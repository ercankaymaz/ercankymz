using System.ServiceModel.Description;

namespace System.ServiceModel;

public class FaultCode
{
	private string _ns;

	private EnvelopeVersion _version;

	public bool IsPredefinedFault
	{
		get
		{
			if (_ns.Length != 0)
			{
				return _version != null;
			}
			return true;
		}
	}

	public bool IsSenderFault
	{
		get
		{
			if (IsPredefinedFault)
			{
				return Name == (_version ?? EnvelopeVersion.Soap12).SenderFaultName;
			}
			return false;
		}
	}

	public bool IsReceiverFault
	{
		get
		{
			if (IsPredefinedFault)
			{
				return Name == (_version ?? EnvelopeVersion.Soap12).ReceiverFaultName;
			}
			return false;
		}
	}

	public string Namespace => _ns;

	public string Name { get; }

	public FaultCode SubCode { get; }

	public FaultCode(string name)
		: this(name, "", null)
	{
	}

	public FaultCode(string name, FaultCode subCode)
		: this(name, "", subCode)
	{
	}

	public FaultCode(string name, string ns)
		: this(name, ns, null)
	{
	}

	public FaultCode(string name, string ns, FaultCode subCode)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("name"));
		}
		if (name.Length == 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("name"));
		}
		if (!string.IsNullOrEmpty(ns))
		{
			NamingHelper.CheckUriParameter(ns, "ns");
		}
		Name = name;
		_ns = ns;
		SubCode = subCode;
		switch (ns)
		{
		case "http://www.w3.org/2003/05/soap-envelope":
			_version = EnvelopeVersion.Soap12;
			break;
		case "http://schemas.xmlsoap.org/soap/envelope/":
			_version = EnvelopeVersion.Soap11;
			break;
		case "http://schemas.microsoft.com/ws/2005/05/envelope/none":
			_version = EnvelopeVersion.None;
			break;
		default:
			_version = null;
			break;
		}
	}

	public static FaultCode CreateSenderFaultCode(FaultCode subCode)
	{
		return new FaultCode("Sender", subCode);
	}

	public static FaultCode CreateSenderFaultCode(string name, string ns)
	{
		return CreateSenderFaultCode(new FaultCode(name, ns));
	}

	public static FaultCode CreateReceiverFaultCode(FaultCode subCode)
	{
		if (subCode == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("subCode"));
		}
		return new FaultCode("Receiver", subCode);
	}

	public static FaultCode CreateReceiverFaultCode(string name, string ns)
	{
		return CreateReceiverFaultCode(new FaultCode(name, ns));
	}
}
