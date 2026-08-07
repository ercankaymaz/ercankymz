// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1Exception
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Asn1;

[Serializable]
public class Asn1Exception : IOException
{
  public Asn1Exception()
  {
  }

  public Asn1Exception(string message)
    : base(message)
  {
  }

  public Asn1Exception(string message, Exception innerException)
    : base(message, innerException)
  {
  }

  protected Asn1Exception(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
  }
}
