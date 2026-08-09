#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit.Properties;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonContextMenuCollectionEditor : CollectionEditor
{
	protected class KryptonContextMenuCollectionForm : CollectionForm
	{
		protected class DictItemBase : Dictionary<KryptonContextMenuItemBase, KryptonContextMenuItemBase>
		{
		}

		protected class MenuTreeNode : TreeNode
		{
			private KryptonContextMenuItemBase _item;

			private object _propertyObject;

			public KryptonContextMenuItemBase Item => _item;

			public object PropertyObject => _propertyObject;

			public MenuTreeNode(KryptonContextMenuItemBase item)
			{
				Debug.Assert(item != null);
				_item = item;
				_propertyObject = item;
				base.ImageIndex = ImageIndexFromItem();
				base.SelectedImageIndex = base.ImageIndex;
				base.Text = _item.ToString();
				_item.PropertyChanged += OnPropertyChanged;
			}

			private int ImageIndexFromItem()
			{
				if (_item is KryptonContextMenuCheckBox)
				{
					return 6;
				}
				if (_item is KryptonContextMenuCheckButton)
				{
					return 7;
				}
				if (_item is KryptonContextMenuColorColumns)
				{
					return 0;
				}
				if (_item is KryptonContextMenuHeading)
				{
					return 1;
				}
				if (_item is KryptonContextMenuItem)
				{
					return 2;
				}
				if (_item is KryptonContextMenuItems)
				{
					return 3;
				}
				if (_item is KryptonContextMenuLinkLabel)
				{
					return 8;
				}
				if (_item is KryptonContextMenuRadioButton)
				{
					return 5;
				}
				if (_item is KryptonContextMenuSeparator)
				{
					return 4;
				}
				if (_item is KryptonContextMenuImageSelect)
				{
					return 13;
				}
				if (_item is KryptonContextMenuMonthCalendar)
				{
					return 14;
				}
				Debug.Assert(condition: false);
				return -1;
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

		private DictItemBase _beforeItems;

		private KryptonContextMenuCollectionEditor _editor;

		private Button buttonOK;

		private TreeView treeView;

		private Label label1;

		private Label label2;

		private ImageList imageList;

		private Button buttonDelete;

		private Button buttonMoveUp;

		private Button buttonMoveDown;

		private Button buttonAddCheckBox;

		private Button buttonAddCheckButton;

		private Button buttonAddRadioButton;

		private Button buttonAddLinkLabel;

		private Button buttonAddSeparator;

		private Button buttonAddItem;

		private Button buttonAddItems;

		private Button buttonAddHeading;

		private Button buttonAddMonthCalendar;

		private Button buttonAddColorColumns;

		private Button buttonAddImageSelect;

		private PropertyGrid propertyGrid1;

		private IContainer components = null;

		public KryptonContextMenuCollectionForm(KryptonContextMenuCollectionEditor editor)
			: base(editor)
		{
			_editor = editor;
			components = new Container();
			buttonOK = new Button();
			treeView = new TreeView();
			imageList = new ImageList(components);
			label1 = new Label();
			buttonDelete = new Button();
			buttonMoveUp = new Button();
			buttonMoveDown = new Button();
			buttonAddCheckBox = new Button();
			buttonAddCheckButton = new Button();
			buttonAddRadioButton = new Button();
			buttonAddLinkLabel = new Button();
			buttonAddSeparator = new Button();
			buttonAddItem = new Button();
			buttonAddItems = new Button();
			buttonAddHeading = new Button();
			buttonAddMonthCalendar = new Button();
			propertyGrid1 = new PropertyGrid();
			label2 = new Label();
			buttonAddColorColumns = new Button();
			buttonAddImageSelect = new Button();
			SuspendLayout();
			buttonOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
			buttonOK.DialogResult = DialogResult.OK;
			buttonOK.Location = new Point(630, 504);
			buttonOK.Name = "buttonOK";
			buttonOK.Size = new Size(75, 23);
			buttonOK.TabIndex = 16;
			buttonOK.Text = "OK";
			buttonOK.UseVisualStyleBackColor = true;
			buttonOK.Click += buttonOK_Click;
			treeView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			treeView.HideSelection = false;
			treeView.ImageIndex = 0;
			treeView.ImageList = imageList;
			treeView.Location = new Point(16, 29);
			treeView.Name = "treeView";
			treeView.SelectedImageIndex = 0;
			treeView.Size = new Size(251, 466);
			treeView.TabIndex = 0;
			treeView.AfterSelect += SelectionChanged;
			imageList.TransparentColor = Color.Magenta;
			imageList.Images.AddRange(new Image[15]
			{
				Resources.KryptonContextMenuColorColumns,
				Resources.KryptonContextMenuHeading,
				Resources.KryptonContextMenuItem,
				Resources.KryptonContextMenuItems,
				Resources.KryptonContextMenuSeparator,
				Resources.KryptonRadioButton,
				Resources.KryptonCheckBox,
				Resources.KryptonCheckButton,
				Resources.KryptonLinkLabel,
				Resources.delete2,
				Resources.arrow_up_blue,
				Resources.arrow_down_blue,
				Resources.KryptonContextMenuColorColumns,
				Resources.KryptonContextMenuImageSelect,
				Resources.KryptonMonthCalendar
			});
			imageList.Images.SetKeyName(0, "KryptonContextMenuColorColumns.bmp");
			imageList.Images.SetKeyName(1, "KryptonContextMenuHeading.bmp");
			imageList.Images.SetKeyName(2, "KryptonContextMenuItem.bmp");
			imageList.Images.SetKeyName(3, "KryptonContextMenuItems.bmp");
			imageList.Images.SetKeyName(4, "KryptonContextMenuSeparator.bmp");
			imageList.Images.SetKeyName(5, "KryptonRadioButton.bmp");
			imageList.Images.SetKeyName(6, "KryptonCheckBox.bmp");
			imageList.Images.SetKeyName(7, "KryptonCheckButton.bmp");
			imageList.Images.SetKeyName(8, "KryptonLinkLabel.bmp");
			imageList.Images.SetKeyName(9, "delete2.png");
			imageList.Images.SetKeyName(10, "arrow_up_blue.png");
			imageList.Images.SetKeyName(11, "arrow_down_blue.png");
			imageList.Images.SetKeyName(12, "KryptonContextMenuColorColumns.bmp");
			imageList.Images.SetKeyName(13, "KryptonContextMenuImageSelect.bmp");
			label1.AutoSize = true;
			label1.Location = new Point(13, 11);
			label1.Name = "label1";
			label1.Size = new Size(75, 13);
			label1.TabIndex = 7;
			label1.Text = "Item Hierarchy";
			buttonDelete.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonDelete.ImageAlign = ContentAlignment.MiddleLeft;
			buttonDelete.ImageIndex = 9;
			buttonDelete.ImageList = imageList;
			buttonDelete.Location = new Point(282, 467);
			buttonDelete.Name = "buttonDelete";
			buttonDelete.Size = new Size(144, 28);
			buttonDelete.TabIndex = 14;
			buttonDelete.Text = "Delete";
			buttonDelete.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonDelete.UseVisualStyleBackColor = true;
			buttonDelete.Click += buttonDelete_Click;
			buttonMoveUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonMoveUp.ImageAlign = ContentAlignment.MiddleLeft;
			buttonMoveUp.ImageIndex = 10;
			buttonMoveUp.ImageList = imageList;
			buttonMoveUp.Location = new Point(282, 29);
			buttonMoveUp.Name = "buttonMoveUp";
			buttonMoveUp.Size = new Size(144, 28);
			buttonMoveUp.TabIndex = 1;
			buttonMoveUp.Text = "Move Up";
			buttonMoveUp.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonMoveUp.UseVisualStyleBackColor = true;
			buttonMoveUp.Click += buttonMoveUp_Click;
			buttonMoveDown.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonMoveDown.ImageAlign = ContentAlignment.MiddleLeft;
			buttonMoveDown.ImageIndex = 11;
			buttonMoveDown.ImageList = imageList;
			buttonMoveDown.Location = new Point(282, 60);
			buttonMoveDown.Name = "buttonMoveDown";
			buttonMoveDown.Size = new Size(144, 28);
			buttonMoveDown.TabIndex = 2;
			buttonMoveDown.Text = "Move Down";
			buttonMoveDown.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonMoveDown.UseVisualStyleBackColor = true;
			buttonMoveDown.Click += buttonMoveDown_Click;
			buttonAddCheckBox.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddCheckBox.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddCheckBox.ImageIndex = 6;
			buttonAddCheckBox.ImageList = imageList;
			buttonAddCheckBox.Location = new Point(282, 231);
			buttonAddCheckBox.Name = "buttonAddCheckBox";
			buttonAddCheckBox.Size = new Size(144, 28);
			buttonAddCheckBox.TabIndex = 7;
			buttonAddCheckBox.Text = "Add CheckBox";
			buttonAddCheckBox.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddCheckBox.UseVisualStyleBackColor = true;
			buttonAddCheckBox.Click += buttonAddCheckBox_Click;
			buttonAddCheckButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddCheckButton.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddCheckButton.ImageIndex = 7;
			buttonAddCheckButton.ImageList = imageList;
			buttonAddCheckButton.Location = new Point(282, 263);
			buttonAddCheckButton.Name = "buttonAddCheckButton";
			buttonAddCheckButton.Size = new Size(144, 28);
			buttonAddCheckButton.TabIndex = 8;
			buttonAddCheckButton.Text = "Add CheckButton";
			buttonAddCheckButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddCheckButton.UseVisualStyleBackColor = true;
			buttonAddCheckButton.Click += buttonAddCheckButton_Click;
			buttonAddRadioButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddRadioButton.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddRadioButton.ImageIndex = 5;
			buttonAddRadioButton.ImageList = imageList;
			buttonAddRadioButton.Location = new Point(282, 295);
			buttonAddRadioButton.Name = "buttonAddRadioButton";
			buttonAddRadioButton.Size = new Size(144, 28);
			buttonAddRadioButton.TabIndex = 9;
			buttonAddRadioButton.Text = "Add RadioButton";
			buttonAddRadioButton.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddRadioButton.UseVisualStyleBackColor = true;
			buttonAddRadioButton.Click += buttonAddRadioButton_Click;
			buttonAddLinkLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddLinkLabel.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddLinkLabel.ImageIndex = 8;
			buttonAddLinkLabel.ImageList = imageList;
			buttonAddLinkLabel.Location = new Point(282, 327);
			buttonAddLinkLabel.Name = "buttonAddLinkLabel";
			buttonAddLinkLabel.Size = new Size(144, 28);
			buttonAddLinkLabel.TabIndex = 10;
			buttonAddLinkLabel.Text = "Add LinkLabel";
			buttonAddLinkLabel.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddLinkLabel.UseVisualStyleBackColor = true;
			buttonAddLinkLabel.Click += buttonAddLinkLabel_Click;
			buttonAddSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddSeparator.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddSeparator.ImageIndex = 4;
			buttonAddSeparator.ImageList = imageList;
			buttonAddSeparator.Location = new Point(282, 199);
			buttonAddSeparator.Name = "buttonAddSeparator";
			buttonAddSeparator.Size = new Size(144, 28);
			buttonAddSeparator.TabIndex = 6;
			buttonAddSeparator.Text = "Add Separator";
			buttonAddSeparator.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddSeparator.UseVisualStyleBackColor = true;
			buttonAddSeparator.Click += buttonAddSeparator_Click;
			buttonAddItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddItem.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddItem.ImageIndex = 2;
			buttonAddItem.ImageList = imageList;
			buttonAddItem.Location = new Point(282, 103);
			buttonAddItem.Name = "buttonAddItem";
			buttonAddItem.Size = new Size(144, 28);
			buttonAddItem.TabIndex = 3;
			buttonAddItem.Text = "Add Item";
			buttonAddItem.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddItem.UseVisualStyleBackColor = true;
			buttonAddItem.Click += buttonAddItem_Click;
			buttonAddItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddItems.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddItems.ImageIndex = 3;
			buttonAddItems.ImageList = imageList;
			buttonAddItems.Location = new Point(282, 135);
			buttonAddItems.Name = "buttonAddItems";
			buttonAddItems.Size = new Size(144, 28);
			buttonAddItems.TabIndex = 4;
			buttonAddItems.Text = "Add Items";
			buttonAddItems.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddItems.UseVisualStyleBackColor = true;
			buttonAddItems.Click += buttonAddItems_Click;
			buttonAddHeading.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddHeading.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddHeading.ImageIndex = 1;
			buttonAddHeading.ImageList = imageList;
			buttonAddHeading.Location = new Point(282, 167);
			buttonAddHeading.Name = "buttonAddHeading";
			buttonAddHeading.Size = new Size(144, 28);
			buttonAddHeading.TabIndex = 5;
			buttonAddHeading.Text = "Add Heading";
			buttonAddHeading.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddHeading.UseVisualStyleBackColor = true;
			buttonAddHeading.Click += buttonAddHeading_Click;
			buttonAddMonthCalendar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddMonthCalendar.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddMonthCalendar.ImageIndex = 14;
			buttonAddMonthCalendar.ImageList = imageList;
			buttonAddMonthCalendar.Location = new Point(282, 423);
			buttonAddMonthCalendar.Name = "buttonAddMonthCalendar";
			buttonAddMonthCalendar.Size = new Size(144, 28);
			buttonAddMonthCalendar.TabIndex = 13;
			buttonAddMonthCalendar.Text = "Add Month Calendar";
			buttonAddMonthCalendar.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddMonthCalendar.UseVisualStyleBackColor = true;
			buttonAddMonthCalendar.Click += buttonAddMonthCalendar_Click;
			propertyGrid1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
			propertyGrid1.HelpVisible = false;
			propertyGrid1.Location = new Point(439, 29);
			propertyGrid1.Name = "propertyGrid1";
			propertyGrid1.Size = new Size(266, 466);
			propertyGrid1.TabIndex = 15;
			propertyGrid1.ToolbarVisible = false;
			label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			label2.AutoSize = true;
			label2.Location = new Point(436, 11);
			label2.Name = "label2";
			label2.Size = new Size(77, 13);
			label2.TabIndex = 16;
			label2.Text = "Item Properties";
			buttonAddColorColumns.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddColorColumns.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddColorColumns.ImageIndex = 12;
			buttonAddColorColumns.ImageList = imageList;
			buttonAddColorColumns.Location = new Point(282, 359);
			buttonAddColorColumns.Name = "buttonAddColorColumns";
			buttonAddColorColumns.Size = new Size(144, 28);
			buttonAddColorColumns.TabIndex = 11;
			buttonAddColorColumns.Text = "Add ColorColumns";
			buttonAddColorColumns.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddColorColumns.UseVisualStyleBackColor = true;
			buttonAddColorColumns.Click += buttonAddColorColumns_Click;
			buttonAddImageSelect.Anchor = AnchorStyles.Top | AnchorStyles.Right;
			buttonAddImageSelect.ImageAlign = ContentAlignment.MiddleLeft;
			buttonAddImageSelect.ImageIndex = 13;
			buttonAddImageSelect.ImageList = imageList;
			buttonAddImageSelect.Location = new Point(282, 391);
			buttonAddImageSelect.Name = "buttonAddImageSelect";
			buttonAddImageSelect.Size = new Size(144, 28);
			buttonAddImageSelect.TabIndex = 12;
			buttonAddImageSelect.Text = "Add ImageSelect";
			buttonAddImageSelect.TextImageRelation = TextImageRelation.ImageBeforeText;
			buttonAddImageSelect.UseVisualStyleBackColor = true;
			buttonAddImageSelect.Click += buttonAddImageSelect_Click;
			base.AcceptButton = buttonOK;
			base.AutoScaleMode = AutoScaleMode.None;
			base.ClientSize = new Size(717, 557);
			base.ControlBox = false;
			base.Controls.Add(buttonAddColorColumns);
			base.Controls.Add(buttonAddImageSelect);
			base.Controls.Add(label2);
			base.Controls.Add(propertyGrid1);
			base.Controls.Add(buttonAddMonthCalendar);
			base.Controls.Add(buttonAddHeading);
			base.Controls.Add(buttonAddItems);
			base.Controls.Add(buttonAddItem);
			base.Controls.Add(buttonAddSeparator);
			base.Controls.Add(buttonAddLinkLabel);
			base.Controls.Add(buttonAddRadioButton);
			base.Controls.Add(buttonAddCheckButton);
			base.Controls.Add(buttonAddCheckBox);
			base.Controls.Add(buttonMoveDown);
			base.Controls.Add(buttonMoveUp);
			base.Controls.Add(buttonDelete);
			base.Controls.Add(label1);
			base.Controls.Add(treeView);
			base.Controls.Add(buttonOK);
			MinimumSize = new Size(733, 593);
			base.Name = "KryptonContextMenuEditorForm";
			base.StartPosition = FormStartPosition.CenterScreen;
			Text = "KryptonContextMenu Items Editor";
			base.Load += KryptonContextMenuEditorForm_Load;
			ResumeLayout(performLayout: false);
			PerformLayout();
		}

		protected override void OnEditValueChanged()
		{
			if (base.EditValue != null)
			{
				_beforeItems = CreateItemsDictionary(base.Items);
				propertyGrid1.Site = new PropertyGridSite(base.Context, propertyGrid1);
				treeView.Nodes.Clear();
				object[] items = base.Items;
				for (int i = 0; i < items.Length; i++)
				{
					KryptonContextMenuItemBase item = (KryptonContextMenuItemBase)items[i];
					AddMenuTreeNode(item, null);
				}
				treeView.ExpandAll();
				if (treeView.Nodes.Count > 0)
				{
					treeView.SelectedNode = treeView.Nodes[0];
				}
				UpdateButtons();
				UpdatePropertyGrid();
			}
		}

		private void KryptonContextMenuEditorForm_Load(object sender, EventArgs e)
		{
			propertyGrid1.BrowsableAttributes = new AttributeCollection(new KryptonPersistAttribute());
		}

		private void buttonOK_Click(object sender, EventArgs e)
		{
			object[] array = new object[treeView.Nodes.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ((MenuTreeNode)treeView.Nodes[i]).Item;
			}
			DictItemBase after = CreateItemsDictionary(array);
			base.Items = array;
			treeView.Nodes.Clear();
			SynchronizeCollections(_beforeItems, after, base.Context);
			base.Context.OnComponentChanged();
		}

		private void buttonMoveUp_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView.SelectedNode;
			if (selectedNode != null)
			{
				MenuTreeNode menuTreeNode = selectedNode as MenuTreeNode;
				if (selectedNode.Parent == null)
				{
					int num = treeView.Nodes.IndexOf(selectedNode);
					treeView.Nodes.Remove(selectedNode);
					treeView.Nodes.Insert(num - 1, selectedNode);
				}
				else
				{
					int num2 = selectedNode.Parent.Nodes.IndexOf(selectedNode);
					TreeNode treeNode = selectedNode.Parent;
					MenuTreeNode menuTreeNode2 = treeNode as MenuTreeNode;
					if (menuTreeNode2.Item is KryptonContextMenuItems)
					{
						KryptonContextMenuItems kryptonContextMenuItems = menuTreeNode2.Item as KryptonContextMenuItems;
						kryptonContextMenuItems.Items.Remove(menuTreeNode.Item);
						kryptonContextMenuItems.Items.Insert(num2 - 1, menuTreeNode.Item);
					}
					else if (menuTreeNode2.Item is KryptonContextMenuItem)
					{
						KryptonContextMenuItem kryptonContextMenuItem = menuTreeNode2.Item as KryptonContextMenuItem;
						kryptonContextMenuItem.Items.Remove(menuTreeNode.Item);
						kryptonContextMenuItem.Items.Insert(num2 - 1, menuTreeNode.Item);
					}
					treeNode.Nodes.Remove(selectedNode);
					treeNode.Nodes.Insert(num2 - 1, selectedNode);
				}
				treeView.SelectedNode = selectedNode;
				treeView.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonMoveDown_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView.SelectedNode;
			if (selectedNode != null)
			{
				MenuTreeNode menuTreeNode = selectedNode as MenuTreeNode;
				if (selectedNode.Parent == null)
				{
					int num = treeView.Nodes.IndexOf(selectedNode);
					treeView.Nodes.Remove(selectedNode);
					treeView.Nodes.Insert(num + 1, selectedNode);
				}
				else
				{
					int num2 = selectedNode.Parent.Nodes.IndexOf(selectedNode);
					TreeNode treeNode = selectedNode.Parent;
					MenuTreeNode menuTreeNode2 = treeNode as MenuTreeNode;
					if (menuTreeNode2.Item is KryptonContextMenuItems)
					{
						KryptonContextMenuItems kryptonContextMenuItems = menuTreeNode2.Item as KryptonContextMenuItems;
						kryptonContextMenuItems.Items.Remove(menuTreeNode.Item);
						kryptonContextMenuItems.Items.Insert(num2 + 1, menuTreeNode.Item);
					}
					else if (menuTreeNode2.Item is KryptonContextMenuItem)
					{
						KryptonContextMenuItem kryptonContextMenuItem = menuTreeNode2.Item as KryptonContextMenuItem;
						kryptonContextMenuItem.Items.Remove(menuTreeNode.Item);
						kryptonContextMenuItem.Items.Insert(num2 + 1, menuTreeNode.Item);
					}
					treeNode.Nodes.Remove(selectedNode);
					treeNode.Nodes.Insert(num2 + 1, selectedNode);
				}
				treeView.SelectedNode = selectedNode;
				treeView.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void buttonAddItem_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuItem)));
		}

		private void buttonAddItems_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuItems)));
		}

		private void buttonAddHeading_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuHeading)));
		}

		private void buttonAddMonthCalendar_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuMonthCalendar)));
		}

		private void buttonAddSeparator_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuSeparator)));
		}

		private void buttonAddCheckBox_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuCheckBox)));
		}

		private void buttonAddCheckButton_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuCheckButton)));
		}

		private void buttonAddRadioButton_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuRadioButton)));
		}

		private void buttonAddLinkLabel_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuLinkLabel)));
		}

		private void buttonAddColorColumns_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuColorColumns)));
		}

		private void buttonAddImageSelect_Click(object sender, EventArgs e)
		{
			AddNewItem((KryptonContextMenuItemBase)CreateInstance(typeof(KryptonContextMenuImageSelect)));
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			TreeNode selectedNode = treeView.SelectedNode;
			if (selectedNode != null)
			{
				MenuTreeNode menuTreeNode = selectedNode as MenuTreeNode;
				if (selectedNode.Parent == null)
				{
					treeView.Nodes.Remove(selectedNode);
				}
				else
				{
					TreeNode treeNode = selectedNode.Parent;
					MenuTreeNode menuTreeNode2 = treeNode as MenuTreeNode;
					if (menuTreeNode2.Item is KryptonContextMenuItems)
					{
						KryptonContextMenuItems kryptonContextMenuItems = menuTreeNode2.Item as KryptonContextMenuItems;
						kryptonContextMenuItems.Items.Remove(menuTreeNode.Item);
					}
					else if (menuTreeNode2.Item is KryptonContextMenuItem)
					{
						KryptonContextMenuItem kryptonContextMenuItem = menuTreeNode2.Item as KryptonContextMenuItem;
						kryptonContextMenuItem.Items.Remove(menuTreeNode.Item);
					}
					selectedNode.Parent.Nodes.Remove(selectedNode);
				}
				treeView.Focus();
			}
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void SelectionChanged(object sender, TreeViewEventArgs e)
		{
			UpdateButtons();
			UpdatePropertyGrid();
		}

		private void UpdatePropertyGrid()
		{
			TreeNode selectedNode = treeView.SelectedNode;
			if (selectedNode == null)
			{
				propertyGrid1.SelectedObject = null;
			}
			else
			{
				propertyGrid1.SelectedObject = ((MenuTreeNode)selectedNode).PropertyObject;
			}
		}

		private void AddMenuTreeNode(KryptonContextMenuItemBase item, MenuTreeNode parent)
		{
			MenuTreeNode node = new MenuTreeNode(item);
			if (parent != null)
			{
				parent.Nodes.Add(node);
			}
			else
			{
				treeView.Nodes.Add(node);
			}
			if (item is KryptonContextMenuItems)
			{
				KryptonContextMenuItems kryptonContextMenuItems = (KryptonContextMenuItems)item;
				{
					foreach (KryptonContextMenuItemBase item2 in kryptonContextMenuItems.Items)
					{
						AddMenuTreeNode(item2, node);
					}
					return;
				}
			}
			if (!(item is KryptonContextMenuItem))
			{
				return;
			}
			KryptonContextMenuItem kryptonContextMenuItem = (KryptonContextMenuItem)item;
			foreach (KryptonContextMenuItemBase item3 in kryptonContextMenuItem.Items)
			{
				AddMenuTreeNode(item3, node);
			}
		}

		private void AddNewItem(KryptonContextMenuItemBase item)
		{
			TreeNode selectedNode = treeView.SelectedNode;
			TreeNode treeNode = new MenuTreeNode(item);
			if (selectedNode == null)
			{
				treeView.Nodes.Add(treeNode);
			}
			else if (selectedNode.Parent == null)
			{
				if (item is KryptonContextMenuItem)
				{
					MenuTreeNode menuTreeNode = selectedNode as MenuTreeNode;
					KryptonContextMenuItems kryptonContextMenuItems = menuTreeNode.Item as KryptonContextMenuItems;
					kryptonContextMenuItems.Items.Add(item);
					selectedNode.Nodes.Add(treeNode);
				}
				else
				{
					int num = treeView.Nodes.IndexOf(selectedNode);
					treeView.Nodes.Insert(num + 1, treeNode);
				}
			}
			else
			{
				int num2 = selectedNode.Parent.Nodes.IndexOf(selectedNode);
				TreeNode treeNode2 = selectedNode.Parent;
				MenuTreeNode menuTreeNode2 = treeNode2 as MenuTreeNode;
				if (menuTreeNode2.Item is KryptonContextMenuItems)
				{
					if (ValidInItemCollection(item))
					{
						KryptonContextMenuItems kryptonContextMenuItems2 = menuTreeNode2.Item as KryptonContextMenuItems;
						kryptonContextMenuItems2.Items.Insert(num2 + 1, item);
						selectedNode.Parent.Nodes.Insert(num2 + 1, treeNode);
					}
					else
					{
						MenuTreeNode menuTreeNode3 = selectedNode as MenuTreeNode;
						Debug.Assert(menuTreeNode3.Item is KryptonContextMenuItem);
						KryptonContextMenuItem kryptonContextMenuItem = menuTreeNode3.Item as KryptonContextMenuItem;
						kryptonContextMenuItem.Items.Add(item);
						selectedNode.Nodes.Add(treeNode);
					}
				}
				else if (menuTreeNode2.Item is KryptonContextMenuItem)
				{
					if (ValidInCollection(item))
					{
						KryptonContextMenuItem kryptonContextMenuItem2 = menuTreeNode2.Item as KryptonContextMenuItem;
						kryptonContextMenuItem2.Items.Insert(num2 + 1, item);
						selectedNode.Parent.Nodes.Insert(num2 + 1, treeNode);
					}
					else
					{
						MenuTreeNode menuTreeNode4 = selectedNode as MenuTreeNode;
						Debug.Assert(menuTreeNode4.Item is KryptonContextMenuItems);
						KryptonContextMenuItems kryptonContextMenuItems3 = menuTreeNode4.Item as KryptonContextMenuItems;
						kryptonContextMenuItems3.Items.Add(item);
						selectedNode.Nodes.Add(treeNode);
					}
				}
			}
			if (treeNode != null)
			{
				treeView.SelectedNode = treeNode;
				treeView.Focus();
			}
			UpdateButtons();
		}

		private void UpdateButtons()
		{
			KryptonContextMenuItemBase kryptonContextMenuItemBase = null;
			KryptonContextMenuItemBase kryptonContextMenuItemBase2 = null;
			int count = treeView.Nodes.Count;
			int num = -1;
			if (treeView.SelectedNode is MenuTreeNode menuTreeNode)
			{
				kryptonContextMenuItemBase = menuTreeNode.Item;
				num = treeView.Nodes.IndexOf(menuTreeNode);
				if (menuTreeNode.Parent != null)
				{
					count = menuTreeNode.Parent.Nodes.Count;
					num = menuTreeNode.Parent.Nodes.IndexOf(menuTreeNode);
					if (menuTreeNode.Parent is MenuTreeNode menuTreeNode2)
					{
						kryptonContextMenuItemBase2 = menuTreeNode2.Item;
					}
				}
			}
			buttonMoveUp.Enabled = kryptonContextMenuItemBase != null && num > 0;
			buttonMoveDown.Enabled = kryptonContextMenuItemBase != null && num < count - 1;
			buttonAddItem.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuItem));
			buttonAddItems.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuItems));
			buttonAddSeparator.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuSeparator));
			buttonAddHeading.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuHeading));
			buttonAddMonthCalendar.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuMonthCalendar));
			buttonAddCheckBox.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuCheckBox));
			buttonAddCheckButton.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuCheckButton));
			buttonAddRadioButton.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuRadioButton));
			buttonAddLinkLabel.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuLinkLabel));
			buttonAddColorColumns.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuColorColumns));
			buttonAddImageSelect.Enabled = AllowAddItem(kryptonContextMenuItemBase, kryptonContextMenuItemBase2, typeof(KryptonContextMenuImageSelect));
			buttonDelete.Enabled = kryptonContextMenuItemBase != null;
		}

		private bool AllowAddItem(KryptonContextMenuItemBase item, KryptonContextMenuItemBase parent, Type addType)
		{
			if (item is KryptonContextMenuItems && addType.Equals(typeof(KryptonContextMenuItem)))
			{
				return true;
			}
			if (ItemInsideCollection(item, parent))
			{
				KryptonContextMenuCollection kryptonContextMenuCollection = new KryptonContextMenuCollection();
				Type[] restrictTypes = kryptonContextMenuCollection.RestrictTypes;
				foreach (Type type in restrictTypes)
				{
					if (type.Equals(addType))
					{
						return true;
					}
				}
			}
			else
			{
				KryptonContextMenuItemCollection kryptonContextMenuItemCollection = new KryptonContextMenuItemCollection();
				Type[] restrictTypes2 = kryptonContextMenuItemCollection.RestrictTypes;
				foreach (Type type2 in restrictTypes2)
				{
					if (type2.Equals(addType))
					{
						return true;
					}
				}
				if (item != null && item is KryptonContextMenuItem)
				{
					KryptonContextMenuCollection kryptonContextMenuCollection2 = new KryptonContextMenuCollection();
					Type[] restrictTypes3 = kryptonContextMenuCollection2.RestrictTypes;
					foreach (Type type3 in restrictTypes3)
					{
						if (type3.Equals(addType))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		private bool ValidInCollection(KryptonContextMenuItemBase item)
		{
			Type type = item.GetType();
			KryptonContextMenuCollection kryptonContextMenuCollection = new KryptonContextMenuCollection();
			Type[] restrictTypes = kryptonContextMenuCollection.RestrictTypes;
			foreach (Type type2 in restrictTypes)
			{
				if (type2.Equals(type))
				{
					return true;
				}
			}
			return false;
		}

		private bool ValidInItemCollection(KryptonContextMenuItemBase item)
		{
			Type type = item.GetType();
			KryptonContextMenuItemCollection kryptonContextMenuItemCollection = new KryptonContextMenuItemCollection();
			Type[] restrictTypes = kryptonContextMenuItemCollection.RestrictTypes;
			foreach (Type type2 in restrictTypes)
			{
				if (type2.Equals(type))
				{
					return true;
				}
			}
			return false;
		}

		private bool ItemInsideCollection(KryptonContextMenuItemBase item, KryptonContextMenuItemBase parent)
		{
			if (parent == null)
			{
				return true;
			}
			return !(parent is KryptonContextMenuItems);
		}

		private DictItemBase CreateItemsDictionary(object[] items)
		{
			DictItemBase dictItemBase = new DictItemBase();
			for (int i = 0; i < items.Length; i++)
			{
				KryptonContextMenuItemBase baseItem = (KryptonContextMenuItemBase)items[i];
				AddItemsToDictionary(dictItemBase, baseItem);
			}
			return dictItemBase;
		}

		private void AddItemsToDictionary(DictItemBase dictItems, KryptonContextMenuItemBase baseItem)
		{
			dictItems.Add(baseItem, baseItem);
			if (baseItem is KryptonContextMenuItems)
			{
				KryptonContextMenuItems kryptonContextMenuItems = (KryptonContextMenuItems)baseItem;
				foreach (KryptonContextMenuItemBase item in kryptonContextMenuItems.Items)
				{
					AddItemsToDictionary(dictItems, item);
				}
			}
			if (!(baseItem is KryptonContextMenuItem))
			{
				return;
			}
			KryptonContextMenuItem kryptonContextMenuItem = (KryptonContextMenuItem)baseItem;
			foreach (KryptonContextMenuItemBase item2 in kryptonContextMenuItem.Items)
			{
				AddItemsToDictionary(dictItems, item2);
			}
		}

		private void SynchronizeCollections(DictItemBase before, DictItemBase after, ITypeDescriptorContext context)
		{
			foreach (KryptonContextMenuItemBase value in after.Values)
			{
				if (!before.ContainsKey(value) && context.Container != null)
				{
					context.Container.Add(value);
				}
			}
			foreach (KryptonContextMenuItemBase value2 in before.Values)
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
			foreach (KryptonContextMenuItemBase value3 in after.Values)
			{
				if (before.ContainsKey(value3))
				{
					componentChangeService.OnComponentChanging(value3, null);
					componentChangeService.OnComponentChanged(value3, null, null, null);
				}
			}
		}
	}

	public KryptonContextMenuCollectionEditor()
		: base(typeof(KryptonContextMenuCollection))
	{
	}

	protected override CollectionForm CreateCollectionForm()
	{
		return new KryptonContextMenuCollectionForm(this);
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[10]
		{
			typeof(KryptonContextMenuItems),
			typeof(KryptonContextMenuSeparator),
			typeof(KryptonContextMenuHeading),
			typeof(KryptonContextMenuLinkLabel),
			typeof(KryptonContextMenuCheckBox),
			typeof(KryptonContextMenuCheckButton),
			typeof(KryptonContextMenuRadioButton),
			typeof(KryptonContextMenuColorColumns),
			typeof(KryptonContextMenuMonthCalendar),
			typeof(KryptonContextMenuImageSelect)
		};
	}
}
