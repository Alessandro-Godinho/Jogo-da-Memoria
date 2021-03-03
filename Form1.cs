using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
namespace Memoria
{
    public partial class Form1 : Form
    {
        List<Cores.Cor> Colors = new List<Cores.Cor>();
        List<Button> Botoes = new List<Button>();
        List<Object> GravarCorNaLista = new List<Object>();
        ArrayList Caixa1 = new ArrayList();
        ArrayList Caixa2 = new ArrayList();

        int  k = 0, aux;
        Color cor_Par = Color.White;
        bool mostrarCores;
        public Form1()
        {
            InitializeComponent();

            PreencherCores();
            
            foreach(var botao in  this.Controls)
            {
                if(botao is Button)
                {
                    Button botaoAuxiliar = (Button)botao;
                    if(botaoAuxiliar.Text.StartsWith(" "))
                    {
                        Botoes.Add(botaoAuxiliar);
                        GravarCorNaLista.Add(botaoAuxiliar);
                    }
                }
            }
        }

        private void PreencherCores()
        {
            foreach (Cores.Cor cor in Enum.GetValues(typeof(Cores.Cor)))
            {
                Colors.Add(cor);
            }
        }
        public void Sorteio(ArrayList caixa)
        {
            while (Colors.Count > 0)
            {
                Cores.Cor cor;
                do
                {
                    cor = Sortear();
                }   while (!Colors.Contains(cor));
                switch (cor)
                {
                    case Cores.Cor.Vermelho:
                        Botoes[k].BackColor = Color.Red;
                        GravarCorNaLista[k] = Color.Red;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Amarelo:

                        Botoes[k].BackColor = Color.Yellow;
                        GravarCorNaLista[k] = Color.Yellow;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Preto:
                        Botoes[k].BackColor = Color.Black;
                        GravarCorNaLista[k] = Color.Black;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Azul:

                        Botoes[k].BackColor = Color.Blue;
                        GravarCorNaLista[k] = Color.Blue;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Laranja:

                        Botoes[k].BackColor = Color.Orange;
                        GravarCorNaLista[k] = Color.Orange;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Magenta:
                        Botoes[k].BackColor = Color.Magenta;
                        GravarCorNaLista[k] = Color.Magenta;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Roxo:
                        Botoes[k].BackColor = Color.Purple;
                        GravarCorNaLista[k] = Color.Purple;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Marron:
                        Botoes[k].BackColor = Color.Brown;
                        GravarCorNaLista[k] = Color.Brown;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Verde:
                        Botoes[k].BackColor = Color.Green;
                        GravarCorNaLista[k] = Color.Green;
                        caixa.Add(cor);
                        break;
                    case Cores.Cor.Limao:
                        Botoes[k].BackColor = Color.Lime;
                        GravarCorNaLista[k] = Color.Lime;
                        caixa.Add(cor);
                        break;
                }
                Colors.Remove(cor);
                k++;
            }

            PreencherCores();
        }

        private Cores.Cor Sortear()
        {
            Random rand = new Random();
            Thread.Sleep(15);
            Cores.Cor cor = (Cores.Cor)rand.Next(10);
            return cor;
        }
        
        public void Verificacao(Color cor)
        {
            btnnovojogo.Enabled = false;
            mostrarCores = false;
            if (Variaveis.VezesClicado == 1)
            {
                cor_Par = cor;
                aux = Variaveis.BotaoReferente;
            }
                
            if (Variaveis.VezesClicado == 2)
            {
               

                if (cor_Par == cor)
                {
                    Thread.Sleep(500);
                    Botoes[aux].Hide();
                    Botoes[Variaveis.BotaoReferente].Hide();
                    Variaveis.Pontos = Variaveis.Pontos + 10;
                    lblponto.Text = Variaveis.Pontos.ToString();
                    Variaveis.BtnDesaparecido++;

                }
                else
                {
                    Variaveis.Pontos = Variaveis.Pontos - 3;
                    lblponto.Text = Variaveis.Pontos.ToString();
                    timer1.Enabled = true;
                }
                if (Variaveis.Pontos < 0) { lblponto.ForeColor = Color.Red; }
                else { lblponto.ForeColor = Color.Blue; }
                if (Variaveis.BtnDesaparecido == 10)
                {
                    if (MessageBox.Show("Você Fez " + lblponto.Text + " Pontos! Deseja Jogar Novamente?","Reiniciar Jogo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (Button botao in Botoes)
                        {
                            botao.Show();
                        }
                        btnnovojogo.Enabled = true;
                        Reiniciar();

                    }
                    else
                        Application.Exit();


                }
                 Variaveis.VezesClicado = 0;
            }
        }

        public void MostrarBotoes()
        {
            for (int i = 0; i < Botoes.Count; i++)
            {
                Botoes[i].Show();
            }
        }

        private void btnnovojogo_Click(object sender, EventArgs e)
        {
            Reiniciar();
        }

        private void Reiniciar()
        {
            k = 0;
            Caixa1.Clear();
            Caixa2.Clear();
            Variaveis.VezesClicado = 0;
            Variaveis.Pontos = 0;
            Variaveis.BtnDesaparecido = 0;
            lblponto.Text = "";
            MostrarBotoes();
            Sorteio(Caixa1);
            Sorteio(Caixa2);
            timer1.Enabled = true;
            mostrarCores = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int tempo = mostrarCores ? 4000 : 500;
            Thread.Sleep(tempo);

            for (int i = 0; i < Botoes.Count; i++)
                {        
                    Botoes[i].BackColor = Color.White;
                    Botoes[i].Enabled = true;
                }

                
                timer1.Enabled = false;
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClickBotao(0, button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickBotao(1, button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ClickBotao(2, button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClickBotao(3, button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ClickBotao(4, button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ClickBotao(5, button6);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ClickBotao(6, button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ClickBotao(7, button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ClickBotao(8, button9);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ClickBotao(9, button10);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ClickBotao(10, button11);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ClickBotao(11, button12);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClickBotao(12, button13);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            ClickBotao(13, button14);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ClickBotao(14, button15);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            ClickBotao(15, button16);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            ClickBotao(16, button17);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            ClickBotao(17, button18);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ClickBotao(18, button19);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ClickBotao(19, button20);
        }
        private void ClickBotao(int index, Button botao)
        {
            Variaveis.VezesClicado++;
            Variaveis.BotaoReferente = index;
            System.Drawing.Color Aux = (Color)GravarCorNaLista[index];
            botao.BackColor = Aux;
            Botoes[index].Enabled = false;
            Verificacao((Color)GravarCorNaLista[index]);
        }

       


       
    }
}
