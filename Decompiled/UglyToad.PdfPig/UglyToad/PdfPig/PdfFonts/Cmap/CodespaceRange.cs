using System;

namespace UglyToad.PdfPig.PdfFonts.Cmap;

internal class CodespaceRange
{
	public ReadOnlyMemory<byte> Start { get; }

	public ReadOnlyMemory<byte> End { get; }

	public int StartInt { get; }

	public int EndInt { get; }

	public int CodeLength { get; }

	public CodespaceRange(ReadOnlyMemory<byte> start, ReadOnlyMemory<byte> end)
	{
		Start = start;
		End = end;
		StartInt = start.Span.ToInt();
		EndInt = end.Span.ToInt();
		CodeLength = start.Length;
	}

	public bool Matches(byte[] code)
	{
		if (code == null)
		{
			throw new ArgumentNullException("code");
		}
		return IsFullMatch(code, code.Length);
	}

	public bool IsFullMatch(byte[] code, int codeLength)
	{
		if (code == null)
		{
			throw new ArgumentNullException("code");
		}
		if (codeLength != CodeLength)
		{
			return false;
		}
		int num = ((ReadOnlySpan<byte>)code).Slice(0, codeLength).ToInt();
		if (num >= StartInt && num <= EndInt)
		{
			return true;
		}
		return false;
	}

	public override string ToString()
	{
		return $"Length {CodeLength}: {StartInt} -> {EndInt}";
	}
}
