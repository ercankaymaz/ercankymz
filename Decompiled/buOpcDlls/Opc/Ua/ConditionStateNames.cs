using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public static class ConditionStateNames
{
	public const string Disabled = "Disabled";

	public const string Enabled = "Enabled";

	public const string Inactive = "Inactive";

	public const string Active = "Active";

	public const string Unacknowledged = "Unacknowledged";

	public const string Acknowledged = "Acknowledged";

	public const string Unconfirmed = "Unconfirmed";

	public const string Confirmed = "Confirmed";

	public const string Unsuppressed = "Unsuppressed";

	public const string Suppressed = "Suppressed";

	public const string HighHighActive = "HighHighActive";

	public const string HighActive = "HighActive";

	public const string LowActive = "LowActive";

	public const string LowLowActive = "LowLowActive";
}
