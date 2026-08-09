using System.Drawing;
using System.Reflection;

namespace buClass.UserFiles.buCad;

public class setView : buSerilization
{
	public bool ShowDynamicBigCross = true;

	public bool ShowDynamicCross = true;

	public bool ShowDynamicText = true;

	public bool ShowDynamicTextCommand = true;

	public bool ShowDynamicTextInfo = true;

	public bool ShowDynamicLineArrow = true;

	public bool ShowMaterial = true;

	public double DrawMarkThickness = 2.0;

	public drawPropertiesType displayDynamicBigCrossDisplay = new drawPropertiesType(Color.LightGray, 1f, new drawingPattern());

	public drawPropertiesType displayDynamicCrossDisplay = new drawPropertiesType(Color.Red, 1f, new drawingPattern());

	public drawPropertiesType displayMarker = new drawPropertiesType(Color.Red, 1f, new drawingPattern());

	public Color colorDynamicText = Color.Red;

	public ContentAlignment DynamicTextAlignment = ContentAlignment.MiddleCenter;

	public bool ShowCommandDynamicText = true;

	public bool ShowDxDyDzValuesDynamicText = false;

	public double DynamicTextSize = 10.0;

	public bool ShowEntityPoints = true;

	public drawPropertiesType displayEntityPoints = new drawPropertiesType(Color.Red, 2f, new drawingPattern());

	public bool ShowOsnapPoints = true;

	public drawPropertiesType displayOsnapPoints = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());

	public drawPropertiesType displayOtherPoints = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());

	public Grid Grid = new Grid();

	public ProjectionModeType Projection = ProjectionModeType.Perspective;

	public DisplayModeType DisplayMode = DisplayModeType.Shaded;

	public bool SetViewUsePlane = true;

	public bool SetPlane = false;

	public bool ShowEdges = false;

	public bool CamareRotateEnable = true;

	public bool AutoPanWithMouseCursor = true;

	public double AutoPanScreenPersentage = 5.0;

	public int AutoPanAmount = 100;

	public int AutoPanRepeatTimems = 500;

	public bool ShowSelectedCamPoints = false;

	public bool SetPlaneAccordingToView = false;

	public bool AddViewButtonsToRightClickMenu = false;

	public setView()
	{
	}

	public setView(setView data)
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
				string name = fields[i].Name;
				object value = fields[i].GetValue(CopiedClass);
				fields[i].SetValue(this, value);
			}
		}
	}
}
