// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DHKeyGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DHKeyGenerationParameters : KeyGenerationParameters
{
  private readonly DHParameters parameters;

  public DHKeyGenerationParameters(SecureRandom random, DHParameters parameters)
    : base(random, DHKeyGenerationParameters.GetStrength(parameters))
  {
    this.parameters = parameters;
  }

  public DHParameters Parameters => this.parameters;

  internal static int GetStrength(DHParameters parameters)
  {
    return parameters.L == 0 ? parameters.P.BitLength : parameters.L;
  }
}
