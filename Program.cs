/*Un banco tiene nombre y un conjunto de cuentas bancarias. De cada cuenta se conoce su nro,
apellido y dni del cliente titular y saldo. De los clientes la información relevante es su nombre y
apellido, dni, dirección, teléfono de contacto y mail.
Se deberá desarrollar una aplicación, utilizando las clases que crea necesarias, que resuelva las
funcionalidades que se muestran en el siguiente menú:
a) Agregar una cuenta al banco. Si el cliente es nuevo (no tiene otra cuenta previa) se debe dar
de alta en la lista de clientes y debe efectuar un depósito de dinero en la caja nueva.
b) Eliminar una cuenta y si no existe ninguna otra cuenta del mismo titular, dar de baja también
al cliente.
c) Listado de clientes que tienen más de una cuenta , indicando nro de cuenta y saldo de cada
una.
d) Realizar una extracción. En caso de no poseer saldo suficiente se debe levantar una
excepción que indique lo sucedido (“Saldo insuficiente”)
e) Depositar dinero en una cuenta dada.
f) Transferir dinero entre dos cuentas. Validar existencia de saldo en la cuenta origen.
g) Listado de cuentas
h) Listado de clientes*/

using System;
using System.Collections;

namespace TP_Integrador
{
	class Program
	{
		public static void Main(string[] args)
		{
			FaltaCuentaException faltacuenta= new FaltaCuentaException (); //inicializó las excepciones
			NroInvalidoException errornro= new NroInvalidoException ();
			SaldoInsuficienteExcepcion saldoInsuficiente = new SaldoInsuficienteExcepcion();
			Banco ban= new Banco("UNAJ");
			Cuenta cuen= new Cuenta("Parra", 23232323, 1234, 1000);
			Cuenta cuen2=new Cuenta("Oliva", 12121212, 1235, 500);
			Cliente cli= new Cliente("Matias", "Parra", 23232323, 42222222, "Calle falsa 123", "parra@gmail.com");
		    Cliente cli2= new Cliente("Camila", "Oliva", 12121212, 45555555, "Calchaqui 456", "oliva@gmail.com");
		    ban.agregarCliente(cli);
		    ban.agregarCliente(cli2);
		    ban.agregarCuenta(cuen);
		    ban.agregarCuenta(cuen2);
		    bool validacion=true; //Cuando se lanzá una excepción, el programa no se cierre
		    int respuesta;
		    string mensaje="*************************\nBienvenido al Banco UNAJ!\n*************************\n1)Agregar cuenta. Si el cliente es nuevo, se debe efectuar un deposito de dinero en la caja nueva.\n" +
		    	               "2)Eliminar cuenta.\n3)Listado de clientes.\n4)Listado de cuentas.\n5)Ver lista de clientes que tienen más de una cuenta.\n6)Realizar una extracción.\n7)Depositar dinero.\n" +
		    	               "8)Transferir dinero entre dos cuentas.\n0)Salir del programa.\n**********************************\nElija una opción: ";
		    Console.Write (mensaje);
		    while (validacion) //Es true, cuando se lanzá la excepción vuelve a este while y como es true continua
			{
				validacion=false;
			try
			{
			    respuesta= int.Parse(Console.ReadLine());
			    while (respuesta!=0)			
				{
					switch (respuesta)
						{
						case 1:  //agregar cuenta
							    AgregrarCuenta(ban);
							    break;
						case 2:  //eliminar cuenta
							    EliminarCuenta(ban);
								break;
						case 3:  //ver lista de clientes
							if (ban.ClienteLista.Count>0)
							{
								Console.Clear();
								Console.WriteLine ("Lista de clientes: ");
								ban.verListaClientes();
							}
							else 
							{	
								throw faltacuenta;
							}
							break;
						case 4:  //ver lista de cuentas
							if (ban.Cuentalista.Count>0)
							{
								Console.Clear();
								Console.WriteLine ("Lista de cuentas: ");
								ban.verCuentas();
							}
							else 
							{	
								throw faltacuenta;
							}
							break;
						case 5: //ver listado de clientes con más de una cuenta
							if(ban.Cuentalista.Count>0){
								Console.Clear();
								Console.WriteLine("Lista de clientes con más de una cuenta: ");
								Masdeunacuenta(ban);
							    }
							else
								
							{
								throw faltacuenta;
							}
							break;
						case 6: //Realiza una extracción
							if(ban.Cuentalista.Count>0){
								Console.Clear();
								ban.verCuentas();
								Console.WriteLine("Ingrese el número de cuenta para realizar la extracción: ");
								int Nrocuenta=int.Parse(Console.ReadLine());
								Console.WriteLine("Ingrese la cantidad de la extracción que desea realizar: ");
								int cant_extra=int.Parse(Console.ReadLine());
								ban.extracción(Nrocuenta, cant_extra);
								Console.WriteLine("La extracción se realizó con éxito");
							}
							break;
						case 7: //Depositar dinero en una cuenta dada
							if(ban.Cuentalista.Count>0){
								Console.Clear();
								ban.verCuentas();
								Console.WriteLine("Ingrese el número de cuenta a la que desea depositarle: ");
								int Nrocuen=int.Parse(Console.ReadLine());
								Console.WriteLine("Ingrese la cantidad que desea depositar: ");
								int cant_depo=int.Parse(Console.ReadLine());
								ban.depositar(Nrocuen, cant_depo);
								Console.WriteLine("Se depositó exitosamente");
							}
							break;
						case 8: //Transferir entre dos cuentas
							if(ban.Cuentalista.Count>0){
								Console.Clear();
								ban.verCuentas();
								transferencia(ban);
							}
							break;
					    default :  //cualquier otra respuesta numerica dara un error
							//Console.ForegroundColor = ConsoleColor.Red;
							Console.Clear();
							Console.WriteLine ("**********************************\nOpcion invalida");
							break;
					}	
			    
					Console.Write (mensaje);
					respuesta=int.Parse(Console.ReadLine());				
			    }
			}
         
		 catch(NroExisteException)
			{
		 	    Console.Clear();
				Console.WriteLine("**********************************\nYa existe un cliente con este número, ingrese un número distinto.");
				validacion=true;
			}
		 catch(FaltaCuentaException)
			{
				Console.WriteLine(faltacuenta);
				validacion=true;
			}
		 catch(NroInvalidoException)//catch por si ingresa un nro inválido
			{				
				
				Console.WriteLine(errornro);
				validacion=true;
			}
		 }
	}
	public static void AgregrarCuenta(Banco ban)
	{
		                    bool NroExiste=true, CliNoExiste=true ;
							string ape="";
							int dni=0 , nro=0, saldo=0;
							Console.WriteLine("Es cliente del banco? s/n");
							string opcion=Console.ReadLine();
							if (opcion=="n"){
								string nom,dire, gmail;
								int tel;
								Console.Write ("Nombre: ");
								nom=Console.ReadLine();
								Console.Write ("Apellido: ");
								ape=Console.ReadLine();
								Console.Write ("Dni: ");
								dni=int.Parse(Console.ReadLine());
								Console.Write ("Telefono del cliente: ");
								tel=int.Parse(Console.ReadLine());
								Console.Write("Dirección: ");
								dire=(Console.ReadLine());
								Console.Write ("Gmail: ");
								gmail=Console.ReadLine();
								Cliente c = new Cliente(nom,ape,dni,tel,dire,gmail);
								ban.agregarCliente(c);
								Console.Clear();
								Console.WriteLine("Cliente agregado exitosamente \nIngrese datos de la cuenta, Debe efectuar un depósito: ");//el cliente nuevo esta creado	
							    }
							else {
								while (CliNoExiste){								
									Console.Write ("Apellido: ");
									ape=Console.ReadLine();
									Console.Write ("Dni: ");
									dni=int.Parse(Console.ReadLine());
									foreach (Cliente Cli in ban.ClienteLista)
									{
										if (ape==Cli.Ape && dni==Cli.Dni)
										{																						
											CliNoExiste=false;
										}
									}
										if (CliNoExiste){
											Console.Clear ();
											Console.WriteLine ("El cliente ingresado no existe");
										}									
							    }
							}
							    Console.Write("Saldo de cuenta: ");							
							    saldo=int.Parse(Console.ReadLine());							    
							    while(NroExiste)
							    {
							    	NroExiste=false;
							    	Console.Write ("Nro de cuenta: ");							
							    	nro=int.Parse(Console.ReadLine());
							    	
							    	foreach (Cuenta Cuen in ban.Cuentalista)
                                {
							    		if(nro==Cuen.Nro)
                                {
							    			Console.WriteLine ("Ya existe un una cuenta con este número");
							    			NroExiste=true;
                                  }
							    }
							    
							 }							    
							    Cuenta Cuenta = new Cuenta (ape, dni, nro, saldo);
							    ban.agregarCuenta (Cuenta);
							    Console.Clear ();
							    Console.WriteLine ("Cuenta agregada con éxito");
	}
	public static void EliminarCuenta(Banco ban)
	{
		if (ban.Cuentalista.Count>0)
							{
								ban.verCuentas();
								Console.Write ("Ingrese el nro del cuenta que desea eliminar: ");
								int nro = int.Parse(Console.ReadLine());
								Console.Clear();
								bool ExisteCuenta= false;
								foreach(Cuenta c in ban.Cuentalista)
								{
									if(c.Nro==nro)
									{
										ExisteCuenta=true;
									}
								}
								if(ExisteCuenta==false) //Si no existe la cuenta
								{
									Console.WriteLine("El Nro de cuenta que ingresó no existe");
								}
								else //Si la cuenta existe
								{
									if(ban.Cuentas(ban.CuentaDni(nro)) == 1) //Uso el método donde retorna la cantidad de cuentas que posee el cliente y le pasa por parámetroel método que retorna el dni que pertence a la cuenta
									{
										ban.borrarCliente(ban.CuentaDni(nro)); //Se elimina al cliente, utiliza el método CuentaDni
										ban.borrarCuenta(nro); //se elimina la cuenta
										Console.WriteLine("La cuenta se eliminó con éxito"); 
										Console.WriteLine("El cliente no posee otra cuenta, por este motivo se da de baja también.");
									}
									else //En caso que el cliente tiene más de una cuenta, se elimina solo la cuenta
									{
										ban.borrarCuenta(nro);
										Console.WriteLine("La cuenta se eliminó con éxito");
									}
								}	
							}
	}
	public static void Masdeunacuenta(Banco ban)
	{
		bool existeCliente = false; //Si encuentra un cliente que cumpla la condición
		if(ban.Cuentalista.Count>0)
		{
			for(int c = 0; c < ban.cantClientes(); c++)
			{ 
				if(ban.Cuentas(ban.verCliente(c).Dni)> 1)
				{
					existeCliente = true; //Si encuentra un cliente que cumpla la condición
					Console.WriteLine("Cliente: {0}, {1}\n", ban.verCliente(c).Ape, ban.verCliente(c).Nom); //Imprime el Apellido y Nombre del cliente
					int dni = ban.verCliente(c).Dni; //Guarda el dni encontrado
					
					for(int n = 0; n < ban.cantCuentas(); n++)
					{
						if(ban.verCuenta(n).Dni == dni) //Busca las cuentas que coinciden con el dni
						{
							Console.WriteLine("Número de cuenta: {0}\n, Saldo: {1}\n", ban.verCuenta(n).Nro, ban.verCuenta(n).Saldo); //Imprime el saldo y Nro de cuenta 
						}
					}
				}
			}
			if(existeCliente == false) //Si no existen clientes con más de una cuenta imprime el mensaje
			{
				Console.WriteLine("No existen clientes con más de una cuenta");
			}
			
		  }
		
		}
	public static void transferencia(Banco ban )
	{
		if (ban.Cuentalista.Count>0)
		{
			
			Console.WriteLine("Ingrese el número de la primera cuenta: ");
			int nroo=int.Parse(Console.ReadLine());
		
			try{
				  Console.WriteLine("Ingrese la cantidad que desea transferir: ");
				  int cant=int.Parse(Console.ReadLine());
				  
				  if(ban.tieneSaldo(nroo, cant))
				  {
				  	ban.extracción(nroo, cant);
				  	Console.WriteLine("Ingrese el numero de la segunda cuenta: ");
				  	int num=int.Parse(Console.ReadLine());
				  	ban.depositar(num,cant);
				  	Console.WriteLine("La transferencia se realizó con éxito");
				  }
				  else
				  {
				  	throw new SaldoInsuficienteExcepcion();
				  }
			}
				
			catch(SaldoInsuficienteExcepcion)
			{
				Console.WriteLine("No se puede realizar la transferencia ya que posee saldo insuficiente");
			}
		 }
	  }
   }
}	