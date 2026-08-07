// Decompiled with JetBrains decompiler
// Type: ns3.Class6
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using buPop3.Mime;
using buPop3.Mime.Traverse;
using System;
using System.Collections.Generic;

#nullable disable
namespace ns3;

internal class Class6 : MultipleMessagePartFinder
{
  protected override List<MessagePart> CaseLeaf(MessagePart messagePart)
  {
    if (messagePart == null)
      throw new ArgumentNullException(nameof (messagePart));
    List<MessagePart> messagePartList = new List<MessagePart>(1);
    if (messagePart.IsAttachment)
      messagePartList.Add(messagePart);
    return messagePartList;
  }
}
