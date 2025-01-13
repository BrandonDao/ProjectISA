using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMPi to addr in R{data[2]}")]
    [NamedInstruction("JMPi")]
    public class JMPi : Instruction
    {
        public override byte OpCode => 0x31;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Pad, Parts.Register, Parts.Pad};
    }
}