// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.ParametersWithIV
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public class ParametersWithIV : ICipherParameters
{
  private readonly ICipherParameters m_parameters;
  private readonly byte[] m_iv;

  internal static ICipherParameters ApplyOptionalIV(ICipherParameters parameters, byte[] iv)
  {
    return iv != null ? (ICipherParameters) new ParametersWithIV(parameters, iv) : parameters;
  }

  public ParametersWithIV(ICipherParameters parameters, byte[] iv)
    : this(parameters, iv, 0, iv.Length)
  {
    if (iv == null)
      throw new ArgumentNullException(nameof (iv));
    this.m_parameters = parameters;
    this.m_iv = (byte[]) iv.Clone();
  }

  public ParametersWithIV(ICipherParameters parameters, byte[] iv, int ivOff, int ivLen)
  {
    if (iv == null)
      throw new ArgumentNullException(nameof (iv));
    this.m_parameters = parameters;
    this.m_iv = new byte[ivLen];
    Array.Copy((Array) iv, ivOff, (Array) this.m_iv, 0, ivLen);
  }

  private ParametersWithIV(ICipherParameters parameters, int ivLength)
  {
    if (ivLength < 0)
      throw new ArgumentOutOfRangeException(nameof (ivLength));
    this.m_parameters = parameters;
    this.m_iv = new byte[ivLength];
  }

  public byte[] GetIV() => (byte[]) this.m_iv.Clone();

  public int IVLength => this.m_iv.Length;

  public ICipherParameters Parameters => this.m_parameters;
}
