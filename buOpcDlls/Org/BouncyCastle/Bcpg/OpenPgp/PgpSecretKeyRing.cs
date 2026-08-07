// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpSecretKeyRing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Security;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpSecretKeyRing : PgpKeyRing
{
  private readonly IList<PgpSecretKey> keys;
  private readonly IList<PgpPublicKey> extraPubKeys;

  internal PgpSecretKeyRing(IList<PgpSecretKey> keys)
    : this(keys, (IList<PgpPublicKey>) new List<PgpPublicKey>())
  {
  }

  private PgpSecretKeyRing(IList<PgpSecretKey> keys, IList<PgpPublicKey> extraPubKeys)
  {
    this.keys = keys;
    this.extraPubKeys = extraPubKeys;
  }

  public PgpSecretKeyRing(byte[] encoding)
    : this((Stream) new MemoryStream(encoding))
  {
  }

  public PgpSecretKeyRing(Stream inputStream)
  {
    this.keys = (IList<PgpSecretKey>) new List<PgpSecretKey>();
    this.extraPubKeys = (IList<PgpPublicKey>) new List<PgpPublicKey>();
    BcpgInputStream pIn = BcpgInputStream.Wrap(inputStream);
    PacketTag packetTag = pIn.SkipMarkerPackets();
    switch (packetTag)
    {
      case PacketTag.SecretKey:
      case PacketTag.SecretSubkey:
        SecretKeyPacket secret1 = (SecretKeyPacket) pIn.ReadPacket();
        while (pIn.NextPacketTag() == PacketTag.Experimental2)
          pIn.ReadPacket();
        TrustPacket trustPk1 = PgpKeyRing.ReadOptionalTrustPacket(pIn);
        IList<PgpSignature> keySigs = PgpKeyRing.ReadSignaturesAndTrust(pIn);
        IList<IUserDataPacket> ids;
        IList<TrustPacket> idTrusts;
        IList<IList<PgpSignature>> idSigs;
        PgpKeyRing.ReadUserIDs(pIn, out ids, out idTrusts, out idSigs);
        this.keys.Add(new PgpSecretKey(secret1, new PgpPublicKey(secret1.PublicKeyPacket, trustPk1, keySigs, ids, idTrusts, idSigs)));
        while (pIn.NextPacketTag() == PacketTag.SecretSubkey || pIn.NextPacketTag() == PacketTag.PublicSubkey)
        {
          if (pIn.NextPacketTag() == PacketTag.SecretSubkey)
          {
            SecretSubkeyPacket secret2 = (SecretSubkeyPacket) pIn.ReadPacket();
            while (pIn.NextPacketTag() == PacketTag.Experimental2)
              pIn.ReadPacket();
            TrustPacket trustPk2 = PgpKeyRing.ReadOptionalTrustPacket(pIn);
            IList<PgpSignature> sigs = PgpKeyRing.ReadSignaturesAndTrust(pIn);
            this.keys.Add(new PgpSecretKey((SecretKeyPacket) secret2, new PgpPublicKey(secret2.PublicKeyPacket, trustPk2, sigs)));
          }
          else
            this.extraPubKeys.Add(new PgpPublicKey((PublicKeyPacket) pIn.ReadPacket(), PgpKeyRing.ReadOptionalTrustPacket(pIn), PgpKeyRing.ReadSignaturesAndTrust(pIn)));
        }
        break;
      default:
        throw new IOException("secret key ring doesn't start with secret key tag: tag 0x" + ((int) packetTag).ToString("X"));
    }
  }

  public PgpPublicKey GetPublicKey() => this.keys[0].PublicKey;

  public IEnumerable<PgpPublicKey> GetKeysWithSignaturesBy(long keyID)
  {
    List<PgpPublicKey> e = new List<PgpPublicKey>();
    foreach (PgpPublicKey publicKey in this.GetPublicKeys())
    {
      if (publicKey.GetSignaturesForKeyID(keyID).GetEnumerator().MoveNext())
        e.Add(publicKey);
    }
    return CollectionUtilities.Proxy<PgpPublicKey>((IEnumerable<PgpPublicKey>) e);
  }

  public IEnumerable<PgpPublicKey> GetPublicKeys()
  {
    List<PgpPublicKey> e = new List<PgpPublicKey>();
    foreach (PgpSecretKey key in (IEnumerable<PgpSecretKey>) this.keys)
      e.Add(key.PublicKey);
    e.AddRange((IEnumerable<PgpPublicKey>) this.extraPubKeys);
    return CollectionUtilities.Proxy<PgpPublicKey>((IEnumerable<PgpPublicKey>) e);
  }

  public PgpSecretKey GetSecretKey() => this.keys[0];

  public IEnumerable<PgpSecretKey> GetSecretKeys()
  {
    return CollectionUtilities.Proxy<PgpSecretKey>((IEnumerable<PgpSecretKey>) this.keys);
  }

  public PgpSecretKey GetSecretKey(long keyId)
  {
    foreach (PgpSecretKey key in (IEnumerable<PgpSecretKey>) this.keys)
    {
      if (keyId == key.KeyId)
        return key;
    }
    return (PgpSecretKey) null;
  }

  public IEnumerable<PgpPublicKey> GetExtraPublicKeys()
  {
    return CollectionUtilities.Proxy<PgpPublicKey>((IEnumerable<PgpPublicKey>) this.extraPubKeys);
  }

  public byte[] GetEncoded()
  {
    MemoryStream outStr = new MemoryStream();
    this.Encode((Stream) outStr);
    return outStr.ToArray();
  }

  public void Encode(Stream outStr)
  {
    if (outStr == null)
      throw new ArgumentNullException(nameof (outStr));
    foreach (PgpSecretKey key in (IEnumerable<PgpSecretKey>) this.keys)
      key.Encode(outStr);
    foreach (PgpPublicKey extraPubKey in (IEnumerable<PgpPublicKey>) this.extraPubKeys)
      extraPubKey.Encode(outStr);
  }

  public static PgpSecretKeyRing ReplacePublicKeys(
    PgpSecretKeyRing secretRing,
    PgpPublicKeyRing publicRing)
  {
    List<PgpSecretKey> keys = new List<PgpSecretKey>(secretRing.keys.Count);
    foreach (PgpSecretKey key in (IEnumerable<PgpSecretKey>) secretRing.keys)
    {
      PgpPublicKey publicKey = publicRing.GetPublicKey(key.KeyId);
      keys.Add(PgpSecretKey.ReplacePublicKey(key, publicKey));
    }
    return new PgpSecretKeyRing((IList<PgpSecretKey>) keys);
  }

  public static PgpSecretKeyRing CopyWithNewPassword(
    PgpSecretKeyRing ring,
    char[] oldPassPhrase,
    char[] newPassPhrase,
    SymmetricKeyAlgorithmTag newEncAlgorithm,
    SecureRandom rand)
  {
    List<PgpSecretKey> keys = new List<PgpSecretKey>(ring.keys.Count);
    foreach (PgpSecretKey secretKey in ring.GetSecretKeys())
    {
      if (secretKey.IsPrivateKeyEmpty)
        keys.Add(secretKey);
      else
        keys.Add(PgpSecretKey.CopyWithNewPassword(secretKey, oldPassPhrase, newPassPhrase, newEncAlgorithm, rand));
    }
    return new PgpSecretKeyRing((IList<PgpSecretKey>) keys, ring.extraPubKeys);
  }

  public static PgpSecretKeyRing InsertSecretKey(PgpSecretKeyRing secRing, PgpSecretKey secKey)
  {
    List<PgpSecretKey> keys = new List<PgpSecretKey>((IEnumerable<PgpSecretKey>) secRing.keys);
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index != keys.Count; ++index)
    {
      PgpSecretKey pgpSecretKey = keys[index];
      if (pgpSecretKey.KeyId == secKey.KeyId)
      {
        flag1 = true;
        keys[index] = secKey;
      }
      if (pgpSecretKey.IsMasterKey)
        flag2 = true;
    }
    if (!flag1)
    {
      if (secKey.IsMasterKey)
      {
        if (flag2)
          throw new ArgumentException("cannot add a master key to a ring that already has one");
        keys.Insert(0, secKey);
      }
      else
        keys.Add(secKey);
    }
    return new PgpSecretKeyRing((IList<PgpSecretKey>) keys, secRing.extraPubKeys);
  }

  public static PgpSecretKeyRing RemoveSecretKey(PgpSecretKeyRing secRing, PgpSecretKey secKey)
  {
    List<PgpSecretKey> keys = new List<PgpSecretKey>((IEnumerable<PgpSecretKey>) secRing.keys);
    bool flag = false;
    for (int index = 0; index < keys.Count; ++index)
    {
      if (keys[index].KeyId == secKey.KeyId)
      {
        flag = true;
        keys.RemoveAt(index);
      }
    }
    return !flag ? (PgpSecretKeyRing) null : new PgpSecretKeyRing((IList<PgpSecretKey>) keys, secRing.extraPubKeys);
  }
}
