// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.KdfFeedbackParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class KdfFeedbackParameters : IDerivationParameters
{
  private static readonly int UNUSED_R = -1;
  private readonly byte[] ki;
  private readonly byte[] iv;
  private readonly bool useCounter;
  private readonly int r;
  private readonly byte[] fixedInputData;

  private KdfFeedbackParameters(
    byte[] ki,
    byte[] iv,
    byte[] fixedInputData,
    int r,
    bool useCounter)
  {
    this.ki = ki != null ? Arrays.Clone(ki) : throw new ArgumentException("A KDF requires Ki (a seed) as input");
    this.fixedInputData = fixedInputData != null ? Arrays.Clone(fixedInputData) : new byte[0];
    this.r = r;
    this.iv = iv != null ? Arrays.Clone(iv) : new byte[0];
    this.useCounter = useCounter;
  }

  public static KdfFeedbackParameters CreateWithCounter(
    byte[] ki,
    byte[] iv,
    byte[] fixedInputData,
    int r)
  {
    if (r != 8 && r != 16 /*0x10*/ && r != 24 && r != 32 /*0x20*/)
      throw new ArgumentException("Length of counter should be 8, 16, 24 or 32");
    return new KdfFeedbackParameters(ki, iv, fixedInputData, r, true);
  }

  public static KdfFeedbackParameters CreateWithoutCounter(
    byte[] ki,
    byte[] iv,
    byte[] fixedInputData)
  {
    return new KdfFeedbackParameters(ki, iv, fixedInputData, KdfFeedbackParameters.UNUSED_R, false);
  }

  public byte[] Ki => Arrays.Clone(this.ki);

  public byte[] Iv => Arrays.Clone(this.iv);

  public bool UseCounter => this.useCounter;

  public int R => this.r;

  public byte[] FixedInputData => Arrays.Clone(this.fixedInputData);
}
