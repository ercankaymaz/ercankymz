// Decompiled with JetBrains decompiler
// Type: System.Diagnostics.DiagLinkedList`1
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace System.Diagnostics;

internal sealed class DiagLinkedList<T> : IEnumerable<T>, IEnumerable
{
  private DiagNode<T> _first;
  private DiagNode<T> _last;

  public DiagLinkedList()
  {
  }

  public DiagLinkedList(T firstValue) => this._last = this._first = new DiagNode<T>(firstValue);

  public DiagLinkedList(IEnumerator<T> e)
  {
    this._last = this._first = new DiagNode<T>(e.Current);
    while (e.MoveNext())
    {
      this._last.Next = new DiagNode<T>(e.Current);
      this._last = this._last.Next;
    }
  }

  public DiagNode<T> First => this._first;

  public void Clear()
  {
    lock (this)
      this._first = this._last = (DiagNode<T>) null;
  }

  private void UnsafeAdd(DiagNode<T> newNode)
  {
    if (this._first == null)
    {
      this._first = this._last = newNode;
    }
    else
    {
      this._last.Next = newNode;
      this._last = newNode;
    }
  }

  public void Add(T value)
  {
    DiagNode<T> newNode = new DiagNode<T>(value);
    lock (this)
      this.UnsafeAdd(newNode);
  }

  public bool AddIfNotExist(T value, Func<T, T, bool> compare)
  {
    lock (this)
    {
      for (DiagNode<T> diagNode = this._first; diagNode != null; diagNode = diagNode.Next)
      {
        if (compare(value, diagNode.Value))
          return false;
      }
      this.UnsafeAdd(new DiagNode<T>(value));
      return true;
    }
  }

  public T Remove(T value, Func<T, T, bool> compare)
  {
    lock (this)
    {
      DiagNode<T> diagNode = this._first;
      if (diagNode == null)
        return default (T);
      if (compare(diagNode.Value, value))
      {
        this._first = diagNode.Next;
        if (this._first == null)
          this._last = (DiagNode<T>) null;
        return diagNode.Value;
      }
      for (DiagNode<T> next = diagNode.Next; next != null; next = next.Next)
      {
        if (!compare(next.Value, value))
        {
          diagNode = next;
        }
        else
        {
          diagNode.Next = next.Next;
          if (this._last == next)
            this._last = diagNode;
          return next.Value;
        }
      }
      return default (T);
    }
  }

  public void AddFront(T value)
  {
    DiagNode<T> diagNode = new DiagNode<T>(value);
    lock (this)
    {
      diagNode.Next = this._first;
      this._first = diagNode;
    }
  }

  public Enumerator<T> GetEnumerator() => new Enumerator<T>(this._first);

  IEnumerator<T> IEnumerable<T>.GetEnumerator() => (IEnumerator<T>) this.GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
