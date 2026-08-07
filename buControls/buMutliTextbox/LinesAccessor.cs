// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.LinesAccessor
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace buMutliTextbox;

public class LinesAccessor : IEnumerable, IList<string>, ICollection<string>, IEnumerable<string>
{
  private IList<Line> ts;

  public LinesAccessor(IList<Line> ts) => this.ts = ts;

  public int IndexOf(string item)
  {
    int num;
    for (int index = 0; index < this.ts.Count; ++index)
    {
      if (this.ts[index].Text == item)
      {
        num = index;
        goto label_6;
      }
    }
    num = -1;
label_6:
    return num;
  }

  public void Insert(int index, string item) => throw new NotImplementedException();

  public void RemoveAt(int index) => throw new NotImplementedException();

  public string this[int index]
  {
    get => this.ts[index].Text;
    set => throw new NotImplementedException();
  }

  public void Add(string item) => throw new NotImplementedException();

  public void Clear() => throw new NotImplementedException();

  public bool Contains(string item)
  {
    bool flag;
    for (int index = 0; index < this.ts.Count; ++index)
    {
      if (this.ts[index].Text == item)
      {
        flag = true;
        goto label_6;
      }
    }
    flag = false;
label_6:
    return flag;
  }

  public void CopyTo(string[] array, int arrayIndex)
  {
    for (int index = 0; index < this.ts.Count; ++index)
      array[index + arrayIndex] = this.ts[index].Text;
  }

  public int Count => this.ts.Count;

  public bool IsReadOnly => true;

  public bool Remove(string item) => throw new NotImplementedException();

  public IEnumerator<string> GetEnumerator()
  {
    for (int index = 0; index < this.ts.Count; ++index)
      yield return this.ts[index].Text;
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
