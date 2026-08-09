using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ModuleWorks.ToolpathParameters;
using buCadCamResVer5.Editor;
using buCadCamResVer5.Library;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Notepad;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms.Cam;
using buEyeBaseVer5.Forms.Door;
using buEyeBaseVer5.Forms.File;
using buEyeBaseVer5.Forms.Shape;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Door;

public class clsDoor
{
	public List<string> cmdExceptionID = new List<string>();

	private string string_0 = "XZ";

	private bool bool_0 = false;

	private Timer timer_0 = new Timer();

	public Timer timNew = new Timer();

	private int int_0 = 1;

	private int int_1 = -1;

	private string string_1 = "";

	private ShapeCreateParameters shapeCreateParameters_0 = new ShapeCreateParameters();

	private F_DoorMat f_DoorMat_0 = null;

	public static DoorJob activeJob;

	public List<buEntity> refEntities = new List<buEntity>();

	public void Init()
	{
		buMWDoorVars.Init();
		OpenDoorFile();
		LoadLanguage();
		timNew.Tick += NewPageTick;
		if (clsInit.appLibrary != null)
		{
			clsInit.appLibrary.Init();
		}
	}

	public void InitSimulation()
	{
	}

	public void DoorTree_AfterSelect(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
			return;
		}
		TreeView treeView = (TreeView)sender;
		TreeNodeSettings treeNodeSettings = (TreeNodeSettings)treeView.SelectedNode;
		if (clsItem.FrmDoorJob.tree_jobs.Nodes != null)
		{
			for (int i = 0; i <= clsItem.FrmDoorJob.tree_jobs.Nodes.Count - 1; i++)
			{
				clsItem.FrmDoorJob.tree_jobs.Nodes[i].ForeColor = Color.Black;
				if (clsItem.FrmDoorJob.tree_jobs.Nodes[i].Nodes != null)
				{
					for (int j = 0; j <= clsItem.FrmDoorJob.tree_jobs.Nodes[i].Nodes.Count - 1; j++)
					{
						clsItem.FrmDoorJob.tree_jobs.Nodes[i].Nodes[j].ForeColor = Color.Black;
					}
				}
			}
		}
		string command = treeNodeSettings.Command;
		string text = command;
		if (text == "panelbase")
		{
			buDoor.varTemps.selectedDoorIndex = treeNodeSettings.ClassIndex;
		}
		else if (text == "item")
		{
			buDoor.varTemps.selectedDoorIndex = treeNodeSettings.ClassIndex;
			buDoor.varTemps.selectedItemIndex = treeNodeSettings.ClassSubIndex;
		}
	}

	public void DoorTree_AfterCheck(object sender, TreeViewEventArgs e)
	{
		if (ccVars.Pages.Count == 0)
		{
		}
	}

	public void DoorTreeUpdate()
	{
		clsItem.FrmDoorJob.tree_jobs.Nodes.Clear();
		TreeNodeSettings treeNodeSettings = new TreeNodeSettings("Job")
		{
			ImageIndex = 10,
			SelectedImageIndex = 10,
			Tag = "-1",
			ClassIndex = 0,
			ClassSubIndex = -1,
			ClassSubSubIndex = -1,
			Command = "panelbase",
			Name = "base",
			Info = "base",
			Index = 0,
			Checked = false
		};
		TreeNodeSettings treeNodeSettings2 = null;
		if (activeJob != null)
		{
			for (int i = 0; i <= activeJob.Items.Count - 1; i++)
			{
				treeNodeSettings2 = new TreeNodeSettings(buShape.ToDefination(activeJob.Items[i]))
				{
					ImageIndex = clsInit.cDoor.JobImageIndex(activeJob.Items[i]),
					SelectedImageIndex = clsInit.cDoor.JobImageIndex(activeJob.Items[i]),
					Tag = 0,
					ClassIndex = 0,
					ClassSubIndex = i,
					ClassSubSubIndex = -1,
					Command = "item",
					Name = "item",
					Info = "item",
					Index = 0,
					Checked = activeJob.Items[i].Enable
				};
				treeNodeSettings.Nodes.Add(treeNodeSettings2);
			}
		}
		if (treeNodeSettings2 != null)
		{
			treeNodeSettings2.Expand();
			treeNodeSettings.Expand();
		}
		clsItem.FrmDoorJob.tree_jobs.Nodes.Add(treeNodeSettings);
	}

	public void Checked_Checked(object sender, EventArgs e)
	{
		buDoor.varDoorRunSettings.SelectMode = clsItem.FrmDoorJob.chk_selectmode.Checked;
		clsItem.FrmDoorJob.tree_jobs.CheckBoxes = buDoor.varDoorRunSettings.SelectMode;
		if (!buDoor.varDoorRunSettings.SelectMode)
		{
			for (int i = 0; i <= clsItem.FrmDoorJob.tree_jobs.Nodes.Count - 1; i++)
			{
				clsItem.FrmDoorJob.tree_jobs.Nodes[i].Expand();
			}
		}
	}

	public void cmdNewMaterial(DoorJob panel)
	{
		if (f_DoorMat_0 == null)
		{
			f_DoorMat_0 = new F_DoorMat();
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OrigineSize = 5;
			f_DoorMat_0.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
			f_DoorMat_0.viewportLayout.CompileUserInterfaceElements();
		}
		f_DoorMat_0.pnl_model.Controls.Add(f_DoorMat_0.viewportLayout);
		f_DoorMat_0.viewportLayout.Entities.Clear();
		f_DoorMat_0.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		ccVars.activeMaterial.Size.Width = buDoor.varDoorRunSettings.MaterialWidth;
		ccVars.activeMaterial.Size.Height = buDoor.varDoorRunSettings.MaterialHeight;
		ccVars.activeMaterial.Size.Depth = buDoor.varDoorRunSettings.MaterialDepth;
		ccVars.activeMaterial.FrontAngle = buDoor.varDoorRunSettings.MaterialFrontAngle;
		ccVars.activeMaterial.BackAngle = buDoor.varDoorRunSettings.MaterialBackAngle;
		ccVars.activeMaterial.Purpose = buDoor.varDoorRunSettings.MaterailPurpuse;
		if (panel != null)
		{
			ccVars.activeMaterial.Size.Width = panel.Material.Size.Width;
			ccVars.activeMaterial.Size.Height = panel.Material.Size.Height;
			ccVars.activeMaterial.Size.Depth = panel.Material.Size.Depth;
			ccVars.activeMaterial.FrontAngle = panel.Material.FrontAngle;
			ccVars.activeMaterial.BackAngle = panel.Material.BackAngle;
			ccVars.activeMaterial.Purpose = panel.Material.Purpose;
		}
		f_DoorMat_0.Material = new MaterialBase5(ccVars.activeMaterial);
		f_DoorMat_0.Case1.Width = buDoor.varDoorRunSettings.Case1Width;
		f_DoorMat_0.Case1.Height = buDoor.varDoorRunSettings.Case1Height;
		f_DoorMat_0.Case1.Depth = buDoor.varDoorRunSettings.Case1Depth;
		f_DoorMat_0.Case2.Width = buDoor.varDoorRunSettings.Case2Width;
		f_DoorMat_0.Case2.Height = buDoor.varDoorRunSettings.Case2Height;
		f_DoorMat_0.Case2.Depth = buDoor.varDoorRunSettings.Case2Depth;
		if (panel == null)
		{
			f_DoorMat_0.Init(null);
		}
		else
		{
			f_DoorMat_0.Init(null);
		}
		f_DoorMat_0.StartPosition = FormStartPosition.CenterParent;
		f_DoorMat_0.ShowDialog();
		if (f_DoorMat_0.PropertiesForm.Result == DialogResult.OK)
		{
			buDoor.varDoorRunSettings.Case1Width = f_DoorMat_0.Case1.Width;
			buDoor.varDoorRunSettings.Case1Height = f_DoorMat_0.Case1.Height;
			buDoor.varDoorRunSettings.Case1Depth = f_DoorMat_0.Case1.Depth;
			buDoor.varDoorRunSettings.Case2Width = f_DoorMat_0.Case2.Width;
			buDoor.varDoorRunSettings.Case2Height = f_DoorMat_0.Case2.Height;
			buDoor.varDoorRunSettings.Case2Depth = f_DoorMat_0.Case2.Depth;
			ccVars.activeMaterial = new MaterialBase5(f_DoorMat_0.Material);
			buDoor.varDoorRunSettings.MaterialWidth = ccVars.activeMaterial.Size.Width;
			buDoor.varDoorRunSettings.MaterialHeight = ccVars.activeMaterial.Size.Height;
			buDoor.varDoorRunSettings.MaterialDepth = ccVars.activeMaterial.Size.Depth;
			buDoor.varDoorRunSettings.MaterialFrontAngle = ccVars.activeMaterial.FrontAngle;
			buDoor.varDoorRunSettings.MaterialBackAngle = ccVars.activeMaterial.BackAngle;
			buDoor.varDoorRunSettings.MaterailPurpuse = ccVars.activeMaterial.Purpose;
			if (panel != null)
			{
				EditPanel(ccVars.activeMaterial);
			}
			else
			{
				AddPanel(ccVars.activeMaterial);
			}
		}
		SaveDoorFile();
	}

	public void cmdShapes()
	{
		if (clsItem.FrmShapeList == null)
		{
			clsItem.FrmShapeList = new F_ShapeList();
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
			Properties.OriginSymbolVisible = true;
			Properties.OrigineSize = 5;
			clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
			clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
			}
			clsItem.FrmShapeList.DataOk += ShapeChanged;
			clsItem.FrmShapeList.DataCancel += ShapeCancel;
		}
		clsItem.FrmShapeList.parShape = new ShapeRuntimeData(buDoor.varDoorRunSettings.ShapeDataParameters);
		if (buDoor.varTemps.lastShape != null)
		{
			clsItem.FrmShapeList.selectedShape = buShape.Copy(buDoor.varTemps.lastShape);
		}
		else
		{
			clsItem.FrmShapeList.selectedShape = new buShapeRectangle(buDoor.varDoorRunSettings.ShapeDataParameters.RectangleWidth, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleHeight, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleRadius, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleChamfer, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleDepth, buDoor.varDoorRunSettings.ShapeDataParameters.RectangleAngle);
		}
		string_1 = "";
		if (AppBool.EditMode || buDoor.varDoorRunSettings.SecondToolEnable)
		{
		}
		clsItem.FrmShapeList.selectedShape.CamPar = new camParameters5(buMWDoorVars.varCamCommon.buPar);
		clsItem.FrmShapeList.parShape.CamPars = new camParameters5(buMWDoorVars.varCamCommon.buPar);
		if (clsItem.FrmShapeList.parShape.FreeDrawDepth <= 0.0)
		{
			clsItem.FrmShapeList.parShape.FreeDrawDepth = 5.0;
		}
		clsItem.FrmShapeList.PropertiesForm.TopMost = true;
		clsItem.FrmShapeList.PropertiesForm.FormPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.StartPosition = FormStartPosition.Manual;
		clsItem.FrmShapeList.Top = 50;
		clsItem.FrmShapeList.Left = 1500;
		clsItem.FrmShapeList.TopMost = true;
		if (clsItem.FrmShapeList.pnl_model.Controls.Count == 0)
		{
			clsItem.FrmShapeList.pnl_model.Controls.Add(clsItem.FrmShapeList.viewportLayout);
		}
		clsItem.FrmShapeList.viewportLayout.Entities.Clear();
		clsItem.FrmShapeList.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		if (clsItem.FrmMain != null)
		{
			clsItem.FrmShapeList.Owner = clsItem.FrmMain;
		}
		clsItem.FrmShapeList.ClosePageAfterOk = false;
		clsItem.FrmShapeList.Init();
		clsItem.FrmShapeList.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmShapeList.Show();
		clsItem.FrmShapeList.Top = 50;
		clsItem.FrmShapeList.Left = Screen.PrimaryScreen.Bounds.Width - clsItem.FrmShapeList.Width;
	}

	public void cmdSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.FormCaption = "Settings";
			f_ClassViewerDialog.Value = buDoor.varDoorSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				buDoor.varDoorSettings = new DoorSettings((DoorSettings)f_ClassViewerDialog.Value);
				SaveDoorFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdCamSettings()
	{
		try
		{
			F_CamSettings1 f_CamSettings = new F_CamSettings1();
			f_CamSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
			f_CamSettings.CamPar = new camParameters5(buMWDoorVars.varCamCommon.buPar);
			f_CamSettings.Init();
			f_CamSettings.ShowDialog();
			if (f_CamSettings.Properties.Result == DialogResult.OK)
			{
				buMWDoorVars.varCamCommon.buPar = new camParameters5(f_CamSettings.CamPar);
				SaveDoorFile();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdSaveGcode(bool ShowCode)
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					cmdCamContour();
					string Lines = "";
					PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
					postProcessor.StartLines.Insert(0, "L YUKLE");
					postProcessor.StartLines.Insert(0, "R2600=" + activeJob.Material.Size.Width.ToString("f1"));
					postProcessor.StartLines.Insert(0, "R2601=" + activeJob.Material.Size.Height.ToString("f1"));
					postProcessor.StartLines.Insert(0, "R2602=" + activeJob.Material.Size.Depth.ToString("f1"));
					postProcessor.StartLines.Insert(0, "R2603=" + activeJob.Material.BackAngle.ToString("f1"));
					postProcessor.StartLines.Insert(0, "R2604=" + activeJob.Material.FrontAngle.ToString("f1"));
					postProcessor.EndLines.Add("[BOSALT]");
					postProcessor.EndLines.Add("L BOSALT");
					postProcessor.EndLines.Add("M05");
					postProcessor.EndLines.Add("M02");
					clsInit.cGcodeCreate.CreatGCode(ccVars.Pages[ccVars.PageIndex].Cams, postProcessor, ref Lines);
					if (!ShowCode)
					{
						SaveFileDialog saveFileDialog = new SaveFileDialog();
						saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
						saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
						saveFileDialog.FilterIndex = 1;
						if (saveFileDialog.ShowDialog() == DialogResult.OK)
						{
							clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
							buFile5.SaveToFile(Lines, saveFileDialog.FileName);
							if (clsItem.FrmProgress != null)
							{
								clsItem.FrmProgress.Visible = false;
							}
							Lines = "";
							clsFiles.SaveParameter();
						}
					}
					else
					{
						F_Notepad f_Notepad = new F_Notepad();
						f_Notepad.Init(Lines);
						f_Notepad.Show();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
						Lines = "";
					}
				}
				else
				{
					buString5.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamContour()
	{
		try
		{
			List<camTp> list = new List<camTp>();
			List<camTp> list2 = new List<camTp>();
			List<camTp> list3 = new List<camTp>();
			for (int i = 0; i <= activeJob.Items.Count - 1; i++)
			{
				if (activeJob.Items[i].planeName == planeBoxNames.Front)
				{
					list.Add(new camTp(activeJob.Items[i].Cam));
				}
				if (activeJob.Items[i].planeName == planeBoxNames.Back)
				{
					list2.Add(new camTp(activeJob.Items[i].Cam));
				}
				if (activeJob.Items[i].planeName == planeBoxNames.Top)
				{
					list3.Add(new camTp(activeJob.Items[i].Cam));
				}
			}
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Pages[ccVars.PageIndex].Cams.Clear();
			if (list2.Count > 0)
			{
				for (int j = 0; j <= list2.Count - 1; j++)
				{
					list2[j].SimilationPoint.SimMove.Clear();
					List<Pnt6DSimMove> list4 = new List<Pnt6DSimMove>();
					for (int k = 0; k <= list2[j].CamPoints.Count - 1; k++)
					{
						List<Pnt6DSimMove> SimPoints = new List<Pnt6DSimMove>();
						clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints, list2[j].CamPoints[k]);
						if (SimPoints.Count > 0)
						{
							for (int l = 0; l <= SimPoints.Count - 1; l++)
							{
								Pnt6DSimMove pnt6DSimMove = new Pnt6DSimMove(SimPoints[l]);
								pnt6DSimMove.Y += activeJob.Material.Size.Height;
								list4.Add(new Pnt6DSimMove(pnt6DSimMove));
							}
						}
						if (list2[j].CamPoints[k].isSecondHead)
						{
							list2[j].CamPoints[k].PreCodes.Add("G0 G53 Z(V4063 / 2 - V4090)");
							list2[j].CamPoints[k].PreCodes.Add("M6 T42");
							list2[j].CamPoints[k].PreCodes.Add("M03 S" + list2[j].Tool.CamData.SpindleSpeed);
							list2[j].CamPoints[k].PreCodes.Add("G16 XYZ+");
							list2[j].CamPoints[k].PreCodes.Add("G0 G53 Z(V4063 / 2 - V4090)");
						}
					}
					if (j == 0)
					{
						list2[j].PreCodes.Add("[M1]");
						list2[j].PreCodes.Add("L GINIPRO.ISC");
						list2[j].PreCodes.Add("G305 OFF");
						list2[j].PreCodes.Add("G54.01");
						list2[j].PreCodes.Add("M06 T41");
						list2[j].PreCodes.Add("M03 S" + list2[j].Tool.CamData.SpindleSpeed);
						list2[j].PreCodes.Add("G16 XYZ+");
					}
					list2[j].CamPoints[0].PreCodes.Add("G0 G53 Z(V4063 / 2 - V4090)");
					if (j == list2.Count - 1)
					{
						list2[j].AfterCodes.Add("G0 G53 Z(V4063 / 2 - V4090)");
						list2[j].AfterCodes.Add("L GFINPRO.ISC");
						list2[j].AfterCodes.Add("JMP [BOSALT]");
						list2[j].AfterCodes.Add("M05");
						list2[j].AfterCodes.Add("M02");
						list2[j].AfterCodes.Add("RET");
					}
					List<camTpPoint> CamPoints = list2[j].CamPoints;
					clsInit.cCam5.ChangeCamPointCoordinates(ref CamPoints, CamPointChangeMethod.XZYToXYZ);
					list2[j].SimilationPoint.SimMove.AddRange(list4.ToArray());
					list2[j].Tool.Geometry.ToolDirection = new Vec3D(0.0, 1.0, 0.0);
					ccVars.Pages[ccVars.PageIndex].Cams.Add(list2[j]);
				}
			}
			if (list3.Count > 0)
			{
				for (int m = 0; m <= list3.Count - 1; m++)
				{
					list3[m].SimilationPoint.SimMove.Clear();
					List<Pnt6DSimMove> list5 = new List<Pnt6DSimMove>();
					for (int n = 0; n <= list3[m].CamPoints.Count - 1; n++)
					{
						List<Pnt6DSimMove> SimPoints2 = new List<Pnt6DSimMove>();
						clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints2, list3[m].CamPoints[n]);
						if (SimPoints2.Count > 0)
						{
							for (int num = 0; num <= SimPoints2.Count - 1; num++)
							{
								Pnt6DSimMove pnt = new Pnt6DSimMove(SimPoints2[num]);
								list5.Add(new Pnt6DSimMove(pnt));
							}
						}
					}
					if (m == 0)
					{
						list3[m].PreCodes.Add("[M2]");
						list3[m].PreCodes.Add("L GINIPRO.ISC");
						list3[m].PreCodes.Add("G305 OFF");
						list3[m].PreCodes.Add("G54.01");
						list3[m].PreCodes.Add("M06 T41");
						list3[m].PreCodes.Add("M03 S" + list3[m].Tool.CamData.SpindleSpeed);
						list3[m].PreCodes.Add("G16 XZY+");
					}
					if (m == list3.Count - 1)
					{
						list3[m].AfterCodes.Add("G0 G53 Y(V4063/1-V4090)");
					}
					List<camTpPoint> CamPoints2 = list3[m].CamPoints;
					clsInit.cCam5.ChangeCamPointCoordinates(ref CamPoints2, CamPointChangeMethod.XYZToXZY);
					list3[m].SimilationPoint.SimMove.AddRange(list5.ToArray());
					list3[m].Tool.Geometry.ToolDirection = new Vec3D(0.0, 0.0, -1.0);
					ccVars.Pages[ccVars.PageIndex].Cams.Add(list3[m]);
				}
			}
			if (list.Count > 0)
			{
				for (int num2 = 0; num2 <= list.Count - 1; num2++)
				{
					list[num2].SimilationPoint.SimMove.Clear();
					List<Pnt6DSimMove> list6 = new List<Pnt6DSimMove>();
					for (int num3 = 0; num3 <= list[num2].CamPoints.Count - 1; num3++)
					{
						List<Pnt6DSimMove> SimPoints3 = new List<Pnt6DSimMove>();
						clsInit.cCam5.CreateSimulationPointsFromCamPoint(ref SimPoints3, list[num2].CamPoints[num3]);
						if (SimPoints3.Count > 0)
						{
							for (int num4 = 0; num4 <= SimPoints3.Count - 1; num4++)
							{
								Pnt6DSimMove pnt6DSimMove2 = new Pnt6DSimMove(SimPoints3[num4]);
								pnt6DSimMove2.Y *= -1.0;
								list6.Add(new Pnt6DSimMove(pnt6DSimMove2));
							}
						}
					}
					if (num2 == 0)
					{
						if (list3.Count != 0)
						{
							list[num2].PreCodes.Add("M06 T42");
							list[num2].PreCodes.Add("M03 S" + list[num2].Tool.CamData.SpindleSpeed);
							list[num2].PreCodes.Add("G16 XYZ+");
						}
						else
						{
							list[num2].PreCodes.Add("[M2]");
							list[num2].PreCodes.Add("L GINIPRO.ISC");
							list[num2].PreCodes.Add("G305 OFF");
							list[num2].PreCodes.Add("G54.01");
							list[num2].PreCodes.Add("M06 T42");
							list[num2].PreCodes.Add("M03 S" + list[num2].Tool.CamData.SpindleSpeed);
							list[num2].PreCodes.Add("G16 XYZ+");
						}
					}
					if (num2 == list.Count - 1)
					{
						list[num2].AfterCodes.Add("G53 Z(V4063/2-V4090)");
					}
					List<camTpPoint> CamPoints3 = list[num2].CamPoints;
					clsInit.cCam5.ChangeCamPointCoordinates(ref CamPoints3, CamPointChangeMethod.XZYToXYZ);
					list[num2].SimilationPoint.SimMove.AddRange(list6.ToArray());
					list[num2].Tool.Geometry.ToolDirection = new Vec3D(0.0, -1.0, 0.0);
					ccVars.Pages[ccVars.PageIndex].Cams.Add(list[num2]);
				}
			}
			if (!((list.Count > 0) | (list3.Count > 0)))
			{
				camTp camTp2 = new camTp();
				camTp2.PreCodes.Add("[M2]");
				camTp2.AfterCodes.Add("RET");
				ccVars.Pages[ccVars.PageIndex].Cams.Add(camTp2);
				return;
			}
			if (list2.Count == 0)
			{
				ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(0, "[M1]");
				ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(1, "JMP [BOSALT]");
				ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(2, "M05");
				ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(3, "M02");
				ccVars.Pages[ccVars.PageIndex].Cams[0].PreCodes.Insert(4, "RET");
			}
			ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("L GFINPRO.ISC");
			ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("JMP [BOSALT]");
			ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("M05");
			ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("M02");
			ccVars.Pages[ccVars.PageIndex].Cams[ccVars.Pages[ccVars.PageIndex].Cams.Count - 1].AfterCodes.Add("RET");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdAddFromFile()
	{
		if (clsItem.FrmFromFile == null)
		{
			clsItem.FrmFromFile = new F_AddFromFile();
		}
		clsItem.FrmFromFile.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		clsItem.FrmFromFile.StartPosition = FormStartPosition.CenterParent;
		clsItem.FrmFromFile.Path = buDoor.varDoorRunSettings.pathFromFile;
		clsItem.FrmFromFile.KeepRatio = buDoor.varDoorRunSettings.FromFileKeepRatio;
		clsItem.FrmFromFile.Init();
		clsItem.FrmFromFile.ShowDialog();
		if (clsItem.FrmFromFile.PropertiesForm.Result != DialogResult.OK)
		{
			return;
		}
		shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
		List<buEntity> BaseRefEntities = new List<buEntity>();
		for (int i = 0; i <= clsItem.FrmFromFile.viewport.Entities.Count - 1; i++)
		{
			buEntity copiedEntity = null;
			buEntity.Copy(clsItem.FrmFromFile.viewport.Entities[i], ref copiedEntity);
			BaseRefEntities.Add(copiedEntity);
		}
		List<buEntity> SortedEntities = new List<buEntity>();
		SortbuResult Result = new SortbuResult();
		clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].StartPoint, ref BaseRefEntities, new SortbuSettings(), ref SortedEntities, ref Result);
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		Point3D MinPoint = new Point3D();
		Point3D MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(SplitedEntitites, ref MinPoint, ref MaxPoint);
		new List<List<buEntity>>();
		for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
		{
			Point3D MinPoint2 = new Point3D();
			Point3D MaxPoint2 = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(SplitedEntitites[j], ref MinPoint2, ref MaxPoint2);
			if (buCompare5.EQ(MinPoint2, MinPoint, 2.0) & buCompare5.EQ(MaxPoint2, MaxPoint, 2.0))
			{
				buCompositeCurve calcCompositeCurve = null;
				clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[j], ref calcCompositeCurve);
				shapeCreateParameters_0.entitiesCurve.Add(calcCompositeCurve);
				SplitedEntitites.RemoveAt(j);
				j = SplitedEntitites.Count;
			}
		}
		for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
		{
			buCompositeCurve calcCompositeCurve2 = null;
			clsInit.cVector5.CreateCompositeCurveFromEntitiesWithCamDirection(SplitedEntitites[k], ref calcCompositeCurve2);
			shapeCreateParameters_0.entitiesCurve.Add(calcCompositeCurve2);
		}
		buDoor.varDoorRunSettings.pathFromFile = clsItem.FrmFromFile.Path;
		MinPoint = new Point3D();
		MaxPoint = new Point3D();
		clsInit.cVector5.BoxSizeCalculate(shapeCreateParameters_0.entitiesCurve, ref MinPoint, ref MaxPoint);
		buDoor.varDoorRunSettings.FromFileKeepRatio = clsItem.FrmFromFile.KeepRatio;
		SaveDoorFile();
		buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = Math.Round(MaxPoint.X - MinPoint.X, 3);
		buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = Math.Round(MaxPoint.Y - MinPoint.Y, 3);
		buDoor.varTemps.lastShape = new buShapeFreeDraw(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawAngle);
		buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
		buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
		cmdShapes();
	}

	public void cmdAddFromLibrary()
	{
		DirectoryInfo directoryInfo = new DirectoryInfo(clsVar.varLibrary.pathLibrary);
		if (!directoryInfo.Exists)
		{
			clsVar.varLibrary.pathLibrary = AppPath.Base + "\\Library";
		}
		clsInit.appCommand.cmdLibDraw();
		if (clsItem.FrmLibraryDraw.PropertiesForm.Result == DialogResult.OK)
		{
			shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
			SketchAnalyseData AnalyseData = new SketchAnalyseData();
			clsInit.appEditor.AnalyseSketchEntity(clsLibrary.LibraryEntities, new SketchAnalyseSetData(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth), ref AnalyseData);
			if (AnalyseData.AnalyseEntities.Count > 0)
			{
				buEntity.Copy(AnalyseData.AnalyseEntities, ref shapeCreateParameters_0.entitiesCurve);
				buNumeric5.Copy(AnalyseData.DepthLevel, ref buDoor.varDoorRunSettings.ShapeDataParameters.DepthLevels);
				buNumeric5.Copy(AnalyseData.DepthLevel, ref shapeCreateParameters_0.DepthLevel);
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(shapeCreateParameters_0.entitiesCurve, ref MinPoint, ref MaxPoint);
				SaveDoorFile();
				buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = MaxPoint.X - MinPoint.X;
				buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = MaxPoint.Y - MinPoint.Y;
				buDoor.varTemps.lastShape = new buShapeFreeDraw(buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth, buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawAngle);
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
				cmdShapes();
			}
		}
	}

	public void cmdMenuCommand(object sender, EventArgs e)
	{
		string text = "";
		if (!(sender is Control))
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				text = toolStripMenuItem.Name;
			}
		}
		else
		{
			Control control = sender as Control;
			text = control.Name;
		}
		if (text == clsItem.FrmDoorJob.mnu_addpanel.Name)
		{
			cmdNewMaterial(null);
		}
		if (text == clsItem.FrmDoorJob.mnu_deletepanel.Name && activeJob != null && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[17]) == DialogResult.Yes)
		{
			doDeletePanel();
		}
		if (text == clsItem.FrmDoorJob.mnu_editpanel.Name && activeJob != null)
		{
			cmdNewMaterial(activeJob);
		}
		if (!(text == clsItem.FrmDoorJob.mnu_renamepanel.Name))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_add.Name) | (text == clsItem.FrmDoorJob.mnu_add.Name)))
		{
		}
		if (text == clsItem.FrmDoorJob.mnu_refresh.Name && activeJob != null)
		{
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			DrawPanelFromJob(activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
		}
		if (((text == clsItem.FrmDoorJob.btn_remove.Name) | (text == clsItem.FrmDoorJob.mnu_remove.Name)) && activeJob != null && ((buDoor.varTemps.selectedDoorIndex >= 0) & (buDoor.varTemps.selectedItemIndex >= 0)) && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[18]) == DialogResult.Yes)
		{
			doDeleteOperation(buDoor.varTemps.selectedItemIndex);
		}
		if (text == clsItem.FrmDoorJob.mnu_removeall.Name && activeJob != null && ((buDoor.varTemps.selectedDoorIndex >= 0) & (buDoor.varTemps.selectedItemIndex >= 0)) && buString5.MessageBoxQuestion(buDoor.LangDoorMessage[23]) == DialogResult.Yes)
		{
			doDeleteAllOperations();
		}
		if (!(text == clsItem.FrmDoorJob.mnu_removeselectedOP.Name))
		{
		}
		if (((text == clsItem.FrmDoorJob.btn_edit.Name) | (text == clsItem.FrmDoorJob.mnu_edit.Name)) && activeJob != null && ((buDoor.varTemps.selectedDoorIndex >= 0) & (buDoor.varTemps.selectedItemIndex >= 0)))
		{
			doEditOperation(buDoor.varTemps.selectedItemIndex);
		}
		if (!((text == clsItem.FrmDoorJob.btn_copy.Name) | (text == clsItem.FrmDoorJob.mnu_copy.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_move.Name) | (text == clsItem.FrmDoorJob.mnu_move.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_mirror.Name) | (text == clsItem.FrmDoorJob.mnu_mirror.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_array.Name) | (text == clsItem.FrmDoorJob.mnu_array.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_rotate.Name) | (text == clsItem.FrmDoorJob.mnu_rotate.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_up.Name) | (text == clsItem.FrmDoorJob.mnu_up.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_down.Name) | (text == clsItem.FrmDoorJob.mnu_down.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_tool.Name) | (text == clsItem.FrmDoorJob.mnu_tool.Name)))
		{
		}
		if (!((text == clsItem.FrmDoorJob.btn_disable.Name) | (text == clsItem.FrmDoorJob.mnu_disable.Name)))
		{
		}
	}

	public void cmdDrawEditor()
	{
		try
		{
			if (clsItem.frmEditor == null)
			{
				clsItem.frmEditor = new F_Editor();
			}
			clsVar.varEditorRuntimeSet.isSketchMode = true;
			clsItem.frmEditor = new F_Editor();
			clsItem.frmEditor.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.frmEditor.Init();
			clsItem.frmEditor.Show(clsItem.FrmMain);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSimStart()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					cmdCamContour();
					clsInit.appCommand.simStart();
				}
				else
				{
					buString5.MessageBoxWarning(AppLanguage.Messages[9]);
				}
			}
			else
			{
				MessageBox.Show("Not Available in Demo Mode");
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSimStop()
	{
		try
		{
			clsInit.appCommand.simStop();
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSaveCode()
	{
		if (!clsVar.appModes_0.DemoMode)
		{
			if (ccVars.Pages.Count > 0)
			{
				if (activeJob != null)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = buDoor.varDoorRunSettings.pathJob;
					saveFileDialog.Filter = "Door File (*.budoor)|*.budoor";
					saveFileDialog.FilterIndex = 1;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						buDoor.varDoorRunSettings.pathJob = buFile5.GetPath(saveFileDialog.FileName);
						SaveDoorJobFile(saveFileDialog.FileName, activeJob);
						SaveDoorFile();
					}
				}
				else
				{
					buString5.MessageBoxWarning(buDrillCalc.LangDrillMessage[31]);
				}
			}
			else
			{
				buString5.MessageBoxWarning(AppLanguage.CadCamMessages[9]);
			}
		}
		else
		{
			MessageBox.Show("Not Available in Demo Mode");
		}
	}

	public void cmdOpenCode()
	{
		if (clsItem.FrmShapeList == null)
		{
			clsItem.FrmShapeList = new F_ShapeList();
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OrigineSymbol = originSymbolStyleType.CoordinateSystem;
			Properties.OriginSymbolVisible = true;
			Properties.OrigineSize = 5;
			clsItem.FrmShapeList.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
			clsItem.FrmShapeList.viewportLayout.CompileUserInterfaceElements();
			for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
			{
				clsItem.FrmShapeList.viewportLayout.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
			}
			clsItem.FrmShapeList.DataOk += ShapeChanged;
			clsItem.FrmShapeList.DataCancel += ShapeCancel;
		}
		OpenFileDialog openFileDialog = new OpenFileDialog();
		openFileDialog.InitialDirectory = buDoor.varDoorRunSettings.pathJob;
		openFileDialog.Filter = "Door File (*.budoor)|*.budoor";
		openFileDialog.FilterIndex = 1;
		if (openFileDialog.ShowDialog() == DialogResult.OK)
		{
			buDoor.varDoorRunSettings.pathJob = buFile5.GetPath(openFileDialog.FileName);
			OpenDoorJobFile(openFileDialog.FileName, ref activeJob);
		}
	}

	public void Sim_Tick(object sender, EventArgs e)
	{
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buDoor.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buDoor.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Door Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Door Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buDoor.LangDoorCommands);
				StringList.Clear();
			}
			if (list.Count <= 0)
			{
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[16];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SaveDoorFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Door\\Door.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Door Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<buDoor.varDoorSettings>");
			arrayList.AddRange(buDoor.varDoorSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buDoor.varDoorSettings>");
			arrayList.Add("<buDoor.varDoorRunSettings>");
			arrayList.AddRange(buDoor.varDoorRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</buDoor.varDoorRunSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Door Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWDoorVars.varCamCommon.mwPar.Serialize(AppPath.Settings + "\\Door\\mwDoorCommon.bin");
			string fileName2 = AppPath.Settings + "\\Door\\DoorCam.bucamset";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(buMWDoorVars.varCamCommon.buPar.ToDefAll("_varCamCommon", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName2);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenDoorFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Door\\Door.prm";
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
					buString.ListToSpecificList("<buDoor.varDoorSettings>", "</buDoor.varDoorSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buDoor.varDoorSettings);
						buLog.addLog("Door Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<buDoor.varDoorRunSettings>", "</buDoor.varDoorRunSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, buDoor.varDoorRunSettings);
						buLog.addLog("Door varDoorRunSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Door Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Printer3D Settings Decoder Error");
				}
			}
			buLog.addLog("Door Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Door\\mwDoorCommon.bin");
			if (fileInfo.Exists)
			{
				buMWDoorVars.varCamCommon.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Door\\DoorCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Door Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Door Cam Settings File Missing");
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
					buSerilization5.Decode(arrayList, "_varCamCommon", SerilizationMode5.MultiLine, buMWDoorVars.varCamCommon.buPar);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Door Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Door Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void SaveDoorJobFile(string FileName, DoorJob Job)
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			new List<string>();
			arrayList.Add("<Job>");
			arrayList.Add("  <Material>");
			arrayList.Add("    Name;" + Job.Name);
			arrayList.Add("    Width;" + Job.Material.Size.Height);
			arrayList.Add("    Length;" + Job.Material.Size.Width);
			arrayList.Add("    Height;" + Job.Material.Size.Depth);
			arrayList.Add("  </Material>");
			arrayList.Add("  <Items>");
			for (int i = 0; i <= Job.Items.Count - 1; i++)
			{
				if (Job.Items[i].ShapeGroup == ShapeGroup.Shape)
				{
					arrayList.AddRange(Job.Items[i].ToDef(6));
				}
			}
			arrayList.Add("  </Items>");
			arrayList.Add("</Job>");
			buFile5.SaveToFile(arrayList, FileName);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void OpenDoorJobFile(string FileName, ref DoorJob Job)
	{
		try
		{
			List<string> StringList = new List<string>();
			new List<string>();
			List<string> CalcList = new List<string>();
			List<List<string>> CalcList2 = new List<List<string>>();
			buFile5.OpenFromFile(FileName, ref StringList);
			buString5.ListToSpecificList("<Material>", "</Material>", AddStartEndKey: false, StringList, ref CalcList);
			buString5.ListToSpecificList("<buShape>", "</buShape>", AddStartEndKey: false, StringList, ref CalcList2);
			for (int i = 0; i <= CalcList.Count - 1; i++)
			{
				string[] array = CalcList[i].Split(';');
				if (array != null && array.Length >= 2)
				{
					if (array[0].ToLower().IndexOf("name") >= 0)
					{
						Job.Name = array[1];
					}
					if (array[0].ToLower().IndexOf("width") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Height = double.Parse(array[1]);
					}
					if (array[0].ToLower().IndexOf("length") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Width = double.Parse(array[1]);
					}
					if (array[0].ToLower().IndexOf("height") >= 0 && buNumeric5.IsNumeric(array[1]))
					{
						Job.Material.Size.Depth = double.Parse(array[1]);
					}
				}
			}
			Job.Items.Clear();
			Job.Cams.Clear();
			Job.Material.Entities.Clear();
			if (Job.Material.Entities.Count >= 0)
			{
				Entity entDoor = null;
				clsInit.cDoor.CreateDoorEntityFromMaterial(Job.Material, ref entDoor);
				Job.Material.Entities.Add(entDoor);
				Job.panelEntity = entDoor;
			}
			bool secondToolEnable = buDoor.varDoorRunSettings.SecondToolEnable;
			int secondToolNo = buDoor.varDoorRunSettings.SecondToolNo;
			for (int j = 0; j <= CalcList2.Count - 1; j++)
			{
				buShape buShape2 = null;
				buShape2 = buShape.Decode(CalcList2[j]);
				if (buShape2.SecondToolName == null || buShape2.SecondToolName.Trim().Length <= 0)
				{
					buDoor.varDoorRunSettings.SecondToolEnable = false;
				}
				else
				{
					for (int k = 0; k <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; k++)
					{
						if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Limits.PlaneFront & (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Data.Name == buShape2.SecondToolName.Trim()))
						{
							buDoor.varDoorRunSettings.SecondToolNo = ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Data.No;
							buDoor.varDoorRunSettings.SecondToolEnable = true;
						}
					}
				}
				ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
				shapeUpdateArg.Parameters.pntBase.X = buShape2.BasePoint.X;
				shapeUpdateArg.Parameters.pntBase.Y = buShape2.BasePoint.Y;
				shapeUpdateArg.Parameters.pntBase.Z = buShape2.BasePoint.Z;
				buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = buShape2.BasePoint.X;
				buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = buShape2.BasePoint.Y;
				buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = buShape2.BasePoint.Z;
				if (shapeCreateParameters_0.entitiesCurve == null)
				{
					shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
				}
				shapeCreateParameters_0.entitiesCurve.Clear();
				if (buShape2.entitiesRef != null && buShape2.entitiesRef.Count > 0)
				{
					buEntity.Copy(buShape2.entitiesRef, ref shapeCreateParameters_0.entitiesCurve);
				}
				ShapeChanged(buShape2, shapeUpdateArg);
				ShapeCam(ref buShape2);
				activeJob.Items.Add(buShape2);
			}
			buDoor.varDoorRunSettings.SecondToolEnable = secondToolEnable;
			buDoor.varDoorRunSettings.SecondToolNo = secondToolNo;
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			DrawPanelFromJob(activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
			DoorTreeUpdate();
			SaveDoorFile();
			clsInit.appCommand.Reset();
			ccVars.Pages[ccVars.PageIndex].Form.Text = buFile5.getFileName(FileName);
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void NewPageExtension()
	{
		timNew.Interval = 100;
		timNew.Enabled = true;
		DoorTreeUpdate();
	}

	public void NewPageTick(object sender, EventArgs e)
	{
		timNew.Enabled = false;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			clsItem.ModelMainPreview.Layers.AddOrReplace(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i]);
		}
		ccVars.activeMaterial.Size.Width = buDoor.varDoorRunSettings.MaterialWidth;
		ccVars.activeMaterial.Size.Height = buDoor.varDoorRunSettings.MaterialHeight;
		ccVars.activeMaterial.Size.Depth = buDoor.varDoorRunSettings.MaterialDepth;
		ccVars.activeMaterial.FrontAngle = buDoor.varDoorRunSettings.MaterialFrontAngle;
		ccVars.activeMaterial.BackAngle = buDoor.varDoorRunSettings.MaterialBackAngle;
		ccVars.activeMaterial.Purpose = buDoor.varDoorRunSettings.MaterailPurpuse;
		AddPanel(ccVars.activeMaterial);
	}

	public void PageClosed()
	{
		DoorTreeUpdate();
	}

	public void AddPanel(MaterialBase5 Mat)
	{
		if (ccVars.Pages.Count > 0)
		{
			activeJob = new DoorJob();
			activeJob.Items = new List<buShape>();
			activeJob.Material = new MaterialBase5(Mat);
			activeJob.Material.Entities.Clear();
			Entity entDoor = null;
			if (ccVars.activeMaterial.Purpose != MaterialPurpose.Door)
			{
				Entity entCase = null;
				Entity entCase2 = null;
				clsInit.cDoor.CreateCaseEntityFromMaterial(new SizeObject(buDoor.varDoorRunSettings.Case1Width, buDoor.varDoorRunSettings.Case1Height, buDoor.varDoorRunSettings.Case1Depth), new SizeObject(buDoor.varDoorRunSettings.Case2Width, buDoor.varDoorRunSettings.Case2Height, buDoor.varDoorRunSettings.Case2Depth), ccVars.activeMaterial.Display.SkinColor, buDoor.varDoorRunSettings.CaseSpace, ref entCase, ref entCase2);
				activeJob.panelEntity = entCase;
				activeJob.panelEntity2 = entCase;
				activeJob.Material.Entities.Add(entCase);
				activeJob.Material.Entities.Add(entCase2);
				activeJob.Material.Size = new SizeObject(buDoor.varDoorRunSettings.Case1Width, buDoor.varDoorRunSettings.Case1Height + buDoor.varDoorRunSettings.Case2Height + buDoor.varDoorRunSettings.CaseSpace, buDoor.varDoorRunSettings.Case1Depth);
			}
			else
			{
				clsInit.cDoor.CreateDoorEntityFromMaterial(ccVars.activeMaterial, ref entDoor);
				activeJob.panelEntity = entDoor;
				activeJob.Material.Entities.Add(entDoor);
			}
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			DrawPanelFromJob(activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
			clsInit.appCommand.PagesUpdate(FillPages: true, "");
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActiveViewport.SetView(viewType.Trimetric);
			clsInit.appCommand.cmdViewZoomFit();
			clsInit.appCommand.cmdViewZoomOut();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			DoorTreeUpdate();
		}
	}

	public void EditPanel(MaterialBase5 Mat)
	{
		List<buShape> list = new List<buShape>();
		for (int i = 0; i <= activeJob.Items.Count - 1; i++)
		{
			list.Add(buShape.Copy(activeJob.Items[i]));
		}
		activeJob.Items.Clear();
		activeJob.Cams.Clear();
		activeJob.Material.Entities.Clear();
		activeJob.Material = new MaterialBase5(Mat);
		if (activeJob.Material.Entities.Count >= 0)
		{
			Entity entDoor = null;
			clsInit.cDoor.CreateDoorEntityFromMaterial(Mat, ref entDoor);
			activeJob.Material.Entities.Add(entDoor);
			activeJob.panelEntity = entDoor;
		}
		bool secondToolEnable = buDoor.varDoorRunSettings.SecondToolEnable;
		int secondToolNo = buDoor.varDoorRunSettings.SecondToolNo;
		for (int j = 0; j <= list.Count - 1; j++)
		{
			buShape buShape2 = buShape.Copy(list[j]);
			buShape2.entitiesShape.Clear();
			buShape2.Cam = new camTp();
			buShape2.entitiesCam.Clear();
			if (buShape2.SecondToolName == null || buShape2.SecondToolName.Trim().Length <= 0)
			{
				buDoor.varDoorRunSettings.SecondToolEnable = false;
			}
			else
			{
				for (int k = 0; k <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; k++)
				{
					if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Limits.PlaneFront & (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Data.Name == buShape2.SecondToolName.Trim()))
					{
						buDoor.varDoorRunSettings.SecondToolNo = ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Data.No;
						buDoor.varDoorRunSettings.SecondToolEnable = true;
					}
				}
			}
			ShapeUpdateArg shapeUpdateArg = new ShapeUpdateArg();
			shapeUpdateArg.Parameters.pntBase.X = buShape2.BasePoint.X;
			shapeUpdateArg.Parameters.pntBase.Y = buShape2.BasePoint.Y;
			shapeUpdateArg.Parameters.pntBase.Z = buShape2.BasePoint.Z;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = buShape2.BasePoint.X;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = buShape2.BasePoint.Y;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = buShape2.BasePoint.Z;
			if (shapeCreateParameters_0.entitiesCurve == null)
			{
				shapeCreateParameters_0.entitiesCurve = new List<buEntity>();
			}
			shapeCreateParameters_0.entitiesCurve.Clear();
			shapeCreateParameters_0.DepthLevel.Clear();
			shapeUpdateArg.Parameters.DepthLevels.Clear();
			shapeUpdateArg.Parameters.DepthLevels.AddRange(buShape2.DepthLevel);
			if (buShape2.entitiesRef != null && buShape2.entitiesRef.Count > 0)
			{
				buEntity.Copy(buShape2.entitiesRef, ref shapeCreateParameters_0.entitiesCurve);
			}
			shapeUpdateArg.Finished = true;
			ShapeChanged(buShape2, shapeUpdateArg);
		}
		buDoor.varDoorRunSettings.SecondToolEnable = secondToolEnable;
		buDoor.varDoorRunSettings.SecondToolNo = secondToolNo;
		DrawPanelFromJob(activeJob, new ViewportDrawOptions());
		DrawPanelFromJob(activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
		DoorTreeUpdate();
		SaveDoorFile();
		clsInit.appCommand.Reset();
	}

	public void DrawPanelFromJob(DoorJob Job, ViewportDrawOptions Options)
	{
		try
		{
			Design design = null;
			if (Options.ViewportRef != ViewportRefType.Main)
			{
				if (Options.ViewportRef != ViewportRefType.Operation)
				{
					if (Options.ViewportRef == ViewportRefType.Preview)
					{
						design = clsItem.ModelMainPreview;
					}
				}
				else
				{
					design = clsItem.FrmShapeList.viewportLayout;
				}
			}
			else
			{
				design = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
			}
			design.Entities.Clear();
			if (Job != null)
			{
				Entity copiedEntity = null;
				if (Job.Material.Entities.Count > 0)
				{
					buEntity.Copy(Job.Material.Entities[0], ref copiedEntity);
					copiedEntity.LayerName = buDoor.varTemps.layerPanel;
					copiedEntity.ColorMethod = colorMethodType.byEntity;
					copiedEntity.Color = Color.FromArgb(150, buDoor.varDoorSettings.colorPanel);
					copiedEntity.Selectable = false;
					design.Entities.Add(copiedEntity);
					if (Job.Material.Entities.Count >= 2)
					{
						copiedEntity = null;
						buEntity.Copy(Job.Material.Entities[1], ref copiedEntity);
						copiedEntity.LayerName = buDoor.varTemps.layerPanel;
						copiedEntity.ColorMethod = colorMethodType.byEntity;
						copiedEntity.Color = Color.FromArgb(150, buDoor.varDoorSettings.colorPanel);
						copiedEntity.Selectable = false;
						design.Entities.Add(copiedEntity);
					}
					if (Options.DrawItems)
					{
						for (int i = 0; i <= Job.Items.Count - 1; i++)
						{
							buShape buShape2 = Job.Items[i];
							shapeCreateParameters_0.Solid = true;
							for (int j = 0; j <= buShape2.entitySolid.Count - 1; j++)
							{
								Entity copiedEntity2 = null;
								buEntity.Copy(buShape2.entitySolid[j], ref copiedEntity2);
								copiedEntity2.LayerName = buDoor.varTemps.layerOperation;
								copiedEntity2.ColorMethod = colorMethodType.byEntity;
								copiedEntity2.Color = Color.FromArgb(160, buDoor.varDoorSettings.colorOperation);
								copiedEntity2.Selectable = false;
								if ((Job.Material.FrontAngle != 0.0) & (Job.Items[i].planeName == planeBoxNames.Front))
								{
									Point3D point3D = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
									copiedEntity2.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D);
									Point3D Points = buVector5.ToPoint3D(buShape2.CalculatedPoint);
									clsInit.cVector5.Rotate(point3D, Job.Material.FrontAngle, Plane.YZ, ref Points);
									double num = buShape2.BasePoint.Z - Points.Z;
									double num2 = num * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
									copiedEntity2.Translate(0.0, 0.0 - num2, num);
								}
								if ((Job.Material.BackAngle != 0.0) & (Job.Items[i].planeName == planeBoxNames.Back))
								{
									Point3D point3D2 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
									copiedEntity2.Rotate(buConversion5.DegreeToRadian(0.0 - Job.Material.BackAngle), Vector3D.AxisX, point3D2);
									Point3D Points2 = buVector5.ToPoint3D(buShape2.CalculatedPoint);
									clsInit.cVector5.Rotate(point3D2, Job.Material.BackAngle, Plane.YZ, ref Points2);
									double num3 = buShape2.BasePoint.Z - Points2.Z;
									double dy = num3 * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
									copiedEntity2.Translate(0.0, dy, num3);
								}
								design.Entities.Add(copiedEntity2);
							}
							for (int k = 0; k <= buShape2.entitiesShape.Count - 1; k++)
							{
								Entity copiedEntity3 = null;
								buEntity.Copy(buShape2.entitiesShape[k], ref copiedEntity3);
								copiedEntity3.LayerName = buDoor.varTemps.layerOperation;
								copiedEntity3.ColorMethod = colorMethodType.byEntity;
								copiedEntity3.Color = Color.FromArgb(255, buDoor.varDoorSettings.colorOperation);
								copiedEntity3.Selectable = false;
								if ((Job.Material.FrontAngle != 0.0) & (Job.Items[i].planeName == planeBoxNames.Front))
								{
									Point3D point3D3 = new Point3D(0.0, 0.0, Job.Material.Size.Depth);
									copiedEntity3.Rotate(buConversion5.DegreeToRadian(Job.Material.FrontAngle), Vector3D.AxisX, point3D3);
									Point3D Points3 = buVector5.ToPoint3D(buShape2.CalculatedPoint);
									clsInit.cVector5.Rotate(point3D3, Job.Material.FrontAngle, Plane.YZ, ref Points3);
									double num4 = buShape2.BasePoint.Z - Points3.Z;
									double num5 = num4 * Math.Tan(buConversion5.DegreeToRadian(Job.Material.FrontAngle));
									copiedEntity3.Translate(0.0, 0.0 - num5, num4);
								}
								if ((Job.Material.BackAngle != 0.0) & (Job.Items[i].planeName == planeBoxNames.Back))
								{
									Point3D point3D4 = new Point3D(0.0, Job.Material.Size.Height, Job.Material.Size.Depth);
									copiedEntity3.Rotate(buConversion5.DegreeToRadian(0.0 - Job.Material.BackAngle), Vector3D.AxisX, point3D4);
									Point3D Points4 = buVector5.ToPoint3D(buShape2.CalculatedPoint);
									clsInit.cVector5.Rotate(point3D4, Job.Material.BackAngle, Plane.YZ, ref Points4);
									double num6 = buShape2.BasePoint.Z - Points4.Z;
									double dy2 = num6 * Math.Tan(buConversion5.DegreeToRadian(Job.Material.BackAngle));
									copiedEntity3.Translate(0.0, dy2, num6);
								}
								design.Entities.Add(copiedEntity3);
							}
							if (Job.Items[i].Cam != null)
							{
								for (int l = 0; l <= Job.Items[i].Cam.EntitiesG1.Count - 1; l++)
								{
									Entity copiedEntity4 = null;
									buEntity.Copy(Job.Items[i].Cam.EntitiesG1[l], ref copiedEntity4);
									copiedEntity4.ColorMethod = colorMethodType.byEntity;
									copiedEntity4.Color = Color.Red;
									copiedEntity4.LineWeight = 3f;
									copiedEntity4.LineWeightMethod = colorMethodType.byEntity;
									copiedEntity4.LayerName = buDoor.varTemps.layerCam;
									copiedEntity4.Selectable = false;
									copiedEntity4.Regen(0.01);
									design.Entities.Add(copiedEntity4);
								}
							}
						}
					}
					if (Options.OtherEntities != null)
					{
						for (int m = 0; m <= Options.OtherEntities.Count - 1; m++)
						{
							Options.OtherEntities[m].Selectable = false;
							design.Entities.Add(Options.OtherEntities[m]);
						}
					}
				}
				design.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
				design.ActiveViewport.DisplayMode = displayType.Flat;
				if (Options.ViewportRef != ViewportRefType.Main)
				{
					if (Options.ViewportRef != ViewportRefType.Operation)
					{
						if (Options.ViewportRef == ViewportRefType.Preview)
						{
							design.SetView(viewType.Dimetric);
							design.ZoomFit(5);
						}
					}
					else if (design.Entities.Count >= 2)
					{
						design.Entities[design.Entities.Count - 2].Selected = true;
						design.Entities[design.Entities.Count - 1].Selected = true;
						design.ZoomFit(selectedOnly: true);
						design.Entities[design.Entities.Count - 2].Selected = false;
						design.Entities[design.Entities.Count - 1].Selected = false;
					}
				}
				design.Invalidate();
			}
			else
			{
				design.Invalidate();
			}
		}
		catch (Exception)
		{
		}
	}

	public void FindSecondTool(planeBoxNames planeName, ref ToolBase5 SecondTool)
	{
		SecondTool = null;
		if (!buDoor.varDoorRunSettings.SecondToolEnable)
		{
			return;
		}
		if (planeName == planeBoxNames.Front)
		{
			for (int i = 0; i <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; i++)
			{
				if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[i].Limits.PlaneFront & (ccVars.Tools[ccVars.ToolGroupIndex].Tools[i].Data.No == buDoor.varDoorRunSettings.SecondToolNo))
				{
					SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[i]);
				}
			}
		}
		if (planeName == planeBoxNames.Back)
		{
			for (int j = 0; j <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; j++)
			{
				if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Limits.PlaneBack & (ccVars.Tools[ccVars.ToolGroupIndex].Tools[j].Data.No == buDoor.varDoorRunSettings.SecondToolNo))
				{
					SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[j]);
				}
			}
		}
		if (planeName != planeBoxNames.Top)
		{
			return;
		}
		for (int k = 0; k <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; k++)
		{
			if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[k].Limits.PlaneTop & (ccVars.Tools[ccVars.ToolGroupIndex].Tools[k].Data.No == buDoor.varDoorRunSettings.SecondToolNo))
			{
				SecondTool = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[k]);
			}
		}
	}

	public void ShapeCam(ref buShape refShape)
	{
		clsMW.CamEntities = new List<Entity>();
		int num = 0;
		ToolBase5 SecondTool = null;
		if (buDoor.varDoorRunSettings.SecondToolEnable)
		{
			FindSecondTool(refShape.planeName, ref SecondTool);
			if (SecondTool != null)
			{
				refShape.SecondToolName = SecondTool.Data.Name;
				num = 1;
			}
		}
		for (int i = 0; i <= num; i++)
		{
			for (int j = 0; j <= refShape.entitiesShape.Count - 1; j++)
			{
				Pnt6D refPoint = new Pnt6D();
				bool flag = false;
				buEntity refEntity = buEntity.Copy(refShape.entitiesShape[j]);
				if (!buCompare5.EQ(refEntity.StartPoint, refEntity.EndPoint))
				{
					clsInit.cVector5.ExtendEntitiesIfOpenContour(ref refEntity, refShape.planeOperation, refShape.CamPar.LeadIn.Length, refShape.CamPar.LeadOut.Length);
				}
				ClockDirectionType clockDirectionType = ClockDirectionType.CW;
				clockDirectionType = clsInit.cVector5.GetClockDirection(refEntity, Plane.XZ);
				if (buMWDoorVars.varCamCommon.buPar.Operations.Direction != clockDirectionType)
				{
					buEntity ChangedEntities = refEntity;
					clsInit.cVector5.ChangeEntitiesDirection(ref ChangedEntities);
				}
				clsMW.CamEntities.Clear();
				clsMW.CamEntities = new List<Entity>();
				Entity copiedEntity = null;
				buEntity.Copy(refEntity, ref copiedEntity);
				if (!buCompare5.EQ(refEntity.StartPoint, refEntity.EndPoint) && refShape.CamPar.Pockets.Enable && copiedEntity is CompositeCurve)
				{
					Line item = new Line(refEntity.EndPoint, refEntity.StartPoint);
					((CompositeCurve)copiedEntity).CurveList.Add(item);
					((CompositeCurve)copiedEntity).Regen(0.01);
				}
				if (refShape.planeName == planeBoxNames.Front)
				{
					copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
				}
				if (refShape.planeName == planeBoxNames.Back)
				{
					copiedEntity.Rotate(buConversion5.DegreeToRadian(-90.0), Vector3D.AxisX);
				}
				copiedEntity.Regen(0.01);
				if (copiedEntity is Circle)
				{
					ToolBase5 toolBase = null;
					if (refShape.planeName == planeBoxNames.Front)
					{
						for (int k = 0; k <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; k++)
						{
							if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[k].Limits.PlaneFront)
							{
								toolBase = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[k]);
							}
						}
					}
					if (refShape.planeName == planeBoxNames.Back)
					{
						for (int l = 0; l <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; l++)
						{
							if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[l].Limits.PlaneBack)
							{
								toolBase = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[l]);
							}
						}
					}
					if (refShape.planeName == planeBoxNames.Top)
					{
						for (int m = 0; m <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; m++)
						{
							if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[m].Limits.PlaneTop)
							{
								toolBase = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[m]);
							}
						}
					}
					if (toolBase != null && buCompare5.EQ(toolBase.Geometry.Diameter, ((Circle)copiedEntity).Diameter, 0.1))
					{
						flag = true;
						refPoint = new Pnt6D(((Circle)copiedEntity).Center.X, ((Circle)copiedEntity).Center.Y, ((Circle)copiedEntity).Center.Z);
					}
				}
				clsMW.CamEntities.Add(copiedEntity);
				ToolBase5 toolBase2 = null;
				if (clsMW.CamEntities.Count <= 0)
				{
					continue;
				}
				camTp Cam = new camTp();
				MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
				mWCalculationOptions.NumberofAxis = 3;
				mWCalculationOptions.Mode = CamMode.WireFrame;
				mWCalculationOptions.DontApplyReset = true;
				mWCalculationOptions.isBuWireframeCalculation = false;
				mWCalculationOptions.AddToCamListInLocalCalculation = false;
				mWCalculationOptions.AddToCamListInMWCalculation = false;
				mWCalculationOptions.ShowLeadInOutPage = false;
				mWCalculationOptions.DontShowDialogBox = true;
				double num2 = refShape.Depth;
				if (j >= 1 && refShape.DepthLevel.Count >= 2)
				{
					num2 = refShape.DepthLevel[1];
				}
				mWCalculationOptions.Depth = num2;
				if (refShape.planeName == planeBoxNames.Front)
				{
					mWCalculationOptions.StartZ = 0.0;
					mWCalculationOptions.Height = 0.0 - num2;
					for (int n = 0; n <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; n++)
					{
						if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[n].Limits.PlaneFront && toolBase2 == null)
						{
							toolBase2 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[n]);
						}
					}
					if (activeJob.Material.FrontAngle != 0.0)
					{
						mWCalculationOptions.isPointDistrubition = true;
					}
				}
				if (refShape.planeName == planeBoxNames.Back)
				{
					mWCalculationOptions.StartZ = 0.0;
					mWCalculationOptions.Height = 0.0 - num2;
					for (int num3 = 0; num3 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; num3++)
					{
						if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[num3].Limits.PlaneBack && toolBase2 == null)
						{
							toolBase2 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[num3]);
						}
					}
					if (activeJob.Material.BackAngle != 0.0)
					{
						mWCalculationOptions.isPointDistrubition = true;
					}
				}
				if (refShape.planeName == planeBoxNames.Top)
				{
					mWCalculationOptions.StartZ = activeJob.Material.Size.Depth;
					mWCalculationOptions.Height = activeJob.Material.Size.Depth - num2;
					for (int num4 = 0; num4 <= ccVars.Tools[ccVars.ToolGroupIndex].Tools.Count - 1; num4++)
					{
						if (ccVars.Tools[ccVars.ToolGroupIndex].Tools[num4].Limits.PlaneTop && toolBase2 == null)
						{
							toolBase2 = new ToolBase5(ccVars.Tools[ccVars.ToolGroupIndex].Tools[num4]);
						}
					}
				}
				if (refShape.planeName != planeBoxNames.Top)
				{
					mWCalculationOptions.RapidDistance = mWCalculationOptions.Height + buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
					if (mWCalculationOptions.RapidDistance < 0.0)
					{
						mWCalculationOptions.RapidDistance = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
					}
					mWCalculationOptions.RapidDistance = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
					mWCalculationOptions.SafeDistance = buMWDoorVars.varCamCommon.buPar.Distances.Safe;
				}
				else
				{
					mWCalculationOptions.RapidDistance = activeJob.Material.Size.Depth - mWCalculationOptions.Height + buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
					mWCalculationOptions.SafeDistance = activeJob.Material.Size.Depth + buMWDoorVars.varCamCommon.buPar.Distances.Safe;
				}
				if (toolBase2 == null)
				{
					buString5.MessageBoxWarning(buDoor.LangDoorMessage[35]);
					continue;
				}
				refShape.Tool = new ToolBase5(toolBase2);
				bool flag2 = refShape.CamPar.Pockets.Enable;
				if (i == 1 && SecondTool != null)
				{
					flag2 = false;
					toolBase2 = new ToolBase5(SecondTool);
				}
				if (flag2)
				{
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Pocket;
					doWireframeRough(mWCalculationOptions, toolBase2, ref Cam);
					if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
					{
						if (!buDoor.varDoorSettings.GoFirstXYZSameTime)
						{
							TpPnt9D tpPnt9D = new TpPnt9D(Cam.CamPoints[0].Points[0]);
							Cam.CamPoints[0].Points[0].EnableAxes.Z = false;
							tpPnt9D.PlungeAxisMovement = true;
							Cam.CamPoints[0].Points.Insert(1, tpPnt9D);
						}
						if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].PlungeAxisMovement)
						{
							Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].Type = 0;
						}
						if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].PlungeAxisMovement)
						{
							Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].Type = 0;
						}
					}
				}
				else
				{
					mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
					if (flag)
					{
						mWCalculationOptions.SafeDistance = activeJob.Material.Size.Depth + buMWDoorVars.varCamCommon.buPar.Distances.Safe;
						doDrill(refPoint, refShape.planeName, mWCalculationOptions, toolBase2, ref Cam);
					}
					else
					{
						doWireframeContour(mWCalculationOptions, toolBase2, ref Cam);
					}
					if (Cam.CamPoints.Count > 0 && Cam.CamPoints[0].Points.Count > 0)
					{
						if (!buDoor.varDoorSettings.GoFirstXYZSameTime)
						{
							TpPnt9D tpPnt9D2 = new TpPnt9D(Cam.CamPoints[0].Points[0]);
							Cam.CamPoints[0].Points[0].EnableAxes.Z = false;
							tpPnt9D2.PlungeAxisMovement = true;
							Cam.CamPoints[0].Points.Insert(1, tpPnt9D2);
						}
						if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].PlungeAxisMovement)
						{
							Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 1].Type = 0;
						}
						if (Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].PlungeAxisMovement)
						{
							Cam.CamPoints[0].Points[Cam.CamPoints[0].Points.Count - 2].Type = 0;
						}
					}
				}
				if (refShape.planeName == planeBoxNames.Top)
				{
					Cam.EntitiesG1.Clear();
					clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
				}
				if (refShape.planeName == planeBoxNames.Front)
				{
					List<camTpPoint> CamPoints = Cam.CamPoints;
					clsInit.cCam5.ChangeCamPointCoordinates(ref CamPoints, CamPointChangeMethod.XYZToXZY);
					if (activeJob.Material.FrontAngle != 0.0)
					{
						for (int num5 = 0; num5 <= Cam.CamPoints.Count - 1; num5++)
						{
							for (int num6 = 0; num6 <= Cam.CamPoints[num5].Points.Count - 1; num6++)
							{
								TpPnt9D Points = Cam.CamPoints[num5].Points[num6];
								Point3D centerPoint = new Point3D(0.0, 0.0, activeJob.Material.Size.Depth);
								Point3D Points2 = buVector5.ToPoint3D(refShape.CalculatedPoint);
								if (buDoor.varDoorSettings.UseAngles)
								{
									clsInit.cVector5.Rotate(centerPoint, 0.0 - activeJob.Material.FrontAngle, Plane.YZ, ref Points2);
									clsInit.cVector5.Rotate(centerPoint, 0.0 - activeJob.Material.FrontAngle, Plane.YZ, ref Points);
									double num7 = refShape.BasePoint.Z - Points2.Z;
									double num8 = num7 * Math.Tan(buConversion5.DegreeToRadian(0.0 - activeJob.Material.FrontAngle));
									clsInit.cVector5.Move(0.0, 0.0 - num8, num7, ref Points);
								}
							}
						}
					}
					Cam.EntitiesG1.Clear();
					clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
					clsInit.cVector5.Mirror(new Point3D(), new Point3D(0.0, 0.0, 10.0), Plane.YZ, ref Cam.EntitiesG1);
				}
				if (refShape.planeName == planeBoxNames.Back)
				{
					List<camTpPoint> CamPoints2 = Cam.CamPoints;
					clsInit.cCam5.ChangeCamPointCoordinates(ref CamPoints2, CamPointChangeMethod.XYZToXZY);
					if (activeJob.Material.BackAngle != 0.0)
					{
						for (int num9 = 0; num9 <= Cam.CamPoints.Count - 1; num9++)
						{
							for (int num10 = 0; num10 <= Cam.CamPoints[num9].Points.Count - 1; num10++)
							{
								TpPnt9D Points3 = Cam.CamPoints[num9].Points[num10];
								Point3D centerPoint2 = new Point3D(0.0, 0.0, activeJob.Material.Size.Depth);
								Point3D Points4 = new Point3D(refShape.CalculatedPoint.X, 0.0, refShape.CalculatedPoint.Z);
								if (buDoor.varDoorSettings.UseAngles)
								{
									clsInit.cVector5.Rotate(centerPoint2, 0.0 - activeJob.Material.BackAngle, Plane.YZ, ref Points4);
									clsInit.cVector5.Rotate(centerPoint2, 0.0 - activeJob.Material.BackAngle, Plane.YZ, ref Points3);
									double num11 = refShape.BasePoint.Z - Points4.Z;
									double dY = num11 * Math.Tan(buConversion5.DegreeToRadian(activeJob.Material.BackAngle));
									clsInit.cVector5.Move(0.0, dY, num11, ref Points3);
								}
							}
						}
					}
					if (SecondTool != null && i == 1)
					{
						for (int num12 = 0; num12 <= Cam.CamPoints.Count - 1; num12++)
						{
							Cam.CamPoints[num12].isSecondHead = true;
						}
					}
					Cam.EntitiesG1.Clear();
					clsInit.cCam5.CamPointsToEntities(Cam, ref Cam.EntitiesG1);
					clsInit.cVector5.Move(0.0, activeJob.Material.Size.Height, 0.0, ref Cam.EntitiesG1);
				}
				Cam.Tool.CamData.SpindleSpeed = toolBase2.CamData.SpindleSpeed;
				if (refShape.Cam != null)
				{
					if (refShape.Cam.CamPoints.Count != 0)
					{
						for (int num13 = 0; num13 <= Cam.CamPoints.Count - 1; num13++)
						{
							refShape.Cam.CamPoints.Add(Cam.CamPoints[num13]);
						}
						for (int num14 = 0; num14 <= Cam.EntitiesG0.Count - 1; num14++)
						{
							refShape.Cam.EntitiesG0.Add(Cam.EntitiesG0[num14]);
						}
						for (int num15 = 0; num15 <= Cam.EntitiesG1.Count - 1; num15++)
						{
							refShape.Cam.EntitiesG1.Add(Cam.EntitiesG1[num15]);
						}
						for (int num16 = 0; num16 <= Cam.EntitiesLeadIn.Count - 1; num16++)
						{
							refShape.Cam.EntitiesLeadIn.Add(Cam.EntitiesLeadIn[num16]);
						}
						for (int num17 = 0; num17 <= Cam.EntitiesLeadOut.Count - 1; num17++)
						{
							refShape.Cam.EntitiesLeadOut.Add(Cam.EntitiesLeadOut[num17]);
						}
						for (int num18 = 0; num18 <= Cam.EntitiesPlunge.Count - 1; num18++)
						{
							refShape.Cam.EntitiesPlunge.Add(Cam.EntitiesPlunge[num18]);
						}
						for (int num19 = 0; num19 <= Cam.EntitiesLeave.Count - 1; num19++)
						{
							refShape.Cam.EntitiesLeave.Add(Cam.EntitiesLeave[num19]);
						}
					}
					else
					{
						refShape.Cam = new camTp(Cam);
					}
				}
				else
				{
					refShape.Cam = new camTp(Cam);
				}
			}
		}
	}

	public void ShapeChanged(object Data1, object Data2)
	{
		buShape Shape = Data1 as buShape;
		ShapeUpdateArg shapeUpdateArg = Data2 as ShapeUpdateArg;
		buDoor.varTemps.activePlane = Shape.planeName;
		if (shapeUpdateArg.Finished)
		{
			shapeCreateParameters_0.Solid = true;
			shapeCreateParameters_0.Size = new SizeObject(activeJob.Material.Size);
			Shape.BasePoint.X = shapeUpdateArg.Parameters.pntBase.X;
			Shape.BasePoint.Y = shapeUpdateArg.Parameters.pntBase.Y;
			Shape.BasePoint.Z = shapeUpdateArg.Parameters.pntBase.Z;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = shapeUpdateArg.Parameters.pntBase.X;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = shapeUpdateArg.Parameters.pntBase.Y;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = shapeUpdateArg.Parameters.pntBase.Z;
			clsInit.cVector5.CreatebuShape(ref Shape, shapeCreateParameters_0);
			Shape.DepthLevel = new List<double>();
			Shape.DepthLevel.AddRange(shapeUpdateArg.Parameters.DepthLevels);
			buDoor.varDoorRunSettings.ShapeDataParameters = new ShapeRuntimeData(shapeUpdateArg.Parameters);
			buShape refShape = buShape.Copy(Shape);
			buDoor.varTemps.lastShape = buShape.Copy(Shape);
			refShape.ID = int_0;
			if (refShape.CamPar != null)
			{
				buMWDoorVars.varCamCommon.buPar = new camParameters5(refShape.CamPar);
			}
			ShapeCam(ref refShape);
			if (!AppBool.EditMode)
			{
				activeJob.Items.Add(refShape);
			}
			else if ((int_1 >= 0) & (int_1 <= activeJob.Items.Count - 1))
			{
				activeJob.Items[int_1] = refShape;
			}
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			DrawPanelFromJob(activeJob, new ViewportDrawOptions(ViewportRefType.Preview));
			DoorTreeUpdate();
			SaveDoorFile();
			clsInit.appCommand.Reset();
			int_0++;
		}
		else
		{
			ccVars.pntDrawDynamicLinesArr.Clear();
			shapeCreateParameters_0.Solid = false;
			shapeCreateParameters_0.Size = new SizeObject(activeJob.Material.Size);
			clsInit.cVector5.CreatebuShape(ref Shape, shapeCreateParameters_0);
			if (Shape.entitiesShape.Count > 0)
			{
				if (Shape.entitySolid != null)
				{
					ViewportDrawOptions viewportDrawOptions = new ViewportDrawOptions();
					viewportDrawOptions.OtherEntities = new List<Entity>();
					for (int i = 0; i <= Shape.entitySolid.Count - 1; i++)
					{
						Entity copiedEntity = null;
						buEntity.Copy(Shape.entitySolid[i], ref copiedEntity);
						copiedEntity.Regen(0.01);
						viewportDrawOptions.ViewportRef = ViewportRefType.Operation;
						viewportDrawOptions.OtherEntities.Add(copiedEntity);
					}
					viewportDrawOptions.calcPoint = new Point3D(Shape.CalculatedPoint.X, Shape.CalculatedPoint.Y, Shape.CalculatedPoint.Z);
					viewportDrawOptions.refPoint = new Point3D(Shape.BasePoint.X, Shape.BasePoint.Y, Shape.BasePoint.Z);
					double num = Point3D.Distance(Shape.ItemSize.MinBox, Shape.ItemSize.MaxBox);
					Joint joint = new Joint(buVector5.ToPoint3D(Shape.CalculatedPoint), num * 0.05, 2);
					joint.Color = Color.Red;
					joint.ColorMethod = colorMethodType.byEntity;
					viewportDrawOptions.OtherEntities.Add(joint);
					DrawPanelFromJob(activeJob, viewportDrawOptions);
					if (Shape.planeName == planeBoxNames.Back)
					{
						clsItem.FrmShapeList.viewportLayout.SetView(viewType.Front);
						clsItem.FrmShapeList.viewportLayout.ZoomFit(selectedOnly: true);
					}
					if (Shape.planeName == planeBoxNames.Front)
					{
						clsItem.FrmShapeList.viewportLayout.SetView(viewType.Front);
						clsItem.FrmShapeList.viewportLayout.ZoomFit(selectedOnly: true);
					}
					if (Shape.planeName == planeBoxNames.Left)
					{
						clsItem.FrmShapeList.viewportLayout.SetView(viewType.Right);
						clsItem.FrmShapeList.viewportLayout.ZoomFit(selectedOnly: true);
					}
					if (Shape.planeName == planeBoxNames.Right)
					{
						clsItem.FrmShapeList.viewportLayout.SetView(viewType.Right);
						clsItem.FrmShapeList.viewportLayout.ZoomFit(selectedOnly: true);
					}
					if ((Shape.planeName == planeBoxNames.Top) | (Shape.planeName == planeBoxNames.Bottom))
					{
						clsItem.FrmShapeList.viewportLayout.SetView(viewType.Top);
						clsItem.FrmShapeList.viewportLayout.ZoomFit(selectedOnly: true);
					}
				}
				clsItem.FrmShapeList.viewportLayout.Entities.ClearSelection();
				for (int j = 0; j <= Shape.entitiesShape.Count - 1; j++)
				{
					List<Point3D> copiedPoint = new List<Point3D>();
					buVector5.Copy(Shape.entitiesShape[j].Vertices, ref copiedPoint);
					if (Shape.planeName == planeBoxNames.Front)
					{
						clsInit.cDoor.RotatePointAtFrontPlane(ref copiedPoint, Shape.BasePoint, Shape.CalculatedPoint, activeJob.Material.Size.Depth, activeJob.Material.FrontAngle);
					}
					if (Shape.planeName == planeBoxNames.Back)
					{
						clsInit.cDoor.RotatePointAtBackPlane(ref copiedPoint, Shape.BasePoint, Shape.CalculatedPoint, activeJob.Material.Size.Depth, activeJob.Material.Size.Height, activeJob.Material.BackAngle);
					}
					ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void ShapeCancel()
	{
		clsInit.appCommand.Reset();
	}

	public void doEditOperation(int Index)
	{
		if ((Index >= 0) & (Index <= activeJob.Items.Count - 1))
		{
			AppBool.EditMode = true;
			int_1 = Index;
			buShape.Copy(activeJob.Items[Index], ref buDoor.varTemps.lastShape);
			if (shapeCreateParameters_0.entitiesCurve != null)
			{
				shapeCreateParameters_0.entitiesCurve.Clear();
			}
			if (activeJob.Items[Index].entitiesRef != null && activeJob.Items[Index].entitiesRef.Count > 0)
			{
				buEntity.Copy(activeJob.Items[Index].entitiesRef, ref shapeCreateParameters_0.entitiesCurve);
			}
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.X = buDoor.varTemps.lastShape.BasePoint.X;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Y = buDoor.varTemps.lastShape.BasePoint.Y;
			buDoor.varDoorRunSettings.ShapeDataParameters.pntBase.Z = buDoor.varTemps.lastShape.BasePoint.Z;
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Rectangle)
			{
				Point3D MinPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint, ref MaxPoint);
				buDoor.varDoorRunSettings.ShapeDataParameters.RectangleWidth = ((buShapeRectangle)buDoor.varTemps.lastShape).Width;
				buDoor.varDoorRunSettings.ShapeDataParameters.RectangleHeight = ((buShapeRectangle)buDoor.varTemps.lastShape).Height;
				buDoor.varDoorRunSettings.ShapeDataParameters.RectangleRadius = ((buShapeRectangle)buDoor.varTemps.lastShape).Radius;
				buDoor.varDoorRunSettings.ShapeDataParameters.RectangleDepth = ((buShapeRectangle)buDoor.varTemps.lastShape).Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint.X, MaxPoint.Y, MaxPoint.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint.X, MinPoint.Y, MinPoint.Z);
			}
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Circle)
			{
				Point3D MinPoint2 = new Point3D();
				Point3D MaxPoint2 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint2, ref MaxPoint2);
				buDoor.varDoorRunSettings.ShapeDataParameters.CircleRadius = ((buShapeCircle)buDoor.varTemps.lastShape).Radius;
				buDoor.varDoorRunSettings.ShapeDataParameters.CircleDepth = ((buShapeCircle)buDoor.varTemps.lastShape).Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint2.X, MaxPoint2.Y, MaxPoint2.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint2.X, MinPoint2.Y, MinPoint2.Z);
			}
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Ellipse)
			{
				Point3D MinPoint3 = new Point3D();
				Point3D MaxPoint3 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint3, ref MaxPoint3);
				buDoor.varDoorRunSettings.ShapeDataParameters.EllipseRadiusX = ((buShapeEllipse)buDoor.varTemps.lastShape).RadiusX;
				buDoor.varDoorRunSettings.ShapeDataParameters.EllipseRadiusY = ((buShapeEllipse)buDoor.varTemps.lastShape).RadiusY;
				buDoor.varDoorRunSettings.ShapeDataParameters.EllipseDepth = ((buShapeEllipse)buDoor.varTemps.lastShape).Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint3.X, MaxPoint3.Y, MaxPoint3.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint3.X, MinPoint3.Y, MinPoint3.Z);
			}
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.Slot)
			{
				Point3D MinPoint4 = new Point3D();
				Point3D MaxPoint4 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint4, ref MaxPoint4);
				buDoor.varDoorRunSettings.ShapeDataParameters.SlotLength = ((buShapeSlot)buDoor.varTemps.lastShape).Length;
				buDoor.varDoorRunSettings.ShapeDataParameters.SlotDiameter = ((buShapeSlot)buDoor.varTemps.lastShape).Diameter;
				buDoor.varDoorRunSettings.ShapeDataParameters.SlotAngle = ((buShapeSlot)buDoor.varTemps.lastShape).Angle;
				buDoor.varDoorRunSettings.ShapeDataParameters.SlotDepth = ((buShapeSlot)buDoor.varTemps.lastShape).Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint4.X, MaxPoint4.Y, MaxPoint4.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint4.X, MinPoint4.Y, MinPoint4.Z);
			}
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.KeyHole)
			{
				Point3D MinPoint5 = new Point3D();
				Point3D MaxPoint5 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint5, ref MaxPoint5);
				buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleDiameter = ((buShapeKeyHole)buDoor.varTemps.lastShape).Diameter;
				buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleHeadDiameter = ((buShapeKeyHole)buDoor.varTemps.lastShape).HeadDiameter;
				buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleLength = ((buShapeKeyHole)buDoor.varTemps.lastShape).Length;
				buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleAngle = ((buShapeKeyHole)buDoor.varTemps.lastShape).Angle;
				buDoor.varDoorRunSettings.ShapeDataParameters.KeyHoleDepth = ((buShapeKeyHole)buDoor.varTemps.lastShape).Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint5.X, MaxPoint5.Y, MaxPoint5.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint5.X, MinPoint5.Y, MinPoint5.Z);
			}
			if (buDoor.varTemps.lastShape.ShapeType == ShapeTypes.FreeDraw)
			{
				Point3D MinPoint6 = new Point3D();
				Point3D MaxPoint6 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(buDoor.varTemps.lastShape.entitiesRef, ref MinPoint6, ref MaxPoint6);
				buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawWidth = Math.Round(MaxPoint6.X - MinPoint6.X, 3);
				buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawHeight = Math.Round(MaxPoint6.Y - MinPoint6.Y, 3);
				buDoor.varDoorRunSettings.ShapeDataParameters.FreeDrawDepth = buDoor.varTemps.lastShape.Depth;
				buDoor.varTemps.lastShape.ItemSize.MaxBox = new Point3D(MaxPoint6.X, MaxPoint6.Y, MaxPoint6.Z);
				buDoor.varTemps.lastShape.ItemSize.MinBox = new Point3D(MinPoint6.X, MinPoint6.Y, MinPoint6.Z);
			}
			buDoor.varDoorRunSettings.ShapeDataParameters.selectedPlane = buDoor.varTemps.lastShape.planeName;
			cmdShapes();
		}
	}

	public void doDeleteOperation(int Index)
	{
		if ((Index >= 0) & (Index <= activeJob.Items.Count - 1))
		{
			activeJob.Items.RemoveAt(Index);
			DrawPanelFromJob(activeJob, new ViewportDrawOptions());
			DoorTreeUpdate();
			clsInit.appCommand.Reset();
		}
	}

	public void doDeleteAllOperations()
	{
		activeJob.Items.Clear();
		DrawPanelFromJob(activeJob, new ViewportDrawOptions());
		DoorTreeUpdate();
		clsInit.appCommand.Reset();
	}

	public void doDeletePanel()
	{
		activeJob.Items.Clear();
		activeJob = null;
		DrawPanelFromJob(activeJob, new ViewportDrawOptions());
		DoorTreeUpdate();
		clsInit.appCommand.Reset();
	}

	public void doReset()
	{
		AppBool.EditMode = false;
	}

	public void doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		if (buMWDoorVars.varCamCommon.buPar.Operations.Direction != ClockDirectionType.CW)
		{
			buMWDoorVars.varCamCommon.buPar.Offsets.OpenContour = CamOpenContourType.Left;
		}
		else
		{
			buMWDoorVars.varCamCommon.buPar.Offsets.OpenContour = CamOpenContourType.Right;
		}
		buMWDoorVars.varCamCommon.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDoorVars.varCamCommon.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWDoorVars.varCamCommon.buPar.Steps.DepthStep = MWCalcoptions.Height;
		int numberOfSlice = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
		buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice = numberOfSlice;
		if (buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice >= 2)
		{
			buMWDoorVars.varCamCommon.buPar.Steps.Enable = true;
		}
		if (!buMWDoorVars.varCamCommon.buPar.Steps.Enable)
		{
			buMWDoorVars.varCamCommon.buPar.Steps.DepthStepMode = CamStepDepthMode.ConstantDepthStep;
		}
		else
		{
			buMWDoorVars.varCamCommon.buPar.Steps.DepthStepMode = CamStepDepthMode.NumberOfSlices;
		}
		buMWDoorVars.varCamCommon.buPar.Distances.Air = 0.0;
		buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
		buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
		buMWDoorVars.varCamCommon.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar);
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
		if (buMWDoorVars.varCamCommon.buPar.Steps.Enable)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
		}
		MWCalcoptions.CamWireframeType = CamWireFrameType.Contour;
		if (!MWCalcoptions.isPointDistrubition)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution;
		}
		else
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
		}
		if (ccVars.PostActive.IsArcAsLine)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
		}
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar, out clsMW.varbuCamWFContourPars);
		if (MWCalcoptions.RapidDistance != 0.0)
		{
			clsMW.varbuCamWFContourPars.Distances.EntryAndExit = MWCalcoptions.RapidDistance;
			clsMW.varbuCamWFContourPars.Distances.EntryAndExit = MWCalcoptions.RapidDistance;
			clsMW.varbuCamWFContourPars.Distances.Rapid = MWCalcoptions.RapidDistance;
			clsMW.varMWCamWFContourPars.MachParam.LinkParams.RetractPlaneIncremental = MWCalcoptions.RapidDistance;
			clsMW.varMWCamWFContourPars.MachParam.LinkParams.ApproachFeedPlaneIncremental = MWCalcoptions.RapidDistance;
			clsMW.varMWCamWFContourPars.MachParam.LinkParams.FeedPlaneIncremental = MWCalcoptions.RapidDistance;
		}
		if (MWCalcoptions.SafeDistance != 0.0)
		{
			clsMW.varbuCamWFContourPars.Distances.Safe = MWCalcoptions.SafeDistance;
			clsMW.varMWCamWFContourPars.MachParam.LinkParams.ClearancePlaneHeight = MWCalcoptions.SafeDistance;
		}
		clsMW.varMWCamWFContourPars.MachParam.LinkParams.FirstEntry.Type = FirstEntryType.FromRapidPlane;
		clsMW.varMWCamWFContourPars.MachParam.LinkParams.LastExit.Type = LastExitType.BackToRapidPlane;
		((InterlinkHandeler)clsMW.varMWCamWFContourPars.MachParam.LinkParams.GapsAlongCut).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
		((InterlinkHandeler)clsMW.varMWCamWFContourPars.MachParam.LinkParams.LinkBetweenSlices).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
		((InterlinkHandeler)clsMW.varMWCamWFContourPars.MachParam.LinkParams.LinkBetweenPasses).LargeMoveHandling.Action = MoveHandlingAction.ActionGapRapidPlane;
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doWireframeRough(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		buMWDoorVars.varCamCommon.buPar.Runtime.SimG0DevideLength = 100.0;
		buMWDoorVars.varCamCommon.buPar.Runtime.SimG1DevideLength = 40.0;
		buMWDoorVars.varCamCommon.buPar.Steps.StartValue = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.buPar.Steps.EndValue = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.buPar.Operations.Height = MWCalcoptions.Height;
		int numberOfSlice = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
		buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice = numberOfSlice;
		if (buMWDoorVars.varCamCommon.buPar.Steps.NumberOfSlice >= 2)
		{
			buMWDoorVars.varCamCommon.buPar.Steps.Enable = true;
		}
		if (buMWDoorVars.varCamCommon.buPar.Steps.Enable)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
			buMWDoorVars.varCamCommon.buPar.Steps.StartValue = MWCalcoptions.StartZ;
			buMWDoorVars.varCamCommon.buPar.Steps.EndValue = MWCalcoptions.Height;
		}
		buMWDoorVars.varCamCommon.buPar.Distances.Air = 0.0;
		buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
		buMWDoorVars.varCamCommon.buPar.Distances.EntryAndExit = buMWDoorVars.varCamCommon.buPar.Distances.Rapid;
		buMWDoorVars.varCamCommon.buPar.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		MWCalcoptions.CamWireframeType = CamWireFrameType.Pocket;
		buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage = 70.0;
		if (!((buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage > 0.0) & (buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage <= 100.0)))
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.MaxStepoverDistance = Tool.Geometry.Diameter;
		}
		else
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.MaxStepoverDistance = buMWDoorVars.varCamCommon.buPar.Pockets.StepOverPersentage / 100.0 * Tool.Geometry.Diameter;
		}
		if (buMWDoorVars.varCamCommon.buPar.Pockets.PocketInOut != InToOutType.OutToIn)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg = true;
		}
		else
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.ReverseCuttingOrderFlg = false;
		}
		if (!MWCalcoptions.isPointDistrubition)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotFitArcsAndPointDistribution;
		}
		else
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
		}
		if (ccVars.PostActive.IsArcAsLine)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.TriangleMeshBasedTpCalcParams.ToolpathOutputType = TriangleMeshBasedTpCalcParamsToolpathOutputType.TotPolygonizeAndPointDistribution;
		}
		buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar);
		buMWDoorVars.varCamCommon.mwPar.MachParam.FeedRate = buMWDoorVars.varCamCommon.buPar.Speeds.Pocket;
		clsMW.varMWCamWFPocketPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, buMWDoorVars.varCamCommon.buPar, out clsMW.varbuCamWFPocketPars);
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		buMWDoorVars.varCamCommon.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFPocketPars, clsMW.varbuCamWFPocketPars, out buMWDoorVars.varCamCommon.buPar);
		if (num < 1)
		{
			buString5.MessageBoxError(AppLanguage.CadCamMessages[93]);
			clsInit.appCommand.Reset();
		}
	}

	public void doDrill(Pnt6D refPoint, planeBoxNames planeName, MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		if (Cam == null)
		{
			Cam = new camTp();
		}
		camParameters5 copyBU = new camParameters5(buMWDoorVars.varCamCommon.buPar);
		if (copyBU.Operations.Direction != ClockDirectionType.CW)
		{
			copyBU.Offsets.OpenContour = CamOpenContourType.Left;
		}
		else
		{
			copyBU.Offsets.OpenContour = CamOpenContourType.Right;
		}
		copyBU.Runtime.SimG0DevideLength = 100.0;
		copyBU.Runtime.SimG1DevideLength = 40.0;
		copyBU.Steps.DepthStep = MWCalcoptions.Height;
		int numberOfSlice = Convert.ToInt32(buNumeric5.RoundToUpper(Math.Abs(MWCalcoptions.Depth) / buDoor.varDoorSettings.ZDownOneTimeLimit));
		copyBU.Steps.NumberOfSlice = numberOfSlice;
		if (copyBU.Steps.NumberOfSlice >= 2)
		{
			copyBU.Steps.Enable = true;
		}
		if (!copyBU.Steps.Enable)
		{
			copyBU.Steps.DepthStepMode = CamStepDepthMode.ConstantDepthStep;
		}
		else
		{
			copyBU.Steps.DepthStepMode = CamStepDepthMode.NumberOfSlices;
		}
		copyBU.Distances.Air = 0.0;
		copyBU.Distances.EntryAndExit = copyBU.Distances.Rapid;
		copyBU.Distances.EntryAndExit = copyBU.Distances.Rapid;
		copyBU.Strategy.TangentFirstAngleGreaterThen180StartMinusAngle = true;
		buMWDoorVars.varCamCommon.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWDoorVars.varCamCommon.mwPar, copyBU);
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.EndHeight = MWCalcoptions.Height;
		buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.Height;
		if (copyBU.Steps.Enable)
		{
			buMWDoorVars.varCamCommon.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.MachiningAreaHeightsParams.StartHeight = MWCalcoptions.StartZ;
		}
		copyBU.Distances.RapidRetract = true;
		copyBU.Operations.Depth = MWCalcoptions.Depth;
		if (planeName != planeBoxNames.Top)
		{
			copyBU.Drill.StartHeight = 0.0;
			copyBU.Drill.EndHeight = 0.0 - MWCalcoptions.Depth;
		}
		else
		{
			copyBU.Drill.StartHeight = activeJob.Material.Size.Depth;
			copyBU.Drill.EndHeight = activeJob.Material.Size.Depth - MWCalcoptions.Depth;
			copyBU.Distances.Safe = activeJob.Material.Size.Depth + copyBU.Distances.Safe;
		}
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWDoorVars.varCamCommon.mwPar, copyBU, out clsMW.varbuCamWFContourPars);
		List<Pnt6D> list = new List<Pnt6D>();
		list.Add(refPoint);
		clsInit.cCam5.camDrill(list, Tool, new WorkPlane(), copyBU, ref Cam);
		buMWDoorVars.varCamCommon.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out copyBU);
	}
}
