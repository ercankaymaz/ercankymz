using System.Collections.Generic;
using System.Globalization;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

[DataContract(Namespace = "http://schemas.xmlsoap.org/ws/2005/05/identity")]
public class Claim
{
	private static Claim s_system;

	[DataMember(Name = "ClaimType")]
	private string _claimType;

	[DataMember(Name = "Resource")]
	private object _resource;

	[DataMember(Name = "Right")]
	private string _right;

	private IEqualityComparer<Claim> _comparer;

	public static IEqualityComparer<Claim> DefaultComparer => EqualityComparer<Claim>.Default;

	public static Claim System
	{
		get
		{
			if (s_system == null)
			{
				s_system = new Claim(ClaimTypes.System, "System", Rights.Identity);
			}
			return s_system;
		}
	}

	public object Resource => _resource;

	public string ClaimType => _claimType;

	public string Right => _right;

	private Claim(string claimType, object resource, string right, IEqualityComparer<Claim> comparer)
	{
		if (claimType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claimType");
		}
		if (claimType.Length <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("claimType", global::System.SR.ArgumentCannotBeEmptyString);
		}
		if (right == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("right");
		}
		if (right.Length <= 0)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgument("right", global::System.SR.ArgumentCannotBeEmptyString);
		}
		_claimType = claimType;
		_resource = resource;
		_right = right;
		_comparer = comparer;
	}

	public Claim(string claimType, object resource, string right)
		: this(claimType, resource, right, null)
	{
	}

	public static Claim CreateDnsClaim(string dns)
	{
		if (dns == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("dns");
		}
		return new Claim(ClaimTypes.Dns, dns, Rights.PossessProperty, ClaimComparer.Dns);
	}

	public static Claim CreateHashClaim(byte[] hash)
	{
		if (hash == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("hash");
		}
		return new Claim(ClaimTypes.Hash, SecurityUtils.CloneBuffer(hash), Rights.PossessProperty, ClaimComparer.Hash);
	}

	public static Claim CreateNameClaim(string name)
	{
		if (name == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
		}
		return new Claim(ClaimTypes.Name, name, Rights.PossessProperty);
	}

	public static Claim CreateSpnClaim(string spn)
	{
		if (spn == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("spn");
		}
		return new Claim(ClaimTypes.Spn, spn, Rights.PossessProperty);
	}

	public static Claim CreateThumbprintClaim(byte[] thumbprint)
	{
		if (thumbprint == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("thumbprint");
		}
		return new Claim(ClaimTypes.Thumbprint, SecurityUtils.CloneBuffer(thumbprint), Rights.PossessProperty, ClaimComparer.Thumbprint);
	}

	public static Claim CreateUpnClaim(string upn)
	{
		if (upn == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("upn");
		}
		return new Claim(ClaimTypes.Upn, upn, Rights.PossessProperty, ClaimComparer.Upn);
	}

	public static Claim CreateUriClaim(Uri uri)
	{
		if (uri == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("uri");
		}
		return new Claim(ClaimTypes.Uri, uri, Rights.PossessProperty);
	}

	public static Claim CreateWindowsSidClaim(SecurityIdentifier sid)
	{
		if (sid == (SecurityIdentifier)null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("sid");
		}
		return new Claim(ClaimTypes.Sid, sid, Rights.PossessProperty);
	}

	public static Claim CreateX500DistinguishedNameClaim(X500DistinguishedName x500DistinguishedName)
	{
		if (x500DistinguishedName == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("x500DistinguishedName");
		}
		return new Claim(ClaimTypes.X500DistinguishedName, x500DistinguishedName, Rights.PossessProperty, ClaimComparer.X500DistinguishedName);
	}

	public override bool Equals(object obj)
	{
		if (_comparer == null)
		{
			_comparer = ClaimComparer.GetComparer(_claimType);
		}
		return _comparer.Equals(this, obj as Claim);
	}

	public override int GetHashCode()
	{
		if (_comparer == null)
		{
			_comparer = ClaimComparer.GetComparer(_claimType);
		}
		return _comparer.GetHashCode(this);
	}

	public override string ToString()
	{
		return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", _right, _claimType);
	}
}
