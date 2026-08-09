namespace Basler.Pylon;

public struct FloatName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator FloatName(string name)
	{
		return new FloatName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
