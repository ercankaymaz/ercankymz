using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ODA.Kernel.TD_RootIntegrated;

public abstract class InternalHelper_ProcessingPickTypes
{
	private string m_find_ClassPreffixName;

	private HashSet<Assembly> m_processedAssemblies = new HashSet<Assembly>();

	private HashSet<Type> m_processedTypes = new HashSet<Type>();

	public InternalHelper_ProcessingPickTypes(string find_ClassPreffixName)
	{
		m_find_ClassPreffixName = find_ClassPreffixName;
		Initialize();
		AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
	}

	private void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
	{
		Initialize();
	}

	private void Initialize()
	{
		Type[] array = FindHelperTypes();
		if (array.Length != 0)
		{
			InitializeImpl(array);
		}
	}

	private Type[] FindHelperTypes()
	{
		new List<Type>();
		Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
		foreach (Assembly assembly in assemblies)
		{
			if (m_processedAssemblies.Contains(assembly))
			{
				continue;
			}
			m_processedAssemblies.Add(assembly);
			Type[] types = assembly.GetTypes();
			for (int j = 0; j < types.Length; j++)
			{
				if (!m_processedTypes.Contains(types[j]) && types[j].Name.StartsWith(m_find_ClassPreffixName))
				{
					m_processedTypes.Add(types[j]);
				}
			}
		}
		return m_processedTypes.ToArray();
	}

	protected abstract void InitializeImpl(IEnumerable<Type> types);
}
