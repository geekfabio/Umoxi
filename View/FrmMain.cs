using DevExpress.XtraBars;
using DevExpress.XtraBars.ToolbarForm;
using System;
using System.Collections.Generic;
using DevExpress.XtraBars.Docking2010.Customization;
using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using System.ComponentModel;
using DevExpress.Utils;
using DevExpress.Utils.Colors;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Data.Filtering;
using DevExpress.LookAndFeel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using DevExpress.Skins;
using DevExpress.XtraTab;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using DevExpress.Utils.Drawing;
using System.Xml;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using DevExpress.XtraBars.ToastNotifications;
using Umoxi.Controller;

namespace Umoxi
{
    public partial class FrmMain : ToolbarForm
    {
        public List<TabOpened> dicFormOpened = new List<TabOpened>();
        public string currentFormOpened = "";

        public FrmMain()
        {
            InitializeComponent();
            if (defaultInstance == null)
                defaultInstance = this;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            #region Dashboard
        //    contentControl.Controls.Add(usDashboard.Instance);
           // contentControl.Controls[0].Dock = DockStyle.Fill;
            #endregion
            accordionControlElementAddNewEvent.Expanded=true;
            dateNavigator1.SchedulerControl=usScheduler.Instance.schedulerControl1;
            toastNotificationsManager1.ShowNotification(toastNotificationsManager1.Notifications[0]);
            MemoryManagement memory = new MemoryManagement();
            memory.FlushMemory(); //Limpa os desnecessário da memoria

        }

        #region Default Instance

        private static FrmMain defaultInstance;

        /// <summary>
        /// default instance behavour in C#
        /// </summary>
        public static FrmMain Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmMain();
                    defaultInstance.FormClosed += new FormClosedEventHandler(defaultInstance_FormClosed);
                }

                return defaultInstance;
            }
            set
            {
                defaultInstance = value;
            }
        }

        static void defaultInstance_FormClosed(object sender, FormClosedEventArgs e)
        {
            defaultInstance = null;
        }

        #endregion

        #region Menu click
        private void btnStudent_Click(object sender, EventArgs e)
        {
            filterAllElement = sender as AccordionControlElement;
            if (sender == llStudentInformation)
            {
                StudentInformationToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llMarksEntry)
            {
                MarksEntryToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llIdentityCard)
            {
                IdentityCardToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llFeesCollection)
            {
                FeesCollectionToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llDailyAttendance)
            {
                DailyAttendanceToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llPromotion)
            {
                PromotionImprovementToolStripMenuItem.PerformClick();
            }
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            filterAllElement = sender as AccordionControlElement;
            if (sender == llEmployeeInformation)
            {
                EmployeeInformationToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llSalaryEntry)
            {
                SalaryEntryToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llSalaryPay)
            {
                SalaryPayToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llAttendance)
            {
                AttendanceSummeryToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llDeductions)
            {
                DeductionsToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llAllowances)
            {
                AllowancesToolStripMenuItem.PerformClick();
            }
        }

        private void btnLibrary_Click(object sender, EventArgs e)
        {
            filterAllElement = sender as AccordionControlElement;
            if (sender == llSupplierInformation)
            {
                SupplierInformationToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llBookInformation)
            {
                BookInformationToolStripMenuItem.PerformClick();
            }
          
        }

        private void btnAccounts_Click(object sender, EventArgs e)
        {
            filterAllElement = sender as AccordionControlElement;
            if (sender == llChartOfAccounts)
            {
                OptionsToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llVoucherEntry)
            {
                VoucherEntryToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llVoucherApproval)
            {
                VoucherApprovalToolStripMenuItem.PerformClick();
            }
            else if (sender == this.llVoucherCancel)
            {
                VoucherCancelToolStripMenuItem.PerformClick();
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            filterAllElement = sender as AccordionControlElement;

            if (sender == llUserRegistration)
            {
                OpenTab(usUser.Instance);
            }
            else if (sender == this.llPermission)
            {
                OpenTab(usPermission.Instance);
            }
            else if (sender == this.llUserLog)
            {
                OpenTab(usUserLog.Instance);
            }
        }

        #endregion

        public class TabOpened
        {
            public string name { set; get; }
            public Control UserControl { set; get; }
            public Image image { set; get; }
        }

        #region ChangeControl
        //Change user control and create log
        public void OpenTab(UserControl userControl)
        {
            //formIsActive = userControl.Tag?.ToString();

            if (!dicFormOpened.Exists(x => x.name == currentFormOpened))
            {
                foreach (Control item in contentControl.Controls)
                {
                    if (!string.IsNullOrEmpty(currentFormOpened) && item.Tag?.ToString() == currentFormOpened)
                    {
                        var image = GetImageFromControl(this);
                        var tabOpened = new TabOpened();
                        tabOpened.name = item.Tag.ToString();
                        tabOpened.UserControl = item;
                        tabOpened.image = image;
                        dicFormOpened.Add(tabOpened); ;
                        break;
                    }
                }
            }


            if (!contentControl.Controls.Contains(userControl))
            {
                //OverlayLoading.handle = OverlayLoading.ShowProgressPanel(this);
                //Thread.Sleep(200);
                transitionManager1.StartTransition(contentControl);
                contentControl.Controls.Clear();
                contentControl.Controls.Add(userControl);
                contentControl.Controls[0].Dock = DockStyle.Fill;
                transitionManager1.EndTransition();
                //TabContent.SelectedTabPage = contentControl;
                //TabContent.SelectedTabPage = userControl;

                //OverlayLoading.CloseProgressPanel(OverlayLoading.handle);
            }
            currentFormOpened = userControl.Tag?.ToString();
            //MessageBox.Show(currentFormOpened);
        }
        #endregion

        protected SkinElement GetSeparatorSkinElement(UserLookAndFeel lookAndFeel)
        {
            SkinElement elem = AccordionControlSkins.GetSkin(lookAndFeel.ActiveLookAndFeel)[AccordionControlSkins.SkinSeparator];
            if (elem != null) return elem;
            return CommonSkins.GetSkin(lookAndFeel.ActiveLookAndFeel)[CommonSkins.SkinLabelLine];
        }

        protected void DrawSeparator(GraphicsCache cache, AccordionElementBaseViewInfo elementInfo)
        {
            SkinElement skinElem = GetSeparatorSkinElement(elementInfo.ControlInfo.LookAndFeel);
            Rectangle rect = new Rectangle(elementInfo.HeaderBounds.X, elementInfo.HeaderBounds.Bottom - skinElem.Size.MinSize.Height, elementInfo.HeaderBounds.Width, skinElem.Size.MinSize.Height);
            SkinElementInfo skinElemInfo = new SkinElementInfo(skinElem, rect);
            ObjectPainter.DrawObject(cache, SkinElementPainter.Default, skinElemInfo);
        }

        private void accdMenu_CustomDrawElement(object sender, CustomDrawElementEventArgs e)
        {
            int selectionWidth = 3;
            SkinElement elem = HamburgerMenuSkins.GetSkin(UserLookAndFeel.Default)[HamburgerMenuSkins.SkinItem];

            int _tag = Convert.ToInt32(e.ObjectInfo.Element.Tag);
            if (_tag < 0) return;

            e.Handled = true;

            e.DrawHeaderBackground();
            e.DrawImage();
            e.DrawText();
            if (e.ObjectInfo.Element == filterAllElement)
                e.Cache.FillRectangle(Color.FromArgb(0, 113, 188), new Rectangle(e.ObjectInfo.HeaderBounds.Location, new Size(ScaleHelper.ScaleHorizontal(selectionWidth), e.ObjectInfo.HeaderBounds.Height)));
            //e.Cache.FillRectangle(elem.GetForeColor(ObjectState.Pressed), new Rectangle(e.ObjectInfo.HeaderBounds.Location, new Size(ScaleHelper.ScaleHorizontal(selectionWidth), e.ObjectInfo.HeaderBounds.Height)));

            float x = e.ObjectInfo.HeaderBounds.Width - e.ObjectInfo.HeaderBounds.X - e.ObjectInfo.TextBounds.X;
            float y = e.ObjectInfo.TextBounds.Y;
            Font fn = accdMenu.Appearance.Item.Normal.Font;
            if (_tag == 1)
            {
                int elementTag = e.ObjectInfo.Element.Tag is int ? (int)e.ObjectInfo.Element.Tag : -1;
                ObjectState state = Equals(elementTag, _tag) ? ObjectState.Pressed : ObjectState.Hot;
                //Size
                var bounds = new Rectangle((int)x - 6, (int)y, 20, 17);
                //Color
                var myBrush = new SolidBrush(Color.FromArgb(0, 113, 188));
                //Radius border
                using (GraphicsPath path = RoundedRect(bounds, 4))
                {
                    e.Cache.FillPath(myBrush, path);
                }

                e.Cache.DrawString(dicFormOpened.Count.ToString(), fn, e.Cache.GetSolidBrush(elem.GetForeColor(state)), x, y);

            }
            //if (_tag == 10)
            //    DrawSeparator(e.Cache, e.ObjectInfo);

        }

        AccordionControlElement filterAllElement = null;

        public Bitmap GetImageFromControl(Control control)
        {
            Size ctrlSize = control.Size;
            Rectangle rect = new Rectangle(new Point(0, 0), ctrlSize);
            using (Bitmap bitmap = new Bitmap(ctrlSize.Width, ctrlSize.Height))
            {
                Bitmap captureBitmap = new Bitmap(1024, 768, PixelFormat.Format32bppArgb);
                Rectangle captureRectangle = Screen.AllScreens[0].Bounds;
                Graphics captureGraphics = Graphics.FromImage(captureBitmap);
                captureGraphics.CopyFromScreen(captureRectangle.Left, captureRectangle.Top, 0, 0, captureRectangle.Size);
                return captureBitmap;
            }
        }

        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        private void elementSwitchTab_Click(object sender, EventArgs e)
        {
            if (dicFormOpened.Count > 0)
            {
                gridControl1.DataSource = null;
                gridControl1.RefreshDataSource();
                gridControl1.DataSource = dicFormOpened;
                flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
                flyoutPanel1.Width = this.Width;
                flyoutPanel1.Height = this.Height / 2;
                flyoutPanel1.Hiding += FlyoutPanel1_Hiding;
                OverlayFormShow.Instance.ShowFormOverlay(this);
                flyoutPanel1.ShowPopup();
            }
        }
        private void FlyoutPanel1_Hiding(object sender, FlyoutPanelEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

        private void flyoutPanel1_ButtonClick(object sender, FlyoutPanelButtonClickEventArgs e)
        {
            if (e.Button.Tag.ToString().Equals("close"))
                flyoutPanel1.HidePopup();
        }

        private void layoutView1_CardClick(object sender, DevExpress.XtraGrid.Views.Layout.Events.CardClickEventArgs e)
        {
            switch (layoutView1.FocusedColumn.Name)
            {
                case "colButton":
                    layoutView1.DeleteRow(layoutView1.FocusedRowHandle);
                    break;
                default:
                    var tabSelected = layoutView1.GetRow(e.RowHandle) as TabOpened;

                    flyoutPanel1.HidePopup(true);
                    OverlayFormShow.Instance.CloseProgressPanel();
                    OpenTab(tabSelected.UserControl as UserControl);
                    break;
            }
        }

        #region Links

        private void AboutToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            AboutProgram.Instance.ShowDialog();
        }

        private void LogOffToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {

        }

        private void ExitToolsStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {

        }

        private void DashboardToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDashboard.Instance);
        }

        #region User
        private void UserRegistrationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usUser.Instance);
        }

        private void PermissionToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usPermission.Instance);
        }

        private void UserLogToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usUserLog.Instance);
        }
        #endregion

        #region School
        private void SchoolInformationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usSchool.Instance);
        }

        private void SchoolBusToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBus.Instance);
        }

        private void SessionToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usSession.Instance);
        }

        private void ClassToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usCicle.Instance);
        }

        private void ClassTypeToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usClass.Instance);
        }

        private void ExaminationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usExamination.Instance);
        }

        private void SubjectEntryToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usSubject.Instance);
        }

        private void GradingMakingToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usGrading.Instance);
        }

        private void FeesEntryToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usFees.Instance);
        }

        private void NationalityToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usNationality.Instance);
        }

        private void HolidayDeclarationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usHoliday.Instance);
        }
        #endregion

        #region Student

        private void StudentInformationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usStudent.Instance);
        }

        private void IdentityCardToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usIdentityCard.Instance);
        }

        private void FeesCollectionToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usFeesCollection.Instance);
        }

        private void WaiverToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usWaiver.Instance);
        }

        private void DocumentsToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDocuments.Instance);
        }

        private void DailyAttendanceToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDailyAttendance.Instance);
        }

        private void MarksEntryToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usMarks.Instance);
        }

        private void PromotionImprovementToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usPromotion.Instance);
        }
        #endregion

        #region Employee
        private void EmployeeInformationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usEmployee.Instance);
        }

        private void DepartmentToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDepartment.Instance);
        }

        private void DesignationToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDesignation.Instance);
        }

        private void SalaryEntryToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usSalary.Instance);
        }

        private void SalaryPayToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usSalaryPay.Instance);
        }

        private void AttendanceToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usEmployeeAttendance.Instance);
        }

        private void AllowancesToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usAllowances.Instance);
        }

        private void DeductionsToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usDeductions.Instance);
        }
        #endregion

        #region Books
        private void SupplierInformationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBookSupplier.Instance);
        }

        private void BookInformationToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBooks.Instance);
        }

        private void BookCategoryToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBookCategory.Instance);
        }

        private void BookClassificationToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBookClassification.Instance);
        }

        private void BookIssueToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBookIssue.Instance);
        }

        private void BookReturnToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usBookIssueReturn.Instance);
        }
        #endregion

        #region Accounts
        private void OptionsToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usAccounts.Instance);
        }

        private void VoucherListToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usVoucherList.Instance);
        }

        private void VoucherApprovalToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usVoucherApproval.Instance);
        }

        private void VoucherCancelToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            OpenTab(usVoucherCancel.Instance);
        }

        #endregion

        private void SettingsToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
        }

        private void NewSMSToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
        }

        private void btnLogOff_Click(object sender, ItemClickEventArgs e)
        {
            labelOff.Text = "Exit";
            this.Close();
        }

        private void EmailSentToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            //OpenTab(contentEmail);
        }

        private void ToolStripButtonSchool_Click(object sender, EventArgs e)
        {
            SchoolInformationToolStripMenuItem.PerformClick();
        }
        private void ToolStripButtonStudent_Click(object sender, EventArgs e)
        {
            StudentInformationToolStripMenuItem.PerformClick();
        }

        #endregion

        private static bool canCloseFunc(DialogResult parameter)
        {
            return parameter != DialogResult.Cancel;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
      
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            toastNotificationsManager1.UnregisterApplicationActivator();
        }

        private void AttendanceSummeryToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
        }


        private void toastNotificationsManager1_UpdateToastContent(object sender, UpdateToastContentEventArgs e)
        {
            XmlDocument content = e.ToastContent;
            XmlElement toastElement = content.GetElementsByTagName("toast").OfType<XmlElement>().FirstOrDefault();

            XmlElement actions = content.CreateElement("actions");
            toastElement.AppendChild(actions);

            XmlElement action = content.CreateElement("action");
            //Send button 
            actions.AppendChild(action);
            action.SetAttribute("content", "Ver o registro");
            action.SetAttribute("arguments", "opendetails");
            //Close button 
            //action = content.CreateElement("action");
            //actions.AppendChild(action);
            //action.SetAttribute("content", "Fechar");
            //action.SetAttribute("arguments", "Close");
        }

        private void toastNotificationsManager1_Activated(object sender, ToastNotificationEventArgs e)
        {
            ToastNotificationActivatedEventArgs args = e as ToastNotificationActivatedEventArgs;
            switch (args.Arguments.ToString())
            {
                case "opendetails":
                    //OpenTab(contentUserLog);
                    break;
            }
        }

        private void accordionControlScheduler_Click(object sender, EventArgs e)
        {
            OpenTab(usScheduler.Instance);
        }

        private void accordionControlElementMothView_Click(object sender, EventArgs e)
        {
            usScheduler.Instance.schedulerControl1.ActiveViewType=DevExpress.XtraScheduler.SchedulerViewType.Month;
        }

        private void accordionControlElementDayView_Click(object sender, EventArgs e)
        {
            usScheduler.Instance.schedulerControl1.ActiveViewType=DevExpress.XtraScheduler.SchedulerViewType.Day;
        }

        private void BarcodePrintToolStripMenuItem_Click(object sender, ItemClickEventArgs e)
        {
            BarcodePrintToolStripMenuItem1.PerformClick();
        }


        private void accordionControlElementAddNewEvent_Click(object sender, EventArgs e)
        {
            usScheduler.Instance.schedulerControl1.CreateNewAppointment();
        }

        #region Student reports

        private void AttendanceSummeryToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void PrintIdentityCardToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void StudentInformationToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void StudentLedgerToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void FeesSummeryToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void MarkSheetToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        #endregion

        #region Employee reports
        private void EmployeeListToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void EmployeeLedgerToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        private void DeductionsSummeryToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void AllowancesSummeryToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        #endregion

        #region Books reports
        private void SupplierListToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void BookListToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void BookIssueToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void BarcodePrintToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        #endregion

        #region Accounts reports
        private void ListOfAccountToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void DailyTransactionToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void AccountLedgerToolStripMenuItem_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        #endregion

        #region Userlog report
        private void UserLogToolStripMenuItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }
        #endregion

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }
    }
}