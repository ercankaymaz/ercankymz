using MS.Internal;

namespace Microsoft.Windows.Design.Interaction;

public struct RelativeValue(RelativePosition reference, double value)
{
	private RelativePosition _reference = reference;

	private double _value = value;

	public RelativePosition Position
	{
		get
		{
			return _reference;
		}
		set
		{
			_reference = value;
		}
	}

	public double Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
		}
	}

	public override bool Equals(object obj)
	{
		if (obj is RelativeValue relativeValue)
		{
			return this == relativeValue;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _reference.GetHashCode() ^ _value.GetHashCode();
	}

	public static bool operator ==(RelativeValue first, RelativeValue second)
	{
		if (first._reference == second._reference)
		{
			return MathUtilities.AreClose(first._value, second._value);
		}
		return false;
	}

	public static bool operator !=(RelativeValue first, RelativeValue second)
	{
		if (!(first._reference != second._reference))
		{
			return !MathUtilities.AreClose(first._value, second._value);
		}
		return true;
	}
}
