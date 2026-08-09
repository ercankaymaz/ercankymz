using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[ComVisible(true)]
public class NonExclusiveLimitAlarmState : LimitAlarmState
{
	private const string HighHighState_InitializationString = "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoU3RhdGUBACQnAC8BACMjJCcAAAAV/////wEBAQAAAAEALCMBAQDrJgQAAAAVYIkKAgAAAAAAAgAAAElkAQAlJwAuAEQlJwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBACknAC4ARCknAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAKycALgBEKycAABUDAgAAAGVuDwAAAEhpZ2hIaWdoIGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBACwnAC4ARCwnAAAVAwIAAABlbhEAAABIaWdoSGlnaCBpbmFjdGl2ZQAV/////wEB/////wAAAAA=";

	private const string HighState_InitializationString = "//////////8VYIkKAgAAAAAACQAAAEhpZ2hTdGF0ZQEALScALwEAIyMtJwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBAC4nAC4ARC4nAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAMicALgBEMicAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQA0JwAuAEQ0JwAAFQMCAAAAZW4LAAAASGlnaCBhY3RpdmUAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQA1JwAuAEQ1JwAAFQMCAAAAZW4NAAAASGlnaCBpbmFjdGl2ZQAV/////wEB/////wAAAAA=";

	private const string LowState_InitializationString = "//////////8VYIkKAgAAAAAACAAAAExvd1N0YXRlAQA2JwAvAQAjIzYnAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEANycALgBENycAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQA7JwAuAEQ7JwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAD0nAC4ARD0nAAAVAwIAAABlbgoAAABMb3cgYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAPicALgBEPicAABUDAgAAAGVuDAAAAExvdyBpbmFjdGl2ZQAV/////wEB/////wAAAAA=";

	private const string LowLowState_InitializationString = "//////////8VYIkKAgAAAAAACwAAAExvd0xvd1N0YXRlAQA/JwAvAQAjIz8nAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEAQCcALgBEQCcAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQBEJwAuAEREJwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAEYnAC4AREYnAAAVAwIAAABlbg0AAABMb3dMb3cgYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEARycALgBERycAABUDAgAAAGVuDwAAAExvd0xvdyBpbmFjdGl2ZQAV/////wEB/////wAAAAA=";

	private const string InitializationString = "//////////8EYIACAQAAAAAAIgAAAE5vbkV4Y2x1c2l2ZUxpbWl0QWxhcm1UeXBlSW5zdGFuY2UBALImAQCyJrImAAD/////HgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAsyYALgBEsyYAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAtCYALgBEtCYAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBALUmAC4ARLUmAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQC2JgAuAES2JgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAtyYALgBEtyYAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALgmAC4ARLgmAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALomAC4ARLomAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAuyYALgBEuyYAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAIQrAC4ARIQrAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAIUrAC4ARIUrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQC8JgAuAES8JgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAL0mAC4ARL0mAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAL4mAC4ARL4mAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAL8mAC8BACMjvyYAAAAV/////wEBBQAAAAEALCMAAQDVJgEALCMAAQDeJgEALCMAAQDrJgEALCMAAQD0JgEALCMAAQD9JgEAAAAVYIkKAgAAAAAAAgAAAElkAQDAJgAuAETAJgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAyCYALwEAKiPIJgAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDJJgAuAETJJgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAMomAC8BACojyiYAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAyyYALgBEyyYAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAzCYALwEAKiPMJgAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDNJgAuAETNJgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAM4mAC4ARM4mAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQDQJgAvAQBEI9AmAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAM8mAC8BAEMjzyYAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBANEmAC8BAEUj0SYAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDSJgAuAETSJgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBANUmAC8BACMj1SYAAAAV/////wEBAQAAAAEALCMBAQC/JgEAAAAVYIkKAgAAAAAAAgAAAElkAQDWJgAuAETWJgAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBAOcmAC8BAJcj5yYAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoJgAuAEToJgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQDrJgAvAQAjI+smAAAAFf////8BAQUAAAABACwjAQEAvyYBACwjAAEAJCcBACwjAAEALScBACwjAAEANicBACwjAAEAPycBAAAAFWCJCgIAAAAAAAIAAABJZAEA7CYALgBE7CYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAhisALgBEhisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBACInAC4ARCInAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaFN0YXRlAQAkJwAvAQAjIyQnAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEAJScALgBEJScAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQApJwAuAEQpJwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBACsnAC4ARCsnAAAVAwIAAABlbg8AAABIaWdoSGlnaCBhY3RpdmUAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAsJwAuAEQsJwAAFQMCAAAAZW4RAAAASGlnaEhpZ2ggaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABIaWdoU3RhdGUBAC0nAC8BACMjLScAAAAV/////wEBAQAAAAEALCMBAQDrJgQAAAAVYIkKAgAAAAAAAgAAAElkAQAuJwAuAEQuJwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADInAC4ARDInAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEANCcALgBENCcAABUDAgAAAGVuCwAAAEhpZ2ggYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEANScALgBENScAABUDAgAAAGVuDQAAAEhpZ2ggaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABMb3dTdGF0ZQEANicALwEAIyM2JwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBADcnAC4ARDcnAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAOycALgBEOycAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQA9JwAuAEQ9JwAAFQMCAAAAZW4KAAAATG93IGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAD4nAC4ARD4nAAAVAwIAAABlbgwAAABMb3cgaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dTdGF0ZQEAPycALwEAIyM/JwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBAEAnAC4AREAnAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEARCcALgBERCcAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBGJwAuAERGJwAAFQMCAAAAZW4NAAAATG93TG93IGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEcnAC4AREcnAAAVAwIAAABlbg8AAABMb3dMb3cgaW5hY3RpdmUAFf////8BAf////8AAAAA";

	private TwoStateVariableState m_highHighState;

	private TwoStateVariableState m_highState;

	private TwoStateVariableState m_lowState;

	private TwoStateVariableState m_lowLowState;

	public TwoStateVariableState HighHighState
	{
		get
		{
			return m_highHighState;
		}
		set
		{
			if (m_highHighState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_highHighState = value;
		}
	}

	public TwoStateVariableState HighState
	{
		get
		{
			return m_highState;
		}
		set
		{
			if (m_highState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_highState = value;
		}
	}

	public TwoStateVariableState LowState
	{
		get
		{
			return m_lowState;
		}
		set
		{
			if (m_lowState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lowState = value;
		}
	}

	public TwoStateVariableState LowLowState
	{
		get
		{
			return m_lowLowState;
		}
		set
		{
			if (m_lowLowState != value)
			{
				base.ChangeMasks |= NodeStateChangeMasks.Children;
			}
			m_lowLowState = value;
		}
	}

	public NonExclusiveLimitAlarmState(NodeState parent)
		: base(parent)
	{
	}

	protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
	{
		return NodeId.Create(9906u, "http://opcfoundation.org/UA/", namespaceUris);
	}

	protected override void Initialize(ISystemContext context)
	{
		base.Initialize(context);
		Initialize(context, "//////////8EYIACAQAAAAAAIgAAAE5vbkV4Y2x1c2l2ZUxpbWl0QWxhcm1UeXBlSW5zdGFuY2UBALImAQCyJrImAAD/////HgAAABVgiQoCAAAAAAAHAAAARXZlbnRJZAEAsyYALgBEsyYAAAAP/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAEV2ZW50VHlwZQEAtCYALgBEtCYAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAACgAAAFNvdXJjZU5vZGUBALUmAC4ARLUmAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAoAAABTb3VyY2VOYW1lAQC2JgAuAES2JgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAEAAAAVGltZQEAtyYALgBEtyYAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAALAAAAUmVjZWl2ZVRpbWUBALgmAC4ARLgmAAABACYB/////wEB/////wAAAAAVYIkKAgAAAAAABwAAAE1lc3NhZ2UBALomAC4ARLomAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABTZXZlcml0eQEAuyYALgBEuyYAAAAF/////wEB/////wAAAAAVYIkKAgAAAAAAEAAAAENvbmRpdGlvbkNsYXNzSWQBAIQrAC4ARIQrAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAABIAAABDb25kaXRpb25DbGFzc05hbWUBAIUrAC4ARIUrAAAAFf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABDb25kaXRpb25OYW1lAQC8JgAuAES8JgAAAAz/////AQH/////AAAAABVgiQoCAAAAAAAIAAAAQnJhbmNoSWQBAL0mAC4ARL0mAAAAEf////8BAf////8AAAAAFWCJCgIAAAAAAAYAAABSZXRhaW4BAL4mAC4ARL4mAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABFbmFibGVkU3RhdGUBAL8mAC8BACMjvyYAAAAV/////wEBBQAAAAEALCMAAQDVJgEALCMAAQDeJgEALCMAAQDrJgEALCMAAQD0JgEALCMAAQD9JgEAAAAVYIkKAgAAAAAAAgAAAElkAQDAJgAuAETAJgAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAUXVhbGl0eQEAyCYALwEAKiPIJgAAABP/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDJJgAuAETJJgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABMYXN0U2V2ZXJpdHkBAMomAC8BACojyiYAAAAF/////wEB/////wEAAAAVYIkKAgAAAAAADwAAAFNvdXJjZVRpbWVzdGFtcAEAyyYALgBEyyYAAAEAJgH/////AQH/////AAAAABVgiQoCAAAAAAAHAAAAQ29tbWVudAEAzCYALwEAKiPMJgAAABX/////AQH/////AQAAABVgiQoCAAAAAAAPAAAAU291cmNlVGltZXN0YW1wAQDNJgAuAETNJgAAAQAmAf////8BAf////8AAAAAFWCJCgIAAAAAAAwAAABDbGllbnRVc2VySWQBAM4mAC4ARM4mAAAADP////8BAf////8AAAAABGGCCgQAAAAAAAcAAABEaXNhYmxlAQDQJgAvAQBEI9AmAAABAQEAAAABAPkLAAEA8woAAAAABGGCCgQAAAAAAAYAAABFbmFibGUBAM8mAC8BAEMjzyYAAAEBAQAAAAEA+QsAAQDzCgAAAAAEYYIKBAAAAAAACgAAAEFkZENvbW1lbnQBANEmAC8BAEUj0SYAAAEBAQAAAAEA+QsAAQANCwEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDSJgAuAETSJgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACgAAAEFja2VkU3RhdGUBANUmAC8BACMj1SYAAAAV/////wEBAQAAAAEALCMBAQC/JgEAAAAVYIkKAgAAAAAAAgAAAElkAQDWJgAuAETWJgAAAAH/////AQH/////AAAAAARhggoEAAAAAAALAAAAQWNrbm93bGVkZ2UBAOcmAC8BAJcj5yYAAAEBAQAAAAEA+QsAAQDwIgEAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQDoJgAuAEToJgAAlgIAAAABACoBAUYAAAAHAAAARXZlbnRJZAAP/////wAAAAADAAAAACgAAABUaGUgaWRlbnRpZmllciBmb3IgdGhlIGV2ZW50IHRvIGNvbW1lbnQuAQAqAQFCAAAABwAAAENvbW1lbnQAFf////8AAAAAAwAAAAAkAAAAVGhlIGNvbW1lbnQgdG8gYWRkIHRvIHRoZSBjb25kaXRpb24uAQAoAQEAAAABAAAAAAAAAAEB/////wAAAAAVYIkKAgAAAAAACwAAAEFjdGl2ZVN0YXRlAQDrJgAvAQAjI+smAAAAFf////8BAQUAAAABACwjAQEAvyYBACwjAAEAJCcBACwjAAEALScBACwjAAEANicBACwjAAEAPycBAAAAFWCJCgIAAAAAAAIAAABJZAEA7CYALgBE7CYAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAACQAAAElucHV0Tm9kZQEAhisALgBEhisAAAAR/////wEB/////wAAAAAVYIkKAgAAAAAAEwAAAFN1cHByZXNzZWRPclNoZWx2ZWQBACInAC4ARCInAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA0AAABIaWdoSGlnaFN0YXRlAQAkJwAvAQAjIyQnAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEAJScALgBEJScAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQApJwAuAEQpJwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBACsnAC4ARCsnAAAVAwIAAABlbg8AAABIaWdoSGlnaCBhY3RpdmUAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQAsJwAuAEQsJwAAFQMCAAAAZW4RAAAASGlnaEhpZ2ggaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAkAAABIaWdoU3RhdGUBAC0nAC8BACMjLScAAAAV/////wEBAQAAAAEALCMBAQDrJgQAAAAVYIkKAgAAAAAAAgAAAElkAQAuJwAuAEQuJwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBADInAC4ARDInAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEANCcALgBENCcAABUDAgAAAGVuCwAAAEhpZ2ggYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEANScALgBENScAABUDAgAAAGVuDQAAAEhpZ2ggaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAgAAABMb3dTdGF0ZQEANicALwEAIyM2JwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBADcnAC4ARDcnAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAOycALgBEOycAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQA9JwAuAEQ9JwAAFQMCAAAAZW4KAAAATG93IGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAD4nAC4ARD4nAAAVAwIAAABlbgwAAABMb3cgaW5hY3RpdmUAFf////8BAf////8AAAAAFWCJCgIAAAAAAAsAAABMb3dMb3dTdGF0ZQEAPycALwEAIyM/JwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBAEAnAC4AREAnAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEARCcALgBERCcAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQBGJwAuAERGJwAAFQMCAAAAZW4NAAAATG93TG93IGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBAEcnAC4AREcnAAAVAwIAAABlbg8AAABMb3dMb3cgaW5hY3RpdmUAFf////8BAf////8AAAAA");
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
		if (HighHighState != null)
		{
			HighHighState.Initialize(context, "//////////8VYIkKAgAAAAAADQAAAEhpZ2hIaWdoU3RhdGUBACQnAC8BACMjJCcAAAAV/////wEBAQAAAAEALCMBAQDrJgQAAAAVYIkKAgAAAAAAAgAAAElkAQAlJwAuAEQlJwAAAAH/////AQH/////AAAAABVgiQoCAAAAAAAOAAAAVHJhbnNpdGlvblRpbWUBACknAC4ARCknAAABACYB/////wEB/////wAAAAAVYKkKAgAAAAAACQAAAFRydWVTdGF0ZQEAKycALgBEKycAABUDAgAAAGVuDwAAAEhpZ2hIaWdoIGFjdGl2ZQAV/////wEB/////wAAAAAVYKkKAgAAAAAACgAAAEZhbHNlU3RhdGUBACwnAC4ARCwnAAAVAwIAAABlbhEAAABIaWdoSGlnaCBpbmFjdGl2ZQAV/////wEB/////wAAAAA=");
		}
		if (HighState != null)
		{
			HighState.Initialize(context, "//////////8VYIkKAgAAAAAACQAAAEhpZ2hTdGF0ZQEALScALwEAIyMtJwAAABX/////AQEBAAAAAQAsIwEBAOsmBAAAABVgiQoCAAAAAAACAAAASWQBAC4nAC4ARC4nAAAAAf////8BAf////8AAAAAFWCJCgIAAAAAAA4AAABUcmFuc2l0aW9uVGltZQEAMicALgBEMicAAAEAJgH/////AQH/////AAAAABVgqQoCAAAAAAAJAAAAVHJ1ZVN0YXRlAQA0JwAuAEQ0JwAAFQMCAAAAZW4LAAAASGlnaCBhY3RpdmUAFf////8BAf////8AAAAAFWCpCgIAAAAAAAoAAABGYWxzZVN0YXRlAQA1JwAuAEQ1JwAAFQMCAAAAZW4NAAAASGlnaCBpbmFjdGl2ZQAV/////wEB/////wAAAAA=");
		}
		if (LowState != null)
		{
			LowState.Initialize(context, "//////////8VYIkKAgAAAAAACAAAAExvd1N0YXRlAQA2JwAvAQAjIzYnAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEANycALgBENycAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQA7JwAuAEQ7JwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAD0nAC4ARD0nAAAVAwIAAABlbgoAAABMb3cgYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEAPicALgBEPicAABUDAgAAAGVuDAAAAExvdyBpbmFjdGl2ZQAV/////wEB/////wAAAAA=");
		}
		if (LowLowState != null)
		{
			LowLowState.Initialize(context, "//////////8VYIkKAgAAAAAACwAAAExvd0xvd1N0YXRlAQA/JwAvAQAjIz8nAAAAFf////8BAQEAAAABACwjAQEA6yYEAAAAFWCJCgIAAAAAAAIAAABJZAEAQCcALgBEQCcAAAAB/////wEB/////wAAAAAVYIkKAgAAAAAADgAAAFRyYW5zaXRpb25UaW1lAQBEJwAuAEREJwAAAQAmAf////8BAf////8AAAAAFWCpCgIAAAAAAAkAAABUcnVlU3RhdGUBAEYnAC4AREYnAAAVAwIAAABlbg0AAABMb3dMb3cgYWN0aXZlABX/////AQH/////AAAAABVgqQoCAAAAAAAKAAAARmFsc2VTdGF0ZQEARycALgBERycAABUDAgAAAGVuDwAAAExvd0xvdyBpbmFjdGl2ZQAV/////wEB/////wAAAAA=");
		}
	}

	public override void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_highHighState != null)
		{
			children.Add(m_highHighState);
		}
		if (m_highState != null)
		{
			children.Add(m_highState);
		}
		if (m_lowState != null)
		{
			children.Add(m_lowState);
		}
		if (m_lowLowState != null)
		{
			children.Add(m_lowLowState);
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
		case "HighHighState":
			if (createOrReplace && HighHighState == null)
			{
				if (replacement == null)
				{
					HighHighState = new TwoStateVariableState(this);
				}
				else
				{
					HighHighState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = HighHighState;
			break;
		case "HighState":
			if (createOrReplace && HighState == null)
			{
				if (replacement == null)
				{
					HighState = new TwoStateVariableState(this);
				}
				else
				{
					HighState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = HighState;
			break;
		case "LowState":
			if (createOrReplace && LowState == null)
			{
				if (replacement == null)
				{
					LowState = new TwoStateVariableState(this);
				}
				else
				{
					LowState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = LowState;
			break;
		case "LowLowState":
			if (createOrReplace && LowLowState == null)
			{
				if (replacement == null)
				{
					LowLowState = new TwoStateVariableState(this);
				}
				else
				{
					LowLowState = (TwoStateVariableState)replacement;
				}
			}
			baseInstanceState = LowLowState;
			break;
		}
		if (baseInstanceState != null)
		{
			return baseInstanceState;
		}
		return base.FindChild(context, browseName, createOrReplace, replacement);
	}

	public virtual void SetLimitState(ISystemContext context, LimitAlarmStates limit)
	{
		if (HighState != null)
		{
			UpdateState(HighState, (limit & LimitAlarmStates.High) != LimitAlarmStates.Inactive || (limit & LimitAlarmStates.HighHigh) != 0);
		}
		if (HighHighState != null)
		{
			UpdateState(HighHighState, (limit & LimitAlarmStates.HighHigh) != 0);
		}
		if (LowState != null)
		{
			UpdateState(LowState, (limit & LimitAlarmStates.Low) != LimitAlarmStates.Inactive || (limit & LimitAlarmStates.LowLow) != 0);
		}
		if (LowLowState != null)
		{
			UpdateState(LowLowState, (limit & LimitAlarmStates.LowLow) != 0);
		}
		TranslationInfo translationInfo = null;
		translationInfo = (((limit & LimitAlarmStates.HighHigh) != LimitAlarmStates.Inactive) ? new TranslationInfo("ConditionStateHighHighActive", "en-US", "HighHighActive") : (((limit & LimitAlarmStates.LowLow) != LimitAlarmStates.Inactive) ? new TranslationInfo("ConditionStateLowLowActive", "en-US", "LowLowActive") : (((limit & LimitAlarmStates.High) != LimitAlarmStates.Inactive) ? new TranslationInfo("ConditionStateHighActive", "en-US", "HighActive") : (((limit & LimitAlarmStates.Low) == 0) ? new TranslationInfo("ConditionStateInactive", "en-US", "Inactive") : new TranslationInfo("ConditionStateLowActive", "en-US", "LowActive")))));
		SetActiveEffectiveSubState(context, new LocalizedText(translationInfo), DateTime.UtcNow);
		UpdateEffectiveState(context);
	}

	private void UpdateState(TwoStateVariableState limit, bool active)
	{
		TranslationInfo translationInfo = null;
		translationInfo = ((!active) ? new TranslationInfo("ConditionStateInactive", "en-US", "Inactive") : new TranslationInfo("ConditionStateActive", "en-US", "Active"));
		limit.Value = new LocalizedText(translationInfo);
		limit.Id.Value = active;
		if (limit.TransitionTime != null)
		{
			limit.TransitionTime.Value = DateTime.UtcNow;
		}
	}
}
