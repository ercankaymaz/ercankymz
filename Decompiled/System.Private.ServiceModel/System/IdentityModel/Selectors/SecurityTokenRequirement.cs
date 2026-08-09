using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Runtime;

namespace System.IdentityModel.Selectors;

public class SecurityTokenRequirement
{
	private const string Namespace = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement";

	private const string tokenTypeProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/TokenType";

	private const string keyUsageProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeyUsage";

	private const string keyTypeProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeyType";

	private const string keySizeProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeySize";

	private const string requireCryptographicTokenProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/RequireCryptographicToken";

	private const string peerAuthenticationMode = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/PeerAuthenticationMode";

	private const string isOptionalTokenProperty = "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/IsOptionalTokenProperty";

	private const bool defaultRequireCryptographicToken = false;

	private const SecurityKeyUsage defaultKeyUsage = SecurityKeyUsage.Signature;

	private const SecurityKeyType defaultKeyType = SecurityKeyType.SymmetricKey;

	private const int defaultKeySize = 0;

	private const bool defaultIsOptionalToken = false;

	private Dictionary<string, object> _properties;

	public static string TokenTypeProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/TokenType";

	public static string KeyUsageProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeyUsage";

	public static string KeyTypeProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeyType";

	public static string KeySizeProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/KeySize";

	public static string RequireCryptographicTokenProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/RequireCryptographicToken";

	public static string PeerAuthenticationMode => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/PeerAuthenticationMode";

	public static string IsOptionalTokenProperty => "http://schemas.microsoft.com/ws/2006/05/identitymodel/securitytokenrequirement/IsOptionalTokenProperty";

	public string TokenType
	{
		get
		{
			if (!TryGetProperty<string>(TokenTypeProperty, out var result))
			{
				return null;
			}
			return result;
		}
		set
		{
			_properties[TokenTypeProperty] = value;
		}
	}

	internal bool IsOptionalToken
	{
		get
		{
			if (!TryGetProperty<bool>(IsOptionalTokenProperty, out var result))
			{
				return false;
			}
			return result;
		}
		set
		{
			_properties[IsOptionalTokenProperty] = value;
		}
	}

	public bool RequireCryptographicToken
	{
		get
		{
			if (!TryGetProperty<bool>(RequireCryptographicTokenProperty, out var result))
			{
				return false;
			}
			return result;
		}
		set
		{
			_properties[RequireCryptographicTokenProperty] = value;
		}
	}

	public SecurityKeyUsage KeyUsage
	{
		get
		{
			if (!TryGetProperty<SecurityKeyUsage>(KeyUsageProperty, out var result))
			{
				return SecurityKeyUsage.Signature;
			}
			return result;
		}
		set
		{
			SecurityKeyUsageHelper.Validate(value);
			_properties[KeyUsageProperty] = value;
		}
	}

	public SecurityKeyType KeyType
	{
		get
		{
			if (!TryGetProperty<SecurityKeyType>(KeyTypeProperty, out var result))
			{
				return SecurityKeyType.SymmetricKey;
			}
			return result;
		}
		set
		{
			SecurityKeyTypeHelper.Validate(value);
			_properties[KeyTypeProperty] = value;
		}
	}

	public int KeySize
	{
		get
		{
			if (!TryGetProperty<int>(KeySizeProperty, out var result))
			{
				return 0;
			}
			return result;
		}
		set
		{
			if (value < 0)
			{
				throw Fx.Exception.ArgumentOutOfRange("value", value, System.SR.ValueMustBeNonNegative);
			}
			Properties[KeySizeProperty] = value;
		}
	}

	public IDictionary<string, object> Properties => _properties;

	public SecurityTokenRequirement()
	{
		_properties = new Dictionary<string, object>();
		Initialize();
	}

	private void Initialize()
	{
		KeyType = SecurityKeyType.SymmetricKey;
		KeyUsage = SecurityKeyUsage.Signature;
		RequireCryptographicToken = false;
		KeySize = 0;
		IsOptionalToken = false;
	}

	public TValue GetProperty<TValue>(string propertyName)
	{
		if (!TryGetProperty<TValue>(propertyName, out var result))
		{
			throw Fx.Exception.Argument(propertyName, string.Format(System.SR.SecurityTokenRequirementDoesNotContainProperty, propertyName));
		}
		return result;
	}

	public bool TryGetProperty<TValue>(string propertyName, out TValue result)
	{
		if (!Properties.TryGetValue(propertyName, out var value))
		{
			result = default(TValue);
			return false;
		}
		if (value != null && !typeof(TValue).IsAssignableFrom(value.GetType()))
		{
			throw Fx.Exception.Argument(propertyName, string.Format(System.SR.SecurityTokenRequirementHasInvalidTypeForProperty, propertyName, value.GetType(), typeof(TValue)));
		}
		result = (TValue)value;
		return true;
	}
}
