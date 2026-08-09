using System.Collections.Generic;
using System.IdentityModel.Policy;
using System.Security.Claims;
using System.Security.Principal;
using System.ServiceModel;

namespace System.IdentityModel.Claims;

public class WindowsClaimSet : ClaimSet, IIdentityInfo, IDisposable
{
	internal const bool DefaultIncludeWindowsGroups = true;

	private WindowsIdentity _windowsIdentity;

	private bool _includeWindowsGroups;

	private IList<Claim> _claims;

	private bool _disposed;

	private string _authenticationType;

	public override Claim this[int index]
	{
		get
		{
			ThrowIfDisposed();
			EnsureClaims();
			return _claims[index];
		}
	}

	public override int Count
	{
		get
		{
			ThrowIfDisposed();
			EnsureClaims();
			return _claims.Count;
		}
	}

	IIdentity IIdentityInfo.Identity
	{
		get
		{
			ThrowIfDisposed();
			return (IIdentity)_windowsIdentity;
		}
	}

	public WindowsIdentity WindowsIdentity
	{
		get
		{
			ThrowIfDisposed();
			return _windowsIdentity;
		}
	}

	public override ClaimSet Issuer => ClaimSet.Windows;

	public DateTime ExpirationTime { get; }

	public WindowsClaimSet(WindowsIdentity windowsIdentity)
		: this(windowsIdentity, includeWindowsGroups: true)
	{
	}

	public WindowsClaimSet(WindowsIdentity windowsIdentity, bool includeWindowsGroups)
		: this(windowsIdentity, includeWindowsGroups, DateTime.UtcNow.AddHours(10.0))
	{
	}

	public WindowsClaimSet(WindowsIdentity windowsIdentity, DateTime expirationTime)
		: this(windowsIdentity, includeWindowsGroups: true, expirationTime)
	{
	}

	public WindowsClaimSet(WindowsIdentity windowsIdentity, bool includeWindowsGroups, DateTime expirationTime)
		: this(windowsIdentity, null, includeWindowsGroups, expirationTime, clone: true)
	{
	}

	public WindowsClaimSet(WindowsIdentity windowsIdentity, string authenticationType, bool includeWindowsGroups, DateTime expirationTime)
		: this(windowsIdentity, authenticationType, includeWindowsGroups, expirationTime, clone: true)
	{
	}

	internal WindowsClaimSet(WindowsIdentity windowsIdentity, string authenticationType, bool includeWindowsGroups, bool clone)
		: this(windowsIdentity, authenticationType, includeWindowsGroups, DateTime.UtcNow.AddHours(10.0), clone)
	{
	}

	internal WindowsClaimSet(WindowsIdentity windowsIdentity, string authenticationType, bool includeWindowsGroups, DateTime expirationTime, bool clone)
	{
		if (windowsIdentity == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("windowsIdentity");
		}
		_windowsIdentity = (clone ? SecurityUtils.CloneWindowsIdentityIfNecessary(windowsIdentity, authenticationType) : windowsIdentity);
		_includeWindowsGroups = includeWindowsGroups;
		ExpirationTime = expirationTime;
		_authenticationType = authenticationType;
	}

	private WindowsClaimSet(WindowsClaimSet from)
		: this(from.WindowsIdentity, from._authenticationType, from._includeWindowsGroups, from.ExpirationTime, clone: true)
	{
	}

	internal WindowsClaimSet Clone()
	{
		ThrowIfDisposed();
		return new WindowsClaimSet(this);
	}

	public void Dispose()
	{
		if (!_disposed)
		{
			_disposed = true;
			_windowsIdentity.Dispose();
		}
	}

	private IList<Claim> InitializeClaimsCore()
	{
		if (_windowsIdentity.AccessToken == null)
		{
			return new List<Claim>();
		}
		List<Claim> list = new List<Claim>(3);
		list.Add(new Claim(ClaimTypes.Sid, _windowsIdentity.User, Rights.Identity));
		if (TryCreateWindowsSidClaim(_windowsIdentity, out var claim))
		{
			list.Add(claim);
		}
		list.Add(Claim.CreateNameClaim(((ClaimsIdentity)(object)_windowsIdentity).Name));
		_ = _includeWindowsGroups;
		return list;
	}

	private void EnsureClaims()
	{
		if (_claims == null)
		{
			_claims = InitializeClaimsCore();
		}
	}

	private void ThrowIfDisposed()
	{
		if (_disposed)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ObjectDisposedException(GetType().FullName));
		}
	}

	private static bool SupportedClaimType(string claimType)
	{
		if (claimType != null && !(ClaimTypes.Sid == claimType) && !(ClaimTypes.DenyOnlySid == claimType))
		{
			return ClaimTypes.Name == claimType;
		}
		return true;
	}

	public override IEnumerable<Claim> FindClaims(string claimType, string right)
	{
		ThrowIfDisposed();
		if (!SupportedClaimType(claimType) || !ClaimSet.SupportedRight(right))
		{
			yield break;
		}
		if (_claims == null && (ClaimTypes.Sid == claimType || ClaimTypes.DenyOnlySid == claimType))
		{
			if (ClaimTypes.Sid == claimType && (right == null || Rights.Identity == right))
			{
				yield return new Claim(ClaimTypes.Sid, _windowsIdentity.User, Rights.Identity);
			}
			if ((right == null || Rights.PossessProperty == right) && TryCreateWindowsSidClaim(_windowsIdentity, out var claim) && claimType == claim.ClaimType)
			{
				yield return claim;
			}
			if (_includeWindowsGroups && right != null && !(Rights.PossessProperty == right))
			{
			}
			yield break;
		}
		EnsureClaims();
		bool anyClaimType = claimType == null;
		bool anyRight = right == null;
		int i = 0;
		while (i < _claims.Count)
		{
			Claim claim2 = _claims[i];
			if (claim2 != null && (anyClaimType || claimType == claim2.ClaimType) && (anyRight || right == claim2.Right))
			{
				yield return claim2;
			}
			int num = i + 1;
			i = num;
		}
	}

	public override IEnumerator<Claim> GetEnumerator()
	{
		ThrowIfDisposed();
		EnsureClaims();
		return _claims.GetEnumerator();
	}

	public override string ToString()
	{
		if (!_disposed)
		{
			return SecurityUtils.ClaimSetToString(this);
		}
		return base.ToString();
	}

	public static bool TryCreateWindowsSidClaim(WindowsIdentity windowsIdentity, out Claim claim)
	{
		throw ExceptionHelper.PlatformNotSupported("CreateWindowsSidClaim is not yet supported");
	}
}
