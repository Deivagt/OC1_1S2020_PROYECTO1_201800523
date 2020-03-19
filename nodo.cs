using System;
using System.Collections.Generic;
using System.Text;

namespace OC1_1S2020_PROY1_201800523
{
    public class nodo
    {
        nodo previo = null;
        nodo izquierda = null;
        nodo derecha = null;
        String valor;
        Boolean esTerminal = false;
        Boolean unitario;
        Boolean anulable = false;
        String primeros = "";
        String Ultimos = "";

        LinkedList<Object> siguientes = new LinkedList<Object>();
        public static int corr = 0;
        int id;

        public nodo(String valor, Boolean esTerminal, Boolean unitario, Boolean anulable)
        {
            this.valor = valor;
            this.esTerminal = esTerminal;
            this.unitario = unitario;
            this.anulable = anulable;
            this.id = corr++;

        }

        public nodo getPrevio()
        {
            return previo;
        }

        public void setPrevio(nodo previo)
        {
            this.previo = previo;
        }

        public nodo getIzquierda()
        {
            return izquierda;
        }

        public void setIzquierda(nodo izquierda)
        {
            this.izquierda = izquierda;
        }

        public nodo getDerecha()
        {
            return derecha;
        }

        public void setDerecha(nodo derecha)
        {
            this.derecha = derecha;
        }

        public String getValor()
        {
            return valor;
        }

        public void setValor(String valor)
        {
            this.valor = valor;
        }

        public Boolean getEsTerminal()
        {
            return esTerminal;
        }

        public void setEsTerminal(Boolean esTerminal)
        {
            this.esTerminal = esTerminal;
        }

        public Boolean getUnitario()
        {
            return unitario;
        }

        public void setUnitario(Boolean unitario)
        {
            this.unitario = unitario;
        }

        public Boolean getAnulable()
        {
            return anulable;
        }

        public void setAnulable(Boolean anulable)
        {
            this.anulable = anulable;
        }



        public int getId()
        {
            return id;
        }

        public void setId(int id)
        {
            this.id = id;
        }

        public String getPrimeros()
        {
            return primeros;
        }

        public void setPrimeros(String primeros)
        {
            this.primeros = primeros;
        }

        public String getUltimos()
        {
            return Ultimos;
        }

        public void setUltimos(String Ultimos)
        {
            this.Ultimos = Ultimos;
        }

        public static int getCorr()
        {
            return corr;
        }

        public static void setCorr(int corr)
        {
            nodo.corr = corr;
        }

        public LinkedList<Object> getSiguientes()
        {
            return siguientes;
        }

        public void setSiguientes(LinkedList<Object> siguientes)
        {
            this.siguientes = siguientes;
        }



    }
}
