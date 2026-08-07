// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Validator.ValidatorBase
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;

#nullable disable
namespace DevAge.ComponentModel.Validator;

[ToolboxItem(false)]
public class ValidatorBase : ComponentLight, IValidator
{
  private bool bool_0;
  private string string_0;
  private string string_1;
  private bool bool_1 = true;
  private ConvertingObjectEventHandler convertingObjectEventHandler_0;
  private ConvertingObjectEventHandler convertingObjectEventHandler_1;
  private ConvertingObjectEventHandler convertingObjectEventHandler_2;
  private object object_0 = (object) null;
  private object object_1 = (object) null;
  private Type type_0;
  private object object_2;
  private ICollection icollection_0;
  private bool bool_2;
  private CultureInfo cultureInfo_0 = (CultureInfo) null;
  private EventHandler eventHandler_0;

  public ValidatorBase() => this.ValueType = (Type) null;

  public ValidatorBase(Type type) => this.ValueType = type;

  protected virtual void OnLoadingValueType()
  {
    if (this.ValueType != (Type) null)
    {
      if (this.ValueType.IsValueType)
      {
        this.bool_0 = false;
        this.object_2 = !this.ValueType.IsEnum ? Activator.CreateInstance(this.ValueType) : this.ValueType.GetFields(BindingFlags.Static | BindingFlags.Public)[0].GetValue((object) null);
      }
      else
      {
        this.object_2 = (object) null;
        this.bool_0 = true;
      }
      this.icollection_0 = (ICollection) null;
      this.bool_2 = false;
      this.object_1 = (object) null;
      this.object_0 = (object) null;
      this.string_0 = "";
      this.string_1 = "";
    }
    else
    {
      this.bool_0 = true;
      this.object_2 = (object) null;
      this.icollection_0 = (ICollection) null;
      this.bool_2 = false;
      this.object_1 = (object) null;
      this.object_0 = (object) null;
      this.string_0 = "";
      this.string_1 = "";
    }
  }

  [System.ComponentModel.DefaultValue(true)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool AllowNull
  {
    get => this.bool_0;
    set
    {
      if (this.bool_0 == value)
        return;
      this.bool_0 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue("")]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string NullString
  {
    get => this.string_0;
    set
    {
      if (!(this.string_0 != value))
        return;
      this.string_0 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue("")]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string NullDisplayString
  {
    get => this.string_1;
    set
    {
      if (!(this.string_1 != value))
        return;
      this.string_1 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  public virtual bool IsNullString(string p_str) => p_str == null || p_str == this.string_0;

  public virtual string ObjectToStringForError(object val)
  {
    try
    {
      return val == null ? "<null>" : val.ToString();
    }
    catch (Exception ex)
    {
      return "<object>";
    }
  }

  public object ObjectToValue(object p_Object)
  {
    Type p_DestinationType = this.ValueType;
    if ((!(p_DestinationType == (Type) null) ? 0 : (p_Object != null ? 1 : 0)) != 0)
      p_DestinationType = p_Object.GetType();
    ConvertingObjectEventArgs e = new ConvertingObjectEventArgs(p_Object, p_DestinationType);
    this.OnConvertingObjectToValue(e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException(this.ValueTypeName, this.ObjectToStringForError(e.Value));
    return this.IsValidValue(e.Value) ? e.Value : throw new ConversionErrorException(this.ValueTypeName, this.ObjectToStringForError(e.Value));
  }

  public object ValueToObject(object p_Value, Type p_ReturnObjectType)
  {
    ConvertingObjectEventArgs e = !(p_ReturnObjectType == (Type) null) ? new ConvertingObjectEventArgs(p_Value, p_ReturnObjectType) : throw new DevAgeApplicationException("Invalid parameter returnObjectType cannot be null");
    this.OnConvertingValueToObject(e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException(p_ReturnObjectType.Name, this.ObjectToStringForError(e.Value));
    if (e.Value == null)
      return (object) null;
    if (e.DestinationType.IsAssignableFrom(e.Value.GetType()))
      return e.Value;
    throw new ConversionErrorException(p_ReturnObjectType.Name, this.ObjectToStringForError(e.Value));
  }

  public string ValueToString(object p_Value)
  {
    object obj = this.ValueToObject(p_Value, typeof (string));
    return obj != null ? (string) obj : (string) null;
  }

  public object StringToValue(string p_str) => this.ObjectToValue((object) p_str);

  [System.ComponentModel.DefaultValue(true)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool AllowStringConversion
  {
    get => this.bool_1;
    set
    {
      if (this.bool_1 == value)
        return;
      this.bool_1 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  public virtual bool IsStringConversionSupported()
  {
    return this.AllowStringConversion && typeof (string) == this.ValueType || this.ValueType == (Type) null;
  }

  public virtual string ValueToDisplayString(object p_Value)
  {
    ConvertingObjectEventArgs e = new ConvertingObjectEventArgs(p_Value, typeof (string));
    this.OnConvertingValueToDisplayString(e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException("display String", this.ObjectToStringForError(e.Value));
    if (e.Value == null)
      return this.NullDisplayString;
    return e.Value is string ? (string) e.Value : throw new ConversionErrorException("display String", this.ObjectToStringForError(e.Value));
  }

  public event ConvertingObjectEventHandler ConvertingObjectToValue
  {
    add => this.convertingObjectEventHandler_0 += value;
    remove => this.convertingObjectEventHandler_0 -= value;
  }

  public event ConvertingObjectEventHandler ConvertingValueToObject
  {
    add => this.convertingObjectEventHandler_1 += value;
    remove => this.convertingObjectEventHandler_1 -= value;
  }

  public event ConvertingObjectEventHandler ConvertingValueToDisplayString
  {
    add => this.convertingObjectEventHandler_2 += value;
    remove => this.convertingObjectEventHandler_2 -= value;
  }

  protected virtual void OnConvertingObjectToValue(ConvertingObjectEventArgs e)
  {
    if (this.convertingObjectEventHandler_0 != null)
      this.convertingObjectEventHandler_0((object) this, e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException(e.DestinationType.Name, this.ObjectToStringForError(e.Value));
    if (e.ConvertingStatus == ConvertingStatus.Completed || !(e.Value is string) || !this.IsNullString((string) e.Value))
      return;
    e.Value = (object) null;
  }

  protected virtual void OnConvertingValueToObject(ConvertingObjectEventArgs e)
  {
    if (this.convertingObjectEventHandler_1 != null)
      this.convertingObjectEventHandler_1((object) this, e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException(e.DestinationType.Name, this.ObjectToStringForError(e.Value));
    if (e.ConvertingStatus == ConvertingStatus.Completed)
      ;
  }

  protected virtual void OnConvertingValueToDisplayString(ConvertingObjectEventArgs e)
  {
    if (this.convertingObjectEventHandler_2 != null)
      this.convertingObjectEventHandler_2((object) this, e);
    if (e.ConvertingStatus == ConvertingStatus.Error)
      throw new ConversionErrorException("display String", this.ObjectToStringForError(e.Value));
    if (e.ConvertingStatus == ConvertingStatus.Completed)
      return;
    if (e.Value == null)
      e.Value = (object) this.NullDisplayString;
    else if (this.IsStringConversionSupported())
      e.Value = (object) this.ValueToString(e.Value);
    else
      e.Value = (object) e.Value.ToString();
  }

  public bool IsValidValue(object p_Value)
  {
    try
    {
      if (this.IsInStandardValues(p_Value))
        return true;
      if (p_Value == null)
        return this.AllowNull;
      if (this.bool_2 || this.object_1 != null && ((IComparable) this.object_1).CompareTo(p_Value) < 0 || this.object_0 != null && ((IComparable) this.object_0).CompareTo(p_Value) > 0)
        return false;
      return !(this.ValueType != (Type) null) || this.ValueType.IsAssignableFrom(p_Value.GetType());
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool IsValidObject(object p_Object) => this.IsValidObject(p_Object, out object _);

  public bool IsValidObject(object p_Object, out object p_ValueConverted)
  {
    p_ValueConverted = (object) null;
    try
    {
      p_ValueConverted = this.ObjectToValue(p_Object);
      return this.IsValidValue(p_ValueConverted);
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public bool IsValidString(string p_strValue) => this.IsValidString(p_strValue, out object _);

  public bool IsValidString(string p_strValue, out object p_ValueConverted)
  {
    return this.IsValidObject((object) p_strValue, out p_ValueConverted);
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object MinimumValue
  {
    get => this.object_0;
    set
    {
      if (this.object_0 == value)
        return;
      this.object_0 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object MaximumValue
  {
    get => this.object_1;
    set
    {
      if (this.object_1 == value)
        return;
      this.object_1 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Type ValueType
  {
    get => this.type_0;
    set
    {
      if (!(this.type_0 != value))
        return;
      this.type_0 = value;
      this.OnLoadingValueType();
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue("")]
  [Browsable(true)]
  public string ValueTypeName
  {
    get => !(this.ValueType == (Type) null) ? this.ValueType.AssemblyQualifiedName : string.Empty;
    set
    {
      if ((value == null ? 1 : (value.Trim().Length == 0 ? 1 : 0)) != 0)
        this.ValueType = (Type) null;
      else
        this.ValueType = Type.GetType(value, true, true);
    }
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object DefaultValue
  {
    get => this.object_2;
    set
    {
      if (this.object_2 == value)
        return;
      this.object_2 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ICollection StandardValues
  {
    get => this.icollection_0;
    set
    {
      if (this.icollection_0 == value)
        return;
      this.icollection_0 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  [System.ComponentModel.DefaultValue(false)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool StandardValuesExclusive
  {
    get => this.bool_2;
    set
    {
      if (this.bool_2 == value)
        return;
      this.bool_2 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  public virtual bool IsInStandardValues(object p_Value)
  {
    bool flag;
    if (this.icollection_0 == null)
    {
      flag = false;
    }
    else
    {
      foreach (object obj in (IEnumerable) this.icollection_0)
      {
        if ((obj != null || p_Value != null ? (obj == null ? 0 : (obj.Equals(p_Value) ? 1 : 0)) : 1) != 0)
        {
          flag = true;
          goto label_11;
        }
      }
      flag = false;
    }
label_11:
    return flag;
  }

  public virtual object StandardValueAtIndex(int p_Index)
  {
    if (this.icollection_0 == null)
      throw new DevAgeApplicationException("StandardValues is null");
    if (this.icollection_0 is IList icollection0)
      return icollection0[p_Index];
    int num = 0;
    foreach (object obj in (IEnumerable) this.icollection_0)
    {
      if (num == p_Index)
        return obj;
      ++num;
    }
    throw new DevAgeApplicationException("Invalid Index");
  }

  public virtual int StandardValuesIndexOf(object p_StandardValue)
  {
    if (this.icollection_0 == null)
      throw new DevAgeApplicationException("StandardValues is null");
    int num1;
    if (this.icollection_0 is IList icollection0)
    {
      num1 = icollection0.IndexOf(p_StandardValue);
    }
    else
    {
      int num2 = 0;
      foreach (object obj in (IEnumerable) this.icollection_0)
      {
        if ((obj != null ? 0 : (p_StandardValue == null ? 1 : 0)) == 0)
        {
          if (obj == null || !obj.Equals(p_StandardValue))
          {
            ++num2;
          }
          else
          {
            num1 = num2;
            goto label_16;
          }
        }
        else
        {
          num1 = num2;
          goto label_16;
        }
      }
      num1 = -1;
    }
label_16:
    return num1;
  }

  [System.ComponentModel.DefaultValue(null)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public CultureInfo CultureInfo
  {
    get => this.cultureInfo_0;
    set
    {
      if (this.cultureInfo_0 == value)
        return;
      this.cultureInfo_0 = value;
      this.OnChanged(EventArgs.Empty);
    }
  }

  protected override void Dispose(bool disposing) => base.Dispose(disposing);

  protected virtual void OnChanged(EventArgs e)
  {
    if (this.eventHandler_0 == null)
      return;
    this.eventHandler_0((object) this, e);
  }

  public event EventHandler Changed
  {
    add => this.eventHandler_0 += value;
    remove => this.eventHandler_0 -= value;
  }
}
