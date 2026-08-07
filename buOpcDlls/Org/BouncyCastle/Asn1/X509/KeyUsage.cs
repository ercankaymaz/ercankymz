// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.KeyUsage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class KeyUsage : DerBitString
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

  public static KeyUsage GetInstance(object obj)
  {
    switch (obj)
    {
      case KeyUsage instance:
        return instance;
      case X509Extension ext:
        return KeyUsage.GetInstance((object) X509Extension.ConvertValueToObject(ext));
      case null:
        return (KeyUsage) null;
      default:
        return new KeyUsage(DerBitString.GetInstance(obj));
    }
  }

  public static KeyUsage FromExtensions(X509Extensions extensions)
  {
    return KeyUsage.GetInstance((object) X509Extensions.GetExtensionParsedValue(extensions, X509Extensions.KeyUsage));
  }

  public KeyUsage(int usage)
    : base(usage)
  {
  }

  private KeyUsage(DerBitString usage)
    : base(usage.GetBytes(), usage.PadBits)
  {
  }

  public override string ToString()
  {
    byte[] bytes = this.GetBytes();
    return bytes.Length == 1 ? "KeyUsage: 0x" + ((int) bytes[0] & (int) byte.MaxValue).ToString("X") : "KeyUsage: 0x" + (((int) bytes[1] & (int) byte.MaxValue) << 8 | (int) bytes[0] & (int) byte.MaxValue).ToString("X");
  }
}
