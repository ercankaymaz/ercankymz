using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProductExtension;

namespace Xbim.Ifc2x3.ArchitectureDomain;

[ExpressType("IfcRelInteractionRequirements", 708)]
public class IfcRelInteractionRequirements : IfcRelConnects, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcRelInteractionRequirements>
{
	private IfcCountMeasure? _dailyInteraction;

	private IfcNormalisedRatioMeasure? _importanceRating;

	private IfcSpatialStructureElement _locationOfInteraction;

	private IfcSpaceProgram _relatedSpaceProgram;

	private IfcSpaceProgram _relatingSpaceProgram;

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 5)]
	public IfcCountMeasure? DailyInteraction
	{
		get
		{
			if (_activated)
			{
				return _dailyInteraction;
			}
			Activate();
			return _dailyInteraction;
		}
		set
		{
			SetValue(delegate(IfcCountMeasure? v)
			{
				_dailyInteraction = v;
			}, _dailyInteraction, value, "DailyInteraction", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcNormalisedRatioMeasure? ImportanceRating
	{
		get
		{
			if (_activated)
			{
				return _importanceRating;
			}
			Activate();
			return _importanceRating;
		}
		set
		{
			SetValue(delegate(IfcNormalisedRatioMeasure? v)
			{
				_importanceRating = v;
			}, _importanceRating, value, "ImportanceRating", 6);
		}
	}

	[EntityAttribute(7, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 7)]
	public IfcSpatialStructureElement LocationOfInteraction
	{
		get
		{
			if (_activated)
			{
				return _locationOfInteraction;
			}
			Activate();
			return _locationOfInteraction;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpatialStructureElement v)
			{
				_locationOfInteraction = v;
			}, _locationOfInteraction, value, "LocationOfInteraction", 7);
		}
	}

	[IndexedProperty]
	[EntityAttribute(8, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 8)]
	public IfcSpaceProgram RelatedSpaceProgram
	{
		get
		{
			if (_activated)
			{
				return _relatedSpaceProgram;
			}
			Activate();
			return _relatedSpaceProgram;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpaceProgram v)
			{
				_relatedSpaceProgram = v;
			}, _relatedSpaceProgram, value, "RelatedSpaceProgram", 8);
		}
	}

	[IndexedProperty]
	[EntityAttribute(9, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 9)]
	public IfcSpaceProgram RelatingSpaceProgram
	{
		get
		{
			if (_activated)
			{
				return _relatingSpaceProgram;
			}
			Activate();
			return _relatingSpaceProgram;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSpaceProgram v)
			{
				_relatingSpaceProgram = v;
			}, _relatingSpaceProgram, value, "RelatingSpaceProgram", 9);
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
			if (LocationOfInteraction != null)
			{
				yield return LocationOfInteraction;
			}
			if (RelatedSpaceProgram != null)
			{
				yield return RelatedSpaceProgram;
			}
			if (RelatingSpaceProgram != null)
			{
				yield return RelatingSpaceProgram;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			if (RelatedSpaceProgram != null)
			{
				yield return RelatedSpaceProgram;
			}
			if (RelatingSpaceProgram != null)
			{
				yield return RelatingSpaceProgram;
			}
		}
	}

	internal IfcRelInteractionRequirements(IModel model, int label, bool activated)
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
			_dailyInteraction = value.NumberVal;
			break;
		case 5:
			_importanceRating = value.RealVal;
			break;
		case 6:
			_locationOfInteraction = (IfcSpatialStructureElement)value.EntityVal;
			break;
		case 7:
			_relatedSpaceProgram = (IfcSpaceProgram)value.EntityVal;
			break;
		case 8:
			_relatingSpaceProgram = (IfcSpaceProgram)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcRelInteractionRequirements other)
	{
		return this == other;
	}
}
