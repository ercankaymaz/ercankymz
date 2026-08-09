using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public class WorkspaceDesignerActionList<T> : DesignerActionList where T : Workspace
{
	protected DesignerActionUIService _designerActionUISvc;

	protected WorkspaceControlDesignerGeneric<T> WorkspaceControlDesigner;

	public Size Size
	{
		get
		{
			return WorkspaceControlDesigner.Control.Size;
		}
		set
		{
			SetControlProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318301), value);
		}
	}

	public AnchorStyles Anchor
	{
		get
		{
			return WorkspaceControlDesigner.Control.Anchor;
		}
		set
		{
			SetControlProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318314), value);
		}
	}

	public DockStyle Dock
	{
		get
		{
			return WorkspaceControlDesigner.Control.Dock;
		}
		set
		{
			SetControlProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319525), value);
		}
	}

	public WorkspaceDesignerActionList(ControlDesigner designer)
		: base(designer.Component)
	{
		_designerActionUISvc = GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
		WorkspaceControlDesigner = (WorkspaceControlDesignerGeneric<T>)designer;
	}

	protected void SetControlProperty(string propertyName, object value)
	{
		TypeDescriptor.GetProperties(base.Component)[propertyName].SetValue(base.Component, value);
	}

	public void SupportRequest()
	{
		Workspace.RunEyeshotToolsForSupport();
	}

	protected void RefreshAll()
	{
		((Workspace)base.Component).Refresh();
		_designerActionUISvc.Refresh(base.Component);
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		DesignerActionHeaderItem value = new DesignerActionHeaderItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316616), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316619));
		designerActionItemCollection.Add(value);
		DesignerActionPropertyItem value2 = new DesignerActionPropertyItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318301), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318301), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316619), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316467));
		designerActionItemCollection.Add(value2);
		DesignerActionPropertyItem value3 = new DesignerActionPropertyItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564318314), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316438), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316619), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316419));
		designerActionItemCollection.Add(value3);
		DesignerActionPropertyItem value4 = new DesignerActionPropertyItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564319525), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316525), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316619), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316508));
		designerActionItemCollection.Add(value4);
		DesignerActionHeaderItem value5 = new DesignerActionHeaderItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316325), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316311));
		designerActionItemCollection.Insert(3, value5);
		DesignerActionMethodItem value6 = new DesignerActionMethodItem(this, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316319), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313335), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316311), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564316298), includeAsDesignerVerb: true);
		designerActionItemCollection.Add(value6);
		return designerActionItemCollection;
	}
}
