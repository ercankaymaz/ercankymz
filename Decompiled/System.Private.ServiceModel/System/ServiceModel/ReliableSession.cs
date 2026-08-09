using System.ComponentModel;
using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class ReliableSession
{
	private ReliableSessionBindingElement _element;

	[DefaultValue(true)]
	public bool Ordered
	{
		get
		{
			return _element.Ordered;
		}
		set
		{
			_element.Ordered = value;
		}
	}

	public TimeSpan InactivityTimeout
	{
		get
		{
			return _element.InactivityTimeout;
		}
		set
		{
			if (value <= TimeSpan.Zero)
			{
				throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentOutOfRangeException("value", value, System.SR.ValueMustBePositive));
			}
			_element.InactivityTimeout = value;
		}
	}

	public ReliableSession()
	{
		_element = new ReliableSessionBindingElement();
	}

	public ReliableSession(ReliableSessionBindingElement reliableSessionBindingElement)
	{
		if (reliableSessionBindingElement == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reliableSessionBindingElement");
		}
		_element = reliableSessionBindingElement;
	}

	internal void CopySettings(ReliableSession copyFrom)
	{
		Ordered = copyFrom.Ordered;
		InactivityTimeout = copyFrom.InactivityTimeout;
	}
}
