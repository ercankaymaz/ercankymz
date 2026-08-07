// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Utilities.Encoders.UrlBase64Encoder
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Utilities.Encoders;

public class UrlBase64Encoder : Base64Encoder
{
  public UrlBase64Encoder()
  {
    this.encodingTable[this.encodingTable.Length - 2] = (byte) 45;
    this.encodingTable[this.encodingTable.Length - 1] = (byte) 95;
    this.padding = (byte) 46;
    this.InitialiseDecodingTable();
  }
}
