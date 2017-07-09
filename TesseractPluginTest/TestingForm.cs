﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TesseractOCRPlugin;

namespace TesseractPluginTest
{
    public partial class TestingForm : Form
    {

        TesseractOCR TessOCR;
        public TestingForm()
        {
            InitializeComponent();
            TessOCR = new TesseractOCR("eng", TesseractOCR.Quality.High);
            
        }

        private void btnOCRThis_Click(object sender, EventArgs e)
        {
           MessageBox.Show (TessOCR.OCRimage(txtPathToOCR.Text));
        }
    }
}
