using System.ComponentModel;

namespace Microsoft.Windows.Design.Interaction;

public abstract class MenuBase : INotifyPropertyChanged
{
	private string _name;

	private string _displayName;

	private EditingContext _context;

	public EditingContext Context
	{
		get
		{
			return _context;
		}
		internal set
		{
			if (_context != value)
			{
				_context = value;
				OnPropertyChanged("Context");
			}
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (_name != value)
			{
				_name = value;
				OnPropertyChanged("Name");
			}
		}
	}

	public string DisplayName
	{
		get
		{
			return _displayName;
		}
		set
		{
			if (_displayName != value)
			{
				_displayName = value;
				OnPropertyChanged("DisplayName");
			}
		}
	}

	public event PropertyChangedEventHandler PropertyChanged;

	protected virtual void OnPropertyChanged(string propertyName)
	{
		if (this.PropertyChanged != null)
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
