using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc2x3.SharedComponentElements;

[ExpressType("IfcMechanicalFastenerType", 643)]
public class IfcMechanicalFastenerType : IfcFastenerType, IIfcMechanicalFastenerType, IIfcElementComponentType, IIfcElementType, IIfcTypeProduct, IIfcTypeObject, IIfcObjectDefinition, IIfcRoot, IPersistEntity, IPersist, IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, IfcProductSelect, IIfcProductSelect, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcMechanicalFastenerType>
{
	private IfcMechanicalFastenerTypeEnum _predefinedType;

	private IfcPositiveLengthMeasure? _nominalDiameter;

	private IfcPositiveLengthMeasure? _nominalLength;

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 10)]
	IfcMechanicalFastenerTypeEnum IIfcMechanicalFastenerType.PredefinedType
	{
		get
		{
			return _predefinedType;
		}
		set
		{
			SetValue(delegate(IfcMechanicalFastenerTypeEnum v)
			{
				_predefinedType = v;
			}, _predefinedType, value, "PredefinedType", -10);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 11)]
	IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalDiameter
	{
		get
		{
			return _nominalDiameter;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_nominalDiameter = v;
			}, _nominalDiameter, value, "NominalDiameter", -11);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcMechanicalFastenerType), 12)]
	IfcPositiveLengthMeasure? IIfcMechanicalFastenerType.NominalLength
	{
		get
		{
			return _nominalLength;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_nominalLength = v;
			}, _nominalLength, value, "NominalLength", -12);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.OwnerHistory != null)
			{
				yield return base.OwnerHistory;
			}
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
			foreach (IfcRepresentationMap representationMap in base.RepresentationMaps)
			{
				yield return representationMap;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (Xbim.Ifc2x3.Kernel.IfcPropertySetDefinition hasPropertySet in base.HasPropertySets)
			{
				yield return hasPropertySet;
			}
		}
	}

	internal IfcMechanicalFastenerType(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 8u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcMechanicalFastenerType other)
	{
		return this == other;
	}
}
