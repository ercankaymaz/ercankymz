// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buPowerNest, Version=5.1.1.1, Culture=neutral, PublicKeyToken=null
// MVID: EB8978B5-B2D2-48FE-B448-717DFAAD425B
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buPowerNest.dll

using \u0001;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  public static byte f000062;
  private static ModuleHandle \u0001;

  public abstract void m0001B8();

  [\u0004]
  public static void CreateMemberRefsDelegates(int typeID)
  {
    Type typeFromHandle;
    try
    {
      typeFromHandle = Type.GetTypeFromHandle(MemberRefsProxy.\u0001.ResolveTypeHandle(33554433 /*0x02000001*/ + typeID));
    }
    catch
    {
      return;
    }
    foreach (FieldInfo field in typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField))
    {
      string name = field.Name;
      bool flag = false;
      int num = 0;
      for (int index1 = name.Length - 1; index1 >= 0; --index1)
      {
        char ch = name[index1];
        if (ch != '~')
        {
          for (int index2 = 0; index2 < 58; ++index2)
          {
            if ((int) \u0003.\u0001.\u0001[index2] == (int) ch)
            {
              num = num * 58 + index2;
              break;
            }
          }
        }
        else
        {
          flag = true;
          break;
        }
      }
      MethodInfo methodFromHandle;
      try
      {
        methodFromHandle = (MethodInfo) MethodBase.GetMethodFromHandle(MemberRefsProxy.\u0001.ResolveMethodHandle(num + 167772161 /*0x0A000001*/));
      }
      catch
      {
        continue;
      }
      Delegate @delegate;
      if (methodFromHandle.IsStatic)
      {
        try
        {
          @delegate = Delegate.CreateDelegate(field.FieldType, methodFromHandle);
        }
        catch (Exception ex)
        {
          continue;
        }
      }
      else
      {
        ParameterInfo[] parameters = methodFromHandle.GetParameters();
        int length = parameters.Length + 1;
        Type[] parameterTypes = new Type[length];
        parameterTypes[0] = typeof (object);
        for (int index = 1; index < length; ++index)
          parameterTypes[index] = parameters[index - 1].ParameterType;
        DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodFromHandle.ReturnType, parameterTypes, typeFromHandle, true);
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        if (length > 1)
          ilGenerator.Emit(OpCodes.Ldarg_1);
        if (length > 2)
          ilGenerator.Emit(OpCodes.Ldarg_2);
        if (length > 3)
          ilGenerator.Emit(OpCodes.Ldarg_3);
        if (length > 4)
        {
          for (int index = 4; index < length; ++index)
            ilGenerator.Emit(OpCodes.Ldarg_S, index);
        }
        ilGenerator.Emit(OpCodes.Tailcall);
        ilGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodFromHandle);
        ilGenerator.Emit(OpCodes.Ret);
        try
        {
          @delegate = dynamicMethod.CreateDelegate(typeFromHandle);
        }
        catch
        {
          continue;
        }
      }
      try
      {
        field.SetValue((object) null, (object) @delegate);
      }
      catch
      {
      }
    }
  }
}
