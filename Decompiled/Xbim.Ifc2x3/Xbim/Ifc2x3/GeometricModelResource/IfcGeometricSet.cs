using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcGeometricSet", 236)]
public class IfcGeometricSet : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeometricSet>, IIfcGeometricSet, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IExpressValidatable
{
	public enum IfcGeometricSetClause
	{
		WR21
	}

	private readonly ItemSet<IfcGeometricSetSelect> _elements;

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 3)]
	public IItemSet<IfcGeometricSetSelect> Elements
	{
		get
		{
			if (_activated)
			{
				return _elements;
			}
			Activate();
			return _elements;
		}
	}

	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim
	{
		get
		{
			if (Elements == null)
			{
				return 0L;
			}
			return Elements[0].Dim;
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcGeometricSetSelect element in Elements)
			{
				yield return element;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcGeometricSet), 1)]
	IItemSet<IIfcGeometricSetSelect> IIfcGeometricSet.Elements => new ProxyItemSet<IfcGeometricSetSelect, IIfcGeometricSetSelect>(Elements);

	Xbim.Ifc4.GeometryResource.IfcDimensionCount IIfcGeometricSet.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcGeometricSet(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_elements = new ItemSet<IfcGeometricSetSelect>(this, 0, 1);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if (propIndex == 0)
		{
			_elements.InternalAdd((IfcGeometricSetSelect)value.EntityVal);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcGeometricSet other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcGeometricSetClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcGeometricSetClause.WR21)
			{
				result = Functions.SIZEOF(Enumerable.Where(Elements, (IfcGeometricSetSelect Temp) => Temp.Dim != Elements.ItemAt(0L).Dim)) == 0;
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcGeometricSet>()?.LogError($"Exception thrown evaluating where-clause 'IfcGeometricSet.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public virtual IEnumerable<ValidationResult> Validate()
	{
		if (!ValidateClause(IfcGeometricSetClause.WR21))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricSet.WR21",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
