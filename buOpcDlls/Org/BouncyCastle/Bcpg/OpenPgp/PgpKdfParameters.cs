// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKdfParameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

internal sealed class PgpKdfParameters
{
  private readonly HashAlgorithmTag m_hashAlgorithm;
  private readonly SymmetricKeyAlgorithmTag m_symmetricWrapAlgorithm;

  public PgpKdfParameters(
    HashAlgorithmTag hashAlgorithm,
    SymmetricKeyAlgorithmTag symmetricWrapAlgorithm)
  {
    this.m_hashAlgorithm = hashAlgorithm;
    this.m_symmetricWrapAlgorithm = symmetricWrapAlgorithm;
  }

  public HashAlgorithmTag HashAlgorithm => this.m_hashAlgorithm;

  public SymmetricKeyAlgorithmTag SymmetricWrapAlgorithm => this.m_symmetricWrapAlgorithm;
}
