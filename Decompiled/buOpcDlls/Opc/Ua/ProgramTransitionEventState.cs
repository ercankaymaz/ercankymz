using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgramTransitionEventState : TransitionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAFByb2dyYW1UcmFuc2l0aW9uRXZlbnRUeXBlSW5zdGFuY2UBAEoJAQBKCUoJAAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAxg4ALgBExg4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAxw4ALgBExw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAMgOAC4ARMgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDJDgAuAETJDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAyg4ALgBEyg4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAMsOAC4ARMsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAM0OAC4ARM0OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAzg4ALgBEzg4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRyYW5zaXRpb24BANkOAC8BAMoK2Q4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDaDgAuAETaDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARnJvbVN0YXRlAQDPDgAvAQDDCs8OAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA0A4ALgBE0A4AAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFRvU3RhdGUBANQOAC8BAMMK1A4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDVDgAuAETVDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAASAAAASW50ZXJtZWRpYXRlUmVzdWx0AQBLCQAvAD9LCQAAABj/////AQH/////AAAAAA==";

	private BaseDataVariableState m_intermediateResult;

	public BaseDataVariableState IntermediateResult
	{
		get
		{
			return m_intermediateResult;
		}
		set
		{
			if (m_intermediateResult != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_intermediateResult = value;
		}
	}

	public ProgramTransitionEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2378u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAFByb2dyYW1UcmFuc2l0aW9uRXZlbnRUeXBlSW5zdGFuY2UBAEoJAQBKCUoJAAD/////DAAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAxg4ALgBExg4AAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAxw4ALgBExw4AAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAMgOAC4ARMgOAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDJDgAuAETJDgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAyg4ALgBEyg4AAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAMsOAC4ARMsOAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAM0OAC4ARM0OAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAzg4ALgBEzg4AAAAF/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFRyYW5zaXRpb24BANkOAC8BAMoK2Q4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDaDgAuAETaDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAJAAAARnJvbVN0YXRlAQDPDgAvAQDDCs8OAAAAFf////8BAf////8BAAAAFWCJCgIAAAAAAAIAAABJZAEA0A4ALgBE0A4AAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAFRvU3RhdGUBANQOAC8BAMMK1A4AAAAV/////wEB/////wEAAAAVYIkKAgAAAAAAAgAAAElkAQDVDgAuAETVDgAAABj/////AQH/////AAAAABVgiQoCAAAAAAASAAAASW50ZXJtZWRpYXRlUmVzdWx0AQBLCQAvAD9LCQAAABj/////AQH/////AAAAAA==");
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
		if (m_intermediateResult != null)
		{
			children.Add(m_intermediateResult);
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
		if (browseName.Name == "IntermediateResult")
		{
			if (createOrReplace && IntermediateResult == null)
			{
				if (replacement == null)
				{
					IntermediateResult = new BaseDataVariableState(this);
				}
				else
				{
					IntermediateResult = (BaseDataVariableState)replacement;
				}
			}
			baseInstanceState = IntermediateResult;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
