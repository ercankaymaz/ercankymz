using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentText : Storage
{
	private class InternalStorage
	{
		public Font ContentTextFont;

		public PaletteTextHint ContentTextHint;

		public PaletteTextTrim ContentTextTrim;

		public PaletteTextHotkeyPrefix ContentTextPrefix;

		public PaletteRelativeAlign ContentTextH;

		public PaletteRelativeAlign ContentTextV;

		public PaletteRelativeAlign ContentTextMultiLineH;

		public InheritBool ContentTextMultiLine;

		public Color ContentTextColor1;

		public Color ContentTextColor2;

		public PaletteColorStyle ContentTextColorStyle;

		public PaletteRectangleAlign ContentTextColorAlign;

		public float ContentTextColorAngle;

		public Image ContentTextImage;

		public PaletteImageStyle ContentTextImageStyle;

		public PaletteRectangleAlign ContentTextImageAlign;

		public bool IsDefault => ContentTextFont == null && ContentTextHint == PaletteTextHint.Inherit && ContentTextTrim == PaletteTextTrim.Inherit && ContentTextPrefix == PaletteTextHotkeyPrefix.Inherit && ContentTextH == PaletteRelativeAlign.Inherit && ContentTextV == PaletteRelativeAlign.Inherit && ContentTextMultiLineH == PaletteRelativeAlign.Inherit && ContentTextMultiLine == InheritBool.Inherit && ContentTextColor1 == Color.Empty && ContentTextColor2 == Color.Empty && ContentTextColorStyle == PaletteColorStyle.Inherit && ContentTextColorAlign == PaletteRectangleAlign.Inherit && ContentTextColorAngle == -1f && ContentTextImage == null && ContentTextImageStyle == PaletteImageStyle.Inherit && ContentTextImageAlign == PaletteRectangleAlign.Inherit;

		public InternalStorage()
		{
			ContentTextHint = PaletteTextHint.Inherit;
			ContentTextTrim = PaletteTextTrim.Inherit;
			ContentTextPrefix = PaletteTextHotkeyPrefix.Inherit;
			ContentTextH = PaletteRelativeAlign.Inherit;
			ContentTextV = PaletteRelativeAlign.Inherit;
			ContentTextMultiLineH = PaletteRelativeAlign.Inherit;
			ContentTextMultiLine = InheritBool.Inherit;
			ContentTextColor1 = Color.Empty;
			ContentTextColor2 = Color.Empty;
			ContentTextColorStyle = PaletteColorStyle.Inherit;
			ContentTextColorAlign = PaletteRectangleAlign.Inherit;
			ContentTextColorAngle = -1f;
			ContentTextImageStyle = PaletteImageStyle.Inherit;
			ContentTextImageAlign = PaletteRectangleAlign.Inherit;
		}
	}

	private InternalStorage _storage;

	[Browsable(false)]
	public override bool IsDefault => _storage == null || _storage.IsDefault;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for drawing the content text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Font Font
	{
		get
		{
			if (_storage == null)
			{
				return null;
			}
			return _storage.ContentTextFont;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextFont != value)
				{
					_storage.ContentTextFont = value;
					OnPropertyChanged("Font");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != null)
			{
				_storage = new InternalStorage();
				_storage.ContentTextFont = value;
				OnPropertyChanged("Font");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text rendering hint for the content text.")]
	[DefaultValue(typeof(PaletteTextHint), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextHint Hint
	{
		get
		{
			if (_storage == null)
			{
				return PaletteTextHint.Inherit;
			}
			return _storage.ContentTextHint;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextHint != value)
				{
					_storage.ContentTextHint = value;
					OnPropertyChanged("Hint");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteTextHint.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextHint = value;
				OnPropertyChanged("Hint");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Text trimming style for the content text.")]
	[DefaultValue(typeof(PaletteTextTrim), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextTrim Trim
	{
		get
		{
			if (_storage == null)
			{
				return PaletteTextTrim.Inherit;
			}
			return _storage.ContentTextTrim;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextTrim != value)
				{
					_storage.ContentTextTrim = value;
					OnPropertyChanged("Trim");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteTextTrim.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextTrim = value;
				OnPropertyChanged("Trim");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("How to draw prefix characters for the content text.")]
	[DefaultValue(typeof(PaletteTextHotkeyPrefix), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteTextHotkeyPrefix Prefix
	{
		get
		{
			if (_storage == null)
			{
				return PaletteTextHotkeyPrefix.Inherit;
			}
			return _storage.ContentTextPrefix;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextPrefix != value)
				{
					_storage.ContentTextPrefix = value;
					OnPropertyChanged("Prefix");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteTextHotkeyPrefix.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextPrefix = value;
				OnPropertyChanged("Prefix");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative horizontal alignment of content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign TextH
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRelativeAlign.Inherit;
			}
			return _storage.ContentTextH;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextH != value)
				{
					_storage.ContentTextH = value;
					OnPropertyChanged("TextH");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteRelativeAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextH = value;
				OnPropertyChanged("TextH");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative vertical alignment of content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign TextV
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRelativeAlign.Inherit;
			}
			return _storage.ContentTextV;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextV != value)
				{
					_storage.ContentTextV = value;
					OnPropertyChanged("TextV");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteRelativeAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextV = value;
				OnPropertyChanged("TextV");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative horizontal alignment of multiline content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign MultiLineH
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRelativeAlign.Inherit;
			}
			return _storage.ContentTextMultiLineH;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextMultiLineH != value)
				{
					_storage.ContentTextMultiLineH = value;
					OnPropertyChanged("MultiLineH");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteRelativeAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextMultiLineH = value;
				OnPropertyChanged("MultiLineH");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Flag indicating if multiline text is allowed..")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual InheritBool MultiLine
	{
		get
		{
			if (_storage == null)
			{
				return InheritBool.Inherit;
			}
			return _storage.ContentTextMultiLine;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextMultiLine != value)
				{
					_storage.ContentTextMultiLine = value;
					OnPropertyChanged("MultiLine");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != InheritBool.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextMultiLine = value;
				OnPropertyChanged("MultiLine");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Main color for the text.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color1
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.ContentTextColor1;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextColor1 != value)
				{
					_storage.ContentTextColor1 = value;
					OnPropertyChanged("Color1");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.ContentTextColor1 = value;
				OnPropertyChanged("Color1");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Secondary color for the text.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Color Color2
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.ContentTextColor2;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextColor2 != value)
				{
					_storage.ContentTextColor2 = value;
					OnPropertyChanged("Color2");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.ContentTextColor2 = value;
				OnPropertyChanged("Color2");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color drawing style for the text.")]
	[DefaultValue(typeof(PaletteColorStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteColorStyle ColorStyle
	{
		get
		{
			if (_storage == null)
			{
				return PaletteColorStyle.Inherit;
			}
			return _storage.ContentTextColorStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextColorStyle != value)
				{
					_storage.ContentTextColorStyle = value;
					OnPropertyChanged("ColorStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteColorStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextColorStyle = value;
				OnPropertyChanged("ColorStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color alignment style for the text.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRectangleAlign ColorAlign
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRectangleAlign.Inherit;
			}
			return _storage.ContentTextColorAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextColorAlign != value)
				{
					_storage.ContentTextColorAlign = value;
					OnPropertyChanged("ColorAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextColorAlign = value;
				OnPropertyChanged("ColorAlign");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color angle for the text.")]
	[DefaultValue(-1f)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual float ColorAngle
	{
		get
		{
			if (_storage == null)
			{
				return -1f;
			}
			return _storage.ContentTextColorAngle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextColorAngle != value)
				{
					_storage.ContentTextColorAngle = value;
					OnPropertyChanged("ColorAngle");
					PerformNeedPaint();
				}
			}
			else if (value != -1f)
			{
				_storage = new InternalStorage();
				_storage.ContentTextColorAngle = value;
				OnPropertyChanged("ColorAngle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image for the text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Image Image
	{
		get
		{
			if (_storage == null)
			{
				return null;
			}
			return _storage.ContentTextImage;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextImage != value)
				{
					_storage.ContentTextImage = value;
					OnPropertyChanged("Image");
					PerformNeedPaint();
				}
			}
			else if (value != null)
			{
				_storage = new InternalStorage();
				_storage.ContentTextImage = value;
				OnPropertyChanged("Image");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image style for the text.")]
	[DefaultValue(typeof(PaletteImageStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteImageStyle ImageStyle
	{
		get
		{
			if (_storage == null)
			{
				return PaletteImageStyle.Inherit;
			}
			return _storage.ContentTextImageStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextImageStyle != value)
				{
					_storage.ContentTextImageStyle = value;
					OnPropertyChanged("ImageStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteImageStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextImageStyle = value;
				OnPropertyChanged("ImageStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Image alignment style for the text.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRectangleAlign ImageAlign
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRectangleAlign.Inherit;
			}
			return _storage.ContentTextImageAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentTextImageAlign != value)
				{
					_storage.ContentTextImageAlign = value;
					OnPropertyChanged("ImageAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentTextImageAlign = value;
				OnPropertyChanged("ImageAlign");
				PerformNeedPaint();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event PropertyChangedEventHandler PropertyChanged;

	public PaletteContentText(NeedPaintHandler needPaint)
	{
		NeedPaint = needPaint;
	}

	protected virtual void OnPropertyChanged(string property)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
