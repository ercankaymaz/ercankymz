// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.NestedMessageContent
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class NestedMessageContent : PkiMessages
{
  public static NestedMessageContent GetInstance(object obj)
  {
    switch (obj)
    {
      case null:
        return (NestedMessageContent) null;
      case NestedMessageContent instance:
        return instance;
      case PkiMessages other:
        return new NestedMessageContent(other);
      default:
        return new NestedMessageContent(Asn1Sequence.GetInstance(obj));
    }
  }

  public static NestedMessageContent GetInstance(
    Asn1TaggedObject taggedObject,
    bool declaredExplicit)
  {
    return NestedMessageContent.GetInstance((object) Asn1Sequence.GetInstance(taggedObject, declaredExplicit));
  }

  public NestedMessageContent(PkiMessage msg)
    : base(msg)
  {
  }

  public NestedMessageContent(PkiMessage[] msgs)
    : base(msgs)
  {
  }

  [Obsolete("Use 'GetInstance' instead")]
  public NestedMessageContent(Asn1Sequence seq)
    : base(seq)
  {
  }

  internal NestedMessageContent(PkiMessages other)
    : base(other)
  {
  }
}
