using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

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

	public NodeId MethodDeclarationId
	{
		get
		{
			return base.TypeDefinitionId;
		}
		set
		{
			base.TypeDefinitionId = value;
		}
	}

	public bool Executable
	{
		get
		{
			return m_executable;
		}
		set
		{
			if (m_executable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_executable = value;
		}
	}

	public bool UserExecutable
	{
		get
		{
			return m_userExecutable;
		}
		set
		{
			if (m_userExecutable != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_userExecutable = value;
		}
	}

	public PropertyState<Argument[]> InputArguments
	{
		get
		{
			return m_inputArguments;
		}
		set
		{
			if (m_inputArguments != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_inputArguments = value;
		}
	}

	public PropertyState<Argument[]> OutputArguments
	{
		get
		{
			return m_outputArguments;
		}
		set
		{
			if (m_outputArguments != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_outputArguments = value;
		}
	}

	public MethodState(NodeState parent)
		: base(NodeClass.Method, parent)
	{
		m_executable = true;
		m_userExecutable = true;
	}

	public static NodeState Construct(NodeState parent)
	{
		return new MethodState(parent);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Executable = true;
		UserExecutable = true;
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		if (source is MethodState methodState)
		{
			m_executable = methodState.m_executable;
			m_userExecutable = methodState.m_userExecutable;
		}
		base.Initialize(context, source);
	}

	public override object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		MethodState clone = (MethodState)Activator.CreateInstance(GetType(), base.Parent);
		return CloneChildren(clone);
	}

	protected override void Export(ISystemContext context, Node node)
	{
		base.Export(context, node);
		if (node is MethodNode methodNode)
		{
			methodNode.Executable = Executable;
			methodNode.UserExecutable = UserExecutable;
		}
	}

	public override void Save(ISystemContext context, XmlEncoder encoder)
	{
		base.Save(context, encoder);
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (m_executable)
		{
			encoder.WriteBoolean("Executable", m_executable);
		}
		if (m_userExecutable)
		{
			encoder.WriteBoolean("UserExecutable", m_executable);
		}
		encoder.PopNamespace();
	}

	public override void Update(ISystemContext context, XmlDecoder decoder)
	{
		base.Update(context, decoder);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("Executable"))
		{
			Executable = decoder.ReadBoolean("Executable");
		}
		if (decoder.Peek("UserExecutable"))
		{
			UserExecutable = decoder.ReadBoolean("UserExecutable");
		}
		decoder.PopNamespace();
	}

	public override AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = base.GetAttributesToSave(context);
		if (m_executable)
		{
			attributesToSave |= AttributesToSave.Executable;
		}
		if (m_userExecutable)
		{
			attributesToSave |= AttributesToSave.UserExecutable;
		}
		return attributesToSave;
	}

	public override void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		base.Save(context, encoder, attributesToSave);
		if ((attributesToSave & AttributesToSave.Executable) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_executable);
		}
		if ((attributesToSave & AttributesToSave.UserExecutable) != AttributesToSave.None)
		{
			encoder.WriteBoolean(null, m_userExecutable);
		}
	}

	public override void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attibutesToLoad)
	{
		base.Update(context, decoder, attibutesToLoad);
		if ((attibutesToLoad & AttributesToSave.Executable) != AttributesToSave.None)
		{
			m_executable = decoder.ReadBoolean(null);
		}
		if ((attibutesToLoad & AttributesToSave.UserExecutable) != AttributesToSave.None)
		{
			m_userExecutable = decoder.ReadBoolean(null);
		}
	}

	protected override ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 21u:
		{
			bool value3 = m_executable;
			if (OnReadExecutable != null)
			{
				serviceResult = OnReadExecutable(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value3;
			}
			return serviceResult;
		}
		case 22u:
		{
			bool value2 = m_userExecutable;
			if (OnReadUserExecutable != null)
			{
				serviceResult = OnReadUserExecutable(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value2;
			}
			return serviceResult;
		}
		default:
			return base.ReadNonValueAttribute(context, attributeId, ref value);
		}
	}

	protected override ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 21u:
		{
			bool? flag2 = value as bool?;
			if (!flag2.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.Executable) == 0)
			{
				return 2151350272u;
			}
			bool value3 = flag2.Value;
			if (OnWriteExecutable != null)
			{
				serviceResult = OnWriteExecutable(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				Executable = value3;
			}
			return serviceResult;
		}
		case 22u:
		{
			bool? flag = value as bool?;
			if (!flag.HasValue)
			{
				return 2155085824u;
			}
			if ((base.WriteMask & AttributeWriteMask.UserExecutable) == 0)
			{
				return 2151350272u;
			}
			bool value2 = flag.Value;
			if (OnWriteUserExecutable != null)
			{
				serviceResult = OnWriteUserExecutable(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				UserExecutable = value2;
			}
			return serviceResult;
		}
		default:
			return base.WriteNonValueAttribute(context, attributeId, value);
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_inputArguments != null)
		{
			children.Add(m_inputArguments);
		}
		if (m_outputArguments != null)
		{
			children.Add(m_outputArguments);
		}
		base.GetChildren(context, children);
	}

	protected override BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		BaseInstanceState baseInstanceState = null;
		string name = browseName.Name;
		if (!(name == "InputArguments"))
		{
			if (name == "OutputArguments")
			{
				if (createOrReplace && OutputArguments == null)
				{
					if (replacement == null)
					{
						OutputArguments = new PropertyState<Argument[]>(this);
					}
					else
					{
						OutputArguments = (PropertyState<Argument[]>)replacement;
					}
				}
				baseInstanceState = OutputArguments;
			}
		}
		else
		{
			if (createOrReplace && InputArguments == null)
			{
				if (replacement == null)
				{
					InputArguments = new PropertyState<Argument[]>(this);
				}
				else
				{
					InputArguments = (PropertyState<Argument[]>)replacement;
				}
			}
			baseInstanceState = InputArguments;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	public virtual ServiceResult Call(ISystemContext context, NodeId objectId, IList<Variant> inputArguments, IList<ServiceResult> argumentErrors, IList<Variant> outputArguments)
	{
		object value = null;
		ReadNonValueAttribute(context, 21u, ref value);
		if (value is bool && !(bool)value)
		{
			return 2165374976u;
		}
		object value2 = null;
		ReadNonValueAttribute(context, 22u, ref value2);
		if (value2 is bool && !(bool)value2)
		{
			return 2149515264u;
		}
		List<object> list = new List<object>();
		int num = 0;
		if (InputArguments != null && InputArguments.Value != null)
		{
			num = InputArguments.Value.Length;
		}
		if (num > inputArguments.Count)
		{
			return 2155216896u;
		}
		if (num < inputArguments.Count)
		{
			return 2162491392u;
		}
		bool flag = false;
		for (int i = 0; i < inputArguments.Count; i++)
		{
			ServiceResult serviceResult = ValidateInputArgument(context, inputArguments[i], i);
			if (ServiceResult.IsBad(serviceResult))
			{
				flag = true;
			}
			list.Add(inputArguments[i].Value);
			argumentErrors.Add(serviceResult);
		}
		if (flag)
		{
			return ServiceResult.Good;
		}
		List<object> list2 = new List<object>();
		if (OutputArguments != null)
		{
			IList<Argument> value3 = OutputArguments.Value;
			if (value3 != null && value3.Count > 0)
			{
				for (int j = 0; j < value3.Count; j++)
				{
					list2.Add(GetArgumentDefaultValue(context, value3[j]));
				}
			}
		}
		ServiceResult serviceResult2 = null;
		try
		{
			serviceResult2 = Call(context, objectId, list, list2);
		}
		catch (Exception exception)
		{
			serviceResult2 = new ServiceResult(exception);
		}
		if (ServiceResult.IsGood(serviceResult2))
		{
			for (int k = 0; k < list2.Count; k++)
			{
				outputArguments.Add(new Variant(list2[k]));
			}
		}
		return serviceResult2;
	}

	protected virtual ServiceResult Call(ISystemContext context, IList<object> inputArguments, IList<object> outputArguments)
	{
		return Call(context, null, inputArguments, outputArguments);
	}

	protected virtual ServiceResult Call(ISystemContext context, NodeId objectId, IList<object> inputArguments, IList<object> outputArguments)
	{
		if (OnCallMethod2 != null)
		{
			return OnCallMethod2(context, this, objectId, inputArguments, outputArguments);
		}
		if (OnCallMethod != null)
		{
			return OnCallMethod(context, this, inputArguments, outputArguments);
		}
		if (Executable && UserExecutable)
		{
			return 2151677952u;
		}
		return 2149515264u;
	}

	protected ServiceResult ValidateInputArgument(ISystemContext context, Variant inputArgument, int index)
	{
		if (InputArguments == null)
		{
			return 2158690304u;
		}
		IList<Argument> value = InputArguments.Value;
		if (value == null || index < 0 || index >= value.Count)
		{
			return 2158690304u;
		}
		Argument argument = value[index];
		if (TypeInfo.IsInstanceOfDataType(inputArgument.Value, argument.DataType, argument.ValueRank, context.NamespaceUris, context.TypeTable) == null)
		{
			return 2155085824u;
		}
		return ServiceResult.Good;
	}

	protected object GetArgumentDefaultValue(ISystemContext context, Argument outputArgument)
	{
		return TypeInfo.GetDefaultValue(outputArgument.DataType, outputArgument.ValueRank, context.TypeTable);
	}
}
