using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("PUSH from R{data[1]} to stack")]
    [NamedInstruction("PUSH")]
    public class PUSH : Instruction
    {
        public override byte OpCode => 0x46;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Pad, Parts.Pad };
    }
}