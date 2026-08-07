// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Ocsp.OCSPRespGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Ocsp;
using System;

#nullable disable
namespace Org.BouncyCastle.Ocsp;

public class OCSPRespGenerator
{
  public const int Successful = 0;
  public const int MalformedRequest = 1;
  public const int InternalError = 2;
  public const int TryLater = 3;
  public const int SigRequired = 5;
  public const int Unauthorized = 6;

  public OcspResp Generate(int status, object response)
  {
    if (response == null)
      return new OcspResp(new OcspResponse(new OcspResponseStatus(status), (ResponseBytes) null));
    BasicOcspResp basicOcspResp = response is BasicOcspResp ? (BasicOcspResp) response : throw new OcspException("unknown response object");
    Asn1OctetString response1;
    try
    {
      response1 = (Asn1OctetString) new DerOctetString(basicOcspResp.GetEncoded());
    }
    catch (Exception ex)
    {
      throw new OcspException("can't encode object.", ex);
    }
    ResponseBytes responseBytes = new ResponseBytes(OcspObjectIdentifiers.PkixOcspBasic, response1);
    return new OcspResp(new OcspResponse(new OcspResponseStatus(status), responseBytes));
  }
}
