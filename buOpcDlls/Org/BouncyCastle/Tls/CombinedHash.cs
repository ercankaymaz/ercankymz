// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.CombinedHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Tls;

public class CombinedHash : TlsHash
{
  protected readonly TlsContext m_context;
  protected readonly TlsCrypto m_crypto;
  protected readonly TlsHash m_md5;
  protected readonly TlsHash m_sha1;

  internal CombinedHash(TlsContext context, TlsHash md5, TlsHash sha1)
  {
    this.m_context = context;
    this.m_crypto = context.Crypto;
    this.m_md5 = md5;
    this.m_sha1 = sha1;
  }

  public CombinedHash(TlsCrypto crypto)
  {
    this.m_crypto = crypto;
    this.m_md5 = crypto.CreateHash(1);
    this.m_sha1 = crypto.CreateHash(2);
  }

  public CombinedHash(CombinedHash t)
  {
    this.m_context = t.m_context;
    this.m_crypto = t.m_crypto;
    this.m_md5 = t.m_md5.CloneHash();
    this.m_sha1 = t.m_sha1.CloneHash();
  }

  public virtual void Update(byte[] input, int inOff, int len)
  {
    this.m_md5.Update(input, inOff, len);
    this.m_sha1.Update(input, inOff, len);
  }

  public virtual byte[] CalculateHash()
  {
    if (this.m_context != null && TlsUtilities.IsSsl(this.m_context))
      Ssl3Utilities.CompleteCombinedHash(this.m_context, this.m_md5, this.m_sha1);
    return Arrays.Concatenate(this.m_md5.CalculateHash(), this.m_sha1.CalculateHash());
  }

  public virtual TlsHash CloneHash() => (TlsHash) new CombinedHash(this);

  public virtual void Reset()
  {
    this.m_md5.Reset();
    this.m_sha1.Reset();
  }
}
