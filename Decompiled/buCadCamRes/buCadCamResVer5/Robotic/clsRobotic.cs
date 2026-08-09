using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps.Robotic;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using ns8;

namespace buCadCamResVer5.Robotic;

public class clsRobotic
{
	private List<Entity> list_0 = new List<Entity>();

	public List<Entity> SelectedMeshes = null;

	public List<RoboticSurfacePoint> SurfacePoints;

	public RobotItem activeRobotItem = new RobotItem();

	public Timer timSim = null;

	public Point3D pntStart = new Point3D();

	public Point3D pntBase = new Point3D();

	public int indexSim = -1;

	public int indexEnt = -1;

	public Entity SelectedEntity = null;

	public List<string> CodeList = new List<string>();

	public MWCalculationOptions LastMWOptions = null;

	public double LastPlungeFeed = 10.0;

	private static double double_0 = 1E-10;

	private static Random random_0 = new Random();

	public void Init()
	{
		buMWRoboticVars.Init();
		SurfacePoints = new List<RoboticSurfacePoint>();
	}

	public void cmdIJKToEuler()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count == 0)
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

	public void cmdCamRoughFlat()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic3AxisRoughFlat;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.Rough;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.isRough = true;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				mWCalculationOptions.CamRotateType = CamRotationType.Flat;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamRoughCircular()
	{
		try
		{
			F_CamFrontBack f_CamFrontBack = new F_CamFrontBack();
			f_CamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamFrontBack.Init();
			f_CamFrontBack.ShowDialog();
			RoboticTempVars.FaceType = f_CamFrontBack.FrontBack;
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic4AxisRoughCircular;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 4;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.Rough;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.isRough = true;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				mWCalculationOptions.CamRotateType = CamRotationType.Circular;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamParallelCutCircular(int AxisNumber)
	{
		try
		{
			F_CamFrontBack f_CamFrontBack = new F_CamFrontBack();
			f_CamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamFrontBack.Init();
			f_CamFrontBack.ShowDialog();
			RoboticTempVars.FaceType = f_CamFrontBack.FrontBack;
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic4AxisParallelCutCircular;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = AxisNumber;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.CamRotateType = CamRotationType.Circular;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamParallelCutFlat(int AxisNumber)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			if (AxisNumber != 3)
			{
				if (AxisNumber != 4)
				{
					ccVars.Action = actionTypeBU.robotic5AxisParallelCutFlat;
				}
				else
				{
					ccVars.Action = actionTypeBU.robotic4AxisParallelCutFlat;
				}
			}
			else
			{
				ccVars.Action = actionTypeBU.robotic3AxisParallelCutFlat;
			}
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = AxisNumber;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				mWCalculationOptions.CamRotateType = CamRotationType.Flat;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamConstantZCircular(int AxisNumber)
	{
		try
		{
			F_CamFrontBack f_CamFrontBack = new F_CamFrontBack();
			f_CamFrontBack.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamFrontBack.Init();
			f_CamFrontBack.ShowDialog();
			RoboticTempVars.FaceType = f_CamFrontBack.FrontBack;
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic4AxisContantZCircular;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = AxisNumber;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.CamRotateType = CamRotationType.Circular;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamConstantZFlat(int AxisNumber)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			if (AxisNumber != 3)
			{
				if (AxisNumber != 4)
				{
					ccVars.Action = actionTypeBU.robotic5AxisConstantZFlat;
				}
			}
			else
			{
				ccVars.Action = actionTypeBU.robotic3AxisConstantZFlat;
			}
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = AxisNumber;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ConstantZ;
				mWCalculationOptions.Mode = CamMode.TriangularMesh;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				mWCalculationOptions.CamRotateType = CamRotationType.Flat;
				doTriangleMesh(mWCalculationOptions);
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

	public void cmdCamParallelCutSurface()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic5AxisParallelCutSurface;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 5;
				mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.ParallelCuts;
				mWCalculationOptions.Mode = CamMode.Surface;
				mWCalculationOptions.CamSurfType = CamSurfaceType.SurfaceParalel;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doSurface(mWCalculationOptions);
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

	public void cmdCamTrimContour()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.robotic5AxisParallelCutSurface;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			clsMW.CamEntities.Clear();
			clsMW.CamEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 5;
				mWCalculationOptions.Mode = CamMode.Contour;
				mWCalculationOptions.isRough = false;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doTriangleMesh(mWCalculationOptions);
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
					mWCalculationOptions3.AddToCamListInMWCalculation = true;
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
					mWCalculationOptions2.AddToCamListInMWCalculation = true;
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
					mWCalculationOptions.AddToCamListInMWCalculation = true;
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

	public void cmdCamWireFrame()
	{
		try
		{
			string text = "";
			F_Notepad f_Notepad = new F_Notepad();
			text = buString5.StringListToString(CodeList, NewLineEnable: true);
			f_Notepad.Init(text);
			f_Notepad.Show();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdGetPointOnSurfece()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.miscGetPoint;
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			dynamicInfo.Command = AppLanguage.CadCamCommand[1] + " ";
			clsInit.appCommand.cmdMainFormStatusUpdate(dynamicInfo.Command + AppLanguage.CadCamStatus[0]);
			buRoboticCalc.varRoboticRunSettings.isFirst = false;
			buRoboticCalc.varRoboticRunSettings.isLast = false;
			if (SelectedMeshes != null)
			{
				SelectedMeshes.Clear();
			}
			SelectedMeshes = new List<Entity>();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is Mesh)
				{
					SelectedMeshes.Add((Mesh)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Clone());
				}
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdContouring()
	{
		SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		clsInit.appCommand.SelectionToEntities(ref buMWCalcs.CamEntities, option);
		MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
		mWCalculationOptions.NumberofAxis = 3;
		mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.Rough;
		mWCalculationOptions.Mode = CamMode.TriangularMesh;
		mWCalculationOptions.isRough = true;
		mWCalculationOptions.DontApplyReset = true;
		mWCalculationOptions.AddToCamListInMWCalculation = true;
		camTp Cam = new camTp();
		camResult Result = new camResult();
		buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamContouring, ref buMWCalcs.varCamContouringPars);
		clsInit.appMW.doContouring(mWCalculationOptions, ccVars.toolActive, ref Cam, ref Result);
		buMWCalcs.CopyCamParameter(buMWCalcs.varCamContouringPars, ref buMWRoboticVars.varCamContouring);
		SurfacePoints.Clear();
		clsInit.appCommand.undoBuffer();
		if (Cam.CamPoints.Count > 0)
		{
			for (int i = 0; i <= Cam.CamPoints[0].Points.Count - 1; i++)
			{
				RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
				ccVars.UndoDont = true;
				Vector3D vector3D = new Vector3D(Cam.CamPoints[0].Points[i].P9.A, Cam.CamPoints[0].Points[i].P9.B, Cam.CamPoints[0].Points[i].P9.C);
				double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
				double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
				double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
				Point3D startPoint = new Point3D(Cam.CamPoints[0].Points[i].P9.X, Cam.CamPoints[0].Points[i].P9.Y, Cam.CamPoints[0].Points[i].P9.Z);
				Point3D endPoint = new Point3D(Cam.CamPoints[0].Points[i].P9.X + vector3D.X * 50.0, Cam.CamPoints[0].Points[i].P9.Y + vector3D.Y * 50.0, Cam.CamPoints[0].Points[i].P9.Z + vector3D.Z * 50.0);
				EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData = new CustomData();
				Line Ent = null;
				clsInit.appCommand.CreateLine(startPoint, endPoint, entData, customData, ref Ent);
				roboticSurfacePoint.entTangent = Ent;
				roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[0].Points[i].P9.X, Cam.CamPoints[0].Points[i].P9.Y, Cam.CamPoints[0].Points[i].P9.Z, a, b, c);
				SurfacePoints.Add(roboticSurfacePoint);
			}
			for (int j = 0; j <= SurfacePoints.Count - 1; j++)
			{
				Pnt6D pntTangent = SurfacePoints[j].pntTangent;
				if (pntTangent != null)
				{
					double a2 = SurfacePoints[j].pntTangent.A;
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					num = ((a2 > 90.0) ? (a2 - 270.0) : (180.0 - (90.0 - a2)));
					if (!(SurfacePoints[j].pntTangent.B > 90.0))
					{
						num2 = SurfacePoints[j].pntTangent.B - 90.0;
					}
					else
					{
						num2 = SurfacePoints[j].pntTangent.B - 90.0;
					}
					num2 = 0.0;
					string text = SurfacePoints[j].pntTangent.X.ToString("f2") + ";" + SurfacePoints[j].pntTangent.Y.ToString("f2") + ";" + SurfacePoints[j].pntTangent.Z.ToString("f2") + ";";
					text = text + num.ToString("f2") + ";" + num2.ToString("f2") + ";" + num3.ToString("f2") + ";";
					text += "100;0;0;0;1;100;";
					Cam.PreCodes.Add(text);
					Pnt6DSimMove item = new Pnt6DSimMove(SurfacePoints[j].pntTangent.X, SurfacePoints[j].pntTangent.Y, SurfacePoints[j].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
					Cam.SimilationPoint.SimMove.Add(item);
				}
			}
			Cam.PreCodes.Insert(0, Cam.PreCodes.Count + 1 + ";");
			string text2 = SurfacePoints[SurfacePoints.Count - 1].pntTangent.X.ToString("f2") + ";" + SurfacePoints[SurfacePoints.Count - 1].pntTangent.Y.ToString("f2") + ";" + (SurfacePoints[SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
			text2 += "0.00;0.00;0.00;100;0;0;0;1;100;";
			Cam.PreCodes.Add(text2);
			Cam.Tool = new ToolBase5(ccVars.toolActive);
			for (int k = 0; k <= SurfacePoints.Count - 1; k++)
			{
				if (SurfacePoints[k].entTangent != null)
				{
					Entity copiedEnt = null;
					buVector5.CopyEntities(SurfacePoints[k].entTangent, ref copiedEnt);
					Cam.EntitiesOther.Add(copiedEnt);
				}
			}
			Cam.CamPoints.Clear();
			clsInit.appCommand.CamAdd(Cam);
			clsInit.appCommand.Reset();
		}
		clsFiles.SaveParameter();
	}

	public void cmdSurface()
	{
		SelectionOption option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		clsInit.appCommand.SelectionToEntities(ref buMWCalcs.CamEntities, option);
		MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
		mWCalculationOptions.NumberofAxis = 3;
		mWCalculationOptions.CamTriMeshType = CamTriangularMeshType.Rough;
		mWCalculationOptions.Mode = CamMode.TriangularMesh;
		mWCalculationOptions.isRough = true;
		mWCalculationOptions.DontApplyReset = true;
		mWCalculationOptions.AddToCamListInMWCalculation = true;
		if (buMWCalcs.CamEntities.Count > 0)
		{
			SelectedEntity = (Entity)buMWCalcs.CamEntities[0].Clone();
		}
		camTp Cam = new camTp();
		camResult Result = new camResult();
		buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis, ref buMWCalcs.varCamSurfacePars);
		buMWCalcs.entityProjection = new List<List<Entity>>();
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
			{
				Entity copiedEntity = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					copiedEntity.Translate(0.0, 0.0, 30.0);
					list.Add(copiedEntity);
				}
			}
		}
		buMWCalcs.varCamSurfacePars.mwPar.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
		if (list.Count > 0)
		{
			buMWCalcs.entityProjection.Add(list);
			buMWCalcs.varCamSurfacePars.mwPar.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
			buMWCalcs.varCamSurfacePars.mwPar.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
		}
		clsInit.appMW.doSurface(mWCalculationOptions, ccVars.toolActive, ref Cam, ref Result);
		buMWCalcs.CopyCamParameter(buMWCalcs.varCamSurfacePars, ref buMWRoboticVars.varCamSurface5Axis);
		SurfacePoints.Clear();
		clsInit.appCommand.undoBuffer();
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = false;
		}
		list_0 = new List<Entity>();
		CodeList = new List<string>();
		if (Cam.CamPoints.Count > 0)
		{
			for (int j = 0; j <= Cam.CamPoints.Count - 1; j++)
			{
				for (int k = 0; k <= Cam.CamPoints[j].Points.Count - 1; k++)
				{
					RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
					ccVars.UndoDont = true;
					Vector3D vector3D = new Vector3D(Cam.CamPoints[j].Points[k].P9.A, Cam.CamPoints[j].Points[k].P9.B, Cam.CamPoints[j].Points[k].P9.C);
					double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
					double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
					double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
					Point3D startPoint = new Point3D(Cam.CamPoints[j].Points[k].P9.X, Cam.CamPoints[j].Points[k].P9.Y, Cam.CamPoints[j].Points[k].P9.Z);
					Point3D endPoint = new Point3D(Cam.CamPoints[j].Points[k].P9.X + vector3D.X * 1.0, Cam.CamPoints[j].Points[k].P9.Y + vector3D.Y * 1.0, Cam.CamPoints[j].Points[k].P9.Z + vector3D.Z * 1.0);
					EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
					CustomData customData = new CustomData();
					Line Ent = null;
					clsInit.appCommand.CreateLine(startPoint, endPoint, entData, customData, ref Ent);
					roboticSurfacePoint.entTangent = Ent;
					roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[j].Points[k].P9.X, Cam.CamPoints[j].Points[k].P9.Y, Cam.CamPoints[j].Points[k].P9.Z, a, b, c);
					roboticSurfacePoint.vecNormal = new Vector3D(vector3D.X, vector3D.Y, vector3D.Z);
					SurfacePoints.Add(roboticSurfacePoint);
					ccVars.UndoDont = true;
					Ent.Color = Color.Black;
					Ent.ColorMethod = colorMethodType.byEntity;
					CustomData customData2 = new CustomData();
					customData2.typeDefination = entityTypeDefination.Simulation;
					Ent.EntityData = customData2;
					list_0.Add(Ent);
				}
			}
			for (int l = 0; l <= SurfacePoints.Count - 1; l++)
			{
				ccVars.UndoDont = true;
				Pnt6D pntTangent = SurfacePoints[l].pntTangent;
				if (pntTangent != null)
				{
					_ = SurfacePoints[l].pntTangent.A;
					_ = SurfacePoints[l].pntTangent.B;
					double num = 0.0;
					double num2 = 0.0;
					double num3 = 0.0;
					num = SurfacePoints[l].pntTangent.A - 90.0;
					if (!(SurfacePoints[l].pntTangent.B > 90.0))
					{
						num2 = 180.0 - (90.0 - SurfacePoints[l].pntTangent.B);
					}
					else
					{
						num2 = SurfacePoints[l].pntTangent.B - 270.0;
					}
					num2 = SurfacePoints[l].pntTangent.B - 90.0;
					num3 = SurfacePoints[l].pntTangent.C;
					string text = SurfacePoints[l].pntTangent.X.ToString("f2") + ";" + SurfacePoints[l].pntTangent.Y.ToString("f2") + ";" + SurfacePoints[l].pntTangent.Z.ToString("f2") + ";";
					text = text + num.ToString("f2") + ";" + num2.ToString("f2") + ";" + num3.ToString("f2") + ";";
					text = text + SurfacePoints[l].vecNormal.X.ToString("f2") + ";" + SurfacePoints[l].vecNormal.Y.ToString("f2") + ";" + SurfacePoints[l].vecNormal.Z.ToString("f2") + ";";
					text += "100;0;0;0;1;100;";
					Cam.PreCodes.Add(text);
					string text2 = SurfacePoints[l].pntTangent.X.ToString("f2") + " ; " + SurfacePoints[l].pntTangent.Y.ToString("f2") + " ; " + SurfacePoints[l].pntTangent.Z.ToString("f2") + " ; ";
					text2 = text2 + num.ToString("f2") + " ; " + num2.ToString("f2") + " ; " + num3.ToString("f2") + " ; ";
					text2 = text2 + SurfacePoints[l].vecNormal.X.ToString("f2") + " ; " + SurfacePoints[l].vecNormal.Y.ToString("f2") + " ; " + SurfacePoints[l].vecNormal.Z.ToString("f2");
					CodeList.Add(text2);
					new Pnt6DSim(SurfacePoints[l].pntTangent.X, SurfacePoints[l].pntTangent.Y, SurfacePoints[l].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
				}
			}
			Cam.PreCodes.Insert(0, Cam.PreCodes.Count + 1 + ";");
			string text3 = SurfacePoints[SurfacePoints.Count - 1].pntTangent.X.ToString("f2") + ";" + SurfacePoints[SurfacePoints.Count - 1].pntTangent.Y.ToString("f2") + ";" + (SurfacePoints[SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
			text3 += "0.00;0.00;0.000.00;0.00;0.00;100;0;0;0;1;100;";
			Cam.PreCodes.Add(text3);
			Cam.Tool = new ToolBase5(ccVars.toolActive);
			double num4 = 10000000.0;
			for (int m = 0; m <= Cam.SimilationPoint.SimMove.Count - 1; m++)
			{
				double num5 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[m].A, Cam.SimilationPoint.SimMove[m].B, Cam.SimilationPoint.SimMove[m].C), new Point3D(), Plane.XY);
				double b2 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[m].A, Cam.SimilationPoint.SimMove[m].B, Cam.SimilationPoint.SimMove[m].C), new Point3D(), Plane.XZ);
				double num6 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[m].A, Cam.SimilationPoint.SimMove[m].B, Cam.SimilationPoint.SimMove[m].C), new Point3D(), Plane.YZ);
				if (!(num5 == 0.0 && num4 != 0.0))
				{
				}
				Cam.SimilationPoint.SimMove[m].A = num6 - 90.0;
				Cam.SimilationPoint.SimMove[m].B = b2;
				if (!(Cam.SimilationPoint.SimMove[m].A > 0.0))
				{
					Cam.SimilationPoint.SimMove[m].C = num5 - 90.0;
				}
				else
				{
					Cam.SimilationPoint.SimMove[m].C = num5 + 90.0;
				}
				num4 = num5;
			}
			Cam.CamPoints.Clear();
			clsInit.appCommand.CamAdd(Cam);
			clsInit.appCommand.Reset();
		}
		clsFiles.SaveParameter();
	}

	public void cmdContourByPoints()
	{
		try
		{
			if (SurfacePoints.Count > 0)
			{
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 5;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doContourBySelected(mWCalculationOptions);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSurfaceByPoints()
	{
		try
		{
			if (SurfacePoints.Count > 0)
			{
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 5;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.AddToCamListInMWCalculation = true;
				doSurfaceBySelected(mWCalculationOptions);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSurfaceToCurvature()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.surfaceConvertToMeshFace;
			dynamicInfo.Command = AppLanguage.CadCamCommand[36];
			ccVars.selectionProcess = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doGetCurveture();
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

	public void cmdEditCurvaturePoints()
	{
		try
		{
			F_RoboticSurfacePoints f_RoboticSurfacePoints = new F_RoboticSurfacePoints();
			for (int i = 0; i <= SurfacePoints.Count - 1; i++)
			{
				RoboticSurfacePoint item = new RoboticSurfacePoint(SurfacePoints[i]);
				f_RoboticSurfacePoints.SurfPoints.Add(item);
			}
			f_RoboticSurfacePoints.TopMost = true;
			f_RoboticSurfacePoints.isTangent = true;
			f_RoboticSurfacePoints.Init();
			f_RoboticSurfacePoints.DataValueChanged += doReCalculateSurfacePoints;
			f_RoboticSurfacePoints.SelectedIndexChanged += doSelecredPointChanged;
			f_RoboticSurfacePoints.Show();
			if (f_RoboticSurfacePoints.PropertiesForm.Result == DialogResult.OK)
			{
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdShowSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Text = "Settings";
			f_ClassViewerDialog.Value = buRoboticCalc.varRoboticSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				buRoboticCalc.varRoboticSettings = new RoboticSettings((RoboticSettings)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdContourFollow()
	{
		try
		{
			doContourFromWireAndAngle(45.0);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdRoboticSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Settings";
			f_ClassViewerDialog.Value = buRoboticCalc.varRoboticSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				buRoboticCalc.varRoboticSettings = new RoboticSettings((RoboticSettings)f_ClassViewerDialog.Value);
				SaveRoboticFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdRoboticRecalculate()
	{
		if (ccVars.Pages[ccVars.PageIndex].Cams.Count > 0 && LastMWOptions != null)
		{
			ToolPathToRobotPathCode(ccVars.Pages[ccVars.PageIndex].Cams[0], LastMWOptions, LastPlungeFeed);
		}
	}

	public void cmdRoboticShowCode(bool SaveFile)
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				bool flag = false;
				string text = "";
				string text2 = "";
				if (SaveFile)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = "Pdl Files (.pdl)|*.pdl";
					saveFileDialog.FilterIndex = 1;
					flag = false;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						flag = true;
						text2 = saveFileDialog.FileName;
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
					}
				}
				if (!flag)
				{
					return;
				}
				string newValue = "";
				if (text2.Length > 0)
				{
					newValue = buFile5.getFileNameWithoutExtension(text2);
				}
				if (activeRobotItem.Codes.Count > 0)
				{
					activeRobotItem.Codes[0] = activeRobotItem.Codes[0].Replace("$$$", newValue);
					activeRobotItem.Codes[activeRobotItem.Codes.Count - 1] = activeRobotItem.Codes[activeRobotItem.Codes.Count - 1].Replace("$$$", newValue);
					text = buString5.StringListToString(activeRobotItem.Codes);
					if (!SaveFile)
					{
						F_Notepad f_Notepad = new F_Notepad();
						f_Notepad.Init(text);
						f_Notepad.Show();
						text = "";
					}
					else
					{
						buFile5.SaveToFile(text, text2);
						text = "";
						clsFiles.SaveParameter();
					}
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.NoPageOpened);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentences.NotAvailableDemoMode);
		}
	}

	public void ToolPathToGCode(camTp Cam)
	{
		if (Cam.CamPoints.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
		{
			for (int j = 0; j <= Cam.CamPoints[i].Points.Count - 1; j++)
			{
				RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
				ccVars.UndoDont = true;
				Vector3D vector3D = new Vector3D(Cam.CamPoints[i].Points[j].P9.A, Cam.CamPoints[i].Points[j].P9.B, Cam.CamPoints[i].Points[j].P9.C);
				double c = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XY);
				double b = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.XZ);
				double a = clsInit.cVector5.PointAngle(new Point3D(vector3D.X, vector3D.Y, vector3D.Z), new Point3D(), Plane.YZ);
				Point3D startPoint = new Point3D(Cam.CamPoints[i].Points[j].P9.X, Cam.CamPoints[i].Points[j].P9.Y, Cam.CamPoints[i].Points[j].P9.Z);
				Point3D endPoint = new Point3D(Cam.CamPoints[i].Points[j].P9.X + vector3D.X * 50.0, Cam.CamPoints[i].Points[j].P9.Y + vector3D.Y * 50.0, Cam.CamPoints[i].Points[j].P9.Z + vector3D.Z * 50.0);
				EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData = new CustomData();
				Line Ent = null;
				clsInit.appCommand.CreateLine(startPoint, endPoint, entData, customData, ref Ent);
				roboticSurfacePoint.entTangent = Ent;
				roboticSurfacePoint.pntTangent = new Pnt6D(Cam.CamPoints[i].Points[j].P9.X, Cam.CamPoints[i].Points[j].P9.Y, Cam.CamPoints[i].Points[j].P9.Z, a, b, c);
				SurfacePoints.Add(roboticSurfacePoint);
			}
		}
		for (int k = 0; k <= SurfacePoints.Count - 1; k++)
		{
			Pnt6D pntTangent = SurfacePoints[k].pntTangent;
			if (pntTangent != null)
			{
				double a2 = SurfacePoints[k].pntTangent.A;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				num = ((a2 > 90.0) ? (a2 - 270.0) : (180.0 - (90.0 - a2)));
				if (!(SurfacePoints[k].pntTangent.B > 90.0))
				{
					num2 = SurfacePoints[k].pntTangent.B - 90.0;
				}
				else
				{
					num2 = SurfacePoints[k].pntTangent.B - 90.0;
				}
				num2 = 0.0;
				string text = SurfacePoints[k].pntTangent.X.ToString("f2") + ";" + SurfacePoints[k].pntTangent.Y.ToString("f2") + ";" + SurfacePoints[k].pntTangent.Z.ToString("f2") + ";";
				text = text + num.ToString("f2") + ";" + num2.ToString("f2") + ";" + num3.ToString("f2") + ";";
				text += "100;0;0;0;1;100;";
				Cam.PreCodes.Add(text);
				new Pnt6DSim(SurfacePoints[k].pntTangent.X, SurfacePoints[k].pntTangent.Y, SurfacePoints[k].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
			}
		}
		Cam.PreCodes.Insert(0, Cam.PreCodes.Count + 1 + ";");
		string text2 = SurfacePoints[SurfacePoints.Count - 1].pntTangent.X.ToString("f2") + ";" + SurfacePoints[SurfacePoints.Count - 1].pntTangent.Y.ToString("f2") + ";" + (SurfacePoints[SurfacePoints.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
		text2 += "0.00;0.00;0.00;100;0;0;0;1;100;";
		Cam.PreCodes.Add(text2);
		Cam.Tool = new ToolBase5(ccVars.toolActive);
		double num4 = 10000000.0;
		for (int l = 0; l <= Cam.SimilationPoint.SimMove.Count - 1; l++)
		{
			double num5 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[l].A, Cam.SimilationPoint.SimMove[l].B, Cam.SimilationPoint.SimMove[l].C), new Point3D(), Plane.XY);
			double b2 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[l].A, Cam.SimilationPoint.SimMove[l].B, Cam.SimilationPoint.SimMove[l].C), new Point3D(), Plane.XZ);
			double num6 = clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[l].A, Cam.SimilationPoint.SimMove[l].B, Cam.SimilationPoint.SimMove[l].C), new Point3D(), Plane.YZ);
			if (!(num5 == 0.0 && num4 != 0.0))
			{
			}
			Cam.SimilationPoint.SimMove[l].A = num6 - 90.0;
			Cam.SimilationPoint.SimMove[l].B = b2;
			if (!(Cam.SimilationPoint.SimMove[l].A > 0.0))
			{
				Cam.SimilationPoint.SimMove[l].C = num5 - 90.0;
			}
			else
			{
				Cam.SimilationPoint.SimMove[l].C = num5 + 90.0;
			}
			num4 = num5;
		}
		Cam.CamPoints.Clear();
		clsInit.appCommand.CamAdd(Cam);
		clsInit.appCommand.Reset();
	}

	public void ToolPathToRobotPathCode(camTp Cam, MWCalculationOptions MWCalcoptions, double PlungeFeed)
	{
		activeRobotItem.ToolPaths.Clear();
		activeRobotItem.Codes.Clear();
		activeRobotItem = new RobotItem();
		if (Cam.CamPoints.Count > 0)
		{
			string text = "";
			text = "PROGRAM $$$ PROG_ARM = 1" + Environment.NewLine;
			text = text + "ROUTINE ToolFrame(ai_tool, ai_frame, ai_arm : INTEGER()) EXPORTED FROM tt_tool GLOBAL" + Environment.NewLine;
			text = text + "BEGIN" + Environment.NewLine;
			text = text + "  $CNFG_CARE:= FALSE" + Environment.NewLine;
			text = text + "  $TURN_CARE:= FALSE" + Environment.NewLine;
			text = text + "  $SING_CARE:= TRUE" + Environment.NewLine;
			text = text + "  $JNT_MTURN:= FALSE" + Environment.NewLine;
			text = text + "  $ORNT_TYPE:= WRIST_JNT" + Environment.NewLine;
			text = text + "  ToolFrame(" + buRoboticCalc.varRoboticSettings.ToolFrame + "," + buRoboticCalc.varRoboticSettings.WorkFrame + "," + buRoboticCalc.varRoboticSettings.RobotFrame + ")" + Environment.NewLine;
			text = text + "  $ARM_OVR:=" + buRoboticCalc.varRoboticSettings.FeedOverride.ToString("f0") + Environment.NewLine;
			text = text + "  MOVE ARM[1] TO $CAL_SYS" + Environment.NewLine;
			activeRobotItem.Codes.Add(text);
			RobotToolPath robotToolPath = null;
			List<RobotToolPath> list = new List<RobotToolPath>();
			for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
			{
				for (int j = 0; j <= Cam.CamPoints[i].Points.Count - 1; j++)
				{
					ccVars.UndoDont = true;
					Pnt9D p = Cam.CamPoints[i].Points[j].P9;
					RobotToolPath robotToolPath2 = new RobotToolPath();
					robotToolPath2.RoboPosition = CamToComauConverter.ConvertCamToComau(new Point3D(p.X, p.Y, p.Z), new Vector3D(p.A, p.B, p.C), null, Cam.Tool.CamData.DepthOffset);
					if (MWCalcoptions.NumberofAxis == 3)
					{
						if (robotToolPath2.RoboPosition == null)
						{
							robotToolPath2.RoboPosition = new RobotPose();
						}
						robotToolPath2.RoboPosition.Position = new Point3D(p.X, p.Y, p.Z + Cam.Tool.CamData.DepthOffset);
						robotToolPath2.RoboPosition.Orientation = new EulerAngles(0.0, 0.0, 0.0);
					}
					if (MWCalcoptions.NumberofAxis == 4 && ((MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts) & (MWCalcoptions.CamRotateType == CamRotationType.Flat)))
					{
						if (robotToolPath2.RoboPosition.Orientation.Roll != 180.0)
						{
							if (robotToolPath2.RoboPosition.Orientation.Roll == 0.0)
							{
								robotToolPath2.RoboPosition.Orientation.Pitch = 360.0 - robotToolPath2.RoboPosition.Orientation.Pitch;
								robotToolPath2.RoboPosition.Orientation.Roll = -180.0;
								robotToolPath2.RoboPosition.Orientation.Yaw = -90.0;
							}
						}
						else
						{
							robotToolPath2.RoboPosition.Orientation.Roll = -180.0;
							robotToolPath2.RoboPosition.Orientation.Yaw = -90.0;
						}
					}
					if (robotToolPath2.RoboPosition == null && robotToolPath != null)
					{
						robotToolPath2.RoboPosition = new RobotPose();
						robotToolPath2.RoboPosition.Position = new Point3D(p.X, p.Y, p.Z);
						robotToolPath2.RoboPosition.Orientation = new EulerAngles(robotToolPath.RoboPosition.Orientation.Roll, robotToolPath.RoboPosition.Orientation.Pitch, robotToolPath.RoboPosition.Orientation.Yaw);
					}
					if (p.C > 0.9999 && robotToolPath != null)
					{
						robotToolPath2.RoboPosition.Orientation = new EulerAngles(robotToolPath.RoboPosition.Orientation.Roll, robotToolPath.RoboPosition.Orientation.Pitch, robotToolPath.RoboPosition.Orientation.Yaw);
					}
					if (robotToolPath == null || !(Math.Abs(robotToolPath.RoboPosition.Orientation.Pitch - robotToolPath2.RoboPosition.Orientation.Pitch) > 20.0))
					{
					}
					if (robotToolPath2.RoboPosition == null)
					{
						robotToolPath2.RoboPosition = new RobotPose();
						robotToolPath2.RoboPosition.Position = new Point3D(p.X, p.Y, p.Z);
						robotToolPath2.RoboPosition.Orientation = new EulerAngles(0.0, 90.0, 0.0);
					}
					if (robotToolPath2.RoboPosition.Orientation.Yaw == 90.0)
					{
					}
					robotToolPath = new RobotToolPath();
					robotToolPath.RoboPosition.Orientation = new EulerAngles(robotToolPath2.RoboPosition.Orientation.Roll, robotToolPath2.RoboPosition.Orientation.Pitch, robotToolPath2.RoboPosition.Orientation.Yaw);
					robotToolPath.RoboPosition.Position = new Point3D(robotToolPath2.RoboPosition.Position.X, robotToolPath2.RoboPosition.Position.Y, robotToolPath2.RoboPosition.Position.Z);
					robotToolPath.RoboPosition.PositionNoTool = new Point3D(robotToolPath2.RoboPosition.PositionNoTool.X, robotToolPath2.RoboPosition.PositionNoTool.Y, robotToolPath2.RoboPosition.PositionNoTool.Z);
					robotToolPath2.RoboPosition.Orientation.Yaw = robotToolPath2.RoboPosition.Orientation.Yaw - 90.0;
					robotToolPath2.RoboPosition.IJKVector = new Vector3D(p.A, p.B, p.C);
					robotToolPath2.RoboPosition.PositionNoTool = new Point3D(p.X, p.Y, p.Z);
					double B = 0.0;
					double C = 0.0;
					CalculateBCAngles(p.A, p.B, p.C, ref B, ref C);
					robotToolPath2.RoboPosition.PlaneAngle.B = B;
					robotToolPath2.RoboPosition.PlaneAngle.C = C;
					CustomData customData = new CustomData();
					customData.typeDefination = entityTypeDefination.SurfaceInfo;
					if (Cam.CamPoints[i].Points[j].Type != 0)
					{
						if (Cam.CamPoints[i].Points[j].Feed != PlungeFeed)
						{
							robotToolPath2.RoboPosition.isCuttingMove = true;
						}
						else
						{
							robotToolPath2.RoboPosition.isPlungeMove = true;
						}
					}
					else
					{
						robotToolPath2.RoboPosition.isQuickMove = true;
					}
					list.Add(robotToolPath2);
				}
			}
			double plungeMoveDevideLength = buRoboticCalc.varRoboticSettings.PlungeMoveDevideLength;
			double cuttingMoveDevideLength = buRoboticCalc.varRoboticSettings.CuttingMoveDevideLength;
			double angleMoveDevideLength = buRoboticCalc.varRoboticSettings.AngleMoveDevideLength;
			for (int k = 0; k <= list.Count - 1; k++)
			{
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				if (k <= 0)
				{
					activeRobotItem.ToolPaths.Add(list[k]);
					continue;
				}
				num = Point3D.Distance(list[k - 1].RoboPosition.Position, list[k].RoboPosition.Position);
				_ = list[k].RoboPosition.Orientation.Yaw - list[k - 1].RoboPosition.Orientation.Yaw;
				num2 = list[k].RoboPosition.Orientation.Pitch - list[k - 1].RoboPosition.Orientation.Pitch;
				num3 = list[k].RoboPosition.Orientation.Roll - list[k - 1].RoboPosition.Orientation.Roll;
				bool flag = false;
				bool flag2 = false;
				if (!list[k].RoboPosition.isPlungeMove)
				{
					if (list[k].RoboPosition.isCuttingMove && num > cuttingMoveDevideLength * 2.0)
					{
						int count = (int)buNumeric5.RoundToUpper(Math.Abs(num) / cuttingMoveDevideLength);
						if (!(Math.Abs(num2) > angleMoveDevideLength))
						{
						}
						List<RobotPose> Devided = new List<RobotPose>();
						bool flag3 = clsInit.cRobotic.DevideToolPath(list[k - 1].RoboPosition, list[k].RoboPosition, count, ref Devided);
						if (Devided.Count > 1 && flag3)
						{
							for (int l = 1; l <= Devided.Count - 1; l++)
							{
								RobotToolPath robotToolPath3 = new RobotToolPath();
								robotToolPath3.RoboPosition = Devided[l];
								robotToolPath3.entVectorNormal = new Line(new Point3D(Devided[l].PositionNoTool.X, Devided[l].PositionNoTool.Y, Devided[l].PositionNoTool.Z), new Point3D(Devided[l].PositionNoTool.X + Devided[l].IJKVector.X * 10.0, Devided[l].PositionNoTool.Y + Devided[l].IJKVector.Y * 10.0, Devided[l].PositionNoTool.Z + Devided[l].IJKVector.Z * 10.0));
								CustomData entityData = new CustomData();
								robotToolPath3.entVectorNormal.EntityData = entityData;
								activeRobotItem.ToolPaths.Add(robotToolPath3);
							}
							flag = true;
							flag2 = true;
						}
					}
				}
				else if (num > plungeMoveDevideLength * 2.0)
				{
					int count2 = (int)buNumeric5.RoundToUpper(Math.Abs(num) / plungeMoveDevideLength);
					List<RobotPose> Devided2 = new List<RobotPose>();
					bool flag4 = clsInit.cRobotic.DevideToolPath(list[k - 1].RoboPosition, list[k].RoboPosition, count2, ref Devided2);
					if (Devided2.Count > 1 && flag4)
					{
						for (int m = 1; m <= Devided2.Count - 1; m++)
						{
							RobotToolPath robotToolPath4 = new RobotToolPath();
							robotToolPath4.RoboPosition = Devided2[m];
							robotToolPath4.entVectorNormal = new Line(new Point3D(Devided2[m].PositionNoTool.X, Devided2[m].PositionNoTool.Y, Devided2[m].PositionNoTool.Z), new Point3D(Devided2[m].PositionNoTool.X + Devided2[m].IJKVector.X * 10.0, Devided2[m].PositionNoTool.Y + Devided2[m].IJKVector.Y * 10.0, Devided2[m].PositionNoTool.Z + Devided2[m].IJKVector.Z * 10.0));
							CustomData entityData2 = new CustomData();
							robotToolPath4.entVectorNormal.EntityData = entityData2;
							activeRobotItem.ToolPaths.Add(robotToolPath4);
						}
						flag = true;
						flag2 = true;
					}
				}
				if (!flag)
				{
					if (Math.Abs(num3) > angleMoveDevideLength)
					{
						int count3 = (int)buNumeric5.RoundToUpper(Math.Abs(num3) / angleMoveDevideLength);
						List<RobotPose> Devided3 = new List<RobotPose>();
						bool flag5 = clsInit.cRobotic.DevideToolPath(list[k - 1].RoboPosition, list[k].RoboPosition, count3, ref Devided3);
						if (Devided3.Count > 1 && flag5)
						{
							for (int n = 1; n <= Devided3.Count - 1; n++)
							{
								RobotToolPath robotToolPath5 = new RobotToolPath();
								robotToolPath5.RoboPosition = Devided3[n];
								robotToolPath5.entVectorNormal = new Line(new Point3D(Devided3[n].PositionNoTool.X, Devided3[n].PositionNoTool.Y, Devided3[n].PositionNoTool.Z), new Point3D(Devided3[n].PositionNoTool.X + Devided3[n].IJKVector.X * 10.0, Devided3[n].PositionNoTool.Y + Devided3[n].IJKVector.Y * 10.0, Devided3[n].PositionNoTool.Z + Devided3[n].IJKVector.Z * 10.0));
								CustomData entityData3 = new CustomData();
								robotToolPath5.entVectorNormal.EntityData = entityData3;
								activeRobotItem.ToolPaths.Add(robotToolPath5);
							}
							flag = true;
							flag2 = true;
						}
					}
					if (Math.Abs(num2) > angleMoveDevideLength)
					{
						RobotPose robotPose = new RobotPose(list[k - 1].RoboPosition);
						RobotPose robotPose2 = new RobotPose(list[k].RoboPosition);
						if (Math.Abs(num2) > 180.0)
						{
							if (!(num2 > 0.0))
							{
								num2 = list[k].RoboPosition.Orientation.Pitch - (list[k - 1].RoboPosition.Orientation.Pitch - 360.0);
								robotPose.Orientation.Pitch = list[k - 1].RoboPosition.Orientation.Pitch - 360.0;
							}
							else
							{
								num2 = list[k].RoboPosition.Orientation.Pitch - 360.0 - list[k - 1].RoboPosition.Orientation.Pitch;
								robotPose2.Orientation.Pitch = list[k].RoboPosition.Orientation.Pitch - 360.0;
							}
						}
						if (Math.Abs(num2) > angleMoveDevideLength)
						{
							int num4 = (int)buNumeric5.RoundToUpper(Math.Abs(num2) / angleMoveDevideLength);
							if (num4 <= 5)
							{
							}
							List<RobotPose> Devided4 = new List<RobotPose>();
							bool flag6 = clsInit.cRobotic.DevideToolPath(robotPose, robotPose2, num4, ref Devided4);
							if (Devided4.Count > 1 && flag6)
							{
								for (int num5 = 1; num5 <= Devided4.Count - 1; num5++)
								{
									RobotToolPath robotToolPath6 = new RobotToolPath();
									robotToolPath6.RoboPosition = Devided4[num5];
									if (robotToolPath6.RoboPosition.Orientation.Pitch < 0.0)
									{
										robotToolPath6.RoboPosition.Orientation.Pitch = 360.0 + robotToolPath6.RoboPosition.Orientation.Pitch;
									}
									robotToolPath6.entVectorNormal = new Line(new Point3D(Devided4[num5].PositionNoTool.X, Devided4[num5].PositionNoTool.Y, Devided4[num5].PositionNoTool.Z), new Point3D(Devided4[num5].PositionNoTool.X + Devided4[num5].IJKVector.X * 10.0, Devided4[num5].PositionNoTool.Y + Devided4[num5].IJKVector.Y * 10.0, Devided4[num5].PositionNoTool.Z + Devided4[num5].IJKVector.Z * 10.0));
									CustomData entityData4 = new CustomData();
									robotToolPath6.entVectorNormal.EntityData = entityData4;
									activeRobotItem.ToolPaths.Add(robotToolPath6);
								}
								flag = true;
								flag2 = true;
							}
						}
					}
				}
				if (!flag2)
				{
					activeRobotItem.ToolPaths.Add(list[k]);
				}
			}
			for (int num6 = 0; num6 <= activeRobotItem.ToolPaths.Count - 1; num6++)
			{
				string text2 = "  MOVEFLY LINEAR TO POS(" + activeRobotItem.ToolPaths[num6].RoboPosition.Position.X.ToString("f2") + ", " + activeRobotItem.ToolPaths[num6].RoboPosition.Position.Y.ToString("f2") + ", " + activeRobotItem.ToolPaths[num6].RoboPosition.Position.Z.ToString("f2") + ", ";
				text2 = text2 + activeRobotItem.ToolPaths[num6].RoboPosition.Orientation.Roll.ToString("f2") + ", " + activeRobotItem.ToolPaths[num6].RoboPosition.Orientation.Pitch.ToString("f2") + ", " + activeRobotItem.ToolPaths[num6].RoboPosition.Orientation.Yaw.ToString("f2") + ",'w') ADVANCE";
				activeRobotItem.Code = activeRobotItem.Code + text2 + Environment.NewLine;
				if (activeRobotItem.Code.Length > 1000)
				{
					activeRobotItem.Codes.Add(activeRobotItem.Code);
					activeRobotItem.Code = "";
				}
			}
			if (activeRobotItem.Code.Length > 0)
			{
				activeRobotItem.Codes.Add(activeRobotItem.Code);
				activeRobotItem.Code = "";
			}
			for (int num7 = 0; num7 <= Cam.SimilationPoint.SimMove.Count - 1; num7++)
			{
				Pnt6DSimMove pnt6DSimMove = Cam.SimilationPoint.SimMove[num7];
				double B2 = 0.0;
				double C2 = 0.0;
				CalculateBCAngles(pnt6DSimMove.A, pnt6DSimMove.B, pnt6DSimMove.C, ref B2, ref C2);
				pnt6DSimMove.A = 0.0;
				pnt6DSimMove.B = B2;
				pnt6DSimMove.C = C2;
			}
			activeRobotItem.Codes.Add("END $$$");
			string value = buString5.StringListToString(activeRobotItem.Codes);
			Cam.PreCodes.Clear();
			Cam.PreCodes.Add(value);
			Cam.EntitiesG1Orj.Clear();
			clsInit.appCommand.CamAdd(Cam);
			clsInit.appCommand.Reset();
		}
		LastMWOptions = MWCalcoptions;
		LastPlungeFeed = PlungeFeed;
	}

	public void SaveRoboticFile()
	{
		string fileName = AppPath.Settings + "\\Robotic\\Robotic.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Robotic Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<RoboticSettings>");
		arrayList.AddRange(buRoboticCalc.varRoboticSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</RoboticSettings>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Robotic Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
		buMWRoboticVars.varCamContouring.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticWfContour.bin");
		buMWRoboticVars.varCamWFPocket.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticWfPocket.bin");
		buMWRoboticVars.varCamDrill.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticDrill.bin");
		buMWRoboticVars.varCamContouring.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticContouring.bin");
		buMWRoboticVars.varCamSurface4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticSurface4Axis.bin");
		buMWRoboticVars.varCamSurface5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticSurface5Axis.bin");
		buMWRoboticVars.varCamMeshRough3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmRough3Axis.bin");
		buMWRoboticVars.varCamMeshRough4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmRough4Axis.bin");
		buMWRoboticVars.varCamMeshParallel3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel3Axis.bin");
		buMWRoboticVars.varCamMeshParallel4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel4Axis.bin");
		buMWRoboticVars.varCamMeshParallel5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel5Axis.bin");
		buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ3Axis.bin");
		buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ4Axis.bin");
		buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.Serialize(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ5Axis.bin");
		string fileName2 = AppPath.Settings + "\\Robotic\\RoboticCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   MW Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<MwCamSettings>");
		arrayList.AddRange(buMWRoboticVars.varCamWFContour.buPar.ToDefAll("_varbuCamWFContourPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamWFPocket.buPar.ToDefAll("_varbuCamWFPocketPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamDrill.buPar.ToDefAll("_varbuCamDrillPars", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamContouring.buPar.ToDefAll("_buMWRoboticVars.varCamContouring", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamSurface4Axis.buPar.ToDefAll("_buMWRoboticVars.varCamSurface4Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamSurface5Axis.buPar.ToDefAll("_buMWRoboticVars.varCamSurface5Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshRough3Axis.buPar.ToDefAll("_varbuCamMeshRoughPars3Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshRough4Axis.buPar.ToDefAll("_varbuCamMeshRoughPars4Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshParallel3Axis.buPar.ToDefAll("_varbuCamMeshParallelPars3Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshParallel4Axis.buPar.ToDefAll("_varbuCamMeshParallelPars4Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshParallel5Axis.buPar.ToDefAll("_varbuCamMeshParallelPars5Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.ToDefAll("_varbuCamMeshContantZPars3Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.ToDefAll("_varbuCamMeshContantZPars4Axis", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.ToDefAll("_varbuCamMeshContantZPars5Axis", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</MwCamSettings>");
		buFile.SaveToFile(arrayList, fileName2);
	}

	public void OpenRoboticFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Robotic\\Robotic.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			clsVar.Cf2Properties = new List<Cf2FileProperties>();
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.RoboticMode.Enable)
				{
					buLog.addLog("Robotic Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Robotic Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<RoboticSettings>", "</RoboticSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buRoboticCalc.varRoboticSettings);
						buLog.addLog("RoboticSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Robotic Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Robotic Settings Decoder Error");
				}
			}
			buLog.addLog("Robotic Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticWfContour.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamWFContour.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticWfPocket.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamWFPocket.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticDrill.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamDrill.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticContouring.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamContouring.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticSurface4Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamSurface4Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticSurface5Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamSurface5Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmRough3Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmRough4Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel3Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshParallel3Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel4Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshParallel4Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmParallel5Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshParallel5Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ3Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ4Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			fileInfo = new FileInfo(AppPath.Settings + "\\Robotic\\mwRoboticTmConstantZ5Axis.bin");
			if (fileInfo.Exists)
			{
				buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Robotic\\RoboticCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.RoboticMode.Enable)
				{
					buLog.addLog("Robotic Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Robotic Cam Settings File Missing");
				}
				return;
			}
			arrayList = new ArrayList();
			buFile.OpenFromFile(fileName2, ref arrayList);
			try
			{
				ArrayList CalcList2 = new ArrayList();
				buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, arrayList, ref CalcList2);
				if (CalcList2.Count > 0)
				{
					buSerilization5.Decode(arrayList, "_varbuCamWFContourPars", SerilizationMode5.MultiLine, buMWRoboticVars.varCamWFContour.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamWFPocketPars", SerilizationMode5.MultiLine, buMWRoboticVars.varCamWFPocket.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamDrillPars", SerilizationMode5.MultiLine, buMWRoboticVars.varCamDrill.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshRoughPars3Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshRough3Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshRoughPars4Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshRough4Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshParallelPars3Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshParallel3Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshParallelPars4Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshParallel4Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshParallelPars5Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshParallel5Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshContantZPars3Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshContantZPars4Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
					buSerilization5.Decode(arrayList, "_varbuCamMeshContantZPars5Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
					buSerilization5.Decode(arrayList, "_buMWRoboticVars.varCamContouring", SerilizationMode5.MultiLine, buMWRoboticVars.varCamContouring.buPar);
					buSerilization5.Decode(arrayList, "_buMWRoboticVars.varCamSurface4Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamSurface4Axis.buPar);
					buSerilization5.Decode(arrayList, "_buMWRoboticVars.varCamSurface5Axis", SerilizationMode5.MultiLine, buMWRoboticVars.varCamSurface5Axis.buPar);
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
			buLog.addLog("Robotic Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Robotic Settings Decoder Error");
		}
	}

	public void DrawSurfacePointsAsDynamicLine(int SelectedPoint)
	{
		ccVars.pntDrawDynamicLinesArrColored.Clear();
		for (int i = 0; i <= SurfacePoints.Count - 1; i++)
		{
			Color color = Color.Red;
			Color color2 = Color.Purple;
			Color gold = Color.Gold;
			Color darkOrange = Color.DarkOrange;
			if (SelectedPoint != -1 && SelectedPoint == i)
			{
				color = Color.Blue;
				color2 = Color.Blue;
			}
			if (!SurfacePoints[i].Enable)
			{
				continue;
			}
			List<PointRGB> list = new List<PointRGB>();
			if (SurfacePoints[i].entNormal != null)
			{
				for (int j = 0; j <= SurfacePoints[i].entNormal.Vertices.Length - 1; j++)
				{
					Point3D point3D = buVector5.ToPoint3D(SurfacePoints[i].entNormal.Vertices[j]);
					list.Add(new PointRGB(point3D.X, point3D.Y, point3D.Z, color.R, color.G, color.B));
				}
			}
			if (SurfacePoints[i].entTangent != null)
			{
				for (int k = 0; k <= SurfacePoints[i].entTangent.Vertices.Length - 1; k++)
				{
					Point3D point3D2 = buVector5.ToPoint3D(SurfacePoints[i].entTangent.Vertices[k]);
					list.Add(new PointRGB(point3D2.X, point3D2.Y, point3D2.Z, color2.R, color2.G, color2.B));
				}
			}
			if (list.Count > 0)
			{
				ccVars.pntDrawDynamicLinesArrColored.Add(list);
			}
			list = new List<PointRGB>();
			if (SurfacePoints[i].entLeadIn != null)
			{
				for (int l = 0; l <= SurfacePoints[i].entLeadIn.Vertices.Length - 1; l++)
				{
					Point3D point3D3 = buVector5.ToPoint3D(SurfacePoints[i].entLeadIn.Vertices[l]);
					list.Add(new PointRGB(point3D3.X, point3D3.Y, point3D3.Z, gold.R, gold.G, gold.B));
				}
			}
			if (list.Count > 0)
			{
				ccVars.pntDrawDynamicLinesArrColored.Add(list);
			}
			list = new List<PointRGB>();
			if (SurfacePoints[i].entSafeIn != null)
			{
				for (int m = 0; m <= SurfacePoints[i].entSafeIn.Vertices.Length - 1; m++)
				{
					Point3D point3D4 = buVector5.ToPoint3D(SurfacePoints[i].entSafeIn.Vertices[m]);
					list.Add(new PointRGB(point3D4.X, point3D4.Y, point3D4.Z, darkOrange.R, darkOrange.G, darkOrange.B));
				}
			}
			if (list.Count > 0)
			{
				ccVars.pntDrawDynamicLinesArrColored.Add(list);
			}
			list = new List<PointRGB>();
			if (SurfacePoints[i].entLeadOut != null)
			{
				for (int n = 0; n <= SurfacePoints[i].entLeadOut.Vertices.Length - 1; n++)
				{
					Point3D point3D5 = buVector5.ToPoint3D(SurfacePoints[i].entLeadOut.Vertices[n]);
					list.Add(new PointRGB(point3D5.X, point3D5.Y, point3D5.Z, gold.R, gold.G, gold.B));
				}
			}
			if (list.Count > 0)
			{
				ccVars.pntDrawDynamicLinesArrColored.Add(list);
			}
			list = new List<PointRGB>();
			if (SurfacePoints[i].entSafeOut != null)
			{
				for (int num = 0; num <= SurfacePoints[i].entSafeOut.Vertices.Length - 1; num++)
				{
					Point3D point3D6 = buVector5.ToPoint3D(SurfacePoints[i].entSafeOut.Vertices[num]);
					list.Add(new PointRGB(point3D6.X, point3D6.Y, point3D6.Z, darkOrange.R, darkOrange.G, darkOrange.B));
				}
			}
			if (list.Count > 0)
			{
				ccVars.pntDrawDynamicLinesArrColored.Add(list);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void CreateCode(string FileName)
	{
		if (ccVars.Pages[ccVars.PageIndex].Cams.Count > 0)
		{
			buFile5.SaveToFile(ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes, FileName);
		}
	}

	public GeoLib Default4Or5AxisParameter(GeoLib MwPar, int AxisNumber, Vector3D vecRotation, double BAngLimit, double AAngleLimit, bool RadiusFit)
	{
		MwPar.MachParam.RadiusFitFlg = RadiusFit;
		MwPar.MachParam.SplineMaxDeviation = MwPar.MachParam.CutTolerance;
		MwPar.MachParam.MaxAngleChange = 3.0;
		MwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.AdaptiveFlg = false;
		MwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MinStepover = 0.2;
		MwPar.MachParam.ToolAxisControlParams.Cur4AxisDef.SetBasePointAndDirection(new Point3d<double>(0.0, 0.0, 0.0), new Point3d<double>(vecRotation.X, vecRotation.Y, vecRotation.Z));
		MwPar.MachParam.ToolAxisControlParams.TiltStrategy = MachiningParamsTiltStrategy.NoTilt;
		MwPar.MachParam.ToolAxisControlParams.LagAngle = 0.0;
		MwPar.MachParam.ToolAxisControlParams.SideTiltAngle = 0.0;
		MwPar.MachParam.ToolAxisControlParams.CurSideTiltDefType = MachiningParamsSideTiltDefTypes.FollowSurfIsoDir;
		MwPar.MachParam.ToolAxisControlParams.SmoothingFlg = true;
		MwPar.MachParam.ToolAxisControlParams.LimitsFlg = true;
		MwPar.MachParam.ToolAxisControlParams.ToolAxisSmoothingParams.MaxAngleFromInitialToolOrientation = 30.0;
		MwPar.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = false;
		if (BAngLimit > 0.0)
		{
			MwPar.MachParam.ToolAxisControlParams.BAngleLimitInXZPlaneFlg = true;
		}
		MwPar.MachParam.ToolAxisControlParams.BAngleLimitStartInXZPlane = BAngLimit;
		MwPar.MachParam.ToolAxisControlParams.BAngleLimitEndInXZPlane = 180.0 - BAngLimit;
		MwPar.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = false;
		if (AAngleLimit > 0.0)
		{
			MwPar.MachParam.ToolAxisControlParams.AAngleLimitInYZPlaneFlg = true;
		}
		MwPar.MachParam.ToolAxisControlParams.AAngleLimitStartInYZPlane = AAngleLimit;
		MwPar.MachParam.ToolAxisControlParams.AAngleLimitEndInYZPlane = 180.0 - AAngleLimit;
		MwPar.MachParam.ToolAxisControlParams.CAngleLimitInXYPlaneFlg = false;
		MwPar.MachParam.ToolAxisControlParams.CAngleLimitStartInXYPlane = 0.0;
		MwPar.MachParam.ToolAxisControlParams.CAngleLimitEndInXYPlane = 360.0;
		MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitFlg = true;
		MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitStart = 0.0;
		MwPar.MachParam.ToolAxisControlParams.WOrtAngleLimitEnd = 80.0;
		return MwPar;
	}

	public void doContourFromWireAndAngle(double Angle)
	{
		camTp camTp2 = new camTp();
		List<Entity> selectedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption();
		selectionOption.CircleToArc = true;
		selectionOption.CircleTo4Arc = true;
		selectionOption.SplitArcIfGreatThen180 = true;
		selectionOption.Point = false;
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
		List<buEntity> copiedEntities = new List<buEntity>();
		List<buEntity> SortedEntities = new List<buEntity>();
		buEntity.Copy(selectedEntities, ref copiedEntities);
		SortbuSettings sortbuSettings = new SortbuSettings();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		clsInit.cVector5.SortEntitiesByRefPoint(copiedEntities[0].StartPoint, ref copiedEntities, sortbuSettings, ref SortedEntities);
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		List<RoboticSurfacePoint> list = new List<RoboticSurfacePoint>();
		for (int i = 0; i <= SplitedEntitites.Count - 1; i++)
		{
			List<Point3D> Points = new List<Point3D>();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[i], ref Points);
			clsInit.cVector5.DevidePointsByLength(ref Points, 5.0);
			ClockDirectionType clockDirection = clsInit.cVector5.GetClockDirection(Points);
			if (clockDirection == ClockDirectionType.CW)
			{
				Points.Reverse();
			}
			for (int j = 0; j <= Points.Count - 1; j++)
			{
				RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
				roboticSurfacePoint.pntBase = new Point3D(Points[j].X, Points[j].Y, Points[j].Z);
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				if (j != 0)
				{
					num3 = clsInit.cVector5.PointAngle(Points[j], Points[j - 1]);
					Point3D EndPnt = new Point3D();
					clsInit.cVector5.LineWithLengthAndAngle(Points[j], 50.0, num3 - 90.0, ref EndPnt);
					Line line = new Line(Points[j], EndPnt);
					Vector3D axis = new Vector3D(Points[j - 1].X - Points[j].X, Points[j - 1].Y - Points[j].Y);
					line.Rotate(buConversion5.DegreeToRadian(45.0), axis, Points[j - 1]);
					line.Regen(0.1);
					num = 45.0;
					num2 = 0.0;
					roboticSurfacePoint.pntTangent = new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, num, num2, num3);
					list.Add(roboticSurfacePoint);
					if (j != Points.Count - 1)
					{
						continue;
					}
					List<Point3D> pntDevided = new List<Point3D>();
					clsInit.cVector5.EntityDevide(line, 5.0, ref pntDevided);
					for (int k = 0; k <= pntDevided.Count - 1; k++)
					{
						RoboticSurfacePoint roboticSurfacePoint2 = new RoboticSurfacePoint();
						roboticSurfacePoint2.pntTangent = new Pnt6D(pntDevided[k].X, pntDevided[k].Y, pntDevided[k].Z, num, num2, num3);
						if (k == 0)
						{
							roboticSurfacePoint2.entSafeOut = line;
						}
						list.Add(roboticSurfacePoint2);
					}
					continue;
				}
				num3 = clsInit.cVector5.PointAngle(Points[j + 1], Points[j]);
				Point3D EndPnt2 = new Point3D();
				clsInit.cVector5.LineWithLengthAndAngle(Points[j], 50.0, num3 - 90.0, ref EndPnt2);
				Line line2 = new Line(Points[j], EndPnt2);
				Vector3D axis2 = new Vector3D(Points[j].X - Points[j + 1].X, Points[j].Y - Points[j + 1].Y);
				line2.Rotate(buConversion5.DegreeToRadian(45.0), axis2, Points[j]);
				line2.Regen(0.1);
				num = 45.0;
				num2 = 0.0;
				List<Point3D> pntDevided2 = new List<Point3D>();
				clsInit.cVector5.EntityDevide(line2, 5.0, ref pntDevided2);
				pntDevided2.Reverse();
				for (int l = 0; l <= pntDevided2.Count - 1; l++)
				{
					RoboticSurfacePoint roboticSurfacePoint3 = new RoboticSurfacePoint();
					roboticSurfacePoint3.pntTangent = new Pnt6D(pntDevided2[l].X, pntDevided2[l].Y, pntDevided2[l].Z, num, num2, num3);
					if (l == 0)
					{
						roboticSurfacePoint3.entSafeIn = line2;
					}
					list.Add(roboticSurfacePoint3);
				}
				roboticSurfacePoint.pntTangent = new Pnt6D(Points[j].X, Points[j].Y, Points[j].Z, num, num2, num3);
				list.Add(roboticSurfacePoint);
			}
		}
		for (int m = 0; m <= list.Count - 1; m++)
		{
			Pnt6D pntTangent = list[m].pntTangent;
			if (pntTangent != null)
			{
				double a = list[m].pntTangent.A;
				double num4 = 0.0;
				double num5 = 0.0;
				double num6 = 0.0;
				num4 = ((a > 90.0) ? (a - 270.0) : (180.0 - (90.0 - a)));
				if (!(list[m].pntTangent.B > 90.0))
				{
					num5 = list[m].pntTangent.B - 90.0;
				}
				else
				{
					num5 = list[m].pntTangent.B - 90.0;
				}
				num5 = 0.0;
				string text = list[m].pntTangent.X.ToString("f2") + ";" + list[m].pntTangent.Y.ToString("f2") + ";" + list[m].pntTangent.Z.ToString("f2") + ";";
				text = text + num4.ToString("f2") + ";" + num5.ToString("f2") + ";" + num6.ToString("f2") + ";";
				text += "100;0;0;0;1;100;";
				camTp2.PreCodes.Add(text);
				Pnt6DSimMove item = new Pnt6DSimMove(list[m].pntTangent.X, list[m].pntTangent.Y, list[m].pntTangent.Z, pntTangent.A, pntTangent.B, pntTangent.C);
				camTp2.SimilationPoint.SimMove.Add(item);
			}
		}
		camTp2.PreCodes.Insert(0, camTp2.PreCodes.Count + 1 + ";");
		string text2 = list[list.Count - 1].pntTangent.X.ToString("f2") + ";" + list[list.Count - 1].pntTangent.Y.ToString("f2") + ";" + (list[list.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
		text2 += "0.00;0.00;0.00;100;0;0;0;1;100;";
		camTp2.PreCodes.Add(text2);
		camTp2.Tool = new ToolBase5(ccVars.toolActive);
		camTp2.TypeCam = CamType.Contour;
		for (int n = 0; n <= list.Count - 1; n++)
		{
			if (list[n].entTangent != null)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(list[n].entTangent, ref copiedEnt);
				camTp2.EntitiesOther.Add(copiedEnt);
			}
		}
		for (int num7 = 0; num7 <= list.Count - 1; num7++)
		{
			if (list[num7].entSafeIn != null)
			{
				Entity copiedEnt2 = null;
				buVector5.CopyEntities(list[num7].entSafeIn, ref copiedEnt2);
				camTp2.EntitiesOther.Add(copiedEnt2);
			}
			if (list[num7].entLeadIn != null)
			{
				Entity copiedEnt3 = null;
				buVector5.CopyEntities(list[num7].entLeadIn, ref copiedEnt3);
				camTp2.EntitiesOther.Add(copiedEnt3);
			}
			if (list[num7].entSafeOut != null)
			{
				Entity copiedEnt4 = null;
				buVector5.CopyEntities(list[num7].entSafeOut, ref copiedEnt4);
				camTp2.EntitiesOther.Add(copiedEnt4);
			}
			if (list[num7].entLeadOut != null)
			{
				Entity copiedEnt5 = null;
				buVector5.CopyEntities(list[num7].entLeadOut, ref copiedEnt5);
				camTp2.EntitiesOther.Add(copiedEnt5);
			}
		}
		camTp2.CamPoints.Clear();
		clsInit.appCommand.CamAdd(camTp2);
		clsInit.appCommand.Reset();
	}

	public void doWireframeContourRobotic(MWCalculationOptions MWCalcoptions, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		MWCalcoptions.StartPointX = 0.0;
		MWCalcoptions.StartPointY = 0.0;
		buMWRoboticVars.varCamWFContour.buPar.Sorting.Option.NextGroupRules = SortingNextGroupFindRulesType.DrawingSequence;
		buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamWFContour, ref buMWCalcs.varCamWFContourPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		buMWCalcs.CopyCamParameter(buMWCalcs.varCamWFContourPars, ref buMWRoboticVars.varCamWFContour);
		if (num >= 1)
		{
			List<Point3D> list = new List<Point3D>();
			if (Cam.CamPoints.Count > 0)
			{
				for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
				{
					for (int j = 0; j <= Cam.CamPoints[i].Points.Count - 1; j++)
					{
						if (MWCalcoptions.NumberofAxis != 5)
						{
							string text = "-180.00";
							string text2 = "0.00";
							string text3 = "0.00";
							string text4 = Cam.CamPoints[i].Points[j].P9.X.ToString("f2") + ";" + Cam.CamPoints[i].Points[j].P9.Y.ToString("f2") + ";" + Cam.CamPoints[i].Points[j].P9.Z.ToString("f2") + ";";
							text4 = text4 + text + ";" + text2 + ";" + text3 + ";";
							text4 += "50;0;0;0;1;0;";
							Cam.PreCodes.Add(text4);
						}
						else
						{
							list.Add(new Point3D(Cam.CamPoints[i].Points[j].P9.X, Cam.CamPoints[i].Points[j].P9.Y, 0.0));
						}
					}
				}
				Cam.PreCodes.Insert(0, Cam.PreCodes.Count + ";");
			}
			Cam.CamPoints.Clear();
			clsInit.appCommand.Reset();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doTriangleMeshRough(MWCalculationOptions MWCalcoptions, Point3D pntMinOrj, Point3D pntMaxOrj)
	{
		try
		{
			SelectionOption selectionOption = null;
			double rotateAngle = -90.0;
			if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
			{
				rotateAngle = 90.0;
			}
			if (MWCalcoptions.NumberofAxis == 3)
			{
				buMWRoboticVars.varCamMeshRough3Axis.buPar.Operations.isCircularCam = false;
				F_CamRough4XSettings f_CamRough4XSettings = new F_CamRough4XSettings();
				f_CamRough4XSettings.Settings = buMWRoboticVars.varCamMeshRough3Axis.buPar;
				f_CamRough4XSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_CamRough4XSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				f_CamRough4XSettings.Init();
				f_CamRough4XSettings.ShowDialog();
				if (f_CamRough4XSettings.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				buMWRoboticVars.varCamMeshRough3Axis.buPar = f_CamRough4XSettings.Settings;
				Point3D point3D = new Point3D(pntMinOrj.X, pntMinOrj.Y, pntMinOrj.Z);
				Point3D point3D2 = new Point3D(pntMaxOrj.X, pntMaxOrj.Y, pntMaxOrj.Z);
				point3D.X += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.X;
				point3D.Y += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.Y;
				point3D.Z += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMin.Z;
				point3D2.X += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.X;
				point3D2.Y += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.Y;
				point3D2.Z += buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMax.Z;
				Mesh mesh = Mesh.CreateBox(point3D2.X - point3D.X, point3D2.Y - point3D.Y, point3D2.Z - point3D.Z);
				mesh.Translate(point3D.X, point3D.Y, point3D.Z);
				mesh.Regen(0.1);
				clsMW.StockEntities.Add(mesh);
				buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.StartOffset;
				buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough3Axis.buPar.Steps.EndOffset;
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultipleDirectionsFlg = false;
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningDirectionsForMesh[0] = new Vectord(0.0, 0.0, 1.0);
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
				clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshRough3Axis.mwPar, buMWRoboticVars.varCamMeshRough3Axis.buPar, out clsMW.varbuCamMeshRoughPars);
				if (clsMW.varbuCamMeshRoughPars.Distances.Safe < pntMaxOrj.Z)
				{
					clsMW.varbuCamMeshRoughPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshRoughPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshRoughPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshRoughPars, buMWRoboticVars.varCamMeshRough3Axis.buPar);
				clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
				clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockOffsetMode = (CollCtrlOpStockParamsStockOffsetMode)Convert.ToInt32(buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffsetMode);
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockDefTolerance = buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockOffset;
				clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockTolarance;
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
				if ((buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.StBoundingBox) | (buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.St2dContainment))
				{
					clsMW.StockEntities.Clear();
				}
				if (clsMW.StockEntities.Count > 0)
				{
					clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromStock;
					clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
				}
			}
			if (MWCalcoptions.NumberofAxis == 4)
			{
				buMWRoboticVars.varCamMeshRough3Axis.buPar.Operations.isCircularCam = true;
				F_CamRough4XSettings f_CamRough4XSettings2 = new F_CamRough4XSettings();
				f_CamRough4XSettings2.Settings = buMWRoboticVars.varCamMeshRough4Axis.buPar;
				f_CamRough4XSettings2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_CamRough4XSettings2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				f_CamRough4XSettings2.Init();
				f_CamRough4XSettings2.ShowDialog();
				if (f_CamRough4XSettings2.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				buMWRoboticVars.varCamMeshRough4Axis.buPar = f_CamRough4XSettings2.Settings;
				selectionOption = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
				List<Entity> selectedEntities = new List<Entity>();
				clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
				clsMW.CamEntities.Clear();
				for (int i = 0; i <= selectedEntities.Count - 1; i++)
				{
					Entity copiedEntity = null;
					buEntity.Copy(selectedEntities[i], ref copiedEntity);
					clsMW.CamEntities.Add(copiedEntity);
				}
				clsInit.cVector5.Rotate(new Point3D(), rotateAngle, Vector3D.AxisX, ref clsMW.CamEntities);
				clsInit.cVector5.RegenEntities(0.1, ref clsMW.CamEntities);
				buMWRoboticVars.varCamMeshRough4Axis.buPar.Strategy.RotaryAxis = VectorType.YVector;
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(clsMW.CamEntities, ref MinPoint, ref MaxPoint);
				if (buMWRoboticVars.varCamMeshRough4Axis.buPar.Strategy.RotaryAxis == VectorType.YVector)
				{
					MinPoint.X += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.X;
					MinPoint.Y += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.Z;
					MinPoint.Z += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMin.Y;
					MaxPoint.X += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.X;
					MaxPoint.Y += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.Z;
					MaxPoint.Z += buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMax.Y;
				}
				Mesh mesh2 = Mesh.CreateBox(MaxPoint.X - MinPoint.X, MaxPoint.Y - MinPoint.Y, MaxPoint.Z - MinPoint.Z);
				mesh2.Translate(MinPoint.X, MinPoint.Y, MinPoint.Z);
				mesh2.Regen(0.1);
				clsMW.StockEntities.Add(mesh2);
				buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartValue = MaxPoint.Z + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartOffset;
				buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndOffset;
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MultipleDirectionsFlg = false;
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningDirectionsForMesh[0] = new Vectord(0.0, 0.0, 1.0);
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshRough4Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
				clsMW.varMWCamMeshRoughPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshRough4Axis.mwPar, buMWRoboticVars.varCamMeshRough4Axis.buPar, out clsMW.varbuCamMeshRoughPars);
				if (clsMW.varbuCamMeshRoughPars.Distances.Safe < MaxPoint.Z)
				{
					clsMW.varbuCamMeshRoughPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshRoughPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshRoughPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshRoughPars, buMWRoboticVars.varCamMeshRough4Axis.buPar);
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockOffsetMode = (CollCtrlOpStockParamsStockOffsetMode)Convert.ToInt32(buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffsetMode);
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockDefTolerance = buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockOffset;
				clsMW.varMWCamMeshRoughPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.StockTolerance = buMWRoboticVars.varCamMeshRough4Axis.buPar.Options.StockTolarance;
				clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StBoundingBox;
				if ((buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.StBoundingBox) | (buMWRoboticVars.varCamMeshRough3Axis.buPar.Options.StockType == CamStockType.St2dContainment))
				{
					clsMW.StockEntities.Clear();
				}
				if (clsMW.StockEntities.Count > 0)
				{
					clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams.StockType = CollCtrlOpStockParamsStockType.StSurfaces;
				}
			}
			((CollCtrlOpBaseParams)clsMW.varMWCamMeshRoughPars.MachParam.CollCtrlOpStockParams).Status = true;
		}
		catch (Exception)
		{
		}
	}

	public void doTriangleMeshParallelCut(MWCalculationOptions MWCalcoptions, Point3D pntMinOrj, Point3D pntMaxOrj)
	{
		try
		{
			SelectionOption selectionOption = null;
			double rotateAngle = -90.0;
			if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
			{
				rotateAngle = 90.0;
			}
			if (MWCalcoptions.NumberofAxis == 3)
			{
				buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.isCircularCam = false;
				F_CamParallelCutSettings f_CamParallelCutSettings = new F_CamParallelCutSettings();
				f_CamParallelCutSettings.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
				f_CamParallelCutSettings.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
				f_CamParallelCutSettings.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				f_CamParallelCutSettings.Init();
				f_CamParallelCutSettings.ShowDialog();
				if (f_CamParallelCutSettings.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				buMWRoboticVars.varCamMeshParallel3Axis.buPar = f_CamParallelCutSettings.Settings;
				if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
				{
					List<Point3D> Vertices = new List<Point3D>();
					Entity entRectangle = null;
					clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices, ref entRectangle);
					LinearPath item = new LinearPath(Vertices);
					clsMW.Containment2DEntities.Add(item);
				}
				buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.StartOffset;
				buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Steps.EndValue;
				((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
				buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel3Axis.mwPar, buMWRoboticVars.varCamMeshParallel3Axis.buPar, out clsMW.varbuCamMeshParallelPars);
				if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
				{
					clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars);
			}
			if (MWCalcoptions.NumberofAxis == 4)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				if (MWCalcoptions.CamRotateType != CamRotationType.Circular)
				{
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.isCircularCam = false;
					F_CamParallelCutSettings f_CamParallelCutSettings2 = new F_CamParallelCutSettings();
					f_CamParallelCutSettings2.Settings = buMWRoboticVars.varCamMeshParallel4Axis.buPar;
					f_CamParallelCutSettings2.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
					f_CamParallelCutSettings2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					f_CamParallelCutSettings2.Init();
					f_CamParallelCutSettings2.ShowDialog();
					if (f_CamParallelCutSettings2.PropertiesForm.Result != DialogResult.OK)
					{
						return;
					}
					buMWRoboticVars.varCamMeshParallel4Axis.buPar = f_CamParallelCutSettings2.Settings;
					if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
					{
						List<Point3D> Vertices2 = new List<Point3D>();
						Entity entRectangle2 = null;
						clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices2, ref entRectangle2);
						LinearPath item2 = new LinearPath(Vertices2);
						clsMW.Containment2DEntities.Add(item2);
					}
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartOffset;
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
					clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, buMWRoboticVars.varCamMeshParallel4Axis.buPar, out clsMW.varbuCamMeshParallelPars);
					if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
					{
						clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
					}
					clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars);
				}
				else
				{
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.isCircularCam = true;
					F_CamParallelCutSettings f_CamParallelCutSettings3 = new F_CamParallelCutSettings();
					f_CamParallelCutSettings3.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
					f_CamParallelCutSettings3.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
					f_CamParallelCutSettings3.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
					f_CamParallelCutSettings3.Init();
					f_CamParallelCutSettings3.ShowDialog();
					if (f_CamParallelCutSettings3.PropertiesForm.Result != DialogResult.OK)
					{
						return;
					}
					buMWRoboticVars.varCamMeshParallel4Axis.buPar = f_CamParallelCutSettings3.Settings;
					selectionOption = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
					List<Entity> selectedEntities = new List<Entity>();
					clsInit.appCommand.SelectionToEntities(ref selectedEntities, selectionOption);
					clsMW.CamEntities.Clear();
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.Containment2dParams.IsUsedFlg = false;
					for (int i = 0; i <= selectedEntities.Count - 1; i++)
					{
						Entity copiedEntity = null;
						buEntity.Copy(selectedEntities[i], ref copiedEntity);
						clsMW.CamEntities.Add(copiedEntity);
					}
					clsInit.cVector5.Rotate(new Point3D(), rotateAngle, Vector3D.AxisX, ref clsMW.CamEntities);
					clsInit.cVector5.RegenEntities(0.1, ref clsMW.CamEntities);
					clsInit.cVector5.BoxSizeCalculate(clsMW.CamEntities, ref MinPoint, ref MaxPoint);
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Distances.Safe = MaxPoint.Z - MinPoint.Z + 10.0;
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Distances.Air = MaxPoint.Z - MinPoint.Z + 10.0;
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.StartValue = MaxPoint.Z + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.StartOffset;
					buMWRoboticVars.varCamMeshParallel4Axis.buPar.Steps.EndValue = 0.0 + buMWRoboticVars.varCamMeshRough4Axis.buPar.Steps.EndOffset;
					clsMW.Containment2DEntities.Clear();
					Point3D point3D = new Point3D(MinPoint.X, MinPoint.Y);
					Point3D point3D2 = new Point3D(MaxPoint.X, MaxPoint.Y);
					List<Point3D> Vertices3 = new List<Point3D>();
					Entity entRectangle3 = null;
					clsInit.cVector5.Rectangle2Point(new Point3D(point3D.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.X, point3D.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(point3D2.X + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.X, point3D2.Y + buMWRoboticVars.varCamMeshParallel4Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices3, ref entRectangle3);
					LinearPath item3 = new LinearPath(Vertices3);
					clsMW.Containment2DEntities.Add(item3);
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.Containment2dParams.IsUsedFlg = true;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar = Default4Or5AxisParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, 4, Vector3D.AxisY, 45.0, 45.0, RadiusFit: false);
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
					clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel4Axis.mwPar, buMWRoboticVars.varCamMeshParallel4Axis.buPar, out clsMW.varbuCamMeshParallelPars);
					clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, buMWRoboticVars.varCamMeshParallel4Axis.buPar);
				}
			}
			if (MWCalcoptions.NumberofAxis != 5)
			{
				return;
			}
			buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.isCircularCam = false;
			F_CamParallelCutSettings f_CamParallelCutSettings4 = new F_CamParallelCutSettings();
			f_CamParallelCutSettings4.Settings = buMWRoboticVars.varCamMeshParallel3Axis.buPar;
			f_CamParallelCutSettings4.PropertiesForm.FormCloseMode = FormCloseModeType.Dispose;
			f_CamParallelCutSettings4.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
			f_CamParallelCutSettings4.Init();
			f_CamParallelCutSettings4.ShowDialog();
			if (f_CamParallelCutSettings4.PropertiesForm.Result == DialogResult.OK)
			{
				buMWRoboticVars.varCamMeshParallel5Axis.buPar = f_CamParallelCutSettings4.Settings;
				if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.Y, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.X, 0.0) | !buCompare5.EQ(buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.Y, 0.0))
				{
					List<Point3D> Vertices4 = new List<Point3D>();
					Entity entRectangle4 = null;
					clsInit.cVector5.Rectangle2Point(new Point3D(pntMinOrj.X + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.X, pntMinOrj.Y + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMinOffset.Y), new Point3D(pntMaxOrj.X + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.X, pntMaxOrj.Y + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Operations.BorderMaxOffset.Y), Plane.XY, ref Vertices4, ref entRectangle4);
					LinearPath item4 = new LinearPath(Vertices4);
					clsMW.Containment2DEntities.Add(item4);
				}
				buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.StartValue = pntMaxOrj.Z + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.StartOffset;
				buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.EndValue = pntMinOrj.Z + buMWRoboticVars.varCamMeshParallel5Axis.buPar.Steps.EndValue;
				buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
				buMWRoboticVars.varCamMeshParallel5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				clsMW.varMWCamMeshParalelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshParallel5Axis.mwPar, buMWRoboticVars.varCamMeshParallel5Axis.buPar, out clsMW.varbuCamMeshParallelPars);
				if (clsMW.varbuCamMeshParallelPars.Distances.Safe < pntMaxOrj.Z)
				{
					clsMW.varbuCamMeshParallelPars.Distances.Safe = Math.Round(pntMaxOrj.Z + clsMW.varbuCamMeshParallelPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshParalelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshParalelPars, buMWRoboticVars.varCamMeshParallel5Axis.buPar);
			}
		}
		catch (Exception)
		{
		}
	}

	public void doTriangleMesh(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		double num = -90.0;
		double plungeFeed = 10.0;
		if (RoboticTempVars.FaceType == CamFrontBackAll.Back)
		{
			num = 90.0;
		}
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		MWCalcoptions.AddToCamListInMWCalculation = false;
		MWCalcoptions.DontApplyReset = true;
		clsMW.varMWCamMeshRoughPars.MachParam.Containment2dParams.IsUsedFlg = false;
		clsMW.varMWCamMeshParalelPars.MachParam.Containment2dParams.IsUsedFlg = false;
		clsMW.varMWCamMeshContantZPars.MachParam.Containment2dParams.IsUsedFlg = false;
		clsMW.Containment2DEntities.Clear();
		clsMW.StockEntities.Clear();
		if (MWCalcoptions.NumberofAxis == 3)
		{
			buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
			buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
			buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaUndercutsParams.UndercutsFlg = false;
			((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshParallel3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
			((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
			((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshRough3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
		}
		SelectionOption option = new SelectionOption(Wire: true, Solid: false, Dimension: false, Text: false, Point: false, Picture: false);
		List<Entity> selectedEntities = new List<Entity>();
		List<Entity> selectedEntities2 = new List<Entity>();
		clsInit.appCommand.SelectionToEntities(ref selectedEntities2, option);
		option = new SelectionOption(Wire: false, Solid: true, Dimension: false, Text: false, Point: false, Picture: false);
		clsInit.appCommand.SelectionToEntities(ref selectedEntities, option);
		clsInit.cVector5.BoxSizeCalculate(selectedEntities, ref MinPoint, ref MaxPoint);
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
		{
			doTriangleMeshRough(MWCalcoptions, MinPoint, MaxPoint);
		}
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
		{
			doTriangleMeshParallelCut(MWCalcoptions, MinPoint, MaxPoint);
		}
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
		{
			if (MWCalcoptions.NumberofAxis == 3)
			{
				buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.StartValue = MaxPoint.Z;
				buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.EndValue = MinPoint.Z;
				((CollCtrlOpBaseParams)buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.CollControl.CollCtrlOperations[0]).Status = false;
				buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Distances.Air = 200.0;
				buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.StartValue = 140.0;
				buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Steps.EndValue = 0.0;
				clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ3Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
				if (clsMW.varbuCamMeshConstantZPars.Distances.Safe < MaxPoint.Z)
				{
					clsMW.varbuCamMeshConstantZPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshConstantZPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
			}
			if (MWCalcoptions.NumberofAxis == 4)
			{
				buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar = Default4Or5AxisParameter(buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar, 4, Vector3D.AxisZ, 45.0, 45.0, RadiusFit: false);
				buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Distances.Air = MaxPoint.Z - MinPoint.Z + buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Distances.Rapid;
				buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Steps.StartValue = MaxPoint.Z;
				buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Steps.EndValue = MinPoint.Z;
				clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ4Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
				if (clsMW.varbuCamMeshConstantZPars.Distances.Safe < MaxPoint.Z)
				{
					clsMW.varbuCamMeshConstantZPars.Distances.Safe = Math.Round(MaxPoint.Z + clsMW.varbuCamMeshConstantZPars.Distances.Rapid, 3);
				}
				clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
			}
			if (MWCalcoptions.NumberofAxis == 5)
			{
				buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar = Default4Or5AxisParameter(buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar, 4, Vector3D.AxisZ, 45.0, 45.0, RadiusFit: false);
				buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
				buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtUserDefined;
				buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
				buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Strategy.CutTolerance = 0.1;
				buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Distances.Air = 200.0;
				buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Steps.StartValue = 140.0;
				buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Steps.EndValue = 0.0;
				clsMW.varMWCamMeshContantZPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar, buMWRoboticVars.varCamMeshConstantZ5Axis.buPar, out clsMW.varbuCamMeshConstantZPars);
				clsMW.varMWCamMeshContantZPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamMeshContantZPars, buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
				clsMW.Containment2DEntities.Clear();
				Point3D firstPoint = new Point3D(-100.0, 5.0);
				Point3D secondPoint = new Point3D(100.0, 100.0);
				List<Point3D> Vertices = new List<Point3D>();
				Entity entRectangle = null;
				clsInit.cVector5.Rectangle2Point(firstPoint, secondPoint, Plane.XY, ref Vertices, ref entRectangle);
				LinearPath item = new LinearPath(Vertices);
				clsMW.Containment2DEntities.Add(item);
			}
		}
		if (clsMW.Containment2DEntities.Count > 0)
		{
			if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
			{
				clsMW.varMWCamMeshRoughPars.MachParam.Containment2dParams.IsUsedFlg = true;
			}
			if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
			{
				clsMW.varMWCamMeshParalelPars.MachParam.Containment2dParams.IsUsedFlg = true;
			}
			if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
			{
				clsMW.varMWCamMeshContantZPars.MachParam.Containment2dParams.IsUsedFlg = true;
			}
		}
		camResult Result = null;
		int num2 = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		Cam.EntitiesG1Orj.Clear();
		Cam.Tool = new ToolBase5(ccVars.toolActive);
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
		{
			if (MWCalcoptions.NumberofAxis == 3)
			{
				for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
				{
					for (int j = 0; j <= Cam.CamPoints[i].Points.Count - 1; j++)
					{
						TpPnt9D tpPnt9D = Cam.CamPoints[i].Points[j];
						tpPnt9D.P9.A = 0.0;
						tpPnt9D.P9.B = 0.0;
						tpPnt9D.P9.C = 1.0;
						tpPnt9D.P9.Z = tpPnt9D.P9.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
					}
				}
				if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
				{
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
				}
			}
			if (MWCalcoptions.NumberofAxis == 4)
			{
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesG1);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesG0);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesLeave);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesPlunge);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesOther);
				Cam.SimilationPoint.SimMove.Clear();
				for (int k = 0; k <= Cam.CamPoints.Count - 1; k++)
				{
					for (int l = 0; l <= Cam.CamPoints[k].Points.Count - 1; l++)
					{
						TpPnt9D Points = Cam.CamPoints[k].Points[l];
						clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Plane.YZ, ref Points);
						Points.P9.C = 0.0;
						if (!(num < 0.0))
						{
							Points.P9.B = 1.0;
						}
						else
						{
							Points.P9.B = -1.0;
						}
					}
					clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[k]);
				}
			}
		}
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
		{
			Cam.Tool.CamData.DepthOffset = buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
			if ((MWCalcoptions.NumberofAxis == 4) & (MWCalcoptions.CamRotateType == CamRotationType.Circular))
			{
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesG1);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesG0);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesLeave);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesPlunge);
				clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Vector3D.AxisX, ref Cam.EntitiesOther);
				Cam.SimilationPoint.SimMove.Clear();
				for (int m = 0; m <= Cam.CamPoints.Count - 1; m++)
				{
					for (int n = 0; n <= Cam.CamPoints[m].Points.Count - 1; n++)
					{
						TpPnt9D Points2 = Cam.CamPoints[m].Points[n];
						clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Plane.YZ, ref Points2);
						Point3D Points3 = new Point3D(Points2.P9.A, Points2.P9.B, Points2.P9.C);
						clsInit.cVector5.Rotate(new Point3D(), 0.0 - num, Plane.YZ, ref Points3);
						Points2.P9.A = Points3.X;
						Points2.P9.B = Points3.Y;
						Points2.P9.C = Points3.Z;
					}
					clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[m]);
				}
			}
			if ((MWCalcoptions.NumberofAxis == 4) & (MWCalcoptions.CamRotateType == CamRotationType.Flat))
			{
				Cam.SimilationPoint.SimMove.Clear();
				for (int num3 = 0; num3 <= Cam.CamPoints.Count - 1; num3++)
				{
					for (int num4 = 0; num4 <= Cam.CamPoints[num3].Points.Count - 1; num4++)
					{
						TpPnt9D tpPnt9D2 = Cam.CamPoints[num3].Points[num4];
						tpPnt9D2.P9.B = 0.0;
					}
					clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref Cam, Cam.CamPoints[num3]);
				}
			}
			if (MWCalcoptions.NumberofAxis == 3)
			{
				for (int num5 = 0; num5 <= Cam.CamPoints.Count - 1; num5++)
				{
					for (int num6 = 0; num6 <= Cam.CamPoints[num5].Points.Count - 1; num6++)
					{
						TpPnt9D tpPnt9D3 = Cam.CamPoints[num5].Points[num6];
						tpPnt9D3.P9.A = 0.0;
						tpPnt9D3.P9.B = 0.0;
						tpPnt9D3.P9.C = 1.0;
						tpPnt9D3.P9.Z = tpPnt9D3.P9.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
					}
				}
				if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
				{
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
					clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
				}
			}
		}
		if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ && MWCalcoptions.NumberofAxis == 3)
		{
			for (int num7 = 0; num7 <= Cam.CamPoints.Count - 1; num7++)
			{
				for (int num8 = 0; num8 <= Cam.CamPoints[num7].Points.Count - 1; num8++)
				{
					TpPnt9D tpPnt9D4 = Cam.CamPoints[num7].Points[num8];
					tpPnt9D4.P9.A = 0.0;
					tpPnt9D4.P9.B = 0.0;
					tpPnt9D4.P9.C = 1.0;
					tpPnt9D4.P9.Z = tpPnt9D4.P9.Z + buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset;
				}
			}
			if (!buCompare5.EQ(buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, 0.0))
			{
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG1);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesG0);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesPlunge);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeave);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesOther);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadIn);
				clsInit.cVector5.Move(0.0, 0.0, buMWRoboticVars.varCamMeshParallel3Axis.buPar.Operations.SurfaceOffset, ref Cam.EntitiesLeadOut);
			}
		}
		if (num2 >= 1)
		{
			if (MWCalcoptions.NumberofAxis == 3)
			{
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
				{
					buMWRoboticVars.varCamMeshRough3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRoboticVars.varCamMeshRough3Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshRough3Axis.buPar.Speeds.Plunge;
				}
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
				{
					buMWRoboticVars.varCamMeshParallel3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel3Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshParallel3Axis.buPar.Speeds.Plunge;
				}
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
				{
					buMWRoboticVars.varCamMeshConstantZ3Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ3Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshConstantZ3Axis.buPar.Speeds.Plunge;
				}
			}
			if (MWCalcoptions.NumberofAxis == 4)
			{
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.Rough)
				{
					buMWRoboticVars.varCamMeshRough4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshRoughPars, clsMW.varbuCamMeshRoughPars, out buMWRoboticVars.varCamMeshRough4Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshRough4Axis.buPar.Speeds.Plunge;
				}
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
				{
					buMWRoboticVars.varCamMeshParallel4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel4Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshParallel4Axis.buPar.Speeds.Plunge;
				}
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
				{
					buMWRoboticVars.varCamMeshConstantZ4Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ4Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshConstantZ4Axis.buPar.Speeds.Plunge;
				}
			}
			if (MWCalcoptions.NumberofAxis == 5)
			{
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ParallelCuts)
				{
					buMWRoboticVars.varCamMeshParallel5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshParalelPars, clsMW.varbuCamMeshParallelPars, out buMWRoboticVars.varCamMeshParallel5Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshParallel5Axis.buPar.Speeds.Plunge;
				}
				if (MWCalcoptions.CamTriMeshType == CamTriangularMeshType.ConstantZ)
				{
					buMWRoboticVars.varCamMeshConstantZ5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamMeshContantZPars, clsMW.varbuCamMeshConstantZPars, out buMWRoboticVars.varCamMeshConstantZ5Axis.buPar);
					plungeFeed = buMWRoboticVars.varCamMeshConstantZ5Axis.buPar.Speeds.Plunge;
				}
			}
			ToolPathToRobotPathCode(Cam, MWCalcoptions, plungeFeed);
			SaveRoboticFile();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doSurface(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		double plungeFeed = 10.0;
		MWCalcoptions.AddToCamListInMWCalculation = false;
		MWCalcoptions.DontApplyReset = true;
		if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
		{
			clsMW.varMWCamSurfaceParallelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis.mwPar, buMWRoboticVars.varCamSurface5Axis.buPar, out clsMW.varbuCamSurfaceParallelPars);
			clsMW.varMWCamSurfaceParallelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamSurfaceParallelPars, buMWRoboticVars.varCamSurface5Axis.buPar);
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
		}
		buMWCalcs.entityProjection = new List<List<Entity>>();
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
			{
				Entity copiedEntity = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					copiedEntity.Translate(0.0, 0.0, 30.0);
					list.Add(copiedEntity);
				}
			}
		}
		clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
		if (list.Count > 0)
		{
			buMWCalcs.entityProjection.Add(list);
			clsMW.varMWCamSurfaceParallelPars.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
			clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
		}
		camResult Result = null;
		int num = clsInit.appMW.doSurface(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		Cam.EntitiesG1Orj.Clear();
		if (num >= 1)
		{
			if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
			{
				buMWRoboticVars.varCamSurface5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamSurfaceParallelPars, clsMW.varbuCamSurfaceParallelPars, out buMWRoboticVars.varCamSurface5Axis.buPar);
				plungeFeed = buMWRoboticVars.varCamSurface5Axis.buPar.Speeds.Plunge;
			}
			ToolPathToRobotPathCode(Cam, MWCalcoptions, plungeFeed);
			clsFiles.SaveParameter();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doTrimContour(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		double plungeFeed = 10.0;
		MWCalcoptions.AddToCamListInMWCalculation = false;
		MWCalcoptions.DontApplyReset = true;
		if (MWCalcoptions.NumberofAxis == 5)
		{
			clsMW.varMWCamSurfaceParallelPars = buMWCalcs.CopyCamParameter(buMWRoboticVars.varCamSurface5Axis.mwPar, buMWRoboticVars.varCamSurface5Axis.buPar, out clsMW.varbuCamSurfaceParallelPars);
			clsMW.varMWCamSurfaceParallelPars = buMWCalcs.ConvertFromBuCamParToMwCamParTriangleMesh(clsMW.varMWCamSurfaceParallelPars, buMWRoboticVars.varCamSurface5Axis.buPar);
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.UseAirMoveSafetyDistanceFlg = false;
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.HeightsType = MachiningAreaHeightsParamsHeightsType.ShpHtAutomatic;
			clsMW.varMWCamSurfaceParallelPars.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.MachiningAreaHeightsParams.AutomaticHeightsType = MachiningAreaHeightsParamsAutomaticHeightsType.ShpAhtMinMaxFromMachSurf;
		}
		buMWCalcs.entityProjection = new List<List<Entity>>();
		List<Entity> list = new List<Entity>();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
			{
				Entity copiedEntity = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
				if (copiedEntity != null)
				{
					copiedEntity.Translate(0.0, 0.0, 30.0);
					list.Add(copiedEntity);
				}
			}
		}
		clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutParallel;
		if (list.Count > 0)
		{
			buMWCalcs.entityProjection.Add(list);
			clsMW.varMWCamSurfaceParallelPars.MachParam.ProjectCurvesParams.MaxProjectionDistance = 30.0;
			clsMW.varMWCamSurfaceParallelPars.MachParam.CurCutType = MachiningParamsCutType.CutProjectCurves;
		}
		camResult Result = null;
		int num = clsInit.appMW.doContouring(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		Cam.EntitiesG1Orj.Clear();
		if (num >= 1)
		{
			if (MWCalcoptions.NumberofAxis == 5 && MWCalcoptions.CamSurfType == CamSurfaceType.SurfaceParalel)
			{
				buMWRoboticVars.varCamSurface5Axis.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamSurfaceParallelPars, clsMW.varbuCamSurfaceParallelPars, out buMWRoboticVars.varCamSurface5Axis.buPar);
				plungeFeed = buMWRoboticVars.varCamSurface5Axis.buPar.Speeds.Plunge;
			}
			ToolPathToRobotPathCode(Cam, MWCalcoptions, plungeFeed);
			SaveRoboticFile();
		}
		else
		{
			clsInit.appCommand.Reset();
		}
	}

	public void doTriangleMesh5Axis(MWCalculationOptions MWCalcoptions)
	{
		camTp Cam = new camTp();
		MWCalcoptions.AddToCamListInMWCalculation = false;
		MWCalcoptions.DontApplyReset = true;
		MWCalcoptions.NumberofAxis = 5;
		camResult Result = null;
		int num = clsInit.appMW.doTriangularMesh3D(MWCalcoptions, ccVars.toolActive, ref Cam, ref Result);
		for (int i = 0; i <= Cam.CamPoints.Count - 1; i++)
		{
			for (int j = 0; j <= Cam.CamPoints[i].Points.Count - 1; j++)
			{
				Pnt9D p = Cam.CamPoints[i].Points[j].P9;
				Line item = new Line(new Point3D(p.X, p.Y, p.Z), new Point3D(p.X + p.A * 10.0, p.Y + p.B * 10.0, p.Z + p.C * 10.0));
				Cam.EntitiesG1.Add(item);
			}
		}
		for (int k = 0; k <= Cam.SimilationPoint.SimMove.Count - 1; k++)
		{
			_ = Cam.SimilationPoint.SimMove[k];
			clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[k].A, Cam.SimilationPoint.SimMove[k].B, Cam.SimilationPoint.SimMove[k].C), new Point3D(), Plane.XY);
			clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[k].A, Cam.SimilationPoint.SimMove[k].B, Cam.SimilationPoint.SimMove[k].C), new Point3D(), Plane.XZ);
			clsInit.cVector5.PointAngle(new Point3D(Cam.SimilationPoint.SimMove[k].A, Cam.SimilationPoint.SimMove[k].B, Cam.SimilationPoint.SimMove[k].C), new Point3D(), Plane.YZ);
		}
		if (num < 1)
		{
			clsInit.appCommand.Reset();
		}
	}

	public void CalculateBCAngles(double I, double J, double K, ref double B, ref double C)
	{
		if (!(buCompare5.EQ(I, 0.0) & buCompare5.EQ(J, 0.0) & buCompare5.EQ(K, 0.0)))
		{
			B = Math.Acos(K) * (180.0 / Math.PI);
			C = Math.Atan2(J, I) * (180.0 / Math.PI);
			if (C < 0.0)
			{
				C += 360.0;
			}
		}
		else
		{
			B = 0.0;
			C = 0.0;
		}
	}

	public void doContourBySelected(MWCalculationOptions MWCalcoptions)
	{
		camTp camTp2 = new camTp();
		List<RoboticSurfacePoint> list = new List<RoboticSurfacePoint>();
		RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[0]);
		roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[0]);
		roboticSurfacePoint.pntTangent = new Pnt6D(((ICurve)SurfacePoints[0].entSafeIn).StartPoint.X, ((ICurve)SurfacePoints[0].entSafeIn).StartPoint.Y, ((ICurve)SurfacePoints[0].entSafeIn).StartPoint.Z, roboticSurfacePoint.pntTangent.A, roboticSurfacePoint.pntTangent.B, roboticSurfacePoint.pntTangent.C);
		list.Add(roboticSurfacePoint);
		roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[0]);
		roboticSurfacePoint.pntTangent = new Pnt6D(((ICurve)SurfacePoints[0].entLeadIn).StartPoint.X, ((ICurve)SurfacePoints[0].entLeadIn).StartPoint.Y, ((ICurve)SurfacePoints[0].entLeadIn).StartPoint.Z, roboticSurfacePoint.pntTangent.A, roboticSurfacePoint.pntTangent.B, roboticSurfacePoint.pntTangent.C);
		list.Add(roboticSurfacePoint);
		for (int i = 0; i <= SurfacePoints.Count - 1; i++)
		{
			roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[i]);
			list.Add(roboticSurfacePoint);
		}
		roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[SurfacePoints.Count - 1]);
		roboticSurfacePoint.pntTangent = new Pnt6D(((ICurve)SurfacePoints[SurfacePoints.Count - 1].entLeadOut).EndPoint.X, ((ICurve)SurfacePoints[SurfacePoints.Count - 1].entLeadOut).EndPoint.Y, ((ICurve)SurfacePoints[SurfacePoints.Count - 1].entLeadOut).EndPoint.Z, roboticSurfacePoint.pntTangent.A, roboticSurfacePoint.pntTangent.B, roboticSurfacePoint.pntTangent.C);
		list.Add(roboticSurfacePoint);
		roboticSurfacePoint = new RoboticSurfacePoint(SurfacePoints[SurfacePoints.Count - 1]);
		roboticSurfacePoint.pntTangent = new Pnt6D(((ICurve)SurfacePoints[SurfacePoints.Count - 1].entSafeOut).EndPoint.X, ((ICurve)SurfacePoints[SurfacePoints.Count - 1].entSafeOut).EndPoint.Y, ((ICurve)SurfacePoints[SurfacePoints.Count - 1].entSafeOut).EndPoint.Z, roboticSurfacePoint.pntTangent.A, roboticSurfacePoint.pntTangent.B, roboticSurfacePoint.pntTangent.C);
		list.Add(roboticSurfacePoint);
		for (int j = 0; j <= list.Count - 1; j++)
		{
			Pnt6D pntTangent = list[j].pntTangent;
			if (pntTangent != null)
			{
				double a = list[j].pntTangent.A;
				double num = 0.0;
				double num2 = 0.0;
				double num3 = 0.0;
				num = ((a > 90.0) ? (a - 270.0) : (180.0 - (90.0 - a)));
				if (!(list[j].pntTangent.B > 90.0))
				{
					num2 = list[j].pntTangent.B - 90.0;
				}
				else
				{
					num2 = list[j].pntTangent.B - 90.0;
				}
				num2 = 0.0;
				string text = list[j].pntTangent.X.ToString("f2") + ";" + list[j].pntTangent.Y.ToString("f2") + ";" + list[j].pntTangent.Z.ToString("f2") + ";";
				text = text + num.ToString("f2") + ";" + num2.ToString("f2") + ";" + num3.ToString("f2") + ";";
				text += "100;0;0;0;1;100;";
				camTp2.PreCodes.Add(text);
				Pnt6DSimMove item = new Pnt6DSimMove(list[j].pntTangent.X, list[j].pntTangent.Y, list[j].pntTangent.Z, pntTangent.A - 90.0, 0.0, 0.0);
				camTp2.SimilationPoint.SimMove.Add(item);
			}
		}
		camTp2.PreCodes.Insert(0, camTp2.PreCodes.Count + 1 + ";");
		string text2 = list[list.Count - 1].pntTangent.X.ToString("f2") + ";" + list[list.Count - 1].pntTangent.Y.ToString("f2") + ";" + (list[list.Count - 1].pntTangent.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
		text2 += "0.00;0.00;0.00;100;0;0;0;1;100;";
		camTp2.PreCodes.Add(text2);
		camTp2.Tool = new ToolBase5(ccVars.toolActive);
		for (int k = 0; k <= list.Count - 1; k++)
		{
			if (list[k].entTangent != null)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(list[k].entTangent, ref copiedEnt);
				camTp2.EntitiesOther.Add(copiedEnt);
			}
		}
		for (int l = 0; l <= list.Count - 1; l++)
		{
			if (list[l].entSafeIn != null)
			{
				Entity copiedEnt2 = null;
				buVector5.CopyEntities(list[l].entSafeIn, ref copiedEnt2);
				camTp2.EntitiesOther.Add(copiedEnt2);
			}
			if (list[l].entLeadIn != null)
			{
				Entity copiedEnt3 = null;
				buVector5.CopyEntities(list[l].entLeadIn, ref copiedEnt3);
				camTp2.EntitiesOther.Add(copiedEnt3);
			}
			if (list[l].entSafeOut != null)
			{
				Entity copiedEnt4 = null;
				buVector5.CopyEntities(list[l].entSafeOut, ref copiedEnt4);
				camTp2.EntitiesOther.Add(copiedEnt4);
			}
			if (list[l].entLeadOut != null)
			{
				Entity copiedEnt5 = null;
				buVector5.CopyEntities(list[l].entLeadOut, ref copiedEnt5);
				camTp2.EntitiesOther.Add(copiedEnt5);
			}
		}
		camTp2.CamPoints.Clear();
		clsInit.appCommand.CamAdd(camTp2);
		clsInit.appCommand.Reset();
	}

	public void doSurfaceBySelected(MWCalculationOptions MWCalcoptions)
	{
		camTp camTp2 = new camTp();
		for (int i = 0; i <= SurfacePoints.Count - 1; i++)
		{
			double a = SurfacePoints[i].pntNormal.A;
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			num = ((a > 90.0) ? (a - 270.0) : (180.0 - (90.0 - a)));
			num2 = ((SurfacePoints[i].pntNormal.B > 90.0) ? (SurfacePoints[i].pntNormal.B - 90.0) : (SurfacePoints[i].pntNormal.B - 90.0));
			string text = SurfacePoints[i].pntNormal.X.ToString("f2") + ";" + SurfacePoints[i].pntNormal.Y.ToString("f2") + ";" + SurfacePoints[i].pntNormal.Z.ToString("f2") + ";";
			text = text + num.ToString("f2") + ";" + num2.ToString("f2") + ";" + num3.ToString("f2") + ";";
			text += "100;0;0;0;1;100;";
			camTp2.PreCodes.Add(text);
		}
		camTp2.PreCodes.Insert(0, camTp2.PreCodes.Count + 1 + ";");
		string text2 = SurfacePoints[SurfacePoints.Count - 1].pntNormal.X.ToString("f2") + ";" + SurfacePoints[SurfacePoints.Count - 1].pntNormal.Y.ToString("f2") + ";" + (SurfacePoints[SurfacePoints.Count - 1].pntNormal.Z + buRoboticCalc.varRoboticSettings.SafeDistance).ToString("f2") + ";";
		text2 += "0.00;0.00;0.00;100;0;0;0;1;100;";
		camTp2.PreCodes.Add(text2);
		camTp2.CamPoints.Clear();
		for (int j = 0; j <= SurfacePoints.Count - 1; j++)
		{
			if (SurfacePoints[j].entNormal != null)
			{
				Entity copiedEnt = null;
				buVector5.CopyEntities(SurfacePoints[j].entNormal, ref copiedEnt);
				camTp2.EntitiesOther.Add(copiedEnt);
			}
		}
		clsInit.appCommand.CamAdd(camTp2);
		clsInit.appCommand.Reset();
	}

	public bool doAddSurfacePoint(Point3D pntPre, Point3D refPoint, Point3D pntNext, bool isLast, MeshToSurfacePointsSettings Settings)
	{
		if (SurfacePoints == null)
		{
			SurfacePoints = new List<RoboticSurfacePoint>();
		}
		MeshToSurfacePointsCalculations Calc = new MeshToSurfacePointsCalculations();
		RoboticSurfacePoint roboticSurfacePoint = new RoboticSurfacePoint();
		bool hitPointsFromMeshSurfaceByPoint = clsInit.cVector5.GetHitPointsFromMeshSurfaceByPoint(SelectedMeshes, pntPre, refPoint, pntNext, Settings, ref Calc);
		roboticSurfacePoint.entNormal = Calc.normalEntities;
		roboticSurfacePoint.entTangent = Calc.tangentEntities;
		roboticSurfacePoint.pntNormal = Calc.normalPoint;
		roboticSurfacePoint.pntTangent = Calc.tangentPoint;
		roboticSurfacePoint.vecNormal = Calc.NormalVector;
		roboticSurfacePoint.entLeadIn = Calc.LeadInEntities;
		roboticSurfacePoint.entLeadOut = Calc.LeadOutEntities;
		roboticSurfacePoint.entSafeIn = Calc.SafeInEntities;
		roboticSurfacePoint.entSafeOut = Calc.SafeOutEntities;
		if (hitPointsFromMeshSurfaceByPoint)
		{
			if (pntPre != null)
			{
				roboticSurfacePoint.pntPre = buVector5.ToPoint3D(pntPre);
			}
			roboticSurfacePoint.pntBase = buVector5.ToPoint3D(refPoint);
			if (pntNext != null)
			{
				roboticSurfacePoint.pntNext = buVector5.ToPoint3D(pntNext);
			}
			SurfacePoints.Add(roboticSurfacePoint);
		}
		return hitPointsFromMeshSurfaceByPoint;
	}

	public void doReCalculateSurfacePoints(object Data)
	{
		SurfacePoints.Clear();
		List<RoboticSurfacePoint> list = (List<RoboticSurfacePoint>)Data;
		for (int i = 0; i <= list.Count - 1; i++)
		{
			RoboticSurfacePoint item = new RoboticSurfacePoint(list[i]);
			SurfacePoints.Add(item);
		}
		DrawSurfacePointsAsDynamicLine(-1);
	}

	public void doSelecredPointChanged(object Data)
	{
		DrawSurfacePointsAsDynamicLine(Convert.ToInt32(Data.ToString()));
	}

	public void doGetCurveture()
	{
		List<List<Point3D>> list = new List<List<Point3D>>();
		List<Entity> selectedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption(AllSelected: false);
		selectionOption.Mesh = true;
		selectionOption.Surface = true;
		selectionOption.Brep = true;
		clsInit.appCommand.SelectionToEntitiesBySequence(ref selectedEntities, selectionOption);
		clsInit.appCommand.undoBuffer();
		List<Entity> list2 = new List<Entity>();
		SelectedMeshes = new List<Entity>();
		SurfacePoints.Clear();
		SurfacePoints = new List<RoboticSurfacePoint>();
		if (selectedEntities.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= selectedEntities.Count - 1; i++)
		{
			list = new List<List<Point3D>>();
			clsInit.cVector5.SurfaceToControlPoints(selectedEntities[i], ref list);
			if (selectedEntities[i] is Surface)
			{
				SelectedMeshes.Add(((Surface)selectedEntities[i]).ConvertToMesh());
			}
			List<Point3D> list3 = new List<Point3D>();
			if (list.Count != 2)
			{
				for (int j = 0; j <= list.Count - 1; j++)
				{
					if (list[j].Count == 2)
					{
						list3.Add(clsInit.cVector5.MiddlePointOfLine(list[j][0], list[j][1]));
					}
				}
			}
			else
			{
				for (int k = 0; k <= list[0].Count - 1; k++)
				{
					list3.Add(clsInit.cVector5.MiddlePointOfLine(list[0][k], list[1][k]));
				}
			}
			ccVars.UndoDont = true;
			if (list3.Count > 1)
			{
				EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData = new CustomData();
				LinearPath Ent = null;
				clsInit.appCommand.CreatePolyLine(list3, entData, customData, ref Ent);
				list2.Add(Ent);
			}
		}
	}

	public void doGetCurveture11()
	{
		List<List<Point3D>> list = new List<List<Point3D>>();
		List<Entity> selectedEntities = new List<Entity>();
		SelectionOption selectionOption = new SelectionOption(AllSelected: false);
		selectionOption.Mesh = true;
		selectionOption.Surface = true;
		selectionOption.Brep = true;
		clsInit.appCommand.SelectionToEntitiesBySequence(ref selectedEntities, selectionOption);
		clsInit.appCommand.undoBuffer();
		List<Entity> BaseRefEntities = new List<Entity>();
		SelectedMeshes = new List<Entity>();
		SurfacePoints.Clear();
		SurfacePoints = new List<RoboticSurfacePoint>();
		if (selectedEntities.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= selectedEntities.Count - 1; i++)
		{
			list = new List<List<Point3D>>();
			clsInit.cVector5.SurfaceToControlPoints(selectedEntities[i], ref list);
			if (selectedEntities[i] is Surface)
			{
				SelectedMeshes.Add(((Surface)selectedEntities[i]).ConvertToMesh());
			}
			List<Point3D> list2 = new List<Point3D>();
			if (list.Count != 2)
			{
				for (int j = 0; j <= list.Count - 1; j++)
				{
					if (list[j].Count == 2)
					{
						list2.Add(clsInit.cVector5.MiddlePointOfLine(list[j][0], list[j][1]));
					}
				}
			}
			else
			{
				for (int k = 0; k <= list[0].Count - 1; k++)
				{
					list2.Add(clsInit.cVector5.MiddlePointOfLine(list[0][k], list[1][k]));
				}
			}
			ccVars.UndoDont = true;
			if (list2.Count > 1)
			{
				EntityDataSet entData = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData = new CustomData();
				LinearPath Ent = null;
				clsInit.appCommand.CreatePolyLine(list2, entData, customData, ref Ent);
				BaseRefEntities.Add(Ent);
			}
		}
		List<Entity> SortedEntities = new List<Entity>();
		for (int l = 0; l <= BaseRefEntities.Count - 1; l++)
		{
			bool flag = false;
			SortSettings settings = new SortSettings();
			SortResult Result = new SortResult();
			SortedEntities = new List<Entity>();
			Point3D point3D = buVector5.ToPoint3D(BaseRefEntities[l].Vertices[0]);
			point3D = new Point3D(602.0, 333.0, 218.0);
			clsInit.cVector5.SortEntitiesByRefPoint(point3D, ref BaseRefEntities, settings, ref SortedEntities, ref Result);
			for (int m = 0; m <= SortedEntities.Count - 1; m++)
			{
				if (SortedEntities[m].GetType() == typeof(buUpperLineEnt))
				{
					flag = true;
				}
			}
			if (flag)
			{
				SortedEntities = new List<Entity>();
				clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[l].Vertices[BaseRefEntities[0].Vertices.Length - 1], ref BaseRefEntities, settings, ref SortedEntities, ref Result);
				flag = false;
				for (int n = 0; n <= SortedEntities.Count - 1; n++)
				{
					if (SortedEntities[n].GetType() == typeof(buUpperLineEnt))
					{
						flag = true;
					}
				}
			}
			if (!flag)
			{
				l = BaseRefEntities.Count;
			}
		}
		List<Point3D> Points = new List<Point3D>();
		List<List<Point3D>> list3 = new List<List<Point3D>>();
		Vector3D value = new Vector3D();
		List<Point3D> list4 = new List<Point3D>();
		double num = 0.5;
		bool flag2 = false;
		for (int num2 = 0; num2 <= SortedEntities.Count - 1; num2++)
		{
			bool flag3 = false;
			List<Point3D> list5 = new List<Point3D>();
			list5.AddRange(SortedEntities[num2].Vertices);
			Vector3D vector3D = (Vector3D)((ICurve)SortedEntities[num2]).EndTangent.Clone();
			Vector3D value2 = (Vector3D)((ICurve)SortedEntities[num2]).StartTangent.Clone();
			if (((CustomData)SortedEntities[num2].EntityData).sortDirection == entitySortDirection.Reverse)
			{
				vector3D = (Vector3D)((ICurve)SortedEntities[num2]).StartTangent.Clone();
				value2 = (Vector3D)((ICurve)SortedEntities[num2]).EndTangent.Clone();
				list5.Reverse();
				flag3 = true;
			}
			if (num2 != 0)
			{
				if (!buCompare5.EQ(value2, value, 0.1))
				{
					Point3D point3D2 = new Point3D();
					if (flag2)
					{
						point3D2 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2 - 1]).PointAt(num));
						list4[list4.Count - 1] = buVector5.ToPoint3D(point3D2);
					}
					else
					{
						point3D2 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2 - 1]).PointAt(((ICurve)SortedEntities[num2 - 1]).Domain.t1 - num));
						list4[list4.Count - 1] = buVector5.ToPoint3D(point3D2);
					}
					list3.Add(list4);
					list4 = new List<Point3D>();
					list4.AddRange(list5);
					Point3D point3D3 = new Point3D();
					if (flag3)
					{
						point3D3 = ((ICurve)SortedEntities[num2]).PointAt(((ICurve)SortedEntities[num2]).Domain.t1 - num);
						list4[0] = buVector5.ToPoint3D(point3D3);
					}
					else
					{
						point3D3 = ((ICurve)SortedEntities[num2]).PointAt(num);
						list4[0] = buVector5.ToPoint3D(point3D3);
					}
					if ((list4.Count > 0) & (num2 == SortedEntities.Count - 1))
					{
						point3D2 = new Point3D();
						if (flag3)
						{
							point3D2 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2]).PointAt(num));
							list4[list4.Count - 1] = buVector5.ToPoint3D(point3D2);
						}
						else
						{
							point3D2 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2]).PointAt(((ICurve)SortedEntities[num2]).Domain.t1 - num));
							list4[list4.Count - 1] = buVector5.ToPoint3D(point3D2);
						}
						list3.Add(list4);
					}
				}
				else
				{
					list4.AddRange(list5);
					if ((list4.Count > 0) & (num2 == SortedEntities.Count - 1))
					{
						Point3D point3D4 = new Point3D();
						point3D4 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2]).PointAt(((ICurve)SortedEntities[num2]).Domain.t1 - num));
						list4[list4.Count - 1] = buVector5.ToPoint3D(point3D4);
						list3.Add(list4);
					}
				}
			}
			else
			{
				list4.AddRange(list5);
				Point3D point3D5 = new Point3D();
				if (flag3)
				{
					point3D5 = ((ICurve)SortedEntities[num2]).PointAt(((ICurve)SortedEntities[num2]).Domain.t1 - num);
					list4[0] = buVector5.ToPoint3D(point3D5);
				}
				else
				{
					point3D5 = ((ICurve)SortedEntities[num2]).PointAt(num);
					list4[0] = buVector5.ToPoint3D(point3D5);
				}
				if ((list4.Count > 0) & (num2 == SortedEntities.Count - 1))
				{
					Point3D point3D6 = new Point3D();
					point3D6 = buVector5.ToPoint3D(((ICurve)SortedEntities[num2]).PointAt(((ICurve)SortedEntities[num2]).Domain.t1 - num));
					list4[list4.Count - 1] = buVector5.ToPoint3D(point3D6);
					list3.Add(list4);
				}
			}
			Points.AddRange(list5);
			value = (Vector3D)vector3D.Clone();
			flag2 = flag3;
		}
		bool flag4 = clsInit.cVector5.IsClosed(Points);
		clsInit.cVector5.CheckDuplicatedPointsWithPrevious(0.05, ref Points);
		Points.Clear();
		Points = new List<Point3D>();
		for (int num3 = 0; num3 <= list3.Count - 1; num3++)
		{
			List<Point3D> list6 = new List<Point3D>();
			list6 = list3[num3];
			clsInit.cVector5.PointFilterByLength(buRoboticCalc.varRoboticSettings.FilterLength, ref list6);
			list3[num3] = list6;
			Points.AddRange(buVector5.ToPoint3D(list6));
		}
		Points.Add(buVector5.ToPoint3D(Points[0]));
		LinearPath Ent2 = null;
		EntityDataSet entData2 = new EntityDataSet(-1, ccVars.Pages[ccVars.PageIndex].LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
		CustomData customData2 = new CustomData();
		clsInit.appCommand.CreatePolyLine(Points, entData2, customData2, ref Ent2);
		if (Ent2 != null)
		{
			clsInit.appCommand.AddPolyline(Ent2);
		}
		MeshToSurfacePointsSettings meshToSurfacePointsSettings = new MeshToSurfacePointsSettings();
		meshToSurfacePointsSettings.ToolOffset = ccVars.toolActive.Geometry.Diameter / 2.0;
		meshToSurfacePointsSettings.ExtraDepth = buRoboticCalc.varRoboticSettings.ExtraDepth;
		double num4 = double.MinValue;
		int num5 = -1;
		for (int num6 = 0; num6 <= Points.Count - 1; num6++)
		{
			if (Points[num6].Z > num4)
			{
				num4 = Points[num6].Z;
				num5 = num6;
			}
		}
		if (!(num5 >= 1 && flag4))
		{
		}
		meshToSurfacePointsSettings.TangentAngleFromNormal = 90.0;
		Point3D point3D7 = new Point3D();
		int num7 = 0;
		AngleVector angleVector = new AngleVector();
		AngleVector angleVector2 = new AngleVector();
		for (int num8 = 0; num8 <= Points.Count - 1; num8++)
		{
			buVector5.ToPoint3D(Points[num8]);
			meshToSurfacePointsSettings.isFirst = false;
			meshToSurfacePointsSettings.isLast = false;
			meshToSurfacePointsSettings.isFirstEachSegment = false;
			meshToSurfacePointsSettings.isLastEachSegment = false;
			if (num7 > 0)
			{
				angleVector2.X = clsInit.cVector5.PointAngle(Points[num8], point3D7, Plane.YZ);
				angleVector2.Y = clsInit.cVector5.PointAngle(Points[num8], point3D7, Plane.XZ);
				angleVector2.Z = clsInit.cVector5.PointAngle(Points[num8], point3D7, Plane.XY);
				if (num7 > 1)
				{
					double num9 = Math.Abs(angleVector2.X - angleVector.X);
					double num10 = Math.Abs(angleVector2.Y - angleVector.Y);
					double num11 = Math.Abs(angleVector2.Z - angleVector.Z);
					if (!(((num9 > 30.0 && num9 < 170.0) || (num10 > 30.0 && num10 < 170.0) || (num11 > 30.0 && num11 < 170.0)) && num8 > 1))
					{
					}
				}
			}
			if (num8 == 0)
			{
				meshToSurfacePointsSettings.isFirst = true;
			}
			if (num8 == Points.Count - 1)
			{
				meshToSurfacePointsSettings.isLast = true;
			}
			if (!buCompare5.EQ(point3D7, Points[num8], 0.01))
			{
				bool flag5 = false;
				if (num8 >= Points.Count - 1)
				{
					meshToSurfacePointsSettings.isLastEachSegment = true;
					flag5 = doAddSurfacePoint(Points[num8 - 1], Points[num8], null, isLast: true, meshToSurfacePointsSettings);
				}
				else if (num8 != 0)
				{
					flag5 = doAddSurfacePoint(Points[num8 - 1], Points[num8], Points[num8 + 1], isLast: false, meshToSurfacePointsSettings);
				}
				else
				{
					meshToSurfacePointsSettings.isFirstEachSegment = true;
					flag5 = doAddSurfacePoint(null, Points[num8], Points[num8 + 1], isLast: false, meshToSurfacePointsSettings);
				}
				if (flag5)
				{
				}
				num7++;
				angleVector = new AngleVector(angleVector2);
				point3D7 = buVector5.ToPoint3D(Points[num8]);
			}
		}
		DrawSurfacePointsAsDynamicLine(-1);
	}

	public void Tick_Sim(object sender, EventArgs e)
	{
		if ((indexEnt >= 0) & (indexEnt <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEnt];
			Transformation transformation = null;
			Transformation transformation2 = null;
			if (entity is Line)
			{
				Line line = entity as Line;
				Vector3D axisZ = Vector3D.AxisZ;
				axisZ.Normalize();
				Point3D point3D = new Point3D(-200.0, -200.0, 50.0);
				Vector3D vector3D = new Vector3D(line.EndPoint.X - line.StartPoint.X, line.EndPoint.Y - line.StartPoint.Y, line.EndPoint.Z - line.StartPoint.Z);
				vector3D.Normalize();
				transformation = Class5.smethod_102(axisZ, this, vector3D);
				Line line2 = (Line)line.Clone();
				line2.TransformBy(transformation);
				Vector3D v = new Vector3D(point3D.X - line2.StartPoint.X, point3D.Y - line2.StartPoint.Y, point3D.Z - line2.StartPoint.Z);
				transformation2 = new Translation(v);
			}
			_ = transformation2 * transformation;
			_ = pntBase.X - entity.Vertices[0].X;
			_ = pntBase.Y - entity.Vertices[0].Y;
			_ = pntBase.Z - entity.Vertices[0].Z;
			double num = entity.Vertices[1].X - entity.Vertices[0].X;
			double num2 = entity.Vertices[1].Y - entity.Vertices[0].Y;
			double num3 = entity.Vertices[1].Z - entity.Vertices[0].Z;
			double[] double_ = new double[3] { -200.0, -200.0, 50.0 };
			double[] double_2 = new double[3] { 0.0, 0.0, 1.0 };
			double[] array = new double[3]
			{
				entity.Vertices[0].X,
				entity.Vertices[0].Y,
				entity.Vertices[0].Z
			};
			double[] array2 = new double[3] { num, num2, num3 };
			double[,] array3 = Class5.smethod_50(array2, double_2);
			double[] double_3 = Class5.smethod_127(array3, double_);
			double[] array4 = Class5.smethod_154(array, double_3);
			double[,] array5 = new double[4, 4];
			for (int i = 0; i < 3; i++)
			{
				for (int j = 0; j < 3; j++)
				{
					array5[i, j] = array3[i, j];
				}
			}
			for (int k = 0; k < 3; k++)
			{
				array5[k, 3] = array4[k];
			}
			array5[3, 3] = 1.0;
			Vector3D vector3D2 = new Vector3D(0.0, 0.0, 1.0);
			Vector3D vector3D3 = new Vector3D(num, num2, num3);
			Vector3D vector3D4 = Vector3D.Cross(vector3D2, vector3D3);
			double length = vector3D4.Length;
			if (!(length < 1E-12))
			{
			}
			vector3D4.Normalize();
			double angleInRadians = Math.Acos(Vector3D.Dot(vector3D2, vector3D3));
			new Rotation(angleInRadians, vector3D4, entity.Vertices[0]);
			for (int l = 0; l <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; l++)
			{
				Entity entity2 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[l];
				if (entity2.EntityData != null && entity2.EntityData is CustomData)
				{
					CustomData customData = entity2.EntityData as CustomData;
					if (customData.typeDefination == entityTypeDefination.Simulation)
					{
						entity2.TransformBy(transformation);
						entity2.Regen(0.1);
						entity2.TransformBy(transformation2);
						entity2.Regen(0.1);
						entity2.Regen(0.1);
					}
				}
			}
			indexEnt++;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.1);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		if (indexEnt < ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)
		{
		}
		indexSim++;
		if (indexSim >= 20)
		{
			timSim.Enabled = false;
		}
		timSim.Enabled = false;
	}

	public void doSimulation()
	{
		if (timSim == null)
		{
			timSim = new Timer();
			timSim.Tick += Tick_Sim;
			timSim.Interval = 100;
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (entity.EntityData != null && entity.EntityData is CustomData)
			{
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.Simulation) | (customData.typeDefination == entityTypeDefination.Base))
				{
					entity.Selected = true;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		CustomData customData2 = new CustomData();
		pntBase = new Point3D(-200.0, -200.0, 50.0);
		Mesh mesh = Mesh.CreateArrow(pntBase, Vector3D.AxisMinusZ, 2.0, 15.0, 5.0, 5.0, 20, Mesh.natureType.RichSmooth, Mesh.edgeStyleType.Sharp);
		mesh.Translate(0.0, 0.0, 20.0);
		mesh.Regen(0.1);
		mesh.Color = Color.Red;
		mesh.ColorMethod = colorMethodType.byEntity;
		customData2.typeDefination = entityTypeDefination.Base;
		mesh.EntityData = customData2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(mesh);
		if (list_0.Count > 0)
		{
			pntStart.X = list_0[10].Vertices[0].X;
			pntStart.Y = list_0[10].Vertices[0].Y;
			pntStart.Z = list_0[10].Vertices[0].Z;
			indexEnt = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count;
			for (int j = 10; j <= list_0.Count - 1; j++)
			{
				Entity copiedEntity = null;
				buEntity.Copy(list_0[j], ref copiedEntity);
				customData2 = new CustomData();
				customData2.typeDefination = entityTypeDefination.Simulation;
				copiedEntity.EntityData = customData2;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(copiedEntity);
			}
			if (SelectedEntity == null)
			{
			}
			indexSim = 0;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void DoIteration()
	{
		int num = 0;
		for (int i = indexEnt; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (!((indexEnt >= 0) & (indexEnt <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)))
			{
				continue;
			}
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (!(entity is ICurve))
			{
				continue;
			}
			Transformation transformation = null;
			Transformation transformation2 = null;
			if (entity is Line)
			{
				Line line = entity as Line;
				Vector3D axisZ = Vector3D.AxisZ;
				axisZ.Normalize();
				Point3D point3D = new Point3D(-200.0, -200.0, 50.0);
				Vector3D vector3D = new Vector3D(line.EndPoint.X - line.StartPoint.X, line.EndPoint.Y - line.StartPoint.Y, line.EndPoint.Z - line.StartPoint.Z);
				vector3D.Normalize();
				transformation = Class5.smethod_102(axisZ, this, vector3D);
				Line line2 = (Line)line.Clone();
				line2.TransformBy(transformation);
				Vector3D v = new Vector3D(point3D.X - line2.StartPoint.X, point3D.Y - line2.StartPoint.Y, point3D.Z - line2.StartPoint.Z);
				transformation2 = new Translation(v);
			}
			_ = transformation2 * transformation;
			_ = pntBase.X - entity.Vertices[0].X;
			_ = pntBase.Y - entity.Vertices[0].Y;
			_ = pntBase.Z - entity.Vertices[0].Z;
			double num2 = entity.Vertices[1].X - entity.Vertices[0].X;
			double num3 = entity.Vertices[1].Y - entity.Vertices[0].Y;
			double num4 = entity.Vertices[1].Z - entity.Vertices[0].Z;
			double[] double_ = new double[3] { -200.0, -200.0, 50.0 };
			double[] double_2 = new double[3] { 0.0, 0.0, 1.0 };
			double[] array = new double[3]
			{
				entity.Vertices[0].X,
				entity.Vertices[0].Y,
				entity.Vertices[0].Z
			};
			double[] array2 = new double[3] { num2, num3, num4 };
			double[,] array3 = Class5.smethod_50(array2, double_2);
			double[] double_3 = Class5.smethod_127(array3, double_);
			double[] array4 = Class5.smethod_154(array, double_3);
			double[,] array5 = new double[4, 4];
			for (int j = 0; j < 3; j++)
			{
				for (int k = 0; k < 3; k++)
				{
					array5[j, k] = array3[j, k];
				}
			}
			for (int l = 0; l < 3; l++)
			{
				array5[l, 3] = array4[l];
			}
			array5[3, 3] = 1.0;
			Vector3D vector3D2 = new Vector3D(0.0, 0.0, 1.0);
			Vector3D vector3D3 = new Vector3D(num2, num3, num4);
			Vector3D vector3D4 = Vector3D.Cross(vector3D2, vector3D3);
			double length = vector3D4.Length;
			if (!(length < 1E-12))
			{
			}
			vector3D4.Normalize();
			double angleInRadians = Math.Acos(Vector3D.Dot(vector3D2, vector3D3));
			new Rotation(angleInRadians, vector3D4, entity.Vertices[0]);
			Entity entity2 = (Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEnt].Clone();
			for (int m = 0; m <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; m++)
			{
				Entity entity3 = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m];
				if (entity3.EntityData != null && entity3.EntityData is CustomData)
				{
					CustomData customData = entity3.EntityData as CustomData;
					if (customData.typeDefination == entityTypeDefination.Simulation)
					{
						entity3.TransformBy(transformation);
						entity3.Regen(0.1);
						entity3.TransformBy(transformation2);
						entity3.Regen(0.1);
						entity3.Regen(0.1);
					}
				}
			}
			Entity entity4 = (Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEnt].Clone();
			if (entity2 is Line && entity4 is Line)
			{
				double num5 = entity4.Vertices[0].X - entity2.Vertices[0].X;
				double num6 = entity4.Vertices[0].Y - entity2.Vertices[0].Y;
				double num7 = entity4.Vertices[0].Z - entity2.Vertices[0].Z;
				double num8 = entity2.Vertices[1].X - entity2.Vertices[0].X;
				double num9 = entity2.Vertices[1].Y - entity2.Vertices[0].Y;
				double num10 = entity2.Vertices[1].Z - entity2.Vertices[0].Z;
				double num11 = entity4.Vertices[1].X - entity4.Vertices[0].X;
				double num12 = entity4.Vertices[1].Y - entity4.Vertices[0].Y;
				double num13 = entity4.Vertices[1].Z - entity4.Vertices[0].Z;
				double num14 = num11 - num8;
				double num15 = num12 - num9;
				double num16 = num13 - num10;
				CodeList[num] = CodeList[num] + " ; " + num5.ToString("f3") + " ; " + num6.ToString("f3") + " ; " + num7.ToString("f3") + " ; " + num14.ToString("f3") + " ; " + num15.ToString("f3") + " ; " + num16.ToString("f3");
			}
			indexEnt++;
			num++;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved(0.1);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doSim2()
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
			if (entity.EntityData != null && entity.EntityData is CustomData)
			{
				CustomData customData = entity.EntityData as CustomData;
				if ((customData.typeDefination == entityTypeDefination.Simulation) | (customData.typeDefination == entityTypeDefination.Base))
				{
					entity.Selected = true;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		Line line = new Line(-100.0, -100.0, 20.0, -102.0, -105.0, 27.0);
		CustomData customData2 = new CustomData();
		customData2.typeDefination = entityTypeDefination.Simulation;
		line.EntityData = customData2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line, Color.Blue);
		Vector3D axisZ = Vector3D.AxisZ;
		axisZ.Normalize();
		Point3D targetPoint = new Point3D(-200.0, -200.0, 50.0);
		Line line2 = TransformLineCompletely(new Line(line.StartPoint.Clone() as Point3D, line.EndPoint.Clone() as Point3D), axisZ, targetPoint);
		customData2 = new CustomData();
		customData2.typeDefination = entityTypeDefination.Simulation;
		line2.EntityData = customData2;
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(line2, Color.Red);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public Line TransformLineCompletely(Line originalLine, Vector3D targetDirection, Point3D targetPoint)
	{
		Vector3D vector3D = new Vector3D(originalLine.EndPoint.X - originalLine.StartPoint.X, originalLine.EndPoint.Y - originalLine.StartPoint.Y, originalLine.EndPoint.Z - originalLine.StartPoint.Z);
		vector3D.Normalize();
		Transformation xform = Class5.smethod_102(targetDirection, this, vector3D);
		originalLine.TransformBy(xform);
		return MoveLineToPoint(originalLine, targetPoint);
	}

	public Line MoveLineToPoint(Line line, Point3D targetPoint)
	{
		Vector3D v = new Vector3D(targetPoint.X - line.StartPoint.X, targetPoint.Y - line.StartPoint.Y, targetPoint.Z - line.StartPoint.Z);
		Transformation xform = new Translation(v);
		line.TransformBy(xform);
		return line;
	}
}
