using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonGalleryRange), "ToolboxBitmaps.KryptonGalleryRange.bmp")]
[DefaultProperty("Heading")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonGalleryRange : Component
{
	private string _heading;

	private int _imageIndexStart;

	private int _imageIndexEnd;

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Gallery range heading text.")]
	[DefaultValue("Heading")]
	public string Heading
	{
		get
		{
			return _heading;
		}
		set
		{
			if (value != _heading)
			{
				_heading = value;
				OnPropertyChanged("Heading");
			}
		}
	}

	[Category("Behavior")]
	[Description("Index of first image in the gallery ImageList for display.")]
	[DefaultValue(-1)]
	public int ImageIndexStart
	{
		get
		{
			return _imageIndexStart;
		}
		set
		{
			if (_imageIndexStart != value)
			{
				_imageIndexStart = value;
				OnPropertyChanged("ImageIndexStart");
			}
		}
	}

	[Category("Behavior")]
	[Description("Index of last image in the gallery ImageList for display.")]
	[DefaultValue(-1)]
	public int ImageIndexEnd
	{
		get
		{
			return _imageIndexEnd;
		}
		set
		{
			if (_imageIndexEnd != value)
			{
				_imageIndexEnd = value;
				OnPropertyChanged("ImageIndexEnd");
			}
		}
	}

	[Category("Gallery")]
	[Description("Occurs after the value of a property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonGalleryRange()
	{
		_heading = "Heading";
		_imageIndexStart = -1;
		_imageIndexEnd = -1;
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
