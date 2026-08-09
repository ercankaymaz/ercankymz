using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBack : Storage, IPaletteBack
{
	private class InternalStorage
	{
		public InheritBool BackDraw;

		public PaletteGraphicsHint BackGraphicsHint;

		public Color BackColor1;

		public Color BackColor2;

		public PaletteColorStyle BackColorStyle;

		public PaletteRectangleAlign BackColorAlign;

		public float BackColorAngle;

		public Image BackImage;

		public PaletteImageStyle BackImageStyle;

		public PaletteRectangleAlign BackImageAlign;

		public bool IsDefault => BackDraw == InheritBool.Inherit && BackGraphicsHint == PaletteGraphicsHint.Inherit && BackColor1 == Color.Empty && BackColor2 == Color.Empty && BackColorStyle == PaletteColorStyle.Inherit && BackColorAlign == PaletteRectangleAlign.Inherit && BackColorAngle == -1f && BackImage == null && BackImageStyle == PaletteImageStyle.Inherit && BackImageAlign == PaletteRectangleAlign.Inherit;

		public InternalStorage()
		{
			BackDraw = InheritBool.Inherit;
			BackGraphicsHint = PaletteGraphicsHint.Inherit;
			BackColor1 = Color.Empty;
			BackColor2 = Color.Empty;
			BackColorStyle = PaletteColorStyle.Inherit;
			BackColorAlign = PaletteRectangleAlign.Inherit;
			BackColorAngle = -1f;
			BackImageStyle = PaletteImageStyle.Inherit;
			BackImageAlign = PaletteRectangleAlign.Inherit;
		}
	}

	private IPaletteBack _inherit;

	private InternalStorage _storage;

	[Browsable(false)]
	public override bool IsDefault => _storage == null || _storage.IsDefault;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should background be drawn.")]
	[DefaultValue(typeof(InheritBool), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public InheritBool Draw
	{
		get
		{
			if (_storage == null)
			{
				return InheritBool.Inherit;
			}
			return _storage.BackDraw;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackDraw != value)
				{
					_storage.BackDraw = value;
					OnPropertyChanged("Draw");
					PerformNeedPaint();
				}
			}
			else if (value != InheritBool.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackDraw = value;
				OnPropertyChanged("Draw");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Hint for drawing graphics.")]
	[DefaultValue(typeof(PaletteGraphicsHint), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteGraphicsHint GraphicsHint
	{
		get
		{
			if (_storage == null)
			{
				return PaletteGraphicsHint.Inherit;
			}
			return _storage.BackGraphicsHint;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackGraphicsHint != value)
				{
					_storage.BackGraphicsHint = value;
					OnPropertyChanged("GraphicsHint");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteGraphicsHint.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackGraphicsHint = value;
				OnPropertyChanged("GraphicsHint");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Main background color.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color1
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.BackColor1;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackColor1 != value)
				{
					_storage.BackColor1 = value;
					OnPropertyChanged("Color1");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.BackColor1 = value;
				OnPropertyChanged("Color1");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Secondary background color.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color Color2
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.BackColor2;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackColor2 != value)
				{
					_storage.BackColor2 = value;
					OnPropertyChanged("Color2");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.BackColor2 = value;
				OnPropertyChanged("Color2");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background color drawing style.")]
	[DefaultValue(typeof(PaletteColorStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteColorStyle ColorStyle
	{
		get
		{
			if (_storage == null)
			{
				return PaletteColorStyle.Inherit;
			}
			return _storage.BackColorStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackColorStyle != value)
				{
					_storage.BackColorStyle = value;
					OnPropertyChanged("ColorStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteColorStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackColorStyle = value;
				OnPropertyChanged("ColorStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background color alignment style.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRectangleAlign ColorAlign
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRectangleAlign.Inherit;
			}
			return _storage.BackColorAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackColorAlign != value)
				{
					_storage.BackColorAlign = value;
					OnPropertyChanged("ColorAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackColorAlign = value;
				OnPropertyChanged("ColorAlign");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background color angle.")]
	[DefaultValue(-1f)]
	[RefreshProperties(RefreshProperties.All)]
	public float ColorAngle
	{
		get
		{
			if (_storage == null)
			{
				return -1f;
			}
			return _storage.BackColorAngle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackColorAngle != value)
				{
					_storage.BackColorAngle = value;
					OnPropertyChanged("ColorAngle");
					PerformNeedPaint();
				}
			}
			else if (value != -1f)
			{
				_storage = new InternalStorage();
				_storage.BackColorAngle = value;
				OnPropertyChanged("ColorAngle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background image.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public Image Image
	{
		get
		{
			if (_storage == null)
			{
				return null;
			}
			return _storage.BackImage;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackImage != value)
				{
					_storage.BackImage = value;
					OnPropertyChanged("Image");
					PerformNeedPaint();
				}
			}
			else if (value != null)
			{
				_storage = new InternalStorage();
				_storage.BackImage = value;
				OnPropertyChanged("Image");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background image style.")]
	[DefaultValue(typeof(PaletteImageStyle), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteImageStyle ImageStyle
	{
		get
		{
			if (_storage == null)
			{
				return PaletteImageStyle.Inherit;
			}
			return _storage.BackImageStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackImageStyle != value)
				{
					_storage.BackImageStyle = value;
					OnPropertyChanged("ImageStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteImageStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackImageStyle = value;
				OnPropertyChanged("ImageStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Background image alignment style.")]
	[DefaultValue(typeof(PaletteRectangleAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRectangleAlign ImageAlign
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRectangleAlign.Inherit;
			}
			return _storage.BackImageAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BackImageAlign != value)
				{
					_storage.BackImageAlign = value;
					OnPropertyChanged("ImageAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BackImageAlign = value;
				OnPropertyChanged("ImageAlign");
				PerformNeedPaint();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event PropertyChangedEventHandler PropertyChanged;

	public PaletteBack(IPaletteBack inherit, NeedPaintHandler needPaint)
	{
		_inherit = inherit;
		NeedPaint = needPaint;
	}

	public void SetInherit(IPaletteBack inherit)
	{
		_inherit = inherit;
	}

	public void PopulateFromBase(PaletteState state)
	{
		Draw = GetBackDraw(state);
		GraphicsHint = GetBackGraphicsHint(state);
		Color1 = GetBackColor1(state);
		Color2 = GetBackColor2(state);
		ColorStyle = GetBackColorStyle(state);
		ColorAlign = GetBackColorAlign(state);
		ColorAngle = GetBackColorAngle(state);
		Image = GetBackImage(state);
		ImageStyle = GetBackImageStyle(state);
		ImageAlign = GetBackImageAlign(state);
	}

	public InheritBool GetBackDraw(PaletteState state)
	{
		if (Draw != InheritBool.Inherit)
		{
			return Draw;
		}
		return _inherit.GetBackDraw(state);
	}

	public PaletteGraphicsHint GetBackGraphicsHint(PaletteState state)
	{
		if (GraphicsHint != PaletteGraphicsHint.Inherit)
		{
			return GraphicsHint;
		}
		return _inherit.GetBackGraphicsHint(state);
	}

	public Color GetBackColor1(PaletteState state)
	{
		if (Color1 != Color.Empty)
		{
			return Color1;
		}
		return _inherit.GetBackColor1(state);
	}

	public Color GetBackColor2(PaletteState state)
	{
		if (Color2 != Color.Empty)
		{
			return Color2;
		}
		return _inherit.GetBackColor2(state);
	}

	public PaletteColorStyle GetBackColorStyle(PaletteState state)
	{
		if (ColorStyle != PaletteColorStyle.Inherit)
		{
			return ColorStyle;
		}
		return _inherit.GetBackColorStyle(state);
	}

	public PaletteRectangleAlign GetBackColorAlign(PaletteState state)
	{
		if (ColorAlign != PaletteRectangleAlign.Inherit)
		{
			return ColorAlign;
		}
		return _inherit.GetBackColorAlign(state);
	}

	public float GetBackColorAngle(PaletteState state)
	{
		if (ColorAngle != -1f)
		{
			return ColorAngle;
		}
		return _inherit.GetBackColorAngle(state);
	}

	public Image GetBackImage(PaletteState state)
	{
		if (Image != null)
		{
			return Image;
		}
		return _inherit.GetBackImage(state);
	}

	public PaletteImageStyle GetBackImageStyle(PaletteState state)
	{
		if (ImageStyle != PaletteImageStyle.Inherit)
		{
			return ImageStyle;
		}
		return _inherit.GetBackImageStyle(state);
	}

	public PaletteRectangleAlign GetBackImageAlign(PaletteState state)
	{
		if (ImageAlign != PaletteRectangleAlign.Inherit)
		{
			return ImageAlign;
		}
		return _inherit.GetBackImageAlign(state);
	}

	protected virtual void OnPropertyChanged(string property)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
