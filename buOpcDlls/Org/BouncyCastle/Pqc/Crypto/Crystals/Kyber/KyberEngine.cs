// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber.KyberEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Crystals.Kyber;

internal class KyberEngine
{
  private SecureRandom m_random;
  private KyberIndCpa m_indCpa;
  public const int N = 256 /*0x0100*/;
  public const int Q = 3329;
  public const int QInv = 62209;
  public static int SymBytes = 32 /*0x20*/;
  private const int SharedSecretBytes = 32 /*0x20*/;
  public static int PolyBytes = 384;
  public const int Eta2 = 2;
  public int IndCpaMsgBytes = KyberEngine.SymBytes;

  public Symmetric Symmetric { get; private set; }

  public int K { get; private set; }

  public int PolyVecBytes { get; private set; }

  public int PolyCompressedBytes { get; private set; }

  public int PolyVecCompressedBytes { get; private set; }

  public int Eta1 { get; private set; }

  public int IndCpaPublicKeyBytes { get; private set; }

  public int IndCpaSecretKeyBytes { get; private set; }

  public int IndCpaBytes { get; private set; }

  public int PublicKeyBytes { get; private set; }

  public int SecretKeyBytes { get; private set; }

  public int CipherTextBytes { get; private set; }

  public int CryptoBytes { get; private set; }

  public int CryptoSecretKeyBytes { get; private set; }

  public int CryptoPublicKeyBytes { get; private set; }

  public int CryptoCipherTextBytes { get; private set; }

  public KyberEngine(int k, bool usingAes)
  {
    this.K = k;
    switch (k)
    {
      case 2:
        this.Eta1 = 3;
        this.PolyCompressedBytes = 128 /*0x80*/;
        this.PolyVecCompressedBytes = this.K * 320;
        break;
      case 3:
        this.Eta1 = 2;
        this.PolyCompressedBytes = 128 /*0x80*/;
        this.PolyVecCompressedBytes = this.K * 320;
        break;
      case 4:
        this.Eta1 = 2;
        this.PolyCompressedBytes = 160 /*0xA0*/;
        this.PolyVecCompressedBytes = this.K * 352;
        break;
    }
    this.PolyVecBytes = k * KyberEngine.PolyBytes;
    this.IndCpaPublicKeyBytes = this.PolyVecBytes + KyberEngine.SymBytes;
    this.IndCpaSecretKeyBytes = this.PolyVecBytes;
    this.IndCpaBytes = this.PolyVecCompressedBytes + this.PolyCompressedBytes;
    this.PublicKeyBytes = this.IndCpaPublicKeyBytes;
    this.SecretKeyBytes = this.IndCpaSecretKeyBytes + this.IndCpaPublicKeyBytes + 2 * KyberEngine.SymBytes;
    this.CipherTextBytes = this.IndCpaBytes;
    this.CryptoBytes = 32 /*0x20*/;
    this.CryptoSecretKeyBytes = this.SecretKeyBytes;
    this.CryptoPublicKeyBytes = this.PublicKeyBytes;
    this.CryptoCipherTextBytes = this.CipherTextBytes;
    this.Symmetric = !usingAes ? (Symmetric) new Symmetric.ShakeSymmetric() : (Symmetric) new Symmetric.AesSymmetric();
    this.m_indCpa = new KyberIndCpa(this);
  }

  internal void Init(SecureRandom random) => this.m_random = random;

  internal void GenerateKemKeyPair(
    out byte[] t,
    out byte[] rho,
    out byte[] s,
    out byte[] hpk,
    out byte[] nonce)
  {
    byte[] pk;
    byte[] sk;
    this.m_indCpa.GenerateKeyPair(out pk, out sk);
    s = Arrays.CopyOfRange(sk, 0, this.IndCpaSecretKeyBytes);
    hpk = new byte[32 /*0x20*/];
    this.Symmetric.Hash_h(hpk, pk, 0);
    nonce = new byte[KyberEngine.SymBytes];
    this.m_random.NextBytes(nonce);
    t = Arrays.CopyOfRange(pk, 0, this.IndCpaPublicKeyBytes - 32 /*0x20*/);
    rho = Arrays.CopyOfRange(pk, this.IndCpaPublicKeyBytes - 32 /*0x20*/, this.IndCpaPublicKeyBytes);
  }

  internal void KemEncrypt(byte[] cipherText, byte[] sharedSecret, byte[] pk)
  {
    byte[] numArray1 = new byte[KyberEngine.SymBytes];
    byte[] numArray2 = new byte[2 * KyberEngine.SymBytes];
    byte[] numArray3 = new byte[2 * KyberEngine.SymBytes];
    this.m_random.NextBytes(numArray1, 0, KyberEngine.SymBytes);
    this.Symmetric.Hash_h(numArray1, numArray1, 0);
    Array.Copy((Array) numArray1, 0, (Array) numArray2, 0, KyberEngine.SymBytes);
    this.Symmetric.Hash_h(numArray2, pk, KyberEngine.SymBytes);
    this.Symmetric.Hash_g(numArray3, numArray2);
    this.m_indCpa.Encrypt(cipherText, Arrays.CopyOfRange(numArray2, 0, KyberEngine.SymBytes), pk, Arrays.CopyOfRange(numArray3, KyberEngine.SymBytes, 2 * KyberEngine.SymBytes));
    this.Symmetric.Hash_h(numArray3, cipherText, KyberEngine.SymBytes);
    this.Symmetric.Kdf(sharedSecret, numArray3);
  }

  internal void KemDecrypt(byte[] sharedSecret, byte[] cipherText, byte[] secretKey)
  {
    byte[] numArray1 = new byte[2 * KyberEngine.SymBytes];
    byte[] numArray2 = new byte[2 * KyberEngine.SymBytes];
    byte[] numArray3 = new byte[this.CipherTextBytes];
    byte[] pk = Arrays.CopyOfRange(secretKey, this.IndCpaSecretKeyBytes, secretKey.Length);
    this.m_indCpa.Decrypt(numArray1, cipherText, secretKey);
    Array.Copy((Array) secretKey, this.SecretKeyBytes - 2 * KyberEngine.SymBytes, (Array) numArray1, KyberEngine.SymBytes, KyberEngine.SymBytes);
    this.Symmetric.Hash_g(numArray2, numArray1);
    this.m_indCpa.Encrypt(numArray3, Arrays.CopyOf(numArray1, KyberEngine.SymBytes), pk, Arrays.CopyOfRange(numArray2, KyberEngine.SymBytes, numArray2.Length));
    bool b = !Arrays.FixedTimeEquals(cipherText, numArray3);
    this.Symmetric.Hash_h(numArray2, cipherText, KyberEngine.SymBytes);
    this.CMov(numArray2, Arrays.CopyOfRange(secretKey, this.SecretKeyBytes - KyberEngine.SymBytes, this.SecretKeyBytes), KyberEngine.SymBytes, b);
    this.Symmetric.Kdf(sharedSecret, numArray2);
  }

  private void CMov(byte[] r, byte[] x, int len, bool b)
  {
    if (b)
      Array.Copy((Array) x, 0, (Array) r, 0, len);
    else
      Array.Copy((Array) r, 0, (Array) r, 0, len);
  }

  internal void RandomBytes(byte[] buf, int len) => this.m_random.NextBytes(buf, 0, len);
}
