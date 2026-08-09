using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Security;

namespace System.Reflection.Context.Delegation;

internal class DelegatingAssembly : Assembly
{
	[RequiresAssemblyFiles("Calling 'System.Reflection.Assembly.Location' always returns an empty string for assemblies embedded in a single-file app. If the path to the app directory is needed, consider calling 'System.AppContext.BaseDirectory'", Url = "https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/il3000")]
	public override string Location => UnderlyingAssembly.Location;

	public override Module ManifestModule => UnderlyingAssembly.ManifestModule;

	public override bool ReflectionOnly => UnderlyingAssembly.ReflectionOnly;

	public Assembly UnderlyingAssembly { get; }

	public override SecurityRuleSet SecurityRuleSet => UnderlyingAssembly.SecurityRuleSet;

	[Obsolete]
	[RequiresAssemblyFiles]
	public override string CodeBase => UnderlyingAssembly.CodeBase;

	public override MethodInfo EntryPoint => UnderlyingAssembly.EntryPoint;

	[Obsolete]
	[RequiresAssemblyFiles]
	public override string EscapedCodeBase => UnderlyingAssembly.EscapedCodeBase;

	public override string FullName => UnderlyingAssembly.FullName;

	[Obsolete]
	public override bool GlobalAssemblyCache => UnderlyingAssembly.GlobalAssemblyCache;

	public override long HostContext => UnderlyingAssembly.HostContext;

	public override string ImageRuntimeVersion => UnderlyingAssembly.ImageRuntimeVersion;

	public override bool IsDynamic => UnderlyingAssembly.IsDynamic;

	public DelegatingAssembly(Assembly assembly)
	{
		UnderlyingAssembly = assembly;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		return UnderlyingAssembly.GetCustomAttributes(attributeType, inherit);
	}

	public override object[] GetCustomAttributes(bool inherit)
	{
		return UnderlyingAssembly.GetCustomAttributes(inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return UnderlyingAssembly.GetCustomAttributesData();
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		return UnderlyingAssembly.IsDefined(attributeType, inherit);
	}

	public override string ToString()
	{
		return UnderlyingAssembly.ToString();
	}

	public override object CreateInstance(string typeName, bool ignoreCase, BindingFlags bindingAttr, Binder binder, object[] args, CultureInfo culture, object[] activationAttributes)
	{
		return UnderlyingAssembly.CreateInstance(typeName, ignoreCase, bindingAttr, binder, args, culture, activationAttributes);
	}

	public override Type[] GetExportedTypes()
	{
		return UnderlyingAssembly.GetExportedTypes();
	}

	[RequiresAssemblyFiles("Calling 'System.Reflection.Assembly.GetFile(string)' will throw for assemblies embedded in a single-file app", Url = "https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/il3001")]
	public override FileStream GetFile(string name)
	{
		return UnderlyingAssembly.GetFile(name);
	}

	[RequiresAssemblyFiles("Calling 'System.Reflection.Assembly.GetFiles()' will throw for assemblies embedded in a single-file app", Url = "https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/il3001")]
	public override FileStream[] GetFiles()
	{
		return UnderlyingAssembly.GetFiles();
	}

	[RequiresAssemblyFiles("Calling 'System.Reflection.Assembly.GetFiles(bool)' will throw for assemblies embedded in a single-file app", Url = "https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/il3001")]
	public override FileStream[] GetFiles(bool getResourceModules)
	{
		return UnderlyingAssembly.GetFiles(getResourceModules);
	}

	public override Module[] GetLoadedModules(bool getResourceModules)
	{
		return UnderlyingAssembly.GetLoadedModules(getResourceModules);
	}

	public override ManifestResourceInfo GetManifestResourceInfo(string resourceName)
	{
		return UnderlyingAssembly.GetManifestResourceInfo(resourceName);
	}

	public override string[] GetManifestResourceNames()
	{
		return UnderlyingAssembly.GetManifestResourceNames();
	}

	public override Stream GetManifestResourceStream(string name)
	{
		return UnderlyingAssembly.GetManifestResourceStream(name);
	}

	public override Stream GetManifestResourceStream(Type type, string name)
	{
		return UnderlyingAssembly.GetManifestResourceStream(type, name);
	}

	public override Module GetModule(string name)
	{
		return UnderlyingAssembly.GetModule(name);
	}

	public override Module[] GetModules(bool getResourceModules)
	{
		return UnderlyingAssembly.GetModules(getResourceModules);
	}

	public override AssemblyName GetName()
	{
		return UnderlyingAssembly.GetName();
	}

	public override AssemblyName GetName(bool copiedName)
	{
		return UnderlyingAssembly.GetName(copiedName);
	}

	public override AssemblyName[] GetReferencedAssemblies()
	{
		return UnderlyingAssembly.GetReferencedAssemblies();
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture)
	{
		return UnderlyingAssembly.GetSatelliteAssembly(culture);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
	{
		return UnderlyingAssembly.GetSatelliteAssembly(culture, version);
	}

	public override Type GetType(string name, bool throwOnError, bool ignoreCase)
	{
		return UnderlyingAssembly.GetType(name, throwOnError, ignoreCase);
	}

	public override Type[] GetTypes()
	{
		return UnderlyingAssembly.GetTypes();
	}

	public override Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore)
	{
		return UnderlyingAssembly.LoadModule(moduleName, rawModule, rawSymbolStore);
	}
}
