// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.Crypto.Impl.AbstractTlsSecret
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls.Crypto.Impl;

public abstract class AbstractTlsSecret : TlsSecret
{
  protected byte[] m_data;

  protected static byte[] CopyData(AbstractTlsSecret other) => other.CopyData();

  protected AbstractTlsSecret(byte[] data) => this.m_data = data;

  protected virtual void CheckAlive()
  {
    if (this.m_data == null)
      throw new InvalidOperationException("Secret has already been extracted or destroyed");
  }

  protected abstract AbstractTlsCrypto Crypto { get; }

  public virtual byte[] CalculateHmac(int cryptoHashAlgorithm, byte[] buf, int off, int len)
  {
    lock (this)
    {
      this.CheckAlive();
      TlsHmac hmacForHash = this.Crypto.CreateHmacForHash(cryptoHashAlgorithm);
      hmacForHash.SetKey(this.m_data, 0, this.m_data.Length);
      hmacForHash.Update(buf, off, len);
      return hmacForHash.CalculateMac();
    }
  }

  public abstract TlsSecret DeriveUsingPrf(
    int prfAlgorithm,
    string label,
    byte[] seed,
    int length);

  public virtual void Destroy()
  {
    lock (this)
    {
      if (this.m_data == null)
        return;
      Array.Clear((Array) this.m_data, 0, this.m_data.Length);
      this.m_data = (byte[]) null;
    }
  }

  public virtual byte[] Encrypt(TlsEncryptor encryptor)
  {
    lock (this)
    {
      this.CheckAlive();
      return encryptor.Encrypt(this.m_data, 0, this.m_data.Length);
    }
  }

  public virtual byte[] Extract()
  {
    lock (this)
    {
      this.CheckAlive();
      byte[] data = this.m_data;
      this.m_data = (byte[]) null;
      return data;
    }
  }

  public abstract TlsSecret HkdfExpand(int cryptoHashAlgorithm, byte[] info, int length);

  public abstract TlsSecret HkdfExtract(int cryptoHashAlgorithm, TlsSecret ikm);

  public virtual bool IsAlive()
  {
    lock (this)
      return this.m_data != null;
  }

  public virtual int Length
  {
    get
    {
      lock (this)
      {
        this.CheckAlive();
        return this.m_data.Length;
      }
    }
  }

  internal virtual byte[] CopyData()
  {
    lock (this)
      return Arrays.Clone(this.m_data);
  }
}
