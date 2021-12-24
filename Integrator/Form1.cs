using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integrator
{
    public partial class Form1 : Form
    {
        private IExpressionFactory expression_factory_;

        public Form1()
        {
            expression_factory_ = new ExpressionFactory();
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            double a = 0, b = 0, dx = 0, result = 0;

            try {
                a = double.Parse(textBox2.Text);
                b = double.Parse(textBox3.Text);
                dx = double.Parse(textBox4.Text);
            } catch (Exception ex) {
                MessageBox.Show("Поля формы были заполнены неправильно или были пусты.\n\n" + ex.Message, "Ошибка");
                return;
            }

            try {
                IExpressionIntegrator integrator = new ExpressionIntegrator(expression_factory_.Create(textBox1.Text));
                try {
                    result = integrator.Integrate(a, b, dx);
                } catch (Exception ex) {
                    MessageBox.Show("Ошибка вычисления, проверьте правильность выражения.\n\n" + ex.Message, "Ошибка");
                    return;
                }
            } catch(Exception ex) {
                MessageBox.Show("Ошибка парсинга, проверьте правильность выражения.\n\n " + ex.Message, "Ошибка");
                return;
            }

            label1.Text = result.ToString();
        }
    }
}
