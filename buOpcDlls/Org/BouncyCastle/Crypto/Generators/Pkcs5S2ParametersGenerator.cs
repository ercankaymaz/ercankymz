// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Pkcs5S2ParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class Pkcs5S2ParametersGenerator : PbeParametersGenerator
{
  private readonly IMac hMac;
  private readonly byte[] state;

  public Pkcs5S2ParametersGenerator()
    : this((IDigest) new Sha1Digest())
  {
  }

  public Pkcs5S2ParametersGenerator(IDigest digest)
  {
    this.hMac = (IMac) new HMac(digest);
    this.state = new byte[this.hMac.GetMacSize()];
  }

  private void F(byte[] S, int c, byte[] iBuf, byte[] outBytes, int outOff)
  {
    if (c == 0)
      throw new ArgumentException("iteration count must be at least 1.");
    if (S != null)
      this.hMac.BlockUpdate(S, 0, S.Length);
    this.hMac.BlockUpdate(iBuf, 0, iBuf.Length);
    this.hMac.DoFinal(this.state, 0);
    Array.Copy((Array) this.state, 0, (Array) outBytes, outOff, this.state.Length);
    for (int index1 = 1; index1 < c; ++index1)
    {
      this.hMac.BlockUpdate(this.state, 0, this.state.Length);
      this.hMac.DoFinal(this.state, 0);
      for (int index2 = 0; index2 < this.state.Length; ++index2)
        outBytes[outOff + index2] ^= this.state[index2];
    }
  }

  private byte[] GenerateDerivedKey(int dkLen)
  {
    int macSize = this.hMac.GetMacSize();
    int num = (dkLen + macSize - 1) / macSize;
    byte[] iBuf = new byte[4];
    byte[] outBytes = new byte[num * macSize];
    int outOff = 0;
    this.hMac.Init((ICipherParameters) new KeyParameter(this.mPassword));
    for (int index1 = 1; index1 <= num; ++index1)
    {
      int index2 = 3;
      while (++iBuf[index2] == (byte) 0)
        --index2;
      this.F(this.mSalt, this.mIterationCount, iBuf, outBytes, outOff);
      outOff += macSize;
    }
    return outBytes;
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
