// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tsp.TimeStampTokenInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Tsp;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Tsp;

public class TimeStampTokenInfo
{
  private TstInfo tstInfo;
  private DateTime genTime;

  private static TstInfo ParseTstInfo(byte[] tstInfoEncoding)
  {
    try
    {
      return TstInfo.GetInstance((object) tstInfoEncoding);
    }
    catch (Exception ex)
    {
      throw new TspException("unable to parse TstInfo encoding: " + ex.Message);
    }
  }

  public TimeStampTokenInfo(byte[] tstInfoEncoding)
    : this(TimeStampTokenInfo.ParseTstInfo(tstInfoEncoding))
  {
  }

  public TimeStampTokenInfo(TstInfo tstInfo)
  {
    this.tstInfo = tstInfo;
    try
    {
      this.genTime = tstInfo.GenTime.ToDateTime();
    }
    catch (Exception ex)
    {
      throw new TspException("unable to parse genTime field: " + ex.Message);
    }
  }

  public bool IsOrdered => this.tstInfo.Ordering.IsTrue;

  public Accuracy Accuracy => this.tstInfo.Accuracy;

  public DateTime GenTime => this.genTime;

  public GenTimeAccuracy GenTimeAccuracy
  {
    get => this.Accuracy != null ? new GenTimeAccuracy(this.Accuracy) : (GenTimeAccuracy) null;
  }

  public string Policy => this.tstInfo.Policy.Id;

  public BigInteger SerialNumber => this.tstInfo.SerialNumber.Value;

  public GeneralName Tsa => this.tstInfo.Tsa;

  public BigInteger Nonce
  {
    get => this.tstInfo.Nonce != null ? this.tstInfo.Nonce.Value : (BigInteger) null;
  }

  public AlgorithmIdentifier HashAlgorithm => this.tstInfo.MessageImprint.HashAlgorithm;

  public string MessageImprintAlgOid => this.tstInfo.MessageImprint.HashAlgorithm.Algorithm.Id;

  public byte[] GetMessageImprintDigest() => this.tstInfo.MessageImprint.GetHashedMessage();

  public byte[] GetEncoded() => this.tstInfo.GetEncoded();

  public TstInfo TstInfo => this.tstInfo;
}
