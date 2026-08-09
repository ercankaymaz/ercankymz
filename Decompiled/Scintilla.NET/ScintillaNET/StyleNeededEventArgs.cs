using System;

namespace ScintillaNET;

public class StyleNeededEventArgs : EventArgs
{
	private readonly Scintilla scintilla;

	private readonly int bytePosition;

	private int? position;

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

	public StyleNeededEventArgs(Scintilla scintilla, int bytePosition)
	{
		this.scintilla = scintilla;
		this.bytePosition = bytePosition;
	}
}
