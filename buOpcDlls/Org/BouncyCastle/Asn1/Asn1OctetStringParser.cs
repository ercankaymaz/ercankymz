// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Asn1OctetStringParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.IO;

#nullable disable
namespace Org.BouncyCastle.Asn1;

public interface Asn1OctetStringParser : IAsn1Convertible
{
  Stream GetOctetStream();
}
