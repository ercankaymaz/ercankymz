// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.IesEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class IesEngine
{
  private readonly IBasicAgreement agree;
  private readonly IDerivationFunction kdf;
  private readonly IMac mac;
  private readonly BufferedBlockCipher cipher;
  private readonly byte[] macBuf;
  private bool forEncryption;
  private ICipherParameters privParam;
  private ICipherParameters pubParam;
  private IesParameters param;

  public IesEngine(IBasicAgreement agree, IDerivationFunction kdf, IMac mac)
  {
    this.agree = agree;
    this.kdf = kdf;
    this.mac = mac;
    this.macBuf = new byte[mac.GetMacSize()];
  }

  public IesEngine(
    IBasicAgreement agree,
    IDerivationFunction kdf,
    IMac mac,
    BufferedBlockCipher cipher)
  {
    this.agree = agree;
    this.kdf = kdf;
    this.mac = mac;
    this.macBuf = new byte[mac.GetMacSize()];
    this.cipher = cipher;
  }

  public virtual void Init(
    bool forEncryption,
    ICipherParameters privParameters,
    ICipherParameters pubParameters,
    ICipherParameters iesParameters)
  {
    this.forEncryption = forEncryption;
    this.privParam = privParameters;
    this.pubParam = pubParameters;
    this.param = (IesParameters) iesParameters;
  }

  private byte[] DecryptBlock(byte[] in_enc, int inOff, int inLen, byte[] z)
  {
    KdfParameters kdfParameters = new KdfParameters(z, this.param.GetDerivationV());
    int macKeySize = this.param.MacKeySize;
    this.kdf.Init((IDerivationParameters) kdfParameters);
    if (inLen < this.mac.GetMacSize())
      throw new InvalidCipherTextException("Length of input must be greater than the MAC");
    inLen -= this.mac.GetMacSize();
    byte[] numArray;
    KeyParameter parameters;
    if (this.cipher == null)
    {
      byte[] kdfBytes = this.GenerateKdfBytes(kdfParameters, inLen + macKeySize / 8);
      numArray = new byte[inLen];
      for (int index = 0; index != inLen; ++index)
        numArray[index] = (byte) ((uint) in_enc[inOff + index] ^ (uint) kdfBytes[index]);
      parameters = new KeyParameter(kdfBytes, inLen, macKeySize / 8);
    }
    else
    {
      int cipherKeySize = ((IesWithCipherParameters) this.param).CipherKeySize;
      byte[] kdfBytes = this.GenerateKdfBytes(kdfParameters, cipherKeySize / 8 + macKeySize / 8);
      this.cipher.Init(false, (ICipherParameters) new KeyParameter(kdfBytes, 0, cipherKeySize / 8));
      numArray = this.cipher.DoFinal(in_enc, inOff, inLen);
      parameters = new KeyParameter(kdfBytes, cipherKeySize / 8, macKeySize / 8);
    }
    byte[] encodingV = this.param.GetEncodingV();
    this.mac.Init((ICipherParameters) parameters);
    this.mac.BlockUpdate(in_enc, inOff, inLen);
    this.mac.BlockUpdate(encodingV, 0, encodingV.Length);
    this.mac.DoFinal(this.macBuf, 0);
    inOff += inLen;
    if (!Arrays.FixedTimeEquals(Arrays.CopyOfRange(in_enc, inOff, inOff + this.macBuf.Length), this.macBuf))
      throw new InvalidCipherTextException("Invalid MAC.");
    return numArray;
  }

  private byte[] EncryptBlock(byte[] input, int inOff, int inLen, byte[] z)
  {
    KdfParameters kParam = new KdfParameters(z, this.param.GetDerivationV());
    int macKeySize = this.param.MacKeySize;
    byte[] numArray1;
    int num;
    KeyParameter parameters;
    if (this.cipher == null)
    {
      byte[] kdfBytes = this.GenerateKdfBytes(kParam, inLen + macKeySize / 8);
      numArray1 = new byte[inLen + this.mac.GetMacSize()];
      num = inLen;
      for (int index = 0; index != inLen; ++index)
        numArray1[index] = (byte) ((uint) input[inOff + index] ^ (uint) kdfBytes[index]);
      parameters = new KeyParameter(kdfBytes, inLen, macKeySize / 8);
    }
    else
    {
      int cipherKeySize = ((IesWithCipherParameters) this.param).CipherKeySize;
      byte[] kdfBytes = this.GenerateKdfBytes(kParam, cipherKeySize / 8 + macKeySize / 8);
      this.cipher.Init(true, (ICipherParameters) new KeyParameter(kdfBytes, 0, cipherKeySize / 8));
      byte[] numArray2 = new byte[this.cipher.GetOutputSize(inLen)];
      int outOff = this.cipher.ProcessBytes(input, inOff, inLen, numArray2, 0);
      int length = outOff + this.cipher.DoFinal(numArray2, outOff);
      numArray1 = new byte[length + this.mac.GetMacSize()];
      num = length;
      Array.Copy((Array) numArray2, 0, (Array) numArray1, 0, length);
      parameters = new KeyParameter(kdfBytes, cipherKeySize / 8, macKeySize / 8);
    }
    byte[] encodingV = this.param.GetEncodingV();
    this.mac.Init((ICipherParameters) parameters);
    this.mac.BlockUpdate(numArray1, 0, num);
    this.mac.BlockUpdate(encodingV, 0, encodingV.Length);
    this.mac.DoFinal(numArray1, num);
    return numArray1;
  }

  private byte[] GenerateKdfBytes(KdfParameters kParam, int length)
  {
    byte[] output = new byte[length];
    this.kdf.Init((IDerivationParameters) kParam);
    this.kdf.GenerateBytes(output, 0, output.Length);
    return output;
  }

  public virtual byte[] ProcessBlock(byte[] input, int inOff, int inLen)
  {
    this.agree.Init(this.privParam);
    BigInteger agreement = this.agree.CalculateAgreement(this.pubParam);
    byte[] z = BigIntegers.AsUnsignedByteArray(this.agree.GetFieldSize(), agreement);
    try
    {
      return this.forEncryption ? this.EncryptBlock(input, inOff, inLen, z) : this.DecryptBlock(input, inOff, inLen, z);
    }
    finally
    {
      Array.Clear((Array) z, 0, z.Length);
    }
  }
}
