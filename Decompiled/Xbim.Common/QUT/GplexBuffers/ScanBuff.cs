using System.Collections.Generic;
using System.IO;

namespace QUT.GplexBuffers;

public abstract class ScanBuff
{
	private string fileNm;

	public const int EndOfFile = -1;

	public const int UnicodeReplacementChar = 65533;

	public bool IsFile => fileNm != null;

	public string FileName
	{
		get
		{
			return fileNm;
		}
		set
		{
			fileNm = value;
		}
	}

	public abstract long Pos { get; set; }

	public abstract int Read();

	public virtual void Mark()
	{
	}

	public abstract string GetString(long begin, long limit);

	public static ScanBuff GetBuffer(string source)
	{
		return new StringBuffer(source);
	}

	public static ScanBuff GetBuffer(IList<string> source)
	{
		return new LineBuffer(source);
	}

	public static ScanBuff GetBuffer(Stream source)
	{
		return new BuildBuffer(source);
	}

	public static ScanBuff GetBuffer(Stream source, int fallbackCodePage)
	{
		return new BuildBuffer(source, fallbackCodePage);
	}
}
