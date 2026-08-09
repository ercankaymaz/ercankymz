using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IdentityModel.Claims;
using System.IdentityModel.Policy;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;

namespace System.IdentityModel;

internal static class SecurityUtils
{
	public const string Identities = "Identities";

	private static IIdentity s_anonymousIdentity;

	public const string AuthTypeNTLM = "NTLM";

	public const string AuthTypeNegotiate = "Negotiate";

	public const string AuthTypeKerberos = "Kerberos";

	public const string AuthTypeAnonymous = "";

	public const string AuthTypeCertMap = "SSL/PCT";

	public const string AuthTypeBasic = "Basic";

	internal static IIdentity AnonymousIdentity
	{
		get
		{
			if (s_anonymousIdentity == null)
			{
				s_anonymousIdentity = CreateIdentity(string.Empty);
			}
			return s_anonymousIdentity;
		}
	}

	public static DateTime MaxUtcDateTime
	{
		get
		{
			DateTime maxValue = DateTime.MaxValue;
			return new DateTime(maxValue.Ticks - 864000000000L, DateTimeKind.Utc);
		}
	}

	public static DateTime MinUtcDateTime
	{
		get
		{
			DateTime minValue = DateTime.MinValue;
			return new DateTime(minValue.Ticks + 864000000000L, DateTimeKind.Utc);
		}
	}

	internal static IIdentity CreateIdentity(string name, string authenticationType)
	{
		return new GenericIdentity(name, authenticationType);
	}

	internal static IIdentity CreateIdentity(string name)
	{
		return new GenericIdentity(name);
	}

	internal static byte[] CloneBuffer(byte[] buffer)
	{
		return CloneBuffer(buffer, 0, buffer.Length);
	}

	internal static byte[] CloneBuffer(byte[] buffer, int offset, int len)
	{
		byte[] array = Fx.AllocateByteArray(len);
		Buffer.BlockCopy(buffer, offset, array, 0, len);
		return array;
	}

	internal static bool MatchesBuffer(byte[] src, byte[] dst)
	{
		return MatchesBuffer(src, 0, dst, 0);
	}

	internal static bool MatchesBuffer(byte[] src, int srcOffset, byte[] dst, int dstOffset)
	{
		if (dstOffset < 0 || srcOffset < 0)
		{
			return false;
		}
		if (src == null || srcOffset >= src.Length)
		{
			return false;
		}
		if (dst == null || dstOffset >= dst.Length)
		{
			return false;
		}
		if (src.Length - srcOffset != dst.Length - dstOffset)
		{
			return false;
		}
		int num = srcOffset;
		int num2 = dstOffset;
		while (num < src.Length)
		{
			if (src[num] != dst[num2])
			{
				return false;
			}
			num++;
			num2++;
		}
		return true;
	}

	internal static ReadOnlyCollection<IAuthorizationPolicy> CreateAuthorizationPolicies(ClaimSet claimSet)
	{
		return CreateAuthorizationPolicies(claimSet, MaxUtcDateTime);
	}

	internal static ReadOnlyCollection<IAuthorizationPolicy> CreateAuthorizationPolicies(ClaimSet claimSet, DateTime expirationTime)
	{
		List<IAuthorizationPolicy> list = new List<IAuthorizationPolicy>(1);
		list.Add(new UnconditionalPolicy(claimSet, expirationTime));
		return list.AsReadOnly();
	}

	internal static AuthorizationContext CreateDefaultAuthorizationContext(IList<IAuthorizationPolicy> authorizationPolicies)
	{
		if (authorizationPolicies != null && authorizationPolicies.Count == 1 && authorizationPolicies[0] is UnconditionalPolicy)
		{
			return new SimpleAuthorizationContext(authorizationPolicies);
		}
		if (authorizationPolicies == null || authorizationPolicies.Count <= 0)
		{
			return DefaultAuthorizationContext.Empty;
		}
		DefaultEvaluationContext defaultEvaluationContext = new DefaultEvaluationContext();
		object[] array = new object[authorizationPolicies.Count];
		object obj = new object();
		int generation;
		do
		{
			generation = defaultEvaluationContext.Generation;
			for (int i = 0; i < authorizationPolicies.Count; i++)
			{
				if (array[i] != obj)
				{
					IAuthorizationPolicy authorizationPolicy = authorizationPolicies[i];
					if (authorizationPolicy == null)
					{
						array[i] = obj;
					}
					else if (authorizationPolicy.Evaluate(defaultEvaluationContext, ref array[i]))
					{
						array[i] = obj;
					}
				}
			}
		}
		while (generation < defaultEvaluationContext.Generation);
		return new DefaultAuthorizationContext(defaultEvaluationContext);
	}

	internal static string ClaimSetToString(ClaimSet claimSet)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.AppendLine("ClaimSet [");
		for (int i = 0; i < claimSet.Count; i++)
		{
			System.IdentityModel.Claims.Claim claim = claimSet[i];
			if (claim != null)
			{
				stringBuilder.Append("  ");
				stringBuilder.AppendLine(claim.ToString());
			}
		}
		string arg = "] by ";
		ClaimSet claimSet2 = claimSet;
		do
		{
			claimSet2 = claimSet2.Issuer;
			stringBuilder.AppendFormat("{0}{1}", arg, (claimSet2 == claimSet) ? "Self" : ((claimSet2.Count <= 0) ? "Unknown" : claimSet2[0].ToString()));
			arg = " -> ";
		}
		while (claimSet2.Issuer != claimSet2);
		return stringBuilder.ToString();
	}

	internal static IIdentity CloneIdentityIfNecessary(IIdentity identity)
	{
		if (identity != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return identity;
	}

	internal static WindowsIdentity CloneWindowsIdentityIfNecessary(WindowsIdentity wid)
	{
		return CloneWindowsIdentityIfNecessary(wid, ((ClaimsIdentity)(object)wid).AuthenticationType);
	}

	internal static WindowsIdentity CloneWindowsIdentityIfNecessary(WindowsIdentity wid, string authenticationType)
	{
		if (wid != null)
		{
			IntPtr token = ((SafeHandle)(object)wid.AccessToken).DangerousGetHandle();
			return UnsafeCreateWindowsIdentityFromToken(token, authenticationType);
		}
		return wid;
	}

	private static IntPtr UnsafeGetWindowsIdentityToken(WindowsIdentity wid)
	{
		return ((SafeHandle)(object)wid.AccessToken).DangerousGetHandle();
	}

	private static WindowsIdentity UnsafeCreateWindowsIdentityFromToken(IntPtr token, string authenticationType)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected O, but got Unknown
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		if (authenticationType == null)
		{
			return new WindowsIdentity(token);
		}
		return new WindowsIdentity(token, authenticationType);
	}

	internal static ClaimSet CloneClaimSetIfNecessary(ClaimSet claimSet)
	{
		if (claimSet != null)
		{
			throw ExceptionHelper.PlatformNotSupported();
		}
		return claimSet;
	}

	internal static ReadOnlyCollection<ClaimSet> CloneClaimSetsIfNecessary(ReadOnlyCollection<ClaimSet> claimSets)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static void DisposeClaimSetIfNecessary(ClaimSet claimSet)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static void DisposeClaimSetsIfNecessary(ReadOnlyCollection<ClaimSet> claimSets)
	{
		throw ExceptionHelper.PlatformNotSupported();
	}

	internal static string GetCertificateId(X509Certificate2 certificate)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		AppendCertificateIdentityName(stringBuilder, certificate);
		return stringBuilder.ToString();
	}

	internal static void AppendCertificateIdentityName(StringBuilder str, X509Certificate2 certificate)
	{
		string text = certificate.SubjectName.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = certificate.GetNameInfo(X509NameType.DnsName, forIssuer: false);
			if (string.IsNullOrEmpty(text))
			{
				text = certificate.GetNameInfo(X509NameType.SimpleName, forIssuer: false);
				if (string.IsNullOrEmpty(text))
				{
					text = certificate.GetNameInfo(X509NameType.EmailName, forIssuer: false);
					if (string.IsNullOrEmpty(text))
					{
						text = certificate.GetNameInfo(X509NameType.UpnName, forIssuer: false);
					}
				}
			}
		}
		str.Append(string.IsNullOrEmpty(text) ? "<x509>" : text);
		str.Append("; ");
		str.Append(certificate.Thumbprint);
	}

	internal static bool TryCreateX509CertificateFromRawData(byte[] rawData, out X509Certificate2 certificate)
	{
		certificate = ((rawData == null || rawData.Length == 0) ? null : new X509Certificate2(rawData));
		if (certificate != null)
		{
			return certificate.Handle != IntPtr.Zero;
		}
		return false;
	}

	internal static ReadOnlyCollection<IAuthorizationPolicy> CloneAuthorizationPoliciesIfNecessary(ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		if (authorizationPolicies != null && authorizationPolicies.Count > 0)
		{
			bool flag = false;
			for (int i = 0; i < authorizationPolicies.Count; i++)
			{
				if (authorizationPolicies[i] is UnconditionalPolicy { IsDisposable: not false })
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				List<IAuthorizationPolicy> list = new List<IAuthorizationPolicy>(authorizationPolicies.Count);
				for (int j = 0; j < authorizationPolicies.Count; j++)
				{
					if (authorizationPolicies[j] is UnconditionalPolicy unconditionalPolicy2)
					{
						list.Add(unconditionalPolicy2.Clone());
					}
					else
					{
						list.Add(authorizationPolicies[j]);
					}
				}
				return new ReadOnlyCollection<IAuthorizationPolicy>(list);
			}
		}
		return authorizationPolicies;
	}

	public static void DisposeAuthorizationPoliciesIfNecessary(ReadOnlyCollection<IAuthorizationPolicy> authorizationPolicies)
	{
		if (authorizationPolicies != null && authorizationPolicies.Count > 0)
		{
			for (int i = 0; i < authorizationPolicies.Count; i++)
			{
				DisposeIfNecessary(authorizationPolicies[i] as UnconditionalPolicy);
			}
		}
	}

	public static void DisposeIfNecessary(IDisposable obj)
	{
		obj?.Dispose();
	}

	internal static void ResetAllCertificates(X509Certificate2Collection certificates)
	{
		if (certificates != null)
		{
			for (int i = 0; i < certificates.Count; i++)
			{
				ResetCertificate(certificates[i]);
			}
		}
	}

	internal static void ResetCertificate(X509Certificate2 certificate)
	{
		certificate.Dispose();
	}
}
