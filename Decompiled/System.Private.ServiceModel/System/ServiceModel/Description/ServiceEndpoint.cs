using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.ServiceModel.Channels;

namespace System.ServiceModel.Description;

[DebuggerDisplay("Address={Address}")]
[DebuggerDisplay("Name={_name}")]
public class ServiceEndpoint
{
	private ContractDescription _contract;

	private Uri _listenUri;

	private ListenUriMode _listenUriMode;

	private KeyedByTypeCollection<IEndpointBehavior> _behaviors;

	private string _id;

	private XmlName _name;

	public EndpointAddress Address { get; set; }

	public KeyedCollection<Type, IEndpointBehavior> EndpointBehaviors => Behaviors;

	[EditorBrowsable(EditorBrowsableState.Never)]
	public KeyedByTypeCollection<IEndpointBehavior> Behaviors
	{
		get
		{
			if (_behaviors == null)
			{
				_behaviors = new KeyedByTypeCollection<IEndpointBehavior>();
			}
			return _behaviors;
		}
	}

	public Binding Binding { get; set; }

	public ContractDescription Contract
	{
		get
		{
			return _contract;
		}
		set
		{
			_contract = value ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("value");
		}
	}

	public bool IsSystemEndpoint { get; set; }

	public string Name
	{
		get
		{
			if (!XmlName.IsNullOrEmpty(_name))
			{
				return _name.EncodedName;
			}
			if (Binding != null)
			{
				return string.Format(CultureInfo.InvariantCulture, "{0}_{1}", new XmlName(Binding.Name).EncodedName, Contract.Name);
			}
			return Contract.Name;
		}
		set
		{
			_name = new XmlName(value, isEncoded: true);
		}
	}

	public Uri ListenUri
	{
		get
		{
			if (_listenUri == null)
			{
				if (Address == null)
				{
					return null;
				}
				return Address.Uri;
			}
			return _listenUri;
		}
		set
		{
			if (value != null && !value.IsAbsoluteUri)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("value", System.SR.UriMustBeAbsolute);
			}
			_listenUri = value;
		}
	}

	public ListenUriMode ListenUriMode
	{
		get
		{
			return _listenUriMode;
		}
		set
		{
			if (!ListenUriModeHelper.IsDefined(value))
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value"));
			}
			_listenUriMode = value;
		}
	}

	internal string Id
	{
		get
		{
			if (_id == null)
			{
				_id = Guid.NewGuid().ToString();
			}
			return _id;
		}
	}

	internal Uri UnresolvedAddress { get; set; }

	internal Uri UnresolvedListenUri { get; set; }

	internal bool IsFullyConfigured { get; set; }

	public ServiceEndpoint(ContractDescription contract)
	{
		_contract = contract ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contract");
	}

	public ServiceEndpoint(ContractDescription contract, Binding binding, EndpointAddress address)
	{
		_contract = contract ?? throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contract");
		Binding = binding;
		Address = address;
	}

	internal void EnsureInvariants()
	{
		if (Binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.AChannelServiceEndpointSBindingIsNull0));
		}
		if (Contract == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.AChannelServiceEndpointSContractIsNull0));
		}
		Contract.EnsureInvariants();
		Binding.EnsureInvariants(Contract.Name);
	}

	internal void ValidateForClient()
	{
		Validate(runOperationValidators: true, isForService: false);
	}

	internal void ValidateForService(bool runOperationValidators)
	{
		Validate(runOperationValidators, isForService: true);
	}

	private void Validate(bool runOperationValidators, bool isForService)
	{
		ContractDescription contract = Contract;
		for (int i = 0; i < contract.Behaviors.Count; i++)
		{
			IContractBehavior contractBehavior = contract.Behaviors[i];
			contractBehavior.Validate(contract, this);
		}
		for (int j = 0; j < Behaviors.Count; j++)
		{
			IEndpointBehavior endpointBehavior = Behaviors[j];
			endpointBehavior.Validate(this);
		}
		if (!runOperationValidators)
		{
			return;
		}
		for (int k = 0; k < contract.Operations.Count; k++)
		{
			OperationDescription operationDescription = contract.Operations[k];
			for (int l = 0; l < operationDescription.Behaviors.Count; l++)
			{
				IOperationBehavior operationBehavior = operationDescription.Behaviors[l];
				operationBehavior.Validate(operationDescription);
			}
		}
	}
}
