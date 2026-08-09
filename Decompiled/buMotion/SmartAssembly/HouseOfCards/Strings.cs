using System;
using System.Reflection;
using System.Reflection.Emit;
using _0001;
using _0004;
using SmartAssembly.Delegates;

namespace SmartAssembly.HouseOfCards;

public static class Strings
{
	[global::_0001._0001]
	public unsafe static void CreateGetStringDelegate(Type ownerType)
	{
		void* ptr;
		FieldInfo[] fields;
		do
		{
			ptr = stackalloc byte[8];
			fields = ownerType.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
			*(int*)ptr = 0;
		}
		while (6 == 0);
		DynamicMethod dynamicMethod = default(DynamicMethod);
		ILGenerator iLGenerator = default(ILGenerator);
		while (*(int*)ptr < fields.Length)
		{
			FieldInfo fieldInfo = fields[*(int*)ptr];
			try
			{
				if ((object)fieldInfo.FieldType == typeof(GetString))
				{
					dynamicMethod = new DynamicMethod(string.Empty, typeof(string), new Type[1] { typeof(int) }, ownerType.Module, skipVisibility: true);
					iLGenerator = dynamicMethod.GetILGenerator();
					iLGenerator.Emit(OpCodes.Ldarg_0);
					MethodInfo[] methods = typeof(_0004._0002._0001).GetMethods(BindingFlags.Static | BindingFlags.Public);
					((int*)ptr)[1] = 0;
					while (true)
					{
						int num = ((int*)ptr)[1];
						nint num2 = (nint)methods.LongLength;
						int num3;
						do
						{
							num3 = (int)num2;
							num2 = num3;
						}
						while (false);
						if (num >= num3)
						{
							break;
						}
						MethodInfo methodInfo = methods[((int*)ptr)[1]];
						if ((object)methodInfo.ReturnType == typeof(string) || 1 == 0)
						{
							iLGenerator.Emit(OpCodes.Ldc_I4, fieldInfo.MetadataToken & 0xFFFFFF);
							iLGenerator.Emit(OpCodes.Sub);
							iLGenerator.Emit(OpCodes.Call, methodInfo);
							break;
						}
						((int*)ptr)[1]++;
					}
					goto IL_0125;
				}
				if (1 == 0)
				{
					goto IL_0125;
				}
				goto end_IL_003d;
				IL_0125:
				iLGenerator.Emit(OpCodes.Ret);
				fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeof(GetString)));
				break;
				end_IL_003d:;
			}
			catch
			{
			}
			(*(int*)ptr)++;
		}
	}
}
