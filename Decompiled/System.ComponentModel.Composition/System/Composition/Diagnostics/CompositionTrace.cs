using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.Diagnostics;

internal static class CompositionTrace
{
	internal static void PartDefinitionResurrected(ComposablePartDefinition definition)
	{
		ArgumentNullException.ThrowIfNull(definition, "definition");
		if (CompositionTraceSource.CanWriteInformation)
		{
			CompositionTraceSource.WriteInformation(CompositionTraceId.Rejection_DefinitionResurrected, System.SR.CompositionTrace_Rejection_DefinitionResurrected, definition.GetDisplayName());
		}
	}

	internal static void PartDefinitionRejected(ComposablePartDefinition definition, ChangeRejectedException exception)
	{
		ArgumentNullException.ThrowIfNull(definition, "definition");
		ArgumentNullException.ThrowIfNull(exception, "exception");
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Rejection_DefinitionRejected, System.SR.CompositionTrace_Rejection_DefinitionRejected, definition.GetDisplayName(), exception.Message);
		}
	}

	internal static void AssemblyLoadFailed(DirectoryCatalog catalog, string fileName, Exception exception)
	{
		ArgumentNullException.ThrowIfNull(catalog, "catalog");
		ArgumentNullException.ThrowIfNull(fileName, "fileName");
		ArgumentNullException.ThrowIfNull(exception, "exception");
		if (fileName.Length == 0)
		{
			throw new ArgumentException(System.SR.Format(System.SR.ArgumentException_EmptyString, "fileName"), "fileName");
		}
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Discovery_AssemblyLoadFailed, System.SR.CompositionTrace_Discovery_AssemblyLoadFailed, catalog.GetDisplayName(), fileName, exception.Message);
		}
	}

	internal static void DefinitionMarkedWithPartNotDiscoverableAttribute(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (CompositionTraceSource.CanWriteInformation)
		{
			CompositionTraceSource.WriteInformation(CompositionTraceId.Discovery_DefinitionMarkedWithPartNotDiscoverableAttribute, System.SR.CompositionTrace_Discovery_DefinitionMarkedWithPartNotDiscoverableAttribute, type.GetDisplayName());
		}
	}

	internal static void DefinitionMismatchedExportArity(Type type, MemberInfo member)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(member, "member");
		if (CompositionTraceSource.CanWriteInformation)
		{
			CompositionTraceSource.WriteInformation(CompositionTraceId.Discovery_DefinitionMismatchedExportArity, System.SR.CompositionTrace_Discovery_DefinitionMismatchedExportArity, type.GetDisplayName(), member.GetDisplayName());
		}
	}

	internal static void DefinitionContainsNoExports(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (CompositionTraceSource.CanWriteInformation)
		{
			CompositionTraceSource.WriteInformation(CompositionTraceId.Discovery_DefinitionContainsNoExports, System.SR.CompositionTrace_Discovery_DefinitionContainsNoExports, type.GetDisplayName());
		}
	}

	internal static void MemberMarkedWithMultipleImportAndImportMany(ReflectionItem item)
	{
		ArgumentNullException.ThrowIfNull(item, "item");
		if (CompositionTraceSource.CanWriteError)
		{
			CompositionTraceSource.WriteError(CompositionTraceId.Discovery_MemberMarkedWithMultipleImportAndImportMany, System.SR.CompositionTrace_Discovery_MemberMarkedWithMultipleImportAndImportMany, item.GetDisplayName());
		}
	}
}
