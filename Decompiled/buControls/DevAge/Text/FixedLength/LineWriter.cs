using System;
using System.Reflection;
using System.Text;

namespace DevAge.Text.FixedLength;

public class LineWriter
{
	private FieldList fields;

	private IField[] ifield_0;

	private char char_0 = '\0';

	private object[] object_0;

	public FieldList Fields => fields;

	public char Separator
	{
		get
		{
			return char_0;
		}
		set
		{
			char_0 = value;
		}
	}

	public LineWriter(FieldList fields)
	{
		this.fields = fields;
	}

	public LineWriter(Type lineClassType)
	{
		fields = Utilities.ExtractFieldListFromType(lineClassType);
	}

	public void Reset()
	{
		object_0 = null;
	}

	public void SetValue(string fieldName, object val)
	{
		if (object_0 == null)
		{
			object_0 = new object[fields.Count];
		}
		if (ifield_0 == null)
		{
			ifield_0 = fields.GetSortedList();
		}
		object_0[fields[fieldName].Index] = val;
	}

	public string CreateLine()
	{
		if (object_0 != null)
		{
			if (ifield_0 == null)
			{
				ifield_0 = fields.GetSortedList();
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < ifield_0.Length; i++)
			{
				stringBuilder.Append(ifield_0[i].ValueToString(object_0[i]));
				if (Separator != 0)
				{
					stringBuilder.Append(Separator);
				}
			}
			return stringBuilder.ToString();
		}
		throw new ArgumentNullException("mLineValues", "SetValue not called");
	}

	public string CreateLineFromClass(object schemaClass)
	{
		PropertyInfo[] properties = schemaClass.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(FieldAttribute), inherit: true);
			if (customAttributes.Length != 0)
			{
				SetValue(propertyInfo.Name, propertyInfo.GetValue(schemaClass, null));
			}
		}
		return CreateLine();
	}
}
