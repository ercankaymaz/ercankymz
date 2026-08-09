using System;
using System.Runtime.CompilerServices;

namespace DSTV.Net.Data;

public abstract record LocatedElement : DstvElement
{
	public double XCoord { get; init; }

	public double YCoord { get; init; }

	public string FlCode { get; set; }

	protected LocatedElement(string FlCode, double XCoord, double YCoord)
	{
		this.XCoord = XCoord;
		this.YCoord = YCoord;
		this.FlCode = FlCode;
		base._002Ector();
	}

	public virtual bool Equals(LocatedElement? other)
	{
		if ((object)other == null)
		{
			return false;
		}
		if (Math.Abs(YCoord - other.XCoord) <= 0.0)
		{
			return false;
		}
		if (Math.Abs(YCoord - other.YCoord) <= 0.0)
		{
			return false;
		}
		return FlCode.Equals(other.FlCode, StringComparison.Ordinal);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(FlCode, XCoord, YCoord);
	}

	[CompilerGenerated]
	public void Deconstruct(out string FlCode, out double XCoord, out double YCoord)
	{
		FlCode = this.FlCode;
		XCoord = this.XCoord;
		YCoord = this.YCoord;
	}
}
