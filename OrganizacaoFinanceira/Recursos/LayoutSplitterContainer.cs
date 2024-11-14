using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizacaoFinanceira.Recursos
{
    internal class LayoutSplitterContainer
    {
        public void DesenharLinhaDivisoria(SplitContainer splitContainer, PaintEventArgs e)
        {
            splitContainer.BackColor = Color.Black;

            // Cria uma caneta com a cor desejada
            using (Pen pen = new Pen(Color.Black, splitContainer.SplitterWidth))
            {
                // Verifica a orientação do SplitContainer e desenha a linha adequadamente
                if (splitContainer.Orientation == Orientation.Vertical)
                {
                    // Linha vertical
                    int x = splitContainer.SplitterDistance + (splitContainer.SplitterWidth / 2);
                    e.Graphics.DrawLine(pen, x, 0, x, splitContainer.Height);
                }
                else
                {
                    // Linha horizontal
                    int y = splitContainer.SplitterDistance + (splitContainer.SplitterWidth / 2);
                    e.Graphics.DrawLine(pen, 0, y, splitContainer.Width, y);
                }
            }
        }

        public void PintarPainelComBordasArredondadas(Panel panel, PaintEventArgs e)
        {
            // Define o retângulo para o painel
            Rectangle panelRect = panel.ClientRectangle;

            // Cria o caminho com bordas arredondadas
            using (GraphicsPath path = RoundedRect(panelRect, 30))
            {
                // Preenche o painel com a cor especificada
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(91, 10, 130)))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

        // Método auxiliar para criar um retângulo com bordas arredondadas
        private GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            // Top left arc
            path.AddArc(arc, 180, 90);

            // Top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        public void ExibirLinhaDivisoria(SplitContainer splitContainer)
        {
            splitContainer.SplitterWidth = 4;
        }

        public void DiminuirLinhaDivisoria(SplitContainer splitContainer)
        {
            splitContainer.SplitterWidth = 3;
        }
    }
}
