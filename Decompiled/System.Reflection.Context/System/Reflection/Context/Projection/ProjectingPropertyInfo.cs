using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingPropertyInfo : DelegatingPropertyInfo, IProjectable
{
	public Projector Projector { get; }

	public override Type DeclaringType => Projector.ProjectType(base.DeclaringType);

	public override Module Module => Projector.ProjectModule(base.Module);

	public override Type PropertyType => Projector.ProjectType(base.PropertyType);

	public override Type ReflectedType => Projector.ProjectType(base.ReflectedType);

	public ProjectingPropertyInfo(PropertyInfo property, Projector projector)
		: base(property)
	{
		Projector = projector;
	}

	public override MethodInfo[] GetAccessors(bool nonPublic)
	{
		return Projector.Project(base.GetAccessors(nonPublic), Projector.ProjectMethod);
	}

	public override MethodInfo GetGetMethod(bool nonPublic)
	{
		return Projector.ProjectMethod(base.GetGetMethod(nonPublic));
	}

	public override ParameterInfo[] GetIndexParameters()
	{
		return Projector.Project(base.GetIndexParameters(), Projector.ProjectParameter);
	}

	public override MethodInfo GetSetMethod(bool nonPublic)
	{
		return Projector.ProjectMethod(base.GetSetMethod(nonPublic));
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

	public override Type[] GetOptionalCustomModifiers()
	{
		return Projector.Project(base.GetOptionalCustomModifiers(), Projector.ProjectType);
	}

	public override Type[] GetRequiredCustomModifiers()
	{
		return Projector.Project(base.GetRequiredCustomModifiers(), Projector.ProjectType);
	}

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is ProjectingPropertyInfo projectingPropertyInfo && Projector == projectingPropertyInfo.Projector)
		{
			return base.UnderlyingProperty.Equals(projectingPropertyInfo.UnderlyingProperty);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingProperty.GetHashCode();
	}
}
