using System.Collections.Generic;

namespace System.Reflection.Context.Delegation;

internal class DelegatingEventInfo : EventInfo
{
	public override EventAttributes Attributes => UnderlyingEvent.Attributes;

	public override Type DeclaringType => UnderlyingEvent.DeclaringType;

	public override Type EventHandlerType => UnderlyingEvent.EventHandlerType;

	public override bool IsMulticast => UnderlyingEvent.IsMulticast;

	public override int MetadataToken => UnderlyingEvent.MetadataToken;

	public override Module Module => UnderlyingEvent.Module;

	public override string Name => UnderlyingEvent.Name;

	public override Type ReflectedType => UnderlyingEvent.ReflectedType;

	public EventInfo UnderlyingEvent { get; }

	public DelegatingEventInfo(EventInfo @event)
	{
		UnderlyingEvent = @event;
	}

	public override void AddEventHandler(object target, Delegate handler)
	{
		UnderlyingEvent.AddEventHandler(target, handler);
	}

	public override MethodInfo GetAddMethod(bool nonPublic)
	{
		return UnderlyingEvent.GetAddMethod(nonPublic);
	}

	public override MethodInfo[] GetOtherMethods(bool nonPublic)
	{
		return UnderlyingEvent.GetOtherMethods(nonPublic);
	}

	public override MethodInfo GetRaiseMethod(bool nonPublic)
	{
		return UnderlyingEvent.GetRaiseMethod(nonPublic);
	}

	public override MethodInfo GetRemoveMethod(bool nonPublic)
	{
		return UnderlyingEvent.GetRemoveMethod(nonPublic);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingEvent.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingEvent.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingEvent.GetCustomAttributesData();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingEvent.IsDefined(attributeType, inherit);
	}

	public override void RemoveEventHandler(object target, Delegate handler)
	{
		UnderlyingEvent.RemoveEventHandler(target, handler);
	}

	public override string ToString()
	{
		return UnderlyingEvent.ToString();
	}
}
