// Decompiled with JetBrains decompiler
// Type: DevAge.Shell.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Diagnostics;

#nullable disable
namespace DevAge.Shell;

public class Utilities
{
  public static void OpenFile(string p_File) => Utilities.ExecCommand(p_File);

  public static void ExecCommand(string p_Command)
  {
    new Process()
    {
      StartInfo = new ProcessStartInfo(p_Command)
      {
        UseShellExecute = true
      }
    }.Start();
  }
}
