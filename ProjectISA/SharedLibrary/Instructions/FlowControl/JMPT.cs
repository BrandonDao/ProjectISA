using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMPT if R{data[1]} to {(short)((data[2] << 8) | data[3])}")]
    [NamedInstruction("JMPT")]
    public class JMPT : Instruction
    {
        public override byte OpCode => 0x32;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Immediate };
    }
}