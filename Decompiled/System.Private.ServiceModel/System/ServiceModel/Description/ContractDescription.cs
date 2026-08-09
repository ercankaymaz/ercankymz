using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Security;
using System.ServiceModel.Security;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Name={_name}, Namespace={_ns}, ContractType={ContractType}")]
public class ContractDescription
{
	private XmlName _name;

	private string _ns;

	private SessionMode _sessionMode;

	private ProtectionLevel _protectionLevel;

	internal string CodeName => _name.DecodedName;

	[DefaultValue(null)]
	public string ConfigurationName { get; set; }

	public Type ContractType { get; set; }

	public Type CallbackContractType { get; set; }

	public string Name
	{
		get
		{
			return _name.EncodedName;
		}
		set
		{
			if (value == null)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
			}
			if (value.Length == 0)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", System.SR.SFxContractDescriptionNameCannotBeEmpty));
			}
			_name = new XmlName(value, isEncoded: true);
		}
	}

	public string Namespace
	{
		get
		{
			return _ns;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				NamingHelper.CheckUriProperty(value, "Namespace");
			}
			_ns = value;
		}
	}

	public OperationDescriptionCollection Operations { get; }

	public ProtectionLevel ProtectionLevel
	{
		get
		{
			return _protectionLevel;
		}
		set
		{
			if (!ProtectionLevelHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_protectionLevel = value;
			HasProtectionLevel = true;
		}
	}

	public bool HasProtectionLevel { get; private set; }

	[DefaultValue(SessionMode.Allowed)]
	public SessionMode SessionMode
	{
		get
		{
			return _sessionMode;
		}
		set
		{
			if (!SessionModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_sessionMode = value;
		}
	}

	public KeyedCollection<Type, IContractBehavior> ContractBehaviors => Behaviors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public KeyedByTypeCollection<IContractBehavior> Behaviors { get; } = new KeyedByTypeCollection<IContractBehavior>();

	public ContractDescription(string name)
		: this(name, null)
	{
	}

	public ContractDescription(string name, string ns)
	{
		Name = name;
		if (!string.IsNullOrEmpty(ns))
		{
			NamingHelper.CheckUriParameter(ns, "ns");
		}
		Operations = new OperationDescriptionCollection();
		_ns = ns ?? "http://tempuri.org/";
	}

	public bool ShouldSerializeProtectionLevel()
	{
		return HasProtectionLevel;
	}

	public static ContractDescription GetContract(Type contractType)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		TypeLoader typeLoader = new TypeLoader();
		return typeLoader.LoadContractDescription(contractType);
	}

	public static ContractDescription GetContract(Type contractType, Type serviceType)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		if (serviceType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serviceType");
		}
		TypeLoader typeLoader = new TypeLoader();
		return typeLoader.LoadContractDescription(contractType, serviceType);
	}

	public static ContractDescription GetContract(Type contractType, object serviceImplementation)
	{
		if (contractType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contractType");
		}
		if (serviceImplementation == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serviceImplementation");
		}
		TypeLoader typeLoader = new TypeLoader();
		Type type = serviceImplementation.GetType();
		return typeLoader.LoadContractDescription(contractType, type, serviceImplementation);
	}

	public Collection<ContractDescription> GetInheritedContracts()
	{
		Collection<ContractDescription> collection = new Collection<ContractDescription>();
		for (int i = 0; i < Operations.Count; i++)
		{
			OperationDescription operationDescription = Operations[i];
			if (operationDescription.DeclaringContract != this)
			{
				ContractDescription declaringContract = operationDescription.DeclaringContract;
				if (!collection.Contains(declaringContract))
				{
					collection.Add(declaringContract);
				}
			}
		}
		return collection;
	}

	internal void EnsureInvariants()
	{
		if (string.IsNullOrEmpty(Name))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.AChannelServiceEndpointSContractSNameIsNull0));
		}
		if (Namespace == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.AChannelServiceEndpointSContractSNamespace0));
		}
		if (Operations.Count == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxContractHasZeroOperations, Name)));
		}
		bool flag = false;
		for (int i = 0; i < Operations.Count; i++)
		{
			OperationDescription operationDescription = Operations[i];
			operationDescription.EnsureInvariants();
			if (operationDescription.IsInitiating)
			{
				flag = true;
			}
			if ((!operationDescription.IsInitiating || operationDescription.IsTerminating) && SessionMode != SessionMode.Required)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.ContractIsNotSelfConsistentItHasOneOrMore2, Name)));
			}
		}
		if (!flag)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFxContractHasZeroInitiatingOperations, Name)));
		}
	}

	internal bool IsDuplex()
	{
		for (int i = 0; i < Operations.Count; i++)
		{
			if (Operations[i].IsServerInitiated())
			{
				return true;
			}
		}
		return false;
	}
}
