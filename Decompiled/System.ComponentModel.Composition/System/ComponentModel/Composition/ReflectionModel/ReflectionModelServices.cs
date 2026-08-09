using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.ReflectionModel;

public static class ReflectionModelServices
{
	public static Lazy<Type> GetPartType(ComposablePartDefinition partDefinition)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		if (!(partDefinition is ReflectionComposablePartDefinition reflectionComposablePartDefinition))
		{
			throw ExceptionBuilder.CreateReflectionModelInvalidPartDefinition("partDefinition", partDefinition.GetType());
		}
		return reflectionComposablePartDefinition.GetLazyPartType();
	}

	public static bool IsDisposalRequired(ComposablePartDefinition partDefinition)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		if (!(partDefinition is ReflectionComposablePartDefinition reflectionComposablePartDefinition))
		{
			throw ExceptionBuilder.CreateReflectionModelInvalidPartDefinition("partDefinition", partDefinition.GetType());
		}
		return reflectionComposablePartDefinition.IsDisposalRequired;
	}

	public static LazyMemberInfo GetExportingMember(ExportDefinition exportDefinition)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		if (!(exportDefinition is ReflectionMemberExportDefinition reflectionMemberExportDefinition))
		{
			throw new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidExportDefinition, exportDefinition.GetType()), "exportDefinition");
		}
		return reflectionMemberExportDefinition.ExportingLazyMember;
	}

	public static LazyMemberInfo GetImportingMember(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (!(importDefinition is ReflectionMemberImportDefinition reflectionMemberImportDefinition))
		{
			throw new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidMemberImportDefinition, importDefinition.GetType()), "importDefinition");
		}
		return reflectionMemberImportDefinition.ImportingLazyMember;
	}

	public static Lazy<ParameterInfo> GetImportingParameter(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (!(importDefinition is ReflectionParameterImportDefinition reflectionParameterImportDefinition))
		{
			throw new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidParameterImportDefinition, importDefinition.GetType()), "importDefinition");
		}
		return reflectionParameterImportDefinition.ImportingLazyParameter;
	}

	public static bool IsImportingParameter(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (!(importDefinition is ReflectionImportDefinition))
		{
			throw new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidImportDefinition, importDefinition.GetType()), "importDefinition");
		}
		return importDefinition is ReflectionParameterImportDefinition;
	}

	public static bool IsExportFactoryImportDefinition(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		return importDefinition is IPartCreatorImportDefinition;
	}

	public static ContractBasedImportDefinition GetExportFactoryProductImportDefinition(ImportDefinition importDefinition)
	{
		Requires.NotNull(importDefinition, "importDefinition");
		if (!(importDefinition is IPartCreatorImportDefinition partCreatorImportDefinition))
		{
			throw new ArgumentException(System.SR.Format(System.SR.ReflectionModel_InvalidImportDefinition, importDefinition.GetType()), "importDefinition");
		}
		return partCreatorImportDefinition.ProductImportDefinition;
	}

	public static ComposablePartDefinition CreatePartDefinition(Lazy<Type> partType, bool isDisposalRequired, Lazy<IEnumerable<ImportDefinition>>? imports, Lazy<IEnumerable<ExportDefinition>>? exports, Lazy<IDictionary<string, object?>>? metadata, ICompositionElement? origin)
	{
		Requires.NotNull(partType, "partType");
		return new ReflectionComposablePartDefinition(new ReflectionPartCreationInfo(partType, isDisposalRequired, imports, exports, metadata, origin));
	}

	public static ExportDefinition CreateExportDefinition(LazyMemberInfo exportingMember, string contractName, Lazy<IDictionary<string, object?>> metadata, ICompositionElement? origin)
	{
		Requires.NotNullOrEmpty(contractName, "contractName");
		Requires.IsInMembertypeSet(exportingMember.MemberType, "exportingMember", MemberTypes.Field | MemberTypes.Method | MemberTypes.Property | MemberTypes.TypeInfo | MemberTypes.NestedType);
		return new ReflectionMemberExportDefinition(exportingMember, new LazyExportDefinition(contractName, metadata), origin);
	}

	public static ContractBasedImportDefinition CreateImportDefinition(LazyMemberInfo importingMember, string contractName, string? requiredTypeIdentity, IEnumerable<KeyValuePair<string, Type>>? requiredMetadata, ImportCardinality cardinality, bool isRecomposable, CreationPolicy requiredCreationPolicy, ICompositionElement? origin)
	{
		return CreateImportDefinition(importingMember, contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable, requiredCreationPolicy, MetadataServices.EmptyMetadata, isExportFactory: false, origin);
	}

	public static ContractBasedImportDefinition CreateImportDefinition(LazyMemberInfo importingMember, string contractName, string? requiredTypeIdentity, IEnumerable<KeyValuePair<string, Type>>? requiredMetadata, ImportCardinality cardinality, bool isRecomposable, CreationPolicy requiredCreationPolicy, IDictionary<string, object?> metadata, bool isExportFactory, ICompositionElement? origin)
	{
		return CreateImportDefinition(importingMember, contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable, isPreRequisite: false, requiredCreationPolicy, metadata, isExportFactory, origin);
	}

	public static ContractBasedImportDefinition CreateImportDefinition(LazyMemberInfo importingMember, string contractName, string? requiredTypeIdentity, IEnumerable<KeyValuePair<string, Type>>? requiredMetadata, ImportCardinality cardinality, bool isRecomposable, bool isPreRequisite, CreationPolicy requiredCreationPolicy, IDictionary<string, object?> metadata, bool isExportFactory, ICompositionElement? origin)
	{
		Requires.NotNullOrEmpty(contractName, "contractName");
		Requires.IsInMembertypeSet(importingMember.MemberType, "importingMember", MemberTypes.Field | MemberTypes.Property);
		if (isExportFactory)
		{
			return new PartCreatorMemberImportDefinition(importingMember, origin, new ContractBasedImportDefinition(contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable, isPreRequisite, CreationPolicy.NonShared, metadata));
		}
		return new ReflectionMemberImportDefinition(importingMember, contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable, isPreRequisite, requiredCreationPolicy, metadata, origin);
	}

	public static ContractBasedImportDefinition CreateImportDefinition(Lazy<ParameterInfo> parameter, string contractName, string? requiredTypeIdentity, IEnumerable<KeyValuePair<string, Type>>? requiredMetadata, ImportCardinality cardinality, CreationPolicy requiredCreationPolicy, ICompositionElement? origin)
	{
		return CreateImportDefinition(parameter, contractName, requiredTypeIdentity, requiredMetadata, cardinality, requiredCreationPolicy, MetadataServices.EmptyMetadata, isExportFactory: false, origin);
	}

	public static ContractBasedImportDefinition CreateImportDefinition(Lazy<ParameterInfo> parameter, string contractName, string? requiredTypeIdentity, IEnumerable<KeyValuePair<string, Type>>? requiredMetadata, ImportCardinality cardinality, CreationPolicy requiredCreationPolicy, IDictionary<string, object?> metadata, bool isExportFactory, ICompositionElement? origin)
	{
		Requires.NotNull(parameter, "parameter");
		Requires.NotNullOrEmpty(contractName, "contractName");
		if (isExportFactory)
		{
			return new PartCreatorParameterImportDefinition(parameter, origin, new ContractBasedImportDefinition(contractName, requiredTypeIdentity, requiredMetadata, cardinality, isRecomposable: false, isPrerequisite: true, CreationPolicy.NonShared, metadata));
		}
		return new ReflectionParameterImportDefinition(parameter, contractName, requiredTypeIdentity, requiredMetadata, cardinality, requiredCreationPolicy, metadata, origin);
	}

	public static bool TryMakeGenericPartDefinition(ComposablePartDefinition partDefinition, IEnumerable<Type> genericParameters, [NotNullWhen(true)] out ComposablePartDefinition? specialization)
	{
		Requires.NotNull(partDefinition, "partDefinition");
		specialization = null;
		if (!(partDefinition is ReflectionComposablePartDefinition reflectionComposablePartDefinition))
		{
			throw ExceptionBuilder.CreateReflectionModelInvalidPartDefinition("partDefinition", partDefinition.GetType());
		}
		return reflectionComposablePartDefinition.TryMakeGenericPartDefinition(genericParameters.ToArray(), out specialization);
	}
}
