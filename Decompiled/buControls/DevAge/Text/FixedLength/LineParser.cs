using System;
using System.Reflection;
using System.Text.RegularExpressions;
using ns27;

namespace DevAge.Text.FixedLength;

public class LineParser
{
	internal FieldList fieldList_0;

	private Regex regex_0;

	private char char_0 = '\0';

	private Match match_0;

	public FieldList Fields => fieldList_0;

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

	public LineParser()
	{
		fieldList_0 = new FieldList();
	}

	public LineParser(Type lineClassType)
	{
		fieldList_0 = Utilities.ExtractFieldListFromType(lineClassType);
	}

	public void Reset()
	{
		regex_0 = null;
		match_0 = null;
	}

	public void LoadLine(string line)
	{
		if (regex_0 == null)
		{
			regex_0 = Class76.smethod_370(this);
		}
		match_0 = regex_0.Match(line);
	}

	public object GetValue(string fieldName)
	{
		if (match_0 != null)
		{
			Group obj = match_0.Groups[fieldName];
			if (!obj.Success)
			{
				throw new RegExException(fieldName);
			}
			return fieldList_0[fieldName].StringToValue(obj.Value);
		}
		throw new ArgumentNullException("mRegExMatch");
	}

	public object FillLineClass(object schemaClass)
	{
		if (match_0 != null)
		{
			PropertyInfo[] properties = schemaClass.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
			PropertyInfo[] array = properties;
			foreach (PropertyInfo propertyInfo in array)
			{
				object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(FieldAttribute), inherit: true);
				if (customAttributes.Length != 0)
				{
					propertyInfo.SetValue(schemaClass, GetValue(propertyInfo.Name), null);
				}
			}
			return schemaClass;
		}
		throw new ArgumentNullException("mRegExMatch", "LoadLine not called");
	}
}
