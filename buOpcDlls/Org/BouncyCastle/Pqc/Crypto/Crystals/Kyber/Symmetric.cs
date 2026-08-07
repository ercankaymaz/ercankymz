// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.Symmetric
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

public abstract class Symmetric
{
  internal readonly int XofBlockBytes;

  internal abstract void Hash_h(byte[] output, byte[] input, int outOffset);

  internal abstract void Hash_g(byte[] output, byte[] input);

  internal abstract void XofAbsorb(byte[] seed, byte x, byte y);

  internal abstract void XofSqueezeBlocks(byte[] output, int outOffset, int outLen);

  internal abstract void Prf(byte[] output, byte[] key, byte nonce);

  internal abstract void Kdf(byte[] output, byte[] input);

  private Symmetric(int xofBlockBytes) => this.XofBlockBytes = xofBlockBytes;

  internal class ShakeSymmetric : Symmetric
  {
    private ShakeDigest xof;
    private Sha3Digest sha3Digest512;
    private Sha3Digest sha3Digest256;
    private ShakeDigest shakeDigest;

    internal ShakeSymmetric()
      : base(164)
    {
      this.xof = new ShakeDigest(128 /*0x80*/);
      this.shakeDigest = new ShakeDigest(256 /*0x0100*/);
      this.sha3Digest256 = new Sha3Digest(256 /*0x0100*/);
      this.sha3Digest512 = new Sha3Digest(512 /*0x0200*/);
    }

    internal override void Hash_h(byte[] output, byte[] input, int outOffset)
    {
      this.sha3Digest256.BlockUpdate(input, 0, input.Length);
      this.sha3Digest256.DoFinal(output, outOffset);
    }

    internal override void Hash_g(byte[] output, byte[] input)
    {
      this.sha3Digest512.BlockUpdate(input, 0, input.Length);
      this.sha3Digest512.DoFinal(output, 0);
    }

    internal override void XofAbsorb(byte[] seed, byte x, byte y)
    {
      this.xof.Reset();
      byte[] numArray = new byte[seed.Length + 2];
      Array.Copy((Array) seed, 0, (Array) numArray, 0, seed.Length);
      numArray[seed.Length] = x;
      numArray[seed.Length + 1] = y;
      this.xof.BlockUpdate(numArray, 0, seed.Length + 2);
    }

    internal override void XofSqueezeBlocks(byte[] output, int outOffset, int outLen)
    {
      this.xof.Output(output, outOffset, outLen);
    }

    internal override void Prf(byte[] output, byte[] seed, byte nonce)
    {
      byte[] numArray = new byte[seed.Length + 1];
      Array.Copy((Array) seed, 0, (Array) numArray, 0, seed.Length);
      numArray[seed.Length] = nonce;
      this.shakeDigest.BlockUpdate(numArray, 0, numArray.Length);
      this.shakeDigest.OutputFinal(output, 0, output.Length);
    }

    internal override void Kdf(byte[] output, byte[] input)
    {
      this.shakeDigest.BlockUpdate(input, 0, input.Length);
      this.shakeDigest.OutputFinal(output, 0, output.Length);
    }
  }

  internal class AesSymmetric : Symmetric
  {
    private Sha256Digest sha256Digest;
    private Sha512Digest sha512Digest;
    private SicBlockCipher cipher;

    internal AesSymmetric()
      : base(64 /*0x40*/)
    {
      this.sha256Digest = new Sha256Digest();
      this.sha512Digest = new Sha512Digest();
      this.cipher = new SicBlockCipher(AesUtilities.CreateEngine());
    }

    private void DoDigest(IDigest digest, byte[] output, byte[] input, int outOffset)
    {
      digest.BlockUpdate(input, 0, input.Length);
      digest.DoFinal(output, outOffset);
    }

    private void Aes128(byte[] output, int offset, int size)
    {
      byte[] input = new byte[size + offset];
      for (int index = 0; index < size; index += 16 /*0x10*/)
        this.cipher.ProcessBlock(input, index + offset, output, index + offset);
    }

    internal override void Hash_h(byte[] output, byte[] input, int outOffset)
    {
      this.DoDigest((IDigest) this.sha256Digest, output, input, outOffset);
    }

    internal override void Hash_g(byte[] output, byte[] input)
    {
      this.DoDigest((IDigest) this.sha512Digest, output, input, 0);
    }

    internal override void XofAbsorb(byte[] key, byte x, byte y)
    {
      byte[] iv = new byte[12];
      iv[0] = x;
      iv[1] = y;
      this.cipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) new KeyParameter(key, 0, 32 /*0x20*/), iv));
    }

    internal override void XofSqueezeBlocks(byte[] output, int outOffset, int outLen)
    {
      this.Aes128(output, outOffset, outLen);
    }

    internal override void Prf(byte[] output, byte[] key, byte nonce)
    {
      byte[] iv = new byte[12];
      iv[0] = nonce;
      this.cipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) new KeyParameter(key, 0, 32 /*0x20*/), iv));
      this.Aes128(output, 0, output.Length);
    }

    internal override void Kdf(byte[] output, byte[] input)
    {
      byte[] numArray = new byte[32 /*0x20*/];
      this.DoDigest((IDigest) this.sha256Digest, numArray, input, 0);
      Array.Copy((Array) numArray, 0, (Array) output, 0, output.Length);
    }
  }
}
