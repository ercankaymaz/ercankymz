using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcZShapeProfileDef", 528)]
public class IfcZShapeProfileDef : IfcParameterizedProfileDef, IIfcZShapeProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcZShapeProfileDef>
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _depth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _flangeWidth;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _webThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure _flangeThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _filletRadius;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _edgeRadius;

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 4)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcZShapeProfileDef.Depth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(Depth);
		}
		set
		{
			Depth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcZShapeProfileDef.FlangeWidth
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FlangeWidth);
		}
		set
		{
			FlangeWidth = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 6)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcZShapeProfileDef.WebThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(WebThickness);
		}
		set
		{
			WebThickness = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 7)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure IIfcZShapeProfileDef.FlangeThickness
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(FlangeThickness);
		}
		set
		{
			FlangeThickness = new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 8)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcZShapeProfileDef.FilletRadius
	{
		get
		{
			if (!FilletRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(FilletRadius.Value);
		}
		set
		{
			FilletRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcZShapeProfileDef), 9)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcZShapeProfileDef.EdgeRadius
	{
		get
		{
			if (!EdgeRadius.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(EdgeRadius.Value);
		}
		set
		{
			EdgeRadius = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure Depth
	{
		get
		{
			if (_activated)
			{
				return _depth;
			}
			Activate();
			return _depth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_depth = v;
			}, _depth, value, "Depth", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure FlangeWidth
	{
		get
		{
			if (_activated)
			{
				return _flangeWidth;
			}
			Activate();
			return _flangeWidth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_flangeWidth = v;
			}, _flangeWidth, value, "FlangeWidth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure WebThickness
	{
		get
		{
			if (_activated)
			{
				return _webThickness;
			}
			Activate();
			return _webThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_webThickness = v;
			}, _webThickness, value, "WebThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 9)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure FlangeThickness
	{
		get
		{
			if (_activated)
			{
				return _flangeThickness;
			}
			Activate();
			return _flangeThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure v)
			{
				_flangeThickness = v;
			}, _flangeThickness, value, "FlangeThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? FilletRadius
	{
		get
		{
			if (_activated)
			{
				return _filletRadius;
			}
			Activate();
			return _filletRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_filletRadius = v;
			}, _filletRadius, value, "FilletRadius", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? EdgeRadius
	{
		get
		{
			if (_activated)
			{
				return _edgeRadius;
			}
			Activate();
			return _edgeRadius;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_edgeRadius = v;
			}, _edgeRadius, value, "EdgeRadius", 9);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcZShapeProfileDef(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_depth = value.RealVal;
			break;
		case 4:
			_flangeWidth = value.RealVal;
			break;
		case 5:
			_webThickness = value.RealVal;
			break;
		case 6:
			_flangeThickness = value.RealVal;
			break;
		case 7:
			_filletRadius = value.RealVal;
			break;
		case 8:
			_edgeRadius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcZShapeProfileDef other)
	{
		return this == other;
	}
}
