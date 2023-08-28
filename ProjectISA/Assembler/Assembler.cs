using SharedLibrary.Instructions;

namespace Assembler
{
    internal static class Assembler
    {
        public static void Assemble(string assemblyFile, string outputFile)
            => File.WriteAllBytes(outputFile, Instruction.ToByteArray(Instruction.Parse(File.ReadAllText(assemblyFile).Split("\n"))));
    }
}