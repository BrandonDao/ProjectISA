using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("OR R{data[1]} = R{data[2]} | R{data[3]}")]
    [NamedInstruction("OR")]
    public class OR : Instruction
    {
        public override byte OpCode => 0x22;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}