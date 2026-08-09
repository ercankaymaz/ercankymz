using System.Resources;
using FxResources.System.Diagnostics.PerformanceCounter;

namespace System;

internal static class SR
{
	private static readonly bool s_usingResourceKeys = AppContext.TryGetSwitch("System.Resources.UseSystemResourceKeys", out var isEnabled) && isEnabled;

	private static ResourceManager s_resourceManager;

	internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(SR)));

	internal static string InvalidParameter => GetResourceString("InvalidParameter");

	internal static string CategoryHelpCorrupt => GetResourceString("CategoryHelpCorrupt");

	internal static string CounterNameCorrupt => GetResourceString("CounterNameCorrupt");

	internal static string CounterDataCorrupt => GetResourceString("CounterDataCorrupt");

	internal static string InstanceNameTooLong => GetResourceString("InstanceNameTooLong");

	internal static string ProcessLifetimeNotValidInGlobal => GetResourceString("ProcessLifetimeNotValidInGlobal");

	internal static string CountersOOM => GetResourceString("CountersOOM");

	internal static string MappingCorrupted => GetResourceString("MappingCorrupted");

	internal static string SingleInstanceOnly => GetResourceString("SingleInstanceOnly");

	internal static string MultiInstanceOnly => GetResourceString("MultiInstanceOnly");

	internal static string CantConvertProcessToGlobal => GetResourceString("CantConvertProcessToGlobal");

	internal static string CantConvertGlobalToProcess => GetResourceString("CantConvertGlobalToProcess");

	internal static string InstanceAlreadyExists => GetResourceString("InstanceAlreadyExists");

	internal static string SharedMemoryGhosted => GetResourceString("SharedMemoryGhosted");

	internal static string CantCreateFileMapping => GetResourceString("CantCreateFileMapping");

	internal static string CantMapFileView => GetResourceString("CantMapFileView");

	internal static string MismatchedCounterTypes => GetResourceString("MismatchedCounterTypes");

	internal static string PerfCounterPdhError => GetResourceString("PerfCounterPdhError");

	internal static string MustAddCounterCreationData => GetResourceString("MustAddCounterCreationData");

	internal static string CantReadInstance => GetResourceString("CantReadInstance");

	internal static string CantReadCategoryIndex => GetResourceString("CantReadCategoryIndex");

	internal static string CounterLayout => GetResourceString("CounterLayout");

	internal static string CantReadCounter => GetResourceString("CantReadCounter");

	internal static string HelpNotAvailable => GetResourceString("HelpNotAvailable");

	internal static string MissingCategory => GetResourceString("MissingCategory");

	internal static string MissingCounter => GetResourceString("MissingCounter");

	internal static string CantChangeCategoryRegistration => GetResourceString("CantChangeCategoryRegistration");

	internal static string InvalidProperty => GetResourceString("InvalidProperty");

	internal static string CategoryNameNotSet => GetResourceString("CategoryNameNotSet");

	internal static string PerformanceCategoryExists => GetResourceString("PerformanceCategoryExists");

	internal static string PerfInvalidCategoryName => GetResourceString("PerfInvalidCategoryName");

	internal static string CategoryNameTooLong => GetResourceString("CategoryNameTooLong");

	internal static string PerfInvalidCounterName => GetResourceString("PerfInvalidCounterName");

	internal static string PerfInvalidHelp => GetResourceString("PerfInvalidHelp");

	internal static string InvalidCounterName => GetResourceString("InvalidCounterName");

	internal static string DuplicateCounterName => GetResourceString("DuplicateCounterName");

	internal static string CantDeleteCategory => GetResourceString("CantDeleteCategory");

	internal static string InstanceNameRequired => GetResourceString("InstanceNameRequired");

	internal static string MissingInstance => GetResourceString("MissingInstance");

	internal static string CantSetLifetimeAfterInitialized => GetResourceString("CantSetLifetimeAfterInitialized");

	internal static string ReadOnlyCounter => GetResourceString("ReadOnlyCounter");

	internal static string PCNotSupportedUnderAppContainer => GetResourceString("PCNotSupportedUnderAppContainer");

	internal static string CategoryNameMissing => GetResourceString("CategoryNameMissing");

	internal static string CounterNameMissing => GetResourceString("CounterNameMissing");

	internal static string InstanceLifetimeProcessonReadOnly => GetResourceString("InstanceLifetimeProcessonReadOnly");

	internal static string RemoteWriting => GetResourceString("RemoteWriting");

	internal static string NotCustomCounter => GetResourceString("NotCustomCounter");

	internal static string InstanceLifetimeProcessforSingleInstance => GetResourceString("InstanceLifetimeProcessforSingleInstance");

	internal static string InstanceNameProhibited => GetResourceString("InstanceNameProhibited");

	internal static string ReadOnlyRemoveInstance => GetResourceString("ReadOnlyRemoveInstance");

	internal static string CounterExists => GetResourceString("CounterExists");

	internal static string SetSecurityDescriptorFailed => GetResourceString("SetSecurityDescriptorFailed");

	internal static string RegKeyMissingShort => GetResourceString("RegKeyMissingShort");

	internal static string CantGetMappingSize => GetResourceString("CantGetMappingSize");

	internal static string CantReadCategory => GetResourceString("CantReadCategory");

	internal static string PlatformNotSupported_PerfCounters => GetResourceString("PlatformNotSupported_PerfCounters");

	internal static string Perflib_Argument_InvalidCounterSetInstanceType => GetResourceString("Perflib_Argument_InvalidCounterSetInstanceType");

	internal static string Perflib_InvalidOperation_NoActiveProvider => GetResourceString("Perflib_InvalidOperation_NoActiveProvider");

	internal static string Perflib_Argument_InvalidCounterType => GetResourceString("Perflib_Argument_InvalidCounterType");

	internal static string Perflib_InvalidOperation_AddCounterAfterInstance => GetResourceString("Perflib_InvalidOperation_AddCounterAfterInstance");

	internal static string Perflib_Argument_CounterAlreadyExists => GetResourceString("Perflib_Argument_CounterAlreadyExists");

	internal static string Perflib_Argument_EmptyInstanceName => GetResourceString("Perflib_Argument_EmptyInstanceName");

	internal static string Perflib_InvalidOperation_CounterSetNotInstalled => GetResourceString("Perflib_InvalidOperation_CounterSetNotInstalled");

	internal static string Perflib_Argument_InvalidInstance => GetResourceString("Perflib_Argument_InvalidInstance");

	internal static string Perflib_Argument_EmptyCounterName => GetResourceString("Perflib_Argument_EmptyCounterName");

	internal static string Perflib_Argument_CounterNameAlreadyExists => GetResourceString("Perflib_Argument_CounterNameAlreadyExists");

	internal static string Perflib_Argument_ProviderNotFound => GetResourceString("Perflib_Argument_ProviderNotFound");

	internal static string Perflib_InvalidOperation_CounterSetContainsNoCounter => GetResourceString("Perflib_InvalidOperation_CounterSetContainsNoCounter");

	internal static string Perflib_Argument_CounterSetAlreadyRegister => GetResourceString("Perflib_Argument_CounterSetAlreadyRegister");

	internal static string Perflib_Argument_InstanceAlreadyExists => GetResourceString("Perflib_Argument_InstanceAlreadyExists");

	internal static string Perflib_InsufficientMemory_InstanceCounterBlock => GetResourceString("Perflib_InsufficientMemory_InstanceCounterBlock");

	internal static string Perflib_InvalidOperation_CounterRefValue => GetResourceString("Perflib_InvalidOperation_CounterRefValue");

	internal static string Arg_DllInitFailure => GetResourceString("Arg_DllInitFailure");

	internal static string Arg_RegKeyNoRemoteConnect => GetResourceString("Arg_RegKeyNoRemoteConnect");

	internal static string ObjectDisposed_CategorySampleClosed => GetResourceString("ObjectDisposed_CategorySampleClosed");

	internal static string UnauthorizedAccess_RegistryKeyGeneric_Key => GetResourceString("UnauthorizedAccess_RegistryKeyGeneric_Key");

	internal static bool UsingResourceKeys()
	{
		return s_usingResourceKeys;
	}

	private static string GetResourceString(string resourceKey)
	{
		if (UsingResourceKeys())
		{
			return resourceKey;
		}
		string result = null;
		try
		{
			result = ResourceManager.GetString(resourceKey);
		}
		catch (MissingManifestResourceException)
		{
		}
		return result;
	}

	private static string GetResourceString(string resourceKey, string defaultString)
	{
		string resourceString = GetResourceString(resourceKey);
		if (!(resourceKey == resourceString) && resourceString != null)
		{
			return resourceString;
		}
		return defaultString;
	}

	internal static string Format(string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(resourceFormat, p1, p2, p3);
	}

	internal static string Format(string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(resourceFormat, args);
		}
		return resourceFormat;
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1);
		}
		return string.Format(provider, resourceFormat, p1);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2);
		}
		return string.Format(provider, resourceFormat, p1, p2);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, object p1, object p2, object p3)
	{
		if (UsingResourceKeys())
		{
			return string.Join(", ", resourceFormat, p1, p2, p3);
		}
		return string.Format(provider, resourceFormat, p1, p2, p3);
	}

	internal static string Format(IFormatProvider provider, string resourceFormat, params object[] args)
	{
		if (args != null)
		{
			if (UsingResourceKeys())
			{
				return resourceFormat + ", " + string.Join(", ", args);
			}
			return string.Format(provider, resourceFormat, args);
		}
		return resourceFormat;
	}
}
