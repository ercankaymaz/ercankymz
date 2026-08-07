// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.BasicTlsPskExternal
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class BasicTlsPskExternal : TlsPskExternal, TlsPsk
{
  protected readonly byte[] m_identity;
  protected readonly TlsSecret m_key;
  protected readonly int m_prfAlgorithm;

  public BasicTlsPskExternal(byte[] identity, TlsSecret key)
    : this(identity, key, 4)
  {
  }

  public BasicTlsPskExternal(byte[] identity, TlsSecret key, int prfAlgorithm)
  {
    this.m_identity = Arrays.Clone(identity);
    this.m_key = key;
    this.m_prfAlgorithm = prfAlgorithm;
  }

  public virtual byte[] Identity => this.m_identity;

  public virtual TlsSecret Key => this.m_key;

  public virtual int PrfAlgorithm => this.m_prfAlgorithm;
}
