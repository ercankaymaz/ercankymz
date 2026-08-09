using System;
using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecAny : ButtonSpec
{
	private bool _visible;

	private ButtonEnabled _enabled;

	private ButtonCheckState _checked;

	private ButtonEnabled _wasEnabled;

	private ButtonCheckState _wasChecked;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Visible && Enabled == ButtonEnabled.Container && Checked == ButtonCheckState.NotCheckButton;

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Should the button be shown.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(true)]
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
				OnButtonSpecPropertyChanged("Visible");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Defines the button enabled state.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(ButtonEnabled), "Container")]
	public ButtonEnabled Enabled
	{
		get
		{
			return _enabled;
		}
		set
		{
			if (_enabled != value)
			{
				_enabled = value;
				OnButtonSpecPropertyChanged("Enabled");
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Defines if the button is checked or capable of being checked.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(ButtonCheckState), "NotCheckButton")]
	public ButtonCheckState Checked
	{
		get
		{
			return _checked;
		}
		set
		{
			if (_checked != value)
			{
				_checked = value;
				OnButtonSpecPropertyChanged("Checked");
			}
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the button.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(null)]
	public override KryptonCommand KryptonCommand
	{
		get
		{
			return base.KryptonCommand;
		}
		set
		{
			if (base.KryptonCommand != value)
			{
				if (base.KryptonCommand == null)
				{
					_wasEnabled = Enabled;
					_wasChecked = Checked;
				}
				base.KryptonCommand = value;
				if (base.KryptonCommand == null)
				{
					Enabled = _wasEnabled;
					Checked = _wasChecked;
				}
			}
		}
	}

	[Localizable(true)]
	[Category("Behavior")]
	[Description("Defines the type of button specification.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(PaletteButtonSpecStyle), "Generic")]
	public PaletteButtonSpecStyle Type
	{
		get
		{
			return base.ProtectedType;
		}
		set
		{
			if (base.ProtectedType != value)
			{
				base.ProtectedType = value;
				OnButtonSpecPropertyChanged("Type");
			}
		}
	}

	public ButtonSpecAny()
	{
		_visible = true;
		_enabled = ButtonEnabled.Container;
		_checked = ButtonCheckState.NotCheckButton;
	}

	public override object Clone()
	{
		ButtonSpecAny buttonSpecAny = (ButtonSpecAny)base.Clone();
		buttonSpecAny.Visible = Visible;
		buttonSpecAny.Enabled = Enabled;
		buttonSpecAny.Checked = Checked;
		buttonSpecAny.Type = Type;
		return buttonSpecAny;
	}

	public void ResetVisible()
	{
		Visible = true;
	}

	public void ResetEnabled()
	{
		Enabled = ButtonEnabled.Container;
	}

	private bool ShouldSerializeChecked()
	{
		return Checked != ButtonCheckState.NotCheckButton;
	}

	public void ResetChecked()
	{
		Checked = ButtonCheckState.NotCheckButton;
	}

	public void ResetType()
	{
		Type = PaletteButtonSpecStyle.Generic;
	}

	public void CopyFrom(ButtonSpecAny source)
	{
		Visible = source.Visible;
		Enabled = source.Enabled;
		Checked = source.Checked;
		base.CopyFrom(source);
	}

	public override bool GetVisible(IPalette palette)
	{
		return Visible;
	}

	public override ButtonEnabled GetEnabled(IPalette palette)
	{
		return Enabled;
	}

	public override ButtonCheckState GetChecked(IPalette palette)
	{
		return Checked;
	}

	protected override void OnButtonSpecPropertyChanged(string propertyName)
	{
		base.OnButtonSpecPropertyChanged(propertyName);
		if (propertyName == "KryptonCommand")
		{
			if (KryptonCommand != null)
			{
				if (Checked != ButtonCheckState.NotCheckButton)
				{
					Checked = (KryptonCommand.Checked ? ButtonCheckState.Checked : ButtonCheckState.Unchecked);
				}
				Enabled = (KryptonCommand.Enabled ? ButtonEnabled.True : ButtonEnabled.False);
			}
		}
		else if (propertyName == "Checked" && KryptonCommand != null)
		{
			KryptonCommand.Checked = Checked == ButtonCheckState.Checked;
		}
	}

	protected override void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		base.OnCommandPropertyChanged(sender, e);
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (!(text == "Checked"))
		{
			if (text == "Enabled")
			{
				Enabled = (KryptonCommand.Enabled ? ButtonEnabled.True : ButtonEnabled.False);
			}
		}
		else
		{
			Checked = (KryptonCommand.Checked ? ButtonCheckState.Checked : ButtonCheckState.Unchecked);
		}
	}

	protected override void OnClick(EventArgs e)
	{
		if (GetViewEnabled() && Checked != ButtonCheckState.NotCheckButton)
		{
			if (Checked == ButtonCheckState.Unchecked)
			{
				Checked = ButtonCheckState.Checked;
			}
			else
			{
				Checked = ButtonCheckState.Unchecked;
			}
		}
		base.OnClick(e);
	}
}
