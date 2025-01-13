﻿using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("XOR R{data[1]} = R{data[2]} ^ R{data[3]}")]
    [NamedInstruction("XOR")]
    public class XOR : Instruction
    {
        public override byte OpCode => 0x23;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}