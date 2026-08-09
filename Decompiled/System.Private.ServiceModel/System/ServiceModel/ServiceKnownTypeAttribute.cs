namespace System.ServiceModel;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, Inherited = true, AllowMultiple = true)]
public sealed class ServiceKnownTypeAttribute : Attribute
{
	private Type _type;

	public Type DeclaringType { get; }

	public string MethodName { get; }

	public Type Type => _type;

	private ServiceKnownTypeAttribute()
	{
	}

	public ServiceKnownTypeAttribute(Type type)
	{
		_type = type;
	}

	public ServiceKnownTypeAttribute(string methodName)
	{
		MethodName = methodName;
	}

	public ServiceKnownTypeAttribute(string methodName, Type declaringType)
	{
		MethodName = methodName;
		DeclaringType = declaringType;
	}
}
