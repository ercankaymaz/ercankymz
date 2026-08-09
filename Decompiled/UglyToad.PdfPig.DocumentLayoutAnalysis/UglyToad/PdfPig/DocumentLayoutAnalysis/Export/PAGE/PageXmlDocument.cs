using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;

namespace UglyToad.PdfPig.DocumentLayoutAnalysis.Export.PAGE;

[Serializable]
[EditorBrowsable(EditorBrowsableState.Never)]
[GeneratedCode("xsd", "4.6.1055.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
[XmlRoot("PcGts", Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15", IsNullable = false)]
public class PageXmlDocument
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlAdvertRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlAlignSimpleType
	{
		[XmlEnum("left")]
		Left,
		[XmlEnum("centre")]
		Centre,
		[XmlEnum("right")]
		Right,
		[XmlEnum("justify")]
		Justify
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlAlternativeImage
	{
		private string filenameField;

		private string commentsField;

		private float confField;

		private bool confFieldSpecified;

		[XmlAttribute("filename")]
		public string FileName
		{
			get
			{
				return filenameField;
			}
			set
			{
				filenameField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlBaseline
	{
		private string pointsField;

		private float confField;

		private bool confFieldSpecified;

		[XmlAttribute("points")]
		public string Points
		{
			get
			{
				return pointsField;
			}
			set
			{
				pointsField = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlBorder
	{
		private PageXmlCoords coordsField;

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlChartRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlChartSimpleType typeField;

		private bool typeFieldSpecified;

		private int numColoursField;

		private bool numColoursFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		private bool embTextField;

		private bool embTextFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlChartSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("numColours")]
		public int NumColours
		{
			get
			{
				return numColoursField;
			}
			set
			{
				numColoursField = value;
				numColoursFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool NumColoursSpecified
		{
			get
			{
				return numColoursFieldSpecified;
			}
			set
			{
				numColoursFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}

		[XmlAttribute("embText")]
		public bool EmbText
		{
			get
			{
				return embTextField;
			}
			set
			{
				embTextField = value;
				embTextFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool EmbTextSpecified
		{
			get
			{
				return embTextFieldSpecified;
			}
			set
			{
				embTextFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlChartSimpleType
	{
		[XmlEnum("bar")]
		Bar,
		[XmlEnum("line")]
		Line,
		[XmlEnum("pie")]
		Pie,
		[XmlEnum("scatter")]
		Scatter,
		[XmlEnum("surface")]
		Surface,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlChemRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlColourDepthSimpleType
	{
		[XmlEnum("bilevel")]
		BiLevel,
		[XmlEnum("greyscale")]
		GreyScale,
		[XmlEnum("colour")]
		Colour,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlColourSimpleType
	{
		[XmlEnum("black")]
		Black,
		[XmlEnum("blue")]
		Blue,
		[XmlEnum("brown")]
		Brown,
		[XmlEnum("cyan")]
		Cyan,
		[XmlEnum("green")]
		Green,
		[XmlEnum("grey")]
		Grey,
		[XmlEnum("indigo")]
		Indigo,
		[XmlEnum("magenta")]
		Magenta,
		[XmlEnum("orange")]
		Orange,
		[XmlEnum("pink")]
		Pink,
		[XmlEnum("red")]
		Red,
		[XmlEnum("turquoise")]
		Turquoise,
		[XmlEnum("violet")]
		Violet,
		[XmlEnum("white")]
		White,
		[XmlEnum("yellow")]
		Yellow,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlCoords
	{
		private string pointsField;

		private float confField;

		private bool confFieldSpecified;

		[XmlAttribute("points")]
		public string Points
		{
			get
			{
				return pointsField;
			}
			set
			{
				pointsField = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlCustomRegion : PageXmlRegion
	{
		private string typeField;

		[XmlAttribute("type")]
		public string Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlGlyph
	{
		private PageXmlAlternativeImage[] alternativeImageField;

		private PageXmlCoords coordsField;

		private PageXmlGraphemeBase[] graphemesField;

		private PageXmlTextEquiv[] textEquivField;

		private PageXmlTextStyle textStyleField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private string idField;

		private bool ligatureField;

		private bool ligatureFieldSpecified;

		private bool symbolField;

		private bool symbolFieldSpecified;

		private PageXmlScriptSimpleType scriptField;

		private bool scriptFieldSpecified;

		private PageXmlProductionSimpleType productionField;

		private bool productionFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlElement("AlternativeImage")]
		public PageXmlAlternativeImage[] AlternativeImages
		{
			get
			{
				return alternativeImageField;
			}
			set
			{
				alternativeImageField = value;
			}
		}

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}

		[XmlArrayItem("Grapheme", typeof(PageXmlGrapheme), IsNullable = false)]
		[XmlArrayItem("GraphemeGroup", typeof(PageXmlGraphemeGroup), IsNullable = false)]
		[XmlArrayItem("NonPrintingChar", typeof(PageXmlNonPrintingChar), IsNullable = false)]
		public PageXmlGraphemeBase[] Graphemes
		{
			get
			{
				return graphemesField;
			}
			set
			{
				graphemesField = value;
			}
		}

		[XmlElement("TextEquiv")]
		public PageXmlTextEquiv[] TextEquivs
		{
			get
			{
				return textEquivField;
			}
			set
			{
				textEquivField = value;
			}
		}

		public PageXmlTextStyle TextStyle
		{
			get
			{
				return textStyleField;
			}
			set
			{
				textStyleField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("ligature")]
		public bool Ligature
		{
			get
			{
				return ligatureField;
			}
			set
			{
				ligatureField = value;
				ligatureFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LigatureSpecified
		{
			get
			{
				return ligatureFieldSpecified;
			}
			set
			{
				ligatureFieldSpecified = value;
			}
		}

		[XmlAttribute("symbol")]
		public bool Symbol
		{
			get
			{
				return symbolField;
			}
			set
			{
				symbolField = value;
				symbolFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SymbolSpecified
		{
			get
			{
				return symbolFieldSpecified;
			}
			set
			{
				symbolFieldSpecified = value;
			}
		}

		[XmlAttribute("script")]
		public PageXmlScriptSimpleType Script
		{
			get
			{
				return scriptField;
			}
			set
			{
				scriptField = value;
				scriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ScriptSpecified
		{
			get
			{
				return scriptFieldSpecified;
			}
			set
			{
				scriptFieldSpecified = value;
			}
		}

		[XmlAttribute("production")]
		public PageXmlProductionSimpleType Production
		{
			get
			{
				return productionField;
			}
			set
			{
				productionField = value;
				productionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ProductionSpecified
		{
			get
			{
				return productionFieldSpecified;
			}
			set
			{
				productionFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlGrapheme : PageXmlGraphemeBase
	{
		private PageXmlCoords coordsField;

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlInclude(typeof(PageXmlGraphemeGroup))]
	[XmlInclude(typeof(PageXmlNonPrintingChar))]
	[XmlInclude(typeof(PageXmlGrapheme))]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public abstract class PageXmlGraphemeBase
	{
		private PageXmlTextEquiv[] textEquivField;

		private string idField;

		private int indexField;

		private bool ligatureField;

		private bool ligatureFieldSpecified;

		private PageXmlGraphemeBaseCharType charTypeField;

		private bool charTypeFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlElement("TextEquiv")]
		public PageXmlTextEquiv[] TextEquivs
		{
			get
			{
				return textEquivField;
			}
			set
			{
				textEquivField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("index")]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("ligature")]
		public bool Ligature
		{
			get
			{
				return ligatureField;
			}
			set
			{
				ligatureField = value;
				ligatureFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LigatureSpecified
		{
			get
			{
				return ligatureFieldSpecified;
			}
			set
			{
				ligatureFieldSpecified = value;
			}
		}

		[XmlAttribute("charType")]
		public PageXmlGraphemeBaseCharType CharType
		{
			get
			{
				return charTypeField;
			}
			set
			{
				charTypeField = value;
				charTypeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool CharTypeSpecified
		{
			get
			{
				return charTypeFieldSpecified;
			}
			set
			{
				charTypeFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(AnonymousType = true, Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlGraphemeBaseCharType
	{
		[XmlEnum("base")]
		Base,
		[XmlEnum("combining")]
		Combining
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlGraphemeGroup : PageXmlGraphemeBase
	{
		private PageXmlGraphemeBase[] itemsField;

		[XmlElement("Grapheme", typeof(PageXmlGrapheme))]
		[XmlElement("NonPrintingChar", typeof(PageXmlNonPrintingChar))]
		public PageXmlGraphemeBase[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlGraphicRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlGraphicsSimpleType typeField;

		private bool typeFieldSpecified;

		private int numColoursField;

		private bool numColoursFieldSpecified;

		private bool embTextField;

		private bool embTextFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlGraphicsSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("numColours")]
		public int NumColours
		{
			get
			{
				return numColoursField;
			}
			set
			{
				numColoursField = value;
				numColoursFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool NumColoursSpecified
		{
			get
			{
				return numColoursFieldSpecified;
			}
			set
			{
				numColoursFieldSpecified = value;
			}
		}

		[XmlAttribute("embText")]
		public bool EmbText
		{
			get
			{
				return embTextField;
			}
			set
			{
				embTextField = value;
				embTextFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool EmbTextSpecified
		{
			get
			{
				return embTextFieldSpecified;
			}
			set
			{
				embTextFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlGraphicsSimpleType
	{
		[XmlEnum("logo")]
		Logo,
		[XmlEnum("letterhead")]
		Letterhead,
		[XmlEnum("decoration")]
		Decoration,
		[XmlEnum("frame")]
		Frame,
		[XmlEnum("handwritten-annotation")]
		HandwrittenAnnotation,
		[XmlEnum("stamp")]
		Stamp,
		[XmlEnum("signature")]
		Signature,
		[XmlEnum("barcode")]
		Barcode,
		[XmlEnum("paper-grow")]
		PaperGrow,
		[XmlEnum("punch-hole")]
		PunchHole,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlGridPoints
	{
		private int indexField;

		private string pointsField;

		[XmlAttribute("index")]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("points")]
		public string Points
		{
			get
			{
				return pointsField;
			}
			set
			{
				pointsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlGroupSimpleType
	{
		[XmlEnum("paragraph")]
		Paragraph,
		[XmlEnum("list")]
		List,
		[XmlEnum("list-item")]
		ListItem,
		[XmlEnum("figure")]
		Figure,
		[XmlEnum("article")]
		Article,
		[XmlEnum("div")]
		Div,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlImageRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourDepthSimpleType colourDepthField;

		private bool colourDepthFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		private bool embTextField;

		private bool embTextFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("colourDepth")]
		public PageXmlColourDepthSimpleType ColourDepth
		{
			get
			{
				return colourDepthField;
			}
			set
			{
				colourDepthField = value;
				colourDepthFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ColourDepthSpecified
		{
			get
			{
				return colourDepthFieldSpecified;
			}
			set
			{
				colourDepthFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}

		[XmlAttribute("embText")]
		public bool EmbText
		{
			get
			{
				return embTextField;
			}
			set
			{
				embTextField = value;
				embTextFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool EmbTextSpecified
		{
			get
			{
				return embTextFieldSpecified;
			}
			set
			{
				embTextFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlLabel
	{
		private string valueField;

		private string typeField;

		private string commentsField;

		[XmlAttribute("value")]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
			}
		}

		[XmlAttribute("type")]
		public string Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlLabels
	{
		private PageXmlLabel[] labelField;

		private string externalModelField;

		private string externalIdField;

		private string prefixField;

		private string commentsField;

		[XmlElement("Label")]
		public PageXmlLabel[] Labels
		{
			get
			{
				return labelField;
			}
			set
			{
				labelField = value;
			}
		}

		[XmlAttribute("externalModel")]
		public string ExternalModel
		{
			get
			{
				return externalModelField;
			}
			set
			{
				externalModelField = value;
			}
		}

		[XmlAttribute("externalId")]
		public string ExternalId
		{
			get
			{
				return externalIdField;
			}
			set
			{
				externalIdField = value;
			}
		}

		[XmlAttribute("prefix")]
		public string Prefix
		{
			get
			{
				return prefixField;
			}
			set
			{
				prefixField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlLanguageSimpleType
	{
		Abkhaz,
		Afar,
		Afrikaans,
		Akan,
		Albanian,
		Amharic,
		Arabic,
		Aragonese,
		Armenian,
		Assamese,
		Avaric,
		Avestan,
		Aymara,
		Azerbaijani,
		Bambara,
		Bashkir,
		Basque,
		Belarusian,
		Bengali,
		Bihari,
		Bislama,
		Bosnian,
		Breton,
		Bulgarian,
		Burmese,
		Cambodian,
		Cantonese,
		Catalan,
		Chamorro,
		Chechen,
		Chichewa,
		Chinese,
		Chuvash,
		Cornish,
		Corsican,
		Cree,
		Croatian,
		Czech,
		Danish,
		Divehi,
		Dutch,
		Dzongkha,
		English,
		Esperanto,
		Estonian,
		Ewe,
		Faroese,
		Fijian,
		Finnish,
		French,
		Fula,
		Gaelic,
		Galician,
		Ganda,
		Georgian,
		German,
		Greek,
		Guaraní,
		Gujarati,
		Haitian,
		Hausa,
		Hebrew,
		Herero,
		Hindi,
		[XmlEnum("Hiri Motu")]
		HiriMotu,
		Hungarian,
		Icelandic,
		Ido,
		Igbo,
		Indonesian,
		Interlingua,
		Interlingue,
		Inuktitut,
		Inupiaq,
		Irish,
		Italian,
		Japanese,
		Javanese,
		Kalaallisut,
		Kannada,
		Kanuri,
		Kashmiri,
		Kazakh,
		Khmer,
		Kikuyu,
		Kinyarwanda,
		Kirundi,
		Komi,
		Kongo,
		Korean,
		Kurdish,
		Kwanyama,
		Kyrgyz,
		Lao,
		Latin,
		Latvian,
		Limburgish,
		Lingala,
		Lithuanian,
		[XmlEnum("Luba-Katanga")]
		LubaKatanga,
		Luxembourgish,
		Macedonian,
		Malagasy,
		Malay,
		Malayalam,
		Maltese,
		Manx,
		Māori,
		Marathi,
		Marshallese,
		Mongolian,
		Nauru,
		Navajo,
		Ndonga,
		Nepali,
		[XmlEnum("North Ndebele")]
		NorthNdebele,
		[XmlEnum("Northern Sami")]
		NorthernSami,
		Norwegian,
		[XmlEnum("Norwegian Bokmål")]
		NorwegianBokmål,
		[XmlEnum("Norwegian Nynorsk")]
		NorwegianNynorsk,
		Nuosu,
		Occitan,
		Ojibwe,
		[XmlEnum("Old Church Slavonic")]
		OldChurchSlavonic,
		Oriya,
		Oromo,
		Ossetian,
		Pāli,
		Panjabi,
		Pashto,
		Persian,
		Polish,
		Portuguese,
		Punjabi,
		Quechua,
		Romanian,
		Romansh,
		Russian,
		Samoan,
		Sango,
		Sanskrit,
		Sardinian,
		Serbian,
		Shona,
		Sindhi,
		Sinhala,
		Slovak,
		Slovene,
		Somali,
		[XmlEnum("South Ndebele")]
		SouthNdebele,
		[XmlEnum("Southern Sotho")]
		SouthernSotho,
		Spanish,
		Sundanese,
		Swahili,
		Swati,
		Swedish,
		Tagalog,
		Tahitian,
		Tajik,
		Tamil,
		Tatar,
		Telugu,
		Thai,
		Tibetan,
		Tigrinya,
		Tonga,
		Tsonga,
		Tswana,
		Turkish,
		Turkmen,
		Twi,
		Uighur,
		Ukrainian,
		Urdu,
		Uzbek,
		Venda,
		Vietnamese,
		Volapük,
		Walloon,
		Welsh,
		[XmlEnum("Western Frisian")]
		WesternFrisian,
		Wolof,
		Xhosa,
		Yiddish,
		Yoruba,
		Zhuang,
		Zulu,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlLayer
	{
		private PageXmlRegionRef[] regionRefField;

		private string idField;

		private int zIndexField;

		private string captionField;

		[XmlElement("RegionRef")]
		public PageXmlRegionRef[] RegionRefs
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("zIndex")]
		public int ZIndex
		{
			get
			{
				return zIndexField;
			}
			set
			{
				zIndexField = value;
			}
		}

		[XmlAttribute("caption")]
		public string Caption
		{
			get
			{
				return captionField;
			}
			set
			{
				captionField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlLayers
	{
		private PageXmlLayer[] layerField;

		[XmlElement("Layer")]
		public PageXmlLayer[] Layers
		{
			get
			{
				return layerField;
			}
			set
			{
				layerField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlLineDrawingRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType penColourField;

		private bool penColourFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		private bool embTextField;

		private bool embTextFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("penColour")]
		public PageXmlColourSimpleType PenColour
		{
			get
			{
				return penColourField;
			}
			set
			{
				penColourField = value;
				penColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PenColourSpecified
		{
			get
			{
				return penColourFieldSpecified;
			}
			set
			{
				penColourFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}

		[XmlAttribute("embText")]
		public bool EmbText
		{
			get
			{
				return embTextField;
			}
			set
			{
				embTextField = value;
				embTextFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool EmbTextSpecified
		{
			get
			{
				return embTextFieldSpecified;
			}
			set
			{
				embTextFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlMapRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlMathsRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlMetadata
	{
		private string creatorField;

		private DateTime createdField;

		private DateTime lastChangeField;

		private string commentsField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlMetadataItem[] metadataItemField;

		private string externalRefField;

		public string Creator
		{
			get
			{
				return creatorField;
			}
			set
			{
				creatorField = value;
			}
		}

		public DateTime Created
		{
			get
			{
				return createdField;
			}
			set
			{
				createdField = value;
			}
		}

		public DateTime LastChange
		{
			get
			{
				return lastChangeField;
			}
			set
			{
				lastChangeField = value;
			}
		}

		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("MetadataItem")]
		public PageXmlMetadataItem[] MetadataItems
		{
			get
			{
				return metadataItemField;
			}
			set
			{
				metadataItemField = value;
			}
		}

		[XmlAttribute("externalRef")]
		public string ExternalRef
		{
			get
			{
				return externalRefField;
			}
			set
			{
				externalRefField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlMetadataItem
	{
		private PageXmlLabels[] labelsField;

		private PageXmlMetadataItemType typeField;

		private bool typeFieldSpecified;

		private string nameField;

		private string valueField;

		private DateTime dateField;

		private bool dateFieldSpecified;

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlMetadataItemType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("name")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		[XmlAttribute("value")]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
			}
		}

		[XmlAttribute("date")]
		public DateTime Date
		{
			get
			{
				return dateField;
			}
			set
			{
				dateField = value;
				dateFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool DateSpecified
		{
			get
			{
				return dateFieldSpecified;
			}
			set
			{
				dateFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(AnonymousType = true, Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlMetadataItemType
	{
		[XmlEnum("author")]
		Author,
		[XmlEnum("imageProperties")]
		ImageProperties,
		[XmlEnum("processingStep")]
		ProcessingStep,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlMusicRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlNoiseRegion : PageXmlRegion
	{
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlNonPrintingChar : PageXmlGraphemeBase
	{
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlOrderedGroup
	{
		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private object[] itemsField;

		private string idField;

		private string regionRefField;

		private string captionField;

		private PageXmlGroupSimpleType typeField;

		private bool typeFieldSpecified;

		private bool continuationField;

		private bool continuationFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlElement("OrderedGroupIndexed", typeof(PageXmlOrderedGroupIndexed))]
		[XmlElement("RegionRefIndexed", typeof(PageXmlRegionRefIndexed))]
		[XmlElement("UnorderedGroupIndexed", typeof(PageXmlUnorderedGroupIndexed))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string regionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}

		[XmlAttribute("caption")]
		public string Caption
		{
			get
			{
				return captionField;
			}
			set
			{
				captionField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlGroupSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("continuation")]
		public bool Continuation
		{
			get
			{
				return continuationField;
			}
			set
			{
				continuationField = value;
				continuationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ContinuationSpecified
		{
			get
			{
				return continuationFieldSpecified;
			}
			set
			{
				continuationFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlOrderedGroupIndexed
	{
		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private object[] itemsField;

		private string idField;

		private string regionRefField;

		private int indexField;

		private string captionField;

		private PageXmlGroupSimpleType typeField;

		private bool typeFieldSpecified;

		private bool continuationField;

		private bool continuationFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlElement("OrderedGroupIndexed", typeof(PageXmlOrderedGroupIndexed))]
		[XmlElement("RegionRefIndexed", typeof(PageXmlRegionRefIndexed))]
		[XmlElement("UnorderedGroupIndexed", typeof(PageXmlUnorderedGroupIndexed))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string RegionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}

		[XmlAttribute("index")]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("caption")]
		public string Caption
		{
			get
			{
				return captionField;
			}
			set
			{
				captionField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlGroupSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("continuation")]
		public bool Continuation
		{
			get
			{
				return continuationField;
			}
			set
			{
				continuationField = value;
				continuationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ContinuationSpecified
		{
			get
			{
				return continuationFieldSpecified;
			}
			set
			{
				continuationFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlPage
	{
		private PageXmlAlternativeImage[] alternativeImageField;

		private PageXmlBorder borderField;

		private PageXmlPrintSpace printSpaceField;

		private PageXmlReadingOrder readingOrderField;

		private PageXmlLayers layersField;

		private PageXmlRelations relationsField;

		private PageXmlTextStyle textStyleField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private PageXmlRegion[] itemsField;

		private string imageFilenameField;

		private int imageWidthField;

		private int imageHeightField;

		private float imageXResolutionField;

		private bool imageXResolutionFieldSpecified;

		private float imageYResolutionField;

		private bool imageYResolutionFieldSpecified;

		private PageXmlPageImageResolutionUnit imageResolutionUnitField;

		private bool imageResolutionUnitFieldSpecified;

		private string customField;

		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlPageSimpleType typeField;

		private bool typeFieldSpecified;

		private PageXmlLanguageSimpleType primaryLanguageField;

		private bool primaryLanguageFieldSpecified;

		private PageXmlLanguageSimpleType secondaryLanguageField;

		private bool secondaryLanguageFieldSpecified;

		private PageXmlScriptSimpleType primaryScriptField;

		private bool primaryScriptFieldSpecified;

		private PageXmlScriptSimpleType secondaryScriptField;

		private bool secondaryScriptFieldSpecified;

		private PageXmlReadingDirectionSimpleType readingDirectionField;

		private bool readingDirectionFieldSpecified;

		private PageXmlTextLineOrderSimpleType textLineOrderField;

		private bool textLineOrderFieldSpecified;

		private float confField;

		private bool confFieldSpecified;

		[XmlElement("AlternativeImage")]
		public PageXmlAlternativeImage[] AlternativeImage
		{
			get
			{
				return alternativeImageField;
			}
			set
			{
				alternativeImageField = value;
			}
		}

		public PageXmlBorder Border
		{
			get
			{
				return borderField;
			}
			set
			{
				borderField = value;
			}
		}

		public PageXmlPrintSpace PrintSpace
		{
			get
			{
				return printSpaceField;
			}
			set
			{
				printSpaceField = value;
			}
		}

		public PageXmlReadingOrder ReadingOrder
		{
			get
			{
				return readingOrderField;
			}
			set
			{
				readingOrderField = value;
			}
		}

		public PageXmlLayers Layers
		{
			get
			{
				return layersField;
			}
			set
			{
				layersField = value;
			}
		}

		public PageXmlRelations Relations
		{
			get
			{
				return relationsField;
			}
			set
			{
				relationsField = value;
			}
		}

		public PageXmlTextStyle TextStyle
		{
			get
			{
				return textStyleField;
			}
			set
			{
				textStyleField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlElement("AdvertRegion", typeof(PageXmlAdvertRegion))]
		[XmlElement("ChartRegion", typeof(PageXmlChartRegion))]
		[XmlElement("ChemRegion", typeof(PageXmlChemRegion))]
		[XmlElement("CustomRegion", typeof(PageXmlCustomRegion))]
		[XmlElement("GraphicRegion", typeof(PageXmlGraphicRegion))]
		[XmlElement("ImageRegion", typeof(PageXmlImageRegion))]
		[XmlElement("LineDrawingRegion", typeof(PageXmlLineDrawingRegion))]
		[XmlElement("MapRegion", typeof(PageXmlMapRegion))]
		[XmlElement("MathsRegion", typeof(PageXmlMathsRegion))]
		[XmlElement("MusicRegion", typeof(PageXmlMusicRegion))]
		[XmlElement("NoiseRegion", typeof(PageXmlNoiseRegion))]
		[XmlElement("SeparatorRegion", typeof(PageXmlSeparatorRegion))]
		[XmlElement("TableRegion", typeof(PageXmlTableRegion))]
		[XmlElement("TextRegion", typeof(PageXmlTextRegion))]
		[XmlElement("UnknownRegion", typeof(PageXmlUnknownRegion))]
		public PageXmlRegion[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("imageFilename")]
		public string ImageFilename
		{
			get
			{
				return imageFilenameField;
			}
			set
			{
				imageFilenameField = value;
			}
		}

		[XmlAttribute("imageWidth")]
		public int ImageWidth
		{
			get
			{
				return imageWidthField;
			}
			set
			{
				imageWidthField = value;
			}
		}

		[XmlAttribute("imageHeight")]
		public int ImageHeight
		{
			get
			{
				return imageHeightField;
			}
			set
			{
				imageHeightField = value;
			}
		}

		[XmlAttribute("imageXResolution")]
		public float ImageXResolution
		{
			get
			{
				return imageXResolutionField;
			}
			set
			{
				imageXResolutionField = value;
				imageXResolutionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ImageXResolutionSpecified
		{
			get
			{
				return imageXResolutionFieldSpecified;
			}
			set
			{
				imageXResolutionFieldSpecified = value;
			}
		}

		[XmlAttribute("imageYResolution")]
		public float ImageYResolution
		{
			get
			{
				return imageYResolutionField;
			}
			set
			{
				imageYResolutionField = value;
				imageYResolutionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ImageYResolutionSpecified
		{
			get
			{
				return imageYResolutionFieldSpecified;
			}
			set
			{
				imageYResolutionFieldSpecified = value;
			}
		}

		[XmlAttribute("imageResolutionUnit")]
		public PageXmlPageImageResolutionUnit ImageResolutionUnit
		{
			get
			{
				return imageResolutionUnitField;
			}
			set
			{
				imageResolutionUnitField = value;
				imageResolutionUnitFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ImageResolutionUnitSpecified
		{
			get
			{
				return imageResolutionUnitFieldSpecified;
			}
			set
			{
				imageResolutionUnitFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlPageSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryLanguage")]
		public PageXmlLanguageSimpleType PrimaryLanguage
		{
			get
			{
				return primaryLanguageField;
			}
			set
			{
				primaryLanguageField = value;
				primaryLanguageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryLanguageSpecified
		{
			get
			{
				return primaryLanguageFieldSpecified;
			}
			set
			{
				primaryLanguageFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryLanguage")]
		public PageXmlLanguageSimpleType SecondaryLanguage
		{
			get
			{
				return secondaryLanguageField;
			}
			set
			{
				secondaryLanguageField = value;
				secondaryLanguageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryLanguageSpecified
		{
			get
			{
				return secondaryLanguageFieldSpecified;
			}
			set
			{
				secondaryLanguageFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryScript")]
		public PageXmlScriptSimpleType PrimaryScript
		{
			get
			{
				return primaryScriptField;
			}
			set
			{
				primaryScriptField = value;
				primaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryScriptSpecified
		{
			get
			{
				return primaryScriptFieldSpecified;
			}
			set
			{
				primaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryScript")]
		public PageXmlScriptSimpleType SecondaryScript
		{
			get
			{
				return secondaryScriptField;
			}
			set
			{
				secondaryScriptField = value;
				secondaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryScriptSpecified
		{
			get
			{
				return secondaryScriptFieldSpecified;
			}
			set
			{
				secondaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("readingDirection")]
		public PageXmlReadingDirectionSimpleType ReadingDirection
		{
			get
			{
				return readingDirectionField;
			}
			set
			{
				readingDirectionField = value;
				readingDirectionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReadingDirectionSpecified
		{
			get
			{
				return readingDirectionFieldSpecified;
			}
			set
			{
				readingDirectionFieldSpecified = value;
			}
		}

		[XmlAttribute("textLineOrder")]
		public PageXmlTextLineOrderSimpleType TextLineOrder
		{
			get
			{
				return textLineOrderField;
			}
			set
			{
				textLineOrderField = value;
				textLineOrderFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TextLineOrderSpecified
		{
			get
			{
				return textLineOrderFieldSpecified;
			}
			set
			{
				textLineOrderFieldSpecified = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(AnonymousType = true, Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlPageImageResolutionUnit
	{
		PPI,
		PPCM,
		[XmlEnum("other")]
		other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlPageSimpleType
	{
		[XmlEnum("front-cover")]
		FrontCover,
		[XmlEnum("back-cover")]
		BackCover,
		[XmlEnum("title")]
		Title,
		[XmlEnum("table-of-contents")]
		TableOfContents,
		[XmlEnum("index")]
		Index,
		[XmlEnum("content")]
		Content,
		[XmlEnum("blank")]
		Blank,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlPrintSpace
	{
		private PageXmlCoords coordsField;

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlProductionSimpleType
	{
		[XmlEnum("printed")]
		Printed,
		[XmlEnum("typewritten")]
		Typewritten,
		[XmlEnum("handwritten-cursive")]
		HandwrittenCursive,
		[XmlEnum("handwritten-printscript")]
		HandwrittenPrintscript,
		[XmlEnum("medieval-manuscript")]
		MedievalManuscript,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlReadingDirectionSimpleType
	{
		[XmlEnum("left-to-right")]
		LeftToRight,
		[XmlEnum("right-to-left")]
		RightToLeft,
		[XmlEnum("top-to-bottom")]
		TopToBottom,
		[XmlEnum("bottom-to-top")]
		BottomToTop
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlReadingOrder
	{
		private object itemField;

		private float confField;

		private bool confFieldSpecified;

		[XmlElement("OrderedGroup", typeof(PageXmlOrderedGroup))]
		[XmlElement("UnorderedGroup", typeof(PageXmlUnorderedGroup))]
		public object Item
		{
			get
			{
				return itemField;
			}
			set
			{
				itemField = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlInclude(typeof(PageXmlMapRegion))]
	[XmlInclude(typeof(PageXmlCustomRegion))]
	[XmlInclude(typeof(PageXmlUnknownRegion))]
	[XmlInclude(typeof(PageXmlNoiseRegion))]
	[XmlInclude(typeof(PageXmlAdvertRegion))]
	[XmlInclude(typeof(PageXmlMusicRegion))]
	[XmlInclude(typeof(PageXmlChemRegion))]
	[XmlInclude(typeof(PageXmlMathsRegion))]
	[XmlInclude(typeof(PageXmlSeparatorRegion))]
	[XmlInclude(typeof(PageXmlChartRegion))]
	[XmlInclude(typeof(PageXmlTableRegion))]
	[XmlInclude(typeof(PageXmlGraphicRegion))]
	[XmlInclude(typeof(PageXmlLineDrawingRegion))]
	[XmlInclude(typeof(PageXmlImageRegion))]
	[XmlInclude(typeof(PageXmlTextRegion))]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public abstract class PageXmlRegion
	{
		private PageXmlAlternativeImage[] alternativeImageField;

		private PageXmlCoords coordsField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private PageXmlRoles rolesField;

		private PageXmlRegion[] itemsField;

		private string idField;

		private string customField;

		private string commentsField;

		private bool continuationField;

		private bool continuationFieldSpecified;

		[XmlElement("AlternativeImage")]
		public PageXmlAlternativeImage[] AlternativeImage
		{
			get
			{
				return alternativeImageField;
			}
			set
			{
				alternativeImageField = value;
			}
		}

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		public PageXmlRoles Roles
		{
			get
			{
				return rolesField;
			}
			set
			{
				rolesField = value;
			}
		}

		[XmlElement("AdvertRegion", typeof(PageXmlAdvertRegion))]
		[XmlElement("ChartRegion", typeof(PageXmlChartRegion))]
		[XmlElement("ChemRegion", typeof(PageXmlChemRegion))]
		[XmlElement("CustomRegion", typeof(PageXmlCustomRegion))]
		[XmlElement("GraphicRegion", typeof(PageXmlGraphicRegion))]
		[XmlElement("ImageRegion", typeof(PageXmlImageRegion))]
		[XmlElement("LineDrawingRegion", typeof(PageXmlLineDrawingRegion))]
		[XmlElement("MathsRegion", typeof(PageXmlMathsRegion))]
		[XmlElement("MusicRegion", typeof(PageXmlMusicRegion))]
		[XmlElement("NoiseRegion", typeof(PageXmlNoiseRegion))]
		[XmlElement("SeparatorRegion", typeof(PageXmlSeparatorRegion))]
		[XmlElement("TableRegion", typeof(PageXmlTableRegion))]
		[XmlElement("TextRegion", typeof(PageXmlTextRegion))]
		[XmlElement("UnknownRegion", typeof(PageXmlUnknownRegion))]
		public PageXmlRegion[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		[XmlAttribute("continuation")]
		public bool Continuation
		{
			get
			{
				return continuationField;
			}
			set
			{
				continuationField = value;
				continuationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ContinuationSpecified
		{
			get
			{
				return continuationFieldSpecified;
			}
			set
			{
				continuationFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlRegionRef
	{
		private string regionRefField;

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string RegionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlRegionRefIndexed
	{
		private int indexField;

		private string regionRefField;

		[XmlAttribute("index")]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string RegionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlRelation
	{
		private PageXmlLabels[] labelsField;

		private PageXmlRegionRef sourceRegionRefField;

		private PageXmlRegionRef targetRegionRefField;

		private string idField;

		private PageXmlRelationType typeField;

		private bool typeFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		public PageXmlRegionRef SourceRegionRef
		{
			get
			{
				return sourceRegionRefField;
			}
			set
			{
				sourceRegionRefField = value;
			}
		}

		public PageXmlRegionRef TargetRegionRef
		{
			get
			{
				return targetRegionRefField;
			}
			set
			{
				targetRegionRefField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlRelationType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlRelations
	{
		private PageXmlRelation[] relationField;

		[XmlElement("Relation")]
		public PageXmlRelation[] Relations
		{
			get
			{
				return relationField;
			}
			set
			{
				relationField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(AnonymousType = true, Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlRelationType
	{
		[XmlEnum("link")]
		Link,
		[XmlEnum("join")]
		Join
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlRoles
	{
		private PageXmlTableCellRole tableCellRoleField;

		public PageXmlTableCellRole TableCellRole
		{
			get
			{
				return tableCellRoleField;
			}
			set
			{
				tableCellRoleField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlScriptSimpleType
	{
		[XmlEnum("Adlm - Adlam")]
		AdlmAdlam,
		[XmlEnum("Afak - Afaka")]
		AfakAfaka,
		[XmlEnum("Aghb - Caucasian Albanian")]
		AghbCaucasianAlbanian,
		[XmlEnum("Ahom - Ahom, Tai Ahom")]
		AhomAhomTaiAhom,
		[XmlEnum("Arab - Arabic")]
		ArabArabic,
		[XmlEnum("Aran - Arabic (Nastaliq variant)")]
		AranArabicNastaliqVariant,
		[XmlEnum("Armi - Imperial Aramaic")]
		ArmiImperialAramaic,
		[XmlEnum("Armn - Armenian")]
		ArmnArmenian,
		[XmlEnum("Avst - Avestan")]
		AvstAvestan,
		[XmlEnum("Bali - Balinese")]
		BaliBalinese,
		[XmlEnum("Bamu - Bamum")]
		BamuBamum,
		[XmlEnum("Bass - Bassa Vah")]
		BassBassaVah,
		[XmlEnum("Batk - Batak")]
		BatkBatak,
		[XmlEnum("Beng - Bengali")]
		BengBengali,
		[XmlEnum("Bhks - Bhaiksuki")]
		BhksBhaiksuki,
		[XmlEnum("Blis - Blissymbols")]
		BlisBlissymbols,
		[XmlEnum("Bopo - Bopomofo")]
		BopoBopomofo,
		[XmlEnum("Brah - Brahmi")]
		BrahBrahmi,
		[XmlEnum("Brai - Braille")]
		BraiBraille,
		[XmlEnum("Bugi - Buginese")]
		BugiBuginese,
		[XmlEnum("Buhd - Buhid")]
		BuhdBuhid,
		[XmlEnum("Cakm - Chakma")]
		CakmChakma,
		[XmlEnum("Cans - Unified Canadian Aboriginal Syllabics")]
		CansUnifiedCanadianAboriginalSyllabics,
		[XmlEnum("Cari - Carian")]
		CariCarian,
		[XmlEnum("Cham - Cham")]
		ChamCham,
		[XmlEnum("Cher - Cherokee")]
		CherCherokee,
		[XmlEnum("Cirt - Cirth")]
		CirtCirth,
		[XmlEnum("Copt - Coptic")]
		CoptCoptic,
		[XmlEnum("Cprt - Cypriot")]
		CprtCypriot,
		[XmlEnum("Cyrl - Cyrillic")]
		CyrlCyrillic,
		[XmlEnum("Cyrs - Cyrillic (Old Church Slavonic variant)")]
		CyrsCyrillicOldChurchSlavonicVariant,
		[XmlEnum("Deva - Devanagari (Nagari)")]
		DevaDevanagariNagari,
		[XmlEnum("Dsrt - Deseret (Mormon)")]
		DsrtDeseretMormon,
		[XmlEnum("Dupl - Duployan shorthand, Duployan stenography")]
		DuplDuployanShorthandDuployanStenography,
		[XmlEnum("Egyd - Egyptian demotic")]
		EgydEgyptianDemotic,
		[XmlEnum("Egyh - Egyptian hieratic")]
		EgyhEgyptianHieratic,
		[XmlEnum("Egyp - Egyptian hieroglyphs")]
		EgypEgyptianHieroglyphs,
		[XmlEnum("Elba - Elbasan")]
		ElbaElbasan,
		[XmlEnum("Ethi - Ethiopic")]
		EthiEthiopic,
		[XmlEnum("Geok - Khutsuri (Asomtavruli and Nuskhuri)")]
		GeokKhutsuriAsomtavruliAndNuskhuri,
		[XmlEnum("Geor - Georgian (Mkhedruli)")]
		GeorGeorgianMkhedruli,
		[XmlEnum("Glag - Glagolitic")]
		GlagGlagolitic,
		[XmlEnum("Goth - Gothic")]
		GothGothic,
		[XmlEnum("Gran - Grantha")]
		GranGrantha,
		[XmlEnum("Grek - Greek")]
		GrekGreek,
		[XmlEnum("Gujr - Gujarati")]
		GujrGujarati,
		[XmlEnum("Guru - Gurmukhi")]
		GuruGurmukhi,
		[XmlEnum("Hanb - Han with Bopomofo")]
		HanbHanwithBopomofo,
		[XmlEnum("Hang - Hangul")]
		HangHangul,
		[XmlEnum("Hani - Han (Hanzi, Kanji, Hanja)")]
		HaniHanHanziKanjiHanja,
		[XmlEnum("Hano - Hanunoo (Hanunóo)")]
		HanoHanunooHanunóo,
		[XmlEnum("Hans - Han (Simplified variant)")]
		HansHanSimplifiedVariant,
		[XmlEnum("Hant - Han (Traditional variant)")]
		HantHanTraditionalVariant,
		[XmlEnum("Hatr - Hatran")]
		HatrHatran,
		[XmlEnum("Hebr - Hebrew")]
		HebrHebrew,
		[XmlEnum("Hira - Hiragana")]
		HiraHiragana,
		[XmlEnum("Hluw - Anatolian Hieroglyphs")]
		HluwAnatolianHieroglyphs,
		[XmlEnum("Hmng - Pahawh Hmong")]
		HmngPahawhHmong,
		[XmlEnum("Hrkt - Japanese syllabaries")]
		HrktJapaneseSyllabaries,
		[XmlEnum("Hung - Old Hungarian (Hungarian Runic)")]
		HungOldHungarianHungarianRunic,
		[XmlEnum("Inds - Indus (Harappan)")]
		IndsIndusHarappan,
		[XmlEnum("Ital - Old Italic (Etruscan, Oscan etc.)")]
		ItalOldItalicEtruscanOscanEtc,
		[XmlEnum("Jamo - Jamo")]
		JamoJamo,
		[XmlEnum("Java - Javanese")]
		JavaJavanese,
		[XmlEnum("Jpan - Japanese")]
		JpanJapanese,
		[XmlEnum("Jurc - Jurchen")]
		JurcJurchen,
		[XmlEnum("Kali - Kayah Li")]
		KaliKayahLi,
		[XmlEnum("Kana - Katakana")]
		KanaKatakana,
		[XmlEnum("Khar - Kharoshthi")]
		KharKharoshthi,
		[XmlEnum("Khmr - Khmer")]
		KhmrKhmer,
		[XmlEnum("Khoj - Khojki")]
		KhojKhojki,
		[XmlEnum("Kitl - Khitan large script")]
		KitlKhitanlargescript,
		[XmlEnum("Kits - Khitan small script")]
		KitsKhitansmallscript,
		[XmlEnum("Knda - Kannada")]
		KndaKannada,
		[XmlEnum("Kore - Korean (alias for Hangul + Han)")]
		KoreKoreanaliasforHangulHan,
		[XmlEnum("Kpel - Kpelle")]
		KpelKpelle,
		[XmlEnum("Kthi - Kaithi")]
		KthiKaithi,
		[XmlEnum("Lana - Tai Tham (Lanna)")]
		LanaTaiThamLanna,
		[XmlEnum("Laoo - Lao")]
		LaooLao,
		[XmlEnum("Latf - Latin (Fraktur variant)")]
		LatfLatinFrakturvariant,
		[XmlEnum("Latg - Latin (Gaelic variant)")]
		LatgLatinGaelicvariant,
		[XmlEnum("Latn - Latin")]
		LatnLatin,
		[XmlEnum("Leke - Leke")]
		LekeLeke,
		[XmlEnum("Lepc - Lepcha (Róng)")]
		LepcLepchaRóng,
		[XmlEnum("Limb - Limbu")]
		LimbLimbu,
		[XmlEnum("Lina - Linear A")]
		LinaLinearA,
		[XmlEnum("Linb - Linear B")]
		LinbLinearB,
		[XmlEnum("Lisu - Lisu (Fraser)")]
		LisuLisuFraser,
		[XmlEnum("Loma - Loma")]
		LomaLoma,
		[XmlEnum("Lyci - Lycian")]
		LyciLycian,
		[XmlEnum("Lydi - Lydian")]
		LydiLydian,
		[XmlEnum("Mahj - Mahajani")]
		MahjMahajani,
		[XmlEnum("Mand - Mandaic, Mandaean")]
		MandMandaicMandaean,
		[XmlEnum("Mani - Manichaean")]
		ManiManichaean,
		[XmlEnum("Marc - Marchen")]
		MarcMarchen,
		[XmlEnum("Maya - Mayan hieroglyphs")]
		MayaMayanhieroglyphs,
		[XmlEnum("Mend - Mende Kikakui")]
		MendMendeKikakui,
		[XmlEnum("Merc - Meroitic Cursive")]
		MercMeroiticCursive,
		[XmlEnum("Mero - Meroitic Hieroglyphs")]
		MeroMeroiticHieroglyphs,
		[XmlEnum("Mlym - Malayalam")]
		MlymMalayalam,
		[XmlEnum("Modi - Modi, Moḍī")]
		ModiModiMoḍī,
		[XmlEnum("Mong - Mongolian")]
		MongMongolian,
		[XmlEnum("Moon - Moon (Moon code, Moon script, Moon type)")]
		MoonMoonMooncodeMoonscriptMoontype,
		[XmlEnum("Mroo - Mro, Mru")]
		MrooMroMru,
		[XmlEnum("Mtei - Meitei Mayek (Meithei, Meetei)")]
		MteiMeiteiMayekMeitheiMeetei,
		[XmlEnum("Mult - Multani")]
		MultMultani,
		[XmlEnum("Mymr - Myanmar (Burmese)")]
		MymrMyanmarBurmese,
		[XmlEnum("Narb - Old North Arabian (Ancient North Arabian)")]
		NarbOldNorthArabianAncientNorthArabian,
		[XmlEnum("Nbat - Nabataean")]
		NbatNabataean,
		[XmlEnum("Newa - Newa, Newar, Newari")]
		NewaNewaNewarNewari,
		[XmlEnum("Nkgb - Nakhi Geba")]
		NkgbNakhiGeba,
		[XmlEnum("Nkoo - N’Ko")]
		NkooNKo,
		[XmlEnum("Nshu - Nüshu")]
		NshuNüshu,
		[XmlEnum("Ogam - Ogham")]
		OgamOgham,
		[XmlEnum("Olck - Ol Chiki (Ol Cemet’, Ol, Santali)")]
		OlckOlChikiOlCemetOlSantali,
		[XmlEnum("Orkh - Old Turkic, Orkhon Runic")]
		OrkhOldTurkicOrkhonRunic,
		[XmlEnum("Orya - Oriya")]
		OryaOriya,
		[XmlEnum("Osge - Osage")]
		OsgeOsage,
		[XmlEnum("Osma - Osmanya")]
		OsmaOsmanya,
		[XmlEnum("Palm - Palmyrene")]
		PalmPalmyrene,
		[XmlEnum("Pauc - Pau Cin Hau")]
		PaucPauCinHau,
		[XmlEnum("Perm - Old Permic")]
		PermOldPermic,
		[XmlEnum("Phag - Phags-pa")]
		PhagPhagspa,
		[XmlEnum("Phli - Inscriptional Pahlavi")]
		PhliInscriptionalPahlavi,
		[XmlEnum("Phlp - Psalter Pahlavi")]
		PhlpPsalterPahlavi,
		[XmlEnum("Phlv - Book Pahlavi")]
		PhlvBookPahlavi,
		[XmlEnum("Phnx - Phoenician")]
		PhnxPhoenician,
		[XmlEnum("Piqd - Klingon (KLI pIqaD)")]
		PiqdKlingonKLIpIqaD,
		[XmlEnum("Plrd - Miao (Pollard)")]
		PlrdMiaoPollard,
		[XmlEnum("Prti - Inscriptional Parthian")]
		PrtiInscriptionalParthian,
		[XmlEnum("Rjng - Rejang (Redjang, Kaganga)")]
		RjngRejangRedjangKaganga,
		[XmlEnum("Roro - Rongorongo")]
		RoroRongorongo,
		[XmlEnum("Runr - Runic")]
		RunrRunic,
		[XmlEnum("Samr - Samaritan")]
		SamrSamaritan,
		[XmlEnum("Sara - Sarati")]
		SaraSarati,
		[XmlEnum("Sarb - Old South Arabian")]
		SarbOldSouthArabian,
		[XmlEnum("Saur - Saurashtra")]
		SaurSaurashtra,
		[XmlEnum("Sgnw - SignWriting")]
		SgnwSignWriting,
		[XmlEnum("Shaw - Shavian (Shaw)")]
		ShawShavianShaw,
		[XmlEnum("Shrd - Sharada, Śāradā")]
		ShrdSharadaŚāradā,
		[XmlEnum("Sidd - Siddham")]
		SiddSiddham,
		[XmlEnum("Sind - Khudawadi, Sindhi")]
		SindKhudawadiSindhi,
		[XmlEnum("Sinh - Sinhala")]
		SinhSinhala,
		[XmlEnum("Sora - Sora Sompeng")]
		SoraSoraSompeng,
		[XmlEnum("Sund - Sundanese")]
		SundSundanese,
		[XmlEnum("Sylo - Syloti Nagri")]
		SyloSylotiNagri,
		[XmlEnum("Syrc - Syriac")]
		SyrcSyriac,
		[XmlEnum("Syre - Syriac (Estrangelo variant)")]
		SyreSyriacEstrangeloVariant,
		[XmlEnum("Syrj - Syriac (Western variant)")]
		SyrjSyriacWesternVariant,
		[XmlEnum("Syrn - Syriac (Eastern variant)")]
		SyrnSyriacEasternVariant,
		[XmlEnum("Tagb - Tagbanwa")]
		TagbTagbanwa,
		[XmlEnum("Takr - Takri")]
		TakrTakri,
		[XmlEnum("Tale - Tai Le")]
		TaleTaiLe,
		[XmlEnum("Talu - New Tai Lue")]
		TaluNewTaiLue,
		[XmlEnum("Taml - Tamil")]
		TamlTamil,
		[XmlEnum("Tang - Tangut")]
		TangTangut,
		[XmlEnum("Tavt - Tai Viet")]
		TavtTaiViet,
		[XmlEnum("Telu - Telugu")]
		TeluTelugu,
		[XmlEnum("Teng - Tengwar")]
		TengTengwar,
		[XmlEnum("Tfng - Tifinagh (Berber)")]
		TfngTifinaghBerber,
		[XmlEnum("Tglg - Tagalog (Baybayin, Alibata)")]
		TglgTagalogBaybayinAlibata,
		[XmlEnum("Thaa - Thaana")]
		ThaaThaana,
		[XmlEnum("Thai - Thai")]
		ThaiThai,
		[XmlEnum("Tibt - Tibetan")]
		TibtTibetan,
		[XmlEnum("Tirh - Tirhuta")]
		TirhTirhuta,
		[XmlEnum("Ugar - Ugaritic")]
		UgarUgaritic,
		[XmlEnum("Vaii - Vai")]
		VaiiVai,
		[XmlEnum("Visp - Visible Speech")]
		VispVisibleSpeech,
		[XmlEnum("Wara - Warang Citi (Varang Kshiti)")]
		WaraWarangCitiVarangKshiti,
		[XmlEnum("Wole - Woleai")]
		WoleWoleai,
		[XmlEnum("Xpeo - Old Persian")]
		XpeoOldPersian,
		[XmlEnum("Xsux - Cuneiform, Sumero-Akkadian")]
		XsuxCuneiformSumeroAkkadian,
		[XmlEnum("Yiii - Yi")]
		YiiiYi,
		[XmlEnum("Zinh - Code for inherited script")]
		ZinhCodeForInheritedScript,
		[XmlEnum("Zmth - Mathematical notation")]
		ZmthMathematicalNotation,
		[XmlEnum("Zsye - Symbols (Emoji variant)")]
		ZsyeSymbolsEmojiVariant,
		[XmlEnum("Zsym - Symbols")]
		ZsymSymbols,
		[XmlEnum("Zxxx - Code for unwritten documents")]
		ZxxxCodeForUnwrittenDocuments,
		[XmlEnum("Zyyy - Code for undetermined script")]
		ZyyyCodeForUndeterminedScript,
		[XmlEnum("Zzzz - Code for uncoded script")]
		ZzzzCodeForUncodedScript,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlSeparatorRegion : PageXmlRegion
	{
		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlColourSimpleType colourField;

		private bool colourFieldSpecified;

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("colour")]
		public PageXmlColourSimpleType Colour
		{
			get
			{
				return colourField;
			}
			set
			{
				colourField = value;
				colourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ColourSpecified
		{
			get
			{
				return colourFieldSpecified;
			}
			set
			{
				colourFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTableCellRole
	{
		private int rowIndexField;

		private int columnIndexField;

		private int rowSpanField;

		private bool rowSpanFieldSpecified;

		private int colSpanField;

		private bool colSpanFieldSpecified;

		private bool headerField;

		private bool headerFieldSpecified;

		[XmlAttribute("rowIndex")]
		public int RowIndex
		{
			get
			{
				return rowIndexField;
			}
			set
			{
				rowIndexField = value;
			}
		}

		[XmlAttribute("columnIndex")]
		public int ColumnIndex
		{
			get
			{
				return columnIndexField;
			}
			set
			{
				columnIndexField = value;
			}
		}

		[XmlAttribute("rowSpan")]
		public int RowSpan
		{
			get
			{
				return rowSpanField;
			}
			set
			{
				rowSpanField = value;
				rowSpanFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool RowSpanSpecified
		{
			get
			{
				return rowSpanFieldSpecified;
			}
			set
			{
				rowSpanFieldSpecified = value;
			}
		}

		[XmlAttribute("colSpan")]
		public int ColSpan
		{
			get
			{
				return colSpanField;
			}
			set
			{
				colSpanField = value;
				colSpanFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ColSpanSpecified
		{
			get
			{
				return colSpanFieldSpecified;
			}
			set
			{
				colSpanFieldSpecified = value;
			}
		}

		[XmlAttribute("header")]
		public bool Header
		{
			get
			{
				return headerField;
			}
			set
			{
				headerField = value;
				headerFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool HeaderSpecified
		{
			get
			{
				return headerFieldSpecified;
			}
			set
			{
				headerFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTableRegion : PageXmlRegion
	{
		private PageXmlGridPoints[] gridField;

		private float orientationField;

		private bool orientationFieldSpecified;

		private int rowsField;

		private bool rowsFieldSpecified;

		private int columnsField;

		private bool columnsFieldSpecified;

		private PageXmlColourSimpleType lineColourField;

		private bool lineColourFieldSpecified;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		private bool lineSeparatorsField;

		private bool lineSeparatorsFieldSpecified;

		private bool embTextField;

		private bool embTextFieldSpecified;

		[XmlArrayItem("GridPoints", IsNullable = false)]
		public PageXmlGridPoints[] Grid
		{
			get
			{
				return gridField;
			}
			set
			{
				gridField = value;
			}
		}

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("rows")]
		public int Rows
		{
			get
			{
				return rowsField;
			}
			set
			{
				rowsField = value;
				rowsFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool RowsSpecified
		{
			get
			{
				return rowsFieldSpecified;
			}
			set
			{
				rowsFieldSpecified = value;
			}
		}

		[XmlAttribute("columns")]
		public int Columns
		{
			get
			{
				return columnsField;
			}
			set
			{
				columnsField = value;
				columnsFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ColumnsSpecified
		{
			get
			{
				return columnsFieldSpecified;
			}
			set
			{
				columnsFieldSpecified = value;
			}
		}

		[XmlAttribute("lineColour")]
		public PageXmlColourSimpleType LineColour
		{
			get
			{
				return lineColourField;
			}
			set
			{
				lineColourField = value;
				lineColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LineColourSpecified
		{
			get
			{
				return lineColourFieldSpecified;
			}
			set
			{
				lineColourFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}

		[XmlAttribute("lineSeparators")]
		public bool LineSeparators
		{
			get
			{
				return lineSeparatorsField;
			}
			set
			{
				lineSeparatorsField = value;
				lineSeparatorsFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LineSeparatorsSpecified
		{
			get
			{
				return lineSeparatorsFieldSpecified;
			}
			set
			{
				lineSeparatorsFieldSpecified = value;
			}
		}

		[XmlAttribute("embText")]
		public bool EmbText
		{
			get
			{
				return embTextField;
			}
			set
			{
				embTextField = value;
				embTextFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool EmbTextSpecified
		{
			get
			{
				return embTextFieldSpecified;
			}
			set
			{
				embTextFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlTextDataSimpleType
	{
		[XmlEnum("xsd:double")]
		Xsddouble,
		[XmlEnum("xsd:float")]
		XsdFloat,
		[XmlEnum("xsd:integer")]
		XsdInteger,
		[XmlEnum("xsd:boolean")]
		XsdBoolean,
		[XmlEnum("xsd:date")]
		XsdDate,
		[XmlEnum("xsd:time")]
		XsdTime,
		[XmlEnum("xsd:dateTime")]
		XsdDateTime,
		[XmlEnum("xsd:string")]
		XsdString,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTextEquiv
	{
		private string plainTextField;

		private string unicodeField;

		private string indexField;

		private float confField;

		private bool confFieldSpecified;

		private PageXmlTextDataSimpleType dataTypeField;

		private bool dataTypeFieldSpecified;

		private string dataTypeDetailsField;

		private string commentsField;

		public string PlainText
		{
			get
			{
				return plainTextField;
			}
			set
			{
				plainTextField = value;
			}
		}

		public string Unicode
		{
			get
			{
				return unicodeField;
			}
			set
			{
				unicodeField = value;
			}
		}

		[XmlAttribute("index", DataType = "integer")]
		public string Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("conf")]
		public float Conf
		{
			get
			{
				return confField;
			}
			set
			{
				confField = value;
				confFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ConfSpecified
		{
			get
			{
				return confFieldSpecified;
			}
			set
			{
				confFieldSpecified = value;
			}
		}

		[XmlAttribute("dataType")]
		public PageXmlTextDataSimpleType DataType
		{
			get
			{
				return dataTypeField;
			}
			set
			{
				dataTypeField = value;
				dataTypeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool DataTypeSpecified
		{
			get
			{
				return dataTypeFieldSpecified;
			}
			set
			{
				dataTypeFieldSpecified = value;
			}
		}

		[XmlAttribute("dataTypeDetails")]
		public string DataTypeDetails
		{
			get
			{
				return dataTypeDetailsField;
			}
			set
			{
				dataTypeDetailsField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		public override string ToString()
		{
			return Unicode;
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTextLine
	{
		private PageXmlAlternativeImage[] alternativeImageField;

		private PageXmlCoords coordsField;

		private PageXmlBaseline baselineField;

		private PageXmlWord[] wordField;

		private PageXmlTextEquiv[] textEquivField;

		private PageXmlTextStyle textStyleField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private string idField;

		private PageXmlLanguageSimpleType primaryLanguageField;

		private bool primaryLanguageFieldSpecified;

		private PageXmlScriptSimpleType primaryScriptField;

		private bool primaryScriptFieldSpecified;

		private PageXmlScriptSimpleType secondaryScriptField;

		private bool secondaryScriptFieldSpecified;

		private PageXmlReadingDirectionSimpleType readingDirectionField;

		private bool readingDirectionFieldSpecified;

		private PageXmlProductionSimpleType productionField;

		private bool productionFieldSpecified;

		private string customField;

		private string commentsField;

		private int indexField;

		private bool indexFieldSpecified;

		[XmlElement("AlternativeImage")]
		public PageXmlAlternativeImage[] AlternativeImages
		{
			get
			{
				return alternativeImageField;
			}
			set
			{
				alternativeImageField = value;
			}
		}

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}

		public PageXmlBaseline Baseline
		{
			get
			{
				return baselineField;
			}
			set
			{
				baselineField = value;
			}
		}

		[XmlElement("Word")]
		public PageXmlWord[] Words
		{
			get
			{
				return wordField;
			}
			set
			{
				wordField = value;
			}
		}

		[XmlElement("TextEquiv")]
		public PageXmlTextEquiv[] TextEquivs
		{
			get
			{
				return textEquivField;
			}
			set
			{
				textEquivField = value;
			}
		}

		public PageXmlTextStyle TextStyle
		{
			get
			{
				return textStyleField;
			}
			set
			{
				textStyleField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("primaryLanguage")]
		public PageXmlLanguageSimpleType PrimaryLanguage
		{
			get
			{
				return primaryLanguageField;
			}
			set
			{
				primaryLanguageField = value;
				primaryLanguageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryLanguageSpecified
		{
			get
			{
				return primaryLanguageFieldSpecified;
			}
			set
			{
				primaryLanguageFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryScript")]
		public PageXmlScriptSimpleType PrimaryScript
		{
			get
			{
				return primaryScriptField;
			}
			set
			{
				primaryScriptField = value;
				primaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryScriptSpecified
		{
			get
			{
				return primaryScriptFieldSpecified;
			}
			set
			{
				primaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryScript")]
		public PageXmlScriptSimpleType SecondaryScript
		{
			get
			{
				return secondaryScriptField;
			}
			set
			{
				secondaryScriptField = value;
				secondaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryScriptSpecified
		{
			get
			{
				return secondaryScriptFieldSpecified;
			}
			set
			{
				secondaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("readingDirection")]
		public PageXmlReadingDirectionSimpleType ReadingDirection
		{
			get
			{
				return readingDirectionField;
			}
			set
			{
				readingDirectionField = value;
				readingDirectionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReadingDirectionSpecified
		{
			get
			{
				return readingDirectionFieldSpecified;
			}
			set
			{
				readingDirectionFieldSpecified = value;
			}
		}

		[XmlAttribute("production")]
		public PageXmlProductionSimpleType Production
		{
			get
			{
				return productionField;
			}
			set
			{
				productionField = value;
				productionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ProductionSpecified
		{
			get
			{
				return productionFieldSpecified;
			}
			set
			{
				productionFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		[XmlAttribute]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
				indexFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool IndexSpecified
		{
			get
			{
				return indexFieldSpecified;
			}
			set
			{
				indexFieldSpecified = value;
			}
		}

		public override string ToString()
		{
			return string.Join("\n", TextEquivs.Select((PageXmlTextEquiv t) => t.Unicode));
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlTextLineOrderSimpleType
	{
		[XmlEnum("top-to-bottom")]
		TopToBottom,
		[XmlEnum("bottom-to-top")]
		BottomToTop,
		[XmlEnum("left-to-right")]
		LeftToRight,
		[XmlEnum("right-to-left")]
		RightToLeft
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTextRegion : PageXmlRegion
	{
		private PageXmlTextLine[] textLineField;

		private PageXmlTextEquiv[] textEquivField;

		private PageXmlTextStyle textStyleField;

		private float orientationField;

		private bool orientationFieldSpecified;

		private PageXmlTextSimpleType typeField;

		private bool typeFieldSpecified;

		private int leadingField;

		private bool leadingFieldSpecified;

		private PageXmlReadingDirectionSimpleType readingDirectionField;

		private bool readingDirectionFieldSpecified;

		private PageXmlTextLineOrderSimpleType textLineOrderField;

		private bool textLineOrderFieldSpecified;

		private float readingOrientationField;

		private bool readingOrientationFieldSpecified;

		private bool indentedField;

		private bool indentedFieldSpecified;

		private PageXmlAlignSimpleType alignField;

		private bool alignFieldSpecified;

		private PageXmlLanguageSimpleType primaryLanguageField;

		private bool primaryLanguageFieldSpecified;

		private PageXmlLanguageSimpleType secondaryLanguageField;

		private bool secondaryLanguageFieldSpecified;

		private PageXmlScriptSimpleType primaryScriptField;

		private bool primaryScriptFieldSpecified;

		private PageXmlScriptSimpleType secondaryScriptField;

		private bool secondaryScriptFieldSpecified;

		private PageXmlProductionSimpleType productionField;

		private bool productionFieldSpecified;

		[XmlElement("TextLine")]
		public PageXmlTextLine[] TextLines
		{
			get
			{
				return textLineField;
			}
			set
			{
				textLineField = value;
			}
		}

		[XmlElement("TextEquiv")]
		public PageXmlTextEquiv[] TextEquivs
		{
			get
			{
				return textEquivField;
			}
			set
			{
				textEquivField = value;
			}
		}

		public PageXmlTextStyle TextStyle
		{
			get
			{
				return textStyleField;
			}
			set
			{
				textStyleField = value;
			}
		}

		[XmlAttribute("orientation")]
		public float Orientation
		{
			get
			{
				return orientationField;
			}
			set
			{
				orientationField = value;
				orientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool OrientationSpecified
		{
			get
			{
				return orientationFieldSpecified;
			}
			set
			{
				orientationFieldSpecified = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlTextSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("leading")]
		public int Leading
		{
			get
			{
				return leadingField;
			}
			set
			{
				leadingField = value;
				leadingFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LeadingSpecified
		{
			get
			{
				return leadingFieldSpecified;
			}
			set
			{
				leadingFieldSpecified = value;
			}
		}

		[XmlAttribute("readingDirection")]
		public PageXmlReadingDirectionSimpleType ReadingDirection
		{
			get
			{
				return readingDirectionField;
			}
			set
			{
				readingDirectionField = value;
				readingDirectionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReadingDirectionSpecified
		{
			get
			{
				return readingDirectionFieldSpecified;
			}
			set
			{
				readingDirectionFieldSpecified = value;
			}
		}

		[XmlAttribute("textLineOrder")]
		public PageXmlTextLineOrderSimpleType TextLineOrder
		{
			get
			{
				return textLineOrderField;
			}
			set
			{
				textLineOrderField = value;
				textLineOrderFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TextLineOrderSpecified
		{
			get
			{
				return textLineOrderFieldSpecified;
			}
			set
			{
				textLineOrderFieldSpecified = value;
			}
		}

		[XmlAttribute("readingOrientation")]
		public float ReadingOrientation
		{
			get
			{
				return readingOrientationField;
			}
			set
			{
				readingOrientationField = value;
				readingOrientationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReadingOrientationSpecified
		{
			get
			{
				return readingOrientationFieldSpecified;
			}
			set
			{
				readingOrientationFieldSpecified = value;
			}
		}

		[XmlAttribute("indented")]
		public bool Indented
		{
			get
			{
				return indentedField;
			}
			set
			{
				indentedField = value;
				indentedFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool IndentedSpecified
		{
			get
			{
				return indentedFieldSpecified;
			}
			set
			{
				indentedFieldSpecified = value;
			}
		}

		[XmlAttribute("align")]
		public PageXmlAlignSimpleType Align
		{
			get
			{
				return alignField;
			}
			set
			{
				alignField = value;
				alignFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool AlignSpecified
		{
			get
			{
				return alignFieldSpecified;
			}
			set
			{
				alignFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryLanguage")]
		public PageXmlLanguageSimpleType PrimaryLanguage
		{
			get
			{
				return primaryLanguageField;
			}
			set
			{
				primaryLanguageField = value;
				primaryLanguageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryLanguageSpecified
		{
			get
			{
				return primaryLanguageFieldSpecified;
			}
			set
			{
				primaryLanguageFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryLanguage")]
		public PageXmlLanguageSimpleType SecondaryLanguage
		{
			get
			{
				return secondaryLanguageField;
			}
			set
			{
				secondaryLanguageField = value;
				secondaryLanguageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryLanguageSpecified
		{
			get
			{
				return secondaryLanguageFieldSpecified;
			}
			set
			{
				secondaryLanguageFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryScript")]
		public PageXmlScriptSimpleType PrimaryScript
		{
			get
			{
				return primaryScriptField;
			}
			set
			{
				primaryScriptField = value;
				primaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryScriptSpecified
		{
			get
			{
				return primaryScriptFieldSpecified;
			}
			set
			{
				primaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryScript")]
		public PageXmlScriptSimpleType SecondaryScript
		{
			get
			{
				return secondaryScriptField;
			}
			set
			{
				secondaryScriptField = value;
				secondaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryScriptSpecified
		{
			get
			{
				return secondaryScriptFieldSpecified;
			}
			set
			{
				secondaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("production")]
		public PageXmlProductionSimpleType Production
		{
			get
			{
				return productionField;
			}
			set
			{
				productionField = value;
				productionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ProductionSpecified
		{
			get
			{
				return productionFieldSpecified;
			}
			set
			{
				productionFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlTextSimpleType
	{
		[XmlEnum("paragraph")]
		Paragraph,
		[XmlEnum("heading")]
		Heading,
		[XmlEnum("caption")]
		Caption,
		[XmlEnum("header")]
		Header,
		[XmlEnum("footer")]
		Footer,
		[XmlEnum("page-number")]
		PageNumber,
		[XmlEnum("drop-capital")]
		DropCapital,
		[XmlEnum("credit")]
		Credit,
		[XmlEnum("floating")]
		Floating,
		[XmlEnum("signature-mark")]
		SignatureMark,
		[XmlEnum("catch-word")]
		CatchWord,
		[XmlEnum("marginalia")]
		Marginalia,
		[XmlEnum("footnote")]
		FootNote,
		[XmlEnum("footnote-continued")]
		FootNoteContinued,
		[XmlEnum("endnote")]
		EndNote,
		[XmlEnum("TOC-entry")]
		TocEntry,
		[XmlEnum("list-label")]
		LisLabel,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlTextStyle
	{
		private string fontFamilyField;

		private bool serifField;

		private bool serifFieldSpecified;

		private bool monospaceField;

		private bool monospaceFieldSpecified;

		private float fontSizeField;

		private bool fontSizeFieldSpecified;

		private string xHeightField;

		private int kerningField;

		private bool kerningFieldSpecified;

		private PageXmlColourSimpleType textColourField;

		private bool textColourFieldSpecified;

		private string textColourRgbField;

		private PageXmlColourSimpleType bgColourField;

		private bool bgColourFieldSpecified;

		private string bgColourRgbField;

		private bool reverseVideoField;

		private bool reverseVideoFieldSpecified;

		private bool boldField;

		private bool boldFieldSpecified;

		private bool italicField;

		private bool italicFieldSpecified;

		private bool underlinedField;

		private bool underlinedFieldSpecified;

		private PageXmlUnderlineStyleSimpleType underlineStyleField;

		private bool underlineStyleFieldSpecified;

		private bool subscriptField;

		private bool subscriptFieldSpecified;

		private bool superscriptField;

		private bool superscriptFieldSpecified;

		private bool strikethroughField;

		private bool strikethroughFieldSpecified;

		private bool smallCapsField;

		private bool smallCapsFieldSpecified;

		private bool letterSpacedField;

		private bool letterSpacedFieldSpecified;

		[XmlAttribute("fontFamily")]
		public string FontFamily
		{
			get
			{
				return fontFamilyField;
			}
			set
			{
				fontFamilyField = value;
			}
		}

		[XmlAttribute("serif")]
		public bool Serif
		{
			get
			{
				return serifField;
			}
			set
			{
				serifField = value;
				serifFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SerifSpecified
		{
			get
			{
				return serifFieldSpecified;
			}
			set
			{
				serifFieldSpecified = value;
			}
		}

		[XmlAttribute("monospace")]
		public bool Monospace
		{
			get
			{
				return monospaceField;
			}
			set
			{
				monospaceField = value;
				monospaceFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool MonospaceSpecified
		{
			get
			{
				return monospaceFieldSpecified;
			}
			set
			{
				monospaceFieldSpecified = value;
			}
		}

		[XmlAttribute("fontSize")]
		public float FontSize
		{
			get
			{
				return fontSizeField;
			}
			set
			{
				fontSizeField = value;
				fontSizeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool FontSizeSpecified
		{
			get
			{
				return fontSizeFieldSpecified;
			}
			set
			{
				fontSizeFieldSpecified = value;
			}
		}

		[XmlAttribute("xHeight", DataType = "integer")]
		public string XHeight
		{
			get
			{
				return xHeightField;
			}
			set
			{
				xHeightField = value;
			}
		}

		[XmlAttribute("kerning")]
		public int Kerning
		{
			get
			{
				return kerningField;
			}
			set
			{
				kerningField = value;
				kerningFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool KerningSpecified
		{
			get
			{
				return kerningFieldSpecified;
			}
			set
			{
				kerningFieldSpecified = value;
			}
		}

		[XmlAttribute("textColour")]
		public PageXmlColourSimpleType TextColour
		{
			get
			{
				return textColourField;
			}
			set
			{
				textColourField = value;
				textColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TextColourSpecified
		{
			get
			{
				return textColourFieldSpecified;
			}
			set
			{
				textColourFieldSpecified = value;
			}
		}

		[XmlAttribute("textColourRgb", DataType = "integer")]
		public string TextColourRgb
		{
			get
			{
				return textColourRgbField;
			}
			set
			{
				textColourRgbField = value;
			}
		}

		[XmlAttribute("bgColour")]
		public PageXmlColourSimpleType BgColour
		{
			get
			{
				return bgColourField;
			}
			set
			{
				bgColourField = value;
				bgColourFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BgColourSpecified
		{
			get
			{
				return bgColourFieldSpecified;
			}
			set
			{
				bgColourFieldSpecified = value;
			}
		}

		[XmlAttribute("bgColourRgb", DataType = "integer")]
		public string BgColourRgb
		{
			get
			{
				return bgColourRgbField;
			}
			set
			{
				bgColourRgbField = value;
			}
		}

		[XmlAttribute("reverseVideo")]
		public bool ReverseVideo
		{
			get
			{
				return reverseVideoField;
			}
			set
			{
				reverseVideoField = value;
				reverseVideoFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReverseVideoSpecified
		{
			get
			{
				return reverseVideoFieldSpecified;
			}
			set
			{
				reverseVideoFieldSpecified = value;
			}
		}

		[XmlAttribute("bold")]
		public bool Bold
		{
			get
			{
				return boldField;
			}
			set
			{
				boldField = value;
				boldFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool BoldSpecified
		{
			get
			{
				return boldFieldSpecified;
			}
			set
			{
				boldFieldSpecified = value;
			}
		}

		[XmlAttribute("italic")]
		public bool Italic
		{
			get
			{
				return italicField;
			}
			set
			{
				italicField = value;
				italicFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ItalicSpecified
		{
			get
			{
				return italicFieldSpecified;
			}
			set
			{
				italicFieldSpecified = value;
			}
		}

		[XmlAttribute("underlined")]
		public bool Underlined
		{
			get
			{
				return underlinedField;
			}
			set
			{
				underlinedField = value;
				underlinedFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool UnderlinedSpecified
		{
			get
			{
				return underlinedFieldSpecified;
			}
			set
			{
				underlinedFieldSpecified = value;
			}
		}

		[XmlAttribute("underlineStyle")]
		public PageXmlUnderlineStyleSimpleType UnderlineStyle
		{
			get
			{
				return underlineStyleField;
			}
			set
			{
				underlineStyleField = value;
				underlineStyleFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool UnderlineStyleSpecified
		{
			get
			{
				return underlineStyleFieldSpecified;
			}
			set
			{
				underlineStyleFieldSpecified = value;
			}
		}

		[XmlAttribute("subscript")]
		public bool Subscript
		{
			get
			{
				return subscriptField;
			}
			set
			{
				subscriptField = value;
				subscriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SubscriptSpecified
		{
			get
			{
				return subscriptFieldSpecified;
			}
			set
			{
				subscriptFieldSpecified = value;
			}
		}

		[XmlAttribute("superscript")]
		public bool Superscript
		{
			get
			{
				return superscriptField;
			}
			set
			{
				superscriptField = value;
				superscriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SuperscriptSpecified
		{
			get
			{
				return superscriptFieldSpecified;
			}
			set
			{
				superscriptFieldSpecified = value;
			}
		}

		[XmlAttribute("strikethrough")]
		public bool Strikethrough
		{
			get
			{
				return strikethroughField;
			}
			set
			{
				strikethroughField = value;
				strikethroughFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool StrikethroughSpecified
		{
			get
			{
				return strikethroughFieldSpecified;
			}
			set
			{
				strikethroughFieldSpecified = value;
			}
		}

		[XmlAttribute("smallCaps")]
		public bool SmallCaps
		{
			get
			{
				return smallCapsField;
			}
			set
			{
				smallCapsField = value;
				smallCapsFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SmallCapsSpecified
		{
			get
			{
				return smallCapsFieldSpecified;
			}
			set
			{
				smallCapsFieldSpecified = value;
			}
		}

		[XmlAttribute("letterSpaced")]
		public bool LetterSpaced
		{
			get
			{
				return letterSpacedField;
			}
			set
			{
				letterSpacedField = value;
				letterSpacedFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LetterSpacedSpecified
		{
			get
			{
				return letterSpacedFieldSpecified;
			}
			set
			{
				letterSpacedFieldSpecified = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlUnderlineStyleSimpleType
	{
		[XmlEnum("singleLine")]
		SingleLine,
		[XmlEnum("doubleLine")]
		DoubleLine,
		[XmlEnum("other")]
		Other
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlUnknownRegion : PageXmlRegion
	{
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlUnorderedGroup
	{
		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private object[] itemsField;

		private string idField;

		private string regionRefField;

		private string captionField;

		private PageXmlGroupSimpleType typeField;

		private bool typeFieldSpecified;

		private bool continuationField;

		private bool continuationFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlElement("OrderedGroup", typeof(PageXmlOrderedGroup))]
		[XmlElement("RegionRef", typeof(PageXmlRegionRef))]
		[XmlElement("UnorderedGroup", typeof(PageXmlUnorderedGroup))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string RegionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}

		[XmlAttribute("caption")]
		public string Caption
		{
			get
			{
				return captionField;
			}
			set
			{
				captionField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlGroupSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("continuation")]
		public bool Continuation
		{
			get
			{
				return continuationField;
			}
			set
			{
				continuationField = value;
				continuationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ContinuationSpecified
		{
			get
			{
				return continuationFieldSpecified;
			}
			set
			{
				continuationFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlUnorderedGroupIndexed
	{
		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private object[] itemsField;

		private string idField;

		private string regionRefField;

		private int indexField;

		private string captionField;

		private PageXmlGroupSimpleType typeField;

		private bool typeFieldSpecified;

		private bool continuationField;

		private bool continuationFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlElement("OrderedGroup", typeof(PageXmlOrderedGroup))]
		[XmlElement("RegionRef", typeof(PageXmlRegionRef))]
		[XmlElement("UnorderedGroup", typeof(PageXmlUnorderedGroup))]
		public object[] Items
		{
			get
			{
				return itemsField;
			}
			set
			{
				itemsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("regionRef", DataType = "IDREF")]
		public string RegionRef
		{
			get
			{
				return regionRefField;
			}
			set
			{
				regionRefField = value;
			}
		}

		[XmlAttribute("index")]
		public int Index
		{
			get
			{
				return indexField;
			}
			set
			{
				indexField = value;
			}
		}

		[XmlAttribute("caption")]
		public string Caption
		{
			get
			{
				return captionField;
			}
			set
			{
				captionField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlGroupSimpleType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("continuation")]
		public bool Continuation
		{
			get
			{
				return continuationField;
			}
			set
			{
				continuationField = value;
				continuationFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ContinuationSpecified
		{
			get
			{
				return continuationFieldSpecified;
			}
			set
			{
				continuationFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlUserAttribute
	{
		private string nameField;

		private string descriptionField;

		private PageXmlUserAttributeType typeField;

		private bool typeFieldSpecified;

		private string valueField;

		[XmlAttribute("name")]
		public string Name
		{
			get
			{
				return nameField;
			}
			set
			{
				nameField = value;
			}
		}

		[XmlAttribute("description")]
		public string Description
		{
			get
			{
				return descriptionField;
			}
			set
			{
				descriptionField = value;
			}
		}

		[XmlAttribute("type")]
		public PageXmlUserAttributeType Type
		{
			get
			{
				return typeField;
			}
			set
			{
				typeField = value;
				typeFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool TypeSpecified
		{
			get
			{
				return typeFieldSpecified;
			}
			set
			{
				typeFieldSpecified = value;
			}
		}

		[XmlAttribute("value")]
		public string Value
		{
			get
			{
				return valueField;
			}
			set
			{
				valueField = value;
			}
		}
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[XmlType(AnonymousType = true, Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public enum PageXmlUserAttributeType
	{
		[XmlEnum("xsd:string")]
		XsdString,
		[XmlEnum("xsd:integer")]
		XsdInteger,
		[XmlEnum("xsd:boolean")]
		XsdBoolean,
		[XmlEnum("xsd:float")]
		XsdFloat
	}

	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("xsd", "4.6.1055.0")]
	[DebuggerStepThrough]
	[DesignerCategory("code")]
	[XmlType(Namespace = "http://schema.primaresearch.org/PAGE/gts/pagecontent/2019-07-15")]
	public class PageXmlWord
	{
		private PageXmlAlternativeImage[] alternativeImageField;

		private PageXmlCoords coordsField;

		private PageXmlGlyph[] glyphField;

		private PageXmlTextEquiv[] textEquivField;

		private PageXmlTextStyle textStyleField;

		private PageXmlUserAttribute[] userDefinedField;

		private PageXmlLabels[] labelsField;

		private string idField;

		private PageXmlLanguageSimpleType languageField;

		private bool languageFieldSpecified;

		private PageXmlScriptSimpleType primaryScriptField;

		private bool primaryScriptFieldSpecified;

		private PageXmlScriptSimpleType secondaryScriptField;

		private bool secondaryScriptFieldSpecified;

		private PageXmlReadingDirectionSimpleType readingDirectionField;

		private bool readingDirectionFieldSpecified;

		private PageXmlProductionSimpleType productionField;

		private bool productionFieldSpecified;

		private string customField;

		private string commentsField;

		[XmlElement("AlternativeImage")]
		public PageXmlAlternativeImage[] AlternativeImages
		{
			get
			{
				return alternativeImageField;
			}
			set
			{
				alternativeImageField = value;
			}
		}

		public PageXmlCoords Coords
		{
			get
			{
				return coordsField;
			}
			set
			{
				coordsField = value;
			}
		}

		[XmlElement("Glyph")]
		public PageXmlGlyph[] Glyphs
		{
			get
			{
				return glyphField;
			}
			set
			{
				glyphField = value;
			}
		}

		[XmlElement("TextEquiv")]
		public PageXmlTextEquiv[] TextEquivs
		{
			get
			{
				return textEquivField;
			}
			set
			{
				textEquivField = value;
			}
		}

		public PageXmlTextStyle TextStyle
		{
			get
			{
				return textStyleField;
			}
			set
			{
				textStyleField = value;
			}
		}

		[XmlArrayItem("UserAttribute", IsNullable = false)]
		public PageXmlUserAttribute[] UserDefined
		{
			get
			{
				return userDefinedField;
			}
			set
			{
				userDefinedField = value;
			}
		}

		[XmlElement("Labels")]
		public PageXmlLabels[] Labels
		{
			get
			{
				return labelsField;
			}
			set
			{
				labelsField = value;
			}
		}

		[XmlAttribute("id", DataType = "ID")]
		public string Id
		{
			get
			{
				return idField;
			}
			set
			{
				idField = value;
			}
		}

		[XmlAttribute("language")]
		public PageXmlLanguageSimpleType Language
		{
			get
			{
				return languageField;
			}
			set
			{
				languageField = value;
				languageFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool LanguageSpecified
		{
			get
			{
				return languageFieldSpecified;
			}
			set
			{
				languageFieldSpecified = value;
			}
		}

		[XmlAttribute("primaryScript")]
		public PageXmlScriptSimpleType PrimaryScript
		{
			get
			{
				return primaryScriptField;
			}
			set
			{
				primaryScriptField = value;
				primaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool PrimaryScriptSpecified
		{
			get
			{
				return primaryScriptFieldSpecified;
			}
			set
			{
				primaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("secondaryScript")]
		public PageXmlScriptSimpleType SecondaryScript
		{
			get
			{
				return secondaryScriptField;
			}
			set
			{
				secondaryScriptField = value;
				secondaryScriptFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool SecondaryScriptSpecified
		{
			get
			{
				return secondaryScriptFieldSpecified;
			}
			set
			{
				secondaryScriptFieldSpecified = value;
			}
		}

		[XmlAttribute("readingDirection")]
		public PageXmlReadingDirectionSimpleType ReadingDirection
		{
			get
			{
				return readingDirectionField;
			}
			set
			{
				readingDirectionField = value;
				readingDirectionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ReadingDirectionSpecified
		{
			get
			{
				return readingDirectionFieldSpecified;
			}
			set
			{
				readingDirectionFieldSpecified = value;
			}
		}

		[XmlAttribute("production")]
		public PageXmlProductionSimpleType Production
		{
			get
			{
				return productionField;
			}
			set
			{
				productionField = value;
				productionFieldSpecified = true;
			}
		}

		[XmlIgnore]
		public bool ProductionSpecified
		{
			get
			{
				return productionFieldSpecified;
			}
			set
			{
				productionFieldSpecified = value;
			}
		}

		[XmlAttribute("custom")]
		public string Custom
		{
			get
			{
				return customField;
			}
			set
			{
				customField = value;
			}
		}

		[XmlAttribute("comments")]
		public string Comments
		{
			get
			{
				return commentsField;
			}
			set
			{
				commentsField = value;
			}
		}

		public override string ToString()
		{
			return string.Join("\n", TextEquivs.Select((PageXmlTextEquiv t) => t.Unicode));
		}
	}

	private PageXmlMetadata metadataField;

	private PageXmlPage pageField;

	private string pcGtsIdField;

	public PageXmlMetadata Metadata
	{
		get
		{
			return metadataField;
		}
		set
		{
			metadataField = value;
		}
	}

	public PageXmlPage Page
	{
		get
		{
			return pageField;
		}
		set
		{
			pageField = value;
		}
	}

	[XmlAttribute("pcGtsId", DataType = "ID")]
	public string PcGtsId
	{
		get
		{
			return pcGtsIdField;
		}
		set
		{
			pcGtsIdField = value;
		}
	}
}
