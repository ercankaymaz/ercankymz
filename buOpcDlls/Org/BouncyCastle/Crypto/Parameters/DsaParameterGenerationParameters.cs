// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.DsaParameterGenerationParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class DsaParameterGenerationParameters
{
  public const int DigitalSignatureUsage = 1;
  public const int KeyEstablishmentUsage = 2;
  private readonly int l;
  private readonly int n;
  private readonly int certainty;
  private readonly SecureRandom random;
  private readonly int usageIndex;

  public DsaParameterGenerationParameters(int L, int N, int certainty, SecureRandom random)
    : this(L, N, certainty, random, -1)
  {
  }

  public DsaParameterGenerationParameters(
    int L,
    int N,
    int certainty,
    SecureRandom random,
    int usageIndex)
  {
    this.l = L;
    this.n = N;
    this.certainty = certainty;
    this.random = random;
    this.usageIndex = usageIndex;
  }

  public virtual int L => this.l;

  public virtual int N => this.n;

  public virtual int UsageIndex => this.usageIndex;

  public virtual int Certainty => this.certainty;

  public virtual SecureRandom Random => this.random;
}
