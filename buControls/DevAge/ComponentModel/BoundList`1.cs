// Decompiled with JetBrains decompiler
// Type: DevAge.ComponentModel.BoundList`1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable
namespace DevAge.ComponentModel;

[Serializable]
public class BoundList<T> : BoundListBase<T>
{
  private IList<T> mList;

  public BoundList(IList<T> list)
  {
    this.mList = list;
    this.AllowNew = true;
    this.AllowDelete = true;
    this.AllowEdit = true;
    this.AllowSort = this.mList is List<T>;
  }

  protected override T OnAddNew()
  {
    T instance = Activator.CreateInstance<T>();
    this.mList.Add(instance);
    return instance;
  }

  public override int IndexOf(object item) => this.mList.IndexOf((T) item);

  protected override void OnRemoveAt(int index) => this.mList.RemoveAt(index);

  protected override void OnClear() => this.mList.Clear();

  public override object this[int index] => (object) this.mList[index];

  public override int Count => this.mList.Count;

  public override void ApplySort(ListSortDescriptionCollection sorts)
  {
    // ISSUE: object of a compiler-generated type is created
    // ISSUE: variable of a compiler-generated type
    BoundList<T>.Class40 class40 = new BoundList<T>.Class40();
    // ISSUE: reference to a compiler-generated field
    class40.listSortDescriptionCollection_0 = sorts;
    if (!(this.mList is List<T> mList))
      throw new DevAgeApplicationException("Sort not supported, the list must be an instance of List<T>.");
    // ISSUE: reference to a compiler-generated method
    mList.Sort(new Comparison<T>(class40.method_0));
    this.OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
  }
}
