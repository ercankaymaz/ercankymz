using System.Collections.Generic;

namespace System.ServiceModel.Channels;

public class BindingParameterCollection : KeyedByTypeCollection<object>
{
	public BindingParameterCollection()
	{
	}

	internal BindingParameterCollection(params object[] parameters)
	{
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		for (int i = 0; i < parameters.Length; i++)
		{
			Add(parameters[i]);
		}
	}

	internal BindingParameterCollection(BindingParameterCollection parameters)
	{
		if (parameters == null)
		{
			throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("parameters");
		}
		for (int i = 0; i < parameters.Count; i++)
		{
			Add(parameters[i]);
		}
	}
}
