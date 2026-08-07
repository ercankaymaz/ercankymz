// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Operators.KeyWrapperUtil
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1.Nist;
using Org.BouncyCastle.Asn1.Oiw;
using System;
using System.Collections.Generic;

#nullable disable
namespace Org.BouncyCastle.Crypto.Operators;

internal class KeyWrapperUtil
{
  private static readonly Dictionary<string, WrapperProvider> m_providerMap = new Dictionary<string, WrapperProvider>((IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase);

  static KeyWrapperUtil()
  {
    KeyWrapperUtil.m_providerMap.Add("RSA/ECB/PKCS1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/PKCS1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA1ANDMGF1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(OiwObjectIdentifiers.IdSha1));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA224ANDMGF1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha224));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA256ANDMGF1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha256));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA384ANDMGF1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha384));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA512ANDMGF1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha512));
    KeyWrapperUtil.m_providerMap.Add("RSA/NONE/OAEPWITHSHA256ANDMGF1WITHSHA1PADDING", (WrapperProvider) new RsaOaepWrapperProvider(NistObjectIdentifiers.IdSha256, OiwObjectIdentifiers.IdSha1));
  }

  public static IKeyWrapper WrapperForName(string algorithm, ICipherParameters parameters)
  {
    WrapperProvider wrapperProvider;
    if (!KeyWrapperUtil.m_providerMap.TryGetValue(algorithm, out wrapperProvider))
      throw new ArgumentException($"could not resolve {algorithm} to a KeyWrapper");
    return (IKeyWrapper) wrapperProvider.CreateWrapper(true, parameters);
  }

  public static IKeyUnwrapper UnwrapperForName(string algorithm, ICipherParameters parameters)
  {
    WrapperProvider wrapperProvider;
    if (!KeyWrapperUtil.m_providerMap.TryGetValue(algorithm, out wrapperProvider))
      throw new ArgumentException($"could not resolve {algorithm} to a KeyUnwrapper");
    return (IKeyUnwrapper) wrapperProvider.CreateWrapper(false, parameters);
  }
}
