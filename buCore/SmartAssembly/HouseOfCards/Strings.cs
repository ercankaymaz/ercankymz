// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.Strings
// Assembly: buCore, Version=5.1.1.3, Culture=neutral, PublicKeyToken=null
// MVID: 75A66F79-5BE1-42D4-8188-CDC69C2B6DAA
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buCore.dll

using ns0;
using ns7;
using SmartAssembly.Delegates;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class Strings
{
  [Attribute0]
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
          foreach (MethodInfo method in typeof (Class32.Class33).GetMethods(BindingFlags.Static | BindingFlags.Public))
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
