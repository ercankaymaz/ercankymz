using System;

namespace ScintillaNET;

public class InsertCheckEventArgs : EventArgs
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

	public unsafe string Text
	{
		get
		{
			if (CachedText == null)
			{
				string text = (CachedText = Helpers.GetString(textPtr, byteLength, scintilla.Encoding));
			}
			return CachedText;
		}
		set
		{
			CachedText = value ?? string.Empty;
			byte[] bytes = Helpers.GetBytes(CachedText, scintilla.Encoding, zeroTerminated: false);
			fixed (byte* value2 = bytes)
			{
				scintilla.DirectMessage(2672, new IntPtr(bytes.Length), new IntPtr(value2));
			}
		}
	}

	public InsertCheckEventArgs(Scintilla scintilla, int bytePosition, int byteLength, nint text)
	{
		this.scintilla = scintilla;
		this.bytePosition = bytePosition;
		this.byteLength = byteLength;
		textPtr = text;
	}
}
