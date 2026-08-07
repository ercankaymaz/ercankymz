// Decompiled with JetBrains decompiler
// Type: buPop3.Mime.Traverse.IAnswerMessageTraverser`1
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

#nullable disable
namespace buPop3.Mime.Traverse;

public interface IAnswerMessageTraverser<TAnswer>
{
  TAnswer VisitMessage(Message message);

  TAnswer VisitMessagePart(MessagePart messagePart);
}
