using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ViewImages
{
    public partial class Form1 : Form
    {
        private float X;//當前窗體的寬度
        private float Y;//當前窗體的高度
        bool isLoaded;  // 是否已設定各控制的尺寸資料到Tag屬性
        //
        string folder1 = "",folder2 = "", folder3 = "";
        string[] files1, files2, files3;
        string[,] files;
        int[] now = { 0,0,0};
        int[] allnum = { 0,0,0};
        //
        public Form1()
        {
            InitializeComponent();
            isLoaded = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            X = this.Width;//獲取窗體的寬度
            Y = this.Height;//獲取窗體的高度
            isLoaded = true;// 已設定各控制項的尺寸到Tag屬性中
            SetTag(this);//調用方法
        }
        /// <summary>
        /// 將控制項的寬，高，左邊距，頂邊距和字體大小暫存到tag屬性中
        /// </summary>
        /// <param name="cons">遞歸控制項中的控制項</param>
        private void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ":" + con.Height + ":" + con.Left + ":" + con.Top + ":" + con.Font.Size;
                if (con.Controls.Count > 0)
                    SetTag(con);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    if (now[0] <= 0) now[0] = allnum[0];
                    try
                    {
                        pictureBox1.Image = new Bitmap(files1[now[0] - 1]);
                    }
                    catch (Exception ex)
                    {

                    }
                    now[0]--;
                    numericUpDown2.Value = now[0] + 1;
                }

                if (checkBox2.Checked)
                {
                    if (now[1] <= 0) now[1] = allnum[1];
                    try
                    {
                        pictureBox2.Image = new Bitmap(files2[now[1] - 1]);
                    }
                    catch (Exception ex)
                    {

                    }
                    now[1]--;
                    numericUpDown3.Value = now[1] + 1;
                }

                if (checkBox3.Checked)
                {
                    if (now[2] <= 0) now[2] = allnum[2];
                    try
                    {
                        pictureBox3.Image = new Bitmap(files3[now[2] - 1]);
                    }
                    catch (Exception ex)
                    {

                    }
                    now[2]--;
                    numericUpDown4.Value = now[2] + 1;
                }

                GC.Collect();


                //if (now[0] == 0) now[0] = allnum[0];
                //if(now[1] == 0) now[1] = allnum[1];
                //if (now[2] == 0) now[2] = allnum[2];

                //now[0]--;
                //now[1]--;
                //now[2]--;

                //pictureBox1.Image = new Bitmap(files1[now[0]]);
                //pictureBox2.Image = new Bitmap(files2[now[0]]);
                //pictureBox3.Image = new Bitmap(files3[now[0]]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkBox1.Checked)
                {
                    if (now[0] >= allnum[0] - 1) now[0] = -1;
                    try
                    {
                        pictureBox1.Image = new Bitmap(files1[now[0] + 1]);
                    }
                    catch(Exception ex)
                    {
                        
                    }
                    now[0]++;
                    numericUpDown2.Value = now[0] + 1;
                }

                if (checkBox2.Checked)
                {
                    if (now[1] >= allnum[1] - 1) now[1] = -1;
                    try
                    {
                        pictureBox2.Image = new Bitmap(files2[now[1] + 1]);
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    now[1]++;
                    numericUpDown3.Value = now[1] + 1;
                }

                if (checkBox3.Checked)
                {
                    if (now[2] >= allnum[2] - 1) now[2] = -1;
                    try
                    {
                        pictureBox3.Image = new Bitmap(files3[now[2] + 1]);
                    }
                    catch (Exception ex)
                    {
                        
                    }

                    now[2]++;
                    numericUpDown4.Value = now[2] + 1;
                }

                //if (now[0] == allnum[0]-1) now[0] = 0;
                //if (now[1] == allnum[1] - 1) now[1] = 0;
                //if (now[2] == allnum[2] -1) now[2] = 0;

                //now[0]++;
                //now[1]++;
                //now[2]++;

                //pictureBox1.Image = new Bitmap(files1[now[0]]);
                //pictureBox2.Image = new Bitmap(files2[now[1]]);
                //pictureBox3.Image = new Bitmap(files3[now[2]]);

                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked && (int)numericUpDown1.Value != 0)
            {
                if((int)numericUpDown1.Value < allnum[0])
                {

                }
                else
                {

                }
            }
            now[0] = (int)numericUpDown1.Value;
            now[1] = (int)numericUpDown1.Value;
            now[2] = (int)numericUpDown1.Value;

        }

        private void SetControls(float newx, float newy, Control cons)
        {
            if (isLoaded)
            {
                //遍歷窗體中的控制項，重新設置控制項的值
                foreach (Control con in cons.Controls)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[] { ':' });//獲取控制項的Tag屬性值，並分割後存儲字元串數組
                    float a = System.Convert.ToSingle(mytag[0]) * newx;//根據窗體縮放比例確定控制項的值，寬度
                    con.Width = (int)a;//寬度
                    a = System.Convert.ToSingle(mytag[1]) * newy;//高度
                    con.Height = (int)(a);
                    a = System.Convert.ToSingle(mytag[2]) * newx;//左邊距離
                    con.Left = (int)(a);
                    a = System.Convert.ToSingle(mytag[3]) * newy;//上邊緣距離
                    con.Top = (int)(a);
                    //Single currentSize = System.Convert.ToSingle(mytag[4]) * newy;//字體大小
                    //con.Font = new Font(con.Font.Name, currentSize, con.Font.Style, con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx, newy, con);
                    }
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            float xx = this.Width / X;
            float yy = this.Height / Y;
            SetControls(xx,yy,this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(checkBox1.Checked) folder1 = @textBox1.Text;
            if(checkBox2.Checked) folder2 = @textBox2.Text;
            if (checkBox3.Checked)  folder3 = @textBox3.Text;

            //if(!Directory.Exists(folder1) || !Directory.Exists(folder2) || !Directory.Exists(folder3))
            //{
            //    MessageBox.Show("一個以上資料夾不存在");
            //    return;
            //}
            allnum = new int[] { 0,0,0};
            try
            {
                
                if (checkBox1.Checked)
                {
                    folder1 = @textBox1.Text;
                    files1 = Directory.GetFiles(folder1);
                    pictureBox1.Image = new Bitmap(files1[0]);
                    allnum[0] = files1.Length;
                    numericUpDown2.Value = 1;
                }

                if(checkBox2.Checked)
                {
                    folder2 = @textBox2.Text;
                    files2 = Directory.GetFiles(folder2);
                    pictureBox2.Image = new Bitmap(files2[0]);
                    allnum[1] = files2.Length;
                    numericUpDown3.Value = 1;
                }
                
                if(checkBox3.Checked)
                {
                    folder3 = @textBox3.Text;
                    files3 = Directory.GetFiles(folder3);
                    pictureBox3.Image = new Bitmap(files3[0]);
                    allnum[2] = files3.Length;
                    numericUpDown4.Value = 1;
                }

                now = new int[] { 0,0,0};
                //allnum = new int[] { files1.Length, files2.Length, files3.Length};
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
