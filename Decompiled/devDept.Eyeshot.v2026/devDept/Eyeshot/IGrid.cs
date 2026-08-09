namespace devDept.Eyeshot;

internal interface IGrid
{
	GridSettings GetSettings();

	void ApplySettings(GridSettings settings);
}
