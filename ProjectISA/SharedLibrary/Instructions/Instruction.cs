using SharedLibrary.Instructions.ALU;
using SharedLibrary.Instructions.FlowControl;
using SharedLibrary.Instructions.Memory;
using System.Text.RegularExpressions;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public static class Parts
        {
            public delegate int Parser(string asm, int startIndex, ref int dataIndex, ref byte[] data);
            public static Parser Register => RegisterBacking;
            public static Parser Immediate => ImmediateBacking;
            public static Parser Memory => MemoryBacking;
            public static Parser Pad => PadBacking;

            private static int RegisterBacking(string asm, int startIndex, ref int dataIndex, ref byte[] data)
            {
                for (int i = startIndex; i < asm.Length; i++)
                {
                    if (asm[i] == ' ' || asm[i] == 'R' || asm[i] == 'r') continue;

                    data[dataIndex++] = (byte)(asm[i] - '0');
                    return i + 2;
                }
                throw new ArgumentException($"Could not parse register!");
            }
            private static int ImmediateBacking(string asm, int startIndex, ref int dataIndex, ref byte[] data)
            {
                for (int i = startIndex; i < asm.Length; i++)
                {
                    if (asm[i] == ' ') continue;

                    Match match = Regex.Match(asm[i..], @"([0-9a-fA-F]{1,2}) *([0-9a-fA-F]{1,2})?");

                    if (match.Groups[2].Success) // short vs byte without leading 0's check
                    {
                        data[dataIndex++] = byte.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.AllowHexSpecifier);
                        data[dataIndex++] = byte.Parse(match.Groups[2].Value, System.Globalization.NumberStyles.AllowHexSpecifier);
                    }
                    else
                    {
                        data[dataIndex++] = 0x00;
                        data[dataIndex++] = byte.Parse(match.Groups[1].Value, System.Globalization.NumberStyles.AllowHexSpecifier);
                    }

                    return i + match.Length;
                }
                throw new ArgumentException($"Could not parse memory!");
            }
            private static int MemoryBacking(string asm, int startIndex, ref int dataIndex, ref byte[] data) => throw new NotImplementedException();
            private static int PadBacking(string asm, int startIndex, ref int dataIndex, ref byte[] data)
            {
                data[dataIndex++] = 0xFF;
                return 0;
            }
        }

        private static Dictionary<string, Func<Instruction>> NameToNewInstruction { get; } = new()
        {
            // No Operation
            ["NOP"] = () => new NOP(),
            // Math
            ["ADD"] = () => new ADD(),
            // Flow Control
            ["JMP"] = () => new JMP(),
            // Memory
            ["SET"] = () => new SET(),
        };

        public const byte Length = 4;

        public abstract string Name { get; }
        public abstract byte OpCode { get; }
        public uint MachineCode => (uint)(data![0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
        protected abstract Parts.Parser[] PartParsers { get; }
        protected byte[]? data;

        public static byte[] ToByteArray(List<Instruction> instructions)
        {
            var output = new byte[instructions.Count * Length];
            int outputIndex = 0;
            int instIndex = 0;

            for (; outputIndex < output.Length;)
            {
                for (int i = 0; i < Length; i++)
                {
                    output[outputIndex++] = instructions[instIndex].data![i];
                }
                instIndex++;
            }

            return output;
        }

        public static List<Instruction> Parse(string[] asmInstructions)
            => ParseIL(ParseAssembly(asmInstructions));

        private static (List<string>, Dictionary<string, ushort>) ParseAssembly(string[] asmInstructions)
        {
            Dictionary<string, ushort> LabelToLineMap = new();
            List<string> ParsedASM = new();

            int commentLocation;
            for (short i = 0; i < asmInstructions.Length; i++)
            {
                if (asmInstructions[i] == "\r") continue;

                commentLocation = asmInstructions[i].IndexOf(';');
                if (commentLocation != -1)
                {
                    asmInstructions[i] = asmInstructions[i][..commentLocation];
                }
                asmInstructions[i] = asmInstructions[i].Trim();

                if (asmInstructions[i].Length == 0) continue;

                Match labelMatch = Regex.Match(asmInstructions[i], "([a-zA-Z0-9]*):");
                if (labelMatch.Success)
                {
                    LabelToLineMap.Add(labelMatch.Groups[1].Value, (ushort)ParsedASM.Count);
                }
                else
                {
                    ParsedASM.Add(asmInstructions[i]);
                }
            }

            return (ParsedASM, LabelToLineMap);
        }

        private static List<Instruction> ParseIL((List<string>, Dictionary<string, ushort>) ILInfo)
        {
            List<string> ILInstructions = ILInfo.Item1;
            List<Instruction> parsedILInstructions = new(ILInstructions.Count);

            Dictionary<string, ushort> labelToLineMap = ILInfo.Item2;

            string asm, name;
            int asmIndex, dataIndex, endOfNameIndex, labelIndex;
            Instruction instruction;

            for (int i = 0; i < ILInstructions.Count; i++)
            {
                asm = ILInstructions[i];

                endOfNameIndex = asm.IndexOf(' ');
                name = endOfNameIndex == -1 ? asm : asm[..endOfNameIndex];
                asm = asm[name.Length..];

                instruction = NameToNewInstruction[name].Invoke();
                instruction.data = new byte[Length];
                instruction.data[0] = instruction.OpCode;

                asmIndex = 0;
                dataIndex = 1;

                labelIndex = asm.IndexOf('#');
                if((instruction.OpCode & 0xF0) == 0x30 && (instruction.OpCode & 0x0F) == 0 && labelIndex != -1)
                {
                    asm = asm[..labelIndex] + labelToLineMap[asm[(labelIndex + 1)..]].ToString();
                }

                foreach(Parts.Parser parser in instruction.PartParsers)
                {
                    if (parser == Parts.Pad) continue;

                    asmIndex = parser.Invoke(asm, asmIndex, ref dataIndex, ref instruction.data);

                    if (asmIndex >= asm.Length) break;
                }

                parsedILInstructions.Add(instruction);
            }

            return parsedILInstructions;
        }

    }
}