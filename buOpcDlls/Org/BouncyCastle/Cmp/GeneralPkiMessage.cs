// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Cmp.GeneralPkiMessage
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Asn1;
using Org.BouncyCastle.Asn1.Cmp;

#nullable disable
namespace Org.BouncyCastle.Cmp;

public class GeneralPkiMessage
{
  private readonly PkiMessage m_pkiMessage;

  private static PkiMessage ParseBytes(byte[] encoding)
  {
    return PkiMessage.GetInstance((object) Asn1Object.FromByteArray(encoding));
  }

  public GeneralPkiMessage(PkiMessage pkiMessage) => this.m_pkiMessage = pkiMessage;

  public GeneralPkiMessage(byte[] encoding)
    : this(GeneralPkiMessage.ParseBytes(encoding))
  {
  }

  public virtual PkiHeader Header => this.m_pkiMessage.Header;

  public virtual PkiBody Body => this.m_pkiMessage.Body;

  public virtual bool HasProtection => this.m_pkiMessage.Protection != null;

  public virtual PkiMessage ToAsn1Structure() => this.m_pkiMessage;
}
