// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.PicnicEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Math.Raw;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal sealed class PicnicEngine
{
  internal static readonly int saltSizeBytes = 32 /*0x20*/;
  private static readonly uint MAX_DIGEST_SIZE = 64 /*0x40*/;
  private static readonly int WORD_SIZE_BITS = 32 /*0x20*/;
  private static readonly uint LOWMC_MAX_STATE_SIZE = 64 /*0x40*/;
  internal static readonly uint LOWMC_MAX_WORDS = PicnicEngine.LOWMC_MAX_STATE_SIZE / 4U;
  internal static readonly uint LOWMC_MAX_KEY_BITS = 256 /*0x0100*/;
  internal static readonly uint LOWMC_MAX_AND_GATES = 1144;
  private static readonly uint MAX_AUX_BYTES = (PicnicEngine.LOWMC_MAX_AND_GATES + PicnicEngine.LOWMC_MAX_KEY_BITS) / 8U + 1U;
  private static readonly uint PICNIC_MAX_LOWMC_BLOCK_SIZE = 32 /*0x20*/;
  private static readonly uint PICNIC_MAX_PUBLICKEY_SIZE = (uint) (2 * (int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE + 1);
  private static readonly uint PICNIC_MAX_PRIVATEKEY_SIZE = (uint) (3 * (int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE + 2);
  private static readonly uint TRANSFORM_FS = 0;
  private static readonly uint TRANSFORM_UR = 1;
  private static readonly uint TRANSFORM_INVALID = (uint) byte.MaxValue;
  private int CRYPTO_SECRETKEYBYTES;
  private int CRYPTO_PUBLICKEYBYTES;
  private int CRYPTO_BYTES;
  internal int numRounds;
  private int numSboxes;
  internal int stateSizeBits;
  internal int stateSizeBytes;
  internal int stateSizeWords;
  internal int andSizeBytes;
  private int UnruhGWithoutInputBytes;
  internal int UnruhGWithInputBytes;
  internal int numMPCRounds;
  internal int numOpenedRounds;
  internal int numMPCParties;
  internal int seedSizeBytes;
  internal int digestSizeBytes;
  internal int pqSecurityLevel;
  private uint transform;
  private int parameters;
  internal IXof digest;
  private int signatureLength;
  internal LowmcConstants _lowmcConstants;

  internal int GetSecretKeySize() => this.CRYPTO_SECRETKEYBYTES;

  internal int GetPublicKeySize() => this.CRYPTO_PUBLICKEYBYTES;

  internal int GetSignatureSize(int messageLength) => this.CRYPTO_BYTES + messageLength;

  internal int GetTrueSignatureSize() => this.signatureLength + 4;

  internal PicnicEngine(int picnicParams, LowmcConstants lowmcConstants)
  {
    this._lowmcConstants = lowmcConstants;
    this.parameters = picnicParams;
    switch (this.parameters)
    {
      case 1:
      case 2:
        this.pqSecurityLevel = 64 /*0x40*/;
        this.stateSizeBits = 128 /*0x80*/;
        this.numMPCRounds = 219;
        this.numMPCParties = 3;
        this.numSboxes = 10;
        this.numRounds = 20;
        this.digestSizeBytes = 32 /*0x20*/;
        break;
      case 3:
      case 4:
        this.pqSecurityLevel = 96 /*0x60*/;
        this.stateSizeBits = 192 /*0xC0*/;
        this.numMPCRounds = 329;
        this.numMPCParties = 3;
        this.numSboxes = 10;
        this.numRounds = 30;
        this.digestSizeBytes = 48 /*0x30*/;
        break;
      case 5:
      case 6:
        this.pqSecurityLevel = 128 /*0x80*/;
        this.stateSizeBits = 256 /*0x0100*/;
        this.numMPCRounds = 438;
        this.numMPCParties = 3;
        this.numSboxes = 10;
        this.numRounds = 38;
        this.digestSizeBytes = 64 /*0x40*/;
        break;
      case 7:
        this.pqSecurityLevel = 64 /*0x40*/;
        this.stateSizeBits = 129;
        this.numMPCRounds = 250;
        this.numOpenedRounds = 36;
        this.numMPCParties = 16 /*0x10*/;
        this.numSboxes = 43;
        this.numRounds = 4;
        this.digestSizeBytes = 32 /*0x20*/;
        break;
      case 8:
        this.pqSecurityLevel = 96 /*0x60*/;
        this.stateSizeBits = 192 /*0xC0*/;
        this.numMPCRounds = 419;
        this.numOpenedRounds = 52;
        this.numMPCParties = 16 /*0x10*/;
        this.numSboxes = 64 /*0x40*/;
        this.numRounds = 4;
        this.digestSizeBytes = 48 /*0x30*/;
        break;
      case 9:
        this.pqSecurityLevel = 128 /*0x80*/;
        this.stateSizeBits = (int) byte.MaxValue;
        this.numMPCRounds = 601;
        this.numOpenedRounds = 68;
        this.numMPCParties = 16 /*0x10*/;
        this.numSboxes = 85;
        this.numRounds = 4;
        this.digestSizeBytes = 64 /*0x40*/;
        break;
      case 10:
        this.pqSecurityLevel = 64 /*0x40*/;
        this.stateSizeBits = 129;
        this.numMPCRounds = 219;
        this.numMPCParties = 3;
        this.numSboxes = 43;
        this.numRounds = 4;
        this.digestSizeBytes = 32 /*0x20*/;
        break;
      case 11:
        this.pqSecurityLevel = 96 /*0x60*/;
        this.stateSizeBits = 192 /*0xC0*/;
        this.numMPCRounds = 329;
        this.numMPCParties = 3;
        this.numSboxes = 64 /*0x40*/;
        this.numRounds = 4;
        this.digestSizeBytes = 48 /*0x30*/;
        break;
      case 12:
        this.pqSecurityLevel = 128 /*0x80*/;
        this.stateSizeBits = (int) byte.MaxValue;
        this.numMPCRounds = 438;
        this.numMPCParties = 3;
        this.numSboxes = 85;
        this.numRounds = 4;
        this.digestSizeBytes = 64 /*0x40*/;
        break;
    }
    switch (this.parameters)
    {
      case 1:
        this.CRYPTO_SECRETKEYBYTES = 49;
        this.CRYPTO_PUBLICKEYBYTES = 33;
        this.CRYPTO_BYTES = 34036;
        break;
      case 2:
        this.CRYPTO_SECRETKEYBYTES = 49;
        this.CRYPTO_PUBLICKEYBYTES = 33;
        this.CRYPTO_BYTES = 53965;
        break;
      case 3:
        this.CRYPTO_SECRETKEYBYTES = 73;
        this.CRYPTO_PUBLICKEYBYTES = 49;
        this.CRYPTO_BYTES = 76784;
        break;
      case 4:
        this.CRYPTO_SECRETKEYBYTES = 73;
        this.CRYPTO_PUBLICKEYBYTES = 49;
        this.CRYPTO_BYTES = 121857;
        break;
      case 5:
        this.CRYPTO_SECRETKEYBYTES = 97;
        this.CRYPTO_PUBLICKEYBYTES = 65;
        this.CRYPTO_BYTES = 132876;
        break;
      case 6:
        this.CRYPTO_SECRETKEYBYTES = 97;
        this.CRYPTO_PUBLICKEYBYTES = 65;
        this.CRYPTO_BYTES = 209526;
        break;
      case 7:
        this.CRYPTO_SECRETKEYBYTES = 52;
        this.CRYPTO_PUBLICKEYBYTES = 35;
        this.CRYPTO_BYTES = 14612;
        break;
      case 8:
        this.CRYPTO_SECRETKEYBYTES = 73;
        this.CRYPTO_PUBLICKEYBYTES = 49;
        this.CRYPTO_BYTES = 35028;
        break;
      case 9:
        this.CRYPTO_SECRETKEYBYTES = 97;
        this.CRYPTO_PUBLICKEYBYTES = 65;
        this.CRYPTO_BYTES = 61028;
        break;
      case 10:
        this.CRYPTO_SECRETKEYBYTES = 52;
        this.CRYPTO_PUBLICKEYBYTES = 35;
        this.CRYPTO_BYTES = 32061;
        break;
      case 11:
        this.CRYPTO_SECRETKEYBYTES = 73;
        this.CRYPTO_PUBLICKEYBYTES = 49;
        this.CRYPTO_BYTES = 71179;
        break;
      case 12:
        this.CRYPTO_SECRETKEYBYTES = 97;
        this.CRYPTO_PUBLICKEYBYTES = 65;
        this.CRYPTO_BYTES = 126286;
        break;
      default:
        this.CRYPTO_SECRETKEYBYTES = -1;
        this.CRYPTO_PUBLICKEYBYTES = -1;
        this.CRYPTO_BYTES = -1;
        break;
    }
    this.andSizeBytes = PicnicUtilities.NumBytes(this.numSboxes * 3 * this.numRounds);
    this.stateSizeBytes = PicnicUtilities.NumBytes(this.stateSizeBits);
    this.seedSizeBytes = PicnicUtilities.NumBytes(2 * this.pqSecurityLevel);
    this.stateSizeWords = (this.stateSizeBits + PicnicEngine.WORD_SIZE_BITS - 1) / PicnicEngine.WORD_SIZE_BITS;
    switch (this.parameters)
    {
      case 1:
      case 3:
      case 5:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
        this.transform = PicnicEngine.TRANSFORM_FS;
        break;
      case 2:
      case 4:
      case 6:
        this.transform = PicnicEngine.TRANSFORM_UR;
        break;
      default:
        this.transform = PicnicEngine.TRANSFORM_INVALID;
        break;
    }
    if (this.transform == 1U)
    {
      this.UnruhGWithoutInputBytes = this.seedSizeBytes + this.andSizeBytes;
      this.UnruhGWithInputBytes = this.UnruhGWithoutInputBytes + this.stateSizeBytes;
    }
    this.digest = (IXof) new ShakeDigest(this.stateSizeBits == 128 /*0x80*/ || this.stateSizeBits == 129 ? 128 /*0x80*/ : 256 /*0x0100*/);
  }

  internal bool crypto_sign_open(byte[] m, byte[] sm, byte[] pk)
  {
    uint uint32 = Pack.LE_To_UInt32(sm, 0);
    byte[] message = Arrays.CopyOfRange(sm, 4, 4 + m.Length);
    int num = this.picnic_verify(pk, message, sm, uint32);
    Array.Copy((Array) sm, 4, (Array) m, 0, m.Length);
    return num != -1;
  }

  private int picnic_verify(byte[] pk, byte[] message, byte[] signature, uint sigLen)
  {
    byte[] numArray1 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    byte[] numArray2 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    int num = (int) this.picnic_read_public_key(numArray2, numArray1, pk);
    uint[] numArray3 = new uint[this.stateSizeWords];
    uint[] numArray4 = new uint[this.stateSizeWords];
    Pack.LE_To_UInt32(numArray1, 0, numArray4);
    Pack.LE_To_UInt32(numArray2, 0, numArray3);
    if (PicnicEngine.is_picnic3(this.parameters))
    {
      Signature2 sig = new Signature2(this);
      this.DeserializeSignature2(sig, signature, sigLen, message.Length + 4);
      return this.verify_picnic3(sig, numArray3, numArray4, message);
    }
    Signature sig1 = new Signature(this);
    if (this.DeserializeSignature(sig1, signature, sigLen, message.Length + 4) != 0)
      Console.Error.Write("Error couldn't deserialize signature!");
    return this.Verify(sig1, numArray3, numArray4, message);
  }

  private int Verify(Signature sig, uint[] pubKey, uint[] plaintext, byte[] message)
  {
    byte[][][] AS = new byte[this.numMPCRounds][][];
    for (int index1 = 0; index1 < this.numMPCRounds; ++index1)
    {
      AS[index1] = new byte[this.numMPCParties][];
      for (int index2 = 0; index2 < this.numMPCParties; ++index2)
        AS[index1][index2] = new byte[this.digestSizeBytes];
    }
    byte[][][] gs = new byte[this.numMPCRounds][][];
    for (int index3 = 0; index3 < this.numMPCRounds; ++index3)
    {
      gs[index3] = new byte[3][];
      for (int index4 = 0; index4 < 3; ++index4)
        gs[index3][index4] = new byte[this.UnruhGWithInputBytes];
    }
    uint[][][] viewOutputs = new uint[this.numMPCRounds][][];
    for (int index5 = 0; index5 < this.numMPCRounds; ++index5)
    {
      viewOutputs[index5] = new uint[3][];
      for (int index6 = 0; index6 < 3; ++index6)
        viewOutputs[index5][index6] = new uint[this.stateSizeBytes];
    }
    Signature.Proof[] proofs = sig.proofs;
    byte[] challengeBits = sig.challengeBits;
    int num = 0;
    byte[] tmp = new byte[System.Math.Max(6 * this.stateSizeBytes, this.stateSizeBytes + this.andSizeBytes)];
    Tape tape = new Tape(this);
    View[] viewArray1 = new View[this.numMPCRounds];
    View[] viewArray2 = new View[this.numMPCRounds];
    for (int index = 0; index < this.numMPCRounds; ++index)
    {
      viewArray1[index] = new View(this);
      viewArray2[index] = new View(this);
      this.VerifyProof(proofs[index], viewArray1[index], viewArray2[index], this.GetChallenge(challengeBits, index), sig.salt, (uint) index, tmp, plaintext, tape);
      int challenge = this.GetChallenge(challengeBits, index);
      this.Commit(proofs[index].seed1, 0, viewArray1[index], AS[index][challenge]);
      this.Commit(proofs[index].seed2, 0, viewArray2[index], AS[index][(challenge + 1) % 3]);
      Array.Copy((Array) proofs[index].view3Commitment, 0, (Array) AS[index][(challenge + 2) % 3], 0, this.digestSizeBytes);
      if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
      {
        this.G(challenge, proofs[index].seed1, 0, viewArray1[index], gs[index][challenge]);
        this.G((challenge + 1) % 3, proofs[index].seed2, 0, viewArray2[index], gs[index][(challenge + 1) % 3]);
        int length = challenge == 0 ? this.UnruhGWithInputBytes : this.UnruhGWithoutInputBytes;
        Array.Copy((Array) proofs[index].view3UnruhG, 0, (Array) gs[index][(challenge + 2) % 3], 0, length);
      }
      viewOutputs[index][challenge] = viewArray1[index].outputShare;
      viewOutputs[index][(challenge + 1) % 3] = viewArray2[index].outputShare;
      uint[] output = new uint[this.stateSizeWords];
      this.xor_three(output, viewArray1[index].outputShare, viewArray2[index].outputShare, pubKey, this.stateSizeBytes);
      viewOutputs[index][(challenge + 2) % 3] = output;
    }
    byte[] numArray = new byte[PicnicUtilities.NumBytes(2 * this.numMPCRounds)];
    this.H3(pubKey, plaintext, viewOutputs, AS, numArray, sig.salt, message, gs);
    if (!PicnicEngine.SubarrayEquals(challengeBits, numArray, PicnicUtilities.NumBytes(2 * this.numMPCRounds)))
    {
      Console.Error.Write("Invalid signature. Did not verify\n");
      num = -1;
    }
    return num;
  }

  private void VerifyProof(
    Signature.Proof proof,
    View view1,
    View view2,
    int challenge,
    byte[] salt,
    uint roundNumber,
    byte[] tmp,
    uint[] plaintext,
    Tape tape)
  {
    Array.Copy((Array) proof.communicatedBits, 0, (Array) view2.communicatedBits, 0, this.andSizeBytes);
    tape.pos = 0;
    bool flag = false;
    switch (challenge)
    {
      case 0:
        bool randomTape1 = this.CreateRandomTape(proof.seed1, 0, salt, roundNumber, 0U, tmp, this.stateSizeBytes + this.andSizeBytes);
        Pack.LE_To_UInt32(tmp, 0, view1.inputShare);
        Array.Copy((Array) tmp, this.stateSizeBytes, (Array) tape.tapes[0], 0, this.andSizeBytes);
        if (flag = randomTape1 && this.CreateRandomTape(proof.seed2, 0, salt, roundNumber, 1U, tmp, this.stateSizeBytes + this.andSizeBytes))
        {
          Pack.LE_To_UInt32(tmp, 0, view2.inputShare);
          Array.Copy((Array) tmp, this.stateSizeBytes, (Array) tape.tapes[1], 0, this.andSizeBytes);
          break;
        }
        break;
      case 1:
        bool randomTape2 = this.CreateRandomTape(proof.seed1, 0, salt, roundNumber, 1U, tmp, this.stateSizeBytes + this.andSizeBytes);
        Pack.LE_To_UInt32(tmp, 0, view1.inputShare);
        Array.Copy((Array) tmp, this.stateSizeBytes, (Array) tape.tapes[0], 0, this.andSizeBytes);
        if (flag = randomTape2 && this.CreateRandomTape(proof.seed2, 0, salt, roundNumber, 2U, tape.tapes[1], this.andSizeBytes))
        {
          Array.Copy((Array) proof.inputShare, 0, (Array) view2.inputShare, 0, this.stateSizeBytes);
          break;
        }
        break;
      case 2:
        bool randomTape3 = this.CreateRandomTape(proof.seed1, 0, salt, roundNumber, 2U, tape.tapes[0], this.andSizeBytes);
        Array.Copy((Array) proof.inputShare, 0, (Array) view1.inputShare, 0, this.stateSizeBytes);
        if (flag = randomTape3 && this.CreateRandomTape(proof.seed2, 0, salt, roundNumber, 0U, tmp, this.stateSizeBytes + this.andSizeBytes))
        {
          Pack.LE_To_UInt32(tmp, 0, view2.inputShare);
          Array.Copy((Array) tmp, this.stateSizeBytes, (Array) tape.tapes[1], 0, this.andSizeBytes);
          break;
        }
        break;
      default:
        Console.Error.Write("Invalid Challenge!");
        break;
    }
    if (!flag)
      Console.Error.Write("Failed to generate random tapes, signature verification will fail (but signature may actually be valid)\n");
    byte[] numArray = new byte[this.stateSizeBytes * 4];
    Pack.UInt32_To_LE(view1.inputShare, numArray, 0);
    Arrays.Fill(numArray, this.stateSizeBytes, numArray.Length, (byte) 0);
    PicnicUtilities.ZeroTrailingBits(numArray, this.stateSizeBits);
    Pack.LE_To_UInt32(numArray, 0, view1.inputShare);
    Pack.UInt32_To_LE(view2.inputShare, numArray, 0);
    Arrays.Fill(numArray, this.stateSizeBytes, numArray.Length, (byte) 0);
    PicnicUtilities.ZeroTrailingBits(numArray, this.stateSizeBits);
    Pack.LE_To_UInt32(numArray, 0, view2.inputShare);
    uint[] uint32 = Pack.LE_To_UInt32(tmp, 0, tmp.Length / 4);
    this.mpc_LowMC_verify(view1, view2, tape, uint32, plaintext, challenge);
  }

  private void mpc_LowMC_verify(
    View view1,
    View view2,
    Tape tapes,
    uint[] tmp,
    uint[] plaintext,
    int challenge)
  {
    PicnicUtilities.Fill(tmp, 0, tmp.Length, 0U);
    this.mpc_xor_constant_verify(tmp, plaintext, 0, this.stateSizeWords, challenge);
    KMatricesWithPointer kmatricesWithPointer1 = this._lowmcConstants.KMatrix(this, 0);
    this.matrix_mul_offset(tmp, 0, view1.inputShare, 0, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    this.matrix_mul_offset(tmp, this.stateSizeWords, view2.inputShare, 0, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    this.mpc_xor(tmp, tmp, this.stateSizeWords, 2);
    for (int round = 1; round <= this.numRounds; ++round)
    {
      KMatricesWithPointer kmatricesWithPointer2 = this._lowmcConstants.KMatrix(this, round);
      this.matrix_mul_offset(tmp, 0, view1.inputShare, 0, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      this.matrix_mul_offset(tmp, this.stateSizeWords, view2.inputShare, 0, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      this.mpc_substitution_verify(tmp, tapes, view1, view2);
      KMatricesWithPointer kmatricesWithPointer3 = this._lowmcConstants.LMatrix(this, round - 1);
      this.mpc_matrix_mul(tmp, 2 * this.stateSizeWords, tmp, 2 * this.stateSizeWords, kmatricesWithPointer3.GetData(), kmatricesWithPointer3.GetMatrixPointer(), 2);
      KMatricesWithPointer kmatricesWithPointer4 = this._lowmcConstants.RConstant(this, round - 1);
      this.mpc_xor_constant_verify(tmp, kmatricesWithPointer4.GetData(), kmatricesWithPointer4.GetMatrixPointer(), this.stateSizeWords, challenge);
      this.mpc_xor(tmp, tmp, this.stateSizeWords, 2);
    }
    Array.Copy((Array) tmp, 2 * this.stateSizeWords, (Array) view1.outputShare, 0, this.stateSizeWords);
    Array.Copy((Array) tmp, 3 * this.stateSizeWords, (Array) view2.outputShare, 0, this.stateSizeWords);
  }

  private void mpc_substitution_verify(uint[] state, Tape rand, View view1, View view2)
  {
    uint[] numArray1 = new uint[2];
    uint[] numArray2 = new uint[2];
    uint[] numArray3 = new uint[2];
    uint[] output1 = new uint[2];
    uint[] output2 = new uint[2];
    uint[] output3 = new uint[2];
    for (int index1 = 0; index1 < this.numSboxes * 3; index1 += 3)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        int num = (2 + index2) * this.stateSizeWords * 32 /*0x20*/;
        numArray1[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1 + 2);
        numArray2[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1 + 1);
        numArray3[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1);
      }
      this.mpc_AND_verify(numArray1, numArray2, output1, rand, view1, view2);
      this.mpc_AND_verify(numArray2, numArray3, output2, rand, view1, view2);
      this.mpc_AND_verify(numArray3, numArray1, output3, rand, view1, view2);
      for (int index3 = 0; index3 < 2; ++index3)
      {
        int num = (2 + index3) * this.stateSizeWords * 32 /*0x20*/;
        PicnicUtilities.SetBitInWordArray(state, num + index1 + 2, numArray1[index3] ^ output2[index3]);
        PicnicUtilities.SetBitInWordArray(state, num + index1 + 1, numArray1[index3] ^ numArray2[index3] ^ output3[index3]);
        PicnicUtilities.SetBitInWordArray(state, num + index1, numArray1[index3] ^ numArray2[index3] ^ numArray3[index3] ^ output1[index3]);
      }
    }
  }

  private void mpc_AND_verify(
    uint[] in1,
    uint[] in2,
    uint[] output,
    Tape rand,
    View view1,
    View view2)
  {
    uint[] numArray = new uint[2]
    {
      (uint) PicnicUtilities.GetBit(rand.tapes[0], rand.pos),
      (uint) PicnicUtilities.GetBit(rand.tapes[1], rand.pos)
    };
    output[0] = (uint) ((int) in1[0] & (int) in2[1] ^ (int) in1[1] & (int) in2[0] ^ (int) in1[0] & (int) in2[0]) ^ numArray[0] ^ numArray[1];
    PicnicUtilities.SetBit(view1.communicatedBits, rand.pos, (byte) (output[0] & (uint) byte.MaxValue));
    output[1] = (uint) PicnicUtilities.GetBit(view2.communicatedBits, rand.pos);
    ++rand.pos;
  }

  private void mpc_xor_constant_verify(
    uint[] state,
    uint[] input,
    int inOffset,
    int length,
    int challenge)
  {
    int num;
    switch (challenge)
    {
      case 0:
        num = 2 * this.stateSizeWords;
        break;
      case 2:
        num = 3 * this.stateSizeWords;
        break;
      default:
        return;
    }
    for (int index = 0; index < length; ++index)
      state[index + num] = state[index + num] ^ input[index + inOffset];
  }

  private int DeserializeSignature(
    Signature sig,
    byte[] sigBytes,
    uint sigBytesLen,
    int sigBytesOffset)
  {
    Signature.Proof[] proofs = sig.proofs;
    byte[] challengeBits = sig.challengeBits;
    if ((long) sigBytesLen < (long) PicnicUtilities.NumBytes(2 * this.numMPCRounds))
      return -1;
    int inputShareSize = this.ComputeInputShareSize(sigBytes, this.stateSizeBytes);
    int num = PicnicUtilities.NumBytes(2 * this.numMPCRounds) + PicnicEngine.saltSizeBytes + this.numMPCRounds * (2 * this.seedSizeBytes + this.andSizeBytes + this.digestSizeBytes) + inputShareSize;
    if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
      num += this.UnruhGWithoutInputBytes * this.numMPCRounds;
    if ((long) sigBytesLen < (long) num)
      return -1;
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) challengeBits, 0, PicnicUtilities.NumBytes(2 * this.numMPCRounds));
    sigBytesOffset += PicnicUtilities.NumBytes(2 * this.numMPCRounds);
    if (!this.IsChallengeValid(challengeBits))
      return -1;
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.salt, 0, PicnicEngine.saltSizeBytes);
    sigBytesOffset += PicnicEngine.saltSizeBytes;
    for (int round = 0; round < this.numMPCRounds; ++round)
    {
      int challenge = this.GetChallenge(challengeBits, round);
      Array.Copy((Array) sigBytes, sigBytesOffset, (Array) proofs[round].view3Commitment, 0, this.digestSizeBytes);
      sigBytesOffset += this.digestSizeBytes;
      if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
      {
        int length = challenge == 0 ? this.UnruhGWithInputBytes : this.UnruhGWithoutInputBytes;
        Array.Copy((Array) sigBytes, sigBytesOffset, (Array) proofs[round].view3UnruhG, 0, length);
        sigBytesOffset += length;
      }
      Array.Copy((Array) sigBytes, sigBytesOffset, (Array) proofs[round].communicatedBits, 0, this.andSizeBytes);
      sigBytesOffset += this.andSizeBytes;
      Array.Copy((Array) sigBytes, sigBytesOffset, (Array) proofs[round].seed1, 0, this.seedSizeBytes);
      sigBytesOffset += this.seedSizeBytes;
      Array.Copy((Array) sigBytes, sigBytesOffset, (Array) proofs[round].seed2, 0, this.seedSizeBytes);
      sigBytesOffset += this.seedSizeBytes;
      if (challenge == 1 || challenge == 2)
      {
        Pack.LE_To_UInt32(sigBytes, sigBytesOffset, proofs[round].inputShare, 0, this.stateSizeBytes / 4);
        if (this.stateSizeBits == 129)
          proofs[round].inputShare[this.stateSizeWords - 1] = (uint) sigBytes[sigBytesOffset + this.stateSizeBytes - 1] & (uint) byte.MaxValue;
        sigBytesOffset += this.stateSizeBytes;
        if (!this.ArePaddingBitsZero(Pack.UInt32_To_LE(proofs[round].inputShare), this.stateSizeBits))
          return -1;
      }
    }
    return 0;
  }

  private bool IsChallengeValid(byte[] challengeBits)
  {
    for (int round = 0; round < this.numMPCRounds; ++round)
    {
      if (this.GetChallenge(challengeBits, round) > 2)
        return false;
    }
    return true;
  }

  private int ComputeInputShareSize(byte[] challengeBits, int stateSizeBytes)
  {
    int inputShareSize = 0;
    for (int round = 0; round < this.numMPCRounds; ++round)
    {
      switch (this.GetChallenge(challengeBits, round))
      {
        case 1:
        case 2:
          inputShareSize += stateSizeBytes;
          break;
      }
    }
    return inputShareSize;
  }

  private uint picnic_read_public_key(byte[] ciphertext, byte[] plaintext, byte[] pk)
  {
    Array.Copy((Array) pk, 1, (Array) ciphertext, 0, this.stateSizeBytes);
    Array.Copy((Array) pk, 1 + this.stateSizeBytes, (Array) plaintext, 0, this.stateSizeBytes);
    return 0;
  }

  private int verify_picnic3(Signature2 sig, uint[] pubKey, uint[] plaintext, byte[] message)
  {
    byte[][][] numArray1 = new byte[this.numMPCRounds][][];
    for (int index1 = 0; index1 < this.numMPCRounds; ++index1)
    {
      numArray1[index1] = new byte[this.numMPCParties][];
      for (int index2 = 0; index2 < this.numMPCParties; ++index2)
        numArray1[index1][index2] = new byte[this.digestSizeBytes];
    }
    byte[][] Ch = new byte[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      Ch[index] = new byte[this.digestSizeBytes];
    byte[][] leafData = new byte[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      leafData[index] = new byte[this.digestSizeBytes];
    Msg[] msgArray = new Msg[this.numMPCRounds];
    Tree tree1 = new Tree(this, (uint) this.numMPCRounds, this.digestSizeBytes);
    byte[] numArray2 = new byte[(int) PicnicEngine.MAX_DIGEST_SIZE];
    Tree[] treeArray = new Tree[this.numMPCRounds];
    Tape[] tapeArray = new Tape[this.numMPCRounds];
    Tree tree2 = new Tree(this, (uint) this.numMPCRounds, this.seedSizeBytes);
    if (tree2.ReconstructSeeds(sig.challengeC, (uint) this.numOpenedRounds, sig.iSeedInfo, (uint) sig.iSeedInfoLen, sig.salt, 0U) != 0)
      return -1;
    for (uint index3 = 0; (long) index3 < (long) this.numMPCRounds; ++index3)
    {
      if (!this.Contains(sig.challengeC, this.numOpenedRounds, index3))
      {
        treeArray[(int) index3] = new Tree(this, (uint) this.numMPCParties, this.seedSizeBytes);
        treeArray[(int) index3].GenerateSeeds(tree2.GetLeaf(index3), sig.salt, index3);
      }
      else
      {
        treeArray[(int) index3] = new Tree(this, (uint) this.numMPCParties, this.seedSizeBytes);
        int index4 = PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index3);
        uint[] hideList = new uint[1]
        {
          sig.challengeP[index4]
        };
        if (treeArray[(int) index3].ReconstructSeeds(hideList, 1U, sig.proofs[(int) index3].seedInfo, (uint) sig.proofs[(int) index3].seedInfoLen, sig.salt, index3) != 0)
        {
          Console.Error.Write("Failed to reconstruct seeds for round %d\n", (object) index3);
          return -1;
        }
      }
    }
    uint index5 = (uint) (this.numMPCParties - 1);
    byte[] numArray3 = new byte[(int) PicnicEngine.MAX_AUX_BYTES];
    for (uint t = 0; (long) t < (long) this.numMPCRounds; ++t)
    {
      tapeArray[(int) t] = new Tape(this);
      this.CreateRandomTapes(tapeArray[(int) t], treeArray[(int) t].GetLeaves(), treeArray[(int) t].GetLeavesOffset(), sig.salt, t);
      if (!this.Contains(sig.challengeC, this.numOpenedRounds, t))
      {
        tapeArray[(int) t].ComputeAuxTape((byte[]) null);
        for (uint index6 = 0; index6 < index5; ++index6)
          this.commit(numArray1[(int) t][(int) index6], treeArray[(int) t].GetLeaf(index6), (byte[]) null, sig.salt, t, index6);
        this.GetAuxBits(numArray3, tapeArray[(int) t]);
        this.commit(numArray1[(int) t][(int) index5], treeArray[(int) t].GetLeaf(index5), numArray3, sig.salt, t, index5);
      }
      else
      {
        uint index7 = sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, t)];
        for (uint index8 = 0; index8 < index5; ++index8)
        {
          if ((int) index8 != (int) index7)
            this.commit(numArray1[(int) t][(int) index8], treeArray[(int) t].GetLeaf(index8), (byte[]) null, sig.salt, t, index8);
        }
        if ((int) index5 != (int) index7)
          this.commit(numArray1[(int) t][(int) index5], treeArray[(int) t].GetLeaf(index5), sig.proofs[(int) t].aux, sig.salt, t, index5);
        Array.Copy((Array) sig.proofs[(int) t].C, 0, (Array) numArray1[(int) t][(int) index7], 0, this.digestSizeBytes);
      }
    }
    for (int index9 = 0; index9 < this.numMPCRounds; ++index9)
      this.commit_h(Ch[index9], numArray1[index9]);
    uint[] tmp_shares = new uint[this.stateSizeBits];
    for (uint index10 = 0; (long) index10 < (long) this.numMPCRounds; ++index10)
    {
      msgArray[(int) index10] = new Msg(this);
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index10))
      {
        uint index11 = sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index10)];
        if ((int) index11 != (int) index5)
          tapeArray[(int) index10].SetAuxBits(sig.proofs[(int) index10].aux);
        Array.Copy((Array) sig.proofs[(int) index10].msgs, 0, (Array) msgArray[(int) index10].msgs[(int) index11], 0, this.andSizeBytes);
        Arrays.Fill(tapeArray[(int) index10].tapes[(int) index11], (byte) 0);
        msgArray[(int) index10].unopened = (int) index11;
        byte[] numArray4 = new byte[this.stateSizeWords * 4];
        Array.Copy((Array) sig.proofs[(int) index10].input, 0, (Array) numArray4, 0, sig.proofs[(int) index10].input.Length);
        uint[] numArray5 = new uint[this.stateSizeWords];
        Pack.LE_To_UInt32(numArray4, 0, numArray5, 0, this.stateSizeWords);
        if (this.SimulateOnline(numArray5, tapeArray[(int) index10], tmp_shares, msgArray[(int) index10], plaintext, pubKey) == 0)
        {
          this.commit_v(leafData[(int) index10], sig.proofs[(int) index10].input, msgArray[(int) index10]);
        }
        else
        {
          Console.Error.Write("MPC simulation failed for round %d, signature invalid\n", (object) index10);
          return -1;
        }
      }
      else
        leafData[(int) index10] = (byte[]) null;
    }
    int missingLeavesSize = this.numMPCRounds - this.numOpenedRounds;
    uint[] missingLeavesList = this.GetMissingLeavesList(sig.challengeC);
    if (tree1.AddMerkleNodes(missingLeavesList, (uint) missingLeavesSize, sig.cvInfo, (uint) sig.cvInfoLen) != 0)
      return -1;
    int num = tree1.VerifyMerkleTree(leafData, sig.salt);
    if (num != 0)
      return -1;
    this.HCP(numArray2, (uint[]) null, (uint[]) null, Ch, tree1.nodes[0], sig.salt, pubKey, plaintext, message);
    if (PicnicEngine.SubarrayEquals(sig.challengeHash, numArray2, this.digestSizeBytes))
      return num;
    Console.Error.Write("Challenge does not match, signature invalid\n");
    return -1;
  }

  private int DeserializeSignature2(
    Signature2 sig,
    byte[] sigBytes,
    uint sigLen,
    int sigBytesOffset)
  {
    int num1 = this.digestSizeBytes + PicnicEngine.saltSizeBytes;
    if (sigBytes.Length < num1)
      return -1;
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.challengeHash, 0, this.digestSizeBytes);
    sigBytesOffset += this.digestSizeBytes;
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.salt, 0, PicnicEngine.saltSizeBytes);
    sigBytesOffset += PicnicEngine.saltSizeBytes;
    this.ExpandChallengeHash(sig.challengeHash, sig.challengeC, sig.challengeP);
    Tree tree1 = new Tree(this, (uint) this.numMPCRounds, this.seedSizeBytes);
    sig.iSeedInfoLen = (int) tree1.RevealSeedsSize(sig.challengeC, (uint) this.numOpenedRounds);
    int num2 = num1 + sig.iSeedInfoLen;
    int missingLeavesSize = this.numMPCRounds - this.numOpenedRounds;
    uint[] missingLeavesList = this.GetMissingLeavesList(sig.challengeC);
    Tree tree2 = new Tree(this, (uint) this.numMPCRounds, this.digestSizeBytes);
    sig.cvInfoLen = (int) tree2.OpenMerkleTreeSize(missingLeavesList, (uint) missingLeavesSize);
    int num3 = num2 + sig.cvInfoLen;
    int num4 = (int) new Tree(this, (uint) this.numMPCParties, this.seedSizeBytes).RevealSeedsSize(new uint[1], 1U);
    for (uint index = 0; (long) index < (long) this.numMPCRounds; ++index)
    {
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index))
      {
        if ((long) sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index)] != (long) (this.numMPCParties - 1))
          num3 += this.andSizeBytes;
        num3 = num3 + num4 + this.stateSizeBytes + this.andSizeBytes + this.digestSizeBytes;
      }
    }
    if ((long) sigLen != (long) num3)
    {
      Console.Error.Write("sigBytesLen = %d, expected bytesRequired = %d\n", (object) sigBytes.Length, (object) num3);
      return -1;
    }
    sig.iSeedInfo = new byte[sig.iSeedInfoLen];
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.iSeedInfo, 0, sig.iSeedInfoLen);
    sigBytesOffset += sig.iSeedInfoLen;
    sig.cvInfo = new byte[sig.cvInfoLen];
    Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.cvInfo, 0, sig.cvInfoLen);
    sigBytesOffset += sig.cvInfoLen;
    for (uint index = 0; (long) index < (long) this.numMPCRounds; ++index)
    {
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index))
      {
        sig.proofs[(int) index] = new Signature2.Proof2(this);
        sig.proofs[(int) index].seedInfoLen = num4;
        sig.proofs[(int) index].seedInfo = new byte[sig.proofs[(int) index].seedInfoLen];
        Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.proofs[(int) index].seedInfo, 0, sig.proofs[(int) index].seedInfoLen);
        sigBytesOffset += sig.proofs[(int) index].seedInfoLen;
        if ((long) sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index)] != (long) (this.numMPCParties - 1))
        {
          Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.proofs[(int) index].aux, 0, this.andSizeBytes);
          sigBytesOffset += this.andSizeBytes;
          if (!this.ArePaddingBitsZero(sig.proofs[(int) index].aux, 3 * this.numRounds * this.numSboxes))
          {
            Console.Error.Write("failed while deserializing aux bits\n");
            return -1;
          }
        }
        Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.proofs[(int) index].input, 0, this.stateSizeBytes);
        sigBytesOffset += this.stateSizeBytes;
        int andSizeBytes = this.andSizeBytes;
        Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.proofs[(int) index].msgs, 0, andSizeBytes);
        sigBytesOffset += andSizeBytes;
        int bitLength = 3 * this.numRounds * this.numSboxes;
        if (this.ArePaddingBitsZero(sig.proofs[(int) index].msgs, bitLength))
        {
          Array.Copy((Array) sigBytes, sigBytesOffset, (Array) sig.proofs[(int) index].C, 0, this.digestSizeBytes);
          sigBytesOffset += this.digestSizeBytes;
        }
        else
        {
          Console.Error.Write("failed while deserializing msgs bits\n");
          return -1;
        }
      }
    }
    return 0;
  }

  private bool ArePaddingBitsZero(byte[] data, int bitLength)
  {
    int num = PicnicUtilities.NumBytes(bitLength);
    for (int bitNumber = bitLength; bitNumber < num * 8; ++bitNumber)
    {
      if (PicnicUtilities.GetBit(data, bitNumber) != (byte) 0)
        return false;
    }
    return true;
  }

  internal void crypto_sign(byte[] sm, byte[] m, byte[] sk)
  {
    this.picnic_sign(sk, m, sm);
    Array.Copy((Array) m, 0, (Array) sm, 4, m.Length);
    sm = Arrays.CopyOfRange(sm, 0, this.signatureLength);
  }

  private void picnic_sign(byte[] sk, byte[] message, byte[] signature)
  {
    byte[] numArray1 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    Array.Copy((Array) sk, 1, (Array) numArray1, 0, this.stateSizeBytes);
    byte[] numArray2 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    Array.Copy((Array) sk, 1 + this.stateSizeBytes, (Array) numArray2, 0, this.stateSizeBytes);
    byte[] numArray3 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    Array.Copy((Array) sk, 1 + 2 * this.stateSizeBytes, (Array) numArray3, 0, this.stateSizeBytes);
    uint[] numArray4 = new uint[this.stateSizeWords];
    uint[] numArray5 = new uint[this.stateSizeWords];
    uint[] numArray6 = new uint[this.stateSizeWords];
    Pack.LE_To_UInt32(numArray1, 0, numArray4);
    Pack.LE_To_UInt32(numArray3, 0, numArray6);
    Pack.LE_To_UInt32(numArray2, 0, numArray5);
    if (!PicnicEngine.is_picnic3(this.parameters))
    {
      Signature sig = new Signature(this);
      if (this.sign_picnic1(numArray4, numArray5, numArray6, message, sig) != 0)
        Console.Error.Write("Failed to create signature\n");
      int n = this.SerializeSignature(sig, signature, message.Length + 4);
      if (n == -1)
        Console.Error.Write("Failed to serialize signature\n");
      this.signatureLength = n;
      Pack.UInt32_To_LE((uint) n, signature, 0);
    }
    else
    {
      Signature2 sig = new Signature2(this);
      this.sign_picnic3(numArray4, numArray5, numArray6, message, sig);
      int n = this.SerializeSignature2(sig, signature, message.Length + 4);
      this.signatureLength = n;
      Pack.UInt32_To_LE((uint) n, signature, 0);
    }
  }

  private int SerializeSignature(Signature sig, byte[] sigBytes, int sigOffset)
  {
    Signature.Proof[] proofs = sig.proofs;
    byte[] challengeBits = sig.challengeBits;
    int num1 = PicnicUtilities.NumBytes(2 * this.numMPCRounds) + PicnicEngine.saltSizeBytes + this.numMPCRounds * (2 * this.seedSizeBytes + this.stateSizeBytes + this.andSizeBytes + this.digestSizeBytes);
    if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
      num1 += this.UnruhGWithoutInputBytes * this.numMPCRounds;
    if (this.CRYPTO_BYTES < num1)
      return -1;
    int destinationIndex1 = sigOffset;
    Array.Copy((Array) challengeBits, 0, (Array) sigBytes, destinationIndex1, PicnicUtilities.NumBytes(2 * this.numMPCRounds));
    int destinationIndex2 = destinationIndex1 + PicnicUtilities.NumBytes(2 * this.numMPCRounds);
    Array.Copy((Array) sig.salt, 0, (Array) sigBytes, destinationIndex2, PicnicEngine.saltSizeBytes);
    int num2 = destinationIndex2 + PicnicEngine.saltSizeBytes;
    for (int round = 0; round < this.numMPCRounds; ++round)
    {
      int challenge = this.GetChallenge(challengeBits, round);
      Array.Copy((Array) proofs[round].view3Commitment, 0, (Array) sigBytes, num2, this.digestSizeBytes);
      int destinationIndex3 = num2 + this.digestSizeBytes;
      if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
      {
        int length = challenge == 0 ? this.UnruhGWithInputBytes : this.UnruhGWithoutInputBytes;
        Array.Copy((Array) proofs[round].view3UnruhG, 0, (Array) sigBytes, destinationIndex3, length);
        destinationIndex3 += length;
      }
      Array.Copy((Array) proofs[round].communicatedBits, 0, (Array) sigBytes, destinationIndex3, this.andSizeBytes);
      int destinationIndex4 = destinationIndex3 + this.andSizeBytes;
      Array.Copy((Array) proofs[round].seed1, 0, (Array) sigBytes, destinationIndex4, this.seedSizeBytes);
      int destinationIndex5 = destinationIndex4 + this.seedSizeBytes;
      Array.Copy((Array) proofs[round].seed2, 0, (Array) sigBytes, destinationIndex5, this.seedSizeBytes);
      num2 = destinationIndex5 + this.seedSizeBytes;
      if (challenge == 1 || challenge == 2)
      {
        Pack.UInt32_To_LE(proofs[round].inputShare, 0, this.stateSizeWords, sigBytes, num2);
        num2 += this.stateSizeBytes;
      }
    }
    return num2 - sigOffset;
  }

  private int GetChallenge(byte[] challenge, int round)
  {
    return (int) PicnicUtilities.GetBit(challenge, 2 * round + 1) << 1 | (int) PicnicUtilities.GetBit(challenge, 2 * round);
  }

  private int SerializeSignature2(Signature2 sig, byte[] sigBytes, int sigOffset)
  {
    int num1 = this.digestSizeBytes + PicnicEngine.saltSizeBytes + sig.iSeedInfoLen + sig.cvInfoLen;
    for (uint index = 0; (long) index < (long) this.numMPCRounds; ++index)
    {
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index))
      {
        int num2 = (int) sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index)];
        int num3 = num1 + sig.proofs[(int) index].seedInfoLen;
        if ((long) (uint) num2 != (long) (this.numMPCParties - 1))
          num3 += this.andSizeBytes;
        num1 = num3 + this.stateSizeBytes + this.andSizeBytes + this.digestSizeBytes;
      }
    }
    if (sigBytes.Length < num1)
      return -1;
    int destinationIndex1 = sigOffset;
    Array.Copy((Array) sig.challengeHash, 0, (Array) sigBytes, destinationIndex1, this.digestSizeBytes);
    int destinationIndex2 = destinationIndex1 + this.digestSizeBytes;
    Array.Copy((Array) sig.salt, 0, (Array) sigBytes, destinationIndex2, PicnicEngine.saltSizeBytes);
    int destinationIndex3 = destinationIndex2 + PicnicEngine.saltSizeBytes;
    Array.Copy((Array) sig.iSeedInfo, 0, (Array) sigBytes, destinationIndex3, sig.iSeedInfoLen);
    int destinationIndex4 = destinationIndex3 + sig.iSeedInfoLen;
    Array.Copy((Array) sig.cvInfo, 0, (Array) sigBytes, destinationIndex4, sig.cvInfoLen);
    int destinationIndex5 = destinationIndex4 + sig.cvInfoLen;
    for (uint index = 0; (long) index < (long) this.numMPCRounds; ++index)
    {
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index))
      {
        Array.Copy((Array) sig.proofs[(int) index].seedInfo, 0, (Array) sigBytes, destinationIndex5, sig.proofs[(int) index].seedInfoLen);
        int destinationIndex6 = destinationIndex5 + sig.proofs[(int) index].seedInfoLen;
        if ((long) sig.challengeP[PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index)] != (long) (this.numMPCParties - 1))
        {
          Array.Copy((Array) sig.proofs[(int) index].aux, 0, (Array) sigBytes, destinationIndex6, this.andSizeBytes);
          destinationIndex6 += this.andSizeBytes;
        }
        Array.Copy((Array) sig.proofs[(int) index].input, 0, (Array) sigBytes, destinationIndex6, this.stateSizeBytes);
        int destinationIndex7 = destinationIndex6 + this.stateSizeBytes;
        Array.Copy((Array) sig.proofs[(int) index].msgs, 0, (Array) sigBytes, destinationIndex7, this.andSizeBytes);
        int destinationIndex8 = destinationIndex7 + this.andSizeBytes;
        Array.Copy((Array) sig.proofs[(int) index].C, 0, (Array) sigBytes, destinationIndex8, this.digestSizeBytes);
        destinationIndex5 = destinationIndex8 + this.digestSizeBytes;
      }
    }
    return destinationIndex5 - sigOffset;
  }

  private int sign_picnic1(
    uint[] privateKey,
    uint[] pubKey,
    uint[] plaintext,
    byte[] message,
    Signature sig)
  {
    View[][] viewArray = new View[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      viewArray[index] = new View[3];
    byte[][][] AS = new byte[this.numMPCRounds][][];
    for (int index1 = 0; index1 < this.numMPCRounds; ++index1)
    {
      AS[index1] = new byte[this.numMPCParties][];
      for (int index2 = 0; index2 < this.numMPCParties; ++index2)
        AS[index1][index2] = new byte[this.digestSizeBytes];
    }
    byte[][][] gs = new byte[this.numMPCRounds][][];
    for (int index3 = 0; index3 < this.numMPCRounds; ++index3)
    {
      gs[index3] = new byte[3][];
      for (int index4 = 0; index4 < 3; ++index4)
        gs[index3][index4] = new byte[this.UnruhGWithInputBytes];
    }
    byte[] seeds = this.ComputeSeeds(privateKey, pubKey, plaintext, message);
    int num = this.numMPCParties * this.seedSizeBytes;
    Array.Copy((Array) seeds, num * this.numMPCRounds, (Array) sig.salt, 0, PicnicEngine.saltSizeBytes);
    Tape tapes = new Tape(this);
    byte[] numArray1 = new byte[System.Math.Max(9 * this.stateSizeBytes, this.stateSizeBytes + this.andSizeBytes)];
    byte[] numArray2 = new byte[this.stateSizeBytes * 4];
    for (int roundNumber = 0; roundNumber < this.numMPCRounds; ++roundNumber)
    {
      viewArray[roundNumber][0] = new View(this);
      viewArray[roundNumber][1] = new View(this);
      viewArray[roundNumber][2] = new View(this);
      for (int playerNumber = 0; playerNumber < 2; ++playerNumber)
      {
        if (this.CreateRandomTape(seeds, num * roundNumber + playerNumber * this.seedSizeBytes, sig.salt, (uint) roundNumber, (uint) playerNumber, numArray1, this.stateSizeBytes + this.andSizeBytes))
        {
          Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, this.stateSizeBytes);
          PicnicUtilities.ZeroTrailingBits(numArray2, this.stateSizeBits);
          Pack.LE_To_UInt32(numArray2, 0, viewArray[roundNumber][playerNumber].inputShare);
          Array.Copy((Array) numArray1, this.stateSizeBytes, (Array) tapes.tapes[playerNumber], 0, this.andSizeBytes);
        }
        else
        {
          Console.Error.Write("createRandomTape failed \n");
          return -1;
        }
      }
      if (this.CreateRandomTape(seeds, num * roundNumber + 2 * this.seedSizeBytes, sig.salt, (uint) roundNumber, 2U, tapes.tapes[2], this.andSizeBytes))
      {
        this.xor_three(viewArray[roundNumber][2].inputShare, privateKey, viewArray[roundNumber][0].inputShare, viewArray[roundNumber][1].inputShare, this.stateSizeBytes);
        tapes.pos = 0;
        uint[] uint32 = Pack.LE_To_UInt32(numArray1, 0, numArray1.Length / 4);
        this.mpc_LowMC(tapes, viewArray[roundNumber], plaintext, uint32);
        Pack.UInt32_To_LE(uint32, numArray1, 0);
        uint[] numArray3 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
        this.xor_three(numArray3, viewArray[roundNumber][0].outputShare, viewArray[roundNumber][1].outputShare, viewArray[roundNumber][2].outputShare, this.stateSizeBytes);
        if (PicnicEngine.SubarrayEquals(numArray3, pubKey, this.stateSizeWords))
        {
          this.Commit(seeds, num * roundNumber + 0, viewArray[roundNumber][0], AS[roundNumber][0]);
          this.Commit(seeds, num * roundNumber + this.seedSizeBytes, viewArray[roundNumber][1], AS[roundNumber][1]);
          this.Commit(seeds, num * roundNumber + 2 * this.seedSizeBytes, viewArray[roundNumber][2], AS[roundNumber][2]);
          if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
          {
            this.G(0, seeds, num * roundNumber + 0, viewArray[roundNumber][0], gs[roundNumber][0]);
            this.G(1, seeds, num * roundNumber + this.seedSizeBytes, viewArray[roundNumber][1], gs[roundNumber][1]);
            this.G(2, seeds, num * roundNumber + 2 * this.seedSizeBytes, viewArray[roundNumber][2], gs[roundNumber][2]);
          }
        }
        else
        {
          Console.Error.WriteLine($"Simulation failed; output does not match public key (round = {roundNumber.ToString()})");
          return -1;
        }
      }
      else
      {
        Console.Error.Write("createRandomTape failed \n");
        return -1;
      }
    }
    uint[][][] viewOutputs = new uint[this.numMPCRounds][][];
    for (int index5 = 0; index5 < this.numMPCRounds; ++index5)
    {
      viewOutputs[index5] = new uint[3][];
      for (int index6 = 0; index6 < 3; ++index6)
        viewOutputs[index5][index6] = viewArray[index5][index6].outputShare;
    }
    this.H3(pubKey, plaintext, viewOutputs, AS, sig.challengeBits, sig.salt, message, gs);
    for (int round = 0; round < this.numMPCRounds; ++round)
      this.Prove(sig.proofs[round], this.GetChallenge(sig.challengeBits, round), seeds, num * round, viewArray[round], AS[round], (int) this.transform != (int) PicnicEngine.TRANSFORM_UR ? (byte[][]) null : gs[round]);
    return 0;
  }

  private void Prove(
    Signature.Proof proof,
    int challenge,
    byte[] seeds,
    int seedsOffset,
    View[] views,
    byte[][] commitments,
    byte[][] gs)
  {
    switch (challenge)
    {
      case 0:
        Array.Copy((Array) seeds, seedsOffset + 0, (Array) proof.seed1, 0, this.seedSizeBytes);
        Array.Copy((Array) seeds, seedsOffset + this.seedSizeBytes, (Array) proof.seed2, 0, this.seedSizeBytes);
        break;
      case 1:
        Array.Copy((Array) seeds, seedsOffset + this.seedSizeBytes, (Array) proof.seed1, 0, this.seedSizeBytes);
        Array.Copy((Array) seeds, seedsOffset + 2 * this.seedSizeBytes, (Array) proof.seed2, 0, this.seedSizeBytes);
        break;
      case 2:
        Array.Copy((Array) seeds, seedsOffset + 2 * this.seedSizeBytes, (Array) proof.seed1, 0, this.seedSizeBytes);
        Array.Copy((Array) seeds, seedsOffset + 0, (Array) proof.seed2, 0, this.seedSizeBytes);
        break;
      default:
        Console.Error.Write("Invalid challenge");
        break;
    }
    if (challenge == 1 || challenge == 2)
      Array.Copy((Array) views[2].inputShare, 0, (Array) proof.inputShare, 0, this.stateSizeBytes);
    Array.Copy((Array) views[(challenge + 1) % 3].communicatedBits, 0, (Array) proof.communicatedBits, 0, this.andSizeBytes);
    Array.Copy((Array) commitments[(challenge + 2) % 3], 0, (Array) proof.view3Commitment, 0, this.digestSizeBytes);
    if ((int) this.transform != (int) PicnicEngine.TRANSFORM_UR)
      return;
    int length = challenge == 0 ? this.UnruhGWithInputBytes : this.UnruhGWithoutInputBytes;
    Array.Copy((Array) gs[(challenge + 2) % 3], 0, (Array) proof.view3UnruhG, 0, length);
  }

  private void H3(
    uint[] circuitOutput,
    uint[] plaintext,
    uint[][][] viewOutputs,
    byte[][][] AS,
    byte[] challengeBits,
    byte[] salt,
    byte[] message,
    byte[][][] gs)
  {
    byte[] numArray = new byte[this.digestSizeBytes];
    challengeBits[PicnicUtilities.NumBytes(this.numMPCRounds * 2) - 1] = (byte) 0;
    this.digest.Update((byte) 1);
    for (int index1 = 0; index1 < this.numMPCRounds; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
        this.digest.BlockUpdate(Pack.UInt32_To_LE(viewOutputs[index1][index2]), 0, this.stateSizeBytes);
    }
    for (int index3 = 0; index3 < this.numMPCRounds; ++index3)
    {
      for (int index4 = 0; index4 < 3; ++index4)
        this.digest.BlockUpdate(AS[index3][index4], 0, this.digestSizeBytes);
    }
    if ((int) this.transform == (int) PicnicEngine.TRANSFORM_UR)
    {
      for (int index5 = 0; index5 < this.numMPCRounds; ++index5)
      {
        for (int index6 = 0; index6 < 3; ++index6)
        {
          int inLen = index6 == 2 ? this.UnruhGWithInputBytes : this.UnruhGWithoutInputBytes;
          this.digest.BlockUpdate(gs[index5][index6], 0, inLen);
        }
      }
    }
    this.digest.BlockUpdate(Pack.UInt32_To_LE(circuitOutput), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(plaintext), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.digest.BlockUpdate(message, 0, message.Length);
    this.digest.OutputFinal(numArray, 0, this.digestSizeBytes);
    int round = 0;
    bool flag = true;
    while (flag)
    {
      for (int index7 = 0; index7 < this.digestSizeBytes; ++index7)
      {
        uint num = (uint) numArray[index7];
        for (int index8 = 0; index8 < 8; index8 += 2)
        {
          uint trit = num >> 6 - index8 & 3U;
          if (trit < 3U)
          {
            this.SetChallenge(challengeBits, round, trit);
            ++round;
            if (round == this.numMPCRounds)
            {
              flag = false;
              break;
            }
          }
        }
        if (!flag)
          break;
      }
      if (!flag)
        break;
      this.digest.Update((byte) 1);
      this.digest.BlockUpdate(numArray, 0, this.digestSizeBytes);
      this.digest.OutputFinal(numArray, 0, this.digestSizeBytes);
    }
  }

  private void SetChallenge(byte[] challenge, int round, uint trit)
  {
    PicnicUtilities.SetBit(challenge, 2 * round, (byte) (trit & 1U));
    PicnicUtilities.SetBit(challenge, 2 * round + 1, (byte) (trit >> 1 & 1U));
  }

  private void G(int viewNumber, byte[] seed, int seedOffset, View view, byte[] output)
  {
    int num = this.seedSizeBytes + this.andSizeBytes;
    this.digest.Update((byte) 5);
    this.digest.BlockUpdate(seed, seedOffset, this.seedSizeBytes);
    this.digest.OutputFinal(output, 0, this.digestSizeBytes);
    this.digest.BlockUpdate(output, 0, this.digestSizeBytes);
    if (viewNumber == 2)
    {
      this.digest.BlockUpdate(Pack.UInt32_To_LE(view.inputShare), 0, this.stateSizeBytes);
      num += this.stateSizeBytes;
    }
    this.digest.BlockUpdate(view.communicatedBits, 0, this.andSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE((uint) num), 0, 2);
    this.digest.OutputFinal(output, 0, num);
  }

  private void mpc_LowMC(Tape tapes, View[] views, uint[] plaintext, uint[] slab)
  {
    PicnicUtilities.Fill(slab, 0, slab.Length, 0U);
    this.mpc_xor_constant(slab, 3 * this.stateSizeWords, plaintext, 0, this.stateSizeWords);
    KMatricesWithPointer kmatricesWithPointer1 = this._lowmcConstants.KMatrix(this, 0);
    for (int index = 0; index < 3; ++index)
      this.matrix_mul_offset(slab, index * this.stateSizeWords, views[index].inputShare, 0, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    this.mpc_xor(slab, slab, this.stateSizeWords, 3);
    for (int round = 1; round <= this.numRounds; ++round)
    {
      KMatricesWithPointer kmatricesWithPointer2 = this._lowmcConstants.KMatrix(this, round);
      for (int index = 0; index < 3; ++index)
        this.matrix_mul_offset(slab, index * this.stateSizeWords, views[index].inputShare, 0, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      this.mpc_substitution(slab, tapes, views);
      KMatricesWithPointer kmatricesWithPointer3 = this._lowmcConstants.LMatrix(this, round - 1);
      this.mpc_matrix_mul(slab, 3 * this.stateSizeWords, slab, 3 * this.stateSizeWords, kmatricesWithPointer3.GetData(), kmatricesWithPointer3.GetMatrixPointer(), 3);
      KMatricesWithPointer kmatricesWithPointer4 = this._lowmcConstants.RConstant(this, round - 1);
      this.mpc_xor_constant(slab, 3 * this.stateSizeWords, kmatricesWithPointer4.GetData(), kmatricesWithPointer4.GetMatrixPointer(), this.stateSizeWords);
      this.mpc_xor(slab, slab, this.stateSizeWords, 3);
    }
    for (int index = 0; index < 3; ++index)
      Array.Copy((Array) slab, (3 + index) * this.stateSizeWords, (Array) views[index].outputShare, 0, this.stateSizeWords);
  }

  private void Commit(byte[] seed, int seedOffset, View view, byte[] hash)
  {
    this.digest.Update((byte) 4);
    this.digest.BlockUpdate(seed, seedOffset, this.seedSizeBytes);
    this.digest.OutputFinal(hash, 0, this.digestSizeBytes);
    this.digest.Update((byte) 0);
    this.digest.BlockUpdate(hash, 0, this.digestSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(view.inputShare), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(view.communicatedBits, 0, this.andSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(view.outputShare), 0, this.stateSizeBytes);
    this.digest.OutputFinal(hash, 0, this.digestSizeBytes);
  }

  private void mpc_substitution(uint[] state, Tape rand, View[] views)
  {
    uint[] numArray1 = new uint[3];
    uint[] numArray2 = new uint[3];
    uint[] numArray3 = new uint[3];
    uint[] output1 = new uint[3];
    uint[] output2 = new uint[3];
    uint[] output3 = new uint[3];
    for (int index1 = 0; index1 < this.numSboxes * 3; index1 += 3)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        int num = (3 + index2) * this.stateSizeWords * 32 /*0x20*/;
        numArray1[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1 + 2);
        numArray2[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1 + 1);
        numArray3[index2] = PicnicUtilities.GetBitFromWordArray(state, num + index1);
      }
      this.mpc_AND(numArray1, numArray2, output1, rand, views);
      this.mpc_AND(numArray2, numArray3, output2, rand, views);
      this.mpc_AND(numArray3, numArray1, output3, rand, views);
      for (int index3 = 0; index3 < 3; ++index3)
      {
        int num = (3 + index3) * this.stateSizeWords * 32 /*0x20*/;
        PicnicUtilities.SetBitInWordArray(state, num + index1 + 2, numArray1[index3] ^ output2[index3]);
        PicnicUtilities.SetBitInWordArray(state, num + index1 + 1, numArray1[index3] ^ numArray2[index3] ^ output3[index3]);
        PicnicUtilities.SetBitInWordArray(state, num + index1, numArray1[index3] ^ numArray2[index3] ^ numArray3[index3] ^ output1[index3]);
      }
    }
  }

  private void mpc_AND(uint[] in1, uint[] in2, uint[] output, Tape rand, View[] views)
  {
    uint[] numArray = new uint[3]
    {
      (uint) PicnicUtilities.GetBit(rand.tapes[0], rand.pos),
      (uint) PicnicUtilities.GetBit(rand.tapes[1], rand.pos),
      (uint) PicnicUtilities.GetBit(rand.tapes[2], rand.pos)
    };
    for (int index = 0; index < 3; ++index)
    {
      output[index] = (uint) ((int) in1[index] & (int) in2[(index + 1) % 3] ^ (int) in1[(index + 1) % 3] & (int) in2[index] ^ (int) in1[index] & (int) in2[index]) ^ numArray[index] ^ numArray[(index + 1) % 3];
      PicnicUtilities.SetBit(views[index].communicatedBits, rand.pos, (byte) (output[index] & (uint) byte.MaxValue));
    }
    ++rand.pos;
  }

  private void mpc_xor(uint[] state, uint[] input, int len, int players)
  {
    for (int index1 = 0; index1 < players; ++index1)
    {
      for (int index2 = 0; index2 < len; ++index2)
        state[index2 + (players + index1) * this.stateSizeWords] = state[index2 + (players + index1) * this.stateSizeWords] ^ input[index2 + index1 * this.stateSizeWords];
    }
  }

  private void mpc_matrix_mul(
    uint[] output,
    int outputOffset,
    uint[] state,
    int stateOffset,
    uint[] matrix,
    int matrixOffset,
    int players)
  {
    for (int index = 0; index < players; ++index)
      this.matrix_mul_offset(output, outputOffset + index * this.stateSizeWords, state, stateOffset + index * this.stateSizeWords, matrix, matrixOffset);
  }

  private void mpc_xor_constant(
    uint[] state,
    int stateOffset,
    uint[] input,
    int inOffset,
    int len)
  {
    for (int index = 0; index < len; ++index)
      state[index + stateOffset] = state[index + stateOffset] ^ input[index + inOffset];
  }

  private bool CreateRandomTape(
    byte[] seed,
    int seedOffset,
    byte[] salt,
    uint roundNumber,
    uint playerNumber,
    byte[] tape,
    int tapeLen)
  {
    if (tapeLen < this.digestSizeBytes)
      return false;
    this.digest.Update((byte) 2);
    this.digest.BlockUpdate(seed, seedOffset, this.seedSizeBytes);
    this.digest.OutputFinal(tape, 0, this.digestSizeBytes);
    this.digest.BlockUpdate(tape, 0, this.digestSizeBytes);
    this.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(roundNumber), 0, 2);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(playerNumber), 0, 2);
    this.digest.BlockUpdate(Pack.UInt32_To_LE((uint) tapeLen), 0, 2);
    this.digest.OutputFinal(tape, 0, tapeLen);
    return true;
  }

  private byte[] ComputeSeeds(
    uint[] privateKey,
    uint[] publicKey,
    uint[] plaintext,
    byte[] message)
  {
    byte[] output = new byte[this.seedSizeBytes * (this.numMPCParties * this.numMPCRounds) + PicnicEngine.saltSizeBytes];
    this.digest.BlockUpdate(Pack.UInt32_To_LE(privateKey), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(message, 0, message.Length);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(publicKey), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(plaintext), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE((uint) this.stateSizeBits), 0, 2);
    this.digest.OutputFinal(output, 0, this.seedSizeBytes * (this.numMPCParties * this.numMPCRounds) + PicnicEngine.saltSizeBytes);
    return output;
  }

  private void sign_picnic3(
    uint[] privateKey,
    uint[] pubKey,
    uint[] plaintext,
    byte[] message,
    Signature2 sig)
  {
    byte[] numArray1 = new byte[PicnicEngine.saltSizeBytes + this.seedSizeBytes];
    this.ComputeSaltAndRootSeed(numArray1, privateKey, pubKey, plaintext, message);
    byte[] rootSeed = Arrays.CopyOfRange(numArray1, PicnicEngine.saltSizeBytes, numArray1.Length);
    sig.salt = Arrays.CopyOfRange(numArray1, 0, PicnicEngine.saltSizeBytes);
    Tree tree1 = new Tree(this, (uint) this.numMPCRounds, this.seedSizeBytes);
    tree1.GenerateSeeds(rootSeed, sig.salt, 0U);
    byte[][] leaves = tree1.GetLeaves();
    uint leavesOffset = tree1.GetLeavesOffset();
    Tape[] tapeArray = new Tape[this.numMPCRounds];
    Tree[] treeArray = new Tree[this.numMPCRounds];
    for (uint index = 0; (long) index < (long) this.numMPCRounds; ++index)
    {
      tapeArray[(int) index] = new Tape(this);
      treeArray[(int) index] = new Tree(this, (uint) this.numMPCParties, this.seedSizeBytes);
      treeArray[(int) index].GenerateSeeds(leaves[(int) index + (int) leavesOffset], sig.salt, index);
      this.CreateRandomTapes(tapeArray[(int) index], treeArray[(int) index].GetLeaves(), treeArray[(int) index].GetLeavesOffset(), sig.salt, index);
    }
    byte[][] numArray2 = new byte[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      numArray2[index] = new byte[this.stateSizeWords * 4];
    byte[] numArray3 = new byte[(int) PicnicEngine.MAX_AUX_BYTES];
    for (int index = 0; index < this.numMPCRounds; ++index)
      tapeArray[index].ComputeAuxTape(numArray2[index]);
    byte[][][] numArray4 = new byte[this.numMPCRounds][][];
    for (int index1 = 0; index1 < this.numMPCRounds; ++index1)
    {
      numArray4[index1] = new byte[this.numMPCParties][];
      for (int index2 = 0; index2 < this.numMPCParties; ++index2)
        numArray4[index1][index2] = new byte[this.digestSizeBytes];
    }
    for (int t = 0; t < this.numMPCRounds; ++t)
    {
      for (uint index = 0; (long) index < (long) (this.numMPCParties - 1); ++index)
        this.commit(numArray4[t][(int) index], treeArray[t].GetLeaf(index), (byte[]) null, sig.salt, (uint) t, index);
      uint index3 = (uint) (this.numMPCParties - 1);
      this.GetAuxBits(numArray3, tapeArray[t]);
      this.commit(numArray4[t][(int) index3], treeArray[t].GetLeaf(index3), numArray3, sig.salt, (uint) t, index3);
    }
    Msg[] msgArray = new Msg[this.numMPCRounds];
    uint[] tmp_shares = new uint[this.stateSizeBits];
    for (int index = 0; index < this.numMPCRounds; ++index)
    {
      msgArray[index] = new Msg(this);
      uint[] uint32 = Pack.LE_To_UInt32(numArray2[index], 0, this.stateSizeWords);
      this.xor_array(uint32, uint32, privateKey, 0, this.stateSizeWords);
      if (this.SimulateOnline(uint32, tapeArray[index], tmp_shares, msgArray[index], plaintext, pubKey) != 0)
        Console.Error.Write("MPC simulation failed, aborting signature\n");
      Pack.UInt32_To_LE(uint32, numArray2[index], 0);
    }
    byte[][] Ch = new byte[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      Ch[index] = new byte[this.digestSizeBytes];
    byte[][] leafData = new byte[this.numMPCRounds][];
    for (int index = 0; index < this.numMPCRounds; ++index)
      leafData[index] = new byte[this.digestSizeBytes];
    for (int index = 0; index < this.numMPCRounds; ++index)
    {
      this.commit_h(Ch[index], numArray4[index]);
      this.commit_v(leafData[index], numArray2[index], msgArray[index]);
    }
    Tree tree2 = new Tree(this, (uint) this.numMPCRounds, this.digestSizeBytes);
    tree2.BuildMerkleTree(leafData, sig.salt);
    sig.challengeC = new uint[this.numOpenedRounds];
    sig.challengeP = new uint[this.numOpenedRounds];
    sig.challengeHash = new byte[this.digestSizeBytes];
    this.HCP(sig.challengeHash, sig.challengeC, sig.challengeP, Ch, tree2.nodes[0], sig.salt, pubKey, plaintext, message);
    int missingLeavesSize = this.numMPCRounds - this.numOpenedRounds;
    uint[] missingLeavesList = this.GetMissingLeavesList(sig.challengeC);
    int[] outputSizeBytes = new int[1];
    sig.cvInfo = tree2.OpenMerkleTree(missingLeavesList, (uint) missingLeavesSize, outputSizeBytes);
    sig.cvInfoLen = outputSizeBytes[0];
    sig.iSeedInfo = new byte[this.numMPCRounds * this.seedSizeBytes];
    sig.iSeedInfoLen = tree1.RevealSeeds(sig.challengeC, (uint) this.numOpenedRounds, sig.iSeedInfo, this.numMPCRounds * this.seedSizeBytes);
    sig.proofs = new Signature2.Proof2[this.numMPCRounds];
    for (uint index4 = 0; (long) index4 < (long) this.numMPCRounds; ++index4)
    {
      if (this.Contains(sig.challengeC, this.numOpenedRounds, index4))
      {
        sig.proofs[(int) index4] = new Signature2.Proof2(this);
        int index5 = PicnicEngine.IndexOf(sig.challengeC, this.numOpenedRounds, index4);
        uint[] hideList = new uint[1]
        {
          sig.challengeP[index5]
        };
        sig.proofs[(int) index4].seedInfo = new byte[this.numMPCParties * this.seedSizeBytes];
        sig.proofs[(int) index4].seedInfoLen = treeArray[(int) index4].RevealSeeds(hideList, 1U, sig.proofs[(int) index4].seedInfo, this.numMPCParties * this.seedSizeBytes);
        int num = this.numMPCParties - 1;
        if ((long) sig.challengeP[index5] != (long) num)
          this.GetAuxBits(sig.proofs[(int) index4].aux, tapeArray[(int) index4]);
        Array.Copy((Array) numArray2[(int) index4], 0, (Array) sig.proofs[(int) index4].input, 0, this.stateSizeBytes);
        Array.Copy((Array) msgArray[(int) index4].msgs[(int) sig.challengeP[index5]], 0, (Array) sig.proofs[(int) index4].msgs, 0, this.andSizeBytes);
        Array.Copy((Array) numArray4[(int) index4][(int) sig.challengeP[index5]], 0, (Array) sig.proofs[(int) index4].C, 0, this.digestSizeBytes);
      }
    }
  }

  private static int IndexOf(uint[] list, int len, uint value)
  {
    return Array.IndexOf<uint>(list, value, 0, len);
  }

  private uint[] GetMissingLeavesList(uint[] challengeC)
  {
    uint[] missingLeavesList = new uint[this.numMPCRounds - this.numOpenedRounds];
    uint index1 = 0;
    for (int index2 = 0; index2 < this.numMPCRounds; ++index2)
    {
      if (!this.Contains(challengeC, this.numOpenedRounds, (uint) index2))
      {
        missingLeavesList[(int) index1] = (uint) index2;
        ++index1;
      }
    }
    return missingLeavesList;
  }

  private void HCP(
    byte[] challengeHash,
    uint[] challengeC,
    uint[] challengeP,
    byte[][] Ch,
    byte[] hCv,
    byte[] salt,
    uint[] pubKey,
    uint[] plaintext,
    byte[] message)
  {
    for (int index = 0; index < this.numMPCRounds; ++index)
      this.digest.BlockUpdate(Ch[index], 0, this.digestSizeBytes);
    this.digest.BlockUpdate(hCv, 0, this.digestSizeBytes);
    this.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(pubKey), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(plaintext), 0, this.stateSizeBytes);
    this.digest.BlockUpdate(message, 0, message.Length);
    this.digest.OutputFinal(challengeHash, 0, this.digestSizeBytes);
    if (challengeC == null || challengeP == null)
      return;
    this.ExpandChallengeHash(challengeHash, challengeC, challengeP);
  }

  private static int BitsToChunks(int chunkLenBits, byte[] input, int inputLen, uint[] chunks)
  {
    if (chunkLenBits > inputLen * 8)
      return 0;
    int chunks1 = inputLen * 8 / chunkLenBits;
    for (int index1 = 0; index1 < chunks1; ++index1)
    {
      chunks[index1] = 0U;
      for (int index2 = 0; index2 < chunkLenBits; ++index2)
        chunks[index1] += (uint) PicnicUtilities.GetBit(input, index1 * chunkLenBits + index2) << index2;
    }
    return chunks1;
  }

  private static uint AppendUnique(uint[] list, uint value, uint position)
  {
    if (position == 0U)
    {
      list[(int) position] = value;
      return position + 1U;
    }
    for (int index = 0; (long) index < (long) position; ++index)
    {
      if ((int) list[index] == (int) value)
        return position;
    }
    list[(int) position] = value;
    return position + 1U;
  }

  private void ExpandChallengeHash(byte[] challengeHash, uint[] challengeC, uint[] challengeP)
  {
    uint num1 = PicnicUtilities.ceil_log2((uint) this.numMPCRounds);
    uint num2 = PicnicUtilities.ceil_log2((uint) this.numMPCParties);
    uint[] chunks1 = new uint[(long) (this.digestSizeBytes * 8) / (long) System.Math.Min(num1, num2)];
    byte[] numArray = new byte[(int) PicnicEngine.MAX_DIGEST_SIZE];
    Array.Copy((Array) challengeHash, 0, (Array) numArray, 0, this.digestSizeBytes);
    uint position = 0;
    while ((long) position < (long) this.numOpenedRounds)
    {
      int chunks2 = PicnicEngine.BitsToChunks((int) num1, numArray, this.digestSizeBytes, chunks1);
      for (int index = 0; index < chunks2; ++index)
      {
        if ((long) chunks1[index] < (long) this.numMPCRounds)
          position = PicnicEngine.AppendUnique(challengeC, chunks1[index], position);
        if ((long) position == (long) this.numOpenedRounds)
          break;
      }
      this.digest.Update((byte) 1);
      this.digest.BlockUpdate(numArray, 0, this.digestSizeBytes);
      this.digest.OutputFinal(numArray, 0, this.digestSizeBytes);
    }
    uint index1 = 0;
    while ((long) index1 < (long) this.numOpenedRounds)
    {
      int chunks3 = PicnicEngine.BitsToChunks((int) num2, numArray, this.digestSizeBytes, chunks1);
      for (int index2 = 0; index2 < chunks3; ++index2)
      {
        if ((long) chunks1[index2] < (long) this.numMPCParties)
        {
          challengeP[(int) index1] = chunks1[index2];
          ++index1;
        }
        if ((long) index1 == (long) this.numOpenedRounds)
          break;
      }
      this.digest.Update((byte) 1);
      this.digest.BlockUpdate(numArray, 0, this.digestSizeBytes);
      this.digest.OutputFinal(numArray, 0, this.digestSizeBytes);
    }
  }

  private void commit_h(byte[] digest_arr, byte[][] C)
  {
    for (int index = 0; index < this.numMPCParties; ++index)
      this.digest.BlockUpdate(C[index], 0, this.digestSizeBytes);
    this.digest.OutputFinal(digest_arr, 0, this.digestSizeBytes);
  }

  private void commit_v(byte[] digest_arr, byte[] input, Msg msg)
  {
    this.digest.BlockUpdate(input, 0, this.stateSizeBytes);
    for (int index = 0; index < this.numMPCParties; ++index)
    {
      int inLen = PicnicUtilities.NumBytes(msg.pos);
      this.digest.BlockUpdate(msg.msgs[index], 0, inLen);
    }
    this.digest.OutputFinal(digest_arr, 0, this.digestSizeBytes);
  }

  private int SimulateOnline(
    uint[] maskedKey,
    Tape tape,
    uint[] tmp_shares,
    Msg msg,
    uint[] plaintext,
    uint[] pubKey)
  {
    int num = 0;
    uint[] numArray1 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    uint[] numArray2 = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    KMatricesWithPointer kmatricesWithPointer1 = this._lowmcConstants.KMatrix(this, 0);
    this.matrix_mul(numArray1, maskedKey, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    this.xor_array(numArray2, numArray1, plaintext, 0, this.stateSizeWords);
    for (int round = 1; round <= this.numRounds; ++round)
    {
      this.TapesToWords(tmp_shares, tape);
      this.mpc_sbox(numArray2, tmp_shares, tape, msg);
      KMatricesWithPointer kmatricesWithPointer2 = this._lowmcConstants.LMatrix(this, round - 1);
      this.matrix_mul(numArray2, numArray2, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      KMatricesWithPointer kmatricesWithPointer3 = this._lowmcConstants.RConstant(this, round - 1);
      this.xor_array(numArray2, numArray2, kmatricesWithPointer3.GetData(), kmatricesWithPointer3.GetMatrixPointer(), this.stateSizeWords);
      KMatricesWithPointer kmatricesWithPointer4 = this._lowmcConstants.KMatrix(this, round);
      this.matrix_mul(numArray1, maskedKey, kmatricesWithPointer4.GetData(), kmatricesWithPointer4.GetMatrixPointer());
      this.xor_array(numArray2, numArray1, numArray2, 0, this.stateSizeWords);
    }
    if (!PicnicEngine.SubarrayEquals(numArray2, pubKey, this.stateSizeWords))
      num = -1;
    return num;
  }

  private void CreateRandomTapes(
    Tape tape,
    byte[][] seeds,
    uint seedsOffset,
    byte[] salt,
    uint t)
  {
    int outLen = 2 * this.andSizeBytes;
    for (uint n = 0; (long) n < (long) this.numMPCParties; ++n)
    {
      this.digest.BlockUpdate(seeds[(int) n + (int) seedsOffset], 0, this.seedSizeBytes);
      this.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
      this.digest.BlockUpdate(Pack.UInt32_To_LE(t), 0, 2);
      this.digest.BlockUpdate(Pack.UInt32_To_LE(n), 0, 2);
      this.digest.OutputFinal(tape.tapes[(int) n], 0, outLen);
    }
  }

  private static bool SubarrayEquals(byte[] a, byte[] b, int length)
  {
    if (a.Length < length || b.Length < length)
      return false;
    for (int index = 0; index < length; ++index)
    {
      if ((int) a[index] != (int) b[index])
        return false;
    }
    return true;
  }

  private static bool SubarrayEquals(uint[] a, uint[] b, int length)
  {
    if (a.Length < length || b.Length < length)
      return false;
    for (int index = 0; index < length; ++index)
    {
      if ((int) a[index] != (int) b[index])
        return false;
    }
    return true;
  }

  private static uint Extend(uint bit) => (uint) ~((int) bit - 1);

  private void WordToMsgs(uint w, Msg msg)
  {
    for (int bitNumber = 0; bitNumber < this.numMPCParties; ++bitNumber)
    {
      uint bit = PicnicUtilities.GetBit(w, bitNumber);
      PicnicUtilities.SetBit(msg.msgs[bitNumber], msg.pos, (byte) bit);
    }
    ++msg.pos;
  }

  private uint mpc_AND(uint a, uint b, uint mask_a, uint mask_b, Tape tape, Msg msg)
  {
    uint word = tape.TapesToWord();
    uint num = (uint) ((int) PicnicEngine.Extend(a) & (int) mask_b ^ (int) PicnicEngine.Extend(b) & (int) mask_a) ^ word;
    if (msg.unopened >= 0)
    {
      uint bit = (uint) PicnicUtilities.GetBit(msg.msgs[msg.unopened], msg.pos);
      num = PicnicUtilities.SetBit(num, msg.unopened, bit);
    }
    this.WordToMsgs(num, msg);
    return PicnicUtilities.Parity16(num) ^ a & b;
  }

  private void mpc_sbox(uint[] state, uint[] state_masks, Tape tape, Msg msg)
  {
    for (int bitNumber = 0; bitNumber < this.numSboxes * 3; bitNumber += 3)
    {
      uint bitFromWordArray1 = PicnicUtilities.GetBitFromWordArray(state, bitNumber + 2);
      uint stateMask1 = state_masks[bitNumber + 2];
      uint bitFromWordArray2 = PicnicUtilities.GetBitFromWordArray(state, bitNumber + 1);
      uint stateMask2 = state_masks[bitNumber + 1];
      uint bitFromWordArray3 = PicnicUtilities.GetBitFromWordArray(state, bitNumber);
      uint stateMask3 = state_masks[bitNumber];
      uint num1 = this.mpc_AND(bitFromWordArray1, bitFromWordArray2, stateMask1, stateMask2, tape, msg);
      uint num2 = this.mpc_AND(bitFromWordArray2, bitFromWordArray3, stateMask2, stateMask3, tape, msg);
      uint num3 = this.mpc_AND(bitFromWordArray3, bitFromWordArray1, stateMask3, stateMask1, tape, msg);
      uint val1 = bitFromWordArray1 ^ num2;
      uint val2 = bitFromWordArray1 ^ bitFromWordArray2 ^ num3;
      uint val3 = bitFromWordArray1 ^ bitFromWordArray2 ^ bitFromWordArray3 ^ num1;
      PicnicUtilities.SetBitInWordArray(state, bitNumber + 2, val1);
      PicnicUtilities.SetBitInWordArray(state, bitNumber + 1, val2);
      PicnicUtilities.SetBitInWordArray(state, bitNumber, val3);
    }
  }

  internal void aux_mpc_sbox(uint[] input, uint[] output, Tape tape)
  {
    for (int bitNumber = 0; bitNumber < this.numSboxes * 3; bitNumber += 3)
    {
      uint bitFromWordArray1 = PicnicUtilities.GetBitFromWordArray(input, bitNumber + 2);
      uint bitFromWordArray2 = PicnicUtilities.GetBitFromWordArray(input, bitNumber + 1);
      uint bitFromWordArray3 = PicnicUtilities.GetBitFromWordArray(input, bitNumber);
      uint bitFromWordArray4 = PicnicUtilities.GetBitFromWordArray(output, bitNumber + 2);
      int bitFromWordArray5 = (int) PicnicUtilities.GetBitFromWordArray(output, bitNumber + 1);
      uint fresh_output_mask1 = PicnicUtilities.GetBitFromWordArray(output, bitNumber) ^ bitFromWordArray1 ^ bitFromWordArray2 ^ bitFromWordArray3;
      uint fresh_output_mask2 = bitFromWordArray4 ^ bitFromWordArray1;
      int num = (int) bitFromWordArray1;
      uint fresh_output_mask3 = (uint) (bitFromWordArray5 ^ num) ^ bitFromWordArray2;
      this.aux_mpc_AND(bitFromWordArray1, bitFromWordArray2, fresh_output_mask1, tape);
      this.aux_mpc_AND(bitFromWordArray2, bitFromWordArray3, fresh_output_mask2, tape);
      this.aux_mpc_AND(bitFromWordArray3, bitFromWordArray1, fresh_output_mask3, tape);
    }
  }

  private void aux_mpc_AND(uint mask_a, uint mask_b, uint fresh_output_mask, Tape tape)
  {
    int index = this.numMPCParties - 1;
    uint num1 = PicnicUtilities.Parity16(tape.TapesToWord()) ^ (uint) PicnicUtilities.GetBit(tape.tapes[index], tape.pos - 1);
    uint num2 = mask_a & mask_b ^ num1 ^ fresh_output_mask;
    PicnicUtilities.SetBit(tape.tapes[index], tape.pos - 1, (byte) (num2 & (uint) byte.MaxValue));
  }

  private bool Contains(uint[] list, int len, uint value)
  {
    for (int index = 0; index < len; ++index)
    {
      if ((int) list[index] == (int) value)
        return true;
    }
    return false;
  }

  private void TapesToWords(uint[] shares, Tape tape)
  {
    for (int index = 0; index < this.stateSizeBits; ++index)
      shares[index] = tape.TapesToWord();
  }

  private void GetAuxBits(byte[] output, Tape tape)
  {
    byte[] tape1 = tape.tapes[this.numMPCParties - 1];
    int stateSizeBits = this.stateSizeBits;
    int num1 = 0;
    int num2 = 0;
    for (int index1 = 0; index1 < this.numRounds; ++index1)
    {
      num2 += stateSizeBits;
      for (int index2 = 0; index2 < stateSizeBits; ++index2)
        PicnicUtilities.SetBit(output, num1++, PicnicUtilities.GetBit(tape1, num2++));
    }
  }

  private void commit(byte[] digest_arr, byte[] seed, byte[] aux, byte[] salt, uint t, uint j)
  {
    this.digest.BlockUpdate(seed, 0, this.seedSizeBytes);
    if (aux != null)
      this.digest.BlockUpdate(aux, 0, this.andSizeBytes);
    this.digest.BlockUpdate(salt, 0, PicnicEngine.saltSizeBytes);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(t), 0, 2);
    this.digest.BlockUpdate(Pack.UInt32_To_LE(j), 0, 2);
    this.digest.OutputFinal(digest_arr, 0, this.digestSizeBytes);
  }

  private void ComputeSaltAndRootSeed(
    byte[] saltAndRoot,
    uint[] privateKey,
    uint[] pubKey,
    uint[] plaintext,
    byte[] message)
  {
    byte[] numArray1 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    byte[] numArray2 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    byte[] numArray3 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    Pack.UInt32_To_LE(privateKey, numArray1, 0);
    Pack.UInt32_To_LE(pubKey, numArray2, 0);
    Pack.UInt32_To_LE(plaintext, numArray3, 0);
    byte[] input1 = Arrays.CopyOfRange(numArray1, 0, this.stateSizeBytes);
    byte[] input2 = Arrays.CopyOfRange(numArray2, 0, this.stateSizeBytes);
    byte[] input3 = Arrays.CopyOfRange(numArray3, 0, this.stateSizeBytes);
    this.digest.BlockUpdate(input1, 0, this.stateSizeBytes);
    this.digest.BlockUpdate(message, 0, message.Length);
    this.digest.BlockUpdate(input2, 0, this.stateSizeBytes);
    this.digest.BlockUpdate(input3, 0, this.stateSizeBytes);
    this.digest.BlockUpdate(Pack.UInt16_To_LE((ushort) (this.stateSizeBits & (int) ushort.MaxValue)), 0, 2);
    this.digest.OutputFinal(saltAndRoot, 0, saltAndRoot.Length);
  }

  private static bool is_picnic3(int parameters)
  {
    return parameters == 7 || parameters == 8 || parameters == 9;
  }

  internal void crypto_sign_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    byte[] numArray1 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    byte[] numArray2 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    byte[] numArray3 = new byte[(int) PicnicEngine.PICNIC_MAX_LOWMC_BLOCK_SIZE];
    this.picnic_keygen(numArray1, numArray2, numArray3, random);
    this.picnic_write_public_key(numArray2, numArray1, pk);
    this.picnic_write_private_key(numArray3, numArray2, numArray1, sk);
  }

  private int picnic_write_private_key(
    byte[] data,
    byte[] ciphertext,
    byte[] plaintext,
    byte[] buf)
  {
    int num = 1 + 3 * this.stateSizeBytes;
    if (buf.Length < num)
    {
      Console.Error.Write("Failed writing private key!");
      return -1;
    }
    buf[0] = (byte) this.parameters;
    Array.Copy((Array) data, 0, (Array) buf, 1, this.stateSizeBytes);
    Array.Copy((Array) ciphertext, 0, (Array) buf, 1 + this.stateSizeBytes, this.stateSizeBytes);
    Array.Copy((Array) plaintext, 0, (Array) buf, 1 + 2 * this.stateSizeBytes, this.stateSizeBytes);
    return num;
  }

  private int picnic_write_public_key(byte[] ciphertext, byte[] plaintext, byte[] buf)
  {
    int num = 1 + 2 * this.stateSizeBytes;
    if (buf.Length < num)
    {
      Console.Error.Write("Failed writing public key!");
      return -1;
    }
    buf[0] = (byte) this.parameters;
    Array.Copy((Array) ciphertext, 0, (Array) buf, 1, this.stateSizeBytes);
    Array.Copy((Array) plaintext, 0, (Array) buf, 1 + this.stateSizeBytes, this.stateSizeBytes);
    return num;
  }

  private void picnic_keygen(
    byte[] plaintext_bytes,
    byte[] ciphertext_bytes,
    byte[] data_bytes,
    SecureRandom random)
  {
    uint[] numArray1 = new uint[data_bytes.Length / 4];
    uint[] numArray2 = new uint[plaintext_bytes.Length / 4];
    uint[] numArray3 = new uint[ciphertext_bytes.Length / 4];
    random.NextBytes(data_bytes, 0, this.stateSizeBytes);
    PicnicUtilities.ZeroTrailingBits(data_bytes, this.stateSizeBits);
    Pack.LE_To_UInt32(data_bytes, 0, numArray1);
    random.NextBytes(plaintext_bytes, 0, this.stateSizeBytes);
    PicnicUtilities.ZeroTrailingBits(plaintext_bytes, this.stateSizeBits);
    Pack.LE_To_UInt32(plaintext_bytes, 0, numArray2);
    this.LowMCEnc(numArray2, numArray3, numArray1);
    Pack.UInt32_To_LE(numArray1, data_bytes, 0);
    Pack.UInt32_To_LE(numArray2, plaintext_bytes, 0);
    Pack.UInt32_To_LE(numArray3, ciphertext_bytes, 0);
  }

  private void LowMCEnc(uint[] plaintext, uint[] output, uint[] key)
  {
    uint[] numArray = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    if (plaintext != output)
      Array.Copy((Array) plaintext, 0, (Array) output, 0, this.stateSizeWords);
    KMatricesWithPointer kmatricesWithPointer1 = this._lowmcConstants.KMatrix(this, 0);
    this.matrix_mul(numArray, key, kmatricesWithPointer1.GetData(), kmatricesWithPointer1.GetMatrixPointer());
    this.xor_array(output, output, numArray, 0, this.stateSizeWords);
    for (int round = 1; round <= this.numRounds; ++round)
    {
      KMatricesWithPointer kmatricesWithPointer2 = this._lowmcConstants.KMatrix(this, round);
      this.matrix_mul(numArray, key, kmatricesWithPointer2.GetData(), kmatricesWithPointer2.GetMatrixPointer());
      this.Substitution(output);
      KMatricesWithPointer kmatricesWithPointer3 = this._lowmcConstants.LMatrix(this, round - 1);
      this.matrix_mul(output, output, kmatricesWithPointer3.GetData(), kmatricesWithPointer3.GetMatrixPointer());
      KMatricesWithPointer kmatricesWithPointer4 = this._lowmcConstants.RConstant(this, round - 1);
      this.xor_array(output, output, kmatricesWithPointer4.GetData(), kmatricesWithPointer4.GetMatrixPointer(), this.stateSizeWords);
      this.xor_array(output, output, numArray, 0, this.stateSizeWords);
    }
  }

  private void Substitution(uint[] state)
  {
    for (int bitNumber = 0; bitNumber < this.numSboxes * 3; bitNumber += 3)
    {
      uint bitFromWordArray1 = PicnicUtilities.GetBitFromWordArray(state, bitNumber + 2);
      uint bitFromWordArray2 = PicnicUtilities.GetBitFromWordArray(state, bitNumber + 1);
      uint bitFromWordArray3 = PicnicUtilities.GetBitFromWordArray(state, bitNumber);
      PicnicUtilities.SetBitInWordArray(state, bitNumber + 2, bitFromWordArray1 ^ bitFromWordArray2 & bitFromWordArray3);
      PicnicUtilities.SetBitInWordArray(state, bitNumber + 1, (uint) ((int) bitFromWordArray1 ^ (int) bitFromWordArray2 ^ (int) bitFromWordArray1 & (int) bitFromWordArray3));
      PicnicUtilities.SetBitInWordArray(state, bitNumber, (uint) ((int) bitFromWordArray1 ^ (int) bitFromWordArray2 ^ (int) bitFromWordArray3 ^ (int) bitFromWordArray1 & (int) bitFromWordArray2));
    }
  }

  private void xor_three(uint[] output, uint[] in1, uint[] in2, uint[] in3, int lenBytes)
  {
    int stateSizeWords = this.stateSizeWords;
    for (int index = 0; index < stateSizeWords; ++index)
      output[index] = in1[index] ^ in2[index] ^ in3[index];
  }

  internal void xor_array(uint[] output, uint[] in1, uint[] in2, int in2_offset, int length)
  {
    for (int index = 0; index < length; ++index)
      output[index] = in1[index] ^ in2[index + in2_offset];
  }

  internal void matrix_mul(uint[] output, uint[] state, uint[] matrix, int matrixOffset)
  {
    this.matrix_mul_offset(output, 0, state, 0, matrix, matrixOffset);
  }

  internal void matrix_mul_offset(
    uint[] output,
    int outputOffset,
    uint[] state,
    int stateOffset,
    uint[] matrix,
    int matrixOffset)
  {
    uint[] numArray = new uint[(int) PicnicEngine.LOWMC_MAX_WORDS];
    numArray[this.stateSizeWords - 1] = 0U;
    int num1 = this.stateSizeBits / PicnicEngine.WORD_SIZE_BITS;
    int num2 = this.stateSizeWords * PicnicEngine.WORD_SIZE_BITS - this.stateSizeBits;
    uint num3 = Bits.BitPermuteStepSimple(Bits.BitPermuteStepSimple(Bits.BitPermuteStepSimple(uint.MaxValue >> num2, 1431655765U /*0x55555555*/, 1), 858993459U /*0x33333333*/, 2), 252645135U, 4);
    for (int bitNumber = 0; bitNumber < this.stateSizeBits; ++bitNumber)
    {
      uint x = 0;
      for (int index = 0; index < num1; ++index)
      {
        int num4 = bitNumber * this.stateSizeWords + index;
        x ^= state[index + stateOffset] & matrix[matrixOffset + num4];
      }
      if (num2 > 0)
      {
        int num5 = bitNumber * this.stateSizeWords + num1;
        x ^= state[stateOffset + num1] & matrix[matrixOffset + num5] & num3;
      }
      PicnicUtilities.SetBit(numArray, bitNumber, PicnicUtilities.Parity32(x));
    }
    Array.Copy((Array) numArray, 0, (Array) output, outputOffset, this.stateSizeWords);
  }
}
