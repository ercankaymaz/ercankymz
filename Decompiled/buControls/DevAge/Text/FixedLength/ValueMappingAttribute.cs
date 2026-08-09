using System;

namespace DevAge.Text.FixedLength;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
public class ValueMappingAttribute : Attribute
{
	private string string_0;

	private object object_0;

	public string StringValue
	{
		get
		{
			return string_0;
		}
		set
		{
			string_0 = value;
		}
	}

	public object FieldValue
	{
		get
		{
			return object_0;
		}
		set
		{
			object_0 = value;
		}
	}

	public ValueMappingAttribute(string stringValue, object fieldValue)
	{
		StringValue = stringValue;
		FieldValue = fieldValue;
	}
}
