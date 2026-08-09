using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot.Translators;

public class WriteFileParams : WriteParamsWithDrawing
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D = Serializer.LastVersion;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private serializationType _0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private fileType _0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private contentType _0023_003DzJbRvCIbvl65qygMHuA_003D_003D = contentType.GeometryAndTessellation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzByiKipanA57T02a4Ng_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzeICoJuB7hcR_0024eOJO_A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzeu7uodmEVkLZ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal DesignDocument _0023_003DzcoG1S4w_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Color _0023_003DzBLoj4kfgKlTQS7VFZGRuxLs_003D = Color.Empty;

	public int Version
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzec_0024q1ajnnp978xVGiw_003D_003D;
		}
	}

	public serializationType SerializationMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzDe3vzrwTuDBiVSmsFcdwW9k_003D = value;
		}
	}

	public fileType FileMode
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D;
		}
	}

	public contentType Content
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzJbRvCIbvl65qygMHuA_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzJbRvCIbvl65qygMHuA_003D_003D = value;
		}
	}

	public string Tag
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzByiKipanA57T02a4Ng_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzByiKipanA57T02a4Ng_003D_003D = value;
		}
	}

	public bool Purge
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzeICoJuB7hcR_0024eOJO_A_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzeICoJuB7hcR_0024eOJO_A_003D_003D = value;
		}
	}

	public bool SaveThumbnail
	{
		get
		{
			return _0023_003Dzeu7uodmEVkLZ;
		}
		set
		{
			if (value && _0023_003DzcoG1S4w_003D.workspace == null)
			{
				throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303012293));
			}
			_0023_003Dzeu7uodmEVkLZ = value;
		}
	}

	public Color ThumbnailBackgroundColor
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzBLoj4kfgKlTQS7VFZGRuxLs_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzBLoj4kfgKlTQS7VFZGRuxLs_003D = value;
		}
	}

	public WriteFileParams(DesignDocument designDocument, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, bool selectedOnly = false, bool? saveThumbnail = null, bool openBlockOnly = false)
		: this(designDocument, null, contentType, serializationType, selectedOnly, saveThumbnail, openBlockOnly)
	{
	}

	public WriteFileParams(IDesign design, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, bool selectedOnly = false, bool saveThumbnail = true, bool openBlockOnly = false)
		: this(design.Document, contentType, serializationType, selectedOnly, saveThumbnail, openBlockOnly)
	{
	}

	public WriteFileParams(DesignDocument designDocument, DrawingDocument drawing, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, bool selectedOnly = false, bool? saveThumbnail = null, bool openBlockOnly = false)
		: base(designDocument, drawing, selectedOnly, openBlockOnly)
	{
		_0023_003DzcoG1S4w_003D = designDocument;
		Content = contentType;
		SerializationMode = serializationType;
		SaveThumbnail = saveThumbnail ?? (designDocument.workspace != null);
	}

	public WriteFileParams(IDesign design, IDrawing drawing, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, bool selectedOnly = false, bool saveThumbnail = true, bool openBlockOnly = false)
		: this(design.Document, drawing.Document, contentType, serializationType, selectedOnly, saveThumbnail, openBlockOnly)
	{
	}

	public WriteFileParams(IList<Entity> entities = null, LayerKeyedCollection layers = null, BlockKeyedCollection blocks = null, MaterialKeyedCollection materials = null, TextStyleKeyedCollection textStyles = null, LineTypeKeyedCollection lineTypes = null, contentType contentType = contentType.GeometryAndTessellation, serializationType serializationType = serializationType.Uncompressed, linearUnitsType units = linearUnitsType.Meters, bool selectedOnly = false, DrawingDocument drawing = null, HatchPatternKeyedCollection hatchPatterns = null)
		: this(entities, layers, blocks, materials, textStyles, lineTypes, contentType, serializationType, fileType.Standard, units, selectedOnly, drawing, hatchPatterns)
	{
	}

	internal WriteFileParams(IList<Entity> _0023_003Dzv7xH9gk_003D, LayerKeyedCollection _0023_003DzeWJg3NJnk3WA, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, MaterialKeyedCollection _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, TextStyleKeyedCollection _0023_003Dz9LJ7v7xBdLfO, LineTypeKeyedCollection _0023_003DzA3_0024EZ731xRIG, contentType _0023_003DzB5M5dYA_003D, serializationType _0023_003DzISThhDg_003D, fileType _0023_003Dz_0024QaoO_A_003D = fileType.Standard, linearUnitsType _0023_003DzsAi4oSk_003D = linearUnitsType.Meters, bool _0023_003Dz9rsu4TwhLBvn = false, DrawingDocument _0023_003Dzu9im1ZQ_003D = null, HatchPatternKeyedCollection _0023_003DzzX6rzVb3Ybsi = null)
		: base(_0023_003Dzv7xH9gk_003D, _0023_003DzeWJg3NJnk3WA, _0023_003DzJO1FWlQ_003D, _0023_003DzhCnRkiIFA4RATyn_0024Lg_003D_003D, _0023_003Dz9LJ7v7xBdLfO, _0023_003DzA3_0024EZ731xRIG, _0023_003DzsAi4oSk_003D, _0023_003Dz9rsu4TwhLBvn, _0023_003Dzu9im1ZQ_003D, _0023_003DzzX6rzVb3Ybsi)
	{
		Content = _0023_003DzB5M5dYA_003D;
		SerializationMode = _0023_003DzISThhDg_003D;
		_0023_003DzAW1UWCKGbvPN(_0023_003Dz_0024QaoO_A_003D);
		SaveThumbnail = false;
	}

	internal void _0023_003DzAW1UWCKGbvPN(fileType _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzPU2SK_0024rg9rW7PrKHWA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}
}
