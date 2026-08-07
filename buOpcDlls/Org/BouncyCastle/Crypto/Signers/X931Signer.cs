// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Signers.X931Signer
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Signers;

public class X931Signer : ISigner
{
  private IDigest digest;
  private IAsymmetricBlockCipher cipher;
  private RsaKeyParameters kParam;
  private int trailer;
  private int keyBits;
  private byte[] block;

  public X931Signer(IAsymmetricBlockCipher cipher, IDigest digest)
    : this(cipher, digest, false)
  {
  }

  public X931Signer(IAsymmetricBlockCipher cipher, IDigest digest, bool isImplicit)
  {
    this.cipher = cipher;
    this.digest = digest;
    if (isImplicit)
      this.trailer = 188;
    else
      this.trailer = !IsoTrailers.NoTrailerAvailable(digest) ? IsoTrailers.GetTrailer(digest) : throw new ArgumentException("no valid trailer", nameof (digest));
  }

  public virtual string AlgorithmName
  {
    get => $"{this.digest.AlgorithmName}with{this.cipher.AlgorithmName}/X9.31";
  }

  public virtual void Init(bool forSigning, ICipherParameters parameters)
  {
    this.kParam = !(parameters is ParametersWithRandom parametersWithRandom) ? (RsaKeyParameters) parameters : (RsaKeyParameters) parametersWithRandom.Parameters;
    this.cipher.Init(forSigning, parameters);
    this.keyBits = this.kParam.Modulus.BitLength;
    this.block = new byte[(this.keyBits + 7) / 8];
    this.Reset();
  }

  public virtual void Update(byte b) => this.digest.Update(b);

  public virtual void BlockUpdate(byte[] input, int inOff, int inLen)
  {
    this.digest.BlockUpdate(input, inOff, inLen);
  }

  public virtual int GetMaxSignatureSize()
  {
    return BigIntegers.GetUnsignedByteLength(this.kParam.Modulus);
  }

  public virtual byte[] GenerateSignature()
  {
    this.CreateSignatureBlock();
    BigInteger n1 = new BigInteger(1, this.cipher.ProcessBlock(this.block, 0, this.block.Length));
    Arrays.Fill(this.block, (byte) 0);
    BigInteger n2 = n1.Min(this.kParam.Modulus.Subtract(n1));
    return BigIntegers.AsUnsignedByteArray(BigIntegers.GetUnsignedByteLength(this.kParam.Modulus), n2);
  }

  public virtual bool VerifySignature(byte[] signature)
  {
    try
    {
      this.block = this.cipher.ProcessBlock(signature, 0, signature.Length);
    }
    catch (Exception ex)
    {
      return false;
    }
    BigInteger n1 = new BigInteger(1, this.block);
    BigInteger n2;
    if ((n1.IntValue & 15) == 12)
    {
      n2 = n1;
    }
    else
    {
      BigInteger bigInteger = this.kParam.Modulus.Subtract(n1);
      if ((bigInteger.IntValue & 15) != 12)
        return false;
      n2 = bigInteger;
    }
    this.CreateSignatureBlock();
    byte[] numArray = BigIntegers.AsUnsignedByteArray(this.block.Length, n2);
    int num = Arrays.FixedTimeEquals(this.block, numArray) ? 1 : 0;
    Arrays.Fill(this.block, (byte) 0);
    Arrays.Fill<byte>(numArray, (byte) 0);
    return num != 0;
  }

  public virtual void Reset() => this.digest.Reset();

  private void CreateSignatureBlock()
  {
    int digestSize = this.digest.GetDigestSize();
    int outOff;
    if (this.trailer == 188)
    {
      outOff = this.block.Length - digestSize - 1;
      this.digest.DoFinal(this.block, outOff);
      this.block[this.block.Length - 1] = (byte) 188;
    }
    else
    {
      outOff = this.block.Length - digestSize - 2;
      this.digest.DoFinal(this.block, outOff);
      this.block[this.block.Length - 2] = (byte) (this.trailer >> 8);
      this.block[this.block.Length - 1] = (byte) this.trailer;
    }
    this.block[0] = (byte) 107;
    for (int index = outOff - 2; index != 0; --index)
      this.block[index] = (byte) 187;
    this.block[outOff - 1] = (byte) 186;
  }
}
