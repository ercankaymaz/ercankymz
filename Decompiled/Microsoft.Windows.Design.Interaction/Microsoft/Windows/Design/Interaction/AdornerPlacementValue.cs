using System;

namespace Microsoft.Windows.Design.Interaction;

public struct AdornerPlacementValue
{
	private AdornerPlacementDimension _term;

	private double _contribution;

	public AdornerPlacementDimension Term
	{
		get
		{
			return _term;
		}
		set
		{
			if (!EnumValidator.IsValid(value))
			{
				throw new ArgumentOutOfRangeException("value");
			}
			_term = value;
		}
	}

	public double Contribution
	{
		get
		{
			return _contribution;
		}
		set
		{
			_contribution = value;
		}
	}

	public AdornerPlacementValue(AdornerPlacementDimension term, double contribution)
	{
		if (!EnumValidator.IsValid(term))
		{
			throw new ArgumentOutOfRangeException("term");
		}
		_term = term;
		_contribution = contribution;
	}

	public override bool Equals(object obj)
	{
		if (obj is AdornerPlacementValue)
		{
			return Equals((AdornerPlacementValue)obj);
		}
		return false;
	}

	public bool Equals(AdornerPlacementValue value)
	{
		if (Term == value.Term)
		{
			return Contribution == value.Contribution;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Term.GetHashCode() ^ Contribution.GetHashCode();
	}

	public static bool operator ==(AdornerPlacementValue placementValue1, AdornerPlacementValue placementValue2)
	{
		if (placementValue1.Term == placementValue2.Term)
		{
			return placementValue1.Contribution == placementValue2.Contribution;
		}
		return false;
	}

	public static bool operator !=(AdornerPlacementValue placementValue1, AdornerPlacementValue placementValue2)
	{
		if (placementValue1.Term == placementValue2.Term)
		{
			return placementValue1.Contribution != placementValue2.Contribution;
		}
		return true;
	}
}
