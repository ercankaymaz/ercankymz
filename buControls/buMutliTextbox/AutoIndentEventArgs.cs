// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.AutoIndentEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class AutoIndentEventArgs : EventArgs
{
  public AutoIndentEventArgs(
    int iLine,
    string lineText,
    string prevLineText,
    int tabLength,
    int currentIndentation)
  {
    this.iLine = iLine;
    this.LineText = lineText;
    this.PrevLineText = prevLineText;
    this.TabLength = tabLength;
    this.AbsoluteIndentation = currentIndentation;
  }

  public int iLine { get; internal set; }

  public int TabLength { get; internal set; }

  public string LineText { get; internal set; }

  public string PrevLineText { get; internal set; }

  public int Shift { get; set; }

  public int ShiftNextLines { get; set; }

  public int AbsoluteIndentation { get; set; }
}
