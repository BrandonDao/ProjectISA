namespace Assembler
{
    internal class Program
    {
        static void Main()
            => Assembler.Assemble(assemblyFile: @"..\..\..\Assembly\AssemblyProgram.asm", outputFile: @"..\..\..\Assembly\AssembledProgramBytes.bin");
    }
}