using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioClave{

        public bool ValidarClave(string clave){
            if(ValidarMayuscula(clave) && ValidarMinuscula(clave) && ValidarLongitud(clave) && ValidarCaracteresEspeciales(clave) && ValidarDigito(clave)){
                return true;
                //validando comp
            }
            return false;
        }

        public bool ValidarMayuscula(String Clave){

            foreach (char c in Clave){
                if (Char.IsUpper(c)){
                    return true;
                }
            }
            return false;
        }

        public bool ValidarMinuscula(string Clave){
            foreach (char c in Clave)
            {
                if (Char.IsLower(c))
                {
                    return true;
                }
            }
            return false;
        }

        public bool ValidarLongitud(string Clave){

            if(Clave.Length>=6 && Clave.Length <= 12){
                return true;
            }

            return false;
        }

        public bool ValidarCaracteresEspeciales(string Clave){

            string especiales = "0@#$%^&*()+~_-{}[]:;\"'<>,.?¿!¡";
            var regexItem = new Regex(@"[~`!@#$%^&*()+\-\\{}´:;.,<>/?[\]""_-]");
            if (!regexItem.IsMatch(Clave)){
                return false;
            }
            return true;

        }

        public bool ValidarDigito(string clave){
            foreach (char c in clave){
                if (Char.IsDigit(c)){
                    return true;
                }
            }
            return false;
        }

       
    }
}
