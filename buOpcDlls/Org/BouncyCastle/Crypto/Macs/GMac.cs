// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Macs.GMac
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Macs;

public class GMac : IMac
{
  private readonly GcmBlockCipher cipher;
  private readonly int macSizeBits;

  public GMac(GcmBlockCipher cipher)
    : this(cipher, 128 /*0x80*/)
  {
  }

  public GMac(GcmBlockCipher cipher, int macSizeBits)
  {
    this.cipher = cipher;
    this.macSizeBits = macSizeBits;
  }

  public void Init(ICipherParameters parameters)
  {
    byte[] nonce = parameters is ParametersWithIV parametersWithIv ? parametersWithIv.GetIV() : throw new ArgumentException("GMAC requires ParametersWithIV");
    this.cipher.Init(true, (ICipherParameters) new AeadParameters((KeyParameter) parametersWithIv.Parameters, this.macSizeBits, nonce));
  }

  public string AlgorithmName => this.cipher.UnderlyingCipher.AlgorithmName + "-GMAC";

  public int GetMacSize() => this.macSizeBits / 8;

  public void Update(byte input) => this.cipher.ProcessAadByte(input);

  public void BlockUpdate(byte[] input, int inOff, int len)
  {
    this.cipher.ProcessAadBytes(input, inOff, len);
  }

  public int DoFinal(byte[] output, int outOff)
  {
    try
    {
      return this.cipher.DoFinal(output, outOff);
    }
    catch (InvalidCipherTextException ex)
    {
      throw new InvalidOperationException(ex.ToString());
    }
  }

  public void Reset() => this.cipher.Reset();
}
