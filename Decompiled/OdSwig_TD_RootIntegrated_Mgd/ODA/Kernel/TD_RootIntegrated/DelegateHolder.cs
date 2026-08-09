using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ODA.Kernel.TD_RootIntegrated;

public class DelegateHolder
{
	private static DelegateHolder m_holder = new DelegateHolder();

	private List<Delegate> m_collection;

	private DelegateHolder()
	{
		m_collection = new List<Delegate>();
	}

	~DelegateHolder()
	{
		Clear();
	}

	public static void Add(Delegate _delegate)
	{
		lock (m_holder)
		{
			m_holder.m_collection.Add(_delegate);
		}
	}

	public static void Clear()
	{
		lock (m_holder)
		{
			m_holder.m_collection.Clear();
		}
	}

	public static void OnHoldSwigDirectorDelegates<TType>(TType targetObject)
	{
		if (targetObject == null)
		{
			return;
		}
		foreach (FieldInfo item in from x in typeof(TType).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
			where x.Name.StartsWith("swigDelegate")
			select x)
		{
			if (item.GetValue(targetObject) is Delegate obj)
			{
				Add(obj);
			}
		}
	}
}
