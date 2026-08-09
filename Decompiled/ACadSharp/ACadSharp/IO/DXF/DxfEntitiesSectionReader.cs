using System;
using ACadSharp.IO.Templates;

namespace ACadSharp.IO.DXF;

internal class DxfEntitiesSectionReader : DxfSectionReaderBase
{
	public DxfEntitiesSectionReader(IDxfStreamReader reader, DxfDocumentBuilder builder)
		: base(reader, builder)
	{
	}

	public override void Read()
	{
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			CadEntityTemplate cadEntityTemplate = null;
			try
			{
				cadEntityTemplate = readEntity();
			}
			catch (Exception exception)
			{
				if (!_builder.Configuration.Failsafe)
				{
					throw;
				}
				_builder.Notify($"Error while reading an entity at line {_reader.Position}", NotificationType.Error, exception);
				while (_reader.DxfCode != DxfCode.Start)
				{
					_reader.ReadNext();
				}
			}
			if (cadEntityTemplate != null)
			{
				_builder.AddTemplate(cadEntityTemplate);
				ICadOwnerTemplate value;
				if (!cadEntityTemplate.OwnerHandle.HasValue)
				{
					_builder.ModelSpaceEntities.Add(cadEntityTemplate.CadObject);
				}
				else if (_builder.TryGetObjectTemplate<ICadOwnerTemplate>(cadEntityTemplate.OwnerHandle, out value))
				{
					value.OwnedObjectsHandlers.Add(cadEntityTemplate.CadObject.Handle);
				}
				else
				{
					_builder.OrphanTemplates.Add(cadEntityTemplate);
				}
			}
		}
	}
}
