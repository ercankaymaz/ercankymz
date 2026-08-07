// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Generators.Pkcs12ParametersGenerator
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Generators;

public class Pkcs12ParametersGenerator : PbeParametersGenerator
{
  public const int KeyMaterial = 1;
  public const int IVMaterial = 2;
  public const int MacMaterial = 3;
  private readonly IDigest digest;
  private readonly int u;
  private readonly int v;

  public Pkcs12ParametersGenerator(IDigest digest)
  {
    this.digest = digest;
    this.u = digest.GetDigestSize();
    this.v = digest.GetByteLength();
  }

  private void Adjust(byte[] a, int aOff, byte[] b)
  {
    int num1 = ((int) b[b.Length - 1] & (int) byte.MaxValue) + ((int) a[aOff + b.Length - 1] & (int) byte.MaxValue) + 1;
    a[aOff + b.Length - 1] = (byte) num1;
    int num2 = num1 >>> 8;
    for (int index = b.Length - 2; index >= 0; --index)
    {
      int num3 = num2 + (((int) b[index] & (int) byte.MaxValue) + ((int) a[aOff + index] & (int) byte.MaxValue));
      a[aOff + index] = (byte) num3;
      num2 = num3 >>> 8;
    }
  }

  private byte[] GenerateDerivedKey(int idByte, int n)
  {
    byte[] input = new byte[this.v];
    byte[] destinationArray = new byte[n];
    for (int index = 0; index != input.Length; ++index)
      input[index] = (byte) idByte;
    byte[] sourceArray1;
    if (this.mSalt != null && this.mSalt.Length != 0)
    {
      sourceArray1 = new byte[this.v * ((this.mSalt.Length + this.v - 1) / this.v)];
      for (int index = 0; index != sourceArray1.Length; ++index)
        sourceArray1[index] = this.mSalt[index % this.mSalt.Length];
    }
    else
      sourceArray1 = new byte[0];
    byte[] sourceArray2;
    if (this.mPassword != null && this.mPassword.Length != 0)
    {
      sourceArray2 = new byte[this.v * ((this.mPassword.Length + this.v - 1) / this.v)];
      for (int index = 0; index != sourceArray2.Length; ++index)
        sourceArray2[index] = this.mPassword[index % this.mPassword.Length];
    }
    else
      sourceArray2 = new byte[0];
    byte[] numArray1 = new byte[sourceArray1.Length + sourceArray2.Length];
    Array.Copy((Array) sourceArray1, 0, (Array) numArray1, 0, sourceArray1.Length);
    Array.Copy((Array) sourceArray2, 0, (Array) numArray1, sourceArray1.Length, sourceArray2.Length);
    byte[] b = new byte[this.v];
    int num = (n + this.u - 1) / this.u;
    byte[] numArray2 = new byte[this.u];
    for (int index1 = 1; index1 <= num; ++index1)
    {
      this.digest.BlockUpdate(input, 0, input.Length);
      this.digest.BlockUpdate(numArray1, 0, numArray1.Length);
      this.digest.DoFinal(numArray2, 0);
      for (int index2 = 1; index2 != this.mIterationCount; ++index2)
      {
        this.digest.BlockUpdate(numArray2, 0, numArray2.Length);
        this.digest.DoFinal(numArray2, 0);
      }
      for (int index3 = 0; index3 != b.Length; ++index3)
        b[index3] = numArray2[index3 % numArray2.Length];
      for (int index4 = 0; index4 != numArray1.Length / this.v; ++index4)
        this.Adjust(numArray1, index4 * this.v, b);
      if (index1 == num)
        Array.Copy((Array) numArray2, 0, (Array) destinationArray, (index1 - 1) * this.u, destinationArray.Length - (index1 - 1) * this.u);
      else
        Array.Copy((Array) numArray2, 0, (Array) destinationArray, (index1 - 1) * this.u, numArray2.Length);
    }
    return destinationArray;
  }

  public override ICipherParameters GenerateDerivedParameters(string algorithm, int keySize)
  {
    keySize /= 8;
    byte[] derivedKey = this.GenerateDerivedKey(1, keySize);
    return (ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize);
  }

  public override ICipherParameters GenerateDerivedParameters(
    string algorithm,
    int keySize,
    int ivSize)
  {
    keySize /= 8;
    ivSize /= 8;
    byte[] derivedKey = this.GenerateDerivedKey(1, keySize);
    return (ICipherParameters) new ParametersWithIV((ICipherParameters) ParameterUtilities.CreateKeyParameter(algorithm, derivedKey, 0, keySize), this.GenerateDerivedKey(2, ivSize), 0, ivSize);
  }

  public override ICipherParameters GenerateDerivedMacParameters(int keySize)
  {
    keySize /= 8;
    return (ICipherParameters) new KeyParameter(this.GenerateDerivedKey(3, keySize), 0, keySize);
  }
}
