// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cms.CmsPbeKey
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Pkcs;
using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Cms;

public abstract class CmsPbeKey : ICipherParameters
{
  internal readonly char[] password;
  internal readonly byte[] salt;
  internal readonly int iterationCount;

  public CmsPbeKey(char[] password, byte[] salt, int iterationCount)
  {
    this.password = (char[]) password.Clone();
    this.salt = Arrays.Clone(salt);
    this.iterationCount = iterationCount;
  }

  public CmsPbeKey(char[] password, AlgorithmIdentifier keyDerivationAlgorithm)
  {
    if (!keyDerivationAlgorithm.Algorithm.Equals((Asn1Object) PkcsObjectIdentifiers.IdPbkdf2))
      throw new ArgumentException("Unsupported key derivation algorithm: " + keyDerivationAlgorithm.Algorithm?.ToString());
    Pbkdf2Params instance = Pbkdf2Params.GetInstance((object) keyDerivationAlgorithm.Parameters.ToAsn1Object());
    this.password = (char[]) password.Clone();
    this.salt = instance.GetSalt();
    this.iterationCount = instance.IterationCount.IntValue;
  }

  ~CmsPbeKey() => Array.Clear((Array) this.password, 0, this.password.Length);

  public byte[] Salt => Arrays.Clone(this.salt);

  public int IterationCount => this.iterationCount;

  public string Algorithm => "PKCS5S2";

  public string Format => "RAW";

  public byte[] GetEncoded() => (byte[]) null;

  internal abstract KeyParameter GetEncoded(string algorithmOid);
}
