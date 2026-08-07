// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AuditConditionShelvingEventState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionShelvingEventState(NodeState parent) : AuditConditionEventState(parent)
{
  private const string ShelvingTime_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==";
  private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0Q29uZGl0aW9uU2hlbHZpbmdFdmVudFR5cGVJbnN0YW5jZQEAVSsBAFUrVSsAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBWKwAuAERWKwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBXKwAuAERXKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAWCsALgBEWCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFkrAC4ARFkrAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBaKwAuAERaKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAWysALgBEWysAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAXSsALgBEXSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBeKwAuAEReKwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBfKwAuAERfKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAGArAC4ARGArAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAYSsALgBEYSsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAYisALgBEYisAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAYysALgBEYysAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBkKwAuAERkKwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGUrAC4ARGUrAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==";
  private PropertyState<double> m_shelvingTime;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 11093U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0Q29uZGl0aW9uU2hlbHZpbmdFdmVudFR5cGVJbnN0YW5jZQEAVSsBAFUrVSsAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBWKwAuAERWKwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBXKwAuAERXKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAWCsALgBEWCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFkrAC4ARFkrAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBaKwAuAERaKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAWysALgBEWysAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAXSsALgBEXSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBeKwAuAEReKwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBfKwAuAERfKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAGArAC4ARGArAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAYSsALgBEYSsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAYisALgBEYisAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAYysALgBEYysAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBkKwAuAERkKwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGUrAC4ARGUrAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==");
    this.InitializeOptionalChildren(context);
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    this.InitializeOptionalChildren(context);
    base.Initialize(context, source);
  }

  protected override void InitializeOptionalChildren(ISystemContext context)
  {
    base.InitializeOptionalChildren(context);
    if (this.ShelvingTime == null)
      return;
    this.ShelvingTime.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==");
  }

  public PropertyState<double> ShelvingTime
  {
    get => this.m_shelvingTime;
    set
    {
      if (this.m_shelvingTime != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_shelvingTime = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_shelvingTime != null)
      children.Add((BaseInstanceState) this.m_shelvingTime);
    base.GetChildren(context, children);
  }

  protected override BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    BaseInstanceState baseInstanceState = (BaseInstanceState) null;
    if (browseName.Name == "ShelvingTime")
    {
      if (createOrReplace && this.ShelvingTime == null)
        this.ShelvingTime = replacement != null ? (PropertyState<double>) replacement : new PropertyState<double>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.ShelvingTime;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
