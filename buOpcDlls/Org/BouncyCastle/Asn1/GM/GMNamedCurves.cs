// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.GM.GMNamedCurves
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
namespace Org.BouncyCastle.Asn1.GM;

public static class GMNamedCurves
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
    GMNamedCurves.objIds.Add(name, oid);
    GMNamedCurves.names.Add(oid, name);
    GMNamedCurves.curves.Add(oid, holder);
  }

  static GMNamedCurves()
  {
    GMNamedCurves.DefineCurve("wapip192v1", GMObjectIdentifiers.wapip192v1, GMNamedCurves.WapiP192V1Holder.Instance);
    GMNamedCurves.DefineCurve("sm2p256v1", GMObjectIdentifiers.sm2p256v1, GMNamedCurves.SM2P256V1Holder.Instance);
  }

  public static X9ECParameters GetByName(string name)
  {
    DerObjectIdentifier oid = GMNamedCurves.GetOid(name);
    return oid != null ? GMNamedCurves.GetByOid(oid) : (X9ECParameters) null;
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    DerObjectIdentifier oid = GMNamedCurves.GetOid(name);
    return oid != null ? GMNamedCurves.GetByOidLazy(oid) : (X9ECParametersHolder) null;
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return GMNamedCurves.GetByOidLazy(oid)?.Parameters;
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, X9ECParametersHolder>((IDictionary<DerObjectIdentifier, X9ECParametersHolder>) GMNamedCurves.curves, oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, string>((IDictionary<DerObjectIdentifier, string>) GMNamedCurves.names, oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) GMNamedCurves.objIds, name);
  }

  public static IEnumerable<string> Names
  {
    get => CollectionUtilities.Proxy<string>((IEnumerable<string>) GMNamedCurves.objIds.Keys);
  }

  internal class SM2P256V1Holder : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new GMNamedCurves.SM2P256V1Holder();

    private SM2P256V1Holder()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = GMNamedCurves.FromHex("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFF");
      BigInteger bigInteger1 = GMNamedCurves.FromHex("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF00000000FFFFFFFFFFFFFFFC");
      BigInteger bigInteger2 = GMNamedCurves.FromHex("28E9FA9E9D9F5E344D5A9E4BCF6509A7F39789F515AB8F92DDBCBD414D940E93");
      BigInteger bigInteger3 = GMNamedCurves.FromHex("FFFFFFFEFFFFFFFFFFFFFFFFFFFFFFFF7203DF6B21C6052B53BBF40939D54123");
      BigInteger one = BigInteger.One;
      BigInteger a = bigInteger1;
      BigInteger b = bigInteger2;
      BigInteger order = bigInteger3;
      BigInteger cofactor = one;
      return GMNamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, cofactor, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = GMNamedCurves.ConfigureBasepoint(curve, "0432C4AE2C1F1981195F9904466A39C9948FE30BBFF2660BE1715A4589334C74C7BC3736A2F4F6779C59BDCEE36B692153D0A9877CC62A474002DF32E52139F0A0");
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class WapiP192V1Holder : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new GMNamedCurves.WapiP192V1Holder();

    private WapiP192V1Holder()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = GMNamedCurves.FromHex("BDB6F4FE3E8B1D9E0DA8C0D46F4C318CEFE4AFE3B6B8551F");
      BigInteger bigInteger1 = GMNamedCurves.FromHex("BB8E5E8FBC115E139FE6A814FE48AAA6F0ADA1AA5DF91985");
      BigInteger bigInteger2 = GMNamedCurves.FromHex("1854BEBDC31B21B7AEFC80AB0ECD10D5B1B3308E6DBF11C1");
      BigInteger bigInteger3 = GMNamedCurves.FromHex("BDB6F4FE3E8B1D9E0DA8C0D40FC962195DFAE76F56564677");
      BigInteger one = BigInteger.One;
      BigInteger a = bigInteger1;
      BigInteger b = bigInteger2;
      BigInteger order = bigInteger3;
      BigInteger cofactor = one;
      return GMNamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, cofactor, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = GMNamedCurves.ConfigureBasepoint(curve, "044AD5F7048DE709AD51236DE65E4D4B482C836DC6E410664002BB3A02D4AAADACAE24817A4CA3A1B014B5270432DB27D2");
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }
}
