using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ImportType
{
	private static readonly Type LazyOfTType = typeof(Lazy<>);

	private static readonly Type LazyOfTMType = typeof(Lazy<, >);

	private static readonly Type ExportFactoryOfTType = typeof(ExportFactory<>);

	private readonly Type _type;

	private readonly bool _isAssignableCollectionType;

	private Type _contractType;

	private Func<Export, object> _castSingleValue;

	private readonly bool _isOpenGeneric;

	[ThreadStatic]
	internal static Dictionary<Type, Func<Export, object>?>? _castSingleValueCache;

	private static Dictionary<Type, Func<Export, object>?> CastSingleValueCache => _castSingleValueCache ?? (_castSingleValueCache = new Dictionary<Type, Func<Export, object>>());

	public bool IsAssignableCollectionType => _isAssignableCollectionType;

	public Type? ElementType { get; private set; }

	public Type ActualType => _type;

	public bool IsPartCreator { get; private set; }

	public Type ContractType => _contractType;

	public Func<Export, object>? CastExport
	{
		get
		{
			if (_isOpenGeneric)
			{
				throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
			}
			return _castSingleValue;
		}
	}

	public Type? MetadataViewType { get; private set; }

	public ImportType(Type type, ImportCardinality cardinality)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		_type = type;
		Type type2 = type;
		if (cardinality == ImportCardinality.ZeroOrMore)
		{
			_isAssignableCollectionType = IsTypeAssignableCollectionType(type);
			type2 = CheckForCollection(type);
		}
		_isOpenGeneric = type.ContainsGenericParameters;
		Initialize(type2);
	}

	private Type CheckForCollection(Type type)
	{
		ElementType = CollectionServices.GetEnumerableElementType(type);
		if (ElementType != null)
		{
			return ElementType;
		}
		return type;
	}

	private static bool IsGenericDescendentOf(Type type, Type baseGenericTypeDefinition)
	{
		if (type == typeof(object) || type == null)
		{
			return false;
		}
		if (type.IsGenericType && type.GetGenericTypeDefinition() == baseGenericTypeDefinition)
		{
			return true;
		}
		return IsGenericDescendentOf(type.BaseType, baseGenericTypeDefinition);
	}

	public static bool IsDescendentOf(Type type, Type baseType)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		ArgumentNullException.ThrowIfNull(baseType, "baseType");
		if (!baseType.IsGenericTypeDefinition)
		{
			return baseType.IsAssignableFrom(type);
		}
		return IsGenericDescendentOf(type, baseType.GetGenericTypeDefinition());
	}

	[MemberNotNull("_contractType")]
	private void Initialize(Type type)
	{
		if (!type.IsGenericType)
		{
			_contractType = type;
			return;
		}
		Type[] genericArguments = type.GetGenericArguments();
		Type underlyingSystemType = type.GetGenericTypeDefinition().UnderlyingSystemType;
		if (!CastSingleValueCache.TryGetValue(type, out _castSingleValue))
		{
			if (!TryGetCastFunction(underlyingSystemType, _isOpenGeneric, genericArguments, out _castSingleValue))
			{
				_contractType = type;
				return;
			}
			CastSingleValueCache.Add(type, _castSingleValue);
		}
		IsPartCreator = !IsLazyGenericType(underlyingSystemType) && underlyingSystemType != null;
		_contractType = genericArguments[0];
		if (genericArguments.Length == 2)
		{
			MetadataViewType = genericArguments[1];
		}
	}

	private static bool IsLazyGenericType(Type genericType)
	{
		if (!(genericType == LazyOfTType))
		{
			return genericType == LazyOfTMType;
		}
		return true;
	}

	private static bool TryGetCastFunction(Type genericType, bool isOpenGeneric, Type[] arguments, out Func<Export, object> castFunction)
	{
		castFunction = null;
		if (genericType == LazyOfTType)
		{
			if (!isOpenGeneric)
			{
				castFunction = ExportServices.CreateStronglyTypedLazyFactory(arguments[0].UnderlyingSystemType, null);
			}
			return true;
		}
		if (genericType == LazyOfTMType)
		{
			if (!isOpenGeneric)
			{
				castFunction = ExportServices.CreateStronglyTypedLazyFactory(arguments[0].UnderlyingSystemType, arguments[1].UnderlyingSystemType);
			}
			return true;
		}
		if (genericType != null && IsDescendentOf(genericType, ExportFactoryOfTType))
		{
			if (arguments.Length == 1)
			{
				if (!isOpenGeneric)
				{
					castFunction = new ExportFactoryCreator(genericType).CreateStronglyTypedExportFactoryFactory(arguments[0].UnderlyingSystemType, null);
				}
				return true;
			}
			if (arguments.Length == 2)
			{
				if (!isOpenGeneric)
				{
					castFunction = new ExportFactoryCreator(genericType).CreateStronglyTypedExportFactoryFactory(arguments[0].UnderlyingSystemType, arguments[1].UnderlyingSystemType);
				}
				return true;
			}
			throw ExceptionBuilder.ExportFactory_TooManyGenericParameters(genericType.FullName);
		}
		return false;
	}

	private static bool IsTypeAssignableCollectionType(Type type)
	{
		if (type.IsArray || CollectionServices.IsEnumerableOfT(type))
		{
			return true;
		}
		return false;
	}
}
