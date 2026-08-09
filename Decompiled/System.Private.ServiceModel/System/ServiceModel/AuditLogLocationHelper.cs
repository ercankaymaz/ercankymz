using System.ComponentModel;
using System.ServiceModel.Security;

namespace System.ServiceModel;

internal static class AuditLogLocationHelper
{
	public static bool IsDefined(AuditLogLocation auditLogLocation)
	{
		if (auditLogLocation == AuditLogLocation.Security && !SecurityAuditHelper.IsSecurityAuditSupported)
		{
			throw ExceptionHelper.PlatformNotSupported(System.SR.SecurityAuditPlatformNotSupported);
		}
		if (auditLogLocation != AuditLogLocation.Default && auditLogLocation != AuditLogLocation.Application)
		{
			return auditLogLocation == AuditLogLocation.Security;
		}
		return true;
	}

	public static void Validate(AuditLogLocation value)
	{
		if (!IsDefined(value))
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidEnumArgumentException("value", (int)value, typeof(AuditLogLocation)));
		}
	}
}
