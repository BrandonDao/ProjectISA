using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("LT R{data[1]} = R{data[2]} & R{data[3]}")]
    [NamedInstruction("LT")]
    public class LT : Instruction
    {
        public override byte OpCode => 0x29;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}