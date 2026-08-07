// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ParametersWithSalt
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ParametersWithSalt : ICipherParameters
{
  private readonly ICipherParameters m_parameters;
  private readonly byte[] m_salt;

  public ParametersWithSalt(ICipherParameters parameters, byte[] salt)
  {
    if (salt == null)
      throw new ArgumentNullException(nameof (salt));
    this.m_parameters = parameters;
    this.m_salt = (byte[]) salt.Clone();
  }

  public ParametersWithSalt(ICipherParameters parameters, byte[] salt, int saltOff, int saltLen)
  {
    if (salt == null)
      throw new ArgumentNullException(nameof (salt));
    this.m_parameters = parameters;
    this.m_salt = new byte[saltLen];
    Array.Copy((Array) salt, saltOff, (Array) this.m_salt, 0, saltLen);
  }

  public byte[] GetSalt() => (byte[]) this.m_salt.Clone();

  public ICipherParameters Parameters => this.m_parameters;
}
