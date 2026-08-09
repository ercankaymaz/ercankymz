#define DEBUG
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteBorder : Storage, IPaletteBorder
{
	private class InternalStorage
	{
		public InheritBool BorderDraw;

		public PaletteDrawBorders BorderDrawBorders;

		public PaletteGraphicsHint BorderGraphicsHint;

		public Color BorderColor1;

		public Color BorderColor2;

		public PaletteColorStyle BorderColorStyle;

		public PaletteRectangleAlign BorderColorAlign;

		public float BorderColorAngle;

		public int BorderWidth;

		public int BorderRounding;

		public Image BorderImage;

		public PaletteImageStyle BorderImageStyle;

		public PaletteRectangleAlign BorderImageAlign;

		public bool IsDefault => BorderDraw == InheritBool.Inherit && BorderDrawBorders == PaletteDrawBorders.Inherit && BorderGraphicsHint == PaletteGraphicsHint.Inherit && BorderColor1 == Color.Empty && BorderColor2 == Color.Empty && BorderColorStyle == PaletteColorStyle.Inherit && BorderColorAlign == PaletteRectangleAlign.Inherit && BorderColorAngle == -1f && BorderWidth == -1 && BorderRounding == -1 && BorderImage == null && BorderImageStyle == PaletteImageStyle.Inherit && BorderImageAlign == PaletteRectangleAlign.Inherit;

		public InternalStorage()
		{
			BorderDraw = InheritBool.Inherit;
			BorderDrawBorders = PaletteDrawBorders.All;
			BorderGraphicsHint = PaletteGraphicsHint.Inherit;
			BorderColor1 = Color.Empty;
			BorderColor2 = Color.Empty;
			BorderColorStyle = PaletteColorStyle.Inherit;
			BorderColorAlign = PaletteRectangleAlign.Inherit;
			BorderColorAngle = -1f;
			BorderWidth = -1;
			BorderRounding = -1;
			BorderImageStyle = PaletteImageStyle.Inherit;
			BorderImageAlign = PaletteRectangleAlign.Inherit;
		}
	}

	private IPaletteBorder _inherit;

	private InternalStorage _storage;

	[Browsable(false)]
	public override bool IsDefault => _storage == null || _storage.IsDefault;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Should border be drawn.")]
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
			return _storage.BorderDraw;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderDraw != value)
				{
					_storage.BorderDraw = value;
					OnPropertyChanged("Draw");
					PerformNeedPaint();
				}
			}
			else if (value != InheritBool.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderDraw = value;
				OnPropertyChanged("Draw");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Specify which borders should be drawn.")]
	[DefaultValue(typeof(PaletteDrawBorders), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	[Editor("ComponentFactory.Krypton.Toolkit.PaletteDrawBordersEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public PaletteDrawBorders DrawBorders
	{
		get
		{
			if (_storage == null)
			{
				return PaletteDrawBorders.Inherit;
			}
			return _storage.BorderDrawBorders;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderDrawBorders != value)
				{
					_storage.BorderDrawBorders = value;
					OnPropertyChanged("DrawBorders");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteDrawBorders.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderDrawBorders = value;
				OnPropertyChanged("DrawBorders");
				PerformNeedPaint(needLayout: true);
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
			return _storage.BorderGraphicsHint;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderGraphicsHint != value)
				{
					_storage.BorderGraphicsHint = value;
					OnPropertyChanged("GraphicsHint");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteGraphicsHint.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderGraphicsHint = value;
				OnPropertyChanged("GraphicsHint");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Main border color.")]
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
			return _storage.BorderColor1;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderColor1 != value)
				{
					_storage.BorderColor1 = value;
					OnPropertyChanged("Color1");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.BorderColor1 = value;
				OnPropertyChanged("Color1");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Secondary border color.")]
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
			return _storage.BorderColor2;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderColor2 != value)
				{
					_storage.BorderColor2 = value;
					OnPropertyChanged("Color2");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.BorderColor2 = value;
				OnPropertyChanged("Color2");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border color drawing style.")]
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
			return _storage.BorderColorStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderColorStyle != value)
				{
					_storage.BorderColorStyle = value;
					OnPropertyChanged("ColorStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteColorStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderColorStyle = value;
				OnPropertyChanged("ColorStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border color alignment style.")]
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
			return _storage.BorderColorAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderColorAlign != value)
				{
					_storage.BorderColorAlign = value;
					OnPropertyChanged("ColorAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderColorAlign = value;
				OnPropertyChanged("ColorAlign");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border color angle.")]
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
			return _storage.BorderColorAngle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderColorAngle != value)
				{
					_storage.BorderColorAngle = value;
					OnPropertyChanged("ColorAngle");
					PerformNeedPaint();
				}
			}
			else if (value != -1f)
			{
				_storage = new InternalStorage();
				_storage.BorderColorAngle = value;
				OnPropertyChanged("ColorAngle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border width.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int Width
	{
		get
		{
			if (_storage == null)
			{
				return -1;
			}
			return _storage.BorderWidth;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderWidth != value)
				{
					_storage.BorderWidth = value;
					OnPropertyChanged("Width");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != -1)
			{
				_storage = new InternalStorage();
				_storage.BorderWidth = value;
				OnPropertyChanged("Width");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("How much to round the border corners.")]
	[DefaultValue(-1)]
	[RefreshProperties(RefreshProperties.All)]
	public int Rounding
	{
		get
		{
			if (_storage == null)
			{
				return -1;
			}
			return _storage.BorderRounding;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderRounding != value)
				{
					_storage.BorderRounding = value;
					OnPropertyChanged("Rounding");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != -1)
			{
				_storage = new InternalStorage();
				_storage.BorderRounding = value;
				OnPropertyChanged("Rounding");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border image.")]
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
			return _storage.BorderImage;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderImage != value)
				{
					_storage.BorderImage = value;
					OnPropertyChanged("Image");
					PerformNeedPaint();
				}
			}
			else if (value != null)
			{
				_storage = new InternalStorage();
				_storage.BorderImage = value;
				OnPropertyChanged("Image");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border image style.")]
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
			return _storage.BorderImageStyle;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderImageStyle != value)
				{
					_storage.BorderImageStyle = value;
					OnPropertyChanged("ImageStyle");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteImageStyle.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderImageStyle = value;
				OnPropertyChanged("ImageStyle");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Border image alignment style.")]
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
			return _storage.BorderImageAlign;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.BorderImageAlign != value)
				{
					_storage.BorderImageAlign = value;
					OnPropertyChanged("ImageAlign");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteRectangleAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.BorderImageAlign = value;
				OnPropertyChanged("ImageAlign");
				PerformNeedPaint();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event PropertyChangedEventHandler PropertyChanged;

	public PaletteBorder(IPaletteBorder inherit, NeedPaintHandler needPaint)
	{
		Debug.Assert(inherit != null);
		_inherit = inherit;
		NeedPaint = needPaint;
	}

	public void SetInherit(IPaletteBorder inherit)
	{
		_inherit = inherit;
	}

	public void PopulateFromBase(PaletteState state)
	{
		Draw = GetBorderDraw(state);
		DrawBorders = GetBorderDrawBorders(state);
		GraphicsHint = GetBorderGraphicsHint(state);
		Color1 = GetBorderColor1(state);
		Color2 = GetBorderColor2(state);
		ColorStyle = GetBorderColorStyle(state);
		ColorAlign = GetBorderColorAlign(state);
		ColorAngle = GetBorderColorAngle(state);
		Width = GetBorderWidth(state);
		Rounding = GetBorderRounding(state);
		Image = GetBorderImage(state);
		ImageStyle = GetBorderImageStyle(state);
		ImageAlign = GetBorderImageAlign(state);
	}

	public InheritBool GetBorderDraw(PaletteState state)
	{
		if (Draw != InheritBool.Inherit)
		{
			return Draw;
		}
		return _inherit.GetBorderDraw(state);
	}

	private bool ShouldSerializeDrawBorders()
	{
		return DrawBorders != PaletteDrawBorders.Inherit;
	}

	public PaletteDrawBorders GetBorderDrawBorders(PaletteState state)
	{
		if (DrawBorders != PaletteDrawBorders.Inherit)
		{
			return DrawBorders;
		}
		return _inherit.GetBorderDrawBorders(state);
	}

	public PaletteGraphicsHint GetBorderGraphicsHint(PaletteState state)
	{
		if (GraphicsHint != PaletteGraphicsHint.Inherit)
		{
			return GraphicsHint;
		}
		return _inherit.GetBorderGraphicsHint(state);
	}

	public Color GetBorderColor1(PaletteState state)
	{
		if (Color1 != Color.Empty)
		{
			return Color1;
		}
		return _inherit.GetBorderColor1(state);
	}

	public Color GetBorderColor2(PaletteState state)
	{
		if (Color2 != Color.Empty)
		{
			return Color2;
		}
		return _inherit.GetBorderColor2(state);
	}

	public PaletteColorStyle GetBorderColorStyle(PaletteState state)
	{
		if (ColorStyle != PaletteColorStyle.Inherit)
		{
			return ColorStyle;
		}
		return _inherit.GetBorderColorStyle(state);
	}

	public PaletteRectangleAlign GetBorderColorAlign(PaletteState state)
	{
		if (ColorAlign != PaletteRectangleAlign.Inherit)
		{
			return ColorAlign;
		}
		return _inherit.GetBorderColorAlign(state);
	}

	public float GetBorderColorAngle(PaletteState state)
	{
		if (ColorAngle != -1f)
		{
			return ColorAngle;
		}
		return _inherit.GetBorderColorAngle(state);
	}

	public int GetBorderWidth(PaletteState state)
	{
		if (Width != -1)
		{
			return Width;
		}
		return _inherit.GetBorderWidth(state);
	}

	public int GetBorderRounding(PaletteState state)
	{
		if (Rounding != -1)
		{
			return Rounding;
		}
		return _inherit.GetBorderRounding(state);
	}

	public Image GetBorderImage(PaletteState state)
	{
		if (Image != null)
		{
			return Image;
		}
		return _inherit.GetBorderImage(state);
	}

	private bool ShouldSerializeImageStyle()
	{
		return ImageStyle != PaletteImageStyle.Inherit;
	}

	public PaletteImageStyle GetBorderImageStyle(PaletteState state)
	{
		if (ImageStyle != PaletteImageStyle.Inherit)
		{
			return ImageStyle;
		}
		return _inherit.GetBorderImageStyle(state);
	}

	public PaletteRectangleAlign GetBorderImageAlign(PaletteState state)
	{
		if (ImageAlign != PaletteRectangleAlign.Inherit)
		{
			return ImageAlign;
		}
		return _inherit.GetBorderImageAlign(state);
	}

	protected virtual void OnPropertyChanged(string property)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(property));
		}
	}
}
