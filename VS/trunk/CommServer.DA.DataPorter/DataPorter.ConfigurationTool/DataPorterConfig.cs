//<summary>
//  Title   : Configurator for The DataPorter
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    mzrzezny - 2004 - created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CAS.DataPorter.Configurator.HMI;
using CAS.DataPorter.Configurator.HMI.Editors;
using CAS.DataPorter.Configurator.HMI.Wrappers;
using CAS.Lib.ControlLibrary;
using CAS.Lib.ControlLibrary.GDI;
using NetworkConfig;
using Opc.Da;

namespace CAS.DataPorter.Configurator
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class Form1 : System.Windows.Forms.Form
  {
    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabSubItem;
    private System.Windows.Forms.TabPage tabTransition;
    private System.Windows.Forms.TabPage tabServers;
    private System.Windows.Forms.DataGrid dataGridServers;
    private System.Windows.Forms.DataGrid dataGridSubscription;
    private System.Windows.Forms.DataGrid dataGridItem;
    private System.Windows.Forms.DataGrid dataGridTransition;
    private System.Windows.Forms.Button ReadXMLButton;
    private System.Windows.Forms.Button SaveXMLButton;
    private System.Windows.Forms.SaveFileDialog saveFileDialogXML;
    private OPCCliConfiguration opcCliConfiguration;
    private System.Windows.Forms.DataGridTableStyle SUBSCRIPTION_TableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_IDColumn;
    //private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_ID_ServerColumn;
    private DataGridComboBoxColumn SUBSCRIPTION_ID_ServerColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_NameColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_UpdateRateColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_TransactionRateColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_LocaleColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_KeepaliveRateColumn;
    private System.Windows.Forms.DataGridTextBoxColumn SUBSCRIPTION_Deadband;
    private System.Windows.Forms.DataGridTableStyle ITEM_TableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn ITEM_IDColumn;
    //private System.Windows.Forms.DataGridTextBoxColumn ITEM_ID_SubscriptionColumn;
    private DataGridComboBoxColumn ITEM_ID_SubscriptionColumn;
    //private System.Windows.Forms.DataGridTextBoxColumn ITEM_ID_ServerColumn;
    private DataGridComboBoxColumn ITEM_ID_ServerColumn;
    private System.Windows.Forms.DataGridTextBoxColumn ITEM_NameColumn;
    private System.Windows.Forms.DataGridTextBoxColumn ITEM_TypeColumn;
    private System.Windows.Forms.DataGridBoolColumn ITEM_AsyncColumn;
    private System.Windows.Forms.DataGridTextBoxColumn ITEM_ConversionColumn;
    //private System.Windows.Forms.DataGridTextBoxColumn ITEM_ID_TransactionColumn;
    private DataGridComboBoxColumn ITEM_ID_TransactionColumn;
    private System.Windows.Forms.DataGridTableStyle TRANSITION_TableStyle;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_Column;
    //private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_SubscriptionColumn;
    private DataGridComboBoxColumn TRANSITION_ID_SubscriptionColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_ItemINColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_SubINColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_ItemOUTColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_ID_NextColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_TransitionTypeColumn;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_Param1Column;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_DeadbandColumn;
    private System.Windows.Forms.DataGridBoolColumn TRANSITION_IsLeafColumn;
    private System.Windows.Forms.Button importButton;
    private System.Windows.Forms.ComboBox comboBoxserverID;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button clearButton;
    private System.Windows.Forms.OpenFileDialog openFileDialog;
    private System.Windows.Forms.DataGridTextBoxColumn TRANSITION_MinUpdateRateColum;
    private System.Windows.Forms.TextBox textBoxsmplrate;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button importGLSButton;
    private System.Windows.Forms.DataGridTextBoxColumn ITEM_MaxAgeColumn;
    private System.Windows.Forms.MainMenu mainMenu_dialog;
    private System.Windows.Forms.MenuItem menuItem5;
    private System.Windows.Forms.MenuItem menuItem6;
    private System.Windows.Forms.MenuItem menuItem_mainmenu;
    private System.Windows.Forms.MenuItem menuItem_open;
    private System.Windows.Forms.MenuItem menuItem_save;
    private System.Windows.Forms.MenuItem menuItem_import;
    private System.Windows.Forms.MenuItem menuItem_clear;
    private System.Windows.Forms.MenuItem menuItem_close;
    private System.Windows.Forms.MenuItem menuItem_help;
    private System.Windows.Forms.MenuItem menuItem_helpwindow;
    private System.Windows.Forms.MenuItem menuItem_about;
    private System.Windows.Forms.MenuItem menuItem1;
    private System.Windows.Forms.Button button_import_itemdsc;
    private System.Windows.Forms.MenuItem menuItem_imp_item_dsc;
    private System.Windows.Forms.Button button_exit;
    private System.Windows.Forms.MenuItem menuItem_itemdsc;
    private System.Windows.Forms.MenuItem menuItem3;
    private System.Windows.Forms.Button button_import_item_settings;
    private System.Windows.Forms.MenuItem menuItem_imp_item_sett;
    private System.Windows.Forms.Button button_edit_oper_param;
    private System.Windows.Forms.Button button_edit_trans_param;
    private StatusStrip statusStrip1;
    private ToolStripStatusLabel toolStripStatusLabel_numberoftags;
    private Button button_import_tag_list;
    private Panel panel1;
    private TableLayoutPanel tableLayoutPanel1;
    private TableLayoutPanel tableLayoutPanel2;
    private MenuItem menuItem2;
    private TabPage tabPage_TRansactionTree;
    private DataGridViewTextBoxColumn iDTransactionDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn iDOperationDataGridViewTextBoxColumn1;
    private DataGridView dataGridView1;
    private BindingSource operationLinksBindingSource;
    private DataGridViewTextBoxColumn iDOperationDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn inputnumberDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn iDChildOperationDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn ChildOutput_number;
    private BindingSource operationLinksBindingSource1;
    private BindingSource oPERATIONBindingSource;
    private BindingSource oPERATIONBindingSource1;
    private DataGridView dataGrid_operation;
    private BindingSource oPERATIONBindingSource2;
    private BindingSource oPERATIONBindingSource3;
    private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn ID_Item;
    private DataGridViewTextBoxColumn iDTransitionDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn paramDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn operationTypeDataGridViewTextBoxColumn;
    private TabPage tabPage_transactionenvironment;
    private SplitContainer splitContainer1;
    private CAS.DataPorter.Operations.HMI.TransactionEnvironmentTree transactionEnvironmentTree1;
    private IContainer components;

    /// <summary>
    /// Initializes a new instance of the <see cref="Form1"/> class, this is the main configurator form
    /// </summary>
    public Form1()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //

      //datagrid comboboxes
      this.SUBSCRIPTION_ID_ServerColumn.Format = "";
      this.SUBSCRIPTION_ID_ServerColumn.FormatInfo = null;
      this.SUBSCRIPTION_ID_ServerColumn.HeaderText = "ID_server";
      this.SUBSCRIPTION_ID_ServerColumn.MappingName = "ID_server";
      this.SUBSCRIPTION_ID_ServerColumn.Width = 75;
      this.SUBSCRIPTION_ID_ServerColumn.ComboBox.DataSource = this.opcCliConfiguration.Servers;
      this.SUBSCRIPTION_ID_ServerColumn.ComboBox.DisplayMember = "Name";
      this.SUBSCRIPTION_ID_ServerColumn.ComboBox.ValueMember = "ID";

      this.ITEM_ID_SubscriptionColumn.Format = "";
      this.ITEM_ID_SubscriptionColumn.FormatInfo = null;
      this.ITEM_ID_SubscriptionColumn.HeaderText = "ID_Subscription";
      this.ITEM_ID_SubscriptionColumn.MappingName = "ID_Subscription";
      this.ITEM_ID_SubscriptionColumn.Width = 75;
      this.ITEM_ID_SubscriptionColumn.ComboBox.DataSource = this.opcCliConfiguration.Subscriptions;
      this.ITEM_ID_SubscriptionColumn.ComboBox.DisplayMember = "Name";
      this.ITEM_ID_SubscriptionColumn.ComboBox.ValueMember = "ID";

      this.ITEM_ID_ServerColumn.Format = "";
      this.ITEM_ID_ServerColumn.FormatInfo = null;
      this.ITEM_ID_ServerColumn.HeaderText = "ID_server";
      this.ITEM_ID_ServerColumn.MappingName = "ID_server";
      this.ITEM_ID_ServerColumn.Width = 75;
      this.ITEM_ID_ServerColumn.ComboBox.DataSource = this.opcCliConfiguration.Servers;
      this.ITEM_ID_ServerColumn.ComboBox.DisplayMember = "Name";
      this.ITEM_ID_ServerColumn.ComboBox.ValueMember = "ID";

      this.ITEM_ID_TransactionColumn.Format = "";
      this.ITEM_ID_TransactionColumn.FormatInfo = null;
      this.ITEM_ID_TransactionColumn.HeaderText = "ID_Transaction";
      this.ITEM_ID_TransactionColumn.MappingName = "ID_Transaction";
      this.ITEM_ID_TransactionColumn.Width = 75;
      this.ITEM_ID_TransactionColumn.ComboBox.DataSource = this.opcCliConfiguration.Transactions;
      this.ITEM_ID_TransactionColumn.ComboBox.DisplayMember = "ID";
      this.ITEM_ID_TransactionColumn.ComboBox.ValueMember = "ID";

      this.TRANSITION_ID_SubscriptionColumn.Format = "";
      this.TRANSITION_ID_SubscriptionColumn.FormatInfo = null;
      this.TRANSITION_ID_SubscriptionColumn.HeaderText = "ID_Subscription";
      this.TRANSITION_ID_SubscriptionColumn.MappingName = "ID_Subscription";
      this.TRANSITION_ID_SubscriptionColumn.Width = 75;
      this.TRANSITION_ID_SubscriptionColumn.ComboBox.DataSource = this.opcCliConfiguration.Subscriptions;
      this.TRANSITION_ID_SubscriptionColumn.ComboBox.DisplayMember = "Name";
      this.TRANSITION_ID_SubscriptionColumn.ComboBox.ValueMember = "ID";


      transactionEnvironmentTree1.InitialiseTreeFromConfiguration(opcCliConfiguration);
      transactionEnvironmentTree1.PanelChanged += new EventHandler(transactionEnvironmentTree1_PanelChanged);
    }

    void transactionEnvironmentTree1_PanelChanged(object sender, EventArgs e)
    {
      this.splitContainer1.Panel2.Controls.Clear();
      this.splitContainer1.Panel2.Controls.Add(transactionEnvironmentTree1.CurrentPanel);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose(disposing);
    }

    // Derive class from DataGridTextBoxColumn
    private class DataGridComboBoxColumn : DataGridTextBoxColumn
    {
      // Hosted combobox control
      private ComboBox comboBox;
      private CurrencyManager cm;
      private int iCurrentRow;

      // Constructor - create combobox, 
      // register selection change event handler,
      // register lose focus event handler
      internal DataGridComboBoxColumn()
      {
        this.cm = null;

        // Create combobox and force DropDownList style
        this.comboBox = new ComboBox();
        this.comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

        // Add event handler for notification when combobox loses focus
        this.comboBox.Leave += new EventHandler(comboBox_Leave);
      }

      // Property to provide access to combobox 
      internal ComboBox ComboBox
      {
        get { return comboBox; }
      }

      // On edit, add scroll event handler, and display combobox
      protected override void Edit(System.Windows.Forms.CurrencyManager
        source, int rowNum, System.Drawing.Rectangle bounds, bool readOnly,
        string instantText, bool cellIsVisible)
      {
        base.Edit(source, rowNum, bounds, readOnly, instantText,
          cellIsVisible);

        if (!readOnly && cellIsVisible)
        {
          // Save current row in the DataGrid and currency manager 
          // associated with the data source for the DataGrid
          this.iCurrentRow = rowNum;
          this.cm = source;

          // Add event handler for DataGrid scroll notification
          this.DataGridTableStyle.DataGrid.Scroll
            += new EventHandler(DataGrid_Scroll);

          // Site the combobox control within the current cell
          this.comboBox.Parent = this.TextBox.Parent;
          Rectangle rect =
            this.DataGridTableStyle.DataGrid.GetCurrentCellBounds();
          this.comboBox.Location = rect.Location;
          this.comboBox.Size =
            new Size(this.TextBox.Size.Width,
            this.comboBox.Size.Height);

          // Set combobox selection to given text
          this.comboBox.SelectedIndex =
            this.comboBox.FindStringExact(this.TextBox.Text);

          // Make the combobox visible and place on top textbox control
          this.comboBox.Show();
          this.comboBox.BringToFront();
          this.comboBox.Focus();
        }

      }

      // Given a row, get the value member associated with a row.  Use the
      // value member to find the associated display member by iterating 
      // over bound data source
      protected override object
        GetColumnValueAtRow(System.Windows.Forms.CurrencyManager source,
        int rowNum)
      {
        // Given a row number in the DataGrid, get the display member
        object obj = base.GetColumnValueAtRow(source, rowNum);

        // Iterate through the data source bound to the ColumnComboBox
        CurrencyManager cm = (CurrencyManager)
          (this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);
        // Assumes the associated DataGrid is bound to a DataView or 
        // DataTable 
        DataView dataview = ((DataView)cm.List);

        int i;

        for (i = 0; i < dataview.Count; i++)
        {
          if (obj.Equals(dataview[i][this.comboBox.ValueMember]))
            break;
        }

        if (i < dataview.Count)
          return dataview[i][this.comboBox.DisplayMember];

        return DBNull.Value;
      }

      // Given a row and a display member, iterate over bound data source to 
      // find the associated value member.  Set this value member.
      protected override void
        SetColumnValueAtRow(System.Windows.Forms.CurrencyManager source,
        int rowNum, object value)
      {
        object s = value;

        // Iterate through the data source bound to the ColumnComboBox
        CurrencyManager cm = (CurrencyManager)
          (this.DataGridTableStyle.DataGrid.BindingContext[this.comboBox.DataSource]);
        // Assumes the associated DataGrid is bound to a DataView or 
        // DataTable 
        DataView dataview = ((DataView)cm.List);
        int i;

        for (i = 0; i < dataview.Count; i++)
        {
          if (s.Equals(dataview[i][this.comboBox.DisplayMember]))
            break;
        }

        // If set item was found return corresponding value, 
        // otherwise return DbNull.Value
        if (i < dataview.Count)
          s = dataview[i][this.comboBox.ValueMember];
        else
          s = DBNull.Value;

        int oldpos = source.Position;
        if (source.Position != rowNum)
        {
          source.Position = rowNum;
        }
        base.SetColumnValueAtRow(source, rowNum, s);
        if (source.Position != oldpos)
        {
          source.Position = oldpos;
        }
      }

      // On DataGrid scroll, hide the combobox
      private void DataGrid_Scroll(object sender, EventArgs e)
      {
        this.comboBox.Hide();
      }

      // On combobox losing focus, set the column value, hide the combobox,
      // and unregister scroll event handler
      private void comboBox_Leave(object sender, EventArgs e)
      {
        DataRowView rowView = (DataRowView)this.comboBox.SelectedItem;
        //try
        if (this.comboBox.SelectedValue != null)
        {
          object s = rowView.Row[this.comboBox.DisplayMember];

          int oldpos = this.cm.Position;
          if (this.cm.Position != this.iCurrentRow)
          {
            this.cm.Position = this.iCurrentRow;
          }
          SetColumnValueAtRow(this.cm, this.iCurrentRow, s);
          if (this.cm.Position != oldpos)
          {
            this.cm.Position = oldpos;
          }
          Invalidate();
        }
        //catch (Exception er)
        /*else
        {
          //MessageBox.Show(er.ToString());
          MessageBox.Show("blah");
        }*/
        this.comboBox.Hide();
        this.DataGridTableStyle.DataGrid.Scroll -=
          new EventHandler(DataGrid_Scroll);
      }
    }


    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabServers = new System.Windows.Forms.TabPage();
      this.dataGridServers = new System.Windows.Forms.DataGrid();
      this.opcCliConfiguration = new CAS.DataPorter.Configurator.OPCCliConfiguration();
      this.tabSubItem = new System.Windows.Forms.TabPage();
      this.panel1 = new System.Windows.Forms.Panel();
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.dataGridSubscription = new System.Windows.Forms.DataGrid();
      this.SUBSCRIPTION_TableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.SUBSCRIPTION_IDColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_ID_ServerColumn = new CAS.DataPorter.Configurator.Form1.DataGridComboBoxColumn();
      this.SUBSCRIPTION_NameColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_UpdateRateColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_TransactionRateColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_LocaleColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_KeepaliveRateColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.SUBSCRIPTION_Deadband = new System.Windows.Forms.DataGridTextBoxColumn();
      this.dataGridItem = new System.Windows.Forms.DataGrid();
      this.ITEM_TableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.ITEM_IDColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.ITEM_ID_SubscriptionColumn = new CAS.DataPorter.Configurator.Form1.DataGridComboBoxColumn();
      this.ITEM_ID_ServerColumn = new CAS.DataPorter.Configurator.Form1.DataGridComboBoxColumn();
      this.ITEM_NameColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.ITEM_TypeColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.ITEM_ConversionColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.ITEM_AsyncColumn = new System.Windows.Forms.DataGridBoolColumn();
      this.ITEM_ID_TransactionColumn = new CAS.DataPorter.Configurator.Form1.DataGridComboBoxColumn();
      this.ITEM_MaxAgeColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.tabTransition = new System.Windows.Forms.TabPage();
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.button_edit_oper_param = new System.Windows.Forms.Button();
      this.dataGridTransition = new System.Windows.Forms.DataGrid();
      this.TRANSITION_TableStyle = new System.Windows.Forms.DataGridTableStyle();
      this.TRANSITION_ID_Column = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_ID_SubscriptionColumn = new CAS.DataPorter.Configurator.Form1.DataGridComboBoxColumn();
      this.TRANSITION_ID_ItemINColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_ID_SubINColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_ID_ItemOUTColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_ID_NextColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_TransitionTypeColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_Param1Column = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_DeadbandColumn = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_MinUpdateRateColum = new System.Windows.Forms.DataGridTextBoxColumn();
      this.TRANSITION_IsLeafColumn = new System.Windows.Forms.DataGridBoolColumn();
      this.button_edit_trans_param = new System.Windows.Forms.Button();
      this.dataGrid_operation = new System.Windows.Forms.DataGridView();
      this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ID_Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iDTransitionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.paramDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.operationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.oPERATIONBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
      this.tabPage_TRansactionTree = new System.Windows.Forms.TabPage();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.iDOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.inputnumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iDChildOperationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ChildOutput_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.operationLinksBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.tabPage_transactionenvironment = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.transactionEnvironmentTree1 = new CAS.DataPorter.Operations.HMI.TransactionEnvironmentTree();
      this.oPERATIONBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
      this.iDTransactionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.iDOperationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.operationLinksBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.ReadXMLButton = new System.Windows.Forms.Button();
      this.SaveXMLButton = new System.Windows.Forms.Button();
      this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
      this.importButton = new System.Windows.Forms.Button();
      this.comboBoxserverID = new System.Windows.Forms.ComboBox();
      this.label1 = new System.Windows.Forms.Label();
      this.clearButton = new System.Windows.Forms.Button();
      this.importGLSButton = new System.Windows.Forms.Button();
      this.textBoxsmplrate = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.mainMenu_dialog = new System.Windows.Forms.MainMenu(this.components);
      this.menuItem_mainmenu = new System.Windows.Forms.MenuItem();
      this.menuItem_clear = new System.Windows.Forms.MenuItem();
      this.menuItem_open = new System.Windows.Forms.MenuItem();
      this.menuItem_save = new System.Windows.Forms.MenuItem();
      this.menuItem_import = new System.Windows.Forms.MenuItem();
      this.menuItem5 = new System.Windows.Forms.MenuItem();
      this.menuItem6 = new System.Windows.Forms.MenuItem();
      this.menuItem_imp_item_dsc = new System.Windows.Forms.MenuItem();
      this.menuItem_imp_item_sett = new System.Windows.Forms.MenuItem();
      this.menuItem2 = new System.Windows.Forms.MenuItem();
      this.menuItem3 = new System.Windows.Forms.MenuItem();
      this.menuItem_itemdsc = new System.Windows.Forms.MenuItem();
      this.menuItem1 = new System.Windows.Forms.MenuItem();
      this.menuItem_close = new System.Windows.Forms.MenuItem();
      this.menuItem_help = new System.Windows.Forms.MenuItem();
      this.menuItem_helpwindow = new System.Windows.Forms.MenuItem();
      this.menuItem_about = new System.Windows.Forms.MenuItem();
      this.button_import_itemdsc = new System.Windows.Forms.Button();
      this.button_exit = new System.Windows.Forms.Button();
      this.button_import_item_settings = new System.Windows.Forms.Button();
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel_numberoftags = new System.Windows.Forms.ToolStripStatusLabel();
      this.button_import_tag_list = new System.Windows.Forms.Button();
      this.oPERATIONBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.oPERATIONBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
      this.tabControl.SuspendLayout();
      this.tabServers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridServers)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.opcCliConfiguration)).BeginInit();
      this.tabSubItem.SuspendLayout();
      this.panel1.SuspendLayout();
      this.tableLayoutPanel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridSubscription)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridItem)).BeginInit();
      this.tabTransition.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridTransition)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid_operation)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource3)).BeginInit();
      this.tabPage_TRansactionTree.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.operationLinksBindingSource1)).BeginInit();
      this.tabPage_transactionenvironment.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.operationLinksBindingSource)).BeginInit();
      this.statusStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource1)).BeginInit();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl.Controls.Add(this.tabServers);
      this.tabControl.Controls.Add(this.tabSubItem);
      this.tabControl.Controls.Add(this.tabTransition);
      this.tabControl.Controls.Add(this.tabPage_TRansactionTree);
      this.tabControl.Controls.Add(this.tabPage_transactionenvironment);
      this.tabControl.Location = new System.Drawing.Point(8, 8);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      this.tabControl.Size = new System.Drawing.Size(712, 517);
      this.tabControl.TabIndex = 0;
      this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
      // 
      // tabServers
      // 
      this.tabServers.Controls.Add(this.dataGridServers);
      this.tabServers.Location = new System.Drawing.Point(4, 22);
      this.tabServers.Name = "tabServers";
      this.tabServers.Size = new System.Drawing.Size(704, 491);
      this.tabServers.TabIndex = 0;
      this.tabServers.Text = "Servers";
      // 
      // dataGridServers
      // 
      this.dataGridServers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridServers.CaptionText = "Servers";
      this.dataGridServers.DataMember = "";
      this.dataGridServers.DataSource = this.opcCliConfiguration.Servers;
      this.dataGridServers.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridServers.Location = new System.Drawing.Point(0, 8);
      this.dataGridServers.Name = "dataGridServers";
      this.dataGridServers.Size = new System.Drawing.Size(704, 467);
      this.dataGridServers.TabIndex = 0;
      this.dataGridServers.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGridServers_Navigate);
      // 
      // opcCliConfiguration
      // 
      this.opcCliConfiguration.DataSetName = "OPCCliConfiguration";
      this.opcCliConfiguration.Locale = new System.Globalization.CultureInfo("en-US");
      this.opcCliConfiguration.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // tabSubItem
      // 
      this.tabSubItem.Controls.Add(this.panel1);
      this.tabSubItem.Location = new System.Drawing.Point(4, 22);
      this.tabSubItem.Name = "tabSubItem";
      this.tabSubItem.Size = new System.Drawing.Size(704, 491);
      this.tabSubItem.TabIndex = 1;
      this.tabSubItem.Text = "Subscriptions & Items";
      this.tabSubItem.Click += new System.EventHandler(this.tabSubItem_Click);
      // 
      // panel1
      // 
      this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.panel1.Controls.Add(this.tableLayoutPanel1);
      this.panel1.Location = new System.Drawing.Point(3, 8);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(698, 471);
      this.panel1.TabIndex = 2;
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
      this.tableLayoutPanel1.Controls.Add(this.dataGridSubscription, 0, 0);
      this.tableLayoutPanel1.Controls.Add(this.dataGridItem, 0, 1);
      this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 2;
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53F));
      this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47F));
      this.tableLayoutPanel1.Size = new System.Drawing.Size(692, 465);
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // dataGridSubscription
      // 
      this.dataGridSubscription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridSubscription.CaptionText = "Subscription";
      this.dataGridSubscription.DataMember = "";
      this.dataGridSubscription.DataSource = this.opcCliConfiguration.Subscriptions;
      this.dataGridSubscription.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridSubscription.Location = new System.Drawing.Point(3, 3);
      this.dataGridSubscription.Name = "dataGridSubscription";
      this.dataGridSubscription.Size = new System.Drawing.Size(686, 240);
      this.dataGridSubscription.TabIndex = 0;
      this.dataGridSubscription.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.SUBSCRIPTION_TableStyle});
      this.dataGridSubscription.Navigate += new System.Windows.Forms.NavigateEventHandler(this.dataGridSubscription_Navigate);
      // 
      // SUBSCRIPTION_TableStyle
      // 
      this.SUBSCRIPTION_TableStyle.DataGrid = this.dataGridSubscription;
      this.SUBSCRIPTION_TableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.SUBSCRIPTION_IDColumn,
            this.SUBSCRIPTION_ID_ServerColumn,
            this.SUBSCRIPTION_NameColumn,
            this.SUBSCRIPTION_UpdateRateColumn,
            this.SUBSCRIPTION_TransactionRateColumn,
            this.SUBSCRIPTION_LocaleColumn,
            this.SUBSCRIPTION_KeepaliveRateColumn,
            this.SUBSCRIPTION_Deadband});
      this.SUBSCRIPTION_TableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.SUBSCRIPTION_TableStyle.MappingName = "Subscription";
      // 
      // SUBSCRIPTION_IDColumn
      // 
      this.SUBSCRIPTION_IDColumn.Format = "";
      this.SUBSCRIPTION_IDColumn.FormatInfo = null;
      this.SUBSCRIPTION_IDColumn.HeaderText = "ID";
      this.SUBSCRIPTION_IDColumn.MappingName = "ID";
      this.SUBSCRIPTION_IDColumn.Width = 75;
      // 
      // SUBSCRIPTION_ID_ServerColumn
      // 
      this.SUBSCRIPTION_ID_ServerColumn.Format = "";
      this.SUBSCRIPTION_ID_ServerColumn.FormatInfo = null;
      this.SUBSCRIPTION_ID_ServerColumn.Width = 75;
      // 
      // SUBSCRIPTION_NameColumn
      // 
      this.SUBSCRIPTION_NameColumn.Format = "";
      this.SUBSCRIPTION_NameColumn.FormatInfo = null;
      this.SUBSCRIPTION_NameColumn.HeaderText = "Name";
      this.SUBSCRIPTION_NameColumn.MappingName = "Name";
      this.SUBSCRIPTION_NameColumn.Width = 75;
      // 
      // SUBSCRIPTION_UpdateRateColumn
      // 
      this.SUBSCRIPTION_UpdateRateColumn.Format = "";
      this.SUBSCRIPTION_UpdateRateColumn.FormatInfo = null;
      this.SUBSCRIPTION_UpdateRateColumn.HeaderText = "UpdateRate";
      this.SUBSCRIPTION_UpdateRateColumn.MappingName = "UpdateRate";
      this.SUBSCRIPTION_UpdateRateColumn.Width = 75;
      // 
      // SUBSCRIPTION_TransactionRateColumn
      // 
      this.SUBSCRIPTION_TransactionRateColumn.Format = "";
      this.SUBSCRIPTION_TransactionRateColumn.FormatInfo = null;
      this.SUBSCRIPTION_TransactionRateColumn.HeaderText = "TransactionRate";
      this.SUBSCRIPTION_TransactionRateColumn.MappingName = "TransactionRate";
      this.SUBSCRIPTION_TransactionRateColumn.Width = 75;
      // 
      // SUBSCRIPTION_LocaleColumn
      // 
      this.SUBSCRIPTION_LocaleColumn.Format = "";
      this.SUBSCRIPTION_LocaleColumn.FormatInfo = null;
      this.SUBSCRIPTION_LocaleColumn.HeaderText = "Locale";
      this.SUBSCRIPTION_LocaleColumn.MappingName = "Locale";
      this.SUBSCRIPTION_LocaleColumn.Width = 75;
      // 
      // SUBSCRIPTION_KeepaliveRateColumn
      // 
      this.SUBSCRIPTION_KeepaliveRateColumn.Format = "";
      this.SUBSCRIPTION_KeepaliveRateColumn.FormatInfo = null;
      this.SUBSCRIPTION_KeepaliveRateColumn.HeaderText = "KeepAliveRate";
      this.SUBSCRIPTION_KeepaliveRateColumn.MappingName = "KeepAliveRate";
      this.SUBSCRIPTION_KeepaliveRateColumn.Width = 75;
      // 
      // SUBSCRIPTION_Deadband
      // 
      this.SUBSCRIPTION_Deadband.Format = "";
      this.SUBSCRIPTION_Deadband.FormatInfo = null;
      this.SUBSCRIPTION_Deadband.HeaderText = "Deadband";
      this.SUBSCRIPTION_Deadband.MappingName = "Deadband";
      this.SUBSCRIPTION_Deadband.Width = 75;
      // 
      // dataGridItem
      // 
      this.dataGridItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridItem.CaptionText = "Item";
      this.dataGridItem.DataMember = "";
      this.dataGridItem.DataSource = this.opcCliConfiguration.Items;
      this.dataGridItem.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridItem.Location = new System.Drawing.Point(3, 249);
      this.dataGridItem.Name = "dataGridItem";
      this.dataGridItem.Size = new System.Drawing.Size(686, 213);
      this.dataGridItem.TabIndex = 1;
      this.dataGridItem.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.ITEM_TableStyle});
      // 
      // ITEM_TableStyle
      // 
      this.ITEM_TableStyle.DataGrid = this.dataGridItem;
      this.ITEM_TableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.ITEM_IDColumn,
            this.ITEM_ID_SubscriptionColumn,
            this.ITEM_ID_ServerColumn,
            this.ITEM_NameColumn,
            this.ITEM_TypeColumn,
            this.ITEM_ConversionColumn,
            this.ITEM_AsyncColumn,
            this.ITEM_ID_TransactionColumn,
            this.ITEM_MaxAgeColumn});
      this.ITEM_TableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.ITEM_TableStyle.MappingName = "Item";
      // 
      // ITEM_IDColumn
      // 
      this.ITEM_IDColumn.Format = "";
      this.ITEM_IDColumn.FormatInfo = null;
      this.ITEM_IDColumn.HeaderText = "ID";
      this.ITEM_IDColumn.MappingName = "ID";
      this.ITEM_IDColumn.Width = 75;
      // 
      // ITEM_ID_SubscriptionColumn
      // 
      this.ITEM_ID_SubscriptionColumn.Format = "";
      this.ITEM_ID_SubscriptionColumn.FormatInfo = null;
      this.ITEM_ID_SubscriptionColumn.Width = 75;
      // 
      // ITEM_ID_ServerColumn
      // 
      this.ITEM_ID_ServerColumn.Format = "";
      this.ITEM_ID_ServerColumn.FormatInfo = null;
      this.ITEM_ID_ServerColumn.Width = 75;
      // 
      // ITEM_NameColumn
      // 
      this.ITEM_NameColumn.Format = "";
      this.ITEM_NameColumn.FormatInfo = null;
      this.ITEM_NameColumn.HeaderText = "Name";
      this.ITEM_NameColumn.MappingName = "Name";
      this.ITEM_NameColumn.Width = 75;
      // 
      // ITEM_TypeColumn
      // 
      this.ITEM_TypeColumn.Format = "";
      this.ITEM_TypeColumn.FormatInfo = null;
      this.ITEM_TypeColumn.HeaderText = "Type";
      this.ITEM_TypeColumn.MappingName = "Type";
      this.ITEM_TypeColumn.Width = 75;
      // 
      // ITEM_ConversionColumn
      // 
      this.ITEM_ConversionColumn.Format = "";
      this.ITEM_ConversionColumn.FormatInfo = null;
      this.ITEM_ConversionColumn.HeaderText = "Conversion";
      this.ITEM_ConversionColumn.MappingName = "Conversion";
      this.ITEM_ConversionColumn.Width = 75;
      // 
      // ITEM_AsyncColumn
      // 
      this.ITEM_AsyncColumn.HeaderText = "Async";
      this.ITEM_AsyncColumn.MappingName = "Async";
      this.ITEM_AsyncColumn.Width = 75;
      // 
      // ITEM_ID_TransactionColumn
      // 
      this.ITEM_ID_TransactionColumn.Format = "";
      this.ITEM_ID_TransactionColumn.FormatInfo = null;
      this.ITEM_ID_TransactionColumn.Width = 75;
      // 
      // ITEM_MaxAgeColumn
      // 
      this.ITEM_MaxAgeColumn.Format = "";
      this.ITEM_MaxAgeColumn.FormatInfo = null;
      this.ITEM_MaxAgeColumn.HeaderText = "MaxAge";
      this.ITEM_MaxAgeColumn.MappingName = "MaxAge";
      this.ITEM_MaxAgeColumn.Width = 75;
      // 
      // tabTransition
      // 
      this.tabTransition.Controls.Add(this.tableLayoutPanel2);
      this.tabTransition.Location = new System.Drawing.Point(4, 22);
      this.tabTransition.Name = "tabTransition";
      this.tabTransition.Size = new System.Drawing.Size(704, 491);
      this.tabTransition.TabIndex = 2;
      this.tabTransition.Text = "Transaction";
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLayoutPanel2.ColumnCount = 2;
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 78F));
      this.tableLayoutPanel2.Controls.Add(this.button_edit_oper_param, 1, 1);
      this.tableLayoutPanel2.Controls.Add(this.dataGridTransition, 0, 0);
      this.tableLayoutPanel2.Controls.Add(this.button_edit_trans_param, 1, 0);
      this.tableLayoutPanel2.Controls.Add(this.dataGrid_operation, 0, 1);
      this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 11);
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 2;
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.51754F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.48246F));
      this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
      this.tableLayoutPanel2.Size = new System.Drawing.Size(698, 477);
      this.tableLayoutPanel2.TabIndex = 3;
      // 
      // button_edit_oper_param
      // 
      this.button_edit_oper_param.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button_edit_oper_param.Location = new System.Drawing.Point(623, 418);
      this.button_edit_oper_param.Name = "button_edit_oper_param";
      this.button_edit_oper_param.Size = new System.Drawing.Size(72, 56);
      this.button_edit_oper_param.TabIndex = 2;
      this.button_edit_oper_param.Text = "Edit operation Parameter";
      this.button_edit_oper_param.Click += new System.EventHandler(this.button_edit_oper_param_Click);
      // 
      // dataGridTransition
      // 
      this.dataGridTransition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dataGridTransition.CaptionText = "Transaction";
      this.dataGridTransition.DataMember = "";
      this.dataGridTransition.DataSource = this.opcCliConfiguration.Transactions;
      this.dataGridTransition.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.dataGridTransition.Location = new System.Drawing.Point(3, 3);
      this.dataGridTransition.Name = "dataGridTransition";
      this.dataGridTransition.Size = new System.Drawing.Size(614, 206);
      this.dataGridTransition.TabIndex = 0;
      this.dataGridTransition.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
            this.TRANSITION_TableStyle});
      // 
      // TRANSITION_TableStyle
      // 
      this.TRANSITION_TableStyle.DataGrid = this.dataGridTransition;
      this.TRANSITION_TableStyle.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {
            this.TRANSITION_ID_Column,
            this.TRANSITION_ID_SubscriptionColumn,
            this.TRANSITION_ID_ItemINColumn,
            this.TRANSITION_ID_SubINColumn,
            this.TRANSITION_ID_ItemOUTColumn,
            this.TRANSITION_ID_NextColumn,
            this.TRANSITION_TransitionTypeColumn,
            this.TRANSITION_Param1Column,
            this.TRANSITION_DeadbandColumn,
            this.TRANSITION_MinUpdateRateColum,
            this.TRANSITION_IsLeafColumn});
      this.TRANSITION_TableStyle.HeaderForeColor = System.Drawing.SystemColors.ControlText;
      this.TRANSITION_TableStyle.MappingName = "transition";
      // 
      // TRANSITION_ID_Column
      // 
      this.TRANSITION_ID_Column.Format = "";
      this.TRANSITION_ID_Column.FormatInfo = null;
      this.TRANSITION_ID_Column.HeaderText = "ID";
      this.TRANSITION_ID_Column.MappingName = "ID";
      this.TRANSITION_ID_Column.Width = 75;
      // 
      // TRANSITION_ID_SubscriptionColumn
      // 
      this.TRANSITION_ID_SubscriptionColumn.Format = "";
      this.TRANSITION_ID_SubscriptionColumn.FormatInfo = null;
      this.TRANSITION_ID_SubscriptionColumn.Width = 75;
      // 
      // TRANSITION_ID_ItemINColumn
      // 
      this.TRANSITION_ID_ItemINColumn.Format = "";
      this.TRANSITION_ID_ItemINColumn.FormatInfo = null;
      this.TRANSITION_ID_ItemINColumn.HeaderText = "ID_itemIN";
      this.TRANSITION_ID_ItemINColumn.MappingName = "ID_itemIN";
      this.TRANSITION_ID_ItemINColumn.Width = 75;
      // 
      // TRANSITION_ID_SubINColumn
      // 
      this.TRANSITION_ID_SubINColumn.Format = "";
      this.TRANSITION_ID_SubINColumn.FormatInfo = null;
      this.TRANSITION_ID_SubINColumn.HeaderText = "ID_SubIn";
      this.TRANSITION_ID_SubINColumn.MappingName = "ID_SubIn";
      this.TRANSITION_ID_SubINColumn.Width = 75;
      // 
      // TRANSITION_ID_ItemOUTColumn
      // 
      this.TRANSITION_ID_ItemOUTColumn.Format = "";
      this.TRANSITION_ID_ItemOUTColumn.FormatInfo = null;
      this.TRANSITION_ID_ItemOUTColumn.HeaderText = "ID_itemOUT";
      this.TRANSITION_ID_ItemOUTColumn.MappingName = "ID_itemOUT";
      this.TRANSITION_ID_ItemOUTColumn.Width = 75;
      // 
      // TRANSITION_ID_NextColumn
      // 
      this.TRANSITION_ID_NextColumn.Format = "";
      this.TRANSITION_ID_NextColumn.FormatInfo = null;
      this.TRANSITION_ID_NextColumn.HeaderText = "ID_next";
      this.TRANSITION_ID_NextColumn.MappingName = "ID_next";
      this.TRANSITION_ID_NextColumn.Width = 75;
      // 
      // TRANSITION_TransitionTypeColumn
      // 
      this.TRANSITION_TransitionTypeColumn.Format = "";
      this.TRANSITION_TransitionTypeColumn.FormatInfo = null;
      this.TRANSITION_TransitionTypeColumn.HeaderText = "TransitionType";
      this.TRANSITION_TransitionTypeColumn.MappingName = "TransitionType";
      this.TRANSITION_TransitionTypeColumn.Width = 75;
      // 
      // TRANSITION_Param1Column
      // 
      this.TRANSITION_Param1Column.Format = "";
      this.TRANSITION_Param1Column.FormatInfo = null;
      this.TRANSITION_Param1Column.HeaderText = "Param1";
      this.TRANSITION_Param1Column.MappingName = "Param1";
      this.TRANSITION_Param1Column.Width = 75;
      // 
      // TRANSITION_DeadbandColumn
      // 
      this.TRANSITION_DeadbandColumn.Format = "";
      this.TRANSITION_DeadbandColumn.FormatInfo = null;
      this.TRANSITION_DeadbandColumn.HeaderText = "Deadband";
      this.TRANSITION_DeadbandColumn.MappingName = "Deadband";
      this.TRANSITION_DeadbandColumn.Width = 75;
      // 
      // TRANSITION_MinUpdateRateColum
      // 
      this.TRANSITION_MinUpdateRateColum.Format = "";
      this.TRANSITION_MinUpdateRateColum.FormatInfo = null;
      this.TRANSITION_MinUpdateRateColum.HeaderText = "MinUpdateRate";
      this.TRANSITION_MinUpdateRateColum.MappingName = "MinUpdateRate";
      this.TRANSITION_MinUpdateRateColum.Width = 75;
      // 
      // TRANSITION_IsLeafColumn
      // 
      this.TRANSITION_IsLeafColumn.HeaderText = "IsLeaf";
      this.TRANSITION_IsLeafColumn.MappingName = "IsLeaf";
      this.TRANSITION_IsLeafColumn.Width = 75;
      // 
      // button_edit_trans_param
      // 
      this.button_edit_trans_param.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.button_edit_trans_param.Location = new System.Drawing.Point(623, 151);
      this.button_edit_trans_param.Name = "button_edit_trans_param";
      this.button_edit_trans_param.Size = new System.Drawing.Size(72, 58);
      this.button_edit_trans_param.TabIndex = 2;
      this.button_edit_trans_param.Text = "Edit transaction";
      this.button_edit_trans_param.Click += new System.EventHandler(this.button_edit_trans_param_Click);
      // 
      // dataGrid_operation
      // 
      this.dataGrid_operation.AllowUserToOrderColumns = true;
      this.dataGrid_operation.AutoGenerateColumns = false;
      this.dataGrid_operation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGrid_operation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.ID_Item,
            this.iDTransitionDataGridViewTextBoxColumn,
            this.paramDataGridViewTextBoxColumn,
            this.operationTypeDataGridViewTextBoxColumn});
      this.dataGrid_operation.DataSource = this.oPERATIONBindingSource3;
      this.dataGrid_operation.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dataGrid_operation.Location = new System.Drawing.Point(3, 215);
      this.dataGrid_operation.Name = "dataGrid_operation";
      this.dataGrid_operation.Size = new System.Drawing.Size(614, 259);
      this.dataGrid_operation.TabIndex = 3;
      // 
      // iDDataGridViewTextBoxColumn
      // 
      this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
      this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
      this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
      // 
      // ID_Item
      // 
      this.ID_Item.DataPropertyName = "ID_Item";
      this.ID_Item.HeaderText = "ID_Item";
      this.ID_Item.Name = "ID_Item";
      // 
      // iDTransitionDataGridViewTextBoxColumn
      // 
      this.iDTransitionDataGridViewTextBoxColumn.DataPropertyName = "ID_Transaction";
      this.iDTransitionDataGridViewTextBoxColumn.HeaderText = "ID_Transaction";
      this.iDTransitionDataGridViewTextBoxColumn.Name = "iDTransitionDataGridViewTextBoxColumn";
      // 
      // paramDataGridViewTextBoxColumn
      // 
      this.paramDataGridViewTextBoxColumn.DataPropertyName = "Param";
      this.paramDataGridViewTextBoxColumn.HeaderText = "Param";
      this.paramDataGridViewTextBoxColumn.Name = "paramDataGridViewTextBoxColumn";
      // 
      // operationTypeDataGridViewTextBoxColumn
      // 
      this.operationTypeDataGridViewTextBoxColumn.DataPropertyName = "OperationType";
      this.operationTypeDataGridViewTextBoxColumn.HeaderText = "OperationType";
      this.operationTypeDataGridViewTextBoxColumn.Name = "operationTypeDataGridViewTextBoxColumn";
      // 
      // oPERATIONBindingSource3
      // 
      this.oPERATIONBindingSource3.DataMember = "Operations";
      this.oPERATIONBindingSource3.DataSource = this.opcCliConfiguration;
      // 
      // tabPage_TRansactionTree
      // 
      this.tabPage_TRansactionTree.Controls.Add(this.dataGridView1);
      this.tabPage_TRansactionTree.Location = new System.Drawing.Point(4, 22);
      this.tabPage_TRansactionTree.Name = "tabPage_TRansactionTree";
      this.tabPage_TRansactionTree.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage_TRansactionTree.Size = new System.Drawing.Size(704, 491);
      this.tabPage_TRansactionTree.TabIndex = 3;
      this.tabPage_TRansactionTree.Text = "Transaction tree";
      this.tabPage_TRansactionTree.UseVisualStyleBackColor = true;
      // 
      // dataGridView1
      // 
      this.dataGridView1.AutoGenerateColumns = false;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDOperationDataGridViewTextBoxColumn,
            this.inputnumberDataGridViewTextBoxColumn,
            this.iDChildOperationDataGridViewTextBoxColumn,
            this.ChildOutput_number});
      this.dataGridView1.DataSource = this.operationLinksBindingSource1;
      this.dataGridView1.Location = new System.Drawing.Point(35, 18);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.Size = new System.Drawing.Size(644, 194);
      this.dataGridView1.TabIndex = 0;
      // 
      // iDOperationDataGridViewTextBoxColumn
      // 
      this.iDOperationDataGridViewTextBoxColumn.DataPropertyName = "ID_Operation";
      this.iDOperationDataGridViewTextBoxColumn.HeaderText = "ID_Operation";
      this.iDOperationDataGridViewTextBoxColumn.Name = "iDOperationDataGridViewTextBoxColumn";
      // 
      // inputnumberDataGridViewTextBoxColumn
      // 
      this.inputnumberDataGridViewTextBoxColumn.DataPropertyName = "Input_number";
      this.inputnumberDataGridViewTextBoxColumn.HeaderText = "Input_number";
      this.inputnumberDataGridViewTextBoxColumn.Name = "inputnumberDataGridViewTextBoxColumn";
      // 
      // iDChildOperationDataGridViewTextBoxColumn
      // 
      this.iDChildOperationDataGridViewTextBoxColumn.DataPropertyName = "IDChild_Operation";
      this.iDChildOperationDataGridViewTextBoxColumn.HeaderText = "IDChild_Operation";
      this.iDChildOperationDataGridViewTextBoxColumn.Name = "iDChildOperationDataGridViewTextBoxColumn";
      this.iDChildOperationDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
      // 
      // ChildOutput_number
      // 
      this.ChildOutput_number.DataPropertyName = "ChildOutput_number";
      this.ChildOutput_number.HeaderText = "ChildOutput_number";
      this.ChildOutput_number.Name = "ChildOutput_number";
      // 
      // operationLinksBindingSource1
      // 
      this.operationLinksBindingSource1.DataMember = "OperationLinks";
      this.operationLinksBindingSource1.DataSource = this.opcCliConfiguration;
      // 
      // tabPage_transactionenvironment
      // 
      this.tabPage_transactionenvironment.Controls.Add(this.splitContainer1);
      this.tabPage_transactionenvironment.Location = new System.Drawing.Point(4, 22);
      this.tabPage_transactionenvironment.Name = "tabPage_transactionenvironment";
      this.tabPage_transactionenvironment.Padding = new System.Windows.Forms.Padding(3);
      this.tabPage_transactionenvironment.Size = new System.Drawing.Size(704, 491);
      this.tabPage_transactionenvironment.TabIndex = 4;
      this.tabPage_transactionenvironment.Text = "Transaction Environment";
      this.tabPage_transactionenvironment.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(3, 3);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.transactionEnvironmentTree1);
      this.splitContainer1.Size = new System.Drawing.Size(698, 485);
      this.splitContainer1.SplitterDistance = 232;
      this.splitContainer1.TabIndex = 0;
      // 
      // transactionEnvironmentTree1
      // 
      this.transactionEnvironmentTree1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.transactionEnvironmentTree1.Location = new System.Drawing.Point(0, 0);
      this.transactionEnvironmentTree1.Name = "transactionEnvironmentTree1";
      this.transactionEnvironmentTree1.Size = new System.Drawing.Size(232, 485);
      this.transactionEnvironmentTree1.TabIndex = 0;
      // 
      // oPERATIONBindingSource2
      // 
      this.oPERATIONBindingSource2.DataMember = "Operations";
      this.oPERATIONBindingSource2.DataSource = this.opcCliConfiguration;
      // 
      // iDTransactionDataGridViewTextBoxColumn
      // 
      this.iDTransactionDataGridViewTextBoxColumn.DataPropertyName = "ID_Transaction";
      this.iDTransactionDataGridViewTextBoxColumn.HeaderText = "ID_Transaction";
      this.iDTransactionDataGridViewTextBoxColumn.Name = "iDTransactionDataGridViewTextBoxColumn";
      // 
      // iDOperationDataGridViewTextBoxColumn1
      // 
      this.iDOperationDataGridViewTextBoxColumn1.DataPropertyName = "ID_Operation";
      this.iDOperationDataGridViewTextBoxColumn1.HeaderText = "ID_Operation";
      this.iDOperationDataGridViewTextBoxColumn1.Name = "iDOperationDataGridViewTextBoxColumn1";
      // 
      // operationLinksBindingSource
      // 
      this.operationLinksBindingSource.DataMember = "OperationLinks";
      this.operationLinksBindingSource.DataSource = this.opcCliConfiguration;
      // 
      // ReadXMLButton
      // 
      this.ReadXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.ReadXMLButton.Location = new System.Drawing.Point(728, 48);
      this.ReadXMLButton.Name = "ReadXMLButton";
      this.ReadXMLButton.Size = new System.Drawing.Size(88, 24);
      this.ReadXMLButton.TabIndex = 1;
      this.ReadXMLButton.Text = "Open XML";
      this.ReadXMLButton.Click += new System.EventHandler(this.ReadXMLButton_Click);
      // 
      // SaveXMLButton
      // 
      this.SaveXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.SaveXMLButton.Location = new System.Drawing.Point(728, 80);
      this.SaveXMLButton.Name = "SaveXMLButton";
      this.SaveXMLButton.Size = new System.Drawing.Size(88, 24);
      this.SaveXMLButton.TabIndex = 2;
      this.SaveXMLButton.Text = "Save XML";
      this.SaveXMLButton.Click += new System.EventHandler(this.SaveXMLButton_Click);
      // 
      // openFileDialog
      // 
      this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialogXML_FileOk);
      // 
      // importButton
      // 
      this.importButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.importButton.Location = new System.Drawing.Point(728, 176);
      this.importButton.Name = "importButton";
      this.importButton.Size = new System.Drawing.Size(88, 24);
      this.importButton.TabIndex = 3;
      this.importButton.Text = "Import Netconf";
      this.importButton.Click += new System.EventHandler(this.importButton_Click);
      // 
      // comboBoxserverID
      // 
      this.comboBoxserverID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.comboBoxserverID.DisplayMember = "Name";
      this.comboBoxserverID.Location = new System.Drawing.Point(728, 408);
      this.comboBoxserverID.Name = "comboBoxserverID";
      this.comboBoxserverID.Size = new System.Drawing.Size(88, 21);
      this.comboBoxserverID.TabIndex = 5;
      this.comboBoxserverID.ValueMember = "ID";
      // 
      // label1
      // 
      this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label1.Location = new System.Drawing.Point(728, 376);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(88, 21);
      this.label1.TabIndex = 6;
      this.label1.Text = "Server:";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // clearButton
      // 
      this.clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.clearButton.Location = new System.Drawing.Point(728, 112);
      this.clearButton.Name = "clearButton";
      this.clearButton.Size = new System.Drawing.Size(88, 24);
      this.clearButton.TabIndex = 7;
      this.clearButton.Text = "Clear All";
      this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
      // 
      // importGLSButton
      // 
      this.importGLSButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.importGLSButton.Location = new System.Drawing.Point(728, 144);
      this.importGLSButton.Name = "importGLSButton";
      this.importGLSButton.Size = new System.Drawing.Size(88, 24);
      this.importGLSButton.TabIndex = 9;
      this.importGLSButton.Text = "Import GLS";
      this.importGLSButton.Click += new System.EventHandler(this.importGLSButton_Click);
      // 
      // textBoxsmplrate
      // 
      this.textBoxsmplrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxsmplrate.Location = new System.Drawing.Point(728, 472);
      this.textBoxsmplrate.Name = "textBoxsmplrate";
      this.textBoxsmplrate.Size = new System.Drawing.Size(88, 20);
      this.textBoxsmplrate.TabIndex = 11;
      this.textBoxsmplrate.Text = "1000";
      this.textBoxsmplrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // label2
      // 
      this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.label2.Location = new System.Drawing.Point(728, 432);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(88, 32);
      this.label2.TabIndex = 12;
      this.label2.Text = "Default sample rate:";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // mainMenu_dialog
      // 
      this.mainMenu_dialog.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_mainmenu,
            this.menuItem_help});
      // 
      // menuItem_mainmenu
      // 
      this.menuItem_mainmenu.Index = 0;
      this.menuItem_mainmenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_clear,
            this.menuItem_open,
            this.menuItem_save,
            this.menuItem_import,
            this.menuItem3,
            this.menuItem_itemdsc,
            this.menuItem1,
            this.menuItem_close});
      this.menuItem_mainmenu.Text = "Menu";
      // 
      // menuItem_clear
      // 
      this.menuItem_clear.Index = 0;
      this.menuItem_clear.Text = "New / Clear";
      this.menuItem_clear.Click += new System.EventHandler(this.menuItem7_Click);
      // 
      // menuItem_open
      // 
      this.menuItem_open.Index = 1;
      this.menuItem_open.Text = "Open..";
      this.menuItem_open.Click += new System.EventHandler(this.menuItem_open_Click);
      // 
      // menuItem_save
      // 
      this.menuItem_save.Index = 2;
      this.menuItem_save.Text = "Save..";
      this.menuItem_save.Click += new System.EventHandler(this.menuItem_save_Click);
      // 
      // menuItem_import
      // 
      this.menuItem_import.Index = 3;
      this.menuItem_import.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem6,
            this.menuItem_imp_item_dsc,
            this.menuItem_imp_item_sett,
            this.menuItem2});
      this.menuItem_import.Text = "Import";
      // 
      // menuItem5
      // 
      this.menuItem5.Index = 0;
      this.menuItem5.Text = "GLS";
      this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
      // 
      // menuItem6
      // 
      this.menuItem6.Index = 1;
      this.menuItem6.Text = "NetConfig";
      this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
      // 
      // menuItem_imp_item_dsc
      // 
      this.menuItem_imp_item_dsc.Index = 2;
      this.menuItem_imp_item_dsc.Text = "Item DSC";
      this.menuItem_imp_item_dsc.Click += new System.EventHandler(this.menuItem_imp_item_dsc_Click);
      // 
      // menuItem_imp_item_sett
      // 
      this.menuItem_imp_item_sett.Index = 3;
      this.menuItem_imp_item_sett.Text = "Item Settings";
      this.menuItem_imp_item_sett.Click += new System.EventHandler(this.menuItem_imp_item_sett_Click);
      // 
      // menuItem2
      // 
      this.menuItem2.Index = 4;
      this.menuItem2.Text = "Item List";
      this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
      // 
      // menuItem3
      // 
      this.menuItem3.Index = 4;
      this.menuItem3.Text = "-";
      // 
      // menuItem_itemdsc
      // 
      this.menuItem_itemdsc.Index = 5;
      this.menuItem_itemdsc.Text = "ItemDescriber";
      this.menuItem_itemdsc.Click += new System.EventHandler(this.menuItem_itemdsc_Click);
      // 
      // menuItem1
      // 
      this.menuItem1.Index = 6;
      this.menuItem1.Text = "-";
      // 
      // menuItem_close
      // 
      this.menuItem_close.Index = 7;
      this.menuItem_close.Text = "Close";
      this.menuItem_close.Click += new System.EventHandler(this.menuItem_close_Click);
      // 
      // menuItem_help
      // 
      this.menuItem_help.Index = 1;
      this.menuItem_help.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem_helpwindow,
            this.menuItem_about});
      this.menuItem_help.Text = "Help";
      // 
      // menuItem_helpwindow
      // 
      this.menuItem_helpwindow.Index = 0;
      this.menuItem_helpwindow.Text = "Help";
      this.menuItem_helpwindow.Click += new System.EventHandler(this.menuItem_helpwindow_Click);
      // 
      // menuItem_about
      // 
      this.menuItem_about.Index = 1;
      this.menuItem_about.Text = "About..";
      this.menuItem_about.Click += new System.EventHandler(this.menuItem_about_Click);
      // 
      // button_import_itemdsc
      // 
      this.button_import_itemdsc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_import_itemdsc.Location = new System.Drawing.Point(728, 208);
      this.button_import_itemdsc.Name = "button_import_itemdsc";
      this.button_import_itemdsc.Size = new System.Drawing.Size(88, 34);
      this.button_import_itemdsc.TabIndex = 3;
      this.button_import_itemdsc.Text = "Import ItemDSC";
      this.button_import_itemdsc.Click += new System.EventHandler(this.button_import_itemdsc_Click);
      // 
      // button_exit
      // 
      this.button_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_exit.Location = new System.Drawing.Point(728, 16);
      this.button_exit.Name = "button_exit";
      this.button_exit.Size = new System.Drawing.Size(88, 24);
      this.button_exit.TabIndex = 1;
      this.button_exit.Text = "Exit";
      this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
      // 
      // button_import_item_settings
      // 
      this.button_import_item_settings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_import_item_settings.Location = new System.Drawing.Point(728, 248);
      this.button_import_item_settings.Name = "button_import_item_settings";
      this.button_import_item_settings.Size = new System.Drawing.Size(88, 46);
      this.button_import_item_settings.TabIndex = 3;
      this.button_import_item_settings.Text = "Import Item sett.";
      this.button_import_item_settings.Click += new System.EventHandler(this.button_import_item_settings_Click);
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_numberoftags});
      this.statusStrip1.Location = new System.Drawing.Point(0, 528);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(824, 22);
      this.statusStrip1.TabIndex = 13;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel_numberoftags
      // 
      this.toolStripStatusLabel_numberoftags.Name = "toolStripStatusLabel_numberoftags";
      this.toolStripStatusLabel_numberoftags.Size = new System.Drawing.Size(71, 17);
      this.toolStripStatusLabel_numberoftags.Text = "No. of Tags:";
      // 
      // button_import_tag_list
      // 
      this.button_import_tag_list.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button_import_tag_list.Location = new System.Drawing.Point(728, 300);
      this.button_import_tag_list.Name = "button_import_tag_list";
      this.button_import_tag_list.Size = new System.Drawing.Size(88, 41);
      this.button_import_tag_list.TabIndex = 14;
      this.button_import_tag_list.Text = "Import Tag List";
      this.button_import_tag_list.UseVisualStyleBackColor = true;
      this.button_import_tag_list.Click += new System.EventHandler(this.button_import_tag_list_Click);
      // 
      // oPERATIONBindingSource
      // 
      this.oPERATIONBindingSource.DataMember = "Operations";
      this.oPERATIONBindingSource.DataSource = this.opcCliConfiguration;
      // 
      // oPERATIONBindingSource1
      // 
      this.oPERATIONBindingSource1.DataMember = "Operations";
      this.oPERATIONBindingSource1.DataSource = this.opcCliConfiguration;
      // 
      // Form1
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(824, 550);
      this.Controls.Add(this.button_import_item_settings);
      this.Controls.Add(this.button_import_tag_list);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.textBoxsmplrate);
      this.Controls.Add(this.importGLSButton);
      this.Controls.Add(this.clearButton);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.comboBoxserverID);
      this.Controls.Add(this.importButton);
      this.Controls.Add(this.SaveXMLButton);
      this.Controls.Add(this.ReadXMLButton);
      this.Controls.Add(this.tabControl);
      this.Controls.Add(this.button_import_itemdsc);
      this.Controls.Add(this.button_exit);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Menu = this.mainMenu_dialog;
      this.Name = "Form1";
      this.Text = "DataPorter Configurator";
      this.tabControl.ResumeLayout(false);
      this.tabServers.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridServers)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.opcCliConfiguration)).EndInit();
      this.tabSubItem.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      this.tableLayoutPanel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridSubscription)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridItem)).EndInit();
      this.tabTransition.ResumeLayout(false);
      this.tableLayoutPanel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridTransition)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dataGrid_operation)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource3)).EndInit();
      this.tabPage_TRansactionTree.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.operationLinksBindingSource1)).EndInit();
      this.tabPage_transactionenvironment.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.operationLinksBindingSource)).EndInit();
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.oPERATIONBindingSource1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static XMLManagement XMLMan = new XMLManagement();

    [STAThread]
    static void Main()
    {
      XMLManagement myConfig = new XMLManagement();
      Application.Run(new Form1());
    }

    private void dataGridServers_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
    {

    }

    private void tabControl_SelectedIndexChanged(object sender, System.EventArgs e)
    {

    }

    private void SaveProc()
    {
      try
      {
        saveFileDialogXML = new SaveFileDialog();
        saveFileDialogXML.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
        saveFileDialogXML.Filter = "XML files (*.XML)|*.XML";
        saveFileDialogXML.DefaultExt = ".XML";
        switch (saveFileDialogXML.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            XMLMan.writeXMLFile(transactionEnvironmentTree1.Save(opcCliConfiguration), saveFileDialogXML.FileName);
            opcCliConfiguration.Servers.AcceptChanges();
            opcCliConfiguration.Subscriptions.AcceptChanges();
            opcCliConfiguration.Items.AcceptChanges();
            opcCliConfiguration.Transactions.AcceptChanges();
            MessageBox.Show("Configuration is saved, but data grids may not be up to date, please restart the application");
            break;
          default:
            break;
        }
      }
      catch (Exception er)
      {
        MessageBox.Show(er.ToString());
      }
    }
    private void Read_open()
    {
      if ((opcCliConfiguration.Servers.GetChanges() != null)
        || (opcCliConfiguration.Subscriptions.GetChanges() != null)
        || (opcCliConfiguration.Items.GetChanges() != null)
        || (opcCliConfiguration.Transactions.GetChanges() != null))
      {
        if (MessageBox.Show(this, "Sace current data?", "Data changed", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        {
          SaveProc();
          opcCliConfiguration.Items.AcceptChanges();
          opcCliConfiguration.Transactions.AcceptChanges();
          opcCliConfiguration.Subscriptions.AcceptChanges();
          opcCliConfiguration.Servers.AcceptChanges();
        }

      }
      openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
      openFileDialog.Filter = "XML files (*.XML)|*.XML";
      openFileDialog.DefaultExt = ".XML";
      switch (openFileDialog.ShowDialog())
      {
        case System.Windows.Forms.DialogResult.OK:
          if (opcCliConfiguration != null && opcCliConfiguration.Servers.Count > 0) ClearAll(true);
          try
          {
            XMLMan.readXMLFile(opcCliConfiguration, openFileDialog.FileName);
            opcCliConfiguration.Servers.AcceptChanges();
            opcCliConfiguration.Subscriptions.AcceptChanges();
            opcCliConfiguration.Items.AcceptChanges();
            opcCliConfiguration.Transactions.AcceptChanges();
            opcCliConfiguration.Operations.AcceptChanges();
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.Message);
          }
          break;
        default:
          break;
      }
      UpdateNoofTagInfo();
      transactionEnvironmentTree1.InitialiseTreeFromConfiguration(opcCliConfiguration);

    }
    private void ReadXMLButton_Click(object sender, System.EventArgs e)
    {
      Read_open();
    }

    private void openFileDialogXML_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
    {

    }

    private void SaveXMLButton_Click(object sender, System.EventArgs e)
    {
      SaveProc();
    }

    private void button1_Click(object sender, System.EventArgs e)
    {

    }

    private void dataGridSubscription_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
    {

    }

    private void FindID(out long sub, out long itm)
    {
      //szukamy maksymalnego ID w subskrypcji
      long maxid_sub = 0;
      long sub_rows = 0;

      foreach (OPCCliConfiguration.SubscriptionsRow subrow in opcCliConfiguration.Subscriptions)
      {
        sub_rows++;
        if (subrow.ID > maxid_sub)
          maxid_sub = subrow.ID;
      }
      //jesli juz sa elementy w tabeli to ustawiamy sie na kolejny
      if (sub_rows > 0)
        maxid_sub++;
      //szukamy maksymalnego ID w itemach
      long maxid_item = 0;
      long item_rows = 0;
      foreach (OPCCliConfiguration.ItemsRow itrow in opcCliConfiguration.Items)
      {
        item_rows++;
        if (itrow.ID > maxid_item)
          maxid_item = itrow.ID;
      }
      if (item_rows > 0)
        maxid_item++;
      sub = maxid_sub;
      itm = maxid_item;
    }
    private void importnetconfig_proc()
    {
      if (comboBoxserverID.SelectedValue == null)
      {
        MessageBox.Show("No server selected!");
      }
      else
      {
        long maxid_sub = 0;
        long maxid_item = 0;
        FindID(out maxid_sub, out maxid_item);
        long serverid = System.Convert.ToUInt32(this.comboBoxserverID.SelectedValue.ToString());
        openFileDialog.Filter = "XML files (*.XML)|*.XML";
        openFileDialog.DefaultExt = ".XML";
        NetworkConfig.ComunicationNet configuration;
        configuration = new NetworkConfig.ComunicationNet();
        switch (openFileDialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:
            XMLMan.readXMLFile(configuration, openFileDialog.FileName);
            //dodajemy odpowiednie wiersze
            foreach (NetworkConfig.ComunicationNet.GroupsRow grp in configuration.Groups)
            {
              foreach (NetworkConfig.ComunicationNet.DataBlocksRow block in grp.GetDataBlocksRows())
              {
                string newname = grp.Name + "_" + block.Name;
                OPCCliConfiguration.SubscriptionsRow subsrow = opcCliConfiguration.Subscriptions.NewSubscriptionsRow();
                subsrow.ID = maxid_sub++;
                subsrow.ID_server = serverid;
                subsrow.Name = newname;
                subsrow.UpdateRate = (int)grp.TimeScanFast;//TODO: cast should be removed after changes in the commserver config schema
                opcCliConfiguration.Subscriptions.AddSubscriptionsRow(subsrow);
                foreach (NetworkConfig.ComunicationNet.TagsRow tag in block.GetTagsRows())
                {
                  OPCCliConfiguration.ItemsRow itemrow = opcCliConfiguration.Items.NewItemsRow();
                  itemrow.Name = tag.Name;
                  itemrow.ID = maxid_item++;
                  itemrow.ID_Subscription = subsrow.ID;
                  opcCliConfiguration.Items.AddItemsRow(itemrow);
                }
              }
            }
            break;
          default:
            break;
        }
      }
    }
    private void importButton_Click(object sender, System.EventArgs e)
    {
      importnetconfig_proc();
    }
    private void ClearAll(bool askquestion)
    {
      if (!askquestion || MessageBox.Show(this, "Do you want to clear current configuration?", "Clear", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
      {
        opcCliConfiguration.Clear();
      }

    }
    private void clearButton_Click(object sender, System.EventArgs e)
    {
      ClearAll(true);
    }

    struct GLS
    {
      public string item;
      public string samplerate;
    }
    private void importgls_proc()
    {
      if (comboBoxserverID.SelectedValue == null)
      {
        MessageBox.Show("No server selected!");
      }
      else
      {
        long maxid_sub = 0;
        long maxid_item = 0;
        FindID(out maxid_sub, out maxid_item);
        long serverid = System.Convert.ToUInt32(this.comboBoxserverID.SelectedValue.ToString());
        openFileDialog.Filter = "GLS files (*.GLS)|*.GLS";
        openFileDialog.DefaultExt = ".GLS";

        switch (openFileDialog.ShowDialog())
        {
          case System.Windows.Forms.DialogResult.OK:

            GLS gls;
            ArrayList grupy = new ArrayList();
            ArrayList glsy = new ArrayList();

            //wczytujemy sobie GLS'a do stringa
            StreamReader plik = new StreamReader(openFileDialog.FileName, System.Text.Encoding.Default);
            string pgls = plik.ReadToEnd();
            plik.Close();

            //usuwamy naglowek z GLS'a i znajdujemy index smplrate
            int ind;
            int smpind;
            ind = pgls.IndexOf("\r\n");
            pgls = pgls.Remove(0, ind + 2);
            smpind = pgls.IndexOf("SmplRate");
            ind = pgls.IndexOf("\r\n");
            pgls = pgls.Remove(0, ind + 2);
            ind = pgls.IndexOf("\r\n");
            pgls = pgls.Remove(0, ind + 2);

            ind = pgls.IndexOf("\r\n");
            while (ind > 0)
            {
              //bierzemy jedna linie
              string line = pgls.Substring(0, ind);
              //item
              Match m = Regex.Match(line, @"[A-Z][A-Z|0-9|_]+");
              gls.item = m.ToString();
              //smplrate
              m = Regex.Match(line.Substring(smpind, 10), @"[0-9]+");
              if (m.ToString() == "")
              {
                gls.samplerate = textBoxsmplrate.Text;
              }
              else
              {
                gls.samplerate = m.ToString();
              }
              if (!grupy.Contains(gls.samplerate))
              {
                grupy.Add(gls.samplerate);
              }
              glsy.Add(gls);
              pgls = pgls.Remove(0, ind + 2);
              ind = pgls.IndexOf("\r\n");
            }
            //dodajemy wpisy w tabelach
            foreach (string str in grupy)
            {
              OPCCliConfiguration.SubscriptionsRow subsrow = opcCliConfiguration.Subscriptions.NewSubscriptionsRow();
              subsrow.ID = maxid_sub;
              subsrow.ID_server = serverid;
              subsrow.Name = "GR" + str;
              subsrow.UpdateRate = System.Convert.ToInt32(str);
              opcCliConfiguration.Subscriptions.AddSubscriptionsRow(subsrow);
              foreach (GLS g in glsy)
                if (g.samplerate == str)
                {
                  OPCCliConfiguration.ItemsRow itemrow = opcCliConfiguration.Items.NewItemsRow();//NewItemsRow
                  itemrow.Name = g.item;
                  itemrow.ID = maxid_item++;
                  itemrow.ID_Subscription = subsrow.ID;
                  opcCliConfiguration.Items.AddItemsRow(itemrow);
                }
              maxid_sub++;
            }
            break;
          default:
            break;
        }

      }
    }
    private void importGLSButton_Click(object sender, System.EventArgs e)
    {
      importgls_proc();
    }

    private void menuItem7_Click(object sender, System.EventArgs e)
    {
      ClearAll(true);
    }

    private void menuItem_open_Click(object sender, System.EventArgs e)
    {
      Read_open();
    }

    private void menuItem_save_Click(object sender, System.EventArgs e)
    {
      SaveProc();
    }

    private void menuItem5_Click(object sender, System.EventArgs e)
    {
      importgls_proc();
    }

    private void menuItem6_Click(object sender, System.EventArgs e)
    {
      importnetconfig_proc();
    }

    private void menuItem_close_Click(object sender, System.EventArgs e)
    {
      this.Close();
    }
    private void ImportItemDSC()
    {
      openFileDialog.Filter = "CSV files (*.CSV)|*.CSV";
      openFileDialog.DefaultExt = ".CSV";
      openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
      if (openFileDialog.ShowDialog() == DialogResult.OK)
      {
        BaseStation.ItemDescriber.ItemDecriberDataSet ds = new BaseStation.ItemDescriber.ItemDecriberDataSet();
        //INICIALIZACJA ODPOWIEDNIMI PROPERTY
        foreach (PropertyDescription property in PropertyDescription.Enumerate())
        {
          BaseStation.ItemDescriber.ItemDecriberDataSet.PropertyRow row = ds.Property.NewPropertyRow();
          row.Code = property.ID.Code;
          row.Name = property.Name;
          ds.Property.AddPropertyRow(row);
        }
        BaseStation.ItemDescriber.CSVManagement csvman = new BaseStation.ItemDescriber.CSVManagement();
        csvman.LoadCSV(ds, openFileDialog.FileName);
        //sprawdzamy maksymalny aktualny item id:
        long maxitid = 0;
        foreach (OPCCliConfiguration.ItemsRow irow in opcCliConfiguration.Items)
        {
          if (irow.ID >= maxitid)
            maxitid = irow.ID + 1;
        }
        //przeczytalismy konfiguracje - teraz trzeba ja pododawac do konfiguracji glowne;
        foreach (BaseStation.ItemDescriber.ItemDecriberDataSet.ItemsRow itrow in ds.Items)
        {
          string name = itrow.ItemName;
          string server = "";
          long server_id = 0;
          string group = "";
          long group_id = 0;
          int pos;
          pos = name.IndexOf("/");
          //          string item_name=sourcefile.Substring(0,pos);
          //          sourcefile=sourcefile.Remove(0,pos+1);
          //sprawdzamy serwer;
          if (pos > 0)
          {
            server = name.Substring(0, pos);
            name = name.Remove(0, pos + 1);
            pos = name.IndexOf("/");
            //sprawdzamy grupe
            if (pos > 0)
            {
              group = name.Substring(0, pos);
              name = name.Remove(0, pos + 1);
            }
          }
          bool find = false;
          long maxid = 0;
          //sprawdzamy czy istnieje juz server
          foreach (OPCCliConfiguration.ServersRow srow in opcCliConfiguration.Servers)
          {
            if (srow.ID >= maxid)
              maxid = srow.ID + 1;
            if (srow.Name.Equals(server))
            {
              find = true;
              server_id = srow.ID;
              break;
            }
          }
          if (!find)
          {
            // nieznalezlismy servera - trzeba go dodac
            OPCCliConfiguration.ServersRow newservrow = opcCliConfiguration.Servers.NewServersRow();
            server_id = maxid;
            newservrow.ID = maxid;
            newservrow.Name = server;
            opcCliConfiguration.Servers.AddServersRow(newservrow);
          }
          //sprawdzamy czy istnieje juz grupa:
          maxid = 0;
          find = false;
          foreach (OPCCliConfiguration.SubscriptionsRow srow in opcCliConfiguration.Subscriptions)
          {
            if (srow.ID >= maxid)
              maxid = srow.ID + 1;
            if (srow.Name.Equals(group))
            {
              find = true;
              group_id = srow.ID;
              break;
            }
          }
          if (!find)
          {
            // nieznalezlismy grupy - trzeba go dodac
            OPCCliConfiguration.SubscriptionsRow newgrrow = opcCliConfiguration.Subscriptions.NewSubscriptionsRow();
            newgrrow.ID = maxid;
            newgrrow.Name = group;
            newgrrow.ID_server = server_id;
            group_id = maxid;
            opcCliConfiguration.Subscriptions.AddSubscriptionsRow(newgrrow);
          }
          //mamy server i grupe - dodajemy taga:
          // nieznalezlismy servera - trzeba go dodac
          OPCCliConfiguration.ItemsRow newitrow = opcCliConfiguration.Items.NewItemsRow();
          newitrow.ID = maxitid + itrow.ItemID;
          newitrow.Name = name;
          newitrow.ID_Subscription = group_id;
          throw new Exception("Importing tools are not support new schema yet");
          //newitrow.Type = 15; //domyslnie any type (object)
          //teraz trzeba posprawdzac odpowiednie properties

          //          foreach (PropertyDescription property in PropertyDescription.Enumerate())
          //          {
          //            BaseStation.ItemDescriber.ItemDecriberDataSet.PropertyRow row=ds.Property.NewPropertyRow();
          //            row.Code=property.ID.Code;
          //            row.Name=property.Name;
          //            ds.Property.AddPropertyRow(row);
          //          }
          //opcCliConfiguration.Items.AddItemsRow(newitrow);

        }
      }
    }
    private void button_import_itemdsc_Click(object sender, System.EventArgs e)
    {
      ImportItemDSC();
    }

    private void menuItem_imp_item_dsc_Click(object sender, System.EventArgs e)
    {
      ImportItemDSC();
    }

    private void button_exit_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    private void menuItem_about_Click(object sender, System.EventArgs e)
    {
      //TODO System.Windows.Forms.Form about = new BaseStation.About();
      //TODO about.ShowDialog();
    }

    private void menuItem_itemdsc_Click(object sender, System.EventArgs e)
    {
      try
      {
        System.Diagnostics.Process.Start(AppDomain.CurrentDomain.BaseDirectory + "CAS.ItemDescriber.exe");
      }
      catch (Exception)
      {
        MessageBox.Show("DataPorter is not installed properly");
      }
    }
    private void import_item_sett()
    {
      new CAS.DataPorter.Configurator.HMI.Import.ImportItemSettings(opcCliConfiguration, this).Import();
    }
    private void menuItem_imp_item_sett_Click(object sender, System.EventArgs e)
    {
      import_item_sett();
    }

    private void button_import_item_settings_Click(object sender, System.EventArgs e)
    {
      import_item_sett();
    }

    private void button_edit_oper_param_Click(object sender, System.EventArgs e)
    {
      string parameterstring;
      if (dataGrid_operation.CurrentRow.Index >= 0)
      {
        if (opcCliConfiguration.Operations[dataGrid_operation.CurrentRow.Index].IsParamNull())
        {
          parameterstring = "";
        }
        else
          parameterstring = opcCliConfiguration.Operations[dataGrid_operation.CurrentRow.Index].Param;
        EditOperationParameter form = new EditOperationParameter(this.opcCliConfiguration, parameterstring);

        if (form.ShowDialog() == DialogResult.OK)
        {
          if (form.GetParameterString() != "")
          {
            opcCliConfiguration.Operations[dataGrid_operation.CurrentRow.Index].Param = form.GetParameterString();
          }
        }
      }
    }
    private void UpdateNoofTagInfo()
    {
      if (opcCliConfiguration != null && opcCliConfiguration.Items != null)
      {
        this.toolStripStatusLabel_numberoftags.Text = "No. of Tags: " + opcCliConfiguration.Items.Count.ToString();
      }
    }

    private void button_import_tag_list_Click(object sender, EventArgs e)
    {
      new CAS.DataPorter.Configurator.HMI.Import.ImportTagsList(opcCliConfiguration, this).Import();
    }

    private void tabSubItem_Click(object sender, EventArgs e)
    {

    }

    private void menuItem_helpwindow_Click(object sender, EventArgs e)
    {
      Help.ShowHelp(this, "./DataPorter.chm", "index.html");
    }

    private void menuItem2_Click(object sender, EventArgs e)
    {
      new CAS.DataPorter.Configurator.HMI.Import.ImportTagsList(opcCliConfiguration, this).Import();
    }

    private void button_edit_trans_param_Click(object sender, EventArgs e)
    {
      if (dataGridTransition.CurrentRowIndex >= 0)
      {
        TransactionRowWrapper currentelement = new TransactionRowWrapper(
          opcCliConfiguration.Transactions[dataGridTransition.CurrentRowIndex], 
          new ItemsTableWrapper(opcCliConfiguration.Items), 
          new TransactionEnvironmentNode());
        OKCancelForm form = new OKCancelForm("Transaction Editor");
        form.SetUserControl = currentelement.GetUserControl();
        if (form.ShowDialog() == DialogResult.OK)
        {
        }
      }
      else
      {
        EditorPanelForm form2 = new EditorPanelForm();
        form2.EditorPanel.AddShape(new OperationShape(2, 1, 0, 0, Color.LightGray));
        form2.EditorPanel.AddShape(new OperationShape(4, 2, 0, 0, Color.LightGreen));
        form2.ShowDialog(this);
      }
    }

    private void dataGrid_operation_Navigate(object sender, NavigateEventArgs ne)
    {

    }
  }
}
