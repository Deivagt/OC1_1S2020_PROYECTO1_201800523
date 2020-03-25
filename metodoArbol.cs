
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

using System.IO;
namespace OC1_1S2020_PROY1_201800523
{
    class metodoArbol
    {

		nodo raiz;
		
		LinkedList<nodo> newNodos;
	
		//string auxiliar = "";
		public metodoArbol()
		{
			raiz = null;
		
			newNodos = new LinkedList<nodo>();
			
		}

		public void genArbol(LinkedList<nodo> nodos)
		{
			//ε

			

			nodo last = new nodo("#", true, false, false);
			int idt;
		
			idt = Int32.Parse(nodos.Last().getPrimeros());
		
			last.setPrimeros((idt + 1).ToString());
			last.setUltimos((idt + 1).ToString());
			nodos.AddLast(last);

			this.raiz = new nodo(".", false, false, false);
			newNodos.AddFirst(this.raiz);
			nodo aux = this.raiz;
			nodo aux2 = nodos.First();
			bool esDerecha = false;

			while ((nodos.FirstOrDefault() != null))
			{
		
				if (esDerecha == false)
				{
					if (aux.getEsTerminal() == false)
					{

						aux.setIzquierda(aux2);

						aux.getIzquierda().setPrevio(aux);

						aux = aux.getIzquierda();

						nodos.RemoveFirst();
						if (!(nodos.FirstOrDefault() == null))
						{
							aux2 = nodos.First();
						}

					}
					else
					{

						while (aux.getPrevio().getUnitario() || aux.getPrevio().getDerecha() != null)
						{

							aux = aux.getPrevio();
						}

						aux.getPrevio().setDerecha(aux2);
						aux.getPrevio().getDerecha().setPrevio(aux.getPrevio());
						aux = aux.getPrevio().getDerecha();

						nodos.RemoveFirst();
						if (!(nodos.FirstOrDefault() == null))
						{
							aux2 = nodos.First();
						}

						esDerecha = true;
					}
				}
				else
				{

					if (aux.getEsTerminal() == true)
					{

						do
						{

							aux = aux.getPrevio();

						} while ((aux.getDerecha() != null && aux.getUnitario() == false) || (aux.getDerecha() == null && aux.getUnitario() == true));

						esDerecha = false;
						aux.setDerecha(aux2);
						aux.getDerecha().setPrevio(aux);
						aux = aux.getDerecha();
						nodos.RemoveFirst();
						if (!(nodos.FirstOrDefault() == null))
						{
							aux2 = nodos.First();
						}

					}
					else
					{
						aux.setIzquierda(aux2);
						aux.getIzquierda().setPrevio(aux);
						aux = aux.getIzquierda();

						nodos.RemoveFirst();
						if (!(nodos.FirstOrDefault() == null))
						{
							aux2 = nodos.First();
						}
						esDerecha = false;
					}
				}

			}

		}

		string escribirArbol(nodo n)
		{
			string nodos;
			if (n.getIzquierda() == null && n.getDerecha() == null)
			{
				nodos = "nodo" + n.getId() + " [ label =\"" + n.getValor() + "\"];\n";
			}
			else
			{
				nodos = "nodo" + n.getId() + " [ label =\"" + n.getValor() + "\"];\n";
			}
			if (n.getIzquierda() != null)
			{
				nodos = nodos + escribirArbol(n.getIzquierda())
					+ "nodo" + n.getId() + "->nodo" + n.getIzquierda().getId() + "\n";
			}
			if (n.getDerecha() != null)
			{
				nodos = nodos + escribirArbol(n.getDerecha())
					+ "nodo" + n.getId() + "->nodo" + n.getDerecha().getId() + "\n";
			}
			nodos += "nodo" + raiz.getId() + " [ label =\"" + raiz.getValor() + "\"];\n";
			return nodos;
		}

		

		String ruta = "D:\\";
		StringBuilder grafo;
		private void generador(String rdot, String rpng)
		{
			System.IO.File.WriteAllText(rdot, grafo.ToString());
			String comandoDot = "dot -Tpng " + rdot + " -o " + rpng + " ";
			var comando = string.Format(comandoDot);
			var procStart = new System.Diagnostics.ProcessStartInfo("cmd", "/C" + comando);
			var proc = new System.Diagnostics.Process();
			proc.StartInfo = procStart;
			proc.Start();
			proc.WaitForExit();
		}

		public void graficar(String nombre)
		{
			grafo = new StringBuilder();
			String rdot = ruta + "\\imagen.dot";
			String rpng = ruta +"\\salida"+ "\\"+ nombre + ".png";
			grafo.Append("digraph G { ");
			grafo.Append(escribirArbol(this.raiz));
			grafo.Append("}");
			this.generador(rdot, rpng);

		}

		public DataTable generadorNodosAFN(String nombre)
		{
			nodo nuevaCabeza = this.raiz.getIzquierda();
			thompson Thompson = new thompson();
			Thompson.recorridoPreorden(nuevaCabeza);
			Thompson.imprimirNodos();
			Thompson.graficarAFN(nombre); ;

			Recorridos r = new Recorridos(Thompson.getRaiz());
			r.obtenerTerminales();

			r.graficarAFD(nombre);

			return r.tablaTrans();

		}

		

		public void transformar()
		{
			transform(this.raiz);
		}

		private void transform(nodo n)
		{
			if (n == null)
			{

				return;
			}


			//Console.WriteLine(n.getValor() + n.getUnitario() + n.getEsTerminal());


			
			if (n.getEsTerminal() == false && n.getUnitario() == true)// * o + o ?
			{

				nodo izquierdaT = n.getIzquierda();
				nodo cabezaT = n.getPrevio();
				Console.WriteLine(cabezaT.getValor());
				Console.WriteLine(izquierdaT.getValor());

				if (n.getValor().Equals("?"))
				{
					nodo nuevo = new nodo("|", false, false, false);
					nodo derecha = new nodo("epsilon", true, false, false);

					nuevo.setIzquierda(izquierdaT) ;
					nuevo.setDerecha(derecha);
					if(cabezaT.getIzquierda() == n)
					{
						cabezaT.setIzquierda(nuevo);
					}
					else if(cabezaT.getDerecha() == n)
					{
						cabezaT.setDerecha(nuevo);
					}

					n.setIzquierda(null);

				}
				else if (n.getValor().Equals("+"))
				{
					nodo nuevo1 = new nodo(".", false, false, false);
					nodo nuevo2 = new nodo("*", false, true, false);
					
					nuevo1.setIzquierda(izquierdaT);
					nuevo1.setDerecha(nuevo2);
					nuevo2.setIzquierda(duplicar(n.getIzquierda()));

					if (cabezaT.getIzquierda() == n)
					{
						cabezaT.setIzquierda(nuevo1);
					}
					else if (cabezaT.getDerecha() == n)
					{
						cabezaT.setDerecha(nuevo1);
					}

					n.setIzquierda(null);

				}
			}
			

			transform(n.getIzquierda());
			transform(n.getDerecha());
		}

		nodo duplicar(nodo dupl)
		{
			if(dupl== null)
			{
				return dupl;
			}
			nodo n = dupl;
			dupl = new nodo("", false, false, false);
			dupl.setValor(n.getValor());
			dupl.setEsTerminal(n.getEsTerminal());
			dupl.setUnitario(n.getUnitario());
			dupl.setAnulable(n.getAnulable());


			dupl.setIzquierda(duplicar(n.getIzquierda()));
			dupl.setDerecha(duplicar(n.getDerecha()));

			return dupl;
		


		}
	}
}
