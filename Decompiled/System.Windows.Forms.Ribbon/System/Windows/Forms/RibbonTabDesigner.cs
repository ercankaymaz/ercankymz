using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms.Design.Behavior;

namespace System.Windows.Forms;

public class RibbonTabDesigner : ComponentDesigner
{
	private Adorner _panelAdorner;

	public override DesignerVerbCollection Verbs => new DesignerVerbCollection(new DesignerVerb[1]
	{
		new DesignerVerb("Add Panel", AddPanel)
	});

	public RibbonTab Tab => base.Component as RibbonTab;

	public void AddPanel(object sender, EventArgs e)
	{
		if (!(GetService(typeof(IDesignerHost)) is IDesignerHost designerHost) || Tab == null)
		{
			return;
		}
		DesignerTransaction designerTransaction = designerHost.CreateTransaction("AddPanel" + base.Component.Site.Name);
		MemberDescriptor member = TypeDescriptor.GetProperties(base.Component)["Panels"];
		RaiseComponentChanging(member);
		if (designerHost.CreateComponent(typeof(RibbonPanel)) is RibbonPanel ribbonPanel)
		{
			ribbonPanel.Text = ribbonPanel.Site.Name;
			ribbonPanel.Index = Tab.Panels.Count;
			if (ribbonPanel.Index == 0)
			{
				ribbonPanel.IsFirstPanel = true;
			}
			else
			{
				foreach (RibbonPanel panel in Tab.Panels)
				{
					panel.IsLastPanel = false;
				}
				ribbonPanel.IsLastPanel = true;
			}
			Tab.Panels.Add(ribbonPanel);
			Tab.Owner.OnRegionsChanged();
		}
		RaiseComponentChanged(member, null, null);
		designerTransaction.Commit();
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		_panelAdorner = new Adorner();
		if (RibbonDesigner.Current != null)
		{
			BehaviorService behaviorService = RibbonDesigner.Current.GetBehaviorService();
			if (behaviorService != null)
			{
				behaviorService.Adorners.AddRange(new Adorner[1] { _panelAdorner });
				_panelAdorner.Glyphs.Add(new RibbonPanelGlyph(behaviorService, this, Tab));
			}
		}
	}
}
