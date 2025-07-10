using S7.Net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboyKontrol1
{

    public partial class Form1 : Form
    {
        private Plc plc=null;
        public Form1()
        {
            //plc = new Plc(CpuType.S71200, "192.168.0.1", 0, 1);
            //plc.Open();
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = Convert.ToDouble(textBoxTH1.Text);

            double teta2 = Convert.ToDouble(textBoxTH2.Text);
            double teta3 = Convert.ToDouble(textBoxTH3.Text);

            listBoxControl1.Items.Add("TH1:" +textBoxTH1);
            listBoxControl1.Items.Add("TH2:" +textBoxTH2);
            listBoxControl1.Items.Add("TH3:" +textBoxTH3);
           
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };





            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)

            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(sonucmatr[i, j] + "\t");


                }
                Console.WriteLine();


            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)

            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(tamsonuc[i, j] + "\t");


                }
                Console.WriteLine();


            }
            Console.WriteLine();
            for (int i = 0; i < 4; i++)

            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(kesınsonuc[i, j] + "\t");


                }
                Console.WriteLine();



            }



            double px = kesınsonuc[0, 3];
            double py = kesınsonuc[1, 3];
            double pz = kesınsonuc[2, 3];

            textBoxPX.Text=Convert.ToString(px);
            textBoxPY.Text=Convert.ToString(py);
            textBoxPZ.Text=Convert.ToString(pz);

            listBoxControl1.Items.Add("Px"+textBoxPX);
            listBoxControl1.Items.Add("Py"+textBoxPY);
            listBoxControl1.Items.Add("Pz"+textBoxPZ);


        }

        private void button2_Click(object sender, EventArgs e)
        {

           
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double pex = Convert.ToDouble(textBoxPX.Text);
            double pey = Convert.ToDouble(textBoxPY.Text);
            double pez = Convert.ToDouble(textBoxPZ.Text);

            listBoxControl1.Items.Add("Px" + textBoxPX);
            listBoxControl1.Items.Add("Py" + textBoxPY);
            listBoxControl1.Items.Add("Pz" + textBoxPZ);

            Console.WriteLine();
            double q1artıy = Math.Atan2(pey, pex);
            double q1artıxy = Math.Atan2(pey, pex);
            double q3eksiy = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2)) * ((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            double q3artıxy = (Math.Atan2(Math.Sqrt(1 - (((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2)) * ((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((pex * pex) + (pey * pey) + ((pez - h1) * (pez - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            double q2eksiy = (Math.Atan2(((l2 * Math.Sin(q3eksiy))), (l1 + (l2 * Math.Cos(q3eksiy)))) - Math.Atan2((pez - h1), (Math.Sqrt((pex * pex) + (pey * pey)))));
            double q2eksixy = (Math.Atan2(((l2 * Math.Sin(q3artıxy))), (l1 + (l2 * Math.Cos(q3artıxy)))) - Math.Atan2((pez - h1), (Math.Sqrt((pex * pex) + (pey * pey)))));

            double q2artıy = -Math.Atan2((Math.Sqrt((pex * pex) + (pey * pey))), (pez - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksiy))), ((l2 * Math.Sin(q3eksiy))));
            double q2artıxy = -(Math.Atan2(((l2 * Math.Sin(q3artıxy))), (l1 + (l2 * Math.Cos(q3artıxy)))) - Math.Atan2((pez - h1), (Math.Sqrt((pex * pex) + (pey * pey)))));
            
            textBoxTH1.Text =Convert.ToString(q1artıy);

            textBoxTH2.Text = Convert.ToString(q2artıxy);

            textBoxTH3.Text = Convert.ToString(q3artıxy);

            listBoxControl1.Items.Add("TH1:" + textBoxTH1);
            listBoxControl1.Items.Add("TH2:" + textBoxTH2);
            listBoxControl1.Items.Add("TH3:" + textBoxTH3);

        }

        private void buttonArtır_Click(object sender, EventArgs e)
        {
            double click = 0.1;

            if(checkBoxPX.Checked)
            {
                textBoxPX.Text =Convert.ToString( Convert.ToDouble(textBoxPX.Text)+click);
            }
            if (checkBoxPY.Checked)
            {
                textBoxPY.Text = Convert.ToString(Convert.ToDouble(textBoxPY.Text) + click);
            }
            if (checkBoxPZ.Checked)
            {
                textBoxPZ.Text = Convert.ToString(Convert.ToDouble(textBoxPZ.Text) + click);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double click = 0.1;

            if (checkBoxPX.Checked)
            {
                textBoxPX.Text = Convert.ToString(Convert.ToDouble(textBoxPX.Text) - click);
            }
            if (checkBoxPY.Checked)
            {
                textBoxPY.Text = Convert.ToString(Convert.ToDouble(textBoxPY.Text) - click);
            }
            if (checkBoxPZ.Checked)
            {
                textBoxPZ.Text = Convert.ToString(Convert.ToDouble(textBoxPZ.Text) - click);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double click = 0.1;

            if (checkBoxTH1.Checked)
            {
                textBoxTH1.Text = Convert.ToString(Convert.ToDouble(textBoxTH1.Text) + click);
            }
            if (checkBoxTH2.Checked)
            {
                textBoxTH2.Text = Convert.ToString(Convert.ToDouble(textBoxTH2.Text) + click);
            }
            if (checkBoxTH3.Checked)
            {
                textBoxTH3.Text = Convert.ToString(Convert.ToDouble(textBoxTH3.Text) + click);
            }
        }

        private void buttonTHazalt_Click(object sender, EventArgs e)
        {
            double click = 0.1;

            if (checkBoxTH1.Checked)
            {
                textBoxTH1.Text = Convert.ToString(Convert.ToDouble(textBoxTH1.Text) - click);
            }
            if (checkBoxTH2.Checked)
            {
                textBoxTH2.Text = Convert.ToString(Convert.ToDouble(textBoxTH2.Text) - click);
            }
            if (checkBoxTH3.Checked)
            {
                textBoxTH3.Text = Convert.ToString(Convert.ToDouble(textBoxTH3.Text) - click);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBoxControl1.Items.Clear();
        }

        private void buttonZartı_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };





            
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }
            
            

            double click1= 0.0;
            click1 += 0.1;
            double px = kesınsonuc[0, 3];
            double py = kesınsonuc[1, 3];
            double pz = kesınsonuc[2, 3]+click1;
                
            
            textBoxmanuelPX.Text =Convert.ToString(px);
            textBoxmanuelPY.Text =Convert.ToString(py);
            textBoxmanuelPZ.Text =Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);
           
            //double[] acılar = new double[3];
            //double[] tta2 = { q2artı, q2artıx, q2eksi, q2eksix };
            //for (int i = 0; i < 4; i++)
            //{
            //    if (teta2 - 0.10 <= tta2[i] && tta2[i] <= teta2 + 0.10)
            //    {
            //        acılar[1] = Convert.ToDouble(tta2[i]);
            //    }
            //}
            //double[] tta3 = { q3eksi, q3artıx };
            //for (int i = 0; i < 2; i++)
            //{
            //    if (teta3 - 0.10 <= tta3[i] && tta3[i] <= teta3 + 0.10)
            //    {
            //        acılar[2] = Convert.ToDouble(tta3[i]);
            //    }
            //}

            //if (teta1 - 0.10 <= q1artı && q1artı <= teta1 + 0.10)
            //{
            //    acılar[0] = Convert.ToDouble(q1artı);
            //}


        }

        private void buttonZeksi_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };






            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }



            double click = 0.1;

            double px = kesınsonuc[0, 3];
            double py = kesınsonuc[1, 3];
            double pz = kesınsonuc[2, 3] - click;

            textBoxmanuelPX.Text = Convert.ToString(px);
            textBoxmanuelPY.Text = Convert.ToString(py);
            textBoxmanuelPZ.Text = Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);

        }

        private void buttonXartı_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };






            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }



            double click = 0.1;

            double px = kesınsonuc[0, 3] +click;
            double py = kesınsonuc[1, 3];
            double pz = kesınsonuc[2, 3];

            textBoxmanuelPX.Text = Convert.ToString(px);
            textBoxmanuelPY.Text = Convert.ToString(py);
            textBoxmanuelPZ.Text = Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);

        }

        private void buttonXeksi_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };






            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }



            double click = 0.0;
            click += 0.1;
            double px = kesınsonuc[0, 3]-click;
            double py = kesınsonuc[1, 3];
            double pz = kesınsonuc[2, 3];

            textBoxmanuelPX.Text = Convert.ToString(px);
            textBoxmanuelPY.Text = Convert.ToString(py);
            textBoxmanuelPZ.Text = Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);

        }

        private void buttonYArtı_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };






            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }


        

            double click = 0.1;

            double px = kesınsonuc[0, 3];
            double py = kesınsonuc[1, 3]+click;
            double pz = kesınsonuc[2, 3];

            textBoxmanuelPX.Text = Convert.ToString(px);
            textBoxmanuelPY.Text = Convert.ToString(py);
            textBoxmanuelPZ.Text = Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);
        }

        private void buttonYeksi_Click(object sender, EventArgs e)
        {
            double q1artı;
            double q1artıx;
            double q3eksi;
            double q3artıx;
            double q2eksi;
            double q2eksix;
            double q2artı;
            double q2artıx;
            int l3 = 0;
            int l2 = 50;
            int l1 = 50;
            int h1 = 20;
            double teta1 = 1.0;

            double teta2 = 0.78;
            double teta3 = 0.48;
            Console.WriteLine();
            Console.WriteLine(teta1);
            Console.WriteLine(teta2);
            Console.WriteLine(teta3);
            Console.WriteLine();
            // DH tablosu
            double[] alpha = { Math.PI / 2, 0, 0, 0 };
            double[] a = { 0, l1, l2, l3 };
            double[] d = { h1, 0, 0, 0 };
            double[] teta = { teta1, teta2, teta3, 0 };

            double[,] sonucmatr = new double[4, 4];

            double[,] tamsonuc = new double[4, 4];

            double[,] kesınsonuc = new double[4, 4];

            double[,] matr0 = { { Math.Cos(teta[0]), -Math.Sin(teta[0])*Math.Cos(alpha[0]), Math.Sin(teta[0])*Math.Sin(alpha[0]), a[0]*Math.Cos(teta[0])},
                                {Math.Sin(teta[0]),Math.Cos(teta[0])*Math.Cos(alpha[0]),-Math.Sin(alpha[0])*Math.Cos(teta[0]),a[0]*Math.Sin(teta[0])},
                                {0,Math.Sin(alpha[0]),Math.Cos(alpha[0]),d[0]},
                                {0,0,0,1 }
                               };





            double[,] matr1 = { { Math.Cos(teta[1]), -Math.Sin(teta[1])*Math.Cos(alpha[1]), Math.Sin(teta[1])*Math.Sin(alpha[1]), a[1]*Math.Cos(teta[1])},
                                {Math.Sin(teta[1]),Math.Cos(teta[1])*Math.Cos(alpha[1]),-Math.Sin(alpha[1])*Math.Cos(teta[1]),a[1]*Math.Sin(teta[1])},
                                {0,Math.Sin(alpha[1]),Math.Cos(alpha[1]),d[1]},
                                {0,0,0,1 }
                               };
            double[,] matr2 = { { Math.Cos(teta[2]), -Math.Sin(teta[2])*Math.Cos(alpha[2]), Math.Sin(teta[2])*Math.Sin(alpha[2]), a[2]*Math.Cos(teta[2])},
                                {Math.Sin(teta[2]),Math.Cos(teta[2])*Math.Cos(alpha[2]),-Math.Sin(alpha[2])*Math.Cos(teta[2]),a[2]*Math.Sin(teta[2])},
                                {0,Math.Sin(alpha[2]),Math.Cos(alpha[2]),d[2]},
                                {0,0,0,1 }
                               };
            double[,] matr3 = { { Math.Cos(teta[3]), -Math.Sin(teta[3])*Math.Cos(alpha[3]), Math.Sin(teta[3])*Math.Sin(alpha[3]), a[3]*Math.Cos(teta[3])},
                                {Math.Sin(teta[3]),Math.Cos(teta[3])*Math.Cos(alpha[3]),-Math.Sin(alpha[3])*Math.Cos(teta[3]),a[3]*Math.Sin(teta[3])},
                                {0,Math.Sin(alpha[3]),Math.Cos(alpha[3]),d[3]},
                                {0,0,0,1 }
                               };






            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş]; ;
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                sonucmatr[j, ş] += matr0[j, i] * matr1[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                tamsonuc[j, ş] += matr2[j, i] * matr3[i, ş];
                            }

                        }

                    }

                }
            }
            for (int ş = 0; ş < 4; ş++)
            {
                if (ş == 0)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 1)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];


                            }

                        }

                    }
                }
                if (ş == 2)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }
                }
                if (ş == 3)
                {

                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 1)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 2)
                        {
                            for (int i = 0; i < 4; i++)
                            {


                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }
                        }
                        if (j == 3)
                        {
                            for (int i = 0; i < 4; i++)
                            {

                                kesınsonuc[j, ş] += sonucmatr[j, i] * tamsonuc[i, ş];
                            }

                        }

                    }

                }
            }



            double click = 0.1;

            double px = kesınsonuc[0, 3];
            double py = kesınsonuc[1, 3]-click;
            double pz = kesınsonuc[2, 3];

            textBoxmanuelPX.Text = Convert.ToString(px);
            textBoxmanuelPY.Text = Convert.ToString(py);
            textBoxmanuelPZ.Text = Convert.ToString(pz);

            Console.WriteLine();
            q1artı = Math.Atan2(py, px);
            q1artıx = Math.Atan2(py, px);
            q3eksi = Math.PI - (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), -(((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));

            q3artıx = (Math.Atan2(Math.Sqrt(1 - (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) * ((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2))) / ((2 * l1 * l2) * (2 * l1 * l2))), (((px * px) + (py * py) + ((pz - h1) * (pz - h1)) - (l1 * l1) - (l2 * l2)) / (2 * l1 * l2))));
            q2eksi = (Math.Atan2(((l2 * Math.Sin(q3eksi))), (l1 + (l2 * Math.Cos(q3eksi)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));
            q2eksix = (Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            q2artı = -Math.Atan2((Math.Sqrt((px * px) + (py * py))), (pz - h1)) - Math.Atan2(l1 + ((l2 * Math.Cos(q3eksi))), ((l2 * Math.Sin(q3eksi))));
            q2artıx = -(Math.Atan2(((l2 * Math.Sin(q3artıx))), (l1 + (l2 * Math.Cos(q3artıx)))) - Math.Atan2((pz - h1), (Math.Sqrt((px * px) + (py * py)))));

            textBoxmanuelTH1.Text = Convert.ToString(q1artı);
            textBoxmanuelTH2.Text = Convert.ToString(q2artıx);
            textBoxmanuelTH3.Text = Convert.ToString(q3artıx);
        }
    }
}
