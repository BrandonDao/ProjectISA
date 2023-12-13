using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMP {(short)((data[2] << 8) | data[3])}")]
    public class JMP : Instruction
    {
        public override string Name => "JMP";
        public override byte OpCode => 0x30;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Pad, Parts.Immediate };
    }
}