using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class ProgressEventState : BaseEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAGQAAAFByb2dyZXNzRXZlbnRUeXBlSW5zdGFuY2UBAKwsAQCsLKwsAAD/////CgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEArSwALgBErSwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAriwALgBEriwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAK8sAC4ARK8sAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCwLAAuAESwLAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAsSwALgBEsSwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALIsAC4ARLIsAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALQsAC4ARLQsAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAtSwALgBEtSwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbnRleHQBANYwAC4ARNYwAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcm9ncmVzcwEA1zAALgBE1zAAAAAF/////wEB/////wAAAAA=";

	private PropertyState m_context;

	private PropertyState<ushort> m_progress;

	public PropertyState Context
	{
		get
		{
			return m_context;
		}
		set
		{
			if (m_context != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_context = value;
		}
	}

	public PropertyState<ushort> Progress
	{
		get
		{
			return m_progress;
		}
		set
		{
			if (m_progress != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_progress = value;
		}
	}

	public ProgressEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11436u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAGQAAAFByb2dyZXNzRXZlbnRUeXBlSW5zdGFuY2UBAKwsAQCsLKwsAAD/////CgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEArSwALgBErSwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAriwALgBEriwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAK8sAC4ARK8sAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQCwLAAuAESwLAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAsSwALgBEsSwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALIsAC4ARLIsAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALQsAC4ARLQsAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAtSwALgBEtSwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAENvbnRleHQBANYwAC4ARNYwAAAAGP////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABQcm9ncmVzcwEA1zAALgBE1zAAAAAF/////wEB/////wAAAAA=");
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
		if (m_context != null)
		{
			children.Add(m_context);
		}
		if (m_progress != null)
		{
			children.Add(m_progress);
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
		if (!(name == "Context"))
		{
			if (name == "Progress")
			{
				if (createOrReplace && Progress == null)
				{
					if (replacement == null)
					{
						Progress = new PropertyState<ushort>(this);
					}
					else
					{
						Progress = (PropertyState<ushort>)replacement;
					}
				}
				baseInstanceState = Progress;
			}
		}
		else
		{
			if (createOrReplace && Context == null)
			{
				if (replacement == null)
				{
					Context = new PropertyState(this);
				}
				else
				{
					Context = (PropertyState)replacement;
				}
			}
			baseInstanceState = Context;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
