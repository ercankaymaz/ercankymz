// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LMOtsParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class LMOtsParameters
{
  public static LMOtsParameters sha256_n32_w1 = new LMOtsParameters(1, 32 /*0x20*/, 1, 265, 7, 8516U, NistObjectIdentifiers.IdSha256);
  public static LMOtsParameters sha256_n32_w2 = new LMOtsParameters(2, 32 /*0x20*/, 2, 133, 6, 4292U, NistObjectIdentifiers.IdSha256);
  public static LMOtsParameters sha256_n32_w4 = new LMOtsParameters(3, 32 /*0x20*/, 4, 67, 4, 2180U, NistObjectIdentifiers.IdSha256);
  public static LMOtsParameters sha256_n32_w8 = new LMOtsParameters(4, 32 /*0x20*/, 8, 34, 0, 1124U, NistObjectIdentifiers.IdSha256);
  private static Dictionary<object, LMOtsParameters> Suppliers = new Dictionary<object, LMOtsParameters>()
  {
    {
      (object) LMOtsParameters.sha256_n32_w1.ID,
      LMOtsParameters.sha256_n32_w1
    },
    {
      (object) LMOtsParameters.sha256_n32_w2.ID,
      LMOtsParameters.sha256_n32_w2
    },
    {
      (object) LMOtsParameters.sha256_n32_w4.ID,
      LMOtsParameters.sha256_n32_w4
    },
    {
      (object) LMOtsParameters.sha256_n32_w8.ID,
      LMOtsParameters.sha256_n32_w8
    }
  };
  private readonly int m_id;
  private readonly int m_n;
  private readonly int m_w;
  private readonly int m_p;
  private readonly int m_ls;
  private readonly uint m_sigLen;
  private readonly DerObjectIdentifier m_digestOid;

  internal LMOtsParameters(
    int id,
    int n,
    int w,
    int p,
    int ls,
    uint sigLen,
    DerObjectIdentifier digestOid)
  {
    this.m_id = id;
    this.m_n = n;
    this.m_w = w;
    this.m_p = p;
    this.m_ls = ls;
    this.m_sigLen = sigLen;
    this.m_digestOid = digestOid;
  }

  public int ID => this.m_id;

  public int N => this.m_n;

  public int W => this.m_w;

  public int P => this.m_p;

  public int Ls => this.m_ls;

  public int SigLen => Convert.ToInt32(this.m_sigLen);

  public DerObjectIdentifier DigestOid => this.m_digestOid;

  public static LMOtsParameters GetParametersByID(int id)
  {
    return CollectionUtilities.GetValueOrNull<object, LMOtsParameters>((IDictionary<object, LMOtsParameters>) LMOtsParameters.Suppliers, (object) id);
  }
}
