using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class LimitAlarmState : AlarmConditionState
{
	private const string HighHighLimit_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoTGltaXQBAHQrAC4ARHQrAAAAC/////8BAf////8AAAAA";

	private const string HighLimit_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEhpZ2hMaW1pdAEAdSsALgBEdSsAAAAL/////wEB/////wAAAAA=";

	private const string LowLimit_InitializationString = "//////////8VYIkKAgAAAAAACAAAAExvd0xpbWl0AQB2KwAuAER2KwAAAAv/////AQH/////AAAAAA==";

	private const string LowLowLimit_InitializationString = "//////////8VYIkKAgAAAAAACwAAAExvd0xvd0xpbWl0AQB3KwAuAER3KwAAAAv/////AQH/////AAAAAA==";

	private const string BaseHighHighLimit_InitializationString = "//////////8VYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAAA==";

	private const string BaseHighLimit_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEJhc2VIaWdoTGltaXQBAL1AAC4ARL1AAAAAC/////8BAf////8AAAAA";

	private const string BaseLowLimit_InitializationString = "//////////8VYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAA=";

	private const string BaseLowLowLimit_InitializationString = "//////////8VYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAFgAAAExpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAIsLAQCLC4sLAAD/////IgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5BcALgBE5BcAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5RcALgBE5RcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYXAC4AROYXAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnFwAuAETnFwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6BcALgBE6BcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkXAC4AROkXAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsXAC4AROsXAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7BcALgBE7BcAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHErAC4ARHErAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHIrAC4ARHIrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQABJAAuAEQBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAAIkAC4ARAIkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAO0XAC4ARO0XAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAAMkAC8BACMjAyQAAAAV/////wEBBQAAAAEALCMAAQAXJAEALCMAAQAgJAEALCMAAQAtJAEALCMAAQA2JAEALCMAAQA/JAEAAAAVYIkKAgAAAAAAAgAAAElkAQAEJAAuAEQEJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEADCQALwEAKiMMJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQANJAAuAEQNJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAA4kAC8BACojDiQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEADyQALgBEDyQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAECQALwEAKiMQJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQARJAAuAEQRJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBABIkAC4ARBIkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQAUJAAvAQBEIxQkAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBABMkAC8BAEMjEyQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBABUkAC8BAEUjFSQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAWJAAuAEQWJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBABckAC8BACMjFyQAAAAV/////wEBAQAAAAEALCMBAQADJAEAAAAVYIkKAgAAAAAAAgAAAElkAQAYJAAuAEQYJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBACkkAC8BAJcjKSQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAqJAAuAEQqJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQAtJAAvAQAjIy0kAAAAFf////8BAQEAAAABACwjAQEAAyQBAAAAFWCJCgIAAAAAAAIAAABJZAEALiQALgBELiQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAcysALgBEcysAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAGQkAC4ARGQkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaExpbWl0AQB0KwAuAER0KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASGlnaExpbWl0AQB1KwAuAER1KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATG93TGltaXQBAHYrAC4ARHYrAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dMaW1pdAEAdysALgBEdysAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQmFzZUhpZ2hMaW1pdAEAvUAALgBEvUAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=";

	private PropertyState<double> m_highHighLimit;

	private PropertyState<double> m_highLimit;

	private PropertyState<double> m_lowLimit;

	private PropertyState<double> m_lowLowLimit;

	private PropertyState<double> m_baseHighHighLimit;

	private PropertyState<double> m_baseHighLimit;

	private PropertyState<double> m_baseLowLimit;

	private PropertyState<double> m_baseLowLowLimit;

	public PropertyState<double> HighHighLimit
	{
		get
		{
			return m_highHighLimit;
		}
		set
		{
			if (m_highHighLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_highHighLimit = value;
		}
	}

	public PropertyState<double> HighLimit
	{
		get
		{
			return m_highLimit;
		}
		set
		{
			if (m_highLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_highLimit = value;
		}
	}

	public PropertyState<double> LowLimit
	{
		get
		{
			return m_lowLimit;
		}
		set
		{
			if (m_lowLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lowLimit = value;
		}
	}

	public PropertyState<double> LowLowLimit
	{
		get
		{
			return m_lowLowLimit;
		}
		set
		{
			if (m_lowLowLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lowLowLimit = value;
		}
	}

	public PropertyState<double> BaseHighHighLimit
	{
		get
		{
			return m_baseHighHighLimit;
		}
		set
		{
			if (m_baseHighHighLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_baseHighHighLimit = value;
		}
	}

	public PropertyState<double> BaseHighLimit
	{
		get
		{
			return m_baseHighLimit;
		}
		set
		{
			if (m_baseHighLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_baseHighLimit = value;
		}
	}

	public PropertyState<double> BaseLowLimit
	{
		get
		{
			return m_baseLowLimit;
		}
		set
		{
			if (m_baseLowLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_baseLowLimit = value;
		}
	}

	public PropertyState<double> BaseLowLowLimit
	{
		get
		{
			return m_baseLowLowLimit;
		}
		set
		{
			if (m_baseLowLowLimit != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_baseLowLowLimit = value;
		}
	}

	public LimitAlarmState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(2955u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAFgAAAExpbWl0QWxhcm1UeXBlSW5zdGFuY2UBAIsLAQCLC4sLAAD/////IgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEA5BcALgBE5BcAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEA5RcALgBE5RcAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBAOYXAC4AROYXAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQDnFwAuAETnFwAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEA6BcALgBE6BcAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBAOkXAC4AROkXAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBAOsXAC4AROsXAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEA7BcALgBE7BcAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAHErAC4ARHErAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAHIrAC4ARHIrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQABJAAuAEQBJAAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAAIkAC4ARAIkAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAO0XAC4ARO0XAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAAMkAC8BACMjAyQAAAAV/////wEBBQAAAAEALCMAAQAXJAEALCMAAQAgJAEALCMAAQAtJAEALCMAAQA2JAEALCMAAQA/JAEAAAAVYIkKAgAAAAAAAgAAAElkAQAEJAAuAEQEJAAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEADCQALwEAKiMMJAAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQANJAAuAEQNJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAA4kAC8BACojDiQAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEADyQALgBEDyQAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAECQALwEAKiMQJAAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQARJAAuAEQRJAAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBABIkAC4ARBIkAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQAUJAAvAQBEIxQkAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBABMkAC8BAEMjEyQAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBABUkAC8BAEUjFSQAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAWJAAuAEQWJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBABckAC8BACMjFyQAAAAV/////wEBAQAAAAEALCMBAQADJAEAAAAVYIkKAgAAAAAAAgAAAElkAQAYJAAuAEQYJAAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBACkkAC8BAJcjKSQAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQAqJAAuAEQqJAAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQAtJAAvAQAjIy0kAAAAFf////8BAQEAAAABACwjAQEAAyQBAAAAFWCJCgIAAAAAAAIAAABJZAEALiQALgBELiQAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAcysALgBEcysAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBAGQkAC4ARGQkAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaExpbWl0AQB0KwAuAER0KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAJAAAASGlnaExpbWl0AQB1KwAuAER1KwAAAAv/////AQH/////AAAAABVgiQoCAAAAAAAIAAAATG93TGltaXQBAHYrAC4ARHYrAAAAC/////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dMaW1pdAEAdysALgBEdysAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAABVgiQoCAAAAAAANAAAAQmFzZUhpZ2hMaW1pdAEAvUAALgBEvUAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAAVYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=");
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
		if (HighHighLimit != null)
		{
			HighHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoTGltaXQBAHQrAC4ARHQrAAAAC/////8BAf////8AAAAA");
		}
		if (HighLimit != null)
		{
			HighLimit.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEhpZ2hMaW1pdAEAdSsALgBEdSsAAAAL/////wEB/////wAAAAA=");
		}
		if (LowLimit != null)
		{
			LowLimit.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAExvd0xpbWl0AQB2KwAuAER2KwAAAAv/////AQH/////AAAAAA==");
		}
		if (LowLowLimit != null)
		{
			LowLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAExvd0xvd0xpbWl0AQB3KwAuAER3KwAAAAv/////AQH/////AAAAAA==");
		}
		if (BaseHighHighLimit != null)
		{
			BaseHighHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAAEQAAAEJhc2VIaWdoSGlnaExpbWl0AQC8QAAuAES8QAAAAAv/////AQH/////AAAAAA==");
		}
		if (BaseHighLimit != null)
		{
			BaseHighLimit.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEJhc2VIaWdoTGltaXQBAL1AAC4ARL1AAAAAC/////8BAf////8AAAAA");
		}
		if (BaseLowLimit != null)
		{
			BaseLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAADAAAAEJhc2VMb3dMaW1pdAEAvkAALgBEvkAAAAAL/////wEB/////wAAAAA=");
		}
		if (BaseLowLowLimit != null)
		{
			BaseLowLowLimit.Initialize(context, "//////////8VYIkKAgAAAAAADwAAAEJhc2VMb3dMb3dMaW1pdAEAv0AALgBEv0AAAAAL/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_highHighLimit != null)
		{
			children.Add(m_highHighLimit);
		}
		if (m_highLimit != null)
		{
			children.Add(m_highLimit);
		}
		if (m_lowLimit != null)
		{
			children.Add(m_lowLimit);
		}
		if (m_lowLowLimit != null)
		{
			children.Add(m_lowLowLimit);
		}
		if (m_baseHighHighLimit != null)
		{
			children.Add(m_baseHighHighLimit);
		}
		if (m_baseHighLimit != null)
		{
			children.Add(m_baseHighLimit);
		}
		if (m_baseLowLimit != null)
		{
			children.Add(m_baseLowLimit);
		}
		if (m_baseLowLowLimit != null)
		{
			children.Add(m_baseLowLowLimit);
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
		case "HighHighLimit":
			if (createOrReplace && HighHighLimit == null)
			{
				if (replacement == null)
				{
					HighHighLimit = new PropertyState<double>(this);
				}
				else
				{
					HighHighLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = HighHighLimit;
			break;
		case "HighLimit":
			if (createOrReplace && HighLimit == null)
			{
				if (replacement == null)
				{
					HighLimit = new PropertyState<double>(this);
				}
				else
				{
					HighLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = HighLimit;
			break;
		case "LowLimit":
			if (createOrReplace && LowLimit == null)
			{
				if (replacement == null)
				{
					LowLimit = new PropertyState<double>(this);
				}
				else
				{
					LowLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = LowLimit;
			break;
		case "LowLowLimit":
			if (createOrReplace && LowLowLimit == null)
			{
				if (replacement == null)
				{
					LowLowLimit = new PropertyState<double>(this);
				}
				else
				{
					LowLowLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = LowLowLimit;
			break;
		case "BaseHighHighLimit":
			if (createOrReplace && BaseHighHighLimit == null)
			{
				if (replacement == null)
				{
					BaseHighHighLimit = new PropertyState<double>(this);
				}
				else
				{
					BaseHighHighLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = BaseHighHighLimit;
			break;
		case "BaseHighLimit":
			if (createOrReplace && BaseHighLimit == null)
			{
				if (replacement == null)
				{
					BaseHighLimit = new PropertyState<double>(this);
				}
				else
				{
					BaseHighLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = BaseHighLimit;
			break;
		case "BaseLowLimit":
			if (createOrReplace && BaseLowLimit == null)
			{
				if (replacement == null)
				{
					BaseLowLimit = new PropertyState<double>(this);
				}
				else
				{
					BaseLowLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = BaseLowLimit;
			break;
		case "BaseLowLowLimit":
			if (createOrReplace && BaseLowLowLimit == null)
			{
				if (replacement == null)
				{
					BaseLowLowLimit = new PropertyState<double>(this);
				}
				else
				{
					BaseLowLowLimit = (PropertyState<double>)replacement;
				}
			}
			baseInstanceState = BaseLowLowLimit;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}
}
