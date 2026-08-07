// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpObjectFactory
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpObjectFactory
{
  private readonly BcpgInputStream bcpgIn;

  public PgpObjectFactory(Stream inputStream) => this.bcpgIn = BcpgInputStream.Wrap(inputStream);

  public PgpObjectFactory(byte[] bytes)
    : this((Stream) new MemoryStream(bytes, false))
  {
  }

  public PgpObject NextPgpObject()
  {
    switch (this.bcpgIn.NextPacketTag())
    {
      case ~PacketTag.Reserved:
        return (PgpObject) null;
      case PacketTag.PublicKeyEncryptedSession:
      case PacketTag.SymmetricKeyEncryptedSessionKey:
        return (PgpObject) new PgpEncryptedDataList(this.bcpgIn);
      case PacketTag.Signature:
        List<PgpSignature> pgpSignatureList = new List<PgpSignature>();
        while (this.bcpgIn.NextPacketTag() == PacketTag.Signature)
        {
          try
          {
            pgpSignatureList.Add(new PgpSignature(this.bcpgIn));
          }
          catch (UnsupportedPacketVersionException ex)
          {
          }
          catch (PgpException ex)
          {
            throw new IOException("can't create signature object: " + ex?.ToString());
          }
        }
        return (PgpObject) new PgpSignatureList(pgpSignatureList.ToArray());
      case PacketTag.OnePassSignature:
        List<PgpOnePassSignature> onePassSignatureList = new List<PgpOnePassSignature>();
        while (this.bcpgIn.NextPacketTag() == PacketTag.OnePassSignature)
        {
          try
          {
            onePassSignatureList.Add(new PgpOnePassSignature(this.bcpgIn));
          }
          catch (PgpException ex)
          {
            throw new IOException("can't create one pass signature object: " + ex?.ToString());
          }
        }
        return (PgpObject) new PgpOnePassSignatureList(onePassSignatureList.ToArray());
      case PacketTag.SecretKey:
        try
        {
          return (PgpObject) new PgpSecretKeyRing((Stream) this.bcpgIn);
        }
        catch (PgpException ex)
        {
          throw new IOException("can't create secret key object: " + ex?.ToString());
        }
      case PacketTag.PublicKey:
        return (PgpObject) new PgpPublicKeyRing((Stream) this.bcpgIn);
      case PacketTag.CompressedData:
        return (PgpObject) new PgpCompressedData(this.bcpgIn);
      case PacketTag.Marker:
        return (PgpObject) new PgpMarker(this.bcpgIn);
      case PacketTag.LiteralData:
        return (PgpObject) new PgpLiteralData(this.bcpgIn);
      case PacketTag.PublicSubkey:
        return (PgpObject) PgpPublicKeyRing.ReadSubkey(this.bcpgIn);
      case PacketTag.Experimental1:
      case PacketTag.Experimental2:
      case PacketTag.Experimental3:
      case PacketTag.Experimental4:
        return (PgpObject) new PgpExperimental(this.bcpgIn);
      default:
        throw new IOException("unknown object in stream " + this.bcpgIn.NextPacketTag().ToString());
    }
  }

  public IList<PgpObject> AllPgpObjects()
  {
    List<PgpObject> pgpObjectList = new List<PgpObject>();
    PgpObject pgpObject;
    while ((pgpObject = this.NextPgpObject()) != null)
      pgpObjectList.Add(pgpObject);
    return (IList<PgpObject>) pgpObjectList;
  }

  public IList<T> FilterPgpObjects<T>() where T : PgpObject
  {
    List<T> objList = new List<T>();
    PgpObject pgpObject;
    while ((pgpObject = this.NextPgpObject()) != null)
    {
      if (pgpObject is T obj)
        objList.Add(obj);
    }
    return (IList<T>) objList;
  }
}
