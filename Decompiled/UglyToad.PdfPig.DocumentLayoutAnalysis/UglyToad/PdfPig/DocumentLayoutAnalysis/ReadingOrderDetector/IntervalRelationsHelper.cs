using UglyToad.PdfPig.Core;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.ReadingOrderDetector;

public static class IntervalRelationsHelper
{
	public static IntervalRelations GetRelationX(PdfRectangle a, PdfRectangle b, double T)
	{
		if (b.Left - T <= a.Left && a.Left <= b.Left + T && b.Right - T <= a.Right && a.Right <= b.Right + T)
		{
			return IntervalRelations.Equals;
		}
		if (b.Left - T <= a.Right && a.Right <= b.Left + T)
		{
			return IntervalRelations.Meets;
		}
		if (a.Left - T <= b.Right && b.Right <= a.Left + T)
		{
			return IntervalRelations.MeetsI;
		}
		if (b.Left - T <= a.Left && a.Left <= b.Left + T && a.Right < b.Right - T)
		{
			return IntervalRelations.Starts;
		}
		if (a.Left - T <= b.Left && b.Left <= a.Left + T && b.Right < a.Right - T)
		{
			return IntervalRelations.StartsI;
		}
		if (a.Left > b.Left + T && b.Right - T <= a.Right && a.Right <= b.Right + T)
		{
			return IntervalRelations.Finishes;
		}
		if (b.Left > a.Left + T && a.Right - T <= b.Right && b.Right <= a.Right + T)
		{
			return IntervalRelations.FinishesI;
		}
		if (a.Left > b.Left + T && a.Right < b.Right - T)
		{
			return IntervalRelations.During;
		}
		if (b.Left > a.Left + T && b.Right < a.Right - T)
		{
			return IntervalRelations.DuringI;
		}
		if (a.Left < b.Left - T && b.Left + T < a.Right && a.Right < b.Right - T)
		{
			return IntervalRelations.Overlaps;
		}
		if (b.Left < a.Left - T && a.Left + T < b.Right && b.Right < a.Right - T)
		{
			return IntervalRelations.OverlapsI;
		}
		if (a.Right < b.Left - T)
		{
			return IntervalRelations.Precedes;
		}
		if (b.Right < a.Left - T)
		{
			return IntervalRelations.PrecedesI;
		}
		return IntervalRelations.Unknown;
	}

	public static IntervalRelations GetRelationY(PdfRectangle a, PdfRectangle b, double T)
	{
		if (b.Top - T <= a.Top && a.Top <= b.Top + T && b.Bottom - T <= a.Bottom && a.Bottom <= b.Bottom + T)
		{
			return IntervalRelations.Equals;
		}
		if (a.Top - T <= b.Bottom && b.Bottom <= a.Top + T)
		{
			return IntervalRelations.MeetsI;
		}
		if (b.Top - T <= a.Bottom && a.Bottom <= b.Top + T)
		{
			return IntervalRelations.Meets;
		}
		if (b.Top - T <= a.Top && a.Top <= b.Top + T && a.Bottom < b.Bottom - T)
		{
			return IntervalRelations.StartsI;
		}
		if (a.Top - T <= b.Top && b.Top <= a.Top + T && b.Bottom < a.Bottom - T)
		{
			return IntervalRelations.Starts;
		}
		if (a.Top > b.Top + T && b.Bottom - T <= a.Bottom && a.Bottom <= b.Bottom + T)
		{
			return IntervalRelations.FinishesI;
		}
		if (b.Top > a.Top + T && a.Bottom - T <= b.Bottom && b.Bottom <= a.Bottom + T)
		{
			return IntervalRelations.Finishes;
		}
		if (a.Top > b.Top + T && a.Bottom < b.Bottom - T)
		{
			return IntervalRelations.DuringI;
		}
		if (b.Top > a.Top + T && b.Bottom < a.Bottom - T)
		{
			return IntervalRelations.During;
		}
		if (a.Top < b.Top - T && b.Bottom + T < a.Top && a.Bottom < b.Bottom - T)
		{
			return IntervalRelations.OverlapsI;
		}
		if (b.Top < a.Top - T && a.Bottom + T < b.Top && b.Bottom < a.Bottom - T)
		{
			return IntervalRelations.Overlaps;
		}
		if (a.Bottom < b.Top - T)
		{
			return IntervalRelations.PrecedesI;
		}
		if (b.Bottom < a.Top - T)
		{
			return IntervalRelations.Precedes;
		}
		return IntervalRelations.Unknown;
	}
}
