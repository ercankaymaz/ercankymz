using System.Globalization;

namespace System.ServiceModel.Channels;

public abstract class FaultConverter
{
	internal class DefaultFaultConverter : FaultConverter
	{
		private MessageVersion _version;

		internal DefaultFaultConverter(MessageVersion version)
		{
			_version = version;
		}

		protected override bool OnTryCreateException(Message message, MessageFault fault, out Exception exception)
		{
			exception = null;
			if (string.Compare(fault.Code.Namespace, _version.Envelope.Namespace, StringComparison.Ordinal) == 0 && string.Compare(fault.Code.Name, "MustUnderstand", StringComparison.Ordinal) == 0)
			{
				exception = new ProtocolException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
				return true;
			}
			bool flag;
			bool flag2;
			FaultCode faultCode;
			if (_version.Envelope == EnvelopeVersion.Soap11)
			{
				flag = true;
				flag2 = true;
				faultCode = fault.Code;
			}
			else
			{
				flag = fault.Code.IsSenderFault;
				flag2 = fault.Code.IsReceiverFault;
				faultCode = fault.Code.SubCode;
			}
			if (faultCode == null)
			{
				return false;
			}
			if (faultCode.Namespace == null)
			{
				return false;
			}
			if (flag && string.Compare(faultCode.Namespace, _version.Addressing.Namespace, StringComparison.Ordinal) == 0)
			{
				if (string.Compare(faultCode.Name, "ActionNotSupported", StringComparison.Ordinal) == 0)
				{
					exception = new ActionNotSupportedException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
					return true;
				}
				if (string.Compare(faultCode.Name, "DestinationUnreachable", StringComparison.Ordinal) == 0)
				{
					exception = new EndpointNotFoundException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
					return true;
				}
				if (string.Compare(faultCode.Name, "InvalidAddressingHeader", StringComparison.Ordinal) == 0)
				{
					if (faultCode.SubCode != null && string.Compare(faultCode.SubCode.Namespace, _version.Addressing.Namespace, StringComparison.Ordinal) == 0 && string.Compare(faultCode.SubCode.Name, "InvalidCardinality", StringComparison.Ordinal) == 0)
					{
						exception = new MessageHeaderException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text, isDuplicate: true);
						return true;
					}
				}
				else if (_version.Addressing == AddressingVersion.WSAddressing10)
				{
					if (string.Compare(faultCode.Name, "MessageAddressingHeaderRequired", StringComparison.Ordinal) == 0)
					{
						exception = new MessageHeaderException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
						return true;
					}
					if (string.Compare(faultCode.Name, "InvalidAddressingHeader", StringComparison.Ordinal) == 0)
					{
						exception = new ProtocolException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
						return true;
					}
				}
				else
				{
					if (string.Compare(faultCode.Name, "MessageInformationHeaderRequired", StringComparison.Ordinal) == 0)
					{
						exception = new ProtocolException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
						return true;
					}
					if (string.Compare(faultCode.Name, "InvalidMessageInformationHeader", StringComparison.Ordinal) == 0)
					{
						exception = new ProtocolException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
						return true;
					}
				}
			}
			if (flag2 && string.Compare(faultCode.Namespace, _version.Addressing.Namespace, StringComparison.Ordinal) == 0 && string.Compare(faultCode.Name, "EndpointUnavailable", StringComparison.Ordinal) == 0)
			{
				exception = new ServerTooBusyException(fault.Reason.GetMatchingTranslation(CultureInfo.CurrentCulture).Text);
				return true;
			}
			return false;
		}

		protected override bool OnTryCreateFaultMessage(Exception exception, out Message message)
		{
			if (_version.Addressing == AddressingVersion.WSAddressing10)
			{
				if (exception is MessageHeaderException)
				{
					MessageHeaderException ex = exception as MessageHeaderException;
					if (ex.HeaderNamespace == AddressingVersion.WSAddressing10.Namespace)
					{
						message = ex.ProvideFault(_version);
						return true;
					}
				}
				else if (exception is ActionMismatchAddressingException)
				{
					ActionMismatchAddressingException ex2 = exception as ActionMismatchAddressingException;
					message = ex2.ProvideFault(_version);
					return true;
				}
			}
			if (_version.Addressing != AddressingVersion.None && exception is ActionNotSupportedException)
			{
				ActionNotSupportedException ex3 = exception as ActionNotSupportedException;
				message = ex3.ProvideFault(_version);
				return true;
			}
			if (exception is MustUnderstandSoapException)
			{
				MustUnderstandSoapException ex4 = exception as MustUnderstandSoapException;
				message = ex4.ProvideFault(_version);
				return true;
			}
			message = null;
			return false;
		}
	}

	public static FaultConverter GetDefaultFaultConverter(MessageVersion version)
	{
		return new DefaultFaultConverter(version);
	}

	protected abstract bool OnTryCreateException(Message message, MessageFault fault, out Exception exception);

	protected abstract bool OnTryCreateFaultMessage(Exception exception, out Message message);

	public bool TryCreateException(Message message, MessageFault fault, out Exception exception)
	{
		if (message == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("message");
		}
		if (fault == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("fault");
		}
		bool flag = OnTryCreateException(message, fault, out exception);
		if (flag)
		{
			if (exception == null)
			{
				string message2 = System.SR.Format(System.SR.FaultConverterDidNotCreateException, GetType().Name);
				Exception exception2 = new InvalidOperationException(message2);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception2);
			}
		}
		else if (exception != null)
		{
			string message3 = System.SR.Format(System.SR.FaultConverterCreatedException, GetType().Name);
			Exception exception3 = new InvalidOperationException(message3, exception);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception3);
		}
		return flag;
	}

	public bool TryCreateFaultMessage(Exception exception, out Message message)
	{
		bool flag = OnTryCreateFaultMessage(exception, out message);
		if (flag)
		{
			if (message == null)
			{
				string message2 = System.SR.Format(System.SR.FaultConverterDidNotCreateFaultMessage, GetType().Name);
				Exception exception2 = new InvalidOperationException(message2);
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception2);
			}
		}
		else if (message != null)
		{
			string message3 = System.SR.Format(System.SR.FaultConverterCreatedFaultMessage, GetType().Name);
			Exception exception3 = new InvalidOperationException(message3);
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(exception3);
		}
		return flag;
	}
}
