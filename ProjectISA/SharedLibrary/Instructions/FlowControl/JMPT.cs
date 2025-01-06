﻿using System.Diagnostics;

namespace SharedLibrary.Instructions.FlowControl
{
    [DebuggerDisplay("JMPT if R{data[1]} to {(short)((data[2] << 8) | data[3])}")]
    public class JMPT : Instruction
    {
        public override string Name => "JMP";
        public override byte OpCode => 0x32;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Immediate };
    }
}