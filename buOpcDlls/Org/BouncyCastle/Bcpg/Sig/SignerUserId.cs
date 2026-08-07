// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.SignerUserId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class SignerUserId : SignatureSubpacket
{
  public SignerUserId(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.SignerUserId, critical, isLongLength, data)
  {
  }

  public SignerUserId(bool critical, string userId)
    : base(SignatureSubpacketTag.SignerUserId, critical, false, Strings.ToUtf8ByteArray(userId))
  {
  }

  public string GetId() => Strings.FromUtf8ByteArray(this.data);

  public byte[] GetRawId() => Arrays.Clone(this.data);
}
