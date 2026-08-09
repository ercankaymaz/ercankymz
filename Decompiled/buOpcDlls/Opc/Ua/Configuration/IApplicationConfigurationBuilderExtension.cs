using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua.Configuration;

[ComVisible(true)]
public interface IApplicationConfigurationBuilderExtension : IApplicationConfigurationBuilderTraceConfiguration, IApplicationConfigurationBuilderCreate
{
	IApplicationConfigurationBuilderExtension AddExtension<T>(XmlQualifiedName elementName, object value);
}
