// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.Validator.ValueMapping
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;

#nullable disable
namespace DevAge.ComponentModel.Validator;

public class ValueMapping
{
  private IList ilist_0;
  private Type type_0 = typeof (string);
  private IList ilist_1;
  private IList ilist_2;
  private bool bool_0 = true;

  public ValueMapping()
  {
  }

  public ValueMapping(
    IValidator validator,
    IList valueList,
    IList displayStringList,
    IList specialList,
    Type specialType)
  {
    this.ValueList = valueList;
    this.DisplayStringList = displayStringList;
    this.SpecialList = specialList;
    if (validator == null)
      return;
    this.BindValidator(validator);
  }

  public void BindValidator(IValidator p_Validator)
  {
    p_Validator.ConvertingValueToDisplayString += new ConvertingObjectEventHandler(this.method_0);
    p_Validator.ConvertingObjectToValue += new ConvertingObjectEventHandler(this.method_1);
    p_Validator.ConvertingValueToObject += new ConvertingObjectEventHandler(this.method_2);
  }

  public void UnBindValidator(IValidator p_Validator)
  {
    p_Validator.ConvertingValueToDisplayString -= new ConvertingObjectEventHandler(this.method_0);
    p_Validator.ConvertingObjectToValue -= new ConvertingObjectEventHandler(this.method_1);
    p_Validator.ConvertingValueToObject -= new ConvertingObjectEventHandler(this.method_2);
  }

  public IList ValueList
  {
    get => this.ilist_0;
    set => this.ilist_0 = value;
  }

  public IList SpecialList
  {
    get => this.ilist_1;
    set => this.ilist_1 = value;
  }

  public Type SpecialType
  {
    get => this.type_0;
    set => this.type_0 = value;
  }

  public IList DisplayStringList
  {
    get => this.ilist_2;
    set => this.ilist_2 = value;
  }

  public bool ThrowErrorIfNotFound
  {
    get => this.bool_0;
    set => this.bool_0 = value;
  }

  private void method_0(object sender, ConvertingObjectEventArgs e)
  {
    if (this.ilist_2 == null)
      return;
    if (this.ilist_0 == null)
      throw new ApplicationException("ValueList cannot be null");
    int index = this.ilist_0.IndexOf(e.Value);
    if (index >= 0)
    {
      e.Value = this.ilist_2[index];
      e.ConvertingStatus = ConvertingStatus.Completed;
    }
    else
    {
      if (!this.bool_0)
        return;
      e.ConvertingStatus = ConvertingStatus.Error;
    }
  }

  private void method_1(object sender, ConvertingObjectEventArgs e)
  {
    if ((this.ilist_1 == null || e.Value == null ? 0 : (e.Value.GetType() == this.SpecialType ? 1 : 0)) == 0)
      return;
    if (this.ilist_0 == null)
      throw new ApplicationException("ValueList cannot be null");
    int index1 = this.ilist_0.IndexOf(e.Value);
    if (index1 >= 0)
    {
      e.Value = this.ilist_0[index1];
      e.ConvertingStatus = ConvertingStatus.Completed;
    }
    else
    {
      int index2 = this.ilist_1.IndexOf(e.Value);
      if (index2 >= 0)
      {
        e.Value = this.ilist_0[index2];
        e.ConvertingStatus = ConvertingStatus.Completed;
      }
      else
      {
        if (!this.bool_0)
          return;
        e.ConvertingStatus = ConvertingStatus.Error;
      }
    }
  }

  private void method_2(object sender, ConvertingObjectEventArgs e)
  {
    if ((this.ilist_1 == null ? 0 : (e.DestinationType == this.SpecialType ? 1 : 0)) == 0)
      return;
    if (this.ilist_0 == null)
      throw new ApplicationException("ValueList cannot be null");
    int index = this.ilist_0.IndexOf(e.Value);
    if (index >= 0)
    {
      e.Value = this.ilist_1[index];
      e.ConvertingStatus = ConvertingStatus.Completed;
    }
    else
    {
      if (!this.bool_0)
        return;
      e.ConvertingStatus = ConvertingStatus.Error;
    }
  }
}
