using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingParameterInfo : DelegatingParameterInfo, IProjectable
{
	public Projector Projector { get; }

	public override MemberInfo Member => Projector.ProjectMember(base.Member);

	public override Type ParameterType => Projector.ProjectType(base.ParameterType);

	public ProjectingParameterInfo(ParameterInfo parameter, Projector projector)
		: base(parameter)
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
		if (o is ProjectingParameterInfo projectingParameterInfo && Projector == projectingParameterInfo.Projector)
		{
			return base.UnderlyingParameter.Equals(projectingParameterInfo.UnderlyingParameter);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingParameter.GetHashCode();
	}
}
