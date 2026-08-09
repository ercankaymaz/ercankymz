using System;
using System.ComponentModel;

namespace Microsoft.Windows.Design.PropertyEditing;

public class DependencyPropertyValueSource : PropertyValueSource
{
	private enum ValueSource
	{
		Binding,
		TemplateBinding,
		Static,
		StaticResource,
		DynamicResource,
		CustomMarkupExtension,
		LocalValue,
		DefaultValue,
		InheritedValue,
		Null,
		Ambient
	}

	private static DependencyPropertyValueSource _binding;

	private static DependencyPropertyValueSource _templateBinding;

	private static DependencyPropertyValueSource _static;

	private static DependencyPropertyValueSource _staticResource;

	private static DependencyPropertyValueSource _dynamicResource;

	private static DependencyPropertyValueSource _customMarkupExtension;

	private static DependencyPropertyValueSource _defaultValue;

	private static DependencyPropertyValueSource _localValue;

	private static DependencyPropertyValueSource _inheritedValue;

	private static DependencyPropertyValueSource _null;

	private static DependencyPropertyValueSource _ambient;

	private readonly ValueSource _source;

	public static DependencyPropertyValueSource Binding
	{
		get
		{
			if (_binding == null)
			{
				_binding = new DependencyPropertyValueSource(ValueSource.Binding);
			}
			return _binding;
		}
	}

	public static DependencyPropertyValueSource TemplateBinding
	{
		get
		{
			if (_templateBinding == null)
			{
				_templateBinding = new DependencyPropertyValueSource(ValueSource.TemplateBinding);
			}
			return _templateBinding;
		}
	}

	public static DependencyPropertyValueSource Static
	{
		get
		{
			if (_static == null)
			{
				_static = new DependencyPropertyValueSource(ValueSource.Static);
			}
			return _static;
		}
	}

	public static DependencyPropertyValueSource StaticResource
	{
		get
		{
			if (_staticResource == null)
			{
				_staticResource = new DependencyPropertyValueSource(ValueSource.StaticResource);
			}
			return _staticResource;
		}
	}

	public static DependencyPropertyValueSource DynamicResource
	{
		get
		{
			if (_dynamicResource == null)
			{
				_dynamicResource = new DependencyPropertyValueSource(ValueSource.DynamicResource);
			}
			return _dynamicResource;
		}
	}

	public static DependencyPropertyValueSource CustomMarkupExtension
	{
		get
		{
			if (_customMarkupExtension == null)
			{
				_customMarkupExtension = new DependencyPropertyValueSource(ValueSource.CustomMarkupExtension);
			}
			return _customMarkupExtension;
		}
	}

	public static DependencyPropertyValueSource DefaultValue
	{
		get
		{
			if (_defaultValue == null)
			{
				_defaultValue = new DependencyPropertyValueSource(ValueSource.DefaultValue);
			}
			return _defaultValue;
		}
	}

	public static DependencyPropertyValueSource LocalValue
	{
		get
		{
			if (_localValue == null)
			{
				_localValue = new DependencyPropertyValueSource(ValueSource.LocalValue);
			}
			return _localValue;
		}
	}

	public static DependencyPropertyValueSource InheritedValue
	{
		get
		{
			if (_inheritedValue == null)
			{
				_inheritedValue = new DependencyPropertyValueSource(ValueSource.InheritedValue);
			}
			return _inheritedValue;
		}
	}

	public static DependencyPropertyValueSource Null
	{
		get
		{
			if (_null == null)
			{
				_null = new DependencyPropertyValueSource(ValueSource.Null);
			}
			return _null;
		}
	}

	public static DependencyPropertyValueSource Ambient
	{
		get
		{
			if (_ambient == null)
			{
				_ambient = new DependencyPropertyValueSource(ValueSource.Ambient);
			}
			return _ambient;
		}
	}

	public bool IsBinding => _source == ValueSource.Binding;

	public bool IsTemplateBinding => _source == ValueSource.TemplateBinding;

	public bool IsStatic => _source == ValueSource.Static;

	public bool IsStaticResource => _source == ValueSource.StaticResource;

	public bool IsDynamicResource => _source == ValueSource.DynamicResource;

	public bool IsCustomMarkupExtension => _source == ValueSource.CustomMarkupExtension;

	public bool IsDefaultValue => _source == ValueSource.DefaultValue;

	public bool IsLocalValue => _source == ValueSource.LocalValue;

	public bool IsInheritedValue => _source == ValueSource.InheritedValue;

	public bool IsResource
	{
		get
		{
			if (_source != ValueSource.DynamicResource)
			{
				return _source == ValueSource.StaticResource;
			}
			return true;
		}
	}

	public bool IsMarkupExtension
	{
		get
		{
			if (_source != ValueSource.Binding && _source != ValueSource.TemplateBinding && _source != ValueSource.Static && _source != ValueSource.StaticResource && _source != ValueSource.DynamicResource && _source != ValueSource.CustomMarkupExtension)
			{
				return _source == ValueSource.Null;
			}
			return true;
		}
	}

	public bool IsNull => _source == ValueSource.Null;

	public bool IsAmbient => _source == ValueSource.Ambient;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DependencyPropertyValueSource.Binding instead")]
	public static DependencyPropertyValueSource DataBound => Binding;

	[Obsolete("Use DependencyPropertyValueSource.Static instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static DependencyPropertyValueSource SystemResource => Static;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DependencyPropertyValueSource.StaticResource instead")]
	public static DependencyPropertyValueSource LocalStaticResource => StaticResource;

	[Obsolete("Use DependencyPropertyValueSource.DynamicResource instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static DependencyPropertyValueSource LocalDynamicResource => DynamicResource;

	[Obsolete("Use DependencyPropertyValueSource.LocalValue instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static DependencyPropertyValueSource Local => LocalValue;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DependencyPropertyValueSource.InheritedValue instead")]
	public static DependencyPropertyValueSource Inherited => InheritedValue;

	[Obsolete("Use DependencyPropertyValueSource.IsMarkupExtension instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsExpression => IsMarkupExtension;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DependencyPropertyValueSource.IsBinding instead")]
	public bool IsDataBound => IsBinding;

	[Obsolete("Use DependencyPropertyValueSource.IsStatic instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsSystemResource => IsStatic;

	[Obsolete("Use DependencyPropertyValueSource.IsResource instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsLocalResource => IsResource;

	[Obsolete("Use DependencyPropertyValueSource.IsLocalValue instead")]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool IsLocal => IsLocalValue;

	[EditorBrowsable(EditorBrowsableState.Never)]
	[Obsolete("Use DependencyPropertyValueSource.IsInheritedValue instead")]
	public bool IsInherited => IsInheritedValue;

	private DependencyPropertyValueSource(ValueSource source)
	{
		_source = source;
	}
}
