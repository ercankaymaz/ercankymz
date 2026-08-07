// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Engines.XSalsa20Engine
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Engines;

public class XSalsa20Engine : Salsa20Engine
{
  public override string AlgorithmName => "XSalsa20";

  protected override int NonceSize => 24;

  protected override void SetKey(byte[] keyBytes, byte[] ivBytes)
  {
    if (keyBytes == null)
      throw new ArgumentException(this.AlgorithmName + " doesn't support re-init with null key");
    if (keyBytes.Length != 32 /*0x20*/)
      throw new ArgumentException(this.AlgorithmName + " requires a 256 bit key");
    base.SetKey(keyBytes, ivBytes);
    Pack.LE_To_UInt32(ivBytes, 8, this.engineState, 8, 2);
    uint[] output = new uint[this.engineState.Length];
    Salsa20Engine.SalsaCore(20, this.engineState, output);
    this.engineState[1] = output[0] - this.engineState[0];
    this.engineState[2] = output[5] - this.engineState[5];
    this.engineState[3] = output[10] - this.engineState[10];
    this.engineState[4] = output[15] - this.engineState[15];
    this.engineState[11] = output[6] - this.engineState[6];
    this.engineState[12] = output[7] - this.engineState[7];
    this.engineState[13] = output[8] - this.engineState[8];
    this.engineState[14] = output[9] - this.engineState[9];
    Pack.LE_To_UInt32(ivBytes, 16 /*0x10*/, this.engineState, 6, 2);
  }
}
