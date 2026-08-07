// Decompiled with JetBrains decompiler
// Type: ns4.Class8
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Mime;
using buPop3.Mime.Traverse;
using System;
using System.Collections.Generic;

#nullable disable
namespace ns4;

internal class Class8 : IQuestionAnswerMessageTraverser<string, List<MessagePart>>
{
  public List<MessagePart> VisitMessage(Message message, string question)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    return this.VisitMessagePart(message.MessagePart, question);
  }

  public List<MessagePart> VisitMessagePart(MessagePart messagePart, string question)
  {
    if (messagePart == null)
      throw new ArgumentNullException(nameof (messagePart));
    List<MessagePart> messagePartList = new List<MessagePart>();
    if (messagePart.ContentType.MediaType.Equals(question, StringComparison.OrdinalIgnoreCase))
      messagePartList.Add(messagePart);
    if (messagePart.IsMultiPart)
    {
      foreach (MessagePart messagePart1 in messagePart.MessageParts)
      {
        List<MessagePart> collection = this.VisitMessagePart(messagePart1, question);
        messagePartList.AddRange((IEnumerable<MessagePart>) collection);
      }
    }
    return messagePartList;
  }
}
