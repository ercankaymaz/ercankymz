using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal abstract class IfcPhysicalSimpleQuantityTransient : PersistEntityTransient, IIfcPhysicalSimpleQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	public IIfcNamedUnit _unit;

	public IfcLabel Name
	{
		get
		{
			return default(IfcLabel);
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IfcText? Description
	{
		get
		{
			return null;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcPhysicalComplexQuantity> PartOfComplex
	{
		get
		{
			yield break;
		}
	}

	public IIfcNamedUnit Unit
	{
		get
		{
			return _unit;
		}
		set
		{
			throw new NotSupportedException();
		}
	}
}
