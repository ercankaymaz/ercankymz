using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Tables;

namespace ACadSharp.Objects;

[DxfName("MLINESTYLE")]
[DxfSubClass("AcDbMlineStyle")]
public class MLineStyle : NonGraphicalObject
{
	public class Element
	{
		private LineType _lineType = LineType.ByLayer;

		[DxfCodeValue(new int[] { 62 })]
		public Color Color { get; set; } = Color.ByLayer;

		[DxfCodeValue(new int[] { 6 })]
		public LineType LineType
		{
			get
			{
				return _lineType;
			}
			set
			{
				_lineType = CadObject.updateCollection(value, Owner?.Document?.LineTypes);
			}
		}

		[DxfCodeValue(new int[] { 49 })]
		public double Offset { get; set; }

		public MLineStyle Owner { get; internal set; }

		public Element Clone()
		{
			Element obj = MemberwiseClone() as Element;
			obj.Owner = null;
			obj._lineType = (LineType)(LineType?.Clone());
			return obj;
		}

		internal void AssignDocument(CadDocument doc)
		{
			_lineType = CadObject.updateCollection(_lineType, doc.LineTypes);
		}

		internal void UnassignDocument()
		{
			_lineType = _lineType.CloneTyped();
		}
	}

	public const string DefaultName = "Standard";

	private List<Element> _elements = new List<Element>();

	public static MLineStyle Default
	{
		get
		{
			MLineStyle mLineStyle = new MLineStyle("Standard");
			mLineStyle.StartAngle = Math.PI / 2.0;
			mLineStyle.EndAngle = Math.PI / 2.0;
			mLineStyle.AddElement(new Element
			{
				LineType = LineType.ByLayer,
				Offset = 0.5
			});
			mLineStyle.AddElement(new Element
			{
				LineType = LineType.ByLayer,
				Offset = -0.5
			});
			return mLineStyle;
		}
	}

	[DxfCodeValue(new int[] { 3 })]
	public string Description { get; set; }

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 71 })]
	public IEnumerable<Element> Elements => _elements;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 52 })]
	public double EndAngle { get; set; } = Math.PI / 2.0;

	[DxfCodeValue(new int[] { 62 })]
	public Color FillColor { get; set; } = Color.ByLayer;

	[DxfCodeValue(new int[] { 70 })]
	public MLineStyleFlags Flags { get; set; }

	[DxfCodeValue(new int[] { 2 })]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	public override string ObjectName => "MLINESTYLE";

	public override ObjectType ObjectType => ObjectType.MLINESTYLE;

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double StartAngle { get; set; } = Math.PI / 2.0;

	public override string SubclassMarker => "AcDbMlineStyle";

	public MLineStyle(string name)
	{
		Name = name;
	}

	internal MLineStyle()
	{
	}

	public void AddElement(Element element)
	{
		if (element.Owner != null)
		{
			throw new ArgumentException("Element already assigned to a MLineStyle: " + element.Owner.Name);
		}
		element.LineType = CadObject.updateCollection(element.LineType, base.Document?.LineTypes);
		element.Owner = this;
		_elements.Add(element);
	}

	public override CadObject Clone()
	{
		MLineStyle mLineStyle = (MLineStyle)base.Clone();
		mLineStyle._elements = new List<Element>();
		foreach (Element element in _elements)
		{
			mLineStyle.AddElement(element.Clone());
		}
		return mLineStyle;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		foreach (Element item in _elements.Where((Element s) => s.LineType != null))
		{
			item.AssignDocument(doc);
		}
		doc.TextStyles.OnRemove += tableOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.TextStyles.OnRemove -= tableOnRemove;
		foreach (Element item in _elements.Where((Element s) => s.LineType != null))
		{
			item.UnassignDocument();
		}
		base.UnassignDocument();
	}

	protected void tableOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (!(e.Item is LineType lineType))
		{
			return;
		}
		foreach (Element item in _elements.Where((Element s) => s.LineType != null))
		{
			if (item.LineType == lineType)
			{
				item.LineType = null;
			}
		}
	}
}
