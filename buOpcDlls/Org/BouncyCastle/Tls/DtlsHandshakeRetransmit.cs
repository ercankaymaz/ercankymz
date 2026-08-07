// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsHandshakeRetransmit
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

internal interface DtlsHandshakeRetransmit
{
  void ReceivedHandshakeRecord(int epoch, byte[] buf, int off, int len);
}
