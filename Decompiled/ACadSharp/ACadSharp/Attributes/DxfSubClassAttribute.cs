using System;

namespace ACadSharp.Attributes;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DxfSubClassAttribute : Attribute
{
	public string ClassName { get; }

	public bool IsEmpty { get; }

	public DxfSubClassAttribute(string className)
	{
		ClassName = className;
	}

	public DxfSubClassAttribute(string className, bool isEmpty)
		: this(className)
	{
		IsEmpty = isEmpty;
	}
}
