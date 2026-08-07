// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1ParsingException
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Asn1;

[Serializable]
public class Asn1ParsingException : InvalidOperationException
{
  public Asn1ParsingException()
  {
  }

  public Asn1ParsingException(string message)
    : base(message)
  {
  }

  public Asn1ParsingException(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected Asn1ParsingException(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
