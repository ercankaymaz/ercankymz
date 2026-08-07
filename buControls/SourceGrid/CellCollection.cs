// Decompiled with JetBrains decompiler
// Type: SourceGrid.CellCollection
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using SourceGrid.Cells;
using System.Collections;

#nullable disable
namespace SourceGrid;

public class CellCollection : CollectionBase
{
  public CellCollection()
  {
  }

  public CellCollection(ICellVirtual[] items) => this.AddRange(items);

  public CellCollection(CellCollection items) => this.AddRange(items);

  public virtual void AddRange(ICellVirtual[] items)
  {
    foreach (object obj in items)
      this.List.Add(obj);
  }

  public virtual void AddRange(CellCollection items)
  {
    foreach (object obj in items)
      this.List.Add(obj);
  }

  public virtual void Add(ICellVirtual value) => this.List.Add((object) value);

  public virtual bool Contains(ICellVirtual value) => this.List.Contains((object) value);

  public virtual int IndexOf(ICellVirtual value) => this.List.IndexOf((object) value);

  public virtual void Insert(int index, ICellVirtual value)
  {
    this.List.Insert(index, (object) value);
  }

  public virtual ICellVirtual this[int index]
  {
    get => (ICellVirtual) this.List[index];
    set => this.List[index] = (object) value;
  }

  public virtual void Remove(ICellVirtual value) => this.List.Remove((object) value);

  public virtual CellCollection.Enumerator GetEnumerator() => new CellCollection.Enumerator(this);

  public class Enumerator : IEnumerator
  {
    private IEnumerator ienumerator_0;

    public Enumerator(CellCollection collection)
    {
      this.ienumerator_0 = ((CollectionBase) collection).GetEnumerator();
    }

    public ICellVirtual Current => (ICellVirtual) this.ienumerator_0.Current;

    object IEnumerator.Current => (object) (ICellVirtual) this.ienumerator_0.Current;

    public bool MoveNext() => this.ienumerator_0.MoveNext();

    public void Reset() => this.ienumerator_0.Reset();
  }
}
