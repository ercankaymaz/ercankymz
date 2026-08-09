namespace QUT.GplexBuffers;

internal sealed class StringBuffer : ScanBuff
{
	private string str;

	private long bPos;

	private int sLen;

	public override long Pos
	{
		get
		{
			return bPos;
		}
		set
		{
			bPos = value;
		}
	}

	public StringBuffer(string source)
	{
		str = source;
		sLen = source.Length;
		base.FileName = null;
	}

	public override int Read()
	{
		if (bPos < sLen)
		{
			return str[(int)bPos++];
		}
		if (bPos == sLen)
		{
			bPos++;
			return 10;
		}
		bPos++;
		return -1;
	}

	public override string GetString(long begin, long limit)
	{
		if (limit > sLen)
		{
			limit = sLen;
		}
		if (limit <= begin)
		{
			return "";
		}
		return str.Substring((int)begin, (int)(limit - begin));
	}

	public override string ToString()
	{
		return "StringBuffer";
	}
}
