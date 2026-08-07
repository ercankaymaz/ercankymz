// Decompiled with JetBrains decompiler
// Type: SourceGrid.ControlsRepository
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.Windows.Forms;

#nullable disable
namespace SourceGrid;

public class ControlsRepository : DictionaryBase
{
  private Control p_ParentControl;

  public ControlsRepository(Control p_ParentControl) => this.p_ParentControl = p_ParentControl;

  public virtual Control this[Guid key] => (Control) this.Dictionary[(object) key];

  public virtual void Add(Guid key, Control value)
  {
    this.Dictionary.Add((object) key, (object) value);
    this.p_ParentControl.Controls.Add(value);
  }

  public virtual bool Contains(Guid key) => this.Dictionary.Contains((object) key);

  public virtual bool ContainsKey(Guid key) => this.Dictionary.Contains((object) key);

  public virtual bool ContainsValue(Control value)
  {
    bool flag;
    foreach (Control control in (IEnumerable) this.Dictionary.Values)
    {
      if (control == value)
      {
        flag = true;
        goto label_9;
      }
    }
    flag = false;
label_9:
    return flag;
  }

  public virtual void Remove(Guid key)
  {
    if (!this.ContainsKey(key))
      return;
    this.p_ParentControl.Controls.Remove(this[key]);
    this.Dictionary.Remove((object) key);
  }

  public virtual ICollection Keys => this.Dictionary.Keys;

  public virtual ICollection Values => this.Dictionary.Values;
}
