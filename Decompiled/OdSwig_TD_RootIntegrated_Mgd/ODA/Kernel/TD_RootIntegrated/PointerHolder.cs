using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace ODA.Kernel.TD_RootIntegrated;

public class PointerHolder
{
	private static PointerHolder m_holder = new PointerHolder();

	private List<IntPtr> m_collection;

	private PointerHolder()
	{
		m_collection = new List<IntPtr>();
	}

	~PointerHolder()
	{
		Clear();
	}

	public static void Add(IntPtr ptr)
	{
		lock (m_holder)
		{
			m_holder.m_collection.Add(ptr);
		}
	}

	public static void Clear()
	{
		lock (m_holder)
		{
			foreach (IntPtr item in m_holder.m_collection)
			{
				Marshal.FreeHGlobal(item);
			}
			m_holder.m_collection.Clear();
		}
	}
}
