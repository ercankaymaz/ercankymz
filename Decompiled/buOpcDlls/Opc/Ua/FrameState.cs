using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class FrameState : BaseDataVariableState<Frame>
{
	private const string Constant_InitializationString = "//////////8VYIkKAgAAAAAACAAAAENvbnN0YW50AQBkSQAuAERkSQAAAAH/////AQH/////AAAAAA==";

	private const string BaseFrame_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAA=";

	private const string FixedBase_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAEQAAAEZyYW1lVHlwZUluc3RhbmNlAQBiSQEAYkliSQAAAQB9Sf////8BAf////8FAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAcUkALwEAVElxSQAAAQB5Sf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAY0kALwEAW0ljSQAAAQB7Sf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABDb25zdGFudAEAZEkALgBEZEkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=";

	private CartesianCoordinatesState m_cartesianCoordinates;

	private OrientationState m_orientation;

	private PropertyState<bool> m_constant;

	private BaseDataVariableState<NodeId> m_baseFrame;

	private PropertyState<bool> m_fixedBase;

	public CartesianCoordinatesState CartesianCoordinates
	{
		get
		{
			return m_cartesianCoordinates;
		}
		set
		{
			if (m_cartesianCoordinates != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_cartesianCoordinates = value;
		}
	}

	public OrientationState Orientation
	{
		get
		{
			return m_orientation;
		}
		set
		{
			if (m_orientation != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_orientation = value;
		}
	}

	public PropertyState<bool> Constant
	{
		get
		{
			return m_constant;
		}
		set
		{
			if (m_constant != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_constant = value;
		}
	}

	public BaseDataVariableState<NodeId> BaseFrame
	{
		get
		{
			return m_baseFrame;
		}
		set
		{
			if (m_baseFrame != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_baseFrame = value;
		}
	}

	public PropertyState<bool> FixedBase
	{
		get
		{
			return m_fixedBase;
		}
		set
		{
			if (m_fixedBase != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_fixedBase = value;
		}
	}

	public FrameState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18786u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18813u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAEQAAAEZyYW1lVHlwZUluc3RhbmNlAQBiSQEAYkliSQAAAQB9Sf////8BAf////8FAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAcUkALwEAVElxSQAAAQB5Sf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAY0kALwEAW0ljSQAAAQB7Sf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABDb25zdGFudAEAZEkALgBEZEkAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=");
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
		if (Constant != null)
		{
			Constant.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAENvbnN0YW50AQBkSQAuAERkSQAAAAH/////AQH/////AAAAAA==");
		}
		if (BaseFrame != null)
		{
			BaseFrame.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEJhc2VGcmFtZQEAZUkALwA/ZUkAAAAR/////wEB/////wAAAAA=");
		}
		if (FixedBase != null)
		{
			FixedBase.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEZpeGVkQmFzZQEAZkkALgBEZkkAAAAB/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_cartesianCoordinates != null)
		{
			children.Add(m_cartesianCoordinates);
		}
		if (m_orientation != null)
		{
			children.Add(m_orientation);
		}
		if (m_constant != null)
		{
			children.Add(m_constant);
		}
		if (m_baseFrame != null)
		{
			children.Add(m_baseFrame);
		}
		if (m_fixedBase != null)
		{
			children.Add(m_fixedBase);
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
		case "CartesianCoordinates":
			if (createOrReplace && CartesianCoordinates == null)
			{
				if (replacement == null)
				{
					CartesianCoordinates = new CartesianCoordinatesState(this);
				}
				else
				{
					CartesianCoordinates = (CartesianCoordinatesState)replacement;
				}
			}
			baseInstanceState = CartesianCoordinates;
			break;
		case "Orientation":
			if (createOrReplace && Orientation == null)
			{
				if (replacement == null)
				{
					Orientation = new OrientationState(this);
				}
				else
				{
					Orientation = (OrientationState)replacement;
				}
			}
			baseInstanceState = Orientation;
			break;
		case "Constant":
			if (createOrReplace && Constant == null)
			{
				if (replacement == null)
				{
					Constant = new PropertyState<bool>(this);
				}
				else
				{
					Constant = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = Constant;
			break;
		case "BaseFrame":
			if (createOrReplace && BaseFrame == null)
			{
				if (replacement == null)
				{
					BaseFrame = new BaseDataVariableState<NodeId>(this);
				}
				else
				{
					BaseFrame = (BaseDataVariableState<NodeId>)replacement;
				}
			}
			baseInstanceState = BaseFrame;
			break;
		case "FixedBase":
			if (createOrReplace && FixedBase == null)
			{
				if (replacement == null)
				{
					FixedBase = new PropertyState<bool>(this);
				}
				else
				{
					FixedBase = (PropertyState<bool>)replacement;
				}
			}
			baseInstanceState = FixedBase;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
