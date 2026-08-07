// Decompiled with JetBrains decompiler
// Type: ns1.Class9
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Mime;
using buPop3.Mime.Traverse;
using System;

#nullable disable
namespace ns1;

internal class Class9 : IQuestionAnswerMessageTraverser<string, MessagePart>
{
  public MessagePart VisitMessage(Message message, string question)
  {
    if (message == null)
      throw new ArgumentNullException(nameof (message));
    return this.VisitMessagePart(message.MessagePart, question);
  }

  public MessagePart VisitMessagePart(MessagePart messagePart, string question)
  {
    if (messagePart == null)
      throw new ArgumentNullException(nameof (messagePart));
    MessagePart messagePart1;
    if (messagePart.ContentType.MediaType.Equals(question, StringComparison.OrdinalIgnoreCase))
    {
      messagePart1 = messagePart;
    }
    else
    {
      if (messagePart.IsMultiPart)
      {
        foreach (MessagePart messagePart2 in messagePart.MessageParts)
        {
          MessagePart messagePart3 = this.VisitMessagePart(messagePart2, question);
          if (messagePart3 != null)
          {
            messagePart1 = messagePart3;
            goto label_12;
          }
        }
      }
      messagePart1 = (MessagePart) null;
    }
label_12:
    return messagePart1;
  }
}
