using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class PubSubTransportLimitsExceedEventState : PubSubStatusEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAALAAAAFB1YlN1YlRyYW5zcG9ydExpbWl0c0V4Y2VlZEV2ZW50VHlwZUluc3RhbmNlAQC8PAEAvDy8PAAA/////w0AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAL08AC4ARL08AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAL48AC4ARL48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC/PAAuAES/PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAwDwALgBEwDwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAME8AC4ARME8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDCPAAuAETCPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDEPAAuAETEPAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMU8AC4ARMU8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBAMY8AC4ARMY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQDHPAAuAETHPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMg8AC4ARMg8AAABADc5/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAEFjdHVhbAEAyTwALgBEyTwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1heGltdW0BAMo8AC4ARMo8AAAAB/////8BAf////8AAAAA";

	private PropertyState<uint> m_actual;

	private PropertyState<uint> m_maximum;

	public PropertyState<uint> Actual
	{
		get
		{
			return m_actual;
		}
		set
		{
			if (m_actual != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_actual = value;
		}
	}

	public PropertyState<uint> Maximum
	{
		get
		{
			return m_maximum;
		}
		set
		{
			if (m_maximum != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_maximum = value;
		}
	}

	public PubSubTransportLimitsExceedEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(15548u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAALAAAAFB1YlN1YlRyYW5zcG9ydExpbWl0c0V4Y2VlZEV2ZW50VHlwZUluc3RhbmNlAQC8PAEAvDy8PAAA/////w0AAAAVYIkKAgAAAAAABwAAAEV2ZW50SWQBAL08AC4ARL08AAAAD/////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABFdmVudFR5cGUBAL48AC4ARL48AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOb2RlAQC/PAAuAES/PAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAKAAAAU291cmNlTmFtZQEAwDwALgBEwDwAAAAM/////wEB/////wAAAAAVYIkKAgAAAAAABAAAAFRpbWUBAME8AC4ARME8AAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAACwAAAFJlY2VpdmVUaW1lAQDCPAAuAETCPAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABNZXNzYWdlAQDEPAAuAETEPAAAABX/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2V2ZXJpdHkBAMU8AC4ARMU8AAAABf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDb25uZWN0aW9uSWQBAMY8AC4ARMY8AAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAcAAABHcm91cElkAQDHPAAuAETHPAAAABH/////AQH/////AAAAABVgiQoCAAAAAAAFAAAAU3RhdGUBAMg8AC4ARMg8AAABADc5/////wEB/////wAAAAAVYIkKAgAAAAAABgAAAEFjdHVhbAEAyTwALgBEyTwAAAAH/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1heGltdW0BAMo8AC4ARMo8AAAAB/////8BAf////8AAAAA");
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
		if (m_actual != null)
		{
			children.Add(m_actual);
		}
		if (m_maximum != null)
		{
			children.Add(m_maximum);
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
		if (!(name == "Actual"))
		{
			if (name == "Maximum")
			{
				if (createOrReplace && Maximum == null)
				{
					if (replacement == null)
					{
						Maximum = new PropertyState<uint>(this);
					}
					else
					{
						Maximum = (PropertyState<uint>)replacement;
					}
				}
				baseInstanceState = Maximum;
			}
		}
		else
		{
			if (createOrReplace && Actual == null)
			{
				if (replacement == null)
				{
					Actual = new PropertyState<uint>(this);
				}
				else
				{
					Actual = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = Actual;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
