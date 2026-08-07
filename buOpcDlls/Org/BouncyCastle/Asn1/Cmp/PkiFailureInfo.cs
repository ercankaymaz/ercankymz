// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Cmp.PkiFailureInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Asn1.Cmp;

public class PkiFailureInfo : DerBitString
{
  public const int BadAlg = 128 /*0x80*/;
  public const int BadMessageCheck = 64 /*0x40*/;
  public const int BadRequest = 32 /*0x20*/;
  public const int BadTime = 16 /*0x10*/;
  public const int BadCertId = 8;
  public const int BadDataFormat = 4;
  public const int WrongAuthority = 2;
  public const int IncorrectData = 1;
  public const int MissingTimeStamp = 32768 /*0x8000*/;
  public const int BadPop = 16384 /*0x4000*/;
  public const int CertRevoked = 8192 /*0x2000*/;
  public const int CertConfirmed = 4096 /*0x1000*/;
  public const int WrongIntegrity = 2048 /*0x0800*/;
  public const int BadRecipientNonce = 1024 /*0x0400*/;
  public const int TimeNotAvailable = 512 /*0x0200*/;
  public const int UnacceptedPolicy = 256 /*0x0100*/;
  public const int UnacceptedExtension = 8388608 /*0x800000*/;
  public const int AddInfoNotAvailable = 4194304 /*0x400000*/;
  public const int BadSenderNonce = 2097152 /*0x200000*/;
  public const int BadCertTemplate = 1048576 /*0x100000*/;
  public const int SignerNotTrusted = 524288 /*0x080000*/;
  public const int TransactionIdInUse = 262144 /*0x040000*/;
  public const int UnsupportedVersion = 131072 /*0x020000*/;
  public const int NotAuthorized = 65536 /*0x010000*/;
  public const int SystemUnavail = -2147483648 /*0x80000000*/;
  public const int SystemFailure = 1073741824 /*0x40000000*/;
  public const int DuplicateCertReq = 536870912 /*0x20000000*/;

  public PkiFailureInfo(int info)
    : base(info)
  {
  }

  public PkiFailureInfo(DerBitString info)
    : base(info.GetBytes(), info.PadBits)
  {
  }

  public override string ToString() => "PkiFailureInfo: 0x" + this.IntValue.ToString("X");
}
