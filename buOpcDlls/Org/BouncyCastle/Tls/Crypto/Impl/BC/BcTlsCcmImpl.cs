// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.BC.BcTlsCcmImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Modes;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl.BC;

internal class BcTlsCcmImpl : BcTlsAeadCipherImpl
{
  internal BcTlsCcmImpl(CcmBlockCipher cipher, bool isEncrypting)
    : base((IAeadCipher) cipher, isEncrypting)
  {
  }

  public override int DoFinal(
    byte[] input,
    int inputOffset,
    int inputLength,
    byte[] output,
    int outputOffset)
  {
    if (!(this.m_cipher is CcmBlockCipher cipher))
      throw new InvalidOperationException();
    try
    {
      return cipher.ProcessPacket(input, inputOffset, inputLength, output, outputOffset);
    }
    catch (InvalidCipherTextException ex)
    {
      throw new TlsFatalAlert((short) 20, (Exception) ex);
    }
  }
}
