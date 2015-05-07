using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace TemperatureDrawer
{
    public partial class Form1 : Form
    { 
        Dictionary<int, int> dateTemp;
        GraphPane pane;
        ZedGraph.ZedGraphControl zedGraph;
        public Form1()
        {
            DateTempInitial();
            InitializeComponent();
        }
        
        public void SetTemp(string date, string temp)
        {
            int d, t;
            if (Int32.TryParse(date, out d) && Int32.TryParse(temp, out t))
            {
                dateTemp[d]=t;
                DrawGraph();
            }

        }
        public void DateTempInitial()
        {
            dateTemp = new Dictionary<int, int>();
            for (int i = 1; i < 32; i++)
            {
                dateTemp.Add(i, 0);
            }
        }
        public void DrawGraph()
        {
            // Получим панель для рисования

            pane = zedGraph.GraphPane;
            // Очистим список кривых
            pane.CurveList.Clear();

            string[] names = new string[dateTemp.Keys.Count];

            // Высота столбиков
            double[] values = new double[dateTemp.Keys.Count];

            // Заполним данные
            for (int i = 0; i < dateTemp.Keys.Count; i++)
            {
                names[i] = string.Format("{0}", i+1);
                values[i] = (double)dateTemp[i+1];
            }

            // Создадим кривую-гистограмму
            // Первый параметр - название кривой для легенды
            // Второй параметр - значения для оси X, т.к. у нас по этой оси будет идти текст, а функция ожидает тип параметра double[], то пока передаем null
            // Третий параметр - значения для оси Y
            // Четвертый параметр - цвет
            BarItem curve = pane.AddBar("Temperature", null, values, Color.Red);

            // Настроим ось X так, чтобы она отображала текстовые данные
            pane.XAxis.Type = AxisType.Text;

            // Уставим для оси наши подписи
            pane.XAxis.Scale.TextLabels = names;

            pane.XAxis.Title.Text = "Days";
            pane.YAxis.Title.Text = "Temperature";
            pane.Title.Text = "Temperature Calendar";
            // Вызываем метод AxisChange (), чтобы обновить данные об осях. 
            
            zedGraph.AxisChange();

            // Обновляем график
            zedGraph.Invalidate();
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            zedGraph = new ZedGraph.ZedGraphControl();
            zedGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            zedGraph.Location = new System.Drawing.Point(0, 50);
            zedGraph.Name = "zedGraph";
            zedGraph.ScrollGrace = 0D;
            zedGraph.ScrollMaxX = 0D;
            zedGraph.ScrollMaxY = 0D;
            zedGraph.ScrollMaxY2 = 0D;
            zedGraph.ScrollMinX = 0D;
            zedGraph.ScrollMinY = 0D;
            zedGraph.ScrollMinY2 = 0D;
            //zedGraph.Size = this.ClientSize;
            zedGraph.TabIndex = 0;
            Controls.Add(zedGraph);
            DrawGraph(); 
        }

        private void btnSaveGraph_Click(object sender, EventArgs e)
        {
            try
            {
                if (zedGraph != null)
                {
                    Thread t = new Thread(zedGraph.SaveAsBitmap);
                    t.IsBackground = true;
                    t.SetApartmentState (ApartmentState.STA);
                    t.Start();
                    t.Join();
                   // zedGraph.SaveAsBitmap();
                }
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }





       
    }
}
