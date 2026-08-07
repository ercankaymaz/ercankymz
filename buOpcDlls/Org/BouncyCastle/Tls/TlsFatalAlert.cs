// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsFatalAlert
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Tls;

[Serializable]
public class TlsFatalAlert : TlsException
{
  protected readonly byte m_alertDescription;

  private static string GetMessage(short alertDescription, string detailMessage)
  {
    string message = Org.BouncyCastle.Tls.AlertDescription.GetText(alertDescription);
    if (detailMessage != null)
      message = $"{message}; {detailMessage}";
    return message;
  }

  public TlsFatalAlert(short alertDescription)
    : this(alertDescription, (string) null, (Exception) null)
  {
  }

  public TlsFatalAlert(short alertDescription, string detailMessage)
    : this(alertDescription, detailMessage, (Exception) null)
  {
  }

  public TlsFatalAlert(short alertDescription, Exception alertCause)
    : this(alertDescription, (string) null, alertCause)
  {
  }

  public TlsFatalAlert(short alertDescription, string detailMessage, Exception alertCause)
    : base(TlsFatalAlert.GetMessage(alertDescription, detailMessage), alertCause)
  {
    this.m_alertDescription = TlsUtilities.IsValidUint8(alertDescription) ? (byte) alertDescription : throw new ArgumentOutOfRangeException(nameof (alertDescription));
  }

  protected TlsFatalAlert(SerializationInfo info, StreamingContext context)
    : base(info, context)
  {
    this.m_alertDescription = info.GetByte("alertDescription");
  }

  public override void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    base.GetObjectData(info, context);
    info.AddValue("alertDescription", this.m_alertDescription);
  }

  public virtual short AlertDescription => (short) this.m_alertDescription;
}
