using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common.Metadata;

namespace Xbim.IO.Esent;

public class XbimGeometryHandleCollection : List<XbimGeometryHandle>
{
	private readonly ExpressMetaData _metadata;

	public XbimGeometryHandleCollection(IEnumerable<XbimGeometryHandle> enumerable, ExpressMetaData metadata)
		: base(enumerable)
	{
		_metadata = metadata;
	}

	public XbimGeometryHandleCollection()
	{
	}

	public IEnumerable<XbimSurfaceStyle> GetSurfaceStyles()
	{
		HashSet<XbimSurfaceStyle> hashSet = new HashSet<XbimSurfaceStyle>();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			hashSet.Add(enumerator.Current.SurfaceStyle);
		}
		return hashSet;
	}

	public IEnumerable<XbimGeometryHandle> Exclude(params int[] exclude)
	{
		HashSet<int> excludeSet = new HashSet<int>(exclude);
		foreach (int num in exclude)
		{
			foreach (ExpressType nonAbstractSubType in _metadata.ExpressType((short)num).NonAbstractSubTypes)
			{
				excludeSet.Add(nonAbstractSubType.TypeId);
			}
		}
		return this.Where((XbimGeometryHandle h) => !excludeSet.Contains(h.ExpressTypeId));
	}

	public IEnumerable<XbimGeometryHandle> Include(params int[] include)
	{
		HashSet<int> includeSet = new HashSet<int>(include);
		foreach (int num in include)
		{
			foreach (ExpressType subType in _metadata.ExpressType((short)num).SubTypes)
			{
				includeSet.Add(subType.TypeId);
			}
		}
		return this.Where((XbimGeometryHandle h) => includeSet.Contains(h.ExpressTypeId));
	}

	public IEnumerable<XbimGeometryHandle> GetGeometryHandles(XbimSurfaceStyle forStyle)
	{
		return this.Where((XbimGeometryHandle gh) => gh.SurfaceStyle.Equals(forStyle));
	}

	public XbimSurfaceStyleMap ToSurfaceStyleMap(Module module)
	{
		XbimSurfaceStyleMap xbimSurfaceStyleMap = new XbimSurfaceStyleMap();
		foreach (XbimSurfaceStyle surfaceStyle in GetSurfaceStyles())
		{
			xbimSurfaceStyleMap.Add(surfaceStyle, new XbimGeometryHandleCollection());
		}
		using Enumerator enumerator2 = GetEnumerator();
		while (enumerator2.MoveNext())
		{
			XbimGeometryHandle current2 = enumerator2.Current;
			xbimSurfaceStyleMap[current2.SurfaceStyle].Add(current2);
		}
		return xbimSurfaceStyleMap;
	}
}
