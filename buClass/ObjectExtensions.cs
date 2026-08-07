// Decompiled with JetBrains decompiler
// Type: buClass.ObjectExtensions
// Assembly: buClass, Version=5.1.1.6, Culture=neutral, PublicKeyToken=null
// MVID: BF06766D-B74F-405A-BD20-8E95A229023C
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buClass.dll

using System;
using System.Collections.Generic;
using System.Reflection;

#nullable disable
namespace buClass;

public static class ObjectExtensions
{
  private static readonly MethodInfo CloneMethod = typeof (object).GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);

  public static bool IsPrimitive(this Type type)
  {
    return type == typeof (string) || type.IsValueType & type.IsPrimitive;
  }

  public static object DeepClone(this object obj)
  {
    return ObjectExtensions.DeepClone_Internal(obj, (IDictionary<object, object>) new Dictionary<object, object>((IEqualityComparer<object>) new ObjectExtensions.ReferenceEqualityComparer()));
  }

  public static T DeepClone<T>(this T obj) => (T) ((object) obj).DeepClone();

  private static object DeepClone_Internal(object obj, IDictionary<object, object> visited)
  {
    if (obj == null)
      return (object) null;
    Type type = obj.GetType();
    if (type.IsPrimitive())
      return obj;
    if (visited.ContainsKey(obj))
      return visited[obj];
    if (typeof (Delegate).IsAssignableFrom(type))
      return (object) null;
    object cloneObject = ObjectExtensions.CloneMethod.Invoke(obj, (object[]) null);
    if (type.IsArray && !type.GetElementType().IsPrimitive())
    {
      Array clonedArray = (Array) cloneObject;
      clonedArray.ForEach((Action<Array, int[]>) ((array, indices) => array.SetValue(ObjectExtensions.DeepClone_Internal(clonedArray.GetValue(indices), visited), indices)));
    }
    visited.Add(obj, cloneObject);
    ObjectExtensions.CopyFields(obj, visited, cloneObject, type);
    ObjectExtensions.RecursiveCopyBaseTypePrivateFields(obj, visited, cloneObject, type);
    return cloneObject;
  }

  private static void RecursiveCopyBaseTypePrivateFields(
    object originalObject,
    IDictionary<object, object> visited,
    object cloneObject,
    Type typeToReflect)
  {
    if (!(typeToReflect.BaseType != (Type) null))
      return;
    ObjectExtensions.RecursiveCopyBaseTypePrivateFields(originalObject, visited, cloneObject, typeToReflect.BaseType);
    ObjectExtensions.CopyFields(originalObject, visited, cloneObject, typeToReflect.BaseType, BindingFlags.Instance | BindingFlags.NonPublic, (Func<FieldInfo, bool>) (info => info.IsPrivate));
  }

  private static void CopyFields(
    object originalObject,
    IDictionary<object, object> visited,
    object cloneObject,
    Type typeToReflect,
    BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy,
    Func<FieldInfo, bool> filter = null)
  {
    foreach (FieldInfo field in typeToReflect.GetFields(bindingFlags))
    {
      if ((filter == null || filter(field)) && !field.FieldType.IsPrimitive())
      {
        object obj = ObjectExtensions.DeepClone_Internal(field.GetValue(originalObject), visited);
        field.SetValue(cloneObject, obj);
      }
    }
  }

  public static void ForEach(this Array array, Action<Array, int[]> action)
  {
    if (array.LongLength == 0L)
      return;
    ObjectExtensions.ArrayTraverse arrayTraverse = new ObjectExtensions.ArrayTraverse(array);
    do
    {
      action(array, arrayTraverse.Position);
    }
    while (arrayTraverse.Step());
  }

  internal class ReferenceEqualityComparer : EqualityComparer<object>
  {
    public override bool Equals(object x, object y) => x == y;

    public override int GetHashCode(object obj) => obj == null ? 0 : obj.GetHashCode();
  }

  internal class ArrayTraverse
  {
    public int[] Position;
    private int[] maxLengths;

    public ArrayTraverse(Array array)
    {
      this.maxLengths = new int[array.Rank];
      for (int dimension = 0; dimension < array.Rank; ++dimension)
        this.maxLengths[dimension] = array.GetLength(dimension) - 1;
      this.Position = new int[array.Rank];
    }

    public bool Step()
    {
      for (int index1 = 0; index1 < this.Position.Length; ++index1)
      {
        if (this.Position[index1] < this.maxLengths[index1])
        {
          ++this.Position[index1];
          for (int index2 = 0; index2 < index1; ++index2)
            this.Position[index2] = 0;
          return true;
        }
      }
      return false;
    }
  }
}
