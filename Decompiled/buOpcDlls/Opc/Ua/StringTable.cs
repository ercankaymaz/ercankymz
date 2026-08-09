using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public class StringTable
{
	private readonly object m_lock = new object();

	private List<string> m_strings;

	public object SyncRoot => m_lock;

	public int InstanceId => 0;

	public int Count
	{
		get
		{
			lock (m_lock)
			{
				return m_strings.Count;
			}
		}
	}

	public StringTable()
	{
		m_strings = new List<string>();
	}

	public StringTable(bool shared)
	{
		m_strings = new List<string>();
	}

	public StringTable(IEnumerable<string> strings)
	{
		Update(strings);
	}

	public void Update(IEnumerable<string> strings)
	{
		if (strings == null)
		{
			throw new ArgumentNullException("strings");
		}
		lock (m_lock)
		{
			m_strings = new List<string>(strings);
		}
	}

	public int Append(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentNullException("value");
		}
		lock (m_lock)
		{
			m_strings.Add(value);
			return m_strings.Count - 1;
		}
	}

	public string GetString(uint index)
	{
		lock (m_lock)
		{
			if (index < m_strings.Count)
			{
				return m_strings[(int)index];
			}
			return null;
		}
	}

	public int GetIndex(string value)
	{
		lock (m_lock)
		{
			if (string.IsNullOrEmpty(value))
			{
				return -1;
			}
			return m_strings.IndexOf(value);
		}
	}

	public ushort GetIndexOrAppend(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			throw new ArgumentNullException("value");
		}
		lock (m_lock)
		{
			int num = m_strings.IndexOf(value);
			if (num == -1)
			{
				m_strings.Add(value);
				return (ushort)(m_strings.Count - 1);
			}
			return (ushort)num;
		}
	}

	public string[] ToArray()
	{
		lock (m_lock)
		{
			return m_strings.ToArray();
		}
	}

	public ushort[] CreateMapping(StringTable source, bool updateTable)
	{
		if (source == null)
		{
			return null;
		}
		ushort[] array = new ushort[source.Count];
		for (uint num = 0u; num < source.Count; num++)
		{
			string value = source.GetString(num);
			int num2 = GetIndex(value);
			if (num2 < 0)
			{
				if (!updateTable)
				{
					array[num] = ushort.MaxValue;
					continue;
				}
				num2 = Append(value);
			}
			array[num] = (ushort)num2;
		}
		return array;
	}
}
