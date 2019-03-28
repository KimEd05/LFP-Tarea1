using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _LFP_Tarea1_201700507
{
	public partial class ventanaPrincipal : Form
	{
		public ventanaPrincipal()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

		private void label1_Click(object sender, EventArgs e)
		{

		}

		private void txtNumeros_TextChanged(object sender, EventArgs e)
		{
			
		}

		private void lblMostrar_Click(object sender, EventArgs e)
		{
		}

		ListaCircular listaCircular = null;

		private void btnGuardar_Click(object sender, EventArgs e)
		{
			guardarNumeros();

            listaCircular = new ListaCircular();

            for (int i = 0; i < guardarNumeros().Length; i++)
            {
                listaCircular.insertar(guardarNumeros()[i]);
            }

            lblMostrar.Text = " ";
            lblResultado.Text = " ";
		}

		private int[] guardarNumeros()
		{
			String numeros = txtNumeros.Text;
            string[] num = numeros.Split(',');
			int[] listadoNumeros = new int[num.Length];

			for (int i = 0; i < num.Length; i++)
			{
				listadoNumeros[i] = Int32.Parse(num[i]);
			}

			ordenamientoBurbuja(listadoNumeros);

			return listadoNumeros;
		}

		private void btnResultado_Click(object sender, EventArgs e)
		{
            //lblResultado.Text = "" + listaCircular;
            listaCircular.mostrarOrdenada(lblResultado);
		}

		public static void ordenamientoBurbuja(int[] listado)
		{
			int t;
			for (int i = 1; i < listado.Length; i++)
			{
				for (int j = listado.Length - 1; j >= i; j--)
				{
					if (listado[j - 1] > listado[j]) 
					{
						t = listado[j - 1];
						listado[j - 1] = listado[j];
						listado[j] = t;
					}
				}
			}
		}

		private void btnMostrar_Click(object sender, EventArgs e)
		{
            
            listaCircular.mostrar(lblMostrar);
		}
	}

	public class ListaCircular
	{
		private Nodo raiz;
        private Nodo raizResultado;


		class Nodo
		{
			public int valor;
			public Nodo ant, sig;
		}

		public ListaCircular()
		{
			raiz = null;
		}

		public void insertar(int x)
		{
			Nodo nuevo = new Nodo();
			nuevo.valor = x;
			if (raiz == null)
			{
				nuevo.sig = nuevo;
				nuevo.ant = nuevo;
				raiz = nuevo;
                raizResultado = nuevo;
			}
			else
			{
				Nodo ultimo = raiz.ant;
				nuevo.sig = raiz;
				nuevo.ant = ultimo;
				raiz.ant = nuevo;
				ultimo.sig = nuevo;
			}
		}

		public void mostrar(Label lblMostrar)
			
		{
			Nodo reconocer = raiz;
			lblMostrar.Text = "" + reconocer.valor;
			
			raiz = reconocer.sig;
		}

		public void mostrarOrdenada(Label lblResultado)
		{
			Nodo reconocer = raizResultado;
            String texto = " ";

            do
			{                
                texto = texto + reconocer.valor + " ";
               

                if (reconocer.sig != raizResultado) {
                    texto = texto + "- ";
                }
                reconocer = reconocer.sig;

            } while (reconocer != raizResultado);

            lblResultado.Text = texto;
        }

	}

}
