using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ThreeDFrameState : FrameState
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAFwAAAFRocmVlREZyYW1lVHlwZUluc3RhbmNlAQBnSQEAZ0lnSQAAAQB+Sf////8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAbEkALwEAVklsSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBuSQAvAD9uSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAb0kALwA/b0kAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAHBJAC8AP3BJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAaEkALwEAXUloSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQCCSgAvAD+CSgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAg0oALwA/g0oAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAIRKAC8AP4RKAAAAC/////8BAf////8AAAAA";

	public new ThreeDCartesianCoordinatesState CartesianCoordinates
	{
		get
		{
			return (ThreeDCartesianCoordinatesState)base.CartesianCoordinates;
		}
		set
		{
			base.CartesianCoordinates = value;
		}
	}

	public new ThreeDOrientationState Orientation
	{
		get
		{
			return (ThreeDOrientationState)base.Orientation;
		}
		set
		{
			base.Orientation = value;
		}
	}

	public ThreeDFrameState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18791u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(18814u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAFwAAAFRocmVlREZyYW1lVHlwZUluc3RhbmNlAQBnSQEAZ0lnSQAAAQB+Sf////8BAf////8CAAAAFWCJCgIAAAAAABQAAABDYXJ0ZXNpYW5Db29yZGluYXRlcwEAbEkALwEAVklsSQAAAQB6Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABYAQBuSQAvAD9uSQAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAWQEAb0kALwA/b0kAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAFoBAHBJAC8AP3BJAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABPcmllbnRhdGlvbgEAaEkALwEAXUloSQAAAQB8Sf////8BAf////8DAAAAFWCJCgIAAAAAAAEAAABBAQCCSgAvAD+CSgAAAAv/////AQH/////AAAAABVgiQoCAAAAAAABAAAAQgEAg0oALwA/g0oAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAAQAAAEMBAIRKAC8AP4RKAAAAC/////8BAf////8AAAAA");
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
		if (!(name == "CartesianCoordinates"))
		{
			if (name == "Orientation")
			{
				if (createOrReplace && Orientation == null)
				{
					if (replacement == null)
					{
						Orientation = new ThreeDOrientationState(this);
					}
					else
					{
						Orientation = (ThreeDOrientationState)replacement;
					}
				}
				baseInstanceState = Orientation;
			}
		}
		else
		{
			if (createOrReplace && CartesianCoordinates == null)
			{
				if (replacement == null)
				{
					CartesianCoordinates = new ThreeDCartesianCoordinatesState(this);
				}
				else
				{
					CartesianCoordinates = (ThreeDCartesianCoordinatesState)replacement;
				}
			}
			baseInstanceState = CartesianCoordinates;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
