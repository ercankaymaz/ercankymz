using System.Collections.ObjectModel;
using System.IdentityModel.Policy;
using System.IdentityModel.Tokens;
using System.Runtime;
using System.Runtime.Diagnostics;
using System.ServiceModel;

namespace System.IdentityModel.Selectors;

public abstract class SecurityTokenAuthenticator
{
	public bool CanValidateToken(SecurityToken token)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		return CanValidateTokenCore(token);
	}

	public ReadOnlyCollection<IAuthorizationPolicy> ValidateToken(SecurityToken token)
	{
		if (token == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("token");
		}
		if (!CanValidateToken(token))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenValidationException(System.SR.Format(System.SR.CannotValidateSecurityTokenType, this, token.GetType())));
		}
		EventTraceActivity eventTraceActivity = null;
		string text = null;
		if (WcfEventSource.Instance.TokenValidationStartedIsEnabled())
		{
			eventTraceActivity = eventTraceActivity ?? EventTraceActivity.GetFromThreadOrCreate();
			text = text ?? token.GetType().ToString();
			WcfEventSource.Instance.TokenValidationStarted(eventTraceActivity, text, token.Id);
		}
		ReadOnlyCollection<IAuthorizationPolicy> readOnlyCollection = ValidateTokenCore(token);
		if (readOnlyCollection == null)
		{
			string text2 = System.SR.Format(System.SR.CannotValidateSecurityTokenType, this, token.GetType());
			if (WcfEventSource.Instance.TokenValidationFailureIsEnabled())
			{
				eventTraceActivity = eventTraceActivity ?? EventTraceActivity.GetFromThreadOrCreate();
				text = text ?? token.GetType().ToString();
				WcfEventSource.Instance.TokenValidationFailure(eventTraceActivity, text, token.Id, text2);
			}
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new SecurityTokenValidationException(text2));
		}
		if (WcfEventSource.Instance.TokenValidationSuccessIsEnabled())
		{
			eventTraceActivity = eventTraceActivity ?? EventTraceActivity.GetFromThreadOrCreate();
			text = text ?? token.GetType().ToString();
			WcfEventSource.Instance.TokenValidationSuccess(eventTraceActivity, text, token.Id);
		}
		return readOnlyCollection;
	}

	protected abstract bool CanValidateTokenCore(SecurityToken token);

	protected abstract ReadOnlyCollection<IAuthorizationPolicy> ValidateTokenCore(SecurityToken token);
}
