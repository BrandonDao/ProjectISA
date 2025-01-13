using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("GT R{data[1]} = R{data[2]} > R{data[3]}")]
    [NamedInstruction("GT")]
    public class GT : Instruction
    {
        public override byte OpCode => 0x28;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}