using System;

namespace Aladdin.HASP;

[Serializable]
public struct HaspFeature : IComparable<HaspFeature>
{
	private int feature;

	public static HaspFeature Default => new HaspFeature(FeatureType.Default);

	public static HaspFeature ProgNumDefault => new HaspFeature(FeatureType.ProgNumDefault);

	public int Feature => feature;

	public int FeatureId => IsProgNum ? (feature & -65281) : feature;

	public bool IsDefault => FeatureId == (IsProgNum ? (-65536) : 0);

	public bool IsProgNum => (feature & -65536) == -65536;

	public FeatureOptions Options => IsProgNum ? ((FeatureOptions)(feature & 0xFF00)) : FeatureOptions.Default;

	public HaspFeature(int feature)
	{
		this.feature = feature;
	}

	public HaspFeature(FeatureType feature)
	{
		this.feature = (int)feature;
	}

	public int CompareTo(HaspFeature other)
	{
		return feature.CompareTo(other.feature);
	}

	public static bool operator ==(HaspFeature left, HaspFeature right)
	{
		return left.CompareTo(right) == 0;
	}

	public static bool operator !=(HaspFeature left, HaspFeature right)
	{
		return !(left == right);
	}

	public override bool Equals(object obj)
	{
		return this == (HaspFeature)obj;
	}

	public override int GetHashCode()
	{
		return feature;
	}

	public static HaspFeature FromFeature(int feature)
	{
		return new HaspFeature(feature & 0xFFFFF);
	}

	public static HaspFeature FromProgNum(int number)
	{
		number &= 0xFF;
		return new HaspFeature(number | -65536);
	}

	public bool HasOption(FeatureOptions option)
	{
		if (IsProgNum)
		{
			return option == FeatureOptions.Default;
		}
		int num = feature & 0xFF00;
		if (option == FeatureOptions.Default)
		{
			return num == 0;
		}
		return option == FeatureOptions.Default;
	}

	public bool SetOptions(FeatureOptions add, FeatureOptions remove)
	{
		if (!IsProgNum)
		{
			return false;
		}
		if ((add & FeatureOptions.NotRemote) == FeatureOptions.NotRemote)
		{
			add &= ~FeatureOptions.NotLocal;
			remove |= FeatureOptions.NotLocal;
		}
		if ((add & FeatureOptions.NotLocal) == FeatureOptions.NotLocal)
		{
			add &= ~FeatureOptions.NotRemote;
			remove |= FeatureOptions.NotRemote;
		}
		feature |= (int)(add & (FeatureOptions)65280);
		feature &= (int)(~(remove & (FeatureOptions)65280));
		return true;
	}

	public override string ToString()
	{
		return feature.ToString();
	}
}
