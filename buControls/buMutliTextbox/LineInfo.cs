// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.LineInfo
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public struct LineInfo(int startY)
{
  private List<int> list_0 = (List<int>) null;
  internal int startY = startY;
  internal int int_0 = 0;
  internal int int_1 = 0;
  public VisibleState VisibleState = VisibleState.Visible;

  public List<int> CutOffPositions
  {
    get
    {
      if (this.list_0 == null)
        this.list_0 = new List<int>();
      return this.list_0;
    }
  }

  public int WordWrapStringsCount
  {
    get
    {
      int wrapStringsCount;
      switch (this.VisibleState)
      {
        case VisibleState.Visible:
          wrapStringsCount = this.list_0 != null ? this.list_0.Count + 1 : 1;
          break;
        case VisibleState.StartOfHiddenBlock:
          wrapStringsCount = 1;
          break;
        case VisibleState.Hidden:
          wrapStringsCount = 0;
          break;
        default:
          wrapStringsCount = 0;
          break;
      }
      return wrapStringsCount;
    }
  }

  internal int method_0(int int_2) => int_2 == 0 ? 0 : this.CutOffPositions[int_2 - 1];

  internal int method_1(int int_2, Line line_0)
  {
    return this.WordWrapStringsCount > 0 ? (int_2 == this.WordWrapStringsCount - 1 ? line_0.Count - 1 : this.CutOffPositions[int_2] - 1) : 0;
  }

  public int GetWordWrapStringIndex(int iChar)
  {
    int wordWrapStringIndex;
    if ((this.list_0 == null ? 1 : (this.list_0.Count == 0 ? 1 : 0)) != 0)
    {
      wordWrapStringIndex = 0;
    }
    else
    {
      for (int index = 0; index < this.list_0.Count; ++index)
      {
        if (this.list_0[index] > iChar)
        {
          wordWrapStringIndex = index;
          goto label_8;
        }
      }
      wordWrapStringIndex = this.list_0.Count;
    }
label_8:
    return wordWrapStringIndex;
  }
}
