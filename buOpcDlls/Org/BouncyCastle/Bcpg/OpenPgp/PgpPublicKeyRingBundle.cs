// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPublicKeyRingBundle
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

public class PgpPublicKeyRingBundle
{
  private readonly IDictionary<long, PgpPublicKeyRing> m_pubRings;
  private readonly IList<long> m_order;

  private PgpPublicKeyRingBundle(IDictionary<long, PgpPublicKeyRing> pubRings, IList<long> order)
  {
    this.m_pubRings = pubRings;
    this.m_order = order;
  }

  public PgpPublicKeyRingBundle(byte[] encoding)
    : this((Stream) new MemoryStream(encoding, false))
  {
  }

  public PgpPublicKeyRingBundle(Stream inputStream)
    : this((IEnumerable<PgpObject>) new PgpObjectFactory(inputStream).AllPgpObjects())
  {
  }

  public PgpPublicKeyRingBundle(IEnumerable<PgpObject> e)
  {
    this.m_pubRings = (IDictionary<long, PgpPublicKeyRing>) new Dictionary<long, PgpPublicKeyRing>();
    this.m_order = (IList<long>) new List<long>();
    foreach (PgpObject pgpObject in e)
    {
      switch (pgpObject)
      {
        case PgpMarker _:
          continue;
        case PgpPublicKeyRing pgpPublicKeyRing:
          long keyId = pgpPublicKeyRing.GetPublicKey().KeyId;
          this.m_pubRings.Add(keyId, pgpPublicKeyRing);
          this.m_order.Add(keyId);
          continue;
        default:
          throw new PgpException(Platform.GetTypeName((object) pgpObject) + " found where PgpPublicKeyRing expected");
      }
    }
  }

  public int Count => this.m_order.Count;

  public IEnumerable<PgpPublicKeyRing> GetKeyRings()
  {
    return CollectionUtilities.Proxy<PgpPublicKeyRing>((IEnumerable<PgpPublicKeyRing>) this.m_pubRings.Values);
  }

  public IEnumerable<PgpPublicKeyRing> GetKeyRings(string userId)
  {
    return this.GetKeyRings(userId, false, false);
  }

  public IEnumerable<PgpPublicKeyRing> GetKeyRings(string userId, bool matchPartial)
  {
    return this.GetKeyRings(userId, matchPartial, false);
  }

  public IEnumerable<PgpPublicKeyRing> GetKeyRings(
    string userID,
    bool matchPartial,
    bool ignoreCase)
  {
    CompareInfo compareInfo = CultureInfo.InvariantCulture.CompareInfo;
    CompareOptions compareOptions = ignoreCase ? CompareOptions.OrdinalIgnoreCase : CompareOptions.Ordinal;
    foreach (PgpPublicKeyRing pubRing in this.GetKeyRings())
    {
      foreach (string userId in pubRing.GetPublicKey().GetUserIds())
      {
        if (matchPartial)
        {
          if (compareInfo.IndexOf(userId, userID, compareOptions) >= 0)
            yield return pubRing;
        }
        else if (compareInfo.Compare(userId, userID, compareOptions) == 0)
          yield return pubRing;
      }
    }
  }

  public PgpPublicKey GetPublicKey(long keyId)
  {
    foreach (PgpPublicKeyRing keyRing in this.GetKeyRings())
    {
      PgpPublicKey publicKey = keyRing.GetPublicKey(keyId);
      if (publicKey != null)
        return publicKey;
    }
    return (PgpPublicKey) null;
  }

  public PgpPublicKeyRing GetPublicKeyRing(long keyId)
  {
    PgpPublicKeyRing publicKeyRing;
    if (this.m_pubRings.TryGetValue(keyId, out publicKeyRing))
      return publicKeyRing;
    foreach (PgpPublicKeyRing keyRing in this.GetKeyRings())
    {
      if (keyRing.GetPublicKey(keyId) != null)
        return keyRing;
    }
    return (PgpPublicKeyRing) null;
  }

  public bool Contains(long keyID) => this.GetPublicKey(keyID) != null;

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
      this.m_pubRings[key].Encode((Stream) outStr1);
  }

  public static PgpPublicKeyRingBundle AddPublicKeyRing(
    PgpPublicKeyRingBundle bundle,
    PgpPublicKeyRing publicKeyRing)
  {
    long keyId = publicKeyRing.GetPublicKey().KeyId;
    if (bundle.m_pubRings.ContainsKey(keyId))
      throw new ArgumentException("Bundle already contains a key with a keyId for the passed in ring.");
    Dictionary<long, PgpPublicKeyRing> pubRings = new Dictionary<long, PgpPublicKeyRing>(bundle.m_pubRings);
    List<long> order = new List<long>((IEnumerable<long>) bundle.m_order);
    pubRings[keyId] = publicKeyRing;
    order.Add(keyId);
    return new PgpPublicKeyRingBundle((IDictionary<long, PgpPublicKeyRing>) pubRings, (IList<long>) order);
  }

  public static PgpPublicKeyRingBundle RemovePublicKeyRing(
    PgpPublicKeyRingBundle bundle,
    PgpPublicKeyRing publicKeyRing)
  {
    long keyId = publicKeyRing.GetPublicKey().KeyId;
    if (!bundle.m_pubRings.ContainsKey(keyId))
      throw new ArgumentException("Bundle does not contain a key with a keyId for the passed in ring.");
    Dictionary<long, PgpPublicKeyRing> pubRings = new Dictionary<long, PgpPublicKeyRing>(bundle.m_pubRings);
    List<long> order = new List<long>((IEnumerable<long>) bundle.m_order);
    pubRings.Remove(keyId);
    order.Remove(keyId);
    return new PgpPublicKeyRingBundle((IDictionary<long, PgpPublicKeyRing>) pubRings, (IList<long>) order);
  }
}
