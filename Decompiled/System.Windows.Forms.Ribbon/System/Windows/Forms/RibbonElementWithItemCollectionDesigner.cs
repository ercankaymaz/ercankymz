using System.ComponentModel;
using System.ComponentModel.Design;

namespace System.Windows.Forms;

internal abstract class RibbonElementWithItemCollectionDesigner : ComponentDesigner
{
	public abstract Ribbon Ribbon { get; }

	public abstract RibbonItemCollection Collection { get; }

	public override DesignerVerbCollection Verbs => OnGetVerbs();

	protected virtual DesignerVerbCollection OnGetVerbs()
	{
		return new DesignerVerbCollection(new DesignerVerb[12]
		{
			new DesignerVerb("Add Button", AddButton),
			new DesignerVerb("Add ButtonList", AddButtonList),
			new DesignerVerb("Add ItemGroup", AddItemGroup),
			new DesignerVerb("Add Separator", AddSeparator),
			new DesignerVerb("Add TextBox", AddTextBox),
			new DesignerVerb("Add ComboBox", AddComboBox),
			new DesignerVerb("Add ColorChooser", AddColorChooser),
			new DesignerVerb("Add DescriptionMenuItem", AddDescriptionMenuItem),
			new DesignerVerb("Add CheckBox", AddCheckBox),
			new DesignerVerb("Add UpDown", AddUpDown),
			new DesignerVerb("Add Label", AddLabel),
			new DesignerVerb("Add Host", AddHost)
		});
	}

	private void CreateItem(Type t)
	{
		CreateItem(Ribbon, Collection, t);
	}

	protected virtual void CreateItem(Ribbon ribbon, RibbonItemCollection collection, Type t)
	{
		if (GetService(typeof(IDesignerHost)) is IDesignerHost designerHost && collection != null && ribbon != null)
		{
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("AddRibbonItem_" + base.Component.Site.Name);
			MemberDescriptor member = TypeDescriptor.GetProperties(base.Component)["Items"];
			RaiseComponentChanging(member);
			RibbonItem ribbonItem = designerHost.CreateComponent(t) as RibbonItem;
			if (!(ribbonItem is RibbonSeparator) && ribbonItem != null)
			{
				ribbonItem.Text = ribbonItem.Site.Name;
			}
			collection.Add(ribbonItem);
			ribbon.OnRegionsChanged();
			RaiseComponentChanged(member, null, null);
			designerTransaction.Commit();
		}
	}

	protected virtual void AddButton(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonButton));
	}

	protected virtual void AddButtonList(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonButtonList));
	}

	protected virtual void AddItemGroup(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonItemGroup));
	}

	protected virtual void AddSeparator(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonSeparator));
	}

	protected virtual void AddTextBox(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonTextBox));
	}

	protected virtual void AddComboBox(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonComboBox));
	}

	protected virtual void AddColorChooser(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonColorChooser));
	}

	protected virtual void AddDescriptionMenuItem(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonDescriptionMenuItem));
	}

	protected virtual void AddCheckBox(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonCheckBox));
	}

	protected virtual void AddUpDown(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonUpDown));
	}

	protected virtual void AddLabel(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonLabel));
	}

	protected virtual void AddHost(object sender, EventArgs e)
	{
		CreateItem(typeof(RibbonHost));
	}
}
