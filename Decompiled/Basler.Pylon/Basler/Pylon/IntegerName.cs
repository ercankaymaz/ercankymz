namespace Basler.Pylon;

public struct IntegerName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator IntegerName(string name)
	{
		return new IntegerName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
