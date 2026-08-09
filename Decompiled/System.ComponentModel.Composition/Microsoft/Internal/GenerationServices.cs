using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;

namespace Microsoft.Internal;

internal static class GenerationServices
{
	private static readonly MethodInfo s_typeGetTypeFromHandleMethod = typeof(Type).GetMethod("GetTypeFromHandle");

	private static readonly Type s_typeType = typeof(Type);

	private static readonly Type s_stringType = typeof(string);

	private static readonly Type s_charType = typeof(char);

	private static readonly Type s_booleanType = typeof(bool);

	private static readonly Type s_byteType = typeof(byte);

	private static readonly Type s_sByteType = typeof(sbyte);

	private static readonly Type s_int16Type = typeof(short);

	private static readonly Type s_uInt16Type = typeof(ushort);

	private static readonly Type s_int32Type = typeof(int);

	private static readonly Type s_uInt32Type = typeof(uint);

	private static readonly Type s_int64Type = typeof(long);

	private static readonly Type s_uInt64Type = typeof(ulong);

	private static readonly Type s_doubleType = typeof(double);

	private static readonly Type s_singleType = typeof(float);

	private static readonly Type s_iEnumerableTypeofT = typeof(IEnumerable<>);

	private static readonly Type s_iEnumerableType = typeof(IEnumerable);

	private static readonly MethodInfo ExceptionGetData = typeof(Exception).GetProperty("Data").GetGetMethod();

	private static readonly MethodInfo DictionaryAdd = typeof(IDictionary).GetMethod("Add");

	private static readonly ConstructorInfo ObjectCtor = typeof(object).GetConstructor(Type.EmptyTypes);

	public static ILGenerator CreateGeneratorForPublicConstructor(this TypeBuilder typeBuilder, Type[] ctrArgumentTypes)
	{
		ConstructorBuilder constructorBuilder = typeBuilder.DefineConstructor(MethodAttributes.Public, CallingConventions.Standard, ctrArgumentTypes);
		ILGenerator iLGenerator = constructorBuilder.GetILGenerator();
		iLGenerator.Emit(OpCodes.Ldarg_0);
		iLGenerator.Emit(OpCodes.Call, ObjectCtor);
		return iLGenerator;
	}

	public static void LoadValue(this ILGenerator ilGenerator, object? value)
	{
		if (value == null)
		{
			ilGenerator.LoadNull();
			return;
		}
		Type type = value.GetType();
		object obj = value;
		if (type.IsEnum)
		{
			obj = Convert.ChangeType(value, Enum.GetUnderlyingType(type), null);
			type = obj.GetType();
		}
		if (type == s_stringType)
		{
			ilGenerator.LoadString((string)obj);
			return;
		}
		if (s_typeType.IsAssignableFrom(type))
		{
			ilGenerator.LoadTypeOf((Type)obj);
			return;
		}
		if (s_iEnumerableType.IsAssignableFrom(type))
		{
			ilGenerator.LoadEnumerable((IEnumerable)obj);
			return;
		}
		if (type == s_charType || type == s_booleanType || type == s_byteType || type == s_sByteType || type == s_int16Type || type == s_uInt16Type || type == s_int32Type)
		{
			ilGenerator.LoadInt((int)Convert.ChangeType(obj, typeof(int), CultureInfo.InvariantCulture));
			return;
		}
		if (type == s_uInt32Type)
		{
			ilGenerator.LoadInt((int)(uint)obj);
			return;
		}
		if (type == s_int64Type)
		{
			ilGenerator.LoadLong((long)obj);
			return;
		}
		if (type == s_uInt64Type)
		{
			ilGenerator.LoadLong((long)(ulong)obj);
			return;
		}
		if (type == s_singleType)
		{
			ilGenerator.LoadFloat((float)obj);
			return;
		}
		if (type == s_doubleType)
		{
			ilGenerator.LoadDouble((double)obj);
			return;
		}
		throw new InvalidOperationException(System.SR.Format(System.SR.InvalidMetadataValue, value.GetType().FullName));
	}

	public static void AddItemToLocalDictionary(this ILGenerator ilGenerator, LocalBuilder dictionary, object key, object value)
	{
		ArgumentNullException.ThrowIfNull(dictionary, "dictionary");
		ArgumentNullException.ThrowIfNull(key, "key");
		ArgumentNullException.ThrowIfNull(value, "value");
		ilGenerator.Emit(OpCodes.Ldloc, dictionary);
		ilGenerator.LoadValue(key);
		ilGenerator.LoadValue(value);
		ilGenerator.Emit(OpCodes.Callvirt, DictionaryAdd);
	}

	public static void AddLocalToLocalDictionary(this ILGenerator ilGenerator, LocalBuilder dictionary, object key, LocalBuilder value)
	{
		ArgumentNullException.ThrowIfNull(dictionary, "dictionary");
		ArgumentNullException.ThrowIfNull(key, "key");
		ArgumentNullException.ThrowIfNull(value, "value");
		ilGenerator.Emit(OpCodes.Ldloc, dictionary);
		ilGenerator.LoadValue(key);
		ilGenerator.Emit(OpCodes.Ldloc, value);
		ilGenerator.Emit(OpCodes.Callvirt, DictionaryAdd);
	}

	public static void GetExceptionDataAndStoreInLocal(this ILGenerator ilGenerator, LocalBuilder exception, LocalBuilder dataStore)
	{
		ArgumentNullException.ThrowIfNull(exception, "exception");
		ArgumentNullException.ThrowIfNull(dataStore, "dataStore");
		ilGenerator.Emit(OpCodes.Ldloc, exception);
		ilGenerator.Emit(OpCodes.Callvirt, ExceptionGetData);
		ilGenerator.Emit(OpCodes.Stloc, dataStore);
	}

	private static void LoadEnumerable(this ILGenerator ilGenerator, IEnumerable enumerable)
	{
		ArgumentNullException.ThrowIfNull(enumerable, "enumerable");
		Type targetClosedInterfaceType;
		Type type = ((!ReflectionServices.TryGetGenericInterfaceType(enumerable.GetType(), s_iEnumerableTypeofT, out targetClosedInterfaceType)) ? typeof(object) : targetClosedInterfaceType.GetGenericArguments()[0]);
		Type localType = type.MakeArrayType();
		LocalBuilder local = ilGenerator.DeclareLocal(localType);
		ilGenerator.LoadInt(enumerable.Cast<object>().Count());
		ilGenerator.Emit(OpCodes.Newarr, type);
		ilGenerator.Emit(OpCodes.Stloc, local);
		int num = 0;
		foreach (object item in enumerable)
		{
			ilGenerator.Emit(OpCodes.Ldloc, local);
			ilGenerator.LoadInt(num);
			ilGenerator.LoadValue(item);
			if (IsBoxingRequiredForValue(item) && !type.IsValueType)
			{
				ilGenerator.Emit(OpCodes.Box, item.GetType());
			}
			ilGenerator.Emit(OpCodes.Stelem, type);
			num++;
		}
		ilGenerator.Emit(OpCodes.Ldloc, local);
	}

	private static bool IsBoxingRequiredForValue(object value)
	{
		return value?.GetType().IsValueType ?? false;
	}

	private static void LoadNull(this ILGenerator ilGenerator)
	{
		ilGenerator.Emit(OpCodes.Ldnull);
	}

	private static void LoadString(this ILGenerator ilGenerator, string s)
	{
		if (s == null)
		{
			ilGenerator.LoadNull();
		}
		else
		{
			ilGenerator.Emit(OpCodes.Ldstr, s);
		}
	}

	private static void LoadInt(this ILGenerator ilGenerator, int value)
	{
		ilGenerator.Emit(OpCodes.Ldc_I4, value);
	}

	private static void LoadLong(this ILGenerator ilGenerator, long value)
	{
		ilGenerator.Emit(OpCodes.Ldc_I8, value);
	}

	private static void LoadFloat(this ILGenerator ilGenerator, float value)
	{
		ilGenerator.Emit(OpCodes.Ldc_R4, value);
	}

	private static void LoadDouble(this ILGenerator ilGenerator, double value)
	{
		ilGenerator.Emit(OpCodes.Ldc_R8, value);
	}

	private static void LoadTypeOf(this ILGenerator ilGenerator, Type type)
	{
		ilGenerator.Emit(OpCodes.Ldtoken, type);
		ilGenerator.EmitCall(OpCodes.Call, s_typeGetTypeFromHandleMethod, null);
	}
}
