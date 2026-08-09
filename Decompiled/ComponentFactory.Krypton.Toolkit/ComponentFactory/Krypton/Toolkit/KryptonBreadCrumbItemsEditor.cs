using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

internal class KryptonBreadCrumbItemsEditor : CollectionEditor
{
	protected class KryptonBreadCrumbItemsForm : CollectionForm
	{
		protected class DictItemBase : Dictionary<KryptonBreadCrumbItem, KryptonBreadCrumbItem>
		{
		}

		protected class CrumbProxy
		{
			private KryptonBreadCrumbItem _item;

			[Category("Appearance")]
			public string ShortText
			{
				get
				{
					return _item.ShortText;
				}
				set
				{
					_item.ShortText = value;
				}
			}

			[Category("Appearance")]
			public string LongText
			{
				get
				{
					return _item.LongText;
				}
				set
				{
					_item.LongText = value;
				}
			}

			[Category("Appearance")]
			[DefaultValue(null)]
			public Image Image
			{
				get
				{
					return _item.Image;
				}
				set
				{
					_item.Image = value;
				}
			}

			[Category("Appearance")]
			[DefaultValue(typeof(Color), "")]
			public Color ImageTransparentColor
			{
				get
				{
					return _item.ImageTransparentColor;
				}
				set
				{
					_item.ImageTransparentColor = value;
				}
			}

			[Category("Data")]
			[TypeConverter(typeof(StringConverter))]
			[DefaultValue(null)]
			public object Tag
			{
				get
				{
					return _item.Tag;
				}
				set
				{
					_item.Tag = value;
				}
			}

			public CrumbProxy(KryptonBreadCrumbItem item)
			{
				_item = item;
			}
		}

		protected class MenuTreeNode : TreeNode
		{
			private KryptonBreadCrumbItem _item;

			private object _propertyObject;

			public KryptonBreadCrumbItem Item => _item;

			public object PropertyObject => _propertyObject;

			public MenuTreeNode(KryptonBreadCrumbItem item)
			{
				_item = item;
				_propertyObject = item;
				base.Text = _item.ToString();
				_item.PropertyChanged += OnPropertyChanged;
			}

			private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
			{
				base.Text = _item.ToString();
			}
		}

		protected class PropertyGridSite : ISite, IServiceProvider
		{
			private IComponent _component;

			private IServiceProvider _serviceProvider;

			private bool _inGetService;

			public IComponent Component => _component;

			public IContainer Container => null;

			public bool DesignMode => false;

			public string Name
			{
				get
				{
					return null;
				}
				set
				{
				}
			}

			public PropertyGridSite(IServiceProvider servicePovider, IComponent component)
			{
				_serviceProvider = servicePovider;
				_component = component;
			}

			public object GetService(Type t)
			{
				if (!_inGetService && _serviceProvider != null)
				{
					try
					{
						_inGetService = true;
						return _serviceProvider.GetService(t);
					}
					finally
					{
						_inGetService = false;
					}
				}
				return null;
			}
		}

		private KryptonBreadCrumbItemsEditor _editor;

		private DictItemBase _beforeItems;

		private Button buttonOK;

		private TreeView treeView1;

		private Button buttonMoveUp;

		private Button buttonMoveDown;

		private Button buttonAddItem;

		private Button buttonDelete;

		private PropertyGrid propertyGrid1;

		private Label label1;

		private Label label2;

		private Button buttonAddChild;

		public KryptonBreadCrumbItemsForm(KryptonBreadCrumbItemsEditor editor)
			: base(editor)
		{
			_editor = editor;
			buttonOK = new Button();
			treeView1 = new TreeView();
			buttonMoveUp = new Button();
			buttonMoveDown = new Button();
			buttonAddItem = new Button();
			buttonDelete = new Button();
			propertyGrid1 = new PropertyGrid();
			label1 = new Label();
			label2 = new Label();
			buttonAddChild = new Button();
			SuspendLayout();
			buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonOK.DialogResult = DialogResult.OK;
			buttonOK.Location = new Point(547, 382);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new Size(75, 23);
			buttonOK.TabIndex = 8;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += buttonOK_Click;
			treeView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			treeView1.Location = new Point(12, 32);
			treeView1.Name = "treeView1";
			treeView1.Size = new Size(254, 339);
			treeView1.TabIndex = 1;
			treeView1.HideSelection = false;
			treeView1.AfterSelect += treeView1_AfterSelect;
			buttonMoveUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonMoveUp.Image = Resources.arrow_up_blue;
			buttonMoveUp.ImageAlign = ContentAlignment.MiddleLeft;
			buttonMoveUp.Location = new Point(272, 32);
			buttonMoveUp.Name = "buttonMoveUp";
			buttonMoveUp.Size = new Size(95, 28);
			buttonMoveUp.TabIndex = 2;
			buttonMoveUp.Text = "Move Up";
			buttonMoveUp.TextAlign = ContentAlignment.MiddleLeft;
			buttonMoveUp.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonMoveUp.UseVisualStyleBackColor = true;
			buttonMoveUp.Click += buttonMoveUp_Click;
			buttonMoveDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonMoveDown.Image = Resources.arrow_down_blue;
			buttonMoveDown.ImageAlign = ContentAlignment.MiddleLeft;
			buttonMoveDown.Location = new Point(272, 66);
			buttonMoveDown.Name = "buttonMoveDown";
			buttonMoveDown.Size = new Size(95, 28);
			buttonMoveDown.TabIndex = 3;
			buttonMoveDown.Text = "Move Down";
			buttonMoveDown.TextAlign = ContentAlignment.MiddleLeft;
			buttonMoveDown.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonMoveDown.UseVisualStyleBackColor = true;
			buttonMoveDown.Click += buttonMoveDown_Click;
			buttonAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddItem.Image = Resources.add;
			buttonAddItem.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddItem.Location = new Point(272, 112);
			buttonAddItem.Name = "buttonAddItem";
			buttonAddItem.Size = new Size(95, 28);
			buttonAddItem.TabIndex = 4;
			buttonAddItem.Text = "Add Sibling";
			buttonAddItem.TextAlign = ContentAlignment.MiddleLeft;
			buttonAddItem.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddItem.UseVisualStyleBackColor = true;
			buttonAddItem.Click += buttonAddSibling_Click;
			buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonDelete.Image = Resources.delete2;
			buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
			buttonDelete.Location = new Point(272, 190);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(95, 28);
			buttonDelete.TabIndex = 5;
			buttonDelete.Text = "Delete Item";
			buttonDelete.TextAlign = ContentAlignment.MiddleLeft;
			buttonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += buttonDelete_Click;
			propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			propertyGrid1.HelpVisible = false;
			propertyGrid1.Location = new Point(373, 32);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new Size(249, 339);
			propertyGrid1.TabIndex = 7;
			propertyGrid1.ToolbarVisible = false;
			label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label1.AutoSize = true;
			label1.Location = new Point(370, 13);
			label1.Name = "label1";
			label1.Size = new Size(81, 13);
			label1.TabIndex = 6;
			label1.Text = "Item Properties";
			label2.AutoSize = true;
			label2.Location = new Point(12, 13);
			label2.Name = "label2";
			label2.Size = new Size(142, 13);
			label2.TabIndex = 0;
			label2.Text = "BreadCrumbItems Collection";
			buttonAddChild.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddChild.Image = Resources.add;
			buttonAddChild.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddChild.Location = new Point(272, 146);
			buttonAddChild.Name = "buttonAddChild";
			buttonAddChild.Size = new Size(95, 28);
			buttonAddChild.TabIndex = 9;
			buttonAddChild.Text = "Add Child";
			buttonAddChild.TextAlign = ContentAlignment.MiddleLeft;
			buttonAddChild.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddChild.UseVisualStyleBackColor = true;
			buttonAddChild.Click += buttonAddChild_Click;
			base.AcceptButton = buttonOK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.ClientSize = new Size(634, 414);
			base.ControlBox = false;
			base.Controls.Add(buttonAddChild);
			base.Controls.Add(label2);
			base.Controls.Add(label1);
			base.Controls.Add(propertyGrid1);
			base.Controls.Add(buttonDelete);
			base.Controls.Add(buttonAddItem);
			base.Controls.Add(buttonMoveDown);
			base.Controls.Add(buttonMoveUp);
			base.Controls.Add(treeView1);
			base.Controls.Add(buttonOK);
			Font = new Font("Tahoma", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
			MinimumSize = new Size(501, 296);
			base.Name = "KryptonBreadCrumbCollectionForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "BreadCrumbItem Collection Editor";
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		protected override void OnEditValueChanged()
		{
			if (base.EditValue != null)
			{
				_beforeItems = CreateItemsDictionary(base.Items);
				propertyGrid1.Site = new PropertyGridSite(base.Context, propertyGrid1);
				treeView1.Nodes.Clear();
				object[] items = base.Items;
				for (int i = 0; i < items.Length; i++)
				{
					KryptonBreadCrumbItem item = (KryptonBreadCrumbItem)items[i];
					AddMenuTreeNode(item, null);
				}
				treeView1.ExpandAll();
				if (treeView1.Nodes.Count > 0)
				{
					treeView1.SelectedNode = treeView1.Nodes[0];
				}
				UpdateButtons();
				UpdatePropertyGrid();
			}
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			object[] array = new object[treeView1.Nodes.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((MenuTreeNode)treeView1.Nodes[i]).Item;
			}
			DictItemBase after = CreateItemsDictionary(array);
			base.Items = array;
			treeView1.Nodes.Clear();
			SynchronizeCollections(_beforeItems, after, base.Context);
			base.Context.OnComponentChanged();
		}

		private bool ContainsNode(TreeNode node, TreeNode find)
		{
			if (node.Nodes.Contains(find))
			{
				return true;
			}
			foreach (TreeNode node2 in node.Nodes)
			{
				if (ContainsNode(node2, find))
				{
					return true;
				}
			}
			return false;
		}

		private TreeNode NextNode(TreeNode currentNode)
		{
			if (currentNode == null)
			{
				return null;
			}
			bool found = false;
			return RecursiveFind(treeView1.Nodes, currentNode, ref found, forward: true);
		}

		private TreeNode PreviousNode(TreeNode currentNode)
		{
			if (currentNode == null)
			{
				return null;
			}
			bool found = false;
			return RecursiveFind(treeView1.Nodes, currentNode, ref found, forward: false);
		}

		private TreeNode RecursiveFind(TreeNodeCollection nodes, TreeNode target, ref bool found, bool forward)
		{
			for (int i = 0; i < nodes.Count; i++)
			{
				TreeNode treeNode = nodes[forward ? i : (nodes.Count - 1 - i)];
				if (forward)
				{
					if (found)
					{
						return treeNode;
					}
					found |= treeNode == target;
				}
				if (found && forward)
				{
					continue;
				}
				TreeNode treeNode2 = RecursiveFind(treeNode.Nodes, target, ref found, forward);
				if (treeNode2 != null)
				{
					return treeNode2;
				}
				if (found && target != treeNode)
				{
					return treeNode;
				}
				if (!forward)
				{
					if (found)
					{
						return treeNode;
					}
					found |= treeNode == target;
				}
			}
			return null;
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			MenuTreeNode menuTreeNode = (MenuTreeNode)treeView1.SelectedNode;
			if (menuTreeNode != null)
			{
				MenuTreeNode menuTreeNode2 = (MenuTreeNode)PreviousNode(menuTreeNode);
				if (menuTreeNode2 != null)
				{
					bool flag = ContainsNode(menuTreeNode2, menuTreeNode);
					MenuTreeNode menuTreeNode3 = (MenuTreeNode)menuTreeNode.Parent;
					TreeNodeCollection treeNodeCollection = ((menuTreeNode.Parent == null) ? treeView1.Nodes : menuTreeNode.Parent.Nodes);
					menuTreeNode3?.Item.Items.Remove(menuTreeNode.Item);
					treeNodeCollection.Remove(menuTreeNode);
					if (flag)
					{
						MenuTreeNode menuTreeNode4 = (MenuTreeNode)menuTreeNode2.Parent;
						treeNodeCollection = ((menuTreeNode2.Parent == null) ? treeView1.Nodes : menuTreeNode2.Parent.Nodes);
						int num = treeNodeCollection.IndexOf(menuTreeNode2);
						if (!flag && menuTreeNode4 != null && menuTreeNode4 != menuTreeNode3 && num == menuTreeNode4.Nodes.Count - 1)
						{
							num++;
						}
						menuTreeNode4?.Item.Items.Insert(num, menuTreeNode.Item);
						treeNodeCollection.Insert(num, menuTreeNode);
					}
					else
					{
						menuTreeNode3 = menuTreeNode2;
						menuTreeNode3.Item.Items.Insert(menuTreeNode3.Nodes.Count, menuTreeNode.Item);
						menuTreeNode3.Nodes.Insert(menuTreeNode3.Nodes.Count, menuTreeNode);
					}
				}
			}
			treeView1.SelectedNode = menuTreeNode;
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			MenuTreeNode menuTreeNode = (MenuTreeNode)treeView1.SelectedNode;
			if (menuTreeNode != null)
			{
				MenuTreeNode menuTreeNode2 = (MenuTreeNode)NextNode(menuTreeNode);
				if (menuTreeNode2 != null)
				{
					bool flag = ContainsNode(menuTreeNode2, menuTreeNode);
					MenuTreeNode menuTreeNode3 = (MenuTreeNode)menuTreeNode.Parent;
					TreeNodeCollection treeNodeCollection = ((menuTreeNode.Parent == null) ? treeView1.Nodes : menuTreeNode.Parent.Nodes);
					menuTreeNode3?.Item.Items.Remove(menuTreeNode.Item);
					treeNodeCollection.Remove(menuTreeNode);
					if (flag)
					{
						MenuTreeNode menuTreeNode4 = (MenuTreeNode)menuTreeNode2.Parent;
						treeNodeCollection = ((menuTreeNode2.Parent == null) ? treeView1.Nodes : menuTreeNode2.Parent.Nodes);
						int num = treeNodeCollection.IndexOf(menuTreeNode2);
						menuTreeNode4?.Item.Items.Insert(num + 1, menuTreeNode.Item);
						treeNodeCollection.Insert(num + 1, menuTreeNode);
					}
					else
					{
						menuTreeNode3 = menuTreeNode2;
						menuTreeNode3.Item.Items.Insert(0, menuTreeNode.Item);
						menuTreeNode3.Nodes.Insert(0, menuTreeNode);
					}
				}
			}
			treeView1.SelectedNode = menuTreeNode;
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonAddSibling_Click(object sender, EventArgs e)
		{
			KryptonBreadCrumbItem item = (KryptonBreadCrumbItem)CreateInstance(typeof(KryptonBreadCrumbItem));
			TreeNode treeNode = new MenuTreeNode(item);
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode == null)
			{
				treeView1.Nodes.Add(treeNode);
			}
			else
			{
				TreeNode treeNode2 = selectedNode.Parent;
				if (treeNode2 == null)
				{
					treeView1.Nodes.Insert(treeView1.Nodes.IndexOf(selectedNode) + 1, treeNode);
				}
				else
				{
					MenuTreeNode menuTreeNode = (MenuTreeNode)treeNode2;
					menuTreeNode.Item.Items.Insert(treeNode2.Nodes.IndexOf(selectedNode) + 1, item);
					treeNode2.Nodes.Insert(treeNode2.Nodes.IndexOf(selectedNode) + 1, treeNode);
				}
			}
			if (treeNode != null)
			{
				treeView1.SelectedNode = treeNode;
				treeView1.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonAddChild_Click(object sender, EventArgs e)
		{
			KryptonBreadCrumbItem item = (KryptonBreadCrumbItem)CreateInstance(typeof(KryptonBreadCrumbItem));
			TreeNode treeNode = new MenuTreeNode(item);
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode == null)
			{
				treeView1.Nodes.Add(treeNode);
			}
			else
			{
				MenuTreeNode menuTreeNode = (MenuTreeNode)selectedNode;
				menuTreeNode.Item.Items.Add(item);
				selectedNode.Nodes.Add(treeNode);
			}
			if (treeNode != null)
			{
				treeView1.SelectedNode = treeNode;
				treeView1.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode != null)
			{
				MenuTreeNode menuTreeNode = selectedNode as MenuTreeNode;
				if (selectedNode.Parent == null)
				{
					treeView1.Nodes.Remove(selectedNode);
				}
				else
				{
					TreeNode treeNode = selectedNode.Parent;
					MenuTreeNode menuTreeNode2 = treeNode as MenuTreeNode;
					menuTreeNode2.Item.Items.Remove(menuTreeNode.Item);
					selectedNode.Parent.Nodes.Remove(selectedNode);
				}
				treeView1.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
		{
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void UpdateButtons()
		{
			MenuTreeNode menuTreeNode = treeView1.SelectedNode as MenuTreeNode;
			buttonMoveUp.Enabled = menuTreeNode != null && PreviousNode(menuTreeNode) != null;
			buttonMoveDown.Enabled = menuTreeNode != null && NextNode(menuTreeNode) != null;
			buttonDelete.Enabled = menuTreeNode != null;
		}

		private void UpdatePropertyGrid()
		{
			TreeNode selectedNode = treeView1.SelectedNode;
			if (selectedNode == null)
			{
				propertyGrid1.SelectedObject = null;
			}
			else
			{
				propertyGrid1.SelectedObject = new CrumbProxy((KryptonBreadCrumbItem)((MenuTreeNode)selectedNode).PropertyObject);
			}
		}

		private DictItemBase CreateItemsDictionary(object[] items)
		{
			DictItemBase dictItemBase = new DictItemBase();
			for (int i = 0; i < items.Length; i++)
			{
				KryptonBreadCrumbItem baseItem = (KryptonBreadCrumbItem)items[i];
				AddItemsToDictionary(dictItemBase, baseItem);
			}
			return dictItemBase;
		}

		private void AddItemsToDictionary(DictItemBase dictItems, KryptonBreadCrumbItem baseItem)
		{
			dictItems.Add(baseItem, baseItem);
			foreach (KryptonBreadCrumbItem item in baseItem.Items)
			{
				AddItemsToDictionary(dictItems, item);
			}
		}

		private void AddMenuTreeNode(KryptonBreadCrumbItem item, MenuTreeNode parent)
		{
			MenuTreeNode node = new MenuTreeNode(item);
			if (parent != null)
			{
				parent.Nodes.Add(node);
			}
			else
			{
				treeView1.Nodes.Add(node);
			}
			foreach (KryptonBreadCrumbItem item2 in item.Items)
			{
				AddMenuTreeNode(item2, node);
			}
		}

		private void SynchronizeCollections(DictItemBase before, DictItemBase after, ITypeDescriptorContext context)
		{
			foreach (KryptonBreadCrumbItem value in after.Values)
			{
				if (!before.ContainsKey(value) && context.Container != null)
				{
					context.Container.Add(value);
				}
			}
			foreach (KryptonBreadCrumbItem value2 in before.Values)
			{
				if (!after.ContainsKey(value2))
				{
					DestroyInstance(value2);
					if (context.Container != null)
					{
						context.Container.Remove(value2);
					}
				}
			}
			IComponentChangeService componentChangeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
			if (componentChangeService == null)
			{
				return;
			}
			foreach (KryptonBreadCrumbItem value3 in after.Values)
			{
				if (before.ContainsKey(value3))
				{
					componentChangeService.OnComponentChanging(value3, null);
					componentChangeService.OnComponentChanged(value3, null, null, null);
				}
			}
		}
	}

	public KryptonBreadCrumbItemsEditor()
		: base(typeof(KryptonBreadCrumbItem.BreadCrumbItems))
	{
	}

	protected override CollectionForm CreateCollectionForm()
	{
		return new KryptonBreadCrumbItemsForm(this);
	}
}
