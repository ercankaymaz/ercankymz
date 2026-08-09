#define DEBUG
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using PdfSharp.Fonts;
using PdfSharp.Fonts.OpenType;
using PdfSharp.Internal;
using PdfSharp.Pdf;

namespace PdfSharp.Drawing;

[DebuggerDisplay("{DebuggerDisplay}")]
public sealed class XFont
{
	private readonly double _emSize;

	private readonly XFontStyle _style;

	private bool _isVertical;

	private XPdfFontOptions _pdfOptions;

	private int _cellSpace;

	private int _cellAscent;

	private int _cellDescent;

	private XFontMetrics _fontMetrics;

	private XGlyphTypeface _glyphTypeface;

	private OpenTypeDescriptor _descriptor;

	private string _familyName;

	internal int _unitsPerEm;

	internal bool OverrideStyleSimulations;

	internal XStyleSimulations StyleSimulations;

	private readonly FontFamily _gdiFontFamily;

	private Font _gdiFont;

	private string _selector;

	[Browsable(false)]
	public XFontFamily FontFamily => _glyphTypeface.FontFamily;

	public string Name => _glyphTypeface.FontFamily.Name;

	internal string FaceName => _glyphTypeface.FaceName;

	public double Size => _emSize;

	[Browsable(false)]
	public XFontStyle Style => _style;

	public bool Bold => (_style & XFontStyle.Bold) == XFontStyle.Bold;

	public bool Italic => (_style & XFontStyle.Italic) == XFontStyle.Italic;

	public bool Strikeout => (_style & XFontStyle.Strikeout) == XFontStyle.Strikeout;

	public bool Underline => (_style & XFontStyle.Underline) == XFontStyle.Underline;

	internal bool IsVertical
	{
		get
		{
			return _isVertical;
		}
		set
		{
			_isVertical = value;
		}
	}

	public XPdfFontOptions PdfOptions => _pdfOptions ?? (_pdfOptions = new XPdfFontOptions());

	internal bool Unicode => _pdfOptions != null && _pdfOptions.FontEncoding == PdfFontEncoding.Unicode;

	public int CellSpace
	{
		get
		{
			return _cellSpace;
		}
		internal set
		{
			_cellSpace = value;
		}
	}

	public int CellAscent
	{
		get
		{
			return _cellAscent;
		}
		internal set
		{
			_cellAscent = value;
		}
	}

	public int CellDescent
	{
		get
		{
			return _cellDescent;
		}
		internal set
		{
			_cellDescent = value;
		}
	}

	public XFontMetrics Metrics
	{
		get
		{
			Debug.Assert(_fontMetrics != null, "InitializeFontMetrics() not yet called.");
			return _fontMetrics;
		}
	}

	[Browsable(false)]
	public int Height => (int)Math.Ceiling(GetHeight());

	internal XGlyphTypeface GlyphTypeface => _glyphTypeface;

	internal OpenTypeDescriptor Descriptor
	{
		get
		{
			return _descriptor;
		}
		private set
		{
			_descriptor = value;
		}
	}

	internal string FamilyName => _familyName;

	internal int UnitsPerEm
	{
		get
		{
			return _unitsPerEm;
		}
		private set
		{
			_unitsPerEm = value;
		}
	}

	public FontFamily GdiFontFamily => _gdiFontFamily;

	internal Font GdiFont => _gdiFont;

	internal string Selector
	{
		get
		{
			return _selector;
		}
		set
		{
			_selector = value;
		}
	}

	private string DebuggerDisplay => string.Format(CultureInfo.InvariantCulture, "font=('{0}' {1:0.##})", Name, Size);

	public XFont(string familyName, double emSize)
		: this(familyName, emSize, XFontStyle.Regular, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
	{
	}

	public XFont(string familyName, double emSize, XFontStyle style)
		: this(familyName, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
	{
	}

	public XFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
	{
		_familyName = familyName;
		_emSize = emSize;
		_style = style;
		_pdfOptions = pdfOptions;
		Initialize();
	}

	internal XFont(string familyName, double emSize, XFontStyle style, XPdfFontOptions pdfOptions, XStyleSimulations styleSimulations)
	{
		_familyName = familyName;
		_emSize = emSize;
		_style = style;
		_pdfOptions = pdfOptions;
		OverrideStyleSimulations = true;
		StyleSimulations = styleSimulations;
		Initialize();
	}

	public XFont(FontFamily fontFamily, double emSize, XFontStyle style)
		: this(fontFamily, emSize, style, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
	{
	}

	public XFont(FontFamily fontFamily, double emSize, XFontStyle style, XPdfFontOptions pdfOptions)
	{
		_familyName = fontFamily.Name;
		_gdiFontFamily = fontFamily;
		_emSize = emSize;
		_style = style;
		_pdfOptions = pdfOptions;
		InitializeFromGdi();
	}

	public XFont(Font font)
		: this(font, new XPdfFontOptions(GlobalFontSettings.DefaultFontEncoding))
	{
	}

	public XFont(Font font, XPdfFontOptions pdfOptions)
	{
		if (font.Unit != GraphicsUnit.World)
		{
			throw new ArgumentException("Font must use GraphicsUnit.World.");
		}
		_gdiFont = font;
		Debug.Assert(font.Name == font.FontFamily.Name);
		_familyName = font.Name;
		_emSize = font.Size;
		_style = FontStyleFrom(font);
		_pdfOptions = pdfOptions;
		InitializeFromGdi();
	}

	private void Initialize()
	{
		if (_familyName == "Segoe UI Semilight" && (_style & XFontStyle.BoldItalic) == XFontStyle.Italic)
		{
			GetType();
		}
		FontResolvingOptions fontResolvingOptions = (OverrideStyleSimulations ? new FontResolvingOptions(_style, StyleSimulations) : new FontResolvingOptions(_style));
		if (StringComparer.OrdinalIgnoreCase.Compare(_familyName, "PlatformDefault") == 0)
		{
			_familyName = "Calibri";
		}
		_glyphTypeface = XGlyphTypeface.GetOrCreateFrom(_familyName, fontResolvingOptions);
		CreateDescriptorAndInitializeFontMetrics();
	}

	private void InitializeFromGdi()
	{
		try
		{
			Lock.EnterFontFactory();
			if (_gdiFontFamily != null)
			{
				_gdiFont = new Font(_gdiFontFamily, (float)_emSize, (FontStyle)_style, GraphicsUnit.World);
			}
			if (_gdiFont != null)
			{
				_familyName = _gdiFont.FontFamily.Name;
			}
			else
			{
				Debug.Assert(condition: false);
			}
			if (_glyphTypeface == null)
			{
				_glyphTypeface = XGlyphTypeface.GetOrCreateFromGdi(_gdiFont);
			}
			CreateDescriptorAndInitializeFontMetrics();
		}
		finally
		{
			Lock.ExitFontFactory();
		}
	}

	private void CreateDescriptorAndInitializeFontMetrics()
	{
		Debug.Assert(_fontMetrics == null, "InitializeFontMetrics() was already called.");
		_descriptor = (OpenTypeDescriptor)FontDescriptorCache.GetOrCreateDescriptorFor(this);
		_fontMetrics = new XFontMetrics(_descriptor.FontName, _descriptor.UnitsPerEm, _descriptor.Ascender, _descriptor.Descender, _descriptor.Leading, _descriptor.LineSpacing, _descriptor.CapHeight, _descriptor.XHeight, _descriptor.StemV, 0, 0, 0, _descriptor.UnderlinePosition, _descriptor.UnderlineThickness, _descriptor.StrikeoutPosition, _descriptor.StrikeoutSize);
		XFontMetrics metrics = Metrics;
		UnitsPerEm = _descriptor.UnitsPerEm;
		CellAscent = _descriptor.Ascender;
		CellDescent = _descriptor.Descender;
		CellSpace = _descriptor.LineSpacing;
		Debug.Assert(metrics.UnitsPerEm == _descriptor.UnitsPerEm);
	}

	public double GetHeight()
	{
		return (double)CellSpace * _emSize / (double)UnitsPerEm;
	}

	[Obsolete("Use GetHeight() without parameter.")]
	public double GetHeight(XGraphics graphics)
	{
		throw new InvalidOperationException("Honestly: Use GetHeight() without parameter!");
	}

	internal static XFontStyle FontStyleFrom(Font font)
	{
		return (XFontStyle)((font.Bold ? 1 : 0) | (font.Italic ? 2 : 0) | (font.Strikeout ? 8 : 0) | (font.Underline ? 4 : 0));
	}

	public static implicit operator XFont(Font font)
	{
		return new XFont(font);
	}
}
