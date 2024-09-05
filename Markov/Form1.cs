using System.Numerics;

namespace Markov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void resolver_Click(object sender, EventArgs e)
        {
            #region Matrices 
            double[,] matriz = new double[3, 3];
            matriz[0, 0] = double.Parse(n1.Text);
            matriz[0, 1] = double.Parse(n4.Text);
            matriz[0, 2] = double.Parse(n7.Text);
            matriz[1, 0] = double.Parse(n2.Text);
            matriz[1, 1] = double.Parse(n5.Text);
            matriz[1, 2] = double.Parse(n8.Text);
            matriz[2, 0] = double.Parse(n3.Text);
            matriz[2, 1] = double.Parse(n6.Text);
            matriz[2, 2] = double.Parse(n9.Text);

            double[] percentajes = new double[3];
            percentajes[0] = double.Parse(n10.Text);
            percentajes[1] = double.Parse(n11.Text);
            percentajes[2] = double.Parse(n12.Text);

            #endregion


            if (!ValidarSuma(matriz))
            {
                MessageBox.Show("Las columnas no suman 1. Se utilizará la matriz transpuesta.");
                matriz = Transpuesta(matriz);
            }

            int iteraciones = int.Parse(veces.Text);

            double[] resultado = percentajes;
            for (int i = 0; i < iteraciones; i++)
            {
                resultado = MultiplyMatrices(matriz, resultado);
            }

            string resMensaje = $"Resultado: [{string.Join(", ", resultado)}]";
            res.Text = resMensaje;
        }

        private bool ValidarSuma(double[,] matriz)
        {
            for (int j = 0; j < 3; j++)
            {
                double suma = 0;
                for (int i = 0; i < 3; i++)
                {
                    suma += matriz[i, j];
                }
                if (suma != 1)
                {
                    return false;
                }
            }
            return true;
        }

        private double[,] Transpuesta(double[,] matriz)
        {
            double[,] transpuesta = new double[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    transpuesta[j, i] = matriz[i, j];
                }
            }
            return transpuesta;
        }

        private double[] MultiplyMatrices(double[,] matriz, double[] percentajes)
        {
            double[] resultado = new double[3];
            for (int i = 0; i < 3; i++)
            {
                resultado[i] = 0;
                for (int j = 0; j < 3; j++)
                {
                    resultado[i] += matriz[i, j] * percentajes[j];
                }
            }
            return resultado;
        }

        private void reiniciar_Click(object sender, EventArgs e)
        {
            n1.Text = "";
            n2.Text = "";
            n3.Text = "";
            n4.Text = "";
            n5.Text = "";
            n6.Text = "";
            n7.Text = "";
            n8.Text = "";
            n9.Text = "";
            n10.Text = "";
            n11.Text = "";
            n12.Text = "";
            veces.Text = "";


            res.Clear();
        }
    }
}
