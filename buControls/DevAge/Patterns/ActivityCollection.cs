// Decompiled with JetBrains decompiler
// Type: DevAge.Patterns.ActivityCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns7;
using System;
using System.Collections;

#nullable disable
namespace DevAge.Patterns;

public class ActivityCollection : IEnumerable, ICollection
{
  private ArrayList arrayList_0 = new ArrayList();
  private IActivity parentActivity;

  public ActivityCollection(IActivity parentActivity) => this.parentActivity = parentActivity;

  public int Count => this.arrayList_0.Count;

  public virtual bool Contains(IActivity value) => this.arrayList_0.Contains((object) value);

  public virtual int IndexOf(IActivity value) => this.arrayList_0.IndexOf((object) value);

  public virtual void Add(IActivity value) => this.Insert(this.Count, value);

  public virtual void Insert(int index, IActivity value)
  {
    Class39.smethod_697(this);
    this.arrayList_0.Insert(index, (object) value);
    value.Parent = this.parentActivity;
  }

  public virtual void Remove(IActivity value)
  {
    Class39.smethod_697(this);
    this.arrayList_0.Remove((object) value);
    value.Parent = (IActivity) null;
  }

  public virtual IActivity this[int index] => (IActivity) this.arrayList_0[index];

  public virtual ActivityCollection.Enumerator GetEnumerator()
  {
    return new ActivityCollection.Enumerator(this);
  }

  public bool IsSynchronized => this.arrayList_0.IsSynchronized;

  public void CopyTo(Array array, int index) => this.arrayList_0.CopyTo(array, index);

  public object SyncRoot => this.arrayList_0.SyncRoot;

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public class Enumerator : IEnumerator
  {
    private IEnumerator ienumerator_0;

    public Enumerator(ActivityCollection collection)
    {
      this.ienumerator_0 = collection.arrayList_0.GetEnumerator();
    }

    public IActivity Current => (IActivity) this.ienumerator_0.Current;

    object IEnumerator.Current => (object) (IActivity) this.ienumerator_0.Current;

    public bool MoveNext() => this.ienumerator_0.MoveNext();

    public void Reset() => this.ienumerator_0.Reset();
  }
}
