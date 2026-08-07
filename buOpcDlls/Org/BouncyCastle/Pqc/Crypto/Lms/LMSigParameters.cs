// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMSigParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Utilities.Collections;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMSigParameters
{
  public static LMSigParameters lms_sha256_n32_h5 = new LMSigParameters(5, 32 /*0x20*/, 5, NistObjectIdentifiers.IdSha256);
  public static LMSigParameters lms_sha256_n32_h10 = new LMSigParameters(6, 32 /*0x20*/, 10, NistObjectIdentifiers.IdSha256);
  public static LMSigParameters lms_sha256_n32_h15 = new LMSigParameters(7, 32 /*0x20*/, 15, NistObjectIdentifiers.IdSha256);
  public static LMSigParameters lms_sha256_n32_h20 = new LMSigParameters(8, 32 /*0x20*/, 20, NistObjectIdentifiers.IdSha256);
  public static LMSigParameters lms_sha256_n32_h25 = new LMSigParameters(9, 32 /*0x20*/, 25, NistObjectIdentifiers.IdSha256);
  private static Dictionary<int, LMSigParameters> ParametersByID = new Dictionary<int, LMSigParameters>()
  {
    {
      LMSigParameters.lms_sha256_n32_h5.ID,
      LMSigParameters.lms_sha256_n32_h5
    },
    {
      LMSigParameters.lms_sha256_n32_h10.ID,
      LMSigParameters.lms_sha256_n32_h10
    },
    {
      LMSigParameters.lms_sha256_n32_h15.ID,
      LMSigParameters.lms_sha256_n32_h15
    },
    {
      LMSigParameters.lms_sha256_n32_h20.ID,
      LMSigParameters.lms_sha256_n32_h20
    },
    {
      LMSigParameters.lms_sha256_n32_h25.ID,
      LMSigParameters.lms_sha256_n32_h25
    }
  };
  private readonly int m_id;
  private readonly int m_m;
  private readonly int m_h;
  private readonly DerObjectIdentifier m_digestOid;

  internal LMSigParameters(int id, int m, int h, DerObjectIdentifier digestOid)
  {
    this.m_id = id;
    this.m_m = m;
    this.m_h = h;
    this.m_digestOid = digestOid;
  }

  public int ID => this.m_id;

  public int H => this.m_h;

  public int M => this.m_m;

  public DerObjectIdentifier DigestOid => this.m_digestOid;

  public static LMSigParameters GetParametersByID(int id)
  {
    return CollectionUtilities.GetValueOrNull<int, LMSigParameters>((IDictionary<int, LMSigParameters>) LMSigParameters.ParametersByID, id);
  }
}
