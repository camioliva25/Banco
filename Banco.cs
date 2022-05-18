/*
 * Created by SharpDevelop.
 * User: Elsenadoconsulto
 * Date: 12/11/2021
 * Time: 22:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Banco.
	/// </summary>
	public class Banco
	{
		//Atributos
		private string nombre;
		private ArrayList cuentalista;
		private ArrayList clientelista;
		
		//Constructor
		public Banco(string nombre)
		{
			this.nombre=nombre;
			cuentalista= new ArrayList();
			clientelista = new ArrayList();
		}
		//Propiedades
		public string Nombre
		{set{nombre=value;}get{return nombre;}}
		public ArrayList Cuentalista
		{get {return cuentalista;}}
		public ArrayList ClienteLista
		{get {return clientelista;}}
		
		//Métodos
		public void agregarCuenta (Cuenta cuen) //Agrega una cuenta a la lista de cuentas
			{
			cuentalista.Add(cuen);
			}
		public void verCuentas() //Muestra la lista de cuentas
			{
			foreach (Cuenta cuen in cuentalista)
				{
				Console.WriteLine (cuen);
		
	        }
        }
		public void agregarCliente (Cliente cli) //Agregó un cliente a la lista de clientes
		{			
			clientelista.Add(cli);
			
		}
		public void verListaClientes () //lista de clientes
		{	
			
			foreach (Cliente cli in clientelista)
			{
				Console.WriteLine (cli);				
			}			
		}
		public Cliente verCliente(int c)
		{
			return(Cliente) clientelista[c]; //Ver un clinte específico por número
		}
		public int cantClientes()
		{
			return clientelista.Count; //Retorna la cantidad de clientes de la lista de clientes
		}
		public void borrarCuenta (int nro) //Borra la cuenta
		{	
			bool CuentaExiste = false;
			foreach (Cuenta cuen in cuentalista)
			{				
				if (cuen.Nro==nro)
				{	
					CuentaExiste=true;
					cuentalista.Remove(cuen);
					break;
				}
				
			}
			if (CuentaExiste == false)
			{
				
				throw new NroInvalidoException(); //si ingresas un número que no corresponde a ninguna cuenta
			}
		}
		public Cuenta verCuenta (int n) //ver una cuenta específica por número
		{
			return(Cuenta) Cuentalista[n];
		}
		public int cantCuentas()
		{
			return cuentalista.Count; //Retorna la cantidad de cuentas de la lista de cuentas
		}	
		public int Cuentas(int dni)
		{
			int cantidadCuentas = 0;
			foreach(Cuenta cuenta in cuentalista)
			{
				if(cuenta.Dni == dni)
				{
					cantidadCuentas += 1;
				}
			}
			return cantidadCuentas; //Retorna la cantidad de cuentas que posee el cliente
		}
		public int CuentaDni(int nroCuen)
		{
			int dni=0;
			foreach(Cuenta cuenta in cuentalista)
			{
				if(cuenta.Nro == nroCuen)
				{
					dni = cuenta.Dni;
					break;
				}
			}
			return dni; //Retorna el dni que pertenece a la cuenta
		}
			public void borrarCliente (int dni) //borra un cliente
		    {	
			bool ClienteExiste = false;
			foreach (Cliente cli in clientelista)
			{				
				if (cli.Dni==dni)
				{	
					ClienteExiste=true;
					clientelista.Remove(cli);
					break;
				}
				
			}
			if (ClienteExiste == false)
			{
				
				throw new NroInvalidoException(); 
			}
		}
		public bool tieneSaldo(int nroCuen, int cant) //método para ver si la cuenta tiene saldo
		{
			bool HaySaldo = false;
			foreach(Cuenta cuenta in cuentalista)
			{
				if(cuenta.Nro == nroCuen && cuenta.Saldo >= cant)
				{
					HaySaldo = true;
					break;
				}
			}
			return HaySaldo; //Retorna si tiene saldo la cuenta
		}
		  public void extracción(int Nrocuen, int cant_extra) //Busca la cuenta por número de cuenta y le extrae la cantidad
		  {
		  	try{
			     foreach(Cuenta cuenta in Cuentalista)
			     {
				    if(cuenta.Nro == Nrocuen)
				    {
					   if( cuenta.Saldo >cant_extra)
					   {
						   cuenta.Saldo = cuenta.Saldo - cant_extra;
					       break;
				    }
					else{
					   	throw new SaldoInsuficienteExcepcion();
					}
			     }
			  }
		  }
		  	catch(SaldoInsuficienteExcepcion)
		  	{
		  		Console.WriteLine("El saldo es insuficiente");
		    }
   }
		  public void depositar(int Nrocuen, int cant_depo) //Busca la cuenta por número de cuenta y le deposita la cantidad
		  {
		  	foreach(Cuenta cuenta in Cuentalista)
		  	{
		  		if(cuenta.Nro == Nrocuen)
		  		{
		  			cuenta.Saldo = cuenta.Saldo + cant_depo;
		  				break;
		  		}
		  	}
		  }
	}
}