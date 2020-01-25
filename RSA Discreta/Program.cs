using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// Agregados
using System.Security.Cryptography;
using System.Numerics;
using System.Collections;
using System.Globalization;

namespace RSA_Discreta
{
    public class Clave
    {
        // Longitud de clave
        public int k;
        // Exponente publico
        public BigInteger exp_pub = new BigInteger();
        // Modulo
        public BigInteger n = new BigInteger();
        // Exponente privado
        public BigInteger exp_pri = new BigInteger();
    }

    class Funciones
    {
        // Funcion que genera par de Claves
        public void generar_Claves(ref Clave keySet)
        {
            //Genero un primo de la mitad de la longitud de la clave
            BigInteger p = generar_Primo(keySet.k / 2);

            //Mientras el resto de dividir a P por el Exponente Publico sea 1, sigo buscando un nuevo P
            while (BigInteger.Remainder(p, keySet.exp_pub) == 1)
            {
                p = generar_Primo(keySet.k / 2);
            }

            //Genero un primo de la mitad de la longitud de la clave
            BigInteger q = generar_Primo(keySet.k / 2);

            //Mientras el resto de dividir a Q por el Exponente Publico sea 1
            //o P y Q sean iguales, sigo buscando un nuevo Q
            while (BigInteger.Remainder(q, keySet.exp_pub) == 1 || BigInteger.Equals(p, q))
            {
                q = generar_Primo(keySet.k / 2);
            }

            //Genero el Modulo = P*Q
            keySet.n = BigInteger.Multiply(p, q);

            //Genero L para hallar el Exponente Privado
            BigInteger lInt = new BigInteger();

            //Genero el 1 como BigInteger para poder restarle 1 a P y Q
            BigInteger unoInt = 1;

            //Calculo L = (P-1)(Q-1)
            lInt = BigInteger.Multiply(BigInteger.Subtract(p, unoInt), BigInteger.Subtract(q, unoInt));

            //Busco el Modulo Inverso ExpPri = ExpPub^(-1) (mod L)
            keySet.exp_pri = modulo_Inverso(keySet.exp_pub, lInt);
        }

        // Funcion que encripta un mensaje
        public void encriptar(ref String msg, ref String exp, ref String mod, ref String cypher)
        {
            BigInteger m = new BigInteger(System.Text.Encoding.UTF8.GetBytes(msg));
            BigInteger exp_pub = BigInteger.Parse(exp, NumberStyles.None);
            BigInteger n = BigInteger.Parse(mod, NumberStyles.None);
            BigInteger c = new BigInteger();
            c = BigInteger.ModPow(m, exp_pub, n);
            cypher = c.ToString();
        }

        // Funcion que desencripta un mensaje
        public void desencriptar(ref String cypher, ref String exp, ref String mod, ref String msg)
        {
            BigInteger c = BigInteger.Parse(cypher, NumberStyles.None);
            BigInteger exp_pri = BigInteger.Parse(exp, NumberStyles.None);
            BigInteger n = BigInteger.Parse(mod, NumberStyles.None);
            BigInteger m = new BigInteger();
            m = BigInteger.ModPow(c, exp_pri, n);
            byte[] m_array = m.ToByteArray();
            msg = System.Text.Encoding.UTF8.GetString(m_array);
        }

        // Funcion que calcula el a-1 MOD B
        BigInteger modulo_Inverso(BigInteger a, BigInteger b)
        {
            //Algoritmo adaptado a Big Integer para calcular el modulo inverso
            //http://rosettacode.org/wiki/Modular_inverse
            //Usa el Algoritmo Extendido de Euclides

            BigInteger b0 = b;
            BigInteger t, q;
            BigInteger x0 = 0;
            BigInteger x1 = 1;

            if (BigInteger.Equals(b, new BigInteger(1))) return new BigInteger(1);

            while (BigInteger.Compare(a, new BigInteger(1)) == 1)
            {
                q = BigInteger.Divide(a, b);
                t = b;
                BigInteger.DivRem(a, b, out b);
                a = t;
                t = x0;
                x0 = BigInteger.Subtract(x1, BigInteger.Multiply(q, x0));
                x1 = t;
            }

            if (x1 < 0)
            {
                x1 += b0;
            }

            return x1;
        }

        // Funcion que genera numero primos de longitud n bits
        BigInteger generar_Primo(int longitud)
        {
            //Genero un numero aleatorio y lo guardo en un arreglo de bytes de la longitud deseada
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[longitud / 8];
            rng.GetBytes(bytes);

            //Me aseguro que sea impar, seteando el bit mas bajo en 1
            //Notar que el arreglo de bytes esta en formato Little Endian
            bytes[0] |= (byte)(1 << 0);

            //Creo el Biginteger para guardar el Primo
            //Y hago un append de un byte en cero al arreglo para que lo tome como positivo
            //Al ser Little Endian es como agregar un cero adelante         
            BigInteger primo = new BigInteger(bytes.Concat(new byte[] { 0 }).ToArray());

            //Convierto el Big Integer a String y me aseguro que el mismo sea de la longitud deseada
            BigInteger primo_temp = BigInteger.Parse(primo.ToString().Substring(primo.ToString().Length - longitud / 8, longitud / 8), NumberStyles.None);
            primo = primo_temp;

            //Genero el 2 como BigInteger para poder sumarle 2 al numero Primo
            BigInteger dosInt = 2;

            //Mientras el numero no sea Primo
            while (!esPrimoMillerRabin(primo))
            {
                //Sigo buscando
                primo = BigInteger.Add(primo, dosInt);
            }

            return primo;
        }

        // Funcion interfaz de Miller Rabin
        bool esPrimoMillerRabin(BigInteger integer)
        {
            NumberType type = MillerRabin(integer, 400);
            return type == NumberType.Primo;
        }

        // Prueba de Primo usando Miller Rabin, el valor S indica la cantidad de iteraciones del algoritmo
        // Para tener menos probabilidades de obtener un falso primo
        NumberType MillerRabin(BigInteger n, int s)
        {
            BigInteger n_MenosUno = BigInteger.Subtract(n, 1);

            // Por cada iteracion
            for (int j = 1; j <= s; j++)
            {
                // Genero un "a" aleatorio entre 1 y n-1
                BigInteger a = genero_Random(n_MenosUno);

                // Si "a" es Testigo de "n" devuelvo Compuesto
                if (Testigo(a, n))
                {
                    return NumberType.Compuesto;
                }
            }

            // Si ningun "a" fue testigo de "n", devuelvo primo
            return NumberType.Primo;
        }

        // Auxiliar MillerRabin 0
        enum NumberType
        {
            Compuesto,
            Primo
        }

        // Auxiliar MillerRabin 1
        // Genero un numero aleatorio entre 1 y "n" 
        BigInteger genero_Random(BigInteger n)
        {
            byte[] max_Bytes = n.ToByteArray();
            BitArray max_Bits = new BitArray(max_Bytes);
            Random random = new Random(DateTime.Now.Millisecond);

            // Recorro el arreglo de bits de tamaño maximo
            for (int i = 0; i < max_Bits.Length; i++)
            {
                // En cada iteracion obtengo un nuevo numero al azar
                int intRandom = random.Next();

                // Si el numero al azar es par
                if ((intRandom % 2) == 0)
                {
                    // Invierto el bit del arreglo de bits
                    max_Bits[i] = !max_Bits[i];
                }
            }

            BigInteger resultado = new BigInteger();

            // Recorro el arreglo a la inversa
            for (int k = (max_Bits.Count - 1); k >= 0; k--)
            {
                BigInteger valorBit = 0;

                // Si el k-esimo bit es verdadero
                if (max_Bits[k])
                {
                    // Le asigno el valor de 2^k a valorBit
                    valorBit = BigInteger.Pow(2, k);
                }

                // Voy acumulando la suma en el resultado
                resultado = BigInteger.Add(resultado, valorBit);
            }

            BigInteger random_Bigint = new BigInteger();

            // Genero el numero al azar haciendo el resto entre resultado y "n"
            BigInteger.DivRem(resultado, n, out random_Bigint);

            return random_Bigint;
        }

        // Auxiliar MillerRabin 2
        // Funcion que verifica si "a" es testigo de "n"
        bool Testigo(BigInteger a, BigInteger n)
        {
            KeyValuePair<int, BigInteger> tyu = get_tyu(BigInteger.Subtract(n, 1));
            int t = tyu.Key;
            BigInteger u = tyu.Value;
            BigInteger[] x = new BigInteger[t + 1];

            x[0] = BigInteger.ModPow(a, u, n);

            for (int i = 1; i <= t; i++)
            {
                x[i] = BigInteger.ModPow(BigInteger.Multiply(x[i - 1], x[i - 1]), 1, n);
                BigInteger menos = BigInteger.Subtract(x[i - 1], BigInteger.Subtract(n, 1));

                if (x[i] == 1 && x[i - 1] != 1 && !menos.IsZero)
                {
                    return true;
                }
            }

            if (!x[t].IsOne)
            {
                return true;
            }

            return false;
        }

        // Auxiliar MillerRabin 3
        KeyValuePair<int, BigInteger> get_tyu(BigInteger n_MenosUno)
        {
            byte[] n_Bytes = n_MenosUno.ToByteArray();
            BitArray bits = new BitArray(n_Bytes);
            int t = 0;
            BigInteger u = new BigInteger();

            int n = bits.Count - 1;
            bool last_Bit = bits[n];

            while (!last_Bit)
            {
                t++;
                n--;
                last_Bit = bits[n];
            }

            for (int k = ((bits.Count - 1) - t); k >= 0; k--)
            {
                BigInteger valor_Bit = 0;

                if (bits[k])
                {
                    valor_Bit = BigInteger.Pow(2, k);
                }

                u = BigInteger.Add(u, valor_Bit);
            }

            KeyValuePair<int, BigInteger> tyu = new KeyValuePair<int, BigInteger>(t, u);
            return tyu;
        }
    }

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Clave keySet = new Clave();
            //Uso por defecto exponente publico 65537
            keySet.exp_pub = 65537;

            Form1 principal = new Form1(ref keySet);
            Application.Run(principal);

            principal.Dispose();
        }
    }
}
