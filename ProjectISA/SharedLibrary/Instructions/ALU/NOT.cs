using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("NOT R{data[1]} = !R{data[2]}")]
    [NamedInstruction("NOT")]
    public class NOT : Instruction
    {
        public override byte OpCode => 0x20;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Pad };
    }
}