namespace Basler.Pylon;

public interface IFloatParameter : IParameter
{
	void SetValue(double value);

	double GetValue();

	double GetMaximum();

	double GetMinimum();

	double? GetIncrement();
}
