using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using ns27;

namespace buMutliTextbox;

public class TextSource : IDisposable, IEnumerable, IList<Line>, ICollection<Line>, IEnumerable<Line>
{
	public class TextChangedEventArgs : EventArgs
	{
		public int iFromLine;

		public int iToLine;

		public TextChangedEventArgs(int iFromLine, int iToLine)
		{
			this.iFromLine = iFromLine;
			this.iToLine = iToLine;
		}
	}

	protected internal readonly List<Line> lines = new List<Line>();

	protected LinesAccessor linesAccessor;

	private int int_0;

	[CompilerGenerated]
	private CommandManager commandManager_0;

	private buMultiTextBox buMultiTextBox_0;

	public readonly Style[] Styles;

	[CompilerGenerated]
	private EventHandler<LineInsertedEventArgs> eventHandler_0;

	[CompilerGenerated]
	private EventHandler<LineRemovedEventArgs> eventHandler_1;

	[CompilerGenerated]
	private EventHandler<TextChangedEventArgs> eventHandler_2;

	[CompilerGenerated]
	private EventHandler<TextChangedEventArgs> eventHandler_3;

	[CompilerGenerated]
	private EventHandler<TextChangedEventArgs> eventHandler_4;

	[CompilerGenerated]
	private EventHandler<TextChangingEventArgs> eventHandler_5;

	[CompilerGenerated]
	internal EventHandler eventHandler_6;

	[CompilerGenerated]
	private TextStyle textStyle_0;

	public CommandManager Manager
	{
		[CompilerGenerated]
		get
		{
			return commandManager_0;
		}
		[CompilerGenerated]
		set
		{
			commandManager_0 = value;
		}
	}

	public buMultiTextBox CurrentTB
	{
		get
		{
			return buMultiTextBox_0;
		}
		set
		{
			if (buMultiTextBox_0 != value)
			{
				buMultiTextBox_0 = value;
				Class76.smethod_252(this);
			}
		}
	}

	public TextStyle DefaultStyle
	{
		[CompilerGenerated]
		get
		{
			return textStyle_0;
		}
		[CompilerGenerated]
		set
		{
			textStyle_0 = value;
		}
	}

	public virtual Line this[int i]
	{
		get
		{
			return lines[i];
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public virtual bool IsNeedBuildRemovedLineIds => eventHandler_1 != null;

	public virtual int Count => lines.Count;

	public virtual bool IsReadOnly => false;

	public event EventHandler<LineInsertedEventArgs> LineInserted
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LineInsertedEventArgs> eventHandler = eventHandler_0;
			EventHandler<LineInsertedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineInsertedEventArgs> value2 = (EventHandler<LineInsertedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LineInsertedEventArgs> eventHandler = eventHandler_0;
			EventHandler<LineInsertedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineInsertedEventArgs> value2 = (EventHandler<LineInsertedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_0, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<LineRemovedEventArgs> LineRemoved
	{
		[CompilerGenerated]
		add
		{
			EventHandler<LineRemovedEventArgs> eventHandler = eventHandler_1;
			EventHandler<LineRemovedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineRemovedEventArgs> value2 = (EventHandler<LineRemovedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<LineRemovedEventArgs> eventHandler = eventHandler_1;
			EventHandler<LineRemovedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<LineRemovedEventArgs> value2 = (EventHandler<LineRemovedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_1, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<TextChangedEventArgs> TextChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_2;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_2;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_2, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<TextChangedEventArgs> RecalcNeeded
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_3;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_3;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_3, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<TextChangedEventArgs> RecalcWordWrap
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_4;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangedEventArgs> eventHandler = eventHandler_4;
			EventHandler<TextChangedEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangedEventArgs> value2 = (EventHandler<TextChangedEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_4, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<TextChangingEventArgs> TextChanging
	{
		[CompilerGenerated]
		add
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_5;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<TextChangingEventArgs> eventHandler = eventHandler_5;
			EventHandler<TextChangingEventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<TextChangingEventArgs> value2 = (EventHandler<TextChangingEventArgs>)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_5, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler CurrentTBChanged
	{
		[CompilerGenerated]
		add
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler eventHandler = eventHandler_6;
			EventHandler eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
				eventHandler = Interlocked.CompareExchange(ref eventHandler_6, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public virtual void ClearIsChanged()
	{
		foreach (Line line in lines)
		{
			line.IsChanged = false;
		}
	}

	public virtual Line CreateLine()
	{
		return new Line(GenerateUniqueLineId());
	}

	public TextSource(buMultiTextBox currentTB)
	{
		CurrentTB = currentTB;
		linesAccessor = new LinesAccessor(this);
		Manager = new CommandManager(this);
		if (!(Enum.GetUnderlyingType(typeof(StyleIndex)) == typeof(uint)))
		{
			Styles = new Style[16];
		}
		else
		{
			Styles = new Style[32];
		}
		InitDefaultStyle();
	}

	public virtual void InitDefaultStyle()
	{
		DefaultStyle = new TextStyle(null, null, FontStyle.Regular);
	}

	public virtual bool IsLineLoaded(int iLine)
	{
		return lines[iLine] != null;
	}

	public virtual IList<string> GetLines()
	{
		return linesAccessor;
	}

	public IEnumerator<Line> GetEnumerator()
	{
		return lines.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return lines as IEnumerator;
	}

	public virtual int BinarySearch(Line item, IComparer<Line> comparer)
	{
		return lines.BinarySearch(item, comparer);
	}

	public virtual int GenerateUniqueLineId()
	{
		return int_0++;
	}

	public virtual void InsertLine(int index, Line line)
	{
		lines.Insert(index, line);
		OnLineInserted(index);
	}

	public virtual void OnLineInserted(int index)
	{
		OnLineInserted(index, 1);
	}

	public virtual void OnLineInserted(int index, int count)
	{
		if (eventHandler_0 != null)
		{
			eventHandler_0(this, new LineInsertedEventArgs(index, count));
		}
	}

	public virtual void RemoveLine(int index)
	{
		RemoveLine(index, 1);
	}

	public virtual void RemoveLine(int index, int count)
	{
		List<int> list = new List<int>();
		if (count > 0 && IsNeedBuildRemovedLineIds)
		{
			for (int i = 0; i < count; i++)
			{
				list.Add(this[index + i].UniqueId);
			}
		}
		lines.RemoveRange(index, count);
		OnLineRemoved(index, count, list);
	}

	public virtual void OnLineRemoved(int index, int count, List<int> removedLineIds)
	{
		if (count > 0 && eventHandler_1 != null)
		{
			eventHandler_1(this, new LineRemovedEventArgs(index, count, removedLineIds));
		}
	}

	public virtual void OnTextChanged(int fromLine, int toLine)
	{
		if (eventHandler_2 != null)
		{
			eventHandler_2(this, new TextChangedEventArgs(Math.Min(fromLine, toLine), Math.Max(fromLine, toLine)));
		}
	}

	public virtual int IndexOf(Line item)
	{
		return lines.IndexOf(item);
	}

	public virtual void Insert(int index, Line item)
	{
		InsertLine(index, item);
	}

	public virtual void RemoveAt(int index)
	{
		RemoveLine(index);
	}

	public virtual void Add(Line item)
	{
		InsertLine(Count, item);
	}

	public virtual void Clear()
	{
		RemoveLine(0, Count);
	}

	public virtual bool Contains(Line item)
	{
		return lines.Contains(item);
	}

	public virtual void CopyTo(Line[] array, int arrayIndex)
	{
		lines.CopyTo(array, arrayIndex);
	}

	public virtual bool Remove(Line item)
	{
		int num = IndexOf(item);
		if (num < 0)
		{
			return false;
		}
		RemoveLine(num);
		return true;
	}

	public virtual void NeedRecalc(TextChangedEventArgs args)
	{
		if (eventHandler_3 != null)
		{
			eventHandler_3(this, args);
		}
	}

	public virtual void OnRecalcWordWrap(TextChangedEventArgs args)
	{
		if (eventHandler_4 != null)
		{
			eventHandler_4(this, args);
		}
	}

	public virtual void OnTextChanging()
	{
		string text = null;
		OnTextChanging(ref text);
	}

	public virtual void OnTextChanging(ref string text)
	{
		if (eventHandler_5 != null)
		{
			TextChangingEventArgs e = new TextChangingEventArgs
			{
				InsertingText = text
			};
			eventHandler_5(this, e);
			text = e.InsertingText;
			if (e.Cancel)
			{
				text = string.Empty;
			}
		}
	}

	public virtual int GetLineLength(int i)
	{
		return lines[i].Count;
	}

	public virtual bool LineHasFoldingStartMarker(int iLine)
	{
		return !string.IsNullOrEmpty(lines[iLine].FoldingStartMarker);
	}

	public virtual bool LineHasFoldingEndMarker(int iLine)
	{
		return !string.IsNullOrEmpty(lines[iLine].FoldingEndMarker);
	}

	public virtual void Dispose()
	{
	}

	public virtual void SaveToFile(string fileName, Encoding enc)
	{
		using StreamWriter streamWriter = new StreamWriter(fileName, append: false, enc);
		for (int i = 0; i < Count - 1; i++)
		{
			streamWriter.WriteLine(lines[i].Text);
		}
		streamWriter.Write(lines[Count - 1].Text);
	}
}
