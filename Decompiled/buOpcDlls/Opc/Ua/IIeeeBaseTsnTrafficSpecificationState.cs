using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class IIeeeBaseTsnTrafficSpecificationState : BaseInterfaceState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAElJZWVlQmFzZVRzblRyYWZmaWNTcGVjaWZpY2F0aW9uVHlwZUluc3RhbmNlAQBzXgEAc15zXgAA/////wMAAAAVYIkKAgAAAAAAEQAAAE1heEludGVydmFsRnJhbWVzAQB0XgAvAD90XgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATWF4RnJhbWVTaXplAQB1XgAvAD91XgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAIAAAASW50ZXJ2YWwBAHZeAC8AP3ZeAAABACte/////wEB/////wAAAAA=";

	private BaseDataVariableState<ushort> m_maxIntervalFrames;

	private BaseDataVariableState<uint> m_maxFrameSize;

	private BaseDataVariableState<UnsignedRationalNumber> m_interval;

	public BaseDataVariableState<ushort> MaxIntervalFrames
	{
		get
		{
			return m_maxIntervalFrames;
		}
		set
		{
			if (m_maxIntervalFrames != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxIntervalFrames = value;
		}
	}

	public BaseDataVariableState<uint> MaxFrameSize
	{
		get
		{
			return m_maxFrameSize;
		}
		set
		{
			if (m_maxFrameSize != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maxFrameSize = value;
		}
	}

	public BaseDataVariableState<UnsignedRationalNumber> Interval
	{
		get
		{
			return m_interval;
		}
		set
		{
			if (m_interval != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_interval = value;
		}
	}

	public IIeeeBaseTsnTrafficSpecificationState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(24179u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALAAAAElJZWVlQmFzZVRzblRyYWZmaWNTcGVjaWZpY2F0aW9uVHlwZUluc3RhbmNlAQBzXgEAc15zXgAA/////wMAAAAVYIkKAgAAAAAAEQAAAE1heEludGVydmFsRnJhbWVzAQB0XgAvAD90XgAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAMAAAATWF4RnJhbWVTaXplAQB1XgAvAD91XgAAAAf/////AQH/////AAAAABVgiQoCAAAAAAAIAAAASW50ZXJ2YWwBAHZeAC8AP3ZeAAABACte/////wEB/////wAAAAA=");
		InitializeOptionalChildren(context);
	}

	protected override void Initialize(ISystemContext context, NodeState source)
	{
		InitializeOptionalChildren(context);
		base.Initialize(context, source);
	}

	protected override void InitializeOptionalChildren(ISystemContext context)
	{
		base.InitializeOptionalChildren(context);
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_maxIntervalFrames != null)
		{
			children.Add(m_maxIntervalFrames);
		}
		if (m_maxFrameSize != null)
		{
			children.Add(m_maxFrameSize);
		}
		if (m_interval != null)
		{
			children.Add(m_interval);
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
		switch (browseName.Name)
		{
		case "MaxIntervalFrames":
			if (createOrReplace && MaxIntervalFrames == null)
			{
				if (replacement == null)
				{
					MaxIntervalFrames = new BaseDataVariableState<ushort>(this);
				}
				else
				{
					MaxIntervalFrames = (BaseDataVariableState<ushort>)replacement;
				}
			}
			baseInstanceState = MaxIntervalFrames;
			break;
		case "MaxFrameSize":
			if (createOrReplace && MaxFrameSize == null)
			{
				if (replacement == null)
				{
					MaxFrameSize = new BaseDataVariableState<uint>(this);
				}
				else
				{
					MaxFrameSize = (BaseDataVariableState<uint>)replacement;
				}
			}
			baseInstanceState = MaxFrameSize;
			break;
		case "Interval":
			if (createOrReplace && Interval == null)
			{
				if (replacement == null)
				{
					Interval = new BaseDataVariableState<UnsignedRationalNumber>(this);
				}
				else
				{
					Interval = (BaseDataVariableState<UnsignedRationalNumber>)replacement;
				}
			}
			baseInstanceState = Interval;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
