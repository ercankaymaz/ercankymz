namespace SixLabors.ImageSharp.Formats.Webp.Lossy;

internal class PassStats
{
	public bool IsFirst { get; set; }

	public float Dq { get; set; }

	public float Q { get; set; }

	public float LastQ { get; set; }

	public float Qmin { get; }

	public float Qmax { get; }

	public double Value { get; set; }

	public double LastValue { get; set; }

	public double Target { get; }

	public bool DoSizeSearch { get; }

	public PassStats(long targetSize, float targetPsnr, int qMin, int qMax, uint quality)
	{
		bool flag = targetSize != 0;
		IsFirst = true;
		Dq = 10f;
		Qmin = qMin;
		Qmax = qMax;
		Q = Numerics.Clamp((float)quality, (float)qMin, (float)qMax);
		LastQ = Q;
		Target = (flag ? ((float)targetSize) : ((targetPsnr > 0f) ? targetPsnr : 40f));
		Value = 0.0;
		LastValue = 0.0;
		DoSizeSearch = flag;
	}

	public float ComputeNextQ()
	{
		float value;
		if (!IsFirst)
		{
			value = ((Value == LastValue) ? 0f : ((float)((Target - Value) / (LastValue - Value) * (double)(LastQ - Q))));
		}
		else
		{
			value = ((Value > Target) ? (0f - Dq) : Dq);
			IsFirst = false;
		}
		Dq = Numerics.Clamp(value, -30f, 30f);
		LastQ = Q;
		LastValue = Value;
		Q = Numerics.Clamp(Q + Dq, Qmin, Qmax);
		return Q;
	}
}
