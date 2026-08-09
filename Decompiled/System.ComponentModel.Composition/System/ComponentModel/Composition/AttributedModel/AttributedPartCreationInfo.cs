using System.Collections.Generic;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.ComponentModel.Composition.ReflectionModel;
using System.Composition.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Internal;

namespace System.ComponentModel.Composition.AttributedModel;

internal sealed class AttributedPartCreationInfo : IReflectionPartCreationInfo, ICompositionElement
{
	private readonly Type _type;

	private readonly bool _ignoreConstructorImports;

	private readonly ICompositionElement _origin;

	private PartCreationPolicyAttribute _partCreationPolicy;

	private ConstructorInfo _constructor;

	private List<ExportDefinition> _exports;

	private List<ImportDefinition> _imports;

	private HashSet<string> _contractNamesOnNonInterfaces;

	public bool IsDisposalRequired => typeof(IDisposable).IsAssignableFrom(GetPartType());

	public bool IsIdentityComparison => true;

	string ICompositionElement.DisplayName => GetDisplayName();

	ICompositionElement? ICompositionElement.Origin => _origin;

	private CreationPolicy CreationPolicy
	{
		get
		{
			if (_partCreationPolicy == null)
			{
				_partCreationPolicy = _type.GetFirstAttribute<PartCreationPolicyAttribute>() ?? PartCreationPolicyAttribute.Default;
			}
			return _partCreationPolicy.CreationPolicy;
		}
	}

	public AttributedPartCreationInfo(Type type, PartCreationPolicyAttribute? partCreationPolicy, bool ignoreConstructorImports, ICompositionElement? origin)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		_type = type;
		_ignoreConstructorImports = ignoreConstructorImports;
		_partCreationPolicy = partCreationPolicy;
		_origin = origin;
	}

	public Type GetPartType()
	{
		return _type;
	}

	public Lazy<Type> GetLazyPartType()
	{
		return new Lazy<Type>(GetPartType, LazyThreadSafetyMode.PublicationOnly);
	}

	public ConstructorInfo? GetConstructor()
	{
		if (_constructor == null && !_ignoreConstructorImports)
		{
			_constructor = SelectPartConstructor(_type);
		}
		return _constructor;
	}

	public IDictionary<string, object?> GetMetadata()
	{
		return _type.GetPartMetadataForType(CreationPolicy);
	}

	public IEnumerable<ExportDefinition> GetExports()
	{
		DiscoverExportsAndImports();
		return _exports;
	}

	public IEnumerable<ImportDefinition> GetImports()
	{
		DiscoverExportsAndImports();
		return _imports;
	}

	public bool IsPartDiscoverable()
	{
		if (_type.IsAttributeDefined<PartNotDiscoverableAttribute>())
		{
			CompositionTrace.DefinitionMarkedWithPartNotDiscoverableAttribute(_type);
			return false;
		}
		if (!HasExports())
		{
			CompositionTrace.DefinitionContainsNoExports(_type);
			return false;
		}
		if (!AllExportsHaveMatchingArity())
		{
			return false;
		}
		return true;
	}

	private bool HasExports()
	{
		if (!GetExportMembers(_type).Any())
		{
			return GetInheritedExports(_type).Any();
		}
		return true;
	}

	private bool AllExportsHaveMatchingArity()
	{
		bool result = true;
		if (_type.ContainsGenericParameters)
		{
			int pureGenericArity = _type.GetPureGenericArity();
			foreach (MemberInfo item in GetExportMembers(_type).Concat(GetInheritedExports(_type)))
			{
				if (item.MemberType == MemberTypes.Method && ((MethodInfo)item).ContainsGenericParameters)
				{
					result = false;
					CompositionTrace.DefinitionMismatchedExportArity(_type, item);
				}
				else if (item.GetDefaultTypeFromMember().GetPureGenericArity() != pureGenericArity)
				{
					result = false;
					CompositionTrace.DefinitionMismatchedExportArity(_type, item);
				}
			}
		}
		return result;
	}

	public override string ToString()
	{
		return GetDisplayName();
	}

	private string GetDisplayName()
	{
		return GetPartType().GetDisplayName();
	}

	private static ConstructorInfo SelectPartConstructor(Type type)
	{
		ArgumentNullException.ThrowIfNull(type, "type");
		if (type.IsAbstract)
		{
			return null;
		}
		BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		ConstructorInfo[] constructors = type.GetConstructors(bindingAttr);
		if (constructors.Length == 0)
		{
			return null;
		}
		if (constructors.Length == 1 && constructors[0].GetParameters().Length == 0)
		{
			return constructors[0];
		}
		ConstructorInfo constructorInfo = null;
		ConstructorInfo constructorInfo2 = null;
		ConstructorInfo[] array = constructors;
		foreach (ConstructorInfo constructorInfo3 in array)
		{
			if (constructorInfo3.IsAttributeDefined<ImportingConstructorAttribute>())
			{
				if (constructorInfo != null)
				{
					return null;
				}
				constructorInfo = constructorInfo3;
			}
			else if (constructorInfo2 == null && constructorInfo3.GetParameters().Length == 0)
			{
				constructorInfo2 = constructorInfo3;
			}
		}
		return constructorInfo ?? constructorInfo2;
	}

	private void DiscoverExportsAndImports()
	{
		if (_exports == null || _imports == null)
		{
			_exports = GetExportDefinitions();
			_imports = GetImportDefinitions();
		}
	}

	private List<ExportDefinition> GetExportDefinitions()
	{
		List<ExportDefinition> list = new List<ExportDefinition>();
		_contractNamesOnNonInterfaces = new HashSet<string>();
		foreach (MemberInfo exportMember in GetExportMembers(_type))
		{
			ExportAttribute[] attributes = exportMember.GetAttributes<ExportAttribute>();
			foreach (ExportAttribute exportAttribute in attributes)
			{
				AttributedExportDefinition attributedExportDefinition = CreateExportDefinition(exportMember, exportAttribute);
				if (exportAttribute.GetType() == CompositionServices.InheritedExportAttributeType)
				{
					if (!_contractNamesOnNonInterfaces.Contains(attributedExportDefinition.ContractName))
					{
						list.Add(new ReflectionMemberExportDefinition(exportMember.ToLazyMember(), attributedExportDefinition, this));
						_contractNamesOnNonInterfaces.Add(attributedExportDefinition.ContractName);
					}
				}
				else
				{
					list.Add(new ReflectionMemberExportDefinition(exportMember.ToLazyMember(), attributedExportDefinition, this));
				}
			}
		}
		foreach (Type inheritedExport in GetInheritedExports(_type))
		{
			InheritedExportAttribute[] attributes2 = inheritedExport.GetAttributes<InheritedExportAttribute>();
			foreach (InheritedExportAttribute exportAttribute2 in attributes2)
			{
				AttributedExportDefinition attributedExportDefinition2 = CreateExportDefinition(inheritedExport, exportAttribute2);
				if (!_contractNamesOnNonInterfaces.Contains(attributedExportDefinition2.ContractName))
				{
					list.Add(new ReflectionMemberExportDefinition(inheritedExport.ToLazyMember(), attributedExportDefinition2, this));
					if (!inheritedExport.IsInterface)
					{
						_contractNamesOnNonInterfaces.Add(attributedExportDefinition2.ContractName);
					}
				}
			}
		}
		_contractNamesOnNonInterfaces = null;
		return list;
	}

	private AttributedExportDefinition CreateExportDefinition(MemberInfo member, ExportAttribute exportAttribute)
	{
		member.GetContractInfoFromExport(exportAttribute, out Type typeIdentityType, out string contractName);
		return new AttributedExportDefinition(this, member, exportAttribute, typeIdentityType, contractName);
	}

	private static IEnumerable<MemberInfo> GetExportMembers(Type type)
	{
		BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		if (type.IsAbstract)
		{
			flags &= ~BindingFlags.Instance;
		}
		else if (IsExport(type))
		{
			yield return type;
		}
		FieldInfo[] fields = type.GetFields(flags);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (IsExport(fieldInfo))
			{
				yield return fieldInfo;
			}
		}
		PropertyInfo[] properties = type.GetProperties(flags);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (IsExport(propertyInfo))
			{
				yield return propertyInfo;
			}
		}
		MethodInfo[] methods = type.GetMethods(flags);
		foreach (MethodInfo methodInfo in methods)
		{
			if (IsExport(methodInfo))
			{
				yield return methodInfo;
			}
		}
	}

	private static IEnumerable<Type> GetInheritedExports(Type type)
	{
		if (type.IsAbstract)
		{
			yield break;
		}
		Type currentType = type.BaseType;
		if (currentType == null)
		{
			yield break;
		}
		while (currentType != null && currentType.UnderlyingSystemType != CompositionServices.ObjectType)
		{
			if (IsInheritedExport(currentType))
			{
				yield return currentType;
			}
			currentType = currentType.BaseType;
		}
		Type[] interfaces = type.GetInterfaces();
		foreach (Type type2 in interfaces)
		{
			if (IsInheritedExport(type2))
			{
				yield return type2;
			}
		}
	}

	private static bool IsExport(ICustomAttributeProvider attributeProvider)
	{
		return attributeProvider.IsAttributeDefined<ExportAttribute>(inherit: false);
	}

	private static bool IsInheritedExport(ICustomAttributeProvider attributedProvider)
	{
		return attributedProvider.IsAttributeDefined<InheritedExportAttribute>(inherit: false);
	}

	private List<ImportDefinition> GetImportDefinitions()
	{
		List<ImportDefinition> list = new List<ImportDefinition>();
		foreach (MemberInfo importMember in GetImportMembers(_type))
		{
			ReflectionMemberImportDefinition item = AttributedModelDiscovery.CreateMemberImportDefinition(importMember, this);
			list.Add(item);
		}
		ConstructorInfo constructor = GetConstructor();
		if (constructor != null)
		{
			ParameterInfo[] parameters = constructor.GetParameters();
			foreach (ParameterInfo parameter in parameters)
			{
				ReflectionParameterImportDefinition item2 = AttributedModelDiscovery.CreateParameterImportDefinition(parameter, this);
				list.Add(item2);
			}
		}
		return list;
	}

	private static IEnumerable<MemberInfo> GetImportMembers(Type type)
	{
		if (type.IsAbstract)
		{
			yield break;
		}
		foreach (MemberInfo declaredOnlyImportMember in GetDeclaredOnlyImportMembers(type))
		{
			yield return declaredOnlyImportMember;
		}
		if (!(type.BaseType != null))
		{
			yield break;
		}
		Type baseType = type.BaseType;
		while (baseType != null && baseType.UnderlyingSystemType != CompositionServices.ObjectType)
		{
			foreach (MemberInfo declaredOnlyImportMember2 in GetDeclaredOnlyImportMembers(baseType))
			{
				yield return declaredOnlyImportMember2;
			}
			baseType = baseType.BaseType;
		}
	}

	private static IEnumerable<MemberInfo> GetDeclaredOnlyImportMembers(Type type)
	{
		BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		FieldInfo[] fields = type.GetFields(flags);
		foreach (FieldInfo fieldInfo in fields)
		{
			if (IsImport(fieldInfo))
			{
				yield return fieldInfo;
			}
		}
		PropertyInfo[] properties = type.GetProperties(flags);
		foreach (PropertyInfo propertyInfo in properties)
		{
			if (IsImport(propertyInfo))
			{
				yield return propertyInfo;
			}
		}
	}

	private static bool IsImport(ICustomAttributeProvider attributeProvider)
	{
		return attributeProvider.IsAttributeDefined<IAttributedImport>(inherit: false);
	}
}
