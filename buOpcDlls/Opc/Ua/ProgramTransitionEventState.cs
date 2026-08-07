// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ProgramTransitionEventState
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
public class ProgramTransitionEventState(NodeState parent) : TransitionEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAFByb2dyYW1UcmFuc2l0aW9uRXZlbnRUeXBlSW5zdGFuY2UBAEoJAQBKCUoJAAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAxg4ALgBExg4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAxw4ALgBExw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAMgOAC4ARMgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDJDgAuAETJDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAyg4ALgBEyg4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAMsOAC4ARMsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAM0OAC4ARM0OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAzg4ALgBEzg4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRyYW5zaXRpb24BANkOAC8BAMoK2Q4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDaDgAuAETaDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARnJvbVN0YXRlAQDPDgAvAQDDCs8OAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA0A4ALgBE0A4AAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFRvU3RhdGUBANQOAC8BAMMK1A4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDVDgAuAETVDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAASAAAASW50ZXJtZWRpYXRlUmVzdWx0AQBLCQAvAD9LCQAAABj/////AQH/////AAAAAA==";
  private BaseDataVariableState m_intermediateResult;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 2378U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAIgAAAFByb2dyYW1UcmFuc2l0aW9uRXZlbnRUeXBlSW5zdGFuY2UBAEoJAQBKCUoJAAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAxg4ALgBExg4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAxw4ALgBExw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAMgOAC4ARMgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDJDgAuAETJDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAyg4ALgBEyg4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAMsOAC4ARMsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAM0OAC4ARM0OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAzg4ALgBEzg4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRyYW5zaXRpb24BANkOAC8BAMoK2Q4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDaDgAuAETaDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARnJvbVN0YXRlAQDPDgAvAQDDCs8OAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA0A4ALgBE0A4AAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFRvU3RhdGUBANQOAC8BAMMK1A4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDVDgAuAETVDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAASAAAASW50ZXJtZWRpYXRlUmVzdWx0AQBLCQAvAD9LCQAAABj/////AQH/////AAAAAA==");
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
  }

  public BaseDataVariableState IntermediateResult
  {
    get => this.m_intermediateResult;
    set
    {
      if (this.m_intermediateResult != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_intermediateResult = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_intermediateResult != null)
      children.Add((BaseInstanceState) this.m_intermediateResult);
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
    if (browseName.Name == "IntermediateResult")
    {
      if (createOrReplace && this.IntermediateResult == null)
        this.IntermediateResult = replacement != null ? (BaseDataVariableState) replacement : new BaseDataVariableState((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.IntermediateResult;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
