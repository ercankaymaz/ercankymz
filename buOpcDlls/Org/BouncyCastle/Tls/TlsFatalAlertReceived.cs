// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Tls.TlsFatalAlertReceived
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Runtime.Serialization;

#nullable disable
namespace Org.BouncyCastle.Tls;

[Serializable]
public class TlsFatalAlertReceived : TlsException
{
  protected readonly byte m_alertDescription;

  public TlsFatalAlertReceived(short alertDescription)
    : base(Org.BouncyCastle.Tls.AlertDescription.GetText(alertDescription))
  {
    this.m_alertDescription = TlsUtilities.IsValidUint8(alertDescription) ? (byte) alertDescription : throw new ArgumentOutOfRangeException(nameof (alertDescription));
  }

  protected TlsFatalAlertReceived(SerializationInfo info, StreamingContext context)
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
