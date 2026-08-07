// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace SourceGrid;

[Serializable]
public class RangeCollection : List<Range>
{
  public bool ContainsCell(Position p_Position)
  {
    bool flag;
    foreach (Range range in (List<Range>) this)
    {
      if (range.Contains(p_Position))
      {
        flag = true;
        goto label_7;
      }
    }
    flag = false;
label_7:
    return flag;
  }
}
