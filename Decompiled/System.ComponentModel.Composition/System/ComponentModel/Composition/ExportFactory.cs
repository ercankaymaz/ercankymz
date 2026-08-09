namespace System.ComponentModel.Composition;

public class ExportFactory<T>
{
	private readonly Func<Tuple<T, Action>> _exportLifetimeContextCreator;

	public ExportFactory(Func<Tuple<T, Action>> exportLifetimeContextCreator)
	{
		ArgumentNullException.ThrowIfNull(exportLifetimeContextCreator, "exportLifetimeContextCreator");
		_exportLifetimeContextCreator = exportLifetimeContextCreator;
	}

	public ExportLifetimeContext<T> CreateExport()
	{
		Tuple<T, Action> tuple = _exportLifetimeContextCreator();
		return new ExportLifetimeContext<T>(tuple.Item1, tuple.Item2);
	}
}
public class ExportFactory<T, TMetadata> : ExportFactory<T>
{
	private readonly TMetadata _metadata;

	public TMetadata Metadata => _metadata;

	public ExportFactory(Func<Tuple<T, Action>> exportLifetimeContextCreator, TMetadata metadata)
		: base(exportLifetimeContextCreator)
	{
		_metadata = metadata;
	}
}
