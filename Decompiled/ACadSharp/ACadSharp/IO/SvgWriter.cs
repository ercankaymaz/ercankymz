using System.IO;
using System.Xml;
using ACadSharp.IO.SVG;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO;

public class SvgWriter : CadWriterBase<SvgConfiguration>
{
	private SvgXmlWriter _writer;

	public SvgWriter(Stream stream)
		: base(stream, (CadDocument)null)
	{
	}

	public SvgWriter(string filename)
		: this(File.Create(filename))
	{
	}

	public SvgWriter(string filename, CadDocument document)
		: this(File.Create(filename), document)
	{
	}

	public SvgWriter(Stream stream, CadDocument document)
		: base(stream, document)
	{
	}

	public override void Dispose()
	{
		_stream.Dispose();
	}

	public override void Write()
	{
		Write(_document.ModelSpace);
	}

	public void Write(BlockRecord record)
	{
		createWriter();
		_writer.WriteBlock(record);
	}

	public void Write(Layout layout)
	{
		createWriter();
		_writer.WriteLayout(layout);
	}

	private void createWriter()
	{
		new StreamWriter(_stream);
		_writer = new SvgXmlWriter(_stream, _encoding, base.Configuration);
		_writer.Formatting = Formatting.Indented;
		_writer.OnNotification += base.triggerNotification;
	}
}
