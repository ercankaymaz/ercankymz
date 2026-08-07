// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Bindings.ChannelQuotas
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class ChannelQuotas
{
  private readonly object m_lock = new object();
  private int m_maxMessageSize;
  private int m_maxBufferSize;
  private int m_channelLifetime;
  private int m_securityTokenLifetime;
  private IServiceMessageContext m_messageContext;
  private ICertificateValidator m_certificateValidator;

  public ChannelQuotas()
  {
    this.m_messageContext = (IServiceMessageContext) ServiceMessageContext.GlobalContext;
    this.m_maxMessageSize = 1048560;
    this.m_maxBufferSize = (int) ushort.MaxValue;
    this.m_channelLifetime = 60000;
    this.m_securityTokenLifetime = 3600000;
  }

  public IServiceMessageContext MessageContext
  {
    get
    {
      lock (this.m_lock)
        return this.m_messageContext;
    }
    set
    {
      lock (this.m_lock)
        this.m_messageContext = value;
    }
  }

  public ICertificateValidator CertificateValidator
  {
    get
    {
      lock (this.m_lock)
        return this.m_certificateValidator;
    }
    set
    {
      lock (this.m_lock)
        this.m_certificateValidator = value;
    }
  }

  public int MaxMessageSize
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxMessageSize;
    }
    set
    {
      lock (this.m_lock)
        this.m_maxMessageSize = value;
    }
  }

  public int MaxBufferSize
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxBufferSize;
    }
    set
    {
      lock (this.m_lock)
        this.m_maxBufferSize = value;
    }
  }

  public int ChannelLifetime
  {
    get
    {
      lock (this.m_lock)
        return this.m_channelLifetime;
    }
    set
    {
      lock (this.m_lock)
        this.m_channelLifetime = value;
    }
  }

  public int SecurityTokenLifetime
  {
    get
    {
      lock (this.m_lock)
        return this.m_securityTokenLifetime;
    }
    set
    {
      lock (this.m_lock)
        this.m_securityTokenLifetime = value;
    }
  }
}
