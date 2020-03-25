
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OC1_1S2020_PROY1_201800523
{
    class Recorridos
    {
        int contadorEstados = 1;
        nodoThompson inicio;
        List<int> no = new List<int>();
        List<int> noCerradura;
        List<transicion> transiciones = new List<transicion>();
        List<transicion> nuevasTransiciones = new List<transicion>();
        List<nodoThompson> noAgregar = new List<nodoThompson>();
        transicion transicionActual;

        List<nodoThompson> terminales = new List<nodoThompson>();
       

        public Recorridos(nodoThompson inicio)
        {
            this.inicio = inicio;
        }


        public void obtenerTerminales()
        {
            //transicion t = new transicion(""+this.inicio.getId(), this.inicio);
            transicion t = new transicion("" + contadorEstados, this.inicio);
            contadorEstados++;
            transiciones.Add(t);

            obT(this.inicio);


            terminales = terminales.OrderBy(o => o.getValorTransicion()).ToList();

            Console.WriteLine("recorrido");
            foreach (nodoThompson n in terminales)
            {
                Console.WriteLine(n.getValorTransicion());
            }



            foreach (transicion tran in transiciones)
            {
                noCerradura = new List<int>();

                transicionActual = tran;
                obtenerCerradura(tran.getNodo());
                /*Console.WriteLine("Transiciones");
                /***************************
                Console.WriteLine(tran.getNodo().getId());
                /***************************/

               /* Console.WriteLine("nodos que alcanza");
                foreach (int i in transicionActual.getNodosAlcanza())
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("terminales que alcanza");
                foreach (nodoThompson j in transicionActual.getTerminalesAlcanza())
                {
                    Console.WriteLine(j.getValorTransicion() + " " + j.getArriba().getId());
                }*/

            }

            foreach (transicion tran in transiciones)
            {
                bool control = true;

                foreach (nodoThompson k in noAgregar)
                {
                    if (tran.getNodo() == k)
                    {
                        control = false;
                    }

                }

                if (control == true)
                {
                    nuevasTransiciones.Add(tran);
                    foreach (transicion tranTemporal in transiciones)
                    {

                        if (!(tranTemporal == tran))
                        {
                            List<int> nodosQueAlcanzaActual = tran.getNodosAlcanza();
                            List<int> nodosQueAlcanzaTemporal = tranTemporal.getNodosAlcanza();

                            List<int> diferencias = nodosQueAlcanzaActual.Except(nodosQueAlcanzaTemporal).ToList();

                            List<int> diferencias1 = nodosQueAlcanzaTemporal.Except(nodosQueAlcanzaActual).ToList();

                            foreach (int nuevosDif in diferencias1)
                            {
                                diferencias.Add(nuevosDif);
                            }

                            if ((diferencias.FirstOrDefault() == 0))
                            {
                                Console.WriteLine("No se agrega: " + tranTemporal.getNombre());
                                noAgregar.Add(tranTemporal.getNodo());

                            }
                        }

                    }
                }
            }


            Console.WriteLine("nuevasTransiciones");
            foreach (transicion l in nuevasTransiciones)
            {
                Console.WriteLine(l.getNombre());
            }
        }
        void obT(nodoThompson n)
        {

            if (n.getArriba() != null)
            {

                bool control = true;

                foreach (int j in no)
                {

                    if (n.getId() == j)
                    {
                        control = false;
                    }
                }
                if (control == true)
                {
                    if (n.getAbajo() == null)
                    {
                        no.Add(n.getId());
                    }

                    if (!n.getValorTransicion().Equals("ε"))
                    {


                        transicion sig = new transicion("" + contadorEstados, n.getArriba());
                        contadorEstados++;
                        transiciones.Add(sig);


                        bool ctrl = true;

                        foreach (nodoThompson term in terminales)
                        {
                            if (term == n)
                            {

                            }
                            else
                            {
                                if (n.getValorTransicion().Equals(term.getValorTransicion()))
                                {
                                    ctrl = false;
                                }
                            }
                        }
                        if(ctrl == true)
                        {
                            terminales.Add(n);
                        }
                        



                    }
                    obT(n.getArriba());
                }


            }
            if (n.getAbajo() != null)
            {

                bool control = true;

                foreach (int j in no)
                {

                    if (n.getId() == j)
                    {
                        control = false;
                    }
                }
                if (control == true)
                {
                    if (n.getAbajo() == null)
                    {
                        no.Add(n.getId());
                    }
                    if (!n.getValorTransicion().Equals("ε"))
                    {

                        transicion sig = new transicion("" + contadorEstados, n.getArriba());

                        transiciones.Add(sig);

                        bool ctrl = true;
                        foreach (nodoThompson term in terminales)
                        {
                            if (term == n)
                            {

                            }
                            else
                            {
                                if (n.getValorTransicion().Equals(term.getValorTransicion()))
                                {
                                    ctrl = false;
                                }
                            }
                        }
                        if (ctrl == true)
                        {
                            terminales.Add(n);
                        }
                    }
                    obT(n.getAbajo());

                }
            }


        }


        void obtenerCerradura(nodoThompson n)
        {
            if(n.getValorTransicion() == null)
            {
               
                transicionActual.getTerminalesAlcanza().Add(n);
                transicionActual.setEsFinal(true);
            }
            else 
            if (!n.getValorTransicion().Equals("ε") )
            {
                transicionActual.getNodosAlcanza().Add(n.getArriba().getId());
                transicionActual.getTerminalesAlcanza().Add(n);
            }
            else
            {
                obtC(n);
            }

        }

        void obtC(nodoThompson n)
        {

            if (n.getArriba() == null && n.getAbajo() == null)
            {
                transicionActual.setEsFinal(true);
                transicionActual.getNodosAlcanza().Add(n.getId());
            }

            if (n.getArriba() != null)
            {

                bool control = true;

                foreach (int j in noCerradura)
                {

                    if (n.getId() == j)
                    {
                        control = false;
                    }
                }
                if (control == true)
                {
                    if (n.getAbajo() == null)
                    {
                        noCerradura.Add(n.getId());
                    }
                    transicionActual.getNodosAlcanza().Add(n.getId());
                    if (!n.getValorTransicion().Equals("ε"))
                    {
                        transicionActual.getTerminalesAlcanza().Add(n);
                    }
                    else
                    {

                        obtC(n.getArriba());
                    }


                }


            }
            if (n.getAbajo() != null)
            {

                bool control = true;

                foreach (int j in noCerradura)
                {

                    if (n.getId() == j)
                    {
                        control = false;
                    }
                }
                if (control == true)
                {
                    if (n.getAbajo() == null)
                    {
                        noCerradura.Add(n.getId());
                    }
                    transicionActual.getNodosAlcanza().Add(n.getId());
                    if (!n.getValorTransicion().Equals("ε"))
                    {
                        transicionActual.getTerminalesAlcanza().Add(n);
                    }
                    else
                    {

                        obtC(n.getAbajo());
                    }

                }
            }


            /*******************************************************/


        }

        String ruta = "D:\\";
        public void graficarAFD(String nombre)
        {
            grafo = new StringBuilder();
            String rdot = ruta + "\\imagenafd.dot";
            String rpng = ruta + "\\salida\\afd\\" + nombre + ".png";
            grafo.Append("digraph G { rankdir = LR; style=invis; \n");




            grafo.Append(escribirAFD());


            grafo.Append("}");
            this.generador(rdot, rpng);

        }


        string escribirAFD()
        {
            string nodos = "";


            foreach (transicion transicionActual in nuevasTransiciones)
            {
                if (transicionActual.getEsFinal() == true)
                {
                    nodos = nodos + "nodo" + transicionActual.getNombre() + " [ label =\"" + transicionActual.getNombre() + "\"shape= doublecircle];\n";
                }
                else
                {
                    nodos = nodos + "nodo" + transicionActual.getNombre() + " [ label =\"" + transicionActual.getNombre() + "\"];\n";
                }


                List<nodoThompson> terminales1 = transicionActual.getTerminalesAlcanza();
                foreach (nodoThompson terminalActual in terminales1)
                {
                    foreach (transicion trancisionTemporal in nuevasTransiciones)
                    {
                        if (terminalActual.getArriba() == trancisionTemporal.getNodo())
                        {
                            nodos = nodos + "nodo" + transicionActual.getNombre() + "->nodo" + trancisionTemporal.getNombre() + " [label=" + terminalActual.getValorTransicion() + "]" + ";\n";
                        }
                    }
                }

            }

            Console.WriteLine(nodos);

            return nodos;
        }




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

        public DataTable tablaTrans()
        {
            DataTable tablaTransiciones = new DataTable();
            DataColumn columna;
            DataRow fila;

            columna = new DataColumn();
            columna.ColumnName = "Estados";
            tablaTransiciones.Columns.Add(columna);

            foreach (nodoThompson termActual in terminales)
            {
                columna = new DataColumn();
                columna.ColumnName = termActual.getValorTransicion();
                tablaTransiciones.Columns.Add(columna);


            }

            foreach (transicion transicionActual in nuevasTransiciones)
            {
                fila = tablaTransiciones.NewRow();
                fila["Estados"] = transicionActual.getNombre();

                List<nodoThompson> terminales1 = transicionActual.getTerminalesAlcanza();
                foreach (nodoThompson terminalActual in terminales1)
                {

                    foreach (transicion trancisionTemporal in nuevasTransiciones)
                    {
                        
                        if (terminalActual.getArriba() == trancisionTemporal.getNodo())
                        {
                            fila[terminalActual.getValorTransicion()] = trancisionTemporal.getNombre();

                        }
                        
                    }
                }

                tablaTransiciones.Rows.Add(fila);
            }


            return tablaTransiciones;
        }

    }

}

