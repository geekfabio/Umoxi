using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class frmAddBooks : Form
    {
        public frmAddBooks()
        {
            InitializeComponent();
            LoadData();
            txtBookName.Select();
            lstSupplier.Visible = false;
            this.transitionManager.CustomTransition += TransitionsEffects.TransitionEffect;
            TransitionsEffects.transitionManager = transitionManager;
        }
        private void LoadData()
        {
            ConnectionNode.FILLComboBox("SELECT BOOK_CAT_ID, Category_Name FROM BookCategory", cmbCategory);
            ConnectionNode.FILLComboBox("SELECT BOOK_CLASSF_ID, Book_Classf_Type FROM BookClassification", cmbClassification);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            TransitionsEffects.ResetColor(txtBookName, lblBookName);
            TransitionsEffects.ResetColor(txtSupplierName, lblSupplierID);
            TransitionsEffects.ResetColor(txtPrice, lblPrice);
            TransitionsEffects.ResetColor(txtQtyAvailable, lblQtyAvailable);
            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                TransitionsEffects.ShowTransition(txtBookName, lblBookName);
                Snackbar.Show(FrmMain.Default, "Required: Book", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtSupplierID.Text))
            {
                NavigationBar.SelectedItem = tabInfo;
                Snackbar.Show(FrmMain.Default, "Required: Supplier", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtSupplierName, lblSupplierID);
            }
            else if (string.IsNullOrEmpty(cmbCategory.Text))
            {
                NavigationBar.SelectedItem = tabDetails;
                Snackbar.Show(FrmMain.Default, "Required: Category", BunifuSnackbar.MessageTypes.Error);
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                NavigationBar.SelectedItem = tabDetails;
                Snackbar.Show(FrmMain.Default, "Required: Price", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtPrice, lblPrice);
            }
            else if (string.IsNullOrEmpty(txtQtyAvailable.Text))
            {
                NavigationBar.SelectedItem = tabDetails;
                Snackbar.Show(FrmMain.Default, "Required: qty", BunifuSnackbar.MessageTypes.Error);
                TransitionsEffects.ShowTransition(txtQtyAvailable, lblQtyAvailable);
            }
            else
            {
                switch (btnSave.Text)
                {
                    case "Save":
                        #region save
                        ConnectionNode.ExecuteSQLQuery(" INSERT INTO  BookInfo (BookName, BOOK_SUPP_ID, EntryDate, Author, BOOK_CLASSF_ID, BOOK_CAT_ID, ISBN, Barcode, Edition, Volume, Publisher, PubYear, NoOfPages, BookLocation,  CoverType, Price, QtyAvailable) " + (
                            " VALUES ( '" + UtilitiesFunctions.str_repl(txtBookName.Text) + "', ") + txtSupplierID.Text + " , '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', '" + UtilitiesFunctions.str_repl(txtAuthorName.Text) + "', ") + cmbClassification.Text.Split(" # ".ToCharArray()[0])[0] + ", " + cmbCategory.Text.Split(" # ".ToCharArray()[0])[0] + (", '" + UtilitiesFunctions.str_repl(txtISBN.Text) + "', '" + UtilitiesFunctions.str_repl(txtBarcode.Text) + "',  ") + (
                            " '" + UtilitiesFunctions.str_repl(txtEdition.Text) + "', '" + UtilitiesFunctions.str_repl(txtVolume.Text) + "', '" + UtilitiesFunctions.str_repl(txtPublisher.Text) + "', '" + UtilitiesFunctions.str_repl(txtPublishingYear.Text) + "',  '" + UtilitiesFunctions.str_repl(txtNoOfPages.Text) + "', '" + UtilitiesFunctions.str_repl(txtBookLocation.Text) + "', '" + UtilitiesFunctions.str_repl(cmbCoverType.Text) + "', '" + UtilitiesFunctions.str_repl(txtPrice.Text) + "' , '" + UtilitiesFunctions.str_repl(txtQtyAvailable.Text) + "' )"));
                        //get inserted id
                        ConnectionNode.ExecuteSQLQuery("SELECT   BOOK_ID  FROM   BookInfo  ORDER BY BOOK_ID DESC");
                        double BOOK_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BOOK_ID"]);
                        //update image
                        ConnectionNode.UploadBookCoverPhoto(BOOK_ID, PictureBox1);

                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Livro adicionado # " + txtBookName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Saved"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                    case "Update":
                        #region update
                        ConnectionNode.ExecuteSQLQuery(" UPDATE  BookInfo SET BookName= '" + UtilitiesFunctions.str_repl(txtBookName.Text) + "', BOOK_SUPP_ID= " + txtSupplierID.Text + " , EntryDate= '" + Strings.Format(dtpEntryDate.DateTime, "MM/dd/yyyy") + ("', Author= '" + UtilitiesFunctions.str_repl(txtAuthorName.Text) + "', BOOK_CLASSF_ID= ") + cmbClassification.Text.Split(" # ".ToCharArray()[0])[0] + ", BOOK_CAT_ID= " + cmbCategory.Text.Split(" # ".ToCharArray()[0])[0] + (", ISBN= '" + UtilitiesFunctions.str_repl(txtISBN.Text) + "', Barcode= '" + UtilitiesFunctions.str_repl(txtBarcode.Text) + "',  ") + (
                            " Edition=  '" + UtilitiesFunctions.str_repl(txtEdition.Text) + "', Volume= '" + UtilitiesFunctions.str_repl(txtVolume.Text) + "', Publisher= '" + UtilitiesFunctions.str_repl(txtPublisher.Text) + "', PubYear= '" + UtilitiesFunctions.str_repl(txtPublishingYear.Text) + "', NoOfPages= '" + UtilitiesFunctions.str_repl(txtNoOfPages.Text) + "', BookLocation= '" + UtilitiesFunctions.str_repl(txtBookLocation.Text) + "', CoverType= '" + UtilitiesFunctions.str_repl(cmbCoverType.Text) + "', Price= '" + UtilitiesFunctions.str_repl(txtPrice.Text) + "', QtyAvailable= '" + UtilitiesFunctions.str_repl(txtQtyAvailable.Text) + "' ") +
                            " WHERE  BOOK_ID=" + txtBookId.Text + " ");

                        ConnectionNode.UploadBookCoverPhoto(double.Parse(txtBookId.Text), PictureBox1);

                        UtilitiesFunctions.Logger(ConnectionNode.userID, DateTime.Now.ToLongTimeString(), "Livro atualizado # " + txtBookName.Text);

                        this.Close();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("Update"), BunifuSnackbar.MessageTypes.Success);
                        #endregion
                        break;
                }
            }
        }

        private void btnBrowsePic_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                PictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        private void txtSupplierName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                txtSupplierID.Text = null;
                lstSupplier.Visible = false;
            }
            else
            {
                lstSupplier.Visible = true;
                ConnectionNode.FillListBox("SELECT   BOOK_SUPP_ID, Supplier_Name FROM   BookSupplier WHERE  (Supplier_Name LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSupplierName.Text)) + "%')", lstSupplier);
            }
        }

        private void txtSupplierName_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keydata = e.KeyData;
            if (keydata == Keys.Down)
            {
                if (lstSupplier.Items.Count > 0)
                {
                    lstSupplier.Visible = true;
                    lstSupplier.SelectedIndex = 0;
                    lstSupplier.Select();
                }
            }
        }

        private void txtSupplierName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                lstSupplier.Visible = false;
            }
        }

        private void txtSupplierName_Click(object sender, EventArgs e)
        {
            lstSupplier.Visible = true;
            ConnectionNode.FillListBox("SELECT   BOOK_SUPP_ID, Supplier_Name  FROM   BookSupplier", lstSupplier);
        }

        private void lstSupplier_DoubleClick(object sender, EventArgs e)
        {
            if (lstSupplier.Items.Count > 0)
            {
                txtSupplierID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstSupplier.SelectedItem), " # ")[0]);
                txtSupplierName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstSupplier.SelectedItem), " # ")[1]);
                lstSupplier.Visible = false;
                dtpEntryDate.Select();
            }
        }

        private void lstSupplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.ChrW((int)Keys.Enter))
            {
                if (lstSupplier.Items.Count > 0)
                {
                    txtSupplierID.Text = Convert.ToString(Strings.Split(Convert.ToString(lstSupplier.SelectedItem), " # ")[0]);
                    txtSupplierName.Text = Convert.ToString(Strings.Split(Convert.ToString(lstSupplier.SelectedItem), " # ")[1]);
                    lstSupplier.Visible = false;
                    dtpEntryDate.Select();
                }
            }
        }

        private void NavigationBar_SelectedItemChanged(object sender, DevExpress.XtraBars.Navigation.NavigationBarItemEventArgs e)
        {
            if (NavigationBar.SelectedItem == tabInfo)
            {
                TabContent.SelectedTabPage = Page1;
            }
            else if (NavigationBar.SelectedItem == tabDetails)
            {
                TabContent.SelectedTabPage = Page2;
            }
        }

        private void frmAddBooks_FormClosed(object sender, FormClosedEventArgs e)
        {
            OverlayFormShow.Instance.CloseProgressPanel();
        }

    }
}
