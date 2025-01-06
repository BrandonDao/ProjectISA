using SharedLibrary.Instructions;

namespace Assembler
{
    internal static class Assembler
    {
        public static void Assemble(string assemblyFile, string outputFile)
        {
            string[] asmInstructions = File.ReadAllText(assemblyFile).Split("\n");

            List<Instruction> instructions = Instruction.Parse(asmInstructions);

            byte[] bytecode = Instruction.ToByteArray(instructions);

            File.WriteAllBytes(outputFile, bytecode);
        }
    }
}