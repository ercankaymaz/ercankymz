using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using devDept.Eyeshot.Control.Converters;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Eyeshot.Control;

[Serializable]
[TypeConverter(typeof(LegendConverter))]
public class Legend : UserInterfaceBase, IUserInterfaceElement, IUserInterfaceElementBase, ICloneable, ILegend
{
	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<LegendItem, int> _0023_003Dzzv_0024OyQ_0024jrFHONHWmfA_003D_003D;

		public static Func<LegendItem, int> _0023_003Dzf4pqFntZ8LhExa99sA_003D_003D;

		public static Func<LegendItem, int> _0023_003DzdIcOQN97AwTmAvkSOA_003D_003D;

		internal int _0023_003DzSpFNFKtHjF8GqAw7UkK0RIk_003D(LegendItem _0023_003DzDp118Pw_003D)
		{
			return _0023_003DzDp118Pw_003D.Width;
		}

		internal int _0023_003DzjhpeXb_00242rLmR7eeMIhgpIeo_003D(LegendItem _0023_003DzDp118Pw_003D)
		{
			return _0023_003DzDp118Pw_003D.Width;
		}

		internal int _0023_003DzCWmG9TuFIqpk1gTjgtLetmw_003D(LegendItem _0023_003DzDp118Pw_003D)
		{
			return _0023_003DzDp118Pw_003D.Width;
		}
	}

	public enum positionType
	{
		TopLeft,
		TopRight,
		BottomRight,
		BottomLeft
	}

	private TextureBase titleTexture;

	private TextureBase subtitleTexture;

	private TextureBase[] textTextures;

	private LegendItem[] _items;

	private double[] values;

	private int _gap;

	internal bool dirtyTextures = true;

	private string _title;

	private string _subTitle;

	private bool _slave;

	private bool _tapered;

	private string _formatString;

	private bool _alignValuesRight;

	private bool _alignValuesVerticalMiddle;

	private Color _textBackgroundColor;

	private Color _textColor;

	private Color _titleColor;

	private Font _internalTextFont;

	private Font _userTextFont;

	private Font _internalTitleFont;

	private Font _userTitleFont;

	private double _titleSizeFactor = 1.5;

	private bool _lighting;

	private float _lastUsedScaleFactor;

	private Rectangle boundsInViewport;

	[Description("The legend's color table.")]
	[Obsolete("This property is deprecated. Use Legend.Items property.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public Color[] ColorTable
	{
		get
		{
			Color[] array = new Color[_items.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = _items[i].Color;
			}
			return array;
		}
		set
		{
			_items = _0023_003DzxsxVU7oYWgS7(_0023_003DzpDYcwH01f_0024GA(), value);
			SetRange(values[0], values[values.Length - 1]);
		}
	}

	[Description("The legend's items.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public LegendItem[] Items
	{
		get
		{
			return _items;
		}
		set
		{
			_items = value;
			SetRange(values[0], values[values.Length - 1]);
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public double[] Values => values;

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend minimum value.")]
	public double Min
	{
		get
		{
			return values[0];
		}
		set
		{
			if (values[0] != value)
			{
				SetRange(value, values[values.Length - 1]);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend maximum value.")]
	public double Max
	{
		get
		{
			return values[values.Length - 1];
		}
		set
		{
			if (values[values.Length - 1] != value)
			{
				SetRange(values[0], value);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend items vertical gap.")]
	public int Gap
	{
		get
		{
			return _gap;
		}
		set
		{
			_gap = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend's title.")]
	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			if (_title != value)
			{
				dirtyTextures = true;
				_title = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend's subtitle.")]
	public string Subtitle
	{
		get
		{
			return _subTitle;
		}
		set
		{
			if (_subTitle != value)
			{
				dirtyTextures = true;
				_subTitle = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When true, the legend min and max values are set automatically.")]
	public bool Slave
	{
		get
		{
			return _slave;
		}
		set
		{
			if (_slave != value)
			{
				dirtyTextures = true;
				_slave = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When true, the legend items are drawn with variable width.")]
	public bool Tapered
	{
		get
		{
			return _tapered;
		}
		set
		{
			if (_tapered != value)
			{
				dirtyTextures = true;
				_tapered = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Visibility status.")]
	public bool Visible { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Value's numeric format. Useful to change number format and decimal places.")]
	public string FormatString
	{
		get
		{
			return _formatString;
		}
		set
		{
			if (_formatString != value)
			{
				dirtyTextures = true;
				_formatString = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true, values are aligned right.")]
	public bool AlignValuesRight
	{
		get
		{
			return _alignValuesRight;
		}
		set
		{
			if (_alignValuesRight != value)
			{
				dirtyTextures = true;
				_alignValuesRight = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("If true, the values are vertically aligned to the middle of the color rectangles.")]
	public bool AlignValuesVerticalMiddle
	{
		get
		{
			return _alignValuesVerticalMiddle;
		}
		set
		{
			dirtyTextures = true;
			_alignValuesVerticalMiddle = value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Text background color (supports semi-transparent colors).")]
	public Color TextBackgroundColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_textBackgroundColor);
		}
		set
		{
			if (_textBackgroundColor != RenderContextUtility.ConvertColor(value))
			{
				dirtyTextures = true;
				_textBackgroundColor = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Value text color.")]
	public Color TextColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_textColor);
		}
		set
		{
			if (_textColor != RenderContextUtility.ConvertColor(value))
			{
				dirtyTextures = true;
				_textColor = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Title text color.")]
	public Color TitleColor
	{
		get
		{
			return RenderContextUtility.ConvertColor(_titleColor);
		}
		set
		{
			if (_titleColor != RenderContextUtility.ConvertColor(value))
			{
				dirtyTextures = true;
				_titleColor = RenderContextUtility.ConvertColor(value);
			}
		}
	}

	[Description("Value font.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Font TextFont
	{
		get
		{
			return _userTextFont ?? _internalTextFont;
		}
		set
		{
			if (_userTextFont != value)
			{
				dirtyTextures = true;
				_userTextFont = value;
			}
		}
	}

	[Description("Title font.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Font TitleFont
	{
		get
		{
			return _userTitleFont ?? _internalTitleFont;
		}
		set
		{
			if (_userTitleFont != value)
			{
				dirtyTextures = true;
				_userTitleFont = value;
			}
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("When false, the UI element is drawn with a flat color.")]
	public bool Lighting
	{
		get
		{
			return _lighting;
		}
		set
		{
			_lighting = value;
			dirtyTextures = true;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("Legend position type.")]
	public positionType PositionMode { get; set; }

	public Interval Range => new Interval(Min, Max);

	public static LegendItem[] RedToBlue17 => new LegendItem[17]
	{
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 0, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 63, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 127, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 191, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 191))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 127))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 63))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(63, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(127, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(191, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 191, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 127, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 63, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 0, 0)))
	};

	public static LegendItem[] RedToBlue9 => new LegendItem[9]
	{
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 0, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 127, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 127))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(127, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 127, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 0, 0)))
	};

	public static LegendItem[] RedToBlue33 => new LegendItem[33]
	{
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 0, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 31, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 63, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 95, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 127, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 159, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 191, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 223, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 255))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 223))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 191))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 159))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 127))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 95))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 63))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 31))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(31, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(63, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(95, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(127, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(159, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(191, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(223, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 223, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 191, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 159, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 127, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 95, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 63, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 31, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 0, 0)))
	};

	public static LegendItem[] FactorOfSafety4 => new LegendItem[4]
	{
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height, RenderContextUtility.ConvertColor(Color.FromArgb(255, 0, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height * 4, RenderContextUtility.ConvertColor(Color.FromArgb(255, 180, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height * 5, RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, 0))),
		new LegendItem(_0023_003DzpDYcwH01f_0024GA().Width, _0023_003DzpDYcwH01f_0024GA().Height * 5, RenderContextUtility.ConvertColor(Color.FromArgb(0, 0, 255)))
	};

	public Legend()
		: this(_0023_003DzLTSG1DMTMi6n(), _0023_003DzzXycK2aQ0pa_0024(), _0023_003DzTggvRpdisiKK(), _0023_003DzMRNqQ0KWS3dQ(), _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D(), _0023_003DzWUgmeE8YqcXs(), _0023_003DzrjW6l6h7vFxv(), _0023_003DzrsH054jmpxCH(), _0023_003DzSKb0W00Eht0_0024(), _0023_003DzsUEvb2UyM8Zl(), _0023_003Dzv93YZ0pQ1MSo(), _0023_003DzbSgMkPItqhfn(), lighting: true, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D(), _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(Color[] colorTable)
	{
		LegendItem[] _0023_003DzUl92GdI_003D = _0023_003DzxsxVU7oYWgS7(_0023_003DzpDYcwH01f_0024GA(), colorTable);
		_0023_003DzshPEPAc_003D(_0023_003DzLTSG1DMTMi6n(), _0023_003DzzXycK2aQ0pa_0024(), _0023_003DzTggvRpdisiKK(), _0023_003DzMRNqQ0KWS3dQ(), _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D(), _0023_003DzWUgmeE8YqcXs(), _0023_003DzrjW6l6h7vFxv(), _0023_003DzrsH054jmpxCH(), _0023_003DzSKb0W00Eht0_0024(), _0023_003DzsUEvb2UyM8Zl(), _0023_003Dzv93YZ0pQ1MSo(), _0023_003DzUl92GdI_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D(), _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	public Legend(LegendItem[] items)
	{
		_0023_003DzshPEPAc_003D(_0023_003DzLTSG1DMTMi6n(), _0023_003DzzXycK2aQ0pa_0024(), _0023_003DzTggvRpdisiKK(), _0023_003DzMRNqQ0KWS3dQ(), _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D(), _0023_003DzndG2TcxO_tb_0024(), _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D(), _0023_003DzWUgmeE8YqcXs(), _0023_003DzrjW6l6h7vFxv(), _0023_003DzrsH054jmpxCH(), _0023_003DzSKb0W00Eht0_0024(), _0023_003DzsUEvb2UyM8Zl(), _0023_003Dzv93YZ0pQ1MSo(), items, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D(), _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	protected Legend(Legend another)
		: this(another.Min, another.Max, another.Title, another.Subtitle, another.Slave, another.Visible, another.AlignValuesRight, another.FormatString, another._textBackgroundColor, another._titleColor, another._textColor, another.TitleFont, another.TextFont, another.Items, another.Lighting, another.AlignValuesVerticalMiddle, another.Tapered, another.Gap, another.PositionMode)
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Font titleFont, Font textFont, Color[] colorTable)
	{
		LegendItem[] _0023_003DzUl92GdI_003D = _0023_003DzxsxVU7oYWgS7(itemSize, colorTable);
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, titleFont, textFont, _0023_003DzUl92GdI_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: true, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D(), _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Color[] colorTable)
	{
		LegendItem[] _0023_003DzUl92GdI_003D = _0023_003DzxsxVU7oYWgS7(itemSize, colorTable);
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, null, null, _0023_003DzUl92GdI_003D, _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D: false, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D(), _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Font titleFont, Font textFont, Color[] colorTable, bool lighting)
		: this(min, max, title, subtitle, position, itemSize, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, titleFont, textFont, colorTable, lighting, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Color[] colorTable, bool lighting)
		: this(min, max, title, subtitle, position, itemSize, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, colorTable, lighting, _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D())
	{
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Color[] colorTable, bool lighting, bool alignVerticalMiddle)
	{
		LegendItem[] _0023_003DzUl92GdI_003D = _0023_003DzxsxVU7oYWgS7(itemSize, colorTable);
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, null, null, _0023_003DzUl92GdI_003D, lighting, alignVerticalMiddle, _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, Size itemSize, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Font titleFont, Font textFont, Color[] colorTable, bool lighting, bool alignVerticalMiddle)
	{
		LegendItem[] _0023_003DzUl92GdI_003D = _0023_003DzxsxVU7oYWgS7(itemSize, colorTable);
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, titleFont, textFont, _0023_003DzUl92GdI_003D, lighting, alignVerticalMiddle, _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D(), _0023_003DzWPqWQ0HY83ZO(), _0023_003Dz_00245L9XmHWQLb3());
	}

	[Obsolete("This constructor is deprecated.")]
	public Legend(double min, double max, string title, string subtitle, Point position, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Font titleFont, Font textFont, LegendItem[] items, bool lighting, bool alignVerticalMiddle, bool tapered, int gap)
	{
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, titleFont, textFont, items, lighting, alignVerticalMiddle, tapered, gap, _0023_003Dz_00245L9XmHWQLb3());
	}

	public Legend(double min, double max, string title, string subtitle, bool slave, bool visible, bool alignRight, string formatString, Color textBackgroundColor, Color titleColor, Color textColor, Font titleFont, Font textFont, LegendItem[] items, bool lighting, bool alignVerticalMiddle, bool tapered, int gap, positionType positionType)
	{
		_0023_003DzshPEPAc_003D(min, max, title, subtitle, slave, visible, alignRight, formatString, textBackgroundColor, titleColor, textColor, titleFont, textFont, items, lighting, alignVerticalMiddle, tapered, gap, positionType);
	}

	Color[] ILegend.GetColorTable()
	{
		if (_items == null)
		{
			return null;
		}
		Color[] array = new Color[_items.Length];
		for (int i = 0; i < _items.Length; i++)
		{
			array[i] = RenderContextUtility.ConvertColor(_items[i].Color);
		}
		return array;
	}

	public override void ScaleForDPI()
	{
		_items = UtilityEx._0023_003DzowV4NhAf418J(_items, UtilityEx.GetScalingLevel());
		TitleFont = UtilityEx._0023_003DzowV4NhAf418J(TitleFont, _0023_003DzzihtqSXtvdcF: true, UtilityEx.GetScalingLevel());
		TextFont = UtilityEx._0023_003DzowV4NhAf418J(TextFont, _0023_003DzzihtqSXtvdcF: true, UtilityEx.GetScalingLevel());
	}

	private static LegendItem[] _0023_003DzbSgMkPItqhfn()
	{
		return RedToBlue9;
	}

	private bool _0023_003DzK_0024AidVXW0242()
	{
		return !_0023_003DzpaIKcm5gz1Fx(_items, _0023_003DzbSgMkPItqhfn());
	}

	private bool _0023_003Dz7oV713_Uf_VY()
	{
		return !_0023_003DzpaIKcm5gz1Fx(_items, _0023_003DzbSgMkPItqhfn());
	}

	internal void _0023_003Dzku7UtL92Zsrc()
	{
		Items = _0023_003DzbSgMkPItqhfn();
	}

	private bool _0023_003DzpaIKcm5gz1Fx(LegendItem[] _0023_003Dzqg8dByU_003D, LegendItem[] _0023_003DzwrjjMP0_003D)
	{
		if (_0023_003Dzqg8dByU_003D.Length != _0023_003DzwrjjMP0_003D.Length)
		{
			return false;
		}
		for (int i = 0; i < _0023_003Dzqg8dByU_003D.Length; i++)
		{
			if (_0023_003Dzqg8dByU_003D[i].Width != _0023_003DzwrjjMP0_003D[i].Width && _0023_003Dzqg8dByU_003D[i].Height != _0023_003DzwrjjMP0_003D[i].Height && RenderContextUtility.ConvertColor(_0023_003Dzqg8dByU_003D[i].Color).ToArgb() != RenderContextUtility.ConvertColor(_0023_003DzwrjjMP0_003D[i].Color).ToArgb())
			{
				return false;
			}
		}
		return true;
	}

	protected virtual string GetStringValue(int n)
	{
		return string.Format(FormatString, values[n]);
	}

	public void SetRange(double min, double max)
	{
		if (values == null || values.Length != _items.Length + 1)
		{
			int num = ((_items != null) ? (_items.Length + 1) : 2);
			values = new double[num];
		}
		int num2 = values.Length;
		if (num2 > 0)
		{
			values[0] = min;
			values[num2 - 1] = max;
			double num3 = (max - min) / (double)(num2 - 1);
			for (int i = 1; i < num2 - 1; i++)
			{
				values[i] = values[i - 1] + num3;
			}
		}
		dirtyTextures = true;
	}

	private static double _0023_003DzLTSG1DMTMi6n()
	{
		return 0.0;
	}

	private static double _0023_003DzzXycK2aQ0pa_0024()
	{
		return 100.0;
	}

	private static int _0023_003DzWPqWQ0HY83ZO()
	{
		return 0;
	}

	private static string _0023_003DzTggvRpdisiKK()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348647769);
	}

	private static string _0023_003DzMRNqQ0KWS3dQ()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649177);
	}

	internal static Size _0023_003DzpDYcwH01f_0024GA()
	{
		return new Size(10, 30);
	}

	internal static Color _0023_003DzaiEN3rzYDoWa()
	{
		return Color.Blue;
	}

	private static bool _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D()
	{
		return true;
	}

	private static bool _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D()
	{
		return false;
	}

	private static bool _0023_003DzndG2TcxO_tb_0024()
	{
		return true;
	}

	private static Color _0023_003DzrjW6l6h7vFxv()
	{
		return Color.Transparent;
	}

	private static Color _0023_003DzrsH054jmpxCH()
	{
		return Color.Black;
	}

	private static Color _0023_003DzSKb0W00Eht0_0024()
	{
		return Color.Black;
	}

	private static positionType _0023_003Dz_00245L9XmHWQLb3()
	{
		return positionType.TopLeft;
	}

	private static Font _0023_003DzsUEvb2UyM8Zl()
	{
		return null;
	}

	private static Font _0023_003Dzv93YZ0pQ1MSo()
	{
		return null;
	}

	private static bool _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D()
	{
		return false;
	}

	private void _0023_003DzshPEPAc_003D(double _0023_003DzoYJjnU0_003D, double _0023_003DzWRFixiU_003D, string _0023_003DzPw_8sZI_003D, string _0023_003Dze7Mrqg_k1C6e, bool _0023_003DzPv3rWyTKecF_0024, bool _0023_003DzbWHNjOg_003D, bool _0023_003DzWRi1PeihkBHg, string _0023_003Dzls52r2I_003D, Color _0023_003DzXn771es_0024NB9x, Color _0023_003DzNm8rTLA_003D, Color _0023_003Dzlxpb_Og_003D, Font _0023_003Dz4pjcwNJUU1SU, Font _0023_003DzDKqDnmtyvc31, LegendItem[] _0023_003DzUl92GdI_003D, bool _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D, bool _0023_003DzvtBG2srPizSw, bool _0023_003Dzxm6M_00249xm51JX, int _0023_003Dzy50wP2s_003D, positionType _0023_003Dzk55ySW0_003D)
	{
		SetRange(_0023_003DzoYJjnU0_003D, _0023_003DzWRFixiU_003D);
		FormatString = _0023_003Dzls52r2I_003D;
		Title = _0023_003DzPw_8sZI_003D;
		Subtitle = _0023_003Dze7Mrqg_k1C6e;
		Slave = _0023_003DzPv3rWyTKecF_0024;
		Visible = _0023_003DzbWHNjOg_003D;
		AlignValuesRight = _0023_003DzWRi1PeihkBHg;
		AlignValuesVerticalMiddle = _0023_003DzvtBG2srPizSw;
		TextBackgroundColor = _0023_003DzXn771es_0024NB9x;
		TextColor = _0023_003Dzlxpb_Og_003D;
		TitleColor = _0023_003DzNm8rTLA_003D;
		Items = _0023_003DzUl92GdI_003D;
		Lighting = _0023_003DzUuC7n1U7RpSVakVO4A_003D_003D;
		Tapered = _0023_003Dzxm6M_00249xm51JX;
		Gap = _0023_003Dzy50wP2s_003D;
		TextFont = _0023_003DzDKqDnmtyvc31;
		TitleFont = _0023_003Dz4pjcwNJUU1SU;
		PositionMode = _0023_003Dzk55ySW0_003D;
	}

	private static LegendItem[] _0023_003DzxsxVU7oYWgS7(Size _0023_003Dz0ERMHbg_003D, Color[] _0023_003DzXSIcYos_003D)
	{
		LegendItem[] array = new LegendItem[_0023_003DzXSIcYos_003D.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new LegendItem(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height, _0023_003DzXSIcYos_003D[i]);
		}
		return array;
	}

	private bool _0023_003Dzf_jaeaDk9O_s()
	{
		return Min != _0023_003DzLTSG1DMTMi6n();
	}

	private void _0023_003Dz6F5GRlXXsvuE()
	{
		Min = _0023_003DzLTSG1DMTMi6n();
	}

	private bool _0023_003Dz4hs_7LPj2MKK()
	{
		return Max != _0023_003DzzXycK2aQ0pa_0024();
	}

	private void _0023_003Dz_HtcTBW8S4fZ()
	{
		Max = _0023_003DzzXycK2aQ0pa_0024();
	}

	private bool _0023_003DzSGGhmSU3l1XH()
	{
		return Gap != _0023_003DzWPqWQ0HY83ZO();
	}

	private void _0023_003DzcYpPsWHQYbZl()
	{
		Gap = _0023_003DzWPqWQ0HY83ZO();
	}

	private bool _0023_003DzyhWwmgq8mZ64()
	{
		return Title != _0023_003DzTggvRpdisiKK();
	}

	private void _0023_003Dz8UTa_YRK7i0_0024()
	{
		Title = _0023_003DzTggvRpdisiKK();
	}

	private bool _0023_003Dz1qZK8cnaX4Tc()
	{
		return Subtitle != _0023_003DzMRNqQ0KWS3dQ();
	}

	private void _0023_003Dz3sL44IBZiQdO()
	{
		Subtitle = _0023_003DzMRNqQ0KWS3dQ();
	}

	private bool _0023_003DzbpuVfS2oHm6y660Cuw_003D_003D()
	{
		return Slave != _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D();
	}

	private void _0023_003DzgV3ZYvkDa8CE()
	{
		Slave = _0023_003Dz3mD_0024WJYqJTQ3DyJwJA_003D_003D();
	}

	private bool _0023_003DznD_I3ZF8ySyBG_0HoQ_003D_003D()
	{
		return Tapered != _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D();
	}

	private void _0023_003DzucnVtS9GrlQroxCLgQ_003D_003D()
	{
		Tapered = _0023_003DzFGnGk_lsOw1NuvQP5w_003D_003D();
	}

	private bool _0023_003Dz3SV_00249FPfwz1J()
	{
		return Visible != _0023_003DzndG2TcxO_tb_0024();
	}

	private void _0023_003DzGUdRoqIEEze_()
	{
		Visible = _0023_003DzndG2TcxO_tb_0024();
	}

	private static string _0023_003DzWUgmeE8YqcXs()
	{
		return _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589512);
	}

	private bool _0023_003Dze1UPisCj1fP_()
	{
		return FormatString != _0023_003DzWUgmeE8YqcXs();
	}

	private void _0023_003Dzszxv4cIWEC2P()
	{
		FormatString = _0023_003DzWUgmeE8YqcXs();
	}

	private static bool _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D()
	{
		return false;
	}

	private bool _0023_003Dzq14AQiLnBAHaZOMIJA_003D_003D()
	{
		return AlignValuesRight != _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D();
	}

	private void _0023_003Dzvhn0aw4uA19U_00245xo8w_003D_003D()
	{
		AlignValuesRight = _0023_003DztDzI4kYKU0QmdpjwYA_003D_003D();
	}

	private bool _0023_003DziubJv2yZ3PdIaauB_0024UbSWv8_003D()
	{
		return _alignValuesVerticalMiddle != _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D();
	}

	private void _0023_003DzbYwM3FyD6Af5C18O3A_003D_003D()
	{
		_alignValuesVerticalMiddle = _0023_003DzAo5vF6hGOR6EQtmSCQ_003D_003D();
	}

	private bool _0023_003DzotpSg_0024Cq4FMI8VqXCQ_003D_003D()
	{
		return !RenderContextUtility.AreEqual(TextBackgroundColor, _0023_003DzrjW6l6h7vFxv());
	}

	private void _0023_003DzB9_pUr_0024q6fae()
	{
		TextBackgroundColor = RenderContextUtility.ConvertColor(_0023_003DzrjW6l6h7vFxv());
	}

	private bool _0023_003DzR7lfdPM5Ly7X()
	{
		return !RenderContextUtility.AreEqual(TextColor, _0023_003DzSKb0W00Eht0_0024());
	}

	private void _0023_003DzXYtd_0024aXemTQ_0024()
	{
		TextColor = RenderContextUtility.ConvertColor(_0023_003DzSKb0W00Eht0_0024());
	}

	private bool _0023_003DzQgTabGKsg1qw()
	{
		return !RenderContextUtility.AreEqual(TitleColor, _0023_003DzrsH054jmpxCH());
	}

	private void _0023_003DzG_KX9ln53_00248q()
	{
		TitleColor = RenderContextUtility.ConvertColor(_0023_003DzrsH054jmpxCH());
	}

	internal static void _0023_003DzyEl5vhuM_0024afX(Legend _0023_003DztLDbz5AIMKeP)
	{
		if (_0023_003DztLDbz5AIMKeP._userTextFont != null)
		{
			return;
		}
		if (_0023_003DztLDbz5AIMKeP.ParentViewport != null && _0023_003DztLDbz5AIMKeP.ParentViewport._0023_003Dz0TvaYNo_003D != null)
		{
			if (_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(_0023_003DztLDbz5AIMKeP.ParentViewport._0023_003Dz0TvaYNo_003D.Font, ref _0023_003DztLDbz5AIMKeP._internalTextFont))
			{
				_0023_003DztLDbz5AIMKeP.dirtyTextures = true;
			}
		}
		else if (_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(System.Windows.Forms.Control.DefaultFont, ref _0023_003DztLDbz5AIMKeP._internalTextFont))
		{
			_0023_003DztLDbz5AIMKeP.dirtyTextures = true;
		}
	}

	private static bool _0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(Font _0023_003DzQMi_00244nsHFihL, ref Font _0023_003Dz7t7IPa3k6ngt)
	{
		if (_0023_003Dz7t7IPa3k6ngt == null || !_0023_003Dz0dthF5eGi0Zx(_0023_003Dz7t7IPa3k6ngt, _0023_003DzQMi_00244nsHFihL))
		{
			if (_0023_003Dz7t7IPa3k6ngt != null)
			{
				_0023_003Dz7t7IPa3k6ngt.Dispose();
			}
			_0023_003Dz7t7IPa3k6ngt = (Font)_0023_003DzQMi_00244nsHFihL.Clone();
			return true;
		}
		return false;
	}

	private static bool _0023_003Dz0dthF5eGi0Zx(Font _0023_003Dza3F5O2M_003D, Font _0023_003Dzsvj3qxQ_003D)
	{
		if (_0023_003Dza3F5O2M_003D.FontFamily.Name == _0023_003Dzsvj3qxQ_003D.FontFamily.Name && _0023_003Dza3F5O2M_003D.Style == _0023_003Dzsvj3qxQ_003D.Style)
		{
			return _0023_003Dza3F5O2M_003D.Height == _0023_003Dzsvj3qxQ_003D.Height;
		}
		return false;
	}

	private bool _0023_003Dz7tZ_0024PR01p2VZ()
	{
		return TextFont != null;
	}

	private void _0023_003DzsF7yMRKiuC_s()
	{
		TextFont = _0023_003Dzv93YZ0pQ1MSo();
	}

	internal static void _0023_003DzQGFu9f8GtnTq(Legend _0023_003DztLDbz5AIMKeP)
	{
		if (_0023_003DztLDbz5AIMKeP._userTitleFont != null)
		{
			return;
		}
		if (_0023_003DztLDbz5AIMKeP.ParentViewport != null && _0023_003DztLDbz5AIMKeP.ParentViewport._0023_003Dz0TvaYNo_003D != null)
		{
			Font font = _0023_003DztLDbz5AIMKeP.ParentViewport._0023_003Dz0TvaYNo_003D.Font;
			Font font2 = new Font(font.FontFamily, Convert.ToSingle((double)font.Size * _0023_003DztLDbz5AIMKeP._titleSizeFactor), FontStyle.Bold);
			if (_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(font2, ref _0023_003DztLDbz5AIMKeP._internalTitleFont))
			{
				_0023_003DztLDbz5AIMKeP.dirtyTextures = true;
			}
			font2.Dispose();
		}
		else
		{
			Font defaultFont = System.Windows.Forms.Control.DefaultFont;
			Font font3 = new Font(defaultFont.FontFamily, Convert.ToSingle((double)defaultFont.Size * _0023_003DztLDbz5AIMKeP._titleSizeFactor), FontStyle.Bold);
			if (_0023_003DziZZfZEAkgw4HT9h4XA_003D_003D(font3, ref _0023_003DztLDbz5AIMKeP._internalTitleFont))
			{
				_0023_003DztLDbz5AIMKeP.dirtyTextures = true;
			}
			font3.Dispose();
		}
	}

	private bool _0023_003Dz_0024vAeC8ErBn1_0024u7PBXg_003D_003D()
	{
		return TitleFont != null;
	}

	private void _0023_003DzvIG53MX0Npz5()
	{
		TitleFont = _0023_003DzsUEvb2UyM8Zl();
	}

	private bool _0023_003DzpDSd4ZiVVBxIMNnMC58SjPE_003D()
	{
		return Lighting;
	}

	internal void _0023_003DzUi_NH3uU71f_AaJ5Gg_003D_003D()
	{
		Lighting = false;
	}

	private bool _0023_003DztVh1LwaKVqgXmoCXVw_003D_003D()
	{
		return PositionMode != _0023_003Dz_00245L9XmHWQLb3();
	}

	private void _0023_003DzxSxB51gc07_0024Y()
	{
		PositionMode = _0023_003Dz_00245L9XmHWQLb3();
	}

	internal void _0023_003Dz8WTvZ9I_003D()
	{
		dirtyTextures = true;
	}

	protected internal void Draw(Workspace control, Viewport viewport)
	{
		_0023_003Dz99kJFjE_003D(control, viewport, 1f, 1f, 0, 0);
	}

	internal void _0023_003Dz99kJFjE_003D(Workspace _0023_003DzU0f5_qE_003D, Viewport _0023_003DzYzWi5Yw_003D, float _0023_003DzdoUVo1Fyxkwv, float _0023_003Dz9DzCOOE601Zj, int _0023_003Dz7nXk4nAdrYuD, int _0023_003DzHGcYaz9_t1wE)
	{
		bool flag = true;
		ParentViewport = _0023_003DzYzWi5Yw_003D;
		float num = ParentViewport?._0023_003Dz0TvaYNo_003D._0023_003DztnrgTmT5sBNd().Height ?? UtilityEx.GetScalingLevel().Height;
		_0023_003DzQGFu9f8GtnTq(this);
		_0023_003DzyEl5vhuM_0024afX(this);
		int num2 = _items.Length;
		if (dirtyTextures)
		{
			_0023_003DzL5A6d7aXa6AQ1YLLIQ_003D_003D(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, null, null);
			dirtyTextures = false;
			float num3 = _0023_003DzYzWi5Yw_003D.Size.Height - titleTexture.BitmapSize.Height;
			int width = 0;
			float num4 = 0f;
			if (values.Length != 0)
			{
				float num5 = ((IEnumerable<LegendItem>)Items).Max((Func<LegendItem, int>)_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzSpFNFKtHjF8GqAw7UkK0RIk_003D);
				int num6 = (_alignValuesVerticalMiddle ? 1 : 0);
				float num7 = _0023_003DzAX8okkz2Q9HS(num6);
				int num8 = 0;
				if (!string.IsNullOrEmpty(Title))
				{
					num8 += titleTexture.BitmapSize.Height;
				}
				if (!string.IsNullOrEmpty(Subtitle))
				{
					num8 += subtitleTexture.BitmapSize.Height;
				}
				float num9 = (int)Math.Round((float)_items[num2 - 1].Height * num);
				float num10 = num3 - num9 - (float)num8;
				float num11 = num9;
				float num12 = num10 + num11;
				float num13 = 10f;
				if (_alignValuesVerticalMiddle)
				{
					num12 -= num9 / 2f;
				}
				Size size = Size.Empty;
				for (int num14 = values.Length - 1; num14 >= num6; num14--)
				{
					int num15 = num14;
					if (_alignValuesVerticalMiddle)
					{
						num15--;
					}
					TextureBase textureBase = textTextures[num15];
					size = ((textureBase.BitmapSize.Width <= textureBase.Size.Width) ? textureBase.BitmapSize : textureBase.Size);
					if (num14 > 1)
					{
						num10 -= (float)(_items[num14 - 2].Height + _gap);
					}
					if (num14 > 0)
					{
						num12 -= (float)(_items[num14 - 1].Height + _gap);
					}
				}
				num4 = (float)_0023_003DzYzWi5Yw_003D.Size.Height - num12;
				num4 = (_alignValuesVerticalMiddle ? (num4 - (float)size.Height / 2f) : (num4 + (float)size.Height));
				int val = (int)Math.Round(num7 + num5 + num13 + (float)(flag ? 2 : 3));
				width = Math.Max(titleTexture.BitmapSize.Width, Math.Max(subtitleTexture.BitmapSize.Width, val));
			}
			boundsInViewport.Width = width;
			boundsInViewport.Height = (int)Math.Round(num4);
			_lastUsedScaleFactor = 1f;
		}
		_0023_003DzyB7YPoE_003D(boundsInViewport.Width, boundsInViewport.Height, out var _0023_003Dz8GBMuoM_003D, out var _0023_003DzJU0R6e0_003D);
		boundsInViewport.X = (int)Math.Round(_0023_003Dz8GBMuoM_003D);
		boundsInViewport.Y = (int)Math.Round(_0023_003DzJU0R6e0_003D);
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PushBlendState();
		float num16 = boundsInViewport.Location.X;
		float num17 = boundsInViewport.Location.Y;
		float _0023_003DzWBQC3y1PpX2a = _0023_003DzdoUVo1Fyxkwv / _0023_003Dz9DzCOOE601Zj;
		if (_0023_003DzdoUVo1Fyxkwv != _lastUsedScaleFactor)
		{
			Font font = new Font(TitleFont.FontFamily, TitleFont.Size * _0023_003DzdoUVo1Fyxkwv, TitleFont.Style);
			Font font2 = new Font(TextFont.FontFamily, TextFont.Size * _0023_003DzdoUVo1Fyxkwv, TextFont.Style);
			_0023_003DzL5A6d7aXa6AQ1YLLIQ_003D_003D(_0023_003DzU0f5_qE_003D, _0023_003DzYzWi5Yw_003D, font, font2);
			dirtyTextures = false;
			font.Dispose();
			font2.Dispose();
			_lastUsedScaleFactor = _0023_003DzdoUVo1Fyxkwv;
		}
		int num18 = (int)Math.Floor(_0023_003DzdoUVo1Fyxkwv * num16 - (float)_0023_003Dz7nXk4nAdrYuD);
		int num19 = (int)Math.Floor(_0023_003DzdoUVo1Fyxkwv * num17 - (float)_0023_003DzHGcYaz9_t1wE);
		num16 = num18;
		num17 = num19;
		float num20 = (float)_0023_003DzYzWi5Yw_003D.Size.Height - num17 - (float)titleTexture.BitmapSize.Height;
		Workspace._0023_003DzwCL3lEhabo_0024g(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, titleTexture, (int)Math.Round(num16), (int)Math.Round(num20), ContentAlignment.BottomLeft, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: true, out var _0023_003Dz6g4Y6AMwu8y);
		if (!string.IsNullOrEmpty(Subtitle))
		{
			num20 -= (float)subtitleTexture.BitmapSize.Height;
			Workspace._0023_003DzwCL3lEhabo_0024g(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, subtitleTexture, (int)Math.Round(num16), (int)Math.Round(num20), ContentAlignment.BottomLeft, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: true, out _0023_003Dz6g4Y6AMwu8y);
		}
		if (values.Length != 0)
		{
			float _0023_003DzVxKEcOzjMJUJ = Items.Min((LegendItem _0023_003DzDp118Pw_003D) => _0023_003DzDp118Pw_003D.Width);
			float num21 = ((IEnumerable<LegendItem>)Items).Max((Func<LegendItem, int>)_0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzCWmG9TuFIqpk1gTjgtLetmw_003D);
			int num22 = (_alignValuesVerticalMiddle ? 1 : 0);
			float num23 = _0023_003DzAX8okkz2Q9HS(num22);
			int num24 = 0;
			if (!string.IsNullOrEmpty(Title))
			{
				num24 += titleTexture.BitmapSize.Height;
			}
			if (!string.IsNullOrEmpty(Subtitle))
			{
				num24 += subtitleTexture.BitmapSize.Height;
			}
			float num25 = (int)Math.Round((float)_items[num2 - 1].Height * num);
			float num26 = num20 - num25 * _0023_003DzdoUVo1Fyxkwv - (float)num24;
			float num27 = num25 * _0023_003DzdoUVo1Fyxkwv;
			float num28 = num26 + num27;
			float num29 = 10f * _0023_003DzdoUVo1Fyxkwv;
			if (_alignValuesVerticalMiddle)
			{
				num28 -= num25 / 2f;
			}
			_0023_003DzYpOh3PgzNGuF(out var _0023_003DzqjNpwjk_003D, out var _0023_003Dzsdr_I1A_003D);
			float num30 = num16 + _0023_003Dzsdr_I1A_003D;
			if (flag)
			{
				num30 += num21 * _0023_003DzdoUVo1Fyxkwv + num29;
			}
			_ = Size.Empty;
			for (int num31 = values.Length - 1; num31 >= num22; num31--)
			{
				if (num31 > 0)
				{
					LegendItem legendItem = _items[num31 - 1];
					legendItem._0023_003Dz99kJFjE_003D(_0023_003DzU0f5_qE_003D, 0f, num16 + (flag ? ((num21 - (float)legendItem.Width) * _0023_003DzdoUVo1Fyxkwv) : (num23 + num29)), num26, _0023_003DzdoUVo1Fyxkwv, _0023_003DzWBQC3y1PpX2a, num, _tapered ? (num2 - num31 - 2) : 0, _lighting, _gap, _0023_003DzVxKEcOzjMJUJ);
				}
				int num32 = num31;
				if (_alignValuesVerticalMiddle)
				{
					num32--;
				}
				TextureBase _0023_003Dz_IfKSJY_003D = textTextures[num32];
				Workspace._0023_003DzwCL3lEhabo_0024g(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, _0023_003Dz_IfKSJY_003D, (int)Math.Round(num30), (int)Math.Round(num28), _0023_003DzqjNpwjk_003D, _0023_003DzPuIG8z4Ok7Hn: false, _0023_003DzJQ_0024zQtc_003D: true, out _0023_003Dz6g4Y6AMwu8y);
				if (num31 > 1)
				{
					num26 -= (float)(_items[num31 - 2].Height + _gap) * _0023_003DzdoUVo1Fyxkwv;
				}
				if (num31 > 0)
				{
					num28 -= (float)(_items[num31 - 1].Height + _gap) * _0023_003DzdoUVo1Fyxkwv;
				}
			}
		}
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PopShader();
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.PopBlendState();
	}

	private void _0023_003DzyB7YPoE_003D(int _0023_003Dz7PIPnGI_003D, float _0023_003DzkQAiKLA_003D, out float _0023_003Dz8GBMuoM_003D, out float _0023_003DzJU0R6e0_003D)
	{
		positionType positionMode = PositionMode;
		if ((positionMode == positionType.TopLeft || positionMode == positionType.BottomLeft) ? true : false)
		{
			_0023_003Dz8GBMuoM_003D = 10f;
		}
		else
		{
			_0023_003Dz8GBMuoM_003D = ParentViewport.Size.Width - _0023_003Dz7PIPnGI_003D - 10;
		}
		positionMode = PositionMode;
		if ((uint)(positionMode - 2) <= 1u)
		{
			_0023_003DzJU0R6e0_003D = (float)ParentViewport.Size.Height - _0023_003DzkQAiKLA_003D - 10f;
		}
		else
		{
			_0023_003DzJU0R6e0_003D = 10f;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Legend[] legends = ParentViewport.Legends;
		foreach (Legend legend in legends)
		{
			if (legend == this)
			{
				break;
			}
			if (legend.PositionMode == PositionMode)
			{
				int num5 = legend.GetBounds(ParentViewport).Width + 10;
				positionMode = PositionMode;
				bool flag = ((positionMode == positionType.TopLeft || positionMode == positionType.BottomLeft) ? true : false);
				num3 = ((!flag) ? (num3 - num5) : (num3 + num5));
			}
		}
		if (Math.Abs(num3) > Math.Abs(num))
		{
			num = num3;
		}
		if (Math.Abs(num4) > Math.Abs(num2))
		{
			num2 = num4;
		}
		if (ParentViewport._0023_003DzXldEn8dxMaC2 != null)
		{
			ToolBar[] _0023_003DzXldEn8dxMaC = ParentViewport._0023_003DzXldEn8dxMaC2;
			foreach (ToolBar toolBar in _0023_003DzXldEn8dxMaC)
			{
				if (toolBar.Visible)
				{
					Rectangle bounds = toolBar.GetBounds(ParentViewport);
					int num6 = 0;
					int num7 = 0;
					if ((PositionMode == positionType.TopLeft && toolBar.Position == ToolBar.positionType.HorizontalTopLeft) || (PositionMode == positionType.TopRight && toolBar.Position == ToolBar.positionType.HorizontalTopRight))
					{
						num7 = bounds.Y + bounds.Height;
					}
					else if ((PositionMode == positionType.BottomLeft && toolBar.Position == ToolBar.positionType.HorizontalBottomLeft) || (PositionMode == positionType.BottomRight && toolBar.Position == ToolBar.positionType.HorizontalBottomRight))
					{
						num7 = -(ParentViewport.Size.Height - bounds.Y);
					}
					else if ((PositionMode == positionType.TopLeft && toolBar.Position == ToolBar.positionType.VerticalTopLeft) || (PositionMode == positionType.BottomLeft && toolBar.Position == ToolBar.positionType.VerticalBottomLeft))
					{
						num6 = bounds.X + bounds.Width;
					}
					else if ((PositionMode == positionType.TopRight && toolBar.Position == ToolBar.positionType.VerticalTopRight) || (PositionMode == positionType.BottomRight && toolBar.Position == ToolBar.positionType.VerticalBottomRight))
					{
						num6 = -(ParentViewport.Size.Width - bounds.X);
					}
					if (Math.Abs(num6) > Math.Abs(num))
					{
						num = num6;
					}
					if (Math.Abs(num7) > Math.Abs(num2))
					{
						num2 = num7;
					}
				}
			}
		}
		ViewCubeIcon viewCubeIcon = ParentViewport.ViewCubeIcon;
		if (viewCubeIcon != null && viewCubeIcon.Visible)
		{
			Rectangle bounds2 = ParentViewport.ViewCubeIcon.GetBounds(ParentViewport);
			int num8 = 0;
			if ((PositionMode == positionType.TopLeft && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.TopLeft) || (PositionMode == positionType.TopRight && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.TopRight))
			{
				num8 = bounds2.Y + bounds2.Height;
			}
			else if ((PositionMode == positionType.BottomLeft && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.BottomLeft) || (PositionMode == positionType.BottomRight && ParentViewport.ViewCubeIcon.Position == coordinateSystemPositionType.BottomRight))
			{
				num8 = -(ParentViewport.Size.Height - bounds2.Y);
			}
			if (Math.Abs(num8) > Math.Abs(num2))
			{
				num2 = num8;
			}
		}
		CoordinateSystemIcon coordinateSystemIcon = ParentViewport.CoordinateSystemIcon;
		if (coordinateSystemIcon != null && coordinateSystemIcon.Visible)
		{
			Rectangle bounds3 = ParentViewport.CoordinateSystemIcon.GetBounds(ParentViewport);
			int num9 = 0;
			if ((PositionMode == positionType.TopLeft && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.TopLeft) || (PositionMode == positionType.TopRight && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.TopRight))
			{
				num9 = bounds3.Y + bounds3.Height;
			}
			else if ((PositionMode == positionType.BottomLeft && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.BottomLeft) || (PositionMode == positionType.BottomRight && ParentViewport.CoordinateSystemIcon.Position == coordinateSystemPositionType.BottomRight))
			{
				num9 = -(ParentViewport.Size.Height - bounds3.Y);
			}
			if (Math.Abs(num9) > Math.Abs(num2))
			{
				num2 = num9;
			}
		}
		_0023_003Dz8GBMuoM_003D += num;
		_0023_003DzJU0R6e0_003D += num2;
	}

	private float _0023_003DzAX8okkz2Q9HS(int _0023_003DztMA38ag_003D)
	{
		int num = 0;
		for (int num2 = values.Length - 1; num2 >= _0023_003DztMA38ag_003D; num2--)
		{
			int num3 = num2;
			if (_alignValuesVerticalMiddle)
			{
				num3--;
			}
			TextureBase textureBase = textTextures[num3];
			if (((textureBase.BitmapSize.Width <= textureBase.Size.Width) ? textureBase.BitmapSize : textureBase.Size).Width > num)
			{
				num = textureBase.BitmapSize.Width;
			}
		}
		return num;
	}

	private void _0023_003DzYpOh3PgzNGuF(out ContentAlignment _0023_003DzqjNpwjk_003D, out float _0023_003Dzsdr_I1A_003D)
	{
		_0023_003Dzsdr_I1A_003D = 0f;
		if (AlignValuesRight)
		{
			_0023_003DzqjNpwjk_003D = ContentAlignment.MiddleRight;
			_0023_003Dzsdr_I1A_003D = Math.Min(textTextures[0].BitmapSize.Width, textTextures[0].Size.Width);
			for (int i = 1; i < values.Length; i++)
			{
				float num = Math.Min(textTextures[i].BitmapSize.Width, textTextures[i].Size.Width);
				if (num > _0023_003Dzsdr_I1A_003D)
				{
					_0023_003Dzsdr_I1A_003D = num;
				}
			}
		}
		else
		{
			_0023_003DzqjNpwjk_003D = ContentAlignment.MiddleLeft;
		}
	}

	private void _0023_003DzL5A6d7aXa6AQ1YLLIQ_003D_003D(Workspace _0023_003DzA5OxWwM_003D, Viewport _0023_003DzYzWi5Yw_003D, Font _0023_003Dz4pjcwNJUU1SU, Font _0023_003DzDKqDnmtyvc31)
	{
		_0023_003Dz44F_0024M2ub7UF_0024pv2FXQ_003D_003D();
		Font _0023_003Dz6FupbG0_003D = _0023_003Dz4pjcwNJUU1SU ?? TitleFont;
		Font font = _0023_003DzDKqDnmtyvc31 ?? TextFont;
		Bitmap bitmap = (Lighting ? Workspace._0023_003DzRFGA2zTmmjXj(Title, _0023_003Dz6FupbG0_003D, _titleColor, _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0) : Workspace._0023_003DzRFGA2zTmmjXj(Title, _0023_003Dz6FupbG0_003D, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor(), _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), 0));
		titleTexture = _0023_003DzA5OxWwM_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
		bitmap = (Lighting ? Workspace._0023_003DzRFGA2zTmmjXj(Subtitle, font, _textColor, _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0) : Workspace._0023_003DzRFGA2zTmmjXj(Subtitle, font, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor(), _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), 0));
		subtitleTexture = _0023_003DzA5OxWwM_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
		bitmap.Dispose();
		textTextures = _0023_003Dz93_0024V7c2nNdpJnJ139w_003D_003D(_0023_003DzA5OxWwM_003D, _0023_003DzYzWi5Yw_003D, font);
	}

	private TextureBase[] _0023_003Dz93_0024V7c2nNdpJnJ139w_003D_003D(Workspace _0023_003DzA5OxWwM_003D, Viewport _0023_003DzYzWi5Yw_003D, Font _0023_003Dz2IodkSuY0ZJ4)
	{
		TextureBase[] array = new TextureBase[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			Bitmap bitmap = (Lighting ? Workspace._0023_003DzRFGA2zTmmjXj(GetStringValue(i), _0023_003Dz2IodkSuY0ZJ4, _textColor, _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: false, default(Color), 0) : Workspace._0023_003DzRFGA2zTmmjXj(GetStringValue(i), _0023_003Dz2IodkSuY0ZJ4, _0023_003DzYzWi5Yw_003D.Background.GetContrastColor(), _textBackgroundColor, _0023_003DzA5OxWwM_003D._0023_003DzZUohT3Y_003D, RotateFlipType.Rotate180FlipX, _0023_003DzlA4vqb43pzit8w_0024Q4A_003D_003D: true, _0023_003DzPtJa_0024HEmQfD_YqtyuA_003D_003D: true, _0023_003DzYzWi5Yw_003D.Background.GetContrastColorInverted(), 0));
			TextureBase textureBase = _0023_003DzA5OxWwM_003D._0023_003DzmNZD0Zs_003D.CreateTexture2D(bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: true, enlargeIfSizeNotSupported: true);
			bitmap.Dispose();
			array[i] = textureBase;
		}
		return array;
	}

	private void _0023_003Dz44F_0024M2ub7UF_0024pv2FXQ_003D_003D()
	{
		if (titleTexture != null)
		{
			titleTexture.Dispose();
			titleTexture = null;
		}
		if (subtitleTexture != null)
		{
			subtitleTexture.Dispose();
			subtitleTexture = null;
		}
		if (textTextures != null)
		{
			for (int i = 0; i < textTextures.Length; i++)
			{
				if (textTextures[i] != null)
				{
					textTextures[i].Dispose();
					textTextures[i] = null;
				}
			}
		}
		dirtyTextures = true;
	}

	internal void _0023_003DzPY_0024ulDyKjEOA()
	{
		_0023_003Dz44F_0024M2ub7UF_0024pv2FXQ_003D_003D();
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_internalTextFont != null)
		{
			_internalTextFont.Dispose();
			_internalTextFont = null;
		}
		if (_internalTitleFont != null)
		{
			_internalTitleFont.Dispose();
			_internalTitleFont = null;
		}
		_0023_003DzPY_0024ulDyKjEOA();
	}

	public int IndexAt(double numValue)
	{
		int num = _items.Length;
		int value = (int)((double)(num - 1) * (numValue - Min) / Range.Length);
		Utility.LimitRange(0, ref value, num - 1);
		return value;
	}

	public LegendItem ItemAt(double numValue)
	{
		return _items[IndexAt(numValue)];
	}

	public Color ColorAt(double numValue)
	{
		return ItemAt(numValue).Color;
	}

	public double Normalize(double numValue)
	{
		return Utility.Normalize(numValue, Range);
	}

	public static Color[] BuildGradient(int hueSteps = 9)
	{
		List<Color> list = new List<Color>();
		for (int i = 0; i < hueSteps; i++)
		{
			list.Add(RenderContextUtility.ConvertColor(Color.FromArgb(0, (int)(255.0 * (double)i / (double)(hueSteps - 1)), 255)));
		}
		for (int j = 1; j < hueSteps; j++)
		{
			list.Add(RenderContextUtility.ConvertColor(Color.FromArgb(0, 255, (int)(255.0 - 255.0 * ((double)j / ((double)hueSteps - 1.0))))));
		}
		for (int k = 1; k < hueSteps; k++)
		{
			list.Add(RenderContextUtility.ConvertColor(Color.FromArgb((int)(255.0 * (double)k / (double)(hueSteps - 1)), 255, 0)));
		}
		for (int l = 1; l < hueSteps; l++)
		{
			list.Add(RenderContextUtility.ConvertColor(Color.FromArgb(255, (int)(255.0 - 255.0 * ((double)l / ((double)hueSteps - 1.0))), 0)));
		}
		return list.ToArray();
	}

	internal bool _0023_003Dz4XAvJ5aCRLKs(Legend _0023_003DzAbAO3f4_003D)
	{
		if (Min == _0023_003DzAbAO3f4_003D.Min && Max == _0023_003DzAbAO3f4_003D.Max && !(Title != _0023_003DzAbAO3f4_003D.Title) && !(Subtitle != _0023_003DzAbAO3f4_003D.Subtitle) && Slave == _0023_003DzAbAO3f4_003D.Slave && Visible == _0023_003DzAbAO3f4_003D.Visible && AlignValuesRight == _0023_003DzAbAO3f4_003D.AlignValuesRight && !(FormatString != _0023_003DzAbAO3f4_003D.FormatString) && !(TextBackgroundColor != _0023_003DzAbAO3f4_003D.TextBackgroundColor) && !(TitleColor != _0023_003DzAbAO3f4_003D.TitleColor) && !(TextColor != _0023_003DzAbAO3f4_003D.TextColor) && TitleFont.Equals(_0023_003DzAbAO3f4_003D.TitleFont) && TextFont.Equals(_0023_003DzAbAO3f4_003D.TextFont) && _0023_003DzpaIKcm5gz1Fx(Items, _0023_003DzAbAO3f4_003D.Items) && AlignValuesVerticalMiddle == _0023_003DzAbAO3f4_003D.AlignValuesVerticalMiddle && Lighting == _0023_003DzAbAO3f4_003D.Lighting && Tapered == _0023_003DzAbAO3f4_003D.Tapered && Gap == _0023_003DzAbAO3f4_003D.Gap)
		{
			return PositionMode != _0023_003DzAbAO3f4_003D.PositionMode;
		}
		return true;
	}

	public override Rectangle GetBounds(Viewport viewport)
	{
		Rectangle result = boundsInViewport;
		result.Location = new Point(result.X + viewport.Location.X, result.Y + viewport.Location.Y);
		return result;
	}

	protected override void DrawForBitmap(object drawSceneParams)
	{
		DrawSceneParams drawSceneParams2 = (DrawSceneParams)drawSceneParams;
		RenderContextBase renderContext = drawSceneParams2.RenderContext;
		Workspace workspace = (Workspace)drawSceneParams2.Workspace;
		Viewport viewport = (Viewport)drawSceneParams2.Viewport;
		renderContext.ClearColor(workspace._0023_003DzU7yFFKcRyseX());
		renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
		renderContext.FrontFaceCW = false;
		renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_NoPolygonOffset);
		viewport._0023_003Dz191ozMVp28cu(renderContext, workspace._0023_003DzNwtRJ3cLTrAy(), drawSceneParams2.ZoomRect, _0023_003DzPHqp5dQ_003D: false, 0f, workspace._0023_003DzU7yFFKcRyseX(), _0023_003DzIHwNrERoZxEh: false);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		renderContext.PushBlendState();
		renderContext.SetState(blendStateType.Blend);
		_0023_003Dz99kJFjE_003D(workspace, viewport, 1f, 1f, 0, 0);
		renderContext.PopBlendState();
	}

	public override void Update(IUserInterfaceElement another)
	{
		Legend legend = (Legend)another;
		_0023_003DzshPEPAc_003D(legend.Min, legend.Max, legend._title, legend._subTitle, legend.Slave, legend.Visible, legend.AlignValuesRight, legend.FormatString, legend._textBackgroundColor, legend._titleColor, legend._textColor, legend.TitleFont, legend.TextFont, legend.Items, legend._lighting, legend.AlignValuesVerticalMiddle, legend.Tapered, legend.Gap, legend.PositionMode);
	}

	public virtual object Clone()
	{
		return new Legend(this)
		{
			_userTextFont = _userTextFont,
			_userTitleFont = _userTitleFont
		};
	}
}
