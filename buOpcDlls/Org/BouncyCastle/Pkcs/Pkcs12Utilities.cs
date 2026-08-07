// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkcs.Pkcs12Utilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Pkcs;

public class Pkcs12Utilities
{
  public static byte[] ConvertToDefiniteLength(byte[] berPkcs12File)
  {
    return Pfx.GetInstance((object) berPkcs12File).GetEncoded("DER");
  }

  public static byte[] ConvertToDefiniteLength(byte[] berPkcs12File, char[] passwd)
  {
    Pfx instance = Pfx.GetInstance((object) berPkcs12File);
    ContentInfo authSafe = instance.AuthSafe;
    Asn1Object asn1Object = Asn1Object.FromByteArray(Asn1OctetString.GetInstance((object) authSafe.Content).GetOctets());
    ContentInfo contentInfo = new ContentInfo(authSafe.ContentType, (Asn1Encodable) new DerOctetString(asn1Object.GetEncoded("DER")));
    MacData macData1 = instance.MacData;
    MacData macData2;
    try
    {
      int intValue = macData1.IterationCount.IntValue;
      byte[] octets = Asn1OctetString.GetInstance((object) contentInfo.Content).GetOctets();
      byte[] pbeMac = Pkcs12Store.CalculatePbeMac(macData1.Mac.AlgorithmID.Algorithm, macData1.GetSalt(), intValue, passwd, false, octets);
      macData2 = new MacData(new DigestInfo(new AlgorithmIdentifier(macData1.Mac.AlgorithmID.Algorithm, (Asn1Encodable) DerNull.Instance), pbeMac), macData1.GetSalt(), intValue);
    }
    catch (Exception ex)
    {
      throw new IOException("error constructing MAC: " + ex.ToString());
    }
    return new Pfx(contentInfo, macData2).GetEncoded("DER");
  }
}
