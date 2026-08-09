namespace Basler.Pylon;

public interface IStringParameter : IParameter
{
	void SetValue(string value);

	string GetValue();

	int GetMaxLength();
}
