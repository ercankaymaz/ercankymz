using System;

namespace CSUtilities.Attributes;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class StringValueAttribute : Attribute
{
	public string Value { get; }

	public StringValueAttribute(string value)
	{
		Value = value;
	}
}
