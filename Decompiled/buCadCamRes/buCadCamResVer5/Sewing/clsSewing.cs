using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using buCadCamResVer5.Editor;
using buClass;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Sewing;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Sewing;

public class clsSewing
{
	[CompilerGenerated]
	private OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler_0;

	public static TreeView itemTreeView = null;

	public static SewingSettings varSewingSettings = new SewingSettings();

	public static SewingRuntimeSettings varSewingRunSettings = new SewingRuntimeSettings();

	public static SewingCompanies Company = SewingCompanies.Yesim;

	public static SewingModel Model = SewingModel.YesimModel1;

	public List<SewingMain> UndoList = new List<SewingMain>();

	public SewingMain SewingBase = new SewingMain();

	public System.Windows.Forms.Timer timSim = new System.Windows.Forms.Timer();

	public int simIndex = -1;

	public int selectedEntIndex = -1;

	public int selectedVertexIndex = -1;

	public bool SimPaused = false;

	public SewingSelectedPoint baseSelected = null;

	public List<SewingSelectedPoint> Selected = new List<SewingSelectedPoint>();

	public List<SewingJobItem> SewingTableList = new List<SewingJobItem>();

	public List<SewingCode> definedCodes = new List<SewingCode>();

	public F_SewingMove frmMove = null;

	public F_SewingRotate frmRotate = null;

	public F_SewingSelectVertex frmSelectVertex = null;

	public F_SewingFootHeight frmFootHeight = null;

	public F_SewingSpeed frmSpeed = null;

	public F_SewingTable frmTable = null;

	public string cmdTree = "";

	public bool CancelApplied = false;

	public Point3D pntCenter = new Point3D();

	public Point3D pntTarget = new Point3D();

	public Pnt9D pntCamCenter = new Pnt9D();

	public List<Point3D> pntList = new List<Point3D>();

	public List<Pnt9D> pntCam = new List<Pnt9D>();

	public int indx = 0;

	public System.Windows.Forms.Timer timm = null;

	public event OkCommandWithThreeDataEventHandler SewingExternalCommand
	{
		[CompilerGenerated]
		add
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Combine(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler = okCommandWithThreeDataEventHandler_0;
			OkCommandWithThreeDataEventHandler okCommandWithThreeDataEventHandler2;
			do
			{
				okCommandWithThreeDataEventHandler2 = okCommandWithThreeDataEventHandler;
				OkCommandWithThreeDataEventHandler value2 = (OkCommandWithThreeDataEventHandler)Delegate.Remove(okCommandWithThreeDataEventHandler2, value);
				okCommandWithThreeDataEventHandler = Interlocked.CompareExchange(ref okCommandWithThreeDataEventHandler_0, value2, okCommandWithThreeDataEventHandler2);
			}
			while ((object)okCommandWithThreeDataEventHandler != okCommandWithThreeDataEventHandler2);
		}
	}

	public void Init()
	{
		timSim.Tick += Sim_Tick;
		timSim.Interval = 20;
		OpenSewingFile();
		frmTable = new F_SewingTable();
	}

	public void InitSimulation()
	{
	}

	public void circle2()
	{
	}

	public void circle()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		Circle circle = new Circle(Plane.XY, 80.0);
		pntTarget = new Point3D(0.0, -80.0);
		circle.Regen(0.01);
		circle.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		list.Add(circle);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(circle);
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(joint);
		buCircle buCircle2 = new buCircle(new Point3D(0.0, -80.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.LineLength = 3.0;
		entityDevideData.ArcLength = 3.0;
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<Entity> BaseRefEntities = new List<Entity>();
		for (int i = 1; i <= pntList.Count - 1; i++)
		{
			Line line = new Line(new Point3D(pntList[i - 1].X, pntList[i - 1].Y), pntList[i]);
			line.Visible = true;
			line.ColorMethod = colorMethodType.byEntity;
			line.LineWeight = 3f;
			line.LineWeightMethod = colorMethodType.byEntity;
			line.EntityData = new CustomData();
			BaseRefEntities.Add(line);
		}
		List<Entity> SortedEntities = new List<Entity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
		for (int j = 0; j <= SortedEntities.Count - 1; j++)
		{
			if (((CustomData)SortedEntities[j].EntityData).sortDirection != entitySortDirection.Normal)
			{
				Line line2 = new Line(SortedEntities[j].Vertices[1], SortedEntities[j].Vertices[0]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
			else
			{
				Line line3 = new Line(SortedEntities[j].Vertices[0], SortedEntities[j].Vertices[1]);
				line3.Visible = true;
				line3.ColorMethod = colorMethodType.byEntity;
				line3.LineWeight = 3f;
				line3.LineWeightMethod = colorMethodType.byEntity;
				line3.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
			}
		}
		pntCamCenter = new Pnt9D(pntCenter.X, pntCenter.Y, 0.0);
		pntCam.Clear();
		pntCam.Add(new Pnt9D(pntCenter.X, pntCenter.Y, 0.0));
		indx = 2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void roundrect()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = CompositeCurve.CreateRoundedRectangle(Plane.XY, 286.0, 142.0, 40.0, centered: true);
		pntTarget = new Point3D(0.0, -71.0);
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(joint);
		buCircle buCircle2 = new buCircle(new Point3D(0.0, -71.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.LineLength = 3.0;
		entityDevideData.ArcLength = 3.0;
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<Entity> BaseRefEntities = new List<Entity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			Line line = new Line(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			line.Visible = true;
			line.ColorMethod = colorMethodType.byEntity;
			line.LineWeight = 3f;
			line.LineWeightMethod = colorMethodType.byEntity;
			line.EntityData = new CustomData();
			BaseRefEntities.Add(line);
		}
		List<Entity> SortedEntities = new List<Entity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
		for (int k = 0; k <= SortedEntities.Count - 1; k++)
		{
			if (((CustomData)SortedEntities[k].EntityData).sortDirection != entitySortDirection.Normal)
			{
				Line line2 = new Line(SortedEntities[k].Vertices[1], SortedEntities[k].Vertices[0]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
			else
			{
				Line line3 = new Line(SortedEntities[k].Vertices[0], SortedEntities[k].Vertices[1]);
				line3.Visible = true;
				line3.ColorMethod = colorMethodType.byEntity;
				line3.LineWeight = 3f;
				line3.LineWeightMethod = colorMethodType.byEntity;
				line3.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
			}
		}
		indx = 2;
		pntCamCenter = new Pnt9D(pntCenter.X, pntCenter.Y, 0.0);
		pntCam.Clear();
		pntCam.Add(new Pnt9D(pntCenter.X, pntCenter.Y, 0.0));
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void slot()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		CompositeCurve compositeCurve = CompositeCurve.CreateSlot(Plane.XY, 100.0, 20.0, centered: true);
		pntTarget = new Point3D(-70.0, 0.0);
		compositeCurve.Regen(0.01);
		compositeCurve.ColorMethod = colorMethodType.byEntity;
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= compositeCurve.CurveList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy((Entity)compositeCurve.CurveList[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(joint);
		buCircle buCircle2 = new buCircle(new Point3D(-70.0, 0.0), 3.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		List<Entity> devideEntities = new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		pntList = new List<Point3D>();
		clsInit.cVector5.EntitiesDevideByLengthAsPolyline(list, entityDevideData, ref devideEntities);
		clsInit.cVector5.EntitiesToPointsWithCamDirection(devideEntities, 0.01, ref pntList);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<Entity> BaseRefEntities = new List<Entity>();
		for (int j = 1; j <= pntList.Count - 1; j++)
		{
			Line line = new Line(new Point3D(pntList[j - 1].X, pntList[j - 1].Y), pntList[j]);
			line.Visible = true;
			line.ColorMethod = colorMethodType.byEntity;
			line.LineWeight = 3f;
			line.LineWeightMethod = colorMethodType.byEntity;
			line.EntityData = new CustomData();
			BaseRefEntities.Add(line);
		}
		List<Entity> SortedEntities = new List<Entity>();
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, new SortSettings(), ref SortedEntities);
		for (int k = 0; k <= SortedEntities.Count - 1; k++)
		{
			if (((CustomData)SortedEntities[k].EntityData).sortDirection != entitySortDirection.Normal)
			{
				Line line2 = new Line(SortedEntities[k].Vertices[1], SortedEntities[k].Vertices[0]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
			else
			{
				Line line3 = new Line(SortedEntities[k].Vertices[0], SortedEntities[k].Vertices[1]);
				line3.Visible = true;
				line3.ColorMethod = colorMethodType.byEntity;
				line3.LineWeight = 3f;
				line3.LineWeightMethod = colorMethodType.byEntity;
				line3.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
			}
		}
		pntCamCenter = new Pnt9D(pntCenter.X, pntCenter.Y, 0.0);
		pntCam.Clear();
		pntCam.Add(new Pnt9D(pntCenter.X, pntCenter.Y, 0.0));
		indx = 2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void freedraw()
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		pntTarget = new Point3D();
		List<buEntity> list = new List<buEntity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
			list.Add(copiedEntity);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		Joint joint = new Joint(new Point3D(), 2.0, 2);
		joint.ColorMethod = colorMethodType.byEntity;
		joint.Color = Color.Lime;
		buCircle buCircle2 = new buCircle(new Point3D(pntTarget.X, pntTarget.Y), 4.0);
		ccVars.pntDrawDynamicLines = new List<Point3D>();
		ccVars.pntDrawDynamicLines.AddRange(buCircle2.Vertices);
		new List<Entity>();
		new List<Point3D>();
		EntityDevideData entityDevideData = new EntityDevideData();
		entityDevideData.Line = true;
		entityDevideData.LineLength = 4.0;
		entityDevideData.Arc = true;
		entityDevideData.ArcLength = 4.0;
		pntList = new List<Point3D>();
		List<buEntity> BaseRefEntities = new List<buEntity>();
		for (int j = 0; j <= list.Count - 1; j++)
		{
			if (!(list[j] is buLine))
			{
				for (int k = 1; k <= list[j].Vertices.Count - 1; k++)
				{
					buLine item = new buLine(list[j].Vertices[k - 1], list[j].Vertices[k]);
					BaseRefEntities.Add(item);
				}
				continue;
			}
			pntList = new List<Point3D>();
			clsInit.cVector5.EntityDevide(list[j], 4.0, ref pntList);
			for (int l = 1; l <= pntList.Count - 1; l++)
			{
				buLine item2 = new buLine(pntList[l - 1], pntList[l]);
				BaseRefEntities.Add(item2);
			}
		}
		BaseRefEntities.Reverse();
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref pntList);
		List<buEntity> SortedEntities = new List<buEntity>();
		SortbuSettings sortbuSettings = new SortbuSettings();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
		sortbuSettings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
		clsInit.cVector5.SortEntitiesByRefPoint(pntTarget, ref BaseRefEntities, sortbuSettings, ref SortedEntities);
		for (int m = 0; m <= SortedEntities.Count - 1; m++)
		{
			if (SortedEntities[m].sortDirection != entitySortDirection.Normal)
			{
				Line line = new Line(SortedEntities[m].Vertices[1], SortedEntities[m].Vertices[0]);
				line.Visible = true;
				line.ColorMethod = colorMethodType.byEntity;
				line.LineWeight = 3f;
				line.LineWeightMethod = colorMethodType.byEntity;
				line.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line);
			}
			else
			{
				Line line2 = new Line(SortedEntities[m].Vertices[0], SortedEntities[m].Vertices[1]);
				line2.Visible = true;
				line2.ColorMethod = colorMethodType.byEntity;
				line2.LineWeight = 3f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				line2.EntityData = new CustomData();
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
			}
		}
		double dx = pntTarget.X - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].X;
		double dy = pntTarget.Y - ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[0].Vertices[0].Y;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(dx, dy);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
		indx = 0;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void rotate()
	{
		if (indx <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indx] is Line)
			{
				Line line = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indx] as Line;
				double num = 180.0 - clsInit.cVector5.PointAngle(line.EndPoint, line.StartPoint);
				double num2 = line.StartPoint.X - line.EndPoint.X;
				double num3 = line.StartPoint.Y - line.EndPoint.Y;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Translate(num2, num3);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
				double angleInRadians = buConversion5.DegreeToRadian(num);
				pntCamCenter.X += num2;
				pntCamCenter.Y += num3;
				pntCamCenter.C += num;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Rotate(angleInRadians, Vector3D.AxisZ, pntTarget);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.01);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[1] is Joint)
			{
				Joint joint = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[1] as Joint;
				pntCam.Add(new Pnt9D(joint.Position.X, 0.0 - joint.Position.Y, 0.0, 0.0, 0.0, pntCamCenter.C));
			}
			indx++;
			Thread.Sleep(1);
			Application.DoEvents();
		}
	}

	public void CreateCode()
	{
	}

	public void timtic(object sender, EventArgs e)
	{
		rotate();
	}

	public void cmdNew()
	{
		UndoBuffer();
		SewingBase.MainEntityList.Clear();
		SewingBase = new SewingMain();
		clsInit.appSewing.DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		JobUpdate();
	}

	public void cmdConvertToSewingData(EntityList Entities)
	{
		SewingBase = new SewingMain();
		for (int i = 0; i <= Entities.Count - 1; i++)
		{
			if (!(Entities[i].GetType() == typeof(Line)))
			{
				if (Entities[i].GetType() == typeof(Arc))
				{
					buEntity buEntity2 = buEntity.Copy(Entities[i]);
					if (buEntity2 != null)
					{
						buEntity2.Sewing = new SewingInfo();
						buEntity2.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
						buEntity2.Sewing.isStitchDrawing = true;
						SewingBase.MainEntityList.Add(buEntity2);
					}
				}
			}
			else
			{
				buEntity buEntity3 = buEntity.Copy(Entities[i]);
				if (buEntity3 != null)
				{
					buEntity3.Sewing = new SewingInfo();
					buEntity3.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
					buEntity3.Sewing.isStitchDrawing = true;
					SewingBase.MainEntityList.Add(buEntity3);
				}
			}
		}
		doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
	}

	public void cmdChangeStitchLength(List<Entity> selectedEntities, bool ShowDialog = false)
	{
		try
		{
			SewingInfo sewingInfo = null;
			for (int i = 0; i <= selectedEntities.Count - 1; i++)
			{
				if (selectedEntities[i].EntityData != null && selectedEntities[i].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData = selectedEntities[i].EntityData as SewingEntityCustomData;
					if (sewingEntityCustomData.isStitch & (sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1))
					{
						sewingInfo = new SewingInfo(SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing);
						i = selectedEntities.Count;
					}
				}
			}
			if (sewingInfo == null)
			{
				return;
			}
			F_SewingStitchLen f_SewingStitchLen = new F_SewingStitchLen();
			f_SewingStitchLen.StitchLength = sewingInfo.StitchLengt;
			f_SewingStitchLen.Properties.FormCloseMode = FormCloseModeType.Dispose;
			if (ShowDialog)
			{
				f_SewingStitchLen.Init();
				f_SewingStitchLen.ShowDialog();
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				varSewingRunSettings.StitchLen = f_SewingStitchLen.StitchLength;
				okCommandWithThreeDataEventHandler_0("StitchLen", null, null);
				f_SewingStitchLen.StitchLength = varSewingRunSettings.StitchLen;
			}
			if (!((f_SewingStitchLen.Properties.Result == DialogResult.OK || !ShowDialog) & !CancelApplied))
			{
				return;
			}
			UndoBuffer();
			sewingInfo.StitchLengt = f_SewingStitchLen.StitchLength;
			for (int j = 0; j <= selectedEntities.Count - 1; j++)
			{
				if (selectedEntities[j].EntityData != null && selectedEntities[j].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData2 = selectedEntities[j].EntityData as SewingEntityCustomData;
					if ((sewingEntityCustomData2.isStitch & (sewingEntityCustomData2.indexEntity >= 0) & (sewingEntityCustomData2.indexEntity <= SewingBase.MainEntityList.Count - 1)) && sewingInfo.StitchLengt > 0.0)
					{
						SewingBase.MainEntityList[sewingEntityCustomData2.indexEntity].Sewing.StitchLengt = sewingInfo.StitchLengt;
					}
				}
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		}
		catch (Exception)
		{
		}
	}

	public void cmdOffset()
	{
		if (okCommandWithThreeDataEventHandler_0 != null)
		{
			okCommandWithThreeDataEventHandler_0("Offset", null, null);
			clsVar.varEditorRuntimeSet.OffsetValue = varSewingRunSettings.SewingOffset;
		}
		if (!CancelApplied)
		{
			SewingTempVars.DrawType = SewingDrawType.Stitched;
			clsInit.appEditor.action = actionTypeBU.eventOffset;
			if (Sketcher2D.entitiesSelected.Count != 0)
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[33], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = false;
			}
			else
			{
				clsInit.appEditor.StatusUpdate(AppLanguage.CadCamStatus[10], buLangTranslate.preDef.Sewing);
				Sketcher2D.selectionProcess = true;
			}
		}
	}

	public void cmdStitchToJump()
	{
		try
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count > 0)
			{
				UndoBuffer();
			}
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (Sketcher2D.entitiesSelected[i].EntityData != null && Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
					if ((sewingEntityCustomData.isStitch & (sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.isStitchDrawing)
					{
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.isStitchDrawing = false;
					}
				}
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		catch (Exception)
		{
		}
	}

	public void cmdJumpToStitch()
	{
		try
		{
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count > 0)
			{
				UndoBuffer();
			}
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (Sketcher2D.entitiesSelected[i].EntityData != null && Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
					if ((!sewingEntityCustomData.isStitch & (sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1)) && !SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.isStitchDrawing)
					{
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.isStitchDrawing = true;
					}
				}
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		catch (Exception)
		{
		}
	}

	public void cmdSetProperties()
	{
		clsInit.appCommand.Reset(ClearSelection: false);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
		ccVars.Action = actionTypeBU.sewingSetProperties;
		ccVars.stpDrawing = 1;
		ccVars.selectionProcess = false;
	}

	public void cmdShowPoints(bool Visible)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNamePoint)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible = Visible;
			}
		}
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == varSewingSettings.layerNamePoint)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[j].Enable = Visible;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdShowDrawings(bool Visible)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNameDrawing)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible = Visible;
			}
		}
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == varSewingSettings.layerNameDrawing)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[j].Enable = Visible;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdShowDrawingsDevided(bool Visible)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNameDrawingDevided)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible = Visible;
			}
		}
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == varSewingSettings.layerNameDrawingDevided)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[j].Enable = Visible;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdShowDrawingPoints(bool Visible)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNameDrawingPoints)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible = Visible;
			}
		}
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == varSewingSettings.layerNameDrawingPoints)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[j].Enable = Visible;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdShowOriginalDrawings(bool Visible)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNameOriginal)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible = Visible;
			}
		}
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; j++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Layers[j].Name == varSewingSettings.layerNameOriginal)
			{
				ccVars.Pages[ccVars.PageIndex].Layers[j].Enable = Visible;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdAddCodes()
	{
		clsInit.appEditor.action = actionTypeBU.sewingAddCode;
		Sketcher2D.selectionProcess = false;
		clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
	}

	public void cmdSimilationPrevius(int Step)
	{
		simIndex -= Step;
		simIndex -= Step;
		if (simIndex < 0)
		{
			simIndex = 0;
		}
		Sim_Tick(null, null);
	}

	public void cmdSimilationNext(int Step)
	{
		if (Step > 1)
		{
			simIndex += Step - 1;
		}
		if (simIndex > SewingBase.SimilationPoint.SimMove.Count - 1)
		{
			simIndex = SewingBase.SimilationPoint.SimMove.Count - 1;
		}
		Sim_Tick(null, null);
	}

	public void cmdSimilationPause()
	{
		timSim.Enabled = false;
		SimPaused = true;
	}

	public void cmdSimilationStop()
	{
		if (!timSim.Enabled)
		{
			simIndex = -1;
			DeleteSimEntities();
			clsItem.frmEditor.viewport.Invalidate();
		}
		else
		{
			timSim.Enabled = false;
		}
	}

	public void cmdSimilationStart()
	{
		if (!((simIndex > 0) & !timSim.Enabled))
		{
			if (!SimPaused)
			{
				SewingTableList.Clear();
				CreateSewingTableList(Company, Model, ref SewingBase, ref SewingTableList);
				List<Point3D> list = new List<Point3D>();
				for (int i = 0; i <= SewingTableList.Count - 1; i++)
				{
					if (list.Count != 0)
					{
						Point3D point3D = new Point3D(list[list.Count - 1].X, list[list.Count - 1].Y);
						Point3D point3D2 = new Point3D(SewingTableList[i].PositionX, SewingTableList[i].PositionY);
						double num = Point3D.Distance(point3D, point3D2);
						if (!(num > 50.0))
						{
							list.Add(new Point3D(SewingTableList[i].PositionX, SewingTableList[i].PositionY));
							continue;
						}
						List<Point3D> Vertices = new List<Point3D>();
						clsInit.cVector5.LineToLineer(point3D, point3D2, 50.0, ref Vertices);
						for (int j = 1; j <= Vertices.Count - 1; j++)
						{
							list.Add(buVector5.ToPoint3D(Vertices[j]));
						}
					}
					else
					{
						list.Add(new Point3D(SewingTableList[i].PositionX, SewingTableList[i].PositionY));
					}
				}
				SewingBase.SimilationPoint = new SimulationTp();
				for (int k = 0; k <= list.Count - 1; k++)
				{
					Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove();
					pnt6DSimMove = new Pnt6DSimMove(list[k]);
					if (k > 0)
					{
						double c = clsInit.cVector5.PointAngle(list[k], list[k - 1], Plane.XY);
						pnt6DSimMove.C = c;
					}
					SewingBase.SimilationPoint.SimMove.Add(pnt6DSimMove);
				}
				simIndex = 0;
				timSim.Interval = varSewingSettings.SimulationTick;
				timSim.Enabled = true;
			}
			else
			{
				timSim.Enabled = true;
				SimPaused = false;
			}
		}
		else
		{
			timSim.Enabled = true;
		}
	}

	public void cmdShowTable(ref SewingMain sewingBase, ref List<SewingJobItem> sewingTableList)
	{
		if (sewingTableList.Count == 0)
		{
			CreateSewingTableList(Company, Model, ref SewingBase, ref SewingTableList);
		}
		if (frmTable == null)
		{
			frmTable = new F_SewingTable();
		}
		frmTable.SewingTableList.Clear();
		for (int i = 0; i <= sewingTableList.Count - 1; i++)
		{
			frmTable.SewingTableList.Add(new SewingJobItem(sewingTableList[i]));
		}
		frmTable.Properties.FormCloseMode = FormCloseModeType.Invisible;
		frmTable.Init();
		frmTable.ShowDialog();
	}

	public EntityList DrawSewingData(SewingMain SewingData, EntityList EL)
	{
		EL.Clear();
		for (int i = 0; i <= SewingData.MainEntityList.Count - 1; i++)
		{
			Entity copiedEntity = null;
			SewingInfo sewing = SewingData.MainEntityList[i].Sewing;
			SewingDrawType sewingDrawType = SewingDrawType.None;
			if (!sewing.isStitchDrawing)
			{
				buEntity.Copy(SewingData.MainEntityList[i], ref copiedEntity);
				copiedEntity.ColorMethod = colorMethodType.byEntity;
				copiedEntity.Color = varSewingSettings.colorJump;
				copiedEntity.LineWeight = (float)varSewingSettings.thicknessJump;
				copiedEntity.LineWeightMethod = colorMethodType.byEntity;
				sewingDrawType = SewingDrawType.Jump;
			}
			else
			{
				buEntity.Copy(SewingData.MainEntityList[i], ref copiedEntity);
				copiedEntity.ColorMethod = colorMethodType.byEntity;
				copiedEntity.Color = varSewingSettings.colorStitched;
				copiedEntity.LineWeight = (float)varSewingSettings.thicknessStitched;
				copiedEntity.LineWeightMethod = colorMethodType.byEntity;
				sewingDrawType = SewingDrawType.Stitched;
			}
			SewingEntityCustomData sewingEntityCustomData = new SewingEntityCustomData(i, -1, sewing.isStitchDrawing, sewing.StitchLengt, sewingDrawType);
			sewingEntityCustomData.SortDir = SewingData.MainEntityList[i].sortDirection;
			copiedEntity.EntityData = sewingEntityCustomData;
			if (copiedEntity.LayerName != "Default")
			{
				copiedEntity.LayerName = "Default";
			}
			EL.Add(copiedEntity);
			int num = 0;
			int num2 = 0;
			if ((sewing.StartStitchType != SewingAddStitchType.None) & (sewing.StartStitchCount > 0) & sewing.isStitchDrawing & (sewing.Vertex.Count >= 2))
			{
				num = sewing.StartStitchCount;
				double angle = clsInit.cVector5.PointAngle(sewing.Vertex[1].Point, sewing.Vertex[0].Point);
				double length = (double)sewing.StartStitchCount * sewing.StitchLengt;
				Point3D EndPnt = new Point3D();
				clsInit.cVector5.LineWithLengthAndAngle(sewing.Vertex[0].Point, length, angle, ref EndPnt);
				Line line = new Line(sewing.Vertex[0].Point, EndPnt);
				line.ColorMethod = colorMethodType.byEntity;
				line.Color = varSewingSettings.colorLockStitch;
				line.LineWeight = (float)varSewingSettings.thicknessStitched + 2f;
				line.LineWeightMethod = colorMethodType.byEntity;
				SewingEntityCustomData entityData = new SewingEntityCustomData(i, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Extension);
				line.EntityData = entityData;
				EL.Add(line);
			}
			if ((sewing.EndStitchType != SewingAddStitchType.None) & (sewing.EndStitchCount > 0) & sewing.isStitchDrawing & (sewing.Vertex.Count >= 2))
			{
				num2 = sewing.EndStitchCount;
			}
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2 = new List<Point3D>();
			SewingPunteriz sewingPunteriz = null;
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				SewingVertex sewingVertex = sewing.Vertex[j];
				list.Add(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY));
				devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY));
				point.ColorMethod = colorMethodType.byEntity;
				point.Color = varSewingSettings.colorVertex;
				point.LineWeight = (float)varSewingSettings.thicknessVertex + 4f;
				point.LineWeightMethod = colorMethodType.byEntity;
				if (num > 0 && j <= num)
				{
					point.Color = varSewingSettings.colorLockStitch;
					point.LineWeight += 3f;
				}
				if ((num2 > 0) & (j >= sewing.Vertex.Count - num2 - 1))
				{
					point.Color = varSewingSettings.colorLockStitch;
					point.LineWeight += 3f;
				}
				sewingEntityCustomData = new SewingEntityCustomData(i, j, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.VertexPoint);
				if (sewing.Vertex[j].Punterez != null)
				{
					sewingPunteriz = new SewingPunteriz(sewing.Vertex[j].Punterez);
					StartMiddleEndType startMiddleEndType = StartMiddleEndType.Middle;
					SewingPunteriz punterez = sewing.Vertex[j].Punterez;
					bool flag = false;
					if (j != SewingData.MainEntityList[i].Sewing.Vertex.Count - 1)
					{
						if (j != 0)
						{
							punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[j + 1].Point, sewing.Vertex[j].Point);
							startMiddleEndType = StartMiddleEndType.Middle;
							flag = true;
						}
						else
						{
							punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[j + 1].Point, sewing.Vertex[j].Point);
							startMiddleEndType = StartMiddleEndType.Start;
						}
					}
					else
					{
						punterez.Angle = clsInit.cVector5.PointAngle(sewing.Vertex[j - 1].Point, sewing.Vertex[j].Point);
						startMiddleEndType = StartMiddleEndType.End;
					}
					sewingEntityCustomData.Punteriz = new SewingPunteriz(punterez);
					List<Point3D> calcPoints = new List<Point3D>();
					doPunteriz(sewing.Vertex[j].Point, punterez.Length, punterez.Width, punterez.Height, punterez.Angle, punterez.PunterizType, ref calcPoints);
					if (!(punterez.PunterizMethod == SewingPunterizMethod.StitchThenPunteriz && !flag))
					{
						List<Point3D> PointsDevided = new List<Point3D>();
						clsInit.cVector5.DevidePointsByLength(calcPoints, sewing.StitchLengt, ref PointsDevided);
						LinearPath linearPath = new LinearPath(PointsDevided);
						linearPath.ColorMethod = colorMethodType.byEntity;
						linearPath.Color = varSewingSettings.colorPunterez;
						linearPath.LineWeight = (float)varSewingSettings.thicknessStitched + 2f;
						linearPath.LineWeightMethod = colorMethodType.byEntity;
						SewingEntityCustomData entityData2 = new SewingEntityCustomData(i, j, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Punteriz);
						linearPath.EntityData = entityData2;
						EL.Add(linearPath);
					}
					else if (startMiddleEndType == StartMiddleEndType.End || startMiddleEndType == StartMiddleEndType.Start)
					{
						List<Point3D> PointsDevided2 = new List<Point3D>();
						calcPoints.Reverse();
						calcPoints.Insert(0, buVector5.ToPoint3D(calcPoints[calcPoints.Count - 1]));
						clsInit.cVector5.DevidePointsByLength(calcPoints, sewing.StitchLengt, ref PointsDevided2);
						LinearPath linearPath2 = new LinearPath(PointsDevided2);
						linearPath2.ColorMethod = colorMethodType.byEntity;
						linearPath2.Color = varSewingSettings.colorPunterez;
						linearPath2.LineWeight = (float)varSewingSettings.thicknessStitched + 2f;
						linearPath2.LineWeightMethod = colorMethodType.byEntity;
						SewingEntityCustomData entityData3 = new SewingEntityCustomData(i, j, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Punteriz);
						linearPath2.EntityData = entityData3;
						EL.Add(linearPath2);
					}
				}
				point.EntityData = sewingEntityCustomData;
				EL.Add(point);
				if (sewingVertex.Codes.Count > 0)
				{
					for (int k = 0; k <= sewingVertex.Codes.Count - 1; k++)
					{
						double z = (double)k * sewing.StitchLengt * 1.5;
						Joint joint = new Joint(new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY, z), sewing.StitchLengt * 0.5, 2);
						joint.Regen(0.1);
						joint.ColorMethod = colorMethodType.byEntity;
						joint.Color = varSewingSettings.colorVertexHasCode;
						joint.LineWeight = (float)varSewingSettings.thicknessVertex + 4f;
						joint.LineWeightMethod = colorMethodType.byEntity;
						EL.Add(joint);
					}
				}
			}
			if (list2.Count > 1)
			{
				int num3 = -1;
				int num4 = -1;
				double num5 = 9999999.0;
				double num6 = 9999999.0;
				for (int l = 0; l <= sewing.Vertex.Count - 1; l++)
				{
					double num7 = Point3D.Distance(sewing.Vertex[l].Point, list2[0]);
					if (num7 < num5)
					{
						num3 = l;
						num5 = num7;
					}
					double num8 = Point3D.Distance(sewing.Vertex[l].Point, list2[list2.Count - 1]);
					if (num8 < num6)
					{
						num4 = l;
						num6 = num8;
					}
				}
				if (num3 == -1)
				{
					double num9 = 9999999.0;
					for (int m = 0; m <= sewing.Vertex.Count - 1; m++)
					{
						double num10 = Point3D.Distance(sewing.Vertex[m].Point, list2[0]);
						if (num10 < num9)
						{
							num9 = num10;
							num3 = m;
						}
					}
				}
				if (num4 == -1)
				{
					double num11 = 9999999.0;
					for (int n = 0; n <= sewing.Vertex.Count - 1; n++)
					{
						double num12 = Point3D.Distance(sewing.Vertex[n].Point, list2[list2.Count - 1]);
						if (num12 < num11)
						{
							num11 = num12;
							num4 = n;
						}
					}
				}
				if (num3 >= 0 && num4 >= 0 && num3 != num4)
				{
					sewing.Vertex.RemoveRange(num3, num4 - num3 + 1);
					for (int num13 = 0; num13 <= list2.Count - 1; num13++)
					{
						SewingVertex item = new SewingVertex(list2[num13]);
						sewing.Vertex.Insert(num3 + num13, item);
					}
					if (sewingPunteriz != null)
					{
						sewing.Vertex[num3].Punterez = new SewingPunteriz(sewingPunteriz);
					}
					list.Clear();
					list = new List<Point3D>();
					for (int num14 = 0; num14 <= sewing.Vertex.Count - 1; num14++)
					{
						SewingVertex sewingVertex2 = sewing.Vertex[num14];
						list.Add(new Point3D(sewingVertex2.Point.X + sewingVertex2.DeltaX, sewingVertex2.Point.Y + sewingVertex2.DeltaY));
					}
				}
			}
			if (sewing.isStitchDrawing)
			{
				LinearPath linearPath3 = new LinearPath(list);
				linearPath3.ColorMethod = colorMethodType.byEntity;
				linearPath3.Color = varSewingSettings.colorStitched;
				linearPath3.LineWeight = (float)varSewingSettings.thicknessStitched;
				linearPath3.LineWeightMethod = colorMethodType.byEntity;
				sewingEntityCustomData = new SewingEntityCustomData(i, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.VertexPoint);
				sewingEntityCustomData.SortDir = SewingData.MainEntityList[i].sortDirection;
				linearPath3.EntityData = sewingEntityCustomData;
				EL.Add(linearPath3);
			}
			if ((sewing.EndStitchType != SewingAddStitchType.None) & (sewing.EndStitchCount > 0) & sewing.isStitchDrawing & (sewing.Vertex.Count >= 2))
			{
				double angle2 = clsInit.cVector5.PointAngle(sewing.Vertex[sewing.Vertex.Count - 2].Point, sewing.Vertex[sewing.Vertex.Count - 1].Point);
				double length2 = (double)sewing.EndStitchCount * sewing.StitchLengt;
				Point3D EndPnt2 = new Point3D();
				clsInit.cVector5.LineWithLengthAndAngle(sewing.Vertex[sewing.Vertex.Count - 1].Point, length2, angle2, ref EndPnt2);
				Line line2 = new Line(sewing.Vertex[sewing.Vertex.Count - 1].Point, EndPnt2);
				line2.ColorMethod = colorMethodType.byEntity;
				line2.Color = varSewingSettings.colorLockStitch;
				line2.LineWeight = (float)varSewingSettings.thicknessStitched + 2f;
				line2.LineWeightMethod = colorMethodType.byEntity;
				SewingEntityCustomData entityData4 = new SewingEntityCustomData(i, -1, sewing.isStitchDrawing, sewing.StitchLengt, SewingDrawType.Extension);
				line2.EntityData = entityData4;
				EL.Add(line2);
			}
		}
		if (clsItem.frmEditor.viewport != null)
		{
			clsItem.frmEditor.viewport.Invalidate();
		}
		return EL;
	}

	public void DrawSewingTempEntities(List<Entity> tempEntities, ViewportRefType ViewType)
	{
		Design design = null;
		if (ViewType == ViewportRefType.Editor)
		{
			design = clsItem.frmEditor.viewport;
		}
		if (ViewType == ViewportRefType.Main)
		{
			design = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
		}
		design.TempEntities.Clear();
		for (int i = 0; i <= tempEntities.Count - 1; i++)
		{
			Entity copiedEntity = null;
			buEntity.Copy(tempEntities[i], ref copiedEntity);
			design.TempEntities.Add(copiedEntity);
		}
		design.Invalidate();
	}

	public void AddLineJump(Point3D start, Point3D end)
	{
		UndoBuffer();
		buLine buLine2 = new buLine(start, end);
		buLine2.Sewing = new SewingInfo();
		buLine2.Sewing.isStitchDrawing = false;
		buLine2.Sewing.Vertex.Add(new SewingVertex(start));
		buLine2.Sewing.Vertex.Add(new SewingVertex(end));
		SewingBase.MainEntityList.Add(buLine2);
	}

	public void AddLineStitch(Point3D start, Point3D end)
	{
		UndoBuffer();
		buLine buLine2 = new buLine(start, end);
		buLine2.Sewing = new SewingInfo();
		buLine2.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
		buLine2.Sewing.isStitchDrawing = true;
		buLine2.Sewing.Vertex.Add(new SewingVertex(start));
		buLine2.Sewing.Vertex.Add(new SewingVertex(end));
		SewingBase.MainEntityList.Add(buLine2);
		doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
	}

	public void AddArcStitch(Point3D start, Point3D middle, Point3D end, bool flip)
	{
		UndoBuffer();
		buArc buArc2 = new buArc(start, middle, end, flip);
		buArc2.Sewing = new SewingInfo();
		buArc2.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
		buArc2.Sewing.isStitchDrawing = true;
		buArc2.Sewing.Vertex.Add(new SewingVertex(start));
		buArc2.Sewing.Vertex.Add(new SewingVertex(end));
		SewingBase.MainEntityList.Add(buArc2);
		doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
	}

	public void AddCircleStitch(Point3D start, Point3D middle, Point3D end)
	{
		UndoBuffer();
		buCircle buCircle2 = new buCircle(start, middle, end);
		buCircle2.Sewing = new SewingInfo();
		buCircle2.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
		buCircle2.Sewing.isStitchDrawing = true;
		buCircle2.Sewing.Vertex.Add(new SewingVertex(start));
		buCircle2.Sewing.Vertex.Add(new SewingVertex(end));
		SewingBase.MainEntityList.Add(buCircle2);
		doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buSewing.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buSewing.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Sewing Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Profile Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingCommands);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<MainForm>", "</MainForm>", StringList), clsVar.varRuntime.Language, ref buSewingCalc.LangSewingMainForm);
				StringList.Clear();
			}
			if (list.Count <= 0)
			{
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenTeachFile(string FileName, ref SewingMain SewingData)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			TextReader textReader = File.OpenText(FileName);
			string text = "";
			while ((text = textReader.ReadLine()) != null)
			{
				arrayList.Add(text);
			}
			textReader.Close();
			List<List<string>> CalcList = new List<List<string>>();
			buString5.ListToSpecificList("<SewingJobItem>", "</SewingJobItem>", AddStartEndKey: true, arrayList, ref CalcList);
			SewingData.MainEntityList.Clear();
			OpenSewingJobFile(FileName, ref SewingData);
		}
		catch (Exception)
		{
		}
	}

	public void OpenSewingJobFile(string FileName, ref SewingMain SewingData)
	{
		try
		{
			FileInfo fileInfo = new FileInfo(FileName);
			if (!fileInfo.Exists)
			{
				return;
			}
			List<string> StringList = new List<string>();
			buFile5.OpenFromFile(FileName, ref StringList);
			List<List<string>> CalcList = new List<List<string>>();
			buString5.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, StringList, ref CalcList);
			if (CalcList.Count > 0)
			{
				UndoList.Clear();
				SewingData.MainEntityList.Clear();
				SewingData.MainEntityList = new List<buEntity>();
			}
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				buEntity refEntity = null;
				buEntity.Decode(CalcList[i], ref refEntity);
				if (refEntity != null)
				{
					SewingData.MainEntityList.Add(refEntity);
				}
			}
		}
		catch (Exception)
		{
		}
	}

	public void SaveSewingFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Sewing.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Sewing Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<varSewingSettings>");
			arrayList.AddRange(varSewingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varSewingSettings>");
			arrayList.Add("<varSewingRunSettings>");
			arrayList.AddRange(varSewingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</varSewingRunSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("EditSewingor Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenSewingFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Sewing.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Door Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Door Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<varSewingSettings>", "</varSewingSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varSewingSettings);
						buLog.addLog("varSewingSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varSewingRunSettings>", "</varSewingRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varSewingRunSettings);
						buLog.addLog("varSewingRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Sewing Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Editor Settings Decoder Error");
				}
			}
			buLog.addLog("Door Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
		}
		catch (Exception mSException2)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
		if (SewingBase.SimilationPoint.SimMove.Count <= 0)
		{
			simIndex = -1;
			timSim.Enabled = false;
			DeleteSimEntities();
		}
		else if (!((simIndex >= 0) & (simIndex <= SewingBase.SimilationPoint.SimMove.Count - 1)))
		{
			simIndex = -1;
			timSim.Enabled = false;
			DeleteSimEntities();
		}
		else if (clsItem.frmEditor.viewport.Entities.Count > 0)
		{
			DeleteSimEntities();
			Pnt6DSimMove pnt6DSimMove = SewingBase.SimilationPoint.SimMove[simIndex];
			List<Point3D> list = new List<Point3D>();
			list.Add(new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X + 20.0, pnt6DSimMove.Y + 5.0, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X + 20.0, pnt6DSimMove.Y - 5.0, 0.0));
			list.Add(new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			LinearPath linearPath = new LinearPath(list);
			if (varSewingSettings.SimulationRotate)
			{
				linearPath.Rotate(buConversion5.DegreeToRadian(pnt6DSimMove.C + 180.0), Vector3D.AxisZ, new Point3D(pnt6DSimMove.X, pnt6DSimMove.Y, 0.0));
			}
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(linearPath, Plane.XY, true);
			Mesh mesh = region.ExtrudeAsMesh(1.0, 0.1, Mesh.natureType.RichSmooth);
			mesh.Color = Color.FromArgb(varSewingSettings.SimulationTransparency, varSewingSettings.colorSimulation);
			mesh.ColorMethod = colorMethodType.byEntity;
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Tool;
			mesh.EntityData = customData;
			linearPath.EntityData = customData;
			if (!varSewingSettings.SimulationSolid)
			{
				clsItem.frmEditor.viewport.Entities.Add(linearPath);
			}
			else
			{
				clsItem.frmEditor.viewport.Entities.Add(mesh);
			}
			simIndex += varSewingSettings.SimulationStep;
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void DeleteTempEntities()
	{
		if (clsItem.frmEditor == null)
		{
			return;
		}
		for (int i = 0; i <= clsItem.frmEditor.viewport.Entities.Count - 1; i++)
		{
			Entity entity = clsItem.frmEditor.viewport.Entities[i];
			entity.Selected = false;
			if (entity.EntityData != null && entity.EntityData is CustomData && ((CustomData)entity.EntityData).typeDefination == entityTypeDefination.Temp)
			{
				entity.Selected = true;
			}
		}
		clsItem.frmEditor.viewport.Entities.DeleteSelected();
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void DeleteSimEntities()
	{
		if (clsItem.frmEditor.viewport.Entities.Count <= 0)
		{
			return;
		}
		Entity entity = clsItem.frmEditor.viewport.Entities[clsItem.frmEditor.viewport.Entities.Count - 1];
		if ((entity.EntityData != null) & (entity.EntityData is CustomData))
		{
			CustomData customData = entity.EntityData as CustomData;
			if (customData.typeDefination == entityTypeDefination.Tool)
			{
				clsItem.frmEditor.viewport.Entities.RemoveAt(clsItem.frmEditor.viewport.Entities.Count - 1);
			}
		}
	}

	public void CreateTempCircle(Point3D Center, double Radius, Color Clr, bool DrawCircle, ref Entity tempEntity)
	{
		ccVars.DrawCircle.Clear();
		if ((Radius > 0.0) & (Center != null))
		{
			Circle outer = new Circle(Center, Radius);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(outer);
			tempEntity = region.ExtrudeAsMesh(1.0, 0.05, Mesh.natureType.RichSmooth);
			tempEntity.Color = Clr;
			tempEntity.ColorMethod = colorMethodType.byEntity;
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Temp;
			tempEntity.EntityData = customData;
			if (DrawCircle)
			{
				ccVars.DrawCircle.Add(new buCircle(Center, 10.0));
			}
		}
	}

	public void OpenSewingFile(string FileName)
	{
		FileInfo fileInfo = new FileInfo(FileName);
		if (!fileInfo.Exists)
		{
			return;
		}
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(FileName, ref StringList);
		List<List<string>> CalcList = new List<List<string>>();
		buString5.ListToSpecificList("<buEntity>", "</buEntity>", AddStartEndKey: false, StringList, ref CalcList);
		if (CalcList.Count > 0)
		{
			SewingBase.MainEntityList.Clear();
			SewingBase.MainEntityList = new List<buEntity>();
			if (ccVars.Pages.Count > 0)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			}
		}
		for (int i = 0; i <= CalcList.Count - 1; i++)
		{
			buEntity refEntity = null;
			buEntity.Decode(CalcList[i], ref refEntity);
			if (refEntity != null)
			{
				SewingBase.MainEntityList.Add(refEntity);
			}
		}
		new List<Entity>();
		if (ccVars.Pages.Count > 0)
		{
			doDrawMainEntities(SewingBase.MainEntityList, AutoConnect: true);
		}
	}

	public void OpenCamTable(string FileName, double Length)
	{
		List<string> StringList = new List<string>();
		buFile5.OpenFromFile(FileName, ref StringList);
		List<LengthAngle> list = new List<LengthAngle>();
		for (int i = 0; i <= StringList.Count - 1; i++)
		{
			string[] array = StringList[i].Split(';');
			if ((array != null) & (array.Length >= 2))
			{
				LengthAngle lengthAngle = new LengthAngle();
				lengthAngle.Angle = double.Parse(array[0]) * 6.0;
				lengthAngle.Length = double.Parse(array[1]);
				list.Add(lengthAngle);
			}
		}
		if (list.Count > 0)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			List<Point3D> list2 = new List<Point3D>();
			for (int j = 0; j <= list.Count - 1; j++)
			{
				Point3D EndPnt = new Point3D();
				clsInit.cVector5.LineWithLengthAndAngle(new Point3D(), list[j].Length + Length, list[j].Angle, ref EndPnt);
				list2.Add(EndPnt);
				ccVars.UndoDont = true;
				Line line = new Line(new Point3D(), EndPnt);
				line.Color = Color.Lime;
				line.ColorMethod = colorMethodType.byEntity;
				clsInit.appCommand.AddLine(line);
			}
			if (list2.Count >= 2)
			{
				LinearPath linearPath = new LinearPath(list2);
				linearPath.Color = Color.Red;
				linearPath.ColorMethod = colorMethodType.byEntity;
				clsInit.appCommand.AddPolyline(linearPath);
			}
		}
	}

	public bool isPointLayerVisible()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Name == varSewingSettings.layerNamePoint)
			{
				return ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i].Visible;
			}
		}
		return true;
	}

	public void MoveNeighboorOfVertex(ref List<buEntity> MainEntity, int EntityIndex, int VertexIndex, Point3D pntRef, double dX, double dY)
	{
		for (int i = 0; i <= MainEntity.Count - 1; i++)
		{
			if (i == EntityIndex)
			{
				continue;
			}
			if (buCompare5.EQ(pntRef, MainEntity[i].StartPoint, 0.01))
			{
				MainEntity[i].StartPoint.X += dX;
				MainEntity[i].StartPoint.Y += dY;
				MainEntity[i].Update(buEntityUpdateType.None);
			}
			if (buCompare5.EQ(pntRef, MainEntity[i].EndPoint, 0.01))
			{
				MainEntity[i].EndPoint.X += dX;
				MainEntity[i].EndPoint.Y += dY;
				MainEntity[i].Update(buEntityUpdateType.None);
			}
			for (int j = 0; j <= MainEntity[i].Sewing.Vertex.Count - 1; j++)
			{
				Point3D point = MainEntity[i].Sewing.Vertex[j].Point;
				if (buCompare5.EQ(pntRef, point, 0.01))
				{
					MainEntity[i].Sewing.Vertex[j].Point.X += dX;
					MainEntity[i].Sewing.Vertex[j].Point.Y += dY;
				}
			}
		}
	}

	public void MoveMainEntity(ref List<buEntity> MainEntity, int EntityIndex, int VertexIndex, Point3D pntRef, double dX, double dY)
	{
		for (int i = 0; i <= MainEntity.Count - 1; i++)
		{
			if (i == EntityIndex)
			{
				double num = 0.0;
				double num2 = 0.0;
				if (MainEntity[i].Sewing.Vertex.Count > 0)
				{
					num = MainEntity[i].Sewing.Vertex[0].DeltaX;
					num2 = MainEntity[i].Sewing.Vertex[0].DeltaY;
				}
				Point3D value = new Point3D(MainEntity[i].StartPoint.X + num, MainEntity[i].StartPoint.Y + num2);
				if (buCompare5.EQ(pntRef, value, 0.01))
				{
					MainEntity[i].StartPoint.X += dX;
					MainEntity[i].StartPoint.Y += dY;
					MainEntity[i].Update(buEntityUpdateType.None);
				}
				if (MainEntity[i].Sewing.Vertex.Count > 0)
				{
					num = MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaX;
					num2 = MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaY;
				}
				value = new Point3D(MainEntity[i].EndPoint.X + num, MainEntity[i].EndPoint.Y + num2);
				if (buCompare5.EQ(pntRef, value, 0.01))
				{
					MainEntity[i].EndPoint.X += dX;
					MainEntity[i].EndPoint.Y += dY;
					MainEntity[i].Update(buEntityUpdateType.None);
				}
			}
		}
	}

	public void MoveCommand(object Axis, object MoveDis)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = Convert.ToDouble(MoveDis.ToString());
		if (Axis.ToString() == "X")
		{
			num = num3;
		}
		if (Axis.ToString() == "Y")
		{
			num2 = num3;
		}
		varSewingRunSettings.MoveDistance = num3;
		if (clsInit.appEditor.action == actionTypeBU.sewingScale && Selected.Count > 0)
		{
			UndoBuffer();
			for (int i = 0; i <= Selected.Count - 1; i++)
			{
				if (Selected[i].EntityIndex < 0)
				{
					continue;
				}
				Point3D point3D = new Point3D();
				if (Selected[i].CatchPosition == StartMiddleEndType.Start)
				{
					point3D.X = SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.X;
					point3D.Y = SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.Y;
					if (Axis.ToString() == "AnglePlus")
					{
						double degree = 180.0 + clsInit.cVector5.PointAngle(SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint, SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint);
						num = Math.Abs(num3) * Math.Cos(buConversion5.DegreeToRadian(degree));
						num2 = Math.Abs(num3) * Math.Sin(buConversion5.DegreeToRadian(degree));
					}
					if (Axis.ToString() == "AngleMinus")
					{
						double degree2 = clsInit.cVector5.PointAngle(SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint, SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint);
						num = Math.Abs(num3) * Math.Cos(buConversion5.DegreeToRadian(degree2));
						num2 = Math.Abs(num3) * Math.Sin(buConversion5.DegreeToRadian(degree2));
					}
					SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.X = SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.X + num;
					SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.Y = SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.Y + num2;
				}
				if (Selected[i].CatchPosition == StartMiddleEndType.End)
				{
					point3D.X = SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.X;
					point3D.Y = SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.Y;
					if (Axis.ToString() == "AnglePlus")
					{
						double degree3 = 180.0 + clsInit.cVector5.PointAngle(SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint, SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint);
						num = Math.Abs(num3) * Math.Cos(buConversion5.DegreeToRadian(degree3));
						num2 = Math.Abs(num3) * Math.Sin(buConversion5.DegreeToRadian(degree3));
					}
					if (Axis.ToString() == "AngleMinus")
					{
						double degree4 = clsInit.cVector5.PointAngle(SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint, SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint);
						num = Math.Abs(num3) * Math.Cos(buConversion5.DegreeToRadian(degree4));
						num2 = Math.Abs(num3) * Math.Sin(buConversion5.DegreeToRadian(degree4));
					}
					SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.X = SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.X + num;
					SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.Y = SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.Y + num2;
				}
				if (SewingBase.MainEntityList[Selected[i].EntityIndex] is buLine)
				{
					SewingBase.MainEntityList[Selected[i].EntityIndex].Update(buEntityUpdateType.Line);
				}
				if (SewingBase.MainEntityList[Selected[i].EntityIndex] is buArc)
				{
					SewingBase.MainEntityList[Selected[i].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
				}
				MoveTouchEntities(Selected[i].EntityIndex, point3D, num, num2);
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			SaveSewingFile();
		}
		if (clsInit.appEditor.action == actionTypeBU.sewingMove && Selected.Count > 0)
		{
			UndoBuffer();
			for (int j = 0; j <= Selected.Count - 1; j++)
			{
				Point3D point3D2 = new Point3D();
				Point3D point3D3 = new Point3D();
				if (Selected[j].EntityIndex >= 0)
				{
					point3D2.X = SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.X;
					point3D2.Y = SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.Y;
					point3D3.X = SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.X;
					point3D3.Y = SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.Y;
					SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.X = SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.X + num;
					SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.X = SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.X + num;
					SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.Y = SewingBase.MainEntityList[Selected[j].EntityIndex].StartPoint.Y + num2;
					SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.Y = SewingBase.MainEntityList[Selected[j].EntityIndex].EndPoint.Y + num2;
					if (SewingBase.MainEntityList[Selected[j].EntityIndex] is buLine)
					{
						SewingBase.MainEntityList[Selected[j].EntityIndex].Update(buEntityUpdateType.Line);
					}
					if (SewingBase.MainEntityList[Selected[j].EntityIndex] is buArc)
					{
						SewingBase.MainEntityList[Selected[j].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
					}
					MoveTouchEntities(Selected[j].EntityIndex, point3D2, num, num2);
					MoveTouchEntities(Selected[j].EntityIndex, point3D3, num, num2);
				}
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			SaveSewingFile();
		}
		if (clsInit.appEditor.action != actionTypeBU.sewingMoveVertex)
		{
			return;
		}
		if (Selected.Count > 0)
		{
			UndoBuffer();
			bool flag = false;
			for (int k = 0; k <= Selected.Count - 1; k++)
			{
				Point3D point3D4 = new Point3D();
				bool flag2 = false;
				if ((Selected[k].EntityIndex >= 0) & (Selected[k].EntityIndex <= SewingBase.MainEntityList.Count - 1))
				{
					flag2 = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.isStitchDrawing;
				}
				if (!(varSewingSettings.VertexMoveType == MoveVertexType.MoveCorner || !flag2))
				{
					if (Selected[k].EntityIndex < 0)
					{
						continue;
					}
					for (int l = 0; l <= SewingBase.MainEntityList.Count - 1; l++)
					{
						for (int m = 0; m <= SewingBase.MainEntityList[l].Sewing.Vertex.Count - 1; m++)
						{
							Point3D point = SewingBase.MainEntityList[l].Sewing.Vertex[m].Point;
							if (buCompare5.EQ(point.X, Selected[k].refPoint.X) & buCompare5.EQ(point.Y, Selected[k].refPoint.Y))
							{
								point.X += num;
								point.Y += num2;
							}
						}
					}
					Selected[k].refPoint.X = Selected[k].refPoint.X + num;
					Selected[k].refPoint.Y = Selected[k].refPoint.Y + num2;
				}
				else
				{
					if (Selected[k].EntityIndex < 0)
					{
						continue;
					}
					if (!((Selected[k].CatchPosition == StartMiddleEndType.Start) | (Selected[k].CatchPosition == StartMiddleEndType.End)))
					{
						if (Selected[k].VertexIndex <= SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex.Count - 1)
						{
							point3D4.X = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].Point.X + SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaX;
							point3D4.Y = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].Point.Y + SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaY;
							SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaX = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaX + num;
							Selected[k].refPoint.X = Selected[k].refPoint.X + num;
							SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaY = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].DeltaY + num2;
							Selected[k].refPoint.Y = Selected[k].refPoint.Y + num2;
						}
					}
					else
					{
						int index = 0;
						if (Selected[k].CatchPosition == StartMiddleEndType.Start)
						{
							index = 0;
						}
						if (Selected[k].CatchPosition == StartMiddleEndType.End)
						{
							index = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex.Count - 1;
						}
						point3D4.X = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.X + SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].DeltaX;
						point3D4.Y = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.Y + SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].DeltaY;
						bool flag3 = false;
						flag = true;
						if (buCompare5.EQ(Selected[k].refPoint, point3D4))
						{
							SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.X = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.X + num;
							SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.Y = SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[index].Point.Y + num2;
						}
						if (!buCompare5.EQ(Selected[k].refPoint, SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint))
						{
							if (buCompare5.EQ(Selected[k].refPoint, SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint))
							{
								SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint.X = SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint.X + num;
								SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint.Y = SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint.Y + num2;
								flag3 = true;
							}
						}
						else
						{
							SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint.X = SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint.X + num;
							SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint.Y = SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint.Y + num2;
							flag3 = true;
						}
						if (flag3)
						{
							Selected[k].refPoint.X = Selected[k].refPoint.X + num;
							Selected[k].refPoint.Y = Selected[k].refPoint.Y + num2;
							if (SewingBase.MainEntityList[Selected[k].EntityIndex] is buLine)
							{
								SewingBase.MainEntityList[Selected[k].EntityIndex].Update(buEntityUpdateType.Line);
							}
							if (SewingBase.MainEntityList[Selected[k].EntityIndex] is buArc)
							{
								SewingBase.MainEntityList[Selected[k].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
							}
						}
					}
					MoveTouchEntities(Selected[k].EntityIndex, point3D4, num, num2);
				}
			}
			if (varSewingSettings.VertexMoveType == MoveVertexType.MoveCorner && flag)
			{
				doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			}
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			Sketcher2D.selectedCircle.Clear();
			for (int n = 0; n <= Selected.Count - 1; n++)
			{
				Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(Selected[n].refPoint), 0.8);
				circle.Color = Color.Cyan;
				Sketcher2D.selectedCircle.Add(circle);
			}
		}
		SaveSewingFile();
	}

	public void SelectVertexCommand(object Command, object Val, object ShowDialog)
	{
		if (!(Command.ToString() == "Ok"))
		{
			if (!((baseSelected.EntityIndex >= 0) & (baseSelected.EntityIndex <= SewingBase.MainEntityList.Count - 1)) || SewingBase.MainEntityList[baseSelected.EntityIndex].Sewing == null)
			{
				return;
			}
			SewingInfo sewing = SewingBase.MainEntityList[baseSelected.EntityIndex].Sewing;
			if ((Selected[Selected.Count - 1].VertexIndex >= 0) & (Selected[Selected.Count - 1].VertexIndex <= sewing.Vertex.Count - 1))
			{
				if (Command.ToString() == "Minus")
				{
					if (Selected.Count != 1)
					{
						if (Selected.Count > 1)
						{
							if (Selected[Selected.Count - 1].VertexIndex >= Selected[Selected.Count - 2].VertexIndex)
							{
								Selected.RemoveAt(Selected.Count - 1);
							}
							else
							{
								SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint(Selected[Selected.Count - 1]);
								if (sewingSelectedPoint.VertexIndex > 0)
								{
									sewingSelectedPoint.VertexIndex--;
									sewingSelectedPoint.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint.VertexIndex].DeltaY);
									Selected.Add(sewingSelectedPoint);
								}
							}
						}
					}
					else if (Selected[Selected.Count - 1].VertexIndex > 0)
					{
						SewingSelectedPoint sewingSelectedPoint2 = new SewingSelectedPoint(Selected[Selected.Count - 1]);
						if (sewingSelectedPoint2.VertexIndex > 0)
						{
							sewingSelectedPoint2.VertexIndex--;
							sewingSelectedPoint2.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint2.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint2.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint2.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint2.VertexIndex].DeltaY);
							Selected.Add(sewingSelectedPoint2);
						}
					}
				}
				if (Command.ToString() == "Plus")
				{
					if (Selected.Count != 1)
					{
						if (Selected.Count > 1)
						{
							if (Selected[Selected.Count - 1].VertexIndex <= Selected[Selected.Count - 2].VertexIndex)
							{
								Selected.RemoveAt(Selected.Count - 1);
							}
							else
							{
								SewingSelectedPoint sewingSelectedPoint3 = new SewingSelectedPoint(Selected[Selected.Count - 1]);
								if (sewingSelectedPoint3.VertexIndex < sewing.Vertex.Count - 1)
								{
									sewingSelectedPoint3.VertexIndex++;
									sewingSelectedPoint3.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint3.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint3.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint3.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint3.VertexIndex].DeltaY);
									Selected.Add(sewingSelectedPoint3);
								}
							}
						}
					}
					else if (Selected[Selected.Count - 1].VertexIndex < sewing.Vertex.Count - 1)
					{
						SewingSelectedPoint sewingSelectedPoint4 = new SewingSelectedPoint(Selected[Selected.Count - 1]);
						if (sewingSelectedPoint4.VertexIndex < sewing.Vertex.Count - 1)
						{
							sewingSelectedPoint4.VertexIndex++;
							sewingSelectedPoint4.refPoint = new Point3D(sewing.Vertex[sewingSelectedPoint4.VertexIndex].Point.X + sewing.Vertex[sewingSelectedPoint4.VertexIndex].DeltaX, sewing.Vertex[sewingSelectedPoint4.VertexIndex].Point.Y + sewing.Vertex[sewingSelectedPoint4.VertexIndex].DeltaY);
							Selected.Add(sewingSelectedPoint4);
						}
					}
				}
			}
			Sketcher2D.selectedCircle.Clear();
			for (int i = 0; i <= Selected.Count - 1; i++)
			{
				Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(Selected[i].refPoint), 0.8);
				circle.Color = Color.Cyan;
				Sketcher2D.selectedCircle.Add(circle);
			}
			clsItem.frmEditor.viewport.Invalidate();
			return;
		}
		if (frmSelectVertex != null)
		{
			frmSelectVertex.Visible = false;
		}
		if (clsInit.appEditor.action == actionTypeBU.sewingMoveVertex)
		{
			if (frmMove == null)
			{
				frmMove = new F_SewingMove();
				frmMove.MoveCommad += MoveCommand;
				frmMove.CancelCommad += MoveCancel;
			}
			if (varSewingRunSettings.MoveDistance <= 0.0)
			{
				varSewingRunSettings.MoveDistance = 1.0;
			}
			frmMove.MoveDis = varSewingRunSettings.MoveDistance;
			frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
			frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
			frmMove.Properties.TopMost = true;
			frmMove.btn_anglePlus.Visible = false;
			frmMove.btn_angleMinus.Visible = false;
			frmMove.Init();
			frmMove.Show();
		}
		if (clsInit.appEditor.action == actionTypeBU.sewingFootHeight)
		{
			if (frmFootHeight == null)
			{
				frmFootHeight = new F_SewingFootHeight();
			}
			if (varSewingRunSettings.FootHeight < 0.0)
			{
				varSewingRunSettings.FootHeight = 10.0;
			}
			if (Selected.Count > 0)
			{
				varSewingRunSettings.FootHeight = SewingBase.MainEntityList[Selected[0].EntityIndex].Sewing.Vertex[Selected[0].VertexIndex].FootHeight;
				frmFootHeight.FootHeight = varSewingRunSettings.FootHeight;
				frmFootHeight.Properties.FormCloseMode = FormCloseModeType.Invisible;
				frmFootHeight.Properties.FormPosition = FormStartPosition.CenterScreen;
				frmFootHeight.Properties.TopMost = true;
				if ((bool)ShowDialog)
				{
					frmFootHeight.Init();
					frmFootHeight.ShowDialog();
				}
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					okCommandWithThreeDataEventHandler_0("FootHeight", null, null);
					frmFootHeight.FootHeight = varSewingRunSettings.FootHeight;
				}
				if (((frmFootHeight.Properties.Result == DialogResult.OK) | !(bool)ShowDialog) & !CancelApplied)
				{
					for (int j = 0; j <= Selected.Count - 1; j++)
					{
						SewingBase.MainEntityList[Selected[j].EntityIndex].Sewing.Vertex[Selected[j].VertexIndex].FootHeight = frmFootHeight.FootHeight;
					}
					varSewingRunSettings.FootHeight = frmFootHeight.FootHeight;
				}
				clsInit.appEditor.Reset();
			}
			SaveSewingFile();
		}
		if (clsInit.appEditor.action == actionTypeBU.sewingSpeed)
		{
			if (frmSpeed == null)
			{
				frmSpeed = new F_SewingSpeed();
			}
			if (Selected.Count > 0)
			{
				if (SewingBase.MainEntityList[Selected[0].EntityIndex].Sewing.Vertex[Selected[0].VertexIndex].Speed > 0.0)
				{
					varSewingRunSettings.SewingSpeed = SewingBase.MainEntityList[Selected[0].EntityIndex].Sewing.Vertex[Selected[0].VertexIndex].Speed;
				}
				frmSpeed.Speed = varSewingRunSettings.SewingSpeed;
				frmSpeed.Properties.FormCloseMode = FormCloseModeType.Invisible;
				frmSpeed.Properties.FormPosition = FormStartPosition.CenterScreen;
				frmSpeed.Properties.TopMost = true;
				if ((bool)ShowDialog)
				{
					frmSpeed.Init();
					frmSpeed.ShowDialog();
				}
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					okCommandWithThreeDataEventHandler_0("SewingSpeed", null, null);
					frmSpeed.Speed = varSewingRunSettings.SewingSpeed;
				}
				if (((frmSpeed.Properties.Result == DialogResult.OK) | !(bool)ShowDialog) & !CancelApplied)
				{
					for (int k = 0; k <= Selected.Count - 1; k++)
					{
						SewingBase.MainEntityList[Selected[k].EntityIndex].Sewing.Vertex[Selected[k].VertexIndex].Speed = frmSpeed.Speed;
					}
				}
				clsInit.appEditor.Reset();
			}
			SaveSewingFile();
		}
		CancelApplied = false;
	}

	public void MoveCancel()
	{
		clsInit.appEditor.Reset();
	}

	public void RotateCommand(object Axis, object RotateDegree)
	{
		if (clsInit.appEditor.action != actionTypeBU.sewingRotate)
		{
			return;
		}
		Point3D point3D = new Point3D();
		Point3D value = new Point3D();
		Point3D Points = new Point3D();
		if (Selected.Count <= 0)
		{
			return;
		}
		int num = -1;
		StartEndType startEndType = StartEndType.Start;
		UndoBuffer();
		for (int i = 0; i <= Selected.Count - 1; i++)
		{
			if (Selected[i].EntityIndex < 0)
			{
				continue;
			}
			buEntity refEntity = SewingBase.MainEntityList[Selected[i].EntityIndex];
			buEntity buEntity2 = null;
			if (Selected[i].CatchPosition == StartMiddleEndType.Start)
			{
				point3D = new Point3D(SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.X, SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.Y);
				value = new Point3D(SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.X, SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.Y);
			}
			if (Selected[i].CatchPosition == StartMiddleEndType.End)
			{
				point3D = new Point3D(SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.X, SewingBase.MainEntityList[Selected[i].EntityIndex].EndPoint.Y);
				value = new Point3D(SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.X, SewingBase.MainEntityList[Selected[i].EntityIndex].StartPoint.Y);
			}
			for (int j = 0; j <= SewingBase.MainEntityList.Count - 1; j++)
			{
				if (j == Selected[i].EntityIndex)
				{
					continue;
				}
				if (!buCompare5.EQ(value, SewingBase.MainEntityList[j].StartPoint))
				{
					if (buCompare5.EQ(value, SewingBase.MainEntityList[j].EndPoint))
					{
						num = j;
						startEndType = StartEndType.End;
						buEntity2 = SewingBase.MainEntityList[j];
						Points = new Point3D(SewingBase.MainEntityList[j].EndPoint.X, SewingBase.MainEntityList[j].EndPoint.Y);
					}
				}
				else
				{
					num = j;
					startEndType = StartEndType.Start;
					buEntity2 = SewingBase.MainEntityList[j];
					Points = new Point3D(SewingBase.MainEntityList[j].StartPoint.X, SewingBase.MainEntityList[j].StartPoint.Y);
				}
			}
			clsInit.cVector5.Rotate(point3D, (double)RotateDegree, Vector3D.AxisZ, ref refEntity);
			clsInit.cVector5.Rotate(point3D, (double)RotateDegree, Plane.XY, ref Points);
			if (num >= 0 && buEntity2 != null)
			{
				if (startEndType == StartEndType.Start)
				{
					buEntity2.StartPoint = Points;
				}
				if (startEndType == StartEndType.End)
				{
					buEntity2.EndPoint = Points;
				}
				if (buEntity2 is buLine)
				{
					buEntity2.Update(buEntityUpdateType.Line);
				}
				if (buEntity2 is buArc)
				{
					buEntity2.Update(buEntityUpdateType.Arc3Point3D);
				}
			}
			if (SewingBase.MainEntityList[Selected[i].EntityIndex] is buLine)
			{
				SewingBase.MainEntityList[Selected[i].EntityIndex].Update(buEntityUpdateType.Line);
			}
			if (SewingBase.MainEntityList[Selected[i].EntityIndex] is buArc)
			{
				SewingBase.MainEntityList[Selected[i].EntityIndex].Update(buEntityUpdateType.Arc3Point3D);
			}
		}
		varSewingRunSettings.RotateDegree = Math.Abs(Convert.ToDouble(RotateDegree.ToString()));
		doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
		DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
	}

	public void CreateSewingTableList(SewingCompanies Company, SewingModel Model, ref SewingMain SewingBase, ref List<SewingJobItem> SewingTableList)
	{
		if (Company == SewingCompanies.Yesim && Model == SewingModel.YesimModel1)
		{
			CreateSewingTableListAsYesimModel1(ref SewingBase, ref SewingTableList);
		}
		JobUpdate();
	}

	public void CreateSewingJobItem(ref SewingJobItem S, int i, int j, SewingInfo SewInfo, double StartX = 0.0, double StartY = 0.0, bool AddStartPosition = false)
	{
		S.StitchStep = SewInfo.StitchLengt;
		S.HeadSpeed = SewInfo.HeadSpeed;
		S.StitchedWay = SewInfo.isStitchDrawing;
		S.FootHeight = SewInfo.Vertex[j].FootHeight;
		if (SewInfo.Vertex[j].Speed > 0.0)
		{
			S.HeadSpeed = SewInfo.Vertex[j].Speed;
		}
		S.PositionX = SewInfo.Vertex[j].Point.X + SewInfo.Vertex[j].DeltaX;
		S.PositionY = SewInfo.Vertex[j].Point.Y + SewInfo.Vertex[j].DeltaY;
		if (i == 0 && j == 0 && AddStartPosition)
		{
			S.PositionX = StartX;
			S.PositionY = StartY;
		}
		S.Style = SewInfo.Style;
		if (SewInfo.Vertex[j].Codes.Count > 0)
		{
			S.Code1 = (int)SewInfo.Vertex[j].Codes[0].Codes;
		}
		if (SewInfo.Vertex[j].Codes.Count > 1)
		{
			S.Code2 = (int)SewInfo.Vertex[j].Codes[1].Codes;
		}
		if (SewInfo.Vertex[j].Codes.Count > 2)
		{
			S.Code3 = (int)SewInfo.Vertex[j].Codes[2].Codes;
		}
		if (SewInfo.Vertex[j].Codes.Count > 3)
		{
			S.Code4 = (int)SewInfo.Vertex[j].Codes[3].Codes;
		}
		if (SewInfo.Vertex[j].Codes.Count > 4)
		{
			S.Code5 = (int)SewInfo.Vertex[j].Codes[4].Codes;
		}
	}

	public void MoveTouchEntities(int IndexNoApply, Point3D pntCatch, double X, double Y)
	{
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			if (i == IndexNoApply)
			{
				continue;
			}
			bool flag = false;
			if (!buCompare5.EQ(pntCatch, SewingBase.MainEntityList[i].StartPoint))
			{
				if (buCompare5.EQ(pntCatch, SewingBase.MainEntityList[i].EndPoint))
				{
					SewingBase.MainEntityList[i].EndPoint.X = SewingBase.MainEntityList[i].EndPoint.X + X;
					SewingBase.MainEntityList[i].EndPoint.Y = SewingBase.MainEntityList[i].EndPoint.Y + Y;
					flag = true;
				}
			}
			else
			{
				SewingBase.MainEntityList[i].StartPoint.X = SewingBase.MainEntityList[i].StartPoint.X + X;
				SewingBase.MainEntityList[i].StartPoint.Y = SewingBase.MainEntityList[i].StartPoint.Y + Y;
				flag = true;
			}
			for (int j = 0; j <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; j++)
			{
				if (buCompare5.EQ(pntCatch, SewingBase.MainEntityList[i].Sewing.Vertex[j].Point))
				{
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.X = SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.X + X;
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.Y = SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.Y + Y;
					flag = true;
				}
			}
			if (flag)
			{
				if (SewingBase.MainEntityList[i] is buLine)
				{
					SewingBase.MainEntityList[i].Update(buEntityUpdateType.Line);
				}
				if (SewingBase.MainEntityList[i] is buArc)
				{
					SewingBase.MainEntityList[i].Update(buEntityUpdateType.Arc3Point3D);
				}
			}
		}
	}

	public void UndoGetBack()
	{
		if (UndoList.Count > 0)
		{
			clsInit.appEditor.Reset();
			SewingBase = new SewingMain(UndoList[UndoList.Count - 1]);
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			UndoList.RemoveAt(UndoList.Count - 1);
		}
	}

	public void UndoBuffer()
	{
		if (UndoList.Count > 20)
		{
			UndoList.RemoveAt(0);
		}
		if (SewingBase.MainEntityList.Count > 0)
		{
			UndoList.Add(new SewingMain(SewingBase));
		}
	}

	public void JobTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		cmdTree = "";
		switch (treeNodeSettings.Command)
		{
		case "entity":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		case "startlock":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		case "endlock":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		case "punterez":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		case "vertex":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		case "codes":
			selectedEntIndex = treeNodeSettings.ClassSubIndex;
			selectedVertexIndex = treeNodeSettings.ClassSubSubIndex;
			cmdTree = treeNodeSettings.Command;
			break;
		}
		clsItem.frmEditor.viewport.Invalidate();
	}

	public void JobUpdate()
	{
		if (clsItem.frmEditor == null || itemTreeView == null)
		{
			return;
		}
		itemTreeView.Nodes.Clear();
		new TreeNodeSettings("sewing")
		{
			ImageIndex = 0,
			SelectedImageIndex = 0,
			Tag = "-1",
			ClassIndex = 0,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "sewing",
			Name = "sewing",
			Info = "sewing",
			Index = 0,
			Checked = false
		};
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			TreeNodeSettings treeNodeSettings = new TreeNodeSettings("entity")
			{
				Tag = "-1",
				ClassIndex = 0,
				ClassSubIndex = i,
				ClassSubSubIndex = -1,
				Command = "entity",
				Name = "entity" + i,
				Info = "entity" + i,
				Index = 0,
				Checked = false
			};
			treeNodeSettings.ImageIndex = clsInit.cSewing.TreeJobImageIndex(SewingBase.MainEntityList[i]);
			treeNodeSettings.SelectedImageIndex = clsInit.cSewing.TreeJobImageIndex(SewingBase.MainEntityList[i]);
			treeNodeSettings.Text = clsInit.cSewing.TreeJobDefination(SewingBase.MainEntityList[i]);
			if (SewingBase.MainEntityList[i].Sewing.StartStitchCount > 0)
			{
				TreeNodeSettings treeNodeSettings2 = new TreeNodeSettings("startlock")
				{
					Tag = "-1",
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "startlock",
					Name = "startlock" + i,
					Info = "startlock" + i,
					Index = 0,
					Checked = false
				};
				treeNodeSettings2.ImageIndex = 5;
				treeNodeSettings2.SelectedImageIndex = 5;
				treeNodeSettings2.Text = buLangTranslate.preDef.Start + " " + buLangTranslate.preDef.Lock + " " + buLangTranslate.preDef.Stitch + " : " + SewingBase.MainEntityList[i].Sewing.StartStitchCount;
				treeNodeSettings.Nodes.Add(treeNodeSettings2);
			}
			if (SewingBase.MainEntityList[i].Sewing.EndStitchCount > 0)
			{
				TreeNodeSettings treeNodeSettings3 = new TreeNodeSettings("endlock")
				{
					Tag = "-1",
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "endlock",
					Name = "endlock" + i,
					Info = "endlock" + i,
					Index = 0,
					Checked = false
				};
				treeNodeSettings3.ImageIndex = 5;
				treeNodeSettings3.SelectedImageIndex = 5;
				treeNodeSettings3.Text = buLangTranslate.preDef.End + " " + buLangTranslate.preDef.Lock + " " + buLangTranslate.preDef.Stitch + " : " + SewingBase.MainEntityList[i].Sewing.StartStitchCount;
				treeNodeSettings.Nodes.Add(treeNodeSettings3);
			}
			for (int j = 0; j <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; j++)
			{
				if (SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez != null)
				{
					SewingVertex sewingVertex = SewingBase.MainEntityList[i].Sewing.Vertex[j];
					TreeNodeSettings treeNodeSettings4 = new TreeNodeSettings("punterez")
					{
						Tag = "-1",
						ClassIndex = 0,
						ClassSubIndex = i,
						ClassSubSubIndex = j,
						Command = "punterez",
						Name = "punterez" + j,
						Info = "punterez" + j,
						Index = 0,
						Checked = false
					};
					treeNodeSettings4.ImageIndex = 4;
					treeNodeSettings4.SelectedImageIndex = 4;
					treeNodeSettings4.Text = buLangTranslate.preDef.Bartack + " " + buLangTranslate.preDef.Stitch + "[ " + j + " ] : " + buLangTranslate.preDef.Length + ": " + sewingVertex.Punterez.Length + " , " + buLangTranslate.preDef.Width + ": " + sewingVertex.Punterez.Width;
					treeNodeSettings.Nodes.Add(treeNodeSettings4);
				}
			}
			if (SewingBase.MainEntityList[i].Sewing.Vertex.Count > 0)
			{
				TreeNodeSettings treeNodeSettings5 = new TreeNodeSettings("vertex")
				{
					Tag = "-1",
					ClassIndex = 0,
					ClassSubIndex = i,
					Command = "vertex",
					Name = "vertex",
					Info = SewingBase.MainEntityList[i].Sewing.Vertex.Count.ToString(),
					Index = 0,
					Checked = false
				};
				treeNodeSettings5.ImageIndex = 4;
				treeNodeSettings5.SelectedImageIndex = 4;
				treeNodeSettings5.Text = buLangTranslate.preDef.Vertex + " : " + SewingBase.MainEntityList[i].Sewing.Vertex.Count;
				for (int k = 0; k <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; k++)
				{
					SewingVertex sewingVertex2 = SewingBase.MainEntityList[i].Sewing.Vertex[k];
					TreeNodeSettings treeNodeSettings6 = new TreeNodeSettings("vertexnode")
					{
						Tag = "-1",
						ClassIndex = 0,
						ClassSubIndex = i,
						ClassSubSubIndex = k,
						Command = "vertexnode",
						Name = "vertexnode" + k,
						Info = sewingVertex2.Point.X + ";" + sewingVertex2.Point.Y,
						Index = 0,
						Checked = false
					};
					treeNodeSettings6.ImageIndex = 4;
					treeNodeSettings6.SelectedImageIndex = 4;
					treeNodeSettings6.Text = buLangTranslate.preDef.Vertex + " - X: " + sewingVertex2.Point.X.ToString("f2") + "Y: " + sewingVertex2.Point.Y.ToString("f2");
					if (sewingVertex2.Codes.Count > 0)
					{
						treeNodeSettings6.Text = treeNodeSettings6.Text + " , " + sewingVertex2.Codes.Count;
					}
					for (int l = 0; l <= sewingVertex2.Codes.Count - 1; l++)
					{
						TreeNodeSettings treeNodeSettings7 = new TreeNodeSettings("codes")
						{
							Tag = "-1",
							ClassIndex = 0,
							ClassSubIndex = i,
							ClassSubSubIndex = k,
							ClassSubSubSubIndex = l,
							Command = "codes",
							Name = "codes" + k,
							Info = Convert.ToInt32(sewingVertex2.Codes[l].Codes).ToString(),
							Index = 0,
							Checked = false
						};
						treeNodeSettings7.ImageIndex = 6;
						treeNodeSettings7.SelectedImageIndex = 6;
						treeNodeSettings7.Text = buLangTranslate.preDef.Codes + ": " + sewingVertex2.Codes[l].Codes;
						treeNodeSettings6.Nodes.Add(treeNodeSettings7);
					}
					treeNodeSettings5.Nodes.Add(treeNodeSettings6);
				}
				treeNodeSettings.Nodes.Add(treeNodeSettings5);
			}
			itemTreeView.Nodes.Add(treeNodeSettings);
		}
	}

	public void doAddEntities(List<Entity> refEntities)
	{
		for (int i = 0; i <= refEntities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(refEntities[i], ref copiedEntity);
			if (copiedEntity != null)
			{
				copiedEntity.Sewing = new SewingInfo();
				copiedEntity.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
				copiedEntity.Sewing.isStitchDrawing = true;
				SewingBase.MainEntityList.Add(copiedEntity);
			}
		}
		if (refEntities.Count > 0)
		{
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		}
	}

	public void doGetScreenEntititesFromMainEntities(List<buEntity> MainList, ref List<Entity> screenEntities)
	{
		screenEntities.Clear();
		screenEntities = new List<Entity>();
		for (int i = 0; i <= MainList.Count - 1; i++)
		{
			if (MainList[i].Sewing.Vertex.Count != 0)
			{
				for (int j = 0; j <= MainList[i].Sewing.Vertex.Count - 1; j++)
				{
					CustomData customData = new CustomData();
					if (j > 0)
					{
						Line line = new Line(MainList[i].Sewing.Vertex[j - 1].Point, MainList[i].Sewing.Vertex[j].Point);
						line.LineWeight = 1f;
						line.LayerName = "Drawing";
						line.Color = Color.Red;
						line.ColorMethod = colorMethodType.byEntity;
						customData = new CustomData();
						customData.RefIndex = i;
						line.EntityData = customData;
						screenEntities.Add(line);
					}
					devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(MainList[i].Sewing.Vertex[j].Point);
					point.LineWeight = 1f;
					point.Color = Color.Blue;
					point.ColorMethod = colorMethodType.byEntity;
					point.LayerName = "Point";
					customData = new CustomData();
					customData.RefIndex = i;
					point.EntityData = customData;
					screenEntities.Add(point);
				}
			}
			else
			{
				Entity copiedEntity = null;
				buEntity.Copy(MainList[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					copiedEntity.LayerName = "Drawing";
					copiedEntity.Color = Color.Green;
					screenEntities.Add(copiedEntity);
				}
			}
		}
	}

	public bool doGetVertexIndex(Point3D Pnt, ref List<SewingPickType> PickList, ref Point3D pntCatch)
	{
		PickList.Clear();
		if (isPointLayerVisible())
		{
			for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
			{
				for (int j = 0; j <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; j++)
				{
					Point3D point3D = new Point3D(SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.X + SewingBase.MainEntityList[i].Sewing.Vertex[j].DeltaX, SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.Y + SewingBase.MainEntityList[i].Sewing.Vertex[j].DeltaY);
					if (buCompare5.EQ(Pnt, point3D, varSewingSettings.CatchResolution) & SewingBase.MainEntityList[i].Sewing.isStitchDrawing)
					{
						SewingPickType sewingPickType = new SewingPickType();
						sewingPickType.EntityIndex = i;
						sewingPickType.VertexIndex = j;
						sewingPickType.PickType = SewingPickClickType.Vertex;
						PickList.Add(sewingPickType);
						pntCatch = buVector5.ToPoint3D(point3D);
					}
				}
			}
		}
		if (PickList.Count == 0)
		{
			for (int k = 0; k <= SewingBase.MainEntityList.Count - 1; k++)
			{
				if (!buCompare5.EQ(Pnt, SewingBase.MainEntityList[k].StartPoint, varSewingSettings.CatchResolution))
				{
					if (buCompare5.EQ(Pnt, SewingBase.MainEntityList[k].EndPoint, varSewingSettings.CatchResolution))
					{
						SewingPickType sewingPickType2 = new SewingPickType();
						sewingPickType2.EntityIndex = k;
						sewingPickType2.VertexIndex = -1;
						sewingPickType2.PickType = SewingPickClickType.Entity;
						sewingPickType2.EntitySelectType = SewingPickEntitySelectType.EndPoint;
						PickList.Add(sewingPickType2);
					}
				}
				else
				{
					SewingPickType sewingPickType3 = new SewingPickType();
					sewingPickType3.EntityIndex = k;
					sewingPickType3.VertexIndex = -1;
					sewingPickType3.PickType = SewingPickClickType.Entity;
					sewingPickType3.EntitySelectType = SewingPickEntitySelectType.StartPoint;
					PickList.Add(sewingPickType3);
				}
			}
		}
		if (PickList.Count <= 0)
		{
			return false;
		}
		return true;
	}

	public bool doGetVertexIndex(Point3D Pnt, ref List<SewingPickType> PickList)
	{
		Point3D pntCatch = new Point3D();
		return doGetVertexIndex(Pnt, ref PickList, ref pntCatch);
	}

	public void doCopyVertexPropertiesFromOld(ref List<buEntity> mainEntities, int EntityIndex, List<SewingVertex> OldVertex, bool CopyCodes = true)
	{
		if (!((OldVertex.Count > 0) & (mainEntities[EntityIndex].Sewing.Vertex.Count > 0)))
		{
			return;
		}
		if (CopyCodes)
		{
			mainEntities[EntityIndex].Sewing.Vertex[0].Codes.Clear();
		}
		mainEntities[EntityIndex].Sewing.Vertex[0].DeltaX = OldVertex[0].DeltaX;
		mainEntities[EntityIndex].Sewing.Vertex[0].DeltaY = OldVertex[0].DeltaY;
		if (CopyCodes)
		{
			for (int i = 0; i <= OldVertex[0].Codes.Count - 1; i++)
			{
				mainEntities[EntityIndex].Sewing.Vertex[0].Codes.Add(new SewingCode(OldVertex[0].Codes[i]));
			}
		}
		mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].Codes.Clear();
		mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].DeltaX = OldVertex[OldVertex.Count - 1].DeltaX;
		mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].DeltaY = OldVertex[OldVertex.Count - 1].DeltaY;
		for (int j = 0; j <= OldVertex[OldVertex.Count - 1].Codes.Count - 1; j++)
		{
			mainEntities[EntityIndex].Sewing.Vertex[mainEntities[EntityIndex].Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(OldVertex[OldVertex.Count - 1].Codes[j]));
		}
		for (int k = 1; k <= OldVertex.Count - 2; k++)
		{
			if (k > mainEntities[EntityIndex].Sewing.Vertex.Count - 2)
			{
				continue;
			}
			if (CopyCodes)
			{
				mainEntities[EntityIndex].Sewing.Vertex[k].Codes.Clear();
			}
			mainEntities[EntityIndex].Sewing.Vertex[k].DeltaX = OldVertex[k].DeltaX;
			mainEntities[EntityIndex].Sewing.Vertex[k].DeltaY = OldVertex[k].DeltaY;
			if (CopyCodes)
			{
				for (int l = 0; l <= OldVertex[k].Codes.Count - 1; l++)
				{
					mainEntities[EntityIndex].Sewing.Vertex[k].Codes.Add(new SewingCode(OldVertex[k].Codes[l]));
				}
			}
		}
	}

	public void doSetProperties(Point3D Pnt)
	{
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			for (int j = 0; j <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; j++)
			{
				Point3D value = new Point3D(SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.X + SewingBase.MainEntityList[i].Sewing.Vertex[j].DeltaX, SewingBase.MainEntityList[i].Sewing.Vertex[j].Point.Y + SewingBase.MainEntityList[i].Sewing.Vertex[j].DeltaY);
				if (!buCompare5.EQ(Pnt, value, varSewingSettings.CatchResolution))
				{
					continue;
				}
				F_SewingSetProperties f_SewingSetProperties = new F_SewingSetProperties();
				Array values = Enum.GetValues(typeof(SewingCodes));
				for (int k = 0; k <= values.Length - 1; k++)
				{
					f_SewingSetProperties.AllCommands.Add(values.GetValue(k).ToString());
				}
				for (int l = 0; l <= SewingBase.MainEntityList[i].Sewing.Vertex[j].Codes.Count - 1; l++)
				{
					f_SewingSetProperties.ActualCommands.Add(SewingBase.MainEntityList[i].Sewing.Vertex[j].Codes[l].Codes.ToString());
				}
				f_SewingSetProperties.Init();
				f_SewingSetProperties.ShowDialog();
				if (f_SewingSetProperties.Properties.Result != DialogResult.OK)
				{
					continue;
				}
				SewingBase.MainEntityList[i].Sewing.Vertex[j].Codes.Clear();
				for (int m = 0; m <= f_SewingSetProperties.ActualCommands.Count - 1; m++)
				{
					if (f_SewingSetProperties.ActualCommands[m].Trim().Length > 0)
					{
						SewingCode sewingCode = new SewingCode();
						sewingCode.Codes = (SewingCodes)Enum.Parse(typeof(SewingCodes), f_SewingSetProperties.ActualCommands[m].Trim());
						SewingBase.MainEntityList[i].Sewing.Vertex[j].Codes.Add(sewingCode);
					}
				}
			}
		}
	}

	public void doCreateSewingLayers(int indexPage)
	{
		if ((ccVars.Pages.Count > 0 && indexPage >= 0) & (indexPage <= ccVars.Pages.Count - 1))
		{
			ccVars.Pages[indexPage].Layers.Clear();
			LayerBase5 layerBase = new LayerBase5(varSewingSettings.layerNameDrawing);
			layerBase.LayerColor = varSewingSettings.colorDrawing;
			layerBase.LayerThickness = (float)varSewingSettings.thicknessDrawing;
			ccVars.Pages[indexPage].Layers.Add(layerBase);
			LayerBase5 layerBase2 = new LayerBase5(varSewingSettings.layerNamePoint);
			layerBase2.LayerColor = varSewingSettings.colorPoints;
			layerBase2.LayerThickness = (float)varSewingSettings.thicknessPoints;
			ccVars.Pages[indexPage].Layers.Add(layerBase2);
			LayerBase5 layerBase3 = new LayerBase5(varSewingSettings.layerNameGeneral);
			layerBase3.LayerColor = varSewingSettings.colorGeneral;
			layerBase3.LayerThickness = (float)varSewingSettings.thicknessGeneral;
			ccVars.Pages[indexPage].Layers.Add(layerBase3);
			LayerBase5 layerBase4 = new LayerBase5(varSewingSettings.layerNameOriginal);
			layerBase4.LayerColor = varSewingSettings.colorOriginalDrawing;
			layerBase4.LayerThickness = (float)varSewingSettings.thicknessOriginalDrawing;
			ccVars.Pages[indexPage].Layers.Add(layerBase4);
			LayerBase5 layerBase5 = new LayerBase5(varSewingSettings.layerNameDrawingPoints);
			layerBase5.LayerColor = varSewingSettings.colorDrawingPoints;
			layerBase5.LayerThickness = (float)varSewingSettings.thicknessDrawingPoints;
			ccVars.Pages[indexPage].Layers.Add(layerBase5);
			LayerBase5 layerBase6 = new LayerBase5(varSewingSettings.layerNameDrawingDevided);
			layerBase6.LayerColor = varSewingSettings.colorDrawingDevided;
			layerBase6.LayerThickness = (float)varSewingSettings.thicknessDrawingDevided;
			ccVars.Pages[indexPage].Layers.Add(layerBase6);
			ccVars.Pages[indexPage].Form.viewportcad.Layers = clsInit.appCommand.LayerConvertFromBuLayerToEyeLayer(ccVars.Pages[ccVars.PageIndex].Layers);
		}
	}

	public void doSortMainEntitiesByRefPoint(Point3D refPoint, SortingNextGroupFindRulesType NextRules = SortingNextGroupFindRulesType.ClosestLength)
	{
		SortbuSettings sortbuSettings = new SortbuSettings();
		List<buEntity> SortedEntities = new List<buEntity>();
		sortbuSettings.Option.NextGroupRules = NextRules;
		clsInit.cVector5.SortEntitiesByRefPoint(refPoint, ref SewingBase.MainEntityList, sortbuSettings, ref SortedEntities);
		clsItem.frmEditor.SortingDone = false;
		if (SortedEntities.Count > 0)
		{
			SewingBase.MainEntityList.Clear();
			SewingBase.MainEntityList = new List<buEntity>();
			for (int i = 0; i <= SortedEntities.Count - 1; i++)
			{
				if (SortedEntities[i].Sewing != null)
				{
					SewingInfo Sewing = SortedEntities[i].Sewing;
					if (Company == SewingCompanies.Yesim && Model == SewingModel.YesimModel1)
					{
						RemoveStitchEndCommand(ref Sewing);
					}
				}
				if (!(SortedEntities[i].GetType() == typeof(buUpperLine)))
				{
					SewingBase.MainEntityList.Add(buEntity.Copy(SortedEntities[i]));
					continue;
				}
				buLine buLine2 = new buLine(SortedEntities[i].StartPoint, SortedEntities[i].EndPoint);
				buLine2.Sewing = new SewingInfo();
				buLine2.Sewing.isStitchDrawing = false;
				buLine2.Sewing.Vertex.Add(new SewingVertex(SortedEntities[i].StartPoint));
				buLine2.Sewing.Vertex.Add(new SewingVertex(SortedEntities[i].EndPoint));
				SewingBase.MainEntityList.Add(buLine2);
			}
			clsItem.frmEditor.SortingDone = true;
		}
		if (varSewingSettings.DevideEntitiesAfterSort | !SewingBase.isSorted)
		{
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
		}
		SewingBase.isSorted = true;
		clsInit.appEditor.Reset();
		clsInit.appEditor.action = actionTypeBU.None;
	}

	public void doDevideEntitiesByLength(ref List<buEntity> mainEntities, SewingDevideOptions Options)
	{
		int num = 0;
		int num2 = mainEntities.Count - 1;
		if (Options.StartIndex >= 0)
		{
			num = Options.StartIndex;
		}
		if (Options.EndIndex >= 0)
		{
			num2 = Options.EndIndex;
		}
		for (int i = num; i <= num2; i++)
		{
			buEntity buEntity2 = mainEntities[i];
			List<SewingVertex> Copied = new List<SewingVertex>();
			if (buEntity2.Sewing.Vertex.Count > 0)
			{
				SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied);
			}
			if (buEntity2.Sewing == null)
			{
				continue;
			}
			if (!buEntity2.Sewing.isStitchDrawing)
			{
				List<SewingVertex> list = new List<SewingVertex>();
				for (int j = 0; j <= buEntity2.Sewing.Vertex.Count - 1; j++)
				{
					list.Add(new SewingVertex(buEntity2.Sewing.Vertex[j]));
				}
				buEntity2.Sewing.Vertex = new List<SewingVertex>();
				if (buEntity2.sortDirection != entitySortDirection.Normal)
				{
					buEntity2.Sewing.Vertex.Add(new SewingVertex(buEntity2.EndPoint));
					buEntity2.Sewing.Vertex.Add(new SewingVertex(buEntity2.StartPoint));
				}
				else
				{
					buEntity2.Sewing.Vertex.Add(new SewingVertex(buEntity2.StartPoint));
					buEntity2.Sewing.Vertex.Add(new SewingVertex(buEntity2.EndPoint));
				}
				for (int k = 0; k <= list.Count - 1; k++)
				{
					for (int l = 0; l <= buEntity2.Sewing.Vertex.Count - 1; l++)
					{
						if (buCompare5.EQ(list[k].Point, buEntity2.Sewing.Vertex[l].Point) && list[k].Codes.Count > 0)
						{
							for (int m = 0; m <= list[k].Codes.Count - 1; m++)
							{
								buEntity2.Sewing.Vertex[l].Codes.Add(list[k].Codes[m]);
							}
						}
					}
				}
				continue;
			}
			if (!(buEntity2 is buLinearPath))
			{
				List<Point3D> pntDevided = new List<Point3D>();
				double devideLength = buEntity2.Sewing.StitchLengt;
				if ((Copied.Count > 1) & !Options.ProtectEntityStitchLen)
				{
					Entity copiedEntity = null;
					buEntity.Copy(buEntity2, ref copiedEntity);
					int num3 = Convert.ToInt32(((ICurve)copiedEntity).Length() / buEntity2.Sewing.StitchLengt);
					if (num3 < 2)
					{
						num3 = 2;
					}
					double num4 = ((ICurve)copiedEntity).Length();
					devideLength = num4 / (double)(num3 - 1);
				}
				clsInit.cVector5.EntityDevideByCamDir(buEntity2, devideLength, ref pntDevided);
				List<SewingVertex> Copied2 = new List<SewingVertex>();
				SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied2);
				buEntity2.Sewing.Vertex.Clear();
				buEntity2.Sewing.Vertex = new List<SewingVertex>();
				for (int n = 0; n <= pntDevided.Count - 1; n++)
				{
					if (Copied2.Count == 0)
					{
						buEntity2.Sewing.Vertex.Add(new SewingVertex(pntDevided[n]));
					}
				}
				if (Copied2.Count <= 0)
				{
					continue;
				}
				if (Copied2.Count <= pntDevided.Count)
				{
					if (Copied2.Count > pntDevided.Count || Copied2.Count <= 0)
					{
						continue;
					}
					SewingVertex sewingVertex = new SewingVertex(pntDevided[0]);
					sewingVertex.FootHeight = Copied2[0].FootHeight;
					sewingVertex.Speed = Copied2[0].Speed;
					sewingVertex.DeltaX = Copied2[0].DeltaX;
					sewingVertex.DeltaY = Copied2[0].DeltaY;
					for (int num5 = 0; num5 <= Copied2[0].Codes.Count - 1; num5++)
					{
						sewingVertex.Codes.Add(Copied2[0].Codes[num5]);
					}
					if (Copied2[0].Punterez != null)
					{
						sewingVertex.Punterez = new SewingPunteriz(Copied2[0].Punterez);
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex);
					for (int num6 = 1; num6 <= pntDevided.Count - 2; num6++)
					{
						sewingVertex = new SewingVertex(pntDevided[num6]);
						if (num6 >= Copied2.Count - 1)
						{
							if (Options.ApplyNewLenUpToEnd & (buEntity2.Sewing.Vertex.Count > 0))
							{
								sewingVertex.DeltaX = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaX;
								sewingVertex.DeltaY = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaY;
								sewingVertex.FootHeight = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].FootHeight;
								sewingVertex.Speed = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Speed;
								if (buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Punterez != null)
								{
									sewingVertex.Punterez = new SewingPunteriz(buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Punterez);
								}
							}
						}
						else
						{
							sewingVertex.DeltaX = Copied2[num6].DeltaX;
							sewingVertex.DeltaY = Copied2[num6].DeltaY;
							sewingVertex.FootHeight = Copied2[num6].FootHeight;
							sewingVertex.Speed = Copied2[num6].Speed;
							if (Copied2[num6].Punterez != null)
							{
								sewingVertex.Punterez = new SewingPunteriz(Copied2[num6].Punterez);
							}
							if (num6 < Copied2.Count - 1)
							{
								for (int num7 = 0; num7 <= Copied2[num6].Codes.Count - 1; num7++)
								{
									sewingVertex.Codes.Add(Copied2[num6].Codes[num7]);
								}
							}
						}
						buEntity2.Sewing.Vertex.Add(sewingVertex);
					}
					sewingVertex = new SewingVertex(pntDevided[pntDevided.Count - 1]);
					sewingVertex.DeltaX = Copied2[Copied2.Count - 1].DeltaX;
					sewingVertex.DeltaY = Copied2[Copied2.Count - 1].DeltaY;
					sewingVertex.FootHeight = Copied2[Copied2.Count - 1].FootHeight;
					sewingVertex.Speed = Copied2[Copied2.Count - 1].Speed;
					if (Copied2.Count > 1)
					{
						for (int num8 = 0; num8 <= Copied2[Copied2.Count - 1].Codes.Count - 1; num8++)
						{
							sewingVertex.Codes.Add(Copied2[Copied2.Count - 1].Codes[num8]);
						}
					}
					if (Copied2[Copied2.Count - 1].Punterez != null)
					{
						sewingVertex.Punterez = new SewingPunteriz(Copied2[Copied2.Count - 1].Punterez);
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex);
					continue;
				}
				SewingVertex sewingVertex2 = new SewingVertex(pntDevided[0]);
				for (int num9 = 0; num9 <= pntDevided.Count - 1; num9++)
				{
					sewingVertex2 = new SewingVertex(pntDevided[num9]);
					if (num9 >= pntDevided.Count - 1)
					{
						if (Copied2[Copied2.Count - 1].Punterez != null)
						{
							sewingVertex2.Punterez = new SewingPunteriz(Copied2[Copied2.Count - 1].Punterez);
						}
						sewingVertex2.FootHeight = Copied2[Copied2.Count - 1].FootHeight;
						sewingVertex2.Speed = Copied2[Copied2.Count - 1].Speed;
						sewingVertex2.DeltaX = Copied2[Copied2.Count - 1].DeltaX;
						sewingVertex2.DeltaY = Copied2[Copied2.Count - 1].DeltaY;
						for (int num10 = 0; num10 <= Copied2[Copied2.Count - 1].Codes.Count - 1; num10++)
						{
							sewingVertex2.Codes.Add(Copied2[Copied2.Count - 1].Codes[num10]);
						}
					}
					else
					{
						if (Copied2[num9].Punterez != null)
						{
							sewingVertex2.Punterez = new SewingPunteriz(Copied2[num9].Punterez);
						}
						sewingVertex2.FootHeight = Copied2[num9].FootHeight;
						sewingVertex2.Speed = Copied2[num9].Speed;
						sewingVertex2.DeltaX = Copied2[num9].DeltaX;
						sewingVertex2.DeltaY = Copied2[num9].DeltaY;
						for (int num11 = 0; num11 <= Copied2[num9].Codes.Count - 1; num11++)
						{
							sewingVertex2.Codes.Add(Copied2[num9].Codes[num11]);
						}
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex2);
				}
				continue;
			}
			List<Point3D> Points = new List<Point3D>();
			for (int num12 = 1; num12 <= buEntity2.Vertices.Count - 1; num12++)
			{
				List<Point3D> pntDevided2 = new List<Point3D>();
				double num13 = Point3D.Distance(buEntity2.Vertices[num12 - 1], buEntity2.Vertices[num12]);
				buEntity refEntity = new buLine(buEntity2.Vertices[num12 - 1], buEntity2.Vertices[num12]);
				double devideLength2 = buEntity2.Sewing.StitchLengt;
				if ((Copied.Count > 1) & !Options.ProtectEntityStitchLen)
				{
					Entity copiedEntity2 = null;
					buEntity.Copy(buEntity2, ref copiedEntity2);
					Convert.ToInt32(num13 / buEntity2.Sewing.StitchLengt);
					double num14 = ((ICurve)copiedEntity2).Length();
					devideLength2 = num14 / (double)(Copied.Count - 1);
				}
				clsInit.cVector5.EntityDevideByCamDir(refEntity, devideLength2, ref pntDevided2);
				Points.AddRange(pntDevided2);
			}
			List<SewingVertex> Copied3 = new List<SewingVertex>();
			SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied3);
			buEntity2.Sewing.Vertex.Clear();
			buEntity2.Sewing.Vertex = new List<SewingVertex>();
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
			if (Points.Count > 0)
			{
				for (int num15 = 0; num15 <= Points.Count - 1; num15++)
				{
					buEntity2.Sewing.Vertex.Add(new SewingVertex(Points[num15]));
				}
			}
			if (Copied3.Count > Points.Count || Copied3.Count > Points.Count || !((Copied3.Count > 0) & (buEntity2.Sewing.Vertex.Count > 0)))
			{
				continue;
			}
			if (Copied3.Count != 1)
			{
				buEntity2.Sewing.Vertex[0].DeltaX = Copied3[0].DeltaX;
				buEntity2.Sewing.Vertex[0].DeltaY = Copied3[0].DeltaY;
				for (int num16 = 0; num16 <= Copied3[0].Codes.Count - 1; num16++)
				{
					buEntity2.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied3[0].Codes[num16]));
				}
				buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaX = Copied3[Copied3.Count - 1].DeltaX;
				buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaY = Copied3[Copied3.Count - 1].DeltaY;
				for (int num17 = 0; num17 <= Copied3[Copied3.Count - 1].Codes.Count - 1; num17++)
				{
					buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(Copied3[Copied3.Count - 1].Codes[num17]));
				}
			}
			else
			{
				buEntity2.Sewing.Vertex[0].DeltaX = Copied3[0].DeltaX;
				buEntity2.Sewing.Vertex[0].DeltaY = Copied3[0].DeltaY;
				for (int num18 = 0; num18 <= Copied3[0].Codes.Count - 1; num18++)
				{
					buEntity2.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied3[0].Codes[num18]));
				}
			}
		}
	}

	public void doDevideEntities(ref List<buEntity> mainEntities, SewingDevideOptions Options)
	{
		List<Entity> screenDrawEntities = new List<Entity>();
		List<Entity> screenPointEntities = new List<Entity>();
		doDevideEntities(ref mainEntities, Options, ref screenDrawEntities, ref screenPointEntities);
	}

	public void doDevideEntities(ref List<buEntity> mainEntities, SewingDevideOptions Options, ref List<Entity> screenDrawEntities, ref List<Entity> screenPointEntities)
	{
		screenDrawEntities.Clear();
		screenDrawEntities = new List<Entity>();
		screenPointEntities.Clear();
		screenPointEntities = new List<Entity>();
		int num = 0;
		int num2 = mainEntities.Count - 1;
		if (Options.StartIndex >= 0)
		{
			num = Options.StartIndex;
		}
		if (Options.EndIndex >= 0)
		{
			num2 = Options.EndIndex;
		}
		for (int i = num; i <= num2; i++)
		{
			buEntity buEntity2 = mainEntities[i];
			List<SewingVertex> Copied = new List<SewingVertex>();
			if (buEntity2.Sewing.Vertex.Count > 0)
			{
				SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied);
			}
			if (buEntity2.Sewing == null)
			{
				continue;
			}
			if (!buEntity2.Sewing.isStitchDrawing)
			{
				Entity copiedEntity = null;
				buEntity.Copy(buEntity2, ref copiedEntity);
				copiedEntity.LineWeight = (float)Options.DrawigThickness;
				copiedEntity.Color = Options.DrawingColor;
				copiedEntity.ColorMethod = colorMethodType.byEntity;
				if (Options.DrawingLayerName.Length > 0)
				{
					copiedEntity.LayerName = Options.DrawingLayerName;
				}
				CustomData customData = new CustomData();
				customData.RefIndex = i;
				copiedEntity.EntityData = customData;
				screenDrawEntities.Add(copiedEntity);
				for (int j = 0; j <= buEntity2.Vertices.Count - 1; j++)
				{
					devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(buEntity2.Vertices[j]);
					point.LineWeight = (float)Options.PointThickness;
					point.Color = Options.PointColor;
					point.ColorMethod = colorMethodType.byEntity;
					if (Options.PointLayerName.Length > 0)
					{
						point.LayerName = Options.PointLayerName;
					}
					customData = new CustomData();
					customData.RefIndex = i;
					point.EntityData = customData;
					screenPointEntities.Add(point);
				}
				continue;
			}
			if (!(buEntity2 is buLinearPath))
			{
				List<Point3D> pntDevided = new List<Point3D>();
				double devideLength = buEntity2.Sewing.StitchLengt;
				if ((Copied.Count > 1) & !Options.ProtectEntityStitchLen)
				{
					Entity copiedEntity2 = null;
					buEntity.Copy(buEntity2, ref copiedEntity2);
					Convert.ToInt32(((ICurve)copiedEntity2).Length() / buEntity2.Sewing.StitchLengt);
					double num3 = ((ICurve)copiedEntity2).Length();
					devideLength = num3 / (double)(Copied.Count - 1);
				}
				clsInit.cVector5.EntityDevideByCamDir(buEntity2, devideLength, ref pntDevided);
				List<SewingVertex> Copied2 = new List<SewingVertex>();
				SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied2);
				buEntity2.Sewing.Vertex.Clear();
				buEntity2.Sewing.Vertex = new List<SewingVertex>();
				for (int k = 0; k <= pntDevided.Count - 1; k++)
				{
					CustomData customData2 = new CustomData();
					if (k > 0)
					{
						Line line = new Line(pntDevided[k - 1], pntDevided[k]);
						line.LineWeight = (float)Options.DrawigThickness;
						line.Color = Options.DrawingColor;
						line.ColorMethod = colorMethodType.byEntity;
						if (Options.DrawingLayerName.Length > 0)
						{
							line.LayerName = Options.DrawingLayerName;
						}
						customData2 = new CustomData();
						customData2.RefIndex = i;
						line.EntityData = customData2;
						screenDrawEntities.Add(line);
					}
					devDept.Eyeshot.Entities.Point point2 = new devDept.Eyeshot.Entities.Point(pntDevided[k]);
					point2.LineWeight = (float)Options.PointThickness;
					point2.Color = Options.PointColor;
					point2.ColorMethod = colorMethodType.byEntity;
					if (Options.PointLayerName.Length > 0)
					{
						point2.LayerName = Options.PointLayerName;
					}
					customData2 = new CustomData();
					customData2.RefIndex = i;
					point2.EntityData = customData2;
					screenPointEntities.Add(point2);
					if (Copied2.Count == 0)
					{
						buEntity2.Sewing.Vertex.Add(new SewingVertex(pntDevided[k]));
					}
				}
				if (Copied2.Count <= 0)
				{
					continue;
				}
				if (Copied2.Count <= pntDevided.Count)
				{
					if (Copied2.Count > pntDevided.Count || Copied2.Count <= 0)
					{
						continue;
					}
					SewingVertex sewingVertex = new SewingVertex(pntDevided[0]);
					sewingVertex.FootHeight = Copied2[0].FootHeight;
					sewingVertex.Speed = Copied2[0].Speed;
					sewingVertex.DeltaX = Copied2[0].DeltaX;
					sewingVertex.DeltaY = Copied2[0].DeltaY;
					for (int l = 0; l <= Copied2[0].Codes.Count - 1; l++)
					{
						sewingVertex.Codes.Add(Copied2[0].Codes[l]);
					}
					if (Copied2[0].Punterez != null)
					{
						sewingVertex.Punterez = new SewingPunteriz(Copied2[0].Punterez);
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex);
					for (int m = 1; m <= pntDevided.Count - 2; m++)
					{
						sewingVertex = new SewingVertex(pntDevided[m]);
						if (m > Copied2.Count - 1)
						{
							if (Options.ApplyNewLenUpToEnd & (buEntity2.Sewing.Vertex.Count > 0))
							{
								sewingVertex.DeltaX = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaX;
								sewingVertex.DeltaY = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaY;
								sewingVertex.FootHeight = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].FootHeight;
								sewingVertex.Speed = buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Speed;
							}
						}
						else
						{
							sewingVertex.DeltaX = Copied2[m].DeltaX;
							sewingVertex.DeltaY = Copied2[m].DeltaY;
							sewingVertex.FootHeight = Copied2[m].FootHeight;
							sewingVertex.Speed = Copied2[m].Speed;
							if (m < Copied2.Count - 1)
							{
								for (int n = 0; n <= Copied2[m].Codes.Count - 1; n++)
								{
									sewingVertex.Codes.Add(Copied2[m].Codes[n]);
								}
								if (Copied2[m].Punterez != null)
								{
									sewingVertex.Punterez = new SewingPunteriz(Copied2[m].Punterez);
								}
							}
						}
						buEntity2.Sewing.Vertex.Add(sewingVertex);
					}
					sewingVertex = new SewingVertex(pntDevided[pntDevided.Count - 1]);
					sewingVertex.DeltaX = Copied2[Copied2.Count - 1].DeltaX;
					sewingVertex.DeltaY = Copied2[Copied2.Count - 1].DeltaY;
					sewingVertex.FootHeight = Copied2[Copied2.Count - 1].FootHeight;
					sewingVertex.Speed = Copied2[Copied2.Count - 1].Speed;
					if (Copied2.Count > 1)
					{
						for (int num4 = 0; num4 <= Copied2[Copied2.Count - 1].Codes.Count - 1; num4++)
						{
							sewingVertex.Codes.Add(Copied2[Copied2.Count - 1].Codes[num4]);
						}
					}
					if (Copied2[Copied2.Count - 1].Punterez != null)
					{
						sewingVertex.Punterez = new SewingPunteriz(Copied2[Copied2.Count - 1].Punterez);
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex);
					continue;
				}
				SewingVertex sewingVertex2 = new SewingVertex(pntDevided[0]);
				for (int num5 = 0; num5 <= pntDevided.Count - 1; num5++)
				{
					sewingVertex2 = new SewingVertex(pntDevided[num5]);
					if (num5 >= pntDevided.Count - 1)
					{
						for (int num6 = 0; num6 <= Copied2[Copied2.Count - 1].Codes.Count - 1; num6++)
						{
							sewingVertex2.Codes.Add(Copied2[Copied2.Count - 1].Codes[num6]);
						}
					}
					else
					{
						for (int num7 = 0; num7 <= Copied2[num5].Codes.Count - 1; num7++)
						{
							sewingVertex2.Codes.Add(Copied2[num5].Codes[num7]);
						}
					}
					buEntity2.Sewing.Vertex.Add(sewingVertex2);
				}
				continue;
			}
			List<Point3D> Points = new List<Point3D>();
			for (int num8 = 1; num8 <= buEntity2.Vertices.Count - 1; num8++)
			{
				List<Point3D> pntDevided2 = new List<Point3D>();
				double num9 = Point3D.Distance(buEntity2.Vertices[num8 - 1], buEntity2.Vertices[num8]);
				buEntity refEntity = new buLine(buEntity2.Vertices[num8 - 1], buEntity2.Vertices[num8]);
				double devideLength2 = buEntity2.Sewing.StitchLengt;
				if ((Copied.Count > 1) & !Options.ProtectEntityStitchLen)
				{
					Entity copiedEntity3 = null;
					buEntity.Copy(buEntity2, ref copiedEntity3);
					Convert.ToInt32(num9 / buEntity2.Sewing.StitchLengt);
					double num10 = ((ICurve)copiedEntity3).Length();
					devideLength2 = num10 / (double)(Copied.Count - 1);
				}
				clsInit.cVector5.EntityDevideByCamDir(refEntity, devideLength2, ref pntDevided2);
				Points.AddRange(pntDevided2);
			}
			List<SewingVertex> Copied3 = new List<SewingVertex>();
			SewingVertex.Copy(buEntity2.Sewing.Vertex, ref Copied3);
			buEntity2.Sewing.Vertex.Clear();
			buEntity2.Sewing.Vertex = new List<SewingVertex>();
			clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref Points);
			if (Points.Count > 0)
			{
				for (int num11 = 0; num11 <= Points.Count - 1; num11++)
				{
					CustomData customData3 = new CustomData();
					if (num11 > 0)
					{
						Line line2 = new Line(Points[num11 - 1], Points[num11]);
						line2.LineWeight = (float)Options.DrawigThickness;
						line2.Color = Options.DrawingColor;
						line2.ColorMethod = colorMethodType.byEntity;
						if (Options.DrawingLayerName.Length > 0)
						{
							line2.LayerName = Options.DrawingLayerName;
						}
						customData3 = new CustomData();
						customData3.RefIndex = i;
						line2.EntityData = customData3;
						screenDrawEntities.Add(line2);
					}
					devDept.Eyeshot.Entities.Point point3 = new devDept.Eyeshot.Entities.Point(Points[num11]);
					point3.LineWeight = (float)Options.PointThickness;
					point3.Color = Options.PointColor;
					point3.ColorMethod = colorMethodType.byEntity;
					if (Options.PointLayerName.Length > 0)
					{
						point3.LayerName = Options.PointLayerName;
					}
					customData3 = new CustomData();
					customData3.RefIndex = i;
					point3.EntityData = customData3;
					screenPointEntities.Add(point3);
					buEntity2.Sewing.Vertex.Add(new SewingVertex(Points[num11]));
				}
			}
			if (Copied3.Count > Points.Count || Copied3.Count > Points.Count || !((Copied3.Count > 0) & (buEntity2.Sewing.Vertex.Count > 0)))
			{
				continue;
			}
			if (Copied3.Count != 1)
			{
				buEntity2.Sewing.Vertex[0].DeltaX = Copied3[0].DeltaX;
				buEntity2.Sewing.Vertex[0].DeltaY = Copied3[0].DeltaY;
				for (int num12 = 0; num12 <= Copied3[0].Codes.Count - 1; num12++)
				{
					buEntity2.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied3[0].Codes[num12]));
				}
				buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaX = Copied3[Copied3.Count - 1].DeltaX;
				buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].DeltaY = Copied3[Copied3.Count - 1].DeltaY;
				for (int num13 = 0; num13 <= Copied3[Copied3.Count - 1].Codes.Count - 1; num13++)
				{
					buEntity2.Sewing.Vertex[buEntity2.Sewing.Vertex.Count - 1].Codes.Add(new SewingCode(Copied3[Copied3.Count - 1].Codes[num13]));
				}
			}
			else
			{
				buEntity2.Sewing.Vertex[0].DeltaX = Copied3[0].DeltaX;
				buEntity2.Sewing.Vertex[0].DeltaY = Copied3[0].DeltaY;
				for (int num14 = 0; num14 <= Copied3[0].Codes.Count - 1; num14++)
				{
					buEntity2.Sewing.Vertex[0].Codes.Add(new SewingCode(Copied3[0].Codes[num14]));
				}
			}
		}
	}

	public void doDefinePunteriz(Point3D refPoint, bool ShowDialog = false)
	{
		bool flag = false;
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			if (!SewingBase.MainEntityList[i].Sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1; j++)
			{
				double num = Point3D.Distance(SewingBase.MainEntityList[i].Sewing.Vertex[j].Point, refPoint);
				if (!(num < Sketcher2D.PixelVsMilimeter * 10.0 && !flag))
				{
					continue;
				}
				flag = true;
				F_SewingPunteriz f_SewingPunteriz = new F_SewingPunteriz();
				f_SewingPunteriz.PunterizHeight = varSewingRunSettings.PunterizHeigth;
				f_SewingPunteriz.PunterizLength = varSewingRunSettings.PunterizLength;
				f_SewingPunteriz.PunterizType = varSewingRunSettings.PunterizType;
				f_SewingPunteriz.PunterizWidth = varSewingRunSettings.PunterizWidth;
				f_SewingPunteriz.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_SewingPunteriz.Properties.FormPosition = FormStartPosition.CenterScreen;
				if (ShowDialog)
				{
					f_SewingPunteriz.Init();
					f_SewingPunteriz.ShowDialog();
				}
				if (okCommandWithThreeDataEventHandler_0 != null)
				{
					okCommandWithThreeDataEventHandler_0("Punterez", null, null);
					f_SewingPunteriz.PunterizHeight = varSewingRunSettings.PunterizHeigth;
					f_SewingPunteriz.PunterizLength = varSewingRunSettings.PunterizLength;
					f_SewingPunteriz.PunterizType = varSewingRunSettings.PunterizType;
					f_SewingPunteriz.PunterizWidth = varSewingRunSettings.PunterizWidth;
				}
				if ((f_SewingPunteriz.Properties.Result == DialogResult.OK || !ShowDialog) & !CancelApplied)
				{
					UndoBuffer();
					varSewingRunSettings.PunterizHeigth = f_SewingPunteriz.PunterizHeight;
					varSewingRunSettings.PunterizLength = f_SewingPunteriz.PunterizLength;
					varSewingRunSettings.PunterizType = f_SewingPunteriz.PunterizType;
					varSewingRunSettings.PunterizWidth = f_SewingPunteriz.PunterizWidth;
					if (j == 0)
					{
						SewingBase.MainEntityList[i].Sewing.StartStitchType = SewingAddStitchType.None;
						SewingBase.MainEntityList[i].Sewing.StartStitchCount = 0;
					}
					if (j == SewingBase.MainEntityList[i].Sewing.Vertex.Count - 1)
					{
						SewingBase.MainEntityList[i].Sewing.EndStitchType = SewingAddStitchType.None;
						SewingBase.MainEntityList[i].Sewing.EndStitchCount = 0;
					}
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez = new SewingPunteriz();
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez.Height = varSewingRunSettings.PunterizHeigth;
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez.Width = varSewingRunSettings.PunterizWidth;
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez.Length = varSewingRunSettings.PunterizLength;
					SewingBase.MainEntityList[i].Sewing.Vertex[j].Punterez.PunterizType = varSewingRunSettings.PunterizType;
					JobUpdate();
					CancelApplied = false;
				}
			}
		}
		clsInit.appEditor.action = actionTypeBU.None;
	}

	public void doDefineLockStitch(Point3D refPoint, bool ShowDialog = false)
	{
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (!sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num = Point3D.Distance(sewing.Vertex[j].Point, refPoint);
				if (!(num < Sketcher2D.PixelVsMilimeter * 10.0))
				{
					continue;
				}
				F_SewingExtend f_SewingExtend = new F_SewingExtend();
				if (j == 0)
				{
					f_SewingExtend.StitchCount = sewing.StartStitchCount;
					f_SewingExtend.ExtendType = sewing.StartStitchType;
					f_SewingExtend.Properties.FormCloseMode = FormCloseModeType.Dispose;
					f_SewingExtend.Properties.FormPosition = FormStartPosition.CenterScreen;
					if (f_SewingExtend.StitchCount == 0)
					{
						f_SewingExtend.StitchCount = 5;
					}
					if (f_SewingExtend.ExtendType == SewingAddStitchType.None)
					{
						f_SewingExtend.ExtendType = SewingAddStitchType.TwoWay;
					}
					if (ShowDialog)
					{
						f_SewingExtend.Init();
						f_SewingExtend.ShowDialog();
					}
					if (okCommandWithThreeDataEventHandler_0 != null)
					{
						okCommandWithThreeDataEventHandler_0("LockStitch", null, null);
						f_SewingExtend.StitchCount = varSewingRunSettings.LockStitcCount;
						f_SewingExtend.ExtendType = varSewingRunSettings.LockStitchType;
					}
					if ((f_SewingExtend.Properties.Result == DialogResult.OK || !ShowDialog) & !CancelApplied)
					{
						UndoBuffer();
						SewingBase.MainEntityList[i].Sewing.StartStitchCount = f_SewingExtend.StitchCount;
						SewingBase.MainEntityList[i].Sewing.StartStitchType = f_SewingExtend.ExtendType;
					}
				}
				if (j == sewing.Vertex.Count - 1)
				{
					f_SewingExtend.StitchCount = sewing.EndStitchCount;
					f_SewingExtend.ExtendType = sewing.EndStitchType;
					f_SewingExtend.Properties.FormCloseMode = FormCloseModeType.Dispose;
					f_SewingExtend.Properties.FormPosition = FormStartPosition.CenterScreen;
					if (f_SewingExtend.StitchCount == 0)
					{
						f_SewingExtend.StitchCount = 5;
					}
					if (f_SewingExtend.ExtendType == SewingAddStitchType.None)
					{
						f_SewingExtend.ExtendType = SewingAddStitchType.TwoWay;
					}
					if (ShowDialog)
					{
						f_SewingExtend.Init();
						f_SewingExtend.ShowDialog();
					}
					if (okCommandWithThreeDataEventHandler_0 != null)
					{
						okCommandWithThreeDataEventHandler_0("LockStitch", null, null);
						f_SewingExtend.StitchCount = varSewingRunSettings.LockStitcCount;
						f_SewingExtend.ExtendType = varSewingRunSettings.LockStitchType;
					}
					if ((f_SewingExtend.Properties.Result == DialogResult.OK || !ShowDialog) & !CancelApplied)
					{
						UndoBuffer();
						SewingBase.MainEntityList[i].Sewing.EndStitchCount = f_SewingExtend.StitchCount;
						SewingBase.MainEntityList[i].Sewing.EndStitchType = f_SewingExtend.ExtendType;
					}
				}
			}
		}
		clsInit.appEditor.action = actionTypeBU.None;
	}

	public void doDefineAddCodes(Point3D refPoint)
	{
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (!sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num = Point2D.Distance(sewing.Vertex[j].Point, refPoint);
				if (!(num < Sketcher2D.PixelVsMilimeter * 10.0))
				{
					continue;
				}
				F_SewingCodes f_SewingCodes = new F_SewingCodes();
				for (int k = 0; k <= definedCodes.Count - 1; k++)
				{
					f_SewingCodes.CodesDefined.Add(new SewingCode(definedCodes[k]));
				}
				for (int l = 0; l <= sewing.Vertex[j].Codes.Count - 1; l++)
				{
					f_SewingCodes.Codes.Add(new SewingCode(sewing.Vertex[j].Codes[l]));
				}
				UndoBuffer();
				f_SewingCodes.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_SewingCodes.Properties.FormPosition = FormStartPosition.CenterScreen;
				f_SewingCodes.Init();
				f_SewingCodes.ShowDialog();
				if (f_SewingCodes.Properties.Result != DialogResult.OK)
				{
					clsInit.appEditor.Reset();
					return;
				}
				sewing.Vertex[j].Codes.Clear();
				for (int m = 0; m <= f_SewingCodes.Codes.Count - 1; m++)
				{
					sewing.Vertex[j].Codes.Add(new SewingCode(f_SewingCodes.Codes[m]));
				}
				clsInit.appEditor.Reset();
				return;
			}
		}
		for (int n = 0; n <= SewingBase.MainEntityList.Count - 1; n++)
		{
			SewingInfo sewing2 = SewingBase.MainEntityList[n].Sewing;
			for (int num2 = 0; num2 <= sewing2.Vertex.Count - 1; num2++)
			{
				double num3 = Point3D.Distance(sewing2.Vertex[num2].Point, refPoint);
				if (!(num3 < Sketcher2D.PixelVsMilimeter * 10.0))
				{
					continue;
				}
				F_SewingCodes f_SewingCodes2 = new F_SewingCodes();
				for (int num4 = 0; num4 <= definedCodes.Count - 1; num4++)
				{
					f_SewingCodes2.CodesDefined.Add(new SewingCode(definedCodes[num4]));
				}
				for (int num5 = 0; num5 <= sewing2.Vertex[num2].Codes.Count - 1; num5++)
				{
					f_SewingCodes2.Codes.Add(new SewingCode(sewing2.Vertex[num2].Codes[num5]));
				}
				UndoBuffer();
				f_SewingCodes2.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_SewingCodes2.Properties.FormPosition = FormStartPosition.CenterScreen;
				f_SewingCodes2.Init();
				f_SewingCodes2.ShowDialog();
				if (f_SewingCodes2.Properties.Result != DialogResult.OK)
				{
					clsInit.appEditor.Reset();
					return;
				}
				sewing2.Vertex[num2].Codes.Clear();
				for (int num6 = 0; num6 <= f_SewingCodes2.Codes.Count - 1; num6++)
				{
					sewing2.Vertex[num2].Codes.Add(new SewingCode(f_SewingCodes2.Codes[num6]));
				}
				clsInit.appEditor.Reset();
				return;
			}
		}
		clsInit.appEditor.Reset();
	}

	public void doDefineScale(Point3D refPoint, bool ShowDialog = false)
	{
		Selected.Clear();
		Sketcher2D.selectedPoint.Clear();
		clsItem.frmEditor.viewport.TempEntities.Clear();
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (!sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num = Point3D.Distance(sewing.Vertex[j].Point, refPoint);
				if (!(num < Sketcher2D.PixelVsMilimeter * 10.0) || !((j == 0) | (j == sewing.Vertex.Count - 1)))
				{
					continue;
				}
				SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
				if (j == 0)
				{
					if (!buCompare5.EQ(sewing.Vertex[0].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						if (!buCompare5.EQ(sewing.Vertex[0].Point, SewingBase.MainEntityList[i].EndPoint))
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.Middle;
						}
						else
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.End;
						}
					}
					else
					{
						sewingSelectedPoint.CatchPosition = StartMiddleEndType.Start;
					}
				}
				if (j == sewing.Vertex.Count - 1)
				{
					if (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						if (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, SewingBase.MainEntityList[i].EndPoint))
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.Middle;
						}
						else
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.End;
						}
					}
					else
					{
						sewingSelectedPoint.CatchPosition = StartMiddleEndType.Start;
					}
				}
				sewingSelectedPoint.EntityIndex = i;
				sewingSelectedPoint.VertexIndex = j;
				sewingSelectedPoint.refPoint = buVector5.ToPoint3D(sewing.Vertex[j].Point);
				Selected.Add(sewingSelectedPoint);
				Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
			}
		}
		if (Selected.Count == 0)
		{
			for (int k = 0; k <= SewingBase.MainEntityList.Count - 1; k++)
			{
				SewingInfo sewing2 = SewingBase.MainEntityList[k].Sewing;
				if (sewing2.isStitchDrawing)
				{
					continue;
				}
				double num2 = Point3D.Distance(SewingBase.MainEntityList[k].StartPoint, refPoint);
				double num3 = Point3D.Distance(SewingBase.MainEntityList[k].EndPoint, refPoint);
				if (!(num2 < Sketcher2D.PixelVsMilimeter * 10.0))
				{
					if (num3 < Sketcher2D.PixelVsMilimeter * 10.0)
					{
						SewingSelectedPoint sewingSelectedPoint2 = new SewingSelectedPoint();
						sewingSelectedPoint2.CatchPosition = StartMiddleEndType.End;
						sewingSelectedPoint2.EntityIndex = k;
						sewingSelectedPoint2.VertexIndex = -1;
						sewingSelectedPoint2.refPoint = buVector5.ToPoint3D(SewingBase.MainEntityList[k].EndPoint);
						Selected.Add(sewingSelectedPoint2);
						Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint2.refPoint));
					}
				}
				else
				{
					SewingSelectedPoint sewingSelectedPoint3 = new SewingSelectedPoint();
					sewingSelectedPoint3.CatchPosition = StartMiddleEndType.Start;
					sewingSelectedPoint3.EntityIndex = k;
					sewingSelectedPoint3.VertexIndex = -1;
					sewingSelectedPoint3.refPoint = buVector5.ToPoint3D(SewingBase.MainEntityList[k].StartPoint);
					Selected.Add(sewingSelectedPoint3);
					Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint3.refPoint));
				}
			}
		}
		if (Selected.Count > 0)
		{
			if (frmMove == null)
			{
				frmMove = new F_SewingMove();
				frmMove.MoveCommad += MoveCommand;
				frmMove.CancelCommad += MoveCancel;
			}
			if (varSewingRunSettings.MoveDistance <= 0.0)
			{
				varSewingRunSettings.MoveDistance = 1.0;
			}
			frmMove.MoveDis = varSewingRunSettings.MoveDistance;
			frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
			frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
			frmMove.Properties.TopMost = true;
			frmMove.btn_anglePlus.Visible = true;
			frmMove.btn_angleMinus.Visible = true;
			if (ShowDialog)
			{
				frmMove.Init();
				frmMove.Show();
			}
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				okCommandWithThreeDataEventHandler_0("Scale", null, null);
			}
		}
	}

	public void doDefineRotate(Point3D refPoint, bool ShowDialog = false)
	{
		Selected.Clear();
		Sketcher2D.selectedPoint.Clear();
		clsItem.frmEditor.viewport.TempEntities.Clear();
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (!sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num = Point3D.Distance(sewing.Vertex[j].Point, refPoint);
				if (!(num < Sketcher2D.PixelVsMilimeter * 10.0) || !((j == 0) | (j == sewing.Vertex.Count - 1)))
				{
					continue;
				}
				SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
				if (j == 0)
				{
					if (!buCompare5.EQ(sewing.Vertex[0].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						if (!buCompare5.EQ(sewing.Vertex[0].Point, SewingBase.MainEntityList[i].EndPoint))
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.Middle;
						}
						else
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.End;
						}
					}
					else
					{
						sewingSelectedPoint.CatchPosition = StartMiddleEndType.Start;
					}
				}
				if (j == sewing.Vertex.Count - 1)
				{
					if (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						if (!buCompare5.EQ(sewing.Vertex[sewing.Vertex.Count - 1].Point, SewingBase.MainEntityList[i].EndPoint))
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.Middle;
						}
						else
						{
							sewingSelectedPoint.CatchPosition = StartMiddleEndType.End;
						}
					}
					else
					{
						sewingSelectedPoint.CatchPosition = StartMiddleEndType.Start;
					}
				}
				sewingSelectedPoint.EntityIndex = i;
				sewingSelectedPoint.VertexIndex = j;
				sewingSelectedPoint.refPoint = buVector5.ToPoint3D(sewing.Vertex[j].Point);
				Selected.Add(sewingSelectedPoint);
				Sketcher2D.selectedPoint.Add(buVector5.ToPoint3D(sewingSelectedPoint.refPoint));
			}
		}
		if (Selected.Count <= 0)
		{
			return;
		}
		if (Selected.Count > 1)
		{
			DialogBoxList dialogBoxList = new DialogBoxList();
			for (int k = 0; k <= Selected.Count - 1; k++)
			{
				Point3D insPoint = clsInit.cVector5.MiddlePointOfLine(SewingBase.MainEntityList[Selected[k].EntityIndex].StartPoint, SewingBase.MainEntityList[Selected[k].EntityIndex].EndPoint);
				Text item = new Text(Plane.XY, insPoint, (k + 1).ToString(), 10.0);
				clsItem.frmEditor.viewport.Entities.Add(item);
				dialogBoxList.Items.Add((k + 1).ToString());
			}
			clsItem.frmEditor.viewport.Invalidate();
			dialogBoxList.Width = 200;
			dialogBoxList.Height = 150;
			dialogBoxList.Init();
			dialogBoxList.ShowDialog();
			int selectedIndex = dialogBoxList.SelectedIndex;
			if (selectedIndex != 0)
			{
				if (selectedIndex != Selected.Count - 1)
				{
					for (int num2 = Selected.Count - 1; num2 >= selectedIndex + 1; num2--)
					{
						Selected.RemoveAt(num2);
					}
					for (int num3 = selectedIndex - 1; num3 >= 0; num3--)
					{
						Selected.RemoveAt(num3);
					}
				}
				else
				{
					for (int num4 = Selected.Count - 2; num4 >= 0; num4--)
					{
						Selected.RemoveAt(num4);
					}
				}
			}
			else
			{
				for (int num5 = Selected.Count - 1; num5 >= 1; num5--)
				{
					Selected.RemoveAt(num5);
				}
			}
		}
		if (!ShowDialog)
		{
			if (okCommandWithThreeDataEventHandler_0 != null)
			{
				okCommandWithThreeDataEventHandler_0("Rotate", null, null);
				if (!CancelApplied)
				{
					RotateCommand("Plus", varSewingRunSettings.RotateDegree);
				}
			}
			return;
		}
		if (frmRotate == null)
		{
			frmRotate = new F_SewingRotate();
			frmRotate.RotateCommad += RotateCommand;
			frmRotate.CancelCommad += MoveCancel;
		}
		frmRotate.RotateDegree = varSewingRunSettings.RotateDegree;
		frmRotate.Properties.FormCloseMode = FormCloseModeType.Invisible;
		frmRotate.Properties.FormPosition = FormStartPosition.CenterScreen;
		frmRotate.Properties.TopMost = true;
		frmRotate.Init();
		frmRotate.Show();
	}

	public void doDefineMove()
	{
		Selected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		new List<int>();
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (Sketcher2D.entitiesSelected[i].EntityData != null && Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
					if ((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1))
					{
						SewingSelectedPoint sewingSelectedPoint = new SewingSelectedPoint();
						sewingSelectedPoint.EntityIndex = sewingEntityCustomData.indexEntity;
						Selected.Add(sewingSelectedPoint);
					}
				}
			}
		}
		if (Selected.Count > 0)
		{
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[4], buLangTranslate.preDef.Sewing);
			if (frmMove == null)
			{
				frmMove = new F_SewingMove();
				frmMove.MoveCommad += MoveCommand;
				frmMove.CancelCommad += MoveCancel;
			}
			if (varSewingRunSettings.MoveDistance <= 0.0)
			{
				varSewingRunSettings.MoveDistance = 1.0;
			}
			frmMove.MoveDis = varSewingRunSettings.MoveDistance;
			frmMove.Properties.FormCloseMode = FormCloseModeType.Invisible;
			frmMove.Properties.FormPosition = FormStartPosition.CenterScreen;
			frmMove.Properties.TopMost = true;
			frmMove.btn_anglePlus.Visible = false;
			frmMove.btn_angleMinus.Visible = false;
			frmMove.Init();
			frmMove.Show();
		}
	}

	public void doDefineSelectVertex(Point3D refPoint, actionTypeBU action)
	{
		Selected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		new List<int>();
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (Sketcher2D.entitiesSelected[i].EntityData == null || !(Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData))
				{
					continue;
				}
				SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
				if (!((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1)) || !((sewingEntityCustomData.indexVertex >= 0) & (sewingEntityCustomData.indexVertex <= SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.Vertex.Count - 1)))
				{
					continue;
				}
				SewingVertex sewingVertex = SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.Vertex[sewingEntityCustomData.indexVertex];
				baseSelected = new SewingSelectedPoint();
				baseSelected.EntityIndex = sewingEntityCustomData.indexEntity;
				baseSelected.VertexIndex = sewingEntityCustomData.indexVertex;
				baseSelected.refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
				if (sewingEntityCustomData.indexVertex != 0)
				{
					if (sewingEntityCustomData.indexVertex != SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.Vertex.Count - 1)
					{
						baseSelected.CatchPosition = StartMiddleEndType.Middle;
					}
					else
					{
						baseSelected.CatchPosition = StartMiddleEndType.End;
					}
				}
				else
				{
					baseSelected.CatchPosition = StartMiddleEndType.Start;
				}
				Selected.Add(baseSelected);
				i = Sketcher2D.entitiesSelected.Count;
			}
		}
		if (baseSelected != null)
		{
			Sketcher2D.selectedCircle.Clear();
			for (int j = 0; j <= Selected.Count - 1; j++)
			{
				Circle circle = new Circle(Plane.XY, buVector5.ToPoint3D(Selected[j].refPoint), 0.8);
				circle.Color = Color.Cyan;
				Sketcher2D.selectedCircle.Add(circle);
			}
			clsItem.frmEditor.viewport.Invalidate();
			clsInit.appEditor.StatusUpdate(buSewingCalc.LangSewingStatus[7], buLangTranslate.preDef.Sewing);
			if (frmSelectVertex == null)
			{
				frmSelectVertex = new F_SewingSelectVertex();
				frmSelectVertex.SelectCommad += SelectVertexCommand;
				frmSelectVertex.CancelCommad += MoveCancel;
			}
			frmSelectVertex.Properties.FormCloseMode = FormCloseModeType.Invisible;
			frmSelectVertex.Properties.FormPosition = FormStartPosition.CenterScreen;
			frmSelectVertex.Properties.TopMost = true;
			frmSelectVertex.ShowDialog = varSewingRunSettings.ShowDialog;
			frmSelectVertex.Init();
			frmSelectVertex.Show();
		}
	}

	public void doChangeDirection(Point3D refPoint, actionTypeBU action)
	{
		Selected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		new List<int>();
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			UndoBuffer();
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (Sketcher2D.entitiesSelected[i].EntityData != null && Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData)
				{
					SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
					if (((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[sewingEntityCustomData.indexEntity] is buLine)
					{
						Point3D endPoint = buVector5.ToPoint3D(SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].StartPoint);
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].StartPoint = buVector5.ToPoint3D(SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].EndPoint);
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].EndPoint = endPoint;
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Update(buEntityUpdateType.Line);
						SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing.Vertex.Reverse();
					}
				}
			}
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		clsInit.appEditor.Reset();
	}

	public void doDeleteAll()
	{
		if (buString5.MessageBoxQuestion(buSewingCalc.LangSewingMessage[1]) == DialogResult.Yes)
		{
			UndoBuffer();
			SewingBase.MainEntityList.Clear();
			SewingBase.SimilationPoint.SimMove.Clear();
			SewingBase = new SewingMain();
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
	}

	public void doDeleteVertex(Point3D refPoint)
	{
		Selected.Clear();
		Sketcher2D.selectedPoint.Clear();
		clsItem.frmEditor.viewport.TempEntities.Clear();
		int num = -1;
		Point3D point3D = null;
		Point3D point3D2 = null;
		UndoBuffer();
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (!sewing.isStitchDrawing)
			{
				continue;
			}
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num2 = Point3D.Distance(sewing.Vertex[j].Point, refPoint);
				if (!(num2 < Sketcher2D.PixelVsMilimeter * 10.0) || !((j == 0) | (j == sewing.Vertex.Count - 1)))
				{
					continue;
				}
				point3D = new Point3D(sewing.Vertex[j].Point.X + sewing.Vertex[j].DeltaX, sewing.Vertex[j].Point.Y + sewing.Vertex[j].DeltaY);
				num = i;
				if (j == 0)
				{
					if (buCompare5.EQ(sewing.Vertex[j].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						point3D2 = new Point3D(sewing.Vertex[j + 1].Point.X + sewing.Vertex[j + 1].DeltaX, sewing.Vertex[j + 1].Point.Y + sewing.Vertex[j + 1].DeltaY);
						SewingBase.MainEntityList[i].StartPoint = new Point3D(sewing.Vertex[j + 1].Point.X + sewing.Vertex[j + 1].DeltaX, sewing.Vertex[j + 1].Point.Y + sewing.Vertex[j + 1].DeltaY);
					}
					if (buCompare5.EQ(sewing.Vertex[j].Point, SewingBase.MainEntityList[i].EndPoint))
					{
						point3D2 = new Point3D(sewing.Vertex[j + 1].Point.X + sewing.Vertex[j + 1].DeltaX, sewing.Vertex[j + 1].Point.Y + sewing.Vertex[j + 1].DeltaY);
						SewingBase.MainEntityList[i].EndPoint = buVector5.ToPoint3D(sewing.Vertex[j + 1].Point);
					}
				}
				if (j == sewing.Vertex.Count - 1)
				{
					if (buCompare5.EQ(sewing.Vertex[j].Point, SewingBase.MainEntityList[i].StartPoint))
					{
						point3D2 = new Point3D(sewing.Vertex[j - 1].Point.X + sewing.Vertex[j - 1].DeltaX, sewing.Vertex[j - 1].Point.Y + sewing.Vertex[j - 1].DeltaY);
						SewingBase.MainEntityList[i].StartPoint = new Point3D(sewing.Vertex[j - 1].Point.X + sewing.Vertex[j - 1].DeltaX, sewing.Vertex[j - 1].Point.Y + sewing.Vertex[j - 1].DeltaY);
					}
					if (buCompare5.EQ(sewing.Vertex[j].Point, SewingBase.MainEntityList[i].EndPoint))
					{
						point3D2 = new Point3D(sewing.Vertex[j - 1].Point.X + sewing.Vertex[j - 1].DeltaX, sewing.Vertex[j - 1].Point.Y + sewing.Vertex[j - 1].DeltaY);
						SewingBase.MainEntityList[i].EndPoint = new Point3D(sewing.Vertex[j - 1].Point.X + sewing.Vertex[j - 1].DeltaX, sewing.Vertex[j - 1].Point.Y + sewing.Vertex[j - 1].DeltaY);
					}
				}
				if (SewingBase.MainEntityList[i] is buLine)
				{
					SewingBase.MainEntityList[i].Update(buEntityUpdateType.Line);
				}
				if (SewingBase.MainEntityList[i] is buArc)
				{
					SewingBase.MainEntityList[i].Update(buEntityUpdateType.Arc3Point3D);
				}
			}
			if (!((num >= 0) & (point3D != null) & (point3D2 != null)))
			{
				continue;
			}
			for (int k = 0; k <= SewingBase.MainEntityList.Count - 1; k++)
			{
				if (k == num)
				{
					continue;
				}
				if (!buCompare5.EQ(point3D, SewingBase.MainEntityList[k].StartPoint))
				{
					if (buCompare5.EQ(point3D, SewingBase.MainEntityList[k].EndPoint))
					{
						SewingBase.MainEntityList[k].EndPoint.X = point3D2.X;
						SewingBase.MainEntityList[k].EndPoint.Y = point3D2.Y;
					}
				}
				else
				{
					SewingBase.MainEntityList[k].StartPoint.X = point3D2.X;
					SewingBase.MainEntityList[k].StartPoint.Y = point3D2.Y;
				}
			}
		}
		if (num < 0)
		{
			if (UndoList.Count > 0)
			{
				UndoList.RemoveAt(UndoList.Count - 1);
			}
		}
		else
		{
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		}
	}

	public void doDeleteByQuestion(Point3D refPoint)
	{
		int num = -1;
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			for (int j = 0; j <= sewing.Vertex.Count - 1; j++)
			{
				double num2 = Point3D.Distance(sewing.Vertex[j].Point, refPoint);
				if (num2 < Sketcher2D.PixelVsMilimeter * 10.0)
				{
					num = i;
					j = sewing.Vertex.Count;
					i = SewingBase.MainEntityList.Count;
				}
			}
		}
		if (num == -1)
		{
			Sketcher2D.entitiesSelected.Clear();
			clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
			if (Sketcher2D.entitiesSelected.Count > 0)
			{
				for (int k = 0; k <= Sketcher2D.entitiesSelected.Count - 1; k++)
				{
					if (Sketcher2D.entitiesSelected[k].EntityData != null && Sketcher2D.entitiesSelected[k].EntityData is SewingEntityCustomData)
					{
						SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[k].EntityData as SewingEntityCustomData;
						if ((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1))
						{
							num = sewingEntityCustomData.indexEntity;
							k = Sketcher2D.entitiesSelected.Count;
						}
					}
				}
			}
		}
		if (num < 0)
		{
			return;
		}
		UndoBuffer();
		if (buString5.MessageBoxQuestion(buSewingCalc.LangSewingMessage[0]) != DialogResult.Yes)
		{
			SewingBase.MainEntityList.RemoveAt(num);
		}
		else if (!((num > 0) & (num < SewingBase.MainEntityList.Count - 1)))
		{
			if (num != 0)
			{
				if (num == SewingBase.MainEntityList.Count - 1)
				{
					SewingBase.MainEntityList.RemoveAt(num);
				}
			}
			else
			{
				SewingBase.MainEntityList.RemoveAt(num);
			}
		}
		else
		{
			int num3 = -1;
			List<int> RefList = new List<int>();
			RefList.Add(num);
			for (int l = num + 1; l <= SewingBase.MainEntityList.Count - 1; l++)
			{
				if (!SewingBase.MainEntityList[l].Sewing.isStitchDrawing)
				{
					RefList.Add(l);
					continue;
				}
				num3 = l;
				l = SewingBase.MainEntityList.Count;
			}
			if (num3 >= 0)
			{
				SewingBase.MainEntityList[num - 1].EndPoint = buVector5.ToPoint3D(SewingBase.MainEntityList[num3].StartPoint);
				if (!(SewingBase.MainEntityList[num - 1] is buLine))
				{
					if (SewingBase.MainEntityList[num - 1] is buArc)
					{
						SewingBase.MainEntityList[num - 1].Update(buEntityUpdateType.Arc3Point3D);
					}
				}
				else
				{
					SewingBase.MainEntityList[num - 1].Update(buEntityUpdateType.Line);
				}
			}
			clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
			for (int m = 0; m <= RefList.Count - 1; m++)
			{
				SewingBase.MainEntityList.RemoveAt(RefList[m]);
			}
		}
		DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		clsInit.appEditor.Reset();
	}

	public void doDelete()
	{
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		List<int> RefList = new List<int>();
		if (Sketcher2D.entitiesSelected.Count > 0)
		{
			for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
			{
				if (!((Sketcher2D.entitiesSelected[i].EntityData != null) & (Sketcher2D.entitiesSelected[i] is ICurve)) || !((Sketcher2D.entitiesSelected[i].EntityData is SewingEntityCustomData) & (Sketcher2D.entitiesSelected[i].GetType() != typeof(devDept.Eyeshot.Entities.Point))))
				{
					continue;
				}
				SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[i].EntityData as SewingEntityCustomData;
				if (!((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1)))
				{
					continue;
				}
				if (RefList.Count != 0)
				{
					bool flag = true;
					for (int j = 0; j <= RefList.Count - 1; j++)
					{
						if (RefList[j] == sewingEntityCustomData.indexEntity)
						{
							flag = false;
						}
					}
					if (flag)
					{
						RefList.Add(sewingEntityCustomData.indexEntity);
					}
				}
				else
				{
					RefList.Add(sewingEntityCustomData.indexEntity);
				}
			}
		}
		if (RefList.Count > 0)
		{
			UndoBuffer();
		}
		clsInit.cVector5.SortList(SortDirectionType.Bigger, ref RefList);
		for (int k = 0; k <= RefList.Count - 1; k++)
		{
			SewingBase.MainEntityList.RemoveAt(RefList[k]);
		}
		if (RefList.Count > 0)
		{
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
		}
		clsInit.appEditor.Reset();
	}

	public void doOffset(double Offset, LeftRightType Type)
	{
		Sketcher2D.entitiesSelected.Clear();
		clsInit.cVector5.SelectedEntitiesToEntityList(clsItem.frmEditor.viewport.Entities, Clone: false, ref Sketcher2D.entitiesSelected);
		double num = 2.0;
		if (Type == LeftRightType.Right)
		{
			num = -2.0;
		}
		clsVar.varEditorRuntimeSet.OffsetValue = Offset;
		for (int i = 0; i <= Sketcher2D.entitiesSelected.Count - 1; i++)
		{
			Entity entity = (Entity)Sketcher2D.entitiesSelected[i].Clone();
			if (entity.Vertices == null)
			{
				entity.Regen(0.01);
			}
			ICurve curve = (ICurve)entity;
			double num2 = clsInit.cVector5.PointAngle(entity.Vertices[1], entity.Vertices[0]);
			Entity entityOffseted = null;
			Point3D EndPnt = new Point3D();
			clsInit.cVector5.LineWithLengthAndAngle(entity.Vertices[0], curve.Length() / 2.0, num2 + num, ref EndPnt);
			if (clsInit.appEditor.Offset(entity, EndPnt, ref entityOffseted))
			{
				if (entityOffseted != null)
				{
					entityOffseted.ColorMethod = colorMethodType.byEntity;
					entityOffseted.Color = clsVar.varEditorSet.colorEntity;
					entityOffseted.LineWeight = (float)clsVar.varEditorSet.thicknessEntity;
					entityOffseted.LineWeightMethod = colorMethodType.byEntity;
					clsInit.appSewing.doOffset(entityOffseted);
				}
				continue;
			}
			break;
		}
	}

	public void doOffset(Entity entityOffseted)
	{
		SewingInfo sewingInfo = null;
		if (Sketcher2D.entitiesSelected.Count > 0 && Sketcher2D.entitiesSelected[0].EntityData != null && Sketcher2D.entitiesSelected[0].EntityData is SewingEntityCustomData)
		{
			SewingEntityCustomData sewingEntityCustomData = Sketcher2D.entitiesSelected[0].EntityData as SewingEntityCustomData;
			if ((sewingEntityCustomData.indexEntity >= 0) & (sewingEntityCustomData.indexEntity <= SewingBase.MainEntityList.Count - 1))
			{
				sewingInfo = new SewingInfo(SewingBase.MainEntityList[sewingEntityCustomData.indexEntity].Sewing);
			}
		}
		if (entityOffseted != null)
		{
			UndoBuffer();
			buEntity copiedEntity = null;
			buEntity.Copy(entityOffseted, ref copiedEntity);
			if (sewingInfo == null)
			{
				copiedEntity.Sewing = new SewingInfo();
				copiedEntity.Sewing.StitchLengt = varSewingSettings.defaultStitchLength;
			}
			else
			{
				sewingInfo.Vertex.Clear();
				copiedEntity.Sewing = new SewingInfo(sewingInfo);
			}
			SewingBase.MainEntityList.Add(copiedEntity);
			doDevideEntitiesByLength(ref SewingBase.MainEntityList, new SewingDevideOptions());
			DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			clsInit.appEditor.Reset();
		}
	}

	public void doPunteriz(Point3D refPoint, Point3D nextPoint, double Width, double Height, SewingPunterizType Type, ref List<Point3D> calcPoints)
	{
		calcPoints = new List<Point3D>();
		double num = Point3D.Distance(refPoint, nextPoint);
		int count = Convert.ToInt32(num / Width);
		double angle = clsInit.cVector5.PointAngle(nextPoint, refPoint);
		doPunteriz(refPoint, num, Height, count, angle, Type, ref calcPoints);
	}

	public void doPunteriz(Point3D refPoint, double Length, double Width, double Height, double Angle, SewingPunterizType Type, ref List<Point3D> calcPoints)
	{
		calcPoints = new List<Point3D>();
		int count = Convert.ToInt32(Length / Width);
		doPunteriz(refPoint, Length, Height, count, Angle, Type, ref calcPoints);
	}

	public void doPunteriz(Point3D refPoint, double Width, double Height, int Count, double Angle, SewingPunterizType Type, ref List<Point3D> calcPoints)
	{
		calcPoints.Clear();
		calcPoints = new List<Point3D>();
		if (Type != SewingPunterizType.MinLeft)
		{
			if (Type != SewingPunterizType.MinRigth)
			{
				if (Type != SewingPunterizType.CenterLeft)
				{
					if (Type == SewingPunterizType.CenterRigth)
					{
						double num = Width / Convert.ToDouble(Count * 4);
						calcPoints.Add(new Point3D());
						Point3D point3D = new Point3D();
						for (int i = 0; i < Count * 2 - 1; i++)
						{
							if (i != 0)
							{
								if ((double)i % 2.0 != 1.0)
								{
									point3D = new Point3D(num + num + calcPoints[calcPoints.Count - 1].X, Height / 2.0);
									calcPoints.Add(point3D);
								}
								else
								{
									point3D = new Point3D(num + num + calcPoints[calcPoints.Count - 1].X, (0.0 - Height) / 2.0);
									calcPoints.Add(point3D);
								}
							}
							else
							{
								point3D = new Point3D(num + (double)i * (num + num + num + num), (0.0 - Height) / 2.0);
								calcPoints.Add(point3D);
								point3D = new Point3D(num + num + num + (double)i * (num + num + num + num), Height / 2.0);
								calcPoints.Add(point3D);
							}
						}
						point3D = new Point3D(Width, 0.0);
						calcPoints.Add(point3D);
					}
				}
				else
				{
					double num2 = Width / Convert.ToDouble(Count * 4);
					calcPoints.Add(new Point3D());
					Point3D point3D2 = new Point3D();
					for (int j = 0; j < Count * 2 - 1; j++)
					{
						if (j != 0)
						{
							if ((double)j % 2.0 != 1.0)
							{
								point3D2 = new Point3D(num2 + num2 + calcPoints[calcPoints.Count - 1].X, (0.0 - Height) / 2.0);
								calcPoints.Add(point3D2);
							}
							else
							{
								point3D2 = new Point3D(num2 + num2 + calcPoints[calcPoints.Count - 1].X, Height / 2.0);
								calcPoints.Add(point3D2);
							}
						}
						else
						{
							point3D2 = new Point3D(num2 + (double)j * (num2 + num2 + num2 + num2), Height / 2.0);
							calcPoints.Add(point3D2);
							point3D2 = new Point3D(num2 + num2 + num2 + (double)j * (num2 + num2 + num2 + num2), (0.0 - Height) / 2.0);
							calcPoints.Add(point3D2);
						}
					}
					point3D2 = new Point3D(Width, 0.0);
					calcPoints.Add(point3D2);
				}
			}
			else
			{
				double num3 = Width / Convert.ToDouble(Count * 2);
				calcPoints.Add(new Point3D());
				for (int k = 0; k < Count; k++)
				{
					Point3D item = new Point3D(num3 + (double)k * (num3 + num3), 0.0 - Height);
					calcPoints.Add(item);
					item = new Point3D(num3 + num3 + (double)k * (num3 + num3), 0.0);
					calcPoints.Add(item);
				}
			}
		}
		else
		{
			double num4 = Width / Convert.ToDouble(Count * 2);
			calcPoints.Add(new Point3D());
			for (int l = 0; l < Count; l++)
			{
				Point3D item2 = new Point3D(num4 + (double)l * (num4 + num4), Height);
				calcPoints.Add(item2);
				item2 = new Point3D(num4 + num4 + (double)l * (num4 + num4), 0.0);
				calcPoints.Add(item2);
			}
		}
		if (Angle > 0.0)
		{
			clsInit.cVector5.Rotate(new Point3D(), Angle, Plane.XY, ref calcPoints);
		}
		clsInit.cVector5.Move(new Point3D(), refPoint, ref calcPoints);
	}

	public bool doOffset(List<buEntity> refEntities, double Offset, SewingOffsetOptions Options, ref List<buEntity> offsetedEntities, ref List<Point3D> Points)
	{
		List<buEntity> SortedEntities = new List<buEntity>();
		SortbuSettings sortbuSettings = new SortbuSettings();
		SortbuResult Result = new SortbuResult();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		offsetedEntities.Clear();
		offsetedEntities = new List<buEntity>();
		if (refEntities.Count != 0)
		{
			List<Point3D> Points2 = new List<Point3D>();
			clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, sortbuSettings, ref SortedEntities, ref Result);
			clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points2);
			if (Points2.Count != 0)
			{
				double offset = Offset;
				bool flag;
				if (flag = clsInit.cVector5.IsClosed(Points2))
				{
					if (Options.ClosedType == CamClosedContourType.Inner)
					{
						offset = 0.0 - Math.Abs(Offset);
					}
					offset = ((Options.ClosedType == CamClosedContourType.Outter) ? Math.Abs(Offset) : 0.0);
				}
				List<Point3D> OffsetedPoints = new List<Point3D>();
				CamOpenContourType2 openContourType = CamOpenContourType2.Left;
				if (Options.OpenType != CamOpenContourType.Right)
				{
					if (Options.OpenType == CamOpenContourType.Center)
					{
						openContourType = CamOpenContourType2.Center;
					}
				}
				else
				{
					openContourType = CamOpenContourType2.Right;
				}
				clsInit.cVector5.OffsetContour(Points2, offset, Options.CornerTyppe, openContourType, Plane.XY, 0.0, ref OffsetedPoints);
				if (!flag && ((OffsetedPoints.Count > 0) & (Points2.Count > 0)))
				{
					if (Options.MakeSameStartOffsetYLevel)
					{
						OffsetedPoints[0].Y = Points2[0].Y;
					}
					if (Options.MakeSameEndOffsetYLevel)
					{
						OffsetedPoints[OffsetedPoints.Count - 1].Y = Points2[Points2.Count - 1].Y;
					}
				}
				buLinearPath item = new buLinearPath(OffsetedPoints);
				offsetedEntities.Add(item);
				Points = new List<Point3D>();
				clsInit.cVector5.EntitiesToPointsWithCamDirection(offsetedEntities, 0.005, ref Points);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool doOffset(List<Entity> refEntities, double Offset, SewingOffsetOptions Options, ref List<Entity> offsetedEntities, ref List<Point3D> Points)
	{
		List<Entity> SortedEntities = new List<Entity>();
		SortSettings sortSettings = new SortSettings();
		SortResult Result = new SortResult();
		sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		offsetedEntities.Clear();
		offsetedEntities = new List<Entity>();
		if (refEntities.Count != 0)
		{
			List<Point3D> Points2 = new List<Point3D>();
			clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, sortSettings, ref SortedEntities, ref Result);
			clsInit.cVector5.EntitiesToPointsWithCamDirection(SortedEntities, 0.01, ref Points2);
			if (Points2.Count != 0)
			{
				double offset = Offset;
				bool flag;
				if (flag = clsInit.cVector5.IsClosed(Points2))
				{
					if (Options.ClosedType == CamClosedContourType.Inner)
					{
						offset = 0.0 - Math.Abs(Offset);
					}
					offset = ((Options.ClosedType == CamClosedContourType.Outter) ? Math.Abs(Offset) : 0.0);
				}
				List<Point3D> OffsetedPoints = new List<Point3D>();
				CamOpenContourType2 openContourType = CamOpenContourType2.Left;
				if (Options.OpenType != CamOpenContourType.Right)
				{
					if (Options.OpenType == CamOpenContourType.Center)
					{
						openContourType = CamOpenContourType2.Center;
					}
				}
				else
				{
					openContourType = CamOpenContourType2.Right;
				}
				clsInit.cVector5.OffsetContour(Points2, offset, Options.CornerTyppe, openContourType, Plane.XY, 0.0, ref OffsetedPoints);
				if (!flag && ((OffsetedPoints.Count > 0) & (Points2.Count > 0)))
				{
					if (Options.MakeSameStartOffsetYLevel)
					{
						OffsetedPoints[0].Y = Points2[0].Y;
					}
					if (Options.MakeSameEndOffsetYLevel)
					{
						OffsetedPoints[OffsetedPoints.Count - 1].Y = Points2[Points2.Count - 1].Y;
					}
				}
				LinearPath item = new LinearPath(OffsetedPoints);
				offsetedEntities.Add(item);
				Points = new List<Point3D>();
				clsInit.cVector5.EntitiesToPointsWithCamDirection(offsetedEntities, 0.005, ref Points);
				return true;
			}
			return false;
		}
		return false;
	}

	public bool doOffset(List<Point3D> refPoints, double Offset, SewingOffsetOptions Options, ref List<Point3D> offsetedPoints)
	{
		offsetedPoints.Clear();
		offsetedPoints = new List<Point3D>();
		if (refPoints.Count != 0)
		{
			double offset = Offset;
			bool flag;
			if (flag = clsInit.cVector5.IsClosed(refPoints))
			{
				if (Options.ClosedType == CamClosedContourType.Inner)
				{
					offset = 0.0 - Math.Abs(Offset);
				}
				offset = ((Options.ClosedType == CamClosedContourType.Outter) ? Math.Abs(Offset) : 0.0);
			}
			new List<Point3D>();
			CamOpenContourType2 openContourType = CamOpenContourType2.Left;
			if (Options.OpenType != CamOpenContourType.Right)
			{
				if (Options.OpenType == CamOpenContourType.Center)
				{
					openContourType = CamOpenContourType2.Center;
				}
			}
			else
			{
				openContourType = CamOpenContourType2.Right;
			}
			clsInit.cVector5.OffsetContour(refPoints, offset, Options.CornerTyppe, openContourType, Plane.XY, 0.0, ref offsetedPoints);
			if (!flag && ((offsetedPoints.Count > 0) & (refPoints.Count > 0)))
			{
				if (Options.MakeSameStartOffsetYLevel)
				{
					offsetedPoints[0].Y = refPoints[0].Y;
				}
				if (Options.MakeSameEndOffsetYLevel)
				{
					offsetedPoints[offsetedPoints.Count - 1].Y = refPoints[refPoints.Count - 1].Y;
				}
			}
			return true;
		}
		return false;
	}

	public void doDrawMainEntities(List<buEntity> MainEntity)
	{
		doDrawMainEntities(MainEntity, AutoConnect: false);
	}

	public void doDrawMainEntities(List<buEntity> MainEntity, bool AutoConnect)
	{
		if (ccVars.Pages.Count > 0)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		}
		Point3D point3D = new Point3D();
		for (int i = 0; i <= MainEntity.Count - 1; i++)
		{
			devDept.Eyeshot.Entities.Point point = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[i].StartPoint.X, MainEntity[i].StartPoint.Y));
			point.LayerName = varSewingSettings.layerNameDrawingPoints;
			point.ColorMethod = colorMethodType.byLayer;
			point.Color = varSewingSettings.colorDrawingPoints;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(point);
			devDept.Eyeshot.Entities.Point point2 = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[i].EndPoint.X, MainEntity[i].EndPoint.Y));
			point2.LayerName = varSewingSettings.layerNameDrawingPoints;
			point2.ColorMethod = colorMethodType.byLayer;
			point2.Color = varSewingSettings.colorDrawingPoints;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(point2);
			if (!((MainEntity[i].Sewing.Vertex.Count == 0) | (MainEntity[i].Sewing.Vertex.Count == 1)))
			{
				List<Point3D> list = new List<Point3D>();
				if (MainEntity[i].Sewing.Vertex[0].Punterez != null)
				{
					Point3D refPoint = new Point3D(MainEntity[i].Sewing.Vertex[0].Point.X + MainEntity[i].Sewing.Vertex[0].DeltaX, MainEntity[i].Sewing.Vertex[0].Point.Y + MainEntity[i].Sewing.Vertex[0].DeltaY);
					List<Point3D> calcPoints = new List<Point3D>();
					clsInit.appSewing.doPunteriz(refPoint, MainEntity[i].Sewing.Vertex[0].Punterez.Length, MainEntity[i].Sewing.Vertex[0].Punterez.Width, MainEntity[i].Sewing.Vertex[0].Punterez.Height, MainEntity[i].Sewing.Vertex[0].Punterez.Angle, MainEntity[i].Sewing.Vertex[0].Punterez.PunterizType, ref calcPoints);
					calcPoints.Reverse();
					list.AddRange(calcPoints);
				}
				if (MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Punterez != null)
				{
					Point3D refPoint2 = new Point3D(MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.X + MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaX, MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.Y + MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaY);
					List<Point3D> calcPoints2 = new List<Point3D>();
					SewingPunteriz punterez = MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Punterez;
					clsInit.appSewing.doPunteriz(refPoint2, punterez.Length, punterez.Width, punterez.Height, punterez.Angle, punterez.PunterizType, ref calcPoints2);
					calcPoints2.Reverse();
					list.AddRange(calcPoints2);
				}
				for (int j = 0; j <= MainEntity[i].Sewing.Vertex.Count - 1; j++)
				{
					list.Add(new Point3D(MainEntity[i].Sewing.Vertex[j].Point.X + MainEntity[i].Sewing.Vertex[j].DeltaX, MainEntity[i].Sewing.Vertex[j].Point.Y + MainEntity[i].Sewing.Vertex[j].DeltaY));
					devDept.Eyeshot.Entities.Point point3 = new devDept.Eyeshot.Entities.Point(new Point3D(MainEntity[i].Sewing.Vertex[j].Point.X + MainEntity[i].Sewing.Vertex[j].DeltaX, MainEntity[i].Sewing.Vertex[j].Point.Y + MainEntity[i].Sewing.Vertex[j].DeltaY));
					point3.LayerName = varSewingSettings.layerNamePoint;
					point3.ColorMethod = colorMethodType.byLayer;
					if (MainEntity[i].Sewing.Vertex[j].Codes.Count > 0)
					{
						point3.Color = varSewingSettings.colorVertexHasCode;
						point3.ColorMethod = colorMethodType.byEntity;
					}
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(point3);
				}
				point3D = new Point3D(MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.X + MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaX, MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.Y + MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].DeltaY);
				LinearPath linearPath = new LinearPath(list);
				linearPath.LayerName = varSewingSettings.layerNameDrawingDevided;
				if (!MainEntity[i].Sewing.isStitchDrawing)
				{
					linearPath.ColorMethod = colorMethodType.byEntity;
					linearPath.Color = varSewingSettings.colorNoStitch;
				}
				else
				{
					linearPath.ColorMethod = colorMethodType.byLayer;
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(linearPath);
				Entity copiedEntity = null;
				buEntity.Copy(MainEntity[i], ref copiedEntity);
				copiedEntity.LayerName = varSewingSettings.layerNameDrawing;
				if (copiedEntity is Line)
				{
					((Line)copiedEntity).StartPoint.X = MainEntity[i].Sewing.Vertex[0].Point.X + MainEntity[i].Sewing.Vertex[0].DeltaX;
					((Line)copiedEntity).StartPoint.Y = MainEntity[i].Sewing.Vertex[0].Point.Y + MainEntity[i].Sewing.Vertex[0].DeltaY;
					((Line)copiedEntity).EndPoint.X = MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.X + MainEntity[i].Sewing.Vertex[0].DeltaX;
					((Line)copiedEntity).EndPoint.Y = MainEntity[i].Sewing.Vertex[MainEntity[i].Sewing.Vertex.Count - 1].Point.Y + MainEntity[i].Sewing.Vertex[0].DeltaY;
					copiedEntity.Regen(0.01);
				}
				if (!MainEntity[i].Sewing.isStitchDrawing)
				{
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					copiedEntity.Color = varSewingSettings.colorNoStitch;
				}
				else
				{
					copiedEntity.ColorMethod = colorMethodType.byLayer;
				}
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
				continue;
			}
			Entity copiedEntity2 = null;
			buEntity.Copy(MainEntity[i], ref copiedEntity2);
			copiedEntity2.LayerName = varSewingSettings.layerNameDrawing;
			if (!MainEntity[i].Sewing.isStitchDrawing)
			{
				copiedEntity2.ColorMethod = colorMethodType.byEntity;
				copiedEntity2.Color = varSewingSettings.colorNoStitch;
			}
			else
			{
				copiedEntity2.ColorMethod = colorMethodType.byLayer;
			}
			if (!AutoConnect)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity2);
				continue;
			}
			Point3D point3D2 = null;
			Point3D point3D3 = null;
			for (int num = i - 1; num >= 0; num--)
			{
				if (MainEntity[num].Sewing.Vertex.Count > 0)
				{
					int index = MainEntity[num].Sewing.Vertex.Count - 1;
					point3D3 = new Point3D(MainEntity[num].Sewing.Vertex[index].Point.X + MainEntity[num].Sewing.Vertex[index].DeltaX, MainEntity[num].Sewing.Vertex[index].Point.Y + MainEntity[num].Sewing.Vertex[index].DeltaY);
					num = 0;
				}
			}
			int num2;
			for (num2 = i + 1; num2 <= MainEntity.Count - 1; num2++)
			{
				if (MainEntity[num2].Sewing.Vertex.Count <= 1)
				{
					point3D2 = new Point3D(MainEntity[num2].Vertices[0].X, MainEntity[num2].Vertices[0].Y);
					num2 = MainEntity.Count;
				}
				else
				{
					point3D2 = new Point3D(MainEntity[num2].Sewing.Vertex[0].Point.X + MainEntity[num2].Sewing.Vertex[0].DeltaX, MainEntity[num2].Sewing.Vertex[0].Point.Y + MainEntity[num2].Sewing.Vertex[0].DeltaY);
					num2 = MainEntity.Count;
				}
			}
			if ((point3D2 != null) & (point3D3 != null))
			{
				Line line = new Line(point3D3, point3D2);
				line.EntityData = new CustomData();
				line.ColorMethod = colorMethodType.byEntity;
				line.Color = varSewingSettings.colorNoStitch;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line);
				point3D = new Point3D(point3D2.X, point3D2.Y);
			}
			if (!((point3D2 != null) & (point3D3 == null)))
			{
				if (MainEntity[i].Sewing.Vertex.Count > 0 && !buCompare5.EQ(point3D, MainEntity[i].Sewing.Vertex[0].Point))
				{
					Line line2 = new Line(point3D, MainEntity[i].Sewing.Vertex[0].Point);
					line2.EntityData = new CustomData();
					line2.ColorMethod = colorMethodType.byEntity;
					line2.Color = varSewingSettings.colorNoStitch;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2);
					point3D = new Point3D(MainEntity[i].Sewing.Vertex[0].Point.X, MainEntity[i].Sewing.Vertex[0].Point.Y);
				}
			}
			else
			{
				Line line3 = new Line(point3D, point3D2);
				line3.EntityData = new CustomData();
				line3.ColorMethod = colorMethodType.byEntity;
				line3.Color = varSewingSettings.colorNoStitch;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line3);
				point3D = new Point3D(point3D2.X, point3D2.Y);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doMovePoint(double MoveValue, string MoveAxis, List<SewingPickType> PickList, ref List<buEntity> MainEntityList, bool AutoConnect = false)
	{
		bool flag = false;
		for (int i = 0; i <= PickList.Count - 1; i++)
		{
			if (PickList[i].PickType == SewingPickClickType.Vertex)
			{
				if (!(MoveAxis == "X"))
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].Sewing.Vertex[PickList[i].VertexIndex].DeltaY = SewingBase.MainEntityList[PickList[i].EntityIndex].Sewing.Vertex[PickList[i].VertexIndex].DeltaY + MoveValue;
				}
				else
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].Sewing.Vertex[PickList[i].VertexIndex].DeltaX = SewingBase.MainEntityList[PickList[i].EntityIndex].Sewing.Vertex[PickList[i].VertexIndex].DeltaX + MoveValue;
				}
			}
			if (PickList[i].PickType != SewingPickClickType.Entity)
			{
				continue;
			}
			flag = true;
			if (!(MoveAxis == "X"))
			{
				if (PickList[i].EntitySelectType == SewingPickEntitySelectType.StartPoint)
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].StartPoint.Y = SewingBase.MainEntityList[PickList[i].EntityIndex].StartPoint.Y + MoveValue;
				}
				if (PickList[i].EntitySelectType == SewingPickEntitySelectType.EndPoint)
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].EndPoint.Y = SewingBase.MainEntityList[PickList[i].EntityIndex].EndPoint.Y + MoveValue;
				}
			}
			else
			{
				if (PickList[i].EntitySelectType == SewingPickEntitySelectType.StartPoint)
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].StartPoint.X = SewingBase.MainEntityList[PickList[i].EntityIndex].StartPoint.X + MoveValue;
				}
				if (PickList[i].EntitySelectType == SewingPickEntitySelectType.EndPoint)
				{
					SewingBase.MainEntityList[PickList[i].EntityIndex].EndPoint.X = SewingBase.MainEntityList[PickList[i].EntityIndex].EndPoint.X + MoveValue;
				}
			}
		}
		if (flag)
		{
			SewingDevideOptions sewingDevideOptions = new SewingDevideOptions();
			sewingDevideOptions.DrawingLayerName = varSewingSettings.layerNameDrawing;
			sewingDevideOptions.PointLayerName = varSewingSettings.layerNamePoint;
			doDevideEntities(ref SewingBase.MainEntityList, sewingDevideOptions);
		}
		doDrawMainEntities(SewingBase.MainEntityList, AutoConnect);
	}

	public void doDeleteProperties()
	{
		if (cmdTree == "startlock" && ((selectedEntIndex >= 0) & (selectedEntIndex <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[selectedEntIndex].Sewing != null)
		{
			SewingBase.MainEntityList[selectedEntIndex].Sewing.StartStitchCount = 0;
			SewingBase.MainEntityList[selectedEntIndex].Sewing.StartStitchType = SewingAddStitchType.None;
			UndoBuffer();
			clsInit.appSewing.DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		if (cmdTree == "endlock" && ((selectedEntIndex >= 0) & (selectedEntIndex <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[selectedEntIndex].Sewing != null)
		{
			SewingBase.MainEntityList[selectedEntIndex].Sewing.EndStitchCount = 0;
			SewingBase.MainEntityList[selectedEntIndex].Sewing.EndStitchType = SewingAddStitchType.None;
			UndoBuffer();
			clsInit.appSewing.DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		if (cmdTree == "punterez" && ((selectedEntIndex >= 0) & (selectedEntIndex <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[selectedEntIndex].Sewing != null && ((selectedVertexIndex >= 0) & (selectedVertexIndex <= SewingBase.MainEntityList[selectedEntIndex].Sewing.Vertex.Count - 1)))
		{
			SewingBase.MainEntityList[selectedEntIndex].Sewing.Vertex[selectedVertexIndex].Punterez = null;
			UndoBuffer();
			clsInit.appSewing.DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
		if (cmdTree == "codes" && ((selectedEntIndex >= 0) & (selectedEntIndex <= SewingBase.MainEntityList.Count - 1)) && SewingBase.MainEntityList[selectedEntIndex].Sewing != null && ((selectedVertexIndex >= 0) & (selectedVertexIndex <= SewingBase.MainEntityList[selectedEntIndex].Sewing.Vertex.Count - 1)))
		{
			SewingBase.MainEntityList[selectedEntIndex].Sewing.Vertex[selectedVertexIndex].Codes.Clear();
			UndoBuffer();
			clsInit.appSewing.DrawSewingData(SewingBase, clsItem.frmEditor.viewport.Entities);
			JobUpdate();
		}
	}

	public void RemoveStitchEndCommand(ref SewingInfo Sewing)
	{
		for (int i = 0; i <= Sewing.Vertex.Count - 1; i++)
		{
			for (int j = 0; j <= Sewing.Vertex[i].Codes.Count - 1; j++)
			{
				if (Sewing.Vertex[i].Codes[j].Data1 == 16.0)
				{
					Sewing.Vertex[i].Codes[j].Data1 = 0.0;
				}
				if (Sewing.Vertex[i].Codes[j].Data2 == 16.0)
				{
					Sewing.Vertex[i].Codes[j].Data2 = 0.0;
				}
				if (Sewing.Vertex[i].Codes[j].Data3 == 16.0)
				{
					Sewing.Vertex[i].Codes[j].Data3 = 0.0;
				}
				if (Sewing.Vertex[i].Codes[j].Data4 == 16.0)
				{
					Sewing.Vertex[i].Codes[j].Data4 = 0.0;
				}
				if (Sewing.Vertex[i].Codes[j].Data5 == 16.0)
				{
					Sewing.Vertex[i].Codes[j].Data5 = 0.0;
				}
				if (Sewing.Vertex[i].Codes[j].Codes == SewingCodes.PnomaticSet4)
				{
					Sewing.Vertex[i].Codes[j].Codes = SewingCodes.None;
				}
			}
		}
	}

	public void CreateSewingTableListAsYesimModel1(ref SewingMain SewingBase, ref List<SewingJobItem> SewingTableList)
	{
		SewingTableList.Clear();
		for (int i = 0; i <= SewingBase.MainEntityList.Count - 1; i++)
		{
			SewingInfo sewing = SewingBase.MainEntityList[i].Sewing;
			if (sewing.Vertex.Count > 1 && ((sewing.StartStitchCount > 0) & sewing.isStitchDrawing))
			{
				if (sewing.StartStitchType != SewingAddStitchType.OneWay)
				{
					for (int j = 0; j <= sewing.StartStitchCount - 1; j++)
					{
						SewingJobItem S = new SewingJobItem();
						CreateSewingJobItem(ref S, i, j, sewing);
						if (j == 0)
						{
							clsInit.cSewing.AddCodeSewingJobItem(ref S, 22);
						}
						if (SewingTableList.Count != 0)
						{
							if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S.PositionY, 0.1))
							{
								SewingTableList.Add(S);
							}
						}
						else
						{
							SewingTableList.Add(S);
						}
					}
					for (int num = sewing.StartStitchCount; num >= 1; num--)
					{
						SewingJobItem S2 = new SewingJobItem();
						CreateSewingJobItem(ref S2, i, num, sewing);
						if (num == 1)
						{
							clsInit.cSewing.AddCodeSewingJobItem(ref S2, 23);
						}
						if (SewingTableList.Count != 0)
						{
							if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S2.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S2.PositionY, 0.1))
							{
								SewingTableList.Add(S2);
							}
						}
						else
						{
							SewingTableList.Add(S2);
						}
					}
				}
				else
				{
					for (int num2 = sewing.StartStitchCount; num2 >= 1; num2--)
					{
						SewingJobItem S3 = new SewingJobItem();
						CreateSewingJobItem(ref S3, i, num2, sewing);
						if (num2 == sewing.StartStitchCount)
						{
							clsInit.cSewing.AddCodeSewingJobItem(ref S3, 22);
						}
						if (num2 == 1)
						{
							clsInit.cSewing.AddCodeSewingJobItem(ref S3, 23);
						}
						if (SewingTableList.Count != 0)
						{
							if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S3.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S3.PositionY, 0.1))
							{
								SewingTableList.Add(S3);
							}
						}
						else
						{
							SewingTableList.Add(S3);
						}
					}
				}
			}
			double num3 = 0.0;
			double num4 = 0.0;
			double num5 = 0.0;
			double num6 = 0.0;
			if (sewing.Vertex.Count > 0 && sewing.Vertex[sewing.Vertex.Count - 1].Punterez != null)
			{
				num4 = sewing.Vertex[sewing.Vertex.Count - 1].Punterez.Length;
			}
			if ((sewing.Vertex.Count == 0) & (i <= SewingBase.MainEntityList.Count - 2))
			{
				SewingInfo sewing2 = SewingBase.MainEntityList[i + 1].Sewing;
				SewingJobItem sewingJobItem = new SewingJobItem();
				if (sewing2.Vertex.Count > 0)
				{
					sewingJobItem.PositionX = sewing2.Vertex[0].Point.X + sewing2.Vertex[0].DeltaX;
					sewingJobItem.PositionY = sewing2.Vertex[0].Point.Y + sewing2.Vertex[0].DeltaY;
					SewingTableList.Add(sewingJobItem);
				}
			}
			int num7 = 0;
			if (i > 0 && SewingBase.MainEntityList[i - 1].Sewing != null && (SewingBase.MainEntityList[i - 1].Sewing.isStitchDrawing & sewing.isStitchDrawing) && SewingBase.MainEntityList[i - 1].Sewing.Vertex.Count > 0)
			{
				Point3D point = SewingBase.MainEntityList[i - 1].Sewing.Vertex[SewingBase.MainEntityList[i - 1].Sewing.Vertex.Count - 1].Point;
				if (sewing.Vertex != null && sewing.Vertex.Count > 0)
				{
					Point3D point2 = sewing.Vertex[0].Point;
					if (buCompare5.EQ(point, point2))
					{
						num7 = 1;
					}
				}
			}
			for (int k = num7; k <= sewing.Vertex.Count - 1; k++)
			{
				SewingJobItem sewingJobItem2 = new SewingJobItem();
				if (k > 0)
				{
					num5 = Point3D.Distance(sewing.Vertex[k].Point, sewing.Vertex[0].Point);
				}
				num6 = Point3D.Distance(sewing.Vertex[k].Point, sewing.Vertex[sewing.Vertex.Count - 1].Point);
				if ((sewing.Vertex[k].Punterez != null && k == 0) & sewing.isStitchDrawing)
				{
					SewingVertex sewingVertex = sewing.Vertex[k];
					Point3D refPoint = new Point3D(sewingVertex.Point.X + sewingVertex.DeltaX, sewingVertex.Point.Y + sewingVertex.DeltaY);
					List<Point3D> calcPoints = new List<Point3D>();
					List<Point3D> pntDevided = new List<Point3D>();
					List<Point3D> list = new List<Point3D>();
					clsInit.appSewing.doPunteriz(refPoint, sewingVertex.Punterez.Length, sewingVertex.Punterez.Width, sewingVertex.Punterez.Height, sewingVertex.Punterez.Angle, sewingVertex.Punterez.PunterizType, ref calcPoints);
					buLine refEntity = new buLine(calcPoints[0], calcPoints[calcPoints.Count - 1]);
					clsInit.cVector5.EntityDevideByCamDir(refEntity, sewing.StitchLengt, ref pntDevided);
					list.AddRange(pntDevided);
					list.Reverse();
					num3 = sewingVertex.Punterez.Length;
					for (int l = 0; l <= pntDevided.Count - 1; l++)
					{
						sewingJobItem2 = new SewingJobItem();
						sewingJobItem2.StitchStep = sewing.StitchLengt;
						sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
						sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
						sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
						if (sewing.Vertex[k].Speed > 0.0)
						{
							sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
						}
						sewingJobItem2.PositionX = pntDevided[l].X + sewing.Vertex[k].DeltaX;
						sewingJobItem2.PositionY = pntDevided[l].Y + sewing.Vertex[k].DeltaY;
						sewingJobItem2.Style = sewing.Style;
						if (l == 0)
						{
							clsInit.cSewing.GetVertexCodes(ref sewingJobItem2, sewing.Vertex[k]);
							clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 20);
						}
						SewingTableList.Add(sewingJobItem2);
					}
					for (int m = 1; m <= list.Count - 1; m++)
					{
						sewingJobItem2 = new SewingJobItem();
						sewingJobItem2.StitchStep = sewing.StitchLengt;
						sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
						sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
						sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
						if (sewing.Vertex[k].Speed > 0.0)
						{
							sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
						}
						sewingJobItem2.PositionX = list[m].X + sewing.Vertex[k].DeltaX;
						sewingJobItem2.PositionY = list[m].Y + sewing.Vertex[k].DeltaY;
						sewingJobItem2.Style = sewing.Style;
						SewingTableList.Add(sewingJobItem2);
					}
					for (int n = 1; n <= calcPoints.Count - 1; n++)
					{
						sewingJobItem2 = new SewingJobItem();
						sewingJobItem2.StitchStep = sewing.StitchLengt;
						sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
						sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
						sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
						if (sewing.Vertex[k].Speed > 0.0)
						{
							sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
						}
						sewingJobItem2.PositionX = calcPoints[n].X + sewing.Vertex[k].DeltaX;
						sewingJobItem2.PositionY = calcPoints[n].Y + sewing.Vertex[k].DeltaY;
						sewingJobItem2.Style = sewing.Style;
						if (n == calcPoints.Count - 1)
						{
							clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 23);
						}
						SewingTableList.Add(sewingJobItem2);
					}
				}
				sewingJobItem2 = new SewingJobItem();
				CreateSewingJobItem(ref sewingJobItem2, i, k, sewing);
				if ((k == 0) & (sewing.StartStitchCount > 0))
				{
					clsInit.cSewing.ClearCodeSewingJobItem(ref sewingJobItem2);
				}
				if (((k > 0) & (k < sewing.Vertex.Count - 1)) && ((sewing.Vertex[k].Punterez != null) & sewing.isStitchDrawing))
				{
					SewingVertex sewingVertex2 = sewing.Vertex[k];
					Point3D refPoint2 = new Point3D(sewingVertex2.Point.X + sewingVertex2.DeltaX, sewingVertex2.Point.Y + sewingVertex2.DeltaY);
					List<Point3D> calcPoints2 = new List<Point3D>();
					List<Point3D> pntDevided2 = new List<Point3D>();
					new List<Point3D>();
					clsInit.appSewing.doPunteriz(refPoint2, sewingVertex2.Punterez.Length, sewingVertex2.Punterez.Width, sewingVertex2.Punterez.Height, sewingVertex2.Punterez.Angle, sewingVertex2.Punterez.PunterizType, ref calcPoints2);
					buLine refEntity2 = new buLine(calcPoints2[0], calcPoints2[calcPoints2.Count - 1]);
					clsInit.cVector5.EntityDevideByCamDir(refEntity2, sewing.StitchLengt, ref pntDevided2);
					num3 = sewingVertex2.Punterez.Length;
					int num8 = -1;
					int num9 = -1;
					double num10 = 9999999.0;
					double num11 = 9999999.0;
					for (int num12 = k; num12 <= sewing.Vertex.Count - 1; num12++)
					{
						double num13 = Point3D.Distance(sewing.Vertex[num12].Point, pntDevided2[0]);
						if (num13 < num10)
						{
							num8 = num12;
							num10 = num13;
						}
						double num14 = Point3D.Distance(sewing.Vertex[num12].Point, pntDevided2[pntDevided2.Count - 1]);
						if (num14 < num11)
						{
							num9 = num12;
							num11 = num14;
						}
					}
					if (num8 >= 0 && num9 >= 0 && num8 != num9)
					{
						for (int num15 = 0; num15 <= calcPoints2.Count - 1; num15++)
						{
							sewingJobItem2 = new SewingJobItem();
							sewingJobItem2.StitchStep = sewing.StitchLengt;
							sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
							sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
							sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
							if (sewing.Vertex[k].Speed > 0.0)
							{
								sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
							}
							sewingJobItem2.PositionX = calcPoints2[num15].X + sewing.Vertex[k].DeltaX;
							sewingJobItem2.PositionY = calcPoints2[num15].Y + sewing.Vertex[k].DeltaY;
							sewingJobItem2.Style = sewing.Style;
							if (num15 == 0)
							{
								clsInit.cSewing.GetVertexCodes(ref sewingJobItem2, sewing.Vertex[k]);
								clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 20);
							}
							if (num15 == calcPoints2.Count - 1)
							{
								clsInit.cSewing.GetVertexCodes(ref sewingJobItem2, sewing.Vertex[k]);
								clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 23);
							}
							SewingTableList.Add(sewingJobItem2);
						}
						k = num9;
					}
				}
				if ((k == sewing.Vertex.Count - 1) & (sewing.EndStitchCount > 0))
				{
					clsInit.cSewing.ClearCodeSewingJobItem(ref sewingJobItem2);
				}
				if (((num3 == 0.0) | ((num3 > 0.0) & (num5 > num3 + sewing.StitchLengt))) && (num4 == 0.0 || (num4 > 0.0 && num6 > num4)))
				{
					if (SewingTableList.Count != 0)
					{
						if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, sewingJobItem2.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, sewingJobItem2.PositionY, 0.1))
						{
							SewingTableList.Add(sewingJobItem2);
						}
					}
					else
					{
						SewingTableList.Add(sewingJobItem2);
					}
				}
				if (!((sewing.Vertex[k].Punterez != null) & (k == sewing.Vertex.Count - 1) & sewing.isStitchDrawing))
				{
					continue;
				}
				SewingVertex sewingVertex3 = sewing.Vertex[k];
				Point3D refPoint3 = new Point3D(sewingVertex3.Point.X + sewingVertex3.DeltaX, sewingVertex3.Point.Y + sewingVertex3.DeltaY);
				List<Point3D> calcPoints3 = new List<Point3D>();
				List<Point3D> pntDevided3 = new List<Point3D>();
				List<Point3D> list2 = new List<Point3D>();
				clsInit.appSewing.doPunteriz(refPoint3, sewingVertex3.Punterez.Length, sewingVertex3.Punterez.Width, sewingVertex3.Punterez.Height, sewingVertex3.Punterez.Angle, sewingVertex3.Punterez.PunterizType, ref calcPoints3);
				buLine refEntity3 = new buLine(calcPoints3[0], calcPoints3[calcPoints3.Count - 1]);
				clsInit.cVector5.EntityDevideByCamDir(refEntity3, sewing.StitchLengt, ref pntDevided3);
				list2.AddRange(pntDevided3);
				list2.Reverse();
				num3 = sewingVertex3.Punterez.Length;
				for (int num16 = 1; num16 <= list2.Count - 1; num16++)
				{
					sewingJobItem2 = new SewingJobItem();
					sewingJobItem2.StitchStep = sewing.StitchLengt;
					sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
					sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
					sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
					if (sewing.Vertex[k].Speed > 0.0)
					{
						sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
					}
					sewingJobItem2.PositionX = list2[num16].X + sewing.Vertex[k].DeltaX;
					sewingJobItem2.PositionY = list2[num16].Y + sewing.Vertex[k].DeltaY;
					sewingJobItem2.Style = sewing.Style;
					SewingTableList.Add(sewingJobItem2);
				}
				for (int num17 = 1; num17 <= pntDevided3.Count - 1; num17++)
				{
					sewingJobItem2 = new SewingJobItem();
					sewingJobItem2.StitchStep = sewing.StitchLengt;
					sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
					sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
					sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
					if (sewing.Vertex[k].Speed > 0.0)
					{
						sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
					}
					sewingJobItem2.PositionX = pntDevided3[num17].X + sewing.Vertex[k].DeltaX;
					sewingJobItem2.PositionY = pntDevided3[num17].Y + sewing.Vertex[k].DeltaY;
					sewingJobItem2.Style = sewing.Style;
					if (num17 == 1)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 20);
					}
					SewingTableList.Add(sewingJobItem2);
				}
				calcPoints3.Reverse();
				for (int num18 = 1; num18 <= calcPoints3.Count - 1; num18++)
				{
					sewingJobItem2 = new SewingJobItem();
					sewingJobItem2.StitchStep = sewing.StitchLengt;
					sewingJobItem2.HeadSpeed = sewing.HeadSpeed;
					sewingJobItem2.StitchedWay = sewing.isStitchDrawing;
					sewingJobItem2.PositionX = calcPoints3[num18].X + sewing.Vertex[k].DeltaX;
					sewingJobItem2.PositionY = calcPoints3[num18].Y + sewing.Vertex[k].DeltaY;
					sewingJobItem2.FootHeight = sewing.Vertex[k].FootHeight;
					if (sewing.Vertex[k].Speed > 0.0)
					{
						sewingJobItem2.HeadSpeed = sewing.Vertex[k].Speed;
					}
					sewingJobItem2.Style = sewing.Style;
					if (num18 == calcPoints3.Count - 1)
					{
						clsInit.cSewing.GetVertexCodes(ref sewingJobItem2, sewing.Vertex[k]);
						clsInit.cSewing.AddCodeSewingJobItem(ref sewingJobItem2, 23);
					}
					SewingTableList.Add(sewingJobItem2);
				}
			}
			if (!((sewing.Vertex.Count > 1) & sewing.isStitchDrawing))
			{
				continue;
			}
			if (sewing.EndStitchType != SewingAddStitchType.OneWay)
			{
				if (sewing.EndStitchCount <= 0)
				{
					continue;
				}
				for (int num19 = sewing.Vertex.Count - 2; num19 >= sewing.Vertex.Count - sewing.EndStitchCount - 2; num19--)
				{
					SewingJobItem S4 = new SewingJobItem();
					CreateSewingJobItem(ref S4, i, num19, sewing);
					if (num19 == sewing.Vertex.Count - sewing.EndStitchCount - 2)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref S4, 22);
					}
					if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S4.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S4.PositionY, 0.1))
					{
						SewingTableList.Add(S4);
					}
				}
				for (int num20 = sewing.Vertex.Count - sewing.EndStitchCount - 2; num20 <= sewing.Vertex.Count - 1; num20++)
				{
					SewingJobItem S5 = new SewingJobItem();
					CreateSewingJobItem(ref S5, i, num20, sewing);
					if (num20 == sewing.Vertex.Count - 1)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref S5, 23);
					}
					if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S5.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S5.PositionY, 0.1))
					{
						SewingTableList.Add(S5);
					}
				}
			}
			else
			{
				if (sewing.EndStitchCount <= 0)
				{
					continue;
				}
				for (int num21 = sewing.Vertex.Count - 2; num21 >= sewing.Vertex.Count - sewing.EndStitchCount - 2; num21--)
				{
					SewingJobItem S6 = new SewingJobItem();
					CreateSewingJobItem(ref S6, i, num21, sewing);
					if (num21 == sewing.Vertex.Count - 2)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref S6, 22);
					}
					if (num21 == sewing.Vertex.Count - sewing.EndStitchCount - 2)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref S6, 23);
					}
					if (!buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionX, S6.PositionX, 0.1) | !buCompare5.EQ(SewingTableList[SewingTableList.Count - 1].PositionY, S6.PositionY, 0.1))
					{
						SewingTableList.Add(S6);
					}
				}
			}
		}
		if (SewingTableList.Count > 0)
		{
			int num22 = 0;
			for (int num23 = SewingTableList.Count - 1; num23 >= 0; num23--)
			{
				if (num22 > 0)
				{
					Point3D a = new Point3D(SewingTableList[num23 + 1].PositionX, SewingTableList[num23 + 1].PositionY);
					Point3D b = new Point3D(SewingTableList[num23].PositionX, SewingTableList[num23].PositionY);
					double num24 = Point3D.Distance(a, b);
					if (!(num24 < 0.1))
					{
					}
				}
				num22++;
			}
		}
		AnalyseTableListAsYesimModel1(ref SewingTableList);
	}

	public void AnalyseTableListAsYesimModel1(ref List<SewingJobItem> SewingTableList)
	{
		bool flag = false;
		int count = SewingTableList.Count;
		for (int i = 0; i <= count - 1; i++)
		{
			SewingJobItem S = SewingTableList[i];
			SewingJobItem S2 = null;
			if (i > 0)
			{
				S2 = SewingTableList[i - 1];
			}
			if (S.StitchedWay && !flag && !clsInit.cSewing.isCodeAvailable(S, 4))
			{
				int num = clsInit.cSewing.FreeAvailableCodeSequence(S);
				if (num > 0)
				{
					clsInit.cSewing.AddCodeSewingJobItem(ref S, 4);
				}
			}
			if (!S.StitchedWay && flag && S2 != null && !clsInit.cSewing.isCodeAvailable(S2, 5))
			{
				int num2 = clsInit.cSewing.FreeAvailableCodeSequence(S2);
				if (num2 > 0)
				{
					clsInit.cSewing.AddCodeSewingJobItem(ref S2, 5);
				}
			}
			if (i < SewingTableList.Count - 1 && clsInit.cSewing.isCodeAvailable(S, 16))
			{
				if (SewingTableList[i].Code0 == 16)
				{
					SewingTableList[i].Code0 = 0;
				}
				if (SewingTableList[i].Code1 == 16)
				{
					SewingTableList[i].Code1 = 0;
				}
				if (SewingTableList[i].Code2 == 16)
				{
					SewingTableList[i].Code2 = 0;
				}
				if (SewingTableList[i].Code3 == 16)
				{
					SewingTableList[i].Code3 = 0;
				}
				if (SewingTableList[i].Code4 == 16)
				{
					SewingTableList[i].Code4 = 0;
				}
				if (SewingTableList[i].Code5 == 16)
				{
					SewingTableList[i].Code5 = 0;
				}
			}
			if (i == SewingTableList.Count - 1)
			{
				bool flag2;
				if (!(flag2 = clsInit.cSewing.isCodeAvailable(S, 5)))
				{
					int num3 = clsInit.cSewing.FreeAvailableCodeSequence(S);
					if (num3 > 0)
					{
						clsInit.cSewing.AddCodeSewingJobItem(ref S, 5);
					}
				}
				if (flag2 = clsInit.cSewing.isCodeAvailable(S, 16))
				{
					if (SewingTableList[i].Code0 == 16)
					{
						SewingTableList[i].Code0 = 0;
					}
					if (SewingTableList[i].Code1 == 16)
					{
						SewingTableList[i].Code1 = 0;
					}
					if (SewingTableList[i].Code2 == 16)
					{
						SewingTableList[i].Code2 = 0;
					}
					if (SewingTableList[i].Code3 == 16)
					{
						SewingTableList[i].Code3 = 0;
					}
					if (SewingTableList[i].Code4 == 16)
					{
						SewingTableList[i].Code4 = 0;
					}
					if (SewingTableList[i].Code5 == 16)
					{
						SewingTableList[i].Code5 = 0;
					}
				}
				SewingJobItem sewingJobItem = new SewingJobItem(SewingTableList[i]);
				sewingJobItem.Code0 = 0;
				sewingJobItem.Code1 = 16;
				sewingJobItem.Code2 = 0;
				sewingJobItem.Code3 = 0;
				sewingJobItem.Code4 = 0;
				sewingJobItem.Code5 = 0;
				SewingTableList.Add(sewingJobItem);
				if (flag2)
				{
				}
			}
			int Index = -1;
			if (clsInit.cSewing.isCodeAvailable(S, 5, ref Index) && S.Code1 != 5)
			{
				if (Index == 2)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code2);
				}
				if (Index == 3)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code3);
				}
				if (Index == 4)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code4);
				}
				if (Index == 5)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code5);
				}
			}
			if (clsInit.cSewing.isCodeAvailable(S, 4, ref Index) && S.Code1 != 4)
			{
				if (Index == 2)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code2);
				}
				if (Index == 3)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code3);
				}
				if (Index == 4)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code4);
				}
				if (Index == 5)
				{
					buNumeric5.ExchangeTwoVaues(ref S.Code1, ref S.Code5);
				}
			}
			flag = SewingTableList[i].StitchedWay;
		}
		for (int num4 = SewingTableList.Count - 1; num4 >= 0; num4--)
		{
			if (num4 < SewingTableList.Count - 1 && num4 > 0 && (!SewingTableList[num4].StitchedWay & SewingTableList[num4 - 1].StitchedWay))
			{
				SewingJobItem sewingJobItem2 = SewingTableList[num4 - 1];
				SewingJobItem sewingJobItem3 = SewingTableList[num4];
				if (buCompare5.EQ(sewingJobItem3.PositionX, sewingJobItem2.PositionX) & buCompare5.EQ(sewingJobItem3.PositionY, sewingJobItem2.PositionY) & (sewingJobItem3.Code1 != 16))
				{
					SewingTableList.RemoveAt(num4);
				}
			}
		}
	}
}
