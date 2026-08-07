// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Models.IRichTextBox
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid.Cells.Models;

public interface IRichTextBox : IModel
{
  void SetSelectionFont(CellContext cellContext, Font font);

  Font GetSelectionFont(CellContext cellContext);

  void SetSelectionColor(CellContext cellContext, Color color);

  Color GetSelectionColor(CellContext cellContext);

  void SetSelectionCharOffset(CellContext cellContext, int charOffset);

  int GetSelectionCharOffset(CellContext cellContext);

  void SetSelectionAlignment(CellContext cellContext, HorizontalAlignment horAlignment);

  HorizontalAlignment GetSelectionAlignment(CellContext cellContext);
}
