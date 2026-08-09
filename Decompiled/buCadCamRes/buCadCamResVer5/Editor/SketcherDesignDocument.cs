using devDept.Eyeshot;

namespace buCadCamResVer5.Editor;

public class SketcherDesignDocument : DesignDocument
{
	public override RegenParams GetVisualRefinement()
	{
		RegenParams visualRefinement = base.GetVisualRefinement();
		return new RegenParams(visualRefinement.Deviation / 10.0, visualRefinement.Angle);
	}
}
