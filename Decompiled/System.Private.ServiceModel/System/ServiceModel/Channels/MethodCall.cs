using System.Reflection;
using System.ServiceModel.Description;

namespace System.ServiceModel.Channels;

internal class MethodCall
{
	private object[] _inArgs;

	public MethodBase MethodBase { get; private set; }

	public object[] Args { get; private set; }

	public object[] InArgs => _inArgs ?? Args;

	public MethodCall(object[] args)
	{
		Args = args;
	}

	public MethodCall(MethodBase methodBase, object[] args)
		: this(args)
	{
		MethodBase = methodBase;
		CreateInArgs();
	}

	private void CreateInArgs()
	{
		ParameterInfo[] parameters = MethodBase.GetParameters();
		int num = 0;
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo paramInfo in array)
		{
			if (ServiceReflector.FlowsIn(paramInfo))
			{
				num++;
			}
		}
		if (num == Args.Length)
		{
			return;
		}
		_inArgs = new object[num];
		int num2 = 0;
		for (int j = 0; j < parameters.Length; j++)
		{
			if (ServiceReflector.FlowsIn(parameters[j]))
			{
				_inArgs[num2] = Args[j];
				num2++;
			}
		}
	}
}
