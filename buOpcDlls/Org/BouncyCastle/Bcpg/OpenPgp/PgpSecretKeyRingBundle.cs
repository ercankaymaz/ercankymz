// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSecretKeyRingBundle
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSecretKeyRingBundle
{
  private readonly IDictionary<long, PgpSecretKeyRing> m_secretRings;
  private readonly IList<long> m_order;

  private PgpSecretKeyRingBundle(IDictionary<long, PgpSecretKeyRing> secretRings, IList<long> order)
  {
    this.m_secretRings = secretRings;
    this.m_order = order;
  }

  public PgpSecretKeyRingBundle(byte[] encoding)
    : this((Stream) new MemoryStream(encoding, false))
  {
  }

  public PgpSecretKeyRingBundle(Stream inputStream)
    : this((IEnumerable<PgpObject>) new PgpObjectFactory(inputStream).AllPgpObjects())
  {
  }

  public PgpSecretKeyRingBundle(IEnumerable<PgpObject> e)
  {
    this.m_secretRings = (IDictionary<long, PgpSecretKeyRing>) new Dictionary<long, PgpSecretKeyRing>();
    this.m_order = (IList<long>) new List<long>();
    foreach (PgpObject pgpObject in e)
    {
      switch (pgpObject)
      {
        case PgpMarker _:
          continue;
        case PgpSecretKeyRing pgpSecretKeyRing:
          long keyId = pgpSecretKeyRing.GetPublicKey().KeyId;
          this.m_secretRings.Add(keyId, pgpSecretKeyRing);
          this.m_order.Add(keyId);
          continue;
        default:
          throw new PgpException(Platform.GetTypeName((object) pgpObject) + " found where PgpSecretKeyRing expected");
      }
    }
  }

  public int Count => this.m_order.Count;

  public IEnumerable<PgpSecretKeyRing> GetKeyRings()
  {
    return CollectionUtilities.Proxy<PgpSecretKeyRing>((IEnumerable<PgpSecretKeyRing>) this.m_secretRings.Values);
  }

  public IEnumerable<PgpSecretKeyRing> GetKeyRings(string userId)
  {
    return this.GetKeyRings(userId, false, false);
  }

  public IEnumerable<PgpSecretKeyRing> GetKeyRings(string userId, bool matchPartial)
  {
    return this.GetKeyRings(userId, matchPartial, false);
  }

  public IEnumerable<PgpSecretKeyRing> GetKeyRings(
    string userID,
    bool matchPartial,
    bool ignoreCase)
  {
    CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
    CompareOptions compareOptions = ignoreCase ? CompareOptions.OrdinalIgnoreCase : CompareOptions.Ordinal;
    foreach (PgpSecretKeyRing secRing in this.GetKeyRings())
    {
      foreach (string userId in secRing.GetSecretKey().UserIds)
      {
        if (matchPartial)
        {
          if (compareInfo.IndexOf(userId, userID, compareOptions) >= 0)
            yield return secRing;
        }
        else if (compareInfo.Compare(userId, userID, compareOptions) == 0)
          yield return secRing;
      }
    }
  }

  public PgpSecretKey GetSecretKey(long keyId)
  {
    foreach (PgpSecretKeyRing keyRing in this.GetKeyRings())
    {
      PgpSecretKey secretKey = keyRing.GetSecretKey(keyId);
      if (secretKey != null)
        return secretKey;
    }
    return (PgpSecretKey) null;
  }

  public PgpSecretKeyRing GetSecretKeyRing(long keyId)
  {
    PgpSecretKeyRing secretKeyRing;
    if (this.m_secretRings.TryGetValue(keyId, out secretKeyRing))
      return secretKeyRing;
    foreach (PgpSecretKeyRing keyRing in this.GetKeyRings())
    {
      if (keyRing.GetSecretKey(keyId) != null)
        return keyRing;
    }
    return (PgpSecretKeyRing) null;
  }

  public bool Contains(long keyID) => this.GetSecretKey(keyID) != null;

  public byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    this.Encode((Stream) outStr);
    return outStr.ToArray();
  }

  public void Encode(Stream outStr)
  {
    BcpgOutputStream outStr1 = BcpgOutputStream.Wrap(outStr);
    foreach (long key in (IEnumerable<long>) this.m_order)
      this.m_secretRings[key].Encode((Stream) outStr1);
  }

  public static PgpSecretKeyRingBundle AddSecretKeyRing(
    PgpSecretKeyRingBundle bundle,
    PgpSecretKeyRing secretKeyRing)
  {
    long keyId = secretKeyRing.GetPublicKey().KeyId;
    if (bundle.m_secretRings.ContainsKey(keyId))
      throw new ArgumentException("Collection already contains a key with a keyId for the passed in ring.");
    Dictionary<long, PgpSecretKeyRing> secretRings = new Dictionary<long, PgpSecretKeyRing>(bundle.m_secretRings);
    List<long> order = new List<long>((IEnumerable<long>) bundle.m_order);
    secretRings[keyId] = secretKeyRing;
    order.Add(keyId);
    return new PgpSecretKeyRingBundle((IDictionary<long, PgpSecretKeyRing>) secretRings, (IList<long>) order);
  }

  public static PgpSecretKeyRingBundle RemoveSecretKeyRing(
    PgpSecretKeyRingBundle bundle,
    PgpSecretKeyRing secretKeyRing)
  {
    long keyId = secretKeyRing.GetPublicKey().KeyId;
    if (!bundle.m_secretRings.ContainsKey(keyId))
      throw new ArgumentException("Collection does not contain a key with a keyId for the passed in ring.");
    Dictionary<long, PgpSecretKeyRing> secretRings = new Dictionary<long, PgpSecretKeyRing>(bundle.m_secretRings);
    List<long> order = new List<long>((IEnumerable<long>) bundle.m_order);
    secretRings.Remove(keyId);
    order.Remove(keyId);
    return new PgpSecretKeyRingBundle((IDictionary<long, PgpSecretKeyRing>) secretRings, (IList<long>) order);
  }
}
