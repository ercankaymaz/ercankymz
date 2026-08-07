// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SecureChannelContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class SecureChannelContext
{
  private string m_secureChannelId;
  private EndpointDescription m_endpointDescription;
  private RequestEncoding m_messageEncoding;
  private static ThreadLocal<SecureChannelContext> s_Dataslot = new ThreadLocal<SecureChannelContext>();

  public SecureChannelContext(
    string secureChannelId,
    EndpointDescription endpointDescription,
    RequestEncoding messageEncoding)
  {
    this.m_secureChannelId = secureChannelId;
    this.m_endpointDescription = endpointDescription;
    this.m_messageEncoding = messageEncoding;
  }

  protected SecureChannelContext()
  {
    SecureChannelContext current = SecureChannelContext.Current;
    if (current == null)
      return;
    this.m_secureChannelId = current.SecureChannelId;
    this.m_endpointDescription = current.EndpointDescription;
    this.m_messageEncoding = current.MessageEncoding;
  }

  public string SecureChannelId => this.m_secureChannelId;

  public EndpointDescription EndpointDescription => this.m_endpointDescription;

  public RequestEncoding MessageEncoding => this.m_messageEncoding;

  public static SecureChannelContext Current
  {
    get => SecureChannelContext.s_Dataslot.Value;
    set => SecureChannelContext.s_Dataslot.Value = value;
  }
}
