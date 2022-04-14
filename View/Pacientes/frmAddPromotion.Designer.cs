
namespace Umoxi
{
    partial class frmAddPromotion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddPromotion));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges2 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            this.NavigationBar = new DevExpress.XtraBars.Navigation.OfficeNavigationBar();
            this.tabInfo = new DevExpress.XtraBars.Navigation.NavigationBarItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnClose = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuSeparator1 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.bunifuSeparator2 = new Bunifu.UI.WinForms.BunifuSeparator();
            this.cmbSession1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.lblClassNamecm = new Bunifu.UI.WinForms.BunifuLabel();
            this.cmbSchool1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.lblClassName = new Bunifu.UI.WinForms.BunifuLabel();
            this.cmbClass1 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.Snackbar = new Bunifu.UI.WinForms.BunifuSnackbar(this.components);
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
            this.NavigationBar.TabIndex = 124;
            this.NavigationBar.Text = "NavigationBar1";
            this.NavigationBar.ViewMode = DevExpress.XtraBars.Navigation.OfficeNavigationBarViewMode.Tab;
            // 
            // tabInfo
            // 
            this.tabInfo.Name = "tabInfo";
            this.tabInfo.Text = "Promotion";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 57);
            this.panel1.TabIndex = 125;
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
            this.bunifuSeparator1.TabIndex = 139;
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
            this.bunifuSeparator2.Location = new System.Drawing.Point(0, 243);
            this.bunifuSeparator2.Name = "bunifuSeparator2";
            this.bunifuSeparator2.Orientation = Bunifu.UI.WinForms.BunifuSeparator.LineOrientation.Horizontal;
            this.bunifuSeparator2.Size = new System.Drawing.Size(324, 1);
            this.bunifuSeparator2.TabIndex = 140;
            // 
            // cmbSession1
            // 
            this.cmbSession1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSession1.BackColor = System.Drawing.Color.Transparent;
            this.cmbSession1.BackgroundColor = System.Drawing.Color.White;
            this.cmbSession1.BorderColor = System.Drawing.Color.Silver;
            this.cmbSession1.BorderRadius = 5;
            this.cmbSession1.Color = System.Drawing.Color.Silver;
            this.cmbSession1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbSession1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbSession1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbSession1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbSession1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbSession1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbSession1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSession1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbSession1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSession1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbSession1.FillDropDown = true;
            this.cmbSession1.FillIndicator = false;
            this.cmbSession1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSession1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSession1.ForeColor = System.Drawing.Color.Black;
            this.cmbSession1.FormattingEnabled = true;
            this.cmbSession1.Icon = null;
            this.cmbSession1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbSession1.IndicatorColor = System.Drawing.Color.Gray;
            this.cmbSession1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbSession1.IndicatorThickness = 2;
            this.cmbSession1.IsDropdownOpened = false;
            this.cmbSession1.ItemBackColor = System.Drawing.Color.White;
            this.cmbSession1.ItemBorderColor = System.Drawing.Color.White;
            this.cmbSession1.ItemForeColor = System.Drawing.Color.Black;
            this.cmbSession1.ItemHeight = 26;
            this.cmbSession1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cmbSession1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cmbSession1.ItemTopMargin = 3;
            this.cmbSession1.Location = new System.Drawing.Point(28, 198);
            this.cmbSession1.Name = "cmbSession1";
            this.cmbSession1.Size = new System.Drawing.Size(270, 32);
            this.cmbSession1.TabIndex = 167;
            this.cmbSession1.Text = null;
            this.cmbSession1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbSession1.TextLeftMargin = 5;
            // 
            // lblClassNamecm
            // 
            this.lblClassNamecm.AllowParentOverrides = false;
            this.lblClassNamecm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblClassNamecm.AutoEllipsis = false;
            this.lblClassNamecm.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClassNamecm.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblClassNamecm.Font = new System.Drawing.Font("Rubik", 9F);
            this.lblClassNamecm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblClassNamecm.Location = new System.Drawing.Point(34, 45);
            this.lblClassNamecm.Name = "lblClassNamecm";
            this.lblClassNamecm.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblClassNamecm.Size = new System.Drawing.Size(46, 15);
            this.lblClassNamecm.TabIndex = 166;
            this.lblClassNamecm.Text = "School *";
            this.lblClassNamecm.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblClassNamecm.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cmbSchool1
            // 
            this.cmbSchool1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbSchool1.BackColor = System.Drawing.Color.Transparent;
            this.cmbSchool1.BackgroundColor = System.Drawing.Color.White;
            this.cmbSchool1.BorderColor = System.Drawing.Color.Silver;
            this.cmbSchool1.BorderRadius = 5;
            this.cmbSchool1.Color = System.Drawing.Color.Silver;
            this.cmbSchool1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbSchool1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbSchool1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbSchool1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbSchool1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbSchool1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbSchool1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSchool1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbSchool1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSchool1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbSchool1.FillDropDown = true;
            this.cmbSchool1.FillIndicator = false;
            this.cmbSchool1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSchool1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbSchool1.ForeColor = System.Drawing.Color.Black;
            this.cmbSchool1.FormattingEnabled = true;
            this.cmbSchool1.Icon = null;
            this.cmbSchool1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbSchool1.IndicatorColor = System.Drawing.Color.Gray;
            this.cmbSchool1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbSchool1.IndicatorThickness = 2;
            this.cmbSchool1.IsDropdownOpened = false;
            this.cmbSchool1.ItemBackColor = System.Drawing.Color.White;
            this.cmbSchool1.ItemBorderColor = System.Drawing.Color.White;
            this.cmbSchool1.ItemForeColor = System.Drawing.Color.Black;
            this.cmbSchool1.ItemHeight = 26;
            this.cmbSchool1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cmbSchool1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cmbSchool1.ItemTopMargin = 3;
            this.cmbSchool1.Location = new System.Drawing.Point(28, 64);
            this.cmbSchool1.Name = "cmbSchool1";
            this.cmbSchool1.Size = new System.Drawing.Size(270, 32);
            this.cmbSchool1.TabIndex = 165;
            this.cmbSchool1.Text = null;
            this.cmbSchool1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbSchool1.TextLeftMargin = 5;
            // 
            // lblClassName
            // 
            this.lblClassName.AllowParentOverrides = false;
            this.lblClassName.AutoEllipsis = false;
            this.lblClassName.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblClassName.CursorType = System.Windows.Forms.Cursors.Default;
            this.lblClassName.Font = new System.Drawing.Font("Rubik", 9F);
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.lblClassName.Location = new System.Drawing.Point(32, 177);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblClassName.Size = new System.Drawing.Size(51, 15);
            this.lblClassName.TabIndex = 164;
            this.lblClassName.Text = "Session *";
            this.lblClassName.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lblClassName.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // cmbClass1
            // 
            this.cmbClass1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cmbClass1.BackColor = System.Drawing.Color.Transparent;
            this.cmbClass1.BackgroundColor = System.Drawing.Color.White;
            this.cmbClass1.BorderColor = System.Drawing.Color.Silver;
            this.cmbClass1.BorderRadius = 5;
            this.cmbClass1.Color = System.Drawing.Color.Silver;
            this.cmbClass1.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.cmbClass1.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbClass1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.cmbClass1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.cmbClass1.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.cmbClass1.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.cmbClass1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClass1.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.cmbClass1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass1.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbClass1.FillDropDown = true;
            this.cmbClass1.FillIndicator = false;
            this.cmbClass1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClass1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbClass1.ForeColor = System.Drawing.Color.Black;
            this.cmbClass1.FormattingEnabled = true;
            this.cmbClass1.Icon = null;
            this.cmbClass1.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbClass1.IndicatorColor = System.Drawing.Color.Gray;
            this.cmbClass1.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.cmbClass1.IndicatorThickness = 2;
            this.cmbClass1.IsDropdownOpened = false;
            this.cmbClass1.ItemBackColor = System.Drawing.Color.White;
            this.cmbClass1.ItemBorderColor = System.Drawing.Color.White;
            this.cmbClass1.ItemForeColor = System.Drawing.Color.Black;
            this.cmbClass1.ItemHeight = 26;
            this.cmbClass1.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.cmbClass1.ItemHighLightForeColor = System.Drawing.Color.White;
            this.cmbClass1.ItemTopMargin = 3;
            this.cmbClass1.Location = new System.Drawing.Point(28, 131);
            this.cmbClass1.Name = "cmbClass1";
            this.cmbClass1.Size = new System.Drawing.Size(270, 32);
            this.cmbClass1.TabIndex = 169;
            this.cmbClass1.Text = null;
            this.cmbClass1.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.cmbClass1.TextLeftMargin = 5;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Rubik", 9F);
            this.bunifuLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(61)))), ((int)(((byte)(61)))));
            this.bunifuLabel1.Location = new System.Drawing.Point(32, 110);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(38, 15);
            this.bunifuLabel1.TabIndex = 168;
            this.bunifuLabel1.Text = "Class *";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
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
            // frmAddPromotion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(324, 301);
            this.Controls.Add(this.cmbClass1);
            this.Controls.Add(this.bunifuLabel1);
            this.Controls.Add(this.cmbSession1);
            this.Controls.Add(this.lblClassNamecm);
            this.Controls.Add(this.cmbSchool1);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.bunifuSeparator2);
            this.Controls.Add(this.bunifuSeparator1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.NavigationBar);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAddPromotion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAddPromotion_FormClosed);
            this.Load += new System.EventHandler(this.frmAddPromotion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NavigationBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Navigation.OfficeNavigationBar NavigationBar;
        private DevExpress.XtraBars.Navigation.NavigationBarItem tabInfo;
        private System.Windows.Forms.Panel panel1;
        internal Bunifu.UI.WinForms.BunifuButton.BunifuButton btnSave;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnClose;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator1;
        private Bunifu.UI.WinForms.BunifuSeparator bunifuSeparator2;
        internal Bunifu.UI.WinForms.BunifuDropdown cmbSession1;
        private Bunifu.UI.WinForms.BunifuLabel lblClassNamecm;
        internal Bunifu.UI.WinForms.BunifuDropdown cmbSchool1;
        private Bunifu.UI.WinForms.BunifuLabel lblClassName;
        internal Bunifu.UI.WinForms.BunifuDropdown cmbClass1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private Bunifu.UI.WinForms.BunifuSnackbar Snackbar;
    }
}