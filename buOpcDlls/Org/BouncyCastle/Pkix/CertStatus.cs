// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pkix.CertStatus
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Pkix;

public class CertStatus
{
  public const int Unrevoked = 11;
  public const int Undetermined = 12;
  private int status = 11;
  private DateTime? revocationDate;

  public DateTime? RevocationDate
  {
    get => this.revocationDate;
    set => this.revocationDate = value;
  }

  public int Status
  {
    get => this.status;
    set => this.status = value;
  }
}
