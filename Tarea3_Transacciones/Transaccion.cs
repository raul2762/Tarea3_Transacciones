using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_Transacciones
{
	public enum TipoTransaccion
	{
		Aprobada = 1,
		Rechazada,
		Cancelada,
		Eliminada
	}
	public class Transaccion
	{
		
		public int No_trans { get; set; }
		public string Nombre { get; set; }
		public double Monto { get; set; }
		public TipoTransaccion TipoTrans { get; set; }
	}
}
