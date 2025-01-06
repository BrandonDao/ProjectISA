namespace SharedLibrary.Instructions
{
    [AttributeUsage(AttributeTargets.Class)]
    public class NamedInstructionAttribute : Attribute
    {
        public string Name { get; }

        public NamedInstructionAttribute(string name) => Name = name;
    }
}