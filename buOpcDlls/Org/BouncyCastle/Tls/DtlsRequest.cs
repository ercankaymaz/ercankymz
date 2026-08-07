// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsRequest
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

#nullable disable
namespace Org.BouncyCastle.Tls;

public sealed class DtlsRequest
{
  private readonly long m_recordSeq;
  private readonly byte[] m_message;
  private readonly ClientHello m_clientHello;

  internal DtlsRequest(long recordSeq, byte[] message, ClientHello clientHello)
  {
    this.m_recordSeq = recordSeq;
    this.m_message = message;
    this.m_clientHello = clientHello;
  }

  internal ClientHello ClientHello => this.m_clientHello;

  internal byte[] Message => this.m_message;

  internal int MessageSeq => TlsUtilities.ReadUint16(this.m_message, 4);

  internal long RecordSeq => this.m_recordSeq;
}
