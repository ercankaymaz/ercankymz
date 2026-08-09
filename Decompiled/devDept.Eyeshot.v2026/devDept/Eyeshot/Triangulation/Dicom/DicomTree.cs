using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace devDept.Eyeshot.Triangulation.Dicom;

public class DicomTree
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<DicomElement> _0023_003DzJTAL7Ic_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly StringBuilder _0023_003DzqLXfrCw_003D = new StringBuilder();

	public List<DicomElement> Tree => _0023_003DzJTAL7Ic_003D;

	public string Log => _0023_003DzqLXfrCw_003D.ToString();

	public DicomTree(string[] filePaths)
	{
		_0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA _0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA2 = new _0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA();
		foreach (string text in filePaths)
		{
			string text2 = string.Empty;
			try
			{
				text2 = Path.GetFileName(text);
				if (text2 == null)
				{
					continue;
				}
				if (text2.Equals(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902574), StringComparison.InvariantCultureIgnoreCase))
				{
					_0023_003DzqLXfrCw_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902558), text2));
					_0023_003DzqLXfrCw_003D.AppendLine();
					continue;
				}
				Iod iod = new Iod(text);
				if (iod.IsValid())
				{
					_0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA2._0023_003DzPJNpNF4_003D(iod);
					continue;
				}
				throw new NotSupportedException();
			}
			catch
			{
				_0023_003DzqLXfrCw_003D.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902774), text2));
				_0023_003DzqLXfrCw_003D.AppendLine();
			}
		}
		_0023_003DzDhITwvc_003D(_0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA2);
	}

	private void _0023_003DzDhITwvc_003D(_0023_003DzX8WS4WEk3uAlSViPAs8_0024IQWXGpfAi_oVA1fYFtvGx_tHcVtf_0024SYo6MKAHXoA _0023_003Dzs_FvIKXFEs46)
	{
		_0023_003DzJTAL7Ic_003D = new List<DicomElement>();
		foreach (string item2 in _0023_003Dzs_FvIKXFEs46._0023_003DzfRuFJGSHJLLXW8o9Cg_003D_003D())
		{
			DicomElement dicomElement = new DicomElement(item2, DicomElement.dicomNodeType.Patient);
			Tree.Add(dicomElement);
			foreach (string item3 in _0023_003Dzs_FvIKXFEs46._0023_003Dz4hrZLaRh2yd3(item2))
			{
				DicomElement dicomElement2 = new DicomElement(item3, DicomElement.dicomNodeType.SopClass, dicomElement);
				dicomElement.Elements.Add(dicomElement2);
				foreach (string item4 in _0023_003Dzs_FvIKXFEs46._0023_003DzQClqMpc8u6lm7GuYbA_003D_003D(item2, item3))
				{
					DicomElement dicomElement3 = new DicomElement(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902745), item4), DicomElement.dicomNodeType.Study, dicomElement2);
					dicomElement2.Elements.Add(dicomElement3);
					foreach (string item5 in _0023_003Dzs_FvIKXFEs46._0023_003Dz3MM2rh8_003D(item2, item3, item4))
					{
						DicomElement dicomElement4 = new DicomElement(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302902734), item5), DicomElement.dicomNodeType.Series, dicomElement3);
						dicomElement3.Elements.Add(dicomElement4);
						foreach (Iod item6 in _0023_003Dzs_FvIKXFEs46._0023_003Dzo7cirbTPuuoG(item2, item3, item4, item5))
						{
							IodElement item = new IodElement(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302937471), item6.SopInstanceUid), item6, dicomElement4);
							dicomElement4.Elements.Add(item);
						}
					}
				}
			}
		}
	}
}
