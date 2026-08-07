// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.Field
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System;

#nullable disable
namespace DevAge.Text.FixedLength;

public class Field : IField
{
  private int index;
  private string name;
  private int int_0;
  private bool bool_0 = true;
  private IValidator ivalidator_0;

  public Field(int index, string name, int length, Type type)
    : this(index, name, length, (IValidator) new ValidatorTypeConverter(type))
  {
  }

  public Field(int index, string name, int length, IValidator validator)
  {
    this.index = index;
    this.name = name;
    this.Length = length;
    this.Validator = validator;
  }

  public int Index => this.index;

  public string Name => this.name;

  public int Length
  {
    get => this.int_0;
    set => this.int_0 = value > 0 ? value : throw new InvalidFieldLengthException(value);
  }

  public bool TrimBeforeParse
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  public IValidator Validator
  {
    get => this.ivalidator_0;
    set
    {
      this.ivalidator_0 = value != null ? value : throw new ArgumentNullException(nameof (Validator));
    }
  }

  public virtual string RegularExpressionPattern
  {
    get => $"(?<{this.Name}>.{{{this.Length.ToString()}}})";
  }

  public virtual string ValueToString(object val)
  {
    try
    {
      string str = this.Validator.ValueToString(val) ?? string.Empty;
      if (str.Length > this.Length)
        throw new ValueNotValidLengthException(str, this.Length);
      if (str.Length < this.Length)
      {
        if (this.Validator.AllowNull)
          str = str.PadRight(this.Length, ' ');
        else if (this.Validator.ValueType == typeof (string))
          str = str.PadRight(this.Length, ' ');
        else if (this.Validator.ValueType == typeof (int))
        {
          str = str.PadLeft(this.Length, '0');
        }
        else
        {
          if (this.Validator.ValueType == typeof (double))
            throw new ValueNotValidLengthException(str, this.Length);
          if (this.Validator.ValueType == typeof (Decimal))
            throw new ValueNotValidLengthException(str, this.Length);
          throw new ValueNotSupportedException(str, this.Validator.ValueType);
        }
      }
      return str;
    }
    catch (Exception ex)
    {
      throw new FieldStringConvertException(this.Name, val, ex);
    }
  }

  public virtual object StringToValue(string str)
  {
    try
    {
      if ((!this.TrimBeforeParse ? 0 : (str != null ? 1 : 0)) != 0)
        str = str.Trim();
      return this.Validator.StringToValue(str);
    }
    catch (Exception ex)
    {
      throw new FieldParseException(this.Name, str, ex);
    }
  }
}
