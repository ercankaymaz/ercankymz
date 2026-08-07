// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Set
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public abstract class Asn1Set : Asn1Object, IEnumerable<Asn1Encodable>, IEnumerable
{
  internal readonly Asn1Encodable[] m_elements;
  internal DerEncoding[] m_sortedDerEncodings;

  public static Asn1Set GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1Set) null;
      case Asn1Set instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1Set asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1Set) Asn1Set.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct set from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1Set GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1Set) Asn1Set.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  protected internal Asn1Set()
  {
    this.m_elements = Asn1EncodableVector.EmptyElements;
    this.m_sortedDerEncodings = (DerEncoding[]) null;
  }

  protected internal Asn1Set(Asn1Encodable element)
  {
    this.m_elements = element != null ? new Asn1Encodable[1]
    {
      element
    } : throw new ArgumentNullException(nameof (element));
    this.m_sortedDerEncodings = (DerEncoding[]) null;
  }

  protected internal Asn1Set(Asn1Encodable[] elements, bool doSort)
  {
    elements = !Arrays.IsNullOrContainsNull((object[]) elements) ? Asn1EncodableVector.CloneElements(elements) : throw new NullReferenceException("'elements' cannot be null, or contain null");
    DerEncoding[] derEncodingArray = (DerEncoding[]) null;
    if (doSort && elements.Length > 1)
      derEncodingArray = Asn1Set.SortElements(elements);
    this.m_elements = elements;
    this.m_sortedDerEncodings = derEncodingArray;
  }

  protected internal Asn1Set(Asn1EncodableVector elementVector, bool doSort)
  {
    if (elementVector == null)
      throw new ArgumentNullException(nameof (elementVector));
    Asn1Encodable[] elements;
    DerEncoding[] derEncodingArray;
    if (doSort && elementVector.Count > 1)
    {
      elements = elementVector.CopyElements();
      derEncodingArray = Asn1Set.SortElements(elements);
    }
    else
    {
      elements = elementVector.TakeElements();
      derEncodingArray = (DerEncoding[]) null;
    }
    this.m_elements = elements;
    this.m_sortedDerEncodings = derEncodingArray;
  }

  protected internal Asn1Set(bool isSorted, Asn1Encodable[] elements)
  {
    this.m_elements = elements;
    this.m_sortedDerEncodings = (DerEncoding[]) null;
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public virtual IEnumerator<Asn1Encodable> GetEnumerator()
  {
    return ((IEnumerable<Asn1Encodable>) this.m_elements).GetEnumerator();
  }

  public virtual Asn1Encodable this[int index] => this.m_elements[index];

  public virtual int Count => this.m_elements.Length;

  public virtual T[] MapElements<T>(Func<Asn1Encodable, T> func)
  {
    int count = this.Count;
    T[] objArray = new T[count];
    for (int index = 0; index < count; ++index)
      objArray[index] = func(this.m_elements[index]);
    return objArray;
  }

  public virtual Asn1Encodable[] ToArray() => Asn1EncodableVector.CloneElements(this.m_elements);

  public Asn1SetParser Parser => (Asn1SetParser) new Asn1Set.Asn1SetParserImpl(this);

  protected override int Asn1GetHashCode()
  {
    int count = this.Count;
    int hashCode = count + 1;
    while (--count >= 0)
      hashCode = hashCode * 257 ^ this.m_elements[count].ToAsn1Object().CallAsn1GetHashCode();
    return hashCode;
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    if (!(asn1Object is Asn1Set asn1Set))
      return false;
    int count = this.Count;
    if (asn1Set.Count != count)
      return false;
    for (int index = 0; index < count; ++index)
    {
      if (!this.m_elements[index].ToAsn1Object().Equals(asn1Set.m_elements[index].ToAsn1Object()))
        return false;
    }
    return true;
  }

  public override string ToString()
  {
    return CollectionUtilities.ToString<Asn1Encodable>((IEnumerable<Asn1Encodable>) this.m_elements);
  }

  private static DerEncoding[] SortElements(Asn1Encodable[] elements)
  {
    DerEncoding[] contentsEncodingsDer = Asn1OutputStream.GetContentsEncodingsDer(elements);
    Array.Sort<DerEncoding, Asn1Encodable>(contentsEncodingsDer, elements);
    return contentsEncodingsDer;
  }

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1Set.Meta();

    private Meta()
      : base(typeof (Asn1Set), 17)
    {
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) sequence.ToAsn1Set();
    }
  }

  private class Asn1SetParserImpl : Asn1SetParser, IAsn1Convertible
  {
    private readonly Asn1Set outer;
    private readonly int max;
    private int index;

    public Asn1SetParserImpl(Asn1Set outer)
    {
      this.outer = outer;
      this.max = outer.Count;
    }

    public IAsn1Convertible ReadObject()
    {
      if (this.index == this.max)
        return (IAsn1Convertible) null;
      Asn1Encodable asn1Encodable = this.outer[this.index++];
      switch (asn1Encodable)
      {
        case Asn1Sequence _:
          return (IAsn1Convertible) ((Asn1Sequence) asn1Encodable).Parser;
        case Asn1Set _:
          return (IAsn1Convertible) ((Asn1Set) asn1Encodable).Parser;
        default:
          return (IAsn1Convertible) asn1Encodable;
      }
    }

    public virtual Asn1Object ToAsn1Object() => (Asn1Object) this.outer;
  }
}
