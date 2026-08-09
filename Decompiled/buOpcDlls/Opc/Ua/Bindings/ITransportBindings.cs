using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Opc.Ua.Bindings;

[ComVisible(true)]
public interface ITransportBindings<T>
{
	T GetBinding(string uriScheme);

	bool HasBinding(string uriScheme);

	void SetBinding(T binding);

	IEnumerable<Type> AddBindings(Assembly assembly);

	IEnumerable<Type> AddBindings(IEnumerable<Type> bindings);
}
