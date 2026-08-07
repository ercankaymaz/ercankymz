// Decompiled with JetBrains decompiler
// Type: Poly2Tri.Utility.FixedArray3`1
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Poly2Tri.Utility;

public struct FixedArray3<T> : IEnumerable<T>, IEnumerable where T : IEquatable<T>
{
  public T Item0;
  public T Item1;
  public T Item2;

  public T this[int index]
  {
    get
    {
      T obj;
      switch (index)
      {
        case 0:
          obj = this.Item0;
          break;
        case 1:
          obj = this.Item1;
          break;
        case 2:
          obj = this.Item2;
          break;
        default:
          throw new IndexOutOfRangeException();
      }
      return obj;
    }
    set
    {
      switch (index)
      {
        case 0:
          this.Item0 = value;
          break;
        case 1:
          this.Item1 = value;
          break;
        case 2:
          this.Item2 = value;
          break;
        default:
          throw new IndexOutOfRangeException();
      }
    }
  }

  public bool Contains(T value) => this.IndexOf(value) != -1;

  public int IndexOf(T value)
  {
    int num;
    for (int index = 0; index < 3; ++index)
    {
      if ((this[index].Equals(default (T)) ? 0 : (this[index].Equals(value) ? 1 : 0)) != 0)
      {
        num = index;
        goto label_6;
      }
    }
    num = -1;
label_6:
    return num;
  }

  public void Clear() => this.Item0 = this.Item1 = this.Item2 = default (T);

  public void Clear(T value)
  {
    for (int index = 0; index < 3; ++index)
    {
      if ((!this[index].Equals(default (T)) ? 0 : (this[index].Equals(value) ? 1 : 0)) != 0)
        this[index] = default (T);
    }
  }

  private IEnumerable<T> method_0()
  {
    for (int index = 0; index < 3; ++index)
      yield return this[index];
  }

  public IEnumerator<T> GetEnumerator() => this.method_0().GetEnumerator();

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
}
