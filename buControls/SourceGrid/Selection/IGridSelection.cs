// Decompiled with JetBrains decompiler
// Type: SourceGrid.Selection.IGridSelection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

#nullable disable
namespace SourceGrid.Selection;

public interface IGridSelection
{
  event RangeRegionChangedEventHandler SelectionChanged;

  RangeRegion GetSelectionRegion();

  bool IsSelectedRow(int row);

  bool CanReceiveFocus(Position position);

  bool FocusFirstCell(bool pResetSelection);

  void BindToGrid(GridVirtual p_grid);

  void UnBindToGrid();

  bool MoveActiveCell(int rowShift1, int colShift1, int rowShift2, int colShift2);

  bool MoveActiveCell(int rowShift, int colShift);

  bool MoveActiveCell(int rowShift, int colShift, bool resetSelection);

  bool IsEmpty();

  void Invalidate();

  void SelectRange(Range range, bool select);

  void SelectCell(Position position, bool select);

  bool IsSelectedCell(Position position);

  bool EnableMultiSelection { get; set; }

  void ResetSelection(bool mantainFocus);

  void SelectRow(int row, bool select);

  void SelectColumn(int column, bool select);

  bool FocusRow(int row);

  bool FocusColumn(int column);

  bool Focus(Position pCellToActivate, bool pResetSelection);

  Position ActivePosition { get; }

  FocusStyle FocusStyle { get; set; }

  event ChangeActivePositionEventHandler CellGotFocus;

  event ChangeActivePositionEventHandler CellLostFocus;

  event RowCancelEventHandler FocusRowLeaving;

  event RowEventHandler FocusRowEntered;

  event ColumnCancelEventHandler FocusColumnLeaving;

  event ColumnEventHandler FocusColumnEntered;
}
