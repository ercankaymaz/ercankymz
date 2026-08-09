using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

[Serializable]
public class Router3AXCAM : buSerilization5
{
	public string CamName = "";

	public bool isError = false;

	public bool Enable = true;

	public Point3D MinPoint = new Point3D();

	public Point3D MaxPoint = new Point3D();

	public planeBoxNames planeName = planeBoxNames.Top;

	public camTp CamData = new camTp();

	public ToolBase5 Tool = new ToolBase5();

	public camParameters5 CamPars = new camParameters5();

	public List<buEntity> CamEntities = new List<buEntity>();

	public Router3AXCamPlane entitiesPlane = null;

	public CamMode camMode = CamMode.WireFrame;

	public CamWireFrameType camWireframeType = CamWireFrameType.Contour;

	public CamTriangularMeshType camMeshType = CamTriangularMeshType.ParallelCuts;

	public CamTriangularMesh5AxType camMesh5AXType = CamTriangularMesh5AxType.ParallelCuts;

	public CamSurfaceType camSurfType = CamSurfaceType.SurfaceParalel;

	public CamDrillType camDrillType = CamDrillType.Point;

	public Router3AXLayerPurpose Purpose = Router3AXLayerPurpose.None;

	public Router3AXCAM()
	{
	}

	public Router3AXCAM(Router3AXCAM data)
	{
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
		CamPars = new camParameters5(data.CamPars);
		buEntity.Copy(data.CamEntities, ref CamEntities);
		CamData = new camTp(data.CamData);
		if (data.entitiesPlane != null)
		{
			entitiesPlane = new Router3AXCamPlane(data.entitiesPlane);
		}
	}

	public static void Decode(List<string> AL, ref FoamBlock Item)
	{
	}

	public static ArrayList ToDef(FoamBlock refItem, int Space)
	{
		return new ArrayList();
	}

	public override string ToString()
	{
		return CamName.ToString();
	}
}
