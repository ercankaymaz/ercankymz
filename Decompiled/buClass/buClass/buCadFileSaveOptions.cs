using System;

namespace buClass;

[Serializable]
public class buCadFileSaveOptions : buSerilization
{
	public bool SaveCamList = true;

	public bool SaveProfileList = false;

	public buCadFileSaveOptions()
	{
	}

	public buCadFileSaveOptions(bool cam, bool profile)
	{
		SaveCamList = cam;
		SaveProfileList = profile;
	}
}
