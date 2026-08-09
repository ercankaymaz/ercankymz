namespace MS.Internal;

internal class EqualityArray
{
	private object[] _values;

	internal EqualityArray(params object[] values)
	{
		_values = values;
	}

	public override bool Equals(object other)
	{
		if (!(other is EqualityArray equalityArray))
		{
			return false;
		}
		if (equalityArray._values.Length != _values.Length)
		{
			return false;
		}
		for (int i = 0; i < _values.Length; i++)
		{
			if (_values[i] != equalityArray._values[i])
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return _values[0].GetHashCode();
	}
}
