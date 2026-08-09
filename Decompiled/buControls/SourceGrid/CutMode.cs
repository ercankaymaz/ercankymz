using System;

namespace SourceGrid;

public enum CutMode
{
	None,
	[Obsolete("If you want to cut data before paste, then do so explicitly from code before pasting data")]
	CutOnPaste,
	CutImmediately
}
