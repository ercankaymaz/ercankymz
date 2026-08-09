namespace System.ServiceModel.Channels;

public sealed class NamedPipeSettings
{
	public ApplicationContainerSettings ApplicationContainerSettings { get; private set; }

	internal NamedPipeSettings()
	{
		ApplicationContainerSettings = new ApplicationContainerSettings();
	}

	private NamedPipeSettings(NamedPipeSettings elementToBeCloned)
	{
		if (elementToBeCloned.ApplicationContainerSettings != null)
		{
			ApplicationContainerSettings = elementToBeCloned.ApplicationContainerSettings.Clone();
		}
	}

	internal NamedPipeSettings Clone()
	{
		return new NamedPipeSettings(this);
	}

	internal bool IsMatch(NamedPipeSettings pipeSettings)
	{
		if (pipeSettings == null)
		{
			return false;
		}
		if (!ApplicationContainerSettings.IsMatch(pipeSettings.ApplicationContainerSettings))
		{
			return false;
		}
		return true;
	}
}
