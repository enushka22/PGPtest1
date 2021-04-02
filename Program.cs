using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinchoo.PGP;
using System.IO;

namespace PGPtest1
{
    class Program
    {

        static void Main(string[] args)
        {
            //GenerateKeyPair();
            Encrypt();
            //EncryptNSign();
            Console.ReadLine();
        }

        private static void GenerateKeyPair()
        {
            using (ChoPGPEncryptDecrypt pgp = new ChoPGPEncryptDecrypt())
                pgp.GenerateKey("pub.asc", "pri.asc", "test@test.com", "123456789", 2048);
            Console.WriteLine("PGP KeyPair generated.");
        }




        private static void EncryptNSign()
        {
            using (ChoPGPEncryptDecrypt pgp = new ChoPGPEncryptDecrypt())
            {
                using (Stream input = File.OpenRead("SampleData.txt"))
                {
                    using (Stream output = File.OpenWrite("SampleData.PGP"))
                    {
                        //pgp.CompressionAlgorithm = ChoCompressionAlgorithm.Zip;
                        pgp.EncryptAndSign(input, output, @"C:\Users\enushka-home\source\repos\PGPtest1\Pub.asc", @"C:\Users\enushka-home\source\repos\PGPtest1\Pri.asc", "123456789", true, false);
                    }
                }
            }
            Console.WriteLine("PGP Encryption done.");
        }

        





        private static void Encrypt()
        {
            using (ChoPGPEncryptDecrypt pgp = new ChoPGPEncryptDecrypt())
            {
                using (Stream input = File.OpenRead("SampleData.txt"))
                {
                    using (Stream output = File.OpenWrite("SampleData.PGP"))
                    {
                        //pgp.CompressionAlgorithm = ChoCompressionAlgorithm.Zip;
                        pgp.Encrypt(input, output, "Pub.asc", true, false);

                    }
                    Console.WriteLine("PGP Encrypt.");
                }
            }
        }













    }
   
}
