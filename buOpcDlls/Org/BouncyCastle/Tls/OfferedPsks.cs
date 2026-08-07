// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.OfferedPsks
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class OfferedPsks
{
  private readonly IList<PskIdentity> m_identities;
  private readonly IList<byte[]> m_binders;
  private readonly int m_bindersSize;

  public OfferedPsks(IList<PskIdentity> identities)
    : this(identities, (IList<byte[]>) null, -1)
  {
  }

  private OfferedPsks(IList<PskIdentity> identities, IList<byte[]> binders, int bindersSize)
  {
    if (identities == null || identities.Count < 1)
      throw new ArgumentException("cannot be null or empty", nameof (identities));
    if (binders != null && identities.Count != binders.Count)
      throw new ArgumentException("must be the same length as 'identities' (or null)", nameof (binders));
    if (binders != null != bindersSize >= 0)
      throw new ArgumentException("must be >= 0 iff 'binders' are present", nameof (bindersSize));
    this.m_identities = identities;
    this.m_binders = binders;
    this.m_bindersSize = bindersSize;
  }

  public IList<byte[]> Binders => this.m_binders;

  public int BindersSize => this.m_bindersSize;

  public IList<PskIdentity> Identities => this.m_identities;

  public int GetIndexOfIdentity(PskIdentity pskIdentity)
  {
    int index = 0;
    for (int count = this.m_identities.Count; index < count; ++index)
    {
      if (pskIdentity.Equals((object) this.m_identities[index]))
        return index;
    }
    return -1;
  }

  public void Encode(Stream output)
  {
    int i1 = 0;
    foreach (PskIdentity identity in (IEnumerable<PskIdentity>) this.m_identities)
      i1 += identity.GetEncodedLength();
    TlsUtilities.CheckUint16(i1);
    TlsUtilities.WriteUint16(i1, output);
    foreach (PskIdentity identity in (IEnumerable<PskIdentity>) this.m_identities)
      identity.Encode(output);
    if (this.m_binders == null)
      return;
    int i2 = 0;
    foreach (byte[] binder in (IEnumerable<byte[]>) this.m_binders)
      i2 += 1 + binder.Length;
    TlsUtilities.CheckUint16(i2);
    TlsUtilities.WriteUint16(i2, output);
    foreach (byte[] binder in (IEnumerable<byte[]>) this.m_binders)
      TlsUtilities.WriteOpaque8(binder, output);
  }

  internal static void EncodeBinders(
    Stream output,
    TlsCrypto crypto,
    TlsHandshakeHash handshakeHash,
    OfferedPsks.BindersConfig bindersConfig)
  {
    TlsPsk[] psks = bindersConfig.m_psks;
    TlsSecret[] earlySecrets = bindersConfig.m_earlySecrets;
    int i = bindersConfig.m_bindersSize - 2;
    TlsUtilities.CheckUint16(i);
    TlsUtilities.WriteUint16(i, output);
    int num = 0;
    for (int index = 0; index < psks.Length; ++index)
    {
      TlsPsk tlsPsk = psks[index];
      TlsSecret earlySecret = earlySecrets[index];
      int hashForPrf = TlsCryptoUtilities.GetHashForPrf(tlsPsk.PrfAlgorithm);
      TlsHash hash1 = crypto.CreateHash(hashForPrf);
      handshakeHash.CopyBufferTo((Stream) new TlsHashSink(hash1));
      byte[] hash2 = hash1.CalculateHash();
      byte[] pskBinder = TlsUtilities.CalculatePskBinder(crypto, true, hashForPrf, earlySecret, hash2);
      num += 1 + pskBinder.Length;
      TlsUtilities.WriteOpaque8(pskBinder, output);
    }
    if (i != num)
      throw new TlsFatalAlert((short) 80 /*0x50*/);
  }

  internal static int GetBindersSize(TlsPsk[] psks)
  {
    int i = 0;
    for (int index = 0; index < psks.Length; ++index)
    {
      int hashForPrf = TlsCryptoUtilities.GetHashForPrf(psks[index].PrfAlgorithm);
      i += 1 + TlsCryptoUtilities.GetHashOutputSize(hashForPrf);
    }
    TlsUtilities.CheckUint16(i);
    return 2 + i;
  }

  public static OfferedPsks Parse(Stream input)
  {
    List<PskIdentity> identities = new List<PskIdentity>();
    int length1 = TlsUtilities.ReadUint16(input);
    MemoryStream input1 = length1 >= 7 ? new MemoryStream(TlsUtilities.ReadFully(length1, input), false) : throw new TlsFatalAlert((short) 50);
    do
    {
      PskIdentity pskIdentity = PskIdentity.Parse((Stream) input1);
      identities.Add(pskIdentity);
    }
    while (input1.Position < input1.Length);
    List<byte[]> binders = new List<byte[]>();
    int length2 = TlsUtilities.ReadUint16(input);
    MemoryStream input2 = length2 >= 33 ? new MemoryStream(TlsUtilities.ReadFully(length2, input), false) : throw new TlsFatalAlert((short) 50);
    do
    {
      byte[] numArray = TlsUtilities.ReadOpaque8((Stream) input2, 32 /*0x20*/);
      binders.Add(numArray);
    }
    while (input2.Position < input2.Length);
    return new OfferedPsks((IList<PskIdentity>) identities, (IList<byte[]>) binders, 2 + length2);
  }

  internal class BindersConfig
  {
    internal readonly TlsPsk[] m_psks;
    internal readonly short[] m_pskKeyExchangeModes;
    internal readonly TlsSecret[] m_earlySecrets;
    internal int m_bindersSize;

    internal BindersConfig(
      TlsPsk[] psks,
      short[] pskKeyExchangeModes,
      TlsSecret[] earlySecrets,
      int bindersSize)
    {
      this.m_psks = psks;
      this.m_pskKeyExchangeModes = pskKeyExchangeModes;
      this.m_earlySecrets = earlySecrets;
      this.m_bindersSize = bindersSize;
    }
  }

  internal class SelectedConfig
  {
    internal readonly int m_index;
    internal readonly TlsPsk m_psk;
    internal readonly short[] m_pskKeyExchangeModes;
    internal readonly TlsSecret m_earlySecret;

    internal SelectedConfig(
      int index,
      TlsPsk psk,
      short[] pskKeyExchangeModes,
      TlsSecret earlySecret)
    {
      this.m_index = index;
      this.m_psk = psk;
      this.m_pskKeyExchangeModes = pskKeyExchangeModes;
      this.m_earlySecret = earlySecret;
    }
  }
}
