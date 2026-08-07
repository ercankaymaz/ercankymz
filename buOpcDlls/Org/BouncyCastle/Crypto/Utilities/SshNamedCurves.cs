// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Utilities.SshNamedCurves
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Utilities;

public static class SshNamedCurves
{
  private static readonly Dictionary<string, DerObjectIdentifier> objIds = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<DerObjectIdentifier, string> names = new Dictionary<DerObjectIdentifier, string>();

  private static void DefineCurveAlias(string name, DerObjectIdentifier oid)
  {
    if (SshNamedCurves.FindByOidLazy(oid) == null)
      throw new InvalidOperationException();
    SshNamedCurves.objIds.Add(name, oid);
    SshNamedCurves.names.Add(oid, name);
  }

  private static X9ECParametersHolder FindByOidLazy(DerObjectIdentifier oid)
  {
    return ECKeyPairGenerator.FindECCurveByOidLazy(oid);
  }

  static SshNamedCurves()
  {
    SshNamedCurves.DefineCurveAlias("nistp192", SecObjectIdentifiers.SecP192r1);
    SshNamedCurves.DefineCurveAlias("nistp224", SecObjectIdentifiers.SecP224r1);
    SshNamedCurves.DefineCurveAlias("nistp256", SecObjectIdentifiers.SecP256r1);
    SshNamedCurves.DefineCurveAlias("nistp384", SecObjectIdentifiers.SecP384r1);
    SshNamedCurves.DefineCurveAlias("nistp521", SecObjectIdentifiers.SecP521r1);
    SshNamedCurves.DefineCurveAlias("nistb233", SecObjectIdentifiers.SecT233r1);
    SshNamedCurves.DefineCurveAlias("nistb409", SecObjectIdentifiers.SecT409r1);
    SshNamedCurves.DefineCurveAlias("nistk163", SecObjectIdentifiers.SecT163k1);
    SshNamedCurves.DefineCurveAlias("nistk233", SecObjectIdentifiers.SecT233k1);
    SshNamedCurves.DefineCurveAlias("nistk283", SecObjectIdentifiers.SecT283k1);
    SshNamedCurves.DefineCurveAlias("nistk409", SecObjectIdentifiers.SecT409k1);
    SshNamedCurves.DefineCurveAlias("nistt571", SecObjectIdentifiers.SecT571k1);
  }

  public static X9ECParameters GetByName(string name)
  {
    DerObjectIdentifier oid = SshNamedCurves.GetOid(name);
    return oid != null ? SshNamedCurves.GetByOid(oid) : (X9ECParameters) null;
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    DerObjectIdentifier oid = SshNamedCurves.GetOid(name);
    return oid != null ? SshNamedCurves.GetByOidLazy(oid) : (X9ECParametersHolder) null;
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return SshNamedCurves.GetByOidLazy(oid)?.Parameters;
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return !SshNamedCurves.names.ContainsKey(oid) ? (X9ECParametersHolder) null : SshNamedCurves.FindByOidLazy(oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, string>((IDictionary<DerObjectIdentifier, string>) SshNamedCurves.names, oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) SshNamedCurves.objIds, name);
  }

  public static IEnumerable<string> Names
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) SshNamedCurves.objIds.Keys);
  }
}
