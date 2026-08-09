using System;
using System.Collections;
using System.Reflection;

namespace buClass;

[Serializable]
public class ToolCamData : buSerilization
{
	public double DepthConstant = 1.0;

	public int DepthSliceCount = 2;

	public CamDepthType DepthType = CamDepthType.Constant;

	public double Stepover = 0.0;

	public double Cutover = 0.0;

	public double OperationHeight = 0.0;

	public double AreaClearanceSpeed = 100.0;

	public double FinishSpeed = 100.0;

	public double RetractSpeed = 100.0;

	public double FeedSpeed = 100.0;

	public double PlungeSpeed = 30.0;

	public double SpindleSpeed = 10000.0;

	public double OperationHeigthForSecond = 0.0;

	public double ExtraOffset = 0.0;

	public double SafeDistance = 100.0;

	public bool Air = false;

	public bool Water = false;

	public bool Oil = false;

	public bool InnerCooling = false;

	public bool FeedFromTool = false;

	public bool DistanceFromTool = false;

	public bool DepthFromTool = false;

	public bool CutOverrideFromTool = true;

	public ArrayList AirText = new ArrayList();

	public ArrayList OilText = new ArrayList();

	public ArrayList WaterText = new ArrayList();

	public ArrayList InnerCoolText = new ArrayList();

	public Pnt6D SimMoveOffset = new Pnt6D();

	public ClockDirectionType SpindleDirection = ClockDirectionType.CW;

	public ToolCamData()
	{
	}

	public ToolCamData(ToolCamData cam)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(cam, ref CopiedClass);
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

	public override string ToString()
	{
		return "Feed: " + FeedSpeed + " - PlungeSpeed: " + PlungeSpeed + " - SpindleSpeed: " + SpindleSpeed + " - SpindleDir: " + SpindleDirection;
	}
}
