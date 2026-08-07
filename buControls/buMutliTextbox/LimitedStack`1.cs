// Decompiled with JetBrains decompiler
// Type: buMutliTextbox.LimitedStack`1
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using System;
using System.Runtime.CompilerServices;

#nullable disable
namespace buMutliTextbox;

public class LimitedStack<T>
{
  private T[] gparam_0;
  private int int_0;
  private int int_1;

  public int MaxItemCount => this.gparam_0.Length;

  public int Count => this.int_0;

  public LimitedStack(int maxItemCount)
  {
    this.gparam_0 = new T[maxItemCount];
    this.int_0 = 0;
    this.int_1 = 0;
  }

  public T Pop()
  {
    if (this.int_0 == 0)
      throw new Exception("Stack is empty");
    int index = this.method_0();
    T obj = this.gparam_0[index];
    this.gparam_0[index] = default (T);
    --this.int_0;
    return obj;
  }

  [SpecialName]
  private int method_0() => (this.int_1 + this.int_0 - 1) % this.gparam_0.Length;

  public T Peek() => this.int_0 != 0 ? this.gparam_0[this.method_0()] : default (T);

  public void Push(T item)
  {
    if (this.int_0 == this.gparam_0.Length)
      this.int_1 = (this.int_1 + 1) % this.gparam_0.Length;
    else
      ++this.int_0;
    this.gparam_0[this.method_0()] = item;
  }

  public void Clear()
  {
    this.gparam_0 = new T[this.gparam_0.Length];
    this.int_0 = 0;
    this.int_1 = 0;
  }

  public T[] ToArray()
  {
    T[] array = new T[this.int_0];
    for (int index = 0; index < this.int_0; ++index)
      array[index] = this.gparam_0[(this.int_1 + index) % this.gparam_0.Length];
    return array;
  }
}
