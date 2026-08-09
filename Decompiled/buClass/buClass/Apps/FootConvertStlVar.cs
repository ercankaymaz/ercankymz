using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace buClass.Apps;

[Serializable]
public class FootConvertStlVar : buSerilization
{
	public double ScanDistanceX = 2.0;

	public double ScanDistanceY = 2.0;

	public double ScanDistanceXForSurface = 10.0;

	public double ScanDistanceYForSurface = 10.0;

	public double ProfileResolution = 0.02;

	public PerpendicularDirection Direction = PerpendicularDirection.Vertical;

	public int StlLayerIndex = 0;

	public int ProfileLayerIndex = 1;

	public int ConvertedStlLayerIndex = 2;

	public int TabanLayerIndex = 3;

	public int CalculatedCurvesLayerIndex = 4;

	public int MetetarsLayerIndex = 5;

	public int TopukLayerIndex = 6;

	public int ArcLayerIndex = 7;

	public int RefletionLayerIndex = 8;

	public int FirstGridLineDevideCount = 5;

	public int LastGridLineDevideCount = 5;

	public double SurfaceCurveResolution = 0.2;

	public double SurfaceResoluton = 0.05;

	public double BorderCurveResolution = 0.05;

	public bool ShowMovePoints = true;

	public double MoveFirstInternalLineDistanceAtYDir = 0.0;

	public double MoveLastInternalLineDistanceAtYDir = 0.0;

	public int InternalCurveDevideCount = 10;

	public double FootDepth = 20.0;

	public SurfaceFromProfileAndHeight MetetarsData = new SurfaceFromProfileAndHeight();

	public string MetatarsPath = Application.StartupPath;

	public static List<string> Captions = new List<string>();

	public FootConvertStlVar()
	{
	}

	public FootConvertStlVar(FootConvertStlVar data)
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
