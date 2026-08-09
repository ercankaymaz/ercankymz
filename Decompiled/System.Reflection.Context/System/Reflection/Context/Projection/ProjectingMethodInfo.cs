using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingMethodInfo : DelegatingMethodInfo, IProjectable
{
	public Projector Projector { get; }

	public override Type DeclaringType => Projector.ProjectType(base.DeclaringType);

	public override Module Module => Projector.ProjectModule(base.Module);

	public override Type ReflectedType => Projector.ProjectType(base.ReflectedType);

	public override ParameterInfo ReturnParameter => Projector.ProjectParameter(base.ReturnParameter);

	public override ICustomAttributeProvider ReturnTypeCustomAttributes
	{
		get
		{
			ICustomAttributeProvider returnTypeCustomAttributes = base.ReturnTypeCustomAttributes;
			if (returnTypeCustomAttributes is ParameterInfo)
			{
				return Projector.ProjectParameter(ReturnParameter);
			}
			return returnTypeCustomAttributes;
		}
	}

	public override Type ReturnType => Projector.ProjectType(base.ReturnType);

	public ProjectingMethodInfo(MethodInfo method, Projector projector)
		: base(method)
	{
		Projector = projector;
	}

	public override MethodInfo GetBaseDefinition()
	{
		return Projector.ProjectMethod(base.GetBaseDefinition());
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		attributeType = Projector.Unproject(attributeType);
		return base.GetCustomAttributes(attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return Projector.Project(base.GetCustomAttributesData(), Projector.ProjectCustomAttributeData);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		attributeType = Projector.Unproject(attributeType);
		return base.IsDefined(attributeType, inherit);
	}

	public override Type[] GetGenericArguments()
	{
		return Projector.Project(base.GetGenericArguments(), Projector.ProjectType);
	}

	public override MethodInfo GetGenericMethodDefinition()
	{
		return Projector.ProjectMethod(base.GetGenericMethodDefinition());
	}

	public override MethodBody GetMethodBody()
	{
		return Projector.ProjectMethodBody(base.GetMethodBody());
	}

	public override ParameterInfo[] GetParameters()
	{
		return Projector.Project(base.GetParameters(), Projector.ProjectParameter);
	}

	[RequiresUnreferencedCode("If some of the generic arguments are annotated (either with DynamicallyAccessedMembersAttribute, or generic constraints), trimming can't validate that the requirements of those annotations are met.")]
	public override MethodInfo MakeGenericMethod(params Type[] typeArguments)
	{
		return Projector.ProjectMethod(base.MakeGenericMethod(Projector.Unproject(typeArguments)));
	}

	public override Delegate CreateDelegate(Type delegateType)
	{
		return base.CreateDelegate(Projector.Unproject(delegateType));
	}

	public override Delegate CreateDelegate(Type delegateType, object target)
	{
		return base.CreateDelegate(Projector.Unproject(delegateType), target);
	}

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is ProjectingMethodInfo projectingMethodInfo && Projector == projectingMethodInfo.Projector)
		{
			return base.UnderlyingMethod.Equals(projectingMethodInfo.UnderlyingMethod);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingMethod.GetHashCode();
	}
}
