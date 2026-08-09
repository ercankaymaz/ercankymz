using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MeasureResource;

public static class UnitExtensions
{
	private class RegionInfoComparer : IEqualityComparer<RegionInfo>
	{
		public bool Equals(RegionInfo x, RegionInfo y)
		{
			return x.ISOCurrencySymbol == y.ISOCurrencySymbol;
		}

		public int GetHashCode(RegionInfo obj)
		{
			return obj.ISOCurrencySymbol.GetHashCode();
		}
	}

	private static string[] commonCurrencyCultures = new string[24]
	{
		"en-GB", "fr-FR", "en-US", "en-CA", "en-AU", "en-NZ", "en-ZA", "da-DK", "nn-NO", "sv-SE",
		"fr-CH", "es-MX", "pt-BR", "pl-PL", "cs-CZ", "ar-SA", "ar-QA", "ar-AE", "ja-JP", "hi-IN",
		"ur-PK", "ko-KR", "zh-CN", "ru-RU"
	};

	private static IEnumerable<CultureInfo> prioritisedCultures = (from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
		where commonCurrencyCultures.Any((string i) => c.Name == i)
		select c).Union(from c in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
		where !commonCurrencyCultures.Any((string i) => c.Name == i)
		select c);

	private static Lazy<IDictionary<string, RegionInfo>> LazyCurrencyMap = new Lazy<IDictionary<string, RegionInfo>>(() => prioritisedCultures.Select((CultureInfo c) => new RegionInfo(c.Name)).Distinct(new RegionInfoComparer()).ToDictionary((RegionInfo r) => r.ISOCurrencySymbol, (RegionInfo r) => r));

	private static IDictionary<string, RegionInfo> CurrencyMap => LazyCurrencyMap.Value;

	public static string Name(this IIfcUnit ifcUnit)
	{
		if (!(ifcUnit is IIfcDerivedUnit { FullName: var fullName }))
		{
			if (!(ifcUnit is IIfcNamedUnit { FullName: var fullName2 }))
			{
				if (ifcUnit is IIfcMonetaryUnit obj)
				{
					return obj.FullEnglishName();
				}
				return string.Empty;
			}
			return fullName2;
		}
		return fullName;
	}

	public static string Symbol(this IIfcUnit ifcUnit)
	{
		if (!(ifcUnit is IIfcDerivedUnit { FullName: var fullName }))
		{
			if (!(ifcUnit is IIfcNamedUnit { Symbol: var symbol }))
			{
				if (ifcUnit is IIfcMonetaryUnit obj)
				{
					return obj.Symbol();
				}
				return string.Empty;
			}
			return symbol;
		}
		return fullName;
	}

	public static string Symbol(this IIfcMonetaryUnit obj)
	{
		if (!CurrencyMap.ContainsKey(obj.Currency))
		{
			return obj.Currency.ToString();
		}
		return CurrencyMap[obj.Currency].CurrencySymbol;
	}

	public static string FullEnglishName(this IIfcMonetaryUnit obj)
	{
		if (!CurrencyMap.ContainsKey(obj.Currency))
		{
			return obj.Currency.ToString();
		}
		return CurrencyMap[obj.Currency].CurrencyEnglishName;
	}

	public static string FullNativeName(this IIfcMonetaryUnit obj)
	{
		if (!CurrencyMap.ContainsKey(obj.Currency))
		{
			return obj.Currency.ToString();
		}
		return CurrencyMap[obj.Currency].CurrencyNativeName;
	}
}
