using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea3_Transacciones
{
	interface ITransaction
	{
		void Add();
		void Edit();
		void Show();
		void Delete();
	}
}
