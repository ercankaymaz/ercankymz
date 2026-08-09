using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc2x3.Kernel;

namespace Xbim.Ifc2x3.FacilitiesMgmtDomain;

[ExpressType("IfcEquipmentStandard", 152)]
public class IfcEquipmentStandard : IfcControl, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcEquipmentStandard>
{
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

	internal IfcEquipmentStandard(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		if ((uint)propIndex <= 4u)
		{
			base.Parse(propIndex, value, nestedIndex);
			return;
		}
		throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
	}

	public bool Equals(IfcEquipmentStandard other)
	{
		return this == other;
	}
}
