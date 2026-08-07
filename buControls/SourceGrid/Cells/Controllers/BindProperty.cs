// Decompiled with JetBrains decompiler
// Type: SourceGrid.Cells.Controllers.BindProperty
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Reflection;

#nullable disable
namespace SourceGrid.Cells.Controllers;

public class BindProperty : ControllerBase
{
  private PropertyInfo propertyInfo_0 = (PropertyInfo) null;
  private object object_0 = (object) null;

  public BindProperty(PropertyInfo p_Property, object p_LinkObject)
  {
    this.BindValueAtProperty(p_Property, p_LinkObject);
  }

  public override void OnValueChanged(CellContext sender, EventArgs e)
  {
    base.OnValueChanged(sender, e);
    if (!(this.propertyInfo_0 != (PropertyInfo) null))
      return;
    this.propertyInfo_0.SetValue(this.object_0, sender.Cell.Model.ValueModel.GetValue(sender), (object[]) null);
  }

  protected virtual void BindValueAtProperty(PropertyInfo p_Property, object p_LinkObject)
  {
    this.propertyInfo_0 = p_Property;
    this.object_0 = p_LinkObject;
  }

  protected virtual void UnBindValueAtProperty()
  {
    this.propertyInfo_0 = (PropertyInfo) null;
    this.object_0 = (object) null;
  }
}
