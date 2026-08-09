using System;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.RepresentationResource;

[ExpressType("IfcCoordinateOperation", 1143)]
public abstract class IfcCoordinateOperation : PersistEntity, IIfcCoordinateOperation, IPersistEntity, IPersist, IEquatable<IfcCoordinateOperation>
{
	private IfcCoordinateReferenceSystemSelect _sourceCRS;

	private IfcCoordinateReferenceSystem _targetCRS;

	IIfcCoordinateReferenceSystemSelect IIfcCoordinateOperation.SourceCRS
	{
		get
		{
			return SourceCRS;
		}
		set
		{
			SourceCRS = value as IfcCoordinateReferenceSystemSelect;
		}
	}

	IIfcCoordinateReferenceSystem IIfcCoordinateOperation.TargetCRS
	{
		get
		{
			return TargetCRS;
		}
		set
		{
			TargetCRS = value as IfcCoordinateReferenceSystem;
		}
	}

	[IndexedProperty]
	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 1)]
	public IfcCoordinateReferenceSystemSelect SourceCRS
	{
		get
		{
			if (_activated)
			{
				return _sourceCRS;
			}
			Activate();
			return _sourceCRS;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCoordinateReferenceSystemSelect v)
			{
				_sourceCRS = v;
			}, _sourceCRS, value, "SourceCRS", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcCoordinateReferenceSystem TargetCRS
	{
		get
		{
			if (_activated)
			{
				return _targetCRS;
			}
			Activate();
			return _targetCRS;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCoordinateReferenceSystem v)
			{
				_targetCRS = v;
			}, _targetCRS, value, "TargetCRS", 2);
		}
	}

	internal IfcCoordinateOperation(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_sourceCRS = (IfcCoordinateReferenceSystemSelect)value.EntityVal;
			break;
		case 1:
			_targetCRS = (IfcCoordinateReferenceSystem)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCoordinateOperation other)
	{
		return this == other;
	}
}
