using System.IdentityModel.Tokens;

namespace System.IdentityModel.Selectors;

internal static class EmptySecurityTokenResolver
{
	public static SecurityTokenResolver Instance { get; } = SecurityTokenResolver.CreateDefaultSecurityTokenResolver(EmptyReadOnlyCollection<SecurityToken>.Instance, canMatchLocalId: false);
}
