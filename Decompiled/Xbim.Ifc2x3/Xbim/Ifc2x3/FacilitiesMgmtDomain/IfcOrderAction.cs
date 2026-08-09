using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.ProcessExtension;

namespace Xbim.Ifc2x3.FacilitiesMgmtDomain;

[ExpressType("IfcOrderAction", 591)]
public class IfcOrderAction : IfcTask, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcOrderAction>
{
	private IfcIdentifier _actionID;

	[EntityAttribute(11, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 19)]
	public IfcIdentifier ActionID
	{
		get
		{
			if (_activated)
			{
				return _actionID;
			}
			Activate();
			return _actionID;
		}
		set
		{
			SetValue(delegate(IfcIdentifier v)
			{
				_actionID = v;
			}, _actionID, value, "ActionID", 11);
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
		}
	}

	internal IfcOrderAction(IModel model, int label, bool activated)
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
		case 5:
		case 6:
		case 7:
		case 8:
		case 9:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 10:
			_actionID = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcOrderAction other)
	{
		return this == other;
	}
}
