using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Newtonsoft.Json.Utilities;

internal static class ILGeneratorExtensions
{
	public static void PushInstance(this ILGenerator generator, Type type)
	{
		generator.Emit(OpCodes.Ldarg_0);
		if (type.IsValueType())
		{
			generator.Emit(OpCodes.Unbox, type);
		}
		else
		{
			generator.Emit(OpCodes.Castclass, type);
		}
	}

	public static void PushArrayInstance(this ILGenerator generator, int argsIndex, int arrayIndex)
	{
		generator.Emit(OpCodes.Ldarg, argsIndex);
		generator.Emit(OpCodes.Ldc_I4, arrayIndex);
		generator.Emit(OpCodes.Ldelem_Ref);
	}

	public static void BoxIfNeeded(this ILGenerator generator, Type type)
	{
		if (type.IsValueType())
		{
			generator.Emit(OpCodes.Box, type);
		}
		else
		{
			generator.Emit(OpCodes.Castclass, type);
		}
	}

	public static void UnboxIfNeeded(this ILGenerator generator, Type type)
	{
		if (!type.IsValueType())
		{
			generator.Emit(OpCodes.Castclass, type);
			return;
		}
		Label label = generator.DefineLabel();
		Label label2 = generator.DefineLabel();
		LocalBuilder local = generator.DeclareLocal(type);
		generator.Emit(OpCodes.Dup);
		generator.Emit(OpCodes.Brtrue_S, label);
		generator.Emit(OpCodes.Pop);
		generator.Emit(OpCodes.Ldloca, local);
		generator.Emit(OpCodes.Initobj, type);
		generator.Emit(OpCodes.Ldloc, local);
		generator.Emit(OpCodes.Br_S, label2);
		generator.MarkLabel(label);
		generator.Emit(OpCodes.Unbox_Any, type);
		generator.MarkLabel(label2);
	}

	public static void CallMethod(this ILGenerator generator, MethodInfo methodInfo)
	{
		if (methodInfo.IsFinal || !methodInfo.IsVirtual)
		{
			generator.Emit(OpCodes.Call, methodInfo);
		}
		else
		{
			generator.Emit(OpCodes.Callvirt, methodInfo);
		}
	}

	public static void Return(this ILGenerator generator)
	{
		generator.Emit(OpCodes.Ret);
	}
}
