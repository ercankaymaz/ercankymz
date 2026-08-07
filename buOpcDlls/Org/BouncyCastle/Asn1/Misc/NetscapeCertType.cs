// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Misc.NetscapeCertType
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Misc;

public class NetscapeCertType : DerBitString
{
  public const int SslClient = 128 /*0x80*/;
  public const int SslServer = 64 /*0x40*/;
  public const int Smime = 32 /*0x20*/;
  public const int ObjectSigning = 16 /*0x10*/;
  public const int Reserved = 8;
  public const int SslCA = 4;
  public const int SmimeCA = 2;
  public const int ObjectSigningCA = 1;

  public NetscapeCertType(int usage)
    : base(usage)
  {
  }

  public NetscapeCertType(DerBitString usage)
    : base(usage.GetBytes(), usage.PadBits)
  {
  }

  public override string ToString()
  {
    return "NetscapeCertType: 0x" + ((int) this.GetBytes()[0] & (int) byte.MaxValue).ToString("X");
  }
}
