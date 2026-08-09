using System;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class DoorTempVars
{
	public string layerPanel = "Panel";

	public string layerOperation = "Operation";

	public string layerGeneral = "General";

	public string layerSelected = "Selected";

	public string layerCam = "Cam";

	public buShape lastShape = null;

	public ViewportRefType ViewportRef = ViewportRefType.Main;

	public planeBoxNames activePlane = planeBoxNames.Top;

	public int selectedDoorIndex = -1;

	public int selectedItemIndex = -1;

	public DoorTempVars()
	{
	}

	public DoorTempVars(DoorTempVars data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null) || !(GetType() == CopiedClass.GetType()))
		{
			return;
		}
		FieldInfo[] fields = GetType().GetFields();
		if (fields != null)
		{
			for (int i = 0; i <= fields.Length - 1; i++)
			{
				_ = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
