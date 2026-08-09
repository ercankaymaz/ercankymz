namespace System.ComponentModel.Composition.Registration;

public class ParameterImportBuilder
{
	public T Import<T>()
	{
		return default(T);
	}

	public T Import<T>(Action<ImportBuilder> configure)
	{
		return default(T);
	}
}
