using System;

namespace Microsoft.Windows.Design.PropertyEditing;

public struct KeyAttributePair<T>(string key, T value) where T : Attribute
{
	private string key = key;

	private T value = value;

	public string Key => key;

	public T Value => value;

	public static bool operator ==(KeyAttributePair<T> pair1, KeyAttributePair<T> pair2)
	{
		return pair1.Equals(pair2);
	}

	public static bool operator !=(KeyAttributePair<T> pair1, KeyAttributePair<T> pair2)
	{
		return !(pair1 == pair2);
	}

	public override bool Equals(object obj)
	{
		if (!(obj is KeyAttributePair<T> keyAttributePair))
		{
			return false;
		}
		if (!string.Equals(Key, keyAttributePair.Key))
		{
			return false;
		}
		return object.Equals(Value, keyAttributePair.Value);
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (Key == null)
		{
			num ^= Key.GetHashCode();
		}
		if (Value != null)
		{
			int num2 = num;
			T val = Value;
			num = num2 ^ val.GetHashCode();
		}
		return num;
	}
}
