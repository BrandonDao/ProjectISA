using System.Diagnostics;

namespace SharedLibrary.Instructions
{
    [DebuggerDisplay("NOP")]
    public class NOP : Instruction
    {
        public override string Name => "NOP";
        public override byte OpCode => 0x00;
        protected override Parts.Parser[] PartParsers => 
            new Parts.Parser[] { Parts.Pad, Parts.Pad, Parts.Pad };
    }
}