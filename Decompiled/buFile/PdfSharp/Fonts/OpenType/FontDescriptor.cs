using PdfSharp.Drawing;

namespace PdfSharp.Fonts.OpenType;

internal class FontDescriptor
{
	private readonly string _key;

	private string _fontName;

	private string _weight;

	private float _italicAngle;

	private int _xMin;

	private int _yMin;

	private int _xMax;

	private int _yMax;

	private bool _isFixedPitch;

	private int _underlinePosition;

	private int _underlineThickness;

	private int _strikeoutPosition;

	private int _strikeoutSize;

	private string _version;

	private string _encodingScheme;

	private int _unitsPerEm;

	private int _capHeight;

	private int _xHeight;

	private int _ascender;

	private int _descender;

	private int _leading;

	private int _flags;

	private int _stemV;

	private int _lineSpacing;

	public string Key => _key;

	public string FontName
	{
		get
		{
			return _fontName;
		}
		protected set
		{
			_fontName = value;
		}
	}

	public string Weight
	{
		get
		{
			return _weight;
		}
		private set
		{
			_weight = value;
		}
	}

	public virtual bool IsBoldFace => false;

	public float ItalicAngle
	{
		get
		{
			return _italicAngle;
		}
		protected set
		{
			_italicAngle = value;
		}
	}

	public virtual bool IsItalicFace => false;

	public int XMin
	{
		get
		{
			return _xMin;
		}
		protected set
		{
			_xMin = value;
		}
	}

	public int YMin
	{
		get
		{
			return _yMin;
		}
		protected set
		{
			_yMin = value;
		}
	}

	public int XMax
	{
		get
		{
			return _xMax;
		}
		protected set
		{
			_xMax = value;
		}
	}

	public int YMax
	{
		get
		{
			return _yMax;
		}
		protected set
		{
			_yMax = value;
		}
	}

	public bool IsFixedPitch
	{
		get
		{
			return _isFixedPitch;
		}
		private set
		{
			_isFixedPitch = value;
		}
	}

	public int UnderlinePosition
	{
		get
		{
			return _underlinePosition;
		}
		protected set
		{
			_underlinePosition = value;
		}
	}

	public int UnderlineThickness
	{
		get
		{
			return _underlineThickness;
		}
		protected set
		{
			_underlineThickness = value;
		}
	}

	public int StrikeoutPosition
	{
		get
		{
			return _strikeoutPosition;
		}
		protected set
		{
			_strikeoutPosition = value;
		}
	}

	public int StrikeoutSize
	{
		get
		{
			return _strikeoutSize;
		}
		protected set
		{
			_strikeoutSize = value;
		}
	}

	public string Version
	{
		get
		{
			return _version;
		}
		private set
		{
			_version = value;
		}
	}

	public string EncodingScheme
	{
		get
		{
			return _encodingScheme;
		}
		private set
		{
			_encodingScheme = value;
		}
	}

	public int UnitsPerEm
	{
		get
		{
			return _unitsPerEm;
		}
		protected set
		{
			_unitsPerEm = value;
		}
	}

	public int CapHeight
	{
		get
		{
			return _capHeight;
		}
		protected set
		{
			_capHeight = value;
		}
	}

	public int XHeight
	{
		get
		{
			return _xHeight;
		}
		protected set
		{
			_xHeight = value;
		}
	}

	public int Ascender
	{
		get
		{
			return _ascender;
		}
		protected set
		{
			_ascender = value;
		}
	}

	public int Descender
	{
		get
		{
			return _descender;
		}
		protected set
		{
			_descender = value;
		}
	}

	public int Leading
	{
		get
		{
			return _leading;
		}
		protected set
		{
			_leading = value;
		}
	}

	public int Flags
	{
		get
		{
			return _flags;
		}
		private set
		{
			_flags = value;
		}
	}

	public int StemV
	{
		get
		{
			return _stemV;
		}
		protected set
		{
			_stemV = value;
		}
	}

	public int LineSpacing
	{
		get
		{
			return _lineSpacing;
		}
		protected set
		{
			_lineSpacing = value;
		}
	}

	protected FontDescriptor(string key)
	{
		_key = key;
	}

	internal static string ComputeKey(XFont font)
	{
		return font.GlyphTypeface.Key;
	}

	internal static string ComputeKey(string name, XFontStyle style)
	{
		return ComputeKey(name, (style & XFontStyle.Bold) == XFontStyle.Bold, (style & XFontStyle.Italic) == XFontStyle.Italic);
	}

	internal static string ComputeKey(string name, bool isBold, bool isItalic)
	{
		return name.ToLowerInvariant() + "/" + (isBold ? "b" : "") + (isItalic ? "i" : "");
	}

	internal static string ComputeKey(string name)
	{
		return name.ToLowerInvariant();
	}
}
