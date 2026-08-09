using System.Collections.Generic;
using System.Globalization;

namespace System.Reflection.Context.Virtual;

internal abstract class VirtualPropertyBase : PropertyInfo
{
	protected abstract class FuncPropertyAccessorBase : VirtualMethodBase
	{
		public CustomReflectionContext ReflectionContext => DeclaringProperty.ReflectionContext;

		public sealed override MethodAttributes Attributes => base.Attributes | MethodAttributes.SpecialName;

		public sealed override Type DeclaringType => DeclaringProperty.DeclaringType;

		public VirtualPropertyBase DeclaringProperty { get; }

		protected FuncPropertyAccessorBase(VirtualPropertyBase declaringProperty)
		{
			DeclaringProperty = declaringProperty;
		}
	}

	protected abstract class PropertyGetterBase : FuncPropertyAccessorBase
	{
		public sealed override string Name => "get_" + base.DeclaringProperty.Name;

		public sealed override Type ReturnType => base.DeclaringProperty.PropertyType;

		protected PropertyGetterBase(VirtualPropertyBase property)
			: base(property)
		{
		}

		protected override Type[] GetParameterTypes()
		{
			return CollectionServices.Empty<Type>();
		}
	}

	protected abstract class PropertySetterBase : FuncPropertyAccessorBase
	{
		private Type[] _parameterTypes;

		public sealed override string Name => "set_" + base.DeclaringProperty.Name;

		public sealed override Type ReturnType => base.DeclaringProperty.ReflectionContext.MapType(typeof(void).GetTypeInfo());

		protected PropertySetterBase(VirtualPropertyBase property)
			: base(property)
		{
		}

		protected override Type[] GetParameterTypes()
		{
			Type[] array = _parameterTypes;
			if (array == null)
			{
				Type[] obj = new Type[1] { base.DeclaringProperty.PropertyType };
				Type[] array2 = obj;
				_parameterTypes = obj;
				array = array2;
			}
			return array;
		}
	}

	private readonly string _name;

	private readonly Type _propertyType;

	private Type _declaringType;

	private ParameterInfo[] _indexedParameters;

	public CustomReflectionContext ReflectionContext { get; }

	public sealed override PropertyAttributes Attributes => PropertyAttributes.None;

	public sealed override Type DeclaringType => _declaringType;

	public sealed override string Name => _name;

	public sealed override Type PropertyType => _propertyType;

	public sealed override bool CanRead => GetGetMethod(nonPublic: true) != null;

	public sealed override bool CanWrite => GetSetMethod(nonPublic: true) != null;

	public sealed override int MetadataToken
	{
		get
		{
			throw new InvalidOperationException();
		}
	}

	public sealed override Module Module => DeclaringType.Module;

	public sealed override Type ReflectedType => DeclaringType;

	protected VirtualPropertyBase(Type propertyType, string name, CustomReflectionContext context)
	{
		if (name == null)
		{
			throw new ArgumentNullException("name");
		}
		if (name.Length == 0)
		{
			throw new ArgumentException("", "name");
		}
		if (propertyType == null)
		{
			throw new ArgumentNullException("propertyType");
		}
		_propertyType = propertyType;
		_name = name;
		ReflectionContext = context;
	}

	public sealed override MethodInfo[] GetAccessors(bool nonPublic)
	{
		MethodInfo getMethod = GetGetMethod(nonPublic);
		MethodInfo setMethod = GetSetMethod(nonPublic);
		if (!(getMethod == null) && !(setMethod == null))
		{
			return new MethodInfo[2] { getMethod, setMethod };
		}
		return new MethodInfo[1] { getMethod ?? setMethod };
	}

	public sealed override ParameterInfo[] GetIndexParameters()
	{
		return (ParameterInfo[])GetIndexParametersNoCopy().Clone();
	}

	public sealed override object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		MethodInfo getMethod = GetGetMethod(nonPublic: true);
		if (getMethod == null)
		{
			throw new ArgumentException(System.SR.Argument_GetMethNotFnd);
		}
		return getMethod.Invoke(obj, invokeAttr, binder, index, culture);
	}

	public sealed override void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture)
	{
		MethodInfo setMethod = GetSetMethod(nonPublic: true);
		if (setMethod == null)
		{
			throw new ArgumentException(System.SR.Argument_GetMethNotFnd);
		}
		object[] array;
		if (index == null)
		{
			array = new object[1] { value };
		}
		else
		{
			array = new object[index.Length + 1];
			Array.Copy(index, array, index.Length);
			array[index.Length] = value;
		}
		setMethod.Invoke(obj, invokeAttr, binder, array, culture);
	}

	public sealed override object GetConstantValue()
	{
		throw new InvalidOperationException(System.SR.InvalidOperation_EnumLitValueNotFound);
	}

	public sealed override object GetRawConstantValue()
	{
		throw new InvalidOperationException(System.SR.InvalidOperation_EnumLitValueNotFound);
	}

	public sealed override Type[] GetOptionalCustomModifiers()
	{
		return CollectionServices.Empty<Type>();
	}

	public sealed override Type[] GetRequiredCustomModifiers()
	{
		return CollectionServices.Empty<Type>();
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return CollectionServices.Empty<Attribute>();
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return CollectionServices.Empty<Attribute>();
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return CollectionServices.Empty<CustomAttributeData>();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		if (obj is VirtualPropertyBase virtualPropertyBase && _name == virtualPropertyBase._name && _declaringType.Equals(virtualPropertyBase._declaringType) && _propertyType == virtualPropertyBase._propertyType)
		{
			return CollectionServices.CompareArrays(GetIndexParametersNoCopy(), virtualPropertyBase.GetIndexParametersNoCopy());
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _name.GetHashCode() ^ _declaringType.GetHashCode() ^ _propertyType.GetHashCode() ^ CollectionServices.GetArrayHashCode(GetIndexParametersNoCopy());
	}

	public override string ToString()
	{
		return base.ToString();
	}

	internal void SetDeclaringType(Type declaringType)
	{
		_declaringType = declaringType;
	}

	private ParameterInfo[] GetIndexParametersNoCopy()
	{
		if (_indexedParameters == null)
		{
			MethodInfo getMethod = GetGetMethod(nonPublic: true);
			if (getMethod != null)
			{
				_indexedParameters = VirtualParameter.CloneParameters(this, getMethod.GetParameters(), skipLastParameter: false);
			}
			else
			{
				getMethod = GetSetMethod(nonPublic: true);
				_indexedParameters = VirtualParameter.CloneParameters(this, getMethod.GetParameters(), skipLastParameter: true);
			}
		}
		return _indexedParameters;
	}
}
