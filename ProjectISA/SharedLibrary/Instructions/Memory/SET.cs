﻿using System.Diagnostics;

namespace SharedLibrary.Instructions.Memory
{
    [DebuggerDisplay("SET R{data[1]} {(short)((data[2] << 8) | data[3])}")]
    public class SET : Instruction
    {
        public override string Name => "SET";
        public override byte OpCode => 0x40;
        protected override Parts.Parser[] PartParsers =>
            new Parts.Parser[] { Parts.Register, Parts.Immediate };
    }
}