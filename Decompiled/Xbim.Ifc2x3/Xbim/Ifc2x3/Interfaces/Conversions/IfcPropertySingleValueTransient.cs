using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.Interfaces.Conversions;

internal class IfcPropertySingleValueTransient : PersistEntityTransient, IIfcPropertySingleValue, IIfcSimpleProperty, IIfcProperty, IIfcPropertyAbstraction, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	private readonly IfcIdentifier _name;

	private readonly IIfcValue _nominalValue;

	public IEnumerable<IIfcExternalReferenceRelationship> HasExternalReferences
	{
		get
		{
			yield break;
		}
	}

	public IfcIdentifier Name
	{
		get
		{
			return _name;
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

	public IEnumerable<IIfcPropertySet> PartOfPset
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcPropertyDependencyRelationship> PropertyForDependance
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcPropertyDependencyRelationship> PropertyDependsOn
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcComplexProperty> PartOfComplex
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcResourceConstraintRelationship> HasConstraints
	{
		get
		{
			yield break;
		}
	}

	public IEnumerable<IIfcResourceApprovalRelationship> HasApprovals
	{
		get
		{
			yield break;
		}
	}

	public IIfcValue NominalValue
	{
		get
		{
			return _nominalValue;
		}
		set
		{
			throw new NotSupportedException();
		}
	}

	public IIfcUnit Unit
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

	public IfcPropertySingleValueTransient(string name, IIfcValue value)
	{
		_name = name;
		_nominalValue = value;
	}
}
