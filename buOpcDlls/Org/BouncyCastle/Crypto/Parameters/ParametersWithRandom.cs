// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ParametersWithRandom
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ParametersWithRandom : ICipherParameters
{
  private readonly ICipherParameters m_parameters;
  private readonly SecureRandom m_random;

  public ParametersWithRandom(ICipherParameters parameters)
    : this(parameters, CryptoServicesRegistrar.GetSecureRandom())
  {
  }

  public ParametersWithRandom(ICipherParameters parameters, SecureRandom random)
  {
    if (parameters == null)
      throw new ArgumentNullException(nameof (parameters));
    if (random == null)
      throw new ArgumentNullException(nameof (random));
    this.m_parameters = parameters;
    this.m_random = random;
  }

  public ICipherParameters Parameters => this.m_parameters;

  public SecureRandom Random => this.m_random;
}
