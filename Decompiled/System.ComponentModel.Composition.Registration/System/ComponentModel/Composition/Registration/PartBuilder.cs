using System.Collections.Generic;
using System.Composition.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace System.ComponentModel.Composition.Registration;

public class PartBuilder
{
	private static readonly List<Attribute> s_importingConstructorList = new List<Attribute>
	{
		new ImportingConstructorAttribute()
	};

	private static readonly Type s_exportAttributeType = typeof(ExportAttribute);

	private readonly List<ExportBuilder> _typeExportBuilders;

	private bool _setCreationPolicy;

	private CreationPolicy _creationPolicy;

	private List<Tuple<string, object>> _metadataItems;

	private List<Tuple<string, Func<Type, object>>> _metadataItemFuncs;

	private Func<ConstructorInfo[], ConstructorInfo> _constructorFilter;

	private Action<ParameterInfo, ImportBuilder> _configureConstructorImports;

	private readonly List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportBuilder>, Type>> _propertyExports;

	private readonly List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportBuilder>, Type>> _propertyImports;

	private readonly List<Tuple<Predicate<Type>, Action<Type, ExportBuilder>>> _interfaceExports;

	internal Predicate<Type> SelectType { get; private set; }

	internal PartBuilder(Predicate<Type> selectType)
	{
		SelectType = selectType;
		_setCreationPolicy = false;
		_creationPolicy = CreationPolicy.Any;
		_typeExportBuilders = new List<ExportBuilder>();
		_propertyExports = new List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportBuilder>, Type>>();
		_propertyImports = new List<Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportBuilder>, Type>>();
		_interfaceExports = new List<Tuple<Predicate<Type>, Action<Type, ExportBuilder>>>();
	}

	public PartBuilder Export()
	{
		return Export(null);
	}

	public PartBuilder Export(Action<ExportBuilder> exportConfiguration)
	{
		ExportBuilder exportBuilder = new ExportBuilder();
		exportConfiguration?.Invoke(exportBuilder);
		_typeExportBuilders.Add(exportBuilder);
		return this;
	}

	public PartBuilder Export<T>()
	{
		return Export<T>(null);
	}

	public PartBuilder Export<T>(Action<ExportBuilder> exportConfiguration)
	{
		ExportBuilder exportBuilder = new ExportBuilder().AsContractType<T>();
		exportConfiguration?.Invoke(exportBuilder);
		_typeExportBuilders.Add(exportBuilder);
		return this;
	}

	public PartBuilder SelectConstructor(Func<ConstructorInfo[], ConstructorInfo> constructorFilter)
	{
		return SelectConstructor(constructorFilter, null);
	}

	public PartBuilder SelectConstructor(Func<ConstructorInfo[], ConstructorInfo> constructorFilter, Action<ParameterInfo, ImportBuilder> importConfiguration)
	{
		_constructorFilter = constructorFilter;
		_configureConstructorImports = importConfiguration;
		return this;
	}

	public PartBuilder ExportInterfaces(Predicate<Type> interfaceFilter)
	{
		return ExportInterfaces(interfaceFilter, null);
	}

	public PartBuilder ExportInterfaces()
	{
		return ExportInterfaces((Type t) => true, null);
	}

	public PartBuilder ExportInterfaces(Predicate<Type> interfaceFilter, Action<Type, ExportBuilder> exportConfiguration)
	{
		if (interfaceFilter == null)
		{
			throw new ArgumentNullException("interfaceFilter");
		}
		_interfaceExports.Add(Tuple.Create(interfaceFilter, exportConfiguration));
		return this;
	}

	public PartBuilder ExportProperties(Predicate<PropertyInfo> propertyFilter)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		return ExportProperties(propertyFilter, null);
	}

	public PartBuilder ExportProperties(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportBuilder> exportConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		_propertyExports.Add(Tuple.Create<Predicate<PropertyInfo>, Action<PropertyInfo, ExportBuilder>, Type>(propertyFilter, exportConfiguration, null));
		return this;
	}

	public PartBuilder ExportProperties<T>(Predicate<PropertyInfo> propertyFilter)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		return ExportProperties<T>(propertyFilter, null);
	}

	public PartBuilder ExportProperties<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ExportBuilder> exportConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		_propertyExports.Add(Tuple.Create(propertyFilter, exportConfiguration, typeof(T)));
		return this;
	}

	public PartBuilder ImportProperties(Predicate<PropertyInfo> propertyFilter)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		return ImportProperties(propertyFilter, null);
	}

	public PartBuilder ImportProperties(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportBuilder> importConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		_propertyImports.Add(Tuple.Create<Predicate<PropertyInfo>, Action<PropertyInfo, ImportBuilder>, Type>(propertyFilter, importConfiguration, null));
		return this;
	}

	public PartBuilder ImportProperties<T>(Predicate<PropertyInfo> propertyFilter)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		return ImportProperties<T>(propertyFilter, null);
	}

	public PartBuilder ImportProperties<T>(Predicate<PropertyInfo> propertyFilter, Action<PropertyInfo, ImportBuilder> importConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		_propertyImports.Add(Tuple.Create(propertyFilter, importConfiguration, typeof(T)));
		return this;
	}

	public PartBuilder SetCreationPolicy(CreationPolicy creationPolicy)
	{
		_setCreationPolicy = true;
		_creationPolicy = creationPolicy;
		return this;
	}

	public PartBuilder AddMetadata(string name, object value)
	{
		if (_metadataItems == null)
		{
			_metadataItems = new List<Tuple<string, object>>();
		}
		_metadataItems.Add(Tuple.Create(name, value));
		return this;
	}

	public PartBuilder AddMetadata(string name, Func<Type, object> itemFunc)
	{
		if (_metadataItemFuncs == null)
		{
			_metadataItemFuncs = new List<Tuple<string, Func<Type, object>>>();
		}
		_metadataItemFuncs.Add(Tuple.Create(name, itemFunc));
		return this;
	}

	private static bool MemberHasExportMetadata(MemberInfo member)
	{
		object[] customAttributes = member.GetCustomAttributes(typeof(Attribute), inherit: false);
		for (int i = 0; i < customAttributes.Length; i++)
		{
			Attribute attribute = (Attribute)customAttributes[i];
			if (attribute is ExportMetadataAttribute)
			{
				return true;
			}
			Type type = attribute.GetType();
			if (type != s_exportAttributeType && type.IsDefined(typeof(MetadataAttributeAttribute), inherit: true))
			{
				return true;
			}
		}
		return false;
	}

	internal IEnumerable<Attribute> BuildTypeAttributes(Type type)
	{
		List<Attribute> attributes = new List<Attribute>();
		if (_typeExportBuilders != null)
		{
			if (type.GetCustomAttributes(typeof(ExportAttribute), inherit: false).FirstOrDefault() != null || MemberHasExportMetadata(type))
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_TypeExportConventionOverridden(type);
			}
			else
			{
				foreach (ExportBuilder typeExportBuilder in _typeExportBuilders)
				{
					typeExportBuilder.BuildAttributes(type, ref attributes);
				}
			}
		}
		if (_setCreationPolicy)
		{
			if (type.GetCustomAttributes(typeof(PartCreationPolicyAttribute), inherit: false).FirstOrDefault() != null)
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_PartCreationConventionOverridden(type);
			}
			else
			{
				attributes.Add(new PartCreationPolicyAttribute(_creationPolicy));
			}
		}
		if (_metadataItems != null)
		{
			if (type.GetCustomAttributes(typeof(PartMetadataAttribute), inherit: false).FirstOrDefault() != null)
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_PartMetadataConventionOverridden(type);
			}
			else
			{
				foreach (Tuple<string, object> metadataItem in _metadataItems)
				{
					attributes.Add(new PartMetadataAttribute(metadataItem.Item1, metadataItem.Item2));
				}
			}
		}
		if (_metadataItemFuncs != null)
		{
			if (type.GetCustomAttributes(typeof(PartMetadataAttribute), inherit: false).FirstOrDefault() != null)
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_PartMetadataConventionOverridden(type);
			}
			else
			{
				foreach (Tuple<string, Func<Type, object>> metadataItemFunc in _metadataItemFuncs)
				{
					string item = metadataItemFunc.Item1;
					object value = ((metadataItemFunc.Item2 != null) ? metadataItemFunc.Item2(type) : null);
					attributes.Add(new PartMetadataAttribute(item, value));
				}
			}
		}
		if (_interfaceExports.Count != 0 && _typeExportBuilders != null)
		{
			if (type.GetCustomAttributes(typeof(ExportAttribute), inherit: false).FirstOrDefault() != null || MemberHasExportMetadata(type))
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_TypeExportConventionOverridden(type);
			}
			else
			{
				Type[] interfaces = type.GetInterfaces();
				foreach (Type type2 in interfaces)
				{
					Type underlyingSystemType = type2.UnderlyingSystemType;
					if (underlyingSystemType == typeof(IDisposable) || underlyingSystemType == typeof(IPartImportsSatisfiedNotification))
					{
						continue;
					}
					foreach (Tuple<Predicate<Type>, Action<Type, ExportBuilder>> interfaceExport in _interfaceExports)
					{
						if (interfaceExport.Item1 != null && interfaceExport.Item1(underlyingSystemType))
						{
							ExportBuilder exportBuilder = new ExportBuilder();
							exportBuilder.AsContractType(type2);
							interfaceExport.Item2?.Invoke(type2, exportBuilder);
							exportBuilder.BuildAttributes(type2, ref attributes);
						}
					}
				}
			}
		}
		return attributes;
	}

	internal bool BuildConstructorAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		ConstructorInfo[] constructors = type.GetConstructors();
		ConstructorInfo[] array = constructors;
		foreach (ConstructorInfo constructorInfo in array)
		{
			object[] customAttributes = constructorInfo.GetCustomAttributes(typeof(ImportingConstructorAttribute), inherit: false);
			if (customAttributes.Length != 0)
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_ConstructorConventionOverridden(type);
				return true;
			}
		}
		if (_constructorFilter != null)
		{
			ConstructorInfo constructorInfo2 = _constructorFilter(constructors);
			if (constructorInfo2 != null)
			{
				ConfigureConstructorAttributes(constructorInfo2, ref configuredMembers, _configureConstructorImports);
			}
			return true;
		}
		if (_configureConstructorImports != null)
		{
			bool result = false;
			{
				foreach (ConstructorInfo item in FindLongestConstructors(constructors))
				{
					ConfigureConstructorAttributes(item, ref configuredMembers, _configureConstructorImports);
					result = true;
				}
				return result;
			}
		}
		return false;
	}

	internal static void BuildDefaultConstructorAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		ConstructorInfo[] constructors = type.GetConstructors();
		foreach (ConstructorInfo item in FindLongestConstructors(constructors))
		{
			ConfigureConstructorAttributes(item, ref configuredMembers, null);
		}
	}

	private static void ConfigureConstructorAttributes(ConstructorInfo constructorInfo, ref List<Tuple<object, List<Attribute>>> configuredMembers, Action<ParameterInfo, ImportBuilder> configureConstructorImports)
	{
		if (configuredMembers == null)
		{
			configuredMembers = new List<Tuple<object, List<Attribute>>>();
		}
		configuredMembers.Add(Tuple.Create((object)constructorInfo, s_importingConstructorList));
		ParameterInfo[] parameters = constructorInfo.GetParameters();
		ParameterInfo[] array = parameters;
		foreach (ParameterInfo parameterInfo in array)
		{
			if (parameterInfo.GetCustomAttributes(typeof(ImportAttribute), inherit: false).FirstOrDefault() != null || parameterInfo.GetCustomAttributes(typeof(ImportManyAttribute), inherit: false).FirstOrDefault() != null)
			{
				System.Composition.Diagnostics.CompositionTrace.Registration_ParameterImportConventionOverridden(parameterInfo, constructorInfo);
				continue;
			}
			ImportBuilder importBuilder = new ImportBuilder();
			configureConstructorImports?.Invoke(parameterInfo, importBuilder);
			List<Attribute> attributes = null;
			importBuilder.BuildAttributes(parameterInfo.ParameterType, ref attributes);
			configuredMembers.Add(Tuple.Create((object)parameterInfo, attributes));
		}
	}

	internal void BuildPropertyAttributes(Type type, ref List<Tuple<object, List<Attribute>>> configuredMembers)
	{
		if (_propertyImports.Count == 0 && _propertyExports.Count == 0)
		{
			return;
		}
		PropertyInfo[] properties = type.GetProperties();
		foreach (PropertyInfo propertyInfo in properties)
		{
			List<Attribute> attributes = null;
			PropertyInfo property = propertyInfo.DeclaringType.UnderlyingSystemType.GetProperty(propertyInfo.Name, propertyInfo.PropertyType);
			int num = 0;
			bool flag = false;
			bool flag2 = false;
			foreach (Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ImportBuilder>, Type> propertyImport in _propertyImports)
			{
				if (propertyImport.Item1 != null && propertyImport.Item1(property))
				{
					ImportBuilder importBuilder = new ImportBuilder();
					if (propertyImport.Item3 != null)
					{
						importBuilder.AsContractType(propertyImport.Item3);
					}
					propertyImport.Item2?.Invoke(property, importBuilder);
					if (!flag)
					{
						flag2 = propertyInfo.GetCustomAttributes(typeof(ImportAttribute), inherit: false).FirstOrDefault() != null || propertyInfo.GetCustomAttributes(typeof(ImportManyAttribute), inherit: false).FirstOrDefault() != null;
						flag = true;
					}
					if (flag2)
					{
						System.Composition.Diagnostics.CompositionTrace.Registration_MemberImportConventionOverridden(type, propertyInfo);
						break;
					}
					importBuilder.BuildAttributes(property.PropertyType, ref attributes);
					num++;
				}
				if (num > 1)
				{
					System.Composition.Diagnostics.CompositionTrace.Registration_MemberImportConventionMatchedTwice(type, propertyInfo);
				}
			}
			flag = false;
			flag2 = false;
			foreach (Tuple<Predicate<PropertyInfo>, Action<PropertyInfo, ExportBuilder>, Type> propertyExport in _propertyExports)
			{
				if (propertyExport.Item1 != null && propertyExport.Item1(property))
				{
					ExportBuilder exportBuilder = new ExportBuilder();
					if (propertyExport.Item3 != null)
					{
						exportBuilder.AsContractType(propertyExport.Item3);
					}
					propertyExport.Item2?.Invoke(property, exportBuilder);
					if (!flag)
					{
						flag2 = propertyInfo.GetCustomAttributes(typeof(ExportAttribute), inherit: false).FirstOrDefault() != null || MemberHasExportMetadata(propertyInfo);
						flag = true;
					}
					if (flag2)
					{
						System.Composition.Diagnostics.CompositionTrace.Registration_MemberExportConventionOverridden(type, propertyInfo);
						break;
					}
					exportBuilder.BuildAttributes(property.PropertyType, ref attributes);
				}
			}
			if (attributes != null)
			{
				if (configuredMembers == null)
				{
					configuredMembers = new List<Tuple<object, List<Attribute>>>();
				}
				configuredMembers.Add(Tuple.Create((object)property, attributes));
			}
		}
	}

	private static IEnumerable<ConstructorInfo> FindLongestConstructors(ConstructorInfo[] constructors)
	{
		ConstructorInfo constructorInfo = null;
		int argumentsCount = 0;
		int num = 0;
		foreach (ConstructorInfo constructorInfo2 in constructors)
		{
			int num2 = constructorInfo2.GetParameters().Length;
			if (num2 != 0)
			{
				if (num2 > argumentsCount)
				{
					constructorInfo = constructorInfo2;
					argumentsCount = num2;
					num = 1;
				}
				else if (num2 == argumentsCount)
				{
					num++;
				}
			}
		}
		if (num > 1)
		{
			foreach (ConstructorInfo constructorInfo3 in constructors)
			{
				int num3 = constructorInfo3.GetParameters().Length;
				if (num3 == argumentsCount)
				{
					yield return constructorInfo3;
				}
			}
		}
		else if (num == 1)
		{
			yield return constructorInfo;
		}
	}
}
public class PartBuilder<T> : PartBuilder
{
	private sealed class PropertyExpressionAdapter
	{
		private readonly PropertyInfo _propertyInfo;

		private readonly Action<ImportBuilder> _configureImport;

		private readonly Action<ExportBuilder> _configureExport;

		public PropertyExpressionAdapter(Expression<Func<T, object>> propertyFilter, Action<ImportBuilder> configureImport = null, Action<ExportBuilder> configureExport = null)
		{
			_propertyInfo = SelectProperties(propertyFilter);
			_configureImport = configureImport;
			_configureExport = configureExport;
		}

		public bool VerifyPropertyInfo(PropertyInfo pi)
		{
			return pi == _propertyInfo;
		}

		public void ConfigureImport(PropertyInfo _, ImportBuilder importBuilder)
		{
			_configureImport?.Invoke(importBuilder);
		}

		public void ConfigureExport(PropertyInfo _, ExportBuilder exportBuilder)
		{
			_configureExport?.Invoke(exportBuilder);
		}

		private static PropertyInfo SelectProperties(Expression<Func<T, object>> propertyFilter)
		{
			if (propertyFilter == null)
			{
				throw new ArgumentNullException("propertyFilter");
			}
			Expression body = Reduce(propertyFilter).Body;
			if (body.NodeType == ExpressionType.MemberAccess)
			{
				MemberInfo member = ((MemberExpression)body).Member;
				if (member.MemberType == MemberTypes.Property)
				{
					return (PropertyInfo)member;
				}
			}
			throw new ArgumentException(System.SR.Format(System.SR.Argument_ExpressionMustBePropertyMember, "propertyFilter"), "propertyFilter");
		}

		private static Expression<Func<T, object>> Reduce(Expression<Func<T, object>> expr)
		{
			while (expr.CanReduce)
			{
				expr = (Expression<Func<T, object>>)expr.Reduce();
			}
			return expr;
		}
	}

	private sealed class ConstructorExpressionAdapter
	{
		private ConstructorInfo _constructorInfo;

		private Dictionary<ParameterInfo, Action<ImportBuilder>> _importBuilders;

		public ConstructorExpressionAdapter(Expression<Func<ParameterImportBuilder, T>> selectConstructor)
		{
			ParseSelectConstructor(selectConstructor);
		}

		public ConstructorInfo SelectConstructor(ConstructorInfo[] _)
		{
			return _constructorInfo;
		}

		public void ConfigureConstructorImports(ParameterInfo parameterInfo, ImportBuilder importBuilder)
		{
			if (_importBuilders != null && _importBuilders.TryGetValue(parameterInfo, out var value))
			{
				value(importBuilder);
			}
		}

		private void ParseSelectConstructor(Expression<Func<ParameterImportBuilder, T>> constructorFilter)
		{
			if (constructorFilter == null)
			{
				throw new ArgumentNullException("constructorFilter");
			}
			Expression body = Reduce(constructorFilter).Body;
			if (body.NodeType != ExpressionType.New)
			{
				throw new ArgumentException(System.SR.Format(System.SR.Argument_ExpressionMustBePropertyMember, "constructorFilter"), "constructorFilter");
			}
			NewExpression newExpression = (NewExpression)body;
			_constructorInfo = newExpression.Constructor;
			int num = 0;
			ParameterInfo[] parameters = _constructorInfo.GetParameters();
			foreach (Expression argument in newExpression.Arguments)
			{
				if (argument.NodeType != ExpressionType.Call)
				{
					continue;
				}
				MethodCallExpression methodCallExpression = (MethodCallExpression)argument;
				if (methodCallExpression.Arguments.Count != 1)
				{
					continue;
				}
				Expression expression = methodCallExpression.Arguments[0];
				if (expression.NodeType == ExpressionType.Lambda)
				{
					LambdaExpression lambdaExpression = (LambdaExpression)expression;
					Delegate obj = lambdaExpression.Compile();
					if (_importBuilders == null)
					{
						_importBuilders = new Dictionary<ParameterInfo, Action<ImportBuilder>>();
					}
					_importBuilders.Add(parameters[num], (Action<ImportBuilder>)obj);
					num++;
				}
			}
		}

		private static Expression<Func<ParameterImportBuilder, T>> Reduce(Expression<Func<ParameterImportBuilder, T>> expr)
		{
			while (expr.CanReduce)
			{
				expr.Reduce();
			}
			return expr;
		}
	}

	internal PartBuilder(Predicate<Type> selectType)
		: base(selectType)
	{
	}

	public PartBuilder<T> SelectConstructor(Expression<Func<ParameterImportBuilder, T>> constructorFilter)
	{
		if (constructorFilter == null)
		{
			throw new ArgumentNullException("constructorFilter");
		}
		ConstructorExpressionAdapter constructorExpressionAdapter = new ConstructorExpressionAdapter(constructorFilter);
		SelectConstructor(constructorExpressionAdapter.SelectConstructor, constructorExpressionAdapter.ConfigureConstructorImports);
		return this;
	}

	public PartBuilder<T> ExportProperty(Expression<Func<T, object>> propertyFilter)
	{
		return ExportProperty(propertyFilter, null);
	}

	public PartBuilder<T> ExportProperty(Expression<Func<T, object>> propertyFilter, Action<ExportBuilder> exportConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertyFilter, null, exportConfiguration);
		ExportProperties(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureExport);
		return this;
	}

	public PartBuilder<T> ExportProperty<TContract>(Expression<Func<T, object>> propertyFilter)
	{
		return ExportProperty<TContract>(propertyFilter, null);
	}

	public PartBuilder<T> ExportProperty<TContract>(Expression<Func<T, object>> propertyFilter, Action<ExportBuilder> exportConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertyFilter, null, exportConfiguration);
		ExportProperties<TContract>(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureExport);
		return this;
	}

	public PartBuilder<T> ImportProperty(Expression<Func<T, object>> propertyFilter)
	{
		return ImportProperty(propertyFilter, null);
	}

	public PartBuilder<T> ImportProperty(Expression<Func<T, object>> propertyFilter, Action<ImportBuilder> importConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertyFilter, importConfiguration);
		ImportProperties(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureImport);
		return this;
	}

	public PartBuilder<T> ImportProperty<TContract>(Expression<Func<T, object>> propertyFilter)
	{
		return ImportProperty<TContract>(propertyFilter, null);
	}

	public PartBuilder<T> ImportProperty<TContract>(Expression<Func<T, object>> propertyFilter, Action<ImportBuilder> importConfiguration)
	{
		if (propertyFilter == null)
		{
			throw new ArgumentNullException("propertyFilter");
		}
		PropertyExpressionAdapter propertyExpressionAdapter = new PropertyExpressionAdapter(propertyFilter, importConfiguration);
		ImportProperties<TContract>(propertyExpressionAdapter.VerifyPropertyInfo, propertyExpressionAdapter.ConfigureImport);
		return this;
	}
}
