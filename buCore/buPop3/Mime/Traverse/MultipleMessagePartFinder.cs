// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Traverse.MultipleMessagePartFinder
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace buPop3.Mime.Traverse;

public abstract class MultipleMessagePartFinder : AnswerMessageTraverser<List<MessagePart>>
{
  protected override List<MessagePart> MergeLeafAnswers(List<List<MessagePart>> leafAnswers)
  {
    if (leafAnswers == null)
      throw new ArgumentNullException(nameof (leafAnswers));
    List<MessagePart> messagePartList = new List<MessagePart>();
    foreach (List<MessagePart> leafAnswer in leafAnswers)
      messagePartList.AddRange((IEnumerable<MessagePart>) leafAnswer);
    return messagePartList;
  }
}
