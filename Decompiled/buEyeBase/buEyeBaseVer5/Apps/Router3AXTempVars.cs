using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXTempVars : buSerilization5
{
	public string layerPanel = "Panel";

	public string layerOperation = "Operation";

	public string layerGeneral = "General";

	public string layerSelected = "Selected";

	public string layerCam = "Cam";

	public string layerCamPlane = "CamPlane";

	public string layerWireframe = "Wireframe";

	public string layerSheet = "Sheet";

	public string layerPart = "Part";

	public string layerSolid = "Solid";

	public ViewportRefType ViewportRef = ViewportRefType.Main;

	public planeBoxNames activePlane = planeBoxNames.Top;

	public Router3AXTempVars()
	{
	}

	public Router3AXTempVars(Router3AXTempVars data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
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
