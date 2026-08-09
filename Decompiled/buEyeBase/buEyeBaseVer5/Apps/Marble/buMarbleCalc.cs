using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buControls.Components;
using buCore;
using buEyeBaseVer5.Forms.Marble;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns71;

namespace buEyeBaseVer5.Apps.Marble;

public class buMarbleCalc
{
	[CompilerGenerated]
	private sealed class Class184
	{
		public Vector3D vector3D_0;

		internal (double, double) method_0(buEntity buEntity_0)
		{
			double val = Vector3D.Dot(vector3D_0, buEntity_0.StartPoint);
			double val2 = Vector3D.Dot(vector3D_0, buEntity_0.EndPoint);
			return (Math.Min(val, val2), Math.Max(val, val2));
		}
	}

	private string string_0 = "buMarbleCalc";

	[CompilerGenerated]
	private OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler_0;

	public static MarbleItemSettings varOperation = new MarbleItemSettings();

	public static MarbleMachineSettings varMarbleMachineSettings = new MarbleMachineSettings();

	public static MarbleProgramSettings varMarbleSettings = new MarbleProgramSettings();

	public static MarbleRuntimeSettings varMarbleRunSettings = new MarbleRuntimeSettings();

	public static MarbleDisplaySettings varMarbleDisplaySettings = new MarbleDisplaySettings();

	public static MarbleColorSettings varMarbleColorSettings = new MarbleColorSettings();

	public static MarbleControlColorSettings varMarbleControlColorSettings = new MarbleControlColorSettings();

	public static MarbleEntitiesSettings varMarbleEntitiesSettings = new MarbleEntitiesSettings();

	public static MarbleDrawingSetting varMarbleDrawSettings = new MarbleDrawingSetting();

	public static MarbleImageSettings varImageSettings = new MarbleImageSettings();

	public static MarbleCountertopSettings varCountertopSettings = new MarbleCountertopSettings();

	public static marbleCounterTopParameter varCountertopParameter = new marbleCounterTopParameter();

	public static List<GeometryTableItem> CircularShapeResolutions = new List<GeometryTableItem>();

	public static List<CircularSpeedReduction> CircularSpeedReductions = new List<CircularSpeedReduction>();

	public static marbleCounterTopPars runCountertopData = new marbleCounterTopPars();

	public static List<List<Pnt3D>> pntTeachGrids = new List<List<Pnt3D>>();

	public static MarbleSelection SelectedItem = new MarbleSelection();

	public static ToolBase5 activeToolSaw = new ToolBase5();

	public static ToolBase5 activeToolMilling = new ToolBase5();

	public static ToolBase5 activeToolMillingHead = new ToolBase5();

	public static ToolBase5 activeToolWaterjet = new ToolBase5();

	public static ToolBase5 activeToolAirDry = new ToolBase5();

	public static ToolBase5 activeToolLaserPointer = new ToolBase5();

	public static List<ToolBase5> ToolInMagazine = null;

	public static List<ToolBase5> ToolMillings = null;

	public static List<ToolBase5> ToolMillingHeads = null;

	public static List<ToolBase5> ToolSaws = null;

	public static marbleCounterTopBase activeCountertop = null;

	public static marbleCounterTopItem activeCountertopItem = new marbleCounterTopItem();

	public static marbleEdgeItem activeCountertopEdge = new marbleEdgeItem();

	public static marbleCountertopCornerPars activeCountertopCorner = new marbleCountertopCornerPars();

	public static marbleCounterTopItem newCountertopItem = new marbleCounterTopItem();

	public static buEntitiesGroup CountertopRefEntGroup = null;

	public static List<MarbleJob> UndoJobList = new List<MarbleJob>();

	public static List<List<MarbleItem>> UndoList = new List<List<MarbleItem>>();

	public static List<marbleMaterialType> MaterialList = new List<marbleMaterialType>();

	public static buEnableTwoValueList CountertopEdgeControl = null;

	public event OkCommandWithFiveDataEventHandler MarbleCalcCommandSend
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Combine(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler = okCommandWithFiveDataEventHandler_0;
			OkCommandWithFiveDataEventHandler okCommandWithFiveDataEventHandler2;
			do
			{
				okCommandWithFiveDataEventHandler2 = okCommandWithFiveDataEventHandler;
				OkCommandWithFiveDataEventHandler value2 = (OkCommandWithFiveDataEventHandler)Delegate.Remove(okCommandWithFiveDataEventHandler2, value);
				okCommandWithFiveDataEventHandler = Interlocked.CompareExchange(ref okCommandWithFiveDataEventHandler_0, value2, okCommandWithFiveDataEventHandler2);
			}
			while ((object)okCommandWithFiveDataEventHandler != okCommandWithFiveDataEventHandler2);
		}
	}

	public buMarbleCalc()
	{
		if (!buVector5.smethod_0("buMarbleCalc"))
		{
			throw new RegisterException("buMarbleCalc");
		}
	}

	public void GetSurfaceData(MarbleItem Item, ref List<List<buEntity>> calcEntities)
	{
		for (int i = 0; i <= Item.ItemEntities.WireEntities.Count - 1; i++)
		{
			List<buEntity> list = new List<buEntity>();
			List<Point3D> Points = new List<Point3D>();
			EntitiesResolution entitiesResolution = new EntitiesResolution();
			entitiesResolution.ArcResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.CircleResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.CurveResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.EllipseResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.LineResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.OtherResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			entitiesResolution.PolylineResolution = new EntityResolution(Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
			buCall.buVector5_0.EntitiesToPointsWithCamDirection(Item.ItemEntities.WireEntities[i], 0.01, ref Points);
			Points[Points.Count - 1] = new Point3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
			for (int j = 0; j <= Points.Count - 1; j++)
			{
				double num = 0.0;
				int num2 = Convert.ToInt32(Points[j].X);
				int num3 = Convert.ToInt32(Points[j].Y);
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (num3 < 0)
				{
					num3 = 0;
				}
				if (((num3 >= 0) & (num3 <= pntTeachGrids.Count - 1)) && ((num2 >= 0) & (num2 <= pntTeachGrids[num3].Count - 1)))
				{
					num = pntTeachGrids[num3][num2].Z;
				}
				Points[j] = new Point3D(Points[j].X, Points[j].Y, Points[j].Z + num);
			}
			buLinearPath buLinearPath2 = new buLinearPath(Points);
			buLinearPath2.Orientation = new OrientationAngle(Item.ItemEntities.WireEntities[i][0].Orientation);
			list.Add(buLinearPath2);
			calcEntities.Add(list);
		}
	}

	public void KinematicCalc(KinematicBase5 refKinematic, ToolBase5 Tool, ref KinematicBase5 Kinematic)
	{
		double num = Tool.Geometry.Thickness / 2.0;
		if ((Tool.Geometry.SocketThickness > 0.0) & (Tool.Geometry.SocketThickness > Tool.Geometry.Thickness))
		{
			num -= (Tool.Geometry.SocketThickness - Tool.Geometry.Thickness) / 2.0;
		}
		Kinematic = new KinematicBase5(refKinematic);
		Kinematic.RotateCenterOffsetOfA.Y = Kinematic.RotateCenterOffsetOfA.Y + Tool.Geometry.ShoulderThickness + num;
		Kinematic.RotateCenterOffsetOfC.Y = Kinematic.RotateCenterOffsetOfC.Y + Tool.Geometry.ShoulderThickness + num;
	}

	public void CalculateMarbleWireFrameWithSaw(KinematicBase5 refKinematic, ToolBase5 Tool, MarbleJob Job, int indexBase, bool isLast, TpPnt9D LastP9, ref MarbleItem Item, ref MarbleItemCam marbleCam)
	{
		try
		{
			KinematicBase5 Kinematic = new KinematicBase5(refKinematic);
			KinematicCalc(refKinematic, Tool, ref Kinematic);
			bool useTangentLimit = Item.Settings.settingMarbleCam.UseTangentLimit;
			double angleCLimit = Item.Settings.settingMarbleCam.AngleCLimit;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			int num5 = 0;
			Point3D point3D = new Point3D();
			camTp camTp2 = new camTp();
			camTpPoint camTpPoint2 = new camTpPoint();
			List<List<buEntity>> calcEntities = new List<List<buEntity>>();
			List<List<Pnt6D>> list = new List<List<Pnt6D>>();
			int num6 = 1;
			int num7 = 0;
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			if (LastP9 == null)
			{
				if (Job != null)
				{
					int ItemIndex = -1;
					GetItemIndexFromItemID(Job, Item.ID, ref ItemIndex);
					if (ItemIndex < 1 || ItemIndex > Job.Items.Count - 1)
					{
						if (Job.Items.Count > 0)
						{
							MarbleItem marbleItem = Job.Items[Job.Items.Count - 1];
							if (marbleItem.CamList.Count > 0)
							{
								MarbleItemCam marbleItemCam = marbleItem.CamList[marbleItem.CamList.Count - 1];
								if (marbleItemCam.CamBase != null)
								{
									TpPnt9D LastP10 = null;
									buCall.buCam5_0.GetLastPointOfCam(marbleItemCam.CamBase, ref LastP10);
									if (LastP10 != null)
									{
										pnt6D = new Pnt6D(LastP10.P9.X, LastP10.P9.Y, LastP10.P9.Z, LastP10.P9.A, LastP10.P9.B, LastP10.P9.C);
									}
								}
							}
						}
					}
					else
					{
						MarbleItem marbleItem2 = Job.Items[ItemIndex];
						if (marbleItem2.CamList.Count > 0)
						{
							MarbleItemCam marbleItemCam2 = marbleItem2.CamList[marbleItem2.CamList.Count - 1];
							if (marbleItemCam2.CamBase != null)
							{
								TpPnt9D LastP11 = null;
								buCall.buCam5_0.GetLastPointOfCam(marbleItemCam2.CamBase, ref LastP11);
								if (LastP11 != null)
								{
									pnt6D = new Pnt6D(LastP11.P9.X, LastP11.P9.Y, LastP11.P9.Z, LastP11.P9.A, LastP11.P9.B, LastP11.P9.C);
								}
							}
						}
					}
				}
			}
			else
			{
				pnt6D = new Pnt6D(LastP9.P9.X, LastP9.P9.Y, LastP9.P9.Z, LastP9.P9.A, LastP9.P9.B, LastP9.P9.C);
			}
			if (!(Item.Settings.ReadSurfaceParameter.ApplySurfaceReadData & (Item.Settings.ReadSurfaceParameter.SurfaceReadDevideLength > 0.0) & (pntTeachGrids.Count > 0)))
			{
				if (!((Item.ItemType == MarbleItemType.Contour) | (Item.ItemType == MarbleItemType.Shape)))
				{
					for (int i = 0; i <= marbleCam.WireEntities.Count - 1; i++)
					{
						List<buEntity> list2 = new List<buEntity>();
						for (int j = 0; j <= marbleCam.WireEntities[i].Count - 1; j++)
						{
							marbleCam.WireEntities[i][j].Info.Enable = true;
							if (marbleCam.WireEntities[i][j].Info.Enable)
							{
								buEntity copiedEntity = null;
								buEntity.Copy(marbleCam.WireEntities[i][j], ref copiedEntity);
								if (copiedEntity.Orientation.A < 0.0)
								{
									copiedEntity.Orientation.A = 0.0 - copiedEntity.Orientation.A;
									buCall.buVector5_0.ChangeEntitiesDirection(ref copiedEntity);
								}
								list2.Add(copiedEntity);
							}
						}
						if (list2.Count > 0)
						{
							calcEntities.Add(list2);
						}
					}
				}
				else
				{
					ExtendFunctionCalculation(ref Item, ref marbleCam);
					List<List<buEntity>> calcEntities2 = new List<List<buEntity>>();
					List<List<buEntity>> calcEntitiesStrip = new List<List<buEntity>>();
					ExtensionCalculation(ref marbleCam, ref calcEntities2, ref calcEntitiesStrip);
					if (varOperation.settingMarbleCam.CutSameDirection)
					{
						SortCuttingFirstSameDirection(ref calcEntities2);
					}
					if (calcEntitiesStrip.Count > 0)
					{
						for (int k = 0; k <= calcEntitiesStrip.Count - 1; k++)
						{
							calcEntities.Add(calcEntitiesStrip[k]);
						}
					}
					if (calcEntities2.Count > 0)
					{
						for (int l = 0; l <= calcEntities2.Count - 1; l++)
						{
							for (int m = 0; m <= calcEntities2[l].Count - 1; m++)
							{
								if (calcEntities2[l][m].Orientation.A < 0.0)
								{
									buEntity ChangedEntities = calcEntities2[l][m];
									ChangedEntities.Orientation.A = 0.0 - ChangedEntities.Orientation.A;
									buCall.buVector5_0.ChangeEntitiesDirection(ref ChangedEntities);
								}
							}
							calcEntities.Add(calcEntities2[l]);
						}
					}
				}
			}
			else
			{
				GetSurfaceData(Item, ref calcEntities);
			}
			camTp2.Tool = new ToolBase5(Tool);
			camTp2.Kinematic = new KinematicBase5(Kinematic);
			camTp2.Kinematic.MovePartRuntimeOffset.X = 0.0;
			camTp2.Kinematic.MovePartRuntimeOffset.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
			camTp2.Kinematic.MovePartRuntimeOffset.Z = 0.0 - Kinematic.RotateCenterOffsetOfC.Z;
			marbleCam.CamBase = new camTp();
			if (Item.ItemEntities.ExtensionEntities == null)
			{
				Item.ItemEntities.ExtensionEntities = new List<buEntity>();
			}
			Item.ItemEntities.ExtensionEntities.Clear();
			if (calcEntities.Count <= 10)
			{
				num6 = 1;
			}
			num3 = Item.Settings.MaterialParameter.MaterialThickness;
			num = Item.Settings.settingMarbleCam.SawSafeDistance;
			if (Item.MaterialThickness > 0.0)
			{
				num3 = Item.MaterialThickness;
				num = num3 + Item.Settings.settingMarbleCam.SawSafeDistance;
			}
			if (num <= num3 + 10.0)
			{
				num = num3 + 10.0;
			}
			num2 = num3 + Item.Settings.settingMarbleCam.SawRapidDistance;
			if (num < num2)
			{
				num = num2;
			}
			bool flag = false;
			for (int n = 0; n <= calcEntities.Count - 1; n++)
			{
				List<Pnt6D> list3 = new List<Pnt6D>();
				list = new List<List<Pnt6D>>();
				_ = camTpPoint2.Points.Count;
				bool isInside = false;
				bool flag2 = false;
				bool flag3 = false;
				bool flag4 = false;
				bool flag5 = false;
				bool flag6 = false;
				List<string> list4 = new List<string>();
				double num8 = 1.0;
				if (calcEntities[n].Count > 0 && ((calcEntities[n][0] is buCircle) | (calcEntities[n][0] is buArc) | (calcEntities[n][0] is buEllipse)))
				{
					num8 = CircularSpeedReductionCalculate(calcEntities[n][0]);
				}
				if (n < calcEntities.Count - 1 && calcEntities[n + 1].Count > 0 && calcEntities[n + 1][0].Info.Commands != null)
				{
					for (int num9 = 0; num9 <= calcEntities[n + 1][0].Info.Commands.Count - 1; num9++)
					{
						if (calcEntities[n + 1][0].Info.Commands[num9] == EntityCommands.DontMoveSafe.ToString())
						{
							flag6 = true;
						}
					}
				}
				if (calcEntities[n].Count > 0 && calcEntities[n][0].Info.Commands != null)
				{
					for (int num10 = 0; num10 <= calcEntities[n][0].Info.Commands.Count - 1; num10++)
					{
						if (calcEntities[n][0].Info.Commands[num10] == EntityCommands.BackwardCut.ToString())
						{
							flag3 = true;
						}
						if (calcEntities[n][0].Info.Commands[num10] == EntityCommands.FirstStep.ToString())
						{
							flag4 = true;
						}
						if (calcEntities[n][0].Info.Commands[num10] == EntityCommands.LastStep.ToString())
						{
							isLast = true;
						}
						if (calcEntities[n][0].Info.Commands[num10] == EntityCommands.CircularMove.ToString())
						{
							flag2 = true;
						}
						if (calcEntities[n][0].Info.Commands[num10] == EntityCommands.DontMoveSafe.ToString())
						{
							flag5 = true;
						}
					}
				}
				if (calcEntities[n].Count > 0 && calcEntities[n][0].Info.Options != null)
				{
					for (int num11 = 0; num11 <= calcEntities[n][0].Info.Options.Count - 1; num11++)
					{
						list4.Add("(" + calcEntities[n][0].Info.Options[num11] + ")");
					}
				}
				if (calcEntities[n].Count >= 1)
				{
					double num12 = 0.0;
					List<Pnt6D> Points = new List<Pnt6D>();
					new List<Pnt6D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(calcEntities[n], ref Points, CircularShapeResolutions, CircleFrom270: true);
					if (flag3 && calcEntities[n].Count > 0 && ((calcEntities[n][0] is buCircle) | (calcEntities[n][0] is buEllipse)))
					{
						Points.Reverse();
					}
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points);
					if (calcEntities[n][0].Marble != null && calcEntities[n][0].Marble.isInside)
					{
						isInside = calcEntities[n][0].Marble.isInside;
					}
					if (calcEntities[n][0].Info.OffsetABC != null)
					{
						num12 = calcEntities[n][0].Info.OffsetABC.C;
					}
					if (Points.Count > 1)
					{
						double num13 = 0.0;
						double num14 = 0.0;
						double value = 0.0;
						double num15 = 0.0;
						double num16 = 0.0;
						double num17 = 0.0;
						double num18 = 0.0;
						if (n == 0)
						{
							num13 = calcEntities[n][0].Orientation.C;
						}
						num15 = buCall.buVector5_0.PointAngle(new Point3D(Points[1].X, Points[1].Y, Points[1].Z), new Point3D(Points[0].X, Points[0].Y, Points[0].Z));
						if (Item.Settings.settingMarbleCam.UseCZero)
						{
							num15 = 0.0;
						}
						num15 += Item.Settings.settingMarbleCam.OffsetAngleC + num12;
						num14 = Math.Abs(num15 - num13);
						if (num14 > 185.0)
						{
							num15 = ((num13 > num15) ? (num15 + 360.0) : (num15 - 360.0));
						}
						if (num15 > Item.Settings.settingMarbleCam.AngleCMax)
						{
							num15 -= 360.0;
						}
						if (num15 < Item.Settings.settingMarbleCam.AngleCMin)
						{
							num15 += 360.0;
						}
						if (Item.Settings.settingMarbleCam.UseConstantCAngle)
						{
							num15 = Item.Settings.settingMarbleCam.ConstantAngleC;
						}
						num13 = num15;
						list3.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, num15));
						for (int num19 = 1; num19 <= Points.Count - 2; num19++)
						{
							if (num19 != Points.Count - 2)
							{
							}
							bool flag7 = false;
							if (!(buCompare5.EQ(Points[num19].Z, Points[num19 - 1].Z) | Item.Settings.settingMarbleCam.DontCheckZValues))
							{
								list3 = new List<Pnt6D>();
								list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
								continue;
							}
							num15 = buCall.buVector5_0.PointAngle(new Point3D(Points[num19].X, Points[num19].Y, Points[num19].Z), new Point3D(Points[num19 - 1].X, Points[num19 - 1].Y, Points[num19 - 1].Z));
							if (Item.Settings.settingMarbleCam.UseCZero)
							{
								num15 = 0.0;
							}
							num15 += Item.Settings.settingMarbleCam.OffsetAngleC + num12;
							if (num15 > Item.Settings.settingMarbleCam.AngleCMax)
							{
								num15 -= 360.0;
							}
							if (num15 < Item.Settings.settingMarbleCam.AngleCMin)
							{
								num15 += 360.0;
							}
							if (Item.Settings.settingMarbleCam.UseConstantCAngle)
							{
								num15 = Item.Settings.settingMarbleCam.ConstantAngleC;
							}
							if (!Item.Settings.settingMarbleCam.NoAngleCAxisCheck)
							{
								if (!useTangentLimit)
								{
									angleCLimit = Item.Settings.settingMarbleCam.AngleCLimit;
									num17 = buCall.buVector5_0.AngleOfTwoLines(buConversion5.Pnt6DToPoint3D(list3[list3.Count - 1]), buConversion5.Pnt6DToPoint3D(Points[num19]), buConversion5.Pnt6DToPoint3D(Points[num19]), buConversion5.Pnt6DToPoint3D(Points[num19 + 1]), Plane.XY);
									num18 = 180.0 - num17;
									if (num18 >= 360.0 - angleCLimit)
									{
										num18 = 360.0 - num17;
									}
									num16 = buCall.buVector5_0.PointAngle(buConversion5.Pnt6DToPoint3D(Points[num19 + 1]), buConversion5.Pnt6DToPoint3D(Points[num19]));
									if (Item.Settings.settingMarbleCam.UseCZero)
									{
										num16 = 0.0;
									}
									if (num18 > angleCLimit)
									{
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19 + 1].A, 0.0, num16));
										flag7 = true;
									}
									Math.Abs(num15 - num13);
									if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
									{
										list.Add(list3);
										list3 = new List<Pnt6D>();
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num16));
										flag7 = true;
									}
								}
								else
								{
									value = Points[num19 - 1].A - Points[num19].A;
									num14 = Math.Abs(num15 - list3[list3.Count - 1].C);
									if (num14 > 185.0)
									{
										num15 = ((list3[list3.Count - 1].C > num15) ? (num15 + 360.0) : (num15 - 360.0));
									}
									num16 = buCall.buVector5_0.PointAngle(new Point3D(Points[num19 + 1].X, Points[num19 + 1].Y, Points[num19 + 1].Z), new Point3D(Points[num19].X, Points[num19].Y, Points[num19].Z));
									if (Item.Settings.settingMarbleCam.UseCZero)
									{
										num16 = 0.0;
									}
									num16 += Item.Settings.settingMarbleCam.OffsetAngleC + num12;
									angleCLimit = Item.Settings.settingMarbleCam.AngleCLimit;
									num17 = buCall.buVector5_0.AngleOfTwoLines(buConversion5.Pnt6DToPoint3D(list3[list3.Count - 1]), buConversion5.Pnt6DToPoint3D(Points[num19]), buConversion5.Pnt6DToPoint3D(Points[num19]), buConversion5.Pnt6DToPoint3D(Points[num19 + 1]), Plane.XY);
									num18 = 180.0 - num17;
									if (num18 >= 360.0 - angleCLimit)
									{
										num18 = 360.0 - num17;
									}
									Math.Abs(num15 - num13);
									if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
									{
										list.Add(list3);
										list3 = new List<Pnt6D>();
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num16));
										flag7 = true;
									}
								}
								if (!flag7)
								{
									if (!(num18 > angleCLimit && useTangentLimit))
									{
										double num20 = 0.0;
										if (useTangentLimit)
										{
											num20 = Math.Abs(num15 - list3[list3.Count - 1].C);
											if (num20 >= 360.0 - angleCLimit)
											{
												num15 = ((num15 > list3[list3.Count - 1].C) ? (num15 - 360.0) : (num15 + 360.0));
												num20 = Math.Abs(num15 - list3[list3.Count - 1].C);
											}
											if (num20 > 185.0)
											{
												num15 += 360.0;
											}
										}
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
										if (Math.Abs(num15 - num16) > 180.1)
										{
											double num21 = num15 - num16;
											if (!(num15 > num16))
											{
												num16 -= 360.0;
												num21 = num15 - num16;
												double num22 = buNumeric5.RoundToLower(Math.Abs(num21) / 360.0);
												num16 -= num22 * 360.0;
											}
											else
											{
												num16 += 360.0;
												num21 = num15 - num16;
												double num23 = buNumeric5.RoundToLower(Math.Abs(num21) / 360.0);
												num16 += num23 * 360.0;
											}
										}
										if (Item.Settings.settingMarbleCam.AngleCMin != Item.Settings.settingMarbleCam.AngleCMax)
										{
											if (num16 > Item.Settings.settingMarbleCam.AngleCMax)
											{
												list.Add(list3);
												num15 -= 360.0;
												list3 = new List<Pnt6D>();
												list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
											}
											if (num16 < Item.Settings.settingMarbleCam.AngleCMin)
											{
												list.Add(list3);
												num15 += 360.0;
												list3 = new List<Pnt6D>();
												list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
											}
										}
									}
									else
									{
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
										list.Add(list3);
										list3 = new List<Pnt6D>();
										list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19 + 1].A, 0.0, num16));
									}
								}
							}
							else
							{
								list3.Add(new Pnt6D(Points[num19].X, Points[num19].Y, Points[num19].Z, Points[num19].A, 0.0, num15));
							}
							num13 = num15;
						}
						if (list3.Count > 0)
						{
							num15 = buCall.buVector5_0.PointAngle(buConversion5.Pnt6DToPoint3D(Points[Points.Count - 1]), buConversion5.Pnt6DToPoint3D(Points[Points.Count - 2]));
							if (Item.Settings.settingMarbleCam.UseCZero)
							{
								num15 = 0.0;
							}
							num15 += Item.Settings.settingMarbleCam.OffsetAngleC + num12;
							if (num15 > Item.Settings.settingMarbleCam.AngleCMax)
							{
								num15 -= 360.0;
							}
							if (num15 < Item.Settings.settingMarbleCam.AngleCMin)
							{
								num15 += 360.0;
							}
							if (Item.Settings.settingMarbleCam.UseConstantCAngle)
							{
								num15 = Item.Settings.settingMarbleCam.ConstantAngleC;
							}
							double num24 = Math.Abs(num15 - list3[list3.Count - 1].C);
							double num25 = Math.Round(num24 / 360.0, 0);
							if (num25 < 1.0)
							{
								num25 = 1.0;
							}
							if (num24 >= 360.0 - angleCLimit)
							{
								num24 = 360.0 - num15;
								if (num15 > list3[list3.Count - 1].C)
								{
									num15 -= 360.0 * num25;
								}
							}
							if (num24 > 185.0)
							{
								num15 += 360.0;
							}
							list3.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, num15));
							list.Add(list3);
						}
					}
				}
				if (list.Count == 2)
				{
					double num26 = buCall.buVector5_0.Length3D(list[1][list[1].Count - 1], list[0][0]);
					double num27 = Math.Abs(list[1][list[1].Count - 1].C - list[0][0].C);
					if (num26 < 5.0 && num27 < 2.0)
					{
						List<Pnt6D> list5 = new List<Pnt6D>();
						list5.AddRange(list[1]);
						list[0].RemoveAt(0);
						list5.AddRange(list[0]);
						list.Clear();
						list = new List<List<Pnt6D>>();
						list.Add(list5);
					}
				}
				for (int num28 = 0; num28 <= list.Count - 1; num28++)
				{
					double toolLength = Tool.Geometry.Diameter / 2.0;
					double num29 = 0.0;
					double num30 = 0.0;
					double num31 = 0.0;
					Pnt6D pnt6D2 = new Pnt6D();
					new Pnt6D();
					Pnt6D pnt6D3 = new Pnt6D();
					Point3D point3D2 = new Point3D();
					Point3D point3D3 = new Point3D();
					Point3D point3D4 = new Point3D();
					OrientationAngle orientationAngle = new OrientationAngle();
					OrientationAngle orientationAngle2 = new OrientationAngle();
					num = Item.Settings.settingMarbleCam.SawSafeDistance;
					if (num < num2)
					{
						num = num2;
					}
					if (num <= num3 + 10.0)
					{
						num = num3 + 10.0;
					}
					camTpPoint2 = new camTpPoint();
					if (list4.Count > 0)
					{
						camTpPoint2.PreCodes.AddRange(list4);
					}
					camTpPoint2.Type = 0;
					pnt6D2 = new Pnt6D(list[num28][0]);
					point3D2 = buVector5.ToPoint3D(pnt6D2);
					orientationAngle = new OrientationAngle(pnt6D2);
					num29 = Item.Settings.settingMarbleCam.SawForwardCuttingVelocity;
					num30 = Item.Settings.settingMarbleCam.SawPlungeVelocity;
					num31 = Item.Settings.settingMarbleCam.SawLeaveVelocity;
					if (flag3)
					{
						num29 = Item.Settings.settingMarbleCam.SawBackwardCuttingVelocity;
					}
					if (flag2)
					{
						num29 = Item.Settings.settingMarbleCam.SawForwardCircularCuttingVelocity;
						if (flag3)
						{
							num29 = Item.Settings.settingMarbleCam.SawBackwardCircularCuttingVelocity;
						}
					}
					if (flag4)
					{
						num29 = Item.Settings.settingMarbleCam.SawForwardFirstCuttingVelocity;
						if (flag2)
						{
							num29 = Item.Settings.settingMarbleCam.SawForwardCircularFirstCuttingVelocity;
						}
						num30 = Item.Settings.settingMarbleCam.SawPlungeFirstVelocity;
					}
					num29 *= num8;
					num4 = (Item.Settings.settingMarbleCam.AlwaysSafeDistance ? (num / Math.Cos(buConversion5.DegreeToRadian(orientationAngle.A))) : ((!(num5 == 0 && indexBase == 0)) ? (num2 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(orientationAngle.A)))) : (Item.Settings.settingMarbleCam.isFirstCutSafeDistance ? (num / Math.Cos(buConversion5.DegreeToRadian(orientationAngle.A))) : (num2 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(orientationAngle.A)))))));
					num4 -= point3D2.Z;
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithOrientationAngle(point3D2, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), num4, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle, buVector5.ToPoint3D(point3D3), ApplyOffset: true, ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					pnt6D3.Z = pnt6D3.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
					if (orientationAngle.A != pnt6D.A && (LastP9 != null || num5 > 0))
					{
						if (!(pnt6D.Z > pnt6D3.Z))
						{
							Pnt6D p = new Pnt6D(pnt6D.X, pnt6D.Y, pnt6D3.Z, pnt6D.A, pnt6D.B, pnt6D.C);
							camTpPoint2.Points.Add(new TpPnt9D(p, Item.Settings.settingMarbleCam.QuickVelocity, 0));
						}
						else
						{
							Pnt6D p2 = new Pnt6D(pnt6D3.X, pnt6D3.Y, pnt6D.Z, pnt6D3.A, pnt6D3.B, pnt6D3.C);
							camTpPoint2.Points.Add(new TpPnt9D(p2, Item.Settings.settingMarbleCam.QuickVelocity, 0));
						}
					}
					if (!(indexBase == 0 && num5 == 0))
					{
						if (LastP9 == null)
						{
							if (flag5)
							{
								if (!flag)
								{
									camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 0, plungemove: true));
								}
							}
							else
							{
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 0, plungemove: true));
							}
						}
						else if (!buCompare5.EQ(pnt6D3, LastP9))
						{
							if (!buCompare5.EQ(pnt6D3.A, LastP9.P9.A))
							{
								if (!(buCompare5.EQ(pnt6D3.X, LastP9.P9.X, 0.01) & buCompare5.EQ(pnt6D3.Y, LastP9.P9.Y, 0.01)))
								{
									camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, Item.Settings.settingMarbleCam.QuickVelocity, 0));
								}
								else
								{
									camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 1));
								}
							}
							else if (!(buCompare5.EQ(pnt6D3.X, LastP9.P9.X, 0.01) & buCompare5.EQ(pnt6D3.Y, LastP9.P9.Y, 0.01)))
							{
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, Item.Settings.settingMarbleCam.QuickVelocity, 0));
							}
							else
							{
								camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 1, plungemove: true));
							}
						}
					}
					else
					{
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, Item.Settings.settingMarbleCam.QuickVelocity, 0, plungemove: true));
					}
					point3D = buVector5.ToPoint3D(point3D3);
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithOrientationAngle(point3D2, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), num4, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle, buVector5.ToPoint3D(point3D3), ApplyOffset: true, ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					pnt6D3.Z = pnt6D3.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
					if (flag5)
					{
						if (!flag)
						{
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, Item.Settings.settingMarbleCam.QuickVelocity, 0));
						}
					}
					else
					{
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, Item.Settings.settingMarbleCam.QuickVelocity, 0));
					}
					point3D = buVector5.ToPoint3D(point3D3);
					if (num28 == 0)
					{
						new Pnt6D(pnt6D3);
					}
					pnt6D3 = new Pnt6D();
					point3D4 = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle, buVector5.ToPoint3D(point3D4), ApplyOffset: true, ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					pnt6D3.Z = pnt6D3.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num30, 1));
					Line line = new Line(buVector5.ToPoint3D(point3D), buVector5.ToPoint3D(point3D4));
					line.ColorMethod = colorMethodType.byEntity;
					camTp2.EntitiesPlunge.Add(line);
					point3D = buVector5.ToPoint3D(point3D2);
					List<Point3D> list6 = new List<Point3D>();
					list6.Add(buVector5.ToPoint3D(point3D));
					for (int num32 = 1; num32 <= list[num28].Count - 1; num32++)
					{
						pnt6D2 = new Pnt6D(list[num28][num32]);
						if (num32 == 1)
						{
							pnt6D2.X += 0.0;
							pnt6D2.Y += 0.0;
						}
						orientationAngle = new OrientationAngle(pnt6D2);
						pnt6D3 = new Pnt6D();
						point3D4 = buVector5.ToPoint3D(pnt6D2);
						buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle, point3D4, ApplyOffset: true, ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						pnt6D3.Z = pnt6D3.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num29, 1));
						list6.Add(buVector5.ToPoint3D(point3D4));
						point3D = buVector5.ToPoint3D(pnt6D2);
						pnt6D = new Pnt6D(pnt6D3);
						if (num32 == 1 && Item.Settings.settingMarbleCam.UseG38G39)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].PreCodes.Add("G38 O1");
						}
					}
					if (Item.Settings.settingMarbleCam.UseG38G39)
					{
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("G39 O1");
					}
					if (list6.Count > 0)
					{
						LinearPath linearPath = new LinearPath(buVector5.ToPoint3D(list6));
						linearPath.ColorMethod = colorMethodType.byEntity;
						camTp2.EntitiesG1.Add(linearPath);
					}
					if (((Item.SawExtensionDistance > 0.0) & !varMarbleSettings.DontAddExtensionEntities) && list6.Count > 1)
					{
						Point3D EndPnt = new Point3D();
						double num33 = buCall.buVector5_0.PointAngle(list6[1], list6[0]);
						buCall.buVector5_0.LineWithLengthAndAngle(list6[0], Item.SawExtensionDistance, num33 + 180.0, Plane.XY, ref EndPnt);
						buLine buLine2 = new buLine(new Point3D(list6[0].X, list6[0].Y, 0.1), new Point3D(EndPnt.X, EndPnt.Y, 0.1));
						buLine2.typeDefination = entityTypeDefination.MarbleItem;
						buLine2.Marble = new MarbleInfo();
						Item.ItemEntities.ExtensionEntities.Add(buLine2);
						EndPnt = new Point3D();
						num33 = buCall.buVector5_0.PointAngle(list6[list6.Count - 1], list6[list6.Count - 2]);
						buCall.buVector5_0.LineWithLengthAndAngle(list6[list6.Count - 1], Item.SawExtensionDistance, num33, Plane.XY, ref EndPnt);
						buLine buLine3 = new buLine(new Point3D(list6[list6.Count - 1].X, list6[list6.Count - 1].Y, 0.1), new Point3D(EndPnt.X, EndPnt.Y, 0.1));
						buLine2.typeDefination = entityTypeDefination.MarbleItem;
						buLine3.Marble = new MarbleInfo();
						Item.ItemEntities.ExtensionEntities.Add(buLine3);
					}
					if (orientationAngle.A == orientationAngle2.A)
					{
					}
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					num4 = (Item.Settings.settingMarbleCam.AlwaysSafeDistance ? (num / Math.Cos(buConversion5.DegreeToRadian(orientationAngle.A))) : (num2 / Math.Cos(buConversion5.DegreeToRadian(orientationAngle.A))));
					num4 -= point3D.Z;
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithOrientationAngle(point3D, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), num4, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle, buVector5.ToPoint3D(point3D3), ApplyOffset: true, ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					pnt6D3.Z = pnt6D3.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
					if (flag5)
					{
						if (!flag6)
						{
							camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 1));
						}
					}
					else
					{
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num31, 1));
					}
					line = new Line(point3D, point3D3);
					line.ColorMethod = colorMethodType.byEntity;
					camTp2.EntitiesLeave.Add(line);
					pnt6D = new Pnt6D(pnt6D3);
					if (Item.Settings.settingMarbleCam.AutoWaterOpenClose & (camTpPoint2.Points.Count >= 2))
					{
						camTpPoint2.Points[1].AfterCodes.Add("M8");
						camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M9");
					}
					if (calcEntities[n].Count > 0)
					{
						camTpPoint2.SubSequence = calcEntities[n][0].Marble.Sequence;
					}
					camTpPoint2.isInside = isInside;
					camTp2.CamPoints.Add(camTpPoint2);
					num5++;
				}
				if (buSystem.DoEventEnable && num6 > 0 && num7 > 0 && num7 % num6 == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num7++;
					flag = flag5;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			marbleCam.CamBase = new camTp(camTp2);
			marbleCam.CamBase.Name = marbleCam.CamName;
			marbleCam.CamType = CamType.Contour;
			marbleCam.ToolSelected = Tool;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculatePointsWithKinematic(List<Pnt6D> refPoints, KinematicBase5 refKinematic, ToolBase5 Tool, ref List<Pnt6D> calcPoints)
	{
		try
		{
			KinematicBase5 Kinematic = new KinematicBase5(refKinematic);
			KinematicCalc(refKinematic, Tool, ref Kinematic);
			double toolLength = Tool.Geometry.Diameter / 2.0;
			for (int i = 0; i <= refPoints.Count - 1; i++)
			{
				_ = refPoints[i];
				OrientationAngle orientation = new OrientationAngle(refPoints[i].A, refPoints[i].B, refPoints[i].C);
				Pnt6D CalcPoint = new Pnt6D();
				Point3D movePoint = buVector5.ToPoint3D(refPoints[i]);
				buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientation, movePoint, ref CalcPoint);
				CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				CalcPoint.Z = CalcPoint.Z + Kinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
				calcPoints.Add(CalcPoint);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculatePointsWithKinematic(Pnt6D refPoint, KinematicBase5 refKinematic, ToolBase5 Tool, ref Pnt6D calcPoint)
	{
		try
		{
			KinematicBase5 Kinematic = new KinematicBase5(refKinematic);
			KinematicCalc(refKinematic, Tool, ref Kinematic);
			double toolLength = Tool.Geometry.Diameter / 2.0;
			OrientationAngle orientation = new OrientationAngle(refPoint.A, refPoint.B, refPoint.C);
			calcPoint = new Pnt6D();
			Point3D movePoint = buVector5.ToPoint3D(refPoint);
			buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientation, movePoint, ref calcPoint);
			calcPoint.Z = calcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
			calcPoint.Z = calcPoint.Z + refKinematic.OffsetXYZ.Z - Tool.Geometry.Diameter / 2.0;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void SortCuttingFirstSameDirection(ref List<List<buEntity>> calcEntities)
	{
		List<List<buEntity>> list = new List<List<buEntity>>();
		List<List<buEntity>> list2 = new List<List<buEntity>>();
		List<List<buEntity>> list3 = new List<List<buEntity>>();
		List<List<buEntity>> list4 = new List<List<buEntity>>();
		List<List<buEntity>> list5 = new List<List<buEntity>>();
		List<List<buEntity>> list6 = new List<List<buEntity>>();
		for (int i = 0; i <= calcEntities.Count - 1; i++)
		{
			if (calcEntities[i].Count <= 0)
			{
				continue;
			}
			buEntity buEntity2 = calcEntities[i][0];
			if (!(buEntity2 is buLine))
			{
				if (!buCompare5.EQ(buEntity2.Marble.Angle, 0.0, 0.1))
				{
					if (!varOperation.settingMarbleCam.isA45First)
					{
						list5.Add(calcEntities[i]);
					}
					else
					{
						list6.Add(calcEntities[i]);
					}
				}
				else
				{
					list5.Add(calcEntities[i]);
				}
				continue;
			}
			double num = buCall.buVector5_0.PointAngle(buEntity2.EndPoint, buEntity2.StartPoint);
			if (buEntity2.sortDirection == entitySortDirection.Reverse)
			{
				num += 180.0;
			}
			if (!(!buCompare5.EQ(buEntity2.Marble.Angle, 0.0, 0.1) & varOperation.settingMarbleCam.isA45First))
			{
				if (!(buCompare5.EQ(num, 0.0, 0.1) | buCompare5.EQ(num, 360.0, 0.1)))
				{
					if (!(buCompare5.EQ(num, 90.0, 0.1) | buCompare5.EQ(num, 450.0, 0.1)))
					{
						if (!(buCompare5.EQ(num, 180.0, 0.1) | buCompare5.EQ(num, -180.0, 0.1)))
						{
							if (!(buCompare5.EQ(num, 270.0, 0.1) | buCompare5.EQ(num, -90.0, 0.1)))
							{
								list5.Add(calcEntities[i]);
							}
							else
							{
								list4.Add(calcEntities[i]);
							}
						}
						else
						{
							list3.Add(calcEntities[i]);
						}
					}
					else
					{
						list2.Add(calcEntities[i]);
					}
				}
				else
				{
					list.Add(calcEntities[i]);
				}
			}
			else
			{
				list6.Add(calcEntities[i]);
			}
		}
		calcEntities.Clear();
		calcEntities.AddRange(list6);
		if (varOperation.settingMarbleCam.isCircularFirst)
		{
			calcEntities.AddRange(list5);
		}
		calcEntities.AddRange(list);
		calcEntities.AddRange(list3);
		calcEntities.AddRange(list2);
		calcEntities.AddRange(list4);
		if (!varOperation.settingMarbleCam.isCircularFirst)
		{
			calcEntities.AddRange(list5);
		}
	}

	public void SortCuttingFirstSameDirection(ref List<buEntity> calcEntities)
	{
		List<buEntity> list = new List<buEntity>();
		List<buEntity> list2 = new List<buEntity>();
		List<buEntity> list3 = new List<buEntity>();
		List<buEntity> list4 = new List<buEntity>();
		List<buEntity> list5 = new List<buEntity>();
		List<buEntity> list6 = new List<buEntity>();
		for (int i = 0; i <= calcEntities.Count - 1; i++)
		{
			buEntity buEntity2 = calcEntities[i];
			if (!(buEntity2 is buLine))
			{
				if (!buCompare5.EQ(buEntity2.Marble.Angle, 0.0, 0.1))
				{
					if (!varOperation.settingMarbleCam.isA45First)
					{
						list5.Add(calcEntities[i]);
					}
					else
					{
						list6.Add(calcEntities[i]);
					}
				}
				else
				{
					list5.Add(calcEntities[i]);
				}
				continue;
			}
			double num = buCall.buVector5_0.PointAngle(buEntity2.EndPoint, buEntity2.StartPoint);
			if (buEntity2.sortDirection == entitySortDirection.Reverse)
			{
				num += 180.0;
			}
			if (!(!buCompare5.EQ(buEntity2.Marble.Angle, 0.0, 0.1) & varOperation.settingMarbleCam.isA45First))
			{
				if (!(buCompare5.EQ(num, 0.0, 0.1) | buCompare5.EQ(num, 360.0, 0.1)))
				{
					if (!(buCompare5.EQ(num, 90.0, 0.1) | buCompare5.EQ(num, 450.0, 0.1)))
					{
						if (!(buCompare5.EQ(num, 180.0, 0.1) | buCompare5.EQ(num, -180.0, 0.1)))
						{
							if (!(buCompare5.EQ(num, 270.0, 0.1) | buCompare5.EQ(num, -90.0, 0.1)))
							{
								list5.Add(calcEntities[i]);
							}
							else
							{
								list4.Add(calcEntities[i]);
							}
						}
						else
						{
							list3.Add(calcEntities[i]);
						}
					}
					else
					{
						list2.Add(calcEntities[i]);
					}
				}
				else
				{
					list.Add(calcEntities[i]);
				}
			}
			else
			{
				list6.Add(calcEntities[i]);
			}
		}
		calcEntities.Clear();
		calcEntities.AddRange(list6);
		if (varOperation.settingMarbleCam.isCircularFirst)
		{
			calcEntities.AddRange(list5);
		}
		calcEntities.AddRange(list);
		calcEntities.AddRange(list3);
		calcEntities.AddRange(list2);
		calcEntities.AddRange(list4);
		if (!varOperation.settingMarbleCam.isCircularFirst)
		{
			calcEntities.AddRange(list5);
		}
	}

	public void ExtendFunctionCalculation(ref MarbleItem Item, ref MarbleItemCam marbleCam)
	{
		if (Item.Extends.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= Item.Extends.Count - 1; i++)
		{
			if (marbleCam.CamID == Item.Extends[i].CamID && Item.Extends[i].indexWire <= marbleCam.WireEntities.Count - 1 && Item.Extends[i].indexWireSub <= marbleCam.WireEntities[Item.Extends[i].indexWire].Count - 1)
			{
				buEntity copiedEntity = marbleCam.WireEntities[Item.Extends[i].indexWire][Item.Extends[i].indexWireSub];
				if (!buCall.buVector5_0.isEntitySame(copiedEntity, Item.Extends[i].entityExtend))
				{
					Item.Extends[i].entityExtend.Orientation = new OrientationAngle(copiedEntity.Orientation);
					Item.Extends[i].entityExtend.Marble = new MarbleInfo(copiedEntity.Marble);
					buEntity.Copy(Item.Extends[i].entityExtend, ref copiedEntity);
					marbleCam.WireEntities[Item.Extends[i].indexWire][Item.Extends[i].indexWireSub] = copiedEntity;
				}
			}
		}
	}

	public void ExtensionCalculation(ref MarbleItemCam marbleCam, ref List<List<buEntity>> calcEntities, ref List<List<buEntity>> calcEntitiesStrip)
	{
		if (marbleCam.WireAuxEntities != null && marbleCam.WireAuxEntities.Count > 0)
		{
			List<buEntity> list = new List<buEntity>();
			for (int num = marbleCam.WireAuxEntities.Count - 1; num >= 0; num--)
			{
				if (marbleCam.WireAuxEntities[num] != null)
				{
					new List<buEntity>();
					for (int i = 0; i <= marbleCam.WireAuxEntities[num].Count - 1; i++)
					{
						if (marbleCam.WireAuxEntities[num][i] == null)
						{
							continue;
						}
						buEntity copiedEntity = null;
						buEntity.Copy(marbleCam.WireAuxEntities[num][i], ref copiedEntity);
						if (!copiedEntity.Info.Enable)
						{
							continue;
						}
						if (copiedEntity.Orientation.A < 0.0)
						{
							copiedEntity.Orientation.A = 0.0 - copiedEntity.Orientation.A;
							buCall.buVector5_0.ChangeEntitiesDirection(ref copiedEntity);
						}
						if (list.Count != 0)
						{
							if (list[list.Count - 1].Marble.CommandID != copiedEntity.Marble.CommandID)
							{
								for (int j = 0; j <= list.Count - 1; j++)
								{
									List<buEntity> list2 = new List<buEntity>();
									list2.Add(list[j]);
									calcEntitiesStrip.Add(list2);
								}
								list.Clear();
								list.Add(copiedEntity);
							}
							else
							{
								list.Add(copiedEntity);
							}
						}
						else
						{
							list.Add(copiedEntity);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				for (int k = 0; k <= list.Count - 1; k++)
				{
					List<buEntity> list3 = new List<buEntity>();
					list3.Add(list[k]);
					calcEntitiesStrip.Add(list3);
				}
			}
		}
		if (marbleCam.WireEntities != null && marbleCam.WireAuxEntities != null)
		{
			for (int l = 0; l <= marbleCam.WireEntities.Count - 1; l++)
			{
				if (marbleCam.WireEntities[l] == null)
				{
					continue;
				}
				new List<buEntity>();
				for (int m = 0; m <= marbleCam.WireEntities[l].Count - 1; m++)
				{
					if (marbleCam.WireEntities[l][m] == null)
					{
						continue;
					}
					buEntity ChangedEntities = marbleCam.WireEntities[l][m];
					for (int n = 0; n <= marbleCam.WireAuxEntities.Count - 1; n++)
					{
						if (marbleCam.WireAuxEntities[n] == null)
						{
							continue;
						}
						for (int num2 = 0; num2 <= marbleCam.WireAuxEntities[n].Count - 1; num2++)
						{
							if (marbleCam.WireAuxEntities[n][num2] == null)
							{
								continue;
							}
							buEntity buEntity2 = marbleCam.WireAuxEntities[n][num2];
							Point3D pntIntersect = new Point3D();
							if (!buCall.buVector5_0.LineLineIntersection(ChangedEntities.StartPoint, ChangedEntities.EndPoint, buEntity2.StartPoint, buEntity2.EndPoint, Plane.XY, ref pntIntersect))
							{
								continue;
							}
							double num3 = buCall.buVector5_0.Length3D(ChangedEntities.StartPoint, pntIntersect);
							double num4 = buCall.buVector5_0.Length3D(ChangedEntities.EndPoint, pntIntersect);
							if (!(num3 < num4))
							{
								if (num4 < 100.0)
								{
									ChangedEntities.EndPoint = buVector5.ToPoint3D(pntIntersect);
								}
							}
							else if (num3 < 100.0)
							{
								ChangedEntities.StartPoint = buVector5.ToPoint3D(pntIntersect);
							}
							ChangedEntities.Update();
							if (ChangedEntities.Orientation.A < 0.0)
							{
								ChangedEntities.Orientation.A = 0.0 - ChangedEntities.Orientation.A;
								buCall.buVector5_0.ChangeEntitiesDirection(ref ChangedEntities);
							}
						}
					}
				}
			}
		}
		buEntity.Copy(marbleCam.WireEntities, ref calcEntities);
	}

	public void SawMillingHorizontalRough(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLL3D, double CutDepth, KinematicBase5 activeKinematic)
	{
		List<List<Pnt6D>> list = new List<List<Pnt6D>>();
		List<List<Point3D>> list2 = new List<List<Point3D>>();
		List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
		for (int i = 0; i <= PLL3D.Count - 1; i++)
		{
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(PLL3D[i], ref copiedPoint);
			double num = buCall.buVector5_0.Length3D(copiedPoint);
			double num2 = DistanceCalcFromToolDiameterAndThickness(marbleCam.ToolSelected.Geometry.Diameter, CutDepth, 0.0, 0.0, 0.0);
			if (num > num2 + 10.0)
			{
				Point3D centerPnt = buCall.buVector5_0.MiddlePointOfLine(copiedPoint[0], copiedPoint[copiedPoint.Count - 1]);
				double num3 = buCall.buVector5_0.PointAngle(copiedPoint[copiedPoint.Count - 1], copiedPoint[0]);
				Point3D EndPnt = new Point3D();
				Point3D EndPnt2 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3 + 180.0, ref EndPnt);
				buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3, ref EndPnt2);
				copiedPoint[0] = EndPnt;
				copiedPoint[copiedPoint.Count - 1] = EndPnt2;
				if (i % 2 == 0)
				{
					copiedPoint.Reverse();
				}
				List<Pnt6D> list4 = new List<Pnt6D>();
				new buLinearPath(copiedPoint);
				List<Point3D> list5 = new List<Point3D>();
				double c = 0.0;
				for (int j = 0; j <= copiedPoint.Count - 1; j++)
				{
					Pnt6D item = new Pnt6D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z, 0.0, 0.0, c);
					list4.Add(item);
					list5.Add(new Point3D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z));
				}
				List<Pnt6D> calcPoints = new List<Pnt6D>();
				CalculatePointsWithKinematic(list4, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
				list.Add(list4);
				list3.Add(calcPoints);
				list2.Add(list5);
			}
		}
		marbleCam.CamBase.Tool = new ToolBase5(marbleCam.ToolSelected);
		for (int k = 0; k <= list3.Count - 1; k++)
		{
			camTpPoint camTpPoint2 = new camTpPoint();
			camTpPoint2.ToolCam = new ToolBase5(marbleCam.ToolSelected);
			double num4 = Item.Settings.settingSawMilling.SawMillingFinishVerForwardCuttingFeed;
			if (k == 0)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint, ref MidPoint, ref MaxPoint);
				Pnt6D p = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][0].A, 0.0, list3[k][0].C);
				Pnt6D p2 = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z, list3[k][0].A, 0.0, list3[k][0].C);
				TpPnt9D item2 = new TpPnt9D(p, num4, 0);
				camTpPoint2.Points.Add(item2);
				item2 = new TpPnt9D(p2, num4, 0);
				camTpPoint2.Points.Add(item2);
			}
			if (k % 2 == 0)
			{
				num4 = Item.Settings.settingSawMilling.SawMillingFinishVerBackwardCuttingFeed;
			}
			for (int l = 0; l <= list3[k].Count - 1; l++)
			{
				double feed = num4;
				if (k == 0 && l == 0)
				{
					feed = Item.Settings.settingSawMilling.SawMillingFinishVerPlungeFeed;
				}
				TpPnt9D item3 = new TpPnt9D(list3[k][l], feed, 1);
				camTpPoint2.Points.Add(item3);
			}
			if (k == list3.Count - 1)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				Point3D MidPoint2 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint2, ref MidPoint2, ref MaxPoint2);
				Pnt6D p3 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				Pnt6D p4 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				TpPnt9D item4 = new TpPnt9D(p4, num4, 0);
				camTpPoint2.Points.Add(item4);
				item4 = new TpPnt9D(p3, num4, 0);
				camTpPoint2.Points.Add(item4);
			}
			marbleCam.CamBase.CamPoints.Add(camTpPoint2);
			LinearPath item5 = new LinearPath(list2[k]);
			marbleCam.CamBase.EntitiesG1.Add(item5);
		}
	}

	public void SawMillingHorizontalRough(ref MarbleItem Item, ref MarbleItemCam marbleCam, ref bool isReverse, MarbleSawCalcParameters Setting, List<Point3DList> PLL3D, double CutDepth, KinematicBase5 activeKinematic)
	{
		ToolBase5 toolBase = new ToolBase5(marbleCam.ToolSelected);
		toolBase.Geometry.Diameter = 0.1;
		List<List<Pnt6D>> list = new List<List<Pnt6D>>();
		List<List<Point3D>> list2 = new List<List<Point3D>>();
		List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
		for (int i = 0; i <= PLL3D.Count - 1; i++)
		{
			MarbleSawCalcParameters marbleSawCalcParameters = null;
			marbleSawCalcParameters = ((PLL3D[i].Settings != null && PLL3D[i].Settings is MarbleSawCalcParameters) ? new MarbleSawCalcParameters((MarbleSawCalcParameters)PLL3D[i].Settings) : new MarbleSawCalcParameters(Setting));
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(PLL3D[i].Points, ref copiedPoint);
			double num = buCall.buVector5_0.Length3D(copiedPoint);
			double num2 = DistanceCalcFromToolDiameterAndThickness(marbleCam.ToolSelected.Geometry.Diameter, CutDepth, 0.0, 0.0, 0.0);
			if (!(num > num2 + 10.0))
			{
				continue;
			}
			Point3D centerPnt = buCall.buVector5_0.MiddlePointOfLine(copiedPoint[0], copiedPoint[copiedPoint.Count - 1]);
			double num3 = buCall.buVector5_0.PointAngle(copiedPoint[copiedPoint.Count - 1], copiedPoint[0]);
			Point3D EndPnt = new Point3D();
			Point3D EndPnt2 = new Point3D();
			buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3 + 180.0, ref EndPnt);
			buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3, ref EndPnt2);
			copiedPoint[0] = EndPnt;
			copiedPoint[copiedPoint.Count - 1] = EndPnt2;
			if (i % 2 == 0)
			{
				copiedPoint.Reverse();
			}
			List<Pnt6D> list4 = new List<Pnt6D>();
			new buLinearPath(copiedPoint);
			List<Point3D> list5 = new List<Point3D>();
			double c = 0.0;
			for (int j = 0; j <= copiedPoint.Count - 1; j++)
			{
				Pnt6D item = new Pnt6D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z, 0.0, 0.0, c);
				list4.Add(item);
				list5.Add(new Point3D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z));
			}
			List<Pnt6D> calcPoints = new List<Pnt6D>();
			if (!marbleSawCalcParameters.UseKinematic)
			{
				CalculatePointsWithKinematic(list4, activeKinematic, toolBase, ref calcPoints);
				for (int k = 0; k <= calcPoints.Count - 1; k++)
				{
					calcPoints[k].Z = calcPoints[k].Z - marbleCam.ToolSelected.Geometry.Diameter / 2.0;
				}
			}
			else
			{
				CalculatePointsWithKinematic(list4, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
			}
			list.Add(list4);
			list3.Add(calcPoints);
			list2.Add(list5);
		}
		marbleCam.CamBase.Tool = new ToolBase5(marbleCam.ToolSelected);
		for (int l = 0; l <= list3.Count - 1; l++)
		{
			camTpPoint camTpPoint2 = new camTpPoint();
			camTpPoint2.ToolCam = new ToolBase5(marbleCam.ToolSelected);
			double num4 = Item.Settings.settingSawMilling.SawMillingFinishVerForwardCuttingFeed;
			if (l >= 0)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[l], ref MinPoint, ref MidPoint, ref MaxPoint);
				Pnt6D p = new Pnt6D(list3[l][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[l][0].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[l][0].A, 0.0, list3[l][0].C);
				Pnt6D p2 = new Pnt6D(list3[l][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[l][0].Z, list3[l][0].A, 0.0, list3[l][0].C);
				TpPnt9D item2 = new TpPnt9D(p, num4, 0);
				camTpPoint2.Points.Add(item2);
				item2 = new TpPnt9D(p2, num4, 0);
				camTpPoint2.Points.Add(item2);
			}
			if (l % 2 == 0)
			{
				num4 = Item.Settings.settingSawMilling.SawMillingFinishVerBackwardCuttingFeed;
			}
			for (int m = 0; m <= list3[l].Count - 1; m++)
			{
				double feed = num4;
				if (l == 0 && m == 0)
				{
					feed = Item.Settings.settingSawMilling.SawMillingFinishVerPlungeFeed;
				}
				TpPnt9D item3 = new TpPnt9D(list3[l][m], feed, 1);
				camTpPoint2.Points.Add(item3);
			}
			if (l >= 0)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				Point3D MidPoint2 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[l], ref MinPoint2, ref MidPoint2, ref MaxPoint2);
				Pnt6D p3 = new Pnt6D(list3[l][list3[l].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[l][list3[l].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[l][list3[l].Count - 1].A, 0.0, list3[l][list3[l].Count - 1].C);
				Pnt6D p4 = new Pnt6D(list3[l][list3[l].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[l][list3[l].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[l][list3[l].Count - 1].A, 0.0, list3[l][list3[l].Count - 1].C);
				TpPnt9D item4 = new TpPnt9D(p4, num4, 0);
				camTpPoint2.Points.Add(item4);
				item4 = new TpPnt9D(p3, num4, 0);
				camTpPoint2.Points.Add(item4);
			}
			marbleCam.CamBase.CamPoints.Add(camTpPoint2);
			LinearPath item5 = new LinearPath(list2[l]);
			marbleCam.CamBase.EntitiesG1.Add(item5);
		}
	}

	public void SawMillingVerticalToolPointCamCalc(ref MarbleItem Item, ref MarbleItemCam marbleCam, ref bool isReverse, MarbleSawCalcParameters Setting, List<Point3DList> PLL3D, KinematicBase5 activeKinematic)
	{
		try
		{
			int num = 0;
			double num2 = 0.0;
			Pnt6D pnt6D = new Pnt6D();
			Pnt6D calcPoint = new Pnt6D();
			TpPnt9D tpPnt9D = null;
			ToolBase5 toolBase = new ToolBase5(marbleCam.ToolSelected);
			toolBase.Geometry.Diameter = 0.1;
			for (int i = 0; i <= PLL3D.Count - 1; i++)
			{
				camTpPoint camTpPoint2 = new camTpPoint();
				Point3D point3D = null;
				MarbleSawCalcParameters marbleSawCalcParameters = null;
				marbleSawCalcParameters = ((PLL3D[i].Settings != null && PLL3D[i].Settings is MarbleSawCalcParameters) ? new MarbleSawCalcParameters((MarbleSawCalcParameters)PLL3D[i].Settings) : new MarbleSawCalcParameters(Setting));
				List<Point3D> PointsDevided = new List<Point3D>();
				List<Point3D> calculatedPoints = new List<Point3D>();
				if (!(marbleSawCalcParameters.DevideLength > 0.0))
				{
					buVector5.Copy(PLL3D[i].Points, ref PointsDevided, 4);
				}
				else
				{
					buCall.buVector5_0.DevidePointsByLength(PLL3D[i].Points, marbleSawCalcParameters.DevideLength, ref PointsDevided);
				}
				if ((marbleSawCalcParameters.ShiftPoint != null) & marbleSawCalcParameters.ShiftEnable)
				{
					buCall.buVector5_0.ShiftPointsByLength(marbleSawCalcParameters.ShiftPoint, ref PointsDevided, OnlyXY: true);
				}
				if (!marbleSawCalcParameters.SplineEnable)
				{
					buVector5.Copy(PointsDevided, ref calculatedPoints, 4);
				}
				else
				{
					buCall.buVector5_0.BSplineAtSharpCorner(PointsDevided, marbleSawCalcParameters.Splinedt, 20.0, isQuadratic: false, ref calculatedPoints);
				}
				PointsDevided.Clear();
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref calculatedPoints);
				ClockDirectionType clockDirectionType = buCall.buVector5_0.GetClockDirection(calculatedPoints);
				if (clockDirectionType == ClockDirectionType.CW)
				{
					clockDirectionType = ClockDirectionType.CCW;
					calculatedPoints.Reverse();
				}
				double num3 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[1]), buVector5.ToPoint3D(calculatedPoints[0]));
				if (isReverse)
				{
					num3 -= 180.0;
				}
				if (i > 0)
				{
					double num4 = Math.Abs(pnt6D.C - num3);
					if (num4 > 180.0)
					{
						num3 = ((num3 > pnt6D.C) ? (num3 - 360.0) : (num3 + 360.0));
					}
				}
				if (marbleSawCalcParameters.UseContantAngle)
				{
					num3 = marbleSawCalcParameters.ConstantAngle;
				}
				double length = marbleSawCalcParameters.SafeDistanceXY;
				if (marbleSawCalcParameters.LeadInDistance > 0.0)
				{
					length = marbleSawCalcParameters.LeadInDistance;
				}
				if (clockDirectionType != ClockDirectionType.CW)
				{
					point3D = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[0]), length, num3 - 90.0, ref point3D);
				}
				else
				{
					point3D = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[0]), length, num3 - 90.0, ref point3D);
				}
				Pnt6D pnt6D2 = null;
				if (i == 0)
				{
					if (!marbleSawCalcParameters.MoveSafeZDistance)
					{
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, calculatedPoints[0].Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num3;
						if (!marbleSawCalcParameters.UseKinematic)
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
							if (buCompare5.EQ(pnt6D2.A, 90.0))
							{
								calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
							}
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						else
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						camTpPoint2.Points.Add(tpPnt9D);
					}
					else
					{
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 0.0;
						pnt6D2.C = 0.0;
						pnt6D2.Z = Item.SizeItem.MaxPoint.Z + marbleSawCalcParameters.SafeDistanceZ;
						if (!marbleSawCalcParameters.UseKinematic)
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
							if (buCompare5.EQ(pnt6D2.A, 90.0))
							{
								calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
							}
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						else
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						tpPnt9D.EnableAxes.Z = false;
						camTpPoint2.Points.Add(tpPnt9D);
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num3;
						pnt6D2.Z = Item.SizeItem.MaxPoint.Z + marbleSawCalcParameters.SafeDistanceZ;
						if (!marbleSawCalcParameters.UseKinematic)
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
							if (buCompare5.EQ(pnt6D2.A, 90.0))
							{
								calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
							}
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						else
						{
							CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						}
						camTpPoint2.Points.Add(tpPnt9D);
					}
				}
				pnt6D2 = new Pnt6D(calculatedPoints[0].X, calculatedPoints[0].Y, calculatedPoints[0].Z);
				pnt6D2.A = 90.0;
				pnt6D2.C = num3;
				if (!marbleSawCalcParameters.UseKinematic)
				{
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
					if (buCompare5.EQ(pnt6D2.A, 90.0))
					{
						calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
					}
					tpPnt9D = new TpPnt9D(calcPoint, marbleSawCalcParameters.PlungeSpeed, 1);
				}
				else
				{
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = new TpPnt9D(calcPoint, marbleSawCalcParameters.PlungeSpeed, 1);
				}
				tpPnt9D.AfterCodes.Add("G38 O1");
				tpPnt9D.AfterCodes.Add("G51 D1");
				camTpPoint2.Points.Add(tpPnt9D);
				num2 = num3;
				List<Point3D> list = new List<Point3D>();
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				for (int j = 1; j <= calculatedPoints.Count - 1; j++)
				{
					buVector5.ToPoint3D(calculatedPoints[j]);
					double num5 = 0.0;
					num5 = ((j == 0) ? buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[j + 1]), buVector5.ToPoint3D(calculatedPoints[j])) : buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[j]), buVector5.ToPoint3D(calculatedPoints[j - 1])));
					if (isReverse)
					{
						num5 -= 180.0;
					}
					double num6 = num5 - num2;
					if (Math.Abs(num6) > 180.0)
					{
						num5 = ((num6 > 0.0) ? (num5 - 360.0) : (num5 + 360.0));
					}
					if (marbleSawCalcParameters.UseContantAngle)
					{
						num5 = marbleSawCalcParameters.ConstantAngle;
					}
					double feed = marbleSawCalcParameters.ForwardCutSpeed;
					if (isReverse)
					{
						feed = marbleSawCalcParameters.BackwardCutSpeed;
					}
					pnt6D2 = new Pnt6D(calculatedPoints[j].X, calculatedPoints[j].Y, calculatedPoints[j].Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num5;
					if (!marbleSawCalcParameters.UseKinematic)
					{
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
						if (buCompare5.EQ(pnt6D2.A, 90.0))
						{
							calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
						}
						tpPnt9D = new TpPnt9D(calcPoint, feed, 1);
					}
					else
					{
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						tpPnt9D = new TpPnt9D(calcPoint, feed, 1);
					}
					camTpPoint2.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					num2 = num5;
				}
				num3 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 2]));
				if (isReverse)
				{
					num3 -= 180.0;
				}
				double num7 = num3 - num2;
				if (Math.Abs(num7) > 180.0)
				{
					num3 = ((num7 > 0.0) ? (num3 - 360.0) : (num3 + 360.0));
				}
				if (marbleSawCalcParameters.UseContantAngle)
				{
					num3 = marbleSawCalcParameters.ConstantAngle;
				}
				if (i == PLL3D.Count - 1)
				{
					length = marbleSawCalcParameters.SafeDistanceXY;
					if (marbleSawCalcParameters.LeadOutDistance > 0.0)
					{
						length = marbleSawCalcParameters.LeadOutDistance;
					}
					if (clockDirectionType != ClockDirectionType.CW)
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), length, num3 - 90.0, ref point3D);
					}
					else
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), length, num3 - 90.0, ref point3D);
					}
					pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num3;
					if (!marbleSawCalcParameters.UseKinematic)
					{
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, toolBase, ref calcPoint);
						if (buCompare5.EQ(pnt6D2.A, 90.0))
						{
							calcPoint.Z -= marbleCam.ToolSelected.Geometry.Diameter / 2.0;
						}
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
					}
					else
					{
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
					}
					tpPnt9D.PreCodes.Add("G39 O1");
					tpPnt9D.PreCodes.Add("G50");
					camTpPoint2.Points.Add(tpPnt9D);
				}
				pnt6D = new Pnt6D(calcPoint);
				LinearPath linearPath = new LinearPath(calculatedPoints);
				linearPath.Color = Item.Settings.settingSawMilling.SawMillingCamColor;
				linearPath.ColorMethod = colorMethodType.byEntity;
				marbleCam.CamBase.EntitiesG1.Add(linearPath);
				marbleCam.CamBase.CamPoints.Add(camTpPoint2);
				if (marbleCam.CamBase != null)
				{
					marbleCam.CamBase.TypeCam = CamType.SawCut;
				}
				if (isReverse)
				{
					isReverse = false;
				}
				else
				{
					isReverse = true;
				}
				num++;
			}
		}
		catch (Exception)
		{
		}
	}

	public void SawMillingVerticalToolPointCamCenterCalc(ref MarbleItem Item, ref MarbleItemCam marbleCam, MarbleSawCalcParameters Setting, List<Point3DList> PLL3D, KinematicBase5 activeKinematic)
	{
		try
		{
			int num = 0;
			bool flag = false;
			double num2 = 0.0;
			Pnt6D pnt6D = new Pnt6D();
			Pnt6D calcPoint = new Pnt6D();
			TpPnt9D tpPnt9D = null;
			for (int i = 0; i <= PLL3D.Count - 1; i++)
			{
				camTpPoint camTpPoint2 = new camTpPoint();
				Point3D point3D = null;
				MarbleSawCalcParameters marbleSawCalcParameters = null;
				marbleSawCalcParameters = ((PLL3D[i].Settings != null && PLL3D[i].Settings is MarbleSawCalcParameters) ? new MarbleSawCalcParameters((MarbleSawCalcParameters)PLL3D[i].Settings) : new MarbleSawCalcParameters(Setting));
				List<Point3D> PointsDevided = new List<Point3D>();
				List<Point3D> calculatedPoints = new List<Point3D>();
				if (!(marbleSawCalcParameters.DevideLength > 0.0))
				{
					buVector5.Copy(PLL3D[i].Points, ref PointsDevided, 4);
				}
				else
				{
					buCall.buVector5_0.DevidePointsByLength(PLL3D[i].Points, marbleSawCalcParameters.DevideLength, ref PointsDevided);
				}
				if (!marbleSawCalcParameters.SplineEnable)
				{
					buVector5.Copy(PointsDevided, ref calculatedPoints, 4);
				}
				else
				{
					buCall.buVector5_0.BSplineQuadraticUniform(PointsDevided, marbleSawCalcParameters.Splinedt, Closed: true, ref calculatedPoints);
				}
				PointsDevided.Clear();
				if ((marbleSawCalcParameters.ShiftPoint != null) & marbleSawCalcParameters.ShiftEnable)
				{
					buCall.buVector5_0.ShiftPointsByLength(marbleSawCalcParameters.ShiftPoint, ref calculatedPoints, OnlyXY: true);
				}
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref calculatedPoints);
				ClockDirectionType clockDirectionType = buCall.buVector5_0.GetClockDirection(calculatedPoints);
				if (marbleSawCalcParameters.UseClockDirection)
				{
					if (num % 2 != 0)
					{
						if (clockDirectionType == ClockDirectionType.CCW)
						{
							clockDirectionType = ClockDirectionType.CW;
							calculatedPoints.Reverse();
						}
						flag = true;
					}
					else
					{
						if (clockDirectionType == ClockDirectionType.CW)
						{
							clockDirectionType = ClockDirectionType.CCW;
							calculatedPoints.Reverse();
						}
						flag = false;
					}
				}
				if (marbleSawCalcParameters.UseClockDirection)
				{
					clockDirectionType = marbleSawCalcParameters.SetClockDir;
				}
				double num3 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[1]), buVector5.ToPoint3D(calculatedPoints[0]));
				if (flag)
				{
					num3 -= 180.0;
				}
				if (i > 0)
				{
					double num4 = Math.Abs(pnt6D.C - num3);
					if (num4 > 180.0)
					{
						num3 = ((num3 > pnt6D.C) ? (num3 - 360.0) : (num3 + 360.0));
					}
				}
				if (marbleSawCalcParameters.UseContantAngle)
				{
					num3 = marbleSawCalcParameters.ConstantAngle;
				}
				double length = marbleSawCalcParameters.SafeDistanceXY;
				if (marbleSawCalcParameters.LeadInDistance > 0.0)
				{
					length = marbleSawCalcParameters.LeadInDistance;
				}
				if (clockDirectionType != ClockDirectionType.CW)
				{
					point3D = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[0]), length, num3 - 90.0, ref point3D);
				}
				else
				{
					point3D = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[0]), length, num3 - 90.0, ref point3D);
				}
				Pnt6D pnt6D2 = null;
				if ((i == 0) & marbleSawCalcParameters.isFirst)
				{
					pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
					pnt6D2.A = 0.0;
					pnt6D2.C = 0.0;
					pnt6D2.Z = Item.SizeItem.MaxPoint.Z + marbleSawCalcParameters.SafeDistanceZ;
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = (marbleSawCalcParameters.UseKinematic ? new TpPnt9D(calcPoint, 100.0, 0) : new TpPnt9D(pnt6D2, 100.0, 0));
					tpPnt9D.EnableAxes.Z = false;
					camTpPoint2.Points.Add(tpPnt9D);
					pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num3;
					pnt6D2.Z = Item.SizeItem.MaxPoint.Z + marbleSawCalcParameters.SafeDistanceZ;
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = (marbleSawCalcParameters.UseKinematic ? new TpPnt9D(calcPoint, 100.0, 0) : new TpPnt9D(pnt6D2, 100.0, 0));
					camTpPoint2.Points.Add(tpPnt9D);
				}
				pnt6D2 = new Pnt6D(calculatedPoints[0].X, calculatedPoints[0].Y, calculatedPoints[0].Z);
				pnt6D2.A = 90.0;
				pnt6D2.C = num3;
				CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
				tpPnt9D = (marbleSawCalcParameters.UseKinematic ? new TpPnt9D(calcPoint, marbleSawCalcParameters.PlungeSpeed, 1) : new TpPnt9D(pnt6D2, marbleSawCalcParameters.PlungeSpeed, 1));
				tpPnt9D.AfterCodes.Add("G38 O1");
				tpPnt9D.AfterCodes.Add("G51 D1");
				camTpPoint2.Points.Add(tpPnt9D);
				num2 = num3;
				List<Point3D> list = new List<Point3D>();
				list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				for (int j = 1; j <= calculatedPoints.Count - 1; j++)
				{
					buVector5.ToPoint3D(calculatedPoints[j]);
					double num5 = 0.0;
					num5 = ((j == 0) ? buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[j + 1]), buVector5.ToPoint3D(calculatedPoints[j])) : buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[j]), buVector5.ToPoint3D(calculatedPoints[j - 1])));
					if (flag)
					{
						num5 -= 180.0;
					}
					double num6 = num5 - num2;
					if (Math.Abs(num6) > 180.0)
					{
						num5 = ((num6 > 0.0) ? (num5 - 360.0) : (num5 + 360.0));
					}
					if (marbleSawCalcParameters.UseContantAngle)
					{
						num5 = marbleSawCalcParameters.ConstantAngle;
					}
					double feed = marbleSawCalcParameters.ForwardCutSpeed;
					if (flag)
					{
						feed = marbleSawCalcParameters.BackwardCutSpeed;
					}
					pnt6D2 = new Pnt6D(calculatedPoints[j].X, calculatedPoints[j].Y, calculatedPoints[j].Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num5;
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = (marbleSawCalcParameters.UseKinematic ? new TpPnt9D(calcPoint, feed, 1) : new TpPnt9D(pnt6D2, feed, 1));
					camTpPoint2.Points.Add(tpPnt9D);
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					num2 = num5;
				}
				num3 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 2]));
				if (flag)
				{
					num3 -= 180.0;
				}
				double num7 = num3 - num2;
				if (Math.Abs(num7) > 180.0)
				{
					num3 = ((num7 > 0.0) ? (num3 - 360.0) : (num3 + 360.0));
				}
				if (marbleSawCalcParameters.UseContantAngle)
				{
					num3 = marbleSawCalcParameters.ConstantAngle;
				}
				if (i == PLL3D.Count - 1)
				{
					length = marbleSawCalcParameters.SafeDistanceXY;
					if (marbleSawCalcParameters.LeadOutDistance > 0.0)
					{
						length = marbleSawCalcParameters.LeadOutDistance;
					}
					if (clockDirectionType != ClockDirectionType.CW)
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), marbleSawCalcParameters.SafeDistanceXY, num3 - 90.0, ref point3D);
					}
					else
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(calculatedPoints[calculatedPoints.Count - 1]), length, num3 - 90.0, ref point3D);
					}
					pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num3;
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = (marbleSawCalcParameters.UseKinematic ? new TpPnt9D(calcPoint, 100.0, 0) : new TpPnt9D(pnt6D2, 100.0, 0));
					tpPnt9D.PreCodes.Add("G39 O1");
					tpPnt9D.PreCodes.Add("G50");
					if (marbleSawCalcParameters.UseLeadOut)
					{
						camTpPoint2.Points.Add(tpPnt9D);
					}
				}
				pnt6D = new Pnt6D(calcPoint);
				LinearPath linearPath = new LinearPath(calculatedPoints);
				linearPath.Color = Item.Settings.settingSawMilling.SawMillingCamColor;
				linearPath.ColorMethod = colorMethodType.byEntity;
				marbleCam.CamBase.EntitiesG1.Add(linearPath);
				marbleCam.CamBase.CamPoints.Add(camTpPoint2);
				num++;
			}
			if (marbleCam.CamBase != null)
			{
				marbleCam.CamBase.TypeCam = CamType.SawCut;
			}
		}
		catch (Exception)
		{
		}
	}

	public void SawExistingToolPointCamCenterCalc(ref MarbleItem Item, ref MarbleItemCam marbleCam, MarbleSawCalcParameters Setting, List<Pnt6DList> PLL3D, bool UseKinematic, KinematicBase5 activeKinematic)
	{
		try
		{
			int num = 0;
			bool flag = false;
			new Pnt6D();
			Pnt6D calcPoint = new Pnt6D();
			TpPnt9D tpPnt9D = null;
			for (int i = 0; i <= PLL3D.Count - 1; i++)
			{
				camTpPoint camTpPoint2 = new camTpPoint();
				MarbleSawCalcParameters marbleSawCalcParameters = null;
				marbleSawCalcParameters = ((PLL3D[i].Settings != null && PLL3D[i].Settings is MarbleSawCalcParameters) ? new MarbleSawCalcParameters((MarbleSawCalcParameters)PLL3D[i].Settings) : new MarbleSawCalcParameters(Setting));
				List<Pnt6D> list = new List<Pnt6D>();
				List<Pnt6D> copiedPoint = new List<Pnt6D>();
				if (!(marbleSawCalcParameters.DevideLength > 0.0))
				{
					buVector5.Copy(PLL3D[i].Points, ref copiedPoint, 4);
				}
				list.Clear();
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
				Pnt6D pnt6D = null;
				pnt6D = new Pnt6D(copiedPoint[0].X, copiedPoint[0].Y, copiedPoint[0].Z, copiedPoint[0].A, 0.0, copiedPoint[0].C);
				CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
				tpPnt9D = (UseKinematic ? new TpPnt9D(calcPoint, marbleSawCalcParameters.PlungeSpeed, 1) : new TpPnt9D(pnt6D, marbleSawCalcParameters.PlungeSpeed, 1));
				tpPnt9D.AfterCodes.Add("G38 O1");
				tpPnt9D.AfterCodes.Add("G51 D1");
				camTpPoint2.Points.Add(tpPnt9D);
				List<Point3D> list2 = new List<Point3D>();
				list2.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				for (int j = 1; j <= copiedPoint.Count - 1; j++)
				{
					double feed = marbleSawCalcParameters.ForwardCutSpeed;
					if (flag)
					{
						feed = marbleSawCalcParameters.BackwardCutSpeed;
					}
					pnt6D = new Pnt6D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z, copiedPoint[j].A, 0.0, copiedPoint[j].C);
					CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = (UseKinematic ? new TpPnt9D(calcPoint, feed, 1) : new TpPnt9D(pnt6D, marbleSawCalcParameters.PlungeSpeed, 1));
					if (j == copiedPoint.Count - 1)
					{
						tpPnt9D.PreCodes.Add("G39 O1");
						tpPnt9D.PreCodes.Add("G50");
					}
					camTpPoint2.Points.Add(tpPnt9D);
					list2.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
				}
				marbleCam.CamBase.CamPoints.Add(camTpPoint2);
				num++;
			}
		}
		catch (Exception)
		{
		}
	}

	public void SawMillingVerticalRough(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLL3D, KinematicBase5 activeKinematic)
	{
		int num = 0;
		double num2 = 0.0;
		Pnt6D pnt6D = new Pnt6D();
		Pnt6D calcPoint = new Pnt6D();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Entity entity = CompositeCurve.CreateRectangle(Item.SizeItem.Width, Item.SizeItem.Height);
		entity.Translate(Item.SizeItem.MinPoint.X, Item.SizeItem.MinPoint.Y);
		entity.Regen(0.1);
		bool flag = false;
		double num3 = 132.0;
		for (int i = 0; i <= PLL3D.Count - 1; i++)
		{
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			if (PLL3D[i].Count > 3)
			{
				buCall.buVector5_0.BoxSizeCalculate(PLL3D[i], ref MinPoint, ref MaxPoint);
				double num4 = buCall.buVector5_0.Length3D(Item.SizeItem.MinPoint, Item.SizeItem.MaxPoint, Plane.XY);
				double num5 = buCall.buVector5_0.Length3D(MinPoint, MaxPoint, Plane.XY) - marbleCam.ToolSelected.Geometry.Diameter * 2.0;
				double num6 = (num4 - num5) / 2.0;
				int num7 = Convert.ToInt32(buNumeric5.RoundToUpper(num6 / Item.Settings.settingSawMilling.SawMillingRoughVerCutStep));
				_ = num6 / Convert.ToDouble(num7);
				if (num7 <= 0)
				{
					num7 = 1;
				}
				num7 = 1;
				for (int num8 = 1; num8 >= 1; num8--)
				{
					new List<buEntity>();
					new List<Point3D>();
					new List<Pnt6D>();
					camTpPoint camTpPoint2 = new camTpPoint();
					Line line = null;
					Point3D[] array = null;
					Point3D EndPnt = null;
					List<Point3D> copiedPoint = new List<Point3D>();
					List<Point3D> copiedPoint2 = new List<Point3D>();
					if (num7 <= 1)
					{
						buVector5.Copy(PLL3D[i], ref copiedPoint);
					}
					else
					{
						buVector5.Copy(PLL3D[i], ref copiedPoint);
						LinearPath linearPath = new LinearPath(copiedPoint);
						ICurve[] array2 = linearPath.QuickOffset(Item.Settings.settingSawMilling.SawMillingRoughVerCutStep * (double)num8, Plane.XY, cornerType.Round);
						if (array2.Length != 0)
						{
							((Entity)array2[0]).Regen(0.1);
							if (((Entity)array2[0]).Vertices.Length > 3)
							{
								((Entity)array2[0]).Translate(0.0, 0.0, 0.0 - ((Entity)array2[0]).Vertices[0].Z);
								copiedPoint = new List<Point3D>();
								buVector5.Copy(((Entity)array2[0]).Vertices, ref copiedPoint);
								buCall.buVector5_0.Move(0.0, 0.0, PLL3D[i][0].Z, ref copiedPoint);
							}
						}
					}
					Point3D refPoints = new Point3D(Item.SizeItem.MidPoint.X, Item.SizeItem.MinPoint.Y - marbleCam.ToolSelected.Geometry.Diameter / 2.0, Item.SizeItem.MinPoint.Z);
					for (int j = 1; j <= copiedPoint.Count - 1; j++)
					{
					}
					buCall.buVector5_0.ShiftPointsByLength(refPoints, ref copiedPoint, OnlyXY: true);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
					if (Item.Settings.settingSawMilling.SawMillingRoughVerSplineEnable)
					{
						buVector5.Copy(copiedPoint, ref copiedPoint2);
						copiedPoint.Clear();
						copiedPoint = new List<Point3D>();
						buCall.buVector5_0.BSplineCubicUniform(copiedPoint2, Item.Settings.settingSawMilling.SawMillingRoughVerSplineDt, Closed: false, ref copiedPoint);
						buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref copiedPoint);
					}
					ClockDirectionType clockDirectionType = buCall.buVector5_0.GetClockDirection(copiedPoint);
					if (num % 2 != 0)
					{
						if (clockDirectionType == ClockDirectionType.CCW)
						{
							clockDirectionType = ClockDirectionType.CW;
							copiedPoint.Reverse();
						}
						flag = true;
					}
					else
					{
						if (clockDirectionType == ClockDirectionType.CW)
						{
							clockDirectionType = ClockDirectionType.CCW;
							copiedPoint.Reverse();
						}
						flag = false;
					}
					double num9 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(copiedPoint[1]), buVector5.ToPoint3D(copiedPoint[0]));
					if (flag)
					{
						num9 -= 180.0;
					}
					Point3D point3D = null;
					if (i > 0)
					{
						double num10 = Math.Abs(pnt6D.C - num9);
						if (num10 > 180.0)
						{
							num9 = ((num9 > pnt6D.C) ? (num9 - 360.0) : (num9 + 360.0));
						}
					}
					double num11 = buCall.buVector5_0.Length3D(Item.SizeItem.MidPoint, copiedPoint[0], Plane.XY);
					buCall.buVector5_0.Length3D(Item.SizeItem.MidPoint, Item.SizeItem.MaxPoint, Plane.XY);
					num11 = 350.0;
					if (num11 <= 0.0)
					{
						num11 = 10.0;
					}
					if (clockDirectionType != ClockDirectionType.CW)
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(copiedPoint[0]), Item.Settings.settingSawMilling.SawMillingRoughVerApproach + num11, num9 - 90.0, ref point3D);
					}
					else
					{
						point3D = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(copiedPoint[0]), Item.Settings.settingSawMilling.SawMillingRoughVerApproach + num11, num9 - 90.0, ref point3D);
					}
					buCall.buVector5_0.LineWithLengthAndAngle(new Point3D(copiedPoint[0].X, copiedPoint[0].Y, 0.0), 1000.0, num9 - 90.0, ref EndPnt);
					Point3D startPoint = buVector5.ToPoint3D(copiedPoint[0]);
					line = new Line(new Point3D(copiedPoint[0].X, copiedPoint[0].Y, 0.0), EndPnt);
					array = ((ICurve)entity).IntersectWith(line);
					if (array.Length != 0)
					{
						double num12 = buCall.buVector5_0.Length3D(startPoint, array[0], Plane.XY);
						if (!(num12 > Item.Settings.settingSawMilling.SawMillingRoughVerMaxCutDepth))
						{
						}
					}
					marbleCam.ToolSelected.Geometry.Diameter = 1.0;
					Pnt6D pnt6D2 = null;
					if (i == 0)
					{
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 0.0;
						pnt6D2.C = 0.0;
						pnt6D2.Z = Item.SizeItem.MaxPoint.Z + Item.Settings.settingSawMilling.SawMillingRoughVerSafeDistance;
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						calcPoint = new Pnt6D(pnt6D2);
						calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						tpPnt9D.EnableAxes.Z = false;
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						camTpPoint2.Points.Add(tpPnt9D);
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num9;
						pnt6D2.Z = Item.SizeItem.MaxPoint.Z + Item.Settings.settingSawMilling.SawMillingRoughVerSafeDistance;
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						calcPoint = new Pnt6D(pnt6D2);
						calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						camTpPoint2.Points.Add(tpPnt9D);
					}
					if (num8 == num7)
					{
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num9;
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						calcPoint = new Pnt6D(pnt6D2);
						calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						camTpPoint2.Points.Add(tpPnt9D);
					}
					pnt6D2 = new Pnt6D(copiedPoint[0].X, copiedPoint[0].Y, copiedPoint[0].Z);
					pnt6D2.A = 90.0;
					pnt6D2.C = num9;
					CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					calcPoint = new Pnt6D(pnt6D2);
					calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
					calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
					tpPnt9D = new TpPnt9D(calcPoint, Item.Settings.settingSawMilling.SawMillingRoughVerPlungeFeed, 1);
					tpPnt9D.AfterCodes.Add("G38 O1");
					tpPnt9D.AfterCodes.Add("G51 D1");
					camTpPoint2.Points.Add(tpPnt9D);
					num2 = num9;
					List<Point3D> list = new List<Point3D>();
					list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
					for (int k = 1; k <= copiedPoint.Count - 1; k++)
					{
						buVector5.ToPoint3D(copiedPoint[k]);
						double num13 = 0.0;
						num13 = ((k == 0) ? buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(copiedPoint[k + 1]), buVector5.ToPoint3D(copiedPoint[k])) : buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(copiedPoint[k]), buVector5.ToPoint3D(copiedPoint[k - 1])));
						if (flag)
						{
							num13 -= 180.0;
						}
						double num14 = num13 - num2;
						if (Math.Abs(num14) > 180.0)
						{
							num13 = ((num14 > 0.0) ? (num13 - 360.0) : (num13 + 360.0));
						}
						if (flag)
						{
							if (num13 > num2)
							{
							}
						}
						else if (!(num13 < num2))
						{
						}
						buCall.buVector5_0.LineWithLengthAndAngle(new Point3D(copiedPoint[i].X, copiedPoint[i].Y, 0.0), 1000.0, num9 - 90.0, ref EndPnt);
						line = new Line(new Point3D(copiedPoint[i].X, copiedPoint[i].Y, 0.0), EndPnt);
						array = ((ICurve)entity).IntersectWith(line);
						if (array.Length != 0)
						{
							double num15 = buCall.buVector5_0.Length3D(startPoint, array[0], Plane.XY);
							if (!(num15 > Item.Settings.settingSawMilling.SawMillingRoughVerMaxCutDepth))
							{
							}
						}
						double feed = Item.Settings.settingSawMilling.SawMillingRoughVerForwardCuttingFeed;
						if (flag)
						{
							feed = Item.Settings.settingSawMilling.SawMillingRoughVerBackwardCuttingFeed;
						}
						pnt6D2 = new Pnt6D(copiedPoint[k].X, copiedPoint[k].Y, copiedPoint[k].Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num13;
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						calcPoint = new Pnt6D(pnt6D2);
						calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						tpPnt9D = new TpPnt9D(calcPoint, feed, 1);
						camTpPoint2.Points.Add(tpPnt9D);
						list.Add(new Point3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z));
						num2 = num13;
					}
					num9 = buCall.buVector5_0.PointAngle(buVector5.ToPoint3D(copiedPoint[copiedPoint.Count - 1]), buVector5.ToPoint3D(copiedPoint[copiedPoint.Count - 2]));
					if (flag)
					{
						num9 -= 180.0;
					}
					double num16 = num9 - num2;
					if (Math.Abs(num16) > 180.0)
					{
						num9 = ((num16 > 0.0) ? (num9 - 360.0) : (num9 + 360.0));
					}
					if (num8 == 1)
					{
						if (clockDirectionType != ClockDirectionType.CW)
						{
							point3D = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(copiedPoint[copiedPoint.Count - 1]), Item.Settings.settingSawMilling.SawMillingRoughVerApproach + num11, num9 - 90.0, ref point3D);
						}
						else
						{
							point3D = new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(buVector5.ToPoint3D(copiedPoint[copiedPoint.Count - 1]), Item.Settings.settingSawMilling.SawMillingRoughVerApproach + num11, num9 - 90.0, ref point3D);
						}
						pnt6D2 = new Pnt6D(point3D.X, point3D.Y, point3D.Z);
						pnt6D2.A = 90.0;
						pnt6D2.C = num9;
						CalculatePointsWithKinematic(pnt6D2, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						calcPoint = new Pnt6D(pnt6D2);
						calcPoint.X += Math.Cos(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						calcPoint.Y += Math.Sin(buConversion5.DegreeToRadian(calcPoint.C - 90.0)) * num3;
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						tpPnt9D.PreCodes.Add("G39 O1");
						tpPnt9D.PreCodes.Add("G50");
						camTpPoint2.Points.Add(tpPnt9D);
					}
					pnt6D = new Pnt6D(calcPoint);
					buCall.buVector5_0.Move(0.0, 0.0, -50.0, ref camTpPoint2.Points);
					LinearPath item = new LinearPath(copiedPoint);
					marbleCam.CamBase.EntitiesG1.Add(item);
					marbleCam.CamBase.CamPoints.Add(camTpPoint2);
				}
			}
			num++;
		}
	}

	public void SawMillingVerticalFinish(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<Point3DList> PointList, KinematicBase5 activeKinematic)
	{
		List<List<Pnt6D>> list = new List<List<Pnt6D>>();
		List<List<Point3D>> list2 = new List<List<Point3D>>();
		List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
		for (int i = 0; i <= PointList.Count - 1; i++)
		{
			if (i % 2 == 0)
			{
				PointList[i].Points.Reverse();
			}
			List<Pnt6D> list4 = new List<Pnt6D>();
			new buLinearPath(PointList[i].Points);
			List<Point3D> list5 = new List<Point3D>();
			double num = (double)i * Item.Settings.settingSawMilling.SawMillingFinishVerAngleStep - 90.0;
			for (int j = 0; j <= PointList[i].Points.Count - 1; j++)
			{
				Pnt6D item = new Pnt6D(PointList[i].Points[j].X, PointList[i].Points[j].Y, PointList[i].Points[j].Z, 90.0, 0.0, num + 90.0);
				list4.Add(item);
				list5.Add(new Point3D(PointList[i].Points[j].X, PointList[i].Points[j].Y, PointList[i].Points[j].Z));
			}
			List<Pnt6D> calcPoints = new List<Pnt6D>();
			CalculatePointsWithKinematic(list4, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
			list.Add(list4);
			list3.Add(calcPoints);
			list2.Add(list5);
		}
		marbleCam.CamBase.Tool = new ToolBase5(marbleCam.ToolSelected);
		for (int k = 0; k <= list3.Count - 1; k++)
		{
			camTpPoint camTpPoint2 = new camTpPoint();
			camTpPoint2.ToolCam = new ToolBase5(marbleCam.ToolSelected);
			double num2 = Item.Settings.settingSawMilling.SawMillingFinishVerForwardCuttingFeed;
			if (k == 0)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint, ref MidPoint, ref MaxPoint);
				Pnt6D p = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][0].A, 0.0, list3[k][0].C);
				Pnt6D p2 = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z, list3[k][0].A, 0.0, list3[k][0].C);
				TpPnt9D item2 = new TpPnt9D(p, num2, 0);
				camTpPoint2.Points.Add(item2);
				item2 = new TpPnt9D(p2, num2, 0);
				camTpPoint2.Points.Add(item2);
			}
			if (k % 2 == 0)
			{
				num2 = Item.Settings.settingSawMilling.SawMillingFinishVerBackwardCuttingFeed;
			}
			for (int l = 0; l <= list3[k].Count - 1; l++)
			{
				double feed = num2;
				if (k == 0 && l == 0)
				{
					feed = Item.Settings.settingSawMilling.SawMillingFinishVerPlungeFeed;
				}
				TpPnt9D item3 = new TpPnt9D(list3[k][l], feed, 1);
				camTpPoint2.Points.Add(item3);
			}
			if (k == list3.Count - 1)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				Point3D MidPoint2 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint2, ref MidPoint2, ref MaxPoint2);
				Pnt6D p3 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				Pnt6D p4 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				TpPnt9D item4 = new TpPnt9D(p4, num2, 0);
				camTpPoint2.Points.Add(item4);
				item4 = new TpPnt9D(p3, num2, 0);
				camTpPoint2.Points.Add(item4);
			}
			marbleCam.CamBase.CamPoints.Add(camTpPoint2);
			LinearPath item5 = new LinearPath(list2[k]);
			marbleCam.CamBase.EntitiesG1.Add(item5);
		}
	}

	public void ProfileRoughLevel(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, List<Pnt6DS> OrjPL6, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			bool flag = false;
			if (i == PLLSurf.Count - 1)
			{
				flag = true;
			}
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			Item.Settings.settingProfileCut.RoughPerpendicularA = false;
			bool isReverse = false;
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			List<List<Point3D>> list3 = new List<List<Point3D>>();
			List<List<Pnt6D>> list4 = new List<List<Pnt6D>>();
			double num = 0.0;
			if (Item.Settings.settingProfileCut.RoughReverseCAngle)
			{
				num = 180.0;
			}
			if (!Item.Settings.settingProfileCut.TwistEnable)
			{
				for (int j = 0; j <= copiedPoint.Count - 1; j++)
				{
					List<Pnt6D> list5 = new List<Pnt6D>();
					List<Point3D> list6 = new List<Point3D>();
					double a = 0.0;
					double z = copiedPoint[j].Z;
					bool flag2 = false;
					if (OrjPL6[j].Z > copiedPoint[j].Z)
					{
						flag2 = true;
						z = OrjPL6[j].Z;
					}
					if (Item.Settings.settingProfileCut.RoughPerpendicularA)
					{
						a = 90.0;
					}
					if (OrjPL6[j].S == "")
					{
						list5.Add(new Pnt6D(copiedPoint[j].X - Item.Settings.settingProfileCut.RoughLeadIn, copiedPoint[j].Y, z, a, 0.0, 0.0));
						list5.Add(new Pnt6D(copiedPoint[j].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, copiedPoint[j].Y, z, a, 0.0, 0.0));
						list6.Add(new Point3D(copiedPoint[j].X - Item.Settings.settingProfileCut.RoughLeadIn, copiedPoint[j].Y, z));
						list6.Add(new Point3D(copiedPoint[j].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, copiedPoint[j].Y, z));
						List<Pnt6D> calcPoints = new List<Pnt6D>();
						CalculatePointsWithKinematic(list5, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
						list2.Add(list5);
						list4.Add(calcPoints);
						list3.Add(list6);
					}
					if (flag2)
					{
						OrjPL6[j].S = "1";
					}
				}
			}
			if (Item.Settings.settingProfileCut.TwistEnable)
			{
				List<double> Values = new List<double>();
				int num2 = Convert.ToInt32(Math.Abs(Item.Settings.settingProfileCut.TwistStartAngle - Item.Settings.settingProfileCut.TwistEndAngle) / Item.Settings.settingProfileCut.TwisStepAngle);
				buNumeric5.DevideMinMaxValueByNumber(varOperation.settingProfileCut.TwistEndAngle, varOperation.settingProfileCut.TwistStartAngle, num2 + 1, ref Values);
				int num3 = 0;
				double angle = Values[0];
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(Item.ItemEntities.SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
				for (int k = 0; k <= copiedPoint.Count - 1; k++)
				{
					List<Pnt6D> list7 = new List<Pnt6D>();
					List<Point3D> list8 = new List<Point3D>();
					double z2 = copiedPoint[k].Z;
					bool flag3 = false;
					if (OrjPL6[k].S == "")
					{
						double num4 = -99999999.0;
						num3 = 0;
						Point3D point3D = new Point3D(copiedPoint[k].X - Item.Settings.settingProfileCut.RoughLeadIn, copiedPoint[k].Y, z2);
						Point3D point3D2 = new Point3D(copiedPoint[k].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, copiedPoint[k].Y, z2);
						List<Point3D> PointsDevided = new List<Point3D>();
						Point3D point3D3 = new Point3D(OrjPL6[k].X - Item.Settings.settingProfileCut.RoughLeadIn, OrjPL6[k].Y, OrjPL6[k].Z);
						Point3D point3D4 = new Point3D(OrjPL6[k].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, OrjPL6[k].Y, OrjPL6[k].Z);
						List<Point3D> PointsDevided2 = new List<Point3D>();
						double length = buCall.buVector5_0.Length3D(point3D, point3D2) / (double)num2;
						double length2 = buCall.buVector5_0.Length3D(point3D3, point3D4) / (double)num2;
						buCall.buVector5_0.DevideLinePointsByLength(point3D, point3D2, length, ref PointsDevided);
						buCall.buVector5_0.DevideLinePointsByLength(point3D3, point3D4, length2, ref PointsDevided2);
						if (PointsDevided.Count > 0)
						{
							for (int l = 0; l <= PointsDevided2.Count - 1; l++)
							{
								Pnt6D Points = new Pnt6D(PointsDevided2[l].X, PointsDevided2[l].Y, PointsDevided2[l].Z, 0.0, 0.0, 0.0);
								if (num3 <= Values.Count - 1)
								{
									angle = Values[num3];
								}
								buCall.buVector5_0.Rotate(MidPoint, angle, Plane.YZ, ref Points);
								if (Points.Z > num4)
								{
									num4 = Points.Z;
								}
								num3++;
							}
							num3 = 0;
							if (num4 > copiedPoint[k].Z)
							{
								flag3 = true;
								z2 = num4;
							}
							for (int m = 0; m <= PointsDevided.Count - 1; m++)
							{
								double a2 = 0.0;
								double num5 = 0.0;
								if (Item.Settings.settingProfileCut.RoughPerpendicularA)
								{
									a2 = 90.0;
								}
								Pnt6D Points2 = new Pnt6D(PointsDevided[m].X, PointsDevided[m].Y, PointsDevided[k].Z, a2, 0.0, num + 90.0 + num5);
								Point3D Points3 = new Point3D(PointsDevided[m].X, PointsDevided[m].Y, PointsDevided[m].Z);
								Pnt6D Points4 = new Pnt6D(PointsDevided2[m].X, PointsDevided2[m].Y, PointsDevided2[m].Z, a2, 0.0, num + 90.0 + num5);
								Point3D Points5 = new Point3D(PointsDevided2[m].X, PointsDevided2[m].Y, PointsDevided2[m].Z);
								if (num3 <= Values.Count - 1)
								{
									angle = Values[num3];
								}
								if (flag)
								{
									buCall.buVector5_0.Rotate(MidPoint, angle, Plane.YZ, ref Points2);
									buCall.buVector5_0.Rotate(MidPoint, angle, Plane.YZ, ref Points3);
								}
								if (flag3)
								{
									buCall.buVector5_0.Rotate(MidPoint, angle, Plane.YZ, ref Points4);
									buCall.buVector5_0.Rotate(MidPoint, angle, Plane.YZ, ref Points5);
								}
								if (flag3)
								{
									list7.Add(Points4);
									list8.Add(Points5);
								}
								else
								{
									list7.Add(Points2);
									list8.Add(Points3);
								}
								num3++;
							}
							if (list7.Count > 0)
							{
								list2.Add(list7);
								List<Pnt6D> calcPoints2 = new List<Pnt6D>();
								CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
								list4.Add(calcPoints2);
								list3.Add(list8);
							}
						}
					}
					if (flag3)
					{
						OrjPL6[k].S = "1";
					}
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCut.RoughPlungeFeed, Item.Settings.settingProfileCut.RoughCutForwardFeed, Item.Settings.settingProfileCut.RoughCutBackwardFeed, Item.Settings.settingProfileCut.RoughSafeDis, Item.Settings.settingProfileCut.RoughRapid, Item.Settings.settingProfileCut.RoughZigzagMode, Item.Settings.settingProfileCut.RoughAreaMode, Item.Settings.settingProfileCut.RoughMoveUpSafeDistance, isrough: true, isfinish: false, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list2, list4, list3, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.Rough;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileRoughRegion(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, List<Pnt6DS> OrjPL6, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> list2 = new List<Point3D>();
		bool isReverse = false;
		for (int i = 0; i <= OrjPL6.Count - 1; i++)
		{
			List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
			List<List<Point3D>> list4 = new List<List<Point3D>>();
			List<List<Pnt6D>> list5 = new List<List<Pnt6D>>();
			if (i != 85)
			{
			}
			for (int j = 0; j <= PLLSurf.Count - 1; j++)
			{
				if (j != PLLSurf.Count - 1)
				{
				}
				list = PLLSurf[j];
				list2.Clear();
				Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
				if (!Item.Settings.settingProfileCut.RoughReverseCAngle)
				{
				}
				if (!Item.Settings.settingProfileCut.TwistEnable)
				{
					double a = 0.0;
					List<Pnt6D> list6 = new List<Pnt6D>();
					List<Point3D> list7 = new List<Point3D>();
					double z = list[i].Z;
					bool flag = false;
					if (OrjPL6[i].Z > list[i].Z)
					{
						flag = true;
						z = OrjPL6[i].Z;
					}
					if (OrjPL6[i].S == "")
					{
						list6.Add(new Pnt6D(OrjPL6[i].X - Item.Settings.settingProfileCut.RoughLeadIn, OrjPL6[i].Y, z, a, 0.0, 0.0));
						list6.Add(new Pnt6D(OrjPL6[i].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, OrjPL6[i].Y, z, a, 0.0, 0.0));
						list7.Add(new Point3D(OrjPL6[i].X - Item.Settings.settingProfileCut.RoughLeadIn, OrjPL6[i].Y, z));
						list7.Add(new Point3D(OrjPL6[i].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.RoughLeadOut, OrjPL6[i].Y, z));
						List<Pnt6D> calcPoints = new List<Pnt6D>();
						CalculatePointsWithKinematic(list6, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
						list3.Add(list6);
						list5.Add(calcPoints);
						list4.Add(list7);
					}
					if (flag)
					{
						OrjPL6[i].S = "1";
					}
				}
				if (Item.Settings.settingProfileCut.TwistEnable)
				{
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCut.RoughPlungeFeed, Item.Settings.settingProfileCut.RoughCutForwardFeed, Item.Settings.settingProfileCut.RoughCutBackwardFeed, Item.Settings.settingProfileCut.RoughSafeDis, Item.Settings.settingProfileCut.RoughRapid, Item.Settings.settingProfileCut.RoughZigzagMode, Item.Settings.settingProfileCut.RoughAreaMode, Item.Settings.settingProfileCut.RoughMoveUpSafeDistance, isrough: true, isfinish: false, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list3, list5, list4, ref isReverse, activeKinematic, pars);
		}
		CamSawRough.Mode = CamMode.WireFrame;
		CamSawRough.CamWireframeType = marbleCam.WireType;
		CamSawRough.CamTriMeshType = marbleCam.MeshType;
		CamSawRough.NumberOfAxis = 5;
		CamSawRough.TypeCam = CamType.SawCut;
		CamSawRough.Explanation = marbleCam.CamName;
		marbleCam.CamBase = new camTp(CamSawRough);
		marbleCam.isCamCalculated = true;
		buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
		marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
		marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
		marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
		marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
	}

	public void ProfileFinish(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		List<double> list2 = new List<double>();
		List<double> list3 = new List<double>();
		double angle = 0.0;
		int num = 0;
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Item.Settings.settingProfileCut.TwistEnable)
		{
			num = 0;
			angle = list3[0];
			buCall.buVector5_0.BoxSizeCalculate(Item.ItemEntities.SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
		}
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			list2.Clear();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				double num2 = 0.0;
				num2 = ((j == 0) ? buCall.buVector5_0.PointAngle(list[j + 1], list[j], Plane.XZ) : buCall.buVector5_0.PointAngle(list[j], list[j - 1], Plane.XZ));
				if (!(num2 > 180.0))
				{
					list2.Add(0.0);
					continue;
				}
				num2 = 360.0 - num2;
				if (!(num2 >= 0.0 && num2 <= 90.0))
				{
					list2.Add(0.0);
				}
				else
				{
					list2.Add(Math.Round(num2, 5));
				}
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			bool isReverse = false;
			List<List<Pnt6D>> list4 = new List<List<Pnt6D>>();
			List<List<Point3D>> list5 = new List<List<Point3D>>();
			List<List<Pnt6D>> list6 = new List<List<Pnt6D>>();
			if (!Item.Settings.settingProfileCut.FinishReverseCAngle)
			{
			}
			double num3 = buNumeric5.RoundToUpper(Item.Settings.settingProfileCut.Length / Item.Settings.settingProfileCut.FinishStep);
			List<double> Values = new List<double>();
			buNumeric5.DevideMinMaxValueByNumber(copiedPoint[0].X - Item.Settings.settingProfileCut.FinishLeadIn, copiedPoint[0].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.FinishLeadOut, (int)num3, ref Values);
			for (int k = 0; k <= Values.Count - 1; k++)
			{
				if (Item.Settings.settingProfileCut.TwistEnable)
				{
					List<Pnt6D> list7 = new List<Pnt6D>();
					List<Point3D> list8 = new List<Point3D>();
					for (int l = 0; l <= copiedPoint.Count - 1; l++)
					{
						double a = 0.0;
						if (Item.Settings.settingProfileCut.Finish5Axis && l <= list2.Count - 1)
						{
							a = list2[l];
							if (l > 0)
							{
								double num4 = Math.Abs(list2[l] - list2[l - 1]);
								if (num4 > 8.0)
								{
									Pnt6D pnt6D = new Pnt6D(list7[list7.Count - 1]);
									if (!(pnt6D.A <= 0.1))
									{
										double degree = 360.0 - list2[l - 1] + 90.0;
										Pnt6D pnt6D2 = new Pnt6D(pnt6D);
										double num5 = 10.0 * Math.Cos(buConversion5.DegreeToRadian(degree));
										double num6 = 10.0 * Math.Sin(buConversion5.DegreeToRadian(degree));
										double num7 = Math.Cos(buConversion5.DegreeToRadian(pnt6D2.C - 90.0));
										double num8 = Math.Cos(buConversion5.DegreeToRadian(pnt6D2.C - 90.0));
										pnt6D2.X += num5 * num7;
										pnt6D2.Y = pnt6D2.X + num5 * num8;
										pnt6D2.Z += num6;
										list7.Add(pnt6D2);
									}
									else
									{
										Pnt6D pnt6D3 = new Pnt6D(pnt6D);
										pnt6D3.Z += 10.0;
										list7.Add(pnt6D3);
									}
									pnt6D.A = list2[l];
									list7.Add(pnt6D);
								}
							}
						}
						Pnt6D Points = new Pnt6D(Values[k], copiedPoint[l].Y, copiedPoint[l].Z, a, 0.0, 0.0);
						Point3D Points2 = new Point3D(Values[k], copiedPoint[l].Y, copiedPoint[l].Z);
						if (num <= list3.Count - 1)
						{
							angle = list3[num];
						}
						buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points);
						buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points2);
						list7.Add(Points);
						list8.Add(Points2);
					}
					if (list7.Count > 0)
					{
						list4.Add(list7);
						List<Pnt6D> calcPoints = new List<Pnt6D>();
						CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
						list6.Add(calcPoints);
						list5.Add(list8);
					}
					num++;
					continue;
				}
				List<Pnt6D> list9 = new List<Pnt6D>();
				List<Point3D> list10 = new List<Point3D>();
				for (int m = 0; m <= copiedPoint.Count - 1; m++)
				{
					double a2 = 0.0;
					if (Item.Settings.settingProfileCut.Finish5Axis && m <= list2.Count - 1)
					{
						a2 = list2[m];
						if (m > 0)
						{
							double num9 = Math.Abs(list2[m] - list2[m - 1]);
							if (num9 > 8.0)
							{
								Pnt6D pnt6D4 = new Pnt6D(list9[list9.Count - 1]);
								if (!(pnt6D4.A <= 0.1))
								{
									double degree2 = 360.0 - list2[m - 1] + 90.0;
									Pnt6D pnt6D5 = new Pnt6D(pnt6D4);
									double num10 = 10.0 * Math.Cos(buConversion5.DegreeToRadian(degree2));
									double num11 = 10.0 * Math.Sin(buConversion5.DegreeToRadian(degree2));
									double num12 = Math.Cos(buConversion5.DegreeToRadian(pnt6D5.C - 90.0));
									double num13 = Math.Cos(buConversion5.DegreeToRadian(pnt6D5.C - 90.0));
									pnt6D5.X += num10 * num12;
									pnt6D5.Y = pnt6D5.X + num10 * num13;
									pnt6D5.Z += num11;
									list9.Add(pnt6D5);
								}
								else
								{
									Pnt6D pnt6D6 = new Pnt6D(pnt6D4);
									pnt6D6.Z += 10.0;
									list9.Add(pnt6D6);
								}
								pnt6D4.A = list2[m];
								list9.Add(pnt6D4);
							}
						}
					}
					Pnt6D item = new Pnt6D(Values[k], copiedPoint[m].Y, copiedPoint[m].Z, a2, 0.0, 0.0);
					Point3D item2 = new Point3D(Values[k], copiedPoint[m].Y, copiedPoint[m].Z);
					list9.Add(item);
					list10.Add(item2);
				}
				if (list9.Count > 0)
				{
					list4.Add(list9);
					List<Pnt6D> calcPoints2 = new List<Pnt6D>();
					CalculatePointsWithKinematic(list9, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
					list6.Add(calcPoints2);
					list5.Add(list10);
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCut.FinishPlungeFeed, Item.Settings.settingProfileCut.FinishCutForwardFeed, Item.Settings.settingProfileCut.FinishCutBackwardFeed, Item.Settings.settingProfileCut.FinishSafeDis, 20.0, Item.Settings.settingProfileCut.FinishZigzagMode, MarbleCamAreaMode.Region, Item.Settings.settingProfileCut.FinishMoveUpSafe, isrough: false, isfinish: true, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list4, list6, list5, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.SawCut;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileOffset(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			bool isReverse = false;
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			List<List<Point3D>> list3 = new List<List<Point3D>>();
			List<List<Pnt6D>> list4 = new List<List<Pnt6D>>();
			double a = 0.0;
			if (!Item.Settings.settingProfileCut.OffsetReverseCAngle)
			{
			}
			for (int j = 0; j <= copiedPoint.Count - 1; j++)
			{
				List<Pnt6D> list5 = new List<Pnt6D>();
				List<Point3D> list6 = new List<Point3D>();
				double z = copiedPoint[j].Z;
				list5.Add(new Pnt6D(copiedPoint[j].X - Item.Settings.settingProfileCut.RoughLeadIn, copiedPoint[j].Y, z, a, 0.0, 0.0));
				list5.Add(new Pnt6D(copiedPoint[j].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.OffsetLeadOut, copiedPoint[j].Y, z, a, 0.0, 0.0));
				list6.Add(new Point3D(copiedPoint[j].X - Item.Settings.settingProfileCut.RoughLeadIn, copiedPoint[j].Y, z));
				list6.Add(new Point3D(copiedPoint[j].X + Item.Settings.settingProfileCut.Length + Item.Settings.settingProfileCut.OffsetLeadOut, copiedPoint[j].Y, z));
				if (list5.Count > 0)
				{
					list2.Add(list5);
					List<Pnt6D> calcPoints = new List<Pnt6D>();
					CalculatePointsWithKinematic(list5, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
					list4.Add(calcPoints);
					list3.Add(list6);
				}
			}
			if (Item.Settings.settingProfileCut.OffsetCutEdges)
			{
				List<Pnt6D> list7 = new List<Pnt6D>();
				List<Point3D> list8 = new List<Point3D>();
				Pnt6D pnt6D = new Pnt6D(list2[0][0]);
				Pnt6D pnt6D2 = new Pnt6D(list2[1][0]);
				pnt6D.C = buCall.buVector5_0.PointAngle(pnt6D2, pnt6D);
				pnt6D.A = 0.0;
				pnt6D2.C = buCall.buVector5_0.PointAngle(pnt6D2, pnt6D);
				pnt6D2.A = 0.0;
				list7.Add(pnt6D);
				list7.Add(pnt6D2);
				list2.Add(list7);
				list8.Add(new Point3D(list3[0][0].X, list3[0][0].Y, list3[0][0].Z));
				list8.Add(new Point3D(list3[1][0].X, list3[1][0].Y, list3[1][0].Z));
				List<Pnt6D> calcPoints2 = new List<Pnt6D>();
				CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
				list4.Add(calcPoints2);
				list3.Add(list8);
				list7 = new List<Pnt6D>();
				list8 = new List<Point3D>();
				pnt6D = new Pnt6D(list2[0][list2[0].Count - 1]);
				pnt6D.A = 0.0;
				pnt6D2 = new Pnt6D(list2[1][list2[1].Count - 1]);
				pnt6D2.A = 0.0;
				pnt6D.C = buCall.buVector5_0.PointAngle(pnt6D, pnt6D2);
				pnt6D2.C = buCall.buVector5_0.PointAngle(pnt6D, pnt6D2);
				list7.Add(pnt6D2);
				list7.Add(pnt6D);
				list2.Add(list7);
				list8.Add(new Point3D(list3[0][list3[0].Count - 1].X, list3[0][list3[0].Count - 1].Y, list3[0][list3[0].Count - 1].Z));
				list8.Add(new Point3D(list3[1][list3[1].Count - 1].X, list3[1][list3[1].Count - 1].Y, list3[1][list3[1].Count - 1].Z));
				calcPoints2 = new List<Pnt6D>();
				CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
				list4.Add(calcPoints2);
				list3.Add(list8);
			}
			if (!Item.Settings.settingProfileCut.OffsetCutOutside)
			{
				list2.RemoveAt(1);
				list4.RemoveAt(1);
				list3.RemoveAt(1);
			}
			if (!Item.Settings.settingProfileCut.OffsetCutInisde)
			{
				list2.RemoveAt(0);
				list4.RemoveAt(0);
				list3.RemoveAt(0);
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCut.OffsetPlungeFeed, Item.Settings.settingProfileCut.OffsetCutForwardFeed, Item.Settings.settingProfileCut.OffsetCutBackwardFeed, Item.Settings.settingProfileCut.OffsetSafeDis, 20.0, Item.Settings.settingProfileCut.OffsetZigzagMode, MarbleCamAreaMode.Region, Item.Settings.settingProfileCut.RoughMoveUpSafeDistance, isrough: false, isfinish: false, isoffset: true);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list2, list4, list3, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.SawCut;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileCurveRoughLevel(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, List<Pnt6DS> OrjPL6, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			bool flag = false;
			if (i == PLLSurf.Count - 1)
			{
				flag = true;
			}
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			bool isReverse = false;
			double num = buNumeric5.RoundToUpper(Item.Settings.settingProfileCurveCut.SweepAngle / Item.Settings.settingProfileCurveCut.RoughAngleStep);
			double num2 = Item.Settings.settingProfileCurveCut.SweepAngle / num;
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			List<List<Point3D>> list3 = new List<List<Point3D>>();
			List<List<Pnt6D>> list4 = new List<List<Pnt6D>>();
			double num3 = 0.0;
			if (Item.Settings.settingProfileCurveCut.RoughReverseCAngle)
			{
				num3 = 180.0;
			}
			if (!Item.Settings.settingProfileCurveCut.TwistEnable)
			{
				for (int j = 0; j <= copiedPoint.Count - 1; j++)
				{
					List<Pnt6D> Points = new List<Pnt6D>();
					List<Point3D> refPoints = new List<Point3D>();
					double z = copiedPoint[j].Z;
					bool flag2 = false;
					if (OrjPL6[j].Z > copiedPoint[j].Z)
					{
						flag2 = true;
						z = OrjPL6[j].Z;
					}
					if (OrjPL6[j].S == "")
					{
						for (double num4 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num4 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num4 += num2)
						{
							double a = 0.0;
							if (Item.Settings.settingProfileCurveCut.RoughPerpendicularA)
							{
								a = 90.0;
							}
							Pnt6D Points2 = new Pnt6D(copiedPoint[j].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[j].Y, z, a, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num4);
							Point3D Points3 = new Point3D(copiedPoint[j].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[j].Y, z);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points2);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points3);
							Points.Add(Points2);
							refPoints.Add(Points3);
						}
						if (Points.Count > 0)
						{
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points);
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints);
							list2.Add(Points);
							List<Pnt6D> calcPoints = new List<Pnt6D>();
							CalculatePointsWithKinematic(Points, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
							list4.Add(calcPoints);
							list3.Add(refPoints);
						}
					}
					if (flag2)
					{
						OrjPL6[j].S = "1";
					}
				}
			}
			if (Item.Settings.settingProfileCurveCut.TwistEnable)
			{
				List<double> Values = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(varOperation.settingProfileCurveCut.TwistEndAngle, varOperation.settingProfileCurveCut.TwistStartAngle, (int)num + 1, ref Values);
				int num5 = 0;
				double angle = Values[0];
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(Item.ItemEntities.SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
				MidPoint.X += Item.Settings.settingProfileCurveCut.Radius;
				for (int k = 0; k <= copiedPoint.Count - 1; k++)
				{
					List<Pnt6D> Points4 = new List<Pnt6D>();
					List<Point3D> refPoints2 = new List<Point3D>();
					_ = copiedPoint[k].Z;
					bool flag3 = false;
					if (OrjPL6[k].S == "")
					{
						double num6 = -99999999.0;
						num5 = 0;
						for (double num7 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num7 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num7 += num2)
						{
							Pnt6D Points5 = new Pnt6D(OrjPL6[k].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[k].Y, OrjPL6[k].Z, 0.0, 0.0, 0.0);
							if (num5 <= Values.Count - 1)
							{
								angle = Values[num5];
							}
							buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points5);
							if (Points5.Z > num6)
							{
								num6 = Points5.Z;
							}
							num5++;
						}
						num5 = 0;
						if (num6 > copiedPoint[k].Z)
						{
							flag3 = true;
						}
						for (double num8 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num8 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num8 += num2)
						{
							double a2 = 0.0;
							if (Item.Settings.settingProfileCurveCut.RoughPerpendicularA)
							{
								a2 = 90.0;
							}
							Pnt6D Points6 = new Pnt6D(copiedPoint[k].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[k].Y, copiedPoint[k].Z, a2, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num8);
							Point3D Points7 = new Point3D(copiedPoint[k].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[k].Y, copiedPoint[k].Z);
							Pnt6D Points8 = new Pnt6D(OrjPL6[k].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[k].Y, OrjPL6[k].Z, a2, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num8);
							Point3D Points9 = new Point3D(OrjPL6[k].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[k].Y, OrjPL6[k].Z);
							if (num5 <= Values.Count - 1)
							{
								angle = Values[num5];
							}
							if (flag)
							{
								buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points6);
								buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points7);
							}
							if (flag3)
							{
								buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points8);
								buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points9);
							}
							if (flag3)
							{
								buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points8);
								buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points9);
								Points4.Add(Points8);
								refPoints2.Add(Points9);
							}
							else
							{
								buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points6);
								buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points7);
								Points4.Add(Points6);
								refPoints2.Add(Points7);
							}
							num5++;
						}
						if (Points4.Count > 0)
						{
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points4);
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints2);
							list2.Add(Points4);
							List<Pnt6D> calcPoints2 = new List<Pnt6D>();
							CalculatePointsWithKinematic(Points4, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
							list4.Add(calcPoints2);
							list3.Add(refPoints2);
						}
					}
					if (flag3)
					{
						OrjPL6[k].S = "1";
					}
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCurveCut.RoughPlungeFeed, Item.Settings.settingProfileCurveCut.RoughCutForwardFeed, Item.Settings.settingProfileCurveCut.RoughCutBackwardFeed, Item.Settings.settingProfileCurveCut.RoughSafeDis, Item.Settings.settingProfileCurveCut.RoughRapid, Item.Settings.settingProfileCurveCut.RoughZigzagMode, Item.Settings.settingProfileCurveCut.RoughAreaMode, moveupsafedis: true, isrough: true, isfinish: false, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list2, list4, list3, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.SawCut;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileCurveRoughRegion(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, List<Pnt6DS> OrjPL6, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> list2 = new List<Point3D>();
		bool isReverse = false;
		for (int i = 0; i <= OrjPL6.Count - 1; i++)
		{
			List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
			List<List<Point3D>> list4 = new List<List<Point3D>>();
			List<List<Pnt6D>> list5 = new List<List<Pnt6D>>();
			double num = buNumeric5.RoundToUpper(Item.Settings.settingProfileCurveCut.SweepAngle / Item.Settings.settingProfileCurveCut.RoughAngleStep);
			double num2 = Item.Settings.settingProfileCurveCut.SweepAngle / num;
			double num3 = 0.0;
			if (i != 85)
			{
			}
			for (int j = 0; j <= PLLSurf.Count - 1; j++)
			{
				bool flag = false;
				if (j == PLLSurf.Count - 1)
				{
					flag = true;
				}
				list = PLLSurf[j];
				list2.Clear();
				Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
				if (Item.Settings.settingProfileCurveCut.RoughReverseCAngle)
				{
					num3 = 180.0;
				}
				if (!Item.Settings.settingProfileCurveCut.TwistEnable)
				{
					List<Pnt6D> Points = new List<Pnt6D>();
					List<Point3D> refPoints = new List<Point3D>();
					double z = list[i].Z;
					bool flag2 = false;
					if (OrjPL6[i].Z > list[i].Z)
					{
						flag2 = true;
						z = OrjPL6[i].Z;
					}
					if (OrjPL6[i].S == "")
					{
						for (double num4 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num4 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num4 += num2)
						{
							double a = 0.0;
							if (Item.Settings.settingProfileCurveCut.RoughPerpendicularA)
							{
								a = 90.0;
							}
							Pnt6D Points2 = new Pnt6D(list[i].X + Item.Settings.settingProfileCurveCut.Radius, list[i].Y, z, a, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num4);
							Point3D Points3 = new Point3D(list[i].X + Item.Settings.settingProfileCurveCut.Radius, list[i].Y, z);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points2);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points3);
							Points.Add(Points2);
							refPoints.Add(Points3);
						}
						if (Points.Count > 0)
						{
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points);
							buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints);
							list3.Add(Points);
							List<Pnt6D> calcPoints = new List<Pnt6D>();
							CalculatePointsWithKinematic(Points, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
							list5.Add(calcPoints);
							list4.Add(refPoints);
						}
					}
					if (flag2)
					{
						OrjPL6[i].S = "1";
					}
				}
				if (!Item.Settings.settingProfileCurveCut.TwistEnable)
				{
					continue;
				}
				List<double> Values = new List<double>();
				buNumeric5.DevideMinMaxValueByNumber(varOperation.settingProfileCurveCut.TwistEndAngle, varOperation.settingProfileCurveCut.TwistStartAngle, (int)num + 1, ref Values);
				int num5 = 0;
				double angle = Values[0];
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(Item.ItemEntities.SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
				MidPoint.X += Item.Settings.settingProfileCurveCut.Radius;
				List<Pnt6D> Points4 = new List<Pnt6D>();
				List<Point3D> refPoints2 = new List<Point3D>();
				_ = list[i].Z;
				bool flag3 = false;
				if (OrjPL6[i].S == "")
				{
					double num6 = -99999999.0;
					num5 = 0;
					for (double num7 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num7 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num7 += num2)
					{
						Pnt6D Points5 = new Pnt6D(OrjPL6[i].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[i].Y, OrjPL6[i].Z, 0.0, 0.0, 0.0);
						if (num5 <= Values.Count - 1)
						{
							angle = Values[num5];
						}
						buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points5);
						if (Points5.Z > num6)
						{
							num6 = Points5.Z;
						}
						num5++;
					}
					num5 = 0;
					if (num6 > list[i].Z)
					{
						flag3 = true;
					}
					for (double num8 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.RoughLeadInAngle; num8 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.RoughLeadOutAngle; num8 += num2)
					{
						double a2 = 0.0;
						if (Item.Settings.settingProfileCurveCut.RoughPerpendicularA)
						{
							a2 = 90.0;
						}
						Pnt6D Points6 = new Pnt6D(list[i].X + Item.Settings.settingProfileCurveCut.Radius, list[i].Y, list[i].Z, a2, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num8);
						Point3D Points7 = new Point3D(list[i].X + Item.Settings.settingProfileCurveCut.Radius, list[i].Y, list[i].Z);
						Pnt6D Points8 = new Pnt6D(OrjPL6[i].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[i].Y, OrjPL6[i].Z, a2, 0.0, num3 + 90.0 + Item.Settings.settingProfileCurveCut.RoughCOffsetAngle + num8);
						Point3D Points9 = new Point3D(OrjPL6[i].X + Item.Settings.settingProfileCurveCut.Radius, OrjPL6[i].Y, OrjPL6[i].Z);
						if (num5 <= Values.Count - 1)
						{
							angle = Values[num5];
						}
						if (flag)
						{
							buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points6);
							buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points7);
						}
						if (flag3)
						{
							buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points8);
							buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points9);
						}
						if (flag3)
						{
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points8);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points9);
							Points4.Add(Points8);
							refPoints2.Add(Points9);
						}
						else
						{
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points6);
							buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num8, Plane.XY, ref Points7);
							Points4.Add(Points6);
							refPoints2.Add(Points7);
						}
						num5++;
					}
					if (Points4.Count > 0)
					{
						buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points4);
						buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints2);
						list3.Add(Points4);
						List<Pnt6D> calcPoints2 = new List<Pnt6D>();
						CalculatePointsWithKinematic(Points4, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
						list5.Add(calcPoints2);
						list4.Add(refPoints2);
					}
				}
				if (flag3)
				{
					OrjPL6[i].S = "1";
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCurveCut.RoughPlungeFeed, Item.Settings.settingProfileCurveCut.RoughCutForwardFeed, Item.Settings.settingProfileCurveCut.RoughCutBackwardFeed, Item.Settings.settingProfileCurveCut.RoughSafeDis, Item.Settings.settingProfileCurveCut.RoughRapid, Item.Settings.settingProfileCurveCut.RoughZigzagMode, Item.Settings.settingProfileCurveCut.RoughAreaMode, Item.Settings.settingProfileCurveCut.RoughMoveUpSafeDistance, isrough: true, isfinish: false, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list3, list5, list4, ref isReverse, activeKinematic, pars);
		}
		CamSawRough.Mode = CamMode.WireFrame;
		CamSawRough.CamWireframeType = marbleCam.WireType;
		CamSawRough.CamTriMeshType = marbleCam.MeshType;
		CamSawRough.NumberOfAxis = 5;
		CamSawRough.TypeCam = CamType.SawCut;
		CamSawRough.Explanation = marbleCam.CamName;
		marbleCam.CamBase = new camTp(CamSawRough);
		marbleCam.isCamCalculated = true;
		buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
		marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
		marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
		marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
		marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
	}

	public void ProfileCurveFinish(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		List<double> list2 = new List<double>();
		List<double> Values = new List<double>();
		double angle = 0.0;
		int num = 0;
		Point3D MinPoint = new Point3D();
		Point3D MidPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		double num2 = buNumeric5.RoundToUpper(Item.Settings.settingProfileCurveCut.SweepAngle / Item.Settings.settingProfileCurveCut.FinishAngleStep);
		double num3 = Item.Settings.settingProfileCurveCut.SweepAngle / num2;
		if (Item.Settings.settingProfileCurveCut.TwistEnable)
		{
			buNumeric5.DevideMinMaxValueByNumber(varOperation.settingProfileCurveCut.TwistEndAngle, varOperation.settingProfileCurveCut.TwistStartAngle, (int)num2 + 1, ref Values);
			num = 0;
			angle = Values[0];
			buCall.buVector5_0.BoxSizeCalculate(Item.ItemEntities.SourceEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
			MidPoint.X += Item.Settings.settingProfileCurveCut.Radius;
		}
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			list2.Clear();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				double num4 = 0.0;
				num4 = ((j == 0) ? buCall.buVector5_0.PointAngle(list[j + 1], list[j], Plane.XZ) : buCall.buVector5_0.PointAngle(list[j], list[j - 1], Plane.XZ));
				if (!(num4 > 180.0))
				{
					list2.Add(0.0);
					continue;
				}
				num4 = 360.0 - num4;
				if (!(num4 >= 0.0 && num4 <= 90.0))
				{
					list2.Add(0.0);
				}
				else
				{
					list2.Add(Math.Round(num4, 5));
				}
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			bool isReverse = false;
			List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
			List<List<Point3D>> list4 = new List<List<Point3D>>();
			List<List<Pnt6D>> list5 = new List<List<Pnt6D>>();
			double num5 = 0.0;
			if (Item.Settings.settingProfileCurveCut.FinishReverseCAngle)
			{
				num5 = 180.0;
			}
			for (double num6 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.FinishLeadInAngle; num6 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.FinishLeadOutAngle; num6 += num3)
			{
				if (Item.Settings.settingProfileCurveCut.TwistEnable)
				{
					List<Pnt6D> Points = new List<Pnt6D>();
					List<Point3D> refPoints = new List<Point3D>();
					for (int k = 0; k <= copiedPoint.Count - 1; k++)
					{
						double a = 0.0;
						if (Item.Settings.settingProfileCurveCut.Finish5Axis && k <= list2.Count - 1)
						{
							a = list2[k];
							if (k > 0)
							{
								double num7 = Math.Abs(list2[k] - list2[k - 1]);
								if (num7 > 8.0)
								{
									Pnt6D pnt6D = new Pnt6D(Points[Points.Count - 1]);
									if (!(pnt6D.A <= 0.1))
									{
										double degree = 360.0 - list2[k - 1] + 90.0;
										Pnt6D pnt6D2 = new Pnt6D(pnt6D);
										double num8 = 10.0 * Math.Cos(buConversion5.DegreeToRadian(degree));
										double num9 = 10.0 * Math.Sin(buConversion5.DegreeToRadian(degree));
										double num10 = Math.Cos(buConversion5.DegreeToRadian(pnt6D2.C - 90.0));
										double num11 = Math.Cos(buConversion5.DegreeToRadian(pnt6D2.C - 90.0));
										pnt6D2.X += num8 * num10;
										pnt6D2.Y = pnt6D2.X + num8 * num11;
										pnt6D2.Z += num9;
										Points.Add(pnt6D2);
									}
									else
									{
										Pnt6D pnt6D3 = new Pnt6D(pnt6D);
										pnt6D3.Z += 10.0;
										Points.Add(pnt6D3);
									}
									pnt6D.A = list2[k];
									Points.Add(pnt6D);
								}
							}
						}
						Pnt6D Points2 = new Pnt6D(copiedPoint[k].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[k].Y, copiedPoint[k].Z, a, 0.0, num5 + 90.0 + num6);
						Point3D Points3 = new Point3D(copiedPoint[k].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[k].Y, copiedPoint[k].Z);
						if (num <= Values.Count - 1)
						{
							angle = Values[num];
						}
						buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points2);
						buCall.buVector5_0.Rotate(MidPoint, angle, Plane.XZ, ref Points3);
						buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num6, Plane.XY, ref Points2);
						buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num6, Plane.XY, ref Points3);
						Points.Add(Points2);
						refPoints.Add(Points3);
					}
					if (Points.Count > 0)
					{
						buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points);
						buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints);
						list3.Add(Points);
						List<Pnt6D> calcPoints = new List<Pnt6D>();
						CalculatePointsWithKinematic(Points, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
						list5.Add(calcPoints);
						list4.Add(refPoints);
					}
					num++;
					continue;
				}
				List<Pnt6D> Points4 = new List<Pnt6D>();
				List<Point3D> refPoints2 = new List<Point3D>();
				for (int l = 0; l <= copiedPoint.Count - 1; l++)
				{
					double a2 = 0.0;
					if (Item.Settings.settingProfileCurveCut.Finish5Axis && l <= list2.Count - 1)
					{
						a2 = list2[l];
						if (l > 0)
						{
							double num12 = Math.Abs(list2[l] - list2[l - 1]);
							if (num12 > 8.0)
							{
								Pnt6D pnt6D4 = new Pnt6D(Points4[Points4.Count - 1]);
								if (!(pnt6D4.A <= 0.1))
								{
									double degree2 = 360.0 - list2[l - 1] + 90.0;
									Pnt6D pnt6D5 = new Pnt6D(pnt6D4);
									double num13 = 10.0 * Math.Cos(buConversion5.DegreeToRadian(degree2));
									double num14 = 10.0 * Math.Sin(buConversion5.DegreeToRadian(degree2));
									double num15 = Math.Cos(buConversion5.DegreeToRadian(pnt6D5.C - 90.0));
									double num16 = Math.Cos(buConversion5.DegreeToRadian(pnt6D5.C - 90.0));
									pnt6D5.X += num13 * num15;
									pnt6D5.Y = pnt6D5.X + num13 * num16;
									pnt6D5.Z += num14;
									Points4.Add(pnt6D5);
								}
								else
								{
									Pnt6D pnt6D6 = new Pnt6D(pnt6D4);
									pnt6D6.Z += 10.0;
									Points4.Add(pnt6D6);
								}
								pnt6D4.A = list2[l];
								Points4.Add(pnt6D4);
							}
						}
					}
					Pnt6D Points5 = new Pnt6D(copiedPoint[l].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[l].Y, copiedPoint[l].Z, a2, 0.0, num5 + 90.0 + num6);
					Point3D Points6 = new Point3D(copiedPoint[l].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[l].Y, copiedPoint[l].Z);
					buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num6, Plane.XY, ref Points5);
					buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num6, Plane.XY, ref Points6);
					Points4.Add(Points5);
					refPoints2.Add(Points6);
				}
				if (Points4.Count > 0)
				{
					buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref Points4);
					buCall.buVector5_0.Move(0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.X, 0.0 - Item.Settings.settingProfileCurveCut.Radius + Item.CalcMovePoint.Y, Item.CalcMovePoint.Z, ref refPoints2);
					list3.Add(Points4);
					List<Pnt6D> calcPoints2 = new List<Pnt6D>();
					CalculatePointsWithKinematic(Points4, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
					list5.Add(calcPoints2);
					list4.Add(refPoints2);
				}
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCurveCut.FinishPlungeFeed, Item.Settings.settingProfileCurveCut.FinishCutForwardFeed, Item.Settings.settingProfileCurveCut.FinishCutBackwardFeed, Item.Settings.settingProfileCurveCut.FinishSafeDis, 20.0, Item.Settings.settingProfileCurveCut.FinishZigzagMode, MarbleCamAreaMode.Region, Item.Settings.settingProfileCurveCut.FinishMoveUpSafe, isrough: false, isfinish: true, isoffset: false);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list3, list5, list4, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.SawCut;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileCurveOffset(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLLSurf, KinematicBase5 activeKinematic)
	{
		if (PLLSurf.Count <= 0)
		{
			return;
		}
		camTp CamSawRough = new camTp();
		List<Point3D> list = null;
		List<Point3D> copiedPoint = new List<Point3D>();
		for (int i = 0; i <= PLLSurf.Count - 1; i++)
		{
			list = PLLSurf[i];
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref list);
			copiedPoint.Clear();
			buVector5.Copy(list, ref copiedPoint);
			if (copiedPoint.Count <= 0)
			{
				continue;
			}
			Item.Settings.settingMarbleCam.OffsetAngleC = 0.0;
			bool isReverse = false;
			double num = buNumeric5.RoundToUpper(Item.Settings.settingProfileCurveCut.SweepAngle / Item.Settings.settingProfileCurveCut.OffsetAngleStep);
			double num2 = Item.Settings.settingProfileCurveCut.SweepAngle / num;
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			List<List<Point3D>> list3 = new List<List<Point3D>>();
			List<List<Pnt6D>> list4 = new List<List<Pnt6D>>();
			double num3 = 0.0;
			if (Item.Settings.settingProfileCurveCut.OffsetReverseCAngle)
			{
				num3 = 180.0;
			}
			for (int j = 0; j <= copiedPoint.Count - 1; j++)
			{
				List<Pnt6D> list5 = new List<Pnt6D>();
				List<Point3D> list6 = new List<Point3D>();
				double z = copiedPoint[j].Z;
				for (double num4 = Item.Settings.settingProfileCurveCut.StartAngle - Item.Settings.settingProfileCurveCut.OffsetLeadInAngle; num4 <= Item.Settings.settingProfileCurveCut.StartAngle + Item.Settings.settingProfileCurveCut.SweepAngle + Item.Settings.settingProfileCurveCut.OffsetLeadOutAngle; num4 += num2)
				{
					double a = 0.0;
					if (j == 0)
					{
						a = Item.Settings.settingProfileCurveCut.OffsetInnerCutAAngle;
					}
					Pnt6D Points = new Pnt6D(copiedPoint[j].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[j].Y, z, a, 0.0, num3 + 90.0 + num4);
					Point3D Points2 = new Point3D(copiedPoint[j].X + Item.Settings.settingProfileCurveCut.Radius, copiedPoint[j].Y, z);
					buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points);
					buCall.buVector5_0.Rotate(new Point3D(Item.BasePoint.X, Item.BasePoint.Y, Item.BasePoint.Z), num4, Plane.XY, ref Points2);
					list5.Add(Points);
					list6.Add(Points2);
				}
				if (list5.Count > 0)
				{
					list2.Add(list5);
					List<Pnt6D> calcPoints = new List<Pnt6D>();
					CalculatePointsWithKinematic(list5, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
					list4.Add(calcPoints);
					list3.Add(list6);
				}
			}
			if (Item.Settings.settingProfileCurveCut.OffsetCutEdges)
			{
				List<Pnt6D> list7 = new List<Pnt6D>();
				List<Point3D> list8 = new List<Point3D>();
				Pnt6D pnt6D = new Pnt6D(list2[0][0]);
				Pnt6D pnt6D2 = new Pnt6D(list2[1][0]);
				pnt6D.C = buCall.buVector5_0.PointAngle(pnt6D2, pnt6D);
				pnt6D.A = 0.0;
				pnt6D2.C = buCall.buVector5_0.PointAngle(pnt6D2, pnt6D);
				pnt6D2.A = 0.0;
				list7.Add(pnt6D);
				list7.Add(pnt6D2);
				list2.Add(list7);
				list8.Add(new Point3D(list3[0][0].X, list3[0][0].Y, list3[0][0].Z));
				list8.Add(new Point3D(list3[1][0].X, list3[1][0].Y, list3[1][0].Z));
				List<Pnt6D> calcPoints2 = new List<Pnt6D>();
				CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
				list4.Add(calcPoints2);
				list3.Add(list8);
				list7 = new List<Pnt6D>();
				list8 = new List<Point3D>();
				pnt6D = new Pnt6D(list2[0][list2[0].Count - 1]);
				pnt6D.A = 0.0;
				pnt6D2 = new Pnt6D(list2[1][list2[1].Count - 1]);
				pnt6D2.A = 0.0;
				pnt6D.C = buCall.buVector5_0.PointAngle(pnt6D, pnt6D2);
				pnt6D2.C = buCall.buVector5_0.PointAngle(pnt6D, pnt6D2);
				list7.Add(pnt6D2);
				list7.Add(pnt6D);
				list2.Add(list7);
				list8.Add(new Point3D(list3[0][list3[0].Count - 1].X, list3[0][list3[0].Count - 1].Y, list3[0][list3[0].Count - 1].Z));
				list8.Add(new Point3D(list3[1][list3[1].Count - 1].X, list3[1][list3[1].Count - 1].Y, list3[1][list3[1].Count - 1].Z));
				calcPoints2 = new List<Pnt6D>();
				CalculatePointsWithKinematic(list7, activeKinematic, marbleCam.ToolSelected, ref calcPoints2);
				list4.Add(calcPoints2);
				list3.Add(list8);
			}
			if (!Item.Settings.settingProfileCurveCut.OffsetCutOutside)
			{
				list2.RemoveAt(1);
				list4.RemoveAt(1);
				list3.RemoveAt(1);
			}
			if (!Item.Settings.settingProfileCurveCut.OffsetCutInisde)
			{
				list2.RemoveAt(0);
				list4.RemoveAt(0);
				list3.RemoveAt(0);
			}
			MarbleProfileCalcParameters pars = new MarbleProfileCalcParameters(Item.Settings.settingProfileCurveCut.OffsetPlungeFeed, Item.Settings.settingProfileCurveCut.OffsetCutForwardFeed, Item.Settings.settingProfileCurveCut.OffsetCutBackwardFeed, Item.Settings.settingProfileCurveCut.OffsetSafeDis, 20.0, Item.Settings.settingProfileCurveCut.OffsetZigzagMode, MarbleCamAreaMode.Region, Item.Settings.settingProfileCurveCut.RoughMoveUpSafeDistance, isrough: false, isfinish: false, isoffset: true);
			ProfileCamCalcFromPnt6DList(ref Item, ref marbleCam, ref CamSawRough, list2, list4, list3, ref isReverse, activeKinematic, pars);
			CamSawRough.Mode = CamMode.WireFrame;
			CamSawRough.CamWireframeType = marbleCam.WireType;
			CamSawRough.CamTriMeshType = marbleCam.MeshType;
			CamSawRough.NumberOfAxis = 5;
			CamSawRough.TypeCam = CamType.SawCut;
			CamSawRough.Explanation = marbleCam.CamName;
			marbleCam.CamBase = new camTp(CamSawRough);
			marbleCam.isCamCalculated = true;
			buCall.buVector5_0.BoxSizeCalculate(marbleCam.CamBase, ref marbleCam.SizeCamItem.MinPoint, ref marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.MidPoint = buCall.buVector5_0.MiddlePointOfLine(marbleCam.SizeCamItem.MinPoint, marbleCam.SizeCamItem.MaxPoint);
			marbleCam.SizeCamItem.Width = marbleCam.SizeCamItem.MaxPoint.X - marbleCam.SizeCamItem.MinPoint.X;
			marbleCam.SizeCamItem.Height = marbleCam.SizeCamItem.MaxPoint.Y - marbleCam.SizeCamItem.MinPoint.Y;
			marbleCam.SizeCamItem.Depth = marbleCam.SizeCamItem.MaxPoint.Z - marbleCam.SizeCamItem.MinPoint.Z;
		}
	}

	public void ProfileCamCalcFromPnt6DList(ref MarbleItem Item, ref MarbleItemCam marbleCam, ref camTp CamSawRough, List<List<Pnt6D>> arrPL6, List<List<Pnt6D>> arrCalcPL6, List<List<Point3D>> arrPLCam, ref bool isReverse, KinematicBase5 activeKinematic, MarbleProfileCalcParameters Pars)
	{
		TpPnt9D tpPnt9D = null;
		int num = 0;
		if (arrPL6.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= arrCalcPL6.Count - 1; i++)
		{
			camTpPoint camTpPoint2 = new camTpPoint();
			List<Pnt6D> CopiedPnt = new List<Pnt6D>();
			Pnt6D.Copy(arrCalcPL6[i], ref CopiedPnt);
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(arrPLCam[i], ref copiedPoint);
			if (CopiedPnt.Count <= 0)
			{
				continue;
			}
			Pnt6D pnt6D = new Pnt6D(arrPL6[i][0]);
			if (isReverse)
			{
				pnt6D = new Pnt6D(arrPL6[i][arrPL6[i].Count - 1]);
			}
			Pnt6D calcPoint = new Pnt6D();
			if (num != 0)
			{
				pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.RapidDistance;
			}
			else
			{
				pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.SafeDistance;
			}
			CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
			if (isReverse)
			{
				CopiedPnt.Reverse();
			}
			if (Pars.ZigzagMode)
			{
				if (!Pars.isRough)
				{
					if (num != 0)
					{
						if (Pars.MoveUpSafe)
						{
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
							camTpPoint2.Points.Add(tpPnt9D);
						}
					}
					else
					{
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						camTpPoint2.Points.Add(tpPnt9D);
					}
				}
				else if ((num == 0) | (Pars.RoughAreaMode == MarbleCamAreaMode.Level))
				{
					tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
					camTpPoint2.Points.Add(tpPnt9D);
				}
			}
			else
			{
				tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
				camTpPoint2.Points.Add(tpPnt9D);
			}
			if (!Pars.ZigzagMode)
			{
				tpPnt9D = new TpPnt9D(CopiedPnt[0], 100.0, 0);
				tpPnt9D.P9.Z = Item.SizeItem.MaxPoint.Z + Pars.SafeDistance;
				camTpPoint2.Points.Add(tpPnt9D);
			}
			tpPnt9D = new TpPnt9D(CopiedPnt[0], Pars.PlungeSpeed, 1);
			camTpPoint2.Points.Add(tpPnt9D);
			for (int j = 1; j <= CopiedPnt.Count - 1; j++)
			{
				double feed = Pars.ForwardCutSpeed;
				if (isReverse)
				{
					feed = Pars.BackwardSpeed;
				}
				tpPnt9D = new TpPnt9D(CopiedPnt[j], feed, 1);
				camTpPoint2.Points.Add(tpPnt9D);
			}
			if (!Pars.ZigzagMode)
			{
				pnt6D = new Pnt6D(arrPL6[i][arrPL6[i].Count - 1]);
				calcPoint = new Pnt6D();
				pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.SafeDistance;
				CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
				tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
				camTpPoint2.Points.Add(tpPnt9D);
				isReverse = false;
			}
			else
			{
				if (i != arrCalcPL6.Count - 1)
				{
					calcPoint = new Pnt6D();
					pnt6D = ((!isReverse) ? new Pnt6D(arrPL6[i][arrPL6[i].Count - 1]) : new Pnt6D(arrPL6[i][0]));
					if (!Pars.isRough)
					{
						if (Pars.MoveUpSafe)
						{
							pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.RapidDistance;
							CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
							tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
							camTpPoint2.Points.Add(tpPnt9D);
						}
					}
					else if (Pars.RoughAreaMode == MarbleCamAreaMode.Level)
					{
						pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.RapidDistance;
						CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
						tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
						camTpPoint2.Points.Add(tpPnt9D);
					}
				}
				else
				{
					pnt6D = ((!isReverse) ? new Pnt6D(arrPL6[i][arrPL6[i].Count - 1]) : new Pnt6D(arrPL6[i][0]));
					calcPoint = new Pnt6D();
					pnt6D.Z = Item.SizeItem.MaxPoint.Z + Pars.SafeDistance;
					CalculatePointsWithKinematic(pnt6D, activeKinematic, marbleCam.ToolSelected, ref calcPoint);
					tpPnt9D = new TpPnt9D(calcPoint, 100.0, 0);
					camTpPoint2.Points.Add(tpPnt9D);
				}
				isReverse = !isReverse;
			}
			camTpPoint2.ToolCam = new ToolBase5(activeToolSaw);
			LinearPath item = new LinearPath(copiedPoint);
			CamSawRough.Tool = new ToolBase5(activeToolSaw);
			CamSawRough.EntitiesG1.Add(item);
			CamSawRough.CamPoints.Add(camTpPoint2);
			num++;
		}
	}

	public void ProfileSettingToCamSetting(marbleProfileCutPars settingProfile, bool isFinish, ref camParameters5 settingCam)
	{
		if (!isFinish)
		{
			settingCam.Distances.Safe = settingProfile.RoughSafeDis;
			settingCam.Distances.Rapid = settingProfile.RoughRapid;
			settingCam.Speeds.Plunge = settingProfile.RoughPlungeFeed;
			settingCam.Speeds.Feed = settingProfile.RoughCutForwardFeed;
		}
		else
		{
			settingCam.Distances.Safe = settingProfile.FinishSafeDis;
			settingCam.Distances.Rapid = settingProfile.FinishRapid;
			settingCam.Speeds.Plunge = settingProfile.FinishPlungeFeed;
			settingCam.Speeds.Feed = settingProfile.FinishCutForwardFeed;
		}
	}

	public void ProfileCurveSettingToCamSetting(marbleProfileCurveCutPars settingProfileCurve, bool isFinish, ref camParameters5 settingCam)
	{
		if (!isFinish)
		{
			settingCam.Distances.Safe = settingProfileCurve.RoughSafeDis;
			settingCam.Distances.Rapid = settingProfileCurve.RoughRapid;
			settingCam.Speeds.Plunge = settingProfileCurve.RoughPlungeFeed;
			settingCam.Speeds.Feed = settingProfileCurve.RoughCutForwardFeed;
		}
		else
		{
			settingCam.Distances.Safe = settingProfileCurve.FinishSafeDis;
			settingCam.Distances.Rapid = settingProfileCurve.FinishRapid;
			settingCam.Speeds.Plunge = settingProfileCurve.FinishPlungeFeed;
			settingCam.Speeds.Feed = settingProfileCurve.FinishCutForwardFeed;
		}
	}

	public void PocketByDrilling(ref MarbleItem Item, ref MarbleItemCam marbleCam, List<List<Point3D>> PLL3D, double CutDepth, KinematicBase5 activeKinematic)
	{
		List<List<Pnt6D>> list = new List<List<Pnt6D>>();
		List<List<Point3D>> list2 = new List<List<Point3D>>();
		List<List<Pnt6D>> list3 = new List<List<Pnt6D>>();
		for (int i = 0; i <= PLL3D.Count - 1; i++)
		{
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(PLL3D[i], ref copiedPoint);
			double num = buCall.buVector5_0.Length3D(copiedPoint);
			double num2 = DistanceCalcFromToolDiameterAndThickness(marbleCam.ToolSelected.Geometry.Diameter, CutDepth, 0.0, 0.0, 0.0);
			if (num > num2 + 10.0)
			{
				Point3D centerPnt = buCall.buVector5_0.MiddlePointOfLine(copiedPoint[0], copiedPoint[copiedPoint.Count - 1]);
				double num3 = buCall.buVector5_0.PointAngle(copiedPoint[copiedPoint.Count - 1], copiedPoint[0]);
				Point3D EndPnt = new Point3D();
				Point3D EndPnt2 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3 + 180.0, ref EndPnt);
				buCall.buVector5_0.LineWithLengthAndAngle(centerPnt, num / 2.0 - num2, num3, ref EndPnt2);
				copiedPoint[0] = EndPnt;
				copiedPoint[copiedPoint.Count - 1] = EndPnt2;
				if (i % 2 == 0)
				{
					copiedPoint.Reverse();
				}
				List<Pnt6D> list4 = new List<Pnt6D>();
				new buLinearPath(copiedPoint);
				List<Point3D> list5 = new List<Point3D>();
				double c = 0.0;
				for (int j = 0; j <= copiedPoint.Count - 1; j++)
				{
					Pnt6D item = new Pnt6D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z, 0.0, 0.0, c);
					list4.Add(item);
					list5.Add(new Point3D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z));
				}
				List<Pnt6D> calcPoints = new List<Pnt6D>();
				CalculatePointsWithKinematic(list4, activeKinematic, marbleCam.ToolSelected, ref calcPoints);
				list.Add(list4);
				list3.Add(calcPoints);
				list2.Add(list5);
			}
		}
		marbleCam.CamBase.Tool = new ToolBase5(marbleCam.ToolSelected);
		for (int k = 0; k <= list3.Count - 1; k++)
		{
			camTpPoint camTpPoint2 = new camTpPoint();
			camTpPoint2.ToolCam = new ToolBase5(marbleCam.ToolSelected);
			double num4 = Item.Settings.settingSawMilling.SawMillingFinishVerForwardCuttingFeed;
			if (k == 0)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint, ref MidPoint, ref MaxPoint);
				Pnt6D p = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][0].A, 0.0, list3[k][0].C);
				Pnt6D p2 = new Pnt6D(list3[k][0].X, MinPoint.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][0].Z, list3[k][0].A, 0.0, list3[k][0].C);
				TpPnt9D item2 = new TpPnt9D(p, num4, 0);
				camTpPoint2.Points.Add(item2);
				item2 = new TpPnt9D(p2, num4, 0);
				camTpPoint2.Points.Add(item2);
			}
			if (k % 2 == 0)
			{
				num4 = Item.Settings.settingSawMilling.SawMillingFinishVerBackwardCuttingFeed;
			}
			for (int l = 0; l <= list3[k].Count - 1; l++)
			{
				double feed = num4;
				if (k == 0 && l == 0)
				{
					feed = Item.Settings.settingSawMilling.SawMillingFinishVerPlungeFeed;
				}
				TpPnt9D item3 = new TpPnt9D(list3[k][l], feed, 1);
				camTpPoint2.Points.Add(item3);
			}
			if (k == list3.Count - 1)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				Point3D MidPoint2 = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(list3[k], ref MinPoint2, ref MidPoint2, ref MaxPoint2);
				Pnt6D p3 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				Pnt6D p4 = new Pnt6D(list3[k][list3[k].Count - 1].X, MinPoint2.Y - Item.Settings.settingSawMilling.SawMillingFinishVerApproach, list3[k][list3[k].Count - 1].Z + Item.Settings.settingSawMilling.SawMillingFinishVerSafeDistance, list3[k][list3[k].Count - 1].A, 0.0, list3[k][list3[k].Count - 1].C);
				TpPnt9D item4 = new TpPnt9D(p4, num4, 0);
				camTpPoint2.Points.Add(item4);
				item4 = new TpPnt9D(p3, num4, 0);
				camTpPoint2.Points.Add(item4);
			}
			marbleCam.CamBase.CamPoints.Add(camTpPoint2);
			LinearPath item5 = new LinearPath(list2[k]);
			marbleCam.CamBase.EntitiesG1.Add(item5);
		}
	}

	public void FindCornerPathFromContour(Entity entBox, double zDepth, double Offset, Entity BaseEntity, MarbleCorners Corner, ref List<List<Point3D>> PLLOffset)
	{
		if (entBox.BoxMax == null)
		{
			entBox.Regen(0.1);
		}
		Point3D point3D = buCall.buVector5_0.MiddlePointOfLine(entBox.BoxMin, entBox.BoxMax);
		ICurve[] array = ((LinearPath)BaseEntity).QuickOffset(Offset, Plane.XY, cornerType.Round);
		List<Point3D> copiedPoint = new List<Point3D>();
		PLLOffset = new List<List<Point3D>>();
		if (array.Length != 0)
		{
			Line line = null;
			Line line2 = null;
			if (Corner == MarbleCorners.RightBottom)
			{
				line = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(entBox.BoxMax.X + 1000.0, point3D.Y, zDepth));
				line2 = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(point3D.X, entBox.BoxMin.Y - 1000.0, zDepth));
			}
			if (Corner == MarbleCorners.RightTop)
			{
				line = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(entBox.BoxMax.X + 1000.0, point3D.Y, zDepth));
				line2 = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(point3D.X, entBox.BoxMax.Y + 1000.0, zDepth));
			}
			if (Corner == MarbleCorners.LeftTop)
			{
				line = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(entBox.BoxMin.X - 1000.0, point3D.Y, zDepth));
				line2 = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(point3D.X, entBox.BoxMax.Y + 1000.0, zDepth));
			}
			if (Corner == MarbleCorners.LeftBottom)
			{
				line = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(entBox.BoxMin.X - 1000.0, point3D.Y, zDepth));
				line2 = new Line(new Point3D(point3D.X, point3D.Y, zDepth), new Point3D(point3D.X, entBox.BoxMin.Y - 1000.0, zDepth));
			}
			((Entity)array[0]).Translate(0.0, 0.0, zDepth);
			((Entity)array[0]).Regen(0.1);
			Point3D[] array2 = ((ICurve)line).IntersectWith(array[0], 0.0, true);
			Point3D[] array3 = ((ICurve)line2).IntersectWith(array[0], 0.0, true);
			if ((array2.Length != 0) & (array3.Length != 0))
			{
				List<Point3D> list = new List<Point3D>();
				list.Add(array2[0]);
				list.Add(array3[0]);
				ICurve[] segments = null;
				array[0].SplitBy(list, out segments);
				new List<Entity>();
				new List<Entity>();
				Entity entity = null;
				for (int i = 0; i <= segments.Length - 1; i++)
				{
					if (list.Count != 2)
					{
						continue;
					}
					if (!(buCompare5.EQ(segments[i].StartPoint, list[0]) & buCompare5.EQ(segments[i].EndPoint, list[1])))
					{
						if (buCompare5.EQ(segments[i].StartPoint, list[1]) & buCompare5.EQ(segments[i].EndPoint, list[0]))
						{
							entity = (Entity)segments[i];
						}
					}
					else
					{
						entity = (Entity)segments[i];
					}
				}
				copiedPoint.Clear();
				if (entity != null)
				{
					buVector5.Copy(entity.Vertices, ref copiedPoint);
				}
			}
		}
		if (copiedPoint.Count <= 0)
		{
			return;
		}
		PLLOffset.Add(copiedPoint);
		for (int j = 1; j <= 10; j++)
		{
			List<Point3D> copiedPoint2 = new List<Point3D>();
			buVector5.Copy(copiedPoint, ref copiedPoint2);
			if (copiedPoint2.Count <= 0)
			{
				continue;
			}
			LinearPath linearPath = new LinearPath(copiedPoint2);
			ICurve[] array4 = linearPath.QuickOffset(Offset, Plane.XY);
			if (array4.Length != 0)
			{
				new List<Point3D>();
				((Entity)array4[0]).Regen(0.1);
				copiedPoint = new List<Point3D>();
				FindTrimedContour((Entity)array4[0], entBox, ref copiedPoint);
				if (copiedPoint.Count > 0)
				{
					PLLOffset.Add(copiedPoint);
				}
			}
		}
	}

	public void FindTrimedContour(Entity entOffset, Entity refEntities, ref List<Point3D> TrimedPoints)
	{
		Point3D[] array = ((ICurve)refEntities).IntersectWith((ICurve)entOffset);
		if (array.Length == 0)
		{
			bool flag = true;
			for (int i = 0; i <= entOffset.Vertices.Length - 1; i++)
			{
				flag &= buCall.buVector5_0.IsPointInsideBoxsize(entOffset.Vertices[i], refEntities.BoxMin, refEntities.BoxMax, Plane.XY);
			}
			if (flag)
			{
				buVector5.Copy(entOffset.Vertices, ref TrimedPoints);
			}
			return;
		}
		List<Point3D> list = new List<Point3D>();
		for (int j = 0; j <= array.Length - 1; j++)
		{
			list.Add(array[j]);
		}
		ICurve[] segments = null;
		((ICurve)entOffset).SplitBy(list, out segments);
		Entity entity = null;
		for (int k = 0; k <= segments.Length - 1; k++)
		{
			if (list.Count != 2)
			{
				continue;
			}
			if (!(buCompare5.EQ(segments[k].StartPoint, list[0]) & buCompare5.EQ(segments[k].EndPoint, list[1])))
			{
				if (buCompare5.EQ(segments[k].StartPoint, list[1]) & buCompare5.EQ(segments[k].EndPoint, list[0]))
				{
					entity = (Entity)segments[k];
				}
			}
			else
			{
				entity = (Entity)segments[k];
			}
		}
		TrimedPoints.Clear();
		if (entity != null)
		{
			buVector5.Copy(entity.Vertices, ref TrimedPoints);
		}
	}

	public void CamSawCRotationFeedAnalyze(marbleCamSawFeedAnalysisPars Options, KinematicBase5 Kinematic, ref camTp refCam)
	{
		if (refCam == null)
		{
			return;
		}
		for (int i = 0; i <= refCam.CamPoints.Count - 1; i++)
		{
			for (int j = 0; j <= refCam.CamPoints[i].Points.Count - 2; j++)
			{
				if (refCam.CamPoints[i].Points[j].Type != 1)
				{
					continue;
				}
				double num = refCam.CamPoints[i].Points[j + 1].P9.C - refCam.CamPoints[i].Points[j].P9.C;
				double num2 = buCall.buVector5_0.Length2D(refCam.CamPoints[i].Points[j].P9.X, refCam.CamPoints[i].Points[j].P9.Y, refCam.CamPoints[i].Points[j + 1].P9.X, refCam.CamPoints[i].Points[j + 1].P9.Y);
				if (!(num > Options.MaxCStepDegree))
				{
					if (num2 < Options.MaxXYLength && !(num > Options.MaxCStepDegree / 2.0))
					{
					}
					continue;
				}
				double num3 = Options.MaxCStepDegree / num;
				double num4 = num2 / Options.MaxXYLength;
				if (num4 > 1.0)
				{
					num4 = 1.0;
				}
				double num5 = refCam.CamPoints[i].Points[j + 1].Feed * num3 * num4 - Options.FixRatio;
				if (num5 < Options.MinFeedValue)
				{
					num5 = Options.MinFeedValue;
				}
				refCam.CamPoints[i].Points[j + 1].Feed = num5;
			}
		}
	}

	public void MarbleEntityCamDataSet(MarbleToolType ToolType, double TargetZ, ref marbleEntityData Data)
	{
		if (Data == null)
		{
			Data = new marbleEntityData();
		}
		switch (ToolType)
		{
		default:
			Data.CuttingSpeed = varOperation.settingMarbleCam.SawForwardCuttingVelocity;
			Data.CuttingStep = varOperation.settingMarbleCam.SawForwardStepDownDistance;
			Data.PlungeSpeed = varOperation.settingMarbleCam.SawPlungeVelocity;
			Data.CuttingFirstSpeed = varOperation.settingMarbleCam.SawForwardFirstCuttingVelocity;
			Data.CuttingFirstStep = varOperation.settingMarbleCam.SawForwardCircularStepFirstDownDistance;
			Data.PlungeFirstSpeed = varOperation.settingMarbleCam.SawPlungeFirstVelocity;
			Data.TargetZ = TargetZ;
			break;
		case MarbleToolType.Milling:
			Data.CuttingSpeed = varOperation.settingMarbleCam.MillingCuttingVelocity;
			Data.CuttingStep = varOperation.settingMarbleCam.MillingStepDown;
			Data.PlungeSpeed = varOperation.settingMarbleCam.MillingPlungeVelocity;
			Data.CuttingFirstSpeed = varOperation.settingMarbleCam.MillingFirstCuttingVelocity;
			Data.CuttingFirstStep = varOperation.settingMarbleCam.MillingFirstStepDown;
			Data.PlungeFirstSpeed = varOperation.settingMarbleCam.MillingPlungeFirstVelocity;
			Data.TargetZ = TargetZ;
			break;
		case MarbleToolType.WaterJet:
			Data.TargetZ = TargetZ;
			break;
		case MarbleToolType.MillingHead:
			Data.CuttingSpeed = varOperation.settingMarbleCam.MillingHeadCuttingVelocity;
			Data.CuttingStep = varOperation.settingMarbleCam.MillingHeadStepDown;
			Data.PlungeSpeed = varOperation.settingMarbleCam.MillingHeadPlungeVelocity;
			Data.CuttingFirstSpeed = varOperation.settingMarbleCam.MillingHeadFirstCuttingVelocity;
			Data.CuttingFirstStep = varOperation.settingMarbleCam.MillingHeadFirstStepDown;
			Data.PlungeFirstSpeed = varOperation.settingMarbleCam.MillingHeadPlungeFirstVelocity;
			Data.TargetZ = TargetZ;
			break;
		}
	}

	public void MarbleCamParameterToCamParameter(marbleCamPars Data, MarbleToolType ToolType, CamWireFrameType WireType, ref camParameters5 CamPar)
	{
		if (ToolType != MarbleToolType.Milling && ToolType != MarbleToolType.MillingHead)
		{
			CamPar.Speeds.Feed = Data.SawForwardCuttingVelocity;
		}
		if (WireType == CamWireFrameType.Contour)
		{
		}
	}

	public void MarbleEntityDataToCamParameter(marbleEntityData Data, ref camParameters5 CamPar)
	{
		CamPar.Steps.EndValue = Data.TargetZ;
	}

	public void GetLastCamPointOfItem(MarbleItem Item, ref TpPnt9D LastP9)
	{
		if (Item == null)
		{
			LastP9 = null;
			return;
		}
		if (Item.CamList == null || Item.CamList.Count <= 0)
		{
			LastP9 = null;
			return;
		}
		MarbleItemCam marbleItemCam = Item.CamList[Item.CamList.Count - 1];
		if (marbleItemCam.CamBase == null)
		{
			LastP9 = null;
			return;
		}
		camTpPoint camTpPoint2 = marbleItemCam.CamBase.CamPoints[marbleItemCam.CamBase.CamPoints.Count - 1];
		if (camTpPoint2.Points.Count <= 0)
		{
			LastP9 = null;
		}
		else
		{
			LastP9 = new TpPnt9D(camTpPoint2.Points[camTpPoint2.Points.Count - 1]);
		}
	}

	public void GetSawCutStepDistances(double OperationMaxZ, double StockMaxZ, double SawCutStep, ref List<double> ZPositions)
	{
		double NewStep = 0.0;
		int StepCount = 0;
		GetSawCutStepDistances(OperationMaxZ, StockMaxZ, SawCutStep, ref NewStep, ref StepCount, ref ZPositions);
	}

	public void GetSawCutStepDistances(double OperationMaxZ, double StockMaxZ, double SawCutStep, ref double NewStep, ref int StepCount, ref List<double> ZPositions)
	{
		double num = StockMaxZ - OperationMaxZ;
		ZPositions.Clear();
		if (!(num > 0.0))
		{
			return;
		}
		StepCount = (int)buNumeric5.RoundToUpper(num / SawCutStep);
		if (StepCount <= 0)
		{
			StepCount = 1;
		}
		NewStep = Math.Round(num / (double)StepCount, 3) - 0.01;
		if (StepCount != 1)
		{
			for (int i = 0; i <= StepCount - 1; i++)
			{
				ZPositions.Insert(0, OperationMaxZ + NewStep * (double)i);
			}
		}
		else
		{
			ZPositions.Add(OperationMaxZ);
		}
	}

	public void GetCamIndexFromCamID(List<MarbleItemCam> CamList, int CamID, ref int CamIndex)
	{
		CamIndex = -1;
		int num = 0;
		while (true)
		{
			if (num <= CamList.Count - 1)
			{
				if (CamList[num].CamID == CamID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		CamIndex = num;
	}

	public string CamSequenceToString(CamSequence Seq)
	{
		string result = "";
		switch (Seq)
		{
		case CamSequence.ContourConcaveMillingCut:
			result = buLangTranslate.preDef.Concave + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourConvexMillingCut:
			result = buLangTranslate.preDef.Convex + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourInsideMillingCut:
			result = buLangTranslate.preDef.Inside + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourInsideSawCut:
			result = buLangTranslate.preDef.Inside + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourOutsideMillingCut:
			result = buLangTranslate.preDef.Outside + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourOutsideSawCut:
			result = buLangTranslate.preDef.Outside + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.VerticalSawCut:
			result = buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.HorizontalSawCut:
			result = buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.SingleHorizontalCut:
			result = buLangTranslate.preDef.Single + " " + buLangTranslate.preDef.Horizontal + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.SingleVerticalCut:
			result = buLangTranslate.preDef.Single + " " + buLangTranslate.preDef.Vertical + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.VacuumCut:
			result = buLangTranslate.preDef.Vacuum + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.StripStartCut:
			result = buLangTranslate.preDef.Strip + " " + buLangTranslate.preDef.Beginning + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.StripEndCut:
			result = buLangTranslate.preDef.Strip + " " + buLangTranslate.preDef.End + " " + buLangTranslate.preDef.Saw + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.CollapseMillingCut:
			result = buLangTranslate.preDef.Collapse + " " + buLangTranslate.preDef.Milling + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourConcaveDrill:
			result = buLangTranslate.preDef.Concave + " " + buLangTranslate.preDef.Drill + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.ContourConvexDrill:
			result = buLangTranslate.preDef.Convex + " " + buLangTranslate.preDef.Drill + " " + buLangTranslate.preDef.Cut;
			break;
		case CamSequence.Drill:
			result = buLangTranslate.preDef.Drill + " " + buLangTranslate.preDef.Cut;
			break;
		}
		return result;
	}

	public ToolBase5 FindToolFromType(MarbleToolType ToolType)
	{
		ToolBase5 result = null;
		switch (ToolType)
		{
		case MarbleToolType.Saw:
			result = new ToolBase5(activeToolSaw);
			break;
		case MarbleToolType.Milling:
			result = new ToolBase5(activeToolMilling);
			break;
		case MarbleToolType.WaterJet:
			result = new ToolBase5(activeToolWaterjet);
			break;
		case MarbleToolType.MillingHead:
			result = new ToolBase5(activeToolMillingHead);
			break;
		}
		return result;
	}

	public double DistanceCalcFromToolDiameterAndThickness(double Diameter, double Thickness, double TargetZ, double SafeDistance, double AngleA)
	{
		double num = Thickness - TargetZ;
		if (AngleA != 0.0)
		{
			num /= Math.Sin(buConversion5.DegreeToRadian(90.0 - AngleA));
		}
		double num2 = Math.Sqrt(Math.Pow(Diameter / 2.0, 2.0) - Math.Pow(Diameter / 2.0 - num, 2.0)) / 1.0;
		return num2 + SafeDistance;
	}

	public void defaultToolSaw(ref ToolBase5 ToolSaw)
	{
		ToolSaw.Purpose = ToolPurpose.Saw;
		ToolSaw.Geometry.GeometryType = ToolType.Saw;
		ToolSaw.Geometry.Diameter = 400.0;
		ToolSaw.Geometry.Thickness = 4.0;
	}

	public void defaultToolMilling(ref ToolBase5 ToolMilling)
	{
		ToolMilling.Purpose = ToolPurpose.Milling;
		ToolMilling.Geometry.GeometryType = ToolType.Flat;
		ToolMilling.Geometry.Diameter = 10.0;
		ToolMilling.Geometry.Length = 60.0;
	}

	public void defaultToolWaterJet(ref ToolBase5 ToolWaterjet)
	{
		ToolWaterjet.Purpose = ToolPurpose.WaterJet;
		ToolWaterjet.Geometry.GeometryType = ToolType.WateJet;
		ToolWaterjet.Geometry.Diameter = 5.0;
		ToolWaterjet.Geometry.Length = 100.0;
	}

	public void defaultToolMillingHead(ref ToolBase5 ToolMilling)
	{
		ToolMilling.Purpose = ToolPurpose.MillingHead;
		ToolMilling.Geometry.GeometryType = ToolType.Flat;
		ToolMilling.Geometry.Diameter = 25.0;
		ToolMilling.Geometry.Length = 80.0;
	}

	public void GetToolThickness(MarbleToolType ToolType, ref double ToolThickness)
	{
		ToolBase5 toolBase = FindToolFromType(ToolType);
		if (!((toolBase.Purpose == ToolPurpose.Milling) | (toolBase.Purpose == ToolPurpose.MillingHead) | (toolBase.Purpose == ToolPurpose.WaterJet)))
		{
			ToolThickness = toolBase.Geometry.Thickness;
		}
		else
		{
			ToolThickness = toolBase.Geometry.Diameter;
		}
	}

	public void CreateShape(MarbleShapeTypes Type, double Thickness, ref Entity solidEntity, ref ICurve wireEntity)
	{
		switch (Type)
		{
		case MarbleShapeTypes.Rectangle:
		{
			wireEntity = CompositeCurve.CreateRectangle(varMarbleRunSettings.ShapeRectangleWidth, varMarbleRunSettings.ShapeRectangleHeight);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			devDept.Eyeshot.Entities.Region region8 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region8.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.CrossRectangle:
		{
			wireEntity = CompositeCurve.CreateRectangle(varMarbleRunSettings.ShapeRectangleCrossWidth, varMarbleRunSettings.ShapeRectangleCrossHeight);
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Rotate(Utility.DegToRad(45.0), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region12 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region12.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.RoundRectangle:
			if (!(varMarbleRunSettings.ShapeRectangleRoundRadius > 0.0))
			{
				wireEntity = CompositeCurve.CreateRectangle(varMarbleRunSettings.ShapeRectangleRoundWidth, varMarbleRunSettings.ShapeRectangleRoundHeight);
				((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
				devDept.Eyeshot.Entities.Region region14 = new devDept.Eyeshot.Entities.Region(wireEntity);
				solidEntity = region14.ExtrudeAsBrep(Thickness);
			}
			else
			{
				wireEntity = CompositeCurve.CreateRoundedRectangle(varMarbleRunSettings.ShapeRectangleRoundWidth, varMarbleRunSettings.ShapeRectangleRoundHeight, varMarbleRunSettings.ShapeRectangleRoundRadius);
				((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
				devDept.Eyeshot.Entities.Region region15 = new devDept.Eyeshot.Entities.Region(wireEntity);
				solidEntity = region15.ExtrudeAsBrep(Thickness);
			}
			break;
		case MarbleShapeTypes.ChamferRectangle:
		{
			if (!(varMarbleRunSettings.ShapeRectangleChamferLength > 0.0))
			{
				wireEntity = CompositeCurve.CreateRectangle(varMarbleRunSettings.ShapeRectangleChamferWidth, varMarbleRunSettings.ShapeRectangleChamferHeight);
				((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
				devDept.Eyeshot.Entities.Region region10 = new devDept.Eyeshot.Entities.Region(wireEntity);
				solidEntity = region10.ExtrudeAsBrep(Thickness);
				break;
			}
			List<Point3D> Points2 = new List<Point3D>();
			buCall.buVector5_0.RectangleChamfer(new Point3D(), varMarbleRunSettings.ShapeRectangleChamferWidth, varMarbleRunSettings.ShapeRectangleChamferHeight, varMarbleRunSettings.ShapeRectangleChamferLength, Plane.XY, ref Points2);
			List<ICurve> list6 = new List<ICurve>();
			for (int k = 1; k <= Points2.Count - 1; k++)
			{
				list6.Add(new Line(Points2[k - 1], Points2[k]));
			}
			wireEntity = new CompositeCurve(list6);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			devDept.Eyeshot.Entities.Region region11 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region11.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Circle:
		{
			wireEntity = new Circle(Plane.XY, varMarbleRunSettings.ShapeCircleDiameter / 2.0);
			((Entity)wireEntity).Translate(varMarbleRunSettings.ShapeCircleDiameter / 2.0, varMarbleRunSettings.ShapeCircleDiameter / 2.0);
			devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region2.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Ellipse:
		{
			wireEntity = new Ellipse(Plane.XY, varMarbleRunSettings.ShapeEllipseWidth / 2.0, varMarbleRunSettings.ShapeEllipseHeight / 2.0);
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region7 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region7.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.ArcPie:
		{
			Arc arc9 = new Arc(Plane.XY, new Point3D(), varMarbleRunSettings.ShapeArcPieRadius, buConversion5.DegreeToRadian(0.0), buConversion5.DegreeToRadian(varMarbleRunSettings.ShapeArcPieSweepAngle));
			Line item7 = new Line(buVector5.ToPoint3D(arc9.Center), buVector5.ToPoint3D(arc9.StartPoint));
			Line item8 = new Line(buVector5.ToPoint3D(arc9.EndPoint), buVector5.ToPoint3D(arc9.Center));
			List<ICurve> list8 = new List<ICurve>();
			list8.Add(item7);
			list8.Add(arc9);
			list8.Add(item8);
			wireEntity = new CompositeCurve(list8);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region16 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region16.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.EllipsePie:
		{
			EllipticalArc ellipticalArc = new EllipticalArc(Plane.XY, new Point3D(), varMarbleRunSettings.ShapeEllipsePieWidth, varMarbleRunSettings.ShapeEllipsePieHeight, buConversion5.DegreeToRadian(0.0), buConversion5.DegreeToRadian(varMarbleRunSettings.ShapeEllipsePieSweepAngle));
			Line item3 = new Line(buVector5.ToPoint3D(ellipticalArc.Center), buVector5.ToPoint3D(ellipticalArc.StartPoint));
			Line item4 = new Line(buVector5.ToPoint3D(ellipticalArc.EndPoint), buVector5.ToPoint3D(ellipticalArc.Center));
			List<ICurve> list2 = new List<ICurve>();
			list2.Add(item3);
			list2.Add(ellipticalArc);
			list2.Add(item4);
			wireEntity = new CompositeCurve(list2);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region3.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.ShipNose:
		{
			double num3 = varMarbleRunSettings.ShapeShipNoseWidth - varMarbleRunSettings.ShapeShipNoseArcXDistance * 2.0;
			double num4 = varMarbleRunSettings.ShapeShipNoseHeight - varMarbleRunSettings.ShapeShipNoseArcYDistance * 2.0;
			Point3D first2 = new Point3D();
			Point3D second2 = new Point3D(num3 / 2.0, 0.0 - varMarbleRunSettings.ShapeShipNoseArcYDistance, 0.0);
			Point3D third2 = new Point3D(num3, 0.0, 0.0);
			Arc arc5 = new Arc(Plane.XY, first2, second2, third2, flip: false);
			first2 = new Point3D(num3, 0.0, 0.0);
			second2 = new Point3D(num3 + varMarbleRunSettings.ShapeShipNoseArcXDistance, num4 / 2.0, 0.0);
			third2 = new Point3D(num3, num4, 0.0);
			Arc arc6 = new Arc(Plane.XY, first2, second2, third2, flip: false);
			first2 = new Point3D(num3, num4, 0.0);
			second2 = new Point3D(num3 / 2.0, num4 + varMarbleRunSettings.ShapeShipNoseArcYDistance, 0.0);
			third2 = new Point3D(0.0, num4, 0.0);
			Arc arc7 = new Arc(Plane.XY, first2, second2, third2, flip: false);
			first2 = new Point3D(0.0, num4, 0.0);
			second2 = new Point3D(0.0 - varMarbleRunSettings.ShapeShipNoseArcXDistance, num4 / 2.0, 0.0);
			third2 = new Point3D(0.0, 0.0, 0.0);
			Arc arc8 = new Arc(Plane.XY, first2, second2, third2, flip: false);
			List<ICurve> list7 = new List<ICurve>();
			if (!(varMarbleRunSettings.ShapeShipNoseRadius <= 0.0))
			{
				Arc fillet = null;
				Arc fillet2 = null;
				Arc fillet3 = null;
				Arc fillet4 = null;
				if (Curve.Fillet(arc5, arc6, varMarbleRunSettings.ShapeShipNoseRadius, flip1: false, flip2: false, trim1: true, trim2: true, out fillet))
				{
					fillet.Regen(0.05);
					fillet = new Arc(fillet.StartPoint, fillet.MidPoint, fillet.EndPoint, flip: false);
				}
				if (Curve.Fillet(arc6, arc7, varMarbleRunSettings.ShapeShipNoseRadius, flip1: false, flip2: false, trim1: true, trim2: true, out fillet2))
				{
					fillet2.Regen(0.05);
					fillet2 = new Arc(fillet2.StartPoint, fillet2.MidPoint, fillet2.EndPoint, flip: false);
				}
				if (Curve.Fillet(arc7, arc8, varMarbleRunSettings.ShapeShipNoseRadius, flip1: false, flip2: false, trim1: true, trim2: true, out fillet3))
				{
					fillet3.Regen(0.05);
					fillet3 = new Arc(fillet3.StartPoint, fillet3.MidPoint, fillet3.EndPoint, flip: false);
				}
				if (Curve.Fillet(arc8, arc5, varMarbleRunSettings.ShapeShipNoseRadius, flip1: false, flip2: false, trim1: true, trim2: true, out fillet4))
				{
					fillet4.Regen(0.05);
					fillet4 = new Arc(fillet4.StartPoint, fillet4.MidPoint, fillet4.EndPoint, flip: false);
				}
				list7.Add(arc5);
				list7.Add(fillet);
				list7.Add(arc6);
				list7.Add(fillet2);
				list7.Add(arc7);
				list7.Add(fillet3);
				list7.Add(arc8);
				list7.Add(fillet4);
			}
			else
			{
				list7.Add(arc5);
				list7.Add(arc6);
				list7.Add(arc7);
				list7.Add(arc8);
			}
			wireEntity = new CompositeCurve(list7);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region13 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region13.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Triangle:
		{
			List<Point3D> Points = new List<Point3D>();
			Triangle3D triangles = new Triangle3D(new Pnt3D(), new Pnt3D(varMarbleRunSettings.ShapeTriangleWidth, 0.0, 0.0), new Pnt3D(0.0, varMarbleRunSettings.ShapeTriangleHeight, 0.0));
			buCall.buVector5_0.Triangle3DoPoints(triangles, ref Points);
			List<ICurve> list5 = new List<ICurve>();
			for (int j = 1; j <= Points.Count - 1; j++)
			{
				list5.Add(new Line(Points[j - 1], Points[j]));
			}
			wireEntity = new CompositeCurve(list5);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region9 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region9.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Trepezoid:
		{
			List<Point3D> Vertice2D = new List<Point3D>();
			buCall.buVector5_0.TrapezoidPerpendicular(new Point3D(), varMarbleRunSettings.ShapeTrapezLength2, varMarbleRunSettings.ShapeTrapezLength1, varMarbleRunSettings.ShapeTrapezHeight, varMarbleRunSettings.ShapeRotation, Thickness, CreateAsCompositeCurve: true, ref Vertice2D, ref wireEntity, ref solidEntity);
			break;
		}
		case MarbleShapeTypes.Polygon:
		{
			List<Point3D> Vertices = new List<Point3D>();
			buCall.buVector5_0.PolygonCenter(new Point3D(), varMarbleRunSettings.ShapePolygonRadius / 2.0, varMarbleRunSettings.ShapePolygonSide, Plane.XY, ref Vertices);
			Vertices.Reverse();
			List<ICurve> list4 = new List<ICurve>();
			for (int i = 1; i <= Vertices.Count - 1; i++)
			{
				list4.Add(new Line(Vertices[i - 1], Vertices[i]));
			}
			wireEntity = new CompositeCurve(list4);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region6 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region6.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Slot:
		{
			wireEntity = CompositeCurve.CreateSlot(0.0, 0.0, varMarbleRunSettings.ShapeSlotWidth - varMarbleRunSettings.ShapeSlotHeight, varMarbleRunSettings.ShapeSlotHeight / 2.0, varMarbleRunSettings.ShapeRotation, centered: true);
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region5 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region5.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.ArcSweep:
		{
			Arc arc3 = new Arc(Plane.XY, new Point3D(), varMarbleRunSettings.ShapeArcBigRadius, buConversion5.DegreeToRadian(varMarbleRunSettings.ShapeArcSweepAngle));
			Arc arc4 = new Arc(Plane.XY, new Point3D(), varMarbleRunSettings.ShapeArcSmallRadius, buConversion5.DegreeToRadian(varMarbleRunSettings.ShapeArcSweepAngle));
			Line item5 = new Line(arc3.EndPoint, arc4.EndPoint);
			Line item6 = new Line(arc4.StartPoint, arc3.StartPoint);
			List<ICurve> list3 = new List<ICurve>();
			list3.Add(arc3);
			list3.Add(item5);
			list3.Add(arc4);
			list3.Add(item6);
			CompositeCurve compositeCurve = new CompositeCurve(list3);
			compositeCurve.Rotate(buConversion5.DegreeToRadian(varMarbleRunSettings.ShapeRotation), Vector3D.AxisZ);
			wireEntity = compositeCurve;
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region4 = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region4.ExtrudeAsBrep(Thickness);
			break;
		}
		case MarbleShapeTypes.Arc:
		{
			double shapeArcOutsideLength = varMarbleRunSettings.ShapeArcOutsideLength;
			double shapeArcHeight = varMarbleRunSettings.ShapeArcHeight;
			Point3D first = new Point3D(shapeArcOutsideLength, 0.0, 0.0);
			Point3D second = new Point3D(shapeArcOutsideLength / 2.0, shapeArcHeight, 0.0);
			Point3D third = new Point3D();
			Arc arc = new Arc(Plane.XY, first, second, third, flip: false);
			double num = 0.0;
			double num2 = 0.0;
			num = buCall.buVector5_0.PointAngle(arc.StartPoint, arc.Center);
			num2 = buCall.buVector5_0.PointAngle(arc.EndPoint, arc.Center);
			if (num > num2)
			{
				num -= 360.0;
			}
			Arc arc2 = new Arc(Plane.XY, buVector5.ToPoint3D(arc.Center), arc.Radius - varMarbleRunSettings.ShapeArcThickness, buConversion5.DegreeToRadian(num), buConversion5.DegreeToRadian(num2));
			Line item = new Line(buVector5.ToPoint3D(arc.EndPoint), buVector5.ToPoint3D(arc2.EndPoint));
			Line item2 = new Line(buVector5.ToPoint3D(arc2.StartPoint), buVector5.ToPoint3D(arc.StartPoint));
			List<ICurve> list = new List<ICurve>();
			list.Add(arc);
			list.Add(item);
			list.Add(arc2);
			list.Add(item2);
			wireEntity = new CompositeCurve(list);
			((Entity)wireEntity).Rotate(Utility.DegToRad(varMarbleRunSettings.ShapeRotation), new Vector3D(0.0, 0.0, 1.0));
			((Entity)wireEntity).Regen(0.1);
			((Entity)wireEntity).Translate(0.0 - ((Entity)wireEntity).BoxMin.X, 0.0 - ((Entity)wireEntity).BoxMin.Y);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(wireEntity);
			solidEntity = region.ExtrudeAsBrep(Thickness);
			break;
		}
		}
	}

	public void ItemOsnapCalculation(ref MarbleItem Item, MarbleOsnapCalcType OsnapType, double OffsetVal)
	{
		if (Item == null || Item.EntGroup == null)
		{
			return;
		}
		double num = OffsetVal;
		if (OsnapType == MarbleOsnapCalcType.OffsetFromToolGeometry)
		{
			num = -1.0;
		}
		if (num < 0.0)
		{
			double num2 = -999999.0;
			for (int i = 0; i <= Item.CamList.Count - 1; i++)
			{
				if (Item.CamList[i].ToolSelected == null)
				{
					continue;
				}
				if (Item.CamList[i].ToolSelected.Purpose != ToolPurpose.Saw)
				{
					if (Item.CamList[i].ToolSelected.Geometry.Diameter < num2)
					{
						num2 = Item.CamList[i].ToolSelected.Geometry.Diameter;
					}
				}
				else if (Item.CamList[i].ToolSelected.Geometry.Thickness < num2)
				{
					num2 = Item.CamList[i].ToolSelected.Geometry.Thickness;
				}
			}
			if (num2 > 0.0)
			{
				num = num2;
			}
		}
		if (!(num > 0.0))
		{
			return;
		}
		CamOpenContourType camOpenContourType = CamOpenContourType.Left;
		camOpenContourType = ((Item.EntGroup.Outside.Direction == ClockDirectionType.CCW) ? CamOpenContourType.Right : CamOpenContourType.Left);
		if (Item.OsnapPoints == null)
		{
			Item.OsnapPoints = new List<OsnapPoint>();
		}
		Item.OsnapPoints.Clear();
		for (int j = 0; j <= Item.EntGroup.Outside.Entities.Count - 1; j++)
		{
			buEntity OffsetedEntity = null;
			buCall.buVector5_0.OffsetEntity(Item.EntGroup.Outside.Entities[j], OffsetVal, camOpenContourType, ref OffsetedEntity);
			if (OffsetedEntity != null)
			{
				for (int k = 0; k <= OffsetedEntity.Vertices.Count - 1; k++)
				{
					OsnapPoint item = new OsnapPoint(OffsetedEntity.Vertices[k], osnapType.Point);
					Item.OsnapPoints.Add(item);
				}
			}
			OffsetedEntity = null;
		}
	}

	public double CircularSpeedReductionCalculate(buEntity refEntity)
	{
		try
		{
			double diameter = 0.0;
			double FoundPersentage = 100.0;
			double num = 1.0;
			if (refEntity is buCircle || refEntity is buArc || refEntity is buEllipse)
			{
				if (!(refEntity is buCircle))
				{
					if (!(refEntity is buArc))
					{
						if (refEntity is buEllipse)
						{
							diameter = ((((buEllipse)refEntity).RadiusX < ((buEllipse)refEntity).RadiusY) ? (((buEllipse)refEntity).RadiusX * 2.0) : (((buEllipse)refEntity).RadiusY * 2.0));
						}
					}
					else
					{
						diameter = ((buArc)refEntity).Radius * 2.0;
					}
				}
				else
				{
					diameter = ((buCircle)refEntity).Radius * 2.0;
				}
				CircularSpeedReduction.GetPersentage(CircularSpeedReductions, diameter, ref FoundPersentage);
				if (FoundPersentage <= 0.0)
				{
					FoundPersentage = 100.0;
				}
				num = FoundPersentage / 100.0;
			}
			if (num > 1.0)
			{
				num = 1.0;
			}
			if (num < 0.01)
			{
				num = 1.0;
			}
			return num;
		}
		catch (Exception)
		{
			return 1.0;
		}
	}

	public void CommonLinesToWireEntities(List<buEntity> calcLines, ref MarbleJob Job)
	{
		if (varOperation.settingMarbleCam.VerticalBackToFront | varOperation.settingMarbleCam.HorizontalLeftToRight)
		{
			for (int i = 0; i <= calcLines.Count - 1; i++)
			{
				buLine buLine2 = calcLines[i] as buLine;
				bool flag = false;
				bool flag2 = false;
				double num = buCall.buVector5_0.PointAngle(calcLines[i].EndPoint, calcLines[i].StartPoint);
				if ((num >= 45.0 && num <= 135.0) & varOperation.settingMarbleCam.VerticalBackToFront)
				{
					flag = true;
				}
				if ((num >= 135.0 && num <= 225.0) & varOperation.settingMarbleCam.HorizontalLeftToRight)
				{
					flag2 = true;
				}
				if ((flag & varOperation.settingMarbleCam.VerticalBackToFront) && buLine2.Marble != null && buCompare5.EQ(buLine2.Marble.Angle, 0.0))
				{
					buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
				}
				if ((flag2 & varOperation.settingMarbleCam.HorizontalLeftToRight) && buLine2.Marble != null && buCompare5.EQ(buLine2.Marble.Angle, 0.0))
				{
					buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
				}
			}
		}
		if (varOperation.settingMarbleCam.CutSameDirection)
		{
			SortCuttingFirstSameDirection(ref calcLines);
		}
		for (int j = 0; j <= calcLines.Count - 1; j++)
		{
			bool flag3 = false;
			for (int k = 0; k <= Job.Items.Count - 1; k++)
			{
				MarbleItem marbleItem = Job.Items[k];
				if (marbleItem.ItemType != MarbleItemType.Contour)
				{
					continue;
				}
				for (int l = 0; l <= Job.Items[k].CamList.Count - 1; l++)
				{
					MarbleItemCam marbleItemCam = Job.Items[k].CamList[l];
					if (marbleItemCam.WireEntities == null)
					{
						continue;
					}
					for (int m = 0; m <= marbleItemCam.WireEntities.Count - 1; m++)
					{
						for (int num2 = marbleItemCam.WireEntities[m].Count - 1; num2 >= 0; num2--)
						{
							buEntity buEntity2 = marbleItemCam.WireEntities[m][num2];
							if (buEntity2 is buLine)
							{
								bool flag4 = buCall.buVector5_0.IsPointInsideLine(calcLines[j].StartPoint, calcLines[j].EndPoint, buEntity2.StartPoint, Plane.XY, 0.1);
								bool flag5 = buCall.buVector5_0.IsPointInsideLine(calcLines[j].StartPoint, calcLines[j].EndPoint, buEntity2.EndPoint, Plane.XY, 0.1);
								if (flag4 && flag5)
								{
									if (flag3)
									{
										marbleItemCam.WireEntities[m].Clear();
									}
									else
									{
										buEntity2.StartPoint = buVector5.ToPoint3D(calcLines[j].StartPoint);
										buEntity2.EndPoint = buVector5.ToPoint3D(calcLines[j].EndPoint);
										buEntity2.Update();
										flag3 = true;
									}
								}
							}
						}
					}
				}
			}
		}
	}

	public bool MergeCollinearLines(List<buEntity> lines, ref List<buEntity> Result, double collinearTol = 0.01, double gapTol = 0.1)
	{
		try
		{
			List<(Vector3D, Vector3D, double, List<buEntity>)> list = new List<(Vector3D, Vector3D, double, List<buEntity>)>();
			double num = 1E-09;
			bool result = false;
			if (Result == null)
			{
				Result = new List<buEntity>();
			}
			Result.Clear();
			foreach (buEntity line in lines)
			{
				Vector3D vector3D = new Vector3D(line.StartPoint, line.EndPoint);
				if (vector3D.Length < num)
				{
					continue;
				}
				Vector3D vector3D2 = Class186.smethod_23(this, vector3D);
				Vector3D vector3D3 = Vector3D.Cross(vector3D2, Vector3D.AxisZ);
				if (vector3D3.Length < num)
				{
					vector3D3 = Vector3D.Cross(vector3D2, Vector3D.AxisX);
				}
				vector3D3.Normalize();
				double num2 = vector3D3.X * line.StartPoint.X + vector3D3.Y * line.StartPoint.Y + vector3D3.Z * line.StartPoint.Z;
				bool flag = false;
				for (int i = 0; i < list.Count; i++)
				{
					(Vector3D, Vector3D, double, List<buEntity>) tuple = list[i];
					Vector3D vector3D4 = Vector3D.Cross(tuple.Item1, vector3D2);
					if (!(vector3D4.Length > 1E-06) && !(Math.Abs(tuple.Item3 - num2) > collinearTol))
					{
						tuple.Item4.Add(line);
						flag = true;
						break;
					}
				}
				if (flag)
				{
					result = true;
					continue;
				}
				list.Add((vector3D2, vector3D3, num2, new List<buEntity> { line }));
			}
			buLine buLine2 = null;
			foreach (var item4 in list)
			{
				Vector3D vector3D_0 = item4.Item1;
				Vector3D item = item4.Item2;
				double item2 = item4.Item3;
				List<buEntity> item3 = item4.Item4;
				List<(double, double)> list2 = (from valueTuple_0 in item3.Select(delegate(buEntity buEntity_0)
					{
						double val = Vector3D.Dot(vector3D_0, buEntity_0.StartPoint);
						double val2 = Vector3D.Dot(vector3D_0, buEntity_0.EndPoint);
						return (Math.Min(val, val2), Math.Max(val, val2));
					})
					orderby valueTuple_0.Item1
					select valueTuple_0).ToList();
				double double_ = list2[0].Item1;
				double num3 = list2[0].Item2;
				for (int num4 = 1; num4 < list2.Count; num4++)
				{
					var (num5, num6) = list2[num4];
					if (!(num5 <= num3 + gapTol))
					{
						buLine2 = Class186.smethod_189(double_, item, this, item2, vector3D_0, num3);
						if (buLine2 != null)
						{
							buLine2.Orientation = new OrientationAngle(item3[0].Orientation);
							buLine2.Marble = new MarbleInfo(item3[0].Marble);
							buLine2.Update();
							Result.Add(buLine2);
						}
						double_ = num5;
						num3 = num6;
					}
					else
					{
						num3 = Math.Max(num3, num6);
					}
				}
				buLine2 = Class186.smethod_189(double_, item, this, item2, vector3D_0, num3);
				if (buLine2 != null)
				{
					buLine2.Orientation = new OrientationAngle(item3[0].Orientation);
					buLine2.Marble = new MarbleInfo(item3[0].Marble);
					buLine2.Update();
					Result.Add(buLine2);
				}
			}
			return result;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void JobCamCalculatedReset(bool GCodeCreate, bool CamCalculated, bool CamItems, int ItemIndex, ref MarbleJob activeJob)
	{
		if (GCodeCreate)
		{
			activeJob.isGCodeCreated = false;
		}
		if (CamCalculated)
		{
			activeJob.CamCalculated = false;
		}
		activeJob.isFileSend = false;
		activeJob.isCommonPathDone = false;
		if (!CamItems)
		{
			return;
		}
		if (ItemIndex >= 0)
		{
			if ((ItemIndex >= 0) & (ItemIndex <= activeJob.Items.Count - 1))
			{
				for (int i = 0; i <= activeJob.Items[ItemIndex].CamList.Count - 1; i++)
				{
					activeJob.Items[ItemIndex].CamList[i].isCamCalculated = false;
				}
			}
			return;
		}
		for (int j = 0; j <= activeJob.Items.Count - 1; j++)
		{
			for (int k = 0; k <= activeJob.Items[j].CamList.Count - 1; k++)
			{
				activeJob.Items[j].CamList[k].isCamCalculated = false;
			}
		}
	}

	public void CamWireItemEntityToExtendEntity(ref MarbleItem Item)
	{
		if (Item.Extends.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= Item.Extends.Count - 1; i++)
		{
			for (int j = 0; j <= Item.CamList.Count - 1; j++)
			{
				MarbleItemCam marbleItemCam = Item.CamList[j];
				if (marbleItemCam.CamID == Item.Extends[i].CamID && Item.Extends[i].indexWire <= marbleItemCam.WireEntities.Count - 1 && Item.Extends[i].indexWireSub <= marbleItemCam.WireEntities[Item.Extends[i].indexWire].Count - 1)
				{
					buEntity refEntity = marbleItemCam.WireEntities[Item.Extends[i].indexWire][Item.Extends[i].indexWireSub];
					buEntity.Copy(refEntity, ref Item.Extends[i].entityExtend);
				}
			}
		}
	}

	public void AddItemCommands(ref MarbleItem Item, MarbleItemCommands Cmd)
	{
		if (Item.ItemCommands.Count != 0)
		{
			bool flag = true;
			for (int i = 0; i <= Item.ItemCommands.Count - 1; i++)
			{
				if (Item.ItemCommands[i] == Cmd)
				{
					flag = false;
				}
			}
			if (flag)
			{
				Item.ItemCommands.Add(Cmd);
			}
		}
		else
		{
			Item.ItemCommands.Add(Cmd);
		}
	}

	public void AnalyzeCamItemsCuts(MarbleItem Items, ref List<MarbleItemCam> Cams)
	{
		if (Cams.Count <= 0)
		{
			for (int i = 0; i <= Items.CamList.Count - 1; i++)
			{
				Cams.Add(new MarbleItemCam(Items.CamList[i]));
			}
		}
		else if (!((Items.ItemType == MarbleItemType.Shape) | (Items.ItemType == MarbleItemType.Contour)))
		{
			for (int j = 0; j <= Items.CamList.Count - 1; j++)
			{
				Cams.Add(new MarbleItemCam(Items.CamList[j]));
			}
		}
		else
		{
			if (Items.CamList == null || Items.CamList.Count <= 0)
			{
				return;
			}
			for (int k = 0; k <= Items.CamList.Count - 1; k++)
			{
				MarbleItemCam marbleItemCam = Items.CamList[k];
				if (marbleItemCam.WireEntities == null)
				{
					continue;
				}
				for (int num = marbleItemCam.WireEntities.Count - 1; num >= 0; num--)
				{
					bool flag = false;
					for (int num2 = marbleItemCam.WireEntities[num].Count - 1; num2 >= 0; num2--)
					{
						buEntity buEntity2 = marbleItemCam.WireEntities[num][num2];
						Point3D pntStart = null;
						Point3D pntEnd = null;
						buCall.buVector5_0.GetEntityStartEndPointByCamDirection(buEntity2, ref pntStart, ref pntEnd);
						double num3 = buCall.buVector5_0.PointAngle(pntEnd, pntStart);
						for (int l = 0; l <= Cams.Count - 1; l++)
						{
							if (Cams[l].WireEntities == null)
							{
								continue;
							}
							for (int m = 0; m <= Cams[l].WireEntities.Count - 1; m++)
							{
								for (int n = 0; n <= Cams[l].WireEntities[m].Count - 1; n++)
								{
									buEntity ModifiedBaseCamItem = Cams[l].WireEntities[m][n];
									if (!flag && buEntity2.GetType() == ModifiedBaseCamItem.GetType() && buEntity2 is buLine)
									{
										_ = Cams[l].WireEntities[m][n] is buLine;
										Point3D pntStart2 = null;
										Point3D pntEnd2 = null;
										buCall.buVector5_0.GetEntityStartEndPointByCamDirection(ModifiedBaseCamItem, ref pntStart2, ref pntEnd2);
										double num4 = buCall.buVector5_0.PointAngle(pntEnd2, pntStart2);
										double value = Math.Abs(num4 - num3);
										if ((buCompare5.EQ(value, 0.0, 0.1) | buCompare5.EQ(value, 180.0, 0.1)) && ModifyAnalyzeCamItem(ref ModifiedBaseCamItem, buEntity2, activeToolSaw.Geometry.Thickness * 2.0))
										{
											flag = true;
										}
									}
								}
							}
						}
						if (flag)
						{
							marbleItemCam.WireEntities[num].RemoveAt(num2);
						}
					}
					if (marbleItemCam.WireEntities[num].Count == 0)
					{
						marbleItemCam.WireEntities.RemoveAt(num);
					}
				}
				if (marbleItemCam.WireEntities.Count > 0)
				{
					Cams.Add(new MarbleItemCam(marbleItemCam));
				}
			}
		}
	}

	public bool ModifyAnalyzeCamItem(ref buEntity ModifiedBaseCamItem, buEntity CheckedCamItem, double CheckDistance)
	{
		bool flag = false;
		Point3D pntStart = null;
		Point3D pntEnd = null;
		Point3D pntStart2 = null;
		Point3D pntEnd2 = null;
		buCall.buVector5_0.GetEntityStartEndPointByCamDirection(ModifiedBaseCamItem, ref pntStart, ref pntEnd);
		buCall.buVector5_0.GetEntityStartEndPointByCamDirection(CheckedCamItem, ref pntStart2, ref pntEnd2);
		double num = buCall.buVector5_0.Length3D(pntStart, pntStart2);
		double num2 = buCall.buVector5_0.Length3D(pntStart, pntEnd2);
		if (!isEntitySame(ModifiedBaseCamItem, CheckedCamItem))
		{
			if (!(num < CheckDistance))
			{
				if (num2 < CheckDistance)
				{
					if (ModifiedBaseCamItem.sortDirection != entitySortDirection.Normal)
					{
						ModifiedBaseCamItem.EndPoint = buVector5.ToPoint3D(pntStart2);
					}
					else
					{
						ModifiedBaseCamItem.StartPoint = buVector5.ToPoint3D(pntStart2);
					}
					flag = true;
				}
			}
			else
			{
				if (ModifiedBaseCamItem.sortDirection != entitySortDirection.Normal)
				{
					ModifiedBaseCamItem.EndPoint = buVector5.ToPoint3D(pntEnd2);
				}
				else
				{
					ModifiedBaseCamItem.StartPoint = buVector5.ToPoint3D(pntEnd2);
				}
				flag = true;
			}
			num = buCall.buVector5_0.Length3D(pntEnd, pntStart2);
			num2 = buCall.buVector5_0.Length3D(pntEnd, pntEnd2);
			if (!(num < CheckDistance))
			{
				if (num2 < CheckDistance)
				{
					if (ModifiedBaseCamItem.sortDirection != entitySortDirection.Normal)
					{
						ModifiedBaseCamItem.StartPoint = buVector5.ToPoint3D(pntStart2);
					}
					else
					{
						ModifiedBaseCamItem.EndPoint = buVector5.ToPoint3D(pntStart2);
					}
					flag = true;
				}
			}
			else
			{
				if (ModifiedBaseCamItem.sortDirection != entitySortDirection.Normal)
				{
					ModifiedBaseCamItem.StartPoint = buVector5.ToPoint3D(pntEnd2);
				}
				else
				{
					ModifiedBaseCamItem.EndPoint = buVector5.ToPoint3D(pntEnd2);
				}
				flag = true;
			}
			if (flag)
			{
				ModifiedBaseCamItem.Update(buEntityUpdateType.Line);
			}
			return flag;
		}
		return true;
	}

	public bool isEntitySame(buEntity entFirst, buEntity entSecond)
	{
		bool result = false;
		if (entFirst.GetType() == entSecond.GetType())
		{
			if (buCompare5.EQ(entFirst.StartPoint, entSecond.StartPoint, 0.1) & buCompare5.EQ(entFirst.EndPoint, entSecond.EndPoint, 0.1))
			{
				return true;
			}
			if (buCompare5.EQ(entFirst.StartPoint, entSecond.EndPoint, 0.1) & buCompare5.EQ(entFirst.EndPoint, entSecond.StartPoint, 0.1))
			{
				return true;
			}
		}
		return result;
	}

	public void ShapeTypeAngleSet(ref MarbleItem Item)
	{
		if (Item.ShapeType == MarbleShapeTypes.Rectangle)
		{
			for (int i = 0; i <= Item.EntGroup.Outside.Entities.Count - 1; i++)
			{
				if (Item.EntGroup.Outside.Entities[i].Marble == null)
				{
					Item.EntGroup.Outside.Entities[i].Marble = new MarbleInfo();
				}
				if (i == 0)
				{
					Item.EntGroup.Outside.Entities[i].Orientation.A = varMarbleRunSettings.ShapeRectangleBottomAngle;
					Item.EntGroup.Outside.Entities[i].Marble.Angle = varMarbleRunSettings.ShapeRectangleBottomAngle;
				}
				if (i == 1)
				{
					Item.EntGroup.Outside.Entities[i].Orientation.A = varMarbleRunSettings.ShapeRectangleRightAngle;
					Item.EntGroup.Outside.Entities[i].Marble.Angle = varMarbleRunSettings.ShapeRectangleRightAngle;
				}
				if (i == 2)
				{
					Item.EntGroup.Outside.Entities[i].Orientation.A = varMarbleRunSettings.ShapeRectangleTopAngle;
					Item.EntGroup.Outside.Entities[i].Marble.Angle = varMarbleRunSettings.ShapeRectangleTopAngle;
				}
				if (i == 3)
				{
					Item.EntGroup.Outside.Entities[i].Orientation.A = varMarbleRunSettings.ShapeRectangleLeftAngle;
					Item.EntGroup.Outside.Entities[i].Marble.Angle = varMarbleRunSettings.ShapeRectangleLeftAngle;
				}
			}
		}
		if (Item.ShapeType == MarbleShapeTypes.CrossRectangle)
		{
			for (int j = 0; j <= Item.EntGroup.Outside.Entities.Count - 1; j++)
			{
				if (Item.EntGroup.Outside.Entities[j].Marble == null)
				{
					Item.EntGroup.Outside.Entities[j].Marble = new MarbleInfo();
				}
				if (j == 0)
				{
					Item.EntGroup.Outside.Entities[j].Orientation.A = varMarbleRunSettings.ShapeRectangleCrossRightAngle;
					Item.EntGroup.Outside.Entities[j].Marble.Angle = varMarbleRunSettings.ShapeRectangleCrossRightAngle;
				}
				if (j == 1)
				{
					Item.EntGroup.Outside.Entities[j].Orientation.A = varMarbleRunSettings.ShapeRectangleCrossTopAngle;
					Item.EntGroup.Outside.Entities[j].Marble.Angle = varMarbleRunSettings.ShapeRectangleCrossTopAngle;
				}
				if (j == 2)
				{
					Item.EntGroup.Outside.Entities[j].Orientation.A = varMarbleRunSettings.ShapeRectangleCrossLeftAngle;
					Item.EntGroup.Outside.Entities[j].Marble.Angle = varMarbleRunSettings.ShapeRectangleCrossLeftAngle;
				}
				if (j == 3)
				{
					Item.EntGroup.Outside.Entities[j].Orientation.A = varMarbleRunSettings.ShapeRectangleCrossBottomAngle;
					Item.EntGroup.Outside.Entities[j].Marble.Angle = varMarbleRunSettings.ShapeRectangleCrossBottomAngle;
				}
			}
		}
		if (Item.ShapeType == MarbleShapeTypes.Trepezoid)
		{
			for (int k = 0; k <= Item.EntGroup.Outside.Entities.Count - 1; k++)
			{
				if (Item.EntGroup.Outside.Entities[k].Marble == null)
				{
					Item.EntGroup.Outside.Entities[k].Marble = new MarbleInfo();
				}
				if (k == 0)
				{
					Item.EntGroup.Outside.Entities[k].Orientation.A = varMarbleRunSettings.ShapeTrapezBottomAngle;
					Item.EntGroup.Outside.Entities[k].Marble.Angle = varMarbleRunSettings.ShapeTrapezBottomAngle;
				}
				if (k == 1)
				{
					Item.EntGroup.Outside.Entities[k].Orientation.A = varMarbleRunSettings.ShapeTrapezRightAngle;
					Item.EntGroup.Outside.Entities[k].Marble.Angle = varMarbleRunSettings.ShapeTrapezRightAngle;
				}
				if (k == 2)
				{
					Item.EntGroup.Outside.Entities[k].Orientation.A = varMarbleRunSettings.ShapeTrapezTopAngle;
					Item.EntGroup.Outside.Entities[k].Marble.Angle = varMarbleRunSettings.ShapeTrapezTopAngle;
				}
				if (k == 3)
				{
					Item.EntGroup.Outside.Entities[k].Orientation.A = varMarbleRunSettings.ShapeTrapezLeftAngle;
					Item.EntGroup.Outside.Entities[k].Marble.Angle = varMarbleRunSettings.ShapeTrapezLeftAngle;
				}
			}
		}
		if (Item.ShapeType == MarbleShapeTypes.ShipNose)
		{
			for (int l = 0; l <= Item.EntGroup.Outside.Entities.Count - 1; l++)
			{
				if (Item.EntGroup.Outside.Entities[l].Marble == null)
				{
					Item.EntGroup.Outside.Entities[l].Marble = new MarbleInfo();
				}
				if (l == 0)
				{
					Item.EntGroup.Outside.Entities[l].Orientation.A = varMarbleRunSettings.ShapeShipNoseBottomAngle;
					Item.EntGroup.Outside.Entities[l].Marble.Angle = varMarbleRunSettings.ShapeShipNoseBottomAngle;
				}
				if (l == 1)
				{
					Item.EntGroup.Outside.Entities[l].Orientation.A = varMarbleRunSettings.ShapeShipNoseRightAngle;
					Item.EntGroup.Outside.Entities[l].Marble.Angle = varMarbleRunSettings.ShapeShipNoseRightAngle;
				}
				if (l == 2)
				{
					Item.EntGroup.Outside.Entities[l].Orientation.A = varMarbleRunSettings.ShapeShipNoseTopAngle;
					Item.EntGroup.Outside.Entities[l].Marble.Angle = varMarbleRunSettings.ShapeShipNoseTopAngle;
				}
				if (l == 3)
				{
					Item.EntGroup.Outside.Entities[l].Orientation.A = varMarbleRunSettings.ShapeShipNoseLeftAngle;
					Item.EntGroup.Outside.Entities[l].Marble.Angle = varMarbleRunSettings.ShapeShipNoseLeftAngle;
				}
			}
		}
		if (Item.ShapeType == MarbleShapeTypes.Triangle)
		{
			for (int m = 0; m <= Item.EntGroup.Outside.Entities.Count - 1; m++)
			{
				if (Item.EntGroup.Outside.Entities[m].Marble == null)
				{
					Item.EntGroup.Outside.Entities[m].Marble = new MarbleInfo();
				}
				if (m == 0)
				{
					Item.EntGroup.Outside.Entities[m].Orientation.A = varMarbleRunSettings.ShapeTriangleBottomAngle;
					Item.EntGroup.Outside.Entities[m].Marble.Angle = varMarbleRunSettings.ShapeTriangleBottomAngle;
				}
				if (m == 1)
				{
					Item.EntGroup.Outside.Entities[m].Orientation.A = varMarbleRunSettings.ShapeTriangleCrossAngle;
					Item.EntGroup.Outside.Entities[m].Marble.Angle = varMarbleRunSettings.ShapeTriangleCrossAngle;
				}
				if (m == 2)
				{
					Item.EntGroup.Outside.Entities[m].Orientation.A = varMarbleRunSettings.ShapeTriangleLeftAngle;
					Item.EntGroup.Outside.Entities[m].Marble.Angle = varMarbleRunSettings.ShapeTriangleLeftAngle;
				}
			}
		}
		if (!((Item.ShapeType == MarbleShapeTypes.Circle) | (Item.ShapeType == MarbleShapeTypes.Ellipse) | (Item.ShapeType == MarbleShapeTypes.Polygon) | (Item.ShapeType == MarbleShapeTypes.Slot) | (Item.ShapeType == MarbleShapeTypes.RoundRectangle) | (Item.ShapeType == MarbleShapeTypes.ChamferRectangle) | (Item.ShapeType == MarbleShapeTypes.ArcPie) | (Item.ShapeType == MarbleShapeTypes.EllipsePie)))
		{
			return;
		}
		for (int n = 0; n <= Item.EntGroup.Outside.Entities.Count - 1; n++)
		{
			if (Item.EntGroup.Outside.Entities[n].Marble == null)
			{
				Item.EntGroup.Outside.Entities[n].Marble = new MarbleInfo();
			}
			if (Item.ShapeType == MarbleShapeTypes.Circle)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeCircleAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeCircleAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.Ellipse)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeEllipseAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeEllipseAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.Polygon)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapePolygonAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapePolygonAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.Slot)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeSlotAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeSlotAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.RoundRectangle)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeRectangleRoundAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeRectangleRoundAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.ChamferRectangle)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeRectangleChamferAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeRectangleChamferAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.ArcPie)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeArcPieAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeArcPieAngle;
			}
			if (Item.ShapeType == MarbleShapeTypes.EllipsePie)
			{
				Item.EntGroup.Outside.Entities[n].Orientation.A = varMarbleRunSettings.ShapeEllipsePieAngle;
				Item.EntGroup.Outside.Entities[n].Marble.Angle = varMarbleRunSettings.ShapeEllipsePieAngle;
			}
		}
	}

	public string SetEntityCommand(string Cmd, int ItemID, int EdgeIndex, int EntityOutsideIndex, int EntityInsideIndex, int EntityInsideSubIndex, string Info, string Aux)
	{
		return Cmd + ";" + ItemID + ";" + EdgeIndex + ";" + EntityOutsideIndex + ";" + EntityInsideIndex + ";" + EntityInsideSubIndex + ";" + Info + ";" + Aux;
	}

	public bool GetEntityCommand(string refWord, ref EntityCommandArgs e)
	{
		string[] array = refWord.Split(';');
		if (array == null || array.Length < 8)
		{
			return false;
		}
		e.Command = array[0];
		e.ItemID = Convert.ToInt32(array[1]);
		e.EdgeIndex = Convert.ToInt32(array[2]);
		e.EntityOutsideIndex = Convert.ToInt32(array[3]);
		e.EntityInsideIndex = Convert.ToInt32(array[4]);
		e.EntityInsideSubIndex = Convert.ToInt32(array[5]);
		e.Info = array[6];
		e.Aux = array[7];
		return true;
	}

	public void CreatedSlatEntities(buEntity EdgeEntity, buEntitiesGroup EntGroup, ref Entity entSolid, ref List<buEntity> LongCutEntities, ref List<buEntity> ShortCutEntities)
	{
		ClockDirectionType clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(EntGroup.Outside.Entities);
		CamOpenContourType direction = CamOpenContourType.Right;
		if (clockDirectionType == ClockDirectionType.CW)
		{
			direction = CamOpenContourType.Left;
		}
		List<Point3D> calcPoints = new List<Point3D>();
		buEntity calcEntity = null;
		buCall.buVector5_0.OffsetEntityAndCreateEntityByDirection(EdgeEntity, varMarbleRunSettings.SlatOffset, varMarbleRunSettings.SlatWidth, direction, varOperation.settingMarbleCam.OutsideContourLeadIn, varOperation.settingMarbleCam.OutsideContourLeadOut, ref calcPoints, ref calcEntity, ref LongCutEntities, ref ShortCutEntities);
		LinearPath outer = new LinearPath(calcPoints);
		devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer, Plane.XY);
		entSolid = region.ExtrudeAsBrep(varOperation.MaterialParameter.MaterialThickness);
		entSolid.Color = Color.FromArgb(varMarbleColorSettings.colorItemContour.Transperancy, varMarbleColorSettings.colorItemContour.Color);
		entSolid.ColorMethod = colorMethodType.byEntity;
	}

	public void CreateInsideCutCamItem(MarbleJob Job, ref MarbleItem MI, ToolBase5 toolSaw, camParameters5 buPar)
	{
		if (MI.EntGroup.Inside == null || MI.EntGroup.Inside.Count <= 0)
		{
			return;
		}
		for (int num = MI.EntGroup.Inside.Count - 1; num >= 0; num--)
		{
			MarbleItemCam marbleItemCam = new MarbleItemCam();
			marbleItemCam.Direction = InOutCenterType.Inside;
			marbleItemCam.ItemID = MI.ID;
			marbleItemCam.CamName = buLangTranslate.preDef.Inside + " " + buLangTranslate.preDef.Cutting + " [" + buLangTranslate.preDef.Saw + "]";
			marbleItemCam.CamMarbleType = MarbleCamType.ContourSawInsideCut;
			marbleItemCam.CamMode = MarbleCamMode.Contour;
			marbleItemCam.setCam = new camParameters5(buPar);
			marbleItemCam.setCam.Steps.StartValue = MI.SizeItem.MaxPoint.Z;
			marbleItemCam.setCam.Steps.EndValue = MI.SizeItem.MaxPoint.Z - MI.SizeItem.Depth;
			if (MI.EntGroup.Inside[num].ToolType == entityToolType.Saw)
			{
				marbleItemCam.ToolType = MarbleToolType.Saw;
			}
			if (MI.EntGroup.Inside[num].ToolType == entityToolType.Milling)
			{
				marbleItemCam.ToolType = MarbleToolType.Milling;
			}
			if (MI.EntGroup.Inside[num].ToolType == entityToolType.MillingHead)
			{
				marbleItemCam.ToolType = MarbleToolType.MillingHead;
			}
			marbleItemCam.WireType = CamWireFrameType.Contour;
			marbleItemCam.MeshType = varMarbleRunSettings.selectedType.selectedMeshType;
			marbleItemCam.CamType = buCall.buCam5_0.CamWireframeTypeToCamType(CamWireFrameType.Contour);
			marbleItemCam.ToolSelected = FindToolFromType(marbleItemCam.ToolType);
			marbleItemCam.EntityList = new buEntityList(MI.EntGroup.Inside[num]);
			marbleItemCam.EntityList.InOutType = entityInOutDirectionType.Inside;
			marbleItemCam.setCam.Offsets.ClosedContour = CamClosedContourType.Inner;
			GetCamID(Job, MI.CamList, ref marbleItemCam.CamID);
			CreateEdgesFromEntities(marbleItemCam.EntityList.Entities, Job, MI, marbleItemCam, Outside: false, MI.MaterialThickness, toolSaw.Geometry.Diameter, num, ref MI.Edges);
			MI.CamList.Add(marbleItemCam);
		}
	}

	public void CreateEdgesFromEntityGroup(buEntitiesGroup EntGroup, double Thickness, double ToolDiameter, ref List<marbleEdgeItem> Edges)
	{
		if (Edges == null)
		{
			Edges = new List<marbleEdgeItem>();
		}
		Edges.Clear();
		ClockDirectionType clock = buCall.buVector5_0.EntitiesClockDirection(EntGroup.Outside.Entities);
		for (int i = 0; i <= EntGroup.Outside.Entities.Count - 1; i++)
		{
			string text = "";
			if (EntGroup.Outside.Entities[i].Info.Data != null)
			{
				text = EntGroup.Outside.Entities[i].Info.Data;
			}
			if (text.Trim().Length == 0)
			{
				text = buLangTranslate.preDef.Edge;
			}
			marbleEdgeItem marbleEdgeItem2 = new marbleEdgeItem(text, 0.0, clock, Thickness, inside: false, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
			marbleEdgeItem2.IndexEntity = i;
			buEntity.Copy(EntGroup.Outside.Entities[i], ref marbleEdgeItem2.refEntity);
			marbleEdgeItem2.refEntity.Info.EntityIndex = i;
			Edges.Add(marbleEdgeItem2);
		}
		if (EntGroup.Inside == null)
		{
			return;
		}
		for (int j = 0; j <= EntGroup.Inside.Count - 1; j++)
		{
			for (int k = 0; k <= EntGroup.Inside[j].Entities.Count - 1; k++)
			{
				string text2 = "";
				if (EntGroup.Inside[j].Entities[k].Info.Data != null)
				{
					text2 = EntGroup.Inside[j].Entities[k].Info.Data;
				}
				if (text2.Trim().Length == 0)
				{
					text2 = buLangTranslate.preDef.Edge;
				}
				double num = buCall.buVector5_0.EntityLength(EntGroup.Inside[j].Entities[k]);
				double num2 = buCall.buMarbleCalc_0.DistanceCalcFromToolDiameterAndThickness(ToolDiameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, 0.0);
				double num3 = num2 + varOperation.settingMarbleCam.InnerCutSafeDistance;
				if (ToolDiameter == 0.0)
				{
					num3 = 0.0;
				}
				if (num > num3)
				{
					marbleEdgeItem marbleEdgeItem3 = new marbleEdgeItem(text2, 0.0, clock, Thickness, inside: true, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
					marbleEdgeItem3.OutsideInside = OutsideInsideType.Inside;
					marbleEdgeItem3.IndexEntity = k;
					marbleEdgeItem3.IndexEntitySub = j;
					buEntity.Copy(EntGroup.Inside[j].Entities[k], ref marbleEdgeItem3.refEntity);
					marbleEdgeItem3.refEntity.Info.EntityIndex = k;
					marbleEdgeItem3.refEntity.Info.EntitySubIndex = j;
					Edges.Add(marbleEdgeItem3);
				}
			}
		}
	}

	public void CreateEdgesFromEntities(List<buEntity> Entities, MarbleJob Job, MarbleItem Item, MarbleItemCam CamItem, bool Outside, double Thickness, double ToolDiameter, int indexInside, ref List<marbleEdgeItem> Edges)
	{
		if (Edges == null)
		{
			Edges = new List<marbleEdgeItem>();
		}
		if (Job == null)
		{
			MarbleTempVars.EdgeIndex++;
		}
		else
		{
			GetEdgeID(Job, ref MarbleTempVars.EdgeIndex);
		}
		ClockDirectionType clock = buCall.buVector5_0.EntitiesClockDirection(Entities);
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			string text = "";
			if (Entities[i].Info.Data != null)
			{
				text = Entities[i].Info.Data;
			}
			if (text.Trim().Length == 0)
			{
				text = buLangTranslate.preDef.Edge;
			}
			marbleEdgeItem marbleEdgeItem2 = null;
			if (!Outside)
			{
				double num = buCall.buVector5_0.EntityLength(Entities[i]);
				double num2 = buCall.buMarbleCalc_0.DistanceCalcFromToolDiameterAndThickness(ToolDiameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, 0.0);
				double num3 = num2 + varOperation.settingMarbleCam.InnerCutSafeDistance;
				if (ToolDiameter == 0.0)
				{
					num3 = 0.0;
				}
				if (num > num3)
				{
					marbleEdgeItem2 = new marbleEdgeItem(text, 0.0, clock, Thickness, inside: true, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
					marbleEdgeItem2.OutsideInside = OutsideInsideType.Inside;
					marbleEdgeItem2.IndexEntitySub = -1;
				}
			}
			else
			{
				marbleEdgeItem2 = new marbleEdgeItem(text, 0.0, clock, Thickness, inside: false, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
			}
			if (marbleEdgeItem2 != null)
			{
				marbleEdgeItem2.IndexEntity = i;
				marbleEdgeItem2.IndexInside = indexInside;
				buEntity.Copy(Entities[i], ref marbleEdgeItem2.refEntity);
				marbleEdgeItem2.refEntity.Info.EntityIndex = i;
				marbleEdgeItem2.refEntity.Info.InsideIndex = indexInside;
				marbleEdgeItem2.refEntity.Info.ItemID = Item.ID;
				marbleEdgeItem2.refEntity.Info.CamID = CamItem.CamID;
				marbleEdgeItem2.refEntity.Info.EdgeID = MarbleTempVars.EdgeIndex;
				CreateEdgeEntity(marbleEdgeItem2.refEntity, new Point3D(), Outside, Item.ID, CamItem.CamID, marbleEdgeItem2.EdgeID, i, -1, indexInside, ref marbleEdgeItem2.drawEntity);
				GetEdgeID(Job, ref marbleEdgeItem2.EdgeID);
				marbleEdgeItem2.CamID = CamItem.CamID;
				marbleEdgeItem2.ItemID = Item.ID;
				Edges.Add(marbleEdgeItem2);
				MarbleTempVars.EdgeIndex++;
			}
		}
	}

	public void CreateEdgesFromEntity(buEntity Ent, int EntityIndex, ClockDirectionType CD, MarbleJob Job, MarbleItem Item, MarbleItemCam CamItem, bool Outside, double Thickness, double ToolDiameter, int indexInside, ref marbleEdgeItem EdgeItem)
	{
		string text = "";
		if (Ent.Info.Data != null)
		{
			text = Ent.Info.Data;
		}
		if (text.Trim().Length == 0)
		{
			text = buLangTranslate.preDef.Edge;
		}
		EdgeItem = null;
		if (!Outside)
		{
			double num = buCall.buVector5_0.EntityLength(Ent);
			double num2 = buCall.buMarbleCalc_0.DistanceCalcFromToolDiameterAndThickness(ToolDiameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, 0.0);
			double num3 = num2 + varOperation.settingMarbleCam.InnerCutSafeDistance;
			if (ToolDiameter == 0.0)
			{
				num3 = 0.0;
			}
			if (num > num3)
			{
				EdgeItem = new marbleEdgeItem(text, 0.0, CD, Thickness, inside: true, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
				EdgeItem.OutsideInside = OutsideInsideType.Inside;
				EdgeItem.IndexEntitySub = -1;
			}
		}
		else
		{
			EdgeItem = new marbleEdgeItem(text, 0.0, CD, Thickness, inside: false, varCountertopSettings.SocketDefaultWidth, varCountertopSettings.SocketDefaultHeight);
		}
		if (EdgeItem != null)
		{
			if (Ent.Marble != null)
			{
				EdgeItem.Angle = Ent.Marble.Angle;
			}
			EdgeItem.IndexEntity = EntityIndex;
			EdgeItem.IndexInside = indexInside;
			if (Job == null)
			{
				EdgeItem.EdgeID = MarbleTempVars.EdgeIndex;
				MarbleTempVars.EdgeIndex++;
			}
			else
			{
				GetEdgeID(Job, ref EdgeItem.EdgeID);
			}
			buEntity.Copy(Ent, ref EdgeItem.refEntity);
			EdgeItem.refEntity.Info.EntityIndex = EntityIndex;
			EdgeItem.refEntity.Info.InsideIndex = indexInside;
			EdgeItem.refEntity.Info.ItemID = Item.ID;
			EdgeItem.refEntity.Info.CamID = CamItem.CamID;
			EdgeItem.refEntity.Info.EdgeID = EdgeItem.EdgeID;
			CreateEdgeEntity(EdgeItem.refEntity, new Point3D(), Outside, Item.ID, CamItem.CamID, EdgeItem.EdgeID, EntityIndex, -1, indexInside, ref EdgeItem.drawEntity);
			EdgeItem.CamID = CamItem.CamID;
			EdgeItem.ItemID = Item.ID;
		}
	}

	public void CreateEdgeEntities(List<buEntity> refEntities, Point3D refPoint, bool Outside, int indexInside, int indexCam, ref MarbleItem Item)
	{
		if (refEntities.Count > 0)
		{
			for (int i = 0; i <= refEntities.Count - 1; i++)
			{
			}
		}
		if (refEntities.Count <= 0)
		{
			return;
		}
		if (Item.ItemEntities.EdgeEntities == null)
		{
			Item.ItemEntities.EdgeEntities = new List<buEntity>();
		}
		for (int j = 0; j <= refEntities.Count - 1; j++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(refEntities[j], ref copiedEntity);
			if (refPoint != null)
			{
				copiedEntity.Translate(refPoint.X, refPoint.Y, 0.0);
			}
			if (!(copiedEntity is buCompositeCurve))
			{
				if (!(copiedEntity is buCircle))
				{
					if (!(copiedEntity is buEllipse))
					{
						copiedEntity.Marble = new MarbleInfo();
						if (!(copiedEntity is buLinearPath))
						{
							buEntity buEntity2 = copiedEntity;
							List<Point3D> OffsetedPoints = new List<Point3D>();
							buCall.buVector5_0.OffsetOpenContour(buEntity2.Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
							LinearPath outer = new LinearPath(OffsetedPoints);
							devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
							Mesh another = region.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
							buMesh buMesh2 = new buMesh(another);
							buMesh2.Marble = new MarbleInfo();
							buMesh2.Info.EntitySubIndex = indexInside;
							buMesh2.Info.EntityIndex = j;
							buMesh2.Info.CamIndex = indexCam;
							buMesh2.Info.Tags = "Edge";
							if (!Outside)
							{
								buMesh2.Info.Data = "Inside";
							}
							else
							{
								buMesh2.Info.Data = "Outside";
							}
							Item.ItemEntities.EdgeEntities.Add(buMesh2);
							continue;
						}
						for (int k = 1; k <= copiedEntity.Vertices.Count - 1; k++)
						{
							List<Point3D> list = new List<Point3D>();
							list.Add(buVector5.ToPoint3D(copiedEntity.Vertices[k - 1]));
							list.Add(buVector5.ToPoint3D(copiedEntity.Vertices[k]));
							List<Point3D> OffsetedPoints2 = new List<Point3D>();
							buCall.buVector5_0.OffsetOpenContour(list, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints2);
							LinearPath outer2 = new LinearPath(OffsetedPoints2);
							devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(outer2);
							Mesh another2 = region2.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
							buMesh buMesh3 = new buMesh(another2);
							buMesh3.Marble = new MarbleInfo();
							buMesh3.Info.EntitySubIndex = indexInside;
							buMesh3.Info.EntityIndex = j;
							buMesh3.Info.CamIndex = indexCam;
							buMesh3.Info.Tags = "Edge";
							if (!Outside)
							{
								buMesh3.Info.Data = "Inside";
							}
							else
							{
								buMesh3.Info.Data = "Outside";
							}
							Item.ItemEntities.EdgeEntities.Add(buMesh3);
						}
					}
					else
					{
						Ellipse item = new Ellipse(buVector5.ToPoint3D(((buEllipse)copiedEntity).Center), ((buEllipse)copiedEntity).RadiusX + 3.0, ((buEllipse)copiedEntity).RadiusY + 3.0);
						Ellipse item2 = new Ellipse(buVector5.ToPoint3D(((buEllipse)copiedEntity).Center), ((buEllipse)copiedEntity).RadiusX - 3.0, ((buEllipse)copiedEntity).RadiusY - 3.0);
						List<ICurve> list2 = new List<ICurve>();
						list2.Add(item);
						list2.Add(item2);
						devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(list2);
						Mesh another3 = region3.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
						buMesh buMesh4 = new buMesh(another3);
						buMesh4.Marble = new MarbleInfo();
						buMesh4.Info.EntitySubIndex = indexInside;
						buMesh4.Info.EntityIndex = j;
						buMesh4.Info.CamIndex = indexCam;
						buMesh4.Info.Tags = "Edge";
						if (!Outside)
						{
							buMesh4.Info.Data = "Inside";
						}
						else
						{
							buMesh4.Info.Data = "Outside";
						}
						Item.ItemEntities.EdgeEntities.Add(buMesh4);
					}
				}
				else
				{
					Circle item3 = new Circle(buVector5.ToPoint3D(((buCircle)copiedEntity).Center), ((buCircle)copiedEntity).Radius + 3.0);
					Circle item4 = new Circle(buVector5.ToPoint3D(((buCircle)copiedEntity).Center), ((buCircle)copiedEntity).Radius - 3.0);
					List<ICurve> list3 = new List<ICurve>();
					list3.Add(item3);
					list3.Add(item4);
					devDept.Eyeshot.Entities.Region region4 = new devDept.Eyeshot.Entities.Region(list3);
					Mesh another4 = region4.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
					buMesh buMesh5 = new buMesh(another4);
					buMesh5.Marble = new MarbleInfo();
					buMesh5.Info.EntitySubIndex = indexInside;
					buMesh5.Info.EntityIndex = j;
					buMesh5.Info.CamIndex = indexCam;
					buMesh5.Info.Tags = "Edge";
					if (!Outside)
					{
						buMesh5.Info.Data = "Inside";
					}
					else
					{
						buMesh5.Info.Data = "Outside";
					}
					Item.ItemEntities.EdgeEntities.Add(buMesh5);
				}
				continue;
			}
			for (int l = 0; l <= ((buCompositeCurve)copiedEntity).CurveList.Count - 1; l++)
			{
				((buCompositeCurve)copiedEntity).CurveList[l].Marble = new MarbleInfo();
				buEntity buEntity3 = ((buCompositeCurve)copiedEntity).CurveList[l];
				List<Point3D> OffsetedPoints3 = new List<Point3D>();
				buCall.buVector5_0.OffsetOpenContour(buEntity3.Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints3);
				LinearPath outer3 = new LinearPath(OffsetedPoints3);
				devDept.Eyeshot.Entities.Region region5 = new devDept.Eyeshot.Entities.Region(outer3);
				Mesh another5 = region5.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
				buMesh buMesh6 = new buMesh(another5);
				buMesh6.Marble = new MarbleInfo();
				buMesh6.Info.EntitySubIndex = indexInside;
				buMesh6.Info.EntityIndex = j;
				buMesh6.Info.CamIndex = indexCam;
				buMesh6.Info.Tags = "Edge";
				if (!Outside)
				{
					buMesh6.Info.Data = "Inside";
				}
				else
				{
					buMesh6.Info.Data = "Outside";
				}
				Item.ItemEntities.EdgeEntities.Add(buMesh6);
			}
		}
	}

	public void CreateEdgeEntity(buEntity refEntity, Point3D refPoint, bool Outside, int ItemID, int CamID, int EdgeID, int indexEntity, int indexEntitySub, int indexInside, ref buEntity entEdge)
	{
		buEntity copiedEntity = null;
		buEntity.Copy(refEntity, ref copiedEntity);
		if (refPoint != null)
		{
			copiedEntity.Translate(refPoint.X, refPoint.Y, 0.0);
		}
		if (!(copiedEntity is buCompositeCurve))
		{
			if (!(copiedEntity is buCircle))
			{
				if (!(copiedEntity is buEllipse))
				{
					copiedEntity.Marble = new MarbleInfo();
					if (!(copiedEntity is buLinearPath))
					{
						buEntity buEntity2 = copiedEntity;
						List<Point3D> OffsetedPoints = new List<Point3D>();
						buCall.buVector5_0.OffsetOpenContour(buEntity2.Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
						LinearPath outer = new LinearPath(OffsetedPoints);
						devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
						Mesh another = region.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
						entEdge = new buMesh(another);
						entEdge.Marble = new MarbleInfo();
						entEdge.Info.InsideIndex = indexInside;
						entEdge.Info.EntityIndex = indexEntity;
						entEdge.Info.EntitySubIndex = indexEntitySub;
						entEdge.Info.CamID = CamID;
						entEdge.Info.EdgeID = EdgeID;
						entEdge.Info.ItemID = ItemID;
						entEdge.Info.Tags = "Edge";
						if (!Outside)
						{
							entEdge.Info.Data = "Inside";
						}
						else
						{
							entEdge.Info.Data = "Outside";
						}
						return;
					}
					for (int i = 1; i <= copiedEntity.Vertices.Count - 1; i++)
					{
						List<Point3D> list = new List<Point3D>();
						list.Add(buVector5.ToPoint3D(copiedEntity.Vertices[i - 1]));
						list.Add(buVector5.ToPoint3D(copiedEntity.Vertices[i]));
						List<Point3D> OffsetedPoints2 = new List<Point3D>();
						buCall.buVector5_0.OffsetOpenContour(list, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints2);
						LinearPath outer2 = new LinearPath(OffsetedPoints2);
						devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(outer2);
						Mesh another2 = region2.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
						entEdge = new buMesh(another2);
						entEdge.Marble = new MarbleInfo();
						entEdge.Info.InsideIndex = indexInside;
						entEdge.Info.EntityIndex = indexEntity;
						entEdge.Info.EntitySubIndex = indexEntitySub;
						entEdge.Info.CamID = CamID;
						entEdge.Info.EdgeID = EdgeID;
						entEdge.Info.ItemID = ItemID;
						entEdge.Info.Tags = "Edge";
						if (!Outside)
						{
							entEdge.Info.Data = "Inside";
						}
						else
						{
							entEdge.Info.Data = "Outside";
						}
					}
				}
				else
				{
					Ellipse item = new Ellipse(buVector5.ToPoint3D(((buEllipse)copiedEntity).Center), ((buEllipse)copiedEntity).RadiusX + 3.0, ((buEllipse)copiedEntity).RadiusY + 3.0);
					Ellipse item2 = new Ellipse(buVector5.ToPoint3D(((buEllipse)copiedEntity).Center), ((buEllipse)copiedEntity).RadiusX - 3.0, ((buEllipse)copiedEntity).RadiusY - 3.0);
					List<ICurve> list2 = new List<ICurve>();
					list2.Add(item);
					list2.Add(item2);
					devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(list2);
					Mesh another3 = region3.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
					entEdge = new buMesh(another3);
					entEdge.Marble = new MarbleInfo();
					entEdge.Info.InsideIndex = indexInside;
					entEdge.Info.EntityIndex = indexEntity;
					entEdge.Info.EntitySubIndex = indexEntitySub;
					entEdge.Info.CamID = CamID;
					entEdge.Info.EdgeID = EdgeID;
					entEdge.Info.ItemID = ItemID;
					entEdge.Info.Tags = "Edge";
					if (!Outside)
					{
						entEdge.Info.Data = "Inside";
					}
					else
					{
						entEdge.Info.Data = "Outside";
					}
				}
			}
			else
			{
				Circle item3 = new Circle(buVector5.ToPoint3D(((buCircle)copiedEntity).Center), ((buCircle)copiedEntity).Radius + 3.0);
				Circle item4 = new Circle(buVector5.ToPoint3D(((buCircle)copiedEntity).Center), ((buCircle)copiedEntity).Radius - 3.0);
				List<ICurve> list3 = new List<ICurve>();
				list3.Add(item3);
				list3.Add(item4);
				devDept.Eyeshot.Entities.Region region4 = new devDept.Eyeshot.Entities.Region(list3);
				Mesh another4 = region4.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
				entEdge = new buMesh(another4);
				entEdge.Marble = new MarbleInfo();
				entEdge.Info.InsideIndex = indexInside;
				entEdge.Info.EntityIndex = indexEntity;
				entEdge.Info.EntitySubIndex = indexEntitySub;
				entEdge.Info.CamID = CamID;
				entEdge.Info.EdgeID = EdgeID;
				entEdge.Info.ItemID = ItemID;
				entEdge.Info.Tags = "Edge";
				if (!Outside)
				{
					entEdge.Info.Data = "Inside";
				}
				else
				{
					entEdge.Info.Data = "Outside";
				}
			}
			return;
		}
		for (int j = 0; j <= ((buCompositeCurve)copiedEntity).CurveList.Count - 1; j++)
		{
			((buCompositeCurve)copiedEntity).CurveList[j].Marble = new MarbleInfo();
			buEntity buEntity3 = ((buCompositeCurve)copiedEntity).CurveList[j];
			List<Point3D> OffsetedPoints3 = new List<Point3D>();
			buCall.buVector5_0.OffsetOpenContour(buEntity3.Vertices, 3.0, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints3);
			LinearPath outer3 = new LinearPath(OffsetedPoints3);
			devDept.Eyeshot.Entities.Region region5 = new devDept.Eyeshot.Entities.Region(outer3);
			Mesh another5 = region5.ExtrudeAsMesh(1.0, 0.01, Mesh.natureType.RichSmooth);
			entEdge = new buMesh(another5);
			entEdge.Marble = new MarbleInfo();
			entEdge.Info.InsideIndex = indexInside;
			entEdge.Info.EntityIndex = indexEntity;
			entEdge.Info.EntitySubIndex = indexEntitySub;
			entEdge.Info.CamID = CamID;
			entEdge.Info.EdgeID = EdgeID;
			entEdge.Info.ItemID = ItemID;
			entEdge.Info.Tags = "Edge";
			if (!Outside)
			{
				entEdge.Info.Data = "Inside";
			}
			else
			{
				entEdge.Info.Data = "Outside";
			}
		}
	}

	public void EdgePropertiesFromWireEntities(List<List<buEntity>> WireEntities, ref List<marbleEdgeItem> Edges)
	{
		for (int i = 0; i <= Edges.Count - 1; i++)
		{
			bool flag = false;
			if (WireEntities == null)
			{
				continue;
			}
			for (int j = 0; j <= WireEntities.Count - 1; j++)
			{
				for (int k = 0; k <= WireEntities[j].Count - 1; k++)
				{
					if ((Edges[i].IndexEntity == WireEntities[j][k].Info.EntityIndex) & (Edges[i].IndexEntitySub == WireEntities[j][k].Info.EntitySubIndex))
					{
						flag = true;
						Point3D pntStart = new Point3D();
						Point3D pntEnd = new Point3D();
						buCall.buVector5_0.GetEntityStartEndPointByCamDirection(WireEntities[j][k], ref pntStart, ref pntEnd);
						Edges[i].DirectionAngle = buCall.buVector5_0.PointAngle(pntEnd, pntStart);
						Edges[i].Length = buCall.buVector5_0.Length3D(pntEnd, pntStart);
						Edges[i].Sequence = j + 1;
						Edges[i].Enable = WireEntities[j][k].Info.Enable;
						k = WireEntities[j].Count;
					}
				}
				if (flag)
				{
					j = WireEntities.Count;
				}
			}
		}
	}

	public void GetEdgeIndexFromEdgeID(List<marbleEdgeItem> EdgeList, int EdgeID, ref int EdgeIndex)
	{
		EdgeIndex = -1;
		int num = 0;
		while (true)
		{
			if (num <= EdgeList.Count - 1)
			{
				if (EdgeList[num].EdgeID == EdgeID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		EdgeIndex = num;
	}

	public string GetItemInfo(marbleCuttingItems[] cutItems, double CutLength)
	{
		string result = "";
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		int num4 = 0;
		for (int i = 0; i <= cutItems.Length - 1; i++)
		{
			num += cutItems[i].Length * (double)cutItems[i].Count;
			num2 += cutItems[i].Length / 100.0 * (CutLength / 100.0) * (double)cutItems[i].Count;
			num4 += cutItems[i].Count;
		}
		if (Math.Abs(num) > 0.0)
		{
			result = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " : " + num.ToString("f1");
			TimeSpan timeSpan = new TimeSpan((long)num3);
			string text = $"{timeSpan.Hours:D2}h:{timeSpan.Minutes:D2}m:{timeSpan.Seconds:D2}s";
			result = buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Length + " : " + num.ToString("f1") + Environment.NewLine;
			result = result + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Area + " : " + num2.ToString("f1") + Environment.NewLine;
			result = result + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Count + " : " + num4.ToString("") + Environment.NewLine;
			result = result + buLangTranslate.preDef.Total + " " + buLangTranslate.preDef.Execution + " " + buLangTranslate.preDef.Time + " : " + text;
		}
		return result;
	}

	public void GetMarbleItemByID(MarbleJob activeJob, int ID, ref MarbleItem MI)
	{
		for (int i = 0; i <= activeJob.Items.Count - 1; i++)
		{
			if (activeJob.Items[i].ID == ID)
			{
				MI = activeJob.Items[i];
			}
		}
	}

	public void GetMarbleItemByID(MarbleJob activeJob, int ID, ref MarbleItem MI, ref int IndexITem)
	{
		IndexITem = -1;
		for (int i = 0; i <= activeJob.Items.Count - 1; i++)
		{
			if (activeJob.Items[i].ID == ID)
			{
				MI = activeJob.Items[i];
				IndexITem = i;
			}
		}
	}

	public string ItemShapeToName(MarbleShapeTypes Type)
	{
		return Type switch
		{
			MarbleShapeTypes.ShipNose => buLangTranslate.preDef.ShipNose, 
			MarbleShapeTypes.KeyHole => buLangTranslate.preDef.KeyHole, 
			MarbleShapeTypes.Arc => buLangTranslate.preDef.Arc, 
			MarbleShapeTypes.Circle => buLangTranslate.preDef.Cirlce, 
			MarbleShapeTypes.Ellipse => buLangTranslate.preDef.Ellipse, 
			MarbleShapeTypes.FreeDraw => buLangTranslate.preDef.FreeDraw, 
			MarbleShapeTypes.Hole => buLangTranslate.preDef.Hole, 
			MarbleShapeTypes.Polygon => buLangTranslate.preDef.Polygon, 
			MarbleShapeTypes.Rectangle => buLangTranslate.preDef.Rectangle, 
			MarbleShapeTypes.RoundRectangle => buLangTranslate.preDef.Rectangle, 
			MarbleShapeTypes.Slot => buLangTranslate.preDef.Slot, 
			MarbleShapeTypes.Text => buLangTranslate.preDef.Text, 
			MarbleShapeTypes.Trepezoid => buLangTranslate.preDef.Trapezoid, 
			MarbleShapeTypes.Triangle => buLangTranslate.preDef.Triangle, 
			_ => "", 
		};
	}

	public void ItemSizeCalculation(ref MarbleItem Item)
	{
		if (Item.ItemEntities.SolidEntity == null || Item.ItemEntities.SolidEntity.Count <= 0)
		{
			if (Item.EntGroup == null || Item.EntGroup.Outside.Entities.Count <= 0)
			{
				if (Item.EntGroup == null || Item.EntGroup.Inside == null || Item.EntGroup.Inside.Count <= 0)
				{
					if (Item.EntGroup != null && Item.EntGroup.OpenEntities != null && Item.EntGroup.OpenEntities.Count > 0)
					{
						buCall.buVector5_0.BoxSizeCalculate(Item.EntGroup, ref Item.SizeItem.MinPoint, ref Item.SizeItem.MidPoint, ref Item.SizeItem.MaxPoint);
						ObjectSize3D.CalculateSize(ref Item.SizeItem);
					}
				}
				else
				{
					buCall.buVector5_0.BoxSizeCalculate(Item.EntGroup, ref Item.SizeItem.MinPoint, ref Item.SizeItem.MidPoint, ref Item.SizeItem.MaxPoint);
					ObjectSize3D.CalculateSize(ref Item.SizeItem);
				}
			}
			else
			{
				buCall.buVector5_0.BoxSizeCalculate(Item.EntGroup, ref Item.SizeItem.MinPoint, ref Item.SizeItem.MidPoint, ref Item.SizeItem.MaxPoint);
				ObjectSize3D.CalculateSize(ref Item.SizeItem);
			}
			return;
		}
		List<Entity> list = new List<Entity>();
		list.AddRange(Item.ItemEntities.SolidEntity);
		for (int i = 0; i <= Item.Edges.Count - 1; i++)
		{
			if (Item.Edges[i].Slat.DataSlat.Enable && Item.Edges[i].Slat.Solid != null)
			{
				list.Add(Item.Edges[i].Slat.Solid);
			}
		}
		buCall.buVector5_0.BoxSizeCalculate(list, ref Item.SizeItem.MinPoint, ref Item.SizeItem.MidPoint, ref Item.SizeItem.MaxPoint);
		ObjectSize3D.CalculateSize(ref Item.SizeItem);
	}

	public void GetBoxSizeSelectedItems(ref MarbleSelection Selected)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Selected.SelectionItems.Count - 1; i++)
		{
			list.Add(Selected.SelectionItems[i].pntMin);
			list.Add(Selected.SelectionItems[i].pntMax);
		}
		buCall.buVector5_0.BoxSizeCalculate(list, ref Selected.pntTotalMin, ref Selected.pntTotalMax);
	}

	public void GetBoxSizeJobItems(MarbleJob activeJob, ref Point3D pntMin, ref Point3D pntMax)
	{
		List<Point3D> list = new List<Point3D>();
		pntMin = new Point3D();
		pntMax = new Point3D();
		for (int i = 0; i <= activeJob.Items.Count - 1; i++)
		{
			list.Add(activeJob.Items[i].SizeItem.MinPoint);
			list.Add(activeJob.Items[i].SizeItem.MaxPoint);
		}
		if (list.Count > 0)
		{
			buCall.buVector5_0.BoxSizeCalculate(list, ref pntMin, ref pntMax);
		}
	}

	public void GetBoxSizeJobItems(List<MarbleItem> Items, ref Point3D pntMin, ref Point3D pntMax)
	{
		List<Point3D> list = new List<Point3D>();
		pntMin = new Point3D();
		pntMax = new Point3D();
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			list.Add(Items[i].SizeItem.MinPoint);
			list.Add(Items[i].SizeItem.MaxPoint);
		}
		if (list.Count > 0)
		{
			buCall.buVector5_0.BoxSizeCalculate(list, ref pntMin, ref pntMax);
		}
	}

	public void GetItemIndexFromItemID(MarbleJob Job, int ItemID, ref int ItemIndex)
	{
		ItemIndex = -1;
		int num = 0;
		while (true)
		{
			if (num <= Job.Items.Count - 1)
			{
				if (Job.Items[num].ID == ItemID)
				{
					break;
				}
				num++;
				continue;
			}
			return;
		}
		ItemIndex = num;
	}

	public void ItemClockDirectionCheck(ref MarbleItem Item, ClockDirectionType CheckDirection)
	{
		if (Item != null && Item.EntGroup != null)
		{
			Item.EntGroup.Outside.Direction = buCall.buVector5_0.EntitiesClockDirection(Item.EntGroup.Outside.Entities);
			if (Item.EntGroup.Outside.Points == null)
			{
				Item.EntGroup.Outside.Points = new List<Point3D>();
			}
			if (Item.EntGroup.Outside.Direction != CheckDirection)
			{
				Item.EntGroup.Outside.Points.Clear();
				buCall.buVector5_0.ChangeEntitiesDirection(ref Item.EntGroup.Outside.Entities);
				Item.EntGroup.Outside.Direction = CheckDirection;
			}
			if (Item.EntGroup.Outside.Points.Count == 0)
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(Item.EntGroup.Outside.Entities, ref Item.EntGroup.Outside.Points);
			}
			Item.EntGroup.Outside.pntMassCenter = buCall.buVector5_0.CalculateCentroid(Item.EntGroup.Outside.Points);
		}
	}

	public DialogResult SaveHorVerItems(marbleCuttingItems[] ItemsHor, marbleCuttingItems[] ItemsVer, double HorizontalLength, double VerticalLength)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = varMarbleRunSettings.pathItems;
		saveFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
		saveFileDialog.FilterIndex = 1;
		DialogResult dialogResult = saveFileDialog.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			varMarbleRunSettings.pathItems = buFile.GetPath(saveFileDialog.FileName);
			ArrayList arrayList = new ArrayList();
			int num = 0;
			if (ItemsHor != null)
			{
				arrayList.Add("<HorizontalMarbleCuttingItems>");
				for (int i = 0; i <= ItemsHor.Length - 1; i++)
				{
					if ((ItemsHor[i].Length > 0.1) & (ItemsHor[i].Count > 0))
					{
						arrayList.AddRange(ItemsHor[i].ToDefAll("", 2, SerilizationMode5.MultiLine));
						num++;
					}
				}
				arrayList.Add("</HorizontalMarbleCuttingItems>");
				arrayList.Add("<HorizontalMarbleCuttingItemsLength>");
				arrayList.Add("  " + HorizontalLength);
				arrayList.Add("</HorizontalMarbleCuttingItemsLength>");
			}
			if (ItemsVer != null)
			{
				arrayList.Add("<VerticalMarbleCuttingItems>");
				for (int j = 0; j <= ItemsVer.Length - 1; j++)
				{
					if ((ItemsVer[j].Length > 0.1) & (ItemsHor[j].Count > 0))
					{
						arrayList.AddRange(ItemsVer[j].ToDefAll("", 2, SerilizationMode5.MultiLine));
						num++;
					}
				}
				arrayList.Add("</VerticalMarbleCuttingItems>");
				arrayList.Add("<VerticalMarbleCuttingItemsLength>");
				arrayList.Add("  " + VerticalLength);
				arrayList.Add("</VerticalMarbleCuttingItemsLength>");
			}
			if (!(arrayList.Count > 0 && num > 0))
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesMarble.ThereIsNoItemtoSave);
			}
			else
			{
				buFile.SaveToFile(arrayList, saveFileDialog.FileName);
			}
		}
		return dialogResult;
	}

	public DialogResult OpenHorVerItems(ref marbleCuttingItems[] ItemsHor, ref marbleCuttingItems[] ItemsVer, ref double HorizontalLength, ref double VerticalLength)
	{
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = varMarbleRunSettings.pathItems;
		openFileDialog.Filter = "Marble Item Files (.bumarbleitem)|*.bumarbleitem";
		openFileDialog.FilterIndex = 1;
		openFileDialog.Multiselect = false;
		DialogResult dialogResult = openFileDialog.ShowDialog();
		if (dialogResult == DialogResult.OK)
		{
			ArrayList StringList = new ArrayList();
			varMarbleRunSettings.pathItems = buFile.GetPath(openFileDialog.FileName);
			buFile.OpenFromFile(openFileDialog.FileName, ref StringList);
			List<List<string>> CalcList = new List<List<string>>();
			List<List<string>> CalcList2 = new List<List<string>>();
			for (int i = 0; i <= ItemsHor.Length - 1; i++)
			{
				ItemsHor[i] = new marbleCuttingItems();
			}
			for (int j = 0; j <= ItemsVer.Length - 1; j++)
			{
				ItemsVer[j] = new marbleCuttingItems();
			}
			List<string> CalcList3 = new List<string>();
			buString.ListToSpecificList("<HorizontalMarbleCuttingItems>", "</HorizontalMarbleCuttingItems>", AddStartEndKey: true, StringList, ref CalcList3);
			if (CalcList3.Count > 0)
			{
				buString.ListToSpecificList("<marbleCuttingItems>", "</marbleCuttingItems>", AddStartEndKey: true, CalcList3, ref CalcList);
				for (int k = 0; k <= CalcList.Count - 1; k++)
				{
					marbleCuttingItems marbleCuttingItems2 = new marbleCuttingItems();
					buSerilization5.Decode(CalcList[k], "", SerilizationMode5.MultiLine, marbleCuttingItems2);
					ItemsHor[k].Length = marbleCuttingItems2.Length;
					ItemsHor[k].Count = marbleCuttingItems2.Count;
					ItemsHor[k].StartAngle = marbleCuttingItems2.StartAngle;
					ItemsHor[k].EndAngle = marbleCuttingItems2.EndAngle;
				}
			}
			CalcList3 = new List<string>();
			buString.ListToSpecificList("<HorizontalMarbleCuttingItemsLength>", "</HorizontalMarbleCuttingItemsLength>", AddStartEndKey: false, StringList, ref CalcList3);
			if (CalcList3.Count > 0 && buNumeric5.IsNumeric(CalcList3[0]))
			{
				HorizontalLength = Convert.ToDouble(CalcList3[0]);
			}
			CalcList3 = new List<string>();
			buString.ListToSpecificList("<VerticalMarbleCuttingItems>", "</VerticalMarbleCuttingItems>", AddStartEndKey: true, StringList, ref CalcList3);
			if (CalcList3.Count > 0)
			{
				buString.ListToSpecificList("<marbleCuttingItems>", "</marbleCuttingItems>", AddStartEndKey: true, CalcList3, ref CalcList2);
				for (int l = 0; l <= CalcList2.Count - 1; l++)
				{
					marbleCuttingItems marbleCuttingItems3 = new marbleCuttingItems();
					buSerilization5.Decode(CalcList2[l], "", SerilizationMode5.MultiLine, marbleCuttingItems3);
					ItemsVer[l].Length = marbleCuttingItems3.Length;
					ItemsVer[l].Count = marbleCuttingItems3.Count;
					ItemsVer[l].StartAngle = marbleCuttingItems3.StartAngle;
					ItemsVer[l].EndAngle = marbleCuttingItems3.EndAngle;
				}
			}
			CalcList3 = new List<string>();
			buString.ListToSpecificList("<VerticalMarbleCuttingItemsLength>", "</VerticalMarbleCuttingItemsLength>", AddStartEndKey: false, StringList, ref CalcList3);
			if (CalcList3.Count > 0 && buNumeric5.IsNumeric(CalcList3[0]))
			{
				VerticalLength = Convert.ToDouble(CalcList3[0]);
			}
			CalcList3.Clear();
		}
		return dialogResult;
	}

	public void CreateEdgeEntity(buEntity entCurve, double OffsetDistance, double ExtrudeDistance, bool Selectable, int Index, string OutsideInside, ref buEntity entityEdge)
	{
		devDept.Eyeshot.Entities.Region region = null;
		List<Point3D> OffsetedPoints = new List<Point3D>();
		if (entCurve.Vertices.Count > 0)
		{
			if (!buCall.buVector5_0.IsClosed(entCurve.Vertices))
			{
				buCall.buVector5_0.OffsetOpenContour(entCurve.Vertices, OffsetDistance, OffsetCornerType.Line, CamOpenContourType.Left, Plane.XY, 0.0, ref OffsetedPoints);
				LinearPath outer = new LinearPath(OffsetedPoints);
				region = new devDept.Eyeshot.Entities.Region(outer);
			}
			else
			{
				buCall.buVector5_0.OffsetContour(entCurve.Vertices, OffsetDistance, OffsetCornerType.Line, CamOpenContourType.Center, Plane.XY, 0.0, ref OffsetedPoints);
				List<ICurve> list = new List<ICurve>();
				LinearPath item = new LinearPath(OffsetedPoints);
				list.Add(item);
				item = new LinearPath(entCurve.Vertices);
				list.Add(item);
				region = new devDept.Eyeshot.Entities.Region(list);
			}
			if (region != null)
			{
				Mesh another = region.ExtrudeAsMesh(ExtrudeDistance, 0.1, Mesh.natureType.RichSmooth);
				entityEdge = new buMesh(another);
				entityEdge.Info.Selectable = Selectable;
				entityEdge.Marble = new MarbleInfo();
				entityEdge.Info.EntityIndex = 0;
				entityEdge.Info.EntitySubIndex = 0;
				entityEdge.Info.RefIndex = Index;
				entityEdge.Info.Tags = "Edge";
				entityEdge.Info.Data = OutsideInside;
			}
		}
	}

	public void CreateEmptyItem(ref MarbleItem Item)
	{
		Item = new MarbleItem();
		Item.ItemEntities.GroupEntities = new List<buEntitiesGroup>();
		Item.EntGroup = new buEntitiesGroup();
		Item.ItemEntities.SourceEntities = new List<buEntity>();
		Item.ItemEntities.DrawWireEntities = new List<buEntity>();
		Item.ItemEntities.EdgeEntities = new List<buEntity>();
		Item.ItemEntities.ExtensionEntities = new List<buEntity>();
	}

	public bool GetEntityCommand(string refWord, ref string Cmd, ref int ItemID, ref int EdgeIndex, ref int EntityOutsideIndex, ref int EntityInsideIndex, ref int EntityInsideSubIndex, ref string Info, ref string Aux)
	{
		string[] array = refWord.Split(';');
		if (array == null || array.Length < 7)
		{
			return false;
		}
		Cmd = array[0];
		ItemID = Convert.ToInt32(array[1]);
		EdgeIndex = Convert.ToInt32(array[2]);
		EntityOutsideIndex = Convert.ToInt32(array[3]);
		EntityInsideIndex = Convert.ToInt32(array[4]);
		EntityInsideSubIndex = Convert.ToInt32(array[5]);
		Info = array[6];
		Aux = array[7];
		return true;
	}

	public void CharSizeCalculateFromItemSize(double Width, double Height, double MinSize, double MaxSize, double Ratio, ref double calcHeight, ref double calcRatio)
	{
		double num = MinSize;
		num = ((Width < Height) ? (Width * Ratio) : (Height * Ratio));
		if (num < MinSize)
		{
			num = MinSize;
		}
		if (num > MaxSize)
		{
			num = MaxSize;
		}
		calcRatio = num / MinSize;
		calcHeight = Math.Round(num, 1);
	}

	public void AddCurvatureToConcaveEntities(buEntity Ent, List<buEntity> CurveEntities, ref List<buEntity> concaveEL)
	{
		if ((Ent.Info.RefIndex >= 0) & (Ent.Info.RefIndex <= CurveEntities.Count - 1))
		{
			int refIndex = Ent.Info.RefIndex;
			double num = buCall.buVector5_0.Length3D(concaveEL[0].Vertices[0], CurveEntities[refIndex].Vertices[0]);
			double num2 = buCall.buVector5_0.Length3D(concaveEL[0].Vertices[0], CurveEntities[refIndex].Vertices[CurveEntities[refIndex].Vertices.Count - 1]);
			List<Point3D> CopiedPnt = new List<Point3D>();
			CopiedPnt.Add(concaveEL[0].Vertices[0]);
			if (!(num <= num2))
			{
				List<Point3D> copiedPoint = new List<Point3D>();
				buVector5.Copy(CurveEntities[refIndex].Vertices, ref copiedPoint);
				copiedPoint.Reverse();
				buVector5.Add(copiedPoint, ref CopiedPnt);
			}
			else
			{
				buVector5.Add(CurveEntities[refIndex].Vertices, ref CopiedPnt);
			}
			CopiedPnt.Add(concaveEL[0].Vertices[concaveEL[0].Vertices.Count - 1]);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref CopiedPnt);
			concaveEL[0] = new buLinearPath(CopiedPnt);
		}
	}

	public void FindItemsInsideMaterials(MaterialBase5 Mat, List<MarbleItem> Items, ref List<MarbleItem> FoundItems)
	{
		if (Mat == null)
		{
			return;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			Point3D minPoint = new Point3D(Mat.BoxMinPoint.X - 0.5, Mat.BoxMinPoint.Y - 0.5, Mat.BoxMinPoint.Z);
			Point3D maxPoint = new Point3D(Mat.BoxMaxPoint.X + 0.5, Mat.BoxMaxPoint.Y + 0.5, Mat.BoxMaxPoint.Z);
			bool flag = buCall.buVector5_0.IsPointInsideBoxsize(Items[i].SizeItem.MinPoint, minPoint, maxPoint, Plane.XY);
			bool flag2 = buCall.buVector5_0.IsPointInsideBoxsize(Items[i].SizeItem.MaxPoint, minPoint, maxPoint, Plane.XY);
			if (flag && flag2)
			{
				FoundItems.Add(Items[i]);
			}
		}
	}

	public void GetMaterialListFromFiles(string Path, ref List<marbleMaterialType> MatList)
	{
		if (MatList == null)
		{
			MatList = new List<marbleMaterialType>();
		}
		MatList.Clear();
		new List<string>();
		List<string> Files = new List<string>();
		buFile.GetFilesInDirectory(AppPath.Materials, ".bumarblemats", ref Files);
		for (int i = 0; i <= Files.Count - 1; i++)
		{
			marbleMaterialType marbleMaterialType2 = new marbleMaterialType();
			marbleMaterialType2.Parameters = new marbleCamPars();
			List<string> StringList = new List<string>();
			buFile5.OpenFromFile(Files[i], ref StringList);
			buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, marbleMaterialType2.Parameters);
			marbleMaterialType2.MaterialNames = buFile.getFileNameWithoutExtension(Files[i]);
			FileInfo fileInfo = new FileInfo(AppPath.Materials + "\\" + marbleMaterialType2.MaterialNames + ".jpg");
			if (!fileInfo.Exists)
			{
				fileInfo = new FileInfo(AppPath.Materials + "\\" + marbleMaterialType2.MaterialNames + ".png");
				if (!fileInfo.Exists)
				{
					fileInfo = new FileInfo(AppPath.Materials + "\\" + marbleMaterialType2.MaterialNames + ".bmp");
					if (fileInfo.Exists)
					{
						marbleMaterialType2.Photo = Image.FromFile(fileInfo.FullName);
					}
				}
				else
				{
					marbleMaterialType2.Photo = Image.FromFile(fileInfo.FullName);
				}
			}
			else
			{
				marbleMaterialType2.Photo = Image.FromFile(fileInfo.FullName);
			}
			MatList.Add(marbleMaterialType2);
		}
	}

	public void ShowMaterialPage()
	{
		if (buMarbleForms.frmMaterialList == null)
		{
			buMarbleForms.frmMaterialList = new F_MarbleMaterialList();
		}
		buMarbleForms.frmMaterialList.Settings = new marbleCamPars(varOperation.settingMarbleCam);
		buMarbleForms.frmMaterialList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		buMarbleForms.frmMaterialList.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
		buMarbleForms.frmMaterialList.Init();
		buMarbleForms.frmMaterialList.ShowDialog();
		if (buMarbleForms.frmMaterialList.PropertiesForm.Result == DialogResult.OK)
		{
			varOperation.settingMarbleCam = new marbleCamPars(buMarbleForms.frmMaterialList.Settings);
		}
	}

	public void GetMaterialBorderLimits(MarbleJob Job, ToolBase5 ToolSaw)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double baseWoodHeight = varMarbleMachineSettings.BaseWoodHeight;
		double num4 = varMarbleMachineSettings.BaseWoodHeight;
		if (Job.Material.Enable)
		{
			Math.Round(Job.Material.Size.Width, 3);
			baseWoodHeight = Math.Round(Job.Material.Size.Height, 3);
			num = Math.Round(Job.Material.BoxMinPoint.X, 3);
			num2 = Math.Round(Job.Material.BoxMinPoint.Y, 3);
			num4 = num2 + baseWoodHeight;
		}
		List<Point3D> list = new List<Point3D>();
		MarbleTempVars.MaterialLimits.Clear();
		if (Job.Items.Count != 0)
		{
			List<Pnt6D> SortingPoints = new List<Pnt6D>();
			for (int i = 0; i <= Job.Items.Count - 1; i++)
			{
				bool flag = false;
				bool flag2 = false;
				bool flag3 = false;
				double num5 = Job.Items[i].SizeItem.MinPoint.X + Job.Items[i].OffsetX;
				double num6 = Job.Items[i].SizeItem.MinPoint.Y + Job.Items[i].OffsetY;
				double x = Job.Items[i].SizeItem.MaxPoint.X + Job.Items[i].OffsetX;
				double num7 = Job.Items[i].SizeItem.MaxPoint.Y + Job.Items[i].OffsetY;
				for (int j = 0; j <= Job.Items.Count - 1; j++)
				{
					if (i != j)
					{
						flag |= buNumeric5.IsValueInsideMinMaxValues(num6, Job.Items[j].SizeItem.MinPoint.Y + Job.Items[j].OffsetY, Job.Items[j].SizeItem.MaxPoint.Y + Job.Items[j].OffsetY);
						flag2 |= buNumeric5.IsValueInsideMinMaxValues(num7, Job.Items[j].SizeItem.MinPoint.Y + Job.Items[j].OffsetY, Job.Items[j].SizeItem.MaxPoint.Y + Job.Items[j].OffsetY);
						if ((flag || flag2) && num5 > Job.Items[j].SizeItem.MaxPoint.X + Job.Items[j].OffsetX)
						{
							flag3 = true;
						}
					}
				}
				if (!flag)
				{
					SortingPoints.Add(new Pnt6D(num5, num6, i, -1.0, 0.0, 0.0));
				}
				else if (flag3)
				{
					SortingPoints.Add(new Pnt6D(num5, num6, i, -1.0, 0.0, 0.0));
				}
				if (!flag2)
				{
					SortingPoints.Add(new Pnt6D(x, num7, i, 1.0, 0.0, 0.0));
				}
				else if (flag3)
				{
					SortingPoints.Add(new Pnt6D(x, num7, i, 1.0, 0.0, 0.0));
				}
			}
			buCall.buVector5_0.SortDeltaY(new Point3D(-100.0, 100.0, 0.0), SortDirectionType.Lower, ref SortingPoints);
			buCall.buVector5_0.CheckDuplicatedPointAxesWithPrevious(ref SortingPoints, AxesXYZ.Y);
			if (SortingPoints.Count == 0)
			{
				return;
			}
			for (int k = 0; k <= SortingPoints.Count - 1; k++)
			{
				double num8 = -10000000.0;
				num3 = 0.0;
				for (int l = 0; l <= Job.Items.Count - 1; l++)
				{
					Point3D firstPoint = new Point3D(Job.Items[l].SizeItem.MinPoint.X + Job.Items[l].OffsetX, Job.Items[l].SizeItem.MinPoint.Y + Job.Items[l].OffsetY, Job.Items[l].SizeItem.MinPoint.Z);
					Point3D secondPoint = new Point3D(Job.Items[l].SizeItem.MaxPoint.X + Job.Items[l].OffsetX, Job.Items[l].SizeItem.MaxPoint.Y + Job.Items[l].OffsetY, Job.Items[l].SizeItem.MaxPoint.Z);
					Entity entRectangle = null;
					Entity entity = new Line(new Point3D(0.0, SortingPoints[k].Y), new Point3D(100000.0, SortingPoints[k].Y));
					buCall.buVector5_0.Rectangle2Point(firstPoint, secondPoint, Plane.XY, ref entRectangle);
					Point3D[] array = ((ICurve)entity).IntersectWith((ICurve)entRectangle);
					if (array == null || array.Length == 0)
					{
						continue;
					}
					for (int m = 0; m <= array.Length - 1; m++)
					{
						if (array[m].X > num8)
						{
							num8 = array[m].X;
						}
					}
				}
				num3 = SortingPoints[k].A * ToolSaw.Geometry.Thickness;
				list.Add(new Point3D(num8 + ToolSaw.Geometry.Thickness, SortingPoints[k].Y + num3, SortingPoints[k].Z));
			}
			if (list.Count <= 0)
			{
				return;
			}
			if (!(list[0].Y < varOperation.MaterialParameter.EdgeBorderGap))
			{
				MarbleTempVars.MaterialLimits.Add(new Point3D(num, num2));
				list[0].Y = list[0].Y - ToolSaw.Geometry.Thickness;
				Point3D point3D = buVector5.ToPoint3D(list[0]);
				point3D.X = num;
				MarbleTempVars.MaterialLimits.Add(point3D);
			}
			else
			{
				Point3D point3D2 = buVector5.ToPoint3D(list[0]);
				point3D2.Y = num2;
				MarbleTempVars.MaterialLimits.Add(point3D2);
			}
			for (int n = 0; n <= list.Count - 1; n++)
			{
				double num9 = 0.0;
				num3 = 0.0;
				if (n > 0)
				{
					double num10 = list[n].Y - list[n - 1].Y;
					_ = list[n].X - list[n - 1].X;
					double value = list[n].Z - list[n - 1].Z;
					if (Math.Abs(value) > 0.0)
					{
						if (!(num10 > varOperation.MaterialParameter.PartAndPartBorderDistance))
						{
							if (!(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1].X < list[n].X))
							{
								MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1].Y = MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1].Y + ToolSaw.Geometry.Thickness;
								Point3D point3D3 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
								point3D3.X = list[n].X;
								MarbleTempVars.MaterialLimits.Add(point3D3);
							}
							else
							{
								MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1].Y = list[n].Y;
								Point3D point3D4 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
								point3D4.X = list[n].X;
								MarbleTempVars.MaterialLimits.Add(point3D4);
							}
						}
						else
						{
							Point3D pntMin = new Point3D(-100.0, (list[n].Y + list[n - 1].Y) / 2.0, 0.0);
							Point3D pntMax = new Point3D(100000.0, (list[n].Y + list[n - 1].Y) / 2.0, 0.0);
							double MinX = 0.0;
							double MaxX = 0.0;
							if (MarbleItemIntersectionWithLine(Job, pntMin, pntMax, ref MinX, ref MaxX))
							{
								MaxX += ToolSaw.Geometry.Thickness;
							}
							else
							{
								MinX = num;
								MaxX = num;
							}
							Point3D point3D5 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
							point3D5.X = MaxX;
							MarbleTempVars.MaterialLimits.Add(point3D5);
							point3D5 = buVector5.ToPoint3D(list[n]);
							point3D5.X = MaxX;
							point3D5.Y -= ToolSaw.Geometry.Thickness;
							MarbleTempVars.MaterialLimits.Add(point3D5);
						}
					}
				}
				MarbleTempVars.MaterialLimits.Add(new Point3D(list[n].X + num9, list[n].Y + num3, 0.0));
			}
			if (!(num4 - MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1].Y < varOperation.MaterialParameter.EdgeBorderGap))
			{
				Point3D point3D6 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
				point3D6.X = num;
				MarbleTempVars.MaterialLimits.Add(point3D6);
				point3D6 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
				point3D6.Y = num4;
				MarbleTempVars.MaterialLimits.Add(point3D6);
			}
			else
			{
				Point3D point3D7 = buVector5.ToPoint3D(MarbleTempVars.MaterialLimits[MarbleTempVars.MaterialLimits.Count - 1]);
				point3D7.Y = num4;
				MarbleTempVars.MaterialLimits.Add(point3D7);
			}
		}
		else
		{
			MarbleTempVars.MaterialLimits.Add(new Point3D());
			MarbleTempVars.MaterialLimits.Add(new Point3D(0.0, num4, 0.0));
		}
	}

	public bool MarbleItemIntersectionWithLine(MarbleJob Job, Point3D pntMin, Point3D pntMax, ref double MinX, ref double MaxX)
	{
		bool result = false;
		MaxX = -999999.0;
		MinX = 99999999.0;
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			Entity entRectangle = null;
			Entity entity = new Line(new Point3D(0.0, pntMin.Y), new Point3D(100000.0, pntMax.Y));
			Point3D firstPoint = new Point3D(Job.Items[i].SizeItem.MinPoint.X + Job.Items[i].OffsetX, Job.Items[i].SizeItem.MinPoint.Y + Job.Items[i].OffsetY, Job.Items[i].SizeItem.MinPoint.Z);
			Point3D secondPoint = new Point3D(Job.Items[i].SizeItem.MaxPoint.X + Job.Items[i].OffsetX, Job.Items[i].SizeItem.MaxPoint.Y + Job.Items[i].OffsetY, Job.Items[i].SizeItem.MaxPoint.Z);
			buCall.buVector5_0.Rectangle2Point(firstPoint, secondPoint, Plane.XY, ref entRectangle);
			Point3D[] array = ((ICurve)entity).IntersectWith((ICurve)entRectangle);
			if (array == null || array.Length == 0)
			{
				continue;
			}
			result = true;
			for (int j = 0; j <= array.Length - 1; j++)
			{
				if (array[j].X > MaxX)
				{
					MaxX = array[j].X;
				}
				if (array[j].X < MinX)
				{
					MinX = array[j].X;
				}
			}
		}
		return result;
	}

	public void GetAutoMagnetPosition(MarbleJob Job, MarbleItem Item, ref List<Point3D> foundPoint)
	{
	}

	public void CreateMaterial(List<Point3D> PLOutter, List<List<Point3D>> PLInner, MaterialShapes ShapeType, double Thickness, Image refImage, ref MaterialBase5 Mat)
	{
		Entity entSurface = null;
		buCall.buVector5_0.surfaceFromOutterInner(PLOutter, PLInner, Thickness, ref entSurface);
		if (entSurface != null)
		{
			Mat.Points.Clear();
			if (Mat.InnerPoints != null)
			{
				Mat.InnerPoints.Clear();
			}
			if (refImage != null)
			{
				Mat.matImage = (Image)refImage.Clone();
			}
			entSurface.Regen(0.1);
			Mat.Entities.Clear();
			Mat.Entities.Add(entSurface);
			buVector5.Copy(PLOutter, ref Mat.Points);
			buVector5.Copy(PLInner, ref Mat.InnerPoints);
			Mat.Shapes = ShapeType;
			Point3D MidPoint = new Point3D();
			buCall.buVector5_0.BoxSizeCalculate(Mat.Points, ref Mat.BoxMinPoint, ref MidPoint, ref Mat.BoxMaxPoint);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Material;
			entSurface.EntityData = customData;
			entSurface.LayerName = MarbleTempVars.layerMarbleSheet.Name;
			entSurface.Color = Color.FromArgb(varMarbleColorSettings.colorMaterial.Transperancy, varMarbleColorSettings.colorMaterial.Color);
			entSurface.ColorMethod = colorMethodType.byEntity;
			entSurface.Selectable = false;
			Mat.Enable = true;
			Mat.Size.Width = Mat.BoxMaxPoint.X - Mat.BoxMinPoint.X;
			Mat.Size.Height = Mat.BoxMaxPoint.Y - Mat.BoxMinPoint.Y;
			Mat.Size.Depth = Thickness;
		}
	}

	public int FindMaterialWithPoint(List<MaterialBase5> Mats, Point3D refPoint, ref MaterialBase5 FoundMat)
	{
		int result = -1;
		for (int i = 0; i <= Mats.Count - 1; i++)
		{
			MaterialBase5 materialBase = Mats[i];
			if (buCall.buVector5_0.IsPointInsideBoxsize(refPoint, materialBase.BoxMinPoint, materialBase.BoxMaxPoint, Plane.XY))
			{
				FoundMat = new MaterialBase5(Mats[i]);
				result = i;
			}
		}
		return result;
	}

	public void MoveVacuumCut(ref MarbleJob Job, double dX, double dY, int VacuumIndex)
	{
		if (!((VacuumIndex >= 0) & (VacuumIndex <= Job.VacuumCuts.Count - 1)))
		{
			return;
		}
		MarbleVacuumCut marbleVacuumCut = Job.VacuumCuts[VacuumIndex];
		marbleVacuumCut.MoveX += dX;
		marbleVacuumCut.MoveY += dY;
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			MarbleItem Item = Job.Items[i];
			Job.Items[i].OffsetX = 0.0;
			Job.Items[i].OffsetY = 0.0;
			if (marbleVacuumCut.Direction == HorizontalVertical.Vertical && Job.Items[i].SizeItem.MinPoint.X > marbleVacuumCut.StartPoint.X)
			{
				MoveItem(ref Item, marbleVacuumCut.MoveX, 0.0, 0.0);
			}
			if (marbleVacuumCut.Direction == HorizontalVertical.Horizontal && buCompare5.GT(Job.Items[i].SizeItem.MinPoint.Y, marbleVacuumCut.StartPoint.Y, 1.0) && (buCompare5.LE(marbleVacuumCut.StartPoint.X, Job.Items[i].SizeItem.MinPoint.X, 2.0) & buCompare5.LE(Job.Items[i].SizeItem.MaxPoint.X, marbleVacuumCut.EndPoint.X, 2.0)))
			{
				MoveItem(ref Item, 0.0, marbleVacuumCut.MoveY, 0.0);
			}
		}
		for (int j = 0; j <= Job.VacuumMaterials.Count - 1; j++)
		{
		}
		for (int k = 0; k <= Job.VacuumCuts.Count - 1; k++)
		{
			Job.VacuumCuts[k].OffsetX = 0.0;
			Job.VacuumCuts[k].OffsetY = 0.0;
			for (int l = 0; l <= VacuumIndex; l++)
			{
				if (Job.VacuumCuts[k].VacuumID != Job.VacuumCuts[l].VacuumID)
				{
					if (Job.VacuumCuts[l].Direction == HorizontalVertical.Vertical && ((Job.VacuumCuts[k].StartPoint.X > Job.VacuumCuts[l].StartPoint.X) & (Job.VacuumCuts[k].EndPoint.X > Job.VacuumCuts[l].StartPoint.X)))
					{
						Job.VacuumCuts[k].OffsetX = Job.VacuumCuts[k].OffsetX + Job.VacuumCuts[l].MoveX;
					}
					if (Job.VacuumCuts[l].Direction == HorizontalVertical.Horizontal && ((Job.VacuumCuts[k].StartPoint.Y > Job.VacuumCuts[l].StartPoint.Y) & (Job.VacuumCuts[k].EndPoint.Y > Job.VacuumCuts[l].StartPoint.Y)))
					{
						Job.VacuumCuts[k].OffsetY = Job.VacuumCuts[k].OffsetY + Job.VacuumCuts[l].MoveY;
					}
				}
			}
		}
	}

	public void DevideVacuumMaterial(MaterialBase5 baseMaterial, MarbleVacuumCut CutLine, double SecondMoveX, double SecondMoveY, ref MaterialBase5 FirstMaterial, ref MaterialBase5 SecondMaterial)
	{
		if (CutLine.Direction == HorizontalVertical.Vertical && ((baseMaterial.BoxMinPoint.X < CutLine.StartPoint.X) & (CutLine.StartPoint.X < baseMaterial.BoxMaxPoint.X)))
		{
			double num = 0.0;
			double num2 = 0.0;
			num = CutLine.StartPoint.X - baseMaterial.BoxMinPoint.X;
			num2 = baseMaterial.Size.Height;
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(baseMaterial.BoxMinPoint.X + num, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(baseMaterial.BoxMinPoint.X + num, baseMaterial.BoxMinPoint.Y + num2, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y + num2, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			FirstMaterial = new MaterialBase5(baseMaterial);
			FirstMaterial.Entities.Clear();
			CreateMaterial(list, null, baseMaterial.Shapes, baseMaterial.Size.Depth, baseMaterial.matImage, ref FirstMaterial);
			num = baseMaterial.BoxMaxPoint.X - CutLine.StartPoint.X;
			num2 = baseMaterial.Size.Height;
			list = new List<Point3D>();
			list.Add(new Point3D(CutLine.StartPoint.X + SecondMoveX, baseMaterial.BoxMinPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(CutLine.StartPoint.X + num + SecondMoveX, baseMaterial.BoxMinPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(CutLine.StartPoint.X + num + SecondMoveX, baseMaterial.BoxMinPoint.Y + num2 + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(CutLine.StartPoint.X + SecondMoveX, baseMaterial.BoxMinPoint.Y + num2 + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list.Add(new Point3D(CutLine.StartPoint.X + SecondMoveX, baseMaterial.BoxMinPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			SecondMaterial = new MaterialBase5(baseMaterial);
			SecondMaterial.Entities.Clear();
			CreateMaterial(list, null, baseMaterial.Shapes, baseMaterial.Size.Depth, baseMaterial.matImage, ref SecondMaterial);
		}
		if (CutLine.Direction == HorizontalVertical.Horizontal && ((baseMaterial.BoxMinPoint.Y < CutLine.StartPoint.Y) & (CutLine.StartPoint.Y < baseMaterial.BoxMaxPoint.Y)))
		{
			double num3 = 0.0;
			double num4 = 0.0;
			num3 = baseMaterial.Size.Width;
			num4 = CutLine.EndPoint.Y - baseMaterial.BoxMinPoint.Y;
			List<Point3D> list2 = new List<Point3D>();
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + num3, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + num3, baseMaterial.BoxMinPoint.Y + num4, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y + num4, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X, baseMaterial.BoxMinPoint.Y, baseMaterial.BoxMinPoint.Z));
			FirstMaterial = new MaterialBase5(baseMaterial);
			FirstMaterial.Entities.Clear();
			CreateMaterial(list2, null, baseMaterial.Shapes, baseMaterial.Size.Depth, baseMaterial.matImage, ref FirstMaterial);
			num3 = baseMaterial.Size.Width;
			num4 = baseMaterial.BoxMaxPoint.Y - CutLine.StartPoint.Y;
			list2 = new List<Point3D>();
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + SecondMoveX, CutLine.StartPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + num3 + SecondMoveX, CutLine.StartPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + num3 + SecondMoveX, CutLine.StartPoint.Y + num4 + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + SecondMoveX, CutLine.StartPoint.Y + num4 + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			list2.Add(new Point3D(baseMaterial.BoxMinPoint.X + SecondMoveX, CutLine.StartPoint.Y + SecondMoveY, baseMaterial.BoxMinPoint.Z));
			SecondMaterial = new MaterialBase5(baseMaterial);
			SecondMaterial.Entities.Clear();
			CreateMaterial(list2, null, baseMaterial.Shapes, baseMaterial.Size.Depth, baseMaterial.matImage, ref SecondMaterial);
		}
	}

	public bool isVacuumCutInsideMaterial(MaterialBase5 Material, MarbleVacuumCut CutLine)
	{
		try
		{
			return buCall.buVector5_0.IsPointInsideWindow(Material.BoxMinPoint, Material.BoxMaxPoint, CutLine.StartPoint, Plane.XY, UseEqualCondition: true);
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void mouseMoveViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buEyeItems.viewportDialogs.Name)
		{
		}
	}

	public void mouseDownViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (control.Name == buEyeItems.viewportDialogs.Name)
		{
		}
	}

	public void mouseUpViewport(object sender, MouseEventArgs e)
	{
		Control control = sender as Control;
		if (e.Button == MouseButtons.Left && control.Name == buEyeItems.viewportCadCam.Name)
		{
		}
	}

	public void RegenEntities(ref List<Entity> EntityList, double Regen, Design Doc)
	{
		for (int i = 0; i <= EntityList.Count - 1; i++)
		{
			Entity Entity = EntityList[i];
			RegenEntities(ref Entity, Regen, Doc);
		}
	}

	public void RegenEntities(ref Entity Entity, double Regen, Design Doc)
	{
		RegenParams data = new RegenParams(Regen, Doc);
		Entity.Regen(data);
	}

	public Entity SetEntityData(Entity Ent, MarbleItem MI, int indexItem, int indexRef, int indexCam, string Name, entityTypeDefination EntType, string LayerName, bool Selectable, double Thickess, Color Clr)
	{
		Ent.Color = Clr;
		Ent.LineWeight = (float)Thickess;
		Ent.ColorMethod = colorMethodType.byEntity;
		Ent.LineWeightMethod = colorMethodType.byEntity;
		Ent.LayerName = LayerName;
		Ent.Selectable = Selectable;
		if (Ent.EntityData != null)
		{
			if (Ent.EntityData.GetType() != typeof(CustomData))
			{
				Ent.EntityData = new CustomData();
			}
		}
		else
		{
			Ent.EntityData = new CustomData();
		}
		if (MI == null)
		{
			((CustomData)Ent.EntityData).EntityName = Name;
			((CustomData)Ent.EntityData).ActionName = Name;
			((CustomData)Ent.EntityData).ID = "";
		}
		else
		{
			((CustomData)Ent.EntityData).EntityName = MI.ItemType.ToString() + MI.ID + "-" + Name;
			((CustomData)Ent.EntityData).ActionName = MI.ItemType.ToString() + MI.ID + "-" + Name;
			((CustomData)Ent.EntityData).ID = MI.ID.ToString();
		}
		((CustomData)Ent.EntityData).typeDefination = EntType;
		((CustomData)Ent.EntityData).Tags = Name;
		((CustomData)Ent.EntityData).RefIndex = indexRef;
		((CustomData)Ent.EntityData).GroupIdIndex = indexItem;
		((CustomData)Ent.EntityData).CamID = indexCam;
		return Ent;
	}

	public void CameraNewPositionandSizeCalculation(double NewHeight, ref double XOffset, ref double YOffset, ref double WidthOffset, ref double HegihtOffset)
	{
		XOffset = (NewHeight - 0.0) / varMarbleSettings.CameraLensXRatio + varMarbleRunSettings.CameraFirstXPosition;
		YOffset = (NewHeight - 0.0) / varMarbleSettings.CameraLensYRatio + varMarbleRunSettings.CameraFirstYPosition;
		WidthOffset = varMarbleRunSettings.CameraFirstXPosition - XOffset;
		HegihtOffset = varMarbleRunSettings.CameraFirstYPosition - YOffset;
	}

	public void ARotationCenterCalc(double dZ, double dY, double Angle, double SawDiameter, double SawThickness, ref double CenterDistance)
	{
		CenterDistance = 0.0;
		double num = Math.Sqrt(Math.Pow(dY, 2.0) + Math.Pow(dZ, 2.0));
		double num2 = Math.Sin(buConversion5.DegreeToRadian(Angle / 2.0)) * 2.0;
		double x = num / num2;
		CenterDistance = Math.Sqrt(Math.Pow(x, 2.0) - Math.Pow(SawDiameter / 2.0, 2.0));
	}

	public void AddInfoType(InfoType I, ref List<InfoType> List)
	{
		if (List.Count != 0)
		{
			bool flag = false;
			for (int i = 0; i <= List.Count - 1; i++)
			{
				if (List[i].Mode != I.Mode)
				{
					continue;
				}
				if (!((List[i].CodeType == I.CodeType) & (List[i].Code == I.Code) & (List[i].Axis == I.Axis)))
				{
					if ((List[i].Message == I.Message) & (List[i].Code == I.Code) & (List[i].Axis == I.Axis))
					{
						flag = true;
						i = List.Count;
					}
				}
				else
				{
					flag = true;
					i = List.Count;
				}
			}
			if (!flag)
			{
				List.Add(I);
			}
		}
		else
		{
			List.Add(I);
		}
	}

	public void SawCornerConnect(Point3D pntMin, Point3D pntMax, Point3D firstP, Point3D lastP, bool isLast, ref List<Point3D> PLFill)
	{
		for (int i = 1; i <= 4; i++)
		{
			if (!buCompare5.EQ(lastP.X, pntMin.X))
			{
				if (!buCompare5.EQ(lastP.Y, pntMin.Y))
				{
					if (!buCompare5.EQ(lastP.X, pntMax.X))
					{
						if (buCompare5.EQ(lastP.Y, pntMax.Y))
						{
							if (!(buCompare5.EQ(lastP.X, pntMax.X) & buCompare5.EQ(lastP.Y, pntMax.Y)))
							{
								if (!(buCompare5.EQ(lastP.X, pntMin.X) & buCompare5.EQ(lastP.Y, pntMax.Y)))
								{
									PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
									lastP = PLFill[PLFill.Count - 1];
								}
								else
								{
									PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
									lastP = PLFill[PLFill.Count - 1];
								}
							}
							else
							{
								PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
								lastP = PLFill[PLFill.Count - 1];
							}
						}
					}
					else if (!(buCompare5.EQ(lastP.X, pntMax.X) & buCompare5.EQ(lastP.Y, pntMin.Y)))
					{
						if (!(buCompare5.EQ(lastP.X, pntMax.X) & buCompare5.EQ(lastP.Y, pntMax.Y)))
						{
							PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
							lastP = PLFill[PLFill.Count - 1];
						}
						else
						{
							PLFill.Add(new Point3D(pntMin.X, pntMax.Y, lastP.Z));
							lastP = PLFill[PLFill.Count - 1];
						}
					}
					else
					{
						PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
						lastP = PLFill[PLFill.Count - 1];
					}
				}
				else if (!(buCompare5.EQ(lastP.X, pntMax.X) & buCompare5.EQ(lastP.Y, pntMin.Y)))
				{
					if (!(buCompare5.EQ(lastP.X, pntMin.X) & buCompare5.EQ(lastP.Y, pntMin.Y)))
					{
						PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
						lastP = PLFill[PLFill.Count - 1];
					}
					else
					{
						PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
						lastP = PLFill[PLFill.Count - 1];
					}
				}
				else
				{
					PLFill.Add(new Point3D(pntMax.X, pntMax.Y, lastP.Z));
					lastP = PLFill[PLFill.Count - 1];
				}
			}
			else if (!(buCompare5.EQ(lastP.X, pntMin.X) & buCompare5.EQ(lastP.Y, pntMin.Y)))
			{
				if (!(buCompare5.EQ(lastP.X, pntMin.X) & buCompare5.EQ(lastP.Y, pntMax.Y)))
				{
					PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
					lastP = PLFill[PLFill.Count - 1];
				}
				else
				{
					PLFill.Add(new Point3D(pntMin.X, pntMin.Y, lastP.Z));
					lastP = PLFill[PLFill.Count - 1];
				}
			}
			else
			{
				PLFill.Add(new Point3D(pntMax.X, pntMin.Y, lastP.Z));
				lastP = PLFill[PLFill.Count - 1];
			}
			if (buCompare5.EQ(lastP.X, firstP.X) | buCompare5.EQ(lastP.Y, firstP.Y))
			{
				if (isLast)
				{
					PLFill.Add(buVector5.ToPoint3D(PLFill[0]));
				}
				i = 5;
			}
		}
	}

	public void SawCornerCurvature(List<Point3D> refPoints, List<Point3D> CurvePoints, int Degree, MarbleSawCornerCleanMode CornerMode, double Deviation, ref List<Point3D> fillPoints)
	{
		if (!(CornerMode == MarbleSawCornerCleanMode.FullCurvature || CornerMode == MarbleSawCornerCleanMode.FitCircular))
		{
			switch (CornerMode)
			{
			case MarbleSawCornerCleanMode.FitArc:
			{
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				buCall.buVector5_0.BoxSizeCalculate(CurvePoints, ref MinPoint, ref MidPoint, ref MaxPoint);
				List<Point3D> calcPoints = new List<Point3D>();
				buCall.buVector5_0.CurveCornerFromBoxSize(CurvePoints[0], CurvePoints[CurvePoints.Count - 1], MinPoint, MaxPoint, Degree, Deviation, ClockDirectionType.CCW, ref calcPoints);
				if (calcPoints.Count < 2)
				{
					fillPoints.AddRange(CurvePoints);
				}
				else
				{
					fillPoints.AddRange(calcPoints);
				}
				break;
			}
			case MarbleSawCornerCleanMode.FitLine:
			{
				Line line = new Line(CurvePoints[0], CurvePoints[CurvePoints.Count - 1]);
				LinearPath c = new LinearPath(refPoints);
				Point3D[] array = line.IntersectWith(c);
				if (array.Length != 0)
				{
					if (CurvePoints.Count < 3)
					{
						if (!(Degree == 0 || Degree == 1))
						{
							Curve curve = new Curve(Degree, CurvePoints);
							curve.Regen(Deviation);
							fillPoints.AddRange(curve.Vertices.ToArray());
						}
						else
						{
							fillPoints.AddRange(CurvePoints);
						}
					}
					else
					{
						int index = Convert.ToInt32((double)CurvePoints.Count / 2.0);
						fillPoints.Add(buVector5.ToPoint3D(CurvePoints[0]));
						fillPoints.Add(buVector5.ToPoint3D(CurvePoints[index]));
						fillPoints.Add(buVector5.ToPoint3D(CurvePoints[CurvePoints.Count - 1]));
					}
				}
				else
				{
					fillPoints.Add(buVector5.ToPoint3D(CurvePoints[0]));
					fillPoints.Add(buVector5.ToPoint3D(CurvePoints[CurvePoints.Count - 1]));
				}
				break;
			}
			}
		}
		else if (!(Degree == 0 || Degree == 1))
		{
			Curve curve2 = new Curve(Degree, CurvePoints);
			curve2.Regen(Deviation);
			fillPoints.AddRange(curve2.Vertices.ToArray());
		}
		else
		{
			fillPoints.AddRange(CurvePoints);
		}
	}

	public void SawCornerLine(Entity rectBox, List<Point3D> PLRef, double XYStep, double XYSafeDistance, double ZPos, bool isReverse, int CntZ, ref List<Point3DList> PLLFill)
	{
		List<Entity> entHat = new List<Entity>();
		List<Entity> entitiesLine = new List<Entity>();
		List<Entity> entitiesLine2 = new List<Entity>();
		List<Point3D> list = new List<Point3D>();
		Point3DList point3DList = null;
		Point3D EndPnt = new Point3D();
		int num = 0;
		MarbleSawCalcParameters marbleSawCalcParameters = null;
		buCall.buVector5_0.Hatch(rectBox, ZPos, 45.0, XYStep, ref entHat);
		buCall.buVector5_0.GetHatchLines(entHat, 45.0, XYStep, ref entitiesLine);
		entHat.Clear();
		buCall.buVector5_0.Hatch(rectBox, ZPos, 135.0, XYStep, ref entHat);
		buCall.buVector5_0.GetHatchLines(entHat, 135.0, XYStep, ref entitiesLine2);
		LinearPath c = new LinearPath(PLRef);
		if (isReverse)
		{
			list = new List<Point3D>();
			num = 0;
			for (int i = 0; i <= entitiesLine.Count - 1; i++)
			{
				Point3D[] array = ((ICurve)entitiesLine[i]).IntersectWith(c);
				if (array.Length == 0)
				{
					if (num % 2 != 0)
					{
						list.Add(buVector5.ToPoint3D(entitiesLine[i].Vertices[entitiesLine[i].Vertices.Length - 1]));
						list.Add(buVector5.ToPoint3D(entitiesLine[i].Vertices[0]));
					}
					else
					{
						list.Add(buVector5.ToPoint3D(entitiesLine[i].Vertices[0]));
						list.Add(buVector5.ToPoint3D(entitiesLine[i].Vertices[entitiesLine[i].Vertices.Length - 1]));
					}
				}
				else
				{
					i = entitiesLine.Count;
				}
				num++;
			}
			point3DList = new Point3DList();
			buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, -45.0, ref EndPnt);
			list.Insert(0, EndPnt);
			buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, -45.0, ref EndPnt);
			list.Add(EndPnt);
			point3DList.Points.AddRange(list);
			marbleSawCalcParameters = new MarbleSawCalcParameters();
			marbleSawCalcParameters.DevideLength = 0.0;
			marbleSawCalcParameters.ShiftPoint = null;
			marbleSawCalcParameters.ShiftEnable = false;
			marbleSawCalcParameters.SplineEnable = false;
			marbleSawCalcParameters.ConstantAngle = 45.0;
			marbleSawCalcParameters.UseContantAngle = true;
			point3DList.Settings = marbleSawCalcParameters;
			PLLFill.Add(point3DList);
			list = new List<Point3D>();
			num = 0;
			entitiesLine2.Reverse();
			for (int j = 0; j <= entitiesLine2.Count - 1; j++)
			{
				Point3D[] array2 = ((ICurve)entitiesLine2[j]).IntersectWith(c);
				if (array2.Length == 0)
				{
					if (num % 2 != 0)
					{
						list.Add(buVector5.ToPoint3D(entitiesLine2[j].Vertices[entitiesLine2[j].Vertices.Length - 1]));
						list.Add(buVector5.ToPoint3D(entitiesLine2[j].Vertices[0]));
					}
					else
					{
						list.Add(buVector5.ToPoint3D(entitiesLine2[j].Vertices[0]));
						list.Add(buVector5.ToPoint3D(entitiesLine2[j].Vertices[entitiesLine2[j].Vertices.Length - 1]));
					}
				}
				else
				{
					j = entitiesLine.Count;
				}
				num++;
			}
			point3DList = new Point3DList();
			buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 45.0, ref EndPnt);
			list.Insert(0, EndPnt);
			buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 45.0, ref EndPnt);
			list.Add(EndPnt);
			point3DList.Points.AddRange(list);
			marbleSawCalcParameters = new MarbleSawCalcParameters();
			marbleSawCalcParameters.DevideLength = 0.0;
			marbleSawCalcParameters.ShiftPoint = null;
			marbleSawCalcParameters.ShiftEnable = false;
			marbleSawCalcParameters.SplineEnable = false;
			marbleSawCalcParameters.ConstantAngle = 135.0;
			marbleSawCalcParameters.UseContantAngle = true;
			point3DList.Settings = marbleSawCalcParameters;
			PLLFill.Add(point3DList);
			entitiesLine.Reverse();
			list = new List<Point3D>();
			num = 0;
			for (int k = 0; k <= entitiesLine.Count - 1; k++)
			{
				Point3D[] array3 = ((ICurve)entitiesLine[k]).IntersectWith(c);
				if (array3.Length == 0)
				{
					if (num % 2 != 0)
					{
						list.Add(buVector5.ToPoint3D(entitiesLine[k].Vertices[entitiesLine[k].Vertices.Length - 1]));
						list.Add(buVector5.ToPoint3D(entitiesLine[k].Vertices[0]));
					}
					else
					{
						list.Add(buVector5.ToPoint3D(entitiesLine[k].Vertices[0]));
						list.Add(buVector5.ToPoint3D(entitiesLine[k].Vertices[entitiesLine[k].Vertices.Length - 1]));
					}
				}
				else
				{
					k = entitiesLine.Count;
				}
				num++;
			}
			point3DList = new Point3DList();
			buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 135.0, ref EndPnt);
			list.Insert(0, EndPnt);
			buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 135.0, ref EndPnt);
			list.Add(EndPnt);
			point3DList.Points.AddRange(list);
			marbleSawCalcParameters = new MarbleSawCalcParameters();
			marbleSawCalcParameters.DevideLength = 0.0;
			marbleSawCalcParameters.ShiftPoint = null;
			marbleSawCalcParameters.ShiftEnable = false;
			marbleSawCalcParameters.SplineEnable = false;
			marbleSawCalcParameters.ConstantAngle = 225.0;
			marbleSawCalcParameters.UseContantAngle = true;
			point3DList.Settings = marbleSawCalcParameters;
			PLLFill.Add(point3DList);
			entitiesLine2.Reverse();
			list = new List<Point3D>();
			num = 0;
			for (int l = 0; l <= entitiesLine2.Count - 1; l++)
			{
				Point3D[] array4 = ((ICurve)entitiesLine2[l]).IntersectWith(c);
				if (array4.Length == 0)
				{
					if (num % 2 != 0)
					{
						list.Add(buVector5.ToPoint3D(entitiesLine2[l].Vertices[entitiesLine2[l].Vertices.Length - 1]));
						list.Add(buVector5.ToPoint3D(entitiesLine2[l].Vertices[0]));
					}
					else
					{
						list.Add(buVector5.ToPoint3D(entitiesLine2[l].Vertices[0]));
						list.Add(buVector5.ToPoint3D(entitiesLine2[l].Vertices[entitiesLine2[l].Vertices.Length - 1]));
					}
				}
				else
				{
					l = entitiesLine.Count;
				}
				num++;
			}
			point3DList = new Point3DList();
			buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 225.0, ref EndPnt);
			list.Insert(0, EndPnt);
			buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 225.0, ref EndPnt);
			list.Add(EndPnt);
			point3DList.Points.AddRange(list);
			marbleSawCalcParameters = new MarbleSawCalcParameters();
			marbleSawCalcParameters.DevideLength = 0.0;
			marbleSawCalcParameters.ShiftPoint = null;
			marbleSawCalcParameters.ShiftEnable = false;
			marbleSawCalcParameters.SplineEnable = false;
			marbleSawCalcParameters.ConstantAngle = 315.0;
			marbleSawCalcParameters.UseContantAngle = true;
			point3DList.Settings = marbleSawCalcParameters;
			PLLFill.Add(point3DList);
			return;
		}
		list = new List<Point3D>();
		num = 0;
		for (int m = 0; m <= entitiesLine2.Count - 1; m++)
		{
			Point3D[] array5 = ((ICurve)entitiesLine2[m]).IntersectWith(c);
			if (array5.Length == 0)
			{
				if (num % 2 != 0)
				{
					list.Add(buVector5.ToPoint3D(entitiesLine2[m].Vertices[entitiesLine2[m].Vertices.Length - 1]));
					list.Add(buVector5.ToPoint3D(entitiesLine2[m].Vertices[0]));
				}
				else
				{
					list.Add(buVector5.ToPoint3D(entitiesLine2[m].Vertices[0]));
					list.Add(buVector5.ToPoint3D(entitiesLine2[m].Vertices[entitiesLine2[m].Vertices.Length - 1]));
				}
			}
			else
			{
				m = entitiesLine.Count;
			}
			num++;
		}
		point3DList = new Point3DList();
		buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 225.0, ref EndPnt);
		list.Insert(0, EndPnt);
		buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 225.0, ref EndPnt);
		list.Add(EndPnt);
		point3DList.Points.AddRange(list);
		marbleSawCalcParameters = new MarbleSawCalcParameters();
		marbleSawCalcParameters.DevideLength = 0.0;
		marbleSawCalcParameters.ShiftPoint = null;
		marbleSawCalcParameters.ShiftEnable = false;
		marbleSawCalcParameters.SplineEnable = false;
		marbleSawCalcParameters.ConstantAngle = 315.0;
		marbleSawCalcParameters.UseContantAngle = true;
		if (CntZ == 0)
		{
			marbleSawCalcParameters.isFirst = true;
		}
		point3DList.Settings = marbleSawCalcParameters;
		PLLFill.Add(point3DList);
		entitiesLine.Reverse();
		list = new List<Point3D>();
		num = 0;
		for (int n = 0; n <= entitiesLine.Count - 1; n++)
		{
			Point3D[] array6 = ((ICurve)entitiesLine[n]).IntersectWith(c);
			if (array6.Length == 0)
			{
				if (num % 2 != 0)
				{
					list.Add(buVector5.ToPoint3D(entitiesLine[n].Vertices[entitiesLine[n].Vertices.Length - 1]));
					list.Add(buVector5.ToPoint3D(entitiesLine[n].Vertices[0]));
				}
				else
				{
					list.Add(buVector5.ToPoint3D(entitiesLine[n].Vertices[0]));
					list.Add(buVector5.ToPoint3D(entitiesLine[n].Vertices[entitiesLine[n].Vertices.Length - 1]));
				}
			}
			else
			{
				n = entitiesLine.Count;
			}
			num++;
		}
		point3DList = new Point3DList();
		buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 135.0, ref EndPnt);
		list.Insert(0, EndPnt);
		buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 135.0, ref EndPnt);
		list.Add(EndPnt);
		point3DList.Points.AddRange(list);
		marbleSawCalcParameters = new MarbleSawCalcParameters();
		marbleSawCalcParameters.DevideLength = 0.0;
		marbleSawCalcParameters.ShiftPoint = null;
		marbleSawCalcParameters.ShiftEnable = false;
		marbleSawCalcParameters.SplineEnable = false;
		marbleSawCalcParameters.ConstantAngle = 225.0;
		marbleSawCalcParameters.UseContantAngle = true;
		point3DList.Settings = marbleSawCalcParameters;
		PLLFill.Add(point3DList);
		list = new List<Point3D>();
		num = 0;
		entitiesLine2.Reverse();
		for (int num2 = 0; num2 <= entitiesLine2.Count - 1; num2++)
		{
			Point3D[] array7 = ((ICurve)entitiesLine2[num2]).IntersectWith(c);
			if (array7.Length == 0)
			{
				if (num % 2 != 0)
				{
					list.Add(buVector5.ToPoint3D(entitiesLine2[num2].Vertices[entitiesLine2[num2].Vertices.Length - 1]));
					list.Add(buVector5.ToPoint3D(entitiesLine2[num2].Vertices[0]));
				}
				else
				{
					list.Add(buVector5.ToPoint3D(entitiesLine2[num2].Vertices[0]));
					list.Add(buVector5.ToPoint3D(entitiesLine2[num2].Vertices[entitiesLine2[num2].Vertices.Length - 1]));
				}
			}
			else
			{
				num2 = entitiesLine.Count;
			}
			num++;
		}
		point3DList = new Point3DList();
		buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, 45.0, ref EndPnt);
		list.Insert(0, EndPnt);
		buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, 45.0, ref EndPnt);
		list.Add(EndPnt);
		point3DList.Points.AddRange(list);
		marbleSawCalcParameters = new MarbleSawCalcParameters();
		marbleSawCalcParameters.DevideLength = 0.0;
		marbleSawCalcParameters.ShiftPoint = null;
		marbleSawCalcParameters.ShiftEnable = false;
		marbleSawCalcParameters.SplineEnable = false;
		marbleSawCalcParameters.ConstantAngle = 135.0;
		marbleSawCalcParameters.UseContantAngle = true;
		point3DList.Settings = marbleSawCalcParameters;
		PLLFill.Add(point3DList);
		entitiesLine.Reverse();
		list = new List<Point3D>();
		num = 0;
		for (int num3 = 0; num3 <= entitiesLine.Count - 1; num3++)
		{
			Point3D[] array8 = ((ICurve)entitiesLine[num3]).IntersectWith(c);
			if (array8.Length == 0)
			{
				if (num % 2 != 0)
				{
					list.Add(buVector5.ToPoint3D(entitiesLine[num3].Vertices[entitiesLine[num3].Vertices.Length - 1]));
					list.Add(buVector5.ToPoint3D(entitiesLine[num3].Vertices[0]));
				}
				else
				{
					list.Add(buVector5.ToPoint3D(entitiesLine[num3].Vertices[0]));
					list.Add(buVector5.ToPoint3D(entitiesLine[num3].Vertices[entitiesLine[num3].Vertices.Length - 1]));
				}
			}
			else
			{
				num3 = entitiesLine.Count;
			}
			num++;
		}
		point3DList = new Point3DList();
		buCall.buVector5_0.LineWithLengthAndAngle(list[0], XYStep + XYSafeDistance, -45.0, ref EndPnt);
		list.Insert(0, EndPnt);
		buCall.buVector5_0.LineWithLengthAndAngle(list[list.Count - 1], XYStep * (double)num + XYSafeDistance, -45.0, ref EndPnt);
		list.Add(EndPnt);
		point3DList.Points.AddRange(list);
		marbleSawCalcParameters = new MarbleSawCalcParameters();
		marbleSawCalcParameters.DevideLength = 0.0;
		marbleSawCalcParameters.ShiftPoint = null;
		marbleSawCalcParameters.ShiftEnable = false;
		marbleSawCalcParameters.SplineEnable = false;
		marbleSawCalcParameters.ConstantAngle = 45.0;
		marbleSawCalcParameters.UseContantAngle = true;
		point3DList.Settings = marbleSawCalcParameters;
		PLLFill.Add(point3DList);
	}

	public bool isVertical(double AngleC)
	{
		if (!(AngleC >= 45.0 && AngleC <= 135.0))
		{
			if (!(AngleC >= 225.0 && AngleC <= 315.0))
			{
				return false;
			}
			return true;
		}
		return true;
	}

	public bool isCAngleSuitable(double CAngle, bool isHorizontal)
	{
		try
		{
			if (!isHorizontal)
			{
				if (CAngle >= -135.0 && CAngle <= -45.0)
				{
					return true;
				}
				if (CAngle >= 45.0 && CAngle <= 135.0)
				{
					return true;
				}
				if (CAngle >= 225.0 && CAngle <= 315.0)
				{
					return true;
				}
			}
			else
			{
				if (CAngle >= -45.0 && CAngle <= 45.0)
				{
					return true;
				}
				if (CAngle >= 135.0 && CAngle <= 225.0)
				{
					return true;
				}
			}
			return false;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return false;
		}
	}

	public void GetIDs(MarbleJob Job, ref int ItemID, ref int MarbleCamID)
	{
		GetCamID(Job, ref MarbleCamID);
		GetItemID(Job, ref ItemID);
	}

	public void GetItemID(MarbleJob Job, ref int ItemID)
	{
		List<int> List = new List<int>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			if (Job.Items[i].ID >= 0)
			{
				buNumeric5.AddValueToList(Job.Items[i].ID, ref List);
			}
		}
		if (List.Count <= 0)
		{
			ItemID = 1;
			return;
		}
		buNumeric5.SortList(SortDirectionType.Lower, ref List);
		ItemID = List[List.Count - 1] + 1;
	}

	public void GetCamID(MarbleJob Job, ref int MarbleCamID)
	{
		List<int> RefList = new List<int>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			for (int j = 0; j <= Job.Items[i].CamList.Count - 1; j++)
			{
				if (Job.Items[i].CamList[j].CamID >= 0)
				{
					buNumeric5.AddValueToList(Job.Items[i].CamList[j].CamID, ref RefList);
				}
			}
		}
		if (RefList.Count <= 0)
		{
			MarbleCamID = MarbleTempVars.MarbleCamID;
			MarbleTempVars.MarbleCamID++;
		}
		else
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref RefList);
			MarbleCamID = RefList[RefList.Count - 1] + 1;
			MarbleTempVars.MarbleCamID++;
		}
	}

	public void GetCamID(MarbleJob Job, List<MarbleItemCam> CamList, ref int MarbleCamID)
	{
		List<int> List = new List<int>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			for (int j = 0; j <= Job.Items[i].CamList.Count - 1; j++)
			{
				if (Job.Items[i].CamList[j].CamID >= 0)
				{
					buNumeric5.AddValueToList(Job.Items[i].CamList[j].CamID, ref List);
				}
			}
		}
		for (int k = 0; k <= CamList.Count - 1; k++)
		{
			buNumeric5.AddValueToList(CamList[k].CamID, ref List);
		}
		if (List.Count <= 0)
		{
			MarbleCamID = MarbleTempVars.MarbleCamID;
			MarbleTempVars.MarbleCamID++;
		}
		else
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref List);
			MarbleCamID = List[List.Count - 1] + 1;
			MarbleTempVars.MarbleCamID++;
		}
	}

	public void GetCamID(List<MarbleItemCam> CamList, ref int MarbleCamID)
	{
		List<int> List = new List<int>();
		for (int i = 0; i <= CamList.Count - 1; i++)
		{
			if (CamList[i].CamID >= 0)
			{
				buNumeric5.AddValueToList(CamList[i].CamID, ref List);
			}
		}
		if (List.Count <= 0)
		{
			MarbleCamID = MarbleTempVars.MarbleCamID;
			MarbleTempVars.MarbleCamID++;
		}
		else
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref List);
			MarbleCamID = List[List.Count - 1] + 1;
			MarbleTempVars.MarbleCamID++;
		}
	}

	public void GetEdgeID(MarbleJob Job, ref int EdgeID)
	{
		List<int> RefList = new List<int>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			for (int j = 0; j <= Job.Items[i].Edges.Count - 1; j++)
			{
				if (Job.Items[i].Edges[j].EdgeID >= 0)
				{
					buNumeric5.AddValueToList(Job.Items[i].Edges[j].EdgeID, ref RefList);
				}
			}
		}
		if (RefList.Count <= 0)
		{
			EdgeID = MarbleTempVars.MarbleEdgeID;
			MarbleTempVars.MarbleEdgeID++;
		}
		else
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref RefList);
			EdgeID = RefList[RefList.Count - 1] + 1;
			MarbleTempVars.MarbleEdgeID++;
		}
	}

	public void GetStripID(MarbleJob Job, ref int StripID)
	{
		List<int> RefList = new List<int>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			for (int j = 0; j <= Job.Items[i].Edges.Count - 1; j++)
			{
				if (Job.Items[i].Edges[j].Slat != null && Job.Items[i].Edges[j].Slat.DataSlat.StripID >= 0)
				{
					buNumeric5.AddValueToList(Job.Items[i].Edges[j].Slat.DataSlat.StripID, ref RefList);
				}
			}
		}
		if (RefList.Count <= 0)
		{
			StripID = MarbleTempVars.MarbleStripID;
			MarbleTempVars.MarbleStripID++;
		}
		else
		{
			buNumeric5.SortList(SortDirectionType.Lower, ref RefList);
			StripID = RefList[RefList.Count - 1] + 1;
			MarbleTempVars.MarbleStripID++;
		}
	}

	public void GetJobBoxSize(ref MarbleJob Job)
	{
		List<Point3D> list = new List<Point3D>();
		for (int i = 0; i <= Job.Items.Count - 1; i++)
		{
			list.Add(buVector5.ToPoint3D(Job.Items[i].SizeItem.MinPoint));
			list.Add(buVector5.ToPoint3D(Job.Items[i].SizeItem.MaxPoint));
		}
		buCall.buVector5_0.BoxSizeCalculate(list, ref Job.Material.BoxMinPoint, ref Job.Material.BoxMaxPoint);
		Job.Material.Size.Width = Job.Material.BoxMaxPoint.X - Job.Material.BoxMinPoint.X;
		Job.Material.Size.Height = Job.Material.BoxMaxPoint.Y - Job.Material.BoxMinPoint.Y;
		Job.Material.Size.Depth = Job.Material.BoxMaxPoint.Z - Job.Material.BoxMinPoint.Z;
	}

	public void AnalyzeImportEntities(ref List<buEntity> refEntities)
	{
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(refEntities, ref copiedEntities);
		refEntities.Clear();
		for (int i = 0; i <= copiedEntities.Count - 1; i++)
		{
			if (!(copiedEntities[i] is buLinearPath))
			{
				if (!(copiedEntities[i] is buCompositeCurve))
				{
					if ((copiedEntities[i] is buLine) | (copiedEntities[i] is buArc) | (copiedEntities[i] is buCircle) | (copiedEntities[i] is buEllipse) | (copiedEntities[i] is buCurve))
					{
						refEntities.Add(buEntity.Copy(copiedEntities[i]));
					}
					continue;
				}
				buCompositeCurve buCompositeCurve2 = copiedEntities[i] as buCompositeCurve;
				for (int j = 0; j <= buCompositeCurve2.CurveList.Count - 1; j++)
				{
					buEntity copiedEntity = null;
					buEntity.Copy(buCompositeCurve2.CurveList[j], ref copiedEntity);
					refEntities.Add(copiedEntity);
				}
			}
			else
			{
				for (int k = 1; k <= copiedEntities[i].Vertices.Count - 1; k++)
				{
					buLine item = new buLine(copiedEntities[i].Vertices[k - 1], copiedEntities[i].Vertices[k]);
					refEntities.Add(item);
				}
			}
		}
	}

	public void DevideProfileCutPoints(List<Point3D> refPoints, double MinZ, double DevideLength, double VerticalDevideLength, bool isCurveProfilie, bool isRough, ref List<Point3D> devidedPoints)
	{
		bool flag = false;
		Point3D point3D = new Point3D();
		for (int i = 0; i <= refPoints.Count - 1; i++)
		{
			if (refPoints[i].Z < MinZ && flag)
			{
				double num = MinZ - refPoints[i].Z;
				Point3D point3D2 = new Point3D();
				point3D2 = ((num > 0.1) ? new Point3D(refPoints[i].X, refPoints[i].Y, MinZ) : new Point3D(refPoints[i].X, refPoints[i].Y, refPoints[i].Z));
				double num2 = Point3D.Distance(point3D, point3D2);
				if (!(num2 > DevideLength))
				{
					devidedPoints.Add(buVector5.ToPoint3D(point3D2));
					point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
				}
				else
				{
					double value = buCall.buVector5_0.PointAngle(point3D2, point3D, Plane.YZ);
					if (!(buCompare5.EQ(value, 90.0, 0.5) | buCompare5.EQ(value, 270.0, 0.5)))
					{
						List<Point3D> PointsDevided = new List<Point3D>();
						buCall.buVector5_0.DevideLinePointsByLength(point3D, point3D2, DevideLength, ref PointsDevided);
						PointsDevided.RemoveAt(0);
						devidedPoints.AddRange(PointsDevided);
						point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
					}
					else
					{
						List<Point3D> PointsDevided2 = new List<Point3D>();
						buCall.buVector5_0.DevideLinePointsByLength(point3D, point3D2, VerticalDevideLength, ref PointsDevided2);
						PointsDevided2.RemoveAt(0);
						devidedPoints.AddRange(PointsDevided2);
						point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
						if ((i == 0 || i == 1) && isRough)
						{
							devidedPoints.Reverse();
						}
					}
				}
				flag = false;
			}
			if (refPoints[i].Z > MinZ && !flag)
			{
				double num3 = refPoints[i].Z - MinZ;
				if (num3 > 0.1 && !isCurveProfilie && devidedPoints.Count == 0)
				{
					devidedPoints.Add(new Point3D(refPoints[i].X, refPoints[i].Y, MinZ));
					point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
				}
				flag = true;
			}
			if (!flag)
			{
				continue;
			}
			if (devidedPoints.Count != 0)
			{
				double num4 = Point3D.Distance(point3D, refPoints[i]);
				if (!(num4 > DevideLength))
				{
					devidedPoints.Add(buVector5.ToPoint3D(refPoints[i]));
					point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
					continue;
				}
				double value2 = buCall.buVector5_0.PointAngle(refPoints[i], point3D, Plane.YZ);
				if (!(buCompare5.EQ(value2, 90.0, 0.5) | buCompare5.EQ(value2, 270.0, 0.5)))
				{
					List<Point3D> PointsDevided3 = new List<Point3D>();
					buCall.buVector5_0.DevideLinePointsByLength(point3D, refPoints[i], DevideLength, ref PointsDevided3);
					PointsDevided3.RemoveAt(0);
					devidedPoints.AddRange(PointsDevided3);
					point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
					continue;
				}
				List<Point3D> PointsDevided4 = new List<Point3D>();
				buCall.buVector5_0.DevideLinePointsByLength(point3D, refPoints[i], VerticalDevideLength, ref PointsDevided4);
				PointsDevided4.RemoveAt(0);
				devidedPoints.AddRange(PointsDevided4);
				point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
				if ((i == 0 || i == 1) && isRough)
				{
					devidedPoints.Reverse();
				}
			}
			else
			{
				devidedPoints.Add(buVector5.ToPoint3D(refPoints[i]));
				point3D = buVector5.ToPoint3D(devidedPoints[devidedPoints.Count - 1]);
			}
		}
	}

	public void MoveItem(ref MarbleItem Item, double dX, double dY, double dZ)
	{
		Item.BasePoint.X = Item.BasePoint.X + dX;
		Item.BasePoint.Y = Item.BasePoint.Y + dY;
		Item.BasePoint.Z = Item.BasePoint.Z + dZ;
		if (Item.ItemEntities.SolidEntity != null)
		{
			for (int i = 0; i <= Item.ItemEntities.SolidEntity.Count - 1; i++)
			{
				Item.ItemEntities.SolidEntity[i].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.TextEntities != null)
		{
			for (int j = 0; j <= Item.ItemEntities.TextEntities.Count - 1; j++)
			{
				Item.ItemEntities.TextEntities[j].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.DrawWireEntities != null)
		{
			for (int k = 0; k <= Item.ItemEntities.DrawWireEntities.Count - 1; k++)
			{
				Item.ItemEntities.DrawWireEntities[k].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.WireEntities != null)
		{
			for (int l = 0; l <= Item.ItemEntities.WireEntities.Count - 1; l++)
			{
				for (int m = 0; m <= Item.ItemEntities.WireEntities[l].Count - 1; m++)
				{
					Item.ItemEntities.WireEntities[l][m].Translate(dX, dY, dZ);
				}
			}
		}
		if (Item.ItemEntities.BaseEntities != null)
		{
			for (int n = 0; n <= Item.ItemEntities.BaseEntities.Count - 1; n++)
			{
				Item.ItemEntities.BaseEntities[n].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.SourceEntities != null)
		{
			for (int num = 0; num <= Item.ItemEntities.SourceEntities.Count - 1; num++)
			{
				Item.ItemEntities.SourceEntities[num].Translate(dX, dY, dZ);
			}
		}
		if (Item.EntGroup != null)
		{
			Item.EntGroup.Translate(dX, dY, dZ);
			if (Item.EntGroup.Outside != null && Item.EntGroup.Outside.Entities.Count > 0 && Item.EntGroup.Outside.pntMassCenter != null)
			{
				Item.EntGroup.Outside.pntMassCenter.X = Item.EntGroup.Outside.pntMassCenter.X + dX;
				Item.EntGroup.Outside.pntMassCenter.Y = Item.EntGroup.Outside.pntMassCenter.Y + dY;
				Item.EntGroup.Outside.pntMassCenter.Z = Item.EntGroup.Outside.pntMassCenter.Z + dZ;
			}
		}
		if (Item.ItemEntities.ConcaveEntities != null)
		{
			for (int num2 = 0; num2 <= Item.ItemEntities.ConcaveEntities.Count - 1; num2++)
			{
				for (int num3 = 0; num3 <= Item.ItemEntities.ConcaveEntities[num2].Count - 1; num3++)
				{
					Item.ItemEntities.ConcaveEntities[num2][num3].Translate(dX, dY, dZ);
				}
			}
		}
		if (Item.ItemEntities.ConvexEntities != null)
		{
			for (int num4 = 0; num4 <= Item.ItemEntities.ConvexEntities.Count - 1; num4++)
			{
				for (int num5 = 0; num5 <= Item.ItemEntities.ConvexEntities[num4].Count - 1; num5++)
				{
					Item.ItemEntities.ConvexEntities[num4][num5].Translate(dX, dY, dZ);
				}
			}
		}
		if (Item.ItemEntities.EdgeEntities != null)
		{
			for (int num6 = 0; num6 <= Item.ItemEntities.EdgeEntities.Count - 1; num6++)
			{
				Item.ItemEntities.EdgeEntities[num6].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.ExtensionEntities != null)
		{
			for (int num7 = 0; num7 <= Item.ItemEntities.ExtensionEntities.Count - 1; num7++)
			{
				Item.ItemEntities.ExtensionEntities[num7].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.EngravingEntities != null)
		{
			for (int num8 = 0; num8 <= Item.ItemEntities.EngravingEntities.Count - 1; num8++)
			{
				Item.ItemEntities.EngravingEntities[num8].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.BorderEntities != null)
		{
			for (int num9 = 0; num9 <= Item.ItemEntities.BorderEntities.Count - 1; num9++)
			{
				Item.ItemEntities.BorderEntities[num9].Translate(dX, dY, dZ);
			}
		}
		if (Item.ItemEntities.DrillEntities != null)
		{
			for (int num10 = 0; num10 <= Item.ItemEntities.DrillEntities.Count - 1; num10++)
			{
				Item.ItemEntities.DrillEntities[num10].Translate(dX, dY, dZ);
			}
		}
		for (int num11 = 0; num11 <= Item.Edges.Count - 1; num11++)
		{
			Item.Edges[num11].refEntity.Translate(dX, dY, dZ);
			Item.Edges[num11].drawEntity.Translate(dX, dY, dZ);
			if (Item.Edges[num11].Slat.Solid != null)
			{
				Item.Edges[num11].Slat.Solid.Translate(dX, dY, dZ);
			}
		}
		for (int num12 = 0; num12 <= Item.Collapses.Count - 1; num12++)
		{
			if (Item.Collapses[num12].entSolid != null)
			{
				Item.Collapses[num12].entSolid.Translate(dX, dY, dZ);
			}
			if (Item.Collapses[num12].refEntity != null)
			{
				for (int num13 = 0; num13 <= Item.Collapses[num12].refEntity.Count - 1; num13++)
				{
					Item.Collapses[num12].refEntity[num13].Translate(dX, dY, dZ);
				}
			}
			if (Item.Collapses[num12].ContourEntity != null)
			{
				for (int num14 = 0; num14 <= Item.Collapses[num12].ContourEntity.Count - 1; num14++)
				{
					Item.Collapses[num12].ContourEntity[num14].Translate(dX, dY, dZ);
				}
			}
		}
		if (Item.CamList != null && Item.CamList.Count > 0)
		{
			for (int num15 = 0; num15 <= Item.CamList.Count - 1; num15++)
			{
				Item.CamList[num15].isCamCalculated = false;
				if (Item.CamList[num15].CamBase != null)
				{
					for (int num16 = 0; num16 <= Item.CamList[num15].CamBase.EntitiesG0.Count - 1; num16++)
					{
						Item.CamList[num15].CamBase.EntitiesG0[num16].Translate(dX, dY, dZ);
					}
					for (int num17 = 0; num17 <= Item.CamList[num15].CamBase.EntitiesG1.Count - 1; num17++)
					{
						Item.CamList[num15].CamBase.EntitiesG1[num17].Translate(dX, dY, dZ);
					}
					for (int num18 = 0; num18 <= Item.CamList[num15].CamBase.EntitiesLeave.Count - 1; num18++)
					{
						Item.CamList[num15].CamBase.EntitiesLeave[num18].Translate(dX, dY, dZ);
					}
					for (int num19 = 0; num19 <= Item.CamList[num15].CamBase.EntitiesPlunge.Count - 1; num19++)
					{
						Item.CamList[num15].CamBase.EntitiesPlunge[num19].Translate(dX, dY, dZ);
					}
					for (int num20 = 0; num20 <= Item.CamList[num15].CamBase.EntitiesLeadIn.Count - 1; num20++)
					{
						Item.CamList[num15].CamBase.EntitiesLeadIn[num20].Translate(dX, dY, dZ);
					}
					for (int num21 = 0; num21 <= Item.CamList[num15].CamBase.EntitiesLeadOut.Count - 1; num21++)
					{
						Item.CamList[num15].CamBase.EntitiesLeadOut[num21].Translate(dX, dY, dZ);
					}
				}
				if (Item.CamList[num15].WireEntities != null)
				{
					for (int num22 = 0; num22 <= Item.CamList[num15].WireEntities.Count - 1; num22++)
					{
						for (int num23 = 0; num23 <= Item.CamList[num15].WireEntities[num22].Count - 1; num23++)
						{
							Item.CamList[num15].WireEntities[num22][num23].Translate(dX, dY, dZ);
						}
					}
				}
				if (Item.CamList[num15].EntityList != null)
				{
					Item.CamList[num15].EntityList.Translate(dX, dY, dZ);
					if (Item.CamList[num15].EntityList.Entities != null && Item.CamList[num15].EntityList.Entities.Count > 0 && Item.CamList[num15].EntityList.pntMassCenter != null)
					{
						Item.CamList[num15].EntityList.pntMassCenter.X = Item.CamList[num15].EntityList.pntMassCenter.X + dX;
						Item.CamList[num15].EntityList.pntMassCenter.Y = Item.CamList[num15].EntityList.pntMassCenter.Y + dY;
						Item.CamList[num15].EntityList.pntMassCenter.Z = Item.CamList[num15].EntityList.pntMassCenter.Z + dZ;
					}
				}
				if (Item.CamList[num15].WireAuxEntities != null)
				{
					for (int num24 = 0; num24 <= Item.CamList[num15].WireAuxEntities.Count - 1; num24++)
					{
						for (int num25 = 0; num25 <= Item.CamList[num15].WireAuxEntities[num24].Count - 1; num25++)
						{
							Item.CamList[num15].WireAuxEntities[num24][num25].Translate(dX, dY, dZ);
						}
					}
				}
				if (Item.CamList[num15].ConcaveEntities != null)
				{
					for (int num26 = 0; num26 <= Item.CamList[num15].ConcaveEntities.Count - 1; num26++)
					{
						for (int num27 = 0; num27 <= Item.CamList[num15].ConcaveEntities[num26].Count - 1; num27++)
						{
							Item.CamList[num15].ConcaveEntities[num26][num27].Translate(dX, dY, dZ);
						}
					}
				}
				if (Item.CamList[num15].ConvexEntities != null)
				{
					for (int num28 = 0; num28 <= Item.CamList[num15].ConvexEntities.Count - 1; num28++)
					{
						for (int num29 = 0; num29 <= Item.CamList[num15].ConvexEntities[num28].Count - 1; num29++)
						{
							Item.CamList[num15].ConvexEntities[num28][num29].Translate(dX, dY, dZ);
						}
					}
				}
				if (Item.CamList[num15].DrillEntities != null)
				{
					for (int num30 = 0; num30 <= Item.CamList[num15].DrillEntities.Count - 1; num30++)
					{
						Item.CamList[num15].DrillEntities[num30].Translate(dX, dY, dZ);
					}
				}
			}
		}
		Item.SizeItem.MinPoint.X = Item.SizeItem.MinPoint.X + dX;
		Item.SizeItem.MinPoint.Y = Item.SizeItem.MinPoint.Y + dY;
		Item.SizeItem.MidPoint.X = Item.SizeItem.MidPoint.X + dX;
		Item.SizeItem.MidPoint.Y = Item.SizeItem.MidPoint.Y + dY;
		Item.SizeItem.MaxPoint.X = Item.SizeItem.MaxPoint.X + dX;
		Item.SizeItem.MaxPoint.Y = Item.SizeItem.MaxPoint.Y + dY;
	}

	public void RotateItem(ref MarbleItem Item, double Rotation, Point3D pointRotate)
	{
		if (Item.ItemEntities.SolidEntity != null)
		{
			for (int i = 0; i <= Item.ItemEntities.SolidEntity.Count - 1; i++)
			{
				Item.ItemEntities.SolidEntity[i].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.TextEntities != null)
		{
			for (int j = 0; j <= Item.ItemEntities.TextEntities.Count - 1; j++)
			{
				Item.ItemEntities.TextEntities[j].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.DrawWireEntities != null)
		{
			for (int k = 0; k <= Item.ItemEntities.DrawWireEntities.Count - 1; k++)
			{
				Item.ItemEntities.DrawWireEntities[k].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.WireEntities != null)
		{
			for (int l = 0; l <= Item.ItemEntities.WireEntities.Count - 1; l++)
			{
				for (int m = 0; m <= Item.ItemEntities.WireEntities[l].Count - 1; m++)
				{
					Item.ItemEntities.WireEntities[l][m].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
				}
			}
		}
		if (Item.ItemEntities.BaseEntities != null)
		{
			for (int n = 0; n <= Item.ItemEntities.BaseEntities.Count - 1; n++)
			{
				Item.ItemEntities.BaseEntities[n].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.SourceEntities != null)
		{
			for (int num = 0; num <= Item.ItemEntities.SourceEntities.Count - 1; num++)
			{
				Item.ItemEntities.SourceEntities[num].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.EntGroup != null)
		{
			Item.EntGroup.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			if (Item.EntGroup.Outside != null && Item.EntGroup.Outside.Entities.Count > 0 && Item.EntGroup.Outside.pntMassCenter != null)
			{
				buCall.buVector5_0.Rotate(pointRotate, Rotation, Plane.XY, ref Item.EntGroup.Outside.pntMassCenter);
			}
		}
		if (Item.ItemEntities.ConcaveEntities != null)
		{
			for (int num2 = 0; num2 <= Item.ItemEntities.ConcaveEntities.Count - 1; num2++)
			{
				for (int num3 = 0; num3 <= Item.ItemEntities.ConcaveEntities[num2].Count - 1; num3++)
				{
					Item.ItemEntities.ConcaveEntities[num2][num3].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
				}
			}
		}
		if (Item.ItemEntities.ConvexEntities != null)
		{
			for (int num4 = 0; num4 <= Item.ItemEntities.ConvexEntities.Count - 1; num4++)
			{
				for (int num5 = 0; num5 <= Item.ItemEntities.ConvexEntities[num4].Count - 1; num5++)
				{
					Item.ItemEntities.ConvexEntities[num4][num5].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
				}
			}
		}
		if (Item.ItemEntities.EdgeEntities != null)
		{
			for (int num6 = 0; num6 <= Item.ItemEntities.EdgeEntities.Count - 1; num6++)
			{
				Item.ItemEntities.EdgeEntities[num6].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.ExtensionEntities != null)
		{
			for (int num7 = 0; num7 <= Item.ItemEntities.ExtensionEntities.Count - 1; num7++)
			{
				Item.ItemEntities.ExtensionEntities[num7].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.EngravingEntities != null)
		{
			for (int num8 = 0; num8 <= Item.ItemEntities.EngravingEntities.Count - 1; num8++)
			{
				Item.ItemEntities.EngravingEntities[num8].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.BorderEntities != null)
		{
			for (int num9 = 0; num9 <= Item.ItemEntities.BorderEntities.Count - 1; num9++)
			{
				Item.ItemEntities.BorderEntities[num9].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		if (Item.ItemEntities.DrillEntities != null)
		{
			for (int num10 = 0; num10 <= Item.ItemEntities.DrillEntities.Count - 1; num10++)
			{
				Item.ItemEntities.DrillEntities[num10].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		for (int num11 = 0; num11 <= Item.Edges.Count - 1; num11++)
		{
			Item.Edges[num11].refEntity.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			Item.Edges[num11].drawEntity.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			if (Item.Edges[num11].Slat.Solid != null)
			{
				Item.Edges[num11].Slat.Solid.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
			}
		}
		for (int num12 = 0; num12 <= Item.Collapses.Count - 1; num12++)
		{
			if (Item.Collapses[num12].entSolid != null)
			{
				Item.Collapses[num12].entSolid.Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
			}
			if (Item.Collapses[num12].refEntity != null)
			{
				for (int num13 = 0; num13 <= Item.Collapses[num12].refEntity.Count - 1; num13++)
				{
					Item.Collapses[num12].refEntity[num13].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
				}
			}
			if (Item.Collapses[num12].ContourEntity != null)
			{
				for (int num14 = 0; num14 <= Item.Collapses[num12].ContourEntity.Count - 1; num14++)
				{
					Item.Collapses[num12].ContourEntity[num14].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
				}
			}
		}
		if (Item.CamList != null && Item.CamList.Count > 0)
		{
			for (int num15 = 0; num15 <= Item.CamList.Count - 1; num15++)
			{
				Item.CamList[num15].isCamCalculated = false;
				if (Item.CamList[num15].CamBase != null)
				{
					for (int num16 = 0; num16 <= Item.CamList[num15].CamBase.EntitiesG0.Count - 1; num16++)
					{
						Item.CamList[num15].CamBase.EntitiesG0[num16].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
					for (int num17 = 0; num17 <= Item.CamList[num15].CamBase.EntitiesG1.Count - 1; num17++)
					{
						Item.CamList[num15].CamBase.EntitiesG1[num17].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
					for (int num18 = 0; num18 <= Item.CamList[num15].CamBase.EntitiesLeave.Count - 1; num18++)
					{
						Item.CamList[num15].CamBase.EntitiesLeave[num18].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
					for (int num19 = 0; num19 <= Item.CamList[num15].CamBase.EntitiesPlunge.Count - 1; num19++)
					{
						Item.CamList[num15].CamBase.EntitiesPlunge[num19].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
					for (int num20 = 0; num20 <= Item.CamList[num15].CamBase.EntitiesLeadIn.Count - 1; num20++)
					{
						Item.CamList[num15].CamBase.EntitiesLeadIn[num20].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
					for (int num21 = 0; num21 <= Item.CamList[num15].CamBase.EntitiesLeadOut.Count - 1; num21++)
					{
						Item.CamList[num15].CamBase.EntitiesLeadOut[num21].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
				}
				if (Item.CamList[num15].WireEntities != null)
				{
					for (int num22 = 0; num22 <= Item.CamList[num15].WireEntities.Count - 1; num22++)
					{
						for (int num23 = 0; num23 <= Item.CamList[num15].WireEntities[num22].Count - 1; num23++)
						{
							Item.CamList[num15].WireEntities[num22][num23].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
						}
					}
				}
				if (Item.CamList[num15].EntityList != null)
				{
					Item.CamList[num15].EntityList.Rotate(Rotation, Vector3D.AxisZ, pointRotate);
					if (Item.CamList[num15].EntityList.Entities != null && Item.CamList[num15].EntityList.Entities.Count > 0 && Item.CamList[num15].EntityList.pntMassCenter != null)
					{
						buCall.buVector5_0.Rotate(pointRotate, Rotation, Plane.XY, ref Item.CamList[num15].EntityList.pntMassCenter);
					}
				}
				if (Item.CamList[num15].WireAuxEntities != null)
				{
					for (int num24 = 0; num24 <= Item.CamList[num15].WireAuxEntities.Count - 1; num24++)
					{
						for (int num25 = 0; num25 <= Item.CamList[num15].WireAuxEntities[num24].Count - 1; num25++)
						{
							Item.CamList[num15].WireAuxEntities[num24][num25].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
						}
					}
				}
				if (Item.CamList[num15].ConcaveEntities != null)
				{
					for (int num26 = 0; num26 <= Item.CamList[num15].ConcaveEntities.Count - 1; num26++)
					{
						for (int num27 = 0; num27 <= Item.CamList[num15].ConcaveEntities[num26].Count - 1; num27++)
						{
							Item.CamList[num15].ConcaveEntities[num26][num27].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
						}
					}
				}
				if (Item.CamList[num15].ConvexEntities != null)
				{
					for (int num28 = 0; num28 <= Item.CamList[num15].ConvexEntities.Count - 1; num28++)
					{
						for (int num29 = 0; num29 <= Item.CamList[num15].ConvexEntities[num28].Count - 1; num29++)
						{
							Item.CamList[num15].ConvexEntities[num28][num29].Rotate(Rotation, Vector3D.AxisZ, pointRotate);
						}
					}
				}
				if (Item.CamList[num15].DrillEntities != null)
				{
					for (int num30 = 0; num30 <= Item.CamList[num15].DrillEntities.Count - 1; num30++)
					{
						Item.CamList[num15].DrillEntities[num30].Rotate(buConversion5.DegreeToRadian(Rotation), Vector3D.AxisZ, pointRotate);
					}
				}
			}
		}
		ItemSizeCalculation(ref Item);
	}

	public void MirrorItem(ref MarbleItem Item, Point3D pointBase, Point3D pointMirror)
	{
		if (Item.ItemEntities.SolidEntity != null)
		{
			for (int i = 0; i <= Item.ItemEntities.SolidEntity.Count - 1; i++)
			{
				Entity refEntity = Item.ItemEntities.SolidEntity[i];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity);
			}
		}
		if (Item.ItemEntities.TextEntities != null)
		{
			for (int j = 0; j <= Item.ItemEntities.TextEntities.Count - 1; j++)
			{
				buEntity refEntity2 = Item.ItemEntities.TextEntities[j];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity2);
			}
		}
		if (Item.ItemEntities.DrawWireEntities != null)
		{
			for (int k = 0; k <= Item.ItemEntities.DrawWireEntities.Count - 1; k++)
			{
				buEntity refEntity3 = Item.ItemEntities.DrawWireEntities[k];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity3);
			}
		}
		if (Item.ItemEntities.WireEntities != null)
		{
			for (int l = 0; l <= Item.ItemEntities.WireEntities.Count - 1; l++)
			{
				for (int m = 0; m <= Item.ItemEntities.WireEntities[l].Count - 1; m++)
				{
					buEntity refEntity4 = Item.ItemEntities.WireEntities[l][m];
					buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity4);
				}
			}
		}
		if (Item.ItemEntities.SourceEntities != null)
		{
			for (int n = 0; n <= Item.ItemEntities.SourceEntities.Count - 1; n++)
			{
				buEntity refEntity5 = Item.ItemEntities.SourceEntities[n];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity5);
			}
		}
		if (Item.ItemEntities.BaseEntities != null)
		{
			for (int num = 0; num <= Item.ItemEntities.BaseEntities.Count - 1; num++)
			{
				buEntity refEntity6 = Item.ItemEntities.BaseEntities[num];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity6);
			}
		}
		if (Item.EntGroup != null)
		{
			buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref Item.EntGroup);
		}
		if (Item.ItemEntities.ConcaveEntities != null)
		{
			for (int num2 = 0; num2 <= Item.ItemEntities.ConcaveEntities.Count - 1; num2++)
			{
				for (int num3 = 0; num3 <= Item.ItemEntities.ConcaveEntities[num2].Count - 1; num3++)
				{
					buEntity refEntity7 = Item.ItemEntities.ConcaveEntities[num2][num3];
					buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity7);
				}
			}
		}
		if (Item.ItemEntities.ConvexEntities != null)
		{
			for (int num4 = 0; num4 <= Item.ItemEntities.ConvexEntities.Count - 1; num4++)
			{
				for (int num5 = 0; num5 <= Item.ItemEntities.ConvexEntities[num4].Count - 1; num5++)
				{
					buEntity refEntity8 = Item.ItemEntities.ConvexEntities[num4][num5];
					buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity8);
				}
			}
		}
		if (Item.ItemEntities.EdgeEntities != null)
		{
			for (int num6 = 0; num6 <= Item.ItemEntities.EdgeEntities.Count - 1; num6++)
			{
				buEntity refEntity9 = Item.ItemEntities.EdgeEntities[num6];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity9);
			}
		}
		if (Item.ItemEntities.ExtensionEntities != null)
		{
			for (int num7 = 0; num7 <= Item.ItemEntities.ExtensionEntities.Count - 1; num7++)
			{
				buEntity refEntity10 = Item.ItemEntities.ExtensionEntities[num7];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity10);
			}
		}
		if (Item.ItemEntities.EngravingEntities != null)
		{
			for (int num8 = 0; num8 <= Item.ItemEntities.EngravingEntities.Count - 1; num8++)
			{
				buEntity refEntity11 = Item.ItemEntities.EngravingEntities[num8];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity11);
			}
		}
		if (Item.ItemEntities.BorderEntities != null)
		{
			for (int num9 = 0; num9 <= Item.ItemEntities.BorderEntities.Count - 1; num9++)
			{
				buEntity refEntity12 = Item.ItemEntities.BorderEntities[num9];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity12);
			}
		}
		if (Item.ItemEntities.DrillEntities != null)
		{
			for (int num10 = 0; num10 <= Item.ItemEntities.DrillEntities.Count - 1; num10++)
			{
				buEntity refEntity13 = Item.ItemEntities.DrillEntities[num10];
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity13);
			}
		}
		for (int num11 = 0; num11 <= Item.Edges.Count - 1; num11++)
		{
			buEntity refEntity14 = Item.Edges[num11].refEntity;
			buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity14);
			refEntity14 = Item.Edges[num11].drawEntity;
			buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity14);
			if (Item.Edges[num11].Slat.Solid != null)
			{
				Entity refEntity15 = Item.Edges[num11].Slat.Solid;
				buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity15);
			}
		}
		if (Item.CamList != null && Item.CamList.Count > 0)
		{
			for (int num12 = 0; num12 <= Item.CamList.Count - 1; num12++)
			{
				Item.CamList[num12].isCamCalculated = false;
				if (Item.CamList[num12].CamBase != null)
				{
					for (int num13 = 0; num13 <= Item.CamList[num12].CamBase.EntitiesG0.Count - 1; num13++)
					{
						Entity refEntity16 = Item.CamList[num12].CamBase.EntitiesG0[num13];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity16);
					}
					for (int num14 = 0; num14 <= Item.CamList[num12].CamBase.EntitiesG1.Count - 1; num14++)
					{
						Entity refEntity17 = Item.CamList[num12].CamBase.EntitiesG1[num14];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity17);
					}
					for (int num15 = 0; num15 <= Item.CamList[num12].CamBase.EntitiesLeave.Count - 1; num15++)
					{
						Entity refEntity18 = Item.CamList[num12].CamBase.EntitiesLeave[num15];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity18);
					}
					for (int num16 = 0; num16 <= Item.CamList[num12].CamBase.EntitiesPlunge.Count - 1; num16++)
					{
						Entity refEntity19 = Item.CamList[num12].CamBase.EntitiesPlunge[num16];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity19);
					}
					for (int num17 = 0; num17 <= Item.CamList[num12].CamBase.EntitiesLeadIn.Count - 1; num17++)
					{
						Entity refEntity20 = Item.CamList[num12].CamBase.EntitiesLeadIn[num17];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity20);
					}
					for (int num18 = 0; num18 <= Item.CamList[num12].CamBase.EntitiesLeadOut.Count - 1; num18++)
					{
						Entity refEntity21 = Item.CamList[num12].CamBase.EntitiesLeadOut[num18];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity21);
					}
				}
				if (Item.CamList[num12].WireEntities != null)
				{
					for (int num19 = 0; num19 <= Item.CamList[num12].WireEntities.Count - 1; num19++)
					{
						for (int num20 = 0; num20 <= Item.CamList[num12].WireEntities[num19].Count - 1; num20++)
						{
							buEntity refEntity22 = Item.CamList[num12].WireEntities[num19][num20];
							buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity22);
						}
					}
				}
				if (Item.CamList[num12].EntityList != null)
				{
					buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref Item.CamList[num12].EntityList.Entities);
				}
				if (Item.CamList[num12].WireAuxEntities != null)
				{
					for (int num21 = 0; num21 <= Item.CamList[num12].WireAuxEntities.Count - 1; num21++)
					{
						for (int num22 = 0; num22 <= Item.CamList[num12].WireAuxEntities[num21].Count - 1; num22++)
						{
							buEntity refEntity23 = Item.CamList[num12].WireAuxEntities[num21][num22];
							buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity23);
						}
					}
				}
				if (Item.CamList[num12].ConcaveEntities != null)
				{
					for (int num23 = 0; num23 <= Item.CamList[num12].ConcaveEntities.Count - 1; num23++)
					{
						for (int num24 = 0; num24 <= Item.CamList[num12].ConcaveEntities[num23].Count - 1; num24++)
						{
							buEntity refEntity24 = Item.CamList[num12].ConcaveEntities[num23][num24];
							buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity24);
						}
					}
				}
				if (Item.CamList[num12].ConvexEntities != null)
				{
					for (int num25 = 0; num25 <= Item.CamList[num12].ConvexEntities.Count - 1; num25++)
					{
						for (int num26 = 0; num26 <= Item.CamList[num12].ConvexEntities[num25].Count - 1; num26++)
						{
							buEntity refEntity25 = Item.CamList[num12].ConvexEntities[num25][num26];
							buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity25);
						}
					}
				}
				if (Item.CamList[num12].DrillEntities != null)
				{
					for (int num27 = 0; num27 <= Item.CamList[num12].DrillEntities.Count - 1; num27++)
					{
						buEntity refEntity26 = Item.CamList[num12].DrillEntities[num27];
						buCall.buVector5_0.Mirror(pointBase, pointMirror, Plane.XY, ref refEntity26);
					}
				}
			}
		}
		ItemSizeCalculation(ref Item);
	}

	public void ScaleItem(ref MarbleItem Item, Point3D pointBase, double RatioX, double RatioY)
	{
		if (Item.ItemEntities.SolidEntity != null)
		{
			for (int i = 0; i <= Item.ItemEntities.SolidEntity.Count - 1; i++)
			{
				Entity refEntities = Item.ItemEntities.SolidEntity[i];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities);
			}
		}
		if (Item.ItemEntities.TextEntities != null)
		{
			for (int j = 0; j <= Item.ItemEntities.TextEntities.Count - 1; j++)
			{
				buEntity refEntities2 = Item.ItemEntities.TextEntities[j];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities2);
			}
		}
		if (Item.ItemEntities.DrawWireEntities != null)
		{
			for (int k = 0; k <= Item.ItemEntities.DrawWireEntities.Count - 1; k++)
			{
				buEntity refEntities3 = Item.ItemEntities.DrawWireEntities[k];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities3);
			}
		}
		if (Item.ItemEntities.WireEntities != null)
		{
			for (int l = 0; l <= Item.ItemEntities.WireEntities.Count - 1; l++)
			{
				for (int m = 0; m <= Item.ItemEntities.WireEntities[l].Count - 1; m++)
				{
					buEntity refEntities4 = Item.ItemEntities.WireEntities[l][m];
					buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities4);
				}
			}
		}
		if (Item.ItemEntities.SourceEntities != null)
		{
			for (int n = 0; n <= Item.ItemEntities.SourceEntities.Count - 1; n++)
			{
				buEntity refEntities5 = Item.ItemEntities.SourceEntities[n];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities5);
			}
		}
		if (Item.ItemEntities.BaseEntities != null)
		{
			for (int num = 0; num <= Item.ItemEntities.BaseEntities.Count - 1; num++)
			{
				buEntity refEntities6 = Item.ItemEntities.BaseEntities[num];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities6);
			}
		}
		if (Item.EntGroup != null)
		{
			buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref Item.EntGroup);
		}
		if (Item.ItemEntities.ConcaveEntities != null)
		{
			for (int num2 = 0; num2 <= Item.ItemEntities.ConcaveEntities.Count - 1; num2++)
			{
				for (int num3 = 0; num3 <= Item.ItemEntities.ConcaveEntities[num2].Count - 1; num3++)
				{
					buEntity refEntities7 = Item.ItemEntities.ConcaveEntities[num2][num3];
					buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities7);
				}
			}
		}
		if (Item.ItemEntities.ConvexEntities != null)
		{
			for (int num4 = 0; num4 <= Item.ItemEntities.ConvexEntities.Count - 1; num4++)
			{
				for (int num5 = 0; num5 <= Item.ItemEntities.ConvexEntities[num4].Count - 1; num5++)
				{
					buEntity refEntities8 = Item.ItemEntities.ConvexEntities[num4][num5];
					buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities8);
				}
			}
		}
		if (Item.ItemEntities.EdgeEntities != null)
		{
			for (int num6 = 0; num6 <= Item.ItemEntities.EdgeEntities.Count - 1; num6++)
			{
				buEntity refEntities9 = Item.ItemEntities.EdgeEntities[num6];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities9);
			}
		}
		if (Item.ItemEntities.ExtensionEntities != null)
		{
			for (int num7 = 0; num7 <= Item.ItemEntities.ExtensionEntities.Count - 1; num7++)
			{
				buEntity refEntities10 = Item.ItemEntities.ExtensionEntities[num7];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities10);
			}
		}
		if (Item.ItemEntities.EngravingEntities != null)
		{
			for (int num8 = 0; num8 <= Item.ItemEntities.EngravingEntities.Count - 1; num8++)
			{
				buEntity refEntities11 = Item.ItemEntities.EngravingEntities[num8];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities11);
			}
		}
		if (Item.ItemEntities.BorderEntities != null)
		{
			for (int num9 = 0; num9 <= Item.ItemEntities.BorderEntities.Count - 1; num9++)
			{
				buEntity refEntities12 = Item.ItemEntities.BorderEntities[num9];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities12);
			}
		}
		if (Item.ItemEntities.DrillEntities != null)
		{
			for (int num10 = 0; num10 <= Item.ItemEntities.DrillEntities.Count - 1; num10++)
			{
				buEntity refEntities13 = Item.ItemEntities.DrillEntities[num10];
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities13);
			}
		}
		for (int num11 = 0; num11 <= Item.Edges.Count - 1; num11++)
		{
			buEntity refEntities14 = Item.Edges[num11].refEntity;
			buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities14);
			refEntities14 = Item.Edges[num11].drawEntity;
			buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities14);
			if (Item.Edges[num11].Slat.Solid != null)
			{
				Entity refEntities15 = Item.Edges[num11].Slat.Solid;
				buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities15);
			}
		}
		if (Item.CamList != null && Item.CamList.Count > 0)
		{
			for (int num12 = 0; num12 <= Item.CamList.Count - 1; num12++)
			{
				Item.CamList[num12].isCamCalculated = false;
				if (Item.CamList[num12].CamBase != null)
				{
					for (int num13 = 0; num13 <= Item.CamList[num12].CamBase.EntitiesG0.Count - 1; num13++)
					{
						Entity refEntities16 = Item.CamList[num12].CamBase.EntitiesG0[num13];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities16);
					}
					for (int num14 = 0; num14 <= Item.CamList[num12].CamBase.EntitiesG1.Count - 1; num14++)
					{
						Entity refEntities17 = Item.CamList[num12].CamBase.EntitiesG1[num14];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities17);
					}
					for (int num15 = 0; num15 <= Item.CamList[num12].CamBase.EntitiesLeave.Count - 1; num15++)
					{
						Entity refEntities18 = Item.CamList[num12].CamBase.EntitiesLeave[num15];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities18);
					}
					for (int num16 = 0; num16 <= Item.CamList[num12].CamBase.EntitiesPlunge.Count - 1; num16++)
					{
						Entity refEntities19 = Item.CamList[num12].CamBase.EntitiesPlunge[num16];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities19);
					}
					for (int num17 = 0; num17 <= Item.CamList[num12].CamBase.EntitiesLeadIn.Count - 1; num17++)
					{
						Entity refEntities20 = Item.CamList[num12].CamBase.EntitiesLeadIn[num17];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities20);
					}
					for (int num18 = 0; num18 <= Item.CamList[num12].CamBase.EntitiesLeadOut.Count - 1; num18++)
					{
						Entity refEntities21 = Item.CamList[num12].CamBase.EntitiesLeadOut[num18];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities21);
					}
				}
				if (Item.CamList[num12].WireEntities != null)
				{
					for (int num19 = 0; num19 <= Item.CamList[num12].WireEntities.Count - 1; num19++)
					{
						for (int num20 = 0; num20 <= Item.CamList[num12].WireEntities[num19].Count - 1; num20++)
						{
							buEntity refEntities22 = Item.CamList[num12].WireEntities[num19][num20];
							buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities22);
						}
					}
				}
				if (Item.CamList[num12].EntityList != null)
				{
					buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref Item.CamList[num12].EntityList.Entities);
				}
				if (Item.CamList[num12].WireAuxEntities != null)
				{
					for (int num21 = 0; num21 <= Item.CamList[num12].WireAuxEntities.Count - 1; num21++)
					{
						for (int num22 = 0; num22 <= Item.CamList[num12].WireAuxEntities[num21].Count - 1; num22++)
						{
							buEntity refEntities23 = Item.CamList[num12].WireAuxEntities[num21][num22];
							buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities23);
						}
					}
				}
				if (Item.CamList[num12].ConcaveEntities != null)
				{
					for (int num23 = 0; num23 <= Item.CamList[num12].ConcaveEntities.Count - 1; num23++)
					{
						for (int num24 = 0; num24 <= Item.CamList[num12].ConcaveEntities[num23].Count - 1; num24++)
						{
							buEntity refEntities24 = Item.CamList[num12].ConcaveEntities[num23][num24];
							buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities24);
						}
					}
				}
				if (Item.CamList[num12].ConvexEntities != null)
				{
					for (int num25 = 0; num25 <= Item.CamList[num12].ConvexEntities.Count - 1; num25++)
					{
						for (int num26 = 0; num26 <= Item.CamList[num12].ConvexEntities[num25].Count - 1; num26++)
						{
							buEntity refEntities25 = Item.CamList[num12].ConvexEntities[num25][num26];
							buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities25);
						}
					}
				}
				if (Item.CamList[num12].DrillEntities != null)
				{
					for (int num27 = 0; num27 <= Item.CamList[num12].DrillEntities.Count - 1; num27++)
					{
						buEntity refEntities26 = Item.CamList[num12].DrillEntities[num27];
						buCall.buVector5_0.Scale(pointBase, RatioX, RatioY, 1.0, ref refEntities26);
					}
				}
			}
		}
		ItemSizeCalculation(ref Item);
	}

	public void ExtendItem(ref MarbleItem refItem, int EntityIndex, int EntitySubIndex, int EdgeIndex, Point3D pntExtend, double ExtendLength)
	{
		try
		{
			for (int i = 0; i <= refItem.CamList.Count - 1; i++)
			{
				refItem.CamList[i].isCamCalculated = false;
				MarbleItemCam marbleItemCam = refItem.CamList[i];
				if (marbleItemCam.ToolType != MarbleToolType.Saw)
				{
					continue;
				}
				double num = 99999999.0;
				int num2 = -1;
				int num3 = -1;
				StartEndType startEndType = StartEndType.Start;
				if (!(EntityIndex >= 0 || EntitySubIndex >= 0))
				{
					for (int j = 0; j <= marbleItemCam.WireEntities.Count - 1; j++)
					{
						for (int k = 0; k <= marbleItemCam.WireEntities[j].Count - 1; k++)
						{
							double num4 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[j][k].StartPoint, pntExtend);
							if (num4 < num)
							{
								num = num4;
								num2 = j;
								num3 = k;
								startEndType = StartEndType.Start;
							}
							num4 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[j][k].EndPoint, pntExtend);
							if (num4 < num)
							{
								num = num4;
								num2 = j;
								num3 = k;
								startEndType = StartEndType.End;
							}
						}
					}
				}
				else
				{
					for (int l = 0; l <= marbleItemCam.WireEntities.Count - 1; l++)
					{
						for (int m = 0; m <= marbleItemCam.WireEntities[l].Count - 1; m++)
						{
							if ((marbleItemCam.WireEntities[l][m].Info.EntityIndex == EntityIndex) & (marbleItemCam.WireEntities[l][m].Info.EntitySubIndex == EntitySubIndex))
							{
								double num5 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[l][m].StartPoint, pntExtend);
								double num6 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[l][m].EndPoint, pntExtend);
								num2 = l;
								num3 = m;
								startEndType = ((num5 < num6) ? StartEndType.Start : StartEndType.End);
							}
						}
					}
				}
				if (!(num2 >= 0 && num3 >= 0 && EdgeIndex >= 0))
				{
					continue;
				}
				buEntity buEntity2 = marbleItemCam.WireEntities[num2][num3];
				if (startEndType != StartEndType.Start)
				{
					if (buEntity2 is buLine)
					{
						double num7 = buCall.buVector5_0.EntityLength(buEntity2);
						double angle = buCall.buVector5_0.PointAngle(buEntity2.EndPoint, buEntity2.StartPoint);
						Point3D EndPnt = new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buEntity2.StartPoint, num7 + ExtendLength, angle, ref EndPnt);
						buEntity2.EndPoint = new Point3D(EndPnt.X, EndPnt.Y, buEntity2.EndPoint.Z);
						buEntity2.Update();
						MarbleItemExtend marbleItemExtend = new MarbleItemExtend();
						marbleItemExtend.ExtendPoint = new Point3D(buEntity2.EndPoint.X, buEntity2.EndPoint.Y, buEntity2.EndPoint.Z);
						marbleItemExtend.Direction = startEndType;
						marbleItemExtend.ExtendLength = ExtendLength;
						marbleItemExtend.indexCam = i;
						marbleItemExtend.indexWire = num2;
						marbleItemExtend.indexWireSub = num3;
						marbleItemExtend.CamID = marbleItemCam.CamID;
						buEntity.Copy(buEntity2, ref marbleItemExtend.entityExtend);
						if (refItem.Extends.Count != 0)
						{
							MarbleItemExtend.Add(marbleItemExtend, ref refItem.Extends);
						}
						else
						{
							refItem.Extends.Add(marbleItemExtend);
						}
					}
				}
				else if (buEntity2 is buLine)
				{
					double num8 = buCall.buVector5_0.EntityLength(buEntity2);
					double angle2 = buCall.buVector5_0.PointAngle(buEntity2.StartPoint, buEntity2.EndPoint);
					Point3D EndPnt2 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(buEntity2.EndPoint, num8 + ExtendLength, angle2, ref EndPnt2);
					buEntity2.StartPoint = new Point3D(EndPnt2.X, EndPnt2.Y, buEntity2.StartPoint.Z);
					buEntity2.Update();
					MarbleItemExtend marbleItemExtend2 = new MarbleItemExtend();
					marbleItemExtend2.ExtendPoint = new Point3D(buEntity2.StartPoint.X, buEntity2.StartPoint.Y, buEntity2.StartPoint.Z);
					marbleItemExtend2.Direction = startEndType;
					marbleItemExtend2.ExtendLength = ExtendLength;
					marbleItemExtend2.indexCam = i;
					marbleItemExtend2.indexWire = num2;
					marbleItemExtend2.indexWireSub = num3;
					marbleItemExtend2.CamID = marbleItemCam.CamID;
					buEntity.Copy(buEntity2, ref marbleItemExtend2.entityExtend);
					if (refItem.Extends.Count != 0)
					{
						MarbleItemExtend.Add(marbleItemExtend2, ref refItem.Extends);
					}
					else
					{
						refItem.Extends.Add(marbleItemExtend2);
					}
				}
				marbleEdgeItem marbleEdgeItem2 = refItem.Edges[EdgeIndex];
				marbleEdgeItem EdgeItem = null;
				CreateEdgesFromEntity(buEntity2, marbleEdgeItem2.IndexEntity, marbleEdgeItem2.Clock, null, refItem, marbleItemCam, Outside: true, refItem.MaterialThickness, marbleItemCam.ToolSelected.Geometry.Diameter, -1, ref EdgeItem);
				buEntity.Copy(EdgeItem.drawEntity, ref marbleEdgeItem2.drawEntity);
				buEntity.Copy(EdgeItem.refEntity, ref marbleEdgeItem2.refEntity);
				marbleEdgeItem2.Length = EdgeItem.Length;
				refItem.Edges[EdgeIndex] = marbleEdgeItem2;
			}
		}
		catch (Exception)
		{
		}
	}

	public void BreakItem(ref MarbleItem refItem, int EntityIndex, int EntitySubIndex, int EdgeID, int CamID, Point3D pntBreak, double BreakLength, MarbleBreakType BreakType)
	{
		try
		{
			Point3D EndPnt = new Point3D(pntBreak.X, pntBreak.Y, pntBreak.Z);
			for (int i = 0; i <= refItem.CamList.Count - 1; i++)
			{
				if (refItem.CamList[i].CamID != CamID)
				{
					continue;
				}
				refItem.CamList[i].isCamCalculated = false;
				MarbleItemCam marbleItemCam = refItem.CamList[i];
				if (marbleItemCam.ToolType != MarbleToolType.Saw)
				{
					continue;
				}
				double num = 99999999.0;
				int num2 = -1;
				int num3 = -1;
				StartEndType startEndType = StartEndType.Start;
				if (!(EntityIndex >= 0 || EntitySubIndex >= 0))
				{
					for (int j = 0; j <= marbleItemCam.WireEntities.Count - 1; j++)
					{
						for (int k = 0; k <= marbleItemCam.WireEntities[j].Count - 1; k++)
						{
							double num4 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[j][k].StartPoint, pntBreak);
							if (num4 < num)
							{
								num = num4;
								num2 = j;
								num3 = k;
								startEndType = StartEndType.Start;
							}
							num4 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[j][k].EndPoint, pntBreak);
							if (num4 < num)
							{
								num = num4;
								num2 = j;
								num3 = k;
								startEndType = StartEndType.End;
							}
						}
					}
				}
				else
				{
					for (int l = 0; l <= marbleItemCam.WireEntities.Count - 1; l++)
					{
						for (int m = 0; m <= marbleItemCam.WireEntities[l].Count - 1; m++)
						{
							if ((marbleItemCam.WireEntities[l][m].Info.EntityIndex == EntityIndex) & (marbleItemCam.WireEntities[l][m].Info.EntitySubIndex == EntitySubIndex))
							{
								double num5 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[l][m].StartPoint, pntBreak);
								double num6 = buCall.buVector5_0.Length3D(marbleItemCam.WireEntities[l][m].EndPoint, pntBreak);
								num2 = l;
								num3 = m;
								startEndType = ((num5 < num6) ? StartEndType.Start : StartEndType.End);
							}
						}
					}
				}
				if (!(num2 >= 0 && num3 >= 0))
				{
					continue;
				}
				buEntity buEntity2 = marbleItemCam.WireEntities[num2][num3];
				if (BreakType == MarbleBreakType.Distance)
				{
					if (startEndType != StartEndType.Start)
					{
						if (buEntity2 is buLine)
						{
							double angle = buCall.buVector5_0.PointAngle(buEntity2.StartPoint, buEntity2.EndPoint);
							new Point3D();
							buCall.buVector5_0.LineWithLengthAndAngle(buEntity2.EndPoint, BreakLength, angle, ref EndPnt);
						}
					}
					else if (buEntity2 is buLine)
					{
						double angle2 = buCall.buVector5_0.PointAngle(buEntity2.EndPoint, buEntity2.StartPoint);
						new Point3D();
						buCall.buVector5_0.LineWithLengthAndAngle(buEntity2.StartPoint, BreakLength, angle2, ref EndPnt);
					}
				}
				Entity copiedEntity = null;
				buEntity.Copy(buEntity2, ref copiedEntity);
				double t = 0.0;
				((ICurve)copiedEntity).ClosestPointTo(EndPnt, out t);
				ICurve lower = null;
				ICurve upper = null;
				((ICurve)copiedEntity).SplitAt(t, out lower, out upper);
				if (!(lower != null && upper != null))
				{
					continue;
				}
				int entityIndex = buEntity2.Info.EntityIndex;
				if (!(buEntity2 is buLine))
				{
					continue;
				}
				marbleEdgeItem marbleEdgeItem2 = null;
				for (int n = 0; n <= refItem.Edges.Count - 1; n++)
				{
					if (refItem.Edges[n].EdgeID != EdgeID)
					{
						continue;
					}
					marbleEdgeItem2 = refItem.Edges[n];
					buEntity.Copy(buEntity2, ref refItem.Edges[n].refEntity);
					if (marbleEdgeItem2.OutsideInside == OutsideInsideType.Outside)
					{
						Entity copiedEntity2 = null;
						buEntity.Copy(refItem.EntGroup.Outside.Entities[entityIndex], ref copiedEntity2);
						((ICurve)copiedEntity2).ClosestPointTo(EndPnt, out t);
						ICurve lower2 = null;
						ICurve upper2 = null;
						((ICurve)copiedEntity2).SplitAt(t, out lower2, out upper2);
						if (lower2 != null && upper2 != null)
						{
							buLine buLine2 = buEntity2 as buLine;
							refItem.EntGroup.Outside.Entities[entityIndex].StartPoint = new Point3D(lower2.StartPoint.X, lower2.StartPoint.Y, refItem.EntGroup.Outside.Entities[entityIndex].StartPoint.Z);
							refItem.EntGroup.Outside.Entities[entityIndex].EndPoint = new Point3D(lower2.EndPoint.X, lower2.EndPoint.Y, refItem.EntGroup.Outside.Entities[entityIndex].StartPoint.Z);
							refItem.EntGroup.Outside.Entities[entityIndex].StartPoint = lower2.StartPoint;
							refItem.EntGroup.Outside.Entities[entityIndex].Update();
							buLine2.StartPoint = new Point3D(lower2.StartPoint.X, lower2.StartPoint.Y, refItem.EntGroup.Outside.Entities[entityIndex].StartPoint.Z);
							buLine2.EndPoint = new Point3D(lower2.EndPoint.X, lower2.EndPoint.Y, refItem.EntGroup.Outside.Entities[entityIndex].StartPoint.Z);
							buLine2.Update();
							buEntity copiedEntity3 = null;
							buEntity.Copy(buLine2, ref copiedEntity3);
							copiedEntity3.StartPoint = new Point3D(upper2.StartPoint.X, upper2.StartPoint.Y, copiedEntity3.StartPoint.Z);
							copiedEntity3.EndPoint = new Point3D(upper2.EndPoint.X, upper2.EndPoint.Y, copiedEntity3.StartPoint.Z);
							copiedEntity3.Update();
							List<buEntity> list = new List<buEntity>();
							list.Add(copiedEntity3);
							marbleItemCam.WireEntities.Insert(num2 + 1, list);
							refItem.EntGroup.Outside.Entities.Insert(entityIndex + 1, copiedEntity3);
						}
					}
				}
				if (refItem.CamList != null)
				{
					for (int num7 = 0; num7 <= refItem.CamList.Count - 1; num7++)
					{
						if (refItem.CamList[num7].ToolSelected.Purpose == ToolPurpose.Saw)
						{
							_ = refItem.CamList[num7].ToolSelected.Geometry.Diameter;
						}
					}
				}
				marbleItemCam.EntityList = new buEntityList();
				marbleItemCam.EntityList = new buEntityList(refItem.EntGroup.Outside);
				marbleItemCam.EntityList.InOutType = entityInOutDirectionType.Outside;
				int num8 = 0;
				for (int num9 = 0; num9 <= marbleItemCam.WireEntities.Count - 1; num9++)
				{
					for (int num10 = 0; num10 <= marbleItemCam.WireEntities[num9].Count - 1; num10++)
					{
						marbleItemCam.WireEntities[num9][num10].Info.EntityIndex = num8;
						num8++;
					}
				}
				refItem.Edges.Clear();
			}
			if (refItem.Edges.Count != 0)
			{
				return;
			}
			int num11 = -1;
			for (int num12 = 0; num12 <= refItem.CamList.Count - 1; num12++)
			{
				MarbleItemCam marbleItemCam2 = refItem.CamList[num12];
				if (marbleItemCam2.ToolType == MarbleToolType.Saw)
				{
					bool outside = true;
					if (marbleItemCam2.Direction == InOutCenterType.Outside)
					{
						num11++;
					}
					else
					{
						outside = false;
					}
					CreateEdgesFromEntities(marbleItemCam2.EntityList.Entities, null, refItem, marbleItemCam2, outside, refItem.MaterialThickness, marbleItemCam2.ToolSelected.Geometry.Diameter, num11, ref refItem.Edges);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void OffsetItem(ref MarbleItem refItem, int EntityIndex, int EntitySubIndex, double OffsetDistance)
	{
		try
		{
			if (!(EntityIndex >= 0 && EntitySubIndex == -1))
			{
				List<buEntity> OffsetedEntity = new List<buEntity>();
				CamClosedContourType closedType = CamClosedContourType.Outter;
				if (OffsetDistance < 0.0)
				{
					closedType = CamClosedContourType.Inner;
				}
				buCall.buVector5_0.OffsetEntities(refItem.EntGroup.Inside[EntityIndex].Entities, OffsetDistance, CamOpenContourType.Center, closedType, ref OffsetedEntity);
				if (refItem.EntGroup.Inside == null)
				{
					refItem.EntGroup.Inside = new List<buEntityList>();
				}
				if (OffsetedEntity.Count > 0)
				{
					buEntityList buEntityList2 = new buEntityList();
					buEntity.Copy(OffsetedEntity, ref buEntityList2.Entities);
					if (refItem.EntGroup.Inside.Count > 0)
					{
						refItem.EntGroup.Inside[0].InOutType = entityInOutDirectionType.InsideOfInside;
						buEntityList2.InOutType = entityInOutDirectionType.InsideOfInside;
					}
					refItem.EntGroup.Inside.Add(buEntityList2);
				}
				return;
			}
			List<buEntity> OffsetedEntity2 = new List<buEntity>();
			CamClosedContourType closedType2 = CamClosedContourType.Outter;
			if (OffsetDistance < 0.0)
			{
				closedType2 = CamClosedContourType.Inner;
			}
			buCall.buVector5_0.OffsetEntities(refItem.EntGroup.Outside.Entities, OffsetDistance, CamOpenContourType.Center, closedType2, ref OffsetedEntity2);
			if (refItem.EntGroup.Inside == null)
			{
				refItem.EntGroup.Inside = new List<buEntityList>();
			}
			if (OffsetedEntity2.Count > 0)
			{
				buEntityList buEntityList3 = new buEntityList();
				buEntity.Copy(OffsetedEntity2, ref buEntityList3.Entities);
				if (refItem.EntGroup.Inside.Count > 0)
				{
					refItem.EntGroup.Inside[0].InOutType = entityInOutDirectionType.InsideOfInside;
					buEntityList3.InOutType = entityInOutDirectionType.InsideOfInside;
				}
				refItem.EntGroup.Inside.Add(buEntityList3);
			}
		}
		catch (Exception)
		{
		}
	}

	public void OffsetCalculation(marbleOffsetCalculationParameters Pars, MarbleItemSettings Settings, ref double Offset)
	{
		double XLength = 0.0;
		double num = Pars.ToolThickness;
		if (Pars.ToolSocket > Pars.ToolThickness)
		{
			num = Pars.ToolSocket;
		}
		Offset = (Math.Abs(num / 2.0) + Pars.Offset) / Math.Cos(buConversion5.DegreeToRadian(Pars.OrientationA));
		if (Pars.OrientationA < 0.0)
		{
			Math.Round((0.0 - Pars.TargetZ) * Math.Tan(buConversion5.DegreeToRadian(Math.Abs(Pars.OrientationA))), 5);
		}
		if (Pars.isToolSaw)
		{
			buCall.buVector5_0.LengthFromZLengthAndAngle(Pars.MaterialThickness - Pars.TargetZ, Pars.OrientationA, ref XLength);
			if (Pars.isReverseAngleA)
			{
				XLength = 0.0 - XLength;
			}
		}
		if (Math.Abs(Pars.OrientationA) > 0.0)
		{
			Offset -= XLength;
		}
	}

	public void OffsetCalculation(marbleOffsetCalculationParameters Pars, ref double Offset, ref CamOpenContourType OpenOffsetType)
	{
		double XLength = 0.0;
		if (!Pars.isClosed)
		{
			if ((Pars.OpenOffsetType == CamOpenContourType.Left) | (Pars.OpenOffsetType == CamOpenContourType.Right))
			{
				Offset = (Math.Abs(Pars.ToolDiameter / 2.0) + Pars.Offset) / Math.Cos(buConversion5.DegreeToRadian(Pars.OrientationA));
			}
			if (Pars.OpenOffsetType == CamOpenContourType.Center)
			{
				Offset = 0.0;
			}
		}
		else
		{
			if (Pars.ClosedOffsetType == CamClosedContourType.Inner)
			{
				Offset = 0.0 - Math.Abs(Pars.ToolDiameter / 2.0) + Pars.Offset;
			}
			if (Pars.ClosedOffsetType == CamClosedContourType.Outter)
			{
				Offset = (Math.Abs(Pars.ToolDiameter / 2.0) + Pars.Offset) / Math.Cos(buConversion5.DegreeToRadian(Pars.OrientationA));
			}
			if (Pars.ClosedOffsetType == CamClosedContourType.Center)
			{
				Offset = 0.0;
			}
		}
		if (Pars.isToolSaw)
		{
			buCall.buVector5_0.LengthFromZLengthAndAngle(Pars.MaterialThickness - Pars.TargetZ, Pars.OrientationA, ref XLength);
			if (Pars.isReverseAngleA)
			{
				XLength = 0.0 - XLength;
			}
		}
		if (!Pars.isClosed)
		{
			if (Pars.OpenOffsetType != CamOpenContourType.Right)
			{
				if (Pars.OpenOffsetType == CamOpenContourType.Left)
				{
					Offset += XLength;
					if (Offset < 0.0)
					{
						OpenOffsetType = CamOpenContourType.Left;
					}
				}
			}
			else
			{
				Offset -= XLength;
				if (Offset < 0.0)
				{
					OpenOffsetType = CamOpenContourType.Right;
				}
			}
		}
		else
		{
			Offset -= XLength;
		}
	}

	public void EntityLengthModify(buEntity RefEntity, StartPointType ModifyDirType, double ModifyLength, ref buEntity ModifiedEntity)
	{
		ModifiedEntity = new buEntity();
		double cutLength = ModifyLength / Math.Cos(buConversion5.DegreeToRadian(RefEntity.Orientation.A));
		if (ModifyDirType == StartPointType.Start)
		{
			if (RefEntity.sortDirection != entitySortDirection.Normal)
			{
				buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(buEntity.Copy(RefEntity), cutLength, StartPointType.End, Plane.XY, ref ModifiedEntity);
			}
			else
			{
				buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(buEntity.Copy(RefEntity), cutLength, StartPointType.Start, Plane.XY, ref ModifiedEntity);
			}
		}
		if (ModifyDirType == StartPointType.End)
		{
			if (RefEntity.sortDirection != entitySortDirection.Normal)
			{
				buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(buEntity.Copy(RefEntity), cutLength, StartPointType.Start, Plane.XY, ref ModifiedEntity);
			}
			else
			{
				buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(buEntity.Copy(RefEntity), cutLength, StartPointType.End, Plane.XY, ref ModifiedEntity);
			}
		}
		if (ModifyDirType == StartPointType.StartAndEnd)
		{
			buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(buEntity.Copy(RefEntity), cutLength, StartPointType.StartAndEnd, Plane.XY, ref ModifiedEntity);
		}
		ModifiedEntity.Info.CamSelected = false;
	}

	public void EntityCornerModifyByConvexConcave(buEntity FirstEntity, buEntity LastEntity, ClockDirectionType ClockDir, bool ReverseThetaCalculation, double ModifyLength, ref buEntity ModifiedFirstEntity, ref buEntity ModifiedLastEntity)
	{
		ModifiedFirstEntity = new buEntity();
		ModifiedLastEntity = new buEntity();
		bool isTouch = false;
		StartEndType FirstEntityTouchPoint = StartEndType.Start;
		StartEndType SecondEntityTouchPoint = StartEndType.Start;
		buCall.buVector5_0.EntityEntityTouchPoint(FirstEntity, LastEntity, 0.01, ref isTouch, ref FirstEntityTouchPoint, ref SecondEntityTouchPoint);
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		if (FirstEntityTouchPoint != StartEndType.End)
		{
			point3D = buVector5.ToPoint3D(FirstEntity.Vertices[0]);
			point3D2 = buVector5.ToPoint3D(FirstEntity.Vertices[1]);
		}
		else
		{
			point3D = buVector5.ToPoint3D(FirstEntity.Vertices[FirstEntity.Vertices.Count - 1]);
			point3D2 = buVector5.ToPoint3D(FirstEntity.Vertices[FirstEntity.Vertices.Count - 2]);
		}
		if (SecondEntityTouchPoint != StartEndType.End)
		{
			point3D3 = buVector5.ToPoint3D(LastEntity.Vertices[0]);
			point3D4 = buVector5.ToPoint3D(LastEntity.Vertices[1]);
		}
		else
		{
			point3D3 = buVector5.ToPoint3D(LastEntity.Vertices[LastEntity.Vertices.Count - 1]);
			point3D4 = buVector5.ToPoint3D(LastEntity.Vertices[LastEntity.Vertices.Count - 2]);
		}
		double value = buCall.buVector5_0.AngleOfTwoLines(point3D, point3D2, point3D3, point3D4, Plane.XY);
		if (!(180.0 - Math.Abs(value) <= 30.0))
		{
			double num = 0.0;
			double num2 = ModifyLength;
			List<Point3D> CopiedPnt = new List<Point3D>();
			List<Point3D> Points = new List<Point3D>();
			if (FirstEntity.GetType() == typeof(buLine))
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(FirstEntity, 0.01, ref Points);
			}
			if (FirstEntity.GetType() == typeof(buArc))
			{
				buCall.buVector5_0.ArcTo3Point(FirstEntity, ref Points);
				Points.RemoveAt(0);
			}
			buVector5.Add(Points, ref CopiedPnt);
			Points = new List<Point3D>();
			if (LastEntity.GetType() == typeof(buLine))
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(LastEntity, 0.01, ref Points);
			}
			if (LastEntity.GetType() == typeof(buArc))
			{
				buCall.buVector5_0.ArcTo3Point(LastEntity, ref Points);
				Points.RemoveAt(Points.Count - 1);
			}
			buVector5.Add(Points, ref CopiedPnt);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref CopiedPnt);
			if (CopiedPnt.Count == 3)
			{
				num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
			}
			if (CopiedPnt.Count > 3)
			{
				num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[2]);
				if (num > 0.0 && ClockDir == ClockDirectionType.CCW)
				{
					num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
				}
				if (num < 0.0 && ClockDir == ClockDirectionType.CW)
				{
					num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
				}
			}
			if (ReverseThetaCalculation)
			{
				num *= -1.0;
			}
			if (ClockDir != ClockDirectionType.CCW)
			{
				if (!(num >= 0.0))
				{
					new buEntity();
					new buEntity();
					num2 /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
					if (FirstEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - num2, StartPointType.Start, ref ModifiedFirstEntity);
					}
					if (FirstEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - num2, StartPointType.End, ref ModifiedFirstEntity);
					}
					if (SecondEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - num2, StartPointType.Start, ref ModifiedLastEntity);
					}
					if (SecondEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - num2, StartPointType.End, ref ModifiedLastEntity);
					}
					ModifiedFirstEntity.Info.CamSelected = false;
				}
				else
				{
					buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
					ModifiedFirstEntity.Info.CamSelected = false;
					buEntity.Copy(LastEntity, ref ModifiedLastEntity);
					ModifiedLastEntity.Info.CamSelected = false;
				}
			}
			else if (!(num <= 0.0))
			{
				num2 /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
				if (FirstEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - num2, StartPointType.Start, ref ModifiedFirstEntity);
				}
				if (FirstEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - num2, StartPointType.End, ref ModifiedFirstEntity);
				}
				if (SecondEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - num2, StartPointType.Start, ref ModifiedLastEntity);
				}
				if (SecondEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - num2, StartPointType.End, ref ModifiedLastEntity);
				}
				ModifiedFirstEntity.Info.CamSelected = false;
			}
			else
			{
				buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
				ModifiedFirstEntity.Info.CamSelected = false;
				buEntity.Copy(LastEntity, ref ModifiedLastEntity);
				ModifiedLastEntity.Info.CamSelected = false;
			}
		}
		else
		{
			buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
			ModifiedFirstEntity.Info.CamSelected = false;
			buEntity.Copy(LastEntity, ref ModifiedLastEntity);
			ModifiedLastEntity.Info.CamSelected = false;
		}
	}

	public void EntityCornerModifyByConvexConcave(buEntity FirstEntity, buEntity LastEntity, ClockDirectionType ClockDir, marbleConvexConcaveCalculationPars Pars, ref buEntity ModifiedFirstEntity, ref buEntity ModifiedLastEntity, ref List<buEntity> ConcaveEntitiesForMilling, ref List<buEntity> ConvexEntitiesForMilling)
	{
		ModifiedFirstEntity = new buEntity();
		ModifiedLastEntity = new buEntity();
		ConcaveEntitiesForMilling = new List<buEntity>();
		Point3D pntTouch = new Point3D();
		bool isTouch = false;
		StartEndType FirstEntityTouchPoint = StartEndType.Start;
		StartEndType SecondEntityTouchPoint = StartEndType.Start;
		buCall.buVector5_0.EntityEntityTouchPoint(FirstEntity, LastEntity, 0.01, ref isTouch, ref FirstEntityTouchPoint, ref SecondEntityTouchPoint, ref pntTouch);
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		if (FirstEntityTouchPoint != StartEndType.End)
		{
			point3D = buVector5.ToPoint3D(FirstEntity.Vertices[0]);
			point3D2 = buVector5.ToPoint3D(FirstEntity.Vertices[1]);
		}
		else
		{
			point3D = buVector5.ToPoint3D(FirstEntity.Vertices[FirstEntity.Vertices.Count - 1]);
			point3D2 = buVector5.ToPoint3D(FirstEntity.Vertices[FirstEntity.Vertices.Count - 2]);
		}
		if (SecondEntityTouchPoint != StartEndType.End)
		{
			point3D3 = buVector5.ToPoint3D(LastEntity.Vertices[0]);
			point3D4 = buVector5.ToPoint3D(LastEntity.Vertices[1]);
		}
		else
		{
			point3D3 = buVector5.ToPoint3D(LastEntity.Vertices[LastEntity.Vertices.Count - 1]);
			point3D4 = buVector5.ToPoint3D(LastEntity.Vertices[LastEntity.Vertices.Count - 2]);
		}
		double value = buCall.buVector5_0.AngleOfTwoLines(point3D, point3D2, point3D3, point3D4, Plane.XY);
		if (!(180.0 - Math.Abs(value) <= 30.0))
		{
			double num = 0.0;
			double concaveLength = Pars.ConcaveLength;
			double concaveLength2 = Pars.ConcaveLength;
			List<Point3D> CopiedPnt = new List<Point3D>();
			List<Point3D> Points = new List<Point3D>();
			if (FirstEntity.GetType() == typeof(buLine))
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(FirstEntity, 0.01, ref Points);
			}
			if (FirstEntity.GetType() == typeof(buArc))
			{
				buCall.buVector5_0.ArcTo3Point(FirstEntity, ref Points);
				Points.RemoveAt(0);
			}
			buVector5.Add(Points, ref CopiedPnt);
			Points = new List<Point3D>();
			if (LastEntity.GetType() == typeof(buLine))
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(LastEntity, 0.01, ref Points);
			}
			if (LastEntity.GetType() == typeof(buArc))
			{
				buCall.buVector5_0.ArcTo3Point(LastEntity, ref Points);
				Points.RemoveAt(Points.Count - 1);
			}
			buVector5.Add(Points, ref CopiedPnt);
			buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref CopiedPnt);
			if (CopiedPnt.Count == 3)
			{
				num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
			}
			if (CopiedPnt.Count > 3)
			{
				num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[2]);
				if (num > 0.0 && ClockDir == ClockDirectionType.CCW)
				{
					num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
				}
				if (num < 0.0 && ClockDir == ClockDirectionType.CW)
				{
					num = buCall.buVector5_0.CrossProductLength(CopiedPnt[0], CopiedPnt[1], CopiedPnt[CopiedPnt.Count - 1]);
				}
			}
			if (Pars.ReverseThetaCalculation)
			{
				num *= -1.0;
			}
			List<Point3D> list = new List<Point3D>();
			if (ClockDir != ClockDirectionType.CCW)
			{
				if (!(num >= 0.0))
				{
					new buEntity();
					new buEntity();
					concaveLength /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
					if (FirstEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength, StartPointType.Start, ref ModifiedFirstEntity);
						list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.StartPoint));
						list.Add(buVector5.ToPoint3D(pntTouch));
						ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
					}
					if (FirstEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength, StartPointType.End, ref ModifiedFirstEntity);
						list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.EndPoint));
						list.Add(buVector5.ToPoint3D(pntTouch));
						ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
					}
					if (SecondEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength, StartPointType.Start, ref ModifiedLastEntity);
						list.Add(buVector5.ToPoint3D(ModifiedLastEntity.StartPoint));
						ModifiedLastEntity.Info.CamSelected = false;
					}
					if (SecondEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength, StartPointType.End, ref ModifiedLastEntity);
						list.Add(buVector5.ToPoint3D(ModifiedLastEntity.EndPoint));
						ModifiedLastEntity.Info.CamSelected = false;
					}
					ModifiedFirstEntity.Info.CamSelected = false;
					if (list.Count >= 2)
					{
						buLinearPath item = new buLinearPath(list);
						ConcaveEntitiesForMilling.Add(item);
					}
				}
				else if (Pars.isConvex)
				{
					new buEntity();
					new buEntity();
					concaveLength2 /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
					if (FirstEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength2, StartPointType.Start, ref ModifiedFirstEntity);
						list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.StartPoint));
						list.Add(buVector5.ToPoint3D(pntTouch));
						ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
					}
					if (FirstEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength2, StartPointType.End, ref ModifiedFirstEntity);
						list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.EndPoint));
						list.Add(buVector5.ToPoint3D(pntTouch));
						ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
					}
					if (SecondEntityTouchPoint == StartEndType.Start)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength2, StartPointType.Start, ref ModifiedLastEntity);
						list.Add(buVector5.ToPoint3D(ModifiedLastEntity.StartPoint));
						ModifiedLastEntity.Info.CamSelected = false;
					}
					if (SecondEntityTouchPoint == StartEndType.End)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength2, StartPointType.End, ref ModifiedLastEntity);
						list.Add(buVector5.ToPoint3D(ModifiedLastEntity.EndPoint));
						ModifiedLastEntity.Info.CamSelected = false;
					}
					ModifiedFirstEntity.Info.CamSelected = false;
					if (list.Count >= 2)
					{
						buLinearPath item2 = new buLinearPath(list);
						ConvexEntitiesForMilling.Add(item2);
					}
				}
				else
				{
					buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
					ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
					ModifiedFirstEntity.Info.CamSelected = false;
					buEntity.Copy(LastEntity, ref ModifiedLastEntity);
					ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
					ModifiedLastEntity.Info.CamSelected = false;
				}
			}
			else if (!(num <= 0.0))
			{
				concaveLength /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
				if (FirstEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength, StartPointType.Start, ref ModifiedFirstEntity);
					list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.StartPoint));
					list.Add(buVector5.ToPoint3D(pntTouch));
					ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
				}
				if (FirstEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength, StartPointType.End, ref ModifiedFirstEntity);
					list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.EndPoint));
					list.Add(buVector5.ToPoint3D(pntTouch));
					ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
				}
				if (SecondEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength, StartPointType.Start, ref ModifiedLastEntity);
					list.Add(buVector5.ToPoint3D(ModifiedLastEntity.StartPoint));
					ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
				}
				if (SecondEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength, StartPointType.End, ref ModifiedLastEntity);
					list.Add(buVector5.ToPoint3D(ModifiedLastEntity.EndPoint));
					ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
				}
				ModifiedFirstEntity.Info.CamSelected = false;
				if (list.Count >= 2)
				{
					buLinearPath item3 = new buLinearPath(list);
					ConcaveEntitiesForMilling.Add(item3);
				}
			}
			else if (Pars.isConvex)
			{
				concaveLength2 /= Math.Cos(buConversion5.DegreeToRadian(FirstEntity.Orientation.A));
				if (FirstEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength2, StartPointType.Start, ref ModifiedFirstEntity);
					list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.StartPoint));
					list.Add(buVector5.ToPoint3D(pntTouch));
					ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
				}
				if (FirstEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(FirstEntity), buCall.buVector5_0.EntityLength(FirstEntity) - concaveLength2, StartPointType.End, ref ModifiedFirstEntity);
					list.Add(buVector5.ToPoint3D(ModifiedFirstEntity.EndPoint));
					list.Add(buVector5.ToPoint3D(pntTouch));
					ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
				}
				if (SecondEntityTouchPoint == StartEndType.Start)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength2, StartPointType.Start, ref ModifiedLastEntity);
					list.Add(buVector5.ToPoint3D(ModifiedLastEntity.StartPoint));
					ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
				}
				if (SecondEntityTouchPoint == StartEndType.End)
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(LastEntity), buCall.buVector5_0.EntityLength(LastEntity) - concaveLength2, StartPointType.End, ref ModifiedLastEntity);
					list.Add(buVector5.ToPoint3D(ModifiedLastEntity.EndPoint));
					ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
				}
				ModifiedFirstEntity.Info.CamSelected = false;
				if (list.Count >= 2)
				{
					buLinearPath item4 = new buLinearPath(list);
					ConvexEntitiesForMilling.Add(item4);
				}
			}
			else
			{
				buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
				ModifiedFirstEntity.Info = new EntityInfo(FirstEntity.Info);
				ModifiedFirstEntity.Info.CamSelected = false;
				buEntity.Copy(LastEntity, ref ModifiedLastEntity);
				ModifiedLastEntity.Info = new EntityInfo(LastEntity.Info);
				ModifiedLastEntity.Info.CamSelected = false;
			}
		}
		else
		{
			buEntity.Copy(FirstEntity, ref ModifiedFirstEntity);
			ModifiedFirstEntity.Info.CamSelected = false;
			buEntity.Copy(LastEntity, ref ModifiedLastEntity);
			ModifiedLastEntity.Info.CamSelected = false;
		}
	}

	public void EntityModifyByConvexConcave(List<buEntity> refEntities, marbleConvexConcaveCalculationPars Pars, ToolBase5 ToolSaw, MarbleItemSettings Settings, ref List<List<buEntity>> SawEntities, ref List<List<buEntity>> ConcaveEntities, ref List<List<buEntity>> ConvexEntities)
	{
		string text = "EntityModifyByConvexConcave";
		try
		{
			List<DoubleString> list = new List<DoubleString>();
			List<DoubleString> list2 = new List<DoubleString>();
			List<DoubleString> list3 = new List<DoubleString>();
			List<DoubleString> list4 = new List<DoubleString>();
			List<DoubleString> list5 = new List<DoubleString>();
			List<DoubleString> list6 = new List<DoubleString>();
			List<Point3D> Points = new List<Point3D>();
			new Point3D();
			Point3D refPoint = new Point3D();
			ClockDirectionType clockDirectionType = ClockDirectionType.CCW;
			double num = 99999999.0;
			double num2 = Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.TargetZ;
			if (refEntities.Count < 2 || ((refEntities[0] is buArc) & (refEntities[refEntities.Count - 1].GetType() != typeof(buArc))))
			{
			}
			if (SawEntities == null)
			{
				SawEntities = new List<List<buEntity>>();
			}
			if (ConcaveEntities == null)
			{
				ConcaveEntities = new List<List<buEntity>>();
			}
			if (ConvexEntities == null)
			{
				ConvexEntities = new List<List<buEntity>>();
			}
			List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
			List<buEntity> tempConcave = new List<buEntity>();
			List<buEntity> list7 = new List<buEntity>();
			new List<buEntity>();
			List<buEntity> BaseRefEntities = new List<buEntity>();
			List<buEntity> SortedEntities = new List<buEntity>();
			SortbuSettings sortbuSettings = new SortbuSettings();
			if (!(Settings.settingMarbleCam.SawForwardStepDownDistance < num2))
			{
				if (!(Settings.settingMarbleCam.SawForwardStepFirstDownDistance > 0.0))
				{
					list.Add(new DoubleString(Settings.settingMarbleCam.TargetZ, "Normal"));
				}
				else
				{
					list.Add(new DoubleString(Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardStepFirstDownDistance, "First"));
					list.Add(new DoubleString(Settings.settingMarbleCam.TargetZ, "Normal"));
				}
			}
			else
			{
				double startValue = Settings.MaterialParameter.MaterialThickness;
				double targetZ = Settings.settingMarbleCam.TargetZ;
				if (Settings.settingMarbleCam.SawForwardStepFirstDownDistance > 0.0)
				{
					list.Add(new DoubleString(Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardStepFirstDownDistance, "First"));
					startValue = Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardStepFirstDownDistance;
				}
				List<double> CalcValues = new List<double>();
				buNumeric5.StepCalculation(startValue, targetZ, Settings.settingMarbleCam.SawForwardStepDownDistance, ref CalcValues);
				for (int i = 0; i <= CalcValues.Count - 1; i++)
				{
					list.Add(new DoubleString(CalcValues[i], "Normal"));
				}
			}
			if (!(Settings.settingMarbleCam.SawForwardCircularStepDownDistance < num2))
			{
				if (!(Settings.settingMarbleCam.SawForwardCircularStepFirstDownDistance > 0.0))
				{
					list2.Add(new DoubleString(Settings.settingMarbleCam.TargetZ, "Normal"));
				}
				else
				{
					list.Add(new DoubleString(Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardStepFirstDownDistance, "First"));
					list.Add(new DoubleString(Settings.settingMarbleCam.TargetZ, "Normal"));
				}
			}
			else
			{
				double startValue2 = Settings.MaterialParameter.MaterialThickness;
				double targetZ2 = Settings.settingMarbleCam.TargetZ;
				if (Settings.settingMarbleCam.SawForwardCircularStepFirstDownDistance > 0.0)
				{
					list2.Add(new DoubleString(Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardCircularStepFirstDownDistance, "First"));
					startValue2 = Settings.MaterialParameter.MaterialThickness - Settings.settingMarbleCam.SawForwardCircularStepFirstDownDistance;
				}
				List<double> CalcValues2 = new List<double>();
				buNumeric5.StepCalculation(startValue2, targetZ2, Settings.settingMarbleCam.SawForwardCircularStepDownDistance, ref CalcValues2);
				for (int j = 0; j <= CalcValues2.Count - 1; j++)
				{
					list2.Add(new DoubleString(CalcValues2[j], "Normal"));
				}
			}
			clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(refEntities);
			for (int k = 0; k <= refEntities.Count - 1; k++)
			{
				if (!(refEntities[k] is buLinearPath))
				{
					buEntity buEntity2 = buEntity.Copy(refEntities[k]);
					buEntity2.Info.EntityIndex = k;
					buEntity2.Info.EntitySubIndex = Pars.EntitySubIndex;
					if (!(buEntity2 is buArc))
					{
						if (!(buEntity2 is buCurve))
						{
							BaseRefEntities.Add(buEntity2);
						}
						else if (Pars.isInside)
						{
							BaseRefEntities.Add(buEntity2);
						}
						else if (!varOperation.settingMarbleCam.OutsideArcCuttingByMilling)
						{
							BaseRefEntities.Add(buEntity2);
						}
						else
						{
							List<buEntity> list8 = new List<buEntity>();
							list8.Add(buEntity2);
							ConvexEntities.Add(list8);
						}
					}
					else if (Pars.isInside)
					{
						BaseRefEntities.Add(buEntity2);
					}
					else
					{
						buArc buArc2 = buEntity2 as buArc;
						if (!varOperation.settingMarbleCam.OutsideArcCuttingByMilling || !(buArc2.Radius * 2.0 <= varOperation.settingMarbleCam.OutsideArcCuttingMinDiameterBySaw))
						{
							BaseRefEntities.Add(buEntity2);
						}
						else
						{
							List<buEntity> list9 = new List<buEntity>();
							if (buCompare5.EQ(buArc2.Plane.Equation.Z, -1.0) && clockDirectionType == ClockDirectionType.CCW)
							{
								buEntity2.Marble.isConcave = true;
								if (buEntity2.Info.OffsetABC == null)
								{
									buEntity2.Info.OffsetABC = new PointABC();
								}
								buEntity2.Info.OffsetABC.C = 180.0;
							}
							list9.Add(buEntity2);
							if (buEntity2.Marble.isConcave)
							{
								ConcaveEntities.Add(list9);
							}
							else
							{
								ConvexEntities.Add(list9);
							}
						}
					}
					if (!(refEntities[k].Length() > Pars.MinLength))
					{
						continue;
					}
					if (!(refEntities[k] is buArc))
					{
						double num3 = Point3D.Distance(new Point3D(), refEntities[k].StartPoint);
						if (num3 < num)
						{
							refPoint = buVector5.ToPoint3D(refEntities[k].StartPoint);
							num = num3;
						}
					}
					else
					{
						if (Pars.isInside)
						{
							continue;
						}
						if (clockDirectionType != ClockDirectionType.CCW)
						{
							double num4 = Point3D.Distance(new Point3D(), refEntities[k].EndPoint);
							if (num4 < num)
							{
								refPoint = buVector5.ToPoint3D(refEntities[k].EndPoint);
								num = num4;
							}
						}
						else
						{
							double num5 = Point3D.Distance(new Point3D(), refEntities[k].StartPoint);
							if (num5 < num)
							{
								refPoint = buVector5.ToPoint3D(refEntities[k].StartPoint);
								num = num5;
							}
						}
					}
					continue;
				}
				bool flag = false;
				for (int l = 1; l <= refEntities[k].Vertices.Count - 1; l++)
				{
					double num6 = Point3D.Distance(refEntities[k].Vertices[l - 1], refEntities[k].Vertices[l]);
					if (num6 < 15.0)
					{
						flag = true;
						l = refEntities[k].Vertices.Count;
					}
				}
				if (!flag)
				{
					for (int m = 1; m <= refEntities[k].Vertices.Count - 1; m++)
					{
						buLine buLine2 = new buLine(refEntities[k].Vertices[m - 1], refEntities[k].Vertices[m]);
						buLine2.Info.EntityIndex = k;
						buLine2.Info.EntitySubIndex = Pars.EntitySubIndex;
						BaseRefEntities.Add(buLine2);
					}
				}
				else
				{
					buEntity buEntity3 = buEntity.Copy(refEntities[k]);
					buEntity3.Info.EntityIndex = k;
					buEntity3.Info.EntitySubIndex = Pars.EntitySubIndex;
					BaseRefEntities.Add(buEntity3);
				}
			}
			sortbuSettings.Option.PreferLineIfAvailableForFirstTouch = true;
			if (!(!varOperation.settingMarbleCam.OutsideArcCuttingByMilling | (varOperation.settingMarbleCam.OutsideArcCuttingByMilling & (ConvexEntities.Count == 0))))
			{
				SplitedEntitites.Add(BaseRefEntities);
			}
			else
			{
				buCall.buVector5_0.SortEntitiesByRefPoint(refPoint, ref BaseRefEntities, sortbuSettings, ref SortedEntities);
				buCall.buVector5_0.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			}
			for (int n = 0; n <= SplitedEntitites.Count - 1; n++)
			{
				ClockDirectionType clockDirection = buCall.buVector5_0.GetClockDirection(SplitedEntitites[n]);
				if (n != 0)
				{
					if (clockDirection != Settings.settingMarbleCam.ContourInsideDirection)
					{
						List<buEntity> ChangedEntities = SplitedEntitites[n];
						buCall.buVector5_0.ChangeEntitiesDirection(ref ChangedEntities);
					}
				}
				else if (Pars.isInside)
				{
					if (clockDirection != Settings.settingMarbleCam.ContourInsideDirection)
					{
						List<buEntity> ChangedEntities2 = SplitedEntitites[n];
						buCall.buVector5_0.ChangeEntitiesDirection(ref ChangedEntities2);
					}
				}
				else if (clockDirection != Settings.settingMarbleCam.ContourDirection)
				{
					List<buEntity> ChangedEntities3 = SplitedEntitites[n];
					buCall.buVector5_0.ChangeEntitiesDirection(ref ChangedEntities3);
				}
				List<buEntity> tempSawEntities = new List<buEntity>();
				List<buEntity> list10 = new List<buEntity>();
				List<buEntity> list11 = new List<buEntity>();
				clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(SplitedEntitites[n]);
				buCall.buVector5_0.isEntitiesClosed(SplitedEntitites[n]);
				buEntity EPre = null;
				buEntity ECur = null;
				buEntity ENext = null;
				tempConcave.Clear();
				list7.Clear();
				Pars.FirstCornerCalculated = false;
				if (n > 0)
				{
					Pars.isInside = true;
				}
				for (int num7 = 0; num7 <= SplitedEntitites[n].Count - 1; num7++)
				{
					if ((SplitedEntitites[n][num7] is buLine) & (SplitedEntitites[n][num7].sortDirection == entitySortDirection.Reverse))
					{
						buFunctions.ExchangeDatas(ref SplitedEntitites[n][num7].StartPoint, ref SplitedEntitites[n][num7].EndPoint);
						SplitedEntitites[n][num7].Vertices.Reverse();
						SplitedEntitites[n][num7].sortDirection = entitySortDirection.Normal;
					}
					if (!(SplitedEntitites[n][num7] is buArc))
					{
						continue;
					}
					buArc buArc3 = SplitedEntitites[n][num7] as buArc;
					buArc3.Marble.isConcave = false;
					if (buCompare5.EQ(buArc3.Plane.Equation.Z, -1.0))
					{
						buArc3 = new buArc(buArc3.Center, buArc3.EndPoint, buArc3.StartPoint);
						buArc3.Marble = new MarbleInfo(SplitedEntitites[n][num7].Marble);
						if (clockDirectionType == ClockDirectionType.CCW)
						{
							buArc3.Marble.isConcave = true;
							if (buArc3.Info.OffsetABC == null)
							{
								buArc3.Info.OffsetABC = new PointABC();
							}
							buArc3.Info.OffsetABC.C = 180.0;
							if (varOperation.settingMarbleCam.ConcaveArcOffsetType == MarbleConcaveArcOffsetCalculationType.ChangeAngleA)
							{
								ConcaveArcAngleACalculation(buArc3.Radius, ToolSaw.Geometry.Diameter, ref buArc3.Marble.ExtraAngleA);
							}
						}
					}
					SplitedEntitites[n][num7] = buArc3;
				}
				for (int num8 = 0; num8 <= SplitedEntitites[n].Count - 1; num8++)
				{
					if (SplitedEntitites[n][num8].Marble == null)
					{
						SplitedEntitites[n][num8].Marble = new MarbleInfo();
					}
					if (num8 != 0)
					{
						if (num8 != SplitedEntitites[n].Count - 1)
						{
							ENext = SplitedEntitites[n][num8 + 1];
							EPre = SplitedEntitites[n][num8 - 1];
						}
						else
						{
							ENext = null;
							if (tempSawEntities.Count > 0)
							{
								ENext = tempSawEntities[0];
							}
							EPre = SplitedEntitites[n][num8 - 1];
						}
					}
					else
					{
						ECur = SplitedEntitites[n][num8];
						if (SplitedEntitites[n].Count > 1)
						{
							EPre = SplitedEntitites[n][SplitedEntitites[n].Count - 1];
							ENext = SplitedEntitites[n][num8 + 1];
						}
					}
					if (ENext != null && ENext.Marble == null)
					{
						ENext.Marble = new MarbleInfo();
					}
					if (EPre != null && EPre.Marble == null)
					{
						EPre.Marble = new MarbleInfo();
					}
					List<Point3D> Points2 = new List<Point3D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(ECur, 0.01, ref Points);
					if (!(ECur is buArc))
					{
						Points2.Add(Points[0]);
						Points2.Add(Points[1]);
					}
					else
					{
						Points2.Add(Points[Points.Count - 2]);
						Points2.Add(Points[Points.Count - 1]);
					}
					Points = new List<Point3D>();
					if (ENext != null)
					{
						buCall.buVector5_0.EntitiesToPointsWithCamDirection(ENext, 0.01, ref Points);
						Points2.Add(Points[0]);
						Points2.Add(Points[1]);
						buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points2);
					}
					ClockDirectionType clockDirectionType2 = buCall.buVector5_0.GetClockDirection(Points2);
					if (ECur is buCircle || ECur is buEllipse)
					{
						clockDirectionType2 = ClockDirectionType.CCW;
					}
					if (!((!Pars.isInside && clockDirectionType2 != clockDirectionType) | (Pars.isInside && clockDirectionType2 == clockDirectionType)))
					{
						if (varOperation.settingMarbleCam.ConvexCuttingType != MarbleConcaveCuttingType.None)
						{
							CutEntityConcaveCorner(n, num8, isConcave: false, ref EPre, ref ECur, ref ENext, ref SplitedEntitites, ToolSaw, ref Pars, ref tempConcave, ref tempSawEntities, ref ConcaveEntities, ref ConvexEntities);
							continue;
						}
						if (num8 != 0)
						{
							if (num8 < SplitedEntitites[n].Count - 1 && ENext != null)
							{
								if (!(ENext is buArc))
								{
									tempSawEntities.Add(buEntity.Copy(ENext));
								}
								else
								{
									buArc buArc4 = ENext as buArc;
									if (!(buArc4.Radius * 2.0 > varOperation.settingMarbleCam.OutsideArcCuttingMinDiameterBySaw))
									{
										List<buEntity> list12 = new List<buEntity>();
										list12.Add(buEntity.Copy(ENext));
										if (!Pars.isInside)
										{
											ConvexEntities.Add(list12);
										}
										else
										{
											ConcaveEntities.Add(list12);
										}
									}
									else
									{
										tempSawEntities.Add(buEntity.Copy(ENext));
									}
								}
							}
						}
						else
						{
							tempSawEntities.Add(buEntity.Copy(ECur));
							if (ENext != null)
							{
								if (!(ENext is buArc))
								{
									tempSawEntities.Add(buEntity.Copy(ENext));
								}
								else
								{
									buArc buArc5 = ENext as buArc;
									if (!(buArc5.Radius * 2.0 > varOperation.settingMarbleCam.OutsideArcCuttingMinDiameterBySaw))
									{
										List<buEntity> list13 = new List<buEntity>();
										list13.Add(buEntity.Copy(ENext));
										if (!Pars.isInside)
										{
											ConvexEntities.Add(list13);
										}
										else
										{
											ConcaveEntities.Add(list13);
										}
									}
									else
									{
										tempSawEntities.Add(buEntity.Copy(ENext));
									}
								}
							}
						}
						ECur = ENext;
					}
					else
					{
						_ = SplitedEntitites[n];
						CutEntityConcaveCorner(n, num8, isConcave: true, ref EPre, ref ECur, ref ENext, ref SplitedEntitites, ToolSaw, ref Pars, ref tempConcave, ref tempSawEntities, ref ConcaveEntities, ref ConvexEntities);
					}
				}
				if (tempConcave.Count > 1)
				{
					ConcaveEntities.Add(tempConcave);
				}
				for (int num9 = 0; num9 <= tempSawEntities.Count - 1; num9++)
				{
					tempSawEntities[num9].Marble.indexEdge = num9;
					tempSawEntities[num9].Marble.isInside = Pars.isInside;
					if (!(tempSawEntities[num9].GetType() != typeof(buLine)))
					{
						list10.Add(tempSawEntities[num9]);
					}
					else
					{
						list11.Add(tempSawEntities[num9]);
					}
				}
				if ((Settings.settingMarbleCam.SawForwardCircularStepFirstDownDistance > 0.0) & (list2.Count >= 2))
				{
					list4.Add(list2[0]);
					list2.RemoveAt(0);
				}
				if ((Settings.settingMarbleCam.SawForwardStepFirstDownDistance > 0.0) & (list.Count >= 2))
				{
					list3.Add(list[0]);
					list.RemoveAt(0);
				}
				if (Settings.settingMarbleCam.LastStepAtSameTime)
				{
					if (list2.Count >= 1)
					{
						list6.Add(list2[list2.Count - 1]);
						list2.RemoveAt(list2.Count - 1);
					}
					if (list.Count >= 1)
					{
						list5.Add(list[list.Count - 1]);
						list.RemoveAt(list.Count - 1);
					}
				}
				if (list4.Count > 0)
				{
					OffsetEntitiesByLevel(list11, list4, IsCircular: true, CamStepSequenceType.FirstStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
				}
				if (list3.Count > 0)
				{
					OffsetEntitiesByLevel(list10, list3, IsCircular: false, CamStepSequenceType.FirstStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
				}
				if (Settings.settingMarbleCam.StepType == MarbleStepType.Level)
				{
					if ((list11.Count > 0) & (list2.Count > 0))
					{
						OffsetEntitiesByLevel(list11, list2, IsCircular: true, CamStepSequenceType.NormalStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
					}
					if ((list10.Count > 0) & (list.Count > 0))
					{
						OffsetEntitiesByLevel(list10, list, IsCircular: false, CamStepSequenceType.NormalStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
					}
				}
				if (Settings.settingMarbleCam.StepType == MarbleStepType.Region)
				{
					if ((list11.Count > 0) & (list2.Count > 0))
					{
						OffsetEntitiesByRegion(list11, list2, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
					}
					if ((list10.Count > 0) & (list.Count > 0))
					{
						OffsetEntitiesByRegion(list10, list, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
					}
				}
				if (list6.Count > 0)
				{
					OffsetEntitiesByLevel(list11, list6, IsCircular: true, CamStepSequenceType.LastStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
				}
				if (list5.Count > 0)
				{
					OffsetEntitiesByLevel(list10, list5, IsCircular: false, CamStepSequenceType.LastStep, clockDirectionType, Pars, ToolSaw, Settings, ref SawEntities);
				}
				list11.Clear();
				tempSawEntities.Clear();
				list10.Clear();
				list2.Clear();
				list.Clear();
				list4.Clear();
				list3.Clear();
				list6.Clear();
				list5.Clear();
			}
			if (SawEntities != null)
			{
				for (int num10 = 0; num10 <= SawEntities.Count - 1; num10++)
				{
					for (int num11 = 0; num11 <= SawEntities[num10].Count - 1; num11++)
					{
						if (SawEntities[num10][num11].Marble != null)
						{
							SawEntities[num10][num11].Marble.isInside = Pars.isInside;
						}
					}
				}
			}
			if (ConcaveEntities != null)
			{
				for (int num12 = 0; num12 <= ConcaveEntities.Count - 1; num12++)
				{
					for (int num13 = 0; num13 <= ConcaveEntities[num12].Count - 1; num13++)
					{
						if (ConcaveEntities[num12][num13].Marble != null)
						{
							ConcaveEntities[num12][num13].Marble.isInside = Pars.isInside;
						}
					}
				}
			}
			if (ConvexEntities == null)
			{
				return;
			}
			for (int num14 = 0; num14 <= ConvexEntities.Count - 1; num14++)
			{
				for (int num15 = 0; num15 <= ConvexEntities[num14].Count - 1; num15++)
				{
					if (ConvexEntities[num14][num15].Marble != null)
					{
						ConvexEntities[num14][num15].Marble.isInside = Pars.isInside;
					}
				}
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, ex.Message, "Exception");
			buException.throwException(ex, text, ShowMessageBox: true, "Exception");
		}
	}

	public void ConcaveArcOffsetCalculation(double arcRadius, double bladeDiameter, double materialThickness, ref double CalcOffset)
	{
		try
		{
			double num = bladeDiameter / 2.0;
			if (materialThickness > 0.0 && !(arcRadius <= 0.0) && !(num <= 0.0) && !(materialThickness >= arcRadius))
			{
				double d = Math.Acos((arcRadius - materialThickness) / arcRadius);
				CalcOffset = num * (1.0 - Math.Cos(d));
			}
		}
		catch (Exception)
		{
		}
	}

	public void ConcaveArcAngleACalculation(double ArcRadius, double SawDiameter, ref double CalcA)
	{
		try
		{
			double num = SawDiameter / 2.0;
			double num2 = Math.Asin(num / (ArcRadius + num));
			CalcA = num2 * 180.0 / Math.PI;
			if (CalcA > 45.0)
			{
				CalcA = 45.0;
			}
		}
		catch (Exception)
		{
		}
	}

	public void OffsetEntitiesByLevel(List<buEntity> tempEntities, List<DoubleString> StepValues, bool IsCircular, CamStepSequenceType StepType, ClockDirectionType CDRefEnt, marbleConvexConcaveCalculationPars Pars, ToolBase5 ToolSaw, MarbleItemSettings Settings, ref List<List<buEntity>> SawEntities)
	{
		try
		{
			for (int i = 0; i <= tempEntities.Count - 1; i++)
			{
				buCall.buVector5_0.GetClockDirection(tempEntities[i].Vertices);
				CamCuttingDirectionType camCuttingDirectionType = varOperation.settingMarbleCam.CuttingDirection;
				bool flag = varOperation.settingMarbleCam.DontMoveSafeForForwardBackwardDirection;
				if ((tempEntities[i] is buCircle) | (tempEntities[i] is buEllipse))
				{
					camCuttingDirectionType = CamCuttingDirectionType.Forward;
					flag = false;
				}
				int num = 0;
				for (int j = 0; j <= StepValues.Count - 1; j++)
				{
					List<buEntity> refEntities = new List<buEntity>();
					buEntity copiedEntity = null;
					buEntity.Copy(tempEntities[i], ref copiedEntity);
					refEntities.Add(copiedEntity);
					buCall.buVector5_0.Move(0.0, 0.0, StepValues[j].Value, ref refEntities);
					for (int k = 0; k <= refEntities.Count - 1; k++)
					{
						refEntities[k].Info.Commands = new List<string>();
						refEntities[k].Info.Options = new List<string>();
						if (k == 0)
						{
							refEntities[k].Info.Options.Add(buLangTranslate.preDef.Step + " : " + StepValues[j].Value.ToString("f1"));
						}
						if (!IsCircular)
						{
							if (j == 0)
							{
								refEntities[k].Info.Options.Add(buLangTranslate.preDef.Linear + " " + buLangTranslate.preDef.Moving + " " + buLangTranslate.preDef.Length + " : " + refEntities[k].Length().ToString("f1"));
							}
							refEntities[k].Info.Commands.Add(EntityCommands.NoneCircularMove.ToString());
						}
						else
						{
							if (j == 0)
							{
								string text = "";
								if (!(refEntities[k] is buArc))
								{
									if (refEntities[k] is buCircle)
									{
										text = " " + buLangTranslate.preDef.Diameter + " : " + (((buCircle)refEntities[k]).Radius * 2.0).ToString("f1");
									}
								}
								else
								{
									text = " " + buLangTranslate.preDef.Diameter + " : " + (((buArc)refEntities[k]).Radius * 2.0).ToString("f1");
								}
								refEntities[k].Info.Options.Add(buLangTranslate.preDef.Circular + " " + buLangTranslate.preDef.Moving + text);
							}
							refEntities[k].Info.Commands.Add(EntityCommands.CircularMove.ToString());
						}
						if (StepType != CamStepSequenceType.FirstStep)
						{
							if (StepType != CamStepSequenceType.NormalStep)
							{
								if (StepType == CamStepSequenceType.LastStep)
								{
									refEntities[k].Info.Commands.Add(EntityCommands.LastStep.ToString());
								}
							}
							else
							{
								refEntities[k].Info.Commands.Add(EntityCommands.NormalStep.ToString());
							}
						}
						else
						{
							refEntities[k].Info.Options.Add(buLangTranslate.preDef.First + " " + buLangTranslate.preDef.Step);
							refEntities[k].Info.Commands.Add(EntityCommands.FirstStep.ToString());
						}
						if (camCuttingDirectionType == CamCuttingDirectionType.Forward)
						{
							refEntities[k].Info.Commands.Add(EntityCommands.ForwardCut.ToString());
						}
					}
					if (camCuttingDirectionType != CamCuttingDirectionType.Forward)
					{
						List<List<buEntity>> SawEntities2 = new List<List<buEntity>>();
						OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities2);
						for (int l = 0; l <= SawEntities2.Count - 1; l++)
						{
							if (num % 2 != 0)
							{
								for (int m = 0; m <= SawEntities2[l].Count - 1; m++)
								{
									buCall.buVector5_0.CamDirectionChange(ref SawEntities2[l][m].sortDirection);
									if (SawEntities2[l][m].Info.OffsetABC == null)
									{
										SawEntities2[l][m].Info.OffsetABC = new PointABC();
									}
									if (SawEntities2[l][m].Info.OffsetABC.C != 0.0)
									{
										if (SawEntities2[l][m].Info.OffsetABC.C == 180.0)
										{
											SawEntities2[l][m].Info.OffsetABC.C = 0.0;
										}
									}
									else
									{
										SawEntities2[l][m].Info.OffsetABC.C = 180.0;
									}
									if ((SawEntities2[l][m] is buCircle) | (SawEntities2[l][m] is buEllipse))
									{
									}
									if (SawEntities2[l][m].Info.Commands == null)
									{
										SawEntities2[l][m].Info.Commands = new List<string>();
									}
									SawEntities2[l][m].Info.Commands.Add(EntityCommands.BackwardCut.ToString());
									if (j < StepValues.Count - 1 && flag && StepType != CamStepSequenceType.FirstStep)
									{
										SawEntities2[l][m].Info.Commands.Add(EntityCommands.DontMoveSafe.ToString());
									}
								}
								SawEntities.Add(SawEntities2[l]);
								continue;
							}
							for (int n = 0; n <= SawEntities2[l].Count - 1; n++)
							{
								SawEntities2[l][n].Info.Commands.Add(EntityCommands.ForwardCut.ToString());
								if (j < StepValues.Count - 1 && flag && StepType != CamStepSequenceType.FirstStep)
								{
									SawEntities2[l][n].Info.Commands.Add(EntityCommands.DontMoveSafe.ToString());
								}
							}
							SawEntities.Add(SawEntities2[l]);
						}
					}
					else
					{
						OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities);
					}
					refEntities.Clear();
					num++;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void OffsetEntitiesByRegion(List<buEntity> tempEntities, List<DoubleString> StepValues, ClockDirectionType CDRefEnt, marbleConvexConcaveCalculationPars Pars, ToolBase5 ToolSaw, MarbleItemSettings Settings, ref List<List<buEntity>> SawEntities)
	{
		try
		{
			for (int i = 0; i <= StepValues.Count - 1; i++)
			{
				for (int j = 0; j <= tempEntities.Count - 1; j++)
				{
					CamCuttingDirectionType camCuttingDirectionType = varOperation.settingMarbleCam.CuttingDirection;
					if ((tempEntities[j] is buCircle) | (tempEntities[j] is buEllipse))
					{
						camCuttingDirectionType = CamCuttingDirectionType.Forward;
					}
					int num = 0;
					List<buEntity> refEntities = new List<buEntity>();
					buEntity copiedEntity = null;
					buEntity.Copy(tempEntities[j], ref copiedEntity);
					refEntities.Add(copiedEntity);
					buCall.buVector5_0.Move(0.0, 0.0, StepValues[i].Value, ref refEntities);
					if (camCuttingDirectionType != CamCuttingDirectionType.Forward)
					{
						List<List<buEntity>> SawEntities2 = new List<List<buEntity>>();
						OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities2);
						for (int k = 0; k <= SawEntities2.Count - 1; k++)
						{
							if (num % 2 != 0)
							{
								for (int l = 0; l <= SawEntities2[k].Count - 1; l++)
								{
									buCall.buVector5_0.CamDirectionChange(ref SawEntities2[k][l].sortDirection);
									if (SawEntities2[k][l].Info.OffsetABC == null)
									{
										SawEntities2[k][l].Info.OffsetABC = new PointABC();
									}
									SawEntities2[k][l].Info.OffsetABC.C = 180.0;
								}
								SawEntities.Add(SawEntities2[k]);
							}
							else
							{
								SawEntities.Add(SawEntities2[k]);
							}
						}
					}
					else
					{
						OffsetModifiedEntities(refEntities, CDRefEnt, Pars, ToolSaw, Settings, ref SawEntities);
					}
					refEntities.Clear();
					num++;
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void CutEntityConcaveCorner(ref List<buEntity> EL, ToolBase5 ToolSaw, marbleConvexConcaveCalculationPars Pars, ref List<buEntity> tempSawEntities, ref List<List<buEntity>> ConcaveEntities)
	{
		try
		{
			double num = Pars.ConcaveLength;
			List<buEntity> list = new List<buEntity>();
			for (int i = 0; i <= EL.Count - 1; i++)
			{
				if (!(EL[i].GetType() != typeof(buLine)))
				{
					list.Add(buEntity.Copy(EL[i]));
					continue;
				}
				if (EL[i].Orientation.A != 0.0)
				{
					double num2 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, EL[i].Orientation.A);
					num = num2 + varOperation.settingMarbleCam.InnerCutSafeDistance;
				}
				double num3 = EL[i].Length();
				if (!(num3 < num))
				{
					buEntity CalcEntity = null;
					buEntity CuttedEntity = null;
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(EL[i]), buCall.buVector5_0.EntityLength(EL[i]) - num, StartPointType.End, ref CalcEntity, ref CuttedEntity);
					list.Add(CuttedEntity);
					CalcEntity = null;
					CuttedEntity = null;
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(EL[i]), buCall.buVector5_0.EntityLength(EL[i]) - num, StartPointType.Start, ref CalcEntity, ref CuttedEntity);
					list.Add(CuttedEntity);
					CalcEntity = null;
					CuttedEntity = null;
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(EL[i]), buCall.buVector5_0.EntityLength(EL[i]) - num, StartPointType.StartAndEnd, ref CalcEntity, ref CuttedEntity);
					tempSawEntities.Add(CalcEntity);
				}
				else
				{
					list.Add(buEntity.Copy(EL[i]));
				}
			}
			if (list.Count > 0)
			{
			}
		}
		catch (Exception)
		{
		}
	}

	public void CutEntityConcaveCorner(int i, int j, bool isConcave, ref buEntity EPre, ref buEntity ECur, ref buEntity ENext, ref List<List<buEntity>> ELL, ToolBase5 ToolSaw, ref marbleConvexConcaveCalculationPars Pars, ref List<buEntity> tempConcave, ref List<buEntity> tempSawEntities, ref List<List<buEntity>> ConcaveEntities, ref List<List<buEntity>> ConvexEntities)
	{
		buEntity CalcEntity = null;
		buEntity CalcEntity2 = null;
		buEntity CuttedEntity = null;
		buEntity CuttedEntity2 = null;
		double num = ECur.Length();
		double num2 = 0.0;
		double num3 = varOperation.settingMarbleCam.InnerCutSafeDistance;
		if (!isConcave)
		{
			num3 = varOperation.settingMarbleCam.OutterCutSafeDistance;
		}
		if (ECur == null || !((ECur is buEllipse) | (ECur is buCircle)))
		{
			if (ENext != null)
			{
				num2 = ENext.Length();
			}
			if (j != 0)
			{
				bool flag = false;
				if ((num > Pars.MinLength) | ECur.Marble.Trimmed)
				{
					flag = true;
					if (Pars.isInside & (ECur.GetType() != typeof(buLine)))
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num4 = Pars.ConcaveLength;
					if (!isConcave)
					{
						num4 = Pars.ConvexLength;
					}
					if (tempSawEntities[tempSawEntities.Count - 1].Orientation.A != 0.0)
					{
						double num5 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
						num4 = num5 + num3;
					}
					bool flag2 = false;
					if (tempSawEntities[tempSawEntities.Count - 1].Length() < num4)
					{
						flag2 = true;
					}
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.buVector5_0.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					if (CuttedEntity2 != null && ((j < ELL[i].Count - 1) | ((j == ELL[i].Count - 1) & !Pars.FirstCornerCalculated)) && CalcEntity != null && CalcEntity.Marble != null && ((CalcEntity.Marble.TrimSide == StartEndBothNoneType.None) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Start)))
					{
						tempConcave.Add(CuttedEntity2);
					}
					if (CalcEntity != null)
					{
						if (CalcEntity.Marble != null)
						{
							if (ECur.sortDirection != entitySortDirection.Normal)
							{
								if (!((CalcEntity.Marble.TrimSide == StartEndBothNoneType.End) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Both)))
								{
									CalcEntity.Marble.TrimSide = StartEndBothNoneType.Start;
								}
								else
								{
									CalcEntity.Marble.TrimSide = StartEndBothNoneType.Both;
								}
							}
							else if (!((CalcEntity.Marble.TrimSide == StartEndBothNoneType.Start) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Both)))
							{
								CalcEntity.Marble.TrimSide = StartEndBothNoneType.End;
							}
							else
							{
								CalcEntity.Marble.TrimSide = StartEndBothNoneType.Both;
							}
							CalcEntity.Marble.Trimmed = true;
						}
						if (flag2)
						{
							tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
						}
						else
						{
							tempSawEntities[tempSawEntities.Count - 1] = CalcEntity;
						}
					}
				}
			}
			else
			{
				double num6 = Pars.ConcaveLength;
				if (!isConcave)
				{
					num6 = Pars.ConvexLength;
				}
				if (ECur.Orientation.A != 0.0)
				{
					double num7 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, ECur.Orientation.A);
					num6 = num7 + num3;
				}
				bool flag3 = false;
				bool flag4 = false;
				double num8 = ECur.Length();
				if (!(ECur.GetType() != typeof(buLine)))
				{
					if (num8 < Pars.MinLength)
					{
						flag3 = true;
					}
				}
				else
				{
					flag4 = true;
					if (Pars.isInside)
					{
						flag3 = true;
					}
				}
				if (!(flag3 || flag4))
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ECur), buCall.buVector5_0.EntityLength(ECur) - num6, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					tempConcave.Add(CuttedEntity2);
					tempSawEntities.Add(CalcEntity);
					if (CalcEntity.Marble != null)
					{
						CalcEntity.Marble.Trimmed = true;
					}
				}
				else if (EPre != null)
				{
					double num9 = EPre.Length();
					if (num9 > Pars.MinLength)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(EPre), buCall.buVector5_0.EntityLength(EPre) - num6, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					}
					if (CuttedEntity2 != null)
					{
						tempConcave.Add(CuttedEntity2);
					}
					tempConcave.Add(buEntity.Copy(ECur));
					Pars.FirstCornerCalculated = true;
				}
			}
			bool flag5 = false;
			if ((num2 > Pars.MinLength) | (ENext != null && ENext.Marble.Trimmed))
			{
				flag5 = true;
				if (Pars.isInside && ENext != null && ENext.GetType() != typeof(buLine))
				{
					flag5 = false;
				}
			}
			if (!flag5)
			{
				if (ENext != null)
				{
					tempConcave.Add(buEntity.Copy(ENext));
					ECur = ENext;
				}
				return;
			}
			double num10 = Pars.ConcaveLength;
			if (!isConcave)
			{
				num10 = Pars.ConvexLength;
			}
			if (ENext != null && ENext.Orientation.A != 0.0)
			{
				double num11 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
				num10 = num11 + num3;
			}
			bool flag6 = false;
			if (ENext == null || !(ENext.Length() < num10))
			{
				if (ENext != null && ENext.GetType() != typeof(buLine) && ENext.Marble != null && ENext.Marble.isInside)
				{
					flag6 = true;
				}
			}
			else
			{
				flag6 = true;
			}
			if (!flag6 && ENext != null && ((j < ELL[i].Count - 1) | ((j == ELL[i].Count - 1) & !Pars.FirstCornerCalculated)))
			{
				buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ENext), buCall.buVector5_0.EntityLength(ENext) - num10, StartPointType.Start, ref CalcEntity2, ref CuttedEntity);
				tempConcave.Add(CuttedEntity);
			}
			if (CalcEntity2 != null && CalcEntity2.Marble != null)
			{
				if (ENext.sortDirection != entitySortDirection.Normal)
				{
					if (!((CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Start) | (CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Both)))
					{
						CalcEntity2.Marble.TrimSide = StartEndBothNoneType.End;
					}
					else
					{
						CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Both;
					}
				}
				else if (!((CalcEntity2.Marble.TrimSide == StartEndBothNoneType.End) | (CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Both)))
				{
					CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Start;
				}
				else
				{
					CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Both;
				}
				CalcEntity2.Marble.Trimmed = true;
			}
			if (j >= ELL[i].Count - 1)
			{
				if (CalcEntity2 != null)
				{
					if (flag6)
					{
						tempSawEntities.RemoveAt(0);
					}
					else
					{
						tempSawEntities[0] = CalcEntity2;
					}
				}
			}
			else if (CalcEntity2 != null && !flag6)
			{
				if (!(CalcEntity2 is buLine))
				{
					if (CalcEntity2 is buArc && CalcEntity2.Marble != null && !CalcEntity2.Marble.isInside)
					{
						tempSawEntities.Add(CalcEntity2);
					}
				}
				else
				{
					tempSawEntities.Add(CalcEntity2);
				}
			}
			ECur = CalcEntity2;
			if (tempConcave.Count <= 1)
			{
				return;
			}
			ClockDirectionType clockDirection = buCall.buVector5_0.GetClockDirection(tempConcave);
			if (!isConcave)
			{
				if (clockDirection != varOperation.settingMarbleCam.ConvexDirection)
				{
					buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
				}
			}
			else if (clockDirection != varOperation.settingMarbleCam.ConcaveDirection)
			{
				buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
			}
			if (!isConcave)
			{
				ConvexEntities.Add(tempConcave);
			}
			else
			{
				ConcaveEntities.Add(tempConcave);
			}
			tempConcave = new List<buEntity>();
		}
		else
		{
			if (!isConcave)
			{
				tempConcave.Add(buEntity.Copy(ECur));
				ConvexEntities.Add(tempConcave);
			}
			else
			{
				tempConcave.Add(buEntity.Copy(ECur));
				ConcaveEntities.Add(tempConcave);
			}
			tempConcave = new List<buEntity>();
		}
	}

	public void CutEntityConcaveCorner(int i, int j, bool isConcave, ref buEntity ECur, ref buEntity ENext, ref List<List<buEntity>> ELL, ToolBase5 ToolSaw, marbleConvexConcaveCalculationPars Pars, ref List<buEntity> tempConcave, ref List<buEntity> tempSawEntities, ref List<List<buEntity>> ConcaveEntities)
	{
		buEntity CalcEntity = null;
		buEntity CalcEntity2 = null;
		buEntity CuttedEntity = null;
		buEntity CuttedEntity2 = null;
		double num = ECur.Length();
		double num2 = 0.0;
		double num3 = varOperation.settingMarbleCam.InnerCutSafeDistance;
		if (!isConcave)
		{
			num3 = varOperation.settingMarbleCam.OutterCutSafeDistance;
		}
		if (ECur == null || !((ECur is buEllipse) | (ECur is buCircle)))
		{
			if (ENext != null)
			{
				num2 = ENext.Length();
			}
			if (j != 0)
			{
				bool flag = false;
				if ((num > Pars.MinLength) | ECur.Marble.Trimmed)
				{
					flag = true;
					if (Pars.isInside & (ECur.GetType() != typeof(buLine)))
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num4 = Pars.ConcaveLength;
					if (!isConcave)
					{
						num4 = Pars.ConvexLength;
					}
					if (tempSawEntities[tempSawEntities.Count - 1].Orientation.A != 0.0)
					{
						double num5 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
						num4 = num5 + num3;
					}
					bool flag2 = false;
					if (tempSawEntities[tempSawEntities.Count - 1].Length() < num4)
					{
						flag2 = true;
					}
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.buVector5_0.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					if (CuttedEntity2 != null)
					{
						if (isConcave)
						{
							if (CuttedEntity2 is buLine)
							{
								tempConcave.Add(CuttedEntity2);
							}
						}
						else
						{
							tempConcave.Add(CuttedEntity2);
						}
					}
					if (CalcEntity != null)
					{
						if (CalcEntity.Marble != null)
						{
							CalcEntity.Marble.Trimmed = true;
						}
						if (flag2)
						{
							tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
						}
						else
						{
							tempSawEntities[tempSawEntities.Count - 1] = CalcEntity;
						}
					}
				}
			}
			else
			{
				double num6 = Pars.ConcaveLength;
				if (!isConcave)
				{
					num6 = Pars.ConvexLength;
				}
				if (ECur.Orientation.A != 0.0)
				{
					double num7 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, ECur.Orientation.A);
					num6 = num7 + num3;
				}
				bool flag3 = false;
				if (ECur.Length() < num6)
				{
					flag3 = true;
				}
				buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ECur), buCall.buVector5_0.EntityLength(ECur) - num6, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
				if (CuttedEntity2 != null)
				{
					if (isConcave)
					{
						tempConcave.Add(CuttedEntity2);
					}
					else
					{
						tempConcave.Add(CuttedEntity2);
					}
				}
				if (CalcEntity != null && CalcEntity.Marble != null)
				{
					CalcEntity.Marble.Trimmed = true;
				}
				if (!flag3)
				{
					if (isConcave)
					{
						if (CalcEntity is buLine)
						{
							tempSawEntities.Add(CalcEntity);
						}
					}
					else
					{
						tempSawEntities.Add(CalcEntity);
					}
				}
			}
			bool flag4 = false;
			if ((num2 > Pars.MinLength) | ENext.Marble.Trimmed)
			{
				flag4 = true;
				if (Pars.isInside & (ENext.GetType() != typeof(buLine)))
				{
					flag4 = false;
				}
			}
			if (!flag4)
			{
				tempConcave.Add(buEntity.Copy(ENext));
				ECur = ENext;
				return;
			}
			double num8 = Pars.ConcaveLength;
			if (!isConcave)
			{
				num8 = Pars.ConvexLength;
			}
			if (ENext.Orientation.A != 0.0)
			{
				double num9 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
				num8 = num9 + num3;
			}
			bool flag5 = false;
			if (ENext.Length() < num8)
			{
				flag5 = true;
			}
			buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ENext), buCall.buVector5_0.EntityLength(ENext) - num8, StartPointType.Start, ref CalcEntity2, ref CuttedEntity);
			if (CuttedEntity != null)
			{
				if (isConcave)
				{
					if (CuttedEntity is buLine)
					{
						tempConcave.Add(CuttedEntity);
					}
				}
				else
				{
					tempConcave.Add(CuttedEntity);
				}
			}
			if (CalcEntity2 != null && CalcEntity2.Marble != null)
			{
				CalcEntity2.Marble.Trimmed = true;
			}
			if (j >= ELL[i].Count - 1)
			{
				if (CalcEntity2 == null)
				{
					tempSawEntities.RemoveAt(0);
				}
				else if (flag5)
				{
					tempSawEntities.RemoveAt(0);
				}
				else
				{
					tempSawEntities[0] = CalcEntity2;
				}
			}
			else if (CalcEntity2 != null && !flag5)
			{
				if (isConcave)
				{
					if (CalcEntity2 is buLine)
					{
						tempSawEntities.Add(CalcEntity2);
					}
				}
				else
				{
					tempSawEntities.Add(buEntity.Copy(CalcEntity2));
				}
			}
			ECur = CalcEntity2;
			if (tempConcave.Count <= 0)
			{
				return;
			}
			ClockDirectionType clockDirection = buCall.buVector5_0.GetClockDirection(tempConcave);
			if (!isConcave)
			{
				if (clockDirection != varOperation.settingMarbleCam.ConvexDirection)
				{
					buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
				}
			}
			else if (clockDirection != varOperation.settingMarbleCam.ConcaveDirection)
			{
				buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
			}
			ConcaveEntities.Add(tempConcave);
			tempConcave = new List<buEntity>();
		}
		else
		{
			tempConcave.Add(buEntity.Copy(ECur));
			ConcaveEntities.Add(tempConcave);
			tempConcave = new List<buEntity>();
		}
	}

	public void CutEntityConcaveCorner11(int i, int j, bool isConcave, ref buEntity EPre, ref buEntity ECur, ref buEntity ENext, ref List<List<buEntity>> ELL, ToolBase5 ToolSaw, ref marbleConvexConcaveCalculationPars Pars, ref List<buEntity> tempConcave, ref List<buEntity> tempSawEntities, ref List<List<buEntity>> ConcaveEntities)
	{
		buEntity CalcEntity = null;
		buEntity CalcEntity2 = null;
		buEntity CuttedEntity = null;
		buEntity CuttedEntity2 = null;
		double num = ECur.Length();
		double num2 = 0.0;
		double num3 = varOperation.settingMarbleCam.InnerCutSafeDistance;
		if (!isConcave)
		{
			num3 = varOperation.settingMarbleCam.OutterCutSafeDistance;
		}
		if (ECur == null || !((ECur is buEllipse) | (ECur is buCircle)))
		{
			if (ENext != null)
			{
				num2 = ENext.Length();
			}
			if (j != 0)
			{
				bool flag = false;
				if ((num > Pars.MinLength) | ECur.Marble.Trimmed)
				{
					flag = true;
					if (Pars.isInside & (ECur.GetType() != typeof(buLine)))
					{
						flag = false;
					}
				}
				if (flag)
				{
					double num4 = Pars.ConcaveLength;
					if (!isConcave)
					{
						num4 = Pars.ConvexLength;
					}
					if (tempSawEntities[tempSawEntities.Count - 1].Orientation.A != 0.0)
					{
						double num5 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
						num4 = num5 + num3;
					}
					bool flag2 = false;
					if (tempSawEntities[tempSawEntities.Count - 1].Length() < num4)
					{
						flag2 = true;
					}
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(tempSawEntities[tempSawEntities.Count - 1]), buCall.buVector5_0.EntityLength(ECur) - num4, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					if (CuttedEntity2 != null && ((j < ELL[i].Count - 1) | ((j == ELL[i].Count - 1) & !Pars.FirstCornerCalculated)) && CalcEntity != null && CalcEntity.Marble != null && ((CalcEntity.Marble.TrimSide == StartEndBothNoneType.None) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Start)))
					{
						if (isConcave)
						{
							if (!(CuttedEntity2 is buLine))
							{
								if (CuttedEntity2 is buArc)
								{
									tempConcave.Add(CuttedEntity2);
								}
							}
							else
							{
								tempConcave.Add(CuttedEntity2);
							}
						}
						else
						{
							tempConcave.Add(CuttedEntity2);
						}
					}
					if (CalcEntity != null)
					{
						if (CalcEntity.Marble != null)
						{
							if (ECur.sortDirection != entitySortDirection.Normal)
							{
								if (!((CalcEntity.Marble.TrimSide == StartEndBothNoneType.End) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Both)))
								{
									CalcEntity.Marble.TrimSide = StartEndBothNoneType.Start;
								}
								else
								{
									CalcEntity.Marble.TrimSide = StartEndBothNoneType.Both;
								}
							}
							else if (!((CalcEntity.Marble.TrimSide == StartEndBothNoneType.Start) | (CalcEntity.Marble.TrimSide == StartEndBothNoneType.Both)))
							{
								CalcEntity.Marble.TrimSide = StartEndBothNoneType.End;
							}
							else
							{
								CalcEntity.Marble.TrimSide = StartEndBothNoneType.Both;
							}
							CalcEntity.Marble.Trimmed = true;
						}
						if (flag2)
						{
							tempSawEntities.RemoveAt(tempSawEntities.Count - 1);
						}
						else
						{
							tempSawEntities[tempSawEntities.Count - 1] = CalcEntity;
						}
					}
				}
			}
			else
			{
				double num6 = Pars.ConcaveLength;
				if (!isConcave)
				{
					num6 = Pars.ConvexLength;
				}
				if (ECur.Orientation.A != 0.0)
				{
					double num7 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, ECur.Orientation.A);
					num6 = num7 + num3;
				}
				bool flag3 = false;
				bool flag4 = false;
				double num8 = ECur.Length();
				if (!(ECur.GetType() != typeof(buLine)))
				{
					if (num8 < Pars.MinLength)
					{
						flag3 = true;
					}
				}
				else
				{
					flag4 = true;
					if (Pars.isInside)
					{
						flag3 = true;
					}
				}
				if (!(flag3 || flag4))
				{
					buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ECur), buCall.buVector5_0.EntityLength(ECur) - num6, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					tempConcave.Add(CuttedEntity2);
					tempSawEntities.Add(CalcEntity);
					if (CalcEntity.Marble != null)
					{
						CalcEntity.Marble.Trimmed = true;
					}
				}
				else if (EPre != null)
				{
					double num9 = EPre.Length();
					if (num9 > Pars.MinLength)
					{
						buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(EPre), buCall.buVector5_0.EntityLength(EPre) - num6, StartPointType.End, ref CalcEntity, ref CuttedEntity2);
					}
					if (CuttedEntity2 != null)
					{
						tempConcave.Add(CuttedEntity2);
					}
					tempConcave.Add(buEntity.Copy(ECur));
					Pars.FirstCornerCalculated = true;
				}
			}
			bool flag5 = false;
			if ((num2 > Pars.MinLength) | (ENext != null && ENext.Marble.Trimmed))
			{
				flag5 = true;
				if (Pars.isInside && ENext != null && ENext.GetType() != typeof(buLine))
				{
					flag5 = false;
				}
			}
			if (!flag5)
			{
				if (ENext != null)
				{
					tempConcave.Add(buEntity.Copy(ENext));
					ECur = ENext;
				}
				return;
			}
			double num10 = Pars.ConcaveLength;
			if (!isConcave)
			{
				num10 = Pars.ConvexLength;
			}
			if (ENext != null && ENext.Orientation.A != 0.0)
			{
				double num11 = DistanceCalcFromToolDiameterAndThickness(ToolSaw.Geometry.Diameter, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, 0.0, tempSawEntities[tempSawEntities.Count - 1].Orientation.A);
				num10 = num11 + num3;
			}
			bool flag6 = false;
			if (ENext == null || !(ENext.Length() < num10))
			{
				if (ENext != null && ENext.GetType() != typeof(buLine) && ENext.Marble != null && ENext.Marble.isInside)
				{
					flag6 = true;
				}
			}
			else
			{
				flag6 = true;
			}
			if (!flag6 && ENext != null && ((j < ELL[i].Count - 1) | ((j == ELL[i].Count - 1) & !Pars.FirstCornerCalculated)))
			{
				buCall.buVector5_0.EntityUpdateByLength(buEntity.Copy(ENext), buCall.buVector5_0.EntityLength(ENext) - num10, StartPointType.Start, ref CalcEntity2, ref CuttedEntity);
				tempConcave.Add(CuttedEntity);
			}
			if (CalcEntity2 != null && CalcEntity2.Marble != null)
			{
				if (ENext.sortDirection != entitySortDirection.Normal)
				{
					if (!((CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Start) | (CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Both)))
					{
						CalcEntity2.Marble.TrimSide = StartEndBothNoneType.End;
					}
					else
					{
						CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Both;
					}
				}
				else if (!((CalcEntity2.Marble.TrimSide == StartEndBothNoneType.End) | (CalcEntity2.Marble.TrimSide == StartEndBothNoneType.Both)))
				{
					CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Start;
				}
				else
				{
					CalcEntity2.Marble.TrimSide = StartEndBothNoneType.Both;
				}
				CalcEntity2.Marble.Trimmed = true;
			}
			if (j >= ELL[i].Count - 1)
			{
				if (CalcEntity2 != null)
				{
					if (flag6)
					{
						tempSawEntities.RemoveAt(0);
					}
					else
					{
						tempSawEntities[0] = CalcEntity2;
					}
				}
			}
			else if (CalcEntity2 != null && !flag6)
			{
				if (isConcave)
				{
					if (!(CalcEntity2 is buLine))
					{
						if (CalcEntity2 is buArc && CalcEntity2.Marble != null && !CalcEntity2.Marble.isInside)
						{
							tempSawEntities.Add(CalcEntity2);
						}
					}
					else
					{
						tempSawEntities.Add(CalcEntity2);
					}
				}
				else
				{
					tempSawEntities.Add(buEntity.Copy(CalcEntity2));
				}
			}
			ECur = CalcEntity2;
			if (tempConcave.Count <= 1)
			{
				return;
			}
			ClockDirectionType clockDirection = buCall.buVector5_0.GetClockDirection(tempConcave);
			if (!isConcave)
			{
				if (clockDirection != varOperation.settingMarbleCam.ConvexDirection)
				{
					buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
				}
			}
			else if (clockDirection != varOperation.settingMarbleCam.ConcaveDirection)
			{
				buCall.buVector5_0.ChangeEntitiesDirection(ref tempConcave);
			}
			ConcaveEntities.Add(tempConcave);
			tempConcave = new List<buEntity>();
		}
		else
		{
			tempConcave.Add(buEntity.Copy(ECur));
			ConcaveEntities.Add(tempConcave);
			tempConcave = new List<buEntity>();
		}
	}

	public void OffsetModifiedEntities(List<buEntity> tempSawEntities, ClockDirectionType CDRefEnt, marbleConvexConcaveCalculationPars Pars, ToolBase5 ToolSaw, MarbleItemSettings Settings, ref List<List<buEntity>> SawEntities)
	{
		for (int i = 0; i <= tempSawEntities.Count - 1; i++)
		{
			double num = 0.0;
			marbleOffsetCalculationParameters marbleOffsetCalculationParameters2 = new marbleOffsetCalculationParameters();
			marbleOffsetCalculationParameters2.OrientationA = tempSawEntities[i].Orientation.A;
			num = ToolSaw.Geometry.Thickness / 2.0;
			if (Pars.isInside)
			{
				marbleOffsetCalculationParameters2.ClosedOffsetType = CamClosedContourType.Inner;
			}
			else
			{
				marbleOffsetCalculationParameters2.ClosedOffsetType = CamClosedContourType.Outter;
			}
			marbleOffsetCalculationParameters2.TargetZ = tempSawEntities[i].BoxMin.Z;
			marbleOffsetCalculationParameters2.MaterialThickness = Settings.MaterialParameter.MaterialThickness;
			marbleOffsetCalculationParameters2.ToolThickness = ToolSaw.Geometry.Thickness;
			marbleOffsetCalculationParameters2.ToolSocket = ToolSaw.Geometry.SocketThickness;
			if (marbleOffsetCalculationParameters2.OrientationA < 0.0)
			{
				marbleOffsetCalculationParameters2.isReverseAngleA = true;
			}
			OffsetCalculation(marbleOffsetCalculationParameters2, Settings, ref num);
			if (tempSawEntities[i] is buArc && tempSawEntities[i].Marble != null && tempSawEntities[i].Marble.isConcave)
			{
				double CalcOffset = 0.0;
				if (varOperation.settingMarbleCam.ConcaveArcOffsetType == MarbleConcaveArcOffsetCalculationType.ExtraOffset)
				{
					ConcaveArcOffsetCalculation(((buArc)tempSawEntities[i]).Radius, ToolSaw.Geometry.Diameter, marbleOffsetCalculationParameters2.MaterialThickness, ref CalcOffset);
					num += CalcOffset;
				}
			}
			List<buEntity> list = new List<buEntity>();
			buEntity OffsetedEntity = null;
			if (Pars.isInside)
			{
				double num2 = 0.0;
				num2 = ((Math.Abs(marbleOffsetCalculationParameters2.OrientationA) > 1.0) ? varOperation.settingMarbleCam.Inside45DegreeExtraOffset : varOperation.settingMarbleCam.Inside0DegreeExtraOffset);
				if (CDRefEnt != ClockDirectionType.CCW)
				{
					if (!(marbleOffsetCalculationParameters2.OrientationA < 0.0))
					{
						buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Right, ref OffsetedEntity);
					}
					else if (varOperation.settingMarbleCam.InsideCutSizeFromTop)
					{
						buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Left, ref OffsetedEntity);
					}
					else
					{
						buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Right, ref OffsetedEntity);
					}
				}
				else if (!(marbleOffsetCalculationParameters2.OrientationA < 0.0))
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Left, ref OffsetedEntity);
				}
				else if (varOperation.settingMarbleCam.InsideCutSizeFromTop)
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Right, ref OffsetedEntity);
				}
				else
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num + num2, CamOpenContourType.Left, ref OffsetedEntity);
				}
			}
			else if (CDRefEnt != ClockDirectionType.CCW)
			{
				if (!(num >= 0.0))
				{
					if (!((tempSawEntities[i] is buCircle) | (tempSawEntities[i] is buArc) | (tempSawEntities[i] is buEllipse)))
					{
						buCall.buVector5_0.OffsetEntity(tempSawEntities[i], Math.Abs(num), CamOpenContourType.Right, ref OffsetedEntity);
					}
					else
					{
						buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num, CamOpenContourType.Left, ref OffsetedEntity);
					}
				}
				else
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num, CamOpenContourType.Left, ref OffsetedEntity);
				}
			}
			else if (!(num >= 0.0))
			{
				if (!((tempSawEntities[i] is buCircle) | (tempSawEntities[i] is buArc) | (tempSawEntities[i] is buEllipse)))
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], Math.Abs(num), CamOpenContourType.Left, ref OffsetedEntity);
				}
				else
				{
					buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num, CamOpenContourType.Left, ref OffsetedEntity);
				}
			}
			else
			{
				buCall.buVector5_0.OffsetEntity(tempSawEntities[i], num, CamOpenContourType.Right, ref OffsetedEntity);
			}
			if (OffsetedEntity != null)
			{
				list.Add(OffsetedEntity);
				SawEntities.Add(list);
			}
		}
	}

	public void doSingleCut(Pnt6D Position, ToolBase5 Tool, MarbleItemSettings varOperation, KinematicBase5 Kinematic, EntitiesResolution Resolution, ref List<MarbleItem> Items, MarbleSliceType SliceType, bool isFinished = true)
	{
		double num = Tool.Geometry.Thickness;
		if (Tool.Geometry.SocketThickness > Tool.Geometry.Thickness)
		{
			num = Tool.Geometry.SocketThickness;
		}
		List<marbleCuttingItems> list = new List<marbleCuttingItems>();
		List<marbleCuttingItems> list2 = new List<marbleCuttingItems>();
		Items.Clear();
		double num2 = Math.Round(varOperation.MaterialParameter.MaterialThickness * Math.Tan(buConversion5.DegreeToRadian(Math.Abs(Position.A))), 3);
		if (((Position.C >= -45.0) & (Position.C <= 45.0)) | ((Position.C >= 135.0) & (Position.C <= 225.0)))
		{
			list.Add(new marbleCuttingItems(num + num2, 1, Position.A, 0.0 - Position.A));
		}
		if (((Position.C > -135.0) & (Position.C < -45.0)) | ((Position.C > 45.0) & (Position.C < 135.0)) | ((Position.C > 225.0) & (Position.C < 315.0)))
		{
			list2.Add(new marbleCuttingItems(num + num2, 1, Position.A, 0.0 - Position.A));
		}
		if (list.Count > 0)
		{
			List<List<buEntity>> CalcLines = new List<List<buEntity>>();
			List<Entity> Entities = new List<Entity>();
			List<buEntity> entRectangles = new List<buEntity>();
			HorizontalItemsCalc(Position, 0.01, list, varOperation, varOperation.settingSliceCut.CutLengthSingle, ref Entities, ref CalcLines, ref entRectangles);
			int num3 = 0;
			new TpPnt9D();
			for (int i = 0; i <= list.Count - 1; i++)
			{
				for (int j = 0; j <= list[i].Count - 1; j++)
				{
					MarbleItem marbleItem = new MarbleItem();
					marbleItem.ItemEntities.WireEntities = new List<List<buEntity>>();
					marbleItem.ItemEntities.SolidEntity = new List<Entity>();
					marbleItem.Settings = new MarbleItemSettings(varOperation);
					if (CalcLines.Count > 0)
					{
						for (int k = 0; k <= CalcLines[0].Count - 1; k++)
						{
							List<buEntity> list3 = new List<buEntity>();
							list3.Add(buEntity.Copy(CalcLines[0][k]));
							if (list3.Count > 0)
							{
								marbleItem.ItemEntities.WireEntities.Add(list3);
							}
						}
						if (CalcLines.Count > 0)
						{
							List<Point3D> calcPoints = new List<Point3D>();
							buCall.buVector5_0.OffsetEntityAsClosed(CalcLines[0][0], num / 2.0, ref calcPoints);
							LinearPath outer = new LinearPath(calcPoints);
							devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer, Plane.XY);
							Entity item = region.ExtrudeAsMesh(varOperation.MaterialParameter.MaterialThickness, 0.1, Mesh.natureType.RichSmooth);
							marbleItem.ItemEntities.SolidEntity.Add(item);
						}
					}
					marbleItem.ItemType = MarbleItemType.SingleCut;
					if (marbleItem.ItemEntities.WireEntities.Count > 0)
					{
						Items.Add(marbleItem);
					}
					if (!isFinished)
					{
					}
					num3++;
				}
			}
		}
		if (!(list2.Count > 0 && (SliceType == MarbleSliceType.Vertical || SliceType == MarbleSliceType.HorizontalVertical)))
		{
			return;
		}
		List<List<buEntity>> CalcLines2 = new List<List<buEntity>>();
		List<Entity> Entities2 = new List<Entity>();
		List<buEntity> entRectangles2 = new List<buEntity>();
		VerticalItemsCalc(Position, 0.01, list2, varOperation, varOperation.settingSliceCut.CutLengthSingle, ref Entities2, ref CalcLines2, ref entRectangles2);
		int num4 = 0;
		new TpPnt9D();
		for (int l = 0; l <= list2.Count - 1; l++)
		{
			buEntity copiedEntity = new buEntity();
			for (int m = 0; m <= list2[l].Count - 1; m++)
			{
				MarbleItem marbleItem2 = new MarbleItem();
				marbleItem2.ItemEntities.WireEntities = new List<List<buEntity>>();
				marbleItem2.ItemEntities.SolidEntity = new List<Entity>();
				marbleItem2.Settings = new MarbleItemSettings(varOperation);
				if (CalcLines2.Count > 0)
				{
					for (int n = 0; n <= CalcLines2[0].Count - 1; n++)
					{
						List<buEntity> list4 = new List<buEntity>();
						list4.Add(buEntity.Copy(CalcLines2[0][n]));
						if (list4.Count > 0)
						{
							marbleItem2.ItemEntities.WireEntities.Add(list4);
						}
					}
					if (CalcLines2.Count > 0)
					{
						List<Point3D> calcPoints2 = new List<Point3D>();
						buCall.buVector5_0.OffsetEntityAsClosed(CalcLines2[0][0], num / 2.0, ref calcPoints2);
						LinearPath outer2 = new LinearPath(calcPoints2);
						devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(outer2, Plane.XY);
						Entity item2 = region2.ExtrudeAsMesh(varOperation.MaterialParameter.MaterialThickness, 0.1, Mesh.natureType.RichSmooth);
						marbleItem2.ItemEntities.SolidEntity.Add(item2);
					}
				}
				marbleItem2.ItemType = MarbleItemType.SingleCut;
				if (marbleItem2.ItemEntities.WireEntities.Count > 0)
				{
					buEntity.Copy(marbleItem2.ItemEntities.WireEntities[marbleItem2.ItemEntities.WireEntities.Count - 1][marbleItem2.ItemEntities.WireEntities[marbleItem2.ItemEntities.WireEntities.Count - 1].Count - 1], ref copiedEntity);
					Items.Add(marbleItem2);
				}
				if (!isFinished)
				{
				}
				num4++;
			}
		}
	}

	public void doMultiCut(Pnt6D PositionHor, Pnt6D PositionVer, ToolBase5 Tool, List<marbleCuttingItems> ItemsHor, List<marbleCuttingItems> ItemsVer, MarbleItemSettings varOperation, KinematicBase5 Kinematic, EntitiesResolution Resolution, ref List<MarbleItem> Items, MarbleSliceType SliceType, double HorLength, double VerLength, bool isFinished = true)
	{
		double thickness = Tool.Geometry.Thickness;
		if (Tool.Geometry.SocketThickness > Tool.Geometry.Thickness)
		{
			thickness = Tool.Geometry.SocketThickness;
		}
		Items.Clear();
		if (ItemsHor.Count > 0 && (SliceType == MarbleSliceType.Horizontal || SliceType == MarbleSliceType.HorizontalVertical))
		{
			List<List<buEntity>> CalcLines = new List<List<buEntity>>();
			List<List<buEntity>> CalcLines2 = new List<List<buEntity>>();
			List<Entity> Entities = new List<Entity>();
			List<buEntity> entRectangles = new List<buEntity>();
			HorizontalItemsCalc(PositionHor, thickness, ItemsHor, varOperation, HorLength, ref Entities, ref CalcLines2, ref entRectangles, AlwaysSAandEAZero: true);
			Entities.Clear();
			entRectangles.Clear();
			HorizontalItemsCalc(PositionHor, thickness, ItemsHor, varOperation, HorLength, ref Entities, ref CalcLines, ref entRectangles);
			int num = 0;
			int num2 = 0;
			new TpPnt9D();
			for (int i = 0; i <= ItemsHor.Count - 1; i++)
			{
				for (int j = 0; j <= ItemsHor[i].Count - 1; j++)
				{
					MarbleItem marbleItem = new MarbleItem();
					marbleItem.ItemEntities.WireEntities = new List<List<buEntity>>();
					marbleItem.ItemEntities.DrawWireEntities = new List<buEntity>();
					marbleItem.ItemEntities.BorderEntities = new List<buEntity>();
					marbleItem.Settings = new MarbleItemSettings(varOperation);
					marbleItem.ItemEntities.WireEntities.Add(CalcLines[num]);
					marbleItem.ItemEntities.BorderEntities.Add(CalcLines2[num][0]);
					num++;
					marbleItem.ItemEntities.WireEntities.Add(CalcLines[num]);
					marbleItem.ItemEntities.BorderEntities.Add(CalcLines2[num][0]);
					num++;
					marbleItem.ItemEntities.SolidEntity = new List<Entity>();
					marbleItem.ItemEntities.SolidEntity.Add(Entities[num2]);
					marbleItem.ItemType = MarbleItemType.HorizontalCut;
					buLine item = new buLine(new Point3D(entRectangles[j].BoxMin.X - activeToolSaw.Geometry.Thickness / 2.0, entRectangles[j].BoxMin.Y, 0.0), new Point3D(entRectangles[j].BoxMin.X - activeToolSaw.Geometry.Thickness / 2.0, entRectangles[j].BoxMax.Y, 0.0));
					marbleItem.ItemEntities.BorderEntities.Add(item);
					buLine item2 = new buLine(new Point3D(entRectangles[j].BoxMax.X + activeToolSaw.Geometry.Thickness / 2.0, entRectangles[j].BoxMin.Y, 0.0), new Point3D(entRectangles[j].BoxMax.X + activeToolSaw.Geometry.Thickness / 2.0, entRectangles[j].BoxMax.Y, 0.0));
					marbleItem.ItemEntities.BorderEntities.Add(item2);
					if ((Items.Count > 0) & (marbleItem.ItemEntities.WireEntities.Count > 0))
					{
						buEntity baseEntity = Items[Items.Count - 1].ItemEntities.WireEntities[Items[Items.Count - 1].ItemEntities.WireEntities.Count - 1][Items[Items.Count - 1].ItemEntities.WireEntities[Items[Items.Count - 1].ItemEntities.WireEntities.Count - 1].Count - 1];
						if (buCall.buVector5_0.isEntitySame(baseEntity, marbleItem.ItemEntities.WireEntities[0][0]))
						{
							if (marbleItem.ItemEntities.WireEntities[0].Count != 1)
							{
								if (marbleItem.ItemEntities.WireEntities[0].Count > 0)
								{
									marbleItem.ItemEntities.WireEntities[0].RemoveAt(0);
								}
							}
							else
							{
								marbleItem.ItemEntities.WireEntities.RemoveAt(0);
							}
						}
					}
					if (marbleItem.ItemEntities.WireEntities.Count > 0)
					{
						Items.Add(marbleItem);
					}
					if (!isFinished)
					{
					}
					if (num2 <= entRectangles.Count - 1)
					{
						buEntity copiedEntity = null;
						buEntity.Copy(entRectangles[num2], ref copiedEntity);
						if (copiedEntity != null)
						{
							marbleItem.ItemEntities.DrawWireEntities.Add(copiedEntity);
							if (marbleItem.EntGroup == null)
							{
								marbleItem.EntGroup = new buEntitiesGroup();
							}
							if (!(copiedEntity is buCompositeCurve))
							{
								buEntity copiedEntity2 = null;
								buEntity.Copy(copiedEntity, ref copiedEntity2);
								List<buEntity> list = new List<buEntity>();
								list.Add(copiedEntity2);
								buCall.buVector5_0.CreateEntitiesGroupFromEntities(list, null, null, ref marbleItem.EntGroup);
							}
							else
							{
								List<buEntity> list2 = new List<buEntity>();
								for (int k = 0; k <= ((buCompositeCurve)copiedEntity).CurveList.Count - 1; k++)
								{
									buEntity copiedEntity3 = null;
									buEntity.Copy(((buCompositeCurve)copiedEntity).CurveList[k], ref copiedEntity3);
									list2.Add(copiedEntity3);
								}
								buCall.buVector5_0.CreateEntitiesGroupFromEntities(list2, null, null, ref marbleItem.EntGroup);
							}
						}
					}
					num2++;
				}
			}
		}
		if (ItemsVer.Count > 0 && (SliceType == MarbleSliceType.Vertical || SliceType == MarbleSliceType.HorizontalVertical))
		{
			List<List<buEntity>> CalcLines3 = new List<List<buEntity>>();
			List<List<buEntity>> CalcLines4 = new List<List<buEntity>>();
			List<Entity> Entities2 = new List<Entity>();
			List<buEntity> entRectangles2 = new List<buEntity>();
			VerticalItemsCalc(PositionVer, thickness, ItemsVer, varOperation, VerLength, ref Entities2, ref CalcLines4, ref entRectangles2, AlwaysSAandEAZero: true);
			CalcLines3.Clear();
			Entities2.Clear();
			entRectangles2.Clear();
			VerticalItemsCalc(PositionVer, thickness, ItemsVer, varOperation, VerLength, ref Entities2, ref CalcLines3, ref entRectangles2);
			int num3 = 0;
			int num4 = 0;
			new TpPnt9D();
			for (int l = 0; l <= ItemsVer.Count - 1; l++)
			{
				for (int m = 0; m <= ItemsVer[l].Count - 1; m++)
				{
					MarbleItem marbleItem2 = new MarbleItem();
					marbleItem2.ItemEntities.WireEntities = new List<List<buEntity>>();
					marbleItem2.ItemEntities.DrawWireEntities = new List<buEntity>();
					marbleItem2.ItemEntities.BorderEntities = new List<buEntity>();
					marbleItem2.Settings = new MarbleItemSettings(varOperation);
					marbleItem2.ItemEntities.WireEntities.Add(CalcLines3[num3]);
					marbleItem2.ItemEntities.BorderEntities.Add(CalcLines4[num3][0]);
					num3++;
					marbleItem2.ItemEntities.WireEntities.Add(CalcLines3[num3]);
					marbleItem2.ItemEntities.BorderEntities.Add(CalcLines4[num3][0]);
					num3++;
					marbleItem2.ItemEntities.SolidEntity = new List<Entity>();
					marbleItem2.ItemEntities.SolidEntity.Add(Entities2[num4]);
					marbleItem2.ItemType = MarbleItemType.VerticalCut;
					buLine item3 = new buLine(new Point3D(entRectangles2[m].BoxMin.X, entRectangles2[m].BoxMin.Y - activeToolSaw.Geometry.Thickness / 2.0, 0.0), new Point3D(entRectangles2[m].BoxMax.X, entRectangles2[m].BoxMin.Y - activeToolSaw.Geometry.Thickness / 2.0, 0.0));
					marbleItem2.ItemEntities.BorderEntities.Add(item3);
					buLine item4 = new buLine(new Point3D(entRectangles2[m].BoxMin.X, entRectangles2[m].BoxMax.Y + activeToolSaw.Geometry.Thickness / 2.0, 0.0), new Point3D(entRectangles2[m].BoxMax.X, entRectangles2[m].BoxMax.Y + activeToolSaw.Geometry.Thickness / 2.0, 0.0));
					marbleItem2.ItemEntities.BorderEntities.Add(item4);
					if ((Items.Count > 0) & (marbleItem2.ItemEntities.WireEntities.Count > 0))
					{
						buEntity baseEntity2 = Items[Items.Count - 1].ItemEntities.WireEntities[Items[Items.Count - 1].ItemEntities.WireEntities.Count - 1][Items[Items.Count - 1].ItemEntities.WireEntities[Items[Items.Count - 1].ItemEntities.WireEntities.Count - 1].Count - 1];
						if (buCall.buVector5_0.isEntitySame(baseEntity2, marbleItem2.ItemEntities.WireEntities[0][0]))
						{
							if (marbleItem2.ItemEntities.WireEntities[0].Count != 1)
							{
								if (marbleItem2.ItemEntities.WireEntities[0].Count > 0)
								{
									marbleItem2.ItemEntities.WireEntities[0].RemoveAt(0);
								}
							}
							else
							{
								marbleItem2.ItemEntities.WireEntities.RemoveAt(0);
							}
						}
					}
					if (marbleItem2.ItemEntities.WireEntities.Count > 0)
					{
						Items.Add(marbleItem2);
					}
					if (!isFinished)
					{
					}
					if (num4 <= entRectangles2.Count - 1)
					{
						buEntity copiedEntity4 = null;
						buEntity.Copy(entRectangles2[num4], ref copiedEntity4);
						if (copiedEntity4 != null)
						{
							marbleItem2.ItemEntities.DrawWireEntities.Add(copiedEntity4);
							if (marbleItem2.EntGroup == null)
							{
								marbleItem2.EntGroup = new buEntitiesGroup();
							}
							if (!(copiedEntity4 is buCompositeCurve))
							{
								buEntity copiedEntity5 = null;
								buEntity.Copy(copiedEntity4, ref copiedEntity5);
								List<buEntity> list3 = new List<buEntity>();
								list3.Add(copiedEntity5);
								buCall.buVector5_0.CreateEntitiesGroupFromEntities(list3, null, null, ref marbleItem2.EntGroup);
							}
							else
							{
								List<buEntity> list4 = new List<buEntity>();
								for (int n = 0; n <= ((buCompositeCurve)copiedEntity4).CurveList.Count - 1; n++)
								{
									buEntity copiedEntity6 = null;
									buEntity.Copy(((buCompositeCurve)copiedEntity4).CurveList[n], ref copiedEntity6);
									list4.Add(copiedEntity6);
								}
								buCall.buVector5_0.CreateEntitiesGroupFromEntities(list4, null, null, ref marbleItem2.EntGroup);
							}
						}
					}
					num4++;
				}
			}
		}
		if (Items.Count <= 0)
		{
			return;
		}
		int num5 = 0;
		int num6 = 0;
		entitySortDirection entitySortDirection2 = entitySortDirection.Normal;
		if (varOperation.settingSliceCut.SliceDirection != CamCuttingDirectionType.ForwardBackward)
		{
			return;
		}
		for (int num7 = 0; num7 <= Items.Count - 1; num7++)
		{
			for (int num8 = 0; num8 <= Items[num7].ItemEntities.WireEntities.Count - 1; num8++)
			{
				for (int num9 = 0; num9 <= Items[num7].ItemEntities.WireEntities[num8].Count - 1; num9++)
				{
					buEntity buEntity2 = Items[num7].ItemEntities.WireEntities[num8][num9];
					if (num6 > 0 && buEntity2.Orientation.A <= 0.1)
					{
						if (buEntity2.sortDirection == entitySortDirection2)
						{
							buEntity2.sortDirection = entitySortDirection.Reverse;
							if (!varOperation.settingSliceCut.RotateCForReverseDirection)
							{
								if (buEntity2.Info.OffsetABC == null)
								{
									buEntity2.Info.OffsetABC = new PointABC();
								}
								buEntity2.Info.OffsetABC.C = -180.0;
							}
						}
						num5++;
					}
					entitySortDirection2 = buEntity2.sortDirection;
					num6++;
				}
			}
		}
	}

	public void doPerpendicularCut(Pnt6D HorizontalPosition, Pnt6D VerticalPosition, ToolBase5 Tool, List<marbleCuttingItems> HorizontalItems, List<marbleCuttingItems> VerticalItems, MarbleItemSettings varOperation, KinematicBase Kinematic, EntitiesResolution Resolution, ref camTp Cam)
	{
	}

	public void HorizontalItemsCalc(Pnt6D Position, double Thickness, List<marbleCuttingItems> Items, MarbleItemSettings varOperation, double CutLength, ref List<Entity> Entities, ref List<List<buEntity>> CalcLines, ref List<buEntity> entRectangles, bool AlwaysSAandEAZero = false)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 1.0;
		double num5 = 0.0;
		Entity SurfaceEntity = null;
		num3 = varOperation.MaterialParameter.MaterialThickness;
		num5 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
		if (Items[0].Length < 0.0)
		{
			num4 = -1.0;
		}
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			double num6 = Items[i].StartAngle;
			double num7 = Items[i].EndAngle;
			double num8 = Math.Abs(Items[i].Length);
			double num9 = 360.0;
			if (AlwaysSAandEAZero)
			{
				num6 = 0.0;
				num7 = 0.0;
				num9 = 0.0;
			}
			if (num6 > 0.0)
			{
				num8 -= num3 * Math.Tan(buConversion5.DegreeToRadian(num6));
			}
			if (num7 > 0.0)
			{
				num8 -= num3 * Math.Tan(buConversion5.DegreeToRadian(num7));
			}
			if (i <= Items.Count - 2)
			{
				num9 = Items[i + 1].StartAngle;
			}
			buEntity TopFirstLine = null;
			buEntity BottomFirstLine = null;
			buEntity TopLastLine = null;
			buEntity BottomLastLine = null;
			buCall.buVector5_0.Trapezoid3D(new Point3D(Position.X, Position.Y, varOperation.MaterialParameter.MaterialThickness), num8, varOperation.MaterialParameter.MaterialThickness - varOperation.settingMarbleCam.TargetZ, num6 + 90.0, num7 + 90.0, new Vec3D(1.0, 0.0, 0.0), CutLength, num5, ref TopFirstLine, ref BottomFirstLine, ref TopLastLine, ref BottomLastLine, ref SurfaceEntity);
			if (num4 < 0.0)
			{
				num6 *= -1.0;
				num7 *= -1.0;
			}
			int Cnt = 0;
			for (int j = 0; j <= Items[i].Count - 1; j++)
			{
				double num10 = 0.0;
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = Math.Abs(Items[i].Length) / Math.Cos(buConversion5.DegreeToRadian(num5));
				double num14 = 0.0;
				double num15 = 0.0;
				_ = Thickness / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num6)));
				double num16 = Thickness / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num7)));
				num11 = Thickness / 2.0 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num6)));
				num12 = Thickness / 2.0 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num7)));
				num14 = num16;
				Entity refEntities = buVector5.CopyEntities(SurfaceEntity);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(0.0, num, 0.0), ref refEntities);
				buEntity rectangleEntity = null;
				buCall.buVector5_0.DrawRectangle(new Point3D(Position.X, Position.Y + num, 0.0), CutLength, num8, Plane.XY, ref rectangleEntity);
				rectangleEntity.Rotate(0.0 - num5, Vector3D.AxisZ, new Point3D(Position.X, Position.Y + num, 0.0));
				entRectangles.Add(rectangleEntity);
				CustomData customData = new CustomData();
				customData.ActionName = "horizontal";
				refEntities.EntityData = customData;
				Entities.Add(refEntities);
				if ((i == 0 && j == 0) || num2 != num6)
				{
					num10 = num11;
				}
				num10 = num11;
				if (j <= Items[i].Count - 2 && Items[i].EndAngle != 0.0 - Items[i].StartAngle)
				{
					num15 = varOperation.settingSliceCut.SliceOffset;
				}
				if (j == Items[i].Count - 1 && Items[i].EndAngle != 0.0 - num9)
				{
					num15 = varOperation.settingSliceCut.SliceOffset;
				}
				buEntity refEntities2 = buEntity.Copy(TopFirstLine);
				buEntity refEntities3 = buEntity.Copy(BottomFirstLine);
				buEntity refEntities4 = buEntity.Copy(TopLastLine);
				buEntity refEntities5 = buEntity.Copy(BottomLastLine);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(0.0, num - num10, 0.0), ref refEntities2);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(0.0, num - num10, 0.0), ref refEntities3);
				MarblecalcItemLines(refEntities2.StartPoint, refEntities3.StartPoint, refEntities2.EndPoint, refEntities3.EndPoint, num6, num7, num2, Position, StartMode: true, AddAllLines: true, isVertical: false, varOperation, ref CalcLines, ref Cnt);
				if (!AlwaysSAandEAZero)
				{
					Cnt++;
				}
				buCall.buVector5_0.Move(new Point3D(), new Point3D(0.0, num + num12, 0.0), ref refEntities4);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(0.0, num + num12, 0.0), ref refEntities5);
				MarblecalcItemLines(refEntities4.StartPoint, refEntities5.StartPoint, refEntities4.EndPoint, refEntities5.EndPoint, num6, num7, num2, Position, StartMode: false, AddAllLines: true, isVertical: false, varOperation, ref CalcLines, ref Cnt);
				num2 = num7 * -1.0;
				num = num + num13 + num14 + num15;
				if (!AlwaysSAandEAZero)
				{
					Cnt++;
				}
			}
		}
		if (num4 < 0.0)
		{
			buCall.buVector5_0.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref Entities);
			buCall.buVector5_0.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref CalcLines);
			buCall.buVector5_0.Mirror(new Point3D(0.0, Position.Y, 0.0), new Point3D(1.0, Position.Y, 0.0), Plane.XY, ref entRectangles);
		}
	}

	public void VerticalItemsCalc(Pnt6D Position, double Thickness, List<marbleCuttingItems> Items, MarbleItemSettings varOperation, double CutLength, ref List<Entity> Entities, ref List<List<buEntity>> CalcLines, ref List<buEntity> entRectangles, bool AlwaysSAandEAZero = false)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 1.0;
		double num5 = 0.0;
		double num6 = 1.0;
		Entity SurfaceEntity = null;
		num3 = varOperation.MaterialParameter.MaterialThickness;
		num5 = Math.Round(Position.C);
		if (Items.Count == 0)
		{
			return;
		}
		if (entRectangles == null)
		{
			entRectangles = new List<buEntity>();
		}
		entRectangles.Clear();
		if (Items[0].Length < 0.0)
		{
			num4 = -1.0;
		}
		int Cnt = 0;
		for (int i = 0; i <= Items.Count - 1; i++)
		{
			double num7 = Items[i].StartAngle;
			double num8 = Items[i].EndAngle;
			double num9 = Math.Abs(Items[i].Length);
			double num10 = 360.0;
			if (AlwaysSAandEAZero)
			{
				num7 = 0.0;
				num8 = 0.0;
			}
			if (num7 > 0.0)
			{
				num9 -= num3 * Math.Tan(buConversion5.DegreeToRadian(num7));
			}
			if (num8 > 0.0)
			{
				num9 -= num3 * Math.Tan(buConversion5.DegreeToRadian(num8));
			}
			if (i <= Items.Count - 2)
			{
				num10 = Items[i + 1].StartAngle;
			}
			buEntity TopFirstLine = null;
			buEntity BottomFirstLine = null;
			buEntity TopLastLine = null;
			buEntity BottomLastLine = null;
			buCall.buVector5_0.Trapezoid3D(new Point3D(Position.X, Position.Y, varOperation.MaterialParameter.MaterialThickness), num9, varOperation.MaterialParameter.MaterialThickness - varOperation.settingMarbleCam.TargetZ, num7 + 90.0, num8 + 90.0, new Vec3D(0.0, 1.0, 0.0), CutLength, num5, ref TopFirstLine, ref BottomFirstLine, ref TopLastLine, ref BottomLastLine, ref SurfaceEntity);
			if (num4 < 0.0)
			{
				num7 *= -1.0;
				num8 *= -1.0;
			}
			for (int j = 0; j <= Items[i].Count - 1; j++)
			{
				double num11 = 0.0;
				double num12 = 0.0;
				double num13 = 0.0;
				double num14 = Math.Abs(Items[i].Length) / Math.Cos(buConversion5.DegreeToRadian(num5 - 90.0));
				double num15 = 0.0;
				double num16 = 0.0;
				_ = Thickness / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num7)));
				double num17 = Thickness / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num8)));
				num12 = Thickness / 2.0 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num7)));
				num13 = Thickness / 2.0 / Math.Cos(buConversion5.DegreeToRadian(Math.Abs(num8)));
				num15 = num17;
				if ((Position.C > 180.0) | (Position.C < -45.0))
				{
					num6 = -1.0;
				}
				Entity refEntities = buVector5.CopyEntities(SurfaceEntity);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(num, 0.0, 0.0), ref refEntities);
				buEntity rectangleEntity = null;
				buCall.buVector5_0.DrawRectangle(new Point3D(Position.X + num, Position.Y, 0.0), num9, CutLength, Plane.XY, ref rectangleEntity);
				rectangleEntity.Rotate(num5 - 90.0, Vector3D.AxisZ, new Point3D(Position.X + num, Position.Y, 0.0));
				entRectangles.Add(rectangleEntity);
				CustomData customData = new CustomData();
				customData.ActionName = "horizontal";
				refEntities.EntityData = customData;
				Entities.Add(refEntities);
				if ((i == 0 && j == 0) || num2 != num7)
				{
					num11 = num12;
				}
				num11 = num12;
				if (j <= Items[i].Count - 2 && Items[i].EndAngle != 0.0 - Items[i].StartAngle)
				{
					num16 = varOperation.settingSliceCut.SliceOffset;
				}
				if (j == Items[i].Count - 1 && Items[i].EndAngle != 0.0 - num10)
				{
					num16 = varOperation.settingSliceCut.SliceOffset;
				}
				buEntity refEntities2 = buEntity.Copy(TopFirstLine);
				buEntity refEntities3 = buEntity.Copy(BottomFirstLine);
				buEntity refEntities4 = buEntity.Copy(TopLastLine);
				buEntity refEntities5 = buEntity.Copy(BottomLastLine);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(num - num6 * num11, 0.0, 0.0), ref refEntities2);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(num - num6 * num11, 0.0, 0.0), ref refEntities3);
				MarblecalcItemLines(refEntities2.StartPoint, refEntities3.StartPoint, refEntities2.EndPoint, refEntities3.EndPoint, num7, num8, num2, Position, StartMode: true, AddAllLines: true, isVertical: true, varOperation, ref CalcLines, ref Cnt);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(num + num6 * num13, 0.0, 0.0), ref refEntities4);
				buCall.buVector5_0.Move(new Point3D(), new Point3D(num + num6 * num13, 0.0, 0.0), ref refEntities5);
				MarblecalcItemLines(refEntities4.StartPoint, refEntities5.StartPoint, refEntities4.EndPoint, refEntities5.EndPoint, num7, num8, num2, Position, StartMode: false, AddAllLines: true, isVertical: true, varOperation, ref CalcLines, ref Cnt);
				num2 = num8 * -1.0;
				num = num + num14 + num6 * num15 + num6 * num16;
				if (!AlwaysSAandEAZero)
				{
					Cnt++;
				}
			}
		}
		if (num4 < 0.0)
		{
			buCall.buVector5_0.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref Entities);
			buCall.buVector5_0.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref CalcLines);
			buCall.buVector5_0.Mirror(new Point3D(Position.X, 0.0, 0.0), new Point3D(Position.X, 1.0, 0.0), Plane.XY, ref entRectangles);
		}
	}

	public void MarblecalcItemLines(Point3D FirstUpPnt, Point3D FirstDownPnt, Point3D LastUpPnt, Point3D LastDownPnt, double StartAngle, double EndAngle, double LastA, Pnt6D Position, bool StartMode, bool AddAllLines, bool isVertical, MarbleItemSettings varOperation, ref List<List<buEntity>> Entities, ref int Cnt)
	{
		List<buEntity> list = new List<buEntity>();
		List<Point3D> CalcPoints = new List<Point3D>();
		List<Point3D> CalcPoints2 = new List<Point3D>();
		MarbleItemHeightByDirection(varOperation.settingSliceCut.SliceDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.settingMarbleCam.SawForwardStepDownDistance, varOperation.settingMarbleCam.SawBackwardStepDownDistance, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, FirstUpPnt, FirstDownPnt, ref CalcPoints);
		MarbleItemHeightByDirection(varOperation.settingSliceCut.SliceDirection, HeightStepCalculationType.DontChangeBaseStepMakeExtraStep, varOperation.settingMarbleCam.SawForwardStepDownDistance, varOperation.settingMarbleCam.SawBackwardStepDownDistance, varOperation.MaterialParameter.MaterialThickness, varOperation.settingMarbleCam.TargetZ, LastUpPnt, LastDownPnt, ref CalcPoints2);
		list = new List<buEntity>();
		for (int i = 0; i <= CalcPoints.Count - 1; i++)
		{
			buLine buLine2 = new buLine(CalcPoints[i], CalcPoints2[i]);
			if (isVertical)
			{
				if (!StartMode)
				{
					if (EndAngle != 0.0)
					{
						if (!(EndAngle >= 0.0))
						{
							buLine2.Orientation = new OrientationAngle(0.0 - EndAngle, 0.0, Position.C);
						}
						else
						{
							buLine2.Orientation = new OrientationAngle(EndAngle, 0.0, Position.C + 180.0);
							buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
						}
					}
					else
					{
						buLine2.Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
					}
				}
				else if (StartAngle != 0.0)
				{
					if (!(StartAngle > 0.0))
					{
						buLine2.Orientation = new OrientationAngle(0.0 - StartAngle, 0.0, Position.C + 180.0);
						buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
					}
					else
					{
						buLine2.Orientation = new OrientationAngle(StartAngle, 0.0, Position.C);
					}
				}
				else
				{
					buLine2.Orientation = new OrientationAngle(StartAngle, 0.0, Position.C);
				}
			}
			else if (!StartMode)
			{
				if (!(EndAngle >= 0.0))
				{
					buLine2.Orientation = new OrientationAngle(0.0 - EndAngle, 0.0, Position.C + 180.0);
					buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
				}
				else
				{
					buLine2.Orientation = new OrientationAngle(EndAngle, 0.0, Position.C);
				}
			}
			else if (!(StartAngle > 0.0))
			{
				buLine2.Orientation = new OrientationAngle(0.0 - StartAngle, 0.0, Position.C);
			}
			else
			{
				buLine2.Orientation = new OrientationAngle(StartAngle, 0.0, Position.C + 180.0);
				buCall.buVector5_0.CamDirectionChange(ref buLine2.sortDirection);
			}
			buLine2.Marble = new MarbleInfo();
			list.Add(buLine2);
		}
		if (!StartMode)
		{
			if (list.Count > 0)
			{
				Entities.Add(list);
			}
		}
		else
		{
			if (list.Count <= 0)
			{
				return;
			}
			if (Entities.Count != 0)
			{
				if (AddAllLines)
				{
					Entities.Add(list);
				}
				else if (LastA == StartAngle)
				{
					if (!buCompare5.EQ(Position.C, 0.0))
					{
						Entities.Add(list);
					}
				}
				else
				{
					Entities.Add(list);
				}
			}
			else
			{
				Entities.Add(list);
			}
		}
	}

	public void MarblecalcItemCam(ToolBase5 Tool, KinematicBase5 Kinematic, MarbleJob Job, int indexBase, bool isLast, TpPnt9D LastP9, MarbleItem Item, ref MarbleItemCam marbleCam)
	{
		List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
		if ((Item.Settings.settingMarbleCam.CuttingDirection == CamCuttingDirectionType.Forward) | (Item.Settings.settingMarbleCam.CuttingDirection == CamCuttingDirectionType.Backward))
		{
			List<List<buEntity>> list = new List<List<buEntity>>();
			for (int i = 0; i <= Item.ItemEntities.WireEntities.Count - 1; i++)
			{
				for (int j = 0; j <= Item.ItemEntities.WireEntities[i].Count - 1; j++)
				{
					List<buEntity> list2 = new List<buEntity>();
					buEntity copiedEntity = new buEntity();
					buEntity.Copy(Item.ItemEntities.WireEntities[i][j], ref copiedEntity);
					list2.Add(copiedEntity);
					list.Add(list2);
				}
			}
			buEntity.Copy(list, ref copiedEntities);
		}
		CalculateMarbleWireFrameWithSaw(Kinematic, Tool, Job, indexBase, isLast, LastP9, ref Item, ref marbleCam);
		if (marbleCam.CamBase == null)
		{
			return;
		}
		marbleCam.CamBase.Name = marbleCam.CamName;
		marbleCam.CamBase.AxisCount = 5;
		marbleCam.CamBase.TypeCam = CamType.SawCut;
		marbleCam.CamBase.Explanation = buLangTranslate.preDef.Slice + " " + buLangTranslate.preDef.Cutting;
		marbleCam.isCamCalculated = true;
		Pnt6D calcPoint = new Pnt6D();
		_ = Math.Cos(buConversion5.DegreeToRadian(Item.CamPoint.C)) * Kinematic.RotateCenterOffsetOfC.Y;
		_ = Math.Sin(buConversion5.DegreeToRadian(Item.CamPoint.C)) * Kinematic.RotateCenterOffsetOfC.Y;
		CalculatePointsWithKinematic(new Pnt6D(0.0, 0.0, 0.0, 0.0, 0.0, Item.CamPoint.C), Kinematic, Tool, ref calcPoint);
		if (Item.ItemType != MarbleItemType.HorizontalCut)
		{
			if (Item.ItemType == MarbleItemType.VerticalCut)
			{
				marbleCam.CamBase.PositionOffset.X = 0.0 - Math.Round(calcPoint.X, 3);
				marbleCam.CamBase.PositionOffset.Y = 0.0 - Math.Round(calcPoint.Y, 3);
			}
		}
		else
		{
			marbleCam.CamBase.PositionOffset.X = 0.0 - Math.Round(calcPoint.X, 3);
			marbleCam.CamBase.PositionOffset.Y = 0.0 - Math.Round(calcPoint.Y, 3);
		}
		if (!((Item.ItemType == MarbleItemType.SingleCut) & Item.isVacuumCut))
		{
		}
	}

	public void MarbleItemHeightByDirection(CamCuttingDirectionType CutDir, HeightStepCalculationType StepType, double ForwardStep, double BackwardStep, double StartZ, double EndZ, Point3D StartPoint, Point3D EndPoint, ref List<Point3D> CalcPoints)
	{
		try
		{
			List<double> CalculatedHeight = new List<double>();
			CalcPoints.Clear();
			if (CutDir == CamCuttingDirectionType.Forward)
			{
				buCall.buVector_0.StepLengthCalculation(StepType, ForwardStep, StartZ, EndZ, ref CalculatedHeight);
				for (int i = 0; i <= CalculatedHeight.Count - 1; i++)
				{
					Point3D CalcPoint = new Point3D();
					buCall.buVector5_0.XYFromZ(StartPoint, EndPoint, CalculatedHeight[i], ref CalcPoint);
					CalcPoints.Add(CalcPoint);
				}
			}
			if (CutDir == CamCuttingDirectionType.Backward)
			{
				buCall.buVector_0.StepLengthCalculation(StepType, BackwardStep, StartZ, EndZ, ref CalculatedHeight);
				for (int j = 0; j <= CalculatedHeight.Count - 1; j++)
				{
					Point3D CalcPoint2 = new Point3D();
					buCall.buVector5_0.XYFromZ(StartPoint, EndPoint, CalculatedHeight[j], ref CalcPoint2);
					CalcPoints.Add(CalcPoint2);
				}
			}
			if (CutDir != CamCuttingDirectionType.ForwardBackward)
			{
				return;
			}
			buCall.buVector_0.StepLengthCalculation(StepType, ForwardStep + BackwardStep, StartZ, EndZ, ref CalculatedHeight);
			List<double> list = new List<double>();
			double num = StartZ;
			for (int k = 0; k <= CalculatedHeight.Count - 1; k++)
			{
				double num2 = num - CalculatedHeight[k];
				double num3 = BackwardStep / num2;
				if (!(num2 >= ForwardStep + BackwardStep))
				{
					list.Add(CalculatedHeight[k]);
				}
				else
				{
					list.Add(num2 * num3 + CalculatedHeight[k]);
					list.Add(CalculatedHeight[k]);
				}
				num = CalculatedHeight[k];
			}
			buGeneral.CopyLists(list, ref CalculatedHeight);
			for (int l = 0; l <= CalculatedHeight.Count - 1; l++)
			{
				Point3D CalcPoint3 = new Point3D();
				buCall.buVector5_0.XYFromZ(StartPoint, EndPoint, CalculatedHeight[l], ref CalcPoint3);
				CalcPoints.Add(CalcPoint3);
			}
		}
		catch (Exception mSException)
		{
			string text = "CutDir: " + CutDir.ToString() + " - StepType: " + StepType.ToString() + " - ForwardStep: " + ForwardStep + " - BackwardStep: " + BackwardStep + " - StepStartZ: " + StartZ + " - EndZ: " + EndZ;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void calcProfileVectors(List<List<Point3D>> refPoints, VectorType Direction, ToolBase5 Tool, bool MaxToMinDirection, marbleProfileCutPars varProfileCut, ref List<Point3D> calcProfilePoints)
	{
		double num = -1.0;
		new Point3D();
		calcProfilePoints.Clear();
		calcProfilePoints = new List<Point3D>();
		new List<Point3D>();
		for (int i = 0; i <= refPoints.Count - 1; i++)
		{
			for (int j = 0; j <= refPoints[i].Count - 1; j++)
			{
				bool flag = false;
				Point3D point3D = buVector5.ToPoint3D(refPoints[i][j]);
				Point3D secondLineEnd = new Point3D();
				Point3D point3D2 = new Point3D();
				Point3D point3D3 = new Point3D();
				Point3D point3D4 = buVector5.ToPoint3D(refPoints[i][j]);
				double value = 0.0;
				double value2 = -1.0;
				if (j != 40)
				{
				}
				if (j != 0)
				{
					if (Direction == VectorType.XVector)
					{
						value = buCall.buVector5_0.PointAngle(refPoints[i][j], refPoints[i][j - 1], Plane.YZ);
						if (j < refPoints[i].Count - 1)
						{
							value2 = buCall.buVector5_0.PointAngle(refPoints[i][j + 1], refPoints[i][j], Plane.YZ);
						}
					}
					if (Direction == VectorType.YVector)
					{
						value = buCall.buVector5_0.PointAngle(refPoints[i][j], refPoints[i][j - 1], Plane.XZ);
						if (j < refPoints[i].Count - 1)
						{
							value2 = buCall.buVector5_0.PointAngle(refPoints[i][j + 1], refPoints[i][j], Plane.XZ);
						}
					}
				}
				else
				{
					if (Direction == VectorType.XVector)
					{
						value = buCall.buVector5_0.PointAngle(refPoints[i][j + 1], refPoints[i][j], Plane.YZ);
						if (j < refPoints[i].Count - 2)
						{
							value2 = buCall.buVector5_0.PointAngle(refPoints[i][j + 2], refPoints[i][j + 1], Plane.YZ);
						}
					}
					if (Direction == VectorType.YVector)
					{
						value = buCall.buVector5_0.PointAngle(refPoints[i][j + 1], refPoints[i][j], Plane.XZ);
						if (j < refPoints[i].Count - 2)
						{
							value2 = buCall.buVector5_0.PointAngle(refPoints[i][j + 2], refPoints[i][j + 1], Plane.XZ);
						}
					}
				}
				value = Math.Round(value, 3);
				value2 = Math.Round(value2, 3);
				if (j < refPoints[i].Count - 1)
				{
					point3D3 = buVector5.ToPoint3D(refPoints[i][j + 1]);
				}
				if (varProfileCut.CamTypeFinish == CamAxisCountType.Axis3)
				{
					if (Direction == VectorType.XVector && !MaxToMinDirection)
					{
						if (!((value > 180.0 && num < 180.0 && num > 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1)))
						{
						}
						point3D = ((value < 180.0) ? new Point3D(point3D4.X, point3D4.Y - Tool.Geometry.Thickness / 2.0, point3D4.Z) : new Point3D(point3D4.X, point3D4.Y + Tool.Geometry.Thickness / 2.0, point3D4.Z));
						secondLineEnd = ((value2 < 180.0) ? new Point3D(point3D3.X, point3D3.Y - Tool.Geometry.Thickness / 2.0, point3D3.Z) : new Point3D(point3D3.X, point3D3.Y + Tool.Geometry.Thickness / 2.0, point3D3.Z));
						if ((((value <= 180.0 && (num > 180.0 || num == 0.0) && value != num) & (Math.Abs(value - num) < 360.0)) && num >= 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1))
						{
							Point3D pntIntersect = new Point3D();
							buCall.buVector5_0.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], point3D, secondLineEnd, Plane.YZ, ref pntIntersect);
							if (buNumeric5.IsNumeric(pntIntersect.Y.ToString()))
							{
								for (int k = 0; k <= calcProfilePoints.Count - 1; k++)
								{
									if (calcProfilePoints[k].Y > pntIntersect.Y)
									{
										calcProfilePoints.RemoveRange(k, calcProfilePoints.Count - k);
										k = calcProfilePoints.Count;
									}
								}
								calcProfilePoints.Add(buVector5.ToPoint3D(pntIntersect));
							}
						}
					}
					if (Direction == VectorType.XVector && MaxToMinDirection)
					{
						if (!((value < 180.0 && num > 180.0 && num > 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1)))
						{
						}
						if (!buCompare5.EQ(value, 180.0, 0.1))
						{
							if (!(value < 180.0))
							{
								if (value > 180.0)
								{
									point3D = new Point3D(point3D4.X, point3D4.Y - Tool.Geometry.Thickness / 2.0, point3D4.Z);
								}
							}
							else
							{
								point3D = new Point3D(point3D4.X, point3D4.Y + Tool.Geometry.Thickness / 2.0, point3D4.Z);
							}
						}
						else
						{
							point3D = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
						}
						if (!buCompare5.EQ(value2, 180.0, 0.1))
						{
							if (!(value2 < 180.0))
							{
								if (value2 > 180.0)
								{
									secondLineEnd = new Point3D(point3D3.X, point3D3.Y - Tool.Geometry.Thickness / 2.0, point3D3.Z);
								}
							}
							else
							{
								secondLineEnd = new Point3D(point3D3.X, point3D3.Y + Tool.Geometry.Thickness / 2.0, point3D3.Z);
							}
						}
						else
						{
							secondLineEnd = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
						}
						if ((value <= 180.0 && (num >= 180.0 || num == 0.0) && value != num && num >= 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1))
						{
							Point3D pntIntersect2 = new Point3D();
							buCall.buVector5_0.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], point3D, secondLineEnd, Plane.YZ, ref pntIntersect2);
							if (buNumeric5.IsNumeric(pntIntersect2.Y.ToString()))
							{
								for (int l = 0; l <= calcProfilePoints.Count - 1; l++)
								{
									if (calcProfilePoints[l].Y < pntIntersect2.Y)
									{
										calcProfilePoints.RemoveRange(l, calcProfilePoints.Count - l);
										l = calcProfilePoints.Count;
									}
								}
								calcProfilePoints.Add(buVector5.ToPoint3D(pntIntersect2));
							}
						}
					}
					if (Direction == VectorType.YVector && MaxToMinDirection)
					{
						if (!((value < 180.0 && num > 180.0 && num > 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1)))
						{
						}
						if (!buCompare5.EQ(value, 180.0, 0.1))
						{
							if (!(value < 180.0))
							{
								if (value > 180.0)
								{
									point3D = new Point3D(point3D4.X, point3D4.Y - Tool.Geometry.Thickness / 2.0, point3D4.Z);
								}
							}
							else
							{
								point3D = new Point3D(point3D4.X + Tool.Geometry.Thickness / 2.0, point3D4.Y, point3D4.Z);
							}
						}
						else
						{
							point3D = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
						}
						if (!buCompare5.EQ(value2, 180.0, 0.1))
						{
							if (!(value2 < 180.0))
							{
								if (value2 > 180.0)
								{
									secondLineEnd = new Point3D(point3D3.X, point3D3.Y - Tool.Geometry.Thickness / 2.0, point3D3.Z);
								}
							}
							else
							{
								secondLineEnd = new Point3D(point3D3.X, point3D3.Y + Tool.Geometry.Thickness / 2.0, point3D3.Z);
							}
						}
						else
						{
							secondLineEnd = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
						}
						if ((value <= 180.0 && (num >= 180.0 || num == 0.0) && value != num && num >= 0.0) & (calcProfilePoints.Count > 0) & (j < refPoints[i].Count - 1))
						{
							Point3D pntIntersect3 = new Point3D();
							buCall.buVector5_0.LineLineIntersection(calcProfilePoints[calcProfilePoints.Count - 2], calcProfilePoints[calcProfilePoints.Count - 1], point3D, secondLineEnd, Plane.YZ, ref pntIntersect3);
							if (buNumeric5.IsNumeric(pntIntersect3.Y.ToString()))
							{
								for (int m = 0; m <= calcProfilePoints.Count - 1; m++)
								{
									if (calcProfilePoints[m].Y < pntIntersect3.Y)
									{
										calcProfilePoints.RemoveRange(m, calcProfilePoints.Count - m);
										m = calcProfilePoints.Count;
									}
								}
								calcProfilePoints.Add(buVector5.ToPoint3D(pntIntersect3));
							}
						}
					}
				}
				num = value;
				if (flag)
				{
					calcProfilePoints.Add(new Point3D(point3D2.X, point3D2.Y, point3D2.Z));
				}
				if (varProfileCut.CamTypeFinish == CamAxisCountType.Axis3)
				{
					if (calcProfilePoints.Count != 0)
					{
						if (Direction == VectorType.XVector)
						{
							if (MaxToMinDirection)
							{
								if ((point3D.Y <= calcProfilePoints[calcProfilePoints.Count - 1].Y) | buCompare5.EQ(point3D.Y, calcProfilePoints[calcProfilePoints.Count - 1].Y))
								{
									calcProfilePoints.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
								}
							}
							else if ((point3D.Y >= calcProfilePoints[calcProfilePoints.Count - 1].Y) | buCompare5.EQ(point3D.Y, calcProfilePoints[calcProfilePoints.Count - 1].Y))
							{
								calcProfilePoints.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
							}
						}
					}
					else
					{
						calcProfilePoints.Add(new Point3D(point3D.X, point3D.Y, point3D.Z));
					}
				}
				buVector5.ToPoint3D(refPoints[i][j]);
			}
		}
	}

	public void calcAnalayseGeometryForProfileCut(List<buEntity> entSorted, ToolBase5 Tool, bool MaxToMinDirection, Plane entPlane, double FinishResolutionLen, double RoughtResolutionLen, double DownResolutionLen, ref List<List<Point3D>> reCalcRoughPoints, ref List<List<Point3D>> reCalcSmoothPoints)
	{
		ClockDirectionType clockDirectionType = ClockDirectionType.CCW;
		reCalcRoughPoints.Clear();
		reCalcSmoothPoints.Clear();
		for (int i = 0; i <= entSorted.Count - 1; i++)
		{
			List<Point3D> CopiedPnt = new List<Point3D>();
			ClockDirectionType clockDirectionType2 = ClockDirectionType.CCW;
			List<Point3D> Points = new List<Point3D>();
			List<Point3D> Points2 = new List<Point3D>();
			buEntity copiedEntity = new buEntity();
			buEntity.Copy(entSorted[i], ref copiedEntity);
			if (i <= entSorted.Count - 1)
			{
				int num = i;
				if (i == entSorted.Count - 1)
				{
					num = i - 1;
				}
				if (entSorted.Count == 1)
				{
					num = i;
				}
				List<Point3D> list = new List<Point3D>();
				if (entSorted[num].sortDirection == entitySortDirection.Normal)
				{
					list.Add(buVector5.ToPoint3D(entSorted[num].Vertices[entSorted[num].Vertices.Count - 2]));
					list.Add(buVector5.ToPoint3D(entSorted[num].Vertices[entSorted[num].Vertices.Count - 1]));
					buVector5.Add(list, ref CopiedPnt);
				}
				if (entSorted[num].sortDirection == entitySortDirection.Reverse)
				{
					list.Add(buVector5.ToPoint3D(entSorted[num].Vertices[1]));
					list.Add(buVector5.ToPoint3D(entSorted[num].Vertices[0]));
					buVector5.Add(list, ref CopiedPnt);
				}
				list = new List<Point3D>();
				if (entSorted[num + 1].sortDirection == entitySortDirection.Normal)
				{
					list.Add(buVector5.ToPoint3D(entSorted[num + 1].Vertices[0]));
					list.Add(buVector5.ToPoint3D(entSorted[num + 1].Vertices[1]));
					buVector5.Add(list, ref CopiedPnt);
				}
				if (entSorted[num + 1].sortDirection == entitySortDirection.Reverse)
				{
					list.Add(buVector5.ToPoint3D(entSorted[num + 1].Vertices[entSorted[num + 1].Vertices.Count - 1]));
					list.Add(buVector5.ToPoint3D(entSorted[num + 1].Vertices[entSorted[num + 1].Vertices.Count - 2]));
					buVector5.Add(list, ref CopiedPnt);
				}
				buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref CopiedPnt);
				if (CopiedPnt.Count >= 3)
				{
					CopiedPnt.Add(buVector5.ToPoint3D(CopiedPnt[0]));
					clockDirectionType2 = buCall.buVector5_0.GetClockDirection(CopiedPnt);
				}
			}
			if (i == 0)
			{
				if (MaxToMinDirection)
				{
					if (entSorted[i].GetType() == typeof(buLine))
					{
						if (clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType2 == ClockDirectionType.CCW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
					if (entSorted[i].GetType() == typeof(buArc))
					{
						if (clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType2 == ClockDirectionType.CCW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
				}
				else
				{
					if (entSorted[i].GetType() == typeof(buLine))
					{
						if (clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType2 == ClockDirectionType.CW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
					if (entSorted[i].GetType() == typeof(buArc))
					{
						if (clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType2 == ClockDirectionType.CW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
				}
			}
			if ((i > 0) & (i < entSorted.Count - 1))
			{
				if (MaxToMinDirection)
				{
					if (entSorted[i].GetType() == typeof(buLine))
					{
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref copiedEntity);
						}
					}
					if (entSorted[i].GetType() == typeof(buArc))
					{
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref copiedEntity);
						}
					}
				}
				else
				{
					if (entSorted[i].GetType() == typeof(buLine))
					{
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
					if (entSorted[i].GetType() == typeof(buArc))
					{
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.StartAndEnd, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CCW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.End, entPlane, ref copiedEntity);
						}
						if (clockDirectionType == ClockDirectionType.CW && clockDirectionType2 == ClockDirectionType.CW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
				}
			}
			if (i == entSorted.Count - 1)
			{
				if (MaxToMinDirection)
				{
					if (clockDirectionType2 == ClockDirectionType.CW)
					{
						buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
					}
					if (clockDirectionType2 == ClockDirectionType.CCW)
					{
						buEntity.Copy(entSorted[i], ref copiedEntity);
					}
				}
				else
				{
					if (entSorted[i].GetType() == typeof(buLine))
					{
						if (clockDirectionType2 == ClockDirectionType.CCW)
						{
							buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
						}
						if (clockDirectionType2 == ClockDirectionType.CW)
						{
							buEntity.Copy(entSorted[i], ref copiedEntity);
						}
					}
					if (entSorted[i].GetType() == typeof(buArc))
					{
						buCall.buVector5_0.EntityUpdateByLengthUsingCamDirection(entSorted[i], Tool.Geometry.Thickness / 2.0, StartPointType.Start, entPlane, ref copiedEntity);
					}
				}
			}
			if (!(copiedEntity is buLine))
			{
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, RoughtResolutionLen, ref Points);
				buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, FinishResolutionLen, ref Points2);
			}
			else
			{
				double value = buCall.buVector5_0.PointAngle(copiedEntity.EndPoint, copiedEntity.StartPoint);
				if (!(buCompare5.EQ(value, 90.0, 0.1) | buCompare5.EQ(value, 270.0, 0.1)))
				{
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, RoughtResolutionLen, ref Points);
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, FinishResolutionLen, ref Points2);
				}
				else
				{
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, DownResolutionLen, ref Points);
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntity, DownResolutionLen, ref Points2);
				}
			}
			if (entSorted[i].sortDirection == entitySortDirection.Reverse)
			{
				Points.Reverse();
				Points2.Reverse();
			}
			reCalcRoughPoints.Add(new List<Point3D>(Points));
			reCalcSmoothPoints.Add(new List<Point3D>(Points2));
			clockDirectionType = clockDirectionType2;
		}
	}

	public void convOperationParameterToEntityDataParameter(marbleCamPars OPPars, MarbleToolType ToolType, ref marbleEntityData EntityDataPar)
	{
		EntityDataPar.CuttingSpeed = OPPars.SawForwardCuttingVelocity;
		EntityDataPar.CuttingStep = OPPars.SawForwardStepDownDistance;
		EntityDataPar.PlungeSpeed = OPPars.SawPlungeVelocity;
		EntityDataPar.TargetZ = OPPars.TargetZ;
		EntityDataPar.ToolType = ToolType;
	}
}
