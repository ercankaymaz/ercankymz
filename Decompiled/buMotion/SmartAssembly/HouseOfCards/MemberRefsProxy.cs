using System;
using System.Reflection;
using System.Reflection.Emit;
using _0001;

namespace SmartAssembly.HouseOfCards;

public static class MemberRefsProxy
{
	private static ModuleHandle _0001;

	private static char[] _0001;

	[global::_0001._0001]
	public unsafe static void CreateMemberRefsDelegates(int typeID)
	{
		void* ptr = stackalloc byte[29];
		Type typeFromHandle;
		try
		{
			typeFromHandle = Type.GetTypeFromHandle(MemberRefsProxy._0001.ResolveTypeHandle(33554433 + typeID));
		}
		catch
		{
			return;
		}
		if (8 == 0)
		{
			goto IL_01d4;
		}
		FieldInfo[] fields = typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
		*(int*)ptr = 0;
		goto IL_02b0;
		IL_012f:
		Delegate value;
		FieldInfo fieldInfo = default(FieldInfo);
		MethodInfo methodInfo = default(MethodInfo);
		try
		{
			value = Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo);
		}
		catch (Exception)
		{
			goto IL_02a7;
		}
		goto IL_0299;
		IL_01d4:
		ILGenerator iLGenerator = default(ILGenerator);
		iLGenerator.Emit(OpCodes.Ldarg_0);
		if (((int*)ptr)[4] > 1)
		{
			iLGenerator.Emit(OpCodes.Ldarg_1);
		}
		if (((int*)ptr)[4] > 2)
		{
			iLGenerator.Emit(OpCodes.Ldarg_2);
		}
		if (((int*)ptr)[4] > 3)
		{
			iLGenerator.Emit(OpCodes.Ldarg_3);
		}
		if (((int*)ptr)[4] > 4)
		{
			((int*)ptr)[6] = 4;
			while (((int*)ptr)[6] < ((int*)ptr)[4])
			{
				iLGenerator.Emit(OpCodes.Ldarg_S, ((int*)ptr)[6]);
				((int*)ptr)[6]++;
			}
		}
		iLGenerator.Emit(OpCodes.Tailcall);
		iLGenerator.Emit(((bool*)ptr)[28] ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
		iLGenerator.Emit(OpCodes.Ret);
		DynamicMethod dynamicMethod = default(DynamicMethod);
		try
		{
			value = dynamicMethod.CreateDelegate(typeFromHandle);
		}
		catch
		{
			goto IL_02a7;
		}
		goto IL_0299;
		IL_02b0:
		while (true)
		{
			if (*(int*)ptr >= fields.Length)
			{
				return;
			}
			fieldInfo = fields[*(int*)ptr];
			string name = fieldInfo.Name;
			((sbyte*)ptr)[28] = 0;
			((int*)ptr)[1] = 0;
			((int*)ptr)[2] = name.Length - 1;
			while (0 == 0)
			{
				if (((int*)ptr)[2] < 0)
				{
					goto end_IL_02b0;
				}
				char c = name[((int*)ptr)[2]];
				if (c == '~')
				{
					((sbyte*)ptr)[28] = 1;
					goto end_IL_02b0;
				}
				((int*)ptr)[3] = 0;
				if (false)
				{
					goto end_IL_02b0;
				}
				while (((int*)ptr)[3] < 58)
				{
					if (_0001[((int*)ptr)[3]] == c)
					{
						((int*)ptr)[1] = ((int*)ptr)[1] * 58 + ((int*)ptr)[3];
						break;
					}
					((int*)ptr)[3]++;
				}
				((int*)ptr)[2]--;
			}
			continue;
			end_IL_02b0:
			break;
		}
		Type[] array;
		while (true)
		{
			IL_00fe:
			try
			{
				methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(MemberRefsProxy._0001.ResolveMethodHandle(((int*)ptr)[1] + 167772161));
			}
			catch
			{
				break;
			}
			if (methodInfo.IsStatic)
			{
				goto IL_012f;
			}
			ParameterInfo[] parameters = methodInfo.GetParameters();
			((int*)ptr)[4] = parameters.Length + 1;
			array = new Type[((int*)ptr)[4]];
			array[0] = typeof(object);
			((int*)ptr)[5] = 1;
			while (((int*)ptr)[5] < ((int*)ptr)[4])
			{
				array[((int*)ptr)[5]] = parameters[((int*)ptr)[5] - 1].ParameterType;
				if (false)
				{
					goto IL_00fe;
				}
				((int*)ptr)[5]++;
			}
			goto IL_01b4;
		}
		goto IL_02a7;
		IL_02a7:
		if (0 == 0)
		{
			(*(int*)ptr)++;
			goto IL_02b0;
		}
		return;
		IL_0299:
		try
		{
			fieldInfo.SetValue(null, value);
		}
		catch
		{
		}
		goto IL_02a7;
		IL_01b4:
		dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, typeFromHandle, skipVisibility: true);
		iLGenerator = dynamicMethod.GetILGenerator();
		goto IL_01d4;
	}

	static MemberRefsProxy()
	{
		while (true)
		{
			if (uint.MaxValue != 0)
			{
				_0001 = new char[58]
				{
					'\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\a', '\b', '\u000e', '\u000f',
					'\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019',
					'\u001a', '\u001b', '\u001c', '\u001d', '\u001e', '\u001f', '\u007f', '\u0080', '\u0081', '\u0082',
					'\u0083', '\u0084', '\u0086', '\u0087', '\u0088', '\u0089', '\u008a', '\u008b', '\u008c', '\u008d',
					'\u008e', '\u008f', '\u0090', '\u0091', '\u0092', '\u0093', '\u0094', '\u0095', '\u0096', '\u0097',
					'\u0098', '\u0099', '\u009a', '\u009b', '\u009c', '\u009d', '\u009e', '\u009f'
				};
				if ((object)typeof(MulticastDelegate) == null)
				{
					goto IL_002d;
				}
			}
			goto IL_0045;
			IL_002d:
			if (0 == 0)
			{
				if (false)
				{
					continue;
				}
				if (5u != 0)
				{
					break;
				}
			}
			goto IL_0045;
			IL_0045:
			MemberRefsProxy._0001 = Assembly.GetExecutingAssembly().GetModules()[0].ModuleHandle;
			goto IL_002d;
		}
	}
}
