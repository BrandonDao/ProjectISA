namespace SharedLibrary.Instructions
{
    public class NOP : Instruction
    {
        public override string Name => "NOP";
        public override byte OpCode => 0x00;
        protected override Func<string, byte>[] InstructionParts => 
            new Func<string, byte>[] { Parts.Pad, Parts.Pad, Parts.Pad };
    }
}