using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Opaline2Cs;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PowerNest2Cs;
using buCadCamResVer5.Cutter;
using buCadCamResVer5.PanelCut;
using buClass;
using buClass.Apps;
using buControls.ClassViewer;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.buEntities;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Nesting;

public class clsNesting
{
	public static List<buNestingSheet> Sheets = new List<buNestingSheet>();

	public static List<buNestingPart> Parts = new List<buNestingPart>();

	public List<buNestedResult> DoneResults = new List<buNestedResult>();

	public static List<buNestingMaterials> Materials = new List<buNestingMaterials>();

	public static buNestingVar ParNest = new buNestingVar();

	public static buNestingTempVars varTemps = new buNestingTempVars();

	public buNestedResult NestedResult = new buNestedResult();

	public List<buNestedResult> TempResults1 = new List<buNestedResult>();

	public List<Entity> AnalyseEntities = new List<Entity>();

	public static int BestNestCount = 0;

	public clsNesting(string Code = "")
	{
		if (!(Code == "DontCheckLicKeyBro") && !clsSystem.smethod_0("clsNesting"))
		{
			throw new RegisterException("clsNesting");
		}
	}

	public bool Init()
	{
		try
		{
			clsInit.appNestingPower = new clsPowerNest();
			if (clsVar.appModes_0.NestingMode.PanelMode)
			{
				clsInit.appNestingPanel = new clsNestOpaline();
			}
			clsItem.FrmNestSheetPart = new F_NestSheetPartList();
			clsItem.FrmNestPartAdd = new F_NestPartAdd();
			clsItem.FrmNestPartAddV2 = new F_NestPartAddV2();
			clsItem.FrmNestRectPartAdd = new F_NestRectPartAdd();
			clsItem.FrmNestSheetAdd = new F_NestSheetAdd();
			clsItem.FrmNestSheetShapeAdd = new F_NestSheetShapeAdd();
			clsItem.FrmNestExecute = new F_NestExecute();
			clsItem.FrmNestOnlineCalc = new F_NestOnlineCalc();
			clsItem.FrmNestedResult = new F_NestedResults();
			clsItem.FrmOldNestedResult = new F_NestOldResult();
			clsItem.FrmNestOnlineCalc.PreviewPressed += cmdPreviewPressed;
			clsItem.FrmNestOnlineCalc.StopPressed += cmdStopNestingPressed;
			clsItem.FrmNestOnlineCalc.SendPressed += cmdNestResultSendPressed;
			clsItem.FrmNestOnlineCalc.Applied += cmdNestResultApplied;
			clsItem.FrmNestOnlineCalc.ClosedPressed += cmdNesitngPageClosed;
			clsItem.FrmNestedResult.DrawResult += cmdResultDraw;
			clsItem.FrmNestedResult.Creat += doCreate;
			clsItem.FrmNestedResult.Updated += cmdResultUpdate;
			clsItem.FrmNestedResult.Command += cmdResultCommand;
			clsItem.FrmOldNestedResult.PreviewPressed += cmdOldNestingPreviewPressed;
			string text = Path.Combine(Application.StartupPath, "anpn2key.dll");
			if (!string.IsNullOrEmpty(text))
			{
				File.Exists(text);
			}
			else
				_ = 0;
			if (clsVar.appModes_0.NestingMode.PanelMode)
			{
				if (!string.IsNullOrEmpty(clsInit.appNestingPanel.DllName) && File.Exists(clsInit.appNestingPanel.DllName))
				{
					LicenseType licenseType2 = clsInit.appNestingPanel.CheckLicense();
					if (licenseType2 != LicenseType.License2D)
					{
						buString5.MessageBoxError(buLangTranslate.preSentencesNesting.PanelCutNestingDllMode + " " + licenseType2);
					}
				}
				else
				{
					buString5.MessageBoxError(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
				}
			}
			return false;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public void cmdShowSheetPage(bool SheetVisible)
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				if (clsItem.FrmNestSheetPart == null)
				{
					return;
				}
				if (clsItem.FrmNestSheetPart.Visible)
				{
					clsItem.FrmNestSheetPart.Visible = false;
					return;
				}
				clsItem.FrmNestSheetPart.Sheets.Clear();
				clsItem.FrmNestSheetPart.Sheets = new List<buNestingSheet>();
				int tickCount = Environment.TickCount;
				for (int i = 0; i <= Sheets.Count - 1; i++)
				{
					buNestingSheet Copied = new buNestingSheet();
					buNestingSheet.Copy(Sheets[i], ref Copied);
					if (Copied.ID <= 0)
					{
						clsInit.cNesting.GetAvailableNestingSheetID(Sheets, ref Copied.ID);
						Sheets[i].ID = Copied.ID;
					}
					clsItem.FrmNestSheetPart.Sheets.Add(Copied);
				}
				clsItem.FrmNestSheetPart.Parts.Clear();
				clsItem.FrmNestSheetPart.Parts = new List<buNestingPart>();
				for (int j = 0; j <= Parts.Count - 1; j++)
				{
					buNestingPart Copied2 = new buNestingPart();
					buNestingPart.Copy(Parts[j], ref Copied2);
					if (Copied2.ID <= 0)
					{
						clsInit.cNesting.GetAvailableNestingPartID(Parts, ref Copied2.ID);
						Parts[j].ID = Copied2.ID;
					}
					clsItem.FrmNestSheetPart.Parts.Add(Copied2);
				}
				_ = Environment.TickCount - tickCount;
				clsItem.FrmNestSheetPart.AddPartFromFileExtenderAsCsvType = ParNest.Runtime.AddCsvTypeToAddPartFromFile;
				clsItem.FrmNestSheetPart.CsvOpenTypeForAddNestingFromFile = ParNest.Runtime.NestingCsvTypeOpenModeForAddPart;
				clsItem.FrmNestSheetPart.AddPartFromFileFolder = clsVar.varInterface.pathNestingAddPart;
				clsItem.FrmNestSheetPart.AddPartFromFileExtensionIndex = clsVar.varInterface.NestingAddPartFromFileExtensionIndex;
				clsItem.FrmNestSheetPart.Settings = new buNestingVar(ParNest);
				clsItem.FrmNestSheetPart.SaveFileFolder = clsVar.varInterface.pathNestingFiles;
				clsItem.FrmNestSheetPart.activeTool = new ToolBase5(ccVars.toolActive);
				clsItem.FrmNestSheetPart.activeLayer = new LayerBase5(ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex]);
				if (!SheetVisible)
				{
					clsItem.FrmNestSheetPart.Init(1);
				}
				else
				{
					clsItem.FrmNestSheetPart.Init(0);
				}
				clsItem.FrmNestSheetPart.ShowDialog();
				if (clsItem.FrmNestSheetPart.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				ParNest = new buNestingVar(clsItem.FrmNestSheetPart.Settings);
				SheetPartUpdate();
				ccVars.tempEntities.Clear();
				if (!((clsItem.FrmNestSheetPart.SelectedRowPart >= 0) & clsItem.FrmNestSheetPart.DrawPart))
				{
					if (clsItem.FrmNestSheetPart.SendToCad)
					{
						clsInit.appCommand.undoBuffer();
						for (int k = 0; k <= clsItem.FrmNestSheetPart.SendToCadEntities.Count - 1; k++)
						{
							ccVars.UndoDont = true;
							clsItem.FrmNestSheetPart.SendToCadEntities[k].LayerName = ccVars.Pages[ccVars.PageIndex].LayerName;
							clsInit.appCommand.AddEntity(clsItem.FrmNestSheetPart.SendToCadEntities[k]);
						}
					}
					return;
				}
				ccVars.tempEntities.Clear();
				buEntity.Copy(clsItem.FrmNestSheetPart.Parts[clsItem.FrmNestSheetPart.SelectedRowPart].EntitiesGroup, ref ccVars.tempEntities, Inside: true, OpenEntities: true, Solid: false, Text: true);
				for (int l = 0; l <= ccVars.tempEntities.Count - 1; l++)
				{
					Entity entity = ccVars.tempEntities[l];
					bool flag = false;
					for (int m = 0; m <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; m++)
					{
						if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[m].Name == entity.LayerName)
						{
							flag = true;
							entity.ColorMethod = colorMethodType.byLayer;
							entity.LineWeightMethod = colorMethodType.byLayer;
						}
					}
					if (!flag)
					{
						entity.ColorMethod = colorMethodType.byEntity;
						entity.LineWeightMethod = colorMethodType.byEntity;
						entity.LayerName = "Default";
					}
				}
				clsInit.cVector5.BoxSizeCalculate(ccVars.tempEntities, ref ccVars.pntMin, ref ccVars.pntMid, ref ccVars.pntMax);
				for (int n = 0; n <= ccVars.tempEntities.Count - 1; n++)
				{
					ccVars.tempEntities[n].Translate(0.0 - ccVars.pntMid.X, 0.0 - ccVars.pntMid.Y, 0.0 - ccVars.pntMid.Z);
					ccVars.tempEntities[n].Regen(new RegenParams(clsVar.varEntities.RegenDeviation, clsItem.ModelOpenInsert));
				}
				clsInit.cVector5.BoxSizeCalculate(ccVars.tempEntities, ref ccVars.pntMin, ref ccVars.pntMid, ref ccVars.pntMax);
				ccVars.stpDrawing = 2;
				ccVars.selectionProcess = false;
				ccVars.Action = actionTypeBU.drawInsertFromFile;
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowAddSheet()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				if (clsItem.FrmNestSheetAdd == null)
				{
					return;
				}
				if (clsItem.FrmNestSheetAdd.IsDisposed)
				{
					clsItem.FrmNestSheetAdd = new F_NestSheetAdd();
				}
				if (clsItem.FrmNestSheetAdd.Visible)
				{
					clsItem.FrmNestSheetAdd.Visible = false;
					return;
				}
				clsItem.FrmNestSheetAdd.ShowItemNo = ParNest.Runtime.ShowSheetAddItemNoParameter;
				clsItem.FrmNestSheetAdd.Sheet.MaterialData.Width = ParNest.AddMaterial.LastSheetWidth;
				clsItem.FrmNestSheetAdd.Sheet.MaterialData.Height = ParNest.AddMaterial.LastSheetHeight;
				clsItem.FrmNestSheetAdd.Sheet.MaterialData.Quantity = ParNest.AddMaterial.LastSheetQuantity;
				clsItem.FrmNestSheetAdd.Init();
				clsItem.FrmNestSheetAdd.StartPosition = FormStartPosition.CenterScreen;
				clsItem.FrmNestSheetAdd.ShowDialog();
				if (clsItem.FrmNestSheetAdd.Result == DialogResult.OK)
				{
					ParNest.AddMaterial.LastSheetWidth = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Width;
					ParNest.AddMaterial.LastSheetHeight = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Height;
					ParNest.AddMaterial.LastSheetQuantity = clsItem.FrmNestSheetAdd.Sheet.MaterialData.Quantity;
					buNestingSheet buNestingSheet2 = new buNestingSheet(clsItem.FrmNestSheetAdd.Sheet);
					clsInit.cVector5.SetColorEntity(ParNest.Draw.SheetEntityColor, ref buNestingSheet2.EntitiesGroup.Outside.Entities);
					clsInit.cNesting.GetAvailableNestingSheetID(Sheets, ref buNestingSheet2.ID);
					Sheets.Add(buNestingSheet2);
					clsInit.appCommand.ShowInformation(AppLanguage.CadCamInfo[0], 1000);
					clsFiles.SaveParameter();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowAddShapeSheet()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				clsInit.appCommand.Reset(ClearSelection: false);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
				ccVars.Action = actionTypeBU.nestingAddMaterialShapeFromSelection;
				dynamicInfo.Command = AppLanguage.CadCamCommand[88];
				ccVars.selectionProcess = true;
				if (ccVars.SelectionOP.Selections.Count != 0)
				{
					doAddShapePartAndSheet(new Point3D(), isSheet: true, new List<Entity>());
					return;
				}
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdShowAddRectPart()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				if (clsItem.FrmNestRectPartAdd == null)
				{
					return;
				}
				if (clsItem.FrmNestRectPartAdd.IsDisposed)
				{
					clsItem.FrmNestRectPartAdd = new F_NestRectPartAdd();
				}
				if (clsItem.FrmNestRectPartAdd.Visible)
				{
					clsItem.FrmNestRectPartAdd.Visible = false;
					return;
				}
				clsItem.FrmNestRectPartAdd.Settings = new buNestingVar(ParNest);
				clsItem.FrmNestRectPartAdd.ShowItemNo = ParNest.Runtime.ShowPartAddItemNoParameter;
				clsItem.FrmNestRectPartAdd.Init();
				clsItem.FrmNestRectPartAdd.StartPosition = FormStartPosition.CenterScreen;
				clsItem.FrmNestRectPartAdd.ShowDialog();
				if (clsItem.FrmNestRectPartAdd.Result != DialogResult.OK)
				{
					return;
				}
				ParNest = new buNestingVar(clsItem.FrmNestRectPartAdd.Settings);
				buNestingPart buNestingPart2 = new buNestingPart(clsItem.FrmNestRectPartAdd.Part);
				Entity entSurface = null;
				if (ParNest.ProgramSettings.View3D)
				{
					clsInit.cVector5.surfaceFromOutterInner(buNestingPart2.EntitiesGroup, 0.2, ref entSurface);
				}
				if (entSurface != null)
				{
					buNestingPart2.EntitiesGroup.Solid = new buEntityList();
					buEntity copiedEntity = null;
					buEntity.Copy(entSurface, ref copiedEntity);
					if (copiedEntity != null)
					{
						buNestingPart2.EntitiesGroup.Solid.Entities.Add(copiedEntity);
					}
				}
				clsInit.cVector5.SetLayerNameEntity(ccVars.Pages[ccVars.PageIndex].LayerName, ref buNestingPart2.EntitiesGroup.Outside.Entities);
				clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref buNestingPart2.EntitiesGroup.Outside.Entities);
				if (buNestingPart2.EntitiesGroup.Outside.Entities.Count > 0)
				{
					clsInit.cVector5.SetToolNameEntity(ccVars.toolActive.Data.Name, ref buNestingPart2.EntitiesGroup.Outside.Entities);
				}
				clsInit.cNesting.GetAvailableNestingPartID(Parts, ref buNestingPart2.ID);
				Parts.Add(buNestingPart2);
				clsInit.appCommand.ShowInformation(AppLanguage.CadCamInfo[1], 1000);
				clsFiles.SaveParameter();
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			string text = "";
			buLog.addLog(text, "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, text);
		}
	}

	public void cmdShowAddShapePart()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				clsInit.appCommand.Reset(ClearSelection: false);
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
				ccVars.Action = actionTypeBU.nestingAddPartFromSelection;
				if (clsVar.appModes_0.CutterMode.Enable)
				{
					ccVars.Action = actionTypeBU.cutterAddPartFromSelection;
				}
				dynamicInfo.Command = AppLanguage.CadCamCommand[88];
				ccVars.selectionProcess = true;
				clsInit.cVector5.SetNameIfNoName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities);
				if (clsVar.appModes_0.CutterMode.Enable)
				{
					ParNest.AddPart.OutterContourLayerName = clsCutter.varCutterSettings.ContourLayerName;
				}
				if (ccVars.SelectionOP.Selections.Count != 0)
				{
					doAddShapePartAndSheet(new Point3D(), isSheet: false, new List<Entity>());
					return;
				}
				ccVars.stpDrawing = 2;
				clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdShowAddShapePartAll()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				doAddPartAll();
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdShowPartSettings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.FormCaption = "Part";
				f_ClassViewerDialog.Value = ParNest.PartSettings;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 600;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.ParCaptions.AddRange(buNestingPartSettings.Captions);
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result == DialogResult.OK)
				{
					ParNest.PartSettings = new buNestingPartSettings((buNestingPartSettings)f_ClassViewerDialog.Value);
					clsFiles.SaveParameter();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowSheetSettings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.FormCaption = "Sheet";
				f_ClassViewerDialog.Value = ParNest.MaterailSettings;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 750;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.ParCaptions.AddRange(buNestingSheetSettings.Captions);
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result == DialogResult.OK)
				{
					ParNest.MaterailSettings = new buNestingSheetSettings((buNestingSheetSettings)f_ClassViewerDialog.Value);
					clsFiles.SaveParameter();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowResultSettings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.Text = "Result";
				f_ClassViewerDialog.Value = ParNest.ResultSettings;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 750;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result == DialogResult.OK)
				{
					ParNest.ResultSettings = new buNestingResultSettings((buNestingResultSettings)f_ClassViewerDialog.Value);
					clsFiles.SaveParameter();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowNestingSettings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.Text = "Nesting";
				f_ClassViewerDialog.Value = ParNest.Settings;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 350;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result == DialogResult.OK)
				{
					ParNest.Settings = new buNestingSettings((buNestingSettings)f_ClassViewerDialog.Value);
					clsFiles.SaveParameter();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdShowProgramSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Text = "Program";
			f_ClassViewerDialog.Value = ParNest.ProgramSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 350;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				ParNest.ProgramSettings = new buNestingProgramSettings((buNestingProgramSettings)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdExecute()
	{
		if (!clsVar.appModes_0.NestingMode.PanelMode)
		{
			cmdExecuteTrueShape();
		}
		else
		{
			cmdExecutePanel();
		}
	}

	public void cmdExecuteTrueShape()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				clsItem.FrmNestExecute.Settings = new buNestingSettings(ParNest.Settings);
				clsItem.FrmNestExecute.RunTimeSettings = new buNestingRuntime(ParNest.Runtime);
				clsItem.FrmNestExecute.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsItem.FrmNestExecute.StartPosition = FormStartPosition.CenterScreen;
				clsItem.FrmNestExecute.Init();
				clsItem.FrmNestExecute.ShowDialog();
				if (clsItem.FrmNestExecute.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				ParNest.Settings = new buNestingSettings(clsItem.FrmNestExecute.Settings);
				ParNest.Runtime = new buNestingRuntime(clsItem.FrmNestExecute.RunTimeSettings);
				clsFiles.SaveParameter();
				int num = 0;
				int num2 = 0;
				for (int i = 0; i <= Parts.Count - 1; i++)
				{
					if (Parts[i].Enable)
					{
						num += Parts[i].Remain;
					}
				}
				if (num != 0)
				{
					for (int j = 0; j <= Sheets.Count - 1; j++)
					{
						if (Sheets[j].Enable)
						{
							num2 += Sheets[j].Remain;
						}
					}
					if (num2 != 0)
					{
						PowerNest2.LogFunctionCalls(AppPath.Base + "\\NestingExecution.log");
						clsInit.appNestingPower.tempPowerNest = new PowerNest2();
						if (!clsInit.appNestingPower.AddPart(Parts))
						{
							return;
						}
						clsInit.appNestingPower.AddSheet(Sheets);
						NestedResult = new buNestedResult();
						GC.Collect();
						if (clsInit.appNestingPower.Execute(ParNest.Runtime.MaxNestingTimeSec))
						{
							if (clsItem.FrmNestOnlineCalc.IsDisposed)
							{
								clsItem.FrmNestOnlineCalc = new F_NestOnlineCalc();
							}
							if (!ParNest.Settings.NestExecutionByThread)
							{
								clsItem.FrmNestOnlineCalc.SettingsPar = new buNestingVar(ParNest);
								clsItem.FrmNestOnlineCalc.Init(ClearTree: false);
								clsItem.FrmNestOnlineCalc.ShowDialog();
								ParNest = new buNestingVar(clsItem.FrmNestOnlineCalc.SettingsPar);
								clsFiles.SaveParameter();
							}
							else
							{
								clsItem.FrmNestOnlineCalc.btn_send.Enabled = false;
								clsItem.FrmNestOnlineCalc.btn_preview.Enabled = false;
								clsItem.FrmNestOnlineCalc.progress_execution.Maximum = 100;
								clsItem.FrmNestOnlineCalc.SettingsPar = new buNestingVar(ParNest);
								clsItem.FrmNestOnlineCalc.Init();
								clsItem.FrmNestOnlineCalc.ShowDialog();
								ParNest = new buNestingVar(clsItem.FrmNestOnlineCalc.SettingsPar);
								clsFiles.SaveParameter();
							}
						}
					}
					else
					{
						buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoMaterialWillBeUsedForNesting);
					}
				}
				else
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoPartWillWeNested);
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdExecutePanel()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				clsInit.appPanelCut.cmdNestingExecute();
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdFinishPartAdd()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				for (int num = ccVars.Pages.Count - 1; num >= 0; num--)
				{
					clsInit.appCommand.PageClose(num);
				}
				clsInit.appCommand.cmdFileNewPage();
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdGetOldNestedResult()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				List<string> Files = new List<string>();
				buFile5.GetFilesInDirectory(AppPath.Base + "\\NestingTemps", "bunesting", ref Files);
				clsItem.FrmOldNestedResult.Settings = new buNestingVar(ParNest);
				clsItem.FrmOldNestedResult.NestedResultList.Clear();
				for (int i = 0; i <= Files.Count - 1; i++)
				{
					string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(Files[i]);
					clsItem.FrmOldNestedResult.NestedResultList.Add(fileNameWithoutExtension);
				}
				clsItem.FrmOldNestedResult.FileExtension = "bunesting";
				clsItem.FrmOldNestedResult.JobFolder = AppPath.Base + "\\NestingTemps";
				clsItem.FrmOldNestedResult.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsItem.FrmOldNestedResult.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsItem.FrmOldNestedResult.Init();
				clsItem.FrmOldNestedResult.ShowDialog();
				if (clsItem.FrmOldNestedResult.PropertiesForm.Result != DialogResult.OK)
				{
					return;
				}
				ParNest.Runtime = new buNestingRuntime(clsItem.FrmOldNestedResult.Settings.Runtime);
				string fileName = AppPath.Base + "\\NestingTemps\\" + clsItem.FrmOldNestedResult.selectedItem + ".bunesting";
				buFile5.bunesting bunesting = new buFile5.bunesting();
				buNestedResult Result = new buNestedResult();
				List<buNestingPart> Parts = new List<buNestingPart>();
				List<buNestingSheet> Sheets = new List<buNestingSheet>();
				bunesting.OpenNesting(fileName, ref Parts, ref Sheets, ref Result);
				if ((ParNest.Runtime.OldResultImportNestingParts & ParNest.Runtime.OldResultImportNestingClearParts) && Parts.Count > 0)
				{
					clsNesting.Parts.Clear();
				}
				if ((ParNest.Runtime.OldResultImportNestingSheets & ParNest.Runtime.OldResultImportNestingClearSheets) && Sheets.Count > 0)
				{
					clsNesting.Sheets.Clear();
				}
				if (ParNest.Runtime.OldResultImportNestingParts)
				{
					for (int j = 0; j <= Parts.Count - 1; j++)
					{
						clsNesting.Parts.Add(new buNestingPart(Parts[j]));
					}
				}
				if (ParNest.Runtime.OldResultImportNestingSheets)
				{
					for (int k = 0; k <= Sheets.Count - 1; k++)
					{
						clsNesting.Sheets.Add(new buNestingSheet(Sheets[k]));
					}
				}
				if (ParNest.Runtime.OldResultLocation != nestOldResultPosition.ToJob)
				{
					doDrawAllNesting(Result, -1, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: false);
				}
				else
				{
					doAddToAllNestedResult(Result);
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdPreviewPressed(object Result)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (clsItem.FrmPreview == null)
			{
				clsItem.FrmPreview = new F_Preview();
				CreateModelProperties createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				clsInit.cVector5.CreateModelControl(ref clsItem.FrmPreview.viewportLayout, clsVar.UnlockKey, createModelProperties);
			}
			clsItem.FrmPreview.viewportLayout.Entities.Clear();
			int num = 0;
			int sheetIndex = -1;
			int partIndex = -1;
			if (!(Result.GetType() == typeof(string)))
			{
				if (Result.GetType() == typeof(buNestedResult))
				{
					doDrawAllNesting((buNestedResult)Result, sheetIndex, partIndex, clsItem.FrmPreview.viewportLayout, isSolid: true, isPreview: true);
				}
			}
			else
			{
				string[] array = Result.ToString().Split('-');
				if (array != null)
				{
					if (array.Length == 1 && buNumeric5.IsNumeric(array[0]))
					{
						num = Convert.ToInt32(array[0]);
					}
					if (array.Length == 2)
					{
						if (buNumeric5.IsNumeric(array[0]))
						{
							num = Convert.ToInt32(array[0]);
						}
						if (buNumeric5.IsNumeric(array[1]))
						{
							sheetIndex = Convert.ToInt32(array[1]);
						}
					}
					if (array.Length == 3)
					{
						num = Convert.ToInt32(array[0]);
						sheetIndex = Convert.ToInt32(array[1]);
						partIndex = Convert.ToInt32(array[2]);
					}
				}
				if ((num >= 0) & (num <= clsPowerNest.storedNestedResult.Count - 1))
				{
					buNestedResult Result2 = new buNestedResult();
					clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[num], ref Result2);
					doDrawAllNesting(Result2, sheetIndex, partIndex, clsItem.FrmPreview.viewportLayout, isSolid: true, isPreview: true);
				}
			}
			clsItem.FrmPreview.Init(viewType.Top, zoomFit: true, zoomAnimation: false, ViewToolbar: false, ViewCubeIcon: false, ViewOrigine: false, ViewCoordinate: false);
			clsItem.FrmPreview.Show();
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdOldNestingPreviewPressed(object Result)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (clsItem.FrmPreview == null)
			{
				clsItem.FrmPreview = new F_Preview();
				CreateModelProperties createModelProperties = new CreateModelProperties();
				createModelProperties.CoordinateSystemIconVisible = false;
				createModelProperties.ViewCubeIconVisible = false;
				createModelProperties.OrigineCaptionVisible = false;
				createModelProperties.ToolBorVisible = false;
				clsInit.cVector5.CreateModelControl(ref clsItem.FrmPreview.viewportLayout, clsVar.UnlockKey, createModelProperties);
			}
			clsItem.FrmPreview.viewportLayout.Entities.Clear();
			buFile5.bunesting bunesting = new buFile5.bunesting();
			buNestedResult Result2 = new buNestedResult();
			List<buNestingPart> Parts = new List<buNestingPart>();
			List<buNestingSheet> Sheets = new List<buNestingSheet>();
			FileInfo fileInfo = new FileInfo((string)Result);
			if (fileInfo.Exists)
			{
				bunesting.OpenNesting((string)Result, ref Parts, ref Sheets, ref Result2);
				doDrawAllNesting(Result2, -1, -1, clsItem.FrmPreview.viewportLayout, isSolid: true, isPreview: true);
				clsItem.FrmPreview.Init(viewType.Top, zoomFit: true, zoomAnimation: false, ViewToolbar: false, ViewCubeIcon: false, ViewOrigine: false, ViewCoordinate: false);
				clsItem.FrmPreview.Show();
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdStopNestingPressed()
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			clsPowerNest.bStop = true;
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdNesitngPageClosed()
	{
		clsInit.appNestingPower.DisposeNesting();
	}

	public void cmdNestResultSendPressed(object Result)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (Result != null)
			{
				if (((buNestedResultSentEventArg)Result).SendToDraw != nestResultSendType.Draw)
				{
					if (((buNestedResultSentEventArg)Result).SendToDraw != nestResultSendType.Job)
					{
						if (((buNestedResultSentEventArg)Result).SendToDraw == nestResultSendType.File && ((((buNestedResultSentEventArg)Result).IndexResult >= 0) & (((buNestedResultSentEventArg)Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1)))
						{
							buNestedResult Result2 = new buNestedResult();
							clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg)Result).IndexResult], ref Result2);
							doSaveAllNesting(Result2, ((buNestedResultSentEventArg)Result).IndexSheet, ((buNestedResultSentEventArg)Result).IndexPart, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true);
							if (ParNest.Settings.DeleteNestedPartAfterNesting)
							{
								for (int i = 0; i <= Result2.NestedResultSheets.Count - 1; i++)
								{
									for (int j = 0; j <= Result2.NestedResultSheets[i].Parts.Count - 1; j++)
									{
										for (int k = 0; k <= Parts.Count - 1; k++)
										{
											if (Parts[k].ID == Result2.NestedResultSheets[i].Parts[j].ID)
											{
												Parts[k].Selected = true;
												k = Parts.Count;
											}
										}
									}
								}
								for (int num = Parts.Count - 1; num >= 0; num--)
								{
									if (Parts[num].Selected)
									{
										Parts.RemoveAt(num);
									}
								}
							}
							DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
							if (!directoryInfo.Exists)
							{
								Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
							}
							ParNest.Runtime.LastNestedProject = directoryInfo.FullName + "\\" + Result2.JobName + ".bunesting";
							buFile5.bunesting bunesting = new buFile5.bunesting();
							bunesting.SaveNesting(ParNest.Runtime.LastNestedProject, Parts, Sheets, Result2, ParNest);
						}
					}
					else if ((((buNestedResultSentEventArg)Result).IndexResult >= 0) & (((buNestedResultSentEventArg)Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1))
					{
						buNestedResult Result3 = new buNestedResult();
						clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg)Result).IndexResult], ref Result3);
						doAddToAllNestedResult(Result3);
						if (ParNest.Settings.DeleteNestedPartAfterNesting)
						{
							for (int l = 0; l <= Result3.NestedResultSheets.Count - 1; l++)
							{
								for (int m = 0; m <= Result3.NestedResultSheets[l].Parts.Count - 1; m++)
								{
									for (int n = 0; n <= Parts.Count - 1; n++)
									{
										if (Parts[n].ID == Result3.NestedResultSheets[l].Parts[m].ID)
										{
											Parts[n].Selected = true;
											n = Parts.Count;
										}
									}
								}
							}
							for (int num2 = Parts.Count - 1; num2 >= 0; num2--)
							{
								if (Parts[num2].Selected)
								{
									Parts.RemoveAt(num2);
								}
							}
						}
						DirectoryInfo directoryInfo2 = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
						if (!directoryInfo2.Exists)
						{
							Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
						}
						ParNest.Runtime.LastNestedProject = directoryInfo2.FullName + "\\" + Result3.JobName + ".bunesting";
						buFile5.bunesting bunesting2 = new buFile5.bunesting();
						bunesting2.SaveNesting(ParNest.Runtime.LastNestedProject, Parts, Sheets, Result3, ParNest);
					}
				}
				else if ((((buNestedResultSentEventArg)Result).IndexResult >= 0) & (((buNestedResultSentEventArg)Result).IndexResult <= clsPowerNest.storedNestedResult.Count - 1))
				{
					buNestedResult Result4 = new buNestedResult();
					clsInit.appNestingPower.MultiResultToNestedResult(clsPowerNest.storedNestedResult[((buNestedResultSentEventArg)Result).IndexResult], ref Result4);
					doDrawAllNesting(Result4, ((buNestedResultSentEventArg)Result).IndexSheet, ((buNestedResultSentEventArg)Result).IndexPart, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: true);
					if (ParNest.Settings.DeleteNestedPartAfterNesting)
					{
						for (int num3 = 0; num3 <= Result4.NestedResultSheets.Count - 1; num3++)
						{
							for (int num4 = 0; num4 <= Result4.NestedResultSheets[num3].Parts.Count - 1; num4++)
							{
								for (int num5 = 0; num5 <= Parts.Count - 1; num5++)
								{
									if (Parts[num5].ID == Result4.NestedResultSheets[num3].Parts[num4].ID)
									{
										Parts[num5].Selected = true;
										num5 = Parts.Count;
									}
								}
							}
						}
						for (int num6 = Parts.Count - 1; num6 >= 0; num6--)
						{
							if (Parts[num6].Selected)
							{
								Parts.RemoveAt(num6);
							}
						}
					}
					DirectoryInfo directoryInfo3 = new DirectoryInfo(AppPath.Base + "\\NestingTemps");
					if (!directoryInfo3.Exists)
					{
						Directory.CreateDirectory(AppPath.Base + "\\NestingTemps");
					}
					ParNest.Runtime.LastNestedProject = directoryInfo3.FullName + "\\" + Result4.JobName + ".bunesting";
					buFile5.bunesting bunesting3 = new buFile5.bunesting();
					bunesting3.SaveNesting(ParNest.Runtime.LastNestedProject, Parts, Sheets, Result4, ParNest);
				}
				ParNest.Settings = new buNestingSettings(clsItem.FrmNestOnlineCalc.SettingsPar.Settings);
				clsFiles.SaveParameter();
			}
			clsInit.appNestingPower.DisposeNesting();
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdResultCommand(object Data, object Command)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (Command.ToString() == "ShowFolder")
			{
				Process.Start(clsVar.varInterface.pathNestingOutputs);
			}
			if (Command.ToString() == "ShowSheetPart")
			{
				cmdShowSheetPage(SheetVisible: false);
			}
			if (Command.ToString() == "SendParts")
			{
				List<buNestingPart> list = new List<buNestingPart>();
				list = (List<buNestingPart>)Data;
				for (int i = 0; i <= list.Count - 1; i++)
				{
					Parts.Add(new buNestingPart(list[i]));
				}
				cmdShowSheetPage(SheetVisible: false);
			}
			if (Command.ToString() == "SendSheets")
			{
				List<buNestingSheet> list2 = new List<buNestingSheet>();
				list2 = (List<buNestingSheet>)Data;
				for (int j = 0; j <= list2.Count - 1; j++)
				{
					Sheets.Add(new buNestingSheet(list2[j]));
				}
				cmdShowSheetPage(SheetVisible: true);
			}
			if (!(Command.ToString() == "CreateRemnant"))
			{
				return;
			}
			List<buNestedSheet> list3 = Data as List<buNestedSheet>;
			for (int k = 0; k <= list3.Count - 1; k++)
			{
				if (list3[k].RemnantSheets != null && list3[k].RemnantSheets.Count > 0)
				{
					for (int l = 0; l <= list3[k].RemnantSheets.Count - 1; l++)
					{
						buNestingSheet Sheet = new buNestingSheet();
						clsInit.cNesting.SheetRectangle(list3[k].RemnantSheets[l].Width, list3[k].RemnantSheets[l].Height, ref Sheet);
						clsInit.cVector5.SetColorEntity(ParNest.Draw.SheetEntityColor, ref Sheet.EntitiesGroup.Outside.Entities);
						clsInit.cNesting.GetAvailableNestingSheetID(Sheets, ref Sheet.ID);
						Sheet.MaterialData.Width = list3[k].RemnantSheets[l].Width;
						Sheet.MaterialData.Height = list3[k].RemnantSheets[l].Height;
						Sheet.MaterialData.Quantity = 1;
						Sheet.Remain = 1;
						Sheet.Used = 0;
						Sheet.MaterialData.Name = buLangTranslate.preDef.Remnant + "_" + list3[k].Name;
						Sheets.Add(Sheet);
					}
				}
			}
			cmdShowSheetPage(SheetVisible: true);
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdResultDraw(object Result)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (Result != null)
			{
				clsItem.FrmNestedResult.viewport.Entities.Clear();
				doDrawAllNesting(((buNestedResultSentEventArg)Result).NestResult, ((buNestedResultSentEventArg)Result).IndexSheet, ((buNestedResultSentEventArg)Result).IndexPart, clsItem.FrmNestedResult.viewport, isSolid: true, isPreview: true);
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdResultUpdate(object RuntimePar)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (RuntimePar != null)
			{
				ParNest.Runtime = new buNestingRuntime((buNestingRuntime)RuntimePar);
				SaveNestingFile();
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdNestResultApplied(object Setting)
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (Setting != null)
			{
				ParNest.Settings = new buNestingSettings((buNestingSettings)Setting);
				clsFiles.SaveParameter();
			}
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdShowNestedPage()
	{
		if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
		{
			if (buNestingCalc.NestedAllResults.Count < 0)
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoNestedResultToShow);
				return;
			}
			clsItem.FrmNestedResult.NestingResultSettings = new buNestingResultSettings(ParNest.ResultSettings);
			clsItem.FrmNestedResult.RunParameter = new buNestingRuntime(ParNest.Runtime);
			clsItem.FrmNestedResult.NestParameters = new buNestingVar(ParNest);
			if (ParNest.Runtime.ShowNestResultPageAsFullScreen)
			{
				clsItem.FrmNestedResult.WindowState = FormWindowState.Maximized;
			}
			clsItem.FrmNestedResult.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
			clsItem.FrmNestedResult.Init();
			clsItem.FrmNestedResult.Show();
			clsItem.FrmNestedResult.Focus();
		}
		else
		{
			buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
		}
	}

	public void cmdFindFixDrawings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_AnalyseSettings f_AnalyseSettings = new F_AnalyseSettings();
				f_AnalyseSettings.Settings = new AnalyseEntitiesSetting(ParNest.AnalyseSettings);
				f_AnalyseSettings.Properties.FormCloseMode = FormCloseModeType.Dispose;
				f_AnalyseSettings.Properties.FormPosition = FormStartPosition.CenterScreen;
				f_AnalyseSettings.Init();
				f_AnalyseSettings.ShowDialog();
				if (f_AnalyseSettings.Properties.Result == DialogResult.OK)
				{
					ParNest.AnalyseSettings = new AnalyseEntitiesSetting(f_AnalyseSettings.Settings);
					doFindAndFixParts();
					SaveNestingFile();
				}
			}
			else
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NotAvailableFeatures);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		new List<string>();
		FileInfo fileInfo = null;
		fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buNesting.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buNesting.lng"));
		if (!fileInfo.Exists)
		{
			buLog.addLog("Nesting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Nesting Language File Missing");
			return;
		}
		List<string> StringList = new List<string>();
		buFile.OpenFromFile(fileInfo.FullName, ref StringList);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddPart>", "</F_AddPart>", StringList), clsVar.varRuntime.Language, ref F_NestPartAdd.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddRectPart>", "</F_AddRectPart>", StringList), clsVar.varRuntime.Language, ref F_NestRectPartAdd.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddSheet>", "</F_AddSheet>", StringList), clsVar.varRuntime.Language, ref F_NestSheetAdd.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_AddSheetShape>", "</F_AddSheetShape>", StringList), clsVar.varRuntime.Language, ref F_NestSheetShapeAdd.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_SheetParts>", "</F_SheetParts>", StringList), clsVar.varRuntime.Language, ref F_NestSheetPartList.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestExecute>", "</F_NestExecute>", StringList), clsVar.varRuntime.Language, ref F_NestExecute.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestedResult>", "</F_NestedResult>", StringList), clsVar.varRuntime.Language, ref F_NestedResults.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestingCalculation>", "</F_NestingCalculation>", StringList), clsVar.varRuntime.Language, ref F_NestOnlineCalc.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NestOldResult>", "</F_NestOldResult>", StringList), clsVar.varRuntime.Language, ref F_NestOldResult.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_Main>", "</F_Main>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingCaptions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingPartSettings>", "</nestingPartSettings>", StringList), clsVar.varRuntime.Language, ref buNestingPartSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingSheetSettings>", "</nestingSheetSettings>", StringList), clsVar.varRuntime.Language, ref buNestingSheetSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingResultSettings>", "</nestingResultSettings>", StringList), clsVar.varRuntime.Language, ref buNestingResultSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<nestingSettings>", "</nestingSettings>", StringList), clsVar.varRuntime.Language, ref buNestingSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingStatus);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingMessage);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buNesting.LangNestingCaptions);
		StringList.Clear();
	}

	public void SaveNestingFile()
	{
		string text = AppPath.Settings + "\\Nesting";
		if (AppBool.MachineMode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Nesting");
			if (directoryInfo.Exists)
			{
				text = directoryInfo.FullName;
			}
		}
		string fileName = text + "\\NestingSet.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Nesting Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<NestingSettings>");
		arrayList.AddRange(ParNest.AddMaterial.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.AddPart.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.MaterailSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.PartSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.ResultSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.Settings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.Draw.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.ProgramSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.Runtime.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.AddRange(ParNest.AnalyseSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</NestingSettings>");
		arrayList.Add(" ");
		arrayList.Add("<NestingPartsAndSheets>");
		arrayList.AddRange(buNestingSheet.ToDef(Sheets, 2).ToArray());
		arrayList.Add(" ");
		arrayList.AddRange(buNestingPart.ToDef(Parts, 2).ToArray());
		arrayList.Add("</NestingPartsAndSheets>");
		buFile.SaveToFile(arrayList, fileName);
		buLog.addLog("Nesting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
	}

	public void OpenNestingFile()
	{
		string text = AppPath.Settings + "\\Nesting";
		if (AppBool.MachineMode)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(AppPath.MachineSettingsCam + "\\Nesting");
			if (directoryInfo.Exists)
			{
				text = directoryInfo.FullName;
			}
		}
		string fileName = text + "\\NestingSet.prm";
		FileInfo fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			if (clsVar.appModes_0.NestingMode.Enable)
			{
				buLog.addLog("Nesting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Nesting Settings File Missing");
			}
			return;
		}
		ArrayList StringList = new ArrayList();
		buFile.OpenFromFile(fileInfo.FullName, ref StringList);
		try
		{
			ArrayList CalcList = new ArrayList();
			buString.ListToSpecificList("<NestingSettings>", "</NestingSettings>", AddStartEndKey: true, StringList, ref CalcList);
			if (CalcList.Count <= 0)
			{
				buLog.addLog("<NestingSettings> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("<NestingSettings> Line Missing");
			}
			else
			{
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.AddMaterial);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.AddPart);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.MaterailSettings);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.PartSettings);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.ResultSettings);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.Settings);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.Draw);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.ProgramSettings);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.Runtime);
				buSerilization5.Decode(StringList, "", SerilizationMode5.MultiLine, ParNest.AnalyseSettings);
				buLog.addLog("Nesting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				buLog.addLog("Profile Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			}
			CalcList.Clear();
			CalcList = new ArrayList();
			buString.ListToSpecificList("<NestingSheets>", "</NestingSheets>", AddStartEndKey: true, StringList, ref CalcList);
			buNestingSheet.Decode(CalcList, ref Sheets);
			CalcList.Clear();
			CalcList = new ArrayList();
			buString.ListToSpecificList("<NestingParts>", "</NestingParts>", AddStartEndKey: true, StringList, ref CalcList);
			buNestingPart.Decode(StringList, ref Parts);
			CalcList.Clear();
			CalcList = new ArrayList();
			buString.ListToSpecificList("<NestingMaterals>", "</NestingMaterals>", AddStartEndKey: true, StringList, ref CalcList);
			buNestingMaterials.Decode(StringList, ref Materials);
			CalcList.Clear();
			StringList.Clear();
			if (clsVar.appModes_0.CutterMode.Enable)
			{
				ParNest.ProgramSettings.isCutter = true;
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("Nesting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Nesting Settings Decoder Error");
		}
	}

	public bool AddPartFromEntities(buEntitiesGroup entGroup, bool isSheet, bool ShowDialog = true)
	{
		List<int> list = new List<int>();
		ccVars.UndoDont = true;
		if (clsInit.cVector5.isEntitiesClosed(entGroup.Outside.Entities))
		{
			if (clsVar.appModes_0.CutterMode.Enable & clsCutter.varCutterSettings.NotchOnContour)
			{
				List<Entity> list2 = new List<Entity>();
				for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
					{
						CustomData customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].EntityData as CustomData;
						if (customData.typeDefination == entityTypeDefination.Notch && customData.infoString == "VNotch")
						{
							list.Add(i);
							list2.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]));
						}
					}
				}
				new List<List<Entity>>();
			}
			Point3D MinPoint = new Point3D();
			new Point3D();
			Point3D MaxPoint = new Point3D();
			clsInit.cVector5.BoxSizeCalculate(entGroup, ref MinPoint, ref MaxPoint);
			clsInit.cVector5.Move(0.0 - MinPoint.X, 0.0 - MinPoint.Y, 0.0, ref entGroup, clsVar.varEntities.RegenDeviation);
			if (isSheet)
			{
				buNestingSheet buNestingSheet2 = new buNestingSheet();
				buNestingSheet2.MaterialData.Width = MaxPoint.X - MinPoint.X;
				buNestingSheet2.MaterialData.Height = MaxPoint.Y - MinPoint.Y;
				Entity entSurface = null;
				if (ParNest.ProgramSettings.View3D)
				{
					clsInit.cVector5.surfaceFromOutterInner(entGroup, 0.2, ref entSurface);
				}
				if (entSurface != null)
				{
					entGroup.Solid = new buEntityList();
					buEntity copiedEntity = null;
					buEntity.Copy(entSurface, ref copiedEntity);
					if (copiedEntity != null)
					{
						entGroup.Solid.Entities.Add(copiedEntity);
					}
				}
				buNestingSheet2.EntitiesGroup = new buEntitiesGroup(entGroup);
				clsItem.FrmNestSheetShapeAdd.Sheet = new buNestingSheet(buNestingSheet2);
				clsItem.FrmNestSheetShapeAdd.Settings = new buNestingVar(ParNest);
				if (ParNest.PartSettings.AddAutoPartQuantityIfAvailable && entGroup.Text != null && entGroup.Text.Entities.Count > 0)
				{
					clsInit.cNesting.GetPartNameAndQuantity(entGroup.Text.Entities, ParNest, ref ParNest.AddMaterial.Quantity, ref ParNest.AddMaterial.Name);
				}
				clsItem.FrmNestSheetShapeAdd.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
				clsItem.FrmNestSheetShapeAdd.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
				clsItem.FrmNestSheetShapeAdd.Init();
				clsItem.FrmNestSheetShapeAdd.ShowDialog();
				if (clsItem.FrmNestSheetShapeAdd.PropertiesForm.Result != DialogResult.OK)
				{
					return false;
				}
				ParNest = new buNestingVar(clsItem.FrmNestSheetShapeAdd.Settings);
				buNestingSheet2.MaterialData.Thickness = ParNest.AddMaterial.Thickness;
				buNestingSheet2.MaterialData.Quantity = ParNest.AddMaterial.Quantity;
				buNestingSheet2.Remain = ParNest.AddMaterial.Quantity;
				buNestingSheet2.MaterialData.Name = clsItem.FrmNestSheetShapeAdd.txt_name.Text;
				buNestingSheet2.Type = nestMaterialType.Irregular;
				clsInit.cNesting.GetAvailableNestingSheetID(Sheets, ref buNestingSheet2.ID);
				Sheets.Add(buNestingSheet2);
			}
			else
			{
				buNestingPart buNestingPart2 = new buNestingPart();
				buNestingPart buNestingPart3 = new buNestingPart();
				buNestingPart2.PartData.Width = MaxPoint.X - MinPoint.X;
				buNestingPart2.PartData.Height = MaxPoint.Y - MinPoint.Y;
				ParNest.AddPart.Quantity = 1;
				if (ParNest.PartSettings.AddAutoPartQuantityIfAvailable && entGroup.Text != null && entGroup.Text.Entities.Count > 0)
				{
					clsInit.cNesting.GetPartNameAndQuantity(entGroup.Text.Entities, ParNest, ref ParNest.AddPart.Quantity, ref ParNest.AddPart.Name);
				}
				Entity entSurface2 = null;
				if (ParNest.ProgramSettings.View3D)
				{
					clsInit.cVector5.surfaceFromOutterInner(entGroup, 0.2, ref entSurface2);
				}
				if (entSurface2 != null)
				{
					entGroup.Solid = new buEntityList();
					buEntity copiedEntity2 = null;
					buEntity.Copy(entSurface2, ref copiedEntity2);
					if (copiedEntity2 != null)
					{
						entGroup.Solid.Entities.Add(copiedEntity2);
					}
				}
				buNestingPart2.EntitiesGroup = new buEntitiesGroup(entGroup);
				if (!clsVar.UserMode.CompositeMode.Enable)
				{
					if (ShowDialog)
					{
						clsItem.FrmNestPartAdd.Part = new buNestingPart(buNestingPart2);
						clsItem.FrmNestPartAdd.Settings = new buNestingVar(ParNest);
						clsItem.FrmNestPartAdd.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
						clsItem.FrmNestPartAdd.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
						clsItem.FrmNestPartAdd.Init();
						clsItem.FrmNestPartAdd.ShowDialog();
					}
					if (!(clsItem.FrmNestPartAdd.PropertiesForm.Result == DialogResult.OK || !ShowDialog))
					{
						return false;
					}
					for (int j = 0; j <= list.Count - 1; j++)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(list[j]);
					}
					if (ShowDialog)
					{
						ParNest = new buNestingVar(clsItem.FrmNestPartAdd.Settings);
					}
					Point3D MinPoint2 = new Point3D();
					Point3D MaxPoint2 = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(buNestingPart2.EntitiesGroup, ref MinPoint2, ref MaxPoint2);
					buNestingPart2.PartData.Thickness = ParNest.AddPart.Thickness;
					buNestingPart2.PartData.Quantity = ParNest.AddPart.Quantity;
					buNestingPart2.Remain = ParNest.AddPart.Quantity;
					buNestingPart2.PartData.Priority = ParNest.AddPart.Priority;
					if (ShowDialog)
					{
						buNestingPart2.PartData.Name = clsItem.FrmNestPartAdd.txt_name.Text;
					}
					buNestingPart2.PartData.Rotation = ParNest.AddPart.Rotation;
					buNestingPart2.Type = nestMaterialType.Irregular;
					buNestingPart2.UseInnersAsHolePartInPart = ParNest.PartSettings.PartInPart;
					if (entGroup.Text != null)
					{
						new Point3D();
						new Point3D();
					}
					clsInit.cNesting.GetAvailableNestingPartID(Parts, ref buNestingPart2.ID);
					Parts.Add(buNestingPart2);
					if (ParNest.AddPart.MirrorQuantity > 0)
					{
						buNestingPart3 = new buNestingPart(buNestingPart2);
						buNestingPart3.PartData.Quantity = ParNest.AddPart.MirrorQuantity;
						buNestingPart3.Remain = ParNest.AddPart.MirrorQuantity;
						buNestingPart3.PartData.Name = buNestingPart2.PartData.Name + "- [" + buLangTranslate.preDef.Mirror + "]";
						Point3D mirrorPoint = new Point3D(1.0, 0.0, 0.0);
						if (ParNest.AddPart.MirrorAxis == DirectionXandY.YDirection)
						{
							mirrorPoint = new Point3D(0.0, 1.0, 0.0);
						}
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Outside.Entities);
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Outside.Points);
						for (int k = 0; k <= buNestingPart3.EntitiesGroup.Inside.Count - 1; k++)
						{
							buEntityList buEntityList2 = buNestingPart3.EntitiesGroup.Inside[k];
							clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buEntityList2.Entities);
							clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buEntityList2.Points);
						}
						for (int l = 0; l <= buNestingPart3.EntitiesGroup.OpenEntities.Count - 1; l++)
						{
							buEntityList buEntityList3 = buNestingPart3.EntitiesGroup.OpenEntities[l];
							clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buEntityList3.Entities);
							clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buEntityList3.Points);
						}
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Text.Entities);
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Text.Points);
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Solid.Entities);
						clsInit.cVector5.Mirror(new Point3D(), mirrorPoint, Plane.XY, ref buNestingPart3.EntitiesGroup.Solid.Points);
						clsInit.cNesting.GetAvailableNestingPartID(Parts, ref buNestingPart3.ID);
						Parts.Add(buNestingPart3);
					}
				}
				else
				{
					if (ShowDialog)
					{
						clsItem.FrmNestPartAddV2.Part = new buNestingPart(buNestingPart2);
						clsItem.FrmNestPartAddV2.Settings = new buNestingVar(ParNest);
						clsItem.FrmNestPartAddV2.PropertiesForm.FormPosition = FormStartPosition.CenterScreen;
						clsItem.FrmNestPartAddV2.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
						clsItem.FrmNestPartAddV2.Init();
						clsItem.FrmNestPartAddV2.ShowDialog();
					}
					if (!(clsItem.FrmNestPartAddV2.PropertiesForm.Result == DialogResult.OK || !ShowDialog))
					{
						return false;
					}
					for (int m = 0; m <= list.Count - 1; m++)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RemoveAt(list[m]);
					}
					if (ShowDialog)
					{
						ParNest = new buNestingVar(clsItem.FrmNestPartAddV2.Settings);
					}
					Point3D MinPoint3 = new Point3D();
					Point3D MaxPoint3 = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(buNestingPart2.EntitiesGroup, ref MinPoint3, ref MaxPoint3);
					buNestingPart2.UseInnersAsHolePartInPart = false;
					buNestingPart2.PartData.Thickness = ParNest.AddPart.Thickness;
					buNestingPart2.PartData.Quantity = ParNest.AddPart.Quantity;
					buNestingPart2.Remain = ParNest.AddPart.Quantity;
					buNestingPart2.PartData.Priority = ParNest.AddPart.Priority;
					buNestingPart2.PartData.Mirror = ParNest.AddPart.MirrorEnable;
					if (ShowDialog)
					{
						buNestingPart2.PartData.Name = clsItem.FrmNestPartAddV2.txt_name.Text;
					}
					buNestingPart2.PartData.Rotation = ParNest.AddPart.Rotation;
					buNestingPart2.Type = nestMaterialType.Irregular;
					clsInit.cNesting.GetAvailableNestingPartID(Parts, ref buNestingPart2.ID);
					Parts.Add(buNestingPart2);
				}
			}
			return true;
		}
		return false;
	}

	public void AddSheetFromEntities(buEntitiesGroup EntGroup, ref buNestingSheet Sheet)
	{
		Sheet.EntitiesGroup = new buEntitiesGroup(EntGroup);
		if (Sheet.EntitiesGroup.Outside.Entities.Count > 0 && Sheet.EntitiesGroup.Outside.Points == null)
		{
			Sheet.EntitiesGroup.Outside.Points = new List<Point3D>();
			clsInit.cVector5.EntitiesToPointsWithCamDirection(Sheet.EntitiesGroup.Outside.Entities, ref Sheet.EntitiesGroup.Outside.Points);
		}
		if (Sheet.EntitiesGroup.Inside != null)
		{
			for (int i = 0; i <= Sheet.EntitiesGroup.Inside.Count - 1; i++)
			{
				if (Sheet.EntitiesGroup.Inside[i].Points == null)
				{
					Sheet.EntitiesGroup.Inside[i].Points = new List<Point3D>();
					if (Sheet.EntitiesGroup.Inside[i].Entities.Count > 0)
					{
						clsInit.cVector5.EntitiesToPointsWithCamDirection(Sheet.EntitiesGroup.Inside[i].Entities, ref Sheet.EntitiesGroup.Inside[i].Points);
					}
				}
			}
		}
		Entity entSurface = null;
		if (ParNest.ProgramSettings.View3D)
		{
			clsInit.cVector5.surfaceFromOutterInner(Sheet.EntitiesGroup, 0.2, ref entSurface);
		}
		if (entSurface != null)
		{
			Sheet.EntitiesGroup.Solid = new buEntityList();
			buEntity copiedEntity = null;
			buEntity.Copy(entSurface, ref copiedEntity);
			if (copiedEntity != null)
			{
				Sheet.EntitiesGroup.Solid.Entities.Add(copiedEntity);
			}
		}
	}

	public void CreatePdf(buNestedResultEventArg NestResult, bool DoubleSheet = false)
	{
		XFont font = new XFont("Verdana", 20.0, XFontStyle.Bold);
		XFont font2 = new XFont("Verdana", 12.0);
		Design viewport = null;
		CreateModelProperties createModelProperties = new CreateModelProperties();
		createModelProperties.BottomColor = Color.White;
		createModelProperties.MiddleColor = Color.White;
		createModelProperties.TopColor = Color.White;
		createModelProperties.CoordinateSystemIconVisible = false;
		createModelProperties.ViewCubeIconVisible = false;
		createModelProperties.OrigineCaptionVisible = false;
		createModelProperties.ToolBorVisible = false;
		createModelProperties.Width = clsItem.FrmNestedResult.viewport.Width;
		createModelProperties.Height = clsItem.FrmNestedResult.viewport.Height;
		clsInit.cVector5.CreateModelControl(ref viewport, clsVar.UnlockKey, createModelProperties);
		viewport.ActiveViewport.Camera.ProjectionMode = projectionType.Orthographic;
		PdfDocument pdfDocument = new PdfDocument();
		double num = 0.0;
		if (NestResult.SelectedSheet != -1)
		{
			if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
			{
				num = 0.0;
				viewport.Entities.Clear();
				doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, viewport, isSolid: true, isPreview: true);
				viewport.SetView(viewType.Top, fit: true, animate: false);
				viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
				Image image = Clipboard.GetImage();
				PdfPage pdfPage = pdfDocument.AddPage();
				XGraphics xGraphics = XGraphics.FromPdfPage(pdfPage);
				string text = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], NestResult.SelectedSheet);
				xGraphics.DrawString(text, font, XBrushes.Black, new XRect(0.0, 10.0, pdfPage.Width.Point, 20.0), XStringFormats.Center);
				if (image != null)
				{
					double num2 = (double)viewport.Width / (double)viewport.Height;
					MemoryStream stream = new MemoryStream();
					image.Save(stream, ImageFormat.Png);
					XImage image2 = XImage.FromStream(stream);
					double num3 = pdfPage.Width.Point - 40.0;
					double num4 = num3 / num2;
					xGraphics.DrawImage(image2, new XRect(20.0, 40.0, num3, num4));
					num = 40.0 + num4;
				}
				string refString = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, NestResult.SelectedSheet, ParNest.ProgramSettings);
				ArrayList Lines = new ArrayList();
				buString5.StringToArrayListByNewLine(refString, ref Lines);
				for (int i = 0; i <= Lines.Count - 1; i++)
				{
					xGraphics.DrawString(Lines[i].ToString(), font2, XBrushes.Black, new XPoint(20.0, num + 20.0));
					num += 20.0;
				}
			}
		}
		else
		{
			PdfPage pdfPage2 = pdfDocument.AddPage();
			XGraphics xGraphics2 = XGraphics.FromPdfPage(pdfPage2);
			xGraphics2.DrawString(NestResult.nestedResult.JobName, font, XBrushes.Black, new XRect(0.0, 10.0, pdfPage2.Width.Point, 20.0), XStringFormats.Center);
			viewport.Entities.Clear();
			doDrawAllNesting(NestResult.nestedResult, -1, -1, viewport, ParNest.ProgramSettings.View3D, isPreview: true);
			viewport.SetView(viewType.Top, fit: true, animate: false);
			viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
			Image image3 = Clipboard.GetImage();
			if (image3 != null)
			{
				double num5 = (double)image3.Width / (double)image3.Height;
				MemoryStream stream2 = new MemoryStream();
				image3.Save(stream2, ImageFormat.Png);
				XImage image4 = XImage.FromStream(stream2);
				double num6 = pdfPage2.Width.Point - 40.0;
				double num7 = num6 / num5;
				xGraphics2.DrawImage(image4, new XRect(20.0, 40.0, num6, num7));
				num = 40.0 + num7;
			}
			string refString2 = buNestingCalc.NestedResultInfo(NestResult.nestedResult, ParNest.ProgramSettings);
			ArrayList Lines2 = new ArrayList();
			buString5.StringToArrayListByNewLine(refString2, ref Lines2);
			for (int j = 0; j <= Lines2.Count - 1; j++)
			{
				xGraphics2.DrawString(Lines2[j].ToString(), font2, XBrushes.Black, new XPoint(20.0, num + 20.0));
				num += 20.0;
			}
			if (!DoubleSheet)
			{
				for (int k = 0; k <= NestResult.nestedResult.NestedResultSheets.Count - 1; k++)
				{
					num = 0.0;
					viewport.Entities.Clear();
					doDrawAllNesting(NestResult.nestedResult, k, -1, viewport, isSolid: true, isPreview: true);
					viewport.SetView(viewType.Top, fit: true, animate: false);
					viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
					Image image5 = Clipboard.GetImage();
					PdfPage pdfPage3 = pdfDocument.AddPage();
					XGraphics xGraphics3 = XGraphics.FromPdfPage(pdfPage3);
					string text2 = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], k);
					xGraphics3.DrawString(text2, font, XBrushes.Black, new XRect(0.0, 10.0, pdfPage3.Width.Point, 20.0), XStringFormats.Center);
					if (image5 != null)
					{
						double num8 = (double)viewport.Width / (double)viewport.Height;
						MemoryStream stream3 = new MemoryStream();
						image5.Save(stream3, ImageFormat.Png);
						XImage image6 = XImage.FromStream(stream3);
						double num9 = pdfPage3.Width.Point - 40.0;
						double num10 = num9 / num8;
						xGraphics3.DrawImage(image6, new XRect(20.0, 40.0, num9, num10));
						num = 40.0 + num10;
					}
					string refString3 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, k, ParNest.ProgramSettings);
					Lines2 = new ArrayList();
					buString5.StringToArrayListByNewLine(refString3, ref Lines2);
					for (int l = 0; l <= Lines2.Count - 1; l++)
					{
						xGraphics3.DrawString(Lines2[l].ToString(), font2, XBrushes.Black, new XPoint(20.0, num + 20.0));
						num += 20.0;
					}
				}
			}
			else
			{
				font2 = new XFont("Verdana", 10.0);
				for (int m = 0; m <= NestResult.nestedResult.NestedResultSheets.Count - 1; m += 2)
				{
					PdfPage pdfPage4 = null;
					XGraphics xGraphics4 = null;
					pdfPage4 = pdfDocument.AddPage();
					xGraphics4 = XGraphics.FromPdfPage(pdfPage4);
					num = 0.0;
					viewport.Entities.Clear();
					doDrawAllNesting(NestResult.nestedResult, m, -1, viewport, ParNest.ProgramSettings.View3D, isPreview: true);
					viewport.SetView(viewType.Top, fit: true, animate: false);
					Application.DoEvents();
					Thread.Sleep(20);
					viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
					Image image7 = Clipboard.GetImage();
					Application.DoEvents();
					Thread.Sleep(20);
					if (image7 != null)
					{
						double num11 = (double)viewport.Width / (double)viewport.Height;
						MemoryStream stream4 = new MemoryStream();
						image7.Save(stream4, ImageFormat.Png);
						XImage image8 = XImage.FromStream(stream4);
						double num12 = pdfPage4.Width.Point - 40.0;
						double num13 = num12 / num11;
						xGraphics4.DrawImage(image8, new XRect(20.0, -20.0, num12, num13));
						num = 40.0 + num13;
					}
					string text3 = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], m);
					xGraphics4.DrawString(text3, font, XBrushes.Black, new XRect(0.0, 5.0, pdfPage4.Width.Point, 20.0), XStringFormats.Center);
					string refString4 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, m, ParNest.ProgramSettings, 2);
					Lines2 = new ArrayList();
					buString5.StringToArrayListByNewLine(refString4, ref Lines2);
					for (int n = 0; n <= Lines2.Count - 1; n++)
					{
						xGraphics4.DrawString(Lines2[n].ToString(), font2, XBrushes.Black, new XPoint(20.0, 310 + n * 20));
					}
					if (m + 1 <= NestResult.nestedResult.NestedResultSheets.Count - 1)
					{
						num = 400.0;
						viewport.Entities.Clear();
						doDrawAllNesting(NestResult.nestedResult, m + 1, -1, viewport, isSolid: true, isPreview: true);
						viewport.SetView(viewType.Top, fit: true, animate: false);
						Application.DoEvents();
						Thread.Sleep(20);
						viewport.CopyToClipboardRaster(new Size(viewport.Width, viewport.Height), drawBackground: true);
						image7 = Clipboard.GetImage();
						Application.DoEvents();
						Thread.Sleep(20);
						if (image7 != null)
						{
							double num14 = (double)viewport.Width / (double)viewport.Height;
							MemoryStream stream5 = new MemoryStream();
							image7.Save(stream5, ImageFormat.Png);
							XImage image9 = XImage.FromStream(stream5);
							double num15 = pdfPage4.Width.Point - 40.0;
							double num16 = num15 / num14;
							xGraphics4.DrawImage(image9, new XRect(20.0, 380.0, num15, num16));
							num = 40.0 + num16;
						}
						text3 = buNestingCalc.SheetItemFormat(NestResult.nestedResult, AppLanguage.CadCamDynamic[33], m + 1);
						xGraphics4.DrawString(text3, font, XBrushes.Black, new XRect(0.0, 405.0, pdfPage4.Width.Point, 20.0), XStringFormats.Center);
						refString4 = buNestingCalc.NestedSheetInfo(NestResult.nestedResult, m + 1, ParNest.ProgramSettings, 2);
						Lines2 = new ArrayList();
						buString5.StringToArrayListByNewLine(refString4, ref Lines2);
						for (int num17 = 0; num17 <= Lines2.Count - 1; num17++)
						{
							xGraphics4.DrawString(Lines2[num17].ToString(), font2, XBrushes.Black, new XPoint(20.0, 710 + num17 * 20));
							num += 20.0;
						}
					}
				}
			}
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
		saveFileDialog.Filter = "Pdf File (*.pdf)|*.pdf";
		saveFileDialog.FilterIndex = 1;
		if (pdfDocument.PageCount > 0 && saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			ParNest.Runtime.NestingResultPdfFile = NestResult.PdfFile;
			ParNest.Runtime.NestingResultDoCam = NestResult.DoCam;
			ParNest.Runtime.nestedResultCreateType = NestResult.ResultCreateType;
			ParNest.Runtime.nestedResultSheetType = NestResult.ResultSheetType;
			clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
			pdfDocument.Save(saveFileDialog.FileName);
			clsFiles.SaveParameter();
		}
	}

	public void CreateDxf(buNestedResultEventArg NestResult, bool Draw = true)
	{
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		if (Draw)
		{
			doDrawAllNesting(NestResult.nestedResult, -1, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: false, isPreview: false);
		}
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
		saveFileDialog.Filter = "Autocad Dxf File (*.dxf)|*.dxf";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
			clsInit.cVector5.SaveDxfFile(saveFileDialog.FileName, ccVars.Pages[ccVars.PageIndex].Form.viewportcad);
		}
		clsInit.appCommand.Reset();
	}

	public void CreateHpgl(buNestedResultEventArg NestResult)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
		saveFileDialog.Filter = "HPGL File (*.hpgl)|*.hpgl";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
			buFile5.HPGLFile hPGLFile = new buFile5.HPGLFile();
			if (NestResult.SelectedSheet < 0)
			{
				for (int i = 0; i <= NestResult.nestedResult.NestedResultSheets.Count - 1; i++)
				{
					string fileExtension = buFile5.getFileExtension(saveFileDialog.FileName);
					string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
					string path = buFile5.GetPath(saveFileDialog.FileName);
					string name = path + "\\" + fileNameWithoutExtension + "_" + (i + 1).ToString("D3") + fileExtension;
					List<List<Entity>> partEntities = new List<List<Entity>>();
					List<List<Entity>> innerEntities = new List<List<Entity>>();
					List<List<Entity>> auxEntities = new List<List<Entity>>();
					List<List<Entity>> copiedEnt = new List<List<Entity>>();
					clsInit.cNesting.GetAllNestedPartFromSheet(NestResult.nestedResult.NestedResultSheets[i], isSorted: true, ref partEntities, ref innerEntities, ref auxEntities);
					buVector5.AddEntities(innerEntities, ref copiedEnt);
					buVector5.AddEntities(auxEntities, ref copiedEnt);
					buVector5.AddEntities(partEntities, ref copiedEnt);
					hPGLFile.WriteHPGL(name, clsVar.varFile.HPGLFileProperties, copiedEnt);
				}
			}
			else if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
			{
				List<List<Entity>> partEntities2 = new List<List<Entity>>();
				List<List<Entity>> innerEntities2 = new List<List<Entity>>();
				List<List<Entity>> auxEntities2 = new List<List<Entity>>();
				List<List<Entity>> copiedEnt2 = new List<List<Entity>>();
				string jobName = NestResult.nestedResult.JobName;
				jobName = jobName + " - Width " + NestResult.nestedResult.MaxYPosition.ToString("f2");
				jobName = jobName + " - Length " + NestResult.nestedResult.MaxXPosition.ToString("f2");
				jobName = jobName + " - %" + NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet].UsingPersentageFromMaxX.ToString("f2");
				jobName = jobName + " - Part Count " + NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet].Parts.Count.ToString("");
				new List<ContourPoints5>();
				clsInit.cNesting.GetAllNestedPartFromSheet(NestResult.nestedResult.NestedResultSheets[NestResult.SelectedSheet], isSorted: true, ref partEntities2, ref innerEntities2, ref auxEntities2);
				buVector5.AddEntities(innerEntities2, ref copiedEnt2);
				buVector5.AddEntities(auxEntities2, ref copiedEnt2);
				buVector5.AddEntities(partEntities2, ref copiedEnt2);
				hPGLFile.WriteHPGL(saveFileDialog.FileName, clsVar.varFile.HPGLFileProperties, copiedEnt2);
			}
		}
		clsInit.appCommand.Reset();
	}

	public void CreateCsv(buNestedResultEventArg NestResult)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
		saveFileDialog.Filter = "Csv File (*.csv)|*.csv";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
			List<string> list = new List<string>();
			string item = "Name ; Index ; Width ; Height ; Area ; Sheet Persentage ; Part Count; Max X; Pastal Persentage";
			list.Add(item);
			for (int i = 0; i <= NestResult.nestedResult.NestedResultSheets.Count - 1; i++)
			{
				buNestedSheet buNestedSheet2 = NestResult.nestedResult.NestedResultSheets[i];
				item = buNestedSheet2.Name + " ; " + (i + 1) + " ; " + buNestedSheet2.MaterialWidth.ToString("f3") + " ; " + buNestedSheet2.MaterialHeight.ToString("f3") + " ; " + buNestedSheet2.MaterialArea.ToString("f3") + " ; " + buNestedSheet2.UsingPersentage.ToString("f3") + " ; " + buNestedSheet2.Parts.Count + " ; " + buNestedSheet2.SheetMaxXPosition.ToString("f3") + " ; " + buNestedSheet2.UsingPersentageFromMaxX.ToString("f3");
				list.Add(item);
			}
			buFile5.SaveToFile(list, saveFileDialog.FileName);
		}
	}

	public void CreateIsoCutter(buNestedResultEventArg NestResult, bool Draw = true)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.InitialDirectory = clsVar.varInterface.pathNestingOutputs;
		saveFileDialog.Filter = "Iso File (*.iso)|*.iso";
		saveFileDialog.FilterIndex = 1;
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			List<List<Entity>> DrawEntities = new List<List<Entity>>();
			clsVar.varInterface.pathNestingOutputs = buFile5.GetPath(saveFileDialog.FileName);
			if (NestResult.SelectedSheet < 0)
			{
				for (int i = 0; i <= NestResult.nestedResult.NestedResultSheets.Count - 1; i++)
				{
					string fileExtension = buFile5.getFileExtension(saveFileDialog.FileName);
					string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(saveFileDialog.FileName);
					string path = buFile5.GetPath(saveFileDialog.FileName);
					string fileName = path + "\\" + fileNameWithoutExtension + "_" + (i + 1).ToString("D3") + fileExtension;
					CutterIsoFileSettings cutterIsoFileSettings = new CutterIsoFileSettings();
					cutterIsoFileSettings.XScaleFactor = clsCutter.varCutterSettings.XScaleFactor;
					cutterIsoFileSettings.YScaleFactor = clsCutter.varCutterSettings.YScaleFactor;
					cutterIsoFileSettings.NotchOnContour = clsCutter.varCutterSettings.NotchOnContour;
					clsInit.cCutter.WriteIsoFile(fileName, i, cutterIsoFileSettings, NestResult.nestedResult, clsCutter.varCutterSettings, ref DrawEntities);
				}
			}
			else if (NestResult.SelectedSheet <= NestResult.nestedResult.NestedResultSheets.Count - 1)
			{
				CutterIsoFileSettings cutterIsoFileSettings2 = new CutterIsoFileSettings();
				cutterIsoFileSettings2.XScaleFactor = clsCutter.varCutterSettings.XScaleFactor;
				cutterIsoFileSettings2.YScaleFactor = clsCutter.varCutterSettings.YScaleFactor;
				cutterIsoFileSettings2.NotchOnContour = clsCutter.varCutterSettings.NotchOnContour;
				clsInit.cCutter.WriteIsoFile(saveFileDialog.FileName, NestResult.SelectedSheet, cutterIsoFileSettings2, NestResult.nestedResult, clsCutter.varCutterSettings, ref DrawEntities);
			}
			if (Draw && DrawEntities.Count > 0)
			{
				clsInit.appCommand.undoBuffer();
				for (int j = 0; j <= DrawEntities.Count - 1; j++)
				{
					for (int k = 0; k <= DrawEntities[j].Count - 1; k++)
					{
						ccVars.UndoDont = true;
						clsInit.appCommand.AddEntity(DrawEntities[j][k]);
					}
				}
			}
		}
		clsInit.appCommand.Reset();
	}

	public void doCreate(buNestedResultEventArg NestResult)
	{
		ParNest.Runtime.NestingResultPdfFile = NestResult.PdfFile;
		ParNest.Runtime.nestedResultCreateType = NestResult.ResultCreateType;
		ParNest.Runtime.nestedResultSheetType = NestResult.ResultSheetType;
		ParNest.Runtime.NestingResultDoCam = NestResult.DoCam;
		clsFiles.SaveParameter();
		if (NestResult.ResultCreateType != nestedCreateType.Dxf)
		{
			if (NestResult.ResultCreateType != nestedCreateType.Hpgl)
			{
				if (NestResult.ResultCreateType != nestedCreateType.Iso)
				{
					if (NestResult.CsvFile)
					{
						CreateCsv(NestResult);
					}
					if (NestResult.ResultCreateType == nestedCreateType.Draw)
					{
						ccVars.UndoDont = false;
						clsInit.appCommand.undoBuffer();
						if (NestResult.ResultSettings != null)
						{
							ParNest.ResultSettings = new buNestingResultSettings(NestResult.ResultSettings);
						}
						if (ParNest.ResultSettings.DrawAddClearAll)
						{
							ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
						}
						if (!clsVar.appModes_0.FoamCuttingMode.Enable)
						{
							if (!clsVar.appModes_0.MarbleMode.Enable)
							{
								if (!clsVar.appModes_0.CompositeMode.Enable)
								{
									doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: false);
								}
								else
								{
									int sheetIndex = NestResult.SelectedSheet;
									if (NestResult.ResultSheetType == nestedCreateSheetType.All)
									{
										sheetIndex = -1;
									}
									if (NestResult.DoCam)
									{
										clsInit.appRouter3AX.doCamFromNesting(NestResult);
									}
									else
									{
										doDrawAllNesting(NestResult.nestedResult, sheetIndex, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: false);
									}
								}
							}
							else if (clsInit.appMarble != null)
							{
								clsInit.appMarble.doNestingResult(NestResult);
							}
						}
						else
						{
							clsInit.appFoamCutting.doGetNestResult(NestResult.nestedResult, NestResult.SelectedSheet, -1);
						}
					}
					if (NestResult.ResultCreateType == nestedCreateType.SaveFile)
					{
						if (!clsVar.appModes_0.CompositeMode.Enable)
						{
							doDrawAllNesting(NestResult.nestedResult, NestResult.SelectedSheet, -1, ccVars.Pages[ccVars.PageIndex].Form.viewportcad, isSolid: true, isPreview: false);
						}
						else
						{
							clsInit.appRouter3AX.doCamFromNesting(NestResult);
						}
					}
					if (NestResult.PdfFile)
					{
						CreatePdf(NestResult, ParNest.ProgramSettings.DoubleSheetAtPdf);
					}
					if (((NestResult.SelectedResult >= 0) & (NestResult.SelectedResult <= buNestingCalc.NestedAllResults.Count - 1)) && NestResult.nestedResult != null)
					{
						for (int i = 0; i <= NestResult.nestedResult.NestedResultSheets.Count - 1; i++)
						{
							if (NestResult.nestedResult.NestedResultSheets[i].GCodeResult != null && i <= buNestingCalc.NestedAllResults[NestResult.SelectedResult].NestedResultSheets.Count - 1)
							{
								buNestingCalc.NestedAllResults[NestResult.SelectedResult].NestedResultSheets[i].GCodeResult = new MachineGCodeExecutionResult(NestResult.nestedResult.NestedResultSheets[i].GCodeResult);
							}
						}
					}
					ParNest.Runtime = new buNestingRuntime(clsItem.FrmNestedResult.RunParameter);
					clsFiles.SaveParameter();
				}
				else if (clsVar.appModes_0.CutterMode.Enable)
				{
					CreateIsoCutter(NestResult);
				}
			}
			else
			{
				CreateHpgl(NestResult);
			}
		}
		else
		{
			CreateDxf(NestResult);
		}
	}

	public void doAddPartAll()
	{
		List<buEntity> refEntities = new List<buEntity>();
		List<buEntity> refEntities2 = new List<buEntity>();
		int tickCount = Environment.TickCount;
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName)
			{
				buEntity copiedEntity = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
				copiedEntity.Info.OriginalEntityIndex = i;
				refEntities.Add(copiedEntity);
			}
		}
		if (refEntities.Count != 0)
		{
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName != ccVars.Pages[ccVars.PageIndex].LayerName && (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].LayerName].Visible & ((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is ICurve) | (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is Text))))
				{
					buEntity copiedEntity2 = null;
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j], ref copiedEntity2);
					copiedEntity2.Info.OriginalEntityIndex = j;
					refEntities2.Add(copiedEntity2);
				}
			}
		}
		else
		{
			for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
			{
				if (!(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName))
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].LayerName].Visible & ((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is ICurve) | (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is Text)))
					{
						buEntity copiedEntity3 = null;
						buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k], ref copiedEntity3);
						copiedEntity3.Info.OriginalEntityIndex = k;
						refEntities2.Add(copiedEntity3);
					}
				}
				else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is ICurve)
				{
					buEntity copiedEntity4 = null;
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k], ref copiedEntity4);
					copiedEntity4.Info.OriginalEntityIndex = k;
					refEntities.Add(copiedEntity4);
				}
			}
		}
		if (refEntities.Count <= 0)
		{
			return;
		}
		clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref refEntities);
		clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref refEntities2);
		clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref refEntities);
		clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref refEntities2);
		List<buEntity> SortedEntities = new List<buEntity>();
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		SortbuSettings sortbuSettings = new SortbuSettings();
		sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
		sortbuSettings.Option.Resolution = 0.02;
		clsInit.cVector5.SortEntitiesByRefPoint(refEntities[0].Vertices[0], ref refEntities, sortbuSettings, ref SortedEntities);
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		if (SplitedEntitites.Count > 0)
		{
			List<List<buEntity>> list = new List<List<buEntity>>();
			List<List<buEntity>> list2 = new List<List<buEntity>>();
			Point3D MinPoint = new Point3D();
			Point3D MaxPoint = new Point3D();
			Point3D MinPoint2 = new Point3D();
			Point3D MaxPoint2 = new Point3D();
			Point3D MidPoint = new Point3D();
			for (int l = 0; l <= SplitedEntitites.Count - 1; l++)
			{
				clsInit.cVector5.BoxSizeCalculate(SplitedEntitites[l], ref MinPoint2, ref MidPoint, ref MaxPoint2);
				List<Point3D> Points = new List<Point3D>();
				bool flag = false;
				for (int m = 0; m <= SplitedEntitites.Count - 1; m++)
				{
					if (l != m)
					{
						clsInit.cVector5.BoxSizeCalculate(SplitedEntitites[m], ref MinPoint, ref MaxPoint);
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[m], 0.05, ref Points);
						bool flag2 = clsInit.cVector5.isBoxSizeInsideBoxSize(MinPoint, MaxPoint, MinPoint2, MaxPoint2, Plane.XY);
						bool flag3 = clsInit.cVector5.IsPointInsidePolygon(Points, MidPoint, Plane.XY, CheckOver: false);
						if (flag = flag2 && flag3)
						{
							m = SplitedEntitites.Count;
						}
					}
				}
				if (!flag && !clsInit.cVector5.isEntitiesClosed(SplitedEntitites[l]))
				{
					if (SplitedEntitites[l].Count != 1 || !(SplitedEntitites[l][0] is buLinearPath))
					{
						flag = true;
					}
					else
					{
						buEntity refLinearPath = SplitedEntitites[l][0] as buLinearPath;
						if (refLinearPath.Vertices.Count <= 4)
						{
							flag = true;
						}
						else
						{
							int num = 0;
							if (!buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 2]))
							{
								if (!buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 3]))
								{
									if (buCompare5.EQ(refLinearPath.Vertices[0], refLinearPath.Vertices[refLinearPath.Vertices.Count - 4]))
									{
										num = 4;
									}
								}
								else
								{
									num = 3;
								}
							}
							else
							{
								num = 2;
							}
							if (num >= 2 && num <= 4)
							{
								buEntity trimedEntity = null;
								clsInit.cVector5.MakeIsClosedEntityWithTrim(num, ref refLinearPath, ref trimedEntity);
								SplitedEntitites[l][0] = refLinearPath;
								if (trimedEntity != null)
								{
									List<buEntity> list3 = new List<buEntity>();
									list3.Add(trimedEntity);
									list2.Add(list3);
								}
							}
						}
					}
				}
				if (flag)
				{
					List<Point3D> Points2 = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[l], 0.05, ref Points2);
					if (Points2.Count >= 2)
					{
						list2.Add(SplitedEntitites[l]);
					}
				}
				else
				{
					List<Point3D> Points3 = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[l], 0.05, ref Points3);
					if (Points3.Count >= 3)
					{
						list.Add(SplitedEntitites[l]);
					}
				}
			}
			SplitedEntitites.Clear();
			SplitedEntitites = new List<List<buEntity>>();
			buEntity.Copy(list, ref SplitedEntitites);
			for (int n = 0; n <= list2.Count - 1; n++)
			{
				for (int num2 = 0; num2 <= list2[n].Count - 1; num2++)
				{
					refEntities2.Add(buEntity.Copy(list2[n][num2]));
				}
			}
		}
		if (SplitedEntitites.Count <= 0)
		{
			return;
		}
		List<buEntity> list4 = new List<buEntity>();
		List<buEntity> list5 = new List<buEntity>();
		for (int num3 = 0; num3 <= refEntities2.Count - 1; num3++)
		{
			buEntity refEntities3 = refEntities2[num3];
			if (!((refEntities2[num3] is buText) | (refEntities2[num3] is buMultilineText)))
			{
				clsInit.cVector5.Move(0.0, 0.0, 0.0 - refEntities3.BoxMin.Z, ref refEntities3);
				list5.Add(refEntities3);
			}
			else
			{
				clsInit.cVector5.Move(0.0, 0.0, 0.0 - refEntities3.BoxMin.Z, ref refEntities3);
				list4.Add(refEntities3);
			}
		}
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = true;
		}
		CalculationEventArg calculationEventArg = new CalculationEventArg();
		for (int num4 = 0; num4 <= SplitedEntitites.Count - 1; num4++)
		{
			if (clsInit.cVector5.isEntitiesClosed(SplitedEntitites[num4]))
			{
				for (int num5 = 0; num5 <= SplitedEntitites[num4].Count - 1; num5++)
				{
					if (SplitedEntitites[num4][num5].Info.OriginalEntityIndex >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[SplitedEntitites[num4][num5].Info.OriginalEntityIndex].Selected = true;
					}
				}
				buEntitiesGroup buEntitiesGroup2 = new buEntitiesGroup();
				buEntitiesGroup2.Text = new buEntityList();
				buEntitiesGroup2.Outside.Points = new List<Point3D>();
				buEntity.Copy(SplitedEntitites[num4], ref buEntitiesGroup2.Outside.Entities);
				clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntitiesGroup2.Outside.Entities, ref buEntitiesGroup2.Outside.Points);
				List<Point3D> Vertice = buEntitiesGroup2.Outside.Points.ToList();
				if (ParNest.PartSettings.MultiplePArtAddOusideFilterLength > 0.0)
				{
					clsInit.cVector5.RemoveSmallLengthFromPoints(ParNest.PartSettings.MultiplePArtAddOusideFilterLength, ref Vertice);
				}
				for (int num6 = list4.Count - 1; num6 >= 0; num6--)
				{
					bool flag4;
					if (!(flag4 = clsInit.cVector5.IsPointInsidePolygon(buEntitiesGroup2.Outside.Points, list4[num6].BoxMin)))
					{
						if (!(flag4 = clsInit.cVector5.IsPointInsidePolygon(buEntitiesGroup2.Outside.Points, list4[num6].BoxMax)))
						{
							Point3D refPoint = clsInit.cVector5.MiddlePointOfLine(list4[num6].BoxMin, list4[num6].BoxMax);
							flag4 = clsInit.cVector5.IsPointInsidePolygon(buEntitiesGroup2.Outside.Points, refPoint);
						}
						else
						{
							buEntitiesGroup2.Text.Entities.Add(list4[num6]);
						}
					}
					else
					{
						buEntitiesGroup2.Text.Entities.Add(list4[num6]);
					}
					if (!flag4)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list4[num6].Info.OriginalEntityIndex].Selected = false;
					}
					else
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list4[num6].Info.OriginalEntityIndex].Selected = true;
						list4.RemoveAt(num6);
					}
				}
				List<buEntity> BaseRefEntities = new List<buEntity>();
				for (int num7 = list5.Count - 1; num7 >= 0; num7--)
				{
					bool flag5 = false;
					int num8 = list5[num7].Vertices.Count / 10;
					if (num8 <= 0)
					{
						num8 = 1;
					}
					for (int num9 = 0; num9 <= list5[num7].Vertices.Count - 1; num9 += num8)
					{
						if (flag5 = clsInit.cVector5.IsPointInsidePolygon(Vertice, list5[num7].Vertices[num9]))
						{
							num9 = list5[num7].Vertices.Count;
						}
					}
					if (!flag5)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list5[num7].Info.OriginalEntityIndex].Selected = false;
					}
					else
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[list5[num7].Info.OriginalEntityIndex].Selected = true;
						BaseRefEntities.Add(list5[num7]);
						list5.RemoveAt(num7);
					}
				}
				if (BaseRefEntities.Count > 0)
				{
					List<buEntity> SortedEntities2 = new List<buEntity>();
					List<List<buEntity>> SplitedEntitites2 = new List<List<buEntity>>();
					sortbuSettings = new SortbuSettings();
					sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
					clsInit.cVector5.SortEntitiesByRefPoint(BaseRefEntities[0].Vertices[0], ref BaseRefEntities, sortbuSettings, ref SortedEntities2);
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities2, ref SplitedEntitites2);
					if (SplitedEntitites2.Count > 0)
					{
						for (int num10 = 0; num10 <= SplitedEntitites2.Count - 1; num10++)
						{
							if (!clsInit.cVector5.isEntitiesClosed(SplitedEntitites2[num10]))
							{
								if (buEntitiesGroup2.OpenEntities == null)
								{
									buEntitiesGroup2.OpenEntities = new List<buEntityList>();
								}
								buEntityList buEntityList2 = new buEntityList();
								buEntity.Copy(SplitedEntitites2[num10], ref buEntityList2.Entities);
								if (buEntityList2.Entities.Count > 0)
								{
									buEntityList2.Points = new List<Point3D>();
									clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityList2.Entities, ref buEntityList2.Points);
								}
								buEntitiesGroup2.OpenEntities.Add(buEntityList2);
							}
							else
							{
								if (buEntitiesGroup2.Inside == null)
								{
									buEntitiesGroup2.Inside = new List<buEntityList>();
								}
								buEntityList buEntityList3 = new buEntityList();
								buEntity.Copy(SplitedEntitites2[num10], ref buEntityList3.Entities);
								if (buEntityList3.Entities.Count > 0)
								{
									buEntityList3.Points = new List<Point3D>();
									clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntityList3.Entities, ref buEntityList3.Points);
								}
								buEntitiesGroup2.Inside.Add(buEntityList3);
							}
						}
					}
				}
				AddPartFromEntities(buEntitiesGroup2, isSheet: false, ShowDialog: false);
			}
			if (num4 % 20 == 0)
			{
				Application.DoEvents();
			}
			calculationEventArg.Job = buLangTranslate.preDef.Part + " " + buLangTranslate.preDef.Added + " " + (num4 + 1) + " / " + SplitedEntitites.Count;
			double num11 = (double)(num4 + 1) / (double)SplitedEntitites.Count;
			if (!(num11 <= 0.25))
			{
				if (!(num11 > 0.25 && num11 <= 0.5))
				{
					if (!(num11 > 0.5 && num11 <= 0.75))
					{
						calculationEventArg.OverallProgressPercentage = 100.0;
					}
					else
					{
						calculationEventArg.OverallProgressPercentage = 50.0;
					}
				}
				else
				{
					calculationEventArg.OverallProgressPercentage = 50.0;
				}
			}
			else
			{
				calculationEventArg.OverallProgressPercentage = 25.0;
			}
			double num12 = (double)(num4 + 1) / (double)SplitedEntitites.Count * 100.0;
			if (num12 > 100.0)
			{
				num12 = 100.0;
			}
			calculationEventArg.ActiveProgressPercentage = num12;
			clsInit.appCommand.CalculationInProgressCmd(calculationEventArg);
		}
		if (ParNest.AddPart.DeleteSelectedAuxEntities | ParNest.AddPart.DeleteSelectedEntities)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		if (clsItem.FrmProgress != null)
		{
			clsItem.FrmProgress.Visible = false;
		}
		_ = Environment.TickCount - tickCount;
		clsFiles.SaveParameter();
		SaveNestingFile();
		GC.Collect();
	}

	public void doFindAndFixParts()
	{
		AnalyseEntities.Clear();
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (!(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName == ccVars.Pages[ccVars.PageIndex].LayerName))
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName].Visible & ((ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve) | (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is Text)))
				{
					buEntity copiedEntity = null;
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity);
					copiedEntity.Info.OriginalEntityIndex = i;
				}
			}
			else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve)
			{
				buEntity copiedEntity2 = null;
				Entity copiedEntity3 = null;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity2);
				copiedEntity2.Info.OriginalEntityIndex = i;
				buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i], ref copiedEntity3);
				CustomData customData = new CustomData();
				customData.OriginalEntityIndex = i;
				copiedEntity3.EntityData = customData;
				AnalyseEntities.Add(copiedEntity3);
			}
		}
		AnalyseEntitiesResult Result = new AnalyseEntitiesResult();
		clsInit.cVector5.AnalyseEntities(AnalyseEntities, ParNest.AnalyseSettings, ref Result);
		if (!Result.isError)
		{
			buString5.MessageBoxInfo(AppLanguage.CadCamMessages[89]);
			return;
		}
		for (int j = 0; j <= AnalyseEntities.Count - 1; j++)
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].Selected = AnalyseEntities[j].Selected;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		clsItem.FrmDrawingAnalayseResult.TopMost = true;
		clsItem.FrmDrawingAnalayseResult.PropertiesForm.TopMost = true;
		clsItem.FrmDrawingAnalayseResult.Result = new AnalyseEntitiesResult(Result);
		clsItem.FrmDrawingAnalayseResult.Init();
		clsItem.FrmDrawingAnalayseResult.Show();
	}

	public void doAnalyzeFindZoom(object data1, object data2)
	{
		if (data1 == null || data2 == null || !(data2 is AnalyseEntitiesResultError))
		{
			return;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		AnalyseEntitiesResultError analyseEntitiesResultError = data2 as AnalyseEntitiesResultError;
		if ((analyseEntitiesResultError.IndexEntity >= 0) & (analyseEntitiesResultError.IndexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[analyseEntitiesResultError.IndexEntity].Selected = true;
		}
		if (analyseEntitiesResultError.IndexEntityList.Count > 0)
		{
			for (int i = 0; i <= analyseEntitiesResultError.IndexEntityList.Count - 1; i++)
			{
				int num = analyseEntitiesResultError.IndexEntityList[i];
				if ((num >= 0) & (num <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num].Selected = true;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(selectedOnly: true);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doAnalyzeResult(object data1, object data2)
	{
		if (data1 == null || data2 == null || !(data2 is AnalyseEntitiesResultError))
		{
			return;
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.ClearSelection();
		AnalyseEntitiesResultError analyseEntitiesResultError = data2 as AnalyseEntitiesResultError;
		if ((analyseEntitiesResultError.IndexEntity >= 0) & (analyseEntitiesResultError.IndexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
		{
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[analyseEntitiesResultError.IndexEntity].Selected = true;
		}
		if (analyseEntitiesResultError.IndexEntityList.Count > 0)
		{
			for (int i = 0; i <= analyseEntitiesResultError.IndexEntityList.Count - 1; i++)
			{
				int num = analyseEntitiesResultError.IndexEntityList[i];
				if ((num >= 0) & (num <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
				{
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[num].Selected = true;
				}
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doAnalyzeFix(object data1, object data2)
	{
		try
		{
			for (int i = 0; i <= AnalyseEntities.Count - 1; i++)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = false;
			}
			if (clsItem.FrmDrawingAnalayseResult.Result.ErrorList.Count > 0)
			{
				clsInit.appCommand.undoBuffer();
			}
			for (int j = 0; j <= clsItem.FrmDrawingAnalayseResult.Result.ErrorList.Count - 1; j++)
			{
				AnalyseEntitiesResultError analyseEntitiesResultError = clsItem.FrmDrawingAnalayseResult.Result.ErrorList[j];
				int indexEntity = analyseEntitiesResultError.IndexEntity;
				if ((indexEntity >= 0) & (indexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
				{
					if ((analyseEntitiesResultError.Action == AnalyseEntitiesActionType.Delete) & analyseEntitiesResultError.Enable)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity].Selected = true;
					}
					if (!((analyseEntitiesResultError.Action == AnalyseEntitiesActionType.Fix) & analyseEntitiesResultError.Enable))
					{
					}
				}
				if (analyseEntitiesResultError.IndexEntityList.Count <= 0)
				{
					continue;
				}
				for (int k = 0; k <= analyseEntitiesResultError.IndexEntityList.Count - 1; k++)
				{
					indexEntity = analyseEntitiesResultError.IndexEntityList[k];
					if (!((indexEntity >= 0) & (indexEntity <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1)))
					{
						continue;
					}
					if ((analyseEntitiesResultError.Action == AnalyseEntitiesActionType.Delete) & analyseEntitiesResultError.Enable)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity].Selected = true;
					}
					if (!((analyseEntitiesResultError.Action == AnalyseEntitiesActionType.Fix) & analyseEntitiesResultError.Enable) || analyseEntitiesResultError.ErrorType != AnalyseEntitiesResultErrorType.NotClosedEntities)
					{
						continue;
					}
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[indexEntity];
					if (entity is LinearPath)
					{
						Line line = new Line(buVector5.ToPoint3D(entity.Vertices[1]), buVector5.ToPoint3D(entity.Vertices[0]));
						Line line2 = new Line(buVector5.ToPoint3D(entity.Vertices[entity.Vertices.Length - 1]), buVector5.ToPoint3D(entity.Vertices[entity.Vertices.Length - 2]));
						line.StartPoint -= line.StartTangent * 100.0;
						line.EndPoint += line.EndTangent * 100.0;
						line.Regen(0.1);
						line2.StartPoint -= line2.StartTangent * 100.0;
						line2.EndPoint += line2.EndTangent * 100.0;
						line2.Regen(0.1);
						entity.Selected = false;
						Point3D[] array = Utility.Intersection(line, line2, 100.0, computeParameters: false);
						if (array != null && array.Length != 0)
						{
							entity.Vertices[0] = buVector5.ToPoint3D(array[0]);
							entity.Vertices[entity.Vertices.Length - 1] = buVector5.ToPoint3D(array[0]);
							entity.Regen(0.01);
						}
					}
				}
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.RegenAllCurved();
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			AnalyseEntities.Clear();
			GC.Collect();
		}
		catch (Exception)
		{
		}
	}

	public void doAnalyzeCancel(object data1, object data2)
	{
		AnalyseEntities.Clear();
		GC.Collect();
	}

	public bool doAddShapePartAndSheet(Point3D RefPnt, bool isSheet, List<Entity> RefEntities, List<buEntity> RefBuEntities = null)
	{
		buEntitiesGroup buEntitiesGroup2 = new buEntitiesGroup();
		List<buEntity> list = new List<buEntity>();
		bool flag = false;
		SortbuSettings sortbuSettings = new SortbuSettings();
		SortbuResult Result = new SortbuResult();
		SelectionOption selectionOption = new SelectionOption();
		selectionOption.CircleToArc = true;
		selectionOption.SplitArcIfGreatThen180 = true;
		selectionOption.Point = false;
		selectionOption.Text = false;
		SelectionEntityTypes Entities = new SelectionEntityTypes();
		if (RefEntities.Count != 0)
		{
			clsInit.cVector5.EntitiesToEntitiesGroup(ref Entities, RefEntities);
			clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
		}
		else
		{
			clsInit.appCommand.SelectionToEntities(ref Entities);
			clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
		}
		if (RefBuEntities != null && RefBuEntities.Count > 0)
		{
			clsInit.cVector5.EntitiesToEntitiesGroup(ref Entities, RefBuEntities);
			clsInit.cVector5.EntitiesPlaneCheck(ref Entities.entitiesCurve);
		}
		if (Entities.entitiesCurve.Count > 0)
		{
			string LayerName = "";
			List<buEntity> LayerEntities = new List<buEntity>();
			List<buEntity> copiedEntities = new List<buEntity>();
			if (isSheet)
			{
				List<buEntitiesGroup> Groups = new List<buEntitiesGroup>();
				clsInit.cVector5.FindEntitiesGroupFromEntities(Entities.entitiesCurve[0].StartPoint, Entities.entitiesCurve, Plane.XY, ref Groups, 0.05, SortingIntersectionRulesType.LowerIndex, SortingNextGroupFindRulesType.ClosestLength, ParNest.PartSettings.CheckLinearPathToBackwardToFindClosed);
				if (Groups.Count <= 0)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable + " - " + buLangTranslate.preDef.Sheet);
					return false;
				}
				if (!clsInit.cVector5.isEntitiesClosed(Groups[0].Outside.Entities))
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.EntitiesAreNotClosedPath + " - " + buLangTranslate.preDef.Sheet);
					return false;
				}
				if (Groups[0].Outside.Entities.Count <= 0)
				{
					buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable + " - " + buLangTranslate.preDef.Sheet);
					return false;
				}
				buEntitiesGroup2 = new buEntitiesGroup(Groups[0]);
				clsInit.cVector5.SetColorEntity(ParNest.Draw.SheetEntityColor, ref buEntitiesGroup2.Outside.Entities);
				buEntitiesGroup2.Outside.Points = new List<Point3D>();
				clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntitiesGroup2.Outside.Entities, ref buEntitiesGroup2.Outside.Points);
				for (int i = 0; i <= buEntitiesGroup2.Inside.Count - 1; i++)
				{
					clsInit.cVector5.SetColorEntity(ParNest.Draw.SheetInnerColor, ref buEntitiesGroup2.Inside[i].Entities);
					buEntitiesGroup2.Inside[i].Points = new List<Point3D>();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntitiesGroup2.Inside[i].Entities, ref buEntitiesGroup2.Inside[i].Points);
				}
				if (buEntitiesGroup2.OpenEntities != null)
				{
					for (int j = 0; j <= buEntitiesGroup2.OpenEntities.Count - 1; j++)
					{
						clsInit.cVector5.SetColorEntity(ParNest.Draw.SheetInnerColor, ref buEntitiesGroup2.OpenEntities[j].Entities);
						buEntitiesGroup2.OpenEntities[j].Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntitiesGroup2.OpenEntities[j].Entities, ref buEntitiesGroup2.OpenEntities[j].Points);
					}
				}
			}
			else
			{
				if (ParNest.PartSettings.PartMainAddType != nestingPartMainDrawAddModes.Color)
				{
					if (ParNest.PartSettings.PartMainAddType != nestingPartMainDrawAddModes.Layer)
					{
						buEntity.Copy(Entities.entitiesCurve, ref LayerEntities);
					}
					else
					{
						clsInit.cVector5.GetEntitiesByLayerName(ref Entities.entitiesCurve, ccVars.Pages[ccVars.PageIndex].LayerName, ref LayerEntities, SetSelected: true);
					}
				}
				else
				{
					clsInit.appCommand.GetLayerNameFromColor(ParNest.AddPart.SelectionColor, ref LayerName);
					if (LayerName.Length > 0)
					{
						clsInit.cVector5.GetEntitiesByLayerName(ref Entities.entitiesCurve, LayerName, ref LayerEntities, SetSelected: true);
					}
				}
				clsInit.cVector5.DeleteSelectedEntities(ref Entities.entitiesCurve);
				buEntity.Copy(Entities.entitiesCurve, ref copiedEntities);
			}
			if (!isSheet)
			{
				clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref LayerEntities);
				clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref copiedEntities);
				clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref LayerEntities);
				clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref copiedEntities);
				if (Entities.entitiesText != null && Entities.entitiesText.Count > 0)
				{
					clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref Entities.entitiesText);
					if (Entities.entitiesText.Count > 0)
					{
						for (int k = 0; k <= Entities.entitiesText.Count - 1; k++)
						{
							if (Entities.entitiesText[k].BoxMin == null)
							{
								Entities.entitiesText[k].Regen();
							}
							buEntity refEntities = Entities.entitiesText[k];
							clsInit.cVector5.Move(0.0, 0.0, 0.0 - Entities.entitiesText[k].BoxMin.Z, ref refEntities);
						}
					}
					clsInit.appCommand.SetTextEntityStyleAsDefault(ref Entities.entitiesText);
					buEntitiesGroup2.Text = new buEntityList();
					buEntitiesGroup2.Text.GroupType = entityGroupType.Text;
					buEntity.Copy(Entities.entitiesText, ref buEntitiesGroup2.Text.Entities);
					clsInit.appCommand.SetColorEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ref buEntitiesGroup2.Text.Entities);
					clsInit.appCommand.SetToolNameEntityFromLayer(ccVars.Pages[ccVars.PageIndex].Layers, ccVars.Tools[0].Tools, ref buEntitiesGroup2.Text.Entities);
				}
				if (LayerEntities.Count > 0)
				{
					for (int l = 0; l <= LayerEntities.Count - 1; l++)
					{
						if (LayerEntities[l].BoxMin == null)
						{
							LayerEntities[l].Regen();
						}
						buEntity refEntities2 = LayerEntities[l];
						clsInit.cVector5.Move(0.0, 0.0, 0.0 - LayerEntities[l].BoxMin.Z, ref refEntities2);
					}
				}
				if (copiedEntities.Count > 0)
				{
					for (int m = 0; m <= copiedEntities.Count - 1; m++)
					{
						if (copiedEntities[m].BoxMin == null)
						{
							copiedEntities[m].Regen();
						}
						buEntity refEntities3 = copiedEntities[m];
						clsInit.cVector5.Move(0.0, 0.0, 0.0 - copiedEntities[m].BoxMin.Z, ref refEntities3);
					}
				}
				List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
				if (LayerEntities.Count > 0)
				{
					SortbuSettings sortbuSettings2 = new SortbuSettings();
					SortbuResult Result2 = new SortbuResult();
					sortbuSettings2.Option.IntersectionRules = SortingIntersectionRulesType.LowerIndex;
					sortbuSettings2.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
					sortbuSettings2.Option.Resolution = 0.05;
					List<buEntity> SortedEntities = new List<buEntity>();
					clsInit.cVector5.SortEntitiesByRefPoint(LayerEntities[0].StartPoint, ref LayerEntities, sortbuSettings2, ref SortedEntities, ref Result2);
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
				}
				if (SplitedEntitites.Count != 1)
				{
					if (SplitedEntitites.Count > 1)
					{
						List<buEntitiesGroup> Groups2 = new List<buEntitiesGroup>();
						clsInit.cVector5.FindEntitiesGroupFromEntities(LayerEntities[0].StartPoint, LayerEntities, Plane.XY, ref Groups2);
						if (Groups2.Count > 0)
						{
							buEntitiesGroup2 = new buEntitiesGroup(Groups2[0]);
						}
					}
				}
				else
				{
					sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.NoNextGroup;
					sortbuSettings.Option.WhenFoundClosedCurveThenFinish = true;
					for (int n = 0; n <= LayerEntities.Count - 1; n++)
					{
						list = new List<buEntity>();
						clsInit.cVector5.SortEntitiesByRefPoint(LayerEntities[n].StartPoint, ref LayerEntities, sortbuSettings, ref list, ref Result);
						if (clsInit.cVector5.isEntitiesClosed(list))
						{
							buEntity.Copy(list, ref buEntitiesGroup2.Outside.Entities);
							if (clsInit.cVector5.EntitiesClockDirection(buEntitiesGroup2.Outside.Entities) == ClockDirectionType.CCW)
							{
								clsInit.cVector5.ChangeEntitiesDirection(ref buEntitiesGroup2.Outside.Entities);
							}
							buEntitiesGroup2.Outside.Points = new List<Point3D>();
							clsInit.cVector5.EntitiesToPointsWithCamDirection(buEntitiesGroup2.Outside.Entities, ref buEntitiesGroup2.Outside.Points);
							buEntitiesGroup2.Outside.Points[0].X = Math.Round(buEntitiesGroup2.Outside.Points[0].X);
							buEntitiesGroup2.Outside.Points[0].Y = Math.Round(buEntitiesGroup2.Outside.Points[0].Y);
							buEntitiesGroup2.Outside.Points[0].Z = Math.Round(buEntitiesGroup2.Outside.Points[0].Z);
							buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].X = Math.Round(buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].X);
							buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].Y = Math.Round(buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].Y);
							buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].Z = Math.Round(buEntitiesGroup2.Outside.Points[buEntitiesGroup2.Outside.Points.Count - 1].Z);
							buEntitiesGroup2.Outside.GroupType = entityGroupType.Cutting;
							break;
						}
					}
					if (buEntitiesGroup2.Outside.Entities.Count == 0)
					{
						buString5.MessageBoxWarning(buLangTranslate.preSentencesNesting.NoSuitableEntitiesAvailable + " - " + buLangTranslate.preDef.Part);
						return false;
					}
					if ((buEntitiesGroup2.Outside.Entities.Count > 0) & (copiedEntities.Count > 0))
					{
						sortbuSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
						sortbuSettings.Option.WhenFoundClosedCurveThenFinish = false;
						list = new List<buEntity>();
						clsInit.cVector5.SortEntitiesByRefPoint(copiedEntities[0].StartPoint, ref copiedEntities, sortbuSettings, ref list, ref Result);
						if (list.Count > 0)
						{
							List<List<buEntity>> SplitedEntitites2 = new List<List<buEntity>>();
							clsInit.cVector5.EntitiesSplitByUpperLine(list, ref SplitedEntitites2);
							for (int num = 0; num <= SplitedEntitites2.Count - 1; num++)
							{
								if (!clsInit.cVector5.isEntitiesClosed(SplitedEntitites2[num]))
								{
									buEntityList buEntityList2 = new buEntityList(SplitedEntitites2[num]);
									clsInit.appCommand.GetLayerToolFromName(SplitedEntitites2[num][0].LayerName, ref buEntityList2.Tool);
									clsInit.cVector5.LayerGetByName(ccVars.Pages[ccVars.PageIndex].Layers, SplitedEntitites2[num][0].LayerName, ref buEntityList2.Layer);
									buEntityList2.Points = new List<Point3D>();
									clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites2[num], ref buEntityList2.Points);
									buEntityList2.GroupType = entityGroupType.InsideOpen;
									if (buEntitiesGroup2.OpenEntities == null)
									{
										buEntitiesGroup2.OpenEntities = new List<buEntityList>();
									}
									buEntitiesGroup2.OpenEntities.Add(buEntityList2);
									continue;
								}
								buEntityList buEntityList3 = new buEntityList(SplitedEntitites2[num]);
								if (clsInit.cVector5.EntitiesClockDirection(SplitedEntitites2[num]) == ClockDirectionType.CCW)
								{
									clsInit.cVector5.ChangeEntitiesDirection(ref buEntityList3.Entities);
								}
								clsInit.appCommand.GetLayerToolFromName(SplitedEntitites2[num][0].LayerName, ref buEntityList3.Tool);
								clsInit.cVector5.LayerGetByName(ccVars.Pages[ccVars.PageIndex].Layers, SplitedEntitites2[num][0].LayerName, ref buEntityList3.Layer);
								buEntityList3.Points = new List<Point3D>();
								clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites2[num], ref buEntityList3.Points);
								buEntityList3.Points[0].X = Math.Round(buEntityList3.Points[0].X);
								buEntityList3.Points[0].Y = Math.Round(buEntityList3.Points[0].Y);
								buEntityList3.Points[0].Z = Math.Round(buEntityList3.Points[0].Z);
								buEntityList3.Points[buEntityList3.Points.Count - 1].X = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].X);
								buEntityList3.Points[buEntityList3.Points.Count - 1].Y = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].Y);
								buEntityList3.Points[buEntityList3.Points.Count - 1].Z = Math.Round(buEntityList3.Points[buEntityList3.Points.Count - 1].Z);
								buEntityList3.GroupType = entityGroupType.InsideClosed;
								buEntitiesGroup2.Inside.Add(buEntityList3);
							}
						}
					}
				}
			}
			if (buEntitiesGroup2.Outside.Entities.Count > 0)
			{
				flag = AddPartFromEntities(buEntitiesGroup2, isSheet);
				if ((ParNest.AddPart.DeleteSelectedAuxEntities | ParNest.AddPart.DeleteSelectedEntities) && flag)
				{
					clsInit.appCommand.Delete(applyReset: false);
					clsInit.appCommand.ClearEntitiesSelection();
				}
			}
		}
		return flag;
	}

	public bool doAddShapePart(List<buEntitiesGroup> EntGroup)
	{
		bool result = false;
		for (int i = 0; i <= EntGroup.Count - 1; i++)
		{
			if (EntGroup[i].Outside.Entities.Count > 0)
			{
				result = AddPartFromEntities(EntGroup[i], isSheet: false);
			}
		}
		return result;
	}

	public bool doAddShapeSheet(List<buEntitiesGroup> EntGroup)
	{
		bool result = false;
		for (int i = 0; i <= EntGroup.Count - 1; i++)
		{
			if (EntGroup[i].Outside.Entities.Count > 0)
			{
				result = AddPartFromEntities(EntGroup[i], isSheet: true);
			}
		}
		return result;
	}

	public bool doAddShapeSheet(buEntitiesGroup EntGroup)
	{
		bool result = false;
		if (EntGroup.Outside.Entities.Count > 0)
		{
			result = AddPartFromEntities(EntGroup, isSheet: true);
		}
		return result;
	}

	public void doAddToTempCalculatedNesting(buNestedResult Result, bool isLast)
	{
		try
		{
			buNestedResult buNestedResult2 = new buNestedResult(Result);
			ccVars.UndoDont = true;
			buNestedResult2.Parameters = new buNestingVar(ParNest);
			if (clsItem.FrmNestOnlineCalc == null)
			{
				return;
			}
			int num = 0;
			BestNestCount = 1;
			TreeNode treeNode = new TreeNode();
			treeNode.Tag = (clsPowerNest.storedNestedResult.Count - 1).ToString();
			treeNode.Text = "Temp_" + clsPowerNest.storedNestedResult.Count + " = " + buNestedResult2.NestedResultSheets.Count + " " + AppLanguage.CadCamDynamic[33];
			if (buNestedResult2.NotNestedAll)
			{
				treeNode.Text = treeNode.Text + " - " + AppLanguage.CadCamDynamic[94] + " - [" + buNestedResult2.NestedTotalPartCount + " / " + buNestedResult2.OrderedTotalPartCount + "]";
			}
			for (int i = 0; i <= buNestedResult2.NestedResultSheets.Count - 1; i++)
			{
				num += buNestedResult2.NestedResultSheets[i].Parts.Count;
				TreeNode treeNode2 = new TreeNode();
				treeNode2.Tag = BestNestCount - 1 + "-" + i;
				treeNode2.Text = i + 1 + " - " + AppLanguage.CadCamDynamic[33] + " - ( " + buNestedResult2.NestedResultSheets[i].MaterialWidth + " , " + buNestedResult2.NestedResultSheets[i].MaterialHeight + " ) - " + buNestedResult2.NestedResultSheets[i].Parts.Count + " " + AppLanguage.CadCamDynamic[34];
				treeNode2.ForeColor = Color.Black;
				for (int j = 0; j <= buNestedResult2.NestedResultSheets[i].Parts.Count - 1; j++)
				{
					TreeNode treeNode3 = new TreeNode();
					treeNode3.Tag = BestNestCount - 1 + "-" + i + "-" + j;
					treeNode3.Text = j + 1 + " - " + AppLanguage.CadCamDynamic[34] + " - ( " + buNestedResult2.NestedResultSheets[i].Parts[j].Width + " , " + buNestedResult2.NestedResultSheets[i].Parts[j].Height + " ) - R: " + buNestedResult2.NestedResultSheets[i].Parts[j].RotateValue.ToString("f3");
					if (buNestedResult2.NestedResultSheets[i].Parts[j].Name.Trim().Length > 0)
					{
						treeNode3.Text = treeNode3.Text + " - " + buNestedResult2.NestedResultSheets[i].Parts[j].Name.Trim();
					}
					treeNode3.ForeColor = Color.Black;
					treeNode2.Nodes.Add(treeNode3);
				}
				if (buNestedResult2.NestedResultSheets[i].WarningText.Length > 0)
				{
					treeNode2.Text += buNestedResult2.NestedResultSheets[i].WarningText;
					treeNode2.ForeColor = Color.Red;
					treeNode.ForeColor = Color.Red;
					treeNode.Text += buNestedResult2.NestedResultSheets[i].WarningText;
				}
				if (buNestedResult2.NotNestedAll)
				{
					treeNode.ForeColor = Color.Red;
					treeNode2.ForeColor = Color.Red;
					treeNode2.Text = treeNode2.Text + " - " + AppLanguage.CadCamDynamic[94];
				}
				treeNode.Nodes.Add(treeNode2);
			}
			if (!buNestedResult2.NotNestedAll)
			{
				treeNode.Text = treeNode.Text + " - " + num + " " + AppLanguage.CadCamDynamic[34];
			}
			clsItem.FrmNestOnlineCalc.treeView1.Nodes.Add(treeNode);
			if (ParNest.ProgramSettings.CalculationShowFormat == nestCalculationShowFormat.PastalAsSingleSheet)
			{
				treeNode.Text = treeNode.Text + " - X " + AppLanguage.CadCamDynamic[46] + " =  " + buNestedResult2.MaxXPosition.ToString("f3") + " - % " + buNestedResult2.NestedResultSheets[0].UsingPersentageFromMaxX.ToString("f2");
			}
			if (ParNest.Settings.ShowResultPreviewAfterFinish && isLast)
			{
				cmdPreviewPressed(Result);
			}
		}
		catch (Exception)
		{
		}
	}

	public void doAddToAllNestedResult(buNestedResult Result)
	{
		buNestingCalc.NestedAllResults.Add(Result);
		for (int i = 0; i <= Result.NestedResultSheets.Count - 1; i++)
		{
			clsInit.cNesting.IncreaseSheetUsedCountByID(ref Sheets, Result.NestedResultSheets[i].MaterialID);
			for (int j = 0; j <= Result.NestedResultSheets[i].Parts.Count - 1; j++)
			{
				clsInit.cNesting.IncreasePartUsedCountByID(ref Parts, Result.NestedResultSheets[i].Parts[j].ID);
			}
		}
	}

	public void doDrawAllNesting(buNestedResult Result, int SheetIndex, int PartIndex, Design Viewport, bool isSolid, bool isPreview)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i];
			for (int j = 0; j <= Viewport.Layers.Count - 1; j++)
			{
				if (!(layer.Name != Viewport.Layers[j].Name))
				{
					if (layer.Color != Viewport.Layers[j].Color)
					{
						Viewport.Layers[j].Color = layer.Color;
					}
				}
				else
				{
					Viewport.Layers.AddOrReplace(new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, layer.Visible));
				}
			}
		}
		int num = 0;
		int num2 = Result.NestedResultSheets.Count - 1;
		if (SheetIndex >= 0)
		{
			num = SheetIndex;
			num2 = SheetIndex;
		}
		Point3D MinPoint = new Point3D();
		Point3D point3D = new Point3D();
		Point3D MaxPoint = new Point3D();
		if (Result.NestedResultSheets.Count > 0)
		{
			if (ParNest.ResultSettings.DrawAddClearAll | !ParNest.ResultSettings.DrawAddToEnd)
			{
				for (int k = 0; k <= Viewport.Entities.Count - 1; k++)
				{
					if (Viewport.Entities[k].EntityData != null && Viewport.Entities[k].EntityData is CustomData && ((CustomData)Viewport.Entities[k].EntityData).typeDefination == entityTypeDefination.Nesting)
					{
						Viewport.Entities[k].Selected = true;
					}
				}
				Viewport.Entities.DeleteSelected();
				if (ParNest.ResultSettings.DrawAddToEnd)
				{
					Viewport.Entities.RegenAllCurved();
					Viewport.Invalidate();
				}
			}
			double num3 = 0.0;
			double num4 = 0.0;
			if (ParNest.ResultSettings.DrawAddToEnd)
			{
				Viewport.Entities.RegenAllCurved();
				List<Entity> list = new List<Entity>();
				for (int l = 0; l <= Viewport.Entities.Count - 1; l++)
				{
					if (Viewport.Entities[l] is ICurve)
					{
						list.Add(Viewport.Entities[l]);
					}
				}
				if (list.Count <= 0)
				{
					if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
					{
						num3 = ParNest.ResultSettings.DrawAddToEndOffset;
					}
					if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
					{
						num4 = ParNest.ResultSettings.DrawAddToEndOffset;
					}
				}
				else
				{
					Point3D MinPoint2 = new Point3D();
					Point3D MaxPoint2 = new Point3D();
					clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint2, ref MaxPoint2);
					if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
					{
						num3 = MaxPoint2.X + ParNest.ResultSettings.DrawAddToEndOffset;
					}
					if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
					{
						num4 = MaxPoint2.Y + ParNest.ResultSettings.DrawAddToEndOffset;
					}
				}
			}
			if (ParNest.ResultSettings.DrawAddToEnd)
			{
			}
			if (isPreview)
			{
				num3 = 0.0;
				num4 = 0.0;
			}
			for (int m = num; m <= num2; m++)
			{
				List<Entity> calcEntities = new List<Entity>();
				List<Entity> UselessEntities = new List<Entity>();
				ccVars.UndoDont = true;
				bool flag = true;
				if (ParNest.ResultSettings.DrawSheets && (!ParNest.ResultSettings.DrawSheetOnlyPreview || (isPreview ? true : false)))
				{
					clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[m], ParNest.ResultSettings.DrawPartAsSolid && isSolid, ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities, ref UselessEntities);
					if (calcEntities != null)
					{
						string layerName = varTemps.layerSheet;
						if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, layerName))
						{
							layerName = "Default";
						}
						clsInit.cVector5.BoxSizeCalculate(calcEntities, ref MinPoint, ref MaxPoint);
						for (int n = 0; n <= calcEntities.Count - 1; n++)
						{
							Entity refEntity = calcEntities[n];
							clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity);
							calcEntities[n].Translate(num3, num4, 0.0 - MaxPoint.Z - 0.05);
							calcEntities[n].ColorMethod = colorMethodType.byEntity;
							calcEntities[n].LayerName = layerName;
							if (calcEntities[n] is Mesh && calcEntities[n].Color == Color.Black)
							{
								calcEntities[n].Color = ParNest.Draw.SheetSolidColor;
							}
							Viewport.Entities.Add(calcEntities[n]);
						}
					}
				}
				if (Result.NestedResultSheets[m].RemnantSheets != null && Result.NestedResultSheets[m].RemnantSheets.Count > 0)
				{
					string layerName2 = varTemps.layerSheet;
					if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, layerName2))
					{
						layerName2 = "Default";
					}
					for (int num5 = 0; num5 <= Result.NestedResultSheets[m].RemnantSheets.Count - 1; num5++)
					{
						Rectangle2D rectangle2D = Result.NestedResultSheets[m].RemnantSheets[num5];
						CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(Plane.XY, rectangle2D.StartPoint.X, rectangle2D.StartPoint.Y, rectangle2D.Width, rectangle2D.Height);
						compositeCurve.Translate(num3, num4, 0.25);
						compositeCurve.Color = Color.Red;
						compositeCurve.ColorMethod = colorMethodType.byEntity;
						compositeCurve.LayerName = layerName2;
						compositeCurve.LineWeight = 2f;
						compositeCurve.LineWeightMethod = colorMethodType.byEntity;
						if (ParNest.ResultSettings.DrawPartAsSolid)
						{
							devDept.Eyeshot.Entities.Region region = new devDept.Eyeshot.Entities.Region(compositeCurve);
							Mesh mesh = region.ExtrudeAsMesh(0.1, 0.1, Mesh.natureType.RichSmooth);
							mesh.Color = Color.Red;
							mesh.ColorMethod = colorMethodType.byEntity;
							mesh.LayerName = layerName2;
							Viewport.Entities.Add(mesh);
						}
						else
						{
							Viewport.Entities.Add(compositeCurve);
						}
						Entity refEntity2 = new Text(Plane.XY, buLangTranslate.preDef.Remnant, Result.NestedResultSheets[m].MaterialHeight * 0.05, Text.alignmentType.MiddleCenter);
						refEntity2.Translate(rectangle2D.StartPoint.X + rectangle2D.Width / 2.0 + num3, rectangle2D.StartPoint.Y + rectangle2D.Height / 2.0 + num4, 0.5);
						clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity2);
						Viewport.Entities.Add(refEntity2);
					}
				}
				List<Entity> list2 = new List<Entity>();
				double num6 = 0.0;
				int num7 = 0;
				int num8 = Result.NestedResultSheets[m].Parts.Count - 1;
				if (PartIndex >= 0)
				{
					num7 = PartIndex;
					num8 = PartIndex;
				}
				double num9 = Result.NestedResultSheets[m].MaterialWidth + Result.NestedResultSheets[m].MaterialWidth * 0.1;
				double num10 = Result.NestedResultSheets[m].MaterialHeight / 2.0;
				if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
				{
					num9 = Result.NestedResultSheets[m].MaterialWidth / 3.0;
					num10 = (0.0 - Result.NestedResultSheets[m].MaterialHeight) * 0.1;
					if (num9 > Result.NestedResultSheets[m].SheetMaxXPosition + 20.0)
					{
						num9 = Result.NestedResultSheets[m].SheetMaxXPosition + 20.0;
					}
				}
				string text = "";
				string text2 = "";
				if (ParNest.ResultSettings.ShowSheetPersentageOnDisplay)
				{
					text = text + "%" + Result.NestedResultSheets[m].UsingPersentage.ToString("f3");
					text2 = " - ";
				}
				if (ParNest.ResultSettings.ShowSheetNameOnDisplay)
				{
					if (Result.NestedResultSheets[m].Name.Length > 0)
					{
						text = text + text2 + Result.NestedResultSheets[m].Name;
					}
					text2 = " - ";
				}
				if (ParNest.ResultSettings.ShowSheetSizeOnDisplay)
				{
					text = text + text2 + Result.NestedResultSheets[m].MaterialWidth.ToString("f1") + " X " + Result.NestedResultSheets[m].MaterialHeight.ToString("f1");
				}
				if (text.Length > 0)
				{
					Entity refEntity3 = new Text(Plane.XY, text, Result.NestedResultSheets[m].MaterialHeight * 0.05);
					refEntity3.Translate(num9 + num3, num10 + num4);
					clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity3);
					Viewport.Entities.Add(refEntity3);
				}
				Entity refEntity4 = new Text(Plane.XY, m + 1 + " - " + buLangTranslate.preDef.Sheet, Result.NestedResultSheets[m].MaterialHeight * 0.05);
				if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
				{
					refEntity4.Translate(num9 + num3, num10 + num4 + Result.NestedResultSheets[m].MaterialHeight * 0.05 + 30.0);
				}
				if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
				{
					refEntity4.Translate(num9 + num3, num10 - Result.NestedResultSheets[m].MaterialHeight * 0.05 - 30.0);
				}
				clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity4);
				if (ParNest.ResultSettings.ShowSheetCountOnDisplay)
				{
					Viewport.Entities.Add(refEntity4);
				}
				for (int num11 = num7; num11 <= num8; num11++)
				{
					ccVars.UndoDont = true;
					List<Entity> calcEntities2 = new List<Entity>();
					clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[m].Parts[num11], isSolid & ParNest.ResultSettings.DrawPartAsSolid, ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities2);
					new List<Point3D>();
					double num12 = clsInit.cVector5.PolygonArea(Result.NestedResultSheets[m].Parts[num11].EntitiesGroup.Outside.Points, Plane.XY);
					num6 += num12;
					for (int num13 = 0; num13 <= calcEntities2.Count - 1; num13++)
					{
						double dz = 0.0;
						if (((calcEntities2[num13].GetType() != typeof(Brep)) & (calcEntities2[num13].GetType() != typeof(Mesh))) && ParNest.ResultSettings.DrawPartAsSolid)
						{
							dz = 0.25;
						}
						Entity refEntity5 = calcEntities2[num13];
						refEntity5.Translate(num3, num4, dz);
						refEntity5.ColorMethod = colorMethodType.byEntity;
						if ((refEntity5.Color.A == byte.MaxValue) & (refEntity5.Color.R == byte.MaxValue) & (refEntity5.Color.G == byte.MaxValue) & (refEntity5.Color.B == byte.MaxValue))
						{
							refEntity5.Color = Color.Black;
						}
						string layerName3 = refEntity5.LayerName;
						if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, refEntity5.LayerName))
						{
							if (!clsInit.cVector5.IsLayerNameAvailable(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers, refEntity5.LayerName.Trim()))
							{
								layerName3 = "Default";
							}
							else
							{
								refEntity5.LayerName = refEntity5.LayerName.Trim();
								layerName3 = refEntity5.LayerName;
							}
						}
						refEntity5.LayerName = layerName3;
						if (refEntity5 is Mesh && refEntity5.Color == Color.Black)
						{
							refEntity5.Color = Color.WhiteSmoke;
						}
						if (refEntity5 is ICurve)
						{
							refEntity5.LineWeight = 2f;
							refEntity5.LineWeightMethod = colorMethodType.byEntity;
						}
						if (refEntity5 is Text)
						{
							((Text)refEntity5).StyleName = Viewport.TextStyles[0].Name;
						}
						clsInit.cNesting.SetNestingCustomDataOfEntity(ref refEntity5);
						Viewport.Entities.Add(refEntity5);
						list2.Add(refEntity5);
					}
				}
				MinPoint = new Point3D();
				point3D = new Point3D();
				MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(list2, ref MinPoint, ref point3D, ref MaxPoint);
				_ = MaxPoint.X * Result.NestedResultSheets[m].MaterialHeight;
				if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Horizontal)
				{
					num3 = num3 + Result.NestedResultSheets[m].MaterialWidth + ParNest.ResultSettings.DrawNestingResultSpace;
				}
				if (ParNest.ResultSettings.DrawNestingResultAligment == HorizontalVertical.Vertical)
				{
					num4 = num4 + Result.NestedResultSheets[m].MaterialHeight + ParNest.ResultSettings.DrawNestingResultSpace;
				}
				if (num == num2)
				{
					num4 = 0.0;
				}
			}
		}
		Viewport.ZoomFit();
		Viewport.Invalidate();
	}

	public void doSaveAllNesting(buNestedResult Result, int SheetIndex, int PartIndex, Design Viewport, bool isSolid)
	{
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Count - 1; i++)
		{
			Layer layer = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[i];
			for (int j = 0; j <= Viewport.Layers.Count - 1; j++)
			{
				if (!(layer.Name != Viewport.Layers[j].Name))
				{
					if (layer.Color != Viewport.Layers[j].Color)
					{
						Viewport.Layers[j].Color = layer.Color;
					}
				}
				else
				{
					Viewport.Layers.AddOrReplace(new Layer(layer.Name, layer.Color, layer.LineTypeName, layer.LineWeight, layer.Visible));
				}
			}
		}
		int num = 0;
		int num2 = Result.NestedResultSheets.Count - 1;
		if (SheetIndex >= 0)
		{
			num = SheetIndex;
			num2 = SheetIndex;
		}
		if (Result.NestedResultSheets.Count > 0)
		{
			double dy = 0.0;
			for (int k = num; k <= num2; k++)
			{
				Viewport.Entities.Clear();
				List<Entity> calcEntities = new List<Entity>();
				List<Entity> UselessEntities = new List<Entity>();
				ccVars.UndoDont = true;
				if (ParNest.ResultSettings.DrawSheets)
				{
					clsInit.cNesting.NestedSheetToEntity(Result.NestedResultSheets[k], ParNest.ResultSettings.DrawPartAsSolid && isSolid, ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities, ref UselessEntities);
					if (calcEntities != null)
					{
						for (int l = 0; l <= calcEntities.Count - 1; l++)
						{
							calcEntities[l].Translate(0.0, dy);
							Viewport.Entities.Add(calcEntities[l]);
							if (UselessEntities != null)
							{
								for (int m = 0; m <= UselessEntities.Count - 1; m++)
								{
									ccVars.UndoDont = true;
									UselessEntities[m].Translate(0.0, dy);
									Viewport.Entities.Add(UselessEntities[m]);
								}
							}
						}
					}
				}
				List<Entity> list = new List<Entity>();
				double num3 = 0.0;
				int num4 = 0;
				int num5 = Result.NestedResultSheets[k].Parts.Count - 1;
				if (PartIndex >= 0)
				{
					num4 = PartIndex;
					num5 = PartIndex;
				}
				for (int n = num4; n <= num5; n++)
				{
					ccVars.UndoDont = true;
					List<Entity> calcEntities2 = new List<Entity>();
					clsInit.cNesting.NestedPartToEntity(Result.NestedResultSheets[k].Parts[n], isSolid & ParNest.ResultSettings.DrawPartAsSolid, ParNest.ResultSettings.DrawPartOnlyOutterSolid, ref calcEntities2);
					List<Point3D> Points = new List<Point3D>();
					List<buEntity> copiedEntities = new List<buEntity>();
					buEntity.Copy(Result.NestedResultSheets[k].Parts[n].EntitiesGroup.Outside.Entities, ref copiedEntities);
					new EntitiesResolution();
					clsInit.cVector5.EntitiesToPointsWithCamDirection(copiedEntities, 0.01, ref Points);
					double num6 = clsInit.cVector5.PolygonArea(Points, Plane.XY);
					num3 += num6;
					for (int num7 = 0; num7 <= calcEntities2.Count - 1; num7++)
					{
						double dz = 0.0;
						if (calcEntities2[num7].GetType() != typeof(Brep) && ParNest.ResultSettings.DrawPartAsSolid)
						{
							dz = Result.NestedResultSheets[k].Parts[n].Thickness + 0.01;
						}
						Entity entity = calcEntities2[num7];
						if (!clsInit.cVector5.IsLayerNameAvailable(Viewport.Layers, entity.LayerName))
						{
						}
						entity.Translate(0.0, dy, dz);
						Viewport.Entities.Add(entity);
						list.Add(entity);
					}
				}
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(list, ref MinPoint, ref MidPoint, ref MaxPoint);
				_ = MaxPoint.X * Result.NestedResultSheets[k].MaterialHeight;
				Viewport.Entities.RegenAllCurved();
				Viewport.Invalidate();
				buFile5.SaveDxfDwg(Viewport, AppPath.Base + "\\D_" + k + ".dxf");
			}
		}
		Viewport.ZoomFit();
		Viewport.Invalidate();
	}

	public void SheetPartUpdate()
	{
		Sheets.Clear();
		Parts.Clear();
		for (int i = 0; i <= clsItem.FrmNestSheetPart.Sheets.Count - 1; i++)
		{
			Sheets.Add(new buNestingSheet(clsItem.FrmNestSheetPart.Sheets[i]));
		}
		for (int j = 0; j <= clsItem.FrmNestSheetPart.Parts.Count - 1; j++)
		{
			Parts.Add(new buNestingPart(clsItem.FrmNestSheetPart.Parts[j]));
		}
		clsVar.varInterface.NestingAddPartFromFileExtensionIndex = clsItem.FrmNestSheetPart.AddPartFromFileExtensionIndex;
		clsVar.varInterface.pathNestingAddPart = clsItem.FrmNestSheetPart.AddPartFromFileFolder;
		clsVar.varInterface.pathNestingFiles = clsItem.FrmNestSheetPart.SaveFileFolder;
		clsFiles.SaveParameter();
	}
}
