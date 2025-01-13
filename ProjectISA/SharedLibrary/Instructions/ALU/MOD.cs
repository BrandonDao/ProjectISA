using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("MOD R{data[1]} = R{data[2]} % R{data[3]}")]
    [NamedInstruction("MOD")]
    public class MOD : Instruction
    {
        public override byte OpCode => 0x14;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}