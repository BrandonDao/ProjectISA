using SharedLibrary.Instructions.ALU;
using SharedLibrary.Instructions.Memory;

namespace SharedLibrary.Instructions
{
    public abstract class Instruction
    {
        public static class Parts
        {
            public static byte Register(string asm) => throw new NotImplementedException();
            public static byte Memory(string asm) => throw new NotImplementedException();
            public static byte Immediate(string asm) => throw new NotImplementedException();
            public static byte Pad(string asm) => 0xFF;
        }

        private static Dictionary<string, Instruction> NameToReferenceInstruction { get; } = new()
        {
            // No Operation
            ["NOP"] = new NOP(),
            // Math
            ["ADD"] = new ADD(),
            // Memory
            ["SET"] = new SET(),
        };

        public const byte Length = 4;

        public abstract string Name { get; }
        public abstract byte OpCode { get; }
        public uint MachineCode => (uint)(data[0] << 24 | data[1] << 16 | data[2] << 8 | data[3]);
        protected abstract Func<string, byte>[] InstructionParts { get; }
        protected byte[] data;

        public static byte[] ToByteArray(List<Instruction> instructions)
        {
            var output = new byte[instructions.Count * Length];
            int outputIndex = 0;
            int instIndex = 0;

            for (; outputIndex < output.Length;)
            {
                for (int i = 0; i < Length; i++)
                {
                    output[outputIndex++] = instructions[instIndex].data[i];
                }
                instIndex++;
            }

            return output;
        }

        public static List<Instruction> Parse(string[] asmInstructions)
            => ParseIL(ParseAssembly(asmInstructions));

        private static List<string> ParseAssembly(string[] asmInstructions)
        {
            Dictionary<string, ushort> LabelToLineMap = new();
            List<string> ParsedASM = new();

            int commentLocation;
            for(short i = 0; i < asmInstructions.Length; i++)
            {
                if (asmInstructions[i] == "\r") continue;

                commentLocation = asmInstructions[i].IndexOf(';');
                if (commentLocation != -1)
                {
                    asmInstructions[i] = asmInstructions[i][..commentLocation];
                }
                asmInstructions[i] = asmInstructions[i].Trim();

                if (asmInstructions[i].Length == 0) continue;

                if (asmInstructions[i][^1] == ':')
                {
                    LabelToLineMap.Add(asmInstructions[i], (ushort)(ParsedASM.Count));
                }
                else
                {
                    ParsedASM.Add(asmInstructions[i]);
                }
            }

            return ParsedASM;        
        }

        private static List<Instruction> ParseIL(List<string> ILInstructions)
        {

            throw new NotImplementedException();
        }

    }
}