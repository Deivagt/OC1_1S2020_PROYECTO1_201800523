using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OC1_1S2020_PROY1_201800523
{
	class analizador
	{

		LinkedList<metodoArbol> arboles;
		String entrada;


		private LinkedList<token> Out;
		private LinkedList<token> Errores;
		private LinkedList<expresion> expresiones;

		private int estado = 0;
		private String auxL = "";
		private String auxC = "";
		private String auxE = "";
		private String auxLex = "";

		int primUlt = 1;
		public int nErrores = 0;
		private int ntokens = 0;
		Char c;
		Boolean esConjunto = false;
		Boolean lexemas = false;

		public LinkedList<token> escanear(String entrada)
		{

			nErrores = 0;

			entrada.ToLower();
			entrada += "#";
			Out = new LinkedList<token>();
			Errores = new LinkedList<token>();
			expresiones = new LinkedList<expresion>();
			arboles = new LinkedList< metodoArbol > ();
			nodo n;
			for (int i = 0; i < entrada.Length; i++)
			{

				c = entrada.ElementAt(i);

				switch (estado)
				{

					case 0:
						auxL += entrada.ElementAt(i);
						if (Char.IsLetter(c))
						{
							estado = 1;
						}
						else if (Char.IsDigit(c))
						{
							estado = 2;
						}
						else
						{
							switch (c)
							{
								case '{':
									addtoken(token.Tipo.S_abrirLlaves);
									break;
								case '}':
									addtoken(token.Tipo.S_cerrarLlaves);
									break;
								case ',':
									addtoken(token.Tipo.S_coma);
									break;
								case ';':
									esConjunto = false;
									addtoken(token.Tipo.S_puntoComa);
									break;
								case '/':
									estado = 3;
									break;
								case '%':
									lexemas = true;
									addtoken(token.Tipo.S_porcentaje);
									break;
								case ':':
									addtoken(token.Tipo.S_dosPuntos);
									break;
								case '"':
									//addtoken(token.Tipo.S_comillas);
									estado = 4;
									break;
								case '<':
									estado = 5;
									break;

								case '-':
									estado = 6;
									break;
								case '~':
									addtoken(token.Tipo.conj);
									break;
								default:
									if (EsSeparador(i, c, entrada.Length))
									{
										estado = 0;
										auxL = "";
									}
									else
									{
										Console.WriteLine("Caracter no reconcido" + c.ToString());
										addErrortoken(token.Tipo.ERROR, c.ToString());
										estado = 0;
										nErrores++;
									}
									break;

							}
						}
						break;
					case 1:

						if (Char.IsLetter(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 1;
						}
						else if (Char.IsDigit(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 1;
						}
						else
						{
							token.Tipo tipoA = verificarPalabra();
							addtoken(tipoA);
							i--;
						}

						break;

					case 2:

						if (Char.IsLetter(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 1;
						}
						else if (Char.IsDigit(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 2;
						}
						else
						{
							addtoken(token.Tipo.Numero);
							i--;
						}

						break;
					case 3:
						if (!(c == 10 || c == 13 || c == 11 || i == entrada.Length - 1))
						{
							auxL += entrada.ElementAt(i);
						}
						else
						{
							addtoken(token.Tipo.Comentario);
							i--;
						}
						break;
					case 4:

						if (!(c == '"'))
						{

							auxL += entrada.ElementAt(i);
						}
						else
						{
							auxL += entrada.ElementAt(i);
							addtoken(token.Tipo.Cadena);

						}
						break;
					case 5:
						if (c == '!')
						{
							auxL += entrada.ElementAt(i);
							estado = 12;
						}
						else
						{
							if (EsSeparador(i, c, entrada.Length))
							{
								estado = 0;
								auxL = "";
							}
							else
							{
								Console.WriteLine("Caracter no reconcido" + c);
								addErrortoken(token.Tipo.ERROR, c.ToString());
								estado = 0;
								nErrores++;
							}
						}
						break;

					case 6:
						if (c == '-')
						{
							auxL += entrada.ElementAt(i);
							estado = 6;
						}
						else if (c == '>')
						{
							auxL += entrada.ElementAt(i);
							addtoken(token.Tipo.flechita);
							primUlt = 1;
							estado = 6;
						}
						else
						{

							if (esConjunto == true && lexemas == false)
							{ //Def conjuntos
								i--;
								estado = 7;
							}
							else if (esConjunto == false && lexemas == true)
							{ //Def Lexemas
								i--;
								estado = 8;

							}
							else
							{  //Def expresiones
								i--;
								estado = 9;
							}

							break;
						}
						break;
					case 7:
						if (Char.IsLetter(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 7;
						}
						else if (Char.IsDigit(c))
						{
							auxL += entrada.ElementAt(i);
							estado = 7;
						}
						else
						{
							switch (c)
							{
								case ',':
									auxL += entrada.ElementAt(i);
									estado = 7;
									break;
								case '~':
									auxL += entrada.ElementAt(i);
									estado = 7;
									break;
								case ';':
									addtoken(token.Tipo.conjunto);
									auxL += entrada.ElementAt(i);
									addtoken(token.Tipo.S_puntoComa);
									esConjunto = false;
									primUlt = 1;
									estado = 0;
									break;
								default:
									if (EsSeparador(i, c, entrada.Length))
									{
										estado = 7;
										auxL = "";
									}
									else
									{
										Console.WriteLine("Caracter no reconcido" + c);
										addErrortoken(token.Tipo.ERROR, c.ToString());
										estado = 0;
										nErrores++;
									}
									break;

							}
						}
						break;
					case 8:
						if ((c == '"'))
						{
							estado = 13;

						}
						else
						{
							if (EsSeparador(i, c, entrada.Length))
							{
								estado = 8;
								auxL = "";
							}
							else
							{
								Console.WriteLine("Caracter no reconcido" + c);
								addErrortoken(token.Tipo.ERROR, c.ToString());
								estado = 8;
								nErrores++;
							}
						}
						break;
					case 9:

						switch (c)
						{

							case '.':
								auxL += entrada.ElementAt(i);
								n = new nodo(auxL, false, false, false);
								expresiones.Last().getLista().AddLast(n);

								addtoken(token.Tipo.concatenar);

								estado = 9;
								break;
							case '*':
								auxL += entrada.ElementAt(i);
								n = new nodo(auxL, false, true, true);
								expresiones.Last().getLista().AddLast(n);

								addtoken(token.Tipo.ceroMas);
								estado = 9;
								break;
							case '+':
								auxL += entrada.ElementAt(i);
								n = new nodo(auxL, false, true, false);
								expresiones.Last().getLista().AddLast(n);

								addtoken(token.Tipo.unoMas);
								estado = 9;
								break;
							case '|':
								auxL += entrada.ElementAt(i);
								n = new nodo(auxL, false, false, false);
								expresiones.Last().getLista().AddLast(n);

								addtoken(token.Tipo.disyun);

								estado = 9;
								break;
							case '?':
								auxL += entrada.ElementAt(i);
								n = new nodo(auxL, false, true, true);
								expresiones.Last().getLista().AddLast(n);

								addtoken(token.Tipo.ceroUno);
								estado = 9;
								break;
							case '{':
								auxL += entrada.ElementAt(i);
								addtoken(token.Tipo.S_abrirLlaves);
								estado = 11;
								break;
							case '}':
								auxL += entrada.ElementAt(i);
								addtoken(token.Tipo.S_cerrarLlaves);
								estado = 11;
								break;
							case '"':

								estado = 10;
								break;

							case ';':
								auxL += entrada.ElementAt(i);
								addtoken(token.Tipo.S_puntoComa);
								estado = 0;
								break;
							default:
								if (EsSeparador(i, c, entrada.Length))
								{

									estado = 9;
									auxL = "";
								}
								else
								{
									auxL += entrada.ElementAt(i);
									Console.WriteLine("Caracter no reconcido" + c);
									addErrortoken(token.Tipo.ERROR, c.ToString());
									estado = 0;
									nErrores++;
								}
								break;

						}
						break;
					case 10:
						if (!(c == '"'))
						{

							auxL += entrada.ElementAt(i);
						}
						else
						{
							n = new nodo(auxL, true, false, false);
							String t = "";
							t += primUlt;
							primUlt++;
							n.setPrimeros(t);
							n.setUltimos(t);
							expresiones.Last().getLista().AddLast(n);
							addtoken(token.Tipo.Terminal);
							estado = 9;
						}
						break;
					case 11:
						if (!(c == '}'))
						{

							auxL += entrada.ElementAt(i);
						}
						else
						{
							n = new nodo(auxL, true, false, false);
							String t = "";
							t += primUlt;
							primUlt++;
							n.setPrimeros(t);
							n.setUltimos(t);
							expresiones.Last().getLista().AddLast(n);
							addtoken(token.Tipo.Terminal);
							auxL += entrada.ElementAt(i);
							addtoken(token.Tipo.S_cerrarLlaves);
							estado = 9;
						}
						break;
					case 12:
						if (!(c == '!'))
						{
							auxL += entrada.ElementAt(i);

						}
						else if (i == entrada.Length)
						{
							break;
						}
						else
						{
							auxL += entrada.ElementAt(i);
							auxL += entrada.ElementAt(i+1);
							addtoken(token.Tipo.Comentario);
							i += 2;
						}
						break;
					case 13:
						if (!(c == '"'))
						{

							auxL += entrada.ElementAt(i);
						}
						else
						{

							addtoken(token.Tipo.lexema);
							estado = 0;
						}
						break;
					default:
						break;

				}

				/* public void imprimir() {
			System.out.print(entrada);
			}*/
			}

			return Out;
		}

		/*-----------------------------------------------*/
		public void addtoken(token.Tipo tipo)
		{

			Out.AddLast(new token(tipo, auxL));
			ntokens++;
			auxL = "";
			estado = 0;

		}

		public void addErrortoken(token.Tipo tipo, String au)
		{
			Errores.AddLast(new token(tipo, au));
			auxL = "";
			estado = 0;

		}

		/*public void imprimirListatoken()
		{
			Iterator<token> it = Out.listIterator();
			while (it.hasNext())
			{
				token t = it.next();
				System.out.println(t.getTipo() + " <--> " + t.getValor());
			}
		}*/

		public void generadorArboles()
		{
			Iterator<expresion> e = expresiones.listIterator();
			while (e.hasNext())
			{
				expresion t = e.next();
				mArbol m = new mArbol();
				m.genArbol(t.getLista());
				try
				{
					m.graficarArbol(t.getNombre());
					m.generarTablaPrimeros(t.getNombre());
				}
				catch (IOException g)
				{
				}
			}
		}

		public Boolean EsSeparador(int posicion, int ascii, int cantidadCaracteres)
		{
			if (ascii == 32 || ascii == 10 || ascii == 13 || ascii == 11 || posicion == cantidadCaracteres - 1)
			{
				return true;
			}
			return false;
		}

		public token.Tipo verificarPalabra()
		{
			switch (auxL.ToLower())
			{

				case "conj":
					esConjunto = true;
					lexemas = false;
					return token.Tipo.R_CONJ;

				default:
					if (esConjunto == true && lexemas == false)
					{ //Def conjuntos
						return token.Tipo.ID;
					}
					else if (esConjunto == false && lexemas == true)
					{ //Def Lexemas
						return token.Tipo.ID;

					}
					else
					{  //Def expresiones
						expresion e = new expresion(auxL);
						expresiones.AddLast(e);
						return token.Tipo.ID;

					}

			}
		}

		public LinkedList<expresion> getExpresiones()
		{
			return expresiones;
		}

		public void setExpresiones(LinkedList<expresion> expresiones)
		{
			this.expresiones = expresiones;
		}

	}
}
