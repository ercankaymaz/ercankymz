using System;

namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class StandardValueAttribute : Attribute
{
	private object standardValue;

	public object StandardValue
	{
		get
		{
			return standardValue;
		}
		set
		{
			standardValue = value;
		}
	}

	public StandardValueAttribute(object standardValue)
	{
		this.standardValue = standardValue;
	}
}
