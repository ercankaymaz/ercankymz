// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsSecret
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public class BcTlsSecret : AbstractTlsSecret
{
  private static readonly byte[] Ssl3Const = BcTlsSecret.GenerateSsl3Constants();
  protected readonly BcTlsCrypto m_crypto;

  public static BcTlsSecret Convert(BcTlsCrypto crypto, TlsSecret secret)
  {
    switch (secret)
    {
      case BcTlsSecret bcTlsSecret:
        return bcTlsSecret;
      case AbstractTlsSecret other:
        return crypto.AdoptLocalSecret(AbstractTlsSecret.CopyData(other));
      default:
        throw new ArgumentException("unrecognized TlsSecret - cannot copy data: " + secret.GetType().FullName);
    }
  }

  private static byte[] GenerateSsl3Constants()
  {
    int num1 = 15;
    byte[] ssl3Constants = new byte[120];
    int num2 = 0;
    for (int index1 = 0; index1 < num1; ++index1)
    {
      byte num3 = (byte) (65 + index1);
      for (int index2 = 0; index2 <= index1; ++index2)
        ssl3Constants[num2++] = num3;
    }
    return ssl3Constants;
  }

  public BcTlsSecret(BcTlsCrypto crypto, byte[] data)
    : base(data)
  {
    this.m_crypto = crypto;
  }

  public override TlsSecret DeriveUsingPrf(
    int prfAlgorithm,
    string label,
    byte[] seed,
    int length)
  {
    lock (this)
    {
      this.CheckAlive();
      switch (prfAlgorithm)
      {
        case 4:
          return TlsCryptoUtilities.HkdfExpandLabel((TlsSecret) this, 4, label, seed, length);
        case 5:
          return TlsCryptoUtilities.HkdfExpandLabel((TlsSecret) this, 5, label, seed, length);
        case 7:
          return TlsCryptoUtilities.HkdfExpandLabel((TlsSecret) this, 7, label, seed, length);
        default:
          return (TlsSecret) this.m_crypto.AdoptLocalSecret(this.Prf(prfAlgorithm, label, seed, length));
      }
    }
  }

  public override TlsSecret HkdfExpand(int cryptoHashAlgorithm, byte[] info, int length)
  {
    lock (this)
    {
      if (length < 1)
        return (TlsSecret) this.m_crypto.AdoptLocalSecret(TlsUtilities.EmptyBytes);
      int hashOutputSize = TlsCryptoUtilities.GetHashOutputSize(cryptoHashAlgorithm);
      if (length > (int) byte.MaxValue * hashOutputSize)
        throw new ArgumentException("must be <= 255 * (output size of 'hashAlgorithm')", nameof (length));
      this.CheckAlive();
      byte[] data = this.m_data;
      HMac hmac = new HMac(this.m_crypto.CreateDigest(cryptoHashAlgorithm));
      hmac.Init((ICipherParameters) new KeyParameter(data));
      byte[] numArray1 = new byte[length];
      byte[] numArray2 = new byte[hashOutputSize];
      byte num = 0;
      int destinationIndex = 0;
      int length1;
      while (true)
      {
        hmac.BlockUpdate(info, 0, info.Length);
        hmac.Update(++num);
        hmac.DoFinal(numArray2, 0);
        length1 = length - destinationIndex;
        if (length1 > hashOutputSize)
        {
          Array.Copy((Array) numArray2, 0, (Array) numArray1, destinationIndex, hashOutputSize);
          destinationIndex += hashOutputSize;
          hmac.BlockUpdate(numArray2, 0, numArray2.Length);
        }
        else
          break;
      }
      Array.Copy((Array) numArray2, 0, (Array) numArray1, destinationIndex, length1);
      return (TlsSecret) this.m_crypto.AdoptLocalSecret(numArray1);
    }
  }

  public override TlsSecret HkdfExtract(int cryptoHashAlgorithm, TlsSecret ikm)
  {
    lock (this)
    {
      this.CheckAlive();
      byte[] data = this.m_data;
      this.m_data = (byte[]) null;
      HMac hmac = new HMac(this.m_crypto.CreateDigest(cryptoHashAlgorithm));
      hmac.Init((ICipherParameters) new KeyParameter(data));
      BcTlsSecret.Convert(this.m_crypto, ikm).UpdateMac((IMac) hmac);
      byte[] numArray = new byte[hmac.GetMacSize()];
      hmac.DoFinal(numArray, 0);
      return (TlsSecret) this.m_crypto.AdoptLocalSecret(numArray);
    }
  }

  protected override AbstractTlsCrypto Crypto => (AbstractTlsCrypto) this.m_crypto;

  protected virtual void HmacHash(
    int cryptoHashAlgorithm,
    byte[] secret,
    int secretOff,
    int secretLen,
    byte[] seed,
    byte[] output)
  {
    HMac hmac = new HMac(this.m_crypto.CreateDigest(cryptoHashAlgorithm));
    hmac.Init((ICipherParameters) new KeyParameter(secret, secretOff, secretLen));
    byte[] input = seed;
    int macSize = hmac.GetMacSize();
    byte[] output1 = new byte[macSize];
    byte[] numArray = new byte[macSize];
    for (int destinationIndex = 0; destinationIndex < output.Length; destinationIndex += macSize)
    {
      hmac.BlockUpdate(input, 0, input.Length);
      hmac.DoFinal(output1, 0);
      input = output1;
      hmac.BlockUpdate(input, 0, input.Length);
      hmac.BlockUpdate(seed, 0, seed.Length);
      hmac.DoFinal(numArray, 0);
      Array.Copy((Array) numArray, 0, (Array) output, destinationIndex, Math.Min(macSize, output.Length - destinationIndex));
    }
  }

  protected virtual byte[] Prf(int prfAlgorithm, string label, byte[] seed, int length)
  {
    if (prfAlgorithm == 0)
      return this.Prf_Ssl(seed, length);
    byte[] labelSeed = Arrays.Concatenate(Strings.ToByteArray(label), seed);
    return 1 == prfAlgorithm ? this.Prf_1_0(labelSeed, length) : this.Prf_1_2(prfAlgorithm, labelSeed, length);
  }

  protected virtual byte[] Prf_Ssl(byte[] seed, int length)
  {
    IDigest digest1 = this.m_crypto.CreateDigest(1);
    IDigest digest2 = this.m_crypto.CreateDigest(2);
    int digestSize1 = digest1.GetDigestSize();
    int digestSize2 = digest2.GetDigestSize();
    byte[] numArray1 = new byte[Math.Max(digestSize1, digestSize2)];
    byte[] numArray2 = new byte[length];
    int inLen = 1;
    int inOff = 0;
    int num = 0;
    while (num < length)
    {
      digest2.BlockUpdate(BcTlsSecret.Ssl3Const, inOff, inLen);
      inOff += inLen++;
      digest2.BlockUpdate(this.m_data, 0, this.m_data.Length);
      digest2.BlockUpdate(seed, 0, seed.Length);
      digest2.DoFinal(numArray1, 0);
      digest1.BlockUpdate(this.m_data, 0, this.m_data.Length);
      digest1.BlockUpdate(numArray1, 0, digestSize2);
      int length1 = length - num;
      if (length1 < digestSize1)
      {
        digest1.DoFinal(numArray1, 0);
        Array.Copy((Array) numArray1, 0, (Array) numArray2, num, length1);
        num += length1;
      }
      else
      {
        digest1.DoFinal(numArray2, num);
        num += digestSize1;
      }
    }
    return numArray2;
  }

  protected virtual byte[] Prf_1_0(byte[] labelSeed, int length)
  {
    int secretLen = (this.m_data.Length + 1) / 2;
    byte[] output1 = new byte[length];
    this.HmacHash(1, this.m_data, 0, secretLen, labelSeed, output1);
    byte[] output2 = new byte[length];
    this.HmacHash(2, this.m_data, this.m_data.Length - secretLen, secretLen, labelSeed, output2);
    for (int index = 0; index < length; ++index)
      output1[index] ^= output2[index];
    return output1;
  }

  protected virtual byte[] Prf_1_2(int prfAlgorithm, byte[] labelSeed, int length)
  {
    int hashForPrf = TlsCryptoUtilities.GetHashForPrf(prfAlgorithm);
    byte[] output = new byte[length];
    this.HmacHash(hashForPrf, this.m_data, 0, this.m_data.Length, labelSeed, output);
    return output;
  }

  protected virtual void UpdateMac(IMac mac)
  {
    lock (this)
    {
      this.CheckAlive();
      mac.BlockUpdate(this.m_data, 0, this.m_data.Length);
    }
  }
}
