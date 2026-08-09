using System;
using System.Reflection;

namespace buClass.Apps;

[Serializable]
public class ProfileRuntimeSettings : buSerilization
{
	public double NewProfileWidth = 100.0;

	public double NewProfileHeight = 100.0;

	public double NewProfileThickness = 2.0;

	public double SimStep = 2.0;

	public double ClamperMoveStep = 10.0;

	public int DrawingeLayerIndex = 0;

	public int OperationWireframeLayerIndex = 1;

	public int AuxLayerIndex = 2;

	public int SupportBlockLayerIndex = 3;

	public int OperationPlaneLayerIndex = 4;

	public int CamLayerIndex = 5;

	public int OperationSolidLayerIndex = 7;

	public int ProfileLayerIndex = 8;

	public double PatternCopyDistance = 100.0;

	public double PatternCopyCutSpace = 4.0;

	public int PatternCopyCount = 1;

	public bool PatternShowSeperators = true;

	public double ProfileLength = 1000.0;

	public int ProfileMaxClamper = 4;

	public ProfileMacroOpenSave MacroSaveOpen = new ProfileMacroOpenSave();

	public ProfileRuntimeSettings()
	{
	}

	public ProfileRuntimeSettings(ProfileRuntimeSettings data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
			FieldInfo[] fields = GetType().GetFields();
			if (fields != null)
			{
				for (int i = 0; i <= fields.Length - 1; i++)
				{
					string name = fields[i].Name;
					object value = fields[i].GetValue(CopiedClass);
					fields[i].SetValue(this, value);
				}
			}
		}
		MacroSaveOpen = new ProfileMacroOpenSave(data.MacroSaveOpen);
	}
}
