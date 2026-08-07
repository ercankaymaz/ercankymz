// Decompiled with JetBrains decompiler
// Type: DevAge.Text.FixedLength.FieldList
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;

#nullable disable
namespace DevAge.Text.FixedLength;

public class FieldList : DictionaryBase
{
  public virtual IField this[string key]
  {
    get => (IField) this.Dictionary[(object) key];
    set => this.Dictionary[(object) key] = (object) value;
  }

  public virtual void Add(IField value) => this.Dictionary.Add((object) value.Name, (object) value);

  public virtual bool Contains(string fieldName) => this.Dictionary.Contains((object) fieldName);

  public virtual bool ContainsKey(string fieldName) => this.Dictionary.Contains((object) fieldName);

  public virtual bool ContainsValue(IField value)
  {
    bool flag;
    foreach (IField field in (IEnumerable) this.Dictionary.Values)
    {
      if (field == value)
      {
        flag = true;
        goto label_9;
      }
    }
    flag = false;
label_9:
    return flag;
  }

  public virtual void Remove(string fieldName) => this.Dictionary.Remove((object) fieldName);

  public virtual ICollection Keys => this.Dictionary.Keys;

  public virtual ICollection Values => this.Dictionary.Values;

  public IField[] GetSortedList()
  {
    IField[] sortedList = new IField[this.Count];
    for (int fieldIndex = 0; fieldIndex < sortedList.Length; ++fieldIndex)
    {
      foreach (IField field in (IEnumerable) this.Values)
      {
        if (field.Index == fieldIndex)
        {
          sortedList[fieldIndex] = field;
          break;
        }
      }
      if (sortedList[fieldIndex] == null)
        throw new FieldNotDefinedException(fieldIndex);
    }
    return sortedList;
  }
}
