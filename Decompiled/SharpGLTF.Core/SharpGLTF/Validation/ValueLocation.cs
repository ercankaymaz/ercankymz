using System.Reflection;
using SharpGLTF.IO;

namespace SharpGLTF.Validation;

public readonly struct ValueLocation
{
	private readonly string _Name;

	private readonly int _Index;

	public static implicit operator ValueLocation(int index)
	{
		return new ValueLocation(string.Empty, index);
	}

	public static implicit operator ValueLocation(int? index)
	{
		return new ValueLocation(string.Empty, index.GetValueOrDefault());
	}

	public static implicit operator ValueLocation(string name)
	{
		return new ValueLocation(name);
	}

	public static implicit operator ValueLocation((string name, int index) tuple)
	{
		return new ValueLocation(tuple.name, tuple.index);
	}

	public static implicit operator ValueLocation((string name, int? index) tuple)
	{
		return new ValueLocation(tuple.name, tuple.index.GetValueOrDefault());
	}

	public static implicit operator string(ValueLocation location)
	{
		return location.ToString();
	}

	private ValueLocation(string name, int idx1 = -1)
	{
		_Name = name;
		_Index = idx1;
	}

	public override string ToString()
	{
		if (_Index >= 0)
		{
			return $"{_Name}[{_Index}]";
		}
		return _Name;
	}

	public string ToString(JsonSerializable target, string message)
	{
		return ToString(target) + " " + message;
	}

	public string ToString(JsonSerializable target)
	{
		if (target == null)
		{
			return ToString();
		}
		string text = target.GetType().Name;
		PropertyInfo property = target.GetType().GetProperty("LogicalIndex");
		if (property != null)
		{
			object value = property.GetValue(target);
			text += $"[{value}]";
		}
		return text + ToString();
	}
}
