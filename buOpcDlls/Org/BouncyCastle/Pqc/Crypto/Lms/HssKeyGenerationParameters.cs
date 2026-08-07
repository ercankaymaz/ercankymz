// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.HssKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public sealed class HssKeyGenerationParameters : KeyGenerationParameters
{
  private readonly LmsParameters[] m_lmsParameters;

  private static LmsParameters[] ValidateLmsParameters(LmsParameters[] lmsParameters)
  {
    if (lmsParameters == null)
      throw new ArgumentNullException(nameof (lmsParameters));
    return lmsParameters.Length >= 1 && lmsParameters.Length <= 8 ? lmsParameters : throw new ArgumentException("length should be between 1 and 8 inclusive", nameof (lmsParameters));
  }

  public HssKeyGenerationParameters(LmsParameters[] lmsParameters, SecureRandom random)
    : base(random, LmsUtilities.CalculateStrength(HssKeyGenerationParameters.ValidateLmsParameters(lmsParameters)[0]))
  {
    this.m_lmsParameters = lmsParameters;
  }

  public int Depth => this.m_lmsParameters.Length;

  public LmsParameters GetLmsParameters(int index)
  {
    if (index < 0 || index >= this.m_lmsParameters.Length)
      throw new ArgumentOutOfRangeException(nameof (index));
    return this.m_lmsParameters[index];
  }
}
