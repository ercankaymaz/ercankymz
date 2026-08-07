// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1EncodableVector
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class Asn1EncodableVector : IEnumerable<Asn1Encodable>, IEnumerable
{
  internal static readonly Asn1Encodable[] EmptyElements = new Asn1Encodable[0];
  private const int DefaultCapacity = 10;
  private Asn1Encodable[] elements;
  private int elementCount;
  private bool copyOnWrite;

  public static Asn1EncodableVector FromEnumerable(IEnumerable<Asn1Encodable> e)
  {
    Asn1EncodableVector asn1EncodableVector = new Asn1EncodableVector();
    foreach (Asn1Encodable element in e)
      asn1EncodableVector.Add(element);
    return asn1EncodableVector;
  }

  public Asn1EncodableVector()
    : this(10)
  {
  }

  public Asn1EncodableVector(int initialCapacity)
  {
    if (initialCapacity < 0)
      throw new ArgumentException("must not be negative", nameof (initialCapacity));
    this.elements = initialCapacity == 0 ? Asn1EncodableVector.EmptyElements : new Asn1Encodable[initialCapacity];
    this.elementCount = 0;
    this.copyOnWrite = false;
  }

  public Asn1EncodableVector(Asn1Encodable element)
    : this()
  {
    this.Add(element);
  }

  public Asn1EncodableVector(Asn1Encodable element1, Asn1Encodable element2)
    : this()
  {
    this.Add(element1);
    this.Add(element2);
  }

  public Asn1EncodableVector(params Asn1Encodable[] v)
    : this()
  {
    this.Add(v);
  }

  public void Add(Asn1Encodable element)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    int length = this.elements.Length;
    int minCapacity = this.elementCount + 1;
    if (minCapacity > length | this.copyOnWrite)
      this.Reallocate(minCapacity);
    this.elements[this.elementCount] = element;
    this.elementCount = minCapacity;
  }

  public void Add(Asn1Encodable element1, Asn1Encodable element2)
  {
    this.Add(element1);
    this.Add(element2);
  }

  public void Add(params Asn1Encodable[] objs)
  {
    foreach (Asn1Encodable element in objs)
      this.Add(element);
  }

  public void AddOptional(Asn1Encodable element)
  {
    if (element == null)
      return;
    this.Add(element);
  }

  public void AddOptional(Asn1Encodable element1, Asn1Encodable element2)
  {
    if (element1 != null)
      this.Add(element1);
    if (element2 == null)
      return;
    this.Add(element2);
  }

  public void AddOptional(params Asn1Encodable[] elements)
  {
    if (elements == null)
      return;
    foreach (Asn1Encodable element in elements)
    {
      if (element != null)
        this.Add(element);
    }
  }

  public void AddOptionalTagged(bool isExplicit, int tagNo, Asn1Encodable obj)
  {
    if (obj == null)
      return;
    this.Add((Asn1Encodable) new DerTaggedObject(isExplicit, tagNo, obj));
  }

  public void AddOptionalTagged(bool isExplicit, int tagClass, int tagNo, Asn1Encodable obj)
  {
    if (obj == null)
      return;
    this.Add((Asn1Encodable) new DerTaggedObject(isExplicit, tagClass, tagNo, obj));
  }

  public void AddAll(Asn1EncodableVector other)
  {
    int num = other != null ? other.Count : throw new ArgumentNullException(nameof (other));
    if (num < 1)
      return;
    int length = this.elements.Length;
    int minCapacity = this.elementCount + num;
    if (minCapacity > length | this.copyOnWrite)
      this.Reallocate(minCapacity);
    int index = 0;
    do
    {
      Asn1Encodable asn1Encodable = other[index];
      if (asn1Encodable != null)
        this.elements[this.elementCount + index] = asn1Encodable;
      else
        goto label_8;
    }
    while (++index < num);
    goto label_9;
label_8:
    throw new NullReferenceException("'other' elements cannot be null");
label_9:
    this.elementCount = minCapacity;
  }

  public Asn1Encodable this[int index]
  {
    get
    {
      return index < this.elementCount ? this.elements[index] : throw new IndexOutOfRangeException($"{index.ToString()} >= {this.elementCount.ToString()}");
    }
  }

  public int Count => this.elementCount;

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public IEnumerator<Asn1Encodable> GetEnumerator()
  {
    return ((IEnumerable<Asn1Encodable>) this.CopyElements()).GetEnumerator();
  }

  internal Asn1Encodable[] CopyElements()
  {
    if (this.elementCount == 0)
      return Asn1EncodableVector.EmptyElements;
    Asn1Encodable[] destinationArray = new Asn1Encodable[this.elementCount];
    Array.Copy((Array) this.elements, 0, (Array) destinationArray, 0, this.elementCount);
    return destinationArray;
  }

  internal Asn1Encodable[] TakeElements()
  {
    if (this.elementCount == 0)
      return Asn1EncodableVector.EmptyElements;
    if (this.elements.Length == this.elementCount)
    {
      this.copyOnWrite = true;
      return this.elements;
    }
    Asn1Encodable[] destinationArray = new Asn1Encodable[this.elementCount];
    Array.Copy((Array) this.elements, 0, (Array) destinationArray, 0, this.elementCount);
    return destinationArray;
  }

  private void Reallocate(int minCapacity)
  {
    Asn1Encodable[] destinationArray = new Asn1Encodable[Math.Max(this.elements.Length, minCapacity + (minCapacity >> 1))];
    Array.Copy((Array) this.elements, 0, (Array) destinationArray, 0, this.elementCount);
    this.elements = destinationArray;
    this.copyOnWrite = false;
  }

  internal static Asn1Encodable[] CloneElements(Asn1Encodable[] elements)
  {
    return elements.Length >= 1 ? (Asn1Encodable[]) elements.Clone() : Asn1EncodableVector.EmptyElements;
  }
}
