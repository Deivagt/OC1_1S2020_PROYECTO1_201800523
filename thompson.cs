
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

using System.IO;
namespace OC1_1S2020_PROY1_201800523
{
    class thompson
    {
		int contadorNodos = 1;
		nodoThompson raiz ;
		Stack<nodoThompson> nodos = new Stack<nodoThompson>();

		Stack<nodoThompson> iniciales = new Stack<nodoThompson>();
	
		Stack<int> no = new Stack<int>();


		Stack<nodoThompson> terminales = new Stack<nodoThompson>();
	


		
		public thompson()
		{
		
		}

		
		public nodoThompson getRaiz()
		{
			return this.raiz;
		}

		public void recorridoPreorden(nodo n)
		{


			preOrder(n);
		}

		private void preOrder(nodo n)
		{
			if (n == null)
			{

				return;
			}



			preOrder(n.getIzquierda());
			preOrder(n.getDerecha());


			if (n.getEsTerminal() == false && n.getUnitario() == false)// | o . o
			{
				if (n.getValor().Equals("."))
				{
					
					Console.WriteLine(n.getIzquierda().getEsTerminal());
					Console.WriteLine(n.getDerecha().getEsTerminal());
					if (iniciales.FirstOrDefault()!= null)
					{
						/**/
						
						if (n.getIzquierda().getEsTerminal() == true && n.getDerecha().getEsTerminal() == false)
						{
							Console.WriteLine("izquierda t .");
							nodoThompson c1 = terminales.Pop();
						
							nodoThompson c2 =iniciales.Pop();
							/**/

							Console.WriteLine(c1.getValorTransicion());
							Console.WriteLine(c2.getValorTransicion());

							this.raiz = c1;

							c1.setArriba(c2);
							iniciales.Push(c1);


							if (this.raiz == null)
							{
								this.raiz = c1;
							}


						}
						else if(n.getDerecha().getEsTerminal() == true && n.getIzquierda().getEsTerminal() == false)
						{
							Console.WriteLine("derecha t .");
							nodoThompson c2 = terminales.Pop();
							nodoThompson c1 = iniciales.Pop();
							
							/**/
						
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());

							this.raiz = c1;
							iniciales.Push(c1);

							while (c1.getArriba() != null || c1.getValorTransicion() != null)
							{
								c1 = c1.getArriba();
							}


							c1.setArriba(c2);
							c1.setValorTransicion(c2.getValorTransicion());
							c2.setValorTransicion(null);

							
							

						}
						else if(n.getIzquierda().getEsTerminal() == false && n.getDerecha().getEsTerminal() == false)
						{
							Console.WriteLine("ninguno t .");

							nodoThompson c2 = iniciales.Pop();
							nodoThompson c1 = iniciales.Pop();


							/**/
							this.raiz = c1;
							iniciales.Push(c1);

							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());

							while (c1.getArriba() != null || c1.getValorTransicion() != null)
							{
								
								c1 = c1.getArriba();
							}


							c1.setValorTransicion(c2.getValorTransicion());
							c1.setArriba(c2.getArriba());
							if(c2.getAbajo() != null)
							{
								
								c1.setAbajo(c2.getAbajo());
							}

							c2.setValorTransicion(null);


						
							
							

						}
						else
						{
							Console.WriteLine("ambos t .");
							nodoThompson c2 = terminales.Pop();
							nodoThompson c1 = terminales.Pop();
							/**/
							
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());


							nodoThompson c3 = new nodoThompson(null, contadorNodos);
							contadorNodos++;

							if (this.raiz == null)
							{
								this.raiz = c1;
							}

							c1.setArriba(c2);
							c2.setArriba(c3);

							iniciales.Push(c1);

						}



					}
					else
					{
						Console.WriteLine("ambos t .");
						nodoThompson c2 = terminales.Pop();
						nodoThompson c1 = terminales.Pop();
						/**/
						
						Console.WriteLine(c2.getValorTransicion());
						Console.WriteLine(c1.getValorTransicion());


						nodoThompson c3 = new nodoThompson(null, contadorNodos);
						contadorNodos++;

						if(this.raiz == null)
						{
							this.raiz = c1;
						}

						c1.setArriba(c2);
						c2.setArriba(c3);

						iniciales.Push(c1);
						
					}


				}
				else if (n.getValor().Equals("|"))
				{
					if (iniciales.FirstOrDefault() != null)
					{
						if (n.getIzquierda().getEsTerminal() == true && n.getDerecha().getEsTerminal() == false)
						{

							nodoThompson c2 = iniciales.Pop();
							nodoThompson c1 = terminales.Pop();
							
							nodoThompson c3 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;

							c1.setId(contadorNodos);
							contadorNodos++;

							nodoThompson c4 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;

							nodoThompson c6 = new nodoThompson(null, contadorNodos);
							contadorNodos++;
							
							c3.setArriba(c1);
							c1.setArriba(c4);
							c4.setArriba(c6);

							c3.setAbajo(c2);

							while (c2.getArriba() != null || c2.getValorTransicion() != null)
							{
								c2 = c2.getArriba();
							}
							c2.setValorTransicion("ε");

							c2.setArriba(c6);

							/**/
							Console.WriteLine("izquierda t |");
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());

							iniciales.Push(c3);
							
							this.raiz = c3;
							

						}
						else if (n.getDerecha().getEsTerminal() == true && n.getIzquierda().getEsTerminal() == false)
						{
							nodoThompson c1 = iniciales.Pop();

							nodoThompson c2 = terminales.Pop();
							

							nodoThompson c3 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;


							c2.setId(contadorNodos);
							contadorNodos++;


							nodoThompson c5 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;


							nodoThompson c6 = new nodoThompson(null, contadorNodos);
							contadorNodos++;


							c3.setAbajo(c2);
							c2.setArriba(c5);
							c5.setArriba(c6);

							c3.setArriba(c1);
							while (c1.getArriba() != null || c1.getValorTransicion() != null)
							{
								c1 = c1.getArriba();
							}
							c1.setValorTransicion("ε");

							c1.setArriba(c6);



							/**/
							Console.WriteLine("derecha t |");
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());


							iniciales.Push(c3);

							this.raiz = c3;


						}
						else if (n.getIzquierda().getEsTerminal() == false && n.getDerecha().getEsTerminal() == false)
						{
							nodoThompson c2 = iniciales.Pop();
							nodoThompson c1 = iniciales.Pop();

						


							nodoThompson c3 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;

							

							nodoThompson c6 = new nodoThompson(null, contadorNodos);
							contadorNodos++;


							c3.setArriba(c1);
							while (c1.getArriba() != null || c1.getValorTransicion() != null)
							{
								c1 = c1.getArriba();
							}
							c1.setValorTransicion("ε");
							c1.setArriba(c6);

							c3.setAbajo(c2);
							while (c2.getArriba() != null || c2.getValorTransicion() != null)
							{
								c2 = c2.getArriba();
							}
							c2.setValorTransicion("ε");
							c2.setArriba(c6);

							



							/**/
							Console.WriteLine("ninguno t |");
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());


							iniciales.Push(c3);

							this.raiz = c3;

						}
						else
						{
							nodoThompson c2 = terminales.Pop();

							nodoThompson c1 = terminales.Pop();
							contadorNodos = c1.getId();


							nodoThompson c3 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;


							c1.setId(contadorNodos);
							contadorNodos++;


							nodoThompson c4 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;


							nodoThompson c6 = new nodoThompson(null, contadorNodos);
							contadorNodos++;
							c2.setId(contadorNodos);
							contadorNodos++;

							nodoThompson c5 = new nodoThompson("ε", contadorNodos);
							contadorNodos++;


							c3.setArriba(c1);
							c1.setArriba(c4);
							c4.setArriba(c6);

							c3.setAbajo(c2);
							c2.setArriba(c5);
							c5.setArriba(c6);

							/**/
							Console.WriteLine("ambos t |");
							Console.WriteLine(c2.getValorTransicion());
							Console.WriteLine(c1.getValorTransicion());



							iniciales.Push(c3);


							if (this.raiz == null)
							{
								this.raiz = c3;
							}
						}

					}
					else
					{

						nodoThompson c2 = terminales.Pop();
						
						nodoThompson c1 = terminales.Pop();
						contadorNodos = c1.getId();


						nodoThompson c3 = new nodoThompson("ε",contadorNodos);
						contadorNodos++;


						c1.setId(contadorNodos);
						contadorNodos++;


						nodoThompson c4 = new nodoThompson("ε", contadorNodos);
						contadorNodos++;


						nodoThompson c6 = new nodoThompson(null, contadorNodos);
						contadorNodos++;
						c2.setId(contadorNodos);
						contadorNodos++;

						nodoThompson c5 = new nodoThompson("ε", contadorNodos);
						contadorNodos++;
						

						c3.setArriba(c1);
						c1.setArriba(c4);
						c4.setArriba(c6);

						c3.setAbajo(c2);
						c2.setArriba(c5);
						c5.setArriba(c6);

						/**/
						Console.WriteLine("ambos t |");
						Console.WriteLine(c2.getValorTransicion());
						Console.WriteLine(c1.getValorTransicion());


						iniciales.Push(c3);


						if (this.raiz == null)
						{
							this.raiz = c3;
						}
					}
					
				}
			}
			else if (n.getEsTerminal() == false && n.getUnitario() == true)// *
			{
				if (iniciales.FirstOrDefault() != null)
				{
					if (n.getIzquierda().getEsTerminal() == true)
					{
						nodoThompson c1 = terminales.Pop();

						nodoThompson c2 = new nodoThompson("ε", contadorNodos);
						contadorNodos++;

						nodoThompson c3 = new nodoThompson("ε", contadorNodos);
						contadorNodos++;

						nodoThompson c4 = new nodoThompson(null, contadorNodos);
						contadorNodos++;


						c2.setArriba(c1);
						c2.setAbajo(c4);

						c1.setArriba(c3);
						c3.setArriba(c4);

						c3.setAbajo(c1);


						iniciales.Push(c2);

						Console.WriteLine("si t *");
						Console.WriteLine(c1.getValorTransicion());

						if (this.raiz == null)
						{
							this.raiz = c2;
						}



					}
					else 
					{
						nodoThompson c1 = iniciales.Pop();

						nodoThompson c2 = new nodoThompson("ε", contadorNodos);
						contadorNodos++;

						nodoThompson c3 = c1;
						

						nodoThompson c4 = new nodoThompson(null, contadorNodos);
						contadorNodos++;

						Console.WriteLine("no t *");
						Console.WriteLine(c1.getValorTransicion());
						c2.setArriba(c1);
						c2.setAbajo(c4);

						while (c1.getArriba() != null || c1.getValorTransicion() != null)
						{
							c1 = c1.getArriba();
						}
						c1.setValorTransicion("ε");

						c1.setArriba(c4);
						c1.setAbajo(c3);
					





						iniciales.Push(c2);

						this.raiz = c2;
					}
					

				}
				else
				{
					nodoThompson c1 = terminales.Pop();

					nodoThompson c2 = new nodoThompson("ε", contadorNodos);
					contadorNodos++;

					nodoThompson c3 = new nodoThompson("ε", contadorNodos);
					contadorNodos++;

					nodoThompson c4 = new nodoThompson(null, contadorNodos);
					contadorNodos++;

					Console.WriteLine("no t *");
					Console.WriteLine(c1.getValorTransicion());

					c2.setArriba(c1);
					c2.setAbajo(c4);

					c1.setArriba(c3);
					c3.setArriba(c4);

					c3.setAbajo(c1);

					iniciales.Push(c2);
					if (this.raiz == null)
					{
						this.raiz = c2;
					}

				}


			}
			else
			{

				nodoThompson th = new nodoThompson(n.getValor(), contadorNodos);
				contadorNodos++;
				terminales.Push(th);


			}


		}

		void concatenar()
		{

		}
				
		void disyun()
		{

		}

		void kleene()
		{

		}
		
		

		public void imprimirNodos()
		{
			while (nodos.FirstOrDefault() != null)
			{
				nodoThompson n = nodos.Pop();
				Console.WriteLine("transicion: "+n.getValorTransicion() + " id: "+n.getId() ) ;
				if(n.getArriba() != null)
				{
					Console.WriteLine(n.getArriba().getId());
				}
				if (n.getAbajo() != null)
				{
					Console.WriteLine(n.getAbajo().getId());
				}
			}

		}





		/*------------------------------------------------------------------*/

		public void graficarAFN(String nombre)
		{
			grafo = new StringBuilder();
			String rdot = ruta + "\\imagenafn.dot";
			String rpng = ruta + "\\salida\\afn\\" + nombre + ".png";
			grafo.Append("digraph G { rankdir = LR; style=invis;");
			grafo.Append(escribirAFN(this.raiz));
			grafo.Append("}");
			this.generador(rdot, rpng);

		}

		
		string escribirAFN(nodoThompson n)
		{
			string nodos;

			
		
			if(n.getArriba() == null  && n.getAbajo()== null)
			{
				nodos = "nodo" + n.getId() + " [ label =\"" + n.getId() + "\"shape= doublecircle];\n";
			}
			else
			{
				nodos = "nodo" + n.getId() + " [ label =\"" + n.getId() + "\" ];\n";
			}
			


			if (n.getArriba() != null)
			{
				bool control = true;
				//Console.WriteLine("vuelta a");
				foreach (int j in no)
				{
					
					//Console.WriteLine(j);
					if (n.getId() == j)
					{
						control = false;
					}
				}
				if (control == true) {
					if (n.getAbajo() == null)
					{
						no.Push(n.getId());
					}
					nodos = nodos + escribirAFN(n.getArriba())
					+ "nodo" + n.getId() + "->nodo" + n.getArriba().getId() + " [label=" + n.getValorTransicion() + "]" + ";\n";

			}
				
				/*if (!n.getValorTransicion().Equals("ε"))
				{
					no.Push(n.getId());
				}
				if(n.getArriba()!= null)
				{
					if (n.getArriba().getValorTransicion() == null || n.getArriba().getValorTransicion().Equals("ε"))
					{
						no.Push(n.getId());
					}
				}*/
			}
			if (n.getAbajo() != null)
			{
				bool control = true;
				//
				foreach (int j in no)
				{
					//Console.WriteLine(j);
					if (n.getId() == j)
					{
						control = false;
					}
				}
				if (control == true)
				{
					no.Push(n.getId());
					nodos = nodos + escribirAFN(n.getAbajo())
					+ "nodo" + n.getId() + "->nodo" + n.getAbajo().getId() + " [label=" + n.getValorTransicion() + "]" + ";\n"; ;
					
				}
				
				/*if (!n.getValorTransicion().Equals("ε"))
				{
					
				}
				if (n.getArriba() != null)
				{
					if (n.getArriba().getValorTransicion() == null || n.getArriba().getValorTransicion().Equals("ε"))
					{
						no.Push(n.getId());
					}
				}*/
				/*nodos = nodos + escribirAFN(n.getAbajo())
					+ "nodo" + n.getId() + "->nodo" + n.getAbajo().getId() + " [label=" + n.getValorTransicion() + "]" + ";\n";*/
			}

			//nodos += "nodo" + raiz.getId() + " [ label =\"" + raiz.getId() + "\"];\n";
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

		
	}
}
