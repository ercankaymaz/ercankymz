using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditConditionShelvingEventState : AuditConditionEventState
{
	private const string ShelvingTime_InitializationString = "//////////8VYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0Q29uZGl0aW9uU2hlbHZpbmdFdmVudFR5cGVJbnN0YW5jZQEAVSsBAFUrVSsAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBWKwAuAERWKwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBXKwAuAERXKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAWCsALgBEWCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFkrAC4ARFkrAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBaKwAuAERaKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAWysALgBEWysAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAXSsALgBEXSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBeKwAuAEReKwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBfKwAuAERfKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAGArAC4ARGArAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAYSsALgBEYSsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAYisALgBEYisAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAYysALgBEYysAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBkKwAuAERkKwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGUrAC4ARGUrAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==";

	private PropertyState<double> m_shelvingTime;

	public PropertyState<double> ShelvingTime
	{
		get
		{
			return m_shelvingTime;
		}
		set
		{
			if (m_shelvingTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_shelvingTime = value;
		}
	}

	public AuditConditionShelvingEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(11093u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAJwAAAEF1ZGl0Q29uZGl0aW9uU2hlbHZpbmdFdmVudFR5cGVJbnN0YW5jZQEAVSsBAFUrVSsAAP////8QAAAAFWCJCgIAAAAAAAcAAABFdmVudElkAQBWKwAuAERWKwAAAA//////AQH/////AAAAABVgiQoCAAAAAAAJAAAARXZlbnRUeXBlAQBXKwAuAERXKwAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTm9kZQEAWCsALgBEWCsAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5hbWUBAFkrAC4ARFkrAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAQAAABUaW1lAQBaKwAuAERaKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABSZWNlaXZlVGltZQEAWysALgBEWysAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAATWVzc2FnZQEAXSsALgBEXSsAAAAV/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAFNldmVyaXR5AQBeKwAuAEReKwAAAAX/////AQH/////AAAAABVgiQoCAAAAAAAPAAAAQWN0aW9uVGltZVN0YW1wAQBfKwAuAERfKwAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABTdGF0dXMBAGArAC4ARGArAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXJ2ZXJJZAEAYSsALgBEYSsAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAAEgAAAENsaWVudEF1ZGl0RW50cnlJZAEAYisALgBEYisAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAENsaWVudFVzZXJJZAEAYysALgBEYysAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAACAAAAE1ldGhvZElkAQBkKwAuAERkKwAAABH/////AQH/////AAAAABdgiQoCAAAAAAAOAAAASW5wdXRBcmd1bWVudHMBAGUrAC4ARGUrAAAAGAEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==");
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
		if (ShelvingTime != null)
		{
			ShelvingTime.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAFNoZWx2aW5nVGltZQEATy4ALgBETy4AAAEAIgH/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_shelvingTime != null)
		{
			children.Add(m_shelvingTime);
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
		if (browseName.Name == "ShelvingTime")
		{
			if (createOrReplace && ShelvingTime == null)
			{
				if (replacement == null)
				{
					ShelvingTime = new PropertyState<double>(this);
				}
				else
				{
					ShelvingTime = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = ShelvingTime;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
