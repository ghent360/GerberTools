using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GerberCombinerBuilder
{
    public partial class PanelProperties : Form
    {
        private GerberLibrary.GerberPanel ParentPanel;


        public PanelProperties(GerberLibrary.GerberPanel ThePanel)
        {
            InitializeComponent();
            ParentPanel = ThePanel;

            WidthBox.Value = (decimal)ParentPanel.theSet.Width;
            HeightBox.Value = (decimal)ParentPanel.theSet.Height;
            MarginBox.Value = (decimal)ParentPanel.theSet.MarginBetweenBoards;
            ClipToOutlines.Checked = ParentPanel.theSet.ClipToOutlines;
            filloffsetbox.Value = (decimal)ParentPanel.theSet.FillOffset;
            smoothoffsetbox.Value= (decimal)ParentPanel.theSet.Smoothing;
            ExtraTabDrillDistance.Value = (decimal)ParentPanel.theSet.ExtraTabDrillDistance;
            FillEmpty.Checked = ParentPanel.theSet.ConstructNegativePolygon;
            noMouseBites.Checked = ParentPanel.theSet.DoNotGenerateMouseBites;
            mergebyfiletypebox.Checked = ParentPanel.theSet.MergeFileTypes;
        }

        private void OkButton(object sender, EventArgs e)
        {
            ParentPanel.theSet.Width = (double)WidthBox.Value;
            ParentPanel.theSet.Height = (double)HeightBox.Value;
            ParentPanel.theSet.MarginBetweenBoards = (double)MarginBox.Value;
            ParentPanel.theSet.ConstructNegativePolygon = FillEmpty.Checked;
            ParentPanel.theSet.ExtraTabDrillDistance = (double) ExtraTabDrillDistance.Value;
            ParentPanel.theSet.FillOffset = (double)filloffsetbox.Value;
            ParentPanel.theSet.Smoothing = (double)smoothoffsetbox.Value;
            ParentPanel.theSet.DoNotGenerateMouseBites = noMouseBites.Checked;
            ParentPanel.theSet.ClipToOutlines = ClipToOutlines.Checked;
            ParentPanel.theSet.MergeFileTypes = mergebyfiletypebox.Checked;
            Close();
        }

        private void CancelButtonPress(object sender, EventArgs e)
        {
            // cancel
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }
    }
}
