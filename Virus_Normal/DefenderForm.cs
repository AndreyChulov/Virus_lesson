using System.Timers;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Virus_Normal
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

    }
}