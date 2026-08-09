using System;
using System.Collections;

namespace Microsoft.Windows.Design.Interaction;

public sealed class RelativePosition : IEnumerable
{
	private RelativePosition[] _values;

	private string _name;

	public RelativePosition(params RelativePosition[] values)
		: this(null, values)
	{
	}

	public RelativePosition(string name, params RelativePosition[] values)
	{
		if (values == null)
		{
			throw new ArgumentNullException("values");
		}
		if (values.Length > 0)
		{
			int num = CountValues(values);
			_values = new RelativePosition[num];
			FillValues(_values, values, 0);
		}
		else
		{
			_values = values;
		}
		if (name == null || name.Length == 0)
		{
			name = ((_values.Length <= 0) ? string.Empty : string.Concat((object[])_values));
		}
		_name = name;
	}

	public bool Contains(RelativePosition value)
	{
		if (value == null)
		{
			throw new ArgumentNullException("value");
		}
		if (object.ReferenceEquals(value, this))
		{
			return true;
		}
		RelativePosition[] values = _values;
		foreach (RelativePosition objB in values)
		{
			if (object.ReferenceEquals(value, objB))
			{
				return true;
			}
		}
		return false;
	}

	private static int CountValues(RelativePosition[] values)
	{
		int num = 0;
		foreach (RelativePosition relativePosition in values)
		{
			num = ((relativePosition._values.Length <= 0) ? (num + 1) : (num + CountValues(relativePosition._values)));
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		RelativePosition relativePosition = obj as RelativePosition;
		if (relativePosition != null)
		{
			return Equals(relativePosition);
		}
		return false;
	}

	public bool Equals(RelativePosition position)
	{
		if (object.ReferenceEquals(position, null))
		{
			return false;
		}
		if (object.ReferenceEquals(position, this))
		{
			return true;
		}
		if (_values.Length == 0)
		{
			return false;
		}
		if (position._values.Length != _values.Length)
		{
			return false;
		}
		int num = 0;
		for (int i = 0; i < _values.Length; i++)
		{
			for (int j = 0; j < position._values.Length; j++)
			{
				if (object.ReferenceEquals(_values[i], position._values[j]))
				{
					num++;
					break;
				}
			}
		}
		return num == _values.Length;
	}

	private static int FillValues(RelativePosition[] array, RelativePosition[] values, int startingIndex)
	{
		foreach (RelativePosition relativePosition in values)
		{
			if (relativePosition._values.Length > 0)
			{
				startingIndex = FillValues(array, relativePosition._values, startingIndex);
			}
			else
			{
				array[startingIndex++] = relativePosition;
			}
		}
		return startingIndex;
	}

	public override int GetHashCode()
	{
		if (_values.Length > 0)
		{
			int num = _values[0].GetHashCode();
			for (int i = 1; i < _values.Length; i++)
			{
				num ^= _values[i].GetHashCode();
			}
			return num;
		}
		return base.GetHashCode();
	}

	public override string ToString()
	{
		if (_name != null)
		{
			return _name;
		}
		return base.ToString();
	}

	public static bool operator ==(RelativePosition point1, RelativePosition point2)
	{
		if (object.ReferenceEquals(point1, point2))
		{
			return true;
		}
		if (object.ReferenceEquals(point1, null))
		{
			return false;
		}
		return point1.Equals(point2);
	}

	public static bool operator !=(RelativePosition point1, RelativePosition point2)
	{
		if (object.ReferenceEquals(point1, point2))
		{
			return false;
		}
		if (object.ReferenceEquals(point1, null))
		{
			return true;
		}
		return !point1.Equals(point2);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		if (_values != null && _values.Length > 0)
		{
			return _values.GetEnumerator();
		}
		return new RelativePosition[1] { this }.GetEnumerator();
	}
}
