using System;

namespace buEyeBaseVer5;

[Serializable]
public class MachineConfigSettings : buSerilization5
{
	public string PartTypeInfo = "";

	public string PartTypeAdder = "";

	public MachineConfigSettings()
	{
	}

	public MachineConfigSettings(MachineConfigSettings data)
	{
	}
}
