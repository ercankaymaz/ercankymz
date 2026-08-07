// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeStateHierarchyReference
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateHierarchyReference
{
  private string m_sourcePath;
  private NodeId m_referenceTypeId;
  private bool m_isInverse;
  private ExpandedNodeId m_targetId;
  private string m_targetPath;

  public NodeStateHierarchyReference(string sourcePath, IReference reference)
  {
    this.m_sourcePath = sourcePath;
    this.m_referenceTypeId = reference.ReferenceTypeId;
    this.m_isInverse = reference.IsInverse;
    this.m_targetPath = (string) null;
    this.m_targetId = reference.TargetId;
  }

  public NodeStateHierarchyReference(string sourcePath, string targetPath, IReference reference)
  {
    this.m_sourcePath = sourcePath;
    this.m_referenceTypeId = reference.ReferenceTypeId;
    this.m_isInverse = reference.IsInverse;
    this.m_targetPath = targetPath;
  }

  public string SourcePath => this.m_sourcePath;

  public NodeId ReferenceTypeId => this.m_referenceTypeId;

  public bool IsInverse => this.m_isInverse;

  public ExpandedNodeId TargetId => this.m_targetId;

  public string TargetPath => this.m_targetPath;
}
