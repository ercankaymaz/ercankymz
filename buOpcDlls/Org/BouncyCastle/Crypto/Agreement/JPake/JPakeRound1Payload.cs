// Decompiled with JetBrains decompiler
// Type: Org.BouncyCastle.Crypto.Agreement.JPake.JPakeRound1Payload
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Org.BouncyCastle.Math;
using System;

#nullable disable
namespace Org.BouncyCastle.Crypto.Agreement.JPake;

public class JPakeRound1Payload
{
  private readonly string participantId;
  private readonly BigInteger gx1;
  private readonly BigInteger gx2;
  private readonly BigInteger[] knowledgeProofForX1;
  private readonly BigInteger[] knowledgeProofForX2;

  public JPakeRound1Payload(
    string participantId,
    BigInteger gx1,
    BigInteger gx2,
    BigInteger[] knowledgeProofForX1,
    BigInteger[] knowledgeProofForX2)
  {
    JPakeUtilities.ValidateNotNull((object) participantId, nameof (participantId));
    JPakeUtilities.ValidateNotNull((object) gx1, nameof (gx1));
    JPakeUtilities.ValidateNotNull((object) gx2, nameof (gx2));
    JPakeUtilities.ValidateNotNull((object) knowledgeProofForX1, nameof (knowledgeProofForX1));
    JPakeUtilities.ValidateNotNull((object) knowledgeProofForX2, nameof (knowledgeProofForX2));
    this.participantId = participantId;
    this.gx1 = gx1;
    this.gx2 = gx2;
    this.knowledgeProofForX1 = new BigInteger[knowledgeProofForX1.Length];
    Array.Copy((Array) knowledgeProofForX1, (Array) this.knowledgeProofForX1, knowledgeProofForX1.Length);
    this.knowledgeProofForX2 = new BigInteger[knowledgeProofForX2.Length];
    Array.Copy((Array) knowledgeProofForX2, (Array) this.knowledgeProofForX2, knowledgeProofForX2.Length);
  }

  public virtual string ParticipantId => this.participantId;

  public virtual BigInteger Gx1 => this.gx1;

  public virtual BigInteger Gx2 => this.gx2;

  public virtual BigInteger[] KnowledgeProofForX1
  {
    get
    {
      BigInteger[] destinationArray = new BigInteger[this.knowledgeProofForX1.Length];
      Array.Copy((Array) this.knowledgeProofForX1, (Array) destinationArray, this.knowledgeProofForX1.Length);
      return destinationArray;
    }
  }

  public virtual BigInteger[] KnowledgeProofForX2
  {
    get
    {
      BigInteger[] destinationArray = new BigInteger[this.knowledgeProofForX2.Length];
      Array.Copy((Array) this.knowledgeProofForX2, (Array) destinationArray, this.knowledgeProofForX2.Length);
      return destinationArray;
    }
  }
}
