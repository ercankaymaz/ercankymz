using System.Globalization;

namespace System.ServiceModel.Channels;

public sealed class MessageVersion
{
	private static MessageVersion s_soap12Addressing200408;

	private const string MessageVersionToStringFormat = "{0} {1}";

	public AddressingVersion Addressing { get; }

	public static MessageVersion Default => Soap12WSAddressing10;

	public EnvelopeVersion Envelope { get; }

	public static MessageVersion None { get; private set; }

	public static MessageVersion Soap12WSAddressing10 { get; private set; }

	public static MessageVersion Soap11WSAddressing10 { get; private set; }

	public static MessageVersion Soap12WSAddressingAugust2004 => s_soap12Addressing200408;

	public static MessageVersion Soap11WSAddressingAugust2004 { get; private set; }

	public static MessageVersion Soap11 { get; private set; }

	public static MessageVersion Soap12 { get; private set; }

	static MessageVersion()
	{
		None = new MessageVersion(EnvelopeVersion.None, AddressingVersion.None);
		Soap11 = new MessageVersion(EnvelopeVersion.Soap11, AddressingVersion.None);
		Soap12 = new MessageVersion(EnvelopeVersion.Soap12, AddressingVersion.None);
		Soap11WSAddressing10 = new MessageVersion(EnvelopeVersion.Soap11, AddressingVersion.WSAddressing10);
		Soap12WSAddressing10 = new MessageVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressing10);
		Soap11WSAddressingAugust2004 = new MessageVersion(EnvelopeVersion.Soap11, AddressingVersion.WSAddressingAugust2004);
		s_soap12Addressing200408 = new MessageVersion(EnvelopeVersion.Soap12, AddressingVersion.WSAddressingAugust2004);
	}

	private MessageVersion(EnvelopeVersion envelopeVersion, AddressingVersion addressingVersion)
	{
		Envelope = envelopeVersion;
		Addressing = addressingVersion;
	}

	public static MessageVersion CreateVersion(EnvelopeVersion envelopeVersion)
	{
		return CreateVersion(envelopeVersion, AddressingVersion.WSAddressing10);
	}

	public static MessageVersion CreateVersion(EnvelopeVersion envelopeVersion, AddressingVersion addressingVersion)
	{
		if (envelopeVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("envelopeVersion");
		}
		if (addressingVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("addressingVersion");
		}
		if (envelopeVersion == EnvelopeVersion.Soap12)
		{
			if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				return Soap12WSAddressing10;
			}
			if (addressingVersion == AddressingVersion.WSAddressingAugust2004)
			{
				return s_soap12Addressing200408;
			}
			if (addressingVersion == AddressingVersion.None)
			{
				return Soap12;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion));
		}
		if (envelopeVersion == EnvelopeVersion.Soap11)
		{
			if (addressingVersion == AddressingVersion.WSAddressing10)
			{
				return Soap11WSAddressing10;
			}
			if (addressingVersion == AddressingVersion.WSAddressingAugust2004)
			{
				return Soap11WSAddressingAugust2004;
			}
			if (addressingVersion == AddressingVersion.None)
			{
				return Soap11;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion));
		}
		if (envelopeVersion == EnvelopeVersion.None)
		{
			if (addressingVersion == AddressingVersion.None)
			{
				return None;
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("addressingVersion", System.SR.Format(System.SR.AddressingVersionNotSupported, addressingVersion));
		}
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("envelopeVersion", System.SR.Format(System.SR.EnvelopeVersionNotSupported, envelopeVersion));
	}

	public override bool Equals(object obj)
	{
		return this == obj;
	}

	public override int GetHashCode()
	{
		int num = 0;
		if (Envelope == EnvelopeVersion.Soap11)
		{
			num++;
		}
		if (Addressing == AddressingVersion.WSAddressingAugust2004)
		{
			num += 2;
		}
		return num;
	}

	public override string ToString()
	{
		return $"{Envelope.ToString()} {Addressing.ToString()}";
	}

	internal bool IsMatch(MessageVersion messageVersion)
	{
		if (messageVersion == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("messageVersion");
		}
		if (Addressing == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "MessageVersion.Addressing cannot be null")));
		}
		if (Envelope != messageVersion.Envelope)
		{
			return false;
		}
		if (Addressing.Namespace != messageVersion.Addressing.Namespace)
		{
			return false;
		}
		return true;
	}
}
