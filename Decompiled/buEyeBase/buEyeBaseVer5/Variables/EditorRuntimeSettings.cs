using System;
using System.Reflection;
using buClass;

namespace buEyeBaseVer5.Variables;

[Serializable]
public class EditorRuntimeSettings : buSerilization5
{
	public double FilletRadius = 5.0;

	public double ChamferLength = 5.0;

	public double OffsetValue = 10.0;

	public double EqualDistance = 20.0;

	public double RotateAngle = 0.0;

	public double ScaleRatio = 1.0;

	public double ExtendLength = 0.0;

	public double GridMaxValue = 500.0;

	public double LastRotateAngle = 90.0;

	public double TurnOverDistance = 10.0;

	public int PolygonSide = 6;

	public double KeyHoleLength = 33.0;

	public double KeyHoleHeadDiameter = 17.0;

	public double KeyHoleWidth = 10.0;

	public double KeyHoleAngle = 0.0;

	public HorizontalVertical LastMirrorType = HorizontalVertical.Horizontal;

	public bool ShowDimension = true;

	public bool ShowContrraint = true;

	public bool isSketchMode = false;

	public bool isSewingMode = false;

	public bool isFoamMode = false;

	public bool GridEnable = true;

	public bool OsnapOverDisable = false;

	public bool OsnapEntityDisable = false;

	public bool OsnapGridDisable = false;

	public bool OsnapPointDisable = false;

	public bool FromFileKeepRatio = true;

	public bool TurnOverCenter = false;

	public bool ExplodeCompositeCurveToEntities = true;

	public bool ExplodeCircleToArc = true;

	public bool ExplodeCircleToPolyline = false;

	public bool ExplodeArcToPolyline = false;

	public bool ExplodeEllipseToPolyline = false;

	public bool ExplodeCurveToPolyline = true;

	public bool ExplodePolylineToLine = false;

	public string pathFromFile = "C:\\";

	public EditorRuntimeSettings()
	{
	}

	public EditorRuntimeSettings(EditorRuntimeSettings data)
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
