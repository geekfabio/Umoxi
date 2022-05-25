
namespace Umoxi
{
    partial class ChangeUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUser));
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties1 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties2 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties3 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties4 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.mvvmContext = new DevExpress.Utils.MVVM.MVVMContext(this.components);
            this.headerPanel = new DevExpress.XtraEditors.SidePanel();
            this.headerTextLabel = new DevExpress.XtraEditors.LabelControl();
            this.closeButton = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_chkActive = new Bunifu.UI.WinForms.BunifuLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.btnNoViewPassword = new Bunifu.UI.WinForms.BunifuImageButton();
            this.btnViewPassword = new Bunifu.UI.WinForms.BunifuImageButton();
            this.chkRememberMe = new Bunifu.UI.WinForms.BunifuCheckBox();
            this.txtUserName = new Bunifu.UI.WinForms.BunifuTextBox();
            this.txtPassword = new Bunifu.UI.WinForms.BunifuTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).BeginInit();
            this.headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mvvmContext
            // 
            this.mvvmContext.ContainerControl = this;
            // 
            // headerPanel
            // 
            this.headerPanel.AllowResize = false;
            this.headerPanel.Appearance.BackColor = System.Drawing.Color.White;
            this.headerPanel.Appearance.Options.UseBackColor = true;
            this.headerPanel.Controls.Add(this.headerTextLabel);
            this.headerPanel.Controls.Add(this.closeButton);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.MaximumSize = new System.Drawing.Size(0, 31);
            this.headerPanel.MinimumSize = new System.Drawing.Size(0, 31);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(450, 31);
            this.headerPanel.TabIndex = 28;
            // 
            // headerTextLabel
            // 
            this.headerTextLabel.Appearance.Font = new System.Drawing.Font("Rubik", 8.25F, System.Drawing.FontStyle.Bold);
            this.headerTextLabel.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.headerTextLabel.Appearance.Options.UseFont = true;
            this.headerTextLabel.Appearance.Options.UseTextOptions = true;
            this.headerTextLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.headerTextLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.headerTextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headerTextLabel.Location = new System.Drawing.Point(0, 0);
            this.headerTextLabel.Name = "headerTextLabel";
            this.headerTextLabel.Padding = new System.Windows.Forms.Padding(16, 0, 0, 0);
            this.headerTextLabel.Size = new System.Drawing.Size(416, 30);
            this.headerTextLabel.TabIndex = 3;
            this.headerTextLabel.Text = "Trocar de Usuário";
            // 
            // closeButton
            // 
            this.closeButton.AllowFocus = false;
            this.closeButton.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Danger;
            this.closeButton.Appearance.Options.UseBackColor = true;
            this.closeButton.AutoSize = true;
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.closeButton.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.closeButton.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("closeButton.ImageOptions.SvgImage")));
            this.closeButton.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.closeButton.Location = new System.Drawing.Point(416, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.closeButton.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.closeButton.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.closeButton.Size = new System.Drawing.Size(34, 30);
            this.closeButton.TabIndex = 2;
            this.closeButton.TabStop = false;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Rubik", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl1.Location = new System.Drawing.Point(26, 121);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(396, 13);
            this.labelControl1.TabIndex = 29;
            this.labelControl1.Text = "Enter your user name and password to proceed.";
            // 
            // lbl_chkActive
            // 
            this.lbl_chkActive.AccessibleRole = System.Windows.Forms.AccessibleRole.CheckButton;
            this.lbl_chkActive.AllowParentOverrides = false;
            this.lbl_chkActive.AutoEllipsis = false;
            this.lbl_chkActive.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_chkActive.CursorType = System.Windows.Forms.Cursors.Default;
            this.lbl_chkActive.Font = new System.Drawing.Font("Rubik", 9F);
            this.lbl_chkActive.Location = new System.Drawing.Point(73, 276);
            this.lbl_chkActive.Name = "lbl_chkActive";
            this.lbl_chkActive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_chkActive.Size = new System.Drawing.Size(73, 15);
            this.lbl_chkActive.TabIndex = 107;
            this.lbl_chkActive.Text = "Lembrar-me";
            this.lbl_chkActive.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.lbl_chkActive.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Umoxi.Properties.Resources.icons8_change_user_96px;
            this.pictureBox1.Location = new System.Drawing.Point(182, 37);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 113;
            this.pictureBox1.TabStop = false;
            // 
            // btnLogin
            // 
            this.btnLogin.AllowAnimations = true;
            this.btnLogin.AllowMouseEffects = true;
            this.btnLogin.AllowToggling = false;
            this.btnLogin.AnimationSpeed = 200;
            this.btnLogin.AutoGenerateColors = true;
            this.btnLogin.AutoRoundBorders = true;
            this.btnLogin.AutoSizeLeftIcon = true;
            this.btnLogin.AutoSizeRightIcon = true;
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BackColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.ButtonText = "Iniciar Sessão";
            this.btnLogin.ButtonTextMarginLeft = 0;
            this.btnLogin.ColorContrastOnClick = 45;
            this.btnLogin.ColorContrastOnHover = 45;
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges1.BottomLeft = true;
            borderEdges1.BottomRight = true;
            borderEdges1.TopLeft = true;
            borderEdges1.TopRight = true;
            this.btnLogin.CustomizableEdges = borderEdges1;
            this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLogin.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.btnLogin.Font = new System.Drawing.Font("Rubik", 9F);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.btnLogin.IconMarginLeft = 11;
            this.btnLogin.IconPadding = 10;
            this.btnLogin.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.btnLogin.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.btnLogin.IconSize = 25;
            this.btnLogin.IdleBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btnLogin.IdleBorderRadius = 30;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btnLogin.IdleIconLeftImage = null;
            this.btnLogin.IdleIconRightImage = null;
            this.btnLogin.IndicateFocus = false;
            this.btnLogin.Location = new System.Drawing.Point(257, 266);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.btnLogin.OnDisabledState.BorderRadius = 1;
            this.btnLogin.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnDisabledState.BorderThickness = 1;
            this.btnLogin.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.btnLogin.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.btnLogin.OnDisabledState.IconLeftImage = null;
            this.btnLogin.OnDisabledState.IconRightImage = null;
            this.btnLogin.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(226)))));
            this.btnLogin.onHoverState.BorderRadius = 1;
            this.btnLogin.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.onHoverState.BorderThickness = 1;
            this.btnLogin.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(226)))));
            this.btnLogin.onHoverState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.onHoverState.IconLeftImage = null;
            this.btnLogin.onHoverState.IconRightImage = null;
            this.btnLogin.OnIdleState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btnLogin.OnIdleState.BorderRadius = 1;
            this.btnLogin.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnIdleState.BorderThickness = 1;
            this.btnLogin.OnIdleState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(82)))), ((int)(((byte)(204)))));
            this.btnLogin.OnIdleState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.OnIdleState.IconLeftImage = null;
            this.btnLogin.OnIdleState.IconRightImage = null;
            this.btnLogin.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnLogin.OnPressedState.BorderRadius = 1;
            this.btnLogin.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.btnLogin.OnPressedState.BorderThickness = 1;
            this.btnLogin.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(45)))), ((int)(((byte)(112)))));
            this.btnLogin.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.btnLogin.OnPressedState.IconLeftImage = null;
            this.btnLogin.OnPressedState.IconRightImage = null;
            this.btnLogin.Size = new System.Drawing.Size(140, 32);
            this.btnLogin.TabIndex = 112;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnLogin.TextMarginLeft = 0;
            this.btnLogin.TextPadding = new System.Windows.Forms.Padding(0);
            this.btnLogin.UseDefaultRadiusAndThickness = true;
            // 
            // btnNoViewPassword
            // 
            this.btnNoViewPassword.ActiveImage = global::Umoxi.Properties.Resources.icons8_invisible_24px_1;
            this.btnNoViewPassword.AllowAnimations = true;
            this.btnNoViewPassword.AllowBuffering = false;
            this.btnNoViewPassword.AllowToggling = false;
            this.btnNoViewPassword.AllowZooming = true;
            this.btnNoViewPassword.AllowZoomingOnFocus = false;
            this.btnNoViewPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnNoViewPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNoViewPassword.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnNoViewPassword.ErrorImage")));
            this.btnNoViewPassword.FadeWhenInactive = false;
            this.btnNoViewPassword.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnNoViewPassword.Image = global::Umoxi.Properties.Resources.icons8_invisible_24px;
            this.btnNoViewPassword.ImageLocation = null;
            this.btnNoViewPassword.ImageMargin = 3;
            this.btnNoViewPassword.ImageSize = new System.Drawing.Size(20, 20);
            this.btnNoViewPassword.ImageZoomSize = new System.Drawing.Size(23, 23);
            this.btnNoViewPassword.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnNoViewPassword.InitialImage")));
            this.btnNoViewPassword.Location = new System.Drawing.Point(365, 213);
            this.btnNoViewPassword.Name = "btnNoViewPassword";
            this.btnNoViewPassword.Rotation = 0;
            this.btnNoViewPassword.ShowActiveImage = true;
            this.btnNoViewPassword.ShowCursorChanges = true;
            this.btnNoViewPassword.ShowImageBorders = true;
            this.btnNoViewPassword.ShowSizeMarkers = false;
            this.btnNoViewPassword.Size = new System.Drawing.Size(23, 23);
            this.btnNoViewPassword.TabIndex = 111;
            this.btnNoViewPassword.ToolTipText = "";
            this.btnNoViewPassword.WaitOnLoad = false;
            this.btnNoViewPassword.ZoomSpeed = 10;
            // 
            // btnViewPassword
            // 
            this.btnViewPassword.ActiveImage = global::Umoxi.Properties.Resources.icons8_eye_24px_1;
            this.btnViewPassword.AllowAnimations = true;
            this.btnViewPassword.AllowBuffering = false;
            this.btnViewPassword.AllowToggling = false;
            this.btnViewPassword.AllowZooming = true;
            this.btnViewPassword.AllowZoomingOnFocus = false;
            this.btnViewPassword.BackColor = System.Drawing.Color.Transparent;
            this.btnViewPassword.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnViewPassword.ErrorImage = ((System.Drawing.Image)(resources.GetObject("btnViewPassword.ErrorImage")));
            this.btnViewPassword.FadeWhenInactive = false;
            this.btnViewPassword.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.btnViewPassword.Image = global::Umoxi.Properties.Resources.icons8_eye_24px;
            this.btnViewPassword.ImageLocation = null;
            this.btnViewPassword.ImageMargin = 3;
            this.btnViewPassword.ImageSize = new System.Drawing.Size(20, 20);
            this.btnViewPassword.ImageZoomSize = new System.Drawing.Size(23, 23);
            this.btnViewPassword.InitialImage = ((System.Drawing.Image)(resources.GetObject("btnViewPassword.InitialImage")));
            this.btnViewPassword.Location = new System.Drawing.Point(365, 213);
            this.btnViewPassword.Name = "btnViewPassword";
            this.btnViewPassword.Rotation = 0;
            this.btnViewPassword.ShowActiveImage = true;
            this.btnViewPassword.ShowCursorChanges = true;
            this.btnViewPassword.ShowImageBorders = true;
            this.btnViewPassword.ShowSizeMarkers = false;
            this.btnViewPassword.Size = new System.Drawing.Size(23, 23);
            this.btnViewPassword.TabIndex = 109;
            this.btnViewPassword.ToolTipText = "";
            this.btnViewPassword.WaitOnLoad = false;
            this.btnViewPassword.ZoomSpeed = 10;
            // 
            // chkRememberMe
            // 
            this.chkRememberMe.AllowBindingControlAnimation = true;
            this.chkRememberMe.AllowBindingControlColorChanges = false;
            this.chkRememberMe.AllowBindingControlLocation = true;
            this.chkRememberMe.AllowCheckBoxAnimation = false;
            this.chkRememberMe.AllowCheckmarkAnimation = true;
            this.chkRememberMe.AllowOnHoverStates = true;
            this.chkRememberMe.AutoCheck = true;
            this.chkRememberMe.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkRememberMe.BackgroundImage")));
            this.chkRememberMe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.chkRememberMe.BindingControl = this.lbl_chkActive;
            this.chkRememberMe.BindingControlPosition = Bunifu.UI.WinForms.BunifuCheckBox.BindingControlPositions.Right;
            this.chkRememberMe.BorderRadius = 8;
            this.chkRememberMe.Checked = true;
            this.chkRememberMe.CheckState = Bunifu.UI.WinForms.BunifuCheckBox.CheckStates.Checked;
            this.chkRememberMe.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkRememberMe.CustomCheckmarkImage = null;
            this.chkRememberMe.Location = new System.Drawing.Point(49, 272);
            this.chkRememberMe.MinimumSize = new System.Drawing.Size(17, 17);
            this.chkRememberMe.Name = "chkRememberMe";
            this.chkRememberMe.OnCheck.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chkRememberMe.OnCheck.BorderRadius = 8;
            this.chkRememberMe.OnCheck.BorderThickness = 2;
            this.chkRememberMe.OnCheck.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.chkRememberMe.OnCheck.CheckmarkColor = System.Drawing.Color.White;
            this.chkRememberMe.OnCheck.CheckmarkThickness = 2;
            this.chkRememberMe.OnDisable.BorderColor = System.Drawing.Color.LightGray;
            this.chkRememberMe.OnDisable.BorderRadius = 8;
            this.chkRememberMe.OnDisable.BorderThickness = 2;
            this.chkRememberMe.OnDisable.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.OnDisable.CheckmarkColor = System.Drawing.Color.LightGray;
            this.chkRememberMe.OnDisable.CheckmarkThickness = 2;
            this.chkRememberMe.OnHoverChecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(159)))), ((int)(((byte)(123)))));
            this.chkRememberMe.OnHoverChecked.BorderRadius = 8;
            this.chkRememberMe.OnHoverChecked.BorderThickness = 2;
            this.chkRememberMe.OnHoverChecked.CheckBoxColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(159)))), ((int)(((byte)(123)))));
            this.chkRememberMe.OnHoverChecked.CheckmarkColor = System.Drawing.Color.White;
            this.chkRememberMe.OnHoverChecked.CheckmarkThickness = 2;
            this.chkRememberMe.OnHoverUnchecked.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(183)))), ((int)(((byte)(156)))));
            this.chkRememberMe.OnHoverUnchecked.BorderRadius = 8;
            this.chkRememberMe.OnHoverUnchecked.BorderThickness = 1;
            this.chkRememberMe.OnHoverUnchecked.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.OnUncheck.BorderColor = System.Drawing.Color.DarkGray;
            this.chkRememberMe.OnUncheck.BorderRadius = 8;
            this.chkRememberMe.OnUncheck.BorderThickness = 1;
            this.chkRememberMe.OnUncheck.CheckBoxColor = System.Drawing.Color.Transparent;
            this.chkRememberMe.Size = new System.Drawing.Size(21, 21);
            this.chkRememberMe.Style = Bunifu.UI.WinForms.BunifuCheckBox.CheckBoxStyles.Bunifu;
            this.chkRememberMe.TabIndex = 108;
            this.chkRememberMe.ThreeState = false;
            this.chkRememberMe.ToolTipText = null;
            // 
            // txtUserName
            // 
            this.txtUserName.AcceptsReturn = false;
            this.txtUserName.AcceptsTab = false;
            this.txtUserName.AnimationSpeed = 200;
            this.txtUserName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtUserName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtUserName.BackColor = System.Drawing.Color.Transparent;
            this.txtUserName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUserName.BackgroundImage")));
            this.txtUserName.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtUserName.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtUserName.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtUserName.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtUserName.BorderRadius = 10;
            this.txtUserName.BorderThickness = 1;
            this.txtUserName.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultFont = new System.Drawing.Font("Rubik", 9.25F);
            this.txtUserName.DefaultText = "";
            this.txtUserName.FillColor = System.Drawing.Color.White;
            this.txtUserName.HideSelection = true;
            this.txtUserName.IconLeft = global::Umoxi.Properties.Resources.icons8_user_24px;
            this.txtUserName.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.IconPadding = 10;
            this.txtUserName.IconRight = null;
            this.txtUserName.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.Lines = new string[0];
            this.txtUserName.Location = new System.Drawing.Point(49, 150);
            this.txtUserName.MaxLength = 32767;
            this.txtUserName.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtUserName.Modified = false;
            this.txtUserName.Multiline = false;
            this.txtUserName.Name = "txtUserName";
            stateProperties1.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties1.FillColor = System.Drawing.Color.Empty;
            stateProperties1.ForeColor = System.Drawing.Color.Empty;
            stateProperties1.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUserName.OnActiveState = stateProperties1;
            stateProperties2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties2.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtUserName.OnDisabledState = stateProperties2;
            stateProperties3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties3.FillColor = System.Drawing.Color.Empty;
            stateProperties3.ForeColor = System.Drawing.Color.Empty;
            stateProperties3.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUserName.OnHoverState = stateProperties3;
            stateProperties4.BorderColor = System.Drawing.Color.Silver;
            stateProperties4.FillColor = System.Drawing.Color.White;
            stateProperties4.ForeColor = System.Drawing.Color.Empty;
            stateProperties4.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtUserName.OnIdleState = stateProperties4;
            this.txtUserName.Padding = new System.Windows.Forms.Padding(3);
            this.txtUserName.PasswordChar = '\0';
            this.txtUserName.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtUserName.PlaceholderText = "Usuário";
            this.txtUserName.ReadOnly = false;
            this.txtUserName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUserName.SelectedText = "";
            this.txtUserName.SelectionLength = 0;
            this.txtUserName.SelectionStart = 0;
            this.txtUserName.ShortcutsEnabled = true;
            this.txtUserName.Size = new System.Drawing.Size(348, 35);
            this.txtUserName.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtUserName.TabIndex = 106;
            this.txtUserName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtUserName.TextMarginBottom = 0;
            this.txtUserName.TextMarginLeft = 3;
            this.txtUserName.TextMarginTop = 0;
            this.txtUserName.TextPlaceholder = "Usuário";
            this.txtUserName.UseSystemPasswordChar = false;
            this.txtUserName.WordWrap = true;
            // 
            // txtPassword
            // 
            this.txtPassword.AcceptsReturn = false;
            this.txtPassword.AcceptsTab = false;
            this.txtPassword.AnimationSpeed = 200;
            this.txtPassword.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtPassword.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPassword.BackgroundImage")));
            this.txtPassword.BorderColorActive = System.Drawing.Color.DodgerBlue;
            this.txtPassword.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.txtPassword.BorderColorHover = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.txtPassword.BorderColorIdle = System.Drawing.Color.Silver;
            this.txtPassword.BorderRadius = 10;
            this.txtPassword.BorderThickness = 1;
            this.txtPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultFont = new System.Drawing.Font("Rubik", 9.25F);
            this.txtPassword.DefaultText = "";
            this.txtPassword.FillColor = System.Drawing.Color.White;
            this.txtPassword.HideSelection = true;
            this.txtPassword.IconLeft = global::Umoxi.Properties.Resources.icons8_lock_24px_1;
            this.txtPassword.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.IconPadding = 10;
            this.txtPassword.IconRight = null;
            this.txtPassword.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.Lines = new string[0];
            this.txtPassword.Location = new System.Drawing.Point(49, 206);
            this.txtPassword.MaxLength = 32767;
            this.txtPassword.MinimumSize = new System.Drawing.Size(1, 1);
            this.txtPassword.Modified = false;
            this.txtPassword.Multiline = false;
            this.txtPassword.Name = "txtPassword";
            stateProperties5.BorderColor = System.Drawing.Color.DodgerBlue;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.txtPassword.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Silver;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.txtPassword.OnIdleState = stateProperties8;
            this.txtPassword.Padding = new System.Windows.Forms.Padding(3);
            this.txtPassword.PasswordChar = '\0';
            this.txtPassword.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.txtPassword.PlaceholderText = "Palavra-passe";
            this.txtPassword.ReadOnly = false;
            this.txtPassword.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPassword.SelectedText = "";
            this.txtPassword.SelectionLength = 0;
            this.txtPassword.SelectionStart = 0;
            this.txtPassword.ShortcutsEnabled = true;
            this.txtPassword.Size = new System.Drawing.Size(348, 35);
            this.txtPassword.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.txtPassword.TabIndex = 110;
            this.txtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.txtPassword.TextMarginBottom = 0;
            this.txtPassword.TextMarginLeft = 3;
            this.txtPassword.TextMarginTop = 0;
            this.txtPassword.TextPlaceholder = "Palavra-passe";
            this.txtPassword.UseSystemPasswordChar = false;
            this.txtPassword.WordWrap = true;
            // 
            // ChangeUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnNoViewPassword);
            this.Controls.Add(this.btnViewPassword);
            this.Controls.Add(this.chkRememberMe);
            this.Controls.Add(this.lbl_chkActive);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.headerPanel);
            this.Name = "ChangeUser";
            this.Size = new System.Drawing.Size(450, 336);
            ((System.ComponentModel.ISupportInitialize)(this.mvvmContext)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.Utils.MVVM.MVVMContext mvvmContext;
        private Bunifu.UI.WinForms.BunifuImageButton btnNoViewPassword;
        private Bunifu.UI.WinForms.BunifuImageButton btnViewPassword;
        private Bunifu.UI.WinForms.BunifuCheckBox chkRememberMe;
        private Bunifu.UI.WinForms.BunifuLabel lbl_chkActive;
        private Bunifu.UI.WinForms.BunifuTextBox txtUserName;
        private Bunifu.UI.WinForms.BunifuTextBox txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SidePanel headerPanel;
        private DevExpress.XtraEditors.LabelControl headerTextLabel;
        private DevExpress.XtraEditors.SimpleButton closeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton btnLogin;
    }
}
