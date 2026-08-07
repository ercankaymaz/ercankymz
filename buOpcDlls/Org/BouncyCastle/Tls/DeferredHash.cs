// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DeferredHash
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class DeferredHash : TlsHandshakeHash, TlsHash
{
  private const int BufferingHashLimit = 4;
  private readonly TlsContext m_context;
  private DigestInputBuffer m_buf;
  private IDictionary<int, TlsHash> m_hashes;
  private bool m_forceBuffering;
  private bool m_sealed;

  internal DeferredHash(TlsContext context)
  {
    this.m_context = context;
    this.m_buf = new DigestInputBuffer();
    this.m_hashes = (IDictionary<int, TlsHash>) new Dictionary<int, TlsHash>();
    this.m_forceBuffering = false;
    this.m_sealed = false;
  }

  public void CopyBufferTo(Stream output)
  {
    if (this.m_buf == null)
      throw new InvalidOperationException("Not buffering");
    this.m_buf.CopyInputTo(output);
  }

  public void ForceBuffering()
  {
    if (this.m_sealed)
      throw new InvalidOperationException("Too late to force buffering");
    this.m_forceBuffering = true;
  }

  public void NotifyPrfDetermined()
  {
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    switch (securityParameters.PrfAlgorithm)
    {
      case 0:
      case 1:
        this.CheckTrackingHash(1);
        this.CheckTrackingHash(2);
        break;
      default:
        this.CheckTrackingHash(securityParameters.PrfCryptoHashAlgorithm);
        break;
    }
  }

  public void TrackHashAlgorithm(int cryptoHashAlgorithm)
  {
    if (this.m_sealed)
      throw new InvalidOperationException("Too late to track more hash algorithms");
    this.CheckTrackingHash(cryptoHashAlgorithm);
  }

  public void SealHashAlgorithms()
  {
    this.m_sealed = !this.m_sealed ? true : throw new InvalidOperationException("Already sealed");
    this.CheckStopBuffering();
  }

  public void StopTracking()
  {
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    IDictionary<int, TlsHash> newHashes = (IDictionary<int, TlsHash>) new Dictionary<int, TlsHash>();
    switch (securityParameters.PrfAlgorithm)
    {
      case 0:
      case 1:
        this.CloneHash(newHashes, 1);
        this.CloneHash(newHashes, 2);
        break;
      default:
        this.CloneHash(newHashes, securityParameters.PrfCryptoHashAlgorithm);
        break;
    }
    this.m_buf = (DigestInputBuffer) null;
    this.m_hashes = newHashes;
    this.m_forceBuffering = false;
    this.m_sealed = true;
  }

  public TlsHash ForkPrfHash()
  {
    this.CheckStopBuffering();
    SecurityParameters securityParameters = this.m_context.SecurityParameters;
    TlsHash hash;
    switch (securityParameters.PrfAlgorithm)
    {
      case 0:
      case 1:
        hash = (TlsHash) new CombinedHash(this.m_context, this.CloneHash(1), this.CloneHash(2));
        break;
      default:
        hash = this.CloneHash(securityParameters.PrfCryptoHashAlgorithm);
        break;
    }
    if (this.m_buf != null)
      this.m_buf.UpdateDigest(hash);
    return hash;
  }

  public byte[] GetFinalHash(int cryptoHashAlgorithm)
  {
    TlsHash tlsHash;
    if (!this.m_hashes.TryGetValue(cryptoHashAlgorithm, out tlsHash))
      throw new InvalidOperationException($"CryptoHashAlgorithm.{cryptoHashAlgorithm.ToString()} is not being tracked");
    this.CheckStopBuffering();
    TlsHash hash = tlsHash.CloneHash();
    if (this.m_buf != null)
      this.m_buf.UpdateDigest(hash);
    return hash.CalculateHash();
  }

  public void Update(byte[] input, int inOff, int len)
  {
    if (this.m_buf != null)
    {
      this.m_buf.Write(input, inOff, len);
    }
    else
    {
      foreach (TlsHash tlsHash in (IEnumerable<TlsHash>) this.m_hashes.Values)
        tlsHash.Update(input, inOff, len);
    }
  }

  public byte[] CalculateHash()
  {
    throw new InvalidOperationException("Use 'ForkPrfHash' to get a definite hash");
  }

  public TlsHash CloneHash()
  {
    throw new InvalidOperationException("attempt to clone a DeferredHash");
  }

  public void Reset()
  {
    if (this.m_buf != null)
    {
      this.m_buf.SetLength(0L);
    }
    else
    {
      foreach (TlsHash tlsHash in (IEnumerable<TlsHash>) this.m_hashes.Values)
        tlsHash.Reset();
    }
  }

  private void CheckStopBuffering()
  {
    if (this.m_forceBuffering || !this.m_sealed || this.m_buf == null || this.m_hashes.Count > 4)
      return;
    foreach (TlsHash hash in (IEnumerable<TlsHash>) this.m_hashes.Values)
      this.m_buf.UpdateDigest(hash);
    this.m_buf = (DigestInputBuffer) null;
  }

  private void CheckTrackingHash(int cryptoHashAlgorithm)
  {
    if (this.m_hashes.ContainsKey(cryptoHashAlgorithm))
      return;
    TlsHash hash = this.m_context.Crypto.CreateHash(cryptoHashAlgorithm);
    this.m_hashes[cryptoHashAlgorithm] = hash;
  }

  private TlsHash CloneHash(int cryptoHashAlgorithm)
  {
    return this.m_hashes[cryptoHashAlgorithm].CloneHash();
  }

  private void CloneHash(IDictionary<int, TlsHash> newHashes, int cryptoHashAlgorithm)
  {
    TlsHash hash = this.CloneHash(cryptoHashAlgorithm);
    if (this.m_buf != null)
      this.m_buf.UpdateDigest(hash);
    newHashes[cryptoHashAlgorithm] = hash;
  }
}
