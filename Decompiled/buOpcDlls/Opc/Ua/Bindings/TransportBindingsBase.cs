using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public class TransportBindingsBase<T> : ITransportBindings<T> where T : class, ITransportBindingScheme
{
	protected Dictionary<string, T> Bindings { get; private set; }

	protected TransportBindingsBase()
	{
		Bindings = new Dictionary<string, T>();
		AddBindings(typeof(TransportBindingsBase<T>).Assembly);
	}

	protected TransportBindingsBase(Type[] defaultBindings)
	{
		Bindings = new Dictionary<string, T>();
		AddBindings(defaultBindings);
	}

	public T GetBinding(string uriScheme)
	{
		if (!Bindings.TryGetValue(uriScheme, out var value))
		{
			TryAddDefaultTransportBindings(uriScheme);
			if (!Bindings.TryGetValue(uriScheme, out value))
			{
				return null;
			}
		}
		return value;
	}

	public bool HasBinding(string uriScheme)
	{
		if (Bindings.TryGetValue(uriScheme, out var _))
		{
			return true;
		}
		return false;
	}

	public void SetBinding(T binding)
	{
		Bindings[binding.UriScheme] = binding;
	}

	public IEnumerable<Type> AddBindings(Assembly assembly)
	{
		IEnumerable<Type> bindings = from type in assembly.GetExportedTypes()
			where IsBindingType(type)
			select type;
		return AddBindings(bindings);
	}

	public IEnumerable<Type> AddBindings(IEnumerable<Type> bindings)
	{
		List<Type> list = new List<Type>();
		foreach (Type binding in bindings)
		{
			if (Activator.CreateInstance(binding) is T val)
			{
				Bindings[val.UriScheme] = val;
				list.Add(binding);
			}
		}
		return list;
	}

	protected static bool IsBindingType(Type bindingType)
	{
		if (bindingType == null)
		{
			return false;
		}
		System.Reflection.TypeInfo typeInfo = bindingType.GetTypeInfo();
		if (typeInfo.IsAbstract || !typeof(T).GetTypeInfo().IsAssignableFrom(typeInfo))
		{
			return false;
		}
		if (Activator.CreateInstance(bindingType) as T == null)
		{
			return false;
		}
		return true;
	}

	private bool TryAddDefaultTransportBindings(string scheme)
	{
		if (Utils.DefaultBindings.TryGetValue(scheme, out var value))
		{
			Assembly assembly = null;
			string text = Utils.DefaultOpcUaCoreAssemblyFullName.Replace(Utils.DefaultOpcUaCoreAssemblyName, value);
			try
			{
				assembly = Assembly.Load(text);
			}
			catch
			{
				Utils.LogError("Failed to load the assembly {0} for transport binding {1}.", text, scheme);
			}
			if (assembly != null)
			{
				return AddBindings(assembly).Any();
			}
		}
		else
		{
			Utils.LogError("The transport binding {0} is unsupported.", scheme);
		}
		return false;
	}
}
