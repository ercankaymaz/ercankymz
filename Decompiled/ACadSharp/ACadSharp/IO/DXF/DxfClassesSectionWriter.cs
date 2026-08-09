using ACadSharp.Classes;

namespace ACadSharp.IO.DXF;

internal class DxfClassesSectionWriter : DxfSectionWriterBase
{
	public override string SectionName => "CLASSES";

	public DxfClassesSectionWriter(IDxfStreamWriter writer, CadDocument document, CadObjectHolder objectHolder, DxfWriterConfiguration configuration)
		: base(writer, document, objectHolder, configuration)
	{
	}

	protected override void writeSection()
	{
		foreach (DxfClass @class in _document.Classes)
		{
			_writer.Write(0, "CLASS");
			_writer.Write(1, @class.DxfName);
			_writer.Write(2, @class.CppClassName);
			_writer.Write(3, @class.ApplicationName);
			_writer.Write(90, (int)@class.ProxyFlags);
			_writer.Write(91, @class.InstanceCount);
			_writer.Write(280, @class.WasZombie);
			_writer.Write(281, @class.IsAnEntity);
		}
	}
}
