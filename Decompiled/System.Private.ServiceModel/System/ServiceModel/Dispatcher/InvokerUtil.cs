using System.Collections.Generic;
using System.Reflection;

namespace System.ServiceModel.Dispatcher;

internal sealed class InvokerUtil
{
	private class CriticalHelper
	{
		internal InvokeDelegate GenerateInvokeDelegate(MethodInfo method, out int inputParameterCount, out int outputParameterCount)
		{
			ParameterInfo[] parameters = method.GetParameters();
			bool returnsValue = method.ReturnType != typeof(void);
			int inputCount = parameters.Length;
			inputParameterCount = inputCount;
			List<int> list = new List<int>();
			for (int i = 0; i < inputParameterCount; i++)
			{
				if (parameters[i].ParameterType.IsByRef)
				{
					list.Add(i);
				}
			}
			int[] outputPos = list.ToArray();
			outputParameterCount = outputPos.Length;
			return delegate(object target, object[] inputs, object[] outputs)
			{
				object[] array = null;
				if (inputCount > 0)
				{
					array = new object[inputCount];
					for (int j = 0; j < inputCount; j++)
					{
						array[j] = inputs[j];
					}
				}
				object result = null;
				if (returnsValue)
				{
					result = method.Invoke(target, array);
				}
				else
				{
					method.Invoke(target, array);
				}
				for (int k = 0; k < outputPos.Length; k++)
				{
					outputs[k] = inputs[outputPos[k]];
				}
				return result;
			};
		}
	}

	private readonly CriticalHelper _helper;

	public InvokerUtil()
	{
		_helper = new CriticalHelper();
	}

	internal InvokeDelegate GenerateInvokeDelegate(MethodInfo method, out int inputParameterCount, out int outputParameterCount)
	{
		return _helper.GenerateInvokeDelegate(method, out inputParameterCount, out outputParameterCount);
	}
}
