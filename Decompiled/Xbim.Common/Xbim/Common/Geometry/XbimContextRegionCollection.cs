using System.Collections.Generic;

namespace Xbim.Common.Geometry;

public class XbimContextRegionCollection : List<XbimRegionCollection>
{
	private XbimRegionCollection MostPopulated()
	{
		XbimRegionCollection xbimRegionCollection = new XbimRegionCollection();
		using Enumerator enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			XbimRegion xbimRegion = enumerator.Current.MostPopulated();
			if (xbimRegion != null)
			{
				xbimRegionCollection.Add(xbimRegion);
			}
		}
		return xbimRegionCollection;
	}
}
