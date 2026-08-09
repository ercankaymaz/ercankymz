using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.Kernel;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.Kernel;
using Xbim.Ifc4x3.MeasureResource;
using Xbim.Ifc4x3.RepresentationResource;

namespace Xbim.Ifc4x3.ArchitectureDomain;

[ExpressType("IfcWindowLiningProperties", 252)]
public class IfcWindowLiningProperties : Xbim.Ifc4x3.Kernel.IfcPreDefinedPropertySet, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcWindowLiningProperties>, IIfcWindowLiningProperties, IIfcPreDefinedPropertySet, IIfcPropertySetDefinition, IIfcPropertyDefinition, IIfcRoot, Xbim.Ifc4.Kernel.IfcDefinitionSelect, IIfcDefinitionSelect, IExpressSelectType, Xbim.Ifc4.Kernel.IfcPropertySetDefinitionSelect, IIfcPropertySetDefinitionSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? _liningDepth;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _liningThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _transomThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? _mullionThickness;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _firstTransomOffset;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _secondTransomOffset;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _firstMullionOffset;

	private Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? _secondMullionOffset;

	private IfcShapeAspect _shapeAspectStyle;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _liningOffset;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetX;

	private Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? _liningToPanelOffsetY;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 10)]
	public Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? LiningDepth
	{
		get
		{
			if (_activated)
			{
				return _liningDepth;
			}
			Activate();
			return _liningDepth;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure? v)
			{
				_liningDepth = v;
			}, _liningDepth, value, "LiningDepth", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 11)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? LiningThickness
	{
		get
		{
			if (_activated)
			{
				return _liningThickness;
			}
			Activate();
			return _liningThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_liningThickness = v;
			}, _liningThickness, value, "LiningThickness", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 12)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? TransomThickness
	{
		get
		{
			if (_activated)
			{
				return _transomThickness;
			}
			Activate();
			return _transomThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_transomThickness = v;
			}, _transomThickness, value, "TransomThickness", 7);
		}
	}

	[EntityAttribute(8, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 13)]
	public Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? MullionThickness
	{
		get
		{
			if (_activated)
			{
				return _mullionThickness;
			}
			Activate();
			return _mullionThickness;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure? v)
			{
				_mullionThickness = v;
			}, _mullionThickness, value, "MullionThickness", 8);
		}
	}

	[EntityAttribute(9, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 14)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? FirstTransomOffset
	{
		get
		{
			if (_activated)
			{
				return _firstTransomOffset;
			}
			Activate();
			return _firstTransomOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_firstTransomOffset = v;
			}, _firstTransomOffset, value, "FirstTransomOffset", 9);
		}
	}

	[EntityAttribute(10, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 15)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? SecondTransomOffset
	{
		get
		{
			if (_activated)
			{
				return _secondTransomOffset;
			}
			Activate();
			return _secondTransomOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_secondTransomOffset = v;
			}, _secondTransomOffset, value, "SecondTransomOffset", 10);
		}
	}

	[EntityAttribute(11, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 16)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? FirstMullionOffset
	{
		get
		{
			if (_activated)
			{
				return _firstMullionOffset;
			}
			Activate();
			return _firstMullionOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_firstMullionOffset = v;
			}, _firstMullionOffset, value, "FirstMullionOffset", 11);
		}
	}

	[EntityAttribute(12, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 17)]
	public Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? SecondMullionOffset
	{
		get
		{
			if (_activated)
			{
				return _secondMullionOffset;
			}
			Activate();
			return _secondMullionOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure? v)
			{
				_secondMullionOffset = v;
			}, _secondMullionOffset, value, "SecondMullionOffset", 12);
		}
	}

	[EntityAttribute(13, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 18)]
	public IfcShapeAspect ShapeAspectStyle
	{
		get
		{
			if (_activated)
			{
				return _shapeAspectStyle;
			}
			Activate();
			return _shapeAspectStyle;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcShapeAspect v)
			{
				_shapeAspectStyle = v;
			}, _shapeAspectStyle, value, "ShapeAspectStyle", 13);
		}
	}

	[EntityAttribute(14, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? LiningOffset
	{
		get
		{
			if (_activated)
			{
				return _liningOffset;
			}
			Activate();
			return _liningOffset;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_liningOffset = v;
			}, _liningOffset, value, "LiningOffset", 14);
		}
	}

	[EntityAttribute(15, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 20)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? LiningToPanelOffsetX
	{
		get
		{
			if (_activated)
			{
				return _liningToPanelOffsetX;
			}
			Activate();
			return _liningToPanelOffsetX;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_liningToPanelOffsetX = v;
			}, _liningToPanelOffsetX, value, "LiningToPanelOffsetX", 15);
		}
	}

	[EntityAttribute(16, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 21)]
	public Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? LiningToPanelOffsetY
	{
		get
		{
			if (_activated)
			{
				return _liningToPanelOffsetY;
			}
			Activate();
			return _liningToPanelOffsetY;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure? v)
			{
				_liningToPanelOffsetY = v;
			}, _liningToPanelOffsetY, value, "LiningToPanelOffsetY", 16);
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
			if (ShapeAspectStyle != null)
			{
				yield return ShapeAspectStyle;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 5)]
	Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure? IIfcWindowLiningProperties.LiningDepth
	{
		get
		{
			if (!LiningDepth.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcPositiveLengthMeasure(LiningDepth.Value);
		}
		set
		{
			LiningDepth = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcPositiveLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 6)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.LiningThickness
	{
		get
		{
			if (!LiningThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(LiningThickness.Value);
		}
		set
		{
			LiningThickness = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 7)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.TransomThickness
	{
		get
		{
			if (!TransomThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(TransomThickness.Value);
		}
		set
		{
			TransomThickness = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 8)]
	Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure? IIfcWindowLiningProperties.MullionThickness
	{
		get
		{
			if (!MullionThickness.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNonNegativeLengthMeasure(MullionThickness.Value);
		}
		set
		{
			MullionThickness = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNonNegativeLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 9)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstTransomOffset
	{
		get
		{
			if (!FirstTransomOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(FirstTransomOffset.Value);
		}
		set
		{
			FirstTransomOffset = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 10)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondTransomOffset
	{
		get
		{
			if (!SecondTransomOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(SecondTransomOffset.Value);
		}
		set
		{
			SecondTransomOffset = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 11)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.FirstMullionOffset
	{
		get
		{
			if (!FirstMullionOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(FirstMullionOffset.Value);
		}
		set
		{
			FirstMullionOffset = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 12)]
	Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure? IIfcWindowLiningProperties.SecondMullionOffset
	{
		get
		{
			if (!SecondMullionOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcNormalisedRatioMeasure(SecondMullionOffset.Value);
		}
		set
		{
			SecondMullionOffset = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcNormalisedRatioMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 13)]
	IIfcShapeAspect IIfcWindowLiningProperties.ShapeAspectStyle
	{
		get
		{
			return ShapeAspectStyle;
		}
		set
		{
			ShapeAspectStyle = value as IfcShapeAspect;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 14)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningOffset
	{
		get
		{
			if (!LiningOffset.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LiningOffset.Value);
		}
		set
		{
			LiningOffset = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 15)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetX
	{
		get
		{
			if (!LiningToPanelOffsetX.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LiningToPanelOffsetX.Value);
		}
		set
		{
			LiningToPanelOffsetX = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcWindowLiningProperties), 16)]
	Xbim.Ifc4.MeasureResource.IfcLengthMeasure? IIfcWindowLiningProperties.LiningToPanelOffsetY
	{
		get
		{
			if (!LiningToPanelOffsetY.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(LiningToPanelOffsetY.Value);
		}
		set
		{
			LiningToPanelOffsetY = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?(new Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLengthMeasure?)null));
		}
	}

	internal IfcWindowLiningProperties(IModel model, int label, bool activated)
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
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 4:
			_liningDepth = value.RealVal;
			break;
		case 5:
			_liningThickness = value.RealVal;
			break;
		case 6:
			_transomThickness = value.RealVal;
			break;
		case 7:
			_mullionThickness = value.RealVal;
			break;
		case 8:
			_firstTransomOffset = value.RealVal;
			break;
		case 9:
			_secondTransomOffset = value.RealVal;
			break;
		case 10:
			_firstMullionOffset = value.RealVal;
			break;
		case 11:
			_secondMullionOffset = value.RealVal;
			break;
		case 12:
			_shapeAspectStyle = (IfcShapeAspect)value.EntityVal;
			break;
		case 13:
			_liningOffset = value.RealVal;
			break;
		case 14:
			_liningToPanelOffsetX = value.RealVal;
			break;
		case 15:
			_liningToPanelOffsetY = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcWindowLiningProperties other)
	{
		return this == other;
	}
}
