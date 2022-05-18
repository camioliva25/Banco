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
	/// <summary>
	/// Description of Cuenta.
	/// </summary>
		public class Cuenta
	{
		//Atributos
		private string ape;
		private int dni , nro, saldo;
		
		//Constructor
		public Cuenta(string a,int doc, int n, int s)
		{
			ape=a;
			dni=doc;
			nro=n;
			saldo=s;
			
		}
		//Propiedades
		public string Ape
			{set {ape=value;} get {return ape;}}
		public int Dni
            {set {dni=value;} get {return dni;}}	
        public int Nro
            {set{nro=value;}get{return nro;}}
        public int Saldo
            {set{saldo=value;}get{return saldo;}}
		public override string ToString()
		{
			return string.Format("[Cuenta Ape={0}, Dni={1}, Nro={2}, Saldo={3}]", ape, dni, nro, saldo);
		}
	}
}
