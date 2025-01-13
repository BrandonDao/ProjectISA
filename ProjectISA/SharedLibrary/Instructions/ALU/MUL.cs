using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("MUL R{data[1]} = R{data[2]} * R{data[3]}")]
    [NamedInstruction("MUL")]
    public class MUL : Instruction
    {
        public override byte OpCode => 0x12;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}