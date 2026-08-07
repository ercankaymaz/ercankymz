// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SystemContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class SystemContext : ISystemContext, IOperationContext
{
  private object m_systemHandle;
  private NodeId m_sessionId;
  private IList<string> m_preferredLocales;
  private string m_auditEntryId;
  private IUserIdentity m_userIdentity;
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private ITypeTable m_typeTable;
  private IEncodeableFactory m_encodeableFactory;
  private INodeIdFactory m_nodeIdFactory;
  private IOperationContext m_operationContext;
  private NodeStateFactory m_nodeStateFactory;

  public SystemContext() => this.m_nodeStateFactory = new NodeStateFactory();

  public SystemContext(IOperationContext context)
  {
    this.m_nodeStateFactory = new NodeStateFactory();
    this.m_operationContext = context;
  }

  public object SystemHandle
  {
    get => this.m_systemHandle;
    set => this.m_systemHandle = value;
  }

  public NodeId SessionId
  {
    get => this.m_operationContext != null ? this.m_operationContext.SessionId : this.m_sessionId;
    set => this.m_sessionId = value;
  }

  public IUserIdentity UserIdentity
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.UserIdentity : this.m_userIdentity;
    }
    set => this.m_userIdentity = value;
  }

  public IList<string> PreferredLocales
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.PreferredLocales : this.m_preferredLocales;
    }
    set => this.m_preferredLocales = value;
  }

  public string AuditEntryId
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.AuditEntryId : this.m_auditEntryId;
    }
    set => this.m_auditEntryId = value;
  }

  public NamespaceTable NamespaceUris
  {
    get => this.m_namespaceUris;
    set => this.m_namespaceUris = value;
  }

  public StringTable ServerUris
  {
    get => this.m_serverUris;
    set => this.m_serverUris = value;
  }

  public ITypeTable TypeTable
  {
    get => this.m_typeTable;
    set => this.m_typeTable = value;
  }

  public IEncodeableFactory EncodeableFactory
  {
    get => this.m_encodeableFactory;
    set => this.m_encodeableFactory = value;
  }

  public NodeStateFactory NodeStateFactory
  {
    get => this.m_nodeStateFactory;
    set => this.m_nodeStateFactory = value;
  }

  public INodeIdFactory NodeIdFactory
  {
    get => this.m_nodeIdFactory;
    set => this.m_nodeIdFactory = value;
  }

  public IOperationContext OperationContext
  {
    get => this.m_operationContext;
    protected set => this.m_operationContext = value;
  }

  public ISystemContext Copy(IOperationContext context)
  {
    SystemContext systemContext = (SystemContext) this.MemberwiseClone();
    if (context != null)
      systemContext.m_operationContext = context;
    return (ISystemContext) systemContext;
  }

  public DiagnosticsMasks DiagnosticsMask
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.DiagnosticsMask : DiagnosticsMasks.None;
    }
  }

  public StringTable StringTable
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.StringTable : (StringTable) null;
    }
  }

  public DateTime OperationDeadline
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.OperationDeadline : DateTime.MaxValue;
    }
  }

  public StatusCode OperationStatus
  {
    get
    {
      return this.m_operationContext != null ? this.m_operationContext.OperationStatus : (StatusCode) 0U;
    }
  }
}
