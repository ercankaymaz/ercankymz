// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.BaseBinding
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public abstract class BaseBinding
{
  private IServiceMessageContext m_messageContext;

  protected BaseBinding(
    NamespaceTable namespaceUris,
    IEncodeableFactory factory,
    EndpointConfiguration configuration)
  {
    this.m_messageContext = (IServiceMessageContext) new ServiceMessageContext()
    {
      MaxStringLength = configuration.MaxStringLength,
      MaxByteStringLength = configuration.MaxByteStringLength,
      MaxArrayLength = configuration.MaxArrayLength,
      MaxMessageSize = configuration.MaxMessageSize,
      Factory = factory,
      NamespaceUris = namespaceUris
    };
  }

  public IServiceMessageContext MessageContext
  {
    get => this.m_messageContext;
    set => this.m_messageContext = value;
  }
}
