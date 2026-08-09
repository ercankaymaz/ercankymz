using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

internal class ClaimComparer : IEqualityComparer<Claim>
{
	private class ObjectComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object obj1, object obj2)
		{
			if (obj1 == null && obj2 == null)
			{
				return true;
			}
			if (obj1 == null || obj2 == null)
			{
				return false;
			}
			return obj1.Equals(obj2);
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			return obj?.GetHashCode() ?? 0;
		}
	}

	private class BinaryObjectComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object obj1, object obj2)
		{
			if (obj1 == obj2)
			{
				return true;
			}
			byte[] array = obj1 as byte[];
			byte[] array2 = obj2 as byte[];
			if (array == null || array2 == null)
			{
				return false;
			}
			if (array.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			if (!(obj is byte[] array))
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < array.Length && i < 4; i++)
			{
				num = (num << 8) | array[i];
			}
			return num ^ array.Length;
		}
	}

	private class RsaObjectComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object obj1, object obj2)
		{
			if (obj1 == obj2)
			{
				return true;
			}
			throw ExceptionHelper.PlatformNotSupported();
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	private class X500DistinguishedNameObjectComparer : IEqualityComparer
	{
		private IEqualityComparer _binaryComparer;

		public X500DistinguishedNameObjectComparer()
		{
			_binaryComparer = new BinaryObjectComparer();
		}

		bool IEqualityComparer.Equals(object obj1, object obj2)
		{
			if (obj1 == obj2)
			{
				return true;
			}
			throw ExceptionHelper.PlatformNotSupported();
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
	}

	private class UpnObjectComparer : IEqualityComparer
	{
		bool IEqualityComparer.Equals(object obj1, object obj2)
		{
			if (StringComparer.OrdinalIgnoreCase.Equals(obj1 as string, obj2 as string))
			{
				return true;
			}
			string text = obj1 as string;
			string text2 = obj2 as string;
			if (text == null || text2 == null)
			{
				return false;
			}
			if (!TryLookupSidFromName(text, out var sid))
			{
				return false;
			}
			if (!TryLookupSidFromName(text2, out var sid2))
			{
				return false;
			}
			return sid == sid2;
		}

		int IEqualityComparer.GetHashCode(object obj)
		{
			if (!(obj is string text))
			{
				return 0;
			}
			if (TryLookupSidFromName(text, out var sid))
			{
				return ((object)sid).GetHashCode();
			}
			return StringComparer.OrdinalIgnoreCase.GetHashCode(text);
		}

		private bool TryLookupSidFromName(string upn, out SecurityIdentifier sid)
		{
			//IL_0004: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Expected O, but got Unknown
			sid = null;
			try
			{
				NTAccount val = new NTAccount(upn);
				IdentityReference obj = ((IdentityReference)val).Translate(typeof(SecurityIdentifier));
				sid = (SecurityIdentifier)(object)((obj is SecurityIdentifier) ? obj : null);
			}
			catch (IdentityNotMappedException)
			{
			}
			return sid != (SecurityIdentifier)null;
		}
	}

	private static IEqualityComparer<Claim> s_defaultComparer;

	private static IEqualityComparer<Claim> s_hashComparer;

	private static IEqualityComparer<Claim> s_dnsComparer;

	private static IEqualityComparer<Claim> s_rsaComparer;

	private static IEqualityComparer<Claim> s_thumbprintComparer;

	private static IEqualityComparer<Claim> s_upnComparer;

	private static IEqualityComparer<Claim> s_x500DistinguishedNameComparer;

	private IEqualityComparer _resourceComparer;

	public static IEqualityComparer<Claim> Default
	{
		get
		{
			if (s_defaultComparer == null)
			{
				s_defaultComparer = new ClaimComparer(new ObjectComparer());
			}
			return s_defaultComparer;
		}
	}

	public static IEqualityComparer<Claim> Dns
	{
		get
		{
			if (s_dnsComparer == null)
			{
				s_dnsComparer = new ClaimComparer(StringComparer.OrdinalIgnoreCase);
			}
			return s_dnsComparer;
		}
	}

	public static IEqualityComparer<Claim> Hash
	{
		get
		{
			if (s_hashComparer == null)
			{
				s_hashComparer = new ClaimComparer(new BinaryObjectComparer());
			}
			return s_hashComparer;
		}
	}

	public static IEqualityComparer<Claim> Rsa
	{
		get
		{
			if (s_rsaComparer == null)
			{
				s_rsaComparer = new ClaimComparer(new RsaObjectComparer());
			}
			return s_rsaComparer;
		}
	}

	public static IEqualityComparer<Claim> Thumbprint
	{
		get
		{
			if (s_thumbprintComparer == null)
			{
				s_thumbprintComparer = new ClaimComparer(new BinaryObjectComparer());
			}
			return s_thumbprintComparer;
		}
	}

	public static IEqualityComparer<Claim> Upn
	{
		get
		{
			if (s_upnComparer == null)
			{
				s_upnComparer = new ClaimComparer(new UpnObjectComparer());
			}
			return s_upnComparer;
		}
	}

	public static IEqualityComparer<Claim> X500DistinguishedName
	{
		get
		{
			if (s_x500DistinguishedNameComparer == null)
			{
				s_x500DistinguishedNameComparer = new ClaimComparer(new X500DistinguishedNameObjectComparer());
			}
			return s_x500DistinguishedNameComparer;
		}
	}

	private ClaimComparer(IEqualityComparer resourceComparer)
	{
		_resourceComparer = resourceComparer;
	}

	public static IEqualityComparer<Claim> GetComparer(string claimType)
	{
		if (claimType == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claimType");
		}
		if (claimType == ClaimTypes.Dns)
		{
			return Dns;
		}
		if (claimType == ClaimTypes.Hash)
		{
			return Hash;
		}
		if (claimType == ClaimTypes.Rsa)
		{
			return Rsa;
		}
		if (claimType == ClaimTypes.Thumbprint)
		{
			return Thumbprint;
		}
		if (claimType == ClaimTypes.Upn)
		{
			return Upn;
		}
		if (claimType == ClaimTypes.X500DistinguishedName)
		{
			return X500DistinguishedName;
		}
		return Default;
	}

	public bool Equals(Claim claim1, Claim claim2)
	{
		if (claim1 == claim2)
		{
			return true;
		}
		if (claim1 == null || claim2 == null)
		{
			return false;
		}
		if (claim1.ClaimType != claim2.ClaimType || claim1.Right != claim2.Right)
		{
			return false;
		}
		return _resourceComparer.Equals(claim1.Resource, claim2.Resource);
	}

	public int GetHashCode(Claim claim)
	{
		if (claim == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("claim");
		}
		return claim.ClaimType.GetHashCode() ^ claim.Right.GetHashCode() ^ ((claim.Resource != null) ? _resourceComparer.GetHashCode(claim.Resource) : 0);
	}
}
