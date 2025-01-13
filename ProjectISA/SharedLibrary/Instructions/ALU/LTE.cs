using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("LTE R{data[1]} = R{data[2]} <= R{data[3]}")]
    [NamedInstruction("LTE")]
    public class LTE : Instruction
    {
        public override byte OpCode => 0x27;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}