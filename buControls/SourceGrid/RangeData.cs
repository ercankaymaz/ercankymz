// Decompiled with JetBrains decompiler
// Type: SourceGrid.RangeData
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using SourceGrid.Cells;
using System;
using System.Text;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

[Serializable]
public class RangeData
{
  public const string RANGEDATA_FORMAT = "SourceGrid.RangeData";
  [Obsolete]
  private Position mStartDragPosition;
  private Range mSourceRange;
  private object[,] mSourceValues;
  [NonSerialized]
  private GridVirtual mSourceGrid;
  [Obsolete]
  private CutMode mCutMode = CutMode.None;
  [NonSerialized]
  private DataObject dataObject_0 = (DataObject) null;

  static RangeData() => DataFormats.GetFormat("SourceGrid.RangeData");

  public RangeData()
  {
  }

  public RangeData(GridVirtual mSourceGrid)
    : this()
  {
    this.mSourceGrid = mSourceGrid;
  }

  public Range SourceRange => this.mSourceRange;

  public object[,] SourceValues => this.mSourceValues;

  [Obsolete]
  public Position StartDragPosition => this.mStartDragPosition;

  public GridVirtual SourceGrid => this.mSourceGrid;

  [Obsolete]
  public CutMode CutMode => this.mCutMode;

  [Obsolete("Use LoadData method without startDragPosition")]
  public void LoadData(
    GridVirtual sourceGrid,
    Range sourceRange,
    Position startDragPosition,
    CutMode cutMode)
  {
    this.LoadData(sourceGrid, sourceRange, Position.Empty, cutMode);
  }

  public static RangeData LoadData(GridVirtual sourceGrid, Range sourceRange, CutMode cutMode)
  {
    RangeData data = new RangeData(sourceGrid);
    data.mSourceRange = sourceRange;
    data.mSourceValues = new object[sourceRange.RowsCount, Class39.smethod_237(sourceRange, sourceGrid)];
    int index1 = 0;
    int row1 = sourceRange.Start.Row;
    while (true)
    {
      int num1 = row1;
      Position position1 = sourceRange.End;
      int row2 = position1.Row;
      if (num1 <= row2)
      {
        int index2 = 0;
        position1 = sourceRange.Start;
        int column1 = position1.Column;
        while (true)
        {
          int num2 = column1;
          position1 = sourceRange.End;
          int column2 = position1.Column;
          if (num2 <= column2)
          {
            if (sourceGrid.Columns.IsColumnVisible(column1))
            {
              Position position2 = new Position(row1, column1);
              ICellVirtual cell = sourceGrid.GetCell(position2);
              CellContext cellContext = new CellContext(sourceGrid, position2, cell);
              if (cell != null)
                data.mSourceValues[index1, index2] = cellContext.Value;
              ++index2;
            }
            ++column1;
          }
          else
            break;
        }
        ++row1;
        ++index1;
      }
      else
        break;
    }
    if ((cutMode != CutMode.CutImmediately ? 0 : (sourceGrid != null ? 1 : 0)) != 0)
      sourceGrid.ClearValues(new RangeRegion(sourceRange));
    data.dataObject_0 = new DataObject();
    data.dataObject_0.SetData("SourceGrid.RangeData", (object) data);
    string[,] stringArray = RangeData.DataToStringArray(sourceGrid, data.mSourceRange);
    data.dataObject_0.SetData(typeof (string), (object) RangeData.StringArrayToString(stringArray));
    return data;
  }

  public void LoadData(string data)
  {
    this.mSourceGrid = (GridVirtual) null;
    this.StringToData(data, out this.mSourceRange, out this.mSourceValues);
    this.dataObject_0 = new DataObject();
    this.dataObject_0.SetData("SourceGrid.RangeData", (object) this);
    this.dataObject_0.SetData(typeof (string), (object) RangeData.StringArrayToString(this.mSourceValues as string[,]));
  }

  public void WriteData(GridVirtual sourceGrid, Position destinationPosition)
  {
    int upperBound1 = this.SourceValues.GetUpperBound(0);
    int upperBound2 = this.SourceValues.GetUpperBound(1);
    int index1 = 0;
    for (int row = destinationPosition.Row; row <= destinationPosition.Row + upperBound1; ++row)
    {
      int index2 = 0;
      for (int column = destinationPosition.Column; column <= destinationPosition.Column + upperBound2; ++column)
      {
        Position position = new Position(row, column);
        ICellVirtual cell = sourceGrid.GetCell(position);
        CellContext cellContext = new CellContext(sourceGrid, position, cell);
        if ((cell == null || cell.Editor == null ? 0 : (this.mSourceValues[index1, index2] != null ? 1 : 0)) != 0)
          cell.Editor.SetCellValue(cellContext, this.mSourceValues[index1, index2]);
        ++index2;
      }
      ++index1;
    }
  }

  protected virtual void StringToData(string data, out Range range, out object[,] values)
  {
    data = data.Replace("\r\n", "\n");
    string[] strArray1 = data.Split('\n', '\r');
    int length1 = strArray1.Length;
    if ((length1 <= 0 ? 0 : (strArray1[length1 - 1] == null ? 1 : (strArray1[length1 - 1].Length == 0 ? 1 : 0))) != 0)
      --length1;
    if (length1 == 0)
    {
      range = Range.Empty;
      values = (object[,]) new string[0, 0];
    }
    else
    {
      int length2 = strArray1[0].Split('\t').Length;
      range = new Range(0, 0, length1 - 1, length2 - 1);
      values = (object[,]) new string[length1, length2];
      int index1 = 0;
      Position position = range.Start;
      int row = position.Row;
      while (true)
      {
        int num1 = row;
        position = range.Start;
        int num2 = position.Row + length1;
        if (num1 < num2)
        {
          string[] strArray2 = strArray1[index1].Split('\t');
          int index2 = 0;
          position = range.Start;
          int column1 = position.Column;
          while (true)
          {
            int num3 = column1;
            position = range.End;
            int column2 = position.Column;
            if (num3 <= column2)
            {
              values[index1, index2] = index2 >= strArray2.Length ? (object) "" : (object) strArray2[index2];
              ++column1;
              ++index2;
            }
            else
              break;
          }
          ++row;
          ++index1;
        }
        else
          break;
      }
    }
  }

  protected static string StringArrayToString(string[,] values)
  {
    StringBuilder stringBuilder = new StringBuilder();
    int length1 = values.GetLength(0);
    int length2 = values.GetLength(1);
    for (int index1 = 0; index1 < length1; ++index1)
    {
      for (int index2 = 0; index2 < length2; ++index2)
      {
        stringBuilder.Append(values[index1, index2]);
        if (index2 != length1 - 1)
          stringBuilder.Append('\t');
      }
      if (index1 != length1 - 1)
        stringBuilder.Append("\r\n");
    }
    return stringBuilder.ToString();
  }

  protected static string[,] DataToStringArray(GridVirtual sourceGrid, Range range)
  {
    Position position1 = range.End;
    int row1 = position1.Row;
    position1 = range.Start;
    int row2 = position1.Row;
    int length1 = row1 - row2 + 1;
    Position position2 = range.End;
    int column1 = position2.Column;
    position2 = range.Start;
    int column2 = position2.Column;
    int length2 = column1 - column2 + 1;
    string[,] stringArray = new string[length1, length2];
    int index1 = 0;
    int row3 = range.Start.Row;
    while (true)
    {
      int num1 = row3;
      Position position3 = range.End;
      int row4 = position3.Row;
      if (num1 <= row4)
      {
        int index2 = 0;
        position3 = range.Start;
        int column3 = position3.Column;
        while (true)
        {
          int num2 = column3;
          position3 = range.End;
          int column4 = position3.Column;
          if (num2 <= column4)
          {
            Position position4 = new Position(row3, column3);
            ICellVirtual cell = sourceGrid.GetCell(position4);
            CellContext cellContext = new CellContext(sourceGrid, position4, cell);
            if ((cell == null || cell.Editor == null ? 0 : (cell.Editor.IsStringConversionSupported() ? 1 : 0)) != 0)
              stringArray[index1, index2] = cell.Editor.ValueToString(cell.Model.ValueModel.GetValue(cellContext));
            else if (cell != null)
              stringArray[index1, index2] = cellContext.DisplayText;
            ++column3;
            ++index2;
          }
          else
            break;
        }
        ++row3;
        ++index1;
      }
      else
        break;
    }
    return stringArray;
  }

  [Obsolete("Completely not used. Will be removed in future versions")]
  public Range FindDestinationRange(GridVirtual destinationGrid, Position dropDestination)
  {
    Range destinationRange;
    if (dropDestination.IsEmpty())
    {
      destinationRange = Range.Empty;
    }
    else
    {
      Position p_Position1;
      ref Position local = ref p_Position1;
      int row1 = dropDestination.Row;
      Position start = this.mSourceRange.Start;
      int num1 = start.Row - this.mStartDragPosition.Row;
      int row2 = row1 + num1;
      int column = dropDestination.Column;
      start = this.mSourceRange.Start;
      int num2 = start.Column - this.mStartDragPosition.Column;
      int col = column + num2;
      local = new Position(row2, col);
      Position p_StartPosition = Position.Max(p_Position1, new Position(0, 0));
      Range mSourceRange = this.mSourceRange;
      mSourceRange.MoveTo(p_StartPosition);
      destinationRange = mSourceRange.Intersect(destinationGrid.CompleteRange);
    }
    return destinationRange;
  }

  public static void ClipboardSetData(RangeData rangeData)
  {
    if (rangeData.dataObject_0 == null)
      throw new SourceGridException("No data loaded, use the LoadData method");
    Clipboard.SetDataObject((object) rangeData.dataObject_0);
  }

  public static RangeData ClipboardGetData()
  {
    IDataObject dataObject = Clipboard.GetDataObject();
    RangeData data1 = (RangeData) null;
    if (dataObject.GetDataPresent("SourceGrid.RangeData"))
      data1 = (RangeData) dataObject.GetData("SourceGrid.RangeData");
    if (data1 == null && dataObject.GetDataPresent(DataFormats.UnicodeText, true))
    {
      string data2 = (string) dataObject.GetData(DataFormats.UnicodeText, true);
      data1 = new RangeData();
      data1.LoadData(data2);
    }
    return data1;
  }
}
