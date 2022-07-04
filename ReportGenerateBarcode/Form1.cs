using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportGenerateBarcode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.txtCodCategoria.Text = "123456789012";
        }


        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            cleanFields();
            if (validateFields())
            {
                return;
            }
            else {
                string _txtCodProducto = txtCodProducto.Text.Trim();
                string _txtCodCategoria = txtCodCategoria.Text.Trim();
                string _date = DateTime.Now.ToString("MM-yy").Replace("-", "");
                txtBarcode.Text = _txtCodProducto + _txtCodCategoria + _date;
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode();
                Image img = barcode.Encode(BarcodeLib.TYPE.UPCA, txtBarcode.Text, Color.Black, Color.White, 100, 30);
                pictureBox.Image = img;
                this.appData1.Clear();
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, ImageFormat.Png);
                    for (int i = 0; i < quantityBarcode.Value; i++)
                        this.appData1.Barcode.AddBarcodeRow(txtBarcode.Text, ms.ToArray());

                }

                using (frmReport frm = new frmReport(this.appData1.Barcode))
                {
                    frm.ShowDialog();
                }
            }

        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private bool validateFields()
        {
            Boolean checkError = false;
            if (txtCodProducto.Text == "" || txtCodProducto.Text.Length <= 3)
            {
                errorProvider1.SetError(txtCodProducto, "El campo no debe estar vacio, y debe tener 4 dígitos");
                checkError = true;
            }
            if (txtCodCategoria.Text == "" || txtCodCategoria.Text.Length <= 3) {
                errorProvider1.SetError(txtCodCategoria, "El campo no debe estar vacio, y debe tener 4 dígitos");
                checkError = true;
            }
            if (quantityBarcode.Value < 1)
            {
                errorProvider1.SetError(quantityBarcode, "El campo debe ser mayor a 0");
                checkError = true;
            }

            return checkError;
        }

        private void cleanFields(){
            errorProvider1.SetError(txtCodProducto, "");
            errorProvider1.SetError(txtCodCategoria, "");
            errorProvider1.SetError(quantityBarcode, "");
        }



    }
}
