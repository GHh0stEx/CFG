using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlFlowGraph;
using System.IO;

namespace TestApp
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();

            #region Graph
            graph = new CFGraph(PB_Graph, 40);

            graph.AddNode("L", new PointF(50, 20));
            graph.AddNode("W", new PointF(10, 80));
            graph.AddNode("A", new PointF(50, 140));
            graph.AddNode("C", new PointF(90, 80));
            graph.AddNode("F", new PointF(150, 20));
            graph.AddNode("G", new PointF(150, 100));
            graph.AddNode("H", new PointF(150, 200));
            graph.AddNode("J", new PointF(150, 280));
            graph.AddNode("K", new PointF(240, 20));
            graph.AddNode("P", new PointF(280, 100));
            graph.AddNode("N", new PointF(280, 200));
            graph.AddNode("M", new PointF(240, 280));

            graph.AddConnectionLine("L", "W");
            graph.AddConnectionLine("L", "C");
            graph.AddConnectionLine("W", "A");
            graph.AddConnectionLine("C", "A");
            graph.AddConnectionCurve("F", "G", ConnectionSide.Right);
            graph.AddConnectionCurve("H", "J", ConnectionSide.Left);
            graph.AddConnectionCurve("P", "K", ConnectionSide.Right);
            graph.AddConnectionCurve("K", "P", ConnectionSide.Left);
            graph.AddConnectionCurve("H", "F", ConnectionSide.Right);
            graph.AddConnectionCurve("M", "N", ConnectionSide.Left);
            graph.AddConnectionCurve("N", "M", ConnectionSide.Right);
            graph.AddConnectionCurve("G", "J", ConnectionSide.Left);

            graph.EndOfDraw();
            #endregion

            #region Code
            StreamReader sr = new StreamReader("ccode.txt");
            string code = sr.ReadToEnd();
            sr.Dispose();
            int offsetV = 40;

            master = new ProgramTextMaster(PB_Code, code, new ProgramTextBrushes(Brushes.Black, Brushes.DarkRed, Brushes.DarkGray));
            master.CreateProgramText(offsetV);
            #endregion
        }


        private ProgramTextMaster master;
        private CFGraph graph;


        private void TestForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            graph.Dispose();
            master.Dispose();
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            master.SaveToBitmap(Environment.CurrentDirectory, "programCode.jpg");
        }
    }
}
