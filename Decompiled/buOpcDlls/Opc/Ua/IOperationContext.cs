using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public interface IOperationContext
{
	NodeId SessionId { get; }

	IUserIdentity UserIdentity { get; }

	IList<string> PreferredLocales { get; }

	DiagnosticsMasks DiagnosticsMask { get; }

	StringTable StringTable { get; }

	DateTime OperationDeadline { get; }

	StatusCode OperationStatus { get; }

	string AuditEntryId { get; }
}
