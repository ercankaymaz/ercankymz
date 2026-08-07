// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.ReasonFlags
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class ReasonFlags : DerBitString
{
  public const int Unused = 128 /*0x80*/;
  public const int KeyCompromise = 64 /*0x40*/;
  public const int CACompromise = 32 /*0x20*/;
  public const int AffiliationChanged = 16 /*0x10*/;
  public const int Superseded = 8;
  public const int CessationOfOperation = 4;
  public const int CertificateHold = 2;
  public const int PrivilegeWithdrawn = 1;
  public const int AACompromise = 32768 /*0x8000*/;

  public ReasonFlags(int reasons)
    : base(reasons)
  {
  }

  public ReasonFlags(DerBitString reasons)
    : base(reasons.GetBytes(), reasons.PadBits)
  {
  }
}
