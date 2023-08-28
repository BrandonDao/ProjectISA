namespace SharedLibrary.Instructions.Memory
{
    internal class SET : Instruction
    {
        public override string Name => "SET";
        public override byte OpCode => 0x40;
        protected override Func<string, byte>[] InstructionParts =>
            new Func<string, byte>[] { Parts.Register, Parts.Memory, Parts.Memory };
    }
}