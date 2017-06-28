using System;
using System.Windows.Forms;

namespace DrawingProgram
{
    public partial class ResizeShapeForm : Form
    {
        public int ShapeWidth
        {
            get
            {
                return int.Parse(widthText.Text);
            }

            set
            {
                widthText.Text = value.ToString();
            }
        }

        public int ShapeHeight
        {
            get
            {
                return int.Parse(heightText.Text);
            }

            set
            {
                heightText.Text = value.ToString();
            }
        }

        public ResizeShapeForm()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
