// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.TlsSrpConfig
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto;

public class TlsSrpConfig
{
  protected BigInteger[] m_explicitNG;

  public BigInteger[] GetExplicitNG() => (BigInteger[]) this.m_explicitNG.Clone();

  public void SetExplicitNG(BigInteger[] explicitNG)
  {
    this.m_explicitNG = (BigInteger[]) explicitNG.Clone();
  }
}
