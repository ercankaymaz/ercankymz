namespace Basler.Pylon;

public struct ArrayName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator ArrayName(string name)
	{
		return new ArrayName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
