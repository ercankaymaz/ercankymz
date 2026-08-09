using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua.Security;

[DebuggerStepThrough]
[GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
[CollectionDataContract(Name = "ListOfSecurityProfiles", Namespace = "http://opcfoundation.org/UA/2011/03/SecuredApplication.xsd", ItemName = "SecurityProfile")]
[ComVisible(true)]
public class ListOfSecurityProfiles : List<SecurityProfile>
{
}
