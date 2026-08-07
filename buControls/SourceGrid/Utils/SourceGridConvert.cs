// Decompiled with JetBrains decompiler
// Type: SourceGrid.Utils.SourceGridConvert
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.ComponentModel;

#nullable disable
namespace SourceGrid.Utils;

public static class SourceGridConvert
{
  public static T To<T>(object value)
  {
    try
    {
      object obj = SourceGridConvert.To(value, typeof (T));
      return obj != null ? (T) obj : default (T);
    }
    catch (FormatException ex)
    {
      return default (T);
    }
  }

  public static object To(object value, Type type)
  {
    object obj;
    if (value == null)
      obj = (object) null;
    else if (value.GetType() == type)
    {
      obj = value;
    }
    else
    {
      if ((!type.IsGenericType ? 0 : (type.GetGenericTypeDefinition().Equals(typeof (Nullable<>)) ? 1 : 0)) != 0)
      {
        if ((!(value is string) ? 0 : (value.ToString() == string.Empty ? 1 : 0)) != 0)
        {
          obj = (object) null;
          goto label_13;
        }
        type = new NullableConverter(type).UnderlyingType;
      }
      if ((!type.IsEnum ? 0 : (Enum.IsDefined(type, value) ? 1 : 0)) != 0)
      {
        obj = Enum.Parse(type, value.ToString(), false);
      }
      else
      {
        TypeConverter converter1 = TypeDescriptor.GetConverter(type);
        if (converter1.CanConvertFrom(value.GetType()))
        {
          obj = converter1.ConvertFrom(value);
        }
        else
        {
          TypeConverter converter2 = TypeDescriptor.GetConverter(value.GetType());
          obj = !converter2.CanConvertTo(type) ? Convert.ChangeType(value, type) : converter2.ConvertTo(value, type);
        }
      }
    }
label_13:
    return obj;
  }
}
