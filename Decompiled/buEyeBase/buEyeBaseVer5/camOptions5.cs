using System;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class camOptions5 : buSerilization5
{
	public bool ShowAdvancedPArameters = false;

	public bool ShpwCoreParameters = false;

	public bool SelectAllPoints = false;

	public bool SelectAllDrawings = false;

	public bool ToolDataToCamData = true;

	public double PocketNextContourMaxDistance = 10.0;

	public camAxesLimits AxesLimit = new camAxesLimits();

	public double StockHeight = 10.0;

	public double SpinSpeed = 100.0;

	public bool FeedFromEntityFeedrate = false;

	public bool Vacuum1 = false;

	public bool Vacuum2 = false;

	public bool Vacuum3 = false;

	public bool Vacuum4 = false;

	public bool Vacuum5 = false;

	public bool Vacuum6 = false;

	public bool Vacuum7 = false;

	public bool Vacuum8 = false;

	public double WidthXDirection = 0.0;

	public double WidthYDirection = 0.0;

	public double WidthXYDirection = 0.0;

	public double ExtendPatternOutput = 0.0;

	public bool UseXZPlane = false;

	public bool StockEnable = false;

	public bool StockSilhouette = false;

	public double StockTolarance = 0.1;

	public double StockOffset = 0.0;

	public CamStockOffsetMode StockOffsetMode = CamStockOffsetMode.SomExpand;

	public CamStockType StockType = CamStockType.StBoundingBox;

	public CamStockSilhouetteType StockSilhouetteType = CamStockSilhouetteType.partEnd;

	public Point3D StockOffsetMin = new Point3D();

	public Point3D StockOffsetMax = new Point3D();

	public List<RegenResolutionData> RegenList = new List<RegenResolutionData>();

	public static List<string> Captions = new List<string>();

	public camOptions5()
	{
	}

	public camOptions5(camOptions5 data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null)
		{
			if (GetType() == CopiedClass.GetType())
			{
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
			if (data.RegenList.Count > 0)
			{
				for (int j = 0; j <= data.RegenList.Count - 1; j++)
				{
					RegenList.Add(new RegenResolutionData(RegenList[j]));
				}
			}
		}
		((camOptions5)CopiedClass).AxesLimit = new camAxesLimits(data.AxesLimit);
	}

	public override string ToString()
	{
		return "SelectAllPoints: " + SelectAllPoints;
	}
}
