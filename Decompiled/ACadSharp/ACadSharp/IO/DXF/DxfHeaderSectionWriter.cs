using System.Collections.Generic;
using System.Linq;
using ACadSharp.Header;

namespace ACadSharp.IO.DXF;

internal class DxfHeaderSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "HEADER";

	public CadHeader Header => _document.Header;

	public DxfHeaderSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder holder, DxfWriterConfiguration configuration)
		: base(writer, document, holder, configuration)
	{
	}

	protected override void writeSection()
	{
		foreach (KeyValuePair<string, CadSystemVariable> item in CadHeader.GetHeaderMap())
		{
			if ((!base.Configuration.WriteAllHeaderVariables && !base.Configuration.HeaderVariables.Contains(item.Key)) || item.Value.ReferenceType.HasFlag(DxfReferenceType.Ignored) || item.Value.GetValue(Header) == null)
			{
				continue;
			}
			_writer.Write(DxfCode.CLShapeText, item.Key);
			if (item.Key == "$HANDSEED")
			{
				_writer.Write(DxfCode.Handle, _document.Header.HandleSeed);
				continue;
			}
			if (item.Key == "$CECOLOR")
			{
				_writer.Write(62, _document.Header.CurrentEntityColor.GetApproxIndex());
				continue;
			}
			int[] dxfCodes = item.Value.DxfCodes;
			foreach (int code in dxfCodes)
			{
				object systemValue = item.Value.GetSystemValue(code, _document.Header);
				if (systemValue != null)
				{
					_writer.Write((DxfCode)code, systemValue);
				}
			}
		}
	}
}
