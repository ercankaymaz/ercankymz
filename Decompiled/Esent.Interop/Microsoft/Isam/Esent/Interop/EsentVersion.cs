using Microsoft.Isam.Esent.Interop.Implementation;

namespace Microsoft.Isam.Esent.Interop;

public static class EsentVersion
{
	public static bool SupportsServer2003Features => Capabilities.SupportsServer2003Features;

	public static bool SupportsVistaFeatures => Capabilities.SupportsVistaFeatures;

	public static bool SupportsWindows7Features => Capabilities.SupportsWindows7Features;

	public static bool SupportsWindows8Features => Capabilities.SupportsWindows8Features;

	public static bool SupportsWindows81Features => Capabilities.SupportsWindows81Features;

	public static bool SupportsWindows10Features => Capabilities.SupportsWindows10Features;

	public static bool SupportsUnicodePaths => Capabilities.SupportsUnicodePaths;

	public static bool SupportsLargeKeys => Capabilities.SupportsLargeKeys;

	private static JetCapabilities Capabilities => Api.Impl.Capabilities;
}
