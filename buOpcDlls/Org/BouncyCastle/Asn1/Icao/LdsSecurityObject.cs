// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Icao.LdsSecurityObject
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Math;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Icao;

public class LdsSecurityObject : Asn1Encodable
{
  public const int UBDataGroups = 16 /*0x10*/;
  private DerInteger version = new DerInteger(0);
  private AlgorithmIdentifier digestAlgorithmIdentifier;
  private DataGroupHash[] datagroupHash;
  private LdsVersionInfo versionInfo;

  public static LdsSecurityObject GetInstance(object obj)
  {
    if (obj is LdsSecurityObject)
      return (LdsSecurityObject) obj;
    return obj != null ? new LdsSecurityObject(Asn1Sequence.GetInstance(obj)) : (LdsSecurityObject) null;
  }

  private LdsSecurityObject(Asn1Sequence seq)
  {
    IEnumerator<Asn1Encodable> enumerator = seq != null && seq.Count != 0 ? seq.GetEnumerator() : throw new ArgumentException("null or empty sequence passed.");
    enumerator.MoveNext();
    this.version = DerInteger.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    this.digestAlgorithmIdentifier = AlgorithmIdentifier.GetInstance((object) enumerator.Current);
    enumerator.MoveNext();
    Asn1Sequence instance = Asn1Sequence.GetInstance((object) enumerator.Current);
    if (this.version.HasValue(1))
    {
      enumerator.MoveNext();
      this.versionInfo = LdsVersionInfo.GetInstance((object) enumerator.Current);
    }
    this.CheckDatagroupHashSeqSize(instance.Count);
    this.datagroupHash = new DataGroupHash[instance.Count];
    for (int index = 0; index < instance.Count; ++index)
      this.datagroupHash[index] = DataGroupHash.GetInstance((object) instance[index]);
  }

  public LdsSecurityObject(
    AlgorithmIdentifier digestAlgorithmIdentifier,
    DataGroupHash[] datagroupHash)
  {
    this.version = new DerInteger(0);
    this.digestAlgorithmIdentifier = digestAlgorithmIdentifier;
    this.datagroupHash = datagroupHash;
    this.CheckDatagroupHashSeqSize(datagroupHash.Length);
  }

  public LdsSecurityObject(
    AlgorithmIdentifier digestAlgorithmIdentifier,
    DataGroupHash[] datagroupHash,
    LdsVersionInfo versionInfo)
  {
    this.version = new DerInteger(1);
    this.digestAlgorithmIdentifier = digestAlgorithmIdentifier;
    this.datagroupHash = datagroupHash;
    this.versionInfo = versionInfo;
    this.CheckDatagroupHashSeqSize(datagroupHash.Length);
  }

  private void CheckDatagroupHashSeqSize(int size)
  {
    if (size < 2 || size > 16 /*0x10*/)
      throw new ArgumentException($"wrong size in DataGroupHashValues : not in (2..{16 /*0x10*/.ToString()})");
  }

  public BigInteger Version => this.version.Value;

  public AlgorithmIdentifier DigestAlgorithmIdentifier => this.digestAlgorithmIdentifier;

  public DataGroupHash[] GetDatagroupHash() => this.datagroupHash;

  public LdsVersionInfo VersionInfo => this.versionInfo;

  public override Asn1Object ToAsn1Object()
  {
    Asn1EncodableVector elementVector = new Asn1EncodableVector(new Asn1Encodable[3]
    {
      (Asn1Encodable) this.version,
      (Asn1Encodable) this.digestAlgorithmIdentifier,
      (Asn1Encodable) new DerSequence((Asn1Encodable[]) this.datagroupHash)
    });
    elementVector.AddOptional((Asn1Encodable) this.versionInfo);
    return (Asn1Object) new DerSequence(elementVector);
  }
}
