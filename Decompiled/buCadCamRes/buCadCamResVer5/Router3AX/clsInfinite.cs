using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;

namespace buCadCamResVer5.Router3AX;

public class clsInfinite
{
	private string string_0 = "clsInfinite";

	public void cmdShowCode(bool SaveFile, bool SelectedJob = false)
	{
		string text = "cmdShowCode";
		try
		{
			bool flag = true;
			string Lines = "";
			string fileName = "";
			bool flag2 = true;
			if (clsRouter3AX.JobList != null && clsRouter3AX.JobList.Count > 0)
			{
				flag = false;
			}
			if (SelectedJob)
			{
				flag = SelectedJob;
			}
			if (!flag)
			{
				if (SaveFile)
				{
					SaveFileDialog saveFileDialog = new SaveFileDialog();
					saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog.FilterIndex = 1;
					flag2 = false;
					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						flag2 = true;
						fileName = saveFileDialog.FileName;
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
					}
				}
				string text2 = CodeFromList(clsRouter3AX.JobList, fileName);
				if (!SaveFile)
				{
					F_Notepad f_Notepad = new F_Notepad();
					f_Notepad.Init(text2);
					f_Notepad.Show();
					text2 = "";
				}
			}
			else
			{
				if (SaveFile)
				{
					SaveFileDialog saveFileDialog2 = new SaveFileDialog();
					saveFileDialog2.InitialDirectory = clsVar.varInterface.pathGCode;
					saveFileDialog2.Filter = ccVars.PostActive.FileExplanation + " (" + ccVars.PostActive.FileExtension + ")|" + ccVars.PostActive.FileExtension;
					saveFileDialog2.FilterIndex = 1;
					flag2 = false;
					if (saveFileDialog2.ShowDialog() == DialogResult.OK)
					{
						flag2 = true;
						fileName = saveFileDialog2.FileName;
						clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog2.FileName);
					}
				}
				if (flag2)
				{
					CreateGCode(clsInit.appRouter3AX.activeJob, ccVars.PostActive, ref Lines);
					clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref clsInit.appRouter3AX.activeJob.GCodeResult);
					if (!SaveFile)
					{
						F_Notepad f_Notepad2 = new F_Notepad();
						f_Notepad2.Init(Lines);
						f_Notepad2.Show();
						Lines = "";
					}
					else
					{
						buFile5.SaveToFile(Lines, fileName);
						Lines = "";
						clsFiles.SaveParameter();
					}
				}
			}
			if (clsItem.FrmProgress != null)
			{
				clsItem.FrmProgress.Visible = false;
			}
		}
		catch (Exception ex)
		{
			if (clsItem.FrmProgress != null)
			{
				clsItem.FrmProgress.Visible = false;
			}
			buLogVer5.addToLog(string_0, text, "Error", ex.Message, 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public void AnalyzeCode(Router3AXItem Job, ref List<camTp> Cams)
	{
		string text = "AnalyzeCode";
		try
		{
			Cams.Clear();
			Cams = new List<camTp>();
			for (int i = 0; i <= Job.CamList.Count - 1; i++)
			{
				if (Job.CamList[i].CamData.CamPoints.Count <= 0)
				{
					continue;
				}
				camTp camTp2 = new camTp(Job.CamList[i].CamData);
				for (int j = 0; j <= camTp2.CamPoints.Count - 1; j++)
				{
					bool flag = false;
					for (int k = 0; k <= camTp2.CamPoints[j].Points.Count - 1; k++)
					{
						TpPnt9D tpPnt9D = camTp2.CamPoints[j].Points[k];
						if (!tpPnt9D.PlungeAxisMovement)
						{
						}
						if (!tpPnt9D.LeaveAxisMovement)
						{
						}
						if ((tpPnt9D.PlungeAxisMovement && !flag) & (ccVars.PostActive.EnterToPattern.MoveFirstPoint.AfterCode.Count > 0))
						{
							tpPnt9D.AfterCodes.AddRange(ccVars.PostActive.EnterToPattern.MoveFirstPoint.AfterCode);
							flag = true;
						}
					}
					if (ccVars.PostActive.LeaveFromPattern.SafeDistance.AfterCode.Count > 0)
					{
						camTp2.CamPoints[j].AfterCodes.AddRange(ccVars.PostActive.LeaveFromPattern.SafeDistance.AfterCode);
					}
				}
				camTp2.CamPoints[camTp2.CamPoints.Count - 1].AfterCodes.Add("M5");
				Cams.Add(camTp2);
			}
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Error", ex.Message, 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}

	public string CodeFromList(List<Router3AXItem> JobList, string FileName)
	{
		string text = "CodeFromList";
		try
		{
			string fileNameWithoutExtension = buFile5.getFileNameWithoutExtension(FileName);
			string path = clsVar.varInterface.pathGCode + "\\" + buFile5.getFileNameWithoutExtension(FileName);
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (!directoryInfo.Exists)
			{
				directoryInfo.Create();
			}
			if (clsRouter3AX.varRouter3AXSettings.DualTable)
			{
				if (!((clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyA) | (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyB) | (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.SingleTable)))
				{
					if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.TableAThenB)
					{
						string text2 = "";
						MachineTableType tableType = clsRouter3AX.varRouter3AXSettings.TableType;
						PostProcessor postProcessor = new PostProcessor(ccVars.PostActive);
						if (postProcessor.StartLinesFirstTable.Count > 0)
						{
							postProcessor.StartLinesFirstTable.RemoveAt(0);
						}
						if (postProcessor.StartLinesSecondTable.Count > 0)
						{
							postProcessor.StartLinesSecondTable.RemoveAt(0);
						}
						if (postProcessor.EndLinesFirstTable.Count > 0)
						{
							postProcessor.EndLinesFirstTable.RemoveAt(postProcessor.EndLinesFirstTable.Count - 1);
						}
						if (postProcessor.EndLinesSecondTable.Count > 0)
						{
							postProcessor.EndLinesSecondTable.RemoveAt(postProcessor.EndLinesSecondTable.Count - 1);
						}
						double NLine = 1.0;
						for (int i = 0; i <= JobList.Count - 1; i++)
						{
							string Lines = "";
							postProcessor.NumberDef.Start = NLine;
							if (i == 0)
							{
								postProcessor.StartLinesFirstTable.Insert(0, "M73");
							}
							if (i % 2 != 0)
							{
								if (i == JobList.Count - 1)
								{
									postProcessor.EndLinesSecondTable.Add("M30");
								}
								clsRouter3AX.varRouter3AXSettings.TableType = MachineTableType.OnlyB;
								clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[i].GCodeResult);
								CreateGCode(JobList[i], postProcessor, ref Lines);
							}
							else
							{
								if (i == JobList.Count - 1)
								{
									postProcessor.EndLinesFirstTable.Add("M30");
								}
								clsRouter3AX.varRouter3AXSettings.TableType = MachineTableType.OnlyA;
								clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[i].GCodeResult);
								CreateGCode(JobList[i], postProcessor, ref Lines);
							}
							text2 += Lines;
							if (i == 0 && postProcessor.StartLinesFirstTable.Count > 0 && postProcessor.StartLinesFirstTable[0].ToString() == "M73")
							{
								postProcessor.StartLinesFirstTable.RemoveAt(0);
							}
							clsInit.cCam5.GetLastNLineCodeFromString(Lines, ref NLine);
							if (NLine > 0.0)
							{
								NLine += 1.0;
							}
						}
						clsRouter3AX.varRouter3AXSettings.TableType = tableType;
						string fileName = directoryInfo.FullName + "\\" + fileNameWithoutExtension + clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar + "001" + ccVars.PostActive.FileExtension.Replace("*", "");
						buFile5.SaveToFile(text2, fileName);
					}
				}
				else
				{
					for (int j = 0; j <= JobList.Count - 1; j++)
					{
						string Lines2 = "";
						CreateGCode(JobList[j], ccVars.PostActive, ref Lines2);
						string fileName2 = directoryInfo.FullName + "\\" + fileNameWithoutExtension + clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar + (j + 1).ToString("D3") + ccVars.PostActive.FileExtension.Replace("*", "");
						clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines2, ref JobList[j].GCodeResult);
						buFile5.SaveToFile(Lines2, fileName2);
					}
				}
			}
			else
			{
				for (int k = 0; k <= JobList.Count - 1; k++)
				{
					string Lines3 = "";
					CreateGCode(JobList[k], ccVars.PostActive, ref Lines3);
					string fileName3 = directoryInfo.FullName + "\\" + fileNameWithoutExtension + clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar + (k + 1).ToString("D3") + ccVars.PostActive.FileExtension.Replace("*", "");
					clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines3, ref JobList[k].GCodeResult);
					buFile5.SaveToFile(Lines3, fileName3);
				}
			}
			return "";
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Error", ex.Message, 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
			return "";
		}
	}

	public void CreateGCode(Router3AXItem Job, PostProcessor Post, ref string Lines)
	{
		string text = "CreateGCode";
		try
		{
			if (Job == null)
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.CustomerClassNotReady);
				return;
			}
			if (Job.CamList.Count <= 0)
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.NoOperationAvailableInJob);
				return;
			}
			List<camTp> Cams = new List<camTp>();
			AnalyzeCode(Job, ref Cams);
			Lines = "";
			if (Cams.Count <= 0)
			{
				buString5.MessageBoxWarning(buLangTranslate.preSentences.NoToolpathAvailable);
				return;
			}
			double num = Job.CamList[0].MaxPoint.X;
			double num2 = Job.CamList[0].MaxPoint.Y;
			if (Job.Stock != null && Job.Stock.SizeStock != null && Job.Stock.SizeStock.Width > 0.0 && Job.Stock.SizeStock.Height > 0.0)
			{
				num = Job.Stock.SizeStock.Width;
				num2 = Job.Stock.SizeStock.Height;
			}
			PostProcessor postProcessor = new PostProcessor(Post);
			if (clsRouter3AX.varRouter3AXSettings.DualTable)
			{
				if (clsRouter3AX.varRouter3AXSettings.TableType != MachineTableType.OnlyA)
				{
					if (clsRouter3AX.varRouter3AXSettings.TableType != MachineTableType.OnlyB)
					{
						if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.SingleTable)
						{
							postProcessor.StartLines.Clear();
							postProcessor.StartLines.Insert(0, "( Sheet Size = " + num.ToString("f1") + " x " + num2.ToString("f1"));
							postProcessor.StartLines.AddRange(Post.StartLinesBothTable);
							postProcessor.EndLines.Clear();
							postProcessor.EndLines.AddRange(Post.EndLinesBothTable);
						}
					}
					else
					{
						postProcessor.StartLines.Clear();
						postProcessor.StartLines.Insert(0, "( Sheet Size = " + num.ToString("f1") + " x " + num2.ToString("f1"));
						postProcessor.StartLines.AddRange(Post.StartLinesSecondTable);
						postProcessor.EndLines.Clear();
						postProcessor.EndLines.AddRange(Post.EndLinesSecondTable);
					}
				}
				else
				{
					postProcessor.StartLines.Clear();
					postProcessor.StartLines.Insert(0, "( Sheet Size = " + num.ToString("f1") + " x " + num2.ToString("f1"));
					postProcessor.StartLines.AddRange(Post.StartLinesFirstTable);
					postProcessor.EndLines.Clear();
					postProcessor.EndLines.AddRange(Post.EndLinesFirstTable);
				}
			}
			else
			{
				postProcessor.StartLines.Insert(0, "( Sheet Size = " + num.ToString("f1") + " x " + num2.ToString("f1"));
			}
			clsInit.cGcodeCreate.CreatGCode(Cams, postProcessor, ref Lines);
		}
		catch (Exception ex)
		{
			buLogVer5.addToLog(string_0, text, "Error", ex.Message, 0.0, 0.0, AddException: true);
			buException.throwException(ex, text, ShowMessageBox: true, "");
		}
	}
}
