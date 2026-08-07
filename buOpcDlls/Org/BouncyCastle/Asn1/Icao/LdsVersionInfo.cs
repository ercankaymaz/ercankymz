// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Asn1.Icao.LdsVersionInfo
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;

#nullable disable
namespace Org.BouncyCastle.Asn1.Icao;

public class LdsVersionInfo : Asn1Encodable
{
  private DerPrintableString ldsVersion;
  private DerPrintableString unicodeVersion;

  public LdsVersionInfo(string ldsVersion, string unicodeVersion)
  {
    this.ldsVersion = new DerPrintableString(ldsVersion);
    this.unicodeVersion = new DerPrintableString(unicodeVersion);
  }

  private LdsVersionInfo(Asn1Sequence seq)
  {
    this.ldsVersion = seq.Count == 2 ? DerPrintableString.GetInstance((object) seq[0]) : throw new ArgumentException("sequence wrong size for LDSVersionInfo", nameof (seq));
    this.unicodeVersion = DerPrintableString.GetInstance((object) seq[1]);
  }

  public static LdsVersionInfo GetInstance(object obj)
  {
    if (obj is LdsVersionInfo)
      return (LdsVersionInfo) obj;
    return obj != null ? new LdsVersionInfo(Asn1Sequence.GetInstance(obj)) : (LdsVersionInfo) null;
  }

  public virtual string GetLdsVersion() => this.ldsVersion.GetString();

  public virtual string GetUnicodeVersion() => this.unicodeVersion.GetString();

  public override Asn1Object ToAsn1Object()
  {
    return (Asn1Object) new DerSequence((Asn1Encodable) this.ldsVersion, (Asn1Encodable) this.unicodeVersion);
  }
}
