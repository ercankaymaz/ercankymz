// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Saber.Symmetric
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Saber;

public abstract class Symmetric
{
  internal abstract void Hash_h(byte[] output, byte[] input, int outputOffset);

  internal abstract void Hash_g(byte[] output, byte[] input);

  internal abstract void Prf(byte[] output, byte[] input, int inLen, int outputLen);

  protected internal class ShakeSymmetric : Symmetric
  {
    private readonly Sha3Digest sha3Digest256;
    private readonly Sha3Digest sha3Digest512;
    private readonly IXof shakeDigest;

    internal ShakeSymmetric()
    {
      this.shakeDigest = (IXof) new ShakeDigest(128 /*0x80*/);
      this.sha3Digest256 = new Sha3Digest(256 /*0x0100*/);
      this.sha3Digest512 = new Sha3Digest(512 /*0x0200*/);
    }

    internal override void Hash_h(byte[] output, byte[] input, int outputOffset)
    {
      this.sha3Digest256.BlockUpdate(input, 0, input.Length);
      this.sha3Digest256.DoFinal(output, outputOffset);
    }

    internal override void Hash_g(byte[] output, byte[] input)
    {
      this.sha3Digest512.BlockUpdate(input, 0, input.Length);
      this.sha3Digest512.DoFinal(output, 0);
    }

    internal override void Prf(byte[] output, byte[] input, int inLen, int outputLen)
    {
      this.shakeDigest.Reset();
      this.shakeDigest.BlockUpdate(input, 0, inLen);
      this.shakeDigest.OutputFinal(output, 0, outputLen);
    }
  }

  internal class AesSymmetric : Symmetric
  {
    private readonly Sha256Digest sha256Digest;
    private readonly Sha512Digest sha512Digest;
    private readonly SicBlockCipher cipher;

    protected internal AesSymmetric()
    {
      this.sha256Digest = new Sha256Digest();
      this.sha512Digest = new Sha512Digest();
      this.cipher = new SicBlockCipher(AesUtilities.CreateEngine());
    }

    internal override void Hash_h(byte[] output, byte[] input, int outputOffset)
    {
      this.sha256Digest.BlockUpdate(input, 0, input.Length);
      this.sha256Digest.DoFinal(output, outputOffset);
    }

    internal override void Hash_g(byte[] output, byte[] input)
    {
      this.sha512Digest.BlockUpdate(input, 0, input.Length);
      this.sha512Digest.DoFinal(output, 0);
    }

    internal override void Prf(byte[] output, byte[] input, int inLen, int outputLen)
    {
      this.cipher.Init(true, (ICipherParameters) new ParametersWithIV((ICipherParameters) new KeyParameter(input, 0, inLen), new byte[16 /*0x10*/]));
      byte[] input1 = new byte[outputLen];
      for (int index = 0; index < outputLen; index += 16 /*0x10*/)
        this.cipher.ProcessBlock(input1, index, output, index);
    }
  }
}
