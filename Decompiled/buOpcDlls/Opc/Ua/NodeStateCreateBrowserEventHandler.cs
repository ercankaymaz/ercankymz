using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Opc.Ua;

[ComVisible(true)]
public delegate NodeBrowser NodeStateCreateBrowserEventHandler(ISystemContext context, NodeState node, ViewDescription view, NodeId referenceType, bool includeSubtypes, BrowseDirection browseDirection, QualifiedName browseName, IEnumerable<IReference> additionalReferences, bool internalOnly);
