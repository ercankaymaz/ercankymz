// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMotion, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: F5000E34-965A-4264-B97F-117192F983D9
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMotion.dll

using buMotion;
using System;
using System.IO;
using System.Windows.Forms;

#nullable disable
namespace \u0001;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal sealed class \u0001 : Attribute
{
  public static void saveLogList()
  {
    if (TechnicianType.LogList == null)
      return;
    TextWriter textWriter1 = (TextWriter) File.AppendText($"{Application.StartupPath}\\{buMotionColors.LogFileName}");
    for (int index = 0; index <= TechnicianType.LogList.Count - 1; ++index)
      textWriter1.Write(TechnicianType.LogList[index]);
    textWriter1.Close();
    TextWriter textWriter2 = (TextWriter) File.AppendText($"{Application.StartupPath}\\{buMotionColors.SeasonFileName}");
    for (int index = 0; index <= TechnicianType.LogList.Count - 1; ++index)
      textWriter2.Write(TechnicianType.LogList[index]);
    textWriter2.Close();
    TechnicianType.LogList.Clear();
  }
}
