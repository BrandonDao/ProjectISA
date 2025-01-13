using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("AND R{data[1]} = R{data[2]} & R{data[3]}")]
    [NamedInstruction("AND")]
    public class AND : Instruction
    {
        public override byte OpCode => 0x21;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}