using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buConversion5
{
	public buConversion5()
	{
		if (!buVector5.smethod_0("buConversion5"))
		{
			throw new RegisterException("buConversion5");
		}
	}

	public static double RadianToDegree(double Radian)
	{
		try
		{
			double num = 0.0;
			return Radian * 180.0 / Math.PI;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double DegreeToRadian(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static double DegreeToRadianGreat360(double Degree)
	{
		try
		{
			double result = 0.0;
			if (Degree > 360.0)
			{
				Degree -= 360.0;
				result = Degree * Math.PI / 180.0 + Math.PI * 2.0;
				Degree += 360.0;
			}
			if (Degree <= 360.0)
			{
				result = Degree * Math.PI / 180.0;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return 0.0;
		}
	}

	public static string IntegerToBits(int Value, int DigitCount)
	{
		bool[] array = IntegerToBits(Value);
		string text = "";
		for (int i = 0; i <= array.Length - 1; i++)
		{
			if (i <= DigitCount - 1)
			{
				text = (array[i] ? (text + "1") : (text + "0"));
			}
		}
		return text;
	}

	public static bool[] IntegerToBits(int Value)
	{
		string text = Convert.ToString(Value, 2);
		int[] array = (from char_0 in text.PadLeft(32, '0')
			select int.Parse(char_0.ToString())).ToArray();
		bool[] array2 = new bool[array.Length];
		int num = 0;
		for (int num2 = array.Length - 1; num2 >= 0; num2--)
		{
			if (array[num2] == 0)
			{
				array2[num] = false;
			}
			else
			{
				array2[num] = true;
			}
			num++;
		}
		return array2;
	}

	public static int BitsToInteger(bool bit0, bool bit1, bool bit2, bool bit3, bool bit4, bool bit5, bool bit6, bool bit7)
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 8;
		while (num4 != 0)
		{
			double num5 = num4 % 10;
			num2 += num5 * Math.Pow(2.0, num3);
			num4 /= 10;
			num3 += 1.0;
		}
		return Convert.ToInt32(num2);
	}

	public static int BitsToInteger(string binary)
	{
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = Convert.ToInt32(binary);
		while (num4 != 0)
		{
			double num5 = num4 % 10;
			num2 += num5 * Math.Pow(2.0, num3);
			num4 /= 10;
			num3 += 1.0;
		}
		return Convert.ToInt32(num2);
	}

	public static Pnt3D Point3DToPnt3D(Point3D P)
	{
		try
		{
			if (!(P != null))
			{
				return new Pnt3D();
			}
			return new Pnt3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Point3D Pnt6DToPoint3D(Pnt6D P)
	{
		try
		{
			return new Point3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Point3D();
		}
	}

	public static Pnt3D Pnt6DToPnt3D(Pnt6DS P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static Pnt3D Pnt9DToPnt3D(Pnt9D P)
	{
		try
		{
			return new Pnt3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Pnt3D();
		}
	}

	public static string Point3DToString(Point3D P, int Decimal = 3)
	{
		try
		{
			if (!(P != null))
			{
				return "";
			}
			return P.X.ToString("f" + Decimal) + " , " + P.Y.ToString("f" + Decimal) + " , " + P.Z.ToString("f" + Decimal);
		}
		catch (Exception)
		{
			return "";
		}
	}

	public static void Point3DToPnt3D(Point3D[] RefPnt, ref List<Pnt3D> CopiedPnt)
	{
		try
		{
			CopiedPnt.Clear();
			CopiedPnt = new List<Pnt3D>();
			for (int i = 0; i <= RefPnt.Length - 1; i++)
			{
				CopiedPnt.Add(Point3DToPnt3D(RefPnt[i]));
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Point3DToPnt3D(List<Point3D> RefPnt, ref List<Pnt3D> CopiedPnt)
	{
		try
		{
			CopiedPnt.Clear();
			CopiedPnt = new List<Pnt3D>();
			for (int i = 0; i <= RefPnt.Count - 1; i++)
			{
				CopiedPnt.Add(Point3DToPnt3D(RefPnt[i]));
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Point3DToPnt3D(List<List<Point3D>> RefPnt, ref List<List<Pnt3D>> CopiedPnt)
	{
		CopiedPnt = new List<List<Pnt3D>>();
		for (int i = 0; i <= RefPnt.Count - 1; i++)
		{
			List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
			Point3DToPnt3D(RefPnt[i], ref CopiedPnt2);
			CopiedPnt.Add(CopiedPnt2);
		}
	}

	public static void Pnt9DToPnt3D(List<Pnt9D> RefPnt, ref List<Pnt3D> CopiedPnt)
	{
		try
		{
			CopiedPnt.Clear();
			CopiedPnt = new List<Pnt3D>();
			for (int i = 0; i <= RefPnt.Count - 1; i++)
			{
				CopiedPnt.Add(Pnt9DToPnt3D(RefPnt[i]));
			}
		}
		catch (Exception)
		{
		}
	}

	public static void Pnt6DToPnt3D(List<Pnt6DS> RefPnt, ref List<Pnt3D> CopiedPnt)
	{
		try
		{
			CopiedPnt.Clear();
			CopiedPnt = new List<Pnt3D>();
			for (int i = 0; i <= RefPnt.Count - 1; i++)
			{
				CopiedPnt.Add(Pnt6DToPnt3D(RefPnt[i]));
			}
		}
		catch (Exception)
		{
		}
	}

	public static List<Point3D> Pnt3dToPoint3D(List<Pnt3D> P)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= P.Count - 1; i++)
		{
			list.Add(new Point3D(P[i].X, P[i].Y, P[i].Z));
		}
		return list;
	}

	public static Point3D Pnt3DToPoint3D(Pnt3D P)
	{
		try
		{
			return new Point3D(P.X, P.Y, P.Z);
		}
		catch (Exception)
		{
			return new Point3D();
		}
	}

	public static void Pnt3DToPoint3D(List<Pnt3D> RefPnt, ref Point3D[] CopiedPnt)
	{
		if (RefPnt.Count <= 0)
		{
			return;
		}
		CopiedPnt = new Point3D[(RefPnt.Count - 1) * 2];
		int num = 0;
		for (int i = 0; i <= RefPnt.Count - 2; i++)
		{
			if (i != 0)
			{
				CopiedPnt[num] = Pnt3DToPoint3D(RefPnt[i]);
				num++;
				CopiedPnt[num] = Pnt3DToPoint3D(RefPnt[i + 1]);
				num++;
			}
			else
			{
				CopiedPnt[num] = Pnt3DToPoint3D(RefPnt[i]);
				num++;
				CopiedPnt[num] = Pnt3DToPoint3D(RefPnt[i + 1]);
				num++;
			}
		}
	}

	public static void Pnt3DToPoint3D(List<Pnt3D> RefPnt, ref List<Point3D> CopiedPnt)
	{
		if (RefPnt.Count > 0)
		{
			CopiedPnt.Clear();
			for (int i = 0; i <= RefPnt.Count - 1; i++)
			{
				CopiedPnt.Add(Pnt3DToPoint3D(RefPnt[i]));
			}
		}
	}

	public static void Pnt3dToPoint3D(List<List<Pnt3D>> RefPnt, ref List<List<Point3D>> CopiedPnt)
	{
		if (RefPnt.Count > 0)
		{
			CopiedPnt.Clear();
			for (int i = 0; i <= RefPnt.Count - 1; i++)
			{
				CopiedPnt.Add(Pnt3dToPoint3D(RefPnt[i]));
			}
		}
	}

	public static string ToString(Point3D P)
	{
		return "X : " + P.X.ToString("f3") + " , Y : " + P.Y.ToString("f3") + " , Z : " + P.Z.ToString("f3");
	}

	public static string ToString(OrientationAngle P)
	{
		return "A : " + P.A.ToString("f3") + " , B : " + P.B.ToString("f3") + " , C : " + P.C.ToString("f3");
	}

	public static Vector3D Vec3dToVector3D(Vec3D P)
	{
		return new Vector3D(P.X, P.Y, P.Z);
	}

	public static Vec3D Vector3DToVec3D(Vector3D P)
	{
		return new Vec3D(P.X, P.Y, P.Z);
	}

	public static System.Drawing.Point Screen3DTo2D(Design Viewport, Point3D Pnt)
	{
		try
		{
			PointF pointF = default(PointF);
			System.Drawing.Point result = default(System.Drawing.Point);
			Point2D point2D = new Point2D();
			point2D = Viewport.WorldToScreen(Pnt);
			pointF.X = (float)point2D.X;
			pointF.Y = (float)point2D.Y;
			result.X = (int)pointF.X;
			result.Y = Viewport.Height - (int)pointF.Y;
			if (result.X < 0)
			{
				result.X = 1;
			}
			if (result.Y < 0)
			{
				result.Y = 1;
			}
			return result;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return default(System.Drawing.Point);
		}
	}

	public static Point3D Screen2DTo3D(Design Viewport, Plane refPlane, System.Drawing.Point Pnt)
	{
		try
		{
			Point3D intPoint = new Point3D();
			Viewport.ScreenToPlane(Pnt, refPlane, out intPoint);
			if (intPoint == null)
			{
				intPoint = new Point3D();
			}
			return intPoint;
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, "");
			return new Point3D();
		}
	}

	public static void EntityInfoToCustomData(EntityInfo Info, EntityShapeInfo ShapeInfo, ref CustomData CD)
	{
		CD.CamID = Info.CamID;
		CD.RefIndex = Info.RefIndex;
		CD.OriginalEntityIndex = Info.OriginalEntityIndex;
		CD.Sequence = Info.Sequence;
		CD.DontUseForCalculation = Info.DontUseForCalculation;
		CD.CamSelectable = Info.CamSelectable;
		CD.CamSelected = Info.CamSelected;
		CD.Tags = Info.Tags;
		if (ShapeInfo != null)
		{
			CD.infoAngle = ShapeInfo.Angle;
			CD.infoBasePoint = new Point3D(ShapeInfo.BasePoint.X, ShapeInfo.BasePoint.Y, ShapeInfo.BasePoint.Z);
			CD.infoData = ShapeInfo.Data;
			CD.infoDegree = ShapeInfo.Degree;
			CD.infoDepth = ShapeInfo.Depth;
			CD.infoDirection = ShapeInfo.Direction;
			CD.infoHeadRadius = ShapeInfo.HeadRadius;
			CD.infoHeight = ShapeInfo.Height;
			CD.infoLength = ShapeInfo.Length;
			CD.infoRadius = ShapeInfo.Radius;
			CD.infoSide = ShapeInfo.Side;
			CD.infoString = ShapeInfo.String;
			CD.infoWidth = ShapeInfo.Width;
			CD.CurveType = ShapeInfo.CurveType;
		}
	}

	public static void CustomDataToEntityInfo(CustomData CD, ref EntityInfo Info, ref EntityShapeInfo ShapeInfo)
	{
		ShapeInfo = new EntityShapeInfo();
		Info = new EntityInfo();
		Info.CamID = CD.CamID;
		Info.RefIndex = CD.RefIndex;
		Info.OriginalEntityIndex = CD.OriginalEntityIndex;
		Info.Sequence = CD.Sequence;
		Info.DontUseForCalculation = CD.DontUseForCalculation;
		Info.CamSelectable = CD.CamSelectable;
		Info.CamSelected = CD.CamSelected;
		Info.Tags = CD.Tags;
		ShapeInfo.Angle = CD.infoAngle;
		if (CD.infoBasePoint != null)
		{
			ShapeInfo.BasePoint = new Point3D(CD.infoBasePoint.X, CD.infoBasePoint.Y, CD.infoBasePoint.Z);
		}
		ShapeInfo.Data = CD.infoData;
		ShapeInfo.Degree = CD.infoDegree;
		ShapeInfo.Depth = CD.infoDepth;
		ShapeInfo.Direction = CD.infoDirection;
		ShapeInfo.HeadRadius = CD.infoHeadRadius;
		ShapeInfo.Height = CD.infoHeight;
		ShapeInfo.Length = CD.infoLength;
		ShapeInfo.Radius = CD.infoRadius;
		ShapeInfo.Side = CD.infoSide;
		ShapeInfo.String = CD.infoString;
		ShapeInfo.Width = CD.infoWidth;
		ShapeInfo.CurveType = CD.CurveType;
	}

	public static void EyeCamEntityToEyeEntity(Entity CamEntity, ref Entity EyeEntity)
	{
		bool flag = false;
		if (!(CamEntity.GetType() == typeof(buLinearPathCam)))
		{
			if (!(CamEntity.GetType() == typeof(buLineCam)))
			{
				if (!(CamEntity.GetType() == typeof(buArcCam)))
				{
					if (CamEntity.GetType() == typeof(buCompositeCurveCam))
					{
						EyeEntity = new CompositeCurve(((buCompositeCurveCam)CamEntity).CurveList);
						flag = true;
					}
				}
				else
				{
					EyeEntity = new Arc(((buArcCam)CamEntity).Plane, ((buArcCam)CamEntity).Center, ((buArcCam)CamEntity).Radius, ((buArcCam)CamEntity).StartPoint, ((buArcCam)CamEntity).EndPoint, flip: false);
					flag = true;
				}
			}
			else
			{
				EyeEntity = new Line(CamEntity.Vertices[0], CamEntity.Vertices[1]);
				flag = true;
			}
		}
		else
		{
			EyeEntity = new LinearPath(CamEntity.Vertices);
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		if (CamEntity.EntityData != null)
		{
			if (CamEntity.EntityData.GetType() == typeof(CustomData))
			{
				EyeEntity.EntityData = new CustomData((CustomData)CamEntity.EntityData);
			}
		}
		else
		{
			EyeEntity.EntityData = new CustomData();
		}
	}

	public static void buEntityToEyeEntity(List<eEntities> buEntity, bool SetCurrentData, ref List<Entity> eyeEntity, List<LayerBase5> Layers, string SceneName)
	{
		eyeEntity.Clear();
		for (int i = 0; i <= buEntity.Count - 1; i++)
		{
			Entity eyeEntity2 = null;
			buEntityToEyeEntity(buEntity[i], SetCurrentData, i, ref eyeEntity2, Layers, SceneName);
			if (eyeEntity2 != null)
			{
				eyeEntity.Add(eyeEntity2);
			}
		}
	}

	public static void buEntityToEyeEntity(eEntities buEntity, bool SetCurrentData, int Index, ref Entity eyeEntity, List<LayerBase5> Layers, string SceneName)
	{
		try
		{
			if (buEntity.GetType() == typeof(eLine))
			{
				eyeEntity = new Line(Pnt3DToPoint3D(((eLine)buEntity).StartPoint), Pnt3DToPoint3D(((eLine)buEntity).EndPoint));
				eyeEntity.EntityData = new CustomData();
				((CustomData)((Line)eyeEntity).EntityData).SceneName = SceneName;
				((CustomData)((Line)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
				((CustomData)((Line)eyeEntity).EntityData).ActionName = "Line";
				((CustomData)((Line)eyeEntity).EntityData).infoLength = ((eLine)buEntity).geoLength;
				((CustomData)((Line)eyeEntity).EntityData).infoAngle = ((eLine)buEntity).geoAngleXY;
				EntityCommonProperties(ref eyeEntity, buEntity, Layers);
			}
			if (buEntity.GetType() == typeof(eArc))
			{
				if (!buCompare5.EQ(Math.Abs(((eArc)buEntity).EndAngle - ((eArc)buEntity).StartAngle), 360.0))
				{
					eyeEntity = new Arc(Pnt3DToPoint3D(((eArc)buEntity).StartPoint), Pnt3DToPoint3D(((eArc)buEntity).MiddlePoint), Pnt3DToPoint3D(((eArc)buEntity).EndPoint), flip: false);
					eyeEntity.EntityData = new CustomData();
					((CustomData)((Arc)eyeEntity).EntityData).SceneName = SceneName;
					((CustomData)((Arc)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
					((CustomData)((Arc)eyeEntity).EntityData).ActionName = "Arc";
					((Arc)eyeEntity).Regen(new RegenParams(buSystem.RegenDeviation));
					EntityCommonProperties(ref eyeEntity, buEntity, Layers);
				}
				else
				{
					eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((eArc)buEntity).Plane), Pnt3DToPoint3D(((eArc)buEntity).CenterPoint), ((eArc)buEntity).Radius);
					eyeEntity.EntityData = new CustomData();
					((CustomData)((Circle)eyeEntity).EntityData).SceneName = SceneName;
					((CustomData)((Circle)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
					((CustomData)((Circle)eyeEntity).EntityData).ActionName = "Circle";
					EntityCommonProperties(ref eyeEntity, buEntity, Layers);
				}
			}
			if (buEntity.GetType() == typeof(eCircle))
			{
				eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((eCircle)buEntity).Plane), Pnt3DToPoint3D(((eCircle)buEntity).CenterPoint), ((eCircle)buEntity).Radius);
				eyeEntity.EntityData = new CustomData();
				((CustomData)((Circle)eyeEntity).EntityData).SceneName = SceneName;
				((CustomData)((Circle)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
				((CustomData)((Circle)eyeEntity).EntityData).ActionName = "Circle";
				EntityCommonProperties(ref eyeEntity, buEntity, Layers);
			}
			if ((buEntity.GetType() == typeof(eEllipse)) | (buEntity.GetType() == typeof(eBSpline)) | (buEntity.GetType() == typeof(eBezeir)) | (buEntity.GetType() == typeof(ePolyline)))
			{
				eyeEntity = new LinearPath(Pnt3dToPoint3D(buEntity.Vertice));
				eyeEntity.EntityData = new CustomData();
				((CustomData)((LinearPath)eyeEntity).EntityData).SceneName = SceneName;
				((CustomData)((LinearPath)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
				((CustomData)((LinearPath)eyeEntity).EntityData).ActionName = "LinearPath";
				EntityCommonProperties(ref eyeEntity, buEntity, Layers);
			}
			if (buEntity.GetType() == typeof(ePoint))
			{
				eyeEntity = new devDept.Eyeshot.Entities.Point(Pnt3DToPoint3D(((ePoint)buEntity).StartPoint));
				eyeEntity.EntityData = new CustomData();
				((CustomData)((devDept.Eyeshot.Entities.Point)eyeEntity).EntityData).SceneName = SceneName;
				((CustomData)((devDept.Eyeshot.Entities.Point)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
				((CustomData)((devDept.Eyeshot.Entities.Point)eyeEntity).EntityData).ActionName = "Point";
				EntityCommonProperties(ref eyeEntity, buEntity, Layers);
			}
			if (buEntity.GetType() == typeof(eMesh))
			{
				eMesh eMesh2 = new eMesh(buEntity);
				List<Point3D> list = new List<Point3D>();
				List<IndexTriangle> list2 = new List<IndexTriangle>();
				for (int i = 0; i <= eMesh2.Vertice.Count - 1; i++)
				{
					list.Add(new Point3D(eMesh2.Vertice[i].X, eMesh2.Vertice[i].Y, eMesh2.Vertice[i].Z));
				}
				for (int j = 0; j <= eMesh2.TriIndex.Count - 1; j++)
				{
					list2.Add(new IndexTriangle(eMesh2.TriIndex[j].V1, eMesh2.TriIndex[j].V2, eMesh2.TriIndex[j].V3));
				}
				eyeEntity = new Mesh(list, list2);
				eyeEntity.EntityData = new CustomData();
				((Mesh)eyeEntity).NormalAveragingMode = Mesh.normalAveragingType.AveragedByAngle;
				((Mesh)eyeEntity).EdgeStyle = Mesh.edgeStyleType.Sharp;
				((Mesh)eyeEntity).ComputeEdges();
				((CustomData)((Mesh)eyeEntity).EntityData).SceneName = SceneName;
				((CustomData)((Mesh)eyeEntity).EntityData).EntityName = "Ent" + (Index + 1);
				((CustomData)((Mesh)eyeEntity).EntityData).ActionName = "Mesh";
				EntityCommonProperties(ref eyeEntity, eMesh2, Layers);
			}
			if (eyeEntity != null)
			{
				((CustomData)eyeEntity.EntityData).typeDefination = buEntity.TypeDefination;
			}
		}
		catch (Exception)
		{
		}
	}

	public static void geoEntityToEyeEntity(geoEntity geoEntity, ref Entity eyeEntity)
	{
		if (geoEntity.GetType() == typeof(geoLine))
		{
			eyeEntity = new Line(Pnt3DToPoint3D(((geoLine)geoEntity).StartPoint), Pnt3DToPoint3D(((geoLine)geoEntity).EndPoint));
			eyeEntity.EntityData = new CustomData();
			((CustomData)eyeEntity.EntityData).sortDirection = geoEntity.Direction;
			((CustomData)eyeEntity.EntityData).typeDefination = geoEntity.TypeDefination;
		}
		if (geoEntity.GetType() == typeof(geoArc))
		{
			if (!buCompare5.EQ(Math.Abs(((geoArc)geoEntity).EndAngle - ((geoArc)geoEntity).StartAngle), 360.0))
			{
				eyeEntity = new Arc(buVector5.WorkPlaneToPlane(((geoArc)geoEntity).Plane), Pnt3DToPoint3D(((geoArc)geoEntity).CenterPoint), ((geoArc)geoEntity).Radius, Utility.DegToRad(((geoArc)geoEntity).StartAngle), Utility.DegToRad(((geoArc)geoEntity).EndAngle));
				eyeEntity.EntityData = new CustomData();
			}
			else
			{
				eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((geoArc)geoEntity).Plane), Pnt3DToPoint3D(((geoArc)geoEntity).CenterPoint), ((geoArc)geoEntity).Radius);
				eyeEntity.EntityData = new CustomData();
			}
			((CustomData)eyeEntity.EntityData).sortDirection = geoEntity.Direction;
			((CustomData)eyeEntity.EntityData).typeDefination = geoEntity.TypeDefination;
		}
		if (geoEntity.GetType() == typeof(geoCircle))
		{
			eyeEntity = new Circle(buVector5.WorkPlaneToPlane(((geoCircle)geoEntity).Plane), Pnt3DToPoint3D(((geoCircle)geoEntity).CenterPoint), ((geoCircle)geoEntity).Radius);
			eyeEntity.EntityData = new CustomData();
			((CustomData)eyeEntity.EntityData).sortDirection = geoEntity.Direction;
			((CustomData)eyeEntity.EntityData).typeDefination = geoEntity.TypeDefination;
		}
		if ((geoEntity.GetType() == typeof(geoEllipse)) | (geoEntity.GetType() == typeof(geoBSpline)) | (geoEntity.GetType() == typeof(geoPolyline)))
		{
			eyeEntity = new LinearPath(Pnt3dToPoint3D(geoEntity.Vertice));
			eyeEntity.EntityData = new CustomData();
			((CustomData)eyeEntity.EntityData).sortDirection = geoEntity.Direction;
			((CustomData)eyeEntity.EntityData).typeDefination = geoEntity.TypeDefination;
		}
		if (geoEntity.GetType() == typeof(geoPoint))
		{
			eyeEntity = new devDept.Eyeshot.Entities.Point(Pnt3DToPoint3D(((geoPoint)geoEntity).StartPoint));
			eyeEntity.EntityData = new CustomData();
			((CustomData)eyeEntity.EntityData).sortDirection = geoEntity.Direction;
			((CustomData)eyeEntity.EntityData).typeDefination = geoEntity.TypeDefination;
		}
		if (eyeEntity != null && geoEntity != null)
		{
			eyeEntity.LayerName = geoEntity.LayerName;
		}
	}

	public static void geoEntityToEyeEntity(List<geoEntity> geoEntity, ref List<Entity> eyeEntity)
	{
		eyeEntity.Clear();
		for (int i = 0; i <= geoEntity.Count - 1; i++)
		{
			Entity eyeEntity2 = null;
			geoEntityToEyeEntity(geoEntity[i], ref eyeEntity2);
			if (eyeEntity2 != null)
			{
				eyeEntity.Add(eyeEntity2);
			}
		}
	}

	public static void geoEntityToEyeEntity(List<List<geoEntity>> geoEntity, ref List<List<Entity>> eyeEntity)
	{
		eyeEntity.Clear();
		for (int i = 0; i <= geoEntity.Count - 1; i++)
		{
			List<Entity> list = new List<Entity>();
			for (int j = 0; j <= geoEntity[i].Count - 1; j++)
			{
				Entity eyeEntity2 = null;
				geoEntityToEyeEntity(geoEntity[i][j], ref eyeEntity2);
				if (eyeEntity2 != null)
				{
					list.Add(eyeEntity2);
				}
			}
			if (list.Count > 0)
			{
				eyeEntity.Add(list);
			}
		}
	}

	public static void buEntityToEEntities(buEntity eyeEntity, Color color, ref eEntities buEntity)
	{
		try
		{
			eyeEntity.GetType().ToString();
			if (eyeEntity.GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				buEntity = new ePoint(Point3DToPnt3D(((buPoint)eyeEntity).StartPoint));
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buCurve))
			{
				List<Pnt3D> list = new List<Pnt3D>();
				for (int i = 0; i <= ((buCurve)eyeEntity).Vertices.Count - 1; i++)
				{
					list.Add(new Pnt3D(((buCurve)eyeEntity).Vertices[i].X, ((buCurve)eyeEntity).Vertices[i].Y, ((buCurve)eyeEntity).Vertices[i].Z));
				}
				buEntity = new ePolyline(list);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buCompositeCurve))
			{
				List<Pnt3D> list2 = new List<Pnt3D>();
				for (int j = 0; j <= ((buCompositeCurve)eyeEntity).Vertices.Count - 1; j++)
				{
					list2.Add(new Pnt3D(((buCompositeCurve)eyeEntity).Vertices[j].X, ((buCompositeCurve)eyeEntity).Vertices[j].Y, ((buCompositeCurve)eyeEntity).Vertices[j].Z));
				}
				buEntity = new ePolyline(list2);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buLine))
			{
				buEntity = new eLine(Point3DToPnt3D(((buLine)eyeEntity).StartPoint), Point3DToPnt3D(((buLine)eyeEntity).EndPoint));
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buArc))
			{
				buEntity = new eArc(Point3DToPnt3D(((buArc)eyeEntity).StartPoint), Point3DToPnt3D(((buArc)eyeEntity).MiddlePoint), Point3DToPnt3D(((buArc)eyeEntity).EndPoint), new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buCircle))
			{
				buEntity = new eCircle(Point3DToPnt3D(((buCircle)eyeEntity).Center), ((buCircle)eyeEntity).Radius, new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buLinearPath))
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Point3DToPnt3D(((buLinearPath)eyeEntity).Vertices, ref CopiedPnt);
				buEntity = new ePolyline(CopiedPnt);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buText))
			{
				buEntity = new eText(Point3DToPnt3D(((buText)eyeEntity).Plane.Origin), ((buText)eyeEntity).TextString, ((buText)eyeEntity).Height, new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = (float)eyeEntity.Thickness;
			}
			if (eyeEntity.GetType() == typeof(buMesh))
			{
				List<TriangleIndex> list3 = new List<TriangleIndex>();
				for (int k = 0; k <= ((buMesh)eyeEntity).Triangles.Count - 1; k++)
				{
					int v = int.Parse(((buMesh)eyeEntity).Triangles[k].V1.ToString());
					int v2 = int.Parse(((buMesh)eyeEntity).Triangles[k].V2.ToString());
					int v3 = int.Parse(((buMesh)eyeEntity).Triangles[k].V3.ToString());
					TriangleIndex triangleIndex = new TriangleIndex();
					triangleIndex.V1 = v;
					triangleIndex.V2 = v2;
					triangleIndex.V3 = v3;
					list3.Add(triangleIndex);
				}
				List<Pnt3D> list4 = new List<Pnt3D>();
				for (int l = 0; l <= ((buMesh)eyeEntity).Vertices.Count - 1; l++)
				{
					Pnt3D item = new Pnt3D(((buMesh)eyeEntity).Vertices[l].X, ((buMesh)eyeEntity).Vertices[l].Y, ((buMesh)eyeEntity).Vertices[l].Z);
					list4.Add(item);
				}
				buEntity = new eMesh(list3, list4, color);
				if (eyeEntity.BoxMax != null)
				{
					buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMax.X, eyeEntity.BoxMax.Y, eyeEntity.BoxMax.Z);
				}
				if (eyeEntity.BoxMin != null)
				{
					buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMin.X, eyeEntity.BoxMin.Y, eyeEntity.BoxMin.Z);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void buEntityGroupToEEntities(buEntitiesGroup EntGroup, ref List<eEntities> copiedEntity, bool Inside = true, bool OpenEntities = true, bool Solid = false, bool Text = false)
	{
		copiedEntity.Clear();
		if (EntGroup.Outside.Entities.Count > 0)
		{
			for (int i = 0; i <= EntGroup.Outside.Entities.Count - 1; i++)
			{
				eEntities eEntities2 = null;
				buEntityToEEntities(EntGroup.Outside.Entities[i], EntGroup.Outside.Entities[i].Color, ref eEntities2);
				if (eEntities2 != null)
				{
					copiedEntity.Add(eEntities2);
				}
			}
		}
		if (EntGroup.Inside != null && EntGroup.Inside.Count > 0 && Inside)
		{
			for (int j = 0; j <= EntGroup.Inside.Count - 1; j++)
			{
				for (int k = 0; k <= EntGroup.Inside[j].Entities.Count - 1; k++)
				{
					eEntities eEntities3 = null;
					buEntityToEEntities(EntGroup.Inside[j].Entities[k], EntGroup.Inside[j].Entities[k].Color, ref eEntities3);
					if (eEntities3 != null)
					{
						copiedEntity.Add(eEntities3);
					}
				}
			}
		}
		if (EntGroup.OpenEntities == null || !(EntGroup.OpenEntities.Count > 0 && OpenEntities))
		{
			return;
		}
		for (int l = 0; l <= EntGroup.OpenEntities.Count - 1; l++)
		{
			for (int m = 0; m <= EntGroup.OpenEntities[l].Entities.Count - 1; m++)
			{
				eEntities eEntities4 = null;
				buEntityToEEntities(EntGroup.OpenEntities[l].Entities[m], EntGroup.OpenEntities[l].Entities[m].Color, ref eEntities4);
				if (eEntities4 != null)
				{
					copiedEntity.Add(eEntities4);
				}
			}
		}
	}

	public static void eyeEntityToEEntities(Entity eyeEntity, Color color, ref eEntities buEntity)
	{
		try
		{
			eyeEntity.GetType().ToString();
			if (eyeEntity.GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				buEntity = new ePoint(Point3DToPnt3D(((devDept.Eyeshot.Entities.Point)eyeEntity).StartPoint));
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Curve))
			{
				eyeEntity.Regen(0.01);
				List<Pnt3D> list = new List<Pnt3D>();
				for (int i = 0; i <= ((Curve)eyeEntity).Vertices.Length - 1; i++)
				{
					list.Add(new Pnt3D(((Curve)eyeEntity).Vertices[i].X, ((Curve)eyeEntity).Vertices[i].Y, ((Curve)eyeEntity).Vertices[i].Z));
				}
				buEntity = new ePolyline(list);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(CompositeCurve))
			{
				eyeEntity.Regen(0.01);
				List<Pnt3D> list2 = new List<Pnt3D>();
				for (int j = 0; j <= ((CompositeCurve)eyeEntity).Vertices.Length - 1; j++)
				{
					list2.Add(new Pnt3D(((CompositeCurve)eyeEntity).Vertices[j].X, ((CompositeCurve)eyeEntity).Vertices[j].Y, ((CompositeCurve)eyeEntity).Vertices[j].Z));
				}
				buEntity = new ePolyline(list2);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Line))
			{
				buEntity = new eLine(Point3DToPnt3D(((Line)eyeEntity).StartPoint), Point3DToPnt3D(((Line)eyeEntity).EndPoint));
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Arc))
			{
				buEntity = new eArc(Point3DToPnt3D(((Arc)eyeEntity).StartPoint), Point3DToPnt3D(((Arc)eyeEntity).MidPoint), Point3DToPnt3D(((Arc)eyeEntity).EndPoint), new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Circle))
			{
				buEntity = new eCircle(Point3DToPnt3D(((Circle)eyeEntity).Center), ((Circle)eyeEntity).Radius, new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPath))
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPath)eyeEntity).Vertices, ref CopiedPnt);
				buEntity = new ePolyline(CopiedPnt);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPathEx))
			{
				List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPathEx)eyeEntity).Vertices, ref CopiedPnt2);
				buEntity = new ePolyline(CopiedPnt2);
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Text))
			{
				buEntity = new eText(Point3DToPnt3D(((Text)eyeEntity).Plane.Origin), ((Text)eyeEntity).TextString, ((Text)eyeEntity).Height, new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(MultilineText))
			{
				string textString_ = ((Text)eyeEntity).TextString.Replace("\r\n", " ");
				buEntity = new eText(Point3DToPnt3D(((Text)eyeEntity).Plane.Origin), textString_, ((Text)eyeEntity).Height, new WorkPlane());
				buEntity.dispColor = eyeEntity.Color;
				buEntity.dispThickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Mesh))
			{
				List<TriangleIndex> list3 = new List<TriangleIndex>();
				for (int k = 0; k <= ((Mesh)eyeEntity).Triangles.Length - 1; k++)
				{
					int v = int.Parse(((Mesh)eyeEntity).Triangles[k].V1.ToString());
					int v2 = int.Parse(((Mesh)eyeEntity).Triangles[k].V2.ToString());
					int v3 = int.Parse(((Mesh)eyeEntity).Triangles[k].V3.ToString());
					TriangleIndex triangleIndex = new TriangleIndex();
					triangleIndex.V1 = v;
					triangleIndex.V2 = v2;
					triangleIndex.V3 = v3;
					list3.Add(triangleIndex);
				}
				List<Pnt3D> list4 = new List<Pnt3D>();
				for (int l = 0; l <= ((Mesh)eyeEntity).Vertices.Length - 1; l++)
				{
					Pnt3D item = new Pnt3D(((Mesh)eyeEntity).Vertices[l].X, ((Mesh)eyeEntity).Vertices[l].Y, ((Mesh)eyeEntity).Vertices[l].Z);
					list4.Add(item);
				}
				buEntity = new eMesh(list3, list4, color);
				if (eyeEntity.BoxMax == null)
				{
					eyeEntity.Regen(0.01);
				}
				if (eyeEntity.BoxMax != null)
				{
					buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMax.X, eyeEntity.BoxMax.Y, eyeEntity.BoxMax.Z);
				}
				if (eyeEntity.BoxMin != null)
				{
					buEntity.geoMaxPoint = new Pnt3D(eyeEntity.BoxMin.X, eyeEntity.BoxMin.Y, eyeEntity.BoxMin.Z);
				}
			}
			if (eyeEntity.GetType() == typeof(Solid))
			{
				buEntity = new eSolid3D();
			}
			if (!(eyeEntity.GetType() == typeof(devDept.Eyeshot.Entities.Region)))
			{
				return;
			}
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region();
			region = (devDept.Eyeshot.Entities.Region)eyeEntity;
			if (region.ContourList.Count > 0)
			{
				for (int m = 0; m <= region.ContourList.Count - 1; m++)
				{
					CompositeCurve compositeCurve = new CompositeCurve();
					compositeCurve = (CompositeCurve)region.ContourList[m];
					List<Pnt3D> list5 = new List<Pnt3D>();
					for (int n = 0; n <= compositeCurve.CurveList.Count - 1; n++)
					{
						Entity entity = null;
						entity = (Entity)compositeCurve.CurveList[n];
						entity.Regen(0.01);
						if (entity.Vertices != null)
						{
							for (int num = 0; num <= entity.Vertices.Length - 1; num++)
							{
								list5.Add(new Pnt3D(entity.Vertices[num].X, entity.Vertices[num].Y, entity.Vertices[num].Z));
							}
						}
					}
				}
			}
			eyeEntity.Regen(0.01);
			if (eyeEntity.EntityData != null && eyeEntity.EntityData is CustomData)
			{
				buEntity.TypeDefination = ((CustomData)eyeEntity.EntityData).typeDefination;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void eyeEntityToEEntities(List<Entity> eyeEntity, Color color, ref List<eEntities> buEntity)
	{
		buEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			eEntities eEntities2 = null;
			eyeEntityToEEntities(eyeEntity[i], color, ref eEntities2);
			if (eEntities2 != null)
			{
				buEntity.Add(eEntities2);
			}
		}
	}

	public static void eyeEntityToEEntities(List<List<Entity>> eyeEntity, Color color, ref List<List<eEntities>> buEntity)
	{
		buEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			List<eEntities> list = new List<eEntities>();
			for (int j = 0; j <= eyeEntity[i].Count - 1; j++)
			{
				eEntities eEntities2 = null;
				eyeEntityToEEntities(eyeEntity[i][j], color, ref eEntities2);
				if (eEntities2 != null)
				{
					list.Add(eEntities2);
				}
			}
			if (list.Count > 0)
			{
				buEntity.Add(list);
			}
		}
	}

	public static void eyeEntityTogeoEntities(Entity eyeEntity, Color color, List<LayerBase5> Layers, ref geoEntity geoEntity)
	{
		try
		{
			eyeEntity.GetType().ToString();
			if (eyeEntity.GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				geoEntity = new geoPoint(Point3DToPnt3D(((devDept.Eyeshot.Entities.Point)eyeEntity).StartPoint));
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Line))
			{
				geoEntity = new geoLine(Point3DToPnt3D(((Line)eyeEntity).StartPoint), Point3DToPnt3D(((Line)eyeEntity).EndPoint));
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
				if (eyeEntity.EntityData != null)
				{
					geoEntity.Direction = ((CustomData)eyeEntity.EntityData).sortDirection;
				}
			}
			if (eyeEntity.GetType() == typeof(Arc))
			{
				geoEntity = new geoArc(Point3DToPnt3D(((Arc)eyeEntity).StartPoint), Point3DToPnt3D(((Arc)eyeEntity).MidPoint), Point3DToPnt3D(((Arc)eyeEntity).EndPoint), new WorkPlane());
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Circle))
			{
				geoEntity = new geoCircle(Point3DToPnt3D(((Circle)eyeEntity).Center), ((Circle)eyeEntity).Radius, new WorkPlane());
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPath))
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPath)eyeEntity).Vertices, ref CopiedPnt);
				geoEntity = new geoPolyline(CopiedPnt);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(CompositeCurve))
			{
				if (eyeEntity.Vertices == null)
				{
					eyeEntity.Regen(new RegenParams(0.001));
				}
				List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
				Point3DToPnt3D(((CompositeCurve)eyeEntity).Vertices, ref CopiedPnt2);
				geoEntity = new geoPolyline(CopiedPnt2);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Curve))
			{
				if (eyeEntity.Vertices == null)
				{
					eyeEntity.Regen(new RegenParams(0.001));
				}
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				Point3DToPnt3D(((Curve)eyeEntity).Vertices, ref CopiedPnt3);
				geoEntity = new geoPolyline(CopiedPnt3);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPathEx))
			{
				List<Pnt3D> CopiedPnt4 = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPathEx)eyeEntity).Vertices, ref CopiedPnt4);
				geoEntity = new geoPolyline(CopiedPnt4);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (geoEntity == null)
			{
				return;
			}
			geoEntity.LayerName = eyeEntity.LayerName;
			for (int i = 0; i <= Layers.Count - 1; i++)
			{
				if (geoEntity.LayerName == Layers[i].Name)
				{
					geoEntity.ToolName = Layers[i].ToolSelected.Data.Name;
					if (eyeEntity.ColorMethod == colorMethodType.byLayer)
					{
						geoEntity.Color = Layers[i].LayerColor;
					}
				}
			}
			if (eyeEntity.EntityData != null)
			{
				geoEntity.Direction = ((CustomData)eyeEntity.EntityData).sortDirection;
				geoEntity.TypeDefination = ((CustomData)eyeEntity.EntityData).typeDefination;
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void eyeEntityTogeoEntities(Entity eyeEntity, Color color, ref geoEntity geoEntity)
	{
		try
		{
			eyeEntity.GetType().ToString();
			if (eyeEntity.GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				geoEntity = new geoPoint(Point3DToPnt3D(((devDept.Eyeshot.Entities.Point)eyeEntity).StartPoint));
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Line))
			{
				geoEntity = new geoLine(Point3DToPnt3D(((Line)eyeEntity).StartPoint), Point3DToPnt3D(((Line)eyeEntity).EndPoint));
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
				if (eyeEntity.EntityData != null)
				{
					geoEntity.Direction = ((CustomData)eyeEntity.EntityData).sortDirection;
				}
			}
			if (eyeEntity.GetType() == typeof(Arc))
			{
				geoEntity = new geoArc(Point3DToPnt3D(((Arc)eyeEntity).StartPoint), Point3DToPnt3D(((Arc)eyeEntity).MidPoint), Point3DToPnt3D(((Arc)eyeEntity).EndPoint), new WorkPlane());
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Circle))
			{
				geoEntity = new geoCircle(Point3DToPnt3D(((Circle)eyeEntity).Center), ((Circle)eyeEntity).Radius, new WorkPlane());
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPath))
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPath)eyeEntity).Vertices, ref CopiedPnt);
				geoEntity = new geoPolyline(CopiedPnt);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(CompositeCurve))
			{
				if (eyeEntity.Vertices == null)
				{
					eyeEntity.Regen(new RegenParams(0.001));
				}
				List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
				Point3DToPnt3D(((CompositeCurve)eyeEntity).Vertices, ref CopiedPnt2);
				geoEntity = new geoPolyline(CopiedPnt2);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(Curve))
			{
				if (eyeEntity.Vertices == null)
				{
					eyeEntity.Regen(new RegenParams(0.001));
				}
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				Point3DToPnt3D(((Curve)eyeEntity).Vertices, ref CopiedPnt3);
				geoEntity = new geoPolyline(CopiedPnt3);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (eyeEntity.GetType() == typeof(LinearPathEx))
			{
				List<Pnt3D> CopiedPnt4 = new List<Pnt3D>();
				Point3DToPnt3D(((LinearPathEx)eyeEntity).Vertices, ref CopiedPnt4);
				geoEntity = new geoPolyline(CopiedPnt4);
				geoEntity.Color = eyeEntity.Color;
				geoEntity.Thickness = eyeEntity.LineWeight;
			}
			if (geoEntity != null)
			{
				geoEntity.LayerName = eyeEntity.LayerName;
				if (eyeEntity.EntityData != null)
				{
					geoEntity.Direction = ((CustomData)eyeEntity.EntityData).sortDirection;
					geoEntity.TypeDefination = ((CustomData)eyeEntity.EntityData).typeDefination;
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public static void eyeEntityTogeoEntities(List<Entity> eyeEntity, Color color, ref List<geoEntity> geoEntity)
	{
		geoEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			geoEntity geoEntity2 = null;
			eyeEntityTogeoEntities(eyeEntity[i], color, ref geoEntity2);
			if (geoEntity2 != null)
			{
				geoEntity.Add(geoEntity2);
			}
		}
	}

	public static void eyeEntityTogeoEntities(List<Entity> eyeEntity, Color color, List<LayerBase5> Layers, ref List<geoEntity> geoEntity)
	{
		geoEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			geoEntity geoEntity2 = null;
			eyeEntityTogeoEntities(eyeEntity[i], color, Layers, ref geoEntity2);
			if (geoEntity2 != null)
			{
				geoEntity.Add(geoEntity2);
			}
		}
	}

	public static void eyeEntityTogeoEntities(List<List<Entity>> eyeEntity, Color color, ref List<List<geoEntity>> geoEntity)
	{
		geoEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			List<geoEntity> list = new List<geoEntity>();
			for (int j = 0; j <= eyeEntity[i].Count - 1; j++)
			{
				geoEntity geoEntity2 = null;
				eyeEntityTogeoEntities(eyeEntity[i][j], color, ref geoEntity2);
				if (geoEntity2 != null)
				{
					list.Add(geoEntity2);
				}
			}
			if (list.Count > 0)
			{
				geoEntity.Add(list);
			}
		}
	}

	public static void eyeEntityTogeoEntities(List<List<Entity>> eyeEntity, Color color, List<LayerBase5> Layers, ref List<List<geoEntity>> geoEntity)
	{
		geoEntity.Clear();
		for (int i = 0; i <= eyeEntity.Count - 1; i++)
		{
			List<geoEntity> list = new List<geoEntity>();
			for (int j = 0; j <= eyeEntity[i].Count - 1; j++)
			{
				geoEntity geoEntity2 = null;
				eyeEntityTogeoEntities(eyeEntity[i][j], color, Layers, ref geoEntity2);
				if (geoEntity2 != null)
				{
					list.Add(geoEntity2);
				}
			}
			if (list.Count > 0)
			{
				geoEntity.Add(list);
			}
		}
	}

	public static void EntityCommonProperties(ref Entity eyeEntity, eEntities cadEntity, List<LayerBase5> Layers)
	{
		eyeEntity.ColorMethod = colorMethodType.byLayer;
		eyeEntity.LineWeightMethod = colorMethodType.byLayer;
		eyeEntity.LineTypeMethod = colorMethodType.byLayer;
		eyeEntity.Color = cadEntity.dispColor;
		eyeEntity.LineWeight = cadEntity.dispThickness;
		if (cadEntity.LayerIndex < 0)
		{
			cadEntity.LayerIndex = 0;
		}
		if ((cadEntity.LayerIndex >= 0) & (cadEntity.LayerIndex <= Layers.Count - 1))
		{
			eyeEntity.LayerName = Layers[cadEntity.LayerIndex].Name;
		}
		if (eyeEntity.EntityData != null && eyeEntity.EntityData is CustomData)
		{
			((CustomData)eyeEntity.EntityData).typeDefination = cadEntity.TypeDefination;
		}
	}

	public static ObjectAlignment CornerLocationToObjectAlignment(CornerLocation Location)
	{
		ObjectAlignment result = ObjectAlignment.BottomCenter;
		if (Location == CornerLocation.RightBottom)
		{
			result = ObjectAlignment.BottomRight;
		}
		if (Location == CornerLocation.RightCenter)
		{
			result = ObjectAlignment.MiddleRight;
		}
		if (Location == CornerLocation.RightTop)
		{
			result = ObjectAlignment.TopRight;
		}
		if (Location == CornerLocation.LeftBottom)
		{
			result = ObjectAlignment.BottomLeft;
		}
		if (Location == CornerLocation.LeftCenter)
		{
			result = ObjectAlignment.MiddleLeft;
		}
		if (Location == CornerLocation.LeftTop)
		{
			result = ObjectAlignment.TopLeft;
		}
		if (Location == CornerLocation.TopCenter)
		{
			result = ObjectAlignment.TopCenter;
		}
		if (Location == CornerLocation.BottomCenter)
		{
			result = ObjectAlignment.BottomCenter;
		}
		return result;
	}

	public static Color BoolToColor(bool State, Color OnColor, Color OffColor)
	{
		if (!State)
		{
			return OffColor;
		}
		return OnColor;
	}

	public static bool StringToBool(string Value)
	{
		try
		{
			if (!((Value.Trim() == "1") | (Value.Trim().ToLower() == "true")))
			{
				return false;
			}
			return true;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static double StringToDouble(string Value)
	{
		try
		{
			double result = 0.0;
			if (buNumeric5.IsNumeric(Value))
			{
				result = double.Parse(Value);
			}
			return result;
		}
		catch (Exception)
		{
			return 0.0;
		}
	}

	public static int StringToInt(string Value)
	{
		try
		{
			int result = 0;
			if (buNumeric5.IsNumeric(Value))
			{
				result = int.Parse(Value);
			}
			return result;
		}
		catch (Exception)
		{
			return 0;
		}
	}

	public static float StringToFloat(string Value)
	{
		try
		{
			float result = 0f;
			if (buNumeric5.IsNumeric(Value))
			{
				result = float.Parse(Value);
			}
			return result;
		}
		catch (Exception)
		{
			return 0f;
		}
	}

	public static bool IntToBool(int Value)
	{
		try
		{
			if (Value != 0)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool DoubleToBool(double Value)
	{
		try
		{
			if (Value != 0.0)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static bool FloatToBool(float Value)
	{
		try
		{
			if (Value != 0f)
			{
				return true;
			}
			return false;
		}
		catch (Exception)
		{
			return true;
		}
	}

	public static string ColorToString(Color clr, ColorConvertType Type)
	{
		try
		{
			if (Type != ColorConvertType.Html)
			{
				return clr.ToString();
			}
			return ColorTranslator.ToHtml(clr);
		}
		catch (Exception)
		{
			return "Black";
		}
	}

	public static string FontToString(Font fnt)
	{
		try
		{
			FontConverter fontConverter = new FontConverter();
			return fontConverter.ConvertToString(fnt);
		}
		catch (Exception)
		{
			Font value = new Font("Arial", 10f);
			FontConverter fontConverter2 = new FontConverter();
			return fontConverter2.ConvertToString(value);
		}
	}

	public static Color StringToColor(string Code, ColorConvertType Type)
	{
		Color color = default(Color);
		color = Color.Black;
		try
		{
			if (Type != ColorConvertType.Html)
			{
				Code = Code.Replace("Color", "");
				Code = Code.Replace("[", "");
				Code = Code.Replace("]", "");
				Code = Code.Trim();
				Color.FromName(Code);
				return Color.FromName(Code);
			}
			return ColorTranslator.FromHtml(Code);
		}
		catch (Exception)
		{
			return Color.Black;
		}
	}

	public static Font StringToFont(string Code)
	{
		Font result = new Font("Arial", 10f);
		try
		{
			FontConverter fontConverter = new FontConverter();
			result = fontConverter.ConvertFromString(Code) as Font;
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static List<string> EnumToString(Type enumVal)
	{
		List<string> list = new List<string>();
		Array values = Enum.GetValues(enumVal);
		if (values != null)
		{
			for (int i = 0; i <= values.Length - 1; i++)
			{
				list.Add(values.GetValue(i).ToString());
			}
		}
		return list;
	}

	public static displayType DisplayModeConvert(DisplayModeType displayMode)
	{
		return displayMode switch
		{
			DisplayModeType.Shaded => displayType.Shaded, 
			DisplayModeType.Flat => displayType.Flat, 
			DisplayModeType.Wireframe => displayType.Wireframe, 
			DisplayModeType.HiddenLines => displayType.HiddenLines, 
			_ => displayType.Rendered, 
		};
	}

	public static DisplayModeType DisplayModeConvert(displayType displayMode)
	{
		return displayMode switch
		{
			displayType.Shaded => DisplayModeType.Shaded, 
			displayType.Flat => DisplayModeType.Flat, 
			displayType.Wireframe => DisplayModeType.Wireframe, 
			displayType.HiddenLines => DisplayModeType.HiddenLines, 
			_ => DisplayModeType.Rendered, 
		};
	}

	public static projectionType ProjectionTypeConvert(ProjectionModeType ProjectionMode)
	{
		if (ProjectionMode != ProjectionModeType.Orthographic)
		{
			return projectionType.Perspective;
		}
		return projectionType.Orthographic;
	}

	public static ProjectionModeType ProjectionTypeConvert(projectionType ProjectionMode)
	{
		if (ProjectionMode != projectionType.Orthographic)
		{
			return ProjectionModeType.Perspective;
		}
		return ProjectionModeType.Orthographic;
	}

	public static originSymbolStyleType OrigineIconConvert(OriginIconType OrigineIconType)
	{
		if (OrigineIconType != OriginIconType.Ball)
		{
			return originSymbolStyleType.CoordinateSystem;
		}
		return originSymbolStyleType.Ball;
	}

	public static OriginIconType OrigineIconConvert(originSymbolStyleType OrigineIconType)
	{
		if (OrigineIconType != originSymbolStyleType.Ball)
		{
			return OriginIconType.CoordinateSystem;
		}
		return OriginIconType.Ball;
	}

	public static mouseButtonsZPR MouseButtonConvert(mouseButtons Buttons)
	{
		return Buttons switch
		{
			mouseButtons.Left => mouseButtonsZPR.Left, 
			mouseButtons.LeftMiddle => mouseButtonsZPR.LeftMiddle, 
			mouseButtons.LeftMiddleRight => mouseButtonsZPR.LeftMiddleRight, 
			mouseButtons.LeftRight => mouseButtonsZPR.LeftRight, 
			mouseButtons.Middle => mouseButtonsZPR.Middle, 
			mouseButtons.MiddleRight => mouseButtonsZPR.MiddleRight, 
			mouseButtons.Right => mouseButtonsZPR.Right, 
			mouseButtons.XButton1 => mouseButtonsZPR.XButton1, 
			mouseButtons.XButton2 => mouseButtonsZPR.XButton2, 
			_ => mouseButtonsZPR.None, 
		};
	}

	public static devDept.Eyeshot.Control.modifierKeys ModifierKeyConvert(buClass.modifierKeys Keys)
	{
		return Keys switch
		{
			buClass.modifierKeys.Alt => devDept.Eyeshot.Control.modifierKeys.Alt, 
			buClass.modifierKeys.Ctrl => devDept.Eyeshot.Control.modifierKeys.Ctrl, 
			buClass.modifierKeys.CtrlAlt => devDept.Eyeshot.Control.modifierKeys.CtrlAlt, 
			buClass.modifierKeys.CtrlShift => devDept.Eyeshot.Control.modifierKeys.CtrlShift, 
			buClass.modifierKeys.CtrlShiftAlt => devDept.Eyeshot.Control.modifierKeys.CtrlShiftAlt, 
			buClass.modifierKeys.Shift => devDept.Eyeshot.Control.modifierKeys.Shift, 
			buClass.modifierKeys.ShiftAlt => devDept.Eyeshot.Control.modifierKeys.ShiftAlt, 
			_ => devDept.Eyeshot.Control.modifierKeys.None, 
		};
	}

	public static planeNames PlaneBoxNamesToPlaneNames(planeBoxNames Plane)
	{
		return (planeNames)Convert.ToInt32(Plane);
	}

	public static planeBoxNames PlaneNamesToPlaneBoxNames(planeNames Plane)
	{
		return (planeBoxNames)Convert.ToInt32(Plane);
	}

	public static ClockDirectionType ChangeClockDirection(ClockDirectionType Dir)
	{
		if (Dir != ClockDirectionType.CCW)
		{
			return ClockDirectionType.CCW;
		}
		return ClockDirectionType.CW;
	}

	public static double KeyCodeNumberToDouble(Keys Key)
	{
		return Key switch
		{
			Keys.D0 => 0.0, 
			Keys.D1 => 1.0, 
			Keys.D2 => 2.0, 
			Keys.D3 => 3.0, 
			Keys.D4 => 4.0, 
			Keys.D5 => 5.0, 
			Keys.D6 => 6.0, 
			Keys.D7 => 8.0, 
			Keys.D8 => 8.0, 
			Keys.D9 => 9.0, 
			_ => 0.0, 
		};
	}

	public static Text.alignmentType buAligntoEyeAlign(ContentAlignment Align)
	{
		switch (Align)
		{
		default:
			if (Align != ContentAlignment.BottomCenter)
			{
				return Text.alignmentType.MiddleLeft;
			}
			return Text.alignmentType.BottomCenter;
		case ContentAlignment.BottomLeft:
			return Text.alignmentType.BottomLeft;
		case ContentAlignment.BottomCenter:
			return Text.alignmentType.BottomCenter;
		case ContentAlignment.BottomRight:
			return Text.alignmentType.BottomRight;
		case ContentAlignment.MiddleCenter:
			return Text.alignmentType.MiddleCenter;
		case ContentAlignment.MiddleLeft:
			return Text.alignmentType.MiddleLeft;
		case ContentAlignment.MiddleRight:
			return Text.alignmentType.MiddleRight;
		case ContentAlignment.TopCenter:
			return Text.alignmentType.TopCenter;
		case ContentAlignment.TopLeft:
			return Text.alignmentType.TopLeft;
		case ContentAlignment.TopRight:
			return Text.alignmentType.TopRight;
		}
	}

	public static ContentAlignment eyeAligntoBuAlign(Text.alignmentType Align)
	{
		switch (Align)
		{
		default:
			if (Align != Text.alignmentType.BottomCenter)
			{
				return ContentAlignment.MiddleLeft;
			}
			return ContentAlignment.BottomCenter;
		case Text.alignmentType.BottomLeft:
			return ContentAlignment.BottomLeft;
		case Text.alignmentType.BottomCenter:
			return ContentAlignment.BottomCenter;
		case Text.alignmentType.BottomRight:
			return ContentAlignment.BottomRight;
		case Text.alignmentType.MiddleCenter:
			return ContentAlignment.MiddleCenter;
		case Text.alignmentType.MiddleLeft:
			return ContentAlignment.MiddleLeft;
		case Text.alignmentType.MiddleRight:
			return ContentAlignment.MiddleRight;
		case Text.alignmentType.TopCenter:
			return ContentAlignment.TopCenter;
		case Text.alignmentType.TopLeft:
			return ContentAlignment.TopLeft;
		case Text.alignmentType.TopRight:
			return ContentAlignment.TopRight;
		}
	}

	public static viewType buViewTypeToEyeViewType(ViewportViewType View)
	{
		return View switch
		{
			ViewportViewType.Top => viewType.Top, 
			ViewportViewType.Trimetric => viewType.Trimetric, 
			ViewportViewType.Front => viewType.Front, 
			ViewportViewType.Back => viewType.Rear, 
			ViewportViewType.Left => viewType.Left, 
			ViewportViewType.Right => viewType.Right, 
			ViewportViewType.Bottom => viewType.Bottom, 
			ViewportViewType.Isometric => viewType.Isometric, 
			_ => viewType.Top, 
		};
	}

	public static mouseButtonsZPR MouseButtonConv(mouseButtons Button)
	{
		return Button switch
		{
			mouseButtons.Left => mouseButtonsZPR.Left, 
			mouseButtons.LeftMiddle => mouseButtonsZPR.LeftMiddle, 
			mouseButtons.LeftMiddleRight => mouseButtonsZPR.LeftMiddleRight, 
			mouseButtons.LeftRight => mouseButtonsZPR.LeftRight, 
			mouseButtons.Middle => mouseButtonsZPR.Middle, 
			mouseButtons.MiddleRight => mouseButtonsZPR.MiddleRight, 
			mouseButtons.None => mouseButtonsZPR.None, 
			mouseButtons.Right => mouseButtonsZPR.Right, 
			mouseButtons.XButton1 => mouseButtonsZPR.XButton1, 
			mouseButtons.XButton2 => mouseButtonsZPR.XButton2, 
			_ => mouseButtonsZPR.None, 
		};
	}

	public static devDept.Eyeshot.Control.modifierKeys KeyConv(buClass.modifierKeys Key)
	{
		return Key switch
		{
			buClass.modifierKeys.Alt => devDept.Eyeshot.Control.modifierKeys.Alt, 
			buClass.modifierKeys.Ctrl => devDept.Eyeshot.Control.modifierKeys.Ctrl, 
			buClass.modifierKeys.CtrlAlt => devDept.Eyeshot.Control.modifierKeys.CtrlAlt, 
			buClass.modifierKeys.CtrlShift => devDept.Eyeshot.Control.modifierKeys.CtrlShift, 
			buClass.modifierKeys.CtrlShiftAlt => devDept.Eyeshot.Control.modifierKeys.CtrlShiftAlt, 
			buClass.modifierKeys.None => devDept.Eyeshot.Control.modifierKeys.None, 
			buClass.modifierKeys.Shift => devDept.Eyeshot.Control.modifierKeys.Shift, 
			buClass.modifierKeys.ShiftAlt => devDept.Eyeshot.Control.modifierKeys.ShiftAlt, 
			_ => devDept.Eyeshot.Control.modifierKeys.None, 
		};
	}

	public static void eyeLayerTobuLayer(Layer eyeLayer, ref LayerBase5 buLayer)
	{
		buLayer = new LayerBase5
		{
			Name = eyeLayer.Name,
			Enable = eyeLayer.Visible,
			LayerColor = Color.FromArgb(255, eyeLayer.Color),
			LayerThickness = eyeLayer.LineWeight,
			MaterialName = eyeLayer.MaterialName,
			Lock = eyeLayer.Locked,
			LayerPurposes = LayerPurpose.General
		};
		buLayer.Transparency = eyeLayer.Color.A;
	}

	public static void buLayerToeyeLayer(LayerBase5 buLayer, ref Layer eyeLayer)
	{
		eyeLayer = new Layer(buLayer.Name)
		{
			Name = buLayer.Name,
			Visible = buLayer.Enable,
			LineWeight = buLayer.LayerThickness,
			MaterialName = buLayer.MaterialName,
			Locked = buLayer.Lock
		};
		eyeLayer.Color = Color.FromArgb(buLayer.Transparency, buLayer.LayerColor);
	}

	public static LayerKeyedCollection CopyEyeLayerToEyeLayer(LayerKeyedCollection BaseLayer)
	{
		LayerKeyedCollection layerKeyedCollection = new LayerKeyedCollection();
		for (int i = 0; i <= BaseLayer.Count - 1; i++)
		{
			Layer layer = new Layer(BaseLayer[i].Name);
			layer = (Layer)BaseLayer[i].Clone();
			layerKeyedCollection.Add(layer);
		}
		return layerKeyedCollection;
	}

	public static string SecondToTimeFormat(double Second, bool MiliSecond = false)
	{
		TimeSpan timeSpan = TimeSpan.FromSeconds(Second);
		string text = "";
		if (!MiliSecond)
		{
			return $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
		}
		return $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s:{timeSpan.Milliseconds:D3}ms";
	}

	public static string ToolDirectionToString(Vec3D Direction)
	{
		string result = "-Z";
		if (Direction.Z == 1.0)
		{
			result = "+Z";
		}
		if (Direction.Z == -1.0)
		{
			result = "-Z";
		}
		if (Direction.X == 1.0)
		{
			result = "+X";
		}
		if (Direction.X == -1.0)
		{
			result = "-X";
		}
		if (Direction.Y == 1.0)
		{
			result = "+Y";
		}
		if (Direction.Y == -1.0)
		{
			result = "-Y";
		}
		return result;
	}

	public static selectionFilterType buDynamicSelectionModeToEyeDynamicSelection(DynamicalSelectionType selection)
	{
		return selection switch
		{
			DynamicalSelectionType.Face => selectionFilterType.Face, 
			DynamicalSelectionType.Edge => selectionFilterType.Edge, 
			DynamicalSelectionType.Entity => selectionFilterType.Entity, 
			_ => selectionFilterType.Vertex, 
		};
	}

	public static DynamicalSelectionType eyeDynamicSelectionModeToBuDynamicSelection(selectionFilterType selection)
	{
		return selection switch
		{
			selectionFilterType.Face => DynamicalSelectionType.Face, 
			selectionFilterType.Edge => DynamicalSelectionType.Edge, 
			selectionFilterType.Entity => DynamicalSelectionType.Entity, 
			_ => DynamicalSelectionType.Vertex, 
		};
	}
}
