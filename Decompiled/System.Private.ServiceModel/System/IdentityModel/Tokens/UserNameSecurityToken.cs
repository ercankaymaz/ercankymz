using System.Collections.ObjectModel;
using System.Runtime;

namespace System.IdentityModel.Tokens;

public class UserNameSecurityToken : SecurityToken
{
	private string _id;

	private string _userName;

	private DateTime _effectiveTime;

	public override string Id => _id;

	public override ReadOnlyCollection<SecurityKey> SecurityKeys => EmptyReadOnlyCollection<SecurityKey>.Instance;

	public override DateTime ValidFrom => _effectiveTime;

	public override DateTime ValidTo => SecurityUtils.MaxUtcDateTime;

	public string UserName => _userName;

	public string Password { get; }

	public UserNameSecurityToken(string userName, string password)
		: this(userName, password, SecurityUniqueId.Create().Value)
	{
	}

	public UserNameSecurityToken(string userName, string password, string id)
	{
		if (userName == null)
		{
			throw Fx.Exception.ArgumentNull("userName");
		}
		if (userName == string.Empty)
		{
			throw Fx.Exception.Argument("userName", System.SR.UserNameCannotBeEmpty);
		}
		_userName = userName;
		Password = password;
		_id = id;
		_effectiveTime = DateTime.UtcNow;
	}
}
