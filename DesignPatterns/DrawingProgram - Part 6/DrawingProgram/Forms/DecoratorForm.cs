using System;
using System.Windows.Forms;

namespace DrawingProgram.Forms
{
    public partial class DecoratorForm : Form
    {
        public Shapes.ShapeDecorator.OrnamentPosition position;

        public string Ornament
        {
            get
            {
                return ornamentTextBox.Text;
            }
            set
            {
                ornamentTextBox.Text = value.ToString();
            }
        }
        
        /// <summary>
        /// Get ornament position from the selected radio button.
        /// </summary>
        public void GetPositionFromRadioButton()
        {
            if (radioButtonTop.Checked)
                position = Shapes.ShapeDecorator.OrnamentPosition.top;
            if (radioButtonBottom.Checked)
                position = Shapes.ShapeDecorator.OrnamentPosition.bottom;
            if (radioButtonLeft.Checked)
                position = Shapes.ShapeDecorator.OrnamentPosition.left;
            if (radioButtonRight.Checked)
                position = Shapes.ShapeDecorator.OrnamentPosition.right;
        }

    public DecoratorForm()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            GetPositionFromRadioButton();

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
