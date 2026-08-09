using System.IdentityModel.Selectors;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;

namespace System.ServiceModel.Description;

public class ClientCredentials : SecurityCredentialsManager, IEndpointBehavior
{
	private UserNamePasswordClientCredential _userName;

	private X509CertificateInitiatorClientCredential _clientCertificate;

	private X509CertificateRecipientClientCredential _serviceCertificate;

	private WindowsClientCredential _windows;

	private HttpDigestClientCredential _httpDigest;

	private bool _isReadOnly;

	public UserNamePasswordClientCredential UserName
	{
		get
		{
			if (_userName == null)
			{
				_userName = new UserNamePasswordClientCredential();
				if (_isReadOnly)
				{
					_userName.MakeReadOnly();
				}
			}
			return _userName;
		}
	}

	public X509CertificateInitiatorClientCredential ClientCertificate
	{
		get
		{
			if (_clientCertificate == null)
			{
				_clientCertificate = new X509CertificateInitiatorClientCredential();
				if (_isReadOnly)
				{
					_clientCertificate.MakeReadOnly();
				}
			}
			return _clientCertificate;
		}
	}

	public X509CertificateRecipientClientCredential ServiceCertificate
	{
		get
		{
			if (_serviceCertificate == null)
			{
				_serviceCertificate = new X509CertificateRecipientClientCredential();
				if (_isReadOnly)
				{
					_serviceCertificate.MakeReadOnly();
				}
			}
			return _serviceCertificate;
		}
	}

	public WindowsClientCredential Windows
	{
		get
		{
			if (_windows == null)
			{
				_windows = new WindowsClientCredential();
				if (_isReadOnly)
				{
					_windows.MakeReadOnly();
				}
			}
			return _windows;
		}
	}

	public HttpDigestClientCredential HttpDigest
	{
		get
		{
			if (_httpDigest == null)
			{
				_httpDigest = new HttpDigestClientCredential();
				if (_isReadOnly)
				{
					_httpDigest.MakeReadOnly();
				}
			}
			return _httpDigest;
		}
	}

	public ClientCredentials()
	{
	}

	protected ClientCredentials(ClientCredentials other)
	{
		if (other == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("other");
		}
		if (other._userName != null)
		{
			_userName = new UserNamePasswordClientCredential(other._userName);
		}
		if (other._clientCertificate != null)
		{
			_clientCertificate = new X509CertificateInitiatorClientCredential(other._clientCertificate);
		}
		if (other._serviceCertificate != null)
		{
			_serviceCertificate = new X509CertificateRecipientClientCredential(other._serviceCertificate);
		}
		if (other._windows != null)
		{
			_windows = new WindowsClientCredential(other._windows);
		}
		if (other._httpDigest != null)
		{
			_httpDigest = new HttpDigestClientCredential(other._httpDigest);
		}
		_isReadOnly = other._isReadOnly;
	}

	internal static ClientCredentials CreateDefaultCredentials()
	{
		return new ClientCredentials();
	}

	public override SecurityTokenManager CreateSecurityTokenManager()
	{
		return new ClientCredentialsSecurityTokenManager(Clone());
	}

	protected virtual ClientCredentials CloneCore()
	{
		return new ClientCredentials(this);
	}

	public ClientCredentials Clone()
	{
		ClientCredentials clientCredentials = CloneCore();
		if (clientCredentials == null || clientCredentials.GetType() != GetType())
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(System.NotImplemented.ByDesignWithMessage(System.SR.Format(System.SR.CloneNotImplementedCorrectly, GetType(), (clientCredentials != null) ? clientCredentials.ToString() : "null")));
		}
		return clientCredentials;
	}

	void IEndpointBehavior.Validate(ServiceEndpoint serviceEndpoint)
	{
	}

	void IEndpointBehavior.AddBindingParameters(ServiceEndpoint serviceEndpoint, BindingParameterCollection bindingParameters)
	{
		if (bindingParameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("bindingParameters");
		}
		SecurityCredentialsManager securityCredentialsManager = bindingParameters.Find<SecurityCredentialsManager>();
		if (securityCredentialsManager != null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.MultipleSecurityCredentialsManagersInChannelBindingParameters, securityCredentialsManager)));
		}
		bindingParameters.Add(this);
	}

	void IEndpointBehavior.ApplyDispatchBehavior(ServiceEndpoint serviceEndpoint, EndpointDispatcher endpointDispatcher)
	{
		throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.Format(System.SR.SFXEndpointBehaviorUsedOnWrongSide, typeof(ClientCredentials).Name)));
	}

	public virtual void ApplyClientBehavior(ServiceEndpoint serviceEndpoint, ClientRuntime behavior)
	{
		if (serviceEndpoint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serviceEndpoint");
		}
		if (serviceEndpoint.Binding == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("serviceEndpoint.Binding");
		}
		serviceEndpoint.Binding.CreateBindingElements().Find<SecurityBindingElement>();
	}

	internal void MakeReadOnly()
	{
		_isReadOnly = true;
		if (_clientCertificate != null)
		{
			_clientCertificate.MakeReadOnly();
		}
		if (_serviceCertificate != null)
		{
			_serviceCertificate.MakeReadOnly();
		}
		if (_userName != null)
		{
			_userName.MakeReadOnly();
		}
		if (_windows != null)
		{
			_windows.MakeReadOnly();
		}
		if (_httpDigest != null)
		{
			_httpDigest.MakeReadOnly();
		}
	}
}
