using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection.Context.Delegation;

namespace System.Reflection.Context.Projection;

internal class ProjectingAssembly : DelegatingAssembly, IProjectable
{
	public Projector Projector { get; }

	public override Module ManifestModule => Projector.ProjectModule(base.ManifestModule);

	public override MethodInfo EntryPoint => Projector.ProjectMethod(base.EntryPoint);

	public ProjectingAssembly(Assembly assembly, Projector projector)
		: base(assembly)
	{
		Projector = projector;
	}

	public override object[] GetCustomAttributes(Type attributeType, bool inherit)
	{
		attributeType = Projector.Unproject(attributeType);
		return base.GetCustomAttributes(attributeType, inherit);
	}

	public override IList<CustomAttributeData> GetCustomAttributesData()
	{
		return Projector.Project(base.GetCustomAttributesData(), Projector.ProjectCustomAttributeData);
	}

	public override bool IsDefined(Type attributeType, bool inherit)
	{
		attributeType = Projector.Unproject(attributeType);
		return base.IsDefined(attributeType, inherit);
	}

	public override Type[] GetExportedTypes()
	{
		return Projector.Project(base.GetExportedTypes(), Projector.ProjectType);
	}

	public override Module[] GetLoadedModules(bool getResourceModules)
	{
		return Projector.Project(base.GetLoadedModules(getResourceModules), Projector.ProjectModule);
	}

	public override ManifestResourceInfo GetManifestResourceInfo(string resourceName)
	{
		return Projector.ProjectManifestResource(base.GetManifestResourceInfo(resourceName));
	}

	public override Module GetModule(string name)
	{
		return Projector.ProjectModule(base.GetModule(name));
	}

	public override Module[] GetModules(bool getResourceModules)
	{
		return Projector.Project(base.GetModules(getResourceModules), Projector.ProjectModule);
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture)
	{
		return Projector.ProjectAssembly(base.GetSatelliteAssembly(culture));
	}

	public override Assembly GetSatelliteAssembly(CultureInfo culture, Version version)
	{
		return Projector.ProjectAssembly(base.GetSatelliteAssembly(culture, version));
	}

	public override Type GetType(string name, bool throwOnError, bool ignoreCase)
	{
		return Projector.ProjectType(base.GetType(name, throwOnError, ignoreCase));
	}

	public override Type[] GetTypes()
	{
		return Projector.Project(base.GetTypes(), Projector.ProjectType);
	}

	public override Module LoadModule(string moduleName, byte[] rawModule, byte[] rawSymbolStore)
	{
		return Projector.ProjectModule(base.LoadModule(moduleName, rawModule, rawSymbolStore));
	}

	public override bool Equals([NotNullWhen(true)] object o)
	{
		if (o is ProjectingAssembly projectingAssembly && Projector == projectingAssembly.Projector)
		{
			return base.UnderlyingAssembly == projectingAssembly.UnderlyingAssembly;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Projector.GetHashCode() ^ base.UnderlyingAssembly.GetHashCode();
	}
}
