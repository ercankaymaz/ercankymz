using System.ServiceModel.Channels;

namespace System.ServiceModel;

public class BasicHttpsBinding : HttpBindingBase
{
	private BasicHttpsSecurity _basicHttpsSecurity;

	public WSMessageEncoding MessageEncoding { get; set; }

	public BasicHttpsSecurity Security
	{
		get
		{
			return _basicHttpsSecurity;
		}
		set
		{
			_basicHttpsSecurity = value ?? throw FxTrace.Exception.ArgumentNull("value");
		}
	}

	internal override BasicHttpSecurity BasicHttpSecurity => _basicHttpsSecurity.BasicHttpSecurity;

	public BasicHttpsBinding()
		: this(BasicHttpsSecurityMode.Transport)
	{
	}

	public BasicHttpsBinding(BasicHttpsSecurityMode securityMode)
	{
		_basicHttpsSecurity = new BasicHttpsSecurity();
		_basicHttpsSecurity.Mode = securityMode;
	}

	internal override EnvelopeVersion GetEnvelopeVersion()
	{
		return EnvelopeVersion.Soap11;
	}

	public override IChannelFactory<TChannel> BuildChannelFactory<TChannel>(BindingParameterCollection parameters)
	{
		if ((BasicHttpSecurity.Mode == BasicHttpSecurityMode.Transport || BasicHttpSecurity.Mode == BasicHttpSecurityMode.TransportCredentialOnly) && BasicHttpSecurity.Transport.ClientCredentialType == HttpClientCredentialType.InheritedFromHost)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.HttpClientCredentialTypeInvalid, BasicHttpSecurity.Transport.ClientCredentialType)));
		}
		return base.BuildChannelFactory<TChannel>(parameters);
	}

	public override BindingElementCollection CreateBindingElements()
	{
		CheckSettings();
		BindingElementCollection bindingElementCollection = new BindingElementCollection();
		SecurityBindingElement securityBindingElement = BasicHttpSecurity.CreateMessageSecurity();
		if (securityBindingElement != null)
		{
			bindingElementCollection.Add(securityBindingElement);
		}
		WSMessageEncodingHelper.SyncUpEncodingBindingElementProperties(base.TextMessageEncodingBindingElement, base.MtomMessageEncodingBindingElement);
		if (MessageEncoding == WSMessageEncoding.Text)
		{
			bindingElementCollection.Add(base.TextMessageEncodingBindingElement);
		}
		else if (MessageEncoding == WSMessageEncoding.Mtom)
		{
			bindingElementCollection.Add(base.MtomMessageEncodingBindingElement);
		}
		bindingElementCollection.Add(GetTransport());
		return bindingElementCollection.Clone();
	}
}
