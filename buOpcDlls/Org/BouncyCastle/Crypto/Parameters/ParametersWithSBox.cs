// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ParametersWithSBox
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ParametersWithSBox : ICipherParameters
{
  private readonly ICipherParameters m_parameters;
  private readonly byte[] m_sBox;

  public ParametersWithSBox(ICipherParameters parameters, byte[] sBox)
  {
    this.m_parameters = parameters;
    this.m_sBox = sBox;
  }

  public byte[] GetSBox() => this.m_sBox;

  public ICipherParameters Parameters => this.m_parameters;
}
