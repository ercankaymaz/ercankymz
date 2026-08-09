using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class EncryptedData
{
	private string m_algorithm;

	private byte[] m_data;

	public string Algorithm
	{
		get
		{
			return m_algorithm;
		}
		set
		{
			m_algorithm = value;
		}
	}

	public byte[] Data
	{
		get
		{
			return m_data;
		}
		set
		{
			m_data = value;
		}
	}
}
