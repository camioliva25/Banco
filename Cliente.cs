/*
 * Created by SharpDevelop.
 * User: Elsenadoconsulto
 * Date: 12/11/2021
 * Time: 22:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace TP_Integrador
{
	/// <summary>
	/// Description of Cliente.
	/// </summary>
	public class Cliente
	{
		//Atributos
		private string nom , ape, dire, gmail;
		private int dni , tel;
		
		//Constructor
		public Cliente(string n, string a,int doc, int t, string d, string g)
		{
			nom=n;
			ape=a;
			dni=doc;
			tel=t;
			dire=d;
			gmail=g;
		}
		//Propiedades
		public string Nom
			{set {nom=value;} get {return nom;}}	
		public string Ape
			{set {ape=value;} get {return ape;}}
		public int Dni
            {set {dni=value;} get {return dni;}}	
        public string Dire
            {set{dire=value;}get{return dire;}}
        public string Gmail
            {set{gmail=value;}get{return gmail;}}
        public int Tel
            {set{tel=value;}get{return tel;}}
		public override string ToString()
		{
			return string.Format("[Cliente Nom={0}, Ape={1}, Dire={2}, Gmail={3}, Dni={4}, Tel={5}]", nom, ape, dire, gmail, dni, tel);
		}
			}
				
		}

