// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.KdfCounterParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class KdfCounterParameters : IDerivationParameters
{
  private byte[] ki;
  private byte[] fixedInputDataCounterPrefix;
  private byte[] fixedInputDataCounterSuffix;
  private int r;

  public KdfCounterParameters(byte[] ki, byte[] fixedInputDataCounterSuffix, int r)
    : this(ki, (byte[]) null, fixedInputDataCounterSuffix, r)
  {
  }

  public KdfCounterParameters(
    byte[] ki,
    byte[] fixedInputDataCounterPrefix,
    byte[] fixedInputDataCounterSuffix,
    int r)
  {
    this.ki = ki != null ? Arrays.Clone(ki) : throw new ArgumentException("A KDF requires Ki (a seed) as input");
    this.fixedInputDataCounterPrefix = fixedInputDataCounterPrefix != null ? Arrays.Clone(fixedInputDataCounterPrefix) : new byte[0];
    this.fixedInputDataCounterSuffix = fixedInputDataCounterSuffix != null ? Arrays.Clone(fixedInputDataCounterSuffix) : new byte[0];
    this.r = r == 8 || r == 16 /*0x10*/ || r == 24 || r == 32 /*0x20*/ ? r : throw new ArgumentException("Length of counter should be 8, 16, 24 or 32");
  }

  public byte[] Ki => this.ki;

  public byte[] FixedInputData => Arrays.Clone(this.fixedInputDataCounterSuffix);

  public byte[] FixedInputDataCounterPrefix => Arrays.Clone(this.fixedInputDataCounterPrefix);

  public byte[] FixedInputDataCounterSuffix => Arrays.Clone(this.fixedInputDataCounterSuffix);

  public int R => this.r;
}
