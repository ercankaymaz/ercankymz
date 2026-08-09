using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ns27;

namespace buMutliTextbox;

public class FileTextSource : TextSource, IDisposable
{
	internal List<int> list_0 = new List<int>();

	internal FileStream fileStream_0;

	internal Encoding encoding_0;

	private System.Windows.Forms.Timer timer_0 = new System.Windows.Forms.Timer();

	[CompilerGenerated]
	internal EventHandler<LineNeededEventArgs> eventHandler_7;

	[CompilerGenerated]
	private EventHandler<LinePushedEventArgs> eventHandler_8;

	[CompilerGenerated]
	private string string_0;

	public string SaveEOL
	{
		[CompilerGenerated]
		get
		{
			return string_0;
		}
		[CompilerGenerated]
		set
		{
			string_0 = value;
		}
	}

	public override Line this[int i]
	{
		get
		{
			if (lines[i] == null)
			{
				Class76.smethod_430(this, i);
				return lines[i];
			}
			return lines[i];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public event EventHandler<LineNeededEventArgs> LineNeeded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LineNeededEventArgs> eventHandler = eventHandler_7;
			EventHandler<LineNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineNeededEventArgs> value2 = (EventHandler<LineNeededEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LineNeededEventArgs> eventHandler = eventHandler_7;
			EventHandler<LineNeededEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineNeededEventArgs> value2 = (EventHandler<LineNeededEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_7, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<LinePushedEventArgs> LinePushed
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LinePushedEventArgs> eventHandler = eventHandler_8;
			EventHandler<LinePushedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LinePushedEventArgs> value2 = (EventHandler<LinePushedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LinePushedEventArgs> eventHandler = eventHandler_8;
			EventHandler<LinePushedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LinePushedEventArgs> value2 = (EventHandler<LinePushedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_8, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public FileTextSource(buMultiTextBox currentTB)
		: base(currentTB)
	{
		timer_0.Interval = 10000;
		timer_0.Tick += timer_0_Tick;
		timer_0.Enabled = true;
		SaveEOL = Environment.NewLine;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		timer_0.Enabled = false;
		try
		{
			Class76.smethod_696(this);
		}
		finally
		{
			timer_0.Enabled = true;
		}
	}

	public void OpenFile(string fileName, Encoding enc)
	{
		Clear();
		if (fileStream_0 != null)
		{
			fileStream_0.Dispose();
		}
		SaveEOL = Environment.NewLine;
		fileStream_0 = new FileStream(fileName, FileMode.Open);
		long length = fileStream_0.Length;
		enc = Class76.smethod_432(enc, fileStream_0);
		Class76.smethod_196(enc, this);
		list_0.Add((int)fileStream_0.Position);
		lines.Add(null);
		list_0.Capacity = (int)(length / 7L + 1000L);
		int num = 0;
		int item = 0;
		BinaryReader binaryReader = new BinaryReader(fileStream_0, enc);
		while (fileStream_0.Position < length)
		{
			item = (int)fileStream_0.Position;
			char c = binaryReader.ReadChar();
			if (c != '\n')
			{
				if (num == 13)
				{
					list_0.Add(item);
					lines.Add(null);
					SaveEOL = "\r";
				}
			}
			else
			{
				list_0.Add((int)fileStream_0.Position);
				lines.Add(null);
			}
			num = c;
		}
		if (num == 13)
		{
			list_0.Add(item);
			lines.Add(null);
		}
		if (length > 2000000L)
		{
			GC.Collect();
		}
		Line[] collection = new Line[100];
		int count = lines.Count;
		lines.AddRange(collection);
		lines.TrimExcess();
		lines.RemoveRange(count, 100);
		int[] collection2 = new int[100];
		count = lines.Count;
		list_0.AddRange(collection2);
		list_0.TrimExcess();
		list_0.RemoveRange(count, 100);
		encoding_0 = enc;
		OnLineInserted(0, Count);
		int num2 = Math.Min(lines.Count, base.CurrentTB.ClientRectangle.Height / base.CurrentTB.CharHeight);
		for (int i = 0; i < num2; i++)
		{
			Class76.smethod_430(this, i);
		}
		NeedRecalc(new TextChangedEventArgs(0, num2 - 1));
		if (base.CurrentTB.WordWrap)
		{
			OnRecalcWordWrap(new TextChangedEventArgs(0, num2 - 1));
		}
	}

	public void CloseFile()
	{
		if (fileStream_0 != null)
		{
			try
			{
				fileStream_0.Dispose();
			}
			catch
			{
			}
		}
		fileStream_0 = null;
	}

	public override void SaveToFile(string fileName, Encoding enc)
	{
		List<int> list = new List<int>(Count);
		string directoryName = Path.GetDirectoryName(fileName);
		string text = Path.Combine(directoryName, Path.GetFileNameWithoutExtension(fileName) + ".tmp");
		StreamReader streamReader = new StreamReader(fileStream_0, encoding_0);
		using (FileStream fileStream = new FileStream(text, FileMode.Create))
		{
			using StreamWriter streamWriter = new StreamWriter(fileStream, enc);
			streamWriter.Flush();
			for (int i = 0; i < Count; i++)
			{
				list.Add((int)fileStream.Length);
				string text2 = Class76.smethod_795(streamReader, i, this);
				bool flag;
				string text3 = ((flag = lines[i] != null && lines[i].IsChanged) ? lines[i].Text : text2);
				if (eventHandler_8 != null)
				{
					LinePushedEventArgs e = new LinePushedEventArgs(text2, i, (!flag) ? null : text3);
					eventHandler_8(this, e);
					if (e.SavedText != null)
					{
						text3 = e.SavedText;
					}
				}
				streamWriter.Write(text3);
				if (i < Count - 1)
				{
					streamWriter.Write(SaveEOL);
				}
				streamWriter.Flush();
			}
		}
		for (int j = 0; j < Count; j++)
		{
			lines[j] = null;
		}
		streamReader.Dispose();
		fileStream_0.Dispose();
		if (File.Exists(fileName))
		{
			File.Delete(fileName);
		}
		File.Move(text, fileName);
		list_0 = list;
		fileStream_0 = new FileStream(fileName, FileMode.Open);
		encoding_0 = enc;
	}

	public override void ClearIsChanged()
	{
		foreach (Line line in lines)
		{
			if (line != null)
			{
				line.IsChanged = false;
			}
		}
	}

	public override void InsertLine(int index, Line line)
	{
		list_0.Insert(index, -1);
		base.InsertLine(index, line);
	}

	public override void RemoveLine(int index, int count)
	{
		list_0.RemoveRange(index, count);
		base.RemoveLine(index, count);
	}

	public override void Clear()
	{
		base.Clear();
	}

	public override int GetLineLength(int i)
	{
		if (lines[i] != null)
		{
			return lines[i].Count;
		}
		return 0;
	}

	public override bool LineHasFoldingStartMarker(int iLine)
	{
		if (lines[iLine] != null)
		{
			return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
		}
		return false;
	}

	public override bool LineHasFoldingEndMarker(int iLine)
	{
		if (lines[iLine] != null)
		{
			return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
		}
		return false;
	}

	public override void Dispose()
	{
		if (fileStream_0 != null)
		{
			fileStream_0.Dispose();
		}
		timer_0.Dispose();
	}
}
