namespace System.ServiceModel.Channels;

public sealed class ApplicationContainerSettings
{
	public const int CurrentSession = -1;

	public const int ServiceSession = 0;

	private const string GroupNameSuffixFormat = ";SessionId={0};PackageFullName={1}";

	private int _sessionId;

	public string PackageFullName { get; set; }

	public int SessionId
	{
		get
		{
			return _sessionId;
		}
		set
		{
			if (value < -1)
			{
				throw FxTrace.Exception.Argument("value", System.SR.Format(System.SR.SessionValueInvalid, value));
			}
			_sessionId = value;
		}
	}

	internal bool TargetingAppContainer => !string.IsNullOrEmpty(PackageFullName);

	internal ApplicationContainerSettings()
	{
		PackageFullName = null;
		_sessionId = -1;
	}

	private ApplicationContainerSettings(ApplicationContainerSettings source)
	{
		PackageFullName = source.PackageFullName;
		_sessionId = source._sessionId;
	}

	internal ApplicationContainerSettings Clone()
	{
		return new ApplicationContainerSettings(this);
	}

	internal bool IsMatch(ApplicationContainerSettings applicationContainerSettings)
	{
		if (applicationContainerSettings == null)
		{
			return false;
		}
		if (PackageFullName != applicationContainerSettings.PackageFullName)
		{
			return false;
		}
		if (_sessionId != applicationContainerSettings._sessionId)
		{
			return false;
		}
		return true;
	}
}
