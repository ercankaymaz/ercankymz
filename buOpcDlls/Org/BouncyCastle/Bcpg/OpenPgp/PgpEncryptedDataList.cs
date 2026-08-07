// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpEncryptedDataList
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public class PgpEncryptedDataList : PgpObject
{
  private readonly List<PgpEncryptedData> m_list = new List<PgpEncryptedData>();
  private readonly InputStreamPacket m_data;

  public PgpEncryptedDataList(BcpgInputStream bcpgInput)
  {
    List<Packet> packetList = new List<Packet>();
    while (bcpgInput.NextPacketTag() == PacketTag.PublicKeyEncryptedSession || bcpgInput.NextPacketTag() == PacketTag.SymmetricKeyEncryptedSessionKey)
      packetList.Add(bcpgInput.ReadPacket());
    Packet packet1 = bcpgInput.ReadPacket();
    this.m_data = packet1 is InputStreamPacket inputStreamPacket ? inputStreamPacket : throw new IOException("unexpected packet in stream: " + packet1?.ToString());
    foreach (Packet packet2 in packetList)
    {
      switch (packet2)
      {
        case SymmetricKeyEncSessionPacket keyData1:
          this.m_list.Add((PgpEncryptedData) new PgpPbeEncryptedData(keyData1, this.m_data));
          continue;
        case PublicKeyEncSessionPacket keyData2:
          this.m_list.Add((PgpEncryptedData) new PgpPublicKeyEncryptedData(keyData2, this.m_data));
          continue;
        default:
          throw new InvalidOperationException();
      }
    }
  }

  public PgpEncryptedData this[int index] => this.m_list[index];

  public int Count => this.m_list.Count;

  public bool IsEmpty => this.m_list.Count == 0;

  public IEnumerable<PgpEncryptedData> GetEncryptedDataObjects()
  {
    return CollectionUtilities.Proxy<PgpEncryptedData>((IEnumerable<PgpEncryptedData>) this.m_list);
  }
}
