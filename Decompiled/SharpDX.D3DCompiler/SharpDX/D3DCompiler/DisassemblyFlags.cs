using System;

namespace SharpDX.D3DCompiler;

[Flags]
public enum DisassemblyFlags
{
	EnableColorCode = 1,
	EnableDefaultValuePrints = 2,
	EnableInstructionNumbering = 4,
	EnableInstructionCycle = 8,
	DisableDebugInformation = 0x10,
	EnableInstructionOffset = 0x20,
	InstructionOnly = 0x40,
	PrintHexLiterals = 0x80,
	None = 0
}
