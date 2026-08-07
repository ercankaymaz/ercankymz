// Decompiled with JetBrains decompiler
// Type: buDahengSolutions.Program
// Assembly: buCameraSolutions, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 81083553-F2AE-41B0-A4DA-8E8442C4C023
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\Camera\Canon\buCameraSolutions.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace buDahengSolutions;

internal static class Program
{
  [STAThread]
  private static void Main()
  {
    // ISSUE: reference to a compiler-generated method
    ApplicationConfiguration.Initialize();
    Application.Run((Form) new Form1());
  }
}
