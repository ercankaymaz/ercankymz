using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

namespace devDept.Eyeshot.Control.Converters;

public class EnumDescriptionConverter : EnumConverter
{
	protected Type myType;

	public EnumDescriptionConverter(Type type)
		: base(type)
	{
		myType = type;
	}

	public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
	{
		if (value is Enum)
		{
			if (destinationType == typeof(string))
			{
				return EnumDescription.GetDescription((Enum)value);
			}
			if (destinationType == typeof(Enum[]))
			{
				return new Enum[1] { (Enum)value };
			}
		}
		if (value is string && destinationType == typeof(string))
		{
			return EnumDescription.GetDescription(myType, (string)value);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
	{
		if (value is string)
		{
			return EnumDescription.GetValue(myType, (string)value);
		}
		if (value is Enum)
		{
			return EnumDescription.GetDescription((Enum)value);
		}
		return base.ConvertFrom(context, culture, value);
	}

	public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
	{
		MemberInfo[] members = myType.GetMembers(BindingFlags.Static | BindingFlags.Public);
		List<string> list = new List<string>();
		MemberInfo[] array = members;
		foreach (MemberInfo memberInfo in array)
		{
			list.Add(memberInfo.Name);
		}
		return new StandardValuesCollection(list);
	}
}
