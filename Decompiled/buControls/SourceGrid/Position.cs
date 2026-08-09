using System;

namespace SourceGrid;

[Serializable]
public struct Position(int row, int col)
{
	private int m_Row = row;

	private int m_Col = col;

	public static readonly Position Empty;

	public const int c_EmptyIndex = -1;

	public int Row => m_Row;

	public int Column => m_Col;

	static Position()
	{
		Empty = new Position(-1, -1);
	}

	public bool IsEmpty()
	{
		return Equals(Empty);
	}

	public override int GetHashCode()
	{
		return Row;
	}

	public bool Equals(Position p_Position)
	{
		return m_Col == p_Position.m_Col && m_Row == p_Position.m_Row;
	}

	public override bool Equals(object obj)
	{
		return Equals((Position)obj);
	}

	public static bool operator ==(Position Left, Position Right)
	{
		return Left.Equals(Right);
	}

	public static bool operator !=(Position Left, Position Right)
	{
		return !Left.Equals(Right);
	}

	public override string ToString()
	{
		return Row + ";" + Column;
	}

	public static Position Min(Position p_Position1, Position p_Position2)
	{
		int row = ((p_Position1.Row < p_Position2.Row) ? p_Position1.Row : p_Position2.Row);
		int col = ((p_Position1.Column < p_Position2.Column) ? p_Position1.Column : p_Position2.Column);
		return new Position(row, col);
	}

	public static Position Max(Position p_Position1, Position p_Position2)
	{
		int row = ((p_Position1.Row > p_Position2.Row) ? p_Position1.Row : p_Position2.Row);
		int col = ((p_Position1.Column > p_Position2.Column) ? p_Position1.Column : p_Position2.Column);
		return new Position(row, col);
	}
}
