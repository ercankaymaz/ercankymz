using System.Reflection;

namespace System.Composition.Diagnostics;

internal static class CompositionTrace
{
	public static void Registration_ConstructorConventionOverridden(Type type)
	{
		if (type == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteInformation)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteInformation(System.Composition.Diagnostics.CompositionTraceId.Registration_ConstructorConventionOverridden, System.SR.Registration_ConstructorConventionOverridden, type.FullName);
		}
	}

	public static void Registration_TypeExportConventionOverridden(Type type)
	{
		if (type == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_TypeExportConventionOverridden, System.SR.Registration_TypeExportConventionOverridden, type.FullName);
		}
	}

	public static void Registration_MemberExportConventionOverridden(Type type, MemberInfo member)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_MemberExportConventionOverridden, System.SR.Registration_MemberExportConventionOverridden, member.Name, type.FullName);
		}
	}

	public static void Registration_MemberImportConventionOverridden(Type type, MemberInfo member)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_MemberImportConventionOverridden, System.SR.Registration_MemberImportConventionOverridden, member.Name, type.FullName);
		}
	}

	public static void Registration_OnSatisfiedImportNotificationOverridden(Type type, MemberInfo member)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_OnSatisfiedImportNotificationOverridden, System.SR.Registration_OnSatisfiedImportNotificationOverridden, member.Name, type.FullName);
		}
	}

	public static void Registration_PartCreationConventionOverridden(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_PartCreationConventionOverridden, System.SR.Registration_PartCreationConventionOverridden, type.FullName);
		}
	}

	public static void Registration_MemberImportConventionMatchedTwice(Type type, MemberInfo member)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_MemberImportConventionMatchedTwice, System.SR.Registration_MemberImportConventionMatchedTwice, member.Name, type.FullName);
		}
	}

	public static void Registration_PartMetadataConventionOverridden(Type type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_PartMetadataConventionOverridden, System.SR.Registration_PartMetadataConventionOverridden, type.FullName);
		}
	}

	public static void Registration_ParameterImportConventionOverridden(ParameterInfo parameter, ConstructorInfo constructor)
	{
		if (parameter == null)
		{
			throw new ArgumentNullException("parameter");
		}
		if ((object)constructor == null)
		{
			throw new ArgumentNullException("constructor");
		}
		if (System.Composition.Diagnostics.CompositionTraceSource.CanWriteWarning)
		{
			System.Composition.Diagnostics.CompositionTraceSource.WriteWarning(System.Composition.Diagnostics.CompositionTraceId.Registration_ParameterImportConventionOverridden, System.SR.Registration_ParameterImportConventionOverridden, parameter.Name, constructor.Name);
		}
	}
}
