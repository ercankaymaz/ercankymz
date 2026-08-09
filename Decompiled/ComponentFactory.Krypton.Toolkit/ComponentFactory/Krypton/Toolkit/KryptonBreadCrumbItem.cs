using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(false)]
[ToolboxBitmap(typeof(KryptonBreadCrumb), "ToolboxBitmaps.KryptonBreadCrumbItem.bmp")]
[DesignTimeVisible(false)]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItemDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
public class KryptonBreadCrumbItem : KryptonListItem
{
	[Editor("ComponentFactory.Krypton.Toolkit.KryptonBreadCrumbItemsEditor, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e", typeof(UITypeEditor))]
	public class BreadCrumbItems : TypedCollection<KryptonBreadCrumbItem>
	{
		private KryptonBreadCrumbItem _owner;

		public override KryptonBreadCrumbItem this[string name]
		{
			get
			{
				if (!string.IsNullOrEmpty(name))
				{
					using IEnumerator<KryptonBreadCrumbItem> enumerator = GetEnumerator();
					while (enumerator.MoveNext())
					{
						KryptonBreadCrumbItem current = enumerator.Current;
						string shortText = current.ShortText;
						if (!string.IsNullOrEmpty(shortText) && shortText == name)
						{
							return current;
						}
						shortText = current.LongText;
						if (!string.IsNullOrEmpty(shortText) && shortText == name)
						{
							return current;
						}
					}
				}
				return null;
			}
		}

		internal BreadCrumbItems(KryptonBreadCrumbItem owner)
		{
			_owner = owner;
		}

		protected override void OnInserting(TypedCollectionEventArgs<KryptonBreadCrumbItem> e)
		{
			e.Item.Parent = _owner;
			base.OnInserting(e);
		}

		protected override void OnInserted(TypedCollectionEventArgs<KryptonBreadCrumbItem> e)
		{
			base.OnInserted(e);
			_owner.OnPropertyChanged(new PropertyChangedEventArgs("Items"));
		}

		protected override void OnRemoved(TypedCollectionEventArgs<KryptonBreadCrumbItem> e)
		{
			base.OnRemoved(e);
			e.Item.Parent = null;
			_owner.OnPropertyChanged(new PropertyChangedEventArgs("Items"));
		}

		protected override void OnClearing(EventArgs e)
		{
			using (IEnumerator<KryptonBreadCrumbItem> enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					KryptonBreadCrumbItem current = enumerator.Current;
					current.Parent = null;
				}
			}
			base.OnClearing(e);
		}

		protected override void OnCleared(EventArgs e)
		{
			base.OnCleared(e);
			_owner.OnPropertyChanged(new PropertyChangedEventArgs("Items"));
		}
	}

	private KryptonBreadCrumbItem _parent;

	private BreadCrumbItems _items;

	[Category("Data")]
	[Description("Collection of child items.")]
	[EditorBrowsable(EditorBrowsableState.Always)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[RefreshProperties(RefreshProperties.All)]
	[Browsable(true)]
	public BreadCrumbItems Items => _items;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Advanced)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public KryptonBreadCrumbItem Parent
	{
		get
		{
			return _parent;
		}
		internal set
		{
			_parent = value;
		}
	}

	public KryptonBreadCrumbItem()
		: this("ListItem", null, null, Color.Empty)
	{
	}

	public KryptonBreadCrumbItem(string shortText)
		: this(shortText, null, null, Color.Empty)
	{
	}

	public KryptonBreadCrumbItem(string shortText, string longText)
		: this(shortText, longText, null, Color.Empty)
	{
	}

	public KryptonBreadCrumbItem(string shortText, string longText, Image image)
		: this(shortText, longText, image, Color.Empty)
	{
	}

	public KryptonBreadCrumbItem(string shortText, string longText, Image image, Color imageTransparentColor)
		: base(shortText, longText, image, imageTransparentColor)
	{
		_items = new BreadCrumbItems(this);
	}

	public override string ToString()
	{
		return "(" + _items.Count + ") " + base.ShortText;
	}

	protected override void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		base.OnPropertyChanged(e);
		KryptonBreadCrumbItem parent = Parent;
		if (parent != null)
		{
			while (parent.Parent != null)
			{
				parent = parent.Parent;
			}
			parent.OnPropertyChanged(e);
		}
	}
}
