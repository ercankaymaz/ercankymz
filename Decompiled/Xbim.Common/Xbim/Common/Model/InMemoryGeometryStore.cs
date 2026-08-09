using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Xbim.Common.Geometry;

namespace Xbim.Common.Model;

public class InMemoryGeometryStore : IGeometryStore, IDisposable
{
	private ConcurrentDictionary<int, XbimShapeGeometry> _shapeGeometries = new ConcurrentDictionary<int, XbimShapeGeometry>();

	private ConcurrentDictionary<int, XbimShapeInstance> _shapeInstances = new ConcurrentDictionary<int, XbimShapeInstance>();

	private Dictionary<int, List<XbimShapeInstance>> _entityInstanceLookup = new Dictionary<int, List<XbimShapeInstance>>();

	private Dictionary<int, List<XbimShapeInstance>> _entityTypeLookup = new Dictionary<int, List<XbimShapeInstance>>();

	private Dictionary<int, List<XbimShapeInstance>> _entityStyleLookup = new Dictionary<int, List<XbimShapeInstance>>();

	private Dictionary<int, List<XbimShapeInstance>> _geometryShapeLookup = new Dictionary<int, List<XbimShapeInstance>>();

	private HashSet<int> _styles = new HashSet<int>();

	private readonly XbimContextRegionCollection _regions = new XbimContextRegionCollection();

	private HashSet<int> _contextIds = new HashSet<int>();

	private int _geometryCount;

	private int _instanceCount;

	public IDictionary<int, XbimShapeGeometry> ShapeGeometries => _shapeGeometries;

	public IDictionary<int, XbimShapeInstance> ShapeInstances => _shapeInstances;

	public IDictionary<int, List<XbimShapeInstance>> EntityInstanceLookup => _entityInstanceLookup;

	public IDictionary<int, List<XbimShapeInstance>> EntityTypeLookup => _entityTypeLookup;

	public IDictionary<int, List<XbimShapeInstance>> EntityStyleLookup => _entityStyleLookup;

	public IDictionary<int, List<XbimShapeInstance>> GeometryShapeLookup => _geometryShapeLookup;

	public ISet<int> Styles => _styles;

	public XbimContextRegionCollection ContextRegions => _regions;

	public IEnumerable<int> ContextIds => _contextIds;

	public bool IsEmpty => !ShapeGeometries.Any();

	internal int AddShapeGeometry(XbimShapeGeometry shapeGeometry)
	{
		int num = (shapeGeometry.ShapeLabel = Interlocked.Increment(ref _geometryCount));
		_shapeGeometries.TryAdd(num, shapeGeometry);
		return num;
	}

	internal int AddShapeInstance(XbimShapeInstance shapeInstance, int geometryId)
	{
		int num = Interlocked.Increment(ref _instanceCount);
		shapeInstance.ShapeGeometryLabel = geometryId;
		_shapeInstances.TryAdd(num, shapeInstance);
		return num;
	}

	public IGeometryStoreInitialiser BeginInit()
	{
		_shapeGeometries = new ConcurrentDictionary<int, XbimShapeGeometry>();
		_shapeInstances = new ConcurrentDictionary<int, XbimShapeInstance>();
		_geometryCount = 0;
		_instanceCount = 0;
		return new InMemoryGeometryStoreInitialiser(this);
	}

	internal void EndInit(IGeometryStoreInitialiser transaction)
	{
		_entityInstanceLookup = (from s in ShapeInstances
			group s by s.Value.IfcProductLabel).ToDictionary((IGrouping<int, KeyValuePair<int, XbimShapeInstance>> s) => s.Key, (IGrouping<int, KeyValuePair<int, XbimShapeInstance>> v) => v.Select((KeyValuePair<int, XbimShapeInstance> instance) => instance.Value).ToList());
		_entityTypeLookup = ((IEnumerable<KeyValuePair<int, XbimShapeInstance>>)ShapeInstances).GroupBy((Func<KeyValuePair<int, XbimShapeInstance>, int>)((KeyValuePair<int, XbimShapeInstance> s) => s.Value.IfcTypeId)).ToDictionary((IGrouping<int, KeyValuePair<int, XbimShapeInstance>> s) => s.Key, (IGrouping<int, KeyValuePair<int, XbimShapeInstance>> v) => v.Select((KeyValuePair<int, XbimShapeInstance> instance) => instance.Value).ToList());
		_entityStyleLookup = (from s in ShapeInstances
			group s by (s.Value.StyleLabel <= 0) ? (-s.Value.IfcTypeId) : s.Value.StyleLabel).ToDictionary((IGrouping<int, KeyValuePair<int, XbimShapeInstance>> s) => s.Key, (IGrouping<int, KeyValuePair<int, XbimShapeInstance>> v) => v.Select((KeyValuePair<int, XbimShapeInstance> instance) => instance.Value).ToList());
		_geometryShapeLookup = (from s in ShapeInstances
			group s by s.Value.ShapeGeometryLabel).ToDictionary((IGrouping<int, KeyValuePair<int, XbimShapeInstance>> s) => s.Key, (IGrouping<int, KeyValuePair<int, XbimShapeInstance>> v) => v.Select((KeyValuePair<int, XbimShapeInstance> instance) => instance.Value).ToList());
		_styles = new HashSet<int>(from s in EntityStyleLookup
			where s.Key > 0
			select s.Key);
		_contextIds = new HashSet<int>(ShapeInstances.Select((KeyValuePair<int, XbimShapeInstance> s) => s.Value.RepresentationContext).Distinct());
		foreach (var item in ShapeInstances.Values.GroupBy((XbimShapeInstance i) => i.ShapeGeometryLabel, (int label, IEnumerable<XbimShapeInstance> instances) => new
		{
			Label = label,
			Count = instances.Count()
		}))
		{
			ShapeGeometries[item.Label].ReferenceCount = item.Count;
		}
	}

	public IGeometryStoreReader BeginRead()
	{
		return new InMemoryGeometryStoreReader(this);
	}

	internal int AddRegions(XbimRegionCollection regions)
	{
		_regions.Add(regions);
		return _regions.Count - 1;
	}

	public void Dispose()
	{
	}
}
