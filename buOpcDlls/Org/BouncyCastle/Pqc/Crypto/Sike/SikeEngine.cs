// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Sike.SikeEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Sike;

internal sealed class SikeEngine
{
  internal Internal param;
  internal Isogeny isogeny;
  internal Fpx fpx;
  private Sidh sidh;
  private SidhCompressed sidhCompressed;
  private bool isCompressed;

  internal uint GetDefaultSessionKeySize() => this.param.MSG_BYTES * 8U;

  internal int GetCipherTextSize() => this.param.CRYPTO_CIPHERTEXTBYTES;

  internal uint GetPrivateKeySize() => this.param.CRYPTO_SECRETKEYBYTES;

  internal uint GetPublicKeySize() => this.param.CRYPTO_PUBLICKEYBYTES;

  internal SikeEngine(int ver, bool isCompressed, SecureRandom random)
  {
    this.isCompressed = isCompressed;
    switch (ver)
    {
      case 434:
        this.param = (Internal) new P434(isCompressed);
        break;
      case 503:
        this.param = (Internal) new P503(isCompressed);
        break;
      case 610:
        this.param = (Internal) new P610(isCompressed);
        break;
      case 751:
        this.param = (Internal) new P751(isCompressed);
        break;
    }
    this.fpx = new Fpx(this);
    this.isogeny = new Isogeny(this);
    if (isCompressed)
      this.sidhCompressed = new SidhCompressed(this);
    this.sidh = new Sidh(this);
  }

  internal int crypto_kem_keypair(byte[] pk, byte[] sk, SecureRandom random)
  {
    random.NextBytes(sk, 0, (int) this.param.MSG_BYTES);
    if (this.isCompressed)
    {
      random.NextBytes(sk, (int) this.param.MSG_BYTES, (int) this.param.SECRETKEY_A_BYTES);
      sk[(int) this.param.MSG_BYTES] &= (byte) 254;
      sk[(int) this.param.MSG_BYTES + (int) this.param.SECRETKEY_A_BYTES - 1] &= (byte) this.param.MASK_ALICE;
      int num = (int) this.sidhCompressed.EphemeralKeyGeneration_A_extended(sk, pk);
      Array.Copy((Array) pk, 0L, (Array) sk, (long) (this.param.MSG_BYTES + this.param.SECRETKEY_A_BYTES), (long) this.param.CRYPTO_PUBLICKEYBYTES);
    }
    else
    {
      random.NextBytes(sk, (int) this.param.MSG_BYTES, (int) this.param.SECRETKEY_B_BYTES);
      sk[(int) this.param.MSG_BYTES + (int) this.param.SECRETKEY_B_BYTES - 1] &= (byte) this.param.MASK_BOB;
      this.sidh.EphemeralKeyGeneration_B(sk, pk);
      Array.Copy((Array) pk, 0L, (Array) sk, (long) (this.param.MSG_BYTES + this.param.SECRETKEY_B_BYTES), (long) this.param.CRYPTO_PUBLICKEYBYTES);
    }
    return 0;
  }

  internal int crypto_kem_enc(byte[] ct, byte[] ss, byte[] pk, SecureRandom random)
  {
    if (this.isCompressed)
    {
      byte[] numArray1 = new byte[(int) this.param.SECRETKEY_B_BYTES];
      byte[] numArray2 = new byte[(int) this.param.FP2_ENCODED_BYTES];
      byte[] output = new byte[(int) this.param.MSG_BYTES];
      byte[] numArray3 = new byte[(long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES];
      random.NextBytes(numArray3, 0, (int) this.param.MSG_BYTES);
      Array.Copy((Array) pk, 0L, (Array) numArray3, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_PUBLICKEYBYTES);
      IXof xof = (IXof) new ShakeDigest(256 /*0x0100*/);
      xof.BlockUpdate(numArray3, 0, (int) this.param.CRYPTO_PUBLICKEYBYTES + (int) this.param.MSG_BYTES);
      xof.OutputFinal(numArray1, 0, (int) this.param.SECRETKEY_B_BYTES);
      this.sidhCompressed.FormatPrivKey_B(numArray1);
      int num1 = (int) this.sidhCompressed.EphemeralKeyGeneration_B_extended(numArray1, ct, 1U);
      int num2 = (int) this.sidhCompressed.EphemeralSecretAgreement_B(numArray1, pk, numArray2);
      xof.BlockUpdate(numArray2, 0, (int) this.param.FP2_ENCODED_BYTES);
      xof.OutputFinal(output, 0, (int) this.param.MSG_BYTES);
      for (int index = 0; (long) index < (long) this.param.MSG_BYTES; ++index)
        ct[(long) index + (long) this.param.PARTIALLY_COMPRESSED_CHUNK_CT] = (byte) ((uint) numArray3[index] ^ (uint) output[index]);
      Array.Copy((Array) ct, 0L, (Array) numArray3, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_CIPHERTEXTBYTES);
      xof.BlockUpdate(numArray3, 0, (int) ((long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES));
      xof.OutputFinal(ss, 0, (int) this.param.CRYPTO_BYTES);
      return 0;
    }
    byte[] numArray4 = new byte[(int) this.param.SECRETKEY_A_BYTES];
    byte[] numArray5 = new byte[(int) this.param.FP2_ENCODED_BYTES];
    byte[] output1 = new byte[(int) this.param.MSG_BYTES];
    byte[] numArray6 = new byte[(long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES];
    random.NextBytes(numArray6, 0, (int) this.param.MSG_BYTES);
    Array.Copy((Array) pk, 0L, (Array) numArray6, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_PUBLICKEYBYTES);
    IXof xof1 = (IXof) new ShakeDigest(256 /*0x0100*/);
    xof1.BlockUpdate(numArray6, 0, (int) this.param.CRYPTO_PUBLICKEYBYTES + (int) this.param.MSG_BYTES);
    xof1.OutputFinal(numArray4, 0, (int) this.param.SECRETKEY_A_BYTES);
    numArray4[(int) this.param.SECRETKEY_A_BYTES - 1] &= (byte) this.param.MASK_ALICE;
    this.sidh.EphemeralKeyGeneration_A(numArray4, ct);
    this.sidh.EphemeralSecretAgreement_A(numArray4, pk, numArray5);
    xof1.BlockUpdate(numArray5, 0, (int) this.param.FP2_ENCODED_BYTES);
    xof1.OutputFinal(output1, 0, (int) this.param.MSG_BYTES);
    for (int index = 0; (long) index < (long) this.param.MSG_BYTES; ++index)
      ct[(long) index + (long) this.param.CRYPTO_PUBLICKEYBYTES] = (byte) ((uint) numArray6[index] ^ (uint) output1[index]);
    Array.Copy((Array) ct, 0L, (Array) numArray6, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_CIPHERTEXTBYTES);
    xof1.BlockUpdate(numArray6, 0, (int) ((long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES));
    xof1.OutputFinal(ss, 0, (int) this.param.CRYPTO_BYTES);
    return 0;
  }

  internal int crypto_kem_dec(byte[] ss, byte[] ct, byte[] sk)
  {
    if (this.isCompressed)
    {
      byte[] numArray1 = new byte[(int) this.param.SECRETKEY_B_BYTES];
      byte[] numArray2 = new byte[(int) this.param.FP2_ENCODED_BYTES + 2 * (int) this.param.FP2_ENCODED_BYTES + (int) this.param.SECRETKEY_A_BYTES];
      byte[] output = new byte[(int) this.param.MSG_BYTES];
      byte[] numArray3 = new byte[(long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES];
      byte[] tphiBKA_t = numArray2;
      int num = (int) this.sidhCompressed.EphemeralSecretAgreement_A_extended(sk, this.param.MSG_BYTES, ct, numArray2, 1U);
      IXof xof = (IXof) new ShakeDigest(256 /*0x0100*/);
      xof.BlockUpdate(numArray2, 0, (int) this.param.FP2_ENCODED_BYTES);
      xof.OutputFinal(output, 0, (int) this.param.MSG_BYTES);
      for (int index = 0; (long) index < (long) this.param.MSG_BYTES; ++index)
        numArray3[index] = (byte) ((uint) ct[(long) index + (long) this.param.PARTIALLY_COMPRESSED_CHUNK_CT] ^ (uint) output[index]);
      Array.Copy((Array) sk, (long) (this.param.MSG_BYTES + this.param.SECRETKEY_A_BYTES), (Array) numArray3, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_PUBLICKEYBYTES);
      xof.BlockUpdate(numArray3, 0, (int) this.param.CRYPTO_PUBLICKEYBYTES + (int) this.param.MSG_BYTES);
      xof.OutputFinal(numArray1, 0, (int) this.param.SECRETKEY_B_BYTES);
      this.sidhCompressed.FormatPrivKey_B(numArray1);
      byte selector = this.sidhCompressed.validate_ciphertext(numArray1, ct, sk, this.param.MSG_BYTES + this.param.SECRETKEY_A_BYTES + this.param.CRYPTO_PUBLICKEYBYTES, tphiBKA_t, this.param.FP2_ENCODED_BYTES);
      this.fpx.ct_cmov(numArray3, sk, this.param.MSG_BYTES, selector);
      Array.Copy((Array) ct, 0L, (Array) numArray3, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_CIPHERTEXTBYTES);
      xof.BlockUpdate(numArray3, 0, (int) ((long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES));
      xof.OutputFinal(ss, 0, (int) this.param.CRYPTO_BYTES);
      return 0;
    }
    byte[] numArray4 = new byte[(int) this.param.SECRETKEY_A_BYTES];
    byte[] numArray5 = new byte[(int) this.param.FP2_ENCODED_BYTES];
    byte[] output1 = new byte[(int) this.param.MSG_BYTES];
    byte[] numArray6 = new byte[(int) this.param.CRYPTO_PUBLICKEYBYTES];
    byte[] numArray7 = new byte[(long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES];
    this.sidh.EphemeralSecretAgreement_B(sk, ct, numArray5);
    IXof xof1 = (IXof) new ShakeDigest(256 /*0x0100*/);
    xof1.BlockUpdate(numArray5, 0, (int) this.param.FP2_ENCODED_BYTES);
    xof1.OutputFinal(output1, 0, (int) this.param.MSG_BYTES);
    for (int index = 0; (long) index < (long) this.param.MSG_BYTES; ++index)
      numArray7[index] = (byte) ((uint) ct[(long) index + (long) this.param.CRYPTO_PUBLICKEYBYTES] ^ (uint) output1[index]);
    Array.Copy((Array) sk, (long) (this.param.MSG_BYTES + this.param.SECRETKEY_B_BYTES), (Array) numArray7, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_PUBLICKEYBYTES);
    xof1.BlockUpdate(numArray7, 0, (int) this.param.CRYPTO_PUBLICKEYBYTES + (int) this.param.MSG_BYTES);
    xof1.OutputFinal(numArray4, 0, (int) this.param.SECRETKEY_A_BYTES);
    numArray4[(int) this.param.SECRETKEY_A_BYTES - 1] &= (byte) this.param.MASK_ALICE;
    this.sidh.EphemeralKeyGeneration_A(numArray4, numArray6);
    byte selector1 = this.fpx.ct_compare(numArray6, ct, this.param.CRYPTO_PUBLICKEYBYTES);
    this.fpx.ct_cmov(numArray7, sk, this.param.MSG_BYTES, selector1);
    Array.Copy((Array) ct, 0L, (Array) numArray7, (long) this.param.MSG_BYTES, (long) this.param.CRYPTO_CIPHERTEXTBYTES);
    xof1.BlockUpdate(numArray7, 0, (int) ((long) this.param.CRYPTO_CIPHERTEXTBYTES + (long) this.param.MSG_BYTES));
    xof1.OutputFinal(ss, 0, (int) this.param.CRYPTO_BYTES);
    return 0;
  }
}
