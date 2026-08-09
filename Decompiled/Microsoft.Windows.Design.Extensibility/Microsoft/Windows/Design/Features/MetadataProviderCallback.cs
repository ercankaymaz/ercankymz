using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Design.Features;

public delegate IEnumerable<object> MetadataProviderCallback(Type type, Type attributeType);
