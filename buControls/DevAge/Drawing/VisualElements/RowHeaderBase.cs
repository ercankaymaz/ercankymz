// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.RowHeaderBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Drawing.VisualElements;

[Serializable]
public abstract class RowHeaderBase : 
  HeaderBase,
  ICloneable,
  IVisualElement,
  IBackground,
  IHeader,
  IRowHeader
{
  public RowHeaderBase()
  {
  }

  public RowHeaderBase(RowHeaderBase other)
    : base((HeaderBase) other)
  {
  }
}
