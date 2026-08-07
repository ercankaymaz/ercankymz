// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsSessionImpl
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Utilities;
using System;

#nullable disable
namespace Org.BouncyCastle.Tls;

internal class TlsSessionImpl : TlsSession
{
  private readonly byte[] m_sessionID;
  private readonly SessionParameters m_sessionParameters;
  private bool m_resumable;

  internal TlsSessionImpl(byte[] sessionID, SessionParameters sessionParameters)
  {
    if (sessionID == null)
      throw new ArgumentNullException(nameof (sessionID));
    this.m_sessionID = sessionID.Length <= 32 /*0x20*/ ? Arrays.Clone(sessionID) : throw new ArgumentException("cannot be longer than 32 bytes", nameof (sessionID));
    this.m_sessionParameters = sessionParameters;
    this.m_resumable = sessionID.Length != 0 && sessionParameters != null;
  }

  public SessionParameters ExportSessionParameters()
  {
    lock (this)
      return this.m_sessionParameters == null ? (SessionParameters) null : this.m_sessionParameters.Copy();
  }

  public byte[] SessionID
  {
    get
    {
      lock (this)
        return this.m_sessionID;
    }
  }

  public void Invalidate()
  {
    lock (this)
      this.m_resumable = false;
  }

  public bool IsResumable
  {
    get
    {
      lock (this)
        return this.m_resumable;
    }
  }
}
