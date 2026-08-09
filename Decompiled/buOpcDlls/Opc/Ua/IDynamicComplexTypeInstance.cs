using System.Runtime.InteropServices;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public interface IDynamicComplexTypeInstance : IComplexTypeInstance
{
	XmlQualifiedName GetXmlName(IServiceMessageContext context);
}
