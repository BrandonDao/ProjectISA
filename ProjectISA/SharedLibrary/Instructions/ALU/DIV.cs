using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("DIV R{data[1]} = R{data[2]} / R{data[3]}")]
    [NamedInstruction("DIV")]
    public class DIV : Instruction
    {
        public override byte OpCode => 0x13;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}