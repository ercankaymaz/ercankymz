using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.Threading.Tasks;

namespace System.IdentityModel.Selectors;

public class UserNameSecurityTokenProvider : SecurityTokenProvider
{
	private readonly UserNameSecurityToken _userNameToken;

	public UserNameSecurityTokenProvider(string userName, string password)
	{
		if (userName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("userName");
		}
		_userNameToken = new UserNameSecurityToken(userName, password);
	}

	protected override SecurityToken GetTokenCore(TimeSpan timeout)
	{
		return _userNameToken;
	}

	internal override Task<SecurityToken> GetTokenCoreInternalAsync(TimeSpan timeout)
	{
		return Task.FromResult((SecurityToken)_userNameToken);
	}
}
