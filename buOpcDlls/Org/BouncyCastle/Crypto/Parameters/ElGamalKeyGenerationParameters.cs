// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ElGamalKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ElGamalKeyGenerationParameters : KeyGenerationParameters
{
  private readonly ElGamalParameters parameters;

  public ElGamalKeyGenerationParameters(SecureRandom random, ElGamalParameters parameters)
    : base(random, ElGamalKeyGenerationParameters.GetStrength(parameters))
  {
    this.parameters = parameters;
  }

  public ElGamalParameters Parameters => this.parameters;

  internal static int GetStrength(ElGamalParameters parameters)
  {
    return parameters.L == 0 ? parameters.P.BitLength : parameters.L;
  }
}
