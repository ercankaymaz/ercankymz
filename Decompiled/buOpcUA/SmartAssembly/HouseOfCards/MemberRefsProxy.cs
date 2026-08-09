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
	public static void CreateMemberRefsDelegates(int typeID)
	{
		Type type = default(Type);
		try
		{
			Type typeFromHandle = Type.GetTypeFromHandle(MemberRefsProxy._0001.ResolveTypeHandle(33554433 + typeID));
			if (0 == 0)
			{
				type = typeFromHandle;
			}
		}
		catch
		{
			return;
		}
		if (false)
		{
			goto IL_01d5;
		}
		FieldInfo[] fields = type.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField);
		int num = 0;
		goto IL_024b;
		IL_00a5:
		nint num3;
		int num4;
		nint num2 = num3 + num4;
		if (false)
		{
			goto IL_0067;
		}
		int num5 = (int)num2;
		goto IL_00bb;
		IL_01f5:
		ILGenerator iLGenerator;
		iLGenerator.Emit(OpCodes.Tailcall);
		bool flag;
		MethodInfo methodInfo;
		iLGenerator.Emit(flag ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
		iLGenerator.Emit(OpCodes.Ret);
		Delegate value;
		DynamicMethod dynamicMethod;
		try
		{
			value = dynamicMethod.CreateDelegate(type);
		}
		catch
		{
			goto IL_0247;
		}
		goto IL_0236;
		IL_024b:
		FieldInfo fieldInfo;
		string name;
		if (num < fields.Length)
		{
			fieldInfo = fields[num];
			name = fieldInfo.Name;
			num2 = 0;
			goto IL_0067;
		}
		return;
		IL_01d1:
		int num7;
		int num6 = num7;
		goto IL_01e9;
		IL_0067:
		flag = (byte)num2 != 0;
		num5 = 0;
		int num8 = name.Length - 1;
		goto IL_00c4;
		IL_00c4:
		char c;
		if (num8 >= 0)
		{
			c = name[num8];
			goto IL_0084;
		}
		goto IL_00ca;
		IL_0084:
		if (c == '~')
		{
			flag = true;
			goto IL_00ca;
		}
		num4 = 0;
		goto IL_00b5;
		IL_00ca:
		try
		{
			methodInfo = (MethodInfo)MethodBase.GetMethodFromHandle(MemberRefsProxy._0001.ResolveMethodHandle(num5 + 167772161));
		}
		catch
		{
			goto IL_0247;
		}
		num7 = (methodInfo.IsStatic ? 1 : 0);
		int num9;
		while (num7 == 0)
		{
			ParameterInfo[] parameters = methodInfo.GetParameters();
			num3 = (nint)parameters.LongLength;
			if (false)
			{
				goto IL_00a5;
			}
			num9 = (int)num3 + 1;
			Type[] array = new Type[num9];
			array[0] = typeof(object);
			int i;
			if (4u != 0)
			{
				i = 1;
			}
			for (; i < num9; i++)
			{
				array[i] = parameters[i - 1].ParameterType;
			}
			dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array, type, skipVisibility: true);
			iLGenerator = dynamicMethod.GetILGenerator();
			iLGenerator.Emit(OpCodes.Ldarg_0);
			if (num9 > 1)
			{
				iLGenerator.Emit(OpCodes.Ldarg_1);
			}
			if (num9 > 2)
			{
				iLGenerator.Emit(OpCodes.Ldarg_2);
			}
			if (num9 > 3)
			{
				iLGenerator.Emit(OpCodes.Ldarg_3);
			}
			if (num9 > 4)
			{
				num7 = 4;
				if (num7 == 0)
				{
					continue;
				}
				goto IL_01d1;
			}
			goto IL_01f5;
		}
		try
		{
			value = Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo);
		}
		catch (Exception)
		{
			goto IL_0247;
		}
		goto IL_0236;
		IL_01d5:
		iLGenerator.Emit(OpCodes.Ldarg_S, num6);
		num6++;
		goto IL_01e9;
		IL_00b5:
		int num10;
		if (num4 < 58)
		{
			num10 = _0001[num4];
			goto IL_009c;
		}
		goto IL_00bb;
		IL_0236:
		try
		{
			if (0 == 0)
			{
				fieldInfo.SetValue(null, value);
			}
		}
		catch
		{
		}
		goto IL_0247;
		IL_01e9:
		if (false)
		{
			goto IL_0084;
		}
		if (num6 < num9)
		{
			goto IL_01d5;
		}
		goto IL_01f5;
		IL_00bb:
		num10 = num8 - 1;
		if (false)
		{
			goto IL_009c;
		}
		num8 = num10;
		goto IL_00c4;
		IL_009c:
		if (num10 == c)
		{
			num3 = num5 * 58;
			goto IL_00a5;
		}
		num4++;
		goto IL_00b5;
		IL_0247:
		num++;
		goto IL_024b;
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
