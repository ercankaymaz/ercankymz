// Decompiled with JetBrains decompiler
// Type: DevAge.Configuration.PersistableItemDictionary
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;

#nullable disable
namespace DevAge.Configuration;

public class PersistableItemDictionary : DictionaryBase
{
  public virtual PersistableItem this[string key]
  {
    get => (PersistableItem) this.Dictionary[(object) key];
    set => this.Dictionary[(object) key] = (object) value;
  }

  public virtual void Add(string key, PersistableItem value)
  {
    this.Dictionary.Add((object) key, (object) value);
  }

  public virtual bool Contains(string key) => this.Dictionary.Contains((object) key);

  public virtual bool ContainsKey(string key) => this.Dictionary.Contains((object) key);

  public virtual bool ContainsValue(PersistableItem value)
  {
    bool flag;
    foreach (PersistableItem persistableItem in (IEnumerable) this.Dictionary.Values)
    {
      if (persistableItem == value)
      {
        flag = true;
        goto label_9;
      }
    }
    flag = false;
label_9:
    return flag;
  }

  public virtual void Remove(string key) => this.Dictionary.Remove((object) key);

  public virtual ICollection Keys => this.Dictionary.Keys;

  public virtual ICollection Values => this.Dictionary.Values;
}
