// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Security.WrapperUtilities
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Kisa;
using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Nsri;
using Org.BouncyCastle.Asn1.Ntt;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Security;

public static class WrapperUtilities
{
  private static readonly IDictionary<string, string> Algorithms = (IDictionary<string, string>) new Dictionary<string, string>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static WrapperUtilities()
  {
    Enums.GetArbitraryValue<WrapperUtilities.WrapAlgorithm>().ToString();
    WrapperUtilities.Algorithms["AESKW"] = "AESWRAP";
    WrapperUtilities.Algorithms[NistObjectIdentifiers.IdAes128Wrap.Id] = "AESWRAP";
    WrapperUtilities.Algorithms[NistObjectIdentifiers.IdAes192Wrap.Id] = "AESWRAP";
    WrapperUtilities.Algorithms[NistObjectIdentifiers.IdAes256Wrap.Id] = "AESWRAP";
    WrapperUtilities.Algorithms["ARIAKW"] = "ARIAWRAP";
    WrapperUtilities.Algorithms[NsriObjectIdentifiers.id_aria128_kw.Id] = "ARIAWRAP";
    WrapperUtilities.Algorithms[NsriObjectIdentifiers.id_aria192_kw.Id] = "ARIAWRAP";
    WrapperUtilities.Algorithms[NsriObjectIdentifiers.id_aria256_kw.Id] = "ARIAWRAP";
    WrapperUtilities.Algorithms[NttObjectIdentifiers.IdCamellia128Wrap.Id] = "CAMELLIAWRAP";
    WrapperUtilities.Algorithms[NttObjectIdentifiers.IdCamellia192Wrap.Id] = "CAMELLIAWRAP";
    WrapperUtilities.Algorithms[NttObjectIdentifiers.IdCamellia256Wrap.Id] = "CAMELLIAWRAP";
    WrapperUtilities.Algorithms["DESEDERFC3217WRAP"] = "DESEDEWRAP";
    WrapperUtilities.Algorithms["TDEAWRAP"] = "DESEDEWRAP";
    WrapperUtilities.Algorithms[PkcsObjectIdentifiers.IdAlgCms3DesWrap.Id] = "DESEDEWRAP";
    WrapperUtilities.Algorithms[PkcsObjectIdentifiers.IdAlgCmsRC2Wrap.Id] = "RC2WRAP";
    WrapperUtilities.Algorithms["SEEDKW"] = "SEEDWRAP";
    WrapperUtilities.Algorithms[KisaObjectIdentifiers.IdNpkiAppCmsSeedWrap.Id] = "SEEDWRAP";
  }

  public static IWrapper GetWrapper(DerObjectIdentifier oid) => WrapperUtilities.GetWrapper(oid.Id);

  public static IWrapper GetWrapper(string algorithm)
  {
    string upperInvariant = CollectionUtilities.GetValueOrKey<string>(WrapperUtilities.Algorithms, algorithm).ToUpperInvariant();
    try
    {
      switch (Enums.GetEnumValue<WrapperUtilities.WrapAlgorithm>(upperInvariant))
      {
        case WrapperUtilities.WrapAlgorithm.AESRFC3211WRAP:
          return (IWrapper) new Rfc3211WrapEngine(AesUtilities.CreateEngine());
        case WrapperUtilities.WrapAlgorithm.AESWRAP:
          return (IWrapper) new AesWrapEngine();
        case WrapperUtilities.WrapAlgorithm.ARIARFC3211WRAP:
          return (IWrapper) new Rfc3211WrapEngine((IBlockCipher) new AriaEngine());
        case WrapperUtilities.WrapAlgorithm.ARIAWRAP:
          return (IWrapper) new AriaWrapEngine();
        case WrapperUtilities.WrapAlgorithm.CAMELLIARFC3211WRAP:
          return (IWrapper) new Rfc3211WrapEngine((IBlockCipher) new CamelliaEngine());
        case WrapperUtilities.WrapAlgorithm.CAMELLIAWRAP:
          return (IWrapper) new CamelliaWrapEngine();
        case WrapperUtilities.WrapAlgorithm.DESRFC3211WRAP:
          return (IWrapper) new Rfc3211WrapEngine((IBlockCipher) new DesEngine());
        case WrapperUtilities.WrapAlgorithm.DESEDERFC3211WRAP:
          return (IWrapper) new Rfc3211WrapEngine((IBlockCipher) new DesEdeEngine());
        case WrapperUtilities.WrapAlgorithm.DESEDEWRAP:
          return (IWrapper) new DesEdeWrapEngine();
        case WrapperUtilities.WrapAlgorithm.RC2WRAP:
          return (IWrapper) new RC2WrapEngine();
        case WrapperUtilities.WrapAlgorithm.SEEDWRAP:
          return (IWrapper) new SeedWrapEngine();
      }
    }
    catch (ArgumentException ex)
    {
    }
    return (IWrapper) new WrapperUtilities.BufferedCipherWrapper(CipherUtilities.GetCipher(algorithm) ?? throw new SecurityUtilityException($"Wrapper {algorithm} not recognised."));
  }

  public static string GetAlgorithmName(DerObjectIdentifier oid)
  {
    return CollectionUtilities.GetValueOrNull<string, string>(WrapperUtilities.Algorithms, oid.Id);
  }

  private enum WrapAlgorithm
  {
    AESRFC3211WRAP,
    AESWRAP,
    ARIARFC3211WRAP,
    ARIAWRAP,
    CAMELLIARFC3211WRAP,
    CAMELLIAWRAP,
    DESRFC3211WRAP,
    DESEDERFC3211WRAP,
    DESEDEWRAP,
    RC2WRAP,
    SEEDWRAP,
  }

  private class BufferedCipherWrapper : IWrapper
  {
    private readonly IBufferedCipher cipher;
    private bool forWrapping;

    public BufferedCipherWrapper(IBufferedCipher cipher) => this.cipher = cipher;

    public string AlgorithmName => this.cipher.AlgorithmName;

    public void Init(bool forWrapping, ICipherParameters parameters)
    {
      this.forWrapping = forWrapping;
      this.cipher.Init(forWrapping, parameters);
    }

    public byte[] Wrap(byte[] input, int inOff, int length)
    {
      if (!this.forWrapping)
        throw new InvalidOperationException("Not initialised for wrapping");
      return this.cipher.DoFinal(input, inOff, length);
    }

    public byte[] Unwrap(byte[] input, int inOff, int length)
    {
      if (this.forWrapping)
        throw new InvalidOperationException("Not initialised for unwrapping");
      return this.cipher.DoFinal(input, inOff, length);
    }
  }
}
