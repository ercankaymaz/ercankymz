using System;

namespace ScintillaNET;

public class BeforeModificationEventArgs : EventArgs
{
	private readonly Scintilla scintilla;

	private readonly int bytePosition;

	private readonly int byteLength;

	private readonly nint textPtr;

	internal int? CachedPosition { get; set; }

	internal string CachedText { get; set; }

	public int Position
	{
		get
		{
			int? cachedPosition = CachedPosition;
			int valueOrDefault = cachedPosition.GetValueOrDefault();
			if (!cachedPosition.HasValue)
			{
				valueOrDefault = scintilla.Lines.ByteToCharPosition(bytePosition);
				int? cachedPosition2 = valueOrDefault;
				CachedPosition = cachedPosition2;
			}
			return CachedPosition.Value;
		}
	}

	public ModificationSource Source { get; private set; }

	public unsafe virtual string Text
	{
		get
		{
			if (CachedText == null)
			{
				if (textPtr == IntPtr.Zero)
				{
					nint value = scintilla.DirectMessage(2643, new IntPtr(bytePosition), new IntPtr(byteLength));
					CachedText = new string((sbyte*)value, 0, byteLength, scintilla.Encoding);
				}
				else
				{
					CachedText = Helpers.GetString(textPtr, byteLength, scintilla.Encoding);
				}
			}
			return CachedText;
		}
	}

	public BeforeModificationEventArgs(Scintilla scintilla, ModificationSource source, int bytePosition, int byteLength, nint text)
	{
		this.scintilla = scintilla;
		this.bytePosition = bytePosition;
		this.byteLength = byteLength;
		textPtr = text;
		Source = source;
	}
}
