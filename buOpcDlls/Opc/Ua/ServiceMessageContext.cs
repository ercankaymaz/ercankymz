// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ServiceMessageContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ServiceMessageContext : IServiceMessageContext
{
  private readonly object m_lock = new object();
  private int m_maxStringLength;
  private int m_maxByteStringLength;
  private int m_maxArrayLength;
  private int m_maxMessageSize;
  private uint m_maxEncodingNestingLevels;
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private IEncodeableFactory m_factory;
  private static ServiceMessageContext s_globalContext = new ServiceMessageContext(true);

  public ServiceMessageContext()
  {
    this.m_maxStringLength = (int) ushort.MaxValue;
    this.m_maxByteStringLength = 1048560;
    this.m_maxArrayLength = (int) ushort.MaxValue;
    this.m_maxMessageSize = 2097120;
    this.m_namespaceUris = new NamespaceTable();
    this.m_serverUris = new StringTable();
    this.m_factory = (IEncodeableFactory) EncodeableFactory.GlobalFactory;
    this.m_maxEncodingNestingLevels = 200U;
  }

  private ServiceMessageContext(bool shared)
    : this()
  {
    this.m_maxStringLength = (int) ushort.MaxValue;
    this.m_maxByteStringLength = 1048560;
    this.m_maxArrayLength = (int) ushort.MaxValue;
    this.m_maxMessageSize = 2097120;
    this.m_namespaceUris = new NamespaceTable(shared);
    this.m_serverUris = new StringTable(shared);
    this.m_factory = (IEncodeableFactory) EncodeableFactory.GlobalFactory;
    this.m_maxEncodingNestingLevels = 200U;
  }

  public static ServiceMessageContext GlobalContext => ServiceMessageContext.s_globalContext;

  public static ServiceMessageContext ThreadContext
  {
    get => ServiceMessageContext.s_globalContext;
    set
    {
    }
  }

  public object SyncRoot => this.m_lock;

  public int MaxStringLength
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxStringLength;
    }
    set
    {
      lock (this.m_lock)
        this.m_maxStringLength = value;
    }
  }

  public int MaxArrayLength
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxArrayLength;
    }
    set
    {
      lock (this.m_lock)
        this.m_maxArrayLength = value;
    }
  }

  public int MaxByteStringLength
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxByteStringLength;
    }
    set
    {
      lock (this.m_lock)
        this.m_maxByteStringLength = value;
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

  public uint MaxEncodingNestingLevels
  {
    get
    {
      lock (this.m_lock)
        return this.m_maxEncodingNestingLevels;
    }
  }

  public NamespaceTable NamespaceUris
  {
    get => this.m_namespaceUris;
    set
    {
      lock (this.m_lock)
      {
        if (value == null)
          this.m_namespaceUris = ServiceMessageContext.GlobalContext.NamespaceUris;
        else
          this.m_namespaceUris = value;
      }
    }
  }

  public StringTable ServerUris
  {
    get => this.m_serverUris;
    set
    {
      lock (this.m_lock)
      {
        if (value == null)
          this.m_serverUris = ServiceMessageContext.GlobalContext.ServerUris;
        else
          this.m_serverUris = value;
      }
    }
  }

  public IEncodeableFactory Factory
  {
    get => this.m_factory;
    set
    {
      lock (this.m_lock)
      {
        if (value == null)
          this.m_factory = ServiceMessageContext.GlobalContext.Factory;
        else
          this.m_factory = value;
      }
    }
  }
}
