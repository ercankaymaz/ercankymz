using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingFieldInfo : DelegatingFieldInfo, IProjectable
{
	public Projector Projector { get; }

	public override Type DeclaringType => Projector.ProjectType(base.DeclaringType);

	public override Type FieldType => Projector.ProjectType(base.FieldType);

	public override Module Module => Projector.ProjectModule(base.Module);

	public override Type ReflectedType => Projector.ProjectType(base.ReflectedType);

	public ProjectingFieldInfo(FieldInfo field, Projector projector)
		: base(field)
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
		if (o is ProjectingFieldInfo projectingFieldInfo && Projector == projectingFieldInfo.Projector)
		{
			return base.UnderlyingField.Equals(projectingFieldInfo.UnderlyingField);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingField.GetHashCode();
	}
}
