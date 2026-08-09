using Xbim.Common;

namespace Xbim.IO.Step21;

public delegate IPersist CreateEntityDelegate(string className, long? label, bool headerEntity);
