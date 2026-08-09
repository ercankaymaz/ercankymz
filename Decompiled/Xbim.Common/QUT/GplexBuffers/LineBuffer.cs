using System.Collections.Generic;
using System.Text;

namespace QUT.GplexBuffers;

internal sealed class LineBuffer : ScanBuff
{
	private IList<string> line;

	private int numLines;

	private string curLine;

	private int cLine;

	private int curLen;

	private long curLineStart;

	private long curLineEnd;

	private long maxPos;

	private long cPos;

	private long cachedPosition;

	private long cachedLineStart;

	private int cachedIxdex;

	public override long Pos
	{
		get
		{
			return cPos;
		}
		set
		{
			cPos = value;
			findIndex(cPos, out cLine, out curLineStart);
			curLine = ((cLine < numLines) ? line[cLine++] : "");
			curLineEnd = curLineStart + curLine.Length;
		}
	}

	public LineBuffer(IList<string> lineList)
	{
		line = lineList;
		numLines = line.Count;
		cPos = (curLineStart = 0L);
		curLine = ((numLines > 0) ? line[0] : "");
		maxPos = (curLineEnd = (curLen = curLine.Length));
		cLine = 1;
		base.FileName = null;
	}

	public override int Read()
	{
		if (cPos < curLineEnd)
		{
			return curLine[(int)(cPos++ - curLineStart)];
		}
		if (cPos++ == curLineEnd)
		{
			return 10;
		}
		if (cLine >= numLines)
		{
			return -1;
		}
		curLine = line[cLine];
		curLen = curLine.Length;
		curLineStart = curLineEnd + 1;
		curLineEnd = curLineStart + curLen;
		if (curLineEnd > maxPos)
		{
			maxPos = curLineEnd;
		}
		cLine++;
		if (curLen <= 0)
		{
			return 10;
		}
		return curLine[0];
	}

	private void findIndex(long pos, out int ix, out long lstart)
	{
		if (pos >= cachedPosition)
		{
			ix = cachedIxdex;
			lstart = cachedLineStart;
		}
		else
		{
			ix = 0;
			lstart = 0L;
		}
		while (ix < numLines)
		{
			int num = line[ix].Length + 1;
			if (pos < lstart + num)
			{
				break;
			}
			lstart += num;
			ix++;
		}
		cachedPosition = pos;
		cachedIxdex = ix;
		cachedLineStart = lstart;
	}

	public override string GetString(long begin, long limit)
	{
		if (begin >= maxPos || limit <= begin)
		{
			return "";
		}
		findIndex(begin, out var ix, out var lstart);
		int num = (int)(begin - lstart);
		findIndex(limit, out var ix2, out var lstart2);
		int num2 = (int)(limit - lstart2);
		string text = line[ix];
		if (ix == ix2)
		{
			if (num2 > text.Length)
			{
				return text.Substring(num) + "\n";
			}
			return text.Substring(num, num2 - num);
		}
		StringBuilder stringBuilder = new StringBuilder();
		if (num < text.Length)
		{
			stringBuilder.Append(text.Substring(num));
		}
		while (true)
		{
			stringBuilder.Append("\n");
			text = line[++ix];
			if (ix >= ix2)
			{
				break;
			}
			stringBuilder.Append(text);
		}
		if (num2 <= text.Length)
		{
			stringBuilder.Append(text.Substring(0, num2));
		}
		else
		{
			stringBuilder.Append(text);
			stringBuilder.Append("\n");
		}
		return stringBuilder.ToString();
	}

	public override string ToString()
	{
		return "LineBuffer";
	}
}
