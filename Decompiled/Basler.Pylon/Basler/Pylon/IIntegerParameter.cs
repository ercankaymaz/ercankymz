namespace Basler.Pylon;

public interface IIntegerParameter : IParameter
{
	void SetValue(long value);

	long GetValue();

	long GetMaximum();

	long GetMinimum();

	long GetIncrement();
}
