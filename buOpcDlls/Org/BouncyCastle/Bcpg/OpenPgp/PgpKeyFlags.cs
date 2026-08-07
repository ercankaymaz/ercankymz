// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Bcpg.OpenPgp.PgpKeyFlags
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Bcpg.OpenPgp;

public abstract class PgpKeyFlags
{
  public const int CanCertify = 1;
  public const int CanSign = 2;
  public const int CanEncryptCommunications = 4;
  public const int CanEncryptStorage = 8;
  public const int MaybeSplit = 16 /*0x10*/;
  public const int MaybeShared = 128 /*0x80*/;
}
