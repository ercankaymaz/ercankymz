// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MethodState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class MethodState : BaseInstanceState
{
  public NodeAttributeEventHandler<bool> OnReadExecutable;
  public NodeAttributeEventHandler<bool> OnWriteExecutable;
  public NodeAttributeEventHandler<bool> OnReadUserExecutable;
  public NodeAttributeEventHandler<bool> OnWriteUserExecutable;
  public GenericMethodCalledEventHandler OnCallMethod;
  public GenericMethodCalledEventHandler2 OnCallMethod2;
  private bool m_executable;
  private bool m_userExecutable;
  private PropertyState<Argument[]> m_inputArguments;
  private PropertyState<Argument[]> m_outputArguments;

  public MethodState(NodeState parent)
    : base(NodeClass.Method, parent)
  {
    this.m_executable = true;
    this.m_userExecutable = true;
  }

  public static NodeState Construct(NodeState parent) => (NodeState) new MethodState(parent);

  protected override void Initialize(ISystemContext context)
  {
    base.Initialize(context);
    this.Executable = true;
    this.UserExecutable = true;
  }

  protected override void Initialize(ISystemContext context, NodeState source)
  {
    if (source is MethodState methodState)
    {
      this.m_executable = methodState.m_executable;
      this.m_userExecutable = methodState.m_userExecutable;
    }
    base.Initialize(context, source);
  }

  public override object Clone() => this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    return this.CloneChildren((NodeState) Activator.CreateInstance(this.GetType(), (object) this.Parent));
  }

  public NodeId MethodDeclarationId
  {
    get => this.TypeDefinitionId;
    set => this.TypeDefinitionId = value;
  }

  public bool Executable
  {
    get => this.m_executable;
    set
    {
      if (this.m_executable != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_executable = value;
    }
  }

  public bool UserExecutable
  {
    get => this.m_userExecutable;
    set
    {
      if (this.m_userExecutable != value)
        this.ChangeMasks |= NodeStateChangeMasks.NonValue;
      this.m_userExecutable = value;
    }
  }

  protected override void Export(ISystemContext context, Node node)
  {
    base.Export(context, node);
    if (!(node is MethodNode methodNode))
      return;
    methodNode.Executable = this.Executable;
    methodNode.UserExecutable = this.UserExecutable;
  }

  public override void Save(ISystemContext context, XmlEncoder encoder)
  {
    base.Save(context, encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (this.m_executable)
      encoder.WriteBoolean("Executable", this.m_executable);
    if (this.m_userExecutable)
      encoder.WriteBoolean("UserExecutable", this.m_executable);
    encoder.PopNamespace();
  }

  public override void Update(ISystemContext context, XmlDecoder decoder)
  {
    base.Update(context, decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("Executable"))
      this.Executable = decoder.ReadBoolean("Executable");
    if (decoder.Peek("UserExecutable"))
      this.UserExecutable = decoder.ReadBoolean("UserExecutable");
    decoder.PopNamespace();
  }

  public override NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave = base.GetAttributesToSave(context);
    if (this.m_executable)
      attributesToSave |= NodeState.AttributesToSave.Executable;
    if (this.m_userExecutable)
      attributesToSave |= NodeState.AttributesToSave.UserExecutable;
    return attributesToSave;
  }

  public override void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    base.Save(context, encoder, attributesToSave);
    if ((attributesToSave & NodeState.AttributesToSave.Executable) != NodeState.AttributesToSave.None)
      encoder.WriteBoolean((string) null, this.m_executable);
    if ((attributesToSave & NodeState.AttributesToSave.UserExecutable) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteBoolean((string) null, this.m_userExecutable);
  }

  public override void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attibutesToLoad)
  {
    base.Update(context, decoder, attibutesToLoad);
    if ((attibutesToLoad & NodeState.AttributesToSave.Executable) != NodeState.AttributesToSave.None)
      this.m_executable = decoder.ReadBoolean((string) null);
    if ((attibutesToLoad & NodeState.AttributesToSave.UserExecutable) == NodeState.AttributesToSave.None)
      return;
    this.m_userExecutable = decoder.ReadBoolean((string) null);
  }

  protected override ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 21:
        bool executable = this.m_executable;
        if (this.OnReadExecutable != null)
          status = this.OnReadExecutable(context, (NodeState) this, ref executable);
        if (ServiceResult.IsGood(status))
          value = (object) executable;
        return status;
      case 22:
        bool userExecutable = this.m_userExecutable;
        if (this.OnReadUserExecutable != null)
          status = this.OnReadUserExecutable(context, (NodeState) this, ref userExecutable);
        if (ServiceResult.IsGood(status))
          value = (object) userExecutable;
        return status;
      default:
        return base.ReadNonValueAttribute(context, attributeId, ref value);
    }
  }

  protected override ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 21:
        bool? nullable1 = value as bool?;
        if (!nullable1.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.Executable) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        bool flag1 = nullable1.Value;
        if (this.OnWriteExecutable != null)
          status = this.OnWriteExecutable(context, (NodeState) this, ref flag1);
        if (ServiceResult.IsGood(status))
          this.Executable = flag1;
        return status;
      case 22:
        bool? nullable2 = value as bool?;
        if (!nullable2.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.UserExecutable) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        bool flag2 = nullable2.Value;
        if (this.OnWriteUserExecutable != null)
          status = this.OnWriteUserExecutable(context, (NodeState) this, ref flag2);
        if (ServiceResult.IsGood(status))
          this.UserExecutable = flag2;
        return status;
      default:
        return base.WriteNonValueAttribute(context, attributeId, value);
    }
  }

  public PropertyState<Argument[]> InputArguments
  {
    get => this.m_inputArguments;
    set
    {
      if (this.m_inputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_inputArguments = value;
    }
  }

  public PropertyState<Argument[]> OutputArguments
  {
    get => this.m_outputArguments;
    set
    {
      if (this.m_outputArguments != value)
        this.ChangeMasks |= NodeStateChangeMasks.Children;
      this.m_outputArguments = value;
    }
  }

  public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_inputArguments != null)
      children.Add((BaseInstanceState) this.m_inputArguments);
    if (this.m_outputArguments != null)
      children.Add((BaseInstanceState) this.m_outputArguments);
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
      case "InputArguments":
        if (createOrReplace && this.InputArguments == null)
          this.InputArguments = replacement != null ? (PropertyState<Argument[]>) replacement : new PropertyState<Argument[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.InputArguments;
        break;
      case "OutputArguments":
        if (createOrReplace && this.OutputArguments == null)
          this.OutputArguments = replacement != null ? (PropertyState<Argument[]>) replacement : new PropertyState<Argument[]>((NodeState) this);
        baseInstanceState = (BaseInstanceState) this.OutputArguments;
        break;
    }
    return baseInstanceState ?? base.FindChild(context, browseName, createOrReplace, replacement);
  }

  public virtual ServiceResult Call(
    ISystemContext context,
    NodeId objectId,
    IList<Variant> inputArguments,
    IList<ServiceResult> argumentErrors,
    IList<Variant> outputArguments)
  {
    object obj1 = (object) null;
    this.ReadNonValueAttribute(context, 21U, ref obj1);
    if (obj1 is bool flag1 && !flag1)
      return (ServiceResult) 2165374976U;
    object obj2 = (object) null;
    this.ReadNonValueAttribute(context, 22U, ref obj2);
    if (obj2 is bool flag2 && !flag2)
      return (ServiceResult) 2149515264U /*0x801F0000*/;
    List<object> inputArguments1 = new List<object>();
    int num = 0;
    if (this.InputArguments != null && this.InputArguments.Value != null)
      num = this.InputArguments.Value.Length;
    if (num > inputArguments.Count)
      return (ServiceResult) 2155216896U /*0x80760000*/;
    if (num < inputArguments.Count)
      return (ServiceResult) 2162491392U /*0x80E50000*/;
    bool flag3 = false;
    for (int index = 0; index < inputArguments.Count; ++index)
    {
      ServiceResult status = this.ValidateInputArgument(context, inputArguments[index], index);
      if (ServiceResult.IsBad(status))
        flag3 = true;
      inputArguments1.Add(inputArguments[index].Value);
      argumentErrors.Add(status);
    }
    if (flag3)
      return ServiceResult.Good;
    List<object> outputArguments1 = new List<object>();
    if (this.OutputArguments != null)
    {
      IList<Argument> objList = (IList<Argument>) this.OutputArguments.Value;
      if (objList != null && objList.Count > 0)
      {
        for (int index = 0; index < objList.Count; ++index)
          outputArguments1.Add(this.GetArgumentDefaultValue(context, objList[index]));
      }
    }
    ServiceResult status1;
    try
    {
      status1 = this.Call(context, objectId, (IList<object>) inputArguments1, (IList<object>) outputArguments1);
    }
    catch (Exception ex)
    {
      status1 = new ServiceResult(ex);
    }
    if (ServiceResult.IsGood(status1))
    {
      for (int index = 0; index < outputArguments1.Count; ++index)
        outputArguments.Add(new Variant(outputArguments1[index]));
    }
    return status1;
  }

  protected virtual ServiceResult Call(
    ISystemContext context,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    return this.Call(context, (NodeId) null, inputArguments, outputArguments);
  }

  protected virtual ServiceResult Call(
    ISystemContext context,
    NodeId objectId,
    IList<object> inputArguments,
    IList<object> outputArguments)
  {
    if (this.OnCallMethod2 != null)
      return this.OnCallMethod2(context, this, objectId, inputArguments, outputArguments);
    if (this.OnCallMethod != null)
      return this.OnCallMethod(context, this, inputArguments, outputArguments);
    return this.Executable && this.UserExecutable ? (ServiceResult) 2151677952U /*0x80400000*/ : (ServiceResult) 2149515264U /*0x801F0000*/;
  }

  protected ServiceResult ValidateInputArgument(
    ISystemContext context,
    Variant inputArgument,
    int index)
  {
    if (this.InputArguments == null)
      return (ServiceResult) 2158690304U /*0x80AB0000*/;
    IList<Argument> objList = (IList<Argument>) this.InputArguments.Value;
    if (objList == null || index < 0 || index >= objList.Count)
      return (ServiceResult) 2158690304U /*0x80AB0000*/;
    Argument obj = objList[index];
    return TypeInfo.IsInstanceOfDataType(inputArgument.Value, obj.DataType, obj.ValueRank, context.NamespaceUris, context.TypeTable) == null ? (ServiceResult) 2155085824U /*0x80740000*/ : ServiceResult.Good;
  }

  protected object GetArgumentDefaultValue(ISystemContext context, Argument outputArgument)
  {
    return TypeInfo.GetDefaultValue(outputArgument.DataType, outputArgument.ValueRank, context.TypeTable);
  }
}
