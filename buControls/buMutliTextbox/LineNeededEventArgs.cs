// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.LineNeededEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace buMutliTextbox;

public class LineNeededEventArgs : EventArgs
{
  public string SourceLineText { get; private set; }

  public int DisplayedLineIndex { get; private set; }

  public string DisplayedLineText { get; set; }

  public LineNeededEventArgs(string sourceLineText, int displayedLineIndex)
  {
    this.SourceLineText = sourceLineText;
    this.DisplayedLineIndex = displayedLineIndex;
    this.DisplayedLineText = sourceLineText;
  }
}
