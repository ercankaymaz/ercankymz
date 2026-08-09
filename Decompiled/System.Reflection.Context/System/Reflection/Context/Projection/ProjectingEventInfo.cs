using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingEventInfo : DelegatingEventInfo, IProjectable
{
	public Projector Projector { get; }

	public override Type DeclaringType => Projector.ProjectType(base.DeclaringType);

	public override Type EventHandlerType => Projector.ProjectType(base.EventHandlerType);

	public override Module Module => Projector.ProjectModule(base.Module);

	public override Type ReflectedType => Projector.ProjectType(base.ReflectedType);

	public ProjectingEventInfo(EventInfo @event, Projector projector)
		: base(@event)
	{
		Projector = projector;
	}

	public override MethodInfo GetAddMethod(bool nonPublic)
	{
		return Projector.ProjectMethod(base.GetAddMethod(nonPublic));
	}

	public override MethodInfo[] GetOtherMethods(bool nonPublic)
	{
		return Projector.Project(base.GetOtherMethods(nonPublic), Projector.ProjectMethod);
	}

	public override MethodInfo GetRaiseMethod(bool nonPublic)
	{
		return Projector.ProjectMethod(base.GetRaiseMethod(nonPublic));
	}

	public override MethodInfo GetRemoveMethod(bool nonPublic)
	{
		return Projector.ProjectMethod(base.GetRemoveMethod(nonPublic));
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

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is ProjectingEventInfo projectingEventInfo && Projector == projectingEventInfo.Projector)
		{
			return base.UnderlyingEvent.Equals(projectingEventInfo.UnderlyingEvent);
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingEvent.GetHashCode();
	}
}
