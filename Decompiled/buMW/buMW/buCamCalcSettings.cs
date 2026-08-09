using System.Drawing;
using System.Reflection;
using buClass;
using buEyeBaseVer5;

namespace buMW;

public class buCamCalcSettings : buSerilization5
{
	public bool ShowMwDialogBox = false;

	public double XAxisMinLimit = 0.0;

	public double XAxisMaxLimit = 0.0;

	public double YAxisMinLimit = 0.0;

	public double YAxisMaxLimit = 0.0;

	public double ZAxisMinLimit = 0.0;

	public double ZAxisMaxLimit = 0.0;

	public double AAxisMinLimit = 0.0;

	public double AAxisMaxLimit = 0.0;

	public double BAxisMinLimit = 0.0;

	public double BAxisMaxLimit = 0.0;

	public double CAxisMinLimit = 0.0;

	public double CAxisMaxLimit = 0.0;

	public bool CopyToolDataToCamData = false;

	public bool CopyToolFeedToCamFeed = true;

	public bool CopyToolPlungeFeedToCamPlungeFeed = true;

	public bool CopyToolRetractFeedToCamRetractFeed = true;

	public bool ShowProgressForm = true;

	public drawPropertiesType CamMarkDraw = new drawPropertiesType(Color.DarkGreen, 2f, new drawingPattern());

	public drawPropertiesType CamG0Draw = new drawPropertiesType(Color.Brown, 2f, new drawingPattern());

	public drawPropertiesType CamG1Draw = new drawPropertiesType(Color.Blue, 2f, new drawingPattern());

	public drawPropertiesType CamPlungeDraw = new drawPropertiesType(Color.Lime, 2f, new drawingPattern());

	public drawPropertiesType CamLeaveDraw = new drawPropertiesType(Color.Red, 2f, new drawingPattern());

	public drawPropertiesType CamLeadinDraw = new drawPropertiesType(Color.Cyan, 2f, new drawingPattern());

	public drawPropertiesType CamLeadOutDraw = new drawPropertiesType(Color.Orange, 2f, new drawingPattern());

	public drawPropertiesType CamConnectionDraw = new drawPropertiesType(Color.Purple, 2f, new drawingPattern());

	public drawPropertiesType CamOtherDraw = new drawPropertiesType(Color.DarkGray, 2f, new drawingPattern());

	public double CamMarkSize = 0.5;

	public buCamCalcSettings()
	{
	}

	public buCamCalcSettings(buCamCalcSettings data)
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
