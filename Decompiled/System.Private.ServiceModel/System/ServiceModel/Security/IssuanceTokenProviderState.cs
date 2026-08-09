using System.IdentityModel.Tokens;

namespace System.ServiceModel.Security;

internal class IssuanceTokenProviderState : IDisposable
{
	private GenericXmlSecurityToken _serviceToken;

	public bool IsNegotiationCompleted { get; private set; }

	public GenericXmlSecurityToken ServiceToken
	{
		get
		{
			CheckCompleted();
			return _serviceToken;
		}
	}

	public EndpointAddress TargetAddress { get; set; }

	public EndpointAddress RemoteAddress { get; set; }

	public string Context { get; set; }

	public virtual void Dispose()
	{
	}

	public void SetServiceToken(GenericXmlSecurityToken serviceToken)
	{
		if (IsNegotiationCompleted)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.NegotiationIsCompleted));
		}
		_serviceToken = serviceToken;
		IsNegotiationCompleted = true;
	}

	private void CheckCompleted()
	{
		if (!IsNegotiationCompleted)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(System.SR.NegotiationIsNotCompleted));
		}
	}
}
