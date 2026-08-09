using System.Windows;

namespace Microsoft.Windows.Design.Interaction;

public struct RelativePoint
{
	private RelativePosition _position;

	private double _x;

	private double _y;

	public RelativePosition Position
	{
		get
		{
			if (_position == null)
			{
				_position = RelativePositions.TopLeft;
			}
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public RelativePoint(RelativePosition position, double x, double y)
	{
		_position = position;
		_x = x;
		_y = y;
	}

	public RelativePoint(RelativePosition position, Point point)
	{
		_position = position;
		_x = ((Point)(ref point)).X;
		_y = ((Point)(ref point)).Y;
	}

	public override bool Equals(object obj)
	{
		if (obj is RelativePoint)
		{
			return Equals((RelativePoint)obj);
		}
		return false;
	}

	public bool Equals(RelativePoint value)
	{
		if (Position == value.Position && X == value.X)
		{
			return Y == value.Y;
		}
		return false;
	}

	public static RelativePoint FromPoint(Point point)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return new RelativePoint(RelativePositions.TopLeft, point);
	}

	public override int GetHashCode()
	{
		return X.GetHashCode() ^ Y.GetHashCode();
	}

	public static bool operator ==(RelativePoint point1, RelativePoint point2)
	{
		if (point1.Position == point2.Position && point1.X == point2.X)
		{
			return point1.Y == point2.Y;
		}
		return false;
	}

	public static bool operator !=(RelativePoint point1, RelativePoint point2)
	{
		if (!(point1.Position != point2.Position) && point1.X == point2.X)
		{
			return point1.Y != point2.Y;
		}
		return true;
	}

	public static implicit operator RelativePoint(Point point)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		return new RelativePoint(RelativePositions.TopLeft, point);
	}
}
