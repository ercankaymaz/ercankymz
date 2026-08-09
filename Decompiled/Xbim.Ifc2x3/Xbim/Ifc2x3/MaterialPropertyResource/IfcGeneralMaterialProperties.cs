using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;

namespace Xbim.Ifc2x3.MaterialPropertyResource;

[ExpressType("IfcGeneralMaterialProperties", 716)]
public class IfcGeneralMaterialProperties : IfcMaterialProperties, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcGeneralMaterialProperties>
{
	private IfcMolecularWeightMeasure? _molecularWeight;

	private IfcNormalisedRatioMeasure? _porosity;

	private IfcMassDensityMeasure? _massDensity;

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcMolecularWeightMeasure? MolecularWeight
	{
		get
		{
			if (_activated)
			{
				return _molecularWeight;
			}
			Activate();
			return _molecularWeight;
		}
		set
		{
			SetValue(delegate(IfcMolecularWeightMeasure? v)
			{
				_molecularWeight = v;
			}, _molecularWeight, value, "MolecularWeight", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcNormalisedRatioMeasure? Porosity
	{
		get
		{
			if (_activated)
			{
				return _porosity;
			}
			Activate();
			return _porosity;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_porosity = v;
			}, _porosity, value, "Porosity", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcMassDensityMeasure? MassDensity
	{
		get
		{
			if (_activated)
			{
				return _massDensity;
			}
			Activate();
			return _massDensity;
		}
		set
		{
			SetValue(delegate(IfcMassDensityMeasure? v)
			{
				_massDensity = v;
			}, _massDensity, value, "MassDensity", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Material != null)
			{
				yield return base.Material;
			}
		}
	}

	internal IfcGeneralMaterialProperties(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_molecularWeight = value.RealVal;
			break;
		case 2:
			_porosity = value.RealVal;
			break;
		case 3:
			_massDensity = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcGeneralMaterialProperties other)
	{
		return this == other;
	}
}
