using System;
using System.Diagnostics;

namespace SharpGLTF.Reflection;

[DebuggerDisplay("({ValueType}) {Name} = {Value}")]
public readonly struct FieldInfo
{
	private readonly Func<object, object> _Getter;

	public string Name { get; }

	public object Instance { get; }

	public bool IsEmpty => _Getter == null;

	public Type ValueType { get; }

	public object Value => _Getter(Instance);

	public static void Verify(IReflectionObject reflectionObject, string path)
	{
		if (_Extensions.Contains(path, "/extras/", StringComparison.Ordinal) || !From(reflectionObject, path).IsEmpty)
		{
			return;
		}
		throw new ArgumentException(path + " not found in the current model, add objects before animations, or disable verification.", "path");
	}

	public static FieldInfo From(IReflectionObject reflectionObject, string path)
	{
		while (path.Length > 0 && reflectionObject != null)
		{
			if (path[0] != '/')
			{
				throw new ArgumentException("invalid path: " + path, "path");
			}
			path = path.Substring(1);
			int num = path.IndexOf('/');
			if (num < 0)
			{
				num = path.Length;
			}
			string name = path.Substring(0, num);
			if (!reflectionObject.TryGetField(name, out var value))
			{
				return default(FieldInfo);
			}
			path = path.Substring(num);
			if (path.Length == 0)
			{
				return value;
			}
			reflectionObject = value.Value as IReflectionObject;
		}
		return default(FieldInfo);
	}

	public static FieldInfo From<TInstance, TValue>(string name, TInstance instance, Func<TInstance, TValue> getter)
	{
		return new FieldInfo(name, typeof(TValue), instance, (object inst) => getter((TInstance)inst));
	}

	private FieldInfo(string name, Type valueType, object instance, Func<object, object> getter)
	{
		Name = name;
		ValueType = valueType;
		Instance = instance;
		_Getter = getter;
	}
}
