using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buClass;
using buClass.UserFiles.buCad;
using buCore;
using buEyeBaseVer5.Apps.Marble;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buEyeBaseVer5;

public class buCam5
{
	public setCam varCam = new setCam();

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

	public buCam5()
	{
		if (!buVector5.smethod_0("buCam5"))
		{
			throw new RegisterException("buCam5");
		}
	}

	public void CamPointsToEntities(camTp Cam, ref List<Entity> Entities, double MultiplyX = 1.0, double MultiplyY = 1.0, double MultiplyZ = 1.0)
	{
		List<camTp> list = new List<camTp>();
		list.Add(Cam);
		CamPointsToEntities(list, ref Entities, MultiplyX, MultiplyY, MultiplyZ);
	}

	public void CamPointsToEntities(List<camTp> Cams, ref List<Entity> Entities, double MultiplyX = 1.0, double MultiplyY = 1.0, double MultiplyZ = 1.0)
	{
		Entities.Clear();
		Entities = new List<Entity>();
		for (int i = 0; i <= Cams.Count - 1; i++)
		{
			double num = 1.0;
			if (Cams[i].PlaneName == planeNames.Bottom)
			{
				num = -1.0;
			}
			for (int j = 0; j <= Cams[i].CamPoints.Count - 1; j++)
			{
				List<Point3D> list = new List<Point3D>();
				for (int k = 1; k <= Cams[i].CamPoints[j].Points.Count - 1; k++)
				{
					TpPnt9D tpPnt9D = Cams[i].CamPoints[j].Points[k - 1];
					TpPnt9D tpPnt9D2 = Cams[i].CamPoints[j].Points[k];
					if (Cams[i].CamPoints[j].Points[k].Type != 0)
					{
						if (Cams[i].CamPoints[j].Points[k].Type != 1)
						{
							if (Cams[i].CamPoints[j].Points[k].Type != 2)
							{
								if (Cams[i].CamPoints[j].Points[k].Type == 3)
								{
									if (list.Count > 0)
									{
										LinearPath linearPath = new LinearPath(list);
										linearPath.EntityData = new CustomData();
										Entities.Add(linearPath);
										list = new List<Point3D>();
									}
									Point3D arcStartPoint = new Point3D(tpPnt9D.P9.X * MultiplyX, tpPnt9D.P9.Y * MultiplyY, tpPnt9D.P9.Z * num * MultiplyZ);
									Point3D arcEndPoint = new Point3D(tpPnt9D2.P9.X * MultiplyX, tpPnt9D2.P9.Y * MultiplyY, tpPnt9D2.P9.Z * num * MultiplyZ);
									Entity entArc = null;
									buCall.buVector5_0.ArcWithTwoPointAndRadius(arcStartPoint, arcEndPoint, Cams[i].CamPoints[j].Points[k].ArcData.Radius, CW: false, Plane.XY, ref entArc);
									entArc.Regen(0.01);
									Entities.Add(entArc);
								}
							}
							else
							{
								if (list.Count > 0)
								{
									LinearPath linearPath2 = new LinearPath(list);
									linearPath2.EntityData = new CustomData();
									Entities.Add(linearPath2);
									list = new List<Point3D>();
								}
								Point3D arcStartPoint2 = new Point3D(tpPnt9D.P9.X * MultiplyX, tpPnt9D.P9.Y * MultiplyY, tpPnt9D.P9.Z * num * MultiplyZ);
								Point3D arcEndPoint2 = new Point3D(tpPnt9D2.P9.X * MultiplyX, tpPnt9D2.P9.Y * MultiplyY, tpPnt9D2.P9.Z * num * MultiplyZ);
								Entity entArc2 = null;
								buCall.buVector5_0.ArcWithTwoPointAndRadius(arcStartPoint2, arcEndPoint2, Cams[i].CamPoints[j].Points[k].ArcData.Radius, CW: true, Plane.XY, ref entArc2);
								Entities.Add(entArc2);
							}
						}
						else
						{
							if (list.Count == 0)
							{
								list.Add(new Point3D(tpPnt9D.P9.X * MultiplyX, tpPnt9D.P9.Y * MultiplyY, tpPnt9D.P9.Z * num * MultiplyZ));
							}
							list.Add(new Point3D(tpPnt9D2.P9.X * MultiplyX, tpPnt9D2.P9.Y * MultiplyY, tpPnt9D2.P9.Z * num * MultiplyZ));
						}
					}
					else if (list.Count > 0)
					{
						LinearPath linearPath3 = new LinearPath(list);
						linearPath3.EntityData = new CustomData();
						Entities.Add(linearPath3);
						list = new List<Point3D>();
					}
				}
				if (list.Count > 0)
				{
					LinearPath linearPath4 = new LinearPath(list);
					linearPath4.EntityData = new CustomData();
					Entities.Add(linearPath4);
					list = new List<Point3D>();
				}
			}
		}
	}

	public bool camEntitiesToCamPoints(List<Entity> Entities, camParameters5 Parameter, ToolBase5 Tool, ref List<camTp> Cam)
	{
		camTp Cam2 = new camTp();
		camTpPoint camTpPoint2 = new camTpPoint();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			CustomData customData = Entities[i].EntityData as CustomData;
			ICurve curve = Entities[i] as ICurve;
			if (i == 0)
			{
				if (customData.sortDirection != entitySortDirection.Normal)
				{
					TpPnt9D tpPnt9D = new TpPnt9D();
					tpPnt9D.Type = 0;
					tpPnt9D.LeaveAxisMovement = true;
					tpPnt9D.P9 = new Pnt9D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					tpPnt9D.Feed = Parameter.Speeds.Leave;
					camTpPoint2.Points.Add(tpPnt9D);
					tpPnt9D = new TpPnt9D();
					tpPnt9D.Type = 0;
					tpPnt9D.P9 = new Pnt9D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					camTpPoint2.Points.Add(tpPnt9D);
				}
				else
				{
					TpPnt9D tpPnt9D2 = new TpPnt9D();
					tpPnt9D2.Type = 0;
					tpPnt9D2.LeaveAxisMovement = true;
					tpPnt9D2.P9 = new Pnt9D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					camTpPoint2.Points.Add(tpPnt9D2);
					tpPnt9D2 = new TpPnt9D();
					tpPnt9D2.Type = 0;
					tpPnt9D2.P9 = new Pnt9D(curve.StartPoint.X, curve.StartPoint.Y, curve.StartPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					camTpPoint2.Points.Add(tpPnt9D2);
				}
			}
			if (!(Entities[i].GetType() == typeof(Arc)))
			{
				if (customData.typeDefination != entityTypeDefination.CamPlunge)
				{
					if (customData.typeDefination != entityTypeDefination.CamLeave)
					{
						if (customData.typeDefination != entityTypeDefination.CamG0)
						{
							if (!(Entities[i].GetType() == typeof(Line)))
							{
								if (Entities[i].GetType() == typeof(LinearPath))
								{
									LinearPath linearPath = Entities[i] as LinearPath;
									for (int j = 1; j <= linearPath.Vertices.Length - 1; j++)
									{
										TpPnt9D tpPnt9D3 = new TpPnt9D();
										tpPnt9D3.Type = 1;
										tpPnt9D3.P9 = new Pnt9D(linearPath.Vertices[j].X, linearPath.Vertices[j].Y, linearPath.Vertices[j].Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
										tpPnt9D3.Feed = Parameter.Speeds.Feed;
										camTpPoint2.Points.Add(tpPnt9D3);
									}
								}
							}
							else
							{
								TpPnt9D tpPnt9D4 = new TpPnt9D();
								tpPnt9D4.Type = 1;
								tpPnt9D4.P9 = new Pnt9D(((Line)Entities[i]).EndPoint.X, ((Line)Entities[i]).EndPoint.Y, ((Line)Entities[i]).EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
								tpPnt9D4.Feed = Parameter.Speeds.Feed;
								camTpPoint2.Points.Add(tpPnt9D4);
							}
						}
						else
						{
							TpPnt9D tpPnt9D5 = new TpPnt9D();
							tpPnt9D5.Type = 0;
							tpPnt9D5.P9 = new Pnt9D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
							tpPnt9D5.Feed = Parameter.Speeds.Rapid;
							camTpPoint2.Points.Add(tpPnt9D5);
						}
					}
					else
					{
						TpPnt9D tpPnt9D6 = new TpPnt9D();
						tpPnt9D6.Type = 1;
						tpPnt9D6.LeaveAxisMovement = true;
						tpPnt9D6.P9 = new Pnt9D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
						tpPnt9D6.Feed = Parameter.Speeds.Leave;
						camTpPoint2.Points.Add(tpPnt9D6);
					}
				}
				else
				{
					TpPnt9D tpPnt9D7 = new TpPnt9D();
					tpPnt9D7.Type = 1;
					tpPnt9D7.PlungeAxisMovement = true;
					tpPnt9D7.P9 = new Pnt9D(curve.EndPoint.X, curve.EndPoint.Y, curve.EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					tpPnt9D7.Feed = Parameter.Speeds.Plunge;
					camTpPoint2.Points.Add(tpPnt9D7);
				}
			}
			else
			{
				Arc arc = Entities[i] as Arc;
				CustomData customData2 = Entities[i].EntityData as CustomData;
				if (customData2.sortDirection != entitySortDirection.Reverse)
				{
					TpPnt9D tpPnt9D8 = new TpPnt9D();
					tpPnt9D8.ArcData = new TpArcData(arc.Center, arc.StartPoint, arc.EndPoint);
					tpPnt9D8.ArcData.Radius = arc.Radius;
					tpPnt9D8.ArcData.StartAngle = buCall.buVector5_0.PointAngle(arc.StartPoint, arc.Center, arc.Plane);
					tpPnt9D8.ArcData.EndAngle = buCall.buVector5_0.PointAngle(arc.EndPoint, arc.Center, arc.Plane);
					tpPnt9D8.ArcData.SweepAngle = tpPnt9D8.ArcData.EndAngle - tpPnt9D8.ArcData.StartAngle;
					tpPnt9D8.Type = 3;
					tpPnt9D8.P9 = new Pnt9D(((Arc)Entities[i]).EndPoint.X, ((Arc)Entities[i]).EndPoint.Y, ((Arc)Entities[i]).EndPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					tpPnt9D8.Feed = Parameter.Speeds.Feed;
					camTpPoint2.Points.Add(tpPnt9D8);
				}
				else
				{
					TpPnt9D tpPnt9D9 = new TpPnt9D();
					tpPnt9D9.ArcData = new TpArcData(arc.Center, arc.StartPoint, arc.EndPoint);
					tpPnt9D9.ArcData.Radius = arc.Radius;
					tpPnt9D9.ArcData.StartAngle = buCall.buVector5_0.PointAngle(arc.StartPoint, arc.Center, arc.Plane);
					tpPnt9D9.ArcData.EndAngle = buCall.buVector5_0.PointAngle(arc.EndPoint, arc.Center, arc.Plane);
					tpPnt9D9.ArcData.SweepAngle = tpPnt9D9.ArcData.EndAngle - tpPnt9D9.ArcData.StartAngle;
					tpPnt9D9.Type = 2;
					tpPnt9D9.P9 = new Pnt9D(((Arc)Entities[i]).StartPoint.X, ((Arc)Entities[i]).StartPoint.Y, ((Arc)Entities[i]).StartPoint.Z, customData.OrientationA, customData.OrientationB, customData.OrientationC);
					tpPnt9D9.Feed = Parameter.Speeds.Feed;
					camTpPoint2.Points.Add(tpPnt9D9);
				}
			}
		}
		Cam2.Tool = new ToolBase5(Tool);
		CreateSimulationPointsFromCamPoint(ref Cam2, camTpPoint2);
		Cam2.CamPoints.Add(camTpPoint2);
		Cam.Add(Cam2);
		return true;
	}

	public bool camEntitiesToCamPoints(List<buEntity> Entities, camParameters5 Parameter, ToolBase5 Tool, ref List<camTp> Cam)
	{
		camTp camTp2 = new camTp();
		camTpPoint camTpPoint2 = new camTpPoint();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			if (i == 0)
			{
				if (Entities[i].sortDirection != entitySortDirection.Normal)
				{
					TpPnt9D tpPnt9D = new TpPnt9D();
					tpPnt9D.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
					tpPnt9D.ToolNo = Tool.Data.No;
					tpPnt9D.ToolName = Tool.Data.Name;
					tpPnt9D.Type = 0;
					tpPnt9D.P9 = new Pnt9D(Entities[i].EndPoint.X, Entities[i].EndPoint.Y, Entities[i].EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
					camTpPoint2.Points.Add(tpPnt9D);
				}
				else
				{
					TpPnt9D tpPnt9D2 = new TpPnt9D();
					tpPnt9D2.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
					tpPnt9D2.ToolNo = Tool.Data.No;
					tpPnt9D2.ToolName = Tool.Data.Name;
					tpPnt9D2.Type = 0;
					tpPnt9D2.P9 = new Pnt9D(Entities[i].StartPoint.X, Entities[i].StartPoint.Y, Entities[i].StartPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
					camTpPoint2.Points.Add(tpPnt9D2);
				}
			}
			if (!(Entities[i].GetType() == typeof(buArc)))
			{
				if (!((Entities[i].typeDefination == entityTypeDefination.CamPlunge) | (Entities[i].typeDefination == entityTypeDefination.CamPlungeFast)))
				{
					if (Entities[i].typeDefination != entityTypeDefination.CamLeave)
					{
						if (Entities[i].typeDefination != entityTypeDefination.CamG0)
						{
							if (!(Entities[i].GetType() == typeof(buLine)))
							{
								if (!(Entities[i].GetType() == typeof(buLinearPath)))
								{
									continue;
								}
								if (Entities[i].sortDirection != entitySortDirection.Normal)
								{
									buLinearPath buLinearPath2 = Entities[i] as buLinearPath;
									List<Point3D> copiedPoint = new List<Point3D>();
									buVector5.Copy(buLinearPath2.Vertices, ref copiedPoint);
									copiedPoint.Reverse();
									int num = 0;
									if (camTpPoint2.Points.Count > 0)
									{
										Point3D value = new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z);
										if (buCompare5.EQ(value, copiedPoint[0]))
										{
											num = 1;
										}
									}
									for (int j = num; j <= copiedPoint.Count - 1; j++)
									{
										TpPnt9D tpPnt9D3 = new TpPnt9D();
										tpPnt9D3.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
										tpPnt9D3.ToolNo = Tool.Data.No;
										tpPnt9D3.ToolName = Tool.Data.Name;
										tpPnt9D3.Type = 1;
										if (j == 0)
										{
											tpPnt9D3.Type = 0;
										}
										tpPnt9D3.P9 = new Pnt9D(copiedPoint[j].X, copiedPoint[j].Y, copiedPoint[j].Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
										tpPnt9D3.Feed = Parameter.Speeds.Feed;
										if (Entities[i].Info.CamSpeed > 0.0)
										{
											tpPnt9D3.Feed = Entities[i].Info.CamSpeed;
										}
										camTpPoint2.Points.Add(tpPnt9D3);
									}
									continue;
								}
								buLinearPath buLinearPath3 = Entities[i] as buLinearPath;
								int num2 = 0;
								if (camTpPoint2.Points.Count > 0)
								{
									Point3D value2 = new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z);
									if (buCompare5.EQ(value2, buLinearPath3.Vertices[0]))
									{
										num2 = 1;
									}
								}
								for (int k = num2; k <= buLinearPath3.Vertices.Count - 1; k++)
								{
									TpPnt9D tpPnt9D4 = new TpPnt9D();
									tpPnt9D4.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
									tpPnt9D4.ToolNo = Tool.Data.No;
									tpPnt9D4.ToolName = Tool.Data.Name;
									tpPnt9D4.Type = 1;
									if (k == 0)
									{
										tpPnt9D4.Type = 0;
										if (i > 0 && ((Entities[i - 1].typeDefination == entityTypeDefination.CamPlunge) | (Entities[i - 1].typeDefination == entityTypeDefination.CamWireframeContour) | (Entities[i - 1].typeDefination == entityTypeDefination.CamWireframeContourFinish) | (Entities[i - 1].typeDefination == entityTypeDefination.CamWireframePocket)))
										{
											tpPnt9D4.Type = 1;
										}
									}
									tpPnt9D4.P9 = new Pnt9D(buLinearPath3.Vertices[k].X, buLinearPath3.Vertices[k].Y, buLinearPath3.Vertices[k].Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
									tpPnt9D4.Feed = Parameter.Speeds.Feed;
									if (Entities[i].Info.CamSpeed > 0.0)
									{
										tpPnt9D4.Feed = Entities[i].Info.CamSpeed;
									}
									camTpPoint2.Points.Add(tpPnt9D4);
								}
							}
							else if (Entities[i].sortDirection != entitySortDirection.Normal)
							{
								TpPnt9D tpPnt9D5 = new TpPnt9D();
								Point3D value3 = new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z);
								if (!buCompare5.EQ(value3, ((buLine)Entities[i]).EndPoint))
								{
									tpPnt9D5 = new TpPnt9D();
									tpPnt9D5.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
									tpPnt9D5.ToolNo = Tool.Data.No;
									tpPnt9D5.ToolName = Tool.Data.Name;
									tpPnt9D5.Type = 0;
									tpPnt9D5.P9 = new Pnt9D(((buLine)Entities[i]).EndPoint.X, ((buLine)Entities[i]).EndPoint.Y, ((buLine)Entities[i]).EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
									tpPnt9D5.Feed = Parameter.Speeds.Feed;
									camTpPoint2.Points.Add(tpPnt9D5);
								}
								tpPnt9D5 = new TpPnt9D();
								tpPnt9D5.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
								tpPnt9D5.ToolNo = Tool.Data.No;
								tpPnt9D5.ToolName = Tool.Data.Name;
								tpPnt9D5.Type = 1;
								tpPnt9D5.P9 = new Pnt9D(((buLine)Entities[i]).StartPoint.X, ((buLine)Entities[i]).StartPoint.Y, ((buLine)Entities[i]).StartPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
								tpPnt9D5.Feed = Parameter.Speeds.Feed;
								if (Entities[i].Info.CamSpeed > 0.0)
								{
									tpPnt9D5.Feed = Entities[i].Info.CamSpeed;
								}
								camTpPoint2.Points.Add(tpPnt9D5);
							}
							else
							{
								TpPnt9D tpPnt9D6 = new TpPnt9D();
								Point3D value4 = new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z);
								if (!buCompare5.EQ(value4, ((buLine)Entities[i]).StartPoint))
								{
									tpPnt9D6 = new TpPnt9D();
									tpPnt9D6.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
									tpPnt9D6.ToolNo = Tool.Data.No;
									tpPnt9D6.ToolName = Tool.Data.Name;
									tpPnt9D6.Type = 0;
									tpPnt9D6.P9 = new Pnt9D(((buLine)Entities[i]).StartPoint.X, ((buLine)Entities[i]).StartPoint.Y, ((buLine)Entities[i]).StartPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
									tpPnt9D6.Feed = Parameter.Speeds.Feed;
									camTpPoint2.Points.Add(tpPnt9D6);
								}
								tpPnt9D6 = new TpPnt9D();
								tpPnt9D6.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
								tpPnt9D6.ToolNo = Tool.Data.No;
								tpPnt9D6.ToolName = Tool.Data.Name;
								tpPnt9D6.Type = 1;
								tpPnt9D6.P9 = new Pnt9D(((buLine)Entities[i]).EndPoint.X, ((buLine)Entities[i]).EndPoint.Y, ((buLine)Entities[i]).EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
								tpPnt9D6.Feed = Parameter.Speeds.Feed;
								if (Entities[i].Info.CamSpeed > 0.0)
								{
									tpPnt9D6.Feed = Entities[i].Info.CamSpeed;
								}
								camTpPoint2.Points.Add(tpPnt9D6);
							}
						}
						else
						{
							TpPnt9D tpPnt9D7 = new TpPnt9D();
							tpPnt9D7.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
							tpPnt9D7.ToolNo = Tool.Data.No;
							tpPnt9D7.ToolName = Tool.Data.Name;
							tpPnt9D7.Type = 0;
							tpPnt9D7.P9 = new Pnt9D(Entities[i].EndPoint.X, Entities[i].EndPoint.Y, Entities[i].EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
							tpPnt9D7.Feed = Parameter.Speeds.Rapid;
							camTpPoint2.Points.Add(tpPnt9D7);
						}
					}
					else
					{
						TpPnt9D tpPnt9D8 = new TpPnt9D();
						tpPnt9D8.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
						tpPnt9D8.ToolNo = Tool.Data.No;
						tpPnt9D8.ToolName = Tool.Data.Name;
						tpPnt9D8.Type = 0;
						tpPnt9D8.LeaveAxisMovement = true;
						if (!buCompare5.EQ(Entities[i].Orientation.A, 0.0))
						{
							tpPnt9D8.LeaveAxis = "";
						}
						if (buCompare5.EQ(Entities[i].Orientation.A, 90.0) | buCompare5.EQ(Entities[i].Orientation.A, -90.0))
						{
							tpPnt9D8.LeaveAxis = "Y";
						}
						if (Entities[i].Info.CamLeaveAxis != null)
						{
							tpPnt9D8.LeaveAxis = Entities[i].Info.CamLeaveAxis;
						}
						tpPnt9D8.P9 = new Pnt9D(Entities[i].EndPoint.X, Entities[i].EndPoint.Y, Entities[i].EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
						tpPnt9D8.Feed = Parameter.Speeds.Leave;
						camTpPoint2.Points.Add(tpPnt9D8);
					}
					continue;
				}
				TpPnt9D tpPnt9D9 = new TpPnt9D();
				if (camTpPoint2.Points.Count > 0)
				{
					Point3D value5 = new Point3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z);
					if (!buCompare5.EQ(value5, Entities[i].StartPoint))
					{
						tpPnt9D9.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
						tpPnt9D9.ToolNo = Tool.Data.No;
						tpPnt9D9.ToolName = Tool.Data.Name;
						tpPnt9D9.Type = 0;
						tpPnt9D9.P9 = new Pnt9D(Entities[i].StartPoint.X, Entities[i].StartPoint.Y, Entities[i].StartPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
						tpPnt9D9.Feed = Parameter.Speeds.Rapid;
						camTpPoint2.Points.Add(tpPnt9D9);
					}
				}
				tpPnt9D9 = new TpPnt9D();
				tpPnt9D9.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
				tpPnt9D9.ToolNo = Tool.Data.No;
				tpPnt9D9.ToolName = Tool.Data.Name;
				tpPnt9D9.Type = 1;
				tpPnt9D9.PlungeAxisMovement = true;
				if (Entities[i].typeDefination == entityTypeDefination.CamPlungeFast)
				{
					tpPnt9D9.Type = 0;
				}
				if (buCompare5.EQ(Entities[i].Orientation.A, 90.0) | buCompare5.EQ(Entities[i].Orientation.A, -90.0))
				{
					tpPnt9D9.PlungeAxis = "Y";
				}
				if (Entities[i].Info.CamPlungeAxis != null)
				{
					tpPnt9D9.PlungeAxis = Entities[i].Info.CamPlungeAxis;
				}
				tpPnt9D9.P9 = new Pnt9D(Entities[i].EndPoint.X, Entities[i].EndPoint.Y, Entities[i].EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
				tpPnt9D9.Feed = Parameter.Speeds.Plunge;
				if (Entities[i].Info.CamSpeed > 0.0)
				{
					tpPnt9D9.Feed = Entities[i].Info.CamSpeed;
				}
				camTpPoint2.Points.Add(tpPnt9D9);
				continue;
			}
			buArc buArc2 = Entities[i] as buArc;
			if (buArc2.sortDirection != entitySortDirection.Reverse)
			{
				TpPnt9D tpPnt9D10 = new TpPnt9D();
				tpPnt9D10.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
				tpPnt9D10.ToolNo = Tool.Data.No;
				tpPnt9D10.ToolName = Tool.Data.Name;
				tpPnt9D10.ArcData = new TpArcData(buArc2.Center, buArc2.StartPoint, buArc2.EndPoint);
				tpPnt9D10.ArcData.Radius = buArc2.Radius;
				tpPnt9D10.ArcData.StartAngle = buCall.buVector5_0.PointAngle(buArc2.StartPoint, buArc2.Center, buArc2.Plane);
				tpPnt9D10.ArcData.EndAngle = buCall.buVector5_0.PointAngle(buArc2.EndPoint, buArc2.Center, buArc2.Plane);
				tpPnt9D10.ArcData.SweepAngle = tpPnt9D10.ArcData.EndAngle - tpPnt9D10.ArcData.StartAngle;
				tpPnt9D10.Type = 3;
				tpPnt9D10.P9 = new Pnt9D(((buArc)Entities[i]).EndPoint.X, ((buArc)Entities[i]).EndPoint.Y, ((buArc)Entities[i]).EndPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
				tpPnt9D10.Feed = Parameter.Speeds.Feed;
				if (Entities[i].Info.CamSpeed > 0.0)
				{
					tpPnt9D10.Feed = Entities[i].Info.CamSpeed;
				}
				camTpPoint2.Points.Add(tpPnt9D10);
			}
			else
			{
				TpPnt9D tpPnt9D11 = new TpPnt9D();
				tpPnt9D11.EnableAxes = new AxesEnableWithUVW(x: true, y: true, z: true, a: true, b: false, c: false);
				tpPnt9D11.ToolNo = Tool.Data.No;
				tpPnt9D11.ToolName = Tool.Data.Name;
				tpPnt9D11.ArcData = new TpArcData(buArc2.Center, buArc2.StartPoint, buArc2.EndPoint);
				tpPnt9D11.ArcData.Radius = buArc2.Radius;
				tpPnt9D11.ArcData.StartAngle = buCall.buVector5_0.PointAngle(buArc2.StartPoint, buArc2.Center, buArc2.Plane);
				tpPnt9D11.ArcData.EndAngle = buCall.buVector5_0.PointAngle(buArc2.EndPoint, buArc2.Center, buArc2.Plane);
				tpPnt9D11.ArcData.SweepAngle = tpPnt9D11.ArcData.EndAngle - tpPnt9D11.ArcData.StartAngle;
				tpPnt9D11.Type = 2;
				tpPnt9D11.P9 = new Pnt9D(((buArc)Entities[i]).StartPoint.X, ((buArc)Entities[i]).StartPoint.Y, ((buArc)Entities[i]).StartPoint.Z, Entities[i].Orientation.A, Entities[i].Orientation.B, Entities[i].Orientation.C);
				tpPnt9D11.Feed = Parameter.Speeds.Feed;
				if (Entities[i].Info.CamSpeed > 0.0)
				{
					tpPnt9D11.Feed = Entities[i].Info.CamSpeed;
				}
				camTpPoint2.Points.Add(tpPnt9D11);
			}
		}
		camTp2.Tool = new ToolBase5(Tool);
		camTp2.CamPoints.Add(camTpPoint2);
		Cam.Add(camTp2);
		return true;
	}

	public bool camContourCenter(List<Entity> RefEntities, bool TangentCalculaton, ToolBase5 Tool, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Contour  ";
		List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
		List<double> Heights = new List<double>();
		List<double> Heights2 = new List<double>();
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D value = new Point3D();
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double feed = camPars.Speeds.Feed;
		double plunge = camPars.Speeds.Plunge;
		double leave = camPars.Speeds.Leave;
		double rapid = camPars.Speeds.Rapid;
		CamCalculated.TypeCam = CamType.ContourOpenCenter;
		if (!((Tool.Purpose == ToolPurpose.DiamondCut) | (Tool.Purpose == ToolPurpose.Saw)))
		{
		}
		buCall.buVector5_0.SplitArcEntitiesIfGreaterThen180Degree(ref RefEntities);
		buCall.buVector5_0.EntitiesSplitByUpperLine(RefEntities, ref SplitedEntitites);
		num3 = (camPars.Steps.Enable ? camPars.Steps.StartValue : camPars.Operations.Height);
		if (camPars.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByRegions)
		{
			if (!camPars.Steps.Enable)
			{
				Heights2.Clear();
				Heights2.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights2);
			}
			Heights.Add(0.0);
		}
		else
		{
			if (!camPars.Steps.Enable)
			{
				Heights.Clear();
				Heights.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights);
			}
			Heights2.Add(0.0);
		}
		bool flag = false;
		for (int i = 0; i <= Heights2.Count - 1; i++)
		{
			for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
			{
				bool flag2 = false;
				bool flag3 = false;
				List<Entity> ChangedEntities = new List<Entity>();
				if ((i == Heights2.Count - 1) & (j == SplitedEntitites.Count - 1))
				{
					flag = true;
				}
				flag2 = buCall.buVector5_0.isEntitiesClosed(SplitedEntitites[j]);
				ClockDirectionType clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(SplitedEntitites[j]);
				if (!flag2)
				{
					buVector5.CopyEntities(SplitedEntitites[j], ref ChangedEntities);
				}
				else if (clockDirectionType == camPars.Operations.Direction)
				{
					buVector5.CopyEntities(SplitedEntitites[j], ref ChangedEntities);
				}
				else
				{
					buCall.buVector5_0.ChangeEntitiesDirection(SplitedEntitites[j], ref ChangedEntities);
				}
				for (int k = 0; k <= Heights.Count - 1; k++)
				{
					double z = Heights[k];
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
					{
						z = Heights2[i];
					}
					buLineCam buLineCam2 = null;
					buLinearPathCam buLinearPathCam2 = null;
					List<Point3D> list = new List<Point3D>();
					List<Entity> copiedEnt = new List<Entity>();
					if (flag2)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt);
					}
					else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt);
					}
					else if (k % 2 != 0)
					{
						buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt);
					}
					else
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt);
					}
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && k < Heights.Count - 1)
					{
						List<Entity> copiedEnt2 = new List<Entity>();
						if (flag2)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
						}
						else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
						}
						else if ((k + 1) % 2 != 0)
						{
							buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt2);
						}
						else
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
						}
						if (copiedEnt2.Count > 0)
						{
							value = ((buCall.buVector5_0.GetEntityCustomData(copiedEnt2[0]).sortDirection == entitySortDirection.Normal) ? new Point3D(((ICurve)copiedEnt2[0]).StartPoint.X, ((ICurve)copiedEnt2[0]).StartPoint.Y, z) : new Point3D(((ICurve)copiedEnt2[0]).EndPoint.X, ((ICurve)copiedEnt2[0]).EndPoint.Y, z));
						}
					}
					for (int l = 0; l <= copiedEnt.Count - 1; l++)
					{
						Pnt6D pnt6D = new Pnt6D();
						Entity entity = copiedEnt[l];
						List<Point3D> PointList = new List<Point3D>();
						bool flag4 = false;
						bool flag5 = false;
						double safe = camPars.Distances.Safe;
						double num4 = 0.0;
						feed = camPars.Speeds.Feed;
						plunge = camPars.Speeds.Plunge;
						leave = camPars.Speeds.Leave;
						rapid = camPars.Speeds.Rapid;
						if (camPars.Options.FeedFromEntityFeedrate && ((CustomData)copiedEnt[l].EntityData).CamFeedrate > 0.0)
						{
							feed = ((CustomData)copiedEnt[l].EntityData).CamFeedrate;
							plunge = ((CustomData)copiedEnt[l].EntityData).CamFeedrate;
							leave = ((CustomData)copiedEnt[l].EntityData).CamFeedrate;
							rapid = ((CustomData)copiedEnt[l].EntityData).CamFeedrate;
						}
						if (entity is ICurve)
						{
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							if (!camPars.Options.UseXZPlane)
							{
								buCall.buVector5_0.SetValueToPointList(0.0, 0.0, z, XEnable: false, YEnable: false, ZEnable: true, ref PointList);
							}
							if (!(entity is Line))
							{
								if (!(entity is Arc))
								{
									if (!(entity is LinearPath))
									{
										if (!(entity is Curve))
										{
											if (!(entity is Ellipse))
											{
												if (entity.GetType() == typeof(EllipticalArc))
												{
													if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
													{
														if (l == 0)
														{
															point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
														}
														PointList.Reverse();
													}
													else if (l == 0)
													{
														point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
													}
												}
											}
											else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
											{
												if (l == 0)
												{
													point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
												}
												PointList.Reverse();
											}
											else if (l == 0)
											{
												point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
											}
										}
										else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
										{
											if (l == 0)
											{
												point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
											}
											PointList.Reverse();
										}
										else if (l == 0)
										{
											point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
										}
									}
									else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (l == 0)
										{
											point3D = (camPars.Options.UseXZPlane ? new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, entity.Vertices[entity.Vertices.Length - 1].Z) : new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z));
										}
										PointList.Reverse();
									}
									else if (l == 0)
									{
										point3D = (camPars.Options.UseXZPlane ? new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, entity.Vertices[0].Z) : new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z));
									}
								}
								else
								{
									flag4 = true;
									if (TangentCalculaton)
									{
										flag4 = false;
									}
									if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (l == 0)
										{
											point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
										}
										PointList.Reverse();
									}
									else if (l == 0)
									{
										point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
									}
								}
							}
							else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								if (l == 0)
								{
									point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
								}
								PointList.Reverse();
							}
							else if (l == 0)
							{
								point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
							}
						}
						if (!(j == 0 && l == 0))
						{
							safe = num3 + camPars.Distances.Rapid;
							if (((j > 0 && l == 0) & (camTpPoint2.Points.Count > 0)) && safe < camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z)
							{
								safe = camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z;
							}
						}
						else
						{
							safe = camPars.Distances.Safe;
						}
						if (l == 0)
						{
							flag5 = true;
						}
						if ((flag2 || flag3) && k > 0)
						{
							flag5 = false;
						}
						num4 = buCall.buVector5_0.PointAngle(PointList[1], PointList[0], Plane.XY);
						num4 += camPars.Strategy.TangentOffset;
						if (buCompare5.EQ(num4, 0.0) && num2 > 180.0)
						{
							num4 = 360.0;
						}
						if (((k == 0 && l == 0) & camPars.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle) && num4 > 180.0)
						{
							num4 -= 360.0;
						}
						if (num <= 0)
						{
							num2 = num4;
						}
						else
						{
							buCall.buVector5_0.CamTangentCalculation(ref num4, num2, camPars);
						}
						if (flag3 && (buCompare5.EQ(Math.Abs(num4 - num2), 0.0) | buCompare5.EQ(Math.Abs(num4 - num2), 180.0)))
						{
							num4 = num2;
						}
						if (camPars.Strategy.UseContantTangent)
						{
							num4 = camPars.Strategy.ContantTangent;
							num2 = camPars.Strategy.ContantTangent;
						}
						if (!buCompare5.EQ(num4, num2) && TangentCalculaton)
						{
							flag5 = true;
						}
						if (!TangentCalculaton)
						{
							num4 = 0.0;
						}
						if (l == 0)
						{
							list.Add(buVector5.ToPoint3D(point3D));
							pnt6D = new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num4);
							if (!flag5)
							{
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
							else
							{
								if (j == 0)
								{
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe), leave, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe, 0.0, 0.0, pnt6D.C), rapid, 0);
								camTpPoint2.Points.Add(tpPnt9D);
								if (safe != num3 + camPars.Distances.EntryAndExit)
								{
									buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, safe), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
									buLineCam2.MoveType = CamMoveType.G0;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesPlunge.Add(buLineCam2);
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit), new Point3D(pnt3D.X, pnt3D.Y, z));
								buLineCam2.MoveType = CamMoveType.Plunge;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesPlunge.Add(buLineCam2);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
						}
						if (l > 0 && TangentCalculaton)
						{
							double value2 = num4 - num2;
							if ((Math.Abs(value2) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit)
							{
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
								tpPnt9D.Type = 1;
								tpPnt9D.Feed = leave;
								tpPnt9D.PlungeAxisMovement = true;
								tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid));
								buLineCam2.MoveType = CamMoveType.Leave;
								buLineCam2.Color = Color.Blue;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesLeave.Add(buLineCam2);
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num4);
								tpPnt9D.Type = 0;
								tpPnt9D.Feed = rapid;
								tpPnt9D.PlungeAxisMovement = false;
								camTpPoint2.Points.Add(tpPnt9D);
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z, 0.0, 0.0, num4);
								tpPnt9D.Type = 1;
								tpPnt9D.Feed = plunge;
								tpPnt9D.PlungeAxisMovement = true;
								tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid), new Point3D(point3D3.X, point3D3.Y, point3D3.Z));
								buLineCam2.MoveType = CamMoveType.Plunge;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesPlunge.Add(buLineCam2);
							}
						}
						if (flag4)
						{
							if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								pnt6D = new Pnt6D(((ICurve)entity).StartPoint.X, ((ICurve)entity).StartPoint.Y, z);
								pnt3D = new Pnt3D(pnt6D);
								if (!(((Arc)entity).Plane.Equation.Z > 0.0))
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
									tpPnt9D.ArcType = 3;
								}
								else
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
									tpPnt9D.ArcType = 2;
								}
								tpPnt9D.Radius = ((Arc)entity).Radius;
							}
							else
							{
								pnt6D = new Pnt6D(((ICurve)entity).EndPoint.X, ((ICurve)entity).EndPoint.Y, z);
								pnt3D = new Pnt3D(pnt6D);
								if (!(((Arc)entity).Plane.Equation.Z > 0.0))
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
									tpPnt9D.ArcType = 2;
								}
								else
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
									tpPnt9D.ArcType = 3;
								}
								tpPnt9D.Radius = ((Arc)entity).Radius;
							}
							if (!(((Arc)entity).Plane.Equation.Z > 0.0))
							{
								tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
								tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
							}
							else
							{
								tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
								tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
							}
							tpPnt9D.ArcData.CenterPoint = new Point3D(((Arc)entity).Center.X, ((Arc)entity).Center.Y, z);
							tpPnt9D.ArcData.SweepAngle = ((Arc)entity).AngleInDegrees;
							tpPnt9D.ArcData.Radius = ((Arc)entity).Radius;
							tpPnt9D.ArcData.Length = ((Arc)entity).Length();
							tpPnt9D.ArcData.StartAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
							tpPnt9D.ArcData.EndAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.EndPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
							if (tpPnt9D.ArcData.StartAngle > tpPnt9D.ArcData.EndAngle)
							{
								tpPnt9D.ArcData.EndAngle += 360.0;
							}
							camTpPoint2.Points.Add(tpPnt9D);
							point3D3 = new Point3D(pnt3D.X, pnt3D.Y, z);
							for (int m = 1; m <= PointList.Count - 1; m++)
							{
								list.Add(new Point3D(PointList[m].X, PointList[m].Y, z));
							}
						}
						else
						{
							for (int n = 1; n <= PointList.Count - 1; n++)
							{
								num4 = buCall.buVector5_0.PointAngle(PointList[n], PointList[n - 1], Plane.XY);
								num4 += camPars.Strategy.TangentOffset;
								if (buCompare5.EQ(num4, 0.0) && num2 > 180.0)
								{
									num4 = 360.0;
								}
								buCall.buVector5_0.CamTangentCalculation(ref num4, num2, camPars);
								if (flag3 && (buCompare5.EQ(Math.Abs(num4 - num2), 0.0) | buCompare5.EQ(Math.Abs(num4 - num2), 180.0)))
								{
									num4 = num2;
								}
								if (camPars.Strategy.UseContantTangent)
								{
									num4 = camPars.Strategy.ContantTangent;
								}
								double value3 = num4 - num2;
								if (!TangentCalculaton)
								{
									num4 = 0.0;
									num2 = 0.0;
								}
								if (TangentCalculaton && n > 1 && ((Math.Abs(value3) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit))
								{
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
									tpPnt9D.Type = 1;
									tpPnt9D.Feed = leave;
									tpPnt9D.PlungeAxisMovement = true;
									tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid));
									buLineCam2.MoveType = CamMoveType.Leave;
									buLineCam2.Color = Color.Blue;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesLeave.Add(buLineCam2);
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num4);
									tpPnt9D.Type = 0;
									tpPnt9D.Feed = rapid;
									tpPnt9D.PlungeAxisMovement = false;
									camTpPoint2.Points.Add(tpPnt9D);
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z, 0.0, 0.0, num4);
									tpPnt9D.Type = 1;
									tpPnt9D.Feed = plunge;
									tpPnt9D.PlungeAxisMovement = true;
									tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid), new Point3D(point3D3.X, point3D3.Y, point3D3.Z));
									buLineCam2.MoveType = CamMoveType.Plunge;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesPlunge.Add(buLineCam2);
								}
								pnt6D = new Pnt6D(PointList[n].X, PointList[n].Y, PointList[n].Z, 0.0, 0.0, num4);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 1);
								camTpPoint2.Points.Add(tpPnt9D);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, z);
								list.Add(buVector5.ToPoint3D(point3D3));
								num2 = num4;
							}
						}
						flag3 = false;
						if (l == copiedEnt.Count - 1)
						{
							point3D2 = new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
							if (!(flag & (k == Heights.Count - 1)))
							{
								if (!(!buCompare5.EQ(value, point3D2) | (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)))
								{
									flag3 = true;
									if (k == Heights.Count - 1)
									{
										pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
										tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), leave, 1));
										tpPnt9D.PlungeAxis = "Z";
										tpPnt9D.PlungeAxisMovement = true;
										camTpPoint2.Points.Add(tpPnt9D);
										buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
										buLineCam2.MoveType = CamMoveType.Leave;
										buLineCam2.Color = Color.Green;
										buLineCam2.CamID = camPars.Runtime.CamID;
										CamCalculated.EntitiesLeave.Add(buLineCam2);
										point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
									}
								}
								else
								{
									pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
									tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), leave, 1));
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
									buLineCam2.MoveType = CamMoveType.Leave;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesLeave.Add(buLineCam2);
									point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
								}
							}
							else
							{
								pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
								tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), leave, 1));
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe));
								buLineCam2.MoveType = CamMoveType.Leave;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesLeave.Add(buLineCam2);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
							}
						}
						num2 = num4;
						num++;
					}
					buLinearPathCam2 = new buLinearPathCam(list);
					buLinearPathCam2.MoveType = CamMoveType.G1;
					buLinearPathCam2.Color = Color.Red;
					buLinearPathCam2.CamID = camPars.Runtime.CamID;
					CamCalculated.EntitiesG1.Add(buLinearPathCam2);
				}
			}
		}
		if (!TangentCalculaton)
		{
			for (int num5 = 0; num5 <= camTpPoint2.Points.Count - 1; num5++)
			{
				camTpPoint2.Points[num5].P9.C = 0.0;
			}
		}
		SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
		if (camTpPoint2.Points.Count > 0)
		{
			CamCalculated.Tool = new ToolBase5(Tool);
			CamCalculated.CamPoints.Add(camTpPoint2);
			camTpPoint2 = new camTpPoint();
		}
		return true;
	}

	public bool camContourCenter(List<List<Entity>> SplitedRefEntities, bool TangentCalculaton, ToolBase5 Tool, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Contour  ";
		List<List<Entity>> copiedEnt = new List<List<Entity>>();
		List<double> Heights = new List<double>();
		List<double> Heights2 = new List<double>();
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D value = new Point3D();
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double feed = camPars.Speeds.Feed;
		double plunge = camPars.Speeds.Plunge;
		double leave = camPars.Speeds.Leave;
		double rapid = camPars.Speeds.Rapid;
		CamCalculated.TypeCam = CamType.ContourOpenCenter;
		if (!((Tool.Purpose == ToolPurpose.DiamondCut) | (Tool.Purpose == ToolPurpose.Saw)))
		{
		}
		buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt);
		num3 = (camPars.Steps.Enable ? camPars.Steps.StartValue : camPars.Operations.Height);
		if (camPars.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByRegions)
		{
			if (!camPars.Steps.Enable)
			{
				Heights2.Clear();
				Heights2.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights2);
			}
			Heights.Add(0.0);
		}
		else
		{
			if (!camPars.Steps.Enable)
			{
				Heights.Clear();
				Heights.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights);
			}
			Heights2.Add(0.0);
		}
		bool flag = false;
		for (int i = 0; i <= Heights2.Count - 1; i++)
		{
			for (int j = 0; j <= copiedEnt.Count - 1; j++)
			{
				camTpPoint2 = new camTpPoint();
				bool flag2 = false;
				bool flag3 = false;
				List<Entity> ChangedEntities = new List<Entity>();
				if (j != 94)
				{
				}
				if ((i == Heights2.Count - 1) & (j == copiedEnt.Count - 1))
				{
					flag = true;
				}
				flag2 = buCall.buVector5_0.isEntitiesClosed(copiedEnt[j]);
				ClockDirectionType clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(copiedEnt[j]);
				if (!flag2)
				{
					buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
				}
				else if (clockDirectionType == camPars.Operations.Direction)
				{
					buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
				}
				else
				{
					buCall.buVector5_0.ChangeEntitiesDirection(copiedEnt[j], ref ChangedEntities);
				}
				for (int k = 0; k <= Heights.Count - 1; k++)
				{
					double z = Heights[k];
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
					{
						z = Heights2[i];
					}
					buLineCam buLineCam2 = null;
					buLinearPathCam buLinearPathCam2 = null;
					List<Point3D> list = new List<Point3D>();
					List<Entity> copiedEnt2 = new List<Entity>();
					if (flag2)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					else if (k % 2 != 0)
					{
						buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt2);
					}
					else
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && k < Heights.Count - 1)
					{
						List<Entity> copiedEnt3 = new List<Entity>();
						if (flag2)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						else if ((k + 1) % 2 != 0)
						{
							buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt3);
						}
						else
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						if (copiedEnt3.Count > 0)
						{
							value = ((buCall.buVector5_0.GetEntityCustomData(copiedEnt3[0]).sortDirection == entitySortDirection.Normal) ? new Point3D(((ICurve)copiedEnt3[0]).StartPoint.X, ((ICurve)copiedEnt3[0]).StartPoint.Y, z) : new Point3D(((ICurve)copiedEnt3[0]).EndPoint.X, ((ICurve)copiedEnt3[0]).EndPoint.Y, z));
						}
					}
					for (int l = 0; l <= copiedEnt2.Count - 1; l++)
					{
						Pnt6D pnt6D = new Pnt6D();
						Entity entity = copiedEnt2[l];
						List<Point3D> PointList = new List<Point3D>();
						bool flag4 = false;
						bool flag5 = false;
						double safe = camPars.Distances.Safe;
						double num4 = 0.0;
						feed = camPars.Speeds.Feed;
						plunge = camPars.Speeds.Plunge;
						leave = camPars.Speeds.Leave;
						rapid = camPars.Speeds.Rapid;
						if (camPars.Options.FeedFromEntityFeedrate && ((CustomData)copiedEnt2[l].EntityData).CamFeedrate > 0.0)
						{
							feed = ((CustomData)copiedEnt2[l].EntityData).CamFeedrate;
							plunge = ((CustomData)copiedEnt2[l].EntityData).CamFeedrate;
							leave = ((CustomData)copiedEnt2[l].EntityData).CamFeedrate;
							rapid = ((CustomData)copiedEnt2[l].EntityData).CamFeedrate;
						}
						if (entity is ICurve)
						{
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							buCall.buVector5_0.SetValueToPointList(0.0, 0.0, z, XEnable: false, YEnable: false, ZEnable: true, ref PointList);
							if (!(entity is Line))
							{
								if (!(entity is Arc))
								{
									if (!(entity is LinearPath))
									{
										if (!(entity is Curve))
										{
											if (!(entity is Ellipse))
											{
												if (entity.GetType() == typeof(EllipticalArc))
												{
													if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
													{
														if (l == 0)
														{
															point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
														}
														PointList.Reverse();
													}
													else if (l == 0)
													{
														point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
													}
												}
											}
											else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
											{
												if (l == 0)
												{
													point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
												}
												PointList.Reverse();
											}
											else if (l == 0)
											{
												point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
											}
										}
										else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
										{
											if (l == 0)
											{
												point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
											}
											PointList.Reverse();
										}
										else if (l == 0)
										{
											point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
										}
									}
									else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (l == 0)
										{
											point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
										}
										PointList.Reverse();
									}
									else if (l == 0)
									{
										point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
									}
								}
								else
								{
									flag4 = true;
									if (TangentCalculaton)
									{
										flag4 = false;
									}
									if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (l == 0)
										{
											point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
										}
										PointList.Reverse();
									}
									else if (l == 0)
									{
										point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
									}
								}
							}
							else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								if (l == 0)
								{
									point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
								}
								PointList.Reverse();
							}
							else if (l == 0)
							{
								point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
							}
						}
						if (!(j == 0 && l == 0))
						{
							safe = num3 + camPars.Distances.Rapid;
							if (((j > 0 && l == 0) & (camTpPoint2.Points.Count > 0)) && safe < camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z)
							{
								safe = camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z;
							}
						}
						else
						{
							safe = camPars.Distances.Safe;
						}
						if (l == 0)
						{
							flag5 = true;
						}
						if ((flag2 || flag3) && k > 0)
						{
							flag5 = false;
						}
						num4 = buCall.buVector5_0.PointAngle(PointList[1], PointList[0], Plane.XY);
						num4 += camPars.Strategy.TangentOffset;
						if (buCompare5.EQ(num4, 0.0) && num2 > 180.0)
						{
							num4 = 360.0;
						}
						if (num <= 0)
						{
							num2 = num4;
						}
						else
						{
							buCall.buVector5_0.CamTangentCalculation(ref num4, num2, camPars);
						}
						if (flag3 && (buCompare5.EQ(Math.Abs(num4 - num2), 0.0) | buCompare5.EQ(Math.Abs(num4 - num2), 180.0)))
						{
							num4 = num2;
						}
						if (camPars.Strategy.UseContantTangent)
						{
							num4 = camPars.Strategy.ContantTangent;
							num2 = camPars.Strategy.ContantTangent;
						}
						if (!buCompare5.EQ(num4, num2) && TangentCalculaton)
						{
							flag5 = true;
						}
						if (!TangentCalculaton)
						{
							num4 = 0.0;
							num2 = 0.0;
						}
						if (l == 0)
						{
							list.Add(buVector5.ToPoint3D(point3D));
							pnt6D = new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num4);
							if (!flag5)
							{
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
							else
							{
								if (j == 0)
								{
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe), leave, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe, 0.0, 0.0, pnt6D.C), rapid, 0);
								camTpPoint2.Points.Add(tpPnt9D);
								if (safe != num3 + camPars.Distances.EntryAndExit)
								{
									buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, safe), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
									buLineCam2.MoveType = CamMoveType.G0;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesPlunge.Add(buLineCam2);
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit), new Point3D(pnt3D.X, pnt3D.Y, z));
								buLineCam2.MoveType = CamMoveType.Plunge;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesPlunge.Add(buLineCam2);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
						}
						if (l > 0 && TangentCalculaton)
						{
							double value2 = num4 - num2;
							if ((Math.Abs(value2) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit)
							{
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
								tpPnt9D.Type = 1;
								tpPnt9D.Feed = leave;
								tpPnt9D.PlungeAxisMovement = true;
								tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid));
								buLineCam2.MoveType = CamMoveType.Leave;
								buLineCam2.Color = Color.Blue;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesLeave.Add(buLineCam2);
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num4);
								tpPnt9D.Type = 0;
								tpPnt9D.Feed = rapid;
								tpPnt9D.PlungeAxisMovement = false;
								camTpPoint2.Points.Add(tpPnt9D);
								tpPnt9D = new TpPnt9D();
								tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z, 0.0, 0.0, num4);
								tpPnt9D.Type = 1;
								tpPnt9D.Feed = plunge;
								tpPnt9D.PlungeAxisMovement = true;
								tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid), new Point3D(point3D3.X, point3D3.Y, point3D3.Z));
								buLineCam2.MoveType = CamMoveType.Plunge;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesPlunge.Add(buLineCam2);
							}
						}
						if (flag4)
						{
							if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								pnt6D = new Pnt6D(((ICurve)entity).StartPoint.X, ((ICurve)entity).StartPoint.Y, z);
								pnt3D = new Pnt3D(pnt6D);
								if (!(((Arc)entity).Plane.Equation.Z > 0.0))
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
									tpPnt9D.ArcType = 3;
								}
								else
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
									tpPnt9D.ArcType = 2;
								}
								tpPnt9D.Radius = ((Arc)entity).Radius;
							}
							else
							{
								pnt6D = new Pnt6D(((ICurve)entity).EndPoint.X, ((ICurve)entity).EndPoint.Y, z);
								pnt3D = new Pnt3D(pnt6D);
								if (!(((Arc)entity).Plane.Equation.Z > 0.0))
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
									tpPnt9D.ArcType = 2;
								}
								else
								{
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
									tpPnt9D.ArcType = 3;
								}
								tpPnt9D.Radius = ((Arc)entity).Radius;
							}
							if (!(((Arc)entity).Plane.Equation.Z > 0.0))
							{
								tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
								tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
							}
							else
							{
								tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
								tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
							}
							tpPnt9D.ArcData.CenterPoint = new Point3D(((Arc)entity).Center.X, ((Arc)entity).Center.Y, z);
							tpPnt9D.ArcData.SweepAngle = ((Arc)entity).AngleInDegrees;
							tpPnt9D.ArcData.Radius = ((Arc)entity).Radius;
							tpPnt9D.ArcData.Length = ((Arc)entity).Length();
							tpPnt9D.ArcData.StartAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
							tpPnt9D.ArcData.EndAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.EndPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
							if (tpPnt9D.ArcData.StartAngle > tpPnt9D.ArcData.EndAngle)
							{
								tpPnt9D.ArcData.EndAngle += 360.0;
							}
							camTpPoint2.Points.Add(tpPnt9D);
							point3D3 = new Point3D(pnt3D.X, pnt3D.Y, z);
							for (int m = 1; m <= PointList.Count - 1; m++)
							{
								list.Add(new Point3D(PointList[m].X, PointList[m].Y, z));
							}
						}
						else
						{
							for (int n = 1; n <= PointList.Count - 1; n++)
							{
								num4 = buCall.buVector5_0.PointAngle(PointList[n], PointList[n - 1], Plane.XY);
								num4 += camPars.Strategy.TangentOffset;
								if (buCompare5.EQ(num4, 0.0) && num2 > 180.0)
								{
									num4 = 360.0;
								}
								buCall.buVector5_0.CamTangentCalculation(ref num4, num2, camPars);
								if (flag3 && (buCompare5.EQ(Math.Abs(num4 - num2), 0.0) | buCompare5.EQ(Math.Abs(num4 - num2), 180.0)))
								{
									num4 = num2;
								}
								if (camPars.Strategy.UseContantTangent)
								{
									num4 = camPars.Strategy.ContantTangent;
								}
								double value3 = num4 - num2;
								if (!TangentCalculaton)
								{
									num4 = 0.0;
									num2 = 0.0;
								}
								if (TangentCalculaton && n > 1 && ((Math.Abs(value3) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit))
								{
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
									tpPnt9D.Type = 1;
									tpPnt9D.Feed = leave;
									tpPnt9D.PlungeAxisMovement = true;
									tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid));
									buLineCam2.MoveType = CamMoveType.Leave;
									buLineCam2.Color = Color.Blue;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesLeave.Add(buLineCam2);
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid, 0.0, 0.0, num4);
									tpPnt9D.Type = 0;
									tpPnt9D.Feed = rapid;
									tpPnt9D.PlungeAxisMovement = false;
									camTpPoint2.Points.Add(tpPnt9D);
									tpPnt9D = new TpPnt9D();
									tpPnt9D.P9 = new Pnt9D(point3D3.X, point3D3.Y, point3D3.Z, 0.0, 0.0, num4);
									tpPnt9D.Type = 1;
									tpPnt9D.Feed = plunge;
									tpPnt9D.PlungeAxisMovement = true;
									tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z + camPars.Distances.Rapid), new Point3D(point3D3.X, point3D3.Y, point3D3.Z));
									buLineCam2.MoveType = CamMoveType.Plunge;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesPlunge.Add(buLineCam2);
								}
								pnt6D = new Pnt6D(PointList[n].X, PointList[n].Y, PointList[n].Z, 0.0, 0.0, num4);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 1);
								camTpPoint2.Points.Add(tpPnt9D);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, z);
								list.Add(buVector5.ToPoint3D(point3D3));
								num2 = num4;
							}
						}
						flag3 = false;
						if (l == copiedEnt2.Count - 1)
						{
							point3D2 = new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
							if (!(flag & (k == Heights.Count - 1)))
							{
								if (!(!buCompare5.EQ(value, point3D2) | (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)))
								{
									flag3 = true;
									if (k == Heights.Count - 1)
									{
										pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
										tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), leave, 1));
										tpPnt9D.PlungeAxis = "Z";
										tpPnt9D.PlungeAxisMovement = true;
										camTpPoint2.Points.Add(tpPnt9D);
										buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
										buLineCam2.MoveType = CamMoveType.Leave;
										buLineCam2.Color = Color.Green;
										buLineCam2.CamID = camPars.Runtime.CamID;
										CamCalculated.EntitiesLeave.Add(buLineCam2);
										point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
									}
								}
								else
								{
									pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
									tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit, 0.0, 0.0, pnt6D.C), leave, 1));
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit));
									buLineCam2.MoveType = CamMoveType.Leave;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesLeave.Add(buLineCam2);
									point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
								}
							}
							else
							{
								pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
								tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), leave, 1));
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe));
								buLineCam2.MoveType = CamMoveType.Leave;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesLeave.Add(buLineCam2);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num3 + camPars.Distances.EntryAndExit);
							}
						}
						num2 = num4;
						num++;
					}
					buLinearPathCam2 = new buLinearPathCam(list);
					buLinearPathCam2.MoveType = CamMoveType.G1;
					buLinearPathCam2.Color = Color.Red;
					buLinearPathCam2.CamID = camPars.Runtime.CamID;
					CamCalculated.EntitiesG1.Add(buLinearPathCam2);
				}
				CamCalculated.CamPoints.Add(camTpPoint2);
			}
		}
		for (int num5 = 0; num5 <= CamCalculated.CamPoints.Count - 1; num5++)
		{
			SimPointCreatForDetailedPoints(CamCalculated.CamPoints[num5].Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
		}
		if (camTpPoint2.Points.Count <= 0)
		{
		}
		return true;
	}

	public bool camSpin(List<List<Entity>> SplitedRefEntities, bool TangentCalculaton, ToolBase5 Tool, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Contour  ";
		List<List<Entity>> copiedEnt = new List<List<Entity>>();
		List<double> Heights = new List<double>();
		List<double> Heights2 = new List<double>();
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D value = new Point3D();
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		CamCalculated.TypeCam = CamType.ContourOpenCenter;
		if (!((Tool.Purpose == ToolPurpose.DiamondCut) | (Tool.Purpose == ToolPurpose.Saw)))
		{
		}
		buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt);
		num2 = (camPars.Steps.Enable ? camPars.Steps.StartValue : camPars.Operations.Height);
		if (camPars.Strategy.MachiningAreaMode != CamMachiningAreaMode.MachByRegions)
		{
			if (!camPars.Steps.Enable)
			{
				Heights2.Clear();
				Heights2.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights2);
			}
			Heights.Add(0.0);
		}
		else
		{
			if (!camPars.Steps.Enable)
			{
				Heights.Clear();
				Heights.Add(camPars.Operations.Height);
			}
			else
			{
				buCall.buVector5_0.CamStepHeightCalculation(camPars.Steps, ref Heights);
			}
			Heights2.Add(0.0);
		}
		bool flag = false;
		for (int i = 0; i <= Heights2.Count - 1; i++)
		{
			for (int j = 0; j <= copiedEnt.Count - 1; j++)
			{
				bool flag2 = false;
				bool flag3 = false;
				List<Entity> ChangedEntities = new List<Entity>();
				if ((i == Heights2.Count - 1) & (j == copiedEnt.Count - 1))
				{
					flag = true;
				}
				flag2 = buCall.buVector5_0.isEntitiesClosed(copiedEnt[j]);
				ClockDirectionType clockDirectionType = buCall.buVector5_0.EntitiesClockDirection(copiedEnt[j]);
				if (!flag2)
				{
					buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
				}
				else if (clockDirectionType == camPars.Operations.Direction)
				{
					buVector5.CopyEntities(copiedEnt[j], ref ChangedEntities);
				}
				else
				{
					buCall.buVector5_0.ChangeEntitiesDirection(copiedEnt[j], ref ChangedEntities);
				}
				for (int k = 0; k <= Heights.Count - 1; k++)
				{
					double z = Heights[k];
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)
					{
						z = Heights2[i];
					}
					buLineCam buLineCam2 = null;
					buLinearPathCam buLinearPathCam2 = null;
					List<Point3D> list = new List<Point3D>();
					List<Entity> copiedEnt2 = new List<Entity>();
					if (flag2)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					else if (k % 2 != 0)
					{
						buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt2);
					}
					else
					{
						buVector5.CopyEntities(ChangedEntities, ref copiedEnt2);
					}
					if (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByRegions && k < Heights.Count - 1)
					{
						List<Entity> copiedEnt3 = new List<Entity>();
						if (flag2)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						else if (camPars.Strategy.CuttingMethod != CamCuttingMethod.MachtypeZigzag)
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						else if ((k + 1) % 2 != 0)
						{
							buCall.buVector5_0.ChangeEntitiesDirection(ChangedEntities, ref copiedEnt3);
						}
						else
						{
							buVector5.CopyEntities(ChangedEntities, ref copiedEnt3);
						}
						if (copiedEnt3.Count > 0)
						{
							value = ((buCall.buVector5_0.GetEntityCustomData(copiedEnt3[0]).sortDirection == entitySortDirection.Normal) ? new Point3D(((ICurve)copiedEnt3[0]).StartPoint.X, ((ICurve)copiedEnt3[0]).StartPoint.Y, z) : new Point3D(((ICurve)copiedEnt3[0]).EndPoint.X, ((ICurve)copiedEnt3[0]).EndPoint.Y, z));
						}
					}
					double num4 = 0.0;
					for (int l = 0; l <= copiedEnt2.Count - 1; l++)
					{
						num4 += ((ICurve)copiedEnt2[l]).Length();
					}
					double num5 = 0.0;
					double num6 = 0.0;
					double num7 = camPars.Strategy.SpinCEndAngle / num4;
					for (int m = 0; m <= copiedEnt2.Count - 1; m++)
					{
						Pnt6D pnt6D = new Pnt6D();
						Entity entity = copiedEnt2[m];
						List<Point3D> PointList = new List<Point3D>();
						bool flag4 = false;
						bool flag5 = false;
						double safe = camPars.Distances.Safe;
						num6 = 0.0;
						if (entity is ICurve)
						{
							buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
							buCall.buVector5_0.SetValueToPointList(0.0, 0.0, z, XEnable: false, YEnable: false, ZEnable: true, ref PointList);
							if (!(entity is Line))
							{
								if (!(entity is Arc))
								{
									if (!(entity is LinearPath))
									{
										if (!(entity is Curve))
										{
											if (!(entity is Ellipse))
											{
												if (entity.GetType() == typeof(EllipticalArc))
												{
													if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
													{
														if (m == 0)
														{
															point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
														}
														PointList.Reverse();
													}
													else if (m == 0)
													{
														point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
													}
												}
											}
											else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
											{
												if (m == 0)
												{
													point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
												}
												PointList.Reverse();
											}
											else if (m == 0)
											{
												point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
											}
										}
										else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
										{
											if (m == 0)
											{
												point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
											}
											PointList.Reverse();
										}
										else if (m == 0)
										{
											point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
										}
									}
									else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (m == 0)
										{
											point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
										}
										PointList.Reverse();
									}
									else if (m == 0)
									{
										point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
									}
								}
								else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
								{
									if (m == 0)
									{
										point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
									}
									PointList.Reverse();
								}
								else if (m == 0)
								{
									point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
								}
							}
							else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								if (m == 0)
								{
									point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
								}
								PointList.Reverse();
							}
							else if (m == 0)
							{
								point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
							}
						}
						safe = ((j == 0 && m == 0) ? camPars.Distances.Safe : (num2 + camPars.Distances.Rapid));
						if (m == 0)
						{
							flag5 = true;
						}
						if ((flag2 || flag3) && k > 0)
						{
							flag5 = false;
						}
						if (m == 0)
						{
							num6 = num3 + camPars.Strategy.SpinCStartAngle;
							list.Add(buVector5.ToPoint3D(point3D));
							pnt6D = new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num6);
							if (!flag5)
							{
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), camPars.Speeds.Plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
							else
							{
								if (j == 0)
								{
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe), camPars.Speeds.Leave, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, safe, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
								camTpPoint2.Points.Add(tpPnt9D);
								if (safe != num2 + camPars.Distances.Rapid)
								{
									buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, safe), new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid));
									buLineCam2.MoveType = CamMoveType.G0;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesPlunge.Add(buLineCam2);
									pnt3D = new Pnt3D(pnt6D);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
								}
								buLineCam2 = new buLineCam(new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid), new Point3D(pnt3D.X, pnt3D.Y, z));
								buLineCam2.MoveType = CamMoveType.Plunge;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesPlunge.Add(buLineCam2);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), camPars.Speeds.Plunge, 1);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
							}
						}
						if (!flag4)
						{
							for (int n = 1; n <= PointList.Count - 1; n++)
							{
								num5 += Point3D.Distance(PointList[n - 1], PointList[n]);
								num6 = num3 + num5 * num7;
								pnt6D = new Pnt6D(PointList[n].X, PointList[n].Y, PointList[n].Z, 0.0, 0.0, num6);
								pnt3D = new Pnt3D(pnt6D);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), camPars.Speeds.Feed, 1);
								camTpPoint2.Points.Add(tpPnt9D);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, z);
								list.Add(buVector5.ToPoint3D(point3D3));
							}
						}
						flag3 = false;
						if (m == copiedEnt2.Count - 1)
						{
							point3D2 = new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
							if (!(flag & (k == Heights.Count - 1)))
							{
								if (!(!buCompare5.EQ(value, point3D2) | (camPars.Strategy.MachiningAreaMode == CamMachiningAreaMode.MachByLanes)))
								{
									flag3 = true;
									if (k == Heights.Count - 1)
									{
										pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
										tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
										tpPnt9D.PlungeAxis = "Z";
										tpPnt9D.PlungeAxisMovement = true;
										camTpPoint2.Points.Add(tpPnt9D);
										buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid));
										buLineCam2.MoveType = CamMoveType.Leave;
										buLineCam2.Color = Color.Green;
										buLineCam2.CamID = camPars.Runtime.CamID;
										CamCalculated.EntitiesLeave.Add(buLineCam2);
										point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid);
									}
								}
								else
								{
									pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
									tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
									tpPnt9D.PlungeAxis = "Z";
									tpPnt9D.PlungeAxisMovement = true;
									camTpPoint2.Points.Add(tpPnt9D);
									buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid));
									buLineCam2.MoveType = CamMoveType.Leave;
									buLineCam2.Color = Color.Green;
									buLineCam2.CamID = camPars.Runtime.CamID;
									CamCalculated.EntitiesLeave.Add(buLineCam2);
									point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid);
								}
							}
							else
							{
								pnt3D = new Pnt3D(point3D2.X, point3D2.Y, point3D2.Z);
								tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
								tpPnt9D.PlungeAxis = "Z";
								tpPnt9D.PlungeAxisMovement = true;
								camTpPoint2.Points.Add(tpPnt9D);
								buLineCam2 = new buLineCam(new Point3D(point3D3.X, point3D3.Y, point3D3.Z), new Point3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe));
								buLineCam2.MoveType = CamMoveType.Leave;
								buLineCam2.Color = Color.Green;
								buLineCam2.CamID = camPars.Runtime.CamID;
								CamCalculated.EntitiesLeave.Add(buLineCam2);
								point3D3 = new Point3D(pnt3D.X, pnt3D.Y, num2 + camPars.Distances.Rapid);
							}
						}
						num++;
					}
					num3 = num6;
					buLinearPathCam2 = new buLinearPathCam(list);
					buLinearPathCam2.MoveType = CamMoveType.G1;
					buLinearPathCam2.Color = Color.Red;
					buLinearPathCam2.CamID = camPars.Runtime.CamID;
					CamCalculated.EntitiesG1.Add(buLinearPathCam2);
				}
			}
		}
		if (!TangentCalculaton)
		{
			for (int num8 = 0; num8 <= camTpPoint2.Points.Count - 1; num8++)
			{
				camTpPoint2.Points[num8].P9.C = 0.0;
			}
		}
		SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
		if (camTpPoint2.Points.Count > 0)
		{
			CamCalculated.CamPoints.Add(camTpPoint2);
			camTpPoint2 = new camTpPoint();
		}
		return true;
	}

	public void camDrill(List<Pnt6D> RefPoints, ToolBase5 Tool, WorkPlane Plane, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Point  ";
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		double num = 0.0;
		double num2 = Tool.Geometry.Diameter;
		CamCalculated.TypeCam = CamType.Drill;
		if ((Tool.Purpose == ToolPurpose.DiamondCut) | (Tool.Purpose == ToolPurpose.Saw))
		{
			num2 = Tool.Geometry.Thickness;
		}
		camPars.Operations.StepHeights.Clear();
		camPars.Operations.StepHeights.Add(camPars.Drill.EndHeight);
		if (camPars.Drill.PeckMode)
		{
			double num3 = camPars.Drill.StartHeight - camPars.Drill.EndHeight;
			int num4 = Convert.ToInt32(buNumeric5.RoundToLower(num3 / camPars.Drill.PeckDepth));
			camPars.Operations.StepHeights.Clear();
			for (int i = 1; i <= num4; i++)
			{
				camPars.Operations.StepHeights.Add(camPars.Drill.StartHeight - (double)i * camPars.Drill.PeckDepth);
			}
			if (camPars.Operations.StepHeights.Count <= 0)
			{
				camPars.Operations.StepHeights.Add(camPars.Drill.EndHeight);
			}
			else if (!buCompare5.EQ(camPars.Operations.StepHeights[camPars.Operations.StepHeights.Count - 1], camPars.Drill.EndHeight))
			{
				camPars.Operations.StepHeights.Add(camPars.Drill.EndHeight);
			}
		}
		for (int j = 0; j <= RefPoints.Count - 1; j++)
		{
			Pnt6D pnt6D = new Pnt6D(RefPoints[j]);
			pnt6D.C += camPars.Strategy.TangentOffset;
			if (camPars.Strategy.UseContantTangent)
			{
				pnt6D.C = camPars.Strategy.ContantTangent;
			}
			if (j > 0)
			{
				double num5 = pnt6D.C - num;
				if (Math.Abs(num5) > 180.0)
				{
					if (!(num5 > 0.0))
					{
						pnt6D.C += 360.0;
					}
					else
					{
						pnt6D.C -= 360.0;
					}
				}
				if (pnt6D.C > camPars.Strategy.MaxTangentValue)
				{
					double num6 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					if (!(num6 >= 360.0))
					{
						pnt6D.C -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					}
					else
					{
						pnt6D.C -= 360.0;
					}
				}
				if (pnt6D.C < camPars.Strategy.MinTangentValue)
				{
					double num7 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					if (!(num7 >= 360.0))
					{
						pnt6D.C += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					}
					else
					{
						pnt6D.C += 360.0;
					}
				}
			}
			if (j != 0)
			{
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			else
			{
				camTpPoint2 = new camTpPoint();
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe), camPars.Speeds.Leave, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			for (int k = 0; k <= camPars.Operations.StepHeights.Count - 1; k++)
			{
				pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, camPars.Operations.StepHeights[k]);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z, 0.0, 0.0, pnt6D.C), camPars.Speeds.Plunge, 1);
				if (k != 0)
				{
					tpPnt9D.SimDevideLen = (camPars.Operations.StepHeights[k - 1] - camPars.Operations.StepHeights[k]) / 4.0;
				}
				else
				{
					tpPnt9D.SimDevideLen = (camPars.Drill.StartHeight - camPars.Operations.StepHeights[k]) / 4.0;
				}
				camTpPoint2.Points.Add(tpPnt9D);
				if (camPars.Drill.PeckMode & (k < camPars.Operations.StepHeights.Count - 1))
				{
					pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, camPars.Operations.StepHeights[k] + camPars.Drill.PeckMinRetractDistance);
					if (camPars.Drill.PeckFullRetract)
					{
						pnt3D.Z = camPars.Drill.StartHeight;
					}
					tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z, 0.0, 0.0, pnt6D.C), camPars.Speeds.Leave, 1);
					tpPnt9D.SimDevideLen = (tpPnt9D.P9.Z - camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z) / 4.0;
					camTpPoint2.Points.Add(tpPnt9D);
				}
			}
			buLineCam buLineCam2 = new buLineCam(new Point3D(pnt3D2.X, pnt3D2.Y, camPars.Drill.StartHeight), new Point3D(pnt3D.X, pnt3D.Y, camPars.Drill.EndHeight));
			buLineCam2.MoveType = CamMoveType.G1;
			buLineCam2.Color = Color.Red;
			buLineCam2.CamID = camPars.Runtime.CamID;
			CamCalculated.EntitiesG1.Add(buLineCam2);
			buArcCam buArcCam2 = new buArcCam(new Point3D(pnt3D.X, pnt3D.Y, camPars.Drill.EndHeight), num2 / 2.0, 0.0, Math.PI * 2.0);
			buArcCam2.MoveType = CamMoveType.Other;
			buArcCam2.Color = Color.Red;
			buArcCam2.CamID = camPars.Runtime.CamID;
			CamCalculated.EntitiesOther.Add(buArcCam2);
			pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
			if (j < RefPoints.Count - 1)
			{
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, pnt6D.C), camPars.Speeds.Leave, 1));
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid);
			}
			num = pnt6D.C;
			if (j == RefPoints.Count - 1)
			{
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
			if (camTpPoint2.Points.Count > 0)
			{
				CamCalculated.CamPoints.Add(camTpPoint2);
				camTpPoint2 = new camTpPoint();
			}
		}
	}

	public void camDrillThenRotation(List<Pnt6D> RefPoints, ToolBase5 Tool, WorkPlane Plane, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Point  ";
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Pnt3D pnt3D2 = new Pnt3D();
		double num = 0.0;
		double num2 = Tool.Geometry.Diameter;
		CamCalculated.TypeCam = CamType.Drill;
		if ((Tool.Purpose == ToolPurpose.DiamondCut) | (Tool.Purpose == ToolPurpose.Saw))
		{
			num2 = Tool.Geometry.Thickness;
		}
		camPars.Operations.StepHeights.Add(camPars.Steps.EndValue);
		camPars.Operations.StepHeights.Clear();
		camPars.Operations.StepHeights.Add(camPars.Steps.EndValue);
		double num3 = 1.0;
		for (int i = 0; i <= RefPoints.Count - 1; i++)
		{
			Pnt6D pnt6D = new Pnt6D(RefPoints[i]);
			pnt6D.C += camPars.Strategy.TangentOffset;
			if (camPars.Strategy.UseContantTangent)
			{
				pnt6D.C = camPars.Strategy.ContantTangent;
			}
			if (!camPars.Drill.IncremantalRotation)
			{
				num3 = 1.0;
			}
			if (i > 0)
			{
				double num4 = pnt6D.C - num;
				if (Math.Abs(num4) > 180.0)
				{
					if (!(num4 > 0.0))
					{
						pnt6D.C += 360.0;
					}
					else
					{
						pnt6D.C -= 360.0;
					}
				}
				if (pnt6D.C > camPars.Strategy.MaxTangentValue)
				{
					double num5 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					if (!(num5 >= 360.0))
					{
						pnt6D.C -= camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					}
					else
					{
						pnt6D.C -= 360.0;
					}
				}
				if (pnt6D.C < camPars.Strategy.MinTangentValue)
				{
					double num6 = camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					if (!(num6 >= 360.0))
					{
						pnt6D.C += camPars.Strategy.MaxTangentValue - camPars.Strategy.MinTangentValue;
					}
					else
					{
						pnt6D.C += 360.0;
					}
				}
			}
			if (i != 0)
			{
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, camPars.Drill.StartAngle * num3 + camPars.Drill.EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0);
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			else
			{
				camTpPoint2 = new camTpPoint();
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe), camPars.Speeds.Leave, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, camPars.Drill.StartAngle * num3 + camPars.Drill.EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0);
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, camPars.Drill.StartAngle * num3 + camPars.Drill.EndAngle * (num3 - 1.0)), camPars.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, camPars.Drill.EndHeight);
			tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z, 0.0, 0.0, camPars.Drill.StartAngle * num3 + camPars.Drill.EndAngle * (num3 - 1.0)), camPars.Speeds.Plunge, 1);
			camTpPoint2.Points.Add(tpPnt9D);
			pnt3D = new Pnt3D(pnt6D.X, pnt6D.Y, camPars.Drill.EndHeight);
			tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D.Z, 0.0, 0.0, camPars.Drill.EndAngle * num3), camPars.Speeds.Plunge, 1);
			camTpPoint2.Points.Add(tpPnt9D);
			buLineCam buLineCam2 = new buLineCam(new Point3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z), new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z));
			buLineCam2.MoveType = CamMoveType.G1;
			buLineCam2.Color = Color.Red;
			buLineCam2.CamID = camPars.Runtime.CamID;
			CamCalculated.EntitiesG1.Add(buLineCam2);
			buArcCam buArcCam2 = new buArcCam(new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z), num2 / 2.0, 0.0, Math.PI * 2.0);
			buArcCam2.MoveType = CamMoveType.Other;
			buArcCam2.Color = Color.Red;
			buArcCam2.CamID = camPars.Runtime.CamID;
			CamCalculated.EntitiesOther.Add(buArcCam2);
			pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, pnt3D.Z);
			pnt3D = new Pnt3D(pnt6D);
			tpPnt9D = (camPars.Distances.RapidRetract ? new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D2.Z + camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, camPars.Drill.EndAngle * num3), camPars.Speeds.Rapid, 0) : new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, pnt3D2.Z + camPars.Drill.StartHeight + camPars.Distances.Rapid, 0.0, 0.0, camPars.Drill.EndAngle * num3), camPars.Speeds.Leave, 1));
			camTpPoint2.Points.Add(tpPnt9D);
			pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Drill.StartHeight + camPars.Distances.Rapid);
			num = pnt6D.C;
			if (i == RefPoints.Count - 1)
			{
				pnt3D = new Pnt3D(pnt6D);
				tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe, 0.0, 0.0, pnt6D.C), camPars.Speeds.Rapid, 0);
				tpPnt9D.PlungeAxis = "Z";
				tpPnt9D.PlungeAxisMovement = true;
				camTpPoint2.Points.Add(tpPnt9D);
				pnt3D2 = new Pnt3D(pnt3D.X, pnt3D.Y, camPars.Distances.Safe);
			}
			num3 += 1.0;
		}
		SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
		if (camTpPoint2.Points.Count > 0)
		{
			CamCalculated.CamPoints.Add(camTpPoint2);
			camTpPoint2 = new camTpPoint();
		}
	}

	public void camHatch(camParameters5 CamPars, KinematicBase Kinematic, ToolBase5 Tool, ref camTp calcCam, ref List<eEntities> Entities)
	{
		if (CamPars.Hatch.CutStep <= 0.0 || CamPars.Hatch.XDirectionLength <= 0.0 || CamPars.Hatch.YDirectionWidth <= 0.0)
		{
			return;
		}
		List<List<eEntities>> list = new List<List<eEntities>>();
		Entities.Clear();
		if (CamPars.Hatch.CuttingDirection == CamHatchCuttingDirection.XDirection)
		{
			int num = (int)buNumeric5.RoundToLower(CamPars.Hatch.YDirectionWidth / CamPars.Hatch.CutStep);
			if (num == 0)
			{
				num = 1;
			}
			double num2 = CamPars.Hatch.YDirectionWidth / (double)num;
			double num3 = 0.0;
			Pnt3D pnt3D = new Pnt3D();
			List<eEntities> list2 = new List<eEntities>();
			for (int i = 0; i <= num; i++)
			{
				if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
				{
					num3 = (double)i * num2;
					eEntities item = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + CamPars.Hatch.XDirectionLength, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height));
					Entities.Add(item);
					list2.Add(item);
					list.Add(list2);
				}
				if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
				{
					list2 = new List<eEntities>();
					num3 = (double)i * num2;
					eEntities item2 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + CamPars.Hatch.XDirectionLength, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height));
					Entities.Add(item2);
					list2.Add(item2);
					item2 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + CamPars.Hatch.XDirectionLength, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height));
					Entities.Add(item2);
					list2.Add(item2);
					list.Add(list2);
				}
				if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
				{
					num3 = (double)i * num2;
					eEntities eEntities2 = null;
					if (Entities.Count > 0)
					{
						eEntities2 = new eLine(new Pnt3D(pnt3D), new Pnt3D(pnt3D.X, num3, CamPars.Operations.Height));
						Entities.Add(eEntities2);
						list2.Add(eEntities2);
					}
					if (i % 2 == 0)
					{
						eEntities2 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + CamPars.Hatch.XDirectionLength, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height));
					}
					if (i % 2 == 1)
					{
						eEntities2 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + CamPars.Hatch.XDirectionLength, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X, CamPars.Hatch.CornerPoint.Y + num3, CamPars.Operations.Height));
					}
					Entities.Add(eEntities2);
					list2.Add(eEntities2);
					pnt3D = new Pnt3D(eEntities2.Vertice[eEntities2.Vertice.Count - 1]);
				}
			}
			if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				list.Add(list2);
			}
		}
		if (CamPars.Hatch.CuttingDirection != CamHatchCuttingDirection.YDirection)
		{
			return;
		}
		int num4 = (int)buNumeric5.RoundToLower(CamPars.Hatch.XDirectionLength / CamPars.Hatch.CutStep);
		if (num4 == 0)
		{
			num4 = 1;
		}
		double num5 = CamPars.Hatch.XDirectionLength / (double)num4;
		double num6 = 0.0;
		Pnt3D pnt3D2 = new Pnt3D();
		List<eEntities> list3 = new List<eEntities>();
		for (int j = 0; j <= num4; j++)
		{
			if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.Forward)
			{
				list3 = new List<eEntities>();
				num6 = (double)j * num5;
				eEntities item3 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y + CamPars.Hatch.YDirectionWidth, CamPars.Operations.Height));
				Entities.Add(item3);
				list3.Add(item3);
				list.Add(list3);
			}
			if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardBackward)
			{
				list3 = new List<eEntities>();
				num6 = (double)j * num5;
				eEntities item4 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y + CamPars.Hatch.YDirectionWidth, CamPars.Operations.Height));
				Entities.Add(item4);
				list3.Add(item4);
				item4 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y + CamPars.Hatch.YDirectionWidth, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y, CamPars.Operations.Height));
				Entities.Add(item4);
				list3.Add(item4);
				list.Add(list3);
			}
			if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
			{
				num6 = (double)j * num5;
				eEntities eEntities3 = null;
				if (Entities.Count > 0)
				{
					eEntities3 = new eLine(new Pnt3D(pnt3D2), new Pnt3D(num6, pnt3D2.Y, CamPars.Operations.Height));
					Entities.Add(eEntities3);
					list3.Add(eEntities3);
				}
				if (j % 2 == 0)
				{
					eEntities3 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y + CamPars.Hatch.YDirectionWidth, CamPars.Operations.Height));
				}
				if (j % 2 == 1)
				{
					eEntities3 = new eLine(new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y + CamPars.Hatch.YDirectionWidth, CamPars.Operations.Height), new Pnt3D(CamPars.Hatch.CornerPoint.X + num6, CamPars.Hatch.CornerPoint.Y, CamPars.Operations.Height));
				}
				Entities.Add(eEntities3);
				list3.Add(eEntities3);
				pnt3D2 = new Pnt3D(eEntities3.Vertice[eEntities3.Vertice.Count - 1]);
			}
		}
		if (CamPars.Hatch.CuttingModes == CamHatchCuttingMode.ForwardNextBackward)
		{
			list.Add(list3);
		}
	}

	public bool camQuilting(List<List<Entity>> SplitedRefEntities, bool TangentCalculaton, double HeadDistance, ToolBase5 Tool, camParameters5 camPars, ref camTp CamCalculated)
	{
		CamCalculated.Name = "Contour  ";
		List<List<Entity>> copiedEnt = new List<List<Entity>>();
		camTpPoint camTpPoint2 = new camTpPoint();
		TpPnt9D tpPnt9D = new TpPnt9D();
		Pnt3D pnt3D = new Pnt3D();
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		int num = 0;
		double num2 = 0.0;
		double num3 = 0.0;
		double feed = camPars.Speeds.Feed;
		double plunge = camPars.Speeds.Plunge;
		double leave = camPars.Speeds.Leave;
		double rapid = camPars.Speeds.Rapid;
		CamCalculated.TypeCam = CamType.ContourOpenCenter;
		buVector5.CopyEntities(SplitedRefEntities, ref copiedEnt);
		num3 = (camPars.Steps.Enable ? camPars.Steps.StartValue : camPars.Operations.Height);
		int num4 = -1;
		for (int i = 0; i <= copiedEnt.Count - 1; i++)
		{
			bool flag = false;
			buCall.buVector5_0.isEntitiesClosed(copiedEnt[i]);
			double z = 0.0;
			buLineCam buLineCam2 = null;
			buLinearPathCam buLinearPathCam2 = null;
			List<Point3D> list = new List<Point3D>();
			List<Entity> copiedEnt2 = new List<Entity>();
			buVector5.CopyEntities(copiedEnt[i], ref copiedEnt2);
			double Length = 0.0;
			double num5 = 0.0;
			buCall.buVector5_0.EntitiesLength(copiedEnt2, ref Length);
			if (((CustomData)copiedEnt2[0].EntityData).sortDirection != entitySortDirection.Normal)
			{
				num5 = buConversion5.RadianToDegree(((ICurve)copiedEnt2[0]).EndTangent.AngleInXY);
				num5 += 180.0;
				if (num5 < 0.0)
				{
					num5 += 360.0;
				}
				if (num5 >= 360.0)
				{
					num5 -= 360.0;
				}
			}
			else
			{
				num5 = buConversion5.RadianToDegree(((ICurve)copiedEnt2[0]).StartTangent.AngleInXY);
				if (num5 < 0.0)
				{
					num5 += 360.0;
				}
				if (num5 >= 360.0)
				{
					num5 -= 360.0;
				}
			}
			double num6 = 0.0;
			if (!buCall.buVector5_0.isEntitiesClosed(copiedEnt2))
			{
				if ((camPars.Options.ExtendPatternOutput > 0.0) & (copiedEnt2.Count > 0))
				{
					Entity addedEntity = null;
					buCall.buVector5_0.LineFromEntityEndPoint(copiedEnt2[copiedEnt2.Count - 1], camPars.Options.ExtendPatternOutput, ref addedEntity);
					if (addedEntity != null)
					{
						addedEntity.EntityData = new CustomData((CustomData)copiedEnt2[copiedEnt2.Count - 1].EntityData);
						((CustomData)addedEntity.EntityData).sortDirection = entitySortDirection.Normal;
						copiedEnt2.Add(addedEntity);
					}
				}
			}
			else if ((camPars.Offsets.OverlapDistance > 0.0) & (copiedEnt2.Count > 0))
			{
				Entity addedEntity2 = null;
				buCall.buVector5_0.LineFromEntityEndPoint(copiedEnt2[copiedEnt2.Count - 1], camPars.Offsets.OverlapDistance, ref addedEntity2);
				if (addedEntity2 != null)
				{
					addedEntity2.EntityData = new CustomData((CustomData)copiedEnt2[copiedEnt2.Count - 1].EntityData);
					((CustomData)addedEntity2.EntityData).sortDirection = entitySortDirection.Normal;
					copiedEnt2.Add(addedEntity2);
				}
			}
			for (int j = 0; j <= copiedEnt2.Count - 1; j++)
			{
				Pnt6D pnt6D = new Pnt6D();
				Entity entity = copiedEnt2[j];
				int num7 = 0;
				if (((CustomData)copiedEnt2[j].EntityData).Tags.Length > 0 && buNumeric5.IsNumeric(((CustomData)copiedEnt2[j].EntityData).Tags))
				{
					num7 = Convert.ToInt32(((CustomData)copiedEnt2[j].EntityData).Tags);
				}
				List<Point3D> PointList = new List<Point3D>();
				bool flag2 = false;
				double safe = camPars.Distances.Safe;
				double num8 = 0.0;
				if (j == copiedEnt2.Count - 1)
				{
					if (((CustomData)entity.EntityData).sortDirection == entitySortDirection.Normal)
					{
						num6 = buConversion5.RadianToDegree(((ICurve)entity).EndTangent.AngleInXY);
						num6 += 180.0;
						if (num6 < 0.0)
						{
							num6 += 360.0;
						}
						if (num6 >= 360.0)
						{
							num6 -= 360.0;
						}
					}
					if (((CustomData)entity.EntityData).sortDirection == entitySortDirection.Reverse)
					{
						num6 = buConversion5.RadianToDegree(((ICurve)entity).StartTangent.AngleInXY);
						if (num6 < 0.0)
						{
							num6 += 360.0;
						}
						if (num6 >= 360.0)
						{
							num6 -= 360.0;
						}
					}
				}
				feed = camPars.Speeds.Feed;
				plunge = camPars.Speeds.Plunge;
				leave = camPars.Speeds.Leave;
				rapid = camPars.Speeds.Rapid;
				if (camPars.Options.FeedFromEntityFeedrate && ((CustomData)copiedEnt2[j].EntityData).CamFeedrate > 0.0)
				{
					feed = ((CustomData)copiedEnt2[j].EntityData).CamFeedrate;
					plunge = ((CustomData)copiedEnt2[j].EntityData).CamFeedrate;
					leave = ((CustomData)copiedEnt2[j].EntityData).CamFeedrate;
					rapid = ((CustomData)copiedEnt2[j].EntityData).CamFeedrate;
				}
				if (entity is ICurve)
				{
					buVector5.VerticeToPointsList(entity.Vertices, ref PointList);
					buCall.buVector5_0.SetValueToPointList(0.0, 0.0, z, XEnable: false, YEnable: false, ZEnable: true, ref PointList);
					if (!(entity is Line))
					{
						if (!(entity is Arc))
						{
							if (!(entity is LinearPath))
							{
								if (!(entity is Curve))
								{
									if (!(entity is Ellipse))
									{
										if (entity.GetType() == typeof(EllipticalArc))
										{
											if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
											{
												if (j == 0)
												{
													point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
												}
												PointList.Reverse();
											}
											else if (j == 0)
											{
												point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
											}
										}
									}
									else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
									{
										if (j == 0)
										{
											point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
										}
										PointList.Reverse();
									}
									else if (j == 0)
									{
										point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
									}
								}
								else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
								{
									if (j == 0)
									{
										point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
									}
									PointList.Reverse();
								}
								else if (j == 0)
								{
									point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
								}
							}
							else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								if (j == 0)
								{
									point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
								}
								PointList.Reverse();
							}
							else if (j == 0)
							{
								point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
							}
						}
						else
						{
							flag2 = true;
							if (TangentCalculaton)
							{
								flag2 = false;
							}
							if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
							{
								if (j == 0)
								{
									point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
								}
								PointList.Reverse();
							}
							else if (j == 0)
							{
								point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
							}
						}
					}
					else if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
					{
						if (j == 0)
						{
							point3D = new Point3D(entity.Vertices[entity.Vertices.Length - 1].X, entity.Vertices[entity.Vertices.Length - 1].Y, z);
						}
						PointList.Reverse();
					}
					else if (j == 0)
					{
						point3D = new Point3D(entity.Vertices[0].X, entity.Vertices[0].Y, z);
					}
				}
				if (!(i == 0 && j == 0))
				{
					safe = num3 + camPars.Distances.Rapid;
					if (((i > 0 && j == 0) & (camTpPoint2.Points.Count > 0)) && safe < camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z)
					{
						safe = camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Z;
					}
				}
				else
				{
					safe = camPars.Distances.Safe;
				}
				num8 = buCall.buVector5_0.PointAngle(PointList[1], PointList[0], Plane.XY);
				num8 += camPars.Strategy.TangentOffset;
				if (buCompare5.EQ(num8, 0.0) && num2 > 180.0)
				{
					num8 = 360.0;
				}
				if (num <= 0)
				{
					num2 = num8;
				}
				else
				{
					buCall.buVector5_0.CamTangentCalculation(ref num8, num2, camPars);
				}
				if (flag && (buCompare5.EQ(Math.Abs(num8 - num2), 0.0) | buCompare5.EQ(Math.Abs(num8 - num2), 180.0)))
				{
					num8 = num2;
				}
				if (camPars.Strategy.UseContantTangent)
				{
					num8 = camPars.Strategy.ContantTangent;
					num2 = camPars.Strategy.ContantTangent;
				}
				if (i == 0 && j == 0)
				{
					list.Add(buVector5.ToPoint3D(point3D));
					pnt6D = new Pnt6D(point3D.X, point3D.Y, point3D.Z, 0.0, 0.0, num8);
					pnt3D = new Pnt3D(pnt6D);
					tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), rapid, 0);
					tpPnt9D.PreCodes.Add("M40 K" + HeadDistance.ToString("f2"));
					tpPnt9D.AfterCodes.Add("M50 K" + num7);
					tpPnt9D.AfterCodes.Add("M60");
					tpPnt9D.AfterCodes.Add("M70 K" + num5.ToString("f2"));
					camTpPoint2.Points.Add(tpPnt9D);
					num4 = num7;
				}
				if (j > 0 && TangentCalculaton)
				{
					double value = num8 - num2;
					if ((Math.Abs(value) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit)
					{
						tpPnt9D = new TpPnt9D();
						tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
						tpPnt9D.Type = 1;
						tpPnt9D.Feed = leave;
						tpPnt9D.PlungeAxisMovement = true;
						tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
						camTpPoint2.Points.Add(tpPnt9D);
						buLineCam2 = new buLineCam(new Point3D(point3D2.X, point3D2.Y, point3D2.Z), new Point3D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid));
						buLineCam2.MoveType = CamMoveType.Leave;
						buLineCam2.Color = Color.Blue;
						buLineCam2.CamID = camPars.Runtime.CamID;
						CamCalculated.EntitiesLeave.Add(buLineCam2);
						tpPnt9D = new TpPnt9D();
						tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid, 0.0, 0.0, num8);
						tpPnt9D.Type = 0;
						tpPnt9D.Feed = rapid;
						tpPnt9D.PlungeAxisMovement = false;
						camTpPoint2.Points.Add(tpPnt9D);
						tpPnt9D = new TpPnt9D();
						tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z, 0.0, 0.0, num8);
						tpPnt9D.Type = 1;
						tpPnt9D.Feed = plunge;
						tpPnt9D.PlungeAxisMovement = true;
						tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
						camTpPoint2.Points.Add(tpPnt9D);
						buLineCam2 = new buLineCam(new Point3D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid), new Point3D(point3D2.X, point3D2.Y, point3D2.Z));
						buLineCam2.MoveType = CamMoveType.Plunge;
						buLineCam2.Color = Color.Green;
						buLineCam2.CamID = camPars.Runtime.CamID;
						CamCalculated.EntitiesPlunge.Add(buLineCam2);
					}
				}
				int num9 = 0;
				if (camTpPoint2.Points.Count > 0)
				{
					Pnt3D pnt3D2 = new Pnt3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y);
					if (buCompare5.EQ(pnt3D2.X, PointList[0].X, 0.001) & buCompare5.EQ(pnt3D2.Y, PointList[0].Y, 0.001))
					{
						num9 = 1;
					}
				}
				if (flag2)
				{
					if (camTpPoint2.Points.Count > 0)
					{
						bool flag3 = false;
						Pnt3D pnt3D3 = new Pnt3D(camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.X, camTpPoint2.Points[camTpPoint2.Points.Count - 1].P9.Y);
						if (buCompare5.EQ(pnt3D3.X, ((ICurve)entity).StartPoint.X, 0.001) & buCompare5.EQ(pnt3D3.Y, ((ICurve)entity).StartPoint.Y, 0.001))
						{
							flag3 = true;
						}
						if (buCompare5.EQ(pnt3D3.X, ((ICurve)entity).EndPoint.X, 0.001) & buCompare5.EQ(pnt3D3.Y, ((ICurve)entity).EndPoint.Y, 0.001))
						{
							flag3 = true;
						}
						if (!flag3)
						{
							pnt6D = new Pnt6D(((ICurve)entity).StartPoint.X, ((ICurve)entity).StartPoint.Y, z);
							if (((CustomData)entity.EntityData).sortDirection == entitySortDirection.Reverse)
							{
								pnt6D = new Pnt6D(((ICurve)entity).EndPoint.X, ((ICurve)entity).EndPoint.Y, z);
							}
							pnt3D = new Pnt3D(pnt6D);
							tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), rapid, 0);
							if (num7 != num4)
							{
								tpPnt9D.AfterCodes.Add("M50 K" + num7);
							}
							tpPnt9D.AfterCodes.Add("M60");
							tpPnt9D.AfterCodes.Add("M70 K" + num5.ToString("f2"));
							camTpPoint2.Points.Add(tpPnt9D);
						}
					}
					if (((CustomData)entity.EntityData).sortDirection != entitySortDirection.Normal)
					{
						pnt6D = new Pnt6D(((ICurve)entity).StartPoint.X, ((ICurve)entity).StartPoint.Y, z);
						pnt3D = new Pnt3D(pnt6D);
						if (!(((Arc)entity).Plane.Equation.Z > 0.0))
						{
							tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
							tpPnt9D.ArcType = 3;
						}
						else
						{
							tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
							tpPnt9D.ArcType = 2;
						}
						tpPnt9D.Radius = ((Arc)entity).Radius;
					}
					else
					{
						pnt6D = new Pnt6D(((ICurve)entity).EndPoint.X, ((ICurve)entity).EndPoint.Y, z);
						pnt3D = new Pnt3D(pnt6D);
						if (!(((Arc)entity).Plane.Equation.Z > 0.0))
						{
							tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 2);
							tpPnt9D.ArcType = 2;
						}
						else
						{
							tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, 3);
							tpPnt9D.ArcType = 3;
						}
						tpPnt9D.Radius = ((Arc)entity).Radius;
					}
					if (!(((Arc)entity).Plane.Equation.Z > 0.0))
					{
						tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
						tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
					}
					else
					{
						tpPnt9D.ArcData.StartPoint = new Point3D(((Arc)entity).StartPoint.X, ((Arc)entity).StartPoint.Y, z);
						tpPnt9D.ArcData.EndPoint = new Point3D(((Arc)entity).EndPoint.X, ((Arc)entity).EndPoint.Y, z);
					}
					tpPnt9D.ArcData.CenterPoint = new Point3D(((Arc)entity).Center.X, ((Arc)entity).Center.Y, z);
					tpPnt9D.ArcData.SweepAngle = ((Arc)entity).AngleInDegrees;
					tpPnt9D.ArcData.Radius = ((Arc)entity).Radius;
					tpPnt9D.ArcData.Length = ((Arc)entity).Length();
					tpPnt9D.ArcData.StartAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.StartPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
					tpPnt9D.ArcData.EndAngle = buCall.buVector5_0.PointAngle(tpPnt9D.ArcData.EndPoint, tpPnt9D.ArcData.CenterPoint, Plane.XY);
					if (tpPnt9D.ArcData.StartAngle > tpPnt9D.ArcData.EndAngle)
					{
						tpPnt9D.ArcData.EndAngle += 360.0;
					}
					if (j == 0)
					{
						tpPnt9D.PreCodes.Add("M80 K" + Length.ToString("f2"));
					}
					camTpPoint2.Points.Add(tpPnt9D);
					point3D2 = new Point3D(pnt3D.X, pnt3D.Y, z);
					for (int k = 1; k <= PointList.Count - 1; k++)
					{
						list.Add(new Point3D(PointList[k].X, PointList[k].Y, z));
					}
				}
				else
				{
					for (int l = num9; l <= PointList.Count - 1; l++)
					{
						num8 = ((l == 0) ? buCall.buVector5_0.PointAngle(PointList[l + 1], PointList[l], Plane.XY) : buCall.buVector5_0.PointAngle(PointList[l], PointList[l - 1], Plane.XY));
						num8 += camPars.Strategy.TangentOffset;
						if (buCompare5.EQ(num8, 0.0) && num2 > 180.0)
						{
							num8 = 360.0;
						}
						buCall.buVector5_0.CamTangentCalculation(ref num8, num2, camPars);
						if (flag && (buCompare5.EQ(Math.Abs(num8 - num2), 0.0) | buCompare5.EQ(Math.Abs(num8 - num2), 180.0)))
						{
							num8 = num2;
						}
						if (camPars.Strategy.UseContantTangent)
						{
							num8 = camPars.Strategy.ContantTangent;
						}
						double value2 = num8 - num2;
						if (TangentCalculaton && l > 1 && ((Math.Abs(value2) > camPars.Strategy.AngleLimit) & camPars.Strategy.UseTangentLimit))
						{
							tpPnt9D = new TpPnt9D();
							tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid, 0.0, 0.0, num2);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = leave;
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.PlungeAction = CamPlungeActionType.GoUp;
							camTpPoint2.Points.Add(tpPnt9D);
							buLineCam2 = new buLineCam(new Point3D(point3D2.X, point3D2.Y, point3D2.Z), new Point3D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid));
							buLineCam2.MoveType = CamMoveType.Leave;
							buLineCam2.Color = Color.Blue;
							buLineCam2.CamID = camPars.Runtime.CamID;
							CamCalculated.EntitiesLeave.Add(buLineCam2);
							tpPnt9D = new TpPnt9D();
							tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid, 0.0, 0.0, num8);
							tpPnt9D.Type = 0;
							tpPnt9D.Feed = rapid;
							tpPnt9D.PlungeAxisMovement = false;
							camTpPoint2.Points.Add(tpPnt9D);
							tpPnt9D = new TpPnt9D();
							tpPnt9D.P9 = new Pnt9D(point3D2.X, point3D2.Y, point3D2.Z, 0.0, 0.0, num8);
							tpPnt9D.Type = 1;
							tpPnt9D.Feed = plunge;
							tpPnt9D.PlungeAxisMovement = true;
							tpPnt9D.PlungeAction = CamPlungeActionType.GoDownAproach;
							camTpPoint2.Points.Add(tpPnt9D);
							buLineCam2 = new buLineCam(new Point3D(point3D2.X, point3D2.Y, point3D2.Z + camPars.Distances.Rapid), new Point3D(point3D2.X, point3D2.Y, point3D2.Z));
							buLineCam2.MoveType = CamMoveType.Plunge;
							buLineCam2.Color = Color.Green;
							buLineCam2.CamID = camPars.Runtime.CamID;
							CamCalculated.EntitiesPlunge.Add(buLineCam2);
						}
						int type = 1;
						if (l == 0)
						{
							type = 0;
						}
						pnt6D = new Pnt6D(PointList[l].X, PointList[l].Y, PointList[l].Z, 0.0, 0.0, num8);
						pnt3D = new Pnt3D(pnt6D);
						tpPnt9D = new TpPnt9D(new Pnt6D(pnt3D.X, pnt3D.Y, z, 0.0, 0.0, pnt6D.C), feed, type);
						if (num7 != num4)
						{
							tpPnt9D.AfterCodes.Add("M50 K" + num7);
						}
						if (l == 0)
						{
							tpPnt9D.AfterCodes.Add("M60");
							tpPnt9D.AfterCodes.Add("M70 K" + num5.ToString("f2"));
						}
						if (j == 0 && l == 1)
						{
							tpPnt9D.PreCodes.Add("M80 K" + Length.ToString("f2"));
						}
						camTpPoint2.Points.Add(tpPnt9D);
						point3D2 = new Point3D(pnt3D.X, pnt3D.Y, z);
						list.Add(buVector5.ToPoint3D(point3D2));
						num2 = num8;
					}
				}
				if (j == copiedEnt2.Count - 1 && camTpPoint2.Points.Count > 0)
				{
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M71 K" + num6.ToString("f2"));
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("M61");
				}
				flag = false;
				num4 = num7;
				num2 = num8;
				num++;
			}
			buLinearPathCam2 = new buLinearPathCam(list);
			buLinearPathCam2.MoveType = CamMoveType.G1;
			buLinearPathCam2.Color = Color.Red;
			buLinearPathCam2.CamID = camPars.Runtime.CamID;
			CamCalculated.EntitiesG1.Add(buLinearPathCam2);
		}
		SimPointCreatForDetailedPoints(camTpPoint2.Points, 0.25, 0.1, 3.0, 30.0, ref CamCalculated.SimilationPoint);
		if (camTpPoint2.Points.Count > 0)
		{
			CamCalculated.Tool = new ToolBase5(Tool);
			CamCalculated.CamPoints.Add(camTpPoint2);
			camTpPoint2 = new camTpPoint();
		}
		return true;
	}

	public void SimPointCreatForDetailedPoints(List<TpPnt9D> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, double CircularFilterLen, ref SimulationTp simulation)
	{
		SimPointCreatForDetailedPoints(Points, G0DevideRatio, G1DevideRatio, PointFilterLength, CircularFilterLen, new Pnt9D(), ref simulation);
	}

	public void SimPointCreatForDetailedPoints(List<TpPnt9D> Points, double G0DevideRatio, double G1DevideRatio, double PointFilterLength, double CircularFilterLen, Pnt9D Offsets, ref SimulationTp simulation)
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
			Pnt6DSimMove item = new Pnt6DSimMove(Points[num - 1].P9.X + Offsets.X, Points[num - 1].P9.Y + Offsets.Y, Points[num - 1].P9.Z + Offsets.Z, Points[num - 1].P9.A + Offsets.A, Points[num - 1].P9.B + Offsets.B, Points[num - 1].P9.C + Offsets.C, Points[num - 1].Feed, Points[num - 1].ToolNo, Points[num - 1].SpindleSpeed, new Pnt3D(), -1, Points[num - 1].ToolName);
			simulation.SimMove.Add(item);
		}
		for (int i = num; i <= Points.Count - 1; i++)
		{
			List<Pnt6DSimMove> Vertices = new List<Pnt6DSimMove>();
			if (Points[i].Type != 0)
			{
			}
			if ((Points[i].Type == 0) | (Points[i].Type == 1))
			{
				double num2 = 0.0;
				double num3 = buCall.buVector5_0.Length3D(new Pnt3D(Points[i - 1].P9.X, Points[i - 1].P9.Y, Points[i - 1].P9.Z), new Pnt3D(Points[i].P9.X, Points[i].P9.Y, Points[i].P9.Z));
				if (num3 == 0.0)
				{
					num3 = buCall.buVector5_0.Length6D(new Pnt6D(Points[i - 1].P9.X, Points[i - 1].P9.Y, Points[i - 1].P9.Z, Points[i - 1].P9.A, Points[i - 1].P9.B, Points[i - 1].P9.C), new Pnt6D(Points[i].P9.X, Points[i].P9.Y, Points[i].P9.Z, Points[i].P9.A, Points[i].P9.B, Points[i].P9.C));
					num2 = num3;
				}
				double num4 = PointFilterLength;
				if (Points[i].SimDevideLen > 0.0)
				{
					num4 = Points[i].SimDevideLen;
				}
				if (!(num3 > num4))
				{
					Pnt6DSimMove item2 = new Pnt6DSimMove(Points[i].P9.X + Offsets.X, Points[i].P9.Y + Offsets.Y, Points[i].P9.Z + Offsets.Z, Points[i].P9.A + Offsets.A, Points[i].P9.B + Offsets.B, Points[i].P9.C + Offsets.C, Points[i].Feed, Points[i].ToolNo, Points[i].SpindleSpeed, new Pnt3D());
					simulation.SimMove.Add(item2);
				}
				else
				{
					Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(Points[i - 1].P9.X, Points[i - 1].P9.Y, Points[i - 1].P9.Z, Points[i - 1].P9.A, Points[i - 1].P9.B, Points[i - 1].P9.C);
					pnt6DSimMove.FeedRate = Points[i - 1].Feed;
					pnt6DSimMove.SpindleRpm = Points[i - 1].SpindleSpeed;
					pnt6DSimMove.ToolNo = Points[i - 1].ToolNo;
					Pnt6DSimMove pnt6DSimMove2 = new Pnt6DSimMove(Points[i].P9.X, Points[i].P9.Y, Points[i].P9.Z, Points[i].P9.A, Points[i].P9.B, Points[i].P9.C);
					pnt6DSimMove2.FeedRate = Points[i].Feed;
					pnt6DSimMove2.SpindleRpm = Points[i].SpindleSpeed;
					pnt6DSimMove2.ToolNo = Points[i].ToolNo;
					if (num2 > 0.0 && CircularFilterLen > 0.0)
					{
						num4 = CircularFilterLen;
					}
					buCall.buVector5_0.LineToLineer(pnt6DSimMove, pnt6DSimMove2, num4, ref Vertices);
					Vertices.RemoveAt(0);
					for (int j = 0; j <= Vertices.Count - 1; j++)
					{
						Pnt6DSimMove item3 = new Pnt6DSimMove(Vertices[j].X + Offsets.X, Vertices[j].Y + Offsets.Y, Vertices[j].Z + Offsets.Z, Vertices[j].A + Offsets.A, Vertices[j].B + Offsets.B, Vertices[j].C + Offsets.C, Vertices[j].FeedRate, Vertices[j].ToolNo, Vertices[j].SpindleRpm, new Pnt3D());
						simulation.SimMove.Add(item3);
					}
				}
			}
			if (!((Points[i].Type == 2) | (Points[i].Type == 3)))
			{
				continue;
			}
			List<Pnt3D> Vertices2 = new List<Pnt3D>();
			if (Points[i].ArcData == null)
			{
				continue;
			}
			double num5 = PointFilterLength;
			if (Points[i].SimDevideLen > 0.0)
			{
				num5 = Points[i].SimDevideLen;
			}
			if (num5 > Points[i].ArcData.Length / 2.0)
			{
				num5 = Points[i].ArcData.Length / 2.0;
			}
			if (Points[i].ArcData.isCW)
			{
				buCall.buVector5_0.ArcToLineer(buConversion5.Point3DToPnt3D(Points[i].ArcData.CenterPoint), Points[i].ArcData.Radius, Points[i].ArcData.EndAngle, Points[i].ArcData.StartAngle, num5, new WorkPlane(), ref Vertices2);
				Vertices2.Reverse();
			}
			else
			{
				buCall.buVector5_0.ArcToLineer(buConversion5.Point3DToPnt3D(Points[i].ArcData.CenterPoint), Points[i].ArcData.Radius, Points[i].ArcData.StartAngle, Points[i].ArcData.EndAngle, num5, new WorkPlane(), ref Vertices2);
			}
			if (Points[i].Type == 2)
			{
				Vertices2.Reverse();
			}
			if (Vertices2.Count > 0)
			{
				for (int k = 1; k <= Vertices2.Count - 1; k++)
				{
					Pnt6DSimMove item4 = new Pnt6DSimMove(Vertices2[k].X + Offsets.X, Vertices2[k].Y + Offsets.Y, Vertices2[k].Z + Offsets.Z, Offsets.A, Offsets.B, Offsets.C, Points[i].Feed, Points[i].ToolNo, Points[i].SpindleSpeed, new Pnt3D());
					simulation.SimMove.Add(item4);
				}
			}
		}
	}

	public void CamStepCalculation(camStep5 Steps, ref List<double> CalcValues)
	{
		try
		{
			CalcValues.Clear();
			if (!Steps.Enable)
			{
				return;
			}
			if ((Steps.StepType == CamStepType.StartByCountAndStep) & (Steps.Step != 0.0) & (Steps.Count > 0))
			{
				for (int i = 1; i <= Steps.Count; i++)
				{
					double value = Steps.StartValue + Steps.Step * (double)i;
					CalcValues.Add(Math.Round(value, 5));
				}
			}
			if ((Steps.StepType == CamStepType.StartToEndByStep) & (Steps.Step != 0.0))
			{
				double value2 = Steps.EndValue - Steps.StartValue;
				double num = 1.0;
				if (Steps.EndValue < Steps.StartValue)
				{
					num = -1.0;
				}
				int num2 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(value2) / Math.Abs(Steps.Step)));
				double step = Steps.Step;
				if (step != 0.0)
				{
					double value3 = 0.0;
					for (int j = 1; j <= num2; j++)
					{
						double num3 = Steps.StartValue + num * Math.Abs(step) * (double)j;
						CalcValues.Add(Math.Round(num3, 5));
						value3 = num3;
					}
					if (CalcValues.Count > 0 && !buCompare.EQ(value3, Steps.EndValue, 0.001))
					{
						CalcValues.Add(Steps.EndValue);
					}
				}
			}
			if ((Steps.StepType == CamStepType.StartToEndByCount) & (Steps.Count > 0))
			{
				double value4 = Steps.EndValue - Steps.StartValue;
				double num4 = 1.0;
				if (Steps.EndValue < Steps.StartValue)
				{
					num4 = -1.0;
				}
				double num5 = Convert.ToDouble(Math.Abs(value4) / (double)Steps.Count);
				if (num5 != 0.0)
				{
					for (int k = 1; k <= Steps.Count; k++)
					{
						double item = Steps.StartValue + num4 * Math.Abs(num5) * (double)k;
						CalcValues.Add(item);
					}
				}
			}
			if ((Steps.StepType == CamStepType.StartToDistanceByCount) & (Steps.Count > 0))
			{
				double num6 = Steps.StartValue + Steps.Distance;
				double value5 = num6 - Steps.StartValue;
				double num7 = 1.0;
				if (num6 < Steps.StartValue)
				{
					num7 = -1.0;
				}
				double num8 = Convert.ToDouble(Math.Abs(value5) / (double)Steps.Count);
				if (num8 != 0.0)
				{
					for (int l = 1; l <= Steps.Count; l++)
					{
						double item2 = Steps.StartValue + num7 * Math.Abs(num8) * (double)l;
						CalcValues.Add(item2);
					}
				}
			}
			if ((Steps.StepType == CamStepType.StartToDistanceByStep) & (Steps.Step != 0.0))
			{
				double num9 = Steps.StartValue + Steps.Distance;
				double value6 = num9 - Steps.StartValue;
				double num10 = 1.0;
				if (num9 < Steps.StartValue)
				{
					num10 = -1.0;
				}
				int num11 = Convert.ToInt32(buNumeric.RoundToUpper(Math.Abs(value6) / Steps.Step));
				double num12 = Math.Abs(value6) / (double)num11;
				if (num12 != 0.0)
				{
					for (int m = 1; m <= num11; m++)
					{
						double value7 = Steps.StartValue + num10 * Math.Abs(num12) * (double)m;
						CalcValues.Add(Math.Round(value7, 5));
					}
				}
			}
			if (!((Steps.StepType == CamStepType.StartToDistanceByTrueStep) & (Steps.Step != 0.0)))
			{
				return;
			}
			double num13 = Steps.StartValue + Steps.Distance;
			double value8 = num13 - Steps.StartValue;
			double num14 = 1.0;
			if (num13 < Steps.StartValue)
			{
				num14 = -1.0;
			}
			int num15 = Convert.ToInt32(buNumeric.RoundToLower(Math.Abs(value8) / Steps.Step));
			double step2 = Steps.Step;
			if (step2 != 0.0)
			{
				double value9 = 0.0;
				for (int n = 1; n <= num15; n++)
				{
					double num16 = Steps.StartValue + num14 * Math.Abs(step2) * (double)n;
					CalcValues.Add(Math.Round(num16, 5));
					value9 = num16;
				}
				if (!buCompare.EQ(value9, num13, 0.01))
				{
					CalcValues.Add(Math.Round(num13, 5));
				}
			}
		}
		catch (Exception mSException)
		{
			string text = "Steps : " + Steps.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void GetLastPointOfCam(camTp Cam, ref TpPnt9D LastP9)
	{
		LastP9 = new TpPnt9D();
		if (Cam != null && Cam.CamPoints.Count > 0 && Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count > 0)
		{
			LastP9 = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].Points[Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count - 1]);
		}
	}

	public void GetLastPointOfCam(camTp Cam, int CamPointIndex, ref TpPnt9D LastP9)
	{
		LastP9 = new TpPnt9D();
		if (Cam != null && CamPointIndex >= 0 && ((Cam.CamPoints.Count > 0) & (CamPointIndex <= Cam.CamPoints.Count - 1)) && Cam.CamPoints[CamPointIndex].Points.Count > 0)
		{
			LastP9 = new TpPnt9D(Cam.CamPoints[CamPointIndex].Points[Cam.CamPoints[CamPointIndex].Points.Count - 1]);
		}
	}

	public void GetFirstPointOfCam(camTp Cam, ref TpPnt9D FirstP9)
	{
		FirstP9 = new TpPnt9D();
		if (Cam != null && Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
		{
			FirstP9 = new TpPnt9D(Cam.CamPoints[0].Points[0]);
		}
	}

	public void GetFirstPointOfCam(camTp Cam, int CamPointIndex, ref TpPnt9D FirstP9)
	{
		FirstP9 = new TpPnt9D();
		if (Cam != null && CamPointIndex >= 0 && ((Cam.CamPoints.Count > 0) & (CamPointIndex <= Cam.CamPoints.Count - 1)) && Cam.CamPoints[CamPointIndex].Points.Count > 0)
		{
			FirstP9 = new TpPnt9D(Cam.CamPoints[CamPointIndex].Points[0]);
		}
	}

	public string CamTypeToString(camTp Cam, bool Tool = true, bool Explanation = true)
	{
		string text = "";
		if (Cam != null)
		{
			if (!(Cam.Explanation.Trim().Length > 0 && Explanation))
			{
				if (!((Cam.TypeCam == CamType.ContourClosedCenter) | (Cam.TypeCam == CamType.ContourClosedInside) | (Cam.TypeCam == CamType.ContourClosedOutside)))
				{
					if (!((Cam.TypeCam == CamType.ContourOpenCenter) | (Cam.TypeCam == CamType.ContourOpenLeft) | (Cam.TypeCam == CamType.ContourOpenRight)))
					{
						if (!((Cam.TypeCam == CamType.PocketCircular) | (Cam.TypeCam == CamType.PocketFlat)))
						{
							if (Cam.TypeCam != CamType.Face)
							{
								if (Cam.TypeCam != CamType.Face)
								{
									if (Cam.TypeCam != CamType.Chamfer)
									{
										if (Cam.TypeCam != CamType.Engrave)
										{
											if (Cam.TypeCam != CamType.TextEngrave)
											{
												if (Cam.TypeCam != CamType.Face)
												{
													if (Cam.TypeCam != CamType.Trochoidal)
													{
														if (Cam.TypeCam != CamType.Rough)
														{
															if (Cam.TypeCam != CamType.ParallelCut)
															{
																if (Cam.TypeCam != CamType.ConstantZ)
																{
																	if (Cam.TypeCam != CamType.Flatlands)
																	{
																		if (Cam.TypeCam != CamType.Pencil)
																		{
																			if (!((Cam.TypeCam == CamType.Drill) | (Cam.TypeCam == CamType.Drill4X)))
																			{
																				return buLangTranslate.preDef.UnknownCam;
																			}
																			text = text + buLangTranslate.preDef.Drill + " " + buLangTranslate.preDef.Cam;
																			text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
																			if (Tool)
																			{
																				text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
																			}
																			return text;
																		}
																		text = text + buLangTranslate.preDef.Pencil + " " + buLangTranslate.preDef.Cam;
																		text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
																		if (Tool)
																		{
																			text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
																		}
																		return text;
																	}
																	text = text + buLangTranslate.preDef.Flatlands + " " + buLangTranslate.preDef.Cam;
																	text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
																	if (Tool)
																	{
																		text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
																	}
																	return text;
																}
																text = text + buLangTranslate.preDef.ConstantZ + " " + buLangTranslate.preDef.Cam;
																text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
																if (Tool)
																{
																	text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
																}
																return text;
															}
															text = text + buLangTranslate.preDef.ParalelCuts + " " + buLangTranslate.preDef.Cam;
															text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
															if (Tool)
															{
																text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
															}
															return text;
														}
														text = text + buLangTranslate.preDef.Rough + " " + buLangTranslate.preDef.Cam;
														text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
														if (Tool)
														{
															text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
														}
														return text;
													}
													text = text + buLangTranslate.preDef.Trochoidal + " " + buLangTranslate.preDef.Cam;
													text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
													if (Tool)
													{
														text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
													}
													return text;
												}
												text = text + buLangTranslate.preDef.Face + " " + buLangTranslate.preDef.Cam;
												text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
												if (Tool)
												{
													text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
												}
												return text;
											}
											text = text + buLangTranslate.preDef.TextEngrave + " " + buLangTranslate.preDef.Cam;
											text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
											if (Tool)
											{
												text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
											}
											return text;
										}
										text = text + buLangTranslate.preDef.Engrave + " " + buLangTranslate.preDef.Cam;
										text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
										if (Tool)
										{
											text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
										}
										return text;
									}
									text = text + buLangTranslate.preDef.Chamfer + " " + buLangTranslate.preDef.Cam;
									text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
									if (Tool)
									{
										text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
									}
									return text;
								}
								text = text + buLangTranslate.preDef.FloorFinish + " " + buLangTranslate.preDef.Cam;
								text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
								if (Tool)
								{
									text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
								}
								return text;
							}
							text = text + buLangTranslate.preDef.Face + " " + buLangTranslate.preDef.Cam;
							text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
							if (Tool)
							{
								text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
							}
							return text;
						}
						text = text + buLangTranslate.preDef.Pocket + " " + buLangTranslate.preDef.Cam;
						text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
						if (Tool)
						{
							text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
						}
						return text;
					}
					text = text + buLangTranslate.preDef.Contour + buLangTranslate.preDef.Open;
					if (Cam.TypeCam == CamType.ContourOpenCenter)
					{
						text = text + " " + buLangTranslate.preDef.Center;
					}
					if (Cam.TypeCam == CamType.ContourOpenLeft)
					{
						text = text + " " + buLangTranslate.preDef.Left;
					}
					if (Cam.TypeCam == CamType.ContourOpenRight)
					{
						text = text + " " + buLangTranslate.preDef.Right;
					}
					text = text + " " + buLangTranslate.preDef.Cam;
					text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
					if (Tool)
					{
						text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
					}
					return text;
				}
				text = text + buLangTranslate.preDef.Contour + buLangTranslate.preDef.Closed;
				if (Cam.TypeCam == CamType.ContourClosedCenter)
				{
					text = text + " " + buLangTranslate.preDef.Center;
				}
				if (Cam.TypeCam == CamType.ContourClosedInside)
				{
					text = text + " " + buLangTranslate.preDef.Inside;
				}
				if (Cam.TypeCam == CamType.ContourClosedOutside)
				{
					text = text + " " + buLangTranslate.preDef.Outside;
				}
				text = text + " " + buLangTranslate.preDef.Cam;
				text = text + " - " + Cam.NumberOfAxis + buLangTranslate.preDef.Axes;
				if (Tool)
				{
					text = text + " - " + buLangTranslate.preDef.Tool + ": " + Cam.Tool.Geometry.GeometryType;
				}
				return text;
			}
			return Cam.Explanation;
		}
		return buLangTranslate.preDef.NoCamDefined;
	}

	public string CamWireframeTypeToString(CamWireFrameType Cam)
	{
		string text = "";
		return Cam switch
		{
			CamWireFrameType.CenterPath => buLangTranslate.preDef.CenterPath, 
			CamWireFrameType.Chamfer2D => buLangTranslate.preDef.Chamfer, 
			CamWireFrameType.Contour => buLangTranslate.preDef.Contour, 
			CamWireFrameType.Engrave => buLangTranslate.preDef.Engraving, 
			CamWireFrameType.Face => buLangTranslate.preDef.Face, 
			CamWireFrameType.FloorFinish => buLangTranslate.preDef.FloorFinish, 
			CamWireFrameType.None => buLangTranslate.preDef.None, 
			CamWireFrameType.Pocket => buLangTranslate.preDef.Pocket, 
			CamWireFrameType.Profile3Axis => buLangTranslate.preDef.Profile + " 3 " + buLangTranslate.preDef.Axis, 
			CamWireFrameType.Profile5Axis => buLangTranslate.preDef.Profile + " 5 " + buLangTranslate.preDef.Axis, 
			CamWireFrameType.TextEngrave => buLangTranslate.preDef.TextEngrave, 
			CamWireFrameType.Trochoidal => buLangTranslate.preDef.Trochoidal, 
			_ => buLangTranslate.preDef.UnknownCam, 
		};
	}

	public string CamTriangleMestTypeToString(CamTriangularMeshType Cam)
	{
		string text = "";
		return Cam switch
		{
			CamTriangularMeshType.ConstantCusp => buLangTranslate.preDef.ConstantCusp, 
			CamTriangularMeshType.ConstantZ => buLangTranslate.preDef.ConstantZ, 
			CamTriangularMeshType.ConstantZPlusConstantCusp => buLangTranslate.preDef.ConstantZ + " + " + buLangTranslate.preDef.ConstantCusp, 
			CamTriangularMeshType.ConstantZPlusParallelCuts => buLangTranslate.preDef.ConstantZ + " + " + buLangTranslate.preDef.ParalelCuts, 
			CamTriangularMeshType.Flatlands => buLangTranslate.preDef.Flatlands, 
			CamTriangularMeshType.Geodesic => buLangTranslate.preDef.Geodesic, 
			CamTriangularMeshType.None => buLangTranslate.preDef.None, 
			CamTriangularMeshType.ParallelCuts => buLangTranslate.preDef.ParalelCuts, 
			CamTriangularMeshType.Pencil => buLangTranslate.preDef.Pencil, 
			CamTriangularMeshType.ProjectCurves => buLangTranslate.preDef.ProjectCurves, 
			CamTriangularMeshType.Projection => buLangTranslate.preDef.Projection, 
			CamTriangularMeshType.Rotary => buLangTranslate.preDef.Rotary, 
			CamTriangularMeshType.RotaryFinish => buLangTranslate.preDef.RotaryFinish, 
			CamTriangularMeshType.RotaryRough => buLangTranslate.preDef.RotaryRough, 
			CamTriangularMeshType.Rough => buLangTranslate.preDef.Rough, 
			CamTriangularMeshType.Trochoidal => buLangTranslate.preDef.Trochoidal, 
			_ => buLangTranslate.preDef.UnknownCam, 
		};
	}

	public void ChangeCamPointCoordinates(ref List<camTpPoint> CamPoints, CamPointChangeMethod ChangeType)
	{
		if (ChangeType == CamPointChangeMethod.XYZToXZY)
		{
			for (int i = 0; i <= CamPoints.Count - 1; i++)
			{
				for (int j = 0; j <= CamPoints[i].Points.Count - 1; j++)
				{
					TpPnt9D tpPnt9D = CamPoints[i].Points[j];
					buNumeric5.ExchangeTwoVaues(ref tpPnt9D.P9.Y, ref tpPnt9D.P9.Z);
					if (tpPnt9D.PlungeAxisMovement)
					{
						tpPnt9D.PlungeAxis = "Y";
					}
					if (tpPnt9D.LeaveAxisMovement)
					{
						tpPnt9D.LeaveAxis = "Y";
					}
				}
			}
		}
		if (ChangeType != CamPointChangeMethod.XZYToXYZ)
		{
			return;
		}
		for (int k = 0; k <= CamPoints.Count - 1; k++)
		{
			for (int l = 0; l <= CamPoints[k].Points.Count - 1; l++)
			{
				TpPnt9D tpPnt9D2 = CamPoints[k].Points[l];
				buNumeric5.ExchangeTwoVaues(ref tpPnt9D2.P9.Z, ref tpPnt9D2.P9.Y);
				if (tpPnt9D2.PlungeAxisMovement)
				{
					tpPnt9D2.PlungeAxis = "Z";
				}
				if (tpPnt9D2.LeaveAxisMovement)
				{
					tpPnt9D2.LeaveAxis = "Z";
				}
			}
		}
	}

	public CamType CamWireframeTypeToCamType(CamWireFrameType WireType)
	{
		return WireType switch
		{
			CamWireFrameType.CenterPath => CamType.Contour, 
			CamWireFrameType.Chamfer2D => CamType.Chamfer, 
			CamWireFrameType.Contour => CamType.Contour, 
			CamWireFrameType.Engrave => CamType.Engrave, 
			CamWireFrameType.Face => CamType.Face, 
			CamWireFrameType.FloorFinish => CamType.FloorFinishing, 
			CamWireFrameType.None => CamType.None, 
			CamWireFrameType.Pocket => CamType.PocketCircular, 
			CamWireFrameType.Profile3Axis => CamType.Contour, 
			CamWireFrameType.Profile5Axis => CamType.Contour, 
			CamWireFrameType.TextEngrave => CamType.TextEngrave, 
			CamWireFrameType.Trochoidal => CamType.Trochoidal, 
			_ => CamType.None, 
		};
	}

	public CamType CamTriangularMeshTypeToCamType(CamTriangularMeshType MeshType)
	{
		return MeshType switch
		{
			CamTriangularMeshType.ConstantCusp => CamType.ConstantCusp, 
			CamTriangularMeshType.ConstantZ => CamType.ConstantZ, 
			CamTriangularMeshType.ConstantZPlusConstantCusp => CamType.ConstantZPlusConstantCusp, 
			CamTriangularMeshType.ConstantZPlusParallelCuts => CamType.ConstantZPlusParallelCuts, 
			CamTriangularMeshType.Flatlands => CamType.Flatlands, 
			CamTriangularMeshType.Geodesic => CamType.Geodesic, 
			CamTriangularMeshType.None => CamType.None, 
			CamTriangularMeshType.ParallelCuts => CamType.ParallelCut, 
			CamTriangularMeshType.Pencil => CamType.Pencil, 
			CamTriangularMeshType.ProjectCurves => CamType.ProjectCurves, 
			CamTriangularMeshType.Projection => CamType.Projection, 
			CamTriangularMeshType.Rotary => CamType.Rotary, 
			CamTriangularMeshType.RotaryFinish => CamType.RotaryFinish, 
			CamTriangularMeshType.RotaryRough => CamType.RotaryRough, 
			CamTriangularMeshType.Rough => CamType.Rough, 
			CamTriangularMeshType.Trochoidal => CamType.Trochoidal, 
			_ => CamType.None, 
		};
	}

	public void MoveCam(double dX, double dY, double dZ, ref camTp Cam)
	{
		if (Cam != null && Cam.CamPoints != null)
		{
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesG0);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesG1);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesG1Orj);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesLeadIn);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesLeadOut);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesLeave);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesMark);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesOther);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.EntitiesPlunge);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.RefEntities);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.sortedEntities);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.splitedEntities);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.PrePoints);
			buCall.buVector5_0.Move(dX, dY, dZ, ref Cam.AfterPoints);
			for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
			{
				camTpPoint camTpPoint2 = Cam.CamPoints[i];
				buCall.buVector5_0.Move(dX, dY, dZ, ref camTpPoint2.Points);
				buCall.buVector5_0.Move(dX, dY, dZ, ref camTpPoint2.PrePoints);
				buCall.buVector5_0.Move(dX, dY, dZ, ref camTpPoint2.AfterPoints);
			}
		}
	}

	public bool isCamPointsAvailable(List<camTp> Cams)
	{
		if (Cams.Count <= 0)
		{
			return false;
		}
		return isCamPointsAvailable(Cams[0]);
	}

	public bool isCamPointsAvailable(camTp Cam)
	{
		if (Cam == null)
		{
			return false;
		}
		if (Cam.CamPoints == null || Cam.CamPoints.Count <= 0)
		{
			return false;
		}
		if (Cam.CamPoints[0].Points.Count <= 0)
		{
			return false;
		}
		return true;
	}

	public void GetLastNLineCodeFromString(string Line, ref double NLine)
	{
		NLine = -1.0;
		string text = "";
		for (int num = Line.Length - 2; num >= 0; num--)
		{
			if (Line.Substring(num, 1).ToLower() == "n")
			{
				text = Line.Substring(num, Line.Length - num);
				num = 0;
			}
		}
		if (text.Length > 0)
		{
			text = text.Replace("\n", "");
			buString5.ReadCharValue(text, "N", ref NLine);
		}
	}

	public void GetGCodeExecutionResult(MachineGCodeConfigrasyon Configration, string GCodes, ref MachineGCodeExecutionResult Result)
	{
		List<string> Lines = new List<string>();
		buString5.StringToListByNewLine(GCodes, ref Lines);
		GetGCodeExecutionResult(Configration, Lines, ref Result);
	}

	public void GetGCodeExecutionResult(MachineGCodeConfigrasyon Configration, List<string> GCodes, ref MachineGCodeExecutionResult Result)
	{
		Result = new MachineGCodeExecutionResult();
		Pnt6D foundPoint = new Pnt6D();
		Pnt6D copyPoint = null;
		int num = -1;
		double foundFeed = 0.0;
		double Value = 0.0;
		bool flag = false;
		bool flag2 = false;
		MachineAxisInfo aX_X = null;
		MachineAxisInfo aX_Y = null;
		MachineAxisInfo aX_Z = null;
		MachineAxisInfo aX_A = null;
		MachineAxisInfo aX_B = null;
		MachineAxisInfo aX_C = null;
		MachineGCodeConfigrasyon machineGCodeConfigrasyon = new MachineGCodeConfigrasyon(Configration);
		if (Configration.SpeedType == SpeedUnit.meterPerMin)
		{
			for (int i = 0; i <= machineGCodeConfigrasyon.AxesList.Count - 1; i++)
			{
				machineGCodeConfigrasyon.AxesList[i].MaxSpeed = Math.Round(Configration.AxesList[i].MaxSpeed * 1000.0 / 60.0, 5);
				machineGCodeConfigrasyon.AxesList[i].Acceleration = Math.Round(Configration.AxesList[i].Acceleration / 3600.0 * 1000.0, 5);
				machineGCodeConfigrasyon.AxesList[i].Deceleration = Math.Round(Configration.AxesList[i].Deceleration / 3600.0 * 1000.0, 5);
				machineGCodeConfigrasyon.AxesList[i].Jerk = Math.Round(Configration.AxesList[i].Jerk / 216000.0 * 1000.0, 5);
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "x")
				{
					aX_X = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "y")
				{
					aX_Y = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "z")
				{
					aX_Z = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "a")
				{
					aX_A = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "b")
				{
					aX_B = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
				if (machineGCodeConfigrasyon.AxesList[i].AxisName.ToLower().Trim() == "c")
				{
					aX_C = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[i]);
				}
			}
		}
		if (Configration.SpeedType == SpeedUnit.mmPerMin)
		{
			for (int j = 0; j <= machineGCodeConfigrasyon.AxesList.Count - 1; j++)
			{
				machineGCodeConfigrasyon.AxesList[j].MaxSpeed = Math.Round(Configration.AxesList[j].MaxSpeed * 1.0 / 60.0, 5);
				machineGCodeConfigrasyon.AxesList[j].Acceleration = Math.Round(Configration.AxesList[j].Acceleration / 3600.0 * 1.0, 5);
				machineGCodeConfigrasyon.AxesList[j].Deceleration = Math.Round(Configration.AxesList[j].Deceleration / 3600.0 * 1.0, 5);
				machineGCodeConfigrasyon.AxesList[j].Jerk = Math.Round(Configration.AxesList[j].Jerk / 216000.0 * 1.0, 5);
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "x")
				{
					aX_X = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "y")
				{
					aX_Y = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "z")
				{
					aX_Z = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "a")
				{
					aX_A = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "b")
				{
					aX_B = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
				if (machineGCodeConfigrasyon.AxesList[j].AxisName.ToLower().Trim() == "c")
				{
					aX_C = new MachineAxisInfo(machineGCodeConfigrasyon.AxesList[j]);
				}
			}
		}
		for (int k = 0; k <= GCodes.Count - 1; k++)
		{
			string text = GCodes[k].ToLower().Trim();
			flag2 = false;
			if (text.IndexOf("m") < 0)
			{
				if (text.IndexOf("g") < 0)
				{
					if (num >= 0)
					{
						GetCoordinatesFromLine(text, ref foundPoint, ref foundFeed);
						if (!buCompare5.EQ(foundPoint, copyPoint))
						{
							CalculateGCodeTimeAndLength(copyPoint, foundPoint, num, foundFeed, Value, flag2, aX_X, aX_Y, aX_Z, aX_A, aX_B, aX_C, ref Result);
						}
					}
				}
				else
				{
					bool flag3 = false;
					if (text.IndexOf("g0 ") < 0)
					{
						if (text.IndexOf("g1 ") < 0)
						{
							if (text.IndexOf("g2 ") < 0)
							{
								if (text.IndexOf("g3 ") < 0)
								{
									if (text.IndexOf("g4 ") < 0)
									{
										num = -1;
										Value = 0.0;
									}
									else
									{
										num = 4;
										Value = 0.0;
									}
								}
								else
								{
									buString5.ReadCharValue(text, "r", ref Value);
									flag3 = true;
									flag2 = true;
									num = 3;
								}
							}
							else
							{
								buString5.ReadCharValue(text, "r", ref Value);
								flag3 = true;
								flag2 = true;
								num = 2;
							}
						}
						else
						{
							flag3 = true;
							num = 1;
							Value = 0.0;
						}
					}
					else
					{
						flag3 = true;
						flag2 = false;
						num = 0;
						Value = 0.0;
					}
					if (flag3)
					{
						flag = true;
						GetCoordinatesFromLine(text, ref foundPoint, ref foundFeed);
						if (copyPoint != null && !buCompare5.EQ(foundPoint, copyPoint))
						{
							CalculateGCodeTimeAndLength(copyPoint, foundPoint, num, foundFeed, Value, flag2, aX_X, aX_Y, aX_Z, aX_A, aX_B, aX_C, ref Result);
						}
					}
				}
			}
			else
			{
				num = -1;
				Value = 0.0;
				bool flag4 = false;
				double Value2 = 0.0;
				buString5.ReadCharValue(text, "m", ref Value2);
				string text2 = "m" + Value2;
				for (int l = 0; l <= machineGCodeConfigrasyon.MCodeList.Count - 1; l++)
				{
					string text3 = machineGCodeConfigrasyon.MCodeList[l].MCode.ToLower().Trim();
					if ((text.IndexOf(text3) >= 0) & (text3 == text2))
					{
						Result.TotalTimeAsSec += machineGCodeConfigrasyon.MCodeList[l].TimeAsSec;
						Result.TotalMCodeTimeAsSec += machineGCodeConfigrasyon.MCodeList[l].TimeAsSec;
						flag4 = true;
					}
				}
				if (!flag4)
				{
					if (Result.NoDefinedMCodes.Count != 0)
					{
						if (!buString5.isCharsInStringList(GCodes[k].Trim(), Result.NoDefinedMCodes))
						{
							Result.NoDefinedMCodes.Add(GCodes[k].Trim());
						}
					}
					else
					{
						Result.NoDefinedMCodes.Add(GCodes[k].Trim());
					}
				}
			}
			if (flag)
			{
				Pnt6D.CoordinateCopy(foundPoint, ref copyPoint);
			}
		}
		Result.OperationLengthAsMeter = Math.Round(Result.OperationLengthAsMeter, 5);
		Result.OperationTimeAsSec = Math.Round(Result.OperationTimeAsSec, 5);
		Result.QuickMoveLengthAsMeter = Math.Round(Result.QuickMoveLengthAsMeter, 5);
		Result.QuickMoveTimeAsSec = Math.Round(Result.QuickMoveTimeAsSec, 5);
		Result.TotalLengthAsMeter = Math.Round(Result.OperationLengthAsMeter + Result.QuickMoveLengthAsMeter, 5);
		Result.TotalMCodeTimeAsSec = Math.Round(Result.TotalMCodeTimeAsSec, 5);
		Result.TotalTimeAsSec = Math.Round(Result.TotalTimeAsSec, 5);
	}

	public void CalculateGCodeTimeAndLength(Pnt6D pntLast, Pnt6D pntCurrent, int LastCode, double LastF, double LastR, bool isContantMove, MachineAxisInfo AX_X, MachineAxisInfo AX_Y, MachineAxisInfo AX_Z, MachineAxisInfo AX_A, MachineAxisInfo AX_B, MachineAxisInfo AX_C, ref MachineGCodeExecutionResult Result)
	{
		Length6D Delta = new Length6D();
		Pnt6D.GetDifferences(pntLast, pntCurrent, ref Delta);
		double num = 0.0;
		double num2 = 0.0;
		num2 = buCall.buVector5_0.Length3D(pntLast, pntCurrent);
		if ((LastCode == 2 || LastCode == 3) && LastR > 0.0)
		{
			bool cW = true;
			if (LastCode == 3)
			{
				cW = false;
			}
			Entity entArc = null;
			buCall.buVector5_0.ArcWithTwoPointAndRadius(new Point3D(pntLast.X, pntLast.Y), new Point3D(pntCurrent.X, pntCurrent.Y), LastR, cW, Plane.XY, ref entArc);
			if (entArc != null)
			{
				num2 = ((ICurve)entArc).Length();
			}
		}
		if (LastCode != 0)
		{
			if (LastCode != 1)
			{
				if (LastCode == 2 || LastCode == 3)
				{
					if (isContantMove)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromConstantMove(LastF, Math.Abs(num2));
					}
					else if (Math.Abs(num2) > 0.01 && AX_X != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(LastF, AX_X.Acceleration, AX_X.Deceleration, num2);
					}
				}
			}
			else
			{
				double num3 = Math.Abs(Delta.dX) / num2;
				double num4 = Math.Abs(Delta.dY) / num2;
				double num5 = Math.Abs(Delta.dZ) / num2;
				if (isContantMove)
				{
					if (Math.Abs(Delta.dX) > 0.01 && AX_X != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromConstantMove(LastF * num3, Math.Abs(Delta.dX));
					}
					if (Math.Abs(Delta.dY) > 0.01 && AX_Y != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromConstantMove(LastF * num4, Math.Abs(Delta.dY));
					}
					if (Math.Abs(Delta.dZ) > 0.01 && AX_Z != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromConstantMove(LastF * num5, Math.Abs(Delta.dZ));
					}
				}
				else
				{
					if (Math.Abs(Delta.dX) > 0.01 && AX_X != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(LastF * num3, AX_X.Acceleration, AX_X.Deceleration, Math.Abs(Delta.dX));
					}
					if (Math.Abs(Delta.dY) > 0.01 && AX_Y != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(LastF * num4, AX_Y.Acceleration, AX_Y.Deceleration, Math.Abs(Delta.dY));
					}
					if (Math.Abs(Delta.dZ) > 0.01 && AX_Z != null)
					{
						num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(LastF * num5, AX_Z.Acceleration, AX_Z.Deceleration, Math.Abs(Delta.dZ));
					}
				}
			}
		}
		else
		{
			if (Math.Abs(Delta.dX) > 0.01 && AX_X != null)
			{
				num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(AX_X.MaxSpeed, AX_X.Acceleration, AX_X.Deceleration, Math.Abs(Delta.dX));
			}
			if (Math.Abs(Delta.dY) > 0.01 && AX_Y != null)
			{
				num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(AX_Y.MaxSpeed, AX_Y.Acceleration, AX_Y.Deceleration, Math.Abs(Delta.dY));
			}
			if (Math.Abs(Delta.dZ) > 0.01 && AX_Z != null)
			{
				num += buCall.buVector5_0.CalculateTotalTimeFromTrapezLinearMove(AX_Z.MaxSpeed, AX_Z.Acceleration, AX_Z.Deceleration, Math.Abs(Delta.dZ));
			}
		}
		Result.TotalTimeAsSec += num;
		if (LastCode == 0)
		{
			Result.QuickMoveTimeAsSec += num;
			Result.QuickMoveLengthAsMeter += num2 / 1000.0;
		}
		if (LastCode == 1 || LastCode == 2 || LastCode == 3)
		{
			Result.OperationTimeAsSec += num;
			Result.OperationLengthAsMeter += num2 / 1000.0;
		}
	}

	public void GetCoordinatesFromLine(string Line, ref Pnt6D foundPoint, ref double foundFeed)
	{
		if (Line.IndexOf("f") >= 0)
		{
			double Value = 0.0;
			if (buString5.ReadCharValue(Line, "f", ref Value))
			{
				foundFeed = Value;
			}
		}
		if (Line.IndexOf("x") >= 0)
		{
			double Value2 = 0.0;
			if (buString5.ReadCharValue(Line, "x", ref Value2))
			{
				foundPoint.X = Value2;
			}
		}
		if (Line.IndexOf("y") >= 0)
		{
			double Value3 = 0.0;
			if (buString5.ReadCharValue(Line, "y", ref Value3))
			{
				foundPoint.Y = Value3;
			}
		}
		if (Line.IndexOf("z") >= 0)
		{
			double Value4 = 0.0;
			if (buString5.ReadCharValue(Line, "z", ref Value4))
			{
				foundPoint.Z = Value4;
			}
		}
		if (Line.IndexOf("a") >= 0)
		{
			double Value5 = 0.0;
			if (buString5.ReadCharValue(Line, "a", ref Value5))
			{
				foundPoint.A = Value5;
			}
		}
		if (Line.IndexOf("b") >= 0)
		{
			double Value6 = 0.0;
			if (buString5.ReadCharValue(Line, "b", ref Value6))
			{
				foundPoint.B = Value6;
			}
		}
		if (Line.IndexOf("c") >= 0)
		{
			double Value7 = 0.0;
			if (buString5.ReadCharValue(Line, "c", ref Value7))
			{
				foundPoint.C = Value7;
			}
		}
	}

	public void DevideSimPoints(bool ReverseCircular, ref List<Pnt6DSimMove> SimPoints)
	{
		if (SimPoints.Count == 0)
		{
			return;
		}
		List<Pnt6DSimMove> CopiedPnt = new List<Pnt6DSimMove>();
		Pnt6DSimMove.Copy(SimPoints, ref CopiedPnt);
		SimPoints.Clear();
		SimPoints = new List<Pnt6DSimMove>();
		SimPoints.Add(new Pnt6DSimMove(CopiedPnt[0]));
		for (int i = 1; i <= CopiedPnt.Count - 1; i++)
		{
			double num = Math.Round(buCall.buVector5_0.Length6D(CopiedPnt[i - 1], CopiedPnt[i]), 3);
			if (!(num > 0.0))
			{
				SimPoints.Add(new Pnt6DSimMove(CopiedPnt[i]));
				continue;
			}
			List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
			double num2 = 20.0;
			List<Pnt6DSimMove> list = new List<Pnt6DSimMove>();
			if (CopiedPnt[i].GCode == 1)
			{
				num2 = 5.0;
			}
			if (((CopiedPnt[i].GCode == 2) | (CopiedPnt[i].GCode == 3)) & (CopiedPnt[i].R != 0.0))
			{
				bool flag = false;
				if (CopiedPnt[i].GCode == 2)
				{
					flag = true;
				}
				if (ReverseCircular)
				{
					flag = !flag;
				}
				Point3D arcStartPoint = new Point3D(CopiedPnt[i - 1].X, CopiedPnt[i - 1].Y, CopiedPnt[i - 1].Z);
				Point3D arcEndPoint = new Point3D(CopiedPnt[i].X, CopiedPnt[i].Y, CopiedPnt[i].Z);
				Entity entArc = null;
				buCall.buVector5_0.ArcWithTwoPointAndRadius(arcStartPoint, arcEndPoint, CopiedPnt[i].R, flag, Plane.XY, ref entArc);
				if (entArc != null)
				{
					double num3 = ((ICurve)entArc).Length();
					int num4 = Convert.ToInt32(num3 / num2);
					if (num4 < 3)
					{
						num2 = num3 / 5.0;
					}
					List<Point3D> pntDevided = new List<Point3D>();
					buCall.buVector5_0.EntityDevide(entArc, num2, ref pntDevided);
					if (flag)
					{
						pntDevided.Reverse();
					}
					for (int j = 0; j <= pntDevided.Count - 1; j++)
					{
						Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(pntDevided[j]);
						pnt6DSimMove.ToolNo = CopiedPnt[i].ToolNo;
						pnt6DSimMove.SpindleRpm = CopiedPnt[i].SpindleRpm;
						pnt6DSimMove.FeedRate = CopiedPnt[i].FeedRate;
						pnt6DSimMove.GCode = CopiedPnt[i].GCode;
						pnt6DSimMove.Index = CopiedPnt[i].Index;
						pnt6DSimMove.isMCode = CopiedPnt[i].isMCode;
						pnt6DSimMove.MCode = CopiedPnt[i].MCode;
						pnt6DSimMove.Offset = CopiedPnt[i].Offset;
						pnt6DSimMove.ToolName = CopiedPnt[i].ToolName;
						pnt6DSimMove.Index = CopiedPnt[i].Index;
						list.Add(pnt6DSimMove);
					}
				}
			}
			if (list.Count > 1)
			{
				for (int k = 1; k <= list.Count - 1; k++)
				{
					SimPoints.Add(new Pnt6DSimMove(list[k]));
				}
				continue;
			}
			if (!(num > num2))
			{
				SimPoints.Add(new Pnt6DSimMove(CopiedPnt[i]));
				continue;
			}
			int num5 = Convert.ToInt32(num / num2);
			if (num5 < 4)
			{
				num5 = 4;
			}
			buCall.buVector5_0.LineerInterpolation(CopiedPnt[i - 1], CopiedPnt[i], num5, ref CalculatedPoints);
			if (CalculatedPoints.Count > 0)
			{
				CalculatedPoints.RemoveAt(0);
				SimPoints.AddRange(CalculatedPoints);
			}
		}
	}

	public void ReCalculateSimulationPoints(ref camTp Cam)
	{
		Cam.SimilationPoint.SimMove.Clear();
		Cam.SimilationPoint.SimMove = new List<Pnt6DSimMove>();
		for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
		{
			if (i <= 0)
			{
				CreateSimulationPointsFromCamPoint(ref Cam, null, Cam.CamPoints[i]);
			}
			else
			{
				CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[i - 1], Cam.CamPoints[i]);
			}
		}
	}

	public void CreateSimulationPointsFromCamPoint(ref List<Pnt6DSimMove> SimPoints, camTpPoint CamPoint, double DevideLen = 5.0)
	{
		camTp Cam = new camTp();
		CreateSimulationPointsFromCamPoint(ref Cam, CamPoint, DevideLen);
		SimPoints.AddRange(Pnt6DSimMove.Copy(Cam.SimilationPoint.SimMove));
	}

	public void CreateSimulationPointsFromCamPoint(ref camTp Cam, camTpPoint CamPoint, double G0Devide = 10.0, double G1Devide = 2.0)
	{
		if (G0Devide <= 0.0)
		{
			G0Devide = 5.0;
		}
		if (G1Devide <= 0.0)
		{
			G1Devide = 2.0;
		}
		if (CamPoint.PrePoints.Count > 0)
		{
			Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.PrePoints[0]));
			CreateSimulationPointsFromType(ref Cam, CamPoint.PrePoints, G0Devide, G1Devide);
		}
		if (CamPoint.Points.Count > 0)
		{
			if (CamPoint.PrePoints.Count > 0)
			{
				List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
				double num = buCall.buVector_0.Length3D(new Pnt3D(CamPoint.PrePoints[CamPoint.PrePoints.Count - 1].P9.X, CamPoint.PrePoints[CamPoint.PrePoints.Count - 1].P9.Y, CamPoint.PrePoints[CamPoint.PrePoints.Count - 1].P9.Z), new Pnt3D(CamPoint.Points[0].P9.X, CamPoint.Points[0].P9.Y, CamPoint.Points[0].P9.Z));
				int count = Convert.ToInt32(num / G0Devide);
				buCall.buVector5_0.LineerInterpolation(TpPnt9D.ToPnt6DSim(CamPoint.PrePoints[CamPoint.PrePoints.Count - 1]), TpPnt9D.ToPnt6DSim(CamPoint.Points[0]), count, ref CalculatedPoints);
				if (CalculatedPoints.Count >= 2)
				{
					CalculatedPoints.RemoveAt(0);
					Cam.SimilationPoint.SimMove.AddRange(CalculatedPoints);
				}
			}
			Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.Points[0]));
			CreateSimulationPointsFromType(ref Cam, CamPoint.Points, G0Devide, G1Devide);
		}
		if (CamPoint.AfterPoints.Count <= 0)
		{
			return;
		}
		if (CamPoint.Points.Count > 0)
		{
			List<Pnt6DSimMove> CalculatedPoints2 = new List<Pnt6DSimMove>();
			Point3D startPoint = new Point3D(CamPoint.Points[CamPoint.Points.Count - 1].P9.X, CamPoint.Points[CamPoint.Points.Count - 1].P9.Y, CamPoint.Points[CamPoint.Points.Count - 1].P9.Z);
			Point3D endPoint = new Point3D(CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1].P9.X, CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1].P9.Y, CamPoint.AfterPoints[CamPoint.AfterPoints.Count - 1].P9.Z);
			double num2 = buCall.buVector5_0.Length3D(startPoint, endPoint);
			int count2 = Convert.ToInt32(num2 / G0Devide);
			buCall.buVector5_0.LineerInterpolation(TpPnt9D.ToPnt6DSim(CamPoint.Points[CamPoint.Points.Count - 1]), TpPnt9D.ToPnt6DSim(CamPoint.AfterPoints[0]), count2, ref CalculatedPoints2);
			if (CalculatedPoints2.Count >= 2)
			{
				CalculatedPoints2.RemoveAt(0);
				Cam.SimilationPoint.SimMove.AddRange(CalculatedPoints2);
			}
		}
		Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.AfterPoints[0]));
		CreateSimulationPointsFromType(ref Cam, CamPoint.AfterPoints, G0Devide, G1Devide);
	}

	public void CreateSimulationPointsFromCamPoint(ref camTp Cam, camTpPoint PreCamPoint, camTpPoint CamPoint, double DevideLen = 5.0)
	{
		TpPnt9D tpPnt9D = null;
		if (CamPoint.PrePoints.Count <= 0)
		{
			if (CamPoint.Points.Count > 0)
			{
				tpPnt9D = new TpPnt9D(CamPoint.Points[0]);
			}
		}
		else
		{
			tpPnt9D = new TpPnt9D(CamPoint.PrePoints[0]);
		}
		if (PreCamPoint != null && tpPnt9D != null && PreCamPoint.AfterPoints.Count > 0)
		{
			List<Pnt6DSimMove> simPoints = new List<Pnt6DSimMove>();
			SimilationPointBetweenTwoPoints(PreCamPoint.AfterPoints[PreCamPoint.AfterPoints.Count - 1], tpPnt9D, ref simPoints, DevideLen);
			if (simPoints.Count >= 0)
			{
				Cam.SimilationPoint.SimMove.AddRange(simPoints);
			}
		}
		if (CamPoint.PrePoints.Count > 0)
		{
			Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.PrePoints[0]));
			CreateSimulationPointsFromType(ref Cam, CamPoint.PrePoints);
		}
		if (CamPoint.Points.Count > 0)
		{
			if (CamPoint.PrePoints.Count > 0)
			{
				List<Pnt6DSimMove> simPoints2 = new List<Pnt6DSimMove>();
				SimilationPointBetweenTwoPoints(CamPoint.PrePoints[CamPoint.PrePoints.Count - 1], CamPoint.Points[0], ref simPoints2, DevideLen);
				if (simPoints2.Count > 0)
				{
					Cam.SimilationPoint.SimMove.AddRange(simPoints2);
				}
			}
			Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.Points[0]));
			CreateSimulationPointsFromType(ref Cam, CamPoint.Points);
		}
		if (CamPoint.AfterPoints.Count <= 0)
		{
			return;
		}
		if (CamPoint.Points.Count > 0)
		{
			List<Pnt6DSimMove> simPoints3 = new List<Pnt6DSimMove>();
			SimilationPointBetweenTwoPoints(CamPoint.Points[CamPoint.Points.Count - 1], CamPoint.AfterPoints[0], ref simPoints3, DevideLen);
			if (simPoints3.Count >= 0)
			{
				Cam.SimilationPoint.SimMove.AddRange(simPoints3);
			}
		}
		Cam.SimilationPoint.SimMove.Add(TpPnt9D.ToPnt6DSim(CamPoint.AfterPoints[0]));
		CreateSimulationPointsFromType(ref Cam, CamPoint.AfterPoints);
	}

	public void CreateSimulationPointsFromType(ref List<Pnt6DSimMove> simPoints, List<TpPnt9D> Points)
	{
		camTp Cam = new camTp();
		CreateSimulationPointsFromType(ref Cam, Points);
		simPoints.AddRange(Pnt6DSimMove.Copy(Cam.SimilationPoint.SimMove));
	}

	public void CreateSimulationPointsFromType(ref camTp Cam, List<TpPnt9D> Points, double G0Devide = 10.0, double G1Devide = 2.0)
	{
		if (G0Devide <= 0.0)
		{
			G0Devide = 10.0;
		}
		if (G1Devide <= 0.0)
		{
			G1Devide = 2.0;
		}
		TpPnt9D tpPnt9D = new TpPnt9D(Points[0]);
		for (int i = 1; i <= Points.Count - 1; i++)
		{
			TpPnt9D tpPnt9D2 = new TpPnt9D(Points[i]);
			if (!tpPnt9D2.EnableAxes.X)
			{
				tpPnt9D2.P9.X = tpPnt9D.P9.X;
			}
			if (!tpPnt9D2.EnableAxes.Y)
			{
				tpPnt9D2.P9.Y = tpPnt9D.P9.Y;
			}
			if (!tpPnt9D2.EnableAxes.Z)
			{
				tpPnt9D2.P9.Z = tpPnt9D.P9.Z;
			}
			if (!tpPnt9D2.EnableAxes.A)
			{
				tpPnt9D2.P9.A = tpPnt9D.P9.A;
			}
			if (!tpPnt9D2.EnableAxes.B)
			{
				tpPnt9D2.P9.B = tpPnt9D.P9.B;
			}
			if (!tpPnt9D2.EnableAxes.C)
			{
				tpPnt9D2.P9.C = tpPnt9D.P9.C;
			}
			List<Pnt6DSimMove> CalculatedPoints = new List<Pnt6DSimMove>();
			double num = buCall.buVector_0.Length3D(new Pnt3D(tpPnt9D.P9.X, tpPnt9D.P9.Y, tpPnt9D.P9.Z), new Pnt3D(tpPnt9D2.P9.X, tpPnt9D2.P9.Y, tpPnt9D2.P9.Z));
			if (tpPnt9D2.Type != 0)
			{
				if (tpPnt9D2.Type != 1)
				{
					if ((tpPnt9D2.Type == 2) | (tpPnt9D2.Type == 3))
					{
						num = tpPnt9D2.ArcData.Length;
						if ((tpPnt9D2.ArcData.Length == 0.0) & (tpPnt9D2.ArcData.Radius > 0.0))
						{
							num = buCall.buVector5_0.ArcCircumference(tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartAngle, tpPnt9D2.ArcData.EndAngle);
						}
						Arc arc = new Arc(Plane.XY, tpPnt9D2.ArcData.CenterPoint, tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartPoint, tpPnt9D2.ArcData.EndPoint, flip: false);
						arc.Regen(0.01);
						List<Pnt3D> Vertices = new List<Pnt3D>();
						bool flag = Points[i].ArcData.isReverse;
						if (tpPnt9D2.Type == 2)
						{
							if (!flag)
							{
								flag = true;
							}
							Points[i].ArcData.isReverse = true;
						}
						if (flag)
						{
							buCall.buVector_0.ArcToLineer(buConversion5.Point3DToPnt3D(tpPnt9D2.ArcData.CenterPoint), tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartAngle, tpPnt9D2.ArcData.EndAngle, G1Devide, new WorkPlane(), ref Vertices);
							Vertices.Reverse();
						}
						else
						{
							buCall.buVector_0.ArcToLineer(buConversion5.Point3DToPnt3D(tpPnt9D2.ArcData.CenterPoint), tpPnt9D2.ArcData.Radius, tpPnt9D2.ArcData.StartAngle, tpPnt9D2.ArcData.EndAngle, G1Devide, new WorkPlane(), ref Vertices);
						}
						if (Vertices.Count > 0)
						{
							for (int j = 0; j <= Vertices.Count - 1; j++)
							{
								Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(Vertices[j].X, Vertices[j].Y, Vertices[j].Z);
								pnt6DSimMove.A = tpPnt9D2.P9.A;
								CalculatedPoints.Add(pnt6DSimMove);
							}
						}
					}
				}
				else
				{
					int count = Convert.ToInt32(num / G1Devide);
					buCall.buVector5_0.LineerInterpolation(TpPnt9D.ToPnt6DSim(tpPnt9D), TpPnt9D.ToPnt6DSim(tpPnt9D2), count, ref CalculatedPoints);
				}
			}
			else
			{
				int count2 = Convert.ToInt32(num / G0Devide);
				if (num <= 0.1 && !buCompare5.EQ(tpPnt9D.P9.C, tpPnt9D2.P9.C))
				{
					count2 = 50;
				}
				buCall.buVector5_0.LineerInterpolation(TpPnt9D.ToPnt6DSim(tpPnt9D), TpPnt9D.ToPnt6DSim(tpPnt9D2), count2, ref CalculatedPoints);
			}
			if (CalculatedPoints.Count < 2)
			{
				if (Cam.SimilationPoint.SimMove.Count <= 0)
				{
					Pnt6DSimMove pnt6DSimMove2 = TpPnt9D.ToPnt6DSim(tpPnt9D2);
					pnt6DSimMove2.FeedRate = Points[i].Feed;
					pnt6DSimMove2.ToolNo = Points[i].ToolNo;
					pnt6DSimMove2.SpindleRpm = Points[i].SpindleSpeed;
					Cam.SimilationPoint.SimMove.Add(pnt6DSimMove2);
				}
				else
				{
					Pnt6DSimMove pnt6DSimMove3 = TpPnt9D.ToPnt6DSim(tpPnt9D2);
					if (!buCompare5.EQ(Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1], pnt6DSimMove3, 0.01))
					{
						double num2 = buCall.buVector5_0.Length6D(pnt6DSimMove3, Cam.SimilationPoint.SimMove[Cam.SimilationPoint.SimMove.Count - 1]);
						if (num2 >= G1Devide)
						{
							pnt6DSimMove3.FeedRate = Points[i].Feed;
							pnt6DSimMove3.ToolNo = Points[i].ToolNo;
							pnt6DSimMove3.SpindleRpm = Points[i].SpindleSpeed;
							Cam.SimilationPoint.SimMove.Add(pnt6DSimMove3);
						}
					}
				}
			}
			else
			{
				CalculatedPoints.RemoveAt(0);
				for (int k = 0; k <= CalculatedPoints.Count - 1; k++)
				{
					CalculatedPoints[k].FeedRate = Points[i].Feed;
					CalculatedPoints[k].ToolNo = Points[i].ToolNo;
					CalculatedPoints[k].SpindleRpm = Points[i].SpindleSpeed;
					Cam.SimilationPoint.SimMove.Add(CalculatedPoints[k]);
				}
			}
			tpPnt9D = new TpPnt9D(tpPnt9D2);
		}
	}

	public void SimilationPointBetweenTwoPoints(TpPnt9D pntFirst, TpPnt9D pntSecond, ref List<Pnt6DSimMove> simPoints, double DevideLength = 5.0)
	{
		simPoints = new List<Pnt6DSimMove>();
		TpPnt9D tpPnt9D = new TpPnt9D(pntFirst);
		TpPnt9D tpPnt9D2 = new TpPnt9D(pntSecond);
		if (!tpPnt9D2.EnableAxes.X)
		{
			tpPnt9D2.P9.X = tpPnt9D.P9.X;
		}
		if (!tpPnt9D2.EnableAxes.Y)
		{
			tpPnt9D2.P9.Y = tpPnt9D.P9.Y;
		}
		if (!tpPnt9D2.EnableAxes.Z)
		{
			tpPnt9D2.P9.Z = tpPnt9D.P9.Z;
		}
		if (!tpPnt9D2.EnableAxes.A)
		{
			tpPnt9D2.P9.A = tpPnt9D.P9.A;
		}
		if (!tpPnt9D2.EnableAxes.B)
		{
			tpPnt9D2.P9.B = tpPnt9D.P9.B;
		}
		if (!tpPnt9D2.EnableAxes.C)
		{
			tpPnt9D2.P9.C = tpPnt9D.P9.C;
		}
		double num = buCall.buVector5_0.Length3D(tpPnt9D, tpPnt9D2);
		int count = Convert.ToInt32(num / DevideLength);
		buCall.buVector5_0.LineerInterpolation(TpPnt9D.ToPnt6DSim(tpPnt9D), TpPnt9D.ToPnt6DSim(tpPnt9D2), count, ref simPoints);
		if (simPoints.Count >= 2)
		{
			simPoints.RemoveAt(0);
		}
	}

	public void GetStartAndEndPointOfCam(camTp Cam, ref TpPnt9D StartPoint, ref TpPnt9D EndPoint)
	{
		bool flag = false;
		if (Cam != null && Cam.CamPoints.Count > 0)
		{
			if (Cam.CamPoints[0].PrePoints.Count > 0)
			{
				StartPoint = new TpPnt9D(Cam.CamPoints[0].PrePoints[0]);
				flag = true;
			}
			if (!flag && Cam.CamPoints[0].Points.Count > 0)
			{
				StartPoint = new TpPnt9D(Cam.CamPoints[0].Points[0]);
				flag = true;
			}
			if (Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count > 0)
			{
				EndPoint = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].Points[Cam.CamPoints[Cam.CamPoints.Count - 1].Points.Count - 1]);
			}
			if (Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints.Count > 0)
			{
				EndPoint = new TpPnt9D(Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints[Cam.CamPoints[Cam.CamPoints.Count - 1].AfterPoints.Count - 1]);
				flag = true;
			}
		}
	}

	public void LeadInOutCalculation(LeadInOutEntitiesProps FirstEntity, LeadInOutEntitiesProps LastEntitiy, LeadIn5 LeadInProp, LeadOut5 LeadOutProp, Plane Plane, ClockDirectionType Direction, ref List<buEntity> LeadInEntitiy, ref List<buEntity> LeadOutEntitiy)
	{
		try
		{
			double pointTangentAngle = FirstEntity.PointTangentAngle;
			double pointTangentAngle2 = LastEntitiy.PointTangentAngle;
			Point3D point3D = new Point3D();
			Point3D point3D2 = new Point3D();
			if (FirstEntity.RefEntity.sortDirection != entitySortDirection.Reverse)
			{
				point3D = buVector5.ToPoint3D(FirstEntity.RefEntity.Vertices[0]);
				if (LeadInProp.ExtendLength > 0.0)
				{
					Point3D end = buVector5.ToPoint3D(point3D);
					Point3D EndPnt = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt);
					buEntity item = new buLine(EndPnt, end);
					LeadInEntitiy.Add(item);
					point3D = buVector5.ToPoint3D(EndPnt);
				}
			}
			else
			{
				point3D = buVector5.ToPoint3D(FirstEntity.RefEntity.Vertices[FirstEntity.RefEntity.Vertices.Count - 1]);
				if (LeadInProp.ExtendLength > 0.0)
				{
					Point3D end2 = buVector5.ToPoint3D(point3D);
					Point3D EndPnt2 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, LeadInProp.ExtendLength, FirstEntity.PointTangentAngle + 180.0, Plane, ref EndPnt2);
					buEntity item2 = new buLine(EndPnt2, end2);
					LeadInEntitiy.Add(item2);
					point3D = buVector5.ToPoint3D(EndPnt2);
				}
			}
			if (LastEntitiy.RefEntity.sortDirection != entitySortDirection.Reverse)
			{
				point3D2 = buVector5.ToPoint3D(LastEntitiy.RefEntity.Vertices[LastEntitiy.RefEntity.Vertices.Count - 1]);
				if (LeadOutProp.ExtendLength > 0.0)
				{
					Point3D start = buVector5.ToPoint3D(point3D2);
					Point3D EndPnt3 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt3);
					buEntity item3 = new buLine(start, EndPnt3);
					LeadOutEntitiy.Add(item3);
					point3D2 = buVector5.ToPoint3D(EndPnt3);
				}
			}
			else
			{
				point3D2 = buVector5.ToPoint3D(LastEntitiy.RefEntity.Vertices[0]);
				if (LeadOutProp.ExtendLength > 0.0)
				{
					Point3D start2 = buVector5.ToPoint3D(point3D2);
					Point3D EndPnt4 = new Point3D();
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, LeadOutProp.ExtendLength, LastEntitiy.PointTangentAngle, Plane, ref EndPnt4);
					buEntity item4 = new buLine(start2, EndPnt4);
					LeadOutEntitiy.Add(item4);
					point3D2 = buVector5.ToPoint3D(EndPnt4);
				}
			}
			if ((LeadInProp.LeadType == LeadInOutType.Line) & LeadInProp.Enable)
			{
				Point3D EndPnt5 = new Point3D();
				double num = 1.0;
				if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
				{
					num = -1.0;
				}
				buCall.buVector5_0.LineWithLengthAndAngle(point3D, LeadInProp.Length, pointTangentAngle + 180.0 + LeadInProp.TangentAngle * num, Plane, ref EndPnt5);
				buEntity item5 = new buLine(EndPnt5, point3D);
				LeadInEntitiy.Add(item5);
			}
			if ((LeadInProp.LeadType == LeadInOutType.Arc) & LeadInProp.Enable)
			{
				buArc buArc2 = null;
				double num2 = 0.0;
				double num3 = 0.0;
				Point3D EndPnt6 = new Point3D();
				if (LeadInProp.ClockDir == ClockDirectionType.CW)
				{
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, LeadInProp.ArcRadius, pointTangentAngle - 90.0, Plane, ref EndPnt6);
					num2 = buCall.buVector5_0.PointAngle(point3D, EndPnt6, Plane);
					num3 = num2 + LeadInProp.ArcSweepAngle;
					buArc2 = new buArc(Plane, EndPnt6, LeadInProp.ArcRadius, num2, num3);
					buArc2.sortDirection = entitySortDirection.Reverse;
				}
				if (LeadInProp.ClockDir == ClockDirectionType.CCW)
				{
					buCall.buVector5_0.LineWithLengthAndAngle(point3D, LeadInProp.ArcRadius, pointTangentAngle + 90.0, Plane, ref EndPnt6);
					num3 = buCall.buVector5_0.PointAngle(point3D, EndPnt6, Plane);
					num2 = num3 - LeadInProp.ArcSweepAngle;
					buArc2 = new buArc(Plane, EndPnt6, LeadInProp.ArcRadius, num2, num3);
				}
				if (buArc2 != null)
				{
					LeadInEntitiy.Insert(0, buArc2);
				}
			}
			if ((LeadOutProp.LeadType == LeadInOutType.Line) & LeadOutProp.Enable)
			{
				Point3D EndPnt7 = new Point3D();
				double num4 = 1.0;
				if (LeadOutProp.ClockDir == ClockDirectionType.CW)
				{
					num4 = -1.0;
				}
				buCall.buVector5_0.LineWithLengthAndAngle(point3D2, LeadOutProp.Length, pointTangentAngle2 + LeadOutProp.TangentAngle * num4, Plane, ref EndPnt7);
				buEntity item6 = new buLine(point3D2, EndPnt7);
				LeadOutEntitiy.Add(item6);
			}
			if ((LeadOutProp.LeadType == LeadInOutType.Arc) & LeadOutProp.Enable)
			{
				buArc buArc3 = null;
				double num5 = 0.0;
				double num6 = 0.0;
				Point3D EndPnt8 = new Point3D();
				if (LeadOutProp.ClockDir == ClockDirectionType.CW)
				{
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, LeadOutProp.ArcRadius, pointTangentAngle2 - 90.0, Plane, ref EndPnt8);
					num6 = buCall.buVector5_0.PointAngle(point3D2, EndPnt8, Plane);
					num5 = num6 - LeadOutProp.ArcSweepAngle;
					buArc3 = new buArc(Plane, EndPnt8, LeadOutProp.ArcRadius, num5, num6);
					buArc3.sortDirection = entitySortDirection.Reverse;
				}
				if (LeadOutProp.ClockDir == ClockDirectionType.CCW)
				{
					buCall.buVector5_0.LineWithLengthAndAngle(point3D2, LeadOutProp.ArcRadius, pointTangentAngle2 + 90.0, Plane, ref EndPnt8);
					num5 = buCall.buVector5_0.PointAngle(point3D2, EndPnt8, Plane);
					num6 = num5 + LeadOutProp.ArcSweepAngle;
					buArc3 = new buArc(Plane, EndPnt8, LeadOutProp.ArcRadius, num5, num6);
					buArc3.sortDirection = entitySortDirection.Normal;
				}
				if (buArc3 != null)
				{
					LeadOutEntitiy.Add(buArc3);
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

	public void LeadInOutCalculation(buEntity FirstEntity, buEntity LastEntitiy, LeadIn In, LeadOut Out, Plane Plane, ClockDirectionType Direction, ref buEntity LeadInEntitiy, ref buEntity LeadOutEntitiy)
	{
		try
		{
			double num = 0.0;
			double num2 = 0.0;
			Point3D point3D = buVector5.ToPoint3D(FirstEntity.Vertices[0]);
			Point3D point3D2 = buVector5.ToPoint3D(LastEntitiy.Vertices[LastEntitiy.Vertices.Count - 1]);
			num = ((FirstEntity.GetType() == typeof(buArc)) ? (((buArc)FirstEntity).StartAngle + 90.0) : buCall.buVector5_0.PointAngle(FirstEntity.Vertices[1], FirstEntity.Vertices[0], Plane));
			num2 = ((LastEntitiy.GetType() == typeof(buArc)) ? (((buArc)FirstEntity).EndAngle - 90.0) : buCall.buVector5_0.PointAngle(FirstEntity.Vertices[FirstEntity.Vertices.Count - 2], FirstEntity.Vertices[FirstEntity.Vertices.Count - 1], Plane));
			if (FirstEntity.sortDirection == entitySortDirection.Reverse)
			{
				point3D = buVector5.ToPoint3D(FirstEntity.Vertices[FirstEntity.Vertices.Count - 1]);
				point3D2 = buVector5.ToPoint3D(LastEntitiy.Vertices[0]);
				num = ((FirstEntity.GetType() == typeof(buArc)) ? (((buArc)FirstEntity).EndAngle - 90.0) : buCall.buVector5_0.PointAngle(FirstEntity.Vertices[0], FirstEntity.Vertices[1], Plane));
				num2 = ((LastEntitiy.GetType() == typeof(buArc)) ? (((buArc)FirstEntity).StartAngle + 90.0) : buCall.buVector5_0.PointAngle(FirstEntity.Vertices[FirstEntity.Vertices.Count - 1], FirstEntity.Vertices[FirstEntity.Vertices.Count - 2], Plane));
			}
			if (In.LeadType == LeadInOutType.Line)
			{
				Point3D EndPnt = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(point3D, In.Length, num + 180.0 + In.TangentAngle, Plane, ref EndPnt);
				LeadInEntitiy = new buLine(EndPnt, point3D);
			}
			if (In.LeadType == LeadInOutType.Arc)
			{
				Point3D EndPnt2 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(point3D, In.ArcRadius, num + In.ArcSweepAngle, Plane, ref EndPnt2);
				double num3 = buCall.buVector5_0.PointAngle(point3D, EndPnt2, Plane);
				double startAngle = num3 - In.ArcSweepAngle;
				LeadInEntitiy = new buArc(Plane, EndPnt2, In.ArcRadius, startAngle, num3);
			}
			if (Out.LeadType == LeadInOutType.Line)
			{
				Point3D EndPnt3 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(point3D2, Out.Length, num2 + 180.0 + Out.TangentAngle, Plane, ref EndPnt3);
				LeadOutEntitiy = new buLine(point3D2, EndPnt3);
			}
			if (Out.LeadType == LeadInOutType.Arc)
			{
				Point3D EndPnt4 = new Point3D();
				buCall.buVector5_0.LineWithLengthAndAngle(point3D2, In.ArcRadius, num2 + 180.0 + In.ArcSweepAngle, Plane, ref EndPnt4);
				double num4 = buCall.buVector5_0.PointAngle(point3D2, EndPnt4, Plane);
				double endAngle = num4 + In.ArcSweepAngle;
				LeadOutEntitiy = new buArc(Plane, EndPnt4, In.ArcRadius, num4, endAngle);
			}
		}
		catch (Exception mSException)
		{
			string text = "FirstEntity: " + FirstEntity.ToString() + " - LastEntitiyEntity: " + LastEntitiy.ToString() + " - In: " + In.ToString() + " - Out: " + Out.ToString() + " - Plane: " + Plane.ToString();
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculateMarbleItem(List<List<eEntities>> Entities, KinematicBase Kinematic, ToolBase Tool, MarbleItemSettings OperationPars, marbleCamPars CamPars, camSpeeds Speed, camDistances Distance, ref camTp calcCam)
	{
		try
		{
			Pnt3D pnt3D = new Pnt3D();
			Pnt6D p = new Pnt6D();
			calcCam = new camTp();
			calcCam.Tool = new ToolBase5(Tool);
			camTpPoint camTpPoint2 = new camTpPoint();
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
					camTpPoint2 = new camTpPoint();
					camTpPoint2.Type = 0;
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
					buCall.buVector_0.LineWithOrientationAngle(pnt3D3, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), safe2, ref pnt3D2);
					buCall.buKinematic_0.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Rapid, 0));
					if (i == 0)
					{
						p = new Pnt6D(CalcPoint.X, CalcPoint.Y, CalcPoint.Z, 0.0, 0.0, orientationAngle.C);
					}
					pnt3D = new Pnt3D(pnt3D2);
					pnt3D5 = new Pnt3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
					buCall.buVector_0.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), Distance.Safe, ref pnt3D2);
					buCall.buKinematic_0.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Plunge, 1));
					Line line = new Line(buConversion5.Pnt3DToPoint3D(pnt3D), buConversion5.Pnt3DToPoint3D(pnt3D5));
					line.Color = varCam.CamG1Draw.Color;
					line.ColorMethod = colorMethodType.byEntity;
					calcCam.EntitiesG1.Add(line);
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
						buCall.buKinematic_0.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D5), ref CalcPoint);
						CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Plunge, 1));
						line = new Line(buConversion5.Pnt3DToPoint3D(pnt3D), buConversion5.Pnt3DToPoint3D(pnt3D3));
						line.Color = varCam.CamG1Draw.Color;
						line.ColorMethod = colorMethodType.byEntity;
						calcCam.EntitiesG1.Add(line);
						CalcPoint = new Pnt6D();
						pnt3D5 = new Pnt3D(pnt3D4.X, pnt3D4.Y, pnt3D4.Z);
						buCall.buKinematic_0.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D5), ref CalcPoint);
						CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, feed, 1));
						line = new Line(buConversion5.Pnt3DToPoint3D(pnt3D3), buConversion5.Pnt3DToPoint3D(pnt3D4));
						line.Color = varCam.CamG1Draw.Color;
						line.ColorMethod = colorMethodType.byEntity;
						calcCam.EntitiesG1.Add(line);
						pnt3D = new Pnt3D(pnt3D4);
					}
					safe2 = (Distance.Safe - pnt3D4.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					_ = (OperationPars.MaterialParameter.MaterialThickness + Distance.StepUp - pnt3D4.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle.A));
					if (orientationAngle.A == orientationAngle2.A)
					{
					}
					if (i != Entities.Count - 1)
					{
					}
					CalcPoint = new Pnt6D();
					pnt3D5 = new Pnt3D(pnt3D4.X, pnt3D4.Y, pnt3D4.Z);
					pnt3D2 = new Pnt3D();
					buCall.buVector_0.LineWithOrientationAngle(pnt3D5, new OrientationAngle(orientationAngle.A * -1.0, 0.0, orientationAngle.C), safe2, ref pnt3D2);
					buCall.buKinematic_0.ForwardKinematix5Ax(num3, Kinematic, orientationAngle, new Pnt3D(pnt3D2), ref CalcPoint);
					CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(CalcPoint, Speed.Leave, 1));
					line = new Line(buConversion5.Pnt3DToPoint3D(pnt3D4), buConversion5.Pnt3DToPoint3D(pnt3D2));
					line.Color = varCam.CamG0Draw.Color;
					line.ColorMethod = colorMethodType.byEntity;
					calcCam.EntitiesG0.Add(line);
					for (int k = 1; k <= camTpPoint2.Points.Count - 1; k++)
					{
						List<Pnt6DSimMove> collection = new List<Pnt6DSimMove>();
						if (camTpPoint2.Points[k].Type != 0)
						{
						}
						calcCam.SimilationPoint.SimMove.AddRange(collection);
					}
					pnt3D = new Pnt3D(pnt3D4);
					eEntities.CopyEntity(copiedEnt2, ref copiedEnt);
					calcCam.CamPoints.Add(camTpPoint2);
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
			camTpPoint2 = new camTpPoint();
			camTpPoint2.Type = 0;
			camTpPoint2.Points.Add(new TpPnt9D(p, Speed.Rapid, 0));
			calcCam.CamPoints.Add(camTpPoint2);
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

	public void CalculateMarbleWireFrameWithSaw(List<List<buEntity>> Entities, List<List<buEntity>> ReCalculatedEntities, KinematicBase5 Kinematic, ToolBase5 Tool, MarbleItemSettings Operation, camParameters5 camPar, EntitiesResolution Resolution, ref MarbleItem Item)
	{
		try
		{
			List<List<buEntity>> copiedEntities = new List<List<buEntity>>();
			if (!(Operation.ReadSurfaceParameter.ApplySurfaceReadData & (Operation.ReadSurfaceParameter.SurfaceReadDevideLength > 0.0) & (buMarbleCalc.pntTeachGrids.Count > 0)))
			{
				buEntity.Copy(Entities, ref copiedEntities);
			}
			else
			{
				for (int i = 0; i <= Entities.Count - 1; i++)
				{
					List<buEntity> list = new List<buEntity>();
					List<Point3D> Points = new List<Point3D>();
					EntitiesResolution entitiesResolution = new EntitiesResolution();
					entitiesResolution.ArcResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CircleResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.CurveResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.EllipseResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.LineResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.OtherResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					entitiesResolution.PolylineResolution = new EntityResolution(Operation.ReadSurfaceParameter.SurfaceReadDevideLength, 10, 10.0, EntityResolutionType.ByLength);
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(Entities[i], 0.01, ref Points);
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
						if (((num3 >= 0) & (num3 <= buMarbleCalc.pntTeachGrids.Count - 1)) && ((num2 >= 0) & (num2 <= buMarbleCalc.pntTeachGrids[num3].Count - 1)))
						{
							num = buMarbleCalc.pntTeachGrids[num3][num2].Z;
						}
						Points[j] = new Point3D(Points[j].X, Points[j].Y, Points[j].Z + num);
					}
					buLinearPath buLinearPath2 = new buLinearPath(Points);
					buLinearPath2.Orientation = new OrientationAngle(Entities[i][0].Orientation);
					list.Add(buLinearPath2);
					copiedEntities.Add(list);
				}
			}
			bool useTangentLimit = camPar.Strategy.UseTangentLimit;
			Point3D point3D = new Point3D();
			new Pnt6D();
			double angleLimit = camPar.Strategy.AngleLimit;
			List<Triangle3D> triangles = new List<Triangle3D>();
			Item.CamList = new List<MarbleItemCam>();
			MarbleItemCam marbleItemCam = new MarbleItemCam();
			camTp camTp2 = new camTp();
			camTp2.Tool = new ToolBase5(Tool);
			camTp2.Kinematic = new KinematicBase5(Kinematic);
			KinematicItem kinematicItem = new KinematicItem();
			kinematicItem.Axis.A = true;
			kinematicItem.Axis.C = true;
			new eSurface(triangles, Tool.Display.Solid.SkinColor);
			camTp2.Kinematic.MovePartRuntimeOffset.X = 0.0;
			camTp2.Kinematic.MovePartRuntimeOffset.Y = 0.0 - Kinematic.RotateCenterOffsetOfC.Y;
			camTp2.Kinematic.MovePartRuntimeOffset.Z = 0.0 - Kinematic.RotateCenterOffsetOfC.Z;
			camTpPoint camTpPoint2 = new camTpPoint();
			List<List<Pnt6D>> list2 = new List<List<Pnt6D>>();
			int CalcEventCount = 1;
			int num4 = 0;
			new Pnt6D();
			Pnt6D pnt6D = new Pnt6D();
			OrientationAngle orientationAngle = new OrientationAngle();
			Resolution.LineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.PolylineResolution.ResolutionTypes = EntityResolutionType.None;
			Resolution.OtherResolution.ResolutionTypes = EntityResolutionType.None;
			if (ReCalculatedEntities.Count > 0)
			{
				buEntity.Copy(ReCalculatedEntities, ref copiedEntities);
			}
			if (copiedEntities.Count <= 10)
			{
				CalcEventCount = 1;
			}
			buGeneral.DoEventCountCalc(copiedEntities.Count, ref CalcEventCount);
			for (int k = 0; k <= copiedEntities.Count - 1; k++)
			{
				List<Pnt6D> list3 = new List<Pnt6D>();
				list2 = new List<List<Pnt6D>>();
				if (copiedEntities[k].Count >= 1)
				{
					List<Pnt6D> Points2 = new List<Pnt6D>();
					new List<Pnt6D>();
					buCall.buVector5_0.EntitiesToPointsWithCamDirection(copiedEntities[k], ref Points2, CircleFrom270: true);
					buCall.buVector5_0.CheckDuplicatedPointsWithPrevious(ref Points2);
					if (Points2.Count > 1)
					{
						double num5 = 0.0;
						double num6 = 0.0;
						double value = 0.0;
						double num7 = 0.0;
						double num8 = 0.0;
						double num9 = 0.0;
						double num10 = 0.0;
						num7 = buCall.buVector5_0.PointAngle(new Point3D(Points2[1].X, Points2[1].Y, Points2[1].Z), new Point3D(Points2[0].X, Points2[0].Y, Points2[0].Z));
						if (Operation.settingMarbleCam.UseCZero)
						{
							num7 = 0.0;
						}
						if (!((copiedEntities[k].Count == 1) & (Points2[0].C != 0.0)))
						{
						}
						num7 += Operation.settingMarbleCam.OffsetAngleC;
						if (num7 > 360.0)
						{
							num7 -= 360.0;
						}
						if (num7 < -360.0)
						{
							num7 += 360.0;
						}
						if (Operation.settingMarbleCam.UseConstantCAngle)
						{
							num7 = Operation.settingMarbleCam.ConstantAngleC;
						}
						num5 = num7;
						list3.Add(new Pnt6D(Points2[0].X, Points2[0].Y, Points2[0].Z, Points2[0].A, 0.0, num7));
						for (int l = 1; l <= Points2.Count - 2; l++)
						{
							bool flag = false;
							num7 = buCall.buVector5_0.PointAngle(new Point3D(Points2[l].X, Points2[l].Y, Points2[l].Z), new Point3D(Points2[l - 1].X, Points2[l - 1].Y, Points2[l - 1].Z));
							if (Operation.settingMarbleCam.UseCZero)
							{
								num7 = 0.0;
							}
							if (l != 90)
							{
							}
							num7 += Operation.settingMarbleCam.OffsetAngleC;
							if (num7 > 360.0)
							{
								num7 -= 360.0;
							}
							if (num7 < -360.0)
							{
								num7 += 360.0;
							}
							if (Operation.settingMarbleCam.UseConstantCAngle)
							{
								num7 = Operation.settingMarbleCam.ConstantAngleC;
							}
							if (!Operation.settingMarbleCam.NoAngleCAxisCheck)
							{
								if (!useTangentLimit)
								{
									angleLimit = camPar.Strategy.AngleLimit;
									num9 = buCall.buVector5_0.AngleOfTwoLines(buConversion5.Pnt6DToPoint3D(list3[list3.Count - 1]), buConversion5.Pnt6DToPoint3D(Points2[l]), buConversion5.Pnt6DToPoint3D(Points2[l]), buConversion5.Pnt6DToPoint3D(Points2[l + 1]), Plane.XY);
									num10 = 180.0 - num9;
									if (num10 >= 360.0 - angleLimit)
									{
										num10 = 360.0 - num9;
									}
									num8 = buCall.buVector5_0.PointAngle(buConversion5.Pnt6DToPoint3D(Points2[l + 1]), buConversion5.Pnt6DToPoint3D(Points2[l]));
									if (Operation.settingMarbleCam.UseCZero)
									{
										num8 = 0.0;
									}
									if (num10 > angleLimit)
									{
										list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
										list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l + 1].A, 0.0, num8));
										flag = true;
									}
									Math.Abs(num7 - num5);
									if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
									{
										list2.Add(list3);
										list3 = new List<Pnt6D>();
										list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num8));
										flag = true;
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
									num8 = buCall.buVector5_0.PointAngle(new Point3D(Points2[l + 1].X, Points2[l + 1].Y, Points2[l + 1].Z), new Point3D(Points2[l].X, Points2[l].Y, Points2[l].Z));
									if (Operation.settingMarbleCam.UseCZero)
									{
										num8 = 0.0;
									}
									num8 += Operation.settingMarbleCam.OffsetAngleC;
									angleLimit = camPar.Strategy.AngleLimit;
									num9 = buCall.buVector5_0.AngleOfTwoLines(buConversion5.Pnt6DToPoint3D(list3[list3.Count - 1]), buConversion5.Pnt6DToPoint3D(Points2[l]), buConversion5.Pnt6DToPoint3D(Points2[l]), buConversion5.Pnt6DToPoint3D(Points2[l + 1]), Plane.XY);
									num10 = 180.0 - num9;
									if (num10 >= 360.0 - angleLimit)
									{
										num10 = 360.0 - num9;
									}
									Math.Abs(num7 - num5);
									if (Math.Abs(value) > buSystem.resolutionCompare && list3.Count > 1)
									{
										list2.Add(list3);
										list3 = new List<Pnt6D>();
										list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num8));
										flag = true;
									}
								}
								if (!flag)
								{
									if (!(num10 > angleLimit && useTangentLimit))
									{
										double num11 = 0.0;
										if (useTangentLimit)
										{
											num11 = Math.Abs(num7 - list3[list3.Count - 1].C);
											if (num11 >= 360.0 - angleLimit)
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
							}
							else
							{
								list3.Add(new Pnt6D(Points2[l].X, Points2[l].Y, Points2[l].Z, Points2[l].A, 0.0, num7));
							}
							num5 = num7;
						}
						if (list3.Count > 0)
						{
							num7 = buCall.buVector5_0.PointAngle(buConversion5.Pnt6DToPoint3D(Points2[Points2.Count - 1]), buConversion5.Pnt6DToPoint3D(Points2[Points2.Count - 2]));
							if (Operation.settingMarbleCam.UseCZero)
							{
								num7 = 0.0;
							}
							if (!((copiedEntities[k].Count == 1) & (Points2[Points2.Count - 1].C != 0.0)))
							{
							}
							num7 += Operation.settingMarbleCam.OffsetAngleC;
							if (num7 > 360.0)
							{
								num7 -= 360.0;
							}
							if (num7 < -360.0)
							{
								num7 += 360.0;
							}
							if (Operation.settingMarbleCam.UseConstantCAngle)
							{
								num7 = Operation.settingMarbleCam.ConstantAngleC;
							}
							double num15 = Math.Abs(num7 - list3[list3.Count - 1].C);
							if (num15 >= 360.0 - angleLimit)
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
					}
				}
				for (int m = 0; m <= list2.Count - 1; m++)
				{
					bool flag2 = false;
					double toolLength = Tool.Geometry.Diameter / 2.0;
					double num16 = 0.0;
					double num17 = 0.0;
					Pnt6D pnt6D2 = new Pnt6D();
					new Pnt6D();
					Pnt6D pnt6D3 = new Pnt6D();
					Point3D point3D2 = new Point3D();
					Point3D point3D3 = new Point3D();
					Point3D point3D4 = new Point3D();
					OrientationAngle orientationAngle2 = new OrientationAngle();
					OrientationAngle orientationAngle3 = new OrientationAngle();
					if (k <= copiedEntities.Count - 2)
					{
						orientationAngle3 = new OrientationAngle(copiedEntities[k + 1][0].Orientation);
					}
					camTpPoint2 = new camTpPoint();
					camTpPoint2.Type = 0;
					pnt6D2 = new Pnt6D(list2[m][0]);
					point3D2 = buVector5.ToPoint3D(pnt6D2);
					orientationAngle2 = new OrientationAngle(pnt6D2);
					num16 = Operation.settingMarbleCam.SawForwardCuttingVelocity;
					num17 = (Operation.settingMarbleCam.AlwaysSafeDistance ? ((Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A))) : ((k == 0) ? ((Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A))) : ((Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawRapidDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A)))));
					num17 -= point3D2.Z;
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithOrientationAngle(point3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), num17, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, buVector5.ToPoint3D(point3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					if (orientationAngle2.A != orientationAngle.A && pnt6D.Z > pnt6D3.Z)
					{
						pnt6D3.Z = pnt6D.Z;
					}
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, camPar.Speeds.Rapid, 0, plungemove: true));
					point3D = buVector5.ToPoint3D(point3D3);
					new Pnt6D(pnt6D3);
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					buCall.buVector5_0.LineWithOrientationAngle(point3D2, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), num17, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, buVector5.ToPoint3D(point3D3), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, camPar.Speeds.Rapid, 0));
					point3D = buVector5.ToPoint3D(point3D3);
					new Pnt6D(pnt6D3);
					if (m == 0)
					{
						new Pnt6D(pnt6D3);
					}
					pnt6D3 = new Pnt6D();
					point3D4 = new Point3D(point3D2.X, point3D2.Y, point3D2.Z);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, buVector5.ToPoint3D(point3D4), ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, camPar.Speeds.Plunge, 1));
					Line line = new Line(buVector5.ToPoint3D(point3D), buVector5.ToPoint3D(point3D4));
					line.Color = varCam.CamG1Draw.Color;
					line.ColorMethod = colorMethodType.byEntity;
					camTp2.EntitiesG1.Add(line);
					point3D = buVector5.ToPoint3D(point3D2);
					new Pnt6D(pnt6D3);
					List<Point3D> list4 = new List<Point3D>();
					list4.Add(buVector5.ToPoint3D(point3D));
					for (int n = 1; n <= list2[m].Count - 1; n++)
					{
						pnt6D2 = new Pnt6D(list2[m][n]);
						if (n == 1)
						{
							pnt6D2.X += 0.02;
							pnt6D2.Y += 0.02;
						}
						orientationAngle2 = new OrientationAngle(pnt6D2);
						pnt6D3 = new Pnt6D();
						point3D4 = buVector5.ToPoint3D(pnt6D2);
						buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, point3D4, ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, num16, 1));
						list4.Add(buVector5.ToPoint3D(point3D4));
						point3D = buVector5.ToPoint3D(pnt6D2);
						new Pnt6D(pnt6D3);
						orientationAngle = new OrientationAngle(orientationAngle2);
						if (n == 1)
						{
							camTpPoint2.Points[camTpPoint2.Points.Count - 1].PreCodes.Add("G38 O1");
						}
					}
					camTpPoint2.Points[camTpPoint2.Points.Count - 1].AfterCodes.Add("G39 O1");
					if (list4.Count > 0)
					{
						LinearPath linearPath = new LinearPath(buVector5.ToPoint3D(list4));
						linearPath.Color = varCam.CamG1Draw.Color;
						linearPath.ColorMethod = colorMethodType.byEntity;
						camTp2.EntitiesG1.Add(linearPath);
					}
					if (Item.SawExtensionDistance > 0.0 && list4.Count > 1)
					{
						Point3D EndPnt = new Point3D();
						double num18 = buCall.buVector5_0.PointAngle(list4[1], list4[0]);
						buCall.buVector5_0.LineWithLengthAndAngle(list4[0], Item.SawExtensionDistance, num18 + 180.0, Plane.XY, ref EndPnt);
						buLine buLine2 = new buLine(buVector5.ToPoint3D(list4[0]), buVector5.ToPoint3D(EndPnt));
						buLine2.typeDefination = entityTypeDefination.MarbleItem;
						buLine2.Marble = new MarbleInfo();
						Item.ItemEntities.ExtensionEntities.Add(buLine2);
						EndPnt = new Point3D();
						num18 = buCall.buVector5_0.PointAngle(list4[list4.Count - 1], list4[list4.Count - 2]);
						buCall.buVector5_0.LineWithLengthAndAngle(list4[list4.Count - 1], Item.SawExtensionDistance, num18, Plane.XY, ref EndPnt);
						buLine buLine3 = new buLine(buVector5.ToPoint3D(list4[list4.Count - 1]), buVector5.ToPoint3D(EndPnt));
						buLine2.typeDefination = entityTypeDefination.MarbleItem;
						buLine3.Marble = new MarbleInfo();
						Item.ItemEntities.ExtensionEntities.Add(buLine3);
					}
					num17 = (camPar.Distances.Safe - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					_ = (Operation.MaterialParameter.MaterialThickness + camPar.Distances.StepUp - pnt6D2.Z) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
					flag2 = ((orientationAngle2.A != orientationAngle3.A) ? true : false);
					if (k == copiedEntities.Count - 1)
					{
						flag2 = true;
					}
					pnt6D3 = new Pnt6D();
					point3D3 = new Point3D();
					num17 = (Operation.settingMarbleCam.AlwaysSafeDistance ? ((Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A))) : ((Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawRapidDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A))));
					num17 -= point3D.Z;
					buCall.buVector5_0.LineWithOrientationAngle(point3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), num17, ref point3D3);
					buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, point3D3, ref pnt6D3);
					pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
					camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, camPar.Speeds.Leave, 1));
					line = new Line(point3D, point3D3);
					line.Color = varCam.CamG1Draw.Color;
					line.ColorMethod = colorMethodType.byEntity;
					camTp2.EntitiesG1.Add(line);
					orientationAngle = new OrientationAngle(orientationAngle2);
					if (flag2)
					{
						num17 = (Operation.MaterialParameter.MaterialThickness + Operation.settingMarbleCam.SawSafeDistance) / Math.Cos(buConversion.DegreeToRadian(orientationAngle2.A));
						pnt6D3 = new Pnt6D();
						point3D3 = new Point3D();
						buCall.buVector5_0.LineWithOrientationAngle(point3D, new OrientationAngle(orientationAngle2.A * -1.0, 0.0, orientationAngle2.C), num17, ref point3D3);
						buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientationAngle2, buVector5.ToPoint3D(point3D3), ref pnt6D3);
						pnt6D3.Z = pnt6D3.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
						camTpPoint2.Points.Add(new TpPnt9D(pnt6D3, camPar.Speeds.Rapid, 0));
						line = new Line(point3D, point3D3);
						line.Color = varCam.CamG0Draw.Color;
						line.ColorMethod = colorMethodType.byEntity;
						camTp2.EntitiesG1.Add(line);
					}
					pnt6D = new Pnt6D(pnt6D3);
					if (camTpPoint2.Points.Count <= 0)
					{
					}
					camTp2.CamPoints.Add(camTpPoint2);
				}
				for (int num19 = 0; num19 <= copiedEntities[k].Count - 1; num19++)
				{
				}
				if (buSystem.ProgressControlEnable && calculationEventHandler_0 != null && CalcEventCount > 0 && num4 > 0 && num4 % CalcEventCount == 0)
				{
					calculationEventHandler_0(new CalculationEventArg(Convert.ToDouble((double)k / (double)(copiedEntities.Count - 1)) * 100.0, Convert.ToDouble((double)k / (double)(copiedEntities.Count - 1)) * 100.0, 0, "Calculate Marble Code", ""));
				}
				if (buSystem.DoEventEnable && CalcEventCount > 0 && num4 > 0 && num4 % CalcEventCount == 0)
				{
					Application.DoEvents();
				}
				if (!buSystem.Cancel)
				{
					num4++;
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
			marbleItemCam.CamBase = new camTp(camTp2);
			marbleItemCam.ToolSelected = new ToolBase5(Tool);
			Item.CamList.Add(marbleItemCam);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}

	public void CalculatePointsWithKinematic(List<Pnt6D> refPoints, KinematicBase5 Kinematic, ToolBase5 Tool, ref List<Pnt6D> calcPoints)
	{
		try
		{
			double toolLength = Tool.Geometry.Diameter / 2.0;
			for (int i = 0; i <= refPoints.Count - 1; i++)
			{
				_ = refPoints[i];
				OrientationAngle orientation = new OrientationAngle(refPoints[i].A, refPoints[i].B, refPoints[i].C);
				Pnt6D CalcPoint = new Pnt6D();
				Point3D movePoint = buVector5.ToPoint3D(refPoints[i]);
				buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientation, movePoint, ref CalcPoint);
				CalcPoint.Z = CalcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
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

	public void CalculatePointsWithKinematicMilling(List<Pnt6D> refPoints, KinematicBase5 Kinematic, ToolBase5 Tool, ref List<Pnt6D> calcPoints)
	{
		try
		{
			for (int i = 0; i <= refPoints.Count - 1; i++)
			{
				_ = refPoints[i];
				OrientationAngle orientation = new OrientationAngle(refPoints[i].A, refPoints[i].B, refPoints[i].C);
				Pnt6D CalcPoint = new Pnt6D();
				Point3D movePoint = buVector5.ToPoint3D(refPoints[i]);
				buCall.buKinematic5_0.ForwardKinematix5AxMilling(Tool.Geometry.Length, Kinematic, orientation, movePoint, ref CalcPoint);
				CalcPoint.Z += Kinematic.RotateCenterOffsetOfC.Z;
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

	public void CalculatePointsWithKinematic(Pnt6D refPoint, KinematicBase5 Kinematic, ToolBase5 Tool, ref Pnt6D calcPoint)
	{
		try
		{
			double toolLength = Tool.Geometry.Diameter / 2.0;
			OrientationAngle orientation = new OrientationAngle(refPoint.A, refPoint.B, refPoint.C);
			calcPoint = new Pnt6D();
			Point3D movePoint = buVector5.ToPoint3D(refPoint);
			buCall.buKinematic5_0.ForwardKinematix5Ax(toolLength, Kinematic, orientation, movePoint, ref calcPoint);
			calcPoint.Z = calcPoint.Z + Kinematic.RotateCenterOffsetOfC.Z - Kinematic.RotateCenterOffsetOfA.Z;
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: false, text);
		}
	}
}
