// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKeyRing
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public abstract class PgpKeyRing : PgpObject
{
  internal PgpKeyRing()
  {
  }

  internal static TrustPacket ReadOptionalTrustPacket(BcpgInputStream pIn)
  {
    return pIn.SkipMarkerPackets() != PacketTag.Trust ? (TrustPacket) null : (TrustPacket) pIn.ReadPacket();
  }

  internal static IList<PgpSignature> ReadSignaturesAndTrust(BcpgInputStream pIn)
  {
    try
    {
      List<PgpSignature> pgpSignatureList = new List<PgpSignature>();
      while (pIn.SkipMarkerPackets() == PacketTag.Signature)
      {
        SignaturePacket sigPacket = (SignaturePacket) pIn.ReadPacket();
        TrustPacket trustPacket = PgpKeyRing.ReadOptionalTrustPacket(pIn);
        pgpSignatureList.Add(new PgpSignature(sigPacket, trustPacket));
      }
      return (IList<PgpSignature>) pgpSignatureList;
    }
    catch (PgpException ex)
    {
      throw new IOException("can't create signature object: " + ex.Message, (Exception) ex);
    }
  }

  internal static void ReadUserIDs(
    BcpgInputStream pIn,
    out IList<IUserDataPacket> ids,
    out IList<TrustPacket> idTrusts,
    out IList<IList<PgpSignature>> idSigs)
  {
    ids = (IList<IUserDataPacket>) new List<IUserDataPacket>();
    idTrusts = (IList<TrustPacket>) new List<TrustPacket>();
    idSigs = (IList<IList<PgpSignature>>) new List<IList<PgpSignature>>();
    while (PgpKeyRing.IsUserTag(pIn.SkipMarkerPackets()))
    {
      Packet packet = pIn.ReadPacket();
      if (packet is UserIdPacket userIdPacket)
      {
        ids.Add((IUserDataPacket) userIdPacket);
      }
      else
      {
        UserAttributePacket userAttributePacket = (UserAttributePacket) packet;
        ids.Add((IUserDataPacket) new PgpUserAttributeSubpacketVector(userAttributePacket.GetSubpackets()));
      }
      idTrusts.Add(PgpKeyRing.ReadOptionalTrustPacket(pIn));
      idSigs.Add(PgpKeyRing.ReadSignaturesAndTrust(pIn));
    }
  }

  private static bool IsUserTag(PacketTag tag)
  {
    return tag == PacketTag.UserId || tag == PacketTag.UserAttribute;
  }
}
