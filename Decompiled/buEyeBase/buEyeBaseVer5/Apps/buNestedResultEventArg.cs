using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using buClass;

namespace buEyeBaseVer5.Apps;

public class buNestedResultEventArg
{
	public nestResultCreatMode Mode = nestResultCreatMode.Selected;

	public nestedCreateType ResultCreateType = nestedCreateType.Draw;

	public nestedCreateSheetType ResultSheetType = nestedCreateSheetType.All;

	public int SelectedResult = -1;

	public int SelectedSheet = -1;

	public bool DoCam = false;

	public bool PdfFile = false;

	public bool CsvFile = false;

	public string FullFileName = Application.StartupPath;

	public string JustFileName = Application.StartupPath;

	public string JustFolderName = Application.StartupPath;

	public int ImageWidth = 0;

	public int ImageHeight = 0;

	public Image ImageResult = null;

	public List<Image> ImageSheets = null;

	public buNestedResult nestedResult = null;

	public buNestedSheet nestedSheet = null;

	public buNestingResultSettings ResultSettings = null;

	public override string ToString()
	{
		return "Mode : " + Mode;
	}
}
