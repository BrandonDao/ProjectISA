using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("POP from stack into R{data[1]}")]
    [NamedInstruction("POP")]
    public class POP : Instruction
    {
        public override byte OpCode => 0x47;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Pad, Parts.Pad };
    }
}