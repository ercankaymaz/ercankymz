using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Reflection.Context.Projection;

internal abstract class Projector
{
	[return: NotNullIfNotNull("values")]
	public IList<T> Project<T>(IList<T> values, Func<T, T> project)
	{
		if (values == null || values.Count == 0)
		{
			return values;
		}
		T[] array = ProjectAll(values, project);
		return Array.AsReadOnly(array);
	}

	[return: NotNullIfNotNull("values")]
	public T[] Project<T>(T[] values, Func<T, T> project)
	{
		if (values == null || values.Length == 0)
		{
			return values;
		}
		return ProjectAll(values, project);
	}

	public T Project<T>(T value, Func<T, T> project)
	{
		if (NeedsProjection(value))
		{
			return project(value);
		}
		return value;
	}

	[return: NotNullIfNotNull("value")]
	public abstract TypeInfo ProjectType(Type value);

	[return: NotNullIfNotNull("value")]
	public abstract Assembly ProjectAssembly(Assembly value);

	[return: NotNullIfNotNull("value")]
	public abstract Module ProjectModule(Module value);

	[return: NotNullIfNotNull("value")]
	public abstract FieldInfo ProjectField(FieldInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract EventInfo ProjectEvent(EventInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract ConstructorInfo ProjectConstructor(ConstructorInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract MethodInfo ProjectMethod(MethodInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract MethodBase ProjectMethodBase(MethodBase value);

	[return: NotNullIfNotNull("value")]
	public abstract PropertyInfo ProjectProperty(PropertyInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract ParameterInfo ProjectParameter(ParameterInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract MethodBody ProjectMethodBody(MethodBody value);

	[return: NotNullIfNotNull("value")]
	public abstract LocalVariableInfo ProjectLocalVariable(LocalVariableInfo value);

	[return: NotNullIfNotNull("value")]
	public abstract ExceptionHandlingClause ProjectExceptionHandlingClause(ExceptionHandlingClause value);

	[return: NotNullIfNotNull("value")]
	public abstract CustomAttributeData ProjectCustomAttributeData(CustomAttributeData value);

	[return: NotNullIfNotNull("value")]
	public abstract ManifestResourceInfo ProjectManifestResource(ManifestResourceInfo value);

	public abstract CustomAttributeTypedArgument ProjectTypedArgument(CustomAttributeTypedArgument value);

	public abstract CustomAttributeNamedArgument ProjectNamedArgument(CustomAttributeNamedArgument value);

	public abstract InterfaceMapping ProjectInterfaceMapping(InterfaceMapping value);

	[return: NotNullIfNotNull("value")]
	public abstract MemberInfo ProjectMember(MemberInfo value);

	[return: NotNullIfNotNull("values")]
	public static Type[] Unproject(Type[] values)
	{
		if (values == null)
		{
			return null;
		}
		Type[] array = new Type[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = Unproject(values[i]);
		}
		return array;
	}

	[return: NotNullIfNotNull("value")]
	public static Type Unproject(Type value)
	{
		if (value is ProjectingType projectingType)
		{
			return projectingType.UnderlyingType;
		}
		return value;
	}

	public bool NeedsProjection([NotNullWhen(true)] object value)
	{
		if (value == null)
		{
			return false;
		}
		if (value is IProjectable projectable && projectable == this)
		{
			return false;
		}
		return true;
	}

	private T[] ProjectAll<T>(IList<T> values, Func<T, T> project)
	{
		T[] array = new T[values.Count];
		for (int i = 0; i < array.Length; i++)
		{
			T arg = values[i];
			array[i] = project(arg);
		}
		return array;
	}
}
