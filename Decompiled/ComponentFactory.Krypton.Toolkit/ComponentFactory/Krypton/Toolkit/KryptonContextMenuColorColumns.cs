using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonContextMenuColorColumns), "ToolboxBitmaps.KryptonContextMenuColorColumns.bmp")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
[DefaultProperty("ColorScheme")]
[DefaultEvent("SelectedColorChanged")]
public class KryptonContextMenuColorColumns : KryptonContextMenuItemBase
{
	private static readonly Color[][] _noneScheme = new Color[0][];

	private static readonly Color[][] _mono2Scheme = new Color[2][]
	{
		new Color[1] { Color.White },
		new Color[1] { Color.Black }
	};

	private static readonly Color[][] _mono8Scheme = new Color[8][]
	{
		new Color[1] { Color.White },
		new Color[1] { Color.Silver },
		new Color[1] { Color.FromArgb(160, 160, 160) },
		new Color[1] { Color.Gray },
		new Color[1] { Color.FromArgb(96, 96, 96) },
		new Color[1] { Color.FromArgb(64, 64, 64) },
		new Color[1] { Color.FromArgb(32, 32, 32) },
		new Color[1] { Color.Black }
	};

	private static readonly Color[][] _basic16Scheme = new Color[8][]
	{
		new Color[2]
		{
			Color.White,
			Color.Black
		},
		new Color[2]
		{
			Color.Silver,
			Color.Gray
		},
		new Color[2]
		{
			Color.Red,
			Color.Maroon
		},
		new Color[2]
		{
			Color.Yellow,
			Color.Olive
		},
		new Color[2]
		{
			Color.Lime,
			Color.Green
		},
		new Color[2]
		{
			Color.Cyan,
			Color.Teal
		},
		new Color[2]
		{
			Color.Blue,
			Color.Navy
		},
		new Color[2]
		{
			Color.Fuchsia,
			Color.Purple
		}
	};

	private static readonly Color[][] _officeStandardScheme = new Color[10][]
	{
		new Color[1] { Color.FromArgb(192, 0, 0) },
		new Color[1] { Color.Red },
		new Color[1] { Color.FromArgb(255, 192, 0) },
		new Color[1] { Color.Yellow },
		new Color[1] { Color.FromArgb(146, 208, 80) },
		new Color[1] { Color.FromArgb(0, 176, 80) },
		new Color[1] { Color.FromArgb(0, 176, 240) },
		new Color[1] { Color.FromArgb(0, 112, 192) },
		new Color[1] { Color.FromArgb(0, 32, 96) },
		new Color[1] { Color.FromArgb(112, 48, 160) }
	};

	private static readonly Color[][] _officeThemeScheme = new Color[10][]
	{
		new Color[6]
		{
			Color.White,
			Color.FromArgb(242, 242, 242),
			Color.FromArgb(216, 216, 216),
			Color.FromArgb(191, 191, 191),
			Color.FromArgb(165, 165, 165),
			Color.Gray
		},
		new Color[6]
		{
			Color.Black,
			Color.FromArgb(127, 127, 127),
			Color.FromArgb(89, 89, 89),
			Color.FromArgb(63, 63, 63),
			Color.FromArgb(38, 38, 38),
			Color.FromArgb(12, 12, 12)
		},
		new Color[6]
		{
			Color.FromArgb(238, 236, 225),
			Color.FromArgb(221, 217, 195),
			Color.FromArgb(196, 189, 151),
			Color.FromArgb(147, 137, 83),
			Color.FromArgb(73, 68, 41),
			Color.FromArgb(29, 27, 16)
		},
		new Color[6]
		{
			Color.FromArgb(31, 73, 125),
			Color.FromArgb(198, 217, 240),
			Color.FromArgb(141, 179, 226),
			Color.FromArgb(84, 141, 212),
			Color.FromArgb(23, 54, 93),
			Color.FromArgb(15, 36, 62)
		},
		new Color[6]
		{
			Color.FromArgb(79, 129, 189),
			Color.FromArgb(219, 229, 241),
			Color.FromArgb(184, 204, 228),
			Color.FromArgb(149, 179, 215),
			Color.FromArgb(54, 96, 146),
			Color.FromArgb(36, 64, 97)
		},
		new Color[6]
		{
			Color.FromArgb(192, 80, 77),
			Color.FromArgb(242, 220, 219),
			Color.FromArgb(229, 185, 183),
			Color.FromArgb(217, 150, 148),
			Color.FromArgb(149, 55, 52),
			Color.FromArgb(99, 36, 35)
		},
		new Color[6]
		{
			Color.FromArgb(155, 187, 89),
			Color.FromArgb(235, 241, 221),
			Color.FromArgb(215, 227, 188),
			Color.FromArgb(195, 214, 155),
			Color.FromArgb(118, 146, 60),
			Color.FromArgb(79, 97, 40)
		},
		new Color[6]
		{
			Color.FromArgb(128, 100, 162),
			Color.FromArgb(229, 224, 236),
			Color.FromArgb(204, 193, 217),
			Color.FromArgb(178, 162, 199),
			Color.FromArgb(95, 73, 122),
			Color.FromArgb(63, 49, 81)
		},
		new Color[6]
		{
			Color.FromArgb(75, 172, 198),
			Color.FromArgb(219, 238, 243),
			Color.FromArgb(183, 221, 232),
			Color.FromArgb(146, 205, 220),
			Color.FromArgb(49, 133, 155),
			Color.FromArgb(32, 88, 103)
		},
		new Color[6]
		{
			Color.FromArgb(247, 150, 70),
			Color.FromArgb(253, 234, 218),
			Color.FromArgb(251, 213, 181),
			Color.FromArgb(250, 192, 143),
			Color.FromArgb(227, 108, 9),
			Color.FromArgb(151, 72, 6)
		}
	};

	private ColorScheme _colorScheme;

	private Color[][] _colors;

	private Color _selectedColor;

	private Size _blockSize;

	private bool _autoClose;

	private bool _groupNonFirstRows;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int ItemChildCount => 0;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override KryptonContextMenuItemBase this[int index] => null;

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Indicates if clicking a color entry automatically closes the context menu.")]
	[DefaultValue(true)]
	public bool AutoClose
	{
		get
		{
			return _autoClose;
		}
		set
		{
			if (_autoClose != value)
			{
				_autoClose = value;
				OnPropertyChanged(new PropertyChangedEventArgs("AutoClose"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Defines the set of colors to use for display.")]
	[DefaultValue(typeof(ColorScheme), "OfficeThemes")]
	public ColorScheme ColorScheme
	{
		get
		{
			return _colorScheme;
		}
		set
		{
			if (_colorScheme != value)
			{
				SetColorScheme(value);
				OnPropertyChanged(new PropertyChangedEventArgs("ColorScheme"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Color that has been selected by the user.")]
	[DefaultValue(typeof(Color), "")]
	public Color SelectedColor
	{
		get
		{
			return _selectedColor;
		}
		set
		{
			if (_selectedColor != value)
			{
				_selectedColor = value;
				OnSelectedColorChanged(new ColorEventArgs(_selectedColor));
				OnPropertyChanged(new PropertyChangedEventArgs("SelectedColor"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Size of each color block.")]
	[DefaultValue(typeof(Size), "13,13")]
	public Size BlockSize
	{
		get
		{
			return _blockSize;
		}
		set
		{
			if (_blockSize != value)
			{
				_blockSize = value;
				OnPropertyChanged(new PropertyChangedEventArgs("BlockSize"));
			}
		}
	}

	[KryptonPersist]
	[Category("Appearance")]
	[Description("Should all but the first row be grouped together.")]
	[DefaultValue(true)]
	public bool GroupNonFirstRows
	{
		get
		{
			return _groupNonFirstRows;
		}
		set
		{
			if (_groupNonFirstRows != value)
			{
				_groupNonFirstRows = value;
				OnPropertyChanged(new PropertyChangedEventArgs("GroupNonFirstRows"));
			}
		}
	}

	internal Color[][] Colors => _colors;

	[Category("Action")]
	[Description("Occurs when the SelectedColor property changes value.")]
	public event EventHandler<ColorEventArgs> SelectedColorChanged;

	[Category("Action")]
	[Description("Occurs when user is tracking over a color.")]
	public event EventHandler<ColorEventArgs> TrackingColor;

	public KryptonContextMenuColorColumns()
		: this(ColorScheme.OfficeThemes)
	{
	}

	public KryptonContextMenuColorColumns(ColorScheme scheme)
	{
		_autoClose = true;
		_selectedColor = Color.Empty;
		_groupNonFirstRows = true;
		_blockSize = new Size(13, 13);
		SetColorScheme(scheme);
	}

	public override string ToString()
	{
		return "(Color Columns)";
	}

	public override bool ProcessShortcut(Keys keyData)
	{
		return false;
	}

	public override ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn)
	{
		return new ViewDrawMenuColorColumns(provider, this);
	}

	public void SetCustomColors(Color[][] colors)
	{
		if (colors == null || colors.Length == 0)
		{
			colors = _noneScheme;
		}
		int num = -1;
		for (int i = 0; i < colors.Length; i++)
		{
			if (colors[i] == null)
			{
				throw new ArgumentOutOfRangeException("Child array cannot be null.");
			}
			if (i == 0)
			{
				num = colors[i].Length;
			}
			else if (colors[i].Length != num)
			{
				throw new ArgumentOutOfRangeException("Each child color array must be the same length.");
			}
		}
		_colors = colors;
	}

	public bool ContainsColor(Color color)
	{
		if (_colors != null)
		{
			Color[][] colors = _colors;
			foreach (Color[] array in colors)
			{
				Color[] array2 = array;
				foreach (Color color2 in array2)
				{
					if (color.Equals(color2))
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	protected virtual void OnSelectedColorChanged(ColorEventArgs e)
	{
		if (this.SelectedColorChanged != null)
		{
			this.SelectedColorChanged(this, e);
		}
	}

	protected internal virtual void OnTrackingColor(ColorEventArgs e)
	{
		if (this.TrackingColor != null)
		{
			this.TrackingColor(this, e);
		}
	}

	private void SetColorScheme(ColorScheme scheme)
	{
		_colorScheme = scheme;
		switch (scheme)
		{
		case ColorScheme.None:
			_colors = _noneScheme;
			break;
		case ColorScheme.Mono2:
			_colors = _mono2Scheme;
			break;
		case ColorScheme.Mono8:
			_colors = _mono8Scheme;
			break;
		case ColorScheme.Basic16:
			_colors = _basic16Scheme;
			break;
		case ColorScheme.OfficeStandard:
			_colors = _officeStandardScheme;
			break;
		case ColorScheme.OfficeThemes:
			_colors = _officeThemeScheme;
			break;
		}
	}
}
