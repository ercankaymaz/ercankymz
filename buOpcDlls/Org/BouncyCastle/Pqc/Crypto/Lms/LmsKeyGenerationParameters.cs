// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Lms.LmsKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Lms;

public class LmsKeyGenerationParameters : KeyGenerationParameters
{
  private readonly LmsParameters m_lmsParameters;

  public LmsKeyGenerationParameters(LmsParameters lmsParameters, SecureRandom random)
    : base(random, LmsUtilities.CalculateStrength(lmsParameters))
  {
    this.m_lmsParameters = lmsParameters;
  }

  public LmsParameters LmsParameters => this.m_lmsParameters;
}
