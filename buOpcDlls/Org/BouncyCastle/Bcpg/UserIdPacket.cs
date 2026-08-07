// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.UserIdPacket
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System.Text;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class UserIdPacket : ContainedPacket, IUserDataPacket
{
  private readonly byte[] idData;

  public UserIdPacket(BcpgInputStream bcpgIn) => this.idData = bcpgIn.ReadAll();

  public UserIdPacket(string id) => this.idData = Encoding.UTF8.GetBytes(id);

  public UserIdPacket(byte[] rawId) => this.idData = Arrays.Clone(rawId);

  public string GetId() => Encoding.UTF8.GetString(this.idData, 0, this.idData.Length);

  public byte[] GetRawId() => Arrays.Clone(this.idData);

  public override bool Equals(object obj)
  {
    return obj is UserIdPacket userIdPacket && Arrays.AreEqual(this.idData, userIdPacket.idData);
  }

  public override int GetHashCode() => Arrays.GetHashCode(this.idData);

  public override void Encode(BcpgOutputStream bcpgOut)
  {
    bcpgOut.WritePacket(PacketTag.UserId, this.idData);
  }
}
