using System;
using System.Reflection;
using System.Reflection.Emit;
using _0001;
using _0008;
using SmartAssembly.Delegates;

namespace SmartAssembly.HouseOfCards;

public static class Strings
{
	[global::_0001._0001]
	public static void CreateGetStringDelegate(Type ownerType)
	{
		FieldInfo[] fields = ownerType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
		int i;
		do
		{
			i = 0;
		}
		while (false);
		MethodInfo[] methods = default(MethodInfo[]);
		int num2 = default(int);
		for (; i < fields.Length; i++)
		{
			FieldInfo fieldInfo = fields[i];
			try
			{
				if ((object)fieldInfo.FieldType != typeof(GetString))
				{
					continue;
				}
				DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, typeof(string), new Type[1] { typeof(int) }, ownerType.Module, skipVisibility: true);
				ILGenerator iLGenerator = dynamicMethod.GetILGenerator();
				iLGenerator.Emit(OpCodes.Ldarg_0);
				if (2 == 0)
				{
					goto IL_00ff;
				}
				methods = typeof(_0008._0005._0001).GetMethods(BindingFlags.Static | BindingFlags.Public);
				int num = 0;
				if (num == 0)
				{
					num2 = num;
					goto IL_0105;
				}
				goto IL_0107;
				IL_0105:
				num = num2;
				goto IL_0107;
				IL_0107:
				if (num < methods.Length)
				{
					MethodInfo methodInfo = methods[num2];
					if ((object)methodInfo.ReturnType != typeof(string))
					{
						goto IL_00ff;
					}
					do
					{
						iLGenerator.Emit(OpCodes.Ldc_I4, fieldInfo.MetadataToken & 0xFFFFFF);
					}
					while (3 == 0);
					iLGenerator.Emit(OpCodes.Sub);
					iLGenerator.Emit(OpCodes.Call, methodInfo);
				}
				iLGenerator.Emit(OpCodes.Ret);
				fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeof(GetString)));
				break;
				IL_00ff:
				num2++;
				goto IL_0105;
			}
			catch
			{
			}
		}
	}
}
