using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using buClass.Apps;

namespace buClass;

[Serializable]
public class camBase : buSerilization
{
	public List<List<eEntities>> EntitiesList = new List<List<eEntities>>();

	public Pnt3D EntitiesPoint = new Pnt3D();

	public List<eEntities> Entities = new List<eEntities>();

	public List<List<eEntities>> CalculatedEntities = new List<List<eEntities>>();

	public List<eEntities> BaseEntities = new List<eEntities>();

	public List<eEntities> ItemEntities = new List<eEntities>();

	public List<List<Pnt6D>> CalculatedPnt6D = new List<List<Pnt6D>>();

	public List<Pnt9D> Points = new List<Pnt9D>();

	public List<List<Pnt3D>> SortedPoints = new List<List<Pnt3D>>();

	public List<CamPoint> CamPoints = new List<CamPoint>();

	public KinematicBase Kinematic = new KinematicBase();

	public ArrayList PreCodes = new ArrayList();

	public ArrayList AfterCodes = new ArrayList();

	public ArrayList CreatedGCodes = new ArrayList();

	public List<int> BaseEntitiesIndex = new List<int>();

	public ForceCamAxisStrings ForceAxisString = new ForceCamAxisStrings();

	public CamInfo Information = new CamInfo();

	public ToolBase Tool = new ToolBase();

	public WorkPlane Plane = new WorkPlane();

	public camParameters Parameter = new camParameters();

	public PostProcessor Post = new PostProcessor();

	public GrindingOperations GrindingParameter = new GrindingOperations();

	public object OperationData = new object();

	public object CamData = new object();

	public Vec3D MoveOffset = new Vec3D();

	public Pnt3D StartPoint = new Pnt3D();

	public Pnt3D RefPoint = new Pnt3D();

	public ShapeData Shape = null;

	public bool UseCreatedGCode = false;

	public bool UsedCamPost = false;

	public Color DrawColor = Color.Red;

	public int AxisCount = 3;

	public bool Enable = true;

	public int ZAxisIndex = 0;

	public int RegionIndex = 0;

	public double ZSafeDistance = 0.0;

	public int ModeIndex = 0;

	public int ModeSubIndex = 0;

	public string Station = "";

	public string Explanation = "";

	public string Name = "";

	public int LayerIndex = -1;

	public string LayerName = "";

	public string SceneName = "";

	public double OperationHeight = 0.0;

	public CamType CamType = CamType.None;

	public int CamOptions = 0;

	public int Index = 0;

	public int ImageIndex = 0;

	public int CadIndex = -1;

	public int CamID = 0;

	public int ParrentCamID = -1;

	public double TotalOperationTimeSec = 0.0;

	public double TotalOperationDistance = 0.0;

	public double TotalOperationG1Distance = 0.0;

	public double TotalOperationG0Distance = 0.0;

	public actionTypeBU Action = actionTypeBU.None;

	public camBase()
	{
	}

	public camBase(camBase data)
	{
		object CopiedClass = new object();
		buSerilization.CopyClass(data, ref CopiedClass);
		if (this != null && CopiedClass != null && GetType() == CopiedClass.GetType())
		{
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
		if (data.GrindingParameter != null)
		{
			GrindingParameter = new GrindingOperations(data.GrindingParameter);
		}
		if (data.Parameter != null)
		{
			Parameter = new camParameters(data.Parameter);
		}
		StartPoint = new Pnt3D(data.StartPoint);
		Kinematic = new KinematicBase(data.Kinematic);
		Tool = new ToolBase(data.Tool);
		if (data.Shape != null)
		{
			Shape = new ShapeData(data.Shape);
		}
		Pnt6D.Copy(data.CalculatedPnt6D, ref CalculatedPnt6D);
		if (OperationData != null)
		{
			OperationData = buClone.DeepCopy(data.OperationData);
		}
		if (data.EntitiesList != null)
		{
			EntitiesList.Clear();
			EntitiesList = new List<List<eEntities>>();
			eEntities.CopyEntities(data.EntitiesList, ref EntitiesList);
		}
		BaseEntities.Clear();
		for (int j = 0; j <= data.BaseEntities.Count - 1; j++)
		{
			eEntities copiedEnt = new eEntities();
			eEntities.CopyEntity(data.BaseEntities[j], ref copiedEnt);
			BaseEntities.Add(copiedEnt);
		}
		CalculatedEntities.Clear();
		eEntities.CopyEntities(data.CalculatedEntities, ref CalculatedEntities);
		Entities.Clear();
		for (int k = 0; k <= data.Entities.Count - 1; k++)
		{
			eEntities copiedEnt2 = new eEntities();
			eEntities.CopyEntity(data.Entities[k], ref copiedEnt2);
			Entities.Add(copiedEnt2);
		}
		ItemEntities.Clear();
		for (int l = 0; l <= data.ItemEntities.Count - 1; l++)
		{
			eEntities copiedEnt3 = new eEntities();
			eEntities.CopyEntity(data.ItemEntities[l], ref copiedEnt3);
			ItemEntities.Add(copiedEnt3);
		}
		Points.Clear();
		for (int m = 0; m <= data.Points.Count - 1; m++)
		{
			Points.Add(new Pnt9D(data.Points[m]));
		}
		EntitiesPoint = new Pnt3D(data.EntitiesPoint);
		SortedPoints.Clear();
		for (int n = 0; n <= data.SortedPoints.Count - 1; n++)
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			Pnt3D.Copy(data.SortedPoints[n], ref CopiedPnt);
			SortedPoints.Add(CopiedPnt);
		}
		CamPoints.Clear();
		for (int num = 0; num <= data.CamPoints.Count - 1; num++)
		{
			CamPoints.Add(new CamPoint(data.CamPoints[num]));
		}
		AfterCodes.Clear();
		for (int num2 = 0; num2 <= data.AfterCodes.Count - 1; num2++)
		{
			AfterCodes.Add(data.AfterCodes[num2]);
		}
		PreCodes.Clear();
		for (int num3 = 0; num3 <= data.PreCodes.Count - 1; num3++)
		{
			PreCodes.Add(data.PreCodes[num3]);
		}
		CreatedGCodes.Clear();
		for (int num4 = 0; num4 <= data.CreatedGCodes.Count - 1; num4++)
		{
			CreatedGCodes.Add(data.CreatedGCodes[num4]);
		}
		BaseEntitiesIndex.Clear();
		for (int num5 = 0; num5 <= data.BaseEntitiesIndex.Count - 1; num5++)
		{
			BaseEntitiesIndex.Add(data.BaseEntitiesIndex[num5]);
		}
	}

	public static void CopyCam(camBase baseCam, ref camBase copiedCam)
	{
		copiedCam = new camBase(baseCam);
	}

	public static void CopyCam(List<camBase> RefCam, ref List<camBase> CopiedCam)
	{
		CopiedCam.Clear();
		CopiedCam = new List<camBase>();
		for (int i = 0; i <= RefCam.Count - 1; i++)
		{
			camBase item = new camBase(RefCam[i]);
			CopiedCam.Add(item);
		}
	}

	public ArrayList ToDefAll(int Space)
	{
		string text = new string(' ', Space);
		ArrayList arrayList = new ArrayList();
		buSerilization.ExceptionalVariables.Clear();
		buSerilization.ExceptionalVariables.Add("Shape");
		arrayList.Add(text + "<camBase>");
		arrayList.AddRange(ToDefAll("", Space + 2, SerilizationMode.MultiLine).ToArray());
		arrayList.Add(text + "</camBase>");
		return arrayList;
	}

	public static eEntities Decode(List<string> AL, string Char, SerilizationMode Mode)
	{
		List<string> CalcList = new List<string>();
		List<string> list = new List<string>();
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
}
