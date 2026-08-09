using System.Net.Security;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

namespace System.ServiceModel.Security;

public class ChannelProtectionRequirements
{
	private ScopedMessagePartSpecification _outgoingEncryptionParts;

	public bool IsReadOnly { get; private set; }

	public ScopedMessagePartSpecification IncomingSignatureParts { get; private set; }

	public ScopedMessagePartSpecification IncomingEncryptionParts { get; private set; }

	public ScopedMessagePartSpecification OutgoingSignatureParts { get; private set; }

	public ScopedMessagePartSpecification OutgoingEncryptionParts => _outgoingEncryptionParts;

	public ChannelProtectionRequirements()
	{
		IncomingSignatureParts = new ScopedMessagePartSpecification();
		IncomingEncryptionParts = new ScopedMessagePartSpecification();
		OutgoingSignatureParts = new ScopedMessagePartSpecification();
		_outgoingEncryptionParts = new ScopedMessagePartSpecification();
	}

	public ChannelProtectionRequirements(ChannelProtectionRequirements other)
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("other"));
		}
		IncomingSignatureParts = new ScopedMessagePartSpecification(other.IncomingSignatureParts);
		IncomingEncryptionParts = new ScopedMessagePartSpecification(other.IncomingEncryptionParts);
		OutgoingSignatureParts = new ScopedMessagePartSpecification(other.OutgoingSignatureParts);
		_outgoingEncryptionParts = new ScopedMessagePartSpecification(other._outgoingEncryptionParts);
	}

	internal ChannelProtectionRequirements(ChannelProtectionRequirements other, ProtectionLevel newBodyProtectionLevel)
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("other"));
		}
		IncomingSignatureParts = new ScopedMessagePartSpecification(other.IncomingSignatureParts, newBodyProtectionLevel != ProtectionLevel.None);
		IncomingEncryptionParts = new ScopedMessagePartSpecification(other.IncomingEncryptionParts, newBodyProtectionLevel == ProtectionLevel.EncryptAndSign);
		OutgoingSignatureParts = new ScopedMessagePartSpecification(other.OutgoingSignatureParts, newBodyProtectionLevel != ProtectionLevel.None);
		_outgoingEncryptionParts = new ScopedMessagePartSpecification(other._outgoingEncryptionParts, newBodyProtectionLevel == ProtectionLevel.EncryptAndSign);
	}

	public void Add(ChannelProtectionRequirements protectionRequirements)
	{
		Add(protectionRequirements, channelScopeOnly: false);
	}

	public void Add(ChannelProtectionRequirements protectionRequirements, bool channelScopeOnly)
	{
		if (protectionRequirements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("protectionRequirements"));
		}
		if (protectionRequirements.IncomingSignatureParts != null)
		{
			IncomingSignatureParts.AddParts(protectionRequirements.IncomingSignatureParts.ChannelParts);
		}
		if (protectionRequirements.IncomingEncryptionParts != null)
		{
			IncomingEncryptionParts.AddParts(protectionRequirements.IncomingEncryptionParts.ChannelParts);
		}
		if (protectionRequirements.OutgoingSignatureParts != null)
		{
			OutgoingSignatureParts.AddParts(protectionRequirements.OutgoingSignatureParts.ChannelParts);
		}
		if (protectionRequirements._outgoingEncryptionParts != null)
		{
			_outgoingEncryptionParts.AddParts(protectionRequirements._outgoingEncryptionParts.ChannelParts);
		}
		if (!channelScopeOnly)
		{
			AddActionParts(IncomingSignatureParts, protectionRequirements.IncomingSignatureParts);
			AddActionParts(IncomingEncryptionParts, protectionRequirements.IncomingEncryptionParts);
			AddActionParts(OutgoingSignatureParts, protectionRequirements.OutgoingSignatureParts);
			AddActionParts(_outgoingEncryptionParts, protectionRequirements._outgoingEncryptionParts);
		}
	}

	private static void AddActionParts(ScopedMessagePartSpecification to, ScopedMessagePartSpecification from)
	{
		foreach (string action in from.Actions)
		{
			if (from.TryGetParts(action, excludeChannelScope: true, out var parts))
			{
				to.AddParts(parts, action);
			}
		}
	}

	public void MakeReadOnly()
	{
		if (!IsReadOnly)
		{
			IncomingSignatureParts.MakeReadOnly();
			IncomingEncryptionParts.MakeReadOnly();
			OutgoingSignatureParts.MakeReadOnly();
			_outgoingEncryptionParts.MakeReadOnly();
			IsReadOnly = true;
		}
	}

	public ChannelProtectionRequirements CreateInverse()
	{
		ChannelProtectionRequirements channelProtectionRequirements = new ChannelProtectionRequirements();
		channelProtectionRequirements.Add(this, channelScopeOnly: true);
		channelProtectionRequirements.IncomingSignatureParts = new ScopedMessagePartSpecification(OutgoingSignatureParts);
		channelProtectionRequirements.OutgoingSignatureParts = new ScopedMessagePartSpecification(IncomingSignatureParts);
		channelProtectionRequirements.IncomingEncryptionParts = new ScopedMessagePartSpecification(OutgoingEncryptionParts);
		channelProtectionRequirements._outgoingEncryptionParts = new ScopedMessagePartSpecification(IncomingEncryptionParts);
		return channelProtectionRequirements;
	}

	internal static ChannelProtectionRequirements CreateFromContract(ContractDescription contract, ISecurityCapabilities bindingElement, bool isForClient)
	{
		return CreateFromContract(contract, bindingElement.SupportedRequestProtectionLevel, bindingElement.SupportedResponseProtectionLevel, isForClient);
	}

	private static MessagePartSpecification UnionMessagePartSpecifications(ScopedMessagePartSpecification actionParts)
	{
		MessagePartSpecification messagePartSpecification = new MessagePartSpecification(isBodyIncluded: false);
		foreach (string action in actionParts.Actions)
		{
			if (!actionParts.TryGetParts(action, out var parts))
			{
				continue;
			}
			if (parts.IsBodyIncluded)
			{
				messagePartSpecification.IsBodyIncluded = true;
			}
			foreach (XmlQualifiedName headerType in parts.HeaderTypes)
			{
				if (!messagePartSpecification.IsHeaderIncluded(headerType.Name, headerType.Namespace))
				{
					messagePartSpecification.HeaderTypes.Add(headerType);
				}
			}
		}
		return messagePartSpecification;
	}

	internal static ChannelProtectionRequirements CreateFromContractAndUnionResponseProtectionRequirements(ContractDescription contract, ISecurityCapabilities bindingElement, bool isForClient)
	{
		ChannelProtectionRequirements channelProtectionRequirements = CreateFromContract(contract, bindingElement.SupportedRequestProtectionLevel, bindingElement.SupportedResponseProtectionLevel, isForClient);
		ChannelProtectionRequirements channelProtectionRequirements2 = new ChannelProtectionRequirements();
		if (isForClient)
		{
			channelProtectionRequirements2.IncomingEncryptionParts.AddParts(UnionMessagePartSpecifications(channelProtectionRequirements.IncomingEncryptionParts), "*");
			channelProtectionRequirements2.IncomingSignatureParts.AddParts(UnionMessagePartSpecifications(channelProtectionRequirements.IncomingSignatureParts), "*");
			channelProtectionRequirements.OutgoingEncryptionParts.CopyTo(channelProtectionRequirements2.OutgoingEncryptionParts);
			channelProtectionRequirements.OutgoingSignatureParts.CopyTo(channelProtectionRequirements2.OutgoingSignatureParts);
		}
		else
		{
			channelProtectionRequirements2.OutgoingEncryptionParts.AddParts(UnionMessagePartSpecifications(channelProtectionRequirements.OutgoingEncryptionParts), "*");
			channelProtectionRequirements2.OutgoingSignatureParts.AddParts(UnionMessagePartSpecifications(channelProtectionRequirements.OutgoingSignatureParts), "*");
			channelProtectionRequirements.IncomingEncryptionParts.CopyTo(channelProtectionRequirements2.IncomingEncryptionParts);
			channelProtectionRequirements.IncomingSignatureParts.CopyTo(channelProtectionRequirements2.IncomingSignatureParts);
		}
		return channelProtectionRequirements2;
	}

	internal static ChannelProtectionRequirements CreateFromContract(ContractDescription contract, ProtectionLevel defaultRequestProtectionLevel, ProtectionLevel defaultResponseProtectionLevel, bool isForClient)
	{
		if (contract == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("contract"));
		}
		ChannelProtectionRequirements channelProtectionRequirements = new ChannelProtectionRequirements();
		ProtectionLevel protectionLevel;
		ProtectionLevel protectionLevel2;
		if (contract.HasProtectionLevel)
		{
			protectionLevel = contract.ProtectionLevel;
			protectionLevel2 = contract.ProtectionLevel;
		}
		else
		{
			protectionLevel = defaultRequestProtectionLevel;
			protectionLevel2 = defaultResponseProtectionLevel;
		}
		foreach (OperationDescription operation in contract.Operations)
		{
			ProtectionLevel protectionLevel3 = protectionLevel;
			ProtectionLevel protectionLevel4 = protectionLevel2;
			foreach (MessageDescription message in operation.Messages)
			{
				ProtectionLevel protectionLevel5 = (message.HasProtectionLevel ? message.ProtectionLevel : ((message.Direction != MessageDirection.Input) ? protectionLevel4 : protectionLevel3));
				MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
				MessagePartSpecification messagePartSpecification2 = new MessagePartSpecification();
				foreach (MessageHeaderDescription header in message.Headers)
				{
					AddHeaderProtectionRequirements(header, messagePartSpecification, messagePartSpecification2, protectionLevel5);
				}
				ProtectionLevel protectionLevel6;
				if (message.Body.Parts.Count > 0)
				{
					protectionLevel6 = ProtectionLevel.None;
				}
				else if (message.Body.ReturnValue != null)
				{
					if (!message.Body.ReturnValue.GetType().Equals(typeof(MessagePartDescription)))
					{
						throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.OnlyBodyReturnValuesSupported));
					}
					MessagePartDescription returnValue = message.Body.ReturnValue;
					protectionLevel6 = (returnValue.HasProtectionLevel ? returnValue.ProtectionLevel : protectionLevel5);
				}
				else
				{
					protectionLevel6 = protectionLevel5;
				}
				if (message.Body.Parts.Count > 0)
				{
					foreach (MessagePartDescription part in message.Body.Parts)
					{
						ProtectionLevel v = (part.HasProtectionLevel ? part.ProtectionLevel : protectionLevel5);
						protectionLevel6 = ProtectionLevelHelper.Max(protectionLevel6, v);
						if (protectionLevel6 == ProtectionLevel.EncryptAndSign)
						{
							break;
						}
					}
				}
				if (protectionLevel6 != ProtectionLevel.None)
				{
					messagePartSpecification.IsBodyIncluded = true;
					if (protectionLevel6 == ProtectionLevel.EncryptAndSign)
					{
						messagePartSpecification2.IsBodyIncluded = true;
					}
				}
				if (message.Direction == MessageDirection.Input)
				{
					channelProtectionRequirements.IncomingSignatureParts.AddParts(messagePartSpecification, message.Action);
					channelProtectionRequirements.IncomingEncryptionParts.AddParts(messagePartSpecification2, message.Action);
				}
				else
				{
					channelProtectionRequirements.OutgoingSignatureParts.AddParts(messagePartSpecification, message.Action);
					channelProtectionRequirements.OutgoingEncryptionParts.AddParts(messagePartSpecification2, message.Action);
				}
			}
			if (operation.Faults != null)
			{
				if (operation.IsServerInitiated())
				{
					AddFaultProtectionRequirements(operation.Faults, channelProtectionRequirements, protectionLevel3, addToIncoming: true);
				}
				else
				{
					AddFaultProtectionRequirements(operation.Faults, channelProtectionRequirements, protectionLevel4, addToIncoming: false);
				}
			}
		}
		return channelProtectionRequirements;
	}

	private static void AddHeaderProtectionRequirements(MessageHeaderDescription header, MessagePartSpecification signedParts, MessagePartSpecification encryptedParts, ProtectionLevel defaultProtectionLevel)
	{
		ProtectionLevel protectionLevel = (header.HasProtectionLevel ? header.ProtectionLevel : defaultProtectionLevel);
		if (protectionLevel != ProtectionLevel.None)
		{
			XmlQualifiedName item = new XmlQualifiedName(header.Name, header.Namespace);
			signedParts.HeaderTypes.Add(item);
			if (protectionLevel == ProtectionLevel.EncryptAndSign)
			{
				encryptedParts.HeaderTypes.Add(item);
			}
		}
	}

	private static void AddFaultProtectionRequirements(FaultDescriptionCollection faults, ChannelProtectionRequirements requirements, ProtectionLevel defaultProtectionLevel, bool addToIncoming)
	{
		if (faults == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("faults"));
		}
		if (requirements == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("requirements"));
		}
		foreach (FaultDescription fault in faults)
		{
			MessagePartSpecification messagePartSpecification = new MessagePartSpecification();
			MessagePartSpecification messagePartSpecification2 = new MessagePartSpecification();
			ProtectionLevel protectionLevel = (fault.HasProtectionLevel ? fault.ProtectionLevel : defaultProtectionLevel);
			if (protectionLevel != ProtectionLevel.None)
			{
				messagePartSpecification.IsBodyIncluded = true;
				if (protectionLevel == ProtectionLevel.EncryptAndSign)
				{
					messagePartSpecification2.IsBodyIncluded = true;
				}
			}
			if (addToIncoming)
			{
				requirements.IncomingSignatureParts.AddParts(messagePartSpecification, fault.Action);
				requirements.IncomingEncryptionParts.AddParts(messagePartSpecification2, fault.Action);
			}
			else
			{
				requirements.OutgoingSignatureParts.AddParts(messagePartSpecification, fault.Action);
				requirements.OutgoingEncryptionParts.AddParts(messagePartSpecification2, fault.Action);
			}
		}
	}
}
