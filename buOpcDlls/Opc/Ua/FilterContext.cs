// Decompiled with JetBrains decompiler
// Type: Opc.Ua.FilterContext
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class FilterContext : IOperationContext
{
  private NamespaceTable m_namespaceUris;
  private ITypeTable m_typeTree;
  private IOperationContext m_context;
  private IList<string> m_preferredLocales;

  public FilterContext(
    NamespaceTable namespaceUris,
    ITypeTable typeTree,
    IOperationContext context)
  {
    if (namespaceUris == null)
      throw new ArgumentNullException(nameof (namespaceUris));
    if (typeTree == null)
      throw new ArgumentNullException(nameof (typeTree));
    this.m_namespaceUris = namespaceUris;
    this.m_typeTree = typeTree;
    this.m_context = context;
  }

  public FilterContext(NamespaceTable namespaceUris, ITypeTable typeTree)
    : this(namespaceUris, typeTree, (IList<string>) null)
  {
  }

  public FilterContext(
    NamespaceTable namespaceUris,
    ITypeTable typeTree,
    IList<string> preferredLocales)
  {
    if (namespaceUris == null)
      throw new ArgumentNullException(nameof (namespaceUris));
    if (typeTree == null)
      throw new ArgumentNullException(nameof (typeTree));
    this.m_namespaceUris = namespaceUris;
    this.m_typeTree = typeTree;
    this.m_context = (IOperationContext) null;
    this.m_preferredLocales = preferredLocales;
  }

  public NamespaceTable NamespaceUris => this.m_namespaceUris;

  public ITypeTable TypeTree => this.m_typeTree;

  public NodeId SessionId => this.m_context != null ? this.m_context.SessionId : (NodeId) null;

  public IUserIdentity UserIdentity
  {
    get => this.m_context != null ? this.m_context.UserIdentity : (IUserIdentity) null;
  }

  public IList<string> PreferredLocales
  {
    get => this.m_context != null ? this.m_context.PreferredLocales : this.m_preferredLocales;
  }

  public DiagnosticsMasks DiagnosticsMask
  {
    get => this.m_context != null ? this.m_context.DiagnosticsMask : DiagnosticsMasks.SymbolicId;
  }

  public StringTable StringTable
  {
    get => this.m_context != null ? this.m_context.StringTable : (StringTable) null;
  }

  public DateTime OperationDeadline
  {
    get => this.m_context != null ? this.m_context.OperationDeadline : DateTime.MaxValue;
  }

  public StatusCode OperationStatus
  {
    get => this.m_context != null ? this.m_context.OperationStatus : (StatusCode) 0U;
  }

  public string AuditEntryId
  {
    get => this.m_context != null ? this.m_context.AuditEntryId : (string) null;
  }
}
