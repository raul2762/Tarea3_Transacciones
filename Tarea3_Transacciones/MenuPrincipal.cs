using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_Transacciones
{
	public class MenuPrincipal
	{
		static ITransaction transact = ManageTransaction.Instancia;
		public static void ShowMenu()
		{
			Console.Clear();
			Console.WriteLine("1 - Add Transaction \n2 - Edit Transaction \n3 - Show Transaction \n4 - Delete Transaction \n5 - Salir");
			int opcion = Convert.ToInt32(Console.ReadLine());
			switch (opcion)
			{
				case 1:
					transact.Add();
					break;
				case 2:
					transact.Edit();
					break;
				case 3:
					transact.Show();
					break;
				case 4:
					transact.Delete();
					break;
				case 5:
					Environment.Exit(0);
					break;
				default:
					break;
			}
		}

	}
}
