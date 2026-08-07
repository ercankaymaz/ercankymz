// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.JPake.JPakeRound3Payload
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.JPake;

public class JPakeRound3Payload
{
  private readonly string participantId;
  private readonly BigInteger macTag;

  public JPakeRound3Payload(string participantId, BigInteger magTag)
  {
    this.participantId = participantId;
    this.macTag = magTag;
  }

  public virtual string ParticipantId => this.participantId;

  public virtual BigInteger MacTag => this.macTag;
}
