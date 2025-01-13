using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("LOAD into R{data[1]} value {(short)((data[2] << 8) | data[3])}")]
    [NamedInstruction("LOAD")]
    public class LOAD : Instruction
    {
        public override byte OpCode => 0x42;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Immediate };
    }
}