using System.IO;
using System.Text;

namespace QUT.GplexBuffers;

internal class BuildBuffer : ScanBuff
{
	private class BufferElement
	{
		private StringBuilder bldr = new StringBuilder();

		private StringBuilder next = new StringBuilder();

		private long minIx;

		private long maxIx;

		private long brkIx;

		private bool appendToNext;

		internal long MaxIndex => maxIx;

		internal char this[long index]
		{
			get
			{
				if (index < minIx || index >= maxIx)
				{
					throw new BufferException("Index was outside data buffer");
				}
				if (index < brkIx)
				{
					return bldr[(int)(index - minIx)];
				}
				return next[(int)(index - brkIx)];
			}
		}

		internal BufferElement()
		{
		}

		internal void Append(char[] block, int count)
		{
			maxIx += count;
			if (appendToNext)
			{
				next.Append(block, 0, count);
				return;
			}
			bldr.Append(block, 0, count);
			brkIx = maxIx;
			appendToNext = true;
		}

		internal string GetString(long start, long limit)
		{
			if (limit <= start)
			{
				return "";
			}
			if (start >= minIx && limit <= maxIx)
			{
				if (limit < brkIx)
				{
					return bldr.ToString((int)(start - minIx), (int)(limit - start));
				}
				if (start >= brkIx)
				{
					return next.ToString((int)(start - brkIx), (int)(limit - start));
				}
				return bldr.ToString((int)(start - minIx), (int)(brkIx - start)) + next.ToString(0, (int)(limit - brkIx));
			}
			throw new BufferException("String was outside data buffer");
		}

		internal void Mark(long limit)
		{
			if (limit > brkIx + 16)
			{
				StringBuilder stringBuilder = bldr;
				bldr = next;
				next = stringBuilder;
				next.Length = 0;
				minIx = brkIx;
				brkIx = maxIx;
			}
		}
	}

	private BufferElement data = new BufferElement();

	private long bPos;

	private BlockReader NextBlk;

	private string EncodingName
	{
		get
		{
			if (NextBlk.Target is StreamReader streamReader)
			{
				return streamReader.CurrentEncoding.BodyName;
			}
			return "raw-bytes";
		}
	}

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

	public BuildBuffer(Stream stream)
	{
		if (stream is FileStream fileStream)
		{
			base.FileName = fileStream.Name;
		}
		NextBlk = BlockReaderFactory.Raw(stream);
	}

	public BuildBuffer(Stream stream, int fallbackCodePage)
	{
		if (stream is FileStream fileStream)
		{
			base.FileName = fileStream.Name;
		}
		NextBlk = BlockReaderFactory.Get(stream, fallbackCodePage);
	}

	public override void Mark()
	{
		data.Mark(bPos - 2);
	}

	public override int Read()
	{
		if (bPos < data.MaxIndex)
		{
			return data[bPos++];
		}
		char[] block = new char[4096];
		int num = NextBlk(block, 0, 4096);
		if (num == 0)
		{
			return -1;
		}
		data.Append(block, num);
		return data[bPos++];
	}

	public override string GetString(long begin, long limit)
	{
		return data.GetString(begin, limit);
	}

	public override string ToString()
	{
		return "StringBuilder buffer, encoding: " + EncodingName;
	}
}
