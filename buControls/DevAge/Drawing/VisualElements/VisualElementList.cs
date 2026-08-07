// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.VisualElementList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public class VisualElementList : List<IVisualElement>, ICloneable
{
  public object Clone()
  {
    VisualElementList visualElementList = new VisualElementList();
    foreach (IVisualElement visualElement in (List<IVisualElement>) this)
      visualElementList.Add((IVisualElement) visualElement.Clone());
    return (object) visualElementList;
  }
}
