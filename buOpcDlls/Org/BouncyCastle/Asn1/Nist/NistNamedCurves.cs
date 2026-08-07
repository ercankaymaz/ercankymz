// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Nist.NistNamedCurves
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Sec;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Nist;

public static class NistNamedCurves
{
  private static readonly Dictionary<string, DerObjectIdentifier> objIds = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<DerObjectIdentifier, string> names = new Dictionary<DerObjectIdentifier, string>();

  private static void DefineCurveAlias(string name, DerObjectIdentifier oid)
  {
    if (SecNamedCurves.GetByOidLazy(oid) == null)
      throw new InvalidOperationException();
    NistNamedCurves.objIds.Add(name, oid);
    NistNamedCurves.names.Add(oid, name);
  }

  static NistNamedCurves()
  {
    NistNamedCurves.DefineCurveAlias("B-163", SecObjectIdentifiers.SecT163r2);
    NistNamedCurves.DefineCurveAlias("B-233", SecObjectIdentifiers.SecT233r1);
    NistNamedCurves.DefineCurveAlias("B-283", SecObjectIdentifiers.SecT283r1);
    NistNamedCurves.DefineCurveAlias("B-409", SecObjectIdentifiers.SecT409r1);
    NistNamedCurves.DefineCurveAlias("B-571", SecObjectIdentifiers.SecT571r1);
    NistNamedCurves.DefineCurveAlias("K-163", SecObjectIdentifiers.SecT163k1);
    NistNamedCurves.DefineCurveAlias("K-233", SecObjectIdentifiers.SecT233k1);
    NistNamedCurves.DefineCurveAlias("K-283", SecObjectIdentifiers.SecT283k1);
    NistNamedCurves.DefineCurveAlias("K-409", SecObjectIdentifiers.SecT409k1);
    NistNamedCurves.DefineCurveAlias("K-571", SecObjectIdentifiers.SecT571k1);
    NistNamedCurves.DefineCurveAlias("P-192", SecObjectIdentifiers.SecP192r1);
    NistNamedCurves.DefineCurveAlias("P-224", SecObjectIdentifiers.SecP224r1);
    NistNamedCurves.DefineCurveAlias("P-256", SecObjectIdentifiers.SecP256r1);
    NistNamedCurves.DefineCurveAlias("P-384", SecObjectIdentifiers.SecP384r1);
    NistNamedCurves.DefineCurveAlias("P-521", SecObjectIdentifiers.SecP521r1);
  }

  public static X9ECParameters GetByName(string name)
  {
    DerObjectIdentifier oid = NistNamedCurves.GetOid(name);
    return oid != null ? NistNamedCurves.GetByOid(oid) : (X9ECParameters) null;
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    DerObjectIdentifier oid = NistNamedCurves.GetOid(name);
    return oid != null ? NistNamedCurves.GetByOidLazy(oid) : (X9ECParametersHolder) null;
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return NistNamedCurves.GetByOidLazy(oid)?.Parameters;
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return !NistNamedCurves.names.ContainsKey(oid) ? (X9ECParametersHolder) null : SecNamedCurves.GetByOidLazy(oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, string>((IDictionary<DerObjectIdentifier, string>) NistNamedCurves.names, oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) NistNamedCurves.objIds, name);
  }

  public static IEnumerable<string> Names
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) NistNamedCurves.objIds.Keys);
  }
}
