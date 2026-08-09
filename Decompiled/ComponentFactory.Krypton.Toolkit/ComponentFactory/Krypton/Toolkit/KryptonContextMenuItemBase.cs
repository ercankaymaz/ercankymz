using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class KryptonContextMenuItemBase : Component, INotifyPropertyChanged
{
	private object _tag;

	private bool _visible;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract int ItemChildCount { get; }

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public abstract KryptonContextMenuItemBase this[int index] { get; }

	[KryptonPersist]
	[Category("Data")]
	[Description("User-defined data associated with the object.")]
	[TypeConverter(typeof(StringConverter))]
	[DefaultValue(null)]
	[Bindable(true)]
	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
		}
	}

	[KryptonPersist]
	[Category("Behavior")]
	[Description("Determines if the item is visible in the context menu.")]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			if (_visible != value)
			{
				_visible = value;
				OnPropertyChanged(new PropertyChangedEventArgs("Visible"));
			}
		}
	}

	[Category("Property Changed")]
	[Description("Occurs when the value of property has changed.")]
	public event PropertyChangedEventHandler PropertyChanged;

	public KryptonContextMenuItemBase()
	{
		_visible = true;
	}

	public abstract bool ProcessShortcut(Keys keyData);

	public abstract ViewBase GenerateView(IContextMenuProvider provider, object parent, ViewLayoutStack columns, bool standardStyle, bool imageColumn);

	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, e);
		}
	}
}
