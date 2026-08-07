// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Views.IView
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.Drawing;
using System;
using System.Drawing;

#nullable disable
namespace SourceGrid.Cells.Views;

public interface IView : ICloneable
{
  Font Font { get; set; }

  Font GetDrawingFont(GridVirtual grid);

  bool WordWrap { get; set; }

  DevAge.Drawing.ContentAlignment TextAlignment { get; set; }

  IBorder Border { get; set; }

  Color BackColor { get; set; }

  Color ForeColor { get; set; }

  void DrawCell(CellContext cellContext, GraphicsCache graphics, RectangleF rectangle);

  Size Measure(CellContext cellContext, Size maxLayoutArea);
}
