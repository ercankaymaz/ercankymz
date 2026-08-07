// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.SignatureSubpacketsParser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Bcpg.Sig;
using Org.BouncyCastle.Utilities;
using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class SignatureSubpacketsParser
{
  private readonly Stream input;

  public SignatureSubpacketsParser(Stream input) => this.input = input;

  public SignatureSubpacket ReadPacket()
  {
    int num1 = this.input.ReadByte();
    if (num1 < 0)
      return (SignatureSubpacket) null;
    bool isLongLength = false;
    int num2;
    if (num1 < 192 /*0xC0*/)
      num2 = num1;
    else if (num1 <= 223)
    {
      num2 = (num1 - 192 /*0xC0*/ << 8) + this.input.ReadByte() + 192 /*0xC0*/;
    }
    else
    {
      if (num1 != (int) byte.MaxValue)
        throw new IOException("unexpected length header");
      isLongLength = true;
      num2 = this.input.ReadByte() << 24 | this.input.ReadByte() << 16 /*0x10*/ | this.input.ReadByte() << 8 | this.input.ReadByte();
    }
    int num3 = this.input.ReadByte();
    if (num3 < 0)
      throw new EndOfStreamException("unexpected EOF reading signature sub packet");
    byte[] numArray = num2 > 0 ? new byte[num2 - 1] : throw new EndOfStreamException("out of range data found in signature sub packet");
    int bytesRead = Streams.ReadFully(this.input, numArray);
    bool flag = (num3 & 128 /*0x80*/) != 0;
    SignatureSubpacketTag type = (SignatureSubpacketTag) (num3 & (int) sbyte.MaxValue);
    if (bytesRead != numArray.Length)
    {
      switch (type)
      {
        case SignatureSubpacketTag.CreationTime:
          numArray = this.CheckData(numArray, 4, bytesRead, "Signature Creation Time");
          break;
        case SignatureSubpacketTag.ExpireTime:
          numArray = this.CheckData(numArray, 4, bytesRead, "Signature Expiration Time");
          break;
        case SignatureSubpacketTag.KeyExpireTime:
          numArray = this.CheckData(numArray, 4, bytesRead, "Signature Key Expiration Time");
          break;
        case SignatureSubpacketTag.IssuerKeyId:
          numArray = this.CheckData(numArray, 8, bytesRead, "Issuer");
          break;
        default:
          throw new EndOfStreamException("truncated subpacket data.");
      }
    }
    switch (type)
    {
      case SignatureSubpacketTag.CreationTime:
        return (SignatureSubpacket) new SignatureCreationTime(flag, isLongLength, numArray);
      case SignatureSubpacketTag.ExpireTime:
        return (SignatureSubpacket) new SignatureExpirationTime(flag, isLongLength, numArray);
      case SignatureSubpacketTag.Exportable:
        return (SignatureSubpacket) new Exportable(flag, isLongLength, numArray);
      case SignatureSubpacketTag.TrustSig:
        return (SignatureSubpacket) new TrustSignature(flag, isLongLength, numArray);
      case SignatureSubpacketTag.RegExp:
        return (SignatureSubpacket) new RegularExpression(flag, isLongLength, numArray);
      case SignatureSubpacketTag.Revocable:
        return (SignatureSubpacket) new Revocable(flag, isLongLength, numArray);
      case SignatureSubpacketTag.KeyExpireTime:
        return (SignatureSubpacket) new KeyExpirationTime(flag, isLongLength, numArray);
      case SignatureSubpacketTag.PreferredSymmetricAlgorithms:
      case SignatureSubpacketTag.PreferredHashAlgorithms:
      case SignatureSubpacketTag.PreferredCompressionAlgorithms:
      case SignatureSubpacketTag.PreferredAeadAlgorithms:
        return (SignatureSubpacket) new PreferredAlgorithms(type, flag, isLongLength, numArray);
      case SignatureSubpacketTag.RevocationKey:
        return (SignatureSubpacket) new RevocationKey(flag, isLongLength, numArray);
      case SignatureSubpacketTag.IssuerKeyId:
        return (SignatureSubpacket) new IssuerKeyId(flag, isLongLength, numArray);
      case SignatureSubpacketTag.NotationData:
        return (SignatureSubpacket) new NotationData(flag, isLongLength, numArray);
      case SignatureSubpacketTag.PrimaryUserId:
        return (SignatureSubpacket) new PrimaryUserId(flag, isLongLength, numArray);
      case SignatureSubpacketTag.PolicyUrl:
        return (SignatureSubpacket) new PolicyUrl(flag, isLongLength, numArray);
      case SignatureSubpacketTag.KeyFlags:
        return (SignatureSubpacket) new KeyFlags(flag, isLongLength, numArray);
      case SignatureSubpacketTag.SignerUserId:
        return (SignatureSubpacket) new SignerUserId(flag, isLongLength, numArray);
      case SignatureSubpacketTag.RevocationReason:
        return (SignatureSubpacket) new RevocationReason(flag, isLongLength, numArray);
      case SignatureSubpacketTag.Features:
        return (SignatureSubpacket) new Features(flag, isLongLength, numArray);
      case SignatureSubpacketTag.SignatureTarget:
        return (SignatureSubpacket) new SignatureTarget(flag, isLongLength, numArray);
      case SignatureSubpacketTag.EmbeddedSignature:
        return (SignatureSubpacket) new EmbeddedSignature(flag, isLongLength, numArray);
      case SignatureSubpacketTag.IssuerFingerprint:
        return (SignatureSubpacket) new IssuerFingerprint(flag, isLongLength, numArray);
      case SignatureSubpacketTag.IntendedRecipientFingerprint:
        return (SignatureSubpacket) new IntendedRecipientFingerprint(flag, isLongLength, numArray);
      default:
        return new SignatureSubpacket(type, flag, isLongLength, numArray);
    }
  }

  private byte[] CheckData(byte[] data, int expected, int bytesRead, string name)
  {
    return bytesRead == expected ? Arrays.CopyOfRange(data, 0, expected) : throw new EndOfStreamException($"truncated {name} subpacket data.");
  }
}
