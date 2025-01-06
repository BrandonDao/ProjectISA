using System.Diagnostics;

namespace SharedLibrary.Instructions.Logic
{
    [DebuggerDisplay("EQ R{data[1]} = R{data[2]} == R{data[3]}")]
    public class EQ : Instruction
    {
        public override string Name => "EQ";
        public override byte OpCode => 0x24;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}