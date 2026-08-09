namespace devDept.Eyeshot;

public interface IDisplayModeSettings
{
	bool ShowEdges { get; }

	bool ShowInternalWires { get; }

	edgeColorMethodType EdgeColorMethod { get; }
}
