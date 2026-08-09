namespace Basler.Pylon;

public struct BooleanName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator BooleanName(string name)
	{
		return new BooleanName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
