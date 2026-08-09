using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class AuditCancelEventState : AuditSessionEventState
{
	private const string InitializationString = "//////////8EYIACAQAAAAAAHAAAAEF1ZGl0Q2FuY2VsRXZlbnRUeXBlSW5zdGFuY2UBAB4IAQAeCB4IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA8wwALgBE8wwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA9AwALgBE9AwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAPUMAC4ARPUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQD2DAAuAET2DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA9wwALgBE9wwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAPgMAC4ARPgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPoMAC4ARPoMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA+wwALgBE+wwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA/AwALgBE/AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQD9DAAuAET9DAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAP4MAC4ARP4MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAP8MAC4ARP8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAANAC4ARAANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAAENAC4ARAENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZXF1ZXN0SGFuZGxlAQAfCAAuAEQfCAAAAAf/////AQH/////AAAAAA==";

	private PropertyState<uint> m_requestHandle;

	public PropertyState<uint> RequestHandle
	{
		get
		{
			return m_requestHandle;
		}
		set
		{
			if (m_requestHandle != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_requestHandle = value;
		}
	}

	public AuditCancelEventState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2078u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAHAAAAEF1ZGl0Q2FuY2VsRXZlbnRUeXBlSW5zdGFuY2UBAB4IAQAeCB4IAAD/////DwAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA8wwALgBE8wwAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA9AwALgBE9AwAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAPUMAC4ARPUMAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQD2DAAuAET2DAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA9wwALgBE9wwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAPgMAC4ARPgMAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAPoMAC4ARPoMAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA+wwALgBE+wwAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEFjdGlvblRpbWVTdGFtcAEA/AwALgBE/AwAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAGAAAAU3RhdHVzAQD9DAAuAET9DAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAU2VydmVySWQBAP4MAC4ARP4MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDbGllbnRBdWRpdEVudHJ5SWQBAP8MAC4ARP8MAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAAANAC4ARAANAAAADP////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABTZXNzaW9uSWQBAAENAC4ARAENAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABSZXF1ZXN0SGFuZGxlAQAfCAAuAEQfCAAAAAf/////AQH/////AAAAAA==");
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
		if (m_requestHandle != null)
		{
			children.Add(m_requestHandle);
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
		if (browseName.Name == "RequestHandle")
		{
			if (createOrReplace && RequestHandle == null)
			{
				if (replacement == null)
				{
					RequestHandle = new PropertyState<uint>(this);
				}
				else
				{
					RequestHandle = (PropertyState<uint>)replacement;
				}
			}
			baseInstanceState = RequestHandle;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
