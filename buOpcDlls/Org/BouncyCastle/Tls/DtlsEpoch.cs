// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.DtlsEpoch
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Tls.Crypto;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal sealed class DtlsEpoch
{
  private readonly DtlsReplayWindow m_replayWindow = new DtlsReplayWindow();
  private readonly int m_epoch;
  private readonly TlsCipher m_cipher;
  private readonly int m_recordHeaderLengthRead;
  private readonly int m_recordHeaderLengthWrite;
  private long m_sequenceNumber;

  internal DtlsEpoch(
    int epoch,
    TlsCipher cipher,
    int recordHeaderLengthRead,
    int recordHeaderLengthWrite)
  {
    if (epoch < 0)
      throw new ArgumentException("must be >= 0", nameof (epoch));
    if (cipher == null)
      throw new ArgumentNullException(nameof (cipher));
    this.m_epoch = epoch;
    this.m_cipher = cipher;
    this.m_recordHeaderLengthRead = recordHeaderLengthRead;
    this.m_recordHeaderLengthWrite = recordHeaderLengthWrite;
  }

  internal long AllocateSequenceNumber()
  {
    lock (this)
    {
      if (this.m_sequenceNumber >= 281474976710656L /*0x01000000000000*/)
        throw new TlsFatalAlert((short) 80 /*0x50*/);
      return this.m_sequenceNumber++;
    }
  }

  internal TlsCipher Cipher => this.m_cipher;

  internal int Epoch => this.m_epoch;

  internal int RecordHeaderLengthRead => this.m_recordHeaderLengthRead;

  internal int RecordHeaderLengthWrite => this.m_recordHeaderLengthWrite;

  internal DtlsReplayWindow ReplayWindow => this.m_replayWindow;

  internal long SequenceNumber
  {
    get
    {
      lock (this)
        return this.m_sequenceNumber;
    }
    set
    {
      lock (this)
        this.m_sequenceNumber = value;
    }
  }
}
