using System;
using System.Windows;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Interaction;

public abstract class PlacementAdapter : Adapter
{
	public override Type AdapterType => typeof(PlacementAdapter);

	public virtual void BeginPlacement(ModelItem item)
	{
	}

	public virtual void EndPlacement()
	{
	}

	public abstract bool CanSetPosition(PlacementIntent intent, RelativePosition position);

	public abstract RelativeValueCollection GetPlacement(ModelItem item, params RelativePosition[] positions);

	public abstract void SetPlacements(ModelItem item, PlacementIntent intent, params RelativeValue[] positions);

	public abstract void SetPlacements(ModelItem item, PlacementIntent intent, RelativeValueCollection placement);

	public virtual void SetNudgePlacements(ModelItem item, NudgeIntent intent, RelativeValueCollection placement)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (placement == null)
		{
			throw new ArgumentNullException("placement");
		}
		if (!EnumValidator.IsValid(intent))
		{
			throw new ArgumentOutOfRangeException("intent");
		}
		SetPlacements(item, PlacementIntent.Move, placement);
	}

	public virtual void SetNudgePlacements(ModelItem item, NudgeIntent intent, RelativeValue[] positions)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		if (positions == null)
		{
			throw new ArgumentNullException("positions");
		}
		if (!EnumValidator.IsValid(intent))
		{
			throw new ArgumentOutOfRangeException("intent");
		}
		SetPlacements(item, PlacementIntent.Move, positions);
	}

	public abstract Rect GetPlacementBoundary(ModelItem item);

	public abstract Rect GetPlacementBoundary(ModelItem item, PlacementIntent intent, params RelativeValue[] positions);
}
