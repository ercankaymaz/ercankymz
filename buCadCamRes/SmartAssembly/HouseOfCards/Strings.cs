// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.Strings
// Assembly: buCadCamRes, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: E90DB10B-14C6-404B-A6C3-E5D8AB0844F3
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCadCamRes.dll

using ns1;
using ns9;
using SmartAssembly.Delegates;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class Strings
{
  [Attribute1]
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
          foreach (MethodInfo method in typeof (Class14.Class15).GetMethods(BindingFlags.Static | BindingFlags.Public))
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
