// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.OpenSslPbeParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class OpenSslPbeParametersGenerator : PbeParametersGenerator
{
  private readonly IDigest digest;

  public OpenSslPbeParametersGenerator()
    : this((IDigest) new MD5Digest())
  {
  }

  public OpenSslPbeParametersGenerator(IDigest digest) => this.digest = digest;

  public override void Init(byte[] password, byte[] salt, int iterationCount)
  {
    base.Init(password, salt, 1);
  }

  public virtual void Init(byte[] password, byte[] salt) => base.Init(password, salt, 1);

  private byte[] GenerateDerivedKey(int bytesNeeded)
  {
    byte[] numArray = new byte[this.digest.GetDigestSize()];
    byte[] destinationArray = new byte[bytesNeeded];
    int destinationIndex = 0;
    while (true)
    {
      this.digest.BlockUpdate(this.mPassword, 0, this.mPassword.Length);
      this.digest.BlockUpdate(this.mSalt, 0, this.mSalt.Length);
      this.digest.DoFinal(numArray, 0);
      int length = bytesNeeded > numArray.Length ? numArray.Length : bytesNeeded;
      Array.Copy((Array) numArray, 0, (Array) destinationArray, destinationIndex, length);
      destinationIndex += length;
      bytesNeeded -= length;
      if (bytesNeeded != 0)
      {
        this.digest.Reset();
        this.digest.BlockUpdate(numArray, 0, numArray.Length);
      }
      else
        break;
    }
    return destinationArray;
  }

  public override ICipherParameters GenerateDerivedParameters(string algorithm, int keySize)
  {
    keySize /= 8;
    byte[] derivedKey = this.GenerateDerivedKey(keySize);
    return (ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize);
  }

  public override ICipherParameters GenerateDerivedParameters(
    string algorithm,
    int keySize,
    int ivSize)
  {
    keySize /= 8;
    ivSize /= 8;
    byte[] derivedKey = this.GenerateDerivedKey(keySize + ivSize);
    return (ICipherParameters) new ParametersWithIV((ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize), derivedKey, keySize, ivSize);
  }

  public override ICipherParameters GenerateDerivedMacParameters(int keySize)
  {
    keySize /= 8;
    return (ICipherParameters) new KeyParameter(this.GenerateDerivedKey(keySize), 0, keySize);
  }
}
