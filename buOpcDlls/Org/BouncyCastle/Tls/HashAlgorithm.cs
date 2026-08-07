// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.HashAlgorithm
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public abstract class HashAlgorithm
{
  public const short none = 0;
  public const short md5 = 1;
  public const short sha1 = 2;
  public const short sha224 = 3;
  public const short sha256 = 4;
  public const short sha384 = 5;
  public const short sha512 = 6;
  public const short Intrinsic = 8;

  public static string GetName(short hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case 0:
        return "none";
      case 1:
        return "md5";
      case 2:
        return "sha1";
      case 3:
        return "sha224";
      case 4:
        return "sha256";
      case 5:
        return "sha384";
      case 6:
        return "sha512";
      case 8:
        return "Intrinsic";
      default:
        return "UNKNOWN";
    }
  }

  public static int GetOutputSize(short hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case 1:
        return 16 /*0x10*/;
      case 2:
        return 20;
      case 3:
        return 28;
      case 4:
        return 32 /*0x20*/;
      case 5:
        return 48 /*0x30*/;
      case 6:
        return 64 /*0x40*/;
      default:
        return -1;
    }
  }

  public static string GetText(short hashAlgorithm)
  {
    return $"{HashAlgorithm.GetName(hashAlgorithm)}({hashAlgorithm.ToString()})";
  }

  public static bool IsPrivate(short hashAlgorithm)
  {
    return (short) 224 /*0xE0*/ <= hashAlgorithm && hashAlgorithm <= (short) byte.MaxValue;
  }

  public static bool IsRecognized(short hashAlgorithm)
  {
    switch (hashAlgorithm)
    {
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 8:
        return true;
      default:
        return false;
    }
  }
}
