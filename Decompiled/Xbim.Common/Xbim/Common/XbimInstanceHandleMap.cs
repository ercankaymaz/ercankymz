using System.Collections.Generic;

namespace Xbim.Common;

public class XbimInstanceHandleMap : Dictionary<XbimInstanceHandle, XbimInstanceHandle>
{
	public IModel FromModel { get; private set; }

	public IModel ToModel { get; private set; }

	public XbimInstanceHandleMap(IModel from, IModel to)
	{
		FromModel = from;
		ToModel = to;
	}
}
