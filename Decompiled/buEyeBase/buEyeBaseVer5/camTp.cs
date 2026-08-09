using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

[Serializable]
public class camTp : buSerilization5
{
	public ArrayList PreCodes = new ArrayList();

	public ArrayList PreCodesWithoutNo = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public ArrayList AfterCodesWithoutNo = new ArrayList();

	public List<TpPnt9D> PrePoints = new List<TpPnt9D>();

	public List<TpPnt9D> AfterPoints = new List<TpPnt9D>();

	public ArrayList ToolPreCodes = new ArrayList();

	public ArrayList ToolAfterCodes = new ArrayList();

	public ArrayList SpindlePreCodes = new ArrayList();

	public ArrayList SpindleAfterCodes = new ArrayList();

	public ArrayList CreatedGCodes = new ArrayList();

	public List<Entity> RefEntities = new List<Entity>();

	public List<Entity> sortedEntities = new List<Entity>();

	public List<List<Entity>> splitedEntities = new List<List<Entity>>();

	public SimulationTp SimilationPoint = new SimulationTp();

	public Pnt3D SimilationToolOffset = new Pnt3D();

	public List<Entity> EntitiesMark = new List<Entity>();

	public List<Entity> EntitiesG1 = new List<Entity>();

	public List<Entity> EntitiesG1Orj = new List<Entity>();

	public List<Entity> EntitiesG0 = new List<Entity>();

	public List<Entity> EntitiesPlunge = new List<Entity>();

	public List<Entity> EntitiesLeave = new List<Entity>();

	public List<Entity> EntitiesOther = new List<Entity>();

	public List<Entity> EntitiesLeadIn = new List<Entity>();

	public List<Entity> EntitiesLeadOut = new List<Entity>();

	public List<Entity> EntitiesConnection = new List<Entity>();

	public List<int> EntityIndex = new List<int>();

	public List<DirectionArrow> DirectionArrows = new List<DirectionArrow>();

	public List<camTpPoint> CamPoints = new List<camTpPoint>();

	public KinematicBase5 Kinematic = new KinematicBase5();

	public PostProcessor Post = new PostProcessor();

	public CamInfo Information = new CamInfo();

	public ToolBase5 Tool = new ToolBase5();

	public WorkPlane Plane = new WorkPlane();

	public camParameters5 Parameter = new camParameters5();

	public object mwParameter = null;

	public Vector3D OperationVector = new Vector3D(0.0, 0.0, 1.0);

	public Pnt6D PositionOffset = new Pnt6D();

	public MWCalculationOptions MWCalcOptions = new MWCalculationOptions();

	public object OperationData = new object();

	public object CamData = new object();

	public Pnt3D RefPoint = new Pnt3D();

	public Vec3D MoveOffset = new Vec3D();

	public CamType TypeCam = CamType.None;

	public CamMode Mode = CamMode.WireFrame;

	public CamWireFrameType CamWireframeType = CamWireFrameType.Contour;

	public CamTriangularMeshType CamTriMeshType = CamTriangularMeshType.Rough;

	public CamDrillType CamDrillType = CamDrillType.Line;

	public planeNames PlaneName = planeNames.Top;

	public CamSequence Sequnce = CamSequence.None;

	public string Station = "";

	public string Explanation = "";

	public string Name = "";

	public string SceneName = "";

	public double OperationHeight = 0.0;

	public double ZSafeDistance = 0.0;

	public double Aux1 = 0.0;

	public double Aux2 = 0.0;

	public bool Aux1First = true;

	public int AxisCount = 3;

	public int MaterialIndex = -1;

	public int RegionIndex = 0;

	public int ZAxisIndex = 0;

	public int CamOptions = 0;

	public int Index = 0;

	public int ImageIndex = 0;

	public int CamID = 0;

	public int NumberOfAxis = 3;

	public bool UsedCamPost = false;

	public bool Enable = true;

	public bool Visible = true;

	public bool Used = false;

	public actionTypeBU Action = actionTypeBU.None;

	public object Obj1 = null;

	public object Obj2 = null;

	public camTp()
	{
	}

	public camTp(camTp data)
	{
		if (data == null)
		{
			return;
		}
		object CopiedClass = new object();
		buSerilization5.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
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
		MoveOffset = new Vec3D(data.MoveOffset);
		if (data.Parameter != null)
		{
			Parameter = new camParameters5(data.Parameter);
		}
		if (data.Kinematic != null)
		{
			Kinematic = new KinematicBase5(data.Kinematic);
		}
		if (data.Post != null)
		{
			Post = new PostProcessor(data.Post);
		}
		if (data.Information != null)
		{
			Information = new CamInfo(data.Information);
		}
		if (data.Plane != null)
		{
			Plane = new WorkPlane(data.Plane);
		}
		AfterPoints = new List<TpPnt9D>();
		PrePoints = new List<TpPnt9D>();
		for (int j = 0; j <= data.AfterPoints.Count - 1; j++)
		{
			AfterPoints.Add(new TpPnt9D(data.AfterPoints[j]));
		}
		for (int k = 0; k <= data.PrePoints.Count - 1; k++)
		{
			PrePoints.Add(new TpPnt9D(data.PrePoints[k]));
		}
		if (OperationData != null && OperationData.GetType() != typeof(object))
		{
			OperationData = buClone.DeepCopy(data.OperationData);
		}
		if (data.SimilationPoint != null)
		{
			SimilationPoint = new SimulationTp(data.SimilationPoint);
		}
		if (data.DirectionArrows != null)
		{
			DirectionArrows.Clear();
			for (int l = 0; l <= data.DirectionArrows.Count - 1; l++)
			{
				DirectionArrows.Add(new DirectionArrow(DirectionArrows[l]));
			}
		}
		if (data.splitedEntities != null)
		{
			splitedEntities.Clear();
			splitedEntities = new List<List<Entity>>();
			buVector5.CopyEntities(data.splitedEntities, ref splitedEntities);
		}
		if (data.sortedEntities != null)
		{
			sortedEntities.Clear();
			sortedEntities = new List<Entity>();
			buVector5.CopyEntities(data.sortedEntities, ref sortedEntities);
		}
		if (data.RefEntities != null)
		{
			RefEntities.Clear();
			RefEntities = new List<Entity>();
			buVector5.CopyEntities(data.RefEntities, ref RefEntities);
		}
		if (data.EntitiesG0 != null)
		{
			EntitiesG0.Clear();
			buVector5.CopyEntities(data.EntitiesG0, ref EntitiesG0);
		}
		if (data.EntitiesG1 != null)
		{
			EntitiesG1.Clear();
			buVector5.CopyEntities(data.EntitiesG1, ref EntitiesG1);
		}
		if (data.EntitiesLeadIn != null)
		{
			EntitiesLeadIn.Clear();
			buVector5.CopyEntities(data.EntitiesLeadIn, ref EntitiesLeadIn);
		}
		if (data.EntitiesLeadOut != null)
		{
			EntitiesLeadOut.Clear();
			buVector5.CopyEntities(data.EntitiesLeadOut, ref EntitiesLeadOut);
		}
		if (data.EntitiesLeave != null)
		{
			EntitiesLeave.Clear();
			buVector5.CopyEntities(data.EntitiesLeave, ref EntitiesLeave);
		}
		if (data.EntitiesMark != null)
		{
			EntitiesMark.Clear();
			buVector5.CopyEntities(data.EntitiesMark, ref EntitiesMark);
		}
		if (data.EntitiesOther != null)
		{
			EntitiesOther.Clear();
			buVector5.CopyEntities(data.EntitiesOther, ref EntitiesOther);
		}
		if (data.EntitiesPlunge != null)
		{
			EntitiesPlunge.Clear();
			buVector5.CopyEntities(data.EntitiesPlunge, ref EntitiesPlunge);
		}
		if (data.EntitiesConnection != null)
		{
			EntitiesConnection.Clear();
			buVector5.CopyEntities(data.EntitiesConnection, ref EntitiesConnection);
		}
		EntityIndex.Clear();
		for (int m = 0; m <= data.EntityIndex.Count - 1; m++)
		{
			EntityIndex.Add(data.EntityIndex[m]);
		}
		CamPoints.Clear();
		for (int n = 0; n <= data.CamPoints.Count - 1; n++)
		{
			CamPoints.Add(new camTpPoint(data.CamPoints[n]));
		}
		AfterCodes.Clear();
		for (int num = 0; num <= data.AfterCodes.Count - 1; num++)
		{
			AfterCodes.Add(data.AfterCodes[num]);
		}
		AfterCodesWithoutNo.Clear();
		for (int num2 = 0; num2 <= data.AfterCodesWithoutNo.Count - 1; num2++)
		{
			AfterCodesWithoutNo.Add(data.AfterCodesWithoutNo[num2]);
		}
		PreCodes.Clear();
		for (int num3 = 0; num3 <= data.PreCodes.Count - 1; num3++)
		{
			PreCodes.Add(data.PreCodes[num3]);
		}
		PreCodesWithoutNo.Clear();
		for (int num4 = 0; num4 <= data.PreCodesWithoutNo.Count - 1; num4++)
		{
			PreCodesWithoutNo.Add(data.PreCodesWithoutNo[num4]);
		}
		ToolPreCodes.Clear();
		for (int num5 = 0; num5 <= data.ToolPreCodes.Count - 1; num5++)
		{
			ToolPreCodes.Add(data.ToolPreCodes[num5]);
		}
		ToolAfterCodes.Clear();
		for (int num6 = 0; num6 <= data.ToolAfterCodes.Count - 1; num6++)
		{
			ToolAfterCodes.Add(data.ToolAfterCodes[num6]);
		}
		SpindleAfterCodes.Clear();
		for (int num7 = 0; num7 <= data.SpindleAfterCodes.Count - 1; num7++)
		{
			SpindleAfterCodes.Add(data.SpindleAfterCodes[num7]);
		}
		SpindlePreCodes.Clear();
		for (int num8 = 0; num8 <= data.SpindlePreCodes.Count - 1; num8++)
		{
			SpindlePreCodes.Add(data.SpindlePreCodes[num8]);
		}
		CreatedGCodes.Clear();
		for (int num9 = 0; num9 <= data.CreatedGCodes.Count - 1; num9++)
		{
			CreatedGCodes.Add(data.CreatedGCodes[num9]);
		}
	}

	public static void CopyCam(camTp baseCam, ref camTp copiedCam)
	{
		copiedCam = new camTp(baseCam);
	}

	public static void CopyCam(List<camTp> RefCam, ref List<camTp> CopiedCam)
	{
		CopiedCam.Clear();
		CopiedCam = new List<camTp>();
		for (int i = 0; i <= RefCam.Count - 1; i++)
		{
			camTp item = new camTp(RefCam[i]);
			CopiedCam.Add(item);
		}
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		buSerilization5.ExceptionalVariables.Clear();
		buSerilization5.ExceptionalVariables.Add("Shape");
		arrayList.Add(text + "<camTp>");
		arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode5.MultiLine).ToArray());
		arrayList.Add(text + "</camTp>");
		return arrayList;
	}

	public static eEntities Decode(List<string> AL, string Char, SerilizationMode5 Mode)
	{
		List<string> CalcList = new List<string>();
		new List<string>();
		eEntities eEntities2 = new eEntities();
		string text = "";
		buStatics.ListToSpecificList("<" + eEntities2.GetType().Name + Char + ">", "</" + eEntities2.GetType().Name + Char + ">", AL, ref CalcList);
		if (CalcList.Count > 0)
		{
			text = CalcList[0];
		}
		if ((text.Length == 0) & (AL.Count > 0))
		{
			text = AL[0];
		}
		if (text.Length > 0)
		{
		}
		return eEntities2;
	}

	public override string ToString()
	{
		string text = TypeCam.ToString();
		if (Tool != null)
		{
			text = text + " - Tool Purpose: " + Tool.Purpose.ToString() + " - Type: " + Tool.Geometry.GeometryType;
		}
		if (Used)
		{
			text += " - Used";
		}
		if (Sequnce != CamSequence.None)
		{
			text = text + " - Seq: " + Sequnce;
		}
		return text;
	}
}
