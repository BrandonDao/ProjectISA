using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMPTi if R{data[1]} to add in {data[2]}")]
    [NamedInstruction("JMPTi")]
    public class JMPTi : Instruction
    {
        public override byte OpCode => 0x33;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Pad };
    }
}