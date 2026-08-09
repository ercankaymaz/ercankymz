using System;
using System.ComponentModel;
using System.Reflection;
using DevAge.ComponentModel.Validator;
using ns27;

namespace DevAge.Text.FixedLength;

public class Utilities
{
	public static IValidator CreateValidator(Type type, ParseFormatAttribute parseAttributes)
	{
		bool bool_ = default(bool);
		type = Class76.smethod_809(ref bool_, type);
		TypeConverter p_TypeConverter = Class76.smethod_498(parseAttributes, type);
		ValidatorTypeConverter validatorTypeConverter = new ValidatorTypeConverter(type, p_TypeConverter);
		validatorTypeConverter.CultureInfo = parseAttributes.CultureInfo;
		validatorTypeConverter.NullString = "";
		validatorTypeConverter.NullDisplayString = "";
		validatorTypeConverter.AllowNull = bool_;
		return validatorTypeConverter;
	}

	public static FieldList ExtractFieldListFromType(Type classType)
	{
		FieldList fieldList = new FieldList();
		PropertyInfo[] properties = classType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);
		PropertyInfo[] array = properties;
		foreach (PropertyInfo propertyInfo in array)
		{
			FieldAttribute fieldAttribute = null;
			ParseFormatAttribute parseFormatAttribute = null;
			object[] customAttributes = propertyInfo.GetCustomAttributes(typeof(FieldAttribute), inherit: true);
			if (customAttributes.Length != 0)
			{
				fieldAttribute = (FieldAttribute)customAttributes[0];
			}
			customAttributes = propertyInfo.GetCustomAttributes(typeof(ParseFormatAttribute), inherit: true);
			if (customAttributes.Length != 0)
			{
				parseFormatAttribute = (ParseFormatAttribute)customAttributes[0];
			}
			object[] customAttributes2 = propertyInfo.GetCustomAttributes(typeof(ValueMappingAttribute), inherit: true);
			object[] customAttributes3 = propertyInfo.GetCustomAttributes(typeof(StandardValueAttribute), inherit: true);
			if (fieldAttribute == null)
			{
				continue;
			}
			if (parseFormatAttribute == null)
			{
				parseFormatAttribute = new ParseFormatAttribute();
			}
			IValidator validator = CreateValidator(propertyInfo.PropertyType, parseFormatAttribute);
			Field field = new Field(fieldAttribute.FieldIndex, propertyInfo.Name, fieldAttribute.Length, validator);
			field.TrimBeforeParse = parseFormatAttribute.TrimBeforeParse;
			fieldList.Add(field);
			if (customAttributes2.Length != 0)
			{
				ValueMapping valueMapping = new ValueMapping();
				object[] array2 = new object[customAttributes2.Length];
				object[] array3 = new object[customAttributes2.Length];
				for (int j = 0; j < customAttributes2.Length; j++)
				{
					array2[j] = validator.ObjectToValue(((ValueMappingAttribute)customAttributes2[j]).FieldValue);
					array3[j] = ((ValueMappingAttribute)customAttributes2[j]).StringValue;
				}
				valueMapping.ThrowErrorIfNotFound = false;
				valueMapping.ValueList = array2;
				valueMapping.SpecialList = array3;
				valueMapping.SpecialType = typeof(string);
				valueMapping.BindValidator(validator);
			}
			if (customAttributes3.Length != 0)
			{
				object[] array4 = new object[customAttributes3.Length];
				for (int k = 0; k < customAttributes3.Length; k++)
				{
					array4[k] = ((StandardValueAttribute)customAttributes3[k]).StandardValue;
				}
				validator.StandardValues = array4;
				validator.StandardValuesExclusive = true;
			}
		}
		return fieldList;
	}

	public static string ValidateRegExpSeparator(char separator)
	{
		if (separator != 0)
		{
			switch (separator)
			{
			case '$':
			case '(':
			case ')':
			case '*':
			case '+':
			case '?':
			case '[':
			case '\\':
			case '^':
			case '{':
			case '|':
				return "\\" + separator;
			default:
				return separator.ToString();
			}
		}
		return string.Empty;
	}
}
