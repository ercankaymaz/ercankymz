// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.Sig.IssuerKeyId
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Crypto.Utilities;

#nullable disable
namespace Org.BouncyCastle.Bcpg.Sig;

public class IssuerKeyId : SignatureSubpacket
{
  protected static byte[] KeyIdToBytes(long keyId) => Pack.UInt64_To_BE((ulong) keyId);

  public IssuerKeyId(bool critical, bool isLongLength, byte[] data)
    : base(SignatureSubpacketTag.IssuerKeyId, critical, isLongLength, data)
  {
  }

  public IssuerKeyId(bool critical, long keyId)
    : base(SignatureSubpacketTag.IssuerKeyId, critical, false, IssuerKeyId.KeyIdToBytes(keyId))
  {
  }

  public long KeyId => (long) Pack.BE_To_UInt64(this.data);
}
