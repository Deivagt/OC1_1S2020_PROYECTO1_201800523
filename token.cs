using System;
using System.Collections.Generic;
using System.Text;

namespace OC1_1S2020_PROY1_201800523
{
	public class token
	{

		public enum Tipo
		{
			Numero,
			Cadena,
			S_abrirLlaves,
			S_cerrarLlaves,
			S_coma,
			S_puntoComa,
			S_dobleDiagonal,
			ID,
			S_porcentaje,
			S_dosPuntos,
			S_comillas,
			S_abriComent, //<!
			S_cerrarComent, // !>
			flechita, // ->
			concatenar,
			disyun,
			ceroUno,
			ceroMas,
			unoMas,
			conj,
			conjunto,
			expr,
			R_CONJ,
			ULTIMO,
			Comentario,
			Terminal,
			lexema,
			ERROR
		}

		private Tipo tipoToken;
		private String valor;
		private String id;
		private String mensajeError;

		public token(Tipo tipodeToken, String Valor)
		{
			this.tipoToken = tipodeToken;
			this.valor = Valor;
			this.id = asigId(tipodeToken);
			this.mensajeError = "";
		}

		public String getTipo()
		{
			switch (tipoToken)
			{
				case Tipo.Numero:
					return "Numero";
				case Tipo.Cadena:
					return "Cadena";
				case Tipo.S_abrirLlaves:
					return "Simbolo Abrir Llaves";
				case Tipo.S_cerrarLlaves:
					return "Simbolo Cerrar Llaves";
				case Tipo.S_coma:
					return "Simbolo Coma";
				case Tipo.S_puntoComa:
					return "Simbolo Punto y Coma";
				case Tipo.S_dobleDiagonal:
					return "Simbolo Doble Diagonal";
				case Tipo.ID:
					return "Identificador";
				case Tipo.S_porcentaje:
					return "Simbolo Porcentaje";
				case Tipo.S_dosPuntos:
					return "Simbolo Dos Puntos";
				case Tipo.S_comillas:
					return "Simbolo Comillas";
				case Tipo.S_abriComent:
					return "Simbolo Abrir Comentario";
				case Tipo.S_cerrarComent:
					return "Simbolo Cerrar Comentario";
				case Tipo.flechita:
					return "Simbolo Flechita";
				case Tipo.concatenar:
					return "Concatenacion";
				case Tipo.disyun:
					return "Disyuncion";
				case Tipo.ceroUno:
					return "Cero o Uno";
				case Tipo.ceroMas:
					return "Cero o Mas";
				case Tipo.unoMas:
					return "Uno o Mas";
				case Tipo.conj:
					return "Separacion conjunto";
				case Tipo.R_CONJ:
					return "Reservada CONJ";
				case Tipo.Comentario:
					return "Comentario";
				case Tipo.ULTIMO:
					return "#";
				case Tipo.conjunto:
					return "Es Conjunto";
				case Tipo.expr:
					return "Es Expresion";
				case Tipo.ERROR:
					return "00";
				case Tipo.Terminal:
					return "Es Terminal";
				case Tipo.lexema:
					return "Es Lexema";
				default:
					return "00";
			}
		}

		public String asigId(Tipo t)
		{
			switch (tipoToken)
			{
				case Tipo.Numero:
					return "01";
				case Tipo.Cadena:
					return "02";
				case Tipo.S_abrirLlaves:
					return "03";
				case Tipo.S_cerrarLlaves:
					return "04";
				case Tipo.S_coma:
					return "05";
				case Tipo.S_puntoComa:
					return "06";
				case Tipo.S_dobleDiagonal:
					return "07";
				case Tipo.ID:
					return "08";
				case Tipo.S_porcentaje:
					return "09";
				case Tipo.S_dosPuntos:
					return "10";
				case Tipo.S_comillas:
					return "11";
				case Tipo.S_abriComent:
					return "12";
				case Tipo.S_cerrarComent:
					return "13";
				case Tipo.flechita:
					return "14";
				case Tipo.concatenar:
					return "15";
				case Tipo.disyun:
					return "16";
				case Tipo.ceroUno:
					return "17";
				case Tipo.ceroMas:
					return "18";
				case Tipo.unoMas:
					return "19";
				case Tipo.conj:
					return "20";
				case Tipo.R_CONJ:
					return "21";
				case Tipo.ULTIMO:
					return "22";
				case Tipo.Comentario:
					return "23";
				case Tipo.conjunto:
					return "24";
				case Tipo.expr:
					return "25";
				case Tipo.ERROR:
					return "00";
				case Tipo.Terminal:
					return "26";
				case Tipo.lexema:
					return "27";
				default:
					return "00";
			}
		}

		public void setError(String mensaje)
		{
			this.mensajeError = mensaje;
		}

		public Tipo getTipoToken()
		{
			return tipoToken;
		}

		public void setTipoToken(Tipo tipoToken)
		{
			this.tipoToken = tipoToken;
		}

		public String getValor()
		{
			return valor;
		}

		public void setValor(String valor)
		{
			this.valor = valor;
		}

		public String getId()
		{
			return id;
		}

		public void setId(String id)
		{
			this.id = id;
		}

		public String getMensajeError()
		{
			return mensajeError;
		}

		public void setMensajeError(String mensajeError)
		{
			this.mensajeError = mensajeError;
		}

	}
}
