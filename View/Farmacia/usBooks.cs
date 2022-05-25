using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;
using System.Windows.Forms;

namespace Umoxi
{
    public partial class usBooks : UserControl
    {
        public usBooks()
        {
            InitializeComponent();
            LoadData();
            DataGridView1.Columns[8].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            DataGridView1.Columns[9].DefaultCellStyle.Font = new Font("Font Awesome 5 Pro Regular", 12);
            cmbSearchBy.SelectedIndex = 1;
        }

        #region instance
        private static usBooks _instance;

        public static usBooks Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new usBooks();
                return _instance;
            }
        }
        #endregion

        private void LoadData()
        {
            ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
                " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID ";
            ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
            ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
            if (ConnectionNode.sqlDT.Rows.Count > 0)
            {
                lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
            }
            else
            {
                lblTotalBooks.Text = "Book not found.";
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //UtilitiesFunctions.ExportDataToExcelSheet(DataGridView1);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                LoadData();
            }
            else
            {
                switch (cmbSearchBy.Text)
                {
                    case "ID":
                        //search by book id
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                            " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear" +
                            " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                            "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE        (BookInfo.BOOK_ID = " + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + ")";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
                        }
                        else
                        {
                            lblTotalBooks.Text = "Book not found.";
                        }
                        break;
                    //----------------
                    case "Name":
                        //search by book name
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                            " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
                            " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                            "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE  (BookInfo.BookName LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
                        }
                        else
                        {
                            lblTotalBooks.Text = "Book not found.";
                        }
                        break;
                    //----------------
                    case "Supplier":
                        //search by supplier name
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                            " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
                            " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                            "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE  (BookSupplier.Supplier_Name LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
                        }
                        else
                        {
                            lblTotalBooks.Text = "Book not found.";
                        }
                        break;
                    //----------------
                    case "Author":
                        //search by author name
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                            " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
                            " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                            "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE  (BookInfo.Author LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
                        }
                        else
                        {
                            lblTotalBooks.Text = "Book not found.";
                        }
                        break;
                    //----------------
                    #region ISBN
                    /*
                    case "ISBN":
						//search by isbn
						ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
							" BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
							" FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
							"  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE  (BookInfo.ISBN LIKE '%" + System.Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
						ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
						ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
						if (ConnectionNode.sqlDT.Rows.Count > 0)
						{
							lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
						}
						else
						{
							lblTotalBooks.Text = "Book not found.";
						}
						break;
						*/
                    #endregion
                    //----------------
                    case "Barcode":
                        //search by barcode
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, " +
                            " BookCategory.Category_Name, BookInfo.Barcode, BookInfo.PubYear " +
                            " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                            "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID  WHERE  (BookInfo.Barcode LIKE '%" + Convert.ToString(UtilitiesFunctions.str_repl(txtSearch.Text)) + "%') ";
                        ConnectionNode.FillDataGrid(ConnectionNode.sqlString, DataGridView1);
                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            lblTotalBooks.Text = "Total " + Convert.ToString(ConnectionNode.sqlDT.Rows.Count) + " book(s) found.";
                        }
                        else
                        {
                            lblTotalBooks.Text = "Book not found.";
                        }
                        break;
                        //----------------
                }
            }

        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);

            frmAddBooks books = new frmAddBooks();
            using (books)
            {
                books.ShowDialog();
            }
            LoadData();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    #region edit
                    if (MessageBox.Show("Are you sure you want to edit " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, BookClassification.Book_Classf_Type,  " +
                        " BookCategory.Category_Name, BookInfo.ISBN, BookInfo.Barcode, BookInfo.Edition, BookInfo.Volume, BookInfo.Publisher, BookInfo.PubYear, BookInfo.NoOfPages,     BookInfo.BookLocation, BookInfo.CoverType, BookInfo.Price , BookInfo.QtyAvailable " +
                        " , BookInfo.BOOK_CLASSF_ID, BookInfo.BOOK_CAT_ID, BookInfo.BOOK_SUPP_ID,  BookInfo.CoverPhoto " +
                        " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                        "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID WHERE        (BookInfo.BOOK_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ) ";

                        ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                        if (ConnectionNode.sqlDT.Rows.Count > 0)
                        {
                            frmAddBooks books = new frmAddBooks();
                            books.txtBookId.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BOOK_ID"]);
                            books.txtBookName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BookName"]);
                            books.txtSupplierID.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BOOK_SUPP_ID"]);
                            books.dtpEntryDate.DateTime = (DateTime)(ConnectionNode.sqlDT.Rows[0]["EntryDate"]);
                            books.txtISBN.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ISBN"]);
                            books.txtBarcode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Barcode"]);
                            books.txtEdition.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Edition"]);
                            books.txtVolume.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Volume"]);
                            books.txtPublisher.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Publisher"]);
                            books.txtPublishingYear.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PubYear"]);
                            books.txtNoOfPages.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["NoOfPages"]);
                            books.txtBookLocation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BookLocation"]);
                            books.cmbCoverType.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["CoverType"]);
                            books.txtAuthorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Author"]);
                            books.txtPrice.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Price"]);
                            books.txtQtyAvailable.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["QtyAvailable"]);

                            string Supplier_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Supplier_Name"]);
                            double BOOK_CLASSF_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BOOK_CLASSF_ID"]);
                            string Book_Classf_Type = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Book_Classf_Type"]);
                            double BOOK_CAT_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BOOK_CAT_ID"]);
                            string Category_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Category_Name"]);

                            byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["CoverPhoto"]);
                            MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                            books.PictureBox1.Image = Image.FromStream(stmBLOBData);

                            books.cmbClassification.Text = BOOK_CLASSF_ID + " # " + Book_Classf_Type;
                            books.cmbCategory.Text = BOOK_CAT_ID + " # " + Category_Name;

                            books.txtSupplierName.Text = Supplier_Name;
                            books.lstSupplier.Visible = false;

                            books.btnSave.Text = "Update";

                            OverlayFormShow.Instance.ShowFormOverlay(FrmMain.Default);
                            using (books)
                            {
                                books.ShowDialog();
                            }
                            LoadData();

                        }
                    }
                    #endregion
                    break;
                case 1:
                    #region delete
                    if (MessageBox.Show("Are you sure you want to delete " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ? ", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //Delete book form database
                        ConnectionNode.ExecuteSQLQuery(" DELETE BookInfo  WHERE BOOK_ID=" + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + "  ");
                        LoadData();
                        Snackbar.Show(FrmMain.Default, MessageDialog.TextMessage("delete"), BunifuSnackbar.MessageTypes.Success);
                    }
                    #endregion
                    break;
                default:
                    #region view
                    ConnectionNode.sqlString = " SELECT        BookInfo.BOOK_ID, BookInfo.BookName, BookSupplier.Supplier_Name, BookInfo.EntryDate, BookInfo.Author, BookClassification.Book_Classf_Type,  " +
                        " BookCategory.Category_Name, BookInfo.ISBN, BookInfo.Barcode, BookInfo.Edition, BookInfo.Volume, BookInfo.Publisher, BookInfo.PubYear, BookInfo.NoOfPages,     BookInfo.BookLocation, BookInfo.CoverType, BookInfo.Price , BookInfo.QtyAvailable " +
                        " , BookInfo.BOOK_CLASSF_ID, BookInfo.BOOK_CAT_ID, BookInfo.BOOK_SUPP_ID,  BookInfo.CoverPhoto " +
                        " FROM            BookInfo INNER JOIN  BookSupplier ON BookInfo.BOOK_SUPP_ID = BookSupplier.BOOK_SUPP_ID INNER JOIN BookClassification ON BookInfo.BOOK_CLASSF_ID = BookClassification.BOOK_CLASSF_ID INNER JOIN " +
                        "  BookCategory ON BookInfo.BOOK_CAT_ID = BookCategory.BOOK_CAT_ID WHERE        (BookInfo.BOOK_ID = " + Convert.ToString(DataGridView1.CurrentRow.Cells[2].Value) + " ) ";

                    ConnectionNode.ExecuteSQLQuery(ConnectionNode.sqlString);
                    if (ConnectionNode.sqlDT.Rows.Count > 0)
                    {
                        txtBookName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BookName"]);
                        dtpEntryDate.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["EntryDate"]);
                        txtISBN.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["ISBN"]);
                        txtBarcode.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Barcode"]);
                        txtEdition.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Edition"]);
                        txtVolume.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Volume"]);
                        txtPublisher.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Publisher"]);
                        txtPublishingYear.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["PubYear"]);
                        txtNoOfPages.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["NoOfPages"]);
                        txtBookLocation.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["BookLocation"]);
                        cmbCoverType.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["CoverType"]);
                        txtAuthorName.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Author"]);
                        txtPrice.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Price"]);
                        txtQtyAvailable.Text = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["QtyAvailable"]);

                        string Supplier_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Supplier_Name"]);
                        double BOOK_CLASSF_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BOOK_CLASSF_ID"]);
                        string Book_Classf_Type = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Book_Classf_Type"]);
                        double BOOK_CAT_ID = Convert.ToDouble(ConnectionNode.sqlDT.Rows[0]["BOOK_CAT_ID"]);
                        string Category_Name = Convert.ToString(ConnectionNode.sqlDT.Rows[0]["Category_Name"]);

                        byte[] bytBLOBData = (byte[])(ConnectionNode.sqlDT.Rows[0]["CoverPhoto"]);
                        MemoryStream stmBLOBData = new MemoryStream(bytBLOBData);
                        PictureBox1.Image = Image.FromStream(stmBLOBData);

                        cmbClassification.Text = BOOK_CLASSF_ID + " # " + Book_Classf_Type;
                        cmbCategory.Text = BOOK_CAT_ID + " # " + Category_Name;

                        txtSupplierName.Text = Supplier_Name;
                    }
                    #endregion
                    break;
            }
        }

    }
}
