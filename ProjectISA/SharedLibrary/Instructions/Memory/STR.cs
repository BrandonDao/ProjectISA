using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("STR R{data[1]} at {(short)((data[2] << 8) | data[3])}")]
    [NamedInstruction("STR")]
    public class STR : Instruction
    {
        public override byte OpCode => 0x44;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Immediate };
    }
}