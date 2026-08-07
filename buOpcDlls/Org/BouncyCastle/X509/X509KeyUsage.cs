// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.X509.X509KeyUsage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.X509;

#nullable disable
namespace Org.BouncyCastle.X509;

public class X509KeyUsage : Asn1Encodable
{
  public const int DigitalSignature = 128 /*0x80*/;
  public const int NonRepudiation = 64 /*0x40*/;
  public const int KeyEncipherment = 32 /*0x20*/;
  public const int DataEncipherment = 16 /*0x10*/;
  public const int KeyAgreement = 8;
  public const int KeyCertSign = 4;
  public const int CrlSign = 2;
  public const int EncipherOnly = 1;
  public const int DecipherOnly = 32768 /*0x8000*/;
  private readonly int usage;

  public X509KeyUsage(int usage) => this.usage = usage;

  public override Asn1Object ToAsn1Object() => (Asn1Object) new KeyUsage(this.usage);
}
