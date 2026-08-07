// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.ICheckBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace DevAge.Drawing.VisualElements;

public interface ICheckBox : ICloneable, IVisualElement
{
  ControlDrawStyle Style { get; set; }

  CheckBoxState CheckBoxState { get; set; }
}
