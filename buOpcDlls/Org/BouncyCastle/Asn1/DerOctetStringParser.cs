// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.DerOctetStringParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public class DerOctetStringParser : Asn1OctetStringParser, IAsn1Convertible
{
  private readonly DefiniteLengthInputStream stream;

  internal DerOctetStringParser(DefiniteLengthInputStream stream) => this.stream = stream;

  public Stream GetOctetStream() => (Stream) this.stream;

  public Asn1Object ToAsn1Object()
  {
    try
    {
      return (Asn1Object) new DerOctetString(this.stream.ToArray());
    }
    catch (IOException ex)
    {
      throw new InvalidOperationException("IOException converting stream to byte array: " + ex.Message, (Exception) ex);
    }
  }
}
