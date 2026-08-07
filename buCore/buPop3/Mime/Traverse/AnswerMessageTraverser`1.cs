// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Traverse.AnswerMessageTraverser`1
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buPop3.Mime.Traverse;

public abstract class AnswerMessageTraverser<TAnswer> : IAnswerMessageTraverser<TAnswer>
{
  public TAnswer VisitMessage(Message message)
  {
    return message != null ? this.VisitMessagePart(message.MessagePart) : throw new ArgumentNullException(nameof (message));
  }

  public TAnswer VisitMessagePart(MessagePart messagePart)
  {
    if (messagePart == null)
      throw new ArgumentNullException(nameof (messagePart));
    TAnswer answer;
    if (messagePart.IsMultiPart)
    {
      List<TAnswer> leafAnswers = new List<TAnswer>(messagePart.MessageParts.Count);
      foreach (MessagePart messagePart1 in messagePart.MessageParts)
        leafAnswers.Add(this.VisitMessagePart(messagePart1));
      answer = this.MergeLeafAnswers(leafAnswers);
    }
    else
      answer = this.CaseLeaf(messagePart);
    return answer;
  }

  protected abstract TAnswer CaseLeaf(MessagePart messagePart);

  protected abstract TAnswer MergeLeafAnswers(List<TAnswer> leafAnswers);
}
