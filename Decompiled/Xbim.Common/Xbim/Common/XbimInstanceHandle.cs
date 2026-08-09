using System;
using Xbim.Common.Metadata;

namespace Xbim.Common;

public struct XbimInstanceHandle
{
	public readonly int EntityLabel;

	public short EntityTypeId;

	public readonly IModel Model;

	public Type EntityType => Model.Metadata.GetType(EntityTypeId);

	public ExpressType EntityExpressType => Model.Metadata.ExpressType(EntityTypeId);

	public bool IsEmpty => Model == null;

	public static bool operator ==(XbimInstanceHandle a, XbimInstanceHandle b)
	{
		if (a.Model == b.Model && a.EntityLabel == b.EntityLabel)
		{
			return a.EntityTypeId == b.EntityTypeId;
		}
		return false;
	}

	public static bool operator !=(XbimInstanceHandle a, XbimInstanceHandle b)
	{
		if (a.Model == b.Model && a.EntityLabel == b.EntityLabel)
		{
			return a.EntityTypeId == b.EntityTypeId;
		}
		return true;
	}

	public override int GetHashCode()
	{
		int entityLabel = EntityLabel;
		return entityLabel.GetHashCode() ^ Model.GetHashCode();
	}

	public override bool Equals(object b)
	{
		if (Model.Equals(((XbimInstanceHandle)b).Model) && EntityLabel == ((XbimInstanceHandle)b).EntityLabel)
		{
			return EntityTypeId == ((XbimInstanceHandle)b).EntityTypeId;
		}
		return false;
	}

	public XbimInstanceHandle(IModel model, int entityLabel, short type = 0)
	{
		Model = model;
		EntityLabel = entityLabel;
		EntityTypeId = type;
	}

	public XbimInstanceHandle(IModel model, int entityLabel, Type type)
	{
		Model = model;
		EntityLabel = entityLabel;
		EntityTypeId = Model.Metadata.ExpressTypeId(type);
	}

	public XbimInstanceHandle(IModel model, int? label, short? type)
	{
		Model = model;
		EntityLabel = label.GetValueOrDefault();
		EntityTypeId = type.GetValueOrDefault();
	}

	public XbimInstanceHandle(IPersistEntity entity)
	{
		Model = entity.Model;
		EntityLabel = entity.EntityLabel;
		EntityTypeId = Model.Metadata.ExpressTypeId(entity);
	}

	public IPersistEntity GetEntity()
	{
		return Model.Instances[EntityLabel];
	}

	internal ExpressType ExpressType()
	{
		return Model.Metadata.ExpressType(EntityTypeId);
	}
}
