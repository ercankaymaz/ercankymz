using System.Runtime.CompilerServices;

namespace System.Diagnostics.Metrics;

internal struct LabelInstruction(int sourceIndex, string labelName)
{
	public int SourceIndex
	{
		[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
		get;
	} = sourceIndex;

	public string LabelName
	{
		[System_002EDiagnostics_002EDiagnosticSource_002EIsReadOnly]
		get;
	} = labelName;
}
