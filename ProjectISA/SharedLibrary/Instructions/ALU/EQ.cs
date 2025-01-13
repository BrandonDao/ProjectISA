using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("EQ R{data[1]} = R{data[2]} == R{data[3]}")]
    [NamedInstruction("EQ")]
    public class EQ : Instruction
    {
        public override byte OpCode => 0x24;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}