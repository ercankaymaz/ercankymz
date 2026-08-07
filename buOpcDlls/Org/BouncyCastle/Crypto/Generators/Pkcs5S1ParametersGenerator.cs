// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Pkcs5S1ParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class Pkcs5S1ParametersGenerator : PbeParametersGenerator
{
  private readonly IDigest digest;

  public Pkcs5S1ParametersGenerator(IDigest digest) => this.digest = digest;

  private byte[] GenerateDerivedKey()
  {
    byte[] derivedKey = new byte[this.digest.GetDigestSize()];
    this.digest.BlockUpdate(this.mPassword, 0, this.mPassword.Length);
    this.digest.BlockUpdate(this.mSalt, 0, this.mSalt.Length);
    this.digest.DoFinal(derivedKey, 0);
    for (int index = 1; index < this.mIterationCount; ++index)
    {
      this.digest.BlockUpdate(derivedKey, 0, derivedKey.Length);
      this.digest.DoFinal(derivedKey, 0);
    }
    return derivedKey;
  }

  public override ICipherParameters GenerateDerivedParameters(string algorithm, int keySize)
  {
    keySize /= 8;
    if (keySize > this.digest.GetDigestSize())
      throw new ArgumentException($"Can't Generate a derived key {keySize.ToString()} bytes long.");
    byte[] derivedKey = this.GenerateDerivedKey();
    return (ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize);
  }

  public override ICipherParameters GenerateDerivedParameters(
    string algorithm,
    int keySize,
    int ivSize)
  {
    keySize /= 8;
    ivSize /= 8;
    if (keySize + ivSize > this.digest.GetDigestSize())
      throw new ArgumentException($"Can't Generate a derived key {(keySize + ivSize).ToString()} bytes long.");
    byte[] derivedKey = this.GenerateDerivedKey();
    return (ICipherParameters) new ParametersWithIV((ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize), derivedKey, keySize, ivSize);
  }

  public override ICipherParameters GenerateDerivedMacParameters(int keySize)
  {
    keySize /= 8;
    return keySize <= this.digest.GetDigestSize() ? (ICipherParameters) new KeyParameter(this.GenerateDerivedKey(), 0, keySize) : throw new ArgumentException($"Can't Generate a derived key {keySize.ToString()} bytes long.");
  }
}
