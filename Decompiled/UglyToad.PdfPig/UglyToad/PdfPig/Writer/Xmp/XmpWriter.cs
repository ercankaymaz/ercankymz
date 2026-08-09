using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using UglyToad.PdfPig.Tokens;

namespace UglyToad.PdfPig.Writer.Xmp;

internal static class XmpWriter
{
	private sealed class SchemaMapper
	{
		public string Name { get; }

		public Func<PdfDocumentBuilder.DocumentInformationBuilder, string?> ValueFunc { get; }

		public SchemaMapper(string name, Func<PdfDocumentBuilder.DocumentInformationBuilder, string?> valueFunc)
		{
			Name = name;
			ValueFunc = valueFunc;
		}
	}

	private const string Xmptk = "Adobe XMP Core 5.6-c014 79.156797, 2014/08/20-09:53:02        ";

	private const string RdfNamespace = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";

	private const string XmpMetaPrefix = "x";

	private const string XmpMetaNamespace = "adobe:ns:meta/";

	private const string DublinCorePrefix = "dc";

	private const string DublinCoreNamespace = "http://purl.org/dc/elements/1.1/";

	private const string XmpBasicPrefix = "xmp";

	private const string XmpBasicNamespace = "http://ns.adobe.com/xap/1.0/";

	private const string XmpRightsManagementPrefix = "xmpRights";

	private const string XmpRightsManagementNamespace = "http://ns.adobe.com/xap/1.0/rights/";

	private const string XmpMediaManagementPrefix = "xmpMM";

	private const string XmpMediaManagementNamespace = "http://ns.adobe.com/xap/1.0/mm/";

	private const string AdobePdfPrefix = "pdf";

	private const string AdobePdfNamespace = "http://ns.adobe.com/pdf/1.3/";

	private const string PdfAIdentificationExtensionPrefix = "pdfaid";

	private const string PdfAIdentificationExtensionNamespace = "http://www.aiim.org/pdfa/ns/id/";

	public static StreamToken GenerateXmpStream(PdfDocumentBuilder.DocumentInformationBuilder builder, double version, PdfAStandard standard, XDocument? additionalXmpMetadata)
	{
		XNamespace xNamespace = "adobe:ns:meta/";
		XNamespace xNamespace2 = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
		XAttribute xAttribute = new XAttribute(xNamespace2 + "about", string.Empty);
		XElement xElement = new XElement(xNamespace2 + "Description", xAttribute);
		AddElementsForSchema(xElement, "dc", "http://purl.org/dc/elements/1.1/", builder, new List<SchemaMapper>(4)
		{
			new SchemaMapper("format", (PdfDocumentBuilder.DocumentInformationBuilder b) => "application/pdf"),
			new SchemaMapper("creator", (PdfDocumentBuilder.DocumentInformationBuilder b) => b.Author),
			new SchemaMapper("description", (PdfDocumentBuilder.DocumentInformationBuilder b) => b.Subject),
			new SchemaMapper("title", (PdfDocumentBuilder.DocumentInformationBuilder b) => b.Title)
		});
		AddElementsForSchema(xElement, "xmp", "http://ns.adobe.com/xap/1.0/", builder, new List<SchemaMapper>(1)
		{
			new SchemaMapper("CreatorTool", (PdfDocumentBuilder.DocumentInformationBuilder b) => b.Creator)
		});
		AddElementsForSchema(xElement, "pdf", "http://ns.adobe.com/pdf/1.3/", builder, new List<SchemaMapper>(2)
		{
			new SchemaMapper("PDFVersion", (PdfDocumentBuilder.DocumentInformationBuilder b) => version.ToString("F1", CultureInfo.InvariantCulture)),
			new SchemaMapper("Producer", (PdfDocumentBuilder.DocumentInformationBuilder b) => b.Producer)
		});
		XElement versionAndConformanceLevelIdentificationElement = GetVersionAndConformanceLevelIdentificationElement(xNamespace2, xAttribute, standard);
		string text = MergeXmpXdocuments(new XDocument(new XElement(xNamespace + "xmpmeta", GetNamespaceAttribute("x", "adobe:ns:meta/"), new XAttribute(xNamespace + "xmptk", "Adobe XMP Core 5.6-c014 79.156797, 2014/08/20-09:53:02        "), new XElement(xNamespace2 + "RDF", GetNamespaceAttribute("rdf", xNamespace2), xElement, versionAndConformanceLevelIdentificationElement))), additionalXmpMetadata).ToString(SaveOptions.None).Replace("\r\n", "\n");
		text = "<?xpacket begin=\"\ufeff\" id=\"W5M0MpCehiHzreSzNTczkc9d\"?>\n" + text + "\n<?xpacket end=\"r\"?>";
		byte[] bytes = Encoding.UTF8.GetBytes(text);
		return new StreamToken(new DictionaryToken(new Dictionary<NameToken, IToken>
		{
			{
				NameToken.Type,
				NameToken.Metadata
			},
			{
				NameToken.Subtype,
				NameToken.Xml
			},
			{
				NameToken.Length,
				new NumericToken(bytes.Length)
			}
		}), bytes);
	}

	private static XAttribute GetNamespaceAttribute(string prefix, XNamespace ns)
	{
		return new XAttribute(XNamespace.Xmlns + prefix, ns);
	}

	private static void AddElementsForSchema(XElement parent, string prefix, string ns, PdfDocumentBuilder.DocumentInformationBuilder builder, List<SchemaMapper> mappers)
	{
		XNamespace xNamespace = XNamespace.Get(ns);
		parent.Add(GetNamespaceAttribute(prefix, xNamespace));
		foreach (SchemaMapper mapper in mappers)
		{
			string text = mapper.ValueFunc(builder);
			if (text != null)
			{
				parent.Add(new XElement(xNamespace + mapper.Name, text));
			}
		}
	}

	private static XElement GetVersionAndConformanceLevelIdentificationElement(XNamespace rdf, XAttribute emptyRdfAbout, PdfAStandard standard)
	{
		XNamespace xNamespace = "http://www.aiim.org/pdfa/ns/id/";
		XElement xElement = new XElement(rdf + "Description", emptyRdfAbout, GetNamespaceAttribute("pdfaid", xNamespace));
		int num;
		string content;
		switch (standard)
		{
		case PdfAStandard.A1B:
			num = 1;
			content = "B";
			break;
		case PdfAStandard.A1A:
			num = 1;
			content = "A";
			break;
		case PdfAStandard.A2B:
			num = 2;
			content = "B";
			break;
		case PdfAStandard.A2A:
			num = 2;
			content = "A";
			break;
		case PdfAStandard.A3A:
			num = 3;
			content = "A";
			break;
		case PdfAStandard.A3B:
			num = 3;
			content = "B";
			break;
		default:
			throw new ArgumentOutOfRangeException("standard", standard, null);
		}
		xElement.Add(new XElement(xNamespace + "part", num));
		xElement.Add(new XElement(xNamespace + "conformance", content));
		return xElement;
	}

	private static XElement GetExtensionSchemasElement(XNamespace rdf, XAttribute emptyRdfAbout)
	{
		XNamespace xNamespace = "http://www.aiim.org/pdfa/ns/extension/";
		XNamespace xNamespace2 = "http://www.aiim.org/pdfa/ns/schema#";
		XNamespace xNamespace3 = "http://www.aiim.org/pdfa/ns/property#";
		XElement xElement = new XElement(rdf + "Description", emptyRdfAbout, GetNamespaceAttribute("pdfaExtension", xNamespace), GetNamespaceAttribute("pdfaSchema", xNamespace2), GetNamespaceAttribute("pdfaProperty", xNamespace3));
		XElement xElement2 = new XElement(xNamespace + "schemas", new XElement(rdf + "Bag"));
		XElement xElement3 = new XElement(rdf + "li", new XAttribute(rdf + "parseType", "Resource"));
		xElement3.Add(new XElement(xNamespace2 + "namespaceURI", "http://www.aiim.org/pdfa/ns/id/"));
		xElement3.Add(new XElement(xNamespace2 + "prefix", "pdfaid"));
		xElement3.Add(new XElement(xNamespace2 + "schema", "PDF/A ID Schema"));
		XElement xElement4 = new XElement(xNamespace2 + "property", new XElement(rdf + "Seq"));
		XElement xElement5 = xElement4.Elements().Last();
		xElement5.Add(GetSchemaPropertyListItem(rdf, xNamespace3, "part", "Part of PDF/A standard", "internal", "Integer"));
		xElement5.Add(GetSchemaPropertyListItem(rdf, xNamespace3, "amd", "Amendment of PDF/A standard"));
		xElement5.Add(GetSchemaPropertyListItem(rdf, xNamespace3, "conformance", "Conformance level of PDF/A standard"));
		xElement3.Add(xElement4);
		xElement2.Elements().Last().Add(xElement3);
		xElement.Add(xElement2);
		return xElement;
	}

	private static XElement GetSchemaPropertyListItem(XNamespace rdfNs, XNamespace pdfaPropertyNs, string name, string description, string category = "internal", string valueType = "Text")
	{
		XElement xElement = new XElement(rdfNs + "li", new XAttribute(rdfNs + "parseType", "Resource"));
		xElement.Add(new XElement(pdfaPropertyNs + "category", category));
		xElement.Add(new XElement(pdfaPropertyNs + "description", description));
		xElement.Add(new XElement(pdfaPropertyNs + "name", name));
		xElement.Add(new XElement(pdfaPropertyNs + "valueType", valueType));
		return xElement;
	}

	private static XDocument MergeXmpXdocuments(params XDocument[] xDocuments)
	{
		XDocument xDocument = new XDocument(xDocuments.FirstOrDefault());
		foreach (XDocument item in from doc in xDocuments.Skip(1)
			where doc != null
			select doc)
		{
			XDocument xDocument2 = new XDocument(item);
			XElement xElement = xDocument.Descendants(XNamespace.Get("http://www.w3.org/1999/02/22-rdf-syntax-ns#") + "RDF").First();
			List<XElement> list = xDocument2.Descendants(XNamespace.Get("http://www.w3.org/1999/02/22-rdf-syntax-ns#") + "RDF").First().Elements()
				.ToList();
			foreach (XElement item2 in list)
			{
				foreach (XElement item3 in item2.Elements().ToList())
				{
					if ((from mx in xElement.Descendants(XNamespace.Get("http://www.w3.org/1999/02/22-rdf-syntax-ns#") + "Description").SelectMany((XElement d) => d.Descendants())
						select mx.Name).Contains(item3.Name))
					{
						item3.Remove();
					}
				}
			}
			xElement.Add(list);
		}
		return xDocument;
	}
}
