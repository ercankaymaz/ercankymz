// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DefaultTlsSrpConfigVerifier
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using Org.BouncyCastle.Tls.Crypto;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class DefaultTlsSrpConfigVerifier : TlsSrpConfigVerifier
{
  private static readonly List<Srp6Group> DefaultGroups = new List<Srp6Group>();
  protected readonly IList<Srp6Group> m_groups;

  static DefaultTlsSrpConfigVerifier()
  {
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_1024);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_1536);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_2048);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_3072);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_4096);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_6144);
    DefaultTlsSrpConfigVerifier.DefaultGroups.Add(Srp6StandardGroups.rfc5054_8192);
  }

  public DefaultTlsSrpConfigVerifier()
    : this((IList<Srp6Group>) DefaultTlsSrpConfigVerifier.DefaultGroups)
  {
  }

  public DefaultTlsSrpConfigVerifier(IList<Srp6Group> groups)
  {
    this.m_groups = (IList<Srp6Group>) new List<Srp6Group>((IEnumerable<Srp6Group>) groups);
  }

  public virtual bool Accept(TlsSrpConfig srpConfig)
  {
    foreach (Srp6Group group in (IEnumerable<Srp6Group>) this.m_groups)
    {
      if (this.AreGroupsEqual(srpConfig, group))
        return true;
    }
    return false;
  }

  protected virtual bool AreGroupsEqual(TlsSrpConfig a, Srp6Group b)
  {
    BigInteger[] explicitNg = a.GetExplicitNG();
    return this.AreParametersEqual(explicitNg[0], b.N) && this.AreParametersEqual(explicitNg[1], b.G);
  }

  protected virtual bool AreParametersEqual(BigInteger a, BigInteger b) => a == b || a.Equals(b);
}
