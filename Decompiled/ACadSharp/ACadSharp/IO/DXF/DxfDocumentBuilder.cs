using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;
using ACadSharp.Objects;
using ACadSharp.Tables;

namespace ACadSharp.IO.DXF;

internal class DxfDocumentBuilder : CadDocumentBuilder
{
	public DxfReaderConfiguration Configuration { get; }

	public override bool KeepUnknownEntities => Configuration.KeepUnknownEntities;

	public override bool KeepUnknownNonGraphicalObjects => Configuration.KeepUnknownNonGraphicalObjects;

	public HashSet<Entity> ModelSpaceEntities { get; } = new HashSet<Entity>();

	public CadBlockRecordTemplate ModelSpaceTemplate { get; set; }

	public List<CadTemplate> OrphanTemplates { get; set; } = new List<CadTemplate>();

	public DxfDocumentBuilder(ACadVersion version, CadDocument document, DxfReaderConfiguration configuration)
		: base(version, document)
	{
		Configuration = configuration;
	}

	public override void BuildDocument()
	{
		if (ModelSpaceTemplate == null)
		{
			BlockRecord modelSpace = BlockRecord.ModelSpace;
			base.BlockRecords.Add(modelSpace);
			ModelSpaceTemplate = new CadBlockRecordTemplate(modelSpace);
			AddTemplate(ModelSpaceTemplate);
		}
		createMissingHandles();
		ModelSpaceTemplate.OwnedObjectsHandlers.UnionWith(ModelSpaceEntities.Select((Entity o) => o.Handle));
		RegisterTables();
		BuildTables();
		buildDictionaries();
		foreach (CadTemplate orphanTemplate in OrphanTemplates)
		{
			assignOwner(orphanTemplate);
		}
		base.BuildDocument();
		if (Configuration.CreateDefaults)
		{
			base.DocumentToBuild.CreateDefaults();
		}
	}

	public List<Entity> BuildEntities()
	{
		List<Entity> list = new List<Entity>();
		foreach (CadEntityTemplate item in cadObjectsTemplates.Values.OfType<CadEntityTemplate>())
		{
			item.Build(this);
			item.SetUnlinkedReferences();
		}
		foreach (CadEntityTemplate item2 in from o in cadObjectsTemplates.Values.OfType<CadEntityTemplate>()
			where o.CadObject.Owner == null
			select o)
		{
			item2.CadObject.Handle = 0uL;
			list.Add(item2.CadObject);
		}
		return list;
	}

	private void assignOwner(CadTemplate template)
	{
		if (template.CadObject.Owner != null || template.CadObject is CadDictionary || !template.OwnerHandle.HasValue)
		{
			return;
		}
		if (TryGetObjectTemplate<CadTemplate>(template.OwnerHandle, out var value))
		{
			CadTemplate cadTemplate = value;
			if (cadTemplate is CadDictionaryTemplate)
			{
				return;
			}
			if (!(cadTemplate is CadBlockRecordTemplate))
			{
				if (!(cadTemplate is CadPolyLineTemplate cadPolyLineTemplate))
				{
					if (cadTemplate is CadInsertTemplate cadInsertTemplate)
					{
						if (template.CadObject is AttributeEntity attributeEntity)
						{
							cadInsertTemplate.OwnedObjectsHandlers.Add(attributeEntity.Handle);
							return;
						}
						CadInsertTemplate cadInsertTemplate2 = cadInsertTemplate;
						if (template.CadObject is Seqend seqend)
						{
							cadInsertTemplate2.SeqendHandle = seqend.Handle;
							return;
						}
					}
				}
				else
				{
					if (template.CadObject is Vertex vertex)
					{
						cadPolyLineTemplate.OwnedObjectsHandlers.Add(vertex.Handle);
						return;
					}
					CadPolyLineTemplate cadPolyLineTemplate2 = cadPolyLineTemplate;
					if (template.CadObject is Seqend seqend2)
					{
						cadPolyLineTemplate2.SeqendHandle = seqend2.Handle;
						return;
					}
				}
			}
			else if (template.CadObject is Entity)
			{
				return;
			}
			Notify($"Owner {value.GetType().Name} with handle {template.OwnerHandle} assignation not implemented for {template.CadObject.GetType().Name} with handle {template.CadObject.Handle}", NotificationType.Warning);
		}
		else
		{
			Notify($"Owner {template.OwnerHandle} not found for {template.GetType().FullName} with handle {template.CadObject.Handle}", NotificationType.Warning);
		}
	}
}
