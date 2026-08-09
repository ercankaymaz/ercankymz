using System.ComponentModel;
using System.Drawing;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonRibbonContext), "ToolboxBitmaps.KryptonRibbonContext.bmp")]
[DefaultProperty("ContextName")]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public class KryptonRibbonContext : Component
{
	private string _contextName;

	private string _contextTitle;

	private Color _contextColor;

	private object _tag;

	[Category("Appearance")]
	[Description("Unique name of the context.")]
	[DefaultValue("Context")]
	public string ContextName
	{
		get
		{
			return _contextName;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Context";
			}
			if (value != _contextName)
			{
				_contextName = value;
				OnPropertyChanged("ContextName");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Display title for associated contextual tabs.")]
	[DefaultValue("Context")]
	public string ContextTitle
	{
		get
		{
			return _contextTitle;
		}
		set
		{
			if (string.IsNullOrEmpty(value))
			{
				value = "Context Tools";
			}
			if (value != _contextTitle)
			{
				_contextTitle = value;
				OnPropertyChanged("ContextTitle");
			}
		}
	}

	[Bindable(true)]
	[Localizable(true)]
	[Category("Appearance")]
	[Description("Display color for associated contextual tabs.")]
	[DefaultValue(typeof(Color), "Red")]
	public Color ContextColor
	{
		get
		{
			return _contextColor;
		}
		set
		{
			if (value == Color.Transparent)
			{
				value = Color.Red;
			}
			if (value != _contextColor)
			{
				_contextColor = value;
				OnPropertyChanged("ContextColor");
			}
		}
	}

	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			if (value != _tag)
			{
				_tag = value;
				OnPropertyChanged("Tag");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonRibbonContext()
	{
		_contextName = "Context";
		_contextTitle = "Context Tools";
		_contextColor = Color.Red;
	}

	private bool ShouldSerializeTag()
	{
		return Tag != null;
	}

	private void ResetTag()
	{
		Tag = null;
	}

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
