using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Tarea3_Transacciones
{
	
	public class ManageTransaction : ITransaction
	{
		List<Transaccion> tranAprobada = new List<Transaccion>();
		List<Transaccion> tranRechazada = new List<Transaccion>();
		List<Transaccion> tranCancelada = new List<Transaccion>();
		List<Transaccion> tranEliminada = new List<Transaccion>();
		GeneradorId generadorId = GeneradorId.Instancia;
		private static ManageTransaction _instancia = null;
		public static ManageTransaction Instancia
		{
			get
			{
				if (_instancia == null)
				{
					_instancia = new ManageTransaction();
				}
				return _instancia;
			}
		}
		public void Add()
		{
			try
			{
				Transaccion transaccion = new Transaccion();
				transaccion.No_trans = generadorId.GetIdRnd();
				Console.WriteLine("Transaccion #: {0}", transaccion.No_trans);
				Console.Write("Nombre Cliente: ");
				transaccion.Nombre = Console.ReadLine();
				Console.Write("Monto: ");
				transaccion.Monto = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Tipo transaccion 1-Aprobada 2-Rechazada: ");
				int tipoTrans = Convert.ToInt32(Console.ReadLine());
				switch (tipoTrans)
				{
					case 1:
						transaccion.TipoTrans = TipoTransaccion.Aprobada;
						tranAprobada.Add(transaccion);
						break;
					case 2:
						transaccion.TipoTrans = TipoTransaccion.Rechazada;
						tranRechazada.Add(transaccion);
						break;
					default:
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Tipo de transaccion invalido");
						Console.ReadKey();
						Add();
						break;
				}
				Console.WriteLine("Agregar otra transaccion? 1-Si 2-No: ");
				int opcion = Convert.ToInt32(Console.ReadLine());
				switch (opcion)
				{
					case 1:
						Add();
						break;
					case 2:
						MenuPrincipal.ShowMenu();
						break;
					default:
						break;
				}

			}
			catch (Exception ex)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Ha ocurrido un error: {0}", ex.Message);
				Console.ReadKey();
				throw;
			}
			
		}

		public void Edit()
		{
			int index;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Cyan;
			try
			{
				Console.Write("Transaccion #: ");
				int no_trans = Convert.ToInt32(Console.ReadLine());

				var result = tranAprobada.FirstOrDefault(p => p.No_trans == no_trans);
				var result2 = tranRechazada.FirstOrDefault(p => p.No_trans == no_trans);

				if (result != null)
				{
					index = tranAprobada.IndexOf(result);
					Console.WriteLine("Trs # {0} Nombre {1} Monto {2}", result.No_trans, result.Nombre, result.Monto);
					try
					{
						Console.Write("Nombre Cliente: ");
						tranAprobada[index].Nombre = Console.ReadLine();
						Console.Write("Monto: ");
						tranAprobada[index].Monto = Convert.ToDouble(Console.ReadLine());
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("Transaccion editada correctamente!");
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
					catch (Exception)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Error! entrada invalida");
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
					
				}
				else if (result2 != null)
				{
					index = tranAprobada.IndexOf(result2);
					Console.WriteLine("Trs # {0} Nombre {1} Monto {2}", result2.No_trans, result2.Nombre, result2.Monto);
					try
					{
						Console.Write("Nombre Cliente: ");
						tranRechazada[index].Nombre = Console.ReadLine();
						Console.Write("Monto: ");
						tranRechazada[index].Monto = Convert.ToDouble(Console.ReadLine());
						Console.ForegroundColor = ConsoleColor.Green;
						Console.Write("Transaccion editada correctamente!");
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
					catch (Exception)
					{
						Console.ForegroundColor = ConsoleColor.Red;
						Console.WriteLine("Error! entrada invalida");
						Console.ReadKey();
						MenuPrincipal.ShowMenu();
					}
				}

			}
			catch (Exception)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("Error! entrada invalida");
				Console.ReadKey();
				MenuPrincipal.ShowMenu();
				throw;
			}
			

		}
		public void Show()
		{

		}

		public void Delete()
		{

		}
	}
}
