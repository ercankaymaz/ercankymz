namespace Basler.Pylon;

public struct EnumName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static implicit operator EnumName(ParameterListEnum name)
	{
		return new EnumName
		{
			m_name = name.Name
		};
	}

	public static explicit operator EnumName(string name)
	{
		return new EnumName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
