// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampResponse
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Utilities;
using System;
using System.IO;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampResponse
{
  private TimeStampResp resp;
  private TimeStampToken timeStampToken;

  public TimeStampResponse(TimeStampResp resp)
  {
    this.resp = resp;
    if (resp.TimeStampToken == null)
      return;
    this.timeStampToken = new TimeStampToken(resp.TimeStampToken);
  }

  public TimeStampResponse(byte[] resp)
    : this(TimeStampResponse.readTimeStampResp(new Asn1InputStream(resp)))
  {
  }

  public TimeStampResponse(Stream input)
    : this(TimeStampResponse.readTimeStampResp(new Asn1InputStream(input)))
  {
  }

  private static TimeStampResp readTimeStampResp(Asn1InputStream input)
  {
    try
    {
      return TimeStampResp.GetInstance((object) input.ReadObject());
    }
    catch (ArgumentException ex)
    {
      throw new TspException("malformed timestamp response: " + ex?.ToString(), (Exception) ex);
    }
    catch (InvalidCastException ex)
    {
      throw new TspException("malformed timestamp response: " + ex?.ToString(), (Exception) ex);
    }
  }

  public int Status => this.resp.Status.Status.IntValue;

  public string GetStatusString()
  {
    if (this.resp.Status.StatusString == null)
      return (string) null;
    StringBuilder stringBuilder = new StringBuilder();
    PkiFreeText statusString = this.resp.Status.StatusString;
    for (int index = 0; index != statusString.Count; ++index)
      stringBuilder.Append(statusString[index].GetString());
    return stringBuilder.ToString();
  }

  public PkiFailureInfo GetFailInfo()
  {
    return this.resp.Status.FailInfo == null ? (PkiFailureInfo) null : new PkiFailureInfo(this.resp.Status.FailInfo);
  }

  public TimeStampToken TimeStampToken => this.timeStampToken;

  public void Validate(TimeStampRequest request)
  {
    TimeStampToken timeStampToken = this.TimeStampToken;
    if (timeStampToken != null)
    {
      TimeStampTokenInfo timeStampInfo = timeStampToken.TimeStampInfo;
      if (request.Nonce != null && !request.Nonce.Equals(timeStampInfo.Nonce))
        throw new TspValidationException("response contains wrong nonce value.");
      if (this.Status != 0 && this.Status != 1)
        throw new TspValidationException("time stamp token found in failed request.");
      if (!Arrays.FixedTimeEquals(request.GetMessageImprintDigest(), timeStampInfo.GetMessageImprintDigest()))
        throw new TspValidationException("response for different message imprint digest.");
      if (!timeStampInfo.MessageImprintAlgOid.Equals(request.MessageImprintAlgOid))
        throw new TspValidationException("response for different message imprint algorithm.");
      Org.BouncyCastle.Asn1.Cms.Attribute signedAttribute1 = timeStampToken.SignedAttributes[PkcsObjectIdentifiers.IdAASigningCertificate];
      Org.BouncyCastle.Asn1.Cms.Attribute signedAttribute2 = timeStampToken.SignedAttributes[PkcsObjectIdentifiers.IdAASigningCertificateV2];
      if (signedAttribute1 == null && signedAttribute2 == null)
        throw new TspValidationException("no signing certificate attribute present.");
      if (signedAttribute1 != null)
        ;
      if (request.ReqPolicy != null && !request.ReqPolicy.Equals(timeStampInfo.Policy))
        throw new TspValidationException("TSA policy wrong for request.");
    }
    else if (this.Status == 0 || this.Status == 1)
      throw new TspValidationException("no time stamp token found and one expected.");
  }

  public byte[] GetEncoded() => this.resp.GetEncoded();
}
