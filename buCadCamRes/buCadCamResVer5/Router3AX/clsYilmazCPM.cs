// Decompiled with JetBrains decompiler
// Type: buCadCamResVer5.Router3AX.clsYilmazCPM
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using buClass;
using buControls.Forms.WinControlForms.Notepad;
using buEyeBaseVer5;
using buEyeBaseVer5.Apps;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace buCadCamResVer5.Router3AX;

public class clsYilmazCPM
{
  private string string_0 = nameof (clsYilmazCPM);

  public void cmdShowCode(bool SaveFile, bool SelectedJob = false)
  {
    string str1 = nameof (cmdShowCode);
    try
    {
      bool flag1 = true;
      string Lines = "";
      string FileName = "";
      bool flag2 = true;
      if ((clsRouter3AX.JobList == null ? 0 : (clsRouter3AX.JobList.Count > 0 ? 1 : 0)) != 0)
        flag1 = false;
      if (SelectedJob)
        flag1 = SelectedJob;
      if (flag1)
      {
        if (SaveFile)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
          saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
          saveFileDialog.FilterIndex = 1;
          flag2 = false;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            flag2 = true;
            FileName = saveFileDialog.FileName;
            clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
          }
        }
        if (flag2)
        {
          clsInit.appRouter3AX.activeJob.Index = 1;
          this.CreateGCode(clsInit.appRouter3AX.activeJob, ccVars.PostActive, ref Lines);
          string str2;
          if (SaveFile)
          {
            buFile5.SaveToFile(Lines, FileName);
            str2 = "";
            clsFiles.SaveParameter();
          }
          else
          {
            F_Notepad fNotepad = new F_Notepad();
            fNotepad.Init(Lines);
            fNotepad.Show();
            str2 = "";
          }
        }
      }
      else
      {
        if (SaveFile)
        {
          SaveFileDialog saveFileDialog = new SaveFileDialog();
          saveFileDialog.InitialDirectory = clsVar.varInterface.pathGCode;
          saveFileDialog.Filter = $"{ccVars.PostActive.FileExplanation} ({ccVars.PostActive.FileExtension})|{ccVars.PostActive.FileExtension}";
          saveFileDialog.FilterIndex = 1;
          bool flag3 = false;
          if (saveFileDialog.ShowDialog() == DialogResult.OK)
          {
            flag3 = true;
            FileName = saveFileDialog.FileName;
            clsVar.varInterface.pathGCode = buFile5.GetPath(saveFileDialog.FileName);
          }
        }
        string text = this.CodeFromList(clsRouter3AX.JobList, FileName);
        if (!SaveFile)
        {
          F_Notepad fNotepad = new F_Notepad();
          fNotepad.Init(text);
          fNotepad.Show();
        }
      }
      if (clsItem.FrmProgress == null)
        return;
      clsItem.FrmProgress.Visible = false;
    }
    catch (Exception ex)
    {
      if (clsItem.FrmProgress != null)
        clsItem.FrmProgress.Visible = false;
      buLogVer5.addToLog(this.string_0, str1, "Error", ex.Message, 0.0, 0.0, true);
      buException.throwException(ex, str1, true, "");
    }
  }

  public void AnalyzeCode(Router3AXItem Job, ref List<camTp> Cams)
  {
    string str = nameof (AnalyzeCode);
    try
    {
      Cams.Clear();
      Cams = new List<camTp>();
      for (int index1 = 0; index1 <= Job.CamList.Count - 1; ++index1)
      {
        if (Job.CamList[index1].CamData.CamPoints.Count > 0)
        {
          camTp camTp = new camTp(Job.CamList[index1].CamData);
          camTp.PreCodes.Add((object) $"( {Job.CamList[index1].CamName} {buLangTranslate.preDef.Tool}");
          for (int index2 = 0; index2 <= camTp.CamPoints.Count - 1; ++index2)
          {
            bool flag = false;
            for (int index3 = 0; index3 <= camTp.CamPoints[index2].Points.Count - 1; ++index3)
            {
              TpPnt9D point = camTp.CamPoints[index2].Points[index3];
              if (point.PlungeAxisMovement)
              {
                if (clsRouter3AX.varRouter3AXSettings.M75Mode)
                  point.AfterCodes.Add((object) "M75");
                point.AfterCodes.Add((object) $"G43 H{camTp.Tool.Data.No.ToString()} Z{point.P9.Z.ToString("f2")}");
              }
              if (point.LeaveAxisMovement)
              {
                if (clsRouter3AX.varRouter3AXSettings.M75Mode && index2 < camTp.CamPoints.Count - 1)
                  point.AfterCodes.Add((object) "M75");
                point.AfterCodes.Add((object) $"G43 H{camTp.Tool.Data.No.ToString()} Z{point.P9.Z.ToString("f2")}");
              }
              if (point.PlungeAxisMovement & !flag & ccVars.PostActive.EnterToPattern.MoveFirstPoint.AfterCode.Count > 0 & index2 == 0)
              {
                point.AfterCodes.AddRange((ICollection) ccVars.PostActive.EnterToPattern.MoveFirstPoint.AfterCode);
                flag = true;
              }
            }
          }
          bool flag1 = true;
          if (index1 < Job.CamList.Count - 1 && Job.CamList[index1].Tool.Data.No == Job.CamList[index1 + 1].Tool.Data.No)
            flag1 = false;
          if (flag1)
          {
            if (ccVars.PostActive.LeaveFromPattern.SafeDistance.AfterCode.Count > 0)
              camTp.CamPoints[camTp.CamPoints.Count - 1].AfterCodes.AddRange((ICollection) ccVars.PostActive.LeaveFromPattern.SafeDistance.AfterCode);
            camTp.CamPoints[camTp.CamPoints.Count - 1].AfterCodes.Add((object) "M5");
          }
          Cams.Add(camTp);
        }
      }
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", ex.Message, 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }

  public string CodeFromList(List<Router3AXItem> JobList, string FileName)
  {
    string str = nameof (CodeFromList);
    try
    {
      string withoutExtension = buFile5.getFileNameWithoutExtension(FileName);
      DirectoryInfo directoryInfo = new DirectoryInfo($"{clsVar.varInterface.pathGCode}\\{buFile5.getFileNameWithoutExtension(FileName)}");
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      if (!clsRouter3AX.varRouter3AXSettings.DualTable)
      {
        for (int index = 0; index <= JobList.Count - 1; ++index)
        {
          string Lines = "";
          JobList[index].Index = index + 1;
          this.CreateGCode(JobList[index], ccVars.PostActive, ref Lines);
          string FileName1 = $"{directoryInfo.FullName}\\{withoutExtension}{clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar}{(index + 1).ToString("D3")}{ccVars.PostActive.FileExtension.Replace("*", "")}";
          buFile5.SaveToFile(Lines, FileName1);
          clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[index].GCodeResult);
        }
      }
      else if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyA | clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyB | clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.SingleTable)
      {
        for (int index = 0; index <= JobList.Count - 1; ++index)
        {
          string Lines = "";
          JobList[index].Index = index + 1;
          this.CreateGCode(JobList[index], ccVars.PostActive, ref Lines);
          string FileName2 = $"{directoryInfo.FullName}\\{withoutExtension}{clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar}{(index + 1).ToString("D3")}{ccVars.PostActive.FileExtension.Replace("*", "")}";
          buFile5.SaveToFile(Lines, FileName2);
          clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[index].GCodeResult);
        }
      }
      else if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.TableAThenB)
      {
        string String = "";
        MachineTableType tableType = clsRouter3AX.varRouter3AXSettings.TableType;
        PostProcessor Post = new PostProcessor(ccVars.PostActive);
        if (Post.StartLinesFirstTable.Count > 0)
          Post.StartLinesFirstTable.RemoveAt(0);
        if (Post.StartLinesSecondTable.Count > 0)
          Post.StartLinesSecondTable.RemoveAt(0);
        if (Post.EndLinesFirstTable.Count > 0)
          Post.EndLinesFirstTable.RemoveAt(Post.EndLinesFirstTable.Count - 1);
        if (Post.EndLinesSecondTable.Count > 0)
          Post.EndLinesSecondTable.RemoveAt(Post.EndLinesSecondTable.Count - 1);
        double NLine = 1.0;
        for (int index = 0; index <= JobList.Count - 1; ++index)
        {
          string Lines = "";
          Post.NumberDef.Start = NLine;
          JobList[index].Index = index + 1;
          if (index == 0)
            Post.StartLinesFirstTable.Insert(0, (object) "M73");
          if (index % 2 == 0)
          {
            if (index == JobList.Count - 1)
              Post.EndLinesFirstTable.Add((object) "M30");
            clsRouter3AX.varRouter3AXSettings.TableType = MachineTableType.OnlyA;
            this.CreateGCode(JobList[index], Post, ref Lines);
            clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[index].GCodeResult);
          }
          else
          {
            if (index == JobList.Count - 1)
              Post.EndLinesSecondTable.Add((object) "M30");
            clsRouter3AX.varRouter3AXSettings.TableType = MachineTableType.OnlyB;
            this.CreateGCode(JobList[index], Post, ref Lines);
            clsInit.cCam5.GetGCodeExecutionResult(clsVar.varMachineGCodeConfig, Lines, ref JobList[index].GCodeResult);
          }
          String += Lines;
          if (index == 0 && Post.StartLinesFirstTable.Count > 0 && Post.StartLinesFirstTable[0].ToString() == "M73")
            Post.StartLinesFirstTable.RemoveAt(0);
          clsInit.cCam5.GetLastNLineCodeFromString(Lines, ref NLine);
          if (NLine > 0.0)
            ++NLine;
        }
        clsRouter3AX.varRouter3AXSettings.TableType = tableType;
        string FileName3 = $"{directoryInfo.FullName}\\{withoutExtension}{clsRouter3AX.varRouter3AXSettings.MultiGCodeSeparatorChar}001{ccVars.PostActive.FileExtension.Replace("*", "")}";
        buFile5.SaveToFile(String, FileName3);
      }
      return "";
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", ex.Message, 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
      return "";
    }
  }

  public void CreateGCode(Router3AXItem Job, PostProcessor Post, ref string Lines)
  {
    string str = nameof (CreateGCode);
    try
    {
      if (Job != null)
      {
        if (Job.CamList.Count > 0)
        {
          List<camTp> Cams = new List<camTp>();
          this.AnalyzeCode(Job, ref Cams);
          Lines = "";
          if (Cams.Count > 0)
          {
            double num1 = Job.CamList[0].MaxPoint.X;
            double num2 = Job.CamList[0].MaxPoint.Y;
            if ((Job.Stock == null || Job.Stock.SizeStock == null || Job.Stock.SizeStock.Width <= 0.0 ? 0 : (Job.Stock.SizeStock.Height > 0.0 ? 1 : 0)) != 0)
            {
              num1 = Job.Stock.SizeStock.Width;
              num2 = Job.Stock.SizeStock.Height;
            }
            PostProcessor Post1 = new PostProcessor(Post);
            if (!clsRouter3AX.varRouter3AXSettings.DualTable)
              Post1.StartLines.Insert(0, (object) $"( Sheet [ {Job.Index.ToString()} ] - Size = {num1.ToString("f1")} x {num2.ToString("f1")}");
            else if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyA)
            {
              Post1.StartLines.Clear();
              Post1.StartLines.Insert(0, (object) $"( Sheet [{Job.Index.ToString()}] - Size = {num1.ToString("f1")} x {num2.ToString("f1")}");
              Post1.StartLines.AddRange((ICollection) Post.StartLinesFirstTable);
              Post1.EndLines.Clear();
              Post1.EndLines.AddRange((ICollection) Post.EndLinesFirstTable);
            }
            else if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.OnlyB)
            {
              Post1.StartLines.Clear();
              Post1.StartLines.Insert(0, (object) $"( Sheet [{Job.Index.ToString()}] - Size = {num1.ToString("f1")} x {num2.ToString("f1")}");
              Post1.StartLines.AddRange((ICollection) Post.StartLinesSecondTable);
              Post1.EndLines.Clear();
              Post1.EndLines.AddRange((ICollection) Post.EndLinesSecondTable);
            }
            else if (clsRouter3AX.varRouter3AXSettings.TableType == MachineTableType.SingleTable)
            {
              Post1.StartLines.Clear();
              Post1.StartLines.Insert(0, (object) $"( Sheet [ {Job.Index.ToString()} ] - Size = {num1.ToString("f1")} x {num2.ToString("f1")}");
              Post1.StartLines.AddRange((ICollection) Post.StartLinesBothTable);
              Post1.EndLines.Clear();
              Post1.EndLines.AddRange((ICollection) Post.EndLinesBothTable);
            }
            clsInit.cGcodeCreate.CreatGCode(Cams, Post1, ref Lines);
          }
          else
            buString5.MessageBoxWarning(buLangTranslate.preSentences.NoToolpathAvailable);
        }
        else
          buString5.MessageBoxWarning(buLangTranslate.preSentences.NoOperationAvailableInJob);
      }
      else
        buString5.MessageBoxWarning(buLangTranslate.preSentences.CustomerClassNotReady);
    }
    catch (Exception ex)
    {
      buLogVer5.addToLog(this.string_0, str, "Error", ex.Message, 0.0, 0.0, true);
      buException.throwException(ex, str, true, "");
    }
  }
}
