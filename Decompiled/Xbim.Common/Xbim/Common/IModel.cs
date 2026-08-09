using System;
using System.Collections.Generic;
using Xbim.Common.Geometry;
using Xbim.Common.Metadata;
using Xbim.Common.Step21;

namespace Xbim.Common;

public interface IModel : IDisposable
{
	int UserDefinedId { get; set; }

	object Tag { get; set; }

	IGeometryStore GeometryStore { get; }

	IStepFileHeader Header { get; }

	bool IsTransactional { get; }

	IList<XbimInstanceHandle> InstanceHandles { get; }

	IEntityCollection Instances { get; }

	ITransaction CurrentTransaction { get; }

	ExpressMetaData Metadata { get; }

	IModelFactors ModelFactors { get; }

	IInverseCache InverseCache { get; }

	IEntityCache EntityCache { get; }

	XbimSchemaVersion SchemaVersion { get; }

	event NewEntityHandler EntityNew;

	event ModifiedEntityHandler EntityModified;

	event DeletedEntityHandler EntityDeleted;

	bool Activate(IPersistEntity owningEntity);

	void Delete(IPersistEntity entity);

	ITransaction BeginTransaction(string name);

	T InsertCopy<T>(T toCopy, XbimInstanceHandleMap mappings, PropertyTranformDelegate propTransform, bool includeInverses, bool keepLabels) where T : IPersistEntity;

	void ForEach<TSource>(IEnumerable<TSource> source, Action<TSource> body) where TSource : IPersistEntity;

	IInverseCache BeginInverseCaching();

	IEntityCache BeginEntityCaching();
}
