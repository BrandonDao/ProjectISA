using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("COPY to R{data[1]} from R{data[2]}")]
    [NamedInstruction("COPY")]
    public class COPY : Instruction
    {
        public override byte OpCode => 0x41;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Pad };
    }
}