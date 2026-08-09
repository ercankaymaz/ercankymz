namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperTEdge
{
	internal ClipperIntPoint Bot;

	internal ClipperIntPoint Curr;

	internal ClipperIntPoint Top;

	internal ClipperIntPoint Delta;

	internal double Dx;

	internal ClipperPolyType PolyTyp;

	internal ClipperEdgeSide Side;

	internal int WindDelta;

	internal int WindCnt;

	internal int WindCnt2;

	internal int OutIdx;

	internal ClipperTEdge Next;

	internal ClipperTEdge Prev;

	internal ClipperTEdge NextInLML;

	internal ClipperTEdge NextInAEL;

	internal ClipperTEdge PrevInAEL;

	internal ClipperTEdge NextInSEL;

	internal ClipperTEdge PrevInSEL;
}
