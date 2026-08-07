// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcChaCha20Poly1305
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

public sealed class BcChaCha20Poly1305 : TlsAeadCipherImpl
{
  private static readonly byte[] Zeroes = new byte[15];
  private readonly ChaCha7539Engine m_cipher = new ChaCha7539Engine();
  private readonly Poly1305 m_mac = new Poly1305();
  private readonly bool m_isEncrypting;
  private int m_additionalDataLength;

  public BcChaCha20Poly1305(bool isEncrypting) => this.m_isEncrypting = isEncrypting;

  public int DoFinal(
    byte[] input,
    int inputOffset,
    int inputLength,
    byte[] output,
    int outputOffset)
  {
    if (this.m_isEncrypting)
    {
      int num = inputLength;
      this.m_cipher.DoFinal(input, inputOffset, inputLength, output, outputOffset);
      this.UpdateMac(output, outputOffset, num);
      byte[] numArray = new byte[16 /*0x10*/];
      Pack.UInt64_To_LE((ulong) this.m_additionalDataLength, numArray, 0);
      Pack.UInt64_To_LE((ulong) num, numArray, 8);
      this.m_mac.BlockUpdate(numArray, 0, 16 /*0x10*/);
      this.m_mac.DoFinal(output, outputOffset + num);
      return num + 16 /*0x10*/;
    }
    int num1 = inputLength - 16 /*0x10*/;
    this.UpdateMac(input, inputOffset, num1);
    byte[] numArray1 = new byte[16 /*0x10*/];
    Pack.UInt64_To_LE((ulong) this.m_additionalDataLength, numArray1, 0);
    Pack.UInt64_To_LE((ulong) num1, numArray1, 8);
    this.m_mac.BlockUpdate(numArray1, 0, 16 /*0x10*/);
    this.m_mac.DoFinal(numArray1, 0);
    if (!TlsUtilities.ConstantTimeAreEqual(16 /*0x10*/, numArray1, 0, input, inputOffset + num1))
      throw new TlsFatalAlert((short) 20);
    this.m_cipher.DoFinal(input, inputOffset, num1, output, outputOffset);
    return num1;
  }

  public int GetOutputSize(int inputLength)
  {
    return !this.m_isEncrypting ? inputLength - 16 /*0x10*/ : inputLength + 16 /*0x10*/;
  }

  public void Init(byte[] nonce, int macSize, byte[] additionalData)
  {
    if (nonce == null || nonce.Length != 12 || macSize != 16 /*0x10*/)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
    this.m_cipher.Init(this.m_isEncrypting, (ICipherParameters) new ParametersWithIV((ICipherParameters) null, nonce));
    this.InitMac();
    if (additionalData == null)
    {
      this.m_additionalDataLength = 0;
    }
    else
    {
      this.m_additionalDataLength = additionalData.Length;
      this.UpdateMac(additionalData, 0, additionalData.Length);
    }
  }

  public void Reset()
  {
    this.m_cipher.Reset();
    this.m_mac.Reset();
  }

  public void SetKey(byte[] key, int keyOff, int keyLen)
  {
    this.m_cipher.Init(this.m_isEncrypting, (ICipherParameters) new ParametersWithIV((ICipherParameters) new KeyParameter(key, keyOff, keyLen), BcChaCha20Poly1305.Zeroes, 0, 12));
  }

  private void InitMac()
  {
    byte[] numArray = new byte[64 /*0x40*/];
    this.m_cipher.ProcessBytes(numArray, 0, 64 /*0x40*/, numArray, 0);
    this.m_mac.Init((ICipherParameters) new KeyParameter(numArray, 0, 32 /*0x20*/));
    Array.Clear((Array) numArray, 0, numArray.Length);
  }

  private void UpdateMac(byte[] buf, int off, int len)
  {
    this.m_mac.BlockUpdate(buf, off, len);
    int num = len % 16 /*0x10*/;
    if (num == 0)
      return;
    this.m_mac.BlockUpdate(BcChaCha20Poly1305.Zeroes, 0, 16 /*0x10*/ - num);
  }
}
