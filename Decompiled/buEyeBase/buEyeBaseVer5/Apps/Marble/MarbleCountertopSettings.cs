using System;
using System.Drawing;
using System.Reflection;

namespace buEyeBaseVer5.Apps.Marble;

[Serializable]
public class MarbleCountertopSettings : buSerilization5
{
	public double CountertopSlatOffset = 0.0;

	public double CountertopRotation = 0.0;

	public double CountertopRadius = 0.0;

	public double CountertopChamfer = 0.0;

	public double CountertopRectangleWidth = 1000.0;

	public double CountertopRectangleHeight = 600.0;

	public double CountertopLWidth = 1500.0;

	public double CountertopLHeight = 800.0;

	public double CountertopLTopLegWidth = 300.0;

	public double CountertopLBottomLegHeight = 300.0;

	public double CountertopTrapezTopWidth = 1800.0;

	public double CountertopTrapezBottomWidth = 2000.0;

	public double CountertopTrapezHeight = 2000.0;

	public double SocketDefaultWidth = 80.0;

	public double SocketDefaultHeight = 80.0;

	public bool InsideAngleCutOnTopAsSize = true;

	public bool DimensionFromCenter = false;

	public bool ShowInsideDimensions = true;

	public bool ShowInsideLocations = true;

	public bool ShowInsideAngleText = true;

	public bool ShowOutsideDimensions = true;

	public bool ShowOutsideAngleText = true;

	public bool ShowSlatAngleText = true;

	public bool ShowAngleSolid = false;

	public bool ShowChamferSolid = true;

	public bool CollapseAs3DOnMain = false;

	public bool Collapseas3DWihDifferentColor = true;

	public bool CollopseSharpCorner = true;

	public Color colorAngleSolid = Color.LightBlue;

	public Color colorAnglePlane = Color.LimeGreen;

	public Color colorChamferTopPlane = Color.Magenta;

	public Color colorChamferBottomPlane = Color.Magenta;

	public Color colorChamferTopSolid = Color.MediumPurple;

	public Color colorChamferBottomSolid = Color.MediumPurple;

	public Color colorMainAngleText = Color.Black;

	public Color colorMainDimension = Color.Black;

	public Color colorSinkAngle = Color.Green;

	public Color colorSinkDimension = Color.Blue;

	public Color colorSinkLoction = Color.Orange;

	public Color colorBuiltInngle = Color.Green;

	public Color colorBuiltInDimension = Color.BlueViolet;

	public Color colorBuiltInLocation = Color.Orange;

	public Color colorSocketAngle = Color.Green;

	public Color colorSocketDimension = Color.DarkBlue;

	public Color colorSocketLoction = Color.Orange;

	public Color colorTapAngle = Color.Green;

	public Color colorTapDimension = Color.DarkSlateBlue;

	public Color colorTapLoction = Color.Orange;

	public Color colorCavitySolid = Color.Gray;

	public Color colorCavityAngle = Color.Green;

	public Color colorCavityDimension = Color.DarkSlateBlue;

	public Color colorCavityLoction = Color.Orange;

	public Color colorSlatAngle = Color.Green;

	public Color colorCollapse = Color.Cyan;

	public marbleCountertopMainData MainData = new marbleCountertopMainData();

	public marbleCountertopInsideData SinkFirstData = new marbleCountertopInsideData();

	public marbleCountertopInsideData SinkSecondData = new marbleCountertopInsideData();

	public marbleCountertopInsideData BuiltInFirstData = new marbleCountertopInsideData();

	public marbleCountertopInsideData BuiltInSecondData = new marbleCountertopInsideData();

	public marbleCountertopInsideData SocketFirstData = new marbleCountertopInsideData();

	public marbleCountertopInsideData SocketSecondData = new marbleCountertopInsideData();

	public marbleCountertopTapData TapFirstData = new marbleCountertopTapData();

	public marbleCountertopTapData TapSecondData = new marbleCountertopTapData();

	public marbleCountertopTapData TapThirdData = new marbleCountertopTapData();

	public marbleCountertopTapData TapFourthData = new marbleCountertopTapData();

	public marbleCountertopCavityData CavityFirstData = new marbleCountertopCavityData();

	public marbleCountertopCavityData CavitySecondData = new marbleCountertopCavityData();

	public marbleSlatData SlatData = new marbleSlatData();

	public marbleChamferBothSideData ChamferEdgeData = new marbleChamferBothSideData();

	public marbleChamferBothSideData ChamferSlatData = new marbleChamferBothSideData();

	public MarbleCountertopSettings()
	{
	}

	public MarbleCountertopSettings(MarbleCountertopSettings data)
	{
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (!(this != null && CopiedClass != null))
		{
			return;
		}
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
		BuiltInFirstData = new marbleCountertopInsideData(data.BuiltInFirstData);
		BuiltInSecondData = new marbleCountertopInsideData(data.BuiltInSecondData);
		SinkFirstData = new marbleCountertopInsideData(data.SinkFirstData);
		SinkSecondData = new marbleCountertopInsideData(data.SinkSecondData);
		SocketFirstData = new marbleCountertopInsideData(data.SocketFirstData);
		SocketSecondData = new marbleCountertopInsideData(data.SocketSecondData);
		TapFirstData = new marbleCountertopTapData(data.TapFirstData);
		TapSecondData = new marbleCountertopTapData(data.TapSecondData);
		TapThirdData = new marbleCountertopTapData(data.TapThirdData);
		TapFourthData = new marbleCountertopTapData(data.TapFourthData);
		CavityFirstData = new marbleCountertopCavityData(data.CavityFirstData);
		CavitySecondData = new marbleCountertopCavityData(data.CavitySecondData);
	}
}
