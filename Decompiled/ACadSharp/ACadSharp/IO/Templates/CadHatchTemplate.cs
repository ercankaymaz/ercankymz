using System.Collections.Generic;
using ACadSharp.Entities;

namespace ACadSharp.IO.Templates;

internal class CadHatchTemplate : CadEntityTemplate<Hatch>
{
	public class CadBoundaryPathTemplate : ICadTemplate
	{
		public Hatch.BoundaryPath Path { get; set; } = new Hatch.BoundaryPath();

		public HashSet<ulong> Handles { get; set; } = new HashSet<ulong>();

		public void Build(CadDocumentBuilder builder)
		{
			foreach (ulong handle in Handles)
			{
				if (builder.TryGetCadObject<Entity>(handle, out var value))
				{
					Path.Entities.Add(value);
				}
			}
		}
	}

	public List<CadBoundaryPathTemplate> PathTemplates = new List<CadBoundaryPathTemplate>();

	public string HatchPatternName { get; set; }

	public CadHatchTemplate()
		: base(new Hatch())
	{
	}

	public CadHatchTemplate(Hatch hatch)
		: base(hatch)
	{
	}

	protected override void build(CadDocumentBuilder builder)
	{
		base.build(builder);
		foreach (CadBoundaryPathTemplate pathTemplate in PathTemplates)
		{
			base.CadObject.Paths.Add(pathTemplate.Path);
			pathTemplate.Build(builder);
		}
	}
}
