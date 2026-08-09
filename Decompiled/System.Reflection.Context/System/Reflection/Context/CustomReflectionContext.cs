using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Context.Custom;
using System.Reflection.Context.Projection;
using System.Reflection.Context.Virtual;

namespace System.Reflection.Context;

public abstract class CustomReflectionContext : ReflectionContext
{
	private sealed class ReflectionContextProjector : Projector
	{
		public CustomReflectionContext ReflectionContext { get; }

		public ReflectionContextProjector(CustomReflectionContext context)
		{
			ReflectionContext = context;
		}

		public TypeInfo ProjectTypeIfNeeded(TypeInfo value)
		{
			if (NeedsProjection(value))
			{
				value = ReflectionContext.SourceContext.MapType(value);
				return ProjectType(value);
			}
			return value;
		}

		public Assembly ProjectAssemblyIfNeeded(Assembly value)
		{
			if (NeedsProjection(value))
			{
				value = ReflectionContext.SourceContext.MapAssembly(value);
				return ProjectAssembly(value);
			}
			return value;
		}

		[return: NotNullIfNotNull("value")]
		public override TypeInfo ProjectType(Type value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomType(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override Assembly ProjectAssembly(Assembly value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomAssembly(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override Module ProjectModule(Module value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomModule(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override FieldInfo ProjectField(FieldInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomFieldInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override EventInfo ProjectEvent(EventInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomEventInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override ConstructorInfo ProjectConstructor(ConstructorInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomConstructorInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override MethodInfo ProjectMethod(MethodInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomMethodInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override MethodBase ProjectMethodBase(MethodBase value)
		{
			if (value == null)
			{
				return null;
			}
			MethodInfo methodInfo = value as MethodInfo;
			if (methodInfo != null)
			{
				return ProjectMethod(methodInfo);
			}
			ConstructorInfo constructorInfo = value as ConstructorInfo;
			if (constructorInfo != null)
			{
				return ProjectConstructor(constructorInfo);
			}
			throw new InvalidOperationException(System.SR.Format(System.SR.InvalidOperation_InvalidMethodType, value.GetType()));
		}

		[return: NotNullIfNotNull("value")]
		public override PropertyInfo ProjectProperty(PropertyInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomPropertyInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override ParameterInfo ProjectParameter(ParameterInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new CustomParameterInfo(value, ReflectionContext);
		}

		[return: NotNullIfNotNull("value")]
		public override MethodBody ProjectMethodBody(MethodBody value)
		{
			if (value == null)
			{
				return null;
			}
			return new ProjectingMethodBody(value, this);
		}

		[return: NotNullIfNotNull("value")]
		public override LocalVariableInfo ProjectLocalVariable(LocalVariableInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new ProjectingLocalVariableInfo(value, this);
		}

		[return: NotNullIfNotNull("value")]
		public override ExceptionHandlingClause ProjectExceptionHandlingClause(ExceptionHandlingClause value)
		{
			if (value == null)
			{
				return null;
			}
			return new ProjectingExceptionHandlingClause(value, this);
		}

		[return: NotNullIfNotNull("value")]
		public override CustomAttributeData ProjectCustomAttributeData(CustomAttributeData value)
		{
			if (value == null)
			{
				return null;
			}
			return new ProjectingCustomAttributeData(value, this);
		}

		[return: NotNullIfNotNull("value")]
		public override ManifestResourceInfo ProjectManifestResource(ManifestResourceInfo value)
		{
			if (value == null)
			{
				return null;
			}
			return new ProjectingManifestResourceInfo(value, this);
		}

		[return: NotNullIfNotNull("value")]
		public override MemberInfo ProjectMember(MemberInfo value)
		{
			if (value == null)
			{
				return null;
			}
			switch (value.MemberType)
			{
			case MemberTypes.TypeInfo:
			case MemberTypes.NestedType:
				return ProjectType((Type)value);
			case MemberTypes.Constructor:
				return ProjectConstructor((ConstructorInfo)value);
			case MemberTypes.Event:
				return ProjectEvent((EventInfo)value);
			case MemberTypes.Field:
				return ProjectField((FieldInfo)value);
			case MemberTypes.Method:
				return ProjectMethod((MethodInfo)value);
			case MemberTypes.Property:
				return ProjectProperty((PropertyInfo)value);
			default:
				throw new InvalidOperationException(System.SR.Format(System.SR.InvalidOperation_InvalidMemberType, value.Name, value.MemberType));
			}
		}

		public override CustomAttributeTypedArgument ProjectTypedArgument(CustomAttributeTypedArgument value)
		{
			Type argumentType = ProjectType(value.ArgumentType);
			return new CustomAttributeTypedArgument(argumentType, value.Value);
		}

		public override CustomAttributeNamedArgument ProjectNamedArgument(CustomAttributeNamedArgument value)
		{
			MemberInfo memberInfo = ProjectMember(value.MemberInfo);
			CustomAttributeTypedArgument typedArgument = ProjectTypedArgument(value.TypedValue);
			return new CustomAttributeNamedArgument(memberInfo, typedArgument);
		}

		public override InterfaceMapping ProjectInterfaceMapping(InterfaceMapping value)
		{
			return new InterfaceMapping
			{
				InterfaceMethods = Project(value.InterfaceMethods, ProjectMethod),
				InterfaceType = ProjectType(value.InterfaceType),
				TargetMethods = Project(value.TargetMethods, ProjectMethod),
				TargetType = ProjectType(value.TargetType)
			};
		}
	}

	private readonly ReflectionContextProjector _projector;

	internal Projector Projector => _projector;

	internal ReflectionContext SourceContext { get; }

	protected CustomReflectionContext()
		: this(new IdentityReflectionContext())
	{
	}

	protected CustomReflectionContext(ReflectionContext source)
	{
		if (source == null)
		{
			throw new ArgumentNullException("source");
		}
		SourceContext = source;
		_projector = new ReflectionContextProjector(this);
	}

	public override Assembly MapAssembly(Assembly assembly)
	{
		if ((object)assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		return _projector.ProjectAssemblyIfNeeded(assembly);
	}

	public override TypeInfo MapType(TypeInfo type)
	{
		if ((object)type == null)
		{
			throw new ArgumentNullException("type");
		}
		return _projector.ProjectTypeIfNeeded(type);
	}

	protected virtual IEnumerable<object> GetCustomAttributes(MemberInfo member, IEnumerable<object> declaredAttributes)
	{
		return declaredAttributes;
	}

	protected virtual IEnumerable<object> GetCustomAttributes(ParameterInfo parameter, IEnumerable<object> declaredAttributes)
	{
		return declaredAttributes;
	}

	protected virtual IEnumerable<PropertyInfo> AddProperties(Type type)
	{
		yield break;
	}

	protected PropertyInfo CreateProperty(Type propertyType, string name, Func<object, object?>? getter, Action<object, object?>? setter)
	{
		return new VirtualPropertyInfo(name, propertyType, getter, setter, null, null, null, this);
	}

	protected PropertyInfo CreateProperty(Type propertyType, string name, Func<object, object?>? getter, Action<object, object?>? setter, IEnumerable<Attribute>? propertyCustomAttributes, IEnumerable<Attribute>? getterCustomAttributes, IEnumerable<Attribute>? setterCustomAttributes)
	{
		return new VirtualPropertyInfo(name, propertyType, getter, setter, propertyCustomAttributes, getterCustomAttributes, setterCustomAttributes, this);
	}

	internal IEnumerable<PropertyInfo> GetNewPropertiesForType(CustomType type)
	{
		if (type.IsInterface || type.IsGenericParameter || type.HasElementType)
		{
			yield break;
		}
		IEnumerable<PropertyInfo> enumerable = AddProperties(type.UnderlyingType);
		foreach (PropertyInfo item in enumerable)
		{
			if (item == null)
			{
				throw new InvalidOperationException(System.SR.InvalidOperation_AddNullProperty);
			}
			VirtualPropertyBase virtualPropertyBase = item as VirtualPropertyBase;
			if (virtualPropertyBase == null || virtualPropertyBase.ReflectionContext != this)
			{
				throw new InvalidOperationException(System.SR.InvalidOperation_AddPropertyDifferentContext);
			}
			if (virtualPropertyBase.DeclaringType == null)
			{
				virtualPropertyBase.SetDeclaringType(type);
			}
			else if (!virtualPropertyBase.DeclaringType.Equals(type))
			{
				throw new InvalidOperationException(System.SR.InvalidOperation_AddPropertyDifferentType);
			}
			yield return item;
		}
	}

	internal IEnumerable<object> GetCustomAttributesOnMember(MemberInfo member, IEnumerable<object> declaredAttributes, Type attributeFilterType)
	{
		IEnumerable<object> customAttributes = GetCustomAttributes(member, declaredAttributes);
		return AttributeUtils.FilterCustomAttributes(customAttributes, attributeFilterType);
	}

	internal IEnumerable<object> GetCustomAttributesOnParameter(ParameterInfo parameter, IEnumerable<object> declaredAttributes, Type attributeFilterType)
	{
		IEnumerable<object> customAttributes = GetCustomAttributes(parameter, declaredAttributes);
		return AttributeUtils.FilterCustomAttributes(customAttributes, attributeFilterType);
	}
}
