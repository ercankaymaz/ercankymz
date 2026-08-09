using System;
using System.Collections.Specialized;
using System.Windows.Input;

namespace Microsoft.Windows.Design.Interaction;

public class MenuAction : MenuBase
{
	private class MenuActionCommand : ICommand
	{
		private MenuAction _owner;

		public event EventHandler CanExecuteChanged;

		public MenuActionCommand(MenuAction owner)
		{
			_owner = owner;
		}

		internal void RaiseCanExecuteChanged()
		{
			if (this.CanExecuteChanged != null)
			{
				this.CanExecuteChanged(_owner, EventArgs.Empty);
			}
		}

		bool ICommand.CanExecute(object parameter)
		{
			if (_owner.Enabled)
			{
				return _owner.Visible;
			}
			return false;
		}

		public void Execute(object parameter)
		{
			if (_owner.Execute != null)
			{
				_owner.Execute(_owner, new MenuActionEventArgs(_owner.Context));
			}
		}
	}

	private static int stateIsCheckable = BitVector32.CreateMask();

	private static int stateIsChecked = BitVector32.CreateMask(stateIsCheckable);

	private static int stateIsEnabled = BitVector32.CreateMask(stateIsChecked);

	private static int stateIsVisible = BitVector32.CreateMask(stateIsEnabled);

	private BitVector32 _state = default(BitVector32);

	private Uri _imageUri;

	private MenuActionCommand _command;

	public ICommand Command
	{
		get
		{
			if (_command == null)
			{
				_command = new MenuActionCommand(this);
			}
			return _command;
		}
	}

	public bool Checkable
	{
		get
		{
			return _state[stateIsCheckable];
		}
		set
		{
			if (_state[stateIsCheckable] != value)
			{
				_state[stateIsCheckable] = value;
				OnPropertyChanged("Checkable");
			}
		}
	}

	public bool Checked
	{
		get
		{
			return _state[stateIsChecked];
		}
		set
		{
			if (_state[stateIsChecked] != value)
			{
				_state[stateIsChecked] = value;
				OnPropertyChanged("Checked");
			}
		}
	}

	public bool Enabled
	{
		get
		{
			return _state[stateIsEnabled];
		}
		set
		{
			if (_state[stateIsEnabled] != value)
			{
				_state[stateIsEnabled] = value;
				OnPropertyChanged("Enabled");
				if (_command != null)
				{
					_command.RaiseCanExecuteChanged();
				}
			}
		}
	}

	public bool Visible
	{
		get
		{
			return _state[stateIsVisible];
		}
		set
		{
			if (_state[stateIsVisible] != value)
			{
				_state[stateIsVisible] = value;
				OnPropertyChanged("Visible");
				if (_command != null)
				{
					_command.RaiseCanExecuteChanged();
				}
			}
		}
	}

	public Uri ImageUri
	{
		get
		{
			return _imageUri;
		}
		set
		{
			if (_imageUri != value)
			{
				_imageUri = value;
				OnPropertyChanged("ImageUri");
			}
		}
	}

	public event EventHandler<MenuActionEventArgs> Execute;

	public MenuAction(string displayName)
	{
		base.DisplayName = displayName;
		Enabled = true;
		Visible = true;
	}
}
