using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ScintillaNET;

public class LineCollection : IEnumerable<Line>, IEnumerable
{
	private struct PerLine
	{
		public int Start;

		public ContainsMultibyte ContainsMultibyte;
	}

	private enum ContainsMultibyte
	{
		No = -1,
		Unkown,
		Yes
	}

	private readonly Scintilla scintilla;

	private GapBuffer<PerLine> perLineData;

	private int stepLine;

	private int stepLength;

	public bool AllLinesVisible => scintilla.DirectMessage(2236) != IntPtr.Zero;

	public int Count => perLineData.Count - 1;

	internal int TextLength => CharPositionFromLine(perLineData.Count - 1);

	public Line this[int index]
	{
		get
		{
			index = Helpers.Clamp(index, 0, Count - 1);
			return new Line(scintilla, index);
		}
	}

	private void AdjustLineLength(int index, int delta)
	{
		MoveStep(index);
		stepLength += delta;
		PerLine value = perLineData[index];
		value.ContainsMultibyte = ContainsMultibyte.Unkown;
		perLineData[index] = value;
	}

	internal int ByteToCharPosition(int pos)
	{
		int num = ((IntPtr)scintilla.DirectMessage(2166, new IntPtr(pos))).ToInt32();
		int num2 = ((IntPtr)scintilla.DirectMessage(2167, new IntPtr(num))).ToInt32();
		return CharPositionFromLine(num) + GetCharCount(num2, pos - num2);
	}

	internal int CharLineLength(int index)
	{
		if (index + 1 <= stepLine)
		{
			return perLineData[index + 1].Start - perLineData[index].Start;
		}
		if (index <= stepLine)
		{
			return perLineData[index + 1].Start + stepLength - perLineData[index].Start;
		}
		return perLineData[index + 1].Start + stepLength - (perLineData[index].Start + stepLength);
	}

	internal int CharPositionFromLine(int index)
	{
		int num = perLineData[index].Start;
		if (index > stepLine)
		{
			num += stepLength;
		}
		return num;
	}

	internal int CharToWideBytePosition(int pos)
	{
		int num = LineFromCharPosition(pos);
		int num2 = ((IntPtr)scintilla.DirectMessage(2167, new IntPtr(num))).ToInt32();
		pos -= CharPositionFromLine(num);
		if (!LineContainsMultibyteChar(num))
		{
			return num2 + pos;
		}
		while (pos > 0)
		{
			int num3 = num2;
			num2 = ((IntPtr)scintilla.DirectMessage(2670, new IntPtr(num2), new IntPtr(1))).ToInt32();
			pos = ((num2 - num3 != 1) ? (pos - 2) : (pos - 1));
		}
		return num2;
	}

	internal int CharToBytePosition(int pos)
	{
		int num = LineFromCharPosition(pos);
		int num2 = ((IntPtr)scintilla.DirectMessage(2167, new IntPtr(num))).ToInt32();
		pos -= CharPositionFromLine(num);
		if (!LineContainsMultibyteChar(num))
		{
			return num2 + pos;
		}
		while (pos > 0)
		{
			num2 = ((IntPtr)scintilla.DirectMessage(2670, new IntPtr(num2), new IntPtr(1))).ToInt32();
			pos--;
		}
		return num2;
	}

	private void DeletePerLine(int index)
	{
		MoveStep(index);
		stepLength -= CharLineLength(index);
		perLineData.RemoveAt(index);
		stepLine--;
	}

	private int GetCharCount(int pos, int length)
	{
		return GetCharCount(scintilla.DirectMessage(2643, new IntPtr(pos), new IntPtr(length)), length, scintilla.Encoding);
	}

	private unsafe static int GetCharCount(nint text, int length, Encoding encoding)
	{
		if (text == IntPtr.Zero || length == 0)
		{
			return 0;
		}
		return encoding.GetCharCount((byte*)text, length);
	}

	public IEnumerator<Line> GetEnumerator()
	{
		int count = Count;
		for (int i = 0; i < count; i++)
		{
			yield return this[i];
		}
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	private bool LineContainsMultibyteChar(int index)
	{
		PerLine value = perLineData[index];
		if (value.ContainsMultibyte == ContainsMultibyte.Unkown)
		{
			value.ContainsMultibyte = ((((IntPtr)scintilla.DirectMessage(2350, new IntPtr(index))).ToInt32() != CharLineLength(index)) ? ContainsMultibyte.Yes : ContainsMultibyte.No);
			perLineData[index] = value;
		}
		return value.ContainsMultibyte == ContainsMultibyte.Yes;
	}

	internal int LineFromCharPosition(int pos)
	{
		int num = 0;
		int num2 = Count - 1;
		while (num <= num2)
		{
			int num3 = num + (num2 - num) / 2;
			int num4 = CharPositionFromLine(num3);
			if (pos == num4)
			{
				return num3;
			}
			if (num4 < pos)
			{
				num = num3 + 1;
			}
			else
			{
				num2 = num3 - 1;
			}
		}
		return num - 1;
	}

	private void InsertPerLine(int index, int length = 0)
	{
		MoveStep(index);
		int num = 0;
		PerLine value = perLineData[index];
		num = value.Start;
		value.Start += length;
		perLineData[index] = value;
		value = new PerLine
		{
			Start = num
		};
		perLineData.Insert(index, value);
		stepLength += length;
		stepLine++;
	}

	private void MoveStep(int line)
	{
		if (stepLength == 0)
		{
			stepLine = line;
		}
		else if (stepLine < line)
		{
			while (stepLine < line)
			{
				stepLine++;
				PerLine value = perLineData[stepLine];
				value.Start += stepLength;
				perLineData[stepLine] = value;
			}
		}
		else if (stepLine > line)
		{
			while (stepLine > line)
			{
				PerLine value2 = perLineData[stepLine];
				value2.Start -= stepLength;
				perLineData[stepLine] = value2;
				stepLine--;
			}
		}
	}

	internal void RebuildLineData()
	{
		stepLine = 0;
		stepLength = 0;
		perLineData = new GapBuffer<PerLine>
		{
			new PerLine
			{
				Start = 0
			},
			new PerLine
			{
				Start = 0
			}
		};
		NativeMethods.SCNotification scn = default(NativeMethods.SCNotification);
		int value = ((IntPtr)scintilla.DirectMessage(2154)).ToInt32() - 1;
		scn.linesAdded = new IntPtr(value);
		scn.position = IntPtr.Zero;
		scn.length = scintilla.DirectMessage(2006);
		scn.text = scintilla.DirectMessage(2643, scn.position, scn.length);
		TrackInsertText(scn);
	}

	private void scintilla_SCNotification(object sender, SCNotificationEventArgs e)
	{
		NativeMethods.SCNotification sCNotification = e.SCNotification;
		if (sCNotification.nmhdr.code == 2008)
		{
			ScnModified(sCNotification);
		}
	}

	private void ScnModified(NativeMethods.SCNotification scn)
	{
		if ((scn.modificationType & 2) > 0)
		{
			TrackDeleteText(scn);
		}
		if ((scn.modificationType & 1) > 0)
		{
			TrackInsertText(scn);
		}
	}

	private void TrackDeleteText(NativeMethods.SCNotification scn)
	{
		int num = ((IntPtr)scintilla.DirectMessage(2166, scn.position)).ToInt32();
		if (scn.linesAdded == IntPtr.Zero)
		{
			int charCount = GetCharCount(scn.text, ((IntPtr)scn.length).ToInt32(), scintilla.Encoding);
			AdjustLineLength(num, charCount * -1);
			return;
		}
		int pos = ((IntPtr)scintilla.DirectMessage(2167, new IntPtr(num))).ToInt32();
		int length = ((IntPtr)scintilla.DirectMessage(2350, new IntPtr(num))).ToInt32();
		AdjustLineLength(num, GetCharCount(pos, length) - CharLineLength(num));
		int num2 = ((IntPtr)scn.linesAdded).ToInt32() * -1;
		for (int i = 0; i < num2; i++)
		{
			DeletePerLine(num + 1);
		}
	}

	private void TrackInsertText(NativeMethods.SCNotification scn)
	{
		int num = ((IntPtr)scintilla.DirectMessage(2166, scn.position)).ToInt32();
		if (scn.linesAdded == IntPtr.Zero)
		{
			int charCount = GetCharCount(((IntPtr)scn.position).ToInt32(), ((IntPtr)scn.length).ToInt32());
			AdjustLineLength(num, charCount);
			return;
		}
		int num2 = 0;
		int num3 = 0;
		num2 = ((IntPtr)scintilla.DirectMessage(2167, new IntPtr(num))).ToInt32();
		num3 = ((IntPtr)scintilla.DirectMessage(2350, new IntPtr(num))).ToInt32();
		AdjustLineLength(num, GetCharCount(num2, num3) - CharLineLength(num));
		for (int i = 1; i <= ((IntPtr)scn.linesAdded).ToInt32(); i++)
		{
			int num4 = num + i;
			num2 += num3;
			num3 = ((IntPtr)scintilla.DirectMessage(2350, new IntPtr(num4))).ToInt32();
			InsertPerLine(num4, GetCharCount(num2, num3));
		}
	}

	public LineCollection(Scintilla scintilla)
	{
		this.scintilla = scintilla;
		this.scintilla.SCNotification += scintilla_SCNotification;
		perLineData = new GapBuffer<PerLine>
		{
			new PerLine
			{
				Start = 0
			},
			new PerLine
			{
				Start = 0
			}
		};
	}
}
