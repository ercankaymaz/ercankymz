namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperOutRec
{
	public int Idx;

	public bool IsHole;

	public bool IsOpen;

	public ClipperOutRec FirstLeft;

	public ClipperOutPt Pts;

	public ClipperOutPt BottomPt;

	public ClipperPolyNode PolyNode;
}
