// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.BcpgInputStream
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities.IO;
using System.IO;

#nullable disable
namespace Org.BouncyCastle.Bcpg;

public class BcpgInputStream : BaseInputStream
{
  private Stream m_in;
  private bool next;
  private int nextB;

  internal static BcpgInputStream Wrap(Stream inStr)
  {
    return inStr is BcpgInputStream bcpgInputStream ? bcpgInputStream : new BcpgInputStream(inStr);
  }

  private BcpgInputStream(Stream inputStream) => this.m_in = inputStream;

  public override int ReadByte()
  {
    if (!this.next)
      return this.m_in.ReadByte();
    this.next = false;
    return this.nextB;
  }

  public override int Read(byte[] buffer, int offset, int count)
  {
    if (!this.next)
      return this.m_in.Read(buffer, offset, count);
    Streams.ValidateBufferArguments(buffer, offset, count);
    if (this.nextB < 0)
      return 0;
    buffer[offset] = (byte) this.nextB;
    this.next = false;
    return 1;
  }

  public byte[] ReadAll() => Streams.ReadAll((Stream) this);

  public void ReadFully(byte[] buffer, int offset, int count)
  {
    if (Streams.ReadFully((Stream) this, buffer, offset, count) < count)
      throw new EndOfStreamException();
  }

  public void ReadFully(byte[] buffer) => this.ReadFully(buffer, 0, buffer.Length);

  public PacketTag NextPacketTag()
  {
    if (!this.next)
    {
      try
      {
        this.nextB = this.m_in.ReadByte();
      }
      catch (EndOfStreamException ex)
      {
        this.nextB = -1;
      }
      this.next = true;
    }
    if (this.nextB < 0)
      return (PacketTag) this.nextB;
    int num = this.nextB & 63 /*0x3F*/;
    if ((this.nextB & 64 /*0x40*/) == 0)
      num >>= 2;
    return (PacketTag) num;
  }

  public Packet ReadPacket()
  {
    int num1 = this.ReadByte();
    if (num1 < 0)
      return (Packet) null;
    if ((num1 & 128 /*0x80*/) == 0)
      throw new IOException("invalid header encountered");
    int num2 = (num1 & 64 /*0x40*/) != 0 ? 1 : 0;
    int dataLength = 0;
    bool partial = false;
    PacketTag tag;
    if (num2 != 0)
    {
      tag = (PacketTag) (num1 & 63 /*0x3F*/);
      int num3 = this.ReadByte();
      if (num3 < 192 /*0xC0*/)
        dataLength = num3;
      else if (num3 <= 223)
      {
        int num4 = this.m_in.ReadByte();
        dataLength = (num3 - 192 /*0xC0*/ << 8) + num4 + 192 /*0xC0*/;
      }
      else if (num3 == (int) byte.MaxValue)
      {
        dataLength = this.m_in.ReadByte() << 24 | this.m_in.ReadByte() << 16 /*0x10*/ | this.m_in.ReadByte() << 8 | this.m_in.ReadByte();
      }
      else
      {
        partial = true;
        dataLength = 1 << num3;
      }
    }
    else
    {
      int num5 = num1 & 3;
      tag = (PacketTag) ((num1 & 63 /*0x3F*/) >> 2);
      switch (num5)
      {
        case 0:
          dataLength = this.ReadByte();
          break;
        case 1:
          dataLength = this.ReadByte() << 8 | this.ReadByte();
          break;
        case 2:
          dataLength = this.ReadByte() << 24 | this.ReadByte() << 16 /*0x10*/ | this.ReadByte() << 8 | this.ReadByte();
          break;
        case 3:
          partial = true;
          break;
        default:
          throw new IOException("unknown length type encountered");
      }
    }
    BcpgInputStream bcpgIn = !(dataLength == 0 & partial) ? new BcpgInputStream((Stream) new BufferedStream((Stream) new BcpgInputStream.PartialInputStream(this, partial, dataLength))) : this;
    switch (tag)
    {
      case PacketTag.Reserved:
        return (Packet) new InputStreamPacket(bcpgIn);
      case PacketTag.PublicKeyEncryptedSession:
        return (Packet) new PublicKeyEncSessionPacket(bcpgIn);
      case PacketTag.Signature:
        return (Packet) new SignaturePacket(bcpgIn);
      case PacketTag.SymmetricKeyEncryptedSessionKey:
        return (Packet) new SymmetricKeyEncSessionPacket(bcpgIn);
      case PacketTag.OnePassSignature:
        return (Packet) new OnePassSignaturePacket(bcpgIn);
      case PacketTag.SecretKey:
        return (Packet) new SecretKeyPacket(bcpgIn);
      case PacketTag.PublicKey:
        return (Packet) new PublicKeyPacket(bcpgIn);
      case PacketTag.SecretSubkey:
        return (Packet) new SecretSubkeyPacket(bcpgIn);
      case PacketTag.CompressedData:
        return (Packet) new CompressedDataPacket(bcpgIn);
      case PacketTag.SymmetricKeyEncrypted:
        return (Packet) new SymmetricEncDataPacket(bcpgIn);
      case PacketTag.Marker:
        return (Packet) new MarkerPacket(bcpgIn);
      case PacketTag.LiteralData:
        return (Packet) new LiteralDataPacket(bcpgIn);
      case PacketTag.Trust:
        return (Packet) new TrustPacket(bcpgIn);
      case PacketTag.UserId:
        return (Packet) new UserIdPacket(bcpgIn);
      case PacketTag.PublicSubkey:
        return (Packet) new PublicSubkeyPacket(bcpgIn);
      case PacketTag.UserAttribute:
        return (Packet) new UserAttributePacket(bcpgIn);
      case PacketTag.SymmetricEncryptedIntegrityProtected:
        return (Packet) new SymmetricEncIntegrityPacket(bcpgIn);
      case PacketTag.ModificationDetectionCode:
        return (Packet) new ModDetectionCodePacket(bcpgIn);
      case PacketTag.Experimental1:
      case PacketTag.Experimental2:
      case PacketTag.Experimental3:
      case PacketTag.Experimental4:
        return (Packet) new ExperimentalPacket(tag, bcpgIn);
      default:
        throw new IOException("unknown packet type encountered: " + tag.ToString());
    }
  }

  public PacketTag SkipMarkerPackets()
  {
    PacketTag packetTag;
    while ((packetTag = this.NextPacketTag()) == PacketTag.Marker)
      this.ReadPacket();
    return packetTag;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing)
      this.m_in.Dispose();
    base.Dispose(disposing);
  }

  private class PartialInputStream : BaseInputStream
  {
    private BcpgInputStream m_in;
    private bool partial;
    private int dataLength;

    internal PartialInputStream(BcpgInputStream bcpgIn, bool partial, int dataLength)
    {
      this.m_in = bcpgIn;
      this.partial = partial;
      this.dataLength = dataLength;
    }

    public override int ReadByte()
    {
      while (this.dataLength == 0)
      {
        if (!this.partial || this.ReadPartialDataLength() < 0)
          return -1;
      }
      int num = this.m_in.ReadByte();
      if (num < 0)
        throw new EndOfStreamException("Premature end of stream in PartialInputStream");
      --this.dataLength;
      return num;
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
      Streams.ValidateBufferArguments(buffer, offset, count);
      while (this.dataLength == 0)
      {
        if (!this.partial || this.ReadPartialDataLength() < 0)
          return 0;
      }
      int count1 = this.dataLength > count || this.dataLength < 0 ? count : this.dataLength;
      int num = this.m_in.Read(buffer, offset, count1);
      if (num < 1)
        throw new EndOfStreamException("Premature end of stream in PartialInputStream");
      this.dataLength -= num;
      return num;
    }

    private int ReadPartialDataLength()
    {
      int num = this.m_in.ReadByte();
      if (num < 0)
        return -1;
      this.partial = false;
      if (num < 192 /*0xC0*/)
        this.dataLength = num;
      else if (num <= 223)
        this.dataLength = (num - 192 /*0xC0*/ << 8) + this.m_in.ReadByte() + 192 /*0xC0*/;
      else if (num == (int) byte.MaxValue)
      {
        this.dataLength = this.m_in.ReadByte() << 24 | this.m_in.ReadByte() << 16 /*0x10*/ | this.m_in.ReadByte() << 8 | this.m_in.ReadByte();
      }
      else
      {
        this.partial = true;
        this.dataLength = 1 << num;
      }
      return 0;
    }
  }
}
