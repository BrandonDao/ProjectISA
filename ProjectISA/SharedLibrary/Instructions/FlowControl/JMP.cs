using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMP to {(short)((data[2] << 8) | data[3])}")]
    [NamedInstruction("JMP")]
    public class JMP : Instruction
    {
        public override byte OpCode => 0x30;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Pad, Parts.Immediate };
    }
}