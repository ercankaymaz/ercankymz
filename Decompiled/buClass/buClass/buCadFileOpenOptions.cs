using System;

namespace buClass;

[Serializable]
public class buCadFileOpenOptions : buSerilization
{
	public bool OpenCamList = true;

	public bool OpenProfileList = false;

	public buCadFileOpenOptions()
	{
	}

	public buCadFileOpenOptions(bool cam, bool profile)
	{
		OpenCamList = cam;
		OpenProfileList = profile;
	}
}
