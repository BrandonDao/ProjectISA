﻿using System.Diagnostics;

namespace SharedLibrary.Instructions.ALU
{
    [DebuggerDisplay("GTE R{data[1]} = R{data[2]} >= R{data[3]}")]
    [NamedInstruction("GTE")]
    public class GTE : Instruction
    {
        public override byte OpCode => 0x26;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Register, Parts.Register };
    }
}