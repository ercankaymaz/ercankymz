using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buClass.Apps;
using buControls.DialogBox;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Diamaker;
using buMW;
using buMW.CamForms;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Diemaker;

public class clsDiemaker
{
	public static DiemakerProgramSettings varDiemakerSettings = new DiemakerProgramSettings();

	public List<Entity> CamOtherEntities = null;

	public void Init()
	{
		buMWDiamalerVars.Init();
	}

	public void cmdGrindingShapeV()
	{
		try
		{
			ToolBase5 toolBase = null;
			ToolBase5 toolBase2 = null;
			for (int i = 0; i <= ccVars.Tools[0].Tools.Count - 1; i++)
			{
				if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo == ccVars.Tools[0].Tools[i].Data.No)
				{
					toolBase = new ToolBase5(ccVars.Tools[0].Tools[i]);
				}
				if (buDiamakerCalc.varGrindingShape.NickToolNo == ccVars.Tools[0].Tools[i].Data.No)
				{
					toolBase2 = new ToolBase5(ccVars.Tools[0].Tools[i]);
				}
			}
			F_DiamakerGrindVShape f_DiamakerGrindVShape = new F_DiamakerGrindVShape();
			f_DiamakerGrindVShape.ToolGrinding = new ToolBase5(toolBase);
			f_DiamakerGrindVShape.ToolNick = new ToolBase5(toolBase2);
			f_DiamakerGrindVShape.isCircular = false;
			f_DiamakerGrindVShape.Init();
			f_DiamakerGrindVShape.radiolineartype.Checked = true;
			f_DiamakerGrindVShape.ShowDialog();
			if (f_DiamakerGrindVShape.PropertiesForm.Result != DialogResult.OK)
			{
				return;
			}
			SaveDiemakerFile();
			List<Entity> calcEntities = new List<Entity>();
			camTp Cam = new camTp();
			clsInit.cDiamaker.doGrindingVShape(buDiamakerCalc.varGrindingShape, toolBase, toolBase2, f_DiamakerGrindVShape.isCircular, ref calcEntities, ref Cam);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
			string name = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[0].Name;
			string name2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[1].Name;
			ccVars.Pages[ccVars.PageIndex].Cams.Clear();
			for (int j = 0; j <= calcEntities.Count - 1; j++)
			{
				ccVars.UndoDont = true;
				calcEntities[j].LayerName = name;
				clsInit.appCommand.AddEntity(calcEntities[j]);
			}
			clsInit.appCommand.CamAdd(Cam);
			double num = 1.0;
			List<Point3D> list = new List<Point3D>();
			List<Point3D> list2 = new List<Point3D>();
			if (f_DiamakerGrindVShape.radiolineartype.Checked)
			{
				list.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
				list.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[2]));
				list.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[3]));
				list.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
				list2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[0]));
				list2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[1]));
				list2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[3]));
				list2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[4]));
				list2.Add(buVector5.ToPoint3D(calcEntities[1].Vertices[5]));
			}
			if (!buDiamakerCalc.varGrindingShape.NickEnable)
			{
				num = 0.0;
			}
			if (f_DiamakerGrindVShape.radio_circulartype.Checked)
			{
				list.AddRange(calcEntities[1].Vertices);
				list2.Add(new Point3D((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0));
				list2.Add(new Point3D((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, calcEntities[1].Vertices[0].Y));
				list2.Add(new Point3D(buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, calcEntities[1].Vertices[0].Y));
				list2.Add(new Point3D(buDiamakerCalc.varGrindingShape.MaterialThickness / 2.0, 0.0));
				list2.Add(new Point3D((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0));
			}
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
			compositeCurve.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0, num / 2.0);
			devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(compositeCurve);
			Mesh mesh = region.ExtrudeAsMesh(2.0, 0.01, Mesh.natureType.RichSmooth);
			mesh.Color = Color.Gray;
			mesh.ColorMethod = colorMethodType.byEntity;
			mesh.LayerName = name2;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
			int alpha = 150;
			for (int k = 0; k <= buDiamakerCalc.varGrindingShape.FeedCount - 1; k++)
			{
				double num2 = (0.0 - (double)k) * (buDiamakerCalc.varGrindingShape.GrindingLength + num / 1.0 + num + 2.0);
				if (num > 0.0)
				{
					CompositeCurve compositeCurve2 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.NickDepth);
					compositeCurve2.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0, num / 2.0 + num2);
					devDept.Eyeshot.Entities.Region region2 = new devDept.Eyeshot.Entities.Region(compositeCurve2);
					Mesh mesh2 = region2.ExtrudeAsMesh(0.0 - num, 0.01, Mesh.natureType.RichSmooth);
					mesh2.Color = Color.Gray;
					mesh2.ColorMethod = colorMethodType.byEntity;
					mesh2.LayerName = name2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh2);
					CompositeCurve compositeCurve3 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight - buDiamakerCalc.varGrindingShape.NickDepth);
					compositeCurve3.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, buDiamakerCalc.varGrindingShape.NickDepth, num / 2.0 + num2);
					devDept.Eyeshot.Entities.Region region3 = new devDept.Eyeshot.Entities.Region(compositeCurve3);
					Mesh mesh3 = region3.ExtrudeAsMesh(0.0 - num, 0.01, Mesh.natureType.RichSmooth);
					mesh3.Color = Color.FromArgb(alpha, Color.LightSteelBlue);
					mesh3.ColorMethod = colorMethodType.byEntity;
					mesh3.LayerName = name2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh3);
				}
				List<ICurve> list3 = new List<ICurve>();
				LinearPath linearPath = new LinearPath(list);
				ICurve item = linearPath;
				list3.Add(item);
				CompositeCurve compositeCurve4 = new CompositeCurve(list3);
				compositeCurve4.Translate(0.0, 0.0, (0.0 - num) / 2.0 + num2);
				devDept.Eyeshot.Entities.Region region4 = new devDept.Eyeshot.Entities.Region(compositeCurve4);
				Mesh mesh4 = null;
				mesh4 = (f_DiamakerGrindVShape.radiolineartype.Checked ? region4.ExtrudeAsMesh(buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth) : region4.ExtrudeAsMesh(0.0 - buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth));
				mesh4.Color = Color.Red;
				mesh4.ColorMethod = colorMethodType.byEntity;
				mesh4.LayerName = name2;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh4);
				List<ICurve> list4 = new List<ICurve>();
				LinearPath linearPath2 = new LinearPath(list2);
				ICurve item2 = linearPath2;
				list4.Add(item2);
				CompositeCurve compositeCurve5 = new CompositeCurve(list4);
				compositeCurve5.Translate(0.0, 0.0, (0.0 - num) / 2.0 + num2);
				devDept.Eyeshot.Entities.Region region5 = new devDept.Eyeshot.Entities.Region(compositeCurve5);
				Mesh mesh5 = region5.ExtrudeAsMesh(buDiamakerCalc.varGrindingShape.GrindingLength, 0.01, Mesh.natureType.RichSmooth);
				mesh5.Color = Color.Gray;
				mesh5.ColorMethod = colorMethodType.byEntity;
				mesh5.LayerName = name2;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh5);
				if (num > 0.0)
				{
					CompositeCurve compositeCurve6 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.NickDepth);
					compositeCurve6.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0, (0.0 - num) / 2.0 - buDiamakerCalc.varGrindingShape.GrindingLength + num2);
					devDept.Eyeshot.Entities.Region region6 = new devDept.Eyeshot.Entities.Region(compositeCurve6);
					Mesh mesh6 = region6.ExtrudeAsMesh(0.0 - num, 0.01, Mesh.natureType.RichSmooth);
					mesh6.Color = Color.Gray;
					mesh6.ColorMethod = colorMethodType.byEntity;
					mesh6.LayerName = name2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh6);
					CompositeCurve compositeCurve7 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight - buDiamakerCalc.varGrindingShape.NickDepth);
					compositeCurve7.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, buDiamakerCalc.varGrindingShape.NickDepth, (0.0 - num) / 2.0 - buDiamakerCalc.varGrindingShape.GrindingLength + num2);
					devDept.Eyeshot.Entities.Region region7 = new devDept.Eyeshot.Entities.Region(compositeCurve7);
					Mesh mesh7 = region7.ExtrudeAsMesh(0.0 - num, 0.01, Mesh.natureType.RichSmooth);
					mesh7.Color = Color.FromArgb(alpha, Color.LightSteelBlue);
					mesh7.ColorMethod = colorMethodType.byEntity;
					mesh7.LayerName = name2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh7);
				}
				CompositeCurve compositeCurve8 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
				compositeCurve8.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0, (0.0 - num) / 2.0 - num - buDiamakerCalc.varGrindingShape.GrindingLength + num2);
				devDept.Eyeshot.Entities.Region region8 = new devDept.Eyeshot.Entities.Region(compositeCurve8);
				Mesh mesh8 = region8.ExtrudeAsMesh(-2.0, 0.01, Mesh.natureType.RichSmooth);
				mesh8.Color = Color.Gray;
				mesh8.ColorMethod = colorMethodType.byEntity;
				mesh8.LayerName = name2;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh8);
			}
			RegenOptions ro = new RegenOptions();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Regen(ro);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].Regen(0.01);
			double num3 = 0.0;
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].BoxMin != null)
			{
				num3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1].BoxMin.Z;
			}
			if (num3 != 0.0)
			{
				CompositeCurve compositeCurve9 = CompositeCurve.CreateRectangle(Plane.XY, buDiamakerCalc.varGrindingShape.MaterialThickness, buDiamakerCalc.varGrindingShape.BaseMaterialHeight);
				compositeCurve9.Translate((0.0 - buDiamakerCalc.varGrindingShape.MaterialThickness) / 2.0, 0.0);
				devDept.Eyeshot.Entities.Region region9 = new devDept.Eyeshot.Entities.Region(compositeCurve9);
				Mesh mesh9 = region9.ExtrudeAsMesh(num3, 0.01, Mesh.natureType.RichSmooth);
				mesh9.Color = Color.FromArgb(50, Color.Gray);
				mesh9.ColorMethod = colorMethodType.byEntity;
				mesh9.LayerName = name2;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh9);
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdGrindingShapeCircular()
	{
		try
		{
			ToolBase5 toolBase = null;
			ToolBase5 toolBase2 = null;
			for (int i = 0; i <= ccVars.Tools[0].Tools.Count - 1; i++)
			{
				if (buDiamakerCalc.varGrindingShape.VShapeAngleToolNo == ccVars.Tools[0].Tools[i].Data.No)
				{
					toolBase = new ToolBase5(ccVars.Tools[0].Tools[i]);
				}
				if (buDiamakerCalc.varGrindingShape.NickToolNo == ccVars.Tools[0].Tools[i].Data.No)
				{
					toolBase2 = new ToolBase5(ccVars.Tools[0].Tools[i]);
				}
			}
			F_DiamakerGrindVShape f_DiamakerGrindVShape = new F_DiamakerGrindVShape();
			f_DiamakerGrindVShape.ToolGrinding = new ToolBase5(toolBase);
			f_DiamakerGrindVShape.ToolNick = new ToolBase5(toolBase2);
			f_DiamakerGrindVShape.isCircular = true;
			f_DiamakerGrindVShape.Init();
			f_DiamakerGrindVShape.radio_circulartype.Checked = true;
			f_DiamakerGrindVShape.ShowDialog();
			if (f_DiamakerGrindVShape.PropertiesForm.Result == DialogResult.OK)
			{
				List<Entity> calcEntities = new List<Entity>();
				camTp Cam = new camTp();
				clsInit.cDiamaker.doGrindingVShape(buDiamakerCalc.varGrindingShape, toolBase, toolBase2, f_DiamakerGrindVShape.isCircular, ref calcEntities, ref Cam);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
				for (int j = 0; j <= calcEntities.Count - 1; j++)
				{
					ccVars.UndoDont = true;
					clsInit.appCommand.AddEntity(calcEntities[j]);
				}
				clsInit.appCommand.CamAdd(Cam);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamContour(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				switch (Action)
				{
				case actionTypeBU.camContours:
				{
					camTp Cam2 = new camTp();
					MWCalculationOptions mWCalculationOptions2 = new MWCalculationOptions();
					mWCalculationOptions2.NumberofAxis = 3;
					mWCalculationOptions2.CamWireframeType = CamWireFrameType.Contour;
					mWCalculationOptions2.Mode = CamMode.WireFrame;
					mWCalculationOptions2.DontApplyReset = true;
					mWCalculationOptions2.isBuWireframeCalculation = true;
					mWCalculationOptions2.AddToCamListInMWCalculation = false;
					doWireframeContour(mWCalculationOptions2, ref Cam2);
					break;
				}
				case actionTypeBU.camPocketing:
				{
					camTp Cam = new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 3;
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
					mWCalculationOptions.Mode = CamMode.WireFrame;
					mWCalculationOptions.isRough = true;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.AddToCamListInMWCalculation = false;
					doWireframeContour(mWCalculationOptions, ref Cam);
					break;
				}
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamTriangleMesh(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				switch (Action)
				{
				case actionTypeBU.camTriangularMesh3DRough:
				{
					new camTp();
					MWCalculationOptions mWCalculationOptions3 = new MWCalculationOptions();
					mWCalculationOptions3.NumberofAxis = 3;
					mWCalculationOptions3.CamTriMeshType = CamTriangularMeshType.Rough;
					mWCalculationOptions3.Mode = CamMode.TriangularMesh;
					mWCalculationOptions3.isRough = true;
					mWCalculationOptions3.DontApplyReset = true;
					mWCalculationOptions3.AddToCamListInMWCalculation = false;
					doTriangleMesh(mWCalculationOptions3);
					break;
				}
				case actionTypeBU.camTriangularMesh3DParalelCut:
				{
					new camTp();
					MWCalculationOptions mWCalculationOptions2 = new MWCalculationOptions();
					mWCalculationOptions2.NumberofAxis = 3;
					mWCalculationOptions2.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
					mWCalculationOptions2.Mode = CamMode.TriangularMesh;
					mWCalculationOptions2.DontApplyReset = true;
					mWCalculationOptions2.AddToCamListInMWCalculation = false;
					doTriangleMesh(mWCalculationOptions2);
					break;
				}
				case actionTypeBU.camTriangularMesh3DConstantZ:
				{
					new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 3;
					mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
					mWCalculationOptions.Mode = CamMode.TriangularMesh;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.AddToCamListInMWCalculation = false;
					doTriangleMesh(mWCalculationOptions);
					break;
				}
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamDrill(actionTypeBU Action)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = Action;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				if (Action == actionTypeBU.camDrill)
				{
					new camTp();
					MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
					mWCalculationOptions.NumberofAxis = 3;
					mWCalculationOptions.CamDrillType = CamDrillType.Line;
					mWCalculationOptions.CamDrillMode = CamDrillMode.Point;
					mWCalculationOptions.Mode = CamMode.Drill;
					mWCalculationOptions.DontApplyReset = true;
					mWCalculationOptions.AddToCamListInMWCalculation = false;
					doDrill(mWCalculationOptions);
				}
			}
			else
			{
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamSlot()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.diemakerSlotCam;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doSlot();
				return;
			}
			ccVars.stpDrawing = 2;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamScan()
	{
		try
		{
			F_WFScan f_WFScan = new F_WFScan();
			f_WFScan.mwCamParameter = buMWCalcs.CopyCamParameter(buMWDiamalerVars.varMWDiemakerCamScanPars, buMWDiamalerVars.varbuDiemakerCamScanPars, out f_WFScan.buCamParameter);
			f_WFScan.Init();
			f_WFScan.ShowDialog();
			if (f_WFScan.PropertiesForm.Result == DialogResult.OK)
			{
				buMWDiamalerVars.varMWDiemakerCamScanPars = buMWCalcs.CopyCamParameter(f_WFScan.mwCamParameter, f_WFScan.buCamParameter, out buMWDiamalerVars.varbuDiemakerCamScanPars);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SaveDiemakerFile()
	{
		string fileName = AppPath.Settings + "\\Diemaker\\Diemaker.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("<Cf2Props>");
		for (int i = 0; i <= clsVar.Cf2Properties.Count - 1; i++)
		{
			arrayList.AddRange(clsVar.Cf2Properties[i].ToDefAll("", 2, SerilizationMode.MultiLine));
		}
		arrayList.Add("</Cf2Props>");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Diemaker Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<DiemakerSettings>");
		arrayList.AddRange(varDiemakerSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</DiemakerSettings>");
		arrayList.Add("<varGrindingShape>");
		arrayList.AddRange(buDiamakerCalc.varGrindingShape.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</varGrindingShape>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Diemaker Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		buMWDiamalerVars.varMWDiemakerCamWFContourPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour.bin");
		buMWDiamalerVars.varMWDiemakerCamWFContour4XPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour4X.bin");
		buMWDiamalerVars.varMWDiemakerCamWFPocketPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerWfPocket.bin");
		buMWDiamalerVars.varMWDiemakerCamDrillPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerDrill.bin");
		buMWDiamalerVars.varMWDiemakerCamDrillPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerScan.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshRoughPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmRough.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshParalelPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmParallel.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshContantZPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantZ.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshPencilPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmPencil.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshProjectionPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmProjection.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshContantCuspPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantCusp.bin");
		buMWDiamalerVars.varMWDiemakerCamMeshFlatlandPars.Serialize(AppPath.Settings + "\\Diemaker\\mwDiemakerTmFlatlands.bin");
		string fileName2 = AppPath.Settings + "\\Diemaker\\DiemakerCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   MW Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<MwCamSettings>");
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamWFContourPars.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamWFContour4XPars.ToDefAll("_varbuCamWFContour4XPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamWFPocketPars.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamDrillPars.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamDrillPars.ToDefAll("_varbuCamScanPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshRoughPars.ToDefAll("_varbuCamMeshRoughPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshParallelPars.ToDefAll("_varbuCamMeshParallelPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshConstantZPars.ToDefAll("_varbuCamMeshContantZPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshPencilPars.ToDefAll("_varbuCamMeshPencilPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshProjectionPars.ToDefAll("_varbuCamMeshProjectionPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshFlatlandsPars.ToDefAll("_varbuCamMeshFlatlandsPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWDiamalerVars.varbuDiemakerCamMeshConstantCuspPars.ToDefAll("_varbuCamMeshContantCuspPars", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</MwCamSettings>");
		buFile.SaveToFile(arrayList, fileName2);
	}

	public void OpenDiemakerFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Diemaker\\Diemaker.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			clsVar.Cf2Properties = new List<Cf2FileProperties>();
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.DiemakerMode.Enable)
				{
					buLog.addLog("Diemaker Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Diemaker Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<DiemakerSettings>", "</DiemakerSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization.Decode(arrayList, "", SerilizationMode.MultiLine, varDiemakerSettings);
						buLog.addLog("DiemakerSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<varGrindingShape>", "</varGrindingShape>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buDiamakerCalc.varGrindingShape);
						buLog.addLog("varGrindingShape Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					List<List<string>> list = new List<List<string>>();
					ArrayList CalcList2 = new ArrayList();
					list = new List<List<string>>();
					clsVar.Cf2Properties = new List<Cf2FileProperties>();
					buString.ListToSpecificList("<Cf2Props>", "</Cf2Props>", AddStartEndKey: true, arrayList, ref CalcList2);
					buString.ListToSpecificList("<Cf2FileProperties>", "</Cf2FileProperties>", AddStartEndKey: true, CalcList2, ref list);
					if (list.Count > 0)
					{
						for (int i = 0; i <= list.Count - 1; i++)
						{
							Cf2FileProperties cf2FileProperties = new Cf2FileProperties();
							buSerilization.Decode(list[i], "", SerilizationMode.MultiLine, cf2FileProperties);
							clsVar.Cf2Properties.Add(cf2FileProperties);
						}
					}
					CalcList2 = new ArrayList();
					list = new List<List<string>>();
				}
				catch (Exception mSException)
				{
					buLog.addLog("Diemaker Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Diemaker Settings Decoder Error");
				}
			}
			buLog.addLog("Diemaker Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamWFContourPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfPocket.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamWFPocketPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerWfContour4X.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamWFContour4XPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerDrill.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamDrillPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerScan.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamScanPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmRough.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshRoughPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmParallel.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshParalelPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantZ.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshContantZPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmPencil.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshPencilPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmProjection.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshProjectionPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmConstantCusp.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshContantCuspPars.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Diemaker\\mwDiemakerTmFlatlands.bin");
			if (fileInfo.Exists)
			{
				buMWDiamalerVars.varMWDiemakerCamMeshFlatlandPars.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Diemaker\\DiemakerCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.DiemakerMode.Enable)
				{
					buLog.addLog("Diemaker Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Diemaker Cam Settings File Missing");
				}
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList3 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList3);
				if (CalcList3.Count > 0)
				{
					buSerilization.Decode(arrayList, "_varbuCamWFContourPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamWFContourPars);
					buSerilization.Decode(arrayList, "_varbuCamWFPocketPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamWFPocketPars);
					buSerilization.Decode(arrayList, "_varbuCamWFContour4XPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamWFContour4XPars);
					buSerilization.Decode(arrayList, "_varbuCamDrillPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamDrillPars);
					buSerilization.Decode(arrayList, "_varbuCamScanPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamScanPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshRoughPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshRoughPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshParallelPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshParallelPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshContantZPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshConstantZPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshPencilPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshPencilPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshProjectionPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshProjectionPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshFlatlandsPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshFlatlandsPars);
					buSerilization.Decode(arrayList, "_varbuCamMeshContantCuspPars", SerilizationMode.MultiLine, buMWDiamalerVars.varbuDiemakerCamMeshConstantCuspPars);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Marble Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			buLog.addLog("Diemaker Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Diemaker Settings Decoder Error");
		}
	}

	public void doSlot()
	{
		List<Entity> SortedEntities = new List<Entity>();
		List<Entity> selectedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption();
		SortSettings sortSettings = new SortSettings();
		SortResult Result = new SortResult();
		selectionOption.CircleToArc = true;
		selectionOption.SplitArcIfGreatThen180 = true;
		DialogBoxInput dialogBoxInput = new DialogBoxInput();
		dialogBoxInput.Value = varDiemakerSettings.SlotDiameter;
		dialogBoxInput.FormCaption = "Data";
		dialogBoxInput.ValueCaption = "Slot Diameter";
		dialogBoxInput.StartPosition = FormStartPosition.CenterScreen;
		dialogBoxInput.Init();
		dialogBoxInput.ShowDialog();
		if (dialogBoxInput.Result == DialogResult.OK)
		{
			CamOtherEntities = new List<Entity>();
			varDiemakerSettings.SlotDiameter = dialogBoxInput.Value;
			clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
			clsInit.cVector5.EntitiesPlaneCheck(ref selectedEntities);
			if (ccVars.entityEdges != null && ccVars.entityEdges.Count > 0)
			{
				selectedEntities.Clear();
				buVector5.CopyEntities(ccVars.entityEdges[0], ref selectedEntities);
			}
			sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
			if (ccVars.SelectionOP.ClickList.Count <= 0)
			{
				clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)selectedEntities[0]).StartPoint, ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
			}
			else
			{
				sortSettings.Option.ClickList = buVector5.ToPoint3D(ccVars.SelectionOP.ClickList);
				clsInit.cVector5.SortEntitiesByRefPoint(ccVars.SelectionOP.ClickList[0], ref selectedEntities, sortSettings, ref SortedEntities, ref Result);
			}
			List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
			clsInit.appCommand.undoBuffer();
			for (int i = 0; i <= SplitedEntitites.Count - 1; i++)
			{
				ccVars.UndoDont = true;
				CamOtherEntities = new List<Entity>();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				List<Point3D> Points = new List<Point3D>();
				clsMW.CamEntities.Clear();
				clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[i], 0.01, ref Points);
				if (!(varDiemakerSettings.SlotDiameter > ccVars.toolActive.Geometry.Diameter))
				{
					Entity item = new LinearPath(Points);
					clsMW.CamEntities.Add(item);
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
				}
				else
				{
					Point3D EndPnt = new Point3D();
					double num = clsInit.cVector5.PointAngle(Points[1], Points[0], Plane.XY);
					clsInit.cVector5.LineWithLengthAndAngle(Points[0], varDiemakerSettings.SlotDiameter / 2.0, num, ref EndPnt);
					List<Pnt3D> CopiedPnt = new List<Pnt3D>();
					new List<List<Pnt3D>>();
					buConversion5.Point3DToPnt3D(Points, ref CopiedPnt);
					double num2 = clsInit.cVector5.Length3D(Points[0], Points[1]);
					CompositeCurve compositeCurve = CompositeCurve.CreateSlot(ccVars.planeActive, EndPnt.X, EndPnt.Y, num2 - varDiemakerSettings.SlotDiameter, varDiemakerSettings.SlotDiameter / 2.0, Utility.DegToRad(num));
					compositeCurve.Regen(0.1);
					CamOtherEntities.Add(compositeCurve);
					clsMW.CamEntities.Add(compositeCurve);
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
				}
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.isRough = true;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				if (i > 0)
				{
					mWCalculationOptions.DontShowDialogBox = true;
				}
				camTp Cam = new camTp();
				doWireframeContour(mWCalculationOptions, ref Cam);
			}
			clsFiles.SaveParameter();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeContour(MWCalculationOptions MWCalcoptions, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		camResult Result = null;
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDiamalerVars.varMWDiemakerCamWFContourPars, buMWDiamalerVars.varbuDiemakerCamWFContourPars, out clsMW.varbuCamWFContourPars);
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		buMWDiamalerVars.varMWDiemakerCamWFContourPars = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWDiamalerVars.varbuDiemakerCamWFContourPars);
		if (num >= 1)
		{
			if (CamOtherEntities != null && CamOtherEntities.Count > 0)
			{
				for (int i = 0; i <= CamOtherEntities.Count - 1; i++)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(CamOtherEntities[i], ref copiedEnt);
					Cam.EntitiesOther.Add(copiedEnt);
				}
			}
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.WireFrame)
			{
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Contour)
				{
					if (MWCalcoptions.NumberofAxis != 4)
					{
						if (!((MWCalcoptions.NumberofAxis == 3) & !MWCalcoptions.isSpinConstantCalculation))
						{
							if ((MWCalcoptions.NumberofAxis == 3) & MWCalcoptions.isSpinConstantCalculation)
							{
								Cam.PreCodes.Add("G90");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G53");
								Cam.PreCodes.Add("G0 Z0");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M55");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("M154");
								Cam.PreCodes.Add("G75");
								Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
								Cam.PreCodes.Add("G75");
								for (int j = 0; j <= Cam.Tool.ToolNext.Count - 1; j++)
								{
									if (Cam.Tool.ToolNext[j].ToString().Trim().Length > 0)
									{
										Cam.AfterCodes.Add(Cam.Tool.ToolNext[j].ToString().Trim());
									}
								}
								Cam.AfterCodes.Add("M30");
								Cam.AfterCodes.Add("M2");
								for (int k = 0; k <= Cam.Tool.ToolPre.Count - 1; k++)
								{
									if (Cam.Tool.ToolPre[k].ToString().Trim().Length > 0)
									{
										Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[k].ToString().Trim());
									}
								}
								Cam.CamPoints[0].PreCodes.Add("M40 K" + clsMW.varbuCamWFContourPars.Strategy.SpinSpeed);
								clsInit.appCommand.CamAdd(Cam);
							}
						}
						else
						{
							Cam.PreCodes.Add("G90");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G53");
							Cam.PreCodes.Add("G0 Z0");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("M154");
							Cam.PreCodes.Add("G75");
							Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
							Cam.PreCodes.Add("G75");
							for (int l = 0; l <= Cam.Tool.ToolNext.Count - 1; l++)
							{
								if (Cam.Tool.ToolNext[l].ToString().Trim().Length > 0)
								{
									Cam.AfterCodes.Add(Cam.Tool.ToolNext[l].ToString().Trim());
								}
							}
							Cam.AfterCodes.Add("M30");
							Cam.AfterCodes.Add("M2");
							for (int m = 0; m <= Cam.Tool.ToolPre.Count - 1; m++)
							{
								if (Cam.Tool.ToolPre[m].ToString().Trim().Length > 0)
								{
									Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[m].ToString().Trim());
								}
							}
							clsInit.appCommand.CamAdd(Cam);
						}
					}
					else
					{
						Cam.PreCodes.Add("G90");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G53");
						Cam.PreCodes.Add("G0 Z0");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M55");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("M154");
						Cam.PreCodes.Add("G75");
						Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
						Cam.PreCodes.Add("G75");
						for (int n = 0; n <= Cam.Tool.ToolNext.Count - 1; n++)
						{
							if (Cam.Tool.ToolNext[n].ToString().Trim().Length > 0)
							{
								Cam.AfterCodes.Add(Cam.Tool.ToolNext[n].ToString().Trim());
							}
						}
						Cam.AfterCodes.Add("M30");
						Cam.AfterCodes.Add("M2");
						for (int num2 = 0; num2 <= Cam.Tool.ToolPre.Count - 1; num2++)
						{
							if (Cam.Tool.ToolPre[num2].ToString().Trim().Length > 0)
							{
								Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num2].ToString().Trim());
							}
						}
						clsInit.appCommand.CamAdd(Cam);
					}
				}
				if (MWCalcoptions.CamWireframeType == CamWireFrameType.Pocket && MWCalcoptions.NumberofAxis == 3)
				{
					Cam.PreCodes.Add("G90");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G53");
					Cam.PreCodes.Add("G0 Z0");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M154");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					for (int num3 = 0; num3 <= Cam.Tool.ToolNext.Count - 1; num3++)
					{
						if (Cam.Tool.ToolNext[num3].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[num3].ToString().Trim());
						}
					}
					Cam.AfterCodes.Add("M30");
					Cam.AfterCodes.Add("M2");
					for (int num4 = 0; num4 <= Cam.Tool.ToolPre.Count - 1; num4++)
					{
						if (Cam.Tool.ToolPre[num4].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[num4].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
			}
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doTriangleMesh(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		camResult Result = null;
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		if (num >= 1)
		{
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.TriangularMesh)
			{
				Cam.PreCodes.Add("<GCodes>");
				Cam.PreCodes.Add("Mode = " + 2);
				Cam.PreCodes.Add("G90");
				Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
				Cam.PreCodes.Add("G75");
				Cam.PreCodes.Add("G53");
				Cam.PreCodes.Add("G0 Z0");
				Cam.PreCodes.Add("G75");
				Cam.PreCodes.Add("M154");
				Cam.PreCodes.Add("G75");
				Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
				Cam.PreCodes.Add("G75");
				for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
				{
					if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
					{
						Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
					}
				}
				Cam.AfterCodes.Add("M30");
				Cam.AfterCodes.Add("M2");
				Cam.AfterCodes.Add("</GCodes>");
				for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
				{
					if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
					{
						Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
					}
				}
				clsInit.appCommand.CamAdd(Cam);
			}
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doDrill(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		camResult Result = null;
		int num = clsInit.appMW.doDrill(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		if (num >= 1)
		{
			Cam.Mode = MWCalcoptions.Mode;
			Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
			Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
			Cam.CamDrillType = MWCalcoptions.CamDrillType;
			Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
			if (MWCalcoptions.Mode == CamMode.Drill)
			{
				if (MWCalcoptions.NumberofAxis == 4)
				{
					Cam.PreCodes.Add("<GCodes>");
					Cam.PreCodes.Add("Mode = " + 1);
					Cam.PreCodes.Add("G90");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G53");
					Cam.PreCodes.Add("G0 Z0");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M55");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M154");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					for (int i = 0; i <= Cam.Tool.ToolNext.Count - 1; i++)
					{
						if (Cam.Tool.ToolNext[i].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[i].ToString().Trim());
						}
					}
					Cam.AfterCodes.Add("M30");
					Cam.AfterCodes.Add("M2");
					Cam.AfterCodes.Add("</GCodes>");
					for (int j = 0; j <= Cam.Tool.ToolPre.Count - 1; j++)
					{
						if (Cam.Tool.ToolPre[j].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[j].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
				if (MWCalcoptions.NumberofAxis == 3)
				{
					Cam.PreCodes.Add("<GCodes>");
					Cam.PreCodes.Add("Mode = " + 2);
					Cam.PreCodes.Add("G90");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G53");
					Cam.PreCodes.Add("G0 Z0");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("M154");
					Cam.PreCodes.Add("G75");
					Cam.PreCodes.Add("G54 X$G54.X$ Y$G54.Y$ Z$G54.Z$");
					Cam.PreCodes.Add("G75");
					for (int k = 0; k <= Cam.Tool.ToolNext.Count - 1; k++)
					{
						if (Cam.Tool.ToolNext[k].ToString().Trim().Length > 0)
						{
							Cam.AfterCodes.Add(Cam.Tool.ToolNext[k].ToString().Trim());
						}
					}
					Cam.AfterCodes.Add("M30");
					Cam.AfterCodes.Add("M2");
					Cam.AfterCodes.Add("</GCodes>");
					for (int l = 0; l <= Cam.Tool.ToolPre.Count - 1; l++)
					{
						if (Cam.Tool.ToolPre[l].ToString().Trim().Length > 0)
						{
							Cam.CamPoints[0].PreCodes.Add(Cam.Tool.ToolPre[l].ToString().Trim());
						}
					}
					clsInit.appCommand.CamAdd(Cam);
				}
			}
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}
}
