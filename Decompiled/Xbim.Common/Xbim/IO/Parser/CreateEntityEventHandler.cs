using Xbim.Common;

namespace Xbim.IO.Parser;

public delegate IPersist CreateEntityEventHandler(string className, long? label, bool headerEntity, out int[] i);
