using System;

namespace SourceGrid;

[Serializable]
public struct Range
{
	private Position m_Start;

	private Position m_End;

	public static readonly Range Empty;

	public Position Start => m_Start;

	public Position End => m_End;

	public int ColumnsCount
	{
		get
		{
			return m_End.Column - m_Start.Column + 1;
		}
		set
		{
			if (value <= 0)
			{
				throw new SourceGridException("Invalid columns count");
			}
			m_End = new Position(m_End.Row, m_Start.Column + value - 1);
		}
	}

	public int RowsCount
	{
		get
		{
			return m_End.Row - m_Start.Row + 1;
		}
		set
		{
			if (value <= 0)
			{
				throw new SourceGridException("Invalid columns count");
			}
			m_End = new Position(m_Start.Row + value - 1, m_End.Column);
		}
	}

	public Range(Position p_Start, Position p_End)
	{
		this = new Range(p_Start, p_End, bool_0: true);
	}

	public static Range FromPosition(Position startPosition)
	{
		return new Range(startPosition);
	}

	public static Range From(Position startPosition, int rowCount, int colCount)
	{
		Range result = new Range(startPosition);
		result.RowsCount = rowCount;
		result.ColumnsCount = colCount;
		return result;
	}

	public Range(int p_StartRow, int p_StartCol, int p_EndRow, int p_EndCol)
	{
		m_Start = new Position(p_StartRow, p_StartCol);
		m_End = new Position(p_EndRow, p_EndCol);
		method_0();
	}

	private Range(Position position_0, Position position_1, bool bool_0)
	{
		m_Start = position_0;
		m_End = position_1;
		if (bool_0)
		{
			method_0();
		}
	}

	static Range()
	{
		Empty = new Range(Position.Empty, Position.Empty, bool_0: false);
	}

	public void MoveTo(Position p_StartPosition)
	{
		int columnsCount = ColumnsCount;
		int rowsCount = RowsCount;
		m_Start = p_StartPosition;
		RowsCount = rowsCount;
		ColumnsCount = columnsCount;
	}

	public Range(Position p_SinglePosition)
	{
		this = new Range(p_SinglePosition, p_SinglePosition, bool_0: false);
	}

	private void method_0()
	{
		int row = ((m_Start.Row < m_End.Row) ? m_Start.Row : m_End.Row);
		int col = ((m_Start.Column < m_End.Column) ? m_Start.Column : m_End.Column);
		int row2 = ((m_Start.Row > m_End.Row) ? m_Start.Row : m_End.Row);
		int col2 = ((m_Start.Column > m_End.Column) ? m_Start.Column : m_End.Column);
		m_Start = new Position(row, col);
		m_End = new Position(row2, col2);
	}

	public bool ContainsRow(int p_Row)
	{
		return p_Row >= m_Start.Row && p_Row <= m_End.Row;
	}

	public bool ContainsColumn(int p_Col)
	{
		return p_Col >= m_Start.Column && p_Col <= m_End.Column;
	}

	public bool Contains(Position p_Position)
	{
		return p_Position.Row >= m_Start.Row && p_Position.Column >= m_Start.Column && p_Position.Row <= m_End.Row && p_Position.Column <= m_End.Column;
	}

	public bool Contains(Range p_Range)
	{
		return Contains(p_Range.Start) && Contains(p_Range.End);
	}

	public bool IsEmpty()
	{
		return Start.IsEmpty() || End.IsEmpty();
	}

	public static bool operator ==(Range Left, Range Right)
	{
		return Left.Equals(Right);
	}

	public static bool operator !=(Range Left, Range Right)
	{
		return !Left.Equals(Right);
	}

	public override int GetHashCode()
	{
		return m_Start.Row;
	}

	public bool Equals(Range p_Range)
	{
		return Start.Equals(p_Range.Start) && End.Equals(p_Range.End);
	}

	public override bool Equals(object obj)
	{
		return Equals((Range)obj);
	}

	public PositionCollection GetCellsPositions()
	{
		PositionCollection positionCollection = new PositionCollection();
		for (int i = Start.Row; i <= End.Row; i++)
		{
			for (int j = Start.Column; j <= End.Column; j++)
			{
				positionCollection.Add(new Position(i, j));
			}
		}
		return positionCollection;
	}

	public override string ToString()
	{
		return Start.ToString() + " to " + End.ToString();
	}

	public static RangeRegion Union(Range p_Range1, Range p_Range2)
	{
		RangeRegion rangeRegion = new RangeRegion();
		rangeRegion.Add(p_Range1);
		rangeRegion.Add(p_Range2);
		return rangeRegion;
	}

	public static Range GetBounds(Range p_Range1, Range p_Range2)
	{
		if (!p_Range1.IsEmpty())
		{
			if (!p_Range2.IsEmpty())
			{
				return new Range(Position.Min(p_Range1.Start, p_Range2.Start), Position.Max(p_Range1.End, p_Range2.End), bool_0: false);
			}
			return p_Range1;
		}
		return p_Range2;
	}

	public static Range Intersect(Range p_Range1, Range p_Range2)
	{
		if (!p_Range1.IsEmpty() && !p_Range2.IsEmpty())
		{
			Position position_ = Position.Max(p_Range1.Start, p_Range2.Start);
			Position position_2 = Position.Min(p_Range1.End, p_Range2.End);
			if (position_.Column <= position_2.Column && position_.Row <= position_2.Row)
			{
				return new Range(position_, position_2, bool_0: false);
			}
			return Empty;
		}
		return Empty;
	}

	public Range Intersect(Range p_Range)
	{
		return Intersect(this, p_Range);
	}

	public static bool IntersectsWith(Range p_Range1, Range p_Range2)
	{
		return !Intersect(p_Range1, p_Range2).IsEmpty();
	}

	public bool IntersectsWith(Range p_Range)
	{
		return IntersectsWith(this, p_Range);
	}

	public RangeRegion Exclude(Range range)
	{
		Range range2 = Intersect(range);
		RangeRegion rangeRegion;
		if (!range2.IsEmpty())
		{
			rangeRegion = new RangeRegion();
			if (Start.Row < range2.Start.Row && Start.Column < range2.Start.Column)
			{
				rangeRegion.Add(new Range(Start.Row, Start.Column, range2.Start.Row - 1, range2.Start.Column - 1));
			}
			if (Start.Row < range2.Start.Row)
			{
				rangeRegion.Add(new Range(Start.Row, range2.Start.Column, range2.Start.Row - 1, range2.End.Column));
			}
			if (Start.Row < range2.Start.Row && End.Column > range2.End.Column)
			{
				rangeRegion.Add(new Range(Start.Row, range2.End.Column + 1, range2.Start.Row - 1, End.Column));
			}
			if (Start.Column < range2.Start.Column)
			{
				rangeRegion.Add(new Range(range2.Start.Row, Start.Column, range2.End.Row, range2.Start.Column - 1));
			}
			if (End.Column > range2.End.Column)
			{
				rangeRegion.Add(new Range(range2.Start.Row, range2.End.Column + 1, range2.End.Row, End.Column));
			}
			if (End.Row > range2.End.Row && Start.Column < range2.Start.Column)
			{
				rangeRegion.Add(new Range(range2.End.Row + 1, Start.Column, End.Row, range2.Start.Column - 1));
			}
			if (End.Row > range2.End.Row)
			{
				rangeRegion.Add(new Range(range2.End.Row + 1, range2.Start.Column, End.Row, range2.End.Column));
			}
			if (End.Row > range2.End.Row && End.Column > range2.End.Column)
			{
				rangeRegion.Add(new Range(range2.End.Row + 1, range2.End.Column + 1, End.Row, End.Column));
			}
		}
		else
		{
			rangeRegion = new RangeRegion(this);
		}
		return rangeRegion;
	}
}
