using System;
using System.Collections;
using System.Collections.Generic;
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
using buEyeBaseVer5.Apps;
using buEyeBaseVer5.Forms;
using buEyeBaseVer5.buEntities;
using buMW;
using buMW.Variables;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace buCadCamResVer5.Quilting;

public class clsQuilting
{
	private static string string_0 = "fduyfuFDSGERTHSAF-*05435/&%(hgfdhgfHGFHGFHvxcvcvTREQWEFVFDNB gR E%YT%E";

	private static string string_1 = "QWEFGHLJHGFhjklopoıuygtfc-*098h?=)(/TFDERTYUI)OKNBVFDRErd345678uhgfdXCVBHJ/&%RDW^+%&/()=)(/TRFCVBNYTrEDSX";

	private static string string_2 = "";

	private static string string_3 = "";

	private static double double_0 = 0.0;

	private static double double_1 = 0.0;

	public List<string> cmdExceptionID = new List<string>();

	public SortResult QuiltSortResult = new SortResult();

	public List<List<Entity>> refSortEntitiesLL = new List<List<Entity>>();

	public List<Entity> refSortEntities = new List<Entity>();

	public static QuiltingProgramSettings varQuiltingSettings = new QuiltingProgramSettings();

	public static QuiltingRuntimeSettings varQuiltingRunSettings = new QuiltingRuntimeSettings();

	public clsQuilting()
	{
		if (!clsSystem.smethod_0("clsQuilting"))
		{
			throw new RegisterException("clsQuilting");
		}
	}

	public void Init()
	{
		buMWQuiltingVars.Init();
		cmdExceptionID.Add("clsQuilting - ID = 101-00100");
		cmdExceptionID.Add("clsQuilting - ID = 101-00101");
		cmdExceptionID.Add("clsQuilting - ID = 101-00102");
		cmdExceptionID.Add("clsQuilting - ID = 101-00103");
		cmdExceptionID.Add("clsQuilting - ID = 101-00104");
		cmdExceptionID.Add("clsQuilting - ID = 101-00105");
		cmdExceptionID.Add("clsQuilting - ID = 101-00106");
		cmdExceptionID.Add("clsQuilting - ID = 101-00107");
		cmdExceptionID.Add("clsQuilting - ID = 101-00108");
		cmdExceptionID.Add("clsQuilting - ID = 101-00109");
		cmdExceptionID.Add("clsQuilting - ID = 101-00110");
	}

	public void cmdSelectPattern()
	{
		try
		{
			refSortEntitiesLL.Clear();
			ccVars.SortedEntities.Clear();
			refSortEntitiesLL = new List<List<Entity>>();
			refSortEntities = new List<Entity>();
			List<List<Entity>> list = new List<List<Entity>>();
			List<Entity> copiedEnt = new List<Entity>();
			ccVars.SortedEntities = new List<Entity>();
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = false;
			ccVars.Action = actionTypeBU.quiltingSelectPattern;
			if (varQuiltingSettings.SortType != quiltingSortType.All)
			{
				if ((varQuiltingSettings.SortType == quiltingSortType.FirstDoubleHeadThenSingleHead) | (varQuiltingSettings.SortType == quiltingSortType.FirstSingleHeadThenDoubleHead))
				{
					List<Entity> list2 = new List<Entity>();
					List<Entity> list3 = new List<Entity>();
					for (int i = 0; i <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; i++)
					{
						if (!(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i] is ICurve))
						{
							continue;
						}
						Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i];
						if (!(entity.EntityData is CustomData))
						{
							continue;
						}
						CustomData customData = entity.EntityData as CustomData;
						if (!(customData.Tags != "0"))
						{
							if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() != typeof(Point))
							{
								list2.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]));
							}
						}
						else if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i].GetType() != typeof(Point))
						{
							list3.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[i]));
						}
					}
					if (varQuiltingRunSettings.QuiltSortSettings.Option.NextGroupRules != SortingNextGroupFindRulesType.AskMe)
					{
						if (varQuiltingSettings.SortType != quiltingSortType.FirstDoubleHeadThenSingleHead)
						{
							if (varQuiltingSettings.SortType == quiltingSortType.FirstSingleHeadThenDoubleHead)
							{
								if (!((list2.Count > 0) & (list3.Count > 0)))
								{
									if (!((list2.Count > 0) & (list3.Count == 0)))
									{
										if ((list2.Count == 0) & (list3.Count > 0))
										{
											buVector5.CopyEntities(list3, ref copiedEnt);
										}
									}
									else
									{
										buVector5.CopyEntities(list2, ref copiedEnt);
									}
								}
								else
								{
									list.Add(list3);
									list.Add(list2);
								}
							}
						}
						else if (!((list2.Count > 0) & (list3.Count > 0)))
						{
							if (!((list2.Count > 0) & (list3.Count == 0)))
							{
								if ((list2.Count == 0) & (list3.Count > 0))
								{
									buVector5.CopyEntities(list3, ref copiedEnt);
								}
							}
							else
							{
								buVector5.CopyEntities(list2, ref copiedEnt);
							}
						}
						else
						{
							list.Add(list2);
							list.Add(list3);
						}
					}
					else if (varQuiltingSettings.SortType != quiltingSortType.FirstDoubleHeadThenSingleHead)
					{
						if (list3.Count > 0)
						{
							copiedEnt.AddRange(list3);
						}
						if (list2.Count > 0)
						{
							copiedEnt.AddRange(list2);
						}
					}
					else
					{
						if (list2.Count > 0)
						{
							copiedEnt.AddRange(list2);
						}
						if (list3.Count > 0)
						{
							copiedEnt.AddRange(list3);
						}
					}
				}
			}
			else
			{
				for (int j = 0; j <= ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities.Count - 1; j++)
				{
					if (ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j] is ICurve && ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j].GetType() != typeof(Point))
					{
						copiedEnt.Add(buVector5.CopyEntities(ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[j]));
					}
				}
			}
			for (int k = 0; k <= copiedEnt.Count - 1; k++)
			{
				if (!(copiedEnt[k] is LinearPath))
				{
					refSortEntities.Add(buVector5.CopyEntities(copiedEnt[k]));
					continue;
				}
				for (int l = 1; l <= copiedEnt[k].Vertices.Length - 1; l++)
				{
					Line line = new Line(copiedEnt[k].Vertices[l - 1], copiedEnt[k].Vertices[l]);
					line.EntityData = new CustomData((CustomData)copiedEnt[k].EntityData);
					refSortEntities.Add(line);
				}
			}
			for (int m = 0; m <= list.Count - 1; m++)
			{
				List<Entity> list4 = new List<Entity>();
				for (int n = 0; n <= list[m].Count - 1; n++)
				{
					if (!(list[m][n] is LinearPath))
					{
						list4.Add(buVector5.CopyEntities(list[m][n]));
						continue;
					}
					for (int num = 1; num <= list[m][n].Vertices.Length - 1; num++)
					{
						Line line2 = new Line(list[m][n].Vertices[num - 1], list[m][n].Vertices[num]);
						line2.EntityData = new CustomData((CustomData)list[m][n].EntityData);
						list4.Add(line2);
					}
				}
				refSortEntitiesLL.Add(list4);
			}
			clsInit.appCommand.cmdMainFormStatusUpdate("Select");
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[0];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdSortSettings()
	{
		try
		{
			F_QuiltingSettings f_QuiltingSettings = new F_QuiltingSettings();
			f_QuiltingSettings.SortSetting = new SortSettings(varQuiltingRunSettings.QuiltSortSettings);
			f_QuiltingSettings.Init();
			f_QuiltingSettings.StartPosition = FormStartPosition.CenterParent;
			f_QuiltingSettings.ShowDialog();
			if (f_QuiltingSettings.PropertiesForm.Result == DialogResult.OK)
			{
				varQuiltingRunSettings.QuiltSortSettings = new SortSettings(f_QuiltingSettings.SortSetting);
				clsFiles.SaveParameter();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[3];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void cmdCamCreatCode(string FileName)
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog.FilterIndex = 1;
					if (FileName.Length > 1)
					{
						clsVar.varInterface.pathGCode = buFile.GetPath(FileName);
						string Codes = "";
						doSelectionToCode(ref Codes);
						buFile.SaveToFile(Codes, FileName);
						clsFiles.SaveParameter();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
					}
					else if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						clsVar.varInterface.pathGCode = buFile.GetPath(saveFileDialog.FileName);
						string Codes2 = "";
						doSelectionToCode(ref Codes2);
						buFile.SaveToFile(Codes2, saveFileDialog.FileName);
						clsFiles.SaveParameter();
						if (clsItem.FrmProgress != null)
						{
							clsItem.FrmProgress.Visible = false;
						}
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
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

	public void cmdCamShowCode()
	{
		try
		{
			if (!clsVar.appModes_0.DemoMode)
			{
				if (ccVars.Pages.Count > 0)
				{
					string Codes = "";
					doSelectionToCode(ref Codes);
					F_Notepad f_Notepad = new F_Notepad();
					f_Notepad.Init(Codes);
					f_Notepad.Show();
					buFile5.SaveToFile(Codes, Application.StartupPath + "\\Temp.cnc");
					LoadFile(Application.StartupPath + "\\Temp.cnc");
					if (clsItem.FrmProgress != null)
					{
						clsItem.FrmProgress.Visible = false;
					}
				}
				else
				{
					buString.MessageBoxWarning(AppLanguage.Messages[9]);
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

	public void cmdShowSettings()
	{
		try
		{
			F_ClassViewerDialog f_ClassViewerDialog = new F_ClassViewerDialog();
			f_ClassViewerDialog.Text = "Settings";
			f_ClassViewerDialog.Value = varQuiltingSettings;
			f_ClassViewerDialog.StartPosition = FormStartPosition.CenterParent;
			f_ClassViewerDialog.Width = 500;
			f_ClassViewerDialog.Height = 750;
			f_ClassViewerDialog.ValuePersentage = 35.0;
			f_ClassViewerDialog.Init();
			f_ClassViewerDialog.ShowDialog();
			if (f_ClassViewerDialog.Result == DialogResult.OK)
			{
				varQuiltingSettings = new QuiltingProgramSettings((QuiltingProgramSettings)f_ClassViewerDialog.Value);
				clsFiles.SaveParameter();
			}
		}
		catch (Exception)
		{
		}
	}

	public void cmdUndoSelection()
	{
		try
		{
			buVector5.AskMe.GetBack = true;
			if (QuiltSortResult.ResultType == SortingResultType.MultipleEntities)
			{
				buVector5.AskMe.GetBackFromMultiSelection = true;
			}
			clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref clsInit.appQuilting.refSortEntities, varQuiltingRunSettings.QuiltSortSettings, ref ccVars.SortedEntities, ref QuiltSortResult);
			ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
		}
		catch (Exception)
		{
		}
	}

	public void cmdSetProperties()
	{
		try
		{
			if (ccVars.SelectionOP.Selections.Count != 0)
			{
				doSetProperties();
				return;
			}
			ccVars.stpDrawing = 1;
			ccVars.selectionProcess = true;
			ccVars.Action = actionTypeBU.quiltingSetProperties;
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[3];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadLanguage()
	{
		try
		{
			List<string> list = new List<string>();
			FileInfo fileInfo = null;
			fileInfo = ((!clsVar.appModes_0.DeveloperPCMode) ? new FileInfo(AppPath.Language + "\\buQuilting.lng") : new FileInfo("D:\\PCProjects\\Generation5\\CommonFolder\\Language\\buQuilting.lng"));
			if (!fileInfo.Exists)
			{
				buLog.addLog("Quilting Language", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Quilting Language File Missing");
			}
			else
			{
				List<string> StringList = new List<string>();
				buFile.OpenFromFile(fileInfo.FullName, ref StringList);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Status>", "</Status>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingStatus);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Message>", "</Message>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingMessage);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Captions>", "</Captions>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingCaptions);
				buString.GetItemsAccordingToTheLang(buString.ReadXmlItem("<Command>", "</Command>", StringList), clsVar.varRuntime.Language, ref buQuilting.LangQuiltingCommand);
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

	public void SaveQuiltingFile()
	{
		try
		{
			string fileName = AppPath.Settings + "\\Quilting\\Quilting.prm";
			ArrayList arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   Quilting Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<QuiltingSettings>");
			arrayList.AddRange(varQuiltingSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</QuiltingSettings>");
			arrayList.Add("<QuiltingRuntimeSettings>");
			arrayList.AddRange(varQuiltingRunSettings.ToDefAll("", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</QuiltingRuntimeSettings>");
			buFile.SaveToFile(arrayList, fileName);
			buLog.addLog("Quilting Set Saved", "Ok", MethodBase.GetCurrentMethod().Name);
			buMWQuiltingVars.varCamQuilting.mwPar.Serialize(AppPath.Settings + "\\Quilting\\mwQuilting.bin");
			string fileName2 = AppPath.Settings + "\\Quilting\\QuiltingCam.bucamset";
			arrayList = new ArrayList();
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("   MW Cam Settings");
			arrayList.Add("------------------------------------------------------------------------");
			arrayList.Add("<MwCamSettings>");
			arrayList.AddRange(buMWQuiltingVars.varCamQuilting.buPar.ToDefAll("_varCamQuilting", 2, SerilizationMode5.MultiLine));
			arrayList.Add("</MwCamSettings>");
			buFile.SaveToFile(arrayList, fileName2);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[17];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void OpenQuiltingFile()
	{
		try
		{
			ArrayList arrayList = new ArrayList();
			string fileName = AppPath.Settings + "\\Quilting\\Quilting.prm";
			FileInfo fileInfo = new FileInfo(fileName);
			if (!fileInfo.Exists)
			{
				if (clsVar.appModes_0.LaserRouterDiamekerMode.Enable)
				{
					buLog.addLog("Quilting Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buString.MessageBoxError("Quilting Settings File Missing");
				}
			}
			else
			{
				arrayList = new ArrayList();
				buFile.OpenFromFile(fileInfo.FullName, ref arrayList);
				try
				{
					ArrayList CalcList = new ArrayList();
					buString.ListToSpecificList("<QuiltingSettings>", "</QuiltingSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varQuiltingSettings);
						buLog.addLog("Quilting Settings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
					CalcList = new ArrayList();
					buString.ListToSpecificList("<QuiltingRuntimeSettings>", "</QuiltingRuntimeSettings>", AddStartEndKey: true, arrayList, ref CalcList);
					if (CalcList.Count > 0)
					{
						buSerilization5.Decode(arrayList, "", SerilizationMode5.MultiLine, varQuiltingRunSettings);
						buLog.addLog("TuftingRuntimeSettings Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
					}
				}
				catch (Exception mSException)
				{
					buLog.addLog("Quilting Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
					buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Tufting Settings Decoder Error");
				}
			}
			buLog.addLog("Quilting Variable Decoded", "Ok", MethodBase.GetCurrentMethod().Name);
			fileInfo = new FileInfo(AppPath.Settings + "\\Quilting\\mwQuilting.bin");
			if (!fileInfo.Exists)
			{
				buLog.addLog("Quilting mwCam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Quilting mwCam  Settings File Missing");
				buMWQuiltingVars.varCamQuilting = new MWParameters(Unit.Metric, 0);
			}
			else
			{
				buMWQuiltingVars.varCamQuilting.mwPar.Deserialize(fileInfo.FullName);
			}
			string fileName2 = AppPath.Settings + "\\Quilting\\QuiltingCam.bucamset";
			fileInfo = new FileInfo(fileName2);
			if (!fileInfo.Exists)
			{
				buLog.addLog("Quilting Cam Settings File Mising", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buString.MessageBoxError("Quilting Cam Settings File Missing");
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
					buSerilization.Decode(arrayList, "_varCamQuilting", SerilizationMode.MultiLine, buMWQuiltingVars.varCamQuilting.buPar);
				}
			}
			catch (Exception mSException2)
			{
				buLog.addLog("MW Quilting Cam Settings Decoder Error", "Not Ok", MethodBase.GetCurrentMethod().Name);
				buException.throwException(mSException2, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "Quilting Settings Decoder Error");
			}
		}
		catch (Exception mSException3)
		{
			_ = cmdExceptionID[18];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException3, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void LoadFile(string FileName)
	{
		try
		{
			Design model = ccVars.Pages[ccVars.PageIndex].Form.viewportcad;
			clsInit.appFiles.OpenGCodeFile(FileName, Clear: false, ref model);
		}
		catch (Exception)
		{
		}
	}

	public void doSelectionToCode(ref string Codes)
	{
		try
		{
			if (ccVars.SortedEntities.Count <= 0)
			{
				return;
			}
			List<List<Entity>> SplitedEntitites = new List<List<Entity>>();
			List<List<Entity>> copiedEnt = new List<List<Entity>>();
			clsInit.cVector5.EntitiesSplitByUpperLine(ccVars.SortedEntities, ref SplitedEntitites);
			for (int i = 0; i <= SplitedEntitites.Count - 1; i++)
			{
				if (clsInit.cVector5.isEntitiesClosed(SplitedEntitites[i]))
				{
					bool flag = false;
					List<Entity> BaseRefEntities = new List<Entity>();
					Point3D point3D = null;
					for (int j = 0; j <= SplitedEntitites[i].Count - 1; j++)
					{
						CustomData customData = SplitedEntitites[i][j].EntityData as CustomData;
						if (!(!flag & (SplitedEntitites[i][j] is Line) & varQuiltingSettings.StartFromMiddle))
						{
							Entity copiedEnt2 = null;
							buVector5.CopyEntities(SplitedEntitites[i][j], ref copiedEnt2);
							((CustomData)copiedEnt2.EntityData).CamSelected = false;
							BaseRefEntities.Add(copiedEnt2);
							continue;
						}
						bool flag2 = false;
						if (varQuiltingSettings.MiddleDirection == quiltingDirectionType.FirstHorizontal)
						{
							double value = clsInit.cVector5.PointAngle(((Line)SplitedEntitites[i][j]).EndPoint, ((Line)SplitedEntitites[i][j]).StartPoint, Plane.XY);
							if (buCompare5.EQ(value, 0.0, varQuiltingSettings.MiddleDirectionCompareAngle) | buCompare5.EQ(value, 180.0, varQuiltingSettings.MiddleDirectionCompareAngle))
							{
								flag2 = true;
							}
						}
						if (varQuiltingSettings.MiddleDirection == quiltingDirectionType.FirstVertical)
						{
							double value2 = clsInit.cVector5.PointAngle(((Line)SplitedEntitites[i][j]).EndPoint, ((Line)SplitedEntitites[i][j]).StartPoint, Plane.XY);
							if (buCompare5.EQ(value2, 90.0, varQuiltingSettings.MiddleDirectionCompareAngle) | buCompare5.EQ(value2, 270.0, varQuiltingSettings.MiddleDirectionCompareAngle))
							{
								flag2 = true;
							}
						}
						if (!flag2)
						{
							Entity copiedEnt3 = null;
							buVector5.CopyEntities(SplitedEntitites[i][j], ref copiedEnt3);
							((CustomData)copiedEnt3.EntityData).CamSelected = false;
							BaseRefEntities.Add(copiedEnt3);
							continue;
						}
						point3D = Point3D.MidPoint(((ICurve)SplitedEntitites[i][j]).StartPoint, ((ICurve)SplitedEntitites[i][j]).EndPoint);
						ICurve lower = null;
						ICurve upper = null;
						((ICurve)SplitedEntitites[i][j]).SplitBy(point3D, out lower, out upper);
						if (!(lower != null && upper != null))
						{
							point3D = null;
							continue;
						}
						Entity entity = (Entity)lower;
						entity.EntityData = new CustomData();
						((CustomData)entity.EntityData).Tags = customData.Tags;
						((CustomData)entity.EntityData).CamFeedrate = customData.CamFeedrate;
						((CustomData)entity.EntityData).sortDirection = customData.sortDirection;
						Entity entity2 = (Entity)upper;
						entity2.EntityData = new CustomData();
						((CustomData)entity2.EntityData).Tags = customData.Tags;
						((CustomData)entity2.EntityData).CamFeedrate = customData.CamFeedrate;
						((CustomData)entity2.EntityData).sortDirection = customData.sortDirection;
						BaseRefEntities.Add(entity);
						BaseRefEntities.Add(entity2);
						flag = true;
					}
					if (flag)
					{
						SortSettings settings = new SortSettings();
						SortResult Result = new SortResult();
						List<Entity> SortedEntities = new List<Entity>();
						clsInit.cVector5.SortEntitiesByRefPoint(point3D, ref BaseRefEntities, settings, ref SortedEntities, ref Result);
						if (SortedEntities.Count > 0)
						{
							clsInit.cVector5.isEntitiesClosed(SplitedEntitites[i]);
							SplitedEntitites[i] = SortedEntities;
						}
					}
				}
				if (!(varQuiltingSettings.DevideLength > 0.0))
				{
					continue;
				}
				if (varQuiltingSettings.DevideOnlyLines)
				{
					List<Entity> list = new List<Entity>();
					for (int k = 0; k <= SplitedEntitites[i].Count - 1; k++)
					{
						if (!((SplitedEntitites[i][k] is Line) | (SplitedEntitites[i][k] is LinearPath)))
						{
							Entity entity3 = buVector5.CopyEntities(SplitedEntitites[i][k]);
							if (entity3 != null)
							{
								list.Add(entity3);
							}
							continue;
						}
						List<Point3D> pntDevided = new List<Point3D>();
						clsInit.cVector5.EntityDevideByCamDir(SplitedEntitites[i][k], varQuiltingSettings.DevideLength, ref pntDevided);
						if (pntDevided.Count > 0)
						{
							LinearPath linearPath = new LinearPath(pntDevided);
							CustomData customData2 = new CustomData();
							customData2.sortDirection = entitySortDirection.Normal;
							customData2.CamFeedrate = ((CustomData)SplitedEntitites[i][k].EntityData).CamFeedrate;
							customData2.Tags = ((CustomData)SplitedEntitites[i][k].EntityData).Tags;
							linearPath.EntityData = customData2;
							list.Add(linearPath);
						}
					}
					if (list.Count > 0)
					{
						SplitedEntitites[i] = list;
					}
					continue;
				}
				List<Point3D> list2 = new List<Point3D>();
				for (int l = 0; l <= SplitedEntitites[i].Count - 1; l++)
				{
					List<Point3D> pntDevided2 = new List<Point3D>();
					clsInit.cVector5.EntityDevideByCamDir(SplitedEntitites[i][l], varQuiltingSettings.DevideLength, ref pntDevided2);
					if (list2.Count != 0)
					{
						if (pntDevided2.Count > 0)
						{
							if (buCompare5.EQ(pntDevided2[0], list2[list2.Count - 1], 0.1))
							{
								pntDevided2.RemoveAt(0);
							}
							if (pntDevided2.Count > 0)
							{
								list2.AddRange(pntDevided2);
							}
						}
					}
					else if (pntDevided2.Count > 0)
					{
						list2.AddRange(pntDevided2);
					}
				}
				if (list2.Count >= 2)
				{
					CustomData customData3 = new CustomData();
					customData3.sortDirection = entitySortDirection.Normal;
					customData3.CamFeedrate = ((CustomData)SplitedEntitites[i][0].EntityData).CamFeedrate;
					customData3.Tags = ((CustomData)SplitedEntitites[i][0].EntityData).Tags;
					SplitedEntitites[i] = new List<Entity>();
					List<Entity> list3 = new List<Entity>();
					LinearPath linearPath2 = new LinearPath(list2);
					linearPath2.EntityData = customData3;
					list3.Add(linearPath2);
					SplitedEntitites[i] = list3;
				}
			}
			if (!varQuiltingSettings.SharpCornerEnable)
			{
				buVector5.CopyEntities(SplitedEntitites, ref copiedEnt);
			}
			else
			{
				for (int m = 0; m <= SplitedEntitites.Count - 1; m++)
				{
					List<Entity> list4 = new List<Entity>();
					list4.Add(buVector5.CopyEntities(SplitedEntitites[m][0]));
					for (int n = 1; n <= SplitedEntitites[m].Count - 2; n++)
					{
						double Angle = 0.0;
						if (n != 19)
						{
						}
						clsInit.cVector5.AngleOfTwoEntities(SplitedEntitites[m][n - 1], SplitedEntitites[m][n], ref Angle, Plane.XY);
						if (!(180.0 - Angle > varQuiltingSettings.CornerAngle))
						{
							list4.Add(buVector5.CopyEntities(SplitedEntitites[m][n]));
							continue;
						}
						copiedEnt.Add(list4);
						list4 = new List<Entity>();
						list4.Add(buVector5.CopyEntities(SplitedEntitites[m][n]));
						if (n == SplitedEntitites[m].Count - 2)
						{
							copiedEnt.Add(list4);
							list4 = new List<Entity>();
						}
					}
					if (list4.Count != 0)
					{
						list4.Add(buVector5.CopyEntities(SplitedEntitites[m][SplitedEntitites[m].Count - 1]));
						copiedEnt.Add(list4);
						list4 = new List<Entity>();
					}
					else
					{
						list4.Add(buVector5.CopyEntities(SplitedEntitites[m][SplitedEntitites[m].Count - 1]));
						copiedEnt.Add(list4);
						list4 = new List<Entity>();
					}
				}
			}
			clsInit.appCommand.undoBuffer();
			buMWQuiltingVars.varCamQuilting.buPar.Offsets.ClosedContour = CamClosedContourType.Center;
			buMWQuiltingVars.varCamQuilting.buPar.Offsets.OpenContour = CamOpenContourType.Center;
			buMWQuiltingVars.varCamQuilting.buPar.Offsets.OverlapDistance = varQuiltingSettings.ClosedPatternEndExtentLength;
			buMWQuiltingVars.varCamQuilting.buPar.Options.ExtendPatternOutput = varQuiltingSettings.OpenPatternEndExtentLength;
			buMWQuiltingVars.varCamQuilting.mwPar.MachParam.TpCalculationMethodsParams.WireframeBasedTpCalcParams.CuttingSide = WireframeBasedTpCalcParamsCuttingSide.WfbCsCenter;
			buMWCalcs.CopyCamParameter(buMWQuiltingVars.varCamQuilting, ref buMWCalcs.varCamWFContourPars);
			ccVars.toolActive.Geometry.GeometryType = buClass.ToolType.Flat;
			ccVars.toolActive.Geometry.Diameter = 1.0;
			MWCalculationOptions mWCalculationOptions = new MWCalculationOptions();
			mWCalculationOptions.SortingSettings.Option.Resolution = clsVar.varSelection.SelectionResolution;
			mWCalculationOptions.NumberofAxis = 3;
			mWCalculationOptions.CamWireframeType = CamWireFrameType.Contour;
			mWCalculationOptions.Mode = CamMode.WireFrame;
			mWCalculationOptions.DontApplyReset = true;
			mWCalculationOptions.isBuWireframeCalculation = false;
			mWCalculationOptions.AddToCamListInMWCalculation = false;
			mWCalculationOptions.DontShowDialogBox = true;
			mWCalculationOptions.isBuSort = true;
			mWCalculationOptions.isBuWireframeCalculation = true;
			mWCalculationOptions.UseStartPoint = false;
			mWCalculationOptions.UseConstantStartPoint = true;
			mWCalculationOptions.StartPointX = 0.0;
			mWCalculationOptions.StartPointY = 0.0;
			mWCalculationOptions.HeightFromEntities = false;
			camTp CamCalculated = new camTp();
			clsInit.cCam5.camQuilting(copiedEnt, TangentCalculaton: false, varQuiltingSettings.HeadDistance, new ToolBase5(), buMWQuiltingVars.varCamQuilting.buPar, ref CamCalculated);
			clsInit.appCommand.CamAdd(CamCalculated);
			clsInit.appCommand.Reset();
			int num = 0;
			for (int num2 = 0; num2 <= CamCalculated.CamPoints.Count - 1; num2++)
			{
				for (int num3 = 0; num3 <= CamCalculated.CamPoints[num2].Points.Count - 1; num3++)
				{
					if (CamCalculated.CamPoints[num2].Points[num3].Type == 0)
					{
						if (varQuiltingSettings.RoundCorner > 0.0)
						{
							CamCalculated.CamPoints[num2].Points[num3].AfterCodes.Add("G51 D" + varQuiltingSettings.RoundCorner.ToString("f1"));
						}
						if (num != 0)
						{
						}
						num++;
					}
				}
			}
			Codes = "";
			clsInit.cGcodeCreate.CreatGCode(CamCalculated, ccVars.PostActive, ref Codes);
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[1];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doAskMeReturn()
	{
		try
		{
			buVector5.AskMe.Return = true;
			clsInit.cVector5.SortEntitiesByRefPoint(new Point3D(), ref clsInit.appQuilting.refSortEntities, varQuiltingRunSettings.QuiltSortSettings, ref ccVars.SortedEntities, ref QuiltSortResult);
			if (QuiltSortResult.ResultType != SortingResultType.Done && QuiltSortResult.ResultType != SortingResultType.MultipleEntities && QuiltSortResult.ResultType == SortingResultType.SelectNextGroup)
			{
				buVector5.AskMe.LastMarkPosition.Add(buVector5.ToPoint3D(buVector5.AskMe.CatchPoint));
				ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Invalidate();
			}
		}
		catch (Exception mSException)
		{
			_ = cmdExceptionID[2];
			buLog.addLog("", "Not Ok", MethodBase.GetCurrentMethod().Name);
			buException.throwException(mSException, MethodBase.GetCurrentMethod().Name, ShowMessageBox: true, "");
		}
	}

	public void doSetProperties()
	{
		F_QuiltingSetProperties f_QuiltingSetProperties = new F_QuiltingSetProperties();
		f_QuiltingSetProperties.Setting = new QuiltingRuntimeSettings(varQuiltingRunSettings);
		f_QuiltingSetProperties.Init();
		f_QuiltingSetProperties.StartPosition = FormStartPosition.CenterParent;
		f_QuiltingSetProperties.ShowDialog();
		if (f_QuiltingSetProperties.PropertiesForm.Result == DialogResult.OK)
		{
			varQuiltingRunSettings = new QuiltingRuntimeSettings(f_QuiltingSetProperties.Setting);
			clsFiles.SaveParameter();
			for (int i = 0; i <= ccVars.SelectionOP.Selections.Count - 1; i++)
			{
				int index = ccVars.SelectionOP.Selections[i].Index;
				Entity entity = ccVars.Pages[ccVars.PageIndex].Form.viewportcad.Entities[index];
				((CustomData)entity.EntityData).Tags = Convert.ToInt32(varQuiltingRunSettings.Heads).ToString();
			}
			clsInit.appCommand.Reset();
		}
	}
}
