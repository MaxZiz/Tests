using BusinessLogicLayer.Implementations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Tests
{
    public partial class Form1 : Form
    {
        private BaseTestService test;
        CancellationTokenSource cts;
        private bool isStarted = false;

        public Form1()
        {
            InitializeComponent();
            foreach (var item in this.Controls) 
            {
                if (item is Button && ((Button)item).Name != "button4") 
                {                   
                       ((Button)item).Click += CommonBtn_Click;
                }
            }
            label1.Text = "Ожидается ввод";
            if (isStarted == false)
            {
                button4.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {     
            test = new FirstTestService(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {         
            test = new SecondTestService(textBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {                   
            test = new ThirdTestService(textBox1.Text);
        }

        private async void EndOfOperation(string text)
        {
            label1.Text = text;
            button4.Enabled = false;
            test.WriteLogs(text);
        }

        private async void CommonBtn_Click(object sender, EventArgs e)
        {
            isStarted = true;
            button4.Enabled=true;
            label1.Text = "Идёт выполнение теста";
            string status="";
            try
            {
                cts = new CancellationTokenSource();
                await test.RunTest(cts);
                status = "Тест завершён успешно" + " :: " + test.GetTypeOfClass();               
            }
            catch (OperationCanceledException)
            {
                status = "Тест завершён пользователем" + " :: " + test.GetTypeOfClass();
                await Task.Delay(2000);
            }
            catch (Exception ex)
            {
                status = $"Произошла ошибка : {ex.Message}" + " :: " + test.GetTypeOfClass();             
            }
            finally
            {
                EndOfOperation(status);
                label1.Text = "Ожидается ввод данных";
            }
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }
    }
}
