// Decompiled with JetBrains decompiler
// Type: buClass.AppWarning
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

#nullable disable
namespace buClass;

[Serializable]
public class AppWarning : buSerilization
{
  public string Text = "";
  public string Axis = "";
  public int ID = -1;
  public double Code = 0.0;
  public int Option = 0;
  public string Aux = "";
  public bool Occured = false;
  public static List<string> Warnings = new List<string>();

  public AppWarning()
  {
  }

  public AppWarning(string text) => this.Text = text;

  public static void AddToWarning(AppWarning warning)
  {
    AppWarning.Warnings.Add($"{warning.Axis} : {warning.Text} - {warning.ID.ToString()} | {warning.Code.ToString()} | {warning.Option.ToString()} | {warning.Aux}");
  }

  public static void AddToWarning(string Message, int id, string Ax)
  {
    AppWarning.Warnings.Add($"{Ax} : {Message} - {id.ToString()}");
  }

  public static void AddToWarning(string Message) => AppWarning.Warnings.Add(Message);

  public void ClearWarning()
  {
    AppWarning.Warnings.Clear();
    this.Occured = false;
  }

  public static void AppendLogFile(string Filename, List<AppWarning> Warnings)
  {
    TextWriter textWriter = (TextWriter) null;
    try
    {
      if (Filename.Length < 1)
        return;
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      textWriter = (TextWriter) File.AppendText(Filename);
      for (int index = 0; index <= Warnings.Count - 1; ++index)
      {
        string str = $"{Warnings[index].Axis} ; {Warnings[index].Text} ; {Warnings[index].ID.ToString()} ; {Warnings[index].Code.ToString()} ; {Warnings[index].Option.ToString()} ; {Warnings[index].Aux};{DateTime.Now.ToString()}{Environment.NewLine}";
        textWriter.Write(str);
      }
      textWriter.Close();
    }
    catch (Exception ex)
    {
      string str = "Filename : " + Filename;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
      textWriter?.Close();
    }
  }

  public static void AppendLogFile(string Filename, AppWarning Warning)
  {
    TextWriter textWriter = (TextWriter) null;
    try
    {
      if (Filename.Length < 1)
        return;
      DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(Filename));
      if (!directoryInfo.Exists)
        directoryInfo.Create();
      textWriter = (TextWriter) File.AppendText(Filename);
      string str = $"{Warning.Axis} ; {Warning.Text} ; {Warning.ID.ToString()} ; {Warning.Code.ToString()} ; {Warning.Option.ToString()} ; {Warning.Aux};{DateTime.Now.ToString()}{Environment.NewLine}";
      textWriter.Write(str);
      textWriter.Close();
    }
    catch (Exception ex)
    {
      string str = "Filename : " + Filename;
      buLog.addLog(str, "Not Ok", MethodBase.GetCurrentMethod().Name);
      buException.throwException(ex, MethodBase.GetCurrentMethod().Name, false, str);
    }
    finally
    {
      textWriter?.Close();
    }
  }
}
