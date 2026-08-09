using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4.Validation;

namespace Xbim.Ifc4.GeometricModelResource;

[ExpressType("IfcGeometricSet", 236)]
public class IfcGeometricSet : IfcGeometricRepresentationItem, IInstantiableEntity, IPersistEntity, IPersist, IIfcGeometricSet, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcGeometricSet>, IExpressValidatable
{
	public enum IfcGeometricSetClause
	{
		ConsistentDim
	}

	private readonly ItemSet<IfcGeometricSetSelect> _elements;

	IItemSet<IIfcGeometricSetSelect> IIfcGeometricSet.Elements => new ProxyItemSet<IfcGeometricSetSelect, IIfcGeometricSetSelect>(Elements);

	IfcDimensionCount IIfcGeometricSet.Dim => Dim;

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
	public IfcDimensionCount Dim
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
			if (clause == IfcGeometricSetClause.ConsistentDim)
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
		if (!ValidateClause(IfcGeometricSetClause.ConsistentDim))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcGeometricSet.ConsistentDim",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
