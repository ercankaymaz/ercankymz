// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampResponseGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;
using Org.BouncyCastle.Asn1.Cms;
using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampResponseGenerator
{
  private PkiStatus status;
  private Asn1EncodableVector statusStrings;
  private int failInfo;
  private TimeStampTokenGenerator tokenGenerator;
  private IList<string> acceptedAlgorithms;
  private IList<string> acceptedPolicies;
  private IList<string> acceptedExtensions;

  public TimeStampResponseGenerator(
    TimeStampTokenGenerator tokenGenerator,
    IList<string> acceptedAlgorithms)
    : this(tokenGenerator, acceptedAlgorithms, (IList<string>) null, (IList<string>) null)
  {
  }

  public TimeStampResponseGenerator(
    TimeStampTokenGenerator tokenGenerator,
    IList<string> acceptedAlgorithms,
    IList<string> acceptedPolicy)
    : this(tokenGenerator, acceptedAlgorithms, acceptedPolicy, (IList<string>) null)
  {
  }

  public TimeStampResponseGenerator(
    TimeStampTokenGenerator tokenGenerator,
    IList<string> acceptedAlgorithms,
    IList<string> acceptedPolicies,
    IList<string> acceptedExtensions)
  {
    this.tokenGenerator = tokenGenerator;
    this.acceptedAlgorithms = acceptedAlgorithms;
    this.acceptedPolicies = acceptedPolicies;
    this.acceptedExtensions = acceptedExtensions;
    this.statusStrings = new Asn1EncodableVector();
  }

  private void AddStatusString(string statusString)
  {
    this.statusStrings.Add((Asn1Encodable) new DerUtf8String(statusString));
  }

  private void SetFailInfoField(int field) => this.failInfo |= field;

  private PkiStatusInfo GetPkiStatusInfo()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector((Asn1Encodable) new DerInteger((int) this.status));
    if (this.statusStrings.Count > 0)
      elementVector.Add((Asn1Encodable) new PkiFreeText((Asn1Sequence) new DerSequence(this.statusStrings)));
    if (this.failInfo != 0)
      elementVector.Add((Asn1Encodable) new TimeStampResponseGenerator.FailInfo(this.failInfo));
    return PkiStatusInfo.GetInstance((object) new DerSequence(elementVector));
  }

  public TimeStampResponse Generate(
    TimeStampRequest request,
    BigInteger serialNumber,
    DateTime? genTime)
  {
    TimeStampResp resp;
    try
    {
      if (!genTime.HasValue)
        throw new TspValidationException("The time source is not available.", 512 /*0x0200*/);
      request.Validate(this.acceptedAlgorithms, this.acceptedPolicies, this.acceptedExtensions);
      this.status = PkiStatus.Granted;
      this.AddStatusString("Operation Okay");
      PkiStatusInfo pkiStatusInfo = this.GetPkiStatusInfo();
      ContentInfo instance;
      try
      {
        instance = ContentInfo.GetInstance((object) Asn1Object.FromByteArray(this.tokenGenerator.Generate(request, serialNumber, genTime.Value).ToCmsSignedData().GetEncoded()));
      }
      catch (IOException ex)
      {
        throw new TspException("Timestamp token received cannot be converted to ContentInfo", (Exception) ex);
      }
      resp = new TimeStampResp(pkiStatusInfo, instance);
    }
    catch (TspValidationException ex)
    {
      this.status = PkiStatus.Rejection;
      this.SetFailInfoField(ex.FailureCode);
      this.AddStatusString(ex.Message);
      resp = new TimeStampResp(this.GetPkiStatusInfo(), (ContentInfo) null);
    }
    try
    {
      return new TimeStampResponse(resp);
    }
    catch (IOException ex)
    {
      throw new TspException("created badly formatted response!", (Exception) ex);
    }
  }

  public TimeStampResponse GenerateGrantedResponse(
    TimeStampRequest request,
    BigInteger serialNumber,
    DateTime? genTime,
    string statusString,
    X509Extensions additionalExtensions)
  {
    TimeStampResp resp;
    try
    {
      if (!genTime.HasValue)
        throw new TspValidationException("The time source is not available.", 512 /*0x0200*/);
      request.Validate(this.acceptedAlgorithms, this.acceptedPolicies, this.acceptedExtensions);
      this.status = PkiStatus.Granted;
      this.AddStatusString(statusString);
      PkiStatusInfo pkiStatusInfo = this.GetPkiStatusInfo();
      ContentInfo instance;
      try
      {
        instance = ContentInfo.GetInstance((object) Asn1Object.FromByteArray(this.tokenGenerator.Generate(request, serialNumber, genTime.Value, additionalExtensions).ToCmsSignedData().GetEncoded()));
      }
      catch (IOException ex)
      {
        throw new TspException("Timestamp token received cannot be converted to ContentInfo", (Exception) ex);
      }
      resp = new TimeStampResp(pkiStatusInfo, instance);
    }
    catch (TspValidationException ex)
    {
      this.status = PkiStatus.Rejection;
      this.SetFailInfoField(ex.FailureCode);
      this.AddStatusString(ex.Message);
      resp = new TimeStampResp(this.GetPkiStatusInfo(), (ContentInfo) null);
    }
    try
    {
      return new TimeStampResponse(resp);
    }
    catch (IOException ex)
    {
      throw new TspException("created badly formatted response!", (Exception) ex);
    }
  }

  public TimeStampResponse GenerateFailResponse(
    PkiStatus status,
    int failInfoField,
    string statusString)
  {
    this.status = status;
    this.SetFailInfoField(failInfoField);
    if (statusString != null)
      this.AddStatusString(statusString);
    TimeStampResp resp = new TimeStampResp(this.GetPkiStatusInfo(), (ContentInfo) null);
    try
    {
      return new TimeStampResponse(resp);
    }
    catch (IOException ex)
    {
      throw new TspException("created badly formatted response!", (Exception) ex);
    }
  }

  private class FailInfo : DerBitString
  {
    internal FailInfo(int failInfoValue)
      : base(failInfoValue)
    {
    }
  }
}
