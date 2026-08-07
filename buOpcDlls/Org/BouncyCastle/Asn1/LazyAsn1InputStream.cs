// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.LazyAsn1InputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

[Obsolete("Will be removed")]
public class LazyAsn1InputStream : Asn1InputStream
{
  public LazyAsn1InputStream(byte[] input)
    : base(input)
  {
  }

  public LazyAsn1InputStream(Stream inputStream)
    : base(inputStream)
  {
  }

  public LazyAsn1InputStream(Stream input, int limit)
    : base(input, limit)
  {
  }

  public LazyAsn1InputStream(Stream input, int limit, bool leaveOpen)
    : base(input, limit, leaveOpen)
  {
  }
}
