// Decompiled with JetBrains decompiler
// Type: SourceGrid.Range
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;

#nullable disable
namespace SourceGrid;

[Serializable]
public struct Range
{
  private Position m_Start;
  private Position m_End;
  public static readonly Range Empty = new Range(Position.Empty, Position.Empty, false);

  public Range(Position p_Start, Position p_End)
    : this(p_Start, p_End, true)
  {
  }

  public static Range FromPosition(Position startPosition) => new Range(startPosition);

  public static Range From(Position startPosition, int rowCount, int colCount)
  {
    return new Range(startPosition)
    {
      RowsCount = rowCount,
      ColumnsCount = colCount
    };
  }

  public Range(int p_StartRow, int p_StartCol, int p_EndRow, int p_EndCol)
  {
    this.m_Start = new Position(p_StartRow, p_StartCol);
    this.m_End = new Position(p_EndRow, p_EndCol);
    this.method_0();
  }

  private Range(Position position_0, Position position_1, bool bool_0)
  {
    this.m_Start = position_0;
    this.m_End = position_1;
    if (!bool_0)
      return;
    this.method_0();
  }

  public Position Start => this.m_Start;

  public Position End => this.m_End;

  public void MoveTo(Position p_StartPosition)
  {
    int columnsCount = this.ColumnsCount;
    int rowsCount = this.RowsCount;
    this.m_Start = p_StartPosition;
    this.RowsCount = rowsCount;
    this.ColumnsCount = columnsCount;
  }

  public int ColumnsCount
  {
    get => this.m_End.Column - this.m_Start.Column + 1;
    set
    {
      if (value <= 0)
        throw new SourceGridException("Invalid columns count");
      this.m_End = new Position(this.m_End.Row, this.m_Start.Column + value - 1);
    }
  }

  public int RowsCount
  {
    get => this.m_End.Row - this.m_Start.Row + 1;
    set
    {
      if (value <= 0)
        throw new SourceGridException("Invalid columns count");
      this.m_End = new Position(this.m_Start.Row + value - 1, this.m_End.Column);
    }
  }

  public Range(Position p_SinglePosition)
    : this(p_SinglePosition, p_SinglePosition, false)
  {
  }

  private void method_0()
  {
    int row1 = this.m_Start.Row >= this.m_End.Row ? this.m_End.Row : this.m_Start.Row;
    int col1 = this.m_Start.Column >= this.m_End.Column ? this.m_End.Column : this.m_Start.Column;
    int row2 = this.m_Start.Row <= this.m_End.Row ? this.m_End.Row : this.m_Start.Row;
    int col2 = this.m_Start.Column <= this.m_End.Column ? this.m_End.Column : this.m_Start.Column;
    this.m_Start = new Position(row1, col1);
    this.m_End = new Position(row2, col2);
  }

  public bool ContainsRow(int p_Row) => p_Row >= this.m_Start.Row && p_Row <= this.m_End.Row;

  public bool ContainsColumn(int p_Col)
  {
    return p_Col >= this.m_Start.Column && p_Col <= this.m_End.Column;
  }

  public bool Contains(Position p_Position)
  {
    return p_Position.Row >= this.m_Start.Row && p_Position.Column >= this.m_Start.Column && p_Position.Row <= this.m_End.Row && p_Position.Column <= this.m_End.Column;
  }

  public bool Contains(Range p_Range) => this.Contains(p_Range.Start) && this.Contains(p_Range.End);

  public bool IsEmpty() => this.Start.IsEmpty() || this.End.IsEmpty();

  public static bool operator ==(Range Left, Range Right) => Left.Equals(Right);

  public static bool operator !=(Range Left, Range Right) => !Left.Equals(Right);

  public override int GetHashCode() => this.m_Start.Row;

  public bool Equals(Range p_Range)
  {
    return this.Start.Equals(p_Range.Start) && this.End.Equals(p_Range.End);
  }

  public override bool Equals(object obj) => this.Equals((Range) obj);

  public PositionCollection GetCellsPositions()
  {
    PositionCollection cellsPositions = new PositionCollection();
    int row1 = this.Start.Row;
    while (true)
    {
      int num1 = row1;
      Position position = this.End;
      int row2 = position.Row;
      if (num1 <= row2)
      {
        position = this.Start;
        int column1 = position.Column;
        while (true)
        {
          int num2 = column1;
          position = this.End;
          int column2 = position.Column;
          if (num2 <= column2)
          {
            cellsPositions.Add(new Position(row1, column1));
            ++column1;
          }
          else
            break;
        }
        ++row1;
      }
      else
        break;
    }
    return cellsPositions;
  }

  public override string ToString()
  {
    Position position = this.Start;
    string str1 = position.ToString();
    position = this.End;
    string str2 = position.ToString();
    return $"{str1} to {str2}";
  }

  public static RangeRegion Union(Range p_Range1, Range p_Range2)
  {
    return new RangeRegion() { p_Range1, p_Range2 };
  }

  public static Range GetBounds(Range p_Range1, Range p_Range2)
  {
    return !p_Range1.IsEmpty() ? (!p_Range2.IsEmpty() ? new Range(Position.Min(p_Range1.Start, p_Range2.Start), Position.Max(p_Range1.End, p_Range2.End), false) : p_Range1) : p_Range2;
  }

  public static Range Intersect(Range p_Range1, Range p_Range2)
  {
    Range range;
    if ((p_Range1.IsEmpty() ? 1 : (p_Range2.IsEmpty() ? 1 : 0)) != 0)
    {
      range = Range.Empty;
    }
    else
    {
      Position position_0 = Position.Max(p_Range1.Start, p_Range2.Start);
      Position position_1 = Position.Min(p_Range1.End, p_Range2.End);
      range = (position_0.Column > position_1.Column ? 1 : (position_0.Row > position_1.Row ? 1 : 0)) == 0 ? new Range(position_0, position_1, false) : Range.Empty;
    }
    return range;
  }

  public Range Intersect(Range p_Range) => Range.Intersect(this, p_Range);

  public static bool IntersectsWith(Range p_Range1, Range p_Range2)
  {
    return !Range.Intersect(p_Range1, p_Range2).IsEmpty();
  }

  public bool IntersectsWith(Range p_Range) => Range.IntersectsWith(this, p_Range);

  public RangeRegion Exclude(Range range)
  {
    Range range1 = this.Intersect(range);
    RangeRegion rangeRegion1;
    if (range1.IsEmpty())
    {
      rangeRegion1 = new RangeRegion(this);
    }
    else
    {
      rangeRegion1 = new RangeRegion();
      int row1 = this.Start.Row;
      Position position = range1.Start;
      int row2 = position.Row;
      int num1;
      if (row1 < row2)
      {
        position = this.Start;
        int column1 = position.Column;
        position = range1.Start;
        int column2 = position.Column;
        num1 = column1 < column2 ? 1 : 0;
      }
      else
        num1 = 0;
      if (num1 != 0)
      {
        RangeRegion rangeRegion2 = rangeRegion1;
        position = this.Start;
        int row3 = position.Row;
        position = this.Start;
        int column = position.Column;
        position = range1.Start;
        int p_EndRow = position.Row - 1;
        position = range1.Start;
        int p_EndCol = position.Column - 1;
        Range pRange = new Range(row3, column, p_EndRow, p_EndCol);
        rangeRegion2.Add(pRange);
      }
      position = this.Start;
      int row4 = position.Row;
      position = range1.Start;
      int row5 = position.Row;
      if (row4 < row5)
      {
        RangeRegion rangeRegion3 = rangeRegion1;
        position = this.Start;
        int row6 = position.Row;
        position = range1.Start;
        int column3 = position.Column;
        position = range1.Start;
        int p_EndRow = position.Row - 1;
        position = range1.End;
        int column4 = position.Column;
        Range pRange = new Range(row6, column3, p_EndRow, column4);
        rangeRegion3.Add(pRange);
      }
      position = this.Start;
      int row7 = position.Row;
      position = range1.Start;
      int row8 = position.Row;
      int num2;
      if (row7 < row8)
      {
        position = this.End;
        int column5 = position.Column;
        position = range1.End;
        int column6 = position.Column;
        num2 = column5 > column6 ? 1 : 0;
      }
      else
        num2 = 0;
      if (num2 != 0)
      {
        RangeRegion rangeRegion4 = rangeRegion1;
        position = this.Start;
        int row9 = position.Row;
        position = range1.End;
        int p_StartCol = position.Column + 1;
        position = range1.Start;
        int p_EndRow = position.Row - 1;
        position = this.End;
        int column = position.Column;
        Range pRange = new Range(row9, p_StartCol, p_EndRow, column);
        rangeRegion4.Add(pRange);
      }
      position = this.Start;
      int column7 = position.Column;
      position = range1.Start;
      int column8 = position.Column;
      if (column7 < column8)
      {
        RangeRegion rangeRegion5 = rangeRegion1;
        position = range1.Start;
        int row10 = position.Row;
        position = this.Start;
        int column9 = position.Column;
        position = range1.End;
        int row11 = position.Row;
        position = range1.Start;
        int p_EndCol = position.Column - 1;
        Range pRange = new Range(row10, column9, row11, p_EndCol);
        rangeRegion5.Add(pRange);
      }
      position = this.End;
      int column10 = position.Column;
      position = range1.End;
      int column11 = position.Column;
      if (column10 > column11)
      {
        RangeRegion rangeRegion6 = rangeRegion1;
        position = range1.Start;
        int row12 = position.Row;
        position = range1.End;
        int p_StartCol = position.Column + 1;
        position = range1.End;
        int row13 = position.Row;
        position = this.End;
        int column12 = position.Column;
        Range pRange = new Range(row12, p_StartCol, row13, column12);
        rangeRegion6.Add(pRange);
      }
      position = this.End;
      int row14 = position.Row;
      position = range1.End;
      int row15 = position.Row;
      int num3;
      if (row14 > row15)
      {
        position = this.Start;
        int column13 = position.Column;
        position = range1.Start;
        int column14 = position.Column;
        num3 = column13 < column14 ? 1 : 0;
      }
      else
        num3 = 0;
      if (num3 != 0)
      {
        RangeRegion rangeRegion7 = rangeRegion1;
        position = range1.End;
        int p_StartRow = position.Row + 1;
        position = this.Start;
        int column15 = position.Column;
        position = this.End;
        int row16 = position.Row;
        position = range1.Start;
        int p_EndCol = position.Column - 1;
        Range pRange = new Range(p_StartRow, column15, row16, p_EndCol);
        rangeRegion7.Add(pRange);
      }
      position = this.End;
      int row17 = position.Row;
      position = range1.End;
      int row18 = position.Row;
      if (row17 > row18)
      {
        RangeRegion rangeRegion8 = rangeRegion1;
        position = range1.End;
        int p_StartRow = position.Row + 1;
        position = range1.Start;
        int column16 = position.Column;
        position = this.End;
        int row19 = position.Row;
        position = range1.End;
        int column17 = position.Column;
        Range pRange = new Range(p_StartRow, column16, row19, column17);
        rangeRegion8.Add(pRange);
      }
      position = this.End;
      int row20 = position.Row;
      position = range1.End;
      int row21 = position.Row;
      int num4;
      if (row20 > row21)
      {
        position = this.End;
        int column18 = position.Column;
        position = range1.End;
        int column19 = position.Column;
        num4 = column18 > column19 ? 1 : 0;
      }
      else
        num4 = 0;
      if (num4 != 0)
      {
        RangeRegion rangeRegion9 = rangeRegion1;
        position = range1.End;
        int p_StartRow = position.Row + 1;
        position = range1.End;
        int p_StartCol = position.Column + 1;
        position = this.End;
        int row22 = position.Row;
        position = this.End;
        int column20 = position.Column;
        Range pRange = new Range(p_StartRow, p_StartCol, row22, column20);
        rangeRegion9.Add(pRange);
      }
    }
    return rangeRegion1;
  }
}
