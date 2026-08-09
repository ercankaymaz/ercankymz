using System;
using Xbim.Common.Metadata;
using Xbim.Ifc4;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3;

public static class IfcValueHelper
{
	private static ExpressMetaData _ifc4meta;

	private static ExpressMetaData _ifc4x3meta;

	private static ExpressMetaData Ifc4Meta => _ifc4meta ?? (_ifc4meta = ExpressMetaData.GetMetadata(new EntityFactoryIfc4()));

	private static ExpressMetaData Ifc4x3Meta => _ifc4x3meta ?? (_ifc4x3meta = ExpressMetaData.GetMetadata(new EntityFactoryIfc4x3Add2()));

	public static IIfcValue ToIfc4(this IfcValue value)
	{
		if (value == null)
		{
			return null;
		}
		string typeName = value.GetType().Name.ToUpperInvariant();
		if (!Ifc4Meta.TryGetExpressType(typeName, out var expressType))
		{
			throw new NotSupportedException();
		}
		return Activator.CreateInstance(expressType.Type, value.Value) as IIfcValue;
	}

	public static IfcValue ToIfc3(this IIfcValue value)
	{
		if (value == null)
		{
			return null;
		}
		string typeName = value.GetType().Name.ToUpperInvariant();
		if (!Ifc4x3Meta.TryGetExpressType(typeName, out var expressType))
		{
			throw new NotSupportedException();
		}
		return Activator.CreateInstance(expressType.Type, value.Value) as IfcValue;
	}
}
