// Decompiled with JetBrains decompiler
// Type: DevAge.Configuration.PersistableItem
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using DevAge.ComponentModel.Validator;
using System;
using System.Globalization;

#nullable disable
namespace DevAge.Configuration;

public class PersistableItem
{
  private IValidator ivalidator_0;
  private Type pType;
  private string pName;
  private object pDefaultValue;
  private object pDefaultValue;

  public PersistableItem(Type pType, string pName, object pDefaultValue)
  {
    this.ivalidator_0 = (IValidator) new ValidatorTypeConverter(pType);
    this.ivalidator_0.CultureInfo = CultureInfo.InvariantCulture;
    this.pType = pType;
    this.pName = pName;
    this.pDefaultValue = pDefaultValue;
    this.pDefaultValue = pDefaultValue;
  }

  public IValidator Validator => this.ivalidator_0;

  public Type Type => this.pType;

  public string Name => this.pName;

  public object Value
  {
    get => this.pDefaultValue;
    set => this.pDefaultValue = value;
  }

  public object DefaultValue
  {
    get => this.pDefaultValue;
    set => this.pDefaultValue = value;
  }

  public bool IsChanged
  {
    get
    {
      return (this.pDefaultValue != null ? 0 : (this.pDefaultValue == null ? 1 : 0)) == 0 && (this.pDefaultValue == null || !this.pDefaultValue.Equals(this.pDefaultValue));
    }
  }

  public void AcceptAsDefault() => this.pDefaultValue = this.pDefaultValue;

  public void Reset() => this.pDefaultValue = this.pDefaultValue;

  public override string ToString()
  {
    return $"PersistableItem: {this.Name}={this.Validator.ValueToDisplayString(this.Value)}";
  }
}
