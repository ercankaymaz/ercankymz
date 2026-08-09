using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Reflection;

namespace System.ComponentModel.Composition.ReflectionModel;

internal sealed class ExportFactoryCreator
{
	private sealed class LifetimeContext
	{
		public static Tuple<T, Action> GetExportLifetimeContextFromExport<T>(Export export)
		{
			IDisposable disposable = null;
			T item;
			if (export is CatalogExportProvider.ScopeFactoryExport scopeFactoryExport)
			{
				Export export2 = scopeFactoryExport.CreateExportProduct();
				item = ExportServices.GetCastedExportedValue<T>(export2);
				disposable = export2 as IDisposable;
			}
			else if (export is CatalogExportProvider.FactoryExport factoryExport)
			{
				Export export3 = factoryExport.CreateExportProduct();
				item = ExportServices.GetCastedExportedValue<T>(export3);
				disposable = export3 as IDisposable;
			}
			else
			{
				ComposablePartDefinition castedExportedValue = ExportServices.GetCastedExportedValue<ComposablePartDefinition>(export);
				ComposablePart composablePart = castedExportedValue.CreatePart();
				ExportDefinition definition = castedExportedValue.ExportDefinitions.Single();
				item = ExportServices.CastExportedValue<T>(composablePart.ToElement(), composablePart.GetExportedValue(definition));
				disposable = composablePart as IDisposable;
			}
			Action item2 = ((disposable == null) ? ((Action)delegate
			{
			}) : new Action(disposable.Dispose));
			return new Tuple<T, Action>(item, item2);
		}
	}

	private static readonly MethodInfo _createStronglyTypedExportFactoryOfT = typeof(ExportFactoryCreator).GetMethod("CreateStronglyTypedExportFactoryOfT", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

	private static readonly MethodInfo _createStronglyTypedExportFactoryOfTM = typeof(ExportFactoryCreator).GetMethod("CreateStronglyTypedExportFactoryOfTM", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

	private readonly Type _exportFactoryType;

	public ExportFactoryCreator(Type exportFactoryType)
	{
		ArgumentNullException.ThrowIfNull(exportFactoryType, "exportFactoryType");
		_exportFactoryType = exportFactoryType;
	}

	public Func<Export, object> CreateStronglyTypedExportFactoryFactory(Type exportType, Type? metadataViewType)
	{
		MethodInfo methodInfo = ((!(metadataViewType == null)) ? _createStronglyTypedExportFactoryOfTM.MakeGenericMethod(exportType, metadataViewType) : _createStronglyTypedExportFactoryOfT.MakeGenericMethod(exportType));
		if (methodInfo == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		Func<Export, object> func = (Func<Export, object>)Delegate.CreateDelegate(typeof(Func<Export, object>), this, methodInfo);
		return func.Invoke;
	}

	private object CreateStronglyTypedExportFactoryOfT<T>(Export export)
	{
		Type[] typeArguments = new Type[1] { typeof(T) };
		Type type = _exportFactoryType.MakeGenericType(typeArguments);
		Func<Tuple<T, Action>> func = () => LifetimeContext.GetExportLifetimeContextFromExport<T>(export);
		object[] args = new object[1] { func };
		return Activator.CreateInstance(type, args);
	}

	private object CreateStronglyTypedExportFactoryOfTM<T, M>(Export export)
	{
		Type[] typeArguments = new Type[2]
		{
			typeof(T),
			typeof(M)
		};
		Type type = _exportFactoryType.MakeGenericType(typeArguments);
		Func<Tuple<T, Action>> func = () => LifetimeContext.GetExportLifetimeContextFromExport<T>(export);
		M metadataView = AttributedModelServices.GetMetadataView<M>(export.Metadata);
		object[] args = new object[2] { func, metadataView };
		return Activator.CreateInstance(type, args);
	}
}
