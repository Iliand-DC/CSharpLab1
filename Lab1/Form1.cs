using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Lab1
{
    public partial class Form1 : Form
    {
        int N;
        public Form1()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        { // установка размера матрицы и DataGridView
            int i;
            int scan = 0;
            bool start = Int32.TryParse(textBox1.Text, out scan);
            if (start)
            {
                N = Int32.Parse(textBox1.Text);
                DataTable matr = new DataTable("matr");
                DataColumn[] cols = new DataColumn[N];
                for (i = 0; i < N; i++)
                {
                    cols[i] = new DataColumn(i.ToString());
                    matr.Columns.Add(cols[i]);
                }
                for (i = 0; i < N; i++)
                {
                    DataRow newRow;
                    newRow = matr.NewRow();
                    matr.Rows.Add(newRow);
                }
                dataGridView1.DataSource = matr;
                for (i = 0; i < N; i++)
                    dataGridView1.Columns[i].Width = 50;
            }
        }
        // обработка матрицы
        private void btnStart_Click(object sender, EventArgs e)
        {
            dataGridViewRes.Visible = false;
            MatrMake mt = new MatrMake(N);
            mt.GridToMatrix(dataGridView1);
            int scan = 0;
            bool start = Int32.TryParse(textBox1.Text, out scan);
            if (start)
            {
                int delNumber = Convert.ToInt32(deleteBox.Text);
                if (mt.DelCol(delNumber))
                {
                    dataGridViewRes.Visible = true;
                    mt.MatrixToGrid(dataGridViewRes);
                    MessageBox.Show("Колонка " + delNumber + " удалена.");
                }
                else
                {
                    dataGridViewRes.Visible = true;
                    mt.MatrixToGrid(dataGridViewRes);
                }
            }
        }
    }
}
