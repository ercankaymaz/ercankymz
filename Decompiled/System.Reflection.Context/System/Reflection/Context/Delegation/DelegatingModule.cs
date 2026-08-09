using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System.Reflection.Context.Delegation;

internal class DelegatingModule : Module
{
	internal const string UnknownStringMessageInRAF = "Returns <Unknown> for modules with no file path";

	public Module UnderlyingModule { get; }

	public override Assembly Assembly => UnderlyingModule.Assembly;

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string FullyQualifiedName => UnderlyingModule.FullyQualifiedName;

	public override int MDStreamVersion => UnderlyingModule.MDStreamVersion;

	public override int MetadataToken => UnderlyingModule.MetadataToken;

	public override Guid ModuleVersionId => UnderlyingModule.ModuleVersionId;

	[RequiresAssemblyFiles("Returns <Unknown> for modules with no file path")]
	public override string Name => UnderlyingModule.Name;

	public override string ScopeName => UnderlyingModule.ScopeName;

	public DelegatingModule(Module module)
	{
		UnderlyingModule = module;
	}

	public override Type[] FindTypes(TypeFilter filter, object filterCriteria)
	{
		return UnderlyingModule.FindTypes(filter, filterCriteria);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingModule.GetCustomAttributes(inherit);
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingModule.GetCustomAttributes(attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingModule.GetCustomAttributesData();
	}

	public override FieldInfo GetField(string name, BindingFlags bindingAttr)
	{
		return UnderlyingModule.GetField(name, bindingAttr);
	}

	public override FieldInfo[] GetFields(BindingFlags bindingFlags)
	{
		return UnderlyingModule.GetFields(bindingFlags);
	}

	protected override MethodInfo GetMethodImpl(string name, BindingFlags bindingAttr, Binder binder, CallingConventions callConvention, Type[] types, ParameterModifier[] modifiers)
	{
		if (types == null)
		{
			return UnderlyingModule.GetMethod(name);
		}
		return UnderlyingModule.GetMethod(name, bindingAttr, binder, callConvention, types, modifiers);
	}

	public override MethodInfo[] GetMethods(BindingFlags bindingFlags)
	{
		return UnderlyingModule.GetMethods(bindingFlags);
	}

	public override void GetPEKind(out PortableExecutableKinds peKind, out ImageFileMachine machine)
	{
		UnderlyingModule.GetPEKind(out peKind, out machine);
	}

	public override Type GetType(string className, bool throwOnError, bool ignoreCase)
	{
		return UnderlyingModule.GetType(className, throwOnError, ignoreCase);
	}

	public override Type[] GetTypes()
	{
		return UnderlyingModule.GetTypes();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingModule.IsDefined(attributeType, inherit);
	}

	public override bool IsResource()
	{
		return UnderlyingModule.IsResource();
	}

	public override FieldInfo ResolveField(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return UnderlyingModule.ResolveField(metadataToken, genericTypeArguments, genericMethodArguments);
	}

	public override MemberInfo ResolveMember(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return UnderlyingModule.ResolveMember(metadataToken, genericTypeArguments, genericMethodArguments);
	}

	public override MethodBase ResolveMethod(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return UnderlyingModule.ResolveMethod(metadataToken, genericTypeArguments, genericMethodArguments);
	}

	public override byte[] ResolveSignature(int metadataToken)
	{
		return UnderlyingModule.ResolveSignature(metadataToken);
	}

	public override string ResolveString(int metadataToken)
	{
		return UnderlyingModule.ResolveString(metadataToken);
	}

	public override Type ResolveType(int metadataToken, Type[] genericTypeArguments, Type[] genericMethodArguments)
	{
		return UnderlyingModule.ResolveType(metadataToken, genericTypeArguments, genericMethodArguments);
	}

	public override string ToString()
	{
		return UnderlyingModule.ToString();
	}
}
