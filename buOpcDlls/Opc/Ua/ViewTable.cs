// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ViewTable
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class ViewTable
{
  private readonly object m_lock = new object();
  private Dictionary<NodeId, ViewNode> m_views;

  public ViewTable() => this.m_views = new Dictionary<NodeId, ViewNode>();

  public bool IsValid(ViewDescription description)
  {
    if (ViewDescription.IsDefault(description))
      return true;
    lock (this.m_lock)
      return this.m_views.ContainsKey(description.ViewId);
  }

  public bool IsNodeInView(ViewDescription description, NodeId nodeId)
  {
    if (ViewDescription.IsDefault(description))
      return true;
    lock (this.m_lock)
    {
      ViewNode viewNode = (ViewNode) null;
      if (this.m_views.TryGetValue(description.ViewId, out viewNode))
        throw new ServiceResultException(2154496000U /*0x806B0000*/);
      return false;
    }
  }

  public bool IsReferenceInView(ViewDescription description, ReferenceDescription reference)
  {
    if (ViewDescription.IsDefault(description))
      return true;
    lock (this.m_lock)
    {
      ViewNode viewNode = (ViewNode) null;
      if (this.m_views.TryGetValue(description.ViewId, out viewNode))
        throw new ServiceResultException(2154496000U /*0x806B0000*/);
      return false;
    }
  }

  public void Add(ViewNode view)
  {
    if (view == null)
      throw new ArgumentNullException(nameof (view));
    if (NodeId.IsNull(view.NodeId))
      throw new ServiceResultException(2150825984U /*0x80330000*/, Utils.Format("A view may not have a null node id."));
    lock (this.m_lock)
    {
      if (this.m_views.ContainsKey(view.NodeId))
        throw new ServiceResultException(2153644032U /*0x805E0000*/, Utils.Format("A view with the node id '{0}' already exists.", (object) view.NodeId));
      this.m_views.Add(view.NodeId, view);
    }
  }

  public void Remove(NodeId viewId)
  {
    if (NodeId.IsNull(viewId))
      throw new ArgumentNullException(nameof (viewId));
    lock (this.m_lock)
    {
      ViewNode viewNode = (ViewNode) null;
      if (!this.m_views.TryGetValue(viewId, out viewNode))
        throw new ServiceResultException(2154496000U /*0x806B0000*/, Utils.Format("A reference type with the node id '{0}' does not exist.", (object) viewId));
      this.m_views.Remove(viewId);
    }
  }
}
