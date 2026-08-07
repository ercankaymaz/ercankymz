// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.CryptoPro.ECGost3410NamedCurves
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Rosstandart;
using Org.BouncyCastle.Asn1.X9;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Math.EC;
using Org.BouncyCastle.Math.EC.Multiplier;
using Org.BouncyCastle.Utilities.Collections;
using Org.BouncyCastle.Utilities.Encoders;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Asn1.CryptoPro;

public static class ECGost3410NamedCurves
{
  private static readonly Dictionary<string, DerObjectIdentifier> objIds = new Dictionary<string, DerObjectIdentifier>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);
  private static readonly Dictionary<DerObjectIdentifier, X9ECParametersHolder> curves = new Dictionary<DerObjectIdentifier, X9ECParametersHolder>();
  private static readonly Dictionary<DerObjectIdentifier, string> names = new Dictionary<DerObjectIdentifier, string>();

  private static X9ECPoint ConfigureBasepoint(ECCurve curve, BigInteger x, BigInteger y)
  {
    ECPoint point = curve.CreatePoint(x, y);
    WNafUtilities.ConfigureBasepoint(point);
    return new X9ECPoint(point, false);
  }

  private static ECCurve ConfigureCurve(ECCurve curve) => curve;

  private static BigInteger FromHex(string hex) => new BigInteger(1, Hex.DecodeStrict(hex));

  private static void DefineCurve(
    string name,
    DerObjectIdentifier oid,
    X9ECParametersHolder holder)
  {
    ECGost3410NamedCurves.objIds.Add(name, oid);
    ECGost3410NamedCurves.names.Add(oid, name);
    ECGost3410NamedCurves.curves.Add(oid, holder);
  }

  static ECGost3410NamedCurves()
  {
    ECGost3410NamedCurves.DefineCurve("GostR3410-2001-CryptoPro-A", CryptoProObjectIdentifiers.GostR3410x2001CryptoProA, ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_A.Instance);
    ECGost3410NamedCurves.DefineCurve("GostR3410-2001-CryptoPro-B", CryptoProObjectIdentifiers.GostR3410x2001CryptoProB, ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_B.Instance);
    ECGost3410NamedCurves.DefineCurve("GostR3410-2001-CryptoPro-C", CryptoProObjectIdentifiers.GostR3410x2001CryptoProC, ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_C.Instance);
    ECGost3410NamedCurves.DefineCurve("GostR3410-2001-CryptoPro-XchA", CryptoProObjectIdentifiers.GostR3410x2001CryptoProXchA, ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_A.Instance);
    ECGost3410NamedCurves.DefineCurve("GostR3410-2001-CryptoPro-XchB", CryptoProObjectIdentifiers.GostR3410x2001CryptoProXchB, ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_XchB.Instance);
    ECGost3410NamedCurves.DefineCurve("Tc26-Gost-3410-12-256-paramSetA", RosstandartObjectIdentifiers.id_tc26_gost_3410_12_256_paramSetA, ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_256_paramSetA.Instance);
    ECGost3410NamedCurves.DefineCurve("Tc26-Gost-3410-12-512-paramSetA", RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSetA, ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetA.Instance);
    ECGost3410NamedCurves.DefineCurve("Tc26-Gost-3410-12-512-paramSetB", RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSetB, ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetB.Instance);
    ECGost3410NamedCurves.DefineCurve("Tc26-Gost-3410-12-512-paramSetC", RosstandartObjectIdentifiers.id_tc26_gost_3410_12_512_paramSetC, ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetC.Instance);
  }

  public static X9ECParameters GetByName(string name)
  {
    DerObjectIdentifier oid = ECGost3410NamedCurves.GetOid(name);
    return oid != null ? ECGost3410NamedCurves.GetByOid(oid) : (X9ECParameters) null;
  }

  public static X9ECParametersHolder GetByNameLazy(string name)
  {
    DerObjectIdentifier oid = ECGost3410NamedCurves.GetOid(name);
    return oid != null ? ECGost3410NamedCurves.GetByOidLazy(oid) : (X9ECParametersHolder) null;
  }

  public static X9ECParameters GetByOid(DerObjectIdentifier oid)
  {
    return ECGost3410NamedCurves.GetByOidLazy(oid)?.Parameters;
  }

  public static X9ECParametersHolder GetByOidLazy(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, X9ECParametersHolder>((IDictionary<DerObjectIdentifier, X9ECParametersHolder>) ECGost3410NamedCurves.curves, oid);
  }

  public static string GetName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<DerObjectIdentifier, string>((IDictionary<DerObjectIdentifier, string>) ECGost3410NamedCurves.names, oid);
  }

  public static DerObjectIdentifier GetOid(string name)
  {
    return CollectionUtilities.GetValueOrNull<string, DerObjectIdentifier>((IDictionary<string, DerObjectIdentifier>) ECGost3410NamedCurves.objIds, name);
  }

  public static IEnumerable<string> Names
  {
    get
    {
      return CollectionUtilities.Proxy<string>((IEnumerable<string>) ECGost3410NamedCurves.objIds.Keys);
    }
  }

  internal class Holder_gostR3410_2001_CryptoPro_A : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_A();

    private Holder_gostR3410_2001_CryptoPro_A()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD97");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF6C611070995AD10045841B09B761B893");
      BigInteger a = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD94");
      BigInteger b = ECGost3410NamedCurves.FromHex("A6");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.One, ECGost3410NamedCurves.FromHex("8D91E471E0989CDA27DF505A453F2B7635294F2DDF23E3B122ACC99C9E9F1E14"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_gostR3410_2001_CryptoPro_B : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_B();

    private Holder_gostR3410_2001_CryptoPro_B()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("8000000000000000000000000000000000000000000000000000000000000C99");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("800000000000000000000000000000015F700CFFF1A624E5E497161BCC8A198F");
      BigInteger a = ECGost3410NamedCurves.FromHex("8000000000000000000000000000000000000000000000000000000000000C96");
      BigInteger b = ECGost3410NamedCurves.FromHex("3E1AF419A269A5F866A7D3C25C3DF80AE979259373FF2B182F49D4CE7E1BBC8B");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.One, ECGost3410NamedCurves.FromHex("3FA8124359F96680B83D1C3EB2C070E5C545C9858D03ECFB744BF8D717717EFC"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_gostR3410_2001_CryptoPro_C : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_C();

    private Holder_gostR3410_2001_CryptoPro_C()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AACF846E86789051D37998F7B9022D759B");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AA582CA3511EDDFB74F02F3A6598980BB9");
      BigInteger a = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AACF846E86789051D37998F7B9022D7598");
      BigInteger b = ECGost3410NamedCurves.FromHex("805A");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.Zero, ECGost3410NamedCurves.FromHex("41ECE55743711A8C3CBF3783CD08C0EE4D4DC440D4641A8F366E550DFDB3BB67"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_gostR3410_2001_CryptoPro_XchB : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_gostR3410_2001_CryptoPro_XchB();

    private Holder_gostR3410_2001_CryptoPro_XchB()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AACF846E86789051D37998F7B9022D759B");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AA582CA3511EDDFB74F02F3A6598980BB9");
      BigInteger a = ECGost3410NamedCurves.FromHex("9B9F605F5A858107AB1EC85E6B41C8AACF846E86789051D37998F7B9022D7598");
      BigInteger b = ECGost3410NamedCurves.FromHex("805A");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.Zero, ECGost3410NamedCurves.FromHex("41ECE55743711A8C3CBF3783CD08C0EE4D4DC440D4641A8F366E550DFDB3BB67"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_id_tc26_gost_3410_12_256_paramSetA : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_256_paramSetA();

    private Holder_id_tc26_gost_3410_12_256_paramSetA()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFD97");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("400000000000000000000000000000000FD8CDDFC87B6635C115AF556C360C67");
      BigInteger a = ECGost3410NamedCurves.FromHex("C2173F1513981673AF4892C23035A27CE25E2013BF95AA33B22C656F277E7335");
      BigInteger b = ECGost3410NamedCurves.FromHex("295F9BAE7428ED9CCC20E7C359A9D41A22FCCD9108E17BF7BA9337A6F8AE9513");
      BigInteger order = bigInteger;
      BigInteger four = BigInteger.Four;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, four, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, ECGost3410NamedCurves.FromHex("91E38443A5E82C0D880923425712B2BB658B9196932E02C78B2582FE742DAA28"), ECGost3410NamedCurves.FromHex("32879423AB1A0375895786C4BB46E9565FDE0B5344766740AF268ADB32322E5C"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_id_tc26_gost_3410_12_512_paramSetA : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetA();

    private Holder_id_tc26_gost_3410_12_512_paramSetA()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDC7");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF27E69532F48D89116FF22B8D4E0560609B4B38ABFAD2B85DCACDB1411F10B275");
      BigInteger a = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDC4");
      BigInteger b = ECGost3410NamedCurves.FromHex("E8C2505DEDFC86DDC1BD0B2B6667F1DA34B82574761CB0E879BD081CFD0B6265EE3CB090F30D27614CB4574010DA90DD862EF9D4EBEE4761503190785A71C760");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.Three, ECGost3410NamedCurves.FromHex("7503CFE87A836AE3A61B8816E25450E6CE5E1C93ACF1ABC1778064FDCBEFA921DF1626BE4FD036E93D75E6A50E3A41E98028FE5FC235F5B889A589CB5215F2A4"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_id_tc26_gost_3410_12_512_paramSetB : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetB();

    private Holder_id_tc26_gost_3410_12_512_paramSetB()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("8000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006F");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("800000000000000000000000000000000000000000000000000000000000000149A1EC142565A545ACFDB77BD9D40CFA8B996712101BEA0EC6346C54374F25BD");
      BigInteger a = ECGost3410NamedCurves.FromHex("8000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000006C");
      BigInteger b = ECGost3410NamedCurves.FromHex("687D1B459DC841457E3E06CF6F5E2517B97C7D614AF138BCBF85DC806C4B289F3E965D2DB1416D217F8B276FAD1AB69C50F78BEE1FA3106EFB8CCBC7C5140116");
      BigInteger order = bigInteger;
      BigInteger one = BigInteger.One;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, one, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, BigInteger.Two, ECGost3410NamedCurves.FromHex("1A8F7EDA389B094C2C071E3647A8940F3C123B697578C213BE6DD9E6C8EC7335DCB228FD1EDF4A39152CBCAAF8C0398828041055F94CEEEC7E21340780FE41BD"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }

  internal class Holder_id_tc26_gost_3410_12_512_paramSetC : X9ECParametersHolder
  {
    internal static readonly X9ECParametersHolder Instance = (X9ECParametersHolder) new ECGost3410NamedCurves.Holder_id_tc26_gost_3410_12_512_paramSetC();

    private Holder_id_tc26_gost_3410_12_512_paramSetC()
    {
    }

    protected override ECCurve CreateCurve()
    {
      BigInteger q = ECGost3410NamedCurves.FromHex("FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFDC7");
      BigInteger bigInteger = ECGost3410NamedCurves.FromHex("3FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFC98CDBA46506AB004C33A9FF5147502CC8EDA9E7A769A12694623CEF47F023ED");
      BigInteger a = ECGost3410NamedCurves.FromHex("DC9203E514A721875485A529D2C722FB187BC8980EB866644DE41C68E143064546E861C0E2C9EDD92ADE71F46FCF50FF2AD97F951FDA9F2A2EB6546F39689BD3");
      BigInteger b = ECGost3410NamedCurves.FromHex("B4C4EE28CEBC6C2C8AC12952CF37F16AC7EFB6A9F69F4B57FFDA2E4F0DE5ADE038CBC2FFF719D2C18DE0284B8BFEF3B52B8CC7A5F5BF0A3C8D2319A5312557E1");
      BigInteger order = bigInteger;
      BigInteger four = BigInteger.Four;
      return ECGost3410NamedCurves.ConfigureCurve((ECCurve) new FpCurve(q, a, b, order, four, true));
    }

    protected override X9ECParameters CreateParameters()
    {
      byte[] seed = (byte[]) null;
      ECCurve curve = this.Curve;
      X9ECPoint g = ECGost3410NamedCurves.ConfigureBasepoint(curve, ECGost3410NamedCurves.FromHex("E2E31EDFC23DE7BDEBE241CE593EF5DE2295B7A9CBAEF021D385F7074CEA043AA27272A7AE602BF2A7B9033DB9ED3610C6FB85487EAE97AAC5BC7928C1950148"), ECGost3410NamedCurves.FromHex("F5CE40D95B5EB899ABBCCFF5911CB8577939804D6527378B8C108C3D2090FF9BE18E2D33E3021ED2EF32D85822423B6304F726AA854BAE07D0396E9A9ADDC40F"));
      return new X9ECParameters(curve, g, curve.Order, curve.Cofactor, seed);
    }
  }
}
