// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Digests.Sha3Digest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Digests;

public class Sha3Digest : KeccakDigest
{
  internal static void CalculateDigest(
    ulong[] input,
    int inputOffset,
    int inputLengthBits,
    byte[] output,
    int outputOffset,
    int outputLengthBits)
  {
    int num1 = inputLengthBits + 63 /*0x3F*/ >> 6;
    Org.BouncyCastle.Crypto.Check.DataLength(inputOffset > input.Length - num1, "input buffer too short");
    int len1 = outputLengthBits + 7 >> 3;
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outputOffset, len1, "output buffer too short");
    if ((inputLengthBits & 7) != 0)
      throw new ArgumentOutOfRangeException(nameof (inputLengthBits));
    if (outputLengthBits <= 256 /*0x0100*/)
    {
      if (outputLengthBits == 224 /*0xE0*/ || outputLengthBits == 256 /*0x0100*/)
        goto label_7;
    }
    else if (outputLengthBits == 384 || outputLengthBits == 512 /*0x0200*/)
      goto label_7;
    throw new ArgumentOutOfRangeException(nameof (outputLengthBits));
label_7:
    int num2 = 1600 - (outputLengthBits << 1);
    int len2 = num2 >> 6;
    ulong[] numArray = new ulong[25];
    while (inputLengthBits >= num2)
    {
      Nat.XorTo64(len2, input, inputOffset, numArray, 0);
      inputOffset += len2;
      inputLengthBits -= num2;
      KeccakDigest.KeccakPermutation(numArray);
    }
    int len3 = inputLengthBits >> 6;
    int num3 = inputLengthBits & 63 /*0x3F*/;
    Nat.XorTo64(len3, input, inputOffset, numArray, 0);
    ulong num4 = 6;
    if (num3 != 0)
      num4 = num4 << num3 | input[inputOffset + len3] & (ulong) ~(-1L << num3);
    numArray[len3] ^= num4;
    numArray[len2 - 1] ^= 9223372036854775808UL /*0x8000000000000000*/;
    KeccakDigest.KeccakPermutation(numArray);
    int nsLen = outputLengthBits >> 6;
    Pack.UInt64_To_LE(numArray, 0, nsLen, output, outputOffset);
    if ((outputLengthBits & 32 /*0x20*/) == 0)
      return;
    Pack.UInt32_To_LE((uint) numArray[nsLen], output, outputOffset + (nsLen << 3));
  }

  private static int CheckBitLength(int bitLength)
  {
    if (bitLength <= 256 /*0x0100*/)
    {
      if (bitLength == 224 /*0xE0*/ || bitLength == 256 /*0x0100*/)
        goto label_4;
    }
    else if (bitLength == 384 || bitLength == 512 /*0x0200*/)
      goto label_4;
    throw new ArgumentException(bitLength.ToString() + " not supported for SHA-3", nameof (bitLength));
label_4:
    return bitLength;
  }

  public Sha3Digest()
    : this(256 /*0x0100*/)
  {
  }

  public Sha3Digest(int bitLength)
    : base(Sha3Digest.CheckBitLength(bitLength))
  {
  }

  public Sha3Digest(Sha3Digest source)
    : base((KeccakDigest) source)
  {
  }

  public override string AlgorithmName => "SHA3-" + this.fixedOutputLength.ToString();

  public override int DoFinal(byte[] output, int outOff)
  {
    this.AbsorbBits(2, 2);
    return base.DoFinal(output, outOff);
  }

  protected override int DoFinal(byte[] output, int outOff, byte partialByte, int partialBits)
  {
    if (partialBits < 0 || partialBits > 7)
      throw new ArgumentException("must be in the range [0,7]", nameof (partialBits));
    int num = (int) partialByte & (1 << partialBits) - 1 | 2 << partialBits;
    int partialBits1 = partialBits + 2;
    if (partialBits1 >= 8)
    {
      this.Absorb((byte) num);
      partialBits1 -= 8;
      num >>= 8;
    }
    return base.DoFinal(output, outOff, (byte) num, partialBits1);
  }

  public override IMemoable Copy() => (IMemoable) new Sha3Digest(this);
}
