using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using Xbim.Common;
using Xbim.Common.Enumerations;
using Xbim.Common.Exceptions;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.ProductExtension;
using Xbim.Ifc2x3.RepresentationResource;
using Xbim.Ifc2x3.Validation;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;

namespace Xbim.Ifc2x3.Kernel;

[ExpressType("IfcProduct", 20)]
public abstract class IfcProduct : IfcObject, IIfcProduct, IIfcObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IEquatable<IfcProduct>, IExpressValidatable
{
	public enum IfcProductClause
	{
		WR1
	}

	private IfcObjectPlacement _objectPlacement;

	private IfcProductRepresentation _representation;

	[CrossSchemaAttribute(typeof(IIfcProduct), 6)]
	IIfcObjectPlacement IIfcProduct.ObjectPlacement
	{
		get
		{
			return ObjectPlacement;
		}
		set
		{
			ObjectPlacement = value as IfcObjectPlacement;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcProduct), 7)]
	IIfcProductRepresentation IIfcProduct.Representation
	{
		get
		{
			return Representation;
		}
		set
		{
			Representation = value as IfcProductRepresentation;
		}
	}

	IEnumerable<IIfcRelAssignsToProduct> IIfcProduct.ReferencedBy => base.Model.Instances.Where((IIfcRelAssignsToProduct e) => e.RelatingProduct as IfcProduct == this, "RelatingProduct", this);

	[IndexedProperty]
	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 11)]
	public IfcObjectPlacement ObjectPlacement
	{
		get
		{
			if (_activated)
			{
				return _objectPlacement;
			}
			Activate();
			return _objectPlacement;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcObjectPlacement v)
			{
				_objectPlacement = v;
			}, _objectPlacement, value, "ObjectPlacement", 6);
		}
	}

	[IndexedProperty]
	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 12)]
	public IfcProductRepresentation Representation
	{
		get
		{
			if (_activated)
			{
				return _representation;
			}
			Activate();
			return _representation;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcProductRepresentation v)
			{
				_representation = v;
			}, _representation, value, "Representation", 7);
		}
	}

	[InverseProperty("RelatingProduct")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 0 }, new int[] { -1 }, 13)]
	public IEnumerable<IfcRelAssignsToProduct> ReferencedBy => base.Model.Instances.Where((IfcRelAssignsToProduct e) => Equals(e.RelatingProduct), "RelatingProduct", this);

	public IIfcSpatialElement IsContainedIn => (from s in base.Model.Instances
		where s.RelatedElements.Contains(this)
		select s.RelatingStructure).FirstOrDefault();

	internal IfcProduct(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
		case 3:
		case 4:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 5:
			_objectPlacement = (IfcObjectPlacement)value.EntityVal;
			break;
		case 6:
			_representation = (IfcProductRepresentation)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcProduct other)
	{
		return this == other;
	}

	public bool ValidateClause(IfcProductClause clause)
	{
		bool result = false;
		try
		{
			if (clause == IfcProductClause.WR1)
			{
				result = (Functions.EXISTS(Representation) && Functions.EXISTS(ObjectPlacement)) || (Functions.EXISTS(Representation) && !Functions.TYPEOF(Representation).Contains("IFC2X3.IFCPRODUCTDEFINITIONSHAPE")) || !Functions.EXISTS(Representation);
			}
		}
		catch (Exception ex)
		{
			ValidationLogging.CreateLogger<IfcProduct>()?.LogError($"Exception thrown evaluating where-clause 'IfcProduct.{clause}' for #{base.EntityLabel}.", ex);
		}
		return result;
	}

	public override IEnumerable<ValidationResult> Validate()
	{
		foreach (ValidationResult item in base.Validate())
		{
			yield return item;
		}
		if (!ValidateClause(IfcProductClause.WR1))
		{
			yield return new ValidationResult
			{
				Item = this,
				IssueSource = "IfcProduct.WR1",
				IssueType = ValidationFlags.EntityWhereClauses
			};
		}
	}
}
