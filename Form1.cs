using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace RandomText
{
    
    public partial class Form1 : Form
    {
        string[] textlist = {"Hva gjør mennesker som påvirker klimaet?",
                            "Hva er drivhusgasser/klimagasser?",
                            "Hva er drivhuseffekten?",
                            "Fortell om en internasjonal avtale om klima.",
                            "Hva gjør FNs klimapanel (IPCC)?",
                            "Hvorfor stiger den globale gjennomsnittstemperaturen?",
                            "Hvorfor stiger havet?",
                            "Gi et eksempel på en positiv eller negativ tilbakekobling.",
                            "Hva kan du gjøre for å leve mer klimavennlig?",
                            "Hva betyr karbonavtrykk?",
                            "(9C) Hvorfor smelter isen?",
                            "(9C) Hva er Paris-avtalen?",
                            "(9C) Hva kan du gjøre for å hindre at isen smelter?",
                            "(9C) Hvordan kan du minske forbruket ditt?",
                            "(9C) Hvordan kan du minske CO2-avtrykket ditt?",
                            "(9D) Hva er det som bryter ned ozonlaget?",
                            "(9D) Hvordan hjelper gjenbruk av klær klimaet?",
                            "(9D) Hvor mye har gjennomsnittstemperaturen på jorda økt siden 1750?",
                            "(9D) Hvordan er det bra for klimaet at vi kjører mindre bil og fly?",
                            "(9D) Hvordan går det med ozonlaget nå?",
                            "(9D) Hva vil skje hvis polene smelter?"};
        int clicks = 0;
        int n = 0;
        const int base_count = 10;
        const int c_count = 5;
        const int d_count = 6;
        int[] indices;
        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            setup();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (clicks % n == 0)
            {
                setup();
            }
            label1.Text = (indices[clicks] + 1).ToString() + ": " + textlist[indices[clicks++ % n]];
        }

        void setup()
        {
            //n = textlist.Length;
            bool c = radioButton1.Checked;
            n = base_count + (c ? c_count : d_count);
            System.Console.WriteLine("n= " + n);
            indices = new int[n];
            int i = 0;
            for (; i < base_count; i++)
                indices[i] = i;
            if (c)
                for (; i < base_count + c_count; i++)
                    indices[i] = i;
            else
                for (; i < base_count + d_count; i++)
                    indices[i] = i + c_count;
            System.Console.Write("indices= ");
            for (int j = 0; j < indices.Length; j++)
                System.Console.Write(indices[j] + ", ");
            System.Console.WriteLine();
            random.Shuffle(indices);
            System.Console.Write("indices= ");
            for (int j = 0; j < indices.Length; j++)
                System.Console.Write(indices[j] + ", ");
            System.Console.WriteLine();
            clicks = 0;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
                radioButton2.Checked = false;
            setup();   
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                radioButton1.Checked = false;
            setup();
        }
    }
    static class RandomExtensions
    {
        public static void Shuffle<T>(this Random rng, T[] array)
        {
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                T temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
        }
    }
}
