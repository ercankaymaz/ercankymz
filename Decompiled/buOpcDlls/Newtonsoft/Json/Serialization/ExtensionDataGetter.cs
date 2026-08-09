using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Serialization;

[return: Newtonsoft_002EJson_002ENullable(new byte[] { 2, 0, 1, 1 })]
public delegate IEnumerable<KeyValuePair<object, object>> ExtensionDataGetter(object o);
