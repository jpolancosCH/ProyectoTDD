using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using Servicios;

namespace Test
{
    /**
     *La clave debe tener:
     *-Almenos una mayuscula
     *-Almenos una minuscula
     *-Seis caracteres como minimo
     *-Doce caracteres como maximo 
     *-Almenos un caracter especial 
     *- Almenos un digito
     */
    class ClaveTest{
        
        ServicioClave servicioClave;

        [SetUp]
        public void SetUp(){
            servicioClave = new ServicioClave();

        }

        [TestCase("123456", false)]//Solo digitos
        [TestCase("Julian", false)]//Solo letras
        [TestCase("Julian Polanco1&", false)]//mayor al tamaño
        [TestCase("julianp12%", false)]//solo minusculas
        [TestCase("JULIANP12%", false)]//solo mayusculas
        [TestCase("JULIAnP%", false)]//SIN DIGITOS
        [TestCase("JULIAnP12", false)]//SIN caracteres especiales
        [TestCase("327464&%", false)]//SIN letras
        [TestCase("jUl1%", false)]//menor al tamaño
        [TestCase(" ", false)]//vacia
        [TestCase("", false)]//vacia
        //validando com
        public void Validar_Composicion_Clave(String clave, bool esperado)
        {
            
            //When 
            bool resultado = servicioClave.ValidarClave(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("Axz19", true)]
        [TestCase("axz12", false)]
        [TestCase("adfH523", true)]
        [TestCase("123fsdfH", true)]
        [TestCase(" ", false)]
        public void Clave_Debe_Tener_Almenos_Una_Mayuscula(String clave, bool esperado){
          
            //When 
            bool resultado = servicioClave.ValidarMayuscula(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);

        }

        [TestCase("CDF19", false)]
        [TestCase("12341234", false)]
        [TestCase("adfH523", true)]
        [TestCase("123fsdfH", true)]
        [TestCase(" ", false)]
        public void Clave_Debe_Tener_Almenos_Una_Minuscula(String clave, bool esperado){
          
            //When
            bool resultado = servicioClave.ValidarMinuscula(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("12345", false)]
        [TestCase("123456", true)]
        [TestCase("1234567", true)]
        [TestCase("123456789012", true)]
        [TestCase("12345678901", true)]
        [TestCase("1234567890123", false)]
        [TestCase("12345678901234", false)]
        public void Clave_Debe_Tener_Longitud_Entre_seis_y_doce_caracteres(String clave, bool esperado){
            //When
            bool resultado = servicioClave.ValidarLongitud(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("123few%", true)]
        [TestCase("%miudh82%", true)]
        [TestCase("MMkdi12", false)]
        [TestCase("%·$%·$%", true)]
        [TestCase("sfgsdfgdf", false)]
        [TestCase("1234567890123", false)]
        public void Clave_Debe_Tener_Longitud_Almenos_Un_Caracter_Especial(String clave, bool esperado){
            //When
            bool resultado = servicioClave.ValidarCaracteresEspeciales(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase("1234567890123", true)]
        [TestCase("ASDFddf%$%", false)]
        [TestCase("1ASDFfffXCVB%&$2", true)]
        [TestCase("INHDU3&/lfko", true)]
        [TestCase("$%&&/%*[*[4Addd", true)]
        [TestCase("ASDFASDFA", false)]
        [TestCase("aksdfjha", false)]
        public void Clave_Debe_Tener_Almenos_Un_Digito(String clave, bool esperado){
            //When
            bool resultado = servicioClave.ValidarDigito(clave);

            //Asert
            Assert.AreEqual(esperado, resultado);
        }


    }
}
