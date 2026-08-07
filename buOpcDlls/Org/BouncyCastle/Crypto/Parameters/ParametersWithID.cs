// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ParametersWithID
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ParametersWithID : ICipherParameters
{
  private readonly ICipherParameters m_parameters;
  private readonly byte[] m_id;

  public ParametersWithID(ICipherParameters parameters, byte[] id)
    : this(parameters, id, 0, id.Length)
  {
    if (id == null)
      throw new ArgumentNullException(nameof (id));
    this.m_parameters = parameters;
    this.m_id = (byte[]) id.Clone();
  }

  public ParametersWithID(ICipherParameters parameters, byte[] id, int idOff, int idLen)
  {
    if (id == null)
      throw new ArgumentNullException(nameof (id));
    this.m_parameters = parameters;
    this.m_id = new byte[idLen];
    Array.Copy((Array) id, idOff, (Array) this.m_id, 0, idLen);
  }

  public byte[] GetID() => (byte[]) this.m_id.Clone();

  public ICipherParameters Parameters => this.m_parameters;
}
