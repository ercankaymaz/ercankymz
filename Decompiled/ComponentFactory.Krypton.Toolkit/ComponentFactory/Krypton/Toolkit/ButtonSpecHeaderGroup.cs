using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class ButtonSpecHeaderGroup : ButtonSpecAny
{
	private HeaderLocation _location;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && HeaderLocation == HeaderLocation.PrimaryHeader;

	[Localizable(true)]
	[Category("Visuals")]
	[Description("Defines header location for the button.")]
	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(typeof(HeaderLocation), "PrimaryHeader")]
	public HeaderLocation HeaderLocation
	{
		get
		{
			return _location;
		}
		set
		{
			if (_location != value)
			{
				_location = value;
				OnButtonSpecPropertyChanged("Location");
			}
		}
	}

	public ButtonSpecHeaderGroup()
	{
		_location = HeaderLocation.PrimaryHeader;
	}

	public void ResetHeaderLocation()
	{
		HeaderLocation = HeaderLocation.PrimaryHeader;
	}

	public void CopyFrom(ButtonSpecHeaderGroup source)
	{
		HeaderLocation = source.HeaderLocation;
		CopyFrom((ButtonSpecAny)source);
	}

	public override HeaderLocation GetLocation(IPalette palette)
	{
		return HeaderLocation;
	}
}
