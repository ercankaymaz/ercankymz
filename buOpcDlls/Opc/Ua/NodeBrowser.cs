// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeBrowser
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeBrowser : INodeBrowser, IDisposable
{
  private readonly object m_lock = new object();
  private ISystemContext m_context;
  private ViewDescription m_view;
  private NodeId m_referenceType;
  private bool m_includeSubtypes;
  private BrowseDirection m_browseDirection;
  private IReference m_pushBack;
  private List<IReference> m_references;
  private QualifiedName m_browseName;
  private bool m_internalOnly;
  private int m_index;

  public NodeBrowser(
    ISystemContext context,
    ViewDescription view,
    NodeId referenceType,
    bool includeSubtypes,
    BrowseDirection browseDirection,
    QualifiedName browseName,
    IEnumerable<IReference> additionalReferences,
    bool internalOnly)
  {
    this.m_context = context;
    this.m_view = view;
    this.m_referenceType = referenceType;
    this.m_includeSubtypes = includeSubtypes;
    this.m_browseDirection = browseDirection;
    this.m_browseName = browseName;
    this.m_internalOnly = internalOnly;
    this.m_references = new List<IReference>();
    this.m_index = 0;
    if (additionalReferences == null)
      return;
    foreach (IReference additionalReference in additionalReferences)
    {
      if (this.IsRequired(additionalReference.ReferenceTypeId, additionalReference.IsInverse))
        this.m_references.Add(additionalReference);
    }
  }

  public void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
  }

  public virtual IReference Next()
  {
    lock (this.DataLock)
    {
      if (this.m_pushBack != null)
      {
        IReference pushBack = this.m_pushBack;
        this.m_pushBack = (IReference) null;
        return pushBack;
      }
      return this.m_index < this.m_references.Count ? this.m_references[this.m_index++] : (IReference) null;
    }
  }

  public virtual void Push(IReference reference)
  {
    lock (this.DataLock)
      this.m_pushBack = reference;
  }

  public virtual bool IsRequired(NodeState target) => true;

  public virtual bool IsRequired(NodeId referenceType, bool isInverse)
  {
    if (NodeId.IsNull(referenceType))
      return false;
    if (isInverse)
    {
      if (this.m_browseDirection == BrowseDirection.Forward)
        return false;
    }
    else if (this.m_browseDirection == BrowseDirection.Inverse)
      return false;
    return NodeId.IsNull(this.m_referenceType) || referenceType == (object) this.m_referenceType || this.m_includeSubtypes && this.m_context != null && this.m_context.TypeTable.IsTypeOf(referenceType, this.m_referenceType);
  }

  public virtual void Add(IReference reference)
  {
    lock (this.DataLock)
      this.m_references.Add(reference);
  }

  public virtual void Add(NodeId referenceTypeId, bool isInverse, NodeState target)
  {
    lock (this.DataLock)
    {
      if (!QualifiedName.IsNull(this.m_browseName) && target.BrowseName != this.m_browseName)
        return;
      this.m_references.Add((IReference) new NodeStateReference(referenceTypeId, isInverse, target));
    }
  }

  public virtual void Add(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    lock (this.DataLock)
      this.m_references.Add((IReference) new NodeStateReference(referenceTypeId, isInverse, targetId));
  }

  protected object DataLock => this.m_lock;

  public ISystemContext SystemContext => this.m_context;

  public ViewDescription View => this.m_view;

  public NodeId ReferenceType => this.m_referenceType;

  public bool IncludeSubtypes => this.m_includeSubtypes;

  public BrowseDirection BrowseDirection => this.m_browseDirection;

  public QualifiedName BrowseName => this.m_browseName;

  public bool InternalOnly => this.m_internalOnly;
}
