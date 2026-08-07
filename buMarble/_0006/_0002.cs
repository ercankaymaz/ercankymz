// Decompiled with JetBrains decompiler
// Type: .
// Assembly: buMarble, Version=5.1.1.2, Culture=neutral, PublicKeyToken=null
// MVID: D6F2AAC2-9013-4D8E-A4D2-15511BAB107F
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buMarble.dll

using SmartAssembly.Delegates;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace \u0006;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate)]
internal class \u0002 : Attribute
{
  [\u0003]
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
          foreach (MethodInfo method in typeof (\u0001.\u0003.\u0001).GetMethods(BindingFlags.Static | BindingFlags.Public))
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
