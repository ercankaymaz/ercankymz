namespace Zen.Barcode;

public abstract class FactoryChecksum<T> : Checksum where T : GlyphFactory
{
	private T _factory;

	public T Factory => _factory;

	protected FactoryChecksum(T factory)
	{
		_factory = factory;
	}
}
