namespace Basler.Pylon;

public struct StringName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator StringName(string name)
	{
		return new StringName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
