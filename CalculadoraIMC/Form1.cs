using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraIMC
{
    public partial class Form1 : Form
    {
        // Método para obter a altura digitada no textBoxHeight e convertê-la em metros
        public double GetHeight()
        {
            // Verifica se o campo de altura não está vazio e se é um valor numérico válido
            if (!string.IsNullOrEmpty(textBoxHeight.Text) && double.TryParse(textBoxHeight.Text, out double height))
                // Retorna a altura convertida para metros
                return (double)Convert.ToDecimal(height) / 100;
            else
                // Se o valor digitado não for válido, lança uma exceção
                throw new FormatException("O valor de altura não é válido.");
        }

        // Método para obter o peso digitado no textBoxWeight
        public double GetWeight()
        {
            // Verifica se o campo de peso não está vazio e se é um valor numérico válido
            if (!string.IsNullOrEmpty(textBoxWeight.Text) && double.TryParse(textBoxWeight.Text, out double weight))
                // Retorna o peso
                return weight;
            else
                // Se o valor digitado não for válido, lança uma exceção
                throw new FormatException("O valor de peso não é válido.");
        }

        // Construtor da classe Form1
        public Form1()
        {
            InitializeComponent();
        }

        // Evento de clique no pictureBox1 (fechar aplicação)
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close(); // Fecha a aplicação
        }

        // Evento de clique no botão de calcular IMC
        private void button1IMC_Click(object sender, EventArgs e)
        {
            try
            {
                // Calcula o IMC usando os métodos GetWeight e GetHeight e exibe o resultado em uma MessageBox
                double result = GetWeight() / (GetHeight() * GetHeight());
                MessageBox.Show($"Vale lembrar que o IMC ideal pode variar de pessoa para pessoa, dependendo da composição corporal e do nível de atividade física. Consultar um profissional de saúde é essencial para uma avaliação personalizada e precisa.", "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Habilita o rótulo que exibirá o resultado do IMC e atribui o valor calculado
                labelResult.Enabled = true;
                labelResult.Text = result.ToString("#.##"); // Formata o resultado com duas casas decimais
            }
            catch (FormatException ex)
            {
                // Em caso de exceção de formato (quando os valores digitados não são válidos), exibe uma mensagem de erro
                MessageBox.Show(ex.Message, "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
