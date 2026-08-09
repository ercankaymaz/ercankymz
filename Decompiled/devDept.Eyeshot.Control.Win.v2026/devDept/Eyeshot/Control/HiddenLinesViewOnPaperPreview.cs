using System;
using System.Drawing;
using System.Windows.Forms;

namespace devDept.Eyeshot.Control;

public class HiddenLinesViewOnPaperPreview : HiddenLinesViewOnPaper
{
	public Size PrintPreviewDlgClientSize;

	public HiddenLinesViewOnPaperPreview(HiddenLinesViewSettingsEx viewSettings, Size printPreviewDlgClientSize)
		: this(viewSettings, printPreviewDlgClientSize, 0.0)
	{
	}

	public HiddenLinesViewOnPaperPreview(HiddenLinesViewSettingsEx viewSettings, Size printPreviewDlgClientSize, double orthographicScale)
		: this(viewSettings, printPreviewDlgClientSize, orthographicScale, default(RectangleF))
	{
		PrintPreviewDlgClientSize = printPreviewDlgClientSize;
	}

	public HiddenLinesViewOnPaperPreview(HiddenLinesViewSettingsEx viewSettings, Size printPreviewDlgClientSize, double orthographicScale, RectangleF printRect)
		: base(viewSettings, orthographicScale, printRect)
	{
		PrintPreviewDlgClientSize = printPreviewDlgClientSize;
	}

	public override void WorkCompleted(object sender)
	{
		Workspace workspace = (Workspace)HdlViewSettings.document.workspace;
		workspace._0023_003DzbdLgm9c_003D._0023_003DzrDcpsS8_003D.Add(new Workspace._0023_003DzEmdG9Ls_003D(this, workspace));
		if (!workspace._0023_003DzbdLgm9c_003D._0023_003DzA3ipzoQ5sbsK)
		{
			return;
		}
		PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
		if (HdlViewSettings != null)
		{
			printPreviewDialog.ClientSize = PrintPreviewDlgClientSize;
		}
		printPreviewDialog.Document = workspace._0023_003DzbdLgm9c_003D;
		try
		{
			workspace._0023_003DzbdLgm9c_003D._0023_003Dzuw7Bx3c_003D = 0;
			workspace._0023_003DzbdLgm9c_003D._0023_003Dz7IlramNpWwjN = true;
			printPreviewDialog.ShowDialog();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			workspace._0023_003DzbdLgm9c_003D._0023_003Dz7IlramNpWwjN = false;
			workspace._0023_003DzbdLgm9c_003D.hKxLbCvKjVpI4dvqv3tjvDsUbXA();
		}
	}
}
