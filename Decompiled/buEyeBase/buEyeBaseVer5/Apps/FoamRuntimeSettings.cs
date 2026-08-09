using System;
using System.Reflection;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class FoamRuntimeSettings : buSerilization5
{
	public double WaveFormPyramidShapeHeight = 30.0;

	public double WaveFormPyramidShapeWidth = 30.0;

	public double WaveFormPyramidShapeBaseHeight = 15.0;

	public double WaveFormPyramidShapeCount = 5.0;

	public double WaveFormVShapeHeight = 30.0;

	public double WaveFormVShapeWidth = 30.0;

	public double WaveFormVShapeBaseHeight = 100.0;

	public double WaveFormUShapeHeight = 30.0;

	public double WaveFormUShapeWidth = 30.0;

	public double WaveFormUShapeBaseHeight = 100.0;

	public double WaveFormSShapeHeight = 20.0;

	public double WaveFormSShapeWidth = 60.0;

	public double WaveFormSShapeBaseHeight = 100.0;

	public double WaveFormCShapeHeight = 20.0;

	public double WaveFormCShapeWidth = 60.0;

	public double WaveFormCShapeBaseHeight = 100.0;

	public double WaveFormZShapeHeight = 30.0;

	public double WaveFormZShapeWidth = 30.0;

	public double WaveFormZShapeBaseHeight = 100.0;

	public double WaveFormRectShapeHeight = 30.0;

	public double WaveFormRectShapeWidth = 30.0;

	public double WaveFormRectShapeBaseHeight = 100.0;

	public double WaveFormShapeCommonHeight = 30.0;

	public double WaveFormShapeCommonWidth = 30.0;

	public double WaveFormShapeCommonBaseHeight = 100.0;

	public double WaveFormShapeCommonCount = 5.0;

	public double WaveFormShapeCommonRoundRad = 0.0;

	public double WaveFormShapeCommonChamferLen = 0.0;

	public int WaveFormRepeatCount = 0;

	public double WaveFormSpace = 0.0;

	public double SlicesHeight = 50.0;

	public double ShapeLength = 500.0;

	public double WaveFormTopHeight = 20.0;

	public double WaveFormBottomHeight = 20.0;

	public double WaveFormZHeight = 0.0;

	public double WaveFormStartOffset = 0.0;

	public double WaveFormEndOffset = 0.0;

	public double MoveX = 0.0;

	public string BlockName = "Block";

	public double BlockWidth = 0.0;

	public double BlockHeight = 0.0;

	public double BlockIdealWidth = 0.0;

	public double BlockIdealHeight = 0.0;

	public double PatternWidth = 0.0;

	public double PatternHeight = 0.0;

	public double PatternOrjWidth = 0.0;

	public double PatternOrjHeight = 0.0;

	public double PatternWidthStartOffset = 10.0;

	public double PatternWidthEndOffset = 10.0;

	public double PatternHeightStartOffset = 10.0;

	public double PatternHeightEndOffset = 10.0;

	public bool PatternMirrorX = false;

	public bool PatternMirrorY = false;

	public bool DrawBorder = true;

	public bool WaveReverse = false;

	public bool WaveUpDownDirection = true;

	public bool SemiAutoSelection = false;

	public bool ShowVirtualDrawings = false;

	public double MaterialWidth = 2000.0;

	public double MaterialHeight = 1000.0;

	public double MaterialDepth = 500.0;

	public FoamPlaneType planeNames = FoamPlaneType.XZ;

	public FoamType TypeFoam = FoamType.VForm;

	public FoamOperationType Operation = FoamOperationType.Pattern;

	public string pathFoamPattern = Application.StartupPath;

	public string pathFoamJob = Application.StartupPath;

	public string pathConverter = Application.StartupPath;

	public int SimStep = 1;

	public FoamRuntimeSettings()
	{
	}

	public FoamRuntimeSettings(FoamRuntimeSettings data)
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
