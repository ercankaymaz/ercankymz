// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.DesEdeEngine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Utilities;
using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class DesEdeEngine : DesEngine
{
  private int[] workingKey1;
  private int[] workingKey2;
  private int[] workingKey3;
  private bool forEncryption;

  public override void Init(bool forEncryption, ICipherParameters parameters)
  {
    byte[] sourceArray = parameters is KeyParameter keyParameter ? keyParameter.GetKey() : throw new ArgumentException("invalid parameter passed to DESede init - " + Platform.GetTypeName((object) parameters));
    if (sourceArray.Length != 24 && sourceArray.Length != 16 /*0x10*/)
      throw new ArgumentException("key size must be 16 or 24 bytes.");
    this.forEncryption = forEncryption;
    byte[] numArray1 = new byte[8];
    Array.Copy((Array) sourceArray, 0, (Array) numArray1, 0, numArray1.Length);
    this.workingKey1 = DesEngine.GenerateWorkingKey(forEncryption, numArray1);
    byte[] numArray2 = new byte[8];
    Array.Copy((Array) sourceArray, 8, (Array) numArray2, 0, numArray2.Length);
    this.workingKey2 = DesEngine.GenerateWorkingKey(!forEncryption, numArray2);
    if (sourceArray.Length == 24)
    {
      byte[] numArray3 = new byte[8];
      Array.Copy((Array) sourceArray, 16 /*0x10*/, (Array) numArray3, 0, numArray3.Length);
      this.workingKey3 = DesEngine.GenerateWorkingKey(forEncryption, numArray3);
    }
    else
      this.workingKey3 = this.workingKey1;
  }

  public override string AlgorithmName => "DESede";

  public override int GetBlockSize() => 8;

  public override int ProcessBlock(byte[] input, int inOff, byte[] output, int outOff)
  {
    if (this.workingKey1 == null)
      throw new InvalidOperationException("DESede engine not initialised");
    Org.BouncyCastle.Crypto.Check.DataLength(input, inOff, 8, "input buffer too short");
    Org.BouncyCastle.Crypto.Check.OutputLength(output, outOff, 8, "output buffer too short");
    uint uint32_1 = Pack.BE_To_UInt32(input, inOff);
    uint uint32_2 = Pack.BE_To_UInt32(input, inOff + 4);
    if (this.forEncryption)
    {
      DesEngine.DesFunc(this.workingKey1, ref uint32_1, ref uint32_2);
      DesEngine.DesFunc(this.workingKey2, ref uint32_1, ref uint32_2);
      DesEngine.DesFunc(this.workingKey3, ref uint32_1, ref uint32_2);
    }
    else
    {
      DesEngine.DesFunc(this.workingKey3, ref uint32_1, ref uint32_2);
      DesEngine.DesFunc(this.workingKey2, ref uint32_1, ref uint32_2);
      DesEngine.DesFunc(this.workingKey1, ref uint32_1, ref uint32_2);
    }
    Pack.UInt32_To_BE(uint32_1, output, outOff);
    Pack.UInt32_To_BE(uint32_2, output, outOff + 4);
    return 8;
  }
}
