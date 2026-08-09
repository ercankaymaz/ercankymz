using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using buClass;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class PipeBendTempVars
{
	public static int StepZ = 30;

	public static double MedianRadius = 300.0;

	public static int PipeExecStep = 100;

	public static int OffsetX = 0;

	public static int OffsetY = 216;

	public static string StraightBlockName = "straight";

	public static string StraightbackBlockName = "StraightBack";

	public static string BendBlockName = "bend";

	public static string MachineBlockName = "machine";

	public static readonly collisionCheckType _checkMethod = collisionCheckType.SubdivisionTree;

	public static bool ProgressFinished = false;

	public static int _bendPartCounter;

	public static Circle _c1;

	public static CollisionDetection _cd;

	public static readonly List<Entity> collidedEntities = new List<Entity>();

	public static int doneZSteps;

	public static int _entityCollisionIndex;

	public static double _excecutionPipe;

	public static readonly bool _firstOnly = true;

	public static int _numOfFileBlocks;

	public static int _numOfFileEntities;

	public static int NumberOfSim = 0;

	public static Color _pipeColor;

	public static double _pipeDiameter;

	public static int _pipeRowQuantity;

	public static double _pipeTotalLength;

	public Brep _rev1;

	public static readonly Vector3D _machineTranslation = new Vector3D(-1400.0, -495.0, -922.0);

	public static double _machineScalingFactor = 2.1;

	public static int[] machineCollisionEntities = new int[4] { 30, 31, 68, 69 };

	public static readonly Color collisionColor = Color.OrangeRed;

	public static readonly Color collisionColor2 = Color.DarkRed;

	public static Dictionary<Entity, Color> originalColors = new Dictionary<Entity, Color>();

	public static readonly Stopwatch _sw = new Stopwatch();

	public static int _straightPartCounter;

	public static readonly List<Entity> _surfList = new List<Entity>();

	public string LayerGeneral = "";

	public string LayerFoam = "";

	public string Layer3DPattern = "";

	public string LayerWirePattern = "";

	public string LayerSelection = "";

	public string LayerMark = "";

	public string LayerDefault = "Default";

	public PipeBendTempVars()
	{
	}

	public PipeBendTempVars(PipeBendTempVars data)
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
