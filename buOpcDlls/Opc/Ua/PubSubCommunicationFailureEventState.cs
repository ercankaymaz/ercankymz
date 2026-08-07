// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubCommunicationFailureEventState
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
public class PubSubCommunicationFailureEventState(NodeState parent) : PubSubStatusEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAAKwAAAFB1YlN1YkNvbW11bmljYXRpb25GYWlsdXJlRXZlbnRUeXBlSW5zdGFuY2UBAMs8AQDLPMs8AAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAzDwALgBEzDwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAzTwALgBEzTwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAM48AC4ARM48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDPPAAuAETPPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA0DwALgBE0DwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBANE8AC4ARNE8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBANM8AC4ARNM8AAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA1DwALgBE1DwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENvbm5lY3Rpb25JZAEA1TwALgBE1TwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAEdyb3VwSWQBANY8AC4ARNY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEA1zwALgBE1zwAAAEANzn/////AQH/////AAAAABVgiQoCAAAAAAAFAAAARXJyb3IBANg8AC4ARNg8AAAAE/////8BAf////8AAAAA";
  private PropertyState<StatusCode> m_error;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15563U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAAKwAAAFB1YlN1YkNvbW11bmljYXRpb25GYWlsdXJlRXZlbnRUeXBlSW5zdGFuY2UBAMs8AQDLPMs8AAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAzDwALgBEzDwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAzTwALgBEzTwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAM48AC4ARM48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDPPAAuAETPPAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA0DwALgBE0DwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBANE8AC4ARNE8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBANM8AC4ARNM8AAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA1DwALgBE1DwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENvbm5lY3Rpb25JZAEA1TwALgBE1TwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAEdyb3VwSWQBANY8AC4ARNY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAUAAABTdGF0ZQEA1zwALgBE1zwAAAEANzn/////AQH/////AAAAABVgiQoCAAAAAAAFAAAARXJyb3IBANg8AC4ARNg8AAAAE/////8BAf////8AAAAA");
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

  public PropertyState<StatusCode> Error
  {
    get => this.m_error;
    set
    {
      if (this.m_error != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_error = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_error != null)
      children.Add((BaseInstanceState) this.m_error);
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
    if (browseName.Name == "Error")
    {
      if (createOrReplace && this.Error == null)
        this.Error = replacement != null ? (PropertyState<StatusCode>) replacement : new PropertyState<StatusCode>((NodeState) this);
      baseInstanceState = (BaseInstanceState) this.Error;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
