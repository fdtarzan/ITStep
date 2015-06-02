using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;

namespace GoogleMap
{
    public partial class Form1 : Form
    {
        PointLatLng now;
        PointLatLng start;
        PointLatLng end;
        MapRoute route;
        public Form1()
        {
            
            InitializeComponent();

            gMap.MapProvider = GMapProviders.GoogleMap;
            gMap.Position = new PointLatLng(50.6228133, 26.2568899);
            
            gMap.MinZoom = 2;
            gMap.MaxZoom = 18;
            trackBar1.Minimum = gMap.MinZoom;
            trackBar1.Maximum = gMap.MaxZoom;
            gMap.Zoom = 15;
            trackBar1.Value = (int)gMap.Zoom;
            gMap.DragButton = MouseButtons.Left;
            gMap.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;


            gMap.MarkersEnabled = true;
            gMap.RoutesEnabled = true;




        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = now;
        }

        private void button2_Click(object sender, EventArgs e)
        {
              end = now;
              route = GoogleMapProvider.Instance.GetRoute(start, end, false, false, 15);
              GMapRoute r = new GMapRoute(route.Points, "My route");
              GMapOverlay routesOverlay = new GMapOverlay("routes");
              routesOverlay.Routes.Add(r);
              gMap.Overlays.Add(routesOverlay);

        }

        private void gMap_OnPositionChanged(PointLatLng point)
        {
            now = point;
        }

        private void gMap_OnRouteClick(GMapRoute item, MouseEventArgs e)
        {
            textBox1.Text = item.Name;
        }

        private void gMap_MouseClick(object sender, MouseEventArgs e)
        {
            now = gMap.FromLocalToLatLng(e.X, e.Y);

        }



       
    }
}
