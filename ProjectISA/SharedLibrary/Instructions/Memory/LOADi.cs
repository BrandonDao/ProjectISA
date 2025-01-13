using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("LOADi into R{data[1]} from addr in R{data[2]}")]
    [NamedInstruction("LOADi")]
    public class LOADi : Instruction
    {
        public override byte OpCode => 0x43;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Pad };
    }
}