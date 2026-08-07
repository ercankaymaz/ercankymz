// Decompiled with JetBrains decompiler
// Type: SourceGrid.LinkedControlsList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

public class LinkedControlsList : IEnumerable, IEnumerable<LinkedControlValue>
{
  internal Control parent;
  private List<LinkedControlValue> list_0 = new List<LinkedControlValue>();

  public LinkedControlsList(Control parent) => this.parent = parent;

  public void Clear()
  {
    foreach (LinkedControlValue linkedControlValue_0 in this.list_0)
      Class39.smethod_816(linkedControlValue_0, this);
    this.list_0.Clear();
  }

  public void Add(LinkedControlValue linkedControl)
  {
    this.list_0.Add(linkedControl);
    this.parent.Controls.Add(linkedControl.Control);
  }

  public void Remove(LinkedControlValue linkedControl)
  {
    this.list_0.Remove(linkedControl);
    Class39.smethod_816(linkedControl, this);
  }

  public LinkedControlValue GetByControl(Control control)
  {
    LinkedControlValue byControl;
    for (int index = 0; index < this.list_0.Count; ++index)
    {
      if (control == this.list_0[index].Control)
      {
        byControl = this.list_0[index];
        goto label_6;
      }
    }
    byControl = (LinkedControlValue) null;
label_6:
    return byControl;
  }

  public IEnumerator<LinkedControlValue> GetEnumerator()
  {
    return (IEnumerator<LinkedControlValue>) this.list_0.GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.list_0.GetEnumerator();
}
