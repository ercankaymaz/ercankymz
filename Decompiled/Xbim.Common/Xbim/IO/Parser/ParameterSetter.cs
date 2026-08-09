using Xbim.Common;

namespace Xbim.IO.Parser;

public delegate void ParameterSetter(int propIndex, IPropertyValue value, int[] nestedIndex);
