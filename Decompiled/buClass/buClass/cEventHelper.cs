using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace buClass;

public static class cEventHelper
{
	private static Dictionary<Type, List<FieldInfo>> dicEventFieldInfos = new Dictionary<Type, List<FieldInfo>>();

	private static BindingFlags AllBindings => BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;

	private static List<FieldInfo> GetTypeEventFields(Type t)
	{
		if (dicEventFieldInfos.ContainsKey(t))
		{
			return dicEventFieldInfos[t];
		}
		List<FieldInfo> list = new List<FieldInfo>();
		BuildEventFields(t, list);
		dicEventFieldInfos.Add(t, list);
		return list;
	}

	private static void BuildEventFields(Type t, List<FieldInfo> lst)
	{
		EventInfo[] events = t.GetEvents(AllBindings);
		foreach (EventInfo eventInfo in events)
		{
			Type declaringType = eventInfo.DeclaringType;
			FieldInfo field = declaringType.GetField(eventInfo.Name, AllBindings);
			if (field != null)
			{
				lst.Add(field);
			}
		}
	}

	private static EventHandlerList GetStaticEventHandlerList(Type t, object obj)
	{
		MethodInfo method = t.GetMethod("get_Events", AllBindings);
		return (EventHandlerList)method.Invoke(obj, new object[0]);
	}

	public static void RemoveAllEventHandlers(object obj)
	{
		RemoveEventHandler(obj, "");
	}

	public static void RemoveEventHandler(object obj, string EventName)
	{
		if (obj == null)
		{
			return;
		}
		Type type = obj.GetType();
		List<FieldInfo> typeEventFields = GetTypeEventFields(type);
		EventHandlerList eventHandlerList = null;
		foreach (FieldInfo item in typeEventFields)
		{
			if (EventName != "" && string.Compare(EventName, item.Name, ignoreCase: true) != 0)
			{
				continue;
			}
			if (item.IsStatic)
			{
				if (eventHandlerList == null)
				{
					eventHandlerList = GetStaticEventHandlerList(type, obj);
				}
				object value = item.GetValue(obj);
				Delegate obj2 = eventHandlerList[value];
				if ((object)obj2 == null)
				{
					continue;
				}
				Delegate[] invocationList = obj2.GetInvocationList();
				if (invocationList != null)
				{
					EventInfo eventInfo = type.GetEvent(item.Name, AllBindings);
					Delegate[] array = invocationList;
					foreach (Delegate handler in array)
					{
						eventInfo.RemoveEventHandler(obj, handler);
					}
				}
				continue;
			}
			EventInfo eventInfo2 = type.GetEvent(item.Name, AllBindings);
			if (!(eventInfo2 != null))
			{
				continue;
			}
			object value2 = item.GetValue(obj);
			if (value2 is Delegate obj3)
			{
				Delegate[] invocationList2 = obj3.GetInvocationList();
				foreach (Delegate handler2 in invocationList2)
				{
					eventInfo2.RemoveEventHandler(obj, handler2);
				}
			}
		}
	}
}
