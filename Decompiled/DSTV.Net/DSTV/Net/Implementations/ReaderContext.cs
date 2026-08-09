using System.IO;
using System.Threading;

namespace DSTV.Net.Implementations;

public sealed class ReaderContext
{
	private int _lineNumber;

	public int LineNumber => _lineNumber;

	internal TextReader Source { get; init; }

	internal ReaderContext(TextReader source)
	{
		Source = source;
		_lineNumber = 1;
	}

	internal void IncrementLineNumber()
	{
		Interlocked.Increment(ref _lineNumber);
	}
}
