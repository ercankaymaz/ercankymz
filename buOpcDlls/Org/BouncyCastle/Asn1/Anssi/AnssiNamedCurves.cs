// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Anssi.AnssiNamedCurves
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.Anssi;

public static class AnssiNamedCurves
{
  private static readonly Dictionary<string, DerObjectIdentifier> objIds = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<DerObjectIdentifier, X9ECParametersHolder> curves = new Dictionary<DerObjectIdentifier, X9ECParametersHolder>();
  private static readonly Dictionary<DerObjectIdentifier, string> names = new Dictionary<DerObjectIdentifier, string>();

  private static X9ECPoint ConfigureBasepoint(ECCurve curve, string encoding)
  {
    X9ECPoint x9EcPoint = new X9ECPoint(curve, Hex.DecodeStrict(encoding));
    WNafUtilities.ConfigureBasepoint(x9EcPoint.Point);
    return x9EcPoint;
  }

  private static ECCurve ConfigureCurve(ECCurve curve) => curve;

  private static BigInteger FromHex(string hex) => new BigInteger(1, Hex.DecodeStrict(hex));

  private static void DefineCurve(
    string name,
    DerObjectIdentifier oid,
    X9ECParametersHolder holder)
  {
    AnssiNamedCurves.objIds.Add(name, oid);
    AnssiNamedCurves.names.Add(oid, name);
    AnssiNamedCurves.curves.Add(oid, holder);
  }

  static AnssiNamedCurves()
  {
    AnssiNamedCurves.DefineCurve("FRP256v1", AnssiObjectIdentifiers.FRP256v1, AnssiNamedCurves.Frp256v1Holder.Instance);
  }

  public static X9ECParameters GetByName(string name)
  {
    DerObjectIdentifier oid = AnssiNamedCurves.GetOid(name);
    return oid != null ? AnssiNamedCurves.GetByOid(oid) : (X9ECParameters) null;
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    DerObjectIdentifier oid = AnssiNamedCurves.GetOid(name);
    return oid != null ? AnssiNamedCurves.GetByOidLazy(oid) : (X9ECParametersHolder) null;
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return AnssiNamedCurves.GetByOidLazy(oid)?.Parameters;
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, X9ECParametersHolder>((IDictionary<DerObjectIdentifier, X9ECParametersHolder>) AnssiNamedCurves.curves, oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, string>((IDictionary<DerObjectIdentifier, string>) AnssiNamedCurves.names, oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) AnssiNamedCurves.objIds, name);
  }

  public static IEnumerable<string> Names
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) AnssiNamedCurves.objIds.Keys);
  }

  internal class Frp256v1Holder : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new AnssiNamedCurves.Frp256v1Holder();

    private Frp256v1Holder()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = AnssiNamedCurves.FromHex("F1FD178C0B3AD58F10126DE8CE42435B3961ADBCABC8CA6DE8FCF353D86E9C03");
      BigInteger bigInteger1 = AnssiNamedCurves.FromHex("F1FD178C0B3AD58F10126DE8CE42435B3961ADBCABC8CA6DE8FCF353D86E9C00");
      BigInteger bigInteger2 = AnssiNamedCurves.FromHex("EE353FCA5428A9300D4ABA754A44C00FDFEC0C9AE4B1A1803075ED967B7BB73F");
      BigInteger bigInteger3 = AnssiNamedCurves.FromHex("F1FD178C0B3AD58F10126DE8CE42435B53DC67E140D2BF941FFDD459C6D655E1");
      BigInteger one = BigInteger.One;
      BigInteger a = bigInteger1;
      BigInteger b = bigInteger2;
      BigInteger order = bigInteger3;
      BigInteger cofactor = one;
      return AnssiNamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, cofactor, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = AnssiNamedCurves.ConfigureBasepoint(curve, "04B6B3D4C356C139EB31183D4749D423958C27D2DCAF98B70164C97A2DD98F5CFF6142E0F7C8B204911F9271F0F3ECEF8C2701C307E8E4C9E183115A1554062CFB");
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }
}
