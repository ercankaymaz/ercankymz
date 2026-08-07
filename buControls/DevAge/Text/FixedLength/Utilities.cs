// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.Utilities
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using ns7;
using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection;

#nullable disable
namespace DevAge.Text.FixedLength;

public class Utilities
{
  public static IValidator CreateValidator(Type type, ParseFormatAttribute parseAttributes)
  {
    bool bool_0;
    type = Class39.smethod_809(ref bool_0, type);
    TypeConverter p_TypeConverter = Class39.smethod_498(parseAttributes, type);
    ValidatorTypeConverter validator = new ValidatorTypeConverter(type, p_TypeConverter);
    validator.CultureInfo = parseAttributes.CultureInfo;
    validator.NullString = "";
    validator.NullDisplayString = "";
    validator.AllowNull = bool_0;
    return (IValidator) validator;
  }

  public static FieldList ExtractFieldListFromType(Type classType)
  {
    FieldList fieldListFromType = new FieldList();
    foreach (PropertyInfo property in classType.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty))
    {
      FieldAttribute fieldAttribute = (FieldAttribute) null;
      ParseFormatAttribute parseAttributes = (ParseFormatAttribute) null;
      object[] customAttributes1 = property.GetCustomAttributes(typeof (FieldAttribute), true);
      if (customAttributes1.Length != 0)
        fieldAttribute = (FieldAttribute) customAttributes1[0];
      object[] customAttributes2 = property.GetCustomAttributes(typeof (ParseFormatAttribute), true);
      if (customAttributes2.Length != 0)
        parseAttributes = (ParseFormatAttribute) customAttributes2[0];
      object[] customAttributes3 = property.GetCustomAttributes(typeof (ValueMappingAttribute), true);
      object[] customAttributes4 = property.GetCustomAttributes(typeof (StandardValueAttribute), true);
      if (fieldAttribute != null)
      {
        if (parseAttributes == null)
          parseAttributes = new ParseFormatAttribute();
        IValidator validator = Utilities.CreateValidator(property.PropertyType, parseAttributes);
        fieldListFromType.Add((IField) new Field(fieldAttribute.FieldIndex, property.Name, fieldAttribute.Length, validator)
        {
          TrimBeforeParse = parseAttributes.TrimBeforeParse
        });
        if (customAttributes3.Length != 0)
        {
          ValueMapping valueMapping = new ValueMapping();
          object[] objArray1 = new object[customAttributes3.Length];
          object[] objArray2 = new object[customAttributes3.Length];
          for (int index = 0; index < customAttributes3.Length; ++index)
          {
            objArray1[index] = validator.ObjectToValue(((ValueMappingAttribute) customAttributes3[index]).FieldValue);
            objArray2[index] = (object) ((ValueMappingAttribute) customAttributes3[index]).StringValue;
          }
          valueMapping.ThrowErrorIfNotFound = false;
          valueMapping.ValueList = (IList) objArray1;
          valueMapping.SpecialList = (IList) objArray2;
          valueMapping.SpecialType = typeof (string);
          valueMapping.BindValidator(validator);
        }
        if (customAttributes4.Length != 0)
        {
          object[] objArray = new object[customAttributes4.Length];
          for (int index = 0; index < customAttributes4.Length; ++index)
            objArray[index] = ((StandardValueAttribute) customAttributes4[index]).StandardValue;
          validator.StandardValues = (ICollection) objArray;
          validator.StandardValuesExclusive = true;
        }
      }
    }
    return fieldListFromType;
  }

  public static string ValidateRegExpSeparator(char separator)
  {
    string str;
    if (separator == char.MinValue)
    {
      str = string.Empty;
    }
    else
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
          str = "\\" + separator.ToString();
          break;
        default:
          str = separator.ToString();
          break;
      }
    }
    return str;
  }
}
