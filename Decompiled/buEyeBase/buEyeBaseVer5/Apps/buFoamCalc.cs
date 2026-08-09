using System;
using System.Collections.Generic;
using System.Drawing;
using buClass;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5.Apps;

public class buFoamCalc
{
	public static LengthUnit UnitLength = LengthUnit.mm;

	public static SpeedUnit UnitsSpeed = SpeedUnit.mmPerSec;

	public static List<string> LangFoamStatus = new List<string>();

	public static List<string> LangFoamMessage = new List<string>();

	public static List<string> LangFoamCaptions = new List<string>();

	public static List<string> LangFoamCommands = new List<string>();

	public static FoamTempVars varTemps = new FoamTempVars();

	public static FoamSettings varFoamSettings = new FoamSettings();

	public static FoamEditorSettings varFoamEditorSettings = new FoamEditorSettings();

	public static GCodeConverter varFoamGCodeConverter = new GCodeConverter();

	public static FoamRuntimeSettings varFoamRunSettings = new FoamRuntimeSettings();

	public static List<camRadiusFeed> RadiusFeedList = new List<camRadiusFeed>();

	public static List<camLengthFeed> LengthFeedList = new List<camLengthFeed>();

	public static int EntityID = 1;

	public static string UnlockString = "";

	public buFoamCalc()
	{
		if (!buVector5.smethod_0("buFoamCuttingCalc"))
		{
			throw new RegisterException("buFoamCuttingCalc");
		}
	}

	public void CreateSolidOperation(ref FoamPattern Pattern, SizeObject Size, FoamPlaneType refPlane, Color color, bool MultiColor, int transparant = 255)
	{
		try
		{
			Pattern.SolidEntities = new List<Entity>();
			if (refPlane == FoamPlaneType.XZ)
			{
				for (int i = 0; i <= Pattern.foamEntities.Count - 1; i++)
				{
					Color baseColor = color;
					if (MultiColor)
					{
						baseColor = buImage5.GetColorFrom50ListByIndex(i);
					}
					List<ICurve> list = new List<ICurve>();
					List<Point3D> Points = new List<Point3D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(Pattern.foamEntities[i].GroupEntity.Outside.Entities, ref Points);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
					LinearPath linearPath = new LinearPath(Points);
					if (linearPath.IsClosed)
					{
						list.Add(linearPath);
						devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(list, Plane.XZ, sortAndOrient: true);
						Mesh mesh = region.ExtrudeAsMesh(0.0 - Size.Height, 0.2, Mesh.natureType.RichSmooth);
						CustomData customData = new CustomData();
						customData.typeDefination = entityTypeDefination.Operation;
						mesh.EntityData = customData;
						mesh.Color = Color.FromArgb(transparant, baseColor);
						mesh.ColorMethod = colorMethodType.byEntity;
						mesh.Selectable = false;
						Pattern.SolidEntities.Add(mesh);
					}
				}
			}
			if (refPlane != FoamPlaneType.YZ)
			{
				return;
			}
			for (int j = 0; j <= Pattern.foamEntities.Count - 1; j++)
			{
				Color baseColor2 = color;
				if (MultiColor)
				{
					baseColor2 = buImage5.GetColorFrom50ListByIndex(j);
				}
				for (int k = 0; k <= Pattern.foamEntities[j].GroupEntity.Outside.Entities.Count - 1; k++)
				{
					List<ICurve> list2 = new List<ICurve>();
					LinearPath linearPath2 = new LinearPath(Pattern.foamEntities[j].GroupEntity.Outside.Entities[k].Vertices);
					if (linearPath2.IsClosed)
					{
						list2.Add(linearPath2);
						devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(list2, Plane.YZ, sortAndOrient: true);
						Mesh mesh2 = region2.ExtrudeAsMesh(Size.Width, 0.2, Mesh.natureType.RichSmooth);
						CustomData customData2 = new CustomData();
						customData2.typeDefination = entityTypeDefination.Operation;
						mesh2.EntityData = customData2;
						mesh2.Color = Color.FromArgb(transparant, baseColor2);
						mesh2.ColorMethod = colorMethodType.byEntity;
						mesh2.Selectable = false;
						Pattern.SolidEntities.Add(mesh2);
					}
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void CreateMarkCircleEntity(Point3D pntCenter, Plane refPlane, double Diameter, entityTypeDefination T, Color color, ref Entity refEntity)
	{
		Circle circle = new Circle(refPlane, Diameter / 2.0);
		if (refPlane == Plane.XZ)
		{
			circle.Translate(pntCenter.X, pntCenter.Y - 0.2, pntCenter.Z);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(circle);
			refEntity = region.ExtrudeAsMesh(-0.4, 0.1, Mesh.natureType.RichSmooth);
			refEntity.ColorMethod = colorMethodType.byEntity;
			refEntity.Color = color;
			refEntity.Selectable = false;
			CustomData customData = new CustomData();
			customData.typeDefination = T;
			refEntity.EntityData = customData;
		}
		if (refPlane == Plane.YZ)
		{
			circle.Translate(pntCenter.X + 0.2, pntCenter.Y, pntCenter.Z);
			devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(circle);
			refEntity = region2.ExtrudeAsMesh(-0.4, 0.1, Mesh.natureType.RichSmooth);
			refEntity.ColorMethod = colorMethodType.byEntity;
			refEntity.Color = color;
			refEntity.Selectable = false;
			CustomData customData2 = new CustomData();
			customData2.typeDefination = T;
			refEntity.EntityData = customData2;
		}
	}

	public void CreateMarkHexagonEntity(Point3D pntCenter, Plane refPlane, double Diameter, entityTypeDefination T, Color color, ref Entity refEntity)
	{
		if (refPlane == Plane.XZ)
		{
			devDept.Eyeshot.Entities.Region region = devDept.Eyeshot.Entities.Region.CreateHexagon(refPlane, Diameter);
			region.Translate(pntCenter.X, pntCenter.Y - 1.0, pntCenter.Z);
			refEntity = region.ExtrudeAsMesh(-2.0, 0.1, Mesh.natureType.RichSmooth);
			refEntity.ColorMethod = colorMethodType.byEntity;
			refEntity.Color = color;
			refEntity.Selectable = false;
			CustomData customData = new CustomData();
			customData.typeDefination = T;
			refEntity.EntityData = customData;
		}
		if (refPlane == Plane.YZ)
		{
			devDept.Eyeshot.Entities.Region region2 = devDept.Eyeshot.Entities.Region.CreateHexagon(refPlane, Diameter);
			region2.Translate(pntCenter.X + 1.0, pntCenter.Y, pntCenter.Z);
			refEntity = region2.ExtrudeAsMesh(-2.0, 0.1, Mesh.natureType.RichSmooth);
			refEntity.ColorMethod = colorMethodType.byEntity;
			refEntity.Color = color;
			refEntity.Selectable = false;
			CustomData customData2 = new CustomData();
			customData2.typeDefination = T;
			refEntity.EntityData = customData2;
		}
	}

	public void CreateSortEntitiesAndArrow(buEntity sortEntity, Plane refPlane, ref List<Entity> createdEntities, double ArrowFilterDistance = 30.0)
	{
		createdEntities = new List<Entity>();
		CustomData customData = new CustomData();
		customData.typeDefination = entityTypeDefination.Sorted;
		Entity copiedEntity = null;
		buEntity.Copy(sortEntity, ref copiedEntity);
		copiedEntity.ColorMethod = colorMethodType.byEntity;
		copiedEntity.LineWeightMethod = colorMethodType.byEntity;
		if (sortEntity.typeDefination != entityTypeDefination.CamLeadin)
		{
			if (sortEntity.typeDefination != entityTypeDefination.CamLeadOut)
			{
				if (sortEntity.typeDefination != entityTypeDefination.Connection)
				{
					if (!((sortEntity.typeDefination == entityTypeDefination.Upper) | sortEntity.Info.isUpperEntity))
					{
						copiedEntity.Color = varFoamSettings.SortCutColor;
						copiedEntity.LineWeight = 3f;
					}
					else
					{
						copiedEntity.Color = varFoamSettings.SortUpperColor;
						copiedEntity.LineWeight = 5f;
					}
				}
				else
				{
					copiedEntity.Color = varFoamSettings.ConenctionColor;
					copiedEntity.LineWeight = 5f;
				}
			}
			else
			{
				copiedEntity.Color = varFoamSettings.LeadOutColor;
				copiedEntity.LineWeight = 5f;
			}
		}
		else
		{
			copiedEntity.Color = varFoamSettings.LeadInColor;
			copiedEntity.LineWeight = 5f;
		}
		copiedEntity.EntityData = customData;
		createdEntities.Add(copiedEntity);
		List<Entity> arrowEntities = new List<Entity>();
		buCall.buVector5_0.DirectionWireArrowHeadFromEntities(sortEntity, refPlane, varFoamSettings.DirectionArrowHeadLength, varFoamSettings.DirectionArrowHeadAngle, ref arrowEntities);
		double num = 0.0;
		for (int i = 0; i <= arrowEntities.Count - 1; i++)
		{
			bool flag = true;
			if (i > 0 && ((arrowEntities[i].Vertices.Length >= 2) & (arrowEntities[i - 1].Vertices.Length >= 2)))
			{
				double num2 = Point3D.Distance(arrowEntities[i].Vertices[1], arrowEntities[i - 1].Vertices[1]);
				num += num2;
				if (!(num < ArrowFilterDistance))
				{
					num = 0.0;
				}
				else
				{
					flag = false;
				}
			}
			if (flag)
			{
				if (!(refPlane == Plane.XZ))
				{
					arrowEntities[i].Translate(-0.5, 0.0);
				}
				else
				{
					arrowEntities[i].Translate(0.0, -0.5);
				}
				arrowEntities[i].ColorMethod = colorMethodType.byEntity;
				arrowEntities[i].LineWeightMethod = colorMethodType.byEntity;
				customData = new CustomData();
				customData.typeDefination = entityTypeDefination.Sorted;
				arrowEntities[i].EntityData = customData;
				if (!(sortEntity.Info.isUpperEntity | (sortEntity.typeDefination == entityTypeDefination.Upper) | (sortEntity.typeDefination == entityTypeDefination.CamLeadin) | (sortEntity.typeDefination == entityTypeDefination.CamLeadOut) | (sortEntity.typeDefination == entityTypeDefination.Connection)))
				{
					arrowEntities[i].Color = varFoamSettings.SortCutColor;
					arrowEntities[i].LineWeight = 3f;
				}
				else
				{
					arrowEntities[i].Color = varFoamSettings.SortUpperColor;
					arrowEntities[i].LineWeight = 5f;
				}
				createdEntities.Add(arrowEntities[i]);
			}
		}
	}

	public void WavePyramitShape(FoamWaveShapeArgs Args, FoamType Type, ref List<FoamPattern> calcPatterns)
	{
		calcPatterns = new List<FoamPattern>();
		Plane refPlane = Plane.XZ;
		if (Args.refPlane == FoamPlaneType.YZ)
		{
			refPlane = Plane.YZ;
		}
		for (double num = 0.0; num <= (double)(Args.RepeatCount - 1); num += 1.0)
		{
			FoamPattern foamPattern = new FoamPattern();
			double num2 = num * Args.Width * (double)Args.WaveCount;
			double x = 0.0;
			double num3 = 0.0;
			double x2 = 0.0;
			double x3 = 0.0;
			double y = 0.0;
			double y2 = 0.0;
			double y3 = 0.0;
			double y4 = 0.0;
			double z = 0.0;
			double num4 = 0.0;
			double z2 = 0.0;
			double z3 = 0.0;
			List<Point3D> Points = new List<Point3D>();
			List<Point3D> Points2 = new List<Point3D>();
			for (double num5 = 0.0; num5 <= (double)(Args.WaveCount - 1); num5 += 1.0)
			{
				double num6 = 0.0;
				double x4 = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double x5 = 0.0;
				double num9 = 0.0;
				double x6 = 0.0;
				double x7 = 0.0;
				double num10 = 0.0;
				double x8 = 0.0;
				double num11 = 0.0;
				double y5 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				double y6 = 0.0;
				double num14 = 0.0;
				double y7 = 0.0;
				double y8 = 0.0;
				double num15 = 0.0;
				double y9 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = 0.0;
				double num20 = 0.0;
				double num21 = 0.0;
				double num22 = 0.0;
				double num23 = 0.0;
				double num24 = 0.0;
				double num25 = 0.0;
				if (Type == FoamType.Pyramid)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num6 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 0.0;
						x4 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 0.5;
						num7 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 1.0;
						if (num5 == 0.0)
						{
							x = num6;
						}
						if (num5 == (double)(Args.WaveCount - 1))
						{
							num3 = num7;
						}
						num8 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
						x5 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
						num9 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 1.0;
						if (num5 == 0.0)
						{
							x2 = num8;
						}
						if (num5 == (double)(Args.WaveCount - 1))
						{
							x3 = num9;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num11 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 0.0;
						y5 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 0.5;
						num12 = Args.StartWidthOffset + Args.Width / 2.0 + num2 + num5 * Args.Width + Args.Width * 1.0;
						if (num5 == 0.0)
						{
							y = num11;
						}
						if (num5 == (double)(Args.WaveCount - 1))
						{
							y2 = num12;
						}
						num13 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
						y6 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
						num14 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 1.0;
						if (num5 == 0.0)
						{
							y3 = num13;
						}
						if (num5 == (double)(Args.WaveCount - 1))
						{
							y4 = num14;
						}
					}
					num16 = Args.ZPos + Args.ZOffset;
					num17 = Args.ZPos - Args.Height + Args.ZOffset;
					num18 = Args.ZPos + Args.ZOffset;
					num19 = Args.ZPos - Args.Height + Args.ZOffset;
					num20 = Args.ZPos + Args.ZOffset;
					num21 = Args.ZPos - Args.Height + Args.ZOffset;
					num4 = Args.ZPos + Args.ZOffset;
					z = Args.ZPos + Args.BaseHeight - Args.Height + Args.ZOffset;
					z3 = Args.ZPos - Args.Height + Args.ZOffset;
					z2 = Args.ZPos - Args.BaseHeight + Args.ZOffset;
					Points.Add(new Point3D(num6, num11, num16));
					Points.Add(new Point3D(x4, y5, num17));
					Points.Add(new Point3D(num7, num12, num18));
					Points2.Add(new Point3D(num8, num13, num19));
					Points2.Add(new Point3D(x5, y6, num20));
					Points2.Add(new Point3D(num9, num14, num21));
				}
				if (Type != FoamType.Rectangle)
				{
					continue;
				}
				if (Args.refPlane == FoamPlaneType.XZ)
				{
					num6 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.0;
					x4 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.0;
					num7 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.5;
					num8 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.5;
					x5 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 1.0;
					if (num5 == 0.0)
					{
						x = num6;
					}
					if (num5 == (double)(Args.WaveCount - 1))
					{
						num3 = num8;
					}
					num9 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
					x6 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
					x7 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
					num10 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
					x8 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 1.0;
					if (num5 == 0.0)
					{
						x2 = num9;
					}
					if (num5 == (double)(Args.WaveCount - 1))
					{
						x3 = num10;
					}
				}
				if (Args.refPlane == FoamPlaneType.YZ)
				{
					num11 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.0;
					y5 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.0;
					num12 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.5;
					num13 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 0.5;
					y6 = Args.StartWidthOffset + num2 + Args.Width / 2.0 + num5 * Args.Width + Args.Width * 1.0;
					if (num5 == 0.0)
					{
						y = num11;
					}
					if (num5 == (double)(Args.WaveCount - 1))
					{
						y2 = num13;
					}
					num14 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
					y7 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.0;
					y8 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
					num15 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 0.5;
					y9 = Args.StartWidthOffset + num2 + num5 * Args.Width + Args.Width * 1.0;
					if (num5 == 0.0)
					{
						y3 = num14;
					}
					if (num5 == (double)(Args.WaveCount - 1))
					{
						y4 = num15;
					}
				}
				num16 = Args.ZPos + Args.Height + Args.ZOffset;
				num17 = Args.ZPos + Args.Height - Args.Height + Args.ZOffset;
				num18 = Args.ZPos + Args.Height - Args.Height + Args.ZOffset;
				num19 = Args.ZPos + Args.Height + Args.ZOffset;
				num20 = Args.ZPos + Args.Height + Args.ZOffset;
				num21 = Args.ZPos + Args.ZOffset;
				num22 = Args.ZPos + Args.Height + Args.ZOffset;
				num23 = Args.ZPos + Args.Height + Args.ZOffset;
				num24 = Args.ZPos + Args.ZOffset;
				num25 = Args.ZPos + Args.ZOffset;
				num4 = Args.ZPos + Args.Height + Args.ZOffset;
				z = Args.ZPos + Args.BaseHeight + Args.ZOffset;
				z3 = num4 - Args.Height;
				z2 = Args.ZPos - (Args.BaseHeight - Args.Height) + Args.ZOffset;
				Points.Add(new Point3D(num6, num11, num16));
				Points.Add(new Point3D(x4, y5, num17));
				Points.Add(new Point3D(num7, num12, num18));
				Points.Add(new Point3D(num8, num13, num19));
				if (num5 != (double)(Args.WaveCount - 1))
				{
					Points.Add(new Point3D(x5, y6, num20));
				}
				Points2.Add(new Point3D(num9, num14, num21));
				Points2.Add(new Point3D(x6, y7, num22));
				Points2.Add(new Point3D(x7, y8, num23));
				Points2.Add(new Point3D(num10, num15, num24));
				if (num5 != (double)(Args.WaveCount - 1))
				{
					Points2.Add(new Point3D(x8, y9, num25));
				}
			}
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points2);
			if (!(Args.RoundRadius > 0.0))
			{
				if (Args.ChamferLen > 0.0)
				{
					List<Point3D> copiedPoint = new List<Point3D>();
					buVector5.Copy(Points, ref copiedPoint);
					Points.Clear();
					Points = new List<Point3D>();
					buCall.buVector5_0.ChamferPointList(copiedPoint, Args.ChamferLen, refPlane, ref Points);
					copiedPoint = new List<Point3D>();
					buVector5.Copy(Points2, ref copiedPoint);
					Points2.Clear();
					Points2 = new List<Point3D>();
					buCall.buVector5_0.ChamferPointList(copiedPoint, Args.ChamferLen, refPlane, ref Points2);
				}
			}
			else
			{
				List<Point3D> copiedPoint2 = new List<Point3D>();
				buVector5.Copy(Points, ref copiedPoint2);
				Points.Clear();
				Points = new List<Point3D>();
				buCall.buVector5_0.FilletPointList(copiedPoint2, Args.RoundRadius, refPlane, ref Points);
				copiedPoint2 = new List<Point3D>();
				buVector5.Copy(Points2, ref copiedPoint2);
				Points2.Clear();
				Points2 = new List<Point3D>();
				buCall.buVector5_0.FilletPointList(copiedPoint2, Args.RoundRadius, refPlane, ref Points2);
			}
			List<Point3D> copiedPoint3 = new List<Point3D>();
			FoamEntities foamEntities = new FoamEntities();
			buVector5.Copy(Points, ref copiedPoint3);
			copiedPoint3.Add(new Point3D(num3, y2, z));
			copiedPoint3.Add(new Point3D(x, y, z));
			copiedPoint3.Add(new Point3D(x, y, num4));
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint3);
			double num26 = buCall.buVector5_0.PolygonArea(copiedPoint3, ConvertPlane(Args.refPlane));
			double num27 = buCall.buVector5_0.Length3D(copiedPoint3);
			foamEntities.GroupEntity.Outside.Entities.Add(new buLinearPath(copiedPoint3));
			List<Point3D> copiedPoint4 = new List<Point3D>();
			FoamEntities foamEntities2 = new FoamEntities();
			buVector5.Copy(Points2, ref copiedPoint4);
			copiedPoint4.Add(new Point3D(x3, y4, z2));
			copiedPoint4.Add(new Point3D(x2, y3, z2));
			copiedPoint4.Add(new Point3D(x2, y3, z3));
			double num28 = buCall.buVector5_0.PolygonArea(copiedPoint4, ConvertPlane(Args.refPlane));
			double num29 = buCall.buVector5_0.Length3D(copiedPoint3);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint4);
			foamEntities2.GroupEntity.Outside.Entities.Add(new buLinearPath(copiedPoint4));
			foamPattern.foamEntities.Add(foamEntities);
			foamPattern.foamEntities.Add(foamEntities2);
			List<Point3D> copiedPoint5 = new List<Point3D>();
			if (Type == FoamType.Pyramid)
			{
				buVector5.Copy(copiedPoint3, ref copiedPoint5);
				copiedPoint5.Add(new Point3D(copiedPoint4[0].X, copiedPoint4[0].Y, copiedPoint4[0].Z));
				copiedPoint5.Add(new Point3D(x2, y3, z2));
				copiedPoint5.Add(new Point3D(x3, y4, z2));
				copiedPoint5.Add(new Point3D(x3, y4, z3));
				copiedPoint5.Add(new Point3D(num3, y2, num4));
			}
			if (Type == FoamType.Rectangle)
			{
				buVector5.Copy(copiedPoint3, ref copiedPoint5);
				copiedPoint5.Add(new Point3D(x2, y3, num4));
				copiedPoint5.Add(new Point3D(x2, y3, z2));
				copiedPoint5.Add(new Point3D(x3, y4, z2));
				copiedPoint5.Add(new Point3D(x3, y4, z3));
				copiedPoint5.Add(new Point3D(num3, y2, z3));
				copiedPoint5.Add(new Point3D(num3, y2, num4));
				copiedPoint5.Add(new Point3D(num3 + Args.Width / 2.0, y2, num4));
			}
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint5);
			foamPattern.sortEntities.Add(new buLinearPath(copiedPoint5));
			foamPattern.planeName = Args.refPlane;
			FoamEntitiesBoxSize(foamPattern.foamEntities, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
			foamPattern.Info.TotalArea = Math.Round(num26 + num28, 3);
			foamPattern.Info.TotalCuttingLength = Math.Round(num27 + num29, 3);
			if (Args.refPlane == FoamPlaneType.XZ)
			{
				foamPattern.Info.BoxArea = Math.Round((foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X) * (foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z), 3);
			}
			if (Args.refPlane == FoamPlaneType.YZ)
			{
				foamPattern.Info.BoxArea = Math.Round((foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y) * (foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z), 3);
			}
			if (foamPattern.Info.BoxArea > 0.0)
			{
				foamPattern.Info.UsedPersentageFromBoxArea = Math.Round(foamPattern.Info.TotalArea / foamPattern.Info.BoxArea * 100.0, 3);
			}
			if (UnitsSpeed == SpeedUnit.mmPerSec)
			{
				foamPattern.Info.TimeCutting = Math.Round(foamPattern.Info.TotalCuttingLength / Args.CuttingSpeed, 3);
			}
			if (UnitsSpeed == SpeedUnit.mmPerMin)
			{
				foamPattern.Info.TimeCutting = Math.Round(foamPattern.Info.TotalCuttingLength / Args.CuttingSpeed * 60.0, 3);
			}
			calcPatterns.Add(foamPattern);
		}
	}

	public void WaveTypeShape(FoamWaveShapeArgs Args, FoamType Type, ref List<FoamPattern> calcPatterns)
	{
		calcPatterns = new List<FoamPattern>();
		Plane refPlane = Plane.XZ;
		if (Args.refPlane == FoamPlaneType.YZ)
		{
			refPlane = Plane.YZ;
		}
		double num = 0.25 / varFoamSettings.GCodeRegenDEviation;
		if (num < 4.0)
		{
			num = 4.0;
		}
		for (double num2 = 0.0; num2 <= (double)(Args.RepeatCount - 1); num2 += 1.0)
		{
			FoamPattern foamPattern = new FoamPattern();
			double num3 = num2 * Args.Width * (double)Args.WaveCount;
			double x = 0.0;
			double x2 = 0.0;
			double y = 0.0;
			double y2 = 0.0;
			double z = 0.0;
			double z2 = 0.0;
			double z3 = 0.0;
			List<Point3D> Points = new List<Point3D>();
			for (double num4 = 0.0; num4 <= (double)(Args.WaveCount - 1); num4 += 1.0)
			{
				double num5 = 0.0;
				double x3 = 0.0;
				double num6 = 0.0;
				double x4 = 0.0;
				double num7 = 0.0;
				double x5 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				double y3 = 0.0;
				double num10 = 0.0;
				double y4 = 0.0;
				double num11 = 0.0;
				double y5 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = 0.0;
				double num15 = 0.0;
				double num16 = 0.0;
				double num17 = 0.0;
				double num18 = 0.0;
				double num19 = 0.0;
				if (Type == FoamType.ZForm)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.25;
						num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						x4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.75;
						num7 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							x = num5;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							x2 = num7;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.25;
						num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						y4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.75;
						num11 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							y = num9;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							y2 = num11;
						}
					}
					num13 = Args.ZPos + Args.ZOffset;
					num14 = Args.ZPos + Args.Height + Args.ZOffset;
					num15 = Args.ZPos + Args.ZOffset;
					num16 = Args.ZPos - Args.Height + Args.ZOffset;
					num17 = Args.ZPos + Args.ZOffset;
					z3 = Args.ZPos + Args.ZOffset;
					z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
					z = Args.ZPos - Args.BaseHeight + Args.ZOffset;
					Points.Add(new Point3D(num5, num9, num13));
					Points.Add(new Point3D(x3, y3, num14));
					Points.Add(new Point3D(num6, num10, num15));
					Points.Add(new Point3D(x4, y4, num16));
					Points.Add(new Point3D(num7, num11, num17));
				}
				if (Type == FoamType.VForm)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							x = num5;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							x2 = num6;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							y = num9;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							y2 = num10;
						}
					}
					num13 = Args.ZPos + Args.ZOffset;
					num14 = Args.ZPos + Args.Height + Args.ZOffset;
					num15 = Args.ZPos + Args.ZOffset;
					z3 = Args.ZPos + Args.ZOffset;
					z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
					z = Args.ZPos - Args.BaseHeight + Args.Height + Args.ZOffset;
					Points.Add(new Point3D(num5, num9, num13));
					Points.Add(new Point3D(x3, y3, num14));
					Points.Add(new Point3D(num6, num10, num15));
				}
				if (Type == FoamType.SForm)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.25;
						num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						x4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.75;
						num7 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							x = num5;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							x2 = num7;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.25;
						num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						y4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.75;
						num11 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							y = num9;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							y2 = num11;
						}
					}
					num13 = Args.ZPos + Args.ZOffset;
					num14 = Args.ZPos + Args.Height + Args.ZOffset;
					num15 = Args.ZPos + Args.ZOffset;
					num16 = Args.ZPos - Args.Height + Args.ZOffset;
					num17 = Args.ZPos + Args.ZOffset;
					z3 = Args.ZPos + Args.ZOffset;
					z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
					z = Args.ZPos - Args.BaseHeight + Args.ZOffset;
					List<Point3D> Vertices = new List<Point3D>();
					buCall.buVector5_0.Arc3Point(new Point3D(num5, num9, num13), new Point3D(x3, y3, num14), new Point3D(num6, num10, num15), ConvertPlane(Args.refPlane), new EntityResolution(0.5, 10, num, EntityResolutionType.ByLnRadius, 25), ref Vertices);
					Vertices.Reverse();
					Points.AddRange(Vertices);
					Vertices = new List<Point3D>();
					buCall.buVector5_0.Arc3Point(new Point3D(num6, num10, num15), new Point3D(x4, y4, num16), new Point3D(num7, num11, num17), ConvertPlane(Args.refPlane), new EntityResolution(0.5, 10, num, EntityResolutionType.ByLnRadius, 25), ref Vertices);
					Points.AddRange(Vertices);
				}
				if (Type == FoamType.CForm)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							x = num5;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							x2 = num6;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							y = num9;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							y2 = num10;
						}
					}
					num13 = Args.ZPos + Args.ZOffset;
					num14 = Args.ZPos + Args.Height + Args.ZOffset;
					num15 = Args.ZPos + Args.ZOffset;
					z3 = Args.ZPos + Args.ZOffset;
					z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
					z = Args.ZPos - Args.BaseHeight + Args.Height + Args.ZOffset;
					List<Point3D> Vertices2 = new List<Point3D>();
					buCall.buVector5_0.Arc3Point(new Point3D(num5, num9, num13), new Point3D(x3, y3, num14), new Point3D(num6, num10, num15), ConvertPlane(Args.refPlane), new EntityResolution(0.5, 10, num, EntityResolutionType.ByLnRadius, 25), ref Vertices2);
					Vertices2.Reverse();
					Points.AddRange(Vertices2);
				}
				if (Type == FoamType.Rectangle)
				{
					if (Args.refPlane == FoamPlaneType.XZ)
					{
						num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						x4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num7 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						x5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						num8 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							x = num5;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							x2 = num8;
						}
					}
					if (Args.refPlane == FoamPlaneType.YZ)
					{
						num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
						num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						y4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						num11 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
						y5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						num12 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
						if (num4 == 0.0)
						{
							y = num9;
						}
						if (num4 == (double)(Args.WaveCount - 1))
						{
							y2 = num12;
						}
					}
					num13 = Args.ZPos + Args.ZOffset;
					num14 = Args.ZPos + Args.Height + Args.ZOffset;
					num15 = Args.ZPos + Args.Height + Args.ZOffset;
					num16 = Args.ZPos + Args.ZOffset;
					num17 = Args.ZPos - Args.Height + Args.ZOffset;
					num18 = Args.ZPos - Args.Height + Args.ZOffset;
					num19 = Args.ZPos + Args.ZOffset;
					z3 = Args.ZPos + Args.ZOffset;
					z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
					z = Args.ZPos - Args.BaseHeight + Args.ZOffset;
					Points.Add(new Point3D(num5, num9, num13));
					Points.Add(new Point3D(x3, y3, num14));
					Points.Add(new Point3D(num6, num10, num15));
					Points.Add(new Point3D(x4, y4, num16));
					Points.Add(new Point3D(num7, num11, num17));
					Points.Add(new Point3D(x5, y5, num18));
					Points.Add(new Point3D(num8, num12, num19));
				}
				if (Type != FoamType.UForm)
				{
					continue;
				}
				if (Args.refPlane == FoamPlaneType.XZ)
				{
					num5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
					x3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
					num6 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					x4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					num7 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					x5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
					num8 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
					if (num4 == 0.0)
					{
						x = num5;
					}
					if (num4 == (double)(Args.WaveCount - 1))
					{
						x2 = num8;
					}
				}
				if (Args.refPlane == FoamPlaneType.YZ)
				{
					num9 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
					y3 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.0;
					num10 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					y4 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					num11 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 0.5;
					y5 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
					num12 = Args.StartWidthOffset + num3 + num4 * Args.Width + Args.Width * 1.0;
					if (num4 == 0.0)
					{
						y = num9;
					}
					if (num4 == (double)(Args.WaveCount - 1))
					{
						y2 = num12;
					}
				}
				num13 = Args.ZPos + Args.ZOffset;
				num14 = Args.ZPos + Args.Height + Args.ZOffset;
				num15 = Args.ZPos + Args.Height + Args.ZOffset;
				num16 = Args.ZPos + Args.ZOffset;
				num17 = Args.ZPos - Args.Height + Args.ZOffset;
				num18 = Args.ZPos - Args.Height + Args.ZOffset;
				num19 = Args.ZPos + Args.ZOffset;
				z3 = Args.ZPos + Args.ZOffset;
				z2 = Args.ZPos + Args.BaseHeight + Args.ZOffset;
				z = Args.ZPos - Args.BaseHeight + Args.ZOffset;
				Points.Add(new Point3D(num5, num9, num13));
				Points.Add(new Point3D(x3, y3, num14));
				Points.Add(new Point3D(num6, num10, num15));
				Points.Add(new Point3D(x4, y4, num16));
				Points.Add(new Point3D(num7, num11, num17));
				Points.Add(new Point3D(x5, y5, num18));
				Points.Add(new Point3D(num8, num12, num19));
			}
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
			if (!(Args.RoundRadius > 0.0))
			{
				if (Args.ChamferLen > 0.0)
				{
					List<Point3D> copiedPoint = new List<Point3D>();
					buVector5.Copy(Points, ref copiedPoint);
					Points.Clear();
					Points = new List<Point3D>();
					buCall.buVector5_0.ChamferPointList(copiedPoint, Args.ChamferLen, refPlane, ref Points);
				}
			}
			else
			{
				List<Point3D> copiedPoint2 = new List<Point3D>();
				buVector5.Copy(Points, ref copiedPoint2);
				Points.Clear();
				Points = new List<Point3D>();
				buCall.buVector5_0.FilletPointList(copiedPoint2, Args.RoundRadius, refPlane, ref Points);
			}
			List<Point3D> copiedPoint3 = new List<Point3D>();
			FoamEntities foamEntities = new FoamEntities();
			buVector5.Copy(Points, ref copiedPoint3);
			copiedPoint3.Add(new Point3D(x2, y2, z2));
			copiedPoint3.Add(new Point3D(x, y, z2));
			copiedPoint3.Add(new Point3D(x, y, z3));
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint3);
			double num20 = buCall.buVector5_0.PolygonArea(copiedPoint3, ConvertPlane(Args.refPlane));
			double num21 = buCall.buVector5_0.Length3D(copiedPoint3);
			foamEntities.GroupEntity.Outside.Entities.Add(new buLinearPath(copiedPoint3));
			List<Point3D> copiedPoint4 = new List<Point3D>();
			FoamEntities foamEntities2 = new FoamEntities();
			buVector5.Copy(Points, ref copiedPoint4);
			copiedPoint4.Add(new Point3D(x2, y2, z));
			copiedPoint4.Add(new Point3D(x, y, z));
			copiedPoint4.Add(new Point3D(x, y, z3));
			double num22 = buCall.buVector5_0.PolygonArea(copiedPoint4, ConvertPlane(Args.refPlane));
			double num23 = buCall.buVector5_0.Length3D(copiedPoint3);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint4);
			foamEntities2.GroupEntity.Outside.Entities.Add(new buLinearPath(copiedPoint4));
			foamPattern.foamEntities.Add(foamEntities);
			foamPattern.foamEntities.Add(foamEntities2);
			List<Point3D> copiedPoint5 = new List<Point3D>();
			buVector5.Copy(Points, ref copiedPoint5);
			copiedPoint5.Add(new Point3D(x2, y2, z2));
			copiedPoint5.Add(new Point3D(x, y, z2));
			copiedPoint5.Add(new Point3D(x, y, z3));
			copiedPoint5.Add(new Point3D(x, y, z));
			copiedPoint5.Add(new Point3D(x2, y2, z));
			copiedPoint5.Add(new Point3D(x2, y2, z3));
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint5);
			foamPattern.sortEntities.Add(new buLinearPath(copiedPoint5));
			foamPattern.planeName = Args.refPlane;
			FoamEntitiesBoxSize(foamPattern.foamEntities, ref foamPattern.BoxMinItem, ref foamPattern.BoxMaxItem);
			foamPattern.Info.TotalArea = Math.Round(num20 + num22, 3);
			foamPattern.Info.TotalCuttingLength = Math.Round(num21 + num23, 3);
			if (Args.refPlane == FoamPlaneType.XZ)
			{
				foamPattern.Info.BoxArea = Math.Round((foamPattern.BoxMaxItem.X - foamPattern.BoxMinItem.X) * (foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z), 3);
			}
			if (Args.refPlane == FoamPlaneType.YZ)
			{
				foamPattern.Info.BoxArea = Math.Round((foamPattern.BoxMaxItem.Y - foamPattern.BoxMinItem.Y) * (foamPattern.BoxMaxItem.Z - foamPattern.BoxMinItem.Z), 3);
			}
			if (foamPattern.Info.BoxArea > 0.0)
			{
				foamPattern.Info.UsedPersentageFromBoxArea = Math.Round(foamPattern.Info.TotalArea / foamPattern.Info.BoxArea * 100.0, 3);
			}
			if (UnitsSpeed == SpeedUnit.mmPerSec)
			{
				foamPattern.Info.TimeCutting = Math.Round(foamPattern.Info.TotalCuttingLength / Args.CuttingSpeed, 3);
			}
			if (UnitsSpeed == SpeedUnit.mmPerMin)
			{
				foamPattern.Info.TimeCutting = Math.Round(foamPattern.Info.TotalCuttingLength / Args.CuttingSpeed * 60.0, 3);
			}
			calcPatterns.Add(foamPattern);
		}
	}

	public void FoamEntitiesToEntities(List<FoamEntities> FoamEntity, ref List<buEntity> refEntities)
	{
		refEntities.Clear();
		for (int i = 0; i <= FoamEntity.Count - 1; i++)
		{
			for (int j = 0; j <= FoamEntity[i].GroupEntity.Inside.Count - 1; j++)
			{
				for (int k = 0; k <= FoamEntity[i].GroupEntity.Inside[j].Entities.Count - 1; k++)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(FoamEntity[i].GroupEntity.Inside[j].Entities[k], ref copiedEntity);
					if (copiedEntity != null)
					{
						refEntities.Add(copiedEntity);
					}
				}
			}
			for (int l = 0; l <= FoamEntity[i].GroupEntity.Outside.Entities.Count - 1; l++)
			{
				buEntity copiedEntity2 = null;
				buEntity.Copy(FoamEntity[i].GroupEntity.Outside.Entities[l], ref copiedEntity2);
				if (copiedEntity2 != null)
				{
					refEntities.Add(copiedEntity2);
				}
			}
		}
	}

	public void FoamEntitiesMove(double dX, double dY, double dZ, ref List<FoamEntities> refEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			FoamEntities foamEntities = refEntities[i];
			for (int j = 0; j <= foamEntities.GroupEntity.Inside.Count - 1; j++)
			{
				buCall.buVector5_0.Move(dX, dY, dZ, ref foamEntities.GroupEntity.Inside[j].Entities);
			}
			buCall.buVector5_0.Move(dX, dY, dZ, ref foamEntities.GroupEntity.Outside.Entities);
		}
	}

	public void FoamEntitiesBoxSize(List<FoamEntities> refEntities, ref Point3D minPoint, ref Point3D maxPoint)
	{
		List<buEntity> refEntities2 = new List<buEntity>();
		FoamEntitiesToEntities(refEntities, ref refEntities2);
		buCall.buVector5_0.BoxSizeCalculate(refEntities2, ref minPoint, ref maxPoint);
	}

	public void FoamEntitiesRotate(double Degree, Vector3D Axis, ref List<FoamEntities> refEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			for (int j = 0; j <= refEntities[i].GroupEntity.Outside.Entities.Count - 1; j++)
			{
				buEntity buEntity2 = refEntities[i].GroupEntity.Outside.Entities[j];
				buEntity2.Rotate(Degree, Axis);
			}
			for (int k = 0; k <= refEntities[i].GroupEntity.Inside.Count - 1; k++)
			{
				for (int l = 0; l <= refEntities[i].GroupEntity.Inside[k].Entities.Count - 1; l++)
				{
					buEntity buEntity3 = refEntities[i].GroupEntity.Inside[k].Entities[l];
					buEntity3.Rotate(Degree, Axis);
				}
			}
		}
	}

	public void FoamEntitiesMirror(bool MirrorHor, bool MirrorVer, FoamPlaneType refPlane, ref List<FoamEntities> refEntities)
	{
		Point3D minPoint = new Point3D();
		Point3D maxPoint = new Point3D();
		FoamEntitiesBoxSize(refEntities, ref minPoint, ref maxPoint);
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			FoamEntities foamEntities = refEntities[i];
			if (refPlane == FoamPlaneType.XZ)
			{
				if (MirrorHor)
				{
					if (foamEntities.GroupEntity.Outside != null)
					{
						buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref foamEntities.GroupEntity.Outside.Entities);
					}
					if (foamEntities.GroupEntity.Inside != null)
					{
						for (int j = 0; j <= foamEntities.GroupEntity.Inside.Count - 1; j++)
						{
							buCall.buVector5_0.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref foamEntities.GroupEntity.Inside[j].Entities);
						}
					}
					if (foamEntities.GroupEntity.OpenEntities != null)
					{
						for (int k = 0; k <= foamEntities.GroupEntity.OpenEntities.Count - 1; k++)
						{
							buCall.buVector5_0.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref foamEntities.GroupEntity.OpenEntities[k].Entities);
						}
					}
				}
				if (MirrorVer)
				{
					if (foamEntities.GroupEntity.Outside != null)
					{
						buCall.buVector5_0.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref foamEntities.GroupEntity.Outside.Entities);
					}
					if (foamEntities.GroupEntity.Inside != null)
					{
						for (int l = 0; l <= foamEntities.GroupEntity.Inside.Count - 1; l++)
						{
							buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref foamEntities.GroupEntity.Inside[l].Entities);
						}
					}
					if (foamEntities.GroupEntity.OpenEntities != null)
					{
						for (int m = 0; m <= foamEntities.GroupEntity.OpenEntities.Count - 1; m++)
						{
							buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref foamEntities.GroupEntity.OpenEntities[m].Entities);
						}
					}
				}
			}
			if (refPlane != FoamPlaneType.YZ)
			{
				continue;
			}
			if (MirrorHor)
			{
				if (foamEntities.GroupEntity.Outside != null)
				{
					buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref foamEntities.GroupEntity.Outside.Entities);
				}
				if (foamEntities.GroupEntity.Inside != null)
				{
					for (int n = 0; n <= foamEntities.GroupEntity.Inside.Count - 1; n++)
					{
						buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref foamEntities.GroupEntity.Inside[n].Entities);
					}
				}
				if (foamEntities.GroupEntity.OpenEntities != null)
				{
					for (int num = 0; num <= foamEntities.GroupEntity.OpenEntities.Count - 1; num++)
					{
						buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref foamEntities.GroupEntity.OpenEntities[num].Entities);
					}
				}
			}
			if (!MirrorVer)
			{
				continue;
			}
			if (foamEntities.GroupEntity.Outside != null)
			{
				buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref foamEntities.GroupEntity.Outside.Entities);
			}
			if (foamEntities.GroupEntity.Inside != null)
			{
				for (int num2 = 0; num2 <= foamEntities.GroupEntity.Inside.Count - 1; num2++)
				{
					buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref foamEntities.GroupEntity.Inside[num2].Entities);
				}
			}
			if (foamEntities.GroupEntity.OpenEntities != null)
			{
				for (int num3 = 0; num3 <= foamEntities.GroupEntity.OpenEntities.Count - 1; num3++)
				{
					buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref foamEntities.GroupEntity.OpenEntities[num3].Entities);
				}
			}
		}
		minPoint = new Point3D();
		maxPoint = new Point3D();
		FoamEntitiesBoxSize(refEntities, ref minPoint, ref maxPoint);
		FoamEntitiesMove(0.0 - minPoint.X, 0.0 - minPoint.Y, 0.0 - minPoint.Z, ref refEntities);
	}

	public void EntitiesMirror(bool MirrorHor, bool MirrorVer, FoamPlaneType refPlane, ref List<buEntity> refEntities)
	{
		if (refPlane == FoamPlaneType.XZ)
		{
			if (MirrorHor)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
				double x = MinPoint.X;
				buCall.buVector5_0.Mirror(new Point3D(0.0, 0.0, 0.0), new Point3D(0.0, 0.0, 10.0), Plane.XZ, ref refEntities);
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint, ref MaxPoint);
				buCall.buVector5_0.Move(0.0 - MinPoint.X + x, 0.0 - MinPoint.Y, 0.0 - MinPoint.Z, ref refEntities);
			}
			if (MirrorVer)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint2, ref MaxPoint2);
				double x2 = MinPoint2.X;
				buCall.buVector5_0.Mirror(new Point3D(), new Point3D(10.0, 0.0, 0.0), Plane.XZ, ref refEntities);
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint2, ref MaxPoint2);
				buCall.buVector5_0.Move(0.0 - MinPoint2.X + x2, 0.0 - MinPoint2.Y, 0.0 - MinPoint2.Z, ref refEntities);
			}
		}
		if (refPlane == FoamPlaneType.YZ)
		{
			if (MirrorHor)
			{
				buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 10.0, 0.0), Plane.YZ, ref refEntities);
				Point3D MinPoint3 = new Point3D();
				Point3D MaxPoint3 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint3, ref MaxPoint3);
				buCall.buVector5_0.Move(0.0 - MinPoint3.X, 0.0 - MinPoint3.Y, 0.0 - MinPoint3.Z, ref refEntities);
			}
			if (MirrorVer)
			{
				buCall.buVector5_0.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref refEntities);
				Point3D MinPoint4 = new Point3D();
				Point3D MaxPoint4 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(refEntities, ref MinPoint4, ref MaxPoint4);
				buCall.buVector5_0.Move(0.0 - MinPoint4.X, 0.0 - MinPoint4.Y, 0.0 - MinPoint4.Z, ref refEntities);
			}
		}
	}

	public void PatternInfo(List<FoamPattern> Patterns, SizeObject SizeFoam, FoamSettings Settings, FoamRuntimeSettings RunSettings, ref string Info)
	{
		Info = "";
		if (Patterns.Count > 0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			num5 = ((Patterns[0].planeName == FoamPlaneType.XZ) ? (SizeFoam.Width * SizeFoam.Depth) : (SizeFoam.Height * SizeFoam.Depth));
			double num6 = RunSettings.BlockWidth * RunSettings.BlockHeight;
			for (int i = 0; i <= Patterns.Count - 1; i++)
			{
				num += Patterns[i].Info.TotalCuttingLength;
				num2 += Patterns[i].Info.TimeCutting;
				num4 += Patterns[i].Info.TotalArea;
				num3 += Patterns[i].Info.UsedPersentageFromBoxArea;
			}
			num3 /= (double)Patterns.Count;
			Info = Info + buLangTranslate.preDef.Pattern + " " + buLangTranslate.preDef.Information + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " : " + num.ToString("f3") + " " + UnitLength.ToString() + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Time + " : " + num2.ToString("f3") + " " + buLangTranslate.preDef.Second + "   -  " + buLangTranslate.preDef.Pattern + " %" + num3.ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Block + " " + buLangTranslate.preDef.Information + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Block + " %" + (num4 / num6 * 100.0).ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Foam + " " + buLangTranslate.preDef.Information + Environment.NewLine;
			Info = Info + buLangTranslate.preDef.Block + " %" + (num4 / num5 * 100.0).ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
		}
	}

	public void PatternInfo(FoamPattern Patterns, SizeObject SizeFoam, double HorCount, double VerCount, FoamSettings Settings, FoamRuntimeSettings RunSettings, ref string Info)
	{
		Info = "";
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		num5 = ((Patterns.planeName == FoamPlaneType.XZ) ? (SizeFoam.Width * SizeFoam.Depth) : (SizeFoam.Height * SizeFoam.Depth));
		double num6 = RunSettings.BlockIdealWidth * RunSettings.BlockIdealHeight;
		num += Patterns.Info.TotalCuttingLength * HorCount * VerCount;
		num2 += Patterns.Info.TimeCutting * HorCount * VerCount;
		num4 += Patterns.Info.TotalArea * HorCount * VerCount;
		num3 += Patterns.Info.UsedPersentageFromBoxArea;
		Info = Info + buLangTranslate.preDef.Pattern + " " + buLangTranslate.preDef.Information + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " : " + num.ToString("f3") + " " + UnitLength.ToString() + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Time + " : " + num2.ToString("f3") + " " + buLangTranslate.preDef.Second + "   -  " + buLangTranslate.preDef.Pattern + " %" + num3.ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Block + " " + buLangTranslate.preDef.Information + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Block + " %" + (num4 / num6 * 100.0).ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Foam + " " + buLangTranslate.preDef.Information + Environment.NewLine;
		Info = Info + buLangTranslate.preDef.Block + " %" + (num4 / num5 * 100.0).ToString("f3") + " " + buLangTranslate.preDef.Efficiency + Environment.NewLine;
	}

	public void BlocksInfo(List<FoamBlock> Blocks)
	{
	}

	public Plane ConvertPlane(FoamPlaneType refPlane)
	{
		if (refPlane != FoamPlaneType.XZ)
		{
			return Plane.YZ;
		}
		return Plane.XZ;
	}

	public string SequenceToExplanation(FoamSequenceHor Seq)
	{
		string result = "";
		if (Seq == FoamSequenceHor.HorizontalStartThenEnd)
		{
			result = "Horizontal Sequence Start Then End";
		}
		if (Seq == FoamSequenceHor.HorizontalStartThenStart)
		{
			result = "Horizontal Sequence Start Then Start";
		}
		if (Seq == FoamSequenceHor.HorizontalStartThenStartDirect)
		{
			result = "Horizontal Sequence Start Then Start Direct";
		}
		return result;
	}

	public string SequenceToExplanation(FoamSequenceVer Seq)
	{
		string result = "";
		if (Seq == FoamSequenceVer.VerticalStartThenEnd)
		{
			result = "Vertical Sequence Start Then End";
		}
		if (Seq == FoamSequenceVer.VerticalStartThenStart)
		{
			result = "Vertical Sequence Start Then Start";
		}
		if (Seq == FoamSequenceVer.VerticalStartThenStartDirect)
		{
			result = "Vertical Sequence Start Then Start Direct";
		}
		return result;
	}

	public string JobItemName(FoamItem Item)
	{
		string text = buLangTranslate.preDef.Foam;
		if (Item.ItemName.Trim().Length > 0)
		{
			text = Item.ItemName.Trim();
		}
		return text + " - " + buLangTranslate.preDef.Width + "(X) : " + Item.Material.Size.Width + " - " + buLangTranslate.preDef.Height + "(Y) : " + Item.Material.Size.Height + " - " + buLangTranslate.preDef.Depth + "(Z) : " + Item.Material.Size.Depth;
	}

	public string JobBlockName(FoamBlock Item)
	{
		string text = buLangTranslate.preDef.Block;
		if (Item.BlockName.Trim().Length > 0)
		{
			text = Item.BlockName.Trim();
		}
		return text + " -  Z: " + Item.BottomZ.ToString("f1") + " - " + buLangTranslate.preDef.Width + "(X) : " + Item.SizeObj.Width + " - " + buLangTranslate.preDef.Height + "(Y) : " + Item.SizeObj.Height + " - " + buLangTranslate.preDef.Depth + "(Z) : " + Item.SizeObj.Depth;
	}

	public string JobPatternName(FoamPattern Item)
	{
		string text = buLangTranslate.preDef.Pattern;
		if (Item.PatternName.Trim().Length > 0)
		{
			text = Item.PatternName.Trim();
		}
		string text2 = "";
		string text3 = "";
		string text4 = buLangTranslate.preDef.Height + ": " + Item.Height;
		string text5 = "";
		string position = buLangTranslate.preDef.Position;
		double z = Item.BoxMinItem.Z;
		string text6 = "Z " + position + ": " + z;
		if (Item.planeName == FoamPlaneType.XZ)
		{
			string sequence = buLangTranslate.preDef.Sequence;
			int horizontalIndex = Item.HorizontalIndex;
			text2 = "X " + sequence + ": " + horizontalIndex;
			string position2 = buLangTranslate.preDef.Position;
			z = Item.BoxMinItem.X;
			text5 = "X " + position2 + ": " + z;
			text3 = buLangTranslate.preDef.Width + ": " + Item.Width;
		}
		if (Item.planeName == FoamPlaneType.YZ)
		{
			string sequence2 = buLangTranslate.preDef.Sequence;
			int horizontalIndex = Item.HorizontalIndex;
			text2 = "Y " + sequence2 + ": " + horizontalIndex;
			string position3 = buLangTranslate.preDef.Position;
			z = Item.BoxMinItem.Y;
			text5 = "Y " + position3 + ": " + z;
			text3 = buLangTranslate.preDef.Width + ": " + Item.Width;
		}
		return text + " - " + text2 + " - Z: " + Item.VerticalIndex + " - " + text3 + text4 + text5 + text6;
	}

	public int JobPatternImageIndex(FoamPattern OP)
	{
		if (OP.Type != FoamType.VForm)
		{
			if (OP.Type != FoamType.SForm)
			{
				if (OP.Type != FoamType.FromDrawing)
				{
					if (OP.Type != FoamType.SlicesHorizontal)
					{
						if (OP.Type != FoamType.SingleLine)
						{
							return -1;
						}
						return 8;
					}
					return 7;
				}
				return 6;
			}
			return 5;
		}
		return 4;
	}
}
