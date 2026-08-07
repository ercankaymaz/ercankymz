// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsBlockCipherImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal sealed class BcTlsBlockCipherImpl : TlsBlockCipherImpl
{
  private readonly bool m_isEncrypting;
  private readonly IBlockCipher m_cipher;
  private KeyParameter key;

  internal BcTlsBlockCipherImpl(IBlockCipher cipher, bool isEncrypting)
  {
    this.m_cipher = cipher;
    this.m_isEncrypting = isEncrypting;
  }

  public void SetKey(byte[] key, int keyOff, int keyLen)
  {
    this.key = new KeyParameter(key, keyOff, keyLen);
  }

  public void Init(byte[] iv, int ivOff, int ivLen)
  {
    this.m_cipher.Init(this.m_isEncrypting, (ICipherParameters) new ParametersWithIV((ICipherParameters) this.key, iv, ivOff, ivLen));
  }

  public int DoFinal(
    byte[] input,
    int inputOffset,
    int inputLength,
    byte[] output,
    int outputOffset)
  {
    int blockSize = this.m_cipher.GetBlockSize();
    for (int index = 0; index < inputLength; index += blockSize)
      this.m_cipher.ProcessBlock(input, inputOffset + index, output, outputOffset + index);
    return inputLength;
  }

  public int GetBlockSize() => this.m_cipher.GetBlockSize();
}
