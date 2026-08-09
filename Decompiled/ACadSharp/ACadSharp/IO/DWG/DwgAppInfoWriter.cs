using System.IO;
using System.Reflection;
using System.Text;

namespace ACadSharp.IO.DWG;

internal class DwgAppInfoWriter : DwgSectionIO
{
	private IDwgStreamWriter _writer;

	private byte[] _emptyArr = new byte[16];

	public override string SectionName => "AcDb:AppInfo";

	public DwgAppInfoWriter(ACadVersion version, Stream stream)
		: base(version)
	{
		_writer = DwgStreamWriterBase.GetStreamWriter(version, stream, Encoding.Unicode);
	}

	public void Write()
	{
		string text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
		_writer.WriteInt(3);
		_writer.WriteTextUnicode("AppInfoDataList");
		_writer.WriteInt(3);
		_writer.WriteBytes(_emptyArr);
		_writer.WriteTextUnicode(text);
		_writer.WriteBytes(_emptyArr);
		_writer.WriteTextUnicode("This is a comment from ACadSharp");
		_writer.WriteBytes(_emptyArr);
		_writer.WriteTextUnicode("<ProductInformation name =\"ACadSharp\" build_version=\"" + text + "\" registry_version=\"" + text + "\" install_id_string=\"ACadSharp\" registry_localeID=\"1033\"/>");
	}
}
