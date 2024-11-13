using System.Windows.Forms;

namespace OrganizacaoFinanceira.Recursos
{
    public static class LayoutColor
    {
        public static Color corLabel = Color.White;
        public static Color backGround = Color.FromArgb(91, 10, 130);

        public static Color corButton = Color.FromArgb(68, 148, 219); // Azul;
        public static Color corTextButton = Color.White;

        public static Color corFundoGrid = Color.FromArgb(239, 113, 205);
        public static Color corHeaderGrid = Color.FromArgb(161, 58, 132);

        public static Color corValorNegativo = Color.Yellow;

        public static void EstiloLayout(Form form)
        {
            form.BackColor = backGround;
            ConfiguracaoControles(form.Controls);
        }

        private static void ConfiguracaoControles(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Label:
                        Label label = (Label)control;
                        label.ForeColor = corLabel;
                        break;

                    case Button:
                        Button button = (Button)control;
                        button.ForeColor = Color.Black;
                        break;

                    case RadioButton:
                        RadioButton radioButton = (RadioButton)control;
                        radioButton.ForeColor = corLabel;
                        break;

                    case GroupBox:
                        GroupBox groupBox = (GroupBox)control;
                        groupBox.ForeColor = corLabel;
                        ConfiguracaoControles(groupBox.Controls);
                        break;

                    case CheckBox:
                        CheckBox checkBox = (CheckBox)control;
                        checkBox.ForeColor = corLabel;
                        break;

                    case DataGridView:
                        DataGridView dataGridView = (DataGridView)control;
                        dataGridView.BackgroundColor = backGround;
                        dataGridView.ForeColor = corLabel;
                        dataGridView.GridColor = corFundoGrid;
                        dataGridView.DefaultCellStyle.BackColor = backGround;
                        dataGridView.BorderStyle = BorderStyle.None;
                        dataGridView.EnableHeadersVisualStyles = false;
                        dataGridView.ColumnHeadersDefaultCellStyle.BackColor = corHeaderGrid;
                        dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = corLabel;
                        dataGridView.RowHeadersDefaultCellStyle.BackColor = corHeaderGrid;
                        break;

                    case MenuStrip:
                        MenuStrip menuStrip = (MenuStrip)control;
                        menuStrip.BackColor = corFundoGrid;
                        menuStrip.ForeColor = corLabel;
                        break;

                    case SplitContainer:
                        SplitContainer splitContainer = (SplitContainer)control;
                        splitContainer.BackColor = backGround;
                        splitContainer.ForeColor = corLabel;
                        splitContainer.SplitterWidth = 15;
                        ConfiguracaoControles(splitContainer.Controls);
                        break;

                    case SplitterPanel:
                        SplitterPanel splitterPanel = (SplitterPanel)control;
                        splitterPanel.BackColor = backGround;
                        splitterPanel.ForeColor = corLabel;
                        ConfiguracaoControles(splitterPanel.Controls);
                        break;

                    case Panel:
                        Panel panel = (Panel)control;
                        panel.BackColor = backGround;
                        panel.ForeColor = corLabel;
                        ConfiguracaoControles(panel.Controls);
                        break;
                }
            }
        }       

    }
}
