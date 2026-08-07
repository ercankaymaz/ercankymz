// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Sequence
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

public abstract class Asn1Sequence : Asn1Object, IEnumerable<Asn1Encodable>, IEnumerable
{
  internal readonly Asn1Encodable[] elements;

  public static Asn1Sequence GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (Asn1Sequence) null;
      case Asn1Sequence instance:
        return instance;
      case IAsn1Convertible asn1Convertible:
        if (asn1Convertible.ToAsn1Object() is Asn1Sequence asn1Object)
          return asn1Object;
        break;
      case byte[] bytes:
        try
        {
          return (Asn1Sequence) Asn1Sequence.Meta.Instance.FromByteArray(bytes);
        }
        catch (IOException ex)
        {
          throw new ArgumentException("failed to construct sequence from byte[]: " + ex.Message);
        }
    }
    throw new ArgumentException("illegal object in GetInstance: " + Platform.GetTypeName(obj), nameof (obj));
  }

  public static Asn1Sequence GetInstance(Asn1TaggedObject taggedObject, bool declaredExplicit)
  {
    return (Asn1Sequence) Asn1Sequence.Meta.Instance.GetContextInstance(taggedObject, declaredExplicit);
  }

  protected internal Asn1Sequence() => this.elements = Asn1EncodableVector.EmptyElements;

  protected internal Asn1Sequence(Asn1Encodable element)
  {
    this.elements = element != null ? new Asn1Encodable[1]
    {
      element
    } : throw new ArgumentNullException(nameof (element));
  }

  protected internal Asn1Sequence(Asn1Encodable element1, Asn1Encodable element2)
  {
    if (element1 == null)
      throw new ArgumentNullException(nameof (element1));
    this.elements = element2 != null ? new Asn1Encodable[2]
    {
      element1,
      element2
    } : throw new ArgumentNullException(nameof (element2));
  }

  protected internal Asn1Sequence(params Asn1Encodable[] elements)
  {
    this.elements = !Arrays.IsNullOrContainsNull((object[]) elements) ? Asn1EncodableVector.CloneElements(elements) : throw new NullReferenceException("'elements' cannot be null, or contain null");
  }

  internal Asn1Sequence(Asn1Encodable[] elements, bool clone)
  {
    this.elements = clone ? Asn1EncodableVector.CloneElements(elements) : elements;
  }

  protected internal Asn1Sequence(Asn1EncodableVector elementVector)
  {
    this.elements = elementVector != null ? elementVector.TakeElements() : throw new ArgumentNullException(nameof (elementVector));
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public virtual IEnumerator<Asn1Encodable> GetEnumerator()
  {
    return ((IEnumerable<Asn1Encodable>) this.elements).GetEnumerator();
  }

  public virtual Asn1SequenceParser Parser
  {
    get => (Asn1SequenceParser) new Asn1Sequence.Asn1SequenceParserImpl(this);
  }

  public virtual Asn1Encodable this[int index] => this.elements[index];

  public virtual int Count => this.elements.Length;

  public virtual T[] MapElements<T>(Func<Asn1Encodable, T> func)
  {
    int count = this.Count;
    T[] objArray = new T[count];
    for (int index = 0; index < count; ++index)
      objArray[index] = func(this.elements[index]);
    return objArray;
  }

  public virtual Asn1Encodable[] ToArray() => Asn1EncodableVector.CloneElements(this.elements);

  protected override int Asn1GetHashCode()
  {
    int count = this.Count;
    int hashCode = count + 1;
    while (--count >= 0)
      hashCode = hashCode * 257 ^ this.elements[count].ToAsn1Object().CallAsn1GetHashCode();
    return hashCode;
  }

  protected override bool Asn1Equals(Asn1Object asn1Object)
  {
    if (!(asn1Object is Asn1Sequence asn1Sequence))
      return false;
    int count = this.Count;
    if (asn1Sequence.Count != count)
      return false;
    for (int index = 0; index < count; ++index)
    {
      if (!this.elements[index].ToAsn1Object().Equals(asn1Sequence.elements[index].ToAsn1Object()))
        return false;
    }
    return true;
  }

  public override string ToString()
  {
    return CollectionUtilities.ToString<Asn1Encodable>((IEnumerable<Asn1Encodable>) this.elements);
  }

  internal DerBitString[] GetConstructedBitStrings()
  {
    return this.MapElements<DerBitString>(new Func<Asn1Encodable, DerBitString>(DerBitString.GetInstance));
  }

  internal Asn1OctetString[] GetConstructedOctetStrings()
  {
    return this.MapElements<Asn1OctetString>(new Func<Asn1Encodable, Asn1OctetString>(Asn1OctetString.GetInstance));
  }

  internal abstract DerBitString ToAsn1BitString();

  internal abstract DerExternal ToAsn1External();

  internal abstract Asn1OctetString ToAsn1OctetString();

  internal abstract Asn1Set ToAsn1Set();

  internal class Meta : Asn1UniversalType
  {
    internal static readonly Asn1UniversalType Instance = (Asn1UniversalType) new Asn1Sequence.Meta();

    private Meta()
      : base(typeof (Asn1Sequence), 16 /*0x10*/)
    {
    }

    internal override Asn1Object FromImplicitConstructed(Asn1Sequence sequence)
    {
      return (Asn1Object) sequence;
    }
  }

  private class Asn1SequenceParserImpl : Asn1SequenceParser, IAsn1Convertible
  {
    private readonly Asn1Sequence outer;
    private readonly int max;
    private int index;

    public Asn1SequenceParserImpl(Asn1Sequence outer)
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

    public Asn1Object ToAsn1Object() => (Asn1Object) this.outer;
  }
}
