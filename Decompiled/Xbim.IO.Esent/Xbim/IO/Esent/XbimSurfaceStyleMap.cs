using System.Collections.Generic;
using System.Linq;

namespace Xbim.IO.Esent;

public class XbimSurfaceStyleMap : Dictionary<XbimSurfaceStyle, XbimGeometryHandleCollection>
{
	public IEnumerable<XbimSurfaceStyle> Styles => base.Keys;

	public IEnumerable<XbimGeometryHandle> GeometryHandles
	{
		get
		{
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				foreach (XbimGeometryHandle item in enumerator.Current.Value)
				{
					yield return item;
				}
			}
		}
	}

	public IEnumerable<XbimGeometryHandle> GeometryHandlesForStyle(XbimSurfaceStyle style)
	{
		if (TryGetValue(style, out var value))
		{
			return value;
		}
		return Enumerable.Empty<XbimGeometryHandle>();
	}
}
