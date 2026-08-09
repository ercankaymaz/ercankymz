using UglyToad.PdfPig.Content;

namespace UglyToad.PdfPig.Rendering;

public interface IPageImageRenderer
{
	byte[] Render(Page page, double scale, PdfRendererImageFormat imageFormat);
}
