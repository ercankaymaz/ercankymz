// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium.Symmetric
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Dilithium;

public abstract class Symmetric
{
  public int Stream128BlockBytes;
  public int Stream256BlockBytes;

  private Symmetric(int stream128, int stream256)
  {
    this.Stream128BlockBytes = stream128;
    this.Stream256BlockBytes = stream256;
  }

  internal abstract void Stream128Init(byte[] seed, ushort nonce);

  internal abstract void Stream256Init(byte[] seed, ushort nonce);

  internal abstract void Stream128SqueezeBlocks(byte[] output, int offset, int size);

  internal abstract void Stream256SqueezeBlocks(byte[] output, int offset, int size);

  internal class AesSymmetric : Symmetric
  {
    private SicBlockCipher cipher;

    public AesSymmetric()
      : base(64 /*0x40*/, 64 /*0x40*/)
    {
      this.cipher = new SicBlockCipher(AesUtilities.CreateEngine());
    }

    private void Aes128(byte[] output, int offset, int size)
    {
      byte[] input = new byte[size];
      for (int index = 0; index < size; index += 16 /*0x10*/)
        this.cipher.ProcessBlock(input, index + offset, output, index + offset);
    }

    private void StreamInit(byte[] key, ushort nonce)
    {
      byte[] iv = new byte[12];
      iv[0] = (byte) nonce;
      iv[1] = (byte) ((uint) nonce >> 8);
      this.cipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) new KeyParameter(key, 0, 32 /*0x20*/), iv));
    }

    internal override void Stream128Init(byte[] seed, ushort nonce) => this.StreamInit(seed, nonce);

    internal override void Stream256Init(byte[] seed, ushort nonce) => this.StreamInit(seed, nonce);

    internal override void Stream128SqueezeBlocks(byte[] output, int offset, int size)
    {
      this.Aes128(output, offset, size);
    }

    internal override void Stream256SqueezeBlocks(byte[] output, int offset, int size)
    {
      this.Aes128(output, offset, size);
    }
  }

  internal class ShakeSymmetric : Symmetric
  {
    private ShakeDigest digest128;
    private ShakeDigest digest256;

    public ShakeSymmetric()
      : base(168, 136)
    {
      this.digest128 = new ShakeDigest(128 /*0x80*/);
      this.digest256 = new ShakeDigest(256 /*0x0100*/);
    }

    private void StreamInit(ShakeDigest digest, byte[] seed, ushort nonce)
    {
      digest.Reset();
      byte[] input = new byte[2]
      {
        (byte) nonce,
        (byte) ((uint) nonce >> 8)
      };
      digest.BlockUpdate(seed, 0, seed.Length);
      digest.BlockUpdate(input, 0, input.Length);
    }

    internal override void Stream128Init(byte[] seed, ushort nonce)
    {
      this.StreamInit(this.digest128, seed, nonce);
    }

    internal override void Stream256Init(byte[] seed, ushort nonce)
    {
      this.StreamInit(this.digest256, seed, nonce);
    }

    internal override void Stream128SqueezeBlocks(byte[] output, int offset, int size)
    {
      this.digest128.Output(output, offset, size);
    }

    internal override void Stream256SqueezeBlocks(byte[] output, int offset, int size)
    {
      this.digest256.Output(output, offset, size);
    }
  }
}
