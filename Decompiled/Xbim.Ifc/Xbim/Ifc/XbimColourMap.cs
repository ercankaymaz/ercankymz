using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc;

public class XbimColourMap : KeyedCollection<string, XbimColour>
{
	public bool IsTransparent => this.Any((XbimColour c) => c.IsTransparent);

	public new XbimColour this[string key]
	{
		get
		{
			if (Contains(key))
			{
				return base[key];
			}
			if (Contains("Default"))
			{
				return base["Default"];
			}
			return XbimColour.DefaultColour;
		}
	}

	public override int GetHashCode()
	{
		int num = 0;
		using IEnumerator<XbimColour> enumerator = GetEnumerator();
		while (enumerator.MoveNext())
		{
			XbimColour current = enumerator.Current;
			num ^= current.GetHashCode();
		}
		return num;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is XbimColourMap xbimColourMap))
		{
			return false;
		}
		if (xbimColourMap.Count != base.Count)
		{
			return false;
		}
		foreach (XbimColour item in xbimColourMap)
		{
			if (!Contains(item))
			{
				return false;
			}
			if (!item.Equals(this[item.Name]))
			{
				return false;
			}
		}
		return true;
	}

	protected override string GetKeyForItem(XbimColour item)
	{
		return item.Name;
	}

	public XbimColourMap(StandardColourMaps initMap = StandardColourMaps.IfcProductTypeMap)
	{
		switch (initMap)
		{
		case StandardColourMaps.IfcProductTypeMap:
			SetProductTypeColourMap();
			break;
		case StandardColourMaps.Federation:
			SetFederationRoleColourMap();
			break;
		}
	}

	public void SetFederationRoleColourMap()
	{
		Clear();
		Add(new XbimColour("Default", 0.98, 0.92, 0.74));
		Add(new XbimColour(IfcRoleEnum.ARCHITECT.ToString(), 1.0, 1.0, 1.0, 0.5));
		Add(new XbimColour(IfcRoleEnum.MECHANICALENGINEER.ToString(), 1.0, 0.5, 0.25));
		Add(new XbimColour(IfcRoleEnum.ELECTRICALENGINEER.ToString(), 0.0, 0.0, 1.0));
		Add(new XbimColour(IfcRoleEnum.STRUCTURALENGINEER.ToString(), 0.2, 0.2, 0.2));
		double num = 0.0;
		Add(XbimColour.FromHSV(IfcRoleEnum.BUILDINGOPERATOR.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.BUILDINGOWNER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.CIVILENGINEER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.CLIENT.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.COMMISSIONINGENGINEER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.CONSTRUCTIONMANAGER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.CONSULTANT.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.CONTRACTOR.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.COSTENGINEER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.ENGINEER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.FACILITIESMANAGER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.FIELDCONSTRUCTIONMANAGER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.MANUFACTURER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.OWNER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.PROJECTMANAGER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.RESELLER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.SUBCONTRACTOR.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.SUPPLIER.ToString(), num += 15.0, 1.0, 1.0));
		Add(XbimColour.FromHSV(IfcRoleEnum.USERDEFINED.ToString(), num + 15.0, 1.0, 1.0));
	}

	public void SetProductTypeColourMap()
	{
		Clear();
		Add(new XbimColour("Default", 0.98, 0.92, 0.74));
		Add(new XbimColour("IfcWall", 0.98, 0.92, 0.74));
		Add(new XbimColour("IfcWallStandardCase", 0.98, 0.92, 0.74));
		Add(new XbimColour("IfcRoof", 0.28, 0.24, 0.55));
		Add(new XbimColour("IfcBeam", 0.0, 0.0, 0.55));
		Add(new XbimColour("IfcBuildingElementProxy", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcColumn", 0.0, 0.0, 0.55));
		Add(new XbimColour("IfcSlab", 0.47, 0.53, 0.6));
		Add(new XbimColour("IfcWindow", 0.68, 0.85, 0.9, 0.5));
		Add(new XbimColour("IfcCurtainWall", 0.68, 0.85, 0.9, 0.4));
		Add(new XbimColour("IfcPlate", 0.68, 0.85, 0.9, 0.4));
		Add(new XbimColour("IfcDoor", 0.97, 0.19, 0.0));
		Add(new XbimColour("IfcSpace", 0.68, 0.85, 0.9, 0.4));
		Add(new XbimColour("IfcMember", 0.34, 0.34, 0.34));
		Add(new XbimColour("IfcDistributionElement", 0.0, 0.0, 0.55));
		Add(new XbimColour("IfcFurnishingElement", 1f, 0f, 0f));
		Add(new XbimColour("IfcOpeningElement", 0.2, 0.2, 0.8, 0.2));
		Add(new XbimColour("IfcFeatureElementSubtraction", 1.0, 1.0, 1.0));
		Add(new XbimColour("IfcFlowTerminal", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcFlowSegment", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcDistributionFlowElement", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcFlowFitting", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcRailing", 0.95, 0.94, 0.74));
		Add(new XbimColour("IfcGrid", 1.0, 0.9, 0.0));
	}
}
