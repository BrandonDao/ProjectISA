using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("STRi R{data[1]} to addr in {data[2]}")]
    [NamedInstruction("STRi")]
    public class STRi : Instruction
    {
        public override byte OpCode => 0x45;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Pad };
    }
}