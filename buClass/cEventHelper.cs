// Decompiled with JetBrains decompiler
// Type: buClass.cEventHelper
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

#nullable disable
namespace buClass;

public static class cEventHelper
{
  private static Dictionary<Type, List<FieldInfo>> dicEventFieldInfos = new Dictionary<Type, List<FieldInfo>>();

  private static BindingFlags AllBindings
  {
    get
    {
      return BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
    }
  }

  private static List<FieldInfo> GetTypeEventFields(Type t)
  {
    if (cEventHelper.dicEventFieldInfos.ContainsKey(t))
      return cEventHelper.dicEventFieldInfos[t];
    List<FieldInfo> lst = new List<FieldInfo>();
    cEventHelper.BuildEventFields(t, lst);
    cEventHelper.dicEventFieldInfos.Add(t, lst);
    return lst;
  }

  private static void BuildEventFields(Type t, List<FieldInfo> lst)
  {
    foreach (EventInfo eventInfo in t.GetEvents(cEventHelper.AllBindings))
    {
      FieldInfo field = eventInfo.DeclaringType.GetField(eventInfo.Name, cEventHelper.AllBindings);
      if (field != (FieldInfo) null)
        lst.Add(field);
    }
  }

  private static EventHandlerList GetStaticEventHandlerList(Type t, object obj)
  {
    return (EventHandlerList) t.GetMethod("get_Events", cEventHelper.AllBindings).Invoke(obj, new object[0]);
  }

  public static void RemoveAllEventHandlers(object obj) => cEventHelper.RemoveEventHandler(obj, "");

  public static void RemoveEventHandler(object obj, string EventName)
  {
    if (obj == null)
      return;
    Type type = obj.GetType();
    List<FieldInfo> typeEventFields = cEventHelper.GetTypeEventFields(type);
    EventHandlerList eventHandlerList = (EventHandlerList) null;
    foreach (FieldInfo fieldInfo in typeEventFields)
    {
      if (!(EventName != "") || string.Compare(EventName, fieldInfo.Name, true) == 0)
      {
        if (fieldInfo.IsStatic)
        {
          if (eventHandlerList == null)
            eventHandlerList = cEventHelper.GetStaticEventHandlerList(type, obj);
          object key = fieldInfo.GetValue(obj);
          Delegate @delegate = eventHandlerList[key];
          if ((object) @delegate != null)
          {
            Delegate[] invocationList = @delegate.GetInvocationList();
            if (invocationList != null)
            {
              EventInfo eventInfo = type.GetEvent(fieldInfo.Name, cEventHelper.AllBindings);
              foreach (Delegate handler in invocationList)
                eventInfo.RemoveEventHandler(obj, handler);
            }
          }
        }
        else
        {
          EventInfo eventInfo = type.GetEvent(fieldInfo.Name, cEventHelper.AllBindings);
          if (eventInfo != (EventInfo) null && fieldInfo.GetValue(obj) is Delegate @delegate)
          {
            foreach (Delegate invocation in @delegate.GetInvocationList())
              eventInfo.RemoveEventHandler(obj, invocation);
          }
        }
      }
    }
  }
}
