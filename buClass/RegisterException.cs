// Decompiled with JetBrains decompiler
// Type: buClass.RegisterException
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace buClass;

public class RegisterException : ApplicationException
{
  public RegisterException(string str)
    : base("Without Permission Using")
  {
    int num = (int) MessageBox.Show(str, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
    Environment.Exit(0);
  }
}
