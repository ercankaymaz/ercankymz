using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design;

public class AssemblyReferences : ContextItem
{
	private AssemblyName[] _referencedAssemblies;

	private AssemblyName _localAssemblyName;

	private static Dictionary<string, Assembly> _loadedAssemblyTable;

	public sealed override Type ItemType => typeof(AssemblyReferences);

	private static IDictionary<string, Assembly> LoadedAssemblyTable
	{
		get
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			Dictionary<string, Assembly> dictionary = _loadedAssemblyTable;
			if (dictionary == null || dictionary.Count != assemblies.Length)
			{
				if (dictionary == null)
				{
					dictionary = new Dictionary<string, Assembly>(assemblies.Length);
				}
				lock (dictionary)
				{
					foreach (Assembly assembly in assemblies)
					{
						dictionary[assembly.FullName] = assembly;
					}
					_loadedAssemblyTable = dictionary;
				}
			}
			return dictionary;
		}
	}

	public IEnumerable<AssemblyName> ReferencedAssemblies => _referencedAssemblies;

	public AssemblyName LocalAssemblyName => _localAssemblyName;

	public AssemblyReferences()
	{
		_referencedAssemblies = new AssemblyName[0];
	}

	public AssemblyReferences(IEnumerable<AssemblyName> newReferences)
	{
		BuildAssemblyReferences(newReferences);
	}

	public AssemblyReferences(AssemblyName localAssemblyName, IEnumerable<AssemblyName> newReferences)
	{
		_localAssemblyName = localAssemblyName;
		BuildAssemblyReferences(newReferences);
	}

	public IEnumerable<Type> GetTypes(Type baseType)
	{
		AssemblyName[] names = new AssemblyName[_referencedAssemblies.Length];
		_referencedAssemblies.CopyTo(names, 0);
		IDictionary<string, Assembly> assemblyTable = LoadedAssemblyTable;
		for (int idx = 0; idx < names.Length; idx++)
		{
			if (!assemblyTable.TryGetValue(names[idx].FullName, out var a))
			{
				continue;
			}
			names[idx] = null;
			try
			{
				Type[] types = a.GetTypes();
				foreach (Type t in types)
				{
					if (baseType.IsAssignableFrom(t))
					{
						yield return t;
					}
				}
			}
			finally
			{
			}
		}
		foreach (AssemblyName name in names)
		{
			if (name == null)
			{
				continue;
			}
			Type[] types2 = null;
			try
			{
				Assembly assembly = Assembly.Load(name);
				if ((object)assembly != null)
				{
					types2 = assembly.GetTypes();
				}
			}
			catch (FileNotFoundException)
			{
			}
			catch (BadImageFormatException)
			{
			}
			catch (FileLoadException)
			{
			}
			catch (ReflectionTypeLoadException)
			{
			}
			if (types2 == null)
			{
				break;
			}
			try
			{
				Type[] array = types2;
				foreach (Type t2 in array)
				{
					if (baseType.IsAssignableFrom(t2))
					{
						yield return t2;
					}
				}
			}
			finally
			{
			}
		}
	}

	protected override void OnItemChanged(EditingContext context, ContextItem previousItem)
	{
		AssemblyReferences assemblyReferences = (AssemblyReferences)previousItem;
		if (assemblyReferences._referencedAssemblies.Length > 0)
		{
			if (_localAssemblyName != null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.Error_LocalAssemblyNameChanged));
			}
			_localAssemblyName = assemblyReferences._localAssemblyName;
			List<AssemblyName> list = new List<AssemblyName>(assemblyReferences._referencedAssemblies.Length + _referencedAssemblies.Length);
			list.AddRange(assemblyReferences._referencedAssemblies);
			AssemblyName[] referencedAssemblies = _referencedAssemblies;
			foreach (AssemblyName assemblyName in referencedAssemblies)
			{
				bool flag = true;
				foreach (AssemblyName item in list)
				{
					if (item.FullName.Equals(assemblyName.FullName))
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					list.Add(assemblyName);
				}
			}
			_referencedAssemblies = list.ToArray();
		}
		base.OnItemChanged(context, previousItem);
	}

	private void BuildAssemblyReferences(IEnumerable<AssemblyName> newReferences)
	{
		if (newReferences == null)
		{
			throw new ArgumentNullException("newReferences");
		}
		int num = newReferences.Count();
		if (_localAssemblyName != null)
		{
			num++;
		}
		_referencedAssemblies = new AssemblyName[num];
		int num2 = 0;
		foreach (AssemblyName newReference in newReferences)
		{
			if (newReference == null)
			{
				throw new ArgumentNullException("newReferences");
			}
			_referencedAssemblies[num2++] = newReference;
		}
		if (_localAssemblyName != null)
		{
			_referencedAssemblies[num2] = _localAssemblyName;
		}
	}
}
