using System;
using System.Drawing;
using System.Drawing.Text;

namespace ComponentFactory.Krypton.Toolkit;

public class AccurateTextMemento : GlobalId, IDisposable
{
	private static AccurateTextMemento _empty;

	private bool _disposeFont;

	private string _text;

	private Size _size;

	private Font _font;

	private StringFormat _format;

	private TextRenderingHint _hint;

	public string Text => _text;

	public Font Font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
		}
	}

	public Size Size => _size;

	public StringFormat Format => _format;

	public bool IsEmpty => _size == Size.Empty;

	internal static AccurateTextMemento Empty
	{
		get
		{
			if (_empty == null)
			{
				_empty = new AccurateTextMemento(string.Empty, null, Size.Empty, StringFormat.GenericDefault, TextRenderingHint.SystemDefault, disposeFont: false);
			}
			return _empty;
		}
	}

	internal AccurateTextMemento(string text, Font font, SizeF sizeF, StringFormat format, TextRenderingHint hint, bool disposeFont)
	{
		_text = text;
		_size = new Size((int)sizeF.Width + 1, (int)sizeF.Height + 1);
		_font = font;
		_format = format;
		_hint = hint;
		_disposeFont = disposeFont;
	}

	public void Dispose()
	{
		if (_disposeFont && _font != null)
		{
			_font.Dispose();
			_font = null;
		}
	}
}
