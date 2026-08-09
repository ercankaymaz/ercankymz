using System;

namespace ScintillaNET;

public class AutoCSelectionEventArgs : EventArgs
{
	private readonly Scintilla scintilla;

	private readonly nint textPtr;

	private readonly int bytePosition;

	private int? position;

	private string text;

	public int Char { get; private set; }

	public ListCompletionMethod ListCompletionMethod { get; private set; }

	public int Position
	{
		get
		{
			int valueOrDefault = position.GetValueOrDefault();
			if (!position.HasValue)
			{
				valueOrDefault = scintilla.Lines.ByteToCharPosition(bytePosition);
				position = valueOrDefault;
			}
			return position.Value;
		}
	}

	public unsafe string Text
	{
		get
		{
			if (text == null)
			{
				int i;
				for (i = 0; *(bool*)(textPtr + i); i++)
				{
				}
				text = Helpers.GetString(textPtr, i, scintilla.Encoding);
			}
			return text;
		}
	}

	public AutoCSelectionEventArgs(Scintilla scintilla, int bytePosition, nint text, int ch, ListCompletionMethod listCompletionMethod)
	{
		this.scintilla = scintilla;
		this.bytePosition = bytePosition;
		textPtr = text;
		Char = ch;
		ListCompletionMethod = listCompletionMethod;
	}
}
