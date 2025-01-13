using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("SUB R{data[1]} = R{data[2]} - R{data[3]}")]
    [NamedInstruction("SUB")]
    public class SUB : Instruction
    {
        public override byte OpCode => 0x11;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}