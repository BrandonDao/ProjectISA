namespace Assembler
{
    internal class Program
    {
        static void Main(string[] args)
            => Assembler.Assemble(assemblyFile: @"..\..\..\Assembly\AssemblyProgram.asm", outputFile: @"..\..\..\Assembly\AssembledProgramBytes.bin");
    }
}