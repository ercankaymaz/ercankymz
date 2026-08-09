using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class TransitionVariableState : BaseDataVariableState<LocalizedText>
{
	private const string Name_InitializationString = "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMwKAC4ARMwKAAAAFP////8BAf////8AAAAA";

	private const string Number_InitializationString = "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAA=";

	private const string TransitionTime_InitializationString = "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAA";

	private const string EffectiveTransitionTime_InitializationString = "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQDALAAuAETALAAAAQAmAf////8BAf////8AAAAA";

	private const string InitializationString = "//////////8VYIkCAgAAAAAAHgAAAFRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAygoBAMoKygoAAAAV/////wEB/////wUAAAAVYIkKAgAAAAAAAgAAAElkAQDLCgAuAETLCgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAEAAAATmFtZQEAzAoALgBEzAoAAAAU/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAwCwALgBEwCwAAAEAJgH/////AQH/////AAAAAA==";

	private PropertyState m_id;

	private PropertyState<QualifiedName> m_name;

	private PropertyState<uint> m_number;

	private PropertyState<DateTime> m_transitionTime;

	private PropertyState<DateTime> m_effectiveTransitionTime;

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

	public PropertyState<DateTime> TransitionTime
	{
		get
		{
			return m_transitionTime;
		}
		set
		{
			if (m_transitionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_transitionTime = value;
		}
	}

	public PropertyState<DateTime> EffectiveTransitionTime
	{
		get
		{
			return m_effectiveTransitionTime;
		}
		set
		{
			if (m_effectiveTransitionTime != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_effectiveTransitionTime = value;
		}
	}

	public TransitionVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2762u, "http://opcfoundation.org/UA/", namespaceUris);
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
		Initialize(context, "//////////8VYIkCAgAAAAAAHgAAAFRyYW5zaXRpb25WYXJpYWJsZVR5cGVJbnN0YW5jZQEAygoBAMoKygoAAAAV/////wEB/////wUAAAAVYIkKAgAAAAAAAgAAAElkAQDLCgAuAETLCgAAABj/////AQH/////AAAAABVgiQoCAAAAAAAEAAAATmFtZQEAzAoALgBEzAoAAAAU/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAABcAAABFZmZlY3RpdmVUcmFuc2l0aW9uVGltZQEAwCwALgBEwCwAAAEAJgH/////AQH/////AAAAAA==");
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
			Name.Initialize(context, "//////////8VYIkKAgAAAAAABAAAAE5hbWUBAMwKAC4ARMwKAAAAFP////8BAf////8AAAAA");
		}
		if (Number != null)
		{
			Number.Initialize(context, "//////////8VYIkKAgAAAAAABgAAAE51bWJlcgEAzQoALgBEzQoAAAAH/////wEB/////wAAAAA=");
		}
		if (TransitionTime != null)
		{
			TransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQDOCgAuAETOCgAAAQAmAf////8BAf////8AAAAA");
		}
		if (EffectiveTransitionTime != null)
		{
			EffectiveTransitionTime.Initialize(context, "//////////8VYIkKAgAAAAAAFwAAAEVmZmVjdGl2ZVRyYW5zaXRpb25UaW1lAQDALAAuAETALAAAAQAmAf////8BAf////8AAAAA");
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
		if (m_transitionTime != null)
		{
			children.Add(m_transitionTime);
		}
		if (m_effectiveTransitionTime != null)
		{
			children.Add(m_effectiveTransitionTime);
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
		case "TransitionTime":
			if (createOrReplace && TransitionTime == null)
			{
				if (replacement == null)
				{
					TransitionTime = new PropertyState<DateTime>(this);
				}
				else
				{
					TransitionTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = TransitionTime;
			break;
		case "EffectiveTransitionTime":
			if (createOrReplace && EffectiveTransitionTime == null)
			{
				if (replacement == null)
				{
					EffectiveTransitionTime = new PropertyState<DateTime>(this);
				}
				else
				{
					EffectiveTransitionTime = (PropertyState<DateTime>)replacement;
				}
			}
			baseInstanceState = EffectiveTransitionTime;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
