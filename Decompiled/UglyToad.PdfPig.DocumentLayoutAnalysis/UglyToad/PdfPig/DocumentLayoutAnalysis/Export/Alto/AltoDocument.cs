using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export.Alto;

[Serializable]
[EditorBrowsable(EditorBrowsableState.Never)]
[DebuggerStepThrough]
[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
[XmlRoot("alto", Namespace = "http://www.loc.gov/standards/alto/ns-v4#", IsNullable = false)]
public class AltoDocument
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoAlternative
	{
		[XmlAttribute("PURPOSE")]
		public string Purpose { get; set; }

		[XmlText]
		public string Value { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlInclude(typeof(AltoTextBlock))]
	[XmlInclude(typeof(AltoGraphicalElement))]
	[XmlInclude(typeof(AltoIllustration))]
	[XmlInclude(typeof(AltoComposedBlock))]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoBlock : AltoPositionedElement
	{
		private float rotation;

		private bool correctionStatus;

		private AltoBlockTypeShow show;

		private AltoBlockTypeActuate actuate;

		public AltoShape Shape { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }

		[XmlAttribute("TAGREFS", DataType = "IDREFS")]
		public string TagRefs { get; set; }

		[XmlAttribute("PROCESSINGREFS", DataType = "IDREFS")]
		public string ProcessingRefs { get; set; }

		[XmlAttribute("ROTATION")]
		public float Rotation
		{
			get
			{
				return rotation;
			}
			set
			{
				rotation = value;
				if (!float.IsNaN(value))
				{
					RotationSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool RotationSpecified { get; set; }

		[XmlAttribute("IDNEXT", DataType = "IDREF")]
		public string IdNext { get; set; }

		[XmlAttribute("CS")]
		public bool CorrectionStatus
		{
			get
			{
				return correctionStatus;
			}
			set
			{
				correctionStatus = value;
				CorrectionStatusSpecified = true;
			}
		}

		[XmlIgnore]
		public bool CorrectionStatusSpecified { get; set; }

		[XmlAttribute("type", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string Type { get; set; }

		[XmlAttribute("href", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink", DataType = "anyURI")]
		public string Href { get; set; }

		[XmlAttribute("role", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string Role { get; set; }

		[XmlAttribute("arcrole", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string Arcrole { get; set; }

		[XmlAttribute("title", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public string Title { get; set; }

		[XmlAttribute("show", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public AltoBlockTypeShow Show
		{
			get
			{
				return show;
			}
			set
			{
				show = value;
				ShowSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ShowSpecified { get; set; }

		[XmlAttribute("actuate", Form = XmlSchemaForm.Qualified, Namespace = "http://www.w3.org/1999/xlink")]
		public AltoBlockTypeActuate Actuate
		{
			get
			{
				return actuate;
			}
			set
			{
				actuate = value;
				ActuateSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ActuateSpecified { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/xlink")]
	public enum AltoBlockTypeActuate
	{
		[XmlEnum("onLoad")]
		OnLoad,
		[XmlEnum("onRequest")]
		OnRequest,
		[XmlEnum("other")]
		Other,
		[XmlEnum("none")]
		None
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/1999/xlink")]
	public enum AltoBlockTypeShow
	{
		[XmlEnum("new")]
		New,
		[XmlEnum("replace")]
		Replace,
		[XmlEnum("embed")]
		Embed,
		[XmlEnum("other")]
		Other,
		[XmlEnum("none")]
		None
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoCircle
	{
		[XmlAttribute("HPOS")]
		public float HorizontalPosition { get; set; }

		[XmlAttribute("VPOS")]
		public float VerticalPosition { get; set; }

		[XmlAttribute("RADIUS")]
		public float Radius { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoComposedBlock : AltoBlock
	{
		[XmlAttribute("TYPE")]
		public string TypeComposed { get; set; }

		[XmlAttribute("FILEID")]
		public string FileId { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoDescription
	{
		public AltoMeasurementUnit MeasurementUnit { get; set; }

		[XmlElement("sourceImageInformation")]
		public AltoSourceImageInformation SourceImageInformation { get; set; }

		[XmlElement("OCRProcessing")]
		public AltoDescriptionOcrProcessing[] OcrProcessing { get; set; }

		[XmlElement("Processing")]
		public AltoDescriptionProcessing[] Processings { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoDescriptionOcrProcessing : AltoOcrProcessing
	{
		[XmlAttribute(DataType = "ID")]
		public string Id { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoDescriptionProcessing : AltoProcessingStep
	{
		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoDocumentIdentifier
	{
		[XmlAttribute("documentIdentifierLocation")]
		public string DocumentIdentifierLocation { get; set; }

		[XmlText]
		public string Value { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoEllipse
	{
		private float rotation;

		[XmlAttribute("HPOS")]
		public float HorizontalPosition { get; set; }

		[XmlAttribute("VPOS")]
		public float VerticalPosition { get; set; }

		[XmlAttribute("HLENGTH")]
		public float HorizontalLength { get; set; }

		[XmlAttribute("VLENGTH")]
		public float VerticalLength { get; set; }

		[XmlAttribute("ROTATION")]
		public float Rotation
		{
			get
			{
				return rotation;
			}
			set
			{
				rotation = value;
				if (!float.IsNaN(value))
				{
					RotationSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool RotationSpecified { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoFileIdentifier
	{
		[XmlAttribute("fileIdentifierLocation")]
		public string FileIdentifierLocation { get; set; }

		[XmlText]
		public string Value { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Flags]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoFontStyles
	{
		[XmlEnum("bold")]
		Bold = 1,
		[XmlEnum("italics")]
		Italics = 2,
		[XmlEnum("subscript")]
		Subscript = 4,
		[XmlEnum("superscript")]
		Superscript = 8,
		[XmlEnum("smallcaps")]
		SmallCaps = 0x10,
		[XmlEnum("underline")]
		Underline = 0x20
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoFontType
	{
		[XmlEnum("serif")]
		Serif,
		[XmlEnum("sans-serif")]
		SansSerif
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoFontWidth
	{
		[XmlEnum("proportional")]
		Proportional,
		[XmlEnum("fixed")]
		Fixed
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoGlyph : AltoPositionedElement
	{
		private float gc;

		public AltoShape Shape { get; set; }

		[XmlElement("Variant")]
		public AltoVariant[] Variant { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("CONTENT")]
		public string Content { get; set; }

		[XmlAttribute("GC")]
		public float Gc
		{
			get
			{
				return gc;
			}
			set
			{
				gc = value;
				if (!float.IsNaN(value))
				{
					GcSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool GcSpecified { get; set; }

		public override string ToString()
		{
			return Content;
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoGraphicalElement : AltoBlock
	{
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoIllustration : AltoBlock
	{
		[XmlAttribute("TYPE")]
		public string IllustrationType { get; set; }

		[XmlAttribute("FILEID")]
		public string FileId { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#", IncludeInSchema = false)]
	public enum AltoItemsChoice
	{
		LayoutTag,
		NamedEntityTag,
		OtherTag,
		RoleTag,
		StructureTag
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoLayout
	{
		[XmlElement("Page")]
		public AltoPage[] Pages { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoMeasurementUnit
	{
		[XmlEnum("pixel")]
		Pixel,
		[XmlEnum("mm10")]
		Mm10,
		[XmlEnum("inch1200")]
		Inch1200
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoOcrProcessing
	{
		[XmlElement("preProcessingStep")]
		public AltoProcessingStep[] PreProcessingStep { get; set; }

		public AltoProcessingStep OcrProcessingStep { get; set; }

		[XmlElement("postProcessingStep")]
		public AltoProcessingStep[] PostProcessingStep { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoPage
	{
		private float height;

		private float width;

		private AltoQuality quality;

		private AltoPosition position;

		private float accuracy;

		private float pc;

		public AltoPageSpace TopMargin { get; set; }

		public AltoPageSpace LeftMargin { get; set; }

		public AltoPageSpace RightMargin { get; set; }

		public AltoPageSpace BottomMargin { get; set; }

		public AltoPageSpace PrintSpace { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("PAGECLASS")]
		public string PageClass { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }

		[XmlAttribute("PROCESSINGREFS", DataType = "IDREFS")]
		public string ProcessingRefs { get; set; }

		[XmlAttribute("HEIGHT")]
		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
				if (!float.IsNaN(value))
				{
					HeightSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool HeightSpecified { get; set; }

		[XmlAttribute("WIDTH")]
		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
				if (!float.IsNaN(value))
				{
					WidthSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool WidthSpecified { get; set; }

		[XmlAttribute("PHYSICAL_IMG_NR")]
		public float PhysicalImgNr { get; set; }

		[XmlAttribute("PRINTED_IMG_NR")]
		public string PrintedImgNr { get; set; }

		[XmlAttribute("QUALITY")]
		public AltoQuality Quality
		{
			get
			{
				return quality;
			}
			set
			{
				quality = value;
				QualitySpecified = true;
			}
		}

		[XmlIgnore]
		public bool QualitySpecified { get; set; }

		[XmlAttribute("QUALITY_DETAIL")]
		public string QualityDetail { get; set; }

		[XmlAttribute("POSITION")]
		public AltoPosition Position
		{
			get
			{
				return position;
			}
			set
			{
				position = value;
				PositionSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PositionSpecified { get; set; }

		[XmlAttribute("PROCESSING", DataType = "IDREF")]
		public string Processing { get; set; }

		[XmlAttribute("ACCURACY")]
		public float Accuracy
		{
			get
			{
				return accuracy;
			}
			set
			{
				accuracy = value;
				if (!float.IsNaN(value))
				{
					AccuracySpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool AccuracySpecified { get; set; }

		[XmlAttribute("PC")]
		public float Pc
		{
			get
			{
				return pc;
			}
			set
			{
				pc = value;
				if (!float.IsNaN(value))
				{
					PcSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool PcSpecified { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoPageSpace : AltoPositionedElement
	{
		public AltoShape Shape { get; set; }

		[XmlElement("TextBlock")]
		public AltoTextBlock[] TextBlock { get; set; }

		[XmlElement("Illustration")]
		public AltoIllustration[] Illustrations { get; set; }

		[XmlElement("GraphicalElement")]
		public AltoGraphicalElement[] GraphicalElements { get; set; }

		[XmlElement("ComposedBlock")]
		public AltoComposedBlock[] ComposedBlocks { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }

		[XmlAttribute("PROCESSINGREFS", DataType = "IDREFS")]
		public string ProcessingRefs { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoParagraphStyle
	{
		private AltoParagraphStyleAlign align;

		private float left;

		private float right;

		private float linespace;

		private float firstLine;

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("ALIGN")]
		public AltoParagraphStyleAlign Align
		{
			get
			{
				return align;
			}
			set
			{
				align = value;
				AlignSpecified = true;
			}
		}

		[XmlIgnore]
		public bool AlignSpecified { get; private set; }

		[XmlAttribute("LEFT")]
		public float Left
		{
			get
			{
				return left;
			}
			set
			{
				left = value;
				if (!float.IsNaN(value))
				{
					LeftSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool LeftSpecified { get; private set; }

		[XmlAttribute("RIGHT")]
		public float Right
		{
			get
			{
				return right;
			}
			set
			{
				right = value;
				if (!float.IsNaN(value))
				{
					RightSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool RightSpecified { get; private set; }

		[XmlAttribute("LINESPACE")]
		public float LineSpace
		{
			get
			{
				return linespace;
			}
			set
			{
				linespace = value;
				if (!float.IsNaN(value))
				{
					LineSpaceSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool LineSpaceSpecified { get; private set; }

		[XmlAttribute("FIRSTLINE")]
		public float FirstLine
		{
			get
			{
				return firstLine;
			}
			set
			{
				firstLine = value;
				if (!float.IsNaN(value))
				{
					FirstLineSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool FirstLineSpecified { get; private set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoParagraphStyleAlign
	{
		Left,
		Right,
		Center,
		Block
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoPolygon
	{
		[XmlAttribute("POINTS")]
		public string Points { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoPosition
	{
		Left,
		Right,
		Foldout,
		Single,
		Cover
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	public abstract class AltoPositionedElement
	{
		private float height;

		private float width;

		private float horizontalPosition;

		private float verticalPosition;

		[XmlAttribute("HEIGHT")]
		public float Height
		{
			get
			{
				return height;
			}
			set
			{
				height = value;
				if (!float.IsNaN(value))
				{
					HeightSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool HeightSpecified { get; set; }

		[XmlAttribute("WIDTH")]
		public float Width
		{
			get
			{
				return width;
			}
			set
			{
				width = value;
				if (!float.IsNaN(value))
				{
					WidthSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool WidthSpecified { get; set; }

		[XmlAttribute("HPOS")]
		public float HorizontalPosition
		{
			get
			{
				return horizontalPosition;
			}
			set
			{
				horizontalPosition = value;
				if (!float.IsNaN(value))
				{
					HorizontalPositionSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool HorizontalPositionSpecified { get; set; }

		[XmlAttribute("VPOS")]
		public float VerticalPosition
		{
			get
			{
				return verticalPosition;
			}
			set
			{
				verticalPosition = value;
				if (!float.IsNaN(value))
				{
					VerticalPositionSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool VerticalPositionSpecified { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Flags]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoProcessingCategory
	{
		[XmlEnum("contentGeneration")]
		ContentGeneration = 1,
		[XmlEnum("contentModification")]
		ContentModification = 2,
		[XmlEnum("preOperation")]
		PreOperation = 4,
		[XmlEnum("postOperation")]
		PostOperation = 8,
		[XmlEnum("other")]
		Other = 0x10
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoProcessingSoftware
	{
		[XmlAttribute("softwareCreator")]
		public string SoftwareCreator { get; set; }

		[XmlAttribute("softwareName")]
		public string SoftwareName { get; set; }

		[XmlAttribute("softwareVersion")]
		public string SoftwareVersion { get; set; }

		[XmlAttribute("applicationDescription")]
		public string ApplicationDescription { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoProcessingStep
	{
		private AltoProcessingCategory processingCategory;

		[XmlAttribute("processingCategory")]
		public AltoProcessingCategory ProcessingCategory
		{
			get
			{
				return processingCategory;
			}
			set
			{
				processingCategory = value;
				ProcessingCategorySpecified = true;
			}
		}

		[XmlIgnore]
		public bool ProcessingCategorySpecified { get; set; }

		[XmlAttribute("processingDateTime")]
		public string ProcessingDateTime { get; set; }

		[XmlAttribute("processingAgency")]
		public string ProcessingAgency { get; set; }

		[XmlElement("processingStepDescription")]
		public string[] ProcessingStepDescription { get; set; }

		[XmlAttribute("processingStepSettings")]
		public string ProcessingStepSettings { get; set; }

		[XmlElement("processingSoftware")]
		public AltoProcessingSoftware ProcessingSoftware { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoQuality
	{
		OK,
		Missing,
		[XmlEnum("Missing in original")]
		MissingInOriginal,
		Damaged,
		Retained,
		Target,
		[XmlEnum("As in original")]
		AsInOriginal
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoShape
	{
		[XmlElement("Circle", typeof(AltoCircle))]
		[XmlElement("Ellipse", typeof(AltoEllipse))]
		[XmlElement("Polygon", typeof(AltoPolygon))]
		public object Item { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoSourceImageInformation
	{
		[XmlElement("fileName")]
		public string FileName { get; set; }

		[XmlElement("fileIdentifier")]
		public AltoFileIdentifier[] FileIdentifiers { get; set; }

		[XmlElement("documentIdentifier")]
		public AltoDocumentIdentifier[] DocumentIdentifiers { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoSP : AltoPositionedElement
	{
		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoString : AltoPositionedElement
	{
		private AltoFontStyles style;

		private AltoSubsType subsType;

		private float wc;

		private bool correctionStatus;

		public AltoShape Shape { get; set; }

		[XmlElement("ALTERNATIVE")]
		public AltoAlternative[] Alternative { get; set; }

		[XmlElement("Glyph")]
		public AltoGlyph[] Glyph { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }

		[XmlAttribute("TAGREFS", DataType = "IDREFS")]
		public string TagRefs { get; set; }

		[XmlAttribute("PROCESSINGREFS", DataType = "IDREFS")]
		public string ProcessingRefs { get; set; }

		[XmlAttribute("CONTENT")]
		public string Content { get; set; }

		[XmlAttribute("STYLE")]
		public AltoFontStyles Style
		{
			get
			{
				return style;
			}
			set
			{
				style = value;
				StyleSpecified = true;
			}
		}

		[XmlIgnore]
		public bool StyleSpecified { get; set; }

		[XmlAttribute("SUBS_TYPE")]
		public AltoSubsType SubsType
		{
			get
			{
				return subsType;
			}
			set
			{
				subsType = value;
				SubsTypeSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SubsTypeSpecified { get; set; }

		[XmlAttribute("SUBS_CONTENT")]
		public string SubsContent { get; set; }

		[XmlAttribute("WC")]
		public float Wc
		{
			get
			{
				return wc;
			}
			set
			{
				wc = value;
				if (!float.IsNaN(value))
				{
					WcSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool WcSpecified { get; set; }

		[XmlAttribute("CC")]
		public string Cc { get; set; }

		[XmlAttribute("CS")]
		public bool CorrectionStatus
		{
			get
			{
				return correctionStatus;
			}
			set
			{
				correctionStatus = value;
				CorrectionStatusSpecified = true;
			}
		}

		[XmlIgnore]
		public bool CorrectionStatusSpecified { get; set; }

		[XmlAttribute("LANG", DataType = "language")]
		public string Language { get; set; }

		public override string ToString()
		{
			return Content;
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoStyles
	{
		[XmlElement("TextStyle")]
		public AltoTextStyle[] TextStyle { get; set; }

		[XmlElement("ParagraphStyle")]
		public AltoParagraphStyle[] ParagraphStyle { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public enum AltoSubsType
	{
		HypPart1,
		HypPart2,
		Abbreviation
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTag
	{
		public AltoTagXmlData XmlData { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("TYPE")]
		public string Type { get; set; }

		[XmlAttribute("LABEL")]
		public string Label { get; set; }

		[XmlAttribute("DESCRIPTION")]
		public string Description { get; set; }

		[XmlAttribute("URI", DataType = "anyURI")]
		public string Uri { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTags
	{
		[XmlElement("LayoutTag", typeof(AltoTag))]
		[XmlElement("NamedEntityTag", typeof(AltoTag))]
		[XmlElement("OtherTag", typeof(AltoTag))]
		[XmlElement("RoleTag", typeof(AltoTag))]
		[XmlElement("StructureTag", typeof(AltoTag))]
		[XmlChoiceIdentifier("ItemsElementName")]
		public AltoTag[] Items { get; set; }

		[XmlElement("ItemsElementName")]
		[XmlIgnore]
		public AltoItemsChoice[] ItemsElementName { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTagXmlData
	{
		[XmlAnyElement]
		public XmlElement[] Any { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTextBlock : AltoBlock
	{
		[XmlElement("TextLine")]
		public AltoTextBlockTextLine[] TextLines { get; set; }

		[XmlAttribute("language", DataType = "language")]
		public string Language { get; set; }

		[XmlAttribute("LANG", DataType = "language")]
		public string Lang { get; set; }

		public override string ToString()
		{
			return string.Join(" ", (IEnumerable<AltoTextBlockTextLine>)TextLines);
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTextBlockTextLine : AltoPositionedElement
	{
		private float baseline;

		private bool correctionStatus;

		public AltoShape Shape { get; set; }

		[XmlElement("String")]
		public AltoString[] Strings { get; set; }

		[XmlElement("SP")]
		public AltoSP[] Sp { get; set; }

		[XmlElement("HYP")]
		public AltoTextBlockTextLineHyp Hyp { get; set; }

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("STYLEREFS", DataType = "IDREFS")]
		public string StyleRefs { get; set; }

		[XmlAttribute("TAGREFS", DataType = "IDREFS")]
		public string TagRefs { get; set; }

		[XmlAttribute("PROCESSINGREFS", DataType = "IDREFS")]
		public string ProcessingRefs { get; set; }

		[XmlAttribute("BASELINE")]
		public float BaseLine
		{
			get
			{
				return baseline;
			}
			set
			{
				baseline = value;
				if (!float.IsNaN(value))
				{
					BaseLineSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool BaseLineSpecified { get; set; }

		[XmlAttribute("LANG", DataType = "language")]
		public string Language { get; set; }

		[XmlAttribute("CS")]
		public bool CorrectionStatus
		{
			get
			{
				return correctionStatus;
			}
			set
			{
				correctionStatus = value;
				CorrectionStatusSpecified = true;
			}
		}

		[XmlIgnore]
		public bool CorrectionStatusSpecified { get; set; }

		public override string ToString()
		{
			return string.Join(" ", (IEnumerable<AltoString>)Strings);
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(AnonymousType = true, Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTextBlockTextLineHyp : AltoPositionedElement
	{
		[XmlAttribute("CONTENT")]
		public string Content { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoTextStyle
	{
		private AltoFontType fontType;

		private AltoFontWidth fontWidth;

		private AltoFontStyles fontStyle;

		[XmlAttribute("ID", DataType = "ID")]
		public string Id { get; set; }

		[XmlAttribute("FONTFAMILY")]
		public string FontFamily { get; set; }

		[XmlAttribute("FONTTYPE")]
		public AltoFontType FontType
		{
			get
			{
				return fontType;
			}
			set
			{
				fontType = value;
				FontTypeSpecified = true;
			}
		}

		[XmlIgnore]
		public bool FontTypeSpecified { get; set; }

		[XmlAttribute("FONTWIDTH")]
		public AltoFontWidth FontWidth
		{
			get
			{
				return fontWidth;
			}
			set
			{
				fontWidth = value;
				FontWidthSpecified = true;
			}
		}

		[XmlIgnore]
		public bool FontWidthSpecified { get; set; }

		[XmlAttribute("FONTSIZE")]
		public float FontSize { get; set; }

		[XmlAttribute("FONTCOLOR", DataType = "hexBinary")]
		public byte[] FontColor { get; set; }

		[XmlAttribute("FONTSTYLE")]
		public AltoFontStyles FontStyle
		{
			get
			{
				return fontStyle;
			}
			set
			{
				fontStyle = value;
				FontStyleSpecified = true;
			}
		}

		[XmlIgnore]
		public bool FontStyleSpecified { get; set; }
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DebuggerStepThrough]
	[XmlType(Namespace = "http://www.loc.gov/standards/alto/ns-v4#")]
	public class AltoVariant
	{
		private float vcField;

		[XmlAttribute("CONTENT")]
		public string Content { get; set; }

		[XmlAttribute("VC")]
		public float Vc
		{
			get
			{
				return vcField;
			}
			set
			{
				vcField = value;
				if (!float.IsNaN(value))
				{
					VcSpecified = true;
				}
			}
		}

		[XmlIgnore]
		public bool VcSpecified { get; set; }
	}

	public AltoDescription Description { get; set; }

	public AltoStyles Styles { get; set; }

	public AltoTags Tags { get; set; }

	public AltoLayout Layout { get; set; }

	[XmlAttribute("SCHEMAVERSION")]
	public string SchemaVersion { get; set; }
}
