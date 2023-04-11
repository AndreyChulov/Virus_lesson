using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Virus_Hard
{
    public partial class DefenderForm : Form
    {
        private int _formIndex;
        public string FormCaption => nameof(DefenderForm) + _formIndex.ToString();

        public DefenderForm(int formIndex)
        {
            _formIndex = formIndex;
            
            InitializeComponent();

            Text = FormCaption;
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // DefenderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "DefenderForm";
            this.Text = "DefenderForm";
            this.ResumeLayout(false);
        }

        #endregion
    }
}