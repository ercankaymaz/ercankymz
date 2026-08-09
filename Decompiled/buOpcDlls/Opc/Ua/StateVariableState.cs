using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class StateVariableState : BaseDataVariableState<LocalizedText>
{
	private const string Name_InitializationString = "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAA";

	private const string Number_InitializationString = "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAxgoALgBExgoAAAAH/////wEB/////wAAAAA=";

	private const string EffectiveDisplayName_InitializationString = "//////////8VYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQDHCgAuAETHCgAAABX/////AQH/////AAAAAA==";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAGQAAAFN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMMKAQDDCsMKAAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEAxAoALgBExAoAAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAMYKAC4ARMYKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAxwoALgBExwoAAAAV/////wEB/////wAAAAA=";

	private PropertyState m_id;

	private PropertyState<QualifiedName> m_name;

	private PropertyState<uint> m_number;

	private PropertyState<LocalizedText> m_effectiveDisplayName;

	public PropertyState Id
	{
		get
		{
			return m_id;
		}
		set
		{
			if (m_id != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_id = value;
		}
	}

	public PropertyState<QualifiedName> Name
	{
		get
		{
			return m_name;
		}
		set
		{
			if (m_name != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_name = value;
		}
	}

	public PropertyState<uint> Number
	{
		get
		{
			return m_number;
		}
		set
		{
			if (m_number != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_number = value;
		}
	}

	public PropertyState<LocalizedText> EffectiveDisplayName
	{
		get
		{
			return m_effectiveDisplayName;
		}
		set
		{
			if (m_effectiveDisplayName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_effectiveDisplayName = value;
		}
	}

	public StateVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2755u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(21u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAGQAAAFN0YXRlVmFyaWFibGVUeXBlSW5zdGFuY2UBAMMKAQDDCsMKAAAAFf////8BAf////8EAAAAFWCJCgIAAAAAAAIAAABJZAEAxAoALgBExAoAAAAY/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABOdW1iZXIBAMYKAC4ARMYKAAAAB/////8BAf////8AAAAAFWCJCgIAAAAAABQAAABFZmZlY3RpdmVEaXNwbGF5TmFtZQEAxwoALgBExwoAAAAV/////wEB/////wAAAAA=");
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
		if (Name != null)
		{
			Name.Initialize(context, "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMUKAC4ARMUKAAAAFP////8BAf////8AAAAA");
		}
		if (Number != null)
		{
			Number.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAxgoALgBExgoAAAAH/////wEB/////wAAAAA=");
		}
		if (EffectiveDisplayName != null)
		{
			EffectiveDisplayName.Initialize(context, "//////////8VYIkKAgAAAAAAFAAAAEVmZmVjdGl2ZURpc3BsYXlOYW1lAQDHCgAuAETHCgAAABX/////AQH/////AAAAAA==");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_id != null)
		{
			children.Add(m_id);
		}
		if (m_name != null)
		{
			children.Add(m_name);
		}
		if (m_number != null)
		{
			children.Add(m_number);
		}
		if (m_effectiveDisplayName != null)
		{
			children.Add(m_effectiveDisplayName);
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
		case "Id":
			if (createOrReplace && Id == null)
			{
				if (replacement == null)
				{
					Id = new PropertyState(this);
				}
				else
				{
					Id = (PropertyState)replacement;
				}
			}
			baseInstanceState = Id;
			break;
		case "Name":
			if (createOrReplace && Name == null)
			{
				if (replacement == null)
				{
					Name = new PropertyState<QualifiedName>(this);
				}
				else
				{
					Name = (PropertyState<QualifiedName>)replacement;
				}
			}
			baseInstanceState = Name;
			break;
		case "Number":
			if (createOrReplace && Number == null)
			{
				if (replacement == null)
				{
					Number = new PropertyState<uint>(this);
				}
				else
				{
					Number = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = Number;
			break;
		case "EffectiveDisplayName":
			if (createOrReplace && EffectiveDisplayName == null)
			{
				if (replacement == null)
				{
					EffectiveDisplayName = new PropertyState<LocalizedText>(this);
				}
				else
				{
					EffectiveDisplayName = (PropertyState<LocalizedText>)replacement;
				}
			}
			baseInstanceState = EffectiveDisplayName;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
