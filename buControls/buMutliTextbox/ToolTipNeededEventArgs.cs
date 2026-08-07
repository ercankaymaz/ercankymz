// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.ToolTipNeededEventArgs
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Windows.Forms;

#nullable disable
namespace buMutliTextbox;

public class ToolTipNeededEventArgs : EventArgs
{
  public ToolTipNeededEventArgs(Place place, string hoveredWord)
  {
    this.HoveredWord = hoveredWord;
    this.Place = place;
  }

  public Place Place { get; private set; }

  public string HoveredWord { get; private set; }

  public string ToolTipTitle { get; set; }

  public string ToolTipText { get; set; }

  public ToolTipIcon ToolTipIcon { get; set; }
}
