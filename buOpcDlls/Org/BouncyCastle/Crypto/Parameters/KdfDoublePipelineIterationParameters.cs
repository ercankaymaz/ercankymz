// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.KdfDoublePipelineIterationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class KdfDoublePipelineIterationParameters : IDerivationParameters
{
  private static readonly int UNUSED_R = 32 /*0x20*/;
  private readonly byte[] ki;
  private readonly bool useCounter;
  private readonly int r;
  private readonly byte[] fixedInputData;

  private KdfDoublePipelineIterationParameters(
    byte[] ki,
    byte[] fixedInputData,
    int r,
    bool useCounter)
  {
    this.ki = ki != null ? Arrays.Clone(ki) : throw new ArgumentNullException("A KDF requires Ki (a seed) as input", nameof (ki));
    this.fixedInputData = fixedInputData != null ? Arrays.Clone(fixedInputData) : new byte[0];
    this.r = r == 8 || r == 16 /*0x10*/ || r == 24 || r == 32 /*0x20*/ ? r : throw new ArgumentException("Length of counter should be 8, 16, 24 or 32");
    this.useCounter = useCounter;
  }

  public static KdfDoublePipelineIterationParameters CreateWithCounter(
    byte[] ki,
    byte[] fixedInputData,
    int r)
  {
    return new KdfDoublePipelineIterationParameters(ki, fixedInputData, r, true);
  }

  public static KdfDoublePipelineIterationParameters CreateWithoutCounter(
    byte[] ki,
    byte[] fixedInputData)
  {
    return new KdfDoublePipelineIterationParameters(ki, fixedInputData, KdfDoublePipelineIterationParameters.UNUSED_R, false);
  }

  public byte[] Ki => Arrays.Clone(this.ki);

  public bool UseCounter => this.useCounter;

  public int R => this.r;

  public byte[] FixedInputData => Arrays.Clone(this.fixedInputData);
}
