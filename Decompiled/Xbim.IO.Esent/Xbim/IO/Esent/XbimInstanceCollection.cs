using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xbim.Common;

namespace Xbim.IO.Esent;

public class XbimInstanceCollection : IEntityCollection, IReadOnlyEntityCollection, IEnumerable<IPersistEntity>, IEnumerable
{
	protected readonly PersistedEntityInstanceCache Cache;

	private readonly EsentModel _model;

	public long Count => Cache.Count;

	public int LastLabel => Cache.HighestLabel;

	public IPersistEntity this[int label] => Cache.GetInstance(label, loadProperties: true, unCached: true);

	public IEnumerable<IPersistEntity> OfType(string stringType, bool activate)
	{
		return Cache.OfType(stringType, activate);
	}

	internal XbimInstanceCollection(EsentModel esentModel)
	{
		Cache = esentModel.Cache;
		_model = esentModel;
	}

	public long CountOf<TIfcType>() where TIfcType : IPersistEntity
	{
		return Cache.CountOf<TIfcType>();
	}

	public IEnumerable<TIfc> OfType<TIfc>(bool activate) where TIfc : IPersistEntity
	{
		return Cache.OfType<TIfc>(activate);
	}

	public IEnumerable<T> Where<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		return Cache.Where(condition, inverseProperty, inverseArgument);
	}

	public T FirstOrDefault<T>() where T : IPersistEntity
	{
		return OfType<T>().FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> expr) where T : IPersistEntity
	{
		return Where(expr).FirstOrDefault();
	}

	public T FirstOrDefault<T>(Func<T, bool> condition, string inverseProperty, IPersistEntity inverseArgument) where T : IPersistEntity
	{
		return Where(condition, inverseProperty, inverseArgument).FirstOrDefault();
	}

	public IEnumerable<TIfc> OfType<TIfc>() where TIfc : IPersistEntity
	{
		return Cache.OfType<TIfc>();
	}

	public IEnumerable<TIfcType> Where<TIfcType>(Func<TIfcType, bool> expression) where TIfcType : IPersistEntity
	{
		return Cache.Where(expression);
	}

	public IEnumerable<XbimInstanceHandle> Handles()
	{
		return Cache.InstanceHandles;
	}

	public IEnumerable<XbimInstanceHandle> Handles<T>()
	{
		return Cache.InstanceHandlesOfType<T>();
	}

	public IPersistEntity GetFromGeometryLabel(int geometryLabel)
	{
		XbimGeometryHandle geometryHandle = Cache.GetGeometryHandle(geometryLabel);
		return Cache.GetInstance(geometryHandle.ProductLabel, loadProperties: true, unCached: true);
	}

	public TIfcType New<TIfcType>() where TIfcType : IInstantiableEntity
	{
		Type typeFromHandle = typeof(TIfcType);
		return (TIfcType)New(typeFromHandle);
	}

	public TIfcType New<TIfcType>(Action<TIfcType> initPropertiesFunc) where TIfcType : IInstantiableEntity
	{
		TIfcType val = New<TIfcType>();
		initPropertiesFunc?.Invoke(val);
		return val;
	}

	public IPersistEntity New(Type t)
	{
		IPersistEntity persistEntity = Cache.CreateNew(t);
		_model.HandleEntityChange(ChangeType.New, persistEntity, 0);
		return persistEntity;
	}

	public bool Contains(int entityLabel)
	{
		return Cache.Contains(entityLabel);
	}

	public bool Contains(IPersistEntity instance)
	{
		return Cache.Contains(instance);
	}

	IEnumerator<IPersistEntity> IEnumerable<IPersistEntity>.GetEnumerator()
	{
		return new XbimInstancesEntityEnumerator(Cache);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return new XbimInstancesEntityEnumerator(Cache);
	}
}
