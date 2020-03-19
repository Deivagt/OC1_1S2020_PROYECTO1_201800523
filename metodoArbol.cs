
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using System.IO;
namespace OC1_1S2020_PROY1_201800523
{
    class metodoArbol
    {

		nodo raiz;
		int n;
		LinkedList<nodo> newNodos;
		LinkedList<System.Object> siguientes;
		string auxiliar = "";
		public metodoArbol()
		{
			raiz = null;
			n = 0;
			newNodos = new LinkedList<nodo>();
			siguientes = new LinkedList<System.Object>();
		}

		public void genArbol(LinkedList<nodo> nodos)
		{

	
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

			genAnulable();
			genPrimeros();
			genUltimos();

			recorridoPreorden();
			Console.WriteLine(siguientes);

			//genSiguientes();

			/*imprimirTerminales();*/

			/*recorridoPreorden();*/
			/*System.out.println(escribirArbol(this.raiz));*/
		}

		public void recorridoPreorden()
		{
			preOrder(raiz);
		}

		private void preOrder(nodo n)
		{
			if (n == null)
			{

				return;
			}

			if (n.getEsTerminal() == true)
			{
				siguientes.AddLast(Int32.Parse(n.getPrimeros()));

			}

			preOrder(n.getIzquierda());
			preOrder(n.getDerecha());
		}

		public void imprimirTerminales()
		{

			hT(raiz);
		}

		private void hT(nodo n)
		{
			if (n == null)
			{

				return;
			}
			if (n.getEsTerminal() == true)
			{
				Console.WriteLine(n.getValor() + n.getSiguientes());

			}

			hT(n.getIzquierda());
			hT(n.getDerecha());
		}

		public void genAnulable()
		{
			hAnulable(raiz);
		}

		private void hAnulable(nodo n)
		{
			if (n == null)
			{
				return;
			}

			hAnulable(n.getIzquierda());
			hAnulable(n.getDerecha());
			if (n.getEsTerminal() == false && n.getUnitario() == false)
			{
				switch (n.getValor())
				{
					case ".":
						if (n.getIzquierda().getAnulable() == true && n.getDerecha().getAnulable() == true)
						{
							n.setAnulable(true);
						}
						else
						{
							n.setAnulable(false);
						}
						break;
					case "|":
						if (n.getIzquierda().getAnulable() == true || n.getDerecha().getAnulable() == true)
						{
							n.setAnulable(true);
						}
						else
						{
							n.setAnulable(false);
						}

						break;
					default:
						break;
				}
			}
			else if (n.getEsTerminal() == false && n.getUnitario() == true)
			{
				switch (n.getValor())
				{
					case "*":
						n.setAnulable(true);
						break;
					case "+":
						if (n.getIzquierda().getAnulable() == true)
						{
							n.setAnulable(true);
						}
						else
						{
							n.setAnulable(false);
						}
						break;
					case "?":
						n.setAnulable(true);
						break;
					default:
						break;

				}
			}
		}

		public void genPrimeros()
		{
			hPrimeros(raiz);
		}

		private void hPrimeros(nodo n)
		{
			if (n == null)
			{
				return;
			}

			hPrimeros(n.getIzquierda());
			hPrimeros(n.getDerecha());
			if (n.getEsTerminal() == false && n.getUnitario() == false)
			{
				switch (n.getValor())
				{
					case ".":
						if (n.getIzquierda().getAnulable() == true)
						{
							n.setPrimeros(n.getIzquierda().getPrimeros() + "," + n.getDerecha().getPrimeros());
						}
						else
						{
							n.setPrimeros(n.getIzquierda().getPrimeros());
						}
						break;
					case "|":
						n.setPrimeros(n.getIzquierda().getPrimeros() + "," + n.getDerecha().getPrimeros());
						break;
					default:
						break;
				}
			}
			else if (n.getEsTerminal() == false && n.getUnitario() == true)
			{
				switch (n.getValor())
				{
					case "*":
						n.setPrimeros(n.getIzquierda().getPrimeros());
						break;
					case "+":
						n.setPrimeros(n.getIzquierda().getPrimeros());
						break;
					case "?":
						n.setPrimeros(n.getIzquierda().getPrimeros());
						break;
					default:
						break;

				}
			}
		}

		public void genUltimos()
		{
			hUltimos(raiz);
		}

		private void hUltimos(nodo n)
		{
			if (n == null)
			{
				return;
			}
			hUltimos(n.getIzquierda());

			hUltimos(n.getDerecha());
			if (n.getEsTerminal() == false && n.getUnitario() == false)
			{

				switch (n.getValor())
				{
					case ".":

						if (n.getDerecha().getAnulable() == true)
						{
							n.setUltimos(n.getIzquierda().getUltimos() + "," + n.getDerecha().getUltimos());
						}
						else
						{
							n.setUltimos(n.getDerecha().getUltimos());
						}
						break;
					case "|":
						n.setUltimos(n.getIzquierda().getUltimos() + "," + n.getDerecha().getUltimos());
						break;
					default:
						break;
				}
			}
			else if (n.getEsTerminal() == false && n.getUnitario() == true)
			{
				switch (n.getValor())
				{
					case "*":
						n.setUltimos(n.getIzquierda().getUltimos());
						break;
					case "+":
						n.setUltimos(n.getIzquierda().getUltimos());
						break;
					case "?":
						n.setUltimos(n.getIzquierda().getUltimos());
						break;
					default:
						break;

				}
			}
		}

		/*public void genSiguientes()
		{
			hsiguientes(raiz);
		}*/

		/*rivate void hsiguientes(nodo n)
		{
			if (n == null)
			{
				return;
			}

			if (n.getEsTerminal() == false && n.getUnitario() == false)
			{
				switch (n.getValor())
				{
					case ".":
						string[] Lossiguientes = separar(n.getIzquierda().getUltimos());
						string[] primDerecha = separar(n.getDerecha().getPrimeros());
						for (int i = 0; i <= Lossiguientes.Length - 1; i++)
						{

							buscarConfirmar(Integer.parseInt(Lossiguientes[i]), primDerecha);

						}
						break;
					default:
						break;
				}
			}
			else if (n.getEsTerminal() == false && n.getUnitario() == true)
			{
				switch (n.getValor())
				{
					case "*":
						string[] Lossiguientes1 = separar(n.getIzquierda().getUltimos());
						string[] prim1 = separar(n.getIzquierda().getPrimeros());
						for (int i = 0; i <= Lossiguientes1.Length - 1; i++)
						{

							buscarConfirmar(Integer.parseInt(Lossiguientes1[i]), prim1);

						}
						break;
					case "+":
						string[] Lossiguientes2 = separar(n.getIzquierda().getUltimos());
						string[] prim2 = separar(n.getIzquierda().getPrimeros());

						for (int i = 0; i <= Lossiguientes2.Length - 1; i++)
						{

							buscarConfirmar(Integer.parseInt(Lossiguientes2[i]), prim2);

						}
						break;

					default:
						break;

				}
			}
			hsiguientes(n.getIzquierda());
			hsiguientes(n.getDerecha());

		}
		*/
		/*void imprimir(LinkedList<nodo> n)
		{
			/*Iterator<nodo> it = newNodos.listIterator();
			while (it.hasNext()) {
				nodo t = it.next();
				System.out.println(t.getIzquierda().getValor()+ " <--> " + t.getValor()+ " <--> " +t.getDerecha().getValor());
			}
			Iterator<nodo> f = n.listIterator();

			while (f.hasNext())
			{
				nodo nt = f.next();
				if (nt.unitario == true)
				{
					/*System.out.println(nt.getIzquierda().getValor() + " " + nt.getValor() + " " + nt.getAnulable());
				}
				else
				{
					if (nt.esTerminal == false)
					{

					}
				}

			}
		}*/

		public int getN()
		{
			return n;
		}

		/*public void buscarConfirmar(int id, string[] nsiguientes)
		{
			hBC(raiz, id, nsiguientes);
		}

		private void hBC(nodo n, int id, string[] nsiguientes)
		{
			if (n == null)
			{

				return;
			}

			if (n.getEsTerminal() == true)
			{

				if (Integer.parseInt(n.getPrimeros()) == id)
				{
					LinkedList<System.Object> aux = new LinkedList<System.Object>();
					for (int i = 0; i <= nsiguientes.Length - 1; i++)
					{
						aux.AddLast(nsiguientes[i]);
					}

					LinkedList<System.Object> aux1 = n.getSiguientes();

					if (! (aux1.First() == null))
					{
						for (int j = 0; j < aux1.size(); j++)
						{
							aux.AddLast(aux1.get(j));
						}
					}

					n.setSiguientes(aux);

				}

			}

			hBC(n.getIzquierda(), id, nsiguientes);
			hBC(n.getDerecha(), id, nsiguientes);
		}*/

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

		/*  void generarTablaPrimeros(String nombre) throws IOException
	  {
		  String contenido = " <TABLE BORDER=\"0\" CELLBORDER=\"1\" CELLSPACING=\"0\" CELLPADDING=\"4\">";
		  contenido += "<TR><TD>Nodo</TD><TD>Primeros</TD><TD>Ultimos</TD><TD>Siguientes</TD>\n"
			  + "</TR>";
		  gcosa();
		  contenido += auxiliar;
		  contenido +=" </TABLE>";
		  System.out.println(contenido);
		  FileWriter a = new FileWriter(nombre + ".dot");
	  a.write(contenido);
		  a.close();
		  auxiliar = "";

		  }

		  void generarTablaUltimos(String nombre) throws IOException
	  {

	  }

	  void generarTablaSiguientes(String nombre) throws IOException
	  {

	  }
	  */
		/*public void gcosa()
		{
			hgp(raiz);
		}

		private void hgp(nodo n)
		{
			if (n == null)
			{

				return;
			}
			string temp = "";
			LinkedList<System.Object> aux1 = n.getSiguientes();

			if (!aux1.isEmpty())
			{
				for (int j = 0; j < aux1.size(); j++)
				{
					temp += aux1.get(j);
				}
			}


			auxiliar += "<TR><TD>" + n.getValor() + "</TD><TD>" + n.getPrimeros() + "</TD><TD>" + n.getUltimos() + "</TD><TD>" + temp + "</TD>\n"
				+ "</TR>";

			hgp(n.getIzquierda());
			hgp(n.getDerecha());
		}*/

		public string[] separar(string linea)
{
	return linea.Split(',');
}
    }
}
