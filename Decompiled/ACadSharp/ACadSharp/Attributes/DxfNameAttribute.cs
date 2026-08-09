using System;

namespace ACadSharp.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public sealed class DxfNameAttribute : Attribute
{
	public string Name { get; }

	public DxfNameAttribute(string name)
	{
		Name = name;
	}
}
