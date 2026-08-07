// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsAeadCipherImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal class BcTlsAeadCipherImpl : TlsAeadCipherImpl
{
  private readonly bool m_isEncrypting;
  internal readonly IAeadCipher m_cipher;
  private KeyParameter key;

  internal BcTlsAeadCipherImpl(IAeadCipher cipher, bool isEncrypting)
  {
    this.m_cipher = cipher;
    this.m_isEncrypting = isEncrypting;
  }

  public void SetKey(byte[] key, int keyOff, int keyLen)
  {
    this.key = new KeyParameter(key, keyOff, keyLen);
  }

  public void Init(byte[] nonce, int macSize, byte[] additionalData)
  {
    this.m_cipher.Init(this.m_isEncrypting, (ICipherParameters) new AeadParameters(this.key, macSize * 8, nonce, additionalData));
  }

  public int GetOutputSize(int inputLength) => this.m_cipher.GetOutputSize(inputLength);

  public virtual int DoFinal(
    byte[] input,
    int inputOffset,
    int inputLength,
    byte[] output,
    int outputOffset)
  {
    int num = this.m_cipher.ProcessBytes(input, inputOffset, inputLength, output, outputOffset);
    try
    {
      return num + this.m_cipher.DoFinal(output, outputOffset + num);
    }
    catch (InvalidCipherTextException ex)
    {
      throw new TlsFatalAlert((short) 20, (Exception) ex);
    }
  }

  public void Reset() => this.m_cipher.Reset();
}
