using System;
using System.Windows;
using Xceed.Wpf.Toolkit.Media.Animation;

namespace Xceed.Wpf.Toolkit.Panels;

public class DoubleAnimator : IterativeAnimator
{
	private readonly IterativeEquation<double> _equation;

	public DoubleAnimator(IterativeEquation<double> equation)
	{
		_equation = equation;
	}

	public override Rect GetInitialChildPlacement(UIElement child, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, ref AnimationRate animationRate, out object placementArgs, out bool isDone)
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		isDone = (animationRate.HasSpeed && animationRate.Speed <= 0.0) || (animationRate.HasDuration && animationRate.Duration.Ticks == 0);
		if (!isDone)
		{
			Vector val = new Vector(((Rect)(ref currentPlacement)).Left + ((Rect)(ref currentPlacement)).Width / 2.0, ((Rect)(ref currentPlacement)).Top + ((Rect)(ref currentPlacement)).Height / 2.0);
			Vector val2 = default(Vector);
			((Vector)(ref val2))._002Ector(((Rect)(ref targetPlacement)).Left + ((Rect)(ref targetPlacement)).Width / 2.0, ((Rect)(ref targetPlacement)).Top + ((Rect)(ref targetPlacement)).Height / 2.0);
			Vector val3 = val - val2;
			animationRate = new AnimationRate(animationRate.HasDuration ? animationRate.Duration : TimeSpan.FromMilliseconds(((Vector)(ref val3)).Length / animationRate.Speed));
		}
		placementArgs = currentPlacement;
		return currentPlacement;
	}

	public override Rect GetNextChildPlacement(UIElement child, TimeSpan currentTime, Rect currentPlacement, Rect targetPlacement, AnimationPanel activeLayout, AnimationRate animationRate, ref object placementArgs, out bool isDone)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Rect result = targetPlacement;
		isDone = true;
		if (_equation != null)
		{
			Rect val = (Rect)placementArgs;
			TimeSpan duration = animationRate.Duration;
			isDone = currentTime >= duration;
			if (!isDone)
			{
				double num = _equation.Evaluate(currentTime, ((Rect)(ref val)).Left, ((Rect)(ref targetPlacement)).Left, duration);
				double num2 = _equation.Evaluate(currentTime, ((Rect)(ref val)).Top, ((Rect)(ref targetPlacement)).Top, duration);
				double num3 = Math.Max(0.0, _equation.Evaluate(currentTime, ((Rect)(ref val)).Width, ((Rect)(ref targetPlacement)).Width, duration));
				double num4 = Math.Max(0.0, _equation.Evaluate(currentTime, ((Rect)(ref val)).Height, ((Rect)(ref targetPlacement)).Height, duration));
				((Rect)(ref result))._002Ector(num, num2, num3, num4);
			}
		}
		return result;
	}
}
