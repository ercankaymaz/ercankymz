namespace Basler.Pylon;

public struct CommandName(string name)
{
	private string m_name = name;

	public string Name => m_name;

	public static explicit operator CommandName(string name)
	{
		return new CommandName
		{
			m_name = name
		};
	}

	public sealed override string ToString()
	{
		return m_name;
	}
}
