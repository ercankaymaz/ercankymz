// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.X509.CrlReason
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.X509;

public class CrlReason : DerEnumerated
{
  public const int Unspecified = 0;
  public const int KeyCompromise = 1;
  public const int CACompromise = 2;
  public const int AffiliationChanged = 3;
  public const int Superseded = 4;
  public const int CessationOfOperation = 5;
  public const int CertificateHold = 6;
  public const int RemoveFromCrl = 8;
  public const int PrivilegeWithdrawn = 9;
  public const int AACompromise = 10;
  private static readonly string[] ReasonString = new string[11]
  {
    nameof (Unspecified),
    nameof (KeyCompromise),
    nameof (CACompromise),
    nameof (AffiliationChanged),
    nameof (Superseded),
    nameof (CessationOfOperation),
    nameof (CertificateHold),
    "Unknown",
    nameof (RemoveFromCrl),
    nameof (PrivilegeWithdrawn),
    nameof (AACompromise)
  };

  public CrlReason(int reason)
    : base(reason)
  {
  }

  public CrlReason(DerEnumerated reason)
    : base(reason.IntValueExact)
  {
  }

  public override string ToString()
  {
    int intValueExact = this.IntValueExact;
    string str;
    switch (intValueExact)
    {
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
        str = CrlReason.ReasonString[intValueExact];
        break;
      default:
        str = "Invalid";
        break;
    }
    return "CrlReason: " + str;
  }
}
