/*
 * Created by SharpDevelop.
 * User: Elsenadoconsulto
 * Date: 12/11/2021
 * Time: 22:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace TP_Integrador
{
	public class NroExisteException:Exception{}
	
public class NroInvalidoException:Exception
	{
			public override string ToString() 
			{		Console.Clear();
					return string.Format("**********************************\nEl nro ingresado no corresponde a ninguna de las cuentas registradas.");					
			}
	}
	public class FaltaCuentaException:Exception
	{
			public override string ToString() 
			{		Console.Clear();
					return string.Format("**********************************\nDebe cargar al menos una cuenta para realizar esta operación.");				
			}
	}
	public class CuentaInsuficienteException:Exception {}
	public class SaldoInsuficienteExcepcion:Exception {}
}
