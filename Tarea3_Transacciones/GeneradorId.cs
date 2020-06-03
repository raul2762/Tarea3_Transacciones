using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_Transacciones
{
	public class GeneradorId
	{
		private static GeneradorId _instancia = null;
		List<int> idGenerados = new List<int>();
		public static GeneradorId Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new GeneradorId();
				}
				return _instancia;
			}
		}
		public int GetIdRnd()
		{
			Random random = new Random();
			bool veryfied = true;
			int id = 0;
			while (veryfied)
			{
				id = random.Next(1000);
				veryfied = idGenerados.Contains(id);
			}

			return id;
		}
	}
}
