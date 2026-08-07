// Decompiled with JetBrains decompiler
// Type: DevAge.Windows.Forms.SubButtonItemCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System.Collections;

#nullable disable
namespace DevAge.Windows.Forms;

public class SubButtonItemCollection : CollectionBase
{
  public SubButtonItemCollection()
  {
  }

  public SubButtonItemCollection(SubButtonItem[] items) => this.AddRange(items);

  public SubButtonItemCollection(SubButtonItemCollection items) => this.AddRange(items);

  public virtual void AddRange(SubButtonItem[] items)
  {
    foreach (object obj in items)
      this.List.Add(obj);
  }

  public virtual void AddRange(SubButtonItemCollection items)
  {
    foreach (object obj in items)
      this.List.Add(obj);
  }

  public virtual void Add(SubButtonItem value) => this.List.Add((object) value);

  public virtual bool Contains(SubButtonItem value) => this.List.Contains((object) value);

  public virtual int IndexOf(SubButtonItem value) => this.List.IndexOf((object) value);

  public virtual void Insert(int index, SubButtonItem value)
  {
    this.List.Insert(index, (object) value);
  }

  public virtual SubButtonItem this[int index]
  {
    get => (SubButtonItem) this.List[index];
    set => this.List[index] = (object) value;
  }

  public virtual void Remove(SubButtonItem value) => this.List.Remove((object) value);

  public virtual SubButtonItemCollection.Enumerator GetEnumerator()
  {
    return new SubButtonItemCollection.Enumerator(this);
  }

  public class Enumerator : IEnumerator
  {
    private IEnumerator ienumerator_0;

    public Enumerator(SubButtonItemCollection collection)
    {
      this.ienumerator_0 = ((CollectionBase) collection).GetEnumerator();
    }

    public SubButtonItem Current => (SubButtonItem) this.ienumerator_0.Current;

    object IEnumerator.Current => (object) (SubButtonItem) this.ienumerator_0.Current;

    public bool MoveNext() => this.ienumerator_0.MoveNext();

    public void Reset() => this.ienumerator_0.Reset();
  }
}
