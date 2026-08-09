using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteContentImage : Storage
{
	private class InternalStorage
	{
		public PaletteRelativeAlign ContentImageH;

		public PaletteRelativeAlign ContentImageV;

		public PaletteImageEffect ContentEffect;

		public Color ContentImageColorMap;

		public Color ContentImageColorTo;

		public bool IsDefault => ContentImageH == PaletteRelativeAlign.Inherit && ContentImageV == PaletteRelativeAlign.Inherit && ContentEffect == PaletteImageEffect.Inherit && ContentImageColorMap == Color.Empty && ContentImageColorTo == Color.Empty;

		public InternalStorage()
		{
			ContentImageH = PaletteRelativeAlign.Inherit;
			ContentImageV = PaletteRelativeAlign.Inherit;
			ContentEffect = PaletteImageEffect.Inherit;
			ContentImageColorMap = Color.Empty;
			ContentImageColorTo = Color.Empty;
		}
	}

	private InternalStorage _storage;

	[Browsable(false)]
	public override bool IsDefault => _storage == null || _storage.IsDefault;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative horizontal alignment of content image.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRelativeAlign ImageH
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRelativeAlign.Inherit;
			}
			return _storage.ContentImageH;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentImageH != value)
				{
					_storage.ContentImageH = value;
					OnPropertyChanged("ImageH");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteRelativeAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentImageH = value;
				OnPropertyChanged("ImageH");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative vertical alignment of content image.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteRelativeAlign ImageV
	{
		get
		{
			if (_storage == null)
			{
				return PaletteRelativeAlign.Inherit;
			}
			return _storage.ContentImageV;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentImageV != value)
				{
					_storage.ContentImageV = value;
					OnPropertyChanged("ImageV");
					PerformNeedPaint(needLayout: true);
				}
			}
			else if (value != PaletteRelativeAlign.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentImageV = value;
				OnPropertyChanged("ImageV");
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Effect applied to drawing the image.")]
	[DefaultValue(typeof(PaletteImageEffect), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public PaletteImageEffect Effect
	{
		get
		{
			if (_storage == null)
			{
				return PaletteImageEffect.Inherit;
			}
			return _storage.ContentEffect;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentEffect != value)
				{
					_storage.ContentEffect = value;
					OnPropertyChanged("Effect");
					PerformNeedPaint();
				}
			}
			else if (value != PaletteImageEffect.Inherit)
			{
				_storage = new InternalStorage();
				_storage.ContentEffect = value;
				OnPropertyChanged("Effect");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color to remap in the image.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color ImageColorMap
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.ContentImageColorMap;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentImageColorMap != value)
				{
					_storage.ContentImageColorMap = value;
					OnPropertyChanged("ImageColorMap");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.ContentImageColorMap = value;
				OnPropertyChanged("ImageColorMap");
				PerformNeedPaint();
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Color to use in place of the image map.")]
	[KryptonDefaultColor]
	[RefreshProperties(RefreshProperties.All)]
	public Color ImageColorTo
	{
		get
		{
			if (_storage == null)
			{
				return Color.Empty;
			}
			return _storage.ContentImageColorTo;
		}
		set
		{
			if (_storage != null)
			{
				if (_storage.ContentImageColorTo != value)
				{
					_storage.ContentImageColorTo = value;
					OnPropertyChanged("ImageColorTo");
					PerformNeedPaint();
				}
			}
			else if (value != Color.Empty)
			{
				_storage = new InternalStorage();
				_storage.ContentImageColorTo = value;
				OnPropertyChanged("ImageColorTo");
				PerformNeedPaint();
			}
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public event PropertyChangedEventHandler PropertyChanged;

	public PaletteContentImage(NeedPaintHandler needPaint)
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
