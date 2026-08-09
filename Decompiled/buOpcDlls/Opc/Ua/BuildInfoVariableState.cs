using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class BuildInfoVariableState : BaseDataVariableState<BuildInfo>
{
	private const string InitializationString = "//////////8VYIkCAgAAAAAAFQAAAEJ1aWxkSW5mb1R5cGVJbnN0YW5jZQEA6wsBAOsL6wsAAAEAUgH/////AQH/////BgAAABVwiQoCAAAAAAAKAAAAUHJvZHVjdFVyaQEA7AsALwA/7AsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAQAAAATWFudWZhY3R1cmVyTmFtZQEA7QsALwA/7QsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAUHJvZHVjdE5hbWUBAO4LAC8AP+4LAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAADwAAAFNvZnR3YXJlVmVyc2lvbgEA7wsALwA/7wsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAQnVpbGROdW1iZXIBAPALAC8AP/ALAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACQAAAEJ1aWxkRGF0ZQEA8QsALwA/8QsAAAEAJgH/////AQEAAAAAAECPQP////8AAAAA";

	private BaseDataVariableState<string> m_productUri;

	private BaseDataVariableState<string> m_manufacturerName;

	private BaseDataVariableState<string> m_productName;

	private BaseDataVariableState<string> m_softwareVersion;

	private BaseDataVariableState<string> m_buildNumber;

	private BaseDataVariableState<DateTime> m_buildDate;

	public BaseDataVariableState<string> ProductUri
	{
		get
		{
			return m_productUri;
		}
		set
		{
			if (m_productUri != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_productUri = value;
		}
	}

	public BaseDataVariableState<string> ManufacturerName
	{
		get
		{
			return m_manufacturerName;
		}
		set
		{
			if (m_manufacturerName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_manufacturerName = value;
		}
	}

	public BaseDataVariableState<string> ProductName
	{
		get
		{
			return m_productName;
		}
		set
		{
			if (m_productName != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_productName = value;
		}
	}

	public BaseDataVariableState<string> SoftwareVersion
	{
		get
		{
			return m_softwareVersion;
		}
		set
		{
			if (m_softwareVersion != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_softwareVersion = value;
		}
	}

	public BaseDataVariableState<string> BuildNumber
	{
		get
		{
			return m_buildNumber;
		}
		set
		{
			if (m_buildNumber != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_buildNumber = value;
		}
	}

	public BaseDataVariableState<DateTime> BuildDate
	{
		get
		{
			return m_buildDate;
		}
		set
		{
			if (m_buildDate != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_buildDate = value;
		}
	}

	public BuildInfoVariableState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(3051u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override NodeId GetDefaultDataTypeId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(338u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override int GetDefaultValueRank()
	{
		return -1;
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8VYIkCAgAAAAAAFQAAAEJ1aWxkSW5mb1R5cGVJbnN0YW5jZQEA6wsBAOsL6wsAAAEAUgH/////AQH/////BgAAABVwiQoCAAAAAAAKAAAAUHJvZHVjdFVyaQEA7AsALwA/7AsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAAQAAAATWFudWZhY3R1cmVyTmFtZQEA7QsALwA/7QsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAUHJvZHVjdE5hbWUBAO4LAC8AP+4LAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAADwAAAFNvZnR3YXJlVmVyc2lvbgEA7wsALwA/7wsAAAAM/////wEBAAAAAABAj0D/////AAAAABVwiQoCAAAAAAALAAAAQnVpbGROdW1iZXIBAPALAC8AP/ALAAAADP////8BAQAAAAAAQI9A/////wAAAAAVcIkKAgAAAAAACQAAAEJ1aWxkRGF0ZQEA8QsALwA/8QsAAAEAJgH/////AQEAAAAAAECPQP////8AAAAA");
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
		if (m_productUri != null)
		{
			children.Add(m_productUri);
		}
		if (m_manufacturerName != null)
		{
			children.Add(m_manufacturerName);
		}
		if (m_productName != null)
		{
			children.Add(m_productName);
		}
		if (m_softwareVersion != null)
		{
			children.Add(m_softwareVersion);
		}
		if (m_buildNumber != null)
		{
			children.Add(m_buildNumber);
		}
		if (m_buildDate != null)
		{
			children.Add(m_buildDate);
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
		case "ProductUri":
			if (createOrReplace && ProductUri == null)
			{
				if (replacement == null)
				{
					ProductUri = new BaseDataVariableState<string>(this);
				}
				else
				{
					ProductUri = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = ProductUri;
			break;
		case "ManufacturerName":
			if (createOrReplace && ManufacturerName == null)
			{
				if (replacement == null)
				{
					ManufacturerName = new BaseDataVariableState<string>(this);
				}
				else
				{
					ManufacturerName = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = ManufacturerName;
			break;
		case "ProductName":
			if (createOrReplace && ProductName == null)
			{
				if (replacement == null)
				{
					ProductName = new BaseDataVariableState<string>(this);
				}
				else
				{
					ProductName = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = ProductName;
			break;
		case "SoftwareVersion":
			if (createOrReplace && SoftwareVersion == null)
			{
				if (replacement == null)
				{
					SoftwareVersion = new BaseDataVariableState<string>(this);
				}
				else
				{
					SoftwareVersion = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = SoftwareVersion;
			break;
		case "BuildNumber":
			if (createOrReplace && BuildNumber == null)
			{
				if (replacement == null)
				{
					BuildNumber = new BaseDataVariableState<string>(this);
				}
				else
				{
					BuildNumber = (BaseDataVariableState<string>)replacement;
				}
			}
			baseInstanceState = BuildNumber;
			break;
		case "BuildDate":
			if (createOrReplace && BuildDate == null)
			{
				if (replacement == null)
				{
					BuildDate = new BaseDataVariableState<DateTime>(this);
				}
				else
				{
					BuildDate = (BaseDataVariableState<DateTime>)replacement;
				}
			}
			baseInstanceState = BuildDate;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
