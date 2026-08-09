using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using System.Threading;
using Microsoft.Internal;
using Microsoft.Internal.Collections;

namespace System.ComponentModel.Composition;

internal static class ExportServices
{
	private sealed class DisposableLazy<T, TMetadataView> : Lazy<T, TMetadataView>, IDisposable
	{
		private readonly IDisposable _disposable;

		public DisposableLazy(Func<T> valueFactory, TMetadataView metadataView, IDisposable disposable, LazyThreadSafetyMode mode)
			: base(valueFactory, metadataView, mode)
		{
			ArgumentNullException.ThrowIfNull(disposable, "disposable");
			_disposable = disposable;
		}

		void IDisposable.Dispose()
		{
			_disposable.Dispose();
		}
	}

	private sealed class DisposableLazy<T> : Lazy<T>, IDisposable
	{
		private readonly IDisposable _disposable;

		public DisposableLazy(Func<T> valueFactory, IDisposable disposable, LazyThreadSafetyMode mode)
			: base(valueFactory, mode)
		{
			ArgumentNullException.ThrowIfNull(disposable, "disposable");
			_disposable = disposable;
		}

		void IDisposable.Dispose()
		{
			_disposable.Dispose();
		}
	}

	private static readonly MethodInfo _createStronglyTypedLazyOfTM = typeof(ExportServices).GetMethod("CreateStronglyTypedLazyOfTM", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _createStronglyTypedLazyOfT = typeof(ExportServices).GetMethod("CreateStronglyTypedLazyOfT", BindingFlags.Static | BindingFlags.NonPublic);

	private static readonly MethodInfo _createSemiStronglyTypedLazy = typeof(ExportServices).GetMethod("CreateSemiStronglyTypedLazy", BindingFlags.Static | BindingFlags.NonPublic);

	internal static readonly Type DefaultMetadataViewType = typeof(IDictionary<string, object>);

	internal static readonly Type DefaultExportedValueType = typeof(object);

	internal static bool IsDefaultMetadataViewType(Type metadataViewType)
	{
		ArgumentNullException.ThrowIfNull(metadataViewType, "metadataViewType");
		return metadataViewType.IsAssignableFrom(DefaultMetadataViewType);
	}

	internal static bool IsDictionaryConstructorViewType(Type metadataViewType)
	{
		ArgumentNullException.ThrowIfNull(metadataViewType, "metadataViewType");
		return metadataViewType.GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, Type.DefaultBinder, new Type[1] { typeof(IDictionary<string, object>) }, Array.Empty<ParameterModifier>()) != null;
	}

	internal static Func<Export, object> CreateStronglyTypedLazyFactory(Type? exportType, Type? metadataViewType)
	{
		MethodInfo methodInfo = ((!(metadataViewType != null)) ? _createStronglyTypedLazyOfT.MakeGenericMethod(exportType ?? DefaultExportedValueType) : _createStronglyTypedLazyOfTM.MakeGenericMethod(exportType ?? DefaultExportedValueType, metadataViewType));
		if (methodInfo == null)
		{
			throw new ArgumentNullException("genericMethod");
		}
		return (Func<Export, object>)Delegate.CreateDelegate(typeof(Func<Export, object>), methodInfo);
	}

	internal static Func<Export, Lazy<object, object>> CreateSemiStronglyTypedLazyFactory(Type? exportType, Type? metadataViewType)
	{
		MethodInfo methodInfo = _createSemiStronglyTypedLazy.MakeGenericMethod(exportType ?? DefaultExportedValueType, metadataViewType ?? DefaultMetadataViewType);
		if (methodInfo == null)
		{
			throw new ArgumentNullException("genericMethod");
		}
		return (Func<Export, Lazy<object, object>>)Delegate.CreateDelegate(typeof(Func<Export, Lazy<object, object>>), methodInfo);
	}

	internal static Lazy<T, M> CreateStronglyTypedLazyOfTM<T, M>(Export export)
	{
		if (export is IDisposable disposable)
		{
			return new DisposableLazy<T, M>(() => GetCastedExportedValue<T>(export), AttributedModelServices.GetMetadataView<M>(export.Metadata), disposable, LazyThreadSafetyMode.PublicationOnly);
		}
		return new Lazy<T, M>(() => GetCastedExportedValue<T>(export), AttributedModelServices.GetMetadataView<M>(export.Metadata), LazyThreadSafetyMode.PublicationOnly);
	}

	internal static Lazy<T> CreateStronglyTypedLazyOfT<T>(Export export)
	{
		if (export is IDisposable disposable)
		{
			return new DisposableLazy<T>(() => GetCastedExportedValue<T>(export), disposable, LazyThreadSafetyMode.PublicationOnly);
		}
		return new Lazy<T>(() => GetCastedExportedValue<T>(export), LazyThreadSafetyMode.PublicationOnly);
	}

	internal static Lazy<object?, object> CreateSemiStronglyTypedLazy<T, M>(Export export)
	{
		if (export is IDisposable disposable)
		{
			return new DisposableLazy<object, object>(() => GetCastedExportedValue<T>(export), AttributedModelServices.GetMetadataView<M>(export.Metadata), disposable, LazyThreadSafetyMode.PublicationOnly);
		}
		return new Lazy<object, object>(() => GetCastedExportedValue<T>(export), AttributedModelServices.GetMetadataView<M>(export.Metadata), LazyThreadSafetyMode.PublicationOnly);
	}

	internal static T GetCastedExportedValue<T>(Export export)
	{
		return CastExportedValue<T>(export.ToElement(), export.Value);
	}

	internal static T CastExportedValue<T>(ICompositionElement element, object? exportedValue)
	{
		if (!ContractServices.TryCast(typeof(T), exportedValue, out object result))
		{
			throw new CompositionContractMismatchException(System.SR.Format(System.SR.ContractMismatch_ExportedValueCannotBeCastToT, element.DisplayName, typeof(T)));
		}
		return (T)result;
	}

	internal static ExportCardinalityCheckResult CheckCardinality<T>(ImportDefinition definition, IEnumerable<T>? enumerable)
	{
		EnumerableCardinality actualCardinality = enumerable?.GetCardinality() ?? EnumerableCardinality.Zero;
		return MatchCardinality(actualCardinality, definition.Cardinality);
	}

	private static ExportCardinalityCheckResult MatchCardinality(EnumerableCardinality actualCardinality, ImportCardinality importCardinality)
	{
		switch (actualCardinality)
		{
		case EnumerableCardinality.Zero:
			if (importCardinality == ImportCardinality.ExactlyOne)
			{
				return ExportCardinalityCheckResult.NoExports;
			}
			break;
		case EnumerableCardinality.TwoOrMore:
			if (importCardinality.IsAtMostOne())
			{
				return ExportCardinalityCheckResult.TooManyExports;
			}
			break;
		default:
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		case EnumerableCardinality.One:
			break;
		}
		return ExportCardinalityCheckResult.Match;
	}
}
