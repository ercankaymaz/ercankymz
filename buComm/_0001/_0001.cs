// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buComm, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: F368091B-602E-4A5D-88CB-765F3FC3A1DE
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buComm.dll

using SmartAssembly.Delegates;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace \u0001;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
internal sealed class \u0001 : Attribute
{
  [\u0001.\u0003]
  public static void CreateGetStringDelegate(Type ownerType)
  {
    foreach (FieldInfo field in ownerType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField))
    {
      try
      {
        if ((object) field.FieldType == (object) typeof (GetString))
        {
          DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof (string), new Type[1]
          {
            typeof (int)
          }, ownerType.Module, true);
          ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
          ilGenerator.Emit(OpCodes.Ldarg_0);
          foreach (MethodInfo method in typeof (\u0003.\u0002.\u0001).GetMethods(BindingFlags.Static | BindingFlags.Public))
          {
            if ((object) method.ReturnType == (object) typeof (string))
            {
              ilGenerator.Emit(OpCodes.Ldc_I4, field.MetadataToken & 16777215 /*0xFFFFFF*/);
              ilGenerator.Emit(OpCodes.Sub);
              ilGenerator.Emit(OpCodes.Call, method);
              break;
            }
          }
          ilGenerator.Emit(OpCodes.Ret);
          field.SetValue((object) null, (object) dynamicMethod.CreateDelegate(typeof (GetString)));
          break;
        }
      }
      catch
      {
      }
    }
  }
}
