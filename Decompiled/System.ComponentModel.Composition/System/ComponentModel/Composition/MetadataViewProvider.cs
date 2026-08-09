using System.Collections.Generic;
using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition;

internal static class MetadataViewProvider
{
	public static TMetadataView GetMetadataView<TMetadataView>(IDictionary<string, object?> metadata)
	{
		ArgumentNullException.ThrowIfNull(metadata, "metadata");
		Type typeFromHandle = typeof(TMetadataView);
		if (typeFromHandle.IsAssignableFrom(typeof(IDictionary<string, object>)))
		{
			return (TMetadataView)metadata;
		}
		Type type = null;
		MetadataViewGenerator.MetadataViewFactory metadataViewFactory = null;
		if (typeFromHandle.IsInterface)
		{
			if (!typeFromHandle.IsAttributeDefined<MetadataViewImplementationAttribute>())
			{
				try
				{
					metadataViewFactory = MetadataViewGenerator.GetMetadataViewFactory(typeFromHandle);
				}
				catch (TypeLoadException innerException)
				{
					throw new NotSupportedException(System.SR.Format(System.SR.NotSupportedInterfaceMetadataView, typeFromHandle.FullName), innerException);
				}
			}
			else
			{
				MetadataViewImplementationAttribute firstAttribute = typeFromHandle.GetFirstAttribute<MetadataViewImplementationAttribute>();
				type = firstAttribute.ImplementationType;
				if (type == null)
				{
					throw new CompositionContractMismatchException(System.SR.Format(System.SR.ContractMismatch_MetadataViewImplementationCanNotBeNull, typeFromHandle.FullName));
				}
				if (!typeFromHandle.IsAssignableFrom(type))
				{
					throw new CompositionContractMismatchException(System.SR.Format(System.SR.ContractMismatch_MetadataViewImplementationDoesNotImplementViewInterface, typeFromHandle.FullName, type.FullName));
				}
			}
		}
		else
		{
			type = typeFromHandle;
		}
		try
		{
			if (metadataViewFactory != null)
			{
				return MetadataViewGenerator.CreateMetadataView<TMetadataView>(metadataViewFactory, metadata);
			}
			if (type == null)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return (TMetadataView)type.SafeCreateInstance(metadata);
		}
		catch (MissingMethodException innerException2)
		{
			throw new CompositionContractMismatchException(System.SR.Format(System.SR.CompositionException_MetadataViewInvalidConstructor, type.AssemblyQualifiedName), innerException2);
		}
		catch (TargetInvocationException ex)
		{
			if (typeFromHandle.IsInterface)
			{
				if (ex.InnerException.GetType() == typeof(InvalidCastException))
				{
					throw new CompositionContractMismatchException(System.SR.Format(System.SR.ContractMismatch_InvalidCastOnMetadataField, ex.InnerException.Data["MetadataViewType"], ex.InnerException.Data["MetadataItemKey"], ex.InnerException.Data["MetadataItemValue"], ex.InnerException.Data["MetadataItemSourceType"], ex.InnerException.Data["MetadataItemTargetType"]), ex);
				}
				if (ex.InnerException.GetType() == typeof(NullReferenceException))
				{
					throw new CompositionContractMismatchException(System.SR.Format(System.SR.ContractMismatch_NullReferenceOnMetadataField, ex.InnerException.Data["MetadataViewType"], ex.InnerException.Data["MetadataItemKey"], ex.InnerException.Data["MetadataItemTargetType"]), ex);
				}
			}
			throw;
		}
	}

	public static bool IsViewTypeValid(Type metadataViewType)
	{
		ArgumentNullException.ThrowIfNull(metadataViewType, "metadataViewType");
		if (ExportServices.IsDefaultMetadataViewType(metadataViewType) || metadataViewType.IsInterface || ExportServices.IsDictionaryConstructorViewType(metadataViewType))
		{
			return true;
		}
		return false;
	}
}
