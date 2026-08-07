// Decompiled with JetBrains decompiler
// Type: MarbleCNC.Program
// Assembly: CMDMarbleCNC, Version=3.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: 99805DCC-380E-4FBC-B708-84554BBCD25B
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\CMDMarbleCNC.exe

using System;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace MarbleCNC;

internal static class Program
{
  [STAThread]
  private static void Main(string[] arcg)
  {
    using (Mutex mutex = new Mutex(false, "Global\\f2a3eef4-cfb1-407d-9076-cc35aa5ace26"))
    {
      if (!mutex.WaitOne(0, false))
      {
        int num = (int) MessageBox.Show("Instance already running");
      }
      else
      {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run((Form) new F_Intro());
      }
    }
  }
}
