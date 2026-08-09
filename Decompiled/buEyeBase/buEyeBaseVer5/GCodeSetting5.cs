using System;

namespace buEyeBaseVer5;

[Serializable]
public class GCodeSetting5 : buSerilization5
{
	public double FilterLength = 0.0;

	public bool CheckComma = true;

	public bool TrimLines = true;

	public bool UseMCode = true;

	public bool UseTCode = true;

	public bool UseSCode = true;
}
