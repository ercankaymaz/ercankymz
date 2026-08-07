// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.JPake.JPakeRound2Payload
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.JPake;

public class JPakeRound2Payload
{
  private readonly string participantId;
  private readonly BigInteger a;
  private readonly BigInteger[] knowledgeProofForX2s;

  public JPakeRound2Payload(string participantId, BigInteger a, BigInteger[] knowledgeProofForX2s)
  {
    JPakeUtilities.ValidateNotNull((object) participantId, nameof (participantId));
    JPakeUtilities.ValidateNotNull((object) a, nameof (a));
    JPakeUtilities.ValidateNotNull((object) knowledgeProofForX2s, nameof (knowledgeProofForX2s));
    this.participantId = participantId;
    this.a = a;
    this.knowledgeProofForX2s = new BigInteger[knowledgeProofForX2s.Length];
    knowledgeProofForX2s.CopyTo((Array) this.knowledgeProofForX2s, 0);
  }

  public virtual string ParticipantId => this.participantId;

  public virtual BigInteger A => this.a;

  public virtual BigInteger[] KnowledgeProofForX2s
  {
    get
    {
      BigInteger[] destinationArray = new BigInteger[this.knowledgeProofForX2s.Length];
      Array.Copy((Array) this.knowledgeProofForX2s, (Array) destinationArray, this.knowledgeProofForX2s.Length);
      return destinationArray;
    }
  }
}
