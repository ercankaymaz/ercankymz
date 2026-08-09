using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buCore.buClipperLib;

namespace buCore;

public class buCamCalc
{
	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_0;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_1;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_2;

	[CompilerGenerated]
	private CalculationEventHandler calculationEventHandler_3;

	[CompilerGenerated]
	private CalculationErrorEventHandler calculationErrorEventHandler_0;

	public EntitiesResolution EntityDevideResolution = new EntitiesResolution();

	public Pnt3D Pnt3LastPoint = new Pnt3D();

	public Pnt6D Pnt6LastPoint = new Pnt6D();

	public Pnt9D Pnt9LastPoint = new Pnt9D();

	public Pnt9DCam Pnt9CamLastPoint = new Pnt9DCam();

	public Color colorG1 = Color.Blue;

	public Color colorG0 = Color.Brown;

	public Color colorLeadIn = Color.Cyan;

	public Color colorLeadOut = Color.Orange;

	public Color colorPlunge = Color.Lime;

	public Color colorLeave = Color.Red;

	public Color colorMark = Color.Blue;

	public double entThickness = 2.0;

	public static List<List<Pnt3D>> pntTeachGrids;

	public event CalculationEventHandler CalculationInProgress
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_0;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_0, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_0;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_0, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationStarted
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_1;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_1, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_1;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_1, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationEnded
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_2;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_2, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_2;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_2, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationEventHandler CalculationCanceled
	{
		[CompilerGenerated]
		add
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_3;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Combine(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_3, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationEventHandler calculationEventHandler = calculationEventHandler_3;
			CalculationEventHandler calculationEventHandler2;
			do
			{
				calculationEventHandler2 = calculationEventHandler;
				CalculationEventHandler value2 = (CalculationEventHandler)Delegate.Remove(calculationEventHandler2, value);
				calculationEventHandler = Interlocked.CompareExchange(ref calculationEventHandler_3, value2, calculationEventHandler2);
			}
			while ((object)calculationEventHandler != calculationEventHandler2);
		}
	}

	public event CalculationErrorEventHandler CalculationError
	{
		[CompilerGenerated]
		add
		{
			CalculationErrorEventHandler calculationErrorEventHandler = calculationErrorEventHandler_0;
			CalculationErrorEventHandler calculationErrorEventHandler2;
			do
			{
				calculationErrorEventHandler2 = calculationErrorEventHandler;
				CalculationErrorEventHandler value2 = (CalculationErrorEventHandler)Delegate.Combine(calculationErrorEventHandler2, value);
				calculationErrorEventHandler = Interlocked.CompareExchange(ref calculationErrorEventHandler_0, value2, calculationErrorEventHandler2);
			}
			while ((object)calculationErrorEventHandler != calculationErrorEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			CalculationErrorEventHandler calculationErrorEventHandler = calculationErrorEventHandler_0;
			CalculationErrorEventHandler calculationErrorEventHandler2;
			do
			{
				calculationErrorEventHandler2 = calculationErrorEventHandler;
				CalculationErrorEventHandler value2 = (CalculationErrorEventHandler)Delegate.Remove(calculationErrorEventHandler2, value);
				calculationErrorEventHandler = Interlocked.CompareExchange(ref calculationErrorEventHandler_0, value2, calculationErrorEventHandler2);
			}
			while ((object)calculationErrorEventHandler != calculationErrorEventHandler2);
		}
	}

	public buCamCalc()
	{
		if (buVector.smethod_0("buCamCalc"))
		{
			if (calculationEventHandler_0 != null)
			{
				calculationEventHandler_0(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationEventHandler_3 != null)
			{
				calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "", ""));
			}
			if (calculationErrorEventHandler_0 != null)
			{
				calculationErrorEventHandler_0(new CalculationErrorEventArg("", "", "", 0));
			}
			return;
		}
		throw new RegisterException("buCamCalc");
	}

	public void CalculateGrindingContour(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, SimulationBase simPars, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Entities.Count / 100.0);
			int num2 = 0;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				eEntities copiedEnt = new eEntities();
				if (Entities[i].Count > 0)
				{
					eEntities copiedEnt2 = new eEntities();
					List<Pnt3D> TargetList = new List<Pnt3D>();
					eEntities.CopyEntity(Entities[i][0], ref copiedEnt2);
					buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
					List<Pnt6D> Points = new List<Pnt6D>();
					buAppCalc.cVector.EntityToPoint(Entities[i], buSystem.EntitiesResolution, ref Points);
					if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
					{
						TargetList.Reverse();
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					if (Points.Count > 1)
					{
						Pnt3D pnt3D2 = new Pnt3D(Points[0]);
						OrientationAngle orientationAngle = new OrientationAngle(Points[0]);
						new OrientationAngle(Points[0]);
						Pnt6D pnt6D = new Pnt6D();
						pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
						pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe);
						new Pnt6D(pnt6D);
						Pnt9DCam item2 = new Pnt9DCam(new Pnt6D(0.0, 0.0, camPars.Distances.Safe), camPars.Speeds.Leave, 0, plungemove: false, Leavemove: true);
						camPoint.EntitiesPlunge.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2), colorPlunge, entThickness));
						camPoint.Points.Add(item2);
						camPoint.NumberOfLeaveMovement++;
						pnt3D = new Pnt3D(pnt3D2);
						new Pnt6D(pnt6D);
						item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Rapid, 0, plungemove: false);
						camPoint.Points.Add(item2);
						pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), new OrientationAngle());
						item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Plunge, 1, plungemove: true, Leavemove: false);
						camPoint.Points.Add(item2);
						camPoint.NumberOfPlungeMovement++;
						List<Pnt3D> list = new List<Pnt3D>();
						double num3 = 0.0;
						if (Points.Count > 0)
						{
							list.Add(new Pnt3D(Points[0]));
						}
						for (int j = 1; j <= Points.Count - 1; j++)
						{
							pnt3D2 = new Pnt3D(Points[j]);
							orientationAngle = new OrientationAngle(Points[j]);
							double feed = camPars.Speeds.Feed;
							pnt6D = new Pnt6D(new Pnt3D(Points[j].X, Points[j].Y, Points[j].Z), new OrientationAngle());
							camPoint.Points.Add(new Pnt9DCam(pnt6D, feed, 1));
							list.Add(new Pnt3D(Points[j]));
							pnt3D = new Pnt3D(Points[j]);
							new Pnt6D(pnt6D);
							new OrientationAngle(orientationAngle);
						}
						if (list.Count >= 2)
						{
							geoPolyline geoPolyline2 = new geoPolyline(list, colorG1, entThickness);
							if (num3 != Convert.ToDouble(EntityPurposeType.LeadIn))
							{
								if (num3 != Convert.ToDouble(EntityPurposeType.LeadOut))
								{
									camPoint.EntitiesG1.Add(geoPolyline2);
								}
								else
								{
									geoPolyline2.Color = colorLeadOut;
									camPoint.EntitiesLeadOut.Add(geoPolyline2);
								}
							}
							else
							{
								geoPolyline2.Color = colorLeadIn;
								camPoint.EntitiesLeadIn.Add(geoPolyline2);
							}
							list = new List<Pnt3D>();
						}
						pnt6D = new Pnt6D(new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe), new OrientationAngle());
						item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 1, plungemove: false, Leavemove: true);
						camPoint.Points.Add(item2);
						camPoint.NumberOfLeaveMovement++;
						camPoint.EntitiesLeave.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorLeave, entThickness));
						if (camPoint.Points.Count > 0)
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
						}
						double num4 = 0.0;
						for (int k = 1; k <= camPoint.Points.Count - 1; k++)
						{
							List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
							double num5 = 0.1;
							double num6 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[k - 1]), new Pnt3D(camPoint.Points[k]));
							if (camPoint.Points[k].Type != 0)
							{
								if (!simPars.DevideG1Movement)
								{
									camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[k]));
								}
								else if (!((num6 > simPars.G1DevideLength) & (simPars.G1DevideLength > 0.0)))
								{
									if (!simPars.UseG1Filter)
									{
										camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[k]));
										continue;
									}
									if (!(num4 > simPars.G1FilterLength))
									{
										num4 += num6;
										continue;
									}
									camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[k]));
									num4 = 0.0;
								}
								else
								{
									num5 = simPars.G1DevideLength / num6;
									buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[k - 1]), new Pnt6D(camPoint.Points[k]), num5, ref CalculatedPoints);
									CalculatedPoints.RemoveAt(0);
									camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
									num4 = 0.0;
								}
							}
							else if (!simPars.DevideG0Movement)
							{
								camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[k]));
							}
							else if (!((num6 > simPars.G0DevideLength) & (simPars.G0DevideLength > 0.0)))
							{
								camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[k]));
							}
							else
							{
								num5 = simPars.G0DevideLength / num6;
								buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[k - 1]), new Pnt6D(camPoint.Points[k]), num5, ref CalculatedPoints);
								CalculatedPoints.RemoveAt(0);
								camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
							}
						}
						eEntities.CopyEntity(copiedEnt2, ref copiedEnt);
						calcCam.CamPoints.Add(camPoint);
					}
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num2++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateGrindingContourSaw(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, GrindingOperations Operation, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<List<Pnt6D>> list = new List<List<Pnt6D>>();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = true;
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0 - Kinematic.RotateCenterOffsetOfC.Y, 0.0 - Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
			new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			calcCam.Kinematic.Items.Add(kinematicItem);
			calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
			calcCam.Kinematic.MovePartRuntimeOffset.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
			calcCam.Kinematic.MovePartRuntimeOffset.Z = 0.0 - Kinematic.RotateCenterOffsetOfC.Z;
			bool useTangentLimit = camPars.Strategy.UseTangentLimit;
			double angleLimit = camPars.Strategy.AngleLimit;
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Entities.Count / 100.0);
			int num2 = 0;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				List<Pnt6D> list2 = new List<Pnt6D>();
				if (Entities[i].Count < 1)
				{
					continue;
				}
				List<Pnt6D> Points = new List<Pnt6D>();
				new List<Pnt6D>();
				buAppCalc.cVector.EntityToPoint(Entities[i], buSystem.EntitiesResolution, ref Points);
				buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
				if (Points.Count <= 1)
				{
					continue;
				}
				double value = 0.0;
				double num3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
				if ((Entities[i].Count == 1) & (Points[0].C != 0.0))
				{
					num3 = Points[0].C;
				}
				double num4 = num3;
				list2.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, num3));
				for (int j = 1; j <= Points.Count - 2; j++)
				{
					bool flag = false;
					num3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[j]), new Pnt3D(Points[j - 1]));
					double num6;
					double num7;
					if (!useTangentLimit)
					{
						angleLimit = camPars.Strategy.AngleLimit;
						double num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list2[list2.Count - 1]), new Pnt3D(Points[j]), new Pnt3D(Points[j]), new Pnt3D(Points[j + 1]), new WorkPlane());
						num6 = 180.0 - num5;
						if (num6 >= 360.0 - angleLimit)
						{
							num6 = 360.0 - num5;
						}
						num7 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[j + 1]), new Pnt3D(Points[j]));
						if (num6 > angleLimit)
						{
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num3));
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j + 1].A, 0.0, num7));
							flag = true;
						}
						Math.Abs(num3 - num4);
						if (Math.Abs(value) > buSystem.resolutionCompare && list2.Count > 1)
						{
							list.Add(list2);
							list2 = new List<Pnt6D>();
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num7));
							flag = true;
						}
					}
					else
					{
						value = Points[j - 1].A - Points[j].A;
						if (Math.Abs(num3 - list2[list2.Count - 1].C) > 185.0)
						{
							num3 = ((!(list2[list2.Count - 1].C <= num3)) ? (num3 + 360.0) : (num3 - 360.0));
						}
						num7 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[j + 1]), new Pnt3D(Points[j]));
						angleLimit = camPars.Strategy.AngleLimit;
						double num8 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list2[list2.Count - 1]), new Pnt3D(Points[j]), new Pnt3D(Points[j]), new Pnt3D(Points[j + 1]), new WorkPlane());
						num6 = 180.0 - num8;
						if (num6 >= 360.0 - angleLimit)
						{
							num6 = 360.0 - num8;
						}
						Math.Abs(num3 - num4);
						if (Math.Abs(value) > buSystem.resolutionCompare && list2.Count > 1)
						{
							list.Add(list2);
							list2 = new List<Pnt6D>();
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num7));
							flag = true;
						}
					}
					if (!flag)
					{
						if (num6 <= angleLimit || !useTangentLimit)
						{
							if (useTangentLimit)
							{
								double num9 = Math.Abs(num3 - list2[list2.Count - 1].C);
								if (num9 >= 360.0 - angleLimit)
								{
									num3 = ((!(num3 <= list2[list2.Count - 1].C)) ? (num3 - 360.0) : (num3 + 360.0));
									num9 = Math.Abs(num3 - list2[list2.Count - 1].C);
								}
								if (num9 > 185.0)
								{
									num3 += 360.0;
								}
							}
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num3));
							if (Math.Abs(num3 - num7) > 180.1)
							{
								double value2 = num3 - num7;
								if (num3 <= num7)
								{
									double num10 = buNumeric.RoundToLower(Math.Abs(value2) / 360.0);
									num7 -= 360.0 + num10 * 360.0;
								}
								else
								{
									double num11 = buNumeric.RoundToLower(Math.Abs(value2) / 360.0);
									num7 += 360.0 + num11 * 360.0;
								}
							}
							if (camPars.Options.AxesLimit.MinLimit != camPars.Options.AxesLimit.MaxLimit)
							{
								if (num7 > camPars.Options.AxesLimit.MaxLimit.C)
								{
									list.Add(list2);
									num3 -= 360.0;
									list2 = new List<Pnt6D>();
									list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num3));
								}
								if (num7 < camPars.Options.AxesLimit.MinLimit.C)
								{
									list.Add(list2);
									num3 += 360.0;
									list2 = new List<Pnt6D>();
									list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num3));
								}
							}
						}
						else
						{
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num3));
							list.Add(list2);
							list2 = new List<Pnt6D>();
							list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j + 1].A, 0.0, num7));
						}
					}
					num4 = num3;
				}
				if (list2.Count <= 0)
				{
					continue;
				}
				num3 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
				if ((Entities[i].Count == 1) & (Points[Points.Count - 1].C != 0.0))
				{
					num3 = Points[Points.Count - 1].C;
				}
				double num12 = Math.Abs(num3 - list2[list2.Count - 1].C);
				if (num12 >= 360.0 - angleLimit)
				{
					num12 = 360.0 - num3;
					if (num3 > list2[list2.Count - 1].C)
					{
						num3 -= 360.0;
					}
				}
				if (num12 > 185.0)
				{
					num3 += 360.0;
				}
				list2.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, num3));
				list.Add(list2);
			}
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			double num13 = camPars.Distances.Safe;
			OrientationAngle orientationAngle = new OrientationAngle();
			if (Operation.SawRampEnable & (Operation.SawRampType != CamZRampType.None))
			{
				for (int k = 0; k <= list.Count - 1; k++)
				{
					List<double> list3 = new List<double>();
					List<Pnt6D> CopiedPnt = new List<Pnt6D>();
					List<Pnt6D> calcStartPoints = new List<Pnt6D>();
					List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
					List<Pnt6D> calcEndPoints = new List<Pnt6D>();
					Pnt6D.Copy(list[k], ref CopiedPnt);
					buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, DevideMiddlePoints: true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
					if (Operation.SawRampType == CamZRampType.Linear)
					{
						list3 = new List<double>();
						buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, camPars.Operations.TargetZ, calcStartPoints.Count, ref list3);
						for (int l = 0; l <= list3.Count - 1; l++)
						{
							calcStartPoints[l] = new Pnt6D(calcStartPoints[l].X, calcStartPoints[l].Y, list3[l], calcStartPoints[l].A, calcStartPoints[l].B, calcStartPoints[l].C);
						}
						list3 = new List<double>();
						buNumeric.DevideMinMaxValueByNumber(camPars.Operations.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref list3);
						for (int m = 0; m <= list3.Count - 1; m++)
						{
							calcEndPoints[m] = new Pnt6D(calcEndPoints[m].X, calcEndPoints[m].Y, list3[m], calcEndPoints[m].A, calcEndPoints[m].B, calcEndPoints[m].C);
						}
					}
					if (Operation.SawRampType == CamZRampType.Circular)
					{
						List<Pnt3D> Points2 = new List<Pnt3D>();
						list3 = new List<double>();
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, camPars.Operations.TargetZ, 1.0, 200, ref list3, ref Points2);
						double num14 = 0.0;
						calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, list3[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
						for (int n = 1; n <= calcStartPoints.Count - 1; n++)
						{
							double num15 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[n - 1]), new Pnt3D(calcStartPoints[n]), new WorkPlane());
							num14 += num15;
							double num16 = 0.0;
							double num17 = 0.0;
							for (int num18 = 1; num18 <= Points2.Count - 1; num18++)
							{
								double num19 = buAppCalc.cVector.Length3D(new Pnt3D(Points2[num18 - 1].X, Points2[num18 - 1].Y), new Pnt3D(Points2[num18].X, Points2[num18].Y));
								num16 += num19;
								if (num17 <= num14 && num14 <= num16)
								{
									calcStartPoints[n] = new Pnt6D(calcStartPoints[n].X, calcStartPoints[n].Y, list3[num18], calcStartPoints[n].A, calcStartPoints[n].B, calcStartPoints[n].C);
									num18 = 100000;
								}
								num17 = num16;
							}
						}
						calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, list3[list3.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
						list3 = new List<double>();
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, camPars.Operations.TargetZ, Operation.SawRampHeight, 1.0, 200, ref list3, ref Points2);
						num14 = 0.0;
						calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, list3[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
						for (int num20 = 1; num20 <= calcEndPoints.Count - 1; num20++)
						{
							double num21 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[num20 - 1]), new Pnt3D(calcEndPoints[num20]), new WorkPlane());
							num14 += num21;
							double num22 = 0.0;
							double num23 = 0.0;
							for (int num24 = 1; num24 <= Points2.Count - 1; num24++)
							{
								double num25 = buAppCalc.cVector.Length3D(new Pnt3D(Points2[num24 - 1].X, Points2[num24 - 1].Y), new Pnt3D(Points2[num24].X, Points2[num24].Y));
								num22 += num25;
								if (num23 <= num14 && num14 <= num22)
								{
									calcEndPoints[num20] = new Pnt6D(calcEndPoints[num20].X, calcEndPoints[num20].Y, list3[num24], calcEndPoints[num20].A, calcEndPoints[num20].B, calcEndPoints[num20].C);
									num24 = 100000;
								}
								num23 = num22;
							}
						}
						calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, list3[list3.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
					}
					List<Pnt6D> Points3 = new List<Pnt6D>();
					Points3.AddRange(calcStartPoints);
					Points3.AddRange(calcMiddlePoints);
					Points3.AddRange(calcEndPoints);
					buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points3);
					list[k] = new List<Pnt6D>();
					list[k] = Points3;
				}
			}
			for (int num26 = 0; num26 <= list.Count - 1; num26++)
			{
				double toolLength = Tool.Geometry.Diameter / 2.0;
				double feed = camPars.Speeds.Feed;
				double safe = camPars.Distances.Safe;
				Pnt6D pnt6D2 = new Pnt6D();
				new Pnt6D();
				Pnt6D pnt6D3 = new Pnt6D();
				Pnt3D pnt3D2 = new Pnt3D();
				Pnt3D pnt3D3 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				OrientationAngle orientationAngle2 = new OrientationAngle();
				OrientationAngle orientationAngle3 = new OrientationAngle();
				Pnt9DCam pnt9DCam = new Pnt9DCam();
				Pnt9DCam pnt9DCam2 = new Pnt9DCam();
				if (num26 <= list.Count - 2)
				{
					orientationAngle3 = new OrientationAngle(new Pnt6D(list[num26 + 1][0]));
				}
				camPoint = new CamPoint();
				camPoint.Type = 0;
				camPoint.IsRapid = true;
				pnt6D3 = new Pnt6D();
				pnt6D2 = new Pnt6D(list[num26][0]);
				pnt3D2 = new Pnt3D(pnt6D2);
				pnt3D3 = new Pnt3D();
				pnt3D4 = new Pnt3D();
				orientationAngle2 = new OrientationAngle(pnt6D2);
				feed = camPars.Speeds.Feed;
				safe = (num13 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				pnt6D3 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
				pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				if (orientationAngle2.A != orientationAngle.A && pnt6D.Z > pnt6D3.Z)
				{
					pnt6D3.Z = pnt6D.Z;
				}
				pnt9DCam2 = new Pnt9DCam(pnt6D3, camPars.Speeds.Rapid, 0, plungemove: true);
				if (num26 > 0)
				{
					camPoint.Points.Add(pnt9DCam2);
				}
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D3);
				pnt6D3 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
				pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				pnt9DCam = new Pnt9DCam(pnt6D3, camPars.Speeds.Rapid, 0);
				if (num26 == 0)
				{
					pnt9DCam.EnableAxes.Z = false;
				}
				camPoint.Points.Add(pnt9DCam);
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D3);
				if (num26 == 0)
				{
					camPoint.Points.Add(pnt9DCam2);
					new Pnt6D(pnt6D3);
				}
				pnt6D3 = new Pnt6D();
				pnt3D4 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D3);
				pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPars.Speeds.Plunge, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D4), Color.Lime));
				pnt3D = new Pnt3D(pnt3D2);
				new Pnt6D(pnt6D3);
				List<Pnt3D> list4 = new List<Pnt3D>();
				list4.Add(new Pnt3D(pnt3D));
				for (int num27 = 1; num27 <= list[num26].Count - 1; num27++)
				{
					pnt6D2 = new Pnt6D(list[num26][num27]);
					orientationAngle2 = new OrientationAngle(pnt6D2);
					pnt6D3 = new Pnt6D();
					pnt3D4 = new Pnt3D(pnt6D2);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, feed, 1));
					list4.Add(new Pnt3D(pnt3D4));
					pnt3D = new Pnt3D(pnt6D2);
					new Pnt6D(pnt6D3);
					orientationAngle = new OrientationAngle(orientationAngle2);
				}
				if (list4.Count > 0)
				{
					camPoint.EntitiesG1.Add(new geoPolyline(list4, Color.Blue));
				}
				safe = (camPars.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				double length = (camPars.Material.Thickness + camPars.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				bool flag2 = orientationAngle2.A != orientationAngle3.A;
				if (num26 == list.Count - 1)
				{
					flag2 = true;
				}
				pnt6D3 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), length, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
				pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPars.Speeds.Leave, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Red));
				num13 = camPars.Material.Thickness + camPars.Distances.StepUp;
				orientationAngle = new OrientationAngle(orientationAngle2);
				if (flag2)
				{
					pnt6D3 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPars.Speeds.Rapid, 0));
					camPoint.EntitiesG0.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Gold));
					num13 = camPars.Distances.Safe;
				}
				pnt6D = new Pnt6D(pnt6D3);
				if (camPoint.Points.Count > 0)
				{
					camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
				}
				for (int num28 = 1; num28 <= camPoint.Points.Count - 1; num28++)
				{
					List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
					double dt = 0.1;
					if (camPoint.Points[num28].Type == 0)
					{
						dt = 0.25;
					}
					if (buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num28 - 1]), new Pnt3D(camPoint.Points[num28])) <= 3.0)
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[num28]));
						continue;
					}
					buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[num28 - 1]), new Pnt6D(camPoint.Points[num28]), dt, ref CalculatedPoints);
					CalculatedPoints.RemoveAt(0);
					camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
				}
				calcCam.CamPoints.Add(camPoint);
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)num26 / (double)(list.Count - 1)) * 100.0, Convert.ToDouble((double)num26 / (double)(list.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
				{
					Application.DoEvents();
				}
				if (buSystem.Cancel)
				{
					buSystem.Cancel = false;
					buSystem.Canceled = true;
					if (calculationEventHandler_2 != null)
					{
						calculationEventHandler_2(new CalculationEventArg());
					}
					if (calculationEventHandler_3 != null)
					{
						calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
					}
					buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
					return;
				}
				num2++;
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateGrindingHole(Pnt3D RefPoint, KinematicBase Kinematic, ToolBase Tool, camParameters camPars, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = 1;
			int num2 = 1;
			camPoint = new CamPoint();
			camPoint.Type = 0;
			camPoint.IsRapid = true;
			Pnt3D pnt3D2 = new Pnt3D(RefPoint);
			Pnt6D pnt6D = new Pnt6D();
			pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
			new Pnt6D(pnt6D);
			Pnt9DCam item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 0, plungemove: true);
			camPoint.Points.Add(item2);
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
			pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
			new Pnt6D(pnt6D);
			item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 0, plungemove: false);
			camPoint.Points.Add(item2);
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
			pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.FirstApproach), new OrientationAngle());
			new Pnt6D(pnt6D);
			item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Plunge, 0, plungemove: true);
			camPoint.Points.Add(item2);
			geoLine item3 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorPlunge, entThickness);
			camPoint.EntitiesPlunge.Add(item3);
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
			if (camPars.Hole.HoleType == grindingHoleType.OneTimeToDown)
			{
				pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight), new OrientationAngle());
				new Pnt6D(pnt6D);
				item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Plunge, 1, plungemove: false);
				camPoint.Points.Add(item2);
				item3 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorG1, entThickness);
				camPoint.EntitiesG1.Add(item3);
				pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
				geoCircle geoCircle2 = new geoCircle(new Pnt3D(pnt6D), Tool.Geometry.Diameter / 2.0);
				geoCircle2.Color = colorMark;
				camPoint.EntitiesMark.Add(geoCircle2);
			}
			double num3 = 0.0;
			if (camPars.Hole.HoleType == grindingHoleType.UpDownByStep)
			{
				for (double num4 = camPars.Hole.StartHeight - Math.Abs(camPars.Hole.DownStep); num4 >= camPars.Hole.EndHeight; num4 -= Math.Abs(camPars.Hole.DownStep))
				{
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, num4), new OrientationAngle());
					new Pnt6D(pnt6D);
					item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Plunge, 1, plungemove: false);
					camPoint.Points.Add(item2);
					item3 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorPlunge, entThickness);
					camPoint.EntitiesPlunge.Add(item3);
					pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
					geoCircle geoCircle3 = new geoCircle(new Pnt3D(pnt6D), Tool.Geometry.Diameter / 2.0);
					geoCircle3.Color = colorMark;
					camPoint.EntitiesMark.Add(geoCircle3);
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, num4 + camPars.Hole.UpStep), new OrientationAngle());
					new Pnt6D(pnt6D);
					item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 1, plungemove: false);
					camPoint.Points.Add(item2);
					pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
					num3 = num4;
				}
				if (num3 > camPars.Hole.EndHeight)
				{
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight), new OrientationAngle());
					new Pnt6D(pnt6D);
					item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Plunge, 1, plungemove: false);
					camPoint.Points.Add(item2);
					item3 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorPlunge, entThickness);
					camPoint.EntitiesPlunge.Add(item3);
					pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
					geoCircle geoCircle4 = new geoCircle(new Pnt3D(pnt6D), Tool.Geometry.Diameter / 2.0);
					geoCircle4.Color = colorMark;
					camPoint.EntitiesMark.Add(geoCircle4);
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Hole.EndHeight + camPars.Hole.UpStep), new OrientationAngle());
					new Pnt6D(pnt6D);
					item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 1, plungemove: false);
					camPoint.Points.Add(item2);
					pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
				}
			}
			pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, camPars.Distances.Safe), new OrientationAngle());
			new Pnt6D(pnt6D);
			item2 = new Pnt9DCam(pnt6D, camPars.Speeds.Leave, 0, plungemove: true);
			camPoint.Points.Add(item2);
			item3 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D), colorLeave, entThickness);
			camPoint.EntitiesLeave.Add(item3);
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, pnt6D.Z);
			if (camPoint.Points.Count > 0)
			{
				camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
			}
			for (int i = 1; i <= camPoint.Points.Count - 1; i++)
			{
				List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
				double dt = 0.1;
				if (camPoint.Points[i].Type == 0)
				{
					dt = 0.25;
				}
				double num5 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[i - 1]), new Pnt3D(camPoint.Points[i]));
				if (!(num5 > 3.0))
				{
					camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[i]));
					continue;
				}
				buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[i - 1]), new Pnt6D(camPoint.Points[i]), dt, ref CalculatedPoints);
				CalculatedPoints.RemoveAt(0);
				camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
			}
			calcCam.CamPoints.Add(camPoint);
			if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
			{
				calculationEventHandler_0(new CalculationEventArg(50.0, 100.0, 0, "Calculate Marble Code", ""));
			}
			if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
			{
				Application.DoEvents();
			}
			if (!buSystem.Cancel)
			{
				num2++;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				return;
			}
			buSystem.Cancel = false;
			buSystem.Canceled = true;
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
			if (calculationEventHandler_3 != null)
			{
				calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
			}
			buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void HatchCamCalculationGrinding(KinematicBase Kinematic, ToolBase Tool, camParameters camPars, SimulationBase simPars, ref camBase calcCam, ref List<eEntities> Entities)
	{
		if (camPars.Hatch.CutStep <= 0.0 || camPars.Hatch.TotalWidth <= 0.0 || camPars.Hatch.CutLength <= 0.0 || camPars.Hatch.CutStep > camPars.Hatch.TotalWidth)
		{
			return;
		}
		List<List<eEntities>> list = new List<List<eEntities>>();
		Entities.Clear();
		int num = (int)buNumeric.RoundToLower(camPars.Hatch.TotalWidth / camPars.Hatch.CutStep);
		if (num == 0)
		{
			num = 1;
		}
		double num2 = camPars.Hatch.TotalWidth / (double)num;
		if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			double num3 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			List<eEntities> list2 = new List<eEntities>();
			for (int i = 0; i <= num - 1; i++)
			{
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					list2 = new List<eEntities>();
					num3 = (double)i * num2;
					eEntities item = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
					Entities.Add(item);
					list2.Add(item);
					list.Add(list2);
				}
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list2 = new List<eEntities>();
					num3 = (double)i * num2;
					eEntities item2 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					item2 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					list.Add(list2);
				}
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num3 = (double)i * num2;
					eEntities eEntities2 = null;
					if (Entities.Count > 0)
					{
						eEntities2 = new eLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D.X, num3, camPars.Hatch.OperationZ));
						Entities.Add(eEntities2);
						list2.Add(eEntities2);
					}
					if (i % 2 == 0)
					{
						eEntities2 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
					}
					if (i % 2 == 1)
					{
						eEntities2 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + camPars.Hatch.CutLength, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X, camPars.Hatch.CornerPoint.Y + num3, camPars.Hatch.OperationZ));
					}
					Entities.Add(eEntities2);
					list2.Add(eEntities2);
					pnt3D = new Pnt3D(eEntities2.Vertice[eEntities2.Vertice.Count - 1]);
				}
			}
			if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				list.Add(list2);
			}
		}
		if (camPars.Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
		{
			double num4 = 0.0;
			Pnt3D pnt3D2 = new Pnt3D();
			List<eEntities> list3 = new List<eEntities>();
			for (int j = 0; j <= num - 1; j++)
			{
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					list3 = new List<eEntities>();
					num4 = (double)j * num2;
					eEntities item3 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
					Entities.Add(item3);
					list3.Add(item3);
					list.Add(list3);
				}
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list3 = new List<eEntities>();
					num4 = (double)j * num2;
					eEntities item4 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					item4 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					list.Add(list3);
				}
				if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num4 = (double)j * num2;
					eEntities eEntities3 = null;
					if (Entities.Count > 0)
					{
						eEntities3 = new eLine(new Pnt3D(pnt3D2), new Pnt3D(num4, pnt3D2.Y, camPars.Hatch.OperationZ));
						Entities.Add(eEntities3);
						list3.Add(eEntities3);
					}
					if (j % 2 == 0)
					{
						eEntities3 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ));
					}
					if (j % 2 == 1)
					{
						eEntities3 = new eLine(new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y + camPars.Hatch.CutLength, camPars.Hatch.OperationZ), new Pnt3D(camPars.Hatch.CornerPoint.X + num4, camPars.Hatch.CornerPoint.Y, camPars.Hatch.OperationZ));
					}
					Entities.Add(eEntities3);
					list3.Add(eEntities3);
					pnt3D2 = new Pnt3D(eEntities3.Vertice[eEntities3.Vertice.Count - 1]);
				}
			}
			if (camPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				list.Add(list3);
			}
		}
		CalculateGrindingContour(list, Kinematic, Tool, camPars, simPars, ref calcCam);
	}

	public void CalculateMarbleItem(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, marbleOperation OperationPars, marbleCamParameters CamPars, camSpeeds Speed, camDistances Distance, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			Pnt6D p = new Pnt6D();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Entities.Count / 100.0);
			int num2 = 0;
			double safe = Distance.Safe;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				eEntities copiedEnt = new eEntities();
				if (Entities[i].Count > 0)
				{
					eEntities copiedEnt2 = new eEntities();
					List<Pnt3D> TargetList = new List<Pnt3D>();
					eEntities.CopyEntity(Entities[i][0], ref copiedEnt2);
					buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
					if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
					{
						TargetList.Reverse();
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					double safe2 = Distance.Safe;
					double feed = Speed.Feed;
					Pnt3D pnt3D2 = new Pnt3D();
					Pnt3D pnt3D3 = new Pnt3D(TargetList[0]);
					Pnt3D pnt3D4 = new Pnt3D(TargetList[TargetList.Count - 1]);
					Pnt3D pnt3D5 = new Pnt3D();
					OrientationAngle orientationAngle = new OrientationAngle(copiedEnt2.Orientation);
					OrientationAngle orientationAngle2 = new OrientationAngle();
					new OrientationAngle();
					feed = Speed.Feed;
					safe2 = (safe - pnt3D3.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					Pnt6D CalcPoint = new Pnt6D();
					double num3 = Tool.Geometry.Diameter / 2.0;
					calcCam.Tool.Geometry.Length = num3;
					pnt3D2 = new Pnt3D();
					pnt3D5 = new Pnt3D(pnt3D3.X, pnt3D3.Y, 0.0);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D3, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), safe2, ref pnt3D2);
					buAppCalc.cKinematic.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(CalcPoint, Speed.Rapid, 0));
					if (i == 0)
					{
						p = new Pnt6D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z, 0.0, 0.0, orientationAngle.C);
					}
					pnt3D = new Pnt3D(pnt3D2);
					pnt3D5 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), Distance.Safe, ref pnt3D2);
					buAppCalc.cKinematic.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(CalcPoint, Speed.Plunge, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D5), Color.Lime));
					pnt3D = new Pnt3D(pnt3D2);
					for (int j = 0; j <= Entities[i].Count - 1; j++)
					{
						feed = Speed.Feed;
						if (Entities[i][j].auxText != null && Entities[i][j].auxText == "Backward")
						{
							feed = Speed.BackwardFeed;
						}
						copiedEnt2 = new eEntities();
						TargetList = new List<Pnt3D>();
						eEntities.CopyEntity(Entities[i][j], ref copiedEnt2);
						buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
						if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
						{
							TargetList.Reverse();
						}
						pnt3D2 = new Pnt3D();
						pnt3D3 = new Pnt3D(TargetList[0]);
						pnt3D4 = new Pnt3D(TargetList[TargetList.Count - 1]);
						pnt3D5 = new Pnt3D();
						orientationAngle = new OrientationAngle(copiedEnt2.Orientation);
						CalcPoint = new Pnt6D();
						pnt3D5 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
						buAppCalc.cKinematic.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D5), ref CalcPoint);
						CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camPoint.Points.Add(new Pnt9DCam(CalcPoint, Speed.Plunge, 1));
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Lime));
						CalcPoint = new Pnt6D();
						pnt3D5 = new Pnt3D(pnt3D4.X, pnt3D4.Y, pnt3D4.Z);
						buAppCalc.cKinematic.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D5), ref CalcPoint);
						CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camPoint.Points.Add(new Pnt9DCam(CalcPoint, feed, 1));
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D4), Color.Blue));
						pnt3D = new Pnt3D(pnt3D4);
					}
					safe2 = (Distance.Safe - pnt3D4.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					_ = (OperationPars.MaterialThickness + Distance.StepUp - pnt3D4.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					if (orientationAngle.A == orientationAngle2.A)
					{
					}
					if (i != Entities.Count - 1)
					{
					}
					CalcPoint = new Pnt6D();
					pnt3D5 = new Pnt3D(pnt3D4.X, pnt3D4.Y, pnt3D4.Z);
					pnt3D2 = new Pnt3D();
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), safe2, ref pnt3D2);
					buAppCalc.cKinematic.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(CalcPoint, Speed.Leave, 1));
					camPoint.EntitiesG0.Add(new geoLine(new Pnt3D(pnt3D4), new Pnt3D(pnt3D2)));
					for (int k = 1; k <= camPoint.Points.Count - 1; k++)
					{
						List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
						double dt = 0.1;
						if (camPoint.Points[k].Type == 0)
						{
							dt = 0.25;
						}
						buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[k - 1]), new Pnt6D(camPoint.Points[k]), dt, ref CalculatedPoints);
						camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
					}
					pnt3D = new Pnt3D(pnt3D4);
					eEntities.CopyEntity(copiedEnt2, ref copiedEnt);
					calcCam.CamPoints.Add(camPoint);
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num2++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble Code", ""));
				}
				buLog.addLog("Calculate Marble Code", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			camPoint = new CamPoint();
			camPoint.Type = 0;
			camPoint.IsRapid = true;
			camPoint.Points.Add(new Pnt9DCam(p, Speed.Rapid, 0));
			calcCam.CamPoints.Add(camPoint);
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateMarbleWireFrameWithSaw(List<List<eEntities>> Entities, List<List<eEntities>> ReCalculatedEntities, KinematicBase Kinematic, ToolBase Tool, marbleOperation Operation, marbleCamParameters CamMarblePars, camParameters camPar, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
			if (!(Operation.ApplySurfaceReadData & (Operation.SurfaceReadDevideLength > 0.0) & (pntTeachGrids.Count > 0)))
			{
				eEntities.CopyEntities(Entities, ref CopiedEnt);
			}
			else
			{
				for (int i = 0; i <= Entities.Count - 1; i++)
				{
					List<eEntities> list = new List<eEntities>();
					List<Pnt3D> Points = new List<Pnt3D>();
					EntitiesResolution entitiesResolution = new EntitiesResolution();
					entitiesResolution.ArcResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CircleResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CurveResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.EllipseResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.LineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.OtherResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.PolylineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					buAppCalc.cVector.EntitiesToPoint(Entities[i], entitiesResolution, ref Points);
					Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
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
						Points[j] = new Pnt3D(Points[j].X, Points[j].Y, Points[j].Z + num);
					}
					ePolyline ePolyline2 = new ePolyline(Points);
					ePolyline2.Orientation = new OrientationAngle(Entities[i][0].Orientation);
					list.Add(ePolyline2);
					CopiedEnt.Add(list);
				}
			}
			bool flag = camPar.Strategy.UseTangentLimit;
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			double num4 = camPar.Strategy.AngleLimit;
			List<Triangle3D> Triangles = new List<Triangle3D>();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			calcCam.Kinematic = new KinematicBase(Kinematic);
			KinematicItem kinematicItem = new KinematicItem();
			kinematicItem.Axis.A = true;
			kinematicItem.Axis.C = true;
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0 - Kinematic.RotateCenterOffsetOfC.Y, 0.0 - Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
			new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			calcCam.Kinematic.Items.Add(kinematicItem);
			calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
			calcCam.Kinematic.MovePartRuntimeOffset.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
			calcCam.Kinematic.MovePartRuntimeOffset.Z = 0.0 - Kinematic.RotateCenterOffsetOfC.Z;
			CamPoint camPoint = new CamPoint();
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			if (Operation.UseSweepOperation && !Operation.SweepZUpSharpCorner)
			{
				flag = false;
			}
			int CalcEventCount = 1;
			int num5 = 0;
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			double num6 = camPar.Distances.Safe;
			OrientationAngle orientationAngle = new OrientationAngle();
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			if (ReCalculatedEntities.Count > 0)
			{
				eEntities.CopyEntities(ReCalculatedEntities, ref CopiedEnt);
			}
			if (CopiedEnt.Count <= 10)
			{
				CalcEventCount = 1;
			}
			buGeneral.DoEventCountCalc(CopiedEnt.Count, ref CalcEventCount);
			for (int k = 0; k <= CopiedEnt.Count - 1; k++)
			{
				List<Pnt6D> list3 = new List<Pnt6D>();
				list2 = new List<List<Pnt6D>>();
				if (CopiedEnt[k].Count >= 1)
				{
					List<Pnt6D> Points2 = new List<Pnt6D>();
					new List<Pnt6D>();
					buAppCalc.cVector.EntitiesToPoint(CopiedEnt[k], Resolution, ref Points2);
					buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points2, 0.01);
					if (Points2.Count > 1)
					{
						double num7 = 0.0;
						double num8 = 0.0;
						double value = 0.0;
						double num9 = 0.0;
						double num10 = 0.0;
						double num11 = 0.0;
						double num12 = 0.0;
						num9 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[1]), new Pnt3D(Points2[0]));
						if (CamMarblePars.UseCZero)
						{
							num9 = 0.0;
						}
						if ((CopiedEnt[k].Count == 1) & (Points2[0].C != 0.0))
						{
							num9 = Points2[0].C;
						}
						if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
						{
							num9 = 0.0;
						}
						num7 = num9;
						list3.Add(new Pnt6D(Points2[0].X, Points2[0].Y, Points2[0].Z, Points2[0].A, 0.0, num9));
						for (int l = 1; l <= Points2.Count - 2; l++)
						{
							bool flag2 = false;
							num9 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l]), new Pnt3D(Points2[l - 1]));
							if (CamMarblePars.UseCZero)
							{
								num9 = 0.0;
							}
							if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
							{
								num9 = 0.0;
							}
							if (l != 90)
							{
							}
							if (!flag)
							{
								num4 = camPar.Strategy.AngleLimit;
								num11 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane());
								num12 = 180.0 - num11;
								if (num12 >= 360.0 - num4)
								{
									num12 = 360.0 - num11;
								}
								num10 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l + 1]), new Pnt3D(Points2[l]));
								if (CamMarblePars.UseCZero)
								{
									num10 = 0.0;
								}
								if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
								{
									num10 = 0.0;
								}
								if (num12 > num4)
								{
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num9));
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l + 1].A, 0.0, num10));
									flag2 = true;
								}
								Math.Abs(num9 - num7);
								if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
								{
									list2.Add(list3);
									list3 = new List<Pnt6D>();
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num10));
									flag2 = true;
								}
							}
							else
							{
								value = Points2[l - 1].A - Points2[l].A;
								num8 = Math.Abs(num9 - list3[list3.Count - 1].C);
								if (num8 > 185.0)
								{
									num9 = ((list3[list3.Count - 1].C > num9) ? (num9 + 360.0) : (num9 - 360.0));
								}
								num10 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l + 1]), new Pnt3D(Points2[l]));
								if (CamMarblePars.UseCZero)
								{
									num10 = 0.0;
								}
								if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
								{
									num10 = 0.0;
								}
								num4 = camPar.Strategy.AngleLimit;
								num11 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane());
								if (CopiedEnt[k][0].OperationPlane == planeType.YZ)
								{
									if (camPar.Strategy.UseLimitAngleForOtherPlane)
									{
										num4 = camPar.Strategy.AngleLimitYZ;
									}
									num11 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane(planeType.YZ, 1));
								}
								num12 = 180.0 - num11;
								if (num12 >= 360.0 - num4)
								{
									num12 = 360.0 - num11;
								}
								Math.Abs(num9 - num7);
								if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
								{
									list2.Add(list3);
									list3 = new List<Pnt6D>();
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num10));
									flag2 = true;
								}
							}
							if (!flag2)
							{
								if (!(num12 > num4 && flag))
								{
									double num13 = 0.0;
									if (flag)
									{
										num13 = Math.Abs(num9 - list3[list3.Count - 1].C);
										if (num13 >= 360.0 - num4)
										{
											num9 = ((num9 > list3[list3.Count - 1].C) ? (num9 - 360.0) : (num9 + 360.0));
											num13 = Math.Abs(num9 - list3[list3.Count - 1].C);
										}
										if (num13 > 185.0)
										{
											num9 += 360.0;
										}
									}
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num9));
									if (Math.Abs(num9 - num10) > 180.1)
									{
										double num14 = num9 - num10;
										if (!(num9 > num10))
										{
											num10 -= 360.0;
											num14 = num9 - num10;
											double num15 = buNumeric.RoundToLower(Math.Abs(num14) / 360.0);
											num10 -= num15 * 360.0;
										}
										else
										{
											num10 += 360.0;
											num14 = num9 - num10;
											double num16 = buNumeric.RoundToLower(Math.Abs(num14) / 360.0);
											num10 += num16 * 360.0;
										}
									}
									if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
									{
										if (num10 > camPar.Options.AxesLimit.MaxLimit.C)
										{
											list2.Add(list3);
											num9 -= 360.0;
											list3 = new List<Pnt6D>();
											list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num9));
										}
										if (num10 < camPar.Options.AxesLimit.MinLimit.C)
										{
											list2.Add(list3);
											num9 += 360.0;
											list3 = new List<Pnt6D>();
											list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num9));
										}
									}
								}
								else
								{
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num9));
									list2.Add(list3);
									list3 = new List<Pnt6D>();
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l + 1].A, 0.0, num10));
								}
							}
							num7 = num9;
						}
						if (list3.Count > 0)
						{
							num9 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[Points2.Count - 1]), new Pnt3D(Points2[Points2.Count - 2]));
							if (CamMarblePars.UseCZero)
							{
								num9 = 0.0;
							}
							if ((CopiedEnt[k].Count == 1) & (Points2[Points2.Count - 1].C != 0.0))
							{
								num9 = Points2[Points2.Count - 1].C;
							}
							double num17 = Math.Abs(num9 - list3[list3.Count - 1].C);
							if (num17 >= 360.0 - num4)
							{
								num17 = 360.0 - num9;
								if (num9 > list3[list3.Count - 1].C)
								{
									num9 -= 360.0;
								}
							}
							if (num17 > 185.0)
							{
								num9 += 360.0;
							}
							list3.Add(new Pnt6D(Points2[Points2.Count - 1].X, Points2[Points2.Count - 1].Y, Points2[Points2.Count - 1].Z, Points2[Points2.Count - 1].A, 0.0, num9));
							list2.Add(list3);
						}
					}
				}
				if (Operation.SawRampEnable & (Operation.SawRampType != CamZRampType.None))
				{
					for (int m = 0; m <= list2.Count - 1; m++)
					{
						List<double> list4 = new List<double>();
						List<Pnt6D> CopiedPnt = new List<Pnt6D>();
						List<Pnt6D> calcStartPoints = new List<Pnt6D>();
						List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
						List<Pnt6D> calcEndPoints = new List<Pnt6D>();
						Pnt6D.Copy(list2[m], ref CopiedPnt);
						buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, DevideMiddlePoints: true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
						if (Operation.SawRampType == CamZRampType.Linear)
						{
							list4 = new List<double>();
							buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, Operation.TargetZ, calcStartPoints.Count, ref list4);
							for (int n = 0; n <= list4.Count - 1; n++)
							{
								calcStartPoints[n] = new Pnt6D(calcStartPoints[n].X, calcStartPoints[n].Y, list4[n], calcStartPoints[n].A, calcStartPoints[n].B, calcStartPoints[n].C);
							}
							list4 = new List<double>();
							buNumeric.DevideMinMaxValueByNumber(Operation.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref list4);
							for (int num18 = 0; num18 <= list4.Count - 1; num18++)
							{
								calcEndPoints[num18] = new Pnt6D(calcEndPoints[num18].X, calcEndPoints[num18].Y, list4[num18], calcEndPoints[num18].A, calcEndPoints[num18].B, calcEndPoints[num18].C);
							}
						}
						if (Operation.SawRampType == CamZRampType.Circular)
						{
							List<Pnt3D> Points3 = new List<Pnt3D>();
							list4 = new List<double>();
							buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, Operation.TargetZ, 1.0, 200, ref list4, ref Points3);
							double num19 = 0.0;
							calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, list4[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
							for (int num20 = 1; num20 <= calcStartPoints.Count - 1; num20++)
							{
								double num21 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[num20 - 1]), new Pnt3D(calcStartPoints[num20]), new WorkPlane());
								num19 += num21;
								double num22 = 0.0;
								double num23 = 0.0;
								for (int num24 = 1; num24 <= Points3.Count - 1; num24++)
								{
									double num25 = buAppCalc.cVector.Length3D(new Pnt3D(Points3[num24 - 1].X, Points3[num24 - 1].Y), new Pnt3D(Points3[num24].X, Points3[num24].Y));
									num22 += num25;
									if (num23 <= num19 && num19 <= num22)
									{
										calcStartPoints[num20] = new Pnt6D(calcStartPoints[num20].X, calcStartPoints[num20].Y, list4[num24], calcStartPoints[num20].A, calcStartPoints[num20].B, calcStartPoints[num20].C);
										num24 = 100000;
									}
									num23 = num22;
								}
							}
							calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, list4[list4.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
							list4 = new List<double>();
							buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.TargetZ, Operation.SawRampHeight, 1.0, 200, ref list4, ref Points3);
							num19 = 0.0;
							calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, list4[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
							for (int num26 = 1; num26 <= calcEndPoints.Count - 1; num26++)
							{
								double num27 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[num26 - 1]), new Pnt3D(calcEndPoints[num26]), new WorkPlane());
								num19 += num27;
								double num28 = 0.0;
								double num29 = 0.0;
								for (int num30 = 1; num30 <= Points3.Count - 1; num30++)
								{
									double num31 = buAppCalc.cVector.Length3D(new Pnt3D(Points3[num30 - 1].X, Points3[num30 - 1].Y), new Pnt3D(Points3[num30].X, Points3[num30].Y));
									num28 += num31;
									if (num29 <= num19 && num19 <= num28)
									{
										calcEndPoints[num26] = new Pnt6D(calcEndPoints[num26].X, calcEndPoints[num26].Y, list4[num30], calcEndPoints[num26].A, calcEndPoints[num26].B, calcEndPoints[num26].C);
										num30 = 100000;
									}
									num29 = num28;
								}
							}
							calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, list4[list4.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
						}
						List<Pnt6D> Points4 = new List<Pnt6D>();
						Points4.AddRange(calcStartPoints);
						Points4.AddRange(calcMiddlePoints);
						Points4.AddRange(calcEndPoints);
						buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points4);
						list2[m] = new List<Pnt6D>();
						list2[m] = Points4;
					}
				}
				for (int num32 = 0; num32 <= list2.Count - 1; num32++)
				{
					bool flag3 = false;
					double toolLength = Tool.Geometry.Diameter / 2.0;
					double feed = camPar.Speeds.Feed;
					double safe = camPar.Distances.Safe;
					double stepUp = camPar.Distances.StepUp;
					Pnt6D pnt6D2 = new Pnt6D();
					new Pnt6D();
					Pnt6D pnt6D3 = new Pnt6D();
					Pnt3D pnt3D2 = new Pnt3D();
					Pnt3D pnt3D3 = new Pnt3D();
					Pnt3D pnt3D4 = new Pnt3D();
					OrientationAngle orientationAngle2 = new OrientationAngle();
					OrientationAngle orientationAngle3 = new OrientationAngle();
					if (k <= CopiedEnt.Count - 2)
					{
						orientationAngle3 = new OrientationAngle(CopiedEnt[k + 1][0].Orientation);
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					pnt6D3 = new Pnt6D();
					pnt6D2 = new Pnt6D(list2[num32][0]);
					pnt3D2 = new Pnt3D(pnt6D2);
					pnt3D3 = new Pnt3D();
					pnt3D4 = new Pnt3D();
					orientationAngle2 = new OrientationAngle(pnt6D2);
					if (Operation.UseSweepOperation)
					{
						if (!Operation.SweepFollowTangent)
						{
							orientationAngle2.C = Operation.SweepConstantAngle;
						}
						else
						{
							orientationAngle2.C += Operation.SweepOffsetAngleForTangent;
						}
					}
					feed = camPar.Speeds.Feed;
					safe = (num6 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					pnt6D3 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					if (orientationAngle2.A != orientationAngle.A && pnt6D.Z > pnt6D3.Z)
					{
						pnt6D3.Z = pnt6D.Z;
					}
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPar.Speeds.Rapid, 0, plungemove: true));
					pnt3D = new Pnt3D(pnt3D3);
					new Pnt6D(pnt6D3);
					pnt6D3 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPar.Speeds.Rapid, 0));
					pnt3D = new Pnt3D(pnt3D3);
					new Pnt6D(pnt6D3);
					if (num32 == 0)
					{
						new Pnt6D(pnt6D3);
					}
					pnt6D3 = new Pnt6D();
					pnt3D4 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPar.Speeds.Plunge, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D4), Color.Lime));
					camPoint.EntitiesG1[camPoint.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
					pnt3D = new Pnt3D(pnt3D2);
					new Pnt6D(pnt6D3);
					List<Pnt3D> list5 = new List<Pnt3D>();
					list5.Add(new Pnt3D(pnt3D));
					for (int num33 = 1; num33 <= list2[num32].Count - 1; num33++)
					{
						pnt6D2 = new Pnt6D(list2[num32][num33]);
						if (num33 == 1)
						{
							pnt6D2.X += 0.02;
							pnt6D2.Y += 0.02;
						}
						orientationAngle2 = new OrientationAngle(pnt6D2);
						pnt6D3 = new Pnt6D();
						pnt3D4 = new Pnt3D(pnt6D2);
						if (Operation.UseSweepOperation)
						{
							if (!Operation.SweepFollowTangent)
							{
								orientationAngle2.C = Operation.SweepConstantAngle;
							}
							else
							{
								orientationAngle2.C += Operation.SweepOffsetAngleForTangent;
							}
						}
						buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camPoint.Points.Add(new Pnt9DCam(pnt6D3, feed, 1));
						list5.Add(new Pnt3D(pnt3D4));
						pnt3D = new Pnt3D(pnt6D2);
						new Pnt6D(pnt6D3);
						orientationAngle = new OrientationAngle(orientationAngle2);
						if (num33 == 1)
						{
							camPoint.Points[camPoint.Points.Count - 1].PreCodes.Add("G38 O1");
						}
					}
					camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G39 O1");
					if (list5.Count > 0)
					{
						camPoint.EntitiesG1.Add(new geoPolyline(list5, Color.Blue));
						camPoint.EntitiesG1[camPoint.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
					}
					if (Operation.SawDistanceWithDepth > 0.0 && list5.Count > 1)
					{
						Pnt3D EndPnt = new Pnt3D();
						double num34 = buAppCalc.cVector.PointAngle(list5[1], list5[0]);
						buAppCalc.cVector.LineWithLengthAndAngle(list5[0], Operation.SawDistanceWithDepth, num34 + 180.0, new WorkPlane(), ref EndPnt);
						geoLine item = new geoLine(list5[0], EndPnt);
						camPoint.EntitiesMark.Add(item);
						camPoint.EntitiesMark[camPoint.EntitiesMark.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
						EndPnt = new Pnt3D();
						num34 = buAppCalc.cVector.PointAngle(list5[list5.Count - 1], list5[list5.Count - 2]);
						buAppCalc.cVector.LineWithLengthAndAngle(list5[list5.Count - 1], Operation.SawDistanceWithDepth, num34, new WorkPlane(), ref EndPnt);
						item = new geoLine(list5[list5.Count - 1], EndPnt);
						camPoint.EntitiesMark.Add(item);
						camPoint.EntitiesMark[camPoint.EntitiesMark.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
					}
					safe = (camPar.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					stepUp = (Operation.MaterialThickness + camPar.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					flag3 = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
					if (num32 == list2.Count - 1)
					{
						flag3 = true;
					}
					pnt6D3 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + stepUp);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), stepUp, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPar.Speeds.Leave, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Red));
					camPoint.EntitiesG1[camPoint.EntitiesG1.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
					num6 = Operation.MaterialThickness + camPar.Distances.StepUp;
					orientationAngle = new OrientationAngle(orientationAngle2);
					if (flag3)
					{
						pnt6D3 = new Pnt6D();
						pnt3D3 = new Pnt3D();
						pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
						buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
						buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camPoint.Points.Add(new Pnt9DCam(pnt6D3, camPar.Speeds.Rapid, 0));
						camPoint.EntitiesG0.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Gold));
						camPoint.EntitiesG0[camPoint.EntitiesG0.Count - 1].BaseEntityIndex = CopiedEnt[k][0].EntityIndex;
						num6 = camPar.Distances.Safe;
					}
					pnt6D = new Pnt6D(pnt6D3);
					if (num32 != list2.Count - 1)
					{
					}
					if (camPoint.Points.Count > 0)
					{
						Pnt6D pnt = new Pnt6D(camPoint.Points[0]);
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(pnt));
					}
					for (int num35 = 1; num35 <= camPoint.Points.Count - 1; num35++)
					{
						List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
						double dt = 0.1;
						Pnt6D pnt6D4 = new Pnt6D(camPoint.Points[num35 - 1].P9);
						Pnt6D pnt6D5 = new Pnt6D(camPoint.Points[num35].P9);
						if (camPoint.Points[num35].Type == 0)
						{
							dt = 0.25;
						}
						double num36 = buAppCalc.cVector.Length3D(pnt6D4, pnt6D5);
						if (!(num36 > 3.0))
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(pnt6D5));
							continue;
						}
						buAppCalc.cVector.LineerInterpolation(new Pnt6D(pnt6D4), new Pnt6D(pnt6D5), dt, ref CalculatedPoints);
						CalculatedPoints.RemoveAt(0);
						camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
					}
					calcCam.CamPoints.Add(camPoint);
				}
				Pnt6D.Add(list2, ref calcCam.CalculatedPnt6D);
				for (int num37 = 0; num37 <= CopiedEnt[k].Count - 1; num37++)
				{
					calcCam.BaseEntitiesIndex.Add(CopiedEnt[k][num37].EntityIndex);
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null && CalcEventCount > 0 && num5 > 0 && num5 % CalcEventCount == 0)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)k / (double)(CopiedEnt.Count - 1)) * 100.0, Convert.ToDouble((double)k / (double)(CopiedEnt.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && CalcEventCount > 0 && num5 > 0 && num5 % CalcEventCount == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num5++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			eEntities.CopyEntities(CopiedEnt, ref calcCam.CalculatedEntities);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateMarbleWireFrameWithSaw2(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, marbleOperation Operation, marbleCamParameters CamMarblePars, camParameters camPar, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			List<List<eEntities>> CopiedEnt = new List<List<eEntities>>();
			if (!(Operation.ApplySurfaceReadData & (Operation.SurfaceReadDevideLength > 0.0)))
			{
				eEntities.CopyEntities(Entities, ref CopiedEnt);
			}
			else
			{
				for (int i = 0; i <= Entities.Count - 1; i++)
				{
					List<eEntities> list = new List<eEntities>();
					List<Pnt3D> Points = new List<Pnt3D>();
					EntitiesResolution entitiesResolution = new EntitiesResolution();
					entitiesResolution.ArcResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CircleResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CurveResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.EllipseResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.LineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.OtherResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.PolylineResolution = new EntityResolution(Operation.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					buAppCalc.cVector.EntitiesToPoint(Entities[i], entitiesResolution, ref Points);
					Points[Points.Count - 1] = new Pnt3D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, 5.0);
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
						Points[j] = new Pnt3D(Points[j].X, Points[j].Y, Points[j].Z + num);
					}
					ePolyline ePolyline2 = new ePolyline(Points);
					ePolyline2.Orientation = new OrientationAngle(Entities[i][0].Orientation);
					list.Add(ePolyline2);
					CopiedEnt.Add(list);
				}
			}
			bool flag = camPar.Strategy.UseTangentLimit;
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			double num4 = camPar.Strategy.AngleLimit;
			List<Triangle3D> Triangles = new List<Triangle3D>();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			calcCam.Kinematic = new KinematicBase(Kinematic);
			KinematicItem kinematicItem = new KinematicItem();
			kinematicItem.Axis.A = true;
			kinematicItem.Axis.C = true;
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0 - Kinematic.RotateCenterOffsetOfC.Y, 0.0 - Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
			new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			calcCam.Kinematic.Items.Add(kinematicItem);
			calcCam.Kinematic.MovePartRuntimeOffset.X = 0.0;
			calcCam.Kinematic.MovePartRuntimeOffset.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
			calcCam.Kinematic.MovePartRuntimeOffset.Z = 0.0 - Kinematic.RotateCenterOffsetOfC.Z;
			CamPoint camPoint = new CamPoint();
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			if (Operation.UseSweepOperation && !Operation.SweepZUpSharpCorner)
			{
				flag = false;
			}
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			for (int k = 0; k <= CopiedEnt.Count - 1; k++)
			{
				List<Pnt6D> list3 = new List<Pnt6D>();
				if (CopiedEnt[k].Count < 1)
				{
					continue;
				}
				List<Pnt6D> Points2 = new List<Pnt6D>();
				new List<Pnt6D>();
				buAppCalc.cVector.EntitiesToPoint(CopiedEnt[k], Resolution, ref Points2);
				buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points2, 0.01);
				if (Points2.Count <= 1)
				{
					continue;
				}
				double num5 = 0.0;
				double num6 = 0.0;
				double value = 0.0;
				double num7 = 0.0;
				double num8 = 0.0;
				double num9 = 0.0;
				double num10 = 0.0;
				num7 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[1]), new Pnt3D(Points2[0]));
				if (CamMarblePars.UseCZero)
				{
					num7 = 0.0;
				}
				if ((CopiedEnt[k].Count == 1) & (Points2[0].C != 0.0))
				{
					num7 = Points2[0].C;
				}
				if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
				{
					num7 = 0.0;
				}
				num5 = num7;
				list3.Add(new Pnt6D(Points2[0].X, Points2[0].Y, Points2[0].Z, Points2[0].A, 0.0, num7));
				for (int l = 1; l <= Points2.Count - 2; l++)
				{
					bool flag2 = false;
					num7 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l]), new Pnt3D(Points2[l - 1]));
					if (CamMarblePars.UseCZero)
					{
						num7 = 0.0;
					}
					if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
					{
						num7 = 0.0;
					}
					if (l != 90)
					{
					}
					if (!flag)
					{
						num4 = camPar.Strategy.AngleLimit;
						num9 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane());
						num10 = 180.0 - num9;
						if (num10 >= 360.0 - num4)
						{
							num10 = 360.0 - num9;
						}
						num8 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l + 1]), new Pnt3D(Points2[l]));
						if (CamMarblePars.UseCZero)
						{
							num8 = 0.0;
						}
						if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
						{
							num8 = 0.0;
						}
						if (num10 > num4)
						{
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l + 1].A, 0.0, num8));
							flag2 = true;
						}
						Math.Abs(num7 - num5);
						if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
						{
							list2.Add(list3);
							list3 = new List<Pnt6D>();
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num8));
							flag2 = true;
						}
					}
					else
					{
						value = Points2[l - 1].A - Points2[l].A;
						num6 = Math.Abs(num7 - list3[list3.Count - 1].C);
						if (num6 > 185.0)
						{
							num7 = ((list3[list3.Count - 1].C > num7) ? (num7 + 360.0) : (num7 - 360.0));
						}
						num8 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[l + 1]), new Pnt3D(Points2[l]));
						if (CamMarblePars.UseCZero)
						{
							num8 = 0.0;
						}
						if (Operation.ProfileCutFinishEnable & (Operation.ProfileCutFinishVector == VectorXYType.XVector))
						{
							num8 = 0.0;
						}
						num4 = camPar.Strategy.AngleLimit;
						num9 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane());
						if (CopiedEnt[k][0].OperationPlane == planeType.YZ)
						{
							if (camPar.Strategy.UseLimitAngleForOtherPlane)
							{
								num4 = camPar.Strategy.AngleLimitYZ;
							}
							num9 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l]), new Pnt3D(Points2[l + 1]), new WorkPlane(planeType.YZ, 1));
						}
						num10 = 180.0 - num9;
						if (num10 >= 360.0 - num4)
						{
							num10 = 360.0 - num9;
						}
						Math.Abs(num7 - num5);
						if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
						{
							list2.Add(list3);
							list3 = new List<Pnt6D>();
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num8));
							flag2 = true;
						}
					}
					if (!flag2)
					{
						if (!(num10 > num4 && flag))
						{
							double num11 = 0.0;
							if (flag)
							{
								num11 = Math.Abs(num7 - list3[list3.Count - 1].C);
								if (num11 >= 360.0 - num4)
								{
									num7 = ((num7 > list3[list3.Count - 1].C) ? (num7 - 360.0) : (num7 + 360.0));
									num11 = Math.Abs(num7 - list3[list3.Count - 1].C);
								}
								if (num11 > 185.0)
								{
									num7 += 360.0;
								}
							}
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
							if (Math.Abs(num7 - num8) > 180.1)
							{
								double num12 = num7 - num8;
								if (!(num7 > num8))
								{
									num8 -= 360.0;
									num12 = num7 - num8;
									double num13 = buNumeric.RoundToLower(Math.Abs(num12) / 360.0);
									num8 -= num13 * 360.0;
								}
								else
								{
									num8 += 360.0;
									num12 = num7 - num8;
									double num14 = buNumeric.RoundToLower(Math.Abs(num12) / 360.0);
									num8 += num14 * 360.0;
								}
							}
							if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
							{
								if (num8 > camPar.Options.AxesLimit.MaxLimit.C)
								{
									list2.Add(list3);
									num7 -= 360.0;
									list3 = new List<Pnt6D>();
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
								}
								if (num8 < camPar.Options.AxesLimit.MinLimit.C)
								{
									list2.Add(list3);
									num7 += 360.0;
									list3 = new List<Pnt6D>();
									list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
								}
							}
						}
						else
						{
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
							list2.Add(list3);
							list3 = new List<Pnt6D>();
							list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l + 1].A, 0.0, num8));
						}
					}
					num5 = num7;
				}
				if (list3.Count <= 0)
				{
					continue;
				}
				num7 = buAppCalc.cVector.PointAngle(new Pnt3D(Points2[Points2.Count - 1]), new Pnt3D(Points2[Points2.Count - 2]));
				if (CamMarblePars.UseCZero)
				{
					num7 = 0.0;
				}
				if ((CopiedEnt[k].Count == 1) & (Points2[Points2.Count - 1].C != 0.0))
				{
					num7 = Points2[Points2.Count - 1].C;
				}
				double num15 = Math.Abs(num7 - list3[list3.Count - 1].C);
				if (num15 >= 360.0 - num4)
				{
					num15 = 360.0 - num7;
					if (num7 > list3[list3.Count - 1].C)
					{
						num7 -= 360.0;
					}
				}
				if (num15 > 185.0)
				{
					num7 += 360.0;
				}
				list3.Add(new Pnt6D(Points2[Points2.Count - 1].X, Points2[Points2.Count - 1].Y, Points2[Points2.Count - 1].Z, Points2[Points2.Count - 1].A, 0.0, num7));
				list2.Add(list3);
			}
			int num16 = Convert.ToInt32((double)list2.Count / 100.0);
			int num17 = 0;
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			double num18 = camPar.Distances.Safe;
			OrientationAngle orientationAngle = new OrientationAngle();
			if (Operation.SawRampEnable & (Operation.SawRampType != CamZRampType.None))
			{
				for (int m = 0; m <= list2.Count - 1; m++)
				{
					List<double> list4 = new List<double>();
					List<Pnt6D> CopiedPnt = new List<Pnt6D>();
					List<Pnt6D> calcStartPoints = new List<Pnt6D>();
					List<Pnt6D> calcMiddlePoints = new List<Pnt6D>();
					List<Pnt6D> calcEndPoints = new List<Pnt6D>();
					Pnt6D.Copy(list2[m], ref CopiedPnt);
					buAppCalc.cVector.DevidePointList(CopiedPnt, Operation.SawDevideLength, Operation.SawRampLenght, Operation.SawRampLenght, DevideMiddlePoints: true, DevideTipType.StartAndEnd, ref calcStartPoints, ref calcMiddlePoints, ref calcEndPoints);
					if (Operation.SawRampType == CamZRampType.Linear)
					{
						list4 = new List<double>();
						buNumeric.DevideMinMaxValueByNumber(Operation.SawRampHeight, Operation.TargetZ, calcStartPoints.Count, ref list4);
						for (int n = 0; n <= list4.Count - 1; n++)
						{
							calcStartPoints[n] = new Pnt6D(calcStartPoints[n].X, calcStartPoints[n].Y, list4[n], calcStartPoints[n].A, calcStartPoints[n].B, calcStartPoints[n].C);
						}
						list4 = new List<double>();
						buNumeric.DevideMinMaxValueByNumber(Operation.TargetZ, Operation.SawRampHeight, calcEndPoints.Count, ref list4);
						for (int num19 = 0; num19 <= list4.Count - 1; num19++)
						{
							calcEndPoints[num19] = new Pnt6D(calcEndPoints[num19].X, calcEndPoints[num19].Y, list4[num19], calcEndPoints[num19].A, calcEndPoints[num19].B, calcEndPoints[num19].C);
						}
					}
					if (Operation.SawRampType == CamZRampType.Circular)
					{
						List<Pnt3D> Points3 = new List<Pnt3D>();
						list4 = new List<double>();
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.SawRampHeight, Operation.TargetZ, 1.0, 200, ref list4, ref Points3);
						double num20 = 0.0;
						calcStartPoints[0] = new Pnt6D(calcStartPoints[0].X, calcStartPoints[0].Y, list4[0], calcStartPoints[0].A, calcStartPoints[0].B, calcStartPoints[0].C);
						for (int num21 = 1; num21 <= calcStartPoints.Count - 1; num21++)
						{
							double num22 = buAppCalc.cVector.Length3D(new Pnt3D(calcStartPoints[num21 - 1]), new Pnt3D(calcStartPoints[num21]), new WorkPlane());
							num20 += num22;
							double num23 = 0.0;
							double num24 = 0.0;
							for (int num25 = 1; num25 <= Points3.Count - 1; num25++)
							{
								double num26 = buAppCalc.cVector.Length3D(new Pnt3D(Points3[num25 - 1].X, Points3[num25 - 1].Y), new Pnt3D(Points3[num25].X, Points3[num25].Y));
								num23 += num26;
								if (num24 <= num20 && num20 <= num23)
								{
									calcStartPoints[num21] = new Pnt6D(calcStartPoints[num21].X, calcStartPoints[num21].Y, list4[num25], calcStartPoints[num21].A, calcStartPoints[num21].B, calcStartPoints[num21].C);
									num25 = 100000;
								}
								num24 = num23;
							}
						}
						calcStartPoints[calcStartPoints.Count - 1] = new Pnt6D(calcStartPoints[calcStartPoints.Count - 1].X, calcStartPoints[calcStartPoints.Count - 1].Y, list4[list4.Count - 1], calcStartPoints[calcStartPoints.Count - 1].A, calcStartPoints[calcStartPoints.Count - 1].B, calcStartPoints[calcStartPoints.Count - 1].C);
						list4 = new List<double>();
						buAppCalc.cVector.CircularZHeightRampByLengthAndHeight(Operation.SawRampLenght, Operation.TargetZ, Operation.SawRampHeight, 1.0, 200, ref list4, ref Points3);
						num20 = 0.0;
						calcEndPoints[0] = new Pnt6D(calcEndPoints[0].X, calcEndPoints[0].Y, list4[0], calcEndPoints[0].A, calcEndPoints[0].B, calcEndPoints[0].C);
						for (int num27 = 1; num27 <= calcEndPoints.Count - 1; num27++)
						{
							double num28 = buAppCalc.cVector.Length3D(new Pnt3D(calcEndPoints[num27 - 1]), new Pnt3D(calcEndPoints[num27]), new WorkPlane());
							num20 += num28;
							double num29 = 0.0;
							double num30 = 0.0;
							for (int num31 = 1; num31 <= Points3.Count - 1; num31++)
							{
								double num32 = buAppCalc.cVector.Length3D(new Pnt3D(Points3[num31 - 1].X, Points3[num31 - 1].Y), new Pnt3D(Points3[num31].X, Points3[num31].Y));
								num29 += num32;
								if (num30 <= num20 && num20 <= num29)
								{
									calcEndPoints[num27] = new Pnt6D(calcEndPoints[num27].X, calcEndPoints[num27].Y, list4[num31], calcEndPoints[num27].A, calcEndPoints[num27].B, calcEndPoints[num27].C);
									num31 = 100000;
								}
								num30 = num29;
							}
						}
						calcEndPoints[calcEndPoints.Count - 1] = new Pnt6D(calcEndPoints[calcEndPoints.Count - 1].X, calcEndPoints[calcEndPoints.Count - 1].Y, list4[list4.Count - 1], calcEndPoints[calcEndPoints.Count - 1].A, calcEndPoints[calcEndPoints.Count - 1].B, calcEndPoints[calcEndPoints.Count - 1].C);
					}
					List<Pnt6D> Points4 = new List<Pnt6D>();
					Points4.AddRange(calcStartPoints);
					Points4.AddRange(calcMiddlePoints);
					Points4.AddRange(calcEndPoints);
					buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points4);
					list2[m] = new List<Pnt6D>();
					list2[m] = Points4;
				}
			}
			for (int num33 = 0; num33 <= list2.Count - 1; num33++)
			{
				bool flag3 = false;
				double toolLength = Tool.Geometry.Diameter / 2.0;
				double feed = camPar.Speeds.Feed;
				double safe = camPar.Distances.Safe;
				double stepUp = camPar.Distances.StepUp;
				Pnt6D pnt6D2 = new Pnt6D();
				Pnt6D pnt6D3 = new Pnt6D();
				Pnt6D pnt6D4 = new Pnt6D();
				Pnt3D pnt3D2 = new Pnt3D();
				Pnt3D pnt3D3 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				OrientationAngle orientationAngle2 = new OrientationAngle();
				OrientationAngle orientationAngle3 = new OrientationAngle();
				if (num33 <= list2.Count - 2)
				{
					pnt6D3 = new Pnt6D(list2[num33 + 1][0]);
					orientationAngle3 = new OrientationAngle(pnt6D3);
				}
				camPoint = new CamPoint();
				camPoint.Type = 0;
				camPoint.IsRapid = true;
				pnt6D4 = new Pnt6D();
				pnt6D2 = new Pnt6D(list2[num33][0]);
				pnt3D2 = new Pnt3D(pnt6D2);
				pnt3D3 = new Pnt3D();
				pnt3D4 = new Pnt3D();
				orientationAngle2 = new OrientationAngle(pnt6D2);
				if (Operation.UseSweepOperation)
				{
					if (!Operation.SweepFollowTangent)
					{
						orientationAngle2.C = Operation.SweepConstantAngle;
					}
					else
					{
						orientationAngle2.C += Operation.SweepOffsetAngleForTangent;
					}
				}
				feed = camPar.Speeds.Feed;
				safe = (num18 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				if (orientationAngle2.A != orientationAngle.A && pnt6D.Z > pnt6D4.Z)
				{
					pnt6D4.Z = pnt6D.Z;
				}
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camPar.Speeds.Rapid, 0, plungemove: true));
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D4);
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camPar.Speeds.Rapid, 0));
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D4);
				if (num33 == 0)
				{
					new Pnt6D(pnt6D4);
				}
				pnt6D4 = new Pnt6D();
				pnt3D4 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camPar.Speeds.Plunge, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D4), Color.Lime));
				pnt3D = new Pnt3D(pnt3D2);
				new Pnt6D(pnt6D4);
				List<Pnt3D> list5 = new List<Pnt3D>();
				list5.Add(new Pnt3D(pnt3D));
				for (int num34 = 1; num34 <= list2[num33].Count - 1; num34++)
				{
					pnt6D2 = new Pnt6D(list2[num33][num34]);
					orientationAngle2 = new OrientationAngle(pnt6D2);
					pnt6D4 = new Pnt6D();
					pnt3D4 = new Pnt3D(pnt6D2);
					if (Operation.UseSweepOperation)
					{
						if (!Operation.SweepFollowTangent)
						{
							orientationAngle2.C = Operation.SweepConstantAngle;
						}
						else
						{
							orientationAngle2.C += Operation.SweepOffsetAngleForTangent;
						}
					}
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D4);
					pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D4, feed, 1));
					list5.Add(new Pnt3D(pnt3D4));
					pnt3D = new Pnt3D(pnt6D2);
					new Pnt6D(pnt6D4);
					orientationAngle = new OrientationAngle(orientationAngle2);
				}
				if (list5.Count > 0)
				{
					camPoint.EntitiesG1.Add(new geoPolyline(list5, Color.Blue));
				}
				if (Operation.SawDistanceWithDepth > 0.0 && list5.Count > 1)
				{
					Pnt3D EndPnt = new Pnt3D();
					double num35 = buAppCalc.cVector.PointAngle(list5[1], list5[0]);
					buAppCalc.cVector.LineWithLengthAndAngle(list5[0], Operation.SawDistanceWithDepth, num35 + 180.0, new WorkPlane(), ref EndPnt);
					geoLine item = new geoLine(list5[0], EndPnt);
					camPoint.EntitiesMark.Add(item);
					EndPnt = new Pnt3D();
					num35 = buAppCalc.cVector.PointAngle(list5[list5.Count - 1], list5[list5.Count - 2]);
					buAppCalc.cVector.LineWithLengthAndAngle(list5[list5.Count - 1], Operation.SawDistanceWithDepth, num35, new WorkPlane(), ref EndPnt);
					item = new geoLine(list5[list5.Count - 1], EndPnt);
					camPoint.EntitiesMark.Add(item);
				}
				safe = (camPar.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				stepUp = (Operation.MaterialThickness + camPar.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				flag3 = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
				if (num33 == list2.Count - 1)
				{
					flag3 = true;
				}
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + stepUp);
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), stepUp, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camPar.Speeds.Leave, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Red));
				num18 = Operation.MaterialThickness + camPar.Distances.StepUp;
				orientationAngle = new OrientationAngle(orientationAngle2);
				if (flag3)
				{
					pnt6D4 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
					pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D4, camPar.Speeds.Rapid, 0));
					camPoint.EntitiesG0.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Gold));
					num18 = camPar.Distances.Safe;
				}
				pnt6D = new Pnt6D(pnt6D4);
				if (num33 != list2.Count - 1)
				{
				}
				if (camPoint.Points.Count > 0)
				{
					camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
				}
				for (int num36 = 1; num36 <= camPoint.Points.Count - 1; num36++)
				{
					List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
					double dt = 0.1;
					if (camPoint.Points[num36].Type == 0)
					{
						dt = 0.25;
					}
					double num37 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num36 - 1]), new Pnt3D(camPoint.Points[num36]));
					if (!(num37 > 3.0))
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[num36]));
						continue;
					}
					buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[num36 - 1]), new Pnt6D(camPoint.Points[num36]), dt, ref CalculatedPoints);
					CalculatedPoints.RemoveAt(0);
					camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
				}
				calcCam.CamPoints.Add(camPoint);
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null && num16 > 0 && num17 > 0 && num17 % num16 == 0)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)num33 / (double)(list2.Count - 1)) * 100.0, Convert.ToDouble((double)num33 / (double)(list2.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num16 > 0 && num17 > 0 && num17 % num16 == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num17++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			if (calcCam.CamPoints.Count > 0)
			{
				for (int num38 = 0; num38 <= Entities.Count - 1; num38++)
				{
					for (int num39 = 0; num39 <= Entities[num38].Count - 1; num39++)
					{
						calcCam.BaseEntitiesIndex.Add(Entities[num38][num39].EntityIndex);
					}
				}
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateMarbleWireFrameWithMillingAndWaterJetTool3Ax(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, bool WaterJetMode, camParameters CamParameter, double AValue, double CValue, string WaterJetAirUpCmd, string WaterJetDownOperationCmd, string WaterJetOnCmd, string WaterJetOffCmd, string WaterJetNextOn, string WaterJetNextOff, string WaterJetApproach, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Entities.Count / 100.0);
			int num2 = 0;
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				eEntities copiedEnt = new eEntities();
				if (Entities[i].Count > 0)
				{
					eEntities copiedEnt2 = new eEntities();
					List<Pnt3D> TargetList = new List<Pnt3D>();
					eEntities.CopyEntity(Entities[i][0], ref copiedEnt2);
					buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
					List<Pnt6D> Points = new List<Pnt6D>();
					buAppCalc.cVector.EntitiesToPoint(Entities[i], Resolution, ref Points);
					if (CamParameter.Strategy.OverrideCEnable)
					{
						for (int j = 0; j <= Points.Count - 1; j++)
						{
							Pnt6D pnt6D = new Pnt6D(Points[j]);
							pnt6D.C = CamParameter.Strategy.OverrideC;
							Points[j] = pnt6D;
						}
						buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
					}
					if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
					{
						TargetList.Reverse();
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					if (Points.Count > 1)
					{
						Pnt3D pnt3D2 = new Pnt3D(Points[0]);
						OrientationAngle orientationAngle = new OrientationAngle(Points[0]);
						new OrientationAngle(Points[0]);
						Pnt6D pnt6D2 = new Pnt6D();
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
						if (!WaterJetMode)
						{
							Pnt9DCam pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Rapid, 0);
							pnt9DCam.PlungeAxisMovement = true;
							camPoint.Points.Add(pnt9DCam);
							camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Rapid, 0));
						}
						pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
						new Pnt6D(pnt6D2);
						pnt6D2 = new Pnt6D(pnt3D2, new OrientationAngle(AValue, 0.0, CValue));
						if (WaterJetMode)
						{
							Pnt9DCam pnt9DCam2 = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 0);
							if (i != 0)
							{
								pnt9DCam2.AfterCodes.Add(WaterJetNextOn);
							}
							else
							{
								pnt9DCam2.AfterCodes.Add(WaterJetApproach);
								pnt9DCam2.AfterCodes.Add(WaterJetDownOperationCmd);
								pnt9DCam2.AfterCodes.Add(WaterJetOnCmd);
							}
							camPoint.Points.Add(pnt9DCam2);
						}
						else
						{
							camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 1));
						}
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2), Color.Lime));
						pnt3D = new Pnt3D(pnt3D2);
						new Pnt6D(pnt6D2);
						List<Pnt3D> list = new List<Pnt3D>();
						list.Add(new Pnt3D(pnt3D));
						for (int k = 1; k <= Points.Count - 1; k++)
						{
							pnt3D2 = new Pnt3D(Points[k]);
							orientationAngle = new OrientationAngle(Points[k]);
							double feed = CamParameter.Speeds.Feed;
							pnt6D2 = new Pnt6D(new Pnt3D(Points[k].X, Points[k].Y, Points[k].Z), new OrientationAngle(AValue, 0.0, CValue));
							camPoint.Points.Add(new Pnt9DCam(pnt6D2, feed, 1));
							list.Add(new Pnt3D(pnt6D2));
							pnt3D = new Pnt3D(Points[k]);
							new Pnt6D(pnt6D2);
							new OrientationAngle(orientationAngle);
						}
						camPoint.EntitiesG1.Add(new geoPolyline(list, Color.Blue));
						if (WaterJetMode)
						{
							pnt6D2 = new Pnt6D(new Pnt3D(pnt3D.X, pnt3D.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
							Pnt9DCam pnt9DCam3 = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 1);
							if (i != Entities.Count - 1)
							{
								pnt9DCam3.AfterCodes.Add(WaterJetNextOff);
							}
							else
							{
								pnt9DCam3.AfterCodes.Add(WaterJetOffCmd);
								pnt9DCam3.AfterCodes.Add(WaterJetApproach);
								pnt9DCam3.AfterCodes.Add(WaterJetAirUpCmd);
							}
							camPoint.Points.Add(pnt9DCam3);
						}
						else
						{
							pnt6D2 = new Pnt6D(new Pnt3D(pnt3D.X, pnt3D.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
							camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Leave, 1));
						}
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D2), Color.Red));
						double num3 = 0.0;
						if (Tool.Purpose == ToolPurpose.Saw)
						{
							num3 = Tool.Geometry.Diameter / 2.0;
						}
						if (camPoint.Points.Count > 0)
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0].P9.X, camPoint.Points[0].P9.Y, camPoint.Points[0].P9.Z + num3, camPoint.Points[0].P9.A, camPoint.Points[0].P9.B, camPoint.Points[0].P9.C));
						}
						for (int l = 1; l <= camPoint.Points.Count - 1; l++)
						{
							List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
							double dt = 0.1;
							if (camPoint.Points[l].Type == 0)
							{
								dt = 0.25;
							}
							Pnt6D pnt6D3 = new Pnt6D(camPoint.Points[l - 1].P9.X, camPoint.Points[l - 1].P9.Y, camPoint.Points[l - 1].P9.Z + num3, camPoint.Points[l - 1].P9.A, camPoint.Points[l - 1].P9.B, camPoint.Points[l - 1].P9.C);
							Pnt6D pnt6D4 = new Pnt6D(camPoint.Points[l].P9.X, camPoint.Points[l].P9.Y, camPoint.Points[l].P9.Z + num3, camPoint.Points[l].P9.A, camPoint.Points[l].P9.B, camPoint.Points[l].P9.C);
							double num4 = buAppCalc.cVector.Length3D(new Pnt3D(pnt6D3), new Pnt3D(pnt6D4));
							if (!(num4 > 3.0))
							{
								camPoint.SimilationPoint.SimPoints.Add(pnt6D4);
								continue;
							}
							buAppCalc.cVector.LineerInterpolation(pnt6D3, pnt6D4, dt, ref CalculatedPoints);
							CalculatedPoints.RemoveAt(0);
							camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
						}
						eEntities.CopyEntity(copiedEnt2, ref copiedEnt);
						calcCam.CamPoints.Add(camPoint);
					}
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num2++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			eEntities.CopyEntities(Entities, ref calcCam.CalculatedEntities);
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateMarbleWireFrameWithMillingAndWaterJetTool5Ax(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, bool WaterJetMode, marbleCamParameters CamMarblePars, camParameters camPar, marbleOperation Operation, double AValue, double CValue, string WaterJetAirUpCmd, string WaterJetDownOperationCmd, string WaterJetOnCmd, string WaterJetOffCmd, string WaterJetNextOn, string WaterJetNextOff, string WaterJetApproach, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			List<List<Pnt6D>> ContinousPoints = new List<List<Pnt6D>>();
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			double num = 0.0;
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num2 = Convert.ToInt32((double)Entities.Count / 100.0);
			int num3 = 0;
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			CalcMarbleEntitiesToContinousPoint(Entities, Resolution, CamMarblePars, camPar, Operation, ref ContinousPoints);
			num2 = Convert.ToInt32((double)ContinousPoints.Count / 100.0);
			new Pnt6D();
			new Pnt6D();
			OrientationAngle orientationAngle = new OrientationAngle();
			if (!Operation.WaterJet5AxisConcaveCalculation)
			{
				for (int i = 0; i <= ContinousPoints.Count - 1; i++)
				{
					for (int j = 0; j <= ContinousPoints[i].Count - 1; j++)
					{
						if (i > 0)
						{
							double c = ContinousPoints[i][j].C;
							if (camPar.Operations.Direction == ClockDirectionType.CCW && c < num)
							{
								ContinousPoints[i][j] = new Pnt6D(ContinousPoints[i][j].X, ContinousPoints[i][j].Y, ContinousPoints[i][j].Z, ContinousPoints[i][j].A, ContinousPoints[i][j].B, ContinousPoints[i][j].C + 360.0);
							}
							if (camPar.Operations.Direction == ClockDirectionType.CW && c > num)
							{
								ContinousPoints[i][j] = new Pnt6D(ContinousPoints[i][j].X, ContinousPoints[i][j].Y, ContinousPoints[i][j].Z, ContinousPoints[i][j].A, ContinousPoints[i][j].B, ContinousPoints[i][j].C - 360.0);
							}
						}
						num = ContinousPoints[i][j].C;
					}
				}
				for (int k = 0; k <= ContinousPoints.Count - 1; k++)
				{
					bool flag = false;
					double toolLength = Tool.Geometry.Diameter / 2.0;
					double feed = camPar.Speeds.Feed;
					double safe = camPar.Distances.Safe;
					double stepUp = camPar.Distances.StepUp;
					Pnt6D pnt6D = new Pnt6D();
					Pnt6D pnt6D2 = new Pnt6D();
					Pnt6D pnt6D3 = new Pnt6D();
					Pnt3D pnt3D2 = new Pnt3D();
					Pnt3D pnt3D3 = new Pnt3D();
					new Pnt3D();
					OrientationAngle orientationAngle2 = new OrientationAngle();
					OrientationAngle orientationAngle3 = new OrientationAngle();
					if (k <= ContinousPoints.Count - 2)
					{
						pnt6D2 = new Pnt6D(ContinousPoints[k + 1][0]);
						orientationAngle3 = new OrientationAngle(pnt6D2);
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					pnt6D3 = new Pnt6D();
					pnt6D = new Pnt6D(ContinousPoints[k][0]);
					pnt3D2 = new Pnt3D(pnt6D);
					pnt3D3 = new Pnt3D();
					new Pnt3D();
					orientationAngle2 = new OrientationAngle(pnt6D);
					feed = camPar.Speeds.Feed;
					pnt6D3 = new Pnt6D(pnt3D2);
					pnt3D3 = new Pnt3D();
					double num4 = 0.0;
					if (k == 0 && orientationAngle2.A != 0.0)
					{
						num4 = orientationAngle2.A;
						pnt6D.A = 0.0;
					}
					pnt6D3 = new Pnt6D(pnt6D);
					pnt3D3 = new Pnt3D();
					Pnt9DCam pnt9DCam = new Pnt9DCam(pnt6D3, camPar.Speeds.Rapid, 0);
					if (!buCompare.EQ(new Pnt3D(pnt6D), pnt3D) && k > 0)
					{
						flag = true;
					}
					if (k == 0)
					{
						pnt9DCam.AfterCodes.Add(WaterJetApproach);
						pnt9DCam.AfterCodes.Add(WaterJetDownOperationCmd);
						pnt9DCam.AfterCodes.Add(WaterJetOnCmd);
						if (num4 != 0.0)
						{
							pnt9DCam.AfterCodes.Add("G0 A" + num4.ToString("f2"));
						}
					}
					if (flag)
					{
						pnt9DCam.PreCodes.Add(WaterJetNextOff);
						pnt9DCam.AfterCodes.Add(WaterJetNextOn);
					}
					if (orientationAngle2.A == orientationAngle.A)
					{
					}
					camPoint.Points.Add(pnt9DCam);
					new Pnt6D(pnt6D3);
					if (k == 0)
					{
						new Pnt6D(pnt6D3);
					}
					List<Pnt3D> list = new List<Pnt3D>();
					list.Add(new Pnt3D(ContinousPoints[k][0]));
					for (int l = 1; l <= ContinousPoints[k].Count - 1; l++)
					{
						pnt6D = new Pnt6D(ContinousPoints[k][l]);
						orientationAngle2 = new OrientationAngle(pnt6D);
						pnt6D3 = new Pnt6D(pnt6D);
						camPoint.Points.Add(new Pnt9DCam(pnt6D3, feed, 1));
						list.Add(new Pnt3D(pnt6D));
						pnt3D = new Pnt3D(pnt6D);
						new Pnt6D(pnt6D3);
						orientationAngle = new OrientationAngle(orientationAngle2);
					}
					camPoint.EntitiesG1.Add(new geoPolyline(list, Color.Blue));
					if ((camPoint.Points.Count > 0) & (k == ContinousPoints.Count - 1))
					{
						camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetOffCmd);
						camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetApproach);
						camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G0 A0.0");
						camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G0 C0.0");
						camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetAirUpCmd);
					}
					if (list.Count > 0)
					{
						camPoint.EntitiesG1.Add(new geoPolyline(list, Color.Blue));
					}
					safe = (camPar.Distances.Safe - pnt6D.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					flag = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
					if (k == ContinousPoints.Count - 1)
					{
						flag = true;
					}
					pnt6D3 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + stepUp);
					orientationAngle = new OrientationAngle(orientationAngle2);
					if (flag)
					{
						pnt6D3 = new Pnt6D();
						pnt3D3 = new Pnt3D();
						new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
						buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
						buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					}
					new Pnt6D(pnt6D3);
					if (camPoint.Points.Count > 0)
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
					}
					for (int m = 1; m <= camPoint.Points.Count - 1; m++)
					{
						List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
						double dt = 0.1;
						if (camPoint.Points[m].Type == 0)
						{
							dt = 0.25;
						}
						double num5 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[m - 1]), new Pnt3D(camPoint.Points[m]));
						if (!(num5 > 3.0))
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[m]));
							continue;
						}
						buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[m - 1]), new Pnt6D(camPoint.Points[m]), dt, ref CalculatedPoints);
						CalculatedPoints.RemoveAt(0);
						camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
					}
					calcCam.CamPoints.Add(camPoint);
					if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null && num2 > 0 && num3 > 0 && num3 % num2 == 0)
					{
						calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)k / (double)(ContinousPoints.Count - 1)) * 100.0, Convert.ToDouble((double)k / (double)(ContinousPoints.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
					}
					if (buSystem.DoEventEnable && num2 > 0 && num3 > 0 && num3 % num2 == 0)
					{
						Application.DoEvents();
					}
					if (!buSystem.Cancel)
					{
						num3++;
						continue;
					}
					buSystem.Cancel = false;
					buSystem.Canceled = true;
					if (calculationEventHandler_2 != null)
					{
						calculationEventHandler_2(new CalculationEventArg());
					}
					if (calculationEventHandler_3 != null)
					{
						calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
					}
					buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
					return;
				}
			}
			if (Operation.ApplySurfaceReadData & (Operation.SurfaceReadDevideLength > 0.0) & (pntTeachGrids.Count > 0))
			{
				for (int n = 0; n <= ContinousPoints.Count - 1; n++)
				{
					new List<eEntities>();
					new List<Pnt3D>();
					for (int num6 = 0; num6 <= ContinousPoints[n].Count - 1; num6++)
					{
						double num7 = 0.0;
						int num8 = Convert.ToInt32(ContinousPoints[n][num6].X);
						int num9 = Convert.ToInt32(ContinousPoints[n][num6].Y);
						if (num8 < 0)
						{
							num8 = 0;
						}
						if (num9 < 0)
						{
							num9 = 0;
						}
						if (((num9 >= 0) & (num9 <= pntTeachGrids.Count - 1)) && ((num8 >= 0) & (num8 <= pntTeachGrids[num9].Count - 1)))
						{
							num7 = pntTeachGrids[num9][num8].Z;
						}
						ContinousPoints[n][num6] = new Pnt6D(ContinousPoints[n][num6].X, ContinousPoints[n][num6].Y, ContinousPoints[n][num6].Z + num7, ContinousPoints[n][num6].A, 0.0, ContinousPoints[n][num6].C);
					}
				}
			}
			if (Operation.WaterJet5AxisConcaveCalculation)
			{
				CalcMarbleWaterjet5AxisConcaveCalculation(Kinematic, Tool, CamMarblePars, camPar, Operation, AValue, CValue, WaterJetAirUpCmd, WaterJetDownOperationCmd, WaterJetOnCmd, WaterJetOffCmd, WaterJetNextOn, WaterJetNextOff, WaterJetApproach, Resolution, ref calcCam, ref ContinousPoints);
			}
			eEntities.CopyEntities(Entities, ref calcCam.CalculatedEntities);
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalcMarbleEntitiesToContinousPoint(List<List<eEntities>> Entities, EntitiesResolution Resolution, marbleCamParameters CamMarblePars, camParameters camPar, marbleOperation Operation, ref List<List<Pnt6D>> ContinousPoints)
	{
		double num = camPar.Strategy.AngleLimit;
		List<List<eEntities>> list = new List<List<eEntities>>();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			List<eEntities> list2 = new List<eEntities>();
			for (int j = 0; j <= Entities[i].Count - 1; j++)
			{
				if (!(Entities[i][j].GetType() == typeof(eCircle)))
				{
					if (!(Entities[i][j].GetType() == typeof(eArc)))
					{
						eEntities copiedEnt = new eEntities();
						eEntities.CopyEntity(Entities[i][j], ref copiedEnt);
						list2.Add(copiedEnt);
						continue;
					}
					if (list2.Count > 0)
					{
						list.Add(list2);
					}
					list2 = new List<eEntities>();
					eEntities copiedEnt2 = new eEntities();
					eEntities.CopyEntity(Entities[i][j], ref copiedEnt2);
					list2.Add(copiedEnt2);
					list.Add(list2);
					list2 = new List<eEntities>();
					continue;
				}
				if (camPar.Operations.Direction != ClockDirectionType.CCW)
				{
					eArc eArc2 = new eArc(((eCircle)Entities[i][j]).CenterPoint, ((eCircle)Entities[i][j]).Radius, 180.0, 360.0, ((eCircle)Entities[i][j]).Plane);
					eArc2.Orientation = new OrientationAngle(Entities[i][j].Orientation);
					eArc2.camDirections = camPathDirectionType.Reverse;
					list2.Add(eArc2);
					list.Add(list2);
					list2 = new List<eEntities>();
					eArc2 = new eArc(((eCircle)Entities[i][j]).CenterPoint, ((eCircle)Entities[i][j]).Radius, 0.0, 180.0, ((eCircle)Entities[i][j]).Plane);
					eArc2.Orientation = new OrientationAngle(Entities[i][j].Orientation);
					if (camPar.Operations.Direction == ClockDirectionType.CW)
					{
						eArc2.camDirections = camPathDirectionType.Reverse;
					}
					list2.Add(eArc2);
					list.Add(list2);
				}
				else
				{
					eArc eArc3 = new eArc(((eCircle)Entities[i][j]).CenterPoint, ((eCircle)Entities[i][j]).Radius, 0.0, 180.0, ((eCircle)Entities[i][j]).Plane);
					eArc3.Orientation = new OrientationAngle(Entities[i][j].Orientation);
					list2.Add(eArc3);
					list.Add(list2);
					list2 = new List<eEntities>();
					eArc3 = new eArc(((eCircle)Entities[i][j]).CenterPoint, ((eCircle)Entities[i][j]).Radius, 180.0, 360.0, ((eCircle)Entities[i][j]).Plane);
					eArc3.Orientation = new OrientationAngle(Entities[i][j].Orientation);
					list2.Add(eArc3);
					list.Add(list2);
				}
				list2 = new List<eEntities>();
			}
			if (list2.Count > 0)
			{
				list.Add(list2);
			}
		}
		for (int k = 0; k <= list.Count - 1; k++)
		{
			List<Pnt6D> list3 = new List<Pnt6D>();
			if (list[k].Count < 1)
			{
				continue;
			}
			List<Pnt6D> Points = new List<Pnt6D>();
			new List<Pnt6D>();
			buAppCalc.cVector.EntitiesToPoint(list[k], Resolution, ref Points);
			Pnt6D pnt6D = new Pnt6D(Points[0]);
			Pnt6D pnt6D2 = new Pnt6D(Points[Points.Count - 1]);
			buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, Operation.PointFilterLength);
			if (!buCompare.EQ(Points[0], pnt6D, 0.01))
			{
				Points.Insert(0, pnt6D);
			}
			if (!buCompare.EQ(Points[Points.Count - 1], pnt6D2, 0.01))
			{
				Points.Add(pnt6D2);
			}
			if (Points.Count <= 1)
			{
				continue;
			}
			double num2 = 0.0;
			double num3 = 0.0;
			double value = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			num4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
			if (buCompare.EQ(num4, 360.0))
			{
				num4 = 0.0;
			}
			if (CamMarblePars.UseCZero)
			{
				num4 = 0.0;
			}
			if ((list[k].Count == 1) & (Points[0].C != 0.0))
			{
				num4 = Points[0].C;
			}
			num2 = num4;
			list3.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, num4));
			for (int l = 1; l <= Points.Count - 2; l++)
			{
				bool flag = false;
				num4 = ((!buCompare.EQ(new Pnt3D(Points[l]), new Pnt3D(Points[l - 1]), 0.01)) ? buAppCalc.cVector.PointAngle(new Pnt3D(Points[l]), new Pnt3D(Points[l - 1])) : num2);
				buAppCalc.cVector.Length3D(new Pnt3D(Points[l]), new Pnt3D(Points[l - 1]));
				if (CamMarblePars.UseCZero)
				{
					num4 = 0.0;
				}
				if (!camPar.Strategy.UseTangentLimit)
				{
					num = camPar.Strategy.AngleLimit;
					num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points[l]), new Pnt3D(Points[l]), new Pnt3D(Points[l + 1]), new WorkPlane());
					num7 = 180.0 - num6;
					if (num7 >= 360.0 - num)
					{
						num7 = 360.0 - num6;
					}
					num5 = ((!buCompare.EQ(new Pnt3D(Points[l + 1]), new Pnt3D(Points[l]), 0.01)) ? buAppCalc.cVector.PointAngle(new Pnt3D(Points[l + 1]), new Pnt3D(Points[l])) : num4);
					if (CamMarblePars.UseCZero)
					{
						num5 = 0.0;
					}
					if (num7 > num)
					{
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num4));
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l + 1].A, 0.0, num5));
						flag = true;
					}
					Math.Abs(num4 - num2);
					if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
					{
						ContinousPoints.Add(list3);
						list3 = new List<Pnt6D>();
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num5));
						flag = true;
					}
				}
				else
				{
					value = Points[l - 1].A - Points[l].A;
					num3 = Math.Abs(num4 - list3[list3.Count - 1].C);
					if (num3 > 185.0)
					{
						num4 = ((list3[list3.Count - 1].C > num4) ? (num4 + 360.0) : (num4 - 360.0));
					}
					num5 = ((!buCompare.EQ(new Pnt3D(Points[l + 1]), new Pnt3D(Points[l]), 0.01)) ? buAppCalc.cVector.PointAngle(new Pnt3D(Points[l + 1]), new Pnt3D(Points[l])) : num4);
					if (CamMarblePars.UseCZero)
					{
						num5 = 0.0;
					}
					num = camPar.Strategy.AngleLimit;
					num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points[l]), new Pnt3D(Points[l]), new Pnt3D(Points[l + 1]), new WorkPlane());
					if (list[k][0].OperationPlane == planeType.YZ)
					{
						if (camPar.Strategy.UseLimitAngleForOtherPlane)
						{
							num = camPar.Strategy.AngleLimitYZ;
						}
						num6 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list3[list3.Count - 1]), new Pnt3D(Points[l]), new Pnt3D(Points[l]), new Pnt3D(Points[l + 1]), new WorkPlane(planeType.YZ, 1));
					}
					num7 = 180.0 - num6;
					if (num7 >= 360.0 - num)
					{
						num7 = 360.0 - num6;
					}
					Math.Abs(num4 - num2);
					if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
					{
						ContinousPoints.Add(list3);
						list3 = new List<Pnt6D>();
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num5));
						flag = true;
					}
				}
				if (!flag)
				{
					if (!((num7 > num) & camPar.Strategy.UseTangentLimit))
					{
						double num8 = 0.0;
						if (camPar.Strategy.UseTangentLimit)
						{
							num8 = Math.Abs(num4 - list3[list3.Count - 1].C);
							if (num8 >= 360.0 - num)
							{
								num4 = ((num4 > list3[list3.Count - 1].C) ? (num4 - 360.0) : (num4 + 360.0));
								num8 = Math.Abs(num4 - list3[list3.Count - 1].C);
							}
							if (num8 > 185.0)
							{
								num4 += 360.0;
							}
						}
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num4));
						if (Math.Abs(num4 - num5) > 180.1)
						{
							double value2 = num4 - num5;
							if (!(num4 > num5))
							{
								double num9 = buNumeric.RoundToLower(Math.Abs(value2) / 360.0);
								num5 -= 360.0 + num9 * 360.0;
							}
							else
							{
								double num10 = buNumeric.RoundToLower(Math.Abs(value2) / 360.0);
								num5 += 360.0 + num10 * 360.0;
							}
						}
						if (camPar.Options.AxesLimit.MinLimit != camPar.Options.AxesLimit.MaxLimit)
						{
							if (num5 > camPar.Options.AxesLimit.MaxLimit.C)
							{
								ContinousPoints.Add(list3);
								num4 -= 360.0;
								list3 = new List<Pnt6D>();
								list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num4));
							}
							if (num5 < camPar.Options.AxesLimit.MinLimit.C)
							{
								ContinousPoints.Add(list3);
								num4 += 360.0;
								list3 = new List<Pnt6D>();
								list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num4));
							}
						}
					}
					else
					{
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l].A, 0.0, num4));
						ContinousPoints.Add(list3);
						list3 = new List<Pnt6D>();
						list3.Add(new Pnt6D(Points[l].X, Points[l].Y, Points[l].Z, Points[l + 1].A, 0.0, num5));
					}
				}
				num2 = num4;
			}
			if (list3.Count <= 0)
			{
				continue;
			}
			num4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
			if (CamMarblePars.UseCZero)
			{
				num4 = 0.0;
			}
			if ((list[k].Count == 1) & (Points[Points.Count - 1].C != 0.0))
			{
				num4 = Points[Points.Count - 1].C;
			}
			double num11 = Math.Abs(num4 - list3[list3.Count - 1].C);
			if (num11 >= 360.0 - num)
			{
				num11 = 360.0 - num4;
				if (num4 > list3[list3.Count - 1].C)
				{
					num4 -= 360.0;
				}
			}
			if (num11 > 185.0)
			{
				num4 += 360.0;
			}
			list3.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, num4));
			ContinousPoints.Add(list3);
		}
	}

	public void CalcMarbleWaterjet5AxisConcaveCalculation(KinematicBase Kinematic, ToolBase Tool, marbleCamParameters CamMarblePars, camParameters camPar, marbleOperation Operation, double AValue, double CValue, string WaterJetAirUpCmd, string WaterJetDownOperationCmd, string WaterJetOnCmd, string WaterJetOffCmd, string WaterJetNextOn, string WaterJetNextOff, string WaterJetApproach, EntitiesResolution Resolution, ref camBase calcCam, ref List<List<Pnt6D>> ContinousPoints)
	{
		int num = Convert.ToInt32((double)ContinousPoints.Count / 100.0);
		int num2 = 0;
		new Pnt6D();
		new Pnt6D();
		double num3 = 0.0;
		OrientationAngle orientationAngle = new OrientationAngle();
		ClockDirectionType clockDirectionType = camPar.Operations.Direction;
		CamPoint camPoint = new CamPoint();
		Pnt3D pnt3D = new Pnt3D();
		new Pnt6D();
		bool flag = false;
		for (int i = 0; i <= ContinousPoints.Count - 1; i++)
		{
			List<Pnt3D> list = new List<Pnt3D>();
			double num4 = 0.0;
			if (i < ContinousPoints.Count - 1)
			{
				for (int j = 0; j <= ContinousPoints[i].Count - 1; j++)
				{
					list.Add(new Pnt3D(ContinousPoints[i][j]));
				}
				list.Add(new Pnt3D(ContinousPoints[i + 1][1]));
				if (list.Count == 3)
				{
					num4 = buAppCalc.cVector.CrossProductLength(list[0], list[1], list[list.Count - 1]);
				}
				if (list.Count > 3)
				{
					num4 = buAppCalc.cVector.CrossProductLength(list[0], list[1], list[2]);
				}
				if (!buAppCalc.cVector.IsClosed(list))
				{
					clockDirectionType = buAppCalc.cVector.PolygonDirection(list);
				}
				if (clockDirectionType == ClockDirectionType.CCW && ((num4 < 0.0) & (camPar.Offsets.OpenContourOld == CamOpenContourType2.Left)))
				{
					flag = true;
				}
				if (clockDirectionType == ClockDirectionType.CW && ((num4 > 0.0) & (camPar.Offsets.OpenContourOld == CamOpenContourType2.Right)))
				{
					flag = true;
				}
			}
			for (int k = 0; k <= ContinousPoints[i].Count - 1; k++)
			{
				if (i > 0)
				{
					double c = ContinousPoints[i][k].C;
					if (clockDirectionType == ClockDirectionType.CCW)
					{
						if (c < num3 && num3 - c > 180.0 && !flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C + 360.0);
						}
						if (c > num3 && c - num3 > 180.0 && flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C - 360.0);
						}
						if (num3 > c && num3 - c > 180.0 && flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C + 360.0);
						}
					}
					if (clockDirectionType == ClockDirectionType.CW)
					{
						if (c > num3 && c - num3 > 180.0 && !flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C - 360.0);
						}
						if (c > num3 && c - num3 > 180.0 && flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C - 360.0);
						}
						if (num3 > c && num3 - c > 180.0 && flag)
						{
							ContinousPoints[i][k] = new Pnt6D(ContinousPoints[i][k].X, ContinousPoints[i][k].Y, ContinousPoints[i][k].Z, ContinousPoints[i][k].A, ContinousPoints[i][k].B, ContinousPoints[i][k].C + 360.0);
						}
					}
				}
				num3 = ContinousPoints[i][k].C;
			}
		}
		List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
		for (int l = 0; l <= ContinousPoints.Count - 1; l++)
		{
			List<Pnt6D> list3 = new List<Pnt6D>();
			if (l == 0)
			{
				if (camPar.Operations.Direction == ClockDirectionType.CW)
				{
					if (Operation.WaterJetLeadInLength > 0.0)
					{
						Pnt3D centerPnt = new Pnt3D(ContinousPoints[l][0]);
						Pnt3D EndPnt = new Pnt3D();
						buAppCalc.cVector.LineWithLengthAndAngle(centerPnt, Operation.WaterJetLeadInLength, ContinousPoints[l][0].C - Operation.WaterJetLeadInInsideAngle, new WorkPlane(), ref EndPnt);
						list3 = new List<Pnt6D>();
						list3.Add(new Pnt6D(EndPnt.X, EndPnt.Y, 0.0, ContinousPoints[l][0].A, 0.0, ContinousPoints[l][0].C - Operation.WaterJetLeadInInsideAngle + 180.0));
						list3.Add(new Pnt6D(ContinousPoints[l][0].X, ContinousPoints[l][0].Y, ContinousPoints[l][0].Z, ContinousPoints[l][0].A, 0.0, ContinousPoints[l][0].C - Operation.WaterJetLeadInInsideAngle + 180.0));
						list2.Add(list3);
					}
					Pnt6D MiddlePoint = new Pnt6D();
					List<Pnt6D> list4 = new List<Pnt6D>();
					if (ContinousPoints[l].Count != 2)
					{
						list4 = new List<Pnt6D>();
						Pnt6D.Copy(ContinousPoints[l], ref list4);
						list2.Add(list4);
					}
					else
					{
						buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[l][0], ContinousPoints[l][1], ref MiddlePoint);
						list4.Add(new Pnt6D(ContinousPoints[l][0]));
						list4.Add(new Pnt6D(MiddlePoint));
						list2.Add(list4);
						list4 = new List<Pnt6D>();
						list4.Add(new Pnt6D(MiddlePoint));
						list4.Add(new Pnt6D(ContinousPoints[l][1]));
						list2.Add(list4);
					}
				}
				if (camPar.Operations.Direction == ClockDirectionType.CCW)
				{
					List<Pnt6D> list5 = new List<Pnt6D>();
					if (Operation.WaterJetLeadInLength > 0.0)
					{
						if (Operation.WaterJetLeadInOutsideAngle != 180.0)
						{
							Pnt3D centerPnt2 = new Pnt3D(ContinousPoints[l][0]);
							Pnt3D EndPnt2 = new Pnt3D();
							buAppCalc.cVector.LineWithLengthAndAngle(centerPnt2, Operation.WaterJetLeadInLength, ContinousPoints[l][0].C - Operation.WaterJetLeadInOutsideAngle, new WorkPlane(), ref EndPnt2);
							Pnt6D pnt6D = new Pnt6D(ContinousPoints[l][0]);
							pnt6D.X = EndPnt2.X;
							pnt6D.Y = EndPnt2.Y;
							pnt6D.C = ContinousPoints[l][0].C - Operation.WaterJetLeadInOutsideAngle + 180.0;
							list5 = new List<Pnt6D>();
							list5.Add(new Pnt6D(pnt6D));
							list5.Add(new Pnt6D(ContinousPoints[l][0].X, ContinousPoints[l][0].Y, ContinousPoints[l][0].Z, ContinousPoints[l][0].A, ContinousPoints[l][0].B, pnt6D.C));
							list2.Add(list5);
						}
						else
						{
							Pnt3D centerPnt3 = new Pnt3D(ContinousPoints[l][0]);
							Pnt3D EndPnt3 = new Pnt3D();
							buAppCalc.cVector.LineWithLengthAndAngle(centerPnt3, Operation.WaterJetLeadInLength, ContinousPoints[l][0].C + Operation.WaterJetLeadInOutsideAngle, new WorkPlane(), ref EndPnt3);
							ContinousPoints[l][0] = new Pnt6D(EndPnt3.X, EndPnt3.Y, ContinousPoints[l][0].Z, ContinousPoints[l][0].A, ContinousPoints[l][0].B, ContinousPoints[l][0].C);
						}
					}
					list5 = new List<Pnt6D>();
					Pnt6D.Copy(ContinousPoints[l], ref list5);
					list2.Add(list5);
				}
			}
			if (l == ContinousPoints.Count - 1)
			{
				if (camPar.Operations.Direction == ClockDirectionType.CW)
				{
					list3 = new List<Pnt6D>();
					Pnt6D MiddlePoint2 = new Pnt6D();
					if (ContinousPoints[l].Count != 2)
					{
						if (ContinousPoints.Count > 1)
						{
							List<Pnt6D> CopiedPnt = new List<Pnt6D>();
							Pnt6D.Copy(ContinousPoints[l], ref CopiedPnt);
							list2.Add(CopiedPnt);
						}
					}
					else
					{
						buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[l][ContinousPoints[l].Count - 2], ContinousPoints[l][ContinousPoints[l].Count - 1], ref MiddlePoint2);
						List<Pnt6D> list6 = new List<Pnt6D>();
						list6.Add(new Pnt6D(ContinousPoints[l][ContinousPoints[l].Count - 2]));
						list6.Add(new Pnt6D(MiddlePoint2));
						list2.Add(list6);
						list6 = new List<Pnt6D>();
						list6.Add(new Pnt6D(MiddlePoint2));
						list6.Add(new Pnt6D(ContinousPoints[l][ContinousPoints[l].Count - 1]));
						list2.Add(list6);
					}
					if (Operation.WaterJetLeadOutLength > 0.0)
					{
						Pnt3D centerPnt4 = new Pnt3D(ContinousPoints[l][ContinousPoints[l].Count - 1]);
						Pnt3D EndPnt4 = new Pnt3D();
						buAppCalc.cVector.LineWithLengthAndAngle(centerPnt4, Operation.WaterJetLeadOutLength, ContinousPoints[l][ContinousPoints[l].Count - 1].C + Operation.WaterJetLeadOutInsideAngle - 180.0, new WorkPlane(), ref EndPnt4);
						list3 = new List<Pnt6D>();
						list3.Add(new Pnt6D(ContinousPoints[l][ContinousPoints[l].Count - 1].X, ContinousPoints[l][ContinousPoints[l].Count - 1].Y, ContinousPoints[l][ContinousPoints[l].Count - 1].Z, ContinousPoints[l][ContinousPoints[l].Count - 1].A, 0.0, ContinousPoints[l][ContinousPoints[l].Count - 1].C + Operation.WaterJetLeadOutInsideAngle - 180.0));
						list3.Add(new Pnt6D(EndPnt4.X, EndPnt4.Y, 0.0, ContinousPoints[l][0].A, 0.0, ContinousPoints[l][0].C + Operation.WaterJetLeadOutInsideAngle - 180.0));
						list2.Add(list3);
					}
				}
				if (camPar.Operations.Direction == ClockDirectionType.CCW)
				{
					List<Pnt6D> CopiedPnt2 = new List<Pnt6D>();
					if (ContinousPoints.Count > 1)
					{
						Pnt6D.Copy(ContinousPoints[l], ref CopiedPnt2);
						list2.Add(CopiedPnt2);
					}
					if (Operation.WaterJetLeadOutLength > 0.0)
					{
						if (Operation.WaterJetLeadInOutsideAngle != 180.0)
						{
							Pnt3D centerPnt5 = new Pnt3D(ContinousPoints[l][ContinousPoints[l].Count - 1]);
							Pnt3D EndPnt5 = new Pnt3D();
							buAppCalc.cVector.LineWithLengthAndAngle(centerPnt5, Operation.WaterJetLeadOutLength, ContinousPoints[l][ContinousPoints[l].Count - 1].C - (180.0 - Operation.WaterJetLeadOutOutsideAngle), new WorkPlane(), ref EndPnt5);
							Pnt6D pnt6D2 = new Pnt6D(list2[list2.Count - 1][list2[list2.Count - 1].Count - 1]);
							Pnt6D pnt6D3 = new Pnt6D(list2[list2.Count - 1][list2[list2.Count - 1].Count - 1]);
							pnt6D2.X = EndPnt5.X;
							pnt6D2.Y = EndPnt5.Y;
							pnt6D2.C = pnt6D3.C + Operation.WaterJetLeadOutOutsideAngle - 180.0;
							CopiedPnt2 = new List<Pnt6D>();
							CopiedPnt2.Add(new Pnt6D(ContinousPoints[l][ContinousPoints[l].Count - 1].X, ContinousPoints[l][ContinousPoints[l].Count - 1].Y, ContinousPoints[l][ContinousPoints[l].Count - 1].Z, ContinousPoints[l][ContinousPoints[l].Count - 1].A, ContinousPoints[l][ContinousPoints[l].Count - 1].B, pnt6D2.C));
							CopiedPnt2.Add(new Pnt6D(pnt6D2));
							list2.Add(CopiedPnt2);
						}
						else
						{
							Pnt3D centerPnt6 = new Pnt3D(ContinousPoints[l][ContinousPoints[l].Count - 1]);
							Pnt3D EndPnt6 = new Pnt3D();
							buAppCalc.cVector.LineWithLengthAndAngle(centerPnt6, Operation.WaterJetLeadOutLength, ContinousPoints[l][ContinousPoints[l].Count - 1].C + 180.0 - Operation.WaterJetLeadOutOutsideAngle, new WorkPlane(), ref EndPnt6);
							Pnt6D pnt6D4 = new Pnt6D(list2[list2.Count - 1][list2[list2.Count - 1].Count - 1]);
							pnt6D4.X = EndPnt6.X;
							pnt6D4.Y = EndPnt6.Y;
							list2[list2.Count - 1][list2[list2.Count - 1].Count - 1] = new Pnt6D(pnt6D4);
						}
					}
				}
			}
			if (!((l > 0) & (l < ContinousPoints.Count - 1)) || l > ContinousPoints.Count - 2)
			{
				continue;
			}
			List<Pnt3D> list7 = new List<Pnt3D>();
			List<Pnt3D> list8 = new List<Pnt3D>();
			for (int m = 0; m <= ContinousPoints[l - 1].Count - 1; m++)
			{
				list7.Add(new Pnt3D(ContinousPoints[l - 1][m]));
			}
			list7.Add(new Pnt3D(ContinousPoints[l][1]));
			if (list7.Count == 3)
			{
				buAppCalc.cVector.CrossProductLength(list7[0], list7[1], list7[list7.Count - 1]);
			}
			if (list7.Count > 3)
			{
				buAppCalc.cVector.CrossProductLength(list7[0], list7[1], list7[2]);
			}
			for (int n = 0; n <= ContinousPoints[l].Count - 1; n++)
			{
				list8.Add(new Pnt3D(ContinousPoints[l][n]));
			}
			list8.Add(new Pnt3D(ContinousPoints[l + 1][1]));
			if (list8.Count == 3)
			{
				buAppCalc.cVector.CrossProductLength(list8[0], list8[1], list8[list8.Count - 1]);
			}
			if (list8.Count > 3)
			{
				buAppCalc.cVector.CrossProductLength(list8[0], list8[1], list8[2]);
			}
			if (camPar.Operations.Direction == ClockDirectionType.CW)
			{
				if (ContinousPoints[l].Count != 2)
				{
					List<Pnt6D> CopiedPnt3 = new List<Pnt6D>();
					Pnt6D.Copy(ContinousPoints[l], ref CopiedPnt3);
					list2.Add(CopiedPnt3);
				}
				else
				{
					Pnt6D MiddlePoint3 = new Pnt6D();
					buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[l][0], ContinousPoints[l][1], ref MiddlePoint3);
					List<Pnt6D> list9 = new List<Pnt6D>();
					list9.Add(new Pnt6D(ContinousPoints[l][0]));
					list9.Add(new Pnt6D(MiddlePoint3));
					list2.Add(list9);
					list9 = new List<Pnt6D>();
					list9.Add(new Pnt6D(MiddlePoint3));
					list9.Add(new Pnt6D(ContinousPoints[l][1]));
					list2.Add(list9);
				}
			}
			if (camPar.Operations.Direction == ClockDirectionType.CCW)
			{
				if (ContinousPoints[l].Count != 2)
				{
					List<Pnt6D> CopiedPnt4 = new List<Pnt6D>();
					Pnt6D.Copy(ContinousPoints[l], ref CopiedPnt4);
					list2.Add(CopiedPnt4);
					continue;
				}
				Pnt6D MiddlePoint4 = new Pnt6D();
				buAppCalc.cVector.MiddlePointOfLine(ContinousPoints[l][0], ContinousPoints[l][1], ref MiddlePoint4);
				List<Pnt6D> list10 = new List<Pnt6D>();
				list10.Add(new Pnt6D(ContinousPoints[l][0]));
				list10.Add(new Pnt6D(MiddlePoint4));
				list2.Add(list10);
				list10 = new List<Pnt6D>();
				list10.Add(new Pnt6D(MiddlePoint4));
				list10.Add(new Pnt6D(ContinousPoints[l][1]));
				list2.Add(list10);
			}
		}
		ContinousPoints.Clear();
		ContinousPoints = new List<List<Pnt6D>>();
		for (int num5 = 0; num5 <= list2.Count - 1; num5++)
		{
			List<Pnt6D> CopiedPnt5 = new List<Pnt6D>();
			Pnt6D.Copy(list2[num5], ref CopiedPnt5);
			ContinousPoints.Add(CopiedPnt5);
		}
		double num6 = 0.0;
		bool flag2 = false;
		List<List<Pnt6D>> CopiedPnt6 = new List<List<Pnt6D>>();
		Pnt6D.Copy(ContinousPoints, ref CopiedPnt6);
		for (int num7 = 0; num7 <= ContinousPoints.Count - 1; num7++)
		{
			double num8 = 0.0;
			double num9 = 0.0;
			double num10 = 0.0;
			double num11 = 0.0;
			double num12 = 0.0;
			List<Pnt3D> list11 = new List<Pnt3D>();
			List<Pnt3D> list12 = new List<Pnt3D>();
			double num13 = 0.0;
			double num14 = 0.0;
			double angleDiff = 0.0;
			double num15 = 0.0;
			double num16 = 0.0;
			int num17 = 0;
			int index = 0;
			num17 = ContinousPoints[num7].Count - 1;
			if (num7 < ContinousPoints.Count - 1)
			{
				index = ContinousPoints[num7 + 1].Count - 1;
			}
			if (num7 < ContinousPoints.Count - 1)
			{
				for (int num18 = 0; num18 <= ContinousPoints[num7].Count - 1; num18++)
				{
					list11.Add(new Pnt3D(ContinousPoints[num7][num18]));
				}
				list11.Add(new Pnt3D(ContinousPoints[num7 + 1][1]));
				if (list11.Count == 3)
				{
					num15 = buAppCalc.cVector.CrossProductLength(list11[0], list11[1], list11[list11.Count - 1]);
				}
				if (list11.Count > 3)
				{
					num15 = buAppCalc.cVector.CrossProductLength(list11[list11.Count - 3], list11[list11.Count - 2], list11[list11.Count - 1]);
				}
				if (num7 < ContinousPoints.Count - 2)
				{
					for (int num19 = 0; num19 <= ContinousPoints[num7 + 1].Count - 1; num19++)
					{
						list12.Add(new Pnt3D(ContinousPoints[num7 + 1][num19]));
					}
					list12.Add(new Pnt3D(ContinousPoints[num7 + 2][1]));
					if (list12.Count == 3)
					{
						num16 = buAppCalc.cVector.CrossProductLength(list12[0], list12[1], list12[list12.Count - 1]);
					}
					if (list12.Count > 3)
					{
						num16 = buAppCalc.cVector.CrossProductLength(list12[0], list12[1], list12[2]);
					}
				}
				double RatioAFromC = 1.0;
				double RatioAFromA = 1.0;
				double X = 1.0;
				double RatioAFromC2 = 1.0;
				double RatioAFromA2 = 1.0;
				double X2 = 1.0;
				if (num7 < ContinousPoints.Count - 2)
				{
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 0.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 1.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA0, Operation.WaterJet5AxisCRtForA1, 0.0, 1.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 1.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 10.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA1, Operation.WaterJet5AxisCRtForA10, 1.0, 10.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 10.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 20.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA10, Operation.WaterJet5AxisCRtForA20, 10.0, 20.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 20.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 30.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA20, Operation.WaterJet5AxisCRtForA30, 20.0, 30.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 30.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 40.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA30, Operation.WaterJet5AxisCRtForA40, 30.0, 40.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 40.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 45.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA40, Operation.WaterJet5AxisCRtForA45, 40.0, 45.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
					if ((ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A > 45.0) & (ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A <= 50.0))
					{
						buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA45, Operation.WaterJet5AxisCRtForA50, 45.0, 50.0, ContinousPoints[num7 + 1][ContinousPoints[num7 + 1].Count - 1].A, ref X2);
					}
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 0.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 1.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA0, Operation.WaterJet5AxisCRtForA1, 0.0, 1.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 1.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 10.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA1, Operation.WaterJet5AxisCRtForA10, 1.0, 10.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 10.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 20.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA10, Operation.WaterJet5AxisCRtForA20, 10.0, 20.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 20.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 30.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA20, Operation.WaterJet5AxisCRtForA30, 20.0, 30.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 30.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 40.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA30, Operation.WaterJet5AxisCRtForA40, 30.0, 40.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 40.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 45.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA40, Operation.WaterJet5AxisCRtForA45, 40.0, 45.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if ((ContinousPoints[num7][ContinousPoints[num7].Count - 1].A > 45.0) & (ContinousPoints[num7][ContinousPoints[num7].Count - 1].A <= 50.0))
				{
					buNumeric.EquationLineer(Operation.WaterJet5AxisCRtForA45, Operation.WaterJet5AxisCRtForA50, 45.0, 50.0, ContinousPoints[num7][ContinousPoints[num7].Count - 1].A, ref X);
				}
				if (camPar.Operations.Direction == ClockDirectionType.CCW)
				{
					double num20 = 0.0;
					double num21 = 0.0;
					Pnt6D pnt6D5 = new Pnt6D();
					num13 = CopiedPnt6[num7 + 1][0].C - CopiedPnt6[num7][num17].C;
					if (num13 < -360.0)
					{
						num13 += 360.0;
					}
					if (num13 > 360.0)
					{
						num13 -= 360.0;
					}
					num14 = CopiedPnt6[num7][num17].A;
					calcARatio(num13, num14, Operation, ref RatioAFromC, ref RatioAFromA);
					num8 = CopiedPnt6[num7][num17].A * RatioAFromC * RatioAFromA;
					num9 = CopiedPnt6[num7][num17].C - CopiedPnt6[num7][num17].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
					num11 = CopiedPnt6[num7 + 1][index].C - CopiedPnt6[num7 + 1][index].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
					num10 = CopiedPnt6[num7][num17].C + num13 / 2.0 - num8 * X + Operation.WaterJet5AxisCOffsetMiddle;
					if (num7 < CopiedPnt6.Count - 2)
					{
						num13 = CopiedPnt6[num7 + 2][0].C - CopiedPnt6[num7 + 1][index].C;
						num14 = CopiedPnt6[num7 + 1][index].A;
						calcARatio(num13, num14, Operation, ref RatioAFromC2, ref RatioAFromA2);
						num12 = CopiedPnt6[num7 + 1][index].A * RatioAFromC2 * RatioAFromA2;
						_ = CopiedPnt6[num7 + 1][index].C - CopiedPnt6[num7 + 1][index].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
						_ = CopiedPnt6[num7 + 2][CopiedPnt6[num7 + 2].Count - 1].C - CopiedPnt6[num7 + 2][CopiedPnt6[num7 + 2].Count - 1].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
						_ = CopiedPnt6[num7][num17].C + num13 / 2.0 - num12 * X + Operation.WaterJet5AxisCOffsetMiddle;
					}
					if (!(num15 > 1E-05))
					{
						if (!(num15 < -1E-07))
						{
							if (num6 >= 0.0 && num16 >= 0.0 && num7 > 0)
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
							}
							if (num6 >= 0.0 && num16 < 0.0 && num7 > 0 && num7 < ContinousPoints.Count - 2)
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][1]);
								pnt6D5.A = ContinousPoints[num7][0].A;
								pnt6D5.C = ContinousPoints[num7][0].C;
								ContinousPoints[num7][1] = new Pnt6D(pnt6D5);
							}
							if (num6 < 0.0 && num16 > 0.0 && num7 > 0)
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
								pnt6D5 = new Pnt6D(ContinousPoints[num7][1]);
								pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][1] = new Pnt6D(pnt6D5);
							}
							if (num6 < 0.0 && num16 < 0.0 && num7 > 0)
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
								pnt6D5 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D5.A = num8;
								pnt6D5.C = num9;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D5);
							}
						}
						else
						{
							if (num7 != 0)
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
								pnt6D5 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D5.A = num8;
								pnt6D5.C = num10;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D5);
							}
							else
							{
								pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D5.C = num9;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
								pnt6D5 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D5.A = num8;
								pnt6D5.C = num10;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D5);
							}
							pnt6D5 = new Pnt6D(ContinousPoints[num7 + 1][0]);
							pnt6D5.A = num8;
							pnt6D5.C = num10;
							ContinousPoints[num7 + 1][0] = new Pnt6D(pnt6D5);
							pnt6D5 = new Pnt6D(ContinousPoints[num7 + 1][index]);
							pnt6D5.A = ContinousPoints[num7 + 1][index].A;
							pnt6D5.C = num11;
							ContinousPoints[num7 + 1][index] = new Pnt6D(pnt6D5);
						}
					}
					else
					{
						if (num7 != 0)
						{
							pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
							pnt6D5.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
							pnt6D5.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
							ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
							if (Math.Abs(ContinousPoints[num7][0].C - num10) > 360.0)
							{
								num10 = ((ContinousPoints[num7][0].C > num10) ? (num10 + 360.0) : (num10 - 360.0));
							}
							pnt6D5 = new Pnt6D(ContinousPoints[num7][num17]);
							pnt6D5.A = num8;
							pnt6D5.C = num10;
							ContinousPoints[num7][num17] = new Pnt6D(pnt6D5);
						}
						else
						{
							pnt6D5 = new Pnt6D(ContinousPoints[num7][0]);
							pnt6D5.C = num9;
							ContinousPoints[num7][0] = new Pnt6D(pnt6D5);
							pnt6D5 = new Pnt6D(ContinousPoints[num7][num17]);
							pnt6D5.A = num8;
							pnt6D5.C = num10;
							ContinousPoints[num7][num17] = new Pnt6D(pnt6D5);
						}
						pnt6D5 = new Pnt6D(ContinousPoints[num7 + 1][0]);
						pnt6D5.A = num8;
						pnt6D5.C = num10;
						ContinousPoints[num7 + 1][0] = new Pnt6D(pnt6D5);
						if (Math.Abs(num10 - num11) > 360.0)
						{
							num11 = ((num10 > num11) ? (num11 + 360.0) : (num11 - 360.0));
						}
						pnt6D5 = new Pnt6D(ContinousPoints[num7 + 1][index]);
						pnt6D5.A = ContinousPoints[num7 + 1][index].A;
						pnt6D5.C = num11;
						ContinousPoints[num7 + 1][index] = new Pnt6D(pnt6D5);
					}
					if (num7 > 0)
					{
						num20 = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
						num21 = ContinousPoints[num7][0].C;
						if ((num6 == 0.0) & !buCompare.EQ(num20, num21, 0.1) & (Math.Abs(num20 - num21) < 90.0))
						{
							Pnt6D pnt6D6 = new Pnt6D(ContinousPoints[num7][0]);
							pnt6D6.C = num20;
							ContinousPoints[num7][0] = new Pnt6D(pnt6D6);
						}
					}
				}
				if (camPar.Operations.Direction == ClockDirectionType.CW)
				{
					Pnt6D pnt6D7 = new Pnt6D();
					if (num7 < ContinousPoints.Count - 2)
					{
						num13 = CopiedPnt6[num7 + 2][0].C - CopiedPnt6[num7 + 1][index].C;
						num14 = CopiedPnt6[num7 + 1][index].A;
						calcARatio(num13, num14, Operation, ref RatioAFromC2, ref RatioAFromA2);
						num12 = CopiedPnt6[num7 + 1][index].A * RatioAFromC2 * RatioAFromA2;
						_ = CopiedPnt6[num7 + 1][index].C - CopiedPnt6[num7 + 1][index].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
						_ = CopiedPnt6[num7 + 2][CopiedPnt6[num7 + 2].Count - 1].C - CopiedPnt6[num7 + 2][CopiedPnt6[num7 + 2].Count - 1].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
						_ = CopiedPnt6[num7][num17].C + num13 / 2.0 - num12 * X + Operation.WaterJet5AxisCOffsetMiddle;
					}
					num13 = CopiedPnt6[num7 + 1][0].C - CopiedPnt6[num7][num17].C;
					if (num13 < -360.0)
					{
						num13 += 360.0;
					}
					if (num13 > 360.0)
					{
						num13 -= 360.0;
					}
					num14 = CopiedPnt6[num7][num17].A;
					calcARatio(num13, num14, Operation, ref RatioAFromC, ref RatioAFromA);
					num8 = CopiedPnt6[num7][num17].A * RatioAFromC * RatioAFromA;
					num9 = CopiedPnt6[num7][num17].C - CopiedPnt6[num7][num17].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
					num11 = CopiedPnt6[num7 + 1][index].C - CopiedPnt6[num7 + 1][index].A * X + Operation.WaterJet5AxisCOffsetStartEnd;
					num10 = CopiedPnt6[num7][num17].C + num13 / 2.0 - num8 * X + Operation.WaterJet5AxisCOffsetMiddle;
					if (!(num15 > 1E-06))
					{
						if (!(num15 < -1E-06))
						{
							if (num6 >= 0.0 && num16 >= 0.0 && num7 > 0)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
							}
							if (num6 < 0.0 && num16 > 0.0 && num7 > 0)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
								pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
							}
							if (num6 < 0.0 && num16 < 0.0 && num7 > 0)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
								pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D7.A = num8;
								pnt6D7.C = num9;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
							}
							if (num16 < 0.0 && num6 >= 0.0 && num7 > 0 && num7 < ContinousPoints.Count - 2)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D7.A = ContinousPoints[num7][0].A;
								pnt6D7.C = ContinousPoints[num7][0].C;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
							}
						}
						else
						{
							if (num6 >= 0.0 && num7 > 0 && !flag2)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
								pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D7.A = num8;
								pnt6D7.C = num10;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
							}
							if ((num6 < 0.0 && num7 > 0) || flag2)
							{
								pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
								pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
								pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
								ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
								pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
								pnt6D7.A = num8;
								pnt6D7.C = num10;
								ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
							}
							flag2 = true;
						}
					}
					else
					{
						pnt6D7 = new Pnt6D();
						if (num7 != 0)
						{
							pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
							pnt6D7.A = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].A;
							pnt6D7.C = ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
							ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
							pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
							pnt6D7.A = num8;
							pnt6D7.C = num10;
							ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
						}
						else
						{
							pnt6D7 = new Pnt6D(ContinousPoints[num7][0]);
							pnt6D7.C = num9;
							ContinousPoints[num7][0] = new Pnt6D(pnt6D7);
							pnt6D7 = new Pnt6D(ContinousPoints[num7][num17]);
							pnt6D7.A = num8;
							pnt6D7.C = num10;
							ContinousPoints[num7][num17] = new Pnt6D(pnt6D7);
						}
						pnt6D7 = new Pnt6D(ContinousPoints[num7 + 1][0]);
						pnt6D7.A = num8;
						pnt6D7.C = num10;
						ContinousPoints[num7 + 1][0] = new Pnt6D(pnt6D7);
						pnt6D7 = new Pnt6D(ContinousPoints[num7 + 1][index]);
						pnt6D7.A = ContinousPoints[num7 + 1][index].A;
						pnt6D7.C = num11;
						ContinousPoints[num7 + 1][index] = new Pnt6D(pnt6D7);
						flag2 = false;
					}
				}
				num6 = Math.Round(num15, 5);
			}
			if (num7 > 0)
			{
				double num22 = ContinousPoints[num7][0].C - ContinousPoints[num7 - 1][ContinousPoints[num7 - 1].Count - 1].C;
				if (Math.Abs(num22) > 180.0)
				{
					if (!(num22 < 0.0))
					{
						Pnt6D pnt6D8 = new Pnt6D(ContinousPoints[num7][0]);
						pnt6D8.C -= 360.0;
						ContinousPoints[num7][0] = new Pnt6D(pnt6D8);
						pnt6D8 = new Pnt6D(ContinousPoints[num7][1]);
						pnt6D8.C -= 360.0;
						ContinousPoints[num7][1] = new Pnt6D(pnt6D8);
					}
					else
					{
						Pnt6D pnt6D9 = new Pnt6D(ContinousPoints[num7][0]);
						pnt6D9.C += 360.0;
						ContinousPoints[num7][0] = new Pnt6D(pnt6D9);
						pnt6D9 = new Pnt6D(ContinousPoints[num7][1]);
						pnt6D9.C += 360.0;
						ContinousPoints[num7][1] = new Pnt6D(pnt6D9);
					}
				}
			}
			List<Pnt6D> Points = new List<Pnt6D>();
			if (ContinousPoints[num7].Count != 2)
			{
				if (ContinousPoints[num7].Count > 2)
				{
					List<double> Values = new List<double>();
					List<double> Values2 = new List<double>();
					double c2 = ContinousPoints[num7][0].C;
					double c3 = ContinousPoints[num7][ContinousPoints[num7].Count - 1].C;
					double a = ContinousPoints[num7][0].A;
					double a2 = ContinousPoints[num7][ContinousPoints[num7].Count - 1].A;
					buNumeric.DevideMinMaxValueByNumber(c2, c3, ContinousPoints[num7].Count, ref Values);
					buNumeric.DevideMinMaxValueByNumber(a, a2, ContinousPoints[num7].Count, ref Values2);
					for (int num23 = 0; num23 <= ContinousPoints[num7].Count - 1; num23++)
					{
						Pnt6D pnt6D10 = new Pnt6D(ContinousPoints[num7][num23]);
						pnt6D10.C = Values[num23];
						pnt6D10.A = Values2[num23];
						ContinousPoints[num7][num23] = new Pnt6D(pnt6D10);
					}
				}
				continue;
			}
			for (int num24 = 1; num24 <= ContinousPoints[num7].Count - 1; num24++)
			{
				List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
				Pnt3D value = new Pnt3D(ContinousPoints[num7][num24 - 1]);
				Pnt3D value2 = new Pnt3D(ContinousPoints[num7][num24]);
				if (buCompare.EQ(value, value2))
				{
					CalculatedPoints.Add(new Pnt6D(ContinousPoints[num7][num24]));
				}
				else
				{
					buAppCalc.cVector.LineerInterpolation(ContinousPoints[num7][num24 - 1], ContinousPoints[num7][num24], 0.1, ref CalculatedPoints);
				}
				ReAdjustAngleA(num14, angleDiff, Operation, ref CalculatedPoints);
				Points.AddRange(CalculatedPoints);
			}
			buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
			if (Points.Count >= 2)
			{
				ContinousPoints[num7] = Points;
			}
		}
		for (int num25 = 0; num25 <= ContinousPoints.Count - 1; num25++)
		{
			bool flag3 = false;
			camPoint = new CamPoint();
			camPoint.Type = 0;
			camPoint.IsRapid = true;
			Pnt6D pnt6D11 = new Pnt6D();
			Pnt6D pnt6D12 = new Pnt6D(ContinousPoints[num25][0]);
			Pnt3D pnt = new Pnt3D(pnt6D12);
			Pnt3D pnt3D2 = new Pnt3D();
			new Pnt3D();
			OrientationAngle orientationAngle2 = new OrientationAngle(pnt6D12);
			OrientationAngle orientationAngle3 = new OrientationAngle();
			double feed = camPar.Speeds.Feed;
			double toolLength = Tool.Geometry.Diameter / 2.0;
			double safe = camPar.Distances.Safe;
			double stepUp = camPar.Distances.StepUp;
			if (num25 <= ContinousPoints.Count - 2)
			{
				orientationAngle3 = new OrientationAngle(ContinousPoints[num25 + 1][0]);
			}
			pnt6D11 = new Pnt6D(pnt);
			pnt3D2 = new Pnt3D();
			double num26 = 0.0;
			if (num25 == 0 && orientationAngle2.A != 0.0)
			{
				num26 = orientationAngle2.A;
				pnt6D12.A = 0.0;
			}
			pnt6D11 = new Pnt6D(pnt6D12);
			pnt3D2 = new Pnt3D();
			Pnt9DCam pnt9DCam = new Pnt9DCam(pnt6D11, camPar.Speeds.Rapid, 0);
			if (!buCompare.EQ(new Pnt3D(pnt6D12), pnt3D) && num25 > 0)
			{
				flag3 = true;
			}
			if (num25 == 0)
			{
				pnt9DCam.AfterCodes.Add(WaterJetApproach);
				pnt9DCam.AfterCodes.Add(WaterJetDownOperationCmd);
				pnt9DCam.AfterCodes.Add(WaterJetOnCmd);
				if (num26 != 0.0)
				{
					pnt9DCam.AfterCodes.Add("G75");
					pnt9DCam.AfterCodes.Add("M102");
					pnt9DCam.AfterCodes.Add("G1 A" + num26.ToString("f2"));
					pnt9DCam.AfterCodes.Add("G75");
				}
				pnt9DCam.AfterCodes.Add("G38 O1");
			}
			if (flag3)
			{
				pnt9DCam.PreCodes.Add(WaterJetNextOff);
				pnt9DCam.AfterCodes.Add(WaterJetNextOn);
			}
			if (orientationAngle2.A == orientationAngle.A)
			{
			}
			camPoint.Points.Add(pnt9DCam);
			new Pnt6D(pnt6D11);
			if (num25 == 0)
			{
				new Pnt6D(pnt6D11);
			}
			List<Pnt3D> list13 = new List<Pnt3D>();
			list13.Add(new Pnt3D(ContinousPoints[num25][0]));
			for (int num27 = 1; num27 <= ContinousPoints[num25].Count - 1; num27++)
			{
				pnt6D12 = new Pnt6D(ContinousPoints[num25][num27]);
				orientationAngle2 = new OrientationAngle(pnt6D12);
				pnt6D11 = new Pnt6D(pnt6D12);
				camPoint.Points.Add(new Pnt9DCam(pnt6D11, feed, 1));
				list13.Add(new Pnt3D(pnt6D12));
				pnt3D = new Pnt3D(pnt6D12);
				new Pnt6D(pnt6D11);
				orientationAngle = new OrientationAngle(orientationAngle2);
			}
			camPoint.EntitiesG1.Add(new geoPolyline(list13, Color.Blue));
			if ((camPoint.Points.Count > 0) & (num25 == ContinousPoints.Count - 1))
			{
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G39 O1");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetOffCmd);
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetApproach);
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G75");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G0 A0.0");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G75");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G0 C0.0");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add("G75");
				camPoint.Points[camPoint.Points.Count - 1].AfterCodes.Add(WaterJetAirUpCmd);
			}
			if (list13.Count > 0)
			{
				camPoint.EntitiesG1.Add(new geoPolyline(list13, Color.Blue));
			}
			safe = (camPar.Distances.Safe - pnt6D12.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
			flag3 = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
			if (num25 == ContinousPoints.Count - 1)
			{
				flag3 = true;
			}
			pnt6D11 = new Pnt6D();
			pnt3D2 = new Pnt3D();
			new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + stepUp);
			orientationAngle = new OrientationAngle(orientationAngle2);
			if (flag3)
			{
				pnt6D11 = new Pnt6D();
				pnt3D2 = new Pnt3D();
				new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D2);
				buAppCalc.cKinematic.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, new Pnt3D(pnt3D2), ref pnt6D11);
				pnt6D11.Z = pnt6D11.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
			}
			new Pnt6D(pnt6D11);
			if (camPoint.Points.Count > 0)
			{
				camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
			}
			for (int num28 = 1; num28 <= camPoint.Points.Count - 1; num28++)
			{
				List<Pnt6D> CalculatedPoints2 = new List<Pnt6D>();
				double dt = 0.1;
				if (camPoint.Points[num28].Type == 0)
				{
					dt = 0.25;
				}
				double num29 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num28 - 1]), new Pnt3D(camPoint.Points[num28]));
				if (!(num29 > 3.0))
				{
					camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[num28]));
					continue;
				}
				buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[num28 - 1]), new Pnt6D(camPoint.Points[num28]), dt, ref CalculatedPoints2);
				CalculatedPoints2.RemoveAt(0);
				camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints2);
			}
			calcCam.CamPoints.Add(camPoint);
			if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null && num > 0 && num2 > 0 && num2 % num == 0)
			{
				calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)num25 / (double)(ContinousPoints.Count - 1)) * 100.0, Convert.ToDouble((double)num25 / (double)(ContinousPoints.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
			}
			if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
			{
				Application.DoEvents();
			}
			if (!buSystem.Cancel)
			{
				num2++;
				continue;
			}
			buSystem.Cancel = false;
			buSystem.Canceled = true;
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
			if (calculationEventHandler_3 != null)
			{
				calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
			}
			buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
			break;
		}
	}

	public void CalculateMarbleWireFrameWithLaserTool3Ax(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters CamParameter, double AValue, double CValue, string LaserEnableCmd, string LaserDisableCmd, string LaserStartCmd, string LaserStopCmd, string LaserDoneCmd, EntitiesResolution Resolution, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Entities.Count / 100.0);
			int num2 = 0;
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				eEntities copiedEnt = new eEntities();
				if (Entities[i].Count > 0)
				{
					eEntities copiedEnt2 = new eEntities();
					List<Pnt3D> TargetList = new List<Pnt3D>();
					eEntities.CopyEntity(Entities[i][0], ref copiedEnt2);
					buGeneral.CopyLists(copiedEnt2.Vertice, ref TargetList);
					List<Pnt6D> Points = new List<Pnt6D>();
					buAppCalc.cVector.EntitiesToPoint(Entities[i], Resolution, ref Points);
					if (CamParameter.Strategy.OverrideCEnable)
					{
						for (int j = 0; j <= Points.Count - 1; j++)
						{
							Pnt6D pnt6D = new Pnt6D(Points[j]);
							pnt6D.C = CamParameter.Strategy.OverrideC;
							Points[j] = pnt6D;
						}
						buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points);
					}
					if (copiedEnt2.camDirections == camPathDirectionType.Reverse)
					{
						TargetList.Reverse();
					}
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					if (Points.Count > 1)
					{
						Pnt3D pnt3D2 = new Pnt3D(Points[0]);
						OrientationAngle orientationAngle = new OrientationAngle(Points[0]);
						new OrientationAngle(Points[0]);
						Pnt6D pnt6D2 = new Pnt6D();
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
						camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Rapid, 0));
						pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
						new Pnt6D(pnt6D2);
						pnt6D2 = new Pnt6D(pnt3D2, new OrientationAngle(AValue, 0.0, CValue));
						Pnt9DCam pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 0);
						if (i != 0)
						{
							pnt9DCam.AfterCodes.Add(LaserStartCmd);
						}
						else
						{
							pnt9DCam.AfterCodes.Add(LaserEnableCmd);
							pnt9DCam.AfterCodes.Add(LaserStartCmd);
						}
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2), Color.Lime));
						pnt3D = new Pnt3D(pnt3D2);
						new Pnt6D(pnt6D2);
						List<Pnt3D> list = new List<Pnt3D>();
						list.Add(new Pnt3D(pnt3D));
						for (int k = 1; k <= Points.Count - 1; k++)
						{
							pnt3D2 = new Pnt3D(Points[k]);
							orientationAngle = new OrientationAngle(Points[k]);
							double feed = CamParameter.Speeds.Feed;
							pnt6D2 = new Pnt6D(new Pnt3D(Points[k].X, Points[k].Y, Points[k].Z), new OrientationAngle(AValue, 0.0, CValue));
							camPoint.Points.Add(new Pnt9DCam(pnt6D2, feed, 1));
							list.Add(new Pnt3D(pnt6D2));
							pnt3D = new Pnt3D(Points[k]);
							new Pnt6D(pnt6D2);
							new OrientationAngle(orientationAngle);
						}
						camPoint.EntitiesG1.Add(new geoPolyline(list, Color.Blue));
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D.X, pnt3D.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
						pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 1);
						if (i != Entities.Count - 1)
						{
							pnt9DCam.PreCodes.Add(LaserStopCmd);
						}
						else
						{
							pnt9DCam.PreCodes.Add(LaserStopCmd);
							pnt9DCam.PreCodes.Add(LaserDoneCmd);
							pnt9DCam.AfterCodes.Add(LaserDisableCmd);
						}
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D2), Color.Red));
						if (camPoint.Points.Count > 0)
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
						}
						for (int l = 1; l <= camPoint.Points.Count - 1; l++)
						{
							List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
							double dt = 0.1;
							if (camPoint.Points[l].Type == 0)
							{
								dt = 0.25;
							}
							double num3 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[l - 1]), new Pnt3D(camPoint.Points[l]));
							if (!(num3 > 3.0))
							{
								camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[l]));
								continue;
							}
							buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[l - 1]), new Pnt6D(camPoint.Points[l]), dt, ref CalculatedPoints);
							CalculatedPoints.RemoveAt(0);
							camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
						}
						eEntities.CopyEntity(copiedEnt2, ref copiedEnt);
						calcCam.CamPoints.Add(camPoint);
					}
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Entities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num2++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void calcARatio(double DeltaAngle, double RefAngleA, marbleOperation Operation, ref double RatioAFromC, ref double RatioAFromA)
	{
		double num = Math.Round(180.0 - Math.Abs(DeltaAngle), 5);
		if (num <= 60.0)
		{
			RatioAFromC = 1.462;
		}
		if (num > 60.0 && num <= 70.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle60, Operation.WaterJet5AxisARatioCornerAngle70, 60.0, 70.0, num, ref RatioAFromC);
		}
		if (num > 70.0 && num <= 80.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle70, Operation.WaterJet5AxisARatioCornerAngle80, 70.0, 80.0, num, ref RatioAFromC);
		}
		if (num > 80.0 && num <= 90.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle80, Operation.WaterJet5AxisARatioCornerAngle90, 80.0, 90.0, num, ref RatioAFromC);
		}
		if (num > 90.0 && num <= 100.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle90, Operation.WaterJet5AxisARatioCornerAngle100, 90.0, 100.0, num, ref RatioAFromC);
		}
		if (num > 100.0 && num <= 110.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle100, Operation.WaterJet5AxisARatioCornerAngle110, 100.0, 110.0, num, ref RatioAFromC);
		}
		if (num > 110.0 && num <= 120.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle110, Operation.WaterJet5AxisARatioCornerAngle120, 110.0, 120.0, num, ref RatioAFromC);
		}
		if (num > 120.0 && num <= 130.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle120, Operation.WaterJet5AxisARatioCornerAngle130, 120.0, 130.0, num, ref RatioAFromC);
		}
		if (num > 130.0 && num <= 140.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle130, Operation.WaterJet5AxisARatioCornerAngle140, 130.0, 140.0, num, ref RatioAFromC);
		}
		if (num > 140.0 && num <= 150.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle140, Operation.WaterJet5AxisARatioCornerAngle150, 140.0, 150.0, num, ref RatioAFromC);
		}
		if (num > 150.0 && num <= 160.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle150, Operation.WaterJet5AxisARatioCornerAngle160, 150.0, 160.0, num, ref RatioAFromC);
		}
		if (num > 160.0 && num <= 170.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle160, Operation.WaterJet5AxisARatioCornerAngle170, 160.0, 170.0, num, ref RatioAFromC);
		}
		if (num > 170.0 && num <= 180.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARatioCornerAngle170, Operation.WaterJet5AxisARatioCornerAngle180, 170.0, 180.0, num, ref RatioAFromC);
		}
		if (num > 180.0)
		{
			RatioAFromC = 1.0;
		}
		if (RefAngleA == 0.0)
		{
			RatioAFromA = 1.0;
		}
		if (RefAngleA > 0.0 && RefAngleA <= 1.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA0, Operation.WaterJet5AxisARtForA1, 0.0, 1.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 1.0 && RefAngleA <= 5.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA1, Operation.WaterJet5AxisARtForA5, 1.0, 5.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 5.0 && RefAngleA <= 10.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA5, Operation.WaterJet5AxisARtForA10, 5.0, 10.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 10.0 && RefAngleA <= 20.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA10, Operation.WaterJet5AxisARtForA20, 10.0, 20.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 20.0 && RefAngleA <= 30.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA20, Operation.WaterJet5AxisARtForA30, 20.0, 30.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 30.0 && RefAngleA <= 40.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA30, Operation.WaterJet5AxisARtForA40, 30.0, 40.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 40.0 && RefAngleA <= 45.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA40, Operation.WaterJet5AxisARtForA45, 40.0, 45.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 45.0 && RefAngleA <= 50.0)
		{
			buNumeric.EquationLineer(Operation.WaterJet5AxisARtForA45, Operation.WaterJet5AxisARtForA50, 45.0, 50.0, RefAngleA, ref RatioAFromA);
		}
		if (RefAngleA > 50.0)
		{
			RatioAFromA = Operation.WaterJet5AxisARtForA50;
		}
	}

	public void ReAdjustAngleA(double refAngle, double AngleDiff, marbleOperation Operation, ref List<Pnt6D> Points)
	{
		bool flag = false;
		if (Points.Count >= 2)
		{
			if (!(Points[0].A > Points[1].A))
			{
				AngleDiff = Points[Points.Count - 1].A - Points[0].A;
				refAngle = Points[0].A;
			}
			else
			{
				flag = true;
				AngleDiff = Points[0].A - Points[Points.Count - 1].A;
				refAngle = Points[Points.Count - 1].A;
			}
		}
		if (flag)
		{
			for (int i = 0; i <= Points.Count - 2; i++)
			{
				Pnt6D pnt6D = new Pnt6D(Points[i]);
				if (i == 0)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc10 / 100.0;
				}
				if (i == 1)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc9 / 100.0;
				}
				if (i == 2)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc8 / 100.0;
				}
				if (i == 3)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc7 / 100.0;
				}
				if (i == 4)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc6 / 100.0;
				}
				if (i == 5)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc5 / 100.0;
				}
				if (i == 6)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc4 / 100.0;
				}
				if (i == 7)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc3 / 100.0;
				}
				if (i == 8)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc2 / 100.0;
				}
				if (i == 9)
				{
					pnt6D.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc1 / 100.0;
				}
				Points[i] = new Pnt6D(pnt6D);
			}
			return;
		}
		for (int j = 1; j <= Points.Count - 1; j++)
		{
			Pnt6D pnt6D2 = new Pnt6D(Points[j]);
			if (j == 1)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc1 / 100.0;
			}
			if (j == 2)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc2 / 100.0;
			}
			if (j == 3)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc3 / 100.0;
			}
			if (j == 4)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc4 / 100.0;
			}
			if (j == 5)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc5 / 100.0;
			}
			if (j == 6)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc6 / 100.0;
			}
			if (j == 7)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc7 / 100.0;
			}
			if (j == 8)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc8 / 100.0;
			}
			if (j == 9)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc9 / 100.0;
			}
			if (j == 10)
			{
				pnt6D2.A = refAngle + AngleDiff * Operation.WaterJet5AxisReAdjustAPerc10 / 100.0;
			}
			Points[j] = new Pnt6D(pnt6D2);
		}
	}

	public void CalculateMarbleHoleWithMillingTool(List<eEntities> Holes, KinematicBase Kinematic, ToolBase Tool, marbleCamParameters CamPars, camParameters CamParameter, double AValue, double CValue, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			KinematicItem kinematicItem = new KinematicItem();
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0, 0.0), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 0.0, 1.0), new EntityResolution(), ref Triangles);
			kinematicItem.Axis.A = false;
			kinematicItem.Axis.C = false;
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			int num = Convert.ToInt32((double)Holes.Count / 100.0);
			int num2 = 0;
			if (CamParameter.Hole.HoleType == grindingHoleType.OneTimeToDown)
			{
				for (int i = 0; i <= Holes.Count - 1; i++)
				{
					eEntities copiedEnt = new eEntities();
					eEntities.CopyEntity(Holes[i], ref copiedEnt);
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					Pnt3D pnt3D2 = new Pnt3D(Holes[i].Vertice[0]);
					new OrientationAngle(Holes[i].Orientation);
					Pnt6D pnt6D = new Pnt6D();
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D, CamParameter.Speeds.Rapid, 0, plungemove: true));
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D, CamParameter.Speeds.Rapid, 0, plungemove: false));
					pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
					new Pnt6D(pnt6D);
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D, CamParameter.Speeds.Rapid, 0, plungemove: true));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight), Color.Lime));
					pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.StartHeight);
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.EndHeight), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D, CamParameter.Speeds.Plunge, 1, plungemove: false));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Hole.EndHeight), Color.Lime));
					List<Pnt3D> Vertices = new List<Pnt3D>();
					buAppCalc.cVector.CircleWithCenter(pnt3D2, Tool.Geometry.Diameter / 2.0, new WorkPlane(), buSystem.EntitiesResolution, ref Vertices);
					camPoint.EntitiesMark.Add(new geoPolyline(Vertices, Color.Brown));
					pnt3D = new Pnt3D(pnt3D2);
					new Pnt6D(pnt6D);
					pnt6D = new Pnt6D(new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D, CamParameter.Speeds.Leave, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D2), Color.Red));
					pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, CamParameter.Distances.Safe);
					new Pnt6D(pnt6D);
					if (camPoint.Points.Count > 0)
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
					}
					for (int j = 1; j <= camPoint.Points.Count - 1; j++)
					{
						List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
						double dt = 0.1;
						if (camPoint.Points[j].Type == 0)
						{
							dt = 0.25;
						}
						double num3 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[j - 1]), new Pnt3D(camPoint.Points[j]));
						if (!(num3 > 3.0))
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[j]));
							continue;
						}
						buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[j - 1]), new Pnt6D(camPoint.Points[j]), dt, ref CalculatedPoints);
						CalculatedPoints.RemoveAt(0);
						camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
					}
					calcCam.CamPoints.Add(camPoint);
					if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
					{
						calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)i / (double)(Holes.Count - 1)) * 100.0, 0, "Calculate Marble Hole", ""));
					}
					if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
					{
						Application.DoEvents();
					}
					if (!buSystem.Cancel)
					{
						num2++;
						continue;
					}
					buSystem.Cancel = false;
					buSystem.Canceled = true;
					if (calculationEventHandler_2 != null)
					{
						calculationEventHandler_2(new CalculationEventArg());
					}
					if (calculationEventHandler_3 != null)
					{
						calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
					}
					buLog.addLog("Calculate Marble Hole", "Canceled", MethodBase.GetCurrentMethod().Name);
					return;
				}
			}
			if (CamParameter.Hole.HoleType == grindingHoleType.UpDownByStep)
			{
				for (int k = 0; k <= Holes.Count - 1; k++)
				{
					eEntities copiedEnt2 = new eEntities();
					eEntities.CopyEntity(Holes[k], ref copiedEnt2);
					camPoint = new CamPoint();
					camPoint.Type = 0;
					camPoint.IsRapid = true;
					Pnt3D pnt3D3 = new Pnt3D(Holes[k].Vertice[0]);
					new OrientationAngle(Holes[k].Orientation);
					Pnt6D pnt6D2 = new Pnt6D();
					pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Rapid, 0, plungemove: true));
					pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Rapid, 0, plungemove: false));
					pnt3D = new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe);
					new Pnt6D(pnt6D2);
					double num4 = 0.0;
					Pnt9DCam pnt9DCam = new Pnt9DCam();
					geoLine geoLine2 = new geoLine();
					for (double num5 = CamParameter.Hole.StartHeight - Math.Abs(CamParameter.Hole.DownStep); num5 >= CamParameter.Hole.EndHeight; num5 -= Math.Abs(CamParameter.Hole.DownStep))
					{
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, num5), new OrientationAngle(AValue, 0.0, CValue));
						new Pnt6D(pnt6D2);
						pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 1, plungemove: false);
						camPoint.Points.Add(pnt9DCam);
						geoLine2 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D2), colorPlunge, entThickness);
						camPoint.EntitiesPlunge.Add(geoLine2);
						pnt3D = new Pnt3D(pnt6D2.X, pnt6D2.Y, pnt6D2.Z);
						geoCircle geoCircle2 = new geoCircle(new Pnt3D(pnt6D2), Tool.Geometry.Diameter / 2.0);
						geoCircle2.Color = colorMark;
						camPoint.EntitiesMark.Add(geoCircle2);
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, num5 + CamParameter.Hole.UpStep), new OrientationAngle(AValue, 0.0, CValue));
						new Pnt6D(pnt6D2);
						pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Leave, 1, plungemove: false);
						camPoint.Points.Add(pnt9DCam);
						pnt3D = new Pnt3D(pnt6D2.X, pnt6D2.Y, pnt6D2.Z);
						num4 = num5;
					}
					if (num4 > CamParameter.Hole.EndHeight)
					{
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Hole.EndHeight), new OrientationAngle(AValue, 0.0, CValue));
						new Pnt6D(pnt6D2);
						pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Plunge, 1, plungemove: false);
						camPoint.Points.Add(pnt9DCam);
						geoLine2 = new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt6D2), colorPlunge, entThickness);
						camPoint.EntitiesPlunge.Add(geoLine2);
						pnt3D = new Pnt3D(pnt6D2.X, pnt6D2.Y, pnt6D2.Z);
						geoCircle geoCircle3 = new geoCircle(new Pnt3D(pnt6D2), Tool.Geometry.Diameter / 2.0);
						geoCircle3.Color = colorMark;
						camPoint.EntitiesMark.Add(geoCircle3);
						pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Hole.EndHeight + CamParameter.Hole.UpStep), new OrientationAngle(AValue, 0.0, CValue));
						new Pnt6D(pnt6D2);
						pnt9DCam = new Pnt9DCam(pnt6D2, CamParameter.Speeds.Leave, 1, plungemove: false);
						camPoint.Points.Add(pnt9DCam);
						pnt3D = new Pnt3D(pnt6D2.X, pnt6D2.Y, pnt6D2.Z);
					}
					pnt6D2 = new Pnt6D(new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), new OrientationAngle(AValue, 0.0, CValue));
					camPoint.Points.Add(new Pnt9DCam(pnt6D2, CamParameter.Speeds.Leave, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe), Color.Red));
					pnt3D = new Pnt3D(pnt3D3.X, pnt3D3.Y, CamParameter.Distances.Safe);
					new Pnt6D(pnt6D2);
					if (camPoint.Points.Count > 0)
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
					}
					for (int l = 1; l <= camPoint.Points.Count - 1; l++)
					{
						List<Pnt6D> CalculatedPoints2 = new List<Pnt6D>();
						double dt2 = 0.1;
						if (camPoint.Points[l].Type == 0)
						{
							dt2 = 0.25;
						}
						double num6 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[l - 1]), new Pnt3D(camPoint.Points[l]));
						if (!(num6 > 3.0))
						{
							camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[l]));
							continue;
						}
						buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[l - 1]), new Pnt6D(camPoint.Points[l]), dt2, ref CalculatedPoints2);
						CalculatedPoints2.RemoveAt(0);
						camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints2);
					}
					calcCam.CamPoints.Add(camPoint);
					if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
					{
						calculationEventHandler_0(new CalculationEventArg(50.0, Convert.ToDouble((double)k / (double)(Holes.Count - 1)) * 100.0, 0, "Calculate Marble Hole", ""));
					}
					if (buSystem.DoEventEnable && num > 0 && num2 > 0 && num2 % num == 0)
					{
						Application.DoEvents();
					}
					if (!buSystem.Cancel)
					{
						num2++;
						continue;
					}
					buSystem.Cancel = false;
					buSystem.Canceled = true;
					if (calculationEventHandler_2 != null)
					{
						calculationEventHandler_2(new CalculationEventArg());
					}
					if (calculationEventHandler_3 != null)
					{
						calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
					}
					buLog.addLog("Calculate Marble Hole", "Canceled", MethodBase.GetCurrentMethod().Name);
					return;
				}
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void HatchCamCalculationMarble(camHatch Hatch, camDistances Distances, camSpeeds Velocity, camStep Steps, camStrategy Strategy, KinematicBase Kinematic, ToolBase Tool, EntitiesResolution Resolution, ref camBase calcCam, ref List<eEntities> Entities)
	{
		if (Hatch.CutStep <= 0.0 || Hatch.TotalWidth <= 0.0 || Hatch.CutLength <= 0.0 || Hatch.CutStep > Hatch.TotalWidth)
		{
			return;
		}
		List<List<eEntities>> list = new List<List<eEntities>>();
		Entities.Clear();
		int num = (int)buNumeric.RoundToLower(Hatch.TotalWidth / Hatch.CutStep);
		if (num == 0)
		{
			num = 1;
		}
		double num2 = Hatch.TotalWidth / (double)num;
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			double num3 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			List<eEntities> list2 = new List<eEntities>();
			for (int i = 0; i <= num - 1; i++)
			{
				if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					list2 = new List<eEntities>();
					num3 = (double)i * num2;
					eEntities item = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item);
					list2.Add(item);
					list.Add(list2);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list2 = new List<eEntities>();
					Strategy.OverrideCEnable = true;
					Strategy.OverrideC = 0.0;
					num3 = (double)i * num2;
					eEntities item2 = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					item2 = new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					list.Add(list2);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num3 = (double)i * num2;
					eEntities eEntities2 = null;
					if (Entities.Count > 0)
					{
						eEntities2 = new eLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D.X, num3, Hatch.OperationZ));
						Entities.Add(eEntities2);
						list2.Add(eEntities2);
					}
					if (i % 2 == 0)
					{
						eEntities2 = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					}
					if (i % 2 == 1)
					{
						eEntities2 = new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					}
					Entities.Add(eEntities2);
					list2.Add(eEntities2);
					pnt3D = new Pnt3D(eEntities2.Vertice[eEntities2.Vertice.Count - 1]);
				}
			}
			if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				Strategy.AngleLimit = 20.0;
				list.Add(list2);
			}
		}
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
		{
			double num4 = 0.0;
			Pnt3D pnt3D2 = new Pnt3D();
			List<eEntities> list3 = new List<eEntities>();
			for (int j = 0; j <= num - 1; j++)
			{
				if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					list3 = new List<eEntities>();
					num4 = (double)j * num2;
					eEntities item3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					Entities.Add(item3);
					list3.Add(item3);
					list.Add(list3);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list3 = new List<eEntities>();
					Strategy.OverrideCEnable = true;
					Strategy.OverrideC = 90.0;
					num4 = (double)j * num2;
					eEntities item4 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					item4 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					list.Add(list3);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num4 = (double)j * num2;
					eEntities eEntities3 = null;
					if (Entities.Count > 0)
					{
						eEntities3 = new eLine(new Pnt3D(pnt3D2), new Pnt3D(num4, pnt3D2.Y, Hatch.OperationZ));
						Entities.Add(eEntities3);
						list3.Add(eEntities3);
					}
					if (j % 2 == 0)
					{
						eEntities3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					}
					if (j % 2 == 1)
					{
						eEntities3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ));
					}
					Entities.Add(eEntities3);
					list3.Add(eEntities3);
					pnt3D2 = new Pnt3D(eEntities3.Vertice[eEntities3.Vertice.Count - 1]);
				}
			}
			if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				Strategy.AngleLimit = 20.0;
				list.Add(list3);
			}
		}
		marbleOperation marbleOperation2 = new marbleOperation();
		marbleOperation2.TargetZ = Hatch.OperationZ;
		new camParameters(Distances, Velocity, Steps, new camOffset(), new camOperation(), new camOptions(), Strategy, new camPocket(), new LeadIn(), new LeadOut(), new camHole(), new camMaterial(), new camHatch());
		CalculateMarbleWireFrameWithMillingAndWaterJetTool3Ax(list, Kinematic, Tool, WaterJetMode: false, new camParameters(Distances, Velocity, Steps, new camOffset(), new camOperation(), new camOptions(), Strategy, new camPocket(), new LeadIn(), new LeadOut(), new camHole(), new camMaterial(), new camHatch()), 0.0, 0.0, "", "", "", "", "", "", "", Resolution, ref calcCam);
	}

	public int PunchWithTwoPoint(double Start, double End, double Offset, double ToolWidth, double ToolUsePersentage, punchParameters Par, ref List<double> calcPoints)
	{
		double num = Math.Abs(End - Start);
		double num2 = ToolUsePersentage;
		double num3 = ToolWidth;
		calcPoints = new List<double>();
		num2 = ((ToolUsePersentage > 1.0) ? (ToolUsePersentage / 100.0) : ToolUsePersentage);
		num3 = ToolWidth * num2;
		if (!(Math.Round(num, 3) > Math.Round(ToolWidth, 3)) || Par.Options.IfToolWidthBiggerThanPunchLengthMakeOperation)
		{
			int num4 = Convert.ToInt32(buNumeric.RoundToUpper(Math.Round(num / ToolWidth, 3)));
			if (End > Start)
			{
				if (num4 == 1)
				{
					double item = Start + Offset + ToolWidth / 2.0;
					calcPoints.Add(item);
				}
				if (num4 > 1)
				{
					double num5 = 0.0;
					double num6 = num;
					for (int i = 0; i <= num4; i++)
					{
						if (num6 > 0.0)
						{
							if (!(num6 > ToolWidth))
							{
								double item2 = End + Offset - ToolWidth / 2.0;
								calcPoints.Add(item2);
								num6 = 0.0;
							}
							else
							{
								double item3 = Start + Offset + num5 + num3 / 2.0;
								calcPoints.Add(item3);
								num5 += num3;
								num6 -= num3;
							}
						}
					}
				}
			}
			if (Start > End)
			{
				if (num4 == 1)
				{
					double item4 = Start + Offset - ToolWidth / 2.0;
					calcPoints.Add(item4);
				}
				if (num4 > 1)
				{
					double num7 = 0.0;
					double num8 = num;
					for (int j = 0; j <= num4; j++)
					{
						if (num8 > 0.0)
						{
							if (!(num8 > ToolWidth))
							{
								double item5 = End + Offset + ToolWidth / 2.0;
								calcPoints.Add(item5);
								num8 = 0.0;
							}
							else
							{
								double item6 = Start + Offset - num7 - num3 / 2.0;
								calcPoints.Add(item6);
								num7 += num3;
								num8 -= num3;
							}
						}
					}
				}
			}
			return 1;
		}
		buString.MessageBoxError(AppLanguage.CadCamMessages[42]);
		return -1;
	}

	public int ProfileOperationTopPlaneCalc(ref ProfileOperation P, ref List<eEntities> CadEntities, ref camBase CamCalc, actionTypeBU Action, ToolBase Tool, WorkPlane Plane, ProfileOperationData OperationData, camParameters camParMilling, ProfileTempData TempData, int LayerIndex, ProfileItem Profile)
	{
		try
		{
			new List<Pnt3D>();
			double num = 1.0;
			new List<List<Pnt3D>>();
			List<double> list = new List<double>();
			CamCalc = new camBase();
			ToolBase toolBase = new ToolBase(Tool);
			CamPoint camPoint = new CamPoint();
			CamZHeightType camZHeightType = CamZHeightType.Contour;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			double num7 = 0.0;
			double num8 = 0.0;
			double num9 = 0.0;
			Pnt9D pnt = new Pnt9D();
			Pnt3D pnt3D = new Pnt3D();
			eEntities eEntities2 = new eEntities();
			List<eEntities> BaseRefEntities = new List<eEntities>();
			Pnt3D pnt3D2 = new Pnt3D();
			num4 = camParMilling.Speeds.Feed;
			num6 = camParMilling.Speeds.Finish;
			num5 = camParMilling.Speeds.AreaClearance;
			num7 = camParMilling.Speeds.Plunge;
			if (!camParMilling.Speeds.FeedEnable)
			{
				num4 = Tool.CamData.FeedSpeed;
			}
			if (!camParMilling.Speeds.PlungeEnable)
			{
				num7 = Tool.CamData.PlungeSpeed;
			}
			if (!camParMilling.Speeds.AreaClearanceEnable)
			{
				num5 = Tool.CamData.AreaClearanceSpeed;
			}
			if (!camParMilling.Speeds.FinishEnable)
			{
				num6 = Tool.CamData.FinishSpeed;
			}
			if (camParMilling.Operations.AreaClearanceEnable)
			{
				camZHeightType = CamZHeightType.AreaClearance;
				num4 = num5;
			}
			if (Action == actionTypeBU.profileCircle)
			{
				P = new ProfileOperationCircle();
				((ProfileOperationCircle)P).Diameter = OperationData.CircleData.CircleDiameter;
				P.Name = "Circle";
				list.Add(OperationData.CircleData.CircleDiameter / 2.0);
				if (camParMilling.Operations.FinishEnable)
				{
					list.Add(OperationData.CircleData.CircleDiameter / 2.0);
				}
				if (camParMilling.Operations.AreaClearanceEnable)
				{
					int num10 = Convert.ToInt32(buNumeric.RoundToUpper(OperationData.CircleData.CircleDiameter / toolBase.Geometry.Diameter));
					for (int i = 0; i <= num10; i++)
					{
						double num11 = OperationData.CircleData.CircleDiameter / 2.0 - toolBase.Geometry.Diameter / 2.0 * (double)(i + 1);
						if (num11 > 0.0)
						{
							list.Add(num11);
						}
					}
				}
				if ((camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut) & camParMilling.Operations.AreaClearanceEnable)
				{
					list.Reverse();
				}
				pnt3D = new Pnt3D(OperationData.Position.X, OperationData.Position.Y, 0.0);
			}
			if (Action == actionTypeBU.profileRectangle)
			{
				P = new ProfileOperationRectangle();
				((ProfileOperationRectangle)P).Width = OperationData.RectangleData.RectangleWidth;
				((ProfileOperationRectangle)P).Height = OperationData.RectangleData.RectangleHeight;
				((ProfileOperationRectangle)P).Angle = OperationData.RectangleData.RectangleAngle;
				P.Name = "Rectangle";
			}
			if (Action == actionTypeBU.profileRoundRectangle)
			{
				P = new ProfileOperationRoundRectangle();
				((ProfileOperationRoundRectangle)P).Width = OperationData.RectangleRoundData.RoundRectangleWidth;
				((ProfileOperationRoundRectangle)P).Height = OperationData.RectangleRoundData.RoundRectangleHeight;
				((ProfileOperationRoundRectangle)P).Angle = OperationData.RectangleRoundData.RoundRectangleAngle;
				((ProfileOperationRoundRectangle)P).Radius = OperationData.RectangleRoundData.RoundRectangleRadius;
				P.Name = "Round Rectangle";
			}
			if (Action == actionTypeBU.profileSlot)
			{
				P = new ProfileOperationSlot();
				((ProfileOperationSlot)P).Width = OperationData.SlotData.SlotWidth;
				((ProfileOperationSlot)P).Diameter = OperationData.SlotData.SlotDiameter;
				((ProfileOperationSlot)P).Angle = OperationData.SlotData.SlotAngle;
				P.Name = "Slot";
			}
			if (Action == actionTypeBU.profileCut)
			{
				P = new ProfileOperationCut();
				((ProfileOperationCut)P).CutWidth = OperationData.CutData.CutWidth;
				((ProfileOperationCut)P).CutHeight = OperationData.CutData.CutHeigth;
				((ProfileOperationCut)P).Angle = OperationData.CutData.CutAngle;
				P.Name = "Cut";
			}
			if (Action == actionTypeBU.profileBarrel)
			{
				P = new ProfileOperationBarrel();
				((ProfileOperationBarrel)P).Diameter = OperationData.BarelData.BarrelDiameter;
				((ProfileOperationBarrel)P).Width = OperationData.BarelData.BarrelWidth;
				((ProfileOperationBarrel)P).Length = OperationData.BarelData.BarrelLength;
				((ProfileOperationBarrel)P).Angle = OperationData.BarelData.BarrelAngle;
				P.Name = "Barrel";
			}
			if (Action == actionTypeBU.profileEllipse)
			{
				P = new ProfileOperationEllipse();
				((ProfileOperationEllipse)P).Width = OperationData.EllipseData.EllipseWidth;
				((ProfileOperationEllipse)P).Height = OperationData.EllipseData.EllipseHeight;
				((ProfileOperationEllipse)P).Angle = OperationData.EllipseData.EllipseAngle;
				P.Name = "Ellipse";
			}
			if (Action == actionTypeBU.profileHole)
			{
				P = new ProfileOperationHole();
				((ProfileOperationHole)P).Diameter = toolBase.Geometry.Diameter;
				P.Name = "Hole";
			}
			if (Action == actionTypeBU.profileNotch)
			{
				P = new ProfileOperationNotch();
				((ProfileOperationNotch)P).Width = OperationData.NotchData.NotchLWidth;
				((ProfileOperationNotch)P).Height = OperationData.NotchData.NotchLHeight;
				((ProfileOperationNotch)P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
				((ProfileOperationNotch)P).Depth = OperationData.NotchData.NotchLDepth;
				P.Name = "Notch";
			}
			if (Action == actionTypeBU.profileFreeDraw)
			{
				P = new ProfileOperationFreeDraw();
				((ProfileOperationFreeDraw)P).Width = OperationData.FreeDrawData.FreeDrawWidth;
				((ProfileOperationFreeDraw)P).Height = OperationData.FreeDrawData.FreeDrawHeight;
				((ProfileOperationFreeDraw)P).Angle = OperationData.FreeDrawData.FreeDrawAngle;
				P.Name = "Free Draw";
			}
			if (Action == actionTypeBU.profileFromSelection)
			{
				Pnt3D MinPoint = new Pnt3D();
				Pnt3D MaxPoint = new Pnt3D();
				double num12 = 0.0;
				double num13 = 0.0;
				buAppCalc.cVector.BoxSizeCalculate(TempData.ScaledEntitiesPoints, ref MinPoint, ref MaxPoint);
				num12 = MaxPoint.X - MinPoint.X;
				num13 = MaxPoint.Y - MinPoint.Y;
				P = new ProfileOperationFreeDraw();
				((ProfileOperationFreeDraw)P).Width = num12;
				((ProfileOperationFreeDraw)P).Height = num13;
				((ProfileOperationFreeDraw)P).Angle = 0.0;
				P.Name = "Free Draw";
			}
			if (Action == actionTypeBU.profileText)
			{
				P = new ProfileOperationText();
				((ProfileOperationText)P).Width = OperationData.TextData.TextWidth;
				((ProfileOperationText)P).Height = OperationData.TextData.TextHeight;
				((ProfileOperationText)P).Angle = OperationData.TextData.TextAngle;
				((ProfileOperationText)P).Text = OperationData.TextData.TextString;
				((ProfileOperationText)P).TextFont = new Font(OperationData.TextData.TextFont.FontFamily, OperationData.TextData.TextFont.Size, OperationData.TextData.TextFont.Style);
				P.Name = "Text";
			}
			P.Action = Action;
			num2 = camParMilling.Distances.Safe;
			num3 = camParMilling.Distances.FirstApproach;
			num8 = camParMilling.Distances.FirstApproach;
			num9 = camParMilling.Distances.Safe;
			if (OperationData.PlaneSelectedName == planeNames.Top)
			{
				num2 = camParMilling.Distances.Safe + Profile.Height;
				num3 = camParMilling.Distances.FirstApproach + Profile.Height;
				num8 = camParMilling.Distances.FirstApproach;
				num9 = camParMilling.Distances.Safe;
			}
			if (OperationData.PlaneSelectedName == planeNames.Left)
			{
				num2 = camParMilling.Distances.LeftSafe;
				num3 = camParMilling.Distances.LeftFirstApproach;
				num8 = camParMilling.Distances.LeftFirstApproach;
				num9 = camParMilling.Distances.LeftSafe;
			}
			if (OperationData.PlaneSelectedName == planeNames.Right)
			{
				num2 = 0.0 - Profile.Width - camParMilling.Distances.RightSafe;
				num3 = 0.0 - Profile.Width - camParMilling.Distances.RightFirstApproach;
				num8 = camParMilling.Distances.RightFirstApproach;
				num9 = camParMilling.Distances.RightSafe;
			}
			List<camZHeight> RefList = new List<camZHeight>();
			for (int j = 0; j <= OperationData.DepthSelectedValues.Count - 1; j++)
			{
				if (camParMilling.Steps.Enable)
				{
					_ = Convert.ToDouble(camParMilling.Steps.Count) * camParMilling.Steps.Step;
					int count = camParMilling.Steps.Count;
					List<double> CalcValues = new List<double>();
					camStep steps = new camStep(enable: true, OperationData.DepthSelectedValues[j].Position, 0.0, OperationData.DepthSelectedValues[j].Depth, 0, camParMilling.Steps.Step, CamStepType.StartToDistanceByTrueStep);
					buAppCalc.cVector.CamStepCalculation(steps, ref CalcValues);
					for (int k = 0; k <= CalcValues.Count - 1; k++)
					{
						double num14 = Math.Round(OperationData.DepthSelectedValues[j].Depth / (double)count * (double)k, 5);
						num14 = CalcValues[k];
						camZHeight camZHeight2 = new camZHeight();
						if ((OperationData.PlaneSelectedName == planeNames.Top) | (OperationData.PlaneSelectedName == planeNames.Left))
						{
							camZHeight2.Depth = Math.Round(num14, 5);
						}
						if ((OperationData.PlaneSelectedName == planeNames.Right) | (OperationData.PlaneSelectedName == planeNames.Left))
						{
							camZHeight2.Depth = Math.Round(num14, 5);
						}
						if (OperationData.PlaneSelectedName == planeNames.Free)
						{
							camZHeight2.Depth = Math.Round(num14, 5);
						}
						camZHeight2.Type = CamZHeightType.Contour;
						if (camParMilling.Operations.FinishEnable)
						{
							camZHeight2.Type = CamZHeightType.Finish;
						}
						if (camParMilling.Operations.AreaClearanceEnable)
						{
							camZHeight2.Type = CamZHeightType.AreaClearance;
						}
						if (k == CalcValues.Count - 1)
						{
							camZHeight2.FinalStep = true;
						}
						RefList.Add(camZHeight2);
					}
				}
				else
				{
					camZHeight camZHeight3 = new camZHeight();
					camZHeight3.Depth = OperationData.DepthSelectedValues[j].Position + OperationData.DepthSelectedValues[j].Depth;
					camZHeight3.Type = CamZHeightType.Contour;
					camZHeight3.FinalStep = true;
					if (camParMilling.Operations.FinishEnable)
					{
						camZHeight3.Type = CamZHeightType.Finish;
					}
					if (camParMilling.Operations.AreaClearanceEnable)
					{
						camZHeight3.Type = CamZHeightType.AreaClearance;
					}
					if (!((OperationData.PlaneSelectedName == planeNames.Left) | (OperationData.PlaneSelectedName == planeNames.Right)))
					{
						RefList.Add(camZHeight3);
					}
					else if (OperationData.YDirection != ProfileYAxisDirection.PositiveDirection)
					{
						RefList.Add(camZHeight3);
					}
					else
					{
						RefList.Add(camZHeight3);
					}
				}
			}
			if (((OperationData.PlaneSelectedName == planeNames.Top) | (OperationData.PlaneSelectedName == planeNames.Left)) && RefList.Count > 0)
			{
				buAppCalc.cVector.SortList(SortDirectionType.Bigger, ref RefList);
			}
			List<Pnt3D> Points = new List<Pnt3D>();
			List<List<Pnt3D>> list2 = new List<List<Pnt3D>>();
			if ((Action == actionTypeBU.profileCircle) & ((OperationData.PlaneSelectedName == planeNames.Free) | camParMilling.Strategy.ArcToPoints))
			{
				pnt3D = new Pnt3D(pnt3D2);
				eCircle refEntity = new eCircle(pnt3D, ((ProfileOperationCircle)P).Diameter / 2.0, new WorkPlane(), (float)num, toolBase.Display.CamColor);
				buAppCalc.cVector.EntitiesToPoint(refEntity, EntityDevideResolution, ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileRectangle)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.RectangleAngleWithCenter(pnt3D, ((ProfileOperationRectangle)P).Width, ((ProfileOperationRectangle)P).Height, ((ProfileOperationRectangle)P).Angle, new WorkPlane(), ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileRoundRectangle)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.RectangleFillet(pnt3D, ((ProfileOperationRoundRectangle)P).Width, ((ProfileOperationRoundRectangle)P).Height, ((ProfileOperationRoundRectangle)P).Radius, ((ProfileOperationRoundRectangle)P).Angle, new WorkPlane(), ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileSlot)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.RectangleFillet(pnt3D, ((ProfileOperationSlot)P).Width, ((ProfileOperationSlot)P).Diameter, ((ProfileOperationSlot)P).Diameter / 2.0, ((ProfileOperationSlot)P).Angle, new WorkPlane(), ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				if (Tool.Geometry.Diameter >= ((ProfileOperationSlot)P).Diameter)
				{
					Points.Clear();
					Pnt3D StartPoint = new Pnt3D();
					Pnt3D EndPoint = new Pnt3D();
					buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(pnt3D, ((ProfileOperationSlot)P).Width / 2.0 - ((ProfileOperationSlot)P).Diameter / 2.0, ((ProfileOperationSlot)P).Angle, new WorkPlane(), ref StartPoint, ref EndPoint);
					Points.Add(StartPoint);
					Points.Add(EndPoint);
				}
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileCut)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.RectangleAngleWithCenter(pnt3D, ((ProfileOperationCut)P).CutWidth, ((ProfileOperationCut)P).CutHeight, ((ProfileOperationCut)P).Angle, new WorkPlane(), ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				if (Tool.Geometry.Diameter >= ((ProfileOperationCut)P).CutWidth)
				{
					Points.Clear();
					Pnt3D StartPoint2 = new Pnt3D();
					Pnt3D EndPoint2 = new Pnt3D();
					buAppCalc.cVector.LineWithCenterPointByLengthAndAngle(pnt3D, ((ProfileOperationCut)P).CutWidth / 2.0 - ((ProfileOperationCut)P).CutHeight / 2.0, ((ProfileOperationCut)P).Angle + 90.0, new WorkPlane(), ref StartPoint2, ref EndPoint2);
					Points.Add(StartPoint2);
					Points.Add(EndPoint2);
				}
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileBarrel)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.Barrel(pnt3D, ((ProfileOperationBarrel)P).Diameter / 2.0, ((ProfileOperationBarrel)P).Width / 2.0, ((ProfileOperationBarrel)P).Length, ((ProfileOperationBarrel)P).Angle, Reverse: false, new WorkPlane(), buSystem.EntitiesResolution, ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileEllipse)
			{
				pnt3D = new Pnt3D(pnt3D2);
				buAppCalc.cVector.EllipseWithCenter(pnt3D, ((ProfileOperationEllipse)P).Width, ((ProfileOperationEllipse)P).Height, ((ProfileOperationEllipse)P).Angle, new WorkPlane(), buSystem.EntitiesResolution, ref Points);
				eEntities2 = new ePolyline(Points);
				eEntities2.LayerIndex = LayerIndex;
				BaseRefEntities.Add(eEntities2);
				list2.Add(Points);
			}
			if (Action == actionTypeBU.profileHole)
			{
				if (OperationData.PlaneSelectedName == planeNames.Free)
				{
					pnt3D = new Pnt3D(pnt3D2);
					eCircle refEntity2 = new eCircle(pnt3D, OperationData.HoleData.HoleDiameter / 2.0, new WorkPlane(), (float)num, toolBase.Display.CamColor);
					buAppCalc.cVector.EntitiesToPoint(refEntity2, EntityDevideResolution, ref Points);
					eEntities2 = new ePolyline(Points);
					eEntities2.LayerIndex = LayerIndex;
					BaseRefEntities.Add(eEntities2);
					List<Pnt3D> list3 = new List<Pnt3D>();
					list3.Add(new Pnt3D(pnt3D));
					list2.Add(list3);
					Points = new List<Pnt3D>();
				}
				else
				{
					pnt3D = new Pnt3D(pnt3D2);
					List<Pnt3D> list4 = new List<Pnt3D>();
					list4.Add(new Pnt3D(pnt3D));
					list2.Add(list4);
					eEntities2 = new eCircle(pnt3D, OperationData.HoleData.HoleDiameter / 2.0, new WorkPlane());
					eEntities2.LayerIndex = LayerIndex;
					BaseRefEntities.Add(eEntities2);
				}
			}
			if (Action == actionTypeBU.profileFreeDraw)
			{
				for (int l = 0; l <= TempData.SortedAndScaledAndRotatedEntitiesPointsList.Count - 1; l++)
				{
					Points = new List<Pnt3D>();
					for (int m = 0; m <= TempData.SortedAndScaledAndRotatedEntitiesPointsList[l].Count - 1; m++)
					{
						Pnt3D item = new Pnt3D(TempData.SortedAndScaledAndRotatedEntitiesPointsList[l][m].X, TempData.SortedAndScaledAndRotatedEntitiesPointsList[l][m].Y, TempData.SortedAndScaledAndRotatedEntitiesPointsList[l][m].Z);
						Points.Add(item);
					}
					if (!buAppCalc.cVector.IsClosed(Points))
					{
						eEntities2 = new ePolyline(Points);
						eEntities2.LayerIndex = LayerIndex;
						BaseRefEntities.Add(eEntities2);
					}
					else
					{
						eEntities2 = new ePolyline(Points);
						eEntities2.LayerIndex = LayerIndex;
						BaseRefEntities.Add(eEntities2);
					}
					list2.Add(Points);
				}
			}
			if (Action == actionTypeBU.profileText)
			{
				for (int n = 0; n <= TempData.SortedAndScaledAndRotatedEntitiesPointsList.Count - 1; n++)
				{
					Points = new List<Pnt3D>();
					for (int num15 = 0; num15 <= TempData.SortedAndScaledAndRotatedEntitiesPointsList[n].Count - 1; num15++)
					{
						Pnt3D item2 = new Pnt3D(TempData.SortedAndScaledAndRotatedEntitiesPointsList[n][num15].X, TempData.SortedAndScaledAndRotatedEntitiesPointsList[n][num15].Y, TempData.SortedAndScaledAndRotatedEntitiesPointsList[n][num15].Z);
						Points.Add(item2);
					}
					buAppCalc.cVector.IsClosed(Points);
					eEntities2 = new ePolyline(Points);
					eEntities2.LayerIndex = LayerIndex;
					BaseRefEntities.Add(eEntities2);
					List<Pnt3D> CopiedPnt = new List<Pnt3D>();
					Pnt3D.Copy(Points, ref CopiedPnt);
					list2.Add(CopiedPnt);
					Points.Clear();
				}
			}
			if (camParMilling.Offsets.ClosedContour == CamClosedContourType.Center)
			{
				camParMilling.Operations.MakeCenterOffset = true;
			}
			if (RefList.Count == 0)
			{
				camZHeight camZHeight4 = new camZHeight();
				camZHeight4.Depth = 0.0;
				camZHeight4.Type = CamZHeightType.Contour;
				RefList.Add(camZHeight4);
			}
			List<eEntities> SortedEntities = new List<eEntities>();
			List<List<eEntities>> SplitedEntitites = new List<List<eEntities>>();
			buAppCalc.cSort.SortEntitiesByRefPoint(new Pnt3D(), ref BaseRefEntities, new SortingOptions(), ref SortedEntities);
			buAppCalc.cVector.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			if (RefList.Count <= 0)
			{
				for (int num16 = 0; num16 <= SplitedEntitites.Count - 1; num16++)
				{
					List<eEntities> list5 = new List<eEntities>();
					for (int num17 = 0; num17 <= SplitedEntitites[num16].Count - 1; num17++)
					{
						eEntities copiedEnt = new eEntities();
						eEntities.CopyEntity(SplitedEntitites[num16][num17], ref copiedEnt);
						list5.Add(eEntities.CopyEntity(copiedEnt));
						CadEntities.Add(eEntities.CopyEntity(copiedEnt));
					}
					if (list5.Count > 0)
					{
						P.Entities.Add(list5);
					}
				}
			}
			else
			{
				for (int num18 = 0; num18 <= RefList.Count - 1; num18++)
				{
					Pnt3D MinPoint2 = new Pnt3D();
					Pnt3D MaxPoint2 = new Pnt3D();
					buAppCalc.cVector.BoxSizeCalculate(BaseRefEntities, ref MinPoint2, ref MaxPoint2);
					for (int num19 = 0; num19 <= SplitedEntitites.Count - 1; num19++)
					{
						List<eEntities> list6 = new List<eEntities>();
						for (int num20 = 0; num20 <= SplitedEntitites[num19].Count - 1; num20++)
						{
							eEntities copiedEnt2 = new eEntities();
							eEntities.CopyEntity(SplitedEntitites[num19][num20], ref copiedEnt2);
							buAppCalc.cVector.Move(new Pnt3D(0.0, 0.0, MinPoint2.Z), new Pnt3D(0.0, 0.0, RefList[num18].Depth), ref copiedEnt2);
							list6.Add(eEntities.CopyEntity(copiedEnt2));
							CadEntities.Add(eEntities.CopyEntity(copiedEnt2));
						}
						if (list6.Count > 0)
						{
							P.Entities.Add(list6);
						}
					}
				}
			}
			CamCalc.Name = "Profile -" + P.Name;
			Pnt9DCam pnt9DCam = new Pnt9DCam();
			Pnt3D pnt3D3 = new Pnt3D();
			Pnt3D refP = new Pnt3D();
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = true;
			if ((Action == actionTypeBU.profileCircle) & ((OperationData.PlaneSelectedName != planeNames.Free) & !camParMilling.Strategy.ArcToPoints))
			{
				for (int num21 = 0; num21 <= RefList.Count - 1; num21++)
				{
					camPoint = new CamPoint();
					camPoint.GCodeOffset = new Pnt9D(pnt);
					pnt3D = new Pnt3D(pnt3D2.X, pnt3D2.Y, RefList[num21].Depth);
					eCircle eCircle2 = new eCircle(pnt3D, ((ProfileOperationCircle)P).Diameter / 2.0, new WorkPlane(), (float)num, toolBase.Display.CamColor);
					eCircle2.LayerIndex = LayerIndex;
					List<eEntities> list7 = new List<eEntities>();
					list7.Add(new eCircle(eCircle2));
					P.Entities.Add(list7);
					CadEntities.Add(new eCircle(eCircle2));
					if ((camParMilling.Operations.Direction == ClockDirectionType.CCW) | (camParMilling.Operations.Direction == ClockDirectionType.CW))
					{
						if (num21 == 0)
						{
							pnt9DCam = new Pnt9DCam(new Pnt6D(eCircle2.CenterPoint.X + eCircle2.Radius - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, num2), camParMilling.Speeds.Rapid, 0);
							pnt9DCam.PlungeAction = CamPlungeActionType.GoUpFirstPoint;
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.PlungeAxisMovement = true;
							pnt9DCam.PlungeValue = num9;
							pnt9DCam.Feed = camParMilling.Speeds.Rapid;
							camPoint.Points.Add(pnt9DCam);
							pnt9DCam = new Pnt9DCam(new Pnt6D(eCircle2.CenterPoint.X + eCircle2.Radius - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, num2), camParMilling.Speeds.Rapid, 0);
							geoLine geoLine2 = new geoLine(new Pnt3D(pnt9DCam.P9.X, pnt9DCam.P9.Y, num2), new Pnt3D(pnt9DCam.P9.X, pnt9DCam.P9.Y, RefList[num21].Depth), -1);
							geoLine2.Color = Tool.Display.PlungeColor;
							geoLine2.Thickness = num;
							pnt9DCam.Type = 0;
							pnt9DCam.Feed = camParMilling.Speeds.Rapid;
							camPoint.Points.Add(pnt9DCam);
						}
						if ((camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut) & camParMilling.Operations.AreaClearanceEnable)
						{
							list.Reverse();
						}
						for (int num22 = 0; num22 <= list.Count - 1; num22++)
						{
							if (num22 == 0)
							{
								pnt9DCam = new Pnt9DCam();
								pnt9DCam.P9 = new Pnt9D(new Pnt3D(eCircle2.CenterPoint.X + list[num22] - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, eCircle2.CenterPoint.Z));
								pnt9DCam.Type = 1;
								pnt9DCam.Feed = num7;
								camPoint.Points.Add(pnt9DCam);
							}
							if (num22 > 0)
							{
								pnt9DCam = new Pnt9DCam();
								pnt9DCam.P9 = new Pnt9D(new Pnt3D(eCircle2.CenterPoint.X + list[num22] - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, eCircle2.CenterPoint.Z));
								pnt9DCam.Type = 1;
								pnt9DCam.Feed = num4;
								camPoint.Points.Add(pnt9DCam);
								geoLine geoLine3 = new geoLine(pnt3D3, new Pnt3D(eCircle2.CenterPoint.X + list[num22] - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, eCircle2.CenterPoint.Z));
								geoLine3.Color = OperationData.CircleData.CircleColor;
								geoLine3.Thickness = OperationData.CircleData.CircleThickness;
							}
							pnt9DCam = new Pnt9DCam();
							pnt9DCam.P9 = new Pnt9D(new Pnt3D(eCircle2.CenterPoint.X - list[num22] + toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, eCircle2.CenterPoint.Z));
							pnt9DCam.ArcData = new geoArc(eCircle2.CenterPoint, list[num22], 0.0, 180.0);
							if (camParMilling.Operations.Direction == ClockDirectionType.CW)
							{
								pnt9DCam.Type = 2;
							}
							if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
							{
								pnt9DCam.Type = 3;
							}
							pnt9DCam.Feed = num4;
							pnt9DCam.IsArc = true;
							camPoint.Points.Add(pnt9DCam);
							pnt9DCam = new Pnt9DCam();
							pnt9DCam.P9 = new Pnt9D(new Pnt3D(eCircle2.CenterPoint.X + list[num22] - toolBase.Geometry.Diameter / 2.0, eCircle2.CenterPoint.Y, eCircle2.CenterPoint.Z));
							pnt9DCam.ArcData = new geoArc(eCircle2.CenterPoint, list[num22], 180.0, 360.0);
							if (camParMilling.Operations.Direction == ClockDirectionType.CW)
							{
								pnt9DCam.Type = 2;
							}
							if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
							{
								pnt9DCam.Type = 3;
							}
							pnt9DCam.IsArc = true;
							pnt9DCam.Feed = num4;
							camPoint.Points.Add(pnt9DCam);
							pnt3D3 = new Pnt3D(pnt9DCam.P9);
							geoCircle geoCircle2 = new geoCircle(eCircle2.CenterPoint, list[num22] - toolBase.Geometry.Diameter / 2.0, new WorkPlane());
							geoCircle2.Color = OperationData.CircleData.CircleColor;
							geoCircle2.Thickness = OperationData.CircleData.CircleThickness;
							camPoint.EntitiesG1.Add(geoCircle2);
							if (camParMilling.Operations.Direction == ClockDirectionType.CCW)
							{
								SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
							}
							if (camParMilling.Operations.Direction == ClockDirectionType.CW)
							{
								List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
								Pnt3D.Copy(geoCircle2.Vertice, ref CopiedPnt2);
								CopiedPnt2.Reverse();
								SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
							}
						}
					}
					if (num21 == RefList.Count - 1)
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(0.0, 0.0, num2), camParMilling.Speeds.Rapid, 0);
						pnt9DCam.PlungeAction = CamPlungeActionType.GoUpLastPoint;
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						pnt9DCam.PlungeValue = num9;
						geoLine geoLine4 = new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D3.X, pnt3D3.Y, num2), -1);
						geoLine4.Color = Tool.Display.LeaveColor;
						geoLine4.Thickness = num;
						camPoint.EntitiesG0.Add(geoLine4);
						pnt9DCam.PlungeAxisMovement = true;
						camPoint.Points.Add(pnt9DCam);
					}
					CamCalc.CamPoints.Add(camPoint);
					CamCalc.Tool = new ToolBase(toolBase);
				}
			}
			for (int num23 = 0; num23 <= list2.Count - 1; num23++)
			{
				camPoint = new CamPoint();
				flag2 = false;
				if (num23 < list2.Count - 1)
				{
					List<List<Pnt3D>> pntCalculated = new List<List<Pnt3D>>();
					ProfileContourOffsets(list2[num23 + 1], 0.0, camParMilling, toolBase, camZHeightType, ref pntCalculated);
					if (pntCalculated.Count > 0 && pntCalculated[0].Count > 0)
					{
						flag2 = true;
						refP = new Pnt3D(pntCalculated[0][0]);
					}
				}
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				Pnt3D.Copy(list2[num23], ref CopiedPnt3);
				for (int num24 = 0; num24 <= RefList.Count - 1; num24++)
				{
					List<List<Pnt3D>> pntCalculated2 = new List<List<Pnt3D>>();
					double extraOffset = 0.0;
					if (camParMilling.Operations.FinishEnable && camParMilling.Steps.Enable && !RefList[num24].FinalStep)
					{
						extraOffset = camParMilling.Offsets.FinishOffset;
					}
					bool flag5 = buAppCalc.cVector.IsClosed(list2[num23]);
					ProfileContourOffsets(list2[num23], extraOffset, camParMilling, toolBase, camZHeightType, ref pntCalculated2);
					if ((!flag5 & camParMilling.Strategy.OpenContourTwoDirectionCut) && num24 % 2 == 1)
					{
						for (int num25 = 0; num25 <= pntCalculated2.Count - 1; num25++)
						{
							pntCalculated2[num25].Reverse();
						}
					}
					_ = RefList[num24].Type;
					camPoint.GCodeOffset = new Pnt9D(pnt);
					for (int num26 = 0; num26 <= pntCalculated2.Count - 1; num26++)
					{
						List<Pnt3D> list8 = new List<Pnt3D>();
						for (int num27 = 0; num27 <= pntCalculated2[num26].Count - 1; num27++)
						{
							Pnt3D item3 = new Pnt3D(pntCalculated2[num26][num27].X, pntCalculated2[num26][num27].Y, RefList[num24].Depth);
							list8.Add(item3);
						}
						bool flag6 = buAppCalc.cVector.IsClosed(list8);
						ClockDirectionType clockDirectionType = ClockDirectionType.CW;
						if (flag6 && flag4)
						{
							clockDirectionType = buAppCalc.cVector.PolygonDirection(list8, Plane);
							if (clockDirectionType != camParMilling.Operations.Direction)
							{
								list8.Reverse();
							}
						}
						if (((num23 == 0 && num24 > 0) || num23 > 0) && !Pnt3D.EqualXY(pnt3D3, pntCalculated2[num26][0]))
						{
							flag3 = true;
						}
						if ((num23 == 0 && num24 == 0) || flag3)
						{
							if ((OperationData.PlaneSelectedName == planeNames.Top) | (OperationData.PlaneSelectedName == planeNames.Free))
							{
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.Type = 0;
								pnt9DCam.Feed = camParMilling.Speeds.Rapid;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								pnt9DCam.EnableAxes.Z = false;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoUpFirstPoint;
								pnt9DCam.PlungeAxis = "Z";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.PlungeValue = num9;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num3), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoDownAproach;
								pnt9DCam.PlungeAxis = "Z";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.PlungeValue = num8;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								geoLine geoLine5 = new geoLine(new Pnt3D(list8[0].X, list8[0].Y, num2), new Pnt3D(list8[0].X, list8[0].Y, RefList[num24].Depth), -1);
								geoLine5.Color = Tool.Display.PlungeColor;
								geoLine5.Thickness = num;
								camPoint.EntitiesPlunge.Add(geoLine5);
							}
							if (OperationData.PlaneSelectedName == planeNames.Right)
							{
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoUpFirstPoint;
								pnt9DCam.PlungeAxis = "Y";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.PlungeValue = num9;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.Type = 0;
								pnt9DCam.Feed = camParMilling.Speeds.Rapid;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								pnt9DCam.EnableAxes.Y = false;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num3), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoDownAproach;
								pnt9DCam.PlungeAxis = "Y";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.PlungeValue = num8;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								geoLine geoLine6 = new geoLine(new Pnt3D(list8[0].X, list8[0].Y, num2), new Pnt3D(list8[0].X, list8[0].Y, RefList[num24].Depth), -1);
								geoLine6.Color = Tool.Display.PlungeColor;
								geoLine6.Thickness = num;
								camPoint.EntitiesPlunge.Add(geoLine6);
							}
							if (OperationData.PlaneSelectedName == planeNames.Left)
							{
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoUpFirstPoint;
								pnt9DCam.PlungeAxis = "Y";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.PlungeValue = num9;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num2), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.Type = 0;
								pnt9DCam.Feed = camParMilling.Speeds.Rapid;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								pnt9DCam.EnableAxes.Y = false;
								camPoint.Points.Add(pnt9DCam);
								pnt9DCam = new Pnt9DCam(new Pnt6D(list8[0].X, list8[0].Y, num3), camParMilling.Speeds.Rapid, 0);
								pnt9DCam.PlungeAction = CamPlungeActionType.GoDownAproach;
								pnt9DCam.PlungeAxis = "Y";
								pnt9DCam.PlungeAxisMovement = true;
								pnt9DCam.PlungeValue = num8;
								pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
								pnt9DCam.ToolNo = Tool.Data.No;
								camPoint.Points.Add(pnt9DCam);
								geoLine geoLine7 = new geoLine(new Pnt3D(list8[0].X, list8[0].Y, num2), new Pnt3D(list8[0].X, list8[0].Y, RefList[num24].Depth), -1);
								geoLine7.Color = Tool.Display.PlungeColor;
								geoLine7.Thickness = num;
								camPoint.EntitiesPlunge.Add(geoLine7);
							}
							flag = true;
							flag3 = false;
						}
						for (int num28 = 0; num28 <= list8.Count - 1; num28++)
						{
							double feed = num4;
							if (flag)
							{
								feed = num7;
							}
							if (Action == actionTypeBU.profileHole)
							{
								feed = num7;
							}
							if ((camZHeightType == CamZHeightType.Finish) & (num24 == RefList.Count - 1))
							{
								feed = num6;
							}
							pnt9DCam = new Pnt9DCam(new Pnt6D(list8[num28]), feed, 1);
							pnt9DCam.Type = 1;
							pnt9DCam.Feed = feed;
							pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
							pnt9DCam.ToolNo = Tool.Data.No;
							camPoint.Points.Add(pnt9DCam);
							pnt3D3 = new Pnt3D(pnt9DCam);
							flag = false;
						}
						if (list8.Count >= 2)
						{
							geoPolyline geoPolyline2 = new geoPolyline(list8, -1);
							geoPolyline2.Color = Tool.Display.CamColor;
							geoPolyline2.Thickness = num;
							camPoint.EntitiesG1.Add(geoPolyline2);
						}
					}
				}
				if (flag2 && ((OperationData.PlaneSelectedName == planeNames.Top) | (OperationData.PlaneSelectedName == planeNames.Bottom)) && !Pnt3D.EqualXY(pnt3D3, refP))
				{
					flag3 = true;
				}
				if (!flag2 || flag3)
				{
					if ((OperationData.PlaneSelectedName == planeNames.Top) | (OperationData.PlaneSelectedName == planeNames.Bottom))
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, num2), camParMilling.Speeds.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAction = CamPlungeActionType.GoUpLastPoint;
						pnt9DCam.PlungeAxisMovement = true;
						pnt9DCam.PlungeValue = num9;
						pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
						pnt9DCam.ToolNo = Tool.Data.No;
						geoLine geoLine8 = new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D3.X, pnt3D3.Y, num2), -1);
						geoLine8.Color = Tool.Display.LeaveColor;
						geoLine8.Thickness = num;
						camPoint.EntitiesG0.Add(geoLine8);
					}
					if (OperationData.PlaneSelectedName == planeNames.Left)
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, num2), camParMilling.Speeds.Rapid, 0);
						pnt9DCam.PlungeAxis = "Y";
						pnt9DCam.PlungeAction = CamPlungeActionType.GoUpLastPoint;
						pnt9DCam.PlungeAxisMovement = true;
						pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
						pnt9DCam.PlungeValue = num9;
						pnt9DCam.ToolNo = Tool.Data.No;
						geoLine geoLine9 = new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D3.X, pnt3D3.Y, num2), -1);
						geoLine9.Color = Tool.Display.LeaveColor;
						geoLine9.Thickness = num;
						camPoint.EntitiesG0.Add(geoLine9);
					}
					if (OperationData.PlaneSelectedName == planeNames.Right)
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, num2), camParMilling.Speeds.Rapid, 0);
						pnt9DCam.PlungeAxis = "Y";
						pnt9DCam.PlungeAction = CamPlungeActionType.GoUpLastPoint;
						pnt9DCam.PlungeAxisMovement = true;
						pnt9DCam.PlungeValue = num9;
						pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
						pnt9DCam.ToolNo = Tool.Data.No;
						geoLine geoLine10 = new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D3.X, pnt3D3.Y, num2), -1);
						geoLine10.Color = Tool.Display.LeaveColor;
						geoLine10.Thickness = num;
						camPoint.EntitiesG0.Add(geoLine10);
					}
					if (OperationData.PlaneSelectedName == planeNames.Free)
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D3.X, pnt3D3.Y, num2), camParMilling.Speeds.Rapid, 0);
						pnt9DCam.PlungeAction = CamPlungeActionType.GoUpLastPoint;
						pnt9DCam.PlungeAxis = "";
						pnt9DCam.PlungeAxisMovement = false;
						pnt9DCam.PlungeValue = num9;
						pnt9DCam.SpindleSpeed = Tool.CamData.SpindleSpeed;
						pnt9DCam.ToolNo = Tool.Data.No;
						geoLine geoLine11 = new geoLine(new Pnt3D(pnt3D3), new Pnt3D(pnt3D3.X, pnt3D3.Y, num2), -1);
						geoLine11.Color = Tool.Display.LeaveColor;
						geoLine11.Thickness = num;
						camPoint.EntitiesG0.Add(geoLine11);
					}
					camPoint.Points.Add(pnt9DCam);
					flag = true;
				}
				for (int num29 = 0; num29 <= camPoint.Points.Count - 1; num29++)
				{
					if (camPoint.Points[num29].Type == 1 && num29 > 0)
					{
						double num30 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num29 - 1]), new Pnt3D(camPoint.Points[num29]));
						CamCalc.TotalOperationTimeSec += num30 / camPoint.Points[num29].Feed;
						CamCalc.TotalOperationG1Distance += num30;
					}
					if (camPoint.Points[num29].Type == 0)
					{
						if (num29 != 0)
						{
							double num31 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num29 - 1]), new Pnt3D(camPoint.Points[num29]));
							CamCalc.TotalOperationG0Distance += num31;
						}
						else
						{
							double num32 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[num29]), new Pnt3D(camPoint.Points[num29 + 1]));
							CamCalc.TotalOperationG0Distance += num32;
						}
					}
				}
				CamCalc.TotalOperationDistance = CamCalc.TotalOperationG0Distance + CamCalc.TotalOperationG1Distance;
				SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
				CamCalc.CamPoints.Add(camPoint);
				CamCalc.Tool = new ToolBase(toolBase);
			}
			P.SelectedPlane = OperationData.PlaneSelectedName;
			P.CamParMilling = new camParameters(camParMilling);
			P.Tool = new ToolBase(toolBase);
			P.OperationData = new ProfileOperationData(OperationData);
			P.CamCalculation.Add(new camBase(CamCalc));
			return 1;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public int ProfileOperationRotateAccordingToPlane(ref ProfileOperation P, ref List<eEntities> CadEntities, ref camBase CamCalc, WorkPlane Plane, ProfileOperationData OperationData, KinematicBase Kinematic)
	{
		try
		{
			if (OperationData.PlaneSelectedName == planeNames.Top)
			{
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.Entities);
				for (int i = 0; i <= P.CamCalculation.Count - 1; i++)
				{
					for (int j = 0; j <= P.CamCalculation[i].CamPoints.Count - 1; j++)
					{
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesG0);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesG1);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesLeadIn);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesLeadOut);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesLeave);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesMark);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesOther);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref P.CamCalculation[i].CamPoints[j].EntitiesPlunge);
						for (int k = 0; k <= P.CamCalculation[i].CamPoints[j].EntitiesG1.Count - 1; k++)
						{
							eEntities EEntity = new eEntities();
							geoEntity.GeoEntitiyToEEntity(P.CamCalculation[i].CamPoints[j].EntitiesG1[k], ref EEntity);
							P.AuxEntities.Add(EEntity);
						}
						for (int l = 0; l <= P.CamCalculation[i].CamPoints[j].SimilationPoint.SimDetailedPoints.Count - 1; l++)
						{
							Pnt6DSim Point = new Pnt6DSim(P.CamCalculation[i].CamPoints[j].SimilationPoint.SimDetailedPoints[l]);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref Point);
							Point.A = 0.0;
							P.CamCalculation[i].CamPoints[j].SimilationPoint.SimDetailedPoints[l] = Point;
						}
						for (int m = 0; m <= P.CamCalculation[i].CamPoints[j].Points.Count - 1; m++)
						{
							Pnt9D Point2 = new Pnt9D(P.CamCalculation[i].CamPoints[j].Points[m].P9);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, 0.0), ref Point2);
							Point2.A = 0.0;
							if (P.CamCalculation[i].CamPoints[j].Points[m].PlungeAxisMovement)
							{
								P.CamCalculation[i].CamPoints[j].Points[m].PlungeAxis = "Z";
							}
							P.CamCalculation[i].CamPoints[j].Points[m].P9 = Point2;
						}
					}
				}
			}
			if (OperationData.PlaneSelectedName == planeNames.Left)
			{
				double num = -90.0;
				buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.Entities);
				buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.Entities);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.Entities);
				for (int n = 0; n <= P.CamCalculation.Count - 1; n++)
				{
					for (int num2 = 0; num2 <= P.CamCalculation[n].CamPoints.Count - 1; num2++)
					{
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesG0);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesG0);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesG0);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesG1);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesG1);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesG1);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadIn);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadIn);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadIn);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadOut);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadOut);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeadOut);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesLeave);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeave);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesLeave);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesMark);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesMark);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesMark);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesOther);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesOther);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesOther);
						buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref P.CamCalculation[n].CamPoints[num2].EntitiesPlunge);
						buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[n].CamPoints[num2].EntitiesPlunge);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[n].CamPoints[num2].EntitiesPlunge);
						for (int num3 = 0; num3 <= P.CamCalculation[n].CamPoints[num2].EntitiesG1.Count - 1; num3++)
						{
							eEntities EEntity2 = new eEntities();
							geoEntity.GeoEntitiyToEEntity(P.CamCalculation[n].CamPoints[num2].EntitiesG1[num3], ref EEntity2);
							P.AuxEntities.Add(EEntity2);
						}
						for (int num4 = 0; num4 <= P.CamCalculation[n].CamPoints[num2].SimilationPoint.SimDetailedPoints.Count - 1; num4++)
						{
							Pnt6DSim RefPoint = new Pnt6DSim(P.CamCalculation[n].CamPoints[num2].SimilationPoint.SimDetailedPoints[num4]);
							buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref RefPoint);
							buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref RefPoint);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref RefPoint);
							RefPoint.A = num;
							P.CamCalculation[n].CamPoints[num2].SimilationPoint.SimDetailedPoints[num4] = RefPoint;
						}
						for (int num5 = 0; num5 <= P.CamCalculation[n].CamPoints[num2].Points.Count - 1; num5++)
						{
							Pnt9D RefPoint2 = new Pnt9D(P.CamCalculation[n].CamPoints[num2].Points[num5].P9);
							buAppCalc.cVector.Mirror(new Pnt3D(), new Pnt3D(1.0, 0.0, 0.0), new WorkPlane(), 0.0, ref RefPoint2);
							buAppCalc.cVector.Rotate(new Pnt3D(), num, new WorkPlane(planeType.YZ, 1), ref RefPoint2);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref RefPoint2);
							RefPoint2.A = num;
							if (P.CamCalculation[n].CamPoints[num2].Points[num5].PlungeAxisMovement)
							{
								P.CamCalculation[n].CamPoints[num2].Points[num5].PlungeAxis = "Y";
							}
							P.CamCalculation[n].CamPoints[num2].Points[num5].P9 = RefPoint2;
						}
					}
				}
			}
			if (OperationData.PlaneSelectedName == planeNames.Right)
			{
				double num6 = -90.0;
				buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.Entities);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.Entities);
				for (int num7 = 0; num7 <= P.CamCalculation.Count - 1; num7++)
				{
					for (int num8 = 0; num8 <= P.CamCalculation[num7].CamPoints.Count - 1; num8++)
					{
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesG0);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesG0);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesG1);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesG1);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeadIn);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeadIn);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeadOut);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeadOut);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeave);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesLeave);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesMark);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesMark);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesOther);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesOther);
						buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num7].CamPoints[num8].EntitiesPlunge);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref P.CamCalculation[num7].CamPoints[num8].EntitiesPlunge);
						for (int num9 = 0; num9 <= P.CamCalculation[num7].CamPoints[num8].EntitiesG1.Count - 1; num9++)
						{
							eEntities EEntity3 = new eEntities();
							geoEntity.GeoEntitiyToEEntity(P.CamCalculation[num7].CamPoints[num8].EntitiesG1[num9], ref EEntity3);
							P.AuxEntities.Add(EEntity3);
						}
						for (int num10 = 0; num10 <= P.CamCalculation[num7].CamPoints[num8].SimilationPoint.SimDetailedPoints.Count - 1; num10++)
						{
							Pnt6DSim Points = new Pnt6DSim(P.CamCalculation[num7].CamPoints[num8].SimilationPoint.SimDetailedPoints[num10]);
							buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref Points);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref Points);
							Points.A = 0.0 - num6;
							P.CamCalculation[num7].CamPoints[num8].SimilationPoint.SimDetailedPoints[num10] = Points;
						}
						for (int num11 = 0; num11 <= P.CamCalculation[num7].CamPoints[num8].Points.Count - 1; num11++)
						{
							Pnt9D Points2 = new Pnt9D(P.CamCalculation[num7].CamPoints[num8].Points[num11].P9);
							buAppCalc.cVector.Rotate(new Pnt3D(), num6, new WorkPlane(planeType.YZ, 1), ref Points2);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, 0.0, P.OperationData.Position.Z), ref Points2);
							Points2.A = 0.0 - num6;
							if (P.CamCalculation[num7].CamPoints[num8].Points[num11].PlungeAxisMovement)
							{
								P.CamCalculation[num7].CamPoints[num8].Points[num11].PlungeAxis = "Y";
							}
							P.CamCalculation[num7].CamPoints[num8].Points[num11].P9 = Points2;
						}
					}
				}
			}
			if (OperationData.PlaneSelectedName == planeNames.Free)
			{
				double a = Plane.Angles.A;
				eEntities.CopyEntities(P.Entities, ref P.NoRotatedEntities);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.NoRotatedEntities);
				buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.Entities);
				buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.Entities);
				for (int num12 = 0; num12 <= P.CamCalculation.Count - 1; num12++)
				{
					for (int num13 = 0; num13 <= P.CamCalculation[num12].CamPoints.Count - 1; num13++)
					{
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesG0);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesG0);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesG1);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesG1);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeadIn);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeadIn);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeadOut);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeadOut);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeave);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesLeave);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesMark);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesMark);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesOther);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesOther);
						buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref P.CamCalculation[num12].CamPoints[num13].EntitiesPlunge);
						buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref P.CamCalculation[num12].CamPoints[num13].EntitiesPlunge);
						for (int num14 = 0; num14 <= P.CamCalculation[num12].CamPoints[num13].EntitiesG1.Count - 1; num14++)
						{
							eEntities EEntity4 = new eEntities();
							geoEntity.GeoEntitiyToEEntity(P.CamCalculation[num12].CamPoints[num13].EntitiesG1[num14], ref EEntity4);
							P.AuxEntities.Add(EEntity4);
						}
						for (int num15 = 0; num15 <= P.CamCalculation[num12].CamPoints[num13].SimilationPoint.SimDetailedPoints.Count - 1; num15++)
						{
							Pnt6DSim Points3 = new Pnt6DSim(P.CamCalculation[num12].CamPoints[num13].SimilationPoint.SimDetailedPoints[num15]);
							buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref Points3);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref Points3);
							Points3.A = a;
							P.CamCalculation[num12].CamPoints[num13].SimilationPoint.SimDetailedPoints[num15] = Points3;
						}
						for (int num16 = 0; num16 <= P.CamCalculation[num12].CamPoints[num13].Points.Count - 1; num16++)
						{
							Pnt9D Points4 = new Pnt9D(P.CamCalculation[num12].CamPoints[num13].Points[num16].P9);
							buAppCalc.cVector.Rotate(new Pnt3D(), a, new WorkPlane(planeType.YZ, 1), ref Points4);
							buAppCalc.cVector.Move(new Pnt3D(), new Pnt3D(P.OperationData.Position.X, P.OperationData.Position.Y, P.OperationData.Position.Z), ref Points4);
							double length = P.Tool.Geometry.Length;
							Pnt6D CalcPoint = new Pnt6D();
							OrientationAngle orientation = new OrientationAngle(a, 0.0, 0.0);
							buAppCalc.cKinematic.ForwardKinematix4Ax(length, Kinematic, VectorType.XVector, orientation, new Pnt3D(Points4.X, Points4.Y, Points4.Z), ref CalcPoint);
							Points4 = new Pnt9D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z - Kinematic.RotateCenterOffsetOfA.Z - length, CalcPoint.A, CalcPoint.B, CalcPoint.C);
							if (P.CamCalculation[num12].CamPoints[num13].Points[num16].PlungeAxisMovement)
							{
								P.CamCalculation[num12].CamPoints[num13].Points[num16].PlungeAxis = "Z";
							}
							P.CamCalculation[num12].CamPoints[num13].Points[num16].P9 = Points4;
						}
					}
				}
			}
			return 1;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
			return -1;
		}
	}

	public int ProfileOperationNotchCalc(ref ProfileOperation P, ref List<eEntities> CadEntities, ref camBase CamCalc, actionTypeBU Action, ProfileItem Profile, ToolBase Tool, List<ToolBase> ToolList, WorkPlane Plane, ProfileOperationData OperationData, camParameters camParNotch, int LayerIndex, double YSing)
	{
		try
		{
			string text = "";
			CamCalc = new camBase();
			CamPoint camPoint = new CamPoint();
			CamCalc.Name = "Profile -" + text;
			Pnt9DCam pnt9DCam = new Pnt9DCam();
			ToolBase toolBase = null;
			ToolBase toolBase2 = null;
			toolBase = new ToolBase(Tool);
			for (int i = 0; i <= ToolList.Count - 1; i++)
			{
				if (ToolList[i].Purpose == ToolPurpose.Saw)
				{
					toolBase = new ToolBase(ToolList[i]);
				}
				if (ToolList[i].Purpose != ToolPurpose.Milling)
				{
					continue;
				}
				if (toolBase2 != null)
				{
					if (ToolList[i].Geometry.Length > OperationData.NotchData.NotchLHeight && ToolList[i].Geometry.Diameter / 2.0 <= OperationData.NotchData.NotchLDepth && ToolList[i].Geometry.Diameter < toolBase2.Geometry.Diameter)
					{
						toolBase2 = new ToolBase(ToolList[i]);
					}
				}
				else if (ToolList[i].Geometry.Length > OperationData.NotchData.NotchLHeight && ToolList[i].Geometry.Diameter / 2.0 <= OperationData.NotchData.NotchLDepth)
				{
					toolBase2 = new ToolBase(ToolList[i]);
				}
			}
			List<double> list = new List<double>();
			double num = 0.0;
			double num2 = 0.0;
			double x = 0.0;
			double x2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double x3 = 0.0;
			double num5 = 0.0;
			int num6 = 0;
			if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
			{
				x2 = 0.0 - camParNotch.Distances.Safe;
				x3 = OperationData.NotchData.NotchLDepth - toolBase2.Geometry.Diameter / 2.0;
			}
			if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
			{
				x2 = Profile.Length + camParNotch.Distances.Safe;
				x3 = Profile.Length - OperationData.NotchData.NotchLDepth + toolBase2.Geometry.Diameter / 2.0;
			}
			if (OperationData.NotchData.NotchType == ProfileNotchType.LType)
			{
				P = new ProfileOperationNotch();
				((ProfileOperationNotch)P).Type = OperationData.NotchData.NotchType;
				((ProfileOperationNotch)P).Width = OperationData.NotchData.NotchLWidth;
				((ProfileOperationNotch)P).Height = OperationData.NotchData.NotchLHeight;
				((ProfileOperationNotch)P).Depth = OperationData.NotchData.NotchLDepth;
				((ProfileOperationNotch)P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
				((ProfileOperationNotch)P).UpDown = OperationData.NotchData.NotchLUpDown;
				((ProfileOperationNotch)P).LeftRight = OperationData.NotchData.NotchLeftRight;
				text = "Notch L";
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					x = OperationData.NotchData.NotchLDepth;
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					x = Profile.Length - OperationData.NotchData.NotchLDepth;
				}
				if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
				{
					num4 = OperationData.NotchData.NotchLHeight - toolBase.Geometry.Thickness * 2.0;
					double num7 = toolBase.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
					num6 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num4 / num7)));
					num3 = Math.Round(num4 / (double)num6, 5);
					list.Add(Profile.Height - toolBase.Geometry.Thickness / 2.0);
					num = Profile.Height - toolBase.Geometry.Thickness / 2.0;
					for (int j = 1; j <= num6; j++)
					{
						num2 = Math.Round(num - num3, 5);
						list.Add(num2);
						num = num2;
					}
					list.Add(Profile.Height - OperationData.NotchData.NotchLHeight + toolBase.Geometry.Thickness / 2.0);
				}
				if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
				{
					num4 = OperationData.NotchData.NotchLHeight - toolBase.Geometry.Thickness * 2.0;
					double num7 = toolBase.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
					num6 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num4 / num7)));
					num3 = Math.Round(num4 / (double)num6, 5);
					list.Add(OperationData.NotchData.NotchLHeight - toolBase.Geometry.Thickness / 2.0);
					num = OperationData.NotchData.NotchLHeight - toolBase.Geometry.Thickness / 2.0;
					for (int k = 1; k <= num6; k++)
					{
						num2 = Math.Round(num - num3, 5);
						list.Add(num2);
						num = num2;
					}
					list.Add(toolBase.Geometry.Thickness / 2.0);
				}
			}
			if (OperationData.NotchData.NotchType == ProfileNotchType.UType)
			{
				P = new ProfileOperationNotch();
				((ProfileOperationNotch)P).Type = OperationData.NotchData.NotchType;
				((ProfileOperationNotch)P).Width = OperationData.NotchData.NotchUWidth;
				((ProfileOperationNotch)P).Height = OperationData.NotchData.NotchUHeight;
				((ProfileOperationNotch)P).Start = OperationData.NotchData.NotchUStart;
				((ProfileOperationNotch)P).Depth = OperationData.NotchData.NotchUDepth;
				((ProfileOperationNotch)P).ToolCutPersentage = OperationData.NotchData.NotchCutPersentage;
				((ProfileOperationNotch)P).LeftRight = OperationData.NotchData.NotchLeftRight;
				text = "Notch U";
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					x = OperationData.NotchData.NotchUDepth;
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					x = Profile.Length - OperationData.NotchData.NotchUDepth;
				}
				num4 = OperationData.NotchData.NotchUHeight - toolBase.Geometry.Thickness * 2.0;
				double num7 = toolBase.Geometry.Thickness * OperationData.NotchData.NotchCutPersentage / 100.0;
				num6 = Convert.ToInt32(buNumeric.RoundToUpper(buNumeric.RoundToUpper(num4 / num7)));
				num3 = Math.Round(num4 / (double)num6, 5);
				list.Add(OperationData.NotchData.NotchUStart - toolBase.Geometry.Thickness / 2.0);
				num = OperationData.NotchData.NotchUStart - toolBase.Geometry.Thickness / 2.0;
				for (int l = 1; l <= num6; l++)
				{
					num2 = Math.Round(num - num3, 5);
					list.Add(num2);
					num = num2;
				}
				list.Add(OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight + toolBase.Geometry.Thickness / 2.0);
			}
			if ((OperationData.NotchData.NotchType == ProfileNotchType.LType) & (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up) & (OperationData.NotchData.NotchCutType == ProfileNotchCutType.BySawAndMilling))
			{
				if (toolBase2 == null)
				{
					return -1;
				}
				CamCalc.Tool = new ToolBase(toolBase);
				num5 = Profile.Height + Profile.SupportBlockZHeight - OperationData.NotchData.NotchLHeight + toolBase.Geometry.Thickness / 2.0;
				List<Pnt3D> list2 = new List<Pnt3D>();
				pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, num5), camParNotch.Speeds.Rapid, 0);
				pnt9DCam.PlungeAxis = "X";
				pnt9DCam.PlungeAxisMovement = true;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, num5), camParNotch.Speeds.Rapid, 0);
				pnt9DCam.Type = 0;
				pnt9DCam.Feed = camParNotch.Speeds.Rapid;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x, 0.0, num5), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Plunge;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x, Profile.Width * YSing, num5), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Feed;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, num5), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Leave;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				geoPolyline geoPolyline2 = new geoPolyline(list2, -1);
				geoPolyline2.Color = OperationData.NotchData.NotchColor;
				geoPolyline2.Thickness = OperationData.NotchData.NotchThickness;
				camPoint.EntitiesG1.Add(geoPolyline2);
				SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
				CamCalc.CamPoints.Add(camPoint);
				CamCalc.Tool = new ToolBase(toolBase);
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
				}
				P.CamCalculation.Add(new camBase(CamCalc));
				CamCalc = new camBase();
				camPoint = new CamPoint();
				CamCalc.Name = "Profile -" + text;
				pnt9DCam = new Pnt9DCam();
				list2 = new List<Pnt3D>();
				pnt9DCam = new Pnt9DCam(new Pnt6D(x3, 0.0, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x3, 0.0, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Rapid, 0);
				pnt9DCam.Type = 0;
				pnt9DCam.Feed = camParNotch.Speeds.Rapid;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x3, 0.0, num5 - toolBase.Geometry.Thickness / 2.0), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Plunge;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x3, Profile.Width * YSing, num5 - toolBase.Geometry.Thickness / 2.0), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Feed;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				pnt9DCam = new Pnt9DCam(new Pnt6D(x3, Profile.Width * YSing, Profile.Height + camParNotch.Distances.Safe), camParNotch.Speeds.Plunge, 1);
				pnt9DCam.Type = 1;
				pnt9DCam.Feed = camParNotch.Speeds.Leave;
				camPoint.Points.Add(pnt9DCam);
				list2.Add(new Pnt3D(pnt9DCam));
				geoPolyline2 = new geoPolyline(list2, -1);
				geoPolyline2.Color = OperationData.NotchData.NotchColor;
				geoPolyline2.Thickness = OperationData.NotchData.NotchThickness;
				camPoint.EntitiesG1.Add(geoPolyline2);
				SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
				CamCalc.CamPoints.Add(camPoint);
				CamCalc.Tool = new ToolBase(toolBase2);
				list.Clear();
			}
			for (int m = 0; m <= list.Count - 1; m++)
			{
				CamCalc.Tool = new ToolBase(toolBase);
				List<Pnt3D> list3 = new List<Pnt3D>();
				camPoint = new CamPoint();
				double z = list[m];
				if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.OneWayDirection)
				{
					pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
					pnt9DCam.PlungeAxis = "X";
					pnt9DCam.PlungeAxisMovement = true;
					camPoint.Points.Add(pnt9DCam);
					pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
					pnt9DCam.Type = 0;
					pnt9DCam.Feed = camParNotch.Speeds.Rapid;
					camPoint.Points.Add(pnt9DCam);
					list3.Add(new Pnt3D(pnt9DCam));
					pnt9DCam = new Pnt9DCam(new Pnt6D(x, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
					pnt9DCam.Type = 1;
					pnt9DCam.Feed = camParNotch.Speeds.Plunge;
					camPoint.Points.Add(pnt9DCam);
					list3.Add(new Pnt3D(pnt9DCam));
					pnt9DCam = new Pnt9DCam(new Pnt6D(x, 0.0, z), camParNotch.Speeds.Plunge, 1);
					pnt9DCam.Type = 1;
					pnt9DCam.Feed = camParNotch.Speeds.Feed;
					camPoint.Points.Add(pnt9DCam);
					list3.Add(new Pnt3D(pnt9DCam));
					pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Plunge, 1);
					pnt9DCam.Type = 1;
					pnt9DCam.Feed = camParNotch.Speeds.Leave;
					camPoint.Points.Add(pnt9DCam);
					list3.Add(new Pnt3D(pnt9DCam));
				}
				if (OperationData.NotchData.NotchCutDirection == CamCuttingWayDirectionType.TwoWayDirection)
				{
					if (m % 2 != 1)
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
						pnt9DCam.PlungeAxis = "X";
						pnt9DCam.PlungeAxisMovement = true;
						camPoint.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Rapid, 0);
						pnt9DCam.Type = 0;
						pnt9DCam.Feed = camParNotch.Speeds.Rapid;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Plunge;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x, 0.0, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Feed;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Leave;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
					}
					else
					{
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
						pnt9DCam.PlungeAxis = "X";
						pnt9DCam.PlungeAxisMovement = true;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, 0.0, z), camParNotch.Speeds.Rapid, 0);
						pnt9DCam.Type = 0;
						pnt9DCam.Feed = camParNotch.Speeds.Rapid;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x, 0.0, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Plunge;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Feed;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
						pnt9DCam = new Pnt9DCam(new Pnt6D(x2, Profile.Width * YSing, z), camParNotch.Speeds.Plunge, 1);
						pnt9DCam.Type = 1;
						pnt9DCam.Feed = camParNotch.Speeds.Leave;
						camPoint.Points.Add(pnt9DCam);
						list3.Add(new Pnt3D(pnt9DCam));
					}
				}
				geoPolyline geoPolyline3 = new geoPolyline(list3, -1);
				geoPolyline3.Color = OperationData.RectangleData.RectangleColor;
				geoPolyline3.Thickness = OperationData.RectangleData.RectangleThickness;
				camPoint.EntitiesG1.Add(geoPolyline3);
				SimPointCreatForDetailedPoints(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					CamCalc.Tool.CamData.SimMoveOffset.X = (0.0 - toolBase.Geometry.Diameter) / 2.0;
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					CamCalc.Tool.CamData.SimMoveOffset.X = toolBase.Geometry.Diameter / 2.0;
				}
				CamCalc.CamPoints.Add(camPoint);
			}
			if (OperationData.NotchData.NotchType == ProfileNotchType.LType)
			{
				List<List<Pnt3D>> Vertices = new List<List<Pnt3D>>();
				List<Triangle3D> Triangles = new List<Triangle3D>();
				List<TriangleIndex> TrianglesIndex = new List<TriangleIndex>();
				List<Pnt3D> Vertices2 = new List<Pnt3D>();
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
					{
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices, ref Triangles);
					}
					if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
					{
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices, ref Triangles);
					}
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Up)
					{
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, Profile.Height - OperationData.NotchData.NotchLHeight), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices, ref Triangles);
					}
					if (OperationData.NotchData.NotchLUpDown == UpDownLocationType.Down)
					{
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref TrianglesIndex, ref Vertices2);
						buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchLDepth / 2.0, YSing * OperationData.NotchData.NotchLWidth / 2.0, 0.0), OperationData.NotchData.NotchLDepth, YSing * OperationData.NotchData.NotchLWidth, OperationData.NotchData.NotchLHeight, 0.0, new WorkPlane(), ref Vertices, ref Triangles);
					}
				}
				List<eEntities> list4 = new List<eEntities>();
				CadEntities.Clear();
				for (int n = 0; n <= Vertices.Count - 1; n++)
				{
					ePolyline ePolyline2 = new ePolyline(Vertices[n]);
					ePolyline2.LayerIndex = LayerIndex;
					CadEntities.Add(ePolyline2);
					list4.Add(ePolyline2);
				}
				P.Entities.Add(list4);
				eMesh eMesh2 = new eMesh(TrianglesIndex, Vertices2, Color.Gold);
				eMesh2.LayerIndex = LayerIndex;
				CadEntities.Add(eMesh2);
				P.SolidEntities.Add(eMesh2);
			}
			if (OperationData.NotchData.NotchType == ProfileNotchType.UType)
			{
				List<List<Pnt3D>> list5 = new List<List<Pnt3D>>();
				new List<Triangle3D>();
				List<TriangleIndex> TrianglesIndex2 = new List<TriangleIndex>();
				List<Pnt3D> Vertices3 = new List<Pnt3D>();
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Left)
				{
					buAppCalc.cVector.BoxCenter3D(new Pnt3D(OperationData.NotchData.NotchUDepth / 2.0, YSing * OperationData.NotchData.NotchUWidth / 2.0, OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight), OperationData.NotchData.NotchUDepth, YSing * OperationData.NotchData.NotchUWidth, OperationData.NotchData.NotchUHeight, 0.0, new WorkPlane(), ref TrianglesIndex2, ref Vertices3);
				}
				if (OperationData.NotchData.NotchLeftRight == LeftRightLocationType.Right)
				{
					buAppCalc.cVector.BoxCenter3D(new Pnt3D(Profile.Length - OperationData.NotchData.NotchUDepth / 2.0, YSing * OperationData.NotchData.NotchUWidth / 2.0, OperationData.NotchData.NotchUStart - OperationData.NotchData.NotchUHeight), OperationData.NotchData.NotchUDepth, YSing * OperationData.NotchData.NotchUWidth, OperationData.NotchData.NotchUHeight, 0.0, new WorkPlane(), ref TrianglesIndex2, ref Vertices3);
				}
				CadEntities.Clear();
				List<eEntities> list6 = new List<eEntities>();
				for (int num8 = 0; num8 <= list5.Count - 1; num8++)
				{
					ePolyline ePolyline3 = new ePolyline(list5[num8]);
					ePolyline3.LayerIndex = LayerIndex;
					CadEntities.Add(ePolyline3);
					list6.Add(ePolyline3);
				}
				P.Entities.Add(list6);
				eMesh eMesh3 = new eMesh(TrianglesIndex2, Vertices3, Color.Gold);
				eMesh3.LayerIndex = LayerIndex;
				CadEntities.Add(eMesh3);
				P.SolidEntities.Add(eMesh3);
			}
			P.CamParNotch = new camParameters(camParNotch);
			P.CamCalculation.Add(new camBase(CamCalc));
			P.OperationData = new ProfileOperationData(OperationData);
			return 1;
		}
		catch (Exception mSException)
		{
			string text2 = "";
			buLog.addLog(text2, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text2);
			return -1;
		}
	}

	public int ProfileContourOffsets(List<Pnt3D> ContourPoints, double ExtraOffset, camParameters camParMilling, ToolBase toolSelected, CamZHeightType OperationCamType, ref List<List<Pnt3D>> pntCalculated)
	{
		try
		{
			pntCalculated.Clear();
			if (ContourPoints.Count > 0)
			{
				bool flag = buAppCalc.cVector.IsClosed(ContourPoints);
				if (OperationCamType == CamZHeightType.Contour || OperationCamType == CamZHeightType.Finish)
				{
					if (!flag)
					{
						if (camParMilling.Offsets.OpenContourOld != CamOpenContourType2.Center)
						{
							double offset = toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset;
							buAppCalc.cVector.OffsetContour(ContourPoints, offset, camParMilling.Offsets.Corner, camParMilling.Offsets.OpenContourOld, new WorkPlane(), 0.0, ref pntCalculated);
							List<Pnt3D> CalcPoints = new List<Pnt3D>();
							if (pntCalculated.Count > 0)
							{
								buAppCalc.cVector.OpenProfileCalculation(pntCalculated[0], ContourPoints, offset, new WorkPlane(), camParMilling.Offsets.OpenContourOld, ref CalcPoints);
								pntCalculated[0] = CalcPoints;
							}
						}
						else
						{
							List<Pnt3D> CopiedPnt = new List<Pnt3D>();
							Pnt3D.Copy(ContourPoints, ref CopiedPnt);
							pntCalculated.Add(CopiedPnt);
						}
					}
					else if (camParMilling.Offsets.ClosedContour == CamClosedContourType.Center)
					{
						List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
						Pnt3D.Copy(ContourPoints, ref CopiedPnt2);
						pntCalculated.Add(CopiedPnt2);
					}
					else
					{
						double num = toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset;
						if (camParMilling.Offsets.ClosedContour == CamClosedContourType.Inner)
						{
							num = 0.0 - num;
						}
						buAppCalc.cVector.OffsetContour(ContourPoints, num, camParMilling.Offsets.Corner, CamOpenContourType2.Center, new WorkPlane(), 0.0, ref pntCalculated);
					}
				}
				if (OperationCamType == CamZHeightType.AreaClearance && flag)
				{
					ContourPoints contourPoints = new ContourPoints();
					List<PocketPoints> Pockets = new List<PocketPoints>();
					List<List<eEntities>> PocketEntities = new List<List<eEntities>>();
					Pnt3D.Copy(ContourPoints, ref contourPoints.Outter);
					buAppCalc.cVector.camPocketCircular(contourPoints, 0.0 - (toolSelected.Geometry.Diameter / 2.0 + toolSelected.CamData.ExtraOffset + ExtraOffset), camParMilling.Offsets.Corner, new WorkPlane(), 0.0, ClockDirectionType.CW, ref Pockets, ref PocketEntities);
					if (Pockets.Count > 0)
					{
						for (int i = 0; i <= Pockets.Count - 1; i++)
						{
							List<Pnt3D> list = new List<Pnt3D>();
							for (int j = 0; j <= Pockets[i].Pockets.Count - 1; j++)
							{
								for (int k = 0; k <= Pockets[i].Pockets[j].Count - 1; k++)
								{
									list.Add(new Pnt3D(Pockets[i].Pockets[j][k]));
								}
							}
							if (list.Count > 0)
							{
								if ((camParMilling.Operations.AreaClearanceDirection == InToOutType.InToOut) & camParMilling.Operations.AreaClearanceEnable)
								{
									list.Reverse();
								}
								pntCalculated.Add(list);
							}
						}
					}
				}
			}
			return 1;
		}
		catch (Exception)
		{
			return -1;
		}
	}

	public void Cam5AxisWithSaw(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, camParameters camParameter, ref camBase calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			new Pnt6D();
			List<Triangle3D> Triangles = new List<Triangle3D>();
			calcCam = new camBase();
			calcCam.Tool = new ToolBase(Tool);
			calcCam.Kinematic = new KinematicBase(Kinematic);
			KinematicItem kinematicItem = new KinematicItem();
			kinematicItem.Axis.A = true;
			kinematicItem.Axis.C = true;
			buAppCalc.cVector.Cylinder3D(new Pnt3D(0.0, 0.0 - Kinematic.RotateCenterOffsetOfC.Y, 0.0 - Kinematic.RotateCenterOffsetOfC.Z), Tool.Geometry.Length, Tool.Geometry.Diameter / 2.0, 0.0, new Vec3D(0.0, 1.0, 0.0), new EntityResolution(), ref Triangles);
			eEntities item = new eSurface(Triangles, Tool.Display.Solid.SkinColor);
			kinematicItem.Entities.Add(item);
			calcCam.Kinematic.Items.Add(kinematicItem);
			CamPoint camPoint = new CamPoint();
			if (calculationEventHandler_1 != null)
			{
				calculationEventHandler_1(new CalculationEventArg());
			}
			List<List<Pnt6D>> list = new List<List<Pnt6D>>();
			for (int i = 0; i <= Entities.Count - 1; i++)
			{
				List<Pnt6D> list2 = new List<Pnt6D>();
				if (Entities[i].Count < 1)
				{
					continue;
				}
				List<Pnt6D> Points = new List<Pnt6D>();
				new List<Pnt6D>();
				buAppCalc.cVector.EntityToPoint(Entities[i], buSystem.EntitiesResolution, ref Points);
				buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref Points, 0.01);
				if (Points.Count <= 1)
				{
					continue;
				}
				double num = 0.0;
				double num2 = 0.0;
				num2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[1]), new Pnt3D(Points[0]));
				if ((Entities[i].Count == 1) & (Points[0].C != 0.0))
				{
					num2 = Points[0].C;
				}
				num = num2;
				list2.Add(new Pnt6D(Points[0].X, Points[0].Y, Points[0].Z, Points[0].A, 0.0, num2));
				for (int j = 1; j <= Points.Count - 2; j++)
				{
					num2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[j]), new Pnt3D(Points[j - 1]));
					double num3 = Math.Abs(num2 - list2[list2.Count - 1].C);
					if (num3 > 185.0)
					{
						num2 = ((list2[list2.Count - 1].C > num2) ? (num2 + 360.0) : (num2 - 360.0));
					}
					double num4 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[j + 1]), new Pnt3D(Points[j]));
					double num5 = buAppCalc.cVector.AngleOfTwoLines(new Pnt3D(list2[list2.Count - 1]), new Pnt3D(Points[j]), new Pnt3D(Points[j]), new Pnt3D(Points[j + 1]), new WorkPlane());
					double num6 = 180.0 - num5;
					if (num6 >= 360.0 - camParameter.Strategy.AngleLimit)
					{
						num6 = 360.0 - num5;
					}
					Math.Abs(num2 - num);
					if (!(num6 > camParameter.Strategy.AngleLimit))
					{
						double num7 = Math.Abs(num2 - list2[list2.Count - 1].C);
						if (num7 >= 360.0 - camParameter.Strategy.AngleLimit)
						{
							num2 = ((num2 > list2[list2.Count - 1].C) ? (num2 - 360.0) : (num2 + 360.0));
							num7 = Math.Abs(num2 - list2[list2.Count - 1].C);
						}
						if (num7 > 185.0)
						{
							num2 += 360.0;
						}
						list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num2));
						if (Math.Abs(num2 - num4) > 180.1)
						{
							double value = num2 - num4;
							if (!(num2 > num4))
							{
								double num8 = buNumeric.RoundToLower(Math.Abs(value) / 360.0);
								num4 -= 360.0 + num8 * 360.0;
							}
							else
							{
								double num9 = buNumeric.RoundToLower(Math.Abs(value) / 360.0);
								num4 += 360.0 + num9 * 360.0;
							}
						}
						if (camParameter.Options.AxesLimit.MinLimit != camParameter.Options.AxesLimit.MaxLimit)
						{
							if (num4 > camParameter.Options.AxesLimit.MaxLimit.C)
							{
								list.Add(list2);
								num2 -= 360.0;
								list2 = new List<Pnt6D>();
								list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num2));
							}
							if (num4 < camParameter.Options.AxesLimit.MinLimit.C)
							{
								list.Add(list2);
								num2 += 360.0;
								list2 = new List<Pnt6D>();
								list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num2));
							}
						}
					}
					else
					{
						list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num2));
						list.Add(list2);
						list2 = new List<Pnt6D>();
						list2.Add(new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, Points[j].A, 0.0, num4));
					}
					num = num2;
				}
				if (list2.Count <= 0)
				{
					continue;
				}
				num2 = buAppCalc.cVector.PointAngle(new Pnt3D(Points[Points.Count - 1]), new Pnt3D(Points[Points.Count - 2]));
				if ((Entities[i].Count == 1) & (Points[Points.Count - 1].C != 0.0))
				{
					num2 = Points[Points.Count - 1].C;
				}
				double num10 = Math.Abs(num2 - list2[list2.Count - 1].C);
				if (num10 >= 360.0 - camParameter.Strategy.AngleLimit)
				{
					num10 = 360.0 - num2;
					if (num2 > list2[list2.Count - 1].C)
					{
						num2 -= 360.0;
					}
				}
				if (num10 > 185.0)
				{
					num2 += 360.0;
				}
				list2.Add(new Pnt6D(Points[Points.Count - 1].X, Points[Points.Count - 1].Y, Points[Points.Count - 1].Z, Points[Points.Count - 1].A, 0.0, num2));
				list.Add(list2);
			}
			int num11 = Convert.ToInt32((double)list.Count / 100.0);
			int num12 = 0;
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			double num13 = camParameter.Distances.Safe;
			OrientationAngle orientationAngle = new OrientationAngle();
			if (list.Count > 0 && list[0].Count > 0)
			{
				_ = list[0][0].Z;
			}
			for (int k = 0; k <= list.Count - 1; k++)
			{
				bool flag = false;
				double num14 = Tool.Geometry.Diameter / 2.0;
				double feed = camParameter.Speeds.Feed;
				double safe = camParameter.Distances.Safe;
				double stepUp = camParameter.Distances.StepUp;
				Pnt6D pnt6D2 = new Pnt6D();
				Pnt6D pnt6D3 = new Pnt6D();
				Pnt6D pnt6D4 = new Pnt6D();
				Pnt3D pnt3D2 = new Pnt3D();
				Pnt3D pnt3D3 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				OrientationAngle orientationAngle2 = new OrientationAngle();
				OrientationAngle orientationAngle3 = new OrientationAngle();
				if (k <= list.Count - 2)
				{
					pnt6D3 = new Pnt6D(list[k + 1][0]);
					orientationAngle3 = new OrientationAngle(pnt6D3);
				}
				camPoint = new CamPoint();
				camPoint.Type = 0;
				camPoint.IsRapid = true;
				pnt6D4 = new Pnt6D();
				pnt6D2 = new Pnt6D(list[k][0]);
				pnt3D2 = new Pnt3D(pnt6D2);
				pnt3D3 = new Pnt3D();
				pnt3D4 = new Pnt3D();
				orientationAngle2 = new OrientationAngle(pnt6D2);
				feed = camParameter.Speeds.Feed;
				safe = (num13 - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				calcCam.Tool.Geometry.Length = num14;
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				if (orientationAngle2.A != orientationAngle.A && pnt6D.Z > pnt6D4.Z)
				{
					pnt6D4.Z = pnt6D.Z;
				}
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camParameter.Speeds.Rapid, 0, plungemove: true));
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D4);
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camParameter.Speeds.Rapid, 0));
				pnt3D = new Pnt3D(pnt3D3);
				new Pnt6D(pnt6D4);
				if (k == 0)
				{
					new Pnt6D(pnt6D4);
				}
				pnt6D4 = new Pnt6D();
				pnt3D4 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
				buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camParameter.Speeds.Plunge, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D4), Color.Lime));
				pnt3D = new Pnt3D(pnt3D2);
				new Pnt6D(pnt6D4);
				for (int l = 1; l <= list[k].Count - 1; l++)
				{
					pnt6D2 = new Pnt6D(list[k][l]);
					orientationAngle2 = new OrientationAngle(pnt6D2);
					pnt6D4 = new Pnt6D();
					pnt3D4 = new Pnt3D(pnt6D2);
					buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D4), ref pnt6D4);
					pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D4, feed, 1));
					camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D4), Color.Blue));
					pnt3D = new Pnt3D(pnt6D2);
					new Pnt6D(pnt6D4);
					orientationAngle = new OrientationAngle(orientationAngle2);
				}
				safe = (camParameter.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				stepUp = (camParameter.Operations.Thickness + camParameter.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
				flag = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
				if (k == list.Count - 1)
				{
					flag = true;
				}
				pnt6D4 = new Pnt6D();
				pnt3D3 = new Pnt3D();
				pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + stepUp);
				buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), stepUp, ref pnt3D3);
				buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
				pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
				camPoint.Points.Add(new Pnt9DCam(pnt6D4, camParameter.Speeds.Leave, 1));
				camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Red));
				num13 = camParameter.Operations.Thickness + camParameter.Distances.StepUp;
				orientationAngle = new OrientationAngle(orientationAngle2);
				if (flag)
				{
					pnt6D4 = new Pnt6D();
					pnt3D3 = new Pnt3D();
					pnt3D4 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z + safe);
					buAppCalc.cVector.LineWithOrientationAngle(pnt3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), safe, ref pnt3D3);
					buAppCalc.cKinematic.ForwardKinematix5Ax(num14, Kinematic, orientationAngle2, new Pnt3D(pnt3D3), ref pnt6D4);
					pnt6D4.Z = pnt6D4.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camPoint.Points.Add(new Pnt9DCam(pnt6D4, camParameter.Speeds.Rapid, 0));
					camPoint.EntitiesG0.Add(new geoLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D3), Color.Gold));
					num13 = camParameter.Distances.Safe;
				}
				pnt6D = new Pnt6D(pnt6D4);
				if (k != list.Count - 1)
				{
				}
				if (camPoint.Points.Count > 0)
				{
					camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[0]));
				}
				for (int m = 1; m <= camPoint.Points.Count - 1; m++)
				{
					List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
					double dt = 0.1;
					if (camPoint.Points[m].Type == 0)
					{
						dt = 0.25;
					}
					double num15 = buAppCalc.cVector.Length3D(new Pnt3D(camPoint.Points[m - 1]), new Pnt3D(camPoint.Points[m]));
					if (!(num15 > 3.0))
					{
						camPoint.SimilationPoint.SimPoints.Add(new Pnt6D(camPoint.Points[m]));
						continue;
					}
					buAppCalc.cVector.LineerInterpolation(new Pnt6D(camPoint.Points[m - 1]), new Pnt6D(camPoint.Points[m]), dt, ref CalculatedPoints);
					CalculatedPoints.RemoveAt(0);
					camPoint.SimilationPoint.SimPoints.AddRange(CalculatedPoints);
				}
				calcCam.CamPoints.Add(camPoint);
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)k / (double)(list.Count - 1)) * 100.0, Convert.ToDouble((double)k / (double)(list.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && num11 > 0 && num12 > 0 && num12 % num11 == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num12++;
					continue;
				}
				buSystem.Cancel = false;
				buSystem.Canceled = true;
				if (calculationEventHandler_2 != null)
				{
					calculationEventHandler_2(new CalculationEventArg());
				}
				if (calculationEventHandler_3 != null)
				{
					calculationEventHandler_3(new CalculationEventArg(0.0, 0.0, 0, "Calculate Marble WireFrame", ""));
				}
				buLog.addLog("Calculate Marble WireFrame", "Canceled", MethodBase.GetCurrentMethod().Name);
				return;
			}
			if (calculationEventHandler_2 != null)
			{
				calculationEventHandler_2(new CalculationEventArg());
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void camClosedContour(Pnt3D StartPoint, List<List<Pnt3D>> RefPoints, double Offset, bool AfterFirstPointReverseOffsetDirection, CamClosedContourType CamDirection, ClockDirectionType ClockDirection, OffsetCornerType CornerType, ToolBase Tool, WorkPlane Plane, camSpeeds Speed, camDistances Distance, camStep Steps, camOperation Operation, camOptions Options, ref camBase CamCalculated)
	{
		try
		{
			List<List<eEntities>> list = new List<List<eEntities>>();
			for (int i = 0; i <= RefPoints.Count - 1; i++)
			{
				List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
				if (CamDirection == CamClosedContourType.Center)
				{
					List<Pnt3D> CopiedPnt = new List<Pnt3D>();
					Pnt3D.Copy(RefPoints[i], ref CopiedPnt);
					OffsetedPoints.Add(CopiedPnt);
				}
				else if (AfterFirstPointReverseOffsetDirection)
				{
					if (i != 0)
					{
						buAppCalc.cVector.OffsetContour(RefPoints[i], 0.0 - Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
					}
					else
					{
						buAppCalc.cVector.OffsetContour(RefPoints[i], Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
					}
				}
				else
				{
					buAppCalc.cVector.OffsetContour(RefPoints[i], Offset, CornerType, CamOpenContourType2.Center, Plane, Operation.Height, ref OffsetedPoints);
				}
				for (int j = 0; j <= OffsetedPoints.Count - 1; j++)
				{
					List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
					Pnt3D.Copy(OffsetedPoints[j], ref CopiedPnt2);
					buAppCalc.cVector.ShiftPointsByLength(RefPoints[i][0], ref CopiedPnt2);
					OffsetedPoints[j] = CopiedPnt2;
				}
				for (int k = 0; k <= OffsetedPoints.Count - 1; k++)
				{
					ClockDirectionType clockDirectionType = ClockDirectionType.CW;
					clockDirectionType = buAppCalc.cVector.PolygonDirection(OffsetedPoints[k], Plane);
					if ((clockDirectionType != ClockDirection) & (OffsetedPoints[k].Count > 2))
					{
						OffsetedPoints[k].Reverse();
					}
					List<eEntities> CalcEntities = new List<eEntities>();
					buAppCalc.cVector.PointsToEntities(OffsetedPoints[k], Plane, buSystem.PointsToEntities, ref CalcEntities);
					list.Add(CalcEntities);
				}
				OffsetedPoints.Clear();
			}
			if (CamDirection == CamClosedContourType.Center)
			{
				CamCalculated.CamType = CamType.ContourClosedCenter;
			}
			if (CamDirection == CamClosedContourType.Outter)
			{
				CamCalculated.CamType = CamType.ContourClosedOutside;
			}
			if (CamDirection == CamClosedContourType.Inner)
			{
				CamCalculated.CamType = CamType.ContourClosedInside;
			}
			CamCalculated.Name = "Contour : " + CamDirection;
			new CamPoint();
			if (Operation.StepHeights.Count == 0)
			{
				Operation.StepHeights.Add(Operation.Height);
			}
			bool isFirst = true;
			bool isLast = false;
			bool flag = false;
			bool flag2 = false;
			if (Steps.Sequence == CamMachiningSequenceType.Level)
			{
				Pnt6D nextContourStartPoint = new Pnt6D();
				List<Pnt3D> Points = new List<Pnt3D>();
				for (int l = 0; l <= Operation.StepHeights.Count - 1; l++)
				{
					flag2 = true;
					for (int m = 0; m <= list.Count - 1; m++)
					{
						if ((l == Operation.StepHeights.Count - 1) & (m == list.Count - 1))
						{
							isLast = true;
						}
						if (m >= list.Count - 1)
						{
							Points.Clear();
							buAppCalc.cVector.EntityToPoint(list[0], new EntityResolution(), ref Points);
							if (Points.Count > 0)
							{
								nextContourStartPoint = new Pnt6D(Points[0]);
							}
						}
						else
						{
							Points.Clear();
							buAppCalc.cVector.EntityToPoint(list[m + 1], new EntityResolution(), ref Points);
							if (Points.Count > 0)
							{
								nextContourStartPoint = new Pnt6D(Points[0]);
							}
						}
						flag = true;
						camContourCalculation(list[m], nextContourStartPoint, Operation.StepHeights[l], Tool, isFirst, isContourToContour: true, flag2, isLast, ref CamCalculated, Speed, Distance, Steps, Operation, Options);
						isFirst = false;
						flag2 = false;
					}
				}
			}
			if (Steps.Sequence == CamMachiningSequenceType.Region)
			{
				Pnt6D nextContourStartPoint2 = new Pnt6D();
				List<Pnt3D> Points2 = new List<Pnt3D>();
				for (int n = 0; n <= list.Count - 1; n++)
				{
					flag = true;
					if (n < list.Count - 1)
					{
						Points2.Clear();
						buAppCalc.cVector.EntityToPoint(list[n + 1], new EntityResolution(), ref Points2);
						if (Points2.Count > 0)
						{
							nextContourStartPoint2 = new Pnt6D(Points2[0]);
						}
					}
					for (int num = 0; num <= Operation.StepHeights.Count - 1; num++)
					{
						if ((num == Operation.StepHeights.Count - 1) & (n == list.Count - 1))
						{
							isLast = true;
						}
						if (num >= Operation.StepHeights.Count - 1)
						{
							if (n < list.Count - 1)
							{
								Points2.Clear();
								buAppCalc.cVector.EntityToPoint(list[n + 1], new EntityResolution(), ref Points2);
								if (Points2.Count > 0)
								{
									nextContourStartPoint2 = new Pnt6D(Points2[0]);
									if (!buAppCalc.cVector.IsClosed(Points2) & Steps.Enable & !Steps.MoveUpEnable & (num % 2 == 0))
									{
										nextContourStartPoint2 = new Pnt6D(Points2[Points2.Count - 1]);
									}
								}
							}
						}
						else
						{
							Points2.Clear();
							buAppCalc.cVector.EntityToPoint(list[n], new EntityResolution(), ref Points2);
							if (Points2.Count > 0)
							{
								nextContourStartPoint2 = new Pnt6D(Points2[0]);
								if (!buAppCalc.cVector.IsClosed(Points2) & Steps.Enable & !Steps.MoveUpEnable & (num % 2 == 0))
								{
									nextContourStartPoint2 = new Pnt6D(Points2[Points2.Count - 1]);
								}
							}
						}
						List<eEntities> CopiedEnt = new List<eEntities>();
						eEntities.CopyEntities(list[n], ref CopiedEnt);
						if (!buAppCalc.cVector.IsEntitiesClosedPath(CopiedEnt) & Steps.Enable & !Steps.MoveUpEnable & (num % 2 == 1))
						{
							buAppCalc.cVector.ReverseEntitiesDirection(ref CopiedEnt);
							CopiedEnt.Reverse();
						}
						flag2 = true;
						camContourCalculation(CopiedEnt, nextContourStartPoint2, Operation.StepHeights[num], Tool, isFirst, flag, isStep: true, isLast, ref CamCalculated, Speed, Distance, Steps, Operation, Options);
						isFirst = false;
						flag = false;
					}
				}
			}
			list.Clear();
		}
		catch (Exception mSException)
		{
			string text = "StartPoint: " + StartPoint.ToString() + " - RefPoints: " + RefPoints.Count + " - Offset: " + Offset;
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void camContourCalculation(List<eEntities> OffsetedEntities, Pnt6D NextContourStartPoint, double Height, ToolBase Tool, bool isFirst, bool isContourToContour, bool isStep, bool isLast, ref camBase CamCalculated, camSpeeds Speed, camDistances Distance, camStep Steps, camOperation Operation, camOptions Options)
	{
		Pnt9DCam pnt9DCam = new Pnt9DCam();
		Pnt3D pnt3D = new Pnt3D();
		CamPoint CamPnt = new CamPoint();
		if (OffsetedEntities.Count > 0)
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			Pnt3D.Copy(OffsetedEntities[0].Vertice, ref CopiedPnt);
			if (OffsetedEntities[0].camDirections == camPathDirectionType.Reverse)
			{
				CopiedPnt.Reverse();
			}
			pnt3D = new Pnt3D(CopiedPnt[0]);
			CamSafeDistanceCalculation(isFirst, isContourToContour, isStep, isLast: false, isPlunge: true, isLeave: false, new Pnt6D(pnt3D), NextContourStartPoint, pnt3D.Z, Tool, Distance, Speed, Steps, Operation, ref CamPnt);
			CamCalculated.Tool = new ToolBase(Tool);
			for (int i = 0; i <= OffsetedEntities.Count - 1; i++)
			{
				CopiedPnt = new List<Pnt3D>();
				Pnt3D.Copy(OffsetedEntities[i].Vertice, ref CopiedPnt);
				Pnt3D.SetValue(Height, AxesXYZ.Z, ref CopiedPnt);
				if (OffsetedEntities[i].camDirections == camPathDirectionType.Reverse)
				{
					CopiedPnt.Reverse();
				}
				if (i == 0)
				{
					pnt3D = new Pnt3D(Pnt9LastPoint.X, Pnt9LastPoint.Y, Height);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z), Speed.Plunge, 1);
					CamPnt.Points.Add(pnt9DCam);
					CamPnt.EntitiesG1.Add(new geoLine(new Pnt3D(Pnt9LastPoint), pnt3D, Tool.Display.PlungeColor, Tool.Display.PlungeThickness));
					CamPnt.EntitiesPlunge.Add(new geoLine(new Pnt3D(Pnt9LastPoint), pnt3D, Tool.Display.PlungeColor, Tool.Display.PlungeThickness));
					Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
				}
				if (!(OffsetedEntities[i].GetType() != typeof(eArc)))
				{
					Pnt3D centerPoint = new Pnt3D(((eArc)OffsetedEntities[i]).CenterPoint.X, ((eArc)OffsetedEntities[i]).CenterPoint.Y, Height);
					eArc eArc2 = new eArc(centerPoint, ((eArc)OffsetedEntities[i]).Radius, ((eArc)OffsetedEntities[i]).StartAngle, ((eArc)OffsetedEntities[i]).EndAngle, ((eArc)OffsetedEntities[i]).Plane);
					int num = 3;
					if (OffsetedEntities[i].camDirections == camPathDirectionType.Reverse)
					{
						num = 2;
					}
					pnt3D = new Pnt3D(CopiedPnt[CopiedPnt.Count - 1].X, CopiedPnt[CopiedPnt.Count - 1].Y, Height);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z), Speed.Feed, num);
					pnt9DCam.Radius = eArc2.Radius;
					pnt9DCam.ArcType = num;
					pnt9DCam.ArcData = new geoArc(eArc2.CenterPoint, eArc2.Radius, eArc2.StartAngle, eArc2.EndAngle, eArc2.Plane);
					CamPnt.Points.Add(pnt9DCam);
					CamPnt.EntitiesG1.Add(new geoPolyline(CopiedPnt, Tool.Display.CamColor, Tool.Display.CamThickness));
					Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
				}
				else
				{
					CopiedPnt.RemoveAt(0);
					for (int j = 0; j <= CopiedPnt.Count - 1; j++)
					{
						pnt3D = new Pnt3D(CopiedPnt[j].X, CopiedPnt[j].Y, Height);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z), Speed.Feed, 1);
						CamPnt.Points.Add(pnt9DCam);
						CamPnt.EntitiesG1.Add(new geoLine(new Pnt3D(Pnt9LastPoint), pnt3D, Tool.Display.CamColor, Tool.Display.CamThickness));
						Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
					}
				}
			}
			CamSafeDistanceCalculation(isFirst: false, isContourToContour, isStep, isLast, isPlunge: false, isLeave: true, new Pnt6D(Pnt9LastPoint), NextContourStartPoint, pnt3D.Z, Tool, Distance, Speed, Steps, Operation, ref CamPnt);
			SimPointCreat(CamPnt.Points, 0.25, 0.1, 3.0, ref CamPnt.SimilationPoint);
		}
		if (CamPnt.Points.Count > 0)
		{
			CamCalculated.CamPoints.Add(CamPnt);
			CamPnt = new CamPoint();
		}
	}

	public void CamSafeDistanceCalculation(bool isFirst, bool isContourToContour, bool isStep, bool isLast, bool isPlunge, bool isLeave, Pnt6D PointActual, Pnt6D PointNext, double LastZ, ToolBase Tool, camDistances Distance, camSpeeds Speed, camStep Steps, camOperation Operation, ref CamPoint CamPnt)
	{
		Pnt9DCam pnt9DCam = new Pnt9DCam();
		double num = 0.0;
		if (!isFirst)
		{
			if (!isLast)
			{
				if (!isPlunge)
				{
					if (!isLeave)
					{
						if (!(isFirst || isLast))
						{
						}
					}
					else if (!Pnt3D.EqualXY(new Pnt3D(PointActual), new Pnt3D(PointNext.X, PointNext.Y, PointNext.Z)) || Operation.SafeLeaveForIfLastAndNextPointSameXY != CamSafeForLeave.NotMove)
					{
						if ((Operation.SafeLeaveForContoutToContour == CamSafeForLeave.Air) | (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SafeThenAir) | (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafeThenAir))
						{
							num = Distance.Air;
							pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.LeaveAxisMovement = true;
							CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
							CamPnt.Points.Add(pnt9DCam);
						}
						if ((Operation.SafeLeaveForContoutToContour == CamSafeForLeave.Safe) | (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafeThenSafe))
						{
							num = Distance.Safe;
							pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.LeaveAxisMovement = true;
							CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
							CamPnt.Points.Add(pnt9DCam);
						}
						if (Operation.SafeLeaveForContoutToContour == CamSafeForLeave.SmallSafe)
						{
							num = Distance.SafeSmall;
							pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.LeaveAxisMovement = true;
							CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
							CamPnt.Points.Add(pnt9DCam);
						}
						Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
					}
				}
				else if (!Pnt3D.EqualXY(new Pnt3D(PointActual), new Pnt3D(Pnt9LastPoint.X, Pnt9LastPoint.Y, Pnt9LastPoint.Z)) || Operation.SafePlungeForIfLastAndNextPointSameXY != CamSafeForPlunge.NotMove)
				{
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.Air)
					{
						num = Distance.Air;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
					}
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.AirThenSafe)
					{
						num = Distance.Air;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
						num = Distance.Safe;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
					}
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.AirThenSmallSafe)
					{
						num = Distance.Air;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
						num = Distance.SafeSmall;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
					}
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.Safe)
					{
						num = Distance.Safe;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
					}
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
					{
						num = Distance.Safe;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
						num = Distance.SafeSmall;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
					}
					if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SmallSafe)
					{
						num = Distance.SafeSmall;
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						CamPnt.Points.Add(pnt9DCam);
						pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
						CamPnt.Points.Add(pnt9DCam);
					}
					Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
				}
			}
			else
			{
				if ((Operation.SafeLeaveForLastPoint == CamSafeForLeave.Air) | (Operation.SafeLeaveForLastPoint == CamSafeForLeave.SafeThenAir) | (Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafeThenAir))
				{
					num = Distance.Air;
					pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
					pnt9DCam.PlungeAxis = "Z";
					pnt9DCam.LeaveAxisMovement = true;
					CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
					CamPnt.Points.Add(pnt9DCam);
				}
				if ((Operation.SafeLeaveForLastPoint == CamSafeForLeave.Safe) | (Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafeThenSafe))
				{
					num = Distance.Safe;
					pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
					pnt9DCam.PlungeAxis = "Z";
					pnt9DCam.LeaveAxisMovement = true;
					CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
					CamPnt.Points.Add(pnt9DCam);
				}
				if (Operation.SafeLeaveForLastPoint == CamSafeForLeave.SmallSafe)
				{
					num = Distance.SafeSmall;
					pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
					pnt9DCam.PlungeAxis = "Z";
					pnt9DCam.LeaveAxisMovement = true;
					CamPnt.EntitiesLeave.Add(new geoLine(new Pnt3D(Pnt9LastPoint), new Pnt3D(pnt9DCam), Tool.Display.LeaveColor, Tool.Display.LeaveThickness));
					CamPnt.Points.Add(pnt9DCam);
				}
				Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
			}
		}
		else
		{
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.Air)
			{
				num = Distance.Air;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				CamPnt.Points.Add(pnt9DCam);
			}
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.AirThenSmallSafe)
			{
				num = Distance.Air;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				CamPnt.Points.Add(pnt9DCam);
				num = Distance.SafeSmall;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
			}
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.AirThenSafe)
			{
				num = Distance.Air;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				CamPnt.Points.Add(pnt9DCam);
				num = Distance.Safe;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
			}
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.Safe)
			{
				num = Distance.Safe;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				CamPnt.Points.Add(pnt9DCam);
			}
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.SafeThenSmallSafe)
			{
				num = Distance.Safe;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				CamPnt.Points.Add(pnt9DCam);
				num = Distance.SafeSmall;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Rapid, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
			}
			if (Operation.SafePlungeForFirstPoint == CamSafeForPlunge.SmallSafe)
			{
				num = Distance.SafeSmall;
				pnt9DCam = new Pnt9DCam(new Pnt6D(PointActual.X, PointActual.Y, num), Speed.Leave, 0);
				pnt9DCam.PlungeAxis = "Z";
				pnt9DCam.PlungeAxisMovement = true;
				CamPnt.Points.Add(pnt9DCam);
			}
			Pnt9LastPoint = new Pnt9D(pnt9DCam.P9);
		}
	}

	public void camPoint(List<Pnt3D> RefPoints, ToolBase Tool, WorkPlane Plane, camSpeeds Speed, camDistances Distance, camStep Steps, camOperation Operation, camOptions Options, ref camBase CamCalculated)
	{
		CamCalculated.Name = "Point  ";
		CamPoint camPoint = new CamPoint();
		Pnt9DCam pnt9DCam = new Pnt9DCam();
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D first = new Pnt3D();
		CamCalculated.CamType = CamType.Point;
		if (Operation.StepHeights.Count == 0)
		{
			Operation.StepHeights.Add(Operation.Height);
		}
		for (int i = 0; i <= RefPoints.Count - 1; i++)
		{
			camPoint = new CamPoint();
			pnt3D = new Pnt3D(RefPoints[i]);
			pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, Distance.Safe), Speed.Leave, 0);
			pnt9DCam.PlungeAxis = "Z";
			pnt9DCam.PlungeAxisMovement = true;
			camPoint.Points.Add(pnt9DCam);
			for (int j = 0; j <= Operation.StepHeights.Count - 1; j++)
			{
				if (j == 0)
				{
					pnt3D = new Pnt3D(RefPoints[i]);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, Distance.Safe), Speed.Rapid, 0);
					camPoint.Points.Add(pnt9DCam);
					first = new Pnt3D(pnt3D.X, pnt3D.Y, Distance.Safe);
					pnt3D = new Pnt3D(RefPoints[i]);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, Distance.SafeSmall), Speed.Rapid, 0);
					pnt9DCam.PlungeAxis = "Z";
					pnt9DCam.PlungeAxisMovement = true;
					camPoint.Points.Add(pnt9DCam);
					first = new Pnt3D(pnt3D.X, pnt3D.Y, Distance.Safe);
				}
				pnt3D = new Pnt3D(RefPoints[i].X, RefPoints[i].Y, Operation.StepHeights[j]);
				pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z), Speed.Plunge, 1);
				camPoint.Points.Add(pnt9DCam);
				camPoint.EntitiesG1.Add(new geoLine(first, pnt3D));
				camPoint.EntitiesOther.Add(new geoCircle(pnt3D, Tool.Geometry.Diameter / 2.0));
				first = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
				if (j >= Operation.StepHeights.Count - 1)
				{
					pnt3D = new Pnt3D(RefPoints[i]);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, Distance.Safe), Speed.Rapid, 0);
					camPoint.Points.Add(pnt9DCam);
					first = new Pnt3D(pnt3D.X, pnt3D.Y, Distance.Safe);
				}
				else
				{
					pnt3D = new Pnt3D(RefPoints[i]);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D.X, pnt3D.Y, first.Z + Steps.MoveUp), Speed.Rapid, 0);
					camPoint.Points.Add(pnt9DCam);
					first = new Pnt3D(pnt3D.X, pnt3D.Y, first.Z + Steps.MoveUp);
				}
			}
			SimPointCreat(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
			if (camPoint.Points.Count > 0)
			{
				CamCalculated.CamPoints.Add(camPoint);
				camPoint = new CamPoint();
			}
		}
	}

	public void camPocketCircular(ContourPoints RefPoint, double Offset, OffsetCornerType CornerTypes, camPocket Pocket, WorkPlane Plane, double PlaneOffset, ClockDirectionType NeededDirection, camSpeeds Speed, camDistances Distance, camStep Steps, camOperation Operation, camOptions Options, ref camBase CamCalculated, ref List<PocketPoints> Pockets, ref List<List<eEntities>> PocketEntities)
	{
		if (Offset > 0.0)
		{
			Offset *= -1.0;
		}
		int num = 0;
		bool flag = false;
		bool flag2 = true;
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt = new Pnt3D();
		List<Pnt3D> CopiedPnt = new List<Pnt3D>();
		List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
		List<List<Pnt3D>> list = new List<List<Pnt3D>>();
		List<List<Pnt3D>> list2 = new List<List<Pnt3D>>();
		List<List<Pnt3D>> CopiedPnt3 = new List<List<Pnt3D>>();
		PocketPoints pocketPoints = new PocketPoints();
		List<eEntities> list3 = new List<eEntities>();
		if (flag = buAppCalc.cVector.IsClosed(RefPoint.Outter))
		{
			Pnt3D.Copy(RefPoint.Outter, ref CopiedPnt);
		}
		for (int i = 0; i <= RefPoint.Holes.Count - 1; i++)
		{
			if (flag = buAppCalc.cVector.IsClosed(RefPoint.Holes[i]))
			{
				List<Pnt3D> CopiedPnt4 = new List<Pnt3D>();
				Pnt3D.Copy(RefPoint.Holes[i], ref CopiedPnt4);
				list.Add(CopiedPnt4);
			}
		}
		if (CopiedPnt.Count <= 0)
		{
			return;
		}
		pnt3D = new Pnt3D(CopiedPnt[0]);
		Pnt3D.Copy(CopiedPnt, ref CopiedPnt2);
		CopiedPnt3.Add(CopiedPnt2);
		do
		{
			List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
			List<List<Pnt3D>> TargetList = new List<List<Pnt3D>>();
			List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
			if (num != 0)
			{
				for (int j = 0; j <= CopiedPnt3.Count - 1; j++)
				{
					if (list.Count != 0)
					{
						buAppCalc.cVector.OffsetContour(CopiedPnt3[j], list, Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
					}
					else
					{
						buAppCalc.cVector.OffsetContour(CopiedPnt3[j], Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
					}
					Pnt3D.Add(OffsetedPoints, ref TargetList);
				}
			}
			else
			{
				for (int k = 0; k <= CopiedPnt3.Count - 1; k++)
				{
					if (list.Count != 0)
					{
						buAppCalc.cVector.OffsetContour(CopiedPnt3[k], list, Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
					}
					else
					{
						buAppCalc.cVector.OffsetContour(CopiedPnt3[k], Offset, CornerTypes, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
					}
					List<eEntities> CalcEnt = new List<eEntities>();
					buAppCalc.cVector.AddPointOffsetedPath(OffsetedPoints, CopiedPnt2, Offset, flag, NeededDirection, 0.1, ref CalcEnt);
					for (int l = 0; l <= CalcEnt.Count - 1; l++)
					{
						CopiedPnt5 = new List<Pnt3D>();
						Pnt3D.Copy(CalcEnt[l].Vertice, ref CopiedPnt5);
						buAppCalc.cVector.ShiftPointsByLength(pnt3D, ref CopiedPnt5);
						CopiedPnt5.Add(new Pnt3D(CopiedPnt5[0]));
						buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref CopiedPnt5);
						TargetList.Add(CopiedPnt5);
					}
					if (TargetList.Count <= 1)
					{
						continue;
					}
					for (int m = 0; m <= TargetList.Count - 1; m++)
					{
						for (int n = 1; n <= TargetList.Count - 1; n++)
						{
							double num2 = buAppCalc.cVector.Length3D(pnt3D, TargetList[n][0]);
							double num3 = buAppCalc.cVector.Length3D(pnt3D, TargetList[n - 1][0]);
							if (num2 < num3)
							{
								List<Pnt3D> CopiedPnt6 = new List<Pnt3D>();
								List<Pnt3D> CopiedPnt7 = new List<Pnt3D>();
								Pnt3D.Copy(TargetList[n - 1], ref CopiedPnt6);
								Pnt3D.Copy(TargetList[n], ref CopiedPnt7);
								TargetList[n - 1] = CopiedPnt7;
								TargetList[n] = CopiedPnt6;
							}
						}
					}
				}
			}
			num++;
			CopiedPnt3.Clear();
			if (TargetList.Count == 1)
			{
				if (pocketPoints.Pockets.Count <= 0)
				{
					Pnt3D.Copy(TargetList, ref CopiedPnt5);
				}
				else
				{
					CopiedPnt5 = new List<Pnt3D>();
					Pnt3D.Copy(TargetList, ref CopiedPnt5);
					buAppCalc.cVector.ShiftPointsByLength(new Pnt3D(pnt), ref CopiedPnt5);
					CopiedPnt5.Add(new Pnt3D(CopiedPnt5[0]));
					buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref CopiedPnt5);
				}
				Pnt3D.Copy(TargetList, ref CopiedPnt3);
				ClockDirectionType clockDirectionType = buAppCalc.cVector.PolygonDirection(CopiedPnt5, new WorkPlane());
				if (clockDirectionType != NeededDirection)
				{
					CopiedPnt5.Reverse();
				}
				new List<eEntities>();
				pocketPoints.Pockets.Add(CopiedPnt5);
				list3 = new List<eEntities>();
				new PointsToEntitiesPar();
				buAppCalc.cVector.PointsToEntities(CopiedPnt5, Plane, buSystem.PointsToEntities, ref list3);
				PocketEntities.Add(list3);
				pnt = new Pnt3D(CopiedPnt5[CopiedPnt5.Count - 1]);
			}
			if (TargetList.Count > 1)
			{
				CopiedPnt5 = new List<Pnt3D>();
				Pnt3D.Copy(TargetList[0], ref CopiedPnt5);
				buAppCalc.cVector.ShiftPointsByLength(new Pnt3D(pnt), ref CopiedPnt5);
				CopiedPnt5.Add(new Pnt3D(CopiedPnt5[0]));
				buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref CopiedPnt5);
				pocketPoints.Pockets.Add(CopiedPnt5);
				list3 = new List<eEntities>();
				new PointsToEntitiesPar();
				buAppCalc.cVector.PointsToEntities(CopiedPnt5, Plane, buSystem.PointsToEntities, ref list3);
				PocketEntities.Add(list3);
				CopiedPnt3.Add(CopiedPnt5);
				pnt = new Pnt3D(CopiedPnt5[CopiedPnt5.Count - 1]);
				for (int num4 = 1; num4 <= TargetList.Count - 1; num4++)
				{
					ClockDirectionType clockDirectionType2 = buAppCalc.cVector.PolygonDirection(TargetList[num4], new WorkPlane());
					if (clockDirectionType2 != NeededDirection)
					{
						TargetList[num4].Reverse();
					}
					CopiedPnt5 = new List<Pnt3D>();
					Pnt3D.Copy(TargetList[num4], ref CopiedPnt5);
					if (!buAppCalc.cVector.IsPointsSame(list2, CopiedPnt5))
					{
						list2.Add(CopiedPnt5);
					}
				}
			}
			if ((TargetList.Count == 0) & (list2.Count == 0))
			{
				flag2 = false;
			}
			if ((TargetList.Count == 0) & (list2.Count > 0))
			{
				CopiedPnt.Clear();
				CopiedPnt5 = new List<Pnt3D>();
				ClockDirectionType clockDirectionType3 = buAppCalc.cVector.PolygonDirection(list2[0], new WorkPlane());
				if (clockDirectionType3 != NeededDirection)
				{
					list2[0].Reverse();
				}
				Pnt3D.Copy(list2[0], ref CopiedPnt5);
				pocketPoints.Pockets.Add(CopiedPnt5);
				list3 = new List<eEntities>();
				PointsToEntitiesPar pars = new PointsToEntitiesPar();
				buAppCalc.cVector.PointsToEntities(CopiedPnt5, Plane, pars, ref list3);
				PocketEntities.Add(list3);
				CopiedPnt3.Add(CopiedPnt5);
				list2.RemoveAt(0);
			}
			TargetList.Clear();
		}
		while (flag2);
		Pockets.Add(pocketPoints);
		CamCalculated.Name = "Pocket : " + NeededDirection;
		CamPoint camPoint = new CamPoint();
		Pnt9DCam pnt9DCam = new Pnt9DCam();
		Pnt3D pnt3D2 = new Pnt3D();
		Pnt3D pnt3D3 = new Pnt3D();
		bool flag3 = false;
		if (Operation.StepHeights.Count == 0)
		{
			Operation.StepHeights.Add(Operation.Height);
		}
		camPoint = new CamPoint();
		for (int num5 = 0; num5 <= Operation.StepHeights.Count - 1; num5++)
		{
			flag3 = true;
			if (Pocket.UsePoints)
			{
				for (int num6 = 0; num6 <= pocketPoints.Pockets.Count - 1; num6++)
				{
					bool flag4 = false;
					Pnt3D endPoint = new Pnt3D();
					if (num6 < pocketPoints.Pockets.Count - 1 && pocketPoints.Pockets[num6 + 1].Count > 1)
					{
						flag4 = true;
						endPoint = new Pnt3D(pocketPoints.Pockets[num6 + 1][0]);
					}
					if (pocketPoints.Pockets[num6].Count <= 0)
					{
						continue;
					}
					List<Pnt3D> CopiedPnt8 = new List<Pnt3D>();
					Pnt3D.Copy(pocketPoints.Pockets[num6], ref CopiedPnt8);
					Pnt3D.SetValue(Operation.StepHeights[num5], AxesXYZ.Z, ref CopiedPnt8);
					if (flag3)
					{
						double z = Distance.Safe;
						if ((num5 > 0) & Operation.PocketStepToStepSmallSafe)
						{
							z = Distance.SafeSmall;
						}
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, z), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						camPoint.Points.Add(pnt9DCam);
						pnt3D2 = new Pnt3D(CopiedPnt8[0]);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, z), Speed.Rapid, 0);
						camPoint.Points.Add(pnt9DCam);
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, z);
						if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
						{
							pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.SafeSmall), Speed.Rapid, 0);
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.PlungeAxisMovement = true;
							camPoint.Points.Add(pnt9DCam);
							pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, Distance.SafeSmall);
						}
						pnt3D2 = new Pnt3D(CopiedPnt8[0].X, CopiedPnt8[0].Y, Operation.StepHeights[num5]);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Plunge, 1);
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(pnt3D3, pnt3D2));
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
						CopiedPnt8.RemoveAt(0);
					}
					for (int num7 = 0; num7 <= CopiedPnt8.Count - 1; num7++)
					{
						pnt3D2 = new Pnt3D(CopiedPnt8[num7].X, CopiedPnt8[num7].Y, Operation.StepHeights[num5]);
						pnt3D3 = new Pnt3D(pnt3D2);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, 1);
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(pnt3D3, pnt3D2));
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
					}
					flag3 = false;
					if (flag4)
					{
						double num8 = buAppCalc.cVector.Length3D(pnt3D3, endPoint, Plane);
						double pocketNextContourMaxDistance = Options.PocketNextContourMaxDistance;
						if (pocketNextContourMaxDistance <= 0.0)
						{
							pocketNextContourMaxDistance = double.MaxValue;
						}
						if ((buAppCalc.cVector.IsLineIntersectContourPoints(pnt3D3, endPoint, RefPoint, Plane) | (num8 > Math.Abs(Offset) * 2.0)) && camPoint.Points.Count > 0)
						{
							pnt3D2 = new Pnt3D(pnt3D3);
							pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.Safe), Speed.Leave, 0);
							camPoint.Points.Add(pnt9DCam);
							SimPointCreat(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
							CamCalculated.CamPoints.Add(camPoint);
							camPoint = new CamPoint();
							flag3 = true;
						}
					}
				}
			}
			if (!Pocket.UsePoints)
			{
				Pnt9DCam pnt9DCam2 = new Pnt9DCam();
				for (int num9 = 0; num9 <= PocketEntities.Count - 1; num9++)
				{
					bool flag5 = false;
					Pnt3D endPoint2 = new Pnt3D();
					Pnt3D pnt3D4 = new Pnt3D();
					if (num9 < PocketEntities.Count - 1 && PocketEntities[num9 + 1].Count > 1)
					{
						flag5 = true;
						endPoint2 = ((PocketEntities[num9 + 1][0].camDirections == camPathDirectionType.Normal) ? new Pnt3D(PocketEntities[num9 + 1][0].Vertice[0]) : new Pnt3D(PocketEntities[num9 + 1][0].Vertice[PocketEntities[num9 + 1][0].Vertice.Count - 1]));
					}
					if (PocketEntities[num9].Count <= 0)
					{
						continue;
					}
					pnt3D4 = ((PocketEntities[num9][0].camDirections == camPathDirectionType.Normal) ? new Pnt3D(PocketEntities[num9][0].Vertice[0]) : new Pnt3D(PocketEntities[num9][0].Vertice[PocketEntities[num9][0].Vertice.Count - 1]));
					if (!flag3)
					{
						pnt3D2 = new Pnt3D(pnt3D4.X, pnt3D4.Y, Operation.StepHeights[num5]);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, 1);
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(pnt3D3, pnt3D2));
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
						Pnt9LastPoint = new Pnt9D(pnt3D3);
					}
					else
					{
						double z2 = Distance.Safe;
						if ((num5 > 0) & Operation.PocketStepToStepSmallSafe)
						{
							z2 = Distance.SafeSmall;
						}
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, z2), Speed.Rapid, 0);
						pnt9DCam.PlungeAxis = "Z";
						pnt9DCam.PlungeAxisMovement = true;
						camPoint.Points.Add(pnt9DCam);
						pnt3D2 = new Pnt3D(pnt3D4);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, z2), Speed.Rapid, 0);
						camPoint.Points.Add(pnt9DCam);
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, z2);
						if (Operation.SafePlungeForContoutToContour == CamSafeForPlunge.SafeThenSmallSafe)
						{
							pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.SafeSmall), Speed.Rapid, 0);
							pnt9DCam.PlungeAxis = "Z";
							pnt9DCam.PlungeAxisMovement = true;
							camPoint.Points.Add(pnt9DCam);
							pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, Distance.SafeSmall);
						}
						pnt3D2 = new Pnt3D(pnt3D4.X, pnt3D4.Y, Operation.StepHeights[num5]);
						pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Plunge, 1);
						camPoint.Points.Add(pnt9DCam);
						camPoint.EntitiesG1.Add(new geoLine(pnt3D3, pnt3D2));
						pnt3D3 = new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z);
						Pnt9LastPoint = new Pnt9D(pnt3D3);
					}
					for (int num10 = 0; num10 <= PocketEntities[num9].Count - 1; num10++)
					{
						List<Pnt3D> CopiedPnt9 = new List<Pnt3D>();
						Pnt3D.Copy(PocketEntities[num9][num10].Vertice, ref CopiedPnt9);
						Pnt3D.SetValue(Operation.StepHeights[num5], AxesXYZ.Z, ref CopiedPnt9);
						if (PocketEntities[num9][num10].camDirections == camPathDirectionType.Reverse)
						{
							CopiedPnt9.Reverse();
						}
						if (!(PocketEntities[num9][num10].GetType() != typeof(eArc)))
						{
							Pnt3D centerPoint = new Pnt3D(((eArc)PocketEntities[num9][num10]).CenterPoint.X, ((eArc)PocketEntities[num9][num10]).CenterPoint.Y, Operation.StepHeights[num5]);
							eArc eArc2 = new eArc(centerPoint, ((eArc)PocketEntities[num9][num10]).Radius, ((eArc)PocketEntities[num9][num10]).StartAngle, ((eArc)PocketEntities[num9][num10]).EndAngle, ((eArc)PocketEntities[num9][num10]).Plane);
							int num11 = 3;
							if (PocketEntities[num9][num10].camDirections == camPathDirectionType.Reverse)
							{
								num11 = 2;
							}
							pnt3D2 = new Pnt3D(CopiedPnt9[CopiedPnt9.Count - 1].X, CopiedPnt9[CopiedPnt9.Count - 1].Y, Operation.StepHeights[num5]);
							pnt9DCam2 = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, num11);
							pnt9DCam2.Radius = eArc2.Radius;
							pnt9DCam2.ArcType = num11;
							pnt9DCam2.ArcData = new geoArc(eArc2.CenterPoint, eArc2.Radius, eArc2.StartAngle, eArc2.EndAngle, eArc2.Plane);
							camPoint.Points.Add(pnt9DCam2);
							camPoint.EntitiesG1.Add(new geoPolyline(CopiedPnt9));
							Pnt9LastPoint = new Pnt9D(pnt9DCam2.P9);
						}
						else
						{
							CopiedPnt9.RemoveAt(0);
							for (int num12 = 0; num12 <= CopiedPnt9.Count - 1; num12++)
							{
								pnt3D2 = new Pnt3D(CopiedPnt9[num12].X, CopiedPnt9[num12].Y, Operation.StepHeights[num5]);
								pnt9DCam2 = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), Speed.Feed, 1);
								camPoint.Points.Add(pnt9DCam2);
								camPoint.EntitiesG1.Add(new geoLine(new Pnt3D(Pnt9LastPoint), pnt3D2));
								Pnt9LastPoint = new Pnt9D(pnt9DCam2.P9);
							}
						}
					}
					flag3 = false;
					if (flag5)
					{
						double num13 = buAppCalc.cVector.Length3D(pnt3D3, endPoint2, Plane);
						double pocketNextContourMaxDistance2 = Options.PocketNextContourMaxDistance;
						if (pocketNextContourMaxDistance2 <= 0.0)
						{
							pocketNextContourMaxDistance2 = double.MaxValue;
						}
						if ((buAppCalc.cVector.IsLineIntersectContourPoints(pnt3D3, endPoint2, RefPoint, Plane) | (num13 > Math.Abs(Offset) * 2.0)) && camPoint.Points.Count > 0)
						{
							pnt3D2 = new Pnt3D(pnt3D3);
							pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.Safe), Speed.Leave, 0);
							camPoint.Points.Add(pnt9DCam);
							SimPointCreat(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
							CamCalculated.CamPoints.Add(camPoint);
							camPoint = new CamPoint();
							flag3 = true;
						}
					}
				}
				if (camPoint.Points.Count > 0)
				{
					pnt3D2 = new Pnt3D(pnt3D3);
					pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, Distance.Safe), Speed.Leave, 0);
					camPoint.Points.Add(pnt9DCam);
					SimPointCreat(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
					CamCalculated.CamPoints.Add(camPoint);
					camPoint = new CamPoint();
					flag3 = true;
				}
			}
			if (camPoint.Points.Count > 0)
			{
				double z3 = Distance.Safe;
				if ((num5 < Operation.StepHeights.Count - 1) & Operation.PocketStepToStepSmallSafe)
				{
					z3 = Distance.SafeSmall;
				}
				pnt3D2 = new Pnt3D(pnt3D3);
				pnt9DCam = new Pnt9DCam(new Pnt6D(pnt3D2.X, pnt3D2.Y, z3), Speed.Leave, 0);
				camPoint.Points.Add(pnt9DCam);
				SimPointCreat(camPoint.Points, 0.25, 0.1, 3.0, ref camPoint.SimilationPoint);
			}
			if (camPoint.Points.Count > 0)
			{
				CamCalculated.CamPoints.Add(camPoint);
				camPoint = new CamPoint();
			}
		}
	}

	public void CamFlatPocket(List<Pnt3D> OutsideContour, List<List<Pnt3D>> Holes, double Step, double Offset, double PlaneOffset, CamFlatPocketType Type, CamFlatPocketSortType Sort, WorkPlane Plane, ref List<eEntities> CalcEntities)
	{
		List<List<Pnt3D>> OffsetedPoints = new List<List<Pnt3D>>();
		List<List<Pnt3D>> list = new List<List<Pnt3D>>();
		if (Step <= 0.0)
		{
			return;
		}
		buAppCalc.cVector.OffsetContour(OutsideContour, Math.Abs(Offset) * -1.0, OffsetCornerType.Line, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints);
		for (int i = 0; i <= Holes.Count - 1; i++)
		{
			List<List<Pnt3D>> OffsetedPoints2 = new List<List<Pnt3D>>();
			buAppCalc.cVector.OffsetContour(Holes[i], Math.Abs(Offset), OffsetCornerType.Line, CamOpenContourType2.Closed, Plane, PlaneOffset, ref OffsetedPoints2);
			for (int j = 0; j <= OffsetedPoints2.Count - 1; j++)
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				Pnt3D.Copy(OffsetedPoints2[j], ref CopiedPnt);
				list.Add(CopiedPnt);
			}
		}
		Pnt3D MaxPoint = new Pnt3D();
		Pnt3D MinPoint = new Pnt3D();
		buAppCalc.cVector.BoxSizeCalculate(OffsetedPoints, ref MinPoint, ref MaxPoint);
		List<eLine> list2 = new List<eLine>();
		double num = MaxPoint.X - MinPoint.X + 2.0;
		double num2 = MaxPoint.Y - MinPoint.Y + 2.0;
		double num3 = 0.0;
		int num4 = 0;
		if (Type == CamFlatPocketType.Horizontal)
		{
			num4 = Convert.ToInt32(num2 / Math.Abs(Step));
			num3 = num2 / Convert.ToDouble(num4);
			for (int k = 0; k <= num4; k++)
			{
				if (k != 0)
				{
					if (!(k > 0 && k < num4))
					{
						eLine item = new eLine(new Pnt3D(MinPoint.X - 1.0, MaxPoint.Y - 1.0), new Pnt3D(MaxPoint.X + 1.0, MaxPoint.Y - 1.0));
						list2.Add(item);
					}
					else
					{
						eLine item2 = new eLine(new Pnt3D(MinPoint.X - 1.0, MinPoint.Y + (double)k * num3), new Pnt3D(MaxPoint.X + 1.0, MinPoint.Y + (double)k * num3));
						list2.Add(item2);
					}
				}
				else
				{
					eLine item3 = new eLine(new Pnt3D(MinPoint.X - 1.0, MinPoint.Y + 1.0 + (double)k * num3), new Pnt3D(MaxPoint.X + 1.0, MinPoint.Y + 1.0 + (double)k * num3));
					list2.Add(item3);
				}
			}
		}
		if (Type == CamFlatPocketType.Vertical)
		{
			num4 = Convert.ToInt32(num / Math.Abs(Step));
			num3 = num / Convert.ToDouble(num4);
			for (int l = 0; l <= num4; l++)
			{
				if (l != 0)
				{
					if (!(l > 0 && l < num4))
					{
						eLine item4 = new eLine(new Pnt3D(MaxPoint.X - 1.0, MinPoint.Y - 1.0), new Pnt3D(MaxPoint.X - 1.0, MaxPoint.Y + 1.0));
						list2.Add(item4);
					}
					else
					{
						eLine item5 = new eLine(new Pnt3D(MinPoint.X + (double)l * num3, MinPoint.Y - 1.0), new Pnt3D(MinPoint.X + (double)l * num3, MaxPoint.Y + 1.0));
						list2.Add(item5);
					}
				}
				else
				{
					eLine item6 = new eLine(new Pnt3D(MinPoint.X + 1.0, MinPoint.Y - 1.0), new Pnt3D(MinPoint.X + 1.0, MaxPoint.Y + 1.0));
					list2.Add(item6);
				}
			}
		}
		List<List<Pnt3D>> list3 = new List<List<Pnt3D>>();
		for (int m = 0; m <= list2.Count - 1; m++)
		{
			List<Pnt3D> list4 = new List<Pnt3D>();
			for (int n = 0; n <= OffsetedPoints.Count - 1; n++)
			{
				for (int num5 = 1; num5 <= OffsetedPoints[n].Count - 1; num5++)
				{
					Pnt3D IntersectionPoint = new Pnt3D();
					buAppCalc.cVector.LineLineIntersection(list2[m].StartPoint, list2[m].EndPoint, OffsetedPoints[n][num5 - 1], OffsetedPoints[n][num5], Plane, ref IntersectionPoint);
					if (!buAppCalc.cVector.IsPointInsideLine(OffsetedPoints[n][num5 - 1], OffsetedPoints[n][num5], IntersectionPoint, Plane))
					{
						if (buAppCalc.cVector.IsPointInsidePolygon(OffsetedPoints[n], IntersectionPoint))
						{
						}
					}
					else
					{
						list4.Add(IntersectionPoint);
					}
				}
			}
			for (int num6 = 0; num6 <= list.Count - 1; num6++)
			{
				for (int num7 = 1; num7 <= list[num6].Count - 1; num7++)
				{
					Pnt3D IntersectionPoint2 = new Pnt3D();
					buAppCalc.cVector.LineLineIntersection(list2[m].StartPoint, list2[m].EndPoint, list[num6][num7 - 1], list[num6][num7], Plane, ref IntersectionPoint2);
					if (buAppCalc.cVector.IsPointInsideLine(list[num6][num7 - 1], list[num6][num7], IntersectionPoint2, Plane))
					{
						list4.Add(IntersectionPoint2);
					}
				}
			}
			if (list4.Count > 0)
			{
				list3.Add(list4);
			}
		}
		List<eEntities> list5 = new List<eEntities>();
		List<eEntities> CopiedEnt = new List<eEntities>();
		CalcEntities = new List<eEntities>();
		for (int num8 = 0; num8 <= list3.Count - 1; num8++)
		{
			List<Pnt3D> CopiedPnt2 = new List<Pnt3D>();
			Pnt3D.Copy(list3[num8], ref CopiedPnt2);
			buAppCalc.cVector.CheckDuplicatedPointsWithPrevious(ref CopiedPnt2);
			if (Type == CamFlatPocketType.Horizontal)
			{
				buAppCalc.cVector.SortQuickDeltaX(MinPoint, 0, CopiedPnt2.Count - 1, ref CopiedPnt2);
			}
			if (Type == CamFlatPocketType.Vertical)
			{
				buAppCalc.cVector.SortQuickDeltaY(MinPoint, 0, CopiedPnt2.Count - 1, ref CopiedPnt2);
			}
			double num9 = CopiedPnt2.Count % 2;
			if (num9 == 1.0)
			{
				MessageBox.Show("Tek Sayı");
			}
			if (num9 == 0.0)
			{
				for (int num10 = 0; num10 <= CopiedPnt2.Count - 1; num10 += 2)
				{
					eLine item7 = new eLine(CopiedPnt2[num10], CopiedPnt2[num10 + 1]);
					list5.Add(item7);
				}
			}
		}
		int num11 = 1;
		CalcEntities.Add(eEntities.CopyEntity(list5[0]));
		Pnt3D pnt3D = new Pnt3D(list5[0].Vertice[list5[0].Vertice.Count - 1]);
		list5.RemoveAt(0);
		eEntities.CopyEntities(list5, ref CopiedEnt);
		for (int num12 = 0; num12 <= list5.Count - 1; num12++)
		{
			int num13 = -1;
			int num14 = 0;
			int index = -1;
			int num15 = 0;
			double num16 = double.MaxValue;
			double num17 = double.MaxValue;
			for (int num18 = 0; num18 <= CopiedEnt.Count - 1; num18++)
			{
				Pnt3D pnt3D2 = new Pnt3D(CopiedEnt[num18].Vertice[0]);
				Pnt3D pnt3D3 = new Pnt3D(CopiedEnt[num18].Vertice[CopiedEnt[num18].Vertice.Count - 1]);
				double num19 = buAppCalc.cVector.Length3D(pnt3D2, pnt3D);
				double num20 = buAppCalc.cVector.Length3D(pnt3D3, pnt3D);
				double num21 = buAppCalc.cVector.DeltaX(pnt3D2, pnt3D);
				double num22 = Math.Abs(buAppCalc.cVector.DeltaY(pnt3D2, pnt3D));
				double num23 = buAppCalc.cVector.DeltaX(pnt3D3, pnt3D);
				double num24 = Math.Abs(buAppCalc.cVector.DeltaY(pnt3D3, pnt3D));
				double num25 = 0.0;
				double num26 = 0.0;
				double num27 = 0.0;
				double num28 = 0.0;
				double num29 = 0.0;
				num25 = buAppCalc.cVector.PointAngle(pnt3D2, pnt3D, Plane);
				if (Type == CamFlatPocketType.Horizontal)
				{
					num27 = Math.Sin(buConversion.DegreeToRadian(num25));
					if (num27 != 0.0)
					{
						num26 = Step / num27 * 1.1;
					}
					num28 = num22;
					num29 = num24;
				}
				if (Type == CamFlatPocketType.Vertical)
				{
					num27 = Math.Cos(buConversion.DegreeToRadian(num25));
					if (num27 != 0.0)
					{
						num26 = Step / num27 * 1.1;
					}
					num28 = num21;
					num29 = num23;
				}
				if (Sort == CamFlatPocketSortType.ByClosestLength && num19 < num16 && num28 < Step * 2.0 && num19 < num26 && num11 == 0 && (!buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D, pnt3D2, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, OffsetedPoints) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D2, pnt3D, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, list)))
				{
					num16 = num19;
					num13 = num18;
					num14 = 0;
				}
				if (Sort == CamFlatPocketSortType.ByDirection && num28 < num16 && num28 < Step * 2.0 && num19 < num26 && num11 == 0 && (!buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D, pnt3D2, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, OffsetedPoints) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D2, pnt3D, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, list)))
				{
					num16 = num22;
					num13 = num18;
					num14 = 0;
				}
				num26 = 0.0;
				num25 = buAppCalc.cVector.PointAngle(pnt3D3, pnt3D, Plane);
				if (Type == CamFlatPocketType.Horizontal)
				{
					num27 = Math.Sin(buConversion.DegreeToRadian(num25));
					if (num27 != 0.0)
					{
						num26 = Step / num27 * 1.1;
					}
				}
				if (Type == CamFlatPocketType.Vertical)
				{
					num27 = Math.Cos(buConversion.DegreeToRadian(num25));
					if (num27 != 0.0)
					{
						num26 = Step / num27 * 1.1;
					}
				}
				if (Sort == CamFlatPocketSortType.ByClosestLength && num20 < num16 && num29 < Step * 2.0 && num20 < num26 && num11 == 1 && (!buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D, pnt3D3, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, OffsetedPoints) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D3, pnt3D, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, list)))
				{
					num16 = num20;
					num13 = num18;
					num14 = 1;
				}
				if (Sort == CamFlatPocketSortType.ByDirection && num29 < num16 && num29 < Step * 2.0 && num20 < num26 && num11 == 1 && (!buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D, pnt3D3, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, OffsetedPoints) & !buAppCalc.cVector.IsIntersectionLineWithPoints(pnt3D3, pnt3D, UseLineTipPoints: false, Plane, buSystem.resolutionCompare, list)))
				{
					num16 = num24;
					num13 = num18;
					num14 = 1;
				}
				if (Sort == CamFlatPocketSortType.ByClosestLength)
				{
					if (num19 < num17)
					{
						num17 = num19;
						index = num18;
						num15 = 0;
					}
					if (num20 < num17)
					{
						num17 = num20;
						index = num18;
						num15 = 1;
					}
				}
				if (Sort == CamFlatPocketSortType.ByDirection)
				{
					if (num28 < num17)
					{
						num17 = num22;
						index = num18;
						num15 = 0;
					}
					if (num29 < num17)
					{
						num17 = num24;
						index = num18;
						num15 = 1;
					}
				}
			}
			if (num13 < 0)
			{
				if (num15 == 0)
				{
					eUpperLine item8 = new eUpperLine(pnt3D, CopiedEnt[index].Vertice[0]);
					CalcEntities.Add(item8);
					eLine item9 = new eLine(CopiedEnt[index].Vertice[0], CopiedEnt[index].Vertice[CopiedEnt[index].Vertice.Count - 1]);
					CalcEntities.Add(item9);
					pnt3D = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
					num11 = 1;
				}
				if (num15 == 1)
				{
					eUpperLine item10 = new eUpperLine(pnt3D, CopiedEnt[index].Vertice[CopiedEnt[index].Vertice.Count - 1]);
					CalcEntities.Add(item10);
					eLine item11 = new eLine(CopiedEnt[index].Vertice[CopiedEnt[index].Vertice.Count - 1], CopiedEnt[index].Vertice[0]);
					CalcEntities.Add(item11);
					pnt3D = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
					num11 = 0;
				}
				CopiedEnt.RemoveAt(index);
			}
			else
			{
				if (num14 == 0)
				{
					num11 = 1;
					eLine item12 = new eLine(pnt3D, CopiedEnt[num13].Vertice[0]);
					CalcEntities.Add(item12);
					item12 = new eLine(CopiedEnt[num13].Vertice[0], CopiedEnt[num13].Vertice[CopiedEnt[num13].Vertice.Count - 1]);
					CalcEntities.Add(item12);
					pnt3D = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
				}
				if (num14 == 1)
				{
					num11 = 0;
					eLine item13 = new eLine(pnt3D, CopiedEnt[num13].Vertice[CopiedEnt[num13].Vertice.Count - 1]);
					CalcEntities.Add(item13);
					item13 = new eLine(CopiedEnt[num13].Vertice[CopiedEnt[num13].Vertice.Count - 1], CopiedEnt[num13].Vertice[0]);
					CalcEntities.Add(item13);
					pnt3D = new Pnt3D(CalcEntities[CalcEntities.Count - 1].Vertice[CalcEntities[CalcEntities.Count - 1].Vertice.Count - 1]);
				}
				CopiedEnt.RemoveAt(num13);
			}
		}
	}

	public void HatchCamCalculation(camHatch Hatch, camDistances Distances, camSpeeds Velocity, camStep Steps, camStrategy Strategy, camOperation Operations, camOptions Options, KinematicBase Kinematic, ToolBase Tool, ref camBase calcCam, ref List<eEntities> Entities)
	{
		if (Hatch.CutStep <= 0.0 || Hatch.TotalWidth <= 0.0 || Hatch.CutLength <= 0.0 || Hatch.CutStep > Hatch.TotalWidth)
		{
			return;
		}
		List<List<eEntities>> list = new List<List<eEntities>>();
		Entities.Clear();
		int num = (int)buNumeric.RoundToLower(Hatch.TotalWidth / Hatch.CutStep);
		if (num == 0)
		{
			num = 1;
		}
		double num2 = Hatch.TotalWidth / (double)num;
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			double num3 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			List<eEntities> list2 = new List<eEntities>();
			for (int i = 0; i <= num; i++)
			{
				if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					num3 = (double)i * num2;
					eEntities item = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item);
					list2.Add(item);
					list.Add(list2);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list2 = new List<eEntities>();
					Strategy.OverrideCEnable = true;
					Strategy.OverrideC = 0.0;
					num3 = (double)i * num2;
					eEntities item2 = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					item2 = new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					Entities.Add(item2);
					list2.Add(item2);
					list.Add(list2);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num3 = (double)i * num2;
					eEntities eEntities2 = null;
					if (Entities.Count > 0)
					{
						eEntities2 = new eLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D.X, num3, Hatch.OperationZ));
						Entities.Add(eEntities2);
						list2.Add(eEntities2);
					}
					if (i % 2 == 0)
					{
						eEntities2 = new eLine(new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					}
					if (i % 2 == 1)
					{
						eEntities2 = new eLine(new Pnt3D(Hatch.CornerPoint.X + Hatch.CutLength, Hatch.CornerPoint.Y + num3, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X, Hatch.CornerPoint.Y + num3, Hatch.OperationZ));
					}
					Entities.Add(eEntities2);
					list2.Add(eEntities2);
					pnt3D = new Pnt3D(eEntities2.Vertice[eEntities2.Vertice.Count - 1]);
				}
			}
			if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				Strategy.AngleLimit = 20.0;
				list.Add(list2);
			}
		}
		if (Hatch.CuttingDirection == CamHatchCuttingDirection.YDirection)
		{
			double num4 = 0.0;
			Pnt3D pnt3D2 = new Pnt3D();
			List<eEntities> list3 = new List<eEntities>();
			for (int j = 0; j <= num; j++)
			{
				if (Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					list3 = new List<eEntities>();
					num4 = (double)j * num2;
					eEntities item3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					Entities.Add(item3);
					list3.Add(item3);
					list.Add(list3);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list3 = new List<eEntities>();
					Strategy.OverrideCEnable = true;
					Strategy.OverrideC = 90.0;
					num4 = (double)j * num2;
					eEntities item4 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					item4 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ));
					Entities.Add(item4);
					list3.Add(item4);
					list.Add(list3);
				}
				if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num4 = (double)j * num2;
					eEntities eEntities3 = null;
					if (Entities.Count > 0)
					{
						eEntities3 = new eLine(new Pnt3D(pnt3D2), new Pnt3D(num4, pnt3D2.Y, Hatch.OperationZ));
						Entities.Add(eEntities3);
						list3.Add(eEntities3);
					}
					if (j % 2 == 0)
					{
						eEntities3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ));
					}
					if (j % 2 == 1)
					{
						eEntities3 = new eLine(new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y + Hatch.CutLength, Hatch.OperationZ), new Pnt3D(Hatch.CornerPoint.X + num4, Hatch.CornerPoint.Y, Hatch.OperationZ));
					}
					Entities.Add(eEntities3);
					list3.Add(eEntities3);
					pnt3D2 = new Pnt3D(eEntities3.Vertice[eEntities3.Vertice.Count - 1]);
				}
			}
			if (Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				Strategy.AngleLimit = 20.0;
				list.Add(list3);
			}
		}
		List<List<Pnt3D>> Points = new List<List<Pnt3D>>();
		List<eEntities> SortedEntities = new List<eEntities>();
		SortingOptions sortingOptions = new SortingOptions();
		sortingOptions.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
		sortingOptions.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		buAppCalc.cSort.SortEntitiesByRefPoint(new Pnt3D(), ref Entities, sortingOptions, ref SortedEntities);
		buAppCalc.cVector.EntityToPoint(SortedEntities, new EntityResolution(), ref Points);
		marbleOperation marbleOperation2 = new marbleOperation();
		marbleOperation2.TargetZ = Hatch.OperationZ;
		List<List<Pnt3D>> list4 = new List<List<Pnt3D>>();
		for (int k = 0; k <= Entities.Count - 1; k++)
		{
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			Pnt3D.Copy(Entities[k].Vertice, ref CopiedPnt);
			list4.Add(CopiedPnt);
		}
		camClosedContour(new Pnt3D(), Points, 0.0, AfterFirstPointReverseOffsetDirection: false, CamClosedContourType.Center, ClockDirectionType.CW, OffsetCornerType.Line, Tool, new WorkPlane(), Velocity, Distances, Steps, Operations, Options, ref calcCam);
	}

	public void LeadInOutCalculation(LeadInOutEntitiesProperties FirstEntity, LeadInOutEntitiesProperties LastEntitiy, LeadIn LeadInProp, LeadOut LeadOutProp, WorkPlane Plane, ClockDirectionType Direction, ref List<eEntities> LeadInEntitiy, ref List<eEntities> LeadOutEntitiy)
	{
		try
		{
			double pointTangentAngle = FirstEntity.PointTangentAngle;
			double pointTangentAngle2 = LastEntitiy.PointTangentAngle;
			Pnt3D pnt3D = new Pnt3D();
			Pnt3D pnt3D2 = new Pnt3D();
			if (FirstEntity.RefEntity.camDirections != camPathDirectionType.Reverse)
			{
				pnt3D = new Pnt3D(FirstEntity.RefEntity.Vertice[0]);
				if (LeadInProp.ExtendLength > 0.0)
				{
					Pnt3D endPoint = new Pnt3D(pnt3D);
					Pnt3D EndPnt = new Pnt3D();
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt);
					eEntities eEntities2 = new eLine(EndPnt, endPoint);
					eEntities2.Purpose = EntityPurposeType.LeadIn;
					LeadInEntitiy.Add(eEntities2);
					pnt3D = new Pnt3D(EndPnt);
				}
			}
			else
			{
				pnt3D = new Pnt3D(FirstEntity.RefEntity.Vertice[FirstEntity.RefEntity.Vertice.Count - 1]);
				if (LeadInProp.ExtendLength > 0.0)
				{
					Pnt3D endPoint2 = new Pnt3D(pnt3D);
					Pnt3D EndPnt2 = new Pnt3D();
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt2);
					eEntities eEntities3 = new eLine(EndPnt2, endPoint2);
					eEntities3.Purpose = EntityPurposeType.LeadIn;
					LeadInEntitiy.Add(eEntities3);
					pnt3D = new Pnt3D(EndPnt2);
				}
			}
			if (LastEntitiy.RefEntity.camDirections != camPathDirectionType.Reverse)
			{
				pnt3D2 = new Pnt3D(LastEntitiy.RefEntity.Vertice[LastEntitiy.RefEntity.Vertice.Count - 1]);
				if (LeadOutProp.ExtendLength > 0.0)
				{
					Pnt3D startPoint = new Pnt3D(pnt3D2);
					Pnt3D EndPnt3 = new Pnt3D();
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt3);
					eEntities eEntities4 = new eLine(startPoint, EndPnt3);
					eEntities4.Purpose = EntityPurposeType.LeadOut;
					LeadOutEntitiy.Add(eEntities4);
					pnt3D2 = new Pnt3D(EndPnt3);
				}
			}
			else
			{
				pnt3D2 = new Pnt3D(LastEntitiy.RefEntity.Vertice[0]);
				if (LeadOutProp.ExtendLength > 0.0)
				{
					Pnt3D startPoint2 = new Pnt3D(pnt3D2);
					Pnt3D EndPnt4 = new Pnt3D();
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt4);
					eEntities eEntities5 = new eLine(startPoint2, EndPnt4);
					eEntities5.Purpose = EntityPurposeType.LeadOut;
					LeadOutEntitiy.Add(eEntities5);
					pnt3D2 = new Pnt3D(EndPnt4);
				}
			}
			if ((LeadInProp.LeadType == LeadInOutType.Line) & LeadInProp.Enable)
			{
				Pnt3D EndPnt5 = new Pnt3D();
				double num = 1.0;
				if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
				{
					num = -1.0;
				}
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, LeadInProp.Length, pointTangentAngle + 180.0 + LeadInProp.TangentAngle * num, Plane, ref EndPnt5);
				eEntities eEntities6 = new eLine(EndPnt5, pnt3D);
				eEntities6.Purpose = EntityPurposeType.LeadIn;
				LeadInEntitiy.Add(eEntities6);
			}
			if ((LeadInProp.LeadType == LeadInOutType.Arc) & LeadInProp.Enable)
			{
				eArc eArc2 = null;
				double num2 = 0.0;
				double num3 = 0.0;
				Pnt3D EndPnt6 = new Pnt3D();
				if (LeadInProp.ClockDir == ClockDirectionType.CW)
				{
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, LeadInProp.ArcRadius, pointTangentAngle - 90.0, Plane, ref EndPnt6);
					num2 = buAppCalc.cVector.PointAngle(pnt3D, EndPnt6, Plane);
					num3 = num2 + LeadInProp.ArcSweepAngle;
					eArc2 = new eArc(EndPnt6, LeadInProp.ArcRadius, num2, num3, Plane);
					eArc2.camDirections = camPathDirectionType.Reverse;
				}
				if (LeadInProp.ClockDir == ClockDirectionType.CCW)
				{
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, LeadInProp.ArcRadius, pointTangentAngle + 90.0, Plane, ref EndPnt6);
					num3 = buAppCalc.cVector.PointAngle(pnt3D, EndPnt6, Plane);
					num2 = num3 - LeadInProp.ArcSweepAngle;
					eArc2 = new eArc(EndPnt6, LeadInProp.ArcRadius, num2, num3, Plane);
				}
				if (eArc2 != null)
				{
					eArc2.Purpose = EntityPurposeType.LeadIn;
					LeadInEntitiy.Insert(0, eArc2);
				}
			}
			if ((LeadOutProp.LeadType == LeadInOutType.Line) & LeadOutProp.Enable)
			{
				Pnt3D EndPnt7 = new Pnt3D();
				double num4 = 1.0;
				if (LeadOutProp.ClockDir == ClockDirectionType.CW)
				{
					num4 = -1.0;
				}
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, LeadOutProp.Length, pointTangentAngle2 + LeadOutProp.TangentAngle * num4, Plane, ref EndPnt7);
				eEntities eEntities7 = new eLine(pnt3D2, EndPnt7);
				eEntities7.Purpose = EntityPurposeType.LeadOut;
				LeadOutEntitiy.Add(eEntities7);
			}
			if ((LeadOutProp.LeadType == LeadInOutType.Arc) & LeadOutProp.Enable)
			{
				eArc eArc3 = null;
				double num5 = 0.0;
				double num6 = 0.0;
				Pnt3D EndPnt8 = new Pnt3D();
				if (LeadOutProp.ClockDir == ClockDirectionType.CW)
				{
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, LeadOutProp.ArcRadius, pointTangentAngle2 - 90.0, Plane, ref EndPnt8);
					num6 = buAppCalc.cVector.PointAngle(pnt3D2, EndPnt8, Plane);
					num5 = num6 - LeadOutProp.ArcSweepAngle;
					eArc3 = new eArc(EndPnt8, LeadOutProp.ArcRadius, num5, num6, Plane);
					eArc3.camDirections = camPathDirectionType.Reverse;
				}
				if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
				{
					buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, LeadOutProp.ArcRadius, pointTangentAngle2 + 90.0, Plane, ref EndPnt8);
					num5 = buAppCalc.cVector.PointAngle(pnt3D2, EndPnt8, Plane);
					num6 = num5 + LeadOutProp.ArcSweepAngle;
					eArc3 = new eArc(EndPnt8, LeadOutProp.ArcRadius, num5, num6, Plane);
					eArc3.camDirections = camPathDirectionType.Normal;
				}
				if (eArc3 != null)
				{
					eArc3.Purpose = EntityPurposeType.LeadOut;
					LeadOutEntitiy.Add(eArc3);
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "FirstEntity: " + FirstEntity.ToString() + " - LastEntitiyEntity: " + LastEntitiy.ToString() + " - In: " + LeadInProp.ToString() + " - Out: " + LeadOutProp.ToString() + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void LeadInOutCalculation(eEntities FirstEntity, eEntities LastEntitiy, LeadIn In, LeadOut Out, WorkPlane Plane, ClockDirectionType Direction, ref eEntities LeadInEntitiy, ref eEntities LeadOutEntitiy)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D(FirstEntity.Vertice[0]);
			Pnt3D pnt3D2 = new Pnt3D(LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 1]);
			double num = ((!(FirstEntity.GetType() == typeof(eArc))) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[1], FirstEntity.Vertice[0], Plane) : (((eArc)FirstEntity).StartAngle + 90.0));
			double num2 = ((!(LastEntitiy.GetType() == typeof(eArc))) ? buAppCalc.cVector.PointAngle(LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 2], LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 1], Plane) : (((eArc)LastEntitiy).EndAngle - 90.0));
			if (FirstEntity.camDirections == camPathDirectionType.Reverse)
			{
				pnt3D = new Pnt3D(FirstEntity.Vertice[FirstEntity.Vertice.Count - 1]);
				pnt3D2 = new Pnt3D(LastEntitiy.Vertice[0]);
				num = ((!(FirstEntity.GetType() == typeof(eArc))) ? buAppCalc.cVector.PointAngle(FirstEntity.Vertice[0], FirstEntity.Vertice[1], Plane) : (((eArc)FirstEntity).EndAngle - 90.0));
				num2 = ((!(LastEntitiy.GetType() == typeof(eArc))) ? buAppCalc.cVector.PointAngle(LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 1], LastEntitiy.Vertice[LastEntitiy.Vertice.Count - 2], Plane) : (((eArc)LastEntitiy).StartAngle + 90.0));
			}
			if (In.LeadType == LeadInOutType.Line)
			{
				Pnt3D EndPnt = new Pnt3D();
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, In.Length, num + 180.0 + In.TangentAngle, Plane, ref EndPnt);
				LeadInEntitiy = new eLine(EndPnt, pnt3D);
			}
			if (In.LeadType == LeadInOutType.Arc)
			{
				Pnt3D EndPnt2 = new Pnt3D();
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D, In.ArcRadius, num + In.ArcSweepAngle, Plane, ref EndPnt2);
				double num3 = buAppCalc.cVector.PointAngle(pnt3D, EndPnt2, Plane);
				double startAngle = num3 - In.ArcSweepAngle;
				LeadInEntitiy = new eArc(EndPnt2, In.ArcRadius, startAngle, num3, Plane);
			}
			if (Out.LeadType == LeadInOutType.Line)
			{
				Pnt3D EndPnt3 = new Pnt3D();
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, Out.Length, num2 + 180.0 + Out.TangentAngle, Plane, ref EndPnt3);
				LeadOutEntitiy = new eLine(pnt3D2, EndPnt3);
			}
			if (Out.LeadType == LeadInOutType.Arc)
			{
				Pnt3D EndPnt4 = new Pnt3D();
				buAppCalc.cVector.LineWithLengthAndAngle(pnt3D2, Out.ArcRadius, num2 + 180.0 + Out.ArcSweepAngle, Plane, ref EndPnt4);
				double num4 = buAppCalc.cVector.PointAngle(pnt3D2, EndPnt4, Plane);
				double endAngle = num4 + Out.ArcSweepAngle;
				LeadOutEntitiy = new eArc(EndPnt4, Out.ArcRadius, num4, endAngle, Plane);
			}
		}
		catch (Exception)
		{
		}
	}

	public void SimPointCreat(List<Pnt9DCam> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, ref Simulation simulation)
	{
		SimPointCreat(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, new Pnt9D(), ref simulation);
	}

	public void SimPointCreat(List<Pnt9DCam> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, Pnt9D Offsets, ref Simulation simulation)
	{
		if (G0DevideRatio <= 0.0)
		{
			G0DevideRatio = 0.25;
		}
		if (G1DevideRatio <= 0.0)
		{
			G1DevideRatio = 0.1;
		}
		int num = 1;
		if (Points.Count <= 0)
		{
			return;
		}
		if (Points[0].PlungeAxisMovement)
		{
			num = 2;
		}
		if ((Points.Count > 0) & (num <= Points.Count))
		{
			new Pnt6D(Points[num - 1].P9.X + Offsets.X, Points[num - 1].P9.Y + Offsets.Y, Points[num - 1].P9.Z + Offsets.Z, Points[num - 1].P9.A + Offsets.A, Points[num - 1].P9.B + Offsets.B, Points[num - 1].P9.C + Offsets.C);
			simulation.SimPoints.Add(new Pnt6D(Points[num - 1]));
		}
		for (int i = num; i <= Points.Count - 1; i++)
		{
			List<Pnt6D> CalculatedPoints = new List<Pnt6D>();
			double dt = G1DevideRatio;
			if (Points[i].Type == 0)
			{
				dt = 0.25;
			}
			if ((Points[i].Type == 0) | (Points[i].Type == 1))
			{
				double num2 = buAppCalc.cVector.Length3D(new Pnt3D(Points[i - 1]), new Pnt3D(Points[i]));
				if (!(num2 > PointFilterLength))
				{
					Pnt6D item = new Pnt6D(Points[i].P9.X + Offsets.X, Points[i].P9.Y + Offsets.Y, Points[i].P9.Z + Offsets.Z, Points[i].P9.A + Offsets.A, Points[i].P9.B + Offsets.B, Points[i].P9.C + Offsets.C);
					simulation.SimPoints.Add(item);
				}
				else
				{
					buAppCalc.cVector.LineerInterpolation(new Pnt6D(Points[i - 1]), new Pnt6D(Points[i]), dt, ref CalculatedPoints);
					CalculatedPoints.RemoveAt(0);
					for (int j = 0; j <= CalculatedPoints.Count - 1; j++)
					{
						Pnt6D item2 = new Pnt6D(CalculatedPoints[j].X + Offsets.X, CalculatedPoints[j].Y + Offsets.Y, CalculatedPoints[j].Z + Offsets.Z, CalculatedPoints[j].A + Offsets.A, CalculatedPoints[j].B + Offsets.B, CalculatedPoints[j].C + Offsets.C);
						simulation.SimPoints.Add(item2);
					}
				}
			}
			if (!((Points[i].Type == 2) | (Points[i].Type == 3)))
			{
				continue;
			}
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			if (Points[i].ArcData == null)
			{
				continue;
			}
			Pnt3D.Copy(Points[i].ArcData.Vertice, ref CopiedPnt);
			if (Points[i].Type == 2)
			{
				CopiedPnt.Reverse();
			}
			if (CopiedPnt.Count > 0)
			{
				for (int k = 1; k <= CopiedPnt.Count - 1; k++)
				{
					Pnt6D item3 = new Pnt6D(CopiedPnt[k].X + Offsets.X, CopiedPnt[k].Y + Offsets.Y, CopiedPnt[k].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C);
					simulation.SimPoints.Add(item3);
				}
			}
		}
	}

	public void SimPointCreatForDetailedPoints(List<Pnt9DCam> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, ref Simulation simulation)
	{
		SimPointCreatForDetailedPoints(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, new Pnt9D(), ref simulation);
	}

	public void SimPointCreatForDetailedPoints(List<Pnt9DCam> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, Pnt9D Offsets, ref Simulation simulation)
	{
		if (G0DevideRatio <= 0.0)
		{
			G0DevideRatio = 0.25;
		}
		if (G1DevideRatio <= 0.0)
		{
			G1DevideRatio = 0.1;
		}
		int num = 1;
		if (Points.Count <= 0)
		{
			return;
		}
		if (Points[0].PlungeAxisMovement)
		{
			num = 2;
		}
		if ((Points.Count > 0) & (num <= Points.Count))
		{
			Pnt6DSim item = new Pnt6DSim(Points[num - 1].P9.X + Offsets.X, Points[num - 1].P9.Y + Offsets.Y, Points[num - 1].P9.Z + Offsets.Z, Points[num - 1].P9.A + Offsets.A, Points[num - 1].P9.B + Offsets.B, Points[num - 1].P9.C + Offsets.C, Points[num - 1].Feed, Points[num - 1].ToolNo, Points[num - 1].SpindleSpeed, new Pnt3D());
			simulation.SimDetailedPoints.Add(item);
		}
		for (int i = num; i <= Points.Count - 1; i++)
		{
			List<Pnt6DSim> CalculatedPoints = new List<Pnt6DSim>();
			double dt = G1DevideRatio;
			if (Points[i].Type == 0)
			{
				dt = 0.25;
			}
			if ((Points[i].Type == 0) | (Points[i].Type == 1))
			{
				double num2 = buAppCalc.cVector.Length3D(new Pnt3D(Points[i - 1]), new Pnt3D(Points[i]));
				if (!(num2 > PointFilterLength))
				{
					Pnt6DSim item2 = new Pnt6DSim(Points[i].P9.X + Offsets.X, Points[i].P9.Y + Offsets.Y, Points[i].P9.Z + Offsets.Z, Points[i].P9.A + Offsets.A, Points[i].P9.B + Offsets.B, Points[i].P9.C + Offsets.C, Points[i].Feed, Points[i].ToolNo, Points[i].SpindleSpeed, new Pnt3D());
					simulation.SimDetailedPoints.Add(item2);
				}
				else
				{
					buAppCalc.cVector.LineerInterpolation(new Pnt6DSim(Points[i - 1]), new Pnt6DSim(Points[i]), dt, ref CalculatedPoints);
					CalculatedPoints.RemoveAt(0);
					for (int j = 0; j <= CalculatedPoints.Count - 1; j++)
					{
						Pnt6DSim item3 = new Pnt6DSim(CalculatedPoints[j].X + Offsets.X, CalculatedPoints[j].Y + Offsets.Y, CalculatedPoints[j].Z + Offsets.Z, CalculatedPoints[j].A + Offsets.A, CalculatedPoints[j].B + Offsets.B, CalculatedPoints[j].C + Offsets.C, CalculatedPoints[j].FeedRate, CalculatedPoints[j].ToolNo, CalculatedPoints[j].SpindleRpm, new Pnt3D());
						simulation.SimDetailedPoints.Add(item3);
					}
				}
			}
			if (!((Points[i].Type == 2) | (Points[i].Type == 3)))
			{
				continue;
			}
			List<Pnt3D> CopiedPnt = new List<Pnt3D>();
			if (Points[i].ArcData == null)
			{
				continue;
			}
			Pnt3D.Copy(Points[i].ArcData.Vertice, ref CopiedPnt);
			if (Points[i].Type == 2)
			{
				CopiedPnt.Reverse();
			}
			if (CopiedPnt.Count > 0)
			{
				for (int k = 1; k <= CopiedPnt.Count - 1; k++)
				{
					Pnt6DSim item4 = new Pnt6DSim(CopiedPnt[k].X + Offsets.X, CopiedPnt[k].Y + Offsets.Y, CopiedPnt[k].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C, Points[i].Feed, Points[i].ToolNo, Points[i].SpindleSpeed, new Pnt3D());
					simulation.SimDetailedPoints.Add(item4);
				}
			}
		}
	}

	public void ClippingPattern(List<Pnt3D> OutterPoints, List<List<Pnt3D>> InnerPoints, ref List<List<Pnt3D>> CalculatedPolygons)
	{
		buClipper buClipper2 = new buClipper();
		List<List<IntPoint>> list = new List<List<IntPoint>>();
		List<List<IntPoint>> list2 = new List<List<IntPoint>>();
		List<List<IntPoint>> list3 = new List<List<IntPoint>>();
		List<IntPoint> list4 = new List<IntPoint>();
		for (int i = 0; i <= OutterPoints.Count - 1; i++)
		{
			IntPoint item = new IntPoint(Convert.ToInt32(OutterPoints[i].X * 1000.0), Convert.ToInt32(OutterPoints[i].Y * 1000.0));
			list4.Add(item);
		}
		List<IntPoint> item2 = new List<IntPoint>(list4);
		list.Add(item2);
		for (int j = 0; j <= InnerPoints.Count - 1; j++)
		{
			list4 = new List<IntPoint>();
			for (int k = 0; k <= InnerPoints[j].Count - 1; k++)
			{
				IntPoint item3 = new IntPoint(Convert.ToInt32(InnerPoints[j][k].X * 1000.0), Convert.ToInt32(InnerPoints[j][k].Y * 1000.0));
				list4.Add(item3);
			}
			List<IntPoint> item4 = new List<IntPoint>(list4);
			list2.Add(item4);
		}
		buClipper2.AddPaths(list, PolyType.ptSubject, closed: true);
		buClipper2.AddPaths(list2, PolyType.ptClip, closed: true);
		buClipper2.Execute(ClipType.ctUnion, list3, PolyFillType.pftEvenOdd, PolyFillType.pftNonZero);
		for (int l = 0; l <= list3.Count - 1; l++)
		{
			List<Pnt3D> list5 = new List<Pnt3D>();
			for (int m = 0; m <= list3[l].Count - 1; m++)
			{
				Pnt3D item5 = new Pnt3D((double)list3[l][m].X / (double)buSystem.DoubleToIntegerConts, (double)list3[l][m].Y / (double)buSystem.DoubleToIntegerConts, list3[l][m].Z);
				list5.Add(item5);
			}
			if (list5.Count >= 2 && !buCompare.EQ(list5[0], list5[list5.Count - 1], buSystem.resolutionCompare))
			{
				new Pnt3D(list5[0]);
				list5.Add(new Pnt3D(list5[0]));
			}
			CalculatedPolygons.Add(list5);
		}
	}

	static buCamCalc()
	{
		pntTeachGrids = new List<List<Pnt3D>>();
	}
}
