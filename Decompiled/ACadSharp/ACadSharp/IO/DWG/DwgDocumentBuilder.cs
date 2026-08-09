using System.Collections.Generic;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;

namespace ACadSharp.IO.DWG;

internal class DwgDocumentBuilder : CadDocumentBuilder
{
	public DwgReaderConfiguration Configuration { get; }

	public DwgHeaderHandlesCollection HeaderHandles { get; set; } = new DwgHeaderHandlesCollection();

	public List<CadBlockRecordTemplate> BlockRecordTemplates { get; set; } = new List<CadBlockRecordTemplate>();

	public List<Entity> PaperSpaceEntities { get; } = new List<Entity>();

	public List<Entity> ModelSpaceEntities { get; } = new List<Entity>();

	public override bool KeepUnknownEntities => Configuration.KeepUnknownEntities;

	public override bool KeepUnknownNonGraphicalObjects => Configuration.KeepUnknownNonGraphicalObjects;

	public DwgDocumentBuilder(ACadVersion version, CadDocument document, DwgReaderConfiguration configuration)
		: base(version, document)
	{
		Configuration = configuration;
	}

	public override void BuildDocument()
	{
		createMissingHandles();
		foreach (CadBlockRecordTemplate blockRecordTemplate in BlockRecordTemplates)
		{
			blockRecordTemplate.SetBlockToRecord(this, HeaderHandles);
		}
		RegisterTables();
		BuildTables();
		buildDictionaries();
		base.BuildDocument();
		HeaderHandles.UpdateHeader(base.DocumentToBuild.Header, this);
	}
}
