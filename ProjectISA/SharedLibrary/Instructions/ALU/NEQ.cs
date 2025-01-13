using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("NEQ R{data[1]} = R{data[2]} != R{data[3]}")]
    [NamedInstruction("NEQ")]
    public class NEQ : Instruction
    {
        public override byte OpCode => 0x25;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}