// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Parameters.Blake3Parameters
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Parameters;

public sealed class Blake3Parameters : ICipherParameters
{
  private const int KeyLen = 32 /*0x20*/;
  private byte[] m_theKey;
  private byte[] m_theContext;

  public static Blake3Parameters Context(byte[] pContext)
  {
    return pContext != null ? new Blake3Parameters()
    {
      m_theContext = Arrays.Clone(pContext)
    } : throw new ArgumentNullException(nameof (pContext));
  }

  public static Blake3Parameters Key(byte[] pKey)
  {
    if (pKey == null)
      throw new ArgumentNullException(nameof (pKey));
    return pKey.Length == 32 /*0x20*/ ? new Blake3Parameters()
    {
      m_theKey = Arrays.Clone(pKey)
    } : throw new ArgumentException("Invalid key length", nameof (pKey));
  }

  public byte[] GetKey() => Arrays.Clone(this.m_theKey);

  public void ClearKey() => Arrays.Fill(this.m_theKey, (byte) 0);

  public byte[] GetContext() => Arrays.Clone(this.m_theContext);
}
