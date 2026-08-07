// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PubSubTransportLimitsExceedEventState
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
public class PubSubTransportLimitsExceedEventState(NodeState parent) : PubSubStatusEventState(parent)
{
  private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAFB1YlN1YlRyYW5zcG9ydExpbWl0c0V4Y2VlZEV2ZW50VHlwZUluc3RhbmNlAQC8PAEAvDy8PAAA/////w0AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAL08AC4ARL08AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAL48AC4ARL48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC/PAAuAES/PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAwDwALgBEwDwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAME8AC4ARME8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDCPAAuAETCPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDEPAAuAETEPAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMU8AC4ARMU8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBAMY8AC4ARMY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQDHPAAuAETHPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMg8AC4ARMg8AAABADc5/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAEFjdHVhbAEAyTwALgBEyTwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1heGltdW0BAMo8AC4ARMo8AAAAB/////8BAf////8AAAAA";
  private PropertyState<uint> m_actual;
  private PropertyState<uint> m_maximum;

  protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
  {
    return NodeId.Create((object) 15548U, "http://opcfoundation.org/UA/", namespaceUris);
  }

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Initialize(context, "//////////8EYIACAQAAAAAALAAAAFB1YlN1YlRyYW5zcG9ydExpbWl0c0V4Y2VlZEV2ZW50VHlwZUluc3RhbmNlAQC8PAEAvDy8PAAA/////w0AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAL08AC4ARL08AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAL48AC4ARL48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC/PAAuAES/PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAwDwALgBEwDwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAME8AC4ARME8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDCPAAuAETCPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDEPAAuAETEPAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMU8AC4ARMU8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBAMY8AC4ARMY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQDHPAAuAETHPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMg8AC4ARMg8AAABADc5/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAEFjdHVhbAEAyTwALgBEyTwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1heGltdW0BAMo8AC4ARMo8AAAAB/////8BAf////8AAAAA");
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

  public PropertyState<uint> Actual
  {
    get => this.m_actual;
    set
    {
      if (this.m_actual != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_actual = value;
    }
  }

  public PropertyState<uint> Maximum
  {
    get => this.m_maximum;
    set
    {
      if (this.m_maximum != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_maximum = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_actual != null)
      children.Add((BaseInstanceState) this.m_actual);
    if (this.m_maximum != null)
      children.Add((BaseInstanceState) this.m_maximum);
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
    switch (browseName.Name)
    {
      case "Actual":
        if (createOrReplace && this.Actual == null)
          this.Actual = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Actual;
        break;
      case "Maximum":
        if (createOrReplace && this.Maximum == null)
          this.Maximum = replacement != null ? (PropertyState<uint>) replacement : new PropertyState<uint>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.Maximum;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }
}
