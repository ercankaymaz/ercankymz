using System.Text;
using Xbim.Ifc2x3.CostResource;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc;

public static class IIfcAppliedValueExtensions
{
	public static string AsString(this IIfcAppliedValue obj)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (obj.Description.HasValue)
		{
			Xbim.Ifc4.MeasureResource.IfcText? description = obj.Description;
			if (!string.IsNullOrEmpty(description.HasValue ? ((string)description.GetValueOrDefault()) : null))
			{
				description = obj.Description;
				stringBuilder.Append(description.HasValue ? ((string)description.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		if (obj.AppliedValue != null)
		{
			stringBuilder.Append("AppliedValue: ");
			if (obj.AppliedValue is Xbim.Ifc4.MeasureResource.IfcRatioMeasure)
			{
				stringBuilder.Append($"{((Xbim.Ifc4.MeasureResource.IfcRatioMeasure)(object)obj.AppliedValue).Value:N2}");
			}
			if (obj.AppliedValue is Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)
			{
				stringBuilder.Append($"{((Xbim.Ifc4.MeasureResource.IfcMonetaryMeasure)(object)obj.AppliedValue).Value:N2}");
			}
			if (obj.AppliedValue is Xbim.Ifc4.MeasureResource.IfcMeasureWithUnit)
			{
				stringBuilder.Append(((Xbim.Ifc4.MeasureResource.IfcMeasureWithUnit)obj.AppliedValue).AsString());
			}
			stringBuilder.Append(", ");
		}
		if (obj.UnitBasis != null)
		{
			stringBuilder.Append("UnitBase: ");
			stringBuilder.Append(((Xbim.Ifc4.MeasureResource.IfcMeasureWithUnit)obj.UnitBasis).AsString());
			stringBuilder.Append(", ");
		}
		if (obj.ApplicableDate.HasValue)
		{
			stringBuilder.Append("ApplicableDate: ");
			stringBuilder.Append(obj.ApplicableDate.ToString());
			stringBuilder.Append(", ");
		}
		if (obj.FixedUntilDate.HasValue)
		{
			stringBuilder.Append("FixedUntilDate: ");
			stringBuilder.Append(obj.FixedUntilDate.ToString());
			stringBuilder.Append(", ");
		}
		if (obj is IIfcCostValue)
		{
			IIfcCostValue ifcCostValue = (IIfcCostValue)obj;
			if (ifcCostValue.Category.HasValue)
			{
				stringBuilder.Append("CostType: ");
				Xbim.Ifc4.MeasureResource.IfcLabel? category = ifcCostValue.Category;
				stringBuilder.Append(category.HasValue ? ((string)category.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
			if (ifcCostValue.Condition.HasValue)
			{
				stringBuilder.Append("Condition: ");
				Xbim.Ifc4.MeasureResource.IfcLabel? category = ifcCostValue.Condition;
				stringBuilder.Append(category.HasValue ? ((string)category.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		if (obj is IfcEnvironmentalImpactValue)
		{
			IfcEnvironmentalImpactValue ifcEnvironmentalImpactValue = (IfcEnvironmentalImpactValue)obj;
			if (ifcEnvironmentalImpactValue.ImpactType != null)
			{
				stringBuilder.Append("ImpactType: ");
				stringBuilder.Append(ifcEnvironmentalImpactValue.ImpactType);
				stringBuilder.Append(", ");
			}
			stringBuilder.Append("Category: ");
			stringBuilder.Append(ifcEnvironmentalImpactValue.Category.ToString());
			stringBuilder.Append(", ");
			if (ifcEnvironmentalImpactValue.UserDefinedCategory.HasValue)
			{
				stringBuilder.Append("UserDefinedCategory: ");
				Xbim.Ifc2x3.MeasureResource.IfcLabel? userDefinedCategory = ifcEnvironmentalImpactValue.UserDefinedCategory;
				stringBuilder.Append(userDefinedCategory.HasValue ? ((string)userDefinedCategory.GetValueOrDefault()) : null);
				stringBuilder.Append(", ");
			}
		}
		return stringBuilder.ToString();
	}
}
