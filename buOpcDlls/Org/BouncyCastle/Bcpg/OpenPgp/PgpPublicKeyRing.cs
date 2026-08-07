// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpPublicKeyRing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpPublicKeyRing : PgpKeyRing
{
  private readonly IList<PgpPublicKey> keys;

  public PgpPublicKeyRing(byte[] encoding)
    : this((Stream) new MemoryStream(encoding, false))
  {
  }

  internal PgpPublicKeyRing(IList<PgpPublicKey> pubKeys) => this.keys = pubKeys;

  public PgpPublicKeyRing(Stream inputStream)
  {
    this.keys = (IList<PgpPublicKey>) new List<PgpPublicKey>();
    BcpgInputStream bcpgInputStream = BcpgInputStream.Wrap(inputStream);
    PacketTag packetTag = bcpgInputStream.SkipMarkerPackets();
    switch (packetTag)
    {
      case PacketTag.PublicKey:
      case PacketTag.PublicSubkey:
        PublicKeyPacket publicPk = PgpPublicKeyRing.ReadPublicKeyPacket(bcpgInputStream);
        TrustPacket trustPk = PgpKeyRing.ReadOptionalTrustPacket(bcpgInputStream);
        IList<PgpSignature> keySigs = PgpKeyRing.ReadSignaturesAndTrust(bcpgInputStream);
        IList<IUserDataPacket> ids;
        IList<TrustPacket> idTrusts;
        IList<IList<PgpSignature>> idSigs;
        PgpKeyRing.ReadUserIDs(bcpgInputStream, out ids, out idTrusts, out idSigs);
        this.keys.Add(new PgpPublicKey(publicPk, trustPk, keySigs, ids, idTrusts, idSigs));
        while (bcpgInputStream.NextPacketTag() == PacketTag.PublicSubkey)
          this.keys.Add(PgpPublicKeyRing.ReadSubkey(bcpgInputStream));
        break;
      default:
        throw new IOException("public key ring doesn't start with public key tag: tag 0x" + ((int) packetTag).ToString("X"));
    }
  }

  public virtual PgpPublicKey GetPublicKey() => this.keys[0];

  public virtual PgpPublicKey GetPublicKey(long keyId)
  {
    foreach (PgpPublicKey key in (IEnumerable<PgpPublicKey>) this.keys)
    {
      if (keyId == key.KeyId)
        return key;
    }
    return (PgpPublicKey) null;
  }

  public virtual IEnumerable<PgpPublicKey> GetPublicKeys()
  {
    return CollectionUtilities.Proxy<PgpPublicKey>((IEnumerable<PgpPublicKey>) this.keys);
  }

  public virtual byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    this.Encode((Stream) outStr);
    return outStr.ToArray();
  }

  public virtual void Encode(Stream outStr)
  {
    if (outStr == null)
      throw new ArgumentNullException(nameof (outStr));
    foreach (PgpPublicKey key in (IEnumerable<PgpPublicKey>) this.keys)
      key.Encode(outStr);
  }

  public static PgpPublicKeyRing InsertPublicKey(PgpPublicKeyRing pubRing, PgpPublicKey pubKey)
  {
    List<PgpPublicKey> pubKeys = new List<PgpPublicKey>((IEnumerable<PgpPublicKey>) pubRing.keys);
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index != pubKeys.Count; ++index)
    {
      PgpPublicKey pgpPublicKey = pubKeys[index];
      if (pgpPublicKey.KeyId == pubKey.KeyId)
      {
        flag1 = true;
        pubKeys[index] = pubKey;
      }
      if (pgpPublicKey.IsMasterKey)
        flag2 = true;
    }
    if (!flag1)
    {
      if (pubKey.IsMasterKey)
      {
        if (flag2)
          throw new ArgumentException("cannot add a master key to a ring that already has one");
        pubKeys.Insert(0, pubKey);
      }
      else
        pubKeys.Add(pubKey);
    }
    return new PgpPublicKeyRing((IList<PgpPublicKey>) pubKeys);
  }

  public static PgpPublicKeyRing RemovePublicKey(PgpPublicKeyRing pubRing, PgpPublicKey pubKey)
  {
    int count = pubRing.keys.Count;
    long keyId = pubKey.KeyId;
    List<PgpPublicKey> pubKeys = new List<PgpPublicKey>(count);
    bool flag = false;
    foreach (PgpPublicKey key in (IEnumerable<PgpPublicKey>) pubRing.keys)
    {
      if (key.KeyId == keyId)
        flag = true;
      else
        pubKeys.Add(key);
    }
    return !flag ? (PgpPublicKeyRing) null : new PgpPublicKeyRing((IList<PgpPublicKey>) pubKeys);
  }

  internal static PublicKeyPacket ReadPublicKeyPacket(BcpgInputStream bcpgInput)
  {
    Packet packet = bcpgInput.ReadPacket();
    return packet is PublicKeyPacket publicKeyPacket ? publicKeyPacket : throw new IOException("unexpected packet in stream: " + packet?.ToString());
  }

  internal static PgpPublicKey ReadSubkey(BcpgInputStream bcpgInput)
  {
    PublicKeyPacket publicPk = PgpPublicKeyRing.ReadPublicKeyPacket(bcpgInput);
    TrustPacket trustPacket = PgpKeyRing.ReadOptionalTrustPacket(bcpgInput);
    IList<PgpSignature> pgpSignatureList = PgpKeyRing.ReadSignaturesAndTrust(bcpgInput);
    TrustPacket trustPk = trustPacket;
    IList<PgpSignature> sigs = pgpSignatureList;
    return new PgpPublicKey(publicPk, trustPk, sigs);
  }

  public static PgpPublicKeyRing Join(PgpPublicKeyRing first, PgpPublicKeyRing second)
  {
    return PgpPublicKeyRing.Join(first, second, false, false);
  }

  public static PgpPublicKeyRing Join(
    PgpPublicKeyRing first,
    PgpPublicKeyRing second,
    bool joinTrustPackets,
    bool allowSubkeySigsOnNonSubkey)
  {
    if (!Arrays.AreEqual(first.GetPublicKey().GetFingerprint(), second.GetPublicKey().GetFingerprint()))
      throw new ArgumentException("Cannot merge certificates with differing primary keys.");
    HashSet<long> longSet = new HashSet<long>();
    foreach (PgpPublicKey publicKey in second.GetPublicKeys())
      longSet.Add(publicKey.KeyId);
    List<PgpPublicKey> pubKeys = new List<PgpPublicKey>();
    foreach (PgpPublicKey publicKey1 in first.GetPublicKeys())
    {
      PgpPublicKey publicKey2 = second.GetPublicKey(publicKey1.KeyId);
      if (publicKey2 != null)
      {
        pubKeys.Add(PgpPublicKey.Join(publicKey1, publicKey2, joinTrustPackets, allowSubkeySigsOnNonSubkey));
        longSet.Remove(publicKey1.KeyId);
      }
      else
        pubKeys.Add(publicKey1);
    }
    foreach (long keyId in longSet)
      pubKeys.Add(second.GetPublicKey(keyId));
    return new PgpPublicKeyRing((IList<PgpPublicKey>) pubKeys);
  }
}
