using System.ComponentModel.Composition.Primitives;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.Hosting;

public class CompositionService : ICompositionService, IDisposable
{
	private readonly CompositionContainer _compositionContainer;

	private readonly INotifyComposablePartCatalogChanged _notifyCatalog;

	internal CompositionService(ComposablePartCatalog composablePartCatalog)
	{
		ArgumentNullException.ThrowIfNull(composablePartCatalog, "composablePartCatalog");
		_notifyCatalog = composablePartCatalog as INotifyComposablePartCatalogChanged;
		try
		{
			if (_notifyCatalog != null)
			{
				_notifyCatalog.Changing += OnCatalogChanging;
			}
			CompositionOptions compositionOptions = CompositionOptions.DisableSilentRejection | CompositionOptions.IsThreadSafe | CompositionOptions.ExportCompositionService;
			CompositionContainer compositionContainer = new CompositionContainer(composablePartCatalog, compositionOptions);
			_compositionContainer = compositionContainer;
		}
		catch
		{
			if (_notifyCatalog != null)
			{
				_notifyCatalog.Changing -= OnCatalogChanging;
			}
			throw;
		}
	}

	public void SatisfyImportsOnce(ComposablePart part)
	{
		Requires.NotNull(part, "part");
		if (_compositionContainer == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		_compositionContainer.SatisfyImportsOnce(part);
	}

	public void Dispose()
	{
		if (_compositionContainer == null)
		{
			throw new Exception(System.SR.Diagnostic_InternalExceptionMessage);
		}
		if (_notifyCatalog != null)
		{
			_notifyCatalog.Changing -= OnCatalogChanging;
		}
		_compositionContainer.Dispose();
	}

	private void OnCatalogChanging(object sender, ComposablePartCatalogChangeEventArgs e)
	{
		throw new ChangeRejectedException(System.SR.NotSupportedCatalogChanges);
	}
}
