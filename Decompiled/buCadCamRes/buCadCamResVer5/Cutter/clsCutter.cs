using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using buClass;
using buControls.ClassViewer;
using buControls.Forms.WinControlForms.Errors;
using buCore;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.Forms.Materials;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Cutter;

public class clsCutter
{
	public static CutterProgramSettings varCutterSettings = new CutterProgramSettings();

	public static CutterRuntimeSettings varCutterRuntimeSettings = new CutterRuntimeSettings();

	public List<CutterNotch> NotchList = new List<CutterNotch>();

	public RulProperties Properties = new RulProperties();

	private F_MaterialRect2D f_MaterialRect2D_0 = null;

	public void Init()
	{
		LoadLanguage();
		buMWCutterVars.Init();
	}

	public void cmdNewMaterial(DoorJob panel)
	{
		if (f_MaterialRect2D_0 == null)
		{
			f_MaterialRect2D_0 = new F_MaterialRect2D();
			CreateModelProperties Properties = new CreateModelProperties();
			clsInit.appCommand.EyeParameterToCreateModelProperties(clsVar.varPreviewViewport, clsVar.varMouse, ref Properties);
			Properties.CoordinateSystemIconVisible = false;
			Properties.ViewCubeIconVisible = false;
			Properties.OrigineCaptionVisible = false;
			Properties.ToolBorVisible = false;
			Properties.OrigineSize = 5;
			f_MaterialRect2D_0.viewportLayout = clsInit.cVector5.CreateModelControl(clsVar.UnlockKey, Properties);
			f_MaterialRect2D_0.viewportLayout.CompileUserInterfaceElements();
		}
		f_MaterialRect2D_0.pnl_model.Controls.Add(f_MaterialRect2D_0.viewportLayout);
		f_MaterialRect2D_0.viewportLayout.Entities.Clear();
		f_MaterialRect2D_0.PropertiesForm.FormCloseMode = FormCloseModeType.Invisible;
		ccVars.activeMaterial.Size.Width = varCutterRuntimeSettings.ManuelSheetWidth;
		ccVars.activeMaterial.Size.Height = varCutterRuntimeSettings.ManuelSheetHeight;
		f_MaterialRect2D_0.Material = new MaterialBase5(ccVars.activeMaterial);
		if (panel == null)
		{
			f_MaterialRect2D_0.Init(null);
		}
		else
		{
			f_MaterialRect2D_0.Init(panel.Material);
		}
		f_MaterialRect2D_0.StartPosition = FormStartPosition.CenterParent;
		f_MaterialRect2D_0.ShowDialog();
		if (f_MaterialRect2D_0.PropertiesForm.Result == DialogResult.OK)
		{
			ccVars.activeMaterial = new MaterialBase5(f_MaterialRect2D_0.Material);
			varCutterRuntimeSettings.ManuelSheetWidth = ccVars.activeMaterial.Size.Width;
			varCutterRuntimeSettings.ManuelSheetHeight = ccVars.activeMaterial.Size.Height;
			CompositeCurve compositeCurve = CompositeCurve.CreateRectangle(ccVars.activeMaterial.Size.Width, ccVars.activeMaterial.Size.Height);
			CustomData customData = new CustomData();
			customData.typeDefination = entityTypeDefination.Sheet;
			compositeCurve.EntityData = customData;
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(compositeCurve);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ZoomFit(10);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			SaveCutterFile();
		}
	}

	public void cmdNotchEdit()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.cutterNotchAdd;
			dynamicInfo.Command = AppLanguage.CadCamCommand[13];
			ccVars.selectionProcess = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doNotchRotate();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdMachineSettings()
	{
		try
		{
			F_CutterMachineSettings f_CutterMachineSettings = new F_CutterMachineSettings();
			f_CutterMachineSettings.Settings = new CutterProgramSettings(varCutterSettings);
			f_CutterMachineSettings.Init();
			f_CutterMachineSettings.ShowDialog();
			if (f_CutterMachineSettings.PropertiesForm.Result == DialogResult.OK)
			{
				varCutterSettings = new CutterProgramSettings(f_CutterMachineSettings.Settings);
			}
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdOffsetDrawing()
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			ccVars.Action = actionTypeBU.cutterOffsetEntities;
			dynamicInfo.Command = AppLanguage.CadCamCommand[13];
			ccVars.selectionProcess = true;
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doOffsetDrawing();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			clsInit.appCommand.cmdMainFormStatusUpdate(AppLanguage.CadCamStatus[10] + " [ " + dynamicInfo.Command + " ]");
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdConvertText()
	{
		string name = ccVars.Pages[ccVars.PageIndex].Layers[ccVars.Pages[ccVars.PageIndex].LayerIndex].Name;
		List<Entity> LayerEntities = new List<Entity>();
		clsInit.cVector5.GetEntitiesByLayerName(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, name, ref LayerEntities);
		List<buEntity> copiedEntities = new List<buEntity>();
		buEntity.Copy(LayerEntities, ref copiedEntities);
		doConvertText(copiedEntities);
	}

	public void cmdShowCutterSettings()
	{
		try
		{
			if (clsVar.appModes_0.NestingMode.Mode1 != 2.0)
			{
				F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
				f_ClassViewerDialog.Text = "Cutter";
				f_ClassViewerDialog.Value = varCutterSettings;
				f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
				f_ClassViewerDialog.Width = 500;
				f_ClassViewerDialog.Height = 750;
				f_ClassViewerDialog.ValuePersentage = 35.0;
				f_ClassViewerDialog.Init();
				f_ClassViewerDialog.ShowDialog();
				if (f_ClassViewerDialog.Result != DialogResult.OK)
				{
					return;
				}
				varCutterSettings = new CutterProgramSettings((CutterProgramSettings)f_ClassViewerDialog.Value);
				ccVars.MaterialList.Clear();
				if (varCutterSettings.ShowMachineSize)
				{
					for (int i = 0; (double)i <= varCutterSettings.RepeatCount - 1.0; i++)
					{
						MaterialBase5 materialBase = new MaterialBase5(varCutterSettings.MachineWidth, varCutterSettings.MachineHeight, 1.0);
						materialBase.dX = (double)i * varCutterSettings.MachineWidth;
						materialBase.dZ = -1.1;
						ccVars.MaterialList.Add(materialBase);
					}
				}
				clsInit.appCommand.MaterialUpdate(FillMaterial: true, -1);
				clsFiles.SaveParameter();
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

	public void cmdMenuCommand(object sender, EventArgs e)
	{
		if (!(sender is Control))
		{
			if (sender is ToolStripMenuItem)
			{
				ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
				_ = toolStripMenuItem.Name;
			}
		}
		else
		{
			Control control = sender as Control;
			_ = control.Name;
		}
	}

	public void Job_AfterSelect(object sender, TreeViewEventArgs e)
	{
		TreeView treeView = (TreeView)sender;
		_ = (TreeNodeSettings)treeView.SelectedNode;
	}

	public void JobUpdate(bool FillPages, string Command, DrillItem Item, int indexItem)
	{
		try
		{
			if (clsItem.FrmCutterJob == null)
			{
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
		fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buCutter.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buCutter.lng"));
		if (!fileInfo.Exists)
		{
			buLog.addLog("Nesting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Cutter Language File Missing");
			return;
		}
		List<string> StringList = new List<string>();
		buFile.OpenFromFile(fileInfo.FullName, ref StringList);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<CutterProgramSettings>", "</CutterProgramSettings>", StringList), clsVar.varRuntime.Language, ref CutterProgramSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_CutterMachineSettings>", "</F_CutterMachineSettings>", StringList), clsVar.varRuntime.Language, ref F_CutterMachineSettings.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<F_NotchEdit>", "</F_NotchEdit>", StringList), clsVar.varRuntime.Language, ref F_NotchEdit.Captions);
		buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buCutter.LangCutterMessage);
		StringList.Clear();
	}

	public void SaveCutterFile()
	{
		string fileName = AppPath.Settings + "\\Nesting\\CutterSet.prm";
		ArrayList arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   Cuttter Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<CutterSettings>");
		arrayList.AddRange(varCutterSettings.ToDefAll("", 2, SerilizationMode.MultiLine));
		arrayList.Add("</CutterSettings>");
		buFile.SaveToFile(arrayList, fileName);
		buMWCutterVars.varCamCutter.mwPar.Serialize(AppPath.Settings + "\\Nesting\\mwCutterCommon.bin");
		string fileName2 = AppPath.Settings + "\\Nesting\\CutterCam.bucamset";
		arrayList = new ArrayList();
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("   MW Cam Settings");
		arrayList.Add("------------------------------------------------------------------------");
		arrayList.Add("<MwCamSettings>");
		arrayList.AddRange(buMWCutterVars.varCamCutter.buPar.ToDefAll("_varCamCutter", 2, SerilizationMode5.MultiLine));
		arrayList.Add("</MwCamSettings>");
		buFile.SaveToFile(arrayList, fileName2);
		buLog.addLog("Cuttter Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
	}

	public void OpenCutterFile()
	{
		ArrayList StringList = new ArrayList();
		string fileName = AppPath.Settings + "\\Nesting\\CutterSet.prm";
		FileInfo fileInfo = new FileInfo(fileName);
		if (!fileInfo.Exists)
		{
			if (clsVar.appModes_0.NestingMode.Enable)
			{
				buLog.addLog("Cutter Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Cutter Settings File Missing");
			}
		}
		else
		{
			buFile.OpenFromFile(fileInfo.FullName, ref StringList);
			try
			{
				ArrayList CalcList = new ArrayList();
				buString.ListToSpecificList("<CutterSettings>", "</CutterSettings>", AddStartEndKey: true, StringList, ref CalcList);
				if (CalcList.Count <= 0)
				{
					buLog.addLog("<CutterSettings> Line Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("<CutterSettings> Line Missing");
				}
				else
				{
					buSerilization.Decode(StringList, "", SerilizationMode.MultiLine, varCutterSettings);
					buLog.addLog("Cutter Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
				}
			}
			catch (Exception mSException)
			{
				buLog.addLog("Cutter Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Cutter Settings Decoder Error");
			}
		}
		fileInfo = new FileInfo(AppPath.Settings + "\\Nesting\\mwCutterCommon.bin");
		if (fileInfo.Exists)
		{
			buMWCutterVars.varCamCutter.mwPar.Deserialize(fileInfo.FullName);
		}
		string fileName2 = AppPath.Settings + "\\Nesting\\CutterCam.bucamset";
		fileInfo = new FileInfo(fileName2);
		if (!fileInfo.Exists)
		{
			buLog.addLog("Cutter Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buString.MessageBoxError("Cutter Cam Settings File Missing");
			return;
		}
		StringList = new ArrayList();
		buFile.OpenFromFile(fileName2, ref StringList);
		try
		{
			ArrayList CalcList2 = new ArrayList();
			buString.ListToSpecificList("<MwCamSettings>", "</MwCamSettings>", AddStartEndKey: true, StringList, ref CalcList2);
			if (CalcList2.Count > 0)
			{
				buSerilization5.Decode(StringList, "_varCamCommon", SerilizationMode5.MultiLine, buMWCutterVars.varCamCutter.buPar);
			}
		}
		catch (Exception mSException2)
		{
			buLog.addLog("MW Cutter Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Cutter Settings Decoder Error");
		}
	}

	public void AddCutterThingsToNestingResult(ref buNestedResult Result)
	{
		if (Result.NestingSheetList.Count > 0)
		{
			Result.PastalWidth = Result.NestedResultSheets[0].MaterialWidth;
		}
	}

	public void ExtendEntitiesByRules1()
	{
		List<RulStrectPoints> list = new List<RulStrectPoints>();
		List<RulStrectPoints> list2 = new List<RulStrectPoints>();
		List<RulStrectPoints> list3 = new List<RulStrectPoints>();
		List<RulStrectPoints> list4 = new List<RulStrectPoints>();
		List<RulStrectPoints> list5 = new List<RulStrectPoints>();
		List<RulStrectPoints> list6 = new List<RulStrectPoints>();
		List<RulStrectPoints> list7 = new List<RulStrectPoints>();
		List<CutterNotch> list8 = new List<CutterNotch>();
		List<Entity> list9 = new List<Entity>();
		List<Entity> list10 = new List<Entity>();
		List<Entity> list11 = new List<Entity>();
		List<Entity> list12 = new List<Entity>();
		List<Entity> list13 = new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		List<Entity> list14 = new List<Entity>();
		List<Entity> list15 = new List<Entity>();
		List<Entity> list16 = new List<Entity>();
		List<Entity> list17 = new List<Entity>();
		List<Entity> list18 = new List<Entity>();
		List<Entity> list19 = new List<Entity>();
		List<Entity> list20 = new List<Entity>();
		List<Entity> list21 = new List<Entity>();
		List<Entity> list22 = new List<Entity>();
		List<Entity> list23 = new List<Entity>();
		new List<Entity>();
		List<Entity> list24 = new List<Entity>();
		List<Entity> list25 = new List<Entity>();
		List<Entity> list26 = new List<Entity>();
		NotchList.Clear();
		NotchList = new List<CutterNotch>();
		FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
		List<ePoint> list27 = new List<ePoint>();
		if (fileInfo.Exists)
		{
			List<eEntities> RefEntities = new List<eEntities>();
			List<LayerBase> Layers = new List<LayerBase>();
			buFile.Dxf dxf = new buFile.Dxf();
			dxf.ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
			for (int num = RefEntities.Count - 1; num >= 0; num--)
			{
				if (RefEntities[num].GetType() == typeof(ePoint))
				{
					eEntities CalcEnt = new ePoint();
					clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[num], ref CalcEnt);
					CalcEnt.geoAngleXY = RefEntities[num].geoAngleXY;
					list27.Add((ePoint)CalcEnt);
				}
			}
		}
		Layer item = new Layer(varCutterSettings.NotchLayerName, Color.DarkRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item);
		Layer item2 = new Layer(varCutterSettings.InfoLayerName, Color.MediumVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item2);
		Layer item3 = new Layer(varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item3);
		if (Properties.SizeList.Count == 0)
		{
			Properties.SizeList.Add("");
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				list25.Add((Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Clone());
			}
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName == varCutterSettings.MirrorLayerName)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				list26.Add((Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Clone());
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		for (int j = 0; j <= Properties.SizeList.Count - 1; j++)
		{
			list = new List<RulStrectPoints>();
			list2 = new List<RulStrectPoints>();
			list5 = new List<RulStrectPoints>();
			list4 = new List<RulStrectPoints>();
			list3 = new List<RulStrectPoints>();
			list6 = new List<RulStrectPoints>();
			list7 = new List<RulStrectPoints>();
			list8 = new List<CutterNotch>();
			list9 = new List<Entity>();
			list11 = new List<Entity>();
			list15 = new List<Entity>();
			list17 = new List<Entity>();
			list19 = new List<Entity>();
			list21 = new List<Entity>();
			for (int k = 0; k <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; k++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is devDept.Eyeshot.Entities.Point)
				{
					devDept.Eyeshot.Entities.Point point = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] as devDept.Eyeshot.Entities.Point;
					for (int l = 0; l <= list27.Count - 1; l++)
					{
						if (!(buCompare5.EQ(list27[l].StartPoint.X, point.StartPoint.X, 0.01) & buCompare5.EQ(list27[l].StartPoint.Y, point.StartPoint.Y, 0.01)) || !((list27[l].auxText.IndexOf("39") >= 0) | (list27[l].auxText.IndexOf("50") >= 0)))
						{
							continue;
						}
						if (point.LayerName == varCutterSettings.NotchInsideLayerName)
						{
							CutterNotch cutterNotch = new CutterNotch();
							cutterNotch.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
							cutterNotch.NotchType = CutterNotchType.INotch;
							cutterNotch.Length = point.StartPoint.Z;
							cutterNotch.Direction = InOutType.Inside;
							cutterNotch.DirectionAngle = list27[l].geoAngleXY;
							if (list8.Count != 0)
							{
								bool flag = true;
								for (int m = 0; m <= list8.Count - 1; m++)
								{
									if (buCompare5.EQ(list8[m].Position, cutterNotch.Position))
									{
										flag = false;
										m = list8.Count;
									}
								}
								if (flag)
								{
									list8.Add(cutterNotch);
								}
							}
							else
							{
								list8.Add(cutterNotch);
							}
						}
						if (!(point.LayerName == varCutterSettings.NotchOutsideLayerName))
						{
							continue;
						}
						CutterNotch cutterNotch2 = new CutterNotch();
						cutterNotch2.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
						cutterNotch2.Length = point.StartPoint.Z;
						cutterNotch2.Direction = InOutType.Outside;
						cutterNotch2.DirectionAngle = list27[l].geoAngleXY;
						if (list27[l].auxText.IndexOf("39") < 0)
						{
							cutterNotch2.NotchType = CutterNotchType.INotch;
						}
						else
						{
							cutterNotch2.Width = list27[l].auxValue;
							cutterNotch2.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch2.Width / 2.0 / cutterNotch2.Length)) * 2.0;
							cutterNotch2.NotchType = CutterNotchType.VNotch;
						}
						if (list8.Count != 0)
						{
							bool flag2 = true;
							for (int n = 0; n <= list8.Count - 1; n++)
							{
								if (buCompare5.EQ(list8[n].Position, cutterNotch2.Position))
								{
									flag2 = false;
									n = list8.Count;
								}
							}
							if (flag2)
							{
								list8.Add(cutterNotch2);
							}
						}
						else
						{
							list8.Add(cutterNotch2);
						}
					}
				}
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is Text)
				{
					Text text = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] as Text;
					bool flag3 = false;
					if (text.LayerName == varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints = new RulStrectPoints();
						rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints.No = no;
						for (int num2 = 0; num2 <= Properties.RuleList.Count - 1; num2++)
						{
							if (rulStrectPoints.No == Properties.RuleList[num2].No)
							{
								rulStrectPoints.dX = Properties.RuleList[num2].Position[j].X;
								rulStrectPoints.dY = Properties.RuleList[num2].Position[j].Y;
							}
						}
						list.Add(rulStrectPoints);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no2 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints2 = new RulStrectPoints();
						rulStrectPoints2.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints2.No = no2;
						for (int num3 = 0; num3 <= Properties.RuleList.Count - 1; num3++)
						{
							if (rulStrectPoints2.No == Properties.RuleList[num3].No)
							{
								rulStrectPoints2.dX = Properties.RuleList[num3].Position[j].X;
								rulStrectPoints2.dY = Properties.RuleList[num3].Position[j].Y;
							}
						}
						list2.Add(rulStrectPoints2);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourNoCutLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no3 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints3 = new RulStrectPoints();
						rulStrectPoints3.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints3.No = no3;
						for (int num4 = 0; num4 <= Properties.RuleList.Count - 1; num4++)
						{
							if (rulStrectPoints3.No == Properties.RuleList[num4].No)
							{
								rulStrectPoints3.dX = Properties.RuleList[num4].Position[j].X;
								rulStrectPoints3.dY = Properties.RuleList[num4].Position[j].Y;
							}
						}
						list5.Add(rulStrectPoints3);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.RopeDirectionLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no4 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints4 = new RulStrectPoints();
						rulStrectPoints4.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints4.No = no4;
						for (int num5 = 0; num5 <= Properties.RuleList.Count - 1; num5++)
						{
							if (rulStrectPoints4.No == Properties.RuleList[num5].No)
							{
								rulStrectPoints4.dX = Properties.RuleList[num5].Position[j].X;
								rulStrectPoints4.dY = Properties.RuleList[num5].Position[j].Y;
							}
						}
						list4.Add(rulStrectPoints4);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.DrillLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no5 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints5 = new RulStrectPoints();
						rulStrectPoints5.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints5.No = no5;
						for (int num6 = 0; num6 <= Properties.RuleList.Count - 1; num6++)
						{
							if (rulStrectPoints5.No == Properties.RuleList[num6].No)
							{
								rulStrectPoints5.dX = Properties.RuleList[num6].Position[j].X;
								rulStrectPoints5.dY = Properties.RuleList[num6].Position[j].Y;
							}
						}
						list3.Add(rulStrectPoints5);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourPloter1LayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no6 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints6 = new RulStrectPoints();
						rulStrectPoints6.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints6.No = no6;
						for (int num7 = 0; num7 <= Properties.RuleList.Count - 1; num7++)
						{
							if (rulStrectPoints6.No == Properties.RuleList[num7].No)
							{
								rulStrectPoints6.dX = Properties.RuleList[num7].Position[j].X;
								rulStrectPoints6.dY = Properties.RuleList[num7].Position[j].Y;
							}
						}
						list6.Add(rulStrectPoints6);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourPloter2LayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						int no7 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints7 = new RulStrectPoints();
						rulStrectPoints7.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints7.No = no7;
						for (int num8 = 0; num8 <= Properties.RuleList.Count - 1; num8++)
						{
							if (rulStrectPoints7.No == Properties.RuleList[num8].No)
							{
								rulStrectPoints7.dX = Properties.RuleList[num8].Position[j].X;
								rulStrectPoints7.dY = Properties.RuleList[num8].Position[j].Y;
							}
						}
						list7.Add(rulStrectPoints7);
						flag3 = true;
					}
					if (text.LayerName == varCutterSettings.DrillLayerName && j == 0 && text.TextString.IndexOf("#-") >= 0)
					{
						double num9 = 5.0;
						for (int num10 = 0; num10 <= list25.Count - 1; num10++)
						{
							if (list25[num10].LayerName == varCutterSettings.DrillLayerName && buCompare5.EQ(text.InsertionPoint, ((devDept.Eyeshot.Entities.Point)list25[num10]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point)list25[num10]).StartPoint.Z > 0.0)
							{
								num9 = ((devDept.Eyeshot.Entities.Point)list25[num10]).StartPoint.Z;
							}
						}
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						EntityDataSet entData = new EntityDataSet(-1, varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, text.InsertionPoint);
						CustomData customData = new CustomData();
						Circle Ent = new Circle(text.InsertionPoint, num9 / 2.0);
						clsInit.appCommand.CreateCircle(text.InsertionPoint, num9 / 2.0, Plane.XY, entData, customData, ref Ent);
						((CustomData)Ent.EntityData).infoData = Properties.SizeList[j];
						list13.Add(Ent);
						flag3 = true;
					}
					if (!varCutterSettings.AddAttribute && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is devDept.Eyeshot.Entities.Attribute)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						flag3 = true;
					}
					if (!flag3 && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						flag3 = true;
					}
					if (!flag3 && j == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						Text text2 = (Text)text.Clone();
						text2.EntityData = new CustomData((CustomData)text.EntityData);
						text2.LayerName = varCutterSettings.InfoLayerName;
						list23.Add(text2);
					}
				}
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k] is ICurve)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k];
					((CustomData)entity.EntityData).infoData = Properties.SizeList[j];
					if (entity.LayerName == varCutterSettings.ContourLayerName)
					{
						list9.Add(buVector5.CopyEntities(entity));
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.InnerContourLayerName)
					{
						list11.Add(buVector5.CopyEntities(entity));
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.ContourRefLayerName)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.InnerContourRefLayerName)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.RopeDirectionLayerName && j == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						list15.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourNoCutLayerName && j == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = false;
						list17.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourPloter1LayerName && j == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						list19.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourPloter2LayerName && j == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[k].Selected = true;
						list21.Add(buVector5.CopyEntities(entity));
					}
				}
			}
			if (list26.Count > 0)
			{
				List<RulStrectPoints> list28 = new List<RulStrectPoints>();
				List<CutterNotch> list29 = new List<CutterNotch>();
				for (int num11 = 0; num11 <= list26.Count - 1; num11++)
				{
					Point3D startPoint = ((ICurve)list26[num11]).StartPoint;
					Point3D endPoint = ((ICurve)list26[num11]).EndPoint;
					Point3D value = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
					for (int num12 = 0; num12 <= list9.Count - 1; num12++)
					{
						List<Point3D> PointList = new List<Point3D>();
						buVector5.VerticeToPointsList(list9[num12].Vertices, ref PointList);
						bool flag4 = false;
						for (int num13 = 1; num13 <= PointList.Count - 1; num13++)
						{
							Point3D value2 = clsInit.cVector5.MiddlePointOfLine(PointList[num13 - 1], PointList[num13]);
							if (buCompare5.EQ(value, value2))
							{
								PointList.RemoveAt(num13);
								flag4 = true;
							}
						}
						if (!flag4)
						{
							Point3D value3 = clsInit.cVector5.MiddlePointOfLine(PointList[0], PointList[PointList.Count - 1]);
							if (buCompare5.EQ(value, value3))
							{
								flag4 = true;
							}
						}
						if (!flag4)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList[0], 0.1))
							{
								flag4 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList[PointList.Count - 1], 0.1))
							{
								flag4 = true;
							}
						}
						if (!flag4)
						{
							continue;
						}
						for (int num14 = 0; num14 <= list.Count - 1; num14++)
						{
							Point3D refPoint = new Point3D(list[num14].Position.X, list[num14].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list9[num12], refPoint, 0.1))
							{
								RulStrectPoints rulStrectPoints8 = new RulStrectPoints(list[num14]);
								Point3D mirrorPoint = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
								rulStrectPoints8.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
								rulStrectPoints8.dY = 0.0 - list[num14].dY;
								list28.Add(rulStrectPoints8);
							}
						}
						for (int num15 = 0; num15 <= list8.Count - 1; num15++)
						{
							Point3D refPoint2 = new Point3D(list8[num15].Position.X, list8[num15].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list9[num12], refPoint2, 0.1))
							{
								CutterNotch cutterNotch3 = new CutterNotch(list8[num15]);
								Point3D mirrorPoint2 = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint2, ref mirrorPoint2);
								cutterNotch3.Position = new Point3D(mirrorPoint2.X, mirrorPoint2.Y);
								cutterNotch3.DirectionAngle += 180.0;
								list29.Add(cutterNotch3);
							}
						}
						List<Point3D> mirrorPoint3 = new List<Point3D>();
						clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList, ref mirrorPoint3);
						mirrorPoint3.Reverse();
						PointList.AddRange(mirrorPoint3);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList);
						Entity copiedEntity = new LinearPath(PointList);
						clsInit.cVector5.CopyEntityProperties(list9[num12], ref copiedEntity);
						((CustomData)copiedEntity.EntityData).infoData = Properties.SizeList[j];
						list9[num12] = copiedEntity;
					}
					for (int num16 = 0; num16 <= list19.Count - 1; num16++)
					{
						List<Point3D> PointList2 = new List<Point3D>();
						buVector5.VerticeToPointsList(list19[num16].Vertices, ref PointList2);
						bool flag5 = false;
						for (int num17 = 1; num17 <= PointList2.Count - 1; num17++)
						{
							Point3D value4 = clsInit.cVector5.MiddlePointOfLine(PointList2[num17 - 1], PointList2[num17]);
							if (buCompare5.EQ(value, value4))
							{
								PointList2.RemoveAt(num17);
								flag5 = true;
							}
						}
						if (!flag5)
						{
							Point3D value5 = clsInit.cVector5.MiddlePointOfLine(PointList2[0], PointList2[PointList2.Count - 1]);
							if (buCompare5.EQ(value, value5, varCutterSettings.MirrorCenterPointCatchGapDistance))
							{
								flag5 = true;
							}
						}
						if (!flag5)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList2[0], 0.1))
							{
								flag5 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList2[PointList2.Count - 1], 0.1))
							{
								flag5 = true;
							}
						}
						if (flag5)
						{
							List<Point3D> mirrorPoint4 = new List<Point3D>();
							clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList2, ref mirrorPoint4);
							mirrorPoint4.Reverse();
							PointList2.AddRange(mirrorPoint4);
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList2);
							Entity copiedEntity2 = new LinearPath(PointList2);
							clsInit.cVector5.CopyEntityProperties(list19[num16], ref copiedEntity2);
							((CustomData)copiedEntity2.EntityData).infoData = Properties.SizeList[j];
							list19[num16] = copiedEntity2;
						}
					}
					for (int num18 = 0; num18 <= list21.Count - 1; num18++)
					{
						List<Point3D> PointList3 = new List<Point3D>();
						buVector5.VerticeToPointsList(list21[num18].Vertices, ref PointList3);
						bool flag6 = false;
						for (int num19 = 1; num19 <= PointList3.Count - 1; num19++)
						{
							Point3D value6 = clsInit.cVector5.MiddlePointOfLine(PointList3[num19 - 1], PointList3[num19]);
							if (buCompare5.EQ(value, value6))
							{
								PointList3.RemoveAt(num19);
								flag6 = true;
							}
						}
						if (!flag6)
						{
							Point3D value7 = clsInit.cVector5.MiddlePointOfLine(PointList3[0], PointList3[PointList3.Count - 1]);
							if (buCompare5.EQ(value, value7, varCutterSettings.MirrorCenterPointCatchGapDistance))
							{
								flag6 = true;
							}
						}
						if (!flag6)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList3[0], 0.1))
							{
								flag6 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list26[num11], PointList3[PointList3.Count - 1], 0.1))
							{
								flag6 = true;
							}
						}
						if (flag6)
						{
							List<Point3D> mirrorPoint5 = new List<Point3D>();
							clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList3, ref mirrorPoint5);
							mirrorPoint5.Reverse();
							PointList3.AddRange(mirrorPoint5);
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList3);
							Entity copiedEntity3 = new LinearPath(PointList3);
							clsInit.cVector5.CopyEntityProperties(list21[num18], ref copiedEntity3);
							((CustomData)copiedEntity3.EntityData).infoData = Properties.SizeList[j];
							list21[num18] = copiedEntity3;
						}
					}
				}
				for (int num20 = 0; num20 <= list28.Count - 1; num20++)
				{
					list.Add(new RulStrectPoints(list28[num20]));
				}
				for (int num21 = 0; num21 <= list29.Count - 1; num21++)
				{
					bool flag7 = true;
					for (int num22 = 0; num22 <= list8.Count - 1; num22++)
					{
						if (buCompare5.EQ(list8[num22].Position, list29[num21].Position))
						{
							flag7 = false;
							num22 = list8.Count;
						}
					}
					if (flag7)
					{
						list8.Add(new CutterNotch(list29[num21]));
					}
				}
			}
			for (int num23 = 0; num23 <= list9.Count - 1; num23++)
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				List<Pnt3D> Points = new List<Pnt3D>();
				Pnt3D pnt = new Pnt3D();
				Pnt3D pnt3D = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				ICurve curve = list9[num23] as ICurve;
				clsInit.cVector5.BoxSizeCalculate(list9[num23], ref MinPoint, ref MidPoint, ref MaxPoint);
				for (int num24 = 0; num24 <= list8.Count - 1; num24++)
				{
					Point3D point3D = new Point3D(list8[num24].Position.X, list8[num24].Position.Y);
					clsInit.cVector5.PointAngle(MidPoint, point3D, Plane.XY);
					double t = 0.0;
					list8[num24].CurveAtLength = curve.Length();
					((ICurve)list9[num23]).ClosestPointTo(point3D, out t);
					if (!clsInit.cVector5.isPointInsideEntity(curve, point3D, 1.0))
					{
						list8[num24].InCurve = false;
					}
					else
					{
						list8[num24].InCurve = true;
					}
					list8[num24].CurveAtPersentage = t / list8[num24].CurveAtLength;
					if (list8[num24].InCurve)
					{
						Point3D basePoint = curve.PointAt(t);
						Point3D tipPoint = curve.PointAt(t + 0.1);
						double num25 = clsInit.cVector5.PointAngle(tipPoint, basePoint, Plane.XY);
						double angle = num25 + 90.0;
						double angle2 = num25 - 90.0;
						Point3D EndPnt = new Point3D();
						Point3D EndPnt2 = new Point3D();
						clsInit.cVector5.LineWithLengthAndAngle(new Point3D(list8[num24].Position.X, list8[num24].Position.Y), 2.0, angle, ref EndPnt);
						clsInit.cVector5.LineWithLengthAndAngle(new Point3D(list8[num24].Position.X, list8[num24].Position.Y), 2.0, angle2, ref EndPnt2);
						Utility.PointInPolygon(EndPnt, list9[num23].Vertices);
						Utility.PointInPolygon(EndPnt2, list9[num23].Vertices);
						list8[num24].baseEntityIndex = num23;
						list8[num24].baseEntityName = ((CustomData)list9[num23].EntityData).EntityName;
					}
				}
				for (int num26 = 0; num26 <= list9[num23].Vertices.Length - 1; num26++)
				{
					Pnt3D pnt3D2 = new Pnt3D(list9[num23].Vertices[num26].X, list9[num23].Vertices[num26].Y, list9[num23].Vertices[num26].Z);
					bool flag8 = false;
					for (int num27 = 0; num27 <= list.Count - 1; num27++)
					{
						if (buCompare5.EQ(pnt3D2, list[num27].Position))
						{
							pnt = new Pnt3D(pnt3D2);
							_ = list[num27].dX;
							_ = list[num27].dY;
							pnt3D2 = new Pnt3D(pnt3D2.X + list[num27].dX, pnt3D2.Y + list[num27].dY, pnt3D2.Z);
							flag8 = true;
						}
					}
					if (!flag8)
					{
						Points.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
						continue;
					}
					if (Points.Count > 0)
					{
						Points.Insert(0, new Pnt3D(pnt3D));
						Points.Add(new Pnt3D(pnt));
						Pnt3D MinPoint2 = new Pnt3D();
						Pnt3D MidPoint2 = new Pnt3D();
						Pnt3D MaxPoint2 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
						double num28 = 1.0;
						double num29 = 1.0;
						num28 = (pnt3D2.X - CopiedPnt[CopiedPnt.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
						num29 = (pnt3D2.Y - CopiedPnt[CopiedPnt.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
						clsInit.cVector.Scale(pnt3D, num28, num29, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points);
						_ = CopiedPnt[CopiedPnt.Count - 1].X - Points[0].X;
						_ = CopiedPnt[CopiedPnt.Count - 1].Y - Points[0].Y;
						clsInit.cVector.Move(Points[0], CopiedPnt[CopiedPnt.Count - 1], ref Points);
						Points.RemoveAt(0);
						Points.RemoveAt(Points.Count - 1);
						Pnt3D.Add(Points, ref CopiedPnt);
						Points.Clear();
						Points = new List<Pnt3D>();
					}
					CopiedPnt.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
					pnt3D = new Pnt3D(pnt);
				}
				EntityDataSet entData2 = new EntityDataSet(-1, varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData2 = new CustomData((CustomData)list9[num23].EntityData);
				LinearPath Ent2 = new LinearPath();
				List<Point3D> CopiedPnt2 = new List<Point3D>();
				if (CopiedPnt.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt, ref CopiedPnt2);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData2, customData2, ref Ent2);
				Ent2.EntityData = customData2;
				list10.Add(Ent2);
				for (int num30 = 0; num30 <= list8.Count - 1; num30++)
				{
					Pnt3D pnt3D3 = new Pnt3D(list8[num30].Position.X, list8[num30].Position.Y, list8[num30].Position.Z);
					for (int num31 = 0; num31 <= list.Count - 1; num31++)
					{
						if (buCompare5.EQ(pnt3D3, list[num31].Position))
						{
							pnt = new Pnt3D(pnt3D3);
							_ = list[num30].dX;
							_ = list[num30].dY;
							list8[num30].Position = new Point3D(pnt3D3.X + list[num31].dX, pnt3D3.Y + list[num31].dY, pnt3D3.Z);
							num31 = list.Count;
						}
					}
					if (list8[num30].InCurve | !list8[num30].InCurve)
					{
						Entity copiedEntity4 = null;
						buEntity.Copy(Ent2, ref copiedEntity4);
						ICurve baseEntity = (ICurve)copiedEntity4;
						List<Entity> notchEntities = new List<Entity>();
						Point3D position = buVector5.ToPoint3D(list8[num30].Position);
						clsInit.cCutter.CreateNotch(list8[num30].NotchType, position, list8[num30].Length, list8[num30].DirectionAngle, list8[num30].Angle, baseEntity, ref notchEntities);
						for (int num32 = 0; num32 <= notchEntities.Count - 1; num32++)
						{
							Entity Ent3 = null;
							clsInit.appCommand.CreateEntity(notchEntities[num32], ref Ent3);
							Ent3.LayerName = varCutterSettings.NotchLayerName;
							((CustomData)Ent3.EntityData).infoBasePoint = new Point3D(list8[num30].Position.X, list8[num30].Position.Y, list8[num30].Position.Z);
							((CustomData)Ent3.EntityData).infoLength = list8[num30].Length;
							((CustomData)Ent3.EntityData).infoWidth = list8[num30].Width;
							((CustomData)Ent3.EntityData).infoAngle = list8[num30].Angle;
							((CustomData)Ent3.EntityData).infoDirection = list8[num30].DirectionAngle;
							((CustomData)Ent3.EntityData).ActionName = ((CustomData)list9[num23].EntityData).EntityName;
							((CustomData)Ent3.EntityData).infoString = list8[num30].NotchType.ToString();
							((CustomData)Ent3.EntityData).infoData = Properties.SizeList[j];
							list24.Add(Ent3);
						}
					}
				}
			}
			for (int num33 = 0; num33 <= list11.Count - 1; num33++)
			{
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				List<Pnt3D> Points2 = new List<Pnt3D>();
				Pnt3D pnt2 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint3 = new Point3D();
				Point3D MidPoint3 = new Point3D();
				Point3D MaxPoint3 = new Point3D();
				_ = list11[num33] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list11[num33], ref MinPoint3, ref MidPoint3, ref MaxPoint3);
				for (int num34 = 0; num34 <= list11[num33].Vertices.Length - 1; num34++)
				{
					Pnt3D pnt3D5 = new Pnt3D(list11[num33].Vertices[num34].X, list11[num33].Vertices[num34].Y, list11[num33].Vertices[num34].Z);
					bool flag9 = false;
					for (int num35 = 0; num35 <= list2.Count - 1; num35++)
					{
						if (buCompare5.EQ(pnt3D5, list2[num35].Position))
						{
							pnt2 = new Pnt3D(pnt3D5);
							_ = list2[num35].dX;
							_ = list2[num35].dY;
							pnt3D5 = new Pnt3D(pnt3D5.X + list2[num35].dX, pnt3D5.Y + list2[num35].dY, pnt3D5.Z);
							flag9 = true;
						}
					}
					if (!flag9)
					{
						Points2.Add(new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z));
						continue;
					}
					if (Points2.Count > 0)
					{
						Points2.Insert(0, new Pnt3D(pnt3D4));
						Points2.Add(new Pnt3D(pnt2));
						Pnt3D MinPoint4 = new Pnt3D();
						Pnt3D MidPoint4 = new Pnt3D();
						Pnt3D MaxPoint4 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points2, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
						double num36 = 1.0;
						double num37 = 1.0;
						num36 = (pnt3D5.X - CopiedPnt3[CopiedPnt3.Count - 1].X) / (Points2[Points2.Count - 1].X - Points2[0].X);
						num37 = (pnt3D5.Y - CopiedPnt3[CopiedPnt3.Count - 1].Y) / (Points2[Points2.Count - 1].Y - Points2[0].Y);
						clsInit.cVector.Scale(pnt3D4, num36, num37, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points2);
						_ = CopiedPnt3[CopiedPnt3.Count - 1].X - Points2[0].X;
						_ = CopiedPnt3[CopiedPnt3.Count - 1].Y - Points2[0].Y;
						clsInit.cVector.Move(Points2[0], CopiedPnt3[CopiedPnt3.Count - 1], ref Points2);
						Points2.RemoveAt(0);
						Points2.RemoveAt(Points2.Count - 1);
						Pnt3D.Add(Points2, ref CopiedPnt3);
						Points2.Clear();
						Points2 = new List<Pnt3D>();
					}
					CopiedPnt3.Add(new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z));
					pnt3D4 = new Pnt3D(pnt2);
				}
				EntityDataSet entData3 = new EntityDataSet(-1, varCutterSettings.InnerContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData3 = new CustomData((CustomData)list11[num33].EntityData);
				LinearPath Ent4 = new LinearPath();
				List<Point3D> CopiedPnt4 = new List<Point3D>();
				if (CopiedPnt3.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points2, ref CopiedPnt4);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt3, ref CopiedPnt4);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt4, entData3, customData3, ref Ent4);
				list12.Add(Ent4);
			}
			for (int num38 = 0; num38 <= list17.Count - 1; num38++)
			{
				List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
				List<Pnt3D> Points3 = new List<Pnt3D>();
				Pnt3D pnt3 = new Pnt3D();
				Pnt3D pnt3D6 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint5 = new Point3D();
				Point3D MidPoint5 = new Point3D();
				Point3D MaxPoint5 = new Point3D();
				_ = list17[num38] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list17[num38], ref MinPoint5, ref MidPoint5, ref MaxPoint5);
				for (int num39 = 0; num39 <= list17[num38].Vertices.Length - 1; num39++)
				{
					Pnt3D pnt3D7 = new Pnt3D(list17[num38].Vertices[num39].X, list17[num38].Vertices[num39].Y, list17[num38].Vertices[num39].Z);
					bool flag10 = false;
					for (int num40 = 0; num40 <= list5.Count - 1; num40++)
					{
						if (buCompare5.EQ(pnt3D7, list5[num40].Position))
						{
							pnt3 = new Pnt3D(pnt3D7);
							_ = list5[num40].dX;
							_ = list5[num40].dY;
							pnt3D7 = new Pnt3D(pnt3D7.X + list5[num40].dX, pnt3D7.Y + list5[num40].dY, pnt3D7.Z);
							flag10 = true;
						}
					}
					if (!flag10)
					{
						Points3.Add(new Pnt3D(pnt3D7.X, pnt3D7.Y, pnt3D7.Z));
						continue;
					}
					if (Points3.Count > 0)
					{
						Points3.Insert(0, new Pnt3D(pnt3D6));
						Points3.Add(new Pnt3D(pnt3));
						Pnt3D MinPoint6 = new Pnt3D();
						Pnt3D MidPoint6 = new Pnt3D();
						Pnt3D MaxPoint6 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points3, ref MinPoint6, ref MidPoint6, ref MaxPoint6);
						double num41 = 1.0;
						double num42 = 1.0;
						num41 = (pnt3D7.X - CopiedPnt5[CopiedPnt5.Count - 1].X) / (Points3[Points3.Count - 1].X - Points3[0].X);
						num42 = (pnt3D7.Y - CopiedPnt5[CopiedPnt5.Count - 1].Y) / (Points3[Points3.Count - 1].Y - Points3[0].Y);
						clsInit.cVector.Scale(pnt3D6, num41, num42, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points3);
						_ = CopiedPnt5[CopiedPnt5.Count - 1].X - Points3[0].X;
						_ = CopiedPnt5[CopiedPnt5.Count - 1].Y - Points3[0].Y;
						clsInit.cVector.Move(Points3[0], CopiedPnt5[CopiedPnt5.Count - 1], ref Points3);
						Points3.RemoveAt(0);
						Points3.RemoveAt(Points3.Count - 1);
						Pnt3D.Add(Points3, ref CopiedPnt5);
						Points3.Clear();
						Points3 = new List<Pnt3D>();
					}
					CopiedPnt5.Add(new Pnt3D(pnt3D7.X, pnt3D7.Y, pnt3D7.Z));
					pnt3D6 = new Pnt3D(pnt3);
				}
				EntityDataSet entData4 = new EntityDataSet(-1, varCutterSettings.InnerContourNoCutLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData4 = new CustomData((CustomData)list17[num38].EntityData);
				LinearPath Ent5 = new LinearPath();
				List<Point3D> CopiedPnt6 = new List<Point3D>();
				if (CopiedPnt5.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points3, ref CopiedPnt6);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt5, ref CopiedPnt6);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt6, entData4, customData4, ref Ent5);
				list18.Add(Ent5);
			}
			for (int num43 = 0; num43 <= list15.Count - 1; num43++)
			{
				List<Pnt3D> CopiedPnt7 = new List<Pnt3D>();
				List<Pnt3D> Points4 = new List<Pnt3D>();
				Pnt3D pnt4 = new Pnt3D();
				Pnt3D pnt3D8 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint7 = new Point3D();
				Point3D MidPoint7 = new Point3D();
				Point3D MaxPoint7 = new Point3D();
				_ = list15[num43] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list15[num43], ref MinPoint7, ref MidPoint7, ref MaxPoint7);
				for (int num44 = 0; num44 <= list15[num43].Vertices.Length - 1; num44++)
				{
					Pnt3D pnt3D9 = new Pnt3D(list15[num43].Vertices[num44].X, list15[num43].Vertices[num44].Y, list15[num43].Vertices[num44].Z);
					bool flag11 = false;
					for (int num45 = 0; num45 <= list4.Count - 1; num45++)
					{
						if (buCompare5.EQ(pnt3D9, list4[num45].Position))
						{
							pnt4 = new Pnt3D(pnt3D9);
							_ = list4[num45].dX;
							_ = list4[num45].dY;
							pnt3D9 = new Pnt3D(pnt3D9.X + list4[num45].dX, pnt3D9.Y + list4[num45].dY, pnt3D9.Z);
							flag11 = true;
						}
					}
					if (!flag11)
					{
						Points4.Add(new Pnt3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z));
						continue;
					}
					if (Points4.Count > 0)
					{
						Points4.Insert(0, new Pnt3D(pnt3D8));
						Points4.Add(new Pnt3D(pnt4));
						Pnt3D MinPoint8 = new Pnt3D();
						Pnt3D MidPoint8 = new Pnt3D();
						Pnt3D MaxPoint8 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points4, ref MinPoint8, ref MidPoint8, ref MaxPoint8);
						double num46 = 1.0;
						double num47 = 1.0;
						num46 = (pnt3D9.X - CopiedPnt7[CopiedPnt7.Count - 1].X) / (Points4[Points4.Count - 1].X - Points4[0].X);
						num47 = (pnt3D9.Y - CopiedPnt7[CopiedPnt7.Count - 1].Y) / (Points4[Points4.Count - 1].Y - Points4[0].Y);
						clsInit.cVector.Scale(pnt3D8, num46, num47, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points4);
						_ = CopiedPnt7[CopiedPnt7.Count - 1].X - Points4[0].X;
						_ = CopiedPnt7[CopiedPnt7.Count - 1].Y - Points4[0].Y;
						clsInit.cVector.Move(Points4[0], CopiedPnt7[CopiedPnt7.Count - 1], ref Points4);
						Points4.RemoveAt(0);
						Points4.RemoveAt(Points4.Count - 1);
						Pnt3D.Add(Points4, ref CopiedPnt7);
						Points4.Clear();
						Points4 = new List<Pnt3D>();
					}
					CopiedPnt7.Add(new Pnt3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z));
					pnt3D8 = new Pnt3D(pnt4);
				}
				EntityDataSet entData5 = new EntityDataSet(-1, varCutterSettings.RopeDirectionLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData5 = new CustomData((CustomData)list15[num43].EntityData);
				LinearPath Ent6 = new LinearPath();
				List<Point3D> CopiedPnt8 = new List<Point3D>();
				if (CopiedPnt7.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points4, ref CopiedPnt8);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt7, ref CopiedPnt8);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt8, entData5, customData5, ref Ent6);
				list16.Add(Ent6);
			}
			for (int num48 = 0; num48 <= list13.Count - 1; num48++)
			{
				Point3D MinPoint9 = new Point3D();
				Point3D MidPoint9 = new Point3D();
				Point3D MaxPoint9 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(list13[num48], ref MinPoint9, ref MidPoint9, ref MaxPoint9);
				Pnt3D pnt3D10 = new Pnt3D(((Circle)list13[num48]).Center.X, ((Circle)list13[num48]).Center.Y, ((Circle)list13[num48]).Center.Z);
				double radius = ((Circle)list13[num48]).Radius;
				for (int num49 = 0; num49 <= list3.Count - 1; num49++)
				{
					if (buCompare5.EQ(pnt3D10, list3[num49].Position))
					{
						pnt3D10 = new Pnt3D(pnt3D10.X + list3[num49].dX, pnt3D10.Y + list3[num49].dY, pnt3D10.Z);
					}
				}
				EntityDataSet entData6 = new EntityDataSet(-1, varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData6 = new CustomData((CustomData)list13[num48].EntityData);
				customData6.infoData = Properties.SizeList[j];
				Circle Ent7 = null;
				clsInit.appCommand.CreateCircle(new Point3D(pnt3D10.X, pnt3D10.Y, pnt3D10.Z), radius, Plane.XY, entData6, customData6, ref Ent7);
				list14.Add(Ent7);
			}
			for (int num50 = 0; num50 <= list19.Count - 1; num50++)
			{
				List<Pnt3D> CopiedPnt9 = new List<Pnt3D>();
				List<Pnt3D> Points5 = new List<Pnt3D>();
				Pnt3D pnt5 = new Pnt3D();
				Pnt3D pnt3D11 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint10 = new Point3D();
				Point3D MidPoint10 = new Point3D();
				Point3D MaxPoint10 = new Point3D();
				_ = list19[num50] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list19[num50], ref MinPoint10, ref MidPoint10, ref MaxPoint10);
				for (int num51 = 0; num51 <= list19[num50].Vertices.Length - 1; num51++)
				{
					Pnt3D pnt3D12 = new Pnt3D(list19[num50].Vertices[num51].X, list19[num50].Vertices[num51].Y, list19[num50].Vertices[num51].Z);
					bool flag12 = false;
					for (int num52 = 0; num52 <= list6.Count - 1; num52++)
					{
						if (buCompare5.EQ(pnt3D12, list6[num52].Position))
						{
							pnt5 = new Pnt3D(pnt3D12);
							_ = list6[num52].dX;
							_ = list6[num52].dY;
							pnt3D12 = new Pnt3D(pnt3D12.X + list6[num52].dX, pnt3D12.Y + list6[num52].dY, pnt3D12.Z);
							flag12 = true;
						}
					}
					if (!flag12)
					{
						Points5.Add(new Pnt3D(pnt3D12.X, pnt3D12.Y, pnt3D12.Z));
						continue;
					}
					if (Points5.Count > 0)
					{
						Points5.Insert(0, new Pnt3D(pnt3D11));
						Points5.Add(new Pnt3D(pnt5));
						Pnt3D MinPoint11 = new Pnt3D();
						Pnt3D MidPoint11 = new Pnt3D();
						Pnt3D MaxPoint11 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points5, ref MinPoint11, ref MidPoint11, ref MaxPoint11);
						double num53 = 1.0;
						double num54 = 1.0;
						num53 = (pnt3D12.X - CopiedPnt9[CopiedPnt9.Count - 1].X) / (Points5[Points5.Count - 1].X - Points5[0].X);
						num54 = (pnt3D12.Y - CopiedPnt9[CopiedPnt9.Count - 1].Y) / (Points5[Points5.Count - 1].Y - Points5[0].Y);
						clsInit.cVector.Scale(pnt3D11, num53, num54, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points5);
						_ = CopiedPnt9[CopiedPnt9.Count - 1].X - Points5[0].X;
						_ = CopiedPnt9[CopiedPnt9.Count - 1].Y - Points5[0].Y;
						clsInit.cVector.Move(Points5[0], CopiedPnt9[CopiedPnt9.Count - 1], ref Points5);
						Points5.RemoveAt(0);
						Points5.RemoveAt(Points5.Count - 1);
						Pnt3D.Add(Points5, ref CopiedPnt9);
						Points5.Clear();
						Points5 = new List<Pnt3D>();
					}
					CopiedPnt9.Add(new Pnt3D(pnt3D12.X, pnt3D12.Y, pnt3D12.Z));
					pnt3D11 = new Pnt3D(pnt5);
				}
				EntityDataSet entData7 = new EntityDataSet(-1, varCutterSettings.InnerContourPloter1LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData7 = new CustomData((CustomData)list19[num50].EntityData);
				LinearPath Ent8 = new LinearPath();
				List<Point3D> CopiedPnt10 = new List<Point3D>();
				if (CopiedPnt9.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points5, ref CopiedPnt10);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt9, ref CopiedPnt10);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt10, entData7, customData7, ref Ent8);
				list20.Add(Ent8);
			}
			for (int num55 = 0; num55 <= list21.Count - 1; num55++)
			{
				List<Pnt3D> CopiedPnt11 = new List<Pnt3D>();
				List<Pnt3D> Points6 = new List<Pnt3D>();
				Pnt3D pnt6 = new Pnt3D();
				Pnt3D pnt3D13 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint12 = new Point3D();
				Point3D MidPoint12 = new Point3D();
				Point3D MaxPoint12 = new Point3D();
				_ = list21[num55] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list21[num55], ref MinPoint12, ref MidPoint12, ref MaxPoint12);
				for (int num56 = 0; num56 <= list21[num55].Vertices.Length - 1; num56++)
				{
					Pnt3D pnt3D14 = new Pnt3D(list21[num55].Vertices[num56].X, list21[num55].Vertices[num56].Y, list21[num55].Vertices[num56].Z);
					bool flag13 = false;
					for (int num57 = 0; num57 <= list7.Count - 1; num57++)
					{
						if (buCompare5.EQ(pnt3D14, list7[num57].Position))
						{
							pnt6 = new Pnt3D(pnt3D14);
							_ = list7[num57].dX;
							_ = list7[num57].dY;
							pnt3D14 = new Pnt3D(pnt3D14.X + list7[num57].dX, pnt3D14.Y + list7[num57].dY, pnt3D14.Z);
							flag13 = true;
						}
					}
					if (!flag13)
					{
						Points6.Add(new Pnt3D(pnt3D14.X, pnt3D14.Y, pnt3D14.Z));
						continue;
					}
					if (Points6.Count > 0)
					{
						Points6.Insert(0, new Pnt3D(pnt3D13));
						Points6.Add(new Pnt3D(pnt6));
						Pnt3D MinPoint13 = new Pnt3D();
						Pnt3D MidPoint13 = new Pnt3D();
						Pnt3D MaxPoint13 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points6, ref MinPoint13, ref MidPoint13, ref MaxPoint13);
						double num58 = 1.0;
						double num59 = 1.0;
						num58 = (pnt3D14.X - CopiedPnt11[CopiedPnt11.Count - 1].X) / (Points6[Points6.Count - 1].X - Points6[0].X);
						num59 = (pnt3D14.Y - CopiedPnt11[CopiedPnt11.Count - 1].Y) / (Points6[Points6.Count - 1].Y - Points6[0].Y);
						clsInit.cVector.Scale(pnt3D13, num58, num59, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points6);
						_ = CopiedPnt11[CopiedPnt11.Count - 1].X - Points6[0].X;
						_ = CopiedPnt11[CopiedPnt11.Count - 1].Y - Points6[0].Y;
						clsInit.cVector.Move(Points6[0], CopiedPnt11[CopiedPnt11.Count - 1], ref Points6);
						Points6.RemoveAt(0);
						Points6.RemoveAt(Points6.Count - 1);
						Pnt3D.Add(Points6, ref CopiedPnt11);
						Points6.Clear();
						Points6 = new List<Pnt3D>();
					}
					CopiedPnt11.Add(new Pnt3D(pnt3D14.X, pnt3D14.Y, pnt3D14.Z));
					pnt3D13 = new Pnt3D(pnt6);
				}
				EntityDataSet entData8 = new EntityDataSet(-1, varCutterSettings.InnerContourPloter2LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData8 = new CustomData((CustomData)list21[num55].EntityData);
				LinearPath Ent9 = new LinearPath();
				List<Point3D> CopiedPnt12 = new List<Point3D>();
				if (CopiedPnt11.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points6, ref CopiedPnt12);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt11, ref CopiedPnt12);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt12, entData8, customData8, ref Ent9);
				list22.Add(Ent9);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		for (int num60 = 0; num60 <= list10.Count - 1; num60++)
		{
			ccVars.UndoDont = true;
			((CustomData)list10[num60].EntityData).typeDefination = entityTypeDefination.Cutting;
			clsInit.appCommand.AddEntity(list10[num60]);
		}
		for (int num61 = 0; num61 <= list24.Count - 1; num61++)
		{
			ccVars.UndoDont = true;
			((CustomData)list24[num61].EntityData).typeDefination = entityTypeDefination.Notch;
			clsInit.appCommand.AddEntity(list24[num61]);
		}
		for (int num62 = 0; num62 <= list12.Count - 1; num62++)
		{
			ccVars.UndoDont = true;
			((CustomData)list12[num62].EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
			clsInit.appCommand.AddEntity(list12[num62]);
		}
		for (int num63 = 0; num63 <= list20.Count - 1; num63++)
		{
			ccVars.UndoDont = true;
			clsInit.appCommand.AddEntity(list20[num63]);
			((CustomData)list20[num63].EntityData).typeDefination = entityTypeDefination.InnerAux;
		}
		for (int num64 = 0; num64 <= list22.Count - 1; num64++)
		{
			ccVars.UndoDont = true;
			((CustomData)list22[num64].EntityData).typeDefination = entityTypeDefination.InnerAux;
			clsInit.appCommand.AddEntity(list22[num64]);
		}
		for (int num65 = 0; num65 <= list16.Count - 1; num65++)
		{
			((CustomData)list16[num65].EntityData).typeDefination = entityTypeDefination.Direction;
			double num66 = Point3D.Distance(list16[num65].Vertices[0], list16[num65].Vertices[list16[num65].Vertices.Length - 1]);
			List<Entity> calcEntities = new List<Entity>();
			clsInit.cVector5.DrawWireArrow(list16[num65].Vertices[0], list16[num65].Vertices[list16[num65].Vertices.Length - 1], num66 * 0.1, 15.0, Plane.XY, ref calcEntities);
			for (int num67 = 0; num67 <= calcEntities.Count - 1; num67++)
			{
				Entity copiedEntity5 = calcEntities[num67];
				clsInit.cVector5.CopyEntityProperties(list16[num65], ref copiedEntity5);
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(copiedEntity5);
			}
		}
		for (int num68 = 0; num68 <= list23.Count - 1; num68++)
		{
			ccVars.UndoDont = true;
			bool flag14 = false;
			for (int num69 = 0; num69 <= list10.Count - 1; num69++)
			{
				_ = ((Text)list23[num68]).InsertionPoint;
				if (list10[num69].BoxMin == null)
				{
					list10[num69].Regen(new RegenParams(0.01, ccVars.Pages[ccVars.PageIndex].Form.viewportcad));
				}
				if (clsInit.cVector5.IsPointInsideBoxsize(((Text)list23[num68]).InsertionPoint, list10[num69].BoxMin, list10[num69].BoxMax, Plane.XY))
				{
					flag14 = true;
				}
			}
			((CustomData)list23[num68].EntityData).typeDefination = entityTypeDefination.Info;
			if (!flag14)
			{
				clsInit.appCommand.AddEntity(list23[num68]);
				continue;
			}
			list23[num68].LayerName = varCutterSettings.PartInfoLayerName;
			clsInit.appCommand.AddEntity(list23[num68]);
		}
		for (int num70 = 0; num70 <= list14.Count - 1; num70++)
		{
			ccVars.UndoDont = true;
			((CustomData)list14[num70].EntityData).typeDefination = entityTypeDefination.Drill;
			clsInit.appCommand.AddEntity(list14[num70]);
		}
	}

	public void ExtendEntitiesByRules2()
	{
		List<RulStrectPoints> list = new List<RulStrectPoints>();
		List<RulStrectPoints> list2 = new List<RulStrectPoints>();
		List<RulStrectPoints> list3 = new List<RulStrectPoints>();
		List<RulStrectPoints> list4 = new List<RulStrectPoints>();
		List<RulStrectPoints> list5 = new List<RulStrectPoints>();
		List<RulStrectPoints> list6 = new List<RulStrectPoints>();
		List<RulStrectPoints> list7 = new List<RulStrectPoints>();
		List<RulStrectPoints> list8 = new List<RulStrectPoints>();
		List<CutterNotch> list9 = new List<CutterNotch>();
		List<Entity> list10 = new List<Entity>();
		List<Entity> list11 = new List<Entity>();
		List<Entity> list12 = new List<Entity>();
		List<Entity> list13 = new List<Entity>();
		List<Entity> list14 = new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		List<Entity> list15 = new List<Entity>();
		List<Entity> list16 = new List<Entity>();
		List<Entity> list17 = new List<Entity>();
		List<Entity> list18 = new List<Entity>();
		List<Entity> list19 = new List<Entity>();
		List<Entity> list20 = new List<Entity>();
		List<Entity> list21 = new List<Entity>();
		List<Entity> list22 = new List<Entity>();
		List<Entity> list23 = new List<Entity>();
		List<Entity> list24 = new List<Entity>();
		new List<Entity>();
		List<Entity> list25 = new List<Entity>();
		List<Entity> list26 = new List<Entity>();
		List<Entity> list27 = new List<Entity>();
		NotchList.Clear();
		NotchList = new List<CutterNotch>();
		FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
		List<ePoint> list28 = new List<ePoint>();
		if (fileInfo.Exists)
		{
			List<eEntities> RefEntities = new List<eEntities>();
			List<LayerBase> Layers = new List<LayerBase>();
			buFile.Dxf dxf = new buFile.Dxf();
			dxf.ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
			for (int num = RefEntities.Count - 1; num >= 0; num--)
			{
				if (RefEntities[num].GetType() == typeof(ePoint))
				{
					eEntities CalcEnt = new ePoint();
					clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[num], ref CalcEnt);
					CalcEnt.geoAngleXY = RefEntities[num].geoAngleXY;
					list28.Add((ePoint)CalcEnt);
				}
			}
		}
		Layer item = new Layer(varCutterSettings.NotchLayerName, Color.DarkRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item);
		Layer item2 = new Layer(varCutterSettings.InfoLayerName, Color.MediumVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item2);
		Layer item3 = new Layer(varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item3);
		if (Properties.SizeList.Count == 0)
		{
			Properties.SizeList.Add("");
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(devDept.Eyeshot.Entities.Point))
			{
				list26.Add((Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Clone());
			}
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].LayerName == varCutterSettings.MirrorLayerName)
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
				list27.Add((Entity)ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Clone());
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
		{
			if (!(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is devDept.Eyeshot.Entities.Point))
			{
				continue;
			}
			devDept.Eyeshot.Entities.Point point = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] as devDept.Eyeshot.Entities.Point;
			for (int k = 0; k <= list28.Count - 1; k++)
			{
				if (!(buCompare5.EQ(list28[k].StartPoint.X, point.StartPoint.X, 0.01) & buCompare5.EQ(list28[k].StartPoint.Y, point.StartPoint.Y, 0.01)) || !((list28[k].auxText.IndexOf("39") >= 0) | (list28[k].auxText.IndexOf("50") >= 0)))
				{
					continue;
				}
				if (point.LayerName == varCutterSettings.NotchInsideLayerName)
				{
					CutterNotch cutterNotch = new CutterNotch();
					cutterNotch.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
					cutterNotch.NotchType = CutterNotchType.INotch;
					cutterNotch.Length = point.StartPoint.Z;
					cutterNotch.Direction = InOutType.Inside;
					cutterNotch.DirectionAngle = list28[k].geoAngleXY;
					list9.Add(cutterNotch);
				}
				if (point.LayerName == varCutterSettings.NotchOutsideLayerName)
				{
					CutterNotch cutterNotch2 = new CutterNotch();
					cutterNotch2.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
					cutterNotch2.Length = point.StartPoint.Z;
					cutterNotch2.Direction = InOutType.Outside;
					cutterNotch2.DirectionAngle = list28[k].geoAngleXY;
					if (list28[k].auxText.IndexOf("39") < 0)
					{
						cutterNotch2.NotchType = CutterNotchType.INotch;
					}
					else
					{
						cutterNotch2.Width = list28[k].auxValue;
						cutterNotch2.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch2.Width / 2.0 / cutterNotch2.Length)) * 2.0;
						cutterNotch2.NotchType = CutterNotchType.VNotch;
					}
					list9.Add(cutterNotch2);
				}
			}
		}
		for (int l = 0; l <= Properties.SizeList.Count - 1; l++)
		{
			list = new List<RulStrectPoints>();
			list2 = new List<RulStrectPoints>();
			list5 = new List<RulStrectPoints>();
			list4 = new List<RulStrectPoints>();
			list3 = new List<RulStrectPoints>();
			list6 = new List<RulStrectPoints>();
			list7 = new List<RulStrectPoints>();
			list8 = new List<RulStrectPoints>();
			list10 = new List<Entity>();
			list12 = new List<Entity>();
			list16 = new List<Entity>();
			list18 = new List<Entity>();
			list20 = new List<Entity>();
			list22 = new List<Entity>();
			for (int m = 0; m <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; m++)
			{
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m] is Text)
				{
					Text text = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m] as Text;
					bool flag = false;
					if (text.LayerName == varCutterSettings.ContourRuleScaleLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints = new RulStrectPoints();
						rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints.No = no;
						for (int n = 0; n <= Properties.RuleList.Count - 1; n++)
						{
							if (rulStrectPoints.No == Properties.RuleList[n].No)
							{
								rulStrectPoints.dX = Properties.RuleList[n].Position[l].X;
								rulStrectPoints.dY = Properties.RuleList[n].Position[l].Y;
							}
						}
						list.Add(rulStrectPoints);
						flag = true;
						for (int num2 = 0; num2 <= list9.Count - 1; num2++)
						{
							if (!buCompare5.EQ(buVector5.ToPoint3D(list9[num2].Position), text.InsertionPoint, 0.1))
							{
								continue;
							}
							no = Convert.ToInt32(text.TextString.Replace("#", ""));
							rulStrectPoints = new RulStrectPoints();
							rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
							rulStrectPoints.No = no;
							for (int num3 = 0; num3 <= Properties.RuleList.Count - 1; num3++)
							{
								if (rulStrectPoints.No == Properties.RuleList[num3].No)
								{
									rulStrectPoints.dX = Properties.RuleList[num3].Position[l].X;
									rulStrectPoints.dY = Properties.RuleList[num3].Position[l].Y;
								}
							}
							list8.Add(rulStrectPoints);
						}
					}
					if (text.LayerName == varCutterSettings.InnerContourLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no2 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints2 = new RulStrectPoints();
						rulStrectPoints2.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints2.No = no2;
						for (int num4 = 0; num4 <= Properties.RuleList.Count - 1; num4++)
						{
							if (rulStrectPoints2.No == Properties.RuleList[num4].No)
							{
								rulStrectPoints2.dX = Properties.RuleList[num4].Position[l].X;
								rulStrectPoints2.dY = Properties.RuleList[num4].Position[l].Y;
							}
						}
						list2.Add(rulStrectPoints2);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourNoCutLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no3 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints3 = new RulStrectPoints();
						rulStrectPoints3.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints3.No = no3;
						for (int num5 = 0; num5 <= Properties.RuleList.Count - 1; num5++)
						{
							if (rulStrectPoints3.No == Properties.RuleList[num5].No)
							{
								rulStrectPoints3.dX = Properties.RuleList[num5].Position[l].X;
								rulStrectPoints3.dY = Properties.RuleList[num5].Position[l].Y;
							}
						}
						list5.Add(rulStrectPoints3);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.RopeDirectionLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no4 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints4 = new RulStrectPoints();
						rulStrectPoints4.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints4.No = no4;
						for (int num6 = 0; num6 <= Properties.RuleList.Count - 1; num6++)
						{
							if (rulStrectPoints4.No == Properties.RuleList[num6].No)
							{
								rulStrectPoints4.dX = Properties.RuleList[num6].Position[l].X;
								rulStrectPoints4.dY = Properties.RuleList[num6].Position[l].Y;
							}
						}
						list4.Add(rulStrectPoints4);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.DrillLayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no5 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints5 = new RulStrectPoints();
						rulStrectPoints5.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints5.No = no5;
						for (int num7 = 0; num7 <= Properties.RuleList.Count - 1; num7++)
						{
							if (rulStrectPoints5.No == Properties.RuleList[num7].No)
							{
								rulStrectPoints5.dX = Properties.RuleList[num7].Position[l].X;
								rulStrectPoints5.dY = Properties.RuleList[num7].Position[l].Y;
							}
						}
						list3.Add(rulStrectPoints5);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourPloter1LayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no6 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints6 = new RulStrectPoints();
						rulStrectPoints6.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints6.No = no6;
						for (int num8 = 0; num8 <= Properties.RuleList.Count - 1; num8++)
						{
							if (rulStrectPoints6.No == Properties.RuleList[num8].No)
							{
								rulStrectPoints6.dX = Properties.RuleList[num8].Position[l].X;
								rulStrectPoints6.dY = Properties.RuleList[num8].Position[l].Y;
							}
						}
						list6.Add(rulStrectPoints6);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.InnerContourPloter2LayerName && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						int no7 = Convert.ToInt32(text.TextString.Replace("#", ""));
						RulStrectPoints rulStrectPoints7 = new RulStrectPoints();
						rulStrectPoints7.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints7.No = no7;
						for (int num9 = 0; num9 <= Properties.RuleList.Count - 1; num9++)
						{
							if (rulStrectPoints7.No == Properties.RuleList[num9].No)
							{
								rulStrectPoints7.dX = Properties.RuleList[num9].Position[l].X;
								rulStrectPoints7.dY = Properties.RuleList[num9].Position[l].Y;
							}
						}
						list7.Add(rulStrectPoints7);
						flag = true;
					}
					if (text.LayerName == varCutterSettings.DrillLayerName && l == 0 && text.TextString.IndexOf("#-") >= 0)
					{
						double num10 = 5.0;
						for (int num11 = 0; num11 <= list26.Count - 1; num11++)
						{
							if (list26[num11].LayerName == varCutterSettings.DrillLayerName && buCompare5.EQ(text.InsertionPoint, ((devDept.Eyeshot.Entities.Point)list26[num11]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point)list26[num11]).StartPoint.Z > 0.0)
							{
								num10 = ((devDept.Eyeshot.Entities.Point)list26[num11]).StartPoint.Z;
							}
						}
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						EntityDataSet entData = new EntityDataSet(-1, varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, text.InsertionPoint);
						CustomData customData = new CustomData();
						Circle Ent = new Circle(text.InsertionPoint, num10 / 2.0);
						clsInit.appCommand.CreateCircle(text.InsertionPoint, num10 / 2.0, Plane.XY, entData, customData, ref Ent);
						((CustomData)Ent.EntityData).infoData = Properties.SizeList[l];
						list14.Add(Ent);
						flag = true;
					}
					if (!varCutterSettings.AddAttribute && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m] is devDept.Eyeshot.Entities.Attribute)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						flag = true;
					}
					if (!flag && text.TextString.IndexOf("#-") >= 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						flag = true;
					}
					if (!flag && l == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						Text text2 = (Text)text.Clone();
						text2.EntityData = new CustomData((CustomData)text.EntityData);
						text2.LayerName = varCutterSettings.InfoLayerName;
						list24.Add(text2);
					}
				}
				if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m] is ICurve)
				{
					Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m];
					((CustomData)entity.EntityData).infoData = Properties.SizeList[l];
					if (entity.LayerName == varCutterSettings.ContourLayerName)
					{
						list10.Add(buVector5.CopyEntities(entity));
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.InnerContourLayerName)
					{
						list12.Add(buVector5.CopyEntities(entity));
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.ContourRefLayerName)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.InnerContourRefLayerName)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
					}
					if (entity.LayerName == varCutterSettings.RopeDirectionLayerName && l == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						list16.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourNoCutLayerName && l == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = false;
						list18.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourPloter1LayerName && l == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						list20.Add(buVector5.CopyEntities(entity));
					}
					if (entity.LayerName == varCutterSettings.InnerContourPloter2LayerName && l == 0)
					{
						ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[m].Selected = true;
						list22.Add(buVector5.CopyEntities(entity));
					}
				}
			}
			if (list27.Count > 0)
			{
				List<RulStrectPoints> list29 = new List<RulStrectPoints>();
				List<CutterNotch> list30 = new List<CutterNotch>();
				for (int num12 = 0; num12 <= list27.Count - 1; num12++)
				{
					Point3D startPoint = ((ICurve)list27[num12]).StartPoint;
					Point3D endPoint = ((ICurve)list27[num12]).EndPoint;
					Point3D value = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
					for (int num13 = 0; num13 <= list10.Count - 1; num13++)
					{
						List<Point3D> PointList = new List<Point3D>();
						buVector5.VerticeToPointsList(list10[num13].Vertices, ref PointList);
						bool flag2 = false;
						for (int num14 = 1; num14 <= PointList.Count - 1; num14++)
						{
							Point3D value2 = clsInit.cVector5.MiddlePointOfLine(PointList[num14 - 1], PointList[num14]);
							if (buCompare5.EQ(value, value2))
							{
								PointList.RemoveAt(num14);
								flag2 = true;
							}
						}
						if (!flag2)
						{
							Point3D value3 = clsInit.cVector5.MiddlePointOfLine(PointList[0], PointList[PointList.Count - 1]);
							if (buCompare5.EQ(value, value3))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList[0], 0.1))
							{
								flag2 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList[PointList.Count - 1], 0.1))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							continue;
						}
						for (int num15 = 0; num15 <= list.Count - 1; num15++)
						{
							Point3D refPoint = new Point3D(list[num15].Position.X, list[num15].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list10[num13], refPoint, 0.1))
							{
								RulStrectPoints rulStrectPoints8 = new RulStrectPoints(list[num15]);
								Point3D mirrorPoint = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
								rulStrectPoints8.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
								rulStrectPoints8.dY = 0.0 - list[num15].dY;
								list29.Add(rulStrectPoints8);
							}
						}
						for (int num16 = 0; num16 <= list9.Count - 1; num16++)
						{
							Point3D refPoint2 = new Point3D(list9[num16].Position.X, list9[num16].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list10[num13], refPoint2, 0.1))
							{
								CutterNotch cutterNotch3 = new CutterNotch(list9[num16]);
								Point3D mirrorPoint2 = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint2, ref mirrorPoint2);
								cutterNotch3.Position = new Point3D(mirrorPoint2.X, mirrorPoint2.Y);
								cutterNotch3.DirectionAngle += 180.0;
								list30.Add(cutterNotch3);
							}
						}
						List<Point3D> mirrorPoint3 = new List<Point3D>();
						clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList, ref mirrorPoint3);
						mirrorPoint3.Reverse();
						PointList.AddRange(mirrorPoint3);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList);
						Entity copiedEntity = new LinearPath(PointList);
						clsInit.cVector5.CopyEntityProperties(list10[num13], ref copiedEntity);
						((CustomData)copiedEntity.EntityData).infoData = Properties.SizeList[l];
						list10[num13] = copiedEntity;
					}
					for (int num17 = 0; num17 <= list20.Count - 1; num17++)
					{
						List<Point3D> PointList2 = new List<Point3D>();
						buVector5.VerticeToPointsList(list20[num17].Vertices, ref PointList2);
						bool flag3 = false;
						for (int num18 = 1; num18 <= PointList2.Count - 1; num18++)
						{
							Point3D value4 = clsInit.cVector5.MiddlePointOfLine(PointList2[num18 - 1], PointList2[num18]);
							if (buCompare5.EQ(value, value4))
							{
								PointList2.RemoveAt(num18);
								flag3 = true;
							}
						}
						if (!flag3)
						{
							Point3D value5 = clsInit.cVector5.MiddlePointOfLine(PointList2[0], PointList2[PointList2.Count - 1]);
							if (buCompare5.EQ(value, value5, varCutterSettings.MirrorCenterPointCatchGapDistance))
							{
								flag3 = true;
							}
						}
						if (!flag3)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList2[0], 0.1))
							{
								flag3 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList2[PointList2.Count - 1], 0.1))
							{
								flag3 = true;
							}
						}
						if (flag3)
						{
							List<Point3D> mirrorPoint4 = new List<Point3D>();
							clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList2, ref mirrorPoint4);
							mirrorPoint4.Reverse();
							PointList2.AddRange(mirrorPoint4);
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList2);
							Entity copiedEntity2 = new LinearPath(PointList2);
							clsInit.cVector5.CopyEntityProperties(list20[num17], ref copiedEntity2);
							((CustomData)copiedEntity2.EntityData).infoData = Properties.SizeList[l];
							list20[num17] = copiedEntity2;
						}
					}
					for (int num19 = 0; num19 <= list22.Count - 1; num19++)
					{
						List<Point3D> PointList3 = new List<Point3D>();
						buVector5.VerticeToPointsList(list22[num19].Vertices, ref PointList3);
						bool flag4 = false;
						for (int num20 = 1; num20 <= PointList3.Count - 1; num20++)
						{
							Point3D value6 = clsInit.cVector5.MiddlePointOfLine(PointList3[num20 - 1], PointList3[num20]);
							if (buCompare5.EQ(value, value6))
							{
								PointList3.RemoveAt(num20);
								flag4 = true;
							}
						}
						if (!flag4)
						{
							Point3D value7 = clsInit.cVector5.MiddlePointOfLine(PointList3[0], PointList3[PointList3.Count - 1]);
							if (buCompare5.EQ(value, value7, varCutterSettings.MirrorCenterPointCatchGapDistance))
							{
								flag4 = true;
							}
						}
						if (!flag4)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList3[0], 0.1))
							{
								flag4 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list27[num12], PointList3[PointList3.Count - 1], 0.1))
							{
								flag4 = true;
							}
						}
						if (flag4)
						{
							List<Point3D> mirrorPoint5 = new List<Point3D>();
							clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList3, ref mirrorPoint5);
							mirrorPoint5.Reverse();
							PointList3.AddRange(mirrorPoint5);
							clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList3);
							Entity copiedEntity3 = new LinearPath(PointList3);
							clsInit.cVector5.CopyEntityProperties(list22[num19], ref copiedEntity3);
							((CustomData)copiedEntity3.EntityData).infoData = Properties.SizeList[l];
							list22[num19] = copiedEntity3;
						}
					}
				}
				for (int num21 = 0; num21 <= list29.Count - 1; num21++)
				{
					list.Add(new RulStrectPoints(list29[num21]));
				}
				for (int num22 = 0; num22 <= list30.Count - 1; num22++)
				{
					list9.Add(new CutterNotch(list30[num22]));
				}
			}
			for (int num23 = 0; num23 <= list10.Count - 1; num23++)
			{
				List<Pnt3D> CopiedPnt = new List<Pnt3D>();
				List<Pnt3D> Points = new List<Pnt3D>();
				Pnt3D pnt = new Pnt3D();
				Pnt3D pnt3D = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint = new Point3D();
				Point3D MidPoint = new Point3D();
				Point3D MaxPoint = new Point3D();
				ICurve curve = list10[num23] as ICurve;
				clsInit.cVector5.BoxSizeCalculate(list10[num23], ref MinPoint, ref MidPoint, ref MaxPoint);
				for (int num24 = 0; num24 <= list9.Count - 1; num24++)
				{
					Point3D point3D = new Point3D(list9[num24].Position.X, list9[num24].Position.Y);
					clsInit.cVector5.PointAngle(MidPoint, point3D, Plane.XY);
					double t = 0.0;
					list9[num24].CurveAtLength = curve.Length();
					((ICurve)list10[num23]).ClosestPointTo(point3D, out t);
					if (!clsInit.cVector5.isPointInsideEntity(curve, point3D, 1.0))
					{
						list9[num24].InCurve = false;
					}
					else
					{
						list9[num24].InCurve = true;
					}
					list9[num24].CurveAtPersentage = t / list9[num24].CurveAtLength;
					if (list9[num24].InCurve)
					{
						Point3D basePoint = curve.PointAt(t);
						Point3D tipPoint = curve.PointAt(t + 0.1);
						double num25 = clsInit.cVector5.PointAngle(tipPoint, basePoint, Plane.XY);
						double angle = num25 + 90.0;
						double angle2 = num25 - 90.0;
						Point3D EndPnt = new Point3D();
						Point3D EndPnt2 = new Point3D();
						clsInit.cVector5.LineWithLengthAndAngle(new Point3D(list9[num24].Position.X, list9[num24].Position.Y), 2.0, angle, ref EndPnt);
						clsInit.cVector5.LineWithLengthAndAngle(new Point3D(list9[num24].Position.X, list9[num24].Position.Y), 2.0, angle2, ref EndPnt2);
						Utility.PointInPolygon(EndPnt, list10[num23].Vertices);
						Utility.PointInPolygon(EndPnt2, list10[num23].Vertices);
						list9[num24].baseEntityIndex = num23;
						list9[num24].baseEntityName = ((CustomData)list10[num23].EntityData).EntityName;
					}
				}
				for (int num26 = 0; num26 <= list10[num23].Vertices.Length - 1; num26++)
				{
					Pnt3D pnt3D2 = new Pnt3D(list10[num23].Vertices[num26].X, list10[num23].Vertices[num26].Y, list10[num23].Vertices[num26].Z);
					bool flag5 = false;
					for (int num27 = 0; num27 <= list.Count - 1; num27++)
					{
						if (buCompare5.EQ(pnt3D2, list[num27].Position))
						{
							pnt = new Pnt3D(pnt3D2);
							_ = list[num27].dX;
							_ = list[num27].dY;
							pnt3D2 = new Pnt3D(pnt3D2.X + list[num27].dX, pnt3D2.Y + list[num27].dY, pnt3D2.Z);
							flag5 = true;
						}
					}
					if (!flag5)
					{
						Points.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
						continue;
					}
					if (Points.Count > 0)
					{
						Points.Insert(0, new Pnt3D(pnt3D));
						Points.Add(new Pnt3D(pnt));
						Pnt3D MinPoint2 = new Pnt3D();
						Pnt3D MidPoint2 = new Pnt3D();
						Pnt3D MaxPoint2 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint2, ref MidPoint2, ref MaxPoint2);
						double num28 = 1.0;
						double num29 = 1.0;
						num28 = (pnt3D2.X - CopiedPnt[CopiedPnt.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
						num29 = (pnt3D2.Y - CopiedPnt[CopiedPnt.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
						clsInit.cVector.Scale(pnt3D, num28, num29, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points);
						_ = CopiedPnt[CopiedPnt.Count - 1].X - Points[0].X;
						_ = CopiedPnt[CopiedPnt.Count - 1].Y - Points[0].Y;
						clsInit.cVector.Move(Points[0], CopiedPnt[CopiedPnt.Count - 1], ref Points);
						Points.RemoveAt(0);
						Points.RemoveAt(Points.Count - 1);
						Pnt3D.Add(Points, ref CopiedPnt);
						Points.Clear();
						Points = new List<Pnt3D>();
					}
					CopiedPnt.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
					pnt3D = new Pnt3D(pnt);
				}
				EntityDataSet entData2 = new EntityDataSet(-1, varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData2 = new CustomData((CustomData)list10[num23].EntityData);
				LinearPath Ent2 = new LinearPath();
				List<Point3D> CopiedPnt2 = new List<Point3D>();
				if (CopiedPnt.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt, ref CopiedPnt2);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData2, customData2, ref Ent2);
				Ent2.EntityData = customData2;
				list11.Add(Ent2);
			}
			for (int num30 = 0; num30 <= list9.Count - 1; num30++)
			{
				new Pnt3D();
				Pnt3D pnt3D3 = new Pnt3D(list9[num30].Position.X, list9[num30].Position.Y, list9[num30].Position.Z);
				for (int num31 = 0; num31 <= list8.Count - 1; num31++)
				{
					if (buCompare5.EQ(pnt3D3, list8[num31].Position))
					{
						new Pnt3D(pnt3D3);
						_ = list8[num31].dX;
						_ = list8[num31].dY;
						pnt3D3 = new Pnt3D(pnt3D3.X + list8[num31].dX, pnt3D3.Y + list8[num31].dY, pnt3D3.Z);
						list9[num30].Position = new Point3D(pnt3D3.X, pnt3D3.Y, pnt3D3.Z);
					}
				}
				if (list9[num30].InCurve & (list9[num30].baseEntityIndex >= 0))
				{
					int baseEntityIndex = list9[num30].baseEntityIndex;
					Entity copiedEntity4 = null;
					buEntity.Copy(list10[baseEntityIndex], ref copiedEntity4);
					ICurve baseEntity = (ICurve)copiedEntity4;
					List<Entity> notchEntities = new List<Entity>();
					clsInit.cCutter.CreateNotch(list9[num30].NotchType, buVector5.ToPoint3D(list9[num30].Position), list9[num30].Length, list9[num30].DirectionAngle, list9[num30].Angle, baseEntity, ref notchEntities);
					for (int num32 = 0; num32 <= notchEntities.Count - 1; num32++)
					{
						Entity Ent3 = null;
						clsInit.appCommand.CreateEntity(notchEntities[num32], ref Ent3);
						Ent3.LayerName = varCutterSettings.NotchLayerName;
						((CustomData)Ent3.EntityData).infoBasePoint = new Point3D(list9[num30].Position.X, list9[num30].Position.Y, list9[num30].Position.Z);
						((CustomData)Ent3.EntityData).infoLength = list9[num30].Length;
						((CustomData)Ent3.EntityData).infoWidth = list9[num30].Width;
						((CustomData)Ent3.EntityData).infoAngle = list9[num30].Angle;
						((CustomData)Ent3.EntityData).infoDirection = list9[num30].DirectionAngle;
						((CustomData)Ent3.EntityData).ActionName = ((CustomData)list10[baseEntityIndex].EntityData).EntityName;
						((CustomData)Ent3.EntityData).infoString = list9[num30].NotchType.ToString();
						((CustomData)Ent3.EntityData).infoData = Properties.SizeList[l];
						list25.Add(Ent3);
					}
				}
			}
			for (int num33 = 0; num33 <= list12.Count - 1; num33++)
			{
				List<Pnt3D> CopiedPnt3 = new List<Pnt3D>();
				List<Pnt3D> Points2 = new List<Pnt3D>();
				Pnt3D pnt2 = new Pnt3D();
				Pnt3D pnt3D4 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint3 = new Point3D();
				Point3D MidPoint3 = new Point3D();
				Point3D MaxPoint3 = new Point3D();
				_ = list12[num33] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list12[num33], ref MinPoint3, ref MidPoint3, ref MaxPoint3);
				for (int num34 = 0; num34 <= list12[num33].Vertices.Length - 1; num34++)
				{
					Pnt3D pnt3D5 = new Pnt3D(list12[num33].Vertices[num34].X, list12[num33].Vertices[num34].Y, list12[num33].Vertices[num34].Z);
					bool flag6 = false;
					for (int num35 = 0; num35 <= list2.Count - 1; num35++)
					{
						if (buCompare5.EQ(pnt3D5, list2[num35].Position))
						{
							pnt2 = new Pnt3D(pnt3D5);
							_ = list2[num35].dX;
							_ = list2[num35].dY;
							pnt3D5 = new Pnt3D(pnt3D5.X + list2[num35].dX, pnt3D5.Y + list2[num35].dY, pnt3D5.Z);
							flag6 = true;
						}
					}
					if (!flag6)
					{
						Points2.Add(new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z));
						continue;
					}
					if (Points2.Count > 0)
					{
						Points2.Insert(0, new Pnt3D(pnt3D4));
						Points2.Add(new Pnt3D(pnt2));
						Pnt3D MinPoint4 = new Pnt3D();
						Pnt3D MidPoint4 = new Pnt3D();
						Pnt3D MaxPoint4 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points2, ref MinPoint4, ref MidPoint4, ref MaxPoint4);
						double num36 = 1.0;
						double num37 = 1.0;
						num36 = (pnt3D5.X - CopiedPnt3[CopiedPnt3.Count - 1].X) / (Points2[Points2.Count - 1].X - Points2[0].X);
						num37 = (pnt3D5.Y - CopiedPnt3[CopiedPnt3.Count - 1].Y) / (Points2[Points2.Count - 1].Y - Points2[0].Y);
						clsInit.cVector.Scale(pnt3D4, num36, num37, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points2);
						_ = CopiedPnt3[CopiedPnt3.Count - 1].X - Points2[0].X;
						_ = CopiedPnt3[CopiedPnt3.Count - 1].Y - Points2[0].Y;
						clsInit.cVector.Move(Points2[0], CopiedPnt3[CopiedPnt3.Count - 1], ref Points2);
						Points2.RemoveAt(0);
						Points2.RemoveAt(Points2.Count - 1);
						Pnt3D.Add(Points2, ref CopiedPnt3);
						Points2.Clear();
						Points2 = new List<Pnt3D>();
					}
					CopiedPnt3.Add(new Pnt3D(pnt3D5.X, pnt3D5.Y, pnt3D5.Z));
					pnt3D4 = new Pnt3D(pnt2);
				}
				EntityDataSet entData3 = new EntityDataSet(-1, varCutterSettings.InnerContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData3 = new CustomData((CustomData)list12[num33].EntityData);
				LinearPath Ent4 = new LinearPath();
				List<Point3D> CopiedPnt4 = new List<Point3D>();
				if (CopiedPnt3.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points2, ref CopiedPnt4);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt3, ref CopiedPnt4);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt4, entData3, customData3, ref Ent4);
				list13.Add(Ent4);
			}
			for (int num38 = 0; num38 <= list18.Count - 1; num38++)
			{
				List<Pnt3D> CopiedPnt5 = new List<Pnt3D>();
				List<Pnt3D> Points3 = new List<Pnt3D>();
				Pnt3D pnt3 = new Pnt3D();
				Pnt3D pnt3D6 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint5 = new Point3D();
				Point3D MidPoint5 = new Point3D();
				Point3D MaxPoint5 = new Point3D();
				_ = list18[num38] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list18[num38], ref MinPoint5, ref MidPoint5, ref MaxPoint5);
				for (int num39 = 0; num39 <= list18[num38].Vertices.Length - 1; num39++)
				{
					Pnt3D pnt3D7 = new Pnt3D(list18[num38].Vertices[num39].X, list18[num38].Vertices[num39].Y, list18[num38].Vertices[num39].Z);
					bool flag7 = false;
					for (int num40 = 0; num40 <= list5.Count - 1; num40++)
					{
						if (buCompare5.EQ(pnt3D7, list5[num40].Position))
						{
							pnt3 = new Pnt3D(pnt3D7);
							_ = list5[num40].dX;
							_ = list5[num40].dY;
							pnt3D7 = new Pnt3D(pnt3D7.X + list5[num40].dX, pnt3D7.Y + list5[num40].dY, pnt3D7.Z);
							flag7 = true;
						}
					}
					if (!flag7)
					{
						Points3.Add(new Pnt3D(pnt3D7.X, pnt3D7.Y, pnt3D7.Z));
						continue;
					}
					if (Points3.Count > 0)
					{
						Points3.Insert(0, new Pnt3D(pnt3D6));
						Points3.Add(new Pnt3D(pnt3));
						Pnt3D MinPoint6 = new Pnt3D();
						Pnt3D MidPoint6 = new Pnt3D();
						Pnt3D MaxPoint6 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points3, ref MinPoint6, ref MidPoint6, ref MaxPoint6);
						double num41 = 1.0;
						double num42 = 1.0;
						num41 = (pnt3D7.X - CopiedPnt5[CopiedPnt5.Count - 1].X) / (Points3[Points3.Count - 1].X - Points3[0].X);
						num42 = (pnt3D7.Y - CopiedPnt5[CopiedPnt5.Count - 1].Y) / (Points3[Points3.Count - 1].Y - Points3[0].Y);
						clsInit.cVector.Scale(pnt3D6, num41, num42, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points3);
						_ = CopiedPnt5[CopiedPnt5.Count - 1].X - Points3[0].X;
						_ = CopiedPnt5[CopiedPnt5.Count - 1].Y - Points3[0].Y;
						clsInit.cVector.Move(Points3[0], CopiedPnt5[CopiedPnt5.Count - 1], ref Points3);
						Points3.RemoveAt(0);
						Points3.RemoveAt(Points3.Count - 1);
						Pnt3D.Add(Points3, ref CopiedPnt5);
						Points3.Clear();
						Points3 = new List<Pnt3D>();
					}
					CopiedPnt5.Add(new Pnt3D(pnt3D7.X, pnt3D7.Y, pnt3D7.Z));
					pnt3D6 = new Pnt3D(pnt3);
				}
				EntityDataSet entData4 = new EntityDataSet(-1, varCutterSettings.InnerContourNoCutLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData4 = new CustomData((CustomData)list18[num38].EntityData);
				LinearPath Ent5 = new LinearPath();
				List<Point3D> CopiedPnt6 = new List<Point3D>();
				if (CopiedPnt5.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points3, ref CopiedPnt6);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt5, ref CopiedPnt6);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt6, entData4, customData4, ref Ent5);
				list19.Add(Ent5);
			}
			for (int num43 = 0; num43 <= list16.Count - 1; num43++)
			{
				List<Pnt3D> CopiedPnt7 = new List<Pnt3D>();
				List<Pnt3D> Points4 = new List<Pnt3D>();
				Pnt3D pnt4 = new Pnt3D();
				Pnt3D pnt3D8 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint7 = new Point3D();
				Point3D MidPoint7 = new Point3D();
				Point3D MaxPoint7 = new Point3D();
				_ = list16[num43] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list16[num43], ref MinPoint7, ref MidPoint7, ref MaxPoint7);
				for (int num44 = 0; num44 <= list16[num43].Vertices.Length - 1; num44++)
				{
					Pnt3D pnt3D9 = new Pnt3D(list16[num43].Vertices[num44].X, list16[num43].Vertices[num44].Y, list16[num43].Vertices[num44].Z);
					bool flag8 = false;
					for (int num45 = 0; num45 <= list4.Count - 1; num45++)
					{
						if (buCompare5.EQ(pnt3D9, list4[num45].Position))
						{
							pnt4 = new Pnt3D(pnt3D9);
							_ = list4[num45].dX;
							_ = list4[num45].dY;
							pnt3D9 = new Pnt3D(pnt3D9.X + list4[num45].dX, pnt3D9.Y + list4[num45].dY, pnt3D9.Z);
							flag8 = true;
						}
					}
					if (!flag8)
					{
						Points4.Add(new Pnt3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z));
						continue;
					}
					if (Points4.Count > 0)
					{
						Points4.Insert(0, new Pnt3D(pnt3D8));
						Points4.Add(new Pnt3D(pnt4));
						Pnt3D MinPoint8 = new Pnt3D();
						Pnt3D MidPoint8 = new Pnt3D();
						Pnt3D MaxPoint8 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points4, ref MinPoint8, ref MidPoint8, ref MaxPoint8);
						double num46 = 1.0;
						double num47 = 1.0;
						num46 = (pnt3D9.X - CopiedPnt7[CopiedPnt7.Count - 1].X) / (Points4[Points4.Count - 1].X - Points4[0].X);
						num47 = (pnt3D9.Y - CopiedPnt7[CopiedPnt7.Count - 1].Y) / (Points4[Points4.Count - 1].Y - Points4[0].Y);
						clsInit.cVector.Scale(pnt3D8, num46, num47, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points4);
						_ = CopiedPnt7[CopiedPnt7.Count - 1].X - Points4[0].X;
						_ = CopiedPnt7[CopiedPnt7.Count - 1].Y - Points4[0].Y;
						clsInit.cVector.Move(Points4[0], CopiedPnt7[CopiedPnt7.Count - 1], ref Points4);
						Points4.RemoveAt(0);
						Points4.RemoveAt(Points4.Count - 1);
						Pnt3D.Add(Points4, ref CopiedPnt7);
						Points4.Clear();
						Points4 = new List<Pnt3D>();
					}
					CopiedPnt7.Add(new Pnt3D(pnt3D9.X, pnt3D9.Y, pnt3D9.Z));
					pnt3D8 = new Pnt3D(pnt4);
				}
				EntityDataSet entData5 = new EntityDataSet(-1, varCutterSettings.RopeDirectionLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData5 = new CustomData((CustomData)list16[num43].EntityData);
				LinearPath Ent6 = new LinearPath();
				List<Point3D> CopiedPnt8 = new List<Point3D>();
				if (CopiedPnt7.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points4, ref CopiedPnt8);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt7, ref CopiedPnt8);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt8, entData5, customData5, ref Ent6);
				list17.Add(Ent6);
			}
			for (int num48 = 0; num48 <= list14.Count - 1; num48++)
			{
				Point3D MinPoint9 = new Point3D();
				Point3D MidPoint9 = new Point3D();
				Point3D MaxPoint9 = new Point3D();
				clsInit.cVector5.BoxSizeCalculate(list14[num48], ref MinPoint9, ref MidPoint9, ref MaxPoint9);
				Pnt3D pnt3D10 = new Pnt3D(((Circle)list14[num48]).Center.X, ((Circle)list14[num48]).Center.Y, ((Circle)list14[num48]).Center.Z);
				double radius = ((Circle)list14[num48]).Radius;
				for (int num49 = 0; num49 <= list3.Count - 1; num49++)
				{
					if (buCompare5.EQ(pnt3D10, list3[num49].Position))
					{
						pnt3D10 = new Pnt3D(pnt3D10.X + list3[num49].dX, pnt3D10.Y + list3[num49].dY, pnt3D10.Z);
					}
				}
				EntityDataSet entData6 = new EntityDataSet(-1, varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData6 = new CustomData((CustomData)list14[num48].EntityData);
				customData6.infoData = Properties.SizeList[l];
				Circle Ent7 = null;
				clsInit.appCommand.CreateCircle(new Point3D(pnt3D10.X, pnt3D10.Y, pnt3D10.Z), radius, Plane.XY, entData6, customData6, ref Ent7);
				list15.Add(Ent7);
			}
			for (int num50 = 0; num50 <= list20.Count - 1; num50++)
			{
				List<Pnt3D> CopiedPnt9 = new List<Pnt3D>();
				List<Pnt3D> Points5 = new List<Pnt3D>();
				Pnt3D pnt5 = new Pnt3D();
				Pnt3D pnt3D11 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint10 = new Point3D();
				Point3D MidPoint10 = new Point3D();
				Point3D MaxPoint10 = new Point3D();
				_ = list20[num50] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list20[num50], ref MinPoint10, ref MidPoint10, ref MaxPoint10);
				for (int num51 = 0; num51 <= list20[num50].Vertices.Length - 1; num51++)
				{
					Pnt3D pnt3D12 = new Pnt3D(list20[num50].Vertices[num51].X, list20[num50].Vertices[num51].Y, list20[num50].Vertices[num51].Z);
					bool flag9 = false;
					for (int num52 = 0; num52 <= list6.Count - 1; num52++)
					{
						if (buCompare5.EQ(pnt3D12, list6[num52].Position))
						{
							pnt5 = new Pnt3D(pnt3D12);
							_ = list6[num52].dX;
							_ = list6[num52].dY;
							pnt3D12 = new Pnt3D(pnt3D12.X + list6[num52].dX, pnt3D12.Y + list6[num52].dY, pnt3D12.Z);
							flag9 = true;
						}
					}
					if (!flag9)
					{
						Points5.Add(new Pnt3D(pnt3D12.X, pnt3D12.Y, pnt3D12.Z));
						continue;
					}
					if (Points5.Count > 0)
					{
						Points5.Insert(0, new Pnt3D(pnt3D11));
						Points5.Add(new Pnt3D(pnt5));
						Pnt3D MinPoint11 = new Pnt3D();
						Pnt3D MidPoint11 = new Pnt3D();
						Pnt3D MaxPoint11 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points5, ref MinPoint11, ref MidPoint11, ref MaxPoint11);
						double num53 = 1.0;
						double num54 = 1.0;
						num53 = (pnt3D12.X - CopiedPnt9[CopiedPnt9.Count - 1].X) / (Points5[Points5.Count - 1].X - Points5[0].X);
						num54 = (pnt3D12.Y - CopiedPnt9[CopiedPnt9.Count - 1].Y) / (Points5[Points5.Count - 1].Y - Points5[0].Y);
						clsInit.cVector.Scale(pnt3D11, num53, num54, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points5);
						_ = CopiedPnt9[CopiedPnt9.Count - 1].X - Points5[0].X;
						_ = CopiedPnt9[CopiedPnt9.Count - 1].Y - Points5[0].Y;
						clsInit.cVector.Move(Points5[0], CopiedPnt9[CopiedPnt9.Count - 1], ref Points5);
						Points5.RemoveAt(0);
						Points5.RemoveAt(Points5.Count - 1);
						Pnt3D.Add(Points5, ref CopiedPnt9);
						Points5.Clear();
						Points5 = new List<Pnt3D>();
					}
					CopiedPnt9.Add(new Pnt3D(pnt3D12.X, pnt3D12.Y, pnt3D12.Z));
					pnt3D11 = new Pnt3D(pnt5);
				}
				EntityDataSet entData7 = new EntityDataSet(-1, varCutterSettings.InnerContourPloter1LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData7 = new CustomData((CustomData)list20[num50].EntityData);
				LinearPath Ent8 = new LinearPath();
				List<Point3D> CopiedPnt10 = new List<Point3D>();
				if (CopiedPnt9.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points5, ref CopiedPnt10);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt9, ref CopiedPnt10);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt10, entData7, customData7, ref Ent8);
				list21.Add(Ent8);
			}
			for (int num55 = 0; num55 <= list22.Count - 1; num55++)
			{
				List<Pnt3D> CopiedPnt11 = new List<Pnt3D>();
				List<Pnt3D> Points6 = new List<Pnt3D>();
				Pnt3D pnt6 = new Pnt3D();
				Pnt3D pnt3D13 = new Pnt3D();
				new List<Pnt3D>();
				Point3D MinPoint12 = new Point3D();
				Point3D MidPoint12 = new Point3D();
				Point3D MaxPoint12 = new Point3D();
				_ = list22[num55] is ICurve;
				clsInit.cVector5.BoxSizeCalculate(list22[num55], ref MinPoint12, ref MidPoint12, ref MaxPoint12);
				for (int num56 = 0; num56 <= list22[num55].Vertices.Length - 1; num56++)
				{
					Pnt3D pnt3D14 = new Pnt3D(list22[num55].Vertices[num56].X, list22[num55].Vertices[num56].Y, list22[num55].Vertices[num56].Z);
					bool flag10 = false;
					for (int num57 = 0; num57 <= list7.Count - 1; num57++)
					{
						if (buCompare5.EQ(pnt3D14, list7[num57].Position))
						{
							pnt6 = new Pnt3D(pnt3D14);
							_ = list7[num57].dX;
							_ = list7[num57].dY;
							pnt3D14 = new Pnt3D(pnt3D14.X + list7[num57].dX, pnt3D14.Y + list7[num57].dY, pnt3D14.Z);
							flag10 = true;
						}
					}
					if (!flag10)
					{
						Points6.Add(new Pnt3D(pnt3D14.X, pnt3D14.Y, pnt3D14.Z));
						continue;
					}
					if (Points6.Count > 0)
					{
						Points6.Insert(0, new Pnt3D(pnt3D13));
						Points6.Add(new Pnt3D(pnt6));
						Pnt3D MinPoint13 = new Pnt3D();
						Pnt3D MidPoint13 = new Pnt3D();
						Pnt3D MaxPoint13 = new Pnt3D();
						clsInit.cVector.BoxSizeCalculate(Points6, ref MinPoint13, ref MidPoint13, ref MaxPoint13);
						double num58 = 1.0;
						double num59 = 1.0;
						num58 = (pnt3D14.X - CopiedPnt11[CopiedPnt11.Count - 1].X) / (Points6[Points6.Count - 1].X - Points6[0].X);
						num59 = (pnt3D14.Y - CopiedPnt11[CopiedPnt11.Count - 1].Y) / (Points6[Points6.Count - 1].Y - Points6[0].Y);
						clsInit.cVector.Scale(pnt3D13, num58, num59, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points6);
						_ = CopiedPnt11[CopiedPnt11.Count - 1].X - Points6[0].X;
						_ = CopiedPnt11[CopiedPnt11.Count - 1].Y - Points6[0].Y;
						clsInit.cVector.Move(Points6[0], CopiedPnt11[CopiedPnt11.Count - 1], ref Points6);
						Points6.RemoveAt(0);
						Points6.RemoveAt(Points6.Count - 1);
						Pnt3D.Add(Points6, ref CopiedPnt11);
						Points6.Clear();
						Points6 = new List<Pnt3D>();
					}
					CopiedPnt11.Add(new Pnt3D(pnt3D14.X, pnt3D14.Y, pnt3D14.Z));
					pnt3D13 = new Pnt3D(pnt6);
				}
				EntityDataSet entData8 = new EntityDataSet(-1, varCutterSettings.InnerContourPloter2LayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
				CustomData customData8 = new CustomData((CustomData)list22[num55].EntityData);
				LinearPath Ent9 = new LinearPath();
				List<Point3D> CopiedPnt12 = new List<Point3D>();
				if (CopiedPnt11.Count <= 0)
				{
					buConversion5.Pnt3DToPoint3D(Points6, ref CopiedPnt12);
				}
				else
				{
					buConversion5.Pnt3DToPoint3D(CopiedPnt11, ref CopiedPnt12);
				}
				clsInit.appCommand.CreatePolyLine(CopiedPnt12, entData8, customData8, ref Ent9);
				list23.Add(Ent9);
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		for (int num60 = 0; num60 <= list11.Count - 1; num60++)
		{
			ccVars.UndoDont = true;
			((CustomData)list11[num60].EntityData).typeDefination = entityTypeDefination.Cutting;
			clsInit.appCommand.AddEntity(list11[num60]);
		}
		for (int num61 = 0; num61 <= list25.Count - 1; num61++)
		{
			ccVars.UndoDont = true;
			((CustomData)list25[num61].EntityData).typeDefination = entityTypeDefination.Notch;
			clsInit.appCommand.AddEntity(list25[num61]);
		}
		for (int num62 = 0; num62 <= list13.Count - 1; num62++)
		{
			ccVars.UndoDont = true;
			((CustomData)list13[num62].EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
			clsInit.appCommand.AddEntity(list13[num62]);
		}
		for (int num63 = 0; num63 <= list21.Count - 1; num63++)
		{
			ccVars.UndoDont = true;
			clsInit.appCommand.AddEntity(list21[num63]);
			((CustomData)list21[num63].EntityData).typeDefination = entityTypeDefination.InnerAux;
		}
		for (int num64 = 0; num64 <= list23.Count - 1; num64++)
		{
			ccVars.UndoDont = true;
			((CustomData)list23[num64].EntityData).typeDefination = entityTypeDefination.InnerAux;
			clsInit.appCommand.AddEntity(list23[num64]);
		}
		for (int num65 = 0; num65 <= list17.Count - 1; num65++)
		{
			((CustomData)list17[num65].EntityData).typeDefination = entityTypeDefination.Direction;
			double num66 = Point3D.Distance(list17[num65].Vertices[0], list17[num65].Vertices[list17[num65].Vertices.Length - 1]);
			List<Entity> calcEntities = new List<Entity>();
			clsInit.cVector5.DrawWireArrow(list17[num65].Vertices[0], list17[num65].Vertices[list17[num65].Vertices.Length - 1], num66 * 0.1, 15.0, Plane.XY, ref calcEntities);
			for (int num67 = 0; num67 <= calcEntities.Count - 1; num67++)
			{
				Entity copiedEntity5 = calcEntities[num67];
				clsInit.cVector5.CopyEntityProperties(list17[num65], ref copiedEntity5);
				ccVars.UndoDont = true;
				clsInit.appCommand.AddEntity(copiedEntity5);
			}
		}
		for (int num68 = 0; num68 <= list24.Count - 1; num68++)
		{
			ccVars.UndoDont = true;
			bool flag11 = false;
			for (int num69 = 0; num69 <= list11.Count - 1; num69++)
			{
				_ = ((Text)list24[num68]).InsertionPoint;
				if (list11[num69].BoxMin == null)
				{
					list11[num69].Regen(new RegenParams(0.01, ccVars.Pages[ccVars.PageIndex].Form.viewportcad));
				}
				if (clsInit.cVector5.IsPointInsideBoxsize(((Text)list24[num68]).InsertionPoint, list11[num69].BoxMin, list11[num69].BoxMax, Plane.XY))
				{
					flag11 = true;
				}
			}
			((CustomData)list24[num68].EntityData).typeDefination = entityTypeDefination.Info;
			if (!flag11)
			{
				clsInit.appCommand.AddEntity(list24[num68]);
				continue;
			}
			list24[num68].LayerName = varCutterSettings.PartInfoLayerName;
			clsInit.appCommand.AddEntity(list24[num68]);
		}
		for (int num70 = 0; num70 <= list15.Count - 1; num70++)
		{
			ccVars.UndoDont = true;
			((CustomData)list15[num70].EntityData).typeDefination = entityTypeDefination.Drill;
			clsInit.appCommand.AddEntity(list15[num70]);
		}
	}

	public void ExtendEntitiesByRules()
	{
		List<RulStrectPoints> list = new List<RulStrectPoints>();
		List<RulStrectPoints> list2 = new List<RulStrectPoints>();
		List<RulStrectPoints> list3 = new List<RulStrectPoints>();
		List<RulStrectPoints> list4 = new List<RulStrectPoints>();
		List<RulStrectPoints> list5 = new List<RulStrectPoints>();
		List<RulStrectPoints> list6 = new List<RulStrectPoints>();
		List<RulStrectPoints> list7 = new List<RulStrectPoints>();
		List<RulStrectPoints> list8 = new List<RulStrectPoints>();
		List<CutterNotch> list9 = new List<CutterNotch>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		List<Entity> list10 = new List<Entity>();
		new List<Entity>();
		new List<Entity>();
		List<Entity> list11 = new List<Entity>();
		List<Entity> list12 = new List<Entity>();
		List<string> list13 = new List<string>();
		NotchList.Clear();
		NotchList = new List<CutterNotch>();
		FileInfo fileInfo = new FileInfo(ccVars.Pages[ccVars.PageIndex].FileName);
		List<ePoint> list14 = new List<ePoint>();
		if (fileInfo.Exists)
		{
			List<eEntities> RefEntities = new List<eEntities>();
			List<LayerBase> Layers = new List<LayerBase>();
			buFile.Dxf dxf = new buFile.Dxf();
			dxf.ReadDXF(fileInfo.FullName, ref RefEntities, ref Layers);
			for (int num = RefEntities.Count - 1; num >= 0; num--)
			{
				if (RefEntities[num].GetType() == typeof(ePoint))
				{
					eEntities CalcEnt = new ePoint();
					clsInit.cVector.Move(new Pnt3D(), new Pnt3D(ccVars.Pages[ccVars.PageIndex].MovedDistanceWhenImport), RefEntities[num], ref CalcEnt);
					CalcEnt.geoAngleXY = RefEntities[num].geoAngleXY;
					list14.Add((ePoint)CalcEnt);
				}
			}
		}
		Layer item = new Layer(varCutterSettings.NotchLayerName, Color.DarkRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item);
		Layer item2 = new Layer(varCutterSettings.InfoLayerName, Color.MediumVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item2);
		Layer item3 = new Layer(varCutterSettings.PartInfoLayerName, Color.PaleVioletRed);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers.Add(item3);
		if (Properties.SizeList.Count == 0)
		{
			Properties.SizeList.Add("");
		}
		List<Entity> copiedEnt = new List<Entity>();
		buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities, ref copiedEnt);
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Clear();
		ccVars.Pages[ccVars.PageIndex].OsnapPoints.Clear();
		ccVars.Pages[ccVars.PageIndex].OsnapTempPoints.Clear();
		string[] collection = varCutterSettings.ContourRuleScaleLayerName.Split(';');
		list13 = new List<string>(collection);
		for (int i = 0; i <= Properties.SizeList.Count - 1; i++)
		{
			list = new List<RulStrectPoints>();
			list2 = new List<RulStrectPoints>();
			list5 = new List<RulStrectPoints>();
			list4 = new List<RulStrectPoints>();
			list3 = new List<RulStrectPoints>();
			list6 = new List<RulStrectPoints>();
			list7 = new List<RulStrectPoints>();
			list8 = new List<RulStrectPoints>();
			List<CutterPart> list15 = new List<CutterPart>();
			new CutterPart();
			for (int j = 0; j <= copiedEnt.Count - 1; j++)
			{
				if (copiedEnt[j].GetType() == typeof(devDept.Eyeshot.Entities.Point))
				{
					list11.Add((Entity)copiedEnt[j].Clone());
				}
				if (copiedEnt[j] is ICurve && copiedEnt[j].LayerName == varCutterSettings.MirrorLayerName)
				{
					copiedEnt[j].Selected = true;
					list12.Add((Entity)copiedEnt[j].Clone());
				}
			}
			for (int k = 0; k <= copiedEnt.Count - 1; k++)
			{
				Entity entity = copiedEnt[k];
				if (copiedEnt[k] is devDept.Eyeshot.Entities.Point)
				{
					devDept.Eyeshot.Entities.Point point = copiedEnt[k] as devDept.Eyeshot.Entities.Point;
					for (int l = 0; l <= list14.Count - 1; l++)
					{
						if (!(buCompare5.EQ(list14[l].StartPoint.X, point.StartPoint.X, 0.01) & buCompare5.EQ(list14[l].StartPoint.Y, point.StartPoint.Y, 0.01)) || !((list14[l].auxText.IndexOf("39") >= 0) | (list14[l].auxText.IndexOf("50") >= 0)))
						{
							continue;
						}
						if (point.LayerName == varCutterSettings.NotchInsideLayerName)
						{
							CutterNotch cutterNotch = new CutterNotch();
							cutterNotch.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
							cutterNotch.NotchType = CutterNotchType.INotch;
							cutterNotch.Length = point.StartPoint.Z;
							cutterNotch.Direction = InOutType.Inside;
							cutterNotch.DirectionAngle = list14[l].geoAngleXY;
							list9.Add(cutterNotch);
							copiedEnt[k].Selected = true;
						}
						if (point.LayerName == varCutterSettings.NotchOutsideLayerName)
						{
							CutterNotch cutterNotch2 = new CutterNotch();
							cutterNotch2.Position = new Point3D(point.StartPoint.X, point.StartPoint.Y, 0.0);
							cutterNotch2.Length = point.StartPoint.Z;
							cutterNotch2.Direction = InOutType.Outside;
							cutterNotch2.DirectionAngle = list14[l].geoAngleXY;
							if (list14[l].auxText.IndexOf("39") < 0)
							{
								cutterNotch2.NotchType = CutterNotchType.INotch;
							}
							else
							{
								cutterNotch2.Width = list14[l].auxValue;
								cutterNotch2.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch2.Width / 2.0 / cutterNotch2.Length)) * 2.0;
								cutterNotch2.NotchType = CutterNotchType.VNotch;
							}
							list9.Add(cutterNotch2);
							copiedEnt[k].Selected = true;
						}
					}
				}
				if (!(entity is Text))
				{
					continue;
				}
				bool flag = false;
				Text text = entity as Text;
				for (int m = 0; m <= list13.Count - 1; m++)
				{
					if (!(text.LayerName == list13[m]) || text.TextString.IndexOf("#-") < 0)
					{
						continue;
					}
					copiedEnt[k].Selected = true;
					int no = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints = new RulStrectPoints();
					rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints.No = no;
					for (int n = 0; n <= Properties.RuleList.Count - 1; n++)
					{
						if (rulStrectPoints.No == Properties.RuleList[n].No)
						{
							rulStrectPoints.dX = Properties.RuleList[n].Position[i].X;
							rulStrectPoints.dY = Properties.RuleList[n].Position[i].Y;
						}
					}
					list.Add(rulStrectPoints);
					flag = true;
					for (int num2 = 0; num2 <= list9.Count - 1; num2++)
					{
						if (!buCompare5.EQ(buVector5.ToPoint3D(list9[num2].Position), text.InsertionPoint, 0.1))
						{
							continue;
						}
						no = Convert.ToInt32(text.TextString.Replace("#", ""));
						rulStrectPoints = new RulStrectPoints();
						rulStrectPoints.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
						rulStrectPoints.No = no;
						for (int num3 = 0; num3 <= Properties.RuleList.Count - 1; num3++)
						{
							if (rulStrectPoints.No == Properties.RuleList[num3].No)
							{
								rulStrectPoints.dX = Properties.RuleList[num3].Position[i].X;
								rulStrectPoints.dY = Properties.RuleList[num3].Position[i].Y;
							}
						}
						list8.Add(rulStrectPoints);
					}
				}
				if (((text.LayerName == varCutterSettings.InnerContourLayerName) | (text.LayerName == varCutterSettings.ContourRuleScaleLayerName)) && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no2 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints2 = new RulStrectPoints();
					rulStrectPoints2.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints2.No = no2;
					for (int num4 = 0; num4 <= Properties.RuleList.Count - 1; num4++)
					{
						if (rulStrectPoints2.No == Properties.RuleList[num4].No)
						{
							rulStrectPoints2.dX = Properties.RuleList[num4].Position[i].X;
							rulStrectPoints2.dY = Properties.RuleList[num4].Position[i].Y;
						}
					}
					list2.Add(rulStrectPoints2);
					flag = true;
				}
				if (((text.LayerName == varCutterSettings.InnerContourNoCutLayerName) | (text.LayerName == varCutterSettings.ContourRuleScaleLayerName)) && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no3 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints3 = new RulStrectPoints();
					rulStrectPoints3.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints3.No = no3;
					for (int num5 = 0; num5 <= Properties.RuleList.Count - 1; num5++)
					{
						if (rulStrectPoints3.No == Properties.RuleList[num5].No)
						{
							rulStrectPoints3.dX = Properties.RuleList[num5].Position[i].X;
							rulStrectPoints3.dY = Properties.RuleList[num5].Position[i].Y;
						}
					}
					list5.Add(rulStrectPoints3);
					flag = true;
				}
				if (text.LayerName == varCutterSettings.RopeDirectionLayerName && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no4 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints4 = new RulStrectPoints();
					rulStrectPoints4.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints4.No = no4;
					for (int num6 = 0; num6 <= Properties.RuleList.Count - 1; num6++)
					{
						if (rulStrectPoints4.No == Properties.RuleList[num6].No)
						{
							rulStrectPoints4.dX = Properties.RuleList[num6].Position[i].X;
							rulStrectPoints4.dY = Properties.RuleList[num6].Position[i].Y;
						}
					}
					list4.Add(rulStrectPoints4);
					flag = true;
				}
				if (text.LayerName == varCutterSettings.DrillLayerName && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no5 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints5 = new RulStrectPoints();
					rulStrectPoints5.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints5.No = no5;
					for (int num7 = 0; num7 <= Properties.RuleList.Count - 1; num7++)
					{
						if (rulStrectPoints5.No == Properties.RuleList[num7].No)
						{
							rulStrectPoints5.dX = Properties.RuleList[num7].Position[i].X;
							rulStrectPoints5.dY = Properties.RuleList[num7].Position[i].Y;
						}
					}
					list3.Add(rulStrectPoints5);
					flag = true;
				}
				if (((text.LayerName == varCutterSettings.InnerContourPloter1LayerName) | (text.LayerName == varCutterSettings.ContourRuleScaleLayerName)) && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no6 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints6 = new RulStrectPoints();
					rulStrectPoints6.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints6.No = no6;
					for (int num8 = 0; num8 <= Properties.RuleList.Count - 1; num8++)
					{
						if (rulStrectPoints6.No == Properties.RuleList[num8].No)
						{
							rulStrectPoints6.dX = Properties.RuleList[num8].Position[i].X;
							rulStrectPoints6.dY = Properties.RuleList[num8].Position[i].Y;
						}
					}
					list6.Add(rulStrectPoints6);
					flag = true;
				}
				if (((text.LayerName == varCutterSettings.InnerContourPloter2LayerName) | (text.LayerName == varCutterSettings.ContourRuleScaleLayerName)) && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no7 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints7 = new RulStrectPoints();
					rulStrectPoints7.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints7.No = no7;
					for (int num9 = 0; num9 <= Properties.RuleList.Count - 1; num9++)
					{
						if (rulStrectPoints7.No == Properties.RuleList[num9].No)
						{
							rulStrectPoints7.dX = Properties.RuleList[num9].Position[i].X;
							rulStrectPoints7.dY = Properties.RuleList[num9].Position[i].Y;
						}
					}
					list7.Add(rulStrectPoints7);
					flag = true;
				}
				if (((text.LayerName == varCutterSettings.NotchInsideLayerName) | (text.LayerName == varCutterSettings.NotchOutsideLayerName)) && text.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[k].Selected = true;
					int no8 = Convert.ToInt32(text.TextString.Replace("#", ""));
					RulStrectPoints rulStrectPoints8 = new RulStrectPoints();
					rulStrectPoints8.Position = new Pnt3D(text.InsertionPoint.X, text.InsertionPoint.Y, text.InsertionPoint.Z);
					rulStrectPoints8.No = no8;
					for (int num10 = 0; num10 <= Properties.RuleList.Count - 1; num10++)
					{
						if (rulStrectPoints8.No == Properties.RuleList[num10].No)
						{
							rulStrectPoints8.dX = Properties.RuleList[num10].Position[i].X;
							rulStrectPoints8.dY = Properties.RuleList[num10].Position[i].Y;
						}
					}
					list8.Add(rulStrectPoints8);
					flag = true;
				}
				if (flag)
				{
					copiedEnt[k].Selected = true;
				}
			}
			for (int num11 = 0; num11 <= copiedEnt.Count - 1; num11++)
			{
				Entity entity2 = copiedEnt[num11];
				if (!(copiedEnt[num11] is ICurve) || !(entity2.LayerName == varCutterSettings.ContourLayerName))
				{
					continue;
				}
				if (list12.Count > 0)
				{
					List<RulStrectPoints> list16 = new List<RulStrectPoints>();
					List<CutterNotch> list17 = new List<CutterNotch>();
					for (int num12 = 0; num12 <= list12.Count - 1; num12++)
					{
						Point3D startPoint = ((ICurve)list12[num12]).StartPoint;
						Point3D endPoint = ((ICurve)list12[num12]).EndPoint;
						Point3D value = clsInit.cVector5.MiddlePointOfLine(startPoint, endPoint);
						List<Point3D> PointList = new List<Point3D>();
						buVector5.VerticeToPointsList(entity2.Vertices, ref PointList);
						bool flag2 = false;
						for (int num13 = 1; num13 <= PointList.Count - 1; num13++)
						{
							Point3D value2 = clsInit.cVector5.MiddlePointOfLine(PointList[num13 - 1], PointList[num13]);
							if (buCompare5.EQ(value, value2))
							{
								PointList.RemoveAt(num13);
								flag2 = true;
							}
						}
						if (!flag2)
						{
							Point3D value3 = clsInit.cVector5.MiddlePointOfLine(PointList[0], PointList[PointList.Count - 1]);
							if (buCompare5.EQ(value, value3))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num12], PointList[0], 0.1))
							{
								flag2 = true;
							}
							if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num12], PointList[PointList.Count - 1], 0.1))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							continue;
						}
						for (int num14 = 0; num14 <= list.Count - 1; num14++)
						{
							Point3D refPoint = new Point3D(list[num14].Position.X, list[num14].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)entity2, refPoint, 0.1))
							{
								RulStrectPoints rulStrectPoints9 = new RulStrectPoints(list[num14]);
								Point3D mirrorPoint = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint, ref mirrorPoint);
								rulStrectPoints9.Position = new Pnt3D(mirrorPoint.X, mirrorPoint.Y);
								rulStrectPoints9.dY = 0.0 - list[num14].dY;
								list16.Add(rulStrectPoints9);
							}
						}
						if (list16.Count > 0)
						{
							for (int num15 = 0; num15 <= list16.Count - 1; num15++)
							{
								bool flag3 = false;
								for (int num16 = 0; num16 <= list.Count - 1; num16++)
								{
									if (buCompare5.EQ(list[num16].Position, list16[num15].Position, 0.1))
									{
										flag3 = true;
										num16 = list.Count;
									}
								}
								if (!flag3)
								{
									list.Add(new RulStrectPoints(list16[num15]));
								}
							}
						}
						for (int num17 = 0; num17 <= list9.Count - 1; num17++)
						{
							Point3D refPoint2 = new Point3D(list9[num17].Position.X, list9[num17].Position.Y);
							if (clsInit.cVector5.isPointInsideEntity((ICurve)entity2, refPoint2, 0.1))
							{
								CutterNotch cutterNotch3 = new CutterNotch(list9[num17]);
								Point3D mirrorPoint2 = new Point3D();
								clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, refPoint2, ref mirrorPoint2);
								cutterNotch3.Position = new Point3D(mirrorPoint2.X, mirrorPoint2.Y);
								cutterNotch3.DirectionAngle += 180.0;
								list17.Add(cutterNotch3);
							}
						}
						if (list17.Count > 0)
						{
							for (int num18 = 0; num18 <= list17.Count - 1; num18++)
							{
								bool flag4 = false;
								for (int num19 = 0; num19 <= list9.Count - 1; num19++)
								{
									if (buCompare5.EQ(list9[num19].Position, list17[num18].Position, 0.1))
									{
										flag4 = true;
										num19 = list9.Count;
									}
								}
								if (!flag4)
								{
									list9.Add(new CutterNotch(list17[num18]));
								}
							}
						}
						List<Point3D> mirrorPoint3 = new List<Point3D>();
						clsInit.cVector5.Mirror(startPoint, endPoint, Plane.XY, PointList, ref mirrorPoint3);
						mirrorPoint3.Reverse();
						PointList.AddRange(mirrorPoint3);
						clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList);
						Entity copiedEntity = new LinearPath(PointList);
						clsInit.cVector5.CopyEntityProperties(entity2, ref copiedEntity);
						entity2 = copiedEntity;
					}
				}
				if (entity2.BoxMin == null)
				{
					entity2.Regen(0.01);
				}
				CutterPart cutterPart = new CutterPart();
				Entity copiedEntity2 = null;
				buEntity.Copy(entity2, ref copiedEntity2);
				cutterPart.Cut = copiedEntity2;
				cutterPart.pntMin = buVector5.ToPoint3D(entity2.BoxMin);
				cutterPart.pntMax = buVector5.ToPoint3D(entity2.BoxMax);
				copiedEnt[num11].Selected = true;
				list15.Add(cutterPart);
			}
			for (int num20 = 0; num20 <= copiedEnt.Count - 1; num20++)
			{
				Entity entity3 = copiedEnt[num20];
				if (entity3.BoxMax == null)
				{
					entity3.Regen(0.01);
				}
				if (copiedEnt[num20] is ICurve)
				{
					if (entity3.LayerName == varCutterSettings.InnerContourLayerName)
					{
						for (int num21 = 0; num21 <= list15.Count - 1; num21++)
						{
							if (clsInit.cVector5.isBoxSizeInsideBoxSize(list15[num21].pntMin, list15[num21].pntMax, entity3.BoxMin, entity3.BoxMax, Plane.XY))
							{
								Entity copiedEntity3 = null;
								buEntity.Copy(entity3, ref copiedEntity3);
								list15[num21].InnerCut.Add(copiedEntity3);
								num21 = list15.Count;
							}
						}
						copiedEnt[num20].Selected = true;
					}
					if (entity3.LayerName == varCutterSettings.ContourRefLayerName)
					{
						copiedEnt[num20].Selected = true;
					}
					if (entity3.LayerName == varCutterSettings.InnerContourRefLayerName)
					{
						copiedEnt[num20].Selected = true;
					}
					if (entity3.LayerName == varCutterSettings.RopeDirectionLayerName)
					{
						for (int num22 = 0; num22 <= list15.Count - 1; num22++)
						{
							if (clsInit.cVector5.isBoxSizeInsideBoxSize(list15[num22].pntMin, list15[num22].pntMax, entity3.BoxMin, entity3.BoxMax, Plane.XY))
							{
								Entity copiedEntity4 = null;
								buEntity.Copy(entity3, ref copiedEntity4);
								list15[num22].RopeDirection.Add(copiedEntity4);
								num22 = list15.Count;
							}
						}
						copiedEnt[num20].Selected = true;
					}
					if (entity3.LayerName == varCutterSettings.InnerContourNoCutLayerName)
					{
						for (int num23 = 0; num23 <= list15.Count - 1; num23++)
						{
							if (clsInit.cVector5.isBoxSizeInsideBoxSize(list15[num23].pntMin, list15[num23].pntMax, entity3.BoxMin, entity3.BoxMax, Plane.XY))
							{
								Entity copiedEntity5 = null;
								buEntity.Copy(entity3, ref copiedEntity5);
								list15[num23].InnerNoCut.Add(copiedEntity5);
								num23 = list15.Count;
							}
						}
						copiedEnt[num20].Selected = false;
					}
					if (entity3.LayerName == varCutterSettings.InnerContourPloter1LayerName)
					{
						for (int num24 = 0; num24 <= list15.Count - 1; num24++)
						{
							if (!clsInit.cVector5.isBoxSizeInsideBoxSize(list15[num24].pntMin, list15[num24].pntMax, entity3.BoxMin, entity3.BoxMax, Plane.XY))
							{
								continue;
							}
							if (list12.Count > 0)
							{
								for (int num25 = 0; num25 <= list12.Count - 1; num25++)
								{
									Point3D startPoint2 = ((ICurve)list12[num25]).StartPoint;
									Point3D endPoint2 = ((ICurve)list12[num25]).EndPoint;
									Point3D value4 = clsInit.cVector5.MiddlePointOfLine(startPoint2, endPoint2);
									List<Point3D> PointList2 = new List<Point3D>();
									buVector5.VerticeToPointsList(entity3.Vertices, ref PointList2);
									bool flag5 = false;
									for (int num26 = 1; num26 <= PointList2.Count - 1; num26++)
									{
										Point3D value5 = clsInit.cVector5.MiddlePointOfLine(PointList2[num26 - 1], PointList2[num26]);
										if (buCompare5.EQ(value4, value5))
										{
											PointList2.RemoveAt(num26);
											flag5 = true;
										}
									}
									if (!flag5)
									{
										Point3D value6 = clsInit.cVector5.MiddlePointOfLine(PointList2[0], PointList2[PointList2.Count - 1]);
										if (buCompare5.EQ(value4, value6))
										{
											flag5 = true;
										}
									}
									if (!flag5)
									{
										if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num25], PointList2[0], 0.1))
										{
											flag5 = true;
										}
										if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num25], PointList2[PointList2.Count - 1], 0.1))
										{
											flag5 = true;
										}
									}
									if (flag5)
									{
										List<Point3D> mirrorPoint4 = new List<Point3D>();
										clsInit.cVector5.Mirror(startPoint2, endPoint2, Plane.XY, PointList2, ref mirrorPoint4);
										mirrorPoint4.Reverse();
										PointList2.AddRange(mirrorPoint4);
										clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList2);
										Entity copiedEntity6 = new LinearPath(PointList2);
										clsInit.cVector5.CopyEntityProperties(entity3, ref copiedEntity6);
										entity3 = copiedEntity6;
									}
								}
							}
							Entity copiedEntity7 = null;
							buEntity.Copy(entity3, ref copiedEntity7);
							list15[num24].Plotter1.Add(copiedEntity7);
							num24 = list15.Count;
						}
						copiedEnt[num20].Selected = true;
					}
					if (entity3.LayerName == varCutterSettings.InnerContourPloter2LayerName)
					{
						for (int num27 = 0; num27 <= list15.Count - 1; num27++)
						{
							if (!clsInit.cVector5.isBoxSizeInsideBoxSize(list15[num27].pntMin, list15[num27].pntMax, entity3.BoxMin, entity3.BoxMax, Plane.XY))
							{
								continue;
							}
							if (list12.Count > 0)
							{
								for (int num28 = 0; num28 <= list12.Count - 1; num28++)
								{
									Point3D startPoint3 = ((ICurve)list12[num28]).StartPoint;
									Point3D endPoint3 = ((ICurve)list12[num28]).EndPoint;
									Point3D value7 = clsInit.cVector5.MiddlePointOfLine(startPoint3, endPoint3);
									List<Point3D> PointList3 = new List<Point3D>();
									buVector5.VerticeToPointsList(entity3.Vertices, ref PointList3);
									bool flag6 = false;
									for (int num29 = 1; num29 <= PointList3.Count - 1; num29++)
									{
										Point3D value8 = clsInit.cVector5.MiddlePointOfLine(PointList3[num29 - 1], PointList3[num29]);
										if (buCompare5.EQ(value7, value8))
										{
											PointList3.RemoveAt(num29);
											flag6 = true;
										}
									}
									if (!flag6)
									{
										Point3D value9 = clsInit.cVector5.MiddlePointOfLine(PointList3[0], PointList3[PointList3.Count - 1]);
										if (buCompare5.EQ(value7, value9))
										{
											flag6 = true;
										}
									}
									if (!flag6)
									{
										if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num28], PointList3[0], 0.1))
										{
											flag6 = true;
										}
										if (clsInit.cVector5.isPointInsideEntity((ICurve)list12[num28], PointList3[PointList3.Count - 1], 0.1))
										{
											flag6 = true;
										}
									}
									if (flag6)
									{
										List<Point3D> mirrorPoint5 = new List<Point3D>();
										clsInit.cVector5.Mirror(startPoint3, endPoint3, Plane.XY, PointList3, ref mirrorPoint5);
										mirrorPoint5.Reverse();
										PointList3.AddRange(mirrorPoint5);
										clsInit.cVector5.CheckDuplicatedPointsWithPrevious(ref PointList3);
										Entity copiedEntity8 = new LinearPath(PointList3);
										clsInit.cVector5.CopyEntityProperties(entity3, ref copiedEntity8);
										entity3 = copiedEntity8;
									}
								}
							}
							Entity copiedEntity9 = null;
							buEntity.Copy(entity3, ref copiedEntity9);
							list15[num27].Plotter2.Add(copiedEntity9);
							num27 = list15.Count;
						}
						copiedEnt[num20].Selected = true;
					}
				}
				if (!(entity3 is Text))
				{
					continue;
				}
				bool flag7 = false;
				Text text2 = entity3 as Text;
				if (entity3.LayerName == varCutterSettings.DrillLayerName && text2.TextString.IndexOf("#-") >= 0)
				{
					double num30 = 5.0;
					for (int num31 = 0; num31 <= list11.Count - 1; num31++)
					{
						if (list11[num31].LayerName == varCutterSettings.DrillLayerName && buCompare5.EQ(text2.InsertionPoint, ((devDept.Eyeshot.Entities.Point)list11[num31]).StartPoint, Plane.XY) && ((devDept.Eyeshot.Entities.Point)list11[num31]).StartPoint.Z > 0.0)
						{
							num30 = ((devDept.Eyeshot.Entities.Point)list11[num31]).StartPoint.Z;
						}
					}
					Circle circle = new Circle(text2.InsertionPoint, num30 / 2.0);
					for (int num32 = 0; num32 <= list15.Count - 1; num32++)
					{
						if (clsInit.cVector5.IsPointInsideBoxsize(circle.Center, list15[num32].pntMin, list15[num32].pntMax, Plane.XY))
						{
							Entity copiedEntity10 = null;
							buEntity.Copy(circle, ref copiedEntity10);
							list15[num32].Drill.Add(copiedEntity10);
							num32 = list15.Count;
						}
					}
					copiedEnt[num20].Selected = true;
					flag7 = true;
				}
				if (!varCutterSettings.AddAttribute && entity3 is devDept.Eyeshot.Entities.Attribute)
				{
					copiedEnt[num20].Selected = true;
					flag7 = true;
				}
				if (!flag7 && text2.TextString.IndexOf("#-") >= 0)
				{
					copiedEnt[num20].Selected = true;
					flag7 = true;
				}
				if (!flag7 && i == 0)
				{
					copiedEnt[num20].Selected = true;
					Text text3 = (Text)entity3.Clone();
					text3.LayerName = varCutterSettings.InfoLayerName;
					list10.Add(text3);
				}
			}
			for (int num33 = 0; num33 <= list15.Count - 1; num33++)
			{
				for (int num34 = 0; num34 <= list9.Count - 1; num34++)
				{
					if (clsInit.cVector5.isPointOverEntity((ICurve)list15[num33].Cut, list9[num34].Position, 0.1))
					{
						list15[num33].Notch.Add(new CutterNotch(list9[num34]));
					}
				}
			}
			clsInit.appCommand.undoBuffer();
			Entity entCalculted = null;
			for (int num35 = 0; num35 <= list15.Count - 1; num35++)
			{
				ccVars.UndoDont = true;
				ScaleEntityFromStrectPoints(list15[num35].Cut, list, ref entCalculted);
				if (entCalculted.BoxMax == null)
				{
					entCalculted.Regen(0.01);
				}
				string text4 = "Cut" + num35 + Properties.SizeList[i];
				entCalculted.LayerName = varCutterSettings.ContourLayerName;
				((CustomData)entCalculted.EntityData).typeDefination = entityTypeDefination.Cutting;
				((CustomData)entCalculted.EntityData).EntityName = text4;
				((CustomData)entCalculted.EntityData).ActionName = "OutterEntity";
				((CustomData)entCalculted.EntityData).Tags = "";
				((CustomData)entCalculted.EntityData).infoData = Properties.SizeList[i];
				Entity copiedEntity11 = null;
				buEntity.Copy(entCalculted, ref copiedEntity11);
				list15[num35].Cut = copiedEntity11;
				clsInit.appCommand.AddEntity(entCalculted);
				for (int num36 = 0; num36 <= list15[num35].InnerCut.Count - 1; num36++)
				{
					ccVars.UndoDont = true;
					Entity entCalculted2 = null;
					ScaleEntityFromStrectPoints(list15[num35].InnerCut[num36], list2, ref entCalculted2);
					entCalculted2.LayerName = varCutterSettings.InnerContourLayerName;
					((CustomData)entCalculted2.EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
					((CustomData)entCalculted2.EntityData).EntityName = "InnerCut" + num36;
					((CustomData)entCalculted2.EntityData).ActionName = "InnerEntity";
					((CustomData)entCalculted2.EntityData).Tags = text4;
					clsInit.appCommand.AddEntity(entCalculted2);
				}
				for (int num37 = 0; num37 <= list15[num35].InnerNoCut.Count - 1; num37++)
				{
					ccVars.UndoDont = true;
					Entity entCalculted3 = null;
					ScaleEntityFromStrectPoints(list15[num35].InnerNoCut[num37], list5, ref entCalculted3);
					entCalculted3.LayerName = varCutterSettings.InnerContourNoCutLayerName;
					((CustomData)entCalculted3.EntityData).typeDefination = entityTypeDefination.InnerContourCenter;
					((CustomData)entCalculted3.EntityData).EntityName = "InnerNoCut" + num37;
					((CustomData)entCalculted3.EntityData).ActionName = "InnerEntity";
					((CustomData)entCalculted3.EntityData).Tags = text4;
					entCalculted3.Selectable = false;
					clsInit.appCommand.AddEntity(entCalculted3);
				}
				for (int num38 = 0; num38 <= list15[num35].Plotter1.Count - 1; num38++)
				{
					ccVars.UndoDont = true;
					Entity entCalculted4 = null;
					ScaleEntityFromStrectPoints(list15[num35].Plotter1[num38], list6, ref entCalculted4);
					entCalculted4.LayerName = varCutterSettings.InnerContourPloter1LayerName;
					((CustomData)entCalculted4.EntityData).EntityName = "Plotter1" + num38;
					((CustomData)entCalculted4.EntityData).ActionName = "InnerEntity";
					((CustomData)entCalculted4.EntityData).Tags = text4;
					((CustomData)entCalculted4.EntityData).typeDefination = entityTypeDefination.InnerAux;
					clsInit.appCommand.AddEntity(entCalculted4);
				}
				for (int num39 = 0; num39 <= list15[num35].Plotter2.Count - 1; num39++)
				{
					ccVars.UndoDont = true;
					Entity entCalculted5 = null;
					ScaleEntityFromStrectPoints(list15[num35].Plotter2[num39], list7, ref entCalculted5);
					entCalculted5.LayerName = varCutterSettings.InnerContourPloter2LayerName;
					((CustomData)entCalculted5.EntityData).EntityName = "Plotter2" + num39;
					((CustomData)entCalculted5.EntityData).ActionName = "InnerEntity";
					((CustomData)entCalculted5.EntityData).Tags = text4;
					((CustomData)entCalculted5.EntityData).typeDefination = entityTypeDefination.InnerAux;
					clsInit.appCommand.AddEntity(entCalculted5);
				}
				for (int num40 = 0; num40 <= list15[num35].Drill.Count - 1; num40++)
				{
					ccVars.UndoDont = true;
					Entity entCalculted6 = null;
					ScaleDrillFromStrectPoints(list15[num35].Drill[num40], list3, ref entCalculted6);
					entCalculted6.LayerName = varCutterSettings.InnerContourPloter1LayerName;
					((CustomData)entCalculted6.EntityData).EntityName = "Drill" + num40;
					((CustomData)entCalculted6.EntityData).ActionName = "InnerEntity";
					((CustomData)entCalculted6.EntityData).Tags = text4;
					((CustomData)entCalculted6.EntityData).typeDefination = entityTypeDefination.DrillAux;
					clsInit.appCommand.AddEntity(entCalculted6);
				}
				for (int num41 = 0; num41 <= list15[num35].RopeDirection.Count - 1; num41++)
				{
					ccVars.UndoDont = true;
					Point3D point3D = buVector5.ToPoint3D(((ICurve)list15[num35].RopeDirection[num41]).StartPoint);
					Point3D point3D2 = buVector5.ToPoint3D(((ICurve)list15[num35].RopeDirection[num41]).EndPoint);
					double num42 = Point3D.Distance(point3D, point3D2);
					List<Entity> calcEntities = new List<Entity>();
					clsInit.cVector5.DrawWireArrow(point3D, point3D2, num42 * 0.1, 15.0, Plane.XY, ref calcEntities);
					for (int num43 = 0; num43 <= calcEntities.Count - 1; num43++)
					{
						Entity entCalculted7 = null;
						ScaleEntityFromStrectPoints(calcEntities[num43], list4, ref entCalculted7);
						entCalculted7.LayerName = varCutterSettings.RopeDirectionLayerName;
						((CustomData)entCalculted7.EntityData).typeDefination = entityTypeDefination.Direction;
						((CustomData)entCalculted7.EntityData).EntityName = "RopeDir" + num41;
						((CustomData)entCalculted7.EntityData).ActionName = "InnerEntity";
						((CustomData)entCalculted7.EntityData).Tags = text4;
						clsInit.appCommand.AddEntity(entCalculted7);
					}
				}
				for (int num44 = 0; num44 <= list15[num35].Notch.Count - 1; num44++)
				{
					List<Entity> notchEntities = new List<Entity>();
					CutterNotch calcNotch = new CutterNotch();
					ScaleNotchFromStrectPoints(list15[num35].Notch[num44], list8, ref calcNotch);
					clsInit.cCutter.CreateNotch(calcNotch.NotchType, buVector5.ToPoint3D(calcNotch.Position), calcNotch.Length, calcNotch.DirectionAngle, calcNotch.Angle, (ICurve)list15[num35].Cut, ref notchEntities);
					for (int num45 = 0; num45 <= notchEntities.Count - 1; num45++)
					{
						ccVars.UndoDont = true;
						Entity copiedEntity12 = null;
						buEntity.Copy(notchEntities[num45], ref copiedEntity12);
						copiedEntity12.LayerName = varCutterSettings.NotchLayerName;
						((CustomData)copiedEntity12.EntityData).EntityName = "Notch" + num44;
						((CustomData)copiedEntity12.EntityData).ActionName = "InnerEntity";
						((CustomData)copiedEntity12.EntityData).Tags = text4;
						((CustomData)copiedEntity12.EntityData).typeDefination = entityTypeDefination.Notch;
						((CustomData)copiedEntity12.EntityData).infoBasePoint = new Point3D(list9[num45].Position.X, list9[num45].Position.Y, list9[num45].Position.Z);
						((CustomData)copiedEntity12.EntityData).infoLength = list9[num45].Length;
						((CustomData)copiedEntity12.EntityData).infoWidth = list9[num45].Width;
						((CustomData)copiedEntity12.EntityData).infoAngle = list9[num45].Angle;
						((CustomData)copiedEntity12.EntityData).infoDirection = list9[num45].DirectionAngle;
						((CustomData)copiedEntity12.EntityData).infoString = list9[num45].NotchType.ToString();
						clsInit.appCommand.AddEntity(copiedEntity12);
					}
				}
			}
			if (i != 0)
			{
				continue;
			}
			for (int num46 = 0; num46 <= list10.Count - 1; num46++)
			{
				ccVars.UndoDont = true;
				Entity entity4 = null;
				entity4 = buVector5.CopyEntities(list10[num46]);
				Point3D point2 = buVector5.ToPoint3D(((Text)list10[num46]).InsertionPoint);
				bool flag8 = false;
				for (int num47 = 0; num47 <= list15.Count - 1; num47++)
				{
					Entity copiedEntity13 = null;
					buEntity.Copy(list15[num47].Cut, ref copiedEntity13);
					copiedEntity13.Regen(0.01);
					if (clsInit.cVector5.IsPointInsideBoxsize(point2, copiedEntity13.BoxMin, copiedEntity13.BoxMax, Plane.XY))
					{
						flag8 = true;
						num47 = list15.Count;
					}
				}
				if (!flag8)
				{
					entity4.LayerName = varCutterSettings.InfoLayerName;
				}
				else
				{
					entity4.LayerName = varCutterSettings.PartInfoLayerName;
				}
				((CustomData)entity4.EntityData).typeDefination = entityTypeDefination.Text;
				clsInit.appCommand.AddEntity(entity4);
			}
		}
	}

	public void ScaleEntityFromStrectPoints(Entity refEntity, List<RulStrectPoints> StrectPnt, ref Entity entCalculted)
	{
		List<Pnt3D> CopiedPnt = new List<Pnt3D>();
		List<Pnt3D> Points = new List<Pnt3D>();
		Pnt3D pnt = new Pnt3D();
		Pnt3D pnt3D = new Pnt3D();
		new List<Pnt3D>();
		new Point3D();
		new Point3D();
		new Point3D();
		Entity entity = null;
		buEntity.Copy(refEntity);
		for (int i = 0; i <= entity.Vertices.Length - 1; i++)
		{
			Pnt3D pnt3D2 = new Pnt3D(entity.Vertices[i].X, entity.Vertices[i].Y, entity.Vertices[i].Z);
			bool flag = false;
			for (int j = 0; j <= StrectPnt.Count - 1; j++)
			{
				if (buCompare5.EQ(pnt3D2, StrectPnt[j].Position))
				{
					pnt = new Pnt3D(pnt3D2);
					_ = StrectPnt[j].dX;
					_ = StrectPnt[j].dY;
					pnt3D2 = new Pnt3D(pnt3D2.X + StrectPnt[j].dX, pnt3D2.Y + StrectPnt[j].dY, pnt3D2.Z);
					flag = true;
				}
			}
			if (!flag)
			{
				Points.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
				continue;
			}
			if ((Points.Count > 0) & (CopiedPnt.Count > 0))
			{
				Points.Insert(0, new Pnt3D(pnt3D));
				Points.Add(new Pnt3D(pnt));
				Pnt3D MinPoint = new Pnt3D();
				Pnt3D MidPoint = new Pnt3D();
				Pnt3D MaxPoint = new Pnt3D();
				clsInit.cVector.BoxSizeCalculate(Points, ref MinPoint, ref MidPoint, ref MaxPoint);
				double num = 1.0;
				double num2 = 1.0;
				_ = pnt3D2.X - CopiedPnt[CopiedPnt.Count - 1].X;
				_ = pnt3D2.Y - CopiedPnt[CopiedPnt.Count - 1].Y;
				_ = Points[Points.Count - 1].X - Points[0].X;
				_ = Points[Points.Count - 1].Y - Points[0].Y;
				num = (pnt3D2.X - CopiedPnt[CopiedPnt.Count - 1].X) / (Points[Points.Count - 1].X - Points[0].X);
				num2 = (pnt3D2.Y - CopiedPnt[CopiedPnt.Count - 1].Y) / (Points[Points.Count - 1].Y - Points[0].Y);
				clsInit.cVector.Scale(pnt3D, num, num2, 1.0, ScaleX: true, ScaleY: true, ScaleZ: false, ref Points);
				_ = CopiedPnt[CopiedPnt.Count - 1].X - Points[0].X;
				_ = CopiedPnt[CopiedPnt.Count - 1].Y - Points[0].Y;
				clsInit.cVector.Move(Points[0], CopiedPnt[CopiedPnt.Count - 1], ref Points);
				Points.RemoveAt(0);
				Points.RemoveAt(Points.Count - 1);
				Pnt3D.Add(Points, ref CopiedPnt);
				Points.Clear();
				Points = new List<Pnt3D>();
			}
			if ((Points.Count > 0) & (CopiedPnt.Count == 0))
			{
				Points.Add(new Pnt3D(pnt3D2));
				Pnt3D.Add(Points, ref CopiedPnt);
				Points.Clear();
				Points = new List<Pnt3D>();
			}
			CopiedPnt.Add(new Pnt3D(pnt3D2.X, pnt3D2.Y, pnt3D2.Z));
			pnt3D = new Pnt3D(pnt);
		}
		if (Points.Count > 0)
		{
			Pnt3D.Add(Points, ref CopiedPnt);
		}
		EntityDataSet entData = new EntityDataSet(-1, varCutterSettings.ContourLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
		CustomData customData = new CustomData((CustomData)entity.EntityData);
		LinearPath Ent = new LinearPath();
		List<Point3D> CopiedPnt2 = new List<Point3D>();
		if (CopiedPnt.Count <= 0)
		{
			buConversion5.Pnt3DToPoint3D(Points, ref CopiedPnt2);
		}
		else
		{
			buConversion5.Pnt3DToPoint3D(CopiedPnt, ref CopiedPnt2);
		}
		clsInit.appCommand.CreatePolyLine(CopiedPnt2, entData, customData, ref Ent);
		Ent.EntityData = customData;
		entCalculted = Ent;
	}

	public void ScaleNotchFromStrectPoints(CutterNotch refNotch, List<RulStrectPoints> StrectPnt, ref CutterNotch calcNotch)
	{
		new Pnt3D();
		new Pnt3D();
		Pnt3D pnt3D = new Pnt3D(refNotch.Position.X, refNotch.Position.Y, refNotch.Position.Z);
		calcNotch = new CutterNotch(refNotch);
		for (int i = 0; i <= StrectPnt.Count - 1; i++)
		{
			if (buCompare5.EQ(StrectPnt[i].Position, new Pnt3D(refNotch.Position.X, refNotch.Position.Y, refNotch.Position.Z)))
			{
				new Pnt3D(pnt3D);
				_ = StrectPnt[i].dX;
				_ = StrectPnt[i].dY;
				calcNotch.Position = new Point3D(pnt3D.X + StrectPnt[i].dX, pnt3D.Y + StrectPnt[i].dY, pnt3D.Z);
			}
		}
	}

	public void ScaleDrillFromStrectPoints(Entity refEntity, List<RulStrectPoints> StrectPnt, ref Entity entCalculted)
	{
		Pnt3D pnt3D = new Pnt3D(((Circle)refEntity).Center.X, ((Circle)refEntity).Center.Y, ((Circle)refEntity).Center.Z);
		double radius = ((Circle)refEntity).Radius;
		for (int i = 0; i <= StrectPnt.Count - 1; i++)
		{
			if (buCompare5.EQ(pnt3D, StrectPnt[i].Position))
			{
				pnt3D = new Pnt3D(pnt3D.X + StrectPnt[i].dX, pnt3D.Y + StrectPnt[i].dY, pnt3D.Z);
			}
		}
		Entity copiedEntity = null;
		buEntity.Copy(refEntity, ref copiedEntity);
		EntityDataSet entData = new EntityDataSet(-1, varCutterSettings.DrillLayerName, ccVars.Pages[ccVars.PageIndex].SceneName, "", "", null, ccVars.pntBase);
		CustomData customData = new CustomData((CustomData)copiedEntity.EntityData);
		Circle Ent = null;
		clsInit.appCommand.CreateCircle(new Point3D(pnt3D.X, pnt3D.Y, pnt3D.Z), radius, Plane.XY, entData, customData, ref Ent);
		Ent.EntityData = customData;
		entCalculted = Ent;
	}

	public void doNewExtension()
	{
		ccVars.MaterialList.Clear();
		if (varCutterSettings.ShowMachineSize)
		{
			for (int i = 0; (double)i <= varCutterSettings.RepeatCount - 1.0; i++)
			{
				MaterialBase5 materialBase = new MaterialBase5(varCutterSettings.MachineWidth, varCutterSettings.MachineHeight, 1.0);
				materialBase.dX = (double)i * varCutterSettings.MachineWidth;
				ccVars.MaterialList.Add(materialBase);
			}
		}
	}

	public void doOpenPage()
	{
		ccVars.MaterialList.Clear();
		if (varCutterSettings.ShowMachineSize)
		{
			for (int i = 0; (double)i <= varCutterSettings.RepeatCount - 1.0; i++)
			{
				MaterialBase5 materialBase = new MaterialBase5(varCutterSettings.MachineWidth, varCutterSettings.MachineHeight, 1.0);
				materialBase.dX = (double)i * varCutterSettings.MachineWidth;
				ccVars.MaterialList.Add(materialBase);
			}
		}
	}

	public void doConvertText(List<buEntity> refEntities)
	{
		if (refEntities.Count <= 0)
		{
			return;
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
		{
			if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() == typeof(Text))
			{
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].Selected = true;
			}
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.DeleteSelected();
		List<Entity> list = new List<Entity>();
		SortbuSettings settings = new SortbuSettings();
		List<buEntity> SortedEntities = new List<buEntity>();
		clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref refEntities, settings, ref SortedEntities);
		List<List<buEntity>> list2 = new List<List<buEntity>>();
		List<List<buEntity>> SplitedEntitites = new List<List<buEntity>>();
		clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
		List<buEntity> list3 = new List<buEntity>();
		for (int j = 0; j <= SplitedEntitites.Count - 1; j++)
		{
			buEntity buEntity2 = SplitedEntitites[j][0];
			if (!buEntity2.Info.CamSelected)
			{
				list3.Add(buEntity2);
			}
			if (!buEntity2.Info.CamSelected)
			{
				for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
				{
					if (k == j)
					{
						continue;
					}
					buEntity buEntity3 = SplitedEntitites[k][0];
					if (buEntity3.Info.CamSelected)
					{
						continue;
					}
					for (int l = 0; l <= buEntity2.Vertices.Count - 1; l++)
					{
						for (int m = 0; m <= buEntity3.Vertices.Count - 1; m++)
						{
							if (buCompare5.EQ(buEntity2.Vertices[l], buEntity3.Vertices[m]))
							{
								buEntity3.Info.CamSelected = true;
								list3.Add(buEntity3);
							}
						}
					}
				}
			}
			if (list3.Count > 0)
			{
				buEntity2.Info.CamSelected = true;
				list2.Add(list3);
				list3 = new List<buEntity>();
			}
		}
		for (int num = list2.Count - 1; num >= 0; num--)
		{
			bool flag = false;
			if (num <= list2.Count - 1)
			{
				for (int n = 0; n <= ccVars.CharLibList.Count - 1; n++)
				{
					for (int num2 = 0; num2 <= ccVars.CharLibList[n].CharEntities.Count - 1; num2++)
					{
						if (flag || list2[num].Count < 1 || !((list2[num][0] is buLinearPath) & (ccVars.CharLibList[n].CharEntities[num2] is buLinearPath)))
						{
							continue;
						}
						buLinearPath buLinearPath2 = list2[num][0] as buLinearPath;
						buLinearPath buLinearPath3 = ccVars.CharLibList[n].CharEntities[num2] as buLinearPath;
						Point3D MinPoint = new Point3D();
						Point3D MidPoint = new Point3D();
						Point3D MaxPoint = new Point3D();
						clsInit.cVector5.BoxSizeCalculate(ccVars.CharLibList[n].CharEntities, ref MinPoint, ref MidPoint, ref MaxPoint);
						if (buLinearPath2.Vertices.Count != buLinearPath3.Vertices.Count)
						{
							continue;
						}
						double value = clsInit.cVector5.Length3D(buLinearPath2.Vertices);
						double value2 = clsInit.cVector5.Length3D(buLinearPath3.Vertices);
						double num3 = clsInit.cVector5.PointAngle(buLinearPath2.Vertices[1], buLinearPath2.Vertices[0]);
						double num4 = clsInit.cVector5.PointAngle(buLinearPath3.Vertices[1], buLinearPath3.Vertices[0]);
						if (!buCompare5.EQ(value, value2, 0.5))
						{
							continue;
						}
						if (ccVars.CharLibList[n].CharEntities.Count != 1)
						{
							Point3D MinPoint2 = new Point3D();
							Point3D MidPoint2 = new Point3D();
							Point3D MaxPoint2 = new Point3D();
							clsInit.cVector5.BoxSizeCalculate(list2[num], ref MinPoint2, ref MidPoint2, ref MaxPoint2);
							Entity entity = new Text(Plane.XY, MidPoint2, ccVars.CharLibList[n].Char, MaxPoint.Y - MinPoint.Y, Text.alignmentType.MiddleCenter);
							if (!buCompare5.EQ(num3, num4, 1.0))
							{
								double angleInRadians = buConversion5.DegreeToRadian(num3 - num4);
								entity.Rotate(angleInRadians, Vector3D.AxisZ, MidPoint2);
							}
							list.Add(entity);
							flag = true;
						}
						else
						{
							Point3D MinPoint3 = new Point3D();
							Point3D MidPoint3 = new Point3D();
							Point3D MaxPoint3 = new Point3D();
							clsInit.cVector5.BoxSizeCalculate(buLinearPath2.Vertices, ref MinPoint3, ref MidPoint3, ref MaxPoint3);
							Entity entity2 = new Text(Plane.XY, MidPoint3, ccVars.CharLibList[n].Char, MaxPoint.Y - MinPoint.Y, Text.alignmentType.MiddleCenter);
							if (!buCompare5.EQ(num3, num4, 1.0))
							{
								double angleInRadians2 = buConversion5.DegreeToRadian(num3 - num4);
								entity2.Rotate(angleInRadians2, Vector3D.AxisZ, MidPoint3);
							}
							list.Add(entity2);
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				list2.RemoveAt(num);
			}
		}
		if (list.Count > 0)
		{
			for (int num5 = 0; num5 <= list.Count - 1; num5++)
			{
				list[num5].LayerName = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Layers[0].Name;
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Add(list[num5]);
			}
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		ccVars.pntDrawDynamicLinesArr = new List<List<Point3D>>();
		for (int num6 = 0; num6 <= list2.Count - 1; num6++)
		{
			List<Point3D> copiedPoint = new List<Point3D>();
			buVector5.Copy(list2[num6][0].Vertices, ref copiedPoint);
			ccVars.pntDrawDynamicLinesArr.Add(copiedPoint);
		}
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void doOffsetDrawing()
	{
		F_CutterOffsetEntities f_CutterOffsetEntities = new F_CutterOffsetEntities();
		f_CutterOffsetEntities.OffsetValue = varCutterSettings.OffsetValue;
		f_CutterOffsetEntities.OffsetType = varCutterSettings.OffsetType;
		f_CutterOffsetEntities.DeleteOriginal = varCutterSettings.DeleteOriginal;
		f_CutterOffsetEntities.Init();
		f_CutterOffsetEntities.ShowDialog();
		if (f_CutterOffsetEntities.PropertiesForm.Result == DialogResult.OK)
		{
			varCutterSettings.OffsetValue = f_CutterOffsetEntities.OffsetValue;
			varCutterSettings.OffsetType = f_CutterOffsetEntities.OffsetType;
			varCutterSettings.DeleteOriginal = f_CutterOffsetEntities.DeleteOriginal;
			camTp Cam = new camTp();
			cmdCamContour(ref Cam);
		}
	}

	public void doOperationAfterFileLoad()
	{
		if (!varCutterSettings.LockLayers)
		{
			return;
		}
		for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Layers.Count - 1; i++)
		{
			if (!((ccVars.Pages[ccVars.PageIndex].Layers[i].Name == varCutterSettings.ContourLayerName) | (ccVars.Pages[ccVars.PageIndex].Layers[i].Name == varCutterSettings.ContourRefLayerName)))
			{
				ccVars.Pages[ccVars.PageIndex].Layers[i].Lock = true;
			}
			else
			{
				ccVars.Pages[ccVars.PageIndex].Layers[i].Lock = false;
			}
		}
		clsInit.appCommand.LayersUpdate(ccVars.Pages[ccVars.PageIndex].Layers, FillLayer: true, 0);
	}

	public void doNotchRotate()
	{
		for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
		{
			Entity entity = buVector5.CopyEntities(ccVars.SelectionOP.Selections[i].SelectedEntity);
			CustomData customData = entity.EntityData as CustomData;
			if (customData.typeDefination != entityTypeDefination.Notch)
			{
				continue;
			}
			F_NotchEdit f_NotchEdit = new F_NotchEdit();
			CutterNotch cutterNotch = new CutterNotch();
			cutterNotch.DirectionAngle = customData.infoDirection;
			cutterNotch.Length = customData.infoLength;
			cutterNotch.baseEntityName = customData.ActionName;
			cutterNotch.Position = new Point3D(customData.infoBasePoint.X, customData.infoBasePoint.Y, customData.infoBasePoint.Z);
			if (!(customData.infoString == "VNotch"))
			{
				cutterNotch.NotchType = CutterNotchType.INotch;
			}
			else
			{
				cutterNotch.NotchType = CutterNotchType.VNotch;
			}
			f_NotchEdit.Notch = new CutterNotch(cutterNotch);
			f_NotchEdit.Init();
			f_NotchEdit.ShowDialog();
			if (f_NotchEdit.PropertiesForm.Result != DialogResult.OK)
			{
				continue;
			}
			cutterNotch = new CutterNotch(f_NotchEdit.Notch);
			cutterNotch.Angle = buConversion5.RadianToDegree(Math.Atan(cutterNotch.Width / 2.0 / cutterNotch.Length)) * 2.0;
			if (f_NotchEdit.ChangeDirection)
			{
				cutterNotch.DirectionAngle += 180.0;
				if (cutterNotch.DirectionAngle >= 360.0)
				{
					cutterNotch.DirectionAngle -= 360.0;
				}
			}
			ICurve curve = null;
			for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
			{
				customData = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].EntityData as CustomData;
				if (cutterNotch.baseEntityName == customData.EntityName)
				{
					Entity copiedEntity = null;
					buEntity.Copy(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j], ref copiedEntity);
					curve = (ICurve)copiedEntity;
				}
			}
			if (curve == null)
			{
				continue;
			}
			List<Entity> notchEntities = new List<Entity>();
			clsInit.cCutter.CreateNotch(cutterNotch.NotchType, new Point3D(cutterNotch.Position.X, cutterNotch.Position.Y, cutterNotch.Position.Z), cutterNotch.Length, cutterNotch.DirectionAngle, cutterNotch.Angle, curve, ref notchEntities);
			if (notchEntities.Count > 0)
			{
				notchEntities[0].EntityData = entity.EntityData;
				((CustomData)notchEntities[0].EntityData).infoLength = cutterNotch.Length;
				((CustomData)notchEntities[0].EntityData).infoWidth = cutterNotch.Width;
				((CustomData)notchEntities[0].EntityData).infoAngle = cutterNotch.Angle;
				((CustomData)notchEntities[0].EntityData).infoDirection = cutterNotch.DirectionAngle;
				((CustomData)notchEntities[0].EntityData).infoString = cutterNotch.NotchType.ToString();
				int index = ccVars.SelectionOP.Selections[i].Index;
				if ((index >= 0) & (index <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1))
				{
					Entity copiedEntity2 = null;
					buEntity.Copy(notchEntities[0], ref copiedEntity2);
					copiedEntity2.LayerName = entity.LayerName;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index] = copiedEntity2;
					ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index].Regen(clsVar.varEntities.RegenDeviation);
				}
			}
		}
		clsInit.appCommand.Reset();
		ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
	}

	public void cmdCamContour(ref camTp Cam)
	{
		try
		{
			clsInit.appCommand.Reset(ClearSelection: false);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.ActionMode = actionType.None;
			Cam = new camTp();
			MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
			mWCalculationOptions.NumberofAxis = 3;
			mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
			mWCalculationOptions.Mode = CamMode.WireFrame;
			mWCalculationOptions.DontApplyReset = true;
			mWCalculationOptions.isBuWireframeCalculation = false;
			mWCalculationOptions.AddToCamListInLocalCalculation = false;
			mWCalculationOptions.AddToCamListInMWCalculation = false;
			mWCalculationOptions.ShowLeadInOutPage = false;
			mWCalculationOptions.DontShowDialogBox = true;
			ToolBase5 toolBase = new ToolBase5();
			toolBase.Purpose = ToolPurpose.Milling;
			toolBase.Geometry.GeometryType = ToolType.Flat;
			toolBase.Geometry.Diameter = varCutterSettings.OffsetValue * 2.0;
			toolBase.Geometry.Length = 100.0;
			doWireframeContour(mWCalculationOptions, toolBase, ref Cam);
		}
		catch (Exception mSException)
		{
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public int doWireframeContour(MWCalculationOptions MWCalcoptions, ToolBase5 Tool, ref camTp Cam)
	{
		Cam = new camTp();
		buMWCutterVars.varCamCutter.buPar.Offsets.OpenContour = CamOpenContourType.Center;
		buMWCutterVars.varCamCutter.buPar.Offsets.ClosedContour = varCutterSettings.OffsetType;
		buMWCutterVars.varCamCutter.buPar.Distances.Air = 0.0;
		buMWCutterVars.varCamCutter.buPar.Distances.Safe = 0.0;
		buMWCutterVars.varCamCutter.buPar.Distances.Rapid = 0.0;
		buMWCutterVars.varCamCutter.buPar.Distances.EntryAndExit = 0.0;
		buMWCutterVars.varCamCutter.buPar.Distances.EntryAndExit = 0.0;
		buMWCutterVars.varCamCutter.mwPar = buMWCalcs.ConvertFromBuCamParToMwCamPar(buMWCutterVars.varCamCutter.mwPar, buMWCutterVars.varCamCutter.buPar);
		clsMW.varMWCamWFContourPars = buMWCalcs.CopyCamParameter(buMWCutterVars.varCamCutter.mwPar, buMWCutterVars.varCamCutter.buPar, out clsMW.varbuCamWFContourPars);
		clsMW.varMWCamWFContourPars.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.SharpCornersFlg = true;
		camResult Result = null;
		int num = clsInit.appMW.doWireframeContour(MWCalcoptions, Tool, ref Cam, ref Result);
		if (Result.Errors.Count <= 0)
		{
			ccVars.UndoDont = false;
			clsInit.appCommand.undoBuffer();
			buMWCutterVars.varCamCutter.mwPar = buMWCalcs.CopyCamParameter(clsMW.varMWCamWFContourPars, clsMW.varbuCamWFContourPars, out buMWCutterVars.varCamCutter.buPar);
			if (num >= 1)
			{
				Cam.Mode = MWCalcoptions.Mode;
				Cam.CamWireframeType = MWCalcoptions.CamWireframeType;
				Cam.CamTriMeshType = MWCalcoptions.CamTriMeshType;
				Cam.NumberOfAxis = MWCalcoptions.NumberofAxis;
				Cam.Action = actionTypeBU.None;
				List<camTp> list = new List<camTp>();
				list.Add(Cam);
				List<Entity> BaseRefEntities = new List<Entity>();
				if (Cam.EntitiesG1Orj.Count <= 0)
				{
					if (Cam.EntitiesG1.Count > 0)
					{
						for (int i = 0; i <= Cam.EntitiesG1.Count - 1; i++)
						{
							Entity copiedEnt = null;
							buVector5.CopyEntities(Cam.EntitiesG1[i], ref copiedEnt);
							copiedEnt.EntityData = new CustomData();
							BaseRefEntities.Add(copiedEnt);
						}
					}
				}
				else
				{
					for (int j = 0; j <= Cam.EntitiesG1Orj.Count - 1; j++)
					{
						Entity copiedEnt2 = null;
						buVector5.CopyEntities(Cam.EntitiesG1Orj[j], ref copiedEnt2);
						copiedEnt2.EntityData = new CustomData();
						BaseRefEntities.Add(copiedEnt2);
					}
				}
				if (BaseRefEntities.Count > 0)
				{
					SortSettings sortSettings = new SortSettings();
					sortSettings.Option.NextGroupRules = SortingNextGroupFindRulesType.ClosestLength;
					sortSettings.Option.IntersectionRules = SortingIntersectionRulesType.FromDrawing;
					sortSettings.Option.UseCamSelectedProps = true;
					SortResult Result2 = new SortResult();
					List<Entity> SortedEntities = new List<Entity>();
					clsInit.cVector5.SortEntitiesByRefPoint(((ICurve)BaseRefEntities[0]).StartPoint, ref BaseRefEntities, sortSettings, ref SortedEntities, ref Result2);
					List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
					clsInit.cVector5.EntitiesSplitByUpperLine(SortedEntities, ref SplitedEntitites);
					for (int k = 0; k <= SplitedEntitites.Count - 1; k++)
					{
						bool flag = clsInit.cVector5.isEntitiesClosed(SplitedEntitites[k]);
						ccVars.UndoDont = true;
						if (!flag)
						{
							for (int l = 0; l <= SplitedEntitites[k].Count - 1; l++)
							{
								ccVars.UndoDont = true;
								clsInit.appCommand.AddEntity(SplitedEntitites[k][l]);
							}
							continue;
						}
						List<ICurve> list2 = new List<ICurve>();
						for (int m = 0; m <= SplitedEntitites[k].Count - 1; m++)
						{
							list2.Add((ICurve)SplitedEntitites[k][m]);
						}
						new CompositeCurve(list2, sortAndOrient: true);
						List<Point3D> Points = new List<Point3D>();
						clsInit.cVector5.EntitiesToPointsWithCamDirection(SplitedEntitites[k], 0.01, ref Points);
						LinearPath ent = new LinearPath(Points);
						clsInit.appCommand.AddEntity(ent);
					}
					if (varCutterSettings.DeleteOriginal)
					{
						clsInit.appCommand.Delete(applyReset: false);
					}
					clsInit.appCommand.Reset();
					clsFiles.SaveParameter();
				}
				return 1;
			}
			clsInit.appCommand.Reset();
			return num;
		}
		F_ErrorList f_ErrorList = new F_ErrorList();
		f_ErrorList.Init(Result.Errors);
		f_ErrorList.ShowDialog();
		clsInit.appCommand.Reset();
		return -2;
	}
}
