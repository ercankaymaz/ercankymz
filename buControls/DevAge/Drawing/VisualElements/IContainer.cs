// Decompiled with JetBrains decompiler
// Type: DevAge.Drawing.VisualElements.IContainer
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Drawing;

#nullable disable
namespace DevAge.Drawing.VisualElements;

public interface IContainer : ICloneable, IVisualElement
{
  RectangleF GetContentRectangle(MeasureHelper measure, RectangleF backGroundArea);

  SizeF GetExtent(MeasureHelper measure, SizeF contentSize);
}
