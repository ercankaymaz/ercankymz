using System.Collections.Generic;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingConstructorInfo : DelegatingConstructorInfo, IProjectable
{
	public Projector Projector { get; }

	public override Type DeclaringType => Projector.ProjectType(base.DeclaringType);

	public override Module Module => Projector.ProjectModule(base.Module);

	public override Type ReflectedType => Projector.ProjectType(base.ReflectedType);

	public ProjectingConstructorInfo(ConstructorInfo constructor, Projector projector)
		: base(constructor)
	{
		Projector = projector;
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

	public override MethodBody GetMethodBody()
	{
		return Projector.ProjectMethodBody(base.GetMethodBody());
	}

	public override ParameterInfo[] GetParameters()
	{
		return Projector.Project(base.GetParameters(), Projector.ProjectParameter);
	}

	public override bool Equals(object o)
	{
		if (o is ProjectingConstructorInfo projectingConstructorInfo && Projector == projectingConstructorInfo.Projector)
		{
			return base.UnderlyingConstructor.Equals(projectingConstructorInfo.UnderlyingConstructor);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingConstructor.GetHashCode();
	}
}
