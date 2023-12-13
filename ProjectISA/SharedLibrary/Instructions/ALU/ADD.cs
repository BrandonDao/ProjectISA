using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("ADD R{data[1]} R{data[2]} R{data[3]}")]
    public class ADD : Instruction
    {
        public override string Name => "ADD";
        public override byte OpCode => 0x10;
        protected override Parts.Parser[] PartParsers => 
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}