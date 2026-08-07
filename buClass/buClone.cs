// Decompiled with JetBrains decompiler
// Type: buClass.buClone
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Reflection;

#nullable disable
namespace buClass;

public class buClone
{
  public static T DeepCopy<T>(T obj)
  {
    return (object) obj != null ? (T) buClone.Process((object) obj) : throw new ArgumentNullException("Object cannot be null");
  }

  private static object Process(object obj)
  {
    if (obj == null)
      return (object) null;
    Type type1 = obj.GetType();
    if (type1.IsValueType || type1 == typeof (string))
      return obj;
    if (type1.IsArray)
    {
      Type type2 = Type.GetType(type1.FullName.Replace("[]", string.Empty));
      Array array = obj as Array;
      Array instance = Array.CreateInstance(type2, array.Length);
      for (int index = 0; index < array.Length; ++index)
        instance.SetValue(buClone.Process(array.GetValue(index)), index);
      return Convert.ChangeType((object) instance, obj.GetType());
    }
    if (!type1.IsClass)
      throw new ArgumentException("Unknown type");
    object instance1 = Activator.CreateInstance(obj.GetType());
    foreach (FieldInfo field in type1.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
    {
      object obj1 = field.GetValue(obj);
      if (obj1 != null)
        field.SetValue(instance1, buClone.Process(obj1));
    }
    return instance1;
  }
}
