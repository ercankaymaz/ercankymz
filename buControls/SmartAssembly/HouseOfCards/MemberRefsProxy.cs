// Decompiled with JetBrains decompiler
// Type: SmartAssembly.HouseOfCards.MemberRefsProxy
// Assembly: buControls, Version=5.1.1.4, Culture=neutral, PublicKeyToken=null
// MVID: 8B369C0A-23E7-45ED-9051-267DACDF7858
// Assembly location: C:\Users\ERCAN\Desktop\CMDMarbleCNC\buControls.dll

using ns22;
using System;
using System.Reflection;
using System.Reflection.Emit;

#nullable disable
namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
  private static ModuleHandle moduleHandle_0;
  private static char[] char_0 = new char[58]
  {
    '\u0001',
    '\u0002',
    '\u0003',
    '\u0004',
    '\u0005',
    '\u0006',
    '\a',
    '\b',
    '\u000E',
    '\u000F',
    '\u0010',
    '\u0011',
    '\u0012',
    '\u0013',
    '\u0014',
    '\u0015',
    '\u0016',
    '\u0017',
    '\u0018',
    '\u0019',
    '\u001A',
    '\u001B',
    '\u001C',
    '\u001D',
    '\u001E',
    '\u001F',
    '\u007F',
    '\u0080',
    '\u0081',
    '\u0082',
    '\u0083',
    '\u0084',
    '\u0086',
    '\u0087',
    '\u0088',
    '\u0089',
    '\u008A',
    '\u008B',
    '\u008C',
    '\u008D',
    '\u008E',
    '\u008F',
    '\u0090',
    '\u0091',
    '\u0092',
    '\u0093',
    '\u0094',
    '\u0095',
    '\u0096',
    '\u0097',
    '\u0098',
    '\u0099',
    '\u009A',
    '\u009B',
    '\u009C',
    '\u009D',
    '\u009E',
    '\u009F'
  };

  [Attribute1]
  public static void CreateMemberRefsDelegates(int typeID)
  {
    Type typeFromHandle;
    try
    {
      typeFromHandle = Type.GetTypeFromHandle(MemberRefsProxy.moduleHandle_0.ResolveTypeHandle(33554433 /*0x02000001*/ + typeID));
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
            if ((int) MemberRefsProxy.char_0[index2] == (int) ch)
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
        methodFromHandle = (MethodInfo) MethodBase.GetMethodFromHandle(MemberRefsProxy.moduleHandle_0.ResolveMethodHandle(num + 167772161 /*0x0A000001*/));
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

  static MemberRefsProxy()
  {
    if ((object) typeof (MulticastDelegate) == null)
      return;
    MemberRefsProxy.moduleHandle_0 = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
  }
}
