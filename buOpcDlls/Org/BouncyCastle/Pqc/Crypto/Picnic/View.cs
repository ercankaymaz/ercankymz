// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Pqc.Crypto.Picnic.View
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Pqc.Crypto.Picnic;

internal class View
{
  internal uint[] inputShare;
  internal byte[] communicatedBits;
  internal uint[] outputShare;

  internal View(PicnicEngine engine)
  {
    this.inputShare = new uint[engine.stateSizeBytes];
    this.communicatedBits = new byte[engine.andSizeBytes];
    this.outputShare = new uint[engine.stateSizeBytes];
  }
}
