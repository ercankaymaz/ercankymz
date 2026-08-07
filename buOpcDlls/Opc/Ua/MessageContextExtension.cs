// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MessageContextExtension
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class MessageContextExtension
{
  public MessageContextExtension(IServiceMessageContext messageContext)
  {
    this.MessageContext = messageContext;
  }

  public static MessageContextExtension Current => (MessageContextExtension) null;

  public static IServiceMessageContext CurrentContext
  {
    get
    {
      MessageContextExtension current = MessageContextExtension.Current;
      return current != null ? current.MessageContext : (IServiceMessageContext) ServiceMessageContext.ThreadContext;
    }
  }

  public IServiceMessageContext MessageContext { get; private set; }
}
