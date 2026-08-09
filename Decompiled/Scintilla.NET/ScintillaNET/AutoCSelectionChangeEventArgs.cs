using System;

namespace ScintillaNET;

public class AutoCSelectionChangeEventArgs : EventArgs
{
	private readonly Scintilla scintilla;

	private readonly nint textPtr;

	private readonly int bytePosition;

	private int? position;

	private string text;

	public int ListType { get; private set; }

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

	public AutoCSelectionChangeEventArgs(Scintilla scintilla, nint text, int bytePosition, int listType)
	{
		this.scintilla = scintilla;
		textPtr = text;
		this.bytePosition = bytePosition;
		ListType = listType;
	}
}
