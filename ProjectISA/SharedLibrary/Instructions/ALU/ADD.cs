namespace SharedLibrary.Instructions.ALU
{

    public class ADD : Instruction
    {
        public override string Name => "ADD";
        public override byte OpCode => 0x10;
        protected override Func<string, byte>[] InstructionParts =>
                new Func<string, byte>[] { Parts.Register, Parts.Register, Parts.Register };
    }
}