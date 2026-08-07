// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsDHGroupVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DefaultTlsDHGroupVerifier : TlsDHGroupVerifier
{
  public static readonly int DefaultMinimumPrimeBits = 2048 /*0x0800*/;
  private static readonly List<DHGroup> DefaultGroups = new List<DHGroup>();
  protected readonly IList<DHGroup> m_groups;
  protected readonly int m_minimumPrimeBits;

  private static void AddDefaultGroup(DHGroup dhGroup)
  {
    DefaultTlsDHGroupVerifier.DefaultGroups.Add(dhGroup);
  }

  static DefaultTlsDHGroupVerifier()
  {
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc3526_2048);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc3526_3072);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc3526_4096);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc3526_6144);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc3526_8192);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc7919_ffdhe2048);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc7919_ffdhe3072);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc7919_ffdhe4096);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc7919_ffdhe6144);
    DefaultTlsDHGroupVerifier.AddDefaultGroup(DHStandardGroups.rfc7919_ffdhe8192);
  }

  public DefaultTlsDHGroupVerifier()
    : this(DefaultTlsDHGroupVerifier.DefaultMinimumPrimeBits)
  {
  }

  public DefaultTlsDHGroupVerifier(int minimumPrimeBits)
    : this((IList<DHGroup>) DefaultTlsDHGroupVerifier.DefaultGroups, minimumPrimeBits)
  {
  }

  public DefaultTlsDHGroupVerifier(IList<DHGroup> groups, int minimumPrimeBits)
  {
    this.m_groups = (IList<DHGroup>) new List<DHGroup>((IEnumerable<DHGroup>) groups);
    this.m_minimumPrimeBits = minimumPrimeBits;
  }

  public virtual bool Accept(DHGroup dhGroup)
  {
    return this.CheckMinimumPrimeBits(dhGroup) && this.CheckGroup(dhGroup);
  }

  public virtual int MinimumPrimeBits => this.m_minimumPrimeBits;

  protected virtual bool AreGroupsEqual(DHGroup a, DHGroup b)
  {
    if (a == b)
      return true;
    return this.AreParametersEqual(a.P, b.P) && this.AreParametersEqual(a.G, b.G);
  }

  protected virtual bool AreParametersEqual(BigInteger a, BigInteger b) => a == b || a.Equals(b);

  protected virtual bool CheckGroup(DHGroup dhGroup)
  {
    foreach (DHGroup group in (IEnumerable<DHGroup>) this.m_groups)
    {
      if (this.AreGroupsEqual(dhGroup, group))
        return true;
    }
    return false;
  }

  protected virtual bool CheckMinimumPrimeBits(DHGroup dhGroup)
  {
    return dhGroup.P.BitLength >= this.MinimumPrimeBits;
  }
}
