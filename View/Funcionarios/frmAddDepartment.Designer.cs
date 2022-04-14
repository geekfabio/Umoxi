
namespace Umoxi
{
    partial class frmAddDepartment
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddDepartment));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.NavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.tabInfo = new DevExpress.XtraBars.Navigation.NavigationBarItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.txtDepID = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtDepartmentName = new Bunifu.UI.WinForms.BunifuTextBox();
            this.lblDepartmentName = new Bunifu.UI.WinForms.BunifuLabel();
            this.transitionManager = new DevExpress.Utils.Animation.TransitionManager(this.components);
            this.Snackbar = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.NavigationBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // NavigationBar
            // 
            this.NavigationBar.AppearanceItem.Disabled.Font = new System.Drawing.Font("Rubik", 12F);
            this.NavigationBar.AppearanceItem.Disabled.Options.UseFont = true;
            this.NavigationBar.AppearanceItem.Hovered.Font = new System.Drawing.Font("Rubik", 12F);
            this.NavigationBar.AppearanceItem.Hovered.Options.UseFont = true;
            this.NavigationBar.AppearanceItem.Normal.Font = new System.Drawing.Font("Rubik", 12F);
            this.NavigationBar.AppearanceItem.Normal.Options.UseFont = true;
            this.NavigationBar.AppearanceItem.Pressed.Font = new System.Drawing.Font("Rubik", 12F);
            this.NavigationBar.AppearanceItem.Pressed.Options.UseFont = true;
            this.NavigationBar.AppearanceItem.Selected.Font = new System.Drawing.Font("Rubik", 12F);
            this.NavigationBar.AppearanceItem.Selected.Options.UseFont = true;
            this.NavigationBar.AutoSize = false;
            this.NavigationBar.BackColor = System.Drawing.Color.Transparent;
            this.NavigationBar.CustomizationButtonVisibility = DevExpress.XtraBars.Navigation.CustomizationButtonVisibility.Hidden;
            this.NavigationBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.NavigationBar.Font = new System.Drawing.Font("Rubik", 5.25F);
            this.NavigationBar.Items.AddRange(new DevExpress.XtraBars.Navigation.NavigationBarItem[] {
            this.tabInfo});
            this.NavigationBar.Location = new System.Drawing.Point(0, 0);
            this.NavigationBar.LookAndFeel.SkinName = "Office 2019 White";
            this.NavigationBar.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.NavigationBar.LookAndFeel.UseDefaultLookAndFeel = false;
            this.NavigationBar.Name = "NavigationBar";
            this.NavigationBar.SelectedItem = this.tabInfo;
            this.NavigationBar.Size = new System.Drawing.Size(324, 30);
            this.NavigationBar.TabIndex = 123;
            this.NavigationBar.Text = "NavigationBar1";
            this.NavigationBar.ViewMode = DevExpress.XtraBars.Navigation.OfficeNavigationBarViewMode.Tab;
            // 
            // tabInfo
            // 
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Text = "Department";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 57);
            this.panel1.TabIndex = 124;
            // 
            // btnSave
            // 
            this.btnSave.AllowAnimations = true;
            this.btnSave.AllowMouseEffects = true;
            this.btnSave.AllowToggling = false;
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSave.AnimationSpeed = 200;
            this.btnSave.AutoGenerateColors = false;
            this.btnSave.AutoRoundBorders = false;
            this.btnSave.AutoSizeLeftIcon = true;
            this.btnSave.AutoSizeRightIcon = true;
            this.btnSave.BackColor = System.Drawing.Color.Transparent;
            this.btnSave.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnSave.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSave.BackgroundImage")));
            this.btnSave.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.ButtonText = "Save";
            this.btnSave.ButtonTextMarginLeft = 0;
            this.btnSave.ColorContrastOnClick = 45;
            this.btnSave.ColorContrastOnHover = 45;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnSave.CustomizableEdges = borderEdges1;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnSave.Font = new System.Drawing.Font("Rubik", 9F);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.IconLeft = null;
            this.btnSave.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnSave.IconMarginLeft = 11;
            this.btnSave.IconPadding = 10;
            this.btnSave.IconRight = null;
            this.btnSave.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnSave.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnSave.IconSize = 25;
            this.btnSave.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnSave.IdleBorderRadius = 10;
            this.btnSave.IdleBorderThickness = 1;
            this.btnSave.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnSave.IdleIconLeftImage = null;
            this.btnSave.IdleIconRightImage = null;
            this.btnSave.IndicateFocus = false;
            this.btnSave.Location = new System.Drawing.Point(215, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnSave.OnDisabledState.BorderRadius = 10;
            this.btnSave.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnDisabledState.BorderThickness = 1;
            this.btnSave.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnSave.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnSave.OnDisabledState.IconLeftImage = null;
            this.btnSave.OnDisabledState.IconRightImage = null;
            this.btnSave.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(176)))), ((int)(((byte)(218)))));
            this.btnSave.onHoverState.BorderRadius = 10;
            this.btnSave.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.onHoverState.BorderThickness = 1;
            this.btnSave.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(176)))), ((int)(((byte)(218)))));
            this.btnSave.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnSave.onHoverState.IconLeftImage = null;
            this.btnSave.onHoverState.IconRightImage = null;
            this.btnSave.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnSave.OnIdleState.BorderRadius = 10;
            this.btnSave.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnIdleState.BorderThickness = 1;
            this.btnSave.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.btnSave.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnIdleState.IconLeftImage = null;
            this.btnSave.OnIdleState.IconRightImage = null;
            this.btnSave.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnSave.OnPressedState.BorderRadius = 10;
            this.btnSave.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnSave.OnPressedState.BorderThickness = 1;
            this.btnSave.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(62)))), ((int)(((byte)(103)))));
            this.btnSave.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnSave.OnPressedState.IconLeftImage = null;
            this.btnSave.OnPressedState.IconRightImage = null;
            this.btnSave.Size = new System.Drawing.Size(97, 32);
            this.btnSave.TabIndex = 77;
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSave.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSave.TextMarginLeft = 0;
            this.btnSave.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnSave.UseDefaultRadiusAndThickness = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.AllowAnimations = true;
            this.btnClose.AllowMouseEffects = true;
            this.btnClose.AllowToggling = false;
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.AnimationSpeed = 200;
            this.btnClose.AutoGenerateColors = false;
            this.btnClose.AutoRoundBorders = false;
            this.btnClose.AutoSizeLeftIcon = true;
            this.btnClose.AutoSizeRightIcon = true;
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BackColor1 = System.Drawing.Color.White;
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.ButtonText = "Close";
            this.btnClose.ButtonTextMarginLeft = 0;
            this.btnClose.ColorContrastOnClick = 45;
            this.btnClose.ColorContrastOnHover = 45;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges2.BottomLeft = true;
            borderEdges2.BottomRight = true;
            borderEdges2.TopLeft = true;
            borderEdges2.TopRight = true;
            this.btnClose.CustomizableEdges = borderEdges2;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnClose.Font = new System.Drawing.Font("Rubik", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.IconLeft = null;
            this.btnClose.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnClose.IconMarginLeft = 11;
            this.btnClose.IconPadding = 10;
            this.btnClose.IconRight = null;
            this.btnClose.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnClose.IconSize = 25;
            this.btnClose.IdleBorderColor = System.Drawing.Color.Silver;
            this.btnClose.IdleBorderRadius = 10;
            this.btnClose.IdleBorderThickness = 1;
            this.btnClose.IdleFillColor = System.Drawing.Color.White;
            this.btnClose.IdleIconLeftImage = null;
            this.btnClose.IdleIconRightImage = null;
            this.btnClose.IndicateFocus = false;
            this.btnClose.Location = new System.Drawing.Point(112, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnClose.OnDisabledState.BorderRadius = 10;
            this.btnClose.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnDisabledState.BorderThickness = 1;
            this.btnClose.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnClose.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnClose.OnDisabledState.IconLeftImage = null;
            this.btnClose.OnDisabledState.IconRightImage = null;
            this.btnClose.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.btnClose.onHoverState.BorderRadius = 10;
            this.btnClose.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.onHoverState.BorderThickness = 1;
            this.btnClose.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(200)))), ((int)(((byte)(207)))));
            this.btnClose.onHoverState.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.onHoverState.IconLeftImage = null;
            this.btnClose.onHoverState.IconRightImage = null;
            this.btnClose.OnIdleState.BorderColor = System.Drawing.Color.Silver;
            this.btnClose.OnIdleState.BorderRadius = 10;
            this.btnClose.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnIdleState.BorderThickness = 1;
            this.btnClose.OnIdleState.FillColor = System.Drawing.Color.White;
            this.btnClose.OnIdleState.ForeColor = System.Drawing.Color.Gray;
            this.btnClose.OnIdleState.IconLeftImage = null;
            this.btnClose.OnIdleState.IconRightImage = null;
            this.btnClose.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(189)))), ((int)(((byte)(198)))));
            this.btnClose.OnPressedState.BorderRadius = 10;
            this.btnClose.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnClose.OnPressedState.BorderThickness = 1;
            this.btnClose.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(189)))), ((int)(((byte)(198)))));
            this.btnClose.OnPressedState.ForeColor = System.Drawing.Color.DimGray;
            this.btnClose.OnPressedState.IconLeftImage = null;
            this.btnClose.OnPressedState.IconRightImage = null;
            this.btnClose.Size = new System.Drawing.Size(97, 32);
            this.btnClose.TabIndex = 78;
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnClose.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnClose.TextMarginLeft = 0;
            this.btnClose.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnClose.UseDefaultRadiusAndThickness = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDepID
            // 
            this.txtDepID.AcceptsReturn = false;
            this.txtDepID.AcceptsTab = false;
            this.txtDepID.AnimationSpeed = 200;
            this.txtDepID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDepID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDepID.AutoSizeHeight = true;
            this.txtDepID.BackColor = System.Drawing.Color.White;
            this.txtDepID.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDepID.BackgroundImage")));
            this.txtDepID.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.txtDepID.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDepID.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtDepID.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtDepID.BorderRadius = 10;
            this.txtDepID.BorderThickness = 1;
            this.txtDepID.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDepID.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepID.DefaultFont = new System.Drawing.Font("Rubik", 9.25F);
            this.txtDepID.DefaultText = "";
            this.txtDepID.FillColor = System.Drawing.Color.White;
            this.txtDepID.HideSelection = true;
            this.txtDepID.IconLeft = null;
            this.txtDepID.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepID.IconPadding = 10;
            this.txtDepID.IconRight = null;
            this.txtDepID.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepID.Lines = new string[0];
            this.txtDepID.Location = new System.Drawing.Point(2, 67);
            this.txtDepID.MaxLength = 32767;
            this.txtDepID.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDepID.Modified = false;
            this.txtDepID.Multiline = false;
            this.txtDepID.Name = "txtDepID";
            stateProperties1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepID.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDepID.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepID.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepID.OnIdleState = stateProperties4;
            this.txtDepID.Padding = new System.Windows.Forms.Padding(3);
            this.txtDepID.PasswordChar = '\0';
            this.txtDepID.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDepID.PlaceholderText = "";
            this.txtDepID.ReadOnly = false;
            this.txtDepID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDepID.SelectedText = "";
            this.txtDepID.SelectionLength = 0;
            this.txtDepID.SelectionStart = 0;
            this.txtDepID.ShortcutsEnabled = true;
            this.txtDepID.Size = new System.Drawing.Size(23, 35);
            this.txtDepID.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtDepID.TabIndex = 157;
            this.txtDepID.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDepID.TextMarginBottom = 0;
            this.txtDepID.TextMarginLeft = 3;
            this.txtDepID.TextMarginTop = 0;
            this.txtDepID.TextPlaceholder = "";
            this.txtDepID.UseSystemPasswordChar = false;
            this.txtDepID.Visible = false;
            this.txtDepID.WordWrap = true;
            // 
            // txtDepartmentName
            // 
            this.txtDepartmentName.AcceptsReturn = false;
            this.txtDepartmentName.AcceptsTab = false;
            this.txtDepartmentName.AnimationSpeed = 200;
            this.txtDepartmentName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtDepartmentName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtDepartmentName.AutoSizeHeight = true;
            this.txtDepartmentName.BackColor = System.Drawing.Color.White;
            this.txtDepartmentName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtDepartmentName.BackgroundImage")));
            this.txtDepartmentName.BorderColorActive = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            this.txtDepartmentName.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtDepartmentName.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtDepartmentName.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtDepartmentName.BorderRadius = 10;
            this.txtDepartmentName.BorderThickness = 1;
            this.txtDepartmentName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtDepartmentName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartmentName.DefaultFont = new System.Drawing.Font("Rubik", 9.25F);
            this.txtDepartmentName.DefaultText = "";
            this.txtDepartmentName.FillColor = System.Drawing.Color.White;
            this.txtDepartmentName.HideSelection = true;
            this.txtDepartmentName.IconLeft = null;
            this.txtDepartmentName.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartmentName.IconPadding = 10;
            this.txtDepartmentName.IconRight = null;
            this.txtDepartmentName.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDepartmentName.Lines = new string[0];
            this.txtDepartmentName.Location = new System.Drawing.Point(31, 67);
            this.txtDepartmentName.MaxLength = 32767;
            this.txtDepartmentName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtDepartmentName.Modified = false;
            this.txtDepartmentName.Multiline = false;
            this.txtDepartmentName.Name = "txtDepartmentName";
            stateProperties5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(113)))), ((int)(((byte)(188)))));
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartmentName.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtDepartmentName.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartmentName.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtDepartmentName.OnIdleState = stateProperties8;
            this.txtDepartmentName.Padding = new System.Windows.Forms.Padding(3);
            this.txtDepartmentName.PasswordChar = '\0';
            this.txtDepartmentName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtDepartmentName.PlaceholderText = "";
            this.txtDepartmentName.ReadOnly = false;
            this.txtDepartmentName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDepartmentName.SelectedText = "";
            this.txtDepartmentName.SelectionLength = 0;
            this.txtDepartmentName.SelectionStart = 0;
            this.txtDepartmentName.ShortcutsEnabled = true;
            this.txtDepartmentName.Size = new System.Drawing.Size(270, 35);
            this.txtDepartmentName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtDepartmentName.TabIndex = 155;
            this.txtDepartmentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtDepartmentName.TextMarginBottom = 0;
            this.txtDepartmentName.TextMarginLeft = 3;
            this.txtDepartmentName.TextMarginTop = 0;
            this.txtDepartmentName.TextPlaceholder = "";
            this.txtDepartmentName.UseSystemPasswordChar = false;
            this.txtDepartmentName.WordWrap = true;
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AllowParentOverrides = false;
            this.lblDepartmentName.AutoEllipsis = false;
            this.lblDepartmentName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblDepartmentName.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblDepartmentName.Font = new System.Drawing.Font("Rubik", 9F);
            this.lblDepartmentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblDepartmentName.Location = new System.Drawing.Point(35, 48);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblDepartmentName.Size = new System.Drawing.Size(77, 15);
            this.lblDepartmentName.TabIndex = 156;
            this.lblDepartmentName.Text = "Department *";
            this.lblDepartmentName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblDepartmentName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // transitionManager
            // 
            this.transitionManager.FrameCount = 400;
            this.transitionManager.ShowWaitingIndicator = false;
            // 
            // Snackbar
            // 
            this.Snackbar.AllowDragging = false;
            this.Snackbar.AllowMultipleViews = true;
            this.Snackbar.ClickToClose = true;
            this.Snackbar.DoubleClickToClose = true;
            this.Snackbar.DurationAfterIdle = 3000;
            this.Snackbar.ErrorOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Snackbar.ErrorOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(74)))), ((int)(((byte)(76)))));
            this.Snackbar.ErrorOptions.ActionBorderRadius = 1;
            this.Snackbar.ErrorOptions.ActionFont = new System.Drawing.Font("Rubik", 8.25F, System.Drawing.FontStyle.Bold);
            this.Snackbar.ErrorOptions.ActionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(74)))), ((int)(((byte)(76)))));
            this.Snackbar.ErrorOptions.BackColor = System.Drawing.Color.White;
            this.Snackbar.ErrorOptions.BorderColor = System.Drawing.Color.White;
            this.Snackbar.ErrorOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(199)))));
            this.Snackbar.ErrorOptions.Font = new System.Drawing.Font("Rubik", 9.75F);
            this.Snackbar.ErrorOptions.ForeColor = System.Drawing.Color.Black;
            this.Snackbar.ErrorOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon")));
            this.Snackbar.ErrorOptions.IconLeftMargin = 12;
            this.Snackbar.FadeCloseIcon = false;
            this.Snackbar.Host = Bunifu.UI.WinForms.BunifuSnackbar.Hosts.FormOwner;
            this.Snackbar.InformationOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Snackbar.InformationOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(149)))), ((int)(((byte)(242)))));
            this.Snackbar.InformationOptions.ActionBorderRadius = 1;
            this.Snackbar.InformationOptions.ActionFont = new System.Drawing.Font("Rubik", 8.25F);
            this.Snackbar.InformationOptions.ActionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(149)))), ((int)(((byte)(242)))));
            this.Snackbar.InformationOptions.BackColor = System.Drawing.Color.White;
            this.Snackbar.InformationOptions.BorderColor = System.Drawing.Color.White;
            this.Snackbar.InformationOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(213)))), ((int)(((byte)(255)))));
            this.Snackbar.InformationOptions.Font = new System.Drawing.Font("Rubik", 9.75F);
            this.Snackbar.InformationOptions.ForeColor = System.Drawing.Color.Black;
            this.Snackbar.InformationOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon1")));
            this.Snackbar.InformationOptions.IconLeftMargin = 12;
            this.Snackbar.Margin = 10;
            this.Snackbar.MaximumSize = new System.Drawing.Size(0, 0);
            this.Snackbar.MaximumViews = 7;
            this.Snackbar.MessageRightMargin = 15;
            this.Snackbar.MinimumSize = new System.Drawing.Size(0, 0);
            this.Snackbar.ShowBorders = false;
            this.Snackbar.ShowCloseIcon = true;
            this.Snackbar.ShowIcon = true;
            this.Snackbar.ShowShadows = true;
            this.Snackbar.SuccessOptions.ActionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.Snackbar.SuccessOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(196)))), ((int)(((byte)(26)))));
            this.Snackbar.SuccessOptions.ActionBorderRadius = 1;
            this.Snackbar.SuccessOptions.ActionFont = new System.Drawing.Font("Rubik", 8.25F);
            this.Snackbar.SuccessOptions.ActionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(196)))), ((int)(((byte)(26)))));
            this.Snackbar.SuccessOptions.BackColor = System.Drawing.Color.White;
            this.Snackbar.SuccessOptions.BorderColor = System.Drawing.Color.White;
            this.Snackbar.SuccessOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(255)))), ((int)(((byte)(237)))));
            this.Snackbar.SuccessOptions.Font = new System.Drawing.Font("Rubik", 9.75F);
            this.Snackbar.SuccessOptions.ForeColor = System.Drawing.Color.Black;
            this.Snackbar.SuccessOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon2")));
            this.Snackbar.SuccessOptions.IconLeftMargin = 12;
            this.Snackbar.ViewsMargin = 7;
            this.Snackbar.WarningOptions.ActionBackColor = System.Drawing.Color.White;
            this.Snackbar.WarningOptions.ActionBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(173)))), ((int)(((byte)(20)))));
            this.Snackbar.WarningOptions.ActionBorderRadius = 5;
            this.Snackbar.WarningOptions.ActionFont = new System.Drawing.Font("Rubik", 8.25F);
            this.Snackbar.WarningOptions.ActionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(173)))), ((int)(((byte)(20)))));
            this.Snackbar.WarningOptions.BackColor = System.Drawing.Color.White;
            this.Snackbar.WarningOptions.BorderColor = System.Drawing.Color.White;
            this.Snackbar.WarningOptions.CloseIconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(229)))), ((int)(((byte)(143)))));
            this.Snackbar.WarningOptions.Font = new System.Drawing.Font("Rubik", 9.75F);
            this.Snackbar.WarningOptions.ForeColor = System.Drawing.Color.Black;
            this.Snackbar.WarningOptions.Icon = ((System.Drawing.Image)(resources.GetObject("resource.Icon3")));
            this.Snackbar.WarningOptions.IconLeftMargin = 12;
            this.Snackbar.ZoomCloseIcon = true;
            // 
            // bunifuSeparator2
            // 
            this.bunifuSeparator2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator2.BackgroundImage")));
            this.bunifuSeparator2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator2.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bunifuSeparator2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.bunifuSeparator2.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator2.LineThickness = 1;
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 133);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(324, 1);
            this.bunifuSeparator2.TabIndex = 158;
            // 
            // bunifuSeparator1
            // 
            this.bunifuSeparator1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuSeparator1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuSeparator1.BackgroundImage")));
            this.bunifuSeparator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSeparator1.DashCap = Bunifu.UI.WinForms.BunifuSeparator.CapStyles.Flat;
            this.bunifuSeparator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.bunifuSeparator1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(244)))), ((int)(((byte)(245)))));
            this.bunifuSeparator1.LineStyle = Bunifu.UI.WinForms.BunifuSeparator.LineStyles.Solid;
            this.bunifuSeparator1.LineThickness = 1;
            this.bunifuSeparator1.Location = new System.Drawing.Point(0, 30);
            this.bunifuSeparator1.Name = "bunifuSeparator1";
            this.bunifuSeparator1.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator1.Size = new System.Drawing.Size(324, 1);
            this.bunifuSeparator1.TabIndex = 159;
            // 
            // frmAddDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(324, 191);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.txtDepID);
            this.Controls.Add(this.txtDepartmentName);
            this.Controls.Add(this.lblDepartmentName);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NavigationBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddDepartment";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddDepartment_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.NavigationBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.OfficeNavigationBar NavigationBar;
        private System.Windows.Forms.Panel panel1;
        internal Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        internal Bunifu.UI.WinForms.BunifuTextBox txtDepID;
        internal Bunifu.UI.WinForms.BunifuTextBox txtDepartmentName;
        private Bunifu.UI.WinForms.BunifuLabel lblDepartmentName;
        private DevExpress.Utils.Animation.TransitionManager transitionManager;
        private Bunifu.UI.WinForms.BunifuSnackbar Snackbar;
        private DevExpress.XtraBars.Navigation.NavigationBarItem tabInfo;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
    }
}